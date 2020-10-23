using DomainModel;
using Presentation;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TemplateManager
{
    public partial class MainForm : Form, IMainView
    {
        public event Action OpenTemplateFile;
        public event Action TemplateSelected;
        public event Action SelectedFieldChanged;
        public event Action SelectedFieldValueSave;
        public event Action PrintFormSave;
        public event Action SendToEmail;
        public event Action ToPrintForm;

        public string SelectedField // Выбранное поле шаблона
        {
            get { return lbFields.SelectedItem.ToString(); }
        }

        public string PrintFormPath // Путь к сохраненной печатной форме
        {
            get { return tbPrintFormName.Text + ".docx"; }
        }

        public string TemplatePath // Путь к файлу шаблона
        {
            get { return tbTemplatePath.Text; }
            set { tbTemplatePath.Text = value; }
        }

        public string SelectedFieldValue
        {
            get { return tbFieldValue.Text; }
            set { tbFieldValue.Text = value; }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        public new void Show()
        {
            Application.Run(this);
        }

        // События View
        private void btnTemplateSelect_Click(object sender, EventArgs e) => OpenTemplateFile?.Invoke();             // Была нажата кнопка выбора файла шаблона
        private void tbTemplatePath_TextChanged(object sender, EventArgs e) => TemplateSelected?.Invoke();          // Был выбран файл шаблона
        private void lbFields_SelectedIndexChanged(object sender, EventArgs e) => SelectedFieldChanged?.Invoke();   // Было выбрано поле шаблона
        private void btnFieldValueSave_Click(object sender, EventArgs e) => SelectedFieldValueSave?.Invoke();       // Было сохранено значение выбранного поля шаблона
        private void btnPrintFormSave_Click(object sender, EventArgs e) => PrintFormSave?.Invoke();                 // Была нажата кнопка сохранения шаблона
        private void btnPrintFormSendOnEmail_Click(object sender, EventArgs e) => SendToEmail?.Invoke();            // Была нажата кнопка отправки шаблона по эл. почте
        private void btnPrintFormSendToPrint_Click(object sender, EventArgs e) => ToPrintForm?.Invoke();            // Была нажата кнопка печати формы

        // Защита
        private void tbFieldValue_TextChanged(object sender, EventArgs e) => btnFieldValueSave.Enabled = true;      // Изменено значение выбранного поля шаблона
        private void tbPrintFormName_TextChanged(object sender, EventArgs e) => btnPrintFormSave.Enabled = (sender as TextBox).TextLength > 0 ? true : false; // Изменено название файла ПФ

        // Изменен источник данных ListBox
        private void lbFields_DataSourceChanged(object sender, EventArgs e)
        {
            bool state = lbFields.DataSource == null ? false : true;
            btnFieldValueSave.Enabled = state;
            tbFieldValue.Enabled = state;
            tbFieldValue.Focus();
            tbPrintFormName.Enabled = state;
        }

        // Быстрое перемещение по ListBox
        private void tbFieldValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnFieldValueSave.Enabled)
                {
                    btnFieldValueSave.PerformClick();
                }
                if (lbFields.SelectedIndex < lbFields.Items.Count)
                {
                    if (lbFields.SelectedIndex != lbFields.Items.Count - 1)
                    {
                        lbFields.SelectedIndex++;
                        (sender as TextBox).Focus();
                        (sender as TextBox).Select(0, 0);
                    }
                    else
                    {
                        tbPrintFormName.Focus();
                        tbPrintFormName.Select(0, 0);
                    }
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                if (lbFields.SelectedIndex > 0)
                {
                    lbFields.SelectedIndex--;
                    (sender as TextBox).Focus();
                    (sender as TextBox).Select(0, 0);
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                if (lbFields.SelectedIndex < lbFields.Items.Count - 1)
                {
                    lbFields.SelectedIndex++;
                    (sender as TextBox).Focus();
                    (sender as TextBox).Select(0, 0);
                }
            }
        }

        // Фокусировка на TextBox для установки значения выбранного поля
        private void lbFields_MouseUp(object sender, MouseEventArgs e)
        {
            if (lbFields.SelectedItem != null)
            {
                if (tbFieldValue.Enabled)
                {
                    tbFieldValue.Focus();
                    tbFieldValue.Select(0, 0);
                }
            }
        }

        // Быстрое сохранение заполненной формы
        private void tbPrintFormName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((sender as TextBox).Text.Length > 0)
                {
                    btnPrintFormSave.PerformClick();
                }
            }
        }

        // Методы View
        public void SetFieldListDataSource(List<string> fieldList) => lbFields.DataSource = fieldList;     // Указать источник данных для списка полей шаблона
        public void ShowInformation(string infoMessage) => MessageBox.Show(infoMessage, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void ShowError(string errorMessage) => MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public IEmailView GetEmailView() => new EmailForm();
        public IEmailService GetEmailService() => new EmailService();

        // Получить путь к выбранному файлу шаблона
        public string GetTemplateFileName()
        {
            string fileName = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выбрать шаблон печатной формы";
            ofd.Filter = "Word Files(*.docx;)|*.docx|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.FileName;
            }
            return fileName;
        }

        public void EnableSendingAndPrinting()
        {
            btnPrintFormSendOnEmail.Enabled = true;
            btnPrintFormSendToPrint.Enabled = true;
        }

        public void DisableSendingAndPrinting()
        {
            btnPrintFormSendOnEmail.Enabled = false;
            btnPrintFormSendToPrint.Enabled = false;
        }
    }
}
