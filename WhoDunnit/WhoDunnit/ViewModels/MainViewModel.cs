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
        private readonly INavigationService m_navigationService;

        public DelegateCommand OnNewGameStartCommand { get; private set; }

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            m_navigationService = navigationService;

            OnNewGameStartCommand = new DelegateCommand(OnNewGameStart);
        }

        public async void OnNewGameStart()
        {
            await m_navigationService.NavigateAsync("PlayerSelectionView");
        }
        
    }
}
