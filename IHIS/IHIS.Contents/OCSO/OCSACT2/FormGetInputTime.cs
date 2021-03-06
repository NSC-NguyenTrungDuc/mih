using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;

namespace IHIS.OCSO
{
	/// <summary>
	/// FormSettingHopeDate에 대한 요약 설명입니다.
	/// </summary>
	public class FormGetInputTime : IHIS.Framework.XForm
	{
		////////////////////////////////// Screen Level 개발자 변수 기술 ///////////////////////////////////

		private MultiLayout mLayInputData = null;

		bool mIsOxygenCode = false; // 산소입력코드 여부
		////////////////////////////////////////////////////////////////////////////////////////////////////

		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XLabel lblNurse_Remark;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XMemoBox mbxNurse_Remark;
		private IHIS.Framework.XPanel pnlLeft;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XPanel pnlStandard;
		private IHIS.Framework.XMemoBox xMemoBox1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XPanel pnlOxygenCode;
		private IHIS.Framework.XEditMask emMinute;
		private IHIS.Framework.XEditMask emHour;
		private IHIS.Framework.XDisplayBox dbxHangmogName;
		private IHIS.Framework.XEditMask emMinute1;
		private IHIS.Framework.XEditMask emHour1;
		private IHIS.Framework.XEditMask emMinute_Suryang;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.ComponentModel.Container components = null;

		public FormGetInputTime()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGetInputTime));
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlStandard = new IHIS.Framework.XPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mbxNurse_Remark = new IHIS.Framework.XMemoBox();
            this.emMinute = new IHIS.Framework.XEditMask();
            this.emHour = new IHIS.Framework.XEditMask();
            this.lblNurse_Remark = new IHIS.Framework.XLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.dbxHangmogName = new IHIS.Framework.XDisplayBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlOxygenCode = new IHIS.Framework.XPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.emMinute_Suryang = new IHIS.Framework.XEditMask();
            this.emMinute1 = new IHIS.Framework.XEditMask();
            this.emHour1 = new IHIS.Framework.XEditMask();
            this.xMemoBox1 = new IHIS.Framework.XMemoBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlStandard.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlOxygenCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlBottom.Controls.Add(this.btnList);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlStandard
            // 
            resources.ApplyResources(this.pnlStandard, "pnlStandard");
            this.pnlStandard.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlStandard.Controls.Add(this.label1);
            this.pnlStandard.Controls.Add(this.label6);
            this.pnlStandard.Controls.Add(this.mbxNurse_Remark);
            this.pnlStandard.Controls.Add(this.emMinute);
            this.pnlStandard.Controls.Add(this.emHour);
            this.pnlStandard.Controls.Add(this.lblNurse_Remark);
            this.pnlStandard.Controls.Add(this.label7);
            this.pnlStandard.DrawBorder = true;
            this.pnlStandard.Name = "pnlStandard";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Name = "label1";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Name = "label6";
            // 
            // mbxNurse_Remark
            // 
            this.mbxNurse_Remark.DisplayMemoText = true;
            resources.ApplyResources(this.mbxNurse_Remark, "mbxNurse_Remark");
            this.mbxNurse_Remark.Name = "mbxNurse_Remark";
            // 
            // emMinute
            // 
            this.emMinute.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.emMinute, "emMinute");
            this.emMinute.GeneralNumberFormat = true;
            this.emMinute.MaxinumCipher = 3;
            this.emMinute.Name = "emMinute";
            // 
            // emHour
            // 
            this.emHour.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.emHour, "emHour");
            this.emHour.GeneralNumberFormat = true;
            this.emHour.MaxinumCipher = 3;
            this.emHour.Name = "emHour";
            // 
            // lblNurse_Remark
            // 
            this.lblNurse_Remark.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
            resources.ApplyResources(this.lblNurse_Remark, "lblNurse_Remark");
            this.lblNurse_Remark.Name = "lblNurse_Remark";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.DarkCyan;
            this.label7.Name = "label7";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlLeft.Controls.Add(this.dbxHangmogName);
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.DrawBorder = true;
            this.pnlLeft.Name = "pnlLeft";
            // 
            // dbxHangmogName
            // 
            resources.ApplyResources(this.dbxHangmogName, "dbxHangmogName");
            this.dbxHangmogName.Name = "dbxHangmogName";
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // pnlOxygenCode
            // 
            resources.ApplyResources(this.pnlOxygenCode, "pnlOxygenCode");
            this.pnlOxygenCode.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlOxygenCode.Controls.Add(this.label8);
            this.pnlOxygenCode.Controls.Add(this.label5);
            this.pnlOxygenCode.Controls.Add(this.label4);
            this.pnlOxygenCode.Controls.Add(this.emMinute_Suryang);
            this.pnlOxygenCode.Controls.Add(this.emMinute1);
            this.pnlOxygenCode.Controls.Add(this.emHour1);
            this.pnlOxygenCode.Controls.Add(this.xMemoBox1);
            this.pnlOxygenCode.Controls.Add(this.xLabel1);
            this.pnlOxygenCode.Controls.Add(this.label3);
            this.pnlOxygenCode.Controls.Add(this.label2);
            this.pnlOxygenCode.DrawBorder = true;
            this.pnlOxygenCode.Name = "pnlOxygenCode";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Name = "label8";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Name = "label4";
            // 
            // emMinute_Suryang
            // 
            this.emMinute_Suryang.DecimalDigits = 1;
            this.emMinute_Suryang.EditMaskType = IHIS.Framework.MaskType.Decimal;
            resources.ApplyResources(this.emMinute_Suryang, "emMinute_Suryang");
            this.emMinute_Suryang.GeneralNumberFormat = true;
            this.emMinute_Suryang.MaxinumCipher = 5;
            this.emMinute_Suryang.Name = "emMinute_Suryang";
            // 
            // emMinute1
            // 
            this.emMinute1.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.emMinute1, "emMinute1");
            this.emMinute1.GeneralNumberFormat = true;
            this.emMinute1.MaxinumCipher = 3;
            this.emMinute1.Name = "emMinute1";
            // 
            // emHour1
            // 
            this.emHour1.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.emHour1, "emHour1");
            this.emHour1.GeneralNumberFormat = true;
            this.emHour1.MaxinumCipher = 3;
            this.emHour1.Name = "emHour1";
            // 
            // xMemoBox1
            // 
            this.xMemoBox1.DisplayMemoText = true;
            resources.ApplyResources(this.xMemoBox1, "xMemoBox1");
            this.xMemoBox1.Name = "xMemoBox1";
            // 
            // xLabel1
            // 
            this.xLabel1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Name = "label2";
            // 
            // FormGetInputTime
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlOxygenCode);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlStandard);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLeft);
            this.Name = "FormGetInputTime";
            this.Controls.SetChildIndex(this.pnlLeft, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.pnlStandard, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlOxygenCode, 0);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlStandard.ResumeLayout(false);
            this.pnlStandard.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlOxygenCode.ResumeLayout(false);
            this.pnlOxygenCode.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region 부모 폼에서 얻어갈 값
		/// <summary>
		/// 부모 폼에서 얻어갈 값
		/// </summary>
		/// <returns> MultiLayout : 선택한 일자List </returns>
		public MultiLayout ReturnValue
		{			
			get
			{
				MultiLayout layOutputData = this.mLayInputData.Clone(); // 구조 Clone

				int insertRow = layOutputData.InsertRow(-1);
		
				if (this.mIsOxygenCode) // 산소입력코드 여부
				{
					layOutputData.SetItemValue(insertRow, "minute_suryang", this.emMinute_Suryang.GetDataValue());
					layOutputData.SetItemValue(insertRow, "hour",           this.emHour1.GetDataValue());
					layOutputData.SetItemValue(insertRow, "minute",         this.emMinute1.GetDataValue());
				}
				else
				{
					layOutputData.SetItemValue(insertRow, "minute_suryang", 0); // 분당주입량 입력안함
					layOutputData.SetItemValue(insertRow, "hour",           this.emHour.GetDataValue());
					layOutputData.SetItemValue(insertRow, "minute",         this.emMinute.GetDataValue());				
				}

				return layOutputData;
			}			
		}
		#endregion

		#region 부모 폼에서 받을 값 세팅
		/// <summary>
		/// 부모 폼에서 받을 값 세팅
		/// </summary>
		/// <param name="aLayInputData"> MultiLayout Input Date </param>
		/// <param name="aIsOxygenCode"> bool 산소입력코드 여부 </param>
		/// <returns> bool </returns>
		public bool GetValue(MultiLayout aLayInputData, bool aIsOxygenCode)
		{
			this.mLayInputData = aLayInputData;
						
			this.mIsOxygenCode = aIsOxygenCode;

			this.pnlOxygenCode.Visible = false; this.pnlStandard.Dock = DockStyle.Fill;   this.pnlStandard.BringToFront(); // 디폴트 처리

			if (this.mLayInputData.RowCount ==  0) return false;

			this.dbxHangmogName.SetDataValue(this.mLayInputData.GetItemValue(0, "hangmog_code").ToString() + " - " + 
											 this.mLayInputData.GetItemValue(0, "hangmog_name").ToString());

			if (this.mIsOxygenCode) // 산소입력코드 여부
			{
				this.pnlStandard.Visible   = false; 
				this.pnlOxygenCode.Visible = true; this.pnlOxygenCode.Dock = DockStyle.Fill; this.pnlOxygenCode.BringToFront();

				this.emMinute_Suryang.SetDataValue(this.mLayInputData.GetItemDouble(0, "minute_suryang"));
                if (this.mLayInputData.GetItemDouble(0, "hour") == 1
                    && this.mLayInputData.GetItemDouble(0, "minute") == 0)
                {
                    this.emHour1.SetDataValue("0");
                    this.emMinute1.SetDataValue("1");
                }
                else
                {
                    this.emHour1.SetDataValue(this.mLayInputData.GetItemDouble(0, "hour"));
                    this.emMinute1.SetDataValue(this.mLayInputData.GetItemDouble(0, "minute"));
                }
			}
			else
			{
                if (this.mLayInputData.GetItemDouble(0, "hour") == 1
                    && this.mLayInputData.GetItemDouble(0, "minute") == 0)
                {
                    this.emHour.SetDataValue("0");
                    this.emMinute.SetDataValue("1");
                }
                else
                {
                    this.emHour.SetDataValue(this.mLayInputData.GetItemDouble(0, "hour"));
                    this.emMinute.SetDataValue(this.mLayInputData.GetItemDouble(0, "minute"));
                }
			}

			return true;
		}
		#endregion

		///////////////////////////////////////////////////////////////////////////////////////////////////////
		#region [메소드 모듈]

		#endregion

		// Screen Load
		/// <summary>
		/// Screen Load시 Post Event로 Call 되서 Load시 처리할 로직들을 기술한다
		/// </summary>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			this.PostLoad();
		}
		private void PostLoad()
		{	
			if (this.mIsOxygenCode) // 산소입력코드 여부
			{
				this.emMinute_Suryang.Focus();
			}
			else
			{		
				this.emHour.Focus();
			}
		}

		#region 타Screen에서 Open (Command)	
		public override object Command(string command, CommonItemCollection commandParam)
		{                       
//			switch(command.Trim())
//			{
//				case "OCS0208Q00": // 사용자 복용코드조회
//					#region
//
//					if (commandParam.Contains("OCS0208") && (MultiLayout)commandParam["OCS0208"] != null && 
//						((MultiLayout)commandParam["OCS0208"]).RowCount > 0)
//					{
//						this.fbxBogyong_Code.Focus();						
//						this.fbxBogyong_Code.SetEditValue(((MultiLayout)commandParam["OCS0208"]).GetItemString(0, "bogyong_code"));
//						this.fbxBogyong_Code.AcceptData();
//					}
//					break;
//
//					#endregion
//			}
//
			return base.Command(command, commandParam);
		}
		#endregion

		#region buttonList ButtonList 클릭 Event : Find SQL조건 및 필드 정의 (btnList_ButtonClick)
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			string mbxMsg = "";
			string mbxCap = "";
			switch (e.Func)
			{
				case FunctionType.Cancel:  // 취소
					this.Reset(); // 화면 정보 Clear
					e.IsBaseCall = false;
					
					break;

				case FunctionType.Process: // 선택

					if (!this.AcceptData()) break;

					if (this.mIsOxygenCode) // 산소입력코드 여부
					{
						if ( TypeCheck.NVL(this.emMinute_Suryang.GetDataValue(), "0").ToString() == "0" ||
							(TypeCheck.NVL(this.emHour1.GetDataValue(), "0").ToString() == "0" && TypeCheck.NVL(this.emMinute1.GetDataValue(), "0").ToString() == "0"))
						{					
							mbxMsg = NetInfo.Language == LangMode.Jr ? "必ずデータを入力してください。" : "반드시 데이타를 입력하십시오.";
							mbxCap = "";
							XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

							return;
						}
					}
					else
					{
						if (TypeCheck.NVL(this.emHour.GetDataValue(), "0").ToString() == "0" && TypeCheck.NVL(this.emMinute.GetDataValue(), "0").ToString() == "0")
						{					
							mbxMsg = NetInfo.Language == LangMode.Jr ? "必ずデータを入力してください。" : "반드시 데이타를 입력하십시오.";
							mbxCap = "";
							XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

							return;
						}
					}

					this.DialogResult = DialogResult.OK;
					break;
			}
		}
		#endregion

	}
}
