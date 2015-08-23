using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.DAO;
using MvcApplication.Helpers;
using MvcApplication.Entities;
using MvcApplication.Common;

namespace MvcApplication.Controllers
{
    public class RegisterController : Controller
    {
        YhglDAO yhglDAO = new YhglDAO();
        //
        // GET: /Register/

        public ActionResult Index()
        {
            ViewData["challengeGuid"] = Guid.NewGuid().ToString();
            return View();
        }

        public string ValidationData(string userName)
        {
            bool isExist = yhglDAO.IsExistByName(userName);
            return isExist.ToString().ToLower();
        }

        public ActionResult RegisterUser()
        {
            string userName = Request.Form["username"];
            string psw = Request.Form["psw"];
            string email = Request.Form["email"];
            string bm = Request.Form["bm"];
            string mobile = Request.Form["mobile"];
            string tel = Request.Form["tel"];
            string fax = Request.Form["fax"];
           


            var userInfo = new yhgl_users
            {
                user_name = userName,
                user_email = email,
                user_psw = psw,
                user_bm = bm,
                user_mobile = mobile,
                user_tel = tel,
                user_fax = fax,
                level_id = 2,
                user_qy = "是"
            };



            ArgsHelp ah = yhglDAO.AddNewUser(userInfo);
            if (ah.flag)
                return JavaScript("alert('注册成功！')");
            else
                return JavaScript("alert('注册失败！')");
        }

        public string SubmitRegistration(string myCaptcha, string attempt)
        {
            if (CaptchaHelper.VerifyAndExpireSolution(HttpContext, myCaptcha, attempt))
                return "true";
            else
                return "false";
        }

    }
}
