using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Presentation;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace DomainModel
{
    public class MainService : IMainService
    {
        private readonly IPrintForm _model; // Модель данных
        private readonly IMainRepository _repository; // Взаимодействие с БД

        public string SavedPrintFormFullPath { get { return _model.SavedPrintFormFullPath; } }

        private Dictionary<string, string> dicTemplateFields; // Словарь, содержащий поле шаблона и указанное значение
        public List<string> FieldList
        {
            get { return dicTemplateFields?.Keys.ToList(); }
        }

        public MainService()
        {
            dicTemplateFields = new Dictionary<string, string>();
            _model = new PrintForm();
            _repository = new MainRepository();
        }

        // Проверить, содержится ли поле в списке
        public bool FieldListContainsName(string name)
        {
            return dicTemplateFields.Keys.Contains(name);
        }

        // Проверить файл на существование
        public bool IsFileExist(string fileName)
        {
            return File.Exists(fileName);
        }

        // Получить значение поля
        public string GetFieldValue(string selectedFieldName)
        {
            if (dicTemplateFields.Keys.Contains(selectedFieldName))
            {
                return dicTemplateFields[selectedFieldName];
            }
            else
            {
                return null;
            }
        }

        // Открыть шаблон
        public void OpenTemplate(string filePath)
        {
            try
            {
                _model.TemplateFilePath = filePath;
                dicTemplateFields.Clear();
                _model.SavedPrintFormFullPath = null;
                byte[] textByteArray = File.ReadAllBytes(filePath);                                 // Получаем массив байтов из нашего файла

                using (MemoryStream stream = new MemoryStream())                                    // Начинаем работу с потоком
                {
                    stream.Write(textByteArray, 0, textByteArray.Length);                           // Записываем в поток наш word-файл

                    using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))  // Открываем документ из потока с возможностью редактирования
                    {
                        var bookMarks = FindBookmarks(doc.MainDocumentPart.Document);               // Ищем все закладки в документе

                        foreach (var end in bookMarks)                                              // Добавляем найденные закладки в словарь
                        {
                            dicTemplateFields.Add(end.Key, string.Empty);                           // end.Key содержит имена наших закладок
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }                                 

        // Установить значение поля
        public void SetFieldValue(string fieldName, string fieldValue)
        {
            if (dicTemplateFields.ContainsKey(fieldName))
            {
                dicTemplateFields[fieldName] = fieldValue;
            }
        }

        // Сохранить печатную форму в файл
        public void SavePrintForm(string printFormPath)
        {
            try
            {
                try
                {
                    // Получаем массив байтов из нашего файла
                    byte[] textByteArray = File.ReadAllBytes(_model.TemplateFilePath);

                    // Начинаем работу с потоком
                    using (MemoryStream stream = new MemoryStream())
                    {
                        // Записываем в поток наш word-файл
                        stream.Write(textByteArray, 0, textByteArray.Length);
                        // Открываем документ из потока с возможностью редактирования
                        using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))
                        {
                            // Изменяем шрифт по-умолчанию
                            RunProperties rPr = new RunProperties(
                                new RunFonts()
                                {
                                    HighAnsi = "Times New Roman"
                                },
                                new FontSize()
                                {
                                    Val = new StringValue("28")
                                });

                            // Ищем все закладки в документе
                            var bookMarks = FindBookmarks(doc.MainDocumentPart.Document);

                            foreach (var end in bookMarks)
                            {
                                foreach (var field in dicTemplateFields)
                                {
                                    if (end.Key == field.Key)
                                    {
                                        var textElement = new Text(field.Value ?? string.Empty);
                                        // Далее данный текст добавляем в закладку
                                        Run runElement = new Run();
                                        runElement.AppendChild(textElement);
                                        runElement.PrependChild(rPr.CloneNode(true));
                                        end.Value.InsertAfterSelf(runElement);
                                    }
                                }
                            }
                        }
                        // Записываем всё в наш файл
                        string filePath = Directory.GetCurrentDirectory() + "\\" + printFormPath;
                        File.WriteAllBytes(filePath, stream.ToArray());
                        _model.SavedPrintFormFullPath = filePath;
                        _model.DateTimeOfSaveForm = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                        _model.DateTimeOfSendToPrint = String.Empty;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                _repository.AddPrintFormLog(_model); // Логгируем в БД
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
                if (String.IsNullOrEmpty(_model.DateTimeOfSendToPrint))
                {
                    ToPrintPrintForm();
                    _repository.UpdatePrintFormLog(_model);
                }
                else
                {
                    ToPrintPrintForm();
                    _repository.AddPrintFormLog(_model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Отправить форму на печать
        private void ToPrintPrintForm()
        {
            try
            {
                using (PrintDialog pd = new PrintDialog())
                {
                    pd.ShowDialog();
                    ProcessStartInfo info = new ProcessStartInfo($"{_model.SavedPrintFormFullPath}");
                    info.WindowStyle = ProcessWindowStyle.Hidden;
                    info.Verb = "PrintTo";
                    info.Arguments = pd.PrinterSettings.PrinterName;
                    info.CreateNoWindow = true;
                    Process.Start(info);
                    _model.DateTimeOfSendToPrint = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Найти все закладки в документе
        private static Dictionary<string, BookmarkEnd> FindBookmarks(OpenXmlElement documentPart, Dictionary<string, BookmarkEnd> outs = null, Dictionary<string, string> bStartWithNoEnds = null)
        {
            if (outs == null) { outs = new Dictionary<string, BookmarkEnd>(); } // outs - конечный результат
            if (bStartWithNoEnds == null) { bStartWithNoEnds = new Dictionary<string, string>(); } // bStartWithNoEnds - словарь, который будет содержать только начало закладок, чтобы потом по ним находить соответствующие им концы закладок

            // Проходимся по всем элементам на странице Word-документа
            foreach (var docElement in documentPart.Elements()) // documentPart - элемент Word-документа
            {
                // BookmarkStart определяет начало закладки в рамках документа
                // маркер начала связан с маркером конца закладки
                if (docElement is BookmarkStart)
                {
                    var bookmarkStart = docElement as BookmarkStart;
                    if (bookmarkStart.Name != "_GoBack") // Игнорировать стандартный метод возврата
                    {
                        bStartWithNoEnds.Add(bookmarkStart.Id, bookmarkStart.Name); // Записываем id и имя закладки
                    }
                }

                // BookmarkEnd определяет конец закладки в рамках документа
                if (docElement is BookmarkEnd)
                {
                    var bookmarkEnd = docElement as BookmarkEnd;
                    foreach (var startName in bStartWithNoEnds)
                    {
                        // startName.Key как раз и содержит id закладки
                        // здесь проверяем, что есть связь между началом и концом закладки
                        if (bookmarkEnd.Id == startName.Key)
                            outs.Add(startName.Value, bookmarkEnd); // В конечный список добавляем то, что нам и нужно получить
                    }
                }
                // Самовызывае, чтобы пройтись по всем элементам word-документа
                FindBookmarks(docElement, outs, bStartWithNoEnds);
            }

            return outs;
        }
    }
}
