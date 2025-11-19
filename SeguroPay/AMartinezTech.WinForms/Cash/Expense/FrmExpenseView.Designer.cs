namespace AMartinezTech.WinForms.Cash.Expense
{
    partial class FrmExpenseView
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
            PanelAlertMessage = new Panel();
            LabelAlertMessage = new Label();
            PanelLineTop = new Panel();
            PanelButtom = new Panel();
            LabelTitle = new Label();
            PanelLineButtom = new Panel();
            CbExpenseCategory = new ComboBox();
            TextBoxAmount = new TextBox();
            TextBoxNote = new TextBox();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            BtnExpenseCategory = new FontAwesome.Sharp.IconButton();
            errorProvider1 = new ErrorProvider(components);
            PanelAlertMessage.SuspendLayout();
            PanelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(410, 35);
            PanelAlertMessage.TabIndex = 2;
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
            PanelLineTop.Size = new Size(410, 2);
            PanelLineTop.TabIndex = 3;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelTitle);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 389);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(410, 35);
            PanelButtom.TabIndex = 11;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            LabelTitle.Location = new Point(13, 5);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(135, 21);
            LabelTitle.TabIndex = 0;
            LabelTitle.Text = "Maestro de gastos";
            // 
            // PanelLineButtom
            // 
            PanelLineButtom.Dock = DockStyle.Bottom;
            PanelLineButtom.Location = new Point(0, 387);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(410, 2);
            PanelLineButtom.TabIndex = 10;
            // 
            // CbExpenseCategory
            // 
            CbExpenseCategory.FormattingEnabled = true;
            CbExpenseCategory.Location = new Point(11, 73);
            CbExpenseCategory.Name = "CbExpenseCategory";
            CbExpenseCategory.Size = new Size(184, 23);
            CbExpenseCategory.TabIndex = 1;
            CbExpenseCategory.SelectedIndexChanged += CbExpenseCategory_SelectedIndexChanged;
            // 
            // TextBoxAmount
            // 
            TextBoxAmount.Location = new Point(216, 73);
            TextBoxAmount.Name = "TextBoxAmount";
            TextBoxAmount.Size = new Size(165, 23);
            TextBoxAmount.TabIndex = 3;
            TextBoxAmount.TextChanged += TextBoxAmount_TextChanged;
            // 
            // TextBoxNote
            // 
            TextBoxNote.Location = new Point(11, 117);
            TextBoxNote.Multiline = true;
            TextBoxNote.Name = "TextBoxNote";
            TextBoxNote.Size = new Size(371, 172);
            TextBoxNote.TabIndex = 5;
            // 
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(296, 294);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 7;
            BtnPersistence.Text = "&Guardar";
            BtnPersistence.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPersistence.UseVisualStyleBackColor = true;
            BtnPersistence.Click += BtnPersistence_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 55);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 0;
            label1.Text = "Categoría";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(216, 55);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 2;
            label2.Text = "Monto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 99);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 4;
            label3.Text = "Concepto";
            // 
            // BtnExpenseCategory
            // 
            BtnExpenseCategory.Cursor = Cursors.Hand;
            BtnExpenseCategory.FlatAppearance.BorderSize = 0;
            BtnExpenseCategory.FlatStyle = FlatStyle.Flat;
            BtnExpenseCategory.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            BtnExpenseCategory.IconColor = Color.Black;
            BtnExpenseCategory.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnExpenseCategory.IconSize = 32;
            BtnExpenseCategory.Location = new Point(163, 46);
            BtnExpenseCategory.Name = "BtnExpenseCategory";
            BtnExpenseCategory.Size = new Size(32, 33);
            BtnExpenseCategory.TabIndex = 12;
            BtnExpenseCategory.UseVisualStyleBackColor = true;
            BtnExpenseCategory.Click += BtnExpenseCategory_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmExpenseView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 424);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BtnPersistence);
            Controls.Add(TextBoxNote);
            Controls.Add(TextBoxAmount);
            Controls.Add(CbExpenseCategory);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelAlertMessage);
            Controls.Add(BtnExpenseCategory);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmExpenseView";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gastos";
            Load += FrmExpenseView_Load;
            PanelAlertMessage.ResumeLayout(false);
            PanelAlertMessage.PerformLayout();
            PanelButtom.ResumeLayout(false);
            PanelButtom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelAlertMessage;
        private Label LabelAlertMessage;
        private Panel PanelLineTop;
        private Panel PanelButtom;
        private Label LabelTitle;
        private Panel PanelLineButtom;
        private ComboBox CbExpenseCategory;
        private TextBox TextBoxAmount;
        private TextBox TextBoxNote;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private Label label1;
        private Label label2;
        private Label label3;
        private FontAwesome.Sharp.IconButton BtnExpenseCategory;
        private ErrorProvider errorProvider1;
    }
}