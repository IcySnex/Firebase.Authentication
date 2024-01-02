namespace Firebase.Authentication.Sample.WinForms.Controls
{
    partial class SettingsControl
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
            SettingsLabel = new Label();
            RestartButton = new Button();
            ApiKeyPanel = new Panel();
            ApiKeyDescription = new Label();
            ApiKeyTitle = new Label();
            ApiKeyContent = new TextBox();
            DividerPanel = new Panel();
            HttpTimeoutPanel = new Panel();
            HttpTimeoutContent = new MaskedTextBox();
            HttpTimeoutDescription = new Label();
            HttpTimeoutTitle = new Label();
            HttpProxyPanel = new Panel();
            HttpProxyDescription = new Label();
            HttpProxyTitle = new Label();
            HttpProxyContent = new TextBox();
            TitlePanel = new Panel();
            TitleDescription = new Label();
            TitleTitle = new Label();
            TitleContent = new TextBox();
            IconPanel = new Panel();
            IconDescription = new Label();
            IconTitle = new Label();
            IconContent = new TextBox();
            StartupLocationPanel = new Panel();
            StartPositionContent = new ComboBox();
            StartupLocationDescription = new Label();
            StartupLocationTitle = new Label();
            LeftPanel = new Panel();
            LeftContent = new NumericUpDown();
            LeftLable = new Label();
            LeftTitle = new Label();
            TopPanel = new Panel();
            TopContent = new NumericUpDown();
            TopDescription = new Label();
            TopLabel = new Label();
            ShowAsDialogPanel = new Panel();
            ShowAsDialogContent = new CheckBox();
            ShowAsDialogDescription = new Label();
            ShowAsDialogLabel = new Label();
            FlowRedirectToPanel = new Panel();
            FlowRedirectToDescription = new Label();
            FlowRedirectToLabel = new Label();
            FlowRedirectToContent = new TextBox();
            TimeoutPanel = new Panel();
            TimeoutContent = new MaskedTextBox();
            TimeoutDescription = new Label();
            TimeoutLabel = new Label();
            ReCaptchaSiteKeyPanel = new Panel();
            ReCaptchaSiteKeyDescription = new Label();
            ReCaptchaSiteKeyLabel = new Label();
            ReCaptchaSiteKeyContent = new TextBox();
            ReCaptchaHostNamePanel = new Panel();
            ReCaptchaHostNameDescription = new Label();
            ReCaptchaHostNameLabel = new Label();
            ReCaptchaHostNameContent = new TextBox();
            ImgurClientIdPanel = new Panel();
            ImgurClientIdDescription = new Label();
            ImgurClientIdTitel = new Label();
            ImgurClientIdContent = new TextBox();
            ApiKeyPanel.SuspendLayout();
            HttpTimeoutPanel.SuspendLayout();
            HttpProxyPanel.SuspendLayout();
            TitlePanel.SuspendLayout();
            IconPanel.SuspendLayout();
            StartupLocationPanel.SuspendLayout();
            LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LeftContent).BeginInit();
            TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TopContent).BeginInit();
            ShowAsDialogPanel.SuspendLayout();
            FlowRedirectToPanel.SuspendLayout();
            TimeoutPanel.SuspendLayout();
            ReCaptchaSiteKeyPanel.SuspendLayout();
            ReCaptchaHostNamePanel.SuspendLayout();
            ImgurClientIdPanel.SuspendLayout();
            SuspendLayout();
            // 
            // SettingsLabel
            // 
            SettingsLabel.AutoSize = true;
            SettingsLabel.Font = new Font("Segoe UI Semibold", 18.75F, FontStyle.Bold, GraphicsUnit.Point);
            SettingsLabel.Location = new Point(10, 10);
            SettingsLabel.Name = "SettingsLabel";
            SettingsLabel.Size = new Size(108, 35);
            SettingsLabel.TabIndex = 1;
            SettingsLabel.Text = "Settings";
            // 
            // RestartButton
            // 
            RestartButton.Location = new Point(12, 51);
            RestartButton.Name = "RestartButton";
            RestartButton.Size = new Size(467, 42);
            RestartButton.TabIndex = 2;
            RestartButton.Text = "Updating settings requires app restart";
            RestartButton.UseVisualStyleBackColor = true;
            RestartButton.Click += RestartButton_Click;
            // 
            // ApiKeyPanel
            // 
            ApiKeyPanel.BackColor = SystemColors.ControlLight;
            ApiKeyPanel.Controls.Add(ApiKeyDescription);
            ApiKeyPanel.Controls.Add(ApiKeyTitle);
            ApiKeyPanel.Controls.Add(ApiKeyContent);
            ApiKeyPanel.Location = new Point(12, 120);
            ApiKeyPanel.Name = "ApiKeyPanel";
            ApiKeyPanel.Size = new Size(467, 97);
            ApiKeyPanel.TabIndex = 6;
            // 
            // ApiKeyDescription
            // 
            ApiKeyDescription.AutoSize = true;
            ApiKeyDescription.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ApiKeyDescription.ForeColor = SystemColors.ControlDarkDark;
            ApiKeyDescription.Location = new Point(15, 35);
            ApiKeyDescription.Name = "ApiKeyDescription";
            ApiKeyDescription.Size = new Size(178, 20);
            ApiKeyDescription.TabIndex = 4;
            ApiKeyDescription.Text = "The Firebase Web API key";
            // 
            // ApiKeyTitle
            // 
            ApiKeyTitle.AutoSize = true;
            ApiKeyTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ApiKeyTitle.Location = new Point(14, 12);
            ApiKeyTitle.Name = "ApiKeyTitle";
            ApiKeyTitle.Size = new Size(70, 25);
            ApiKeyTitle.TabIndex = 3;
            ApiKeyTitle.Text = "ApiKey";
            // 
            // ApiKeyContent
            // 
            ApiKeyContent.Location = new Point(15, 60);
            ApiKeyContent.Name = "ApiKeyContent";
            ApiKeyContent.Size = new Size(420, 23);
            ApiKeyContent.TabIndex = 6;
            // 
            // DividerPanel
            // 
            DividerPanel.BackColor = SystemColors.ControlDark;
            DividerPanel.Location = new Point(0, 103);
            DividerPanel.Name = "DividerPanel";
            DividerPanel.Padding = new Padding(12, 0, 12, 0);
            DividerPanel.Size = new Size(484, 2);
            DividerPanel.TabIndex = 7;
            // 
            // HttpTimeoutPanel
            // 
            HttpTimeoutPanel.BackColor = SystemColors.ControlLight;
            HttpTimeoutPanel.Controls.Add(HttpTimeoutContent);
            HttpTimeoutPanel.Controls.Add(HttpTimeoutDescription);
            HttpTimeoutPanel.Controls.Add(HttpTimeoutTitle);
            HttpTimeoutPanel.Location = new Point(12, 229);
            HttpTimeoutPanel.Name = "HttpTimeoutPanel";
            HttpTimeoutPanel.Size = new Size(467, 97);
            HttpTimeoutPanel.TabIndex = 7;
            // 
            // HttpTimeoutContent
            // 
            HttpTimeoutContent.Location = new Point(17, 60);
            HttpTimeoutContent.Mask = "00:00:00";
            HttpTimeoutContent.Name = "HttpTimeoutContent";
            HttpTimeoutContent.Size = new Size(420, 23);
            HttpTimeoutContent.TabIndex = 7;
            HttpTimeoutContent.ValidatingType = typeof(DateTime);
            // 
            // HttpTimeoutDescription
            // 
            HttpTimeoutDescription.AutoSize = true;
            HttpTimeoutDescription.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            HttpTimeoutDescription.ForeColor = SystemColors.ControlDarkDark;
            HttpTimeoutDescription.Location = new Point(15, 35);
            HttpTimeoutDescription.Name = "HttpTimeoutDescription";
            HttpTimeoutDescription.Size = new Size(291, 20);
            HttpTimeoutDescription.TabIndex = 4;
            HttpTimeoutDescription.Text = "The time span in which a request times out";
            // 
            // HttpTimeoutTitle
            // 
            HttpTimeoutTitle.AutoSize = true;
            HttpTimeoutTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            HttpTimeoutTitle.Location = new Point(14, 12);
            HttpTimeoutTitle.Name = "HttpTimeoutTitle";
            HttpTimeoutTitle.Size = new Size(117, 25);
            HttpTimeoutTitle.TabIndex = 3;
            HttpTimeoutTitle.Text = "HttpTimeout";
            // 
            // HttpProxyPanel
            // 
            HttpProxyPanel.BackColor = SystemColors.ControlLight;
            HttpProxyPanel.Controls.Add(HttpProxyDescription);
            HttpProxyPanel.Controls.Add(HttpProxyTitle);
            HttpProxyPanel.Controls.Add(HttpProxyContent);
            HttpProxyPanel.Location = new Point(12, 337);
            HttpProxyPanel.Name = "HttpProxyPanel";
            HttpProxyPanel.Size = new Size(467, 97);
            HttpProxyPanel.TabIndex = 8;
            // 
            // HttpProxyDescription
            // 
            HttpProxyDescription.AutoSize = true;
            HttpProxyDescription.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            HttpProxyDescription.ForeColor = SystemColors.ControlDarkDark;
            HttpProxyDescription.Location = new Point(15, 35);
            HttpProxyDescription.Name = "HttpProxyDescription";
            HttpProxyDescription.Size = new Size(223, 20);
            HttpProxyDescription.TabIndex = 4;
            HttpProxyDescription.Text = "The proxy used for web requests";
            // 
            // HttpProxyTitle
            // 
            HttpProxyTitle.AutoSize = true;
            HttpProxyTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            HttpProxyTitle.Location = new Point(14, 12);
            HttpProxyTitle.Name = "HttpProxyTitle";
            HttpProxyTitle.Size = new Size(95, 25);
            HttpProxyTitle.TabIndex = 3;
            HttpProxyTitle.Text = "HttpProxy";
            // 
            // HttpProxyContent
            // 
            HttpProxyContent.Location = new Point(15, 60);
            HttpProxyContent.Name = "HttpProxyContent";
            HttpProxyContent.Size = new Size(420, 23);
            HttpProxyContent.TabIndex = 6;
            // 
            // TitlePanel
            // 
            TitlePanel.BackColor = SystemColors.ControlLight;
            TitlePanel.Controls.Add(TitleDescription);
            TitlePanel.Controls.Add(TitleTitle);
            TitlePanel.Controls.Add(TitleContent);
            TitlePanel.Location = new Point(12, 445);
            TitlePanel.Name = "TitlePanel";
            TitlePanel.Size = new Size(467, 118);
            TitlePanel.TabIndex = 9;
            // 
            // TitleDescription
            // 
            TitleDescription.AutoSize = true;
            TitleDescription.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            TitleDescription.ForeColor = SystemColors.ControlDarkDark;
            TitleDescription.Location = new Point(15, 35);
            TitleDescription.Name = "TitleDescription";
            TitleDescription.Size = new Size(430, 40);
            TitleDescription.TabIndex = 4;
            TitleDescription.Text = "The title of the provider flow window. (Use {provider} to use the\r\nprovider name)";
            // 
            // TitleTitle
            // 
            TitleTitle.AutoSize = true;
            TitleTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            TitleTitle.Location = new Point(14, 12);
            TitleTitle.Name = "TitleTitle";
            TitleTitle.Size = new Size(48, 25);
            TitleTitle.TabIndex = 3;
            TitleTitle.Text = "Title";
            // 
            // TitleContent
            // 
            TitleContent.Location = new Point(15, 80);
            TitleContent.Name = "TitleContent";
            TitleContent.Size = new Size(420, 23);
            TitleContent.TabIndex = 6;
            // 
            // IconPanel
            // 
            IconPanel.BackColor = SystemColors.ControlLight;
            IconPanel.Controls.Add(IconDescription);
            IconPanel.Controls.Add(IconTitle);
            IconPanel.Controls.Add(IconContent);
            IconPanel.Location = new Point(12, 574);
            IconPanel.Name = "IconPanel";
            IconPanel.Size = new Size(467, 97);
            IconPanel.TabIndex = 9;
            // 
            // IconDescription
            // 
            IconDescription.AutoSize = true;
            IconDescription.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            IconDescription.ForeColor = SystemColors.ControlDarkDark;
            IconDescription.Location = new Point(15, 35);
            IconDescription.Name = "IconDescription";
            IconDescription.Size = new Size(447, 20);
            IconDescription.TabIndex = 4;
            IconDescription.Text = "The icon of the provider flow window (empty for provider default)";
            // 
            // IconTitle
            // 
            IconTitle.AutoSize = true;
            IconTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            IconTitle.Location = new Point(14, 12);
            IconTitle.Name = "IconTitle";
            IconTitle.Size = new Size(48, 25);
            IconTitle.TabIndex = 3;
            IconTitle.Text = "Icon";
            // 
            // IconContent
            // 
            IconContent.Location = new Point(15, 60);
            IconContent.Name = "IconContent";
            IconContent.Size = new Size(420, 23);
            IconContent.TabIndex = 6;
            // 
            // StartupLocationPanel
            // 
            StartupLocationPanel.BackColor = SystemColors.ControlLight;
            StartupLocationPanel.Controls.Add(StartPositionContent);
            StartupLocationPanel.Controls.Add(StartupLocationDescription);
            StartupLocationPanel.Controls.Add(StartupLocationTitle);
            StartupLocationPanel.Location = new Point(12, 682);
            StartupLocationPanel.Name = "StartupLocationPanel";
            StartupLocationPanel.Size = new Size(467, 97);
            StartupLocationPanel.TabIndex = 10;
            // 
            // StartPositionContent
            // 
            StartPositionContent.FormattingEnabled = true;
            StartPositionContent.Location = new Point(17, 60);
            StartPositionContent.Name = "StartPositionContent";
            StartPositionContent.Size = new Size(420, 23);
            StartPositionContent.TabIndex = 8;
            // 
            // StartupLocationDescription
            // 
            StartupLocationDescription.AutoSize = true;
            StartupLocationDescription.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            StartupLocationDescription.ForeColor = SystemColors.ControlDarkDark;
            StartupLocationDescription.Location = new Point(15, 35);
            StartupLocationDescription.Name = "StartupLocationDescription";
            StartupLocationDescription.Size = new Size(333, 20);
            StartupLocationDescription.TabIndex = 4;
            StartupLocationDescription.Text = "The startup location of the provider flow window";
            // 
            // StartupLocationTitle
            // 
            StartupLocationTitle.AutoSize = true;
            StartupLocationTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            StartupLocationTitle.Location = new Point(14, 12);
            StartupLocationTitle.Name = "StartupLocationTitle";
            StartupLocationTitle.Size = new Size(144, 25);
            StartupLocationTitle.TabIndex = 3;
            StartupLocationTitle.Text = "StartupLocation";
            // 
            // LeftPanel
            // 
            LeftPanel.BackColor = SystemColors.ControlLight;
            LeftPanel.Controls.Add(LeftContent);
            LeftPanel.Controls.Add(LeftLable);
            LeftPanel.Controls.Add(LeftTitle);
            LeftPanel.Location = new Point(11, 790);
            LeftPanel.Name = "LeftPanel";
            LeftPanel.Size = new Size(467, 97);
            LeftPanel.TabIndex = 10;
            // 
            // LeftContent
            // 
            LeftContent.Location = new Point(17, 58);
            LeftContent.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            LeftContent.Name = "LeftContent";
            LeftContent.Size = new Size(420, 23);
            LeftContent.TabIndex = 7;
            // 
            // LeftLable
            // 
            LeftLable.AutoSize = true;
            LeftLable.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            LeftLable.ForeColor = SystemColors.ControlDarkDark;
            LeftLable.Location = new Point(15, 35);
            LeftLable.Name = "LeftLable";
            LeftLable.Size = new Size(309, 20);
            LeftLable.TabIndex = 4;
            LeftLable.Text = "The left position of the provider flow window";
            // 
            // LeftTitle
            // 
            LeftTitle.AutoSize = true;
            LeftTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            LeftTitle.Location = new Point(14, 12);
            LeftTitle.Name = "LeftTitle";
            LeftTitle.Size = new Size(43, 25);
            LeftTitle.TabIndex = 3;
            LeftTitle.Text = "Left";
            // 
            // TopPanel
            // 
            TopPanel.BackColor = SystemColors.ControlLight;
            TopPanel.Controls.Add(TopContent);
            TopPanel.Controls.Add(TopDescription);
            TopPanel.Controls.Add(TopLabel);
            TopPanel.Location = new Point(11, 898);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(467, 97);
            TopPanel.TabIndex = 11;
            // 
            // TopContent
            // 
            TopContent.Location = new Point(17, 58);
            TopContent.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            TopContent.Name = "TopContent";
            TopContent.Size = new Size(420, 23);
            TopContent.TabIndex = 7;
            // 
            // TopDescription
            // 
            TopDescription.AutoSize = true;
            TopDescription.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            TopDescription.ForeColor = SystemColors.ControlDarkDark;
            TopDescription.Location = new Point(15, 35);
            TopDescription.Name = "TopDescription";
            TopDescription.Size = new Size(310, 20);
            TopDescription.TabIndex = 4;
            TopDescription.Text = "The top position of the provider flow window";
            // 
            // TopLabel
            // 
            TopLabel.AutoSize = true;
            TopLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            TopLabel.Location = new Point(14, 12);
            TopLabel.Name = "TopLabel";
            TopLabel.Size = new Size(42, 25);
            TopLabel.TabIndex = 3;
            TopLabel.Text = "Top";
            // 
            // ShowAsDialogPanel
            // 
            ShowAsDialogPanel.BackColor = SystemColors.ControlLight;
            ShowAsDialogPanel.Controls.Add(ShowAsDialogContent);
            ShowAsDialogPanel.Controls.Add(ShowAsDialogDescription);
            ShowAsDialogPanel.Controls.Add(ShowAsDialogLabel);
            ShowAsDialogPanel.Location = new Point(11, 1006);
            ShowAsDialogPanel.Name = "ShowAsDialogPanel";
            ShowAsDialogPanel.Size = new Size(467, 97);
            ShowAsDialogPanel.TabIndex = 12;
            // 
            // ShowAsDialogContent
            // 
            ShowAsDialogContent.AutoSize = true;
            ShowAsDialogContent.Location = new Point(19, 60);
            ShowAsDialogContent.Name = "ShowAsDialogContent";
            ShowAsDialogContent.Size = new Size(15, 14);
            ShowAsDialogContent.TabIndex = 8;
            ShowAsDialogContent.UseVisualStyleBackColor = true;
            // 
            // ShowAsDialogDescription
            // 
            ShowAsDialogDescription.AutoSize = true;
            ShowAsDialogDescription.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ShowAsDialogDescription.ForeColor = SystemColors.ControlDarkDark;
            ShowAsDialogDescription.Location = new Point(15, 35);
            ShowAsDialogDescription.Name = "ShowAsDialogDescription";
            ShowAsDialogDescription.Size = new Size(310, 20);
            ShowAsDialogDescription.TabIndex = 4;
            ShowAsDialogDescription.Text = "The top position of the provider flow window";
            // 
            // ShowAsDialogLabel
            // 
            ShowAsDialogLabel.AutoSize = true;
            ShowAsDialogLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ShowAsDialogLabel.Location = new Point(14, 12);
            ShowAsDialogLabel.Name = "ShowAsDialogLabel";
            ShowAsDialogLabel.Size = new Size(133, 25);
            ShowAsDialogLabel.TabIndex = 3;
            ShowAsDialogLabel.Text = "ShowAsDialog";
            // 
            // FlowRedirectToPanel
            // 
            FlowRedirectToPanel.BackColor = SystemColors.ControlLight;
            FlowRedirectToPanel.Controls.Add(FlowRedirectToDescription);
            FlowRedirectToPanel.Controls.Add(FlowRedirectToLabel);
            FlowRedirectToPanel.Controls.Add(FlowRedirectToContent);
            FlowRedirectToPanel.Location = new Point(11, 1114);
            FlowRedirectToPanel.Name = "FlowRedirectToPanel";
            FlowRedirectToPanel.Size = new Size(467, 114);
            FlowRedirectToPanel.TabIndex = 10;
            // 
            // FlowRedirectToDescription
            // 
            FlowRedirectToDescription.AutoSize = true;
            FlowRedirectToDescription.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            FlowRedirectToDescription.ForeColor = SystemColors.ControlDarkDark;
            FlowRedirectToDescription.Location = new Point(15, 35);
            FlowRedirectToDescription.Name = "FlowRedirectToDescription";
            FlowRedirectToDescription.Size = new Size(433, 40);
            FlowRedirectToDescription.TabIndex = 4;
            FlowRedirectToDescription.Text = "he url to which the provider will redirect the user back to (empty\r\nfor provider default)";
            // 
            // FlowRedirectToLabel
            // 
            FlowRedirectToLabel.AutoSize = true;
            FlowRedirectToLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            FlowRedirectToLabel.Location = new Point(14, 12);
            FlowRedirectToLabel.Name = "FlowRedirectToLabel";
            FlowRedirectToLabel.Size = new Size(138, 25);
            FlowRedirectToLabel.TabIndex = 3;
            FlowRedirectToLabel.Text = "FlowRedirectTo";
            // 
            // FlowRedirectToContent
            // 
            FlowRedirectToContent.Location = new Point(15, 78);
            FlowRedirectToContent.Name = "FlowRedirectToContent";
            FlowRedirectToContent.Size = new Size(420, 23);
            FlowRedirectToContent.TabIndex = 6;
            // 
            // TimeoutPanel
            // 
            TimeoutPanel.BackColor = SystemColors.ControlLight;
            TimeoutPanel.Controls.Add(TimeoutContent);
            TimeoutPanel.Controls.Add(TimeoutDescription);
            TimeoutPanel.Controls.Add(TimeoutLabel);
            TimeoutPanel.Location = new Point(11, 1239);
            TimeoutPanel.Name = "TimeoutPanel";
            TimeoutPanel.Size = new Size(467, 97);
            TimeoutPanel.TabIndex = 8;
            // 
            // TimeoutContent
            // 
            TimeoutContent.Location = new Point(17, 60);
            TimeoutContent.Mask = "00:00:00";
            TimeoutContent.Name = "TimeoutContent";
            TimeoutContent.Size = new Size(420, 23);
            TimeoutContent.TabIndex = 7;
            TimeoutContent.ValidatingType = typeof(DateTime);
            // 
            // TimeoutDescription
            // 
            TimeoutDescription.AutoSize = true;
            TimeoutDescription.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            TimeoutDescription.ForeColor = SystemColors.ControlDarkDark;
            TimeoutDescription.Location = new Point(15, 35);
            TimeoutDescription.Name = "TimeoutDescription";
            TimeoutDescription.Size = new Size(322, 20);
            TimeoutDescription.TabIndex = 4;
            TimeoutDescription.Text = "The time span in which a user request times out";
            // 
            // TimeoutLabel
            // 
            TimeoutLabel.AutoSize = true;
            TimeoutLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            TimeoutLabel.Location = new Point(14, 12);
            TimeoutLabel.Name = "TimeoutLabel";
            TimeoutLabel.Size = new Size(81, 25);
            TimeoutLabel.TabIndex = 3;
            TimeoutLabel.Text = "Timeout";
            // 
            // ReCaptchaSiteKeyPanel
            // 
            ReCaptchaSiteKeyPanel.BackColor = SystemColors.ControlLight;
            ReCaptchaSiteKeyPanel.Controls.Add(ReCaptchaSiteKeyDescription);
            ReCaptchaSiteKeyPanel.Controls.Add(ReCaptchaSiteKeyLabel);
            ReCaptchaSiteKeyPanel.Controls.Add(ReCaptchaSiteKeyContent);
            ReCaptchaSiteKeyPanel.Location = new Point(11, 1346);
            ReCaptchaSiteKeyPanel.Name = "ReCaptchaSiteKeyPanel";
            ReCaptchaSiteKeyPanel.Size = new Size(467, 132);
            ReCaptchaSiteKeyPanel.TabIndex = 10;
            // 
            // ReCaptchaSiteKeyDescription
            // 
            ReCaptchaSiteKeyDescription.AutoSize = true;
            ReCaptchaSiteKeyDescription.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ReCaptchaSiteKeyDescription.ForeColor = SystemColors.ControlDarkDark;
            ReCaptchaSiteKeyDescription.Location = new Point(15, 35);
            ReCaptchaSiteKeyDescription.Name = "ReCaptchaSiteKeyDescription";
            ReCaptchaSiteKeyDescription.Size = new Size(346, 60);
            ReCaptchaSiteKeyDescription.TabIndex = 4;
            ReCaptchaSiteKeyDescription.Text = "The reCAPTCHA site key. (You can get your projects\r\nreCAPTCHA site key by using\r\n'IAuthenticationClient.GetReCaptchaSiteKeyAsync')";
            // 
            // ReCaptchaSiteKeyLabel
            // 
            ReCaptchaSiteKeyLabel.AutoSize = true;
            ReCaptchaSiteKeyLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ReCaptchaSiteKeyLabel.Location = new Point(14, 12);
            ReCaptchaSiteKeyLabel.Name = "ReCaptchaSiteKeyLabel";
            ReCaptchaSiteKeyLabel.Size = new Size(162, 25);
            ReCaptchaSiteKeyLabel.TabIndex = 3;
            ReCaptchaSiteKeyLabel.Text = "ReCaptchaSiteKey";
            // 
            // ReCaptchaSiteKeyContent
            // 
            ReCaptchaSiteKeyContent.Location = new Point(15, 97);
            ReCaptchaSiteKeyContent.Name = "ReCaptchaSiteKeyContent";
            ReCaptchaSiteKeyContent.Size = new Size(420, 23);
            ReCaptchaSiteKeyContent.TabIndex = 6;
            // 
            // ReCaptchaHostNamePanel
            // 
            ReCaptchaHostNamePanel.BackColor = SystemColors.ControlLight;
            ReCaptchaHostNamePanel.Controls.Add(ReCaptchaHostNameDescription);
            ReCaptchaHostNamePanel.Controls.Add(ReCaptchaHostNameLabel);
            ReCaptchaHostNamePanel.Controls.Add(ReCaptchaHostNameContent);
            ReCaptchaHostNamePanel.Location = new Point(11, 1488);
            ReCaptchaHostNamePanel.Name = "ReCaptchaHostNamePanel";
            ReCaptchaHostNamePanel.Size = new Size(467, 114);
            ReCaptchaHostNamePanel.TabIndex = 11;
            // 
            // ReCaptchaHostNameDescription
            // 
            ReCaptchaHostNameDescription.AutoSize = true;
            ReCaptchaHostNameDescription.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ReCaptchaHostNameDescription.ForeColor = SystemColors.ControlDarkDark;
            ReCaptchaHostNameDescription.Location = new Point(15, 35);
            ReCaptchaHostNameDescription.Name = "ReCaptchaHostNameDescription";
            ReCaptchaHostNameDescription.Size = new Size(380, 40);
            ReCaptchaHostNameDescription.TabIndex = 4;
            ReCaptchaHostNameDescription.Text = "The reCAPTCHA host name. (This has to be added to the\r\nauthorized domains to work with ReCaptcha.Desktop)";
            // 
            // ReCaptchaHostNameLabel
            // 
            ReCaptchaHostNameLabel.AutoSize = true;
            ReCaptchaHostNameLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ReCaptchaHostNameLabel.Location = new Point(14, 12);
            ReCaptchaHostNameLabel.Name = "ReCaptchaHostNameLabel";
            ReCaptchaHostNameLabel.Size = new Size(189, 25);
            ReCaptchaHostNameLabel.TabIndex = 3;
            ReCaptchaHostNameLabel.Text = "ReCaptchaHostName";
            // 
            // ReCaptchaHostNameContent
            // 
            ReCaptchaHostNameContent.Location = new Point(15, 78);
            ReCaptchaHostNameContent.Name = "ReCaptchaHostNameContent";
            ReCaptchaHostNameContent.Size = new Size(420, 23);
            ReCaptchaHostNameContent.TabIndex = 6;
            // 
            // ImgurClientIdPanel
            // 
            ImgurClientIdPanel.BackColor = SystemColors.ControlLight;
            ImgurClientIdPanel.Controls.Add(ImgurClientIdDescription);
            ImgurClientIdPanel.Controls.Add(ImgurClientIdTitel);
            ImgurClientIdPanel.Controls.Add(ImgurClientIdContent);
            ImgurClientIdPanel.Location = new Point(11, 1612);
            ImgurClientIdPanel.Name = "ImgurClientIdPanel";
            ImgurClientIdPanel.Size = new Size(467, 114);
            ImgurClientIdPanel.TabIndex = 12;
            // 
            // ImgurClientIdDescription
            // 
            ImgurClientIdDescription.AutoSize = true;
            ImgurClientIdDescription.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ImgurClientIdDescription.ForeColor = SystemColors.ControlDarkDark;
            ImgurClientIdDescription.Location = new Point(15, 35);
            ImgurClientIdDescription.Name = "ImgurClientIdDescription";
            ImgurClientIdDescription.Size = new Size(380, 40);
            ImgurClientIdDescription.TabIndex = 4;
            ImgurClientIdDescription.Text = "The reCAPTCHA host name. (This has to be added to the\r\nauthorized domains to work with ReCaptcha.Desktop)";
            // 
            // ImgurClientIdTitel
            // 
            ImgurClientIdTitel.AutoSize = true;
            ImgurClientIdTitel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ImgurClientIdTitel.Location = new Point(14, 12);
            ImgurClientIdTitel.Name = "ImgurClientIdTitel";
            ImgurClientIdTitel.Size = new Size(127, 25);
            ImgurClientIdTitel.TabIndex = 3;
            ImgurClientIdTitel.Text = "ImgurClientId";
            // 
            // ImgurClientIdContent
            // 
            ImgurClientIdContent.Location = new Point(15, 78);
            ImgurClientIdContent.Name = "ImgurClientIdContent";
            ImgurClientIdContent.Size = new Size(420, 23);
            ImgurClientIdContent.TabIndex = 6;
            // 
            // SettingsControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            Controls.Add(ImgurClientIdPanel);
            Controls.Add(ReCaptchaHostNamePanel);
            Controls.Add(ReCaptchaSiteKeyPanel);
            Controls.Add(TimeoutPanel);
            Controls.Add(FlowRedirectToPanel);
            Controls.Add(ShowAsDialogPanel);
            Controls.Add(TopPanel);
            Controls.Add(LeftPanel);
            Controls.Add(StartupLocationPanel);
            Controls.Add(IconPanel);
            Controls.Add(TitlePanel);
            Controls.Add(HttpProxyPanel);
            Controls.Add(HttpTimeoutPanel);
            Controls.Add(DividerPanel);
            Controls.Add(ApiKeyPanel);
            Controls.Add(RestartButton);
            Controls.Add(SettingsLabel);
            Name = "SettingsControl";
            Size = new Size(504, 809);
            ApiKeyPanel.ResumeLayout(false);
            ApiKeyPanel.PerformLayout();
            HttpTimeoutPanel.ResumeLayout(false);
            HttpTimeoutPanel.PerformLayout();
            HttpProxyPanel.ResumeLayout(false);
            HttpProxyPanel.PerformLayout();
            TitlePanel.ResumeLayout(false);
            TitlePanel.PerformLayout();
            IconPanel.ResumeLayout(false);
            IconPanel.PerformLayout();
            StartupLocationPanel.ResumeLayout(false);
            StartupLocationPanel.PerformLayout();
            LeftPanel.ResumeLayout(false);
            LeftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LeftContent).EndInit();
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TopContent).EndInit();
            ShowAsDialogPanel.ResumeLayout(false);
            ShowAsDialogPanel.PerformLayout();
            FlowRedirectToPanel.ResumeLayout(false);
            FlowRedirectToPanel.PerformLayout();
            TimeoutPanel.ResumeLayout(false);
            TimeoutPanel.PerformLayout();
            ReCaptchaSiteKeyPanel.ResumeLayout(false);
            ReCaptchaSiteKeyPanel.PerformLayout();
            ReCaptchaHostNamePanel.ResumeLayout(false);
            ReCaptchaHostNamePanel.PerformLayout();
            ImgurClientIdPanel.ResumeLayout(false);
            ImgurClientIdPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label SettingsLabel;
        private Button RestartButton;
        private Panel ApiKeyPanel;
        private Label ApiKeyDescription;
        private Label ApiKeyTitle;
        private TextBox ApiKeyContent;
        private Panel DividerPanel;
        private Panel HttpTimeoutPanel;
        private Label HttpTimeoutDescription;
        private Label HttpTimeoutTitle;
        private Panel HttpProxyPanel;
        private Label HttpProxyDescription;
        private Label HttpProxyTitle;
        private Panel TitlePanel;
        private Label TitleDescription;
        private Label TitleTitle;
        private TextBox TitleContent;
        private Panel IconPanel;
        private Label IconDescription;
        private Label IconTitle;
        private TextBox IconContent;
        private Panel StartupLocationPanel;
        private Label StartupLocationDescription;
        private Label StartupLocationTitle;
        private ComboBox StartPositionContent;
        private Panel LeftPanel;
        private Label LeftLable;
        private Label LeftTitle;
        private NumericUpDown LeftContent;
        private Panel TopPanel;
        private NumericUpDown TopContent;
        private Label TopDescription;
        private Label TopLabel;
        private MaskedTextBox HttpTimeoutContent;
        private TextBox HttpProxyContent;
        private Panel ShowAsDialogPanel;
        private Label ShowAsDialogDescription;
        private Label ShowAsDialogLabel;
        private CheckBox ShowAsDialogContent;
        private Panel FlowRedirectToPanel;
        private Label FlowRedirectToDescription;
        private Label FlowRedirectToLabel;
        private TextBox FlowRedirectToContent;
        private Panel TimeoutPanel;
        private MaskedTextBox TimeoutContent;
        private Label TimeoutDescription;
        private Label TimeoutLabel;
        private Panel ReCaptchaSiteKeyPanel;
        private Label ReCaptchaHostNameDescription;
        private Label ReCaptchaSiteKeyLabel;
        private TextBox ReCaptchaSiteKeyContent;
        private Label ReCaptchaSiteKeyDescription;
        private Panel ReCaptchaHostNamePanel;
        private Label ReCaptchaHostNameLabel;
        private TextBox ReCaptchaHostNameContent;
        private Panel ImgurClientIdPanel;
        private Label ImgurClientIdDescription;
        private Label ImgurClientIdTitel;
        private TextBox ImgurClientIdContent;
    }
}
