namespace Firebase.Authentication.Sample.WinForms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            NavigationPanel = new Panel();
            SettingsButton = new Button();
            UserInfoButton = new Button();
            LoggerButton = new Button();
            GitHubButton = new Button();
            HomeButton = new Button();
            ContentPanel = new Panel();
            NavigationPanel.SuspendLayout();
            SuspendLayout();
            // 
            // NavigationPanel
            // 
            NavigationPanel.BackColor = Color.FromArgb(255, 190, 92);
            NavigationPanel.Controls.Add(SettingsButton);
            NavigationPanel.Controls.Add(UserInfoButton);
            NavigationPanel.Controls.Add(LoggerButton);
            NavigationPanel.Controls.Add(GitHubButton);
            NavigationPanel.Controls.Add(HomeButton);
            NavigationPanel.Dock = DockStyle.Top;
            NavigationPanel.Location = new Point(0, 0);
            NavigationPanel.Name = "NavigationPanel";
            NavigationPanel.Size = new Size(504, 48);
            NavigationPanel.TabIndex = 1;
            // 
            // SettingsButton
            // 
            SettingsButton.AutoSize = true;
            SettingsButton.Dock = DockStyle.Left;
            SettingsButton.FlatAppearance.BorderSize = 0;
            SettingsButton.FlatStyle = FlatStyle.Flat;
            SettingsButton.ForeColor = SystemColors.ButtonFace;
            SettingsButton.Location = new Point(150, 0);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(75, 48);
            SettingsButton.TabIndex = 5;
            SettingsButton.Text = "Settings";
            SettingsButton.UseVisualStyleBackColor = true;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // UserInfoButton
            // 
            UserInfoButton.AutoSize = true;
            UserInfoButton.Dock = DockStyle.Left;
            UserInfoButton.FlatAppearance.BorderSize = 0;
            UserInfoButton.FlatStyle = FlatStyle.Flat;
            UserInfoButton.ForeColor = SystemColors.ButtonFace;
            UserInfoButton.Location = new Point(75, 0);
            UserInfoButton.Name = "UserInfoButton";
            UserInfoButton.Size = new Size(75, 48);
            UserInfoButton.TabIndex = 4;
            UserInfoButton.Text = "User Info";
            UserInfoButton.UseVisualStyleBackColor = true;
            UserInfoButton.Visible = false;
            UserInfoButton.Click += UserInfoButton_Click;
            // 
            // LoggerButton
            // 
            LoggerButton.AutoSize = true;
            LoggerButton.Dock = DockStyle.Right;
            LoggerButton.FlatAppearance.BorderSize = 0;
            LoggerButton.FlatStyle = FlatStyle.Flat;
            LoggerButton.ForeColor = SystemColors.ButtonFace;
            LoggerButton.Location = new Point(324, 0);
            LoggerButton.Name = "LoggerButton";
            LoggerButton.Size = new Size(90, 48);
            LoggerButton.TabIndex = 3;
            LoggerButton.Text = "Show Logger";
            LoggerButton.UseVisualStyleBackColor = true;
            LoggerButton.Click += LoggerButton_Click;
            // 
            // GitHubButton
            // 
            GitHubButton.AutoSize = true;
            GitHubButton.Dock = DockStyle.Right;
            GitHubButton.FlatAppearance.BorderSize = 0;
            GitHubButton.FlatStyle = FlatStyle.Flat;
            GitHubButton.ForeColor = SystemColors.ButtonFace;
            GitHubButton.Location = new Point(414, 0);
            GitHubButton.Name = "GitHubButton";
            GitHubButton.Size = new Size(90, 48);
            GitHubButton.TabIndex = 2;
            GitHubButton.Text = "GitHub";
            GitHubButton.UseVisualStyleBackColor = true;
            GitHubButton.Click += GitHubButton_Click;
            // 
            // HomeButton
            // 
            HomeButton.AutoSize = true;
            HomeButton.Dock = DockStyle.Left;
            HomeButton.FlatAppearance.BorderSize = 0;
            HomeButton.FlatStyle = FlatStyle.Flat;
            HomeButton.ForeColor = SystemColors.ButtonFace;
            HomeButton.Location = new Point(0, 0);
            HomeButton.Name = "HomeButton";
            HomeButton.Size = new Size(75, 48);
            HomeButton.TabIndex = 0;
            HomeButton.Text = "Home";
            HomeButton.UseVisualStyleBackColor = true;
            HomeButton.Click += HomeButton_Click;
            // 
            // ContentPanel
            // 
            ContentPanel.AutoSize = true;
            ContentPanel.Dock = DockStyle.Fill;
            ContentPanel.Location = new Point(0, 48);
            ContentPanel.Name = "ContentPanel";
            ContentPanel.Size = new Size(504, 863);
            ContentPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 911);
            Controls.Add(ContentPanel);
            Controls.Add(NavigationPanel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(460, 890);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WinForms Sample - Firebase Authentication";
            NavigationPanel.ResumeLayout(false);
            NavigationPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel NavigationPanel;
        private Button LoggerButton;
        private Button GitHubButton;
        private Button HomeButton;
        private Button SettingsButton;
        private Button UserInfoButton;
        private Panel ContentPanel;
    }
}