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
using System.Windows.Shapes;

namespace test
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        public Window1(string userID)
        {
            
            
            InitializeComponent();
        }

        private void C2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("아쎄이는 지금부터 오프라인 입대 대상이다!");
            MessageBox.Show("너무 걱정말도록! 우리가 직접 데리러 갈테니!");
            MessageBox.Show("이 문구를 본 순간, 희망을 버려라!");
            Application.Current.Shutdown();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            test.WindowSignUp window2 = new test.WindowSignUp();
            window2.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            test.WindowSignUp window2 = new test.WindowSignUp();
            window2.ShowDialog();
        }
    }
}
