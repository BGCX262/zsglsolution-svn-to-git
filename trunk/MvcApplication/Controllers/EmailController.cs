using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net.Mime;
using System.Web.Script.Serialization;
using MvcApplication.Entities;
using MvcApplication.DAO;
using MvcApplication.Common;

namespace MvcApplication.Controllers
{
    public class EmailController : Controller
    {
        //
        // GET: /Emali/
        EmailglDAO emailglDAO = new EmailglDAO();
        FileDAO fileDAO = new FileDAO();
        /// <summary>
        /// 发送邮件（view）
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult Index(UserModel user)
        {
            return View(user);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult Send(UserModel user)
        {
            string receiver = Request.Form["receiver"];
            string sender = Request.Form["sender"];
            string content = Request.Form["content"];
            string psw = Request.Form["psw"];
            string topic = Request.Form["topic"];
            if (!CommonOper.email_hftz(receiver))
                return JavaScript("Failed('不正确的邮件格式');");
            ArgsHelp ah = SendMail(receiver, user.UserInfo.user_name, receiver, topic, content, psw,user.UserInfo.user_id);
            if (ah.flag)
                return JavaScript("Successed();");
            else
                return JavaScript("Failed('" + ah.msg + "');");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="senderName"></param>
        /// <param name="receiver"></param>
        /// <param name="topic"></param>
        /// <param name="content"></param>
        /// <param name="psw"></param>
        /// <returns></returns>
        public ArgsHelp SendMail(string sender, string senderName, string receiver, string topic, string content, string psw,int userID)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                GlobalVar.message.From = new MailAddress(sender, senderName);//必须是提供smtp服务的邮件服务器
                GlobalVar.message.To.Clear();//清空以前的收件人
                GlobalVar.message.To.Add(new MailAddress(receiver));  //收件人
                GlobalVar.message.Subject = topic;
                GlobalVar.message.IsBodyHtml = true;
                GlobalVar.message.BodyEncoding = System.Text.Encoding.UTF8;
                GlobalVar.message.Body = content;
                GlobalVar.message.Priority = System.Net.Mail.MailPriority.High;
                SmtpClient client = new SmtpClient("mail.skywalk.cn", 25); // 587;//Gmail使用的端口
                client.Credentials = new System.Net.NetworkCredential(sender, psw); //这里是申请的邮箱和密码
                client.EnableSsl = false; //必须经过ssl加密 
                string fj = string.Empty;
                client.Send(GlobalVar.message);
                foreach (var id in GlobalVar.AttachmentID)
                {
                    fj += id + "|";
                }
                yjgl_yjmx yjmx = new yjgl_yjmx
                {
                    user_id = userID,
                    yj_fssj = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                    yj_nr = content,
                    yj_zt = topic,
                    yj_sjr = receiver,
                    yj_fj = fj
                };
                emailglDAO.SaveEmailInfo(yjmx);
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            return ah;
        }


        /// <summary>
        /// 添加附件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="fileID"></param>
        /// <returns></returns>
        public ActionResult AddAccessories(string filePath,string fileName,string fileID)
        {
            string script = string.Empty;
            ArgsHelp ah = AddAccessoriesNoJs(filePath, fileName, fileID);
            if (!ah.flag)
            {
                if (ah.msg == "已经存在")
                    script = "alert('附件已经存在！');cancelNotRefresh('EmailAttachment');";
                else
                    script = "alert('错误！" + ah.msg + "');";
            }
            else
            {
                script = string.Format("FileClick({0}, {1});cancelNotRefresh('EmailAttachment');",
                    new JavaScriptSerializer().Serialize(fileID),
                    new JavaScriptSerializer().Serialize(fileName));
            }
            return JavaScript(script);
        }

        public ActionResult RemoveAccessories(string fileId) {
            try
            {
                GlobalVar.AttachmentID.Remove(fileId);
                var file = fileDAO.GetFileByID(fileId);
                foreach (var attachment in GlobalVar.message.Attachments)
                {
                    if (attachment.Name == file.file_path.Split('\\').Last())
                    {
                        GlobalVar.message.Attachments.Remove(attachment);
                        break;
                    }
                }
                
            }
            catch (Exception e)
            {
                return JavaScript("alert('" + e.Message + "');");
            }
            return null;
        }

        public ArgsHelp AddAccessoriesNoJs(string filePath, string fileName, string fileID)
        {
            ArgsHelp ah = new ArgsHelp();
            try
            {
                GlobalVar.AttachmentID.Clear();
                // Create  the file attachment for this e-mail message.
                Attachment data = new Attachment(filePath, MediaTypeNames.Application.Octet);//(ofd.FileName, MediaTypeNames.Application.Octet);
                // Add time stamp information for the file.
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(filePath);// (ofd.FileName);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(filePath);// (ofd.FileName);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(filePath);// (ofd.FileName);
                // Add the file attachment to this e-mail message.
                if (GlobalVar.AttachmentID.Contains(fileID))
                    throw new Exception("已经存在");
                else
                {
                    GlobalVar.AttachmentID.Add(fileID);
                    GlobalVar.message.Attachments.Add(data);
                }
            }
            catch (Exception e)
            {
                ah.flag = false;
                ah.msg = e.Message;
            }
            return ah;
        }


        public ActionResult EmailsView(UserModel user) 
        {
            var model = new EmailWithFilesModel
            {
                YjmxWithFilesEntites = emailglDAO.GetAllEmails(user.UserInfo.user_id)
            };
            return View(model);
        }

        public ActionResult ForwardEmail(string emailId, string receiver,string psw, UserModel user)
        {
            FileDAO fileDAO = new FileDAO();
            var email = emailglDAO.GetEmailById(emailId);
            if (!CommonOper.email_hftz(receiver))
                return JavaScript("ForwardFailed('错误的邮箱格式');");
            foreach (var fileID in email.yj_fj.Split('|'))
            {
                if (fileID == "")
                    continue;
                var file = fileDAO.GetFileByID(fileID);
                ArgsHelp ah2 = AddAccessoriesNoJs(file.file_path, file.file_name, file.file_id);
                if (!ah2.flag)
                    return JavaScript("ForwardFailed('附件添加错误:" + ah2.msg + "');");
            }
            ArgsHelp ah = SendMail(user.UserInfo.user_email, user.UserInfo.user_name, receiver, email.yj_zt, email.yj_nr, psw, user.UserInfo.user_id);
            if (ah.flag)
                return JavaScript("ForwardSuccessed();");
            else
                return JavaScript("ForwardFailed('" + ah.msg + "');");
        }

    }
}
