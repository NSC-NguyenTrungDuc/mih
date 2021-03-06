using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// SelectMonitorForm에 대한 요약 설명입니다.
	/// </summary>
	internal class SelectMonitorForm : System.Windows.Forms.Form
	{
		private int monitorIndex = 1; //첫번째 Monitor
		public int MonitorIndex
		{
			get
			{
				if (rb0.Checked)
					return 0;
				if (rb1.Checked)
					return 1;
				else if (rb2.Checked)
					return 2;
				else if (rb3.Checked)
					return 3;
				else
					return 4;
			}
		}
		private System.Windows.Forms.GroupBox gbxMonitor;
		private IHIS.Framework.XButton btnCancel;
		private IHIS.Framework.XButton btnOK;
		private IHIS.Framework.XFlatRadioButton rb1;
		private IHIS.Framework.XFlatRadioButton rb2;
		private IHIS.Framework.XFlatRadioButton rb3;
		private IHIS.Framework.XFlatRadioButton rb4;
		private IHIS.Framework.XFlatRadioButton rb0;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SelectMonitorForm(int monitorIndex)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			this.monitorIndex = monitorIndex;

			this.Text = XMsg.GetField("F051"); // 모니터 설정
			this.gbxMonitor.Text = XMsg.GetField("F052"); //모니터
			this.rb0.Text = XMsg.GetField("F053"); //지정안함
            this.btnOK.Text = XMsg.GetField("F054");
            this.btnCancel.Text = XMsg.GetField("F055");

            this.rb1.Text = XMsg.GetField("F061");
            this.rb2.Text = XMsg.GetField("F062");
            this.rb3.Text = XMsg.GetField("F063");
            this.rb4.Text = XMsg.GetField("F064");
            
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
            this.gbxMonitor = new System.Windows.Forms.GroupBox();
            this.rb4 = new IHIS.Framework.XFlatRadioButton();
            this.rb3 = new IHIS.Framework.XFlatRadioButton();
            this.rb2 = new IHIS.Framework.XFlatRadioButton();
            this.rb1 = new IHIS.Framework.XFlatRadioButton();
            this.rb0 = new IHIS.Framework.XFlatRadioButton();
            this.btnCancel = new IHIS.Framework.XButton();
            this.btnOK = new IHIS.Framework.XButton();
            this.gbxMonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxMonitor
            // 
            this.gbxMonitor.Controls.Add(this.rb4);
            this.gbxMonitor.Controls.Add(this.rb3);
            this.gbxMonitor.Controls.Add(this.rb2);
            this.gbxMonitor.Controls.Add(this.rb1);
            this.gbxMonitor.Controls.Add(this.rb0);
            this.gbxMonitor.Location = new System.Drawing.Point(2, 6);
            this.gbxMonitor.Name = "gbxMonitor";
            this.gbxMonitor.Size = new System.Drawing.Size(347, 44);
            this.gbxMonitor.TabIndex = 0;
            this.gbxMonitor.TabStop = false;
            this.gbxMonitor.Text = "Monitor";
            // 
            // rb4
            // 
            this.rb4.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Lavender);
            this.rb4.Location = new System.Drawing.Point(289, 14);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(48, 24);
            this.rb4.TabIndex = 3;
            this.rb4.Text = "4th";
            this.rb4.UseVisualStyleBackColor = false;
            // 
            // rb3
            // 
            this.rb3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Lavender);
            this.rb3.Location = new System.Drawing.Point(235, 14);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(48, 24);
            this.rb3.TabIndex = 2;
            this.rb3.Text = "3rd";
            this.rb3.UseVisualStyleBackColor = false;
            // 
            // rb2
            // 
            this.rb2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Lavender);
            this.rb2.Location = new System.Drawing.Point(181, 14);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(48, 24);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "2nd";
            this.rb2.UseVisualStyleBackColor = false;
            // 
            // rb1
            // 
            this.rb1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Lavender);
            this.rb1.Location = new System.Drawing.Point(127, 14);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(48, 24);
            this.rb1.TabIndex = 0;
            this.rb1.Text = "1st";
            this.rb1.UseVisualStyleBackColor = false;
            // 
            // rb0
            // 
            this.rb0.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Lavender);
            this.rb0.Location = new System.Drawing.Point(10, 14);
            this.rb0.Name = "rb0";
            this.rb0.Size = new System.Drawing.Size(111, 24);
            this.rb0.TabIndex = 6;
            this.rb0.Text = "지정안함";
            this.rb0.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(277, 56);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnCancel.Size = new System.Drawing.Size(72, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "취 소";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(197, 56);
            this.btnOK.Name = "btnOK";
            this.btnOK.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnOK.Size = new System.Drawing.Size(72, 28);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "확 인";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SelectMonitorForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.Lavender;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(353, 86);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbxMonitor);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectMonitorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Monitor";
            this.gbxMonitor.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			//현재 Monitor의 갯수에 따라 Check 선택, RadioButton Enable 조정
			int mCount = SystemInformation.MonitorCount;
			int mIndex = Math.Max(0,Math.Min(this.monitorIndex, mCount)); //Monitor Index 적합성 SET

			//현재 모니터의 갯수에 따라 Enable 조정
			if (mCount == 1)
			{
				rb2.Enabled = false;
				rb3.Enabled = false;
				rb4.Enabled = false;
			}
			else if (mCount == 2)
			{
				rb3.Enabled = false;
				rb4.Enabled = false;
			}
			else if (mCount == 3)
				rb4.Enabled = false;

			if (mIndex == 0)
				rb0.Checked = true;
			else if (mIndex == 1)
				rb1.Checked = true;
			else if (mIndex == 2)
				rb2.Checked = true;
			else if (mIndex == 3)
				rb3.Checked = true;
			else
				rb4.Checked = true;
		}

		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}
	}
}
