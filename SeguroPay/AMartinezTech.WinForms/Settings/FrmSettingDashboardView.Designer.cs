namespace AMartinezTech.WinForms.Settings
{
    partial class FrmSettingDashboardView
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
            BtnUser = new FontAwesome.Sharp.IconButton();
            BtnCompany = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // BtnUser
            // 
            BtnUser.Cursor = Cursors.Hand;
            BtnUser.IconChar = FontAwesome.Sharp.IconChar.Users;
            BtnUser.IconColor = Color.Black;
            BtnUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnUser.Location = new Point(12, 12);
            BtnUser.Name = "BtnUser";
            BtnUser.Size = new Size(85, 85);
            BtnUser.TabIndex = 0;
            BtnUser.Text = "Usuarios";
            BtnUser.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnUser.UseVisualStyleBackColor = true;
            BtnUser.Click += BtnUser_Click;
            // 
            // BtnCompany
            // 
            BtnCompany.Cursor = Cursors.Hand;
            BtnCompany.IconChar = FontAwesome.Sharp.IconChar.BuildingCircleCheck;
            BtnCompany.IconColor = Color.Black;
            BtnCompany.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCompany.Location = new Point(12, 113);
            BtnCompany.Name = "BtnCompany";
            BtnCompany.Size = new Size(85, 85);
            BtnCompany.TabIndex = 1;
            BtnCompany.Text = "Compañía";
            BtnCompany.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnCompany.UseVisualStyleBackColor = true;
            BtnCompany.Click += BtnCompany_Click;
            // 
            // FrmSettingDashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnCompany);
            Controls.Add(BtnUser);
            Name = "FrmSettingDashboardView";
            Text = "FrmSettingDashboardView";
            ResumeLayout(false);
        }

        #endregion

        private FontAwesome.Sharp.IconButton BtnUser;
        private FontAwesome.Sharp.IconButton BtnCompany;
    }
}