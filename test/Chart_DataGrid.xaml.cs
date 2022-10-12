using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    /// Chart_DataGrid.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Chart_DataGrid : Window
    {
        public Chart_DataGrid()
        {
            InitializeComponent();
            btngriddata.Click += Btngriddata_Click;
           
        }

        private void Btngriddata_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string strBLK = @"SELECT *
                                    FROM HMI_COPY   
                                   WHERE 블록코드 = '000015'
                                     AND 항목 = 'FL'
                                     AND 태그아이디 = '1L-42730-501-FRI-O011'
                                     AND 시간 BETWEEN TO_DATE('20220103000000', 'YYYYMMDDHH24MISS') 
                                                     AND TO_DATE('20220103235959', 'YYYYMMDDHH24MISS');";

                //string strTID = @"SELECT 태그아이디
                //                    FROM HMI_COPY   
                //                   WHERE 블록코드 = '000015'
                //                     AND 항목 = 'FL'
                //                     AND 태그아이디 = '1L-42730-501-FRI-O011'
                //                     AND 시간 BETWEEN TO_DATE('20220103000000', 'YYYYMMDDHH24MISS') 
                //                                     AND TO_DATE('20220103235959', 'YYYYMMDDHH24MISS');";

                //string strITC= @"SELECT 항목
                //                    FROM HMI_COPY   
                //                   WHERE 블록코드 = '000015'
                //                     AND 항목 = 'FL'
                //                     AND 태그아이디 = '1L-42730-501-FRI-O011'
                //                     AND 시간 BETWEEN TO_DATE('20220103000000', 'YYYYMMDDHH24MISS') 
                //                                     AND TO_DATE('20220103235959', 'YYYYMMDDHH24MISS');";

                //string strMET = @"SELECT 시간
                //                    FROM HMI_COPY   
                //                   WHERE 블록코드 = '000015'
                //                     AND 항목 = 'FL'
                //                     AND 태그아이디 = '1L-42730-501-FRI-O011'
                //                     AND 시간 BETWEEN TO_DATE('20220103000000', 'YYYYMMDDHH24MISS') 
                //                                     AND TO_DATE('20220103235959', 'YYYYMMDDHH24MISS');";

                //string strMEV = @"SELECT 계측값
                //                    FROM HMI_COPY   
                //                   WHERE 블록코드 = '000015'
                //                     AND 항목 = 'FL'
                //                     AND 태그아이디 = '1L-42730-501-FRI-O011'
                //                     AND 시간 BETWEEN TO_DATE('20220103000000', 'YYYYMMDDHH24MISS') 
                //                                     AND TO_DATE('20220103235959', 'YYYYMMDDHH24MISS');";

                //string strMDV = @"SELECT 보정값
                //                    FROM HMI_COPY   
                //                   WHERE 블록코드 = '000015'
                //                     AND 항목 = 'FL'
                //                     AND 태그아이디 = '1L-42730-501-FRI-O011'
                //                     AND 시간 BETWEEN TO_DATE('20220103000000', 'YYYYMMDDHH24MISS') 
                //                                     AND TO_DATE('20220103235959', 'YYYYMMDDHH24MISS');";








                DataTable dtresult1 = TestClass.SelectData(strBLK);

                //dtresult1.Columns.Add("비앙세",typeof(string));
                datagrid.ItemsSource = dtresult1.DefaultView;


                
                // DataTable dtresult2 = TestClass.SelectData(strTID);
                // datagrid.ItemsSource = dtresult2.DefaultView;
                // DataTable dtresult3 = TestClass.SelectData(strITC);
                // datagrid.ItemsSource = dtresult3.DefaultView;
                // DataTable dtresult4 = TestClass.SelectData(strMET);
                // datagrid.ItemsSource = dtresult4.DefaultView;
                // DataTable dtresult5 = TestClass.SelectData(strMEV);
                // datagrid.ItemsSource = dtresult5.DefaultView;
                // DataTable dtresult6 = TestClass.SelectData(strMDV);
                // datagrid.ItemsSource = dtresult6.DefaultView; ;










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

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
