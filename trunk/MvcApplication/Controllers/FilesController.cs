using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Entities;
using MvcApplication.Models;
using System.Web.Script.Serialization;
using MvcApplication.Common;
using MvcApplication.DAO;

namespace MvcApplication.Controllers
{
    public class FilesController : Controller
    {
        UserFloderDataContext userFloderDB = new UserFloderDataContext();
        FsyhGxFilesDataContext fsyhGxFilesDB = new FsyhGxFilesDataContext();
        FilesDataContext filesDB = new FilesDataContext();
        GxglDAO gxglDAO = new GxglDAO();
        FileDAO fileDAO = new FileDAO();
        //
        // GET: /Files/

        public ActionResult FileList(UserModel user,string floderName)
        {
            List<wjgl_files> files;
            bool canAddNewFloder = true;
            bool canDelFloder = true;
            if (floderName == "默认")
            {
                canDelFloder = false;
                floderName = "";
            }
            if (floderName == "共享")
            {
                canAddNewFloder = false;
                canDelFloder = false;
                files = new List<wjgl_files>();
                foreach (var file in user.ZyhGxFiles)
                    files.Add(file.FileInfo);
            }
            else
            {
                if (user.Files != null)
                {
                    files = (from f in user.Files where f.floder_name == (floderName == "" ? null : floderName) select f).ToList();
                }else
                    files = new List<wjgl_files>();
            }
            var floderInfo = (from fd in userFloderDB.userfloder where fd.floder_name == floderName select fd).ToList();
            var fileListEntity = new FileListEntity
            {
                Files = files,
                CanAddNewFloder = canAddNewFloder,
                CanDelFolder = canDelFloder,
                FloderInfo = floderInfo.Count==0 ? new userfloder() : floderInfo.First()
            };
            return View(fileListEntity);
        }

        public ActionResult FsyhFileList(int fsyhId)
        {
            var files = (from f in fsyhGxFilesDB.gxgl_fsyhgxb
                         where f.fsyh_id == fsyhId
                         select f).ToList();
            List<FsyhGxFileEntity> fsyhFilesEntities = new List<FsyhGxFileEntity>();
            foreach (var file in files)
            {
                var fileInfo = (from fi in filesDB.wjgl_files
                                where fi.file_id == file.file_id
                                select fi).First();
                FsyhGxFileEntity fsyhFilesEntity = new FsyhGxFileEntity();
                fsyhFilesEntity.FileInfo = fileInfo;
                fsyhFilesEntities.Add(fsyhFilesEntity);
            }
            var model = new FsyhFileListModel
            {
                FsyhFilesEntities = fsyhFilesEntities
            };
            return View(model);
        }

        public ActionResult ShowFile(string filePath)
        {
            return JavaScript("showFile(" + new JavaScriptSerializer().Serialize(filePath) + ");");
        }

        public ActionResult ShowUnreadFile(string fileId)
        {
            var file = fileDAO.GetFileByID(fileId);
            gxglDAO.SetIsRead(fileId);
            return JavaScript("showFile(" + new JavaScriptSerializer().Serialize(file.file_path) + ");");
        }

        public ActionResult GxFileList(UserModel user)
        {
            var gxFileModel = new GxFilesModel
            {
                ZyhGxFiles = user.ZyhGxFiles
            };
            return View(gxFileModel);
        }

        public ActionResult DelFile(string fileId)
        {
            ArgsHelp ah = new ArgsHelp();
            try 
            {
                ah = fileDAO.DelFile(fileId);
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            if (ah.flag)
                return JavaScript("alert('删除成功！');refresh();");
            else
                return JavaScript("alert('删除失败！" + ah.msg + "');"); 
        }


    }
}
