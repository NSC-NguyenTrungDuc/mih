using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IHIS
{
	/// <summary>
	/// PostMessage를 수신하는 Event를 처리하는 메서드를 나타냅니다.
	/// </summary>
	public delegate void PostEventHandler(Message m);

	/// <summary>
	/// FormPostCallHelper에 대한 요약 설명입니다.
	/// </summary>
	public class FormPostCallHelper : System.Windows.Forms.Form
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private int postMsg = 0;
		/// <summary>
		/// PostMessage 수신 Event 입니다.
		/// </summary>
		public event PostEventHandler PostMsgReceived;
		/// <summary>
		/// PostCallHelperForm 생성자
		/// </summary>
		/// <param name="msg"></param>
		public FormPostCallHelper(int msg)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			this.postMsg = msg;
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
			// PostCallHelperForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(0, 0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "PostCallHelperForm";
			this.Opacity = 0;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ISS PostCall Helper";

		}
		#endregion
		/// <summary>
		/// Window Message를 처리합니다.
		/// </summary>
		/// <param name="m"> Window Message </param>
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (m.Msg == postMsg)
				OnPostMsgReceived(m);
		}
		/// <summary>
		/// PostMsgReceived Event를 발생시킵니다.
		/// </summary>
		/// <param name="m">  Window Message </param>
		protected virtual void OnPostMsgReceived(Message m)
		{
			if (PostMsgReceived != null)
				PostMsgReceived(m);
		}
	}
}
