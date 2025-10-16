namespace AMartinezTech.WinForms.Client.Conversations
{
    partial class FrmClientConversationView
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
            LabelClientFullName = new Label();
            label1 = new Label();
            TextBoxSubject = new TextBox();
            label2 = new Label();
            TextBoxMessage = new TextBox();
            label3 = new Label();
            ComboBoxChannel = new ComboBox();
            label4 = new Label();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            BtnClear = new FontAwesome.Sharp.IconButton();
            PanelLineTop = new Panel();
            PanelAlertMessage = new Panel();
            LabelAlertMessage = new Label();
            PanelLineButtom = new Panel();
            PanelButtom = new Panel();
            LabelTitle = new Label();
            errorProvider1 = new ErrorProvider(components);
            TextBoxContactNumber = new MaskedTextBox();
            DataGridView = new DataGridView();
            LabelAsistenceBy = new Label();
            PanelAlertMessage.SuspendLayout();
            PanelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            SuspendLayout();
            // 
            // LabelClientFullName
            // 
            LabelClientFullName.AutoSize = true;
            LabelClientFullName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            LabelClientFullName.Location = new Point(13, 55);
            LabelClientFullName.Name = "LabelClientFullName";
            LabelClientFullName.Size = new Size(65, 25);
            LabelClientFullName.TabIndex = 0;
            LabelClientFullName.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 92);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 1;
            label1.Text = "Teléfono de contacto";
            // 
            // TextBoxSubject
            // 
            TextBoxSubject.Location = new Point(184, 110);
            TextBoxSubject.Name = "TextBoxSubject";
            TextBoxSubject.Size = new Size(343, 23);
            TextBoxSubject.TabIndex = 4;
            TextBoxSubject.TextChanged += TextBoxSubject_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(184, 92);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 3;
            label2.Text = "Motivo";
            // 
            // TextBoxMessage
            // 
            TextBoxMessage.Location = new Point(10, 202);
            TextBoxMessage.Multiline = true;
            TextBoxMessage.Name = "TextBoxMessage";
            TextBoxMessage.Size = new Size(517, 236);
            TextBoxMessage.TabIndex = 8;
            TextBoxMessage.TextChanged += TextBoxMessage_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 184);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 7;
            label3.Text = "Nota";
            // 
            // ComboBoxChannel
            // 
            ComboBoxChannel.FormattingEnabled = true;
            ComboBoxChannel.Location = new Point(10, 158);
            ComboBoxChannel.Name = "ComboBoxChannel";
            ComboBoxChannel.Size = new Size(152, 23);
            ComboBoxChannel.TabIndex = 6;
            ComboBoxChannel.SelectedIndexChanged += ComboBoxChannel_SelectedIndexChanged;
            ComboBoxChannel.KeyPress += ComboBoxChannel_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 140);
            label4.Name = "label4";
            label4.Size = new Size(136, 15);
            label4.TabIndex = 5;
            label4.Text = "Medio de comunicación";
            // 
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(442, 444);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 10;
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
            BtnClear.Location = new Point(334, 444);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(85, 85);
            BtnClear.TabIndex = 9;
            BtnClear.Text = "&Limpiar";
            BtnClear.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Dock = DockStyle.Top;
            PanelLineTop.Location = new Point(0, 35);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(1084, 2);
            PanelLineTop.TabIndex = 34;
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(1084, 35);
            PanelAlertMessage.TabIndex = 33;
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
            PanelLineButtom.Location = new Point(0, 544);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(1084, 2);
            PanelLineButtom.TabIndex = 36;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelTitle);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 546);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(1084, 35);
            PanelButtom.TabIndex = 35;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            LabelTitle.Location = new Point(13, 5);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(137, 21);
            LabelTitle.TabIndex = 1;
            LabelTitle.Text = "Atención al cliente";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // TextBoxContactNumber
            // 
            TextBoxContactNumber.Location = new Point(12, 110);
            TextBoxContactNumber.Mask = "000-000-0000";
            TextBoxContactNumber.Name = "TextBoxContactNumber";
            TextBoxContactNumber.Size = new Size(117, 23);
            TextBoxContactNumber.TabIndex = 2;
            // 
            // DataGridView
            // 
            DataGridView.Location = new Point(548, 110);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(524, 328);
            DataGridView.TabIndex = 0;
            DataGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // LabelAsistenceBy
            // 
            LabelAsistenceBy.AutoSize = true;
            LabelAsistenceBy.Location = new Point(184, 161);
            LabelAsistenceBy.Name = "LabelAsistenceBy";
            LabelAsistenceBy.Size = new Size(79, 15);
            LabelAsistenceBy.TabIndex = 37;
            LabelAsistenceBy.Text = "Asistido por : ";
            // 
            // FrmClientConversationView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 581);
            Controls.Add(LabelAsistenceBy);
            Controls.Add(DataGridView);
            Controls.Add(TextBoxContactNumber);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelAlertMessage);
            Controls.Add(BtnPersistence);
            Controls.Add(BtnClear);
            Controls.Add(label4);
            Controls.Add(ComboBoxChannel);
            Controls.Add(TextBoxMessage);
            Controls.Add(label3);
            Controls.Add(TextBoxSubject);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LabelClientFullName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmClientConversationView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Atención al cliente";
            Load += FrmClientConversationView_Load;
            PanelAlertMessage.ResumeLayout(false);
            PanelAlertMessage.PerformLayout();
            PanelButtom.ResumeLayout(false);
            PanelButtom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox TextBoxSubject;
        private Label label2;
        private TextBox TextBoxMessage;
        private Label label3;
        private ComboBox ComboBoxChannel;
        private Label label4;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private FontAwesome.Sharp.IconButton BtnClear;
        private Panel PanelLineTop;
        private Panel PanelAlertMessage;
        private Label LabelAlertMessage;
        private Panel PanelLineButtom;
        private Panel PanelButtom;
        private Label LabelTitle;
        private ErrorProvider errorProvider1;
        public Label LabelClientFullName;
        private MaskedTextBox TextBoxContactNumber;
        private DataGridView DataGridView;
        private Label LabelAsistenceBy;
    }
}