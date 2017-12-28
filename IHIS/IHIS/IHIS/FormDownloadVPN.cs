using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using IHIS.Framework;

namespace IHIS
{
    public partial class FormDownloadVPN : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        private const string SETUP_FOLDER = "setup";
        private BackgroundWorker backgroundWorker = new BackgroundWorker();

        public FormDownloadVPN()
        {
            InitializeComponent();
            this.Text = XMsg.GetMsg("MSG024");

            // MED-14286
            if (NetInfo.Language == LangMode.Jr)
            {
                this.Font = new Font("MS UI Gothic", 9.75f);
            }
            else
            {
                this.Font = new Font("Arial", 8.75f);
            }
        }

        private void FormDownloadVPN_Load(object sender, EventArgs e)
        {
            try
            {
                this.Download();
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Report progress.
            //backgroundWorker.
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            progBar.Value = e.ProgressPercentage;
        }

        private void Install()
        {
            try
            {
                string setupPath = Path.Combine(Path.Combine(Application.StartupPath, SETUP_FOLDER), ConfigurationManager.AppSettings["VPNSetupFileName"]);
                //for (int i = 0; i < 100; i++)
                //{
                //    Thread.Sleep(50);
                //    progBar.Value = i;
                //}
                Process.Start(setupPath);
                ProcessStartInfo psi = new ProcessStartInfo();
                this.Close();

                //Process process = new Process();
                //process.StartInfo.FileName = setupPath;
                //process.StartInfo.Arguments = "/q";
                //process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                //process.Start();
                //process.WaitForExit();

                //ProcessStartInfo psi = new ProcessStartInfo();
                //psi.Arguments = "/s /v /qn /min";
                //psi.CreateNoWindow = true;
                //psi.WindowStyle = ProcessWindowStyle.Hidden;
                //psi.FileName = @"D:\setup\FolderSize-2.6-x64.msi";
                ////psi.UseShellExecute = false;
                //Process.Start(psi);

                //Process p = new Process();
                //p.StartInfo.FileName = "msiexec.exe";
                ////p.StartInfo.Arguments = "/i \"C:\\Application.msi\"/qn";
                //p.StartInfo.Arguments = "/i \"C:\\ihis\\setup\\setupvpnclient.msi\"/qn";
                //p.Start();
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }
        }

        /// <summary>
        /// Downloads and installs VPN client to end-user computer automatically.
        /// </summary>
        /// <returns></returns>
        private void Download()
        {
            try
            {
                string downloadUri = ConfigurationManager.AppSettings["VPNDownloadURL"];
                string downloadPath = Path.Combine(Path.Combine(Application.StartupPath, SETUP_FOLDER), ConfigurationManager.AppSettings["VPNSetupFileName"]);

                // Creates if directory is not exist
                // https://sofiamedix.atlassian.net/browse/MED-11866
                if (!Directory.Exists(Path.Combine(Application.StartupPath, SETUP_FOLDER)))
                {
                    Directory.CreateDirectory(Path.Combine(Application.StartupPath, SETUP_FOLDER));
                }

                using (WebClient client = new WebClient())
                {
                    client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(Completed);
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    client.DownloadFileAsync(new Uri(downloadUri), downloadPath);
                }
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progBar.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // Internet connection error
            if (e.Error != null)
            {
                Logs.WriteLog(e.Error.Message);
                this.Text = XMsg.GetMsg("MSG025");
                Thread.Sleep(3000);
                this.Close();
                return;
            }

            // Installing VPN client...
            //this.progBar.Value = 0;
            //this.Text = XMsg.GetMsg("MSG023");
            this.Install();
            //// Completed
            //this.Text = XMsg.GetMsg("MSG026");
            //// Delay 3s before closing form
            //Thread.Sleep(3000);
            //this.Close();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
    }
}