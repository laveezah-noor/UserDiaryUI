using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UserDiary;
using UserDiaryUI.Commands;
using UserDiaryUI.Service;
using UserDiaryUI.Stores;

namespace UserDiaryUI.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        //private UserDiary.Cache cache;
        //private readonly ObservableCollection<DiaryViewModel> diaries;
        //public IEnumerable<UserDiary.Diary> Diaries => diaries;

        private DiaryListViewModel _diaryListViewModel;
        public ModalUserViewModel _modalUserViewModel;
        private ObservableCollection<DiaryViewModel> _diaries;
        public string Name => Cache.getCache().currentUser.Name;

        public ObservableCollection<DiaryViewModel> Diaries
        {
            get { return _diaries; }
            set
            {
                _diaries = value;
                OnPropertyChanged(nameof(Diaries));
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

        public ICommand CreateDiary { get; }

        public HomeViewModel(CacheStore cache, INavigationService navigationService, ModalNavigationStore modalNavigationStore) {
            UserDiary.User user = cache.Cache.currentUser;

            if(user.userDiaries is not null && user.userDiaries.diaries.Count != 0)
            {
            _diaryListViewModel = new DiaryListViewModel(user.userDiaries, modalNavigationStore, navigationService);
                Diaries = _diaryListViewModel._diaries;
            }
            //Users = _userListViewModel._userlist;
            CreateDiary = new CreateDiaryModalCommand(navigationService, modalNavigationStore, null);

            //diaries = new ObservableCollection<DiaryViewModel>();
            //diaries.Add(new DiaryViewModel(new UserDiary.Diary(1,"Diary 1")));
            //diaries.Add(new DiaryViewModel(new UserDiary.Diary(2, "Diary 2")));
            //diaries.Add(new DiaryViewModel(new UserDiary.Diary(3, "Diary 3")));
        }
    }
}
