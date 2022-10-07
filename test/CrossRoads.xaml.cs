using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing.IndexedProperties;
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
    /// CrossRoads.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CrossRoads : Page
    {
        public CrossRoads()
        {
            InitializeComponent();
            
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Fr.Content = new Userpage();
        }

        private void Resign_Click(object sender, RoutedEventArgs e)
        {
            Fr.Content = new Resignpage();
        }


        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////// 키 입력 버튼 칸 ///////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
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

        

        
    }
}
