using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.Framework;
using IHIS.NURO;


namespace IHIS.NURO
{
	/// <summary>
	/// FormSujinNo에 대한 요약 설명입니다.
	/// </summary>
	public class FormSujinNo : IHIS.Framework.XForm
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XLabel xLabel2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XEditMask emkSujinNo;
		private IHIS.Framework.XButtonList btnList;
		/// <summary> 
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormSujinNo(string aBunho, string aNaewonDate)
		{
			// 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
			InitializeComponent();

			// TODO: InitializeComponent를 호출한 다음 초기화 작업을 추가합니다.
			this.mNaewonDate = aNaewonDate ;
			this.mBunho      = aBunho      ;
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

		#region 구성 요소 디자이너에서 생성한 코드
		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormSujinNo));
			this.xPanel1 = new IHIS.Framework.XPanel();
			this.emkSujinNo = new IHIS.Framework.XEditMask();
			this.xLabel2 = new IHIS.Framework.XLabel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.xPanel2 = new IHIS.Framework.XPanel();
			this.btnList = new IHIS.Framework.XButtonList();
			this.xPanel1.SuspendLayout();
			this.xPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
			this.SuspendLayout();
			// 
			// xPanel1
			// 
			this.xPanel1.Controls.Add(this.emkSujinNo);
			this.xPanel1.Controls.Add(this.xLabel2);
			this.xPanel1.Controls.Add(this.pictureBox1);
			this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xPanel1.Location = new System.Drawing.Point(0, 0);
			this.xPanel1.Name = "xPanel1";
			this.xPanel1.Size = new System.Drawing.Size(295, 210);
			this.xPanel1.TabIndex = 1;
			// 
			// emkSujinNo
			// 
			this.emkSujinNo.EditMaskType = IHIS.Framework.MaskType.Number;
			this.emkSujinNo.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.emkSujinNo.Location = new System.Drawing.Point(25, 93);
			this.emkSujinNo.MaxLength = 3;
			this.emkSujinNo.Name = "emkSujinNo";
			this.emkSujinNo.Size = new System.Drawing.Size(246, 55);
			this.emkSujinNo.TabIndex = 39;
			this.emkSujinNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.emkSujinNo.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.XEditMask_DataValidating);
			// 
			// xLabel2
			// 
			this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
			this.xLabel2.EdgeRounding = false;
			this.xLabel2.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xLabel2.Location = new System.Drawing.Point(25, 20);
			this.xLabel2.Name = "xLabel2";
			this.xLabel2.Size = new System.Drawing.Size(246, 55);
			this.xLabel2.TabIndex = 37;
			this.xLabel2.Text = "受診番号";
			this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(295, 210);
			this.pictureBox1.TabIndex = 31;
			this.pictureBox1.TabStop = false;
			// 
			// xPanel2
			// 
			this.xPanel2.Controls.Add(this.btnList);
			this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.xPanel2.Location = new System.Drawing.Point(0, 169);
			this.xPanel2.Name = "xPanel2";
			this.xPanel2.Size = new System.Drawing.Size(295, 41);
			this.xPanel2.TabIndex = 2;
			// 
			// btnList
			// 
			this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnList.IsVisibleReset = false;
			this.btnList.Location = new System.Drawing.Point(25, 5);
			this.btnList.Name = "btnList";
			this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Process;
			this.btnList.Size = new System.Drawing.Size(244, 34);
			this.btnList.TabIndex = 0;
			this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
			// 
			// FormSujinNo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(295, 232);
			this.Controls.Add(this.xPanel2);
			this.Controls.Add(this.xPanel1);
			this.Name = "FormSujinNo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "受診準登録";
			this.Load += new System.EventHandler(this.FormSujinNo_Load);
			this.Controls.SetChildIndex(this.xPanel1, 0);
			this.Controls.SetChildIndex(this.xPanel2, 0);
			this.xPanel1.ResumeLayout(false);
			this.xPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Form 변수 

		private string mMsg = "";
		private string mCap = "";

		private string mBunho = "";
		private string mNaewonDate = "";

		public string mReturnSujinNo = "";

		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormSujinNo_Load(object sender, System.EventArgs e)
		{		
			this.emkSujinNo.SetDataValue("0");
			this.emkSujinNo.SelectAll();
		}

		#region 중복체크

		private bool IsValidSujinNo ()
		{
			string bunho = "";
			string suname = "";

			if(this.emkSujinNo.GetDataValue() == "0")
			{
				return true;
			}

			// 중복체크
            NuroChkGetBunhoBySujinInfo chkGetBunhoBySujinInfo = IHIS.NURO.Methodes.ChkGetBunhoBySujin(mNaewonDate, this.emkSujinNo.GetDataValue());
		    if (chkGetBunhoBySujinInfo != null)
		    {
		        bunho = chkGetBunhoBySujinInfo.Bunho;
		        suname = chkGetBunhoBySujinInfo.Suname;
                if (bunho != this.mBunho)
                {
                    this.mMsg = this.emkSujinNo.GetDataValue() + (NetInfo.Language == LangMode.Ko ? " 번호는 " : " は ") +
                        "(" + bunho + ")" + suname + (NetInfo.Language == LangMode.Ko ? "가 사용하고 있습니다." : "さんが使用しています。");
                    this.mCap = (NetInfo.Language == LangMode.Ko ? "수진번호 중복" : "受診番号重複");

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
		    }
//            DataTable dt = IHIS.NURO.Methodes.ChkGetBunhoBySujin(mNaewonDate, this.emkSujinNo.GetDataValue());

//			if (!TypeCheck.IsNull(dt))
//			{
//                if(dt.Rows.Count > 0)
//                {
//                    bunho = dt.Rows[0]["bunho"].ToString();
//                    suname = dt.Rows[0]["suname"].ToString();
//
//				    if (bunho != this.mBunho)
//				    {
//					    this.mMsg = this.emkSujinNo.GetDataValue() + (NetInfo.Language == LangMode.Ko ? " 번호는 " : " は ") +
//						    "(" + bunho + ")" + suname + (NetInfo.Language == LangMode.Ko ? "가 사용하고 있습니다." : "さんが使用しています。");
//					    this.mCap = (NetInfo.Language == LangMode.Ko ? "수진번호 중복" : "受診番号重複");
//
//					    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
//
//					    return false;
//				    }
//                }
//			}

			return true;
		}

		#endregion

		#region XButtonList
		
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Process:
					
					if (this.IsValidSujinNo())
					{
						this.mReturnSujinNo = TypeCheck.NVL(this.emkSujinNo.GetDataValue(), "0").ToString();

						this.DialogResult = DialogResult.OK;
					}
					else
					{
						this.emkSujinNo.Focus();
						this.emkSujinNo.SelectAll();
					}
					
					break;
				case FunctionType.Cancel:

					this.DialogResult = DialogResult.Cancel;
					
					break;
														  
				case FunctionType.Close:

					this.DialogResult = DialogResult.No;
					
					break; 
				default:
					break;
			}

		}

		#endregion

		#region XEditMask

		private void XEditMask_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if (e.DataValue == "" || e.DataValue == "0")
			{
				return;
			}

			PostCallHelper.PostCall(new PostMethod(PostValidating));
		}

		private void PostValidating()
		{
			if (IsValidSujinNo())
			{
				btnList.PerformClick(FunctionType.Process);
			}
		}

		#endregion

	}
}
