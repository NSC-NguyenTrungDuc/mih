#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using IHIS.BASS.Properties;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
#endregion

namespace IHIS.BASS
{
	/// <summary>
	/// BAS0111U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0111U00 : IHIS.Framework.XScreen
	{
		#region 사용자 변수
		string mbxMsg = string.Empty;
		string mbxCap = string.Empty;
		string mjohap_gubun = string.Empty;

		#endregion

		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XEditGrid grdBAS0111;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XMstGrid grdMaster;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XLabel xLabel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XInfoCombo cboJohap_gubun;
		private IHIS.Framework.XDatePicker dtpNaewon_date;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.SingleLayout layGetJohapGubun;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XFindBox fbxJohap;
		private IHIS.Framework.XFindWorker fwkGaein;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.SingleLayout vsvJohap;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XGridHeader xGridHeader2;
        private IHIS.Framework.SingleLayout vsvZipCode;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BAS0111U00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0111U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdBAS0111 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.fbxJohap = new IHIS.Framework.XFindBox();
            this.fwkGaein = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dtpNaewon_date = new IHIS.Framework.XDatePicker();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.cboJohap_gubun = new IHIS.Framework.XInfoCombo();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.layGetJohapGubun = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.vsvJohap = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.vsvZipCode = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboJohap_gubun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdBAS0111
            // 
            this.grdBAS0111.AddedHeaderLine = 1;
            this.grdBAS0111.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell11,
            this.xEditGridCell12});
            this.grdBAS0111.ColPerLine = 7;
            this.grdBAS0111.Cols = 8;
            resources.ApplyResources(this.grdBAS0111, "grdBAS0111");
            this.grdBAS0111.ExecuteQuery = null;
            this.grdBAS0111.FixedCols = 1;
            this.grdBAS0111.FixedRows = 2;
            this.grdBAS0111.HeaderHeights.Add(21);
            this.grdBAS0111.HeaderHeights.Add(0);
            this.grdBAS0111.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2});
            this.grdBAS0111.MasterLayout = this.grdMaster;
            this.grdBAS0111.Name = "grdBAS0111";
            this.grdBAS0111.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBAS0111.ParamList")));
            //this.grdBAS0111.QuerySQL = resources.GetString("grdBAS0111.QuerySQL");
            this.grdBAS0111.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdBAS0111.RowHeaderVisible = true;
            this.grdBAS0111.Rows = 3;
            this.grdBAS0111.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdBAS0111_GridColumnChanged);
            this.grdBAS0111.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdBAS0111_MouseDown);
            this.grdBAS0111.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdBAS0111_GridFindClick);
            this.grdBAS0111.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBAS0111_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 2;
            this.xEditGridCell1.CellName = "johap_gubun";
            this.xEditGridCell1.CellWidth = 100;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 13;
            this.xEditGridCell2.CellName = "johap";
            this.xEditGridCell2.CellWidth = 90;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 500;
            this.xEditGridCell3.CellName = "gaein";
            this.xEditGridCell3.CellWidth = 179;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.RowSpan = 2;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "user_yn";
            this.xEditGridCell4.CellWidth = 32;
            this.xEditGridCell4.Col = 7;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.InitValue = "Y";
            this.xEditGridCell4.RowSpan = 2;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AutoTabDataSelected = true;
            this.xEditGridCell7.CellLen = 3;
            this.xEditGridCell7.CellName = "zip_code1";
            this.xEditGridCell7.CellWidth = 58;
            this.xEditGridCell7.Col = 3;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell7.Row = 1;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 4;
            this.xEditGridCell8.CellName = "zip_code2";
            this.xEditGridCell8.CellWidth = 61;
            this.xEditGridCell8.Col = 4;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell8.Row = 1;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AutoTabDataSelected = true;
            this.xEditGridCell9.CellLen = 100;
            this.xEditGridCell9.CellName = "address";
            this.xEditGridCell9.CellWidth = 206;
            this.xEditGridCell9.Col = 5;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell9.Row = 1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellLen = 100;
            this.xEditGridCell11.CellName = "address1";
            this.xEditGridCell11.CellWidth = 185;
            this.xEditGridCell11.Col = 6;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell11.Row = 1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellLen = 100;
            this.xEditGridCell12.CellName = "gaein_name";
            this.xEditGridCell12.CellWidth = 264;
            this.xEditGridCell12.Col = 2;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell12.RowSpan = 2;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 3;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 58;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 5;
            this.xGridHeader2.ColSpan = 2;
            this.xGridHeader2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 206;
            // 
            // grdMaster
            // 
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell5,
            this.xEditGridCell10,
            this.xEditGridCell6});
            this.grdMaster.ColPerLine = 2;
            this.grdMaster.Cols = 3;
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(21);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.QuerySQL = resources.GetString("grdMaster.QuerySQL");
            this.grdMaster.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 2;
            this.xEditGridCell5.CellName = "johap_gubun";
            this.xEditGridCell5.CellWidth = 137;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 13;
            this.xEditGridCell10.CellName = "johap";
            this.xEditGridCell10.Col = 1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "johap_name";
            this.xEditGridCell6.CellWidth = 123;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.fbxJohap);
            this.pnlTop.Controls.Add(this.xLabel3);
            this.pnlTop.Controls.Add(this.dtpNaewon_date);
            this.pnlTop.Controls.Add(this.xLabel2);
            this.pnlTop.Controls.Add(this.cboJohap_gubun);
            this.pnlTop.Controls.Add(this.xLabel1);
            this.pnlTop.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            // 
            // fbxJohap
            // 
            this.fbxJohap.FindWorker = this.fwkGaein;
            resources.ApplyResources(this.fbxJohap, "fbxJohap");
            this.fbxJohap.Name = "fbxJohap";
            this.fbxJohap.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxJohap_DataValidating);
            // 
            // fwkGaein
            // 
            this.fwkGaein.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkGaein.ExecuteQuery = null;
            this.fwkGaein.FormText = "保険者番号照会";
            this.fwkGaein.InputSQL = resources.GetString("fwkGaein.InputSQL");
            this.fwkGaein.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkGaein.ParamList")));
            this.fwkGaein.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkGaein.ServerFilter = true;
            this.fwkGaein.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkGaein_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "johap";
            this.findColumnInfo1.ColWidth = 97;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "johap_name";
            this.findColumnInfo2.ColWidth = 327;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // dtpNaewon_date
            // 
            this.dtpNaewon_date.IsJapanYearType = true;
            resources.ApplyResources(this.dtpNaewon_date, "dtpNaewon_date");
            this.dtpNaewon_date.Name = "dtpNaewon_date";
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // cboJohap_gubun
            // 
            this.cboJohap_gubun.CodeType = "JOHAP_GUBUN";
            this.cboJohap_gubun.DataList = null;
            resources.ApplyResources(this.cboJohap_gubun, "cboJohap_gubun");
            this.cboJohap_gubun.Name = "cboJohap_gubun";
            this.cboJohap_gubun.SelectedIndexChanged += new System.EventHandler(this.cboJohap_gubun_SelectedIndexChanged);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // layGetJohapGubun
            // 
            this.layGetJohapGubun.ExecuteQuery = null;
            this.layGetJohapGubun.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layGetJohapGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layGetJohapGubun.ParamList")));
            //this.layGetJohapGubun.QuerySQL = resources.GetString("layGetJohapGubun.QuerySQL");
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "johap_gubun";
            // 
            // vsvJohap
            // 
            this.vsvJohap.ExecuteQuery = null;
            this.vsvJohap.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.vsvJohap.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvJohap.ParamList")));
            this.vsvJohap.QuerySQL = "SELECT A.JOHAP_NAME\r\n  FROM BAS0110 A\r\n WHERE A.HOSP_CODE = :f_hosp_code\r\n   AND " +
                "A.JOHAP     = :f_johap\r\n   AND TO_DATE(:f_start_date, \'YYYY/MM/DD\') BETWEEN A.ST" +
                "ART_DATE AND A.END_DATE";
            this.vsvJohap.QueryStarting += new System.ComponentModel.CancelEventHandler(this.vsvJohap_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "johap_name";
            // 
            // vsvZipCode
            // 
            this.vsvZipCode.ExecuteQuery = null;
            this.vsvZipCode.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem3});
            this.vsvZipCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvZipCode.ParamList")));
            this.vsvZipCode.QuerySQL = resources.GetString("vsvZipCode.QuerySQL");
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "address";
            // 
            // BAS0111U00
            // 
            this.Controls.Add(this.grdBAS0111);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grdMaster);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.xPanel1);
            this.Name = "BAS0111U00";
            resources.ApplyResources(this, "$this");
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.BAS0111U00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboJohap_gubun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수 

		private string mGaein = "";

		private string mMsg = "";
		private string mCap = "";

		#endregion

		#region Screen Open 이벤트 

		/// <summary>
		/// Screen Open
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BAS0111U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			string johap_gurun = string.Empty;

			this.grdBAS0111.SetRelationKey("johap_gubun", "johap_gubun");
			this.grdBAS0111.SetRelationKey("johap", "johap");
			this.grdMaster.SetRelationTable("BAS0111");

            grdBAS0111.ParamList = new List<string>(new String[] { "f_hosp_code", "f_johap_gubun", "f_johap" });
		    grdBAS0111.ExecuteQuery = ExecuteQueryGrdBas0111ListItem;

            grdMaster.ParamList = new List<string>(new String[] { "f_hosp_code", "f_johap_gubun", "f_johap", "f_naewon_date" });
		    grdMaster.ExecuteQuery = ExecuteQueryGrdMasterListItem;

            layGetJohapGubun.ParamList = new List<string>(new String[] { "f_hosp_code", "f_gubun", "f_naewon_date" });
            layGetJohapGubun.ExecuteQuery = ExecuteQueryLayGetListItem;

            vsvJohap.ParamList = new List<string>(new String[] { "f_hosp_code", "f_johap", "f_start_date" });
		    vsvJohap.ExecuteQuery = ExecuteQueryVzvJohapListItem;

            vsvZipCode.ParamList = new List<string>(new String[] { "f_hosp_code", "f_zip1", "f_zip2" });
		    vsvZipCode.ExecuteQuery = ExecuteQueryVzvZipcodeListItem;

           

            this.grdBAS0111.SavePerformer = new XSavePerformer(this);

			if (OpenParam != null)
			{
				if (OpenParam.Contains("gubun"))
                {
                    this.layGetJohapGubun.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					this.layGetJohapGubun.SetBindVarValue("f_gubun", this.OpenParam["gubun"].ToString());
                    this.layGetJohapGubun.SetBindVarValue("f_naewon_date", this.OpenParam["naewon_date"].ToString());
                    this.layGetJohapGubun.QueryLayout();
				}

				if (this.OpenParam.Contains("johap_gubun"))
				{
                    cboJohap_gubun.SetDataValue(this.OpenParam["johap_gubun"].ToString());
                   
				}
				else
				{
                    cboJohap_gubun.SetDataValue(this.layGetJohapGubun.GetItemValue("johap_gubun").ToString());
				}

				if (this.OpenParam.Contains("naewon_date"))
				{
					dtpNaewon_date.SetDataValue(this.OpenParam["naewon_date"].ToString());
				}
				else
				{
					dtpNaewon_date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
				}

				if (this.OpenParam.Contains("johap"))
				{
					this.fbxJohap.SetDataValue(this.OpenParam["johap"].ToString());
				}

				grdMaster.Reset();

                //if (TypeCheck.IsNull(cboJohap_gubun.GetDataValue()) == false)
                //{
                    this.grdMaster.QueryLayout(false);
				//}

				if (this.OpenParam.Contains("johap"))
				{
					this.SelectJohap(this.OpenParam["johap"].ToString());
				}

			}
			else
			{
				cboJohap_gubun.SelectedIndex = 0;
				dtpNaewon_date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")); /* 오늘 */
				fbxJohap.SetDataValue("%"); /* 전체 */
			}

		}

		#endregion

		#region 조합구분 Find
		private void fbxJohap_gubun_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
//			string johap_gubun = string.Empty;
//			if (TypeCheck.IsNull(fbxJohap_gubun.GetDataValue()) == true)
//			{	
//				return;
//			}
//			johap_gubun = fbxJohap_gubun.GetDataValue();
//
//			fwkComm.AutoQuery = true;
//			fwkComm.InputSQL =  "SELECT A.JOHAP, A.JOHAP_NAME  " + 
//				"  FROM BAS0110 A, "             + 
//				"       ( SELECT Z.JOHAP_GUBUN, Z.JOHAP, MAX(Z.JOHAP_YMD) JOHAP_YMD " + 
//				"           FROM BAS0110 Z "                       + 
//				"          WHERE Z.JOHAP_GUBUN = '" + johap_gubun + "'" + 
//				"            AND Z.JOHAP_YMD   <= TO_DATE(SYSDATE, 'YYYY/MM/DD')" +
//				"          GROUP BY Z.JOHAP_GUBUN, Z.JOHAP ) B "       + 
//				" WHERE A.JOHAP_GUBUN = B.JOHAP_GUBUN "            + 
//				"   AND A.JOHAP       = B.JOHAP "                  + 
//				"   AND A.JOHAP_YMD   = B.JOHAP_YMD "  +
//				" ORDER BY A.JOHAP";
//
//			fwkComm.ColInfos.Clear();
//			fwkComm.FormText = "保険者番号区分";
//			fwkComm.ColInfos.Add("johap", "保険者番号", FindColType.String, 100, 0, true, FilterType.No); 
//			fwkComm.ColInfos.Add("johap_name", "保険者番号名", FindColType.String, 300, 0, true, FilterType.No);

		}
		#endregion

		#region 조합구분 Validating
		private void fbxJohap_gubun_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
//			if (TypeCheck.IsNull(e.DataValue.ToString()) == true)
//			{
//				dbxJohap_Gubun_Name.SetDataValue("");
//				grdMaster.Reset();
//				grdBAS0111.Reset();
//				return;
//			}
		
		}
		#endregion

		#region 조합구분 콤보에서 선택했을때
		private void cboJohap_gubun_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (TypeCheck.IsNull(cboJohap_gubun.GetDataValue()) == true)
			{
				return;
            }
            //this.grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.grdMaster.SetBindVarValue("f_johap_gubun", cboJohap_gubun.GetDataValue().ToString());
            //this.grdMaster.SetBindVarValue("f_naewon_date", dtpNaewon_date.GetDataValue().ToString());
            //this.grdMaster.SetBindVarValue("f_johap", this.fbxJohap.GetDataValue());

			grdMaster.Reset();

			if (this.grdMaster.QueryLayout(false) == false)
			{
				XMessageBox.Show(Service.ErrFullMsg);
				return;
			}

		}
		#endregion

		#region 다른 스크린 오픈

		/// <summary>
		/// 우편번호 조회 창 Open
		/// </summary>
		/// <param name="aSearchGubun"></param>
		/// <param name="aZipCode1"></param>
		/// <param name="aZipCode2"></param>
		/// <param name="aAddress"></param>
		private void OpenScreen_BAS0123Q00(string aSearchGubun, string aZipCode1, string aZipCode2, string aAddress)
		{
			CommonItemCollection param = new CommonItemCollection();

			if (aSearchGubun == "zipCode")
			{
				param.Add("SearchGubun", aSearchGubun);
				param.Add("zip_code1", aZipCode1);
				param.Add("zip_code2", aZipCode2);
			}
			else
			{
				param.Add("SearchGubun", aSearchGubun);
				param.Add("address", aAddress);
			}

			XScreen.OpenScreenWithParam(this, "BASS", "BAS0123Q00", ScreenOpenStyle.ResponseFixed, param);
		}

		#endregion

		#region [   버튼 리스트 관련   ]

		#region 조회
		private void All_Query()
		{

			mbxMsg = "";
			mbxCap = "";

			if (TypeCheck.IsNull(cboJohap_gubun.GetDataValue()) == true)
			{
				return;
			}

			if (TypeCheck.IsNull(dtpNaewon_date.GetDataValue()) == true)
			{
				return;
			}

//			if (TypeCheck.IsDateTime(dtpChojae_Ymd.GetDataValue()) == false || TypeCheck.IsNull(dtpChojae_Ymd.GetDataValue()) == true)
//			{
//				mbxMsg = NetInfo.Language == LangMode.Jr ? "初再診適用日付けを入力してください" 
//					: "초재진적용일자를 입력하십시오";
//				mbxCap = NetInfo.Language == LangMode.Jr ? "確認!!!" : "확인!!!";
//				XMessageBox.Show(mbxMsg, mbxCap);
//			}

            //dsvMaster.SetInValue("johap_gubun", cboJohap_gubun.GetDataValue().ToString());
            //dsvMaster.SetInValue("naewon_date", dtpNaewon_date.GetDataValue().ToString());
            //dsvMaster.SetInValue("johap"      , fbxJohap.GetDataValue());

			grdMaster.Reset();

			if (!this.grdMaster.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg);
				return;
			}

			if (!TypeCheck.IsNull(mjohap_gubun))
			{
				for (int i = 0; i < grdMaster.RowCount; i++)
				{
					if (mjohap_gubun == grdMaster.GetItemString(i, "johap_gubun"))
					{
						grdMaster.SetFocusToItem(i, "johap_gubun_name");
						break;
					}
				}
			}
			
		}
		#endregion

		#region 저장
		private void All_Save()
		{
			for (int i = 0; i < grdBAS0111.RowCount; i++)
			{
				if (grdBAS0111.GetRowState(i) == DataRowState.Added || grdBAS0111.GetRowState(i) != DataRowState.Deleted)
				{
//					if ( TypeCheck.IsNull(grdBAS0111.GetItemString(i, "johap_gubun").ToString()) == true) 
//					{
//						//dtpChojae_Ymd.Focus();
//						return;
//					}
//
//					if ( TypeCheck.IsNull(grdBAS0111.GetItemString(i, "johap").ToString()) == true) 
//					{
//						grdBAS0111.SetFocusToItem(i, "johap");
//						return;
//					}

					if ( TypeCheck.IsNull(grdBAS0111.GetItemString(i, "gaein")) == true) 
					{
						grdBAS0111.SetFocusToItem(i, "gaein");
						return;
					}

				}
			}

			//if (!this.grdBAS0111.SaveLayout())
            if (!GrdListSaveLayout())
			{
				XMessageBox.Show(Resources.MSG_FAIL, "保存失敗", MessageBoxIcon.Error );
				return;
			}

			mjohap_gubun = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "johap_gubun");

			mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が完了しました。" 
				: "정상적으로 저장 되었습니다" ;
            mbxCap = NetInfo.Language == LangMode.Jr ? "保存" : "";
			XMessageBox.Show(mbxMsg, mbxCap);

			All_Query();
		}
		#endregion

		#region 입력
		private void Row_insert()
		{
			
			for (int i =0; i < grdBAS0111.RowCount; i++)
			{
				if ( TypeCheck.IsNull(grdBAS0111.GetItemString(i, "johap")) == true) 
				{
					grdBAS0111.SetFocusToItem(i, "johap");
					return;
				}

				if ( TypeCheck.IsNull(grdBAS0111.GetItemString(i, "gaein")) == true) 
				{
					grdBAS0111.SetFocusToItem(i, "gaein");
					return;
				}
			}

			grdBAS0111.InsertRow();

			this.grdBAS0111.SetItemValue(this.grdBAS0111.CurrentRowNumber, "user_yn", "Y");

		}
		#endregion

		#region 초기화
		private void All_Reset()
		{

		}
		#endregion

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					mjohap_gubun = "";
					All_Query();
					break;
				case FunctionType.Update:
					e.IsBaseCall = false;
					All_Save();
					break;
				case FunctionType.Insert:
					e.IsBaseCall = false;
					Row_insert();
					break;

				default:
					break;
			}
		}


		#endregion

		#region Johap Select

		private void SelectJohap(string aJohap)
		{
			for (int i=0; i<this.grdMaster.RowCount; i++)
			{
				if (this.grdMaster.GetItemString(i, "johap") == aJohap)
				{
					this.grdMaster.SetFocusToItem(i, "johap_name");
					break;
				}
			}
		}

		#endregion

		#region XFindBox

		private void fbxJohap_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			// 공백은 통과
			if (e.DataValue == "")
			{
				return ;
			}

			// 전체
			if (e.DataValue == "%")
			{
				return ;
			}

            this.vsvJohap.SetBindVarValue("f_johap", e.DataValue);
			this.vsvJohap.QueryLayout();

			if (this.vsvJohap.GetItemValue("johap_name").ToString() == "")
			{
				this.mbxMsg = (NetInfo.Language == LangMode.Ko ? "보험자 번호가 정확하지 않습니다." : "保険者番号が有効ではありません。ご確認ください。");

				this.SetMsg(this.mbxMsg, MsgType.Error);
                e.Cancel = true;
				return;
            }
		}

		#endregion

		#region 기호 그리드 (BAS0111)

		#region Grid MouseDown

		private void grdBAS0111_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int rowNumber;

			if (e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				rowNumber = this.grdBAS0111.GetHitRowNumber(e.Y);
	
				if (rowNumber < 0)
					return ;
				
				this.mGaein = this.grdBAS0111.GetItemString(rowNumber, "gaein");

				CommonItemCollection param = new CommonItemCollection();

				param.Add("gaein", this.mGaein);

				((XScreen)(this.Opener)).Command("BAS0111U00", param);

				this.Close();
			}
		}

		#endregion

		#region 그리드 파인드 클릭

		private void grdBAS0111_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
			switch (e.ColName)
			{
				case "zip_code1":

					this.OpenScreen_BAS0123Q00("ZipCode", this.grdBAS0111.GetItemString(e.RowNumber, "zip_code1")
						                                , this.grdBAS0111.GetItemString(e.RowNumber, "zip_code2"), "");

					break;

				case "address" :

					this.OpenScreen_BAS0123Q00("address", "", "", this.grdBAS0111.GetItemString(e.RowNumber, "address"));

					break;
			}
		}

		#endregion

		#region Column Changed

		private void grdBAS0111_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			string name = "";

			switch (e.ColName)
			{
				case "zip_code1" :

					if (e.ChangeValue.ToString() != this.grdBAS0111.GetItemString(e.RowNumber, "zip_code1", DataBufferType.OriginalBuffer))
					{
						this.grdBAS0111.SetItemValue(e.RowNumber, "zip_code2", "");
					}

					break;

				case "zip_code2" :

					if (e.ChangeValue.ToString() == "") 
					{
						this.grdBAS0111.SetItemValue(e.RowNumber, "address", "");
						this.grdBAS0111.SetItemValue(e.RowNumber, "address1", "");

						this.SetMsg("");

						return;
					}
                    this.vsvZipCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.vsvZipCode.SetBindVarValue("f_zip1", this.grdBAS0111.GetItemString(e.RowNumber, "zip_code1"));
                    this.vsvZipCode.SetBindVarValue("f_zip2", e.ChangeValue.ToString());

					this.vsvZipCode.QueryLayout();

                    name = this.vsvZipCode.GetItemValue("address").ToString();

                    if (name == "")
                    {
                        this.mMsg = (NetInfo.Language == LangMode.Ko ? "우편번호가 정확하지 않습니다. 확인바랍니다."
                                                                     : "郵便番号が有効ではありません。 ご確認ください。");

                        this.SetMsg(this.mMsg, MsgType.Error);

                        e.Cancel = true;
                    }
                    else
                    {
                        this.grdBAS0111.SetItemValue(e.RowNumber, "address", name);

                        this.SetMsg("");

                    }

					break;
			}
		}

		#endregion

		#endregion

		#region Command

		public override object Command(string command, CommonItemCollection commandParam)
		{
			switch (command)
			{
				case "BAS0123Q00":
					this.grdBAS0111.SetItemValue(grdBAS0111.CurrentRowNumber, "zip_code1", commandParam["zip_code1"]);
					this.grdBAS0111.SetItemValue(grdBAS0111.CurrentRowNumber, "zip_code2", commandParam["zip_code2"]);
					this.grdBAS0111.SetItemValue(grdBAS0111.CurrentRowNumber, "address", commandParam["address"]);

					PostCallHelper.PostCall(new PostMethodStr(PostCommandMethod), "zip_code");

					break;
			}

			return base.Command (command, commandParam);
		}

		#endregion

		#region Post Call Method

		private void PostCommandMethod (string aCommand)
		{
			switch (aCommand)
			{
				case "zip_code" :

					this.grdBAS0111.SetFocusToItem(this.grdBAS0111.CurrentRowNumber, "address", true);

					break;
			}
		}

		#endregion

        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdMaster.SetBindVarValue("f_johap_gubun", cboJohap_gubun.GetDataValue());
            this.grdMaster.SetBindVarValue("f_naewon_date", dtpNaewon_date.GetDataValue());
            this.grdMaster.SetBindVarValue("f_johap", this.fbxJohap.GetDataValue());
        }

        private void fwkGaein_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkGaein.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.fwkGaein.SetBindVarValue("f_johap_gubun", cboJohap_gubun.GetDataValue());
            this.fwkGaein.SetBindVarValue("f_start_date", dtpNaewon_date.GetDataValue());
        }

        private void vsvJohap_QueryStarting(object sender, CancelEventArgs e)
        {
            this.vsvJohap.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.vsvJohap.SetBindVarValue("f_start_date", dtpNaewon_date.GetDataValue());
        }

        private void grdBAS0111_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdBAS0111.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdBAS0111.SetBindVarValue("f_johap_gubun", grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "johap_gubun"));
            this.grdBAS0111.SetBindVarValue("f_johap", grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "johap"));
        }

        #region XSavePerformer
        string mErrMsg = "";

        private class XSavePerformer : ISavePerformer
        {
            private BAS0111U00 parent;

            public XSavePerformer(BAS0111U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                object retVal = null;

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (item.RowState)
                {
                    case DataRowState.Added:
                        /* 존재여부 체크 */
                        cmdText = @"SELECT 'Y'
                                      FROM BAS0111
                                     WHERE HOSP_CODE   = :f_hosp_code
                                       AND JOHAP_GUBUN = :f_johap_gubun
                                       AND JOHAP       = :f_johap
                                       AND GAEIN       = :f_gaein";

                        retVal = null;
                        retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                        if (!TypeCheck.IsNull(retVal))
                        {
                            if (retVal.ToString() == "Y")
                            {
                                parent.mErrMsg = "「保険者種別区分:" + item.BindVarList["f_johap_gubun"].VarValue + "、"
                                               + "保険者区分:" + item.BindVarList["f_johap"].VarValue + "、"
                                               + "記号:" + item.BindVarList["f_gaein"].VarValue 
                                               + "」は既に登録されています。";

                                

                                return false;
                            }
                        }

                        cmdText = @"SELECT CODE_NAME
                                      FROM BAS0102
                                     WHERE HOSP_CODE = :f_hosp_code
                                       AND CODE_TYPE = 'JOHAP_GUBUN'
                                       AND CODE      = :f_johap_gubun";
                        retVal = null;
                        retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                        if (TypeCheck.IsNull(retVal))
                        {
                            parent.mErrMsg = "「保険者種別区分:" + item.BindVarList["f_johap_gubun"].VarValue
                                           + "」が基準情報に登録されていません。ご確認ください。";
                            
                            return false;
                        }

                        cmdText = @"INSERT INTO BAS0111
                                         ( SYS_DATE
                                         , SYS_ID
                                         , UPD_DATE
                                         , UPD_ID
                                         , HOSP_CODE
                                         , JOHAP
                                         , GAEIN
                                         , JOHAP_GUBUN
                                         , USE_YN         
                                         , ZIP_CODE1
                                         , ZIP_CODE2
                                         , ADDRESS
                                         , ADDRESS1          
                                         , GAEIN_NAME       )
                                    VALUES 
                                         ( SYSDATE
                                         , :q_user_id
                                         , SYSDATE
                                         , :q_user_id
                                         , :f_hosp_code
                                         , :f_johap
                                         , :f_gaein
                                         , :f_johap_gubun
                                         , :f_use_yn         
                                         , :f_zip_code1
                                         , :f_zip_code2
                                         , :f_address
                                         , :f_address1      
                                         , :f_gaein_name    )";

                        break;
                        
                    case DataRowState.Modified:
                        cmdText = @"SELECT CODE_NAME
                                      FROM BAS0102
                                     WHERE HOSP_CODE = :f_hosp_code
                                       AND CODE_TYPE = 'JOHAP_GUBUN'
                                       AND CODE      = :f_johap_gubun";
                        retVal = null;
                        retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                        if (TypeCheck.IsNull(retVal))
                        {
                            parent.mErrMsg = "「保険者種別区分:" + item.BindVarList["f_johap_gubun"].VarValue
                                           + "」が基準情報に登録されていません。ご確認ください。";
                            return false;
                        }

                        cmdText = @"UPDATE BAS0111
                                       SET UPD_ID      = :q_user_id
                                         , UPD_DATE    = SYSDATE
                                         , USE_YN      = :f_use_yn
                                         , ZIP_CODE1   = :f_zip_code1
                                         , ZIP_CODE2   = :f_zip_code2
                                         , ADDRESS     = :f_address  
                                         , ADDRESS1    = :f_address1 
                                         , GAEIN_NAME  = :f_gaein_name
                                     WHERE HOSP_CODE   = :f_hosp_code
                                       AND JOHAP_GUBUN = :f_johap_gubun
                                       AND JOHAP       = :f_johap
                                       AND GAEIN       = :f_gaein   ";

                        break;


                    case DataRowState.Deleted:

                        cmdText = @"DELETE BAS0111
                                     WHERE HOSP_CODE   = :f_hosp_code
                                       AND JOHAP_GUBUN = :f_johap_gubun
                                       AND JOHAP       = :f_johap
                                       AND GAEIN       = :f_gaein ";

                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }

        }

        #endregion

        #region Connect to cloud\

        private IList<object[]> ExecuteQueryGrdMasterListItem(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            BAS0111U00GrdMasterArgs vBas0111U00GrdMasterArgs = new BAS0111U00GrdMasterArgs();
            vBas0111U00GrdMasterArgs.FHospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            vBas0111U00GrdMasterArgs.FJohapGubun = bc["f_johap_gubun"] != null ? bc["f_johap_gubun"].VarValue : "";
            vBas0111U00GrdMasterArgs.FJohap = bc["f_johap"] != null ? bc["f_johap"].VarValue : "";
            vBas0111U00GrdMasterArgs.FNaewonDate = bc["f_naewon_date"] != null ? bc["f_naewon_date"].VarValue : "";
            BAS0111U00GrdMasterResult result = CloudService.Instance.Submit<BAS0111U00GrdMasterResult, BAS0111U00GrdMasterArgs>(vBas0111U00GrdMasterArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0111U00GrdMasterItemInfo item in result.Dt)
                {
                    object[] objects =
                    {
                        item.JohapGubun,
                        item.Johap,
                        item.JohapName
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private IList<object[]> ExecuteQueryGrdBas0111ListItem(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            BAS0111U00GrdBas0111Args vBas0111U00GrdBas0111Args = new BAS0111U00GrdBas0111Args();
            vBas0111U00GrdBas0111Args.FHospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            vBas0111U00GrdBas0111Args.FJohapGubun = bc["f_johap_gubun"] != null ? bc["f_johap_gubun"].VarValue : "";
            vBas0111U00GrdBas0111Args.FJohap = bc["f_johap"] != null ? bc["f_johap"].VarValue : "";
            BAS0111U00GrdBas0111Result result = CloudService.Instance.Submit<BAS0111U00GrdBas0111Result, BAS0111U00GrdBas0111Args>(vBas0111U00GrdBas0111Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0111U00GrdBas0111ItemInfo item in result.Dt)
                {
                    object[] objects =
                    {
                        item.JohapGubun,
                        item.Johap,
                        item.Gaein,
                        item.UseYn,
                        item.ZipCode1,
                        item.ZipCode2,
                        item.Address,
                        item.Address1,
                        item.Name,
                        item.ContKey
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private IList<object[]> ExecuteQueryVzvJohapListItem(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            BAS0111U00VzvJohapArgs args = new BAS0111U00VzvJohapArgs();
            args.FHospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            args.FStartDate = bc["f_start_date"] != null ? bc["f_start_date"].VarValue : "";
            args.FJohap = bc["f_johap"] != null ? bc["f_johap"].VarValue : "";
            BAS0111U00VzvJohapResult result = CloudService.Instance.Submit<BAS0111U00VzvJohapResult, BAS0111U00VzvJohapArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0111U00LayVzvItemInfo item in result.Dt)
                {
                    object[] objects =
                    {
                        item.Name
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private IList<object[]> ExecuteQueryVzvZipcodeListItem(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            BAS0111U00VzvZipCodeArgs args = new BAS0111U00VzvZipCodeArgs();
            args.FHospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            args.FZip1 = bc["f_zip1"] != null ? bc["f_zip1"].VarValue : "";
            args.FZip2 = bc["f_zip2"] != null ? bc["f_zip2"].VarValue : "";
            BAS0111U00VzvZipCodeResult result = CloudService.Instance.Submit<BAS0111U00VzvZipCodeResult, BAS0111U00VzvZipCodeArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0111U00LayVzvItemInfo item in result.Dt)
                {
                    object[] objects =
                    {
                        item.Name
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private IList<object[]> ExecuteQueryLayGetListItem(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            BAS0111U00LayGetJohapArgs args = new BAS0111U00LayGetJohapArgs();
            args.FHospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            args.FGubun = bc["f_gubun"] != null ? bc["f_gubun"].VarValue : "";
            args.FNaewonDate = bc["f_naewon_date"] != null ? bc["f_naewon_date"].VarValue : "";
            BAS0111U00LayGetJohapResult result = CloudService.Instance.Submit<BAS0111U00LayGetJohapResult, BAS0111U00LayGetJohapArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0111U00LayVzvItemInfo item in result.Dt)
                {
                    object[] objects =
                    {
                        item.Name
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

	    private bool GrdListSaveLayout()
	    {
            for (int i = 0; i < grdBAS0111.RowCount; i++)
	        {
	            if (grdBAS0111.GetRowState(i) == DataRowState.Added)
	            {
	            }
	        }

            // Update data
            BAS0111U00SaveLayoutArgs args = new BAS0111U00SaveLayoutArgs();
            args.GrdItem = createGrdListItemInfo();
            if (!ValidateGrdItem(args.GrdItem))
            {
                return false;
            }
            args.QUserId = UserInfo.UserID;
	        args.FHospCode = EnvironInfo.HospCode;



            BAS0111U00SaveLayoutResult updateResult = CloudService.Instance.Submit<BAS0111U00SaveLayoutResult, BAS0111U00SaveLayoutArgs>(args);

	        if (updateResult != null)
	        {
	            string msg = "";
	            switch (updateResult.ErrFlag)
	            {
                    case "1":
	                    msg = string.Format(Resources.MSG_001, updateResult.JohapGubun, updateResult.Johap,
	                        updateResult.Gaein);
                        XMessageBox.Show(msg, Resources.CAP_001, MessageBoxButtons.OK, MessageBoxIcon.Error);
	                    return false;
                    case "2":
                        msg = string.Format(Resources.MSG_002, updateResult.JohapGubun);
                        XMessageBox.Show(msg, Resources.CAP_001, MessageBoxButtons.OK, MessageBoxIcon.Error);
	                    return false;
                    case "3":
                        msg = string.Format(Resources.MSG_003, updateResult.JohapGubun);
                        XMessageBox.Show(msg, Resources.CAP_001, MessageBoxButtons.OK, MessageBoxIcon.Error);
	                    return false;
	            }
	        }
            if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
                updateResult.Result == false)
            {
                return false;
            }
            return true;

            
	    }

        private bool ValidateGrdItem(List<BAS0111U00GrdBas0111ItemInfo> list)
        {
            if (list.Count > 0)
            {
                foreach (BAS0111U00GrdBas0111ItemInfo item in list)
                {
                    if (String.IsNullOrEmpty(item.Johap) || String.IsNullOrEmpty(item.JohapGubun) || String.IsNullOrEmpty(item.Gaein))
                    {
                        return false;
                    }
                } 
            }
            return true;
        }

        private List<BAS0111U00GrdBas0111ItemInfo> createGrdListItemInfo()
        {
            List<BAS0111U00GrdBas0111ItemInfo> grdListItemInfo = new List<BAS0111U00GrdBas0111ItemInfo>();
            for (int i = 0; i < grdBAS0111.RowCount; i++)
            {
                if (grdBAS0111.GetRowState(i) == DataRowState.Added || grdBAS0111.GetRowState(i) == DataRowState.Modified)
                {
                    BAS0111U00GrdBas0111ItemInfo info = new BAS0111U00GrdBas0111ItemInfo();
                    //info.JohapGubun = grdBAS0111.GetItemString(i, "johap_gubun");
                    info.JohapGubun = grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "johap_gubun");
                    //info.Johap = grdBAS0111.GetItemString(i, "johap");
                    info.Johap = grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "johap");
                    info.Gaein = grdBAS0111.GetItemString(i, "gaein");
                    info.UseYn = grdBAS0111.GetItemString(i, "user_yn");
                    info.ZipCode1 = grdBAS0111.GetItemString(i, "zip_code1");
                    info.ZipCode2 = grdBAS0111.GetItemString(i, "zip_code2");
                    info.Address = grdBAS0111.GetItemString(i, "address");
                    info.Address1 = grdBAS0111.GetItemString(i, "address1");
                    info.Name = grdBAS0111.GetItemString(i, "gaein_name");
                    info.ContKey = "";
                    info.RowState = grdBAS0111.GetRowState(i).ToString();

                    grdListItemInfo.Add(info);
                }
            }
            if (grdBAS0111.DeletedRowTable != null && grdBAS0111.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdBAS0111.DeletedRowTable.Rows)
                {
                    BAS0111U00GrdBas0111ItemInfo info = new BAS0111U00GrdBas0111ItemInfo();
                    //info.JohapGubun = row["johap_gubun"].ToString();
                    info.JohapGubun = grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "johap_gubun");
                    //info.Johap = grdBAS0111.GetItemString(i, "johap");
                    info.Johap = grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "johap");
                    info.Gaein = row["gaein"].ToString();
                    info.UseYn = row["user_yn"].ToString();
                    info.ZipCode1 = row["zip_code1"].ToString();
                    info.ZipCode2 = row["zip_code2"].ToString();
                    info.Address = row["address"].ToString();
                    info.Address1 = row["address1"].ToString();
                    info.Name = row["gaein_name"].ToString();
                    info.ContKey = "";
                    info.RowState = DataRowState.Deleted.ToString();

                    grdListItemInfo.Add(info);
                }
            }
            return grdListItemInfo;
        }

        #endregion

    }
}

