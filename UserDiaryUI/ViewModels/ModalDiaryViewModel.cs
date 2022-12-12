
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserDiary;
using UserDiaryUI.Commands;
using UserDiaryUI.Service;
using UserDiaryUI.Stores;

namespace UserDiaryUI.ViewModels
{
        public class ModalDiaryViewModel : ViewModelBase
        {
            public int _id;
            private string _name;
            public string _content;
            private string _createdAt;
            private string _lastModified;
            //private string _userName;
            //private string _password;
            //private string _email;
            //private string _phone;


            //public string Password
            //{
            //    get { return _password; }
            //    set
            //    {
            //        _password = value;
            //        OnPropertyChanged(nameof(Password));
            //    }
            //}

            //public string Email
            //{
            //    get { return _email; }
            //    set
            //    {
            //        _email = value;
            //        OnPropertyChanged(nameof(Email));
            //    }
            //}

            //public string Phone
            //{
            //    get { return _phone; }
            //    set
            //    {
            //        _phone = value;
            //        OnPropertyChanged(nameof(Phone));
            //    }
            //}


            public string CreatedAt
            {
                get { return _createdAt; }
                set
                {
                    _createdAt = value;
                    OnPropertyChanged(nameof(Type));
                }
            }

            public string LastModified
            {
                get { return _lastModified; }
                set
                {
                    _lastModified = value;
                    OnPropertyChanged(nameof(LastModified));
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


            public string Content
            {
                get { return _content; }
                set
                {
                    _content = value;
                    OnPropertyChanged(nameof(Content));
                }
            }
            public bool hasDiary { get; set; }

            public ICommand CreateDiaryCommand { get; }
            public ICommand EditDiaryCommand { get; }
            public ICommand CloseModalCommand { get; }
            public string Text { get; set; }

            public ModalDiaryViewModel(INavigationService navigationService, ModalNavigationStore modalNavigationStore, Diary diary)
            {
                if (diary is not null)
                {
                    hasDiary = true;
                    Text = "Edit Diary";
                    _id = diary.Id;
                    Name = diary?.Name;
                    Content = diary?.Content;
                    CreatedAt = diary?.CreatedAt.ToString();
                    LastModified = diary?.LastUpdate.ToString();

            }
            else
                {
                    Text = "Create New Diary";
                }
                CreateDiaryCommand = new CreateDiaryCommand(this, navigationService, modalNavigationStore);
                EditDiaryCommand = new EditDiaryCommand(this, navigationService, modalNavigationStore);
                CloseModalCommand = new CloseModalCommand(modalNavigationStore);

            }
        }

}
