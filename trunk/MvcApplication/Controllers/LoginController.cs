using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Entities;
using MvcApplication.Models;

namespace MvcApplication.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        UserDataContext userDB = new UserDataContext();
        FsyhDataContext fsyhDB = new FsyhDataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Verify(UserModel user,FsyhModel fsyh)
        {
            string name = Request.Form["username"];
            string psw = Request.Form["password"];
            string kind = Request.Form["userKind"];
            if (kind == "主用户")
            {
                var users = (from u in userDB.yhgl_users
                             where u.user_name == name
                             where u.user_psw == psw
                             where u.user_qy == "是"
                             select u).ToList();
                if (users.Count != 0)
                {
                    user.UserInfo = users.First();
                    return JavaScript("document.location='/Home/Main'");
                }
                return JavaScript("alert('登录失败');");
            }
            else
            {
                var fsyhs = (from fs in fsyhDB.yhgl_fsyh
                            where fs.fsyh_name == name
                            select fs).ToList();
                if (fsyhs.Count != 0)
                {
                    fsyh.FsyhInfo = fsyhs.First();
                    return JavaScript("document.location='/Home/Fsyh'");
                }
                return JavaScript("alert('登录失败')");
            }
        }

        bool Validate(string name,string psw)
        {
            if (name == "")
                return false;
            if (psw == "")
                return false;
            return true;
        }

    }
}
