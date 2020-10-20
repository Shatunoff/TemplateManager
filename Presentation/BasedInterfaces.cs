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

    public interface IMainModel
    {
        List<string> FieldListAsList { get; }                       // Список полей шаблона
        string SavedPrintFormFullPath { get; }                      // Путь к сохраненной форме

        bool FieldListContainsName(string name);                    // Проверить, содержится ли указанное поле в списке
        bool IsFileExist(string fileName);                          // Проверить указанный файл на существование
        string GetFieldValue(string selectedFieldName);             // Получить значение для указанного поля
        void OpenTemplate(string filePath);                         // Открыть шаблон по указанному пути
        void SetFieldValue(string fieldName, string fieldValue);    // Установить значение для указанного поля
        void SaveTemplateToFile(string printFormPath);              // Сохранить файл по указанному пути
        void ToPrintForm();                                         // Отправить файл на печать
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

    public interface IEmailModel
    {
        Dictionary<string, int> SmtpDic { get; }                    // Словарь Smtp-сервер-порт

        string SenderEmail { get; set; }                            // Email отправителя
        string SenderPassword { get; set; }                         // Пароль от Email'а отправителя
        string RecipientEmail { get; set; }                         // Email получателя
        string MailSubject { get; set; }                            // Тема письма
        string MailBody { get; set; }                               // Сообщение
        string Attachment { get; set; }                             // Вложение
        string SmtpServer { get; set; }                             // Smtp-сервер
        int SmtpPort { get; set; }                                  // Порт для подключения к Smtp-серверу

        bool IsFileExist(string fileName);                          // Проверить, существует ли файл
        void SendToEmail();                                         // Отправить письмо
    }
}
