using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;
using System.Text;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.Framework.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;

namespace IHIS.Framework
{
    /// <summary>
    /// ChangeUserForm에 대한 요약 설명입니다.
    /// </summary>
    internal class ChangeUserForm : System.Windows.Forms.Form
    {
        private string origUserID = "";
        private bool isEditableUserID = true; //UserID를 변경할 수 있는지 여부
        private IHIS.Framework.XButton btnClose;
        private IHIS.Framework.XButton btnConfirm;
        private System.Windows.Forms.CheckBox chkSaveID;
        private IHIS.Framework.XTextBox txtPswd;
        private IHIS.Framework.XTextBox txtUserID;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private XComboBox cboGwa;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public ChangeUserForm(string userID, bool isEditableUserID)
        {
            //
            // Windows Form 디자이너 지원에 필요합니다.
            //
            InitializeComponent();

            SetControlTextByLangMode();

            //공통 Login Image로 BackgroundImage 설정
            if (!this.DesignMode)
                EnvironInfo.SetBackgroundImage(this);

            //
            // TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
            //
            this.txtUserID.Text = userID;
            this.origUserID = userID;
            this.isEditableUserID = isEditableUserID;
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
            this.btnClose = new IHIS.Framework.XButton();
            this.btnConfirm = new IHIS.Framework.XButton();
            this.chkSaveID = new System.Windows.Forms.CheckBox();
            this.txtPswd = new IHIS.Framework.XTextBox();
            this.txtUserID = new IHIS.Framework.XTextBox();
            this.lbMsg = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboGwa = new IHIS.Framework.XComboBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(218, 214);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnClose.Size = new System.Drawing.Size(72, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "취 소";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(112, 214);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(72, 32);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "확 인";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // chkSaveID
            // 
            this.chkSaveID.BackColor = System.Drawing.Color.Transparent;
            this.chkSaveID.Checked = true;
            this.chkSaveID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkSaveID.Location = new System.Drawing.Point(254, 178);
            this.chkSaveID.Name = "chkSaveID";
            this.chkSaveID.Size = new System.Drawing.Size(104, 24);
            this.chkSaveID.TabIndex = 3;
            this.chkSaveID.Text = "ID 저장";
            this.chkSaveID.UseVisualStyleBackColor = false;
            // 
            // txtPswd
            // 
            this.txtPswd.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.txtPswd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtPswd.Location = new System.Drawing.Point(170, 178);
            this.txtPswd.MaxLength = 10;
            this.txtPswd.Name = "txtPswd";
            this.txtPswd.PasswordChar = '*';
            this.txtPswd.Size = new System.Drawing.Size(80, 21);
            this.txtPswd.TabIndex = 2;
            this.txtPswd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPswd_KeyPress);
            // 
            // txtUserID
            // 
            this.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserID.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.txtUserID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtUserID.Location = new System.Drawing.Point(170, 152);
            this.txtUserID.MaxLength = 10;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(80, 21);
            this.txtUserID.TabIndex = 0;
            this.txtUserID.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtUserID_DataValidating);
            // 
            // lbMsg
            // 
            this.lbMsg.BackColor = System.Drawing.Color.Transparent;
            this.lbMsg.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbMsg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbMsg.Location = new System.Drawing.Point(24, 264);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(330, 18);
            this.lbMsg.TabIndex = 5;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTitle.Location = new System.Drawing.Point(114, 84);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(176, 24);
            this.lbTitle.TabIndex = 10;
            this.lbTitle.Text = "lbTitle";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(47, 152);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(123, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "User ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(104, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Password";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboGwa
            // 
            this.cboGwa.Location = new System.Drawing.Point(254, 152);
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.Size = new System.Drawing.Size(81, 21);
            this.cboGwa.TabIndex = 1;
            this.cboGwa.Visible = false;
            // 
            // ChangeUserForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::IHIS.Framework.Properties.Resources.AdminLoginForm;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(408, 300);
            this.ControlBox = false;
            this.Controls.Add(this.cboGwa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.chkSaveID);
            this.Controls.Add(this.txtPswd);
            this.Controls.Add(this.txtUserID);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(408, 300);
            this.MinimumSize = new System.Drawing.Size(408, 300);
            this.Name = "ChangeUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change User";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //UserID Edit불가이면 txtUserID.ReadOnly true, Focus txtPswd에 SET
            if (!this.isEditableUserID)
            {
                this.txtUserID.ReadOnly = true;
                //Load시 Focus는 PostMessage로 보내야 정확히 작동함.
                PostCallHelper.PostCall(new PostMethod(this.PostPswdFocus));
            }
        }

        private void PostPswdFocus()
        {
            this.txtPswd.Focus();
        }


        private void txtPswd_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (this.txtPswd.Text.Length > 0)
                {
                    this.btnConfirm.PerformClick(); //확인 처리
                }
            }
        }

        private void btnConfirm_Click(object sender, System.EventArgs e)
        {
            if (txtUserID.Text == "")
            {
                lbMsg.Text = XMsg.GetMsg("M005"); // 사용자ID가 입력되지 않았습니다.
                txtUserID.Focus();
                return;
            }
            if (txtPswd.Text == "")
            {
                lbMsg.Text = XMsg.GetMsg("M006"); // 비밀번호가 입력되지 않았습니다.
                txtPswd.Focus();
                return;
            }

            lbMsg.Text = "";

            #region deleted by Cloud
            ////2010.07.07 kimminsoo 
            ////<gwa_list> 과리스트 선택 기능이 있으면 진료과 선택여부 확인하고 userID를 선택된 과의 doctorID로 setting
            //string userID = this.txtUserID.Text;
            //if (cboGwa.Visible)
            //{
            //    if (this.cboGwa.SelectedIndex < 0)
            //    {
            //        lbMsg.Text = XMsg.GetMsg("M009"); //진료과를 선택해 주세요.
            //        this.cboGwa.Focus();
            //        return;
            //    }
            //    //선택된 과의 의사ID로 UserID setting ( combo 구성을 valueItem = DoctorID, DisplayItem=진료과명 으로 구성 )
            //    userID = cboGwa.GetDataValue();
            //}

            //string errMsg = "";

            ////이전과 같은 사용자를 입력하였더라도 사용자변경 LOGIC을 그대로 적용함
            ////같은 사용자라도 이 창을 띄웠으면 새로 LOGIN하는 것과 같은 LOGIC을 적용해야함

            //if (cboGwa.Visible)
            //{
            //    //20101213 KIMMINSOO 수정
            //    string gwa = userID.Substring(0, 2);
            //    string gwaName = "";

            //    //string cmdStr = "SELECT A.GWA_NAME"
            //    //                + "  FROM BAS0260 A"
            //    //                + " WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'"
            //    //                + "   AND A.GWA   = '" + gwa + "'"
            //    //                + "   AND SYSDATE BETWEEN A.START_DATE AND A.END_DATE";

            //    //object retVal = Service.ExecuteScalar(cmdStr);

            //    //if (!TypeCheck.IsNull(retVal))
            //    //{
            //    //    gwaName = retVal.ToString();
            //    //}

            //    // Get default gwa - Cloud team
            //    ArrayList gwaInfoList = new ArrayList();
            //    UserInfoUtil.GetDocotorGwaList(UserInfo.UserID, gwaInfoList, out errMsg);
            //    gwaName = (gwaInfoList[0] as DoctorGwaInfo).GwaName;

            //    //사용자 정보 Check 실패시 return
            //    if (!UserInfoUtil.CheckUserDoctor(EnvironInfo.CurrSystemID, this.txtUserID.Text, this.txtPswd.Text, gwa, gwaName, out errMsg))
            //    {
            //        lbMsg.Text = errMsg;
            //        this.txtUserID.Focus();
            //        return;
            //    }
            //}
            //else
            //{
            //    //사용자 정보 Check 실패시 return
            //    if (!UserInfoUtil.CheckUser(EnvironInfo.CurrSystemID, this.txtUserID.Text, this.txtPswd.Text, out errMsg))
            //    {
            //        lbMsg.Text = errMsg;
            //        this.txtUserID.Focus();
            //        return;
            //    }
            //}
            #endregion

            // 2015.10.23 fixed https://nextop-asia.atlassian.net/browse/MED-4849
            AdmLoginFormCheckLoginUserArgs args = new AdmLoginFormCheckLoginUserArgs();
            args.User = this.txtUserID.Text;
            args.Password = this.txtPswd.Text;
            AdmLoginFormCheckLoginUserResult res = CloudService.Instance.Submit<AdmLoginFormCheckLoginUserResult, AdmLoginFormCheckLoginUserArgs>(args);

            // Set user info
            if (res.ExecutionStatus == ExecutionStatus.Success && res.UserInfoItem.Count > 0)
            {
                UserInfo.UserID = res.UserInfoItem[0].UserId;
                UserInfo.HospCode = res.UserInfoItem[0].HospCode;
                UserInfo.UserGroup = res.UserInfoItem[0].UserGroup;
                UserInfo.UserName = res.UserInfoItem[0].UserNm;
                UserInfo.UserPswd = this.txtPswd.Text;
            }
            else
            {
                lbMsg.Text = Resources.MSG_003; // Username or password is incorrect
                return;
            }
            ShowLoginForm(EnvironInfo.CurrSystemID, EnvironInfo.CurrSystemName);
            //ID 저장시 Registry에 SET
            UserInfoUtil.SetSystemUserToRegistry(EnvironInfo.CurrSystemID, UserInfo.UserID, this.chkSaveID.Checked);

            //시스템 사용자현황(ADM3400)에 해당 시스템의 사용자 ID 변경
            UserInfoUtil.ChangeSystemUser(EnvironInfo.CurrSystemID, this.origUserID, UserInfo.UserID);

            this.DialogResult = DialogResult.OK;
        }

        private static bool ShowLoginForm(string systemID, string systemName)
        {
            ArrayList gwaInfoList = new ArrayList();
            bool rel = false;
            string errMsg = "";
            if (!UserInfoUtil.GetDocotorGwaList(UserInfo.UserID, gwaInfoList, out errMsg))
            {
                XMessageBox.Show(errMsg);
                return false;
            }
            DoctorGwaInfo doctorGwaInfo = gwaInfoList[0] as DoctorGwaInfo;
            if (doctorGwaInfo != null)
            {
                string userID = doctorGwaInfo.DoctorID;
                string gwa = userID.Substring(0, 2);
                string gwaName = "";
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
                    //lbMsg.Text = errMsg;
                    //this.txtUserID.Focus();
                    return rel;
                }
                //UserInfoUtil.RegisterSystemUser(this.systemID, UserInfo.UserID);
            }
            else
            {
                return rel;
            }
            return true;
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
            this.btnClose.Text = XMsg.GetField("F001"); // 취 소
            this.btnConfirm.Text = XMsg.GetField("F007"); // 확 인
            this.chkSaveID.Text = XMsg.GetField("F008"); // ID 저장
            this.lbTitle.Text = XMsg.GetField("F009"); // 사용자 변경

            this.label2.Text = XMsg.GetField("F059");
            this.label1.Text = XMsg.GetField("F060");            
        }

        private void txtUserID_DataValidating(object sender, DataValidatingEventArgs e)
        {
            ////진료과 선택 기능이 없을 경우, return
            //if (!EnvironInfo.ShowDoctorGwaListAtLogin) return;
            ////과 리스트 선택 기능이 없을 경우
            //if (!EnvironInfo.GwaListShowingSystemList.Contains(EnvironInfo.CurrSystemID)) return;

            ////최초 과콤보 visible false
            //this.cboGwa.Visible = false;

            ////입력된 UserID로 진료과정보 LIST 조회
            //ArrayList gwaInfoList = new ArrayList(); //Output으로 받을 DoctorGwaInfo class List
            //string errMsg = "";
            ////과정보 조회 실패시 에러
            //if (!UserInfoUtil.GetDocotorGwaList(e.DataValue, gwaInfoList, out errMsg))
            //{
            //    XMessageBox.Show(errMsg);
            //    e.Cancel = true;
            //    return;
            //}
            ////콤보구성
            //this.cboGwa.ResetData();
            //this.cboGwa.ComboItems.Clear();
            //foreach (DoctorGwaInfo info in gwaInfoList)
            //{
            //    //Value = 의사ID, Display = 진료과명
            //    cboGwa.ComboItems.Add(info.DoctorID, info.GwaName);
            //}
            //cboGwa.RefreshComboItems();

            ////cboGwa.Visible = true;
            //cboGwa.SelectedIndex = 0;

            //PostCallHelper.PostCall(new PostMethod(this.FocusToComboGwa));
        }

        private void FocusToComboGwa()
        {
            cboGwa.Focus();
        }
    }
}
