using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace MvcApplication.Controllers
{
    public class ShowFileController : Controller
    {
        //
        // GET: /ShowFile/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowFilePartial(string filePath)
        {
            string fullPath = Request.MapPath("/UploadFiles/") + filePath.Replace("/", "\\");
            string pdfFileName = string.Empty;
            if (filePath.Split('.').Last() == "pdf" || GlobalVar.ImgExtension.Contains(filePath.Split('.').Last()))
                pdfFileName = Request.MapPath("/UploadFiles/") + filePath.Replace("/", "\\");
            else
                pdfFileName = Request.MapPath("/UploadFiles/") + filePath.Replace("/","\\") + ".pdf";
            string swfFileName = Request.MapPath("/UploadFiles/") + filePath.Replace("/", "\\") + ".swf";
            string fileName = "../../UploadFiles/" + filePath + ".swf";
            if (GlobalVar.ImgExtension.Contains(filePath.Split('.').Last()))
            {
                if (!System.IO.File.Exists(swfFileName))
                {
                    if (Img2Swf(fullPath, fullPath.Split('.').Last()))
                    {
                        ViewData["path"] = fileName;
                    }
                    else
                    {
                        ViewData["path"] = "失败!";
                    }
                }
                else
                {
                    ViewData["path"] = fileName;
                }
            }
            else
            {
                if (!System.IO.File.Exists(swfFileName))
                {
                    if (Doc2Swf(Request.MapPath("/SWFTools/pdf2swf.exe"), pdfFileName, swfFileName))
                    {
                        ViewData["path"] = fileName;
                    }
                    else
                    {
                        ViewData["path"] = "失败!";
                    }
                }
                else
                {
                    ViewData["path"] = fileName;
                }
            }
            return View();
        }

        private static Boolean Doc2Swf(string appPath, string source, string des)
        {
            var pc = new Process();
            var psi = new ProcessStartInfo(appPath, source + " -o " + des+" -T 9");
            try
            {
                pc.StartInfo = psi;
                pc.Start();
                pc.WaitForExit();
            }
            catch(Exception e)
            {
                return false;
            }
            finally
            {
                pc.Close();
            }
            return System.IO.File.Exists(des);
        }

        private Boolean Img2Swf(string appPath,string ext)
        {
            if (ext == GlobalVar.ImgExtension[0])
                return Doc2Swf(Request.MapPath("/SWFTools/jpeg2swf.exe"), appPath, appPath + ".swf");
            if(ext==GlobalVar.ImgExtension[1])
                return Doc2Swf(Request.MapPath("/SWFTools/png2swf.exe"), appPath, appPath + ".swf");
            else
                return Doc2Swf(Request.MapPath("/SWFTools/gif2swf.exe"), appPath, appPath + ".swf");
        }

    }
}
