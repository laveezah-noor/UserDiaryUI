using System.Windows;
using System.Windows.Input;
using UserDiary;
using UserDiaryUI.Commands;
using UserDiaryUI.Service;
using UserDiaryUI.Stores;

namespace UserDiaryUI.ViewModels
{
    public class ModalUserViewModel : ViewModelBase
    {
        public int _id;
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
        public bool _authorized;

        public bool Authorized
        {
            get { return _authorized; }
            set
            {
                _authorized = value;
                OnPropertyChanged(nameof(Authorized));
            }
        }
        public bool hasUser { get; set; }

        public ICommand CreateUserCommand { get; }
        public ICommand EditUserCommand { get; }
        public ICommand CloseModalCommand { get; }
        public string Text { get; set; }

        public ModalUserViewModel(INavigationService navigationService, ModalNavigationStore navigationStore, User user)
        {
            if (user is not null)
            {
                hasUser = true;
                Text = "Edit User";
                _id = user.Id;
                Type = user?.Type.ToString();
                Name = user?.Name;
                UserName = user?.UserName;
                Password = user?.Password;
                Phone = user?.phone;
                Email = user?.email;
                Authorized = user?.Status == "pending" ? false : true;
                //MessageBox.Show($"{Type}, {Name}, {UserName}, {Password}, {Phone},{ Email}");
            }
            else
            {
                Text = "Create New User";
            }
            CreateUserCommand = new CreateUserCommand(this, navigationStore, navigationService);
            EditUserCommand = new EditUserCommand(this, navigationStore, navigationService);
            CloseModalCommand = new CloseModalCommand(navigationStore);
            
        }
    }
}
