namespace AMartinezTech.WinForms.Insurance
{
    partial class FrmInsuranceDashboardView
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
            LabelTotalClients = new Label();
            PanelLeyenda = new Panel();
            CheckBoxIsActiveFilter = new CheckBox();
            DataGridView = new DataGridView();
            label1 = new Label();
            TextBoxSearch = new TextBox();
            IconPictureBoxSearch = new FontAwesome.Sharp.IconPictureBox();
            PanelLineTop = new Panel();
            LabelTitle = new Label();
            IconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            PanelClient = new Panel();
            LabelAlertMessage = new Label();
            CheckBoxIsActive = new CheckBox();
            TextBoxContactPhone = new TextBox();
            label7 = new Label();
            TextBoxContactName = new TextBox();
            label6 = new Label();
            TextBoxPhone = new TextBox();
            label5 = new Label();
            TextBoxEmail = new TextBox();
            label4 = new Label();
            TextBoxAddress = new TextBox();
            label3 = new Label();
            TextBoxName = new TextBox();
            label2 = new Label();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            BtnClear = new FontAwesome.Sharp.IconButton();
            errorProvider1 = new ErrorProvider(components);
            PanelLeyenda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).BeginInit();
            PanelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // LabelTotalClients
            // 
            LabelTotalClients.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LabelTotalClients.AutoSize = true;
            LabelTotalClients.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            LabelTotalClients.Location = new Point(3, 9);
            LabelTotalClients.Name = "LabelTotalClients";
            LabelTotalClients.Size = new Size(50, 19);
            LabelTotalClients.TabIndex = 10;
            LabelTotalClients.Text = "label2";
            // 
            // PanelLeyenda
            // 
            PanelLeyenda.Controls.Add(LabelTotalClients);
            PanelLeyenda.Location = new Point(12, 543);
            PanelLeyenda.Name = "PanelLeyenda";
            PanelLeyenda.Size = new Size(383, 115);
            PanelLeyenda.TabIndex = 11;
            // 
            // CheckBoxIsActiveFilter
            // 
            CheckBoxIsActiveFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CheckBoxIsActiveFilter.AutoSize = true;
            CheckBoxIsActiveFilter.Checked = true;
            CheckBoxIsActiveFilter.CheckState = CheckState.Checked;
            CheckBoxIsActiveFilter.Location = new Point(704, 70);
            CheckBoxIsActiveFilter.Name = "CheckBoxIsActiveFilter";
            CheckBoxIsActiveFilter.Size = new Size(96, 19);
            CheckBoxIsActiveFilter.TabIndex = 7;
            CheckBoxIsActiveFilter.Text = "Filtrar activos";
            CheckBoxIsActiveFilter.UseVisualStyleBackColor = true;
            CheckBoxIsActiveFilter.CheckedChanged += CheckBoxIsActiveFilter_CheckedChanged;
            // 
            // DataGridView
            // 
            DataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(429, 109);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(517, 428);
            DataGridView.TabIndex = 3;
            DataGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(458, 49);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 5;
            label1.Text = "Buscar";
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxSearch.Location = new Point(458, 66);
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.Size = new Size(240, 23);
            TextBoxSearch.TabIndex = 6;
            // 
            // IconPictureBoxSearch
            // 
            IconPictureBoxSearch.BackColor = SystemColors.Control;
            IconPictureBoxSearch.ForeColor = SystemColors.ControlText;
            IconPictureBoxSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            IconPictureBoxSearch.IconColor = SystemColors.ControlText;
            IconPictureBoxSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            IconPictureBoxSearch.IconSize = 23;
            IconPictureBoxSearch.Location = new Point(429, 66);
            IconPictureBoxSearch.Name = "IconPictureBoxSearch";
            IconPictureBoxSearch.Size = new Size(25, 23);
            IconPictureBoxSearch.TabIndex = 20;
            IconPictureBoxSearch.TabStop = false;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PanelLineTop.Location = new Point(12, 96);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(931, 2);
            PanelLineTop.TabIndex = 8;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic);
            LabelTitle.Location = new Point(458, 21);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(245, 28);
            LabelTitle.TabIndex = 4;
            LabelTitle.Text = "Gestion de aseguradoras";
            // 
            // IconPictureBox
            // 
            IconPictureBox.BackColor = SystemColors.Control;
            IconPictureBox.ForeColor = SystemColors.ControlText;
            IconPictureBox.IconChar = FontAwesome.Sharp.IconChar.Hospital;
            IconPictureBox.IconColor = SystemColors.ControlText;
            IconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            IconPictureBox.IconSize = 45;
            IconPictureBox.Location = new Point(14, 44);
            IconPictureBox.Name = "IconPictureBox";
            IconPictureBox.Size = new Size(45, 45);
            IconPictureBox.TabIndex = 31;
            IconPictureBox.TabStop = false;
            // 
            // PanelClient
            // 
            PanelClient.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            PanelClient.Controls.Add(LabelAlertMessage);
            PanelClient.Controls.Add(CheckBoxIsActive);
            PanelClient.Controls.Add(TextBoxContactPhone);
            PanelClient.Controls.Add(label7);
            PanelClient.Controls.Add(TextBoxContactName);
            PanelClient.Controls.Add(label6);
            PanelClient.Controls.Add(TextBoxPhone);
            PanelClient.Controls.Add(label5);
            PanelClient.Controls.Add(TextBoxEmail);
            PanelClient.Controls.Add(label4);
            PanelClient.Controls.Add(TextBoxAddress);
            PanelClient.Controls.Add(label3);
            PanelClient.Controls.Add(TextBoxName);
            PanelClient.Controls.Add(label2);
            PanelClient.Location = new Point(14, 109);
            PanelClient.Name = "PanelClient";
            PanelClient.Size = new Size(409, 337);
            PanelClient.TabIndex = 0;
            // 
            // LabelAlertMessage
            // 
            LabelAlertMessage.AutoSize = true;
            LabelAlertMessage.Font = new Font("Segoe UI", 12F);
            LabelAlertMessage.Location = new Point(0, 0);
            LabelAlertMessage.Name = "LabelAlertMessage";
            LabelAlertMessage.Size = new Size(52, 21);
            LabelAlertMessage.TabIndex = 13;
            LabelAlertMessage.Text = "label8";
            // 
            // CheckBoxIsActive
            // 
            CheckBoxIsActive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CheckBoxIsActive.AutoSize = true;
            CheckBoxIsActive.Checked = true;
            CheckBoxIsActive.CheckState = CheckState.Checked;
            CheckBoxIsActive.Location = new Point(297, 78);
            CheckBoxIsActive.Name = "CheckBoxIsActive";
            CheckBoxIsActive.Size = new Size(60, 19);
            CheckBoxIsActive.TabIndex = 12;
            CheckBoxIsActive.Text = "Activo";
            CheckBoxIsActive.UseVisualStyleBackColor = true;
            // 
            // TextBoxContactPhone
            // 
            TextBoxContactPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxContactPhone.Location = new Point(1, 311);
            TextBoxContactPhone.Name = "TextBoxContactPhone";
            TextBoxContactPhone.Size = new Size(361, 23);
            TextBoxContactPhone.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1, 293);
            label7.Name = "label7";
            label7.Size = new Size(119, 15);
            label7.TabIndex = 10;
            label7.Text = "Teléfono de contacto";
            // 
            // TextBoxContactName
            // 
            TextBoxContactName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxContactName.Location = new Point(1, 267);
            TextBoxContactName.Name = "TextBoxContactName";
            TextBoxContactName.Size = new Size(361, 23);
            TextBoxContactName.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1, 249);
            label6.Name = "label6";
            label6.Size = new Size(115, 15);
            label6.TabIndex = 8;
            label6.Text = "Persona de contacto";
            // 
            // TextBoxPhone
            // 
            TextBoxPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxPhone.Location = new Point(1, 223);
            TextBoxPhone.Name = "TextBoxPhone";
            TextBoxPhone.Size = new Size(361, 23);
            TextBoxPhone.TabIndex = 7;
            TextBoxPhone.TextChanged += TextBoxPhone_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1, 205);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 6;
            label5.Text = "Teléfono";
            // 
            // TextBoxEmail
            // 
            TextBoxEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxEmail.Location = new Point(1, 179);
            TextBoxEmail.Name = "TextBoxEmail";
            TextBoxEmail.Size = new Size(361, 23);
            TextBoxEmail.TabIndex = 5;
            TextBoxEmail.TextChanged += TextBoxEmail_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1, 161);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 4;
            label4.Text = "Correo";
            // 
            // TextBoxAddress
            // 
            TextBoxAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxAddress.Location = new Point(1, 97);
            TextBoxAddress.MaxLength = 300;
            TextBoxAddress.Multiline = true;
            TextBoxAddress.Name = "TextBoxAddress";
            TextBoxAddress.Size = new Size(361, 61);
            TextBoxAddress.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1, 79);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 2;
            label3.Text = "Dirección";
            // 
            // TextBoxName
            // 
            TextBoxName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxName.Location = new Point(1, 53);
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new Size(361, 23);
            TextBoxName.TabIndex = 1;
            TextBoxName.TextChanged += TextBoxName_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1, 35);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 0;
            label2.Text = "Compañía";
            // 
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(120, 452);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 2;
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
            BtnClear.Location = new Point(12, 452);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(85, 85);
            BtnClear.TabIndex = 1;
            BtnClear.Text = "&Limpiar";
            BtnClear.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmInsuranceDashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 670);
            Controls.Add(BtnPersistence);
            Controls.Add(BtnClear);
            Controls.Add(PanelClient);
            Controls.Add(IconPictureBox);
            Controls.Add(LabelTitle);
            Controls.Add(PanelLeyenda);
            Controls.Add(CheckBoxIsActiveFilter);
            Controls.Add(DataGridView);
            Controls.Add(label1);
            Controls.Add(TextBoxSearch);
            Controls.Add(IconPictureBoxSearch);
            Controls.Add(PanelLineTop);
            Name = "FrmInsuranceDashboardView";
            Text = "FrmInsuranceDashboardView";
            Load += FrmInsuranceDashboardView_Load;
            PanelLeyenda.ResumeLayout(false);
            PanelLeyenda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).EndInit();
            PanelClient.ResumeLayout(false);
            PanelClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelTotalClients;
        private Panel PanelLeyenda;
        private CheckBox CheckBoxIsActiveFilter;
        private DataGridView DataGridView;
        private Label label1;
        private TextBox TextBoxSearch;
        private FontAwesome.Sharp.IconPictureBox IconPictureBoxSearch;
        private Panel PanelLineTop;
        private Label LabelTitle;
        private FontAwesome.Sharp.IconPictureBox IconPictureBox;
        private Panel PanelClient;
        private TextBox TextBoxAddress;
        private Label label3;
        private TextBox TextBoxName;
        private Label label2;
        private TextBox TextBoxPhone;
        private Label label5;
        private TextBox TextBoxEmail;
        private Label label4;
        private TextBox TextBoxContactPhone;
        private Label label7;
        private TextBox TextBoxContactName;
        private Label label6;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private FontAwesome.Sharp.IconButton BtnClear;
        private CheckBox CheckBoxIsActive;
        private Label LabelAlertMessage;
        private ErrorProvider errorProvider1;
    }
}