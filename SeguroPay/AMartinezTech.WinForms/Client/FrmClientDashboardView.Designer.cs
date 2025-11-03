namespace AMartinezTech.WinForms.Client
{
    partial class FrmClientDashboardView
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
            BtnClient = new FontAwesome.Sharp.IconButton();
            PanelLineTop = new Panel();
            IconPictureBoxSearch = new FontAwesome.Sharp.IconPictureBox();
            TextBoxSearch = new TextBox();
            label1 = new Label();
            ComboBoxClientType = new ComboBox();
            label3 = new Label();
            DataGridView = new DataGridView();
            CheckBoxIsActive = new CheckBox();
            BtnPrintList = new FontAwesome.Sharp.IconButton();
            PanelLeyenda = new Panel();
            LabelTotalClients = new Label();
            LabelTitle = new Label();
            IconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // BtnClient
            // 
            BtnClient.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnClient.Cursor = Cursors.Hand;
            BtnClient.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            BtnClient.IconColor = Color.Black;
            BtnClient.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnClient.Location = new Point(770, 513);
            BtnClient.Name = "BtnClient";
            BtnClient.Size = new Size(85, 85);
            BtnClient.TabIndex = 0;
            BtnClient.Text = "&Nuevo";
            BtnClient.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClient.UseVisualStyleBackColor = true;
            BtnClient.Click += BtnNuevo_Click;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PanelLineTop.Location = new Point(12, 96);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(931, 2);
            PanelLineTop.TabIndex = 7;
            // 
            // IconPictureBoxSearch
            // 
            IconPictureBoxSearch.BackColor = SystemColors.Control;
            IconPictureBoxSearch.ForeColor = SystemColors.ControlText;
            IconPictureBoxSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            IconPictureBoxSearch.IconColor = SystemColors.ControlText;
            IconPictureBoxSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            IconPictureBoxSearch.IconSize = 23;
            IconPictureBoxSearch.Location = new Point(65, 66);
            IconPictureBoxSearch.Name = "IconPictureBoxSearch";
            IconPictureBoxSearch.Size = new Size(25, 23);
            IconPictureBoxSearch.TabIndex = 2;
            IconPictureBoxSearch.TabStop = false;
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Location = new Point(94, 66);
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.Size = new Size(350, 23);
            TextBoxSearch.TabIndex = 2;
            TextBoxSearch.Enter += TextBoxSearch_Enter;
            TextBoxSearch.KeyDown += TextBoxSearch_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(94, 48);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Buscar";
            // 
            // ComboBoxClientType
            // 
            ComboBoxClientType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ComboBoxClientType.FormattingEnabled = true;
            ComboBoxClientType.Location = new Point(773, 67);
            ComboBoxClientType.Name = "ComboBoxClientType";
            ComboBoxClientType.Size = new Size(173, 23);
            ComboBoxClientType.TabIndex = 4;
            ComboBoxClientType.SelectedIndexChanged += ComboBoxClientType_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(773, 49);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 3;
            label3.Text = "Filtrar por:";
            // 
            // DataGridView
            // 
            DataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(14, 108);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(934, 394);
            DataGridView.TabIndex = 8;
            DataGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // CheckBoxIsActive
            // 
            CheckBoxIsActive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CheckBoxIsActive.AutoSize = true;
            CheckBoxIsActive.Checked = true;
            CheckBoxIsActive.CheckState = CheckState.Checked;
            CheckBoxIsActive.Location = new Point(671, 69);
            CheckBoxIsActive.Name = "CheckBoxIsActive";
            CheckBoxIsActive.Size = new Size(96, 19);
            CheckBoxIsActive.TabIndex = 11;
            CheckBoxIsActive.Text = "Filtrar activos";
            CheckBoxIsActive.UseVisualStyleBackColor = true;
            CheckBoxIsActive.CheckedChanged += CheckBoxIsActive_CheckedChanged;
            // 
            // BtnPrintList
            // 
            BtnPrintList.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnPrintList.Cursor = Cursors.Hand;
            BtnPrintList.IconChar = FontAwesome.Sharp.IconChar.Print;
            BtnPrintList.IconColor = Color.Black;
            BtnPrintList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPrintList.Location = new Point(861, 513);
            BtnPrintList.Name = "BtnPrintList";
            BtnPrintList.Size = new Size(85, 85);
            BtnPrintList.TabIndex = 12;
            BtnPrintList.Text = "&Imprimir listado";
            BtnPrintList.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPrintList.UseVisualStyleBackColor = true;
            BtnPrintList.Click += BtnPrintList_Click;
            // 
            // PanelLeyenda
            // 
            PanelLeyenda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PanelLeyenda.Location = new Point(12, 529);
            PanelLeyenda.Name = "PanelLeyenda";
            PanelLeyenda.Size = new Size(383, 220);
            PanelLeyenda.TabIndex = 15;
            // 
            // LabelTotalClients
            // 
            LabelTotalClients.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LabelTotalClients.AutoSize = true;
            LabelTotalClients.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            LabelTotalClients.Location = new Point(18, 507);
            LabelTotalClients.Name = "LabelTotalClients";
            LabelTotalClients.Size = new Size(50, 19);
            LabelTotalClients.TabIndex = 16;
            LabelTotalClients.Text = "label2";
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic);
            LabelTitle.Location = new Point(94, 20);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(187, 28);
            LabelTitle.TabIndex = 17;
            LabelTitle.Text = "Gestion de clientes";
            // 
            // IconPictureBox
            // 
            IconPictureBox.BackColor = SystemColors.Control;
            IconPictureBox.ForeColor = SystemColors.ControlText;
            IconPictureBox.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            IconPictureBox.IconColor = SystemColors.ControlText;
            IconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            IconPictureBox.IconSize = 45;
            IconPictureBox.Location = new Point(14, 44);
            IconPictureBox.Name = "IconPictureBox";
            IconPictureBox.Size = new Size(45, 45);
            IconPictureBox.TabIndex = 18;
            IconPictureBox.TabStop = false;
            // 
            // FrmClientDashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 761);
            Controls.Add(IconPictureBox);
            Controls.Add(LabelTitle);
            Controls.Add(LabelTotalClients);
            Controls.Add(PanelLeyenda);
            Controls.Add(BtnPrintList);
            Controls.Add(CheckBoxIsActive);
            Controls.Add(DataGridView);
            Controls.Add(label3);
            Controls.Add(ComboBoxClientType);
            Controls.Add(label1);
            Controls.Add(TextBoxSearch);
            Controls.Add(IconPictureBoxSearch);
            Controls.Add(PanelLineTop);
            Controls.Add(BtnClient);
            Name = "FrmClientDashboardView";
            Text = "FrmClientDashboardView";
            Load += FrmClientDashboardView_Load;
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton BtnClient;
        private Panel PanelLineTop;
        private FontAwesome.Sharp.IconPictureBox IconPictureBoxSearch;
        private TextBox TextBoxSearch;
        private Label label1;
        private ComboBox ComboBoxClientType;
        private Label label3;
        private DataGridView DataGridView;
        private CheckBox CheckBoxIsActive;
        private FontAwesome.Sharp.IconButton BtnPrintList;
        private Panel PanelLeyenda;
        private Label LabelTotalClients;
        private Label LabelTitle;
        private FontAwesome.Sharp.IconPictureBox IconPictureBox;
    }
}