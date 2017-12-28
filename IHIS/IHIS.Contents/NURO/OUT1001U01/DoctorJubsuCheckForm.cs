using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IHIS.NURO
{
	/// <summary>
	/// DoctorJubsuCheckForm에 대한 요약 설명입니다.
	/// </summary>
	public class DoctorJubsuCheckForm : IHIS.Framework.XForm
	{
		#region 자동생성
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XDisplayBox xDisplayBox2;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButton btnConfirm;
		private IHIS.Framework.XDisplayBox dbxTitle;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XLabel xLabel6;
		private IHIS.Framework.XLabel xLabel7;
		private IHIS.Framework.XLabel lbDoctorName;
		private IHIS.Framework.XDisplayBox dbxMagamTime;
		private IHIS.Framework.XDisplayBox dbxMagamTime1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public DoctorJubsuCheckForm()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DoctorJubsuCheckForm));
			this.xPanel1 = new IHIS.Framework.XPanel();
			this.xLabel7 = new IHIS.Framework.XLabel();
			this.xLabel6 = new IHIS.Framework.XLabel();
			this.lbDoctorName = new IHIS.Framework.XLabel();
			this.xLabel4 = new IHIS.Framework.XLabel();
			this.xLabel3 = new IHIS.Framework.XLabel();
			this.dbxMagamTime1 = new IHIS.Framework.XDisplayBox();
			this.dbxMagamTime = new IHIS.Framework.XDisplayBox();
			this.xLabel2 = new IHIS.Framework.XLabel();
			this.xLabel1 = new IHIS.Framework.XLabel();
			this.xDisplayBox2 = new IHIS.Framework.XDisplayBox();
			this.dbxTitle = new IHIS.Framework.XDisplayBox();
			this.xPanel2 = new IHIS.Framework.XPanel();
			this.btnConfirm = new IHIS.Framework.XButton();
			this.xPanel1.SuspendLayout();
			this.xPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// xPanel1
			// 
			this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
			this.xPanel1.Controls.Add(this.xLabel7);
			this.xPanel1.Controls.Add(this.xLabel6);
			this.xPanel1.Controls.Add(this.lbDoctorName);
			this.xPanel1.Controls.Add(this.xLabel4);
			this.xPanel1.Controls.Add(this.xLabel3);
			this.xPanel1.Controls.Add(this.dbxMagamTime1);
			this.xPanel1.Controls.Add(this.dbxMagamTime);
			this.xPanel1.Controls.Add(this.xLabel2);
			this.xPanel1.Controls.Add(this.xLabel1);
			this.xPanel1.Controls.Add(this.xDisplayBox2);
			this.xPanel1.Controls.Add(this.dbxTitle);
			this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xPanel1.Location = new System.Drawing.Point(0, 0);
			this.xPanel1.Name = "xPanel1";
			this.xPanel1.Size = new System.Drawing.Size(352, 184);
			this.xPanel1.TabIndex = 1;
			// 
			// xLabel7
			// 
			this.xLabel7.BorderColor = IHIS.Framework.XColor.XFormBackColor;
			this.xLabel7.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xLabel7.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
			this.xLabel7.Location = new System.Drawing.Point(48, 52);
			this.xLabel7.Name = "xLabel7";
			this.xLabel7.Size = new System.Drawing.Size(264, 21);
			this.xLabel7.TabIndex = 11;
			this.xLabel7.Text = "受付可能時間を超過しています。";
			// 
			// xLabel6
			// 
			this.xLabel6.BorderColor = IHIS.Framework.XColor.XFormBackColor;
			this.xLabel6.Location = new System.Drawing.Point(166, 18);
			this.xLabel6.Name = "xLabel6";
			this.xLabel6.Size = new System.Drawing.Size(100, 21);
			this.xLabel6.TabIndex = 10;
			this.xLabel6.Text = "先生";
			// 
			// lbDoctorName
			// 
			this.lbDoctorName.BorderColor = IHIS.Framework.XColor.XFormBackColor;
			this.lbDoctorName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbDoctorName.Location = new System.Drawing.Point(16, 16);
			this.lbDoctorName.Name = "lbDoctorName";
			this.lbDoctorName.Size = new System.Drawing.Size(138, 22);
			this.lbDoctorName.TabIndex = 9;
			this.lbDoctorName.Text = "梅野　福太郎";
			this.lbDoctorName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// xLabel4
			// 
			this.xLabel4.BorderColor = IHIS.Framework.XColor.XFormBackColor;
			this.xLabel4.EdgeRounding = false;
			this.xLabel4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xLabel4.Location = new System.Drawing.Point(276, 140);
			this.xLabel4.Name = "xLabel4";
			this.xLabel4.Size = new System.Drawing.Size(64, 21);
			this.xLabel4.TabIndex = 8;
			this.xLabel4.Text = "まで";
			// 
			// xLabel3
			// 
			this.xLabel3.BorderColor = IHIS.Framework.XColor.XFormBackColor;
			this.xLabel3.EdgeRounding = false;
			this.xLabel3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xLabel3.Location = new System.Drawing.Point(276, 110);
			this.xLabel3.Name = "xLabel3";
			this.xLabel3.Size = new System.Drawing.Size(58, 21);
			this.xLabel3.TabIndex = 7;
			this.xLabel3.Text = "まで";
			// 
			// dbxMagamTime1
			// 
			this.dbxMagamTime1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Khaki);
			this.dbxMagamTime1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dbxMagamTime1.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
			this.dbxMagamTime1.Location = new System.Drawing.Point(142, 136);
			this.dbxMagamTime1.Mask = "##:##";
			this.dbxMagamTime1.Name = "dbxMagamTime1";
			this.dbxMagamTime1.Size = new System.Drawing.Size(120, 24);
			this.dbxMagamTime1.TabIndex = 6;
			this.dbxMagamTime1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dbxMagamTime
			// 
			this.dbxMagamTime.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Khaki);
			this.dbxMagamTime.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dbxMagamTime.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
			this.dbxMagamTime.Location = new System.Drawing.Point(142, 106);
			this.dbxMagamTime.Mask = "##:##";
			this.dbxMagamTime.Name = "dbxMagamTime";
			this.dbxMagamTime.Size = new System.Drawing.Size(120, 24);
			this.dbxMagamTime.TabIndex = 5;
			this.dbxMagamTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xLabel2
			// 
			this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
			this.xLabel2.EdgeRounding = false;
			this.xLabel2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xLabel2.Location = new System.Drawing.Point(24, 136);
			this.xLabel2.Name = "xLabel2";
			this.xLabel2.Size = new System.Drawing.Size(100, 24);
			this.xLabel2.TabIndex = 4;
			this.xLabel2.Text = "午後";
			this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xLabel1
			// 
			this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
			this.xLabel1.EdgeRounding = false;
			this.xLabel1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xLabel1.Location = new System.Drawing.Point(24, 106);
			this.xLabel1.Name = "xLabel1";
			this.xLabel1.Size = new System.Drawing.Size(100, 24);
			this.xLabel1.TabIndex = 3;
			this.xLabel1.Text = "午前";
			this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xDisplayBox2
			// 
			this.xDisplayBox2.BackColor = IHIS.Framework.XColor.XFormBackColor;
			this.xDisplayBox2.Location = new System.Drawing.Point(8, 96);
			this.xDisplayBox2.Name = "xDisplayBox2";
			this.xDisplayBox2.Size = new System.Drawing.Size(336, 76);
			this.xDisplayBox2.TabIndex = 2;
			// 
			// dbxTitle
			// 
			this.dbxTitle.BackColor = IHIS.Framework.XColor.XFormBackColor;
			this.dbxTitle.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dbxTitle.Location = new System.Drawing.Point(8, 10);
			this.dbxTitle.Name = "dbxTitle";
			this.dbxTitle.Size = new System.Drawing.Size(336, 78);
			this.dbxTitle.TabIndex = 0;
			// 
			// xPanel2
			// 
			this.xPanel2.Controls.Add(this.btnConfirm);
			this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.xPanel2.Location = new System.Drawing.Point(0, 184);
			this.xPanel2.Name = "xPanel2";
			this.xPanel2.Size = new System.Drawing.Size(352, 40);
			this.xPanel2.TabIndex = 2;
			// 
			// btnConfirm
			// 
			this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
			this.btnConfirm.Location = new System.Drawing.Point(264, 6);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnConfirm.Size = new System.Drawing.Size(82, 28);
			this.btnConfirm.TabIndex = 2;
			this.btnConfirm.Text = "確 認";
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// DoctorJubsuCheckForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(352, 246);
			this.Controls.Add(this.xPanel1);
			this.Controls.Add(this.xPanel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "DoctorJubsuCheckForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "受付締切";
			this.Load += new System.EventHandler(this.DoctorJubsuCheckForm_Load);
			this.Controls.SetChildIndex(this.xPanel2, 0);
			this.Controls.SetChildIndex(this.xPanel1, 0);
			this.xPanel1.ResumeLayout(false);
			this.xPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Form변수

		public string mDoctorName = "";
		public string mMagamTime  = "";
		public string mMagamTime1 = "";

		#endregion

		#region Form Load

		private void DoctorJubsuCheckForm_Load(object sender, System.EventArgs e)
		{
			this.lbDoctorName.Text = "☞ " + this.mDoctorName;
			this.dbxMagamTime.SetDataValue(this.mMagamTime);
			this.dbxMagamTime1.SetDataValue(this.mMagamTime1);
		}

		#endregion

		#region XButton

		private void btnConfirm_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		#endregion
	}
}
