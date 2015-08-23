using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Entities;
using MvcApplication.Models;
using MvcApplication.DAO;
using MvcApplication.Common;

namespace MvcApplication.Controllers
{
    public class FloderController : Controller
    {
        FloderDAO floderDAO = new FloderDAO();
        //
        // GET: /Floder/

        public ActionResult AddFloder(UserModel user)
        {
            ArgsHelp ah = new ArgsHelp();
            string floderName = Request.Form["floderName"];
            string higherFloder = Request.Form["higherFloder"];
            if (floderName == "")
                return JavaScript("alert('请填写文件名')");
            string filePath = Request.MapPath("/UploadFiles/" + user.UserInfo.user_id + "/");
            if (higherFloder == null || higherFloder == "/")
            {
                filePath = Request.MapPath("/UploadFiles/" + user.UserInfo.user_id + "/") + floderName;
                higherFloder = "";
            }
            else
                filePath = Request.MapPath("/UploadFiles/" + user.UserInfo.user_id + "/") + higherFloder + "/" + floderName;
            ah = floderDAO.AddNewFloder(user.UserInfo.user_id, floderName, filePath, higherFloder);
            if (ah.flag)
                return JavaScript("alert('添加成功');refresh();");
            else
                return JavaScript("alert('添加失败');");
        }

        public ActionResult MoveToFloder(string fileID, string floderName, string higherFloder, UserModel user)
        {
            ArgsHelp ah = new ArgsHelp();
            string filePath = string.Empty;
            if (higherFloder == null || higherFloder == "")
                filePath = user.UserInfo.user_id + "/" + floderName;
            else
                filePath = user.UserInfo.user_id + "/" + higherFloder + "/" + floderName;
            ah = floderDAO.MoveFileToNewFloder(fileID, floderName, filePath, Request.MapPath("/UploadFiles/"));
            if (ah.flag)
                return JavaScript("alert('移动成功');refresh();");
            else
                return JavaScript("alert('移动失败');");
        }

        public ActionResult DelFloder(string floderName, string higherFloder, UserModel user)
        {
            ArgsHelp ah = new ArgsHelp();
            foreach (var file in user.Files)
            {
                if (file.floder_name == floderName)
                    return JavaScript("alert('文件夹内还有文件，无法删除！')");
            }
            string filePath = string.Empty;
            if (higherFloder == null || higherFloder == "")
                filePath = Request.MapPath("/UploadFiles/" + user.UserInfo.user_id + "/") + floderName;
            else
                filePath = Request.MapPath("/UploadFiles/" + user.UserInfo.user_id + "/") + higherFloder + "/" + floderName;
            ah = floderDAO.DeleteFloder(floderName, filePath);
            if (ah.flag)
                return JavaScript("alert('删除成功');refresh();");
            else
                return JavaScript("alert('删除失败');");
        }

    }
}
