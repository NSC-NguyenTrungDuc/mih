#region namespace
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.ADMA.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Adma;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
#endregion

namespace IHIS.ADMA
{
    /// <summary>
    /// ADM106Uｿ｡ ｴ・ﾑ ｿ萓・ｼｳｸ暲ﾔｴﾏｴﾙ.
    /// </summary>
    [ToolboxItem(false)]
    public class ADMS2015U00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XTreeView menuTree;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XEditGrid grdSystemList;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XDisplayBox dbxHospitalNm;
        private IHIS.Framework.XFindBox fbxHospitalID;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.FindColumnInfo findColumnInfo3;
        private IHIS.Framework.FindColumnInfo findColumnInfo4;
        private IHIS.Framework.FindColumnInfo findColumnInfo5;
        private IHIS.Framework.FindColumnInfo findColumnInfo6;
        private IHIS.Framework.XFindWorker fwkSysID;
        private IHIS.Framework.FindColumnInfo findColumnInfo7;
        private IHIS.Framework.FindColumnInfo findColumnInfo8;
        private IHIS.Framework.XFindWorker fwkPgmID;
        private MultiLayout layTreeQuery;
        private XButton btnSysUp;
        private XButton btnSysDown;
        private XPanel xPanel3;
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
        private MultiLayout layTreeChild;
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
        private XPanel xPanel4;
        private XPanel xPanel5;
        private XButton btnGrpDown;
        private XButton btnGrpUp;
        private XEditGrid grdGroupList;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private System.ComponentModel.IContainer components;
        private ADMS2015U00LoadGroupSystemHospitalResult groupSystemHospitalResult;

        public ADMS2015U00()
        {
            InitializeComponent();

            #region 저장용 Save Performer 지정

            //this.grdMenuList.SavePerformer = new XSavePerformer(this);

            #endregion

            //set Paramlist
            this.fwkPgmID.ParamList = new List<string>(new String[] { "f_pgm_id" });
            this.layTreeQuery.ParamList = new List<string>(new String[] { "f_sys_id", "f_upper_menu" });
            this.layTreeChild.ParamList = new List<string>(new String[] { "f_sys_id", "f_upper_menu" });
            this.grdSystemList.ParamList = new List<string>(new String[] { "f_adms_group_id"});

            //set ExecuteQuery
            this.fwkPgmID.ExecuteQuery = LoadDataFwkPgmID;
            this.fwkSysID.ExecuteQuery = LoadDataFwkHospitalID;
            this.grdSystemList.ExecuteQuery = LoadDataMakeQuery;
            this.layTreeQuery.ExecuteQuery = LoadDataMakeQuery;
            this.layTreeChild.ExecuteQuery = LoadDataMakeQuery;
            this.grdGroupList.ExecuteQuery = LoadGrdGroupList;
        }

        /// <summary>
        /// Dispose 구현
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
        /// 디자이너에서 생성한 코드들
        /// 원래 글자가 깨졌어요
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADMS2015U00));
            this.grdSystemList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.fwkPgmID = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.fbxHospitalID = new IHIS.Framework.XFindBox();
            this.fwkSysID = new IHIS.Framework.XFindWorker();
            this.findColumnInfo7 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo8 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo5 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo6 = new IHIS.Framework.FindColumnInfo();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.dbxHospitalNm = new IHIS.Framework.XDisplayBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.layTreeQuery = new IHIS.Framework.MultiLayout();
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
            this.btnSysUp = new IHIS.Framework.XButton();
            this.btnSysDown = new IHIS.Framework.XButton();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.btnGrpDown = new IHIS.Framework.XButton();
            this.btnGrpUp = new IHIS.Framework.XButton();
            this.grdGroupList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.layTreeChild = new IHIS.Framework.MultiLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.grdSystemList)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layTreeQuery)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupList)).BeginInit();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layTreeChild)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "닫힌폴더.gif");
            this.ImageList.Images.SetKeyName(1, "열린폴더.gif");
            this.ImageList.Images.SetKeyName(2, "보기.gif");
            // 
            // grdSystemList
            // 
            this.grdSystemList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell8,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdSystemList.ColPerLine = 3;
            this.grdSystemList.Cols = 4;
            resources.ApplyResources(this.grdSystemList, "grdSystemList");
            this.grdSystemList.ExecuteQuery = null;
            this.grdSystemList.FixedCols = 1;
            this.grdSystemList.FixedRows = 1;
            this.grdSystemList.HeaderHeights.Add(37);
            this.grdSystemList.Name = "grdSystemList";
            this.grdSystemList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSystemList.ParamList")));
            this.grdSystemList.RowHeaderVisible = true;
            this.grdSystemList.Rows = 2;
            this.grdSystemList.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdSystemList_GridColumnChanged);
            this.grdSystemList.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdSystemList_SaveEnd);
            this.grdSystemList.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdSystemList_GridColumnProtectModify);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "adms_group_system_id";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "system_seq";
            this.xEditGridCell2.CellWidth = 84;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "hosp_code";
            this.xEditGridCell8.CellWidth = 61;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderBackColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xEditGridCell8.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AutoTabDataSelected = true;
            this.xEditGridCell3.CellName = "select_flg";
            this.xEditGridCell3.CellWidth = 30;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.FindWorker = this.fwkPgmID;
            this.xEditGridCell3.HeaderBackColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xEditGridCell3.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell3.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkPgmID
            // 
            this.fwkPgmID.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkPgmID.ExecuteQuery = null;
            this.fwkPgmID.FormText = global::IHIS.ADMA.Properties.Resources.TEXT3;
            this.fwkPgmID.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkPgmID.ParamList")));
            this.fwkPgmID.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "pgm_id";
            this.findColumnInfo3.ColWidth = 116;
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "pgm_nm";
            this.findColumnInfo4.ColWidth = 301;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 20;
            this.xEditGridCell4.CellName = "system_id";
            this.xEditGridCell4.CellWidth = 129;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 20;
            this.xEditGridCell5.CellName = "sys_nm";
            this.xEditGridCell5.CellWidth = 267;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderBackColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xEditGridCell5.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell5.IsReadOnly = true;
            // 
            // fbxHospitalID
            // 
            this.fbxHospitalID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxHospitalID.FindWorker = this.fwkSysID;
            resources.ApplyResources(this.fbxHospitalID, "fbxHospitalID");
            this.fbxHospitalID.Name = "fbxHospitalID";
            this.fbxHospitalID.Validating += new System.ComponentModel.CancelEventHandler(this.fbxHospitalID_Validating);
            this.fbxHospitalID.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxID_FindSelected);
            // 
            // fwkSysID
            // 
            this.fwkSysID.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo7,
            this.findColumnInfo8});
            this.fwkSysID.ExecuteQuery = null;
            this.fwkSysID.FormText = global::IHIS.ADMA.Properties.Resources.TEXT4;
            this.fwkSysID.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkSysID.ParamList")));
            this.fwkSysID.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            // 
            // findColumnInfo7
            // 
            this.findColumnInfo7.ColName = "sys_id";
            this.findColumnInfo7.ColWidth = 116;
            this.findColumnInfo7.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo7, "findColumnInfo7");
            // 
            // findColumnInfo8
            // 
            this.findColumnInfo8.ColName = "sys_nm";
            this.findColumnInfo8.ColWidth = 210;
            this.findColumnInfo8.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo8, "findColumnInfo8");
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "sysID";
            this.findColumnInfo1.ColWidth = 99;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "sysNM";
            this.findColumnInfo2.ColWidth = 235;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // findColumnInfo5
            // 
            this.findColumnInfo5.ColName = "pgmID";
            this.findColumnInfo5.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo5, "findColumnInfo5");
            // 
            // findColumnInfo6
            // 
            this.findColumnInfo6.ColName = "pgmNM";
            this.findColumnInfo6.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo6, "findColumnInfo6");
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
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.dbxHospitalNm);
            this.xPanel2.Controls.Add(this.fbxHospitalID);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Name = "xPanel2";
            // 
            // dbxHospitalNm
            // 
            resources.ApplyResources(this.dbxHospitalNm, "dbxHospitalNm");
            this.dbxHospitalNm.Name = "dbxHospitalNm";
            // 
            // xLabel1
            // 
            this.xLabel1.BackColor = IHIS.Framework.XColor.XScreenBackColor;
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // layTreeQuery
            // 
            this.layTreeQuery.ExecuteQuery = null;
            this.layTreeQuery.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10});
            this.layTreeQuery.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layTreeQuery.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "sys_id";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "tr_id";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "tr_seq";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "pgm_id";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "upper_menu";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "pgm_nm";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "pgm_tp";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "pgm_open_tp";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "short_cut";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "menu_param";
            // 
            // btnSysUp
            // 
            this.btnSysUp.Image = ((System.Drawing.Image)(resources.GetObject("btnSysUp.Image")));
            resources.ApplyResources(this.btnSysUp, "btnSysUp");
            this.btnSysUp.Name = "btnSysUp";
            this.btnSysUp.Click += new System.EventHandler(this.btnSysUp_Click);
            // 
            // btnSysDown
            // 
            this.btnSysDown.Image = ((System.Drawing.Image)(resources.GetObject("btnSysDown.Image")));
            resources.ApplyResources(this.btnSysDown, "btnSysDown");
            this.btnSysDown.Name = "btnSysDown";
            this.btnSysDown.Click += new System.EventHandler(this.btnSysDown_Click);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xPanel4);
            this.xPanel3.Controls.Add(this.xPanel5);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.btnGrpDown);
            this.xPanel4.Controls.Add(this.btnGrpUp);
            this.xPanel4.Controls.Add(this.grdGroupList);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Name = "xPanel4";
            // 
            // btnGrpDown
            // 
            this.btnGrpDown.Image = ((System.Drawing.Image)(resources.GetObject("btnGrpDown.Image")));
            resources.ApplyResources(this.btnGrpDown, "btnGrpDown");
            this.btnGrpDown.Name = "btnGrpDown";
            this.btnGrpDown.Click += new System.EventHandler(this.btnGrpDown_Click);
            // 
            // btnGrpUp
            // 
            this.btnGrpUp.Image = ((System.Drawing.Image)(resources.GetObject("btnGrpUp.Image")));
            resources.ApplyResources(this.btnGrpUp, "btnGrpUp");
            this.btnGrpUp.Name = "btnGrpUp";
            this.btnGrpUp.Click += new System.EventHandler(this.btnGrpUp_Click);
            // 
            // grdGroupList
            // 
            this.grdGroupList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14});
            this.grdGroupList.ColPerLine = 3;
            this.grdGroupList.Cols = 4;
            resources.ApplyResources(this.grdGroupList, "grdGroupList");
            this.grdGroupList.ExecuteQuery = null;
            this.grdGroupList.FixedCols = 1;
            this.grdGroupList.FixedRows = 1;
            this.grdGroupList.HeaderHeights.Add(37);
            this.grdGroupList.Name = "grdGroupList";
            this.grdGroupList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdGroupList.ParamList")));
            this.grdGroupList.RowHeaderVisible = true;
            this.grdGroupList.Rows = 2;
            this.grdGroupList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdGroupList_RowFocusChanged);
            this.grdGroupList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdGroupList_QueryStarting);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "adms_group_id";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "grp_seq";
            this.xEditGridCell10.CellWidth = 84;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "hosp_code";
            this.xEditGridCell11.CellWidth = 61;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderBackColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xEditGridCell11.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "select_flg";
            this.xEditGridCell12.CellWidth = 30;
            this.xEditGridCell12.Col = 1;
            this.xEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderBackColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xEditGridCell12.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell12.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 20;
            this.xEditGridCell13.CellName = "grp_id";
            this.xEditGridCell13.CellWidth = 128;
            this.xEditGridCell13.Col = 2;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 20;
            this.xEditGridCell14.CellName = "grp_nm";
            this.xEditGridCell14.CellWidth = 224;
            this.xEditGridCell14.Col = 3;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderBackColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
            this.xEditGridCell14.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell14.IsReadOnly = true;
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.btnSysDown);
            this.xPanel5.Controls.Add(this.btnSysUp);
            this.xPanel5.Controls.Add(this.grdSystemList);
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.Name = "xPanel5";
            // 
            // layTreeChild
            // 
            this.layTreeChild.ExecuteQuery = null;
            this.layTreeChild.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20});
            this.layTreeChild.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layTreeChild.ParamList")));
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "sys_id";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "tr_id";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "tr_seq";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "pgm_id";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "upper_menu";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "pgm_nm";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "pgm_tp";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "pgm_open_tp";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "short_cut";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "menu_param";
            // 
            // ADMS2015U00
            // 
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "ADMS2015U00";  
           
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ADMS2015U00_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSystemList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layTreeQuery)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupList)).EndInit();
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layTreeChild)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region MakeQuery

        //private string MakeQuery(string aSysID, string aUpperMenu)
        //{
        //    string queryText = " SELECT A.SYS_ID "
        //                    + "      , A.TR_ID "
        //                    + "      , A.TR_SEQ "
        //                    + "      , A.PGM_ID "
        //                    + "      , A.UPPR_MENU "
        //                    + "      , NVL(A.MENU_TITLE, B.PGM_NM) PGM_NM "
        //                    + "      , B.PGM_TP "
        //                    + "      , A.PGM_OPEN_TP "
        //                    + "      , A.SHORT_CUT "
        //                    + "      , A.MENU_PARAM "
        //                    + "   FROM ADM0300 B, ADM4100 A "
        //                    + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'"
        //                    + "    AND A.PGM_ID    = B.PGM_ID "
        //                    + "    AND A.SYS_ID    = '" + aSysID + "'";

        //    if (aUpperMenu == "")
        //    {
        //        queryText += "    AND A.UPPR_MENU IS NULL ";
        //    }
        //    else
        //    {
        //        queryText += "    AND NVL(A.UPPR_MENU,'x') = NVL('" + aUpperMenu + "','x')";
        //    }

        //    queryText += "    ORDER BY A.TR_SEQ ";

        //    return queryText;
        //}

        #endregion

        #region Query Grid Data

        private void QueryGridData(string aSysid, TreeNode aSelectedNode)
        {
            if (aSelectedNode == null) return;

            string uppermenu = ((Hashtable)aSelectedNode.Tag)["tr_id"].ToString();
            //this.grdMenuList.QuerySQL = this.MakeQuery(aSysid, uppermenu);

            this.grdSystemList.SetBindVarValue("f_sys_id", aSysid);
            this.grdSystemList.SetBindVarValue("f_upper_menu", uppermenu);

            this.grdSystemList.QueryLayout(true);
        }

        #endregion

        #region TreeMake

        private void MakeMenuTreeRoot(string aSysid)
        {
            Hashtable nodeInfo;
            TreeNode rootnode;
            TreeNode childnode;
            this.menuTree.Nodes.Clear();

            rootnode = new TreeNode(this.dbxHospitalNm.GetDataValue(), 0, 1);
            nodeInfo = new Hashtable();
            nodeInfo.Add("sys_id", aSysid);
            nodeInfo.Add("tr_id", "");
            nodeInfo.Add("pgm_id", "");
            nodeInfo.Add("pgm_tp", "M");
            rootnode.Tag = nodeInfo;

            menuTree.Nodes.Add(rootnode);

            //this.layTreeQuery.QuerySQL = this.MakeQuery(aSysid, "");
            this.layTreeQuery.SetBindVarValue("f_sys_id", aSysid);
            this.layTreeQuery.SetBindVarValue("f_upper_menu", "");

            this.layTreeQuery.QueryLayout(true);

            //MessageBox.Show(this.layTreeQuery.GetItemString(0, "pgm_nm"));

            foreach (DataRow dr in this.layTreeQuery.LayoutTable.Rows)
            {
                if (dr["pgm_tp"].ToString() == "M")
                    childnode = new TreeNode(dr["pgm_nm"].ToString(), 0, 1);
                else
                    childnode = new TreeNode(dr["pgm_nm"].ToString(), 2, 2);

                nodeInfo = new Hashtable();
                nodeInfo.Add("sys_id", aSysid);
                nodeInfo.Add("tr_id", dr["tr_id"].ToString());
                nodeInfo.Add("pgm_id", dr["pgm_id"].ToString());
                nodeInfo.Add("pgm_tp", dr["pgm_tp"].ToString());

                childnode.Tag = nodeInfo;

                MakeMenuTreeChild(aSysid, childnode);

                rootnode.Nodes.Add(childnode);
            }

            rootnode.Expand();

            //menuTree.ExpandAll();

        }

        private void MakeMenuTreeChild(string aSysid, TreeNode aParent)
        {
            Hashtable nodeInfo;
            TreeNode childnode;
            string upperMenu = "";

            if (aParent == null) return;

            aParent.Nodes.Clear();

            upperMenu = ((Hashtable)aParent.Tag)["tr_id"].ToString();

            //this.layTreeChild.QuerySQL = this.MakeQuery(aSysid, upperMenu);
            this.layTreeChild.SetBindVarValue("f_sys_id", aSysid);
            this.layTreeChild.SetBindVarValue("f_upper_menu", upperMenu);

            this.layTreeChild.QueryLayout(true);

            foreach (DataRow dr in this.layTreeChild.LayoutTable.Rows)
            {
                if (dr["pgm_tp"].ToString() == "M")
                    childnode = new TreeNode(dr["pgm_nm"].ToString(), 0, 1);
                else
                    childnode = new TreeNode(dr["pgm_nm"].ToString(), 2, 2);

                nodeInfo = new Hashtable();
                nodeInfo.Add("sys_id", aSysid);
                nodeInfo.Add("tr_id", dr["tr_id"].ToString());
                nodeInfo.Add("pgm_id", dr["pgm_id"].ToString());
                nodeInfo.Add("pgm_tp", dr["pgm_tp"].ToString());

                childnode.Tag = nodeInfo;

                aParent.Nodes.Add(childnode);
            }
        }

        #endregion

        #region MenuTree EventHandler
        private void menuTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            this.CurrMQLayout = this.grdSystemList;

            this.QueryGridData(this.fbxHospitalID.GetDataValue(), e.Node);

            this.menuTree.SelectedNode.Expand();
        }
        #endregion

        #region	grdMenuList Event

        private void grdSystemList_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName == "pgm_open_tp")
            {
                if (e.DataRow["pgm_id"].ToString().Substring(e.DataRow["pgm_id"].ToString().Length - 1, 1) == "M")
                    e.Protect = true;
                else
                    e.Protect = false;
            }
        }

        private void grdSystemList_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            string cmdText = "";
            object retVal = "";
            switch (e.ColName)
            {
                case "pgm_id":
                    //cmdText
                    //    = "SELECT PGM_NM FROM ADM0300 "
                    //    + " WHERE PGM_ID  = '" + this.grdMenuList.GetItemString(this.grdMenuList.CurrentRowNumber, "pgm_id") + "'";

                    //retVal = Service.ExecuteScalar(cmdText);

                    ADM106UGetPgmNameArgs args = new ADM106UGetPgmNameArgs(this.grdSystemList.GetItemString(this.grdSystemList.CurrentRowNumber, "pgm_id"));
                    ADM106UGetPgmNameResult result =
                        CloudService.Instance.Submit<ADM106UGetPgmNameResult, ADM106UGetPgmNameArgs>(args);

                    //if (retVal == null)
                    if (String.IsNullOrEmpty(result.PgmNm))
                    {
                        XMessageBox.Show(Resources.TEXT5, Resources.TEXT6, MessageBoxIcon.Information);
                        this.grdSystemList.SetFocusToItem(this.grdSystemList.CurrentRowNumber, "pgm_id");
                    }
                    else
                    {
                        //this.grdMenuList.SetItemValue(this.grdMenuList.CurrentRowNumber, "pgm_nm", retVal.ToString());
                        this.grdSystemList.SetItemValue(this.grdSystemList.CurrentRowNumber, "pgm_nm", result.PgmNm);
                    }
                    break;
                default:
                    break;
            }

        }

        private void grdSystemList_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (!e.IsSuccess)
            {
                XMessageBox.Show(e.ErrMsg + " " + Service.ErrFullMsg, Resources.TEXT2, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Update 관련

        private void ReMakeSeq()
        {
            for (int i = 0; i < this.grdGroupList.RowCount; i++)
            {
                if (this.grdGroupList.GetItemString(i, "grp_seq") != (i + 1).ToString() ||
                    this.grdGroupList.GetItemString(i, "grp_seq") == "")
                {
                    this.grdGroupList.SetItemValue(i, "grp_seq", i + 1);
                }
            }

            for (int i = 0; i < this.grdSystemList.RowCount; i++)
            {
                if (this.grdSystemList.GetItemString(i, "system_seq") != (i + 1).ToString() ||
                    this.grdSystemList.GetItemString(i, "system_seq") == "")
                {
                    this.grdSystemList.SetItemValue(i, "system_seq", i + 1);
                }
            }
        }

        #endregion

        #region XButtonList
        // 버튼 리스트 관련 이벤트
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            //string cmdText = "";

            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;
                    groupSystemHospitalResult = LoadScreenDataByHospital();

                    this.grdGroupList.QueryLayout(true);

                    this.grdSystemList.ExecuteQuery = LoadGrdSystemListGrouped;

                    this.grdSystemList.QueryLayout(true);

                    break;
                case FunctionType.Update:

                    this.AcceptData();

                    // TR_SEQ 순번 재조정
                    this.ReMakeSeq();

                    //if (this.grdMenuList.SaveLayout())
                    if (SaveGrdList())
                    {
                        e.IsSuccess = true;
                        XMessageBox.Show(Resources.MSG_SAVE_SUCCESS, Resources.TEXT6, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //xButtonList1.PerformClick(FunctionType.Query);
                        this.grdSystemList.QueryLayout(true);

                    }
                    else
                    {
                        e.IsSuccess = false;
                        XMessageBox.Show(Resources.MSG_SAVE_ERROR, Resources.TEXT2, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
            }
        }



        #endregion

        #region 행변경

        private void ChangeGridRow(XEditGrid grid, int aFromRow, int aToRow)
        {

            MultiLayout tempLay = grid.CloneToLayout();
            foreach (DataRow dr in grid.LayoutTable.Rows)
            {
                tempLay.LayoutTable.ImportRow(dr);
            }

            grid.LayoutTable.Rows.Clear();

            int currentColNum = (grid.CurrentColNumber < 0 ? 0 : grid.CurrentColNumber);


            for (int i = 0; i < tempLay.LayoutTable.Rows.Count; i++)
            {
                if (aFromRow == i) continue;

                if (aToRow == i)
                {
                    // 위로 올릴때
                    if (aFromRow > aToRow)
                    {
                        grid.LayoutTable.ImportRow(tempLay.LayoutTable.Rows[aFromRow]);
                        grid.LayoutTable.ImportRow(tempLay.LayoutTable.Rows[aToRow]);
                    }
                    // 밑으로 내릴때
                    else
                    {
                        grid.LayoutTable.ImportRow(tempLay.LayoutTable.Rows[aToRow]);
                        grid.LayoutTable.ImportRow(tempLay.LayoutTable.Rows[aFromRow]);
                    }
                }
                else
                {
                    grid.LayoutTable.ImportRow(tempLay.LayoutTable.Rows[i]);
                }
            }

            grid.DisplayData();
            grid.SetFocusToItem(aToRow, currentColNum, false);
        }

        #endregion

        #region XFindBox

        private void fbxID_FindSelected(object sender, FindEventArgs e)
        {
            XFindBox control = (XFindBox)sender;
            XDisplayBox dbxBox = this.dbxHospitalNm;
            dbxBox = this.dbxHospitalNm;
            if (TypeCheck.IsNull(e.ReturnValues) == true)
            {
                dbxBox.SetDataValue("");
            }
            else
            {
                dbxBox.SetDataValue(e.ReturnValues[1].ToString());
            }
        }

        private void fbxHospitalID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            groupSystemHospitalResult = this.LoadScreenDataByHospital();
            this.grdGroupList.QueryLayout(true);
            this.grdSystemList.ExecuteQuery = LoadGrdSystemListGrouped;
            this.grdSystemList.QueryLayout(true);
        }

        #endregion

        #region XSavePerformer

        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {

            private ADMS2015U00 parent = null;


            public XSavePerformer(ADMS2015U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                object retVal = "";

                item.BindVarList.Add("f_q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_q_user_trm", Service.ClientIP.Substring(Service.ClientIP.Length - 6, 6));

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                #region Insert
                                cmdText
                                    = " SELECT MAX(TO_NUMBER(NVL(TR_ID,'0'))) + 1 FROM ADM4100 "
                                    + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "'"
                                    + "    AND SYS_ID = '" + item.BindVarList["f_sys_id"].VarValue + "'";

                                retVal = Service.ExecuteScalar(cmdText);

                                if (retVal == null)
                                {
                                    XMessageBox.Show(" TR_ID 生成に失敗しました。", "保存失敗", MessageBoxIcon.Error);
                                    return false;
                                }

                                string trID = retVal.ToString().PadLeft(5, '0');

                                cmdText
                                    = "   INSERT INTO ADM4100 (SYS_ID, TR_ID, PGM_ID, TR_SEQ, UPPR_MENU, PGM_OPEN_TP, "
                                    + "                        MENU_PARAM, MENU_TITLE, CR_MEMB, CR_TRM,   CR_TIME  , HOSP_CODE )  "
                                    + "                VALUES (:f_sys_id, '" + trID + "', :f_pgm_id, :f_tr_seq, :f_uppr_menu, :f_pgm_open_tp,"
                                    + "                        '', :f_pgm_nm, :f_q_user_id, :f_q_user_trm, SYSDATE ,'" + EnvironInfo.HospCode + "') ";

                                break;
                                #endregion
                            case DataRowState.Modified:
                                #region Update
                                cmdText
                                    = " UPDATE ADM4100 "
                                    + "    SET PGM_ID      = :f_pgm_id, "
                                    + "        MENU_TITLE  = :f_pgm_nm, "
                                    + "        TR_SEQ      = :f_tr_seq, "
                                    + "        UPPR_MENU   = :f_uppr_menu, "
                                    + "        PGM_OPEN_TP = :f_pgm_open_tp, "
                                    //+ "        MENU_PARAM  = :f_menu_param, "
                                    + "        UP_MEMB     = :f_q_user_id,"
                                    + "        UP_TRM      = :f_q_user_trm, "
                                    + "        UP_TIME     = SYSDATE"
                                    + "  WHERE HOSP_CODE   = '" + EnvironInfo.HospCode + "'"
                                    + "    AND SYS_ID      = :f_sys_id "
                                    + "    AND TR_ID       = :f_tr_id ";
                                break;
                                #endregion
                            case DataRowState.Deleted:
                                #region Delete
                                cmdText
                                    = "DELETE ADM4100 "
                                    + " WHERE SYS_ID = :f_sys_id "
                                    + "   AND TR_ID  = :f_tr_id ";

                                if (Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    cmdText = " SELECT 'X' FROM ADM4100 "
                                            + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "'"
                                            + "    AND SYS_ID = :f_sys_id AND UPPR_MENU = :f_tr_id ";
                                    retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                                    if (retVal == null)
                                    {
                                        cmdText = "";
                                    }
                                    else
                                    {
                                        if (retVal.ToString() == "X")
                                        {
                                            cmdText
                                                = " DELETE ADM4100 "
                                                + "  WHERE SYS_ID = :f_sys_id "
                                                + "    AND UPPR_MENU = :f_tr_id ";
                                        }
                                    }
                                }
                                else
                                {
                                    XMessageBox.Show("Delete Failed.");
                                    return false;
                                }
                                break;
                                #endregion
                        }

                        if (cmdText != "")
                        {
                            if (Service.ExecuteNonQuery(cmdText, item.BindVarList))
                            {
                                cmdText
                                    = "UPDATE ADM4310 "
                                    + "   SET MENU_GEN_YN = 'N' "
                                    + "  WHERE HOSP_CODE   = '" + EnvironInfo.HospCode + "'"
                                    + "    AND SYS_ID      = :f_sys_id "
                                    ;

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);
                                return true;
                            }
                            else
                            {
                                XMessageBox.Show("Failed");
                                return false;
                            }
                        }
                        else
                        {
                            cmdText
                                = "UPDATE ADM4310 "
                                + "   SET MENU_GEN_YN  = 'N' "
                                + "  WHERE HOSP_CODE   = '" + EnvironInfo.HospCode + "'"
                                + "    AND SYS_ID      = :f_sys_id "
                                ;

                            Service.ExecuteNonQuery(cmdText, item.BindVarList);
                            return true;
                        }
                    default:    // CallerID ﾀ・ﾞ ｽﾇﾆﾐ 
                        break;
                }
                return true;
            }
        }
        #endregion

        #region XButton

        private void btnSysDown_Click(object sender, EventArgs e)
        {
            if (this.grdSystemList.RowCount == 0 ||
                this.grdSystemList.CurrentRowNumber == this.grdSystemList.RowCount - 1 ||
                this.grdSystemList.CurrentRowNumber < 0)
            {
                return;
            }

            this.ChangeGridRow(this.grdSystemList, this.grdSystemList.CurrentRowNumber, this.grdSystemList.CurrentRowNumber + 1);

        }

        private void btnSysUp_Click(object sender, EventArgs e)
        {
            if (this.grdSystemList.RowCount == 0 ||
                this.grdSystemList.CurrentRowNumber == 0 ||
                this.grdSystemList.CurrentRowNumber < 0) return;

            this.ChangeGridRow(this.grdSystemList, this.grdSystemList.CurrentRowNumber, this.grdSystemList.CurrentRowNumber - 1);
        }

        #endregion

        private void ADMS2015U00_Load(object sender, EventArgs e)
        {
            this.fbxHospitalID.Focus();
        }

        private void grdGroupList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdGroupList.SetBindVarValue("f_hosp_code", this.fbxHospitalID.Text);
        }

        private void grdGroupList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.grdSystemList.ExecuteQuery = LoadGrdSystemList;
            this.grdSystemList.SetBindVarValue("f_adms_group_id", grdGroupList.GetItemString(grdGroupList.CurrentRowNumber, "grp_id"));
            grdSystemList.QueryLayout(true);
        }

        private void btnGrpDown_Click(object sender, EventArgs e)
        {
            if (this.grdGroupList.RowCount == 0 ||
                this.grdGroupList.CurrentRowNumber == this.grdGroupList.RowCount - 1 ||
                this.grdGroupList.CurrentRowNumber < 0)
            {
                return;
            }

            this.ChangeGridRow(this.grdGroupList, this.grdGroupList.CurrentRowNumber, this.grdGroupList.CurrentRowNumber + 1);
        }

        private void btnGrpUp_Click(object sender, EventArgs e)
        {
            if (this.grdGroupList.RowCount == 0 ||
                this.grdGroupList.CurrentRowNumber == 0 ||
                this.grdGroupList.CurrentRowNumber < 0) return;

            this.ChangeGridRow(this.grdGroupList, this.grdGroupList.CurrentRowNumber, this.grdGroupList.CurrentRowNumber - 1);
        }

        #region cloud services

        private IList<object[]> LoadDataFwkHospitalID(BindVarCollection varlist)
        {
            List<object[]> res = new List<object[]>();
            ADM103UGetFwkHospitalArgs args = new ADM103UGetFwkHospitalArgs();
            ADM103UGetFwkHospitalResult result = CloudService.Instance.Submit<ADM103UGetFwkHospitalResult, ADM103UGetFwkHospitalArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.HospList)
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

        private List<object[]> LoadDataFwkPgmID(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM106UFwkPgmIDArgs args = new ADM106UFwkPgmIDArgs();
            args.PgmId = bc["f_pgm_id"] != null ? bc["f_pgm_id"].VarValue : "";
            ADM106UFwkPgmIDResult result = CloudService.Instance.Submit<ADM106UFwkPgmIDResult, ADM106UFwkPgmIDArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.FwkList)
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

        private List<object[]> LoadDataMakeQuery(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM106UMakeQueryListItemArgs args = new ADM106UMakeQueryListItemArgs();
            args.SysId = bc["f_sys_id"] != null ? bc["f_sys_id"].VarValue : "";
            args.UpperMenu = bc["f_upper_menu"] != null ? bc["f_upper_menu"].VarValue : "";
            ADM106UMakeQueryListItemResult result = CloudService.Instance.Submit<ADM106UMakeQueryListItemResult, ADM106UMakeQueryListItemArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADM106UMakeQueryListItemInfo item in result.ListInfo)
                {
                    object[] objects = 
				{ 
					item.SysId, 
					item.TrId, 
					item.TrSeq, 
					item.PgmId, 
					item.UpprMenu, 
					item.PgmNm, 
					item.PgmTp, 
					item.PgmOpenTp, 
					item.ShortCut, 
					item.MenuParam
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private bool SaveGrdList()
        {
            ADMS2015U00CreateGroupHospitalArgs args = new ADMS2015U00CreateGroupHospitalArgs();
            args.UserId = UserInfo.UserID;
            args.HospCode = this.fbxHospitalID.Text;
            args.GroupId = grdGroupList.GetItemString(grdGroupList.CurrentRowNumber, "grp_id");
            args.GroupListInfo = GetGrdGroupListForSave();
            args.SystemListItem = GetGrdSystemListForSave();
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, ADMS2015U00CreateGroupHospitalArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }
            return false;
        }

        private List<ADM106UMakeQueryListItemInfo> GetListFromGrdMenuList()
        {
            List<ADM106UMakeQueryListItemInfo> dataList = new List<ADM106UMakeQueryListItemInfo>();
            for (int i = 0; i < grdSystemList.RowCount; i++)
            {
                ADM106UMakeQueryListItemInfo info = new ADM106UMakeQueryListItemInfo();
                info.SysId = grdSystemList.GetItemString(i, "sys_id");
                info.TrId = grdSystemList.GetItemString(i, "tr_id");
                info.TrSeq = grdSystemList.GetItemString(i, "tr_seq");
                info.PgmId = grdSystemList.GetItemString(i, "pgm_id");
                info.UpprMenu = grdSystemList.GetItemString(i, "uppr_menu");
                info.PgmNm = grdSystemList.GetItemString(i, "pgm_nm");
                info.PgmTp = grdSystemList.GetItemString(i, "pgm_tp");
                info.PgmOpenTp = grdSystemList.GetItemString(i, "pgm_open_tp");
                info.RowState = grdSystemList.GetRowState(i).ToString();

                dataList.Add(info);
            }
            if (grdSystemList.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdSystemList.DeletedRowTable.Rows)
                {
                    ADM106UMakeQueryListItemInfo info = new ADM106UMakeQueryListItemInfo();
                    info.SysId = row["sys_id"].ToString();
                    info.TrId = row["tr_id"].ToString();
                    info.TrSeq = row["tr_seq"].ToString();
                    info.PgmId = row["pgm_id"].ToString();
                    info.UpprMenu = row["uppr_menu"].ToString();
                    info.PgmNm = row["pgm_nm"].ToString();
                    info.PgmTp = row["pgm_tp"].ToString();
                    info.PgmOpenTp = row["pgm_open_tp"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }

            return dataList;
        }

        private List<object[]> LoadGrdGroupList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADMS2015U00LoadGroupSystemHospitalResult result = groupSystemHospitalResult;
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADMS2015U00GroupHospitalInfo item in result.GroupListInfo)
                {
                    object[] objects = 
						{ 
                        item.AdmsGroupId, 
                        item.GrpSeq, 
                        item.HospCode, 
                        item.SelectFlg, 
                        item.GrpId, 
                        item.GrpNm
						};
                    res.Add(objects);
                }
            }
            return res;
        }
        private List<object[]> LoadGrdSystemListGrouped(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADMS2015U00LoadGroupSystemHospitalResult result = groupSystemHospitalResult;
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADMS2015U00SystemHospitalInfo item in result.SystemListInfo)
                {
                    object[] objects = 
						{ 
                        item.AdmsGroupSystemId, 
                        item.SystemSeq, 
                        item.HospCode, 
                        item.SelectFlg, 
                        item.SystemId, 
                        item.SysNm
						};
                    res.Add(objects);
                }
            }
            return res;
        }

        private ADMS2015U00LoadGroupSystemHospitalResult LoadScreenDataByHospital()
        {
            ADMS2015U00LoadGroupSystemHospitalArgs args = new ADMS2015U00LoadGroupSystemHospitalArgs();
            args.HospCode = this.fbxHospitalID.Text;
            return CloudService.Instance.Submit<ADMS2015U00LoadGroupSystemHospitalResult, ADMS2015U00LoadGroupSystemHospitalArgs>(args);
        }

        private List<object[]> LoadGrdSystemList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADMS2015U00GetSystemHospitalArgs args = new ADMS2015U00GetSystemHospitalArgs();
            args.GroupId = bc["f_adms_group_id"] != null ? bc["f_adms_group_id"].VarValue : "";
            args.HospCode = this.fbxHospitalID.Text;
            ADMS2015U00GetSystemHospitalResult result = CloudService.Instance.Submit<ADMS2015U00GetSystemHospitalResult, ADMS2015U00GetSystemHospitalArgs>(args);
            if (result != null)
            {
                foreach (ADMS2015U00SystemHospitalInfo item in result.SystemListInfo)
                {
                    object[] objects = 
				{ 
					item.AdmsGroupSystemId, 
					item.SystemSeq, 
					item.HospCode, 
					item.SelectFlg, 
					item.SystemId, 
					item.SysNm
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<ADMS2015U00GroupHospitalInfo> GetGrdGroupListForSave()
        {
            List<ADMS2015U00GroupHospitalInfo> dataList = new List<ADMS2015U00GroupHospitalInfo>();
            for (int i = 0; i < grdGroupList.RowCount; i++)
            {
                ADMS2015U00GroupHospitalInfo info = new ADMS2015U00GroupHospitalInfo();
                info.AdmsGroupId = grdGroupList.GetItemString(i, "adms_group_id");
                info.GrpSeq = grdGroupList.GetItemString(i, "grp_seq");
                info.HospCode = grdGroupList.GetItemString(i, "hosp_code");
                info.SelectFlg = grdGroupList.GetItemString(i, "select_flg");
                info.GrpId = grdGroupList.GetItemString(i, "grp_id");
                info.GrpNm = grdGroupList.GetItemString(i, "grp_nm");
                info.DataRowState = grdGroupList.GetRowState(i).ToString();

                dataList.Add(info);
            }

            return dataList;
        }

        private List<ADMS2015U00SystemHospitalInfo> GetGrdSystemListForSave()
        {
            List<ADMS2015U00SystemHospitalInfo> dataList = new List<ADMS2015U00SystemHospitalInfo>();
            for (int i = 0; i < grdSystemList.RowCount; i++)
            {
                ADMS2015U00SystemHospitalInfo info = new ADMS2015U00SystemHospitalInfo();
                info.AdmsGroupSystemId = grdSystemList.GetItemString(i, "adms_group_system_id");
                info.SystemSeq = grdSystemList.GetItemString(i, "system_seq");
                info.HospCode = grdSystemList.GetItemString(i, "hosp_code");
                info.SelectFlg = grdSystemList.GetItemString(i, "select_flg");
                info.SystemId = grdSystemList.GetItemString(i, "system_id");
                info.SysNm = grdSystemList.GetItemString(i, "sys_nm");
                info.DataRowState = grdSystemList.GetRowState(i).ToString();

                dataList.Add(info);
            }

            return dataList;
        }

        #endregion
    }
}