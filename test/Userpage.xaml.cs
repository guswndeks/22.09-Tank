using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

namespace test
{
    /// <summary>
    /// Userpage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Userpage : Page
    {
        public Userpage()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {




            if (string.IsNullOrEmpty(ID.Text) || string.IsNullOrEmpty(PW.Text) || string.IsNullOrEmpty(NN.Text) || string.IsNullOrEmpty(NA.Text))
            {
                MessageBox.Show("정보를 모두 입력하시기 바랍니다");
                ID.Focus();
                return;
            }
            else
            {
              try
                {
                    string sql = "Select ID From Identity where ID = '" + ID.Text + "';";
                    TestClass testClass = new TestClass();
                    string[] arySQLResult = TestClass.ContainerC(sql);

                    if (arySQLResult.Length > 0)
                    {

                        string result1 = arySQLResult[0].ToString();
                        
                        
                        if(string.IsNullOrEmpty(result1))
                        {
                            MessageBox.Show("ID를 다시 입력해주십시오.");
                        }
                        else
                        {
                            try
                            {
                                string usql = "Update Identity Set Name = '" + NN.Text +  "',Age =  '" + NA.Text + "'Where ID = '" + ID.Text + "';";
                                
                                string[] arySQLResult2 = TestClass.ContainerC(usql);
                                MessageBox.Show("해당 정보가 수정되었습니다. 다시 로그인해주십시오.");
                                Window.GetWindow(this).Close();
                                test.Window1 window1 = new test.Window1();
                                window1.ShowDialog();

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
                    return ;
                }
                    
                
                    
            }
        }
    }
}