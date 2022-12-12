using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserDiary;
using UserDiaryUI.Stores;
using UserDiaryUI.Service;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly INavigationService _navigationService;
        
        public NavigateCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }


        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }

    }
}
