using Presentation;
using System;
using System.Collections.Generic;

namespace DomainModel
{
    public class MainService : IMainService
    {
        private readonly IMainModel _model; // Модель данных

        public string SavedPrintFormFullPath { get { return _model.SavedPrintFormFullPath; } }

        public List<string> FieldList
        {
            get { return _model.FieldListAsList; }
        }

        public MainService()
        {
            _model = new MainModel();
        }

        public bool FieldListContainsName(string name) => _model.FieldListContainsName(name);                           // Проверить, содержится ли поле в списке
        public bool IsFileExist(string fileName) => _model.IsFileExist(fileName);                                       // Проверить файл на существование
        public string GetFieldValue(string selectedFieldName) => _model.GetFieldValue(selectedFieldName);               // Получить значение поля
        public void OpenTemplate(string filePath) => _model.OpenTemplate(filePath);                                     // Открыть шаблон
        public void SetFieldValue(string fieldName, string fieldValue) => _model.SetFieldValue(fieldName, fieldValue);  // Установить значение поля

        // Сохранить печатную форму в файл
        public void SavePrintForm(string printFormPath)
        {
            try
            {
                _model.SaveTemplateToFile(printFormPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Отправить форму на печать
        public void ToPrintForm()
        {
            try
            {
                _model.ToPrintForm();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
