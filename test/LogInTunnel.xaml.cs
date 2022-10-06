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

namespace test
{
    /// <summary>
    /// LogInTunnel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LogInTunnel : Window
    {
        public LogInTunnel()
        {
            InitializeComponent();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            test.Userpage User = new test.Userpage();
            User.Title = "User";
            this.Content = User;
            
        }
        

        private void Resign_Click(object sender, RoutedEventArgs e)
        {
            test.Resignpage Resign = new test.Resignpage();
            Resign.Title = "Resign";
            this.Content = Resign;
        }

        ////////////////////////////////////////////////////////////////////////키입력 조절파트////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                this.Edit_Click(sender, e);
                
            }
        }

        private void Button_KeyDown_1(object sender, KeyEventArgs e)
        {                
                if (e.Key == Key.Enter)
                {
                    this.Resign_Click(sender, e);
                }
            }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
    }

