using System;
using System.Collections.Generic;
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
    public class LandingViewModel : ViewModelBase
    {
        private readonly Cache _cache;
        public NavigationBarViewModel NavigationBar { get; }
        public ViewModelBase _contentViewModel { get; set; }

        public ViewModelBase ContentViewModel
        {
            get { return _contentViewModel; }
            set
            {
                _contentViewModel = value;
                OnPropertyChanged(nameof(ContentViewModel));
            }
        }


        public LandingViewModel(NavigationBarViewModel navigationBar, ViewModelBase content)
        {
            NavigationBar = navigationBar;
            ContentViewModel = content;
        }
    }
}
