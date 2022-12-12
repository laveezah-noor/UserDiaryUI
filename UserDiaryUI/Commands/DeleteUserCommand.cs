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
    public class DeleteUserCommand : CommandBase
    {
        private readonly User _user;
        private readonly ModalNavigationStore _navigationStore;
        private readonly INavigationService _navigationService;

        public DeleteUserCommand(User user, ModalNavigationStore navigationStore, INavigationService navigationService)
        {
            _user = user;
            _navigationStore = navigationStore;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            dynamic res;
            //MessageBox.Show(_user.Id.ToString());
            res = Cache.getCache().currentUser.DeleteUser(_user);

            //if (_viewModel.Authorized)
            //{
            //    //MessageBox.Show(String.Format("Authorize the User {0}", _viewModel._id));
            //    res = Cache.getCache().currentUser.AuthorizeUser(_viewModel._id);
            //}
            //else
            //{
            //    //MessageBox.Show(String.Format("UnAuthorize the User {0}", _viewModel._id));
            //    res = Cache.getCache().currentUser.Unauthorize(_viewModel._id);
            //}

            _navigationStore.Close();
            MessageBox.Show((string)res["Response"]);
            _navigationService.Navigate();
        }
    }
}
