using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;
using System.Text;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Utility;
using System.Text.RegularExpressions;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using System.Diagnostics;


namespace IHIS.Framework
{
    /// <summary>
    /// Form1에 대한 요약 설명입니다.
    /// </summary>
    public class ChangePswdForm : System.Windows.Forms.Form
    {
        //UserID 
        private string userID = "";
        private IHIS.Framework.XButton btnConfirm;
        private IHIS.Framework.XButton btnClose;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbOldPswd;
        private System.Windows.Forms.Label lbNewPswd;
        private System.Windows.Forms.Label lbCnfmPswd;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox picpoc;
        private Label labpicpoc;
        private XTextBox txtCnfmPswd;
        private XTextBox txtNewPswd;
        private XTextBox txtOldPswd;

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public ChangePswdForm(string userID)
        {
            // updated by Cloud
            CloudService.Instance.Connect();

            InitializeComponent();

            // MED-14286
            if (NetInfo.Language != LangMode.Jr)
            {
                this.Font = Service.COMMON_FONT;
                this.lbTitle.Font = new Font("Arial", 11.75f, FontStyle.Bold);
            }

            this.userID = userID;

            SetControlTextByLangMode();

            //공통 Login Image로 BackgroundImage 설정
            if (!this.DesignMode)
                EnvironInfo.SetBackgroundImage(this);
        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbMsg = new System.Windows.Forms.Label();
            this.btnConfirm = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbOldPswd = new System.Windows.Forms.Label();
            this.lbNewPswd = new System.Windows.Forms.Label();
            this.lbCnfmPswd = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picpoc = new System.Windows.Forms.PictureBox();
            this.labpicpoc = new System.Windows.Forms.Label();
            this.txtCnfmPswd = new IHIS.Framework.XTextBox();
            this.txtNewPswd = new IHIS.Framework.XTextBox();
            this.txtOldPswd = new IHIS.Framework.XTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picpoc)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMsg
            // 
            this.lbMsg.BackColor = System.Drawing.Color.Transparent;
            this.lbMsg.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMsg.ForeColor = System.Drawing.Color.IndianRed;
            this.lbMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbMsg.Location = new System.Drawing.Point(24, 241);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(324, 49);
            this.lbMsg.TabIndex = 0;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(106, 306);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(72, 32);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "확 인";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(184, 306);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnClose.Size = new System.Drawing.Size(72, 32);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "취 소";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbTitle.Location = new System.Drawing.Point(102, 54);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(186, 24);
            this.lbTitle.TabIndex = 9;
            this.lbTitle.Text = "lbTitle";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbOldPswd
            // 
            this.lbOldPswd.BackColor = System.Drawing.Color.Transparent;
            this.lbOldPswd.Location = new System.Drawing.Point(12, 110);
            this.lbOldPswd.Name = "lbOldPswd";
            this.lbOldPswd.Size = new System.Drawing.Size(152, 19);
            this.lbOldPswd.TabIndex = 12;
            this.lbOldPswd.Text = "이전비밀번호";
            this.lbOldPswd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNewPswd
            // 
            this.lbNewPswd.BackColor = System.Drawing.Color.Transparent;
            this.lbNewPswd.Location = new System.Drawing.Point(12, 143);
            this.lbNewPswd.Name = "lbNewPswd";
            this.lbNewPswd.Size = new System.Drawing.Size(152, 19);
            this.lbNewPswd.TabIndex = 13;
            this.lbNewPswd.Text = "신규비밀번호";
            this.lbNewPswd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCnfmPswd
            // 
            this.lbCnfmPswd.BackColor = System.Drawing.Color.Transparent;
            this.lbCnfmPswd.Location = new System.Drawing.Point(12, 199);
            this.lbCnfmPswd.Name = "lbCnfmPswd";
            this.lbCnfmPswd.Size = new System.Drawing.Size(152, 19);
            this.lbCnfmPswd.TabIndex = 14;
            this.lbCnfmPswd.Text = "확인비밀번호";
            this.lbCnfmPswd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IHIS.Framework.Properties.Resources.icon_kc_bg;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 18);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::IHIS.Framework.Properties.Resources.icon_look_bg;
            this.pictureBox2.Location = new System.Drawing.Point(75, 54);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 20);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // picpoc
            // 
            this.picpoc.Location = new System.Drawing.Point(169, 170);
            this.picpoc.Name = "picpoc";
            this.picpoc.Size = new System.Drawing.Size(158, 3);
            this.picpoc.TabIndex = 17;
            this.picpoc.TabStop = false;
            this.picpoc.Visible = false;
            // 
            // labpicpoc
            // 
            this.labpicpoc.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labpicpoc.Location = new System.Drawing.Point(169, 179);
            this.labpicpoc.Name = "labpicpoc";
            this.labpicpoc.Size = new System.Drawing.Size(158, 13);
            this.labpicpoc.TabIndex = 18;
            // 
            // txtCnfmPswd
            // 
            this.txtCnfmPswd.EnterKeyToTab = false;
            this.txtCnfmPswd.Location = new System.Drawing.Point(169, 198);
            this.txtCnfmPswd.MaxLength = 15;
            this.txtCnfmPswd.Name = "txtCnfmPswd";
            this.txtCnfmPswd.PasswordChar = '*';
            this.txtCnfmPswd.Size = new System.Drawing.Size(158, 20);
            this.txtCnfmPswd.TabIndex = 2;
            this.txtCnfmPswd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCnfmPswd_KeyPress);
            // 
            // txtNewPswd
            // 
            this.txtNewPswd.Location = new System.Drawing.Point(169, 143);
            this.txtNewPswd.MaxLength = 15;
            this.txtNewPswd.Name = "txtNewPswd";
            this.txtNewPswd.PasswordChar = '*';
            this.txtNewPswd.Size = new System.Drawing.Size(158, 20);
            this.txtNewPswd.TabIndex = 1;
            this.txtNewPswd.TextChanged += new System.EventHandler(this.txtNewPswd_TextChanged);
            // 
            // txtOldPswd
            // 
            this.txtOldPswd.Location = new System.Drawing.Point(169, 109);
            this.txtOldPswd.MaxLength = 15;
            this.txtOldPswd.Name = "txtOldPswd";
            this.txtOldPswd.PasswordChar = '*';
            this.txtOldPswd.Size = new System.Drawing.Size(158, 20);
            this.txtOldPswd.TabIndex = 0;
            // 
            // ChangePswdForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::IHIS.Framework.Properties.Resources.form_change_pass_background;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(360, 360);
            this.ControlBox = false;
            this.Controls.Add(this.labpicpoc);
            this.Controls.Add(this.picpoc);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtCnfmPswd);
            this.Controls.Add(this.txtNewPswd);
            this.Controls.Add(this.lbCnfmPswd);
            this.Controls.Add(this.lbNewPswd);
            this.Controls.Add(this.lbOldPswd);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.txtOldPswd);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(360, 360);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 360);
            this.Name = "ChangePswdForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picpoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        /// <summary>
        /// 확인 버튼 클릭시
        /// </summary>
        private void btnConfirm_Click(object sender, System.EventArgs e)
        {
            /* 확인 사항
             * 이전비밀번호 입력여부 확인
             * 새 비밀번호, 확인 비밀번호 일치여부 확인 */
            if (this.txtOldPswd.Text.Trim() == "")
            {
                this.lbMsg.Text = XMsg.GetMsg("M001"); // 이전비밀번호를 입력하십시오.
                this.txtOldPswd.Focus();
                return;
            }
            if (this.txtNewPswd.Text.Trim() == "")
            {
                this.lbMsg.Text = XMsg.GetMsg("M002"); // 신규비밀번호를 입력하십시오."
                this.txtNewPswd.Focus();
                return;
            }
            if (this.txtNewPswd.Text.Trim().Length < 8)
            {
                this.lbMsg.Text = XMsg.GetMsg("M083"); 
                this.txtNewPswd.Focus();
                return;
            }
            if (this.txtCnfmPswd.Text.Trim() == "")
            {
                this.lbMsg.Text = XMsg.GetMsg("M003"); // 확인비밀번호를 입력하십시오."
                this.txtCnfmPswd.Focus();
                return;
            }
            if (this.txtNewPswd.Text.Trim() != this.txtCnfmPswd.Text.Trim())
            {
                this.lbMsg.Text = XMsg.GetMsg("M004"); // 신규비밀번호와 확인비밀번호가 일치하지 않습니다."
                this.txtNewPswd.Focus();
                return;
            }
            //Check pass
            string pwdHis = "";
            //int count = 0;

            string[] pwdHistory = UserInfo.PwdHistory.Split('>');
            string latestPsw = pwdHistory[0];
            if (Utility.CreateMd5Hash(txtOldPswd.Text.Trim(), false) != latestPsw)
            {
                // 前回パスワードを入力間違えました。もう一度入力して下さい。
                this.lbMsg.Text = XMsg.GetMsg("M084");
                this.txtOldPswd.Focus();

                // Update cache to lock account
                AttemptTime at = CacheService.Instance.Get<AttemptTime>(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES);
                int attemptCnt = at.GetAttemptChangePass(UserInfo.UserID) + 1;
                at.SetAttemptChangePass(UserInfo.UserID, attemptCnt);
                CacheService.Instance.Set(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES, at, TimeSpan.MaxValue);

                // Wrong password over 5 times?
                if (at.GetAttemptChangePass(UserInfo.UserID) > 5)
                {
                    // Update to lock account
                    FwUserInfoChangePswArgs args = new FwUserInfoChangePswArgs();
                    args.HospCode = ""; // Get from server
                    args.UserId = UserInfo.UserID;
                    args.OldPassword = "";
                    args.NewPassword = "";
                    args.Attempt = at.GetAttemptChangePass(UserInfo.UserID);
                    args.PwdHistory = "";
                    UpdateResult res = CloudService.Instance.Submit<UpdateResult, FwUserInfoChangePswArgs>(args);
                }

                return;
            }

            if (pwdHistory.Length == 3)
            {
                if(Utility.CreateMd5Hash(txtNewPswd.Text.Trim(),false) == pwdHistory[0])
                {
                    // 新規パスワードは前回パスワードと重複してはいけません。もう一度入力して下さい。
                    this.lbMsg.Text = XMsg.GetMsg("M081"); 
                    this.txtNewPswd.Focus();
                    return;
                }
                else if (Utility.CreateMd5Hash(txtNewPswd.Text.Trim(), false) == pwdHistory[1])
                {
                    // 新規パスワードは最近使用した ３つのパスワードと異なる必要があります。
                    this.lbMsg.Text = XMsg.GetMsg("M082"); 
                    this.txtNewPswd.Focus();
                    return;
                }
                else if (Utility.CreateMd5Hash(txtNewPswd.Text.Trim(), false) == pwdHistory[2])
                {
                    // 新規パスワードは最近使用した ３つのパスワードと異なる必要があります。
                    this.lbMsg.Text = XMsg.GetMsg("M082");
                    this.txtNewPswd.Focus();
                    return;
                }
                else
                { 
                    pwdHis = Utility.CreateMd5Hash(txtNewPswd.Text.Trim(),false) + ">" + UserInfo.PwdHistory.Remove(UserInfo.PwdHistory.IndexOf(">",UserInfo.PwdHistory.IndexOf(">")  +1));
                }
            }

            if (pwdHistory.Length == 2)
            {
                //string[] pwdHistory = UserInfo.PwdHistory.Split('>');
                if(Utility.CreateMd5Hash(txtNewPswd.Text.Trim(),false) == pwdHistory[0])
                {
                    // 新規パスワードは前回パスワードと重複してはいけません。もう一度入力して下さい。
                    this.lbMsg.Text = XMsg.GetMsg("M081"); 
                    this.txtNewPswd.Focus();
                    return;
                }
                else if (Utility.CreateMd5Hash(txtNewPswd.Text.Trim(), false) == pwdHistory[1])
                {
                    // 新規パスワードは最近使用した ３つのパスワードと異なる必要があります。
                    this.lbMsg.Text = XMsg.GetMsg("M082"); 
                    this.txtNewPswd.Focus();
                    return;
                }
                else
                {
                    pwdHis = Utility.CreateMd5Hash(txtNewPswd.Text.Trim(), false) + ">" + UserInfo.PwdHistory;
                }
                
            }

            if (pwdHistory.Length == 1)
            {
                //string pwdHistory = UserInfo.PwdHistory;
                if(Utility.CreateMd5Hash(txtNewPswd.Text.Trim(),false) == pwdHistory[0])
                {
                    // 新規パスワードは前回パスワードと重複してはいけません。もう一度入力して下さい。
                    this.lbMsg.Text = XMsg.GetMsg("M081"); 
                    this.txtNewPswd.Focus();
                    return;
                }
                else
                {
                    pwdHis = Utility.CreateMd5Hash(txtNewPswd.Text.Trim(),false) + ">" + UserInfo.PwdHistory;
                }
            }
            lbMsg.Text = "";

            string errMsg = "";

            //AttemptTime lstAttemptTime = new AttemptTime();
            //if (!CacheService.Instance.IsSet(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES))
            //{
            //    CacheService.Instance.Set(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES, lstAttemptTime, TimeSpan.MaxValue);
            //}

            AttemptTime lstAttemptTime = CacheService.Instance.Get<AttemptTime>(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES);
            if (!lstAttemptTime.ContainsUser(UserInfo.UserID))
            {
                UserAttemptTime user = new UserAttemptTime();
                user.UserId = UserInfo.UserID;
                user.AttemptTimes = 0;
                user.LockedTime = DateTime.MinValue;
                lstAttemptTime.LstAttempt.Add(user);
                user.AttemptChangePass = 0;
                CacheService.Instance.Set(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES, lstAttemptTime, TimeSpan.MaxValue);
            }
            int attemptChangePass = lstAttemptTime.GetAttemptChangePass(UserInfo.UserID);
            //사용자 정보 Check 실패시 return
            if (!UserInfoUtil.ChangePassword(this.userID, this.txtOldPswd.Text, this.txtNewPswd.Text, pwdHis, attemptChangePass, out errMsg))
            {
                lbMsg.Text = errMsg;
                this.txtOldPswd.Focus();
                attemptChangePass = lstAttemptTime.GetAttemptChangePass(UserInfo.UserID) + 1;
                lstAttemptTime.SetAttemptChangePass(UserInfo.UserID, attemptChangePass);
                if (attemptChangePass >= Constants.SecurityLogin.MAX_ATTEMPT_TIMES)
                {
                    CacheService.Instance.Set(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES, lstAttemptTime, TimeSpan.MaxValue);
                    return;
                }
                else
                {
                    CacheService.Instance.Set(Constants.SecurityLogin.CACHE_ATTEMPT_TIMES, lstAttemptTime, TimeSpan.MaxValue);
                }

                return;
            }
            else
            {
                // Change password succeeded: update password
                UserInfo.UserPswd = Utility.CreateMd5Hash(txtNewPswd.Text, false);
            }
            
            this.DialogResult = DialogResult.OK;
        }
        // password strength
        private int pwdStrength(string pwd)
        {
            int score = 1;
            if (Regex.IsMatch(pwd, @"^(?=.*[a-z])", RegexOptions.ECMAScript) && Regex.IsMatch(pwd, @"[0-9]+(\.[0-9][0-9]?)?", RegexOptions.ECMAScript)) //both, lower and upper case
                score++;
            if (Regex.IsMatch(pwd, @"^(?=.*[A-Z])", RegexOptions.ECMAScript)) //both, lower and upper case
                score++;
            if (Regex.IsMatch(pwd, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript)) //^[A-Z]+$
                score++;
            return score;
        }

        /// <summary>
        /// 비밀번호에서 Enter Key를 눌렀을때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void txtCnfmPswd_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if ((this.txtOldPswd.Text.Length > 0) && (this.txtNewPswd.Text.Length > 0))
                {
                    this.btnConfirm.PerformClick(); //확인 처리
                }
            }
        }

        #region WndProc
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == (int) Win32.Msgs.WM_NCHITTEST)
                msg.Result = new IntPtr(2); //Hit Caption
            else
                base.WndProc(ref msg);
        }
        #endregion

        //일본어, 한글 모드에 따른 Text 설정
        private void SetControlTextByLangMode()
        {
            this.btnClose.Text = XMsg.GetField("F001"); // 취소
            this.btnConfirm.Text = XMsg.GetField("F002"); // 변 경
            this.lbTitle.Text = XMsg.GetField("F003"); // 비밀번호 변경            
            this.lbOldPswd.Text = XMsg.GetField("F004"); // 이전비밀번호
            this.lbNewPswd.Text = XMsg.GetField("F005"); // 신규비밀번호
            this.lbCnfmPswd.Text = XMsg.GetField("F006"); // 확인비밀번호
        }

        private void txtNewPswd_TextChanged(object sender, EventArgs e)
        {
            picpoc.Visible = true;
            int score = pwdStrength(txtNewPswd.Text);
            if (score == 1)
            {
                this.picpoc.Image = global::IHIS.Framework.Properties.Resources.rate_1;
                labpicpoc.Text = "Weak";
                labpicpoc.ForeColor = System.Drawing.ColorTranslator.FromHtml("#c94f22");
            }
            if (score == 2)
            {
                this.picpoc.Image = global::IHIS.Framework.Properties.Resources.rate2;
                labpicpoc.ForeColor = System.Drawing.ColorTranslator.FromHtml("#fcb438");
                labpicpoc.Text = "Good";
            }
            if (score == 3)
            {
                this.picpoc.Image = global::IHIS.Framework.Properties.Resources.rate_3;
                labpicpoc.ForeColor = System.Drawing.ColorTranslator.FromHtml("#acc724");
                labpicpoc.Text = "Strong";
            }
            if (score == 4)
            {
                this.picpoc.Image = global::IHIS.Framework.Properties.Resources.rate_4;
                labpicpoc.ForeColor = System.Drawing.ColorTranslator.FromHtml("#62a115");
                labpicpoc.Text = "Very Strong";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
