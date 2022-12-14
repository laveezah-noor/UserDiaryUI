using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using UserDiary;
using UserDiaryUI.Service;
using UserDiaryUI.ViewModels;
using UserDiaryUI.Scripts;
using utils;

namespace UserDiaryUI.Commands
{
    internal class SigninCommand : CommandBase
    {
        private INavigationService _navigationService;
        private readonly SigninViewModel _signinViewModel;
        private UserDiary.Cache _cache;
        
        public SigninCommand(INavigationService navigationService, SigninViewModel signinViewModel)
        {
            this._navigationService = navigationService;
            this._signinViewModel = signinViewModel;
            //this._cache = Cache.getCache();
        }

        public override void Execute(object? parameter)
        {
            //dynamic res;
            if (!string.IsNullOrEmpty(_signinViewModel.Email)?
               Utility.ValidateEmail(_signinViewModel.Email) : true
               &&
               !string.IsNullOrEmpty(_signinViewModel.Phone) ?
               Utility.ValidatePhone(_signinViewModel.Phone) : true )
            {
                MessageBox.Show(string.Format(" Name:{2}\n Username: {0}\n Password: {1}\n Phone: {3}\n Email:{4}"
                , this._signinViewModel.UserName, this._signinViewModel.Password, this._signinViewModel.Name, this._signinViewModel.Phone,
                this._signinViewModel.Email));

                Dictionary<string, string> request = new Dictionary<string, string>()
            {
                {"username", _signinViewModel.UserName },
                {"password", _signinViewModel.Password },

            };
                Client.instance.ConnectToServer((int)ClientPackets.register, request);
                Dictionary<string, object> res = Client.instance.tcp.Result();


                //res = _cache.Register(_signinViewModel.Name, _signinViewModel.UserName, _signinViewModel.Password, _signinViewModel.Email, _signinViewModel.Phone);
                if ((int)res["Status"] == 200)
                {
                    _navigationService.Navigate();
                } 
                MessageBox.Show((string)res["Response"]);
            }
            else
            {
                MessageBox.Show("Email or Phone Format Incorrect!");
            }
            Client.instance.Disconnect();
            //else MessageBox.Show("Username already exists!");
            //dynamic res = _cache.UserLog("admin", "admin");
            //MessageBox.Show($" Response Status: {res["Status"]}\n Response: {res["Response"]}");
            //if ((int)res["Status"] == 200)
            //{

            //}
            //Convert.ToString((int)res["Status"])
        }
    }
}