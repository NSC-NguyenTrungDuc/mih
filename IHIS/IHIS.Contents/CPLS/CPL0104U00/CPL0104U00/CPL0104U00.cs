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
    /// CPL0104U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class CPL0104U00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XButtonList btnList;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XEditGrid grdDetail;
        private IHIS.Framework.XMstGrid grdMaster;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XTextBox txtSpecimenCode;
        private IHIS.Framework.XTextBox txtGumsaName;
        private IHIS.Framework.XTextBox txtHangmogCode;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XComboItem xComboItem3;
        private IHIS.Framework.XComboItem xComboItem4;
        private IHIS.Framework.XGridHeader xGridHeader1;
        private IHIS.Framework.XGridHeader xGridHeader2;
        private IHIS.Framework.XGridHeader xGridHeader3;
        private IHIS.Framework.XComboItem xComboItem5;
        private IHIS.Framework.XComboItem xComboItem6;
        private IHIS.Framework.XComboItem xComboItem7;
        private IHIS.Framework.XComboItem xComboItem8;
        private IHIS.Framework.XComboItem xComboItem9;
        private IHIS.Framework.XComboBox cboEmergency;
        private IHIS.Framework.XComboItem xComboItem10;
        private IHIS.Framework.XComboItem xComboItem11;
        private XEditGridCell xEditGridCell15;
        private XGridHeader xGridHeader4;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private int maxRowpage = 200;

        public CPL0104U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            this.grdMaster.ParamList = new List<string>(new String[] { "f_hosp_code", "f_hangmog_code", "f_specimen_code", "f_emergency", "f_gumsa_name", "f_page_number" });
            this.grdDetail.ParamList = new List<string>(new String[] { "f_hosp_code", "f_hangmog_code", "f_specimen_code", "f_emergency", "f_page_number" });

            this.grdMaster.ExecuteQuery = LoadDataGrdMaster;
            this.grdDetail.ExecuteQuery = LoadDataGrdDetail;
        }

        /// <summary>
        /// get data for grdDetail
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdDetail(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL0104U00GrdDetailArgs args = new CPL0104U00GrdDetailArgs();
            args.HangmogCode = bc["f_hangmog_code"] != null ? bc["f_hangmog_code"].VarValue : "";
            args.SpecimenCode = bc["f_specimen_code"] != null ? bc["f_specimen_code"].VarValue : "";
            args.Emergency = bc["f_emergency"] != null ? bc["f_emergency"].VarValue : "";
            args.PageNumber = bc["f_page_number"] != null ? bc["f_page_number"].VarValue : "";
            args.Offset = maxRowpage.ToString();
            CPL0104U00GrdDetailResult result = CloudService.Instance.Submit<CPL0104U00GrdDetailResult, CPL0104U00GrdDetailArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success && result.DetailList.Count > 0)
            {
                foreach (CPL0104U00GrdDetailListItemInfo item in result.DetailList)
                {
                    object[] objects = 
				{ 
					item.HangmogCode, 
					item.SpecimenCode, 
					item.Emergency, 
					item.Sex, 
					item.NaiFrom, 
					item.NaiTo, 
					item.FromAge, 
					item.ToAge, 
					item.FromStandard, 
					item.ToStandard, 
				};
                    res.Add(objects);
                }
            }
            return res;
        } 



        /// <summary>
        /// LoadData for grdMaster
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdMaster(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL0104U00GrdMasterArgs args = new CPL0104U00GrdMasterArgs();
            args.HangmogCode = bc["f_hangmog_code"] != null ? bc["f_hangmog_code"].VarValue : "";
            args.SpecimenCode = bc["f_specimen_code"] != null ? bc["f_specimen_code"].VarValue : "";
            args.Emergency = bc["f_emergency"] != null ? bc["f_emergency"].VarValue : "";
            args.GumsaName = bc["f_gumsa_name"] != null ? bc["f_gumsa_name"].VarValue : "";
            args.PageNumber = bc["f_page_number"] != null ? bc["f_page_number"].VarValue : "";
            args.Offset = maxRowpage.ToString();
            CPL0104U00GrdMasterResult result = CloudService.Instance.Submit<CPL0104U00GrdMasterResult, CPL0104U00GrdMasterArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success && result.MasterList.Count > 0)
            {
                foreach (CPL0104U00GrdMasterListItemInfo item in result.MasterList)
                {
                    object[] objects = 
				{ 
					item.HangmogCode, 
					item.SpecimenCode, 
					item.CodeName, 
					item.Emergency, 
					item.GumsaName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL0104U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdDetail = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xComboItem9 = new IHIS.Framework.XComboItem();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.xGridHeader3 = new IHIS.Framework.XGridHeader();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader4 = new IHIS.Framework.XGridHeader();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.cboEmergency = new IHIS.Framework.XComboBox();
            this.xComboItem10 = new IHIS.Framework.XComboItem();
            this.xComboItem11 = new IHIS.Framework.XComboItem();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.txtSpecimenCode = new IHIS.Framework.XTextBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.txtGumsaName = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.txtHangmogCode = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel1.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
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
            this.xPanel5.Controls.Add(this.grdDetail);
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Name = "xPanel5";
            // 
            // grdDetail
            // 
            this.grdDetail.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14});
            this.grdDetail.ColPerLine = 7;
            this.grdDetail.ColResizable = true;
            this.grdDetail.Cols = 8;
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedCols = 1;
            this.grdDetail.FixedRows = 2;
            this.grdDetail.HeaderHeights.Add(23);
            this.grdDetail.HeaderHeights.Add(21);
            this.grdDetail.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2,
            this.xGridHeader3});
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.RowHeaderVisible = true;
            this.grdDetail.Rows = 3;
            this.grdDetail.ToolTipActive = true;
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "hangmog_code";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "specimen_code";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "emergency";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "sex";
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6,
            this.xComboItem7});
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.RowSpan = 2;
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "M";
            // 
            // xComboItem6
            // 
            resources.ApplyResources(this.xComboItem6, "xComboItem6");
            this.xComboItem6.ValueItem = "F";
            // 
            // xComboItem7
            // 
            resources.ApplyResources(this.xComboItem7, "xComboItem7");
            this.xComboItem7.ValueItem = "H";
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "nai_from";
            this.xEditGridCell9.CellWidth = 35;
            this.xEditGridCell9.Col = 2;
            this.xEditGridCell9.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem8});
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.Row = 1;
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "Y";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "M";
            // 
            // xComboItem8
            // 
            resources.ApplyResources(this.xComboItem8, "xComboItem8");
            this.xComboItem8.ValueItem = "D";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "nai_to";
            this.xEditGridCell10.CellWidth = 35;
            this.xEditGridCell10.Col = 3;
            this.xEditGridCell10.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4,
            this.xComboItem9});
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.Row = 1;
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "Y";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "M";
            // 
            // xComboItem9
            // 
            resources.ApplyResources(this.xComboItem9, "xComboItem9");
            this.xComboItem9.ValueItem = "D";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "from_age";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell11.CellWidth = 39;
            this.xEditGridCell11.Col = 4;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.MaxinumCipher = 3;
            this.xEditGridCell11.Row = 1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "to_age";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell12.CellWidth = 40;
            this.xEditGridCell12.Col = 5;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.MaxinumCipher = 3;
            this.xEditGridCell12.Row = 1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 40;
            this.xEditGridCell13.CellName = "from_standard";
            this.xEditGridCell13.CellWidth = 87;
            this.xEditGridCell13.Col = 6;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.Row = 1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 40;
            this.xEditGridCell14.CellName = "to_standard";
            this.xEditGridCell14.CellWidth = 95;
            this.xEditGridCell14.Col = 7;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.Row = 1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 2;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 35;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 4;
            this.xGridHeader2.ColSpan = 2;
            this.xGridHeader2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 39;
            // 
            // xGridHeader3
            // 
            this.xGridHeader3.Col = 6;
            this.xGridHeader3.ColSpan = 2;
            this.xGridHeader3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xGridHeader3, "xGridHeader3");
            this.xGridHeader3.HeaderWidth = 87;
            // 
            // grdMaster
            // 
            this.grdMaster.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell15,
            this.xEditGridCell7,
            this.xEditGridCell8});
            this.grdMaster.ColPerLine = 5;
            this.grdMaster.ColResizable = true;
            this.grdMaster.Cols = 6;
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 2;
            this.grdMaster.HeaderHeights.Add(41);
            this.grdMaster.HeaderHeights.Add(1);
            this.grdMaster.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader4});
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 3;
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "hangmog_code";
            this.xEditGridCell1.CellWidth = 71;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.RowSpan = 2;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "specimen_code";
            this.xEditGridCell2.CellWidth = 45;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.Row = 1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "specimen_name";
            this.xEditGridCell15.Col = 3;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.Row = 1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "emergency";
            this.xEditGridCell7.CellWidth = 98;
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.RowSpan = 2;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 100;
            this.xEditGridCell8.CellName = "gumsa_name";
            this.xEditGridCell8.CellWidth = 229;
            this.xEditGridCell8.Col = 5;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.RowSpan = 2;
            // 
            // xGridHeader4
            // 
            this.xGridHeader4.Col = 2;
            this.xGridHeader4.ColSpan = 2;
            this.xGridHeader4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xGridHeader4, "xGridHeader4");
            this.xGridHeader4.HeaderWidth = 45;
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
            this.xPanel4.Controls.Add(this.grdMaster);
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Name = "xPanel4";
            // 
            // xPanel3
            // 
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
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
            this.xPanel2.Controls.Add(this.cboEmergency);
            this.xPanel2.Controls.Add(this.xLabel4);
            this.xPanel2.Controls.Add(this.txtSpecimenCode);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.Controls.Add(this.txtGumsaName);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.txtHangmogCode);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // cboEmergency
            // 
            resources.ApplyResources(this.cboEmergency, "cboEmergency");
            this.cboEmergency.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem10,
            this.xComboItem11});
            this.cboEmergency.Name = "cboEmergency";
            // 
            // xComboItem10
            // 
            resources.ApplyResources(this.xComboItem10, "xComboItem10");
            this.xComboItem10.ValueItem = "Y";
            // 
            // xComboItem11
            // 
            resources.ApplyResources(this.xComboItem11, "xComboItem11");
            this.xComboItem11.ValueItem = "N";
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // txtSpecimenCode
            // 
            resources.ApplyResources(this.txtSpecimenCode, "txtSpecimenCode");
            this.txtSpecimenCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSpecimenCode.Name = "txtSpecimenCode";
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
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
            this.txtHangmogCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHangmogCode.Name = "txtHangmogCode";
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // CPL0104U00
            // 
            resources.ApplyResources(this, "$this");
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.xPanel1);
            this.Name = "CPL0104U00";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CPL0104U00_Closing);
            this.xPanel1.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
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
            this.grdDetail.SetRelationKey("hangmog_code", "hangmog_code");
            this.grdDetail.SetRelationKey("specimen_code", "specimen_code");
            this.grdDetail.SetRelationKey("emergency", "emergency");
            this.grdDetail.SetRelationTable("cpl0104");
            this.CurrMQLayout = this.grdMaster;

            //this.grdDetail.SavePerformer = new XSavePerformer(this);

            //this.SaveLayoutList.Add(grdDetail);
        }
        #endregion

        #region btnList_ButtonClick

        private bool mIsSaveSuccess = true;
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;

                    this.grdMaster.QueryLayout(false);

                    break;

                case FunctionType.Insert:
                    if (this.CurrMQLayout == this.grdMaster)
                        e.IsBaseCall = false;
                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;
                    mIsSaveSuccess = true;
                    for (int i = 0; i < this.grdDetail.RowCount; i++)
                    {
                        if ((this.grdDetail.GetItemString(i, "sex") == "")      ||
                            (this.grdDetail.GetItemString(i, "from_age") == "") ||
                            (this.grdDetail.GetItemString(i, "to_age") == "")   ||
                            (this.grdDetail.GetItemString(i, "nai_from") == "") ||
                            (this.grdDetail.GetItemString(i, "nai_to") == "")    )
                        {
                            this.mIsSaveSuccess = false;
                            XMessageBox.Show(Resources.MSG001_MSG, Resources.MSG001_CAP, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                        //if (!this.grdDetail.SaveLayout())
                        //{
                        //    XMessageBox.Show(Resources.MSG002_MSG + Service.ErrFullMsg, Resources.MSG002_CAP, MessageBoxIcon.Warning);
                        //}

                    if (!SaveGrdDetail())
                    {
                        XMessageBox.Show(Resources.MSG002_MSG + Service.ErrFullMsg, Resources.MSG002_CAP, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        XMessageBox.Show(Resources.MSG003_MSG, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.grdDetail.QueryLayout(false);
                    }

                    break;
                default:
                    break;
            }
        }

        private bool SaveGrdDetail()
        {
            List<CPL0104U00GrdDetailListItemInfo> inputList = GetListFromGrdDetail();
            if (inputList.Count == 0)
            {
                return true;
            }

            CPL0104U00SaveLayoutArgs args = new CPL0104U00SaveLayoutArgs(UserInfo.UserID, inputList);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, CPL0104U00SaveLayoutArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }
            return false;
        }

        private List<CPL0104U00GrdDetailListItemInfo> GetListFromGrdDetail()
        {
            List<CPL0104U00GrdDetailListItemInfo> dataList = new List<CPL0104U00GrdDetailListItemInfo>();
            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (grdDetail.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }

                CPL0104U00GrdDetailListItemInfo info = new CPL0104U00GrdDetailListItemInfo();
                info.HangmogCode = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "hangmog_code");
                info.SpecimenCode = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "specimen_code");
                info.Emergency = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "emergency");
                info.Sex = grdDetail.GetItemString(i, "sex");
                info.NaiFrom = grdDetail.GetItemString(i, "nai_from");
                info.NaiTo = grdDetail.GetItemString(i, "nai_to");
                info.FromAge = grdDetail.GetItemString(i, "from_age");
                info.ToAge = grdDetail.GetItemString(i, "to_age");
                info.FromStandard = grdDetail.GetItemString(i, "from_standard");
                info.ToStandard = grdDetail.GetItemString(i, "to_standard");
                info.RowState = grdDetail.GetRowState(i).ToString();

                dataList.Add(info);
            }

            if (grdDetail.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdDetail.DeletedRowTable.Rows)
                {
                    CPL0104U00GrdDetailListItemInfo info = new CPL0104U00GrdDetailListItemInfo();
                    info.HangmogCode = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "hangmog_code");
                    info.SpecimenCode = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "specimen_code");
                    info.Emergency = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "emergency");
                    info.Sex = row["sex"].ToString();
                    info.NaiFrom = row["nai_from"].ToString();
                    info.NaiTo = row["nai_to"].ToString();
                    info.FromAge = row["from_age"].ToString();
                    info.ToAge = row["to_age"].ToString();
                    info.FromStandard = row["from_standard"].ToString();
                    info.ToStandard = row["to_standard"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }
            return dataList;
        }

        #endregion

        #region txtGumsaName_DataValidating
        private void txtGumsaName_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.grdMaster.QueryLayout(false);
        }
        #endregion

        #region set in value before query
        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdMaster.SetBindVarValue("f_hangmog_code", txtHangmogCode.GetDataValue());
            grdMaster.SetBindVarValue("f_specimen_code", txtSpecimenCode.GetDataValue());
            grdMaster.SetBindVarValue("f_emergency", cboEmergency.GetDataValue());
            grdMaster.SetBindVarValue("f_gumsa_name", txtGumsaName.GetDataValue());
        }

        private void grdDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdDetail.SetBindVarValue("f_hangmog_code", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "hangmog_code"));
            grdDetail.SetBindVarValue("f_specimen_code", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "specimen_code"));
            grdDetail.SetBindVarValue("f_emergency", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "emergency"));
        }
        #endregion

        #region XSavePerformer
//        private class XSavePerformer : IHIS.Framework.ISavePerformer
//        {
//            private CPL0104U00 parent = null;
//            public XSavePerformer(CPL0104U00 parent)
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
//                        cmdText = @"INSERT INTO CPL0104 (SYS_DATE         ,SYS_ID              ,UPD_DATE          ,UPD_ID
//                                                        ,HANGMOG_CODE     ,SPECIMEN_CODE       ,EMERGENCY
//                                                        ,SEX              ,FROM_AGE            ,TO_AGE
//                                                        ,FROM_STANDARD    ,TO_STANDARD         ,NAI_FROM
//                                                        ,NAI_TO           ,HOSP_CODE
//                                               ) VALUES (SYSDATE          ,:f_user_id          ,SYSDATE           ,:f_user_id
//                                                        ,:f_hangmog_code  ,:f_specimen_code    ,:f_emergency
//                                                        ,:f_sex           ,:f_from_age         ,:f_to_age
//                                                        ,:f_from_standard ,:f_to_standard      ,:f_nai_from
//                                                        ,:f_nai_to        ,:f_hosp_code
//                                                        )";
//                        break;
//                    case DataRowState.Modified:
//                        cmdText = @"UPDATE CPL0104
//                                       SET UPD_ID            = :f_user_id
//                                         , UPD_DATE          = SYSDATE
//                                         , FROM_STANDARD     = :f_from_standard
//                                         , TO_STANDARD       = :f_to_standard
//                                     WHERE HANGMOG_CODE      = :f_hangmog_code                          
//                                       AND SPECIMEN_CODE     = :f_specimen_code                        
//                                       AND EMERGENCY         = :f_emergency
//                                       AND SEX               = :f_sex                      
//                                       AND FROM_AGE          = :f_from_age                              
//                                       AND TO_AGE            = :f_to_age
//                                       AND NAI_FROM          = :f_nai_from
//                                       AND NAI_TO            = :f_nai_to                        
//                                       AND HOSP_CODE         = :f_hosp_code";
//                        break;
//                    case DataRowState.Deleted:
//                        cmdText = @"DELETE CPL0104
//                                     WHERE HANGMOG_CODE      = :f_hangmog_code                          
//                                       AND SPECIMEN_CODE     = :f_specimen_code                        
//                                       AND EMERGENCY         = :f_emergency
//                                       AND SEX               = :f_sex                      
//                                       AND FROM_AGE          = :f_from_age                              
//                                       AND TO_AGE            = :f_to_age
//                                       AND NAI_FROM          = :f_nai_from
//                                       AND NAI_TO            = :f_nai_to                        
//                                       AND HOSP_CODE         = :f_hosp_code";
//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion

        private void CPL0104U00_Closing(object sender, CancelEventArgs e)
        {
            if (!mIsSaveSuccess)
                e.Cancel = true;

            mIsSaveSuccess = true;
        }
    }
}

