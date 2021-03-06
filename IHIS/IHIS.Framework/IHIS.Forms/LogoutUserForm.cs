using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;
using System.Text;

namespace IHIS.Framework
{
	/// <summary>
	/// LogoutUserForm에 대한 요약 설명입니다.
	/// </summary>
	internal class LogoutUserForm : System.Windows.Forms.Form
	{
		private IHIS.Framework.XButton btnClose;
		private IHIS.Framework.XButton btnConfirm;
		private System.Windows.Forms.CheckBox chkSaveID;
		private IHIS.Framework.XTextBox txtPswd;
		private IHIS.Framework.XTextBox txtUserID;
		private System.Windows.Forms.Label lbMsg;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public LogoutUserForm()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
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
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.CausesValidation = false;
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(224, 210);
			this.btnClose.Name = "btnClose";
			this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnClose.Size = new System.Drawing.Size(72, 32);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "종 료";
			// 
			// btnConfirm
			// 
			this.btnConfirm.Location = new System.Drawing.Point(110, 210);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Size = new System.Drawing.Size(72, 32);
			this.btnConfirm.TabIndex = 3;
			this.btnConfirm.Text = "확 인";
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// chkSaveID
			// 
			this.chkSaveID.BackColor = System.Drawing.Color.Transparent;
			this.chkSaveID.Checked = true;
			this.chkSaveID.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSaveID.Location = new System.Drawing.Point(250, 178);
			this.chkSaveID.Name = "chkSaveID";
			this.chkSaveID.TabIndex = 2;
			this.chkSaveID.Text = "ID 저장";
			// 
			// txtPswd
			// 
			this.txtPswd.Location = new System.Drawing.Point(166, 178);
			this.txtPswd.MaxLength = 10;
			this.txtPswd.Name = "txtPswd";
			this.txtPswd.PasswordChar = '*';
			this.txtPswd.Size = new System.Drawing.Size(80, 20);
			this.txtPswd.TabIndex = 1;
			this.txtPswd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPswd_KeyPress);
			// 
			// txtUserID
			// 
			this.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtUserID.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txtUserID.Location = new System.Drawing.Point(166, 152);
			this.txtUserID.MaxLength = 10;
			this.txtUserID.Name = "txtUserID";
			this.txtUserID.Size = new System.Drawing.Size(80, 20);
			this.txtUserID.TabIndex = 0;
			// 
			// lbMsg
			// 
			this.lbMsg.BackColor = System.Drawing.Color.Transparent;
			this.lbMsg.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbMsg.ForeColor = System.Drawing.Color.IndianRed;
			this.lbMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lbMsg.Location = new System.Drawing.Point(24, 264);
			this.lbMsg.Name = "lbMsg";
			this.lbMsg.Size = new System.Drawing.Size(364, 22);
			this.lbMsg.TabIndex = 5;
			// 
			// lbTitle
			// 
			this.lbTitle.BackColor = System.Drawing.Color.Transparent;
			this.lbTitle.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.Color.White;
			this.lbTitle.Location = new System.Drawing.Point(114, 84);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(176, 24);
			this.lbTitle.TabIndex = 11;
			this.lbTitle.Text = "lbTitle";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(100, 180);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 19);
			this.label1.TabIndex = 17;
			this.label1.Text = "Password";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(100, 152);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 19);
			this.label2.TabIndex = 16;
			this.label2.Text = "User ID";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LogoutUserForm
			// 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(408, 300);
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbTitle);
			this.Controls.Add(this.lbMsg);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnConfirm);
			this.Controls.Add(this.chkSaveID);
			this.Controls.Add(this.txtPswd);
			this.Controls.Add(this.txtUserID);
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new System.Drawing.Size(408, 300);
			this.MinimumSize = new System.Drawing.Size(408, 300);
			this.Name = "LogoutUserForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Logout User";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

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

			string errMsg = "";

			//이전과 같은 사용자를 입력하였더라도 사용자변경 LOGIC을 그대로 적용함
			//같은 사용자라도 이 창을 띄웠으면 새로 LOGIN하는 것과 같은 LOGIC을 적용해야함
			string origUserID = UserInfo.UserID;

			//사용자 정보 Check 실패시 return
            if (!UserInfoUtil.CheckUser(EnvironInfo.CurrSystemID, this.txtUserID.Text, this.txtPswd.Text, out errMsg))
			{
				lbMsg.Text = errMsg;
				this.txtUserID.Focus();
				return;
			}

			//ID 저장시 Registry에 SET
            UserInfoUtil.SetSystemUserToRegistry(EnvironInfo.CurrSystemID, UserInfo.UserID, this.chkSaveID.Checked);

			//시스템 사용자현황(ADM3400)에 해당 시스템의 사용자 ID 변경
			UserInfoUtil.ChangeSystemUser(EnvironInfo.CurrSystemID, origUserID, UserInfo.UserID);

			this.DialogResult = DialogResult.OK;
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
			this.btnClose.Text = XMsg.GetField("F010"); // 종 료
			this.btnConfirm.Text = XMsg.GetField("F007"); // 확 인
			this.chkSaveID.Text = XMsg.GetField("F008"); // ID 저장
			this.lbTitle.Text = XMsg.GetField("F016"); // 사용자 LOGOUT
		}
	}
}
