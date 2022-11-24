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
    public class SigninViewModel : ViewModelBase
    {
        private string _userName;
        private string _password;
        private string _name;
        private string _email;
        private string _phone;

        public string UserName
        {
            get { return _userName; }
            set
            {
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

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }


        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public ICommand SigninCommand { get; }
        public ICommand ViewLoginCommand { get; }
        public MessageViewModel ErrorMessageViewModel { get; }

        public SigninViewModel(INavigationService<LoginViewModel> navigationService)
        {
            ErrorMessageViewModel = new MessageViewModel();
            SigninCommand = new SigninCommand(navigationService, this);
            ViewLoginCommand = new NavigateCommand<LoginViewModel>(navigationService);
        }
    }
}
