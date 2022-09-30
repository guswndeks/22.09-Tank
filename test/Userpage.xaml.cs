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
            Loaded += Userpage_Loaded;
        }

        private void Userpage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] strarryresult = TestClass.GetUserInfo();

                ID.Text = strarryresult[0];
                PW.Text = strarryresult[1];
                N.Text = strarryresult[2];
                A.Text = strarryresult[3];
                NID.Text = strarryresult[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    string sql = "Select ID, PW, NAME, AGE From Identity where ID = '" + ID.Text + "';";
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
                                string usql = "Update Identity Set Name = '" + NN.Text +  "',Age =  '" + NA.Text + "',PW =  '" + NPW.Text + "'Where ID = '" + ID.Text + "';";
                                
                                string[] arySQLResult2 = TestClass.ContainerC(usql);
                                MessageBox.Show("해당 정보가 수정되었습니다. 다시 로그인해주십시오.");
                                Window.GetWindow(this).Close();
                                test.Window1 window1 = new test.Window1();
                                window1.ShowDialog();

                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
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
        }
    }
}