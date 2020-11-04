using System;
using Presentation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace DomainModel
{
    public class EmailService : IEmailService
    {
        private readonly IEmail _model; // Модель данных
        private readonly IEmailRepository _repository; // Взаимодействие с БД

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

        public EmailService()
        {
            _model = new Email();
            _repository = new EmailRepository();
        }

        // Проверить файл на существование
        public bool IsFileExist(string fileName)
        {
            return File.Exists(fileName);
        }

        // Отправить письмо
        public void SendToEmail()
        {
            try
            {
                using (MailMessage message = new MailMessage(_model.SenderEmail, _model.RecipientEmail))
                {
                    message.Subject = _model.MailSubject;
                    message.Body = _model.MailBody;
                    message.IsBodyHtml = false;
                    message.Attachments.Add(new Attachment(_model.Attachment));

                    using (SmtpClient client = new SmtpClient(_model.SmtpServer, _model.SmtpPort))
                    {
                        client.EnableSsl = true;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;

                        client.Credentials = new NetworkCredential(_model.SenderEmail, _model.SenderPassword);
                        try
                        {
                            client.Send(message);
                            _model.DateTimeOfSendToEmail = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }

                _repository.AddEmailLog(_model); // Логгируем в бд
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Установить параметры письма
        public void SetMail(string subject, string body, string attach)
        {
            _model.MailSubject = subject;
            _model.MailBody = body;
            _model.Attachment = attach;
        }

        // Установить параметры получателя
        public void SetRecipient(string recipientEmail)
        {
            _model.RecipientEmail = recipientEmail;
        }

        // Установить параметры отправителя
        public void SetSender(string senderEmail, string senderPassword)
        {
            _model.SenderEmail = senderEmail;
            _model.SenderPassword = senderPassword;
        }

        // Установить параметры Smtp-сервера
        public void SetSmtp(string smtpServer, int smtpPort)
        {
            _model.SmtpServer = smtpServer;
            _model.SmtpPort = smtpPort;
        }
    }
}
