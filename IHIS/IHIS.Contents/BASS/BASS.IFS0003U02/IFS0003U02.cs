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
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
#endregion

namespace IHIS.BASS
{
    /// <summary>
    /// IFS0003U02에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class IFS0003U02 : IHIS.Framework.XScreen
    {
        #region Auto generated code
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XButtonList btnList;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XLabel xLabel1;
        private XEditGrid grdIFS0003;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XGridHeader xGridHeader1;
        private XGridHeader xGridHeader2;
        private XDatePicker xDateMapGubunYmd;
        private XDisplayBox dbxSearchGubunName;
        private XLabel xLabel18;
        private XFindBox fbxSearchGubun;
        private SingleLayout layCommon;
        private SingleLayout layDupCheck;
        private SingleLayoutItem singleLayoutItem1;
        private XFindWorker fwkCommon;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private XFindWorker fwkCode;
        private FindColumnInfo findColumnInfo5;
        private FindColumnInfo findColumnInfo6;

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IFS0003U02));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdIFS0003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.fwkCode = new IHIS.Framework.XFindWorker();
            this.findColumnInfo5 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo6 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.dbxSearchGubunName = new IHIS.Framework.XDisplayBox();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.fbxSearchGubun = new IHIS.Framework.XFindBox();
            this.xDateMapGubunYmd = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.layDupCheck = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIFS0003)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.splitter1);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.xPanel2);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel5
            // 
            this.xPanel5.AccessibleDescription = null;
            this.xPanel5.AccessibleName = null;
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.BackgroundImage = null;
            this.xPanel5.Controls.Add(this.grdIFS0003);
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Font = null;
            this.xPanel5.Name = "xPanel5";
            // 
            // grdIFS0003
            // 
            this.grdIFS0003.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdIFS0003, "grdIFS0003");
            this.grdIFS0003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12});
            this.grdIFS0003.ColPerLine = 9;
            this.grdIFS0003.Cols = 10;
            this.grdIFS0003.ExecuteQuery = null;
            this.grdIFS0003.FixedCols = 1;
            this.grdIFS0003.FixedRows = 2;
            this.grdIFS0003.HeaderHeights.Add(19);
            this.grdIFS0003.HeaderHeights.Add(25);
            this.grdIFS0003.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2});
            this.grdIFS0003.Name = "grdIFS0003";
            this.grdIFS0003.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdIFS0003.ParamList")));
            this.grdIFS0003.QuerySQL = resources.GetString("grdIFS0003.QuerySQL");
            this.grdIFS0003.RowHeaderVisible = true;
            this.grdIFS0003.Rows = 3;
            this.grdIFS0003.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdIFS0003_GridColumnChanged);
            this.grdIFS0003.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdIFS0003_GridFindClick);
            this.grdIFS0003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdIFS0003_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "map_gubun";
            this.xEditGridCell3.CellWidth = 167;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.RowSpan = 2;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "map_gubun_ymd";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 90;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsNotNull = true;
            this.xEditGridCell4.RowSpan = 2;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 30;
            this.xEditGridCell5.CellName = "ocs_code";
            this.xEditGridCell5.CellWidth = 83;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.FindWorker = this.fwkCode;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsNotNull = true;
            this.xEditGridCell5.Row = 1;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkCode
            // 
            this.fwkCode.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo5,
            this.findColumnInfo6});
            this.fwkCode.ExecuteQuery = null;
            this.fwkCode.FormText = "OCSコード参照";
            this.fwkCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCode.ParamList")));
            this.fwkCode.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkCode.ServerFilter = true;
            // 
            // findColumnInfo5
            // 
            this.findColumnInfo5.ColName = "code";
            this.findColumnInfo5.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo5, "findColumnInfo5");
            // 
            // findColumnInfo6
            // 
            this.findColumnInfo6.ColName = "code_name";
            this.findColumnInfo6.ColWidth = 140;
            this.findColumnInfo6.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo6, "findColumnInfo6");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 80;
            this.xEditGridCell6.CellName = "ocs_code_name";
            this.xEditGridCell6.CellWidth = 193;
            this.xEditGridCell6.Col = 4;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.Row = 1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 1;
            this.xEditGridCell8.CellName = "ocs_default_yn";
            this.xEditGridCell8.CellWidth = 30;
            this.xEditGridCell8.Col = 5;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.Row = 1;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 30;
            this.xEditGridCell9.CellName = "if_code";
            this.xEditGridCell9.CellWidth = 89;
            this.xEditGridCell9.Col = 6;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsNotNull = true;
            this.xEditGridCell9.Row = 1;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkCommon.ExecuteQuery = null;
            this.fwkCommon.FormText = "ORCAコード照会";
            this.fwkCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCommon.ParamList")));
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkCommon.ServerFilter = true;
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "code";
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "code_name";
            this.findColumnInfo4.ColWidth = 140;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 80;
            this.xEditGridCell10.CellName = "if_code_name";
            this.xEditGridCell10.CellWidth = 191;
            this.xEditGridCell10.Col = 7;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.Row = 1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellLen = 1;
            this.xEditGridCell11.CellName = "if_default_yn";
            this.xEditGridCell11.CellWidth = 28;
            this.xEditGridCell11.Col = 8;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.Row = 1;
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellLen = 4000;
            this.xEditGridCell12.CellName = "remark";
            this.xEditGridCell12.CellWidth = 46;
            this.xEditGridCell12.Col = 9;
            this.xEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.RowSpan = 2;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 3;
            this.xGridHeader1.ColSpan = 3;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 83;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 6;
            this.xGridHeader2.ColSpan = 3;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 89;
            // 
            // splitter1
            // 
            this.splitter1.AccessibleDescription = null;
            this.splitter1.AccessibleName = null;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackgroundImage = null;
            this.splitter1.Font = null;
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.dbxSearchGubunName);
            this.xPanel2.Controls.Add(this.xLabel18);
            this.xPanel2.Controls.Add(this.fbxSearchGubun);
            this.xPanel2.Controls.Add(this.xDateMapGubunYmd);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // dbxSearchGubunName
            // 
            this.dbxSearchGubunName.AccessibleDescription = null;
            this.dbxSearchGubunName.AccessibleName = null;
            resources.ApplyResources(this.dbxSearchGubunName, "dbxSearchGubunName");
            this.dbxSearchGubunName.Image = null;
            this.dbxSearchGubunName.Name = "dbxSearchGubunName";
            // 
            // xLabel18
            // 
            this.xLabel18.AccessibleDescription = null;
            this.xLabel18.AccessibleName = null;
            resources.ApplyResources(this.xLabel18, "xLabel18");
            this.xLabel18.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel18.EdgeRounding = false;
            this.xLabel18.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel18.Image = null;
            this.xLabel18.Name = "xLabel18";
            // 
            // fbxSearchGubun
            // 
            this.fbxSearchGubun.AccessibleDescription = null;
            this.fbxSearchGubun.AccessibleName = null;
            resources.ApplyResources(this.fbxSearchGubun, "fbxSearchGubun");
            this.fbxSearchGubun.BackgroundImage = null;
            this.fbxSearchGubun.FindWorker = this.fwkCommon;
            this.fbxSearchGubun.Name = "fbxSearchGubun";
            this.fbxSearchGubun.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSearchGubun_DataValidating);
            this.fbxSearchGubun.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxSearchGubun_FindClick);
            // 
            // xDateMapGubunYmd
            // 
            this.xDateMapGubunYmd.AccessibleDescription = null;
            this.xDateMapGubunYmd.AccessibleName = null;
            resources.ApplyResources(this.xDateMapGubunYmd, "xDateMapGubunYmd");
            this.xDateMapGubunYmd.BackgroundImage = null;
            this.xDateMapGubunYmd.Name = "xDateMapGubunYmd";
            this.xDateMapGubunYmd.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.xDateMapGubunYmd_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            // 
            // layDupCheck
            // 
            this.layDupCheck.ExecuteQuery = null;
            this.layDupCheck.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layDupCheck.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupCheck.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "dup_yn";
            // 
            // IFS0003U02
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel1);
            this.Name = "IFS0003U02";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.IFS0003U02_Closing);
            this.Load += new System.EventHandler(this.IFS0003U02_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdIFS0003)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        #endregion

        #region Fields
        string mMsg = "";
        string mCap = "";
        string mCheck = "";
        bool boolSave = true;
        #endregion

        #region Constructor
        /// <summary>
        /// IFS0003U02
        /// </summary>
        public IFS0003U02()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            // updated by Cloud
            InitializeCloud();
        }
        #endregion

        #region Events

        private void IFS0003U02_Load(object sender, EventArgs e)
        {
            //this.grdIFS0003.SavePerformer = new XSavePeformer(this);

            this.xDateMapGubunYmd.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.grdIFS0003.QueryLayout(false);
        }

        private void fbxSearchGubun_FindClick(object sender, CancelEventArgs e)
        {
            XFindBox control = (XFindBox)sender;

            switch (control.Name)
            {
                case "fbxSearchGubun":
                    this.fwkCommon.FormText = "MAP区分照会";
                    this.fwkCommon.ColInfos[0].HeaderText = "区分コード";
                    this.fwkCommon.ColInfos[0].ColWidth = 200;
                    this.fwkCommon.ColInfos[1].HeaderText = "区分名";
                    this.fwkCommon.ColInfos[1].ColWidth = 250;

                    this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkCommon.SetBindVarValue("f_code_type", "MAP_GUBUN_SKJ");
                    break;
            }
        }

        private void fbxSearchGubun_DataValidating(object sender, DataValidatingEventArgs e)
        {
            XFindBox control = (XFindBox)sender;
            SingleLayoutItem sli = new SingleLayoutItem();

            this.layCommon.LayoutItems.Clear();

            switch (control.Name)
            {
                case "fbxSearchGubun":
//                    this.layCommon.QuerySQL = @"SELECT A.CODE_NAME
//                                              FROM IFS0002 A
//                                             WHERE A.HOSP_CODE   = :f_hosp_code 
//                                               AND A.CODE_TYPE   = :f_code_type
//                                               AND A.CODE        = :f_code ";
                    sli.DataName = "gubun_name";
                    sli.BindControl = this.dbxSearchGubunName;
                    this.layCommon.LayoutItems.Add(sli);

                    this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layCommon.SetBindVarValue("f_code", fbxSearchGubun.GetDataValue());
                    this.layCommon.SetBindVarValue("f_code_type", "MAP_GUBUN_SKJ");
                    this.layCommon.ExecuteQuery = GetLayCommon;
                    this.layCommon.QueryLayout();
                    this.grdIFS0003.QueryLayout(false);
                    break;
            }
        }

        private void xDateMapGubunYmd_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue != "")
            {
                this.grdIFS0003.QueryLayout(false);
            }
        }

        private void grdIFS0003_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.grdIFS0003.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdIFS0003.SetBindVarValue("f_map_gubun", this.fbxSearchGubun.GetDataValue());
            this.grdIFS0003.SetBindVarValue("f_map_gubun_ymd", this.xDateMapGubunYmd.GetDataValue());

        }

        private void grdIFS0003_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            if (e.ColName == "if_code")
            {
                string map_gubun = this.grdIFS0003.GetItemString(e.RowNumber, "map_gubun");

                this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.fwkCommon.SetBindVarValue("f_code_type", map_gubun);
                this.fwkCommon.FormText = "IFコード照会";
                this.fwkCommon.ColInfos[0].HeaderText = "コード";
                this.fwkCommon.ColInfos[1].HeaderText = "コード名";
            }

            if (e.ColName == "ocs_code")
            {
                string map_gubun = this.grdIFS0003.GetItemString(e.RowNumber, "map_gubun");

                //string InputSQL = "";
                //InputSQL = @"  SELECT A.CODE         AS CODE     " +
                //            "        , A.CODE_NAME    AS NAME    " +
                //            "     FROM " + "VW_IFS_" + map_gubun + " A " +
                //            "    WHERE A.HOSP_CODE    = :f_hosp_code ";

                //this.fwkCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

                //this.fwkCode.InputSQL = InputSQL;

                // updated by Cloud
                fwkCode.ParamList = new List<string>(new string[] { "f_map_gubun" });
                fwkCode.SetBindVarValue("f_map_gubun", map_gubun);
                fwkCode.ExecuteQuery = GetFwkCode;
            }
        }

        private void grdIFS0003_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            switch (e.ColName)
            {
                case "ocs_code":
                    #region deleted by Cloud
//                    SingleLayout ocsCommon = new SingleLayout();
//                    ocsCommon.QuerySQL = @"SELECT  PKG_IFS_BAS.FN_LOAD_OCS_CODE_NAME(:f_hosp_code, :f_map_gubun, :f_code ) OCS_CODE_NAME
//                                              FROM DUAL ";

//                    ocsCommon.LayoutItems.Add("ocs_code_name");
//                    ocsCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//                    ocsCommon.SetBindVarValue("f_map_gubun", this.fbxSearchGubun.GetDataValue());
//                    ocsCommon.SetBindVarValue("f_code", this.grdIFS0003.GetItemString(e.RowNumber, "ocs_code"));

//                    if (ocsCommon.QueryLayout())
//                    {
//                        if (ocsCommon.GetItemValue("ocs_code_name").ToString() != "")
//                        {
//                            this.grdIFS0003.SetItemValue(e.RowNumber, "ocs_code_name", ocsCommon.GetItemValue("ocs_code_name").ToString());
//                        }
//                        else
//                        {
//                            this.grdIFS0003.SetItemValue(e.RowNumber, "ocs_code", "");
//                            this.grdIFS0003.SetItemValue(e.RowNumber, "ocs_code_name", "");
//                        }
//                    }
//                    else
//                    {
//                        this.grdIFS0003.SetItemValue(e.RowNumber, "ocs_code", "");
//                        this.grdIFS0003.SetItemValue(e.RowNumber, "ocs_code_name", "");
//                    }
                    #endregion

                    // updated by Cloud
                    IFS0003U01GrdIFS0003GridColumnChangedArgs args = new IFS0003U01GrdIFS0003GridColumnChangedArgs();
                    args.Code = this.grdIFS0003.GetItemString(e.RowNumber, "ocs_code");
                    args.ColName = e.ColName;
                    args.MapGubun = this.fbxSearchGubun.GetDataValue();
                    IFS0003U01StringResult res = CloudService.Instance.Submit<IFS0003U01StringResult, IFS0003U01GrdIFS0003GridColumnChangedArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success)
                    {
                        if (res.StrRes != "")
                        {
                            this.grdIFS0003.SetItemValue(e.RowNumber, "ocs_code_name", res.StrRes);
                        }
                        else
                        {
                            this.grdIFS0003.SetItemValue(e.RowNumber, "ocs_code", "");
                            this.grdIFS0003.SetItemValue(e.RowNumber, "ocs_code_name", "");
                        }
                    }
                    else
                    {
                        this.grdIFS0003.SetItemValue(e.RowNumber, "ocs_code", "");
                        this.grdIFS0003.SetItemValue(e.RowNumber, "ocs_code_name", "");
                    }

                    break;

                case "if_code":

                    #region deleted by Cloud
                    //SingleLayout layCommon = new SingleLayout();
                    //layCommon.QuerySQL = @"SELECT  PKG_IFS_BAS.FN_LOAD_IF_CODE_NAME(:f_hosp_code, :f_map_gubun, :f_code ) IF_CODE_NAME FROM DUAL ";

                    //layCommon.LayoutItems.Add("if_code_name");
                    //layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    //layCommon.SetBindVarValue("f_map_gubun", this.fbxSearchGubun.GetDataValue());
                    //layCommon.SetBindVarValue("f_code", this.grdIFS0003.GetItemString(e.RowNumber, "if_code"));

                    //if (layCommon.QueryLayout())
                    //{
                    //    this.grdIFS0003.SetItemValue(e.RowNumber, "if_code_name", layCommon.GetItemValue("if_code_name").ToString());
                    //}
                    //else
                    //{
                    //    this.grdIFS0003.SetItemValue(e.RowNumber, "if_code", "");
                    //    this.grdIFS0003.SetItemValue(e.RowNumber, "if_code_name", "");
                    //}
                    #endregion

                    // updated by Cloud
                    IFS0003U01GrdIFS0003GridColumnChangedArgs argsIf = new IFS0003U01GrdIFS0003GridColumnChangedArgs();
                    argsIf.Code = this.grdIFS0003.GetItemString(e.RowNumber, "if_code");
                    argsIf.ColName = e.ColName;
                    argsIf.MapGubun = this.fbxSearchGubun.GetDataValue();
                    IFS0003U01StringResult resIf = CloudService.Instance.Submit<IFS0003U01StringResult, IFS0003U01GrdIFS0003GridColumnChangedArgs>(argsIf);

                    if (resIf.ExecutionStatus == ExecutionStatus.Success)
                    {
                        this.grdIFS0003.SetItemValue(e.RowNumber, "if_code_name", resIf.StrRes);
                    }
                    else
                    {
                        this.grdIFS0003.SetItemValue(e.RowNumber, "if_code", "");
                        this.grdIFS0003.SetItemValue(e.RowNumber, "if_code_name", "");
                    }

                    break;
            }
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            this.boolSave = true;

            switch (e.Func)
            {
                case FunctionType.Update:

                    e.IsBaseCall = false;

                    #region deleted by Cloud
                    //if (this.grdIFS0003.SaveLayout())
                    //{
                    //    this.mMsg = NetInfo.Language == LangMode.Ko ? "저장이 완료되었습니다." : "保存が完了しました。";

                    //    this.mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : "保存完了";

                    //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //    this.grdIFS0003.QueryLayout(false);
                    //}
                    //else
                    //{
                    //    this.boolSave = false;
                    //    this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗";
                    //    if (Service.ErrFullMsg == "")
                    //    {
                    //        string mesg = NetInfo.Language == LangMode.Ko ? "를 입력하여주십시요." : "を入力してください。";
                    //        this.mMsg = this.mCheck + mesg;

                    //        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //    else
                    //    {
                    //        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : "保存に失敗しました。";
                    //        this.mMsg += "\r\n" + Service.ErrFullMsg;
                    //        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //}
                    #endregion

                    // updated by Cloud
                    IFS0003U01SaveLayoutArgs args = new IFS0003U01SaveLayoutArgs();
                    args.UserId = UserInfo.UserID;
                    args.GrdIfsItem = GetListDataForSaveLayout();
                    // No change?
                    if (args.GrdIfsItem.Count == 0) return;
                    IFS0003U01SaveLayoutResult res = CloudService.Instance.Submit<IFS0003U01SaveLayoutResult, IFS0003U01SaveLayoutArgs>(args);

                    if (!TypeCheck.IsNull(res.MapGubun + res.MapGubunYmd))
                    {
                        XMessageBox.Show(Properties.Resources.MSG1 + res.MapGubun + Properties.Resources.MSG2 + res.MapGubunYmd + Properties.Resources.MSG3
                                         , Properties.Resources.MSGCAP1, MessageBoxIcon.Warning);
                        return;
                    }

                    if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
                    {
                        this.mMsg = Properties.Resources.MSG4;
                        this.mCap = Properties.Resources.MSGCAP4;
                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.grdIFS0003.QueryLayout(false);
                    }
                    else
                    {
                        this.boolSave = false;
                        this.mCap = Properties.Resources.MSGCAP5;
                        if (Service.ErrFullMsg == "")
                        {
                            string mesg = Properties.Resources.MSG5;
                            this.mMsg = this.mCheck + mesg;

                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            this.mMsg = Properties.Resources.MSG6;
                            this.mMsg += "\r\n" + Service.ErrFullMsg;
                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    break;

                case FunctionType.Insert:

                    e.IsBaseCall = false;

                    int rowNum = this.grdIFS0003.InsertRow();

                    this.grdIFS0003.SetItemValue(rowNum, "map_gubun_ymd", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                    if (!TypeCheck.IsNull(this.fbxSearchGubun.GetDataValue()))
                    {
                        int cntNumber = this.grdIFS0003.CurrentRowNumber - 1;
                        this.grdIFS0003.SetItemValue(rowNum, "map_gubun", this.fbxSearchGubun.GetDataValue());
                    }

                    break;

                default:
                    break;
            }
        }

        private void IFS0003U02_Closing(object sender, CancelEventArgs e)
        {
            if (this.boolSave == false)
            {
                e.Cancel = true;
            }
        }

        #endregion

        // deleted by Cloud
        #region [ XSavePeformer ]
        //public class XSavePeformer : ISavePerformer
        //{
        //    IFS0003U02 parent = null;

        //    public XSavePeformer(IFS0003U02 parent)
        //    {
        //        this.parent = parent;
        //    }

        //    private int Validateion_Check(BindVarCollection BindVarList)
        //    {
        //        int value = 0;
        //        string messg = "";
        //        if (BindVarList["f_map_gubun"].VarValue == "")
        //        {
        //            messg += NetInfo.Language == LangMode.Ko ? "구분코드" : "区分コード";
        //            value = 1;
        //        }
        //        if (BindVarList["f_ocs_code"].VarValue == "")
        //        {
        //            if (value == 1)
        //            {
        //                messg += ",";
        //            }
        //            messg += NetInfo.Language == LangMode.Ko ? "OCS코드" : "OCSコード";
        //            value = 2;
        //        }
        //        if (BindVarList["f_ocs_default_yn"].VarValue == "")
        //        {
        //            if (value > 1)
        //            {
        //                messg += ",";
        //            }
        //            messg += NetInfo.Language == LangMode.Ko ? "OCS_YN" : "OCS_YN";
        //            value = 3;
        //        }
        //        if (BindVarList["f_if_code"].VarValue == "")
        //        {
        //            if (value > 1)
        //            {
        //                messg += ",";
        //            }
        //            messg += NetInfo.Language == LangMode.Ko ? "IF코드" : "IFコード";
        //            value = 4;
        //        }
        //        if (BindVarList["f_if_default_yn"].VarValue == "")
        //        {
        //            if (value > 1)
        //            {
        //                messg += ",";
        //            }
        //            messg += NetInfo.Language == LangMode.Ko ? "IF_YN" : "IF_YN";
        //            value = 5;
        //        }
        //        if (BindVarList["f_map_gubun_ymd"].VarValue == "")
        //        {
        //            if (value > 1)
        //            {
        //                messg += ",";
        //            }
        //            messg += NetInfo.Language == LangMode.Ko ? "적용일자" : "適用日付";
        //            value = 6;
        //        }
        //        if (BindVarList["f_remark"].VarValue == "")
        //        {
        //            if (value > 1)
        //            {
        //                messg += ",";
        //            }
        //            messg += NetInfo.Language == LangMode.Ko ? "비고" : "備考";
        //            value = 7;
        //        }
        //        parent.mCheck = messg;
        //        return value;
        //    }            

//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";
//                object t_dup_check = "";

//                item.BindVarList.Add("f_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

//                switch (callerID)
//                {
//                    case '1':

//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:
                                
//                                //if (Validateion_Check(item.BindVarList) != 0)
//                                //{
//                                //    return false;
//                                //}

//                                cmdText = @"SELECT 'Y' 
//                                                  FROM DUAL
//                                                 WHERE EXISTS ( SELECT 'X'
//                                                                  FROM IFS0003
//                                                                 WHERE HOSP_CODE      = :f_hosp_code
//                                                                   AND MAP_GUBUN      = :f_map_gubun
//                                                                   AND OCS_CODE       = :f_ocs_code
//                                                                   AND MAP_GUBUN_YMD  = :f_map_gubun_ymd) ";

//                                t_dup_check = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                if (!TypeCheck.IsNull(t_dup_check))
//                                {
//                                    if (t_dup_check.ToString() == "Y")
//                                    {
//                                        XMessageBox.Show("MAP区分コード:「" + item.BindVarList["f_map_gubun"].VarValue + "」" +
//                                                         "適用日付:「" + item.BindVarList["f_map_gubun_ymd"].VarValue + "」\r\n" +
//                                                         "は既に登録されています。", "注意", MessageBoxIcon.Warning);
//                                        return false;
//                                    }
//                                }

//                                cmdText = @"UPDATE IFS0003 A
//                                            SET A.UPD_ID            = :f_user_id
//                                              , A.UPD_DATE          = SYSDATE
//                                              , A.REMARK            = :f_remark
//                                          WHERE A.HOSP_CODE         = :f_hosp_code
//                                            AND A.MAP_GUBUN         = :f_map_gubun
//                                            AND A.MAP_GUBUN_YMD     = :f_map_gubun_ymd
//                                            AND A.OCS_CODE          = :f_ocs_code";
//                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

//                                cmdText = @"INSERT INTO IFS0003 (
//                                                            SYS_DATE,       SYS_ID,             UPD_DATE,           UPD_ID,
//                                                            HOSP_CODE,      MAP_GUBUN,          MAP_GUBUN_YMD,
//                                                            OCS_CODE,       OCS_DEFAULT_YN,     IF_CODE,            IF_DEFAULT_YN,
//                                                            REMARK
//                                                ) VALUES (
//                                                            SYSDATE,        :f_user_id,         sysdate,            NULL,
//                                                            :f_hosp_code,   :f_map_gubun,       :f_map_gubun_ymd,
//                                                            :f_ocs_code,    :f_ocs_default_yn,  :f_if_code,         :f_if_default_yn,
//                                                            :f_remark )";

//                                break;
//                            case DataRowState.Modified:

//                                //if (Validateion_Check(item.BindVarList) != 0)
//                                //{
//                                //    return false;
//                                //}
//                                cmdText = @"UPDATE IFS0003 A
//                                            SET A.UPD_ID            = :f_user_id
//                                              , A.UPD_DATE          = SYSDATE
//                                              , MAP_GUBUN_YMD       = :f_map_gubun_ymd
//                                              , OCS_CODE            = :f_ocs_code
//                                              , OCS_DEFAULT_YN      = :f_ocs_default_yn
//                                              , IF_CODE             = :f_if_code
//                                              , IF_DEFAULT_YN       = :f_if_default_yn
//                                              , A.REMARK            = :f_remark
//                                          WHERE A.HOSP_CODE         = :f_hosp_code
//                                            AND A.MAP_GUBUN         = :f_map_gubun
//                                            AND A.MAP_GUBUN_YMD     = :f_map_gubun_ymd
//                                            AND A.OCS_CODE          = :f_ocs_code";
//                                break;

//                            case DataRowState.Deleted:

//                                cmdText = @"DELETE
//                                           FROM IFS0003 A
//                                          WHERE A.HOSP_CODE         = :f_hosp_code
//                                            AND A.MAP_GUBUN         = :f_map_gubun
//                                            AND A.MAP_GUBUN_YMD     = :f_map_gubun_ymd
//                                            AND A.OCS_CODE          = :f_ocs_code
//                                            AND A.IF_CODE           = :f_if_code";
//                                break;
//                        }
//                        break;
//                }
//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion

        #region Cloud updated code

        #region InitializeCloud
        /// <summary>
        /// InitializeCloud
        /// </summary>
        private void InitializeCloud()
        {
            // fwkCommon
            fwkCommon.ParamList = new List<string>(new string[] { "f_code_type", "f_find1" });
            fwkCommon.ExecuteQuery = GetFwkCommon;

            // grdIFS0003
            grdIFS0003.ParamList = new List<string>(new string[] { "f_map_gubun", "f_map_gubun_ymd" });
            grdIFS0003.ExecuteQuery = GetGrdIFS0003;

            // layCommon
            layCommon.ParamList = new List<string>(new string[] { "f_code", "f_code_type" });
        }
        #endregion

        #region GetFwkCommon
        /// <summary>
        /// GetFwkCommon
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetFwkCommon(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            IFS0003U01FwkCommonArgs args = new IFS0003U01FwkCommonArgs();
            args.CodeType = bvc["f_code_type"].VarValue;
            args.Find1 = bvc["f_find1"].VarValue;
            ComboResult res = CloudService.Instance.Submit<ComboResult, IFS0003U01FwkCommonArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdIFS0003
        /// <summary>
        /// GetGrdIFS0003
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdIFS0003(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            IFS0003U01GrdIFS0003Args args = new IFS0003U01GrdIFS0003Args();
            args.MapGubun = bvc["f_map_gubun"].VarValue;
            args.MapGubunYmd = bvc["f_map_gubun_ymd"].VarValue;
            IFS0003U01GrdIFS0003Result res = CloudService.Instance.Submit<IFS0003U01GrdIFS0003Result, IFS0003U01GrdIFS0003Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdIfsItem.ForEach(delegate(IFS0003U01GrdIFS0003Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.MapGubun,
                        item.MapGubunYmd,
                        item.OcsCode,
                        item.OcsCodeName,
                        item.OcsDefaultYn,
                        item.IfCode,
                        item.IfCodeName,
                        item.IfDefaultYn,
                        item.Remark,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayCommon
        /// <summary>
        /// GetLayCommon
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayCommon(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            IFS0003U01FbxSearchGubunDataValidatingArgs args = new IFS0003U01FbxSearchGubunDataValidatingArgs();
            args.Code = bvc["f_code"].VarValue;
            args.CodeType = bvc["f_code_type"].VarValue;
            IFS0003U01StringResult res = CloudService.Instance.Submit<IFS0003U01StringResult, IFS0003U01FbxSearchGubunDataValidatingArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                lObj.Add(new object[] { res.StrRes });
            }

            return lObj;
        }
        #endregion

        #region GetFwkCode
        /// <summary>
        /// GetFwkCode
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetFwkCode(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            IFS0003U01GrdIFS0003GridFindClickArgs args = new IFS0003U01GrdIFS0003GridFindClickArgs();
            args.MapGubun = bvc["f_map_gubun"].VarValue;
            ComboResult res = CloudService.Instance.Submit<ComboResult, IFS0003U01GrdIFS0003GridFindClickArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }
        #endregion

        #region GetListDataForSaveLayout
        /// <summary>
        /// GetListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<IFS0003U01GrdIFS0003Info> GetListDataForSaveLayout()
        {
            List<IFS0003U01GrdIFS0003Info> lstData = new List<IFS0003U01GrdIFS0003Info>();

            // For insert/update
            for (int i = 0; i < grdIFS0003.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdIFS0003.GetRowState(i) == DataRowState.Unchanged) continue;

                IFS0003U01GrdIFS0003Info item   = new IFS0003U01GrdIFS0003Info();
                item.IfCode                     = grdIFS0003.GetItemString(i, "if_code");
                item.IfCodeName                 = grdIFS0003.GetItemString(i, "if_code_name");
                item.IfDefaultYn                = grdIFS0003.GetItemString(i, "if_default_yn");
                item.MapGubun                   = grdIFS0003.GetItemString(i, "map_gubun");
                item.MapGubunYmd                = grdIFS0003.GetItemString(i, "map_gubun_ymd");
                item.OcsCode                    = grdIFS0003.GetItemString(i, "ocs_code");
                item.OcsCodeName                = grdIFS0003.GetItemString(i, "ocs_code_name");
                item.OcsDefaultYn               = grdIFS0003.GetItemString(i, "ocs_default_yn");
                item.Remark                     = grdIFS0003.GetItemString(i, "remark");
                item.RowState                   = grdIFS0003.GetRowState(i).ToString();

                lstData.Add(item);
            }

            // For delete
            if (null != grdIFS0003.DeletedRowTable)
            {
                foreach (DataRow dr in grdIFS0003.DeletedRowTable.Rows)
                {
                    IFS0003U01GrdIFS0003Info item   = new IFS0003U01GrdIFS0003Info();
                    item.IfCode                     = dr["if_code"].ToString();
                    item.MapGubun                   = dr["map_gubun"].ToString();
                    item.MapGubunYmd                = dr["map_gubun_ymd"].ToString();
                    item.OcsCode                    = dr["ocs_code"].ToString();
                    item.RowState                   = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #endregion
    }
}