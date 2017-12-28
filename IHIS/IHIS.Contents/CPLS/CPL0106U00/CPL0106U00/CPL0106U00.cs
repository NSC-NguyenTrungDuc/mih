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
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CPLS.Properties;
using IHIS.Framework;
#endregion

namespace IHIS.CPLS
{
    /// <summary>
    /// CPL0106U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class CPL0106U00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XMstGrid grdGroup;
        private IHIS.Framework.XEditGrid grdCode;
        private System.Windows.Forms.Splitter splitter1;
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
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XTextBox txtHangmogCode;
        private IHIS.Framework.XTextBox txtGumsaName;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XFindWorker fwkGumsa;
        private IHIS.Framework.FindColumnInfo findColumnInfo9;
        private IHIS.Framework.FindColumnInfo findColumnInfo10;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGrid grdSubGroup;
        private System.Windows.Forms.Splitter splitter2;
        private XMonthBox xMonthBox1;
        private XDictComboBox xDictComboBox1;
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell33;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private FindColumnInfo findColumnInfo3;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        UpdateResult updateResult = new UpdateResult();

        public CPL0106U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            grdGroup.ParamList = new List<string>(new String[] { "f_hangmog_code", "f_gumsa_name", "f_hosp_code" });
            grdCode.ParamList = new List<string>(new String[] { "f_hangmog_code", "f_specimen_code", "f_emergency", "f_group_gubun", "f_hosp_code" });
            grdSubGroup.ParamList = new List<string>(new String[] { "f_hangmog_code", "f_specimen_code", "f_emergency", "f_group_gubun", "f_hosp_code" });
            fwkGumsa.ParamList = new List<string>(new String[] { "f_find1" });

            grdGroup.ExecuteQuery = LoadDataGrdGroup;
            grdCode.ExecuteQuery = LoadDataGrdCode;
            grdSubGroup.ExecuteQuery = LoadDataGrdCode;
            fwkGumsa.ExecuteQuery = LoadDataFwkGumsa;
        }

        private List<object[]> LoadDataFwkGumsa(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL0106U00FwkGumsaArgs args = new CPL0106U00FwkGumsaArgs();
            args.Find1 = bc["f_find1"] != null ? bc["f_find1"].VarValue : "";
            CPL0106U00FwkGumsaResult result = CloudService.Instance.Submit<CPL0106U00FwkGumsaResult, CPL0106U00FwkGumsaArgs>(args);
            if (result != null)
            {
                foreach (CPL0106U00FwkGumsaListItemInfo item in result.FwkGumsaList)
                {
                    object[] objects = 
				{ 
					item.HangmogCode, 
					item.SpecimenCode, 
					item.SpecimenName, 
					item.Emergency, 
					item.GumsaName
				};
                    res.Add(objects);
                }
            }
            return res;
        } 



        private List<object[]> LoadDataGrdGroup(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL0106U00GrdGroupArgs args = new CPL0106U00GrdGroupArgs();
            args.HangmogCode = bc["f_hangmog_code"] != null ? bc["f_hangmog_code"].VarValue : "";
            args.GumsaName = bc["f_gumsa_name"] != null ? bc["f_gumsa_name"].VarValue : "";
            CPL0106U00GrdGroupResult result = CloudService.Instance.Submit<CPL0106U00GrdGroupResult, CPL0106U00GrdGroupArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL0106U00GrdGroupListItemInfo item in result.GrdGroupList)
                {
                    object[] objects = 
				{ 
					item.GroupGubun, 
					item.HangmogCode, 
					item.SpecimenCode, 
					item.SpecimenName, 
					item.Emergency, 
					item.GumsaName, 
					item.JundalGubun, 
					item.JundalName
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataGrdCode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL0106U00GrdCodeArgs args = new CPL0106U00GrdCodeArgs();
            args.HangmogCode = bc["f_hangmog_code"] != null ? bc["f_hangmog_code"].VarValue : "";
            args.SpecimenCode = bc["f_specimen_code"] != null ? bc["f_specimen_code"].VarValue : "";
            args.Emergency = bc["f_emergency"] != null ? bc["f_emergency"].VarValue : "";
            args.GroupGubun = bc["f_group_gubun"] != null ? bc["f_group_gubun"].VarValue : "";
            CPL0106U00GrdCodeResult result = CloudService.Instance.Submit<CPL0106U00GrdCodeResult, CPL0106U00GrdCodeArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL0106U00GrdListItemInfo item in result.GrdCodeList)
                {
                    object[] objects = 
				{ 
					item.GroupGubunA, 
					item.HangmogCode, 
					item.SpecimenCode, 
					item.Emergency, 
					item.SubHangmogCode, 
					item.SubSpecimenCode, 
					item.SpecimenName, 
					item.SubEmergency, 
					item.GumsaName, 
					item.ContinueYn, 
					item.GroupGubunB, 
					item.SgCode, 
					item.RowState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL0106U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.grdSubGroup = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.grdCode = new IHIS.Framework.XEditGrid();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.fwkGumsa = new IHIS.Framework.XFindWorker();
            this.findColumnInfo9 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo10 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.grdGroup = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xMonthBox1 = new IHIS.Framework.XMonthBox();
            this.xDictComboBox1 = new IHIS.Framework.XDictComboBox();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.txtGumsaName = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.txtHangmogCode = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xPanel1.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroup)).BeginInit();
            this.xPanel4.SuspendLayout();
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
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.splitter1);
            this.xPanel1.Controls.Add(this.xPanel4);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.xPanel2);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel5
            // 
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.Controls.Add(this.splitter2);
            this.xPanel5.Controls.Add(this.grdSubGroup);
            this.xPanel5.Controls.Add(this.grdCode);
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Name = "xPanel5";
            // 
            // splitter2
            // 
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.Name = "splitter2";
            this.splitter2.TabStop = false;
            // 
            // grdSubGroup
            // 
            resources.ApplyResources(this.grdSubGroup, "grdSubGroup");
            this.grdSubGroup.ApplyPaintEventToAllColumn = true;
            this.grdSubGroup.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell31});
            this.grdSubGroup.ColPerLine = 6;
            this.grdSubGroup.Cols = 7;
            this.grdSubGroup.ExecuteQuery = null;
            this.grdSubGroup.FixedCols = 1;
            this.grdSubGroup.FixedRows = 1;
            this.grdSubGroup.HeaderHeights.Add(30);
            this.grdSubGroup.Name = "grdSubGroup";
            this.grdSubGroup.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSubGroup.ParamList")));
            this.grdSubGroup.RowHeaderVisible = true;
            this.grdSubGroup.Rows = 2;
            this.grdSubGroup.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdSubGroup.ToolTipActive = true;
            this.grdSubGroup.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdSubGroup_GridCellPainting);
            this.grdSubGroup.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSubGroup_QueryStarting);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "group_gubun";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "hangmog_code";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "specimen_code";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "emergency";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "sub_hangmog_code";
            this.xEditGridCell23.CellWidth = 88;
            this.xEditGridCell23.Col = 1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsReadOnly = true;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "sub_specimen_code";
            this.xEditGridCell24.CellWidth = 60;
            this.xEditGridCell24.Col = 2;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsReadOnly = true;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "specimen_name";
            this.xEditGridCell25.CellWidth = 85;
            this.xEditGridCell25.Col = 3;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsReadOnly = true;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "sub_emergency";
            this.xEditGridCell26.CellWidth = 62;
            this.xEditGridCell26.Col = 4;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "gumsa_name";
            this.xEditGridCell27.CellWidth = 104;
            this.xEditGridCell27.Col = 5;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsReadOnly = true;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "continue_yn";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "sub_group_gubun";
            this.xEditGridCell29.CellWidth = 30;
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "sg_code";
            this.xEditGridCell31.CellWidth = 72;
            this.xEditGridCell31.Col = 6;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            // 
            // grdCode
            // 
            resources.ApplyResources(this.grdCode, "grdCode");
            this.grdCode.ApplyPaintEventToAllColumn = true;
            this.grdCode.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell16,
            this.xEditGridCell18,
            this.xEditGridCell30});
            this.grdCode.ColPerLine = 5;
            this.grdCode.ColResizable = true;
            this.grdCode.Cols = 6;
            this.grdCode.ExecuteQuery = null;
            this.grdCode.FixedCols = 1;
            this.grdCode.FixedRows = 1;
            this.grdCode.HeaderHeights.Add(31);
            this.grdCode.MasterLayout = this.grdGroup;
            this.grdCode.Name = "grdCode";
            this.grdCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdCode.ParamList")));
            this.grdCode.RowHeaderVisible = true;
            this.grdCode.Rows = 2;
            this.grdCode.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdCode.ToolTipActive = true;
            this.grdCode.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdCode_GridFindSelected);
            this.grdCode.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdCode_SaveEnd);
            this.grdCode.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdCode_RowFocusChanged);
            this.grdCode.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdCode_GridCellPainting);
            this.grdCode.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdCode_GridColumnChanged);
            this.grdCode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdCode_QueryStarting);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "group_gubun";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "hangmog_code";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "specimen_code";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "emergency";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "sub_hangmog_code";
            this.xEditGridCell7.CellWidth = 128;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.FindWorker = this.fwkGumsa;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell7.IsUpdatable = false;
            // 
            // fwkGumsa
            // 
            this.fwkGumsa.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo9,
            this.findColumnInfo1,
            this.findColumnInfo2,
            this.findColumnInfo3,
            this.findColumnInfo10});
            this.fwkGumsa.ExecuteQuery = null;
            this.fwkGumsa.FormText = global::IHIS.CPLS.Properties.Resources.FWKGUMSA_FORMTEXT;
            this.fwkGumsa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkGumsa.ParamList")));
            this.fwkGumsa.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fwkGumsa.ServerFilter = true;
            this.fwkGumsa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkGumsa_QueryStarting);
            // 
            // findColumnInfo9
            // 
            this.findColumnInfo9.ColName = "gubun";
            this.findColumnInfo9.ColWidth = 106;
            this.findColumnInfo9.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo9, "findColumnInfo9");
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "speciment_code";
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "speciment_name";
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "emergency";
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo10
            // 
            this.findColumnInfo10.ColName = "gubun_name";
            this.findColumnInfo10.ColWidth = 315;
            this.findColumnInfo10.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo10, "findColumnInfo10");
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "sub_specimen_code";
            this.xEditGridCell8.CellWidth = 85;
            this.xEditGridCell8.Col = 2;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 100;
            this.xEditGridCell9.CellName = "specimen_name";
            this.xEditGridCell9.CellWidth = 108;
            this.xEditGridCell9.Col = 3;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdCol = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "sub_emergency";
            this.xEditGridCell10.CellWidth = 104;
            this.xEditGridCell10.Col = 4;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellLen = 100;
            this.xEditGridCell11.CellName = "gumsa_name";
            this.xEditGridCell11.CellWidth = 203;
            this.xEditGridCell11.Col = 5;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdCol = false;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "continue_yn";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "sub_group_gubun";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "sg_code";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // grdGroup
            // 
            resources.ApplyResources(this.grdGroup, "grdGroup");
            this.grdGroup.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell32,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell33});
            this.grdGroup.ColPerLine = 6;
            this.grdGroup.ColResizable = true;
            this.grdGroup.Cols = 7;
            this.grdGroup.ExecuteQuery = null;
            this.grdGroup.FixedCols = 1;
            this.grdGroup.FixedRows = 1;
            this.grdGroup.HeaderHeights.Add(30);
            this.grdGroup.Name = "grdGroup";
            this.grdGroup.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdGroup.ParamList")));
            this.grdGroup.RowHeaderVisible = true;
            this.grdGroup.Rows = 2;
            this.grdGroup.ToolTipActive = true;
            this.grdGroup.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdGroup_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "group_gubun";
            this.xEditGridCell1.CellWidth = 47;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdCol = false;
            this.xEditGridCell1.SuppressRepeating = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "hangmog_code";
            this.xEditGridCell2.CellWidth = 70;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.SuppressRepeating = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "specimen_code";
            this.xEditGridCell3.CellWidth = 30;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "specimen_name";
            this.xEditGridCell32.CellWidth = 112;
            this.xEditGridCell32.Col = 3;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "emergency";
            this.xEditGridCell4.CellWidth = 68;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 100;
            this.xEditGridCell5.CellName = "gumsa_name";
            this.xEditGridCell5.CellWidth = 190;
            this.xEditGridCell5.Col = 5;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "jundal_gubun";
            this.xEditGridCell6.CellWidth = 37;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "jundal_name";
            this.xEditGridCell33.CellWidth = 120;
            this.xEditGridCell33.Col = 6;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsReadOnly = true;
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xPanel4
            // 
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Controls.Add(this.grdGroup);
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Name = "xPanel4";
            // 
            // xPanel3
            // 
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Controls.Add(this.xMonthBox1);
            this.xPanel3.Controls.Add(this.xDictComboBox1);
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // xMonthBox1
            // 
            resources.ApplyResources(this.xMonthBox1, "xMonthBox1");
            this.xMonthBox1.IsVietnameseYearType = false;
            this.xMonthBox1.Name = "xMonthBox1";
            // 
            // xDictComboBox1
            // 
            resources.ApplyResources(this.xDictComboBox1, "xDictComboBox1");
            this.xDictComboBox1.ExecuteQuery = null;
            this.xDictComboBox1.Name = "xDictComboBox1";
            this.xDictComboBox1.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("xDictComboBox1.ParamList")));
            this.xDictComboBox1.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.txtGumsaName);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.txtHangmogCode);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // txtGumsaName
            // 
            resources.ApplyResources(this.txtGumsaName, "txtGumsaName");
            this.txtGumsaName.Name = "txtGumsaName";
            this.txtGumsaName.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtGumsaName_DataValidating);
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // txtHangmogCode
            // 
            resources.ApplyResources(this.txtHangmogCode, "txtHangmogCode");
            this.txtHangmogCode.Name = "txtHangmogCode";
            this.txtHangmogCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtHangmogCode_DataValidating);
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "group_gubun";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // CPL0106U00
            // 
            resources.ApplyResources(this, "$this");
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.xPanel1);
            this.Name = "CPL0106U00";
            this.xPanel1.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSubGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroup)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.grdCode.SetRelationKey("hangmog_code", "hangmog_code");
            this.grdCode.SetRelationKey("specimen_code", "specimen_code");
            this.grdCode.SetRelationKey("emergency", "emergency");
            this.grdCode.SetRelationKey("group_gubun", "group_gubun");
            this.grdCode.SetRelationTable("CPL0106");
            this.CurrMQLayout = this.grdGroup;

            //this.grdCode.SavePerformer = new XSavePerformer(this);

            //this.SaveLayoutList.Add(grdCode);

            this.grdGroup.QueryLayout(true);
        }
        #endregion

        #region btnList_ButtonClick
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    if (this.CurrMQLayout == this.grdGroup)
                        e.IsBaseCall = false;
                    break;
               
                case FunctionType.Update:
                    if (!SaveGrdCode())
                    {
                        XMessageBox.Show(Resources.TEXT1);
                    }
                    else
                    {
                        grdCode.QueryLayout(false);
                    }
                    break;
                default:
                    break;
            }
        }

        private bool SaveGrdCode()
        {
            List<CPL0106U00GrdListItemInfo> inputList = GetListFromGrdCode();
            if (inputList.Count == 0)
            {
                return true;
            }

            if (!ValidateData())
            {
                XMessageBox.Show("[" + Resources.SubHangmogCode + "] " + Resources.TEXT2);
                return false;
            }

            CPL0106U00SaveLayoutArgs args = new CPL0106U00SaveLayoutArgs(UserInfo.UserID, inputList);
            this.updateResult = CloudService.Instance.Submit<UpdateResult, CPL0106U00SaveLayoutArgs>(args);
            if (updateResult.ExecutionStatus == ExecutionStatus.Success)
            {
                return updateResult.Result;
            }
            return false;
        }

        private bool ValidateData()
        {
            for (int i = 0; i < grdCode.RowCount; i++)
            {
                for (int j = i + 1; j < grdCode.RowCount; j++)
                {
                    if (grdCode.GetItemString(i, "sub_hangmog_code").Equals(grdCode.GetItemString(j, "sub_hangmog_code")))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private List<CPL0106U00GrdListItemInfo> GetListFromGrdCode()
        {
            List<CPL0106U00GrdListItemInfo> dataList = new List<CPL0106U00GrdListItemInfo>();
            for (int i = 0; i < grdCode.RowCount; i++)
            {
                if (grdCode.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }

                CPL0106U00GrdListItemInfo info = new CPL0106U00GrdListItemInfo();
                info.GroupGubunA = grdGroup.GetItemString(grdGroup.CurrentRowNumber, "group_gubun");
                info.HangmogCode = grdGroup.GetItemString(grdGroup.CurrentRowNumber, "hangmog_code");
                info.SpecimenCode = grdGroup.GetItemString(grdGroup.CurrentRowNumber, "specimen_code");
                info.Emergency = grdGroup.GetItemString(grdGroup.CurrentRowNumber, "emergency");

                info.SubHangmogCode = grdCode.GetItemString(i, "sub_hangmog_code");
                info.SubSpecimenCode = grdCode.GetItemString(i, "sub_specimen_code");
                info.SpecimenName = grdCode.GetItemString(i, "specimen_name");
                info.SubEmergency = grdCode.GetItemString(i, "sub_emergency");
                info.GumsaName = grdCode.GetItemString(i, "gumsa_name");
                info.ContinueYn = grdCode.GetItemString(i, "continue_yn");
                info.GroupGubunB = grdCode.GetItemString(i, "sub_group_gubun");
                info.SgCode = grdCode.GetItemString(i, "sg_code");
                info.RowState = grdCode.GetRowState(i).ToString();

                dataList.Add(info);
            }
            if (grdCode.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdCode.DeletedRowTable.Rows)
                {
                    CPL0106U00GrdListItemInfo info = new CPL0106U00GrdListItemInfo();
                    info.GroupGubunA = grdGroup.GetItemString(grdGroup.CurrentRowNumber, "group_gubun");
                    info.HangmogCode = grdGroup.GetItemString(grdGroup.CurrentRowNumber, "hangmog_code");
                    info.SpecimenCode = grdGroup.GetItemString(grdGroup.CurrentRowNumber, "specimen_code");
                    info.Emergency = grdGroup.GetItemString(grdGroup.CurrentRowNumber, "emergency");

                    info.SubHangmogCode = row["sub_hangmog_code"].ToString();
                    info.SubSpecimenCode = row["sub_specimen_code"].ToString();
                    info.SpecimenName = row["specimen_name"].ToString();
                    info.SubEmergency = row["sub_emergency"].ToString();
                    info.GumsaName = row["gumsa_name"].ToString();
                    info.ContinueYn = row["continue_yn"].ToString();
                    info.GroupGubunB = row["sub_group_gubun"].ToString();
                    info.SgCode = row["sg_code"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }

            return dataList;
        }

        #endregion

       

        private void grdCode_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if ((grdCode.GetItemString(e.RowNumber, "sub_group_gubun") == "01") || (grdCode.GetItemString(e.RowNumber, "sub_group_gubun") == "01"))
            {
                e.BackColor = Color.Yellow;
            }
        }

        private void grdSubGroup_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if ((grdSubGroup.GetItemString(e.RowNumber, "sub_group_gubun") == "01") || (grdSubGroup.GetItemString(e.RowNumber, "sub_group_gubun") == "03"))
            {
                e.BackColor = Color.Yellow;
            }

            if (grdSubGroup.GetItemString(e.RowNumber, "sg_code") != "")
            {
                e.ForeColor = Color.Red;
            }
        }

        private void grdCode_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            grdSubGroup.QueryLayout(false);
        }

        private void txtHangmogCode_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.txtGumsaName.SetDataValue("");
            this.grdGroup.QueryLayout(true);
        }

        private void txtGumsaName_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.grdGroup.QueryLayout(true);
        }

        #region 조회변수 셋팅
        private void grdGroup_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdGroup.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdGroup.SetBindVarValue("f_hangmog_code", txtHangmogCode.GetDataValue());
            this.grdGroup.SetBindVarValue("f_gumsa_name", txtGumsaName.GetDataValue());
        }

        private void grdCode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdCode.SetBindVarValue("f_hangmog_code", grdGroup.GetItemString(grdGroup.CurrentRowNumber, "hangmog_code"));
            this.grdCode.SetBindVarValue("f_specimen_code", grdGroup.GetItemString(grdGroup.CurrentRowNumber, "specimen_code"));
            this.grdCode.SetBindVarValue("f_emergency", grdGroup.GetItemString(grdGroup.CurrentRowNumber, "emergency"));
            this.grdCode.SetBindVarValue("f_group_gubun", grdGroup.GetItemString(grdGroup.CurrentRowNumber, "group_gubun"));
        }

        private void grdSubGroup_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdSubGroup.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdSubGroup.SetBindVarValue("f_hangmog_code", grdCode.GetItemString(grdCode.CurrentRowNumber, "sub_hangmog_code"));
            this.grdSubGroup.SetBindVarValue("f_specimen_code", grdCode.GetItemString(grdCode.CurrentRowNumber, "sub_specimen_code"));
            this.grdSubGroup.SetBindVarValue("f_emergency", grdCode.GetItemString(grdCode.CurrentRowNumber, "sub_emergency"));
            this.grdSubGroup.SetBindVarValue("f_group_gubun", grdCode.GetItemString(grdCode.CurrentRowNumber, "sub_group_gubun"));
        }
        #endregion

        #region XSavePerformer
//        private class XSavePerformer : IHIS.Framework.ISavePerformer
//        {
//            private CPL0106U00 parent = null;
//            public XSavePerformer(CPL0106U00 parent)
//            {
//                this.parent = parent;
//            }
//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";
//                //Grid에서 넘어온 Bind 변수에 f_user_id SET
//                item.BindVarList.Add("f_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);


//                switch (item.RowState)
//                {
//                    case DataRowState.Added:
//                        cmdText = @"INSERT INTO CPL0106 (SYS_DATE         ,SYS_ID              ,UPD_DATE          ,UPD_ID
//                                                        ,GROUP_GUBUN      ,HANGMOG_CODE        ,SPECIMEN_CODE    
//                                                        ,EMERGENCY        ,SUB_HANGMOG_CODE    ,SUB_SPECIMEN_CODE
//                                                        ,SUB_EMERGENCY    ,CONTINUE_YN         ,HOSP_CODE
//                                               ) VALUES (SYSDATE          ,:f_user_id          ,SYSDATE           ,:f_user_id
//                                                        ,:f_group_gubun   ,:f_hangmog_code     ,:f_specimen_code    
//                                                        ,nvl(:f_emergency,'N')     ,:f_sub_hangmog_code ,:f_sub_specimen_code
//                                                        ,nvl(:f_sub_emergency,'N') ,:f_continue_yn      ,:f_hosp_code 
//                                                        )";
//                        break;
//                    case DataRowState.Modified:
//                        cmdText = @"UPDATE CPL0106
//                                       SET UPD_ID            = :f_user_id
//                                         , UPD_DATE          = SYSDATE
//                                         , SUB_SPECIMEN_CODE = :f_sub_specimen_code                      
//                                         , SUB_EMERGENCY     = :f_sub_emergency                              
//                                         , CONTINUE_YN       = :f_continue_yn                            
//                                     WHERE HOSP_CODE         = :f_hosp_code
//                                       AND GROUP_GUBUN       = :f_group_gubun                          
//                                       AND HANGMOG_CODE      = :f_hangmog_code                          
//                                       AND SPECIMEN_CODE     = :f_specimen_code                        
//                                       AND EMERGENCY         = nvl(:f_emergency,'N')
//                                       AND SUB_HANGMOG_CODE  = :f_sub_hangmog_code";
//                        break;
//                    case DataRowState.Deleted:
//                        cmdText = @"DELETE CPL0106
//                                     WHERE HOSP_CODE        = :f_hosp_code
//                                       AND GROUP_GUBUN      = :f_group_gubun                          
//                                       AND HANGMOG_CODE     = :f_hangmog_code                          
//                                       AND SPECIMEN_CODE    = :f_specimen_code                        
//                                       AND EMERGENCY        = nvl(:f_emergency,'N')
//                                       AND SUB_HANGMOG_CODE = :f_sub_hangmog_code";
//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion

        #region 저장 처리 후 에러메세지 팝업처리
        private void grdCode_SaveEnd(object sender, SaveEndEventArgs e)
        {
            //tungtx todo delete
            //if (!e.IsSuccess) XMessageBox.Show("ERROR CODE : " + Service.ErrCode + "   " + e.ErrMsg);
        }
        #endregion


        #region 파인드 셀 값 변경시 처리 로직
        private void grdCode_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (TypeCheck.IsNull(e.ChangeValue))
            {
                if (e.ColName == "sub_hangmog_code") this.grdCode.SetItemValue(e.RowNumber, "gumsa_name", null);
                //else if (e.ColName == "sub_specimen_code") this.grdCode.SetItemValue(e.RowNumber, "specimen_name", null);
                e.Cancel = false;
                return;
            }

            BindVarCollection bindVarList = new BindVarCollection();
            string cmdText = "";

            if (e.ColName == "sub_hangmog_code")
            {
//                bindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                bindVarList.Add("f_code", grdCode.GetItemString(e.RowNumber,"sub_hangmog_code"));

//                cmdText = @"SELECT A.HANGMOG_CODE
//                                 , A.SPECIMEN_CODE
//                                 , (SELECT Z.CODE_NAME 
//                                      FROM CPL0109 Z
//                                     WHERE Z.HOSP_CODE = A.HOSP_CODE
//                                       AND Z.CODE_TYPE = '04'
//                                       AND Z.CODE      = A.SPECIMEN_CODE) SPECIMEN_NAME
//                                 , A.EMERGENCY
//                                 , A.GUMSA_NAME
//                              FROM CPL0101 A
//                             WHERE A.HOSP_CODE = :f_hosp_code
//                               AND A.HANGMOG_CODE = :f_code";

//                DataTable dt = Service.ExecuteDataTable(cmdText, bindVarList);


                //tungtx
                CPL0106U00GridColumnChangeArgs args = new CPL0106U00GridColumnChangeArgs(grdCode.GetItemString(e.RowNumber, "sub_hangmog_code"));
                CPL0106U00GridColumnChangeResult result =
                    CloudService.Instance.Submit<CPL0106U00GridColumnChangeResult, CPL0106U00GridColumnChangeArgs>(args);

                //if (Service.ErrCode != 0 || dt.Rows.Count == 0)
                if (result.ExecutionStatus != ExecutionStatus.Success || result.ResultList.Count == 0)
                {
                    this.SetMsg(XMsg.GetMsg("M001"), MsgType.Error); //존재하지 않는 항목코드입니다.
                    e.Cancel = true;

                    //added 2015/04/25
                    return;
                }

                //this.grdCode.SetItemValue(e.RowNumber, "sub_hangmog_code", dt.Rows[0]["hangmog_code"].ToString());
                //this.grdCode.SetItemValue(e.RowNumber, "sub_specimen_code", dt.Rows[0]["specimen_code"].ToString());
                //this.grdCode.SetItemValue(e.RowNumber, "specimen_name", dt.Rows[0]["specimen_name"].ToString());
                //this.grdCode.SetItemValue(e.RowNumber, "sub_emergency", dt.Rows[0]["emergency"].ToString());
                //this.grdCode.SetItemValue(e.RowNumber, "gumsa_name", dt.Rows[0]["gumsa_name"].ToString());

                this.grdCode.SetItemValue(e.RowNumber, "sub_hangmog_code", result.ResultList[0].HangmogCode);
                this.grdCode.SetItemValue(e.RowNumber, "sub_specimen_code", result.ResultList[0].SpecimenCode);
                this.grdCode.SetItemValue(e.RowNumber, "specimen_name", result.ResultList[0].SpecimenName);
                this.grdCode.SetItemValue(e.RowNumber, "sub_emergency", result.ResultList[0].Emergency);
                this.grdCode.SetItemValue(e.RowNumber, "gumsa_name", result.ResultList[0].GumsaName);
            }
//            else if (e.ColName == "sub_specimen_code")
//            {
//                bindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                bindVarList.Add("f_hangmog_code", grdCode.GetItemString(e.RowNumber, "sub_hangmog_code"));
//                bindVarList.Add("f_code", grdCode.GetItemString(e.RowNumber, "sub_specimen_code"));
//                cmdText = @"SELECT A.CODE_NAME
//                              FROM CPL0109 A
//                             WHERE HOSP_CODE = :f_hosp_code
//                               AND A.CODE_TYPE  = '04'
//                               AND A.CODE IN (SELECT SPECIMEN_CODE FROM CPL0101 WHERE HOSP_CODE = :f_hosp_code AND HANGMOG_CODE = :f_hangmog_code)
//                               AND A.CODE = :f_code";

//                 /*         @"SELECT CODE_NAME 
//                              FROM CPL0109 
//                             WHERE CODE_TYPE = '04' 
//                               AND CODE = :f_code";  */
//                retVal = Service.ExecuteScalar(cmdText, bindVarList);

//                if (retVal == null)
//                {
//                    this.SetMsg(XMsg.GetMsg("M001"), MsgType.Error); //존재하지 않는 항목코드입니다.
//                    e.Cancel = true;
//                }
//                else
//                {
//                    grdCode.SetItemValue(e.RowNumber, "specimen_name", retVal.ToString());
//                }
//            }
        }

        private bool MakeValService(XFindBox aCtl)
        {
            bool result = false;

            //findBox validation 
            BindVarCollection bindVarList = new BindVarCollection();
            string cmdText = "";
            object retVal = null;

            //end sample

            switch (aCtl.Name)
            {
                case "fbxHangmogCode":
                    txtGumsaName.Text = "";

                    bindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                    bindVarList.Add("f_code", aCtl.GetDataValue());
                    cmdText = "select gumsa_name from cpl0101 where hosp_code = :f_hosp_code and hangmog_code = :f_code";
                    retVal = Service.ExecuteScalar(cmdText, bindVarList);

                    if (retVal == null)
                    {
                        this.SetMsg(XMsg.GetMsg("M001"), MsgType.Normal); //존재하지 않는 항목코드입니다.
                        //return;
                    }
                    else
                    {
                        //항목명 SET
                        this.txtGumsaName.SetDataValue(retVal.ToString());
                    }
                    result = true;
                    break;
                default:
                    XMessageBox.Show("NO CONTROL FOUND", "ERROR");
                    result = false;
                    break;
            }
            return result;

        }
        
        #endregion

        private void fwkGumsa_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkGumsa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            fwkGumsa.SetBindVarValue("f_find1", grdCode.GetItemString(grdCode.CurrentRowNumber, "sub_specimen_code"));
        }

        private void grdCode_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {
            string hangmog_code = e.ReturnValues[0].ToString();
            string specimen_code = e.ReturnValues[1].ToString();
            string specimen_name = e.ReturnValues[2].ToString();
            string emergency = e.ReturnValues[3].ToString();
            string hangmog_name = e.ReturnValues[4].ToString();

            this.grdCode.SetItemValue(e.RowNumber, "sub_hangmog_code", hangmog_code);
            this.grdCode.SetItemValue(e.RowNumber, "sub_specimen_code", specimen_code);
            this.grdCode.SetItemValue(e.RowNumber, "specimen_name", specimen_name);
            this.grdCode.SetItemValue(e.RowNumber, "sub_emergency", emergency);
            this.grdCode.SetItemValue(e.RowNumber, "gumsa_name", hangmog_name);
        }
    }
}

