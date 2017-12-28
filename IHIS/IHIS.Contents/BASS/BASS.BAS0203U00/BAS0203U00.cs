#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Results;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Utility;
using IHIS.BASS.Properties;
#endregion

namespace IHIS.BASS
{
    /// <summary>
    /// BAS0203U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class BAS0203U00 : IHIS.Framework.XScreen
    {
        #region Auto-generated code

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XEditGrid grdBAS0203;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XDatePicker dtpJukyongDate;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XFindWorker fwkSymyaGubun;
        private IHIS.Framework.XFindWorker fwkBunCode;
        private IHIS.Framework.XFindWorker fwkSgCode;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.FindColumnInfo findColumnInfo3;
        private IHIS.Framework.FindColumnInfo findColumnInfo4;
        private IHIS.Framework.FindColumnInfo findColumnInfo5;
        private IHIS.Framework.FindColumnInfo findColumnInfo6;
        private IHIS.Framework.XFindBox fbxSymyaGubun;
        private IHIS.Framework.XDisplayBox dbxSymyaGubun;
        private IHIS.Framework.SingleLayout laySymyaGubun;
        private IHIS.Framework.SingleLayout laySymyaGubun2;
        private IHIS.Framework.SingleLayout layBunCode;
        private IHIS.Framework.SingleLayout laySgCode;
        private IHIS.Framework.SingleLayout layDupCheck;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayoutItem singleLayoutItem5;
        private XGridHeader xGridHeader1;
        private XGridHeader xGridHeader2;
        private XHospBox xHospBox;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0203U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xHospBox = new IHIS.Framework.XHospBox();
            this.dbxSymyaGubun = new IHIS.Framework.XDisplayBox();
            this.fbxSymyaGubun = new IHIS.Framework.XFindBox();
            this.fwkSymyaGubun = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpJukyongDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.grdBAS0203 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.fwkBunCode = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.fwkSgCode = new IHIS.Framework.XFindWorker();
            this.findColumnInfo5 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo6 = new IHIS.Framework.FindColumnInfo();
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
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.btnList = new IHIS.Framework.XButtonList();
            this.laySymyaGubun = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.laySymyaGubun2 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.layBunCode = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.laySgCode = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.layDupCheck = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0203)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
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
            this.xPanel1.Controls.Add(this.xHospBox);
            this.xPanel1.Controls.Add(this.dbxSymyaGubun);
            this.xPanel1.Controls.Add(this.fbxSymyaGubun);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dtpJukyongDate);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xHospBox
            // 
            this.xHospBox.AccessibleDescription = null;
            this.xHospBox.AccessibleName = null;
            resources.ApplyResources(this.xHospBox, "xHospBox");
            this.xHospBox.BackColor = System.Drawing.Color.Transparent;
            this.xHospBox.BackgroundImage = null;
            this.xHospBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.xHospBox.HospCode = "";
            this.xHospBox.Name = "xHospBox";
            this.xHospBox.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.xHospBox_DataValidating);
            this.xHospBox.FindClick += new System.EventHandler(this.xHospBox_FindClick);
            // 
            // dbxSymyaGubun
            // 
            this.dbxSymyaGubun.AccessibleDescription = null;
            this.dbxSymyaGubun.AccessibleName = null;
            resources.ApplyResources(this.dbxSymyaGubun, "dbxSymyaGubun");
            this.dbxSymyaGubun.Image = null;
            this.dbxSymyaGubun.Name = "dbxSymyaGubun";
            // 
            // fbxSymyaGubun
            // 
            this.fbxSymyaGubun.AccessibleDescription = null;
            this.fbxSymyaGubun.AccessibleName = null;
            resources.ApplyResources(this.fbxSymyaGubun, "fbxSymyaGubun");
            this.fbxSymyaGubun.BackgroundImage = null;
            this.fbxSymyaGubun.FindWorker = this.fwkSymyaGubun;
            this.fbxSymyaGubun.Name = "fbxSymyaGubun";
            this.fbxSymyaGubun.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxSymyaGubun_DataValidating);
            // 
            // fwkSymyaGubun
            // 
            this.fwkSymyaGubun.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkSymyaGubun.ExecuteQuery = null;
            this.fwkSymyaGubun.FormText = global::IHIS.BASS.Properties.Resources.TEXT9;
            this.fwkSymyaGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkSymyaGubun.ParamList")));
            this.fwkSymyaGubun.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkSymyaGubun.ServerFilter = true;
            this.fwkSymyaGubun.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkSymyaGubun_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.ColWidth = 64;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 224;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // dtpJukyongDate
            // 
            this.dtpJukyongDate.AccessibleDescription = null;
            this.dtpJukyongDate.AccessibleName = null;
            resources.ApplyResources(this.dtpJukyongDate, "dtpJukyongDate");
            this.dtpJukyongDate.BackgroundImage = null;
            this.dtpJukyongDate.IsVietnameseYearType = false;
            this.dtpJukyongDate.Name = "dtpJukyongDate";
            this.dtpJukyongDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpJukyongDate_KeyDown);
            this.dtpJukyongDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtpJukyongDate_MouseDown);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // grdBAS0203
            // 
            this.grdBAS0203.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdBAS0203, "grdBAS0203");
            this.grdBAS0203.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell21});
            this.grdBAS0203.ColPerLine = 6;
            this.grdBAS0203.Cols = 6;
            this.grdBAS0203.ExecuteQuery = null;
            this.grdBAS0203.FixedRows = 2;
            this.grdBAS0203.HeaderHeights.Add(21);
            this.grdBAS0203.HeaderHeights.Add(0);
            this.grdBAS0203.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2});
            this.grdBAS0203.Name = "grdBAS0203";
            this.grdBAS0203.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBAS0203.ParamList")));
            this.grdBAS0203.QuerySQL = resources.GetString("grdBAS0203.QuerySQL");
            this.grdBAS0203.Rows = 3;
            this.grdBAS0203.ToolTipActive = true;
            this.grdBAS0203.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdBAS0203_GridColumnChanged);
            this.grdBAS0203.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBAS0203_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "jy_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 402;
            this.xEditGridCell1.Col = 5;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowSpan = 2;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AutoTabDataSelected = true;
            this.xEditGridCell2.CellLen = 1;
            this.xEditGridCell2.CellName = "symya_gubun";
            this.xEditGridCell2.CellWidth = 32;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.FindWorker = this.fwkSymyaGubun;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.Row = 1;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 80;
            this.xEditGridCell3.CellName = "symya_gubun_name";
            this.xEditGridCell3.CellWidth = 124;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.Row = 1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AutoTabDataSelected = true;
            this.xEditGridCell4.CellLen = 2;
            this.xEditGridCell4.CellName = "bun_code";
            this.xEditGridCell4.CellWidth = 30;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.FindWorker = this.fwkBunCode;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell4.IsNotNull = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkBunCode
            // 
            this.fwkBunCode.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkBunCode.ExecuteQuery = null;
            this.fwkBunCode.FormText = "分類コード照会";
            this.fwkBunCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkBunCode.ParamList")));
            this.fwkBunCode.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkBunCode.ServerFilter = true;
            this.fwkBunCode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkBunCode_QueryStarting);
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo3.ColName = "code";
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "code_name";
            this.findColumnInfo4.ColWidth = 246;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 30;
            this.xEditGridCell5.CellName = "bun_name";
            this.xEditGridCell5.CellWidth = 30;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AutoTabDataSelected = true;
            this.xEditGridCell6.CellName = "sg_code";
            this.xEditGridCell6.CellWidth = 30;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.FindWorker = this.fwkSgCode;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell6.IsNotNull = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // fwkSgCode
            // 
            this.fwkSgCode.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo5,
            this.findColumnInfo6});
            this.fwkSgCode.ExecuteQuery = null;
            this.fwkSgCode.FormText = "点数コード照会";
            this.fwkSgCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkSgCode.ParamList")));
            this.fwkSgCode.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkSgCode.ServerFilter = true;
            this.fwkSgCode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkSgCode_QueryStarting);
            // 
            // findColumnInfo5
            // 
            this.findColumnInfo5.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo5.ColName = "code";
            this.findColumnInfo5.ColWidth = 109;
            this.findColumnInfo5.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo5, "findColumnInfo5");
            // 
            // findColumnInfo6
            // 
            this.findColumnInfo6.ColName = "code_name";
            this.findColumnInfo6.ColWidth = 294;
            this.findColumnInfo6.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo6, "findColumnInfo6");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 80;
            this.xEditGridCell7.CellName = "sg_name";
            this.xEditGridCell7.CellWidth = 30;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 4;
            this.xEditGridCell8.CellName = "from_time";
            this.xEditGridCell8.CellWidth = 120;
            this.xEditGridCell8.Col = 3;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsNotNull = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.Mask = "##:##";
            this.xEditGridCell8.Row = 1;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 4;
            this.xEditGridCell9.CellName = "to_time";
            this.xEditGridCell9.CellWidth = 44;
            this.xEditGridCell9.Col = 4;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsNotNull = true;
            this.xEditGridCell9.Mask = "##:##";
            this.xEditGridCell9.Row = 1;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 2;
            this.xEditGridCell10.CellName = "yoil_gubun";
            this.xEditGridCell10.CellWidth = 107;
            this.xEditGridCell10.Col = 2;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsNotNull = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.RowSpan = 2;
            this.xEditGridCell10.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "from_month";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell11.CellWidth = 30;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.InitValue = "-1";
            this.xEditGridCell11.IsNotNull = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.MinusAccept = true;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "to_month";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell12.CellWidth = 30;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.InitValue = "99999";
            this.xEditGridCell12.IsNotNull = true;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.MinusAccept = true;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "old_jy_date";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "old_symya_gubun";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "old_bun_code";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "old_sg_code";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "old_from_time";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "old_to_time";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "old_yoil_gubun";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "old_from_month";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "old_to_month";
            this.xEditGridCell21.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 32;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 3;
            this.xGridHeader2.ColSpan = 2;
            this.xGridHeader2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 120;
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // laySymyaGubun
            // 
            this.laySymyaGubun.ExecuteQuery = null;
            this.laySymyaGubun.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.laySymyaGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySymyaGubun.ParamList")));
            this.laySymyaGubun.QueryStarting += new System.ComponentModel.CancelEventHandler(this.laySymyaGubun_QueryStarting);
            this.laySymyaGubun.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.laySymyaGubun_QueryEnd);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.dbxSymyaGubun;
            this.singleLayoutItem1.DataName = "dbxSymyaGubun";
            // 
            // laySymyaGubun2
            // 
            this.laySymyaGubun2.ExecuteQuery = null;
            this.laySymyaGubun2.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.laySymyaGubun2.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySymyaGubun2.ParamList")));
            this.laySymyaGubun2.QuerySQL = "SELECT CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND CODE_TY" +
                "PE = \'SYMYA_GUBUN\'\r\n   AND CODE = :f_code";
            this.laySymyaGubun2.QueryStarting += new System.ComponentModel.CancelEventHandler(this.laySymyaGubun2_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "code_name";
            // 
            // layBunCode
            // 
            this.layBunCode.ExecuteQuery = null;
            this.layBunCode.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem3});
            this.layBunCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBunCode.ParamList")));
            this.layBunCode.QuerySQL = "SELECT FN_BAS_LOAD_BAS0230(:f_code)\r\n  FROM DUAL";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "bun_name";
            // 
            // laySgCode
            // 
            this.laySgCode.ExecuteQuery = null;
            this.laySgCode.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem4});
            this.laySgCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySgCode.ParamList")));
            this.laySgCode.QuerySQL = resources.GetString("laySgCode.QuerySQL");
            this.laySgCode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.laySgCode_QueryStarting);
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "sg_name";
            // 
            // layDupCheck
            // 
            this.layDupCheck.ExecuteQuery = null;
            this.layDupCheck.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem5});
            this.layDupCheck.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupCheck.ParamList")));
            this.layDupCheck.QuerySQL = resources.GetString("layDupCheck.QuerySQL");
            this.layDupCheck.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDupCheck_QueryStarting);
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.DataName = "dup_yn";
            // 
            // BAS0203U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.grdBAS0203);
            this.Controls.Add(this.xPanel1);
            this.Name = "BAS0203U00";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.BAS0203U00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0203)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #endregion

        #region Fields & properties

        //private bool mIsPass = false;
        private bool mIsNewRow = false;
        private string mMsg = "";
        private string mCap = "";
        private string mHospCode = "";

        #endregion

        #region Constructor
        /// <summary>
        /// BAS0203U00
        /// </summary>
        public BAS0203U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            //this.grdBAS0203.SavePerformer = new XSavePeformer(this);

            // updated by Cloud
            InitializeCloud();
        }

        #endregion

        #region Events

        private void BAS0203U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            // 2015.06.22 Cloud updated START
            this.mHospCode = UserInfo.HospCode;
            //this.mHospCode = "K01"; // test data
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                xHospBox.Visible = true;
                xHospBox.Location = new Point(8, 10);
                dbxSymyaGubun.Location = new Point(697, 10);
                fbxSymyaGubun.Location = new Point(639, 10);
                xLabel2.Location = new Point(559, 10);
                dtpJukyongDate.Location = new Point(442, 10);
                xLabel1.Location = new Point(362, 10);
                //xPanel1.Size = new Size(812, 48);
                btnList.SetEnabled(FunctionType.Insert, false);
                btnList.SetEnabled(FunctionType.Update, false);
                btnList.SetEnabled(FunctionType.Delete, false);
            }
            else
            {
                xHospBox.Visible = false;
            }

            // Set yoil_gubun cbo
            SetYoilCbo(this.mHospCode);
            // 2015.06.22 Cloud updated END

            // 적용일자는 오늘날자로...
            this.dtpJukyongDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.grdBAS0203.QueryLayout(false);
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    break;
                case FunctionType.Delete:
                    break;
                case FunctionType.Query:
                    break;

                case FunctionType.Update:
                    #region deleted by Cloud
                    //if (this.grdBAS0203.SaveLayout())
                    //{
                    //    this.mMsg = NetInfo.Language == LangMode.Ko ? "저장이 완료되었습니다." : Properties.Resources.TEXT1;

                    //    this.mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : Properties.Resources.TEXT2;

                    //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //    this.grdBAS0203.QueryLayout(false);
                    //}
                    //else
                    //{
                    //    this.mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : Properties.Resources.TEXT3;

                    //    this.mMsg += "\r\n" + Service.ErrFullMsg;

                    //    this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : Properties.Resources.TEXT4;

                    //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //}
                    #endregion

                    // 2015.06.22 Cloud updated START
                    e.IsBaseCall = false;
                    BAS0203U00SaveLayoutArgs args = new BAS0203U00SaveLayoutArgs();
                    args.GrdBas0203Item = GetListDataForSaveLayout();
                    args.HospCode = this.mHospCode;
                    args.UserId = UserInfo.UserID;
                    if (args.GrdBas0203Item.Count < 1) return;
                    UpdateResult res = CloudService.Instance.Submit<UpdateResult, BAS0203U00SaveLayoutArgs>(args);

                    if (!TypeCheck.IsNull(res.Msg))
                    {
                        XMessageBox.Show("「" + res.Msg + "」" + Properties.Resources.TEXT7, Properties.Resources.TEXT8, MessageBoxIcon.Warning);
                        return;
                    }

                    if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장이 완료되었습니다." : Properties.Resources.TEXT1;

                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : Properties.Resources.TEXT2;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.grdBAS0203.QueryLayout(false);
                    }
                    else
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : Properties.Resources.TEXT3;

                        this.mMsg += "\r\n" + Service.ErrFullMsg;

                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : Properties.Resources.TEXT4;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // 2015.06.22 Cloud updated END
                    break;
            }
        }

        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    this.grdBAS0203.SetItemValue(grdBAS0203.CurrentRowNumber, "jy_date", this.dtpJukyongDate.GetDataValue());

                    //언비저블로 했으므로 강제로 값넣어줌 
                    this.grdBAS0203.SetItemValue(grdBAS0203.CurrentRowNumber, "bun_code", "%");
                    this.grdBAS0203.SetItemValue(grdBAS0203.CurrentRowNumber, "sg_code", "%");
                    this.grdBAS0203.SetItemValue(grdBAS0203.CurrentRowNumber, "from_month", "-1");
                    this.grdBAS0203.SetItemValue(grdBAS0203.CurrentRowNumber, "to_month", "999999");

                    if (this.fbxSymyaGubun.GetDataValue() != "")
                    {
                        this.grdBAS0203.SetItemValue(grdBAS0203.CurrentRowNumber, "symya_gubun", fbxSymyaGubun.GetDataValue());
                        this.grdBAS0203.SetItemValue(grdBAS0203.CurrentRowNumber, "symya_gubun_name", this.dbxSymyaGubun.GetDataValue());
                        this.grdBAS0203.SetFocusToItem(grdBAS0203.CurrentRowNumber, "bun_code");
                    }
                    break;
                case FunctionType.Reset:
                    this.dtpJukyongDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    break;
            }
        }

        private void laySymyaGubun_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.laySymyaGubun.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.laySymyaGubun.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.laySymyaGubun.SetBindVarValue("f_code", this.fbxSymyaGubun.GetDataValue());
        }

        private void laySymyaGubun_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.laySymyaGubun.GetItemValue("dbxSymyaGubun").ToString() != "")
            {
                this.grdBAS0203.QueryLayout(false);
            }
        }

        private void laySymyaGubun2_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.laySymyaGubun2.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.laySymyaGubun2.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.laySymyaGubun2.SetBindVarValue("f_code", this.grdBAS0203.GetItemString(grdBAS0203.CurrentRowNumber, "symya_gubun"));
        }

        private void laySgCode_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.laySgCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.laySgCode.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.laySgCode.SetBindVarValue("f_sg_code", this.grdBAS0203.GetItemString(grdBAS0203.CurrentRowNumber, "sg_code"));
            this.laySgCode.SetBindVarValue("f_sg_ymd", this.dtpJukyongDate.GetDataValue());
        }

        private void layDupCheck_QueryStarting(object sender, CancelEventArgs e)
        {
            int rowNumber = this.grdBAS0203.CurrentRowNumber;

            //this.layDupCheck.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDupCheck.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layDupCheck.SetBindVarValue("f_symya_gubun", this.grdBAS0203.GetItemString(rowNumber, "symya_gubun"));
            this.layDupCheck.SetBindVarValue("f_bun_code", this.grdBAS0203.GetItemString(rowNumber, "bun_code"));
            this.layDupCheck.SetBindVarValue("f_sg_code", this.grdBAS0203.GetItemString(rowNumber, "sg_code"));
            this.layDupCheck.SetBindVarValue("f_jy_date", this.grdBAS0203.GetItemString(rowNumber, "jy_date"));
            this.layDupCheck.SetBindVarValue("f_from_time", this.grdBAS0203.GetItemString(rowNumber, "from_time"));
        }

        private void grdBAS0203_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            string hour = "";
            string min = "";
            string msg = "";

            this.SetMsg(msg);
            if (e.ChangeValue.ToString() == "")
                return;

            switch (e.ColName)
            {
                case "symya_gubun":
                    if (this.DupCheck(e.ChangeValue.ToString(),
                                      grdBAS0203.GetItemString(e.RowNumber, "yoil_gubun"),
                                      grdBAS0203.GetItemString(e.RowNumber, "bun_code"),
                                      grdBAS0203.GetItemString(e.RowNumber, "sg_code"),
                                      grdBAS0203.GetItemString(e.RowNumber, "jy_date"),
                                      grdBAS0203.GetItemString(e.RowNumber, "from_time")))
                    {
                        msg = (NetInfo.Language == LangMode.Ko ? "동일한 코드가 존재 합니다." : Properties.Resources.TEXT5);

                        this.SetMsg(msg, MsgType.Error);

                        e.Cancel = true;
                    }

                    this.laySymyaGubun2.QueryLayout();
                    this.grdBAS0203.SetItemValue(e.RowNumber, "symya_gubun_name", this.laySymyaGubun2.GetItemValue("code_name"));
                    break;

                case "yoil_gubun":

                    if (this.DupCheck(grdBAS0203.GetItemString(e.RowNumber, "symya_gubun"),
                                      e.ChangeValue.ToString(),
                                      grdBAS0203.GetItemString(e.RowNumber, "bun_code"),
                                      grdBAS0203.GetItemString(e.RowNumber, "sg_code"),
                                      grdBAS0203.GetItemString(e.RowNumber, "jy_date"),
                                      grdBAS0203.GetItemString(e.RowNumber, "from_time")))
                    {
                        msg = (NetInfo.Language == LangMode.Ko ? "동일한 코드가 존재 합니다." : Properties.Resources.TEXT5);

                        this.SetMsg(msg, MsgType.Error);

                        e.Cancel = true;
                    }
                    break;

                case "bun_code":
                    if (this.DupCheck(grdBAS0203.GetItemString(e.RowNumber, "symya_gubun"),
                                      grdBAS0203.GetItemString(e.RowNumber, "yoil_gubun"),
                                      e.ChangeValue.ToString(),
                                      grdBAS0203.GetItemString(e.RowNumber, "sg_code"),
                                      grdBAS0203.GetItemString(e.RowNumber, "jy_date"),
                                      grdBAS0203.GetItemString(e.RowNumber, "from_time")))
                    {
                        msg = (NetInfo.Language == LangMode.Ko ? "동일한 코드가 존재 합니다." : Properties.Resources.TEXT5);

                        this.SetMsg(msg, MsgType.Error);

                        e.Cancel = true;
                    }

                    // 데이터가 없으면 바로 리턴
                    if (e.ChangeValue.ToString() == "")
                        break;

                    #region deleted by Cloud
                    //// 벨리데이션 서비스 콜
                    //this.layBunCode.SetBindVarValue("f_code", e.ChangeValue.ToString());

                    //this.layBunCode.QueryLayout();

                    //// Out 벨류가 없다면 에러
                    //if (this.layBunCode.GetItemValue("bun_name").ToString() == "")
                    //{
                    //    msg = (NetInfo.Language == LangMode.Ko ? "No Data Found.." : "No Data Found..");

                    //    this.SetMsg(msg, MsgType.Error);

                    //    e.Cancel = true;
                    //}
                    //else
                    //{
                    //    this.grdBAS0203.SetItemValue(e.RowNumber, "bun_name", this.layBunCode.GetItemValue("bun_name").ToString());
                    //    this.grdBAS0203.SetFocusToItem(e.RowNumber, "bun_name");

                    //    this.SetMsg("");
                    //}
                    #endregion

                    // 2015.06.22 Cloud updated START
                    BAS0203U00LayBunCodeArgs args = new BAS0203U00LayBunCodeArgs();
                    args.Code = e.ChangeValue.ToString();
                    BAS0203U00StringResult res = CloudService.Instance.Submit<BAS0203U00StringResult, BAS0203U00LayBunCodeArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success)
                    {
                        if (res.ResStr == "")
                        {
                            msg = (NetInfo.Language == LangMode.Ko ? "No Data Found.." : "No Data Found..");

                            this.SetMsg(msg, MsgType.Error);

                            e.Cancel = true;
                        }
                        else
                        {
                            this.grdBAS0203.SetItemValue(e.RowNumber, "bun_name", res.ResStr);
                            this.grdBAS0203.SetFocusToItem(e.RowNumber, "bun_name");

                            this.SetMsg("");
                        }
                    }
                    // 2015.06.22 Cloud updated END

                    break;
                case "sg_code":
                    if (this.DupCheck(grdBAS0203.GetItemString(e.RowNumber, "symya_gubun"),
                                      grdBAS0203.GetItemString(e.RowNumber, "yoil_gubun"),
                                      grdBAS0203.GetItemString(e.RowNumber, "bun_code"),
                                      e.ChangeValue.ToString(),
                                      grdBAS0203.GetItemString(e.RowNumber, "jy_date"),
                                      grdBAS0203.GetItemString(e.RowNumber, "from_time")))
                    {
                        msg = (NetInfo.Language == LangMode.Ko ? "동일한 코드가 존재 합니다." : Properties.Resources.TEXT5);

                        this.SetMsg(msg, MsgType.Error);

                        e.Cancel = true;
                    }
                    this.laySgCode.QueryLayout();
                    this.grdBAS0203.SetItemValue(e.RowNumber, "sg_name", this.laySgCode.GetItemValue("sg_name"));
                    break;

                case "jy_date":
                    if (this.DupCheck(grdBAS0203.GetItemString(e.RowNumber, "symya_gubun"),
                                      grdBAS0203.GetItemString(e.RowNumber, "yoil_gubun"),
                                      grdBAS0203.GetItemString(e.RowNumber, "bun_code"),
                                      grdBAS0203.GetItemString(e.RowNumber, "sg_code"),
                                      e.ChangeValue.ToString(),
                                      grdBAS0203.GetItemString(e.RowNumber, "from_time")))
                    {
                        msg = (NetInfo.Language == LangMode.Ko ? "동일한 코드가 존재 합니다." : Properties.Resources.TEXT5);

                        this.SetMsg(msg, MsgType.Error);

                        e.Cancel = true;
                    }
                    break;

                case "from_time":
                    hour = e.ChangeValue.ToString().Substring(0, 2);
                    min = e.ChangeValue.ToString().Substring(2, 2);

                    if (TypeCheck.IsInt(hour) && TypeCheck.IsInt(min))
                    {
                        if ((int.Parse(hour) < 0 || int.Parse(hour) >= 24) ||
                             (int.Parse(min) < 0 || int.Parse(min) >= 60))
                        {
                            msg = (NetInfo.Language == LangMode.Ko ? "시간을 확인하세요" : Properties.Resources.TEXT6);

                            this.SetMsg(msg, MsgType.Error);

                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        msg = (NetInfo.Language == LangMode.Ko ? "시간을 확인하세요" : Properties.Resources.TEXT6);

                        this.SetMsg(msg, MsgType.Error);

                        e.Cancel = true;
                    }

                    if (this.DupCheck(grdBAS0203.GetItemString(e.RowNumber, "symya_gubun"),
                                      grdBAS0203.GetItemString(e.RowNumber, "yoil_gubun"),
                                      grdBAS0203.GetItemString(e.RowNumber, "bun_code"),
                                      grdBAS0203.GetItemString(e.RowNumber, "sg_code"),
                                      grdBAS0203.GetItemString(e.RowNumber, "jy_date"),
                                      e.ChangeValue.ToString()))
                    {
                        msg = (NetInfo.Language == LangMode.Ko ? "동일한 코드가 존재 합니다." : Properties.Resources.TEXT5);

                        this.SetMsg(msg, MsgType.Error);

                        e.Cancel = true;
                    }
                    break;

                case "to_time":
                    hour = e.ChangeValue.ToString().Substring(0, 2);
                    min = e.ChangeValue.ToString().Substring(2, 2);

                    if (TypeCheck.IsInt(hour) && TypeCheck.IsInt(min))
                    {
                        if ((int.Parse(hour) < 0 || int.Parse(hour) >= 24) ||
                               (int.Parse(min) < 0 || int.Parse(min) >= 60))
                        {
                            msg = (NetInfo.Language == LangMode.Ko ? "시간을 확인하세요" : Properties.Resources.TEXT6);

                            this.SetMsg(msg, MsgType.Error);

                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        msg = (NetInfo.Language == LangMode.Ko ? "시간을 확인하세요" : Properties.Resources.TEXT6);

                        this.SetMsg(msg, MsgType.Error);

                        e.Cancel = true;
                    }
                    break;
            }
        }

        private void dtpJukyongDate_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.grdBAS0203.QueryLayout(false);
            }
        }

        private void dtpJukyongDate_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {

                this.JukYongDateCall();

            }
        }

        private void grdBAS0203_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.grdBAS0203.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdBAS0203.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdBAS0203.SetBindVarValue("f_jy_date", this.dtpJukyongDate.GetDataValue());
            this.grdBAS0203.SetBindVarValue("f_symya_gubun", this.fbxSymyaGubun.GetDataValue());
        }

        private void fwkBunCode_QueryStarting(object sender, CancelEventArgs e)
        {
            //fwkBunCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            fwkBunCode.SetBindVarValue("f_hosp_code", this.mHospCode);
            fwkBunCode.SetBindVarValue("f_jy_date", dtpJukyongDate.GetDataValue());
        }

        private void fwkSgCode_QueryStarting(object sender, CancelEventArgs e)
        {
            //fwkSgCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            fwkSgCode.SetBindVarValue("f_hosp_code", this.mHospCode);
            fwkSgCode.SetBindVarValue("f_jy_date", dtpJukyongDate.GetDataValue());
        }

        private void fbxSymyaGubun_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.laySymyaGubun.QueryLayout();
        }

        private void fwkSymyaGubun_QueryStarting(object sender, CancelEventArgs e)
        {
            //fwkSymyaGubun.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            fwkSymyaGubun.SetBindVarValue("f_hosp_code", this.mHospCode);
        }

        private void xHospBox_FindClick(object sender, EventArgs e)
        {
            this.mHospCode = xHospBox.HospCode;
            RefreshScreen();
        }

        private void xHospBox_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (!e.Cancel)
            {
                this.mHospCode = e.DataValue;
                RefreshScreen();
            }
        }

        #endregion

        #region Methods(private)

        public override object Command(string command, CommonItemCollection commandParam)
        {
            // TODO:  BAS0203U00.Command 구현을 추가합니다.

            if (command == "BAS0201")
            {
                dtpJukyongDate.SetEditValue(commandParam["BAS0201"].ToString());
                dtpJukyongDate.AcceptData();
            }

            return base.Command(command, commandParam);
        }

        private bool DupCheck(string aSymyaGubun, string aYoilGbun, string aBunCode, string aSgCode, string aJyDate, string aFromTime)
        {
            int rowNumber = this.grdBAS0203.CurrentRowNumber;
            // 삭제 그리드에서 찾아본다.


            if (this.grdBAS0203.DeletedRowTable != null)
            {
                foreach (DataRow dr in grdBAS0203.DeletedRowTable.Rows)
                {
                    if (dr["symya_gubun"].ToString() == aSymyaGubun &&
                         dr["yoil_gubun"].ToString() == aYoilGbun &&
                         dr["bun_code"].ToString() == aBunCode &&
                         dr["sg_code"].ToString() == aSgCode &&
                         dr["jy_date"].ToString() == aJyDate &&
                         dr["from_time"].ToString() == aFromTime)
                    {
                        return false;
                    }
                }
            }

            // 현재 그리드에서 찾아본다.

            for (int i = 0; i < grdBAS0203.RowCount; i++)
            {
                if (i != rowNumber &&
                    this.grdBAS0203.GetItemString(i, "symya_gubun") == aSymyaGubun &&
                    this.grdBAS0203.GetItemString(i, "yoil_gubun") == aYoilGbun &&
                    this.grdBAS0203.GetItemString(i, "bun_code") == aBunCode &&
                    this.grdBAS0203.GetItemString(i, "sg_code") == aSgCode &&
                    this.grdBAS0203.GetItemString(i, "jy_date") == aJyDate &&
                    this.grdBAS0203.GetItemString(i, "from_time") == aFromTime)
                {
                    return true;
                }
            }

            this.layDupCheck.QueryLayout();

            if (this.layDupCheck.GetItemValue("dup_yn").ToString() == "Y")
            {
                return true;
            }

            this.mIsNewRow = false;

            return false;
        }

        private void JukYongDateCall()
        {
            IHIS.Framework.IXScreen aScreen;
            aScreen = XScreen.FindScreen("BASS", "BAS0201Q00");

            if (aScreen == null)
            {
                CommonItemCollection param = new CommonItemCollection();

                param.Add("table_name", "BAS0203");
                param.Add("col_name", "JY_DATE");

                XScreen.OpenScreenWithParam(this, "BASS", "BAS0201Q00", ScreenOpenStyle.PopUpFixed, param);
            }
            else
            {
                ((XScreen)aScreen).Activate();
            }
        }

        #endregion

        // deleted by Cloud
        #region XSavePeformer
//        private class XSavePeformer : ISavePerformer
//        {
//            private BAS0203U00 parent = null;

//            public XSavePeformer(BAS0203U00 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerId, RowDataItem item)
//            {
//                string cmdText = "";
//                object t_chk = "";

//                item.BindVarList.Add("q_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

//                switch (callerId)
//                {
//                    case '1':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                cmdText = @"SELECT 'Y'
//                                              FROM DUAL
//                                             WHERE EXISTS ( SELECT 'X'
//                                                              FROM BAS0203
//                                                             WHERE HOSP_CODE   = :f_hosp_code 
//                                                               AND SYMYA_GUBUN = :f_symya_gubun
//                                                               AND BUN_CODE    = :f_bun_code
//                                                               AND SG_CODE     = :f_sg_code
//                                                               AND JY_DATE     = :f_jy_date
//                                                               AND YOIL_GUBUN  = :f_yoil_gubun
//                                                               AND FROM_MONTH  = :f_from_month
//                                                               AND TO_MONTH    = :f_to_month
//                                                               AND FROM_TIME   = :f_from_time
//                                                               AND TO_TIME     = :f_to_time   )";

//                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                if (!TypeCheck.IsNull(t_chk))
//                                {
//                                    if (t_chk.ToString() == "Y")
//                                    {
//                                        XMessageBox.Show("「" + item.BindVarList["f_symya_gubun"].VarValue + "」" + Properties.Resources.TEXT7, Properties.Resources.TEXT8, MessageBoxIcon.Warning);
//                                        return false;
//                                    }
//                                }

//                                cmdText = @"INSERT INTO BAS0203
//                                                   ( SYS_DATE         , SYS_ID            , UPD_DATE     , UPD_ID      , HOSP_CODE
//                                                   , JY_DATE          , SYMYA_GUBUN       , BUN_CODE
//                                                   , SG_CODE          , FROM_TIME         , TO_TIME
//                                                   , YOIL_GUBUN       , FROM_MONTH        , TO_MONTH      )
//                                              VALUES
//                                                   ( SYSDATE          , :q_user_id        , SYSDATE       , :q_user_id , :f_hosp_code
//                                                   , :f_jy_date       , :f_symya_gubun    , :f_bun_code
//                                                   , :f_sg_code       , :f_from_time      , :f_to_time
//                                                   , :f_yoil_gubun    , :f_from_month     , :f_to_month    )";

//                                break;

//                            case DataRowState.Modified:

//                                cmdText = @"UPDATE BAS0203
//                                               SET UPD_ID       = :q_user_id
//                                                 , UPD_DATE     = SYSDATE
//                                                 , TO_TIME      = :f_to_time
//                                                 , TO_MONTH     = :f_to_month
//                                             WHERE HOSP_CODE    = :f_hosp_code
//                                               AND SYMYA_GUBUN  = :f_old_symya_gubun
//                                               AND BUN_CODE     = :f_old_bun_code
//                                               AND SG_CODE      = :f_old_sg_code
//                                               AND FROM_TIME    = :f_old_from_time
//                                               AND JY_DATE      = :f_old_jy_date
//                                               AND YOIL_GUBUN   = :f_old_yoil_gubun
//                                               AND FROM_MONTH   = :f_old_from_month
//                                               AND TO_MONTH     = :f_old_to_month
//                                               AND TO_TIME      = :f_old_to_time ";

//                                break;

//                            case DataRowState.Deleted:


//                                cmdText = @"DELETE FROM BAS0203
//                                               WHERE HOSP_CODE   = :f_hosp_code
//                                                 AND SYMYA_GUBUN = :f_old_symya_gubun
//                                                 AND BUN_CODE    = :f_old_bun_code
//                                                 AND SG_CODE     = :f_old_sg_code
//                                                 AND FROM_TIME   = :f_old_from_time
//                                                 AND JY_DATE     = :f_old_jy_date
//                                                 AND YOIL_GUBUN  = :f_old_yoil_gubun
//                                                 AND FROM_MONTH  = :f_old_from_month
//                                                 AND TO_MONTH    = :f_old_to_month
//                                                 AND TO_TIME     = :f_old_to_time   ";

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
            // fwkBunCode
            fwkBunCode.ParamList = new List<string>(new string[] { "f_hosp_code", "f_find1", "f_jy_date" });
            fwkBunCode.ExecuteQuery = GetFwkBunCode;

            // fwkSgCode
            fwkSgCode.ParamList = new List<string>(new string[] { "f_hosp_code", "f_find1", "f_jy_date" });
            fwkSgCode.ExecuteQuery = GetFwkSgCode;

            // fwkSymyaGubun
            fwkSymyaGubun.ParamList = new List<string>(new string[] { "f_hosp_code", "f_find1" });
            fwkSymyaGubun.ExecuteQuery = GetFwkSymyaGubun;

            // grdBAS0203
            grdBAS0203.ParamList = new List<string>(new string[] { "f_hosp_code", "f_jy_date", "f_symya_gubun" });
            grdBAS0203.ExecuteQuery = GetGrdBAS0203;

            // laySgCode
            laySgCode.ParamList = new List<string>(new string[] { "f_hosp_code", "f_sg_ymd", "f_sg_code" });
            laySgCode.ExecuteQuery = GetLaySgCode;

            // layDupCheck
            layDupCheck.ParamList = new List<string>(new string[]
                {
                    "f_hosp_code",
                    "f_symya_gubun",
                    "f_bun_code",
                    "f_sg_code",
                    "f_jy_date",
                    "f_from_time",
                });
            layDupCheck.ExecuteQuery = GetLayDupCheck;

            // laySymyaGubun
            laySymyaGubun.ParamList = new List<string>(new string[] { "f_hosp_code", "f_code" });
            laySymyaGubun.ExecuteQuery = GetLaySymyaGubun;

            // laySymyaGubun2
            laySymyaGubun2.ParamList = new List<string>(new string[] { "f_hosp_code", "f_code" });
            laySymyaGubun2.ExecuteQuery = GetLaySymyaGubun2;
        }
        #endregion

        #region GetFwkBunCode
        /// <summary>
        /// GetFwkBunCode
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetFwkBunCode(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            BAS0203U00FwkBunCodeArgs args = new BAS0203U00FwkBunCodeArgs();
            args.Find1 = bvc["f_find1"].VarValue;
            args.HospCode = this.mHospCode;
            args.JyDate = bvc["f_jy_date"].VarValue;
            ComboResult res = CloudService.Instance.Submit<ComboResult, BAS0203U00FwkBunCodeArgs>(args);

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

        #region GetFwkSgCode
        /// <summary>
        /// GetFwkSgCode
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetFwkSgCode(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            BAS0203U00FwkSgCodeArgs args = new BAS0203U00FwkSgCodeArgs();
            args.Find1 = bvc["f_find1"].VarValue;
            args.HospCode = this.mHospCode;
            args.JyDate = bvc["f_jy_date"].VarValue;
            ComboResult res = CloudService.Instance.Submit<ComboResult, BAS0203U00FwkSgCodeArgs>(args);

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

        #region GetFwkSymyaGubun
        /// <summary>
        /// GetFwkSymyaGubun
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetFwkSymyaGubun(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            BAS0203U00FwkSymyaGubunArgs args = new BAS0203U00FwkSymyaGubunArgs();
            args.Find1 = bvc["f_find1"].VarValue;
            args.HospCode = this.mHospCode;
            ComboResult res = CloudService.Instance.Submit<ComboResult, BAS0203U00FwkSymyaGubunArgs>(args);

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

        #region GetGrdBAS0203
        /// <summary>
        /// GetGrdBAS0203
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdBAS0203(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            BAS0203U00GrdBAS0203Args args = new BAS0203U00GrdBAS0203Args();
            args.HospCode = this.mHospCode;
            args.JyDate = bvc["f_jy_date"].VarValue;
            args.SymyaGubun = bvc["f_symya_gubun"].VarValue;
            BAS0203U00GrdBAS0203Result res = CloudService.Instance.Submit<BAS0203U00GrdBAS0203Result, BAS0203U00GrdBAS0203Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdBas0203Item.ForEach(delegate(BAS0203U00GrdBAS0203Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.JyDate,
                        item.SymyaGubun,
                        item.SymyaGubunName,
                        item.BunCode,
                        item.BunName,
                        item.SgCode,
                        item.SgName,
                        item.FromTime,
                        item.ToTime,
                        item.YoilGubun,
                        item.FromMonth,
                        item.ToMonth,
                        item.OldJyDate,
                        item.OldSymyaGubun,
                        item.OldBunCode,
                        item.OldSgCode,
                        item.OldFromTime,
                        item.OldToTime,
                        item.OldYoilGubun,
                        item.OldFromMonth,
                        item.OldToMonth,
                        item.ContKey,
                    });
                });
            }
            if (NetInfo.Language == LangMode.Jr)
            {
                xEditGridCell1.IsJapanYearType = true;
            }
            return lObj;
        }
        #endregion

        #region GetLaySgCode
        /// <summary>
        /// GetLaySgCode
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLaySgCode(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            BAS0203U00LaySgCodeArgs args = new BAS0203U00LaySgCodeArgs();
            args.HospCode = this.mHospCode;
            args.SgCode = bvc["f_sg_code"].VarValue;
            args.SgYmd = bvc["f_sg_ymd"].VarValue;
            BAS0203U00LaySgCodeResult res = CloudService.Instance.Submit<BAS0203U00LaySgCodeResult, BAS0203U00LaySgCodeArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LaySgCodeItem.ForEach(delegate(DataStringListItemInfo item)
                {
                    lObj.Add(new object[] { item.DataValue });
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
        private List<BAS0203U00GrdBAS0203Info> GetListDataForSaveLayout()
        {
            List<BAS0203U00GrdBAS0203Info> lstData = new List<BAS0203U00GrdBAS0203Info>();

            // For insert/update
            for (int i = 0; i < grdBAS0203.RowCount; i++)
            {
                BAS0203U00GrdBAS0203Info item = new BAS0203U00GrdBAS0203Info();

                item.JyDate                 = grdBAS0203.GetItemString(i, "jy_date");
                item.SymyaGubun             = grdBAS0203.GetItemString(i, "symya_gubun");
                item.SymyaGubunName         = grdBAS0203.GetItemString(i, "symya_gubun_name");
                item.BunCode                = grdBAS0203.GetItemString(i, "bun_code");
                item.BunName                = grdBAS0203.GetItemString(i, "bun_name");
                item.SgCode                 = grdBAS0203.GetItemString(i, "sg_code");
                item.SgName                 = grdBAS0203.GetItemString(i, "sg_name");
                item.FromTime               = grdBAS0203.GetItemString(i, "from_time");
                item.ToTime                 = grdBAS0203.GetItemString(i, "to_time");
                item.YoilGubun              = grdBAS0203.GetItemString(i, "yoil_gubun");
                item.FromMonth              = grdBAS0203.GetItemString(i, "from_month");
                item.ToMonth                = grdBAS0203.GetItemString(i, "to_month");
                item.OldJyDate              = grdBAS0203.GetItemString(i, "old_jy_date");
                item.OldSymyaGubun          = grdBAS0203.GetItemString(i, "old_symya_gubun");
                item.OldBunCode             = grdBAS0203.GetItemString(i, "old_bun_code");
                item.OldSgCode              = grdBAS0203.GetItemString(i, "old_sg_code");
                item.OldFromTime            = grdBAS0203.GetItemString(i, "old_from_time");
                item.OldToTime              = grdBAS0203.GetItemString(i, "old_to_time");
                item.OldYoilGubun           = grdBAS0203.GetItemString(i, "old_yoil_gubun");
                item.OldFromMonth           = grdBAS0203.GetItemString(i, "old_from_month");
                item.OldToMonth             = grdBAS0203.GetItemString(i, "old_to_month");
                //item.ContKey                = grdBAS0203.GetItemString(i, "cont_key");
                item.RowState               = grdBAS0203.GetRowState(i).ToString();

                lstData.Add(item);
            }

            // For delete
            if (null != grdBAS0203.DeletedRowTable)
            {
                foreach (DataRow dr in grdBAS0203.DeletedRowTable.Rows)
                {
                    BAS0203U00GrdBAS0203Info item = new BAS0203U00GrdBAS0203Info();

                    item.JyDate                 = dr["jy_date"].ToString();
                    item.SymyaGubun             = dr["symya_gubun"].ToString();
                    item.SymyaGubunName         = dr["symya_gubun_name"].ToString();
                    item.BunCode                = dr["bun_code"].ToString();
                    item.BunName                = dr["bun_name"].ToString();
                    item.SgCode                 = dr["sg_code"].ToString();
                    item.SgName                 = dr["sg_name"].ToString();
                    item.FromTime               = dr["from_time"].ToString();
                    item.ToTime                 = dr["to_time"].ToString();
                    item.YoilGubun              = dr["yoil_gubun"].ToString();
                    item.FromMonth              = dr["from_month"].ToString();
                    item.ToMonth                = dr["to_month"].ToString();
                    item.OldJyDate              = dr["old_jy_date"].ToString();
                    item.OldSymyaGubun          = dr["old_symya_gubun"].ToString();
                    item.OldBunCode             = dr["old_bun_code"].ToString();
                    item.OldSgCode              = dr["old_sg_code"].ToString();
                    item.OldFromTime            = dr["old_from_time"].ToString();
                    item.OldToTime              = dr["old_to_time"].ToString();
                    item.OldYoilGubun           = dr["old_yoil_gubun"].ToString();
                    item.OldFromMonth           = dr["old_from_month"].ToString();
                    item.OldToMonth             = dr["old_to_month"].ToString();
                    //item.ContKey                = dr["cont_key"].ToString();
                    item.RowState               = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #region GetLayDupCheck
        /// <summary>
        /// GetLayDupCheck
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayDupCheck(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            BAS0203U00LayDupCheckArgs args  = new BAS0203U00LayDupCheckArgs();
            args.BunCode                    = bvc["f_bun_code"].VarValue;
            args.FromTime                   = bvc["f_from_time"].VarValue;
            args.HospCode                   = bvc["f_hosp_code"].VarValue;
            args.JyDate                     = bvc["f_jy_date"].VarValue;
            args.SgCode                     = bvc["f_sg_code"].VarValue;
            args.SymyaGubun                 = bvc["f_symya_gubun"].VarValue;
            BAS0203U00StringResult res = CloudService.Instance.Submit<BAS0203U00StringResult, BAS0203U00LayDupCheckArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                lObj.Add(new object[] { res.ResStr });
            }

            return lObj;
        }
        #endregion

        #region GetLaySymyaGubun
        /// <summary>
        /// GetLaySymyaGubun
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLaySymyaGubun(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            BAS0203U00LaySymyaGubunArgs args = new BAS0203U00LaySymyaGubunArgs();
            args.Code = bvc["f_code"].VarValue;
            args.HospCode = bvc["f_hosp_code"].VarValue;
            BAS0203U00StringResult res = CloudService.Instance.Submit<BAS0203U00StringResult, BAS0203U00LaySymyaGubunArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                lObj.Add(new object[] { res.ResStr });
            }

            return lObj;
        }
        #endregion

        #region GetLaySymyaGubun2
        /// <summary>
        /// GetLaySymyaGubun2
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLaySymyaGubun2(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            BAS0203U00LaySymyaGubunArgs args = new BAS0203U00LaySymyaGubunArgs();
            args.Code = bvc["f_code"].VarValue;
            args.HospCode = bvc["f_hosp_code"].VarValue;
            BAS0203U00StringResult res = CloudService.Instance.Submit<BAS0203U00StringResult, BAS0203U00LaySymyaGubunArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                lObj.Add(new object[] { res.ResStr });
            }

            return lObj;
        }
        #endregion

        #region SetYoilCbo
        /// <summary>
        /// SetYoilCbo
        /// </summary>
        private void SetYoilCbo(string hospCode)
        {
            DataTable dt = new DataTable();

            BAS0203U00CboYoilGubunArgs args = new BAS0203U00CboYoilGubunArgs();
            args.HospCode = hospCode;
            ComboResult res = CloudService.Instance.Submit<ComboResult, BAS0203U00CboYoilGubunArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success && res.ComboItem.Count > 0)
            {
                dt = Utility.ConvertToDataTable(res.ComboItem);
            }

            grdBAS0203.SetComboItems("yoil_gubun", dt, "code_name", "code");
        }
        #endregion

        #region RefreshScreen
        /// <summary>
        /// RefreshScreen
        /// </summary>
        private void RefreshScreen()
        {
            this.grdBAS0203.QueryLayout(true);
            SetYoilCbo(this.mHospCode);
        }
        #endregion

        #endregion
    }
}

