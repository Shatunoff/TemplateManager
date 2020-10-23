using System;
using Presentation;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace DomainModel
{
    class EmailModel : IEmailModel
    {
        private Dictionary<string, int> smtpDic = new Dictionary<string, int>()
        {
            {"smtp.yandex.ru",  25 },
            {"smtp.mail.ru",    465 },
            {"smtp.gmail.com",  465 }
        };

        public Dictionary<string, int> SmtpDic
        {
            get { return smtpDic; }
        }

        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }
        public string RecipientEmail { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }
        public string Attachment { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }

        public void SendToEmail()
        {
            using (MailMessage message = new MailMessage(SenderEmail, RecipientEmail))
            {
                message.Subject = MailSubject;
                message.Body = MailBody;
                message.IsBodyHtml = false;
                message.Attachments.Add(new Attachment(Attachment));

                using (SmtpClient client = new SmtpClient(SmtpServer, SmtpPort))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;

                    client.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public bool IsFileExist(string fileName)
        {
            return File.Exists(fileName);
        }
    }
}