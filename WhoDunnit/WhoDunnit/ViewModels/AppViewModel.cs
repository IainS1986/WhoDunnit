using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WhoDunnit.Extensions;
using Xamarin.Forms;

namespace WhoDunnit.ViewModels
{
    class AppViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService m_navigationService;
        protected INavigationService NavigationService
        {
            get { return m_navigationService; }
        }

        public AppViewModel()
        {

        }

        public AppViewModel(INavigationService navigationService)
        {
            m_navigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }

        public async Task<bool> OnBackButtonPressed()
        {
            return await NavigationService.GoBackAsync(animated: false);
        }
    }
}
