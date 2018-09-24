using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class userinfo   //添加需申明为public
    {
        public int id { get; set; }
        public string nickname { get; set; }
        public string truename { get; set; }
        public string sex { get; set; }
        public DateTime regtime { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
    }
}
