using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Common;
using MvcApplication.Entities;

namespace MvcApplication.DAO
{
    public class FriendDAO
    {
        FriendDataContext friendDB = new FriendDataContext();
        FsyhDataContext fsyhDB = new FsyhDataContext();
        FriendGroupDataContext groupDB = new FriendGroupDataContext();
        /// <summary>
        /// 好友移动
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="friendId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ArgsHelp MoveToNewGroup(string groupId,string friendId,int userId)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                var friend = (from f in friendDB.hygl_friend
                              where f.hy1_id == userId
                              where f.hy2_id == Convert.ToInt32(friendId)
                              select f).First();
                friend.group_id = Convert.ToInt32(groupId);
                friendDB.SubmitChanges();
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            return ah;
        }

        public ArgsHelp ChangeBz(int friendId, string bz)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                var friend = (from f in friendDB.hygl_friend
                              where f.hy2_id == friendId
                              select f).First();
                friend.hy_bz = bz;
                friendDB.SubmitChanges();
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            return ah;
        }

        public ArgsHelp FsyhChangeBz(int friendId, string bz)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                var fsyh = (from f in fsyhDB.yhgl_fsyh
                            where f.fsyh_id == friendId
                            select f).First();
                fsyh.fsyh_bz = bz;
                fsyhDB.SubmitChanges();
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            return ah;
        }

        public ArgsHelp ChangeGroupName(int groupId,string newName)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                var group = (from g in groupDB.hygl_group
                             where g.group_id == groupId
                             select g).First();
                group.group_name = newName;
                groupDB.SubmitChanges();
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
