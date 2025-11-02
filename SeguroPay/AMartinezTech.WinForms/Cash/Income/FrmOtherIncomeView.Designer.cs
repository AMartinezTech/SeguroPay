namespace AMartinezTech.WinForms.Cash.Income
{
    partial class FrmOtherIncomeView
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
            Amount = new TextBox();
            label6 = new Label();
            ClientDetail = new TextBox();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            LabelAmount = new Label();
            label3 = new Label();
            Note = new TextBox();
            label2 = new Label();
            MadeIn = new ComboBox();
            label1 = new Label();
            PaymentMethod = new ComboBox();
            PanelLineTop = new Panel();
            PanelAlertMessage = new Panel();
            LabelAlertMessage = new Label();
            PanelLineButtom = new Panel();
            PanelButtom = new Panel();
            LabelTitle = new Label();
            errorProvider1 = new ErrorProvider(components);
            BtnSelectClient = new FontAwesome.Sharp.IconButton();
            PanelAlertMessage.SuspendLayout();
            PanelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // Amount
            // 
            Amount.Location = new Point(208, 398);
            Amount.Name = "Amount";
            Amount.Size = new Size(100, 23);
            Amount.TabIndex = 9;
            Amount.Text = "0.00";
            Amount.TextAlign = HorizontalAlignment.Right;
            Amount.TextChanged += Amount_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 64);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 0;
            label6.Text = "Cliente";
            // 
            // ClientDetail
            // 
            ClientDetail.BackColor = Color.White;
            ClientDetail.Enabled = false;
            ClientDetail.Location = new Point(12, 82);
            ClientDetail.Multiline = true;
            ClientDetail.Name = "ClientDetail";
            ClientDetail.Size = new Size(295, 96);
            ClientDetail.TabIndex = 1;
            // 
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(222, 427);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 10;
            BtnPersistence.Text = "&Guardar";
            BtnPersistence.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPersistence.UseVisualStyleBackColor = true;
            BtnPersistence.Click += BtnPersistence_Click;
            // 
            // LabelAmount
            // 
            LabelAmount.AutoSize = true;
            LabelAmount.Font = new Font("Segoe UI", 12F);
            LabelAmount.Location = new Point(104, 400);
            LabelAmount.Name = "LabelAmount";
            LabelAmount.Size = new Size(96, 21);
            LabelAmount.TabIndex = 8;
            LabelAmount.Text = "Monto.: RD$";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 269);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 6;
            label3.Text = "Nota";
            // 
            // Note
            // 
            Note.Location = new Point(13, 287);
            Note.Multiline = true;
            Note.Name = "Note";
            Note.Size = new Size(295, 105);
            Note.TabIndex = 7;
            Note.TextChanged += Note_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 225);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 4;
            label2.Text = "Realizado en";
            // 
            // MadeIn
            // 
            MadeIn.FormattingEnabled = true;
            MadeIn.Location = new Point(12, 243);
            MadeIn.Name = "MadeIn";
            MadeIn.Size = new Size(295, 23);
            MadeIn.TabIndex = 5;
            MadeIn.SelectedIndexChanged += MadeIn_SelectedIndexChanged;
            MadeIn.KeyPress += MadeIn_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 181);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 2;
            label1.Text = "Método de pago";
            // 
            // PaymentMethod
            // 
            PaymentMethod.FormattingEnabled = true;
            PaymentMethod.Location = new Point(12, 199);
            PaymentMethod.Name = "PaymentMethod";
            PaymentMethod.Size = new Size(187, 23);
            PaymentMethod.TabIndex = 3;
            PaymentMethod.SelectedIndexChanged += PaymentMethod_SelectedIndexChanged;
            PaymentMethod.KeyPress += PaymentMethod_KeyPress;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Dock = DockStyle.Top;
            PanelLineTop.Location = new Point(0, 35);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(341, 2);
            PanelLineTop.TabIndex = 49;
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(341, 35);
            PanelAlertMessage.TabIndex = 50;
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
            PanelLineButtom.Location = new Point(0, 524);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(341, 2);
            PanelLineButtom.TabIndex = 52;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelTitle);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 526);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(341, 35);
            PanelButtom.TabIndex = 51;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            LabelTitle.Location = new Point(13, 5);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(187, 21);
            LabelTitle.TabIndex = 0;
            LabelTitle.Text = "Maestro de otros ingresos";
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
            BtnSelectClient.Location = new Point(112, 52);
            BtnSelectClient.Name = "BtnSelectClient";
            BtnSelectClient.Size = new Size(195, 28);
            BtnSelectClient.TabIndex = 53;
            BtnSelectClient.Text = "Seleccionar Cliente";
            BtnSelectClient.TextAlign = ContentAlignment.MiddleLeft;
            BtnSelectClient.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnSelectClient.UseVisualStyleBackColor = true;
            BtnSelectClient.Click += BtnSelectClient_Click;
            // 
            // FrmOtherIncomeView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 561);
            Controls.Add(BtnSelectClient);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelAlertMessage);
            Controls.Add(Amount);
            Controls.Add(label6);
            Controls.Add(ClientDetail);
            Controls.Add(BtnPersistence);
            Controls.Add(LabelAmount);
            Controls.Add(label3);
            Controls.Add(Note);
            Controls.Add(label2);
            Controls.Add(MadeIn);
            Controls.Add(label1);
            Controls.Add(PaymentMethod);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmOtherIncomeView";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Otros ingresos";
            Load += FrmOtherIncomeView_Load;
            PanelAlertMessage.ResumeLayout(false);
            PanelAlertMessage.PerformLayout();
            PanelButtom.ResumeLayout(false);
            PanelButtom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Amount;
        private Label label6;
        private TextBox ClientDetail;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private Label LabelAmount;
        private Label label3;
        private TextBox Note;
        private Label label2;
        private ComboBox MadeIn;
        private Label label1;
        private ComboBox PaymentMethod;
        private Panel PanelLineTop;
        private Panel PanelAlertMessage;
        private Label LabelAlertMessage;
        private Panel PanelLineButtom;
        private Panel PanelButtom;
        private Label LabelTitle;
        private ErrorProvider errorProvider1;
        private FontAwesome.Sharp.IconButton BtnSelectClient;
    }
}