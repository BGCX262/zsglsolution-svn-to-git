using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;
using MvcApplication.DAO;
using MvcApplication.Common;

namespace MvcApplication.Controllers
{
    public class FriendController : Controller
    {
        FriendDAO friendDAO = new FriendDAO();
        public ActionResult MoveFriend(string groupId, string friendId, UserModel user)
        {
            ArgsHelp ah = friendDAO.MoveToNewGroup(groupId, friendId, user.UserInfo.user_id);
            if (ah.flag)
                return JavaScript("refresh();");
            else
                return JavaScript("alert('出错！" + ah.msg + "')");
        }

        public ActionResult ChangeBz()
        {
            string friendId = Request.Form["hiddenId"];
            string bz = Request.Form["bz"];
            string type = Request.Form["friendType"];
            ArgsHelp ah=new ArgsHelp();
            if (type == "主用户")
                ah = friendDAO.ChangeBz(Convert.ToInt32(friendId), bz);
            else
                ah = friendDAO.FsyhChangeBz(Convert.ToInt32(friendId), bz);
            if (ah.flag)
                return JavaScript("alert('备注更改成功!');refresh();");
            else
                return JavaScript("alert('错误！" + ah.msg + "');");
        }

        public ActionResult FsyhChangeBz()
        {
            string friendId = Request.Form["hiddenId"];
            string bz = Request.Form["fsyhBz"];
            ArgsHelp ah = friendDAO.ChangeBz(Convert.ToInt32(friendId), bz);
            if (ah.flag)
                return JavaScript("alert('备注更改成功!');refresh();");
            else
                return JavaScript("alert('错误！" + ah.msg + "');");
        }

        public ActionResult ChangeGroupName()
        {
            string id = Request.Form["groupId"];
            string name = Request.Form["name"];
            ArgsHelp ah = friendDAO.ChangeGroupName(Convert.ToInt32(id), name);
            if (ah.flag)
                return JavaScript("alert('更改成功！');refresh();");
            else
                return JavaScript("alert('更改失败！" + ah.msg + "');");
        }

    }
}
