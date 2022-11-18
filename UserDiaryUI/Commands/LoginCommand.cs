using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Commands
{
    public class LoginCommand : CommandBase
    {
        readonly LoginViewModel _loginViewModel;
        readonly UserDiary.Cache _cache;

        public LoginCommand( LoginViewModel loginViewModel, UserDiary.Cache cache)
        {
            _loginViewModel = loginViewModel;
            _cache = cache;
        }
        public override void Execute(object? parameter)
        {
            _cache.UserLog(_loginViewModel.UserName, _loginViewModel.UserName);
        }
    }
}
