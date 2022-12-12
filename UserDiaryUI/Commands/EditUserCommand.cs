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
    public class EditUserCommand : CommandBase
    {
        private readonly ModalUserViewModel _viewModel;
        private readonly ModalNavigationStore _navigationStore;
        private readonly INavigationService _navigationService;

        public EditUserCommand(ModalUserViewModel viewModel, ModalNavigationStore navigationStore, INavigationService navigationService)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            //MessageBox.Show(string.Format(" Name:{2}\n Username: {0}\n Password: {1}\n Phone: {3}\n Email:{4}"
            //        , this._viewModel.UserName, this._viewModel.Password, this._viewModel.Name, this._viewModel.Phone,
            //    this._viewModel.Email));
            dynamic res;
            if (_viewModel.Authorized)
            {
                //MessageBox.Show(String.Format("Authorize the User {0}", _viewModel._id));
                res = Cache.getCache().currentUser.AuthorizeUser(_viewModel._id);
            }
            else
            {
                //MessageBox.Show(String.Format("UnAuthorize the User {0}", _viewModel._id));
                res = Cache.getCache().currentUser.Unauthorize(_viewModel._id);
            }


            if ((int)res["Status"] == 200) _navigationStore.Close();
            else if ((int)res["Status"] == 400)
            {
                MessageBox.Show((string)res["Response"]);
            }
            _navigationService.Navigate();
        }
    }
}
