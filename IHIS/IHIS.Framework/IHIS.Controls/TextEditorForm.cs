using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace IHIS.Framework
{
	/// <summary>
	/// TextEditorForm에 대한 요약 설명입니다.
	/// </summary>
	public class TextEditorForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Editor의 Text입력 Control입니다.
		/// </summary>
		protected System.Windows.Forms.TextBox textBox1;
		private IHIS.Framework.XButton btnOK;
		private IHIS.Framework.XButton btnCancel;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// TextEditorForm 생성자
		/// </summary>
		/// <param name="text"></param>
		public TextEditorForm(string caption, string text)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();
			
			this.Text = caption;
			this.btnOK.Text = "OK"; //확 인
			this.btnCancel.Text = "Cancel"; //취 소
			textBox1.Text = text;
		}
		/// <summary>
		/// 편집된 Text를 가져옵니다.
		/// </summary>
		public string ReturnText
		{
			get { return textBox1.Text; }
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnOK = new IHIS.Framework.XButton();
			this.btnCancel = new IHIS.Framework.XButton();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.AcceptsReturn = true;
			this.textBox1.AcceptsTab = true;
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(5, 5);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(690, 382);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(532, 392);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(76, 28);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "확 인";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(620, 392);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnCancel.Size = new System.Drawing.Size(76, 28);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "취 소";
			// 
			// TextEditorForm
			// 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(700, 422);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.textBox1);
			this.DockPadding.Bottom = 35;
			this.DockPadding.Left = 5;
			this.DockPadding.Right = 5;
			this.DockPadding.Top = 5;
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "TextEditorForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "텍스트 편집기";
			this.ResumeLayout(false);

		}
		#endregion

	}
}