#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.OCSA
{
	
	/// <summary>
	/// DATAMODIFY에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DATAMODIFY : IHIS.Framework.XScreen
	{
		#region [Instance Variable]
		//Message처리
		string mbxMsg = "", mbxCap = "";		
		#endregion


		private IHIS.Framework.XButtonList xButtonList1;
		private System.Windows.Forms.RichTextBox txtSQL;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DATAMODIFY()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
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

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.xButtonList1 = new IHIS.Framework.XButtonList();
			this.txtSQL = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
			this.SuspendLayout();
			// 
			// xButtonList1
			// 
			this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xButtonList1.Location = new System.Drawing.Point(702, 548);
			this.xButtonList1.Name = "xButtonList1";
			this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Process;
			this.xButtonList1.Size = new System.Drawing.Size(244, 34);
			this.xButtonList1.TabIndex = 1;
			this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
			// 
			// txtSQL
			// 
			this.txtSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSQL.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSQL.ImeMode = System.Windows.Forms.ImeMode.Alpha;
			this.txtSQL.Location = new System.Drawing.Point(6, 8);
			this.txtSQL.Name = "txtSQL";
			this.txtSQL.Size = new System.Drawing.Size(944, 528);
			this.txtSQL.TabIndex = 0;
			this.txtSQL.Text = "";
			// 
			// DATAMODIFY
			// 
			this.Controls.Add(this.txtSQL);
			this.Controls.Add(this.xButtonList1);
			this.Name = "DATAMODIFY";
			((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region [Button List Event]

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{   
			switch (e.Func)
			{
		
				case FunctionType.Process:

					e.IsBaseCall = false;

					try
					{
						Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;	
						
						ProcessModify();
				
					}
					finally
					{
						Cursor.Current = System.Windows.Forms.Cursors.Default;
					}
			

					break;
				
				default:

					break;
			}			
		}
		#endregion

		#region [Function]

		private void ProcessModify()
		{
			if(txtSQL.Text.Trim() == "") return;

			string[] executeSQL = txtSQL.Text.Split(';');

			foreach(string inputSQL in executeSQL)
			{
				if(inputSQL.Trim() == "") continue;

                if(DsvUpdate(inputSQL))
				{
					mbxMsg = "処理が完了しました。";
					SetMsg(mbxMsg);
				}
			}

		}
		#endregion

        #region DsvUpdate()
        private bool DsvUpdate(string inputSQL)
        {
            try
            {
                Service.BeginTransaction();
                if (!Service.ExecuteNonQuery(inputSQL)) throw new Exception(Service.ErrFullMsg);
            }
            catch(Exception xe)
            {
                Service.RollbackTransaction();
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace, "エラー", MessageBoxIcon.Error);
                return false;
            }
            Service.CommitTransaction();
            return true;
        }
        #endregion

    }
}

