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

namespace UserDiaryUI.Pages
{
    enum Pages
    {
        HomePage,
        DiaryPage,
        UsersPage,
        UsersDiaryPage,
        AdminsPage,
        ProfilePage
    }
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : UserControl
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void Navigate_to_Page(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Tag.ToString() == Pages.HomePage.ToString())
            {
                SubWindow.Source = new Uri("./HomePage.xaml", UriKind.Relative);
            }
            else if (((Button)sender).Tag.ToString() == Pages.DiaryPage.ToString())
            {
                SubWindow.Source = new Uri("./DiaryPage.xaml", UriKind.Relative);
            }
            else if (((Button)sender).Tag.ToString() == Pages.UsersPage.ToString())
            {
                SubWindow.Source = new Uri("./UsersPage.xaml", UriKind.Relative);
            }
            else if (((Button)sender).Tag.ToString() == Pages.UsersDiaryPage.ToString())
            {
                SubWindow.Source = new Uri("./DiaryPage.xaml", UriKind.Relative);
            }
            else if (((Button)sender).Tag.ToString() == Pages.AdminsPage.ToString())
            {
                SubWindow.Source = new Uri("./UsersPage.xaml", UriKind.Relative);
            }
            else if (((Button)sender).Tag.ToString() == Pages.ProfilePage.ToString())
            {
                SubWindow.Source = new Uri("./ProfilePage.xaml", UriKind.Relative);
            }
        }
            private void LogoutPopUp(object sender, MouseButtonEventArgs e)
        {
            DisableMainPage();
        }
        private void DisableMainPage()
        {
            MainPage.IsEnabled = false; 
            this.Background = Brushes.LightGray; 
            logoutPopUp.IsOpen = true;
        }
        
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            EnableMainPage();
        }
        
        private void EnableMainPage()
        {
            MainPage.IsEnabled = true; 
            this.Background = null; 
            logoutPopUp.IsOpen = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
