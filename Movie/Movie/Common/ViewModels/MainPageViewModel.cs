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

namespace Movie.Common.ViewModels
{
    class MainPageViewModel
    {
        private INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }
    }
}
