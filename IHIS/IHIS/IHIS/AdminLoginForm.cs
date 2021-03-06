using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
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
//
using IHIS.Framework;

namespace IHIS
{
    /// <summary>
    /// AdminLoginForm에 대한 요약 설명입니다.
    /// </summary>
    [Obsolete("This form is obsolete. See LoginForm instead.")]
    internal class AdminLoginForm : System.Windows.Forms.Form
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

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public AdminLoginForm()
        {
            try
            {
                CloudService.Instance.Connect();
            }
            catch
            {
                throw new Exception("Cannot connect to server!");
            }

            //
            // Windows Form 디자이너 지원에 필요합니다.
            //
            InitializeComponent();

            //
            // TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
            //

            //공통 Login Image로 BackgroundImage 설정
            if (!this.DesignMode)
                SetBackgroundImage();
        }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLoginForm));
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPswd = new System.Windows.Forms.TextBox();
            this.btnOK = new IHIS.XPButton();
            this.btnCancel = new IHIS.XPButton();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.lbMsg = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.lbMsg.ForeColor = System.Drawing.Color.IndianRed;
            this.lbMsg.Name = "lbMsg";
            // 
            // lbTitle
            // 
            this.lbTitle.AccessibleDescription = null;
            this.lbTitle.AccessibleName = null;
            resources.ApplyResources(this.lbTitle, "lbTitle");
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.ForeColor = System.Drawing.Color.White;
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
            // AdminLoginForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = global::IHIS.Properties.Resources.AdminLoginForm;
            this.CancelButton = this.btnCancel;
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.chkSave);
            this.Controls.Add(this.txtPswd);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = null;
            this.Name = "AdminLoginForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            //추후 사용자 TABLE 확정후 사용자 ID 비밀번호 CHECK 확인 Logic 추가
            if (txtUserID.Text.Trim() == "")
            {
                lbMsg.Text = XMsg.GetMsg("M001"); // 사용자ID가 입력되지 않았습니다.
                txtUserID.Focus();
                return;
            }
            if (txtPswd.Text.Trim() == "")
            {
                lbMsg.Text = XMsg.GetMsg("M002"); // 비밀번호가 입력되지 않았습니다."
                txtPswd.Focus();
                return;
            }

            //사용자ID,비밀번호 Check
            if (!CheckAdminUser())
                return;


            //Registry이 ADMIN = Y 하루동안 Check하지 않음 이면 NoCheck Y, 아니면 N, 
            //LoginTime에 현재날짜 SET
            /*RegistryKey rkey = Registry.LocalMachine;
            RegistryKey rkey1 = rkey.OpenSubKey("SOFTWARE\\IHIS\\USER", true);
            if (rkey1 != null)
            {
                rkey1.SetValue("ADMIN", "Y");
                rkey1.SetValue("LoginTime", DateTime.Now.ToString("yyyyMMdd"));
                if (this.chkSave.Checked)
                    rkey1.SetValue("NoCheck", "Y");
                else
                    rkey1.SetValue("NoCheck", "N");
                rkey1.Close();
            }*/

            CacheService.Instance.Set(Constants.CacheKeyCbo.CACHE_COMMON_ADMIN_YN, "Y", TimeSpan.MaxValue);
            CacheService.Instance.Set(Constants.CacheKeyCbo.CACHE_COMMON_ADMIN_LOGIN_TIME, DateTime.Now.ToString("yyyyMMdd"), TimeSpan.MaxValue);
            string chkSaveValue = "N";
            if (this.chkSave.Checked)
                chkSaveValue = "Y";
            CacheService.Instance.Set(Constants.CacheKeyCbo.CACHE_COMMON_ADMIN_NO_CHECK, chkSaveValue, TimeSpan.MaxValue);
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #region CheckAdminUser
        private bool CheckAdminUser()
        {
            this.lbMsg.Text = "";

            //ADM3200의 USER_GROUP이 Admin인지 여부 Check, 사용자 ID, 비밀번호 Check
            //<ORACLE>
            // TODO comment use connect cloud
            /*string cmdText 
                = "SELECT USER_SCRT, USER_GROUP, DECODE(USER_END_YMD, NULL,'Y','N') USE_YN "
                + "  FROM ADM3200 "
                + " WHERE USER_ID ='" + this.txtUserID.Text + "'";*/
            CheckAdminUserArgs vCheckAdminUserArgs = new CheckAdminUserArgs();
            vCheckAdminUserArgs.UserId = this.txtUserID.Text;
            CheckAdminUserResult result = CloudService.Instance.Submit<CheckAdminUserResult, CheckAdminUserArgs>(vCheckAdminUserArgs);
            /*
            //<MYSQL>
            string cmdText
                = "SELECT USER_SCRT, USER_GROUP, (CASE IFNULL(USER_END_YMD,'X') WHEN 'X' THEN 'Y' ELSE 'N' END) USE_YN "
                + "  FROM ADM3200 "
                + " WHERE USER_ID ='" + this.txtUserID.Text + "'";
            */
            //			DataTable table = Service.ExecuteDataTable(cmdText);
            DataTable table = new DataTable();

            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                table = Utility.ConvertToDataTable(result.UserInfo);
            }
            if (table.Rows.Count < 1) //사용자 ID 잘못 입력
            {
                lbMsg.Text = XMsg.GetMsg("M003"); // 사용자ID를 잘못 입력하셨습니다."
                return false;
            }
            string scrt = table.Rows[0][0].ToString();
            string group = table.Rows[0][1].ToString();
            string useYn = table.Rows[0][2].ToString();
            if (useYn == "N")
            {
                lbMsg.Text = XMsg.GetMsg("M004"); // 시스템 사용이 종료되었습니다."
                return false;
            }
            if (scrt != this.txtPswd.Text)
            {
                lbMsg.Text = XMsg.GetMsg("M005"); // 비밀번호를 잘못 입력하셨습니다."
                return false;
            }
            if (group != "ADMIN")  //Admin Group이 아니면 Admin 로그인 불가
            {
                lbMsg.Text = XMsg.GetMsg("M006"); // 시스템 관리자가 아닙니다."
                return false;
            }
            return true;
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
            if (CacheService.Instance.IsSet(Constants.CacheKeyCbo.CACHE_COMMON_ID))
            {
                this.txtUserID.Text = CacheService.Instance.Get(Constants.CacheKeyCbo.CACHE_COMMON_ID, "").ToString();
                //Focus는 Pswd에 SET (Post로 Call)
                PostCallHelper.PostCall(new PostMethod(SetFocus));
            }
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
            if (txtUserID.Text.Length == 7)
            //if (txtUserID.Text.Length == 10) // updated by Cloud
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
                string fileName = Application.StartupPath + "\\Images\\Login.gif";
                if (File.Exists(fileName))
                {
                    Bitmap backImg = Image.FromFile(fileName) as Bitmap;
                    this.BackgroundImage = backImg;
                    //Bitmap TransParent (테두리가 TransParent이므로 적용안함)
                    Color tColor = backImg.GetPixel(0, 0);
                    backImg.MakeTransparent(tColor);

                    //Size 설정 (MaxSize도 고정)
                    this.ClientSize = backImg.Size;
                    this.MaximumSize = backImg.Size;

                    //Form의 Region 설정
                    this.Region = new Region(CalculateGraphicsPath(backImg));

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
            this.btnOK.Text = XMsg.GetField("F001"); // 확 인" : "ログイン");
            this.btnCancel.Text = XMsg.GetField("F002"); // 취 소" : "キャンセル");
            this.chkSave.Text = XMsg.GetField("F003"); // 하루동안 체크하지 않음" : "一日間、チェックしていない");
            this.lbTitle.Text = XMsg.GetField("F004"); // ADMIN 로그인" : "ADMIN ログイン");
        }

    }
}