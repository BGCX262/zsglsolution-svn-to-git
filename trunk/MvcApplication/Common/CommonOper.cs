using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace MvcApplication.Common
{
    public class CommonOper
    {
        /// <summary>
        /// 验证邮箱
        /// </summary>
        /// <param name="input_email"></param>
        /// <returns></returns>
        public static bool email_hftz(string input_email)
        {
            Regex cardExp = new Regex(@"^[0-9a-zA-Z]+([._\-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+\.[0-9a-zA-Z]+$");
            if (cardExp.Match(input_email).Success == false)
                return false;
            else
                return true;
        }
    }
}
