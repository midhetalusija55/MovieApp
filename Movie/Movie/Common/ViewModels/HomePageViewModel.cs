using Movie.Common.Models;
using Movie.Common.Repository;
using Movie.Common.Constants;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Movie.Models;

namespace Movie.Common.Viewmodels
{
    class HomePageViewModel : BindableBase
    {
        private int page = 1;
        private INavigationService _navigationService;
        private ObservableCollection<Movies> listMovies = new ObservableCollection<Movies>();
        IMovieRepository repository = DependencyService.Get<IMovieRepository>();
        public Command RefreshMoviesCommand { get; set; }
        public Command MovieTresholdReachedCommand { get; set; }

        private int _movieTreshold;
        public int MovieTreshold
        {
            get => _movieTreshold;
            set => SetProperty(ref _movieTreshold, value);
        }

        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public ObservableCollection<Movies> allMovies { get; set; }

        private bool isLoadingData;


        public bool IsLoadingData
        {
            get => isLoadingData;
            set => SetProperty(ref isLoadingData, value);
        }

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            allMovies = new ObservableCollection<Movies>();
            MovieTreshold = 1;
            _ = FetchMoviesAsync();
            MovieTresholdReachedCommand = new Command(async () => await MoviesTresholdReached());
            RefreshMoviesCommand = new Command(async () =>
            {
                await FetchMoviesAsync();
                IsRefreshing = false;
            });
        }

        public async Task FetchMoviesAsync()
        {
            if (IsLoadingData)
            {
                return;
            }
            IsLoadingData = true;
            try
            {
                MovieTreshold = 1;
                page = 1;
                listMovies.Clear();
                allMovies.Clear();
                listMovies = await repository.GetMovies(new MovieCall(ApiKeys.NOW_PLAYING, page));
                if (listMovies != null)
                {
                    foreach (Movies movie in listMovies)
                    {
                        if (movie != null && !allMovies.Contains(movie))
                        {
                            allMovies.Add(movie);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                IsLoadingData = false;
            }
        }

        private async Task MoviesTresholdReached()
        {
            if (IsLoadingData)
            {
                return;
            }
            page++;
            IsLoadingData = true;
            try
            {
                listMovies = await repository.GetMovies(new MovieCall(ApiKeys.NOW_PLAYING, page));
                foreach (Movies movie in listMovies)
                {
                    if (movie != null && !allMovies.Contains(movie))
                    {
                        allMovies.Add(movie);
                    }
                }
                if (listMovies.Count() == 0)
                {
                    MovieTreshold = -1;
                    return;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                IsLoadingData = false;
            }
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

       
    }
}