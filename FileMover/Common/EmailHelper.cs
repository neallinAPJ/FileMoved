using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FileMover
{
    /// <summary>
    /// 邮件发送帮助类
    /// </summary>
    public class EmailHelper
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailBody">邮件内容</param>
        public static void SendEmail(string mailBody)
        {
            var mail = new MailMessage();
            string[] recipients = ConfigurationManager.AppSettings["EmailRecipients"].Split(';');
            foreach (var item in recipients)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    mail.To.Add(item.Trim());
                }
            }
            mail.Subject = "Screen Saver Update Mail";
            mail.Body = mailBody;
            using (var smtp = new SmtpClient())
            {
                smtp.Send(mail);
            }
        }
    }
}
