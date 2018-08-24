using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismPopupSample.ViewModels
{
	public class PopupSamplePageViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService { get; }

        public PopupSamplePageViewModel(INavigationService navigationService)
        {
            System.Diagnostics.Debug.WriteLine("Hello from the PopupViewViewModel");
            _navigationService = navigationService;
            NavigateBackCommand = new DelegateCommand(OnNavigateBackCommandExecuted);
        }


        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand NavigateBackCommand { get; }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine($"{GetType().Name} Navigated From");
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine($"{GetType().Name} Navigated To");

            if (parameters.ContainsKey("message"))
            {
                Message = parameters["message"].ToString();
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine($"{GetType().Name} Navigating To");
        }


        private async void OnNavigateBackCommandExecuted()
        {
            await _navigationService.GoBackAsync(new NavigationParameters{
                { "message", "Hello from the Popup View" }
            });
        }
    }
}
