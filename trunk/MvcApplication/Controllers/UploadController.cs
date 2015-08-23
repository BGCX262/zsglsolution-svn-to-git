using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MvcApplication.Models;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using Xlsx = Microsoft.Office.Interop.Excel;
using PPT = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using System.Xml.Linq;
using MvcApplication.Entities;
using MvcApplication.DAO;
using System.Threading;

namespace MvcApplication.Controllers
{

    delegate void SaveFileDelegate(HttpPostedFileBase postedFile, string fileName, string ext, UserModel user);
    delegate void SaveNrDelegate(string fileId, string filePath, string ext);
    public class UploadController : Controller
    {

        FilesDataContext filesDB = new FilesDataContext();
        wjnrDataContext wjnrDB = new wjnrDataContext();
        UserDataContext userDB = new UserDataContext();
        FileDAO fileDAO = new FileDAO();
        string fileID = string.Empty;
        //
        // GET: /Upload/

        public ActionResult UploadPartial(UserModel user)
        {
            return View(user);
        }

        /// <summary>
        /// 上传并保存
        /// </summary>
        /// <param name="fileData">需上传的文件</param>
        /// <param name="folder">保存地址</param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ContentResult UploadAndSave(HttpPostedFileBase fileData, string folder, string bz, string userId)
        {
            string result = "";
            if (null != fileData)
            {
                try
                {
                    var userModel = new UserModel
                    {
                        UserInfo = (from u in userDB.yhgl_users
                                where u.user_id == Convert.ToInt32(userId)
                                select u).First()
                    };
                    result = Path.GetFileName(fileData.FileName);//获得文件名
                    string ext = Path.GetExtension(fileData.FileName);//获得文件扩展名
                    string saveName = result;//实际保存文件名
                    string fileUpTime = DateTime.Now.ToString("yyyy-MM-dd")
                        + "-" + fileDAO.GetFileId("文件上传");
                    fileID = "文件上传-" + fileUpTime;
                    string fileName = fileUpTime + ext;
                    string path = userModel.UserInfo.user_id + "/" + fileUpTime + ext;
                    Save2SQL(fileData, saveName, path, ext, bz, userModel);//保存到数据库
                    SaveFile(fileData, fileName, ext, userModel);//保存文件
                }
                catch(Exception e)
                {
                    result = "";
                }
            }
            return Content(result);
        }

        /// <summary>
        /// 保存文件到数据库
        /// </summary>
        private void Save2SQL(HttpPostedFileBase postedFile, 
            string fileName,string path, string ext, string bz,UserModel user)
        {
            var file = new wjgl_files
            {
                file_id = fileID,
                file_name = fileName,
                file_path = path,
                file_scsj = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                file_bz = bz,
                user_id = user.UserInfo.user_id
            };
            fileDAO.AddNewFile(file);
            SaveWjnr(fileID, path, ext);
        }

        /// <summary>
        /// 保存文件内容到数据库
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ext"></param>
        private void SaveWjnr(string fileId,string filePath,string ext)
        {
            try
            {
                List<string> wjnrs = new List<string>();
                if (GlobalVar.WordExtension.Contains(ext))
                    wjnrs = FileCommonOperations.GetWordContent(filePath);
                if (GlobalVar.ExcelExtension.Contains(ext))
                    wjnrs = FileCommonOperations.GetExcelContent(filePath);
                if (GlobalVar.PPTExtension.Contains(ext))
                    wjnrs = FileCommonOperations.GetPPTContent(filePath);
                else
                { 
                    return; 
                }
                foreach (string wjnr in wjnrs)
                {
                    var wjnrEntity = new wjgl_wjnrjs
                    {
                        file_id = fileId,
                        file_nr = wjnr
                    };
                    fileDAO.AddFileNr(wjnrEntity);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 保存文件原本
        /// </summary>
        /// <param name="postedFile"></param>
        /// <param name="filepath">文件路径</param>
        /// <param name="saveName">文件名</param>
        /// <param name="ext">文件后缀名</param>
        private void SaveFile(HttpPostedFileBase postedFile, string fileName,string ext,UserModel user)
        {
            string filepath = Request.MapPath("/UploadFiles/" + user.UserInfo.user_id + "/");
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            try
            {
                postedFile.SaveAs(filepath + fileName);
                Conversion(filepath + fileName, ext);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        /// <summary>
        /// 将文件转换为PDF，并保存
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="ext"></param>
        private void Conversion(string fileName,string ext)
        {
            if (GlobalVar.WordExtension.Contains(ext))
                FileCommonOperations.Word2Pdf(fileName);
            if (GlobalVar.ExcelExtension.Contains(ext))
                FileCommonOperations.Excel2Pdf(fileName);
            if (GlobalVar.PPTExtension.Contains(ext))
                FileCommonOperations.PPT2Pdf(fileName);
        }

        /// <summary>
        /// 上传头像
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadAvatar(UserModel user)
        {
            return View(user);
        }

        AvatarDAO avatarDAO = new AvatarDAO();
        public ActionResult UploadImage(HttpPostedFileBase fileData, string folder, string userId)
        {
            string result = string.Empty;
            if (null != fileData)
            {
                try
                {
                    var user = (from u in userDB.yhgl_users
                                where u.user_id == Convert.ToInt32(userId)
                                select u).First();
                    string ext = Path.GetExtension(fileData.FileName);//获得文件扩展名
                    string saveName = result;//实际保存文件名
                    string fileUpTime = DateTime.Now.ToString("yyyy-MM-dd")
                        + "-" + fileDAO.GetFileId("头像上传");
                    string fileName = fileUpTime + ext;
                    result = Path.GetFileName(fileData.FileName) + "|" + "../../Avatar/" + fileName; ;//获得文件名
                    SaveAvatar(fileData, fileName,user==null?"":user.user_avatar);//保存文件
                    avatarDAO.ChangeAvatar("../../Avatar/" + fileName, user.user_id);
                }
                catch (Exception e)
                {
                    result = "";
                }
            }
            return Content(result);
        }

        void SaveAvatar(HttpPostedFileBase postedFile, string fileName,string oldPath)
        {
            string filepath = Request.MapPath("/Avatar/");
            GlobalVar.AvatarPath = "../../Avatar/" + fileName;
            if (oldPath != "")
                avatarDAO.DelAvatar(Request.MapPath("/Avatar/") + oldPath.Split('/').Last());
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            try
            {
                postedFile.SaveAs(filepath + fileName);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }


    }
}
