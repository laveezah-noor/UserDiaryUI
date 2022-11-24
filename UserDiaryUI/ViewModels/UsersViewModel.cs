using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using UserDiary;
using UserDiaryUI.Commands;
using UserDiaryUI.Components;

namespace UserDiaryUI.ViewModels
{
    public class UsersViewModel : ViewModelBase
    {
        private UserListViewModel _userListViewModel;
        public ModalUserViewModel _modalUserViewModel;
        public ObservableCollection<UserViewModel> Users;
        public ModalUserViewModel ModalUserViewModel
        {
            get { return _modalUserViewModel; }
            set
            {
                _modalUserViewModel = value;
                OnPropertyChanged(nameof(ModalUserViewModel));
            }
        }

        public void setModalUserViewModel(ModalUserViewModel modal)
        {
            ModalUserViewModel = modal;
        }

        public ICommand CreateUser { get; }
        public ICommand EditUser { get; }

        public UsersViewModel(UserDiary.Cache cache)
        {
            if (cache.UserList.UsersList.Count !=0)
            {
                _userListViewModel = new UserListViewModel(cache.UserList);
                Users = _userListViewModel._userlist;

                //CreateUser = new CreateUserModalCommand(setModalUserViewModel);
            }

            //diaries = new ObservableCollection<DiaryViewModel>();
            //diaries.Add(new DiaryViewModel(new UserDiary.Diary(1,"Diary 1")));
            //diaries.Add(new DiaryViewModel(new UserDiary.Diary(2, "Diary 2")));
            //diaries.Add(new DiaryViewModel(new UserDiary.Diary(3, "Diary 3")));
        }
    }

    public class CreateUserModalCommand : CommandBase
    {
        public delegate void setModal(ModalUserViewModel modal);

        public CreateUserModalCommand(setModal setModalUserViewModel)
        {
            //setModal = setModalUserViewModel;
        }

        public override void Execute(object? parameter)
        {
            //setModal.Invoke(new ModalUserViewModel(new User(), true));
        }
    }

}
