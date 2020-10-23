namespace TemplateManager
{
    partial class EmailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbAttachmentPath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbMailBody = new System.Windows.Forms.TextBox();
            this.tbMailSubject = new System.Windows.Forms.TextBox();
            this.tbMailRecipient = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudSmtpPort = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSmtpServer = new System.Windows.Forms.TextBox();
            this.checkSetManually = new System.Windows.Forms.CheckBox();
            this.cbSenderService = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSenderPassword = new System.Windows.Forms.TextBox();
            this.tbSenderEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmtpPort)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(514, 278);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(75, 23);
            this.btnSendEmail.TabIndex = 12;
            this.btnSendEmail.Text = "Отправить";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbAttachmentPath);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbMailBody);
            this.groupBox2.Controls.Add(this.tbMailSubject);
            this.groupBox2.Controls.Add(this.tbMailRecipient);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 176);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Письмо";
            // 
            // tbAttachmentPath
            // 
            this.tbAttachmentPath.Location = new System.Drawing.Point(73, 147);
            this.tbAttachmentPath.Name = "tbAttachmentPath";
            this.tbAttachmentPath.ReadOnly = true;
            this.tbAttachmentPath.Size = new System.Drawing.Size(498, 20);
            this.tbAttachmentPath.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Вложение:";
            // 
            // tbMailBody
            // 
            this.tbMailBody.Location = new System.Drawing.Point(9, 58);
            this.tbMailBody.Multiline = true;
            this.tbMailBody.Name = "tbMailBody";
            this.tbMailBody.Size = new System.Drawing.Size(562, 83);
            this.tbMailBody.TabIndex = 7;
            this.tbMailBody.Text = "Сформированная печатная форма доступна во вложении к письму.";
            // 
            // tbMailSubject
            // 
            this.tbMailSubject.Location = new System.Drawing.Point(238, 19);
            this.tbMailSubject.Name = "tbMailSubject";
            this.tbMailSubject.Size = new System.Drawing.Size(333, 20);
            this.tbMailSubject.TabIndex = 6;
            this.tbMailSubject.Text = "Печатная форма";
            // 
            // tbMailRecipient
            // 
            this.tbMailRecipient.Location = new System.Drawing.Point(48, 19);
            this.tbMailRecipient.Name = "tbMailRecipient";
            this.tbMailRecipient.Size = new System.Drawing.Size(100, 20);
            this.tbMailRecipient.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тема письма:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Сообщение:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Кому:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudSmtpPort);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbSmtpServer);
            this.groupBox1.Controls.Add(this.checkSetManually);
            this.groupBox1.Controls.Add(this.cbSenderService);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbSenderPassword);
            this.groupBox1.Controls.Add(this.tbSenderEmail);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 78);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация об отправителе";
            // 
            // nudSmtpPort
            // 
            this.nudSmtpPort.Enabled = false;
            this.nudSmtpPort.Location = new System.Drawing.Point(506, 45);
            this.nudSmtpPort.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudSmtpPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSmtpPort.Name = "nudSmtpPort";
            this.nudSmtpPort.Size = new System.Drawing.Size(40, 20);
            this.nudSmtpPort.TabIndex = 12;
            this.nudSmtpPort.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(440, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Smtp-порт:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(255, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Smtp-сервер:";
            // 
            // tbSmtpServer
            // 
            this.tbSmtpServer.Enabled = false;
            this.tbSmtpServer.Location = new System.Drawing.Point(334, 45);
            this.tbSmtpServer.Name = "tbSmtpServer";
            this.tbSmtpServer.Size = new System.Drawing.Size(100, 20);
            this.tbSmtpServer.TabIndex = 9;
            this.tbSmtpServer.Text = "smtp.yandex.ru";
            // 
            // checkSetManually
            // 
            this.checkSetManually.AutoSize = true;
            this.checkSetManually.Location = new System.Drawing.Point(461, 21);
            this.checkSetManually.Name = "checkSetManually";
            this.checkSetManually.Size = new System.Drawing.Size(113, 17);
            this.checkSetManually.TabIndex = 8;
            this.checkSetManually.Text = "Указать вручную";
            this.checkSetManually.UseVisualStyleBackColor = true;
            // 
            // cbSenderService
            // 
            this.cbSenderService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSenderService.FormattingEnabled = true;
            this.cbSenderService.Location = new System.Drawing.Point(334, 19);
            this.cbSenderService.Name = "cbSenderService";
            this.cbSenderService.Size = new System.Drawing.Size(121, 21);
            this.cbSenderService.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Сервис отправителя:";
            // 
            // tbSenderPassword
            // 
            this.tbSenderPassword.Location = new System.Drawing.Point(108, 46);
            this.tbSenderPassword.Name = "tbSenderPassword";
            this.tbSenderPassword.PasswordChar = '*';
            this.tbSenderPassword.Size = new System.Drawing.Size(100, 20);
            this.tbSenderPassword.TabIndex = 5;
            // 
            // tbSenderEmail
            // 
            this.tbSenderEmail.Location = new System.Drawing.Point(108, 19);
            this.tbSenderEmail.Name = "tbSenderEmail";
            this.tbSenderEmail.Size = new System.Drawing.Size(100, 20);
            this.tbSenderEmail.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "От кого (Пароль):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "От кого (Email):";
            // 
            // EmailForm
            // 
            this.AcceptButton = this.btnSendEmail;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 313);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmailForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отправить печатную форму на Email";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmtpPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbAttachmentPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbMailBody;
        private System.Windows.Forms.TextBox tbMailSubject;
        private System.Windows.Forms.TextBox tbMailRecipient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudSmtpPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSmtpServer;
        private System.Windows.Forms.CheckBox checkSetManually;
        private System.Windows.Forms.ComboBox cbSenderService;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSenderPassword;
        private System.Windows.Forms.TextBox tbSenderEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}