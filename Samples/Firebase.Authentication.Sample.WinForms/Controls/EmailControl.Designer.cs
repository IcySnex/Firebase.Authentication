namespace Firebase.Authentication.Sample.WinForms.Controls
{
    partial class EmailControl
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
            EmailLabel = new Label();
            EmailContent = new TextBox();
            ForgotPasswordLink = new LinkLabel();
            CancelButton = new Authentication.WinForms.UI.FirebaseAuthenticationButton();
            SignInButton = new Authentication.WinForms.UI.FirebaseAuthenticationButton();
            EmailPanel = new Panel();
            DisplayNamePanel = new Panel();
            DisplayNameLabel = new Label();
            DisplayNameContent = new TextBox();
            PasswordPanel = new Panel();
            PasswordTitel = new Label();
            PasswordContent = new TextBox();
            EmailPanel.SuspendLayout();
            DisplayNamePanel.SuspendLayout();
            PasswordPanel.SuspendLayout();
            SuspendLayout();
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            EmailLabel.ForeColor = SystemColors.ControlLightLight;
            EmailLabel.Location = new Point(0, 7);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(46, 20);
            EmailLabel.TabIndex = 7;
            EmailLabel.Text = "Email";
            // 
            // EmailContent
            // 
            EmailContent.Location = new Point(0, 30);
            EmailContent.Name = "EmailContent";
            EmailContent.Size = new Size(300, 23);
            EmailContent.TabIndex = 8;
            // 
            // ForgotPasswordLink
            // 
            ForgotPasswordLink.ActiveLinkColor = Color.FromArgb(255, 167, 12);
            ForgotPasswordLink.AutoSize = true;
            ForgotPasswordLink.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ForgotPasswordLink.LinkColor = Color.FromArgb(246, 130, 12);
            ForgotPasswordLink.Location = new Point(106, 217);
            ForgotPasswordLink.Name = "ForgotPasswordLink";
            ForgotPasswordLink.Size = new Size(127, 20);
            ForgotPasswordLink.TabIndex = 13;
            ForgotPasswordLink.TabStop = true;
            ForgotPasswordLink.Text = "Forgot password?";
            ForgotPasswordLink.VisitedLinkColor = Color.FromArgb(169, 89, 8);
            ForgotPasswordLink.LinkClicked += ForgotPasswordLink_LinkClicked;
            // 
            // CancelButton
            // 
            CancelButton.BackColor = Color.FromArgb(51, 51, 51);
            CancelButton.CornerRadius = 2;
            CancelButton.FlatAppearance.BorderSize = 0;
            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            CancelButton.ForeColor = Color.FromArgb(196, 196, 196);
            CancelButton.ImageAlign = ContentAlignment.MiddleLeft;
            CancelButton.Location = new Point(106, 279);
            CancelButton.Name = "CancelButton";
            CancelButton.Padding = new Padding(12, 0, 12, 0);
            CancelButton.Size = new Size(144, 40);
            CancelButton.TabIndex = 15;
            CancelButton.Text = "Cancel";
            CancelButton.TextAlign = ContentAlignment.MiddleLeft;
            CancelButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            CancelButton.UseVisualStyleBackColor = false;
            CancelButton.Click += CancelButton_Click;
            // 
            // SignInButton
            // 
            SignInButton.BackColor = Color.FromArgb(255, 190, 92);
            SignInButton.CornerRadius = 2;
            SignInButton.FlatAppearance.BorderSize = 0;
            SignInButton.FlatStyle = FlatStyle.Flat;
            SignInButton.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            SignInButton.ForeColor = Color.Black;
            SignInButton.ImageAlign = ContentAlignment.MiddleLeft;
            SignInButton.Location = new Point(262, 279);
            SignInButton.Name = "SignInButton";
            SignInButton.Padding = new Padding(12, 0, 12, 0);
            SignInButton.Size = new Size(144, 40);
            SignInButton.TabIndex = 16;
            SignInButton.Text = "Sign in";
            SignInButton.TextAlign = ContentAlignment.MiddleLeft;
            SignInButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            SignInButton.UseVisualStyleBackColor = false;
            SignInButton.Click += SignInButton_Click;
            // 
            // EmailPanel
            // 
            EmailPanel.Controls.Add(EmailLabel);
            EmailPanel.Controls.Add(EmailContent);
            EmailPanel.Location = new Point(106, 38);
            EmailPanel.Name = "EmailPanel";
            EmailPanel.Size = new Size(300, 57);
            EmailPanel.TabIndex = 17;
            // 
            // DisplayNamePanel
            // 
            DisplayNamePanel.Controls.Add(DisplayNameLabel);
            DisplayNamePanel.Controls.Add(DisplayNameContent);
            DisplayNamePanel.Location = new Point(106, 98);
            DisplayNamePanel.Name = "DisplayNamePanel";
            DisplayNamePanel.Size = new Size(300, 57);
            DisplayNamePanel.TabIndex = 18;
            // 
            // DisplayNameLabel
            // 
            DisplayNameLabel.AutoSize = true;
            DisplayNameLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            DisplayNameLabel.ForeColor = SystemColors.ControlLightLight;
            DisplayNameLabel.Location = new Point(0, 7);
            DisplayNameLabel.Name = "DisplayNameLabel";
            DisplayNameLabel.Size = new Size(99, 20);
            DisplayNameLabel.TabIndex = 7;
            DisplayNameLabel.Text = "Display name";
            // 
            // DisplayNameContent
            // 
            DisplayNameContent.Location = new Point(0, 30);
            DisplayNameContent.Name = "DisplayNameContent";
            DisplayNameContent.Size = new Size(300, 23);
            DisplayNameContent.TabIndex = 8;
            // 
            // PasswordPanel
            // 
            PasswordPanel.Controls.Add(PasswordTitel);
            PasswordPanel.Controls.Add(PasswordContent);
            PasswordPanel.Location = new Point(106, 158);
            PasswordPanel.Name = "PasswordPanel";
            PasswordPanel.Size = new Size(300, 57);
            PasswordPanel.TabIndex = 19;
            // 
            // PasswordTitel
            // 
            PasswordTitel.AutoSize = true;
            PasswordTitel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordTitel.ForeColor = SystemColors.ControlLightLight;
            PasswordTitel.Location = new Point(0, 7);
            PasswordTitel.Name = "PasswordTitel";
            PasswordTitel.Size = new Size(70, 20);
            PasswordTitel.TabIndex = 7;
            PasswordTitel.Text = "Password";
            // 
            // PasswordContent
            // 
            PasswordContent.Location = new Point(0, 30);
            PasswordContent.Name = "PasswordContent";
            PasswordContent.Size = new Size(300, 23);
            PasswordContent.TabIndex = 8;
            PasswordContent.UseSystemPasswordChar = true;
            // 
            // EmailControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(PasswordPanel);
            Controls.Add(DisplayNamePanel);
            Controls.Add(EmailPanel);
            Controls.Add(SignInButton);
            Controls.Add(CancelButton);
            Controls.Add(ForgotPasswordLink);
            Name = "EmailControl";
            Size = new Size(513, 359);
            EmailPanel.ResumeLayout(false);
            EmailPanel.PerformLayout();
            DisplayNamePanel.ResumeLayout(false);
            DisplayNamePanel.PerformLayout();
            PasswordPanel.ResumeLayout(false);
            PasswordPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label EmailLabel;
        private TextBox EmailContent;
        private LinkLabel ForgotPasswordLink;
        private Authentication.WinForms.UI.FirebaseAuthenticationButton CancelButton;
        private Authentication.WinForms.UI.FirebaseAuthenticationButton SignInButton;
        private Panel EmailPanel;
        private Panel DisplayNamePanel;
        private Label DisplayNameLabel;
        private TextBox DisplayNameContent;
        private Panel PasswordPanel;
        private Label PasswordTitel;
        private TextBox PasswordContent;
    }
}
