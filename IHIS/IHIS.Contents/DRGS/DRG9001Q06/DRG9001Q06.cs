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
	/// DRG9001Q06에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG9001Q06 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XFindWorker fbxCommon;
		private IHIS.Framework.SingleLayout vsvCommon;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XComboBox cbxInOut;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem3;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XLabel xLabel7;
//		private IHIS.Framework.XDataWindow dw_drug;
		private IHIS.Framework.XDatePicker dtpOrderDate;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XPatientBox xPatientBox1;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.MultiLayout layDrugList;
		private IHIS.Framework.XDictComboBox cbxOrderGubun;
		private IHIS.Framework.XFindBox fbxJundalPart;
		private IHIS.Framework.XTextBox tbxJundalPartName;
		private IHIS.Framework.SingleLayout dsvJundalPartName;
		private IHIS.Framework.MultiLayout layExcel;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XGroupBox xGroupBox1;
		private IHIS.Framework.XFlatRadioButton rbtOrder;
		private IHIS.Framework.XFlatRadioButton rbtActing;
        private IHIS.Framework.MultiLayout layExcelAct;
        private MultiLayoutItem multiLayoutItem56;
        private MultiLayoutItem multiLayoutItem57;
        private MultiLayoutItem multiLayoutItem58;
        private MultiLayoutItem multiLayoutItem59;
        private MultiLayoutItem multiLayoutItem60;
        private MultiLayoutItem multiLayoutItem61;
        private MultiLayoutItem multiLayoutItem62;
        private MultiLayoutItem multiLayoutItem63;
        private MultiLayoutItem multiLayoutItem64;
        private MultiLayoutItem multiLayoutItem65;
        private MultiLayoutItem multiLayoutItem66;
        private MultiLayoutItem multiLayoutItem67;
        private MultiLayoutItem multiLayoutItem68;
        private MultiLayoutItem multiLayoutItem69;
        private MultiLayoutItem multiLayoutItem70;
        private MultiLayoutItem multiLayoutItem71;
        private MultiLayoutItem multiLayoutItem72;
        private MultiLayoutItem multiLayoutItem39;
        private MultiLayoutItem multiLayoutItem40;
        private MultiLayoutItem multiLayoutItem41;
        private MultiLayoutItem multiLayoutItem42;
        private MultiLayoutItem multiLayoutItem43;
        private MultiLayoutItem multiLayoutItem44;
        private MultiLayoutItem multiLayoutItem45;
        private MultiLayoutItem multiLayoutItem46;
        private MultiLayoutItem multiLayoutItem47;
        private MultiLayoutItem multiLayoutItem48;
        private MultiLayoutItem multiLayoutItem49;
        private MultiLayoutItem multiLayoutItem50;
        private MultiLayoutItem multiLayoutItem51;
        private MultiLayoutItem multiLayoutItem52;
        private MultiLayoutItem multiLayoutItem53;
        private MultiLayoutItem multiLayoutItem54;
        private MultiLayoutItem multiLayoutItem55;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem36;
        private SingleLayoutItem singleLayoutItem1;
        private XGrid grdExcel;
        private XGridCell xGridCell1;
        private XGridCell xGridCell2;
        private XGridCell xGridCell3;
        private XGridCell xGridCell4;
        private XGridCell xGridCell5;
        private XGridCell xGridCell6;
        private XGridCell xGridCell7;
        private XGridCell xGridCell8;
        private XGridCell xGridCell9;
        private XGridCell xGridCell10;
        private XGridCell xGridCell11;
        private XGridCell xGridCell12;
        private XGridCell xGridCell13;
        private XGridCell xGridCell14;
        private XGridCell xGridCell15;
        private XGridCell xGridCell16;
        private XGridCell xGridCell17;
        private XGrid grdExcelAct;
        private XGridCell xGridCell18;
        private XGridCell xGridCell19;
        private XGridCell xGridCell20;
        private XGridCell xGridCell21;
        private XGridCell xGridCell22;
        private XGridCell xGridCell23;
        private XGridCell xGridCell24;
        private XGridCell xGridCell25;
        private XGridCell xGridCell26;
        private XGridCell xGridCell27;
        private XGridCell xGridCell28;
        private XGridCell xGridCell29;
        private XGridCell xGridCell30;
        private XGridCell xGridCell31;
        private XGridCell xGridCell32;
        private XGridCell xGridCell33;
        private XGridCell xGridCell34;
        private DataGridView dgvExcel;
        private DataGridViewTextBoxColumn bunho;
        private DataGridViewTextBoxColumn suname;
        private DataGridViewTextBoxColumn order_date;
        private DataGridViewTextBoxColumn gwa_name;
        private DataGridViewTextBoxColumn doctor_name;
        private DataGridViewTextBoxColumn in_out_gubun_name;
        private DataGridViewTextBoxColumn order_gubun_name;
        private DataGridViewTextBoxColumn hangmog_code;
        private DataGridViewTextBoxColumn hangmog_name;
        private DataGridViewTextBoxColumn suryang;
        private DataGridViewTextBoxColumn ord_danui_name;
        private DataGridViewTextBoxColumn dv_time;
        private DataGridViewTextBoxColumn dv;
        private DataGridViewTextBoxColumn nalsu;
        private DataGridViewTextBoxColumn input_id_name;
        private DataGridViewTextBoxColumn hope_date;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DRG9001Q06()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG9001Q06));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xGroupBox1 = new IHIS.Framework.XGroupBox();
            this.rbtActing = new IHIS.Framework.XFlatRadioButton();
            this.rbtOrder = new IHIS.Framework.XFlatRadioButton();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.tbxJundalPartName = new IHIS.Framework.XTextBox();
            this.fbxJundalPart = new IHIS.Framework.XFindBox();
            this.fbxCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.cbxOrderGubun = new IHIS.Framework.XDictComboBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.cbxInOut = new IHIS.Framework.XComboBox();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.dtpOrderDate = new IHIS.Framework.XDatePicker();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xPatientBox1 = new IHIS.Framework.XPatientBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layDrugList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.vsvCommon = new IHIS.Framework.SingleLayout();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.dgvExcel = new System.Windows.Forms.DataGridView();
            this.bunho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gwa_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctor_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.in_out_gubun_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_gubun_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hangmog_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hangmog_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suryang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ord_danui_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dv_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nalsu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.input_id_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hope_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdExcelAct = new IHIS.Framework.XGrid();
            this.xGridCell18 = new IHIS.Framework.XGridCell();
            this.xGridCell19 = new IHIS.Framework.XGridCell();
            this.xGridCell20 = new IHIS.Framework.XGridCell();
            this.xGridCell21 = new IHIS.Framework.XGridCell();
            this.xGridCell22 = new IHIS.Framework.XGridCell();
            this.xGridCell23 = new IHIS.Framework.XGridCell();
            this.xGridCell24 = new IHIS.Framework.XGridCell();
            this.xGridCell25 = new IHIS.Framework.XGridCell();
            this.xGridCell26 = new IHIS.Framework.XGridCell();
            this.xGridCell27 = new IHIS.Framework.XGridCell();
            this.xGridCell28 = new IHIS.Framework.XGridCell();
            this.xGridCell29 = new IHIS.Framework.XGridCell();
            this.xGridCell30 = new IHIS.Framework.XGridCell();
            this.xGridCell31 = new IHIS.Framework.XGridCell();
            this.xGridCell32 = new IHIS.Framework.XGridCell();
            this.xGridCell33 = new IHIS.Framework.XGridCell();
            this.xGridCell34 = new IHIS.Framework.XGridCell();
            this.grdExcel = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.xGridCell6 = new IHIS.Framework.XGridCell();
            this.xGridCell7 = new IHIS.Framework.XGridCell();
            this.xGridCell8 = new IHIS.Framework.XGridCell();
            this.xGridCell9 = new IHIS.Framework.XGridCell();
            this.xGridCell10 = new IHIS.Framework.XGridCell();
            this.xGridCell11 = new IHIS.Framework.XGridCell();
            this.xGridCell12 = new IHIS.Framework.XGridCell();
            this.xGridCell13 = new IHIS.Framework.XGridCell();
            this.xGridCell14 = new IHIS.Framework.XGridCell();
            this.xGridCell15 = new IHIS.Framework.XGridCell();
            this.xGridCell16 = new IHIS.Framework.XGridCell();
            this.xGridCell17 = new IHIS.Framework.XGridCell();
            this.dsvJundalPartName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layExcel = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem57 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem58 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem59 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem60 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem61 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem62 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem63 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem64 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem65 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem66 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem67 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem68 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem69 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem70 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem71 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem72 = new IHIS.Framework.MultiLayoutItem();
            this.layExcelAct = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem40 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem52 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPatientBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDrugList)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExcelAct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layExcelAct)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xGroupBox1);
            this.xPanel1.Controls.Add(this.xLabel5);
            this.xPanel1.Controls.Add(this.tbxJundalPartName);
            this.xPanel1.Controls.Add(this.fbxJundalPart);
            this.xPanel1.Controls.Add(this.cbxOrderGubun);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.xLabel7);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Controls.Add(this.cbxInOut);
            this.xPanel1.Controls.Add(this.dtpOrderDate);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.xPatientBox1);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xGroupBox1
            // 
            this.xGroupBox1.Controls.Add(this.rbtActing);
            this.xGroupBox1.Controls.Add(this.rbtOrder);
            resources.ApplyResources(this.xGroupBox1, "xGroupBox1");
            this.xGroupBox1.Name = "xGroupBox1";
            this.xGroupBox1.Protect = true;
            this.xGroupBox1.TabStop = false;
            // 
            // rbtActing
            // 
            resources.ApplyResources(this.rbtActing, "rbtActing");
            this.rbtActing.Name = "rbtActing";
            this.rbtActing.UseVisualStyleBackColor = false;
            this.rbtActing.CheckedChanged += new System.EventHandler(this.rbtActing_CheckedChanged);
            // 
            // rbtOrder
            // 
            this.rbtOrder.Checked = true;
            resources.ApplyResources(this.rbtOrder, "rbtOrder");
            this.rbtOrder.Name = "rbtOrder";
            this.rbtOrder.TabStop = true;
            this.rbtOrder.UseVisualStyleBackColor = false;
            this.rbtOrder.CheckedChanged += new System.EventHandler(this.rbtOrder_CheckedChanged);
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Name = "xLabel5";
            // 
            // tbxJundalPartName
            // 
            resources.ApplyResources(this.tbxJundalPartName, "tbxJundalPartName");
            this.tbxJundalPartName.Name = "tbxJundalPartName";
            this.tbxJundalPartName.ReadOnly = true;
            this.tbxJundalPartName.TabStop = false;
            // 
            // fbxJundalPart
            // 
            this.fbxJundalPart.FindWorker = this.fbxCommon;
            resources.ApplyResources(this.fbxJundalPart, "fbxJundalPart");
            this.fbxJundalPart.Name = "fbxJundalPart";
            this.fbxJundalPart.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxJundalPart_DataValidating);
            // 
            // fbxCommon
            // 
            this.fbxCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fbxCommon.ExecuteQuery = null;
            this.fbxCommon.InputSQL = resources.GetString("fbxCommon.InputSQL");
            this.fbxCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fbxCommon.ParamList")));
            this.fbxCommon.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "jaeryo_code";
            this.findColumnInfo1.ColWidth = 111;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "jaeryo_name";
            this.findColumnInfo2.ColWidth = 231;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // cbxOrderGubun
            // 
            this.cbxOrderGubun.ExecuteQuery = null;
            resources.ApplyResources(this.cbxOrderGubun, "cbxOrderGubun");
            this.cbxOrderGubun.Name = "cbxOrderGubun";
            this.cbxOrderGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxOrderGubun.ParamList")));
            this.cbxOrderGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxOrderGubun.UserSQL = resources.GetString("cbxOrderGubun.UserSQL");
            this.cbxOrderGubun.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.cbxOrderGubun_DataValidating);
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xLabel7
            // 
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Name = "xLabel7";
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
            this.xComboItem1});
            resources.ApplyResources(this.cbxInOut, "cbxInOut");
            this.cbxInOut.Name = "cbxInOut";
            this.cbxInOut.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.cbxInOut_DataValidating);
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
            // dtpOrderDate
            // 
            this.dtpOrderDate.IsJapanYearType = true;
            this.dtpOrderDate.IsVietnameseYearType = false;
            resources.ApplyResources(this.dtpOrderDate, "dtpOrderDate");
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpOrderDate_DataValidating);
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // xPatientBox1
            // 
            resources.ApplyResources(this.xPatientBox1, "xPatientBox1");
            this.xPatientBox1.Name = "xPatientBox1";
            this.xPatientBox1.PatientSelected += new System.EventHandler(this.xPatientBox1_PatientSelected);
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "Excel", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Reset, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisiblePreview = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // layDrugList
            // 
            this.layDrugList.ExecuteQuery = null;
            this.layDrugList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem34,
            this.multiLayoutItem35,
            this.multiLayoutItem36});
            this.layDrugList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDrugList.ParamList")));
            this.layDrugList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDrugList_QueryStarting);
            this.layDrugList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layDrugList_QueryEnd);
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "bunho";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "suname";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "gwa_name";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "doctor_name";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "in_out_gubun";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "order_gubun";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "jaeryo_code";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "jaeryo_name";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "suryang";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "ord_danui_name";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "input_id_name";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "input_gubun_name";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "order_date";
            this.multiLayoutItem31.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "dv_time";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "dv";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "order_gubun_name";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "nalsu";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "gubun";
            // 
            // vsvCommon
            // 
            this.vsvCommon.ExecuteQuery = null;
            this.vsvCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvCommon.ParamList")));
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.dgvExcel);
            this.xPanel3.Controls.Add(this.grdExcelAct);
            this.xPanel3.Controls.Add(this.grdExcel);
            this.xPanel3.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // dgvExcel
            // 
            this.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bunho,
            this.suname,
            this.order_date,
            this.gwa_name,
            this.doctor_name,
            this.in_out_gubun_name,
            this.order_gubun_name,
            this.hangmog_code,
            this.hangmog_name,
            this.suryang,
            this.ord_danui_name,
            this.dv_time,
            this.dv,
            this.nalsu,
            this.input_id_name,
            this.hope_date});
            resources.ApplyResources(this.dgvExcel, "dgvExcel");
            this.dgvExcel.Name = "dgvExcel";
            this.dgvExcel.RowTemplate.Height = 21;
            // 
            // bunho
            // 
            resources.ApplyResources(this.bunho, "bunho");
            this.bunho.Name = "bunho";
            // 
            // suname
            // 
            resources.ApplyResources(this.suname, "suname");
            this.suname.Name = "suname";
            // 
            // order_date
            // 
            resources.ApplyResources(this.order_date, "order_date");
            this.order_date.Name = "order_date";
            // 
            // gwa_name
            // 
            resources.ApplyResources(this.gwa_name, "gwa_name");
            this.gwa_name.Name = "gwa_name";
            // 
            // doctor_name
            // 
            resources.ApplyResources(this.doctor_name, "doctor_name");
            this.doctor_name.Name = "doctor_name";
            // 
            // in_out_gubun_name
            // 
            resources.ApplyResources(this.in_out_gubun_name, "in_out_gubun_name");
            this.in_out_gubun_name.Name = "in_out_gubun_name";
            // 
            // order_gubun_name
            // 
            resources.ApplyResources(this.order_gubun_name, "order_gubun_name");
            this.order_gubun_name.Name = "order_gubun_name";
            // 
            // hangmog_code
            // 
            resources.ApplyResources(this.hangmog_code, "hangmog_code");
            this.hangmog_code.Name = "hangmog_code";
            // 
            // hangmog_name
            // 
            resources.ApplyResources(this.hangmog_name, "hangmog_name");
            this.hangmog_name.Name = "hangmog_name";
            // 
            // suryang
            // 
            resources.ApplyResources(this.suryang, "suryang");
            this.suryang.Name = "suryang";
            // 
            // ord_danui_name
            // 
            resources.ApplyResources(this.ord_danui_name, "ord_danui_name");
            this.ord_danui_name.Name = "ord_danui_name";
            // 
            // dv_time
            // 
            resources.ApplyResources(this.dv_time, "dv_time");
            this.dv_time.Name = "dv_time";
            // 
            // dv
            // 
            resources.ApplyResources(this.dv, "dv");
            this.dv.Name = "dv";
            // 
            // nalsu
            // 
            resources.ApplyResources(this.nalsu, "nalsu");
            this.nalsu.Name = "nalsu";
            // 
            // input_id_name
            // 
            resources.ApplyResources(this.input_id_name, "input_id_name");
            this.input_id_name.Name = "input_id_name";
            // 
            // hope_date
            // 
            resources.ApplyResources(this.hope_date, "hope_date");
            this.hope_date.Name = "hope_date";
            // 
            // grdExcelAct
            // 
            this.grdExcelAct.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell18,
            this.xGridCell19,
            this.xGridCell20,
            this.xGridCell21,
            this.xGridCell22,
            this.xGridCell23,
            this.xGridCell24,
            this.xGridCell25,
            this.xGridCell26,
            this.xGridCell27,
            this.xGridCell28,
            this.xGridCell29,
            this.xGridCell30,
            this.xGridCell31,
            this.xGridCell32,
            this.xGridCell33,
            this.xGridCell34});
            this.grdExcelAct.ColPerLine = 17;
            this.grdExcelAct.Cols = 17;
            this.grdExcelAct.ExecuteQuery = null;
            this.grdExcelAct.FixedRows = 1;
            this.grdExcelAct.HeaderHeights.Add(12);
            resources.ApplyResources(this.grdExcelAct, "grdExcelAct");
            this.grdExcelAct.Name = "grdExcelAct";
            this.grdExcelAct.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdExcelAct.ParamList")));
            this.grdExcelAct.QuerySQL = resources.GetString("grdExcelAct.QuerySQL");
            this.grdExcelAct.Rows = 2;
            this.grdExcelAct.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdExcelAct_QueryStarting);
            this.grdExcelAct.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdExcelAct_QueryEnd);
            // 
            // xGridCell18
            // 
            this.xGridCell18.CellName = "bunho";
            resources.ApplyResources(this.xGridCell18, "xGridCell18");
            // 
            // xGridCell19
            // 
            this.xGridCell19.CellName = "suname";
            this.xGridCell19.Col = 1;
            resources.ApplyResources(this.xGridCell19, "xGridCell19");
            // 
            // xGridCell20
            // 
            this.xGridCell20.CellName = "order_date";
            this.xGridCell20.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell20.Col = 2;
            resources.ApplyResources(this.xGridCell20, "xGridCell20");
            // 
            // xGridCell21
            // 
            this.xGridCell21.CellName = "gwa_name";
            this.xGridCell21.Col = 3;
            resources.ApplyResources(this.xGridCell21, "xGridCell21");
            // 
            // xGridCell22
            // 
            this.xGridCell22.CellName = "doctor_name";
            this.xGridCell22.Col = 4;
            resources.ApplyResources(this.xGridCell22, "xGridCell22");
            // 
            // xGridCell23
            // 
            this.xGridCell23.CellName = "in_out_gubun_name";
            this.xGridCell23.Col = 5;
            resources.ApplyResources(this.xGridCell23, "xGridCell23");
            // 
            // xGridCell24
            // 
            this.xGridCell24.CellName = "order_gubun_name";
            this.xGridCell24.Col = 6;
            resources.ApplyResources(this.xGridCell24, "xGridCell24");
            // 
            // xGridCell25
            // 
            this.xGridCell25.CellName = "hangmog_code";
            this.xGridCell25.Col = 7;
            resources.ApplyResources(this.xGridCell25, "xGridCell25");
            // 
            // xGridCell26
            // 
            this.xGridCell26.CellName = "hangmog_name";
            this.xGridCell26.Col = 8;
            resources.ApplyResources(this.xGridCell26, "xGridCell26");
            // 
            // xGridCell27
            // 
            this.xGridCell27.CellName = "suryang";
            this.xGridCell27.Col = 9;
            resources.ApplyResources(this.xGridCell27, "xGridCell27");
            // 
            // xGridCell28
            // 
            this.xGridCell28.CellName = "ord_danui_name";
            this.xGridCell28.Col = 10;
            resources.ApplyResources(this.xGridCell28, "xGridCell28");
            // 
            // xGridCell29
            // 
            this.xGridCell29.CellName = "dv_time";
            this.xGridCell29.Col = 11;
            resources.ApplyResources(this.xGridCell29, "xGridCell29");
            // 
            // xGridCell30
            // 
            this.xGridCell30.CellName = "dv";
            this.xGridCell30.Col = 12;
            resources.ApplyResources(this.xGridCell30, "xGridCell30");
            // 
            // xGridCell31
            // 
            this.xGridCell31.CellName = "nalsu";
            this.xGridCell31.Col = 13;
            resources.ApplyResources(this.xGridCell31, "xGridCell31");
            // 
            // xGridCell32
            // 
            this.xGridCell32.CellName = "input_id_name";
            this.xGridCell32.Col = 14;
            resources.ApplyResources(this.xGridCell32, "xGridCell32");
            // 
            // xGridCell33
            // 
            this.xGridCell33.CellName = "hope_date";
            this.xGridCell33.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell33.Col = 15;
            resources.ApplyResources(this.xGridCell33, "xGridCell33");
            // 
            // xGridCell34
            // 
            this.xGridCell34.CellName = "jundal_part_name";
            this.xGridCell34.Col = 16;
            resources.ApplyResources(this.xGridCell34, "xGridCell34");
            // 
            // grdExcel
            // 
            this.grdExcel.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell3,
            this.xGridCell4,
            this.xGridCell5,
            this.xGridCell6,
            this.xGridCell7,
            this.xGridCell8,
            this.xGridCell9,
            this.xGridCell10,
            this.xGridCell11,
            this.xGridCell12,
            this.xGridCell13,
            this.xGridCell14,
            this.xGridCell15,
            this.xGridCell16,
            this.xGridCell17});
            this.grdExcel.ColPerLine = 17;
            this.grdExcel.Cols = 17;
            this.grdExcel.ExecuteQuery = null;
            this.grdExcel.FixedRows = 1;
            this.grdExcel.HeaderHeights.Add(15);
            resources.ApplyResources(this.grdExcel, "grdExcel");
            this.grdExcel.Name = "grdExcel";
            this.grdExcel.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdExcel.ParamList")));
            this.grdExcel.QuerySQL = resources.GetString("grdExcel.QuerySQL");
            this.grdExcel.Rows = 2;
            this.grdExcel.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdExcel_QueryStarting);
            this.grdExcel.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdExcel_QueryEnd);
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "bunho";
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            // 
            // xGridCell2
            // 
            this.xGridCell2.CellName = "suname";
            this.xGridCell2.Col = 1;
            resources.ApplyResources(this.xGridCell2, "xGridCell2");
            // 
            // xGridCell3
            // 
            this.xGridCell3.CellName = "order_date";
            this.xGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell3.Col = 2;
            resources.ApplyResources(this.xGridCell3, "xGridCell3");
            // 
            // xGridCell4
            // 
            this.xGridCell4.CellName = "gwa_name";
            this.xGridCell4.Col = 3;
            resources.ApplyResources(this.xGridCell4, "xGridCell4");
            // 
            // xGridCell5
            // 
            this.xGridCell5.CellName = "doctor_name";
            this.xGridCell5.Col = 4;
            resources.ApplyResources(this.xGridCell5, "xGridCell5");
            // 
            // xGridCell6
            // 
            this.xGridCell6.CellName = "in_out_gubun_name";
            this.xGridCell6.Col = 5;
            resources.ApplyResources(this.xGridCell6, "xGridCell6");
            // 
            // xGridCell7
            // 
            this.xGridCell7.CellName = "order_gubun_name";
            this.xGridCell7.Col = 6;
            resources.ApplyResources(this.xGridCell7, "xGridCell7");
            // 
            // xGridCell8
            // 
            this.xGridCell8.CellName = "hangmog_code";
            this.xGridCell8.Col = 7;
            resources.ApplyResources(this.xGridCell8, "xGridCell8");
            // 
            // xGridCell9
            // 
            this.xGridCell9.CellName = "hangmog_name";
            this.xGridCell9.Col = 8;
            resources.ApplyResources(this.xGridCell9, "xGridCell9");
            // 
            // xGridCell10
            // 
            this.xGridCell10.CellName = "suryang";
            this.xGridCell10.Col = 9;
            resources.ApplyResources(this.xGridCell10, "xGridCell10");
            // 
            // xGridCell11
            // 
            this.xGridCell11.CellName = "ord_danui_name";
            this.xGridCell11.Col = 10;
            resources.ApplyResources(this.xGridCell11, "xGridCell11");
            // 
            // xGridCell12
            // 
            this.xGridCell12.CellName = "dv_time";
            this.xGridCell12.Col = 11;
            resources.ApplyResources(this.xGridCell12, "xGridCell12");
            // 
            // xGridCell13
            // 
            this.xGridCell13.CellName = "dv";
            this.xGridCell13.Col = 12;
            resources.ApplyResources(this.xGridCell13, "xGridCell13");
            // 
            // xGridCell14
            // 
            this.xGridCell14.CellName = "nalsu";
            this.xGridCell14.Col = 13;
            resources.ApplyResources(this.xGridCell14, "xGridCell14");
            // 
            // xGridCell15
            // 
            this.xGridCell15.CellName = "input_id_name";
            this.xGridCell15.Col = 14;
            resources.ApplyResources(this.xGridCell15, "xGridCell15");
            // 
            // xGridCell16
            // 
            this.xGridCell16.CellName = "hope_date";
            this.xGridCell16.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell16.Col = 15;
            resources.ApplyResources(this.xGridCell16, "xGridCell16");
            // 
            // xGridCell17
            // 
            this.xGridCell17.CellName = "jundal_part_name";
            this.xGridCell17.Col = 16;
            resources.ApplyResources(this.xGridCell17, "xGridCell17");
            // 
            // dsvJundalPartName
            // 
            this.dsvJundalPartName.ExecuteQuery = null;
            this.dsvJundalPartName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.dsvJundalPartName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dsvJundalPartName.ParamList")));
            this.dsvJundalPartName.QuerySQL = resources.GetString("dsvJundalPartName.QuerySQL");
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.tbxJundalPartName;
            this.singleLayoutItem1.DataName = "JundalPartName";
            // 
            // layExcel
            // 
            this.layExcel.ExecuteQuery = null;
            this.layExcel.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem56,
            this.multiLayoutItem57,
            this.multiLayoutItem58,
            this.multiLayoutItem59,
            this.multiLayoutItem60,
            this.multiLayoutItem61,
            this.multiLayoutItem62,
            this.multiLayoutItem63,
            this.multiLayoutItem64,
            this.multiLayoutItem65,
            this.multiLayoutItem66,
            this.multiLayoutItem67,
            this.multiLayoutItem68,
            this.multiLayoutItem69,
            this.multiLayoutItem70,
            this.multiLayoutItem71,
            this.multiLayoutItem72});
            this.layExcel.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layExcel.ParamList")));
            this.layExcel.QuerySQL = resources.GetString("layExcel.QuerySQL");
            this.layExcel.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layExcel_QueryStarting);
            this.layExcel.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layExcel_QueryEnd);
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "患者番号";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "患者名";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "オーダ日";
            this.multiLayoutItem58.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "科名";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "医師名";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "入・外";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "オーダ区分";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "薬品コード";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "薬品名";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "数量";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "単位";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "DV_TIME";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "回数";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "日数";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "入力者";
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "予約日";
            this.multiLayoutItem71.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "行為部署";
            // 
            // layExcelAct
            // 
            this.layExcelAct.ExecuteQuery = null;
            this.layExcelAct.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem39,
            this.multiLayoutItem40,
            this.multiLayoutItem41,
            this.multiLayoutItem42,
            this.multiLayoutItem43,
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem46,
            this.multiLayoutItem47,
            this.multiLayoutItem48,
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
            this.multiLayoutItem52,
            this.multiLayoutItem53,
            this.multiLayoutItem54,
            this.multiLayoutItem55});
            this.layExcelAct.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layExcelAct.ParamList")));
            this.layExcelAct.QuerySQL = resources.GetString("layExcelAct.QuerySQL");
            this.layExcelAct.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layExcelAct_QueryStarting);
            this.layExcelAct.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layExcelAct_QueryEnd);
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "患者番号";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "患者名";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "実施日";
            this.multiLayoutItem41.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "科名";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "医師名";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "入・外";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "オーダ区分";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "薬品コード";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "薬品名";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "数量";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "単位";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "DV_TIME";
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "回数";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "日数";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "入力者";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "予約日";
            this.multiLayoutItem54.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "行為部署";
            // 
            // DRG9001Q06
            // 
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel3);
            this.Name = "DRG9001Q06";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.DRG9001Q06_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xPatientBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDrugList)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExcelAct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layExcelAct)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region DRG9001Q06_Load
		private void DRG9001Q06_Load(object sender, System.EventArgs e)
		{
			// Control 초기화
            this.dtpOrderDate.SetDataValue(IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
			this.cbxInOut.SetDataValue("%");
			this.cbxOrderGubun.SetDataValue("%");
			this.fbxJundalPart.SetDataValue("%");
			this.tbxJundalPartName.SetDataValue("全体");
		}
		#endregion

		#region btnList_ButtonClick
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // 마우스 모래시계
					if (this.rbtOrder.Checked == true)
					{
                        this.layDrugList.QuerySQL = @"SELECT A.BUNHO                                                                  BUNHO
                                                             , B.SUNAME                                                                 SUNAME
                                                             , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                GWA_NAME
                                                             , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                          DOCTOR_NAME
                                                             , FN_ADM_DICT_NM('IN_OUT_GUBUN', 'O')                                      IN_OUT_GUBUN_NAME
                                                             , ''
                                                             , A.HANGMOG_CODE                                                           HANGMOG_CODE
                                                             , C.HANGMOG_NAME                                                           HANGMOG_NAME
                                                             , A.SURYANG                                                                SURYANG
                                                             , E.CODE_NAME                                                              ORD_DANUI_NAME
                                                             , FN_ADM_LOAD_USER_NAME(A.INPUT_ID)                                        INPUT_ID_NAME
                                                             , FN_BAS_LOAD_BUSEO_NAME(FN_ADM_USER_DEPT(A.INPUT_ID), A.ORDER_DATE)       INPUT_GUBUN_NAME
                                                             , TO_DATE(:f_order_date, 'YYYY/MM/DD')                                     ORDER_DATE
                                                             , A.DV_TIME                                                                DV_TIME
                                                             , TRIM(TO_CHAR(A.DV,'99'))                                                 DV
                                                             , F.CODE_NAME                                                              ORDER_GUBUN_NAME
                                                             , A.NALSU                                                                  NALSU 
                                                             , '1'                                                                      GUBUN                                              
                                                             , '1' || A.ORDER_GUBUN || TRIM(TO_CHAR(A.PKOCS1003,'000000000000000'))     OUT_KEY
                                                          FROM OCS0132 F
                                                             , OCS0132 E
                                                             , INV0110 D
                                                             , OCS0103 C
                                                             , OUT0101 B
                                                             , OCS1003 A
                                                         WHERE A.HOSP_CODE                  = :f_hosp_code
                                                           AND B.HOSP_CODE                  = A.HOSP_CODE
                                                           AND C.HOSP_CODE                  = A.HOSP_CODE
                                                           AND D.HOSP_CODE                  = A.HOSP_CODE
                                                           AND E.HOSP_CODE(+)               = A.HOSP_CODE
                                                           AND F.HOSP_CODE(+)               = A.HOSP_CODE
                                                           AND A.ORDER_DATE                = TO_DATE(:f_order_date, 'YYYY/MM/DD')
                                                           AND A.BUNHO                      = :f_bunho
                                                           AND :f_in_out_gubun             IN ('O','%')
                                                           AND SUBSTR(A.ORDER_GUBUN,2,1) LIKE :f_order_gubun
                                                           AND A.JUNDAL_PART             LIKE :f_jundal_part
                                                           AND NVL(A.JUNDAL_PART,'X')      <> 'PA'
                                                           AND NVL(A.DC_YN,'N')             = 'N'
                                                           AND A.SOURCE_FKOCS1003          IS NULL
                                                           AND A.BUNHO                      = B.BUNHO
                                                           AND A.HANGMOG_CODE               = C.HANGMOG_CODE
                                                           AND C.JAERYO_CODE                = D.JAERYO_CODE
                                                           AND D.JAERYO_GUBUN               = 'A'
                                                           AND A.ORD_DANUI                  = E.CODE(+)
                                                           AND E.CODE_TYPE(+)               = 'ORD_DANUI'
                                                           AND A.ORDER_GUBUN                = F.CODE(+)
                                                           AND F.CODE_TYPE(+)               = 'ORDER_GUBUN'
                                                         UNION ALL
                                                        SELECT A.BUNHO                                                                  BUNHO
                                                             , B.SUNAME                                                                 SUNAME
                                                             , FN_BAS_LOAD_GWA_NAME(F.GWA, A.ORDER_DATE)                                GWA_NAME
                                                             , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                          DOCTOR_NAME
                                                             , FN_ADM_DICT_NM('IN_OUT_GUBUN', 'I')                                      IN_OUT_GUBUN_NAME
                                                             , ''
                                                             , A.HANGMOG_CODE                                                           HANGMOG_CODE
                                                             , C.HANGMOG_NAME                                                           HANGMOG_NAME
                                                             , A.SURYANG                                                                SURYANG
                                                             , E.CODE_NAME                                                              ORD_DANUI_NAME
                                                             , FN_ADM_LOAD_USER_NAME(A.INPUT_ID)                                        INPUT_ID_NAME
                                                             , FN_BAS_LOAD_BUSEO_NAME(FN_ADM_USER_DEPT(A.INPUT_ID), A.ORDER_DATE)       INPUT_GUBUN_NAME
                                                             , TO_DATE(:f_order_date, 'YYYY/MM/DD')                                     ORDER_DATE
                                                             , A.DV_TIME                                                                DV_TIME
                                                             , TRIM(TO_CHAR(A.DV,'99'))                                                 DV
                                                             , G.CODE_NAME                                                              ORDER_GUBUN_NAME 
                                                             , A.NALSU                                                                  NALSU
                                                             , '1'                                                                      GUBUN                                                     
                                                             , '2' || A.ORDER_GUBUN || TRIM(TO_CHAR(A.PKOCS2003,'000000000000000'))     OUT_KEY
                                                          FROM OCS0132 G
                                                             , INP1001 F
                                                             , OCS0132 E
                                                             , INV0110 D
                                                             , OCS0103 C
                                                             , OUT0101 B
                                                             , OCS2003 A
                                                         WHERE A.HOSP_CODE                  = :f_hosp_code
                                                           AND B.HOSP_CODE                  = A.HOSP_CODE
                                                           AND C.HOSP_CODE                  = A.HOSP_CODE
                                                           AND D.HOSP_CODE                  = A.HOSP_CODE
                                                           AND E.HOSP_CODE(+)               = A.HOSP_CODE
                                                           AND F.HOSP_CODE(+)               = A.HOSP_CODE
                                                           AND A.ORDER_DATE                 = TO_DATE(:f_order_date, 'YYYY/MM/DD')
                                                           AND A.BUNHO                      = :f_bunho
                                                           AND :f_in_out_gubun             IN ('I','%')
                                                           AND SUBSTR(A.ORDER_GUBUN,2,1) LIKE :f_order_gubun
                                                           AND A.JUNDAL_PART             LIKE :f_jundal_part
                                                           AND NVL(A.JUNDAL_PART,'X')      <> 'PA'
                                                           AND NVL(A.DC_YN,'N')             = 'N'
                                                           AND A.SOURCE_FKOCS2003          IS NULL
                                                           AND A.BUNHO                      = B.BUNHO
                                                           AND A.HANGMOG_CODE               = C.HANGMOG_CODE
                                                           AND C.JAERYO_CODE                = D.JAERYO_CODE
                                                           AND D.JAERYO_GUBUN               = 'A'
                                                           AND A.ORD_DANUI                  = E.CODE(+)
                                                           AND E.CODE_TYPE(+)               = 'ORD_DANUI'
                                                           AND A.FKINP1001                  = F.PKINP1001
                                                           AND A.ORDER_GUBUN                = G.CODE(+)
                                                           AND G.CODE_TYPE(+)               = 'ORDER_GUBUN'
                                                         ORDER BY 19";
                        this.layDrugList.QueryLayout(true);
					}
					else
                    {
                        this.layDrugList.QuerySQL = @"SELECT A.BUNHO                                                                  BUNHO
                                                             , B.SUNAME                                                                 SUNAME
                                                             , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                GWA_NAME
                                                             , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                          DOCTOR_NAME
                                                             , FN_ADM_DICT_NM('IN_OUT_GUBUN', 'O')                                      IN_OUT_GUBUN_NAME
                                                             , ''
                                                             , A.HANGMOG_CODE                                                           HANGMOG_CODE
                                                             , C.HANGMOG_NAME                                                           HANGMOG_NAME
                                                             , A.SURYANG                                                                SURYANG
                                                             , E.CODE_NAME                                                              ORD_DANUI_NAME
                                                             , FN_ADM_LOAD_USER_NAME(A.INPUT_ID)                                        INPUT_ID_NAME
                                                             , FN_BAS_LOAD_BUSEO_NAME(FN_ADM_USER_DEPT(A.INPUT_ID), A.ORDER_DATE)       INPUT_GUBUN_NAME
                                                             , TO_DATE(:f_act_date, 'YYYY/MM/DD')                                       ACT_DATE
                                                             , A.DV_TIME                                                                DV_TIME
                                                             , TRIM(TO_CHAR(A.DV,'99'))                                                 DV
                                                             , F.CODE_NAME                                                              ORDER_GUBUN_NAME 
                                                             , A.NALSU                                                                  NALSU
                                                             , '2'                                                                      GUBUN                                         
                                                             , '1' || A.ORDER_GUBUN || TRIM(TO_CHAR(A.PKOCS1003,'000000000000000'))     OUT_KEY
                                                          FROM OCS0132 F
                                                             , OCS0132 E
                                                             , INV0110 D
                                                             , OCS0103 C
                                                             , OUT0101 B
                                                             , OCS1003 A
                                                         WHERE A.HOSP_CODE                  = :f_hosp_code
                                                           AND B.HOSP_CODE                  = A.HOSP_CODE
                                                           AND C.HOSP_CODE                  = A.HOSP_CODE
                                                           AND D.HOSP_CODE                  = A.HOSP_CODE
                                                           AND E.HOSP_CODE(+)               = A.HOSP_CODE
                                                           AND F.HOSP_CODE(+)               = A.HOSP_CODE
                                                           AND A.ACTING_DATE                = TO_DATE(:f_act_date, 'YYYY/MM/DD')
                                                           AND A.BUNHO                      = :f_bunho
                                                           AND :f_in_out_gubun             IN ('O','%')
                                                           AND SUBSTR(A.ORDER_GUBUN,2,1) LIKE :f_order_gubun
                                                           AND A.JUNDAL_PART             LIKE :f_jundal_part
                                                           AND NVL(A.JUNDAL_PART,'X')    NOT IN ('HOM','PA')
                                                           AND NVL(A.DC_YN,'N')             = 'N'
                                                           AND A.SOURCE_FKOCS1003          IS NULL
                                                           AND A.BUNHO                      = B.BUNHO
                                                           AND A.HANGMOG_CODE               = C.HANGMOG_CODE
                                                           AND C.JAERYO_CODE                = D.JAERYO_CODE
                                                           AND D.JAERYO_GUBUN               = 'A'
                                                           AND A.ORD_DANUI                  = E.CODE(+)
                                                           AND E.CODE_TYPE(+)               = 'ORD_DANUI'
                                                           AND A.ORDER_GUBUN                = F.CODE(+)
                                                           AND F.CODE_TYPE(+)               = 'ORDER_GUBUN'
                                                         UNION ALL
                                                        SELECT A.BUNHO                                                                  BUNHO
                                                             , B.SUNAME                                                                 SUNAME
                                                             , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                GWA_NAME
                                                             , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                          DOCTOR_NAME
                                                             , FN_ADM_DICT_NM('IN_OUT_GUBUN', 'O')                                      IN_OUT_GUBUN_NAME
                                                             , ''
                                                             , A.HANGMOG_CODE                                                           HANGMOG_CODE
                                                             , C.HANGMOG_NAME                                                           HANGMOG_NAME
                                                             , A.SURYANG                                                                SURYANG
                                                             , E.CODE_NAME                                                              ORD_DANUI_NAME
                                                             , FN_ADM_LOAD_USER_NAME(A.INPUT_ID)                                        INPUT_ID_NAME
                                                             , FN_BAS_LOAD_BUSEO_NAME(FN_ADM_USER_DEPT(A.INPUT_ID), A.ORDER_DATE)       INPUT_GUBUN_NAME
                                                             , TO_DATE(:f_act_date, 'YYYY/MM/DD')                                       ACT_DATE
                                                             , A.DV_TIME                                                                DV_TIME
                                                             , TRIM(TO_CHAR(A.DV,'99'))                                                 DV
                                                             , F.CODE_NAME                                                              ORDER_GUBUN_NAME
                                                             , A.NALSU                                                                  NALSU  
                                                             , '2'                                                                      GUBUN                                               
                                                             , '2' || A.ORDER_GUBUN || TRIM(TO_CHAR(A.PKOCS1003,'000000000000000'))     OUT_KEY
                                                          FROM OCS0132 F
                                                             , OCS0132 E
                                                             , INV0110 D
                                                             , OCS0103 C
                                                             , OUT0101 B
                                                             , OCS1003 A
                                                         WHERE A.HOSP_CODE                  = :f_hosp_code
                                                           AND B.HOSP_CODE                  = A.HOSP_CODE
                                                           AND C.HOSP_CODE                  = A.HOSP_CODE
                                                           AND D.HOSP_CODE                  = A.HOSP_CODE
                                                           AND E.HOSP_CODE(+)               = A.HOSP_CODE
                                                           AND F.HOSP_CODE(+)               = A.HOSP_CODE
                                                           AND NVL(A.ACTING_DATE,A.ORDER_DATE) = TO_DATE(:f_act_date, 'YYYY/MM/DD')
                                                           AND A.BUNHO                      = :f_bunho
                                                           AND :f_in_out_gubun             IN ('O','%')
                                                           AND SUBSTR(A.ORDER_GUBUN,2,1) LIKE :f_order_gubun
                                                           AND A.JUNDAL_PART             LIKE :f_jundal_part
                                                           AND NVL(A.JUNDAL_PART,'X')       = 'HOM'
                                                           AND NVL(A.DC_YN,'N')             = 'N'
                                                           AND A.SOURCE_FKOCS1003          IS NULL
                                                           AND A.BUNHO                      = B.BUNHO
                                                           AND A.HANGMOG_CODE               = C.HANGMOG_CODE
                                                           AND C.JAERYO_CODE                = D.JAERYO_CODE
                                                           AND D.JAERYO_GUBUN               = 'A'
                                                           AND A.ORD_DANUI                  = E.CODE(+)
                                                           AND E.CODE_TYPE(+)               = 'ORD_DANUI'
                                                           AND A.ORDER_GUBUN                = F.CODE(+)
                                                           AND F.CODE_TYPE(+)               = 'ORDER_GUBUN' 
                                                         UNION ALL
                                                        SELECT A.BUNHO                                                                  BUNHO
                                                             , B.SUNAME                                                                 SUNAME
                                                             , FN_BAS_LOAD_GWA_NAME(F.GWA, A.ORDER_DATE)                                GWA_NAME
                                                             , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                          DOCTOR_NAME
                                                             , FN_ADM_DICT_NM('IN_OUT_GUBUN', 'I')                                      IN_OUT_GUBUN_NAME
                                                             , ''
                                                             , A.HANGMOG_CODE                                                           HANGMOG_CODE
                                                             , C.HANGMOG_NAME                                                           HANGMOG_NAME
                                                             , A.SURYANG                                                                SURYANG
                                                             , E.CODE_NAME                                                              ORD_DANUI_NAME
                                                             , FN_ADM_LOAD_USER_NAME(A.INPUT_ID)                                        INPUT_ID_NAME
                                                             , FN_BAS_LOAD_BUSEO_NAME(FN_ADM_USER_DEPT(A.INPUT_ID), A.ORDER_DATE)       INPUT_GUBUN_NAME
                                                             , TO_DATE(:f_act_date, 'YYYY/MM/DD')                                       ACT_DATE 
                                                             , A.DV_TIME                                                                DV_TIME
                                                             , TRIM(TO_CHAR(A.DV,'99'))                                                 DV
                                                             , G.CODE_NAME                                                              ORDER_GUBUN_NAME
                                                             , A.NALSU                                                                  NALSU
                                                             , '2'                                                                      GUBUN                                                    
                                                             , '3' || A.ORDER_GUBUN || TRIM(TO_CHAR(A.PKOCS2003,'000000000000000'))     OUT_KEY
                                                          FROM OCS0132 G
                                                             , INP1001 F
                                                             , OCS0132 E
                                                             , INV0110 D
                                                             , OCS0103 C
                                                             , OUT0101 B
                                                             , OCS2003 A
                                                         WHERE A.HOSP_CODE                  = :f_hosp_code
                                                           AND B.HOSP_CODE                  = A.HOSP_CODE
                                                           AND C.HOSP_CODE                  = A.HOSP_CODE
                                                           AND D.HOSP_CODE                  = A.HOSP_CODE
                                                           AND E.HOSP_CODE(+)               = A.HOSP_CODE
                                                           AND F.HOSP_CODE(+)               = A.HOSP_CODE
                                                           AND G.HOSP_CODE(+)               = A.HOSP_CODE
                                                           AND A.ACTING_DATE                = TO_DATE(:f_act_date, 'YYYY/MM/DD')
                                                           AND A.BUNHO                      = :f_bunho
                                                           AND :f_in_out_gubun             IN ('I','%')
                                                           AND SUBSTR(A.ORDER_GUBUN,2,1) LIKE :f_order_gubun
                                                           AND A.JUNDAL_PART             LIKE :f_jundal_part
                                                           AND NVL(A.JUNDAL_PART,'X')    NOT IN ('HOM','PA')
                                                           AND NVL(A.DC_YN,'N')             = 'N'
                                                           AND A.SOURCE_FKOCS2003          IS NULL
                                                           AND A.BUNHO                      = B.BUNHO
                                                           AND A.HANGMOG_CODE               = C.HANGMOG_CODE
                                                           AND C.JAERYO_CODE                = D.JAERYO_CODE
                                                           AND D.JAERYO_GUBUN               = 'A'
                                                           AND A.ORD_DANUI                  = E.CODE(+)
                                                           AND E.CODE_TYPE(+)               = 'ORD_DANUI'
                                                           AND A.FKINP1001                  = F.PKINP1001
                                                           AND A.ORDER_GUBUN                = G.CODE(+)
                                                           AND G.CODE_TYPE(+)               = 'ORDER_GUBUN'
                                                         UNION ALL
                                                        SELECT A.BUNHO                                                                  BUNHO
                                                             , B.SUNAME                                                                 SUNAME
                                                             , FN_BAS_LOAD_GWA_NAME(F.GWA, A.ORDER_DATE)                                GWA_NAME
                                                             , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                          DOCTOR_NAME
                                                             , FN_ADM_DICT_NM('IN_OUT_GUBUN', 'I')                                      IN_OUT_GUBUN_NAME
                                                             , ''
                                                             , A.HANGMOG_CODE                                                           HANGMOG_CODE
                                                             , C.HANGMOG_NAME                                                           HANGMOG_NAME
                                                             , A.SURYANG                                                                SURYANG
                                                             , E.CODE_NAME                                                              ORD_DANUI_NAME
                                                             , FN_ADM_LOAD_USER_NAME(A.INPUT_ID)                                        INPUT_ID_NAME
                                                             , FN_BAS_LOAD_BUSEO_NAME(FN_ADM_USER_DEPT(A.INPUT_ID), A.ORDER_DATE)       INPUT_GUBUN_NAME
                                                             , TO_DATE(:f_act_date, 'YYYY/MM/DD')                                       ACT_DATE 
                                                             , A.DV_TIME                                                                DV_TIME
                                                             , TRIM(TO_CHAR(A.DV,'99'))                                                 DV
                                                             , G.CODE_NAME                                                              ORDER_GUBUN_NAME
                                                             , A.NALSU                                                                  NALSU
                                                             , '2'                                                                      GUBUN                                                     
                                                             , '4' || A.ORDER_GUBUN || TRIM(TO_CHAR(A.PKOCS2003,'000000000000000'))     OUT_KEY
                                                          FROM OCS0132 G
                                                             , INP1001 F
                                                             , OCS0132 E
                                                             , INV0110 D
                                                             , OCS0103 C
                                                             , OUT0101 B
                                                             , OCS2003 A
                                                         WHERE A.HOSP_CODE                  = :f_hosp_code
                                                           AND B.HOSP_CODE                  = A.HOSP_CODE
                                                           AND C.HOSP_CODE                  = A.HOSP_CODE
                                                           AND D.HOSP_CODE                  = A.HOSP_CODE
                                                           AND E.HOSP_CODE(+)               = A.HOSP_CODE
                                                           AND F.HOSP_CODE(+)               = A.HOSP_CODE
                                                           AND G.HOSP_CODE(+)               = A.HOSP_CODE
                                                           AND NVL(A.ACTING_DATE,A.ORDER_DATE) = TO_DATE(:f_act_date, 'YYYY/MM/DD')
                                                           AND A.BUNHO                      = :f_bunho
                                                           AND :f_in_out_gubun             IN ('I','%')
                                                           AND SUBSTR(A.ORDER_GUBUN,2,1) LIKE :f_order_gubun
                                                           AND A.JUNDAL_PART             LIKE :f_jundal_part
                                                           AND NVL(A.JUNDAL_PART,'X')       = 'HOM'
                                                           AND NVL(A.DC_YN,'N')             = 'N'
                                                           AND A.SOURCE_FKOCS2003          IS NULL
                                                           AND A.BUNHO                      = B.BUNHO
                                                           AND A.HANGMOG_CODE               = C.HANGMOG_CODE
                                                           AND C.JAERYO_CODE                = D.JAERYO_CODE
                                                           AND D.JAERYO_GUBUN               = 'A'
                                                           AND A.ORD_DANUI                  = E.CODE(+)
                                                           AND E.CODE_TYPE(+)               = 'ORD_DANUI'
                                                           AND A.FKINP1001                  = F.PKINP1001
                                                           AND A.ORDER_GUBUN                = G.CODE(+)
                                                           AND G.CODE_TYPE(+)               = 'ORDER_GUBUN'
                                                         ORDER BY 19";
                        this.layDrugList.QueryLayout(true);
					}
					Cursor.Current = System.Windows.Forms.Cursors.Default; // 마우스 원상복귀
					break;
				case FunctionType.Process:
					Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // 마우스 모래시계
					//layExcel.Reset();

                    string cmdText = "";

					if (this.rbtOrder.Checked == true)
                    {
                        //this.layExcel.QueryLayout(true);
                        this.grdExcel.QueryLayout(true);

                        #region
                        //                        cmdText = @"SELECT A.BUNHO                                                                  患者番号
//                                         , B.SUNAME                                                                 患者名
//                                         , TO_DATE(:f_order_date, 'YYYY/MM/DD')                                     オーダ日
//                                         , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                科名
//                                         , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                          医師名
//                                         , FN_ADM_DICT_NM('IN_OUT_GUBUN', 'O')                                      入・外
//                                         , F.CODE_NAME                                                              オーダ区分
//                                         , A.HANGMOG_CODE                                                           薬品コード
//                                         , C.HANGMOG_NAME                                                           薬品名
//                                         , A.SURYANG                                                                数量
//                                         , E.CODE_NAME                                                              単位
//                                         , A.DV_TIME                                                                DV_TIME
//                                         , A.DV                                                                     回数
//                                         , A.NALSU                                                                  日数
//                                         , FN_ADM_LOAD_USER_NAME(A.INPUT_ID)                                        入力者
//                                         , TO_DATE(A.HOPE_DATE, 'YYYY/MM/DD')                                       予約日   
//                                         , FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.ORDER_DATE)                        行為部署                                      
//                                         , '1' || A.ORDER_GUBUN || TRIM(TO_CHAR(A.PKOCS1003,'000000000000000'))     OUT_KEY
//                                      FROM OCS0132 F
//                                         , OCS0132 E
//                                         , INV0110 D
//                                         , OCS0103 C
//                                         , OUT0101 B
//                                         , OCS1003 A
//                                     WHERE A.HOSP_CODE                  = :f_hosp_code
//                                       AND B.HOSP_CODE                  = A.HOSP_CODE
//                                       AND C.HOSP_CODE                  = A.HOSP_CODE
//                                       AND D.HOSP_CODE                  = A.HOSP_CODE
//                                       AND E.HOSP_CODE(+)               = A.HOSP_CODE
//                                       AND F.HOSP_CODE(+)               = A.HOSP_CODE
//                                       AND A.ORDER_DATE                = TO_DATE(:f_order_date, 'YYYY/MM/DD')
//                                       AND A.BUNHO                      = :f_bunho
//                                       AND :f_in_out_gubun             IN ('O','%')
//                                       AND SUBSTR(A.ORDER_GUBUN,2,1) LIKE :f_order_gubun
//                                       AND A.JUNDAL_PART             LIKE :f_jundal_part
//                                       AND NVL(A.JUNDAL_PART,'X')      <> 'PA'
//                                       AND NVL(A.DC_YN,'N')             = 'N'
//                                       AND A.SOURCE_FKOCS1003          IS NULL
//                                       AND A.BUNHO                      = B.BUNHO
//                                       AND A.HANGMOG_CODE               = C.HANGMOG_CODE
//                                       AND C.JAERYO_CODE                = D.JAERYO_CODE
//                                       AND D.JAERYO_GUBUN               = 'A'
//                                       AND A.ORD_DANUI                  = E.CODE(+)
//                                       AND E.CODE_TYPE(+)               = 'ORD_DANUI'
//                                       AND A.ORDER_GUBUN                = F.CODE(+)
//                                       AND F.CODE_TYPE(+)               = 'ORDER_GUBUN'
//                                     UNION ALL
//                                    SELECT A.BUNHO                                                                  患者番号
//                                         , B.SUNAME                                                                 患者名
//                                         , TO_DATE(:f_order_date, 'YYYY/MM/DD')                                     オーダ日
//                                         , FN_BAS_LOAD_GWA_NAME(F.GWA, A.ORDER_DATE)                                科名
//                                         , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                          医師名
//                                         , FN_ADM_DICT_NM('IN_OUT_GUBUN', 'I')                                      入・外
//                                         , G.CODE_NAME                                                              オーダ区分
//                                         , A.HANGMOG_CODE                                                           薬品コード
//                                         , C.HANGMOG_NAME                                                           薬品名
//                                         , A.SURYANG                                                                数量
//                                         , E.CODE_NAME                                                              単位
//                                         , A.DV_TIME                                                                DV_TIME
//                                         , A.DV                                                                     回数
//                                         , A.NALSU                                                                  日数
//                                         , FN_ADM_LOAD_USER_NAME(A.INPUT_ID)                                        入力者
//                                         , TO_DATE(A.HOPE_DATE, 'YYYY/MM/DD')                                       予約日   
//                                         , FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.ORDER_DATE)                        行為部署                                                         
//                                         , '2' || A.ORDER_GUBUN || TRIM(TO_CHAR(A.PKOCS2003,'000000000000000'))     OUT_KEY
//                                      FROM OCS0132 G
//                                         , INP1001 F
//                                         , OCS0132 E
//                                         , INV0110 D
//                                         , OCS0103 C
//                                         , OUT0101 B
//                                         , OCS2003 A
//                                     WHERE A.HOSP_CODE                  = :f_hosp_code
//                                       AND B.HOSP_CODE                  = A.HOSP_CODE
//                                       AND C.HOSP_CODE                  = A.HOSP_CODE
//                                       AND D.HOSP_CODE                  = A.HOSP_CODE
//                                       AND E.HOSP_CODE(+)               = A.HOSP_CODE
//                                       AND F.HOSP_CODE(+)               = A.HOSP_CODE
//                                       AND G.HOSP_CODE(+)               = A.HOSP_CODE
//                                       AND A.ORDER_DATE                 = TO_DATE(:f_order_date, 'YYYY/MM/DD')
//                                       AND A.BUNHO                      = :f_bunho
//                                       AND :f_in_out_gubun             IN ('I','%')
//                                       AND SUBSTR(A.ORDER_GUBUN,2,1) LIKE :f_order_gubun
//                                       AND A.JUNDAL_PART             LIKE :f_jundal_part
//                                       AND NVL(A.JUNDAL_PART,'X')      <> 'PA'
//                                       AND NVL(A.DC_YN,'N')             = 'N'
//                                       AND A.SOURCE_FKOCS2003          IS NULL
//                                       AND A.BUNHO                      = B.BUNHO
//                                       AND A.HANGMOG_CODE               = C.HANGMOG_CODE
//                                       AND C.JAERYO_CODE                = D.JAERYO_CODE
//                                       AND D.JAERYO_GUBUN               = 'A'
//                                       AND A.ORD_DANUI                  = E.CODE(+)
//                                       AND E.CODE_TYPE(+)               = 'ORD_DANUI'
//                                       AND A.FKINP1001                  = F.PKINP1001
//                                       AND A.ORDER_GUBUN                = G.CODE(+)
//                                       AND G.CODE_TYPE(+)               = 'ORDER_GUBUN'
//                                     ORDER BY 18";
#endregion
					}
					else
					{
                        //this.layExcelAct.QueryLayout(true);
                        this.grdExcelAct.QueryLayout(true);
                        #region 
                        //                        cmdText = @"SELECT A.BUNHO                                                                  患者番号
//     , B.SUNAME                                                                 患者名
//     , TO_DATE(:f_act_date, 'YYYY/MM/DD')                                       オーダ日
//     , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                科名
//     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                          医師名
//     , FN_ADM_DICT_NM('IN_OUT_GUBUN', 'O')                                      入・外
//     , F.CODE_NAME                                                              オーダ区分
//     , A.HANGMOG_CODE                                                           薬品コード
//     , C.HANGMOG_NAME                                                           薬品名
//     , A.SURYANG                                                                数量
//     , E.CODE_NAME                                                              単位
//     , A.DV_TIME                                                                DV_TIME
//     , A.DV                                                                     回数
//     , A.NALSU                                                                  日数
//     , FN_ADM_LOAD_USER_NAME(A.INPUT_ID)                                        入力者
//     , TO_DATE(A.HOPE_DATE , 'YYYY/MM/DD')                                      予約日   
//     , FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.ORDER_DATE)                        行為部署                                             
//     , '1' || A.ORDER_GUBUN || TRIM(TO_CHAR(A.PKOCS1003,'000000000000000'))     OUT_KEY
//  FROM OCS0132 F
//     , OCS0132 E
//     , INV0110 D
//     , OCS0103 C
//     , OUT0101 B
//     , OCS1003 A
// WHERE A.HOSP_CODE                  = :f_hosp_code
//   AND B.HOSP_CODE                  = A.HOSP_CODE
//   AND C.HOSP_CODE                  = A.HOSP_CODE
//   AND D.HOSP_CODE                  = A.HOSP_CODE
//   AND E.HOSP_CODE(+)               = A.HOSP_CODE
//   AND F.HOSP_CODE(+)               = A.HOSP_CODE
//   AND A.ACTING_DATE                = TO_DATE(:f_act_date, 'YYYY/MM/DD')
//   AND A.BUNHO                      = :f_bunho
//   AND :f_in_out_gubun             IN ('O','%')
//   AND SUBSTR(A.ORDER_GUBUN,2,1) LIKE :f_order_gubun
//   AND A.JUNDAL_PART             LIKE :f_jundal_part
//   AND NVL(A.JUNDAL_PART,'X')    NOT IN ('HOM','PA')
//   AND NVL(A.DC_YN,'N')             = 'N'
//   AND A.SOURCE_FKOCS1003          IS NULL
//   AND A.BUNHO                      = B.BUNHO
//   AND A.HANGMOG_CODE               = C.HANGMOG_CODE
//   AND C.JAERYO_CODE                = D.JAERYO_CODE
//   AND D.JAERYO_GUBUN               = 'A'
//   AND A.ORD_DANUI                  = E.CODE(+)
//   AND E.CODE_TYPE(+)               = 'ORD_DANUI'
//   AND A.ORDER_GUBUN                = F.CODE(+)
//   AND F.CODE_TYPE(+)               = 'ORDER_GUBUN'
// UNION ALL
//SELECT A.BUNHO                                                                患者番号
//     , B.SUNAME                                                               患者名
//     , TO_DATE(:f_act_date, 'YYYY/MM/DD')                                     オーダ日
//     , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                              科名
//     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                        医師名
//     , FN_ADM_DICT_NM('IN_OUT_GUBUN', 'O')                                    入・外
//     , F.CODE_NAME                                                            オーダ区分
//     , A.HANGMOG_CODE                                                         薬品コード
//     , C.HANGMOG_NAME                                                         薬品名
//     , A.SURYANG                                                              数量
//     , E.CODE_NAME                                                            単位
//     , A.DV_TIME                                                              DV_TIME
//     , A.DV                                                                   回数
//     , A.NALSU                                                                日数
//     , FN_ADM_LOAD_USER_NAME(A.INPUT_ID)                                      入力者
//     , TO_DATE(A.HOPE_DATE , 'YYYY/MM/DD')                                    予約日   
//     , FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.ORDER_DATE)                      行為部署                                            
//     , '2' || A.ORDER_GUBUN || TRIM(TO_CHAR(A.PKOCS1003,'000000000000000'))   OUT_KEY
//  FROM OCS0132 F
//     , OCS0132 E
//     , INV0110 D
//     , OCS0103 C
//     , OUT0101 B
//     , OCS1003 A
// WHERE A.HOSP_CODE                  = :f_hosp_code
//   AND B.HOSP_CODE                  = A.HOSP_CODE
//   AND C.HOSP_CODE                  = A.HOSP_CODE
//   AND D.HOSP_CODE                  = A.HOSP_CODE
//   AND E.HOSP_CODE(+)               = A.HOSP_CODE
//   AND F.HOSP_CODE(+)               = A.HOSP_CODE
//   AND NVL(A.ACTING_DATE,A.ORDER_DATE) = TO_DATE(:f_act_date, 'YYYY/MM/DD')
//   AND A.BUNHO                      = :f_bunho
//   AND :f_in_out_gubun             IN ('O','%')
//   AND SUBSTR(A.ORDER_GUBUN,2,1) LIKE :f_order_gubun
//   AND A.JUNDAL_PART             LIKE :f_jundal_part
//   AND NVL(A.JUNDAL_PART,'X')       = 'HOM'
//   AND NVL(A.DC_YN,'N')             = 'N'
//   AND A.SOURCE_FKOCS1003          IS NULL
//   AND A.BUNHO                      = B.BUNHO
//   AND A.HANGMOG_CODE               = C.HANGMOG_CODE
//   AND C.JAERYO_CODE                = D.JAERYO_CODE
//   AND D.JAERYO_GUBUN               = 'A'
//   AND A.ORD_DANUI                  = E.CODE(+)
//   AND E.CODE_TYPE(+)               = 'ORD_DANUI'
//   AND A.ORDER_GUBUN                = F.CODE(+)
//   AND F.CODE_TYPE(+)               = 'ORDER_GUBUN' 
// UNION ALL
//SELECT A.BUNHO                                                                 患者番号
//     , B.SUNAME                                                                患者名
//     , TO_DATE(:f_act_date, 'YYYY/MM/DD')                                      オーダ日
//     , FN_BAS_LOAD_GWA_NAME(F.GWA, A.ORDER_DATE)                               科名
//     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                         医師名
//     , FN_ADM_DICT_NM('IN_OUT_GUBUN', 'I')                                     入・外
//     , G.CODE_NAME                                                             オーダ区分
//     , A.HANGMOG_CODE                                                          薬品コード
//     , C.HANGMOG_NAME                                                          薬品名
//     , A.SURYANG                                                               数量
//     , E.CODE_NAME                                                             単位
//     , A.DV_TIME                                                               DV_TIME
//     , A.DV                                                                    回数
//     , A.NALSU                                                                 日数
//     , FN_ADM_LOAD_USER_NAME(A.INPUT_ID)                                       入力者
//     , TO_DATE(A.HOPE_DATE , 'YYYY/MM/DD')                                     予約日   
//     , FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.ORDER_DATE)                       行為部署                                              
//     , '3' || A.ORDER_GUBUN || TRIM(TO_CHAR(A.PKOCS2003,'000000000000000'))    OUT_KEY
//  FROM OCS0132 G
//     , INP1001 F
//     , OCS0132 E
//     , INV0110 D
//     , OCS0103 C
//     , OUT0101 B
//     , OCS2003 A
// WHERE A.HOSP_CODE                  = :f_hosp_code
//   AND B.HOSP_CODE                  = A.HOSP_CODE
//   AND C.HOSP_CODE                  = A.HOSP_CODE
//   AND D.HOSP_CODE                  = A.HOSP_CODE
//   AND E.HOSP_CODE(+)               = A.HOSP_CODE
//   AND F.HOSP_CODE(+)               = A.HOSP_CODE
//   AND G.HOSP_CODE(+)               = A.HOSP_CODE
//   AND A.ACTING_DATE                 = TO_DATE(:f_act_date, 'YYYY/MM/DD')
//   AND A.BUNHO                      = :f_bunho
//   AND :f_in_out_gubun             IN ('I','%')
//   AND SUBSTR(A.ORDER_GUBUN,2,1) LIKE :f_order_gubun
//   AND A.JUNDAL_PART             LIKE :f_jundal_part
//   AND NVL(A.JUNDAL_PART,'X')    NOT IN ('HOM','PA')
//   AND NVL(A.DC_YN,'N')             = 'N'
//   AND A.SOURCE_FKOCS2003          IS NULL
//   AND A.BUNHO                      = B.BUNHO
//   AND A.HANGMOG_CODE               = C.HANGMOG_CODE
//   AND C.JAERYO_CODE                = D.JAERYO_CODE
//   AND D.JAERYO_GUBUN               = 'A'
//   AND A.ORD_DANUI                  = E.CODE(+)
//   AND E.CODE_TYPE(+)               = 'ORD_DANUI'
//   AND A.FKINP1001                  = F.PKINP1001
//   AND A.ORDER_GUBUN                = G.CODE(+)
//   AND G.CODE_TYPE(+)               = 'ORDER_GUBUN'
// UNION ALL
//SELECT A.BUNHO                                                                 患者番号
//     , B.SUNAME                                                                患者名
//     , TO_DATE(:f_act_date, 'YYYY/MM/DD')                                      オーダ日
//     , FN_BAS_LOAD_GWA_NAME(F.GWA, A.ORDER_DATE)                               科名
//     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                         医師名
//     , FN_ADM_DICT_NM('IN_OUT_GUBUN', 'I')                                     入・外
//     , G.CODE_NAME                                                             オーダ区分
//     , A.HANGMOG_CODE                                                          薬品コード
//     , C.HANGMOG_NAME                                                          薬品名
//     , A.SURYANG                                                               数量
//     , E.CODE_NAME                                                             単位
//     , A.DV_TIME                                                               DV_TIME
//     , A.DV                                                                    回数
//     , A.NALSU                                                                 日数
//     , FN_ADM_LOAD_USER_NAME(A.INPUT_ID)                                       入力者
//     , TO_DATE(A.HOPE_DATE , 'YYYY/MM/DD')                                     予約日   
//     , FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.ORDER_DATE)                       行為部署                                                    
//     , '4' || A.ORDER_GUBUN || TRIM(TO_CHAR(A.PKOCS2003,'000000000000000'))    OUT_KEY
//  FROM OCS0132 G
//     , INP1001 F
//     , OCS0132 E
//     , INV0110 D
//     , OCS0103 C
//     , OUT0101 B
//     , OCS2003 A
// WHERE A.HOSP_CODE                  = :f_hosp_code
//   AND B.HOSP_CODE                  = A.HOSP_CODE
//   AND C.HOSP_CODE                  = A.HOSP_CODE
//   AND D.HOSP_CODE                  = A.HOSP_CODE
//   AND E.HOSP_CODE(+)               = A.HOSP_CODE
//   AND F.HOSP_CODE(+)               = A.HOSP_CODE
//   AND G.HOSP_CODE(+)               = A.HOSP_CODE
//   AND NVL(A.ACTING_DATE,A.ORDER_DATE) = TO_DATE(:f_act_date, 'YYYY/MM/DD')
//   AND A.BUNHO                      = :f_bunho
//   AND :f_in_out_gubun             IN ('I','%')
//   AND SUBSTR(A.ORDER_GUBUN,2,1) LIKE :f_order_gubun
//   AND A.JUNDAL_PART             LIKE :f_jundal_part
//   AND NVL(A.JUNDAL_PART,'X')       = 'HOM'
//   AND NVL(A.DC_YN,'N')             = 'N'
//   AND A.SOURCE_FKOCS2003          IS NULL
//   AND A.BUNHO                      = B.BUNHO
//   AND A.HANGMOG_CODE               = C.HANGMOG_CODE
//   AND C.JAERYO_CODE                = D.JAERYO_CODE
//   AND D.JAERYO_GUBUN               = 'A'
//   AND A.ORD_DANUI                  = E.CODE(+)
//   AND E.CODE_TYPE(+)               = 'ORD_DANUI'
//   AND A.FKINP1001                  = F.PKINP1001
//   AND A.ORDER_GUBUN                = G.CODE(+)
//   AND G.CODE_TYPE(+)               = 'ORDER_GUBUN'
                        // ORDER BY 18";
                        #endregion
                    }

                    #region
                    //BindVarCollection bc = new BindVarCollection();

                    //bc.Add("f_hosp_code", EnvironInfo.HospCode);
                    //bc.Add("f_act_date", this.dtpOrderDate.GetDataValue());
                    //bc.Add("f_order_date", this.dtpOrderDate.GetDataValue());
                    //bc.Add("f_bunho", this.xPatientBox1.BunHo);
                    //bc.Add("f_in_out_gubun", this.cbxInOut.GetDataValue());
                    //bc.Add("f_order_gubun", this.cbxOrderGubun.GetDataValue());
                    //bc.Add("f_jundal_part", this.fbxJundalPart.GetDataValue());

                    //DataTable table = Service.ExecuteDataTable(cmdText, bc);

                    //Excel.ApplicationClass excel = new Excel.ApplicationClass(); int ColumnIndex = 0;
                    //foreach (DataColumn col in table.Columns)
                    //{
                    //    ColumnIndex++;
                    //    excel.Cells[1, ColumnIndex] = col.ColumnName;
                    //}
                    //int rowIndex = 0;
                    //foreach (DataRow row in table.Rows)
                    //{
                    //    rowIndex++;
                    //    ColumnIndex = 0;
                    //    foreach (DataColumn col in table.Columns)
                    //    {
                    //        ColumnIndex++;
                    //        excel.Cells[rowIndex + 1, ColumnIndex] = row[col.ColumnName].ToString();
                    //    }
                    //}
                    //excel.Visible = true;
                    //Excel.Worksheet wkSheet = (Excel.Worksheet)excel.ActiveSheet;
                    //wkSheet.Activate();
                    #endregion

                    Cursor.Current = System.Windows.Forms.Cursors.Default; // 마우스 원상복귀
					break;
				case FunctionType.Print:
					e.IsBaseCall = false;
                    
                    //try
                    //{
                    //    if(dw_drug.RowCount > 0)
                    //      dw_drug.Print();
                    //} 
                    //catch {}
					break;
			}
		}
		#endregion

        #region dsvDrg9001q06_ServiceEnd
        private void layDrugList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //if (e.IsSuccess)
            //{
            //    this.dw_drug.Reset();
            //    this.dw_drug.FillData(this.layDrugList.LayoutTable);
            //}
        }
		#endregion
	
		#region fbxJundalPart_DataValidating
		private void fbxJundalPart_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if (TypeCheck.IsNull(fbxJundalPart.GetDataValue()))
			{
				this.tbxJundalPartName.SetDataValue("");
			}
			else
            {
                dsvJundalPartName.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                dsvJundalPartName.SetBindVarValue("f_code", e.DataValue);
                dsvJundalPartName.QueryLayout();

                if (this.dsvJundalPartName.GetItemValue("JundalPartName").ToString() == "")
                {
                    e.Cancel = true;
                    return;
                }
			}
		}
		#endregion


		#region excelmap
		private string[] excelmap = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
										"AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ",
										"BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ",
										"CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ",
										"DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ",
										"EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ",
										"FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ",
										"GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ",
										"HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ",
										"IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ"};
		#endregion

		#region GetExcelIndexToLetter
		private string GetExcelIndexToLetter(int i)
		{
			return excelmap[i];
		}
		#endregion

		#region ExportSub
		protected virtual void ExportSub(bool isSaveFile, bool runExcel, bool onlyDisplayedColumn)
		{
            string msg = "";
   //         dw_drug.Export(true);
            //try
            //{
            //    string fileName = "";
            //    ArrayList excelProcList = new ArrayList();
            //    //파일을 Save하면 파일명칭지정하는 Dialog Show
            //    if (isSaveFile)
            //    {
            //        //Excel.ExcelApp를 사용하면 Interop.Excel등 다른 dll참조해야하고, 또한
            //        //Excel을 띄우게 되므로 html형식으로 Excel파일을 만듦
            //        SaveFileDialog dlg = new SaveFileDialog();
            //        dlg.Filter = "Excel files (*.xls)|*.xls"  ;
            //        dlg.FilterIndex = 1 ;
            //        dlg.RestoreDirectory = true ;
            //        if(dlg.ShowDialog() != DialogResult.OK)
            //            return;

            //        fileName = dlg.FileName;
            //    }
            //    else
            //    {
            //        //미지정이면 현재 Drive에 Temp Dir에 현재시간.xls 파일로 생성
            //        string path = Application.StartupPath.Substring(0,1) + ":\\Temp";
            //        if (!Directory.Exists(path))
            //            Directory.CreateDirectory(path);
            //        fileName = path + "\\" + DateTime.Now.ToString("HHmmss") + ".xls";
            //    }

            //    //GabageCollector를 쓰면 Excel이 죽지 않는 경우가 발생
            //    //기존에 떠있는 Excel 검색하여 저장후 새로 생긴 Excel Kill
            //    foreach(Process proc in Process.GetProcessesByName("EXCEL"))
            //        excelProcList.Add(proc.Id);
            //    Excel.ApplicationClass excelApp = new Excel.ApplicationClass();
            //    if (excelApp == null)
            //    {
            //        msg = (NetInfo.Language == LangMode.Ko ? "Excel파일을 생성하지 못했습니다."
            //            : "Excelファイルの生成できませんでした。");
            //        ShowErrMsg(msg);
            //        return;
            //    }
				
            //    excelApp.Visible = false;

            //    //2005.11.22 onlyDisplayedColumn 속성 반영 (true이면 컬럼List중에서 visible한 컬럼만 SET 
            //    //				int colCount = layExcel.LayoutTable.Columns.Count;
            //    int colCount = layExcel.LayoutTable.Columns.Count;
            //    ArrayList dispColList = new ArrayList();

            //    //				if (onlyDisplayedColumn)
            //    //				{
            //    //					foreach (XGridCell info in this.CellInfos)
            //    //						if (info.IsVisible)
            //    //							dispColList.Add(info.CellName);
            //    //					//컬럼의 갯수는 보여지는 컬럼의 갯수
            //    //					colCount = dispColList.Count;
            //    //				}
            //    //				else  //DataTable에 있는 모든 컬럼을 dispColList에 SET
            //    //				{
            //    //					foreach (DataColumn dtCol in layExcel.LayoutTable.Columns)
            //    //						dispColList.Add(dtCol.ColumnName);
            //    //				}
            //    if (colCount == 0) return;

            //    foreach (DataColumn dtCol in layExcel.LayoutTable.Columns)
            //        dispColList.Add(dtCol.ColumnName);

            //    Excel.Workbook theWorkBook = excelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            //    Excel.Worksheet theWorkSheet = (Excel.Worksheet)theWorkBook.Worksheets[1];
            //    int rowCount = layExcel.LayoutTable.Rows.Count;
            //    int colIndex = 0;
            //    int rowIndex = 0;
            //    Excel.Range theRange = theWorkSheet.Cells.get_Range(GetExcelIndexToLetter(0) + "1", GetExcelIndexToLetter(colCount -1) + (rowCount + 1).ToString());

            //    //Header 포함 Row의 갯수 + 1
            //    object[,] dataArray = new object[rowCount + 1, colCount];

            //    //Header 설정 (있으면 설정, 없으면 컬럼명으로 설정)
            //    //Date,DataTime형 컬럼 List Date형이면 Y, DateTime형이면 T
            //    Hashtable dateColunmList = new Hashtable();
            //    ArrayList	colNameList = new ArrayList();  //컬럼명 SET
            //    XGridCell cellInfo = null;
            //    object data = DBNull.Value;
            //    string colName = "";

            //    //foreach (DataColumn dtCol in this.LayoutTable.Columns)
            //    foreach (string columnName in dispColList)
            //    {
            //        cellInfo = null;
            //        if (cellInfo == null)
            //        {
            //            dataArray[0, colIndex] = columnName;
            //            if (layExcel.LayoutTable.Columns[columnName].DataType == typeof(DateTime))
            //                dateColunmList.Add(columnName, "T");
            //        }
            //        else
            //        {
            //            if (cellInfo.HeaderText != "")
            //                dataArray[0, colIndex] = cellInfo.HeaderText;
            //            else
            //                dataArray[0, colIndex] = columnName;

            //            //Date형,DateTime형 컬럼 SET
            //            if (cellInfo.CellType == XCellDataType.Date)
            //                dateColunmList.Add(columnName, "Y");
            //            else if (cellInfo.CellType == XCellDataType.DateTime)
            //                dateColunmList.Add(columnName, "T");
            //        }
            //        colIndex++;
            //        //컬럼명 List에 Add
            //        colNameList.Add(columnName);
            //    }
				
            //    //Data 설정
            //    foreach (DataRow dtRow in layExcel.LayoutTable.Rows)
            //    {
            //        rowIndex++;

            //        for (int i = 0 ; i < colCount ; i++)
            //        {
            //            colName = colNameList[i].ToString();
            //            data = dtRow[i];
            //            if (dateColunmList.Contains(colName))
            //            {
            //                if (dateColunmList[colName].ToString() == "Y") //Date형 YYYYMMDD형 -> YYYY/MM/DD형으로
            //                {
            //                    try
            //                    {
            //                        if (data == DBNull.Value)
            //                            dataArray[rowIndex, i] = string.Empty;
            //                        else
            //                        {
            //                            //Date형은 YYYY/MM/DD로 관리함
            //                            if (TypeCheck.IsDateTime(data))
            //                                dataArray[rowIndex, i] = data;
            //                            else  //YYYYMMDD 형
            //                                dataArray[rowIndex, i] = data.ToString().Substring(0,4) + "/" + data.ToString().Substring(4,2) + "/" + data.ToString().Substring(6,2);
            //                        }
            //                    }
            //                    catch
            //                    {
            //                        dataArray[rowIndex, i] = string.Empty;
            //                    }
            //                }
            //                else //DateTime형 YYYY/MM/DD HH:MI:SS
            //                {
            //                    try
            //                    {
            //                        if (data == DBNull.Value)
            //                            dataArray[rowIndex, i] = string.Empty;
            //                        else
            //                            dataArray[rowIndex, i] = ((DateTime)data).ToString("yyyy/MM/dd HH:mm:ss");
            //                    }
            //                    catch
            //                    {
            //                        dataArray[rowIndex, i] = string.Empty;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                dataArray[rowIndex, i] = data.ToString();
            //            }

            //        }
            //    }
				
            //    //Range Data Set
            //    theRange.Value = dataArray;

            //    //SaveAs File
            //    theWorkBook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //        Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing,Type.Missing, Type.Missing);

            //    //저장후 Excel Process 종료
            //    excelApp.Quit();

            //    //excelApp에 의해 생성된 Process Kill
            //    Process[] excelProcess = Process.GetProcessesByName("EXCEL");
            //    for (int i = 0 ; i < excelProcess.Length ; i++)
            //    {
            //        if (!excelProcList.Contains(excelProcess[i].Id))
            //            excelProcess[i].Kill();
            //    }

            //    //Excel Run
            //    try
            //    {
            //        if (runExcel)
            //        {
            //            //Dir명이 Space가 들어가 있는 경우에 대비하여 arguments를 전달시에 양쪽을 ""로 묶음
            //            Process.Start("EXCEL.exe", "\"" + fileName + "\"");
            //        }
            //    }
            //    catch{}
            //}
            //catch(Exception e)
            //{
            //    msg = (NetInfo.Language == LangMode.Ko ? "Excel파일 생성실패. 에러[" + e.Message + "]"
            //        : "Excelファイルの生成失敗。 エラ?[" + e.Message + "]");
            //    ShowErrMsg(msg);
            //}
		}

		protected virtual void ExportSubAct(bool isSaveFile, bool runExcel, bool onlyDisplayedColumn)
		{
			string msg = "";
            
            //try
            //{
            //    string fileName = "";
            //    ArrayList excelProcList = new ArrayList();
            //    //파일을 Save하면 파일명칭지정하는 Dialog Show
            //    if (isSaveFile)
            //    {
            //        //Excel.ExcelApp를 사용하면 Interop.Excel등 다른 dll참조해야하고, 또한
            //        //Excel을 띄우게 되므로 html형식으로 Excel파일을 만듦
            //        SaveFileDialog dlg = new SaveFileDialog();
            //        dlg.Filter = "Excel files (*.xls)|*.xls"  ;
            //        dlg.FilterIndex = 1 ;
            //        dlg.RestoreDirectory = true ;
            //        if(dlg.ShowDialog() != DialogResult.OK)
            //            return;

            //        fileName = dlg.FileName;
            //    }
            //    else
            //    {
            //        //미지정이면 현재 Drive에 Temp Dir에 현재시간.xls 파일로 생성
            //        string path = Application.StartupPath.Substring(0,1) + ":\\Temp";
            //        if (!Directory.Exists(path))
            //            Directory.CreateDirectory(path);
            //        fileName = path + "\\" + DateTime.Now.ToString("HHmmss") + ".xls";
            //    }

            //    //GabageCollector를 쓰면 Excel이 죽지 않는 경우가 발생
            //    //기존에 떠있는 Excel 검색하여 저장후 새로 생긴 Excel Kill
            //    foreach(Process proc in Process.GetProcessesByName("EXCEL"))
            //        excelProcList.Add(proc.Id);
				
            //    Excel.ApplicationClass excelApp = new Excel.ApplicationClass();
            //    if (excelApp == null)
            //    {
            //        msg = (NetInfo.Language == LangMode.Ko ? "Excel파일을 생성하지 못했습니다."
            //            : "Excelファイルの生成できませんでした。");
            //        ShowErrMsg(msg);
            //        return;
            //    }
				
            //    excelApp.Visible = false;

            //    //2005.11.22 onlyDisplayedColumn 속성 반영 (true이면 컬럼List중에서 visible한 컬럼만 SET 
            //    //				int colCount = layExcel.LayoutTable.Columns.Count;
            //    int colCount = layExcelAct.LayoutTable.Columns.Count;
            //    ArrayList dispColList = new ArrayList();

            //    //				if (onlyDisplayedColumn)
            //    //				{
            //    //					foreach (XGridCell info in this.CellInfos)
            //    //						if (info.IsVisible)
            //    //							dispColList.Add(info.CellName);
            //    //					//컬럼의 갯수는 보여지는 컬럼의 갯수
            //    //					colCount = dispColList.Count;
            //    //				}
            //    //				else  //DataTable에 있는 모든 컬럼을 dispColList에 SET
            //    //				{
            //    //					foreach (DataColumn dtCol in layExcel.LayoutTable.Columns)
            //    //						dispColList.Add(dtCol.ColumnName);
            //    //				}
            //    if (colCount == 0) return;

            //    foreach (DataColumn dtCol in layExcelAct.LayoutTable.Columns)
            //        dispColList.Add(dtCol.ColumnName);

            //    Excel.Workbook theWorkBook = excelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            //    Excel.Worksheet theWorkSheet = (Excel.Worksheet)theWorkBook.Worksheets[1];
            //    int rowCount = layExcelAct.LayoutTable.Rows.Count;
            //    int colIndex = 0;
            //    int rowIndex = 0;
            //    Excel.Range theRange = theWorkSheet.Cells.get_Range(GetExcelIndexToLetter(0) + "1", GetExcelIndexToLetter(colCount -1) + (rowCount + 1).ToString());

            //    //Header 포함 Row의 갯수 + 1
            //    object[,] dataArray = new object[rowCount + 1, colCount];

            //    //Header 설정 (있으면 설정, 없으면 컬럼명으로 설정)
            //    //Date,DataTime형 컬럼 List Date형이면 Y, DateTime형이면 T
            //    Hashtable dateColunmList = new Hashtable();
            //    ArrayList	colNameList = new ArrayList();  //컬럼명 SET
            //    XGridCell cellInfo = null;
            //    object data = DBNull.Value;
            //    string colName = "";

            //    //foreach (DataColumn dtCol in this.LayoutTable.Columns)
            //    foreach (string columnName in dispColList)
            //    {
            //        cellInfo = null;
            //        if (cellInfo == null)
            //        {
            //            dataArray[0, colIndex] = columnName;
            //            if (layExcelAct.LayoutTable.Columns[columnName].DataType == typeof(DateTime))
            //                dateColunmList.Add(columnName, "T");
            //        }
            //        else
            //        {
            //            if (cellInfo.HeaderText != "")
            //                dataArray[0, colIndex] = cellInfo.HeaderText;
            //            else
            //                dataArray[0, colIndex] = columnName;

            //            //Date형,DateTime형 컬럼 SET
            //            if (cellInfo.CellType == XCellDataType.Date)
            //                dateColunmList.Add(columnName, "Y");
            //            else if (cellInfo.CellType == XCellDataType.DateTime)
            //                dateColunmList.Add(columnName, "T");
            //        }
            //        colIndex++;
            //        //컬럼명 List에 Add
            //        colNameList.Add(columnName);
            //    }
				
            //    //Data 설정
            //    foreach (DataRow dtRow in layExcelAct.LayoutTable.Rows)
            //    {
            //        rowIndex++;

            //        for (int i = 0 ; i < colCount ; i++)
            //        {
            //            colName = colNameList[i].ToString();
            //            data = dtRow[i];
            //            if (dateColunmList.Contains(colName))
            //            {
            //                if (dateColunmList[colName].ToString() == "Y") //Date형 YYYYMMDD형 -> YYYY/MM/DD형으로
            //                {
            //                    try
            //                    {
            //                        if (data == DBNull.Value)
            //                            dataArray[rowIndex, i] = string.Empty;
            //                        else
            //                        {
            //                            //Date형은 YYYY/MM/DD로 관리함
            //                            if (TypeCheck.IsDateTime(data))
            //                                dataArray[rowIndex, i] = data;
            //                            else  //YYYYMMDD 형
            //                                dataArray[rowIndex, i] = data.ToString().Substring(0,4) + "/" + data.ToString().Substring(4,2) + "/" + data.ToString().Substring(6,2);
            //                        }
            //                    }
            //                    catch
            //                    {
            //                        dataArray[rowIndex, i] = string.Empty;
            //                    }
            //                }
            //                else //DateTime형 YYYY/MM/DD HH:MI:SS
            //                {
            //                    try
            //                    {
            //                        if (data == DBNull.Value)
            //                            dataArray[rowIndex, i] = string.Empty;
            //                        else
            //                            dataArray[rowIndex, i] = ((DateTime)data).ToString("yyyy/MM/dd HH:mm:ss");
            //                    }
            //                    catch
            //                    {
            //                        dataArray[rowIndex, i] = string.Empty;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                dataArray[rowIndex, i] = data.ToString();
            //            }

            //        }
            //    }
				
            //    //Range Data Set
            //    theRange.Value = dataArray;

            //    //SaveAs File
            //    theWorkBook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //        Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing,Type.Missing, Type.Missing);

            //    //저장후 Excel Process 종료
            //    excelApp.Quit();

            //    //excelApp에 의해 생성된 Process Kill
            //    Process[] excelProcess = Process.GetProcessesByName("EXCEL");
            //    for (int i = 0 ; i < excelProcess.Length ; i++)
            //    {
            //        if (!excelProcList.Contains(excelProcess[i].Id))
            //            excelProcess[i].Kill();
            //    }

            //    //Excel Run
            //    try
            //    {
            //        if (runExcel)
            //        {
            //            //Dir명이 Space가 들어가 있는 경우에 대비하여 arguments를 전달시에 양쪽을 ""로 묶음
            //            Process.Start("EXCEL.exe", "\"" + fileName + "\"");
            //        }
            //    }
            //    catch{}
            //}
            //catch(Exception e)
            //{
            //    msg = (NetInfo.Language == LangMode.Ko ? "Excel파일 생성실패. 에러[" + e.Message + "]"
            //        : "Excelファイルの生成失敗。 エラ?[" + e.Message + "]");
            //    ShowErrMsg(msg);
            //}
		}
		#endregion

		#region ShowErrMsg
		protected void ShowErrMsg(string msg)
		{
			if (msg == "") return;
			
			XMessageBox.Show(msg);

		}
		#endregion

		#region 타이틀 변경
		private void rbtOrder_CheckedChanged(object sender, System.EventArgs e)
		{
			xLabel2.Text = "オーダ日";
            this.btnList.PerformClick(FunctionType.Query);
		}

		private void rbtActing_CheckedChanged(object sender, System.EventArgs e)
		{
            xLabel2.Text = "実施日";
            this.btnList.PerformClick(FunctionType.Query);
		}
		#endregion

        private void layDrugList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layDrugList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDrugList.SetBindVarValue("f_order_date", this.dtpOrderDate.GetDataValue());
            this.layDrugList.SetBindVarValue("f_act_date", this.dtpOrderDate.GetDataValue());
            this.layDrugList.SetBindVarValue("f_bunho", this.xPatientBox1.BunHo);
            this.layDrugList.SetBindVarValue("f_in_out_gubun", this.cbxInOut.GetDataValue());
            this.layDrugList.SetBindVarValue("f_order_gubun", this.cbxOrderGubun.GetDataValue());
            this.layDrugList.SetBindVarValue("f_jundal_part", this.fbxJundalPart.GetDataValue());
        }

        private void layExcel_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layExcel.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layExcel.SetBindVarValue("f_order_date", this.dtpOrderDate.GetDataValue());
            this.layExcel.SetBindVarValue("f_bunho", this.xPatientBox1.BunHo);
            this.layExcel.SetBindVarValue("f_in_out_gubun", this.cbxInOut.GetDataValue());
            this.layExcel.SetBindVarValue("f_order_gubun", this.cbxOrderGubun.GetDataValue());
            this.layExcel.SetBindVarValue("f_jundal_part", this.fbxJundalPart.GetDataValue());

        }

        private void layExcelAct_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layExcelAct.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layExcelAct.SetBindVarValue("f_act_date", this.dtpOrderDate.GetDataValue());
            this.layExcelAct.SetBindVarValue("f_bunho", this.xPatientBox1.BunHo);
            this.layExcelAct.SetBindVarValue("f_in_out_gubun", this.cbxInOut.GetDataValue());
            this.layExcelAct.SetBindVarValue("f_order_gubun", this.cbxOrderGubun.GetDataValue());
            this.layExcelAct.SetBindVarValue("f_jundal_part", this.fbxJundalPart.GetDataValue());

        }

        private void grdExcel_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdExcel.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdExcel.SetBindVarValue("f_order_date", this.dtpOrderDate.GetDataValue());
            this.grdExcel.SetBindVarValue("f_bunho", this.xPatientBox1.BunHo);
            this.grdExcel.SetBindVarValue("f_in_out_gubun", this.cbxInOut.GetDataValue());
            this.grdExcel.SetBindVarValue("f_order_gubun", this.cbxOrderGubun.GetDataValue());
            this.grdExcel.SetBindVarValue("f_jundal_part", this.fbxJundalPart.GetDataValue());
        }
        private void grdExcelAct_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdExcelAct.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdExcelAct.SetBindVarValue("f_act_date", this.dtpOrderDate.GetDataValue());
            this.grdExcelAct.SetBindVarValue("f_bunho", this.xPatientBox1.BunHo);
            this.grdExcelAct.SetBindVarValue("f_in_out_gubun", this.cbxInOut.GetDataValue());
            this.grdExcelAct.SetBindVarValue("f_order_gubun", this.cbxOrderGubun.GetDataValue());
            this.grdExcelAct.SetBindVarValue("f_jundal_part", this.fbxJundalPart.GetDataValue());
        }

        #region dsvExcel_ServiceEnd
        private void grdExcel_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if(this.grdExcel.RowCount > 0)
                this.grdExcel.Export();
        }

        private void grdExcelAct_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if(this.grdExcelAct.RowCount > 0)
                this.grdExcelAct.Export();
        }

        private void layExcel_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                //ExportSub(true, false, false);
            }
        }

        private void layExcelAct_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                //ExportSubAct(true, false, false);
            }
        }
        #endregion

        private void dw_drug_Click(object sender, EventArgs e)
        {
 //           dw_drug.Refresh();
        }

        private void dw_drug_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
   //         dw_drug.Refresh();
        }

        private void cbxInOut_DataValidating(object sender, DataValidatingEventArgs e)
        {

            this.btnList.PerformClick(FunctionType.Query);
        }

        private void cbxOrderGubun_DataValidating(object sender, DataValidatingEventArgs e)
        {

            this.btnList.PerformClick(FunctionType.Query);
        }

        private void dtpOrderDate_DataValidating(object sender, DataValidatingEventArgs e)
        {

            this.btnList.PerformClick(FunctionType.Query);
        }

        private void xPatientBox1_PatientSelected(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }


	}
}

