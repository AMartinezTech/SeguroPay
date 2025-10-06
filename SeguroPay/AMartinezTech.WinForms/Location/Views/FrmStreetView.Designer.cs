namespace AMartinezTech.WinForms.Location.Views
{
    partial class FrmStreetView
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
            TextBoxName = new TextBox();
            label1 = new Label();
            DataGridView = new DataGridView();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            BtnClear = new FontAwesome.Sharp.IconButton();
            LabelCityName = new Label();
            PanelLineTop = new Panel();
            PanelAlertMessage = new Panel();
            LabelAlertMessage = new Label();
            PanelLineButtom = new Panel();
            PanelButtom = new Panel();
            LabelTitle = new Label();
            errorProvider1 = new ErrorProvider(components);
            TextBoxSearch = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            PanelAlertMessage.SuspendLayout();
            PanelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // TextBoxName
            // 
            TextBoxName.Location = new Point(25, 70);
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new Size(255, 23);
            TextBoxName.TabIndex = 1;
            TextBoxName.TextChanged += TextBoxName_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 52);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre completo";
            // 
            // DataGridView
            // 
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(309, 97);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(330, 237);
            DataGridView.TabIndex = 4;
            DataGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(195, 249);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 3;
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
            BtnClear.Location = new Point(25, 249);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(85, 85);
            BtnClear.TabIndex = 2;
            BtnClear.Text = "&Limpiar";
            BtnClear.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // LabelCityName
            // 
            LabelCityName.AutoSize = true;
            LabelCityName.Location = new Point(25, 131);
            LabelCityName.Name = "LabelCityName";
            LabelCityName.Size = new Size(118, 15);
            LabelCityName.TabIndex = 7;
            LabelCityName.Text = "Nombre de la ciudad";
            // 
            // PanelLineTop
            // 
            PanelLineTop.Dock = DockStyle.Top;
            PanelLineTop.Location = new Point(0, 35);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(654, 2);
            PanelLineTop.TabIndex = 6;
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(654, 35);
            PanelAlertMessage.TabIndex = 5;
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
            PanelLineButtom.Location = new Point(0, 353);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(654, 2);
            PanelLineButtom.TabIndex = 8;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelTitle);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 355);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(654, 35);
            PanelButtom.TabIndex = 9;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            LabelTitle.Location = new Point(13, 5);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(129, 21);
            LabelTitle.TabIndex = 0;
            LabelTitle.Text = "Maestro de calles";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Location = new Point(310, 68);
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.Size = new Size(329, 23);
            TextBoxSearch.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(311, 48);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 11;
            label2.Text = "Buscar";
            // 
            // FrmStreetView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 390);
            Controls.Add(label2);
            Controls.Add(TextBoxSearch);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelAlertMessage);
            Controls.Add(LabelCityName);
            Controls.Add(BtnPersistence);
            Controls.Add(BtnClear);
            Controls.Add(DataGridView);
            Controls.Add(TextBoxName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmStreetView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calles";
            Load += FrmStreetView_Load;
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

        private TextBox TextBoxName;
        private Label label1;
        private DataGridView DataGridView;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private FontAwesome.Sharp.IconButton BtnClear;
        private Panel PanelLineTop;
        private Panel PanelAlertMessage;
        private Label LabelAlertMessage;
        private Panel PanelLineButtom;
        private Panel PanelButtom;
        private Label LabelTitle;
        private ErrorProvider errorProvider1;
        public Label LabelCityName;
        private Label label2;
        private TextBox TextBoxSearch;
    }
}