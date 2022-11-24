using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UserDiaryUI.Service;
using UserDiaryUI.Stores;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Commands
{
    public class LoginCommand : CommandBase
    {
        readonly INavigationService<UsersViewModel> _navigationService;
        readonly LoginViewModel _loginViewModel;
        UserDiary.Cache _cache;
        
        public LoginCommand(INavigationService<UsersViewModel> navigationService, LoginViewModel loginViewModel)
        {
            _navigationService = navigationService;
            _cache = UserDiary.Cache.getCache();
            _loginViewModel = loginViewModel;
        }
        public override void Execute(object? parameter)
        {
            //MessageBox.Show($" Username: {_loginViewModel.UserName}\n Password:{_loginViewModel.Password}");
            dynamic res = _cache.UserLog(_loginViewModel.UserName, _loginViewModel.Password);
            //dynamic res = _cache.UserLog("admin", "admin");
            if ((int)res["Status"] == 200)
            {
                _navigationService.Navigate();

            } else MessageBox.Show($" Response Status: {res["Status"]}\n Response: {res["Response"]}");
            //MessageBox.Show("Wrong Input");
        }
    }
}
