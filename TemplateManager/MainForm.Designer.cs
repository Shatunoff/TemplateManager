namespace TemplateManager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPrintFormSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPrintFormName = new System.Windows.Forms.TextBox();
            this.btnPrintFormSendToPrint = new System.Windows.Forms.Button();
            this.btnPrintFormSendOnEmail = new System.Windows.Forms.Button();
            this.btnTemplateSelect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFieldValueSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFieldValue = new System.Windows.Forms.TextBox();
            this.lbFields = new System.Windows.Forms.ListBox();
            this.tbTemplatePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPrintFormSave);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbPrintFormName);
            this.groupBox2.Controls.Add(this.btnPrintFormSendToPrint);
            this.groupBox2.Controls.Add(this.btnPrintFormSendOnEmail);
            this.groupBox2.Location = new System.Drawing.Point(15, 237);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(527, 87);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Результат";
            // 
            // btnPrintFormSave
            // 
            this.btnPrintFormSave.Enabled = false;
            this.btnPrintFormSave.Location = new System.Drawing.Point(9, 58);
            this.btnPrintFormSave.Name = "btnPrintFormSave";
            this.btnPrintFormSave.Size = new System.Drawing.Size(250, 23);
            this.btnPrintFormSave.TabIndex = 10;
            this.btnPrintFormSave.Text = "Сохранить форму в корне программы";
            this.btnPrintFormSave.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = ".docx";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Название печатной формы:";
            // 
            // tbPrintFormName
            // 
            this.tbPrintFormName.Enabled = false;
            this.tbPrintFormName.Location = new System.Drawing.Point(9, 32);
            this.tbPrintFormName.Name = "tbPrintFormName";
            this.tbPrintFormName.Size = new System.Drawing.Size(217, 20);
            this.tbPrintFormName.TabIndex = 7;
            // 
            // btnPrintFormSendToPrint
            // 
            this.btnPrintFormSendToPrint.Enabled = false;
            this.btnPrintFormSendToPrint.Location = new System.Drawing.Point(265, 29);
            this.btnPrintFormSendToPrint.Name = "btnPrintFormSendToPrint";
            this.btnPrintFormSendToPrint.Size = new System.Drawing.Size(256, 23);
            this.btnPrintFormSendToPrint.TabIndex = 6;
            this.btnPrintFormSendToPrint.Text = "Распечатать форму";
            this.btnPrintFormSendToPrint.UseVisualStyleBackColor = true;
            // 
            // btnPrintFormSendOnEmail
            // 
            this.btnPrintFormSendOnEmail.Enabled = false;
            this.btnPrintFormSendOnEmail.Location = new System.Drawing.Point(265, 58);
            this.btnPrintFormSendOnEmail.Name = "btnPrintFormSendOnEmail";
            this.btnPrintFormSendOnEmail.Size = new System.Drawing.Size(256, 23);
            this.btnPrintFormSendOnEmail.TabIndex = 5;
            this.btnPrintFormSendOnEmail.Text = "Отправить на Email";
            this.btnPrintFormSendOnEmail.UseVisualStyleBackColor = true;
            // 
            // btnTemplateSelect
            // 
            this.btnTemplateSelect.Location = new System.Drawing.Point(467, 12);
            this.btnTemplateSelect.Name = "btnTemplateSelect";
            this.btnTemplateSelect.Size = new System.Drawing.Size(75, 23);
            this.btnTemplateSelect.TabIndex = 13;
            this.btnTemplateSelect.Text = "Выбрать";
            this.btnTemplateSelect.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFieldValueSave);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbFieldValue);
            this.groupBox1.Controls.Add(this.lbFields);
            this.groupBox1.Location = new System.Drawing.Point(15, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 191);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Заполнение формы";
            // 
            // btnFieldValueSave
            // 
            this.btnFieldValueSave.Enabled = false;
            this.btnFieldValueSave.Location = new System.Drawing.Point(446, 30);
            this.btnFieldValueSave.Name = "btnFieldValueSave";
            this.btnFieldValueSave.Size = new System.Drawing.Size(75, 23);
            this.btnFieldValueSave.TabIndex = 6;
            this.btnFieldValueSave.Text = "Сохранить";
            this.btnFieldValueSave.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Значение:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Поле:";
            // 
            // tbFieldValue
            // 
            this.tbFieldValue.Enabled = false;
            this.tbFieldValue.Location = new System.Drawing.Point(235, 32);
            this.tbFieldValue.Name = "tbFieldValue";
            this.tbFieldValue.Size = new System.Drawing.Size(205, 20);
            this.tbFieldValue.TabIndex = 2;
            // 
            // lbFields
            // 
            this.lbFields.FormattingEnabled = true;
            this.lbFields.HorizontalScrollbar = true;
            this.lbFields.Location = new System.Drawing.Point(9, 32);
            this.lbFields.Name = "lbFields";
            this.lbFields.Size = new System.Drawing.Size(220, 147);
            this.lbFields.TabIndex = 0;
            // 
            // tbTemplatePath
            // 
            this.tbTemplatePath.BackColor = System.Drawing.SystemColors.Window;
            this.tbTemplatePath.Location = new System.Drawing.Point(119, 14);
            this.tbTemplatePath.Name = "tbTemplatePath";
            this.tbTemplatePath.ReadOnly = true;
            this.tbTemplatePath.Size = new System.Drawing.Size(342, 20);
            this.tbTemplatePath.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Выберите шаблон:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 334);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnTemplateSelect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbTemplatePath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Формирование печатной формы";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPrintFormSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPrintFormName;
        private System.Windows.Forms.Button btnPrintFormSendToPrint;
        private System.Windows.Forms.Button btnPrintFormSendOnEmail;
        private System.Windows.Forms.Button btnTemplateSelect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFieldValueSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFieldValue;
        private System.Windows.Forms.ListBox lbFields;
        private System.Windows.Forms.TextBox tbTemplatePath;
        private System.Windows.Forms.Label label1;
    }
}

