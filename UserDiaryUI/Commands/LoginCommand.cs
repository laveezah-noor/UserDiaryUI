using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UserDiary;
using UserDiaryClient;
using UserDiaryUI.Service;
using UserDiaryUI.Stores;
using UserDiaryUI.ViewModels;
using utils;

namespace UserDiaryUI.Commands
{
    public class LoginCommand : CommandBase
    {
        readonly INavigationService _navigationService;
        readonly LoginViewModel _loginViewModel;
        //UserDiary.Cache _cache;
        
        public LoginCommand(INavigationService navigationService, LoginViewModel loginViewModel)
        {
            _navigationService = navigationService;
            _loginViewModel = loginViewModel;
        }
        public override void Execute(object? parameter)
        {
            //MessageBox.Show($" Username: {_loginViewModel.UserName}\n Password:{_loginViewModel.Password}");

            Client.instance.ConnectToServer((int)ClientPackets.login);
            Dictionary<string, object> res = Client.instance.tcp.Result();

            //dynamic res = Cache.getCache().UserLog(_loginViewModel.UserName, _loginViewModel.Password);
            //dynamic res = _cache.UserLog("admin", "admin");
            if ((Int32)res["Status"] == 200)
            {
                MessageBox.Show(res["Response"].ToString());
                User currentUser = (User)res["Response"];
                //Cache.getCache().currentUser = (User)res["Response"];
                //_navigationService.Navigate();
            Client.instance.Disconnect();

            } else MessageBox.Show($" Response Status: {res["Status"]}\n Response: {res["Response"]}");
            Client.instance.Disconnect();
            //MessageBox.Show("Wrong Input");
        }
    }
}
