using System;
using Presentation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateManager
{
    public partial class EmailForm : Form, IEmailView
    {
        public event Action SendToEmail;

        public string SenderEmail
        {
            get { return tbSenderEmail.Text; }
        }

        public string SenderPassword
        {
            get { return tbSenderPassword.Text; }
        }

        public string RecipientEmail
        {
            get { return tbMailRecipient.Text; }
        }

        public string MailSubject
        {
            get { return tbMailSubject.Text; }
        }

        public string MailBody
        {
            get { return tbMailBody.Text; }
        }

        public string SmtpServer
        {
            get
            {
                if (checkSetManually.Checked)
                {
                    return tbSmtpServer.Text;
                }
                else
                {
                    return ((KeyValuePair<string, int>)cbSenderService.SelectedItem).Key;
                }
            }
        }

        public int? SmtpPort
        {
            get
            {
                if (checkSetManually.Checked)
                {
                    return (int)nudSmtpPort.Value;
                }
                else
                {
                    return ((KeyValuePair<string, int>)cbSenderService.SelectedItem).Value;
                }
            }
        }

        public EmailForm()
        {
            InitializeComponent();
        }

        private void btnSendEmail_Click(object sender, EventArgs e) => SendToEmail?.Invoke();               // Была нажата кнопка отправить
        private void checkSetManually_CheckedChanged(object sender, EventArgs e)                            // Была выбрана "ручная" установка smtp-сервера
        {
            bool state = (sender as CheckBox).Checked;
            tbSmtpServer.Enabled = nudSmtpPort.Enabled = state;
        }

        public void ShowInformation(string infoMessage) => MessageBox.Show(infoMessage, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void ShowError(string errorMessage) => MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public void SetAttachmentFilePath(string filePath) => tbAttachmentPath.Text = filePath;    // Установить путь к файлу вложения
        public void SetSmtpDictionary(Dictionary<string, int> dicSmtp)                                      // Установить список Smtp-серверов с портами
        {
            cbSenderService.DataSource = new BindingSource(dicSmtp, null);
            cbSenderService.DisplayMember = "Key";
            cbSenderService.ValueMember = "Value";
        }
    }
}
