using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Entities;
using MvcApplication.Common;

namespace MvcApplication.DAO
{
    public class GxglDAO
    {
        FsyhGxFilesDataContext fsyhGxFilesDB = new FsyhGxFilesDataContext();
        ZyhGxFilesDataContext zyhGxFilesDB = new ZyhGxFilesDataContext();
        FriendDataContext friendDB = new FriendDataContext();
        YhglDAO yhglDAO = new YhglDAO();

        /// <summary>
        /// 新增共享
        /// </summary>
        /// <param name="gxEntity">共享实体</param>
        /// <param name="userId">共享用户ID</param>
        public void AddGx(GxEntity gxEntity,int userId)
        {
            try
            {
                GxEntity gxEntityResult = AllGxmxById(userId);
                foreach (var user in gxEntity.UserList)
                {
                    AddFriend(user, userId.ToString());
                    foreach (var file in gxEntity.FileList)
                    {
                        if (ZyhValidate(user, file, gxEntityResult)) continue;
                        var zyhgx = new gxgl_zyhgx
                        {
                            file_id = file,
                            user_id = Convert.ToInt32(user),
                            gx_ly = userId,
                            gx_sj = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                            gx_isread = "否"
                        };
                        zyhGxFilesDB.gxgl_zyhgx.InsertOnSubmit(zyhgx);
                        zyhGxFilesDB.SubmitChanges();
                    }
                }
                foreach (var fsyh in gxEntity.FsyhList)
                {
                    foreach (var file in gxEntity.FileList)
                    {
                        if (FsyhValidate(fsyh, file, gxEntityResult)) continue;
                        var fsyhgx = new gxgl_fsyhgxb
                        {
                            file_id = file,
                            fsyh_id = Convert.ToInt32(fsyh),
                            fsyhgx_ly = userId,
                            fsyhgx_sj = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                        };
                        fsyhGxFilesDB.gxgl_fsyhgxb.InsertOnSubmit(fsyhgx);
                        fsyhGxFilesDB.SubmitChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// 验证是否已经存在该共享(主用户)
        /// </summary>
        /// <param name="userId">被共享的用户ID</param>
        /// <param name="fileId">被共享的文件ID</param>
        /// <returns></returns>
        bool ZyhValidate(string userId, string fileId,GxEntity gxEntityResult)
        {
            foreach (var zyhgx in gxEntityResult.ZyhgxMx)
            {
                if (zyhgx.user_id == Convert.ToInt32(userId) && zyhgx.file_id == fileId)
                    return true;//已经存在这个共享
            }
            return false;
        }

        /// <summary>
        /// 验证是否已经存在该共享(附属用户)
        /// </summary>
        /// <param name="fsyhId">被共享的附属用户ID</param>
        /// <param name="fileId">被共享的文件ID</param>
        /// <returns></returns>
        bool FsyhValidate(string fsyhId, string fileId, GxEntity gxEntityResult)
        {
            foreach (var fsyhgx in gxEntityResult.FsyhgxMx)
            {
                if (fsyhgx.fsyh_id == Convert.ToInt32(fsyhId) && fsyhgx.file_id == fileId)
                    return true;//已经存在这个共享
            }
            return false;
        }
        
        /// <summary>
        /// 为共享文件的用户与被共享的用户之间添加好友关系
        /// </summary>
        /// <param name="id1">用户ID1</param>
        /// <param name="id2">用户ID2</param>
        void AddFriend(string id1, string id2)
        {
            try
            {
                List<hygl_friend> friends = yhglDAO.GetFriendxx();
                if (friends.Count == 0)
                    yhglDAO.AddFriend(Convert.ToInt32(id1), Convert.ToInt32(id2));
                else
                {
                    foreach (var friend in friends)
                    {
                        if ((friend.hy1_id == Convert.ToInt32(id1) && friend.hy2_id == Convert.ToInt32(id2))
                            || (friend.hy1_id == Convert.ToInt32(id2) && friend.hy2_id == Convert.ToInt32(id1)))
                            return;
                    }
                    yhglDAO.AddFriend(Convert.ToInt32(id1), Convert.ToInt32(id2));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public GxEntity AllGxmxById(int userId)
        {
            var zyhgx = (from u in zyhGxFilesDB.gxgl_zyhgx
                         where u.gx_ly == userId
                         select u).ToList();
            var fsyhgx = (from fyf in fsyhGxFilesDB.gxgl_fsyhgxb
                             where fyf.fsyhgx_ly == userId
                             select fyf).ToList();

            var gxEntity = new GxEntity
            {
                ZyhgxMx = zyhgx,
                FsyhgxMx = fsyhgx
            };
            return gxEntity;
        }

        public ArgsHelp CancelGx(string gxId,string userType)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                if (userType == "主用户")
                {
                    var gxInfo = (from gx in zyhGxFilesDB.gxgl_zyhgx
                                  where gx.gx_id == Convert.ToInt32(gxId)
                                  select gx).First();
                    zyhGxFilesDB.gxgl_zyhgx.DeleteOnSubmit(gxInfo);
                    zyhGxFilesDB.SubmitChanges();
                }
                else
                {
                    var gxInfo = (from gx in fsyhGxFilesDB.gxgl_fsyhgxb
                                  where gx.fsyhgx_id == Convert.ToInt32(gxId)
                                  select gx).First();
                    fsyhGxFilesDB.gxgl_fsyhgxb.DeleteOnSubmit(gxInfo);
                    fsyhGxFilesDB.SubmitChanges();
                }
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            return ah;
        }
        
        public ArgsHelp SetIsRead(string id)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                var gx = (from g in zyhGxFilesDB.gxgl_zyhgx
                          where g.file_id == id
                          select g).First();
                gx.gx_isread = "是";
                zyhGxFilesDB.SubmitChanges();
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
