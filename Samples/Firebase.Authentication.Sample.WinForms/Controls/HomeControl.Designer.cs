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
            ((System.ComponentModel.ISupportInitialize)IconBox).BeginInit();
            SuspendLayout();
            // 
            // IconBox
            // 
            IconBox.Dock = DockStyle.Top;
            IconBox.Image = Properties.Resources.firebase;
            IconBox.Location = new Point(0, 0);
            IconBox.Name = "IconBox";
            IconBox.Size = new Size(513, 100);
            IconBox.SizeMode = PictureBoxSizeMode.Zoom;
            IconBox.TabIndex = 0;
            IconBox.TabStop = false;
            // 
            // TitleLabel
            // 
            TitleLabel.Dock = DockStyle.Top;
            TitleLabel.Font = new Font("Segoe UI Variable Text Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            TitleLabel.Location = new Point(0, 100);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(513, 40);
            TitleLabel.TabIndex = 1;
            TitleLabel.Text = "Firebase.Authentication";
            TitleLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // ContentPanel
            // 
            ContentPanel.Dock = DockStyle.Bottom;
            ContentPanel.Location = new Point(0, 207);
            ContentPanel.Name = "ContentPanel";
            ContentPanel.Size = new Size(513, 556);
            ContentPanel.TabIndex = 3;
            // 
            // DividerPanel
            // 
            DividerPanel.BackColor = SystemColors.ControlDark;
            DividerPanel.Dock = DockStyle.Top;
            DividerPanel.Location = new Point(0, 140);
            DividerPanel.Name = "DividerPanel";
            DividerPanel.Padding = new Padding(12, 0, 12, 0);
            DividerPanel.Size = new Size(513, 2);
            DividerPanel.TabIndex = 4;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.Dock = DockStyle.Top;
            DescriptionLabel.Font = new Font("Segoe UI Variable Text", 13F, FontStyle.Regular, GraphicsUnit.Point);
            DescriptionLabel.Location = new Point(0, 142);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(513, 34);
            DescriptionLabel.TabIndex = 5;
            DescriptionLabel.Text = "Secure and easy to use authentication for C# and dotnet";
            DescriptionLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // HomeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(DescriptionLabel);
            Controls.Add(DividerPanel);
            Controls.Add(ContentPanel);
            Controls.Add(TitleLabel);
            Controls.Add(IconBox);
            Name = "HomeControl";
            Size = new Size(513, 763);
            ((System.ComponentModel.ISupportInitialize)IconBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox IconBox;
        private Label TitleLabel;
        private Panel ContentPanel;
        private Panel DividerPanel;
        private Label DescriptionLabel;
    }
}
