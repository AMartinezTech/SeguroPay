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
            PolicyNo = new TextBox();
            label2 = new Label();
            Insurance = new ComboBox();
            label3 = new Label();
            PolicyType = new ComboBox();
            ClientDetail = new TextBox();
            PaymentFrequency = new ComboBox();
            label5 = new Label();
            NumericUpDownPayDay = new NumericUpDown();
            label6 = new Label();
            Amount = new TextBox();
            label7 = new Label();
            label8 = new Label();
            Note = new TextBox();
            PanelLineTop = new Panel();
            PanelAlertMessage = new Panel();
            LabelAlertMessage = new Label();
            PanelLineButtom = new Panel();
            PanelButtom = new Panel();
            LabelTitle = new Label();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            BtnClear = new FontAwesome.Sharp.IconButton();
            errorProvider1 = new ErrorProvider(components);
            BtnSelectClient = new FontAwesome.Sharp.IconButton();
            LabelAlert = new Label();
            PaymentInstallments = new TextBox();
            label9 = new Label();
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
            // PolicyNo
            // 
            PolicyNo.Location = new Point(13, 75);
            PolicyNo.Name = "PolicyNo";
            PolicyNo.Size = new Size(147, 23);
            PolicyNo.TabIndex = 1;
            PolicyNo.TextChanged += TextBoxPolicyNo_TextChanged;
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
            // Insurance
            // 
            Insurance.FormattingEnabled = true;
            Insurance.Location = new Point(13, 119);
            Insurance.Name = "Insurance";
            Insurance.Size = new Size(195, 23);
            Insurance.TabIndex = 3;
            Insurance.SelectedIndexChanged += ComboBoxInsurance_SelectedIndexChanged;
            Insurance.KeyPress += ComboBoxInsurance_KeyPress;
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
            // PolicyType
            // 
            PolicyType.FormattingEnabled = true;
            PolicyType.Location = new Point(13, 163);
            PolicyType.Name = "PolicyType";
            PolicyType.Size = new Size(197, 23);
            PolicyType.TabIndex = 5;
            PolicyType.SelectedIndexChanged += ComboBoxPolicyTypeId_SelectedIndexChanged;
            PolicyType.KeyPress += ComboBoxPolicyTypeId_KeyPress;
            // 
            // ClientDetail
            // 
            ClientDetail.Enabled = false;
            ClientDetail.Location = new Point(13, 223);
            ClientDetail.Multiline = true;
            ClientDetail.Name = "ClientDetail";
            ClientDetail.Size = new Size(197, 101);
            ClientDetail.TabIndex = 7;
            ClientDetail.TextChanged += TextBoxClient_TextChanged;
            // 
            // PaymentFrequency
            // 
            PaymentFrequency.FormattingEnabled = true;
            PaymentFrequency.Location = new Point(251, 75);
            PaymentFrequency.Name = "PaymentFrequency";
            PaymentFrequency.Size = new Size(197, 23);
            PaymentFrequency.TabIndex = 9;
            PaymentFrequency.SelectedIndexChanged += ComboBoxPayFrecuency_SelectedIndexChanged;
            PaymentFrequency.KeyPress += ComboBoxPayFrecuency_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(251, 57);
            label5.Name = "label5";
            label5.Size = new Size(110, 15);
            label5.TabIndex = 8;
            label5.Text = "Frecuencia de pago";
            // 
            // NumericUpDownPayDay
            // 
            NumericUpDownPayDay.Location = new Point(251, 119);
            NumericUpDownPayDay.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            NumericUpDownPayDay.Minimum = new decimal(new int[] { 25, 0, 0, 0 });
            NumericUpDownPayDay.Name = "NumericUpDownPayDay";
            NumericUpDownPayDay.Size = new Size(77, 23);
            NumericUpDownPayDay.TabIndex = 11;
            NumericUpDownPayDay.Value = new decimal(new int[] { 25, 0, 0, 0 });
            NumericUpDownPayDay.ValueChanged += NumericUpDownPayDay_ValueChanged;
            NumericUpDownPayDay.KeyPress += NumericUpDownPayDay_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(251, 101);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 10;
            label6.Text = "Día de pago";
            // 
            // Amount
            // 
            Amount.Location = new Point(251, 163);
            Amount.Name = "Amount";
            Amount.Size = new Size(197, 23);
            Amount.TabIndex = 15;
            Amount.Text = "0.00";
            Amount.TextChanged += TextBoxAmount_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(251, 145);
            label7.Name = "label7";
            label7.Size = new Size(100, 15);
            label7.TabIndex = 14;
            label7.Text = "Monto cuota RD$";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(251, 202);
            label8.Name = "label8";
            label8.Size = new Size(33, 15);
            label8.TabIndex = 16;
            label8.Text = "Nota";
            // 
            // Note
            // 
            Note.Location = new Point(251, 223);
            Note.Multiline = true;
            Note.Name = "Note";
            Note.Size = new Size(197, 101);
            Note.TabIndex = 17;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Dock = DockStyle.Top;
            PanelLineTop.Location = new Point(0, 35);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(478, 2);
            PanelLineTop.TabIndex = 21;
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(478, 35);
            PanelAlertMessage.TabIndex = 22;
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
            PanelLineButtom.Location = new Point(0, 453);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(478, 2);
            PanelLineButtom.TabIndex = 24;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelTitle);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 455);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(478, 35);
            PanelButtom.TabIndex = 23;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            LabelTitle.Location = new Point(13, 5);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(133, 21);
            LabelTitle.TabIndex = 0;
            LabelTitle.Text = "Maestro de poliza";
            // 
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(123, 348);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 19;
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
            BtnClear.Location = new Point(15, 348);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(85, 85);
            BtnClear.TabIndex = 18;
            BtnClear.Text = "&Limpiar";
            BtnClear.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // BtnSelectClient
            // 
            BtnSelectClient.Cursor = Cursors.Hand;
            BtnSelectClient.IconChar = FontAwesome.Sharp.IconChar.Search;
            BtnSelectClient.IconColor = Color.Black;
            BtnSelectClient.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnSelectClient.IconSize = 25;
            BtnSelectClient.Location = new Point(13, 189);
            BtnSelectClient.Name = "BtnSelectClient";
            BtnSelectClient.Size = new Size(195, 28);
            BtnSelectClient.TabIndex = 6;
            BtnSelectClient.Text = "Seleccionar Cliente";
            BtnSelectClient.TextAlign = ContentAlignment.MiddleLeft;
            BtnSelectClient.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnSelectClient.UseVisualStyleBackColor = true;
            BtnSelectClient.Click += BtnSelectClient_Click;
            // 
            // LabelAlert
            // 
            LabelAlert.AutoSize = true;
            LabelAlert.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            LabelAlert.Location = new Point(251, 348);
            LabelAlert.Name = "LabelAlert";
            LabelAlert.Size = new Size(53, 21);
            LabelAlert.TabIndex = 20;
            LabelAlert.Text = "label9";
            LabelAlert.Visible = false;
            // 
            // PaymentInstallments
            // 
            PaymentInstallments.Location = new Point(352, 119);
            PaymentInstallments.Name = "PaymentInstallments";
            PaymentInstallments.Size = new Size(96, 23);
            PaymentInstallments.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(352, 101);
            label9.Name = "label9";
            label9.Size = new Size(93, 15);
            label9.TabIndex = 12;
            label9.Text = "Cantidad cuotas";
            // 
            // FrmPolicyView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 490);
            Controls.Add(label9);
            Controls.Add(PaymentInstallments);
            Controls.Add(LabelAlert);
            Controls.Add(BtnSelectClient);
            Controls.Add(BtnPersistence);
            Controls.Add(BtnClear);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelAlertMessage);
            Controls.Add(Note);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(Amount);
            Controls.Add(label6);
            Controls.Add(NumericUpDownPayDay);
            Controls.Add(label5);
            Controls.Add(PaymentFrequency);
            Controls.Add(ClientDetail);
            Controls.Add(PolicyType);
            Controls.Add(label3);
            Controls.Add(Insurance);
            Controls.Add(label2);
            Controls.Add(PolicyNo);
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
        private TextBox PolicyNo;
        private Label label2;
        private ComboBox Insurance;
        private Label label3;
        private ComboBox PolicyType;
        private TextBox ClientDetail;
        private ComboBox PaymentFrequency;
        private Label label5;
        private NumericUpDown NumericUpDownPayDay;
        private Label label6;
        private TextBox Amount;
        private Label label7;
        private Label label8;
        private TextBox Note;
        private Panel PanelLineTop;
        private Panel PanelAlertMessage;
        private Label LabelAlertMessage;
        private Panel PanelLineButtom;
        private Panel PanelButtom;
        private Label LabelTitle;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private FontAwesome.Sharp.IconButton BtnClear;
        private ErrorProvider errorProvider1;
        private FontAwesome.Sharp.IconButton BtnSelectClient;
        private Label LabelAlert;
        private Label label9;
        private TextBox PaymentInstallments;
    }
}