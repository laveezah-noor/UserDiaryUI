using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserDiaryUI.Commands;
using UserDiaryUI.Service;

namespace UserDiaryUI.ViewModels
{
    public class WelcomeViewModel : ViewModelBase
    {
        public ICommand NavigateCommand { get; }

        public WelcomeViewModel(INavigationService navigationService)
        {
            NavigateCommand = new NavigateCommand(navigationService);
        }
    }
}
