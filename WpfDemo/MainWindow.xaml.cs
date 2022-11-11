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

namespace WpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //TextBlock Result;
        //TextBox Input;
        
        public MainWindow()
        {
            InitializeComponent();
            myWindow.Icon = new BitmapImage(new Uri(@"https://www.pngfind.com/pngs/m/560-5600539_png-cat-funny-icon-05-funny-cat-icon.png"));
            TextBlock Question = new TextBlock() { Text= "How old is your cat?" };
            //Question.SetValue(Grid.RowProperty, 0);
            //Question.SetValue(Grid.ColumnProperty, 0);
            //Input = new TextBox() { Height=15 };
            //Input.SetValue(Grid.RowProperty, 0);
            //Input.SetValue(Grid.ColumnProperty, 1);
            //Result = new TextBlock() { Text= "Your cat is "};
            //Result.SetValue(Grid.RowProperty, 1);
            //Result.SetValue(Grid.ColumnProperty, 0);
            //Input.KeyDown += TextBox_KeyDown;
            
            Grid mainGrid = new Grid();
            
            //Grid.SetRow(Input, 0);
            //Grid.SetRow(Question, 0);
            //Grid.SetRow(Result, 1);
            //Grid.SetColumn(Question, 0);
            //Grid.SetColumn(Input, 1);
            //Grid.SetColumn(Result, 0);
            //mainGrid.Children.Add(Input);
            //mainGrid.Children.Add(Question);
            //mainGrid.Children.Add(Result);
            //mainGrid.Children.Add(Input);
            //buttonHello.Content = "No Hello";
            //TextBlock textBlock = new TextBlock();
            //textBlock.Text = "Hello World";
            //textBlock.Inlines.Add("This is added using Inlines");
            //myWindow.Content = mainGrid;
        }

        //private void Image_GotMouseCapture(object sender, MouseEventArgs e)
        //{
        //    image.Source = new BitmapImage(new Uri(@"https://images.ctfassets.net/hrltx12pl8hq/a2hkMAaruSQ8haQZ4rBL9/8ff4a6f289b9ca3f4e6474f29793a74a/nature-image-for-website.jpg?fit=fill&w=480&h=320"));
        //}

        //private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //if (slider_val != null && slider.Value >15)
        //{
        //    slider_val.Text = slider.Value.ToString();
        //    TextBlock.FontSize = slider.Value;
        //}
        //}

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            //this.Cursor = Cursors.Wait; 
            //// Dramatic delay...
            //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3)); 
            //this.Cursor = null;
            {
                //try
                //{
                //    int InputCatAge = int.Parse(Input.Text);
                //    int HumanAge;
                //    if(InputCatAge > 0 && InputCatAge <= 1)
                //    {
                //        HumanAge = 15;
                //    Result.Text = $"Your cat is {HumanAge} years old";

                //    } else if (InputCatAge >= 2 && InputCatAge < 25)
                //    {
                //        HumanAge = (((InputCatAge - 2) * 4)+24);
                //        Result.Text = $"Your cat is {HumanAge} years old";
                //    }
                //    else
                //    {
                //        Result.Text = $"Your cat is dead or not born!";

                //    }
                //} catch (Exception myException)
                //{
                //    MessageBox.Show("Incorrect Input");
                //}

            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Hi");
        }

        //private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        //{
        //    System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        //}

        //private void buttonHello_Click(object sender, RoutedEventArgs e)
        //{
        //    //buttonHello.IsEnabled = false;
        //    label.Foreground = Brushes.SteelBlue;
        //    label.FontSize = label.FontSize + 1;
        //}

        //private void buttonHello_AccessKeyPressed(object sender, AccessKeyPressedEventArgs e)
        //{

        //}
        //void OnClick1(object sender, RoutedEventArgs e)
        //{
        //    btn1.Background = Brushes.LightBlue;
        //}

        //void OnClick2(object sender, RoutedEventArgs e)
        //{
        //    btn2.Background = Brushes.Pink;
        //}

        //void OnClick3(object sender, RoutedEventArgs e)
        //{
        //    btn1.Background = Brushes.Pink;
        //    btn2.Background = Brushes.LightBlue;
        //}

        //private void Parent_Checked(object sender, RoutedEventArgs e)
        //{
        //    Baby1.IsChecked = Parent.IsChecked;
        //    Baby2.IsChecked = Parent.IsChecked;
        //    Baby3.IsChecked = Parent.IsChecked;
        //}

        //private void Baby_Checked(object sender, RoutedEventArgs e)
        //{
        //    Parent.IsChecked = null;
        //    if (Baby1.IsChecked == true && Baby2.IsChecked == true && Baby3.IsChecked == true) 
        //        Parent.IsChecked = true;
        //    else if (Baby1.IsChecked == false && Baby2.IsChecked == false && Baby3.IsChecked == false) 
        //        Parent.IsChecked = false;
        //}
    }
}
