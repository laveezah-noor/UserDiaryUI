using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserDiary;
using UserDiaryUI.Commands;

namespace UserDiaryUI.ViewModels
{
    public class ModalUserViewModel : ViewModelBase
    {
        private string _type;
        private string _userName;
        private string _password;
        private string _name;
        private string _email;
        private string _phone;


        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

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

        public ICommand CreateUserCommand { get; }

        public ModalUserViewModel(User user, bool type)
        {
            _type = user.Type.ToString();
            _name = user.Name;
            _userName = user.UserName;
            _password = user.Password;
            _phone = user.phone;
            _email = user.email;
            CreateUserCommand = new CreateUserCommand(this);
        }
    }
}
