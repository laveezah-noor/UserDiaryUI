using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UserDiary;
using UserDiaryUI.Commands;
using UserDiaryUI.Service;
using UserDiaryUI.Stores;

namespace UserDiaryUI.ViewModels
{
    public class ModalWarningViewModel : ViewModelBase
    {
        public ICommand Command { get; }
        public ICommand CancelCommand { get; }
        public string Type { get; set; }

        public ModalWarningViewModel(INavigationService navigationService, ModalNavigationStore navigationStore, string type, object data)
        {
            Type = type;
            if (Type == "Logout")
            {
                //MessageBox.Show(Type);
                Command = new LogoutCommand(navigationService, navigationStore);
            } 
            else if (Type == "Delete User")
            {
                Command = new DeleteUserCommand((User)data, navigationStore, navigationService);
            }
            else if (Type == "Delete Diary")
            {
                Command = new DeleteDiaryCommand((Diary)data, navigationStore, navigationService);
            }
            CancelCommand = new CloseModalCommand(navigationStore);
        }
    }
}
