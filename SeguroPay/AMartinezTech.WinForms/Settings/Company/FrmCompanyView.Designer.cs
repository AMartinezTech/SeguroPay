namespace AMartinezTech.WinForms.Settings.Company
{
    partial class FrmCompanyView
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
            TxtName = new TextBox();
            TxtRNC = new TextBox();
            label2 = new Label();
            TxtPhone = new TextBox();
            label3 = new Label();
            TxtEmail = new TextBox();
            label4 = new Label();
            TxtLine1 = new TextBox();
            label5 = new Label();
            TxtLine2 = new TextBox();
            label6 = new Label();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            PanelLineTop = new Panel();
            PanelAlertMessage = new Panel();
            LabelAlertMessage = new Label();
            PanelLineButtom = new Panel();
            PanelButtom = new Panel();
            LabelTitle = new Label();
            PbLogo = new PictureBox();
            errorProvider1 = new ErrorProvider(components);
            label7 = new Label();
            PanelAlertMessage.SuspendLayout();
            PanelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 50);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // TxtName
            // 
            TxtName.Location = new Point(27, 68);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(283, 23);
            TxtName.TabIndex = 1;
            // 
            // TxtRNC
            // 
            TxtRNC.Location = new Point(27, 112);
            TxtRNC.Name = "TxtRNC";
            TxtRNC.Size = new Size(133, 23);
            TxtRNC.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 94);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 2;
            label2.Text = "RNC";
            // 
            // TxtPhone
            // 
            TxtPhone.Location = new Point(177, 112);
            TxtPhone.Name = "TxtPhone";
            TxtPhone.Size = new Size(133, 23);
            TxtPhone.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(177, 94);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 4;
            label3.Text = "Teléfono";
            // 
            // TxtEmail
            // 
            TxtEmail.Location = new Point(27, 159);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(283, 23);
            TxtEmail.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 141);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 6;
            label4.Text = "Correo";
            // 
            // TxtLine1
            // 
            TxtLine1.Location = new Point(27, 206);
            TxtLine1.Name = "TxtLine1";
            TxtLine1.Size = new Size(283, 23);
            TxtLine1.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 188);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 8;
            label5.Text = "Dirección";
            // 
            // TxtLine2
            // 
            TxtLine2.Location = new Point(27, 250);
            TxtLine2.Name = "TxtLine2";
            TxtLine2.Size = new Size(283, 23);
            TxtLine2.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 232);
            label6.Name = "label6";
            label6.Size = new Size(86, 15);
            label6.TabIndex = 10;
            label6.Text = "Línea adicional";
            // 
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(225, 290);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 17;
            BtnPersistence.Text = "&Guardar";
            BtnPersistence.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPersistence.UseVisualStyleBackColor = true;
            BtnPersistence.Click += BtnPersistence_Click;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Dock = DockStyle.Top;
            PanelLineTop.Location = new Point(0, 35);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(510, 2);
            PanelLineTop.TabIndex = 21;
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(510, 35);
            PanelAlertMessage.TabIndex = 20;
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
            PanelLineButtom.Location = new Point(0, 393);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(510, 2);
            PanelLineButtom.TabIndex = 23;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelTitle);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 395);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(510, 35);
            PanelButtom.TabIndex = 22;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            LabelTitle.Location = new Point(13, 5);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(161, 21);
            LabelTitle.TabIndex = 1;
            LabelTitle.Text = "Maestro de compañía";
            // 
            // PbLogo
            // 
            PbLogo.BorderStyle = BorderStyle.FixedSingle;
            PbLogo.Cursor = Cursors.Hand;
            PbLogo.Image = Properties.Resources.camera_32;
            PbLogo.Location = new Point(340, 68);
            PbLogo.Name = "PbLogo";
            PbLogo.Size = new Size(131, 114);
            PbLogo.TabIndex = 24;
            PbLogo.TabStop = false;
            PbLogo.Click += PbLogo_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(340, 50);
            label7.Name = "label7";
            label7.Size = new Size(136, 15);
            label7.TabIndex = 25;
            label7.Text = "Clic para selecionar logo";
            // 
            // FrmCompanyView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 430);
            Controls.Add(label7);
            Controls.Add(PbLogo);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelAlertMessage);
            Controls.Add(BtnPersistence);
            Controls.Add(TxtLine2);
            Controls.Add(label6);
            Controls.Add(TxtLine1);
            Controls.Add(label5);
            Controls.Add(TxtEmail);
            Controls.Add(label4);
            Controls.Add(TxtPhone);
            Controls.Add(label3);
            Controls.Add(TxtRNC);
            Controls.Add(label2);
            Controls.Add(TxtName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCompanyView";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Compañía";
            Load += FrmCompanyView_Load;
            PanelAlertMessage.ResumeLayout(false);
            PanelAlertMessage.PerformLayout();
            PanelButtom.ResumeLayout(false);
            PanelButtom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TxtName;
        private TextBox TxtRNC;
        private Label label2;
        private TextBox TxtPhone;
        private Label label3;
        private TextBox TxtEmail;
        private Label label4;
        private TextBox TxtLine1;
        private Label label5;
        private TextBox TxtLine2;
        private Label label6;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private Panel PanelLineTop;
        private Panel PanelAlertMessage;
        private Label LabelAlertMessage;
        private Panel PanelLineButtom;
        private Panel PanelButtom;
        private Label LabelTitle;
        private PictureBox PbLogo;
        private ErrorProvider errorProvider1;
        private Label label7;
    }
}