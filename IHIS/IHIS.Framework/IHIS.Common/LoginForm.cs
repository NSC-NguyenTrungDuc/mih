using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices; // For Marshal
using System.Data;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using Microsoft.Win32;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace IHIS.Framework
{
    /// <summary>
    /// Form1에 대한 요약 설명입니다.
    /// </summary>
    internal class LoginForm : System.Windows.Forms.Form
    {
        private string systemID = "";
        private IHIS.Framework.XButton btnConfirm;
        private IHIS.Framework.XButton btnClose;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.Label lbSystem;
        private System.Windows.Forms.Label lbTitle;
        private XComboBox cboGwa;

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public LoginForm(string systemID, string systemName)
        {
            //Thread.CurrentThread.CurrentCulture = XLocalizable.CultureInfo;
            //Thread.CurrentThread.CurrentUICulture = XLocalizable.CultureInfo;
            InitializeComponent();
            this.systemID = systemID;
            this.lbSystem.Text = systemName;
            SetControlTextByLangMode();

            //공통 Login Image로 BackgroundImage 설정
            if (!this.DesignMode)
                EnvironInfo.SetBackgroundImage(this);

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

        #region Windows Form Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.lbMsg = new System.Windows.Forms.Label();
            this.btnConfirm = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.lbSystem = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.cboGwa = new IHIS.Framework.XComboBox();
            this.SuspendLayout();
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
            // btnConfirm
            // 
            this.btnConfirm.AccessibleDescription = null;
            this.btnConfirm.AccessibleName = null;
            resources.ApplyResources(this.btnConfirm, "btnConfirm");
            this.btnConfirm.BackgroundImage = null;
            this.btnConfirm.Font = null;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleDescription = null;
            this.btnClose.AccessibleName = null;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackgroundImage = null;
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = null;
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
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
            // lbTitle
            // 
            this.lbTitle.AccessibleDescription = null;
            this.lbTitle.AccessibleName = null;
            resources.ApplyResources(this.lbTitle, "lbTitle");
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Name = "lbTitle";
            // 
            // cboGwa
            // 
            this.cboGwa.AccessibleDescription = null;
            this.cboGwa.AccessibleName = null;
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.BackgroundImage = null;
            this.cboGwa.Font = null;
            this.cboGwa.Name = "cboGwa";
            // 
            // LoginForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.btnClose;
            this.ControlBox = false;
            this.Controls.Add(this.cboGwa);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbSystem);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lbMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            if (CloudService.Instance.Connect())
            {
                base.OnLoad(e);

                LoadComboGwa();

                //사용자 ID Registry에서 GET
                //Registry에 ID가 등록되어있으면 ID Display(CheckBox:checked)
                /*RegistryKey rkey = Registry.LocalMachine;

                RegistryKey rkey1 = rkey.OpenSubKey("SOFTWARE\\IHIS\\USER\\" + this.systemID);
                if (rkey1 == null)
                {
                    rkey1 = rkey.CreateSubKey("SOFTWARE\\IHIS\\USER\\" + this.systemID);
                }*/
                object retVal =
                    CacheService.Instance.Get(Constants.CacheKeyCbo.CACHE_COMMON_USER_PREFIX + this.systemID + ".ID",
                        null);
                /*if (rkey1.GetValue("ID") != null)*/
                if (retVal != null)
                {
                    /*this.txtUserID.Text = rkey1.GetValue("ID").ToString();*/
                    //this.txtUserID.Text = retVal.ToString();
                    //this.chkSaveID.Checked = true;
                    //Focus는 Pswd에 SET (Post로 Call)
                    PostCallHelper.PostCall(new PostMethod(SetFocus));
                }
                else
                {
                    //this.chkSaveID.Checked = false;
                }
                /*rkey1.Close();*/
            }
            else
            {
                MessageBox.Show("Cannot connect to server");
            }
        }
        private void SetFocus()
        {
            //this.txtPswd.Focus();
        }
        #endregion


        /// <summary>
        /// 확인 버튼 클릭시
        /// </summary>
        private void btnConfirm_Click(object sender, System.EventArgs e)
        {
            //if (txtUserID.Text == "")
            //{
            //    lbMsg.Text = XMsg.GetMsg("M001"); // 사용자ID가 입력되지 않았습니다." : "ユーザーＩＤを入力したください。");
            //    txtUserID.Focus();
            //    return;
            //}
            //if (txtPswd.Text == "")
            //{
            //    lbMsg.Text = XMsg.GetMsg("M002"); // 비밀번호가 입력되지 않았습니다." : "パスワードを入力してください。");
            //    txtPswd.Focus();
            //    return;
            //}

            lbMsg.Text = "";

            //2010.07.07 kimminsoo 
            //<gwa_list> 과리스트 선택 기능이 있으면 진료과 선택여부 확인하고 userID를 선택된 과의 doctorID로 setting
            //string userID = this.txtUserID.Text;
            string userID = UserInfo.UserID;
            if (cboGwa.Visible)
            {
                if (this.cboGwa.SelectedIndex < 0)
                {
                    lbMsg.Text = XMsg.GetMsg("M009"); //진료과를 선택해 주세요.
                    this.cboGwa.Focus();
                    return;
                }
                //선택된 과의 의사ID로 UserID setting ( combo 구성을 valueItem = DoctorID, DisplayItem=진료과명 으로 구성 )
                userID = cboGwa.GetDataValue();
            }

            string errMsg = "";

            if (cboGwa.Visible)
            {
                //20101213 KIMMINSOO 수정
                string gwa = userID.Substring(0, 2);
                string gwaName = "";

                /*string cmdStr = "SELECT A.GWA_NAME"
                                + "  FROM BAS0260 A"
                                + " WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'"
                                + "   AND A.GWA   = '" + gwa + "'"
                                + "   AND SYSDATE BETWEEN A.START_DATE AND A.END_DATE";

                object retVal = Service.ExecuteScalar(cmdStr);

                if (!TypeCheck.IsNull(retVal))
                {
                    gwaName = retVal.ToString();
                }

                //사용자 정보 Check 실패시 return
                if (!UserInfoUtil.CheckUserDoctor(this.systemID, this.txtUserID.Text, this.txtPswd.Text, gwa, gwaName, out errMsg))
                {
                    lbMsg.Text = errMsg;
                    this.txtUserID.Focus();
                    return;
                }*/

                // Cloud service
                CheckUserDoctorLoginArgs userDoctorLoginArgs = new CheckUserDoctorLoginArgs();
                userDoctorLoginArgs.Gwa = gwa;
                userDoctorLoginArgs.UserInfo = new UserRequestInfo();
                userDoctorLoginArgs.UserInfo.SysId = systemID.Trim();
                //userDoctorLoginArgs.UserInfo.UserId = txtUserID.Text.Trim();
                userDoctorLoginArgs.UserInfo.UserId = UserInfo.UserID;
                //userDoctorLoginArgs.UserInfo.UserScrt = txtPswd.Text;
                userDoctorLoginArgs.UserInfo.UserScrt = UserInfo.UserPswd;
                userDoctorLoginArgs.UserInfo.ScrtCheckYn = "Y";
                userDoctorLoginArgs.UserInfo.IpAddr = Service.ClientIP;
                CheckUserDoctorLoginResult userDoctorLoginResult =
                    CloudService.Instance.Submit<CheckUserDoctorLoginResult, CheckUserDoctorLoginArgs>(
                        userDoctorLoginArgs);
                if (!TypeCheck.IsNull(userDoctorLoginResult.GwaName))
                {
                    gwaName = userDoctorLoginResult.GwaName;
                }
                //if (!UserInfoUtil.CheckUserDoctor(this.txtUserID.Text, this.txtPswd.Text, gwa, gwaName, userDoctorLoginResult, out errMsg))
                if (!UserInfoUtil.CheckUserDoctor(UserInfo.UserID, UserInfo.UserPswd, gwa, gwaName, userDoctorLoginResult, out errMsg))
                {
                    lbMsg.Text = errMsg;
                    //this.txtUserID.Focus();
                    return;
                }
            }
            else
            {
                //사용자 정보 Check 실패시 return


                /*string cmd = @"SELECT FN_OCS_GET_SUBPART_DOCTOR('" + EnvironInfo.HospCode + "', '" + this.txtUserID.Text + "', '" + this.systemID + "') FROM SYS.DUAL";
                object obj = Service.ExecuteScalar(cmd);
                
                // 部門システムのIDが存在したら部門IDを優先してログインをする。
                // ドクターのみ
                if (obj.ToString() != "NULL")
                {
                    if (!UserInfoUtil.CheckUser(this.systemID, obj.ToString(), this.txtPswd.Text, out errMsg))
                    {
                        lbMsg.Text = errMsg;
                        this.txtUserID.Focus();
                        return;
                    }
                }
                else
                {
                    if (!UserInfoUtil.CheckUser(this.systemID, this.txtUserID.Text, this.txtPswd.Text, out errMsg))
                    {
                        lbMsg.Text = errMsg;
                        this.txtUserID.Focus();
                        return;
                    }
                }*/

                //// Cloud service
                //CheckUserLoginArgs userLoginArgs = new CheckUserLoginArgs();
                //userLoginArgs.UserId = this.txtUserID.Text;
                //userLoginArgs.SystemId = this.systemID;
                //userLoginArgs.UserInfo = new UserRequestInfo();
                //userLoginArgs.UserInfo.SysId = systemID.Trim();
                //userLoginArgs.UserInfo.UserId = txtUserID.Text.Trim();
                //userLoginArgs.UserInfo.UserScrt = txtPswd.Text;
                //userLoginArgs.UserInfo.ScrtCheckYn = "Y";
                //userLoginArgs.UserInfo.IpAddr = Service.ClientIP;
                //CheckUserLoginResult userLoginResult =
                //    CloudService.Instance.Submit<CheckUserLoginResult, CheckUserLoginArgs>(userLoginArgs);
                //if (userLoginResult.SubPartDoctor != "NULL")
                //{
                //    if (!UserInfoUtil.CheckUser(userLoginResult.SubPartDoctor, this.txtPswd.Text, userLoginResult, out errMsg))
                //    {
                //        lbMsg.Text = errMsg;
                //        this.txtUserID.Focus();
                //        return;
                //    }
                //}
                //else
                //{
                //    if (!UserInfoUtil.CheckUser(this.txtUserID.Text, this.txtPswd.Text, userLoginResult, out errMsg))
                //    {
                //        lbMsg.Text = errMsg;
                //        this.txtUserID.Focus();
                //        return;
                //    }
                //}
            }

            //시스템 사용자 진입 등록
            UserInfoUtil.RegisterSystemUser(this.systemID, UserInfo.UserID);

            //ID 저장시 Registry에 SET
            //ID 저장시 Registry에 SET
            //UserInfoUtil.SetSystemUserToRegistry(this.systemID, UserInfo.UserID, this.chkSaveID.Checked);

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 비밀번호 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChngPswd_Click(object sender, System.EventArgs e)
        {
            ////사용자 입력여부 확인
            //if (this.txtUserID.Text.Trim() == "")
            //{
            //    lbMsg.Text = XMsg.GetMsg("M001"); // 사용자ID가 입력되지 않았습니다."
            //    txtUserID.Focus();
            //    return;
            //}
            //ChangePswdForm dlg = new ChangePswdForm(this.txtUserID.Text.Trim());
            //dlg.ShowDialog();
            //dlg.Dispose();
        }

        /// <summary>
        /// 비밀번호에서 Enter Key를 눌렀을때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPswd_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //try
            //{
            //    if (e.KeyChar == (char)13)
            //    {
            //        if (this.txtPswd.Text.Length > 0)
            //        {
            //            this.btnConfirm.PerformClick(); //확인 처리
            //        }
            //    }
            //}
            //catch (Exception exxx)
            //{
            //    MessageBox.Show("d" + exxx.Message);
            //    MessageBox.Show("d" + exxx.StackTrace);

            //}
        }

        #region WndProc
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == (int)Win32.Msgs.WM_NCHITTEST)
                msg.Result = new IntPtr(2); //Hit Caption
            else
                base.WndProc(ref msg);
        }
        #endregion

        //일본어, 한글 모드에 따른 Text 설정
        private void SetControlTextByLangMode()
        {
            this.btnClose.Text = XMsg.GetField("F001"); // 취소 
            this.btnConfirm.Text = XMsg.GetField("F002"); //  확 인
            //this.btnChngPswd.Text = XMsg.GetField("F003"); // 비밀번호변경" : "バスワード変更");
            //this.chkSaveID.Text = XMsg.GetField("F004"); // ID 저장" : "ＩＤ保存");
            this.lbTitle.Text = XMsg.GetField("F005"); // 사용자 LOGIN" : "ユーザーログイン");
        }

        /* 2010.07.07 kimminsoo
         * okinawa 기준의 과선택 추가
         * C:\IHIS\bin\IHIS.config 파일에 <DOCTOC_GWA_LIST_AT_LOGIN SHOW="Y"> 와 같이 등록하여 관리.
         * EnvironInfo.ShowDoctorGwaListAtLogin = true/false 설정
         * config xml file 에 ShowingSystemList 로 진료과 선택 기능이 필요한 시스템을 등록
         * EnvironInfo.GwaListShowingSystemList 에서 참조할 수 있도록 처리
         * 
         *  config file ex
         * 
         *  <DOCTOR_GWA_LIST_AT_LOGIN SHOW="Y">
         *    <ShowingSystemID>OCSI</ShowingSystemID>
         *    <ShowingSystemID>OCS0</ShowingSystemID>
         *  </DOCTOR_GWA_LIST_AT_LOGIN>
         * 
         */
        private void txtUserID_DataValidating(object sender, DataValidatingEventArgs e)
        {
            //진료과 선택 기능이 없을 경우, return
            if (!EnvironInfo.ShowDoctorGwaListAtLogin) return;
            //과 리스트 선택 기능이 없을 경우
            if (!EnvironInfo.GwaListShowingSystemList.Contains(this.systemID)) return;

            //최초 과콤보 visible false
            this.cboGwa.Visible = false;

            //입력된 UserID로 진료과정보 LIST 조회
            ArrayList gwaInfoList = new ArrayList(); //Output으로 받을 DoctorGwaInfo class List
            string errMsg = "";
            //과정보 조회 실패시 에러
            if (!UserInfoUtil.GetDocotorGwaList(e.DataValue, gwaInfoList, out errMsg))
            {
                XMessageBox.Show(errMsg);
                e.Cancel = true;
                return;
            }
            //콤보구성
            this.cboGwa.ResetData();
            this.cboGwa.ComboItems.Clear();
            foreach (DoctorGwaInfo info in gwaInfoList)
            {
                //Value = 의사ID, Display = 진료과명
                cboGwa.ComboItems.Add(info.DoctorID, info.GwaName);
            }
            cboGwa.RefreshComboItems();

            cboGwa.Visible = true;
            cboGwa.SelectedIndex = 0;
        }

        private void LoadComboGwa()
        {
            //진료과 선택 기능이 없을 경우, return
            if (!EnvironInfo.ShowDoctorGwaListAtLogin) return;
            //과 리스트 선택 기능이 없을 경우
            if (!EnvironInfo.GwaListShowingSystemList.Contains(this.systemID)) return;

            //최초 과콤보 visible false
            this.cboGwa.Visible = false;

            //입력된 UserID로 진료과정보 LIST 조회
            ArrayList gwaInfoList = new ArrayList(); //Output으로 받을 DoctorGwaInfo class List
            string errMsg = "";
            //과정보 조회 실패시 에러
            if (!UserInfoUtil.GetDocotorGwaList(UserInfo.UserID, gwaInfoList, out errMsg))
            {
                XMessageBox.Show(errMsg);
                return;
            }
            //콤보구성
            this.cboGwa.ResetData();
            this.cboGwa.ComboItems.Clear();
            foreach (DoctorGwaInfo info in gwaInfoList)
            {
                //Value = 의사ID, Display = 진료과명
                cboGwa.ComboItems.Add(info.DoctorID, info.GwaName);
            }
            cboGwa.RefreshComboItems();

            cboGwa.Visible = true;
            cboGwa.SelectedIndex = 0;
        }
    }
}
