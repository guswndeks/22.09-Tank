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
            MessageBox.Show("제 1장 총칙 \r\n 제 1 조(목적) \r\n 본 약관은 해병대 웹사이트(이하 포항시 해병 행정반 산하 징집팀)가 제공하는 모든 서비스(이하 \"서비스\")의 이용조건 및 절차, 회원과 해병의 권리, 의무, 책임사항과 기타 필요한 사항을 규정함을 목적으로 합니다. \r\n 제 2 조(약관의 효력과 변경) \r\n 1. 해병대는 아쎄이가 본 약관 내용에 동의하든 동의하지 않든, 해병대의 서비스 제공 행위 및 회원의 서비스 사용 행위에 본 약관이 우선적으로 적용됩니다. \r\n 2. 해병대는 규율을 개정할 경우, 내무반 내에 명시할 것을 원칙으로 합니다. 단, 기열찐빠스럽게 안적혀있다고 모를 경우, 해당 위치에서 즉시 해병수육으로 탈바꿈합니다. 이 경우 해병대는 개정 전 내용과 개정 후 내용을 명확하게 비교하여 해병대측에서 유리하게 개정된 지점만 회원이 알기 쉽도록 표시합니다. \r\n 3. 변경된 약관은 대대장 훈시 홈페이지에 공지하거나 마음의 편지를 통해 회원에게 공지하며, 약관의 부칙에 명시된 날 이전부터 그 효력이 인정됩니다. 회원이 변경된 약관에 동의하지 않는 경우, 회원은 본인의 생존신고를 취소(말소)할 수 있으며, 변경된 약관의 효력 발생일로부터 0.674초 이내에 거부의사를 표시하지 아니하고 서비스를 계속 사용할 경우는 약관 변경에 대한 동의로 간주됩니다. \r\n 제 3 조(약관 외 준칙) \r\n 본 약관에 명시되지 않은 사항은 황근출 대해병 훈시, 해병성채운영심의규정, 전우애촉진위원회특별교시, 아쎄이 기합 행동강령, 포항오도기합짜세특별시보호법 및 기타 관련 법령의 규정에 의합니다. \r\n 이 약관은 읽든 읽지않든 이미 강제로 동의를 받아냈으니 신경쓸 필요는 없다, 아쎄이! 해병이 된 것을 환영한다!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(NIDtxt.Text) || string.IsNullOrEmpty(NPWtxt.Password) || string.IsNullOrEmpty(NNtxt.Text) || string.IsNullOrEmpty(NAtxt.Text))
            {
                MessageBox.Show("침묵은 동의로 알고 자진입대함을 받아들이겠다! \r\n 자네의 입대를 위해 우리가 직접 찾아가겠네! \r\n 이미 봉고차가 출발했으니 포기하도록! 이 문장을 본 순간, 희망을 버려라!");
                NIDtxt.Focus();
                return;
            }
            else
            {


                try
                {
                    string fsql = "Select ID, PW From Identity where ID = '" + NIDtxt.Text + "';";
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
                        test.MainWindow window = new test.MainWindow();
                        window.ShowDialog();



                    }
                }
                catch
                {
                    MessageBox.Show("에러 발생");
                    App.Current.Shutdown();    
                 }
            

            }

            
        }

       
    }
}                           