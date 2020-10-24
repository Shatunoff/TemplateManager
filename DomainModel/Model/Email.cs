using Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Email : IEmail
    {
        public virtual int Id { get; set; }
        public virtual string SenderEmail { get; set; }
        public virtual string SenderPassword { get; set; }
        public virtual string RecipientEmail { get; set; }
        public virtual string MailSubject { get; set; }
        public virtual string MailBody { get; set; }
        public virtual string Attachment { get; set; }
        public virtual string SmtpServer { get; set; }
        public virtual int SmtpPort { get; set; }
        public virtual string DateTimeOfSendToEmail { get; set; }
    
        public Email()
        {
            SenderEmail = String.Empty;
            SenderPassword = String.Empty;
            RecipientEmail = String.Empty;
            MailSubject = String.Empty;
            MailBody = String.Empty;
            Attachment = String.Empty;
            SmtpServer = String.Empty;
            SmtpPort = 0;
            DateTimeOfSendToEmail = String.Empty;
        }
    }
}
