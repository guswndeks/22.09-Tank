using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using Tibero.DbAccess;

namespace test
{
    public class TestClass
    {
        public static string resultID = string.Empty;
        public static string resultPW = string.Empty;
        public static string resultNM = string.Empty;
        public static string resultAGE = string.Empty;

        public static string[] ContainerC(string sql)
        {
            string strconn = "Provider = tbprov.Tbprov.6; Location=127.0.0.1,8640; Data Source = tiberia; User ID = Xerath; Password=9598";

            Tibero.DbAccess.OleDbConnectionTbr conn = new OleDbConnectionTbr(strconn);

            try
            {
                conn.Open();
            
                Tibero.DbAccess.OleDbCommandTbr cmd1 = new OleDbCommandTbr();
                
                cmd1.CommandText = sql;
                cmd1.Connection = conn;

                OleDbDataReader reader1 = cmd1.ExecuteReader();

                List<string> list = new List<string>();

                if (reader1.Read())
                {
                    for (int i = 0; i < reader1.FieldCount; i++)
                    { 
                        list.Add(reader1[i].ToString());
                    }
                }

                conn.Close();
                string[] arySQLResult = list.ToArray();

                if (arySQLResult.Length > 0)
                {

                    resultID = arySQLResult[0].ToString();
                    resultPW = arySQLResult[1].ToString();
                    resultNM = arySQLResult[2].ToString();
                    resultAGE = arySQLResult[3].ToString();

                }


                return arySQLResult;
            }
            catch (Exception)
            {
                conn.Close();

                throw;
            }
        }

        public static string[] GetUserInfo()
        {
            string[] strarry = { resultID , resultPW, resultNM, resultAGE };
            return strarry;
        }

    }


}

