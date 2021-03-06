using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// LeaveForm에 대한 요약 설명입니다.
	/// </summary>
	internal class LeaveForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
		LeavePassForm leavePassForm;

		public LeaveForm(Point location, Size size)
		{
			InitializeComponent();
			this.Location = location;
			this.Size	  = size;
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
			// 
			// LeaveForm
			// 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Brown;
			this.ClientSize = new System.Drawing.Size(824, 560);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.MinimizeBox = false;
			this.Name = "LeaveForm";
			this.Opacity = 0.3;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "3";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LeaveForm_KeyDown);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeaveForm_MouseDown);
			this.Activated += new System.EventHandler(this.LeaveForm_Activated);

		}
		#endregion

		private void LeaveForm_Activated(object sender, System.EventArgs e)
		{
			this.Icon = Owner.Icon;
		}

		private void LeaveForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.Alt)
			{
				e.Handled = true;
			}
			else
			{
				LoadPassForm();
			}
		}

		private void LeaveForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			LoadPassForm();
		}

		internal void LoadPassForm()
		{
			if (leavePassForm == null)
			{
				leavePassForm = new LeavePassForm();
			}
			leavePassForm.ShowDialog(this);
			if (leavePassForm.DialogResult == DialogResult.OK)
			{
				this.DialogResult = DialogResult.OK;
				leavePassForm.Close();
			}
			else
				leavePassForm.Hide();
		}
		////////////////////////////////////////////////////////////////////////////////////////
	}
}
