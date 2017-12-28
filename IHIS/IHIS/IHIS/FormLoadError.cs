using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Configuration;
using System.IO.IsolatedStorage;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
//
using IHIS.Framework;

namespace IHIS
{
    /// <summary>
    /// Notify to user and clear all IsolatedStorage contents
    /// MED-8972
    /// </summary>
    public partial class FormLoadError : Form
    {
        #region Fields & properties

        private int _totalCacheFile = 0;
        private int _step = 1;
        private System.Windows.Forms.Timer _timer2;
        private const string ISOLATED_STORAGE_DIR = "IsolatedStorage";

        #endregion

        #region Constructor
        /// <summary>
        /// FormLoadError
        /// </summary>
        public FormLoadError()
        {
            InitializeComponent();
            SetCultureInfo();
            ApplyMultiLanguage();

            this.lbAppName.Text = System.AppDomain.CurrentDomain.FriendlyName;
            this.progressBar.Minimum = 0;
            this.lbProcess.Visible = false;
            this.MaximizeBox = false;
            this.btnClose.Visible = false;
            this.btnClose.Enabled = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
        }
        #endregion

        #region Events

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLoadError_Load(object sender, EventArgs e)
        {
            try
            {
                ClearIsolatedStorage();
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
            }
            finally
            {
                this.Enabled = false;
                _timer2 = new System.Windows.Forms.Timer();
                _timer2.Tick += new EventHandler(button1_Click);
                _timer2.Interval = 5000;
                _timer2.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        #region Methods (private)

        private void SetCultureInfo()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture.Name, true);
            if (culture.Name.Contains("en"))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", true);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en", true);
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture.Name, true);
            }
        }

        private void ApplyMultiLanguage()
        {
            Service.SetLangMode();
            this.Text = XMsg.GetField("F025");
            this.lbTitle.Text = XMsg.GetField("F025");
            this.lbContent.Text = XMsg.GetField("F026");
            this.lbName.Text = XMsg.GetField("F027");
            this.lbFrom.Text = XMsg.GetField("F028");
            this.btnClose.Text = XMsg.GetField("F031");
        }

        #region ClearIsolatedStorage
        /// <summary>
        /// Clear IsolatedStorage when initializing cache service failed.
        /// https://sofiamedix.atlassian.net/browse/MED-8972
        /// </summary>
        private void ClearIsolatedStorage()
        {
            //_timer1.Stop();
            this.lbProcess.Visible = true;

            try
            {
                IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForDomain();
                string rootDir = store.GetType().GetField("m_RootDir", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(store).ToString();
                string isoDir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(rootDir)))));

                if (isoDir.Contains(ISOLATED_STORAGE_DIR))
                {
                    this._totalCacheFile = Directory.GetFiles(isoDir, "*", SearchOption.AllDirectories).Length;
                    this.progressBar.Maximum = _totalCacheFile;
                    DeleteStorage(isoDir);
                    this.lbProcess.Text = string.Format(XMsg.GetField("F030"), progressBar.Value, this._totalCacheFile);
                }
            }
            catch (Exception ex)
            {
                Logs.StartWriteLog();
                Logs.WriteLog("Clear IsolatedStorage failed. Message: " + ex.Message);
                Logs.EndWriteLog();
            }
        }

        /// <summary>
        /// Clear all folder, sub-folder and files in IsolatedStorage
        /// </summary>
        /// <param name="isoDir"></param>
        private void DeleteStorage(string isoDir)
        {
            try
            {
                foreach (string file in Directory.GetFiles(isoDir))
                {
                    DeleteFile(file);

                    // Update progressbar
                    this.progressBar.Value = this._step;
                    this.lbProcess.Text = string.Format(XMsg.GetField("F029"), progressBar.Value, this._totalCacheFile);
                    this._step++;
                }

                foreach (string nextDir in Directory.GetDirectories(isoDir))
                {
                    DeleteStorage(nextDir);
                }

                RemoveDirectory(isoDir);
            }
            catch (Exception ex)
            {
                Logs.StartWriteLog();
                Logs.WriteLog("DeleteStorage failed. Message: " + ex.Message);
                Logs.EndWriteLog();
            }
            finally { }
        }

        // could not be used
        private static void DeleteStorage1(IsolatedStorageFile storage)
        {
            string rootDir = "";
            //string backingStorePartition = "";

            try
            {
                rootDir = storage.GetType().GetField("m_RootDir", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(storage).ToString();
                string s = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(rootDir))))));
                bool res = RemoveDirectory(rootDir);
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
            }
            finally { }

            if (storage == null || rootDir == "")
            {
                Logs.WriteLog("DeleteStorage error: No IsolatedStorage was found!");
                return;
            }

            // GetDirectoryNames return a list of directory like this:
            // C:\Users\[USER_NAME]\AppData\Local\IsolatedStorage\iqjvy4av.yao\4yxmrtdr.3xd\StrongName.3bivv0sfvqffodluf2m0deihdylyakno\Publisher.wobgdc0ahsmraeplqqlxnqg12riflrpx\Files\demo\-148685955
            string[] storageDir = storage.GetDirectoryNames(@"demo/*");
            foreach (string dirNm in storageDir)
            {
                Logs.WriteLog(string.Format("Scanning folder {0}...", dirNm));
                //storage.DeleteDirectory(dirNm);

                try
                {
                    // GetFileNames return all files in directory above. Example: Exp, Key, LA, RA, ScPr, Val
                    string[] storageFiles = storage.GetFileNames(@"/demo/" + dirNm + @"/*");
                    foreach (string file in storageFiles)
                    {
                        //storage.DeleteFile(rootDir + @"demo/" + dirNm + @"/" + file);
                        // Use string concat to avoid IO.PathTooLongException
                        string longPath = rootDir + @"demo/" + dirNm + @"/" + file;
                        DeleteFile(longPath);
                        Logs.WriteLog(string.Format("Deleted file [{0}] in IsolatedStorage.", file));
                    }

                    // Delete empty folder
                    //storage.DeleteDirectory(@"/demo/" + dirNm);
                    //RemoveDirectory(rootDir + @"demo/" + dirNm);
                }
                catch (Exception ex)
                {
                    Logs.WriteLog("DeleteStorage failed. Message: " + ex.Message);
                }
                finally { }
            }

            // Delete BackingStore partition folder
            try
            {
                RemoveDirectory(rootDir + @"demo");
            }
            catch (Exception ex)
            {
                Logs.WriteLog("DeleteStorage failed. Message: " + ex.Message);
            }
            finally { }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool DeleteFile(string path);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool RemoveDirectory(string lpPathName);
        #endregion

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        #endregion
    }
}