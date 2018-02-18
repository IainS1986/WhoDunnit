using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoDunnit.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhoDunnit.Views
{
	public partial class PlayerSelectionView : ContentPage
	{
		public PlayerSelectionView()
		{
			InitializeComponent ();
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override bool OnBackButtonPressed()
        {
            PlayerSelectionViewModel vm = BindingContext as PlayerSelectionViewModel;
            if(vm!=null)
            {
                vm.OnBackButtonPressed();
                return true;
            }

            return base.OnBackButtonPressed();
        }
    }
}