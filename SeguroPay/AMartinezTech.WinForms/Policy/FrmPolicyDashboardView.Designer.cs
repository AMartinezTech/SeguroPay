namespace AMartinezTech.WinForms.Policy
{
    partial class FrmPolicyDashboardView
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
            LabelTitle = new Label();
            BtnInsurance = new FontAwesome.Sharp.IconButton();
            LabelTotalClients = new Label();
            PanelLeyenda = new Panel();
            BtnPrintList = new FontAwesome.Sharp.IconButton();
            CheckBoxIsActived = new CheckBox();
            DataGridView = new DataGridView();
            label3 = new Label();
            ComboBoxClientType = new ComboBox();
            label1 = new Label();
            TextBoxSearch = new TextBox();
            IconPictureBoxSearch = new FontAwesome.Sharp.IconPictureBox();
            PanelLineTop = new Panel();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).BeginInit();
            SuspendLayout();
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic);
            LabelTitle.Location = new Point(134, 13);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(184, 28);
            LabelTitle.TabIndex = 43;
            LabelTitle.Text = "Gestion de polizas";
            // 
            // BtnInsurance
            // 
            BtnInsurance.Cursor = Cursors.Hand;
            BtnInsurance.Font = new Font("Segoe UI", 9F);
            BtnInsurance.IconChar = FontAwesome.Sharp.IconChar.BriefcaseMedical;
            BtnInsurance.IconColor = Color.Black;
            BtnInsurance.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnInsurance.Location = new Point(12, 13);
            BtnInsurance.Name = "BtnInsurance";
            BtnInsurance.Size = new Size(85, 85);
            BtnInsurance.TabIndex = 42;
            BtnInsurance.Text = "&Nueva";
            BtnInsurance.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnInsurance.UseVisualStyleBackColor = true;
            // 
            // LabelTotalClients
            // 
            LabelTotalClients.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LabelTotalClients.AutoSize = true;
            LabelTotalClients.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            LabelTotalClients.Location = new Point(18, 506);
            LabelTotalClients.Name = "LabelTotalClients";
            LabelTotalClients.Size = new Size(50, 19);
            LabelTotalClients.TabIndex = 41;
            LabelTotalClients.Text = "label2";
            // 
            // PanelLeyenda
            // 
            PanelLeyenda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PanelLeyenda.Location = new Point(12, 528);
            PanelLeyenda.Name = "PanelLeyenda";
            PanelLeyenda.Size = new Size(383, 220);
            PanelLeyenda.TabIndex = 40;
            // 
            // BtnPrintList
            // 
            BtnPrintList.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnPrintList.IconChar = FontAwesome.Sharp.IconChar.Print;
            BtnPrintList.IconColor = Color.Black;
            BtnPrintList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPrintList.Location = new Point(861, 512);
            BtnPrintList.Name = "BtnPrintList";
            BtnPrintList.Size = new Size(85, 85);
            BtnPrintList.TabIndex = 39;
            BtnPrintList.Text = "&Imprimir listado";
            BtnPrintList.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPrintList.UseVisualStyleBackColor = true;
            BtnPrintList.Visible = false;
            // 
            // CheckBoxIsActived
            // 
            CheckBoxIsActived.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CheckBoxIsActived.AutoSize = true;
            CheckBoxIsActived.Checked = true;
            CheckBoxIsActived.CheckState = CheckState.Checked;
            CheckBoxIsActived.Location = new Point(702, 70);
            CheckBoxIsActived.Name = "CheckBoxIsActived";
            CheckBoxIsActived.Size = new Size(65, 19);
            CheckBoxIsActived.TabIndex = 38;
            CheckBoxIsActived.Text = "Activos";
            CheckBoxIsActived.UseVisualStyleBackColor = true;
            // 
            // DataGridView
            // 
            DataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(12, 108);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(934, 394);
            DataGridView.TabIndex = 37;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(773, 48);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 34;
            label3.Text = "Tipo";
            // 
            // ComboBoxClientType
            // 
            ComboBoxClientType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ComboBoxClientType.FormattingEnabled = true;
            ComboBoxClientType.Location = new Point(773, 66);
            ComboBoxClientType.Name = "ComboBoxClientType";
            ComboBoxClientType.Size = new Size(173, 23);
            ComboBoxClientType.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 48);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 31;
            label1.Text = "Buscar";
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxSearch.Location = new Point(134, 66);
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.Size = new Size(546, 23);
            TextBoxSearch.TabIndex = 32;
            // 
            // IconPictureBoxSearch
            // 
            IconPictureBoxSearch.BackColor = SystemColors.Control;
            IconPictureBoxSearch.ForeColor = SystemColors.ControlText;
            IconPictureBoxSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            IconPictureBoxSearch.IconColor = SystemColors.ControlText;
            IconPictureBoxSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            IconPictureBoxSearch.IconSize = 23;
            IconPictureBoxSearch.Location = new Point(105, 66);
            IconPictureBoxSearch.Name = "IconPictureBoxSearch";
            IconPictureBoxSearch.Size = new Size(25, 23);
            IconPictureBoxSearch.TabIndex = 33;
            IconPictureBoxSearch.TabStop = false;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PanelLineTop.Location = new Point(105, 95);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(841, 2);
            PanelLineTop.TabIndex = 36;
            // 
            // FrmPolicyDashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 761);
            Controls.Add(LabelTitle);
            Controls.Add(BtnInsurance);
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
            Name = "FrmPolicyDashboardView";
            Text = "FrmPolicyDashboardView";
            Load += FrmPolicyDashboardView_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelTitle;
        private FontAwesome.Sharp.IconButton BtnInsurance;
        private Label LabelTotalClients;
        private Panel PanelLeyenda;
        private FontAwesome.Sharp.IconButton BtnPrintList;
        private CheckBox CheckBoxIsActived;
        private DataGridView DataGridView;
        private Label label3;
        private ComboBox ComboBoxClientType;
        private Label label1;
        private TextBox TextBoxSearch;
        private FontAwesome.Sharp.IconPictureBox IconPictureBoxSearch;
        private Panel PanelLineTop;
    }
}