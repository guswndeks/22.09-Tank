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
            string srtID = TestClass.GetUserInfo()[0];
            ID.Text = srtID;
            
        }
        private void Resign_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("정말로 탈퇴하시겠습니까? \r\n 탈퇴시 계정의 정보는 모두 삭제되며, 이후 복원이 불가능합니다. \r\n 그래도 하시겠습니까?.", "계정 탈퇴", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (mbr == MessageBoxResult.Yes)
            {
                if (string.IsNullOrEmpty(PW.Text))
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
                        string[] arySQLResult = TestClass.ContainerC(sql);

                        if (arySQLResult.Length > 0)
                        {
                            
                            string result1 = arySQLResult[0].ToString();
                            

                            if (arySQLResult.Length > 0)
                            {
                                string result2 = arySQLResult[1].ToString();
                                if (PW.Text == result2)
                                {
                                    try
                                    {
                                        string dsql = "Delete From Identity where ID = '" + ID.Text + "'and PW = '" + PW.Text + "';";

                                        string[] arySQLResult2 = TestClass.ContainerC(dsql);
                                        MessageBox.Show("계정이 삭제되었습니다. 그동안 이용해주셔서 감사합니다.");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("문제가 발생했으므로 셧다운합니다. \n\r 다시 작동시켜주세요. \n\r" + ex.Message);
                                    }
                                    finally
                                    {
                                        App.Current.Shutdown();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("비밀번호를 찾을 수 없습니다. 다시 입력해주세요");
                                    PW.Clear();
                                    PW.Focus();
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("비밀번호를 찾을 수 없습니다. 다시 입력해주세요");
                                PW.Clear();
                                PW.Focus();
                              
                            }
                        }                        
                        else
                        {
                            MessageBox.Show("아이디를 찾을 수 없습니다. 다시 입력해주세요");
                            ID.Clear();
                            ID.Focus();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("계정 조회 실패, 다시 입력해주세요.");
                        ID.Clear();
                        PW.Clear();
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
        
        ////////////////////////////////////////////////////////////////////////키입력 조절파트////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                PW.Focus();
            }
        }

        private void PW_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                this.Resign_Click(sender, e);
            }
        }

        

        private void PW_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Space))
            {
                e.Handled = true;
            }
        }

    private void PW_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void ID_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Space))
            {
                e.Handled = true;
            }
        }

        

        
    }
}
