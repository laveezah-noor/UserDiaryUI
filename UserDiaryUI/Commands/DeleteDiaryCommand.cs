using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UserDiary;
using UserDiaryUI.Service;
using UserDiaryUI.Stores;

namespace UserDiaryUI.Commands
{
    public class DeleteDiaryCommand : CommandBase
    {
        private readonly Diary _diary;
        private readonly ModalNavigationStore _navigationStore;
        private readonly INavigationService _navigationService;

        public DeleteDiaryCommand(Diary diary, ModalNavigationStore navigationStore, INavigationService navigationService)
        {
            _diary = diary;
            _navigationStore = navigationStore;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            dynamic res;
            //MessageBox.Show(_diary.Id.ToString());
            res = Cache.getCache().currentUser.DeleteDiary(_diary.Id);
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


            if ((int)res["Status"] == 200) {

                CacheStore.GetCache().CurrentUser = Cache.getCache().currentUser;
            _navigationStore.Close();
            }
            else if ((int)res["Status"] == 400)
            {
                MessageBox.Show((string)res["Response"]);
            }
            _navigationService.Navigate();
        }
    }
}
