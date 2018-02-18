using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace WhoDunnit.ViewModels
{
    class MainViewModel : AppViewModel
    {
        public DelegateCommand OnNewGameStartCommand { get; private set; }

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            OnNewGameStartCommand = new DelegateCommand(OnNewGameStart);
        }

        public async void OnNewGameStart()
        {
            await NavigationService.NavigateAsync("PlayerSelectionView", animated:false, useModalNavigation:false);
        }
        
    }
}
