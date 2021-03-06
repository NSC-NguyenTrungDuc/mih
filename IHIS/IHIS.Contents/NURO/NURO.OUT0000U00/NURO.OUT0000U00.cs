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
using IHIS.NURO.Properties;

#endregion

namespace IHIS.NURO
{
    /// <summary>
    /// OUTS.OUT1101U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OUT0000U00 : IHIS.Framework.XScreen
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
        private XEditGridCell xEditGridCell11;
        private XPanel xPanel2;
        private RadioButton rbnkakei;
        private RadioButton rbnAll;
        private RadioButton rbnkakeiEnd;
        private RadioButton rbnTrans;
        private RadioButton rbnArrive;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XCheckBox cbxNotice;
        private IContainer components;

        public OUT0000U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OUT0000U00));
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
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.rbnkakei = new System.Windows.Forms.RadioButton();
            this.rbnAll = new System.Windows.Forms.RadioButton();
            this.rbnkakeiEnd = new System.Windows.Forms.RadioButton();
            this.rbnTrans = new System.Windows.Forms.RadioButton();
            this.rbnArrive = new System.Windows.Forms.RadioButton();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel4.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
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
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.dbxSuname);
            this.xPanel1.Controls.Add(this.fbxBunho);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dtpGijunDate);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.cboGwa);
            this.xPanel1.Name = "xPanel1";
            // 
            // dbxSuname
            // 
            resources.ApplyResources(this.dbxSuname, "dbxSuname");
            this.dbxSuname.Name = "dbxSuname";
            // 
            // fbxBunho
            // 
            this.fbxBunho.ApplyByteLimit = true;
            resources.ApplyResources(this.fbxBunho, "fbxBunho");
            this.fbxBunho.Name = "fbxBunho";
            this.fbxBunho.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBunho_DataValidating);
            this.fbxBunho.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBunho_FindClick);
            // 
            // xLabel2
            // 
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // dtpGijunDate
            // 
            this.dtpGijunDate.IsJapanYearType = true;
            resources.ApplyResources(this.dtpGijunDate, "dtpGijunDate");
            this.dtpGijunDate.Name = "dtpGijunDate";
            this.dtpGijunDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpGijunDate_DataValidating);
            // 
            // xLabel4
            // 
            this.xLabel4.EdgeRounding = false;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel1
            // 
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // cboGwa
            // 
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.Name = "cboGwa";
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
            this.layOut0101.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layOut0101.QuerySQL = "SELECT A.SUNAME, A.SUNAME2, FN_BAS_TO_JAPAN_DATE_CONVERT(\'1\', A.BIRTH) BIRTH\r\n  F" +
                "ROM OUT0101 A\r\n WHERE A.HOSP_CODE   = :f_hosp_code\r\n   AND A.BUNHO       = :f_bu" +
                "nho";
            this.layOut0101.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layOut0101_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "bunho";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // cboTime
            // 
            resources.ApplyResources(this.cboTime, "cboTime");
            this.cboTime.Name = "cboTime";
            this.cboTime.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboTime.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM NUR0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE(" +
                ")\r\n   AND CODE_TYPE = \'NUR2001U04_TIMER\'\r\n ORDER BY TO_NUMBER(CODE)";
            // 
            // cbxAutoQuery
            // 
            resources.ApplyResources(this.cbxAutoQuery, "cbxAutoQuery");
            this.cbxAutoQuery.Checked = true;
            this.cbxAutoQuery.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAutoQuery.Name = "cbxAutoQuery";
            this.cbxAutoQuery.UseVisualStyleBackColor = false;
            this.cbxAutoQuery.CheckedChanged += new System.EventHandler(this.cbxAutoQuery_CheckedChanged);
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.cbxNotice);
            this.xPanel4.Controls.Add(this.cbxAutoQuery);
            this.xPanel4.Controls.Add(this.cboTime);
            this.xPanel4.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Name = "xPanel4";
            // 
            // cbxNotice
            // 
            resources.ApplyResources(this.cbxNotice, "cbxNotice");
            this.cbxNotice.CheckedValue = "N";
            this.cbxNotice.Name = "cbxNotice";
            this.cbxNotice.UseVisualStyleBackColor = false;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdList);
            this.xPanel3.Controls.Add(this.xPanel2);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // grdList
            // 
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
            this.xEditGridCell11,
            this.xEditGridCell16,
            this.xEditGridCell17});
            this.grdList.ColPerLine = 9;
            this.grdList.Cols = 10;
            resources.ApplyResources(this.grdList, "grdList");
            this.grdList.FixedCols = 1;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(27);
            this.grdList.Name = "grdList";
            this.grdList.QuerySQL = resources.GetString("grdList.QuerySQL");
            this.grdList.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdList.RowHeaderVisible = true;
            this.grdList.Rows = 2;
            this.grdList.ToolTipActive = true;
            this.grdList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdList_MouseDown);
            this.grdList.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdList_GridColumnProtectModify);
            this.grdList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdList_GridCellPainting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "fkout1001";
            this.xEditGridCell1.Col = -1;
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
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "suname";
            this.xEditGridCell3.CellWidth = 100;
            this.xEditGridCell3.Col = 2;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "jubsu_time";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell10.CellWidth = 150;
            this.xEditGridCell10.Col = 3;
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
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "gwa";
            this.xEditGridCell6.Col = -1;
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
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "gwa_name";
            this.xEditGridCell8.CellWidth = 90;
            this.xEditGridCell8.Col = 4;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "doctor_name";
            this.xEditGridCell9.CellWidth = 100;
            this.xEditGridCell9.Col = 5;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "jubsu_gubun";
            this.xEditGridCell12.Col = -1;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "naewon_yn";
            this.xEditGridCell14.CellWidth = 100;
            this.xEditGridCell14.Col = 6;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdatable = false;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "arrive_yn";
            this.xEditGridCell13.CellWidth = 100;
            this.xEditGridCell13.Col = 7;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "trans_yn";
            this.xEditGridCell5.CellWidth = 100;
            this.xEditGridCell5.Col = 8;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "kaikei_end_yn";
            this.xEditGridCell11.CellWidth = 100;
            this.xEditGridCell11.Col = 9;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "arrive_yn_old";
            this.xEditGridCell16.Col = -1;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "trans_yn_old";
            this.xEditGridCell17.Col = -1;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xPanel2
            // 
            this.xPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel2.Controls.Add(this.rbnkakei);
            this.xPanel2.Controls.Add(this.rbnAll);
            this.xPanel2.Controls.Add(this.rbnkakeiEnd);
            this.xPanel2.Controls.Add(this.rbnTrans);
            this.xPanel2.Controls.Add(this.rbnArrive);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // rbnkakei
            // 
            resources.ApplyResources(this.rbnkakei, "rbnkakei");
            this.rbnkakei.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbnkakei.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbnkakei.Name = "rbnkakei";
            this.rbnkakei.Tag = "";
            this.rbnkakei.UseVisualStyleBackColor = false;
            this.rbnkakei.CheckedChanged += new System.EventHandler(this.rbnRadio_CheckedChanged);
            // 
            // rbnAll
            // 
            resources.ApplyResources(this.rbnAll, "rbnAll");
            this.rbnAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbnAll.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbnAll.Name = "rbnAll";
            this.rbnAll.Tag = "";
            this.rbnAll.UseVisualStyleBackColor = false;
            this.rbnAll.CheckedChanged += new System.EventHandler(this.rbnRadio_CheckedChanged);
            // 
            // rbnkakeiEnd
            // 
            resources.ApplyResources(this.rbnkakeiEnd, "rbnkakeiEnd");
            this.rbnkakeiEnd.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbnkakeiEnd.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbnkakeiEnd.Name = "rbnkakeiEnd";
            this.rbnkakeiEnd.Tag = "";
            this.rbnkakeiEnd.UseVisualStyleBackColor = false;
            this.rbnkakeiEnd.CheckedChanged += new System.EventHandler(this.rbnRadio_CheckedChanged);
            // 
            // rbnTrans
            // 
            resources.ApplyResources(this.rbnTrans, "rbnTrans");
            this.rbnTrans.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbnTrans.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbnTrans.Name = "rbnTrans";
            this.rbnTrans.UseVisualStyleBackColor = false;
            this.rbnTrans.CheckedChanged += new System.EventHandler(this.rbnRadio_CheckedChanged);
            // 
            // rbnArrive
            // 
            resources.ApplyResources(this.rbnArrive, "rbnArrive");
            this.rbnArrive.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbnArrive.Checked = true;
            this.rbnArrive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbnArrive.Name = "rbnArrive";
            this.rbnArrive.TabStop = true;
            this.rbnArrive.UseVisualStyleBackColor = false;
            this.rbnArrive.CheckedChanged += new System.EventHandler(this.rbnRadio_CheckedChanged);
            // 
            // OUT0000U00
            // 
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel4);
            this.Name = "OUT0000U00";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.OUT0000U00_Load);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OUT0000U00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel4.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.xPanel2.ResumeLayout(false);
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
        private int mMaxWidth = 662;
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
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장이 완료되었습니다." : Resources.OUT0000U00_LHT;
                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : Resources.OUT0000U00_HTL;
                        //XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.SetMsg(this.mMsg, MsgType.Normal);
                        this.DataLoad();
                    }
                    else
                    {
                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : Resources.OUT0000U00_LTB;
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : Resources.OUT0000U00_LDBTB;
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
                this.grdList.ReadOnly = false;
            }
            else
            {
                this.grdList.ReadOnly = true;
                this.cbxNotice.Visible = false;
            }
            this.cboTime.SelectedIndex = 0;
            this.grdList.SavePerformer = new XSavePeformer(this);
            this.MakeGwaCombo();
            this.dtpGijunDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            this.btnList.PerformClick(FunctionType.Query);
        }
        private void OUT0000U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // 화면 사이즈 조정
            // 화면 크기를 화면에 맞게 최대화 시킨다 
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(mMaxWidth, rc.Height - 105);
        }

        #region [콤보박스 생성]
        private void MakeGwaCombo()
        {
            string UserSQL = @" SELECT '%', '全体'
                                  FROM DUAL
                                 UNION
                                SELECT A.GWA, A.GWA_NAME
				                 FROM BAS0260 A
				                WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE
                                  AND A.BUSEO_GUBUN = '1'
				                  AND A.START_DATE = ( SELECT MAX(Z.START_DATE)
				                                        FROM BAS0260 Z 
				                                       WHERE Z.HOSP_CODE  = A.HOSP_CODE
                                                         AND Z.BUSEO_CODE = A.BUSEO_CODE 
				                                         AND Z.START_DATE <= TRUNC(SYSDATE) ) 
				                 ORDER BY 1  ";

            IHIS.Framework.MultiLayout layoutCombo = new MultiLayout();
            layoutCombo.Reset();
            layoutCombo.LayoutItems.Clear();
            layoutCombo.LayoutItems.Add("gwa", DataType.String);
            layoutCombo.LayoutItems.Add("gwa_name", DataType.String);
            layoutCombo.InitializeLayoutTable();
            layoutCombo.QuerySQL = UserSQL;
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

        #region DataLoad
        private void DataLoad()
        {
            this.grdList.Reset();

            if (this.rbnArrive.Checked)
            {
                this.grdList.SetBindVarValue("f_arrive_yn", "N");
                this.grdList.SetBindVarValue("f_trans_yn", "N");
                this.grdList.SetBindVarValue("f_kaikei_end_yn", "N");
            }
            else if (this.rbnTrans.Checked)
            {
                this.grdList.SetBindVarValue("f_arrive_yn", "Y");
                this.grdList.SetBindVarValue("f_trans_yn", "N");
                this.grdList.SetBindVarValue("f_kaikei_end_yn", "N");
            }
            //else if (this.rbnkakei.Checked)
            //{
            //    this.grdList.SetBindVarValue("f_arrive_yn", "Y");
            //    this.grdList.SetBindVarValue("f_trans_yn", "Y");
            //    this.grdList.SetBindVarValue("f_kaikei_end_yn", "N");
            //}
            else if (this.rbnkakeiEnd.Checked)
            {
                this.grdList.SetBindVarValue("f_arrive_yn", "Y");
                this.grdList.SetBindVarValue("f_trans_yn", "Y");
                this.grdList.SetBindVarValue("f_kaikei_end_yn", "Y");
            }
            else
            {
                this.grdList.SetBindVarValue("f_arrive_yn", "%");
                this.grdList.SetBindVarValue("f_trans_yn", "%");
                this.grdList.SetBindVarValue("f_kaikei_end_yn", "%");
            }
            this.grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdList.SetBindVarValue("f_naewon_date", this.dtpGijunDate.GetDataValue());
            this.grdList.SetBindVarValue("f_gwa", this.cboGwa.GetDataValue());
            this.grdList.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue().ToString());
            this.grdList.QueryLayout(false);
            this.SetDefaultGridImage();
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

        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private OUT0000U00 parent = null;

            public XSavePeformer(OUT0000U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);  //병원코드
                item.BindVarList.Add("f_user_id", UserInfo.UserID);         //갱신자ID

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Modified:

                                cmdText = @" DECLARE
                                               BEGIN
                                                    UPDATE OUT0000 A
                                                    SET   A.UPD_ID           = :f_user_id
                                                        , A.UPD_DATE         = SYSDATE
                                                        , A.ARRIVE_KAIKEI_YN = :f_arrive_yn
                                                        , A.TRANS_KAIKEI_YN  = :f_trans_yn
                                                        , A.KAIKEI_END_YN    = :f_kaikei_end_yn
                                                  WHERE A.HOSP_CODE   = :f_hosp_code
                                                    AND A.FKOUT1001   = :f_fkout1001
                                                    AND A.NAEWON_DATE = :f_naewon_date;                                                    
                                                  IF SQL%NOTFOUND THEN
                                                    INSERT INTO OUT0000
                                                        ( SYS_DATE          ,SYS_ID             ,UPD_DATE   
                                                        ,UPD_ID             ,FKOUT1001          ,NAEWON_DATE        
                                                        ,GWA                ,DOCTOR             ,ARRIVE_KAIKEI_YN   
                                                        ,TRANS_KAIKEI_YN    ,KAIKEI_END_YN      ,HOSP_CODE)
                                                        VALUES
                                                        ( SYSDATE           ,:f_user_id         ,SYSDATE    
                                                        ,:f_user_id         ,:f_fkout1001       ,:f_naewon_date     
                                                        ,:f_gwa             ,:f_doctor          ,:f_arrive_yn       
                                                        ,:f_trans_yn        ,:f_kaikei_end_yn   ,:f_hosp_code);                                                   
                                                   END IF;  
                                              END; "; 
                                break;
                        }
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion
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
            this.layOut0101.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layOut0101.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue().ToString());
        }
        #endregion

        private void grdList_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            e.Protect = true;

            if (this.rbnArrive.Checked == true)
            {
                if ((e.ColName == "arrive_yn") &&
                    (this.grdList.GetItemString(e.RowNumber, "trans_yn_old") == "N") &&
                    (this.grdList.GetItemString(e.RowNumber, "kaikei_end_yn") == "N"))
                {
                    e.Protect = false;
                }
                else if ((e.ColName == "trans_yn") &&
                    (this.grdList.GetItemString(e.RowNumber, "arrive_yn_old") == "Y") &&
                    (this.grdList.GetItemString(e.RowNumber, "kaikei_end_yn") == "N"))
                {
                    e.Protect = false;
                }
                else if ((e.ColName == "kaikei_end_yn") &&
                    (this.grdList.GetItemString(e.RowNumber, "arrive_yn") == "Y") &&
                    (this.grdList.GetItemString(e.RowNumber, "trans_yn") == "Y"))
                {
                    e.Protect = false;
                }
            }
            else if (this.rbnTrans.Checked == true)
            {
                if (((e.ColName == "trans_yn") &&
                    (this.grdList.GetItemString(e.RowNumber, "arrive_yn") == "Y")) ||
                    ((e.ColName == "arrive_yn") &&
                    (this.grdList.GetItemString(e.RowNumber, "trans_yn") == "N")))
                {
                    e.Protect = false;
                }
            }
            else if (this.rbnkakeiEnd.Checked)
            {
                if (e.ColName == "kaikei_end_yn")
                {
                    e.Protect = false;
                }
            }
        }

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

            if (grd.GetItemValue(e.RowNumber, "reser_yn").ToString().Trim() == "Y") // 예약환자
            {
                e.BackColor = Color.LightGreen;
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
                    this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText = this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText + Resources.OUT0000U00_BENHK;
                }

                switch (this.grdList.GetItemString(i, "jubsu_gubun"))
                {
                    case "07":    // 약만의 환자
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText = this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText + Resources.OUT0000U00_TNTT;
                        break;
                    case "08":    // 주사만의 환자
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText = this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText + Resources.OUT0000U00_TNT;
                        break;
                    case "09":    // 검사만의 환자
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].Image = this.ImageList.Images[4];
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText = this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText + Resources.OUT0000U00_TNXN;
                        break;
                    case "14":    // 긴급환자
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText = this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText + Resources.OUT0000U00_KC;
                        break; 
                    case "11":    // 건강검진
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].Image = this.ImageList.Images[5];
                        this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText = this.grdList[i + this.grdList.HeaderHeights.Count, 0].ToolTipText + Resources.OUT0000U00_CDSK;
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

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                rowNumber = grd.GetHitRowNumber(e.Y);

                if (rowNumber < 0) return;

                if ((grd.CurrentColName == "arrive_yn") ||
                    (grd.CurrentColName == "trans_yn") ||
                    (grd.CurrentColName == "kaikei_end_yn"))
                {
                    this.timer1.Start();
                    return;
                }
                try
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    this.SendPatient(rowNumber);
                }
                finally
                {
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
            }
            else
            {
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
            if ((this.rbnkakeiEnd.Checked) || (this.rbnAll.Checked))
            {
                return;
            }
            if ((this.grdList.RowCount > 0) && (this.mUserGrop = true) && (this.cbxNotice.Checked))
            {
                if (this.rbnArrive.Checked)
                {
                    dtRow = this.grdList.LayoutTable.Select("trans_yn =" + "'Y'");
                    this.mMsg = NetInfo.Language == LangMode.Ko ? "회계대기환자가" : "会計待ち患者が";
                    this.mCap = NetInfo.Language == LangMode.Ko ? "알림" : "お知らせ";
                }
                else if (this.rbnTrans.Checked)
                {
                    dtRow = this.grdList.LayoutTable.Select("arrive_yn =" + "'Y'");
                    this.mMsg = NetInfo.Language == LangMode.Ko ? "전송대기환자가" : "転送待ち患者が";
                    this.mCap = NetInfo.Language == LangMode.Ko ? "알림" : "お知らせ";
                }
                if ((dtRow != null) && (dtRow.Length > 0))
                {
                    this.mMsg += NetInfo.Language == LangMode.Ko ? " 【 " + dtRow.Length.ToString() + " 】명있습니다." : " 【 " + dtRow.Length.ToString() + " 】名います。";
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


    }
}
