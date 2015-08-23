using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace MvcApplication
{
    public class GlobalVar
    {
        /// <summary>
        /// word后缀名
        /// </summary>
        public static readonly List<string> WordExtension
            = new List<string>() { ".doc", ".docx" };

        /// <summary>
        /// excel后缀名
        /// </summary>
        public static readonly List<string> ExcelExtension
            = new List<string>() { ".xls", ".xlsx" };

        /// <summary>
        /// ppt后缀名
        /// </summary>
        public static readonly List<string> PPTExtension
            = new List<string>() { ".ppt", ".pptx" };

        /// <summary>
        /// 图片后缀名
        /// </summary>
        public static readonly List<string> ImgExtension
            = new List<string>() { "jpg", "png", "gif" };

        public static MailMessage message = new MailMessage();
        public static List<string> AttachmentID = new List<string>();


        public static string AvatarPath = string.Empty;
        public static string DefaultAvatar = "../../Avatar/default.jpg";
    }
}
