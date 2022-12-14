using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Xml.Serialization;
using UserDiary;
using UserDiaryUI.Commands;
using UserDiaryUI.Components;
using UserDiaryUI.Service;
using UserDiaryUI.Stores;

namespace UserDiaryUI.ViewModels
{
    public class UsersViewModel : ViewModelBase
    {
        
        private UserListViewModel _userListViewModel;
        public ModalUserViewModel _modalUserViewModel;
        public ObservableCollection<UserViewModel> _users;

        public ObservableCollection<UserViewModel> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public ModalUserViewModel ModalUserViewModel
        {
            get { return _modalUserViewModel; }
            set
            {
                _modalUserViewModel = value;
                OnPropertyChanged(nameof(ModalUserViewModel));
            }
        }

        public bool setModalUserViewModel(ModalUserViewModel modal)
        {
            ModalUserViewModel = modal;
            return true;
        }

        public ICommand CreateUser { get; }
        public string _userType { get; }


        public UsersViewModel(INavigationService navigationService, ModalNavigationStore modalNavigationStore, string userType)
        {
            Cache cache = Cache.getCache();
            if (cache.UserList.UsersList.Count !=0)
            {
                _userType = userType;
                _userListViewModel = new UserListViewModel(cache.UserList, modalNavigationStore, navigationService, _userType);
                Users = _userListViewModel._userlist;
                CreateUser = new CreateUserModalCommand(navigationService, modalNavigationStore, null);
            }

            //diaries = new ObservableCollection<DiaryViewModel>();
            //diaries.Add(new DiaryViewModel(new UserDiary.Diary(1,"Diary 1")));
            //diaries.Add(new DiaryViewModel(new UserDiary.Diary(2, "Diary 2")));
            //diaries.Add(new DiaryViewModel(new UserDiary.Diary(3, "Diary 3")));
        }
    }

    

}
