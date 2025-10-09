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
            BtnNuevo = new FontAwesome.Sharp.IconButton();
            PanelLineTop = new Panel();
            IconPictureBoxSearch = new FontAwesome.Sharp.IconPictureBox();
            TextBoxSearch = new TextBox();
            label1 = new Label();
            ComboBoxClientType = new ComboBox();
            label3 = new Label();
            DataGridView = new DataGridView();
            CheckBoxIsActived = new CheckBox();
            BtnPrintList = new FontAwesome.Sharp.IconButton();
            PanelLeyenda = new Panel();
            LabelTotalClients = new Label();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            SuspendLayout();
            // 
            // BtnNuevo
            // 
            BtnNuevo.Cursor = Cursors.Hand;
            BtnNuevo.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            BtnNuevo.IconColor = Color.Black;
            BtnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnNuevo.Location = new Point(12, 12);
            BtnNuevo.Name = "BtnNuevo";
            BtnNuevo.Size = new Size(85, 85);
            BtnNuevo.TabIndex = 0;
            BtnNuevo.Text = "&Nuevo";
            BtnNuevo.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnNuevo.UseVisualStyleBackColor = true;
            BtnNuevo.Click += BtnNuevo_Click;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PanelLineTop.Location = new Point(105, 96);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(841, 2);
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
            IconPictureBoxSearch.Location = new Point(105, 67);
            IconPictureBoxSearch.Name = "IconPictureBoxSearch";
            IconPictureBoxSearch.Size = new Size(25, 23);
            IconPictureBoxSearch.TabIndex = 2;
            IconPictureBoxSearch.TabStop = false;
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxSearch.Location = new Point(134, 67);
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.Size = new Size(546, 23);
            TextBoxSearch.TabIndex = 2;
            TextBoxSearch.KeyDown += TextBoxSearch_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 49);
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
            label3.Size = new Size(31, 15);
            label3.TabIndex = 3;
            label3.Text = "Tipo";
            // 
            // DataGridView
            // 
            DataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(12, 109);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(934, 394);
            DataGridView.TabIndex = 8;
            DataGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // CheckBoxIsActived
            // 
            CheckBoxIsActived.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CheckBoxIsActived.AutoSize = true;
            CheckBoxIsActived.Checked = true;
            CheckBoxIsActived.CheckState = CheckState.Checked;
            CheckBoxIsActived.Location = new Point(702, 71);
            CheckBoxIsActived.Name = "CheckBoxIsActived";
            CheckBoxIsActived.Size = new Size(65, 19);
            CheckBoxIsActived.TabIndex = 11;
            CheckBoxIsActived.Text = "Activos";
            CheckBoxIsActived.UseVisualStyleBackColor = true;
            CheckBoxIsActived.CheckedChanged += CheckBoxIsActived_CheckedChanged;
            // 
            // BtnPrintList
            // 
            BtnPrintList.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
            BtnPrintList.Visible = false;
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
            // FrmClientDashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 761);
            Controls.Add(LabelTotalClients);
            Controls.Add(PanelLeyenda);
            Controls.Add(BtnPrintList);
            Controls.Add(CheckBoxIsActived);
            Controls.Add(DataGridView);
            Controls.Add(label3);
            Controls.Add(ComboBoxClientType);
            Controls.Add(label1);
            Controls.Add(TextBoxSearch);
            Controls.Add(IconPictureBoxSearch);
            Controls.Add(PanelLineTop);
            Controls.Add(BtnNuevo);
            Name = "FrmClientDashboardView";
            Text = "FrmClientDashboardView";
            Load += FrmClientDashboardView_Load;
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton BtnNuevo;
        private Panel PanelLineTop;
        private FontAwesome.Sharp.IconPictureBox IconPictureBoxSearch;
        private TextBox TextBoxSearch;
        private Label label1;
        private ComboBox ComboBoxClientType;
        private Label label3;
        private DataGridView DataGridView;
        private CheckBox CheckBoxIsActived;
        private FontAwesome.Sharp.IconButton BtnPrintList;
        private Panel PanelLeyenda;
        private Label LabelTotalClients;
    }
}