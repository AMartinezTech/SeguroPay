namespace AMartinezTech.WinForms.Bank
{
    partial class FrmBankAccount
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
            PanelLineTop = new Panel();
            PanelAlertMessage = new Panel();
            LabelAlertMessage = new Label();
            TextBoxName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            TextBoxNumber = new TextBox();
            ComboBoxType = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            TextBoxContactName = new TextBox();
            label5 = new Label();
            TextBoxContactPhone = new TextBox();
            CheckBoxIsActive = new CheckBox();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            BtnClear = new FontAwesome.Sharp.IconButton();
            PanelLineButtom = new Panel();
            PanelButtom = new Panel();
            LabelTitle = new Label();
            DataGridView = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            PanelAlertMessage.SuspendLayout();
            PanelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // PanelLineTop
            // 
            PanelLineTop.Dock = DockStyle.Top;
            PanelLineTop.Location = new Point(0, 35);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(792, 2);
            PanelLineTop.TabIndex = 21;
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(792, 35);
            PanelAlertMessage.TabIndex = 20;
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
            // TextBoxName
            // 
            TextBoxName.Location = new Point(13, 70);
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new Size(255, 23);
            TextBoxName.TabIndex = 22;
            TextBoxName.TextChanged += TextBoxName_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 52);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 23;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 96);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 25;
            label2.Text = "Número";
            // 
            // TextBoxNumber
            // 
            TextBoxNumber.Location = new Point(14, 114);
            TextBoxNumber.Name = "TextBoxNumber";
            TextBoxNumber.Size = new Size(255, 23);
            TextBoxNumber.TabIndex = 24;
            TextBoxNumber.TextChanged += TextBoxNumber_TextChanged;
            // 
            // ComboBoxType
            // 
            ComboBoxType.FormattingEnabled = true;
            ComboBoxType.Location = new Point(14, 158);
            ComboBoxType.Name = "ComboBoxType";
            ComboBoxType.Size = new Size(254, 23);
            ComboBoxType.TabIndex = 26;
            ComboBoxType.KeyPress += ComboBoxType_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 140);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 27;
            label3.Text = "Tipo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 184);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 29;
            label4.Text = "Contacto";
            // 
            // TextBoxContactName
            // 
            TextBoxContactName.Location = new Point(14, 202);
            TextBoxContactName.Name = "TextBoxContactName";
            TextBoxContactName.Size = new Size(255, 23);
            TextBoxContactName.TabIndex = 28;
            TextBoxContactName.TextChanged += TextBoxContactName_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 228);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 31;
            label5.Text = "Teléfono";
            // 
            // TextBoxContactPhone
            // 
            TextBoxContactPhone.Location = new Point(14, 246);
            TextBoxContactPhone.Name = "TextBoxContactPhone";
            TextBoxContactPhone.Size = new Size(255, 23);
            TextBoxContactPhone.TabIndex = 30;
            TextBoxContactPhone.TextChanged += TextBoxContactPhone_TextChanged;
            // 
            // CheckBoxIsActive
            // 
            CheckBoxIsActive.AutoSize = true;
            CheckBoxIsActive.Checked = true;
            CheckBoxIsActive.CheckState = CheckState.Checked;
            CheckBoxIsActive.Location = new Point(154, 285);
            CheckBoxIsActive.Name = "CheckBoxIsActive";
            CheckBoxIsActive.Size = new Size(60, 19);
            CheckBoxIsActive.TabIndex = 32;
            CheckBoxIsActive.Text = "Activo";
            CheckBoxIsActive.UseVisualStyleBackColor = true;
            // 
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(184, 311);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 34;
            BtnPersistence.Text = "&Guardar";
            BtnPersistence.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPersistence.UseVisualStyleBackColor = true;
            BtnPersistence.Click += BtnPersistence_Click;
            // 
            // BtnClear
            // 
            BtnClear.Cursor = Cursors.Hand;
            BtnClear.IconChar = FontAwesome.Sharp.IconChar.File;
            BtnClear.IconColor = Color.Black;
            BtnClear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnClear.Location = new Point(14, 311);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(85, 85);
            BtnClear.TabIndex = 33;
            BtnClear.Text = "&Limpiar";
            BtnClear.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // PanelLineButtom
            // 
            PanelLineButtom.Dock = DockStyle.Bottom;
            PanelLineButtom.Location = new Point(0, 413);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(792, 2);
            PanelLineButtom.TabIndex = 36;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelTitle);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 415);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(792, 35);
            PanelButtom.TabIndex = 35;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            LabelTitle.Location = new Point(13, 5);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(134, 21);
            LabelTitle.TabIndex = 1;
            LabelTitle.Text = "Maestro de banco";
            // 
            // DataGridView
            // 
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(309, 70);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(479, 326);
            DataGridView.TabIndex = 37;
            DataGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmBankAccount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 450);
            Controls.Add(DataGridView);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(BtnPersistence);
            Controls.Add(BtnClear);
            Controls.Add(CheckBoxIsActive);
            Controls.Add(label5);
            Controls.Add(TextBoxContactPhone);
            Controls.Add(label4);
            Controls.Add(TextBoxContactName);
            Controls.Add(label3);
            Controls.Add(ComboBoxType);
            Controls.Add(label2);
            Controls.Add(TextBoxNumber);
            Controls.Add(label1);
            Controls.Add(TextBoxName);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelAlertMessage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmBankAccount";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cuenta de banco";
            Load += FrmBankAccount_Load;
            PanelAlertMessage.ResumeLayout(false);
            PanelAlertMessage.PerformLayout();
            PanelButtom.ResumeLayout(false);
            PanelButtom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelLineTop;
        private Panel PanelAlertMessage;
        private Label LabelAlertMessage;
        private TextBox TextBoxName;
        private Label label1;
        private Label label2;
        private TextBox TextBoxNumber;
        private ComboBox ComboBoxType;
        private Label label3;
        private Label label4;
        private TextBox TextBoxContactName;
        private Label label5;
        private TextBox TextBoxContactPhone;
        private CheckBox CheckBoxIsActive;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private FontAwesome.Sharp.IconButton BtnClear;
        private Panel PanelLineButtom;
        private Panel PanelButtom;
        private Label LabelTitle;
        private DataGridView DataGridView;
        private ErrorProvider errorProvider1;
    }
}