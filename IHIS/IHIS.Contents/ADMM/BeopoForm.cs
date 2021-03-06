using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.ADMM
{
	/// <summary>
	/// BeopoForm에 대한 요약 설명입니다.
	/// </summary>
	internal class BeopoForm : System.Windows.Forms.Form
	{
		#region Properties
		public string BeopoName  //그룹명
		{
			get { return this.txtGpName.Text.Trim();}
		}
		public string BeopoDesc  //그룹설명
		{
			get { return this.txtCmmt.Text.Trim();}
		}
		#endregion

		private System.Windows.Forms.TextBox txtGpName;
		private System.Windows.Forms.TextBox txtCmmt;
		private IHIS.Framework.XButton btnOK;
		private IHIS.Framework.XButton btnCancel;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Label lbName;
		private System.Windows.Forms.Label lbDesc;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BeopoForm()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			//일본어 변경
			SetControlNameByLangMode();
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
			this.lbTitle = new System.Windows.Forms.Label();
			this.lbName = new System.Windows.Forms.Label();
			this.lbDesc = new System.Windows.Forms.Label();
			this.txtGpName = new System.Windows.Forms.TextBox();
			this.txtCmmt = new System.Windows.Forms.TextBox();
			this.btnOK = new IHIS.Framework.XButton();
			this.btnCancel = new IHIS.Framework.XButton();
			this.SuspendLayout();
			// 
			// lbTitle
			// 
			this.lbTitle.Location = new System.Drawing.Point(14, 0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(276, 24);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "저장할 배포이름을 입력하십시오";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbName
			// 
			this.lbName.Location = new System.Drawing.Point(6, 28);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(34, 20);
			this.lbName.TabIndex = 1;
			this.lbName.Text = "이름";
			// 
			// lbDesc
			// 
			this.lbDesc.Location = new System.Drawing.Point(6, 52);
			this.lbDesc.Name = "lbDesc";
			this.lbDesc.Size = new System.Drawing.Size(34, 20);
			this.lbDesc.TabIndex = 2;
			this.lbDesc.Text = "설명";
			// 
			// txtGpName
			// 
			this.txtGpName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.txtGpName.Location = new System.Drawing.Point(42, 28);
			this.txtGpName.MaxLength = 25;
			this.txtGpName.Name = "txtGpName";
			this.txtGpName.Size = new System.Drawing.Size(248, 20);
			this.txtGpName.TabIndex = 3;
			this.txtGpName.Text = "";
			// 
			// txtCmmt
			// 
			this.txtCmmt.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.txtCmmt.Location = new System.Drawing.Point(42, 52);
			this.txtCmmt.MaxLength = 50;
			this.txtCmmt.Multiline = true;
			this.txtCmmt.Name = "txtCmmt";
			this.txtCmmt.Size = new System.Drawing.Size(248, 60);
			this.txtCmmt.TabIndex = 4;
			this.txtCmmt.Text = "";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(118, 116);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(76, 26);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "확 인";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(214, 116);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnCancel.Size = new System.Drawing.Size(76, 26);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "취 소";
			// 
			// BeopoForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(249)), ((System.Byte)(251)));
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(296, 146);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtCmmt);
			this.Controls.Add(this.txtGpName);
			this.Controls.Add(this.lbDesc);
			this.Controls.Add(this.lbName);
			this.Controls.Add(this.lbTitle);
			this.DockPadding.All = 5;
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "BeopoForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "배포목록저장";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (this.txtGpName.Text.Trim() == "")
			{
				XMessageBox.Show("配布リスト名を入力してください。");
				this.txtGpName.Focus();
				return;
			}
			this.DialogResult = DialogResult.OK;
		}

		private void SetControlNameByLangMode()
		{
			if (NetInfo.Language == LangMode.Jr)
			{
				this.Text = "配布リストの保存";  //배포목록저장
				this.btnOK.Text = "確 認";
				this.btnCancel.Text = "取 消";
				this.lbTitle.Text = "配布リスト名を入力してください。"; //저장할 배포이름을 입력하십시오.
				this.lbName.Text = "名";
				this.lbDesc.Text = "説明";
			}
		}
	}
}
