namespace AMartinezTech.WinForms.Settings.User
{
    partial class FrmUserView
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
            label1 = new Label();
            TextBoxFullName = new TextBox();
            TextBoxEmail = new TextBox();
            label2 = new Label();
            TextBoxPhone = new TextBox();
            label3 = new Label();
            ComboBoxRol = new ComboBox();
            label4 = new Label();
            TextBoxUserName = new TextBox();
            label5 = new Label();
            TextBoxPassword = new TextBox();
            label6 = new Label();
            TextBoxConfirmPassword = new TextBox();
            label7 = new Label();
            CheckBoxIsActive = new CheckBox();
            BtnClear = new FontAwesome.Sharp.IconButton();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            DataGridView = new DataGridView();
            PanelAlertMessage = new Panel();
            LabelAlertMessage = new Label();
            PanelLineTop = new Panel();
            PanelButtom = new Panel();
            LabelTitle = new Label();
            PanelLineButtom = new Panel();
            errorProvider1 = new ErrorProvider(components);
            CheckBoxFilterByIsActive = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            PanelAlertMessage.SuspendLayout();
            PanelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 50);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre completo";
            // 
            // TextBoxFullName
            // 
            TextBoxFullName.Location = new Point(22, 68);
            TextBoxFullName.Name = "TextBoxFullName";
            TextBoxFullName.Size = new Size(255, 23);
            TextBoxFullName.TabIndex = 1;
            TextBoxFullName.TextChanged += TextBoxFullName_TextChanged;
            // 
            // TextBoxEmail
            // 
            TextBoxEmail.Location = new Point(22, 112);
            TextBoxEmail.Name = "TextBoxEmail";
            TextBoxEmail.Size = new Size(255, 23);
            TextBoxEmail.TabIndex = 3;
            TextBoxEmail.Text = "@";
            TextBoxEmail.TextChanged += TextBoxEmail_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 94);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 2;
            label2.Text = "Correo";
            // 
            // TextBoxPhone
            // 
            TextBoxPhone.Location = new Point(22, 156);
            TextBoxPhone.Name = "TextBoxPhone";
            TextBoxPhone.Size = new Size(126, 23);
            TextBoxPhone.TabIndex = 5;
            TextBoxPhone.TextChanged += TextBoxPhone_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 138);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 4;
            label3.Text = "Teléfono";
            // 
            // ComboBoxRol
            // 
            ComboBoxRol.FormattingEnabled = true;
            ComboBoxRol.Items.AddRange(new object[] { "Administrador", "Cajero", "Gestor" });
            ComboBoxRol.Location = new Point(176, 156);
            ComboBoxRol.Name = "ComboBoxRol";
            ComboBoxRol.Size = new Size(101, 23);
            ComboBoxRol.TabIndex = 6;
            ComboBoxRol.Text = "Administrador";
            ComboBoxRol.SelectedIndexChanged += ComboBoxRol_SelectedIndexChanged;
            ComboBoxRol.KeyPress += ComboBoxRol_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(176, 138);
            label4.Name = "label4";
            label4.Size = new Size(24, 15);
            label4.TabIndex = 7;
            label4.Text = "Rol";
            // 
            // TextBoxUserName
            // 
            TextBoxUserName.Location = new Point(22, 200);
            TextBoxUserName.Name = "TextBoxUserName";
            TextBoxUserName.Size = new Size(126, 23);
            TextBoxUserName.TabIndex = 9;
            TextBoxUserName.TextChanged += TextBoxUserName_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 182);
            label5.Name = "label5";
            label5.Size = new Size(47, 15);
            label5.TabIndex = 8;
            label5.Text = "Usuario";
            // 
            // TextBoxPassword
            // 
            TextBoxPassword.Location = new Point(22, 244);
            TextBoxPassword.Name = "TextBoxPassword";
            TextBoxPassword.Size = new Size(126, 23);
            TextBoxPassword.TabIndex = 11;
            TextBoxPassword.TextChanged += TextBoxPassword_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 226);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 10;
            label6.Text = "Clave";
            // 
            // TextBoxConfirmPassword
            // 
            TextBoxConfirmPassword.Location = new Point(22, 288);
            TextBoxConfirmPassword.Name = "TextBoxConfirmPassword";
            TextBoxConfirmPassword.Size = new Size(126, 23);
            TextBoxConfirmPassword.TabIndex = 13;
            TextBoxConfirmPassword.TextChanged += TextBoxConfirmPassword_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(22, 270);
            label7.Name = "label7";
            label7.Size = new Size(93, 15);
            label7.TabIndex = 12;
            label7.Text = "Confirmar Clave";
            // 
            // CheckBoxIsActive
            // 
            CheckBoxIsActive.AutoSize = true;
            CheckBoxIsActive.Checked = true;
            CheckBoxIsActive.CheckState = CheckState.Checked;
            CheckBoxIsActive.Location = new Point(178, 198);
            CheckBoxIsActive.Name = "CheckBoxIsActive";
            CheckBoxIsActive.Size = new Size(60, 19);
            CheckBoxIsActive.TabIndex = 14;
            CheckBoxIsActive.Text = "Activo";
            CheckBoxIsActive.UseVisualStyleBackColor = true;
            // 
            // BtnClear
            // 
            BtnClear.Cursor = Cursors.Hand;
            BtnClear.IconChar = FontAwesome.Sharp.IconChar.File;
            BtnClear.IconColor = Color.Black;
            BtnClear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnClear.Location = new Point(22, 326);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(85, 85);
            BtnClear.TabIndex = 15;
            BtnClear.Text = "&Limpiar";
            BtnClear.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(192, 326);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 16;
            BtnPersistence.Text = "&Guardar";
            BtnPersistence.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPersistence.UseVisualStyleBackColor = true;
            BtnPersistence.Click += BtnPersistence_Click;
            // 
            // DataGridView
            // 
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(300, 68);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(479, 343);
            DataGridView.TabIndex = 17;
            DataGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(800, 35);
            PanelAlertMessage.TabIndex = 18;
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
            // PanelLineTop
            // 
            PanelLineTop.Dock = DockStyle.Top;
            PanelLineTop.Location = new Point(0, 35);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(800, 2);
            PanelLineTop.TabIndex = 19;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelTitle);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 426);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(800, 35);
            PanelButtom.TabIndex = 20;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            LabelTitle.Location = new Point(13, 5);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(149, 21);
            LabelTitle.TabIndex = 1;
            LabelTitle.Text = "Maestro de usuarios";
            // 
            // PanelLineButtom
            // 
            PanelLineButtom.Dock = DockStyle.Bottom;
            PanelLineButtom.Location = new Point(0, 424);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(800, 2);
            PanelLineButtom.TabIndex = 21;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // CheckBoxFilterByIsActive
            // 
            CheckBoxFilterByIsActive.AutoSize = true;
            CheckBoxFilterByIsActive.Checked = true;
            CheckBoxFilterByIsActive.CheckState = CheckState.Checked;
            CheckBoxFilterByIsActive.Location = new Point(683, 43);
            CheckBoxFilterByIsActive.Name = "CheckBoxFilterByIsActive";
            CheckBoxFilterByIsActive.Size = new Size(96, 19);
            CheckBoxFilterByIsActive.TabIndex = 22;
            CheckBoxFilterByIsActive.Text = "Filtrar activos";
            CheckBoxFilterByIsActive.UseVisualStyleBackColor = true;
            CheckBoxFilterByIsActive.CheckedChanged += CheckBoxFilterByIsActive_CheckedChanged;
            // 
            // FrmUserView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 461);
            Controls.Add(CheckBoxFilterByIsActive);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelAlertMessage);
            Controls.Add(DataGridView);
            Controls.Add(BtnPersistence);
            Controls.Add(BtnClear);
            Controls.Add(CheckBoxIsActive);
            Controls.Add(TextBoxConfirmPassword);
            Controls.Add(label7);
            Controls.Add(TextBoxPassword);
            Controls.Add(label6);
            Controls.Add(TextBoxUserName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(ComboBoxRol);
            Controls.Add(TextBoxPhone);
            Controls.Add(label3);
            Controls.Add(TextBoxEmail);
            Controls.Add(label2);
            Controls.Add(TextBoxFullName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmUserView";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuarios";
            Load += FrmUserView_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            PanelAlertMessage.ResumeLayout(false);
            PanelAlertMessage.PerformLayout();
            PanelButtom.ResumeLayout(false);
            PanelButtom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TextBoxFullName;
        private TextBox TextBoxEmail;
        private Label label2;
        private TextBox TextBoxPhone;
        private Label label3;
        private ComboBox ComboBoxRol;
        private Label label4;
        private TextBox TextBoxUserName;
        private Label label5;
        private TextBox TextBoxPassword;
        private Label label6;
        private TextBox TextBoxConfirmPassword;
        private Label label7;
        private CheckBox CheckBoxIsActive;
        private FontAwesome.Sharp.IconButton BtnClear;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private DataGridView DataGridView;
        private Panel PanelAlertMessage;
        private Label LabelAlertMessage;
        private Panel PanelLineTop;
        private Panel PanelButtom;
        private Panel PanelLineButtom;
        private ErrorProvider errorProvider1;
        private CheckBox CheckBoxFilterByIsActive;
        private Label LabelTitle;
    }
}