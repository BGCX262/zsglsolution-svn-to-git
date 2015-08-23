using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;
using MvcApplication.Entities;
using MvcApplication.DAO;
using MvcApplication.Common;

namespace MvcApplication.Controllers
{
    public class GxglController : Controller
    {
        //
        // GET: /Gxgl/
        UserDataContext userDB = new UserDataContext();
        FilesDataContext filesDB = new FilesDataContext();
        FsyhDataContext fsyhDB = new FsyhDataContext();
        ZyhGxFilesDataContext zyhGxFilesDB = new ZyhGxFilesDataContext();
        FsyhGxFilesDataContext fsyhGxFilesDB = new FsyhGxFilesDataContext();
        GxglDAO gxglDAO = new GxglDAO();
        YhglDAO yhglDAO = new YhglDAO();

        public ActionResult SetGxPartial()
        {
            return View();
        }

        public ActionResult SetGx(UserModel user)
        {
            List<string> userList = new List<string>();
            List<string> fileList = new List<string>();
            List<string> fsyhList = new List<string>();
            GxEntity gxEntity = new GxEntity();
            try
            {
                if (Request.Form["filesGx"] == null)
                {
                    throw new Exception("没有选择要共享的文件！");
                }
                if (Request.Form["usersGx"] == null && Request.Form["fsyhsGx"] == null)
                {
                    throw new Exception("没有选择要共享的用户！");    
                }
                var files = Request.Form["filesGx"];
                var users = Request.Form["usersGx"] == null ? string.Empty : Request.Form["usersGx"];
                var fsyhs = Request.Form["fsyhsGx"] == null ? string.Empty : Request.Form["fsyhsGx"];
                if (users != "")
                {
                    foreach (var userInfo in users.Split(','))
                        userList.Add(userInfo);
                }
                
                foreach (var fileInfo in files.Split(','))
                    fileList.Add(fileInfo);
                if (fsyhs != "")
                {
                    foreach (var fsyhInfo in fsyhs.Split(','))
                        fsyhList.Add(fsyhInfo);
                }
                gxEntity.UserList = userList;
                gxEntity.FileList = fileList;
                gxEntity.FsyhList = fsyhList;
                gxglDAO.AddGx(gxEntity, user.UserInfo.user_id);
                return JavaScript("alert('设置成功！')");
            }
            catch (Exception e)
            {
                return JavaScript("alert('" + e.Message + "')");
            }
        }

        public ActionResult GxFiles_ToOthers(UserModel user)
        {
            var zyhFiles = (from zf in zyhGxFilesDB.gxgl_zyhgx
                         where zf.gx_ly == user.UserInfo.user_id
                         select zf).ToList();
            var fsyhFiles = (from ff in fsyhGxFilesDB.gxgl_fsyhgxb
                             where ff.fsyhgx_ly == user.UserInfo.user_id
                             select ff).ToList();
            var model = BuildModel(zyhFiles, fsyhFiles);
            return View(model);

        }

        Files_ShareToOthersModel BuildModel(List<gxgl_zyhgx> zyhFiles, List<gxgl_fsyhgxb> fsyhFiles)
        {
            List<Files_ShareToZyhEntity> files_ShareToZyhEntities = new List<Files_ShareToZyhEntity>();
            List<Files_ShareToFsyhEntity> files_ShareToFsyhEntities = new List<Files_ShareToFsyhEntity>();
            foreach (var zyhFile in zyhFiles)
            {
                var zyhName = (from u in userDB.yhgl_users
                               where u.user_id == zyhFile.user_id
                               select u.user_name).First();
                var fileName = (from f in filesDB.wjgl_files
                                where f.file_id == zyhFile.file_id
                                select f.file_name).First();
                Files_ShareToZyhEntity files_ShareToZyhEntity = new Files_ShareToZyhEntity
                {
                    File_ShareToZyh = zyhFile,
                    ZyhName = zyhName,
                    FileName = fileName
                };
                files_ShareToZyhEntities.Add(files_ShareToZyhEntity);
            }
            foreach (var fsyhFile in fsyhFiles)
            {
                var fsyhName = (from fs in fsyhDB.yhgl_fsyh
                                where fs.fsyh_id == fsyhFile.fsyh_id
                                select fs.fsyh_name).First();
                var fileName = (from f in filesDB.wjgl_files
                                where f.file_id == fsyhFile.file_id
                                select f.file_name).First();
                Files_ShareToFsyhEntity files_ShareToFsyhEntity = new Files_ShareToFsyhEntity
                {
                    File_ShareToFsyh = fsyhFile,
                    FsyhName = fsyhName,
                    FileName = fileName
                };
                files_ShareToFsyhEntities.Add(files_ShareToFsyhEntity);
            }
            var files_ShareToOthersModel = new Files_ShareToOthersModel
            {
                Files_ShareToFsyhEntities = files_ShareToFsyhEntities,
                Files_ShareToZyhEntities = files_ShareToZyhEntities
            };
            return files_ShareToOthersModel;
        }

        public ActionResult CancelGx(string gxId,string userType)
        {
            ArgsHelp ah = gxglDAO.CancelGx(gxId, userType);
            if (ah.flag)
                return JavaScript("alert('共享已取消！');refresh();");
            else
                return JavaScript("alert('失败：" + ah.msg + "')");
        }
        

    }
}
