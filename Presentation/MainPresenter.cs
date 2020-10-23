using System;

namespace Presentation
{
    public class MainPresenter : IPresenter
    {
        private readonly IMainView _view;
        private readonly IMainService _service;

        public MainPresenter(IMainView view, IMainService service)
        {
            _view = view;
            _service = service;

            _view.OpenTemplateFile += () => OpenTemplateFile();
            _view.TemplateSelected += () => SetFieldList();
            _view.SelectedFieldChanged += () => GetSelectedFieldValue(_view.SelectedField);
            _view.SelectedFieldValueSave += () => SaveSelectedFieldValue(_view.SelectedField, _view.SelectedFieldValue);
            _view.PrintFormSave += () => SavePrintForm(_view.PrintFormPath);
            _view.SendToEmail += () => SendEmail(_service.SavedPrintFormFullPath);
            _view.ToPrintForm += () => ToPrintSavedTemplate();
        }

        // Отобразить форму
        public void Run()
        {
            _view.Show();
        }

        // Открыть файл шаблона
        private void OpenTemplateFile()
        {
            string fileName = _view.GetTemplateFileName();
            if (fileName != null)
            {
                if (_service.IsFileExist(fileName))
                {
                    _service.OpenTemplate(fileName);
                    _view.TemplatePath = fileName;
                    _view.DisableSendingAndPrinting();
                }
                else
                {
                    _view.ShowError("Указанный файл шаблона не существует.");
                }
            }
        }

        // Получить список полей шаблона
        private void SetFieldList()
        {
            if (_service.FieldList == null)
            {
                throw new NullReferenceException("FieldList");
            }
            else
            {
                _view.SetFieldListDataSource(_service.FieldList);
            }
        }

        // Получить значение выбранного поля
        private void GetSelectedFieldValue(string selectedFieldName)
        {
            if (selectedFieldName == null)
            {
                throw new ArgumentNullException("selectedFieldName");
            }

            if (!_service.FieldListContainsName(selectedFieldName))
            {
                _view.ShowError("Указанный ключ не найден в списке");
            }
            else
            {
                _view.SelectedFieldValue = _service.GetFieldValue(selectedFieldName);
            }
        }

        // Сохранить значение для выбранного поля
        private void SaveSelectedFieldValue(string selectedFieldName, string selectedFieldValue)
        {
            if (selectedFieldName == null)
            {
                throw new ArgumentNullException("selectedFieldName");
            }
            if (selectedFieldValue == null)
            {
                throw new ArgumentNullException("selectedFieldValue");
            }

            if (!_service.FieldListContainsName(selectedFieldName))
            {
                _view.ShowError("Указанный ключ не найден в списке");
            }
            else
            {
                _service.SetFieldValue(selectedFieldName, selectedFieldValue);
            }
        }

        // Отправить печатную форму по эл. почте
        private void SendEmail(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("filePath");
            }

            if (!_service.IsFileExist(filePath))
            {
                _view.ShowError("Недействительный путь к файлу печатной формы.");
            }
            else
            {
                var emailPresenter = new EmailPresenter(_view.GetEmailView(), _view.GetEmailService(), filePath);
                emailPresenter.Run();
            }
        }

        // Сохранить печатную форму в файл
        private void SavePrintForm(string printFormPath)
        {
            if (printFormPath == null)
            {
                throw new ArgumentNullException("printFormName");
            }

            try
            {
                _service.SavePrintForm(printFormPath);
                _view.ShowInformation("Печатная форма успешно сохранена в корне программы.");
                _view.EnableSendingAndPrinting();
            }
            catch (Exception ex)
            {
                _view.ShowError($"При сохранении печатной формы произошла ошибка:\n{ex.Message}");
            }
        }

        // Отправить печатную форму на печать
        private void ToPrintSavedTemplate()
        {
            if (_service.SavedPrintFormFullPath == null)
            {
                throw new ArgumentException("SavedPrintFormFullPath");
            }

            try
            {
                _service.ToPrintForm();
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }
    }
}
