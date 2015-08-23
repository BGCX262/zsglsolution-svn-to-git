using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;

namespace MvcApplication.Controllers
{
    public class FriendListController : Controller
    {
        //
        // GET: /FriendList/

        public ActionResult FriendNav(UserModel user)
        {
            var friendListModel = new FriendListModel
            {
                FriendGroups = user.FriendGroups,
                FriendMx = user.FriendMx,
                FsyhMx = user.FsyhMx,
                IsAdmin = user.UserInfo.level_id == 1 ? true : false
            };
            return View(friendListModel);
        }

    }
}
