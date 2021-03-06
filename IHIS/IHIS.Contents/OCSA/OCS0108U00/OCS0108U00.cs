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
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
    /// <summary>
    /// OCS0108U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS0108U00 : IHIS.Framework.XScreen
    {
        #region [Instance Variable]
        //Message처리
        string mbxMsg = "", mbxCap = "";
        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XTextBox txtHangmog_name_inx;
        private IHIS.Framework.XLabel xLabel4;
        private System.Windows.Forms.TreeView tvwSlip_Info;
        private IHIS.Framework.XPanel xPanel4;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XMstGrid grdOCS0103;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XLabel xLabel63;
        private IHIS.Framework.XEditGrid grdOCS0108;
        private IHIS.Framework.XEditGridCell xEditGridCell89;
        private IHIS.Framework.XEditGridCell xEditGridCell90;
        private IHIS.Framework.XEditGridCell xEditGridCell91;
        private IHIS.Framework.XEditGridCell xEditGridCell92;
        private IHIS.Framework.XEditGridCell xEditGridCell93;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XPanel xPanel6;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XDisplayBox dbxSunabDanui;
        private IHIS.Framework.XDisplayBox dbxSubulDanui;
        private IHIS.Framework.XDisplayBox dbxSubulChangeQty;
        private IHIS.Framework.XDisplayBox dbxSunabChangeQty;
        private IHIS.Framework.MultiLayout laySlip_Info;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XHospBox xHospBox;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public OCS0108U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            // TODO comment use connect cloud
//            SaveLayoutList.Add(grdOCS0108);
//            grdOCS0108.SavePerformer = new XSavePerformer(this);

            //Create ParamList and ExecuteQuer
            grdOCS0103.ParamList = new List<string>(new String[] { "f_slip_code", "f_hangmog_name_inx" });
            grdOCS0103.ExecuteQuery = ExecuteQueryGrdOCS0103Item;

            grdOCS0108.ParamList = new List<string>(new String[] { "f_hangmog_code", "f_hangmog_start_date" });
            grdOCS0108.ExecuteQuery = ExecuteQueryGrdOCS0108Item;

            laySlip_Info.ExecuteQuery = ExecuteQueryLaySlipItem;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0108U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xHospBox = new IHIS.Framework.XHospBox();
            this.txtHangmog_name_inx = new IHIS.Framework.XTextBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdOCS0108 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.grdOCS0103 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.dbxSubulChangeQty = new IHIS.Framework.XDisplayBox();
            this.dbxSunabChangeQty = new IHIS.Framework.XDisplayBox();
            this.dbxSubulDanui = new IHIS.Framework.XDisplayBox();
            this.dbxSunabDanui = new IHIS.Framework.XDisplayBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel63 = new IHIS.Framework.XLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.tvwSlip_Info = new System.Windows.Forms.TreeView();
            this.laySlip_Info = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103)).BeginInit();
            this.xPanel6.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.laySlip_Info)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xHospBox);
            this.xPanel1.Controls.Add(this.txtHangmog_name_inx);
            this.xPanel1.Controls.Add(this.xLabel4);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // xHospBox
            // 
            this.xHospBox.BackColor = System.Drawing.Color.Transparent;
            this.xHospBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.xHospBox, "xHospBox");
            this.xHospBox.HospCode = "";
            this.xHospBox.Name = "xHospBox";
            this.xHospBox.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.xHospBox_DataValidating);
            this.xHospBox.FindClick += new System.EventHandler(this.xHospBox_FindClick);
            // 
            // txtHangmog_name_inx
            // 
            resources.ApplyResources(this.txtHangmog_name_inx, "txtHangmog_name_inx");
            this.txtHangmog_name_inx.Name = "txtHangmog_name_inx";
            this.txtHangmog_name_inx.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtHangmog_name_inx_DataValidating);
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Name = "xLabel4";
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xPanel5);
            this.xPanel3.Controls.Add(this.splitter1);
            this.xPanel3.Controls.Add(this.xPanel4);
            this.xPanel3.Controls.Add(this.tvwSlip_Info);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.grdOCS0108);
            this.xPanel5.Controls.Add(this.xPanel6);
            this.xPanel5.Controls.Add(this.xLabel63);
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.Name = "xPanel5";
            // 
            // grdOCS0108
            // 
            this.grdOCS0108.ApplyPaintEventToAllColumn = true;
            this.grdOCS0108.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell89,
            this.xEditGridCell90,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell10});
            this.grdOCS0108.ColPerLine = 4;
            this.grdOCS0108.Cols = 4;
            resources.ApplyResources(this.grdOCS0108, "grdOCS0108");
            this.grdOCS0108.ExecuteQuery = null;
            this.grdOCS0108.FixedRows = 1;
            this.grdOCS0108.FocusColumnName = "ord_danui";
            this.grdOCS0108.HeaderHeights.Add(21);
            this.grdOCS0108.MasterLayout = this.grdOCS0103;
            this.grdOCS0108.Name = "grdOCS0108";
            this.grdOCS0108.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0108.ParamList")));
            this.grdOCS0108.Rows = 2;
            this.grdOCS0108.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0108_GridColumnChanged);
            this.grdOCS0108.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS0108_RowFocusChanged);
            this.grdOCS0108.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdOCS0108_SaveEnd);
            this.grdOCS0108.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0108_GridCellPainting);
            this.grdOCS0108.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS0108_GridColumnProtectModify);
            this.grdOCS0108.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0108_QueryStarting);
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "hangmog_code";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsUpdatable = false;
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell90.CellName = "seq";
            this.xEditGridCell90.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell90.CellWidth = 46;
            this.xEditGridCell90.ExecuteQuery = null;
            this.xEditGridCell90.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell91.CellName = "ord_danui";
            this.xEditGridCell91.CellWidth = 101;
            this.xEditGridCell91.Col = 1;
            this.xEditGridCell91.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell91.ExecuteQuery = null;
            this.xEditGridCell91.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsUpdatable = false;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell92.CellName = "change_qty1";
            this.xEditGridCell92.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell92.CellWidth = 120;
            this.xEditGridCell92.Col = 3;
            this.xEditGridCell92.DecimalDigits = 4;
            this.xEditGridCell92.ExecuteQuery = null;
            this.xEditGridCell92.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell93.CellName = "change_qty2";
            this.xEditGridCell93.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell93.CellWidth = 120;
            this.xEditGridCell93.Col = 2;
            this.xEditGridCell93.DecimalDigits = 4;
            this.xEditGridCell93.ExecuteQuery = null;
            this.xEditGridCell93.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "sunab_danui";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "subul_danui";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "hangmog_start_date";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // grdOCS0103
            // 
            resources.ApplyResources(this.grdOCS0103, "grdOCS0103");
            this.grdOCS0103.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell11});
            this.grdOCS0103.ColPerLine = 4;
            this.grdOCS0103.Cols = 4;
            this.grdOCS0103.ExecuteQuery = null;
            this.grdOCS0103.FixedRows = 1;
            this.grdOCS0103.HeaderHeights.Add(21);
            this.grdOCS0103.Name = "grdOCS0103";
            this.grdOCS0103.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0103.ParamList")));
            this.grdOCS0103.Rows = 2;
            this.grdOCS0103.ToolTipActive = true;
            this.grdOCS0103.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS0103_RowFocusChanged);
            this.grdOCS0103.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0103_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "slip_code";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.CellName = "hangmog_code";
            this.xEditGridCell2.CellWidth = 89;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.CellName = "hangmog_name";
            this.xEditGridCell3.CellWidth = 213;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "sunab_danui";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "sunab_danui_name";
            this.xEditGridCell7.CellWidth = 86;
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "subul_danui";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "subul_danui_name";
            this.xEditGridCell9.CellWidth = 90;
            this.xEditGridCell9.Col = 3;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "hangmog_start_date";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.dbxSubulChangeQty);
            this.xPanel6.Controls.Add(this.dbxSunabChangeQty);
            this.xPanel6.Controls.Add(this.dbxSubulDanui);
            this.xPanel6.Controls.Add(this.dbxSunabDanui);
            this.xPanel6.Controls.Add(this.xLabel3);
            this.xPanel6.Controls.Add(this.xLabel2);
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.Name = "xPanel6";
            // 
            // dbxSubulChangeQty
            // 
            this.dbxSubulChangeQty.DecimalDigits = 4;
            this.dbxSubulChangeQty.EditMaskType = IHIS.Framework.MaskType.Decimal;
            resources.ApplyResources(this.dbxSubulChangeQty, "dbxSubulChangeQty");
            this.dbxSubulChangeQty.Name = "dbxSubulChangeQty";
            // 
            // dbxSunabChangeQty
            // 
            this.dbxSunabChangeQty.DecimalDigits = 4;
            this.dbxSunabChangeQty.EditMaskType = IHIS.Framework.MaskType.Decimal;
            resources.ApplyResources(this.dbxSunabChangeQty, "dbxSunabChangeQty");
            this.dbxSunabChangeQty.Name = "dbxSunabChangeQty";
            // 
            // dbxSubulDanui
            // 
            resources.ApplyResources(this.dbxSubulDanui, "dbxSubulDanui");
            this.dbxSubulDanui.Name = "dbxSubulDanui";
            // 
            // dbxSunabDanui
            // 
            resources.ApplyResources(this.dbxSunabDanui, "dbxSunabDanui");
            this.dbxSunabDanui.Name = "dbxSunabDanui";
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel63
            // 
            this.xLabel63.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            resources.ApplyResources(this.xLabel63, "xLabel63");
            this.xLabel63.EdgeRounding = false;
            this.xLabel63.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel63.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel63.Name = "xLabel63";
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.xLabel1);
            this.xPanel4.Controls.Add(this.grdOCS0103);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Name = "xPanel4";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Name = "xLabel1";
            // 
            // tvwSlip_Info
            // 
            this.tvwSlip_Info.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.tvwSlip_Info, "tvwSlip_Info");
            this.tvwSlip_Info.HideSelection = false;
            this.tvwSlip_Info.ImageList = this.ImageList;
            this.tvwSlip_Info.Name = "tvwSlip_Info";
            this.tvwSlip_Info.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwSlip_Info_AfterSelect);
            // 
            // laySlip_Info
            // 
            this.laySlip_Info.ExecuteQuery = null;
            this.laySlip_Info.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            this.laySlip_Info.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySlip_Info.ParamList")));
            this.laySlip_Info.QueryStarting += new System.ComponentModel.CancelEventHandler(this.laySlip_Info_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "slip_gubun";
            this.multiLayoutItem1.IsNotNull = true;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "slip_gubun_name";
            this.multiLayoutItem2.IsNotNull = true;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "slip_code";
            this.multiLayoutItem3.IsNotNull = true;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "slip_name";
            this.multiLayoutItem4.IsNotNull = true;
            // 
            // OCS0108U00
            // 
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            resources.ApplyResources(this, "$this");
            this.Name = "OCS0108U00";
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103)).EndInit();
            this.xPanel6.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.laySlip_Info)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Common Variables
        //private string mHospCode = EnvironInfo.HospCode;
        private string mHospCode = UserInfo.HospCode;
        #endregion

        #region [Screen Event]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // 2015.06.22 Cloud updated START
            //this.mHospCode = "K01"; // test data
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                xHospBox.Visible = true;
                xButtonList1.SetEnabled(FunctionType.Insert, false);
                xButtonList1.SetEnabled(FunctionType.Update, false);
                xButtonList1.SetEnabled(FunctionType.Delete, false);
            }
            else
            {
                xHospBox.Visible = false;
            }
            // 2015.06.22 Cloud updated END

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {

            //Set Current Grid
            this.CurrMSLayout = this.grdOCS0103;
            this.CurrMQLayout = this.grdOCS0103;

            splitter1.BackColor = XColor.XPanelBorderColor.Color;

            //Set M/D Relation
            grdOCS0108.SetRelationKey("hangmog_code", "hangmog_code");

            //ComboBox 생성
            CreateCombo();

            //laySlip_Info.QueryLayout(false);
            laySlip_Info.QueryLayout(true);

            //Show TreeView 
            ShowSlip_Info();
        }
        #endregion

        #region [Combo 생성]
        private void CreateCombo()
        {
            IHIS.Framework.MultiLayout layoutCombo = new MultiLayout();

            //Order danui DataLayout;
            layoutCombo.Reset();
            layoutCombo.LayoutItems.Clear();
            layoutCombo.LayoutItems.Add("code", DataType.String);
            layoutCombo.LayoutItems.Add("code_name", DataType.String);
            layoutCombo.LayoutItems.Add("seq", DataType.String);

            layoutCombo.InitializeLayoutTable();

            // TODO comment use connect to cloud
//            layoutCombo.QuerySQL = " SELECT '', ' ', '00' "
//                                 + "   FROM DUAL "
//                                 + "  UNION ALL "
//                                 + " SELECT CODE, CODE||': '||CODE_NAME CODE_NAME, CODE SEQ "
//                                 + "   FROM OCS0132 "
//                                 + "  WHERE HOSP_CODE = '"+mHospCode+"' AND CODE_TYPE = 'ORD_DANUI' "
//                                 + "  ORDER BY 3 ";

            layoutCombo.ExecuteQuery = ExecuteQueryCreateComboItem;
            if (layoutCombo.QueryLayout(true) && layoutCombo.RowCount > 0)
            {
                grdOCS0108.SetComboItems("ord_danui", layoutCombo.LayoutTable, "code_name", "code");
            }
        }
        #endregion

        #region [TreeView Slip Info]
        private void ShowSlip_Info()
        {
            tvwSlip_Info.Nodes.Clear();
            if (laySlip_Info.RowCount < 1) return;

            string slip_gubun = "";
            TreeNode node;

            foreach (DataRow row in laySlip_Info.LayoutTable.Rows)
            {
                if (slip_gubun != row["slip_gubun"].ToString())
                {
                    node = new TreeNode(row["slip_gubun_name"].ToString());
                    node.Tag = row["slip_gubun"].ToString();
                    tvwSlip_Info.Nodes.Add(node);
                    slip_gubun = row["slip_gubun"].ToString();
                }

                node = new TreeNode(row["slip_name"].ToString());
                node.Tag = row["slip_code"].ToString();
                tvwSlip_Info.Nodes[tvwSlip_Info.Nodes.Count - 1].Nodes.Add(node);
            }

            tvwSlip_Info.SelectedNode = tvwSlip_Info.Nodes[0].Nodes[0];
        }

        private void tvwSlip_Info_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                if (tvwSlip_Info.SelectedNode.Parent == null) return;

                string slip_code = tvwSlip_Info.SelectedNode.Tag.ToString();

                grdOCS0103.SetBindVarValue("f_slip_code", slip_code);
                grdOCS0103.SetBindVarValue("f_hangmog_name_inx", "");
                grdOCS0103.QueryLayout(true);
            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }
        #endregion

        #region [Button List Event]
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            SetMsg("");

            switch (e.Func)
            {
                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    if (this.CurrMSLayout != grdOCS0108 || grdOCS0103.CurrentRowNumber < 0)
                        return;

                    DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);
                    if (chkCell.RowNumber < 0)
                    {
                        int currentRow = grdOCS0108.InsertRow();
                        grdOCS0108.SetItemValue(currentRow, "hangmog_code", grdOCS0103.GetItemString(grdOCS0103.CurrentRowNumber, "hangmog_code"));
                        grdOCS0108.SetItemValue(currentRow, "hangmog_start_date", grdOCS0103.GetItemString(grdOCS0103.CurrentRowNumber, "hangmog_start_date"));
                        grdOCS0108.SetItemValue(currentRow, "seq", MaxOrd_danui_max());
                        grdOCS0108.SetItemValue(currentRow, "sunab_danui", "000");
                        grdOCS0108.SetItemValue(currentRow, "subul_danui", "000");
                    }
                    else
                        ((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
                    break;
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    string hangmog_name_inx = txtHangmog_name_inx.GetDataValue().Trim();
                    if (hangmog_name_inx == "") return;
                    grdOCS0103.SetBindVarValue("f_slip_code", "");
                    grdOCS0103.SetBindVarValue("f_hangmog_name_inx", hangmog_name_inx);
                    grdOCS0103.QueryLayout(true);
                    break;
                case FunctionType.Update:
                    if (SaveStart())
                    {
                        bool isGrdOCS0108Save = GrdOCS0108SaveLayout(); 
                        if (isGrdOCS0108Save)
                        {
                            mbxMsg = Resources.MSG005_MSG;
                            mbxCap = Resources.MSG001_CAP;
                            SetMsg(mbxMsg);
                            XMessageBox.Show(mbxMsg, mbxCap);
                        }
                        else
                        {
                            mbxMsg = Resources.MSG006_MSG;
                            mbxMsg = mbxMsg + Service.ErrMsg;
                            mbxCap = Resources.MSG001_CAP;
                            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Hand);
                        }
                    }
                    grdOCS0108.ResetUpdate();
//                        grdOCS0108.SaveLayout();

                    break;
                case FunctionType.Delete:
                    if (this.CurrMSLayout == grdOCS0108)
                    {
                        if (grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "sunab_danui") != "000")
                        {
                            mbxMsg = Resources.MSG001_MSG;
                            mbxMsg = mbxMsg + Service.ErrMsg;
                            e.IsBaseCall = false;
                        }
                        else if (grdOCS0108.GetItemString(grdOCS0108.CurrentRowNumber, "subul_danui") != "000")
                        {
                            mbxMsg = Resources.MSG002_MSG;
                            mbxMsg = mbxMsg + Service.ErrMsg;
                            e.IsBaseCall = false;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Delete:
                    CalChangeSuryang(grdOCS0108.CurrentRowNumber);
                    break;
            }
        }
        #endregion

        #region [grdOCS0103]
        private void grdOCS0103_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (e.CurrentRow < 0)
            {
                // 수납단위, 수불단위
                dbxSunabDanui.SetDataValue("");
                dbxSubulDanui.SetDataValue("");
            }
            else
            {
                // 수납단위, 수불단위
                dbxSunabDanui.SetDataValue(grdOCS0103.GetItemString(e.CurrentRow, "sunab_danui_name"));
                dbxSubulDanui.SetDataValue(grdOCS0103.GetItemString(e.CurrentRow, "subul_danui_name"));
            }
        }

        private void grdOCS0103_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdOCS0103.SetBindVarValue("f_hosp_code", mHospCode);
            dbxSunabDanui.SetDataValue("");
            dbxSubulDanui.SetDataValue("");
        }
        #endregion

        #region [grdOCS0108]
        private void grdOCS0108_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (e.DataRow["sunab_danui"].ToString() != "000" && e.DataRow["sunab_danui"].ToString() != "0" && !TypeCheck.IsNull(e.DataRow["sunab_danui"].ToString()))
            {
                e.BackColor = XColor.XCalendarSelectedDateBackColor.Color;
            }
            else if (e.DataRow["subul_danui"].ToString() != "000" && e.DataRow["subul_danui"].ToString() != "0" && !TypeCheck.IsNull(e.DataRow["subul_danui"].ToString()))
            {
                e.BackColor = XColor.XCalendarDateBackColor.Color;
            }
        }

        private void grdOCS0108_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            e.Cancel = false;

            switch (e.ColName)
            {
                case "seq":
                    if (e.ChangeValue.ToString().Trim() == "1")
                    {
                        mbxMsg = Resources.MSG003_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                    }
                    break;
                case "ord_danui":
                    if (e.ChangeValue.ToString().Trim() == "") break;

                    //중복 Check
                    for (int i = 0; i < grdOCS0108.RowCount; i++)
                    {
                        if (i != e.RowNumber)
                        {
                            if (grdOCS0108.GetItemString(i, "ord_danui").Trim() == e.ChangeValue.ToString().Trim())
                            {
                                mbxMsg = Resources.MSG004_MSG;
                                mbxCap = "";
                                XMessageBox.Show(mbxMsg, mbxCap);
                                e.Cancel = true;
                            }
                        }
                    }
                    break;
                default:
                    PostCallHelper.PostCall(new PostMethodInt(CalChangeSuryang), e.RowNumber);
                    break;
            }
        }

        private void grdOCS0108_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            e.Protect = false;

            //항목에서 등록하는 부분은 protect
            if (e.DataRow["sunab_danui"].ToString() != "000" && !TypeCheck.IsNull(e.DataRow["sunab_danui"].ToString()))
            {
                if (e.ColName == "ord_danui" || e.ColName == "change_qty1")
                    e.Protect = true; ;
            }

            if (e.DataRow["subul_danui"].ToString() != "000" && !TypeCheck.IsNull(e.DataRow["subul_danui"].ToString()))
            {
                if (e.ColName == "ord_danui" || e.ColName == "change_qty2")
                    e.Protect = true;
            }
        }

        private void grdOCS0108_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            CalChangeSuryang(e.CurrentRow);
        }

        private void grdOCS0108_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdOCS0108.SetBindVarValue("f_hangmog_code", grdOCS0103.GetItemString(grdOCS0103.CurrentRowNumber, "hangmog_code"));
            grdOCS0108.SetBindVarValue("f_hosp_code", mHospCode);
            grdOCS0108.SetBindVarValue("f_hangmog_start_date", this.grdOCS0103.GetItemString(grdOCS0103.CurrentRowNumber, "hangmog_start_date"));
            dbxSunabChangeQty.SetDataValue("");
            dbxSubulChangeQty.SetDataValue("");
        }

        private void grdOCS0108_SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
        {
            bool isGrdOCS0108Save = false;
            isGrdOCS0108Save = e.IsSuccess;
            if (isGrdOCS0108Save)
            {
                mbxMsg = Resources.MSG005_MSG;
                SetMsg(mbxMsg);
            }
            else
            {
                mbxMsg = Resources.MSG006_MSG;
                mbxMsg = mbxMsg + Service.ErrMsg;
                mbxCap = "Save Error";
                XMessageBox.Show(mbxMsg, mbxCap);
            }
        }
        #endregion

        #region Insert한 Row 중에 Not Null필드 미입력 Row Search (GetEmptyNewRow)
        /// <summary>
        /// Insert한 Row 중에 Not Null필드 미입력 Row Search
        /// </summary>
        /// <remarks>
        /// Grid 컬럼 속성이 Not Null과 Visible, Not ReadOnly 항목으로 체크한다..
        /// </remarks>
        /// <param name="aGrd"> XEditGrid  </param>
        /// <returns> celReturn.RowNumber < 0 미입력데이타 없음 </returns>
        private DataGridCell GetEmptyNewRow(object aGrd)
        {
            DataGridCell celReturn = new DataGridCell(-1, -1);

            if (aGrd == null) return celReturn;

            XEditGrid grdChk = null;

            try
            {
                grdChk = (XEditGrid)aGrd;
            }
            catch
            {
                return celReturn;
            }

            foreach (XEditGridCell cell in grdChk.CellInfos)
            {
                // NotNull Check
                if (cell.IsNotNull && cell.IsVisible && !cell.IsReadOnly)
                {
                    for (int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
                    {
                        if (grdChk.GetRowState(rowIndex) == DataRowState.Added && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
                        {
                            celReturn.ColumnNumber = cell.Col;
                            celReturn.RowNumber = rowIndex;
                            break;
                        }
                    }

                    if (celReturn.RowNumber < 0)
                        continue;
                    else
                        break;
                }
            }

            return celReturn;
        }
        #endregion

        #region [Control]
        private void txtHangmog_name_inx_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                if (e.DataValue.Trim() == "") return;

                grdOCS0103.SetBindVarValue("f_slip_code", "");
                grdOCS0103.SetBindVarValue("f_hangmog_name_inx", JapanTextHelper.GetFullKatakana(e.DataValue.Trim(), true));
                grdOCS0103.QueryLayout(true);

            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }
        #endregion

        #region [처방단위]
        private bool IsExistDanui(string danui)
        {
            bool returnValue = false;

            if (grdOCS0108.LayoutTable.Select(" ord_danui = '" + danui + "' ", "").Length > 0)
                returnValue = true;

            return returnValue;
        }

        private void IsExistAndInsertDanui(string gubun, string danui)
        {
            if (!IsExistDanui(danui) && danui != "000" && !TypeCheck.IsNull(danui))
            {
                for (int i = 0; i < grdOCS0108.RowCount; i++)
                {
                    if (gubun == "0")
                        grdOCS0108.SetItemValue(i, "sunab_danui", "000");
                    else
                        grdOCS0108.SetItemValue(i, "subul_danui", "000");
                }

                int insertRow = grdOCS0108.InsertRow(-1);

                grdOCS0108.SetItemValue(insertRow, "ord_danui", danui);
                grdOCS0108.SetItemValue(insertRow, "seq", MaxOrd_danui_max());
                grdOCS0108.SetItemValue(insertRow, "subul_danui", "000");
                grdOCS0108.SetItemValue(insertRow, "sunab_danui", "000");

                if (gubun == "0")
                {
                    grdOCS0108.SetItemValue(insertRow, "sunab_danui", danui);
                    grdOCS0108.SetItemValue(insertRow, "change_qty1", 1);
                    grdOCS0108.SetItemValue(insertRow, "change_qty2", 0);
                    grdOCS0108.SetFocusToItem(insertRow, "change_qty2");
                }
                else if (gubun == "1")
                {
                    grdOCS0108.SetItemValue(insertRow, "subul_danui", danui);
                    grdOCS0108.SetItemValue(insertRow, "change_qty1", 0);
                    grdOCS0108.SetItemValue(insertRow, "change_qty2", 1);
                    grdOCS0108.SetFocusToItem(insertRow, "change_qty1");
                }
                else
                {
                    grdOCS0108.SetItemValue(insertRow, "change_qty1", 0);
                    grdOCS0108.SetItemValue(insertRow, "change_qty2", 0);
                    grdOCS0108.SetFocusToItem(insertRow, "change_qty1");
                }
            }
            else if (danui != "000" && !TypeCheck.IsNull(danui))
            {
                for (int i = 0; i < grdOCS0108.RowCount; i++)
                {
                    if (gubun == "0")
                        grdOCS0108.SetItemValue(i, "sunab_danui", "000");
                    else if (gubun == "1")
                        grdOCS0108.SetItemValue(i, "subul_danui", "000");
                }

                for (int i = 0; i < grdOCS0108.RowCount; i++)
                {
                    if (grdOCS0108.GetItemString(i, "ord_danui") == danui)
                    {
                        if (gubun == "0")
                        {
                            grdOCS0108.SetItemValue(i, "sunab_danui", danui);
                            grdOCS0108.SetItemValue(i, "change_qty1", 1);
                        }
                        else if (gubun == "1")
                        {
                            grdOCS0108.SetItemValue(i, "subul_danui", danui);
                            grdOCS0108.SetItemValue(i, "change_qty2", 1);
                        }
                        break;
                    }
                }
            }
        }

        private int MaxOrd_danui_max()
        {
            int returnValue = 0;

            for (int i = 0; i < grdOCS0108.RowCount; i++)
            {
                if (!TypeCheck.IsNull(grdOCS0108.GetItemString(i, "seq")))
                {
                    if (int.Parse(grdOCS0108.GetItemString(i, "seq")) > returnValue)
                        returnValue = int.Parse(grdOCS0108.GetItemString(i, "seq"));
                }
            }

            returnValue++;

            return returnValue;
        }
        #endregion

        #region [Function]
        private void CalChangeSuryang(int rowNumber)
        {
            //double sunab_base    = 0;
            //double subul_base    = 0;

            this.AcceptData();

            double sunab_cur = 0;
            double subul_cur = 0;
            double sunab_change = 0;
            double subul_change = 0;

            dbxSunabChangeQty.SetDataValue("");
            dbxSubulChangeQty.SetDataValue("");

            if (rowNumber < 0) return;

            if (!TypeCheck.IsNull(grdOCS0108.GetItemString(rowNumber, "change_qty1")))
                sunab_cur = Double.Parse(grdOCS0108.GetItemString(rowNumber, "change_qty1"));

            if (!TypeCheck.IsNull(grdOCS0108.GetItemString(rowNumber, "change_qty2")))
                subul_cur = Double.Parse(grdOCS0108.GetItemString(rowNumber, "change_qty2"));

            if (sunab_cur == 0)
                sunab_change = 1;
            else
                sunab_change = 1.0 / sunab_cur;

            if (subul_cur == 0)
                subul_change = 1;
            else
                subul_change = 1.0 / subul_cur;

            dbxSunabChangeQty.SetDataValue(sunab_change);
            dbxSubulChangeQty.SetDataValue(subul_change);
        }

        private bool SaveStart()
        {
            AcceptData();

            //OCS0108
            for (int rowIndex = 0; rowIndex < grdOCS0108.RowCount; rowIndex++)
            {
                if (grdOCS0108.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOCS0108.GetItemString(rowIndex, "ord_danui").Trim() == "")
                    {
                        grdOCS0108.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                }

                if (grdOCS0108.GetItemString(rowIndex, "seq").Trim() == "")
                {
                    mbxMsg = Resources.MSG003_MSG;
                    mbxCap = "";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    grdOCS0108.SetFocusToItem(rowIndex, "seq");
                    return false;
                }

                if (grdOCS0108.GetItemString(rowIndex, "change_qty1").Trim() == "" || grdOCS0108.GetItemString(rowIndex, "change_qty1").Trim() == "0")
                {
                    mbxMsg = Resources.MSG007_MSG;
                    mbxCap = "";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    grdOCS0108.SetFocusToItem(rowIndex, "seq");
                    return false;
                }

                if (grdOCS0108.GetItemString(rowIndex, "change_qty2").Trim() == "" || grdOCS0108.GetItemString(rowIndex, "change_qty2").Trim() == "0")
                {
                    mbxMsg = Resources.MSG008_MSG;
                    mbxCap = "";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    grdOCS0108.SetFocusToItem(rowIndex, "seq");
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region [ laySlip SetBindVarValue Setting ]
        private void laySlip_Info_QueryStarting(object sender, CancelEventArgs e)
        {
            laySlip_Info.SetBindVarValue("f_hosp_code", mHospCode);
        }
        #endregion

        #region Connect to cloud service 

        /// <summary>
        /// ExecuteQueryCreateComboItem
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryCreateComboItem(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0108U00CreateComboArgs vOCS0108U00CreateComboArgs = new OCS0108U00CreateComboArgs(this.mHospCode);
            OCS0108U00CreateComboResult result = CloudService.Instance.Submit<OCS0108U00CreateComboResult, OCS0108U00CreateComboArgs>(vOCS0108U00CreateComboArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0108U00CreateComboItemInfo item in result.ComboItem)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeName,
                        item.Seq
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdOCS0103Item
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOCS0103Item(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0108U00grdOCS0103Args vOCS0108U00grdOCS0103Args = new OCS0108U00grdOCS0103Args();
            vOCS0108U00grdOCS0103Args.HangmogNameInx = bc["f_hangmog_name_inx"] != null ? bc["f_hangmog_name_inx"].VarValue : "";
            vOCS0108U00grdOCS0103Args.SlipCode = bc["f_slip_code"] != null ? bc["f_slip_code"].VarValue : "";
            vOCS0108U00grdOCS0103Args.HospCode = this.mHospCode;
            OCS0108U00grdOCS0103Result result = CloudService.Instance.Submit<OCS0108U00grdOCS0103Result, OCS0108U00grdOCS0103Args>(vOCS0108U00grdOCS0103Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0108U00grdOCS0103ItemInfo item in result.GrdOcs0103)
                {
                    object[] objects =
                    {
                        item.SlipCode,
                        item.HangmogCode,
                        item.HangmogName,
                        item.SunabDanui,
                        item.SunabDanuiName,
                        item.SubulDanui,
                        item.SubulDanuiName,
                        item.HangmogStartDate
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdOCS0108Item
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOCS0108Item(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0108U00grdOCS0108Args vOCS0108U00grdOCS0108Args = new OCS0108U00grdOCS0108Args();
            vOCS0108U00grdOCS0108Args.HangmogStartDate = bc["f_hangmog_start_date"] != null ? bc["f_hangmog_start_date"].VarValue : "";
            vOCS0108U00grdOCS0108Args.HangmogCode = bc["f_hangmog_code"] != null ? bc["f_hangmog_code"].VarValue : "";
            vOCS0108U00grdOCS0108Args.HospCode = this.mHospCode;
            OCS0108U00grdOCS0108Result result = CloudService.Instance.Submit<OCS0108U00grdOCS0108Result, OCS0108U00grdOCS0108Args>(vOCS0108U00grdOCS0108Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0108U00grdOCS0108ItemInfo item in result.GrdOcs0108)
                {
                    object[] objects =
                    {
                        item.HangmogCode,
                        item.Seq,
                        item.OrdDanui,
                        item.ChangeQty1,
                        item.ChangeQty2,
                        item.SunabDanui,
                        item.SubulDanui,
                        item.HangmogStartDate
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryLaySlipItem
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryLaySlipItem(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0108U00laySlipArgs vOCS0108U00laySlipArgs = new OCS0108U00laySlipArgs(this.mHospCode);
            OCS0108U00laySlipResult result = CloudService.Instance.Submit<OCS0108U00laySlipResult, OCS0108U00laySlipArgs>(vOCS0108U00laySlipArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0108U00laySlipItemInfo item in result.LaySlip)
                {
                    object[] objects =
                    {
                        item.SlipGubun,
                        item.SlipGubunName,
                        item.SlipCode,
                        item.SlipName
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool GrdOCS0108SaveLayout()
        {
            OCS0108U00ExecuteArgs args = new OCS0108U00ExecuteArgs();
            args.ItemInfo = CreateListGrdOCS0108Item();
            args.UserId = UserInfo.UserID;
            args.HospCode = this.mHospCode;
            UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, OCS0108U00ExecuteArgs>(args);
            if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
                updateResult.Result == false)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// CreateListGrdOCS0108Item
        /// </summary>
        /// <returns></returns>
        private List<OCS0108U00grdOCS0108ItemInfo> CreateListGrdOCS0108Item()
        {
            List<OCS0108U00grdOCS0108ItemInfo> listgrOcs0108ItemInfo = new List<OCS0108U00grdOCS0108ItemInfo>();
            for (int i = 0; i < grdOCS0108.RowCount; i++)
            {
                if (grdOCS0108.GetRowState(i) == DataRowState.Added ||
                    grdOCS0108.GetRowState(i) == DataRowState.Modified)
                {
                    OCS0108U00grdOCS0108ItemInfo ocs0108ItemInfo = new OCS0108U00grdOCS0108ItemInfo();
                    ocs0108ItemInfo.HangmogCode = grdOCS0108.GetItemString(i, "hangmog_code");
                    ocs0108ItemInfo.Seq = grdOCS0108.GetItemString(i, "seq");
                    ocs0108ItemInfo.OrdDanui = grdOCS0108.GetItemString(i, "ord_danui");
                    ocs0108ItemInfo.ChangeQty1 = grdOCS0108.GetItemString(i, "change_qty1");
                    ocs0108ItemInfo.ChangeQty2 = grdOCS0108.GetItemString(i, "change_qty2");
                    ocs0108ItemInfo.SunabDanui = grdOCS0108.GetItemString(i, "sunab_danui");
                    ocs0108ItemInfo.SubulDanui = grdOCS0108.GetItemString(i, "subul_danui");
                    ocs0108ItemInfo.HangmogStartDate = grdOCS0108.GetItemString(i, "hangmog_start_date");
                    ocs0108ItemInfo.DataRowState = grdOCS0108.GetRowState(i).ToString();

                    listgrOcs0108ItemInfo.Add(ocs0108ItemInfo);
                }
            }
            if (grdOCS0108.DeletedRowTable != null && grdOCS0108.DisplayRowCount > 0)
            {
                foreach (DataRow row in grdOCS0108.DeletedRowTable.Rows)
                {
                    OCS0108U00grdOCS0108ItemInfo ocs0108ItemInfo = new OCS0108U00grdOCS0108ItemInfo();
                    ocs0108ItemInfo.HangmogCode = row["hangmog_code"].ToString();
                    ocs0108ItemInfo.Seq = row["seq"].ToString();
                    ocs0108ItemInfo.OrdDanui = row["ord_danui"].ToString();
                    ocs0108ItemInfo.ChangeQty1 = row["change_qty1"].ToString();
                    ocs0108ItemInfo.ChangeQty2 = row["change_qty2"].ToString();
                    ocs0108ItemInfo.SunabDanui = row["sunab_danui"].ToString();
                    ocs0108ItemInfo.SubulDanui = row["subul_danui"].ToString();
                    ocs0108ItemInfo.HangmogStartDate = row["hangmog_start_date"].ToString();
                    ocs0108ItemInfo.DataRowState = DataRowState.Deleted.ToString();

                    listgrOcs0108ItemInfo.Add(ocs0108ItemInfo);
                }
                
            }
            return listgrOcs0108ItemInfo;
        }
        #endregion

        #region [XSavePerformer Class]
        //private class XSavePerformer : IHIS.Framework.ISavePerformer
        //{
        //    private OCS0108U00 parent = null;

        //    public XSavePerformer(OCS0108U00 parent)
        //    {
        //        this.parent = parent;
        //    }

        //    public bool Execute(char callerID, RowDataItem item)
        //    {
        //        string cmdText = "";
        //        item.BindVarList.Add("f_user_id", UserInfo.UserID);
        //        item.BindVarList.Add("f_hosp_code", parent.mHospCode);

        //        switch (item.RowState)
        //        {
        //            case DataRowState.Added:
        //                cmdText = "INSERT INTO OCS0108 "
        //                        + "	  (SYS_DATE, SYS_ID, HANGMOG_CODE, ORD_DANUI, SEQ, CHANGE_QTY1, CHANGE_QTY2, HOSP_CODE, HANGMOG_START_DATE) "
        //                        + "VALUES "
        //                        + "	  (SYSDATE, :f_user_id, :f_hangmog_code, :f_ord_danui, :f_seq, :f_change_qty1, :f_change_qty2, :f_hosp_code, :f_hangmog_start_date)";
        //                break;
        //            case DataRowState.Modified:
        //                cmdText = "UPDATE OCS0108 "
        //                        + "	  SET UPD_ID       = :f_user_id     , "
        //                        + "	      UPD_DATE     = SYSDATE        , "
        //                        + "		  SEQ          = :f_seq         , "
        //                        + "       CHANGE_QTY1  = :f_change_qty1 , "
        //                        + "       CHANGE_QTY2  = :f_change_qty2   "
        //                        + "	WHERE HANGMOG_CODE = :f_hangmog_code  "
        //                        + "   AND HANGMOG_START_DATE = :f_hangmog_start_date "
        //                        + "	  AND ORD_DANUI    = :f_ord_danui     "
        //                        + "   AND HOSP_CODE    = :f_hosp_code     ";
        //                break;
        //            case DataRowState.Deleted:
        //                cmdText = "DELETE OCS0108 "
        //                        + "	WHERE HANGMOG_CODE = :f_hangmog_code "
        //                        + "   AND HANGMOG_START_DATE = :f_hangmog_start_date "
        //                        + "	  AND ORD_DANUI    = :f_ord_danui    "
        //                        + "   AND HOSP_CODE    = :f_hosp_code    ";
        //                break;
        //        }
        //        return Service.ExecuteNonQuery(cmdText, item.BindVarList);
        //    }
        //}
        #endregion

        #region xHospBox events
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

        private void RefreshScreen()
        {
            laySlip_Info.QueryLayout(true);
            grdOCS0103.QueryLayout(true);
            grdOCS0108.QueryLayout(true);
        }
        #endregion
    }
}

