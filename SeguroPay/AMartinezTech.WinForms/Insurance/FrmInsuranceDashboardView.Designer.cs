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
            LabelTotalClients = new Label();
            PanelLeyenda = new Panel();
            BtnPrintList = new FontAwesome.Sharp.IconButton();
            CheckBoxIsActived = new CheckBox();
            DataGridView = new DataGridView();
            label1 = new Label();
            TextBoxSearch = new TextBox();
            IconPictureBoxSearch = new FontAwesome.Sharp.IconPictureBox();
            PanelLineTop = new Panel();
            LabelTitle = new Label();
            IconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            PanelClient = new Panel();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // LabelTotalClients
            // 
            LabelTotalClients.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LabelTotalClients.AutoSize = true;
            LabelTotalClients.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            LabelTotalClients.Location = new Point(18, 507);
            LabelTotalClients.Name = "LabelTotalClients";
            LabelTotalClients.Size = new Size(50, 19);
            LabelTotalClients.TabIndex = 28;
            LabelTotalClients.Text = "label2";
            // 
            // PanelLeyenda
            // 
            PanelLeyenda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PanelLeyenda.Location = new Point(12, 529);
            PanelLeyenda.Name = "PanelLeyenda";
            PanelLeyenda.Size = new Size(383, 220);
            PanelLeyenda.TabIndex = 27;
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
            BtnPrintList.TabIndex = 26;
            BtnPrintList.Text = "&Imprimir listado";
            BtnPrintList.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPrintList.UseVisualStyleBackColor = true;
            BtnPrintList.Visible = false;
            // 
            // CheckBoxIsActived
            // 
            CheckBoxIsActived.AutoSize = true;
            CheckBoxIsActived.Checked = true;
            CheckBoxIsActived.CheckState = CheckState.Checked;
            CheckBoxIsActived.Location = new Point(702, 71);
            CheckBoxIsActived.Name = "CheckBoxIsActived";
            CheckBoxIsActived.Size = new Size(65, 19);
            CheckBoxIsActived.TabIndex = 25;
            CheckBoxIsActived.Text = "Activos";
            CheckBoxIsActived.UseVisualStyleBackColor = true;
            // 
            // DataGridView
            // 
            DataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(408, 109);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(538, 394);
            DataGridView.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 49);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 18;
            label1.Text = "Buscar";
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Location = new Point(134, 67);
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.Size = new Size(546, 23);
            TextBoxSearch.TabIndex = 19;
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
            IconPictureBoxSearch.TabIndex = 20;
            IconPictureBoxSearch.TabStop = false;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PanelLineTop.Location = new Point(12, 96);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(931, 2);
            PanelLineTop.TabIndex = 23;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic);
            LabelTitle.Location = new Point(134, 14);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(245, 28);
            LabelTitle.TabIndex = 30;
            LabelTitle.Text = "Gestion de aseguradoras";
            // 
            // IconPictureBox
            // 
            IconPictureBox.BackColor = SystemColors.Control;
            IconPictureBox.ForeColor = SystemColors.ControlText;
            IconPictureBox.IconChar = FontAwesome.Sharp.IconChar.Hospital;
            IconPictureBox.IconColor = SystemColors.ControlText;
            IconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            IconPictureBox.IconSize = 85;
            IconPictureBox.Location = new Point(12, 5);
            IconPictureBox.Name = "IconPictureBox";
            IconPictureBox.Size = new Size(85, 85);
            IconPictureBox.TabIndex = 31;
            IconPictureBox.TabStop = false;
            // 
            // PanelClient
            // 
            PanelClient.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            PanelClient.BorderStyle = BorderStyle.FixedSingle;
            PanelClient.Location = new Point(14, 109);
            PanelClient.Name = "PanelClient";
            PanelClient.Size = new Size(381, 394);
            PanelClient.TabIndex = 32;
            // 
            // FrmInsuranceDashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 761);
            Controls.Add(PanelClient);
            Controls.Add(IconPictureBox);
            Controls.Add(LabelTitle);
            Controls.Add(LabelTotalClients);
            Controls.Add(PanelLeyenda);
            Controls.Add(BtnPrintList);
            Controls.Add(CheckBoxIsActived);
            Controls.Add(DataGridView);
            Controls.Add(label1);
            Controls.Add(TextBoxSearch);
            Controls.Add(IconPictureBoxSearch);
            Controls.Add(PanelLineTop);
            Name = "FrmInsuranceDashboardView";
            Text = "FrmInsuranceDashboardView";
            Load += FrmInsuranceDashboardView_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelTotalClients;
        private Panel PanelLeyenda;
        private FontAwesome.Sharp.IconButton BtnPrintList;
        private CheckBox CheckBoxIsActived;
        private DataGridView DataGridView;
        private Label label1;
        private TextBox TextBoxSearch;
        private FontAwesome.Sharp.IconPictureBox IconPictureBoxSearch;
        private Panel PanelLineTop;
        private Label LabelTitle;
        private FontAwesome.Sharp.IconPictureBox IconPictureBox;
        private Panel PanelClient;
    }
}