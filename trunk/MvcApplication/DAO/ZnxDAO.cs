using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Common;
using MvcApplication.Entities;

namespace MvcApplication.DAO
{
    public class ZnxDAO
    {
        YhglDAO yhglDAO = new YhglDAO();
        ZnxsDataContext znxDB = new ZnxsDataContext();
        public ArgsHelp SendZnx(yjgl_znx znx)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                znxDB.yjgl_znx.InsertOnSubmit(znx);
                znxDB.SubmitChanges();
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            return ah;
        }

        public List<ZnxEntity> GetAllZnx(int userId)
        {
            var znxs = (from z in znxDB.yjgl_znx
                        where z.fs_user_id == userId
                        select z).ToList();
            List<ZnxEntity> znxEntities = new List<ZnxEntity>();
            foreach (var znx in znxs)
            {
                var senderName = yhglDAO.GetUserById(znx.fs_user_id).user_name;
                var receiverName = yhglDAO.GetUserById(znx.js_user_id).user_name;
                ZnxEntity znxEntity = new ZnxEntity
                {
                    Znxmx = znx,
                    SenderName = senderName,
                    ReceiverName = receiverName
                };
                znxEntities.Add(znxEntity);

            }
            return znxEntities;
        }

        public List<ZnxEntity> GetAllRsvZnx(int userId)
        {
            var znxs = (from z in znxDB.yjgl_znx
                        where z.js_user_id == userId
                        select z).ToList();
            List<ZnxEntity> znxEntities = new List<ZnxEntity>();
            foreach (var znx in znxs)
            {
                var senderName = yhglDAO.GetUserById(znx.fs_user_id).user_name;
                var receiverName = yhglDAO.GetUserById(znx.js_user_id).user_name;
                ZnxEntity znxEntity = new ZnxEntity
                {
                    Znxmx = znx,
                    SenderName = senderName,
                    ReceiverName = receiverName
                };
                znxEntities.Add(znxEntity);

            }
            return znxEntities;
        }

        public ArgsHelp SetIsRead(int id)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                var znx = (from z in znxDB.yjgl_znx
                           where z.znx_id == id
                           select z).First();
                znx.znx_isread = "是";
                znxDB.SubmitChanges();
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
