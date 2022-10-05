using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    /// WindowSignUp.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WindowSignUp : Window
    {
        public WindowSignUp()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("제 1장 총칙 \r\n 제 1 조(목적) \r\n 본 약관은 로그인 웹사이트가 제공하는 모든 서비스(이하 \"서비스\")의 이용조건 및 절차, 회원의 권리, 의무, 책임사항과 기타 필요한 사항을 규정함을 목적으로 합니다. \r\n 제 2 조(약관의 효력과 변경) \r\n 1. 로그인 창의 서비스 제공 행위 및 회원의 서비스 사용 행위에 본 약관이 우선적으로 적용됩니다. \r\n 2. 로그인 관련 정보는 해당 홈페이지에 명시합니다. \r\n 3. 변경된 약관은 해당 홈페이지에 공지하거나 기입된 연락처를 통해 회원에게 공지하며, 약관의 부칙에 명시된 날 직후부터 그 효력이 인정됩니다. 회원이 변경된 약관에 동의하지 않는 경우, 회원은 해당 서비스에 대해 약관을 해지할 수 있으며, 변경된 약관의 효력 발생일로부터 즉시 실효하며 서비스를 계속 사용할 경우는 약관 변경에 대한 동의로 간주됩니다. \r\n 제 3 조(약관 외 준칙) \r\n 본 약관에 명시되지 않은 사항은 홈페이지 하단에 기술된 해당 법규 및 기타 관련 법령의 규정에 의합니다.");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(NIDtxt.Text) || string.IsNullOrEmpty(NPWtxt.Password) || string.IsNullOrEmpty(NNtxt.Text) || string.IsNullOrEmpty(NAtxt.Text))
            {
                MessageBox.Show("입력하지 않은 정보가 있습니다. \n\r 빈칸이 있는지 다시 확인해주십시오.");
                NIDtxt.Focus();
                return;
            }
            else
            {


                try
                {
                    string fsql = "Select ID, PW, NAME, AGE From Identity where ID = '" + NIDtxt.Text + "';";
                    TestClass testClass = new TestClass();
                    string[] arySQLResult = TestClass.ContainerC(fsql);

                    if (arySQLResult.Length > 0)
                    {
                        string result1 = arySQLResult[0].ToString();
                        string result2 = arySQLResult[1].ToString();



                        MessageBox.Show("중복된 ID입니다. 변경 후 재입력 바랍니다.");
                        NIDtxt.Focus();
                        return;


                    }


                    else
                    {
                        string sql = "Insert Into Identity(ID, PW, Name, Age) Values('" + NIDtxt.Text + "','" + NPWtxt.Password + "','" + NNtxt.Text + "','" + NAtxt.Text + "');";

                        TestClass testClass2 = new TestClass();
                        string[] arySQLResult2 = TestClass.ContainerC(sql);
                        MessageBox.Show("회원가입 성공");
                        MessageBox.Show("해당 계정으로 접속해주세요");
                        Window.GetWindow(this).Close();
                       
                        



                    }
                }
                catch
                {
                    MessageBox.Show("에러 발생");
                       
                 }
            

            }

            
        }

        ////////////////////////////////////////////////////////////////////////키입력 조절파트////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void NIDtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                NPWtxt.Focus();
            }
        }

        private void NPWtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                NNtxt.Focus();
            }
        }

        private void NNtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                NAtxt.Focus();
            }
        }

        private void NAtxt_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.Key == Key.Enter)
            {
                this.Button_Click_1(sender, e);
            }
        }

        private void NIDtxt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.ImeProcessed))
            {
                e.Handled = true;
            }
        }

        private void NPWtxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int check;
            if (!int.TryParse(e.Text, out check))
            { e.Handled = true; }
        }

        private void NAtxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int check;
            if (!int.TryParse(e.Text, out check))
            { e.Handled = true; }
        }

        private void NPWtxt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.ImeProcessed))
            {
                e.Handled = true;
            }
        }

        private void NAtxt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.ImeProcessed))
            {
                e.Handled = true;
            }
        }
    }
}                           