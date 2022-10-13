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
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(IDtxt.Text))
            {
                MessageBox.Show("아이디를 입력해주십시오.");
                IDtxt.Focus();
                return;
            }
            if (!IDtxt.Text.IndexOf(" ").Equals(-1))
            {
                MessageBox.Show("아이디에 띄어쓰기가 포함되어있습니다. 다시 입력해주세요.");
                IDtxt.Focus();
                return;
            }

            if (string.IsNullOrEmpty(PWtxt.Password))
            {
                MessageBox.Show("비밀번호를 입력해주십시오");
                PWtxt.Focus();
                return;
            }
            if (!PWtxt.Password.IndexOf(" ").Equals(-1))
            {
                MessageBox.Show("비밀번호에 띄어쓰기가 포함되어있습니다. 다시 입력해주세요.");
                PWtxt.Focus();
                return;
            }


            //--------------------------------------------------------------------------------------------------------------------------------------

            try
            {
                string sql = "Select ID, PW, Name, Age From Identity where ID = '" + IDtxt.Text + "';";


                //--------------------------------아이디, 패스워드 가져오기----------------------------------------

                //------------------------비밀번호 가져오기--------------------------------------
                //Tibero.DbAccess.OleDbCommandTbr cmd2 = new OleDbCommandTbr();

                //cmd2.CommandText = "Select PW From Identity where ID = cmd1;";

                //cmd2.Connection = conn;

                //OleDbDataReader reader2 = cmd2.ExecuteReader();



                string[] arySQLResult = TestClass.ContainerC(sql);


                if (arySQLResult.Length > 0)
                {

                    string result1 = arySQLResult[0].ToString();
                    string result2 = arySQLResult[1].ToString();
                    string result3 = arySQLResult[2].ToString();
                    string result4 = arySQLResult[3].ToString();


                    if (string.IsNullOrEmpty(result1))
                    {
                        MessageBox.Show("아이디를 다시 입력해주십시오.");
                        IDtxt.Clear();
                        IDtxt.Focus();

                        return;
                    }
                    else
                    {
                        if (PWtxt.Password.Equals(result2))
                        {
                            Fr.Content = new CrossRoads();
                        }
                        else
                        {
                            MessageBox.Show("비밀번호를 다시 입력해주십시오.");
                            PWtxt.Clear();
                            PWtxt.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("아이디를 다시 입력해주십시오.");
                    IDtxt.Clear();
                    IDtxt.Focus();
                    return;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            test.WindowSignUp windowSU = new test.WindowSignUp();
            windowSU.ShowDialog();
        }

        private void IDtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PWtxt.Focus();
            }
        }

        private void PWtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                this.Button_Click(sender, e);
        }
    }
    
}
