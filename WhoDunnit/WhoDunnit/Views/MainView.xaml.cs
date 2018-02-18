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
        private double m_backgroundAlpha;

        private double m_logoOffY;
        private double m_buttonOffScale;
        private double m_backgroundOffAlpha;

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
            m_backgroundAlpha = 1;
            
            m_logoOffY = -Logo.Height;
            m_buttonOffScale = 0;
            m_backgroundOffAlpha = 0;

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
            await AnimateUI(m_logoOffY, m_buttonOffScale, m_backgroundOffAlpha, Easing.SinIn);

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

            await AnimateUI(m_logoY, m_buttonScale, m_backgroundAlpha, Easing.SinOut);
        }

        private async Task AnimateUI(double toLogoY, double toButtonScale, double toAlpha, Easing easing)
        {
            const int AnimLength = 250;

            double logoy_target = toLogoY - Logo.Y;

            var backgroundanim = Background.FadeTo(toAlpha, AnimLength + (AnimLength / 2));
            var logoanim = Logo.TranslateTo(0, logoy_target, AnimLength, easing);
            await Task.Delay(AnimLength / 2);
            var buttonanim = NewGameButton.ScaleTo(toButtonScale, AnimLength, easing);

            await logoanim;
            await buttonanim;
            await backgroundanim;
        }
        
    }
}