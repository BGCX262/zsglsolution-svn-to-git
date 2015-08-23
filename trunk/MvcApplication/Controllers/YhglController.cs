using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.DAO;
using MvcApplication.Models;
using MvcApplication.Common;
using MvcApplication.Entities;

namespace MvcApplication.Controllers
{
    public class YhglController : Controller
    {
        YhglDAO yhglDAO = new YhglDAO();
        UserDataContext userDB = new UserDataContext();
        //
        // GET: /Yhgl/

    #region 查找用户/新增好友
        public string FindUsers(string username,UserModel user)
        {
            string resultStr = string.Empty;
            var users = yhglDAO.GetUsersByName(username);
            if (users.Count == 0)
                return "<div>没有找到这个用户！</div>";
            else
            {
                foreach (var u in users)
                {
                    if (u.user_id == user.UserInfo.user_id)
                        continue;
                    resultStr += BuildResultString(u.user_id.ToString(), u.user_name);
                }
            }
            return "<div>" + resultStr + "</div>"; 
        }

        public ActionResult AddNewFriend(UserModel user, string HiddenUId)
        {
            try
            {
                yhglDAO.AddFriend(user.UserInfo.user_id, Convert.ToInt32(HiddenUId));
                return JavaScript("alert('添加好友成功！');");
            }
            catch (Exception e)
            { return JavaScript("alert('添加好友失败！');"); }
        }

        string BuildResultString(string userID,string userName)
        {
            return "<form action='/Yhgl/AddNewFriend' method='post' onclick='Sys.Mvc.AsyncForm.handleClick(this, new Sys.UI.DomEvent(event));'"+
               "onsubmit='Sys.Mvc.AsyncForm.handleSubmit(this, new Sys.UI.DomEvent(event), { insertionMode: Sys.Mvc.InsertionMode.replace });' >" +
            "<span>" + userName + "</span>" +
            "<input type='hidden' name='HiddenUId' value=" + userID + " />" +
            "<span><input type='submit' value='加为好友' /></span>" +
            "</form>";
        }
    #endregion

        /// <summary>
        /// 新增附属用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult AddNewFsyh(UserModel user)
        {
            string fsyhName = Request.Form["fsyhName"];
            try
            {
                yhglDAO.AddFsyh(fsyhName, user.UserInfo.user_id);
                return JavaScript("alert('增加附属用户成功！');refresh();");
            }
            catch (Exception e)
            {
                return JavaScript("alert('增加附属用户失败！');");
            }
        }

        /// <summary>
        /// 增加好友分组
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult AddNewGroup(UserModel user)
        {
            string groupName = Request.Form["groupName"];
            ArgsHelp ah = new ArgsHelp();
            try
            {
                ah = yhglDAO.AddNewGroup(groupName, user.UserInfo.user_id);
                if(ah.flag)
                    return JavaScript("alert('增加分组成功！');refresh();");
                else
                    return JavaScript("alert('增加分组失败！');");
            }
            catch (Exception e)
            {
                return JavaScript("alert('增加分组失败！');");
            }

        }

        #region 管理员操作用户
        /// <summary>
        /// 增加用户页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddNewZyh()
        {
            return View();
        }

        /// <summary>
        /// 增加用户操作
        /// </summary>
        /// <returns></returns>
        public ActionResult AddNewZyh2SQL()
        {
            ArgsHelp ah = new ArgsHelp();
            try
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
                    user_qy = "是",
                    user_avatar = GlobalVar.AvatarPath ?? GlobalVar.DefaultAvatar
                };
                ah = yhglDAO.AddNewUser(userInfo);
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            if (ah.flag)
                return JavaScript("alert('增加成功！');refresh();");
            else
                return JavaScript("alert('增加失败！');");
        }

        public ActionResult DisableZyhView()
        {
            var users = (from us in userDB.yhgl_users
                         where us.user_qy == "是"
                         where us.level_id != 1
                         select us).ToList();
            var model = new UsersModel
            {
                Users = users
            };
            return View(model);
        }

        public ActionResult DisableZyh(string userId)
        {
            ArgsHelp ah = yhglDAO.DisableZyh(Convert.ToInt32(userId));
            if (ah.flag)
                return JavaScript("alert('禁用成功');refresh();");
            else
                return JavaScript("alert('禁用失败" + ah.msg + "')");
        }
        public ActionResult EnabledZyhView() 
        {
            var users = (from us in userDB.yhgl_users
                         where us.user_qy == "否"
                         where us.level_id != 1
                         select us).ToList();
            var model = new UsersModel
            {
                Users = users
            };
            return View(model);
        }
        public ActionResult EnabledZyh(string userId)
        {
            ArgsHelp ah = yhglDAO.EnabledZyh(Convert.ToInt32(userId));
            if (ah.flag)
                return JavaScript("alert('启用成功');refresh();");
            else
                return JavaScript("alert('启用失败" + ah.msg + "')");
        }

        public ActionResult UsersView()
        {
            List<UserWithFilesEntity> userWithFilesEntities = yhglDAO.GetUserWithFiles();
            var model = new UserWithFilesModel
            {
                UserWithFiles = userWithFilesEntities
            };
            return View(model);
        }


        public ActionResult ChangePsw()
        {
            var model = new UsersModel
            {
                Users = yhglDAO.GetAllUsers()
            };
            return View(model);
        }

        public ActionResult SetNewPsw(int userId)
        {
            string newPsw = Request.Form["newPsw"].ToString();
            ArgsHelp ah = new ArgsHelp();
            ah = yhglDAO.SetNewPsw(userId, newPsw);
            if (ah.flag)
                return JavaScript("alert('修改成功！');");
            else
                return JavaScript("alert('修改失败！" + ah.msg + "');");
        }
        #endregion

    }
}
