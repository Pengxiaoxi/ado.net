using model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dao
{
    public class UserDao
    {
        //将数据表da转换为List集合
        public List<userinfo> DataTableToList(DataTable da)
        {
            List<userinfo> userlist = new List<userinfo>();
            if (da.Rows.Count > 0)
            {
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
            }
            return userlist;
        }
    }
}
