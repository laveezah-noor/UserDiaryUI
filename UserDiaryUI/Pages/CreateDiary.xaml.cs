using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserDiaryUI.ViewModels;

namespace UserDiaryUI.Pages
{
    /// <summary>
    /// Interaction logic for CreateDiary.xaml
    /// </summary>
    public partial class CreateDiary : UserControl
    {
        public CreateDiary()
        {
            InitializeComponent();
            //DataContext = new CreateDiaryViewModel();
        }

        //private void Cancel_Click(object sender, RoutedEventArgs e)
        //{
        //    Close();
        //}

    }
}
