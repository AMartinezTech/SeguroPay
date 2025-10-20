namespace AMartinezTech.WinForms.Policy
{
    partial class FrmPolicyView
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
            label1 = new Label();
            TextBoxPolicyNo = new TextBox();
            label2 = new Label();
            ComboBoxInsurance = new ComboBox();
            label3 = new Label();
            ComboBoxPolicyTypeId = new ComboBox();
            TextBoxClient = new TextBox();
            ComboBoxPayFrecuency = new ComboBox();
            label5 = new Label();
            NumericUpDownPayDay = new NumericUpDown();
            label6 = new Label();
            TextBoxAmount = new TextBox();
            label7 = new Label();
            label8 = new Label();
            TextBoxNote = new TextBox();
            PanelLineTop = new Panel();
            PanelAlertMessage = new Panel();
            LabelAlertMessage = new Label();
            PanelLineButtom = new Panel();
            PanelButtom = new Panel();
            LabelTitle = new Label();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            BtnClear = new FontAwesome.Sharp.IconButton();
            errorProvider1 = new ErrorProvider(components);
            BtnNewPolicyType = new FontAwesome.Sharp.IconButton();
            BtnSelectClient = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownPayDay).BeginInit();
            PanelAlertMessage.SuspendLayout();
            PanelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 57);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 0;
            label1.Text = "No. de poliza";
            // 
            // TextBoxPolicyNo
            // 
            TextBoxPolicyNo.Location = new Point(13, 75);
            TextBoxPolicyNo.Name = "TextBoxPolicyNo";
            TextBoxPolicyNo.Size = new Size(147, 23);
            TextBoxPolicyNo.TabIndex = 1;
            TextBoxPolicyNo.TextChanged += TextBoxPolicyNo_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 101);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 2;
            label2.Text = "Aseguradora";
            // 
            // ComboBoxInsurance
            // 
            ComboBoxInsurance.FormattingEnabled = true;
            ComboBoxInsurance.Location = new Point(13, 119);
            ComboBoxInsurance.Name = "ComboBoxInsurance";
            ComboBoxInsurance.Size = new Size(195, 23);
            ComboBoxInsurance.TabIndex = 3;
            ComboBoxInsurance.SelectedIndexChanged += ComboBoxInsurance_SelectedIndexChanged;
            ComboBoxInsurance.KeyPress += ComboBoxInsurance_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 145);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 4;
            label3.Text = "Tipo";
            // 
            // ComboBoxPolicyTypeId
            // 
            ComboBoxPolicyTypeId.FormattingEnabled = true;
            ComboBoxPolicyTypeId.Location = new Point(13, 163);
            ComboBoxPolicyTypeId.Name = "ComboBoxPolicyTypeId";
            ComboBoxPolicyTypeId.Size = new Size(145, 23);
            ComboBoxPolicyTypeId.TabIndex = 5;
            ComboBoxPolicyTypeId.SelectedIndexChanged += ComboBoxPolicyTypeId_SelectedIndexChanged;
            ComboBoxPolicyTypeId.KeyPress += ComboBoxPolicyTypeId_KeyPress;
            // 
            // TextBoxClient
            // 
            TextBoxClient.Location = new Point(13, 223);
            TextBoxClient.Multiline = true;
            TextBoxClient.Name = "TextBoxClient";
            TextBoxClient.Size = new Size(197, 74);
            TextBoxClient.TabIndex = 6;
            TextBoxClient.TextChanged += TextBoxClient_TextChanged;
            // 
            // ComboBoxPayFrecuency
            // 
            ComboBoxPayFrecuency.FormattingEnabled = true;
            ComboBoxPayFrecuency.Location = new Point(251, 75);
            ComboBoxPayFrecuency.Name = "ComboBoxPayFrecuency";
            ComboBoxPayFrecuency.Size = new Size(197, 23);
            ComboBoxPayFrecuency.TabIndex = 8;
            ComboBoxPayFrecuency.SelectedIndexChanged += ComboBoxPayFrecuency_SelectedIndexChanged;
            ComboBoxPayFrecuency.KeyPress += ComboBoxPayFrecuency_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(251, 57);
            label5.Name = "label5";
            label5.Size = new Size(110, 15);
            label5.TabIndex = 9;
            label5.Text = "Frecuencia de pago";
            // 
            // NumericUpDownPayDay
            // 
            NumericUpDownPayDay.Location = new Point(251, 119);
            NumericUpDownPayDay.Name = "NumericUpDownPayDay";
            NumericUpDownPayDay.Size = new Size(120, 23);
            NumericUpDownPayDay.TabIndex = 10;
            NumericUpDownPayDay.ValueChanged += NumericUpDownPayDay_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(251, 101);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 11;
            label6.Text = "Día de pago";
            // 
            // TextBoxAmount
            // 
            TextBoxAmount.Location = new Point(251, 163);
            TextBoxAmount.Name = "TextBoxAmount";
            TextBoxAmount.Size = new Size(120, 23);
            TextBoxAmount.TabIndex = 12;
            TextBoxAmount.Text = "0.00";
            TextBoxAmount.TextChanged += TextBoxAmount_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(251, 145);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 13;
            label7.Text = "Monto RD$";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(251, 189);
            label8.Name = "label8";
            label8.Size = new Size(33, 15);
            label8.TabIndex = 14;
            label8.Text = "Nota";
            // 
            // TextBoxNote
            // 
            TextBoxNote.Location = new Point(251, 207);
            TextBoxNote.Multiline = true;
            TextBoxNote.Name = "TextBoxNote";
            TextBoxNote.Size = new Size(197, 74);
            TextBoxNote.TabIndex = 15;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Dock = DockStyle.Top;
            PanelLineTop.Location = new Point(0, 35);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(493, 2);
            PanelLineTop.TabIndex = 34;
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(493, 35);
            PanelAlertMessage.TabIndex = 33;
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
            // PanelLineButtom
            // 
            PanelLineButtom.Dock = DockStyle.Bottom;
            PanelLineButtom.Location = new Point(0, 387);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(493, 2);
            PanelLineButtom.TabIndex = 36;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelTitle);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 389);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(493, 35);
            PanelButtom.TabIndex = 35;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            LabelTitle.Location = new Point(13, 5);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(133, 21);
            LabelTitle.TabIndex = 1;
            LabelTitle.Text = "Maestro de poliza";
            // 
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(123, 298);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 38;
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
            BtnClear.Location = new Point(15, 298);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(85, 85);
            BtnClear.TabIndex = 37;
            BtnClear.Text = "&Limpiar";
            BtnClear.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // BtnNewPolicyType
            // 
            BtnNewPolicyType.Cursor = Cursors.Hand;
            BtnNewPolicyType.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            BtnNewPolicyType.IconColor = Color.Black;
            BtnNewPolicyType.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnNewPolicyType.IconSize = 25;
            BtnNewPolicyType.Location = new Point(180, 158);
            BtnNewPolicyType.Name = "BtnNewPolicyType";
            BtnNewPolicyType.Size = new Size(30, 30);
            BtnNewPolicyType.TabIndex = 39;
            BtnNewPolicyType.UseVisualStyleBackColor = true;
            BtnNewPolicyType.Click += BtnNewPolicyType_Click;
            // 
            // BtnSelectClient
            // 
            BtnSelectClient.IconChar = FontAwesome.Sharp.IconChar.Search;
            BtnSelectClient.IconColor = Color.Black;
            BtnSelectClient.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnSelectClient.IconSize = 25;
            BtnSelectClient.Location = new Point(13, 189);
            BtnSelectClient.Name = "BtnSelectClient";
            BtnSelectClient.Size = new Size(195, 28);
            BtnSelectClient.TabIndex = 40;
            BtnSelectClient.Text = "Seleccionar Cliente";
            BtnSelectClient.TextAlign = ContentAlignment.MiddleLeft;
            BtnSelectClient.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnSelectClient.UseVisualStyleBackColor = true;
            BtnSelectClient.Click += BtnSelectClient_Click;
            // 
            // FrmPolicyView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 424);
            Controls.Add(BtnSelectClient);
            Controls.Add(BtnNewPolicyType);
            Controls.Add(BtnPersistence);
            Controls.Add(BtnClear);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelAlertMessage);
            Controls.Add(TextBoxNote);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(TextBoxAmount);
            Controls.Add(label6);
            Controls.Add(NumericUpDownPayDay);
            Controls.Add(label5);
            Controls.Add(ComboBoxPayFrecuency);
            Controls.Add(TextBoxClient);
            Controls.Add(ComboBoxPolicyTypeId);
            Controls.Add(label3);
            Controls.Add(ComboBoxInsurance);
            Controls.Add(label2);
            Controls.Add(TextBoxPolicyNo);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPolicyView";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Poliza";
            Load += FrmPolicyView_Load;
            ((System.ComponentModel.ISupportInitialize)NumericUpDownPayDay).EndInit();
            PanelAlertMessage.ResumeLayout(false);
            PanelAlertMessage.PerformLayout();
            PanelButtom.ResumeLayout(false);
            PanelButtom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TextBoxPolicyNo;
        private Label label2;
        private ComboBox ComboBoxInsurance;
        private Label label3;
        private ComboBox ComboBoxPolicyTypeId;
        private TextBox TextBoxClient;
        private ComboBox ComboBoxPayFrecuency;
        private Label label5;
        private NumericUpDown NumericUpDownPayDay;
        private Label label6;
        private TextBox TextBoxAmount;
        private Label label7;
        private Label label8;
        private TextBox TextBoxNote;
        private Panel PanelLineTop;
        private Panel PanelAlertMessage;
        private Label LabelAlertMessage;
        private Panel PanelLineButtom;
        private Panel PanelButtom;
        private Label LabelTitle;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private FontAwesome.Sharp.IconButton BtnClear;
        private ErrorProvider errorProvider1;
        private FontAwesome.Sharp.IconButton BtnNewPolicyType;
        private FontAwesome.Sharp.IconButton BtnSelectClient;
    }
}