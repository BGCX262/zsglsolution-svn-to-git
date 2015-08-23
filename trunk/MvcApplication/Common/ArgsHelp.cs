using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Common
{
    public class ArgsHelp
    {
        public ArgsHelp()
        {
            this.flag = true;
            this.msg = "";
        }

        public ArgsHelp(bool flag)
        {
            this.flag = flag;
        }

        public ArgsHelp(bool flag, string msg)
        {
            this.flag = flag;
            this.msg = msg;
        }

        public bool flag { set; get; }//正确还是错误
        public string msg { set; get; } //消息
    }
}
