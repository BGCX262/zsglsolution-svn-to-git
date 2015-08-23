using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Common;
using MvcApplication.Entities;
using System.Transactions;
using System.IO;

namespace MvcApplication.DAO
{
    public class FloderDAO
    {
        UserFloderDataContext userFloderDB = new UserFloderDataContext();
        FilesDataContext filesDB = new FilesDataContext();

        /// <summary>
        /// 新建文件夹
        /// </summary>
        /// <param name="userId">用户ID（用来保存到数据库）</param>
        /// <param name="floderName">文件夹名称</param>
        /// <param name="filePath">新建文件夹路径</param>
        /// <returns></returns>
        public ArgsHelp AddNewFloder(int userId,string floderName,string filePath,string higherFloder)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                userfloder userfloder = new userfloder
                {
                    floder_name = floderName,
                    user_id = userId,
                    floder_higher = higherFloder
                };
                userFloderDB.userfloder.InsertOnSubmit(userfloder);
                userFloderDB.SubmitChanges();
                Directory.CreateDirectory(filePath);
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
        /// 文件移动到文件夹
        /// </summary>
        /// <param name="fileID">文件ID</param>
        /// <param name="filePath">文件夹所在路径</param>
        /// <returns></returns>
        public ArgsHelp MoveFileToNewFloder(string fileID, string floderName, string filePath, string file_Prefix)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                var file = (from f in filesDB.wjgl_files
                            where f.file_id == fileID
                            select f).First();
                FileInfo fi = new FileInfo(file_Prefix + file.file_path.Replace("/", "\\"));
                FileInfo fiPDF = new FileInfo(file_Prefix + file.file_path.Replace("/", "\\") + ".pdf");
                FileInfo fiSWF = new FileInfo(file_Prefix + file.file_path.Replace("/", "\\") + ".swf");
                string fileName = file.file_path.Split('/').Last();
                fi.MoveTo(filePath + "\\" + fileName);
                if (fiPDF.Exists == true)
                    fiPDF.MoveTo(filePath + "\\" + fileName + ".pdf");
                if (fiSWF.Exists == true)
                    fiSWF.MoveTo(filePath + "\\" + fileName + ".swf");
                file.floder_name = floderName;
                file.file_path = filePath + "\\" + fileName;
                filesDB.SubmitChanges();
                ah.flag = true;
            }
            catch (Exception e)
            {
                ah.flag = false;
            }
            return ah;
        }

        public ArgsHelp DeleteFloder(string floderName, string path)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
                else
                {
                    ah.flag = false;
                    ah.msg = "不存在文件夹！";
                }
                var floder = (from fd in userFloderDB.userfloder where fd.floder_name == floderName select fd).First();
                userFloderDB.userfloder.DeleteOnSubmit(floder);
                userFloderDB.SubmitChanges();
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
