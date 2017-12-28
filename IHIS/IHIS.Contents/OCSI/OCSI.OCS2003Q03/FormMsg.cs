using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.OCSI
{
	/// <summary>
	/// FormMsg�� ���� ��� �����Դϴ�.
	/// </summary>
	internal class FormMsg : System.Windows.Forms.Form
	{
        private IHIS.Framework.XPictureBox pbxAlert;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormMsg()
		{

			InitializeComponent();
		}

		/// <summary>
		/// ��� ���� ��� ���ҽ��� �����մϴ�.
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

		#region Windows Form �����̳ʿ��� ������ �ڵ�
		/// <summary>
		/// �����̳� ������ �ʿ��� �޼����Դϴ�.
		/// �� �޼����� ������ �ڵ� ������� �������� ���ʽÿ�.
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

		#region ȭ�� Ŭ���� ȭ�� �ݰ� ��ȸ ����
		private void FormMsg_Click(object sender, System.EventArgs e)
		{
			pbxAlert_Click(sender, e);
		}

		// ������ Ȯ���ϰ� ȭ���� �ݴ´�
		private void pbxAlert_Click(object sender, System.EventArgs e)
		{
			
			this.Close();
	
		}
		#endregion

	}
}
