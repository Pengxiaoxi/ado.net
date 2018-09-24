using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlhelper
{
    public class SqlHelper
    {
        //获取配置文件中的数据库连接字符串
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        private static readonly SqlConnection conn = new SqlConnection(connStr);


        //ExecuteQuery查询返回DataTable
        public DataTable ExecuteQuery(string sql, SqlParameter[] paramers)    //若定义为static则不要需要引用new
        {
            try
            {
                
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                {
                    //if (paramers != null)
                    //{
                    //    adapter.SelectCommand.Parameters.AddRange(paramers);
                    //}

                    //conn.Open();   //打开数据库连接  ps：SqlDataAdapter会自动打开数据库连接

                    DataTable datatabele = new DataTable();
                    adapter.Fill(datatabele);    //将查询结果填充到datatable中

                    return datatabele;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
