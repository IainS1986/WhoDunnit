using Prism.DryIoc;
using DryIoc;
using Prism.Navigation;
using Prism;
using Prism.Ioc;
using WhoDunnit.Views;
using Xamarin.Forms;

namespace WhoDunnit
{
	public partial class App : PrismApplication
	{
        public App() : base(null)
        {
        }

        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
        
            await NavigationService.NavigateAsync("Navigation/MainView");
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>("Navigation");
            containerRegistry.RegisterForNavigation<MainView>();
            containerRegistry.RegisterForNavigation<PlayerSelectionView>();
        }

        public static Page GetMainPage()
        {
            // Replace the ExamplePage with whatever page is appropriate to start off your app
            //  - Like your login page, or home screen, or whatever
            return new NavigationPage(new MainView());
        }
    }
}
