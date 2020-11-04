using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation
{
    public interface IView
    {
        void Show();
        DialogResult ShowDialog();
        void Close();
    }

    public interface IMainView : IView
    {
        event Action OpenTemplateFile;                              // Пользователь пытается выбрать шаблон
        event Action TemplateSelected;                              // Пользователь выбрал шаблон ПФ
        event Action PrintFormSave;                                 // Пользователь пытается сохранить ПФ
        event Action SendToEmail;                                   // Пользователь пытается отправить файл по эл. почте
        event Action ToPrintForm;                                   // Пользователь пытается отправить файл на печать
        event Action SelectedFieldValueSave;                        // Пользователь пытается сохранить значение выбранного поля
        event Action SelectedFieldChanged;                          // Пользователь выбрал другое поле шаблона

        string TemplatePath { get; set; }                           // Путь к выбранному шаблону ПФ
        string SelectedField { get; }                               // Выбранное поле шаблона
        string SelectedFieldValue { get; set; }                     // Значение выбранного поля шаблона ПФ
        string PrintFormPath { get; }                               // Имя файла заполненной ПФ

        string GetTemplateFileName();                               // Диалог выбора файла шаблона
        void SetFieldListDataSource(List<string> fieldList);        // Указать источник данных для списка полей шаблона ПФ
        void ShowInformation(string infoMessage);                   // Информационные сообщения
        void ShowError(string errorMessage);                        // Сообщение об ошибках
        void EnableSendingAndPrinting();                            // Разрешить отправку по почте и печать ПФ
        void DisableSendingAndPrinting();                           // Запретить отправку по почте и печать ПФ

        IEmailView GetEmailView();
        IEmailService GetEmailService();
    }

    public interface IPresenter
    {
        void Run();
    }

    public interface IMainService
    {
        List<string> FieldList { get; }                             // Список полей шаблона
        string SavedPrintFormFullPath { get; }                      // Путь к сохраненной форме

        bool FieldListContainsName(string name);                    // Проверить, содержится ли указанное поле в списке
        bool IsFileExist(string fileName);                          // Проверить указанный файл на существование
        string GetFieldValue(string selectedFieldName);             // Получить значение для указанного поля
        void OpenTemplate(string filePath);                         // Открыть шаблон по указанному пути
        void SetFieldValue(string fieldName, string fieldValue);    // Установить значение для указанного поля
        void SavePrintForm(string printFormPath);                   // Попытаться сохранить файл по указанному пути
        void ToPrintForm();                                         // Отправить файл на печать
    }

    public interface IMainRepository
    {
        void AddPrintFormLog(IPrintForm printForm);                 // Добавить лог печатной формы в базу
        void UpdatePrintFormLog(IPrintForm printForm);              // Обновить лог печатной формы в базу (для добавления времени печати)
    }

    public interface IPrintForm
    {
        int Id { get; set; }
        string DateTimeOfSaveForm { get; set; }
        string DateTimeOfSendToPrint { get; set; }
        string TemplateFilePath { get; set; }
        string SavedPrintFormFullPath { get; set; }
    }

    public interface IEmailView : IView
    {
        event Action SendToEmail;                                   // Пользователь пытается отправить файл по эл. почте

        string SenderEmail { get; }                                 // Email отправителя
        string SenderPassword { get; }                              // Пароль от Email'а отправителя
        string RecipientEmail { get; }                              // Email получателя
        string MailSubject { get; }                                 // Тема письма
        string MailBody { get; }                                    // Сообщение
        string SmtpServer { get; }                                  // Smtp-сервер
        int? SmtpPort { get; }                                      // Порт для подключения к Smtp-серверу

        void SetAttachmentFilePath(string filePath);                // Указать путь к вложению
        void SetSmtpDictionary(Dictionary<string, int> dicSmtp);    // Указать источник данных для списка smtp-серверов
        void ShowInformation(string infoMessage);                   // Информационные сообщения
        void ShowError(string errorMessage);                        // Сообщение об ошибках
    }

    public interface IEmailService
    {
        Dictionary<string, int> SmtpDic { get; }                    // Словарь Smtp-сервер-порт

        bool IsFileExist(string fileName);                          // Проверить, существует ли файл
        void SendToEmail();                                         // Отправить письмо

        void SetMail(string subject, string body, string attach);   // Установить параметры письма
        void SetSmtp(string smtpServer, int smtpPort);              // Установить параметры Smtp-сервера
        void SetSender(string senderEmail, string senderPassword);  // Установить параметры отправителя
        void SetRecipient(string recipientEmail);                   // Установить параметры получателя
    }

    public interface IEmailRepository
    {
        void AddEmailLog(IEmail email);                        // Добавить лог отправки Email в базу
    }

    public interface IEmail // Модель данных
    {
        int Id { get; set; }
        string SenderEmail { get; set; }
        string SenderPassword { get; set; }
        string RecipientEmail { get; set; }
        string MailSubject { get; set; }
        string MailBody { get; set; }
        string Attachment { get; set; }
        string SmtpServer { get; set; }
        int SmtpPort { get; set; }
        string DateTimeOfSendToEmail { get; set; }
    }
}
