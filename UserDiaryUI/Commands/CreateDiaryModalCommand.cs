using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDiaryUI.Service;
using UserDiaryUI.Stores;
using UserDiaryUI.ViewModels;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Commands
{
    public class CreateDiaryModalCommand : CommandBase
    {
            private ModalNavigationStore _modalNavigationStore;
            private INavigationService _navigationService;
            private object _data;

            public CreateDiaryModalCommand(INavigationService navigationService, ModalNavigationStore modalNavigationStore, object data)
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
                    return new ModalNavigationService<ModalDiaryViewModel>(_modalNavigationStore, () => new ModalDiaryViewModel(_navigationService, _modalNavigationStore, (UserDiary.Diary)_data));

                }
                return new ModalNavigationService<ModalDiaryViewModel>(_modalNavigationStore, () => new ModalDiaryViewModel(_navigationService,  _modalNavigationStore, null));

            
        }
    }
}
