namespace AMartinezTech.WinForms.Policy.Type
{
    partial class FrmPolicyTypeView
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
            TextBoxName = new TextBox();
            CheckBoxIsActive = new CheckBox();
            DataGridView = new DataGridView();
            PanelLineTop = new Panel();
            PanelAlertMessage = new Panel();
            LabelAlertMessage = new Label();
            PanelLineButtom = new Panel();
            PanelButtom = new Panel();
            LabelTitle = new Label();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            BtnClear = new FontAwesome.Sharp.IconButton();
            CheckBoxFilterByIsActive = new CheckBox();
            errorProvider1 = new ErrorProvider(components);
            LabelInsuranceName = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            PanelAlertMessage.SuspendLayout();
            PanelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 98);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 2;
            label1.Text = "Nombre";
            // 
            // TextBoxName
            // 
            TextBoxName.Location = new Point(25, 116);
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new Size(252, 23);
            TextBoxName.TabIndex = 3;
            TextBoxName.TextChanged += TextBoxName_TextChanged;
            // 
            // CheckBoxIsActive
            // 
            CheckBoxIsActive.AutoSize = true;
            CheckBoxIsActive.Checked = true;
            CheckBoxIsActive.CheckState = CheckState.Checked;
            CheckBoxIsActive.Enabled = false;
            CheckBoxIsActive.Location = new Point(25, 145);
            CheckBoxIsActive.Name = "CheckBoxIsActive";
            CheckBoxIsActive.Size = new Size(60, 19);
            CheckBoxIsActive.TabIndex = 4;
            CheckBoxIsActive.Text = "Activo";
            CheckBoxIsActive.UseVisualStyleBackColor = true;
            // 
            // DataGridView
            // 
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(302, 71);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(337, 221);
            DataGridView.TabIndex = 5;
            DataGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Dock = DockStyle.Top;
            PanelLineTop.Location = new Point(0, 35);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(670, 2);
            PanelLineTop.TabIndex = 21;
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(670, 35);
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
            // PanelLineButtom
            // 
            PanelLineButtom.Dock = DockStyle.Bottom;
            PanelLineButtom.Location = new Point(0, 309);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(670, 2);
            PanelLineButtom.TabIndex = 25;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelTitle);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 311);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(670, 35);
            PanelButtom.TabIndex = 24;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            LabelTitle.Location = new Point(13, 5);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(197, 21);
            LabelTitle.TabIndex = 1;
            LabelTitle.Text = "Maestro de tipos de polizas";
            // 
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(192, 207);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 23;
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
            BtnClear.Location = new Point(22, 207);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(85, 85);
            BtnClear.TabIndex = 22;
            BtnClear.Text = "&Limpiar";
            BtnClear.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // CheckBoxFilterByIsActive
            // 
            CheckBoxFilterByIsActive.AutoSize = true;
            CheckBoxFilterByIsActive.Checked = true;
            CheckBoxFilterByIsActive.CheckState = CheckState.Checked;
            CheckBoxFilterByIsActive.Location = new Point(543, 49);
            CheckBoxFilterByIsActive.Name = "CheckBoxFilterByIsActive";
            CheckBoxFilterByIsActive.Size = new Size(96, 19);
            CheckBoxFilterByIsActive.TabIndex = 26;
            CheckBoxFilterByIsActive.Text = "Filtrar activos";
            CheckBoxFilterByIsActive.UseVisualStyleBackColor = true;
            CheckBoxFilterByIsActive.CheckedChanged += CheckBoxFilterByIsActive_CheckedChanged;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // LabelInsuranceName
            // 
            LabelInsuranceName.AutoSize = true;
            LabelInsuranceName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            LabelInsuranceName.Location = new Point(28, 55);
            LabelInsuranceName.Name = "LabelInsuranceName";
            LabelInsuranceName.Size = new Size(51, 20);
            LabelInsuranceName.TabIndex = 27;
            LabelInsuranceName.Text = "label2";
            // 
            // FrmPolicyTypeView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(670, 346);
            Controls.Add(LabelInsuranceName);
            Controls.Add(CheckBoxFilterByIsActive);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(BtnPersistence);
            Controls.Add(BtnClear);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelAlertMessage);
            Controls.Add(DataGridView);
            Controls.Add(CheckBoxIsActive);
            Controls.Add(TextBoxName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPolicyTypeView";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tipo de poliza";
            Load += FrmPolicyTypeView_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
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
        private TextBox TextBoxName;
        private CheckBox CheckBoxIsActive;
        private DataGridView DataGridView;
        private Panel PanelLineTop;
        private Panel PanelAlertMessage;
        private Label LabelAlertMessage;
        private Panel PanelLineButtom;
        private Panel PanelButtom;
        private Label LabelTitle;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private FontAwesome.Sharp.IconButton BtnClear;
        private CheckBox CheckBoxFilterByIsActive;
        private ErrorProvider errorProvider1;
        public Label LabelInsuranceName;
    }
}