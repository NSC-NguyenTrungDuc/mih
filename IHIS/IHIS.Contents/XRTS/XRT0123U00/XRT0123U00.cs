#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Xrts;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results.Xrts;
using IHIS.Framework;
using IHIS.XRTS.Properties;

#endregion

namespace IHIS.XRTS
{
    /// <summary>
    /// XRT0101U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class XRT0123U00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XMstGrid grdMcode;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XEditGrid grdDcode;
        private IHIS.Framework.SingleLayout layDupD;
        private IHIS.Framework.XButtonList btnList;
        private System.Windows.Forms.ToolTip toolTip;
        private SingleLayoutItem singleLayoutItem2;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XPanel xPanel1;
        private XPanel xPanel2;
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
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XGridHeader xGridHeader1;
        private XDisplayBox dbxBuwiName;
        private XFindBox fbxBuwiCode;
        private XLabel xLabel1;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XComboItem xComboItem3;
        private XEditGridCell xEditGridCell15;
        private System.ComponentModel.IContainer components;

        public XRT0123U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            ApplyFont();
            //this.grdMcode.SavePerformer = new XSavePerformer(this);
            //this.grdDcode.SavePerformer = this.grdMcode.SavePerformer;

            this.grdMcode.ParamList = new List<string>(new String[] { "f_hosp_code", "f_xray_gubun" });
            this.grdDcode.ParamList = new List<string>(new String[] { "f_hosp_code", "f_xray_gubun", "f_buwi_code" });
            this.layDupD.ParamList = new List<string>(new String[] { "f_hosp_code", "f_xray_gubun", "f_buwi_code" });

            this.grdMcode.ExecuteQuery = LoadDataGrdMCode;
            this.grdDcode.ExecuteQuery = LoadDataGrdDCode;
            this.layDupD.ExecuteQuery = LoadDataLayDupD;
        }

        private void ApplyFont()
        {
            if (NetInfo.Language != LangMode.Jr)
            {
                ((System.ComponentModel.ISupportInitialize)(this.grdDcode)).BeginInit();
                this.xGridHeader1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                ((System.ComponentModel.ISupportInitialize)(this.grdDcode)).EndInit();
            }
        }

        private List<object[]> LoadDataLayDupD(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            XRT0123U00LayDupDArgs args = new XRT0123U00LayDupDArgs();
            args.XrayGubun = bc["f_xray_gubun"] != null ? bc["f_xray_gubun"].VarValue : "";
            args.BuwiCode = bc["f_buwi_code"] != null ? bc["f_buwi_code"].VarValue : "";
            XRT0123U00LayDupDResult result = CloudService.Instance.Submit<XRT0123U00LayDupDResult, XRT0123U00LayDupDArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.YnValue
                });
            }
            return res;
        }



        private List<object[]> LoadDataGrdDCode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            XRT0123U00GrdDCodeArgs args = new XRT0123U00GrdDCodeArgs();
            args.XrayGubun = bc["f_xray_gubun"] != null ? bc["f_xray_gubun"].VarValue : "";
            args.BuwiCode = bc["f_buwi_code"] != null ? bc["f_buwi_code"].VarValue : "";
            XRT0123U00GrdDCodeResult result = CloudService.Instance.Submit<XRT0123U00GrdDCodeResult, XRT0123U00GrdDCodeArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (XRT0123U00GrdDCodeItemInfo item in result.ListInfo)
                {
                    object[] objects = 
				{ 
					item.XrayGubun, 
					item.BuwiCode, 
					item.BuwiName, 
					item.Valtage, 
					item.CurElectric, 
					item.Time, 
					item.Distance, 
					item.Grid, 
					item.Note, 
					item.XrayGubunName, 
					item.FromAge, 
					item.ToAge, 
					item.MasVal, 
					item.ContKey, 
				};
                    res.Add(objects);
                }
            }
            return res;
        }



        private List<object[]> LoadDataGrdMCode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            XRT0123U00grdMCodeArgs args = new XRT0123U00grdMCodeArgs();
            args.XrayGubun = bc["f_xray_gubun"] != null ? bc["f_xray_gubun"].VarValue : "";
            XRT0123U00grdMCodeResult result = CloudService.Instance.Submit<XRT0123U00grdMCodeResult, XRT0123U00grdMCodeArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ListGrd)
                {
                    object[] objects = 
				    { 
					    item.Code, 
					    item.CodeName
				    };
                    res.Add(objects);
                }
            }
            return res;
        }



        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XRT0123U00));
            this.grdMcode = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grdDcode = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.layDupD = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.toolTip = new System.Windows.Forms.ToolTip();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dbxBuwiName = new IHIS.Framework.XDisplayBox();
            this.fbxBuwiCode = new IHIS.Framework.XFindBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grdMcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDcode)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // grdMcode
            // 
            resources.ApplyResources(this.grdMcode, "grdMcode");
            this.grdMcode.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdMcode.ColPerLine = 1;
            this.grdMcode.ColResizable = true;
            this.grdMcode.Cols = 2;
            this.grdMcode.ExecuteQuery = null;
            this.grdMcode.FixedCols = 1;
            this.grdMcode.FixedRows = 1;
            this.grdMcode.HeaderHeights.Add(33);
            this.grdMcode.Name = "grdMcode";
            this.grdMcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMcode.ParamList")));
            this.grdMcode.ReadOnly = true;
            this.grdMcode.RowHeaderVisible = true;
            this.grdMcode.Rows = 2;
            this.toolTip.SetToolTip(this.grdMcode, resources.GetString("grdMcode.ToolTip"));
            this.grdMcode.UseDefaultTransaction = false;
            this.grdMcode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMcode_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellName = "xray_gubun";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdCol = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellLen = 300;
            this.xEditGridCell2.CellName = "xray_gubun_name";
            this.xEditGridCell2.CellWidth = 150;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdCol = false;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.toolTip.SetToolTip(this.btnList, resources.GetString("btnList.ToolTip"));
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            this.toolTip.SetToolTip(this.splitter1, resources.GetString("splitter1.ToolTip"));
            // 
            // grdDcode
            // 
            this.grdDcode.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdDcode, "grdDcode");
            this.grdDcode.CallerID = '2';
            this.grdDcode.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell15});
            this.grdDcode.ColPerLine = 11;
            this.grdDcode.ColResizable = true;
            this.grdDcode.Cols = 12;
            this.grdDcode.ExecuteQuery = null;
            this.grdDcode.FixedCols = 1;
            this.grdDcode.FixedRows = 2;
            this.grdDcode.HeaderHeights.Add(18);
            this.grdDcode.HeaderHeights.Add(18);
            this.grdDcode.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdDcode.MasterLayout = this.grdMcode;
            this.grdDcode.Name = "grdDcode";
            this.grdDcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDcode.ParamList")));
            this.grdDcode.QuerySQL = resources.GetString("grdDcode.QuerySQL");
            this.grdDcode.RowHeaderVisible = true;
            this.grdDcode.Rows = 3;
            this.toolTip.SetToolTip(this.grdDcode, resources.GetString("grdDcode.ToolTip"));
            this.grdDcode.ToolTipActive = true;
            this.grdDcode.UseDefaultTransaction = false;
            this.grdDcode.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdDcode_GridFindClick);
            this.grdDcode.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDcode_GridColumnChanged);
            this.grdDcode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDcode_QueryStarting);
            this.grdDcode.PreEndInitializing += new System.EventHandler(this.grdDcode_PreEndInitializing);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellName = "xray_gubun";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "buwi_code";
            this.xEditGridCell4.CellWidth = 83;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsNotNull = true;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.RowSpan = 2;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellLen = 200;
            this.xEditGridCell5.CellName = "buwi_name";
            this.xEditGridCell5.CellWidth = 180;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.RowSpan = 2;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellLen = 5;
            this.xEditGridCell6.CellName = "valtage";
            this.xEditGridCell6.CellWidth = 49;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.RowSpan = 2;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellLen = 5;
            this.xEditGridCell7.CellName = "cur_electric";
            this.xEditGridCell7.CellWidth = 71;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.RowSpan = 2;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellName = "time";
            this.xEditGridCell8.CellWidth = 98;
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.RowSpan = 2;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellLen = 5;
            this.xEditGridCell9.CellName = "Span";
            this.xEditGridCell9.CellWidth = 38;
            this.xEditGridCell9.Col = 9;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.RowSpan = 2;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.CellName = "grid";
            this.xEditGridCell10.CellWidth = 37;
            this.xEditGridCell10.Col = 10;
            this.xEditGridCell10.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3});
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.RowSpan = 2;
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "+";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "-";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = global::IHIS.XRTS.Properties.Resource.xComboItem3Value;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.CellLen = 300;
            this.xEditGridCell11.CellName = "note";
            this.xEditGridCell11.CellWidth = 110;
            this.xEditGridCell11.Col = 11;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.RowSpan = 2;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.CellLen = 200;
            this.xEditGridCell12.CellName = "xray_gubun_name";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.CellLen = 3;
            this.xEditGridCell13.CellName = "from_age";
            this.xEditGridCell13.CellWidth = 35;
            this.xEditGridCell13.Col = 3;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsNotNull = true;
            this.xEditGridCell13.Mask = "###";
            this.xEditGridCell13.Maxinum = 200D;
            this.xEditGridCell13.Row = 1;
            this.xEditGridCell13.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell14.CellLen = 3;
            this.xEditGridCell14.CellName = "to_age";
            this.xEditGridCell14.CellWidth = 35;
            this.xEditGridCell14.Col = 4;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsNotNull = true;
            this.xEditGridCell14.Mask = "###";
            this.xEditGridCell14.Maxinum = 200D;
            this.xEditGridCell14.Row = 1;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell14.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell15.CellLen = 5;
            this.xEditGridCell15.CellName = "mas_val";
            this.xEditGridCell15.CellWidth = 34;
            this.xEditGridCell15.Col = 8;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell15.RowSpan = 2;
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 3;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 35;
            // 
            // layDupD
            // 
            this.layDupD.ExecuteQuery = null;
            this.layDupD.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layDupD.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupD.ParamList")));
            this.layDupD.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDupD_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "dup_yn";
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.dbxBuwiName);
            this.xPanel1.Controls.Add(this.fbxBuwiCode);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Name = "xPanel1";
            this.toolTip.SetToolTip(this.xPanel1, resources.GetString("xPanel1.ToolTip"));
            // 
            // dbxBuwiName
            // 
            resources.ApplyResources(this.dbxBuwiName, "dbxBuwiName");
            this.dbxBuwiName.Name = "dbxBuwiName";
            this.toolTip.SetToolTip(this.dbxBuwiName, resources.GetString("dbxBuwiName.ToolTip"));
            // 
            // fbxBuwiCode
            // 
            resources.ApplyResources(this.fbxBuwiCode, "fbxBuwiCode");
            this.fbxBuwiCode.Name = "fbxBuwiCode";
            this.toolTip.SetToolTip(this.fbxBuwiCode, resources.GetString("fbxBuwiCode.ToolTip"));
            this.fbxBuwiCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBuwiCode_FindClick);
            this.fbxBuwiCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBuwiCode_DataValidating);
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            this.toolTip.SetToolTip(this.xLabel1, resources.GetString("xLabel1.ToolTip"));
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.grdDcode);
            this.xPanel2.Controls.Add(this.grdMcode);
            this.xPanel2.Name = "xPanel2";
            this.toolTip.SetToolTip(this.xPanel2, resources.GetString("xPanel2.ToolTip"));
            // 
            // XRT0123U00
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "XRT0123U00";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            ((System.ComponentModel.ISupportInitialize)(this.grdMcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDcode)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            // TODO:  XRT0101U00.OnLoad 구현을 추가합니다.
            base.OnLoad(e);

            this.grdDcode.SetRelationKey("xray_gubun", "xray_gubun");
            this.grdDcode.SetRelationTable("XRT0123");

            if (!this.grdMcode.QueryLayout(false))
                XMessageBox.Show(Resource.XMessageBox3 + Service.ErrFullMsg, Resource.XMessageBoxCaption3, MessageBoxIcon.Error);
        }
        #endregion

        #region 디테일 테이블 중복체크(입력시 code)
        private void grdDcode_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            DataRowState rowState = this.grdDcode.LayoutTable.Rows[this.grdDcode.CurrentRowNumber].RowState;
            //입력 버튼이 클릭 되었을 때만 체크
            if (rowState == DataRowState.Added)
            {
                // 입력된 셀이 코드 컬럼이면,
                //if ( e.ColName == "code" )
                if (e.ColName == "buwi_code")
                {

                    this.layDupD.QueryLayout();
                    if (this.layDupD.GetItemValue("dup_yn").ToString() == "Y")
                    {
                        string msg = (NetInfo.Language == LangMode.Ko ? Resource.XMessageBox3_Ko
                            : Resource.XMessageBox3_Jp);
                        //XMessageBox.Show( this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber,"code") +
                        //    msg,Resource.XMessageBox4_caption, MessageBoxButtons.OK );

                        XMessageBox.Show(this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber, "buwi_code") +
                            msg, Resource.XMessageBox4_caption, MessageBoxButtons.OK);
                        e.Cancel = true;
                    }
                }
            }
        }
        #endregion


        #region 버튼리스트 클릭 후 이벤트
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                //초기화가 된 후 포커스 마스터 그리드로..
                case FunctionType.Reset:
                    this.CurrMQLayout = this.grdMcode;
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    if (this.CurrMQLayout == this.grdMcode)
                    {
                        //this.grdMcode.SetBindVarValue("f_code_type", "");
                        this.grdMcode.SetBindVarValue("f_xray_gubun", "");
                    }
                    else
                    {
                        //this.grdDcode.SetBindVarValue("f_code", "");
                        //this.grdDcode.SetBindVarValue("f_code_name", "");

                        this.grdDcode.SetBindVarValue("f_xray_gubun", "");
                        this.grdDcode.SetBindVarValue("f_buwi_code", "");
                    }
                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;
                    e.IsSuccess = true;

                    try
                    {
                        //Service.BeginTransaction();

                        //if (!this.grdMcode.SaveLayout())
                        //    throw new Exception();
                        //if (!this.grdDcode.SaveLayout())
                        //    throw new Exception();

                        //Service.CommitTransaction();

                        //XMessageBox.Show(Resource.xMessageBox1,Resource.xMessageBoxCaption1,MessageBoxIcon.Asterisk);

                        if (SaveGrdDCode())
                        {
                            XMessageBox.Show(Resource.xMessageBox1, Resource.xMessageBoxCaption1, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            XMessageBox.Show(Resource.xMessageBox2, Resource.xMessageBoxCaption2, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        //Service.RollbackTransaction();
                        e.IsSuccess = false;
                        XMessageBox.Show(Resource.xMessageBox2, Resource.xMessageBoxCaption2, MessageBoxIcon.Error);
                    }


                    break;

                case FunctionType.Insert:
                    e.IsBaseCall = false;

                    int rowNum = this.grdDcode.InsertRow(0);
                    if (this.grdMcode.CurrentRowNumber >= 0)
                        this.grdDcode.SetItemValue(rowNum, "xray_gubun", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "xray_gubun"));


                    break;

                default:
                    break;
            }
        }

        private bool SaveGrdDCode()
        {
            List<XRT0123U00GrdDCodeItemInfo> inputList = GetListFromGrdDCode();
            if (inputList.Count == 0)
            {
                return false;
            }
            XRT0123U00SaveLayoutArgs args = new XRT0123U00SaveLayoutArgs(UserInfo.UserID, inputList);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, XRT0123U00SaveLayoutArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }
            return false;
        }

        private List<XRT0123U00GrdDCodeItemInfo> GetListFromGrdDCode()
        {
            List<XRT0123U00GrdDCodeItemInfo> dataList = new List<XRT0123U00GrdDCodeItemInfo>();
            for (int i = 0; i < grdDcode.RowCount; i++)
            {
                if (grdDcode.GetRowState(i) == DataRowState.Unchanged || String.IsNullOrEmpty(grdDcode.GetItemString(i, "buwi_code")))
                {
                    continue;
                }
                XRT0123U00GrdDCodeItemInfo info = new XRT0123U00GrdDCodeItemInfo();
                info.XrayGubun = this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "xray_gubun");
                info.BuwiCode = grdDcode.GetItemString(i, "buwi_code");
                info.BuwiName = grdDcode.GetItemString(i, "buwi_name");
                info.Valtage = grdDcode.GetItemString(i, "valtage");
                info.CurElectric = grdDcode.GetItemString(i, "cur_electric");
                info.Time = grdDcode.GetItemString(i, "time");
                info.Distance = grdDcode.GetItemString(i, "distance");
                info.Grid = grdDcode.GetItemString(i, "grid");
                info.Note = grdDcode.GetItemString(i, "note");
                info.XrayGubunName = grdDcode.GetItemString(i, "xray_gubun_name");
                info.FromAge = grdDcode.GetItemString(i, "from_age");
                info.ToAge = grdDcode.GetItemString(i, "to_age");
                info.MasVal = grdDcode.GetItemString(i, "mas_val");

                info.RowState = grdDcode.GetRowState(i).ToString();
                if (TypeCheck.IsNull(info.BuwiCode) || TypeCheck.IsNull(info.BuwiName) || TypeCheck.IsNull(info.FromAge) || TypeCheck.IsNull(info.ToAge))
                {
                    dataList.Clear();
                    return dataList;
                }
                dataList.Add(info);
            }

            if (this.grdDcode.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdDcode.DeletedRowTable.Rows)
                {
                    if (row["buwi_code"].ToString() == "")
                    {
                        continue;
                    }
                    XRT0123U00GrdDCodeItemInfo info = new XRT0123U00GrdDCodeItemInfo();
                    info.XrayGubun = this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "xray_gubun");
                    info.BuwiCode = row["buwi_code"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();
                    dataList.Add(info);

                }
            }
            return dataList;
        }


        private void grdMcode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMcode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.grdMcode.SetBindVarValue("f_xray_gubun", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "code_type"));
            //this.grdMcode.SetBindVarValue("f_xray_gubun", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "xray_gubun"));
        }

        private void grdDcode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDcode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDcode.SetBindVarValue("f_xray_gubun", this.grdMcode.GetItemString(this.grdMcode.CurrentRowNumber, "xray_gubun"));
            this.grdDcode.SetBindVarValue("f_buwi_code", this.fbxBuwiCode.GetDataValue());
        }

        private void layDupD_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layDupD.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDupD.SetBindVarValue("f_xray_gubun", this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber, "xray_gubun"));
            this.layDupD.SetBindVarValue("f_buwi_code", this.grdDcode.GetItemString(this.grdDcode.CurrentRowNumber, "buwi_code"));
        }

        #region XSavePerformer

        //        private class XSavePerformer : ISavePerformer
        //        {
        //            XRT0123U00 parent;

        //            public XSavePerformer(XRT0123U00 parent)
        //            {
        //                this.parent = parent;
        //            }

        //            public bool Execute(char callerID, RowDataItem item)
        //            {
        //                string cmdText = "";
        //                item.BindVarList.Add("q_user_id", UserInfo.UserID);
        //                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
        //                switch(callerID)
        //                {
        //                    case '2':

        //                    switch (item.RowState)
        //                    { 
        //                        case DataRowState.Added:
        //                            cmdText = @"INSERT INTO XRT0123 (
        //                                              SYS_DATE,             SYS_ID,                  
        //                                              UPD_DATE,             UPD_ID,             HOSP_CODE,
        //                                              XRAY_GUBUN,           BUWI_CODE,          VALTAGE,     
        //                                              CUR_ELECTRIC,         TIME,               DISTANCE,    
        //                                              GRID,                 NOTE, 
        //                                              FROM_AGE,             TO_AGE,             MAS_VAL        
        //                                            ) VALUES (
        //                                              SYSDATE,              :q_user_id,               
        //                                              SYSDATE,              :q_user_id,         :f_hosp_code,  
        //                                              :f_xray_gubun,        :f_buwi_code,       :f_valtage,     
        //                                              :f_cur_electric,      :f_time,            :f_distance,    
        //                                              :f_grid,              :f_note,
        //                                              :f_from_age,          :f_to_age,          :f_mas_val      
        //                                              )";
        //                            break;

        //                        case DataRowState.Modified:
        //                            cmdText = @"DECLARE
        //                                        BEGIN
        //                                           UPDATE XRT0123
        //                                              SET UPD_ID          = :q_user_id
        //                                                , UPD_DATE        = SYSDATE
        //                                                , VALTAGE         = :f_valtage     
        //                                                , CUR_ELECTRIC    = :f_cur_electric
        //                                                , TIME            = :f_time        
        //                                                , DISTANCE        = :f_distance    
        //                                                , GRID            = :f_grid        
        //                                                , NOTE            = :f_note   
        //                                                , FROM_AGE        = :f_from_age
        //                                                , TO_AGE          = :f_to_age   
        //                                                , MAS_VAL         = :f_mas_val 
        //                                            WHERE HOSP_CODE       = :f_hosp_code
        //                                              AND XRAY_GUBUN      = :f_xray_gubun
        //                                              AND BUWI_CODE       = :f_buwi_code;
        //                                              
        //                                           IF SQL%NOTFOUND THEN
        //                                              INSERT INTO XRT0123 (                                          
        //                                                SYS_DATE,              SYS_ID,                  
        //                                                UPD_DATE,              UPD_ID,              HOSP_CODE,    
        //                                                XRAY_GUBUN,            BUWI_CODE,           VALTAGE,                                                     
        //                                                CUR_ELECTRIC,          TIME,                DISTANCE,                                                    
        //                                                GRID,                  NOTE , 
        //                                                FROM_AGE,              TO_AGE,              MAS_VAL                                                     
        //                                              ) VALUES (                                                     
        //                                                SYSDATE,               :q_user_id,               
        //                                                SYSDATE,               :q_user_id,         :f_hosp_code,
        //                                                :f_xray_gubun,         :f_buwi_code,       :f_valtage,                                                  
        //                                                :f_cur_electric,       :f_time,            :f_distance,                                                 
        //                                                :f_grid,               :f_note,
        //                                                :f_from_age,           :f_to_age,          :f_mas_val                                                       
        //                                                );                                                           
        //                                           END IF;
        //                                        END; ";

        //                            break;

        //                        case DataRowState.Deleted:
        //                            cmdText = @"DELETE XRT0123
        //                                         WHERE HOSP_CODE  = :f_hosp_code
        //                                           AND XRAY_GUBUN = :f_xray_gubun
        //                                           AND BUWI_CODE  = :f_buwi_code ";

        //                            break;
        //                    }
        //                    break;
        //                }

        //                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
        //            }
        //        }
        #endregion

        private void fbxBuwiCode_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
                dbxBuwiName.SetDataValue("");
        }

        private string mCaller = "";
        private void grdDcode_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            mCaller = "grdDcode";
            XScreen.OpenScreen(this, "XRT0122Q00", ScreenOpenStyle.ResponseFixed);
        }

        private void fbxBuwiCode_FindClick(object sender, CancelEventArgs e)
        {
            mCaller = "fbxBuwiCode";
            XScreen.OpenScreen(this, "XRT0122Q00", ScreenOpenStyle.ResponseFixed);
        }

        #region [팝업화면에서 데이터 받기]
        public override object Command(string command, CommonItemCollection commandParam)
        {
            if (command == "XRT0122Q00")
            {
                if (mCaller == "fbxBuwiCode")
                {
                    this.fbxBuwiCode.SetDataValue(commandParam["buwi_code"].ToString());
                    this.fbxBuwiCode.AcceptData();

                    this.dbxBuwiName.SetDataValue(commandParam["buwi_name"].ToString());
                    this.dbxBuwiName.AcceptData();

                    this.grdMcode.Reset();
                    this.grdDcode.QueryLayout(false);
                }
                else if (mCaller == "grdDcode")
                {
                    this.grdDcode.SetItemValue(this.grdDcode.CurrentRowNumber, "buwi_code", commandParam["buwi_code"].ToString());
                    this.grdDcode.SetItemValue(this.grdDcode.CurrentRowNumber, "buwi_name", commandParam["buwi_name"].ToString());
                    this.grdDcode.AcceptData();
                }
            }

            return base.Command(command, commandParam);
        }
        #endregion

        private void grdDcode_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell3.ExecuteQuery = LoadDataXEditGridCell3;
        }

        /// <summary>
        /// get data for xEditGridCell3
        /// </summary>
        /// <param name="varlist"></param>
        /// <returns></returns>
        private List<object[]> LoadDataXEditGridCell3(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            XRT0123U00XEditGridCell3Args args = new XRT0123U00XEditGridCell3Args();
            XRT0123U00XEditGridCell3Result result =
                CacheService.Instance.Get<XRT0123U00XEditGridCell3Args, XRT0123U00XEditGridCell3Result>(args);

            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.CboCell)
                {
                    object[] objects = 
				    { 
					    item.Code, 
					    item.CodeName
				    };
                    res.Add(objects);
                }
            }
            return res;
        }


    }
}

