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
        public DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)    //若定义为static则不要需要引用new
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                {
                    if (parameters != null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(parameters);
                    }

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


        //ExecuteNonQuery 增加、修改与删除返回受影响行数i
        public int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            int i = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(parameters);     //将参数数组添加到sql中去

                    conn.Open();                             //打开数据库连接

                    i = cmd.ExecuteNonQuery();               //返回受影响行数

                    return i;
                }
            }
            catch (Exception)
            {
                return i;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
