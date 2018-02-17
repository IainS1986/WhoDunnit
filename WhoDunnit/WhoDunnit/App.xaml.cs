using Prism.DryIoc;
using DryIoc;
using Prism.Navigation;
using Prism;
using Prism.Ioc;
using WhoDunnit.Views;

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

        protected override void OnInitialized()
        {
            InitializeComponent();
        
            NavigationService.NavigateAsync("MainView");
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
            containerRegistry.RegisterForNavigation<MainView>();
            containerRegistry.RegisterForNavigation<PlayerSelectionView>();
        }
    }
}
