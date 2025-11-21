namespace AMartinezTech.WinForms
{
    partial class FrmBankDashboardView
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
            label3 = new Label();
            dateTimePicker2 = new DateTimePicker();
            BtnMovement = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            LabelTitle = new Label();
            LabelTotalClients = new Label();
            PanelLeyenda = new Panel();
            BtnPrintList = new FontAwesome.Sharp.IconButton();
            DataGridView = new DataGridView();
            label1 = new Label();
            TextBoxSearch = new TextBox();
            IconPictureBoxSearch = new FontAwesome.Sharp.IconPictureBox();
            PanelLineTop = new Panel();
            BtnBankAccount = new FontAwesome.Sharp.IconButton();
            comboBox1 = new ComboBox();
            label4 = new Label();
            IconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(589, 48);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 77;
            label3.Text = "Fecha final";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "dd/MMM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(589, 66);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(118, 23);
            dateTimePicker2.TabIndex = 76;
            // 
            // BtnMovement
            // 
            BtnMovement.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnMovement.Cursor = Cursors.Hand;
            BtnMovement.IconChar = FontAwesome.Sharp.IconChar.MoneyBills;
            BtnMovement.IconColor = Color.Black;
            BtnMovement.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnMovement.Location = new Point(770, 516);
            BtnMovement.Name = "BtnMovement";
            BtnMovement.Size = new Size(85, 85);
            BtnMovement.TabIndex = 75;
            BtnMovement.Text = "Crear movimiento";
            BtnMovement.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnMovement.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(450, 48);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 73;
            label2.Text = "Fecha inicio";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MMM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(450, 66);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(118, 23);
            dateTimePicker1.TabIndex = 72;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic);
            LabelTitle.Location = new Point(94, 20);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(174, 28);
            LabelTitle.TabIndex = 71;
            LabelTitle.Text = "Gestion de banco";
            // 
            // LabelTotalClients
            // 
            LabelTotalClients.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LabelTotalClients.AutoSize = true;
            LabelTotalClients.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            LabelTotalClients.Location = new Point(18, 510);
            LabelTotalClients.Name = "LabelTotalClients";
            LabelTotalClients.Size = new Size(50, 19);
            LabelTotalClients.TabIndex = 70;
            LabelTotalClients.Text = "label2";
            // 
            // PanelLeyenda
            // 
            PanelLeyenda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PanelLeyenda.Location = new Point(12, 532);
            PanelLeyenda.Name = "PanelLeyenda";
            PanelLeyenda.Size = new Size(383, 220);
            PanelLeyenda.TabIndex = 69;
            // 
            // BtnPrintList
            // 
            BtnPrintList.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnPrintList.IconChar = FontAwesome.Sharp.IconChar.Print;
            BtnPrintList.IconColor = Color.Black;
            BtnPrintList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPrintList.Location = new Point(861, 516);
            BtnPrintList.Name = "BtnPrintList";
            BtnPrintList.Size = new Size(85, 85);
            BtnPrintList.TabIndex = 68;
            BtnPrintList.Text = "&Imprimir listado";
            BtnPrintList.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPrintList.UseVisualStyleBackColor = true;
            // 
            // DataGridView
            // 
            DataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(14, 108);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(934, 394);
            DataGridView.TabIndex = 67;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(94, 48);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 63;
            label1.Text = "Buscar";
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Location = new Point(94, 66);
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.Size = new Size(350, 23);
            TextBoxSearch.TabIndex = 64;
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
            IconPictureBoxSearch.TabIndex = 65;
            IconPictureBoxSearch.TabStop = false;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PanelLineTop.Location = new Point(12, 95);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(931, 2);
            PanelLineTop.TabIndex = 66;
            // 
            // BtnBankAccount
            // 
            BtnBankAccount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnBankAccount.Cursor = Cursors.Hand;
            BtnBankAccount.Font = new Font("Segoe UI", 9F);
            BtnBankAccount.IconChar = FontAwesome.Sharp.IconChar.Building;
            BtnBankAccount.IconColor = Color.Black;
            BtnBankAccount.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnBankAccount.Location = new Point(679, 516);
            BtnBankAccount.Name = "BtnBankAccount";
            BtnBankAccount.Size = new Size(85, 85);
            BtnBankAccount.TabIndex = 78;
            BtnBankAccount.Text = "&Crear cuenta";
            BtnBankAccount.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnBankAccount.UseVisualStyleBackColor = true;
            BtnBankAccount.Click += BtnBankAccount_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(450, 19);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(259, 23);
            comboBox1.TabIndex = 79;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(450, 1);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 80;
            label4.Text = "Cuenta bancaria";
            // 
            // IconPictureBox
            // 
            IconPictureBox.BackColor = SystemColors.Control;
            IconPictureBox.ForeColor = SystemColors.ControlText;
            IconPictureBox.IconChar = FontAwesome.Sharp.IconChar.Building;
            IconPictureBox.IconColor = SystemColors.ControlText;
            IconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            IconPictureBox.IconSize = 45;
            IconPictureBox.Location = new Point(14, 44);
            IconPictureBox.Name = "IconPictureBox";
            IconPictureBox.Size = new Size(45, 45);
            IconPictureBox.TabIndex = 81;
            IconPictureBox.TabStop = false;
            // 
            // FrmBankDashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 761);
            Controls.Add(IconPictureBox);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(BtnBankAccount);
            Controls.Add(label3);
            Controls.Add(dateTimePicker2);
            Controls.Add(BtnMovement);
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
            Name = "FrmBankDashboardView";
            Text = "FrmBankDashboardView";
            Load += FrmBankDashboardView_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private DateTimePicker dateTimePicker2;
        private FontAwesome.Sharp.IconButton BtnMovement;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Label LabelTitle;
        private Label LabelTotalClients;
        private Panel PanelLeyenda;
        private FontAwesome.Sharp.IconButton BtnPrintList;
        private DataGridView DataGridView;
        private Label label1;
        private TextBox TextBoxSearch;
        private FontAwesome.Sharp.IconPictureBox IconPictureBoxSearch;
        private Panel PanelLineTop;
        private FontAwesome.Sharp.IconButton BtnBankAccount;
        private ComboBox comboBox1;
        private Label label4;
        private FontAwesome.Sharp.IconPictureBox IconPictureBox;
    }
}