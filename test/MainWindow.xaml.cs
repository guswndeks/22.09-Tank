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
using Tibero.DbAccess;
using System.Data.OleDb;
using System.Xml.Linq;
using System.Transactions;
using System.Security.Cryptography.X509Certificates;
using System.Security.RightsManagement;
using System.Printing.IndexedProperties;

namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
       
        public MainWindow()
        {
            InitializeComponent();
            
            Fr.Content = new Main();
           
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {

            Window.GetWindow(this).Close();

        }

        

        

        

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            string srtID = TestClass.GetUserInfo()[0];
           if(string.IsNullOrEmpty(srtID))
            {
                
            }
           else
            {
                Back.IsEnabled = true;
                Fr.Content = new CrossRoads();
            }


        }
    }
}
