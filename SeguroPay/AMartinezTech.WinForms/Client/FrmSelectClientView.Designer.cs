namespace AMartinezTech.WinForms.Client
{
    partial class FrmSelectClientView
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
            IconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            LabelTitle = new Label();
            label1 = new Label();
            TextBoxSearch = new TextBox();
            IconPictureBoxSearch = new FontAwesome.Sharp.IconPictureBox();
            PanelLineTop = new Panel();
            DataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            SuspendLayout();
            // 
            // IconPictureBox
            // 
            IconPictureBox.BackColor = SystemColors.Control;
            IconPictureBox.ForeColor = SystemColors.ControlText;
            IconPictureBox.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            IconPictureBox.IconColor = SystemColors.ControlText;
            IconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            IconPictureBox.IconSize = 45;
            IconPictureBox.Location = new Point(12, 38);
            IconPictureBox.Name = "IconPictureBox";
            IconPictureBox.Size = new Size(45, 45);
            IconPictureBox.TabIndex = 24;
            IconPictureBox.TabStop = false;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic);
            LabelTitle.Location = new Point(92, 14);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(161, 28);
            LabelTitle.TabIndex = 2;
            LabelTitle.Text = "Lista de clientes";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(92, 42);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Buscar";
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Location = new Point(92, 60);
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.Size = new Size(350, 23);
            TextBoxSearch.TabIndex = 0;
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
            IconPictureBoxSearch.Location = new Point(63, 60);
            IconPictureBoxSearch.Name = "IconPictureBoxSearch";
            IconPictureBoxSearch.Size = new Size(25, 23);
            IconPictureBoxSearch.TabIndex = 21;
            IconPictureBoxSearch.TabStop = false;
            // 
            // PanelLineTop
            // 
            PanelLineTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PanelLineTop.Location = new Point(10, 90);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(731, 2);
            PanelLineTop.TabIndex = 3;
            // 
            // DataGridView
            // 
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(10, 98);
            DataGridView.Name = "DataGridView";
            DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView.Size = new Size(731, 343);
            DataGridView.TabIndex = 25;
            DataGridView.CellDoubleClick += DataGridView_CellDoubleClick;
            DataGridView.KeyDown += DataGridView_KeyDown;
            // 
            // FrmSelectClientView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 453);
            Controls.Add(DataGridView);
            Controls.Add(IconPictureBox);
            Controls.Add(LabelTitle);
            Controls.Add(label1);
            Controls.Add(TextBoxSearch);
            Controls.Add(IconPictureBoxSearch);
            Controls.Add(PanelLineTop);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSelectClientView";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Buscar cliente";
            Load += FrmSelectClientView_Load;
            ((System.ComponentModel.ISupportInitialize)IconPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox IconPictureBox;
        private Label LabelTitle;
        private Label label1;
        private TextBox TextBoxSearch;
        private FontAwesome.Sharp.IconPictureBox IconPictureBoxSearch;
        private Panel PanelLineTop;
        private DataGridView DataGridView;
    }
}