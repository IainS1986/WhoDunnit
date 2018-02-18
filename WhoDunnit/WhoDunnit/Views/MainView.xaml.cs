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
	public partial class MainView : ContentPage
    {
        private enum AnimationStage
        {
            None,
            Out,
            In,
        }

        private AnimationStage CurrentAnimState
        {
            get;
            set;
        }

        private double m_logoY;
        private double m_buttonScale;

        private double m_logoOffY;
        private double m_buttonOffScale;

		public MainView ()
		{
			InitializeComponent ();

            CurrentAnimState = AnimationStage.None;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NewGameButton.Command = new Command(AnimateOut);

            AnimateIn();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            //Store off the UI positions we want to animate
            m_logoY = Logo.Y;
            m_buttonScale = NewGameButton.Scale;
            
            m_logoOffY = -Logo.Height;
            m_buttonOffScale = 0;

            //Animate in
            if (CurrentAnimState == AnimationStage.None)
            {
                //Move to Off animation and animate On
                Logo.TranslationY = m_logoOffY - Logo.Y;
                NewGameButton.Scale = 0;

                CurrentAnimState = AnimationStage.Out;
                AnimateIn();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            NewGameButton.Command = null;
        }

        private async void AnimateOut()
        {
            if (CurrentAnimState == AnimationStage.Out)
                return;

            CurrentAnimState = AnimationStage.Out;

            //Bounce out the UI
            await AnimateUI(m_logoOffY, m_buttonOffScale, Easing.SinIn);

            var vm = BindingContext as MainViewModel;
            if(vm != null)
            {
                vm.OnNewGameStart();
            }
        }

        private async void AnimateIn()
        {
            if (CurrentAnimState != AnimationStage.Out)
                return;

            CurrentAnimState = AnimationStage.In;

            await AnimateUI(m_logoY, m_buttonScale, Easing.SinOut);
        }

        private async Task AnimateUI(double toLogoY, double toButtonScale, Easing easing)
        {
            const int AnimLength = 250;

            double logoy_target = toLogoY - Logo.Y;

            var logoanim = Logo.TranslateTo(0, logoy_target, AnimLength, easing);
            await Task.Delay(AnimLength / 2);
            //var buttonanim = NewGameButton.TranslateTo(0, buttony_target, AnimLength, easing);
            var buttonanim = NewGameButton.ScaleTo(toButtonScale, AnimLength, easing);

            await logoanim;
            await buttonanim;
        }
        
    }
}