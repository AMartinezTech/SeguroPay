namespace AMartinezTech.WinForms.Cash
{
    partial class FrmCashDashboardView
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
            LabelTotalClients = new Label();
            PanelLeyenda = new Panel();
            BtnPrintList = new FontAwesome.Sharp.IconButton();
            DataGridView = new DataGridView();
            label1 = new Label();
            TextBoxSearch = new TextBox();
            IconPictureBoxSearch = new FontAwesome.Sharp.IconPictureBox();
            PanelLineTop = new Panel();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            BtnOtherIncome = new FontAwesome.Sharp.IconButton();
            BtnExpense = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            dateTimePicker2 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).BeginInit();
            SuspendLayout();
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic);
            LabelTitle.Location = new Point(45, 9);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(155, 28);
            LabelTitle.TabIndex = 56;
            LabelTitle.Text = "Gestion de caja";
            // 
            // LabelTotalClients
            // 
            LabelTotalClients.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LabelTotalClients.AutoSize = true;
            LabelTotalClients.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            LabelTotalClients.Location = new Point(18, 506);
            LabelTotalClients.Name = "LabelTotalClients";
            LabelTotalClients.Size = new Size(50, 19);
            LabelTotalClients.TabIndex = 54;
            LabelTotalClients.Text = "label2";
            // 
            // PanelLeyenda
            // 
            PanelLeyenda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PanelLeyenda.Location = new Point(12, 528);
            PanelLeyenda.Name = "PanelLeyenda";
            PanelLeyenda.Size = new Size(383, 220);
            PanelLeyenda.TabIndex = 53;
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
            BtnPrintList.TabIndex = 52;
            BtnPrintList.Text = "&Imprimir listado";
            BtnPrintList.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPrintList.UseVisualStyleBackColor = true;
            BtnPrintList.Visible = false;
            // 
            // DataGridView
            // 
            DataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(12, 108);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(934, 394);
            DataGridView.TabIndex = 50;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 48);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 44;
            label1.Text = "Buscar";
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Location = new Point(45, 66);
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.Size = new Size(350, 23);
            TextBoxSearch.TabIndex = 45;
            // 
            // IconPictureBoxSearch
            // 
            IconPictureBoxSearch.BackColor = SystemColors.Control;
            IconPictureBoxSearch.ForeColor = SystemColors.ControlText;
            IconPictureBoxSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            IconPictureBoxSearch.IconColor = SystemColors.ControlText;
            IconPictureBoxSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            IconPictureBoxSearch.IconSize = 23;
            IconPictureBoxSearch.Location = new Point(16, 66);
            IconPictureBoxSearch.Name = "IconPictureBoxSearch";
            IconPictureBoxSearch.Size = new Size(25, 23);
            IconPictureBoxSearch.TabIndex = 46;
            IconPictureBoxSearch.TabStop = false;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PanelLineTop.Location = new Point(16, 95);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(925, 2);
            PanelLineTop.TabIndex = 49;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MMM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(401, 66);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(118, 23);
            dateTimePicker1.TabIndex = 57;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(401, 48);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 58;
            label2.Text = "Fecha inicio";
            // 
            // BtnOtherIncome
            // 
            BtnOtherIncome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnOtherIncome.Cursor = Cursors.Hand;
            BtnOtherIncome.IconChar = FontAwesome.Sharp.IconChar.HandHoldingUsd;
            BtnOtherIncome.IconColor = Color.Black;
            BtnOtherIncome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnOtherIncome.Location = new Point(765, 4);
            BtnOtherIncome.Name = "BtnOtherIncome";
            BtnOtherIncome.Size = new Size(85, 85);
            BtnOtherIncome.TabIndex = 59;
            BtnOtherIncome.Text = "Otros ingresos";
            BtnOtherIncome.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnOtherIncome.UseVisualStyleBackColor = true;
            // 
            // BtnExpense
            // 
            BtnExpense.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnExpense.Cursor = Cursors.Hand;
            BtnExpense.IconChar = FontAwesome.Sharp.IconChar.MoneyBills;
            BtnExpense.IconColor = Color.Black;
            BtnExpense.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnExpense.Location = new Point(856, 4);
            BtnExpense.Name = "BtnExpense";
            BtnExpense.Size = new Size(85, 85);
            BtnExpense.TabIndex = 60;
            BtnExpense.Text = "Gastos";
            BtnExpense.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnExpense.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(540, 48);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 62;
            label3.Text = "Fecha final";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "dd/MMM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(540, 66);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(118, 23);
            dateTimePicker2.TabIndex = 61;
            // 
            // FrmCashDashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 761);
            Controls.Add(label3);
            Controls.Add(dateTimePicker2);
            Controls.Add(BtnExpense);
            Controls.Add(BtnOtherIncome);
            Controls.Add(label2);
            Controls.Add(dateTimePicker1);
            Controls.Add(LabelTitle);
            Controls.Add(LabelTotalClients);
            Controls.Add(PanelLeyenda);
            Controls.Add(BtnPrintList);
            Controls.Add(DataGridView);
            Controls.Add(label1);
            Controls.Add(TextBoxSearch);
            Controls.Add(IconPictureBoxSearch);
            Controls.Add(PanelLineTop);
            Name = "FrmCashDashboardView";
            Text = "FrmCashDashboardView";
            Load += FrmCashDashboardView_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelTitle;
        private Label LabelTotalClients;
        private Panel PanelLeyenda;
        private FontAwesome.Sharp.IconButton BtnPrintList;
        private DataGridView DataGridView;
        private Label label1;
        private TextBox TextBoxSearch;
        private FontAwesome.Sharp.IconPictureBox IconPictureBoxSearch;
        private Panel PanelLineTop;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private FontAwesome.Sharp.IconButton BtnOtherIncome;
        private FontAwesome.Sharp.IconButton BtnExpense;
        private Label label3;
        private DateTimePicker dateTimePicker2;
    }
}