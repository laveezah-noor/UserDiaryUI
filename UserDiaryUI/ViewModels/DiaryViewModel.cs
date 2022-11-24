using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using UserDiary;

namespace UserDiaryUI.ViewModels
{
    public class DiaryViewModel : ViewModelBase
    {
        private readonly Diary _diary;

        public int Id => _diary.Id;
        public string Name => _diary.Name;
        public string Content => _diary.Content;
        public DateTime CreatedAt => _diary.CreatedAt;
        public DateTime LastUpdate => _diary.LastUpdate;

        public DiaryViewModel(UserDiary.Diary diary)
        {
            _diary = diary;
        }
    }
    
    public class DiaryListViewModel : ViewModelBase
    {
        private readonly Diary_List _diarylist;

        public List<Diary> diaries => _diarylist.diaries;
        public int user => _diarylist.user;

        public DiaryListViewModel(Diary_List diarylist)
        {
            _diarylist = diarylist;
        }
    }

}
