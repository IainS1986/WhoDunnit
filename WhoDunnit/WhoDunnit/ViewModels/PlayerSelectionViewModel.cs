using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public class PlayerItem : BindableBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    class PlayerSelectionViewModel : AppViewModel
    {
        private ObservableCollection<PlayerItem> m_players;
        public ObservableCollection<PlayerItem> Players
        {
            get
            {
                return m_players;
            }
            
            set
            {
                m_players = value;
                RaisePropertyChanged(nameof(Players));
            }
        }

        private PlayerItem m_selectedItem;
        public PlayerItem SelectedItem
        {
            get
            {
                return m_selectedItem;
            }

            set
            {
                m_selectedItem = value;
                RaisePropertyChanged(nameof(SelectedItem));
                OnItemTapped();
            }
        }

        public PlayerSelectionViewModel(INavigationService navigationService) : base(navigationService)
        { 
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            Players = new ObservableCollection<PlayerItem>()
            {
                new PlayerItem(){ Description = "Player One", Name = "Me" },
                 new PlayerItem(){ Description = "Player Two", Name = "Holly" },
                  new PlayerItem(){ Description = "Player Three", Name = "Dad" },
                   new PlayerItem(){ Description = "Player Four", Name = "Mum" }
            };
        }

        public void OnItemTapped()
        {
            if (SelectedItem == null)
                return;

            Console.WriteLine(string.Format("Selected {0}", SelectedItem.Name));
        }

    }
}
