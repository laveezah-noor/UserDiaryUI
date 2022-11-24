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

namespace UserDiaryUI.ViewModels
{
    public class LandingViewModel : ViewModelBase
    {
        private readonly Cache _cache;
        public NavigationBarViewModel NavigationBar { get; }
        public ViewModelBase Content { get; }

        public ICommand LogoutCommand { get; }

        public LandingViewModel(INavigationService<LoginViewModel> navigationService, NavigationBarViewModel navigationBar, ViewModelBase Content)
        {
            _cache = Cache.getCache();
            //MessageBox.Show($"{Content}");
            LogoutCommand = new LogoutCommand(navigationService);
            NavigationBar = navigationBar;
            Content = Content;
        }
    }
}
