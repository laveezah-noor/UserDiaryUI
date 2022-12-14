using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using UserDiary;
using UserDiaryUI.Scripts;
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
        CacheStore _cache;
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public App()
        {
            //Stores

            _cache = CacheStore.GetCache();
            _navigationStore = new NavigationStore();
            _modalNavigationStore = new ModalNavigationStore();
            
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            //Server Connection
            //MessageBox.Show(_cache.currentUser.display());
            if (_cache.currentUser.Id != 0)
            {
                CreateHomeViewModel().Navigate();
            }
            else CreateWelcomeViewModel().Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, _modalNavigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private INavigationService CreateLoginViewModel()
        {
            return new NavigationService<LoginViewModel>(
                _navigationStore, 
                () => new LoginViewModel(CreateSigninViewModel(), CreateHomeViewModel()));
        }
        
        private INavigationService CreateSigninViewModel()
        {
            return new NavigationService<SigninViewModel>(
                _navigationStore,
                () => new SigninViewModel(CreateLoginViewModel()));
        }

        private INavigationService CreateWelcomeViewModel()
        {
            return new NavigationService<WelcomeViewModel>(
                _navigationStore, 
                () => new WelcomeViewModel(CreateSigninViewModel()));
        }

        private INavigationService CreateHomeViewModel()
        {
            return new AppNavigationService<DiaryListingViewModel>(
                _navigationStore, 
                () => new HomeViewModel(_cache, CreateHomeViewModel(), _modalNavigationStore), 
                CreateNavigationBarViewModel);
        }

        private INavigationService CreateDiaryViewModel()
        {
            return new AppNavigationService<DiaryListingViewModel>(
                _navigationStore, 
                () => new DiaryListingViewModel(_cache, CreateDiaryViewModel(), _modalNavigationStore), 
                CreateNavigationBarViewModel);
        }

        private INavigationService CreateProfileViewModel()
        {
            return new AppNavigationService<UserProfileViewModel>(
                _navigationStore, 
                () => new UserProfileViewModel(_cache, CreateProfileViewModel()), 
                CreateNavigationBarViewModel);
        }

        private INavigationService CreateUserViewModel()
        {
            return new AppNavigationService<UsersViewModel>(
                _navigationStore, 
                () => new UsersViewModel(CreateUserViewModel(), _modalNavigationStore,"Users"), 
                CreateNavigationBarViewModel);

        }

        private INavigationService CreateAdminViewModel()
        {
            return new AppNavigationService<UsersViewModel>(
                _navigationStore,
                () => new UsersViewModel(CreateAdminViewModel(), _modalNavigationStore, "Admins"),
                CreateNavigationBarViewModel);

        }

        private INavigationService CreateUserDiariesViewModel()
        {
            return new AppNavigationService<UserDiariesViewModel>(
                _navigationStore,
                () => new UserDiariesViewModel(_cache),
                CreateNavigationBarViewModel);

        }

        private NavigationBarViewModel CreateNavigationBarViewModel()
        {
            return new NavigationBarViewModel(
                CreateHomeViewModel(),
                CreateDiaryViewModel(),
                CreateFeedViewModel(),
                CreateProfileViewModel(),
                CreateUserViewModel(),
                CreateAdminViewModel(),
                CreateUserDiariesViewModel(),
                CreateLoginViewModel(),
                _modalNavigationStore);
        }

        private INavigationService CreateFeedViewModel()
        {
            return new AppNavigationService<FeedViewModel>(
                _navigationStore,
                () => new FeedViewModel(),
                CreateNavigationBarViewModel);
        }
    }
}
