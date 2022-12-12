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
using UserDiaryUI.Service;
using UserDiaryUI.Stores;

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

        public ICommand EditDiary { get; set; }
        public ICommand DeleteDiary { get; set; }

        public DiaryViewModel(UserDiary.Diary diary, ModalNavigationStore modalNavigationStore, INavigationService navigationService)
        {
            _diary = diary;
            EditDiary = new CreateDiaryModalCommand(null, modalNavigationStore, diary);
            DeleteDiary = new CreateWarningModalCommand(navigationService, modalNavigationStore, diary, "Delete Diary");
        }
    }
    
    public class DiaryListViewModel : ViewModelBase
    {
        public ObservableCollection<DiaryViewModel> _diaries;

        public DiaryListViewModel(Diary_List diaryList, ModalNavigationStore modalNavigationStore, INavigationService navigationService)
        {
            _diaries = new ObservableCollection<DiaryViewModel>();
            foreach (var user in diaryList.diaries)
            {
                _diaries.Add(new DiaryViewModel(user, modalNavigationStore, navigationService));
            }
        }
    }

}
