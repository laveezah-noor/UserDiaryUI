using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDiary;

namespace UserDiaryUI.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private User _user;

        public int Id => _user.Id;
        public string Name => _user.Name;
        public string UserName => _user.UserName;
        public string Password => _user.Password;
        public string Phone => _user.phone;
        public string Email => _user.email;
        public string Status => _user.Status;
        public bool Login_Status => _user.LogStatus;

        public UserViewModel(UserDiary.User user)
        {
            _user = user;
        }
    }

    public class UserListViewModel : ViewModelBase
    {
        public ObservableCollection<UserViewModel> _userlist;

        public UserListViewModel(DefaultUserList userList)
        {
            _userlist = new ObservableCollection<UserViewModel>();
            foreach (var user in userList.UsersList)
            {
                _userlist.Add(new UserViewModel(user));
            }
        }
    }
}
