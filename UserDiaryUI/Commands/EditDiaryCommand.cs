using UserDiaryUI.Stores;
    using UserDiaryUI.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using UserDiary;
using UserDiaryUI.Service;

    namespace UserDiaryUI.Commands
    {
        public class EditDiaryCommand : CommandBase
        {
            private readonly ModalDiaryViewModel _viewModel;
            private readonly ModalNavigationStore _modalNavigationStore;
            private readonly INavigationService _navigationService;

        public EditDiaryCommand(ModalDiaryViewModel viewModel, INavigationService navigationService, ModalNavigationStore modalNavigationStore)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
            {
            dynamic res = Cache.getCache().currentUser.UpdateDiary(_viewModel._id, _viewModel.Name, _viewModel.Content);
            if ((int)res["Status"] == 200)
            {
                MessageBox.Show((string)res["Response"]);
                _modalNavigationStore.Close();
            }
            else if ((int)res["Status"] == 400)
            {
                MessageBox.Show((string)res["Response"]);
            }
            _navigationService?.Navigate();
        }
    }

}
