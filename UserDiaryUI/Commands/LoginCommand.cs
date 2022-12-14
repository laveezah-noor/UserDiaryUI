using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UserDiary;
using UserDiaryUI.Scripts;
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
            Dictionary<string,string> request = new Dictionary<string, string>()
            {
                {"username", _loginViewModel.UserName },
                {"password", _loginViewModel.Password },

            };
            //dynamic res = Cache.getCache().UserLog(_loginViewModel.UserName, _loginViewModel.Password);
            //dynamic res = Cache.getCache().UserLog("admin", "admin");
            Client.instance.ConnectToServer((int)ClientPackets.login, request);
            Dictionary<string, object> res = Client.instance.tcp.Result();
            if (Convert.ToInt32(res["Status"]) == 200)
            {
                //MessageBox.Show($"{res["Response"]}, {res["RequestId"]}");
                User currentUser = (User) res["Response"];
                CacheStore.GetCache().CurrentUser = currentUser ;
                _navigationService.Navigate();
                //Client.instance.Disconnect();

            }
            else MessageBox.Show($" Response Status: {res["Status"]}\n Response: {res["Response"]}");
            //Client.instance.Disconnect();
            //}
            //MessageBox.Show("Wrong Input");
        }
    }
}
