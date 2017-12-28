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
	/// DRG3010Q01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG3010Q01 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XPatientBox paid;
		private IHIS.Framework.XPanel panTop;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XDatePicker dtpOrderDt;
		private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XButton xButton4;
        private IHIS.Framework.XEditGrid grdDrg3011;
		private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XEditMask txtTuYak;
		private IHIS.X.Magic.Controls.TabPage tabPage1;
		private IHIS.X.Magic.Controls.TabPage tabPage2;
		private IHIS.X.Magic.Controls.TabPage tabPage3;
		private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XTabControl tpCon;
		private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XComboItem xComboItem3;
		private IHIS.Framework.XComboItem xComboItem4;
		private IHIS.Framework.XComboItem xComboItem5;
		private IHIS.Framework.XComboItem xComboItem6;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XEditGridCell xEditGridCell61;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell62;
		private IHIS.Framework.XEditGridCell xEditGridCell63;
		private IHIS.Framework.XEditGridCell xEditGridCell60;
		private IHIS.Framework.XEditGridCell xEditGridCell38;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
		private IHIS.Framework.XEditGridCell xEditGridCell64;
		private IHIS.Framework.XEditGridCell xEditGridCell39;
		private IHIS.Framework.XEditGridCell xEditGridCell66;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
		private IHIS.Framework.XEditGridCell xEditGridCell43;
		private IHIS.Framework.XEditGrid grdDrg3012;
        private IHIS.Framework.XEditGridCell xEditGridCell44;
		private IHIS.Framework.XComboItem xComboItem9;
		private IHIS.Framework.XComboItem xComboItem10;
		private IHIS.Framework.MultiLayout Lay9005q01;
 //       private IHIS.Framework.XDataWindow dw1;
		private IHIS.Framework.XButton btnPrint;
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
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem38;
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
        private XComboItem xComboItem7;
        private XComboItem xComboItem8;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private Splitter splitter1;
        private XEditGrid grdDrg3010;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell45;
        private XEditGridCell xEditGridCell46;
        private XEditGridCell xEditGridCell47;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DRG3010Q01()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG3010Q01));
            this.paid = new IHIS.Framework.XPatientBox();
            this.dtpOrderDt = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.grdDrg3011 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.panTop = new IHIS.Framework.XPanel();
            this.txtTuYak = new IHIS.Framework.XEditMask();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.grdDrg3010 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnPrint = new IHIS.Framework.XButton();
            this.xButton4 = new IHIS.Framework.XButton();
            this.tpCon = new IHIS.Framework.XTabControl();
            this.tabPage1 = new IHIS.X.Magic.Controls.TabPage();
            this.tabPage2 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdDrg3012 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xComboItem9 = new IHIS.Framework.XComboItem();
            this.xComboItem10 = new IHIS.Framework.XComboItem();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.tabPage3 = new IHIS.X.Magic.Controls.TabPage();
            this.Lay9005q01 = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
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
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            ((System.ComponentModel.ISupportInitialize)(this.paid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg3011)).BeginInit();
            this.panTop.SuspendLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg3010)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.tpCon.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg3012)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lay9005q01)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "출력.gif");
            // 
            // paid
            // 
            resources.ApplyResources(this.paid, "paid");
            this.paid.Name = "paid";
            this.paid.ShowBoxImage = false;
            this.paid.PatientSelected += new System.EventHandler(this.paid_PatientSelected);
            // 
            // dtpOrderDt
            // 
            resources.ApplyResources(this.dtpOrderDt, "dtpOrderDt");
            this.dtpOrderDt.IsVietnameseYearType = false;
            this.dtpOrderDt.Name = "dtpOrderDt";
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel1.Name = "xLabel1";
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell44.CellName = "jugi_yn";
            this.xEditGridCell44.Col = 1;
            this.xEditGridCell44.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell44.SuppressRepeating = true;
            this.xEditGridCell44.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdDrg3011
            // 
            resources.ApplyResources(this.grdDrg3011, "grdDrg3011");
            this.grdDrg3011.ApplyPaintEventToAllColumn = true;
            this.grdDrg3011.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12});
            this.grdDrg3011.ColPerLine = 11;
            this.grdDrg3011.ColResizable = true;
            this.grdDrg3011.Cols = 12;
            this.grdDrg3011.ExecuteQuery = null;
            this.grdDrg3011.FixedCols = 1;
            this.grdDrg3011.FixedRows = 1;
            this.grdDrg3011.HeaderHeights.Add(21);
            this.grdDrg3011.Name = "grdDrg3011";
            this.grdDrg3011.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDrg3011.ParamList")));
            this.grdDrg3011.QuerySQL = resources.GetString("grdDrg3011.QuerySQL");
            this.grdDrg3011.ReadOnly = true;
            this.grdDrg3011.RowHeaderVisible = true;
            this.grdDrg3011.Rows = 2;
            this.grdDrg3011.ToolTipActive = true;
            this.grdDrg3011.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdDrg3011_RowFocusChanged);
            this.grdDrg3011.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDrg3011_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "doctor_name";
            this.xEditGridCell1.CellWidth = 123;
            this.xEditGridCell1.Col = 5;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdCol = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "order_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.CellWidth = 112;
            this.xEditGridCell2.Col = 4;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdCol = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "nurse__name";
            this.xEditGridCell3.CellWidth = 120;
            this.xEditGridCell3.Col = 7;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdCol = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "nurse_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 120;
            this.xEditGridCell4.Col = 6;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdCol = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "drg_name";
            this.xEditGridCell5.CellWidth = 113;
            this.xEditGridCell5.Col = 9;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdCol = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "drg_date";
            this.xEditGridCell6.CellWidth = 119;
            this.xEditGridCell6.Col = 8;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdCol = false;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "jubsu_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "drg_bunho";
            this.xEditGridCell8.CellWidth = 64;
            this.xEditGridCell8.Col = 3;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdCol = false;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "bunho";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "chulgo";
            this.xEditGridCell10.CellWidth = 105;
            this.xEditGridCell10.Col = 10;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsUpdCol = false;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "magam_gubun";
            this.xEditGridCell11.CellWidth = 90;
            this.xEditGridCell11.Col = 11;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsUpdCol = false;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "ho_dong";
            this.xEditGridCell12.CellWidth = 35;
            this.xEditGridCell12.Col = 2;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            // 
            // panTop
            // 
            resources.ApplyResources(this.panTop, "panTop");
            this.panTop.Controls.Add(this.paid);
            this.panTop.Controls.Add(this.txtTuYak);
            this.panTop.Controls.Add(this.xLabel3);
            this.panTop.Controls.Add(this.xLabel2);
            this.panTop.Controls.Add(this.dtpOrderDt);
            this.panTop.Controls.Add(this.xLabel1);
            this.panTop.DrawBorder = true;
            this.panTop.Name = "panTop";
            // 
            // txtTuYak
            // 
            resources.ApplyResources(this.txtTuYak, "txtTuYak");
            this.txtTuYak.EditMaskType = IHIS.Framework.MaskType.Number;
            this.txtTuYak.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.txtTuYak.IsVietnameseYearType = false;
            this.txtTuYak.Name = "txtTuYak";
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel2.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xLabel2.Name = "xLabel2";
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.grdDrg3010);
            this.xPanel1.Controls.Add(this.splitter1);
            this.xPanel1.Controls.Add(this.grdDrg3011);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // grdDrg3010
            // 
            resources.ApplyResources(this.grdDrg3010, "grdDrg3010");
            this.grdDrg3010.ApplyPaintEventToAllColumn = true;
            this.grdDrg3010.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47});
            this.grdDrg3010.ColPerLine = 9;
            this.grdDrg3010.ColResizable = true;
            this.grdDrg3010.Cols = 10;
            this.grdDrg3010.ControlBinding = true;
            this.grdDrg3010.ExecuteQuery = null;
            this.grdDrg3010.FixedCols = 1;
            this.grdDrg3010.FixedRows = 1;
            this.grdDrg3010.HeaderHeights.Add(21);
            this.grdDrg3010.Name = "grdDrg3010";
            this.grdDrg3010.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDrg3010.ParamList")));
            this.grdDrg3010.QuerySQL = resources.GetString("grdDrg3010.QuerySQL");
            this.grdDrg3010.ReadOnly = true;
            this.grdDrg3010.RowHeaderVisible = true;
            this.grdDrg3010.Rows = 2;
            this.grdDrg3010.ToolTipActive = true;
            this.grdDrg3010.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDrg3010_QueryStarting);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "ho_dong";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdCol = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "magam_gubun";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "drg_bunho";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "bunho";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "jubsu_date";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "order_date";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell18.CellWidth = 100;
            this.xEditGridCell18.Col = 1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdCol = false;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "jaeryo_code";
            this.xEditGridCell19.CellWidth = 115;
            this.xEditGridCell19.Col = 2;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdCol = false;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "nalsu";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell20.CellWidth = 75;
            this.xEditGridCell20.Col = 9;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdCol = false;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "ord_suryang";
            this.xEditGridCell21.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell21.Col = 8;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdCol = false;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "order_danui";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdCol = false;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "bogyong_code";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsUpdCol = false;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellLen = 35;
            this.xEditGridCell24.CellName = "atc_yn";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdCol = false;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "dv";
            this.xEditGridCell25.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell25.CellWidth = 48;
            this.xEditGridCell25.Col = 7;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdCol = false;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "dv_time";
            this.xEditGridCell26.CellWidth = 34;
            this.xEditGridCell26.Col = 5;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdCol = false;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "jaeryo_name";
            this.xEditGridCell27.CellWidth = 262;
            this.xEditGridCell27.Col = 3;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsUpdCol = false;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "powder_yn";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "fkocs2003";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "bogyong_name";
            this.xEditGridCell45.CellWidth = 263;
            this.xEditGridCell45.Col = 4;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsReadOnly = true;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "danui_name";
            this.xEditGridCell46.CellWidth = 105;
            this.xEditGridCell46.Col = 6;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsReadOnly = true;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "dc_yn";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsReadOnly = true;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.btnPrint);
            this.xPanel2.Controls.Add(this.xButton4);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.ImageIndex = 1;
            this.btnPrint.ImageList = this.ImageList;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // xButton4
            // 
            resources.ApplyResources(this.xButton4, "xButton4");
            this.xButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            this.xButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xButton4.ImageIndex = 0;
            this.xButton4.ImageList = this.ImageList;
            this.xButton4.Name = "xButton4";
            this.xButton4.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.xButton4.Click += new System.EventHandler(this.xButton4_Click);
            // 
            // tpCon
            // 
            resources.ApplyResources(this.tpCon, "tpCon");
            this.tpCon.IDEPixelArea = true;
            this.tpCon.IDEPixelBorder = false;
            this.tpCon.Name = "tpCon";
            this.tpCon.SelectedIndex = 0;
            this.tpCon.SelectedTab = this.tabPage1;
            this.tpCon.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3});
            this.tpCon.SelectionChanged += new System.EventHandler(this.tpCon_SelectionChanged);
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.xPanel1);
            this.tabPage1.Name = "tabPage1";
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.xPanel5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            // 
            // xPanel5
            // 
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.Controls.Add(this.grdDrg3012);
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Name = "xPanel5";
            // 
            // grdDrg3012
            // 
            resources.ApplyResources(this.grdDrg3012, "grdDrg3012");
            this.grdDrg3012.ApplyPaintEventToAllColumn = true;
            this.grdDrg3012.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell61,
            this.xEditGridCell36,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell60,
            this.xEditGridCell38,
            this.xEditGridCell37,
            this.xEditGridCell64,
            this.xEditGridCell39,
            this.xEditGridCell66,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43});
            this.grdDrg3012.ColPerLine = 12;
            this.grdDrg3012.ColResizable = true;
            this.grdDrg3012.Cols = 13;
            this.grdDrg3012.ControlBinding = true;
            this.grdDrg3012.ExecuteQuery = null;
            this.grdDrg3012.FixedCols = 1;
            this.grdDrg3012.FixedRows = 1;
            this.grdDrg3012.HeaderHeights.Add(31);
            this.grdDrg3012.Name = "grdDrg3012";
            this.grdDrg3012.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDrg3012.ParamList")));
            this.grdDrg3012.QuerySQL = resources.GetString("grdDrg3012.QuerySQL");
            this.grdDrg3012.RowHeaderVisible = true;
            this.grdDrg3012.Rows = 2;
            this.grdDrg3012.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdDrg3012_GridCellPainting);
            this.grdDrg3012.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDrg3012_QueryStarting);
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "ho_dong";
            this.xEditGridCell30.Col = 2;
            this.xEditGridCell30.EnableSort = true;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsUpdCol = false;
            this.xEditGridCell30.SuppressRepeating = true;
            this.xEditGridCell30.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "magam_gubun";
            this.xEditGridCell31.CellWidth = 53;
            this.xEditGridCell31.Col = 5;
            this.xEditGridCell31.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3,
            this.xComboItem4,
            this.xComboItem5,
            this.xComboItem6,
            this.xComboItem9,
            this.xComboItem10});
            this.xEditGridCell31.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell31.EnableSort = true;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.SuppressRepeating = true;
            this.xEditGridCell31.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "11";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "12";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "ER";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "31";
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "21";
            // 
            // xComboItem6
            // 
            resources.ApplyResources(this.xComboItem6, "xComboItem6");
            this.xComboItem6.ValueItem = "22";
            // 
            // xComboItem9
            // 
            resources.ApplyResources(this.xComboItem9, "xComboItem9");
            this.xComboItem9.ValueItem = "WE";
            // 
            // xComboItem10
            // 
            resources.ApplyResources(this.xComboItem10, "xComboItem10");
            this.xComboItem10.ValueItem = "MI";
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "drg_bunho";
            this.xEditGridCell32.CellWidth = 60;
            this.xEditGridCell32.Col = 4;
            this.xEditGridCell32.EnableSort = true;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.SuppressRepeating = true;
            this.xEditGridCell32.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "bunho";
            this.xEditGridCell33.CellWidth = 25;
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "jubsu_date";
            this.xEditGridCell34.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell34.Col = 1;
            this.xEditGridCell34.EnableSort = true;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsUpdCol = false;
            this.xEditGridCell34.SuppressRepeating = true;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "order_date";
            this.xEditGridCell35.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell35.Col = 3;
            this.xEditGridCell35.EnableSort = true;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.IsUpdCol = false;
            this.xEditGridCell35.SuppressRepeating = true;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "jaeryo_code";
            this.xEditGridCell61.Col = 6;
            this.xEditGridCell61.EnableSort = true;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsReadOnly = true;
            this.xEditGridCell61.IsUpdCol = false;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "nalsu";
            this.xEditGridCell36.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell36.CellWidth = 30;
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.EnableSort = true;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsUpdCol = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "ord_suryang";
            this.xEditGridCell62.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell62.CellWidth = 40;
            this.xEditGridCell62.Col = 8;
            this.xEditGridCell62.EnableSort = true;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsReadOnly = true;
            this.xEditGridCell62.IsUpdCol = false;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "order_danui";
            this.xEditGridCell63.CellWidth = 50;
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsReadOnly = true;
            this.xEditGridCell63.IsUpdCol = false;
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "bogyong_code";
            this.xEditGridCell60.CellWidth = 183;
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
            this.xEditGridCell60.IsUpdCol = false;
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellLen = 35;
            this.xEditGridCell38.CellName = "atc_yn";
            this.xEditGridCell38.CellWidth = 40;
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsUpdCol = false;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "dv";
            this.xEditGridCell37.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell37.CellWidth = 30;
            this.xEditGridCell37.Col = 10;
            this.xEditGridCell37.EnableSort = true;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.IsUpdCol = false;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "dv_time";
            this.xEditGridCell64.CellWidth = 30;
            this.xEditGridCell64.Col = 9;
            this.xEditGridCell64.EnableSort = true;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsReadOnly = true;
            this.xEditGridCell64.IsUpdCol = false;
            this.xEditGridCell64.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "jaeryo_name";
            this.xEditGridCell39.CellWidth = 215;
            this.xEditGridCell39.Col = 7;
            this.xEditGridCell39.EnableSort = true;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsUpdCol = false;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "powder_yn";
            this.xEditGridCell66.CellWidth = 25;
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.EnableSort = true;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsReadOnly = true;
            this.xEditGridCell66.IsUpdCol = false;
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            this.xEditGridCell66.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "fkocs2003";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "bogyong_name";
            this.xEditGridCell41.CellWidth = 275;
            this.xEditGridCell41.Col = 12;
            this.xEditGridCell41.EnableSort = true;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsReadOnly = true;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "danui_name";
            this.xEditGridCell42.CellWidth = 60;
            this.xEditGridCell42.Col = 11;
            this.xEditGridCell42.EnableSort = true;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsReadOnly = true;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "dc_yn";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsReadOnly = true;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            // 
            // Lay9005q01
            // 
            this.Lay9005q01.ExecuteQuery = null;
            this.Lay9005q01.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem18,
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
            this.multiLayoutItem36,
            this.multiLayoutItem37,
            this.multiLayoutItem38,
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
            this.multiLayoutItem52});
            this.Lay9005q01.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("Lay9005q01.ParamList")));
            this.Lay9005q01.QuerySQL = resources.GetString("Lay9005q01.QuerySQL");
            this.Lay9005q01.QueryStarting += new System.ComponentModel.CancelEventHandler(this.Lay9005q01_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "ho_dong";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "doctor_code";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "doctor_name";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "suname";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "gwa_name";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "jejo_name";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "sex";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "use_jaeryo_count";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "birth";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "age";
            this.multiLayoutItem11.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "inwon_date";
            this.multiLayoutItem12.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "taewon_date";
            this.multiLayoutItem13.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "ho_code";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "order_date";
            this.multiLayoutItem15.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "danui";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "jaeryo_name";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "num01";
            this.multiLayoutItem18.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "num02";
            this.multiLayoutItem19.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "num03";
            this.multiLayoutItem20.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "num04";
            this.multiLayoutItem21.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "num05";
            this.multiLayoutItem22.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "num06";
            this.multiLayoutItem23.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "num07";
            this.multiLayoutItem24.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "num08";
            this.multiLayoutItem25.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "num09";
            this.multiLayoutItem26.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "num10";
            this.multiLayoutItem27.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "num11";
            this.multiLayoutItem28.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "num12";
            this.multiLayoutItem29.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "num13";
            this.multiLayoutItem30.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "num14";
            this.multiLayoutItem31.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "num15";
            this.multiLayoutItem32.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "num16";
            this.multiLayoutItem33.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "num17";
            this.multiLayoutItem34.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "num18";
            this.multiLayoutItem35.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "num19";
            this.multiLayoutItem36.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "num20";
            this.multiLayoutItem37.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "num21";
            this.multiLayoutItem38.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "num22";
            this.multiLayoutItem39.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "num23";
            this.multiLayoutItem40.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "num24";
            this.multiLayoutItem41.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "num25";
            this.multiLayoutItem42.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "num26";
            this.multiLayoutItem43.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "num27";
            this.multiLayoutItem44.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "num28";
            this.multiLayoutItem45.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "num29";
            this.multiLayoutItem46.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "num30";
            this.multiLayoutItem47.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "num31";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "in_out";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "yyyymm";
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "donbon_yn";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "magam_gubun";
            // 
            // xComboItem7
            // 
            resources.ApplyResources(this.xComboItem7, "xComboItem7");
            this.xComboItem7.ValueItem = "Y";
            // 
            // xComboItem8
            // 
            resources.ApplyResources(this.xComboItem8, "xComboItem8");
            this.xComboItem8.ValueItem = "N";
            // 
            // DRG3010Q01
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tpCon);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.panTop);
            this.Name = "DRG3010Q01";
            ((System.ComponentModel.ISupportInitialize)(this.paid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg3011)).EndInit();
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg3010)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.tpCon.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg3012)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lay9005q01)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			this.dtpOrderDt.SetDataValue(EnvironInfo.GetSysDate());
		}
		#endregion

		#region xButtonList1_ButtonClick
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					OrderQuery1();
					break;
				case FunctionType.Process:
					e.IsBaseCall = false;
					break;
				case FunctionType.Cancel:
					e.IsBaseCall = false;
					break;
			}		
		}
		#endregion

        #region Common Properties
        private string mHospCode = EnvironInfo.HospCode;
        #endregion

        #region


        private void OrderQuery1()
		{
            if (TypeCheck.IsNull(paid.BunHo))
            {
                XMessageBox.Show("患者番号を入力してください。");
                paid.Focus();
                return;
            }

            if (tpCon.SelectedIndex == 0 )
			{
                if (!grdDrg3011.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
			}
			else if (tpCon.SelectedIndex == 1 )
			{
                if (!grdDrg3012.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
			}
			else if (tpCon.SelectedIndex == 2 )
			{
                ArrayList inputList = new ArrayList();
                inputList.Add(UserInfo.UserID);
                inputList.Add(dtpOrderDt.GetDataValue().Replace("-", "").Replace("/", "").Substring(0, 6));
                inputList.Add(TypeCheck.NVL(paid.BunHo,"%").ToString());
                inputList.Add("I");
                ArrayList outputList = new ArrayList();
                if (Service.ExecuteProcedure("PR_DRG_INSERT_DRG9005_SERIES", inputList, outputList))
                {
                    if (!Lay9005q01.QueryLayout(false))
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                        return;
                    }
                }
                else
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                    return;
                }

                //dw1.Reset();
                ////string where = "yyyymm = " + "'" + dtpOrderDt.GetDataValue().ToString() + "'";

                ////DataRow[] rows = Lay9005q01.LayoutTable.Select(where);
                //dw1.FillData(Lay9005q01.LayoutTable);
                //dw1.Modify("t_1.text = '" + dtpOrderDt.Text.Substring(0,7) + "'");
                //dw1.Modify("t_2.text = '" + paid.BunHo + ":" + paid.SuName + "'");
                //dw1.AcceptText();	
                //dw1.Refresh();
			}
		}

		#endregion

        private void grdDrg3010_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
            if (e.DataRow["drg_bunho"].ToString() == "")
            {
                e.BackColor = Color.Khaki;
            }

            if (e.DataRow["dc_yn"].ToString() == "Y")
            {
                switch (e.ColName)
                {
                    case "jaeryo_code":
                        e.DrawMiddleLine = true;
                        e.MiddleLineColor = Color.Red;
                        break;
                    case "jaeryo_name":
                        e.DrawMiddleLine = true;
                        e.MiddleLineColor = Color.Red;
                        break;
                    default:
                        break;
                }
            }

		}

		private void paid_PatientSelected(object sender, System.EventArgs e)
		{
			OrderQuery1();
		}

		private void xButton4_Click(object sender, System.EventArgs e)
		{
			string drg_bunho = "", jubsu_date = "";
			
			if (grdDrg3010.CurrentRowNumber < 0) return;
			jubsu_date = grdDrg3010.GetItemString(grdDrg3010.CurrentRowNumber, "jubsu_date");
			drg_bunho  = grdDrg3010.GetItemString(grdDrg3010.CurrentRowNumber, "drg_bunho");
			
			if ( XMessageBox.Show("締切取消し実行を続きますか。","締切取消し",MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
                ArrayList inputList = new ArrayList();
                ArrayList outputList = new ArrayList();
                inputList.Add(jubsu_date);
                inputList.Add(drg_bunho);
                inputList.Add(UserInfo.UserID);
                inputList.Add(mHospCode);

                if (!Service.ExecuteProcedure("PR_DRG_INP_DRG_BUNHO_CANCEL", inputList, outputList))
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                }
			}
		}

		private void grdDrg3011_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
            if (!grdDrg3010.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
		}

		private void tpCon_SelectionChanged(object sender, System.EventArgs e)
		{
			OrderQuery1();
		}

		private void grdDrg3012_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (e.DataRow["drg_bunho"].ToString() == "")
			{
				if (e.DataRow["magam_gubun"].ToString() == "WE")
				{
					e.BackColor = XColor.XPanelBorderColor.Color;
				}
				else if (e.DataRow["magam_gubun"].ToString() == "MI")
				{
					e.BackColor = XColor.XGroupBoxForeColor.Color;
				}
				else
				{
					e.BackColor = Color.Khaki;
				}
			}

			if (e.DataRow["dc_yn"].ToString() == "Y")
			{
				switch (e.ColName)
				{
					case "jaeryo_code": 
						e.DrawMiddleLine  = true;
						e.MiddleLineColor = Color.Red;
						break;
					case "jaeryo_name":
						e.DrawMiddleLine  = true;
						e.MiddleLineColor = Color.Red;
						break;
					default:
						break;
				}
			}
		}

		private void grdDrg3010_GridCellPainting_1(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (e.DataRow["jugi_yn"].ToString() == "N")
			{
				if  (e.ColName == "jugi_yn" ) e.ForeColor = Color.Red;
			}

			if (e.DataRow["dc_yn"].ToString() == "Y")
			{
				switch (e.ColName)
				{
					case "jaeryo_code": 
						e.DrawMiddleLine  = true;
						e.MiddleLineColor = Color.Red;
						break;
					case "jaeryo_name":
						e.DrawMiddleLine  = true;
						e.MiddleLineColor = Color.Red;
						break;
					default:
						break;
				}
			}
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
            //if (dw1.RowCount > 0)
            //    dw1.Print();
        }

        #region 각 그리드/레이아웃에 바인드변수 설정
        private void Lay9005q01_QueryStarting(object sender, CancelEventArgs e)
        {
            Lay9005q01.SetBindVarValue("f_bunho", TypeCheck.NVL(paid.BunHo,"%").ToString());
            Lay9005q01.SetBindVarValue("f_month", this.dtpOrderDt.GetDataValue());
        }
        #endregion

        private void grdDrg3011_QueryStarting(object sender, CancelEventArgs e)
        {
            grdDrg3011.SetBindVarValue("f_bunho", TypeCheck.NVL(paid.BunHo, "%").ToString());
            grdDrg3011.SetBindVarValue("f_jubsu_date", dtpOrderDt.GetDataValue());
            grdDrg3011.SetBindVarValue("f_drg_bunho", txtTuYak.GetDataValue());
            grdDrg3011.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdDrg3010_QueryStarting(object sender, CancelEventArgs e)
        {
            grdDrg3010.SetBindVarValue("f_bunho", grdDrg3011.GetItemString(grdDrg3011.CurrentRowNumber, "bunho"));
            grdDrg3010.SetBindVarValue("f_drg_bunho", grdDrg3011.GetItemString(grdDrg3011.CurrentRowNumber, "drg_bunho"));
            grdDrg3010.SetBindVarValue("f_jubsu_date", grdDrg3011.GetItemString(grdDrg3011.CurrentRowNumber, "jubsu_date").Replace("-", "").Replace("/", "").Substring(0, 8));
            grdDrg3010.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdDrg3012_QueryStarting(object sender, CancelEventArgs e)
        {
            grdDrg3012.SetBindVarValue("f_bunho", TypeCheck.NVL(paid.BunHo, "%").ToString());
            grdDrg3012.SetBindVarValue("f_jubsu_date", dtpOrderDt.GetDataValue());
            grdDrg3012.SetBindVarValue("f_hosp_code", mHospCode);
        }
    }
}

