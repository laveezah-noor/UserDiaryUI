using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserDiaryUI.Commands;
using UserDiaryUI.Service;

namespace UserDiaryUI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _userName;
        private string _password;

        public string UserName
        {
            get { return _userName; }
            set {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand ViewSigninCommand { get; }

        public LoginViewModel(INavigationService signinNavigationService, INavigationService landingNavigationService)
        {
            LoginCommand = new LoginCommand(landingNavigationService, this);
            ViewSigninCommand = new NavigateCommand(signinNavigationService);
        }
    }

}
