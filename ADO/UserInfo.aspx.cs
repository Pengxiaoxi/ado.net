using dao;
using model;
using sqlhelper;
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
    public partial class UserInfo : System.Web.UI.Page
    {
        //private readonly static string connStr = "server=10.84.192.131l uid=sa; pwd=777777; database=BBS";

        //调用config文件中的数据库连接   （这个成员只能在本类中使用，这个成员不需要实例化即可使用，这个成员只能在"类初始化"时赋值）
        private readonly static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public List<userinfo> userInfo { get; set; }
        public int uid { get; set; }

        SqlHelper sqlhelper = new SqlHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            string flag = Request["flag"];

            if (flag == null || "".Equals(flag))
            {
                this.showuser();
            }
            else if (flag == "delete")
            {
                this.deleteuser();
            }
        }

        ////查询 WAY1  ado.net
        //protected void showuser()
        //{
        //    //得到数据库连接对象conn
        //    using (SqlConnection conn = new SqlConnection(connStr))
        //    {
        //        string sql = "select * from t_user";    //定义sql语句  where nickname = 'px';  where mobile like '%123%'"

        //        using (SqlDataAdapter atper = new SqlDataAdapter(sql, conn))
        //        {
        //            DataTable da = new DataTable();     //创建数据表对象

        //            atper.Fill(da);   //将数据库查询出来的结果填充到da对象中

        //            //int i = da.Rows.Count;   //查询出来了几条数据

        //            UserDao userdao = new UserDao();

        //            userInfo = userdao.DataTableToList(da);  //将DataTable转换为List               
        //        }
        //    }
        //}

        //查询nickname = px的  //WAY2   调用sqlhelper类传递SQL与参数
        protected void showuser()
        {    
            string nickname = "lc";

            string sql = "select * from t_user";    //定义带有参数的SQL语句 where nickname=@nickname

            SqlParameter[] param = {
                new SqlParameter("@nickname",SqlDbType.VarChar),
            };
            param[0].Value = nickname;                           //定义参数数组并赋值

            DataTable da = sqlhelper.ExecuteQuery(sql, null);   //若有参数则传参否则为null

            UserDao userdao = new UserDao();

            userInfo = userdao.DataTableToList(da);              //转换为list集合
        }


        protected void firstnewuser()
        {
            string sql = "select * from t_user order by id asc";

            object obj = sqlhelper.ExecuteScalar(sql, null);
        }



        //删除  ado.net   way1
        //protected void deleteuser()
        //{
        //    uid = Convert.ToInt32(Request["uid"]);   //Int32.Parse()
        //    //得到数据库连接对象conn
        //    using (SqlConnection conn = new SqlConnection(connStr))
        //    {
        //        string sql = "delete from t_user where id = @id";  //删除的SQL语句

        //        using (SqlCommand cmd = new SqlCommand(sql, conn))
        //        {
        //            SqlParameter[] param = {
        //                new SqlParameter("@id", SqlDbType.Int)
        //            };

        //            param[0].Value = uid;

        //            cmd.Parameters.AddRange(param);    //将参数数组添加到SQL语句中

        //            conn.Open();  //打开数据库连接
        //            int i = cmd.ExecuteNonQuery();  //返回受影响行数

        //            if (i > 0)
        //            {
        //                Response.Redirect("/UserInfo.aspx");
        //            }
        //            else
        //            {
        //                Response.Redirect("/UserInfo.aspx");
        //            }

        //        }
        //    }
        //}


        //删除方法 way2   调用sqlhelper类
        protected void deleteuser()
        {
            uid = Convert.ToInt32(Request["uid"]);

            string sql = "delete from t_user where id = @id";

            SqlParameter[] paramter = {
                new SqlParameter("@id",SqlDbType.Int),
            };
            paramter[0].Value = uid;                //定义参数数组并赋值

            int i = sqlhelper.ExecuteNonQuery(sql, paramter);   //返回受影响行数

            if (i > 0)
            {
                Response.Redirect("/UserInfo.aspx");
            }
            else
            {
                Response.Redirect("/UserInfo.aspx");
            }
        }



        //将数据表da转换为List集合
        protected List<userinfo> findUserList(DataTable da)
        {
            //if (da.Rows.Count > 0)
            //{
            List<userinfo> userlist = new List<userinfo>();
            foreach (DataRow row in da.Rows)
            {
                userinfo user = new userinfo();
                user.id = Convert.ToInt32(row["id"]);
                user.nickname = row["nickname"].ToString();
                user.truename = row["truename"].ToString();
                user.sex = row["sex"].ToString();
                user.regtime = Convert.ToDateTime(row["regtime"]);   //Covert转换函数
                user.mobile = row["mobile"].ToString();
                user.email = row["email"].ToString();

                userlist.Add(user);   //将创建出来的userinfo对象一一保存到userInfo中
            }
            //}
            return userlist;
        }



        //查询
        //protected void try1()
        //{
        //    using (SqlConnection conn = new SqlConnection(connStr))
        //    {
        //        string sql = "select * from t_user";

        //        using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
        //        {
        //            DataTable da = new DataTable();

        //            adapter.Fill(da);

        //            UserDao userDao = new UserDao();

        //            List<userinfo> userList = userDao.DataTableToList(da);
        //        }
        //    }
        //}

        //删除
        //protected void try2()
        //{
        //    int uid = Convert.ToInt32(Request["uid"]);
        //    using (SqlConnection conn = new SqlConnection(connStr))
        //    {
        //        string sql = "delete from t_user where id = @id";

        //        using (SqlCommand cmd = new SqlCommand(sql, conn))
        //        {
        //            SqlParameter[] param = {
        //                new SqlParameter("@id", SqlDbType.Int)
        //            };

        //            param[0].Value = uid;

        //            cmd.Parameters.AddRange(param);

        //            conn.Open();

        //            int i = cmd.ExecuteNonQuery();

        //            if (i > 0)
        //            {
        //                Response.Write(true);
        //            }
        //        }
        //    }
        //}

    }
}