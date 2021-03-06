using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IHIS.Framework
{
    /// <summary>
    /// LeavePassForm에 대한 요약 설명입니다.
    /// </summary>
    internal class LeavePassForm : System.Windows.Forms.Form
    {
        private IHIS.Framework.XTextBox txtPasswd;
        private IHIS.Framework.XButton btnOK;
        private IHIS.Framework.XButton btnCancel;
        private IHIS.Framework.XButton btnClose;
        private System.Windows.Forms.Label lbPswd;
        private System.ComponentModel.Container components = null;

        public LeavePassForm()
        {
            InitializeComponent();
            SetControlTextByLangMode();
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
            this.txtPasswd = new IHIS.Framework.XTextBox();
            this.lbPswd = new System.Windows.Forms.Label();
            this.btnOK = new IHIS.Framework.XButton();
            this.btnCancel = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.SuspendLayout();
            // 
            // txtPasswd
            // 
            this.txtPasswd.Location = new System.Drawing.Point(128, 8);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.PasswordChar = '*';
            this.txtPasswd.TabIndex = 1;
            // 
            // lbPswd
            // 
            this.lbPswd.Location = new System.Drawing.Point(24, 8);
            this.lbPswd.Name = "lbPswd";
            this.lbPswd.Size = new System.Drawing.Size(100, 22);
            this.lbPswd.TabIndex = 0;
            this.lbPswd.Text = "비밀번호";
            this.lbPswd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(8, 52);
            this.btnOK.Name = "btnOK";
            this.btnOK.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnOK.Size = new System.Drawing.Size(72, 28);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "확 인";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(88, 52);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnCancel.Size = new System.Drawing.Size(72, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "취 소";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(184, 52);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 28);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "시스템 종료";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LeavePassForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(296, 85);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbPswd);
            this.Controls.Add(this.txtPasswd);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LeavePassForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "비밀번호 입력";
            this.TopMost = true;
            this.ResumeLayout(false);

        }
        #endregion

        protected override void OnActivated(System.EventArgs e)
        {
            base.OnActivated(e);
            this.Icon = Owner.Icon;
            this.txtPasswd.Focus();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            string pass = IHIS.CloudConnector.Utility.Utility.CreateMd5Hash(txtPasswd.Text, false);
            if (UserInfo.UserPswd != pass)
            {
                txtPasswd.Focus();
                txtPasswd.SelectAll();
                this.DialogResult = DialogResult.None;
            }
            else
                this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Application.Exit();
        }

        //일본어, 한글 모드에 따른 Text 설정
        private void SetControlTextByLangMode()
        {
            this.Text = XMsg.GetField("F013"); // 비밀번호 입력
            this.btnCancel.Text = XMsg.GetField("F001"); // 취 소
            this.btnOK.Text = XMsg.GetField("F007"); // 확 인
            this.btnClose.Text = XMsg.GetField("F014"); // 시스템 종료
            this.lbPswd.Text = XMsg.GetField("F015"); // 비밀번호
        }

    }
}