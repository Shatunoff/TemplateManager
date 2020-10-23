using System;
using Presentation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class EmailService : IEmailService
    {
        private readonly IEmailModel _model; // Модель данных

        public Dictionary<string, int> SmtpDic
        {
            get { return _model.SmtpDic; }
        }

        public EmailService()
        {
            _model = new EmailModel();
        }

        // Проверить файл на существование
        public bool IsFileExist(string fileName)
        {
            return _model.IsFileExist(fileName);
        }

        // Отправить письмо
        public void SendToEmail()
        {
            try
            {
                _model.SendToEmail();
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
