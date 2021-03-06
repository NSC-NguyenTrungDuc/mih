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
	public class FormGetInputO2 : IHIS.Framework.XForm
	{
		////////////////////////////////// Screen Level 개발자 변수 기술 ///////////////////////////////////

        private MultiLayout mLayInputData = null;

		bool mIsOxygenCode = false; // 산소입력코드 여부

		//Control
		private Hashtable htControl   = new Hashtable();
		////////////////////////////////////////////////////////////////////////////////////////////////////

		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPanel pnlLeft;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XMemoBox xMemoBox1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XPanel pnlOxygenCode;
		private IHIS.Framework.XDisplayBox dbxHangmogName;
		private IHIS.Framework.XEditMask emMinute1;
		private IHIS.Framework.XEditMask emHour1;
		private IHIS.Framework.XEditMask emMinute_Suryang;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private IHIS.Framework.XPanel pnlOxygenCalc;
		private IHIS.Framework.XFlatLabel xFlatLabel1;
		private IHIS.Framework.XFlatLabel xFlatLabel2;
		private IHIS.Framework.XFlatLabel xFlatLabel3;
		private System.Windows.Forms.VScrollBar vsbDv;
		private IHIS.Framework.XEditMask emkDv;
		private IHIS.Framework.XDisplayBox xDisplayBox2;
		private System.Windows.Forms.VScrollBar vsbChange_qty;
		private IHIS.Framework.XEditMask emkChange_qty;
		private IHIS.Framework.XDisplayBox xDisplayBox1;
		private System.Windows.Forms.VScrollBar vsbFio2;
		private IHIS.Framework.XEditMask emkFio2;
		private IHIS.Framework.XDisplayBox xDisplayBox3;
		private System.ComponentModel.Container components = null;

		public FormGetInputO2()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGetInputO2));
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
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
            this.pnlOxygenCalc = new IHIS.Framework.XPanel();
            this.vsbFio2 = new System.Windows.Forms.VScrollBar();
            this.emkFio2 = new IHIS.Framework.XEditMask();
            this.xDisplayBox3 = new IHIS.Framework.XDisplayBox();
            this.vsbChange_qty = new System.Windows.Forms.VScrollBar();
            this.emkChange_qty = new IHIS.Framework.XEditMask();
            this.xDisplayBox1 = new IHIS.Framework.XDisplayBox();
            this.vsbDv = new System.Windows.Forms.VScrollBar();
            this.emkDv = new IHIS.Framework.XEditMask();
            this.xDisplayBox2 = new IHIS.Framework.XDisplayBox();
            this.xFlatLabel3 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel2 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlOxygenCode.SuspendLayout();
            this.pnlOxygenCalc.SuspendLayout();
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
            // pnlOxygenCalc
            // 
            this.pnlOxygenCalc.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.pnlOxygenCalc.Controls.Add(this.vsbFio2);
            this.pnlOxygenCalc.Controls.Add(this.emkFio2);
            this.pnlOxygenCalc.Controls.Add(this.xDisplayBox3);
            this.pnlOxygenCalc.Controls.Add(this.vsbChange_qty);
            this.pnlOxygenCalc.Controls.Add(this.emkChange_qty);
            this.pnlOxygenCalc.Controls.Add(this.xDisplayBox1);
            this.pnlOxygenCalc.Controls.Add(this.vsbDv);
            this.pnlOxygenCalc.Controls.Add(this.emkDv);
            this.pnlOxygenCalc.Controls.Add(this.xDisplayBox2);
            this.pnlOxygenCalc.Controls.Add(this.xFlatLabel3);
            this.pnlOxygenCalc.Controls.Add(this.xFlatLabel2);
            this.pnlOxygenCalc.Controls.Add(this.xFlatLabel1);
            resources.ApplyResources(this.pnlOxygenCalc, "pnlOxygenCalc");
            this.pnlOxygenCalc.DrawBorder = true;
            this.pnlOxygenCalc.Name = "pnlOxygenCalc";
            // 
            // vsbFio2
            // 
            resources.ApplyResources(this.vsbFio2, "vsbFio2");
            this.vsbFio2.Name = "vsbFio2";
            this.vsbFio2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsbNumber_Scroll);
            // 
            // emkFio2
            // 
            this.emkFio2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emkFio2.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.emkFio2, "emkFio2");
            this.emkFio2.MaxinumCipher = 3;
            this.emkFio2.Name = "emkFio2";
            this.emkFio2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.emkQty_KeyPress);
            // 
            // xDisplayBox3
            // 
            this.xDisplayBox3.BackColor = IHIS.Framework.XColor.XTextBoxBackColor;
            this.xDisplayBox3.EdgeRounding = false;
            resources.ApplyResources(this.xDisplayBox3, "xDisplayBox3");
            this.xDisplayBox3.Name = "xDisplayBox3";
            // 
            // vsbChange_qty
            // 
            resources.ApplyResources(this.vsbChange_qty, "vsbChange_qty");
            this.vsbChange_qty.Name = "vsbChange_qty";
            this.vsbChange_qty.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsbNumber_Scroll);
            // 
            // emkChange_qty
            // 
            this.emkChange_qty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emkChange_qty.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.emkChange_qty, "emkChange_qty");
            this.emkChange_qty.MaxinumCipher = 3;
            this.emkChange_qty.Name = "emkChange_qty";
            this.emkChange_qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.emkQty_KeyPress);
            // 
            // xDisplayBox1
            // 
            this.xDisplayBox1.BackColor = IHIS.Framework.XColor.XTextBoxBackColor;
            this.xDisplayBox1.EdgeRounding = false;
            resources.ApplyResources(this.xDisplayBox1, "xDisplayBox1");
            this.xDisplayBox1.Name = "xDisplayBox1";
            // 
            // vsbDv
            // 
            resources.ApplyResources(this.vsbDv, "vsbDv");
            this.vsbDv.Name = "vsbDv";
            this.vsbDv.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsbNumber_Scroll);
            // 
            // emkDv
            // 
            this.emkDv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emkDv.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.emkDv, "emkDv");
            this.emkDv.MaxinumCipher = 3;
            this.emkDv.Name = "emkDv";
            this.emkDv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.emkQty_KeyPress);
            // 
            // xDisplayBox2
            // 
            this.xDisplayBox2.BackColor = IHIS.Framework.XColor.XTextBoxBackColor;
            this.xDisplayBox2.EdgeRounding = false;
            resources.ApplyResources(this.xDisplayBox2, "xDisplayBox2");
            this.xDisplayBox2.Name = "xDisplayBox2";
            // 
            // xFlatLabel3
            // 
            this.xFlatLabel3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xFlatLabel3, "xFlatLabel3");
            this.xFlatLabel3.Name = "xFlatLabel3";
            // 
            // xFlatLabel2
            // 
            this.xFlatLabel2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xFlatLabel2, "xFlatLabel2");
            this.xFlatLabel2.Name = "xFlatLabel2";
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xFlatLabel1, "xFlatLabel1");
            this.xFlatLabel1.Name = "xFlatLabel1";
            // 
            // FormGetInputO2
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlOxygenCode);
            this.Controls.Add(this.pnlOxygenCalc);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLeft);
            this.Name = "FormGetInputO2";
            this.Controls.SetChildIndex(this.pnlLeft, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlOxygenCalc, 0);
            this.Controls.SetChildIndex(this.pnlOxygenCode, 0);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlOxygenCode.ResumeLayout(false);
            this.pnlOxygenCode.PerformLayout();
            this.pnlOxygenCalc.ResumeLayout(false);
            this.pnlOxygenCalc.PerformLayout();
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
				layOutputData.SetItemValue(insertRow, "minute_suryang", this.emMinute_Suryang.GetDataValue());
				layOutputData.SetItemValue(insertRow, "hour",           this.emHour1.GetDataValue());
				layOutputData.SetItemValue(insertRow, "minute",         this.emMinute1.GetDataValue());
				
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
			if (this.mLayInputData.RowCount ==  0) return false;

			this.dbxHangmogName.SetDataValue(this.mLayInputData.GetItemValue(0, "hangmog_code").ToString() + " - " + 
				this.mLayInputData.GetItemValue(0, "hangmog_name").ToString());

			this.emMinute_Suryang.SetDataValue(this.mLayInputData.GetItemDouble(0, "minute_suryang"));
			this.emHour1.SetDataValue(this.mLayInputData.GetItemDouble(0, "hour"));

            if(this.mLayInputData.GetItemDouble(0, "minute") > 0)
			    this.emMinute1.SetDataValue(this.mLayInputData.GetItemDouble(0, "minute"));
            else
                this.emMinute1.SetDataValue(1);
			

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
			SetControl(pnlOxygenCalc);
			this.emMinute_Suryang.Focus();
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


		#region [Control HashTable]

		/// <summary>
		/// 1.Hashtable에 각 DataControl를 Load시켜서 해당 Control의 제어를 용이하게 한다.
		/// </summary>
		private void SetControl(XPanel pnl)
		{
			string colName = "";

			foreach(object obj in pnl.Controls)
			{
				try
				{
					if( obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
					{
						colName = ((XComboBox)obj).Name.Substring(3).ToLower();
						htControl.Add(colName, obj);
					}
					else if( obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
					{
						colName = ((XTextBox)obj).Name.Substring(3).ToLower();
						htControl.Add(colName, obj);
					}
					else if( obj.GetType().Name.ToString().IndexOf("XEditMask" ) >= 0)
					{						
						colName = ((XEditMask)obj).Name.Substring(3).ToLower();
						htControl.Add(colName, obj);
					}
					else if( obj.GetType().ToString().IndexOf("XCheckBox" ) >= 0)
					{
						colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
						htControl.Add(colName, obj);
					}
					else if( obj.GetType().ToString().IndexOf("XDisplayBox" ) >= 0)
					{
						colName = ((XDisplayBox)obj).Name.Substring(3).ToLower();
						htControl.Add(colName, obj);									
					}
					else if( obj.GetType().ToString().IndexOf("XFindBox" ) >= 0)
					{
						colName = ((XFindBox)obj).Name.Substring(3).ToLower();
						htControl.Add(colName, obj);
					}	
					else if( obj.GetType().ToString().IndexOf("XDatePicker" ) >= 0)
					{
						colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
						htControl.Add(colName, obj);
					}
					
				}
				catch(Exception ex)
				{
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message);
				}
			}
		}

		#endregion

		#region [Scroll]
		/// <summary>
		/// Number인 경우 Scroll시 증가,감소처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void vsbNumber_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			VScrollBar vsb = sender as VScrollBar;
            
			string colName = vsb.Name.Substring(3).ToLower();
			
			double incrementValue = 1;
			double maxIncrement   = 999;
			double controlValue   = 0;
			
			switch (e.Type)
			{
				case System.Windows.Forms.ScrollEventType.LargeIncrement:
				case System.Windows.Forms.ScrollEventType.SmallIncrement:
					//감소
					controlValue = double.Parse(((IDataControl)htControl[colName]).DataValue.ToString() == "" ? "0" : ((IDataControl)htControl[colName]).DataValue.ToString());
					controlValue = controlValue - incrementValue;

					if(controlValue < 0 ) controlValue = 0;

					((IDataControl)htControl[colName]).DataValue = controlValue;

					break;
				case System.Windows.Forms.ScrollEventType.LargeDecrement:
				case System.Windows.Forms.ScrollEventType.SmallDecrement:

					//증가
					controlValue = double.Parse(((IDataControl)htControl[colName]).DataValue.ToString() == "" ? "0" : ((IDataControl)htControl[colName]).DataValue.ToString());
					controlValue = controlValue + incrementValue;

					if( controlValue >= maxIncrement) controlValue = 0;

					((IDataControl)htControl[colName]).DataValue = controlValue;
					
					break;
			}

			PostCallHelper.PostCall(new PostMethod(SetO2Suryang));
		}

		/// <summary>
		/// Time인 경우 Scroll시 증가,감소처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void vsbTime_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			VScrollBar vsb = sender as VScrollBar;            
			string colName = vsb.Name.Substring(3).ToLower();

			XEditMask editor = (XEditMask)htControl[colName];
			bool selectHour = true;
			int  selectStart = editor.SelectionStart;

			if(selectStart > 2)
				selectHour = false;
			
			int hours = 0;
			int min   = 0;

			if( TypeCheck.IsInt(editor.GetDataValue().ToString().PadRight(4).Substring(0, 2)) )
				hours = int.Parse(editor.GetDataValue().ToString().PadRight(4).Substring(0, 2));

			if( TypeCheck.IsInt(editor.GetDataValue().ToString().PadRight(4).Substring(2)) )
				min   = int.Parse(editor.GetDataValue().ToString().PadRight(4).Substring(2));
			
			switch (e.Type)
			{
				case System.Windows.Forms.ScrollEventType.LargeIncrement:
				case System.Windows.Forms.ScrollEventType.SmallIncrement:
					//감소
					if( selectHour )
					{
						hours = hours - 1;
						if( hours < 0 )
							hours = 23;
					}
					else
					{
						min = min - 1;
						if(min < 0)
						{
							min = 59;
							hours = hours - 1;
							if( hours < 0 )
								hours = 23;
						}
					}

					break;
				case System.Windows.Forms.ScrollEventType.LargeDecrement:
				case System.Windows.Forms.ScrollEventType.SmallDecrement:

					//증가
					//감소
					if( selectHour )
					{
						hours = hours + 1;
						if( hours >= 24 )
							hours = 0;
					}
					else
					{
						min = min + 1;
						if(min >= 60)
						{
							min = 0;
							hours = hours + 1;
							if( hours >= 24 )
								hours = 0;
						}
					}
					
					break;
			}

			editor.SetDataValue(hours.ToString("00") + min.ToString("00"));
			editor.SelectionStart = selectStart;
		}
		#endregion

		#region [산소량계산]

		private void emkQty_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			PostCallHelper.PostCall(new PostMethod(SetO2Suryang));
		}


		private void SetO2Suryang()
		{
			double suryang = CalO2Suryang();
			emMinute_Suryang.SetDataValue(suryang.ToString());
		}

		private double CalO2Suryang()
		{
			int    dv            = 0;
			if( TypeCheck.IsInt(emkDv.GetDataValue()) )
				dv = int.Parse(emkDv.GetDataValue());

			int    changeSuryang    = 0;
			if( TypeCheck.IsInt(emkChange_qty.GetDataValue()) )
				changeSuryang = int.Parse(emkChange_qty.GetDataValue());

			int    fio2          = 0;
			if( TypeCheck.IsInt(emkFio2.GetDataValue()) )
				fio2 = int.Parse(emkFio2.GetDataValue());

			double suryang       = 0.0;
			
			suryang = ((dv * changeSuryang * fio2)/10000.0)/10.0;

			return suryang;
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

					if ( TypeCheck.NVL(this.emMinute_Suryang.GetDataValue(), "0").ToString() == "0" ||
						(TypeCheck.NVL(this.emHour1.GetDataValue(), "0").ToString() == "0" && TypeCheck.NVL(this.emMinute1.GetDataValue(), "0").ToString() == "0"))
					{					
						mbxMsg = NetInfo.Language == LangMode.Jr ? "必ずデータを入力してください。" : "반드시 데이타를 입력하십시오.";
						mbxCap = "";
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

						return;
					}

					this.DialogResult = DialogResult.OK;
					break;
			}
		}
		#endregion

		
	}
}
