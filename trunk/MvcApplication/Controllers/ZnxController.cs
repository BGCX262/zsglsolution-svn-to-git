using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;
using MvcApplication.Entities;
using MvcApplication.DAO;
using MvcApplication.Common;

namespace MvcApplication.Controllers
{
    public class ZnxController : Controller
    {
        ZnxDAO znxDAO = new ZnxDAO();
        //
        // GET: /Znx/

        public ActionResult SendZnxView(UserModel user)
        {
            return View(user);
        }

        /// <summary>
        /// 发送站内信
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult Send(UserModel user)
        {
            string[] receivers = Request.Form["rsvID"].Split(',');
            string content = Request.Form["content"];
            string topic = Request.Form["topic"];
            try
            {
                foreach (var receiver in receivers)
                {
                    yjgl_znx znx = new yjgl_znx
                    {
                        fs_user_id = user.UserInfo.user_id,
                        js_user_id = Convert.ToInt32(receiver),
                        znx_topic = topic,
                        znx_nr = content,
                        znx_fssj = DateTime.Now.ToString("yyy-MM-dd hh:mm:ss"),
                        znx_isread = "否"
                    };
                    ArgsHelp ah = znxDAO.SendZnx(znx);
                    if (!ah.flag)
                        throw new Exception(ah.msg);
                }
            }
            catch (Exception e)
            {
                return JavaScript("ZnxFailed('" + e.Message + "');");
            }
            return JavaScript("ZnxSuccessed();");
        }

        public ActionResult AllZnx(UserModel user)
        {
            var model = new ZnxModel
            {
                ZnxEntities = znxDAO.GetAllZnx(user.UserInfo.user_id)
            };
            return View(model);
        }

        public ActionResult SetIsRead(int znxId)
        {
            ArgsHelp ah = znxDAO.SetIsRead(znxId);
            if (ah.flag)
                return JavaScript("refresh();");
            else
                return JavaScript("alert('发生错误" + ah.msg + "');");
        }

    }
}
