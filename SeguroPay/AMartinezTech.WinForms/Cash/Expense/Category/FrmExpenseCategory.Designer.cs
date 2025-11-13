namespace AMartinezTech.WinForms.Cash.Expense.Category
{
    partial class FrmExpenseCategory
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
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            BtnClear = new FontAwesome.Sharp.IconButton();
            DataGridView = new DataGridView();
            TextBoxName = new TextBox();
            label1 = new Label();
            PanelLineButtom = new Panel();
            PanelButtom = new Panel();
            LabelTitle = new Label();
            CbIsActive = new CheckBox();
            errorProvider1 = new ErrorProvider(components);
            LblLoadingData = new Label();
            PanelAlertMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            PanelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // PanelLineTop
            // 
            PanelLineTop.Dock = DockStyle.Top;
            PanelLineTop.Location = new Point(0, 35);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(654, 2);
            PanelLineTop.TabIndex = 8;
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(654, 35);
            PanelAlertMessage.TabIndex = 7;
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
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(190, 188);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 15;
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
            BtnClear.Location = new Point(20, 188);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(85, 85);
            BtnClear.TabIndex = 14;
            BtnClear.Text = "&Limpiar";
            BtnClear.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // DataGridView
            // 
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(312, 74);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(330, 199);
            DataGridView.TabIndex = 16;
            DataGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // TextBoxName
            // 
            TextBoxName.Location = new Point(20, 74);
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new Size(255, 23);
            TextBoxName.TabIndex = 13;
            TextBoxName.TextChanged += TextBoxName_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 56);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 12;
            label1.Text = "Nombre";
            // 
            // PanelLineButtom
            // 
            PanelLineButtom.Dock = DockStyle.Bottom;
            PanelLineButtom.Location = new Point(0, 295);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(654, 2);
            PanelLineButtom.TabIndex = 18;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelTitle);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 297);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(654, 35);
            PanelButtom.TabIndex = 19;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            LabelTitle.Location = new Point(13, 5);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(226, 21);
            LabelTitle.TabIndex = 0;
            LabelTitle.Text = "Maestro de categoría de gastos";
            // 
            // CbIsActive
            // 
            CbIsActive.AutoSize = true;
            CbIsActive.Checked = true;
            CbIsActive.CheckState = CheckState.Checked;
            CbIsActive.Location = new Point(216, 108);
            CbIsActive.Name = "CbIsActive";
            CbIsActive.Size = new Size(59, 19);
            CbIsActive.TabIndex = 20;
            CbIsActive.Text = "Activa";
            CbIsActive.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // LblLoadingData
            // 
            LblLoadingData.AutoSize = true;
            LblLoadingData.Font = new Font("Segoe UI", 12F);
            LblLoadingData.Location = new Point(428, 160);
            LblLoadingData.Name = "LblLoadingData";
            LblLoadingData.Size = new Size(90, 21);
            LblLoadingData.TabIndex = 21;
            LblLoadingData.Text = "Cargando....";
            LblLoadingData.Visible = false;
            // 
            // FrmExpenseCategory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 332);
            Controls.Add(LblLoadingData);
            Controls.Add(CbIsActive);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(BtnPersistence);
            Controls.Add(BtnClear);
            Controls.Add(DataGridView);
            Controls.Add(TextBoxName);
            Controls.Add(label1);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelAlertMessage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmExpenseCategory";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Categoría de gastos";
            Load += FrmExpenseCategory_Load;
            PanelAlertMessage.ResumeLayout(false);
            PanelAlertMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            PanelButtom.ResumeLayout(false);
            PanelButtom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelLineTop;
        private Panel PanelAlertMessage;
        private Label LabelAlertMessage;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private FontAwesome.Sharp.IconButton BtnClear;
        private DataGridView DataGridView;
        private TextBox TextBoxName;
        private Label label1;
        private Panel PanelLineButtom;
        private Panel PanelButtom;
        private Label LabelTitle;
        private CheckBox CbIsActive;
        private ErrorProvider errorProvider1;
        private Label LblLoadingData;
    }
}