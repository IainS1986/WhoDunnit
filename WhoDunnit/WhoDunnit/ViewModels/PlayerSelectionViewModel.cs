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
    public enum PlayerType
    {
        Me = 0,
        Holly,
        Mum,
        Dad,
        Lynne,
        Tony,
        Other
    }

    class PlayerSelectionViewModel : AppViewModel
    {
        private int m_totalPlayers;
        public int TotalPlayers
        {
            get { return m_totalPlayers; }
            set { m_totalPlayers = value; RaisePropertyChanged(nameof(TotalPlayers)); }
        }

        public PlayerSelectionViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            TotalPlayers = 4;
        }

    }
}
