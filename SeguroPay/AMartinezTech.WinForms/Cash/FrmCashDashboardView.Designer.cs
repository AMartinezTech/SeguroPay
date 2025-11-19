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
            components = new System.ComponentModel.Container();
            LabelTitle = new Label();
            LabelTotalClients = new Label();
            PanelIncomeFilter = new Panel();
            BtnIncomeFilter = new FontAwesome.Sharp.IconButton();
            label7 = new Label();
            ComboBoxIncomeMadeIn = new ComboBox();
            ComboBoxIncomeTypes = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            ComboBoxPaymentMethods = new ComboBox();
            BtnPrintList = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            TextBoxSearch = new TextBox();
            IconPictureBoxSearch = new FontAwesome.Sharp.IconPictureBox();
            PanelLineTop = new Panel();
            DateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            BtnOtherIncome = new FontAwesome.Sharp.IconButton();
            BtnExpense = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            DateTimePicker2 = new DateTimePicker();
            IconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            LabelAlertMessage = new Label();
            errorProvider1 = new ErrorProvider(components);
            FilterBy = new ComboBox();
            label4 = new Label();
            DataGridView = new DataGridView();
            LabelTotal = new Label();
            label9 = new Label();
            PanelIncomeFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            SuspendLayout();
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic);
            LabelTitle.Location = new Point(94, 20);
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
            LabelTotalClients.Location = new Point(6, 3);
            LabelTotalClients.Name = "LabelTotalClients";
            LabelTotalClients.Size = new Size(125, 19);
            LabelTotalClients.TabIndex = 54;
            LabelTotalClients.Text = "Filtro de ingresos";
            // 
            // PanelIncomeFilter
            // 
            PanelIncomeFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PanelIncomeFilter.Controls.Add(BtnIncomeFilter);
            PanelIncomeFilter.Controls.Add(label7);
            PanelIncomeFilter.Controls.Add(ComboBoxIncomeMadeIn);
            PanelIncomeFilter.Controls.Add(ComboBoxIncomeTypes);
            PanelIncomeFilter.Controls.Add(label6);
            PanelIncomeFilter.Controls.Add(label5);
            PanelIncomeFilter.Controls.Add(ComboBoxPaymentMethods);
            PanelIncomeFilter.Controls.Add(LabelTotalClients);
            PanelIncomeFilter.Location = new Point(12, 528);
            PanelIncomeFilter.Name = "PanelIncomeFilter";
            PanelIncomeFilter.Size = new Size(387, 220);
            PanelIncomeFilter.TabIndex = 53;
            // 
            // BtnIncomeFilter
            // 
            BtnIncomeFilter.IconChar = FontAwesome.Sharp.IconChar.Filter;
            BtnIncomeFilter.IconColor = Color.Black;
            BtnIncomeFilter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnIncomeFilter.Location = new Point(193, 92);
            BtnIncomeFilter.Name = "BtnIncomeFilter";
            BtnIncomeFilter.Size = new Size(85, 85);
            BtnIncomeFilter.TabIndex = 74;
            BtnIncomeFilter.Text = "Filtrar";
            BtnIncomeFilter.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnIncomeFilter.UseVisualStyleBackColor = true;
            BtnIncomeFilter.Click += BtnIncomeFilter_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(10, 74);
            label7.Name = "label7";
            label7.Size = new Size(76, 15);
            label7.TabIndex = 73;
            label7.Text = "Realizado en:";
            // 
            // ComboBoxIncomeMadeIn
            // 
            ComboBoxIncomeMadeIn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ComboBoxIncomeMadeIn.FormattingEnabled = true;
            ComboBoxIncomeMadeIn.Location = new Point(10, 92);
            ComboBoxIncomeMadeIn.Name = "ComboBoxIncomeMadeIn";
            ComboBoxIncomeMadeIn.Size = new Size(121, 23);
            ComboBoxIncomeMadeIn.TabIndex = 72;
            // 
            // ComboBoxIncomeTypes
            // 
            ComboBoxIncomeTypes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ComboBoxIncomeTypes.FormattingEnabled = true;
            ComboBoxIncomeTypes.Location = new Point(10, 46);
            ComboBoxIncomeTypes.Name = "ComboBoxIncomeTypes";
            ComboBoxIncomeTypes.Size = new Size(121, 23);
            ComboBoxIncomeTypes.TabIndex = 68;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(141, 28);
            label6.Name = "label6";
            label6.Size = new Size(98, 15);
            label6.TabIndex = 71;
            label6.Text = "Método de pago:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(10, 28);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 69;
            label5.Text = "Tipo:";
            // 
            // ComboBoxPaymentMethods
            // 
            ComboBoxPaymentMethods.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ComboBoxPaymentMethods.FormattingEnabled = true;
            ComboBoxPaymentMethods.Location = new Point(141, 46);
            ComboBoxPaymentMethods.Name = "ComboBoxPaymentMethods";
            ComboBoxPaymentMethods.Size = new Size(141, 23);
            ComboBoxPaymentMethods.TabIndex = 70;
            // 
            // BtnPrintList
            // 
            BtnPrintList.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnPrintList.IconChar = FontAwesome.Sharp.IconChar.Print;
            BtnPrintList.IconColor = Color.Black;
            BtnPrintList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPrintList.Location = new Point(861, 602);
            BtnPrintList.Name = "BtnPrintList";
            BtnPrintList.Size = new Size(85, 85);
            BtnPrintList.TabIndex = 52;
            BtnPrintList.Text = "&Imprimir listado";
            BtnPrintList.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPrintList.UseVisualStyleBackColor = true;
            BtnPrintList.Visible = false;
            BtnPrintList.Click += BtnPrintList_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(94, 48);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 44;
            label1.Text = "Buscar";
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Location = new Point(94, 66);
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.Size = new Size(350, 23);
            TextBoxSearch.TabIndex = 45;
            TextBoxSearch.Enter += TextBoxSearch_Enter;
            TextBoxSearch.KeyDown += TextBoxSearch_KeyDown;
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
            // DateTimePicker1
            // 
            DateTimePicker1.CustomFormat = "dd/MMM/yyyy";
            DateTimePicker1.Format = DateTimePickerFormat.Custom;
            DateTimePicker1.Location = new Point(450, 66);
            DateTimePicker1.Name = "DateTimePicker1";
            DateTimePicker1.Size = new Size(118, 23);
            DateTimePicker1.TabIndex = 57;
            DateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(450, 48);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 58;
            label2.Text = "Fecha inicio";
            // 
            // BtnOtherIncome
            // 
            BtnOtherIncome.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnOtherIncome.Cursor = Cursors.Hand;
            BtnOtherIncome.IconChar = FontAwesome.Sharp.IconChar.HandHoldingUsd;
            BtnOtherIncome.IconColor = Color.Black;
            BtnOtherIncome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnOtherIncome.Location = new Point(765, 509);
            BtnOtherIncome.Name = "BtnOtherIncome";
            BtnOtherIncome.Size = new Size(85, 85);
            BtnOtherIncome.TabIndex = 59;
            BtnOtherIncome.Text = "Otros ingresos";
            BtnOtherIncome.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnOtherIncome.UseVisualStyleBackColor = true;
            BtnOtherIncome.Click += BtnOtherIncome_Click;
            // 
            // BtnExpense
            // 
            BtnExpense.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnExpense.Cursor = Cursors.Hand;
            BtnExpense.IconChar = FontAwesome.Sharp.IconChar.MoneyBills;
            BtnExpense.IconColor = Color.Black;
            BtnExpense.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnExpense.Location = new Point(856, 509);
            BtnExpense.Name = "BtnExpense";
            BtnExpense.Size = new Size(85, 85);
            BtnExpense.TabIndex = 60;
            BtnExpense.Text = "Gastos";
            BtnExpense.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnExpense.UseVisualStyleBackColor = true;
            BtnExpense.Click += BtnExpense_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(589, 48);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 62;
            label3.Text = "Fecha final";
            // 
            // DateTimePicker2
            // 
            DateTimePicker2.CustomFormat = "dd/MMM/yyyy";
            DateTimePicker2.Format = DateTimePickerFormat.Custom;
            DateTimePicker2.Location = new Point(589, 66);
            DateTimePicker2.Name = "DateTimePicker2";
            DateTimePicker2.Size = new Size(118, 23);
            DateTimePicker2.TabIndex = 61;
            DateTimePicker2.ValueChanged += DateTimePicker2_ValueChanged;
            // 
            // IconPictureBox
            // 
            IconPictureBox.BackColor = SystemColors.Control;
            IconPictureBox.ForeColor = SystemColors.ControlText;
            IconPictureBox.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            IconPictureBox.IconColor = SystemColors.ControlText;
            IconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            IconPictureBox.IconSize = 45;
            IconPictureBox.Location = new Point(14, 44);
            IconPictureBox.Name = "IconPictureBox";
            IconPictureBox.Size = new Size(45, 45);
            IconPictureBox.TabIndex = 63;
            IconPictureBox.TabStop = false;
            // 
            // LabelAlertMessage
            // 
            LabelAlertMessage.AutoSize = true;
            LabelAlertMessage.Font = new Font("Segoe UI", 12F);
            LabelAlertMessage.Location = new Point(94, 4);
            LabelAlertMessage.Name = "LabelAlertMessage";
            LabelAlertMessage.Size = new Size(52, 21);
            LabelAlertMessage.TabIndex = 64;
            LabelAlertMessage.Text = "label8";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FilterBy
            // 
            FilterBy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FilterBy.FormattingEnabled = true;
            FilterBy.Items.AddRange(new object[] { "Ingresos", "Gastos" });
            FilterBy.Location = new Point(820, 66);
            FilterBy.Name = "FilterBy";
            FilterBy.Size = new Size(121, 23);
            FilterBy.TabIndex = 65;
            FilterBy.Text = "Ingresos";
            FilterBy.SelectedIndexChanged += FilterBy_SelectedIndexChanged;
            FilterBy.KeyPress += FilterBy_KeyPress;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(820, 48);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 66;
            label4.Text = "Filtrar por:";
            // 
            // DataGridView
            // 
            DataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(16, 103);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(925, 400);
            DataGridView.TabIndex = 67;
            DataGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // LabelTotal
            // 
            LabelTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LabelTotal.AutoSize = true;
            LabelTotal.Location = new Point(713, 69);
            LabelTotal.Name = "LabelTotal";
            LabelTotal.Size = new Size(28, 15);
            LabelTotal.TabIndex = 68;
            LabelTotal.Text = "0.00";
            LabelTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(713, 48);
            label9.Name = "label9";
            label9.Size = new Size(65, 15);
            label9.TabIndex = 69;
            label9.Text = "TOTAL RD$";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmCashDashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 761);
            Controls.Add(label9);
            Controls.Add(LabelTotal);
            Controls.Add(DataGridView);
            Controls.Add(label4);
            Controls.Add(FilterBy);
            Controls.Add(LabelAlertMessage);
            Controls.Add(IconPictureBox);
            Controls.Add(label3);
            Controls.Add(DateTimePicker2);
            Controls.Add(BtnExpense);
            Controls.Add(BtnOtherIncome);
            Controls.Add(label2);
            Controls.Add(DateTimePicker1);
            Controls.Add(LabelTitle);
            Controls.Add(PanelIncomeFilter);
            Controls.Add(BtnPrintList);
            Controls.Add(label1);
            Controls.Add(TextBoxSearch);
            Controls.Add(IconPictureBoxSearch);
            Controls.Add(PanelLineTop);
            Name = "FrmCashDashboardView";
            Text = "FrmCashDashboardView";
            Load += FrmCashDashboardView_Load;
            PanelIncomeFilter.ResumeLayout(false);
            PanelIncomeFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelTitle;
        private Label LabelTotalClients;
        private Panel PanelIncomeFilter;
        private FontAwesome.Sharp.IconButton BtnPrintList;
        private Label label1;
        private TextBox TextBoxSearch;
        private FontAwesome.Sharp.IconPictureBox IconPictureBoxSearch;
        private Panel PanelLineTop;
        private DateTimePicker DateTimePicker1;
        private Label label2;
        private FontAwesome.Sharp.IconButton BtnOtherIncome;
        private FontAwesome.Sharp.IconButton BtnExpense;
        private Label label3;
        private DateTimePicker DateTimePicker2;
        private FontAwesome.Sharp.IconPictureBox IconPictureBox;
        private Label LabelAlertMessage;
        private ErrorProvider errorProvider1;
        private Label label4;
        private ComboBox FilterBy;
        private DataGridView DataGridView;
        private Label label5;
        private ComboBox ComboBoxIncomeTypes;
        private Label label7;
        private ComboBox ComboBoxIncomeMadeIn;
        private Label label6;
        private ComboBox ComboBoxPaymentMethods;
        private FontAwesome.Sharp.IconButton BtnIncomeFilter;
        private Label LabelTotal;
        private Label label9;
    }
}