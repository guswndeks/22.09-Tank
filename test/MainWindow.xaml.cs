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
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(IDtxt.Text))
            {
                MessageBox.Show("아이디를 입력해주십시오.");
                IDtxt.Focus();
                return;
            }
            if (string.IsNullOrEmpty(PWtxt.Password))
            {
                MessageBox.Show("비밀번호를 입력해주십시오");
                PWtxt.Focus();
                return;
            }
            //--------------------------------------------------------------------------------------------------------------------------------------
            
            try
            {
                string sql = "Select ID, PW, Name, Age From Identity where ID = '" + IDtxt.Text + "';";
                TestClass testClass = new TestClass();




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
                        
                    }
                    else
                    {
                        if (PWtxt.Password.Equals(result2))
                        {

                            
                            test.LogInTunnel window4 = new test.LogInTunnel();
                            window4.ShowDialog();


                        }
                        else
                        {
                            MessageBox.Show("비밀번호를 다시 입력해주십시오.");
                        }

                    }


                }
                else
                {
                   MessageBox.Show("아이디를 다시 입력해주십시오.");
                }
                
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              
                
             
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            test.Window1 window1 = new test.Window1();
            window1.ShowDialog();
        }
    }
}
