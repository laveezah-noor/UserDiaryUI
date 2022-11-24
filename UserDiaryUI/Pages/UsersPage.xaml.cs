using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserDiaryUI.Pages;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Pages
{
    /// <summary>
    /// Interaction logic for DiaryPage.xaml
    /// </summary>
    public partial class UsersPage : UserControl
    {
        public UsersPage()
        {
            InitializeComponent();
            UsersViewModel viewModel = new UsersViewModel(UserDiary.Cache.getCache());
            listUsers.ItemsSource = viewModel.Users;
            this.DataContext = viewModel;
        }
        private void CreateNew_Popup(object sender, RoutedEventArgs e)
        {
            DisableMainPage();
        }
        private void DisableMainPage()
        {
            usersPage.IsEnabled = false;
            this.Background = Brushes.LightGray;
            CreateNewPopUp.IsOpen = true;
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            // Copy name from the Popup into the main page. lblName.Content = "You entered: " + txtName.Text; EnableMainPage();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            EnableMainPage();
        }
        private void EnableMainPage()
        {
            usersPage.IsEnabled = true;
            this.Background = null;
            CreateNewPopUp.IsOpen = false;
        }
    }
}
