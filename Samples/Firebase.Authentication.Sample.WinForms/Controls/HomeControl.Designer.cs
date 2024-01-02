namespace Firebase.Authentication.Sample.WinForms.Controls
{
    partial class HomeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            IconBox = new PictureBox();
            TitleLabel = new Label();
            ContentPanel = new Panel();
            DividerPanel = new Panel();
            DescriptionLabel = new Label();
            NoticeLabel1 = new Label();
            NoticeLabel2 = new Label();
            NoticeLink1 = new LinkLabel();
            NoticeLink2 = new LinkLabel();
            NoticePanel = new Panel();
            SpacerPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)IconBox).BeginInit();
            NoticePanel.SuspendLayout();
            SuspendLayout();
            // 
            // IconBox
            // 
            IconBox.Dock = DockStyle.Top;
            IconBox.Image = Properties.Resources.firebase;
            IconBox.Location = new Point(0, 0);
            IconBox.Name = "IconBox";
            IconBox.Size = new Size(507, 94);
            IconBox.SizeMode = PictureBoxSizeMode.Zoom;
            IconBox.TabIndex = 0;
            IconBox.TabStop = false;
            // 
            // TitleLabel
            // 
            TitleLabel.Dock = DockStyle.Top;
            TitleLabel.Font = new Font("Segoe UI Variable Text Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            TitleLabel.Location = new Point(0, 94);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(507, 40);
            TitleLabel.TabIndex = 1;
            TitleLabel.Text = "Firebase.Authentication";
            TitleLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // ContentPanel
            // 
            ContentPanel.AutoSize = true;
            ContentPanel.Dock = DockStyle.Bottom;
            ContentPanel.Location = new Point(0, 276);
            ContentPanel.Name = "ContentPanel";
            ContentPanel.Size = new Size(507, 0);
            ContentPanel.TabIndex = 3;
            // 
            // DividerPanel
            // 
            DividerPanel.BackColor = SystemColors.ControlDark;
            DividerPanel.Location = new Point(22, 132);
            DividerPanel.Name = "DividerPanel";
            DividerPanel.Padding = new Padding(12, 0, 12, 0);
            DividerPanel.Size = new Size(460, 2);
            DividerPanel.TabIndex = 4;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.Dock = DockStyle.Top;
            DescriptionLabel.Font = new Font("Segoe UI Variable Text", 13F, FontStyle.Regular, GraphicsUnit.Point);
            DescriptionLabel.Location = new Point(0, 134);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(507, 32);
            DescriptionLabel.TabIndex = 5;
            DescriptionLabel.Text = "Secure and easy to use authentication for C# and dotnet";
            DescriptionLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // NoticeLabel1
            // 
            NoticeLabel1.AutoSize = true;
            NoticeLabel1.Font = new Font("Segoe UI Variable Text", 9F, FontStyle.Regular, GraphicsUnit.Point);
            NoticeLabel1.Location = new Point(53, 4);
            NoticeLabel1.Name = "NoticeLabel1";
            NoticeLabel1.Size = new Size(288, 16);
            NoticeLabel1.TabIndex = 6;
            NoticeLabel1.Text = "By continuing, you are indicating that you accept our";
            NoticeLabel1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // NoticeLabel2
            // 
            NoticeLabel2.AutoSize = true;
            NoticeLabel2.Font = new Font("Segoe UI Variable Text", 9F, FontStyle.Regular, GraphicsUnit.Point);
            NoticeLabel2.Location = new Point(426, 4);
            NoticeLabel2.Name = "NoticeLabel2";
            NoticeLabel2.Size = new Size(27, 16);
            NoticeLabel2.TabIndex = 7;
            NoticeLabel2.Text = "and";
            NoticeLabel2.TextAlign = ContentAlignment.BottomCenter;
            // 
            // NoticeLink1
            // 
            NoticeLink1.ActiveLinkColor = Color.FromArgb(255, 167, 12);
            NoticeLink1.AutoSize = true;
            NoticeLink1.Font = new Font("Segoe UI Variable Text", 9F, FontStyle.Regular, GraphicsUnit.Point);
            NoticeLink1.LinkColor = Color.FromArgb(246, 130, 12);
            NoticeLink1.Location = new Point(338, 4);
            NoticeLink1.Name = "NoticeLink1";
            NoticeLink1.Size = new Size(91, 16);
            NoticeLink1.TabIndex = 8;
            NoticeLink1.TabStop = true;
            NoticeLink1.Text = "Terms of Service";
            NoticeLink1.VisitedLinkColor = Color.FromArgb(169, 89, 8);
            NoticeLink1.LinkClicked += NoticeLink1_LinkClicked;
            // 
            // NoticeLink2
            // 
            NoticeLink2.ActiveLinkColor = Color.FromArgb(255, 167, 12);
            NoticeLink2.AutoSize = true;
            NoticeLink2.Font = new Font("Segoe UI Variable Text", 9F, FontStyle.Regular, GraphicsUnit.Point);
            NoticeLink2.LinkColor = Color.FromArgb(246, 130, 12);
            NoticeLink2.Location = new Point(213, 20);
            NoticeLink2.Name = "NoticeLink2";
            NoticeLink2.Size = new Size(83, 16);
            NoticeLink2.TabIndex = 9;
            NoticeLink2.TabStop = true;
            NoticeLink2.Text = "Privacy Police.";
            NoticeLink2.VisitedLinkColor = Color.FromArgb(169, 89, 8);
            NoticeLink2.LinkClicked += NoticeLink2_LinkClicked;
            // 
            // NoticePanel
            // 
            NoticePanel.Controls.Add(NoticeLabel1);
            NoticePanel.Controls.Add(NoticeLink2);
            NoticePanel.Controls.Add(NoticeLink1);
            NoticePanel.Controls.Add(NoticeLabel2);
            NoticePanel.Dock = DockStyle.Bottom;
            NoticePanel.Location = new Point(0, 276);
            NoticePanel.Name = "NoticePanel";
            NoticePanel.Size = new Size(507, 47);
            NoticePanel.TabIndex = 10;
            // 
            // SpacerPanel
            // 
            SpacerPanel.Location = new Point(0, 0);
            SpacerPanel.Name = "SpacerPanel";
            SpacerPanel.Size = new Size(504, 320);
            SpacerPanel.TabIndex = 11;
            // 
            // HomeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Control;
            Controls.Add(ContentPanel);
            Controls.Add(NoticePanel);
            Controls.Add(DividerPanel);
            Controls.Add(DescriptionLabel);
            Controls.Add(TitleLabel);
            Controls.Add(IconBox);
            Controls.Add(SpacerPanel);
            Name = "HomeControl";
            Size = new Size(507, 323);
            ((System.ComponentModel.ISupportInitialize)IconBox).EndInit();
            NoticePanel.ResumeLayout(false);
            NoticePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox IconBox;
        private Label TitleLabel;
        private Panel ContentPanel;
        private Panel DividerPanel;
        private Label DescriptionLabel;
        private Label NoticeLabel1;
        private Label NoticeLabel2;
        private LinkLabel NoticeLink1;
        private LinkLabel NoticeLink2;
        private Panel NoticePanel;
        private Panel SpacerPanel;
    }
}
