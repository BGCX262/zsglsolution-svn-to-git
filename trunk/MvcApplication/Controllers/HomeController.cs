using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;
using MvcApplication.Entities;
using System.Web.Script.Serialization;
using MvcApplication.DAO;

namespace MvcApplication.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        ZyhGxFilesDataContext zyhGxFilesDB = new ZyhGxFilesDataContext();
        FsyhGxFilesDataContext fsyhGxFilesDB = new FsyhGxFilesDataContext();
        FilesDataContext filesDB = new FilesDataContext();
        UserDataContext userDB = new UserDataContext();
        FsyhDataContext fsyhDB = new FsyhDataContext();
        FriendDataContext friendDB = new FriendDataContext();
        UserFloderDataContext userFloderDB = new UserFloderDataContext();
        FriendGroupDataContext friendGroupDB = new FriendGroupDataContext();
        ZnxDAO znxDAO = new ZnxDAO();

        public ActionResult Main(UserModel user)
        {
            if (user.UserInfo.level_id == 1)
                return RedirectToAction("Admin");
            //上传的文件
            var file = (from f in filesDB.wjgl_files
                        where f.user_id == user.UserInfo.user_id
                        select f).ToList();
            //附属用户
            var fsyhs = (from fs in fsyhDB.yhgl_fsyh
                        where fs.user_id == user.UserInfo.user_id
                        select fs).ToList();
            //好友(主用户)
            var friends = (from fr in friendDB.hygl_friend
                           where fr.hy1_id == user.UserInfo.user_id
                           select fr).ToList();
            var floders = (from fl in userFloderDB.userfloder
                           where fl.user_id == user.UserInfo.user_id
                           select fl).ToList();
            var groups = (from g in friendGroupDB.hygl_group
                          where g.user_id == user.UserInfo.user_id
                          select g).ToList();
            user.Files = file.Count == 0 ? new List<wjgl_files>() : file;
            user.FsyhMx = fsyhs.Count == 0 ? new List<yhgl_fsyh>() : fsyhs;
            user.UserFloders = floders.Count == 0 ? new List<userfloder>() : floders;
            user.FriendGroups = groups.Count == 0 ? new List<hygl_group>() : groups;
            List<FriendEntity> friendList = new List<FriendEntity>();
            foreach (var friend in friends)
            {
                var userF = (from u in userDB.yhgl_users
                             where u.user_id == friend.hy2_id
                             select u).First();
                hygl_group group;
                if (friend.group_id == null)
                    group = new hygl_group();
                else
                    group = (from g in friendGroupDB.hygl_group
                             where g.group_id == friend.group_id
                             select g).First();
                FriendEntity friendEntity = new FriendEntity
                {
                    YhInfo = userF,
                    GroupInfo = group,
                    FriendMx = friend
                };
                friendList.Add(friendEntity);
                
            }
            user.FriendMx = friendList;
            //可查看的共享文件
            var gxFiles = (from gf in zyhGxFilesDB.gxgl_zyhgx
                           where gf.user_id == user.UserInfo.user_id
                           select gf).ToList();
            List<ZyhGxFilesEntity> gxFilesEntities = new List<ZyhGxFilesEntity>();
            foreach (gxgl_zyhgx zyhgx in gxFiles)
            {
                var fileInfo = (from fi in filesDB.wjgl_files
                                where fi.file_id == zyhgx.file_id
                                select fi).First();
                var userInfo = (from ui in userDB.yhgl_users
                                where ui.user_id == zyhgx.gx_ly
                                select ui).First();
                ZyhGxFilesEntity zyhGxFilesEntity = new ZyhGxFilesEntity
                {
                    FileInfo = fileInfo,
                    GxyhInfo = userInfo,
                    Gxmx = zyhgx
                };
                gxFilesEntities.Add(zyhGxFilesEntity);
            }
            user.ZyhGxFiles = gxFilesEntities;
            user.ZnxMx = znxDAO.GetAllRsvZnx(user.UserInfo.user_id);
            return View(user);
        }



        /// <summary>
        /// 附属用户登录
        /// </summary>
        /// <param name="fsyh"></param>
        /// <returns></returns>
        public ActionResult Fsyh(FsyhModel fsyh)
        {
            var files = (from f in fsyhGxFilesDB.gxgl_fsyhgxb
                         where f.fsyh_id == fsyh.FsyhInfo.fsyh_id
                         select f).ToList();
            List<FsyhGxFileEntity> fsyhEilesEntities = new List<FsyhGxFileEntity>();
            foreach (var file in files)
            {
                var fileInfo = (from fi in filesDB.wjgl_files
                                where fi.file_id == file.file_id
                                select fi).First();
                FsyhGxFileEntity fsyhEilesEntity = new FsyhGxFileEntity();
                fsyhEilesEntity.FileInfo = fileInfo;
                fsyhEilesEntities.Add(fsyhEilesEntity);
            }
            fsyh.FsyhGxInfo = fsyhEilesEntities;
            return View(fsyh);
        }

        public ActionResult Admin(UserModel user)
        {
            var friends = (from f in userDB.yhgl_users
                           where f.level_id != 1
                           select f).ToList();
            List<FriendEntity> friendList = new List<FriendEntity>();
            foreach (var friend in friends)
            {
                FriendEntity friendEntity = new FriendEntity
                {
                    YhInfo = friend,
                    GroupInfo = new hygl_group
                    {
                        group_id = 0
                    },
                    FriendMx = new hygl_friend()
                };
                friendList.Add(friendEntity);
            }
            user.FriendMx = friendList;
            var groups = (from g in friendGroupDB.hygl_group
                          where g.user_id == user.UserInfo.user_id
                          select g).ToList();
            user.FriendGroups = groups == null ? new List<hygl_group>() : groups;
            return View(user);
        }

        public ActionResult Welcome(UserModel user)
        {
            return View(user);   
        }
    }
}
