using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UserDiary;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Commands
{
    public class CreateUserCommand : CommandBase
    {
        private readonly ModalUserViewModel _createViewModel;

        public CreateUserCommand(ModalUserViewModel viewModel)
        {
            _createViewModel = viewModel;
            //this._cache = Cache.getCache();
        }

        public override void Execute(object? parameter)
        {
            if (UserDiary.Utility.ValidateUsername(_createViewModel.UserName))
            {
                MessageBox.Show(string.Format(" Name:{2}\n Username: {0}\n Password: {1}\n Phone: {3}\n Email:{4}"
                    , this._createViewModel.UserName, this._createViewModel.Password, this._createViewModel.Name, this._createViewModel.Phone,
                this._createViewModel.Email));
                Cache.getCache().currentUser.CreateUser(_createViewModel.Type, _createViewModel.Name, _createViewModel.UserName, _createViewModel.Password);
                //if ((int)res["Status"] == 200)
                //{
                //    MessageBox.Show((string)res["Response"]);
                //}

            }
            else MessageBox.Show("Username already exists!");
        }
    }
}
