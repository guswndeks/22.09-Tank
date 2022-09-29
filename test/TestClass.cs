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
                
            
                test2class test2class = new test2class();
                

                

                return list.ToArray();
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }
    }


}

