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
    class MainModel : IMainModel
    {
        private string templateFilePath;
        private Dictionary<string, string> dicTemplateFields; // Словарь, содержащий поле шаблона и указанное значение

        public string SavedPrintFormFullPath { get; private set; }

        public List<string> FieldListAsList
        {
            get
            {
                return dicTemplateFields?.Keys.ToList();
            }
        }

        public MainModel()
        {
            dicTemplateFields = new Dictionary<string, string>();
        }

        // Открыть файл шаблона
        public void OpenTemplate(string templatePath)
        {
            try
            {
                templateFilePath = templatePath;
                dicTemplateFields.Clear();
                SavedPrintFormFullPath = null;
                byte[] textByteArray = File.ReadAllBytes(templatePath);                             // Получаем массив байтов из нашего файла

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

        // Проверить указанный файл на существование
        public bool IsFileExist(string fileName)
        {
            return File.Exists(fileName);
        }

        // Проверить поле на наличие в списке
        public bool FieldListContainsName(string fieldName)
        {
            return dicTemplateFields.Keys.Contains(fieldName);
        }

        // Получить значение указанного поля
        public string GetFieldValue(string fieldName)
        {
            if (dicTemplateFields.Keys.Contains(fieldName))
            {
                return dicTemplateFields[fieldName];
            }
            else
            {
                return null;
            }
        }

        // Изменить значение выбранного поля
        public void SetFieldValue(string key, string value)
        {
            if (dicTemplateFields.ContainsKey(key))
            {
                dicTemplateFields[key] = value;
            }
        }

        // Сохранить заполненный шаблон в файл
        public void SaveTemplateToFile(string fileName)
        {
            try
            {
                // Получаем массив байтов из нашего файла
                byte[] textByteArray = File.ReadAllBytes(templateFilePath);

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
                    string filePath = Directory.GetCurrentDirectory() + "\\" + fileName;
                    File.WriteAllBytes(filePath, stream.ToArray());
                    SavedPrintFormFullPath = filePath;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ToPrintForm()
        {
            try
            {
                using (PrintDialog pd = new PrintDialog())
                {
                    pd.ShowDialog();
                    ProcessStartInfo info = new ProcessStartInfo($"{SavedPrintFormFullPath}");
                    info.WindowStyle = ProcessWindowStyle.Hidden;
                    info.Verb = "PrintTo";
                    info.Arguments = pd.PrinterSettings.PrinterName;
                    info.CreateNoWindow = true;
                    Process.Start(info);
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
