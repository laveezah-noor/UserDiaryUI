using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public class UserViewModel : ViewModelBase
    {
    public ICommand EditUser { get; set; }
        public ICommand DeleteUser { get; set; }
        private User _user;

        public int Id => _user.Id;
        public string Name => _user.Name;
        public string UserName => _user.UserName;
        public string Password => _user.Password;
        public string Phone => _user.phone;
        public string Email => _user.email;
        public string Status => _user.Status;
        public bool Login_Status => _user.LogStatus;

        public UserViewModel(User user, ModalNavigationStore modalNavigationStore, INavigationService navigationService)
        {
            _user = user;

            EditUser = new CreateUserModalCommand(navigationService, modalNavigationStore, user);
            DeleteUser = new CreateWarningModalCommand(navigationService, modalNavigationStore, user, "Delete User");

        }
    }

    public class UserListViewModel : ViewModelBase
    {
        public ObservableCollection<UserViewModel> _userlist;

        public UserListViewModel(DefaultUserList userList, ModalNavigationStore modalNavigationStore, INavigationService navigationService, string userType)
        {
            _userlist = new ObservableCollection<UserViewModel>();
            if (userType == "Admins") {
                foreach (var user in userList.UsersList)
                {
                    if (user.Type == Types.admin.ToString())
                    {
                    _userlist.Add(new UserViewModel(user, modalNavigationStore, navigationService));
                    }
                }


            }
            else
            {
            foreach (var user in userList.UsersList)
            {

                _userlist.Add(new UserViewModel(user, modalNavigationStore, navigationService));
            }

            }
        }
    }
}
