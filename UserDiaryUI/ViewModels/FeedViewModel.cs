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
    public class FeedViewModel : ViewModelBase
    {
        public class FeedDiaryViewModel : ViewModelBase
        {
            Diary _diary;
            public int userId => _diary.userId;
            public string Name => Cache.getCache().UserList.FindUser(userId).Name;
            public string Title => _diary.Name;
            public string Content => _diary.Content;
            public DateTime CreatedAt => _diary.CreatedAt;
            public DateTime LastUpdate => _diary.LastUpdate;


            public FeedDiaryViewModel(Diary diary)
            {
                _diary = diary;
                //Name = Cache.getCache().UserList.FindUser(userId).Name;
            }
        }

        private ObservableCollection<FeedDiaryViewModel> _diaries;

        public ObservableCollection<FeedDiaryViewModel> Diaries
        {
            get { return _diaries; }
            set
            {
                _diaries = value;
                OnPropertyChanged(nameof(Diaries));
            }
        }



        public FeedViewModel()
        {

            List<Diary> list = Cache.getCache().DisplayFeed();
            Diaries = new ObservableCollection<FeedDiaryViewModel>();
            foreach (var item in list)
            {
                Diaries.Add(new FeedDiaryViewModel(item));
            }
        }
    }
}
