using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
//
using IHIS.Framework;

namespace IHIS
{
	/// <summary>
	/// SetTimeForm에 대한 요약 설명입니다.
	/// </summary>
	internal class SetTimeForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lbMsg;
		private IHIS.XPButton btnOK;
		private IHIS.XPButton btnCancel;
		private System.Windows.Forms.Label lbTitle;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SetTimeForm(DateTime serverTime)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			this.lbTitle.Text = XMsg.GetField("F020"); // PC시간 동기화
			//서버시간, PC시간, 시간을 맞추지 않을 경우 잘못된 날짜(시간)으로 인해 데이타 오류가 발생할 수 있습니다.
			//PC 시간을 서버시간에 맞추겠습니까?
			this.lbMsg.Text = XMsg.GetMsg("M034") + "[" + serverTime.ToString("yyyy-MM-dd HH:mm:ss")   + "]\n\n"
				+ XMsg.GetMsg("M035") + "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]\n\n"
				+ XMsg.GetMsg("M036") + "\n\n"
				+ XMsg.GetMsg("M037");

			//일본,한글 모드에 따른 Control Text Set
			SetControlTextByLangMode();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SetTimeForm));
			this.lbMsg = new System.Windows.Forms.Label();
			this.btnOK = new IHIS.XPButton();
			this.btnCancel = new IHIS.XPButton();
			this.lbTitle = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbMsg
			// 
			this.lbMsg.BackColor = System.Drawing.Color.Transparent;
			this.lbMsg.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbMsg.Location = new System.Drawing.Point(10, 40);
			this.lbMsg.Name = "lbMsg";
			this.lbMsg.Size = new System.Drawing.Size(230, 122);
			this.lbMsg.TabIndex = 0;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(32, 164);
			this.btnOK.Name = "btnOK";
			this.btnOK.Scheme = IHIS.Schemes.Silver;
			this.btnOK.Size = new System.Drawing.Size(68, 26);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "확 인";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(152, 164);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Scheme = IHIS.Schemes.Green;
			this.btnCancel.Size = new System.Drawing.Size(68, 26);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "취 소";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lbTitle
			// 
			this.lbTitle.BackColor = System.Drawing.Color.Transparent;
			this.lbTitle.Enabled = false;
			this.lbTitle.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.Color.White;
			this.lbTitle.Location = new System.Drawing.Point(34, 16);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(110, 18);
			this.lbTitle.TabIndex = 3;
			this.lbTitle.Text = "PC시간 동기화";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SetTimeForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(250, 200);
			this.Controls.Add(this.lbTitle);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lbMsg);
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SetTimeForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SetTimeForm";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		#region WndProc
		protected override void WndProc(ref Message m)
		{
			//WM_NCHITTEST시에 Caption을 선택한 것처럼 Msg Hook
			if (m.Msg == (int) Msgs.WM_NCHITTEST)
				m.Result = new IntPtr(2); //Hit Caption
			else
				base.WndProc(ref m);
		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void SetControlTextByLangMode()
		{
			this.btnCancel.Text = XMsg.GetField("F017"); // 취 소" : "取消し");
			this.btnOK.Text = XMsg.GetField("F018"); // 확 인" : "確 認");
		}
	}
}
