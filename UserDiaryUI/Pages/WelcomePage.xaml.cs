using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
using UserDiaryUI;

namespace UserDiaryUI.Pages
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
            //WelcomeImg.Source = new BitmapImage(new Uri("/Images/Character-Thinking.jpg", UriKind.Relative));
        }

        private void Navigate_To_Signin(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new Uri("LoginPage.xaml", UriKind.Relative));
        }
    }
}
