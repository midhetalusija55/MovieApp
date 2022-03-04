using Movie.Common.Repository;
using Movie.Common.Viewmodels;
using Movie.Common.ViewModels;
using Movie.Common.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;

namespace Movie
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected async override void OnInitialized()
        {
            InitializeComponent();
            
            DependencyService.Register<IMovieRepository, MovieRepository>();
            try
            {
                await NavigationService.NavigateAsync("MainPage/NavigationPage/HomePage");
            }
            catch (Exception) { }
        }



        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<MovieDetailsPage, MovieDetailsPageViewModel>();
        }
    }
}
