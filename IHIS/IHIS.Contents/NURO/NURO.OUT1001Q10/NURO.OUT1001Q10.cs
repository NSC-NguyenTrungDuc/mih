#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.NURO.Properties;

#endregion

namespace IHIS.NURO
{
    /// <summary>
    /// OUTS.OUT1101U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OUT1001Q10 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XDictComboBox cboGwa;
        //private IHIS.Framework.DataServiceSIMO dsvQrylist;
        //private IHIS.Framework.DataServiceMISO dsvUpdate;
        private XDatePicker dtpGijunDate;
        private XLabel xLabel4;
        private Timer timer1;
        private XDisplayBox dbxSuname;
        private XFindBox fbxBunho;
        private XLabel xLabel2;
        private SingleLayout layOut0101;
        private SingleLayoutItem singleLayoutItem1;
        private XButtonList btnList;
        private XDictComboBox cboTime;
        private XCheckBox cbxAutoQuery;
        private XPanel xPanel4;
        private XPanel xPanel3;
        private XEditGrid grdList;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell5;
        private XCheckBox cbxNotice;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell16;
        private IContainer components;

        private const string CACHE_OUT1001Q10_COMBO_LIST_ITEM_KEYS = "Nuro.Out1001q10.CboListItem";

        public OUT1001Q10()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            grdList.ExecuteQuery = GetOutOrderStatusList;
            layOut0101.ExecuteQuery = GetDataForSingleLayout;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OUT1001Q10));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.fbxBunho = new IHIS.Framework.XFindBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpGijunDate = new IHIS.Framework.XDatePicker();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cboGwa = new IHIS.Framework.XDictComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.layOut0101 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.btnList = new IHIS.Framework.XButtonList();
            this.cboTime = new IHIS.Framework.XDictComboBox();
            this.cbxAutoQuery = new IHIS.Framework.XCheckBox();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.cbxNotice = new IHIS.Framework.XCheckBox();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel4.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "약품검색.ico");
            this.ImageList.Images.SetKeyName(1, "WTRS.ico");
            this.ImageList.Images.SetKeyName(2, "재진예약.gif");
            this.ImageList.Images.SetKeyName(3, "주사기_2.gif");
            this.ImageList.Images.SetKeyName(4, "검사예약.ico");
            this.ImageList.Images.SetKeyName(5, "건진운영관리.ico");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.dbxSuname);
            this.xPanel1.Controls.Add(this.fbxBunho);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dtpGijunDate);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.cboGwa);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // dbxSuname
            // 
            this.dbxSuname.AccessibleDescription = null;
            this.dbxSuname.AccessibleName = null;
            resources.ApplyResources(this.dbxSuname, "dbxSuname");
            this.dbxSuname.Image = null;
            this.dbxSuname.Name = "dbxSuname";
            // 
            // fbxBunho
            // 
            this.fbxBunho.AccessibleDescription = null;
            this.fbxBunho.AccessibleName = null;
            resources.ApplyResources(this.fbxBunho, "fbxBunho");
            this.fbxBunho.ApplyByteLimit = true;
            this.fbxBunho.BackgroundImage = null;
            this.fbxBunho.Name = "fbxBunho";
            this.fbxBunho.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBunho_DataValidating);
            this.fbxBunho.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBunho_FindClick);
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // dtpGijunDate
            // 
            this.dtpGijunDate.AccessibleDescription = null;
            this.dtpGijunDate.AccessibleName = null;
            resources.ApplyResources(this.dtpGijunDate, "dtpGijunDate");
            this.dtpGijunDate.BackgroundImage = null;
            this.dtpGijunDate.IsVietnameseYearType = false;
            this.dtpGijunDate.Name = "dtpGijunDate";
            this.dtpGijunDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpGijunDate_DataValidating);
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // cboGwa
            // 
            this.cboGwa.AccessibleDescription = null;
            this.cboGwa.AccessibleName = null;
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.BackgroundImage = null;
            this.cboGwa.ExecuteQuery = null;
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboGwa.ParamList")));
            this.cboGwa.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboGwa.SelectedIndexChanged += new System.EventHandler(this.cboGwa_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // layOut0101
            // 
            this.layOut0101.ExecuteQuery = null;
            this.layOut0101.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layOut0101.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOut0101.ParamList")));
            this.layOut0101.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layOut0101_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "bunho";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // cboTime
            // 
            this.cboTime.AccessibleDescription = null;
            this.cboTime.AccessibleName = null;
            resources.ApplyResources(this.cboTime, "cboTime");
            this.cboTime.BackgroundImage = null;
            this.cboTime.ExecuteQuery = null;
            this.cboTime.Name = "cboTime";
            this.cboTime.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTime.ParamList")));
            this.cboTime.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // cbxAutoQuery
            // 
            this.cbxAutoQuery.AccessibleDescription = null;
            this.cbxAutoQuery.AccessibleName = null;
            resources.ApplyResources(this.cbxAutoQuery, "cbxAutoQuery");
            this.cbxAutoQuery.BackgroundImage = null;
            this.cbxAutoQuery.Checked = true;
            this.cbxAutoQuery.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAutoQuery.Name = "cbxAutoQuery";
            this.cbxAutoQuery.UseVisualStyleBackColor = false;
            this.cbxAutoQuery.CheckedChanged += new System.EventHandler(this.cbxAutoQuery_CheckedChanged);
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.cbxNotice);
            this.xPanel4.Controls.Add(this.cbxAutoQuery);
            this.xPanel4.Controls.Add(this.cboTime);
            this.xPanel4.Controls.Add(this.btnList);
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // cbxNotice
            // 
            this.cbxNotice.AccessibleDescription = null;
            this.cbxNotice.AccessibleName = null;
            resources.ApplyResources(this.cbxNotice, "cbxNotice");
            this.cbxNotice.BackgroundImage = null;
            this.cbxNotice.CheckedValue = "N";
            this.cbxNotice.Name = "cbxNotice";
            this.cbxNotice.UseVisualStyleBackColor = false;
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.grdList);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // grdList
            // 
            resources.ApplyResources(this.grdList, "grdList");
            this.grdList.ApplyPaintEventToAllColumn = true;
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell10,
            this.xEditGridCell4,
            this.xEditGridCell15,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell12,
            this.xEditGridCell14,
            this.xEditGridCell13,
            this.xEditGridCell5,
            this.xEditGridCell18,
            this.xEditGridCell11,
            this.xEditGridCell16});
            this.grdList.ColPerLine = 9;
            this.grdList.Cols = 10;
            this.grdList.ExecuteQuery = null;
            this.grdList.FixedCols = 1;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(32);
            this.grdList.Name = "grdList";
            this.grdList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdList.ParamList")));
            this.grdList.QuerySQL = resources.GetString("grdList.QuerySQL");
            this.grdList.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdList.RowHeaderVisible = true;
            this.grdList.Rows = 2;
            this.grdList.ToolTipActive = true;
            this.grdList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdList_QueryEnd);
            this.grdList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdList_MouseDown);
            this.grdList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdList_GridCellPainting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "fkout1001";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "suname";
            this.xEditGridCell3.CellWidth = 190;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "jubsu_time";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell10.CellWidth = 117;
            this.xEditGridCell10.Col = 3;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.Mask = "HH:MI";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "naewon_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "reser_yn";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "gwa";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "doctor";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "gwa_name";
            this.xEditGridCell8.CellWidth = 83;
            this.xEditGridCell8.Col = 4;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "doctor_name";
            this.xEditGridCell9.CellWidth = 191;
            this.xEditGridCell9.Col = 5;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "jubsu_gubun";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "naewon_yn";
            this.xEditGridCell14.CellWidth = 107;
            this.xEditGridCell14.Col = 6;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "tot_cnt";
            this.xEditGridCell13.CellWidth = 43;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "acting_per";
            this.xEditGridCell5.CellWidth = 118;
            this.xEditGridCell5.Col = 7;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "all_end_yn";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "acting_time";
            this.xEditGridCell11.CellWidth = 120;
            this.xEditGridCell11.Col = 9;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.Mask = "##:##";
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "data_send_yn";
            this.xEditGridCell16.CellWidth = 94;
            this.xEditGridCell16.Col = 8;
            this.xEditGridCell16.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OUT1001Q10
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel4);
            this.Name = "OUT1001Q10";
            this.Load += new System.EventHandler(this.OUT0000U00_Load);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OUT0000U00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel4.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Screen 변수

        //private string mMsg = "";
        //private string mCap = "";

        XColor mSelectedBackColor = new XColor(Color.FromName("ActiveCaption"));
        XColor mSelectedForeColor = new XColor(Color.FromName("ActiveCaptionText"));

        XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));
        XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));

        #endregion

        #region XButtonList
        string mMsg = "";
        string mCap = "";
        bool mUserGrop = false;
        //private int mMaxWidth = 662;
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.DataLoad();
                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    if (this.grdList.SaveLayout())
                    {
                        e.IsSuccess = false;
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장이 완료되었습니다." : Resources.XMessageBox1;
                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : Resources.caption1;
                        //XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.SetMsg(this.mMsg, MsgType.Normal);
                        this.DataLoad();
                    }
                    else
                    {
                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : Resources.caption2;
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : Resources.XMessageBox2;
                        this.mMsg += "\r\n" + Service.ErrFullMsg;
                        this.SetMsg(this.mMsg, MsgType.Error);
                    }
                    this.Activate();
                    break;
                case FunctionType.Reset:
                    e.IsBaseCall = false;
                    break;
                //case FunctionType.Close:
                //    e.IsBaseCall = false;
                //    //this.HideDocking();
                //    break;
            }
        }

        #endregion

        private void OUT0000U00_Load(object sender, System.EventArgs e)
        {
            //if ((UserInfo.UserGubun == UserType.Normal) &&
            if ((UserInfo.UserGroup == "OUT") ||
                (UserInfo.UserGroup == "OUTA") ||
                (UserInfo.UserGroup == "INP") ||
                (UserInfo.UserGroup == "INPA"))
            {
                this.mUserGrop = true;
                this.cbxNotice.Visible = true;
            }
            else
            {
                this.grdList.ReadOnly = true;
                this.cbxNotice.Visible = false;
            }
            initializeComboListItem();
            
            if (cboTime.ComboItems.Count > 0)
            {
                cboTime.SelectedIndex = 0;
            }
            if (cboGwa.ComboItems.Count > 0)
            {
                cboGwa.SelectedIndex = 0;
            }
            
            this.dtpGijunDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            this.btnList.PerformClick(FunctionType.Query);
        }
        private void OUT0000U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // 화면 사이즈 조정
            // 화면 크기를 화면에 맞게 최대화 시킨다 
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(this.Width, rc.Height - 105);
        }

        #region [콤보박스 생성]
        private void MakeGwaCombo()
        {
//            string UserSQL = @" SELECT '%', '全体'
//                                  FROM DUAL
//                                 UNION
//                                SELECT A.GWA, A.GWA_NAME
//				                 FROM BAS0260 A
//				                WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE
//                                  AND A.BUSEO_GUBUN = '1'
//				                  AND A.START_DATE = ( SELECT MAX(Z.START_DATE)
//				                                        FROM BAS0260 Z 
//				                                       WHERE Z.HOSP_CODE  = A.HOSP_CODE
//                                                         AND Z.BUSEO_CODE = A.BUSEO_CODE 
//				                                         AND Z.START_DATE <= TRUNC(SYSDATE) ) 
//				                 ORDER BY 1  ";

            IHIS.Framework.MultiLayout layoutCombo = new MultiLayout();
            layoutCombo.ExecuteQuery = GetComboMakeGwaCombo;
            layoutCombo.Reset();
            layoutCombo.LayoutItems.Clear();
            layoutCombo.LayoutItems.Add("gwa", DataType.String);
            layoutCombo.LayoutItems.Add("gwa_name", DataType.String);
            layoutCombo.InitializeLayoutTable();
//            layoutCombo.QuerySQL = UserSQL;
            layoutCombo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            if (layoutCombo.QueryLayout(false) && layoutCombo.RowCount > 0)
            {
                this.cboGwa.SetComboItems(layoutCombo.LayoutTable, "gwa_name", "gwa");
            }

            if (this.cboGwa.ComboItems.Count > 0)
            {
                this.cboGwa.SelectedIndex = 0;
            }
        }
        #endregion

        private IList<object[]> GetComboMakeGwaCombo(BindVarCollection list)
        {
            IList<object[]> lstResult = new List<object[]>();
            NuroMakeDeptComboArgs makeDeptComboArgs = new NuroMakeDeptComboArgs();
            ComboListItemResult comboListItemResult =
                CloudService.Instance.Submit<ComboListItemResult, NuroMakeDeptComboArgs>(makeDeptComboArgs);

            if (comboListItemResult != null)
            {
                IList<ComboListItemInfo> listItem = comboListItemResult.ListItemInfos;
                Console.WriteLine("size: " + listItem.Count);
                foreach (ComboListItemInfo item in listItem)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                    
                    lstResult.Add(objects);
                }
            }
            return lstResult;
        } 

       

        #region createParamList
        private List<string> createParamList()
        {
            List<string> lstResult = new List<string>();
            lstResult.Add("f_naewon_date");
            lstResult.Add("f_gwa");
            lstResult.Add("f_bunho");

            return lstResult;
        }
        #endregion createParamList

        #region DataLoad
        private void DataLoad()
        {
            this.grdList.Reset();
            this.grdList.ParamList = createParamList();
            this.grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdList.SetBindVarValue("f_naewon_date", this.dtpGijunDate.GetDataValue());
            this.grdList.SetBindVarValue("f_gwa", this.cboGwa.GetDataValue());
            this.grdList.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue().ToString());
            this.grdList.QueryLayout(false);
            this.SetDefaultGridImage();
        }
        #endregion

        #region GetOutOrderStatusList

        private IList<object[]> GetOutOrderStatusList(BindVarCollection list)
        {
            grdList.Reset();
            IList<object[]> lstResult = new List<object[]>();
            string naewon_date = list["f_naewon_date"].VarValue;
            string gwa = list["f_gwa"].VarValue;
            string bunho = list["f_bunho"].VarValue;
            if (naewon_date.Equals(""))
            {
                return lstResult;
            }
            NuroOutOrderStatusArgs nuroOutOrderStatusArgs = new NuroOutOrderStatusArgs(naewon_date, gwa, bunho);
            NuroOutOrderStatusResult result =
                CloudService.Instance.Submit<NuroOutOrderStatusResult, NuroOutOrderStatusArgs>(
                    nuroOutOrderStatusArgs);


            if (result != null)
            {
                IList<NuroOutOrderStatusInfo> listOurOrderStatusInfo = result.LstOrderStatusInfos;

                foreach (NuroOutOrderStatusInfo nuroOutOrderStatusInfo in listOurOrderStatusInfo)
                {
                    object[] objects =
                    {
                        nuroOutOrderStatusInfo.PkOut1001,
                        nuroOutOrderStatusInfo.PatientCode,
                        nuroOutOrderStatusInfo.PatientName,
                        nuroOutOrderStatusInfo.RecepTionTime,
                        nuroOutOrderStatusInfo.ComingStatusDate,
                        nuroOutOrderStatusInfo.ReserYn,
                        nuroOutOrderStatusInfo.DeptCode,
                        nuroOutOrderStatusInfo.DoctorCode,
                        nuroOutOrderStatusInfo.DeptName,
                        nuroOutOrderStatusInfo.DoctorName,
                        nuroOutOrderStatusInfo.ReceptionType,
                        nuroOutOrderStatusInfo.CompleteExamination,
                        nuroOutOrderStatusInfo.NumberOfItemsReq,
                        nuroOutOrderStatusInfo.ActingPer,
                        nuroOutOrderStatusInfo.AllEndYn,
                        nuroOutOrderStatusInfo.ActingTime,
                        nuroOutOrderStatusInfo.DatasEndYn
                    };

                    lstResult.Add(objects);
                }
            }
            return lstResult;
        }
        
        #endregion

        #region XComboBox
        private void cboGwa_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region RadioButton
        private void rbnRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            RadioButton control = sender as RadioButton;

            if (control.Checked == true)
            {
                control.BackColor = this.mSelectedBackColor.Color;
                control.ForeColor = this.mSelectedForeColor.Color;
                this.btnList.PerformClick(FunctionType.Query);
                if ((control.Name == "rbnkakeiEnd") || (control.Name == "rbnAll"))
                {
                    this.cbxNotice.Visible = false;
                }
                else 
                {
                    this.cbxNotice.Visible = true;
                }
            }
            else
            {
                control.BackColor = this.mUnSelectedBackColor.Color;
                control.ForeColor = this.mUnSelectedForeColor.Color;
            }
        }
        #endregion

        private void dtpGijunDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue != "")
            {
                //this.grdList.Reset();
                this.btnList.PerformClick(FunctionType.Query);
            }
        }

        #region [환자정보취득이벤트]
        private void fbxBunho_FindClick(object sender, CancelEventArgs e)
        {
            this.OpenScreen_OUT0101Q01();
        }
        
        private void OpenScreen_OUT0101Q01()
        {
            CommonItemCollection param = new CommonItemCollection();

            XScreen.OpenScreenWithParam(this, "NURI", "OUT0101Q01", ScreenOpenStyle.ResponseFixed, param);
        }
        
        private void fbxBunho_DataValidating(object sender, DataValidatingEventArgs e)
        {
            string bunho = "";
            if (e.DataValue != "")
            {
                bunho = BizCodeHelper.GetStandardBunHo(e.DataValue);
            }
            PostCallHelper.PostCall(new PostMethodStr(PostValidating), bunho);
        }
        private void PostValidating(string aBunho)
        {
            this.fbxBunho.SetDataValue(aBunho);
            // XDisplayBox 데이터삭제
            this.dbxSuname.ResetText();
            if (aBunho != "")
            {
                this.layOut0101.LayoutItems.Clear();
                this.layOut0101.LayoutItems.Add("SUNAME");
                // 환자정보데이터 취득
                if (this.layOut0101.QueryLayout())
                {
                    this.dbxSuname.SetEditValue(layOut0101.GetItemValue("SUNAME").ToString());
                }
            }
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void layOut0101_QueryStarting(object sender, CancelEventArgs e)
        {
            layOut0101.ParamList = CreateParamsListForSingleLayout();
            layOut0101.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue().ToString());
        }

        private List<string> CreateParamsListForSingleLayout()
        {
            List<string> lstParam = new List<string>();
            lstParam.Add("f_bunho");
            return lstParam;
        }

        private IList<object[]> GetDataForSingleLayout(BindVarCollection lisCollection)
        {
            IList<object[]> lstSingleLayoutData = new List<object[]>();
            NuroSearchPatientArgs nuroSearchPatientArgs = new NuroSearchPatientArgs(lisCollection["f_bunho"].VarValue);
            NuroSearchPatientInfoResult nuroPatientInfoResult =
                CloudService.Instance.Submit<NuroSearchPatientInfoResult, NuroSearchPatientArgs>(nuroSearchPatientArgs);
            if (nuroPatientInfoResult != null)
            {
                IList<NuroSearchPatientInfo> lstNuroPatientInfos = nuroPatientInfoResult.LsPatientInfos;
                foreach (NuroSearchPatientInfo item in lstNuroPatientInfos)
                {
                    object[] objects =
                    {
                        item.PatientName1,
                        item.PatientName2,
                        item.Birth
                    };
                    lstSingleLayoutData.Add(objects);
                }
            }
            return lstSingleLayoutData;
        }

        #endregion

        

        private void btnList_PostButtonClick(object sender, PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Reset:
                    createDisplay();
                    break;
            }
        }

        private void createDisplay()
        {
            this.dtpGijunDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.fbxBunho.SetDataValue("");
            this.dbxSuname.SetDataValue("");
            if (this.cboGwa.ComboItems.Count > 0)
            {
                this.cboGwa.SelectedIndex = 0;
            }
            this.grdList.Reset();
        }

        private void grdList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;

            //if (grd.GetItemValue(e.RowNumber, "reser_yn").ToString().Trim() == "Y") // 예약환자
            //{
            //    e.BackColor = Color.LightGreen;
            //}
            //else 

            if (grd.GetItemString(e.RowNumber, "data_send_yn") == "Y")
            {
                e.BackColor = Color.DarkGray;
            }
            else if (grd.GetItemString(e.RowNumber, "all_end_yn").Trim() == "Y") // 진료 완료
            {
                e.BackColor = Color.SkyBlue;
                e.ForeColor = Color.Blue;
            }

        }

        private void grdList_GridContDisplayed(object sender, XGridContDisplayedEventArgs e)
        {
            this.SetDefaultGridImage();
        }
        #region SetDefaultGridImage

        private void SetDefaultGridImage()
        {
            for (int i = 0; i < this.grdList.RowCount; i++)
            {
                // 예약환자
                if (this.grdList.GetItemString(i, "reser_yn") == "Y")
                {
                    this.grdList[i + this.grdList.HeaderHeights.Count, 0].Image = this.ImageList.Images[2];
                    this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText = this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText + Resources.ToolTipText1;
                }

                switch (this.grdList.GetItemString(i, "jubsu_gubun"))
                {
                    case "07":    // 약만의 환자
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText = this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText + Resources.ToolTipText2;
                        break;
                    case "08":    // 주사만의 환자
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText = this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText + Resources.ToolTipText3;
                        break;
                    case "09":    // 검사만의 환자
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].Image = this.ImageList.Images[4];
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText = this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText + Resources.ToolTipText4;
                        break;
                    //case "14":    // 긴급환자
                    //    this.grdList[i + this.grdList.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];
                    //    this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText = this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText + "/緊急";
                    //    break; 
                    case "11":    // 건강검진
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].Image = this.ImageList.Images[5];
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText = this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText + Resources.ToolTipText5;
                        break;
                }
            }
        }

        #endregion

        #region [ 에디터그리드마우스클릭이벤트 ]
        private void grdList_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            int rowNumber = -1;
            this.timer1.Stop();            

            try
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    rowNumber = grd.GetHitRowNumber(e.Y);

                    if (rowNumber < 0)  throw new Exception();

                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    this.SendPatient(rowNumber);
                }
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.timer1.Start();
            }
        }
        #endregion
        #region [Send Patient Info]
        private void SendPatient(int aRowNumber)
        {
            IHIS.Framework.IXScreen aScreen;

            string bunho = this.grdList.GetItemString(aRowNumber, "bunho");
            string suname = this.grdList.GetItemString(aRowNumber, "suname");
            string gwa = this.grdList.GetItemString(aRowNumber, "gwa");
            string io_gubun = "O";
            aScreen = XScreen.FindScreen("NURO", "ORDERTRANS");
            if (aScreen == null)
            {
                CommonItemCollection openParams  = new CommonItemCollection();
                openParams.Add("bunho", bunho);
                openParams.Add("suname", suname);
                openParams.Add("gwa", gwa);
                openParams.Add("io_gubun", io_gubun);
                openParams.Add("date", dtpGijunDate.GetDataValue());
                XScreen.OpenScreenWithParam(this, "NURO", "ORDERTRANS", IHIS.Framework.ScreenOpenStyle.PopUpSizable, ScreenAlignment.ParentTopLeft, openParams);
            }
            else 
            {
                aScreen.Activate();
                XPatientInfo paInfo = new XPatientInfo(bunho, suname, gwa, "", "", PatientPKGubun.Out, this.ScreenName);
                XScreen.SendPatientInfo(paInfo);
            }
        }
        #endregion
        
        private void cbxAutoQuery_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAutoQuery.Checked)
            {
                this.cboTime.Enabled = true;
                this.timer1.Interval = Int32.Parse(this.cboTime.GetDataValue());
            }
            else
            {
                this.cboTime.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.cbxAutoQuery.Checked == false)
            {
                return;
            }
            DataRow[] dtRow = null;
            //조회
            this.btnList.PerformClick(FunctionType.Query);
            //회계종료, 전부인경우 리턴
            
            if ((this.grdList.RowCount > 0) && (this.mUserGrop = true) && (this.cbxNotice.Checked))
            {

                dtRow = this.grdList.LayoutTable.Select("all_end_yn =" + "'Y' and data_send_yn = 'N'");
                this.mMsg = NetInfo.Language == LangMode.Ko ? "회계대기환자가" : Resources.XMessageBox4;
                this.mCap = NetInfo.Language == LangMode.Ko ? "알림" : Resources.Caption4;
                
                if ((dtRow != null) && (dtRow.Length > 0))
                {
                    this.mMsg += NetInfo.Language == LangMode.Ko ? " 【 " + dtRow.Length.ToString() + " 】명있습니다." : Resources.XMessageBox5_1 + dtRow.Length.ToString() + Resources.XMessageBox5_2;
                    FormMsg frmMsg = new FormMsg();
                    frmMsg.strTitle = this.mCap;
                    frmMsg.strMemo = this.mMsg;
                    this.timer1.Stop();
                    frmMsg.ShowDialog();
                    //this.Activate();
                    this.timer1.Start();
                }
            }
        }

        private void grdList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            grdList.UnSelectAll();
        }

        private void initializeComboListItem()
        {
            InitializeComboListItemArgs args = new InitializeComboListItemArgs();
            args.CodeType = "JUBSU_GUBUN";
            args.ComboTimeType = "NUR2001U04_TIMER";
//            args.CodeTypeChojae = "CHOJAE";
//            args.CodeTypeCboTel = "TEL_GUBUN";
            InitializeComboListItemResult result = CacheService.Instance.Get<InitializeComboListItemArgs, InitializeComboListItemResult>(args);
            if (result != null)
            {
                cboGwa.SetDictDDLB(createListDataForCombo(result.ComboDepartmentItem));
                cboTime.SetDictDDLB(createListDataForCombo(result.ComboTimeItem));
            }
        }

        private IList<object[]> createListDataForCombo(List<ComboListItemInfo> listComboItem)
        {
            IList<object[]> lstData = new List<object[]>();
            if (listComboItem != null && listComboItem.Count > 0)
            {
                foreach (ComboListItemInfo comboListItemInfo in listComboItem)
                {
                    object[] obj = { comboListItemInfo.Code, comboListItemInfo.CodeName };
                    lstData.Add(obj);
                }
            }
            return lstData;
        }
    }
}
