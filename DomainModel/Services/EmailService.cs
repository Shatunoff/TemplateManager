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
        private readonly IEmailRepository _repository; // Взаимодействие с БД

        public Dictionary<string, int> SmtpDic
        {
            get { return _model.SmtpDic; }
        }

        public EmailService()
        {
            _model = new EmailModel();
            _repository = new EmailRepository();
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
                _repository.AddEmailLog(_model.Model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Установить параметры письма
        public void SetMail(string subject, string body, string attach)
        {
            _model.Model.MailSubject = subject;
            _model.Model.MailBody = body;
            _model.Model.Attachment = attach;
        }

        // Установить параметры получателя
        public void SetRecipient(string recipientEmail)
        {
            _model.Model.RecipientEmail = recipientEmail;
        }

        // Установить параметры отправителя
        public void SetSender(string senderEmail, string senderPassword)
        {
            _model.Model.SenderEmail = senderEmail;
            _model.Model.SenderPassword = senderPassword;
        }

        // Установить параметры Smtp-сервера
        public void SetSmtp(string smtpServer, int smtpPort)
        {
            _model.Model.SmtpServer = smtpServer;
            _model.Model.SmtpPort = smtpPort;
        }
    }
}
