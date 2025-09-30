namespace AMartinezTech.WinForms.Auth
{
    partial class FrmLoginView
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
            PanelAlertMessage = new Panel();
            PanelLineTop = new Panel();
            PanelButtom = new Panel();
            PanelLineButtom = new Panel();
            label1 = new Label();
            TextBoxUser = new TextBox();
            TextBoxPassword = new TextBox();
            label2 = new Label();
            BtnLogin = new FontAwesome.Sharp.IconButton();
            IconPictureBoxLogin = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxLogin).BeginInit();
            SuspendLayout();
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(329, 35);
            PanelAlertMessage.TabIndex = 0;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Dock = DockStyle.Top;
            PanelLineTop.Location = new Point(0, 35);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(329, 2);
            PanelLineTop.TabIndex = 1;
            // 
            // PanelButtom
            // 
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 350);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(329, 100);
            PanelButtom.TabIndex = 2;
            // 
            // PanelLineButtom
            // 
            PanelLineButtom.Dock = DockStyle.Bottom;
            PanelLineButtom.Location = new Point(0, 348);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(329, 2);
            PanelLineButtom.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 75);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 4;
            label1.Text = "Usuario";
            // 
            // TextBoxUser
            // 
            TextBoxUser.Location = new Point(18, 93);
            TextBoxUser.Name = "TextBoxUser";
            TextBoxUser.Size = new Size(193, 23);
            TextBoxUser.TabIndex = 5;
            // 
            // TextBoxPassword
            // 
            TextBoxPassword.Location = new Point(18, 157);
            TextBoxPassword.Name = "TextBoxPassword";
            TextBoxPassword.PasswordChar = '*';
            TextBoxPassword.Size = new Size(193, 23);
            TextBoxPassword.TabIndex = 7;
            TextBoxPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 139);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 6;
            label2.Text = "Clave";
            // 
            // BtnLogin
            // 
            BtnLogin.Cursor = Cursors.Hand;
            BtnLogin.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnLogin.IconColor = Color.Black;
            BtnLogin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnLogin.Location = new Point(18, 216);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(193, 75);
            BtnLogin.TabIndex = 8;
            BtnLogin.Text = "Inicial sessión";
            BtnLogin.UseVisualStyleBackColor = true;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // IconPictureBoxLogin
            // 
            IconPictureBoxLogin.BackColor = SystemColors.Control;
            IconPictureBoxLogin.ForeColor = SystemColors.ControlText;
            IconPictureBoxLogin.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            IconPictureBoxLogin.IconColor = SystemColors.ControlText;
            IconPictureBoxLogin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            IconPictureBoxLogin.IconSize = 91;
            IconPictureBoxLogin.Location = new Point(226, 93);
            IconPictureBoxLogin.Name = "IconPictureBoxLogin";
            IconPictureBoxLogin.Size = new Size(91, 91);
            IconPictureBoxLogin.SizeMode = PictureBoxSizeMode.AutoSize;
            IconPictureBoxLogin.TabIndex = 9;
            IconPictureBoxLogin.TabStop = false;
            // 
            // FrmLoginView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 450);
            Controls.Add(IconPictureBoxLogin);
            Controls.Add(BtnLogin);
            Controls.Add(TextBoxPassword);
            Controls.Add(label2);
            Controls.Add(TextBoxUser);
            Controls.Add(label1);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelAlertMessage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLoginView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += FrmLoginView_Load;
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxLogin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelAlertMessage;
        private Panel PanelLineTop;
        private Panel PanelButtom;
        private Panel PanelLineButtom;
        private Label label1;
        private TextBox TextBoxUser;
        private TextBox TextBoxPassword;
        private Label label2;
        private FontAwesome.Sharp.IconButton BtnLogin;
        private FontAwesome.Sharp.IconPictureBox IconPictureBoxLogin;
    }
}