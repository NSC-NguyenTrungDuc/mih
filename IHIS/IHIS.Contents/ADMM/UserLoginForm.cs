using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.ADMM
{
	/// <summary>
	/// UserLoginForm에 대한 요약 설명입니다.
	/// </summary>
	internal class UserLoginForm : System.Windows.Forms.Form
	{
		//사용자ID 전달
		public string UserID
		{
			get { return this.txtUserID.Text.Trim();}
		}
		public string UserName
		{
			get { return UserInfo.UserName;}
		}

		private MainForm parentForm = null;
		private System.Windows.Forms.Label label1;
		private IHIS.Framework.XButton btnCancel;
		private IHIS.Framework.XButton btnOK;
		private System.Windows.Forms.Label label2;
		private IHIS.Framework.XTextBox txtUserID;
		private IHIS.Framework.XTextBox txtPswd;
		private System.Windows.Forms.Label lbTitle;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UserLoginForm(MainForm parentForm)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			//일본어전환
			SetControlNameByLangMode();

			this.parentForm = parentForm;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLoginForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new IHIS.Framework.XButton();
            this.btnOK = new IHIS.Framework.XButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserID = new IHIS.Framework.XTextBox();
            this.txtPswd = new IHIS.Framework.XTextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(40, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(144, 144);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnCancel.Size = new System.Drawing.Size(68, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "취 소";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(48, 144);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(68, 28);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "확 인";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(40, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserID
            // 
            this.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtUserID.Location = new System.Drawing.Point(112, 64);
            this.txtUserID.MaxLength = 8;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 20);
            this.txtUserID.TabIndex = 0;
            this.txtUserID.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            // 
            // txtPswd
            // 
            this.txtPswd.Location = new System.Drawing.Point(112, 96);
            this.txtPswd.MaxLength = 4;
            this.txtPswd.Name = "txtPswd";
            this.txtPswd.PasswordChar = '*';
            this.txtPswd.Size = new System.Drawing.Size(100, 20);
            this.txtPswd.TabIndex = 1;
            this.txtPswd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPswd_KeyPress);
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(34, 16);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(146, 16);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.Text = "메세지 사용자 입력";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserLoginForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(250, 200);
            this.ControlBox = false;
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.txtPswd);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(250, 200);
            this.MinimumSize = new System.Drawing.Size(250, 200);
            this.Name = "UserLoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region WndProc
		protected override void WndProc(ref Message m)
		{
			//WM_NCHITTEST시에 Caption을 선택한 것처럼 Msg Hook
			if (m.Msg == (int) Win32.Msgs.WM_NCHITTEST)
				m.Result = new IntPtr(2); //Hit Caption
			else
				base.WndProc(ref m);
		}
		#endregion

		private void txtUserID_TextChanged(object sender, System.EventArgs e)
		{
			//Text의 Length가 8이면 다음으로 이동
			if (txtUserID.Text.Length == 8)
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

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			string msg = "";
			//사용자ID, 비밀번호 입력여부 확인
			if (txtUserID.Text.Trim() == "")
			{
				msg = (NetInfo.Language == LangMode.Ko ? "사용자ID가 입력되지 않았습니다."
					:"ユーザーＩＤを入力してください。");
				XMessageBox.Show(msg);
				txtUserID.Focus();
				return;
			}
			if (txtPswd.Text.Trim() == "")
			{
				msg = (NetInfo.Language == LangMode.Ko ? "비밀번호가 입력되지 않았습니다."
					:"パスワードを入力してください。");
				XMessageBox.Show(msg);
				txtPswd.Focus();
				return;
			}
			string errMsg = "";
			//UserLogin 실패시
			if (!UserInfoUtil.CheckUser("ADMM", txtUserID.Text.Trim(), txtPswd.Text.Trim(), out errMsg))
			{
				XMessageBox.Show(errMsg);
				return;
			}
			this.DialogResult = DialogResult.OK;
		}

		private void SetControlNameByLangMode()
		{
			if (NetInfo.Language == LangMode.Jr)
			{
				this.lbTitle.Text = "メッセージユーザーログイン";  //메세지사용자로그인
				this.btnCancel.Text = "取消し";  //취소
				this.btnOK.Text = "確 認";  //확인
			}
        }
	}
}
