using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Newtonsoft.Json;
using SevenZip;

using AtlanticaRunRus.Properties;


namespace AtlanticaRunRus
{




    public partial class MainForm : Form
    {
        bool isCloseButtonHover = false;
        bool isStartButtonHover = false;
        bool isSettingsButtonHover = false;
        bool isCloseButtonDisabled = false;
        bool isStartButtonDisabled = false;
        bool isSettingsButtonDisabled = false;
        bool isForcedUpdate = false;
        
        

        const string patchDatPath = "PatchInfo/Patch.dat";
        const string atlanticaRunPath = "AtlanticaRun.exe";
        const string engVersionInfo = "LANG/ENG/VersionInfo.ndt";
        const string rusVersionInfo = "LANG/RUS/VersionInfo.ndt";
        const string atlanticaPath = "Atlantica.exe";
        const string atlanticaRusPath = "AtlanticaRus.exe";
        const string atlanticaConfigPath = "AtlanticaConfig.exe";
        const string rusWebsiteUrl = "http://aousrus.stdark.pw";
        const string getVersionUrl = rusWebsiteUrl + "/api/getversion";
        const string getFileListUrl = rusWebsiteUrl + "/api/getfilelist";
        const string getFileListFullUrl = rusWebsiteUrl + "/api/getfilelistfull";
        const string getFileUrl = rusWebsiteUrl + "/api/getfile/";
        const string getFileFullUrl = rusWebsiteUrl + "/api/getfilefull/";

        int enVer = 0;
        int ruVer = 0;
        int locVer = 0;
        int tempLocVersion = 0;

        NDTDecrypt mNdtDecrypt = new NDTDecrypt();
        Encoding mEncoding = Encoding.Default;
        WebClient mWebClient;
        




        public MainForm()
        {
            
            InitializeComponent();
        }


        //Форма

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            TopMost = true;
            
            PatchStatusLbl.Text = "Проверяем обновления оригинальных файлов клиента...";
            if (isUpdateAvailable())
            {

                CheckUpdate();

            }
            else
            {
                LangCB.SelectedIndex = 1;
                PatchStatusLbl.Text = "Версия русификатора соответствует версии клиента. Приятной игры!";
                PatchStatusLbl.ForeColor = Color.Green;
            }
            StartBtn.Enabled = true;
            SettingsBtn.Enabled = true;
            CloseBtn.Enabled = true;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists("Newtonsoft.Json.dll"))
            {
                File.WriteAllBytes("Newtonsoft.Json.dll", Resources.Newtonsoft_Json);
            }
            if (!File.Exists("SevenZipSharp.dll"))
            {
                File.WriteAllBytes("SevenZipSharp.dll", Resources.SevenZipSharp);
            }
            if (Environment.Is64BitOperatingSystem)
            {
                if (!File.Exists("7z.dll") || File.ReadAllBytes("7z.dll") != Resources._7z64)
                {
                    File.WriteAllBytes("7z.dll", Resources._7z64);
                }
            }
            else
            {
                if (!File.Exists("7z.dll") || File.ReadAllBytes("7z.dll") != Resources._7z32)
                {
                    File.WriteAllBytes("7z.dll", Resources._7z32);
                }
            }
            if (File.Exists("rlauncher_upd.exe"))
            {
                if (File.Exists("AtlanticaRunRus.old"))
                {
                    File.Delete("AtlanticaRunRus.old");
                    File.Delete("rlauncher_upd.exe");
                }   
                else if (File.Exists("AtlanticaRunRus_upd.exe"))
                {
                    Process.Start("rlauncher_upd.exe");
                    AppExit();
                }
            }
            
            launcherVerLbl.Text = Application.ProductVersion.ToString();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;
            StartBtn.Enabled = false;
            SettingsBtn.Enabled = false;
            CloseBtn.Enabled = false;
            RewritePatchDat();
            locVer = Settings.Default.LOC_VER;
            cliVerLbl.Text = "Версия клиента: ";
            rusVerLbl.Text = "Версия русификатора: ";
            
            


        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Directory.Exists("Temp"))
            {
                Directory.Delete("Temp", true);
            }

        }


        //Браузеры
        private void centerBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            centerBrowser.Visible = true;

        }

        private void rightBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            rightBrowser.Visible = true;
        }

        private void rightBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            
            Process.Start(e.Url.ToString());
            e.Cancel = true;
           

        }


        //Кнопка закрыть

        private void CloseBtn_MouseEnter(object sender, EventArgs e)
        {
            if (!isCloseButtonDisabled)
            {
                this.CloseBtn.Image = Resources.BTN_CLOSE_HOVER;
                isCloseButtonHover = true;
            }
            
        }

        private void CloseBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isCloseButtonDisabled)
            {
                
                this.CloseBtn.Image = Resources.BTN_CLOSE_PUSH;
                
                AppExit();
            }
        }

        private void CloseBtn_MouseLeave(object sender, EventArgs e)
        {
            if (!isCloseButtonDisabled)
            {
                this.CloseBtn.Image = Resources.BTN_CLOSE_NORMAL;
                isCloseButtonHover = false;
            }
        }

        private void CloseBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isCloseButtonDisabled)
            {
                if (isCloseButtonHover)
                {
                    this.CloseBtn.Image = Resources.BTN_CLOSE_HOVER;
                }
                else
                {
                    this.CloseBtn.Image = Resources.BTN_CLOSE_NORMAL;
                }
            }
        }

        //Start Button

        private void StartBtn_MouseDown(object sender, EventArgs e)
        {
            if (!isStartButtonDisabled)
            {
                this.StartBtn.Image = Resources.BTN_START_PUSH;
                if (isForcedUpdate)
                {
                    CheckUpdate();
                }
                else
                {
                    
                    if (LangCB.SelectedIndex == 0)
                    {
                        Process.Start(atlanticaPath);
                        AppExit();
                    }
                    else if (LangCB.SelectedIndex == 1)
                    {
                        Process.Start(atlanticaRusPath);
                        AppExit();
                    }
                    else MessageBox.Show("Непредвиденная ошибка #1. Язык неопределен");
                }
            }

        }

        private void StartBtn_MouseEnter(object sender, EventArgs e)
        {
            if (!isStartButtonDisabled)
            {
                this.StartBtn.Image = Resources.BTN_START_HOVER;
                isStartButtonHover = true;
            }
        }

        private void StartBtn_MouseLeave(object sender, EventArgs e)
        {
            if (!isStartButtonDisabled)
            {
                this.StartBtn.Image = Resources.BTN_START_NORMAL;
                isStartButtonHover = false;
            }
        }

        private void StartBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isStartButtonDisabled)
            {
                if (isStartButtonHover)
                {
                    this.StartBtn.Image = Resources.BTN_START_HOVER;
                }
                else
                {
                    this.StartBtn.Image = Resources.BTN_START_NORMAL;
                }
            }
        }


        // Settings button
        private void SettingsBtn_MouseEnter(object sender, EventArgs e)
        {
            if (!isSettingsButtonDisabled)
            {
                this.SettingsBtn.Image = Resources.BTN_CONFIG_HOVER;
                isSettingsButtonHover = true;
            }
        }

        private void SettingsBtn_MouseLeave(object sender, EventArgs e)
        {
            if (!isSettingsButtonDisabled)
            {
                this.SettingsBtn.Image = Resources.BTN_CONFIG_NORMAL;
                isSettingsButtonHover = false;
            }
        }

        private void SettingsBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isSettingsButtonDisabled)
            {
                this.SettingsBtn.Image = Resources.BTN_CONFIG_PUSH;
                Process.Start(atlanticaConfigPath);
            }
        }

        private void SettingsBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isSettingsButtonDisabled)
            {
                if (isSettingsButtonHover)
                {
                    this.SettingsBtn.Image = Resources.BTN_CONFIG_HOVER;
                }
                else
                {
                    this.SettingsBtn.Image = Resources.BTN_CONFIG_NORMAL;
                }
            }
        }

        //Принудительное обновление

        private void isForced_CheckedChanged(object sender, EventArgs e)
        {
            isForcedUpdate = isForced.Checked;
        }




        //////////////////////////Вспомогательные методы

        void AppExit()
        {
            Application.Exit();


        }


        //Перезапись конфига оригинального лаунчера для автозапуска клиента
        void RewritePatchDat()
        {
            string patchDat = mEncoding.GetString(File.ReadAllBytes(patchDatPath));
            patchDat = patchDat.Replace("autostart=0", "autostart=1");
            File.WriteAllText(patchDatPath, patchDat);

        }

        void CheckUpdate()
        {

            if (isRusUpdateAvailable(ruVer, isForcedUpdate))
            {
                LangCB.SelectedIndex = 1;
                PatchStatusLbl.Text = "Доступно обновление русификатора. Перезапустите лаунчер, если хотите обновиться.";
                PatchStatusLbl.ForeColor = Color.Gold;
                if (MessageBox.Show("Доступно обновление русификатора. Загрузить обновления?", "Обновление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    downloadFiles();


                }
            }
            else
            {
                LangCB.SelectedIndex = 0;
                PatchStatusLbl.Text = "Обновление русификатора пока недоступно, сброс языка на Английский";
                PatchStatusLbl.ForeColor = Color.Red;
            }
        }

        // Проверка обновлений оригинального клиента
        bool isUpdateAvailable()
        {
            if (Process.GetProcessesByName("Atlantica").Length != 0 || Process.GetProcessesByName("AtlanticaRus").Length != 0) return false;
            Process atlanticaRunProc = new Process();
            atlanticaRunProc.StartInfo.FileName = atlanticaRunPath;
            //atlanticaRunProc.StartInfo.CreateNoWindow = true;

            atlanticaRunProc.Start();
            atlanticaRunProc.WaitForExit();
            TopMost = false;
            while (true)
            {
                if (Process.GetProcessesByName("Atlantica").Length != 0)
                {
                    Process.GetProcessesByName("Atlantica")[0].Kill();
                    break;
                }
            }
            string engVerFile = mEncoding.GetString(mNdtDecrypt.Start(engVersionInfo)).Replace("\0", "");
            int indStart = engVerFile.IndexOf("Version\t") + 8;
            int indEnd = engVerFile.IndexOf("\r\n<End");
            int engVer = int.Parse(engVerFile.Substring(indStart, indEnd - indStart));


            string rusVerFile = null;
            int rusVer = 0;

            if (File.Exists(rusVersionInfo))
            {
                rusVerFile = mEncoding.GetString(mNdtDecrypt.Start(rusVersionInfo)).Replace("\0", "");
                rusVer = int.Parse(rusVerFile.Substring(indStart, indEnd - indStart));
            }
            else
            {
                rusVer = 0;
                isForcedUpdate = true;
            }



            cliVerLbl.Text = "Версия клиента: " + engVer.ToString();
            rusVerLbl.Text = "Версия русификатора: " + rusVer.ToString()+"."+locVer;
            enVer = engVer;
            ruVer = rusVer;
            return engVer > rusVer || isRusUpdateAvailable(rusVer, false);
        }


        //Доступно ли обновление для русификатора?
        bool isRusUpdateAvailable(int ver, bool force)
        {
            mWebClient = new WebClient();

            Stream stream = mWebClient.OpenRead(getVersionUrl);
            StreamReader reader = new StreamReader(stream);
            Dictionary<string, string> json = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd().ToString());
            int servVersion = int.Parse(json["version"]);
            int locVersion = int.Parse(json["locver"]);
            tempLocVersion = int.Parse(json["locver"]);
            return force || servVersion > ruVer || locVersion > locVer;
        }

        // получаем список файлов на сервере
        Dictionary<string, string> getFileList()
        {

            mWebClient = new WebClient();
            Stream stream;
            if (isForcedUpdate)
            {
                stream = mWebClient.OpenRead(getFileListFullUrl);

            }
            else
            {
                stream = mWebClient.OpenRead(getFileListUrl);
            }

            StreamReader reader = new StreamReader(stream);
            Dictionary<string, string> result = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd().ToString());
            return result;
        }



        // Загружаем файлы
        void downloadFiles()
        {
            Dictionary<string, string> list = getFileList();
            PatchStatusLbl.Text = "Загружаем";
            PatchStatusLbl.ForeColor = Color.Gold;
            this.DownloadBar.Value = 0;
            isSettingsButtonDisabled = true;
            isStartButtonDisabled = true;
            SettingsBtn.Image = Resources.BTN_CONFIG_DISABLED;
            StartBtn.Image = Resources.BTN_START_DISABLED;
            Thread thread = new Thread(() =>
            {
                foreach (var item in list)
                {
                    
                    if (File.Exists("Temp/" + item.Key)&& ComputeMD5Checksum("Temp/" + item.Key).ToLower()==item.Value)
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            this.DownloadBar.Value += 100 / list.Count;
                        });
                        continue;
                    }
                    

                    mWebClient = new WebClient();
                    
                    if (!Directory.Exists("Temp")) Directory.CreateDirectory("Temp");

                    if(isForcedUpdate) mWebClient.DownloadFile(new Uri(getFileFullUrl + item.Key), "Temp/" + item.Key);
                    else mWebClient.DownloadFile(new Uri(getFileUrl + item.Key), "Temp/" + item.Key);
                    if (!mWebClient.IsBusy)
                    {
                        mWebClient.Dispose();
                    }
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        this.DownloadBar.Value += 100 / list.Count;
                    });
                }

                this.BeginInvoke((MethodInvoker)delegate
                {
                    this.DownloadBar.Value = DownloadBar.Maximum;
                    PatchStatusLbl.Text = "Загрузка завершена, распаковываем";
                });
                extractArchive();





            });

            thread.Start();



        }


        void extractArchive()
        {
            var f = Directory.GetFiles("Temp", "*.001");
            InstallBar.Value = 0;
           
            

            isSettingsButtonDisabled = true;
            isStartButtonDisabled = true;
            isCloseButtonDisabled = true;
            SettingsBtn.Image = Resources.BTN_CONFIG_DISABLED;
            StartBtn.Image = Resources.BTN_START_DISABLED;
            CloseBtn.Image = Resources.BTN_CLOSE_DISABLED;
            
            Thread thread2 = new Thread(() =>
            {
                SevenZipBase.SetLibraryPath("7z.dll");
                SevenZipExtractor se = new SevenZipExtractor(f[0]);
                
                se.ExtractionFinished += new EventHandler<EventArgs>(se_ExtractionFinished);
                se.Extracting += new EventHandler<ProgressEventArgs>(se_Extracting);

                se.BeginExtractArchive(Directory.GetCurrentDirectory());
            });
            thread2.Start();
        }

        private void se_Extracting(object sender, ProgressEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                InstallBar.Value = e.PercentDone;
            });
        }

        private void se_ExtractionFinished(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                InstallBar.Value = 100;
                LangCB.SelectedIndex = 1;
                PatchStatusLbl.Text = "Установка завершена. Приятной игры!";
                PatchStatusLbl.ForeColor = Color.Green;
                isSettingsButtonDisabled = false;
                isStartButtonDisabled = false;
                isCloseButtonDisabled = false;
                SettingsBtn.Image = Resources.BTN_CONFIG_NORMAL;
                StartBtn.Image = Resources.BTN_START_NORMAL;
                CloseBtn.Image = Resources.BTN_CLOSE_NORMAL;
                
                string rusVerFile = mEncoding.GetString(mNdtDecrypt.Start(rusVersionInfo)).Replace("\0", "");
                rusVerLbl.Text = "Версия русификатора: " + rusVerFile.Substring(rusVerFile.IndexOf("Version\t") + 8, rusVerFile.IndexOf("\r\n<End") - (rusVerFile.IndexOf("Version\t") + 8))+"."+tempLocVersion;
                Settings.Default.LOC_VER = tempLocVersion;
                Settings.Default.Save();
                if (File.Exists("rlauncher_upd.exe"))
                {
                    Process.Start("rlauncher_upd.exe");
                    AppExit();
                }
                if (isForced.Checked == true)
                {
                    isForced.Checked = false;
                    isForcedUpdate = false;
                }

            });
        }


        //Считаем md5
        private string ComputeMD5Checksum(string path)
        {
            using (FileStream fs = System.IO.File.OpenRead(path))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                byte[] checkSum = md5.ComputeHash(fileData);
                string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                return result;
            }
        }

        
    }
}