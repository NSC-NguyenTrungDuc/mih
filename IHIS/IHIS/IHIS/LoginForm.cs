using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using Microsoft.Win32;
using IHIS.Properties;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.Endo;
using System.Timers;
using System.Threading;
using System.Globalization;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Configuration;
using Ionic.Zip;

namespace IHIS
{
    /// <summary>
    /// LoginForm에 대한 요약 설명입니다.
    /// </summary>
    internal class LoginForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtPswd;
        private IHIS.XPButton btnOK;
        private IHIS.XPButton btnCancel;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.CheckBox chkSave;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Label lbSystem;
        private TextBox txtHospCode;
        private CheckBox chkActive;
        private Label label3;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        //Fix bug MED-6993 
        private string endTime = "";
        private string currentTime = "";
        private XPButton btnSettingVPN;
        /*---------------------------------------*/

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public LoginForm()
        {
            //
            // Windows Form 디자이너 지원에 필요합니다.
            //
            InitializeComponent();
            //MED-15367
            DeleteCache();
            // MED-14391
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            #region multilangue login
            string cultureName = "";
            CultureInfo culture = CultureInfo.CurrentCulture;
            Logs.WriteLog("Current UI Culture :" + culture.Name);

            //if (CacheService.Instance.IsSet(Constants.CacheKeyLayout.CACHE_USERS_LOCAL))
            //{
            //    string cultureCacheName = CacheService.Instance.Get(Constants.CacheKeyLayout.CACHE_USERS_LOCAL, "").ToString();
            //    if (!String.IsNullOrEmpty(cultureCacheName))
            //    {
            //        cultureName = cultureCacheName;
            //    }
            //    else
            //    {
            //        cultureName = culture.Name;
            //    }
            //}
            //else
            //{
            //    cultureName = culture.Name;
            //}

            // https://sofiamedix.atlassian.net/browse/MED-8972
            try
            {
                if (CacheService.Instance.IsSet(Constants.CacheKeyLayout.CACHE_USERS_LOCAL))
                {
                    string cultureCacheName = Convert.ToString(CacheService.Instance.Get(Constants.CacheKeyLayout.CACHE_USERS_LOCAL, ""));
                    if (!String.IsNullOrEmpty(cultureCacheName))
                    {
                        cultureName = cultureCacheName;
                    }
                    else
                    {
                        cultureName = culture.Name;
                    }
                }
                else
                {
                    cultureName = culture.Name;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
                if (ex is NullReferenceException)
                {
                    try
                    {
                        // Clear cache and restart app
                        FormLoadError frm = new FormLoadError();
                        frm.ShowDialog();

                        // Restart
                        if (frm.DialogResult == DialogResult.OK)
                        {
                            frm.Dispose();
                            // Restart
                            Application.Restart();
                            Process.GetCurrentProcess().Kill();
                        }

                        Logs.WriteLog("Clear IsolatedStorage done!");
                    }
                    catch (Exception e)
                    {
                        Logs.WriteLog(e.Message);
                    }
                    finally { }
                }
            }
            finally { }

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName, true);
            if (cultureName.Contains("en"))
            {
                cultureName = "en-US";
                String cultureUIName = "en";
                Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName, true);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureUIName, true);
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName, true);
            }

            ApplyMultiLanguage();
            #endregion

            //
            // TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
            //

            try
            {
                //VPNHelpers.ExtAccountDisconnect(CacheService.Instance.Get(VPNHelpers.VPN_CONN_KEY, "").ToString());
                CloudService.Instance.Connect();
            }
            catch
            {
                throw new Exception("Cannot connect to server!");
            }

            // 2015.10.15 changed userID textbox max length from 7 to 10
            // to fix https://nextop-asia.atlassian.net/browse/MED-4702
            txtUserID.MaxLength = 10;
            txtPswd.MaxLength = 16;
            //공통 Login Image로 BackgroundImage 설정
            if (!this.DesignMode)
                SetBackgroundImage();

            // 2015.12.18 updated
            lbSystem.Text = "";

            string hospCode = CacheService.Instance.Get("CACHE_HOSP_CODE", "").ToString();

            if (hospCode != "")
            {
                FormSelectHospCodeArgs args = new FormSelectHospCodeArgs();
                args.HospCode = hospCode;
                FormSelectHospCodeResult res = CloudService.Instance.Submit<FormSelectHospCodeResult, FormSelectHospCodeArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    this.txtHospCode.Text = res.HospCode;
                    this.txtHospCode.Enabled = false;
                    this.chkActive.Checked = false;
                    this.lbSystem.Text = res.HospName;

                    // MED-10181
                    this.UpdateVpnInfo(res);

                    // MED-14286
                    if (res.Language != "JA")
                    {
                        this.Font = new Font("Arial", 8.75f);
                        this.lbTitle.Font = new Font("Arial", 15.75f);
                        this.lbSystem.Font = new Font("Arial", 12f);
                    }
                    else
                    {
                        this.Font = new Font("MS UI Gothic", 9.75f);
                        this.lbTitle.Font = new Font("MS UI Gothic", 15.75f, FontStyle.Bold);
                        this.lbSystem.Font = new Font("MS UI Gothic", 12f, FontStyle.Bold);
                        NetInfo.Language = LangMode.Jr;
                    }
                }
            }
            else
            {
                this.txtHospCode.Enabled = true;
                this.chkActive.Checked = true;

                // MED-14286
                this.Font = new Font("Arial", 8.75f);
                this.lbTitle.Font = new Font("Arial", 15.75f);
                this.lbSystem.Font = new Font("Arial", 12f);
            }

            this.SettingVisibleControl();

            // Auto-reconnect VPN if has valid settings before
            if (UserInfo.VpnYn)
            {
                VPNHelpers.Reconnect(CacheService.Instance.Get(VPNHelpers.VPN_CONN_KEY + this.txtHospCode.Text.Trim(), "").ToString());
            }

            // Attract default kinki database
            try
            {
                // Extract default kinki.zip
                // https://sofiamedix.atlassian.net/browse/MED-14567
                Thread extrThread = new Thread(new ThreadStart(ExtractKinki));
                extrThread.Start();
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }
        }

        private void ApplyMultiLanguage()
        {
            Service.SetLangMode();
            this.btnCancel.Text = XMsg.GetField("btnCancel.Text");
            this.btnOK.Text = XMsg.GetField("btnOK.Text");
            //this.changePswdBtn.Text = XMsg.GetField("changePswdBtn.Text");
            this.chkSave.Text = XMsg.GetField("chkSave.Text");
            this.label1.Text = XMsg.GetField("label1.Text");
            this.label2.Text = XMsg.GetField("label2.Text");
            this.label3.Text = XMsg.GetField("label3.Text");
            this.lbSystem.Text = XMsg.GetField("lbSystem.Text");
            this.lbTitle.Text = XMsg.GetField("lbTitle.Text");
            // MED-10181
            this.btnSettingVPN.Text = XMsg.GetField("btnSettingVPN.Text");
        }

        // https://nextop-asia.atlassian.net/browse/MED-6224
        //public LoginForm(string hospCode, string hospName)
        //{
        //    //
        //    // Windows Form 디자이너 지원에 필요합니다.
        //    //
        //    InitializeComponent();

        //    //
        //    // TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
        //    //

        //    try
        //    {
        //        CloudService.Instance.Connect();
        //    }
        //    catch
        //    {
        //        throw new Exception("Cannot connect to server!");
        //    }

        //    // 2015.10.15 changed userID textbox max length from 7 to 10
        //    // to fix https://nextop-asia.atlassian.net/browse/MED-4702
        //    txtUserID.MaxLength = 10;

        //    //공통 Login Image로 BackgroundImage 설정
        //    if (!this.DesignMode)
        //        SetBackgroundImage();

        //    //// 2015.12.16 https://nextop-asia.atlassian.net/browse/MED-6224
        //    //if (hospName == "")
        //    //{
        //    //    FormSelectHospCodeArgs args = new FormSelectHospCodeArgs();
        //    //    args.HospCode = hospCode;
        //    //    FormSelectHospCodeResult res = CloudService.Instance.Submit<FormSelectHospCodeResult, FormSelectHospCodeArgs>(args);

        //    //    if (res.ExecutionStatus == ExecutionStatus.Success)
        //    //    {
        //    //        hospName = res.HospName;
        //    //    }
        //    //}

        //    //this.lbSystem.Text = hospName;
        //}

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPswd = new System.Windows.Forms.TextBox();
            this.btnOK = new IHIS.XPButton();
            this.btnCancel = new IHIS.XPButton();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.lbMsg = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbSystem = new System.Windows.Forms.Label();
            this.txtHospCode = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnSettingVPN = new IHIS.XPButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserID
            // 
            this.txtUserID.AccessibleDescription = null;
            this.txtUserID.AccessibleName = null;
            resources.ApplyResources(this.txtUserID, "txtUserID");
            this.txtUserID.BackgroundImage = null;
            this.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserID.Font = null;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            this.txtUserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserID_KeyPress);
            // 
            // txtPswd
            // 
            this.txtPswd.AccessibleDescription = null;
            this.txtPswd.AccessibleName = null;
            resources.ApplyResources(this.txtPswd, "txtPswd");
            this.txtPswd.BackgroundImage = null;
            this.txtPswd.Font = null;
            this.txtPswd.Name = "txtPswd";
            this.txtPswd.TextChanged += new System.EventHandler(this.txtPswd_TextChanged);
            this.txtPswd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPswd_KeyPress);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleDescription = null;
            this.btnOK.AccessibleName = null;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.BackgroundImage = null;
            this.btnOK.Font = null;
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = null;
            this.btnCancel.AccessibleName = null;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackgroundImage = null;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Schemes.OliveGreen;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkSave
            // 
            this.chkSave.AccessibleDescription = null;
            this.chkSave.AccessibleName = null;
            resources.ApplyResources(this.chkSave, "chkSave");
            this.chkSave.BackColor = System.Drawing.Color.Transparent;
            this.chkSave.BackgroundImage = null;
            this.chkSave.Checked = true;
            this.chkSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSave.Font = null;
            this.chkSave.Name = "chkSave";
            this.chkSave.UseVisualStyleBackColor = false;
            // 
            // lbMsg
            // 
            this.lbMsg.AccessibleDescription = null;
            this.lbMsg.AccessibleName = null;
            resources.ApplyResources(this.lbMsg, "lbMsg");
            this.lbMsg.BackColor = System.Drawing.Color.Transparent;
            this.lbMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbMsg.Name = "lbMsg";
            // 
            // lbTitle
            // 
            this.lbTitle.AccessibleDescription = null;
            this.lbTitle.AccessibleName = null;
            resources.ApplyResources(this.lbTitle, "lbTitle");
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.ForeColor = System.Drawing.Color.Black;
            this.lbTitle.Name = "lbTitle";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // lbSystem
            // 
            this.lbSystem.AccessibleDescription = null;
            this.lbSystem.AccessibleName = null;
            resources.ApplyResources(this.lbSystem, "lbSystem");
            this.lbSystem.BackColor = System.Drawing.Color.Transparent;
            this.lbSystem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbSystem.Name = "lbSystem";
            // 
            // txtHospCode
            // 
            this.txtHospCode.AccessibleDescription = null;
            this.txtHospCode.AccessibleName = null;
            resources.ApplyResources(this.txtHospCode, "txtHospCode");
            this.txtHospCode.BackgroundImage = null;
            this.txtHospCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHospCode.Font = null;
            this.txtHospCode.Name = "txtHospCode";
            this.txtHospCode.Leave += new System.EventHandler(this.txtHospCode_Leave);
            this.txtHospCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHospCode_KeyPress);
            // 
            // chkActive
            // 
            this.chkActive.AccessibleDescription = null;
            this.chkActive.AccessibleName = null;
            resources.ApplyResources(this.chkActive, "chkActive");
            this.chkActive.BackColor = System.Drawing.Color.Transparent;
            this.chkActive.BackgroundImage = null;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Font = null;
            this.chkActive.Name = "chkActive";
            this.chkActive.UseVisualStyleBackColor = false;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = null;
            this.label3.Name = "label3";
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = null;
            this.panel1.Controls.Add(this.lbSystem);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleDescription = null;
            this.pictureBox1.AccessibleName = null;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = null;
            this.pictureBox1.Font = null;
            this.pictureBox1.Image = global::IHIS.Properties.Resources.icon_kc;
            this.pictureBox1.ImageLocation = null;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.AccessibleDescription = null;
            this.pictureBox2.AccessibleName = null;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BackgroundImage = null;
            this.pictureBox2.Font = null;
            this.pictureBox2.Image = global::IHIS.Properties.Resources.icon_user;
            this.pictureBox2.ImageLocation = null;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.AccessibleDescription = null;
            this.pictureBox3.AccessibleName = null;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::IHIS.Properties.Resources.icon_close;
            this.pictureBox3.Font = null;
            this.pictureBox3.ImageLocation = null;
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // btnSettingVPN
            // 
            this.btnSettingVPN.AccessibleDescription = null;
            this.btnSettingVPN.AccessibleName = null;
            resources.ApplyResources(this.btnSettingVPN, "btnSettingVPN");
            this.btnSettingVPN.BackgroundImage = null;
            this.btnSettingVPN.Font = null;
            this.btnSettingVPN.Name = "btnSettingVPN";
            this.btnSettingVPN.Click += new System.EventHandler(this.btnSettingVPN_Click);
            // 
            // LoginForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ControlBox = false;
            this.Controls.Add(this.btnSettingVPN);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.txtHospCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.chkSave);
            this.Controls.Add(this.txtPswd);
            this.Controls.Add(this.txtUserID);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = null;
            this.Name = "LoginForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region btnOK_Click
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            try
            {
                // https://sofiamedix.atlassian.net/browse/MED-10605
                CloudService.Instance.EnsureVpnYn();

                // Validation
                if (!this.InputChecks())
                {
                    return;
                }

                // Check VPN connection
                if (UserInfo.VpnYn)
                {
                    if (!this.VpnCheck())
                    {
                        return;
                    }
                }

                #region Initialize User Custom Layout
                CustomLayout lstCustomLayout = new CustomLayout();
                if (!CacheService.Instance.IsSet(Constants.CacheKeyLayout.CACHE_USERS_LAYOUT))
                {
                    CacheService.Instance.Set(Constants.CacheKeyLayout.CACHE_USERS_LAYOUT, lstCustomLayout, TimeSpan.MaxValue);
                }
                #endregion

                AttemptTime lstAttemptTime = new AttemptTime();
                if (!CacheService.Instance.IsSet(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES))
                {
                    CacheService.Instance.Set(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES, lstAttemptTime, TimeSpan.MaxValue);
                }
                lstAttemptTime = CacheService.Instance.Get<AttemptTime>(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES);
                if (!lstAttemptTime.ContainsUser(this.txtUserID.Text))
                {
                    UserAttemptTime user = new UserAttemptTime();
                    user.UserId = this.txtUserID.Text;
                    user.AttemptTimes = 0;
                    user.LockedTime = DateTime.MinValue;
                    //user.AttemptChangePass = 0;
                    lstAttemptTime.LstAttempt.Add(user);
                    CacheService.Instance.Set(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES, lstAttemptTime, TimeSpan.MaxValue);
                }

                //check whether user has been locked or not
                if (lstAttemptTime.GetLockedTime(this.txtUserID.Text) != DateTime.MinValue)
                {
                    TimeSpan ts = DateTime.Now - lstAttemptTime.GetLockedTime(this.txtUserID.Text);
                    if (ts.TotalMinutes < 3)
                    {
                        // lbMsg.Text = Resources.MSG007;
                        lbMsg.Text = XMsg.GetMsg("MSG007");
                        return;
                    }
                    else
                    {
                        //reset attempt
                        lstAttemptTime.SetAttemptTime(this.txtUserID.Text, 0);
                        lstAttemptTime.SetLockedTime(this.txtUserID.Text, DateTime.MinValue);
                        CacheService.Instance.Set(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES, lstAttemptTime, TimeSpan.MaxValue);
                    }
                }

                CloudService.Instance.Connect();

                AdmLoginFormCheckLoginUserArgs args = new AdmLoginFormCheckLoginUserArgs();
                args.User = this.txtUserID.Text;
                args.Password = Utility.CreateMd5Hash(this.txtPswd.Text, false);
                args.HospCode = txtHospCode.Text.Trim();
                AdmLoginFormCheckLoginUserResult res = CloudService.Instance.Submit<AdmLoginFormCheckLoginUserResult, AdmLoginFormCheckLoginUserArgs>(args);

                // Set user info
                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (res.UserInfoItem.Count > 0)
                    {
                        // User information were set here
                        this.UpdateUserInfo(res);

                        // VPN is expired?
                        if (VPNHelpers.CertExpired)
                        {
                            lbMsg.Text = XMsg.GetMsg("MSG021");
                            return;
                        }

                        //Fix bug MED-6993.Get "CurrentTime","EndTime"
                        currentTime = res.UserInfoItem[0].CurrentTime;
                        endTime = res.UserInfoItem[0].EndTime;

                        // Removes expired caches
                        this.ClearMemory(res);

                        Service.SetLangMode();
                        lstAttemptTime.SetAttemptTime(this.txtUserID.Text, 0);
                        lstAttemptTime.SetLockedTime(this.txtUserID.Text, DateTime.MinValue);
                        CacheService.Instance.Set(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES, lstAttemptTime, TimeSpan.MaxValue);
                    }
                    else
                    {
                        if (res.Msg == "SMO") // User SMO
                        {
                            lbMsg.Text = XMsg.GetMsg("MSG015");
                            DelayForm();
                            return;
                        }
                        int attemptTimes = lstAttemptTime.GetAttemptTime(this.txtUserID.Text) + 1;
                        lstAttemptTime.SetAttemptTime(this.txtUserID.Text, attemptTimes);
                        if (attemptTimes >= Constants.SecurityLogin.MAX_ATTEMPT_TIMES)
                        {
                            lstAttemptTime.SetLockedTime(this.txtUserID.Text, DateTime.Now);
                            CacheService.Instance.Set(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES, lstAttemptTime, TimeSpan.MaxValue);
                            lbMsg.Text = XMsg.GetMsg("MSG007");
                            DelayForm();
                            return;
                        }
                        else
                        {

                            CacheService.Instance.Set(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES, lstAttemptTime, TimeSpan.MaxValue);
                        }
                        //lbMsg.Text = Resources.MSG002; // Username or password is incorrect
                        lbMsg.Text = XMsg.GetMsg("MSG002");
                        DelayForm();
                        return;
                    }
                }
                // https://sofiamedix.atlassian.net/browse/MED-10582
                else if (res.ExecutionStatus == ExecutionStatus.RequireVpn)
                {
                    lbMsg.Text = XMsg.GetMsg("MSG019");
                    return;
                }
                else
                {
                    //lbMsg.Text = Resources.MSG002; // Username or password is incorrect
                    lbMsg.Text = XMsg.GetMsg("MSG002");
                    DelayForm();
                    return;
                }

                //Fix bug MED-6993 
                // Compare to "EndTime" , "CurrentTime"               
                if (endTime != string.Empty)
                {
                    if (DateTime.Parse(endTime) < DateTime.Parse(currentTime))
                    {
                        //string errMsg = Resources.MSG012;lbMsg.Text = XMsg.GetMsg("M006")
                        string errMsg = XMsg.GetMsg("MSG012");
                        lbMsg.Text = errMsg;
                        DelayForm();
                        return;
                    }
                }

                //clear changePasswordAttemp if user is unlock
                if (UserInfo.ChangePwdFlg == "1")
                {
                    AttemptTime at = CacheService.Instance.Get<AttemptTime>(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES);
                    at.SetAttemptChangePass(UserInfo.UserID, 0);
                    CacheService.Instance.Set(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES, at, TimeSpan.MaxValue);
                }

                //first login need change pass
                if (UserInfo.FirstLoginFlg == "Y" && UserInfo.ChangePwdFlg == "Y")
                {
                    //this.Hide();
                    ChangePswdForm ChangePwd = new ChangePswdForm(UserInfo.UserID);
                    if (ChangePwd.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }
                if (UserInfo.FirstLoginFlg == "Y" && UserInfo.ChangePwdFlg == "N")
                {
                    //lbMsg.Text = Resources.MSG010;
                    lbMsg.Text = XMsg.GetMsg("MSG010");
                    DelayForm();
                    return;
                }
                //after 1 years need change pass
                if (UserInfo.LastPwdChange != string.Empty)
                {
                    // Use DateTime.TryParse instead
                    string[] nowSplit = UserInfo.CurrentTime.Split('/');
                    int yearN = Convert.ToInt32(nowSplit[0]);
                    int monthN = Convert.ToInt32(nowSplit[1]);
                    int dayN = Convert.ToInt32(nowSplit[2]);
                    string[] lastSplit = UserInfo.LastPwdChange.Split('/');
                    int yearL = Convert.ToInt32(lastSplit[0]);
                    int monthL = Convert.ToInt32(lastSplit[1]);
                    int dayL = Convert.ToInt32(lastSplit[2]);

                    DateTime date1 = new DateTime(yearN, monthN, dayN);
                    DateTime date2 = new DateTime(yearL, monthL, dayL);
                    TimeSpan span = date1.Subtract(date2);
                    double subDay = span.TotalDays;

                    if (subDay > 365 && UserInfo.ChangePwdFlg == "Y")
                    {
                        //this.Hide();
                        ChangePswdForm ChangePwd = new ChangePswdForm(UserInfo.UserID);
                        if (ChangePwd.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }
                    }
                    if (subDay > 365 && UserInfo.ChangePwdFlg == "N")
                    {
                        //   lbMsg.Text = Resources.MSG008;
                        lbMsg.Text = XMsg.GetMsg("MSG008");
                        DelayForm();
                        return;
                    }
                }

                // Caching data
                Logs.WriteLog("==============================================================================");
                Logs.WriteLog("[CACHING USER INFO START]...");
                if (this.chkSave.Checked)
                {
                    CacheService.Instance.Set(Constants.CacheKeyCbo.CACHE_USER_ID, UserInfo.UserID, TimeSpan.MaxValue);
                    CacheService.Instance.Set(Constants.CacheKeyCbo.CACHE_COMMON_ADMIN_YN, "Y", TimeSpan.MaxValue);
                }
                else
                {
                    CacheService.Instance.Remove(Constants.CacheKeyCbo.CACHE_USER_ID);
                    CacheService.Instance.Set(Constants.CacheKeyCbo.CACHE_COMMON_ADMIN_YN, "N", TimeSpan.MaxValue);
                }
                Logs.WriteLog("[CACHE_USER_ID.KEY]:" + Constants.CacheKeyCbo.CACHE_USER_ID);
                Logs.WriteLog("[USER_ID]:" + UserInfo.UserID);
                Logs.WriteLog("[CACHE_COMMON_ADMIN_YN.KEY]:" + Constants.CacheKeyCbo.CACHE_COMMON_ADMIN_YN);
                Logs.WriteLog("[CACHE_COMMON_ADMIN_YN.VALUE]:" + CacheService.Instance.Get(Constants.CacheKeyCbo.CACHE_COMMON_ADMIN_YN, ""));
                Logs.WriteLog("[CACHING USER INFO END].");

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logs.WriteLog("LOGIN ERROR!");
                Logs.WriteLog("StackTrace: " + ex.StackTrace);
                Logs.WriteLog("===================================================");
                Logs.WriteLog("Message: " + ex.Message);
            }
        }

        /// <summary>
        /// Default kinki:
        /// https://sofiamedix.atlassian.net/browse/MED-14567
        /// </summary>
        private void ExtractKinki()
        {
            string kcckDbFile = Environment.CurrentDirectory + "\\SQLiteDB\\kcck.db";
            string mainDbFile = Environment.CurrentDirectory + "\\SQLiteDB\\main.db";
            string mainDbTempFile = Environment.CurrentDirectory + "\\SQLiteDB\\main.db.temp";
            string kinkiZipFile = Environment.CurrentDirectory + "\\SQLiteDB\\kinki.zip";

            // No zip file to unzip?
            if (!File.Exists(kinkiZipFile))
            {
                return;
            }

            try
            {
                // Delete current kcck.db
                if (File.Exists(kcckDbFile))
                {
                    File.Delete(kcckDbFile);
                }

                // Path to Unzip
                string extractPath = Environment.CurrentDirectory + "\\SQLiteDB\\";

                // Unzip
                using (ZipFile zip = ZipFile.Read(kinkiZipFile))
                {
                    // Delete temp file
                    if (File.Exists(mainDbTempFile))
                    {
                        File.Delete(mainDbTempFile);
                    }

                    zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                }

                // Rename to kcck.db
                if (File.Exists(mainDbFile))
                {
                    File.Copy(mainDbFile, kcckDbFile, true);
                    File.Delete(mainDbFile);
                    File.Delete(kinkiZipFile);
                }
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }
        }

        private bool InputChecks()
        {
            // Validate HospCode
            // https://nextop-asia.atlassian.net/browse/MED-6281
            if (txtHospCode.Text.Trim() == "")
            {
                // lbMsg.Text = Resources.MSG006;
                lbMsg.Text = XMsg.GetMsg("MSG006");
                txtHospCode.Focus();
                return false;
            }

            //추후 사용자 TABLE 확정후 사용자 ID 비밀번호 CHECK 확인 Logic 추가
            if (txtUserID.Text.Trim() == "")
            {
                lbMsg.Text = XMsg.GetMsg("M001"); // 사용자ID가 입력되지 않았습니다.
                txtUserID.Focus();
                return false;
            }
            if (txtPswd.Text.Trim() == "")
            {
                lbMsg.Text = XMsg.GetMsg("M002"); // 비밀번호가 입력되지 않았습니다."
                txtPswd.Focus();
                return false;
            }

            return true;
        }

        private bool VpnCheck()
        {
            bool result = false;

            try
            {
                //string vpnUser = CacheService.Instance.Get(VPNHelpers.VPN_CONN_KEY, "").ToString();
                string vpnUser = CacheService.Instance.Get(VPNHelpers.VPN_CONN_KEY + txtHospCode.Text.Trim(), "").ToString();
                //string newUser = txtHospCode.Text.Trim() + "_" + txtUserID.Text.Trim();

                //if (!string.IsNullOrEmpty(vpnUser) && vpnUser != newUser)
                //{
                //    // Disconnect current connection to open a new connection
                //    int ret = VPNHelpers.StartProcess();
                //    ret = VPNHelpers.ExtAccountDisconnect(vpnUser);
                //}

                // https://sofiamedix.atlassian.net/browse/MED-13378
                if (!string.IsNullOrEmpty(vpnUser))
                {
                    int ret;
                    ret = VPNHelpers.StartProcess();
                    ret = VPNHelpers.ExtAccountConnect(vpnUser);

                    if (ret == 6 || ret == 35)
                    {
                        // Connected
                        result = true;
                    }
                    else
                    {
                        lbMsg.Text = XMsg.GetMsg("MSG019");
                    }
                }
                else
                {
                    lbMsg.Text = XMsg.GetMsg("MSG019");
                }
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }

            return result;
        }

        private void UpdateUserInfo(AdmLoginFormCheckLoginUserResult res)
        {
            UserInfo.UserID = res.UserInfoItem[0].UserId;
            UserInfo.HospCode = res.UserInfoItem[0].HospCode;
            UserInfo.TimeZone = res.UserInfoItem[0].TimeZone;
            UserInfo.UserGroup = res.UserInfoItem[0].UserGroup;
            UserInfo.UserName = res.UserInfoItem[0].UserNm;
            UserInfo.UserPswd = Utility.CreateMd5Hash(this.txtPswd.Text, false);
            UserInfo.DoctorDrugCheck = res.UserInfoItem[0].DoctorDrugCheck.Equals("Y");
            UserInfo.CheckDosage = res.UserInfoItem[0].CheckDosage.Equals("Y");
            UserInfo.CheckInteraction = res.UserInfoItem[0].CheckInteraction.Equals("Y");
            UserInfo.CheckKinki = res.UserInfoItem[0].CheckKinki.Equals("Y");
            UserInfo.VersionDrugChecking = res.UserInfoItem[0].RevDrugChecking;
            UserInfo.VersionDrugDosage = res.UserInfoItem[0].RevDosage;
            UserInfo.VersionDrugGenericName = res.UserInfoItem[0].RevGenericName;
            UserInfo.VersionDrugInteraction = res.UserInfoItem[0].RevInteraction;
            UserInfo.VersionDrugKinkiDisease = res.UserInfoItem[0].RevKinkiDisease;
            UserInfo.VersionDrugKinkiMessage = res.UserInfoItem[0].RevKinkiMessage;
            UserInfo.ChangePwdFlg = res.UserInfoItem[0].ChangePwdFlg;
            UserInfo.FirstLoginFlg = res.UserInfoItem[0].FirstLoginFlg;
            UserInfo.LastPwdChange = res.UserInfoItem[0].LastPwdChange;
            UserInfo.PwdHistory = res.UserInfoItem[0].PwdHistory;
            UserInfo.CurrentTime = res.UserInfoItem[0].CurrentTime;
            // 2015.12.02 Cloud team: add Orca server info
            UserInfo.OrcaIp = res.OrcaInfo.OrcaIp;
            UserInfo.OrcaUser = res.OrcaInfo.OrcaUser;
            UserInfo.OrcaPassword = res.OrcaInfo.OrcaPassword;
            // 2015.12.23 Added by Cloud
            UserInfo.OrcaPort = res.OrcaInfo.OrcaPort;
            UserInfo.OrcaHospCode = res.OrcaInfo.OrcaHospCode;
            UserInfo.OrcaPortRcvClaim = res.OrcaInfo.OrcaPortRcvClaim;
            // 2016.04.07 Added by Cloud
            UserInfo.UsePHR = res.UserInfoItem[0].UsePhr;
            //2016.05.12 MED-10202
            UserInfo.OrcaCloudYn = res.OrcaInfo.OrcaCloudYn;
            //Misa
            UserInfo.MisaIp = res.MisaInfo.MisaIp;
            UserInfo.MisaUser = res.MisaInfo.MisaUser;
            UserInfo.MisaPwd = res.MisaInfo.MisaPwd;
            UserInfo.MisaDbInsurName = res.MisaInfo.MisaDbInsurName;
            UserInfo.MisaInstanceName = res.MisaInfo.MisaInstanceName;
            UserInfo.MisaDbNonInsurName = res.MisaInfo.MisaDbNonInsurName;
            // New Master Data
            // https://sofiamedix.atlassian.net/browse/MED-7316
            res.NewMstDataListItem.ForEach(delegate(NewMstDataListInfo item)
            {
                UserInfo.NewMstDataLst.Add(item.ScreenName);
            });
            // https://sofiamedix.atlassian.net/browse/MED-10712
            UserInfo.CertExpired = res.UserInfoItem[0].CertExpired;
            // MED-6861
            UserInfo.InvUsage = res.UserInfoItem[0].InvUsage == "Y";

            // https://sofiamedix.atlassian.net/browse/MED-15742
            UserInfo.CplDatabase = res.CplItgItem.CplDatabase;
            UserInfo.CplDevBio = res.CplItgItem.CplDevBio;
            UserInfo.CplDevBlood = res.CplItgItem.CplDevBlood;
            UserInfo.CplDevUrine = res.CplItgItem.CplDevUrine;
            UserInfo.CplPassword = res.CplItgItem.CplPassword;
            UserInfo.CplPort = res.CplItgItem.CplPort;
            UserInfo.CplServer = res.CplItgItem.CplServer;
            UserInfo.CplSpecimenAuto = res.CplItgItem.CplSpecimenAuto;
            UserInfo.CplUserId = res.CplItgItem.CplUserId;

            // Language mode
            switch (res.UserInfoItem[0].Language)
            {
                case "JA":
                    NetInfo.Language = LangMode.Jr;
                    CacheService.Instance.Set(Constants.CacheKeyLayout.CACHE_USERS_LOCAL, "ja-JP", TimeSpan.MaxValue);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja-JP", true);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP", true);
                    break;
                case "EN":
                    NetInfo.Language = LangMode.En;
                    CacheService.Instance.Set(Constants.CacheKeyLayout.CACHE_USERS_LOCAL, "en", TimeSpan.MaxValue);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en", true);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", true);
                    break;
                case "VI":
                    NetInfo.Language = LangMode.Vi;
                    CacheService.Instance.Set(Constants.CacheKeyLayout.CACHE_USERS_LOCAL, "vi-VN", TimeSpan.MaxValue);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN", true);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN", true);
                    break;
                default:
                    NetInfo.Language = LangMode.Jr;
                    CacheService.Instance.Set(Constants.CacheKeyLayout.CACHE_USERS_LOCAL, "ja-JP", TimeSpan.MaxValue);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja-JP", true);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP", true);
                    break;
            }
        }

        private void ClearMemory(AdmLoginFormCheckLoginUserResult res)
        {
            try
            {
                // Caching revision mechanism
                // https://sofiamedix.atlassian.net/browse/MED-8153
                Dictionary<string, int> newRevDic = new Dictionary<string, int>();
                res.CacheRevItem.ForEach(delegate(CacheRevisionInfo item)
                {
                    if (!newRevDic.ContainsKey(item.TableName))
                    {
                        newRevDic.Add(item.TableName, item.Revision);
                    }
                });

                // Set revision info into memory (first time login)
                if (!CacheService.Instance.IsSet(CacheServiceHelper.CACHE_REVISION_KEY))
                {
                    CacheService.Instance.Set(CacheServiceHelper.CACHE_REVISION_KEY, newRevDic, TimeSpan.MaxValue);
                }

                // Removes all expired cache
                CacheServiceHelper.RemoveExpiredCache((Dictionary<string, int>)CacheService.Instance.Get(CacheServiceHelper.CACHE_REVISION_KEY, new Dictionary<string, int>()), newRevDic);
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }
        }
        #endregion

        //delay 2 seconds if user input wrong account
        private void DelayForm()
        {
            this.txtUserID.Enabled = false;
            this.txtPswd.Enabled = false;
            //this.changePswdBtn.Enabled = false;
            this.btnOK.Enabled = false;
            this.btnCancel.Enabled = false;
            // https://sofiamedix.atlassian.net/browse/MED-10181
            this.btnSettingVPN.Enabled = false;

            Thread.Sleep(2000);
            this.txtUserID.Enabled = true;
            this.txtPswd.Enabled = true;
            //this.changePswdBtn.Enabled = true;
            this.btnOK.Enabled = true;
            this.btnCancel.Enabled = true;
            // https://sofiamedix.atlassian.net/browse/MED-10181
            this.btnSettingVPN.Enabled = true;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #region CheckAdminUser
        private bool CheckAdminUser()
        {
            this.lbMsg.Text = "";

            ////ADM3200의 USER_GROUP이 Admin인지 여부 Check, 사용자 ID, 비밀번호 Check
            ////<ORACLE>
            //// TODO comment use connect cloud
            ///*string cmdText 
            //    = "SELECT USER_SCRT, USER_GROUP, DECODE(USER_END_YMD, NULL,'Y','N') USE_YN "
            //    + "  FROM ADM3200 "
            //    + " WHERE USER_ID ='" + this.txtUserID.Text + "'";*/
            //CheckAdminUserArgs vCheckAdminUserArgs = new CheckAdminUserArgs();
            //vCheckAdminUserArgs.UserId = this.txtUserID.Text;
            //CheckAdminUserResult result = CloudService.Instance.Submit<CheckAdminUserResult, CheckAdminUserArgs>(vCheckAdminUserArgs);
            ///*
            ////<MYSQL>
            //string cmdText
            //    = "SELECT USER_SCRT, USER_GROUP, (CASE IFNULL(USER_END_YMD,'X') WHEN 'X' THEN 'Y' ELSE 'N' END) USE_YN "
            //    + "  FROM ADM3200 "
            //    + " WHERE USER_ID ='" + this.txtUserID.Text + "'";
            //*/
            ////			DataTable table = Service.ExecuteDataTable(cmdText);
            //DataTable table = new DataTable();

            //if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    table = Utility.ConvertToDataTable(result.UserInfo);
            //}
            //if (table.Rows.Count < 1) //사용자 ID 잘못 입력
            //{
            //    lbMsg.Text = XMsg.GetMsg("M003"); // 사용자ID를 잘못 입력하셨습니다."
            //    return false;
            //}
            //string scrt = table.Rows[0][0].ToString();
            //string group = table.Rows[0][1].ToString();
            //string useYn = table.Rows[0][2].ToString();
            //if (useYn == "N")
            //{
            //    lbMsg.Text = XMsg.GetMsg("M004"); // 시스템 사용이 종료되었습니다."
            //    return false;
            //}
            //if (scrt != this.txtPswd.Text)
            //{
            //    lbMsg.Text = XMsg.GetMsg("M005"); // 비밀번호를 잘못 입력하셨습니다."
            //    return false;
            //}
            //if (group != "ADMIN")  //Admin Group이 아니면 Admin 로그인 불가
            //{
            //    lbMsg.Text = XMsg.GetMsg("M006"); // 시스템 관리자가 아닙니다."
            //    return false;
            //}
            //return true;

            // 2015.08.17 AnhNV Added START
            bool success = false;
            AdmLoginFormCheckLoginUserArgs args = new AdmLoginFormCheckLoginUserArgs();
            args.User = txtUserID.Text;
            args.Password = txtPswd.Text;
            AdmLoginFormCheckLoginUserResult res = CloudService.Instance.Submit<AdmLoginFormCheckLoginUserResult, AdmLoginFormCheckLoginUserArgs>(args);

            // Set user info
            if (res.ExecutionStatus == ExecutionStatus.Success && res.UserInfoItem.Count > 0)
            {
                success = true;
                UserInfo.UserID = res.UserInfoItem[0].UserId;
                UserInfo.HospCode = res.UserInfoItem[0].HospCode;
                UserInfo.UserGroup = res.UserInfoItem[0].UserGroup;
                UserInfo.UserName = res.UserInfoItem[0].UserNm;
                UserInfo.UserPswd = this.txtPswd.Text;
            }
            else
            {
                //lbMsg.Text = Resources.MSG002; // Username or password is incorrect
                lbMsg.Text = XMsg.GetMsg("MSG002");
            }

            return success;
            // 2015.08.17 AnhNV Added END
        }
        #endregion

        #region OnLoad, OnMouseMove
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SetControlTextByLangMode();

            //사용자 ID Registry에서 GET
            //Registry에 ID가 등록되어있으면 ID Display(CheckBox:checked)
            /*RegistryKey rkey = Registry.LocalMachine;

            RegistryKey rkey1 = rkey.OpenSubKey("SOFTWARE\\IHIS\\USER");
            if (rkey1 == null)
            {
                rkey1 = rkey.CreateSubKey("SOFTWARE\\IHIS\\USER");
            }
            if (rkey1.GetValue("ID") != null)
            {
                this.txtUserID.Text = rkey1.GetValue("ID").ToString();
                //Focus는 Pswd에 SET (Post로 Call)
                PostCallHelper.PostCall(new PostMethod(SetFocus));
            }
            rkey1.Close();*/

            Logs.StartWriteLog();
            Logs.WriteLog("[LOGIN FORM - ONLOAD START]...");
            Logs.WriteLog("[CACHE_USER_ID.KEY]:" + Constants.CacheKeyCbo.CACHE_USER_ID);
            Logs.WriteLog("[USER_ID]:" + CacheService.Instance.Get(Constants.CacheKeyCbo.CACHE_USER_ID, "").ToString());

            if (CacheService.Instance.IsSet(Constants.CacheKeyCbo.CACHE_USER_ID))
            {
                this.txtUserID.Text = CacheService.Instance.Get(Constants.CacheKeyCbo.CACHE_USER_ID, "").ToString();
            }
            else
            {
                this.txtUserID.Text = string.Empty;
            }

            if (CacheService.Instance.IsSet(Constants.CacheKeyCbo.CACHE_COMMON_ADMIN_YN)
                && CacheService.Instance.Get(Constants.CacheKeyCbo.CACHE_COMMON_ADMIN_YN, "N").ToString() == "Y")
            {
                this.chkSave.Checked = true;
            }
            else
            {
                this.chkSave.Checked = false;
            }

            Logs.WriteLog("[LOGIN FORM - ONLOAD END].");
            Logs.EndWriteLog();

            //if (CacheService.Instance.IsSet(Constants.CacheKeyCbo.CACHE_COMMON_ID))
            //{
            //    this.txtUserID.Text = CacheService.Instance.Get(Constants.CacheKeyCbo.CACHE_COMMON_ID, "").ToString();
            //    //Focus는 Pswd에 SET (Post로 Call)
            //    PostCallHelper.PostCall(new PostMethod(SetFocus));
            //}

            // https://sofiamedix.atlassian.net/browse/MED-10889
            PostCallHelper.PostCall(new PostMethod(CheckUsingVPN));
        }

        private void SetFocus()
        {
            this.txtPswd.Focus();
        }
        #endregion

        #region WndProc
        protected override void WndProc(ref Message m)
        {
            //WM_NCHITTEST시에 Caption을 선택한 것처럼 Msg Hook
            if (m.Msg == (int)Msgs.WM_NCHITTEST)
                m.Result = new IntPtr(2); //Hit Caption
            else
                base.WndProc(ref m);
        }
        #endregion

        private void txtUserID_TextChanged(object sender, System.EventArgs e)
        {
            //Text의 Length가 7이면 다음으로 이동
            //if (txtUserID.Text.Length == 7)
            // 2015.10.15 changed userID textbox max length from 7 to 10
            // to fix https://nextop-asia.atlassian.net/browse/MED-4702
            if (txtUserID.Text.Length == 10)
            {
                SendKeys.SendWait("{TAB}");
            }
        }

        private void txtPswd_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //EnterKey입력시 비밀번호가 입력되었으면 확인 Click 처리
            if ((e.KeyChar == (char)13) && (this.txtPswd.Text != ""))
                this.btnOK.PerformClick();
        }

        private void txtUserID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //Enter Key 입력시 Tab Key 발생
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        #region SetBackgroundImage, CalculateGraphicsPath
        private void SetBackgroundImage()
        {
            try
            {
                //string fileName = Application.StartupPath + "\\Images\\Login.gif";
                string fileName = Application.StartupPath + "\\Images\\form_login_background2.gif";
                if (File.Exists(fileName))
                {
                    Bitmap backImg = Image.FromFile(fileName) as Bitmap;
                    this.BackgroundImage = backImg;
                    //Bitmap TransParent (테두리가 TransParent이므로 적용안함)
                    Color tColor = backImg.GetPixel(0, 0);
                    backImg.MakeTransparent(tColor);

                    //Size 설정 (MaxSize도 고정)
                    //this.ClientSize = backImg.Size;
                    //this.MaximumSize = backImg.Size;

                    //Form의 Region 설정
                    //this.Region = new Region(CalculateGraphicsPath(backImg));

                }
            }
            finally { }
        }
        private static GraphicsPath CalculateGraphicsPath(Bitmap bitmap)
        {

            GraphicsPath graphicsPath = new GraphicsPath();

            // TransParent Color
            Color tColor = bitmap.GetPixel(0, 0);

            // 0 ~ 10까지는 TransParent 계산, 10 ~ 275까지는 Rect 적용(TransParent없음)
            // 275 ~height까지 TransParent 계산

            int colOpaquePixel = 0;

            // Go through all rows (Y axis)
            for (int row = 0; row < 10; row++)
            {
                // Reset value
                colOpaquePixel = 0;

                // Go through all columns (X axis)
                for (int col = 0; col < bitmap.Width; col++)
                {
                    if (bitmap.GetPixel(col, row) != tColor)
                    {
                        colOpaquePixel = col;
                        int colNext = col;
                        for (colNext = colOpaquePixel; colNext < bitmap.Width; colNext++)
                            if (bitmap.GetPixel(colNext, row) == tColor)
                                break;
                        graphicsPath.AddRectangle(new Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1));
                        col = colNext;
                    }
                }
            }
            graphicsPath.AddRectangle(new Rectangle(0, 10, bitmap.Width, 265));
            for (int row = 275; row < bitmap.Height; row++)
            {
                // Reset value
                colOpaquePixel = 0;

                // Go through all columns (X axis)
                for (int col = 0; col < bitmap.Width; col++)
                {
                    if (bitmap.GetPixel(col, row) != tColor)
                    {
                        colOpaquePixel = col;
                        int colNext = col;
                        for (colNext = colOpaquePixel; colNext < bitmap.Width; colNext++)
                            if (bitmap.GetPixel(colNext, row) == tColor)
                                break;
                        graphicsPath.AddRectangle(new Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1));
                        col = colNext;
                    }
                }
            }

            // Return calculated graphics path
            return graphicsPath;
        }
        #endregion

        //일본어, 한글 모드에 따른 Text 설정
        private void SetControlTextByLangMode()
        {
            //this.btnOK.Text = XMsg.GetField("F001"); // 확 인" : "ログイン");
            //this.btnCancel.Text = XMsg.GetField("F002"); // 취 소" : "キャンセル");
            //this.chkSave.Text = XMsg.GetField("F003"); // 하루동안 체크하지 않음" : "一日間、チェックしていない");
            //this.lbTitle.Text = XMsg.GetField("F004"); // ADMIN 로그인" : "ADMIN ログイン");
        }

        //private void changePswdBtn_Click(object sender, EventArgs e)
        //{
        //    //사용자 입력여부 확인
        //    if (this.txtUserID.Text.Trim() == "")
        //    {
        //        lbMsg.Text = Resources.MSG001; // 사용자ID가 입력되지 않았습니다."
        //        txtUserID.Focus();
        //        return;
        //    }
        //    ChangePswdForm dlg = new ChangePswdForm(this.txtUserID.Text.Trim());
        //    dlg.ShowDialog();
        //    dlg.Dispose();
        //}

        private void txtHospCode_Leave(object sender, EventArgs e)
        {
            UserInfo.VpnYn = false;
            if (txtHospCode.Text.Trim() == "")
            {
                lbSystem.Text = "";
                UserInfo.VpnYn = false;
                this.SettingVisibleControl();
                return;
            }

            try
            {
                //string currHospcode = CacheService.Instance.Get("CACHE_HOSP_CODE", "").ToString();
                //VPNHelpers.ExtAccountDisconnect(currHospcode);
                CloudService.Instance.EnsureVpnYn();

                FormSelectHospCodeArgs args = new FormSelectHospCodeArgs();
                args.HospCode = txtHospCode.Text.Trim();
                FormSelectHospCodeResult res = CloudService.Instance.Submit<FormSelectHospCodeResult, FormSelectHospCodeArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (res.HospCode != "")
                    {
                        // MED-10181
                        this.UpdateVpnInfo(res);
                        this.SettingVisibleControl();
                        // https://sofiamedix.atlassian.net/browse/MED-10889
                        this.CheckUsingVPN();

                        CacheService.Instance.Set("CACHE_HOSP_CODE", res.HospCode, TimeSpan.MaxValue);
                        this.lbSystem.Text = res.HospName;

                        if (this.lbMsg.Text.Contains("病院コード"))
                        {
                            this.lbMsg.Text = "";
                        }
                    }
                    else
                    {
                        // Hosp code does not exist
                        //lbMsg.Text = string.Format(Resources.MSG005, txtHospCode.Text.Trim());lbMsg.Text = XMsg.GetMsg("MSG007");
                        lbMsg.Text = string.Format(XMsg.GetMsg("MSG005"), txtHospCode.Text.Trim());
                        lbSystem.Text = "";
                        txtHospCode.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.WriteLog("FormSelectHospCodeRequest exception: " + ex.Message);
            }
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            txtHospCode.Enabled = chkActive.Checked;
        }

        private void txtHospCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Focus to UserID textbox when user press ENTER key
            if (e.KeyChar == (char)13)
            {
                txtUserID.Focus();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnCancel.PerformClick();
        }

        private void txtPswd_TextChanged(object sender, EventArgs e)
        {

        }

        #region VPN - https://sofiamedix.atlassian.net/browse/MED-10181

        /// <summary>
        /// https://sofiamedix.atlassian.net/browse/MED-10181
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettingVPN_Click(object sender, EventArgs e)
        {
            FormSettingVPN frm;

            try
            {
                // MED-10901
                string connectionName = "";
                string hospCode = txtHospCode.Text.Trim();

                if (!string.IsNullOrEmpty(txtUserID.Text.Trim()))
                {
                    connectionName = string.Concat(txtHospCode.Text.Trim(), "_", txtUserID.Text.Trim());
                }

                frm = new FormSettingVPN(hospCode, connectionName);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally
            {
            }
        }

        /// <summary>
        /// Hide/unhide button Settings
        /// </summary>
        private void SettingVisibleControl()
        {
            // Use VPN?
            if (UserInfo.VpnYn)
            {
                this.btnSettingVPN.Visible = true;

                // https://sofiamedix.atlassian.net/browse/MED-13394
                //this.btnSettingVPN.Location = new Point(84, 313);
                //this.btnOK.Location = new Point(175, 313);
                //this.btnCancel.Location = new Point(266, 313);
                this.btnSettingVPN.Location = new Point(84, this.btnSettingVPN.Location.Y);
                this.btnOK.Location = new Point(175, this.btnOK.Location.Y);
                this.btnCancel.Location = new Point(266, this.btnCancel.Location.Y);
            }
            else
            {
                this.btnSettingVPN.Visible = false;

                // https://sofiamedix.atlassian.net/browse/MED-13394
                //this.btnOK.Location = new Point(130, 313);
                //this.btnCancel.Location = new Point(221, 313);
                this.btnOK.Location = new Point(130, this.btnOK.Location.Y);
                this.btnCancel.Location = new Point(221, this.btnOK.Location.Y);
            }
        }

        /// <summary>
        /// https://sofiamedix.atlassian.net/browse/MED-10582
        /// </summary>
        /// <param name="result"></param>
        private void UpdateVpnInfo(FormSelectHospCodeResult result)
        {
            this.lbMsg.Text = "";
            UserInfo.VpnYn = result.VpnYn == "Y";

            if (result.VpnYn == "Y")
            {
                try
                {
                    int ret = 1;

                    // Attempt to set up a new connection to VPN server
                    string cert = Convert.ToString(CacheService.Instance.Get(VPNHelpers.VPN_CERT + this.txtHospCode.Text.Trim(), ""));
                    string key = Convert.ToString(CacheService.Instance.Get(VPNHelpers.VPN_KEY + this.txtHospCode.Text.Trim(), ""));
                    string vpnUser = CacheService.Instance.Get(VPNHelpers.VPN_CONN_KEY + this.txtHospCode.Text.Trim(), "").ToString();

                    if (!string.IsNullOrEmpty(cert) && !string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(vpnUser))
                    {
                        ret = VPNHelpers.StartProcess();
                        //ret = VPNHelpers.NicCreate();
                        ret = VPNHelpers.ExtAccountCreate(vpnUser, vpnUser);
                        ret = VPNHelpers.ExtAccountCertSet(vpnUser, key, cert);
                        ret = VPNHelpers.ExtAccountConnect(vpnUser);
                    }
                }
                catch (Exception ex)
                {
                    Logs.WriteLog(ex.Message);
                    Logs.WriteLog(ex.StackTrace);
                }
                finally { }
            }
        }

        private void CheckUsingVPN()
        {
            // https://sofiamedix.atlassian.net/browse/MED-10889
            if (UserInfo.VpnYn && VPNHelpers.IsVPNRunning() == false)
            {
                string msg = XMsg.GetMsg("MSG022");
                string cap = XMsg.GetField("F018");

                // Do you want to download and install VPN client?
                if (XMessageBox.Show(msg, cap, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FormDownloadVPN frm = new FormDownloadVPN();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(this);

                    // Brings all pop-up to font
                    this.SendToBack();
                }
            }
        }

        #endregion

        #region DeleteCache
        private void DeleteCache()
        {
            string strCmdText = @"/C rundll32 dfshim CleanOnlineAppCache";
            System.Diagnostics.ProcessStartInfo myProcessInfo = new System.Diagnostics.ProcessStartInfo(); //Initializes a new ProcessStartInfo of name myProcessInfo
            myProcessInfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe"; //Sets the FileName property of myProcessInfo to %SystemRoot%\System32\cmd.exe where %SystemRoot% is a system variable which is expanded using Environment.ExpandEnvironmentVariables
            myProcessInfo.Arguments = strCmdText; //Sets the arguments to cd..            
            myProcessInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; //Sets the WindowStyle of myProcessInfo which indicates the window state to use when the process is started to Hidden
            System.Diagnostics.Process.Start(myProcessInfo);
        }
        #endregion
    }
}