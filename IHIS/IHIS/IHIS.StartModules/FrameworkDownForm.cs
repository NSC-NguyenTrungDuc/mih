using System;
using System.Drawing;
//
using IHIS.Framework;


namespace IHIS
{
	/// <summary>
	/// ProgressBarForm에 대한 요약 설명입니다.
	/// </summary>
	internal class FrameworkDownForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ProgressBar progressTotal;
		private System.Windows.Forms.Label fileName;
		private System.Windows.Forms.Label ratio;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ProgressBar progressBytes;
		private System.Windows.Forms.Label lbByte;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrameworkDownForm()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			SetBackgroundImage();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrameworkDownForm));
			this.progressTotal = new System.Windows.Forms.ProgressBar();
			this.fileName = new System.Windows.Forms.Label();
			this.ratio = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.progressBytes = new System.Windows.Forms.ProgressBar();
			this.lbByte = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// progressTotal
			// 
			this.progressTotal.Location = new System.Drawing.Point(14, 116);
			this.progressTotal.Name = "progressTotal";
			this.progressTotal.Size = new System.Drawing.Size(306, 10);
			this.progressTotal.TabIndex = 0;
			// 
			// fileName
			// 
			this.fileName.BackColor = System.Drawing.Color.Transparent;
			this.fileName.Location = new System.Drawing.Point(12, 96);
			this.fileName.Name = "fileName";
			this.fileName.Size = new System.Drawing.Size(218, 18);
			this.fileName.TabIndex = 3;
			this.fileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ratio
			// 
			this.ratio.BackColor = System.Drawing.Color.Transparent;
			this.ratio.Location = new System.Drawing.Point(230, 96);
			this.ratio.Name = "ratio";
			this.ratio.Size = new System.Drawing.Size(66, 18);
			this.ratio.TabIndex = 4;
			this.ratio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(294, 96);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 18);
			this.label1.TabIndex = 5;
			this.label1.Text = "File";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// progressBytes
			// 
			this.progressBytes.Location = new System.Drawing.Point(14, 82);
			this.progressBytes.Name = "progressBytes";
			this.progressBytes.Size = new System.Drawing.Size(306, 10);
			this.progressBytes.TabIndex = 6;
			// 
			// lbByte
			// 
			this.lbByte.BackColor = System.Drawing.Color.Transparent;
			this.lbByte.Location = new System.Drawing.Point(14, 62);
			this.lbByte.Name = "lbByte";
			this.lbByte.Size = new System.Drawing.Size(306, 16);
			this.lbByte.TabIndex = 7;
			this.lbByte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FrameworkDownForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(335, 135);
			this.ControlBox = false;
			this.Controls.Add(this.lbByte);
			this.Controls.Add(this.progressBytes);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ratio);
			this.Controls.Add(this.fileName);
			this.Controls.Add(this.progressTotal);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FrameworkDownForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		public void IncreaseDownCount()
		{
			try
			{
				progressTotal.Value++;
				ratio.Text = progressTotal.Value.ToString() + " / " + progressTotal.Maximum.ToString();
				ratio.Refresh();
			}
			catch{}
		}
		public void SetTotalCount(int totalCount)
		{
			progressTotal.Maximum = totalCount;
			progressTotal.Value = 0;
			ratio.Text = "0 / " + progressTotal.Maximum.ToString();
		}
		public void SetFileName(string fileNm)
		{
			fileName.Text = fileNm;
			fileName.Refresh();
		}

		private void SetBackgroundImage()
		{
			//한국어,일본어 모드에 따라 배경 이미지 설정
			try
			{
				string resName = (NetInfo.Language == LangMode.Ko ? "IHIS.Images.FrameworkDownFormKo.gif" : "IHIS.Images.FrameworkDownFormJr.gif");
				System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
				this.BackgroundImage = (Bitmap) Bitmap.FromStream(l_as.GetManifestResourceStream(resName));
			}
			catch{}

		}
		public void SetByteString(string str)
		{
			this.lbByte.Text = str;
			this.lbByte.Refresh();
		}
		public void SetRecvBytes(int recvBytes)
		{
			this.progressBytes.Value = Math.Min(recvBytes, this.progressBytes.Maximum);
		}

		#region WndProc
		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			if (m.Msg == (int) Msgs.WM_NCHITTEST)
				m.Result = new IntPtr(2); //Hit Caption
			else
				base.WndProc(ref m);
		}
		#endregion
	}
}
