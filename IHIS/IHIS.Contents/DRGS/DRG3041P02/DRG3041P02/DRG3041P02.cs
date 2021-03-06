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
	/// DRG3041P02에 대한 요약 설명입니다.
	/// </summary> 
	[ToolboxItem(false)]
	public class DRG3041P02 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel pnlMain;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XEditGrid grdIpgoList;
        private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XButton btnCancel;
	//	private IHIS.Framework.XDataWindow dw_lable;
        private IHIS.Framework.MultiLayout layJusaLable;
		private System.Windows.Forms.GroupBox groupBox1;
        private IHIS.Framework.XPatientBox PaBox;
        private IHIS.Framework.XDatePicker dtpChulgoDate;
        private IHIS.Framework.XButton btnJusaLabel;
		private IHIS.Framework.XPanel pnlMagamGrd;
		private IHIS.Framework.XEditGrid grdIpgoJUSAOrder;
		private IHIS.Framework.XEditGrid grdMagamOrder;
		private IHIS.Framework.XEditGridCell xEditGridCell57;
		private IHIS.Framework.XEditGridCell xEditGridCell101;
		private IHIS.Framework.XEditGridCell xEditGridCell102;
		private IHIS.Framework.XEditGridCell xEditGridCell103;
		private IHIS.Framework.XEditGridCell xEditGridCell104;
		private IHIS.Framework.XEditGridCell xEditGridCell105;
		private IHIS.Framework.XEditGridCell xEditGridCell106;
		private IHIS.Framework.XEditGridCell xEditGridCell107;
		private IHIS.Framework.XEditGridCell xEditGridCell108;
		private IHIS.Framework.XEditGridCell xEditGridCell109;
		private IHIS.Framework.XEditGridCell xEditGridCell110;
		private IHIS.Framework.XEditGridCell xEditGridCell111;
		private IHIS.Framework.XEditGridCell xEditGridCell112;
		private IHIS.Framework.XEditGridCell xEditGridCell113;
		private IHIS.Framework.XEditGridCell xEditGridCell114;
		private IHIS.Framework.XEditGridCell xEditGridCell115;
		private IHIS.Framework.XEditGridCell xEditGridCell116;
		private IHIS.Framework.XEditGridCell xEditGridCell117;
		private IHIS.Framework.XEditGridCell xEditGridCell118;
		private IHIS.Framework.XEditGridCell xEditGridCell119;
		private IHIS.Framework.XEditGridCell xEditGridCell120;
		private IHIS.Framework.XEditGridCell xEditGridCell121;
		private IHIS.Framework.XEditGridCell xEditGridCell122;
		private IHIS.Framework.XEditGridCell xEditGridCell124;
		private IHIS.Framework.XEditGridCell xEditGridCell125;
		private IHIS.Framework.XEditGridCell xEditGridCell128;
		private IHIS.Framework.XEditGridCell xEditGridCell130;
		private IHIS.Framework.XEditGridCell xEditGridCell257;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
		private IHIS.Framework.XEditGridCell xEditGridCell43;
		private IHIS.Framework.XEditGridCell xEditGridCell44;
		private IHIS.Framework.XEditGridCell xEditGridCell45;
		private IHIS.Framework.XEditGridCell xEditGridCell46;
		private IHIS.Framework.XEditGridCell xEditGridCell47;
		private IHIS.Framework.XEditGridCell xEditGridCell48;
		private IHIS.Framework.XEditGridCell xEditGridCell49;
		private IHIS.Framework.XEditGridCell xEditGridCell50;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
		private IHIS.Framework.XEditGridCell xEditGridCell52;
		private IHIS.Framework.XEditGridCell xEditGridCell53;
		private IHIS.Framework.XEditGridCell xEditGridCell54;
		private IHIS.Framework.XEditGridCell xEditGridCell55;
		private IHIS.Framework.XEditGridCell xEditGridCell56;
		private IHIS.Framework.XEditGridCell xEditGridCell123;
		private IHIS.Framework.XEditGridCell xEditGridCell126;
		private IHIS.Framework.XEditGridCell xEditGridCell127;
		private IHIS.Framework.XEditGridCell xEditGridCell129;
		private IHIS.Framework.XEditGridCell xEditGridCell258;
		private IHIS.Framework.XPanel xPanel3;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XCheckBox chkLable;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
        private SingleLayout layIDLoad;
        private SingleLayoutItem singleLayoutItem1;
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
        private MultiLayoutItem multiLayoutItem53;
        private MultiLayoutItem multiLayoutItem54;
        private MultiLayoutItem multiLayoutItem55;
        private MultiLayoutItem multiLayoutItem56;
        private MultiLayoutItem multiLayoutItem57;
        private MultiLayoutItem multiLayoutItem58;
        private XPanel xPanel1;
        private ImageList imageListMixGroup;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell31;
        private XGridHeader xGridHeader1;
        private XEditGridCell xEditGridCell37;
        private XDictComboBox cbxBuseo;
        private XLabel xLabel7;
        private XLabel xLabel3;
        private XLabel xLabel4;
        private XPanel pnlTop;
        private XLabel xLabel2;
        private XLabel xLabel1;
        private XTextBox tbxBarcode;
        private XTextBox tbxUserID;
        private XLabel lbUserName;
		private System.ComponentModel.IContainer components;

		public DRG3041P02()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG3041P02));
            this.pnlMain = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.pnlMagamGrd = new IHIS.Framework.XPanel();
            this.grdIpgoJUSAOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell110 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell111 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell112 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell113 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell114 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell115 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell116 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell117 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell118 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell119 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell120 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell121 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell122 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell124 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell130 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell257 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.grdMagamOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell123 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell258 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.grdIpgoList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.cbxBuseo = new IHIS.Framework.XDictComboBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.PaBox = new IHIS.Framework.XPatientBox();
            this.dtpChulgoDate = new IHIS.Framework.XDatePicker();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.tbxBarcode = new IHIS.Framework.XTextBox();
            this.tbxUserID = new IHIS.Framework.XTextBox();
            this.lbUserName = new IHIS.Framework.XLabel();
            this.btnCancel = new IHIS.Framework.XButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.chkLable = new IHIS.Framework.XCheckBox();
            this.btnJusaLabel = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layJusaLable = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem57 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem58 = new IHIS.Framework.MultiLayoutItem();
            this.layIDLoad = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.imageListMixGroup = new System.Windows.Forms.ImageList();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.pnlMain.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.pnlMagamGrd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIpgoJUSAOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamOrder)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIpgoList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaBox)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJusaLable)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.xPanel3);
            this.pnlMain.Controls.Add(this.pnlTop);
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.DrawBorder = true;
            this.pnlMain.Name = "pnlMain";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.pnlMagamGrd);
            this.xPanel3.Controls.Add(this.splitter1);
            this.xPanel3.Controls.Add(this.xPanel1);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // pnlMagamGrd
            // 
            this.pnlMagamGrd.Controls.Add(this.grdIpgoJUSAOrder);
            this.pnlMagamGrd.Controls.Add(this.grdMagamOrder);
            resources.ApplyResources(this.pnlMagamGrd, "pnlMagamGrd");
            this.pnlMagamGrd.Name = "pnlMagamGrd";
            // 
            // grdIpgoJUSAOrder
            // 
            this.grdIpgoJUSAOrder.AddedHeaderLine = 1;
            this.grdIpgoJUSAOrder.ApplyPaintEventToAllColumn = true;
            this.grdIpgoJUSAOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell57,
            this.xEditGridCell101,
            this.xEditGridCell102,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell105,
            this.xEditGridCell106,
            this.xEditGridCell107,
            this.xEditGridCell108,
            this.xEditGridCell109,
            this.xEditGridCell110,
            this.xEditGridCell111,
            this.xEditGridCell112,
            this.xEditGridCell113,
            this.xEditGridCell114,
            this.xEditGridCell115,
            this.xEditGridCell116,
            this.xEditGridCell117,
            this.xEditGridCell118,
            this.xEditGridCell119,
            this.xEditGridCell120,
            this.xEditGridCell121,
            this.xEditGridCell122,
            this.xEditGridCell124,
            this.xEditGridCell125,
            this.xEditGridCell128,
            this.xEditGridCell130,
            this.xEditGridCell257,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25});
            this.grdIpgoJUSAOrder.ColPerLine = 15;
            this.grdIpgoJUSAOrder.Cols = 16;
            this.grdIpgoJUSAOrder.ControlBinding = true;
            resources.ApplyResources(this.grdIpgoJUSAOrder, "grdIpgoJUSAOrder");
            this.grdIpgoJUSAOrder.ExecuteQuery = null;
            this.grdIpgoJUSAOrder.FixedCols = 1;
            this.grdIpgoJUSAOrder.FixedRows = 2;
            this.grdIpgoJUSAOrder.HeaderHeights.Add(34);
            this.grdIpgoJUSAOrder.HeaderHeights.Add(0);
            this.grdIpgoJUSAOrder.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdIpgoJUSAOrder.Name = "grdIpgoJUSAOrder";
            this.grdIpgoJUSAOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdIpgoJUSAOrder.ParamList")));
            this.grdIpgoJUSAOrder.QuerySQL = resources.GetString("grdIpgoJUSAOrder.QuerySQL");
            this.grdIpgoJUSAOrder.ReadOnly = true;
            this.grdIpgoJUSAOrder.RowHeaderVisible = true;
            this.grdIpgoJUSAOrder.Rows = 3;
            this.grdIpgoJUSAOrder.TabStop = false;
            this.grdIpgoJUSAOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdIpgoJUSAOrder_QueryStarting);
            this.grdIpgoJUSAOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdIpgoJUSAOrder_QueryEnd);
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "order_date";
            this.xEditGridCell57.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell57.Col = 1;
            this.xEditGridCell57.ExecuteQuery = null;
            this.xEditGridCell57.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsReadOnly = true;
            this.xEditGridCell57.IsUpdCol = false;
            this.xEditGridCell57.RowSpan = 2;
            this.xEditGridCell57.SuppressRepeating = true;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "mix_group";
            this.xEditGridCell101.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell101.CellWidth = 30;
            this.xEditGridCell101.Col = 2;
            this.xEditGridCell101.ExecuteQuery = null;
            this.xEditGridCell101.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsReadOnly = true;
            this.xEditGridCell101.IsUpdCol = false;
            this.xEditGridCell101.RowSpan = 2;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "jaeryo_code";
            this.xEditGridCell102.Col = 3;
            this.xEditGridCell102.ExecuteQuery = null;
            this.xEditGridCell102.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell102, "xEditGridCell102");
            this.xEditGridCell102.IsReadOnly = true;
            this.xEditGridCell102.IsUpdCol = false;
            this.xEditGridCell102.RowSpan = 2;
            this.xEditGridCell102.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "jaeryo_name";
            this.xEditGridCell103.CellWidth = 305;
            this.xEditGridCell103.Col = 4;
            this.xEditGridCell103.ExecuteQuery = null;
            this.xEditGridCell103.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.IsReadOnly = true;
            this.xEditGridCell103.IsUpdCol = false;
            this.xEditGridCell103.RowSpan = 2;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "ord_suryang";
            this.xEditGridCell104.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell104.CellWidth = 40;
            this.xEditGridCell104.Col = 5;
            this.xEditGridCell104.ExecuteQuery = null;
            this.xEditGridCell104.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
            this.xEditGridCell104.IsReadOnly = true;
            this.xEditGridCell104.IsUpdCol = false;
            this.xEditGridCell104.RowSpan = 2;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "dv_time";
            this.xEditGridCell105.CellWidth = 22;
            this.xEditGridCell105.Col = 6;
            this.xEditGridCell105.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell105, "xEditGridCell105");
            this.xEditGridCell105.IsReadOnly = true;
            this.xEditGridCell105.IsUpdCol = false;
            this.xEditGridCell105.Row = 1;
            this.xEditGridCell105.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "dv";
            this.xEditGridCell106.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell106.CellWidth = 22;
            this.xEditGridCell106.Col = 7;
            this.xEditGridCell106.ExecuteQuery = null;
            this.xEditGridCell106.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            this.xEditGridCell106.IsReadOnly = true;
            this.xEditGridCell106.IsUpdCol = false;
            this.xEditGridCell106.Row = 1;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "nalsu";
            this.xEditGridCell107.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell107.CellWidth = 22;
            this.xEditGridCell107.Col = -1;
            this.xEditGridCell107.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell107, "xEditGridCell107");
            this.xEditGridCell107.IsReadOnly = true;
            this.xEditGridCell107.IsUpdCol = false;
            this.xEditGridCell107.IsVisible = false;
            this.xEditGridCell107.Row = -1;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "order_danui";
            this.xEditGridCell108.CellWidth = 50;
            this.xEditGridCell108.Col = -1;
            this.xEditGridCell108.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell108, "xEditGridCell108");
            this.xEditGridCell108.IsReadOnly = true;
            this.xEditGridCell108.IsUpdCol = false;
            this.xEditGridCell108.IsVisible = false;
            this.xEditGridCell108.Row = -1;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "danui_name";
            this.xEditGridCell109.CellWidth = 49;
            this.xEditGridCell109.Col = 8;
            this.xEditGridCell109.ExecuteQuery = null;
            this.xEditGridCell109.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell109, "xEditGridCell109");
            this.xEditGridCell109.IsReadOnly = true;
            this.xEditGridCell109.IsUpdCol = false;
            this.xEditGridCell109.RowSpan = 2;
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "bogyong_code";
            this.xEditGridCell110.CellWidth = 197;
            this.xEditGridCell110.Col = -1;
            this.xEditGridCell110.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell110, "xEditGridCell110");
            this.xEditGridCell110.IsReadOnly = true;
            this.xEditGridCell110.IsUpdCol = false;
            this.xEditGridCell110.IsVisible = false;
            this.xEditGridCell110.Row = -1;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "bogyong_name";
            this.xEditGridCell111.CellWidth = 75;
            this.xEditGridCell111.Col = 9;
            this.xEditGridCell111.ExecuteQuery = null;
            this.xEditGridCell111.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell111, "xEditGridCell111");
            this.xEditGridCell111.IsReadOnly = true;
            this.xEditGridCell111.IsUpdCol = false;
            this.xEditGridCell111.RowSpan = 2;
            this.xEditGridCell111.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "powder_yn";
            this.xEditGridCell112.CellWidth = 25;
            this.xEditGridCell112.Col = 10;
            this.xEditGridCell112.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell112.ExecuteQuery = null;
            this.xEditGridCell112.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell112, "xEditGridCell112");
            this.xEditGridCell112.IsReadOnly = true;
            this.xEditGridCell112.RowSpan = 2;
            this.xEditGridCell112.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellName = "remark";
            this.xEditGridCell113.Col = 15;
            this.xEditGridCell113.DisplayMemoText = true;
            this.xEditGridCell113.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell113.ExecuteQuery = null;
            this.xEditGridCell113.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell113, "xEditGridCell113");
            this.xEditGridCell113.IsReadOnly = true;
            this.xEditGridCell113.RowSpan = 2;
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "dv_1";
            this.xEditGridCell114.Col = -1;
            this.xEditGridCell114.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell114, "xEditGridCell114");
            this.xEditGridCell114.IsReadOnly = true;
            this.xEditGridCell114.IsVisible = false;
            this.xEditGridCell114.Row = -1;
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "dv_2";
            this.xEditGridCell115.Col = -1;
            this.xEditGridCell115.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell115, "xEditGridCell115");
            this.xEditGridCell115.IsReadOnly = true;
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "dv_3";
            this.xEditGridCell116.Col = -1;
            this.xEditGridCell116.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell116, "xEditGridCell116");
            this.xEditGridCell116.IsReadOnly = true;
            this.xEditGridCell116.IsVisible = false;
            this.xEditGridCell116.Row = -1;
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "dv_4";
            this.xEditGridCell117.Col = -1;
            this.xEditGridCell117.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell117, "xEditGridCell117");
            this.xEditGridCell117.IsReadOnly = true;
            this.xEditGridCell117.IsVisible = false;
            this.xEditGridCell117.Row = -1;
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellName = "dv_5";
            this.xEditGridCell118.Col = -1;
            this.xEditGridCell118.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell118, "xEditGridCell118");
            this.xEditGridCell118.IsReadOnly = true;
            this.xEditGridCell118.IsVisible = false;
            this.xEditGridCell118.Row = -1;
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "hubal_change_yn";
            this.xEditGridCell119.CellWidth = 25;
            this.xEditGridCell119.Col = 13;
            this.xEditGridCell119.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell119.ExecuteQuery = null;
            this.xEditGridCell119.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell119, "xEditGridCell119");
            this.xEditGridCell119.IsReadOnly = true;
            this.xEditGridCell119.RowSpan = 2;
            this.xEditGridCell119.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "pharmacy";
            this.xEditGridCell120.CellWidth = 30;
            this.xEditGridCell120.Col = 11;
            this.xEditGridCell120.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell120.ExecuteQuery = null;
            this.xEditGridCell120.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell120, "xEditGridCell120");
            this.xEditGridCell120.IsReadOnly = true;
            this.xEditGridCell120.RowSpan = 2;
            this.xEditGridCell120.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellName = "drg_pack_yn";
            this.xEditGridCell121.CellWidth = 25;
            this.xEditGridCell121.Col = 12;
            this.xEditGridCell121.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell121.ExecuteQuery = null;
            this.xEditGridCell121.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell121, "xEditGridCell121");
            this.xEditGridCell121.IsReadOnly = true;
            this.xEditGridCell121.RowSpan = 2;
            this.xEditGridCell121.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellName = "jusa";
            this.xEditGridCell122.CellWidth = 120;
            this.xEditGridCell122.Col = 14;
            this.xEditGridCell122.ExecuteQuery = null;
            this.xEditGridCell122.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell122, "xEditGridCell122");
            this.xEditGridCell122.IsReadOnly = true;
            this.xEditGridCell122.RowSpan = 2;
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "suname";
            this.xEditGridCell124.Col = -1;
            this.xEditGridCell124.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell124, "xEditGridCell124");
            this.xEditGridCell124.IsVisible = false;
            this.xEditGridCell124.Row = -1;
            this.xEditGridCell124.SuppressRepeating = true;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.CellName = "drg_bunho";
            this.xEditGridCell125.CellWidth = 40;
            this.xEditGridCell125.Col = -1;
            this.xEditGridCell125.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell125, "xEditGridCell125");
            this.xEditGridCell125.IsVisible = false;
            this.xEditGridCell125.Row = -1;
            this.xEditGridCell125.SuppressRepeating = true;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "jubsu_date";
            this.xEditGridCell128.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell128, "xEditGridCell128");
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.CellName = "bunho";
            this.xEditGridCell130.CellWidth = 75;
            this.xEditGridCell130.Col = -1;
            this.xEditGridCell130.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell130, "xEditGridCell130");
            this.xEditGridCell130.IsVisible = false;
            this.xEditGridCell130.Row = -1;
            this.xEditGridCell130.SuppressRepeating = true;
            // 
            // xEditGridCell257
            // 
            this.xEditGridCell257.CellName = "ho_dong";
            this.xEditGridCell257.CellWidth = 29;
            this.xEditGridCell257.Col = -1;
            this.xEditGridCell257.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell257, "xEditGridCell257");
            this.xEditGridCell257.IsVisible = false;
            this.xEditGridCell257.Row = -1;
            this.xEditGridCell257.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "dc_yn";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "fkocs2003";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "fkinp1001";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "group_ser";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 6;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 22;
            // 
            // grdMagamOrder
            // 
            this.grdMagamOrder.ApplyPaintEventToAllColumn = true;
            this.grdMagamOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell27,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell123,
            this.xEditGridCell126,
            this.xEditGridCell127,
            this.xEditGridCell129,
            this.xEditGridCell258});
            this.grdMagamOrder.ColPerLine = 13;
            this.grdMagamOrder.ColResizable = true;
            this.grdMagamOrder.Cols = 14;
            this.grdMagamOrder.ControlBinding = true;
            resources.ApplyResources(this.grdMagamOrder, "grdMagamOrder");
            this.grdMagamOrder.ExecuteQuery = null;
            this.grdMagamOrder.FixedCols = 1;
            this.grdMagamOrder.FixedRows = 1;
            this.grdMagamOrder.HeaderHeights.Add(37);
            this.grdMagamOrder.Name = "grdMagamOrder";
            this.grdMagamOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMagamOrder.ParamList")));
            this.grdMagamOrder.QuerySQL = resources.GetString("grdMagamOrder.QuerySQL");
            this.grdMagamOrder.ReadOnly = true;
            this.grdMagamOrder.RowHeaderVisible = true;
            this.grdMagamOrder.Rows = 2;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "order_date";
            this.xEditGridCell27.CellWidth = 77;
            this.xEditGridCell27.Col = 1;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.SuppressRepeating = true;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "group_ser";
            this.xEditGridCell32.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell32.CellWidth = 20;
            this.xEditGridCell32.Col = 2;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdCol = false;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "jaeryo_code";
            this.xEditGridCell33.CellWidth = 77;
            this.xEditGridCell33.Col = 3;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "jaeryo_name";
            this.xEditGridCell34.CellWidth = 203;
            this.xEditGridCell34.Col = 4;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsUpdCol = false;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "ord_suryang";
            this.xEditGridCell35.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell35.CellWidth = 40;
            this.xEditGridCell35.Col = 5;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.IsUpdCol = false;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "dv_time";
            this.xEditGridCell36.CellWidth = 22;
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsUpdCol = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "dv";
            this.xEditGridCell40.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell40.CellWidth = 22;
            this.xEditGridCell40.Col = 6;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsUpdCol = false;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "nalsu";
            this.xEditGridCell41.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell41.CellWidth = 22;
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsUpdCol = false;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "order_danui";
            this.xEditGridCell42.CellWidth = 50;
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsReadOnly = true;
            this.xEditGridCell42.IsUpdCol = false;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "danui_name";
            this.xEditGridCell43.CellWidth = 49;
            this.xEditGridCell43.Col = 7;
            this.xEditGridCell43.ExecuteQuery = null;
            this.xEditGridCell43.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsReadOnly = true;
            this.xEditGridCell43.IsUpdCol = false;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "bogyong_code";
            this.xEditGridCell44.CellWidth = 197;
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsReadOnly = true;
            this.xEditGridCell44.IsUpdCol = false;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "bogyong_name";
            this.xEditGridCell45.CellWidth = 127;
            this.xEditGridCell45.Col = 8;
            this.xEditGridCell45.ExecuteQuery = null;
            this.xEditGridCell45.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsReadOnly = true;
            this.xEditGridCell45.IsUpdCol = false;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "powder_yn";
            this.xEditGridCell46.CellWidth = 25;
            this.xEditGridCell46.Col = 9;
            this.xEditGridCell46.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell46.ExecuteQuery = null;
            this.xEditGridCell46.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsReadOnly = true;
            this.xEditGridCell46.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "remark";
            this.xEditGridCell47.CellWidth = 284;
            this.xEditGridCell47.Col = 13;
            this.xEditGridCell47.DisplayMemoText = true;
            this.xEditGridCell47.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsReadOnly = true;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "dv_1";
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsReadOnly = true;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "dv_2";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsReadOnly = true;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "dv_3";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsReadOnly = true;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "dv_4";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsReadOnly = true;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "dv_5";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsReadOnly = true;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "hubal_change_yn";
            this.xEditGridCell53.CellWidth = 25;
            this.xEditGridCell53.Col = 12;
            this.xEditGridCell53.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsReadOnly = true;
            this.xEditGridCell53.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "pharmacy";
            this.xEditGridCell54.CellWidth = 30;
            this.xEditGridCell54.Col = 10;
            this.xEditGridCell54.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell54.ExecuteQuery = null;
            this.xEditGridCell54.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsReadOnly = true;
            this.xEditGridCell54.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "drg_pack_yn";
            this.xEditGridCell55.CellWidth = 25;
            this.xEditGridCell55.Col = 11;
            this.xEditGridCell55.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell55.ExecuteQuery = null;
            this.xEditGridCell55.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsReadOnly = true;
            this.xEditGridCell55.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "jusa";
            this.xEditGridCell56.CellWidth = 43;
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsReadOnly = true;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            this.xEditGridCell56.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellName = "suname";
            this.xEditGridCell123.Col = -1;
            this.xEditGridCell123.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell123, "xEditGridCell123");
            this.xEditGridCell123.IsVisible = false;
            this.xEditGridCell123.Row = -1;
            this.xEditGridCell123.SuppressRepeating = true;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "drg_bunho";
            this.xEditGridCell126.CellWidth = 40;
            this.xEditGridCell126.Col = -1;
            this.xEditGridCell126.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell126, "xEditGridCell126");
            this.xEditGridCell126.IsVisible = false;
            this.xEditGridCell126.Row = -1;
            this.xEditGridCell126.SuppressRepeating = true;
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "jubsu_date";
            this.xEditGridCell127.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell127.Col = -1;
            this.xEditGridCell127.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell127, "xEditGridCell127");
            this.xEditGridCell127.IsVisible = false;
            this.xEditGridCell127.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "bunho";
            this.xEditGridCell129.Col = -1;
            this.xEditGridCell129.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell129, "xEditGridCell129");
            this.xEditGridCell129.IsVisible = false;
            this.xEditGridCell129.Row = -1;
            this.xEditGridCell129.SuppressRepeating = true;
            // 
            // xEditGridCell258
            // 
            this.xEditGridCell258.CellName = "ho_dong";
            this.xEditGridCell258.CellWidth = 30;
            this.xEditGridCell258.Col = -1;
            this.xEditGridCell258.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell258, "xEditGridCell258");
            this.xEditGridCell258.IsVisible = false;
            this.xEditGridCell258.Row = -1;
            this.xEditGridCell258.SuppressRepeating = true;
            this.xEditGridCell258.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdIpgoList);
            this.xPanel1.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // grdIpgoList
            // 
            this.grdIpgoList.ApplyPaintEventToAllColumn = true;
            this.grdIpgoList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell37,
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
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell31});
            this.grdIpgoList.ColPerLine = 16;
            this.grdIpgoList.Cols = 17;
            resources.ApplyResources(this.grdIpgoList, "grdIpgoList");
            this.grdIpgoList.ExecuteQuery = null;
            this.grdIpgoList.FixedCols = 1;
            this.grdIpgoList.FixedRows = 1;
            this.grdIpgoList.HeaderHeights.Add(21);
            this.grdIpgoList.Name = "grdIpgoList";
            this.grdIpgoList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdIpgoList.ParamList")));
            this.grdIpgoList.QuerySQL = resources.GetString("grdIpgoList.QuerySQL");
            this.grdIpgoList.ReadOnly = true;
            this.grdIpgoList.RowHeaderVisible = true;
            this.grdIpgoList.Rows = 2;
            this.grdIpgoList.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdIpgoList.TabStop = false;
            this.grdIpgoList.ToolTipActive = true;
            this.grdIpgoList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdIpgoList_RowFocusChanged);
            this.grdIpgoList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdIpgoList_GridCellPainting);
            this.grdIpgoList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdIpgoList_QueryStarting);
            this.grdIpgoList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdIpgoList_QueryEnd);
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell37.CellName = "bunho";
            this.xEditGridCell37.CellWidth = 70;
            this.xEditGridCell37.Col = 5;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell1.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell1.CellName = "jubsu_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.Col = 7;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.SuppressRepeating = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell2.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell2.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell2.CellName = "drg_bunho";
            this.xEditGridCell2.CellWidth = 38;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell2.SuppressRepeating = true;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell3.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell3.CellName = "serial_v";
            this.xEditGridCell3.CellWidth = 25;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell4.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell4.CellName = "chulgo_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.Col = 8;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell5.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell5.CellName = "chulgo_time";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell5.CellWidth = 40;
            this.xEditGridCell5.Col = 9;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.Mask = "HH:MI";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "chulgo_id";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell7.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell7.CellName = "ipgo_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.Col = 11;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell8.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell8.CellName = "ipgo_time";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell8.CellWidth = 40;
            this.xEditGridCell8.Col = 12;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.Mask = "HH:MI";
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "ipgo_id";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell10.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell10.CellName = "acting_date";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell10.Col = 14;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell11.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell11.CellName = "acting_time";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell11.CellWidth = 40;
            this.xEditGridCell11.Col = 15;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.Mask = "HH:MI";
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "acting_id";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell13.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell13.CellName = "ho_dong";
            this.xEditGridCell13.CellWidth = 35;
            this.xEditGridCell13.Col = 3;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.SuppressRepeating = true;
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell14.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell14.CellName = "ho_code";
            this.xEditGridCell14.CellWidth = 40;
            this.xEditGridCell14.Col = 4;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.SuppressRepeating = true;
            this.xEditGridCell14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell15.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell15.CellName = "chulgo_id_name";
            this.xEditGridCell15.CellWidth = 90;
            this.xEditGridCell15.Col = 10;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell16.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell16.CellName = "ipgo_id_name";
            this.xEditGridCell16.CellWidth = 90;
            this.xEditGridCell16.Col = 13;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell17.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell17.CellName = "acging_id_name";
            this.xEditGridCell17.CellWidth = 90;
            this.xEditGridCell17.Col = 16;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell18.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell18.CellName = "suname";
            this.xEditGridCell18.CellWidth = 90;
            this.xEditGridCell18.Col = 6;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.SuppressRepeating = true;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "chulgo_all_yn";
            this.xEditGridCell19.CellWidth = 30;
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "magam_gubun";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell21.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell21.CellName = "order_date";
            this.xEditGridCell21.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            this.xEditGridCell21.SuppressRepeating = true;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "seq";
            this.xEditGridCell31.CellWidth = 24;
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            this.xEditGridCell31.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xLabel3);
            this.groupBox1.Controls.Add(this.xLabel4);
            this.groupBox1.Controls.Add(this.cbxBuseo);
            this.groupBox1.Controls.Add(this.xLabel7);
            this.groupBox1.Controls.Add(this.PaBox);
            this.groupBox1.Controls.Add(this.dtpChulgoDate);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.Gray;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // cbxBuseo
            // 
            this.cbxBuseo.ExecuteQuery = null;
            resources.ApplyResources(this.cbxBuseo, "cbxBuseo");
            this.cbxBuseo.Name = "cbxBuseo";
            this.cbxBuseo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxBuseo.ParamList")));
            this.cbxBuseo.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxBuseo.UserSQL = resources.GetString("cbxBuseo.UserSQL");
            this.cbxBuseo.SelectionChangeCommitted += new System.EventHandler(this.cbxBuseo_SelectionChangeCommitted);
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Name = "xLabel7";
            // 
            // PaBox
            // 
            resources.ApplyResources(this.PaBox, "PaBox");
            this.PaBox.Name = "PaBox";
            this.PaBox.PatientSelected += new System.EventHandler(this.PaBox_PatientSelected);
            // 
            // dtpChulgoDate
            // 
            this.dtpChulgoDate.IsVietnameseYearType = false;
            resources.ApplyResources(this.dtpChulgoDate, "dtpChulgoDate");
            this.dtpChulgoDate.Name = "dtpChulgoDate";
            this.dtpChulgoDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpChulgoDate_DataValidating);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.xLabel2);
            this.pnlTop.Controls.Add(this.xLabel1);
            this.pnlTop.Controls.Add(this.tbxBarcode);
            this.pnlTop.Controls.Add(this.tbxUserID);
            this.pnlTop.Controls.Add(this.lbUserName);
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Blue);
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Blue);
            this.xLabel1.Name = "xLabel1";
            // 
            // tbxBarcode
            // 
            this.tbxBarcode.EnterKeyToTab = false;
            resources.ApplyResources(this.tbxBarcode, "tbxBarcode");
            this.tbxBarcode.Name = "tbxBarcode";
            this.tbxBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxBarcode_KeyPress);
            // 
            // tbxUserID
            // 
            this.tbxUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxUserID.EnterKeyToTab = false;
            resources.ApplyResources(this.tbxUserID, "tbxUserID");
            this.tbxUserID.Name = "tbxUserID";
            this.tbxUserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxUserID_KeyPress);
            // 
            // lbUserName
            // 
            this.lbUserName.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.lbUserName, "lbUserName");
            this.lbUserName.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.lbUserName.Name = "lbUserName";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.chkLable);
            this.xPanel2.Controls.Add(this.btnJusaLabel);
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.Controls.Add(this.btnCancel);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // chkLable
            // 
            resources.ApplyResources(this.chkLable, "chkLable");
            this.chkLable.Name = "chkLable";
            this.chkLable.UseVisualStyleBackColor = false;
            // 
            // btnJusaLabel
            // 
            this.btnJusaLabel.Image = ((System.Drawing.Image)(resources.GetObject("btnJusaLabel.Image")));
            resources.ApplyResources(this.btnJusaLabel, "btnJusaLabel");
            this.btnJusaLabel.Name = "btnJusaLabel";
            this.btnJusaLabel.Click += new System.EventHandler(this.btnJusaLabel_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // layJusaLable
            // 
            this.layJusaLable.ExecuteQuery = null;
            this.layJusaLable.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem52,
            this.multiLayoutItem53,
            this.multiLayoutItem54,
            this.multiLayoutItem55,
            this.multiLayoutItem56,
            this.multiLayoutItem57,
            this.multiLayoutItem58});
            this.layJusaLable.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layJusaLable.ParamList")));
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "bunho";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "suname";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "suname2";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "birth";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "age";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "drg_bunho";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "ho_dong";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "ho_code";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "magam_gubun";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "gwa_name";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "doctor_name";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "jubsu_date";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "serial_v";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "resident_name";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "jusa";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "jaeryo_name";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "bogyong_name";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "ord_suryang";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "order_danui";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "dv";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "subul_suryang";
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "subul_danui";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "order_remark";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "rp_barcode";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "order_date";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "order_suryang";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "rp2";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "data_gubun";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "line";
            // 
            // layIDLoad
            // 
            this.layIDLoad.ExecuteQuery = null;
            this.layIDLoad.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layIDLoad.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layIDLoad.ParamList")));
            this.layIDLoad.QuerySQL = "SELECT FN_ADM_LOAD_USER_NAME(:f_user_id) FROM DUAL\r\n";
            this.layIDLoad.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layIDLoad_QueryStarting);
            this.layIDLoad.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layIDLoad_QueryEnd);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "user_name";
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMixGroup.Images.SetKeyName(0, "20.gif");
            this.imageListMixGroup.Images.SetKeyName(1, "1.gif");
            this.imageListMixGroup.Images.SetKeyName(2, "2.gif");
            this.imageListMixGroup.Images.SetKeyName(3, "3.gif");
            this.imageListMixGroup.Images.SetKeyName(4, "4.gif");
            this.imageListMixGroup.Images.SetKeyName(5, "5.gif");
            this.imageListMixGroup.Images.SetKeyName(6, "6.gif");
            this.imageListMixGroup.Images.SetKeyName(7, "7.gif");
            this.imageListMixGroup.Images.SetKeyName(8, "8.gif");
            this.imageListMixGroup.Images.SetKeyName(9, "9.gif");
            this.imageListMixGroup.Images.SetKeyName(10, "10.gif");
            this.imageListMixGroup.Images.SetKeyName(11, "11.gif");
            this.imageListMixGroup.Images.SetKeyName(12, "12.gif");
            this.imageListMixGroup.Images.SetKeyName(13, "13.gif");
            this.imageListMixGroup.Images.SetKeyName(14, "14.gif");
            this.imageListMixGroup.Images.SetKeyName(15, "15.gif");
            this.imageListMixGroup.Images.SetKeyName(16, "16.gif");
            this.imageListMixGroup.Images.SetKeyName(17, "17.gif");
            this.imageListMixGroup.Images.SetKeyName(18, "18.gif");
            this.imageListMixGroup.Images.SetKeyName(19, "19.gif");
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "dc_yn";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "fkocs2003";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "fkinp1001";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "group_ser";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // DRG3041P02
            // 
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.xPanel2);
            this.Name = "DRG3041P02";
            resources.ApplyResources(this, "$this");
            this.pnlMain.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.pnlMagamGrd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdIpgoJUSAOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamOrder)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdIpgoList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaBox)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJusaLable)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
        private string mHospCode = "";
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

            this.mHospCode = EnvironInfo.HospCode;

            //Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            //this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 105);

            //if (UserInfo.HoDong != "")
            //    cbxBuseo.SetEditValue(UserInfo.HoDong);
            //else
            //    cbxBuseo.SetEditValue("1");

            this.cbxBuseo.SelectedIndex = 0;

			this.dtpChulgoDate.SetDataValue(EnvironInfo.GetSysDate());

            this.grdIpgoList.QueryLayout(false);
		}
		#endregion

        #region [tbxUserID_KeyPress]
        private void tbxUserID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (tbxUserID.GetDataValue() == "")
                {
                    lbUserName.Text = "ユーザーＩＤを入力してください。";
                    tbxUserID.Focus();
                }
                else
                {
                    this.layIDLoad.QueryLayout();
                    string user_name = layIDLoad.GetItemValue("user_name").ToString();

                    if (user_name != "")
                    {
                        lbUserName.Text = user_name;
                        tbxBarcode.Focus();
                    }
                    else
                    {
                        lbUserName.Text = "ユーザーＩＤを確認してください。";
                        tbxUserID.Focus();
                        tbxUserID.SelectAll();
                    }
                }
            }
        }
        #endregion

        #region [tbxBarcode_KeyPress]
        private void tbxBarcode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                #region ユーザーＩＤ
                if (lbUserName.Text == "")
                {
                    tbxBarcode.SetDataValue("");
                    tbxBarcode.AcceptData();

                    tbxUserID.Focus();
                    XMessageBox.Show("ユーザーＩＤを入力してください。", "確認", MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                #region エラーメッセージ
                //if (btnErrConform.Visible)
                //{
                //    tbxBarcode.SetDataValue("");
                //    tbxBarcode.AcceptData();

                //    tbxBarcode.Focus();
                //    MessageBox.Show("エラーメッセージを確認してください","確認");
                //    return;
                //}
                #endregion

                this.MakeBarcode(tbxBarcode.GetDataValue(), "I");
            }
        }
        #endregion

        #region [layIDLoad ユーザID、ユーザ名チェック]
        private void layIDLoad_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layIDLoad.SetBindVarValue("f_user_id", this.tbxUserID.GetDataValue());
        }

        private void layIDLoad_QueryEnd(object sender, QueryEndEventArgs e)
        {
            lbUserName.Text = "";
            lbUserName.Text = layIDLoad.GetItemValue("user_name").ToString();
        }
        #endregion

        #region [btnCancel_Click 入庫取消ボタン]
        private void btnCancel_Click(object sender, System.EventArgs e)
		{
            if (this.grdIpgoList.GetItemString(this.grdIpgoList.CurrentRowNumber, "ipgo_date") == "") return;

			string barcode = grdIpgoList.GetItemString(grdIpgoList.CurrentRowNumber, "jubsu_date").Replace("/","");
			barcode += grdIpgoList.GetItemString(grdIpgoList.CurrentRowNumber, "drg_bunho");
            barcode += grdIpgoList.GetItemString(grdIpgoList.CurrentRowNumber, "serial_v");
            barcode += grdIpgoList.GetItemString(grdIpgoList.CurrentRowNumber, "seq");

            MakeBarcode(barcode, "D");

            this.grdIpgoList.QueryLayout(false);
        }
        #endregion

        #region [cbxHoDong_SelectedValueChanged 病棟選択]
        private void cbxHoDong_SelectedValueChanged(object sender, System.EventArgs e)
        {
            this.grdIpgoList.QueryLayout(false);
        }
        #endregion

        #region SetPrint
        private string SetPrint(XDataWindow dw_print, bool lable_yn)
		{
			string print_name = "";

			if (lable_yn)
            {
                foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    if (s == "SATO")
                    {
                        print_name = "SATO";
                        break;
                    }
                    else
                    {
                        if (s.IndexOf("SATO") >= 0)
                            print_name = s;
                    }
                }

                if (print_name.IndexOf("SATO") < 0)
                {
                    //MessageBox.Show("ラベルプリンタの設定がされていません。");
                    //dw_print.PrintDialog(true);
                    print_name = "";
                }
                { 
                    
                }
            }
			else
			{
				print_name = dw_print.PrintProperties.PrinterName;		
		        
			}

			return print_name;
		}
		#endregion

        #region [grdIpgoList_RowFocusChanged]
        private void grdIpgoList_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            //string magam_gubun = "", magam_bunryu = "";
            //magam_gubun = grdChulgoList.GetItemString(grdChulgoList.CurrentRowNumber, "magam_gubun");

            ////내복, 외용
            //if ((magam_gubun == "11") || (magam_gubun == "21"))
            //{
            //    CurrMQLayout = grdMagamOrder;
            //    magam_bunryu = "1";
            //    grdMagamOrder.Visible = true;
            //    grdMagamJUSAOrder.Visible = false;

            //    //grdMagamOrder.SetBindVarValue("f_magam_bunryu", magam_bunryu);
            //    grdMagamOrder.QueryLayout(false);
            //}

            ////주사
            //if ((magam_gubun == "12") || (magam_gubun == "22"))
            //{
            //    CurrMQLayout = grdMagamJUSAOrder;
            //    magam_bunryu = "2";
            //    grdMagamOrder.Visible = false;
            //    grdMagamJUSAOrder.Visible = true;

            //    //grdMagamJUSAOrder.SetBindVarValue("f_magam_bunryu", magam_bunryu);
            //    grdMagamJUSAOrder.QueryLayout(false);
            //}
            //CurrMQLayout = grdIpgoJUSAOrder;
            //magam_bunryu = "2";
            //grdMagamOrder.Visible = false;
            //grdIpgoJUSAOrder.Visible = true;

            //grdMagamJUSAOrder.SetBindVarValue("f_magam_bunryu", magam_bunryu);
            this.grdIpgoJUSAOrder.QueryLayout(false);
        }
        #endregion

        #region [grdIpgoList_GridCellPainting]
        private void grdIpgoList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            this.SetGrdBackColor(sender, e);
        }
        #endregion

        #region [SetGrdBackColor]
        private void SetGrdBackColor(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            if (grid.Name == "grdIpgoList")
            {
                if (grid.GetItemString(e.RowNumber, "ipgo_date") == "")
                {
                    e.BackColor = Color.Pink;
                }
                else e.BackColor = Color.SkyBlue;
            }
        }
        #endregion

        #region [btnList_ButtonClick ボタンリストクリック]
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.grdIpgoList.QueryLayout(false);
					break;
				default:
					break;
			}
        }
        #endregion  

        #region [grdIpgoList_QueryStarting]
        private void grdIpgoList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdIpgoJUSAOrder.Reset();
            this.grdMagamOrder.Reset();

            this.grdIpgoList.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdIpgoList.SetBindVarValue("f_ho_dong", this.cbxBuseo.GetDataValue());
            this.grdIpgoList.SetBindVarValue("f_chulgo_date", this.dtpChulgoDate.GetDataValue());
            this.grdIpgoList.SetBindVarValue("f_bunho", this.PaBox.BunHo);
            //this.grdIpgoList.SetBindVarValue("f_chulgo_all_yn", this.chkAllQry.GetDataValue());
            //this.grdIpgoList.SetBindVarValue("f_inpgo_gubun", "%"); //원본 소스에 아무것도 안넣줘서 %으로 셋팅. Y로 셋팅하면 조회안됨??
        }
        #endregion

        #region [grdIpgoList_QueryEnd]
        private void grdIpgoList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            tbxBarcode.SetDataValue("");
            tbxBarcode.Focus();
        }
        #endregion

        #region [grdIpgoJUSAOrder_QueryStarting]
        private void grdIpgoJUSAOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            
            grd.SetBindVarValue("f_hosp_code", this.mHospCode);
            if(this.grdIpgoList.GetItemDateTime(this.grdIpgoList.CurrentRowNumber, "jubsu_date") != null)
                grd.SetBindVarValue("f_jubsu_date", this.grdIpgoList.GetItemDateTime(this.grdIpgoList.CurrentRowNumber, "jubsu_date").ToString("yyyy/MM/dd"));
            grd.SetBindVarValue("f_drg_bunho", this.grdIpgoList.GetItemString(this.grdIpgoList.CurrentRowNumber, "drg_bunho"));
            grd.SetBindVarValue("f_serial_v", this.grdIpgoList.GetItemString(this.grdIpgoList.CurrentRowNumber, "serial_v"));
        }
        #endregion

        #region [grdIpgoJUSAOrder_QueryEnd]
        private void grdIpgoJUSAOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            if (grd.RowCount > 0)
            {
                this.DisplayMixGroup(grd);
            }
        }
        #endregion

        #region [dtpChulgoDate_DataValidating 出庫日付選択]
        private void dtpChulgoDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.grdIpgoList.QueryLayout(false);
        }
        #endregion

        #region [PaBox_PatientSelected 患者番号入力]
        private void PaBox_PatientSelected(object sender, EventArgs e)
        {
            this.grdIpgoList.QueryLayout(false);
        }
        #endregion

        #region Mix Group 데이타 Image Display (DiaplayMixGroup)
        /// <summary>
        /// Mix Group 데이타 Image Display
        /// </summary>
        /// <param name="aGrd"> XEditGrid </param>
        /// <returns> void  </returns>
        private void DisplayMixGroup(XEditGrid aGrd)
        {
            if (aGrd == null) return;

            try
            {
                //aGrd.Redraw = false; // Grid Display 멈춤

                int imageCnt = 0;

                // 기존 image 클리어
                for (int i = 0; i < aGrd.RowCount; i++) aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;

                for (int i = 0; i < aGrd.RowCount; i++)
                {
                    // 이미 이미지 세팅이 안된건에 한해서 작업수행
                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
                    {
                        //이미수행한건 빼는로직이 있어야함..
                        int count = 0;
                        for (int j = i; j < aGrd.RowCount; j++)
                        {
                            if (aGrd.GetItemString(i, "dc_yn") == "Y") continue;

                            // 동일 group_ser, 동일 mix_group, 동일 희망일자, 동일 OrderGubun가 Mix구별임..
                            if (aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
                                aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim() &&
                                aGrd.GetItemValue(i, "order_date").ToString().Trim() == aGrd.GetItemValue(j, "order_date").ToString().Trim() //&&
                                //aGrd.GetItemValue(i, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1) ==
                                //aGrd.GetItemValue(j, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1)
                                )
                            {
                                count++;
                                if (count > 1)
                                {
                                    //      헤더를 빼야 실제 Row
                                    aGrd[j + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
                                    aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
                                }
                            }
                        }
                        // 현재는 image 갯수만큼 처리
                        if (count > 1) imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
                    }
                }
            }
            finally
            {
                //aGrd.Redraw = true; // Grid Display 
            }

        }
        #endregion

        #region [cbxBuseo_SelectionChangeCommitted 病棟選択]
        private void cbxBuseo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region [btnJusaLabel_Click 注射ラベル印刷]
        private void btnJusaLabel_Click(object sender, EventArgs e)
        {
            if (this.grdIpgoList.RowCount < 1) return;

            this.JusaLablePrint(this.grdIpgoList.GetItemString(this.grdIpgoList.CurrentRowNumber, "jubsu_date")
                              , this.grdIpgoList.GetItemString(this.grdIpgoList.CurrentRowNumber, "drg_bunho")
                              , this.grdIpgoList.GetItemString(this.grdIpgoList.CurrentRowNumber, "serial_v")
                              , this.grdIpgoList.GetItemString(this.grdIpgoList.CurrentRowNumber, "seq"));
        }
        #endregion

        #region [MakeBarcode]
        private void MakeBarcode(string aBarcode, string aIUDGubun)
        {
            //BEGIN       
            //    PR_DRG_MAKE_BARCODE(:i_barcode_bunho
            //                       ,:i_iud_gubun
            //                       ,:i_user_id
            //                       ,TRUNC(SYSDATE)
            //                       ,'NRI'
            //                       ,''
            //                       ,:o_bunho
            //                       ,:o_suname
            //                       ,:o_suname2
            //                       ,:o_jubsu_date
            //                       ,:o_drg_bunho
            //                       ,:o_jusa_yn
            //                       ,:o_return_code
            //                       );	
            //END;

            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

            inputList.Add("I_BARCODE_NO", aBarcode);
            inputList.Add("I_IUD_GUBUN", aIUDGubun);
            inputList.Add("I_USER_ID", this.tbxUserID.GetDataValue());
            inputList.Add("I_DATE", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            inputList.Add("I_USER_GUBUN", "NRI");
            inputList.Add("I_BUNHO", "");

            if (!Service.ExecuteProcedure("PR_DRG_MAKE_BARCODE", inputList, outputList))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }

            string err_code = outputList["IO_RETURN"].ToString();

            if (err_code == "1")
            {
                XMessageBox.Show("バーコード内容を確認して下さい。", "確認", MessageBoxIcon.Warning);
                return;
            }
            else if (err_code == "2")
            {
                XMessageBox.Show("締切されてないオーダです。", "確認", MessageBoxIcon.Warning);
                return;
            }
            else if (err_code == "3")
            {
                XMessageBox.Show("返却オーダーが含まれています。", "確認", MessageBoxIcon.Warning);
                return;
            }
            else if (err_code == "4")
            {
                XMessageBox.Show("既に処理された処方箋です。", "確認", MessageBoxIcon.Warning);
                return;
            }
            else if (err_code == "5")
            {
                XMessageBox.Show("薬局から出庫されてない処方箋です。", "確認", MessageBoxIcon.Warning);
                return;
            }
            else if (err_code == "6")
            {
                XMessageBox.Show("患者情報を確認して下さい。", "確認", MessageBoxIcon.Warning);
                return;
            }
            else if (err_code == "9")
            {
                XMessageBox.Show("既に病棟入庫処理されました｡ 取消出来ません｡", "確認", MessageBoxIcon.Warning);
                return;
            }
            else if (err_code == "10")
            {
                XMessageBox.Show("既に実施処理されました｡ 取消出来ません。", "確認", MessageBoxIcon.Warning);
                return;
            }
            else if (err_code == "11")
            {
                XMessageBox.Show("病棟入庫処理されていません｡", "確認", MessageBoxIcon.Warning);
                return;
            }
            else if (err_code == "12")
            {
                XMessageBox.Show("MIXオーダではありません｡", "確認", MessageBoxIcon.Warning);
                return;
            }
            else if (err_code == "13")
            {
                XMessageBox.Show("既にMIX処理されました｡ 取消出来ません。", "確認", MessageBoxIcon.Warning);
                return;
            }
            else if (err_code == "14")
            {
                XMessageBox.Show("MIX処理がされていません｡", "確認", MessageBoxIcon.Warning);
                return;
            }
            else if (err_code == "15")
            {
                XMessageBox.Show("返却オーダのため入庫できません。", "確認", MessageBoxIcon.Warning);
                return;
            }
            else if (err_code == "Z")
            {
                XMessageBox.Show("Z", "Error", MessageBoxIcon.Warning);
                return;
            }
            else
            {
                //주사라벨 출력
                if (chkLable.Checked)
                {
                    if (outputList["IO_JUSA_YN"].ToString() == "Y")
                    {
                        //string jubsu_date = Convert.ToDateTime(outputList["IO_JUBSU_DATE"]).ToString("yyyy/MM/dd");
                        //string drug_bunho = outputList["IO_DRG_BUNHO"].ToString();

                        string jubsu_date = this.tbxBarcode.Text.Substring(0, 8);
                        string drug_bunho = this.tbxBarcode.Text.Substring(8, 4);
                        string rp = this.tbxBarcode.Text.Substring(12, 1);
                        string seq = this.tbxBarcode.Text.Substring(13, 1);
                        JusaLablePrint(jubsu_date, drug_bunho, rp, seq);
                    }
                }
                this.grdIpgoList.QueryLayout(true);
            }
            tbxBarcode.Focus();
            tbxBarcode.SelectAll();
        }
        #endregion

        #region [JusaLablePrint]
        private void JusaLablePrint(string ar_JubsuDate, string ar_DrgBunho, string ar_Rp, string ar_Seq)
        {
            #region 주사라벨

  //          string origin_print = SetPrint(dw_lable, false);
  //          string print_name = SetPrint(dw_lable, true);

            // lable print set
       //     try
       //     {
       //         if (print_name != "")
       //             IHIS.Framework.PrintHelper.SetDefaultPrinter(print_name);

       //         // 오다 내역 조회
       ////         dw_lable.Reset();
       //         this.DsvJusaLabel(ar_JubsuDate, ar_DrgBunho, ar_Rp, ar_Seq);

       //         // 기본프린터 set
       //         if (origin_print != "")
       //         {
       //             if (origin_print != IHIS.Framework.PrintHelper.GetDefaultPrinterName())
       //                 IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print);
       //         }
       //     }
       //     catch
       //     { }
            #endregion
        }
        #endregion

        #region [-- DsvJusaLabel --]
        /// <summary>
        /// dsvJusaLabel Service Conversion PC: DRGPRINT, WT:0
        /// </summary>
        /// <param name="jubsuDate"></param>
        /// <param name="drgBunho"></param>
        /// <returns></returns>
        private bool DsvJusaLabel(string jubsuDate, string drgBunho, string rp, string seq)
        {
            string o_fkocs2003 = string.Empty;
            string o_bunho = string.Empty;
            string o_fkinp1001 = string.Empty;
            string o_group_ser = string.Empty;
            string o_jubsu_date = string.Empty;
            string o_order_date = string.Empty;
            string o_drg_bunho = string.Empty;
            string o_ho_code = string.Empty;
            string o_ho_dong = string.Empty;
            string o_doctor = string.Empty;
            string o_resident = string.Empty;
            string o_gwa = string.Empty;
            string o_jaeryo_code = string.Empty;
            string o_jaeryo_gubun = string.Empty;
            string o_nalsu = string.Empty;
            string o_divide = string.Empty;
            string o_order_suryang = string.Empty;
            string o_subul_suryang = string.Empty;
            string o_ord_suryang = string.Empty;
            string o_order_danui = string.Empty;
            string o_subul_danui = string.Empty;
            string o_group_yn = string.Empty;
            string o_bunryu1 = string.Empty;
            string o_bunryu2 = string.Empty;
            string o_bunryu3 = string.Empty;
            string o_bunryu4 = string.Empty;
            string o_bogyong_code = string.Empty;
            string o_caution_code = string.Empty;
            string o_mix_yn = string.Empty;
            string o_atc_yn = string.Empty;
            string o_chulgo_buseo = string.Empty;
            string o_chulgo_date = string.Empty;
            string o_chulgo_qty = string.Empty;
            string o_chulgo_yn = string.Empty;
            string o_change_qty = string.Empty;
            string o_toiwon_drg_yn = string.Empty;
            string o_emergency = string.Empty;
            string o_drg_prn_yn = string.Empty;
            string o_drg_prn_time = string.Empty;
            string o_append_yn = string.Empty;
            string o_anti_cancer_yn = string.Empty;
            string o_tpn_yn = string.Empty;
            string o_self_gubun = string.Empty;
            string o_magam_gubun = string.Empty;
            string o_magam_ser = string.Empty;
            string o_dc_yn = string.Empty;
            string o_dc_confirm = string.Empty;
            string o_bannab_yn = string.Empty;
            string o_jundal_part = string.Empty;
            string o_source_fkocs2003 = string.Empty;
            string o_re_use_yn = string.Empty;
            string o_end_type = string.Empty;
            string o_remark = string.Empty;
            string o_input_gubun = string.Empty;
            string o_dv_time = string.Empty;
            string o_dv = string.Empty;
            string o_anti_soyu_yn = string.Empty;
            string o_wonyoi_order_yn = string.Empty;
            string o_wonnae_sayu_code = string.Empty;
            string o_wonyoi_act_yn = string.Empty;
            string o_inv_confirm = string.Empty;
            string o_ho_dong1 = string.Empty;
            string o_suak_jubsu_date = string.Empty;
            string o_suak_ser = string.Empty;
            string o_bunryu6 = string.Empty;
            string o_tpn_joje_gubun = string.Empty;
            string o_powder_yn = string.Empty;
            string o_jubsu_ilsi = string.Empty;
            string o_drg_prn_date = string.Empty;
            string o_er_magam_date = string.Empty;
            string o_er_magam_gubun = string.Empty;
            string o_er_magam_ser = string.Empty;
            string o_jundal_part_run = string.Empty;
            string o_iu_jusa_date = string.Empty;
            string o_mayak_print_yn = string.Empty;
            string o_fkdrg3011 = string.Empty;
            string o_out_bf_dc = string.Empty;
            string o_mix_group = string.Empty;
            string o_hope_date = string.Empty;
            string o_dv_1 = string.Empty;
            string o_dv_2 = string.Empty;
            string o_dv_3 = string.Empty;
            string o_dv_4 = string.Empty;
            string o_dv_5 = string.Empty;
            string o_hubal_change_yn = string.Empty;
            string o_pharmacy = string.Empty;
            string o_jusa_spd_gubun = string.Empty;
            string o_drg_pack_yn = string.Empty;
            string o_jusa = string.Empty;
            string o_jusa_name = string.Empty;

            string o_jaeryo_name = string.Empty;
            string o_bogyong_name = string.Empty;
            string o_order_danui_name = string.Empty;
            string o_subul_danui_name = string.Empty;
            string o_gwa_name = string.Empty;
            string o_doctor_name = string.Empty;
            string o_resident_name = string.Empty;
            string o_serial_v = string.Empty;
            string o_serial_text = string.Empty;

            string o_suname = string.Empty;
            string o_suname2 = string.Empty;
            string o_birth = string.Empty;
            string o_age = string.Empty;
            string o_rp_barcode = string.Empty;
            string o_danui_name = string.Empty;
            string o_data_gubun = string.Empty;
            string o_order_date_text = string.Empty;
            string o_sex_age = string.Empty;
            string o_rp2 = string.Empty;
            string o_cnt = string.Empty;
            string o_line = string.Empty;

            int InsertRow;
            int rowNum;

            DataTable dtLabel = new DataTable();
            DataTable dtSerial = new DataTable();
            DataTable dtRemark = new DataTable();

            string cmdText = "";
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);
            bindVars.Add("f_rp", rp);

            layJusaLable.Reset();

            /* DRGPRINT_I_JUSA_LABLE_CUR */
            cmdText = @"SELECT A.BUNHO                                             BUNHO
                              ,LTRIM(TO_CHAR(A.DRG_BUNHO))                         DRG_BUNHO
                              ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE )    ORDER_DATE_TEXT
                              ,TO_CHAR(A.JUBSU_DATE,'YYYY/MM/DD')                  JUBSU_DATE
                              ,TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD')                  ORDER_DATE
                              ,'Rp.'||E.SERIAL_V||DECODE(A.MIX_GROUP,NULL,'',' M') SERIAL_V
                              ,E.SERIAL_V                                          SERIAL_TEXT
                              ,D.SUNAME                                            SUNAME
                              ,D.SUNAME2                                           SUNAME2
                              ,FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE)          SEX_AGE
                              ,SUBSTRB(FN_DRG_HO_DONG(A.FKINP1001, TRUNC(SYSDATE), 'C'),1,20)      HO_CODE
                              ,SUBSTRB(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)      HO_DONG
                              ,MAX(A.BOGYONG_CODE || ' ' || FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',NVL(A.JUSA_SPD_GUBUN,'0')))     BOGYONG_NAME
                              ,MAX(A.DV)                                           CNT
                              --, '1'                                              CNT
                          FROM DRG2035 E
                              ,OUT0101 D
                              ,DRG0120 C
                              ,INV0110 B
                              ,DRG3010 A
                         WHERE A.HOSP_CODE          = :f_hosp_code
                           AND A.JUBSU_DATE         = :f_jubsu_date
                           AND A.DRG_BUNHO          = :f_drg_bunho
                           AND A.BUNRYU1            = '4'
                           AND NVL(A.DC_YN,'N')     = 'N'
                           AND NVL(A.BANNAB_YN,'N') = 'N'
                           AND B.JAERYO_CODE        = A.JAERYO_CODE
                           AND C.BOGYONG_CODE       (+)= A.BOGYONG_CODE
                           AND D.BUNHO              = A.BUNHO
                           AND E.JUBSU_DATE         = A.JUBSU_DATE
                           AND E.DRG_BUNHO          = A.DRG_BUNHO
                           AND E.FKOCS2003          = A.FKOCS2003   
                           AND E.SERIAL_V           = :f_rp                       
                         GROUP BY A.BUNHO
                              ,LTRIM(TO_CHAR(A.DRG_BUNHO))
                              ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE )
                              ,A.JUBSU_DATE
                              ,A.ORDER_DATE
                              ,'Rp.'||E.SERIAL_V||DECODE(A.MIX_GROUP,NULL,'',' M')
                              ,E.SERIAL_V
                              ,D.SUNAME
                              ,D.SUNAME2
                              ,FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE)
                              ,SUBSTRB(FN_DRG_HO_DONG(A.FKINP1001, TRUNC(SYSDATE), 'C'),1,20)      
                              ,SUBSTRB(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)--,A.DV 
                         ORDER BY LTRIM(TO_CHAR(E.SERIAL_V, '0000'))";
            try
            {
                dtLabel = Service.ExecuteDataTable(cmdText, bindVars);

                for (int i = 0; i < dtLabel.Rows.Count; i++)
                {
                    o_bunho = dtLabel.Rows[i]["bunho"].ToString();
                    o_drg_bunho = dtLabel.Rows[i]["drg_bunho"].ToString();
                    o_order_date_text = dtLabel.Rows[i]["order_date_text"].ToString();
                    o_jubsu_date = dtLabel.Rows[i]["jubsu_date"].ToString();
                    o_order_date = dtLabel.Rows[i]["order_date"].ToString();
                    o_serial_v = dtLabel.Rows[i]["serial_v"].ToString();
                    o_serial_text = dtLabel.Rows[i]["serial_text"].ToString();
                    o_suname = dtLabel.Rows[i]["suname"].ToString();
                    o_suname2 = dtLabel.Rows[i]["suname2"].ToString();
                    o_sex_age = dtLabel.Rows[i]["sex_age"].ToString();
                    o_ho_code = dtLabel.Rows[i]["ho_code"].ToString();
                    o_ho_dong = dtLabel.Rows[i]["ho_dong"].ToString();
                    o_bogyong_name = dtLabel.Rows[i]["bogyong_name"].ToString();
                    o_cnt = dtLabel.Rows[i]["cnt"].ToString();

                    //InsertRow = int.Parse(o_cnt); 
                    InsertRow = 1;

                    bindVars.Remove("f_serial_text");
                    bindVars.Add("f_serial_text", o_serial_text);
                    bindVars.Remove("f_cnt");
                    bindVars.Add("f_cnt", o_cnt);

                    layJusaLable.Reset();

                    for (int k = 1; k <= InsertRow; k++)
                    {
                        bindVars.Remove("k");
                        bindVars.Add("k", k.ToString());
                        bindVars.Add("k", seq.ToString());

                        cmdText = @"SELECT A.JAERYO_CODE                                        JAERYO_CODE
                                         , A.NALSU                                              NALSU
                                         , A.DIVIDE                                             DIVIDE
                                         , A.ORDER_SURYANG                                      ORDER_SURYANG
                                         , A.SUBUL_SURYANG                                      SUBUL_SURYANG
                                         , A.ORD_SURYANG                                        ORD_SURYANG
                                         , A.ORDER_DANUI                                        ORDER_DANUI
                                         , A.SUBUL_DANUI                                        SUBUL_DANUI
                                         , A.BUNRYU1                                            BUNRYU1
                                         , A.BUNRYU2                                            BUNRYU2
                                         , A.BUNRYU3                                            BUNRYU3
                                         , A.BUNRYU4                                            BUNRYU4
                                         , A.REMARK                                             REMARK
                                         , A.DV_TIME                                            DV_TIME
                                         , A.DV                                                 DV
                                         , A.BUNRYU6                                            BUNRYU6
                                         , A.MIX_GROUP                                          MIX_GROUP
                                         , A.DV_1                                               DV_1
                                         , A.DV_2                                               DV_2
                                         , A.DV_3                                               DV_3
                                         , A.DV_4                                               DV_4
                                         , A.DV_5                                               DV_5
                                         , A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN
                                         , A.PHARMACY                                           PHARMACY
                                         , A.JUSA_SPD_GUBUN                                     JUSA_SPD_GUBUN
                                         , A.DRG_PACK_YN                                        DRG_PACK_YN
                                         , A.JUSA                                               JUSA
                                         , B.HANGMOG_NAME                                       JAERYO_NAME
                                         , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI)    DANUI_NAME
                                         , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI)    SUBUL_DANUI_NAME
                                         , FN_OCS_LOAD_CODE_NAME('JUSA',NVL(A.JUSA,'0'))        JUSA_NAME
                                         , TO_CHAR(:k) || '/' || TO_CHAR(:f_cnt)                RP2
                                         , '*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD')||TO_CHAR(A.DRG_BUNHO)||E.SERIAL_V||TO_CHAR(:k)||'*' BARCODE_NO
                                         , 'A'                                                  DATA_GUBUN
                                    FROM DRG2035 E
                                       , OCS2003 C
                                       , OCS0103 B
                                       , DRG3010 A
                                    WHERE A.HOSP_CODE          = :f_hosp_code
                                      AND A.JUBSU_DATE         = :f_jubsu_date
                                      AND A.DRG_BUNHO          = :f_drg_bunho
                                      AND A.DIVIDE            >= :k 
                                      AND A.BUNRYU1            IN ('4')
                                      AND NVL(A.DC_YN,'N')     = 'N'
                                      AND NVL(A.BANNAB_YN,'N') = 'N'
                                      AND B.HOSP_CODE          = C.HOSP_CODE 
                                      AND B.HANGMOG_CODE       = C.HANGMOG_CODE
                                      AND C.HOSP_CODE          = A.HOSP_CODE 
                                      AND C.PKOCS2003          = A.FKOCS2003
                                      AND E.HOSP_CODE          = A.HOSP_CODE 
                                      AND E.JUBSU_DATE         = A.JUBSU_DATE
                                      AND E.DRG_BUNHO          = A.DRG_BUNHO
                                      AND E.FKOCS2003          = A.FKOCS2003
                                      AND E.SERIAL_V           = :f_serial_text
                                      AND C.ORDER_DATE         BETWEEN   B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
                                    ORDER BY LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||
                                             LTRIM(TO_CHAR(DECODE(C.BOM_OCCUR_YN, 'Y', C.SEQ + 100, C.SEQ), '0000'))||
                                             LTRIM(TO_CHAR(C.PKOCS2003, '0000000000'))";

                        dtSerial = Service.ExecuteDataTable(cmdText, bindVars);

                        for (int j = 0; j < dtSerial.Rows.Count; j++)
                        {
                            o_jaeryo_code = dtSerial.Rows[j]["jaeryo_code"].ToString();
                            o_nalsu = dtSerial.Rows[j]["nalsu"].ToString();
                            o_divide = dtSerial.Rows[j]["divide"].ToString();
                            o_order_suryang = dtSerial.Rows[j]["order_suryang"].ToString();
                            o_subul_suryang = dtSerial.Rows[j]["subul_suryang"].ToString();
                            o_ord_suryang = dtSerial.Rows[j]["ord_suryang"].ToString();
                            o_order_danui = dtSerial.Rows[j]["order_danui"].ToString();
                            o_subul_danui = dtSerial.Rows[j]["subul_danui"].ToString();
                            o_bunryu1 = dtSerial.Rows[j]["bunryu1"].ToString();
                            o_bunryu2 = dtSerial.Rows[j]["bunryu2"].ToString();
                            o_bunryu3 = dtSerial.Rows[j]["bunryu3"].ToString();
                            o_bunryu4 = dtSerial.Rows[j]["bunryu4"].ToString();
                            o_remark = dtSerial.Rows[j]["remark"].ToString();
                            o_dv_time = dtSerial.Rows[j]["dv_time"].ToString();
                            o_dv = dtSerial.Rows[j]["dv"].ToString();
                            o_bunryu6 = dtSerial.Rows[j]["bunryu6"].ToString();
                            o_mix_group = dtSerial.Rows[j]["mix_group"].ToString();
                            o_dv_1 = dtSerial.Rows[j]["dv_1"].ToString();
                            o_dv_2 = dtSerial.Rows[j]["dv_2"].ToString();
                            o_dv_3 = dtSerial.Rows[j]["dv_3"].ToString();
                            o_dv_4 = dtSerial.Rows[j]["dv_4"].ToString();
                            o_dv_5 = dtSerial.Rows[j]["dv_5"].ToString();
                            o_hubal_change_yn = dtSerial.Rows[j]["hubal_change_yn"].ToString();
                            o_pharmacy = dtSerial.Rows[j]["pharmacy"].ToString();
                            o_jusa_spd_gubun = dtSerial.Rows[j]["jusa_spd_gubun"].ToString();
                            o_drg_pack_yn = dtSerial.Rows[j]["drg_pack_yn"].ToString();
                            o_jusa = dtSerial.Rows[j]["jusa"].ToString();
                            o_jaeryo_name = dtSerial.Rows[j]["jaeryo_name"].ToString();
                            o_order_danui_name = dtSerial.Rows[j]["danui_name"].ToString();
                            o_subul_danui_name = dtSerial.Rows[j]["subul_danui_name"].ToString();
                            o_jusa_name = dtSerial.Rows[j]["jusa_name"].ToString();
                            o_rp2 = dtSerial.Rows[j]["rp2"].ToString();
                            o_rp_barcode = dtSerial.Rows[j]["barcode_no"].ToString();
                            o_data_gubun = dtSerial.Rows[j]["data_gubun"].ToString();

                            rowNum = layJusaLable.InsertRow(-1);
                            o_line = (rowNum + 1).ToString();

                            layJusaLable.SetItemValue(rowNum, "bunho", o_bunho);
                            layJusaLable.SetItemValue(rowNum, "suname", o_suname);
                            layJusaLable.SetItemValue(rowNum, "suname2", o_suname2);
                            layJusaLable.SetItemValue(rowNum, "birth", o_birth);
                            //layJusaLable.SetItemValue(rowNum, "age", o_age);
                            layJusaLable.SetItemValue(rowNum, "age", o_sex_age);
                            layJusaLable.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                            layJusaLable.SetItemValue(rowNum, "ho_dong", o_ho_dong);
                            layJusaLable.SetItemValue(rowNum, "ho_code", o_ho_code);
                            layJusaLable.SetItemValue(rowNum, "magam_gubun", o_magam_gubun);
                            layJusaLable.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                            layJusaLable.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                            layJusaLable.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                            layJusaLable.SetItemValue(rowNum, "serial_v", o_serial_v);
                            layJusaLable.SetItemValue(rowNum, "resident_name", o_resident_name);
                            layJusaLable.SetItemValue(rowNum, "jusa", o_jusa_name);
                            layJusaLable.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                            layJusaLable.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                            layJusaLable.SetItemValue(rowNum, "ord_suryang", o_ord_suryang);
                            layJusaLable.SetItemValue(rowNum, "order_danui", o_order_danui_name);
                            layJusaLable.SetItemValue(rowNum, "dv", o_dv);
                            layJusaLable.SetItemValue(rowNum, "subul_suryang", o_subul_suryang);
                            layJusaLable.SetItemValue(rowNum, "subul_danui", o_subul_danui);
                            layJusaLable.SetItemValue(rowNum, "order_remark", o_remark);
                            layJusaLable.SetItemValue(rowNum, "rp_barcode", o_rp_barcode);
                            layJusaLable.SetItemValue(rowNum, "order_date", o_order_date);
                            layJusaLable.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                            layJusaLable.SetItemValue(rowNum, "rp2", o_rp2);
                            layJusaLable.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                            layJusaLable.SetItemValue(rowNum, "line", o_line);
                        }
                    }

                    //dw_lable.Reset();
                    //dw_lable.FillData(layJusaLable.LayoutTable);

                    //if (dw_lable.RowCount > 0)
                    //    dw_lable.Print();

                }
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message + "\n\r" + ex.StackTrace);
                return false;
            }
            return true;
        }
        #endregion
    }
}

