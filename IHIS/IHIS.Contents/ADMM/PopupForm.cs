using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.ADMM
{
	/// <summary>
	/// PopupForm에 대한 요약 설명입니다.
	/// </summary>
	public class PopupForm : System.Windows.Forms.Form
	{
		private string userID = "";  //수신자
		private MainForm parentForm = null;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Label lbSender;
		private IHIS.Framework.XButton btnClose;
		private System.Windows.Forms.Label lbRecver;
		private System.Windows.Forms.LinkLabel lbMsg;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		public PopupForm(MainForm parentForm, string[] msgInfos)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//

			this.btnClose.Text = (NetInfo.Language == LangMode.Ko ? "닫 기" : "閉じる");

			this.parentForm = parentForm;
			//msgInfos = 수신자명 + 수신자ID + 송신자명 + 송신자ID + 메세지Title + 메세지
			if (msgInfos.Length >= 6)
			{
                this.lbSender.Text = (NetInfo.Language == LangMode.Ko ? "송신자 : " + msgInfos[0] + " (" + msgInfos[1] + ")"
                    : "送信者 : " + msgInfos[0] + " (" + msgInfos[1] + ")");
                 this.lbRecver.Text = (NetInfo.Language == LangMode.Ko ? "수신자 : " + msgInfos[2] + " (" + msgInfos[3] + ")"
					: "受信先 : " + msgInfos[2] + " (" + msgInfos[3] + ")");
				this.lbTitle.Text = msgInfos[4];
				this.userID = msgInfos[3];
				if (msgInfos[5].Length >= 60)
					this.lbMsg.Text = msgInfos[5].Substring(0,60) + "...";
				else
					this.lbMsg.Text = msgInfos[5];
				//ToopTip Set (Label에 ToolTip Set)
				this.toolTip1.SetToolTip(this.lbMsg, msgInfos[5]);
			}
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupForm));
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbSender = new System.Windows.Forms.Label();
            this.btnClose = new IHIS.Framework.XButton();
            this.lbRecver = new System.Windows.Forms.Label();
            this.lbMsg = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Enabled = false;
            this.lbTitle.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(30, 18);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(162, 16);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "메세지 타이틀";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSender
            // 
            this.lbSender.BackColor = System.Drawing.Color.Transparent;
            this.lbSender.Enabled = false;
            this.lbSender.ForeColor = System.Drawing.Color.Purple;
            this.lbSender.Location = new System.Drawing.Point(18, 39);
            this.lbSender.Name = "lbSender";
            this.lbSender.Size = new System.Drawing.Size(216, 14);
            this.lbSender.TabIndex = 1;
            this.lbSender.Text = "송신자 : 이승필 (ICM0001)";
            this.lbSender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(176, 166);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnClose.Size = new System.Drawing.Size(62, 26);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "닫 기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbRecver
            // 
            this.lbRecver.BackColor = System.Drawing.Color.Transparent;
            this.lbRecver.Enabled = false;
            this.lbRecver.ForeColor = System.Drawing.Color.Sienna;
            this.lbRecver.Location = new System.Drawing.Point(18, 56);
            this.lbRecver.Name = "lbRecver";
            this.lbRecver.Size = new System.Drawing.Size(216, 14);
            this.lbRecver.TabIndex = 5;
            this.lbRecver.Text = "수신자 : 이승필 (ICM0001)";
            this.lbRecver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMsg
            // 
            this.lbMsg.BackColor = System.Drawing.Color.Transparent;
            this.lbMsg.Location = new System.Drawing.Point(18, 78);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(216, 84);
            this.lbMsg.TabIndex = 6;
            this.lbMsg.TabStop = true;
            this.lbMsg.Text = "메세지 도착을 알립니다. 창이 팝업되어서 메세지를 선택하면 메세지 확인이 됩니다.";
            this.lbMsg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbMsg_LinkClicked);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PopupForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(250, 200);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbSender);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbRecver);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(250, 200);
            this.MinimumSize = new System.Drawing.Size(250, 200);
            this.Name = "PopupForm";
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.ResumeLayout(false);

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

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			//위치 조정 (MainForm.PopupFormCount에 따라 위치조정) Popup창 Size(250*200)
			//1024*768기준으로 우측하단부터 3개씩 보여주기
			Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
			int xCnt = Math.Max(MainForm.PopupFormCount,0)/5;
			int yCnt = Math.Max(MainForm.PopupFormCount,0)%5;
			int width = rc.Width - this.Width*xCnt;
			int height = rc.Height - this.Height*yCnt;
			this.Location = new Point(Math.Max(0, width - this.Width), Math.Max(0,height - this.Height));
			
			//메세지수신창 갯수 증가
			MainForm.PopupFormCount++;

			//timer Start
			this.timer1.Enabled = true;
			this.timer1.Start();
		}


		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing (e);
			//Popup창이 닫힐때 MainForm의 Popup창의 갯수 감소
			MainForm.PopupFormCount--;
		}

		private void btnCnfm_Click(object sender, System.EventArgs e)
		{
			//ParentForm에 사용자ID전달하여 미수신내역 조회하도록 처리함.
			this.parentForm.ShowAndSelectRecvList(this.userID);
			this.Close();
			
		}

		private void lbMsg_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			//링크 Click시에 메세지 확인하기
			//ParentForm에 사용자ID전달하여 미수신내역 조회하도록 처리함.
            this.parentForm.ShowAndSelectRecvList(this.userID);
			this.Close();
			//this.btnCnfm.PerformClick();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			//투명도 증가
			this.Opacity = this.Opacity + 0.20;
			if (this.Opacity >= 1.0)
			{
				this.timer1.Enabled = false;
				this.timer1.Stop();
			}
		}

	}
}
