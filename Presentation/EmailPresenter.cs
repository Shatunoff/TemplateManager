using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class EmailPresenter : IPresenter
    {
        private readonly IEmailView _view;
        private readonly IEmailService _service;
        private readonly string attachment;

        public EmailPresenter(IEmailView view, IEmailService service, string attachPath)
        {
            _view = view;
            _service = service;

            attachment = attachPath;
            _view.SetAttachmentFilePath(attachment);
            _view.SetSmtpDictionary(_service.SmtpDic);
            _view.SendToEmail += () => SendToEmail();
        }

        public void Run()
        {
            _view.ShowDialog();
        }

        // Отправить письмо
        public void SendToEmail()
        {
            // Проверить поля на заполнение
            if (_view.SenderEmail == null) _view.ShowInformation("Укажите Email отправителя");
            if (_view.SenderPassword == null) _view.ShowInformation("Укажите пароль от почты отправителя");
            if (_view.RecipientEmail == null) _view.ShowInformation("Укажите Email получателя");
            if (_view.MailSubject == null) _view.ShowInformation("Укажите тему письма");
            if (_view.MailBody == null) _view.ShowInformation("Укажите сообщение");
            if (_view.SmtpServer == null) _view.ShowInformation("Укажите Smtp-сервер");
            if (_view.SmtpPort == null) _view.ShowInformation("Укажите порт для Smtp-сервера");
            if (attachment == null) _view.ShowError("Вложение не было передано");
            if (!_service.IsFileExist(attachment)) _view.ShowError("Файл вложения не найден по указанному пути");

            // Передать параметры в модель
            _service.SetSmtp(_view.SmtpServer, (int)_view.SmtpPort);
            _service.SetSender(_view.SenderEmail, _view.SenderPassword);
            _service.SetRecipient(_view.RecipientEmail);
            _service.SetMail(_view.MailSubject, _view.MailBody, attachment);

            try
            {
                // Отправить письмо
                _service.SendToEmail();
                _view.ShowInformation("Письмо было успешно отправлено");
            }
            catch (Exception ex)
            {
                // Отправка прошла неудачно
                _view.ShowError(ex.Message);
            }
        }
    }
}
