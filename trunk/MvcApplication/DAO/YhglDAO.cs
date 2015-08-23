using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Entities;
using MvcApplication.Common;

namespace MvcApplication.DAO
{
    public class YhglDAO
    {
        FilesDataContext filesDB = new FilesDataContext();
        FsyhDataContext fsyhDB = new FsyhDataContext();
        FriendDataContext friendDB = new FriendDataContext();
        UserDataContext userDB = new UserDataContext();
        FriendGroupDataContext friendGroupDB = new FriendGroupDataContext();

        /// <summary>
        /// 增加附属用户
        /// </summary>
        /// <param name="fsyhName">附属用户名</param>
        /// <param name="userID">主用户ID</param>
        /// <returns></returns>
        public string AddFsyh(string fsyhName,int userID)
        {
            var fsyh = new yhgl_fsyh
            {
                fsyh_name = fsyhName,
                user_id = userID
            };
            fsyhDB.yhgl_fsyh.InsertOnSubmit(fsyh);
            fsyhDB.SubmitChanges();
            return (from fy in fsyhDB.yhgl_fsyh
                    where fy.fsyh_name == fsyhName
                    where fy.user_id == userID
                    select fy.fsyh_id).First().ToString();
        }

        /// <summary>
        /// 添加一组好友关系
        /// </summary>
        /// <param name="userId1">好友1</param>
        /// <param name="userId2">好友2</param>
        public void AddFriend(int userId1, int userId2)
        {
            var friend = new hygl_friend
            {
                hy1_id = userId1,
                hy2_id = userId2,
                hy_time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
            };
            var friend2 = new hygl_friend
            {
                hy1_id = userId2,
                hy2_id = userId1,
                hy_time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
            };
            friendDB.hygl_friend.InsertOnSubmit(friend);
            friendDB.hygl_friend.InsertOnSubmit(friend2);
            friendDB.SubmitChanges();
        }

        /// <summary>
        /// 获取好友信息
        /// </summary>
        /// <returns></returns>
        public List<hygl_friend> GetFriendxx()
        {
            var friends = (from f in friendDB.hygl_friend
                           select f).ToList();

            return friends;
        }

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public bool IsExistByName(string userName)
        {
            var user = (from u in userDB.yhgl_users
                        where u.user_name == userName
                        select u).ToList();
            if (user.Count == 0)
                return true;//没有找到相同用户名的用户，可以使用
            else
                return false;
        }

        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ArgsHelp AddNewUser(yhgl_users user)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                userDB.yhgl_users.InsertOnSubmit(user);
                userDB.SubmitChanges();
                ah.flag = true;
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            return ah;
        }

        /// <summary>
        /// 查找好友
        /// </summary>
        /// <param name="username">要查找的用户名</param>
        /// <returns></returns>
        public List<yhgl_users> GetUsersByName(string username)
        {
            var users = (from u in userDB.yhgl_users
                         where u.user_name.Contains(username)
                         select u).ToList();
            return users;
        }

        /// <summary>
        /// 好友分组
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ArgsHelp AddNewGroup(string groupName,int userId)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                var group = new hygl_group
                {
                    group_name = groupName,
                    user_id = userId,
                    group_cjsj = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                };
                friendGroupDB.hygl_group.InsertOnSubmit(group);
                friendGroupDB.SubmitChanges();
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            return ah;
        }

        /// <summary>
        /// 禁用好友
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ArgsHelp DisableZyh(int userId)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                var user = (from u in userDB.yhgl_users
                            where u.user_id == userId
                            select u).First();
                user.user_qy = "否";
                userDB.SubmitChanges();
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            return ah;
        }

        /// <summary>
        /// 启用好友
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ArgsHelp EnabledZyh(int userId)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                var user = (from u in userDB.yhgl_users
                            where u.user_id == userId
                            select u).First();
                user.user_qy = "是";
                userDB.SubmitChanges();
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            return ah;
        }

        public List<wjgl_files> UserGetFiles(int userId)
        {
            var files = (from f in filesDB.wjgl_files
                         where f.user_id == userId
                         select f).ToList();
            return files;
        }

        public List<UserWithFilesEntity> GetUserWithFiles()
        {
            List<UserWithFilesEntity> userWithFilesEntities = new List<UserWithFilesEntity>();
            var users = (from us in userDB.yhgl_users
                         where us.user_qy == "是"
                         where us.level_id != 1
                         select us).ToList();
            foreach (var user in users)
            {
                UserWithFilesEntity userWithFilesEntity = new UserWithFilesEntity();
                userWithFilesEntity.User = user;
                userWithFilesEntity.Files = UserGetFiles(user.user_id);
                userWithFilesEntities.Add(userWithFilesEntity);
            }
            return userWithFilesEntities;
        }

        /// <summary>
        /// 查找所有主用户（level_id!=1）
        /// </summary>
        /// <returns></returns>
        public List<yhgl_users> GetAllZyh()
        {
            var users = (from us in userDB.yhgl_users
                         where us.user_qy == "是"
                         where us.level_id != 1
                         select us).ToList();
            return users;
        }

        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        public List<yhgl_users> GetAllUsers()
        {
            var users = (from us in userDB.yhgl_users
                         where us.user_qy == "是"
                         select us).ToList();
            return users;
        }

        public ArgsHelp SetNewPsw(int userId, string newPsw)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                var user = (from u in userDB.yhgl_users
                            where u.user_id == userId
                            select u).First();
                user.user_psw = newPsw;
                userDB.SubmitChanges();
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            return ah;
        }

        public yhgl_users GetUserById(int userId)
        {
            var user = (from u in userDB.yhgl_users
                        where u.user_id == userId
                        select u).First();
            return user;
        }

        public ArgsHelp UpdateUserInfo(yhgl_users userInfo)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                var user = (from u in userDB.yhgl_users
                            where u.user_id == userInfo.user_id
                            select u).First();
                user.user_name = userInfo.user_name;
                user.user_mobile = userInfo.user_mobile;
                user.user_email = userInfo.user_email;
                user.user_avatar = userInfo.user_avatar;
                user.user_fax = userInfo.user_fax;
                user.user_tel = userInfo.user_tel;
                userDB.SubmitChanges();
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            return ah;
        }
    }
}
