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
        INavigationService<ViewModelType>
        where ViewModelType : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly NavigationBarViewModel _navigationBar;
        private readonly Func<ViewModelBase> _createViewModel;
        private readonly INavigationService<LoginViewModel> _loginNavigationService;

        public AppNavigationService(NavigationStore navigationStore, INavigationService<LoginViewModel> loginNavigationService, Func<ViewModelBase> createViewModel, NavigationBarViewModel navigationBar)
        {
            _loginNavigationService = loginNavigationService;
            _navigationBar = navigationBar;
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            
            _navigationStore.CurrentViewModel = new LandingViewModel(_loginNavigationService, _navigationBar, _createViewModel());
        }
    }
}
