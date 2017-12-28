#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.DRGS
{
	/// <summary>
	/// DRG9001Q04에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG9001Q04 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XFindBox fbxDrg9001q04;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XDatePicker dtpDrg9001q041;
		private IHIS.Framework.XDatePicker dtpDrg9001q042;
//		private IHIS.Framework.XDataWindow dwDrg9001q04;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.MultiLayout LayDrg9001q04;
		private IHIS.Framework.XFindWorker fbxCommon;
		private IHIS.Framework.SingleLayout vsvCommon;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XComboBox cbxInOut;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem3;
		private IHIS.Framework.XComboItem xComboItem4;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XComboBox cboOrderBy;
		private IHIS.Framework.XComboItem xComboItem7;
		private IHIS.Framework.XComboItem xComboItem8;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XTextBox dbxDrg9001q04;
		private IHIS.Framework.FindColumnInfo findColumnInfo3;
		private IHIS.Framework.SingleLayout vsvInv0110;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DRG9001Q04()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG9001Q04));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dbxDrg9001q04 = new IHIS.Framework.XTextBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.cboOrderBy = new IHIS.Framework.XComboBox();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.cbxInOut = new IHIS.Framework.XComboBox();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.dtpDrg9001q042 = new IHIS.Framework.XDatePicker();
            this.dtpDrg9001q041 = new IHIS.Framework.XDatePicker();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.fbxDrg9001q04 = new IHIS.Framework.XFindBox();
            this.fbxCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.LayDrg9001q04 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.vsvCommon = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.vsvInv0110 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayDrg9001q04)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.dbxDrg9001q04);
            this.xPanel1.Controls.Add(this.xLabel5);
            this.xPanel1.Controls.Add(this.cboOrderBy);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Controls.Add(this.cbxInOut);
            this.xPanel1.Controls.Add(this.dtpDrg9001q042);
            this.xPanel1.Controls.Add(this.dtpDrg9001q041);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.fbxDrg9001q04);
            this.xPanel1.Controls.Add(this.xLabel1);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // dbxDrg9001q04
            // 
            resources.ApplyResources(this.dbxDrg9001q04, "dbxDrg9001q04");
            this.dbxDrg9001q04.Name = "dbxDrg9001q04";
            this.dbxDrg9001q04.ReadOnly = true;
            this.dbxDrg9001q04.TabStop = false;
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Name = "xLabel5";
            // 
            // cboOrderBy
            // 
            this.cboOrderBy.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem7,
            this.xComboItem8});
            resources.ApplyResources(this.cboOrderBy, "cboOrderBy");
            this.cboOrderBy.Name = "cboOrderBy";
            this.cboOrderBy.SelectedIndexChanged += new System.EventHandler(this.cboOrderBy_SelectedIndexChanged);
            this.cboOrderBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboOrderBy_KeyDown);
            // 
            // xComboItem7
            // 
            resources.ApplyResources(this.xComboItem7, "xComboItem7");
            this.xComboItem7.ValueItem = "1";
            // 
            // xComboItem8
            // 
            resources.ApplyResources(this.xComboItem8, "xComboItem8");
            this.xComboItem8.ValueItem = "2";
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // cbxInOut
            // 
            this.cbxInOut.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem2,
            this.xComboItem1,
            this.xComboItem4});
            resources.ApplyResources(this.cbxInOut, "cbxInOut");
            this.cbxInOut.Name = "cbxInOut";
            this.cbxInOut.SelectedIndexChanged += new System.EventHandler(this.cbxInOut_SelectedIndexChanged);
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "%";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "I";
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "O";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "W";
            // 
            // dtpDrg9001q042
            // 
            this.dtpDrg9001q042.IsJapanYearType = true;
            this.dtpDrg9001q042.IsVietnameseYearType = false;
            resources.ApplyResources(this.dtpDrg9001q042, "dtpDrg9001q042");
            this.dtpDrg9001q042.Name = "dtpDrg9001q042";
            this.dtpDrg9001q042.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDrg9001q042_DataValidating);
            // 
            // dtpDrg9001q041
            // 
            this.dtpDrg9001q041.IsJapanYearType = true;
            this.dtpDrg9001q041.IsVietnameseYearType = false;
            resources.ApplyResources(this.dtpDrg9001q041, "dtpDrg9001q041");
            this.dtpDrg9001q041.Name = "dtpDrg9001q041";
            this.dtpDrg9001q041.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDrg9001q041_DataValidating);
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // fbxDrg9001q04
            // 
            this.fbxDrg9001q04.AutoTabDataSelected = true;
            this.fbxDrg9001q04.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxDrg9001q04.FindWorker = this.fbxCommon;
            resources.ApplyResources(this.fbxDrg9001q04, "fbxDrg9001q04");
            this.fbxDrg9001q04.Name = "fbxDrg9001q04";
            this.fbxDrg9001q04.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxDrg9001q04_FindSelected);
            this.fbxDrg9001q04.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxDrg9001q04_DataValidating);
            this.fbxDrg9001q04.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fbxDrg9001q04_KeyDown);
            // 
            // fbxCommon
            // 
            this.fbxCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2,
            this.findColumnInfo3});
            this.fbxCommon.ExecuteQuery = null;
            this.fbxCommon.FormText = "材料コード";
            this.fbxCommon.InputSQL = resources.GetString("fbxCommon.InputSQL");
            this.fbxCommon.IsSetControlText = true;
            this.fbxCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fbxCommon.ParamList")));
            this.fbxCommon.SearchImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.fbxCommon.ServerFilter = true;
            this.fbxCommon.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fbxCommon_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "jaeryo_code";
            this.findColumnInfo1.ColWidth = 111;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "jaeryo_name";
            this.findColumnInfo2.ColWidth = 240;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo3.ColName = "bulyong_date";
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "Excel", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Reset, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList1.IsVisiblePreview = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // LayDrg9001q04
            // 
            this.LayDrg9001q04.ExecuteQuery = null;
            this.LayDrg9001q04.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18});
            this.LayDrg9001q04.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("LayDrg9001q04.ParamList")));
            this.LayDrg9001q04.QueryStarting += new System.ComponentModel.CancelEventHandler(this.LayDrg9001q04_QueryStarting);
            this.LayDrg9001q04.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.LayDrg9001q04_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "gwa";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "doctor";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "input_id";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "bunho";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "su_name";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "sex";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "age";
            this.multiLayoutItem7.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "gubun";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "chulgo_date";
            this.multiLayoutItem9.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "ord_suryang";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "nalsu";
            this.multiLayoutItem11.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "order_dauni_name";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "base_suryang";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "base_danui";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "base_suryang_sum";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "jaeryo_code_name";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "donbog_yn";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "donbog_dv";
            this.multiLayoutItem18.DataType = IHIS.Framework.DataType.Number;
            // 
            // vsvCommon
            // 
            this.vsvCommon.ExecuteQuery = null;
            this.vsvCommon.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.vsvCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvCommon.ParamList")));
            this.vsvCommon.QuerySQL = "SELECT JAERYO_NAME \r\n  FROM INV0110 \r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r" +
    "\n   AND JAERYO_CODE = :f_code";
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.dbxDrg9001q04;
            this.singleLayoutItem1.DataName = "dbxDrg9001q04";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // vsvInv0110
            // 
            this.vsvInv0110.ExecuteQuery = null;
            this.vsvInv0110.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.vsvInv0110.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvInv0110.ParamList")));
            this.vsvInv0110.QuerySQL = "validationServiceDyn1";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "jaeryo_name";
            this.singleLayoutItem2.IsUpdItem = true;
            // 
            // DRG9001Q04
            // 
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel3);
            this.Name = "DRG9001Q04";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.DRG9001Q04_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayDrg9001q04)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		private void DRG9001Q04_Load(object sender, System.EventArgs e)
		{
            this.dtpDrg9001q041.SetEditValue(EnvironInfo.GetSysDate().AddDays(-1).ToString("yyyy/MM/dd"));
            this.dtpDrg9001q042.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
			cboOrderBy.SetDataValue('1');
			cbxInOut.SetDataValue('%');
		}

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
	//				this.dwDrg9001q04.Reset();
                    this.LayDrg9001q04.QueryLayout(true);
					break;
				case FunctionType.Process:
	//				dwDrg9001q04.Export(true);
					break;
				case FunctionType.Print:
					e.IsBaseCall = false;
					//dwDrg9001q04.PrintProperties.PrinterName = "NEC MultiWriter1500N";
                    //try
                    //{
                    //    dwDrg9001q04.Print();
                    //} 
					//catch {}
					break;
			}
		}

		private void vsvCommon_PreServiceCall(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			vsvCommon.SetBindVarValue("f_code", e.DataValue);
      	}

		private void fbxDrg9001q04_FindSelected(object sender, IHIS.Framework.FindEventArgs e)
		{
			dbxDrg9001q04.SetDataValue(e.ReturnValues[1].ToString());
		}


		private void cbxInOut_SelectedIndexChanged(object sender, System.EventArgs e)
		{
  //          this.dwDrg9001q04.Reset();
            this.LayDrg9001q04.QueryLayout(true);
		}

		private void cboOrderBy_SelectedIndexChanged(object sender, System.EventArgs e)
		{
   //         this.dwDrg9001q04.Reset();
            this.LayDrg9001q04.QueryLayout(true);
		}

		private void dtpDrg9001q042_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
     //       this.dwDrg9001q04.Reset();
            this.LayDrg9001q04.QueryLayout(true);
		}

		private void dtpDrg9001q041_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
 //           this.dwDrg9001q04.Reset();
            this.LayDrg9001q04.QueryLayout(true);
		}

		private void vsvCommon_PostServiceCall(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
 //           this.dwDrg9001q04.Reset();
            this.LayDrg9001q04.QueryLayout(true);
		}

		private void fbxDrg9001q04_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Tab || e.KeyCode == System.Windows.Forms.Keys.Enter)
			{
				string name = string.Empty;

				this.vsvInv0110.QuerySQL = "";
                this.vsvInv0110.QuerySQL = "SELECT A.JAERYO_NAME  " +
					                       "  FROM INV0110 A      " +
					                       " WHERE A.HOSP_CODE = :f_hosp_code " +
                                           "   AND A.JAERYO_GUBUN = 'A' AND A.JAERYO_CODE = '" + this.fbxDrg9001q04.GetDataValue().ToString() + "'";
				this.vsvInv0110.LayoutItems.Clear();
                this.vsvInv0110.LayoutItems.Add("jaeryo_name");

                this.vsvInv0110.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

                this.vsvInv0110.QueryLayout();
                
                if (TypeCheck.IsNull(this.vsvInv0110.GetItemValue("jaeryo_name").ToString()) == true)
                {
                    this.fbxDrg9001q04.PopupFindDlg();
                }
                name = this.vsvInv0110.GetItemValue("jaeryo_name").ToString();
                this.dbxDrg9001q04.SetDataValue(name);
			}
		}

        private void LayDrg9001q04_QueryStarting(object sender, CancelEventArgs e)
        {
            if (this.cboOrderBy.GetDataValue() == "1")
            {
                /* 환산 수량을 재료코드를 기준으로 가져 와서 합계를 보여주지 못하는 케이스가 생김
                   그래서 환산 수량을 가져 오는 부분은 전부 항목코드로 변경(2007/03/27) */
                this.LayDrg9001q04.QuerySQL = @"SELECT FN_BAS_LOAD_GWA_NAME(C.GWA,  C.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(C.DOCTOR, C.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(C.INPUT_ID, C.ORDER_DATE)
                                                     , C.BUNHO
                                                     , D.SUNAME
                                                     , D.SEX
                                                     , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),D.BIRTH, 'XX')
                                                     , FN_ADM_DICT_NM('IN_OUT_GUBUN'   , 'O')
                                                     , A.ACT_DATE 
                                                     , SUM(C.SURYANG)
                                                     , C.NALSU
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',C.ORD_DANUI)
                                                     , FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,C.ORDER_DATE,C.ORD_DANUI,C.SURYANG)                        BASE_SURYANG
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',FN_DRG_CHANGE_ORDER_DANWI(C.HANGMOG_CODE,C.ORDER_DATE,C.ORD_DANUI)) BASE_DANUI
                                                     , SUM(FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,C.ORDER_DATE,C.ORD_DANUI,C.SURYANG)) * C.NALSU         BASE_SURYANG_SUM
                                                     , FN_INV_LOAD_JAERYO_NAME(C.HANGMOG_CODE)
                                                     , ''
                                                     , 0
                                                     , C.GWA||C.DOCTOR||A.ACT_DATE||C.BUNHO           KEY
                                                  FROM OUT0101 D
                                                      ,OCS1003 C
                                                      ,INJ1001 A
                                                 WHERE A.HOSP_CODE   = :f_hosp_code
                                                   AND C.HOSP_CODE   = A.HOSP_CODE
                                                   AND D.HOSP_CODE   = A.HOSP_CODE
                                                   AND A.ACT_DATE    BETWEEN TO_DATE(:f_from_date, 'YYYY/MM/DD')
                                                                         AND TO_DATE(:f_to_date, 'YYYY/MM/DD')
                                                   AND A.ACT_DATE IS NOT NULL
                                                   AND C.PKOCS1003 = A.FKOCS1003
                                                   AND C.HANGMOG_CODE = :f_jaeryo_code
                                                   AND :f_in_out_gubun IN ('O', '%')
                                                   AND D.BUNHO  = C.BUNHO
                                                   AND NVL(C.DC_YN, 'N') = 'N'
                                                 GROUP BY FN_BAS_LOAD_GWA_NAME(C.GWA,  C.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(C.DOCTOR, C.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(C.INPUT_ID, C.ORDER_DATE)
                                                     , C.BUNHO
                                                     , D.SUNAME
                                                     , D.SEX
                                                     , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),D.BIRTH, 'XX')
                                                     , FN_ADM_DICT_NM('IN_OUT_GUBUN'   , 'O')
                                                     , A.ACT_DATE 
                                                     , C.NALSU
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',C.ORD_DANUI)
                                                     , FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,C.ORDER_DATE,C.ORD_DANUI,C.SURYANG)
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',FN_DRG_CHANGE_ORDER_DANWI(C.HANGMOG_CODE,C.ORDER_DATE ,C.ORD_DANUI))
                                                     , FN_INV_LOAD_JAERYO_NAME(C.HANGMOG_CODE)
                                                     , C.GWA||C.DOCTOR||A.ACT_DATE||C.BUNHO
                                                UNION ALL
                                                SELECT FN_BAS_LOAD_GWA_NAME(A.GWA,  A.NAEWON_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(C.DOCTOR,  C.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(C.INPUT_ID,  C.ORDER_DATE)
                                                     , A.BUNHO
                                                     , B.SUNAME
                                                     , B.SEX
                                                     , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),B.BIRTH, 'XX')
                                                     , DECODE(NVL(A.WONYOI_ORDER_YN, 'N'), 'Y', FN_ADM_DICT_NM('WONYOI_ORDER_YN', 'Y')
                                                                                              , FN_ADM_DICT_NM('IN_OUT_GUBUN'   , 'O'))
                                                     , A.CHULGO_DATE 
                                                     , SUM(A.ORD_SURYANG)
                                                     , A.NALSU
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORDER_DANUI)
                                                     , FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)                   BASE_SURYANG
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',FN_DRG_CHANGE_ORDER_DANWI(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI)) BASE_DANUI
                                                     , CASE WHEN FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) = 'Y'
                                                            THEN SUM(FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)) * A.NALSU * A.DV
                                                            ELSE SUM(FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)) * A.NALSU END  BASE_SURYANG_SUM
                                                     , FN_INV_LOAD_JAERYO_NAME(A.JAERYO_CODE)
                                                     , FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                      DONBOG_YN
                                                     , CASE WHEN FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) = 'Y'
                                                            THEN A.DV
                                                            ELSE 0 END                                                  DONBOG_DV
                                                     , A.GWA||A.DOCTOR||A.CHULGO_DATE||A.BUNHO           KEY
                                                  FROM OCS1003 C
                                                      ,OUT0101 B
                                                      ,DRG2010 A
                                                 WHERE A.HOSP_CODE   = :f_hosp_code
                                                   AND B.HOSP_CODE   = A.HOSP_CODE
                                                   AND C.HOSP_CODE   = A.HOSP_CODE
                                                   AND A.CHULGO_DATE BETWEEN TO_DATE(:f_from_date, 'YYYY/MM/DD')
                                                                         AND TO_DATE(:f_to_date, 'YYYY/MM/DD')
                                                   AND A.JAERYO_CODE = :f_jaeryo_code
                                                   AND ( (:f_in_out_gubun = 'O' AND NVL(A.WONYOI_ORDER_YN, 'N') = 'N' )
                                                      OR (:f_in_out_gubun = '%' )
                                                       )
                                                   AND NVL(A.WONYOI_ORDER_YN,'N') = 'N'
                                                   AND B.BUNHO      = A.BUNHO
                                                   AND A.FKOCS1003  = C.PKOCS1003
                                                   AND NVL(C.DC_YN, 'N') = 'N'
                                                 GROUP BY FN_BAS_LOAD_GWA_NAME(A.GWA,  A.NAEWON_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(C.DOCTOR,  C.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(C.INPUT_ID,  C.ORDER_DATE)
                                                     , A.BUNHO
                                                     , B.SUNAME
                                                     , B.SEX
                                                     , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),B.BIRTH, 'XX')
                                                     , DECODE(NVL(A.WONYOI_ORDER_YN, 'N'), 'Y', FN_ADM_DICT_NM('WONYOI_ORDER_YN', 'Y')
                                                                                              , FN_ADM_DICT_NM('IN_OUT_GUBUN'   , 'O'))
                                                     , A.CHULGO_DATE  
                                                     , A.NALSU
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORDER_DANUI)
                                                     , FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',FN_DRG_CHANGE_ORDER_DANWI(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI))
                                                     , FN_INV_LOAD_JAERYO_NAME(A.JAERYO_CODE)
                                                     , FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)
                                                     , A.DV
                                                     , A.GWA||A.DOCTOR||A.CHULGO_DATE||A.BUNHO
                                                UNION ALL
                                                SELECT FN_BAS_LOAD_GWA_NAME(A.GWA,  A.NAEWON_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(C.DOCTOR,  C.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(C.INPUT_ID,  C.ORDER_DATE)
                                                     , A.BUNHO
                                                     , B.SUNAME
                                                     , B.SEX
                                                     , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),B.BIRTH, 'XX')
                                                     , DECODE(NVL(A.WONYOI_ORDER_YN, 'N'), 'Y', FN_ADM_DICT_NM('WONYOI_ORDER_YN', 'Y')
                                                                                              , FN_ADM_DICT_NM('IN_OUT_GUBUN'   , 'O'))
                                                     , A.JUBSU_DATE 
                                                     , SUM(A.ORD_SURYANG)
                                                     , A.NALSU
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORDER_DANUI)
                                                     , FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)                   BASE_SURYANG
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',FN_DRG_CHANGE_ORDER_DANWI(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI)) BASE_DANUI
                                                     , CASE WHEN FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) = 'Y'
                                                            THEN SUM(FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)) * A.NALSU * A.DV
                                                            ELSE SUM(FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)) * A.NALSU END  BASE_SURYANG_SUM
                                                     , FN_INV_LOAD_JAERYO_NAME(A.JAERYO_CODE)
                                                     , FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                      DONBOG_YN
                                                     , CASE WHEN FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) = 'Y'
                                                            THEN A.DV
                                                            ELSE 0 END                                                  DONBOG_DV
                                                     , A.GWA||A.DOCTOR||A.JUBSU_DATE||A.BUNHO           KEY
                                                  FROM OCS1003 C
                                                      ,OUT0101 B
                                                      ,DRG2010 A
                                                 WHERE A.HOSP_CODE   = :f_hosp_code
                                                   AND B.HOSP_CODE   = A.HOSP_CODE
                                                   AND C.HOSP_CODE   = A.HOSP_CODE
                                                   AND A.JUBSU_DATE BETWEEN TO_DATE(:f_from_date, 'YYYY/MM/DD')
                                                                        AND TO_DATE(:f_to_date, 'YYYY/MM/DD')
                                                   AND A.JAERYO_CODE = :f_jaeryo_code
                                                   AND ( (:f_in_out_gubun = 'W' AND NVL(A.WONYOI_ORDER_YN, 'N') = 'Y' )
                                                      OR (:f_in_out_gubun = '%' )
                                                       )
                                                   AND NVL(A.WONYOI_ORDER_YN,'N') = 'Y'
                                                   AND B.BUNHO      = A.BUNHO
                                                   AND A.FKOCS1003  = C.PKOCS1003
                                                   AND NVL(C.DC_YN, 'N') = 'N'
                                                 GROUP BY FN_BAS_LOAD_GWA_NAME(A.GWA,  A.NAEWON_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(C.DOCTOR,  C.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(C.INPUT_ID,  C.ORDER_DATE)
                                                     , A.BUNHO
                                                     , B.SUNAME
                                                     , B.SEX
                                                     , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),B.BIRTH, 'XX')
                                                     , DECODE(NVL(A.WONYOI_ORDER_YN, 'N'), 'Y', FN_ADM_DICT_NM('WONYOI_ORDER_YN', 'Y')
                                                                                              , FN_ADM_DICT_NM('IN_OUT_GUBUN'   , 'O'))
                                                     , A.JUBSU_DATE  
                                                     , A.NALSU
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORDER_DANUI)
                                                     , FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',FN_DRG_CHANGE_ORDER_DANWI(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI))
                                                     , FN_INV_LOAD_JAERYO_NAME(A.JAERYO_CODE)
                                                     , FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)
                                                     , A.DV
                                                     , A.GWA||A.DOCTOR||A.JUBSU_DATE||A.BUNHO     
                                                UNION ALL
                                                SELECT FN_BAS_LOAD_GWA_NAME(A.GWA,  A.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR,  A.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT,  A.ORDER_DATE)
                                                     , A.BUNHO
                                                     , B.SUNAME
                                                     , B.SEX
                                                     , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),B.BIRTH, 'XX')
                                                     , FN_ADM_DICT_NM('IN_OUT_GUBUN', 'I')
                                                     , A.CHULGO_DATE
                                                     , A.ORD_SURYANG
                                                     , SUM(A.NALSU)
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORDER_DANUI)                                                        ORDER_DANUI
                                                     , FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)                    BASE_SURYANG
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',FN_DRG_CHANGE_ORDER_DANWI(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI))  BASE_DANUI
                                                     , CASE WHEN FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) = 'Y'
                                                            THEN FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG) * SUM(A.NALSU) * A.DV
                                                            ELSE FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG) * SUM(A.NALSU) END   BASE_SURYANG_SUM
                                                     , FN_INV_LOAD_JAERYO_NAME(A.JAERYO_CODE)
                                                     , FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                      DONBOG_YN
                                                     , CASE WHEN FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) = 'Y'
                                                            THEN A.DV
                                                            ELSE 0 END                                                  DONBOG_DV
                                                     , a.GWA||a.DOCTOR||A.chulgo_date||B.BUNHO           KEY
                                                  FROM OCS2003 C
                                                      ,OUT0101 B
                                                      ,DRG3010 A
                                                 WHERE A.HOSP_CODE   = :f_hosp_code
                                                   AND B.HOSP_CODE   = A.HOSP_CODE
                                                   AND C.HOSP_CODE   = A.HOSP_CODE
                                                   AND A.CHULGO_DATE BETWEEN TO_DATE(:f_from_date, 'YYYY/MM/DD')
                                                                         AND TO_DATE(:f_to_date, 'YYYY/MM/DD')
                                                   AND A.JAERYO_CODE = :f_jaeryo_code
                                                   AND :f_in_out_gubun IN ('%', 'I')
                                                   AND A.CHULGO_DATE IS NOT NULL
                                                   AND B.BUNHO  = A.BUNHO
                                                   AND A.FKOCS2003  = C.PKOCS2003
                                                   AND NVL(C.DC_YN, 'N') = 'N'
                                                 GROUP BY FN_BAS_LOAD_GWA_NAME(A.GWA,  A.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR,  A.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT,  A.ORDER_DATE)
                                                     , A.BUNHO
                                                     , B.SUNAME
                                                     , B.SEX
                                                     , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),B.BIRTH, 'XX')
                                                     , FN_ADM_DICT_NM('IN_OUT_GUBUN', 'O')
                                                     , A.CHULGO_DATE
                                                     , A.ORD_SURYANG
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORDER_DANUI)
                                                     , FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',FN_DRG_CHANGE_ORDER_DANWI(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI))
                                                     , FN_INV_LOAD_JAERYO_NAME(A.JAERYO_CODE)
                                                     , FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)
                                                     , A.DV
                                                     , a.GWA||a.DOCTOR||A.chulgo_date||B.BUNHO
                                                 ORDER BY KEY";
            }
            else
            {
                this.LayDrg9001q04.QuerySQL = @"SELECT FN_BAS_LOAD_GWA_NAME(C.GWA,  C.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(C.DOCTOR, C.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(C.INPUT_ID, C.ORDER_DATE)
                                                     , C.BUNHO
                                                     , D.SUNAME
                                                     , D.SEX
                                                     , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),D.BIRTH, 'XX')
                                                     , FN_ADM_DICT_NM('IN_OUT_GUBUN'   , 'O')
                                                     , A.ACT_DATE 
                                                     , SUM(C.SURYANG)
                                                     , C.NALSU
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',C.ORD_DANUI)
                                                     , FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,C.ORDER_DATE,C.ORD_DANUI,C.SURYANG)                    BASE_SURYANG
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',FN_DRG_CHANGE_ORDER_DANWI(C.HANGMOG_CODE,C.ORDER_DATE,C.ORD_DANUI)) BASE_DANUI
                                                     , SUM(FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,C.ORDER_DATE,C.ORD_DANUI,C.SURYANG)) * C.NALSU     BASE_SURYANG_SUM
                                                     , FN_INV_LOAD_JAERYO_NAME(C.HANGMOG_CODE)
                                                     , ''                                                  
                                                     , 0                                                  
                                                     , TO_CHAR(A.ACT_DATE,'YYYYMMDD')||C.HANGMOG_CODE||A.BUNHO           KEY
                                                  FROM OUT0101 D
                                                      ,OCS1003 C
                                                      ,INJ1001 A
                                                 WHERE A.HOSP_CODE   = :f_hosp_code
                                                   AND C.HOSP_CODE   = A.HOSP_CODE
                                                   AND D.HOSP_CODE   = A.HOSP_CODE
                                                   AND A.ACT_DATE    >= TO_DATE(:f_from_date, 'YYYY/MM/DD')
                                                   AND A.ACT_DATE    <= TO_DATE(:f_to_date, 'YYYY/MM/DD')
                                                   AND A.ACT_DATE IS NOT NULL
                                                   AND C.PKOCS1003 = A.FKOCS1003
                                                   AND C.HANGMOG_CODE = :f_jaeryo_code
                                                   AND :f_in_out_gubun IN ('O', '%')
                                                   AND D.BUNHO  = C.BUNHO
                                                   AND NVL(C.DC_YN, 'N') = 'N'
                                                 GROUP BY FN_BAS_LOAD_GWA_NAME(C.GWA,  C.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(C.DOCTOR, C.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(C.INPUT_ID, C.ORDER_DATE)
                                                     , C.BUNHO
                                                     , D.SUNAME
                                                     , D.SEX
                                                     , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),D.BIRTH, 'XX')
                                                     , FN_ADM_DICT_NM('IN_OUT_GUBUN'   , 'O')
                                                     , A.ACT_DATE
                                                     , C.NALSU
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',C.ORD_DANUI)
                                                     , FN_DRG_CHANGE_ORDER_SURYANG(C.HANGMOG_CODE,C.ORDER_DATE,C.ORD_DANUI,C.SURYANG)
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',FN_DRG_CHANGE_ORDER_DANWI(C.HANGMOG_CODE,C.ORDER_DATE,C.ORD_DANUI))
                                                     , FN_INV_LOAD_JAERYO_NAME(C.HANGMOG_CODE)
                                                     , TO_CHAR(A.ACT_DATE,'YYYYMMDD')||C.HANGMOG_CODE||A.BUNHO
                                                UNION ALL
                                                SELECT
                                                       FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE)
                                                     , A.BUNHO
                                                     , B.SUNAME
                                                     , B.SEX
                                                     , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),B.BIRTH, 'XX')
                                                     , DECODE(NVL(A.WONYOI_ORDER_YN, 'N'), 'Y', FN_ADM_DICT_NM('WONYOI_ORDER_YN', 'Y')
                                                                                              , FN_ADM_DICT_NM('IN_OUT_GUBUN'   , 'O'))
                                                     , A.CHULGO_DATE
                                                     , SUM(A.ORD_SURYANG)
                                                     , A.NALSU
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORDER_DANUI)
                                                     , FN_DRG_CHANGE_ORDER_SURYANG(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)                    BASE_SURYANG
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',FN_DRG_CHANGE_ORDER_DANWI(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI)) BASE_DANUI
                                                     , CASE WHEN FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) = 'Y'
                                                            THEN SUM(FN_DRG_CHANGE_ORDER_SURYANG(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)) * A.NALSU * A.DV
                                                            ELSE SUM(FN_DRG_CHANGE_ORDER_SURYANG(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)) * A.NALSU END     BASE_SURYANG_SUM
                                                     , FN_INV_LOAD_JAERYO_NAME(A.JAERYO_CODE)
                                                     , FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                      DONBOG_YN
                                                     , CASE WHEN FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) = 'Y'
                                                            THEN A.DV
                                                            ELSE 0 END                                                  DONBOG_DV
                                                     , TO_CHAR(A.CHULGO_DATE,'YYYYMMDD')||A.JAERYO_CODE||A.BUNHO                    KEY
                                                  FROM OUT0101 B
                                                      ,DRG2010 A
                                                 WHERE A.HOSP_CODE   = :f_hosp_code
                                                   AND B.HOSP_CODE   = A.HOSP_CODE
                                                   AND A.CHULGO_DATE >= TO_DATE(:f_from_date, 'YYYY/MM/DD')
                                                   AND A.CHULGO_DATE <= TO_DATE(:f_to_date, 'YYYY/MM/DD') 
                                                   AND A.JAERYO_CODE = :f_jaeryo_code
                                                   AND ( (:f_in_out_gubun = 'O' AND NVL(A.WONYOI_ORDER_YN, 'N') = 'N') 
                                                      OR (:f_in_out_gubun = '%' ) 
                                                       )
                                                   AND NVL(A.WONYOI_ORDER_YN,'N') = 'N'    
                                                  -- AND A.CHULGO_DATE IS NOT NULL   
                                                   AND NVL(A.DC_YN, 'N') = 'N'
                                                   AND B.BUNHO  = A.BUNHO
                                                 GROUP BY A.CHULGO_DATE
                                                     , A.JAERYO_CODE
                                                     , FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE)
                                                     , A.BUNHO
                                                     , B.SUNAME
                                                     , B.SEX
                                                     , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),B.BIRTH, 'XX')
                                                     , DECODE(NVL(A.WONYOI_ORDER_YN, 'N'), 'Y', FN_ADM_DICT_NM('WONYOI_ORDER_YN', 'Y')
                                                                                              , FN_ADM_DICT_NM('IN_OUT_GUBUN'   , 'O'))
                                                     , A.NALSU
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORDER_DANUI)
                                                     , FN_DRG_CHANGE_ORDER_SURYANG(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)                    
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',FN_DRG_CHANGE_ORDER_DANWI(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI)) 
                                                     , FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)
                                                     , A.DV
                                                     , TO_CHAR(A.CHULGO_DATE,'YYYYMMDD')||A.JAERYO_CODE||A.BUNHO
                                                UNION ALL
                                                SELECT
                                                       FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE)
                                                     , A.BUNHO
                                                     , B.SUNAME
                                                     , B.SEX
                                                     , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),B.BIRTH, 'XX')
                                                     , DECODE(NVL(A.WONYOI_ORDER_YN, 'N'), 'Y', FN_ADM_DICT_NM('WONYOI_ORDER_YN', 'Y')
                                                                                              , FN_ADM_DICT_NM('IN_OUT_GUBUN'   , 'O'))
                                                     , A.JUBSU_DATE
                                                     , SUM(A.ORD_SURYANG)
                                                     , A.NALSU
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORDER_DANUI)
                                                     , FN_DRG_CHANGE_ORDER_SURYANG(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)                    BASE_SURYANG
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',FN_DRG_CHANGE_ORDER_DANWI(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI)) BASE_DANUI
                                                     , CASE WHEN FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) = 'Y'
                                                            THEN SUM(FN_DRG_CHANGE_ORDER_SURYANG(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)) * A.NALSU * A.DV
                                                            ELSE SUM(FN_DRG_CHANGE_ORDER_SURYANG(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)) * A.NALSU END     BASE_SURYANG_SUM
                                                     , FN_INV_LOAD_JAERYO_NAME(A.JAERYO_CODE)
                                                     , FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                      DONBOG_YN
                                                     , CASE WHEN FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) = 'Y'
                                                            THEN A.DV
                                                            ELSE 0 END                                                  DONBOG_DV
                                                     , TO_CHAR(A.JUBSU_DATE,'YYYYMMDD')||A.JAERYO_CODE||A.BUNHO                    KEY
                                                  FROM OUT0101 B
                                                      ,DRG2010 A
                                                 WHERE A.HOSP_CODE   = :f_hosp_code
                                                   AND B.HOSP_CODE   = A.HOSP_CODE
                                                   AND A.JUBSU_DATE >= TO_DATE(:f_from_date, 'YYYY/MM/DD')
                                                   AND A.JUBSU_DATE <= TO_DATE(:f_to_date, 'YYYY/MM/DD') 
                                                   AND A.JAERYO_CODE = :f_jaeryo_code
                                                   AND ( (:f_in_out_gubun = 'W' AND NVL(A.WONYOI_ORDER_YN, 'N') = 'Y') 
                                                      OR (:f_in_out_gubun = '%' ) 
                                                       )
                                                   AND NVL(A.WONYOI_ORDER_YN,'N') = 'Y'    
                                                  -- AND A.CHULGO_DATE IS NOT NULL   
                                                   AND NVL(A.DC_YN, 'N') = 'N'
                                                   AND B.BUNHO  = A.BUNHO
                                                 GROUP BY A.JUBSU_DATE
                                                     , A.JAERYO_CODE
                                                     , FN_BAS_LOAD_GWA_NAME(A.GWA, A.NAEWON_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE)
                                                     , A.BUNHO
                                                     , B.SUNAME
                                                     , B.SEX
                                                     , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),B.BIRTH, 'XX')
                                                     , DECODE(NVL(A.WONYOI_ORDER_YN, 'N'), 'Y', FN_ADM_DICT_NM('WONYOI_ORDER_YN', 'Y')
                                                                                              , FN_ADM_DICT_NM('IN_OUT_GUBUN'   , 'O'))
                                                     , A.NALSU
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORDER_DANUI)
                                                     , FN_DRG_CHANGE_ORDER_SURYANG(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)                    
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',FN_DRG_CHANGE_ORDER_DANWI(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI)) 
                                                     , FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)
                                                     , A.DV
                                                     , TO_CHAR(A.JUBSU_DATE,'YYYYMMDD')||A.JAERYO_CODE||A.BUNHO     
                                                UNION ALL
                                                SELECT FN_BAS_LOAD_GWA_NAME(A.GWA,  A.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR,  A.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT,  A.ORDER_DATE)
                                                     , A.BUNHO
                                                     , B.SUNAME
                                                     , B.SEX
                                                     , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),B.BIRTH, 'XX')
                                                     , FN_ADM_DICT_NM('IN_OUT_GUBUN', 'I')
                                                     , A.CHULGO_DATE
                                                     , A.ORD_SURYANG
                                                     , SUM(NALSU)
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORDER_DANUI)                                                       ORDER_DANUI
                                                     , FN_DRG_CHANGE_ORDER_SURYANG(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)                    BASE_SURYANG
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',FN_DRG_CHANGE_ORDER_DANWI(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI)) BASE_DANUI
                                                     , CASE WHEN FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) = 'Y'
                                                            THEN FN_DRG_CHANGE_ORDER_SURYANG(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG) * SUM(A.NALSU) * A.DV
                                                            ELSE FN_DRG_CHANGE_ORDER_SURYANG(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG) * SUM(A.NALSU) END   BASE_SURYANG_SUM
                                                     , FN_INV_LOAD_JAERYO_NAME(A.JAERYO_CODE)
                                                     , FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                      DONBOG_YN
                                                     , CASE WHEN FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) = 'Y'
                                                            THEN A.DV
                                                            ELSE 0 END                                                  DONBOG_DV
                                                     , TO_CHAR(A.CHULGO_DATE,'YYYYMMDD')||A.JAERYO_CODE||A.BUNHO                    KEY
                                                  FROM OUT0101 B
                                                      ,DRG3010 A
                                                 WHERE A.HOSP_CODE   = :f_hosp_code
                                                   AND B.HOSP_CODE   = A.HOSP_CODE
                                                   AND A.CHULGO_DATE >= TO_DATE(:f_from_date, 'YYYY/MM/DD')
                                                   AND A.CHULGO_DATE <= TO_DATE(:f_to_date, 'YYYY/MM/DD')   
                                                   AND A.JAERYO_CODE = :f_jaeryo_code        
                                                   AND :f_in_out_gubun IN ('%', 'I')
                                                   AND A.CHULGO_DATE IS NOT NULL                   
                                                   AND B.BUNHO  = A.BUNHO
                                                   AND NVL(A.DC_YN, 'N') = 'N'
                                                 GROUP BY A.CHULGO_DATE
                                                     , A.JAERYO_CODE
                                                     , FN_BAS_LOAD_GWA_NAME(A.GWA,  A.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR,  A.ORDER_DATE)
                                                     , FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT,  A.ORDER_DATE)
                                                     , A.BUNHO
                                                     , B.SUNAME
                                                     , B.SEX
                                                     , A.ORD_SURYANG
                                                     , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),B.BIRTH, 'XX')
                                                     , FN_ADM_DICT_NM('IN_OUT_GUBUN', 'O')
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORDER_DANUI)
                                                     , FN_DRG_CHANGE_ORDER_SURYANG(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI,A.ORD_SURYANG)                   
                                                     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',FN_DRG_CHANGE_ORDER_DANWI(A.JAERYO_CODE,A.ORDER_DATE,A.ORDER_DANUI))
                                                     , FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)
                                                     , A.DV
                                                     , TO_CHAR(A.CHULGO_DATE,'YYYYMMDD')||A.JAERYO_CODE||A.BUNHO
                                                 --ORDER BY 8,15,1,2;
                                                 ORDER BY 19";
            }

            this.LayDrg9001q04.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.LayDrg9001q04.SetBindVarValue("f_from_date", this.dtpDrg9001q041.GetDataValue());
            this.LayDrg9001q04.SetBindVarValue("f_to_date", this.dtpDrg9001q042.GetDataValue());
            this.LayDrg9001q04.SetBindVarValue("f_jaeryo_code", this.fbxDrg9001q04.GetDataValue());
            this.LayDrg9001q04.SetBindVarValue("f_in_out_gubun", this.cbxInOut.GetDataValue());
        }

        private void LayDrg9001q04_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //if (e.IsSuccess)
            //{
            //    if (this.cboOrderBy.GetDataValue() == "1")
            //        this.dwDrg9001q04.DataWindowObject = "drg9001q04";
            //    else
            //        this.dwDrg9001q04.DataWindowObject = "drg9001q04_2";

            //    this.dwDrg9001q04.Reset();
            //    this.dwDrg9001q04.FillData(this.LayDrg9001q04.LayoutTable);
            //    this.dwDrg9001q04.Modify("t_3.text = '" + this.dbxDrg9001q04.Text.ToString() + "'");
            //    this.dwDrg9001q04.Modify("t_5.text = '" + this.dtpDrg9001q041.Text.ToString() + "'");
            //    this.dwDrg9001q04.Modify("t_7.text = '" + this.dtpDrg9001q042.Text.ToString() + "'");
            //}
            //else
            //{
            //    XMessageBox.Show(Service.ErrFullMsg);
            //}
        }

        private void fbxCommon_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fbxCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void fbxDrg9001q04_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.vsvCommon.SetBindVarValue("f_code", e.DataValue);

            this.vsvCommon.QueryLayout();

            if (vsvCommon.GetItemValue("dbxDrg9001q04").ToString() == "")
            {
                e.Cancel = true;
                return;
            }
        }

        private void dwDrg9001q04_Click(object sender, EventArgs e)
        {
  //          this.dwDrg9001q04.Refresh();
        }

        private void dwDrg9001q04_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
   //         this.dwDrg9001q04.Refresh();
        }

        private void cboOrderBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.xButtonList1.PerformClick(FunctionType.Query);
            }
        }
	}
}

