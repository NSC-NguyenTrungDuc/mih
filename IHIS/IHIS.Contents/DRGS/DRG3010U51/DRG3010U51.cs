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

namespace IHIS.DRGS
{
	/// <summary>
	/// DRG3010U51에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG3010U51 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XFindWorker fwkJaeryo;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.XEditGrid grdDrg3010;
		private IHIS.Framework.XDictComboBox cboDong;
		private IHIS.Framework.XPatientBox paid;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XDatePicker dtpBanNabFr;
		private IHIS.Framework.XDatePicker dtpBanNabTo;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XPanel panTop;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XComboBox cboGubun;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.MultiLayout layOrder;
//		private IHIS.Framework.XDataWindow dw1;
		private IHIS.Framework.XDWWorker xdwWorker1;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGrid grdNur1005;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
		private IHIS.Framework.XEditGridCell xEditGridCell38;
		private IHIS.Framework.XEditGridCell xEditGridCell39;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
//		private IHIS.Framework.XDataWindow dw_NUR1005P01;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
        private XComboItem xComboItem3;

		//private int mLastRow =0;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DRG3010U51()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            this.grdDrg3010.SavePerformer = new XSavePerformer(this);
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdDrg3010);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG3010U51));
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpBanNabTo = new IHIS.Framework.XDatePicker();
            this.paid = new IHIS.Framework.XPatientBox();
            this.cboDong = new IHIS.Framework.XDictComboBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dtpBanNabFr = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.fwkJaeryo = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.grdDrg3010 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.cboGubun = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.panTop = new IHIS.Framework.XPanel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.grdNur1005 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.layOrder = new IHIS.Framework.MultiLayout();
            this.xdwWorker1 = new IHIS.Framework.XDWWorker();
            ((System.ComponentModel.ISupportInitialize)(this.paid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg3010)).BeginInit();
            this.panTop.SuspendLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNur1005)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // xLabel2
            // 
            this.xLabel2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // dtpBanNabTo
            // 
            this.dtpBanNabTo.IsVietnameseYearType = false;
            resources.ApplyResources(this.dtpBanNabTo, "dtpBanNabTo");
            this.dtpBanNabTo.Name = "dtpBanNabTo";
            this.dtpBanNabTo.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtp_DataValidating);
            // 
            // paid
            // 
            this.paid.BoxType = IHIS.Framework.PatientBoxType.NormalDetail;
            resources.ApplyResources(this.paid, "paid");
            this.paid.Name = "paid";
            this.paid.PatientSelected += new System.EventHandler(this.paid_PatientSelected);
            // 
            // cboDong
            // 
            this.cboDong.ExecuteQuery = null;
            resources.ApplyResources(this.cboDong, "cboDong");
            this.cboDong.Name = "cboDong";
            this.cboDong.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboDong.ParamList")));
            this.cboDong.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboDong.UserSQL = resources.GetString("cboDong.UserSQL");
            this.cboDong.SelectionChangeCommitted += new System.EventHandler(this.cbo_SelectedIndexChanged);
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // dtpBanNabFr
            // 
            this.dtpBanNabFr.IsVietnameseYearType = false;
            resources.ApplyResources(this.dtpBanNabFr, "dtpBanNabFr");
            this.dtpBanNabFr.Name = "dtpBanNabFr";
            this.dtpBanNabFr.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtp_DataValidating);
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // fwkJaeryo
            // 
            this.fwkJaeryo.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkJaeryo.ExecuteQuery = null;
            this.fwkJaeryo.FormText = "薬品コード";
            this.fwkJaeryo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkJaeryo.ParamList")));
            this.fwkJaeryo.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fwkJaeryo.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "Jaeryo";
            this.findColumnInfo1.ColWidth = 98;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "JaeryoName";
            this.findColumnInfo2.ColWidth = 368;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "一括チェック", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "update_yn";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "order_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 87;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.SuppressRepeating = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "jubsu_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.CellWidth = 87;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.SuppressRepeating = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "jaeryo_code";
            this.xEditGridCell7.CellWidth = 83;
            this.xEditGridCell7.Col = 7;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "jaeryo_name";
            this.xEditGridCell8.CellWidth = 166;
            this.xEditGridCell8.Col = 8;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdCol = false;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "chulgo_buseo";
            this.xEditGridCell9.CellWidth = 85;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "dv_time";
            this.xEditGridCell10.CellWidth = 34;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "dv";
            this.xEditGridCell11.CellWidth = 27;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "subul_suryang";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell13.CellWidth = 59;
            this.xEditGridCell13.Col = 9;
            this.xEditGridCell13.DecimalDigits = 4;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "subul_danui";
            this.xEditGridCell14.CellWidth = 46;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            this.xEditGridCell14.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // grdDrg3010
            // 
            this.grdDrg3010.ApplyPaintEventToAllColumn = true;
            this.grdDrg3010.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell7,
            this.xEditGridCell11,
            this.xEditGridCell10,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell14,
            this.xEditGridCell13,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell8,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell6,
            this.xEditGridCell18,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell9,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell12,
            this.xEditGridCell15,
            this.xEditGridCell41});
            this.grdDrg3010.ColPerLine = 12;
            this.grdDrg3010.ColResizable = true;
            this.grdDrg3010.Cols = 13;
            resources.ApplyResources(this.grdDrg3010, "grdDrg3010");
            this.grdDrg3010.ExecuteQuery = null;
            this.grdDrg3010.FixedCols = 1;
            this.grdDrg3010.FixedRows = 1;
            this.grdDrg3010.HeaderHeights.Add(30);
            this.grdDrg3010.Name = "grdDrg3010";
            this.grdDrg3010.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDrg3010.ParamList")));
            this.grdDrg3010.QuerySQL = resources.GetString("grdDrg3010.QuerySQL");
            this.grdDrg3010.RowHeaderVisible = true;
            this.grdDrg3010.Rows = 2;
            this.grdDrg3010.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdDrg3010_SaveEnd);
            this.grdDrg3010.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdDrg3010_GridCellPainting);
            this.grdDrg3010.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDrg3010_QueryStarting);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "order_danui";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdCol = false;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "source_fkocs2003";
            this.xEditGridCell25.CellWidth = 24;
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdCol = false;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "bannab_yn";
            this.xEditGridCell26.CellWidth = 393;
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "bannab_confirm";
            this.xEditGridCell27.CellWidth = 46;
            this.xEditGridCell27.Col = 12;
            this.xEditGridCell27.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "bunho";
            this.xEditGridCell16.CellWidth = 79;
            this.xEditGridCell16.Col = 5;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.SuppressRepeating = true;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "suname";
            this.xEditGridCell17.CellWidth = 92;
            this.xEditGridCell17.Col = 6;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.SuppressRepeating = true;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "fkocs2003";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "act_date";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell22.CellWidth = 78;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdCol = false;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "ho_dong";
            this.xEditGridCell1.CellWidth = 86;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdCol = false;
            this.xEditGridCell1.SuppressRepeating = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "ho_code";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdCol = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "bunryu2";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "chulgo_qty";
            this.xEditGridCell28.CellWidth = 40;
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "chulgo_date";
            this.xEditGridCell29.CellWidth = 30;
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "drg_bunho";
            this.xEditGridCell5.CellWidth = 61;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "dc_yn";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "order_danui_name";
            this.xEditGridCell15.CellWidth = 75;
            this.xEditGridCell15.Col = 10;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsUpdCol = false;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "user_name";
            this.xEditGridCell41.CellWidth = 82;
            this.xEditGridCell41.Col = 11;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsUpdCol = false;
            // 
            // cboGubun
            // 
            this.cboGubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3});
            resources.ApplyResources(this.cboGubun, "cboGubun");
            this.cboGubun.Name = "cboGubun";
            this.cboGubun.SelectionChangeCommitted += new System.EventHandler(this.cbo_SelectedIndexChanged);
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "N";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "Y";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "%";
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.xLabel4);
            this.panTop.Controls.Add(this.cboGubun);
            this.panTop.Controls.Add(this.dtpBanNabFr);
            this.panTop.Controls.Add(this.xLabel3);
            this.panTop.Controls.Add(this.cboDong);
            this.panTop.Controls.Add(this.xLabel1);
            this.panTop.Controls.Add(this.xLabel2);
            this.panTop.Controls.Add(this.paid);
            this.panTop.Controls.Add(this.dtpBanNabTo);
            resources.ApplyResources(this.panTop, "panTop");
            this.panTop.DrawBorder = true;
            this.panTop.Name = "panTop";
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdDrg3010);
            this.xPanel1.Controls.Add(this.grdNur1005);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // grdNur1005
            // 
            this.grdNur1005.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell23,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40});
            this.grdNur1005.ColPerLine = 9;
            this.grdNur1005.Cols = 10;
            this.grdNur1005.ExecuteQuery = null;
            this.grdNur1005.FixedCols = 1;
            this.grdNur1005.FixedRows = 1;
            this.grdNur1005.HeaderHeights.Add(20);
            resources.ApplyResources(this.grdNur1005, "grdNur1005");
            this.grdNur1005.Name = "grdNur1005";
            this.grdNur1005.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdNur1005.ParamList")));
            this.grdNur1005.QuerySQL = resources.GetString("grdNur1005.QuerySQL");
            this.grdNur1005.ReadOnly = true;
            this.grdNur1005.RowHeaderVisible = true;
            this.grdNur1005.Rows = 2;
            this.grdNur1005.RowStateCheckOnPaint = false;
            this.grdNur1005.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNur1005_QueryStarting);
            this.grdNur1005.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdNur1005_QueryEnd);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "ho_dong1";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "ho_code1";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "bunho";
            this.xEditGridCell23.CellWidth = 90;
            this.xEditGridCell23.Col = 2;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "suname";
            this.xEditGridCell30.CellWidth = 120;
            this.xEditGridCell30.Col = 3;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "hangmog_code";
            this.xEditGridCell31.CellWidth = 90;
            this.xEditGridCell31.Col = 5;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "hangmog_name";
            this.xEditGridCell32.CellWidth = 243;
            this.xEditGridCell32.Col = 6;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "subul_suyang";
            this.xEditGridCell33.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell33.CellWidth = 55;
            this.xEditGridCell33.Col = 7;
            this.xEditGridCell33.DecimalDigits = 1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "subul_danui";
            this.xEditGridCell34.CellWidth = 50;
            this.xEditGridCell34.Col = 8;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "nurse_confirm_user";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "memb_name";
            this.xEditGridCell36.CellWidth = 100;
            this.xEditGridCell36.Col = 4;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "order_date";
            this.xEditGridCell37.CellWidth = 130;
            this.xEditGridCell37.Col = 1;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "jundal_part";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "jundal_part_name";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "bannab_confirm";
            this.xEditGridCell40.CellWidth = 37;
            this.xEditGridCell40.Col = 9;
            this.xEditGridCell40.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // layOrder
            // 
            this.layOrder.ExecuteQuery = null;
            this.layOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrder.ParamList")));
            // 
            // xdwWorker1
            // 
            this.xdwWorker1.DataWindowObject = "dw_nur1005p01";
            this.xdwWorker1.IsPreviewStatusPopup = true;
            this.xdwWorker1.LibraryList = "..\\DRGS\\drgs.drg3010u51.pbd";
            this.xdwWorker1.PaperSize = IHIS.Framework.DataWindowPaperSize.A4;
            // 
            // DRG3010U51
            // 
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.panTop);
            this.Name = "DRG3010U51";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.paid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg3010)).EndInit();
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNur1005)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layOrder)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region Common Properties
        private string mHospCode = EnvironInfo.HospCode;
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			this.dtpBanNabFr.SetDataValue(EnvironInfo.GetSysDate());
			this.dtpBanNabTo.SetDataValue(EnvironInfo.GetSysDate());
			cboDong.SelectedIndex  =0;
			cboGubun.SelectedIndex =0;
		}
		#endregion

		#region xButtonList1_ButtonClick
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					this.CurrMQLayout = this.grdDrg3010;
					break;

				case FunctionType.Process:

					for(int i=0; i< grdDrg3010.RowCount; i++)
					{
						if (grdDrg3010.GetItemString(i,"bannab_confirm") == "Y")
							grdDrg3010.SetItemValue(i,"bannab_confirm","N");
						else
							grdDrg3010.SetItemValue(i,"bannab_confirm","Y");
					}
					break;

				case FunctionType.Print:
                    if (!grdNur1005.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
					break;

				case FunctionType.Update:
					e.IsBaseCall = false;
                    if (!grdDrg3010.SaveLayout())
                    {
                        XMessageBox.Show(Service.ErrFullMsg, "Error");
                    }
                    else
                    {
                        grdDrg3010.QueryLayout(true);
                    }
					break;

				default:
					break;
			}		
		}
		#endregion

		private void grdDrg3010_SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
		{
			if (e.IsSuccess != true)
			{
				XMessageBox.Show(Service.ErrFullMsg, "Error");
			}
		}

        private void grdNur1005_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			if (e.IsSuccess == true)
			{
				if(this.grdNur1005.RowCount > 0)
				{
					try
					{
                        //SetCheckImage();
						//xdwWorker1.PrinterName = "NEC MultiWriter1500N";
                        xdwWorker1.SourceTable = grdNur1005.LayoutTable;
						xdwWorker1.Print();
					}
					catch(Exception Xe)
					{
						XMessageBox.Show(Xe.Message.ToString());
						return;
					}
				}
			}
        }

        public void SetCheckImage()
        {
            //Footer의 왼쪽, 오른쪽에 이미지를 공통으로 관리하여 DataWindow에 Set
            //Footer에 있는 Computed Field의 이름은 좌측은 hospital_image
            //Image는 IFC/Images에서 관리하고 왼쪽에 LeftFooter.gif
            //DataWindow에 있는 Object 목록 Get
            //xdwWorker1.DWViewer.Create("bitmap(band=detail filename=\"" + "D:\\IHIS.Project\\IHIS.Project\\Images\\버튼이미지\\check.gif\\" + " x=\"" + "1016\"" + " y=\"" +"1\"" + " height=\"" + "15\"" + " width=\"" + "15\"" + " border=\"" + "0\"" + " name=check_p_2 visible=\"" + "1~tif (  bannab_confirm = 'Y' , 1, 0 )\"" + ")");
            //xdwWorker1.DWViewer.SetObjectImage("bannab_confirm", "D:\\IHIS.Project\\IHIS.Project\\Images\\버튼이미지\\check.gif\\");

            xdwWorker1.DWViewer.Modify("'Bitmap(band=footer filename=\"" + @"C:\IHIS\Images\FOOTER.jpg" + " x=\"" + "8\"" + " y=\"" + "3\"" + " height=\"" + "25\"" + " width=\"" + "226\"" + " border=\"" + "0\"" + "  name=p_3 visible=\"" + "1\"" + ")'");


            //xdwWorker1.DWViewer.Modify("'bitmap(band=footer filename=\"" + "D:\\IHIS.Project\\IHIS.Project\\Images\\버튼이미지\\check.gif\\" + " name=check_p_2" +" x=\"" + "1016\"" + " y=\"" + "1\")'");
            //xdwWorker1.DWViewer.Modify("'text(band=footer name=check_p_2)'");
            //xdwWorker1.DWViewer.Modify("bitmap(band=detail filename=\"" + "D:\\IHIS.Project\\IHIS.Project\\Images\\버튼이미지\\check.gif\\" + " x=\"" + "1016\"" + " y=\"" + "1\"" + " height=\"" + "15\"" + " width=\"" + "15\"" + " border=\"" + "0\"" + " name=check_p_2 visible=\"" + "1~tif (  bannab_confirm = 'Y' , 1, 0 )\"" + ")");
            //파일이 존재하고 Object가 있으면
            //if (File.Exists(fileName) && (setting.IndexOf("hospital_image") >= 0))
            //{
            //    try
            //    {
            //        modify = "hospital_name.Expression='Bitmap(\"" + fileName + "\")'";
            //        this.Modify(modify);
            //    }
            //    catch { }
            //}
        }

        #region 각 그리드에 바인드변수 지정
        private void grdDrg3010_QueryStarting(object sender, CancelEventArgs e)
        {
            grdDrg3010.SetBindVarValue("f_jubsu_date",    dtpBanNabFr.GetDataValue().ToString().Replace("-", "").Replace("/", ""));
            grdDrg3010.SetBindVarValue("f_jubsu_date_to", dtpBanNabTo.GetDataValue().ToString().Replace("-", "").Replace("/", ""));
            grdDrg3010.SetBindVarValue("f_gubun",         cboGubun.GetDataValue());
            grdDrg3010.SetBindVarValue("f_bunho",         paid.BunHo);
            grdDrg3010.SetBindVarValue("f_ho_dong",       cboDong.GetDataValue());
            grdDrg3010.SetBindVarValue("f_hosp_code",     mHospCode);
        }

        private void grdNur1005_QueryStarting(object sender, CancelEventArgs e)
        {
            grdNur1005.SetBindVarValue("f_from_date", dtpBanNabFr.GetDataValue().ToString().Replace("-", "").Replace("/", ""));
            grdNur1005.SetBindVarValue("f_to_date",   dtpBanNabTo.GetDataValue().ToString().Replace("-", "").Replace("/", ""));
            grdNur1005.SetBindVarValue("f_chulgo_yn", cboGubun.GetDataValue());
            grdNur1005.SetBindVarValue("f_bunho", paid.BunHo);
            grdNur1005.SetBindVarValue("f_ho_dong",   cboDong.GetDataValue());
            grdNur1005.SetBindVarValue("f_hosp_code", mHospCode);
        }
        #endregion

        #region XSavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private DRG3010U51 parent = null;
            public XSavePerformer(DRG3010U51 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);

                cmdText = @"BEGIN
  IF NVL(:f_bunryu2, 'N') <> '1' THEN
                                          
    PR_DRG_OCS_BANNAB('I', :f_bannab_confirm, :f_fkocs2003, :f_subul_danui, :f_subul_suryang);
                                        
    UPDATE DRG3010
       SET UPD_ID    = :q_user_id
          ,UPD_DATE  = SYSDATE
     WHERE FKOCS2003 = :f_fkocs2003
       AND HOSP_CODE = :f_hosp_code;
                                         
  ELSIF NVL(:f_bunryu2, 'N') = '1' THEN
    IF :f_bannab_confirm = 'Y' THEN
      PR_DRG_MAYAK_IPGO(:f_fkocs2003, 'PA', :q_user_id, '3', '1');
    ELSE
      PR_DRG_MAYAK_IPGO(:f_fkocs2003, 'PA', :q_user_id, '3', '2');
    END IF;
  END IF;
END;";

                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        #region 그리드 쿼리 이벤트 메소드
        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdDrg3010.QueryLayout(true);
        }

        private void dtp_DataValidating(object sender, DataValidatingEventArgs e)
        {
            grdDrg3010.QueryLayout(true);
        }

        private void paid_PatientSelected(object sender, EventArgs e)
        {
            grdDrg3010.QueryLayout(true);
        }
        #endregion

        private void grdDrg3010_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["bannab_confirm"].ToString() == "Y")
                e.BackColor = Color.MistyRose;
        }

        

        
    }
}

