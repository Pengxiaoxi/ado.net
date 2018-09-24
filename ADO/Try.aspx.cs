using dao;
using model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADO
{
    public partial class Try : System.Web.UI.Page
    {
        //private static readonly string conn = "server=10.84.192.131,uid=sa,pwd=777777,database=demo";

        private static readonly string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;   //调用数据库连接

        protected void Page_Load(object sender, EventArgs e)
        {
            string nickname = Request["nickname"];
            string truename = Request["truename"];
            //添加方法
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "insert into t_user valuse(@nickanme,@eamil)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlParameter[] param = {
                        new SqlParameter("@nickname",SqlDbType.VarChar),
                        new SqlParameter("@truename",SqlDbType.VarChar),
                    };
                    //给参数数组赋值
                    param[0].Value = nickname;
                    param[1].Value = truename;

                    cmd.Parameters.AddRange(param);   //将参数数组添加到SQL语句
                    conn.Open();   //打开数据库连接
                    int i = cmd.ExecuteNonQuery();  //返回执行后的受影响行数i

                    if (i > 0)
                    {
                        //......
                    }
                }
            }

            //查询
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "select * from t_user";

                using (SqlDataAdapter adaper = new SqlDataAdapter(sql, conn))
                {
                    DataTable da = new DataTable();   //创建数据表对象

                    adaper.Fill(da);        //将查询出来的结果添加到数据表da中

                    UserDao userdao = new UserDao();

                    List<userinfo> userList = userdao.DataTableToList(da);  //将数据表转换为List

                }
            }

        }
    }
}