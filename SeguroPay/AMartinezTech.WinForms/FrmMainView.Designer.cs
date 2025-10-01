namespace AMartinezTech.WinForms
{
    partial class FrmMainView
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
            PanelTopMenu = new Panel();
            BtnSetting = new FontAwesome.Sharp.IconButton();
            BtnBank = new FontAwesome.Sharp.IconButton();
            BtnCash = new FontAwesome.Sharp.IconButton();
            BtnPolicy = new FontAwesome.Sharp.IconButton();
            BtnInsurance = new FontAwesome.Sharp.IconButton();
            BtnClient = new FontAwesome.Sharp.IconButton();
            PanelLineHorizontal = new Panel();
            PanelContainer = new Panel();
            PanelButtomMenu = new Panel();
            PanelTopMenu.SuspendLayout();
            SuspendLayout();
            // 
            // PanelTopMenu
            // 
            PanelTopMenu.Controls.Add(BtnSetting);
            PanelTopMenu.Controls.Add(BtnBank);
            PanelTopMenu.Controls.Add(BtnCash);
            PanelTopMenu.Controls.Add(BtnPolicy);
            PanelTopMenu.Controls.Add(BtnInsurance);
            PanelTopMenu.Controls.Add(BtnClient);
            PanelTopMenu.Dock = DockStyle.Top;
            PanelTopMenu.Location = new Point(0, 0);
            PanelTopMenu.Name = "PanelTopMenu";
            PanelTopMenu.Size = new Size(1184, 100);
            PanelTopMenu.TabIndex = 0;
            // 
            // BtnSetting
            // 
            BtnSetting.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnSetting.Cursor = Cursors.Hand;
            BtnSetting.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BtnSetting.IconChar = FontAwesome.Sharp.IconChar.Sliders;
            BtnSetting.IconColor = Color.Black;
            BtnSetting.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnSetting.Location = new Point(1087, 9);
            BtnSetting.Name = "BtnSetting";
            BtnSetting.Size = new Size(85, 85);
            BtnSetting.TabIndex = 5;
            BtnSetting.Text = "Config.";
            BtnSetting.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnSetting.UseVisualStyleBackColor = true;
            BtnSetting.Click += BtnSetting_Click;
            // 
            // BtnBank
            // 
            BtnBank.Cursor = Cursors.Hand;
            BtnBank.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BtnBank.IconChar = FontAwesome.Sharp.IconChar.Building;
            BtnBank.IconColor = Color.Black;
            BtnBank.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnBank.Location = new Point(376, 9);
            BtnBank.Name = "BtnBank";
            BtnBank.Size = new Size(85, 85);
            BtnBank.TabIndex = 4;
            BtnBank.Text = "Banco";
            BtnBank.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnBank.UseVisualStyleBackColor = true;
            BtnBank.Click += BtnBank_Click;
            // 
            // BtnCash
            // 
            BtnCash.Cursor = Cursors.Hand;
            BtnCash.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BtnCash.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            BtnCash.IconColor = Color.Black;
            BtnCash.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCash.Location = new Point(285, 9);
            BtnCash.Name = "BtnCash";
            BtnCash.Size = new Size(85, 85);
            BtnCash.TabIndex = 3;
            BtnCash.Text = "Caja";
            BtnCash.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnCash.UseVisualStyleBackColor = true;
            BtnCash.Click += BtnCash_Click;
            // 
            // BtnPolicy
            // 
            BtnPolicy.Cursor = Cursors.Hand;
            BtnPolicy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BtnPolicy.IconChar = FontAwesome.Sharp.IconChar.BriefcaseMedical;
            BtnPolicy.IconColor = Color.Black;
            BtnPolicy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPolicy.Location = new Point(194, 9);
            BtnPolicy.Name = "BtnPolicy";
            BtnPolicy.Size = new Size(85, 85);
            BtnPolicy.TabIndex = 2;
            BtnPolicy.Text = "Polizas";
            BtnPolicy.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPolicy.UseVisualStyleBackColor = true;
            BtnPolicy.Click += BtnPolicy_Click;
            // 
            // BtnInsurance
            // 
            BtnInsurance.Cursor = Cursors.Hand;
            BtnInsurance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BtnInsurance.IconChar = FontAwesome.Sharp.IconChar.HouseMedical;
            BtnInsurance.IconColor = Color.Black;
            BtnInsurance.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnInsurance.Location = new Point(103, 9);
            BtnInsurance.Name = "BtnInsurance";
            BtnInsurance.Size = new Size(85, 85);
            BtnInsurance.TabIndex = 1;
            BtnInsurance.Text = "Seguros";
            BtnInsurance.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnInsurance.UseVisualStyleBackColor = true;
            BtnInsurance.Click += BtnInsurance_Click;
            // 
            // BtnClient
            // 
            BtnClient.Cursor = Cursors.Hand;
            BtnClient.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BtnClient.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            BtnClient.IconColor = Color.Black;
            BtnClient.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnClient.Location = new Point(12, 9);
            BtnClient.Name = "BtnClient";
            BtnClient.Size = new Size(85, 85);
            BtnClient.TabIndex = 0;
            BtnClient.Text = "Clientes";
            BtnClient.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClient.UseVisualStyleBackColor = true;
            BtnClient.Click += BtnClient_Click;
            // 
            // PanelLineHorizontal
            // 
            PanelLineHorizontal.Dock = DockStyle.Top;
            PanelLineHorizontal.Location = new Point(0, 100);
            PanelLineHorizontal.Name = "PanelLineHorizontal";
            PanelLineHorizontal.Size = new Size(1184, 2);
            PanelLineHorizontal.TabIndex = 1;
            // 
            // PanelContainer
            // 
            PanelContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PanelContainer.Location = new Point(0, 102);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(1184, 618);
            PanelContainer.TabIndex = 2;
            // 
            // PanelButtomMenu
            // 
            PanelButtomMenu.Dock = DockStyle.Bottom;
            PanelButtomMenu.Location = new Point(0, 726);
            PanelButtomMenu.Name = "PanelButtomMenu";
            PanelButtomMenu.Size = new Size(1184, 35);
            PanelButtomMenu.TabIndex = 0;
            // 
            // FrmMainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(PanelButtomMenu);
            Controls.Add(PanelContainer);
            Controls.Add(PanelLineHorizontal);
            Controls.Add(PanelTopMenu);
            MinimumSize = new Size(1200, 800);
            Name = "FrmMainView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AMartínezTech Copyright © 2025 ( SeguroPay v.1.0.0 )";
            WindowState = FormWindowState.Maximized;
            Load += FrmMainView_Load;
            PanelTopMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelTopMenu;
        private Panel PanelLineHorizontal;
        private Panel PanelContainer;
        private Panel PanelButtomMenu;
        private FontAwesome.Sharp.IconButton BtnClient;
        private FontAwesome.Sharp.IconButton BtnBank;
        private FontAwesome.Sharp.IconButton BtnCash;
        private FontAwesome.Sharp.IconButton BtnPolicy;
        private FontAwesome.Sharp.IconButton BtnInsurance;
        private FontAwesome.Sharp.IconButton BtnSetting;
    }
}