using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrismPopupSample.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigatingAware
    {
        private INavigationService _navigationService { get; }

        public DelegateCommand LaunchPopupCommand { get; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            LaunchPopupCommand = new DelegateCommand(OnLaunchPopupCommandExecuted);
        }
        
        private async void OnLaunchPopupCommandExecuted() =>
            await _navigationService.NavigateAsync("MainPage/PopupSamplePage");

        public void OnNavigatingTo(INavigationParameters parameters)
        {

        }
    }
}
