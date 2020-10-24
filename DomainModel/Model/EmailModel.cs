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
    public class EmailModel : IEmailModel
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

        public IEmail Model { get; set; }

        public EmailModel()
        {
            Model = new Email();
        }

        public void SendToEmail()
        {
            using (MailMessage message = new MailMessage(Model.SenderEmail, Model.RecipientEmail))
            {
                message.Subject = Model.MailSubject;
                message.Body = Model.MailBody;
                message.IsBodyHtml = false;
                message.Attachments.Add(new Attachment(Model.Attachment));

                using (SmtpClient client = new SmtpClient(Model.SmtpServer, Model.SmtpPort))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;

                    client.Credentials = new NetworkCredential(Model.SenderEmail, Model.SenderPassword);
                    try
                    {
                        client.Send(message);
                        Model.DateTimeOfSendToEmail = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
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