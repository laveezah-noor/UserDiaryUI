using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDiaryUI.Stores;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Service
{

    public class ModalNavigationService<ViewModelType> :
        INavigationService
        where ViewModelType : ViewModelBase
    {
        private readonly ModalNavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;

        public ModalNavigationService(ModalNavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
