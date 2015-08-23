using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Common;
using MvcApplication.Entities;

namespace MvcApplication.DAO
{
    public class EmailglDAO
    {
        YjmxDataContext yjmxDB = new YjmxDataContext();
        FilesDataContext filesDB = new FilesDataContext();
        public ArgsHelp SaveEmailInfo(yjgl_yjmx yjmx)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                yjmxDB.yjgl_yjmx.InsertOnSubmit(yjmx);
                yjmxDB.SubmitChanges();
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            return ah;
        }

        public List<YjmxWithFilesEntity> GetAllEmails(int userId)
        {
            List<YjmxWithFilesEntity> yjmxWithFilesEntites = new List<YjmxWithFilesEntity>();
            var emails = (from u in yjmxDB.yjgl_yjmx
                          where u.user_id == userId
                          select u).ToList();
            foreach (var email in emails)
            {
                YjmxWithFilesEntity yjmxWithFilesEntity = new YjmxWithFilesEntity();
                yjmxWithFilesEntity.Yjmx = email;
                List<wjgl_files> files = new List<wjgl_files>();
                foreach (var fileId in email.yj_fj.Split('|'))
                {
                    if (fileId == "")
                        continue;
                    var file = (from f in filesDB.wjgl_files
                                where f.file_id == fileId
                                select f).First();
                    files.Add(file);
                }
                yjmxWithFilesEntity.Files = files;
                yjmxWithFilesEntites.Add(yjmxWithFilesEntity);
            }
            return yjmxWithFilesEntites;
        }

        public yjgl_yjmx GetEmailById(string id)
        {
            var mail = (from m in yjmxDB.yjgl_yjmx
                        where m.yj_id == Convert.ToInt32(id)
                        select m).First();
            return mail;
        }
    }
}
