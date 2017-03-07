namespace AtlanticaRunRus
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LangLbl = new System.Windows.Forms.Label();
            this.LangCB = new System.Windows.Forms.ComboBox();
            this.PatchStatusLbl = new System.Windows.Forms.Label();
            this.cliVerLbl = new System.Windows.Forms.Label();
            this.rusVerLbl = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.PictureBox();
            this.CloseBtn = new System.Windows.Forms.PictureBox();
            this.SettingsBtn = new System.Windows.Forms.PictureBox();
            this.isForced = new System.Windows.Forms.CheckBox();
            this.DownloadBar = new System.Windows.Forms.ProgressBar();
            this.InstallBar = new System.Windows.Forms.ProgressBar();
            this.rightBrowser = new System.Windows.Forms.WebBrowser();
            this.centerBrowser = new System.Windows.Forms.WebBrowser();
            this.launcherVerLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StartBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // LangLbl
            // 
            this.LangLbl.AutoSize = true;
            this.LangLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LangLbl.Location = new System.Drawing.Point(397, 426);
            this.LangLbl.Name = "LangLbl";
            this.LangLbl.Size = new System.Drawing.Size(38, 13);
            this.LangLbl.TabIndex = 3;
            this.LangLbl.Text = "Язык:";
            // 
            // LangCB
            // 
            this.LangCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LangCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LangCB.Items.AddRange(new object[] {
            "ENGLISH",
            "РУССКИЙ"});
            this.LangCB.Location = new System.Drawing.Point(440, 422);
            this.LangCB.Name = "LangCB";
            this.LangCB.Size = new System.Drawing.Size(121, 21);
            this.LangCB.TabIndex = 4;
            this.LangCB.TabStop = false;
            // 
            // PatchStatusLbl
            // 
            this.PatchStatusLbl.AutoSize = true;
            this.PatchStatusLbl.ForeColor = System.Drawing.Color.Gold;
            this.PatchStatusLbl.Location = new System.Drawing.Point(18, 498);
            this.PatchStatusLbl.Name = "PatchStatusLbl";
            this.PatchStatusLbl.Size = new System.Drawing.Size(79, 13);
            this.PatchStatusLbl.TabIndex = 5;
            this.PatchStatusLbl.Text = "PatchStatusLbl";
            // 
            // cliVerLbl
            // 
            this.cliVerLbl.AutoSize = true;
            this.cliVerLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cliVerLbl.Location = new System.Drawing.Point(477, 361);
            this.cliVerLbl.Name = "cliVerLbl";
            this.cliVerLbl.Size = new System.Drawing.Size(43, 13);
            this.cliVerLbl.TabIndex = 6;
            this.cliVerLbl.Text = "VerLabl";
            // 
            // rusVerLbl
            // 
            this.rusVerLbl.AutoSize = true;
            this.rusVerLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rusVerLbl.Location = new System.Drawing.Point(477, 377);
            this.rusVerLbl.Name = "rusVerLbl";
            this.rusVerLbl.Size = new System.Drawing.Size(42, 13);
            this.rusVerLbl.TabIndex = 7;
            this.rusVerLbl.Text = "RusVer";
            // 
            // StartBtn
            // 
            this.StartBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartBtn.Image = global::AtlanticaRunRus.Properties.Resources.BTN_START_NORMAL;
            this.StartBtn.Location = new System.Drawing.Point(569, 449);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(190, 59);
            this.StartBtn.TabIndex = 2;
            this.StartBtn.TabStop = false;
            this.StartBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartBtn_MouseDown);
            this.StartBtn.MouseEnter += new System.EventHandler(this.StartBtn_MouseEnter);
            this.StartBtn.MouseLeave += new System.EventHandler(this.StartBtn_MouseLeave);
            this.StartBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StartBtn_MouseUp);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Image = global::AtlanticaRunRus.Properties.Resources.BTN_CLOSE_NORMAL;
            this.CloseBtn.Location = new System.Drawing.Point(741, 9);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(20, 20);
            this.CloseBtn.TabIndex = 1;
            this.CloseBtn.TabStop = false;
            this.CloseBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseBtn_MouseDown);
            this.CloseBtn.MouseEnter += new System.EventHandler(this.CloseBtn_MouseEnter);
            this.CloseBtn.MouseLeave += new System.EventHandler(this.CloseBtn_MouseLeave);
            this.CloseBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CloseBtn_MouseUp);
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.Image = global::AtlanticaRunRus.Properties.Resources.BTN_CONFIG_NORMAL;
            this.SettingsBtn.Location = new System.Drawing.Point(570, 420);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(188, 24);
            this.SettingsBtn.TabIndex = 8;
            this.SettingsBtn.TabStop = false;
            this.SettingsBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SettingsBtn_MouseDown);
            this.SettingsBtn.MouseEnter += new System.EventHandler(this.SettingsBtn_MouseEnter);
            this.SettingsBtn.MouseLeave += new System.EventHandler(this.SettingsBtn_MouseLeave);
            this.SettingsBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SettingsBtn_MouseUp);
            // 
            // isForced
            // 
            this.isForced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.isForced.AutoSize = true;
            this.isForced.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isForced.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.isForced.Location = new System.Drawing.Point(599, 556);
            this.isForced.Name = "isForced";
            this.isForced.Size = new System.Drawing.Size(167, 17);
            this.isForced.TabIndex = 9;
            this.isForced.Text = "Починить при запуске игры";
            this.isForced.UseVisualStyleBackColor = true;
            this.isForced.CheckedChanged += new System.EventHandler(this.isForced_CheckedChanged);
            // 
            // DownloadBar
            // 
            this.DownloadBar.BackColor = System.Drawing.Color.Black;
            this.DownloadBar.ForeColor = System.Drawing.Color.Gold;
            this.DownloadBar.Location = new System.Drawing.Point(21, 449);
            this.DownloadBar.Name = "DownloadBar";
            this.DownloadBar.Size = new System.Drawing.Size(538, 10);
            this.DownloadBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.DownloadBar.TabIndex = 10;
            // 
            // InstallBar
            // 
            this.InstallBar.BackColor = System.Drawing.Color.Black;
            this.InstallBar.ForeColor = System.Drawing.Color.Green;
            this.InstallBar.Location = new System.Drawing.Point(21, 485);
            this.InstallBar.Name = "InstallBar";
            this.InstallBar.Size = new System.Drawing.Size(538, 10);
            this.InstallBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.InstallBar.TabIndex = 11;
            // 
            // rightBrowser
            // 
            this.rightBrowser.AllowWebBrowserDrop = false;
            this.rightBrowser.IsWebBrowserContextMenuEnabled = false;
            this.rightBrowser.Location = new System.Drawing.Point(473, 122);
            this.rightBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.rightBrowser.Name = "rightBrowser";
            this.rightBrowser.ScriptErrorsSuppressed = true;
            this.rightBrowser.ScrollBarsEnabled = false;
            this.rightBrowser.Size = new System.Drawing.Size(289, 219);
            this.rightBrowser.TabIndex = 12;
            this.rightBrowser.TabStop = false;
            this.rightBrowser.Url = new System.Uri("http://aousrus.stdark.pw/launcher/rightwindow", System.UriKind.Absolute);
            this.rightBrowser.Visible = false;
            this.rightBrowser.WebBrowserShortcutsEnabled = false;
            this.rightBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.rightBrowser_DocumentCompleted);
            this.rightBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.rightBrowser_Navigating);
            // 
            // centerBrowser
            // 
            this.centerBrowser.AllowWebBrowserDrop = false;
            this.centerBrowser.IsWebBrowserContextMenuEnabled = false;
            this.centerBrowser.Location = new System.Drawing.Point(14, 122);
            this.centerBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.centerBrowser.Name = "centerBrowser";
            this.centerBrowser.ScriptErrorsSuppressed = true;
            this.centerBrowser.ScrollBarsEnabled = false;
            this.centerBrowser.Size = new System.Drawing.Size(441, 272);
            this.centerBrowser.TabIndex = 13;
            this.centerBrowser.TabStop = false;
            this.centerBrowser.Url = new System.Uri("http://aousrus.stdark.pw/launcher/centerwindow", System.UriKind.Absolute);
            this.centerBrowser.Visible = false;
            this.centerBrowser.WebBrowserShortcutsEnabled = false;
            this.centerBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.centerBrowser_DocumentCompleted);
            this.centerBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.rightBrowser_Navigating);
            // 
            // launcherVerLbl
            // 
            this.launcherVerLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.launcherVerLbl.BackColor = System.Drawing.Color.Transparent;
            this.launcherVerLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.launcherVerLbl.Location = new System.Drawing.Point(602, 576);
            this.launcherVerLbl.Name = "launcherVerLbl";
            this.launcherVerLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.launcherVerLbl.Size = new System.Drawing.Size(167, 19);
            this.launcherVerLbl.TabIndex = 14;
            this.launcherVerLbl.Text = "1.1.1.4";
            this.launcherVerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::AtlanticaRunRus.Properties.Resources.PATCH_BACKGR;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(778, 594);
            this.Controls.Add(this.launcherVerLbl);
            this.Controls.Add(this.centerBrowser);
            this.Controls.Add(this.rightBrowser);
            this.Controls.Add(this.InstallBar);
            this.Controls.Add(this.DownloadBar);
            this.Controls.Add(this.isForced);
            this.Controls.Add(this.SettingsBtn);
            this.Controls.Add(this.rusVerLbl);
            this.Controls.Add(this.cliVerLbl);
            this.Controls.Add(this.PatchStatusLbl);
            this.Controls.Add(this.LangCB);
            this.Controls.Add(this.LangLbl);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.CloseBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.StartBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox CloseBtn;
        private System.Windows.Forms.PictureBox StartBtn;
        private System.Windows.Forms.Label LangLbl;
        private System.Windows.Forms.ComboBox LangCB;
        private System.Windows.Forms.Label PatchStatusLbl;
        private System.Windows.Forms.Label cliVerLbl;
        private System.Windows.Forms.Label rusVerLbl;
        private System.Windows.Forms.PictureBox SettingsBtn;
        private System.Windows.Forms.CheckBox isForced;
        private System.Windows.Forms.ProgressBar DownloadBar;
        private System.Windows.Forms.ProgressBar InstallBar;
        private System.Windows.Forms.WebBrowser rightBrowser;
        private System.Windows.Forms.WebBrowser centerBrowser;
        private System.Windows.Forms.Label launcherVerLbl;
    }
}

