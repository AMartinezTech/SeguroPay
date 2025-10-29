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
            components = new System.ComponentModel.Container();
            LabelTitle = new Label();
            BtnInsurance = new FontAwesome.Sharp.IconButton();
            LabelTotalClients = new Label();
            PanelLeyenda1 = new Panel();
            BtnPrintList = new FontAwesome.Sharp.IconButton();
            DataGridView = new DataGridView();
            label3 = new Label();
            Status = new ComboBox();
            label1 = new Label();
            TextBoxSearch = new TextBox();
            IconPictureBoxSearch = new FontAwesome.Sharp.IconPictureBox();
            PanelLineTop = new Panel();
            IconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            LabelAlertMessage = new Label();
            errorProvider1 = new ErrorProvider(components);
            PanelLeyenda2 = new Panel();
            Insurance = new ComboBox();
            PolicyType = new ComboBox();
            PanelTopFilter2 = new Panel();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            PanelTopFilter1 = new Panel();
            TotalPolicyFiltered = new Label();
            PanelLeyenda_1 = new Panel();
            PanelLeyenda_2 = new Panel();
            PayStatus = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic);
            LabelTitle.Location = new Point(94, 20);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(184, 28);
            LabelTitle.TabIndex = 43;
            LabelTitle.Text = "Gestion de polizas";
            // 
            // BtnInsurance
            // 
            BtnInsurance.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnInsurance.Cursor = Cursors.Hand;
            BtnInsurance.Font = new Font("Segoe UI", 9F);
            BtnInsurance.IconChar = FontAwesome.Sharp.IconChar.BriefcaseMedical;
            BtnInsurance.IconColor = Color.Black;
            BtnInsurance.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnInsurance.Location = new Point(770, 512);
            BtnInsurance.Name = "BtnInsurance";
            BtnInsurance.Size = new Size(85, 85);
            BtnInsurance.TabIndex = 6;
            BtnInsurance.Text = "&Nueva";
            BtnInsurance.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnInsurance.UseVisualStyleBackColor = true;
            BtnInsurance.Click += BtnInsurance_Click;
            // 
            // LabelTotalClients
            // 
            LabelTotalClients.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LabelTotalClients.AutoSize = true;
            LabelTotalClients.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            LabelTotalClients.Location = new Point(14, 506);
            LabelTotalClients.Name = "LabelTotalClients";
            LabelTotalClients.Size = new Size(40, 15);
            LabelTotalClients.TabIndex = 41;
            LabelTotalClients.Text = "label2";
            // 
            // PanelLeyenda1
            // 
            PanelLeyenda1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PanelLeyenda1.Location = new Point(14, 524);
            PanelLeyenda1.Name = "PanelLeyenda1";
            PanelLeyenda1.Size = new Size(315, 186);
            PanelLeyenda1.TabIndex = 40;
            // 
            // BtnPrintList
            // 
            BtnPrintList.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnPrintList.Cursor = Cursors.Hand;
            BtnPrintList.IconChar = FontAwesome.Sharp.IconChar.Print;
            BtnPrintList.IconColor = Color.Black;
            BtnPrintList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPrintList.Location = new Point(861, 512);
            BtnPrintList.Name = "BtnPrintList";
            BtnPrintList.Size = new Size(85, 85);
            BtnPrintList.TabIndex = 7;
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
            DataGridView.Size = new Size(932, 394);
            DataGridView.TabIndex = 37;
            DataGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(432, 20);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 34;
            label3.Text = "Filtrar por:";
            // 
            // Status
            // 
            Status.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Status.FormattingEnabled = true;
            Status.Location = new Point(732, 66);
            Status.Name = "Status";
            Status.Size = new Size(109, 23);
            Status.TabIndex = 4;
            Status.SelectedIndexChanged += ComboBoxStatus_SelectedIndexChanged;
            Status.KeyPress += ComboBoxStatus_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(94, 48);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Buscar";
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Location = new Point(94, 66);
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.Size = new Size(304, 23);
            TextBoxSearch.TabIndex = 1;
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
            IconPictureBoxSearch.TabIndex = 33;
            IconPictureBoxSearch.TabStop = false;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PanelLineTop.Location = new Point(14, 95);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(931, 2);
            PanelLineTop.TabIndex = 36;
            // 
            // IconPictureBox
            // 
            IconPictureBox.BackColor = SystemColors.Control;
            IconPictureBox.ForeColor = SystemColors.ControlText;
            IconPictureBox.IconChar = FontAwesome.Sharp.IconChar.BriefcaseMedical;
            IconPictureBox.IconColor = SystemColors.ControlText;
            IconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            IconPictureBox.IconSize = 45;
            IconPictureBox.Location = new Point(14, 44);
            IconPictureBox.Name = "IconPictureBox";
            IconPictureBox.Size = new Size(45, 45);
            IconPictureBox.TabIndex = 44;
            IconPictureBox.TabStop = false;
            // 
            // LabelAlertMessage
            // 
            LabelAlertMessage.AutoSize = true;
            LabelAlertMessage.Font = new Font("Segoe UI", 12F);
            LabelAlertMessage.Location = new Point(94, 4);
            LabelAlertMessage.Name = "LabelAlertMessage";
            LabelAlertMessage.Size = new Size(52, 21);
            LabelAlertMessage.TabIndex = 45;
            LabelAlertMessage.Text = "label8";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // PanelLeyenda2
            // 
            PanelLeyenda2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PanelLeyenda2.Location = new Point(341, 524);
            PanelLeyenda2.Name = "PanelLeyenda2";
            PanelLeyenda2.Size = new Size(315, 186);
            PanelLeyenda2.TabIndex = 46;
            // 
            // Insurance
            // 
            Insurance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Insurance.FormattingEnabled = true;
            Insurance.Location = new Point(432, 66);
            Insurance.Name = "Insurance";
            Insurance.Size = new Size(144, 23);
            Insurance.TabIndex = 2;
            Insurance.SelectedIndexChanged += Insurance_SelectedIndexChanged;
            Insurance.KeyPress += Insurance_KeyPress;
            // 
            // PolicyType
            // 
            PolicyType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PolicyType.FormattingEnabled = true;
            PolicyType.Location = new Point(582, 66);
            PolicyType.Name = "PolicyType";
            PolicyType.Size = new Size(144, 23);
            PolicyType.TabIndex = 3;
            PolicyType.SelectedIndexChanged += PolicyType_SelectedIndexChanged;
            PolicyType.KeyPress += PolicyType_KeyPress;
            // 
            // PanelTopFilter2
            // 
            PanelTopFilter2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PanelTopFilter2.Location = new Point(432, 58);
            PanelTopFilter2.Name = "PanelTopFilter2";
            PanelTopFilter2.Size = new Size(512, 2);
            PanelTopFilter2.TabIndex = 49;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(432, 40);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 50;
            label2.Text = "Aseguradora";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(582, 40);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 51;
            label4.Text = "Tipo de póliza";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(732, 40);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 52;
            label5.Text = "Estado";
            // 
            // PanelTopFilter1
            // 
            PanelTopFilter1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PanelTopFilter1.Location = new Point(432, 36);
            PanelTopFilter1.Name = "PanelTopFilter1";
            PanelTopFilter1.Size = new Size(512, 2);
            PanelTopFilter1.TabIndex = 50;
            // 
            // TotalPolicyFiltered
            // 
            TotalPolicyFiltered.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TotalPolicyFiltered.AutoSize = true;
            TotalPolicyFiltered.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            TotalPolicyFiltered.Location = new Point(341, 506);
            TotalPolicyFiltered.Name = "TotalPolicyFiltered";
            TotalPolicyFiltered.Size = new Size(40, 15);
            TotalPolicyFiltered.TabIndex = 53;
            TotalPolicyFiltered.Text = "label6";
            // 
            // PanelLeyenda_1
            // 
            PanelLeyenda_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PanelLeyenda_1.Location = new Point(686, 612);
            PanelLeyenda_1.Name = "PanelLeyenda_1";
            PanelLeyenda_1.Size = new Size(260, 70);
            PanelLeyenda_1.TabIndex = 54;
            // 
            // PanelLeyenda_2
            // 
            PanelLeyenda_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PanelLeyenda_2.Location = new Point(686, 688);
            PanelLeyenda_2.Name = "PanelLeyenda_2";
            PanelLeyenda_2.Size = new Size(260, 70);
            PanelLeyenda_2.TabIndex = 55;
            // 
            // PayStatus
            // 
            PayStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PayStatus.FormattingEnabled = true;
            PayStatus.Items.AddRange(new object[] { "Pendiente", "Al día" });
            PayStatus.Location = new Point(847, 66);
            PayStatus.Name = "PayStatus";
            PayStatus.Size = new Size(98, 23);
            PayStatus.TabIndex = 5;
            PayStatus.Text = "Pendiente";
            PayStatus.SelectedIndexChanged += PayStatus_SelectedIndexChanged;
            PayStatus.KeyPress += PayStatus_KeyPress;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(847, 40);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 57;
            label6.Text = "Pago";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(693, 601);
            label7.Name = "label7";
            label7.Size = new Size(112, 15);
            label7.TabIndex = 58;
            label7.Text = "Solo pólizas activas";
            // 
            // FrmPolicyDashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 761);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(PayStatus);
            Controls.Add(PanelLeyenda_2);
            Controls.Add(PanelLeyenda_1);
            Controls.Add(TotalPolicyFiltered);
            Controls.Add(PanelTopFilter1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(PanelTopFilter2);
            Controls.Add(PolicyType);
            Controls.Add(Insurance);
            Controls.Add(PanelLeyenda2);
            Controls.Add(LabelAlertMessage);
            Controls.Add(IconPictureBox);
            Controls.Add(LabelTitle);
            Controls.Add(BtnInsurance);
            Controls.Add(LabelTotalClients);
            Controls.Add(PanelLeyenda1);
            Controls.Add(BtnPrintList);
            Controls.Add(DataGridView);
            Controls.Add(label3);
            Controls.Add(Status);
            Controls.Add(label1);
            Controls.Add(TextBoxSearch);
            Controls.Add(IconPictureBoxSearch);
            Controls.Add(PanelLineTop);
            Name = "FrmPolicyDashboardView";
            Text = "FrmPolicyDashboardView";
            Load += FrmPolicyDashboardView_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelTitle;
        private FontAwesome.Sharp.IconButton BtnInsurance;
        private Label LabelTotalClients;
        private Panel PanelLeyenda1;
        private FontAwesome.Sharp.IconButton BtnPrintList;
        private DataGridView DataGridView;
        private Label label3;
        private ComboBox Status;
        private Label label1;
        private TextBox TextBoxSearch;
        private FontAwesome.Sharp.IconPictureBox IconPictureBoxSearch;
        private Panel PanelLineTop;
        private FontAwesome.Sharp.IconPictureBox IconPictureBox;
        private Label LabelAlertMessage;
        private ErrorProvider errorProvider1;
        private Panel PanelLeyenda2;
        private ComboBox Insurance;
        private ComboBox PolicyType;
        private Panel PanelTopFilter1;
        private Label label5;
        private Label label4;
        private Label label2;
        private Panel PanelTopFilter2;
        private Label TotalPolicyFiltered;
        private Panel PanelLeyenda_2;
        private Panel PanelLeyenda_1;
        private Label label6;
        private ComboBox PayStatus;
        private Label label7;
    }
}