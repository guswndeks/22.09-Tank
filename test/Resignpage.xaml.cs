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
    /// Resignpage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Resignpage : Page
    {
        public Resignpage()
        {
            InitializeComponent();
        }
        private void Resign_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("정말로 탈퇴하시겠습니까? \r\n 탈퇴시 계정의 정보는 모두 삭제되며, 이후 복원이 불가능합니다. \r\n 그래도 하시겠습니까?.", "계정 탈퇴", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (mbr == MessageBoxResult.Yes)
            {
                if (string.IsNullOrEmpty(ID.Text) || string.IsNullOrEmpty(PW.Text))
                {
                    MessageBox.Show("정보를 모두 입력하시기 바랍니다");
                    ID.Focus();
                    return;
                }
                else
                {
                    try
                    {
                        string sql = "Select ID, PW From Identity where ID = '" + ID.Text + "'and PW = '" + PW.Text + "';";
                        TestClass testClass = new TestClass();
                        string[] arySQLResult = TestClass.ContainerC(sql);

                        if (arySQLResult.Length > 0)
                        {

                            string result1 = arySQLResult[0].ToString();
                            string result2 = arySQLResult[1].ToString();

                            if (string.IsNullOrEmpty(result1))
                            {
                                MessageBox.Show("ID를 다시 입력해주십시오.");
                            }
                            else
                            {
                                try
                                {
                                    string dsql = "Delete From Identity where ID = '" + ID.Text + "'and PW = '" + PW.Text + "';";

                                    string[] arySQLResult2 = TestClass.ContainerC(dsql);
                                    MessageBox.Show("계정이 삭제되었습니다. 그동안 이용해주셔서 감사합니다.");
                                    App.Current.Shutdown();
                                }
                                catch
                                {
                                    MessageBox.Show("문제가 발생했으므로 셧다운합니다. \n\r 다시 작동시켜주세요.");
                                    App.Current.Shutdown();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("아이디를 다시 입력해주십시오.");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("계정 조회 실패, 다시 입력해주세요.");
                        ID.Focus();
                        return;
                    }
                }
            }
            else if(mbr == MessageBoxResult.No)
            {
                MessageBox.Show("다시 화면으로 돌아갑니다.");
                ID.Focus();
                return;
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
