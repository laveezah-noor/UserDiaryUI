using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using UserDiary;
using UserDiaryUI.Service;
using UserDiaryUI.Stores;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Commands
{
    public class CreateUserCommand : CommandBase
    {
        private readonly ModalUserViewModel _viewModel;
        private readonly ModalNavigationStore _navigationStore;
        private readonly INavigationService _navigationService;

        public CreateUserCommand(ModalUserViewModel viewModel, ModalNavigationStore navigationStore, INavigationService navigationService)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            if (!string.IsNullOrEmpty(_viewModel.Name) 
                && !string.IsNullOrEmpty(_viewModel.UserName) 
                && !string.IsNullOrEmpty(_viewModel.Password)
                && !string.IsNullOrEmpty(_viewModel.Type))
            {

                if (Utility.ValidateUsername(_viewModel.UserName))
                {
                    MessageBox.Show(string.Format(" Type:{3}\n Name:{2}\n Username: {0}\n Password: {1}"
                        , this._viewModel.UserName, this._viewModel.Password, this._viewModel.Name, this._viewModel.Type));
                    //MessageBox.Show(_viewModel.Type.ToLower());
                    if (_viewModel.Type.ToLower() == Types.user.ToString())
                    {
                        Cache.getCache().currentUser.CreateUser(Types.user.ToString(), _viewModel.Name, _viewModel.UserName, _viewModel.Password);

                    }
                    else if (_viewModel.Type.ToLower() == Types.admin.ToString())
                    {
                        Cache.getCache().currentUser.CreateUser(Types.admin.ToString(), _viewModel.Name, _viewModel.UserName, _viewModel.Password);

                    }

                    _navigationStore.Close();
                    //if ((int)res["Status"] == 200)
                    //{
                    //MessageBox.Show((string)res["Response"]);
                    //}

                }
                else MessageBox.Show("Username already exists!"); 
            }
            else MessageBox.Show("Please fill the required fields!");

            _navigationService.Navigate();
        }
    }
}
