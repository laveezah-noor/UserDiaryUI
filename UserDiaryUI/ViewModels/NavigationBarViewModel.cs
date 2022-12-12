using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserDiary;
using UserDiaryUI.Commands;
using UserDiaryUI.Service;
using UserDiaryUI.Stores;

namespace UserDiaryUI.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public bool userType => Cache.getCache().currentUser.Type == Types.admin.ToString();
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateDiariesCommand { get; }
        public ICommand NavigateProfileCommand { get; }
        public ICommand NavigateUsersCommand { get; }
        public ICommand NavigateAdminsCommand { get; }
        public ICommand NavigateUserDiariesCommand { get; }
        public ICommand LogoutPopupCommand { get; }
        
        public NavigationBarViewModel(
            INavigationService homeNavigationService,
            INavigationService diaryNavigationService,
            INavigationService profileNavigationService,
            INavigationService usersNavigationService,
            INavigationService adminsNavigationService,
            INavigationService userDiariesNavigationService,
            INavigationService loginNavigationService,
            ModalNavigationStore modalNavigationStore
            )
        {
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateDiariesCommand = new NavigateCommand(diaryNavigationService);
            NavigateProfileCommand = new NavigateCommand(profileNavigationService);
            LogoutPopupCommand = new CreateWarningModalCommand(loginNavigationService, modalNavigationStore, null, "Logout");
            if (userType)
            {
            NavigateUsersCommand = new NavigateCommand(usersNavigationService);
            NavigateAdminsCommand = new NavigateCommand(adminsNavigationService);
            NavigateUserDiariesCommand = new NavigateCommand(userDiariesNavigationService);
            }

        }
    }
}
