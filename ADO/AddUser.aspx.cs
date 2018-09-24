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
    public partial class AddUser : System.Web.UI.Page
    {
        //调用config文件中的数据库连接
        private readonly static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public string save { get; set; }  //添加或保存

        public int uid { get; set; }
        public string nickname { get; set; }
        public string truename { get; set; }
        public string sex { get; set; }
        public string password { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string face { get; set; }
        public string type { get; set; }
        public DateTime regtime { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string flag = Request["flag"];

            if (flag == null || "".Equals(flag))
            {
                save = "添加";
                this.add();
            }
            else if (flag == "update")
            {
                save = "保存";
                this.update();
            }
        }
        //添加
        protected void add()
        {
            if (IsPostBack)
            {
                nickname = Request["nickname"];
                truename = Request["truename"];
                password = Request["password"];
                mobile = Request["mobile"];
                email = Request["email"];
                sex = Request["sex"];
                face = Request["face"];
                type = Request["type"];
                DateTime regetime = DateTime.Now;

                int i = 0;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "insert into t_user values(@email,@face,@mobile,@nickname,@password,@regetime,@sex,@truename,@type)";  //此顺序需要与数据库列对应

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //申明一个参数数组并定义好每个参数的类型
                        SqlParameter[] pars = {
                            new SqlParameter("@nickname",SqlDbType.VarChar,20),
                            new SqlParameter("@truename",SqlDbType.VarChar,20),
                            new SqlParameter("@password",SqlDbType.VarChar,100),
                            new SqlParameter("@regetime",SqlDbType.DateTime),
                            new SqlParameter("@mobile",SqlDbType.VarChar,20),
                            new SqlParameter("@email",SqlDbType.VarChar,100),
                            new SqlParameter("@sex",SqlDbType.VarChar,4),
                            new SqlParameter("@face",SqlDbType.VarChar,200),
                            new SqlParameter("@type",SqlDbType.VarChar,10),
                        };
                        //给参数数组赋值
                        pars[0].Value = nickname;
                        pars[1].Value = truename;
                        pars[2].Value = password;
                        pars[3].Value = regetime;
                        pars[4].Value = mobile;
                        pars[5].Value = email;
                        pars[6].Value = sex;
                        pars[7].Value = face;
                        pars[8].Value = type;

                        cmd.Parameters.AddRange(pars);   //将参数数组添加到SQL语句中

                        conn.Open();   //打开数据库连接

                        i = cmd.ExecuteNonQuery();  //执行SQL语句后返回受影响行数
                    }
                    if (i > 0)
                    {
                        Response.Write("添加成功！");
                        Response.Redirect("/UserInfo.aspx");
                    }
                    else
                    {
                        Response.Write("添加失败！");
                    }
                }
            }
        }

        //修改
        protected void update()
        {
            if (!IsPostBack)
            {
                uid = Convert.ToInt32(Request["uid"]);
                nickname = Request["nickname"];
                truename = Request["truename"];
                password = Request["password"];
                mobile = Request["mobile"];
                email = Request["email"];
                sex = Request["sex"];
                face = Request["face"];
                type = Request["type"];
            }
            else
            {
                uid = Convert.ToInt32(Request.Form["uid"]);
                nickname = Request.Form["nickname"];
                truename = Request.Form["truename"];
                password = Request.Form["password"];
                mobile = Request.Form["mobile"];
                email = Request.Form["email"];
                sex = Request.Form["sex"];
                face = Request.Form["face"];
                type = Request.Form["type"];

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "update t_user set nickname=@nickname,truename=@truename,password=@password,mobile=@mobile,email=@email,sex=@sex,face=@face,type=@type where id = @id";

                    using (SqlCommand cmd = new SqlCommand(sql ,conn))
                    {
                        SqlParameter[] param = {
                            new SqlParameter("@nickname",SqlDbType.VarChar),
                            new SqlParameter("@truename",SqlDbType.VarChar),
                            new SqlParameter("@password",SqlDbType.VarChar),
                            new SqlParameter("@mobile",SqlDbType.VarChar),
                            new SqlParameter("@email", SqlDbType.VarChar),
                            new SqlParameter("@sex", SqlDbType.VarChar),
                            new SqlParameter("@face", SqlDbType.VarChar),
                            new SqlParameter("@type", SqlDbType.VarChar),
                            new SqlParameter("@id", SqlDbType.Int),
                        };

                        param[0].Value = nickname;
                        param[1].Value = truename;
                        param[2].Value = password;
                        param[3].Value = mobile;
                        param[4].Value = email;
                        param[5].Value = sex;
                        param[6].Value = face;
                        param[7].Value = type;
                        param[8].Value = uid;

                        cmd.Parameters.AddRange(param);  //将参数数组添加到SQL语句中
                        
                        conn.Open();  //打开数据库连接

                        int i = cmd.ExecuteNonQuery();   //返回SQL语句执行后受影响行数

                        if (i > 0)
                        {
                            Response.Redirect("/UserInfo.aspx");
                        }
                    }
                }
            }
        }
    }
}
