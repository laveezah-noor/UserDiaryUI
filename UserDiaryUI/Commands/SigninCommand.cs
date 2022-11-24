using System;
using System.Windows;
using System.Windows.Input;
using UserDiary;
using UserDiaryUI.Service;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Commands
{
    internal class SigninCommand : CommandBase
    {
        private INavigationService<LoginViewModel> _navigationService;
        private readonly SigninViewModel _signinViewModel;
        private UserDiary.Cache _cache;
        
        public SigninCommand(INavigationService<LoginViewModel> navigationService, SigninViewModel signinViewModel)
        {
            this._navigationService = navigationService;
            this._signinViewModel = signinViewModel;
            this._cache = Cache.getCache();
        }

        public override void Execute(object? parameter)
        {
            if (UserDiary.Utility.ValidateUsername(_signinViewModel.UserName))
            {
            MessageBox.Show(string.Format(" Name:{2}\n Username: {0}\n Password: {1}\n Phone: {3}\n Email:{4}"
                , this._signinViewModel.UserName, this._signinViewModel.Password, this._signinViewModel.Name, this._signinViewModel.Phone,
                this._signinViewModel.Email));
                dynamic res = _cache.Register(_signinViewModel.Name, _signinViewModel.UserName, _signinViewModel.Password, _signinViewModel.Email, _signinViewModel.Phone);
                if ((int)res["Status"] == 200) _navigationService.Navigate();

            }
            else MessageBox.Show("Username already exists!");
            //dynamic res = _cache.UserLog("admin", "admin");
            //MessageBox.Show($" Response Status: {res["Status"]}\n Response: {res["Response"]}");
            //if ((int)res["Status"] == 200)
            //{

            //}
            //Convert.ToString((int)res["Status"])
        }
    }
}