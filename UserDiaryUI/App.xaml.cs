using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UserDiaryUI.Service;
using UserDiaryUI.Stores;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly UserDiary.Cache _cache;
        private readonly NavigationStore _navigationStore;
        private readonly INavigationService<LandingViewModel> _landingPageNavigationService;
        private readonly INavigationService<SigninViewModel> _signinPageNavigationService;
        private readonly INavigationService<LoginViewModel> _loginPageNavigationService;
        private NavigationBarViewModel navigationBarViewModel;
        public App()
        {
            _navigationStore = new NavigationStore();
            _signinPageNavigationService = CreateSigninViewModel();
            //_landingPageNavigationService = CreateHomeViewModel();
            _loginPageNavigationService = CreateLoginViewModel();
            _cache = UserDiary.Cache.getCache();
            navigationBarViewModel = new NavigationBarViewModel(CreateHomeViewModel(),
                CreateHomeViewModel(),
                CreateProfileViewModel(),CreateUserViewModel());
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            if (_cache.currentUser is not null)
            {
                //_landingPageNavigationService.Navigate();
                    //new LandingViewModel(_navigationStore, CreateLoginViewModel);
            }
            _signinPageNavigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        //private SigninViewModel CreateSigninViewModel()
        //{
        //    return new SigninViewModel(_loginPageNavigationService);
        //}

        //private LoginViewModel CreateLoginViewModel()
        //{
        //    return new LoginViewModel(_signinPageNavigationService, _landingPageNavigationService);
        //}

        private INavigationService<LoginViewModel> CreateLoginViewModel()
        {
            return new NavigationService<LoginViewModel>(_navigationStore, () => new LoginViewModel(CreateSigninViewModel(), CreateHomeViewModel()));
        }
        
        private INavigationService<SigninViewModel> CreateSigninViewModel()
        {
            return new NavigationService<SigninViewModel>(_navigationStore, () => new SigninViewModel(CreateLoginViewModel()));
        }

        //private LandingViewModel CreateLandingViewModel()
        //{
        //    return new LandingViewModel(_loginPageNavigationService, navigationBarViewModel);
        //}

        private INavigationService<DiaryListingViewModel> CreateHomeViewModel()
        {
            return new AppNavigationService<DiaryListingViewModel>(_navigationStore, CreateLoginViewModel(), () => new DiaryListingViewModel(_cache), navigationBarViewModel);
        }
        
        private INavigationService<UserProfileViewModel> CreateProfileViewModel()
        {
            return new AppNavigationService<UserProfileViewModel>(_navigationStore, CreateLoginViewModel(), () => new UserProfileViewModel(), navigationBarViewModel);
        }
        private INavigationService<UserViewModel> CreateUserViewModel()
        {
            return new AppNavigationService<UserViewModel>(_navigationStore, CreateLoginViewModel(), () => new UserViewModel(), navigationBarViewModel);
        }
    }
}
