using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserDiaryUI.ViewModels
{
    public class DiaryListingViewModel : ViewModelBase
    {

        private readonly ObservableCollection<DiaryViewModel> diaries;
        
        public IEnumerable<DiaryViewModel> Diaries => diaries;
        
        public ICommand CreateDiary { get; }

        public DiaryListingViewModel(UserDiary.Cache cache) { 
            diaries = new ObservableCollection<DiaryViewModel>();
            diaries.Add(new DiaryViewModel(new UserDiary.Diary(1,"Diary 1")));
            diaries.Add(new DiaryViewModel(new UserDiary.Diary(2, "Diary 2")));
            diaries.Add(new DiaryViewModel(new UserDiary.Diary(3, "Diary 3")));
        }
    }
}
