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
    public class UserDiariesViewModel : ViewModelBase
    {
        public class UserDiaryViewModel : ViewModelBase
        {

            public int userId { get; }
            public string Name { get; }
            public string UserName { get; }
            public string Status { get; }
            public int DiaryCount { get; }

            public UserDiaryViewModel(Dictionary<string, object> obj)
            {
                User user = (User)obj["User"];
                userId = (int)obj["UserId"];
                Name = user.Name;
                UserName = user.UserName;
                Status = user.Status;
                DiaryCount = (int)obj["Count"];
        }
        }

        private ObservableCollection<UserDiaryViewModel> _diaries;

        public ObservableCollection<UserDiaryViewModel> Diaries
        {
            get { return _diaries; }
            set
            {
                _diaries = value;
                OnPropertyChanged(nameof(Diaries));
            }
        }

        

        public UserDiariesViewModel(Cache cache)
        {
            UserDiary.User user = cache.currentUser;
            List<Dictionary<string, object>> list = user.DisplayDiaryLists();
            Diaries = new ObservableCollection<UserDiaryViewModel>();
            foreach (Dictionary<string, object> item in list)
            {
                Diaries.Add(new UserDiaryViewModel(item));
            }
            //if (user.userDiaries is not null && user.userDiaries.diaries.Count != 0)
            //{
            //    _diaryListViewModel = new DiaryListViewModel(user.userDiaries, modalNavigationStore, navigationService);
            //    Diaries = _diaryListViewModel._diaries;
            //}
            //Users = _userListViewModel._userlist;
            
            //diaries = new ObservableCollection<DiaryViewModel>();
            //diaries.Add(new DiaryViewModel(new UserDiary.Diary(1,"Diary 1")));
            //diaries.Add(new DiaryViewModel(new UserDiary.Diary(2, "Diary 2")));
            //diaries.Add(new DiaryViewModel(new UserDiary.Diary(3, "Diary 3")));
        }
    }
}
