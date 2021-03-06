using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.ADMM
{
	/// <summary>
	/// AllimForm에 대한 요약 설명입니다.
	/// </summary>
	internal class AllimForm : System.Windows.Forms.Form
	{
		private MainForm parentForm = null;
		private string userID = "";
		private System.Windows.Forms.Label lbMsg;
		private IHIS.Framework.XButton btnCnfm;
		private IHIS.Framework.XButton btnClose;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AllimForm(MainForm parentForm, string userID, string msg)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//

			//일본어 번경
			SetControlNameByLangMode();
			this.parentForm = parentForm;
			this.userID = userID;
			this.lbMsg.Text = msg;

			
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
			this.lbMsg = new System.Windows.Forms.Label();
			this.btnCnfm = new IHIS.Framework.XButton();
			this.btnClose = new IHIS.Framework.XButton();
			this.SuspendLayout();
			// 
			// lbMsg
			// 
			this.lbMsg.BackColor = System.Drawing.Color.Khaki;
			this.lbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbMsg.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbMsg.ForeColor = System.Drawing.Color.Indigo;
			this.lbMsg.Location = new System.Drawing.Point(0, 0);
			this.lbMsg.Name = "lbMsg";
			this.lbMsg.Size = new System.Drawing.Size(234, 114);
			this.lbMsg.TabIndex = 0;
			this.lbMsg.Text = "이승필님의 미확인 메세지 5건 확인하시기 바랍니다.";
			this.lbMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnCnfm
			// 
			this.btnCnfm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCnfm.Location = new System.Drawing.Point(4, 86);
			this.btnCnfm.Name = "btnCnfm";
			this.btnCnfm.Scheme = IHIS.Framework.XButtonSchemes.Silver;
			this.btnCnfm.Size = new System.Drawing.Size(116, 26);
			this.btnCnfm.TabIndex = 4;
			this.btnCnfm.Text = "메세지확인하기";
			this.btnCnfm.Click += new System.EventHandler(this.btnCnfm_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(162, 86);
			this.btnClose.Name = "btnClose";
			this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnClose.Size = new System.Drawing.Size(66, 26);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "닫 기";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// AllimForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(234, 114);
			this.ControlBox = false;
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnCnfm);
			this.Controls.Add(this.lbMsg);
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AllimForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "미확인 수신건 확인";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
			this.Location = new Point(rc.Width - this.Width, rc.Height - this.Height);
		}


		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnCnfm_Click(object sender, System.EventArgs e)
		{
			//ParentForm에 사용자ID전달하여 미수신내역 조회하도록 처리함.
			this.parentForm.ShowAndSelectRecvList(this.userID);
			this.Close();
		}

		private void SetControlNameByLangMode()
		{
			if (NetInfo.Language == LangMode.Jr)
			{
				this.Text = "未確認の受信の確認";  //미확인 수신확인
				this.btnCnfm.Text = "メッセージの確認";  //메세지확인
				this.btnClose.Text = "閉じる"; //닫기
			}
		}
	}
}
