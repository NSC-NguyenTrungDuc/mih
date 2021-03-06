using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using IHIS.Framework;

namespace IHIS.OCSA
{
	/// <summary>
	/// ImageEditorForm에 대한 요약 설명입니다.
	/// </summary>
	public class ImageEditorForm : System.Windows.Forms.Form
	{
		#region Fields
		//이미지 Size는 640 * 480으로 고정
		const int IMAGE_WIDTH = 640;
		const int IMAGE_HEIGHT = 480;
		const int MIN_WIDTH = 520;  //Form의 최소 Size
		const int MIN_HEIGHT = 490; //Form의 최소 Size
		#endregion

		#region Property
		//Image 
		public Image Image
		{
			get { return imageEditor.Image;}
		}
		#endregion

		private System.Windows.Forms.Panel pnlBottom;
		private IHIS.Framework.XImageEditor imageEditor;
		private IHIS.Framework.XButton btnSave;
		private IHIS.Framework.XButton btnClose;
		private IHIS.Framework.XButton btnLoad;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ImageEditorForm(Image image)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			
			//Image Set
			//Image를 파일에서 읽어서 원래 이미지 크기 그대로 설정함
			//ImageEditorForm을 call하는 화면에서 원래크기로 Image를 만들어 보내도록함(파일명을 주면 읽는 방법도 고려해 볼 수 있음)
			//Image의 크기에 따라 Form의 Size를 변경할지 여부는 추후 확정하여 반영 일단 FIX
			try
			{
				if (image != null)
				{
					this.imageEditor.Image = image;
					
					//Form의 Size를 Image Size에 맞추어 조정하기, Design크기는 640*480으로 맞추어져 있음
					//따라서, 기본 크기와 Image Size를 비교하여 조정함 (기본Size와의 Image Size의 차이분 만큼 반영)
					int width = Math.Max(MIN_WIDTH, this.Size.Width - (IMAGE_WIDTH - image.Width));
					int height = Math.Max(MIN_HEIGHT, this.Size.Height - (IMAGE_HEIGHT - image.Height));
                    Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                    height = Math.Min(height, rc.Height);
					this.Size = new Size(width, height);

				}
			}
			catch{}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageEditorForm));
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnLoad = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.btnSave = new IHIS.Framework.XButton();
            this.imageEditor = new IHIS.Framework.XImageEditor();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnLoad);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 548);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(1);
            this.pnlBottom.Size = new System.Drawing.Size(720, 30);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(4, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 26);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load Image";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(650, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnClose.Size = new System.Drawing.Size(66, 24);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "閉じる";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(580, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 24);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保 存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imageEditor
            // 
            this.imageEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageEditor.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageEditor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.imageEditor.Location = new System.Drawing.Point(0, 0);
            this.imageEditor.Name = "imageEditor";
            this.imageEditor.ShowSaveButton = false;
            this.imageEditor.Size = new System.Drawing.Size(720, 548);
            this.imageEditor.TabIndex = 3;
            // 
            // ImageEditorForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(720, 578);
            this.Controls.Add(this.imageEditor);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ImageEditorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "イメージエディタ";
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		//이미지 저장
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			this.imageEditor.Save();
			this.DialogResult = DialogResult.OK; 
		}

		private void btnLoad_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "bmp files (*.bmp)|*.bmp|gif files (*.gif)|*.gif|jpg files (*.jpg)|*.jpg";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				this.imageEditor.Image = ImageHelper.GetImage(dlg.FileName);
			}
		}



	}
}
