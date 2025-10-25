namespace AMartinezTech.WinForms.Cash.Income
{
    partial class FrmIncomeView
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
            PaymentMethod = new ComboBox();
            label1 = new Label();
            MadeIn = new ComboBox();
            label2 = new Label();
            Note = new TextBox();
            label3 = new Label();
            Amount = new Label();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            PanelLineTop = new Panel();
            PanelAlertMessage = new Panel();
            LabelAlertMessage = new Label();
            PanelLineButtom = new Panel();
            PanelButtom = new Panel();
            LabelTitle = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            PanelAlertMessage.SuspendLayout();
            PanelButtom.SuspendLayout();
            SuspendLayout();
            // 
            // PaymentMethod
            // 
            PaymentMethod.FormattingEnabled = true;
            PaymentMethod.Location = new Point(13, 144);
            PaymentMethod.Name = "PaymentMethod";
            PaymentMethod.Size = new Size(187, 23);
            PaymentMethod.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 126);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 1;
            label1.Text = "Método de pago";
            // 
            // MadeIn
            // 
            MadeIn.FormattingEnabled = true;
            MadeIn.Location = new Point(13, 199);
            MadeIn.Name = "MadeIn";
            MadeIn.Size = new Size(295, 23);
            MadeIn.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 181);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 3;
            label2.Text = "Medio de pago";
            // 
            // Note
            // 
            Note.Location = new Point(13, 256);
            Note.Multiline = true;
            Note.Name = "Note";
            Note.Size = new Size(295, 105);
            Note.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 238);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 5;
            label3.Text = "Nota";
            // 
            // Amount
            // 
            Amount.AutoSize = true;
            Amount.Font = new Font("Segoe UI", 12F);
            Amount.Location = new Point(178, 387);
            Amount.Name = "Amount";
            Amount.Size = new Size(130, 21);
            Amount.TabIndex = 6;
            Amount.Text = "Monto.: RD$ 0.00";
            // 
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(223, 424);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 20;
            BtnPersistence.Text = "&Guardar";
            BtnPersistence.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPersistence.UseVisualStyleBackColor = true;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Dock = DockStyle.Top;
            PanelLineTop.Location = new Point(0, 35);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(341, 2);
            PanelLineTop.TabIndex = 23;
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(341, 35);
            PanelAlertMessage.TabIndex = 24;
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
            PanelLineButtom.Location = new Point(0, 541);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(341, 2);
            PanelLineButtom.TabIndex = 26;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelTitle);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 543);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(341, 35);
            PanelButtom.TabIndex = 25;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            LabelTitle.Location = new Point(13, 5);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(142, 21);
            LabelTitle.TabIndex = 0;
            LabelTitle.Text = "Maestro de ingreso";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(13, 40);
            label4.Name = "label4";
            label4.Size = new Size(147, 20);
            label4.TabIndex = 27;
            label4.Text = "Aseguradora: Senasa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.Location = new Point(13, 60);
            label5.Name = "label5";
            label5.Size = new Size(158, 20);
            label5.TabIndex = 28;
            label5.Text = "Póliza NO.......: 9827383";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(13, 80);
            label6.Name = "label6";
            label6.Size = new Size(280, 20);
            label6.TabIndex = 29;
            label6.Text = "Cliente..............: Alexis Martínez De La Cruz";
            // 
            // FrmIncomeView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 578);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelAlertMessage);
            Controls.Add(BtnPersistence);
            Controls.Add(Amount);
            Controls.Add(label3);
            Controls.Add(Note);
            Controls.Add(label2);
            Controls.Add(MadeIn);
            Controls.Add(label1);
            Controls.Add(PaymentMethod);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmIncomeView";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ingreso";
            PanelAlertMessage.ResumeLayout(false);
            PanelAlertMessage.PerformLayout();
            PanelButtom.ResumeLayout(false);
            PanelButtom.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox PaymentMethod;
        private Label label1;
        private ComboBox MadeIn;
        private Label label2;
        private TextBox Note;
        private Label label3;
        private Label Amount;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private Panel PanelLineTop;
        private Panel PanelAlertMessage;
        private Label LabelAlertMessage;
        private Panel PanelLineButtom;
        private Panel PanelButtom;
        private Label LabelTitle;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}