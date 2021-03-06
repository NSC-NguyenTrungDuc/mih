using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
//
using IHIS.Framework;

namespace IHIS
{
	/// <summary>
	/// WarningForm에 대한 요약 설명입니다.
	/// </summary>
	public class WarningForm : System.Windows.Forms.Form
	{
		private IHIS.XPButton btnCancel;
		private IHIS.XPButton btnClose;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WarningForm()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			SetBackgroundImage();
			
			//버튼 Text Set
			this.btnClose.Text = XMsg.GetField("F021"); // 종 료
			this.btnCancel.Text = XMsg.GetField("F017"); // 취 소
			
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarningForm));
            this.btnClose = new IHIS.XPButton();
            this.btnCancel = new IHIS.XPButton();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(99, 104);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Schemes.Silver;
            this.btnClose.Size = new System.Drawing.Size(59, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "종 료";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(178, 103);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Schemes.OliveGreen;
            this.btnCancel.Size = new System.Drawing.Size(58, 26);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "취 소";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // WarningForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(335, 135);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WarningForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void SetBackgroundImage()
		{
			//한국어,일본어 모드에 따라 배경 이미지 설정
			try
			{
				//string resName = (NetInfo.Language == LangMode.Ko ? "IHIS.Images.WarningFormKo.gif" : "IHIS.Images.WarningFormJr.gif");

                string resName = "";
                switch (NetInfo.Language)
                {
                    case LangMode.En:
                        resName = "IHIS.Images.WarningFormEn.gif";
                        break;
                    case LangMode.Jr:
                        resName = "IHIS.Images.WarningFormJr.gif";
                        break;
                    case LangMode.Ko:
                        resName = "IHIS.Images.WarningFormKo.gif";
                        break;
                    case LangMode.Vi:
                        resName = "IHIS.Images.WarningFormVi.gif";
                        break;
                    default:
                        resName = "IHIS.Images.WarningFormJr.gif";
                        break;
                }

				System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
				this.BackgroundImage = (Bitmap) Bitmap.FromStream(l_as.GetManifestResourceStream(resName));
			}
			catch{}

		}
	}
}
