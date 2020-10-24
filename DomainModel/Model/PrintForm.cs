using System;
using Presentation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class PrintForm : IPrintForm
    {
        public virtual int Id { get; set; }
        public virtual string DateTimeOfSaveForm { get; set; }
        public virtual string DateTimeOfSendToPrint { get; set; }
        public virtual string TemplateFilePath { get; set; }
        public virtual string SavedPrintFormFullPath { get; set; }

        public PrintForm()
        {
            DateTimeOfSaveForm = String.Empty;
            DateTimeOfSendToPrint = String.Empty;
            TemplateFilePath = String.Empty;
            SavedPrintFormFullPath = String.Empty;
        }
    }
}
