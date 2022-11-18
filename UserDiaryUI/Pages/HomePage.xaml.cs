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

namespace UserDiaryUI.Views
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            //DataContext = this;
        }
 
        private void CreateNew_Popup(object sender, RoutedEventArgs e)
        {
            CreateDiary createDiary = new CreateDiary();
            createDiary.Show();
            //DisableMainPage();
        }
        private void DisableMainPage()
        {
            homePage.IsEnabled = false;
            this.Background = Brushes.LightGray;
            CreateNewPopUp.IsOpen = true;
            
        }

        public void Cancel_Click(object sender, RoutedEventArgs e) => EnableMainPage();

        private void EnableMainPage()
        {
            homePage.IsEnabled = true;
            homePage.Background = null;
            homePage.CreateNewPopUp.IsOpen = false;
        }
    }
}
