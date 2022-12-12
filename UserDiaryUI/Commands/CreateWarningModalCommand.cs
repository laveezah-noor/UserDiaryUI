using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using UserDiary;
using UserDiaryUI.Service;
using UserDiaryUI.Stores;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Commands
{
    public class CreateWarningModalCommand : CommandBase
    {
        private ModalNavigationStore _modalNavigationStore;
        private INavigationService _navigationService;
        private string _type;
        private object _data;

        public CreateWarningModalCommand(INavigationService navigationService, ModalNavigationStore modalNavigationStore,object data, string type)
        {
            _type = type;
            _data = data;
            _modalNavigationStore = modalNavigationStore;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            CreateModalViewModel().Navigate();
        }
        
        private INavigationService CreateModalViewModel()
        {
                return new ModalNavigationService<ModalWarningViewModel>(
                    _modalNavigationStore, 
                    () => new ModalWarningViewModel(_navigationService, _modalNavigationStore, _type, _data));

        }
    }
}
