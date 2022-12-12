using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDiaryUI.Stores;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Service
{
    public class AppNavigationService<ViewModelType> : 
        INavigationService
        where ViewModelType : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<NavigationBarViewModel> _navigationBar;
        private readonly Func<ViewModelBase> _createViewModel;

        public AppNavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel, Func<NavigationBarViewModel> navigationBar)
        {
            _navigationBar = navigationBar;
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            
            _navigationStore.CurrentViewModel = new LandingViewModel(_navigationBar(), _createViewModel());
        }
    }
}
