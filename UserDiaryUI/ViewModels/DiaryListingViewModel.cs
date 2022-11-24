using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace UserDiaryUI.ViewModels
{
    public class DiaryListingViewModel : ViewModelBase
    {
        //private UserDiary.Cache cache;
        //private readonly ObservableCollection<DiaryViewModel> diaries;
        private readonly ObservableCollection<DiaryViewModel> diaries;

        //public IEnumerable<UserDiary.Diary> Diaries => diaries;
        
        public ICommand CreateDiary { get; }

        public DiaryListingViewModel(UserDiary.Cache cache) {
            UserDiary.User user = UserDiary.Cache.getCache().currentUser;
            if(user.userDiaries is not null && user.userDiaries.diaries.Count != 0)
            {
            diaries = new ObservableCollection<DiaryViewModel>((IEnumerable<DiaryViewModel>)cache.currentUser.userDiaries.diaries);
            }

            //diaries = new ObservableCollection<DiaryViewModel>();
            //diaries.Add(new DiaryViewModel(new UserDiary.Diary(1,"Diary 1")));
            //diaries.Add(new DiaryViewModel(new UserDiary.Diary(2, "Diary 2")));
            //diaries.Add(new DiaryViewModel(new UserDiary.Diary(3, "Diary 3")));
        }
    }
}
