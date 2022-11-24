using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserDiaryUI.Commands;
using UserDiaryUI.Service;

namespace UserDiaryUI.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateDiariesCommand { get; }
        public ICommand NavigateProfileCommand { get; }
        public ICommand NavigateUsersCommand { get; }
        public ICommand NavigateAdminsCommand { get; }
        public ICommand NavigateUserDiariesCommand { get; }

        public NavigationBarViewModel(
            INavigationService<DiaryListingViewModel> homeNavigationService,
            INavigationService<DiaryListingViewModel> diaryNavigationService,
            INavigationService<UserProfileViewModel> profileNavigationService,
            INavigationService<UsersViewModel> usersNavigationService
            )
        {
            NavigateHomeCommand = new NavigateCommand<DiaryListingViewModel>(homeNavigationService);
            NavigateDiariesCommand = new NavigateCommand<DiaryListingViewModel>(diaryNavigationService);
            NavigateProfileCommand = new NavigateCommand<UserProfileViewModel>(profileNavigationService);
            NavigateUsersCommand = new NavigateCommand<UsersViewModel>(usersNavigationService);
            NavigateAdminsCommand = new NavigateCommand<UsersViewModel>(usersNavigationService);
            NavigateUserDiariesCommand = new NavigateCommand<UsersViewModel>(usersNavigationService);

        }
    }
}
