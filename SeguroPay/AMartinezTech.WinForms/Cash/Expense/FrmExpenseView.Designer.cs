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
            PanelAlertMessage = new Panel();
            LabelAlertMessage = new Label();
            PanelLineTop = new Panel();
            PanelButtom = new Panel();
            LabelTitle = new Label();
            PanelLineButtom = new Panel();
            CbExpenseCategory = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            BtnClear = new FontAwesome.Sharp.IconButton();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            BtnExpenseCategory = new FontAwesome.Sharp.IconButton();
            PanelAlertMessage.SuspendLayout();
            PanelButtom.SuspendLayout();
            SuspendLayout();
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(307, 35);
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
            PanelLineTop.Size = new Size(307, 2);
            PanelLineTop.TabIndex = 3;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelTitle);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 415);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(307, 35);
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
            PanelLineButtom.Location = new Point(0, 413);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(307, 2);
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
            // textBox1
            // 
            textBox1.Location = new Point(11, 128);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(184, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(10, 182);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(250, 97);
            textBox2.TabIndex = 5;
            // 
            // BtnClear
            // 
            BtnClear.Cursor = Cursors.Hand;
            BtnClear.IconChar = FontAwesome.Sharp.IconChar.File;
            BtnClear.IconColor = Color.Black;
            BtnClear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnClear.Location = new Point(11, 293);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(85, 85);
            BtnClear.TabIndex = 6;
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
            BtnPersistence.Location = new Point(176, 293);
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
            label2.Location = new Point(11, 110);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 2;
            label2.Text = "Monto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 164);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 4;
            label3.Text = "Concepto";
            // 
            // BtnExpenseCategory
            // 
            BtnExpenseCategory.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            BtnExpenseCategory.IconColor = Color.Black;
            BtnExpenseCategory.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnExpenseCategory.IconSize = 32;
            BtnExpenseCategory.Location = new Point(201, 67);
            BtnExpenseCategory.Name = "BtnExpenseCategory";
            BtnExpenseCategory.Size = new Size(32, 32);
            BtnExpenseCategory.TabIndex = 12;
            BtnExpenseCategory.UseVisualStyleBackColor = true;
            BtnExpenseCategory.Click += BtnExpenseCategory_Click;
            // 
            // FrmExpenseView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 450);
            Controls.Add(BtnExpenseCategory);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BtnPersistence);
            Controls.Add(BtnClear);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(CbExpenseCategory);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelAlertMessage);
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
        private TextBox textBox1;
        private TextBox textBox2;
        private FontAwesome.Sharp.IconButton BtnClear;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private Label label1;
        private Label label2;
        private Label label3;
        private FontAwesome.Sharp.IconButton BtnExpenseCategory;
    }
}