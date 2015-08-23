using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Entities;
using System.Xml.Linq;
using MvcApplication.Common;
using System.IO;

namespace MvcApplication.DAO
{
    public class FileDAO
    {
        FilesDataContext filesDB = new FilesDataContext();
        wjnrDataContext wjnrDB = new wjnrDataContext();
        LsbhDataContext lsbhDB = new LsbhDataContext();
        ZyhGxFilesDataContext zyhGxFilesDB = new ZyhGxFilesDataContext();
        FsyhGxFilesDataContext fsyhGxFilesDB = new FsyhGxFilesDataContext();
        public void AddNewFile(wjgl_files fileEntity)
        {
            filesDB.wjgl_files.InsertOnSubmit(fileEntity);
            filesDB.SubmitChanges();
        }

        public void AddFileNr(wjgl_wjnrjs wjnrEntity)
        {
            wjnrDB.wjgl_wjnrjs.InsertOnSubmit(wjnrEntity);
            wjnrDB.SubmitChanges();
        }

        public string GetFileId(string lsName)
        {
            string lsbh = string.Empty;
            var code = (from c in lsbhDB.lsgl_lsbh
                        where c.lsbh_name == lsName
                        select c).First();
            lsbh = code.lsbh_code;
            code.lsbh_beforetime = code.lsbh_lasttime;
            code.lsbh_lasttime = DateTime.Now.ToString("yyyy-MM-dd");
            code.lsbh_code = (Convert.ToInt32(code.lsbh_code) + 1).ToString();
            lsbhDB.SubmitChanges();
            return lsbh;
        }

        public wjgl_files GetFileByID(string fileID)
        {
            var file = (from f in filesDB.wjgl_files
                        where f.file_id == fileID
                        select f).First();
            return file;
        }

        public ArgsHelp DelFile(string fileId)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                var file = (from f in filesDB.wjgl_files
                            where f.file_id == fileId
                            select f).First();
                string[] pathInfos = file.file_path.Split('\\');
                string[] idInfos = file.file_id.Split('-');
                string path = BulidFilePath(pathInfos, idInfos,file.file_name.Split('.').Last());
                var zyhGx = (from zg in zyhGxFilesDB.gxgl_zyhgx
                             where zg.file_id == fileId
                             select zg).ToList();
                zyhGxFilesDB.gxgl_zyhgx.DeleteAllOnSubmit(zyhGx);
                var fsyhGx = (from fg in fsyhGxFilesDB.gxgl_fsyhgxb
                              where fg.file_id == fileId
                              select fg).ToList();
                fsyhGxFilesDB.gxgl_fsyhgxb.DeleteAllOnSubmit(fsyhGx);
                fsyhGxFilesDB.SubmitChanges();
                zyhGxFilesDB.SubmitChanges();
                if (File.Exists(file.file_path))
                {
                    File.Delete(file.file_path);
                    if (File.Exists(path + ".swf"))
                        File.Delete(path + ".swf");
                    if (File.Exists(path + ".pdf"))
                        File.Delete(path + ".pdf");
                }
                else
                {
                    throw new Exception("没有找到文件");
                }
                var lsbh=(from c in lsbhDB.lsgl_lsbh
                        where c.lsbh_name == "文件上传"
                        select c).First();
                lsbh.lsbh_lasttime = lsbh.lsbh_beforetime;
                lsbh.lsbh_code = (Convert.ToInt32(lsbh.lsbh_code) - 1).ToString();
                lsbhDB.SubmitChanges();
                filesDB.wjgl_files.DeleteOnSubmit(file);
                filesDB.SubmitChanges();
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            return ah;
        }

        public string BulidFilePath(string[] pathInfos,string[] idInfos,string ext)
        {
            string path = string.Empty;
            for (int i = 0; i < pathInfos.Length - 1; i++)
            {
                path += pathInfos[i] + "\\";
                if (i == pathInfos.Length - 2)
                {
                    for (int j = 1; j < idInfos.Length; j++)
                    {
                        if (j != idInfos.Length - 1)
                            path += idInfos[j] + "-";
                        else
                            path += idInfos[j] + "." + ext;
                    }
                }
            }
            return path;
        }
    }
}
