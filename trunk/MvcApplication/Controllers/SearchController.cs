using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;
using MvcApplication.Entities;

namespace MvcApplication.Controllers
{
    public class SearchController : Controller
    {
        FilesDataContext filesDB = new FilesDataContext();
        wjnrDataContext wjnrDB = new wjnrDataContext();

        //
        // GET: /Search/

        public ActionResult ContentSearch()
        {
            return View();
        }

        public ActionResult RemarkSearch()
        {
            return View();
        }

        public string SearchResult(string searchKind,UserModel user)
        {
            string content=Request.Form["Content"];
            string HTMLStr = "<p>检索到的文件名称为：</p>";
            List<wjgl_files> files = new List<wjgl_files>();
            if (searchKind == "全文检索")
            {
                var wjnrs = (from c in wjnrDB.wjgl_wjnrjs
                             where c.file_nr.Contains(content)
                             select c.file_id).Distinct().ToList();
                foreach (var wjnr in wjnrs)
                {
                    var file = (from f in filesDB.wjgl_files
                                where f.file_id == wjnr
                                select f).First();
                    files.Add(file);
                }
            }
            else 
            {
                files = (from f in filesDB.wjgl_files
                            where (f.file_name.Contains(content) || f.file_bz.Contains(content))
                            where f.user_id == user.UserInfo.user_id
                            select f).ToList();
            }
            foreach (var file in files)
                HTMLStr += BulidHTML(file.file_id, file.file_name);
            HTMLStr += "<p>你可以在左边的文件列表中点击查看。</p>";
            return HTMLStr;
            
        }

        string BulidHTML(string fileId,string fileName)
        {
            string HTMLStr = "<p>" + fileName + "</p>";
            return HTMLStr;
        }
    }
}
