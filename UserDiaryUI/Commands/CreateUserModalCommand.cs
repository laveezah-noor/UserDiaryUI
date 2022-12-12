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
    public class CreateUserModalCommand : CommandBase
    {
        private ModalNavigationStore _modalNavigationStore;
        private INavigationService _navigationService;
        private object _data;

        public CreateUserModalCommand(INavigationService navigationService, ModalNavigationStore modalNavigationStore, object data)
        {
            _data = data;         
            _modalNavigationStore = modalNavigationStore;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            CreateModalViewModel(_data).Navigate();
        }
        private INavigationService CreateModalViewModel(object type)
        {
            if (_data is not null)
            {
                return new ModalNavigationService<ModalUserViewModel>(_modalNavigationStore, () => new ModalUserViewModel(_navigationService,_modalNavigationStore, (User)_data));

            }
            return new ModalNavigationService<ModalUserViewModel>(_modalNavigationStore, () => new ModalUserViewModel(_navigationService, _modalNavigationStore, null));

        }
    }
}
