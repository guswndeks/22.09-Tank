using Microsoft.VisualBasic;
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
            Window.GetWindow(this).Close();
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
                            if(string.IsNullOrWhiteSpace(NN.Text))
                            {
                                MessageBox.Show("이름에 공백이 포함되어있습니다. 다시 한번 입력해주세요.");
                            }
                            else
                            {
                                if(string.IsNullOrWhiteSpace(NA.Text))
                                {
                                    MessageBox.Show("나이에 띄어쓰기가 포함되어있습니다. 다시 한번 입력해주세요.");

                                }
                                else
                                {
                                    if(string.IsNullOrWhiteSpace(NPW.Text))
                                    {
                                        MessageBox.Show("비밀번호에 띄어쓰기가 포함되어있습니다. 다시 한번 입력해주세요.");
                                    }
                                    else
                                    {
                                    string usql = "Update Identity Set Name = '" + NN.Text +  "',Age =  '" + NA.Text + "',PW =  '" + NPW.Text + "'Where ID = '" + ID.Text + "';";
                                
                                   string[] arySQLResult2 = TestClass.ContainerC(usql);
                                    MessageBox.Show("해당 정보가 수정되었습니다. 다시 로그인해주십시오.");
                                    Window.GetWindow(this).Close();
                                    }
                                }
                            }
                            try
                            {
                                
                                

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
private void Button_Click(object sender, RoutedEventArgs e)
{
            NavigationService.Navigate
                 (
                 new Uri("/LoginTunnel.xaml", UriKind.Relative)
                 );
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////키입력 조절파트////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void NID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                NPW.Focus();
            }
        }

        private void NPW_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                NN.Focus();
            }
        }

        private void NN_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                NA.Focus();
            }
        }

        private void NA_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.Key == Key.Enter)
            {
                this.Edit_Click(sender, e);
            }
        }

        private void NPW_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void NN_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void NA_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int check;
            if (!int.TryParse(e.Text, out check))
            { e.Handled = true; }
        }

        private void NPW_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Space))
            {
                e.Handled = true;
            }
        }

        private void NA_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.ImeProcessed))
            {
                e.Handled = true;
            }
            if (e.Key.Equals(Key.Space))
            {
                e.Handled = true;
            }
        }

        private void NN_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Space))
            {
                e.Handled = true;
            }
        }

       
    }
}