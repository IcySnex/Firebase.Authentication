namespace Firebase.Authentication.Sample.WinForms.Controls
{
    partial class ProviderControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProviderControl));
            FirebaseAuthenticationIcons = new Authentication.WinForms.UI.FirebaseAuthenticationIcons();
            FacebookButton = new Authentication.WinForms.UI.FirebaseAuthenticationButton();
            GoogleButton = new Authentication.WinForms.UI.FirebaseAuthenticationButton();
            AppleButton = new Authentication.WinForms.UI.FirebaseAuthenticationButton();
            GithubButton = new Authentication.WinForms.UI.FirebaseAuthenticationButton();
            TwitterButton = new Authentication.WinForms.UI.FirebaseAuthenticationButton();
            MicrosoftButton = new Authentication.WinForms.UI.FirebaseAuthenticationButton();
            YahooButton = new Authentication.WinForms.UI.FirebaseAuthenticationButton();
            EmailButton = new Authentication.WinForms.UI.FirebaseAuthenticationButton();
            PhoneButton = new Authentication.WinForms.UI.FirebaseAuthenticationButton();
            GuestButton = new Authentication.WinForms.UI.FirebaseAuthenticationButton();
            SuspendLayout();
            // 
            // FirebaseAuthenticationIcons
            // 
            FirebaseAuthenticationIcons.Height = 19;
            // 
            // 
            // 
            FirebaseAuthenticationIcons.List.ImageStream = (ImageListStreamer)resources.GetObject("FirebaseAuthenticationIcons.List.ImageStream");
            FirebaseAuthenticationIcons.List.TransparentColor = Color.Transparent;
            FirebaseAuthenticationIcons.List.Images.SetKeyName(0, "Firebase");
            FirebaseAuthenticationIcons.List.Images.SetKeyName(1, "EmailAndPassword");
            FirebaseAuthenticationIcons.List.Images.SetKeyName(2, "PhoneNumber");
            FirebaseAuthenticationIcons.List.Images.SetKeyName(3, "Facebook");
            FirebaseAuthenticationIcons.List.Images.SetKeyName(4, "Google");
            FirebaseAuthenticationIcons.List.Images.SetKeyName(5, "Apple");
            FirebaseAuthenticationIcons.List.Images.SetKeyName(6, "Github");
            FirebaseAuthenticationIcons.List.Images.SetKeyName(7, "Twitter");
            FirebaseAuthenticationIcons.List.Images.SetKeyName(8, "Microsoft");
            FirebaseAuthenticationIcons.List.Images.SetKeyName(9, "Yahoo");
            FirebaseAuthenticationIcons.List.Images.SetKeyName(10, "Anonymously");
            FirebaseAuthenticationIcons.SpacingHeight = 0;
            FirebaseAuthenticationIcons.SpacingWidth = 8;
            FirebaseAuthenticationIcons.Width = 19;
            // 
            // FacebookButton
            // 
            FacebookButton.BackColor = Color.FromArgb(59, 89, 152);
            FacebookButton.CornerRadius = 2;
            FacebookButton.FlatAppearance.BorderSize = 0;
            FacebookButton.FlatStyle = FlatStyle.Flat;
            FacebookButton.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            FacebookButton.ForeColor = Color.White;
            FacebookButton.ImageAlign = ContentAlignment.MiddleLeft;
            FacebookButton.ImageKey = "Facebook";
            FacebookButton.ImageList = FirebaseAuthenticationIcons.List;
            FacebookButton.Location = new Point(145, 50);
            FacebookButton.Name = "FacebookButton";
            FacebookButton.Padding = new Padding(12, 0, 12, 0);
            FacebookButton.Size = new Size(220, 40);
            FacebookButton.TabIndex = 0;
            FacebookButton.Text = "Sign in with Facebook";
            FacebookButton.TextAlign = ContentAlignment.MiddleLeft;
            FacebookButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            FacebookButton.UseVisualStyleBackColor = false;
            FacebookButton.Click += ProviderButton_Click;
            // 
            // GoogleButton
            // 
            GoogleButton.BackColor = Color.White;
            GoogleButton.CornerRadius = 2;
            GoogleButton.FlatAppearance.BorderSize = 0;
            GoogleButton.FlatStyle = FlatStyle.Flat;
            GoogleButton.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            GoogleButton.ForeColor = Color.FromArgb(101, 101, 101);
            GoogleButton.ImageAlign = ContentAlignment.MiddleLeft;
            GoogleButton.ImageKey = "Google";
            GoogleButton.ImageList = FirebaseAuthenticationIcons.List;
            GoogleButton.Location = new Point(145, 100);
            GoogleButton.Name = "GoogleButton";
            GoogleButton.Padding = new Padding(12, 0, 12, 0);
            GoogleButton.Size = new Size(220, 40);
            GoogleButton.TabIndex = 1;
            GoogleButton.Text = "Sign in with Google";
            GoogleButton.TextAlign = ContentAlignment.MiddleLeft;
            GoogleButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            GoogleButton.UseVisualStyleBackColor = false;
            GoogleButton.Click += ProviderButton_Click;
            // 
            // AppleButton
            // 
            AppleButton.BackColor = Color.Black;
            AppleButton.CornerRadius = 2;
            AppleButton.FlatAppearance.BorderSize = 0;
            AppleButton.FlatStyle = FlatStyle.Flat;
            AppleButton.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            AppleButton.ForeColor = Color.White;
            AppleButton.ImageAlign = ContentAlignment.MiddleLeft;
            AppleButton.ImageKey = "Apple";
            AppleButton.ImageList = FirebaseAuthenticationIcons.List;
            AppleButton.Location = new Point(145, 150);
            AppleButton.Name = "AppleButton";
            AppleButton.Padding = new Padding(12, 0, 12, 0);
            AppleButton.Size = new Size(220, 40);
            AppleButton.TabIndex = 2;
            AppleButton.Text = "Sign in with Apple";
            AppleButton.TextAlign = ContentAlignment.MiddleLeft;
            AppleButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            AppleButton.UseVisualStyleBackColor = false;
            AppleButton.Click += ProviderButton_Click;
            // 
            // GithubButton
            // 
            GithubButton.BackColor = Color.FromArgb(51, 51, 51);
            GithubButton.CornerRadius = 2;
            GithubButton.FlatAppearance.BorderSize = 0;
            GithubButton.FlatStyle = FlatStyle.Flat;
            GithubButton.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            GithubButton.ForeColor = Color.White;
            GithubButton.ImageAlign = ContentAlignment.MiddleLeft;
            GithubButton.ImageKey = "Github";
            GithubButton.ImageList = FirebaseAuthenticationIcons.List;
            GithubButton.Location = new Point(145, 200);
            GithubButton.Name = "GithubButton";
            GithubButton.Padding = new Padding(12, 0, 12, 0);
            GithubButton.Size = new Size(220, 40);
            GithubButton.TabIndex = 3;
            GithubButton.Text = "Sign in with GitHub";
            GithubButton.TextAlign = ContentAlignment.MiddleLeft;
            GithubButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            GithubButton.UseVisualStyleBackColor = false;
            GithubButton.Click += ProviderButton_Click;
            // 
            // TwitterButton
            // 
            TwitterButton.BackColor = Color.FromArgb(85, 172, 238);
            TwitterButton.CornerRadius = 2;
            TwitterButton.FlatAppearance.BorderSize = 0;
            TwitterButton.FlatStyle = FlatStyle.Flat;
            TwitterButton.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            TwitterButton.ForeColor = Color.White;
            TwitterButton.ImageAlign = ContentAlignment.MiddleLeft;
            TwitterButton.ImageKey = "Twitter";
            TwitterButton.ImageList = FirebaseAuthenticationIcons.List;
            TwitterButton.Location = new Point(145, 250);
            TwitterButton.Name = "TwitterButton";
            TwitterButton.Padding = new Padding(12, 0, 12, 0);
            TwitterButton.Size = new Size(220, 40);
            TwitterButton.TabIndex = 4;
            TwitterButton.Text = "Sign in with Twitter";
            TwitterButton.TextAlign = ContentAlignment.MiddleLeft;
            TwitterButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            TwitterButton.UseVisualStyleBackColor = false;
            TwitterButton.Click += ProviderButton_Click;
            // 
            // MicrosoftButton
            // 
            MicrosoftButton.BackColor = Color.FromArgb(47, 47, 47);
            MicrosoftButton.CornerRadius = 2;
            MicrosoftButton.FlatAppearance.BorderSize = 0;
            MicrosoftButton.FlatStyle = FlatStyle.Flat;
            MicrosoftButton.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            MicrosoftButton.ForeColor = Color.White;
            MicrosoftButton.ImageAlign = ContentAlignment.MiddleLeft;
            MicrosoftButton.ImageKey = "Microsoft";
            MicrosoftButton.ImageList = FirebaseAuthenticationIcons.List;
            MicrosoftButton.Location = new Point(145, 300);
            MicrosoftButton.Name = "MicrosoftButton";
            MicrosoftButton.Padding = new Padding(12, 0, 12, 0);
            MicrosoftButton.Size = new Size(220, 40);
            MicrosoftButton.TabIndex = 5;
            MicrosoftButton.Text = "Sign in with Microsoft";
            MicrosoftButton.TextAlign = ContentAlignment.MiddleLeft;
            MicrosoftButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            MicrosoftButton.UseVisualStyleBackColor = false;
            MicrosoftButton.Click += ProviderButton_Click;
            // 
            // YahooButton
            // 
            YahooButton.BackColor = Color.FromArgb(109, 82, 142);
            YahooButton.CornerRadius = 2;
            YahooButton.FlatAppearance.BorderSize = 0;
            YahooButton.FlatStyle = FlatStyle.Flat;
            YahooButton.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            YahooButton.ForeColor = Color.White;
            YahooButton.ImageAlign = ContentAlignment.MiddleLeft;
            YahooButton.ImageKey = "Yahoo";
            YahooButton.ImageList = FirebaseAuthenticationIcons.List;
            YahooButton.Location = new Point(145, 349);
            YahooButton.Name = "YahooButton";
            YahooButton.Padding = new Padding(12, 0, 12, 0);
            YahooButton.Size = new Size(220, 40);
            YahooButton.TabIndex = 6;
            YahooButton.Text = "Sign in with Yahoo";
            YahooButton.TextAlign = ContentAlignment.MiddleLeft;
            YahooButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            YahooButton.UseVisualStyleBackColor = false;
            YahooButton.Click += ProviderButton_Click;
            // 
            // EmailButton
            // 
            EmailButton.BackColor = Color.FromArgb(219, 68, 55);
            EmailButton.CornerRadius = 2;
            EmailButton.FlatAppearance.BorderSize = 0;
            EmailButton.FlatStyle = FlatStyle.Flat;
            EmailButton.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            EmailButton.ForeColor = Color.White;
            EmailButton.ImageAlign = ContentAlignment.MiddleLeft;
            EmailButton.ImageKey = "EmailAndPassword";
            EmailButton.ImageList = FirebaseAuthenticationIcons.List;
            EmailButton.Location = new Point(145, 399);
            EmailButton.Name = "EmailButton";
            EmailButton.Padding = new Padding(12, 0, 12, 0);
            EmailButton.Size = new Size(220, 40);
            EmailButton.TabIndex = 7;
            EmailButton.Text = "Sign in with email";
            EmailButton.TextAlign = ContentAlignment.MiddleLeft;
            EmailButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            EmailButton.UseVisualStyleBackColor = false;
            EmailButton.Click += EmailButton_Click;
            // 
            // PhoneButton
            // 
            PhoneButton.BackColor = Color.FromArgb(2, 189, 126);
            PhoneButton.CornerRadius = 2;
            PhoneButton.FlatAppearance.BorderSize = 0;
            PhoneButton.FlatStyle = FlatStyle.Flat;
            PhoneButton.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            PhoneButton.ForeColor = Color.White;
            PhoneButton.ImageAlign = ContentAlignment.MiddleLeft;
            PhoneButton.ImageKey = "PhoneNumber";
            PhoneButton.ImageList = FirebaseAuthenticationIcons.List;
            PhoneButton.Location = new Point(145, 449);
            PhoneButton.Name = "PhoneButton";
            PhoneButton.Padding = new Padding(12, 0, 12, 0);
            PhoneButton.Size = new Size(220, 40);
            PhoneButton.TabIndex = 8;
            PhoneButton.Text = "Sign in with phone";
            PhoneButton.TextAlign = ContentAlignment.MiddleLeft;
            PhoneButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            PhoneButton.UseVisualStyleBackColor = false;
            PhoneButton.Click += PhoneButton_Click;
            // 
            // GuestButton
            // 
            GuestButton.BackColor = Color.FromArgb(230, 168, 0);
            GuestButton.CornerRadius = 2;
            GuestButton.FlatAppearance.BorderSize = 0;
            GuestButton.FlatStyle = FlatStyle.Flat;
            GuestButton.Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            GuestButton.ForeColor = Color.White;
            GuestButton.ImageAlign = ContentAlignment.MiddleLeft;
            GuestButton.ImageKey = "Anonymously";
            GuestButton.ImageList = FirebaseAuthenticationIcons.List;
            GuestButton.Location = new Point(145, 498);
            GuestButton.Name = "GuestButton";
            GuestButton.Padding = new Padding(12, 0, 12, 0);
            GuestButton.Size = new Size(220, 40);
            GuestButton.TabIndex = 9;
            GuestButton.Text = "Continue as guest";
            GuestButton.TextAlign = ContentAlignment.MiddleLeft;
            GuestButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            GuestButton.UseVisualStyleBackColor = false;
            GuestButton.Click += GuestButton_Click;
            // 
            // ProviderControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(GuestButton);
            Controls.Add(PhoneButton);
            Controls.Add(EmailButton);
            Controls.Add(YahooButton);
            Controls.Add(MicrosoftButton);
            Controls.Add(TwitterButton);
            Controls.Add(GithubButton);
            Controls.Add(AppleButton);
            Controls.Add(GoogleButton);
            Controls.Add(FacebookButton);
            Name = "ProviderControl";
            Size = new Size(513, 586);
            ResumeLayout(false);
        }

        #endregion

        private Authentication.WinForms.UI.FirebaseAuthenticationIcons FirebaseAuthenticationIcons;
        private Authentication.WinForms.UI.FirebaseAuthenticationButton FacebookButton;
        private Authentication.WinForms.UI.FirebaseAuthenticationButton GoogleButton;
        private Authentication.WinForms.UI.FirebaseAuthenticationButton AppleButton;
        private Authentication.WinForms.UI.FirebaseAuthenticationButton GithubButton;
        private Authentication.WinForms.UI.FirebaseAuthenticationButton TwitterButton;
        private Authentication.WinForms.UI.FirebaseAuthenticationButton MicrosoftButton;
        private Authentication.WinForms.UI.FirebaseAuthenticationButton YahooButton;
        private Authentication.WinForms.UI.FirebaseAuthenticationButton EmailButton;
        private Authentication.WinForms.UI.FirebaseAuthenticationButton PhoneButton;
        private Authentication.WinForms.UI.FirebaseAuthenticationButton GuestButton;
    }
}
