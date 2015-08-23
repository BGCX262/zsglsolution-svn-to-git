using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;
using MvcApplication.Common;
using MvcApplication.DAO;
using MvcApplication.Entities;

namespace MvcApplication.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        YhglDAO yhglDAO = new YhglDAO();

        public ActionResult UserBaseInfo(UserModel user)
        {
            return View(user);
        }


        public ActionResult UpdateUserInfo(UserModel user)
        {
            string userName = Request.Form["username"];
            string email = Request.Form["email"];
            string mobile = Request.Form["mobile"];
            string tel = Request.Form["tel"];
            string fax = Request.Form["fax"];

            if (userName == "")
                return JavaScript("alert('请输入用户名!');");
            if (email == "")
                return JavaScript("alert('请输入邮箱！');");
            yhgl_users userInfo = new yhgl_users
            {
                user_id = user.UserInfo.user_id,
                user_avatar = GlobalVar.AvatarPath,
                user_fax = fax,
                user_email = email,
                user_mobile = mobile,
                user_tel = tel,
                user_name = userName
            };
            ArgsHelp ah = yhglDAO.UpdateUserInfo(userInfo);
            if (ah.flag)
                return JavaScript("alert('更新成功！');refresh();");
            else
                return JavaScript("alert('更新失败！" + ah.msg + "');");

        }
    }
}
