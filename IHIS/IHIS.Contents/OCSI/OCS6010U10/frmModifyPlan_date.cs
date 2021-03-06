using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using IHIS.Framework;

namespace IHIS.OCSI
{
	public class frmModifyPlan_date : IHIS.Framework.XForm
	{
		#region [Instance Variable]		
		//Message처리
		private string mbxMsg = "", mbxCap = "";
		private string mFkocs6010       = "";
		private string mPlan_order_date = "";
		#endregion

		private IHIS.Framework.XFlatLabel xFlatLabel1;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XDatePicker dpkPlan_date;
		private System.ComponentModel.IContainer components = null;

		public frmModifyPlan_date()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			// TODO: InitializeComponent를 호출한 다음 초기화 작업을 추가합니다.
		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifyPlan_date));
            this.dpkPlan_date = new IHIS.Framework.XDatePicker();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.SuspendLayout();
            // 
            // dpkPlan_date
            // 
            this.dpkPlan_date.IsJapanYearType = true;
            this.dpkPlan_date.Location = new System.Drawing.Point(138, 18);
            this.dpkPlan_date.Name = "dpkPlan_date";
            this.dpkPlan_date.Size = new System.Drawing.Size(112, 20);
            this.dpkPlan_date.TabIndex = 7;
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.Image = ((System.Drawing.Image)(resources.GetObject("xFlatLabel1.Image")));
            this.xFlatLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xFlatLabel1.Location = new System.Drawing.Point(20, 18);
            this.xFlatLabel1.Name = "xFlatLabel1";
            this.xFlatLabel1.Size = new System.Drawing.Size(110, 20);
            this.xFlatLabel1.TabIndex = 6;
            this.xFlatLabel1.Text = "     予約日付変更";
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.Location = new System.Drawing.Point(136, 70);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Process;
            this.xButtonList1.Size = new System.Drawing.Size(244, 34);
            this.xButtonList1.TabIndex = 9;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // frmModifyPlan_date
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(384, 126);
            this.ControlBox = false;
            this.Controls.Add(this.xButtonList1);
            this.Controls.Add(this.dpkPlan_date);
            this.Controls.Add(this.xFlatLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmModifyPlan_date";
            this.Load += new System.EventHandler(this.frmModifyPlan_date_Load);
            this.Controls.SetChildIndex(this.xFlatLabel1, 0);
            this.Controls.SetChildIndex(this.dpkPlan_date, 0);
            this.Controls.SetChildIndex(this.xButtonList1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region [Form]
        
		private void frmModifyPlan_date_Load(object sender, System.EventArgs e)
		{			
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{
			if(TypeCheck.IsNull(mFkocs6010))
				this.DialogResult = DialogResult.Cancel;

			if(TypeCheck.IsNull(mPlan_order_date))
				this.DialogResult = DialogResult.Cancel;
			else
				this.dpkPlan_date.SetDataValue(mPlan_order_date);

			dpkPlan_date.Focus();
			dpkPlan_date.SelectAll();

		}

		#endregion

		#region [properties]

		public string ModifyPlan_date
		{
			get
			{
				return mPlan_order_date;
			}
			set
			{
				mPlan_order_date = value;
			}
		}

		public string Fkocs6010
		{
			get
			{
				return mFkocs6010;
			}
			set
			{
				mFkocs6010 = value;
			}
		}
        
		#endregion

		#region [Button List Event]
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				
				case FunctionType.Process:
					
					e.IsBaseCall = false;

					if(!TypeCheck.IsDateTime(dpkPlan_date.GetDataValue()))
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "日付の入力に間違いがあります。 ご確認ください。" : "일자를 잘못 입력하셨습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
						break;
					}

					if(this.mPlan_order_date == this.dpkPlan_date.GetDataValue())
					{
						this.DialogResult = DialogResult.Cancel;
						break;
					}

					//현재일자 이후로만 변경이 가능하도록 한다.
					if( int.Parse(DateTime.Parse(dpkPlan_date.GetDataValue()).ToString("yyyyMMdd")) < int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "過去日付へ予約変更はできません。 ご確認ください。" : "현재일이후로만 예정변경이 가능합니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "予定変更" : "예정변경";
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
						break;
					}

					//현재 예정정용일자보다 변경하려는 일자가 작은지 check한다.
					if( !GetCheckModifyPlan_date(mFkocs6010, dpkPlan_date.GetDataValue()))
						break;
                    
					this.mPlan_order_date = this.dpkPlan_date.GetDataValue();
					this.DialogResult = DialogResult.OK;

					break;

				case FunctionType.Cancel:

					dpkPlan_date.SetDataValue(mPlan_order_date);

					break;


				case FunctionType.Close:

					this.DialogResult = DialogResult.Cancel;
					break;

				default:

					break;
			}
		}
		#endregion

		#region [Check]
        
		/// <summary>
		/// 수정하려는 예정일자가 현재예정계획 적용일자에 유효한지 check한다.
		/// </summary>
		/// <param name="aFkocs6010"></param>
		/// <param name="aModify_date"></param>
		/// <returns></returns>
		private bool GetCheckModifyPlan_date(string aFkocs6010, string aModify_date)
		{
			bool checkValue = true;

            string cmdText = "";
            object retVal  = null;
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_modify_date", aModify_date);
            bindVars.Add("f_fkocs6010",   aFkocs6010);
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

            cmdText = @"SELECT DECODE(SIGN(TO_DATE(:f_modify_date, 'YYYY/MM/DD') - APP_DATE), - 1, 'N', 'Y')
                          FROM OCS6010
                         WHERE HOSP_CODE = :f_hosp_code
                           AND PKOCS6010 = :f_fkocs6010";
            retVal = Service.ExecuteScalar(cmdText, bindVars);
            if (!TypeCheck.IsNull(retVal))
            {
                if (retVal.ToString().Equals("Y"))
                {
                    checkValue = true;
                }
                else
                {
                    mbxMsg = "予定変更は予定計画適用日の以降から可能です。";
                    mbxCap = "予定変更";
                    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
                    checkValue = false;
                }
            }
            else
            {
                checkValue = false;
            }

            return checkValue;
		}

		#endregion
	}
}

