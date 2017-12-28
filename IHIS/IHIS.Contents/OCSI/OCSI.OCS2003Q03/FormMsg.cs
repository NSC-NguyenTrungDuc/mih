using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.OCSI
{
	/// <summary>
	/// FormMsg에 대한 요약 설명입니다.
	/// </summary>
	internal class FormMsg : System.Windows.Forms.Form
	{
        private IHIS.Framework.XPictureBox pbxAlert;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormMsg()
		{

			InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMsg));
            this.pbxAlert = new IHIS.Framework.XPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlert)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxAlert
            // 
            this.pbxAlert.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.pbxAlert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxAlert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxAlert.Image = ((System.Drawing.Image)(resources.GetObject("pbxAlert.Image")));
            this.pbxAlert.Location = new System.Drawing.Point(0, 0);
            this.pbxAlert.Name = "pbxAlert";
            this.pbxAlert.Protect = false;
            this.pbxAlert.Size = new System.Drawing.Size(630, 324);
            this.pbxAlert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAlert.TabIndex = 1;
            this.pbxAlert.TabStop = false;
            this.pbxAlert.Click += new System.EventHandler(this.pbxAlert_Click);
            // 
            // FormMsg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(630, 324);
            this.ControlBox = false;
            this.Controls.Add(this.pbxAlert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMsg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Click += new System.EventHandler(this.FormMsg_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlert)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region WndProc
		protected override void WndProc(ref Message m)
		{
			base.WndProc (ref m);
		}
		#endregion

		#region 화면 클릭시 화면 닫고 조회 실행
		private void FormMsg_Click(object sender, System.EventArgs e)
		{
			pbxAlert_Click(sender, e);
		}

		// 내용을 확인하고 화면을 닫는다
		private void pbxAlert_Click(object sender, System.EventArgs e)
		{
			
			this.Close();
	
		}
		#endregion

	}
}
