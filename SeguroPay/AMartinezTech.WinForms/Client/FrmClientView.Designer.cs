namespace AMartinezTech.WinForms.Client
{
    partial class FrmClientView
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
            components = new System.ComponentModel.Container();
            ComboBoxDocIdentityType = new ComboBox();
            label1 = new Label();
            TextBoxDocIdentity = new TextBox();
            label2 = new Label();
            label3 = new Label();
            TextBoxFirstName = new TextBox();
            TextBoxLastName = new TextBox();
            label4 = new Label();
            TextBoxPhone = new TextBox();
            label5 = new Label();
            TextBoxEmail = new TextBox();
            label6 = new Label();
            ComboBoxCity = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            ComboBoxStreet = new ComboBox();
            TextBoxLocationNo = new TextBox();
            label9 = new Label();
            TextBoxAddressRef = new TextBox();
            label10 = new Label();
            TextBoxContactPhone = new TextBox();
            label11 = new Label();
            TextBoxContactName = new TextBox();
            label12 = new Label();
            TextBoxObservation = new TextBox();
            label13 = new Label();
            label14 = new Label();
            ComboBoxClientType = new ComboBox();
            CheckBoxIsActive = new CheckBox();
            BtnClear = new FontAwesome.Sharp.IconButton();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            LabelAlertMessage = new Label();
            PanelLineTop = new Panel();
            PanelAlertMessage = new Panel();
            PanelLineButtom = new Panel();
            PanelButtom = new Panel();
            LabelTitle = new Label();
            errorProvider1 = new ErrorProvider(components);
            BtnStreet = new FontAwesome.Sharp.IconButton();
            PanelAlertMessage.SuspendLayout();
            PanelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // ComboBoxDocIdentityType
            // 
            ComboBoxDocIdentityType.FormattingEnabled = true;
            ComboBoxDocIdentityType.Location = new Point(19, 70);
            ComboBoxDocIdentityType.Name = "ComboBoxDocIdentityType";
            ComboBoxDocIdentityType.Size = new Size(189, 23);
            ComboBoxDocIdentityType.TabIndex = 1;
            ComboBoxDocIdentityType.SelectedIndexChanged += ComboBoxDocIdentityType_SelectedIndexChanged;
            ComboBoxDocIdentityType.KeyPress += ComboBoxDocIdentityType_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 52);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 0;
            label1.Text = "Tipo doc. identidad";
            // 
            // TextBoxDocIdentity
            // 
            TextBoxDocIdentity.Location = new Point(19, 114);
            TextBoxDocIdentity.Name = "TextBoxDocIdentity";
            TextBoxDocIdentity.Size = new Size(189, 23);
            TextBoxDocIdentity.TabIndex = 4;
            TextBoxDocIdentity.TextChanged += TextBoxDocIdentity_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 96);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 3;
            label2.Text = "No. doc. identidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 140);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 7;
            label3.Text = "Nombre (s)";
            // 
            // TextBoxFirstName
            // 
            TextBoxFirstName.Location = new Point(19, 158);
            TextBoxFirstName.Name = "TextBoxFirstName";
            TextBoxFirstName.Size = new Size(189, 23);
            TextBoxFirstName.TabIndex = 8;
            TextBoxFirstName.TextChanged += TextBoxFirtName_TextChanged;
            // 
            // TextBoxLastName
            // 
            TextBoxLastName.Location = new Point(226, 158);
            TextBoxLastName.Name = "TextBoxLastName";
            TextBoxLastName.Size = new Size(189, 23);
            TextBoxLastName.TabIndex = 10;
            TextBoxLastName.TextChanged += TextBoxLastName_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(226, 140);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 9;
            label4.Text = "Apellidos";
            // 
            // TextBoxPhone
            // 
            TextBoxPhone.Location = new Point(19, 202);
            TextBoxPhone.Name = "TextBoxPhone";
            TextBoxPhone.Size = new Size(189, 23);
            TextBoxPhone.TabIndex = 12;
            TextBoxPhone.TextChanged += TextBoxPhone_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 184);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 11;
            label5.Text = "Teléfono";
            // 
            // TextBoxEmail
            // 
            TextBoxEmail.Location = new Point(226, 202);
            TextBoxEmail.Name = "TextBoxEmail";
            TextBoxEmail.Size = new Size(189, 23);
            TextBoxEmail.TabIndex = 14;
            TextBoxEmail.TextChanged += TextBoxEmail_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(226, 184);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 13;
            label6.Text = "Email";
            // 
            // ComboBoxCity
            // 
            ComboBoxCity.FormattingEnabled = true;
            ComboBoxCity.Location = new Point(19, 246);
            ComboBoxCity.Name = "ComboBoxCity";
            ComboBoxCity.Size = new Size(189, 23);
            ComboBoxCity.TabIndex = 16;
            ComboBoxCity.SelectedIndexChanged += ComboBoxCity_SelectedIndexChanged;
            ComboBoxCity.KeyPress += ComboBoxCity_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 228);
            label7.Name = "label7";
            label7.Size = new Size(45, 15);
            label7.TabIndex = 15;
            label7.Text = "Ciudad";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(19, 272);
            label8.Name = "label8";
            label8.Size = new Size(33, 15);
            label8.TabIndex = 17;
            label8.Text = "Calle";
            // 
            // ComboBoxStreet
            // 
            ComboBoxStreet.FormattingEnabled = true;
            ComboBoxStreet.Location = new Point(19, 290);
            ComboBoxStreet.Name = "ComboBoxStreet";
            ComboBoxStreet.Size = new Size(352, 23);
            ComboBoxStreet.TabIndex = 18;
            ComboBoxStreet.SelectedIndexChanged += ComboBoxStreet_SelectedIndexChanged;
            ComboBoxStreet.KeyPress += ComboBoxStreet_KeyPress;
            // 
            // TextBoxLocationNo
            // 
            TextBoxLocationNo.Location = new Point(19, 334);
            TextBoxLocationNo.Name = "TextBoxLocationNo";
            TextBoxLocationNo.Size = new Size(85, 23);
            TextBoxLocationNo.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(19, 316);
            label9.Name = "label9";
            label9.Size = new Size(29, 15);
            label9.TabIndex = 19;
            label9.Text = "No. ";
            // 
            // TextBoxAddressRef
            // 
            TextBoxAddressRef.Location = new Point(127, 334);
            TextBoxAddressRef.Name = "TextBoxAddressRef";
            TextBoxAddressRef.Size = new Size(288, 23);
            TextBoxAddressRef.TabIndex = 22;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(127, 316);
            label10.Name = "label10";
            label10.Size = new Size(62, 15);
            label10.TabIndex = 21;
            label10.Text = "Referencia";
            // 
            // TextBoxContactPhone
            // 
            TextBoxContactPhone.Location = new Point(440, 114);
            TextBoxContactPhone.Name = "TextBoxContactPhone";
            TextBoxContactPhone.Size = new Size(281, 23);
            TextBoxContactPhone.TabIndex = 26;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(440, 96);
            label11.Name = "label11";
            label11.Size = new Size(119, 15);
            label11.TabIndex = 25;
            label11.Text = "Teléfono de contacto";
            // 
            // TextBoxContactName
            // 
            TextBoxContactName.Location = new Point(440, 70);
            TextBoxContactName.Name = "TextBoxContactName";
            TextBoxContactName.Size = new Size(281, 23);
            TextBoxContactName.TabIndex = 24;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(440, 52);
            label12.Name = "label12";
            label12.Size = new Size(117, 15);
            label12.TabIndex = 23;
            label12.Text = "Nombre de contacto";
            // 
            // TextBoxObservation
            // 
            TextBoxObservation.Location = new Point(440, 158);
            TextBoxObservation.Multiline = true;
            TextBoxObservation.Name = "TextBoxObservation";
            TextBoxObservation.Size = new Size(281, 290);
            TextBoxObservation.TabIndex = 28;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(440, 140);
            label13.Name = "label13";
            label13.Size = new Size(73, 15);
            label13.TabIndex = 27;
            label13.Text = "Observación";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(226, 96);
            label14.Name = "label14";
            label14.Size = new Size(85, 15);
            label14.TabIndex = 5;
            label14.Text = "Tipo de cliente";
            // 
            // ComboBoxClientType
            // 
            ComboBoxClientType.FormattingEnabled = true;
            ComboBoxClientType.Location = new Point(226, 114);
            ComboBoxClientType.Name = "ComboBoxClientType";
            ComboBoxClientType.Size = new Size(189, 23);
            ComboBoxClientType.TabIndex = 6;
            ComboBoxClientType.SelectedIndexChanged += ComboBoxClientType_SelectedIndexChanged;
            ComboBoxClientType.KeyPress += ComboBoxClientType_KeyPress;
            // 
            // CheckBoxIsActive
            // 
            CheckBoxIsActive.AutoSize = true;
            CheckBoxIsActive.Checked = true;
            CheckBoxIsActive.CheckState = CheckState.Checked;
            CheckBoxIsActive.Location = new Point(229, 70);
            CheckBoxIsActive.Name = "CheckBoxIsActive";
            CheckBoxIsActive.Size = new Size(60, 19);
            CheckBoxIsActive.TabIndex = 2;
            CheckBoxIsActive.Text = "Activo";
            CheckBoxIsActive.UseVisualStyleBackColor = true;
            // 
            // BtnClear
            // 
            BtnClear.Cursor = Cursors.Hand;
            BtnClear.IconChar = FontAwesome.Sharp.IconChar.File;
            BtnClear.IconColor = Color.Black;
            BtnClear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnClear.Location = new Point(19, 363);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(85, 85);
            BtnClear.TabIndex = 29;
            BtnClear.Text = "&Limpiar";
            BtnClear.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(127, 363);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 30;
            BtnPersistence.Text = "&Guardar";
            BtnPersistence.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPersistence.UseVisualStyleBackColor = true;
            BtnPersistence.Click += BtnPersistence_Click;
            // 
            // LabelAlertMessage
            // 
            LabelAlertMessage.AutoSize = true;
            LabelAlertMessage.Font = new Font("Segoe UI", 12F);
            LabelAlertMessage.Location = new Point(13, 7);
            LabelAlertMessage.Name = "LabelAlertMessage";
            LabelAlertMessage.Size = new Size(52, 21);
            LabelAlertMessage.TabIndex = 0;
            LabelAlertMessage.Text = "label8";
            // 
            // PanelLineTop
            // 
            PanelLineTop.Dock = DockStyle.Top;
            PanelLineTop.Location = new Point(0, 35);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(744, 2);
            PanelLineTop.TabIndex = 32;
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(744, 35);
            PanelAlertMessage.TabIndex = 31;
            // 
            // PanelLineButtom
            // 
            PanelLineButtom.Dock = DockStyle.Bottom;
            PanelLineButtom.Location = new Point(0, 466);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(744, 2);
            PanelLineButtom.TabIndex = 34;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelTitle);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 468);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(744, 35);
            PanelButtom.TabIndex = 33;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            LabelTitle.Location = new Point(13, 5);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(136, 21);
            LabelTitle.TabIndex = 1;
            LabelTitle.Text = "Maestro de cliente";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // BtnStreet
            // 
            BtnStreet.Cursor = Cursors.Hand;
            BtnStreet.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            BtnStreet.IconColor = Color.Black;
            BtnStreet.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnStreet.IconSize = 25;
            BtnStreet.Location = new Point(386, 286);
            BtnStreet.Name = "BtnStreet";
            BtnStreet.Size = new Size(32, 29);
            BtnStreet.TabIndex = 35;
            BtnStreet.UseVisualStyleBackColor = true;
            BtnStreet.Click += BtnStreet_Click;
            // 
            // FrmClientView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 503);
            Controls.Add(BtnStreet);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelAlertMessage);
            Controls.Add(BtnPersistence);
            Controls.Add(BtnClear);
            Controls.Add(CheckBoxIsActive);
            Controls.Add(label14);
            Controls.Add(ComboBoxClientType);
            Controls.Add(TextBoxObservation);
            Controls.Add(label13);
            Controls.Add(TextBoxContactPhone);
            Controls.Add(label11);
            Controls.Add(TextBoxContactName);
            Controls.Add(label12);
            Controls.Add(TextBoxAddressRef);
            Controls.Add(label10);
            Controls.Add(TextBoxLocationNo);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(ComboBoxStreet);
            Controls.Add(label7);
            Controls.Add(ComboBoxCity);
            Controls.Add(TextBoxEmail);
            Controls.Add(label6);
            Controls.Add(TextBoxPhone);
            Controls.Add(label5);
            Controls.Add(TextBoxLastName);
            Controls.Add(label4);
            Controls.Add(TextBoxFirstName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TextBoxDocIdentity);
            Controls.Add(label1);
            Controls.Add(ComboBoxDocIdentityType);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmClientView";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cliente";
            Load += FrmClientView_Load;
            PanelAlertMessage.ResumeLayout(false);
            PanelAlertMessage.PerformLayout();
            PanelButtom.ResumeLayout(false);
            PanelButtom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ComboBoxDocIdentityType;
        private Label label1;
        private TextBox TextBoxDocIdentity;
        private Label label2;
        private Label label3;
        private TextBox TextBoxFirstName;
        private TextBox TextBoxLastName;
        private Label label4;
        private TextBox TextBoxPhone;
        private Label label5;
        private TextBox TextBoxEmail;
        private Label label6;
        private ComboBox ComboBoxCity;
        private Label label7;
        private Label label8;
        private ComboBox ComboBoxStreet;
        private TextBox TextBoxLocationNo;
        private Label label9;
        private TextBox TextBoxAddressRef;
        private Label label10;
        private TextBox TextBoxContactPhone;
        private Label label11;
        private TextBox TextBoxContactName;
        private Label label12;
        private TextBox TextBoxObservation;
        private Label label13;
        private Label label14;
        private ComboBox ComboBoxClientType;
        private CheckBox CheckBoxIsActive;
        private FontAwesome.Sharp.IconButton BtnClear;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private Label LabelAlertMessage;
        private Panel PanelLineTop;
        private Panel PanelAlertMessage;
        private Panel PanelLineButtom;
        private Panel PanelButtom;
        private Label LabelTitle;
        private ErrorProvider errorProvider1;
        private FontAwesome.Sharp.IconButton BtnStreet;
    }
}