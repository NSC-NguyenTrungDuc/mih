using System;
using System.Collections.Generic;
using System.Text;
using IHIS.Framework;
using System.Windows.Forms;

namespace IHIS.OCSO
{
    public partial class UCINJ1001U01
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCINJ1001U01));
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.fwkCmt = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.dw_jusa = new IHIS.Framework.XDataWindow();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.grdDetail = new IHIS.Framework.XMstGrid();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.dtpActingDate = new IHIS.Framework.XDatePicker();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.pnlFillInBottom = new IHIS.Framework.XPanel();
            this.xPanel10 = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.btnCmtClear = new IHIS.Framework.XButton();
            this.dboxCmt = new IHIS.Framework.XDisplayBox();
            this.txtSilsiRemark = new IHIS.Framework.XRichTextBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.fbxCmt = new IHIS.Framework.XFindBox();
            this.pnlDetailFill = new IHIS.Framework.XPanel();
            this.pnlDetailTop = new IHIS.Framework.XPanel();
            this.pnlDetailDate = new IHIS.Framework.XPanel();
            this.dw1 = new IHIS.Framework.XDataWindow();
            this.xDataWindow1 = new IHIS.Framework.XDataWindow();
            this.grdOCS1003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.pnlDetailInfo = new IHIS.Framework.XPanel();
            this.dw_jusa_lable = new IHIS.Framework.XDataWindow();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.pbxReserDate = new System.Windows.Forms.PictureBox();
            this.pbxCPL = new System.Windows.Forms.PictureBox();
            this.btnCPL = new System.Windows.Forms.Button();
            this.btnTodayOrder = new System.Windows.Forms.Button();
            this.btnPostOrder = new System.Windows.Forms.Button();
            this.btnPreOrder = new System.Windows.Forms.Button();
            this.fwkActor = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.layLableNew = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.layOrderPrint = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem40 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem52 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.layTemp = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem57 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem58 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem59 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem60 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem61 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem62 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem63 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem64 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem65 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem66 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem67 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem68 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem69 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem70 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem71 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem72 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem73 = new IHIS.Framework.MultiLayoutItem();
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.layReserDate = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.layCPLOrderYN = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.layPrintName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.mlayConstantInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.pnlFillInBottom.SuspendLayout();
            this.xPanel10.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.pnlDetailFill.SuspendLayout();
            this.pnlDetailTop.SuspendLayout();
            this.pnlDetailDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).BeginInit();
            this.pnlDetailInfo.SuspendLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxReserDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCPL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layLableNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            this.ImageList.Images.SetKeyName(5, "");
            this.ImageList.Images.SetKeyName(6, "항암요법.gif");
            this.ImageList.Images.SetKeyName(7, "핑크볼.gif");
            this.ImageList.Images.SetKeyName(8, "채열실.ico");
            this.ImageList.Images.SetKeyName(9, "RR401.ico");
            this.ImageList.Images.SetKeyName(10, "작성.gif");
            this.ImageList.Images.SetKeyName(11, "임상연구.gif");
            this.ImageList.Images.SetKeyName(12, "조회.gif");
            this.ImageList.Images.SetKeyName(13, "적용.gif");
            this.ImageList.Images.SetKeyName(14, "삭제.gif");
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 1;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 0;
            // 
            // fwkCmt
            // 
            this.fwkCmt.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkCmt.ExecuteQuery = null;
            this.fwkCmt.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCmt.ParamList")));
            this.fwkCmt.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkCmt.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 140;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // dw_jusa
            // 
            resources.ApplyResources(this.dw_jusa, "dw_jusa");
            this.dw_jusa.DataWindowObject = "d_inj_jusa_a5";
            this.dw_jusa.LibraryList = "INJS\\injs.inj1001u01.pbd";
            this.dw_jusa.Name = "dw_jusa";
            this.dw_jusa.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            // 
            // xGridCell1
            // 
            this.xGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            this.xGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xGridCell2
            // 
            this.xGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xGridCell2, "xGridCell2");
            this.xGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // grdDetail
            // 
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell8,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell12,
            this.xEditGridCell30,
            this.xEditGridCell19,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell9,
            this.xEditGridCell34,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell21,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell18,
            this.xEditGridCell23,
            this.xEditGridCell43,
            this.xEditGridCell13,
            this.xEditGridCell44,
            this.xEditGridCell24,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell22,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell14,
            this.xEditGridCell59,
            this.xEditGridCell17,
            this.xEditGridCell60,
            this.xEditGridCell16,
            this.xEditGridCell15,
            this.xEditGridCell61,
            this.xEditGridCell64,
            this.xEditGridCell74,
            this.xEditGridCell76,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell86});
            this.grdDetail.ColPerLine = 13;
            this.grdDetail.Cols = 14;
            this.grdDetail.ControlBinding = true;
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedCols = 1;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.HeaderHeights.Add(21);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.RowHeaderVisible = true;
            this.grdDetail.Rows = 2;
            this.grdDetail.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdDetail.ToolTipActive = true;
            this.grdDetail.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdDetail_QueryEnd);
            this.grdDetail.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdDetail_RowFocusChanged);
            this.grdDetail.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdDetail_GridCellPainting);
            this.grdDetail.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdDetail_ItemValueChanging);
            this.grdDetail.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdDetail_GridColumnProtectModify);
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.xEditGridCell8.ApplyPaintingEvent = true;
            this.xEditGridCell8.CellName = "group_ser";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell8.CellWidth = 52;
            this.xEditGridCell8.Col = 2;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.xEditGridCell8.SuppressRepeating = true;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell27.CellName = "pkinj1002";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            this.xEditGridCell27.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell28.CellName = "fkinj1001";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            this.xEditGridCell28.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell29.CellName = "fkocs1003";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            this.xEditGridCell29.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell12.ApplyPaintingEvent = true;
            this.xEditGridCell12.CellName = "hangmog_name";
            this.xEditGridCell12.CellWidth = 232;
            this.xEditGridCell12.Col = 4;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell30.CellName = "seq";
            this.xEditGridCell30.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            this.xEditGridCell30.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell19.ApplyPaintingEvent = true;
            this.xEditGridCell19.CellName = "tonggye_code";
            this.xEditGridCell19.CellWidth = 110;
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            this.xEditGridCell19.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell31.CellName = "magam_date";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            this.xEditGridCell31.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell32.CellName = "magam_jangso";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            this.xEditGridCell32.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell33.CellName = "magam_ser";
            this.xEditGridCell33.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell9.ApplyPaintingEvent = true;
            this.xEditGridCell9.CellName = "reser_date";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell9.CellWidth = 75;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.EnableSort = true;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell34.CellName = "reser_time";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsUpdatable = false;
            this.xEditGridCell34.IsUpdCol = false;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            this.xEditGridCell34.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell10.ApplyPaintingEvent = true;
            this.xEditGridCell10.CellName = "jubsu_date";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell10.CellWidth = 73;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell11.ApplyPaintingEvent = true;
            this.xEditGridCell11.CellName = "hangmog_code";
            this.xEditGridCell11.CellWidth = 70;
            this.xEditGridCell11.Col = 3;
            this.xEditGridCell11.EnableSort = true;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell35.CellName = "jusa_buui";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            this.xEditGridCell35.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell36.CellName = "acting_jangso";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell37.ApplyPaintingEvent = true;
            this.xEditGridCell37.CellName = "acting_date";
            this.xEditGridCell37.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell37.CellWidth = 94;
            this.xEditGridCell37.Col = 13;
            this.xEditGridCell37.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell37.EnableSort = true;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell38.CellName = "acting_time";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            this.xEditGridCell38.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell39.CellName = "company_code";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            this.xEditGridCell39.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            this.xEditGridCell39.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell40.CellName = "lot_no";
            this.xEditGridCell40.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            this.xEditGridCell40.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell21.ApplyPaintingEvent = true;
            this.xEditGridCell21.CellName = "chasu_code";
            this.xEditGridCell21.CellWidth = 25;
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            this.xEditGridCell21.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell41.CellName = "pw_result";
            this.xEditGridCell41.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            this.xEditGridCell41.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            this.xEditGridCell41.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell42.CellName = "cs_result";
            this.xEditGridCell42.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            this.xEditGridCell42.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsReadOnly = true;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            this.xEditGridCell42.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell18.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell18.ApplyPaintingEvent = true;
            this.xEditGridCell18.CellName = "ast";
            this.xEditGridCell18.CellWidth = 27;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell23.ApplyPaintingEvent = true;
            this.xEditGridCell23.CellName = "acting_flag";
            this.xEditGridCell23.CellWidth = 61;
            this.xEditGridCell23.Col = 1;
            this.xEditGridCell23.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell43.CellName = "sunab_date";
            this.xEditGridCell43.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            this.xEditGridCell43.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsReadOnly = true;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            this.xEditGridCell43.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell13.ApplyPaintingEvent = true;
            this.xEditGridCell13.CellName = "sunab_suryang";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell13.CellWidth = 28;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            this.xEditGridCell13.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell44.CellName = "fkout1001";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            this.xEditGridCell44.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsReadOnly = true;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            this.xEditGridCell44.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell24.ApplyPaintingEvent = true;
            this.xEditGridCell24.CellName = "cancer_yn";
            this.xEditGridCell24.CellWidth = 50;
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            this.xEditGridCell24.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell45.CellName = "bunho";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            this.xEditGridCell45.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsReadOnly = true;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            this.xEditGridCell45.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell46.CellName = "remark_chk";
            this.xEditGridCell46.CellWidth = 34;
            this.xEditGridCell46.Col = 11;
            this.xEditGridCell46.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell46.ExecuteQuery = null;
            this.xEditGridCell46.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsReadOnly = true;
            this.xEditGridCell46.IsUpdCol = false;
            this.xEditGridCell46.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell47.CellName = "dc_yn";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsReadOnly = true;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            this.xEditGridCell47.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell48.CellName = "jusa_tong_cnt";
            this.xEditGridCell48.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.ExecuteQuery = null;
            this.xEditGridCell48.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsReadOnly = true;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            this.xEditGridCell48.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell49.CellName = "other_buseo_yn";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            this.xEditGridCell49.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsReadOnly = true;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            this.xEditGridCell49.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell50.CellName = "jujongja";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            this.xEditGridCell50.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsReadOnly = true;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            this.xEditGridCell50.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell22.ApplyPaintingEvent = true;
            this.xEditGridCell22.CellName = "jujongja_name";
            this.xEditGridCell22.CellWidth = 94;
            this.xEditGridCell22.Col = 12;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell51.CellName = "yebang_jujong_chk";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            this.xEditGridCell51.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsReadOnly = true;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            this.xEditGridCell51.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell52.CellName = "actday_chk";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            this.xEditGridCell52.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsReadOnly = true;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            this.xEditGridCell52.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell53.CellName = "gwa";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsReadOnly = true;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            this.xEditGridCell53.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell54.CellName = "bannab_yn";
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.ExecuteQuery = null;
            this.xEditGridCell54.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsReadOnly = true;
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            this.xEditGridCell54.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell55.CellName = "skin_yn";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            this.xEditGridCell55.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsReadOnly = true;
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            this.xEditGridCell55.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell56.CellName = "chunggu_date";
            this.xEditGridCell56.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            this.xEditGridCell56.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsReadOnly = true;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            this.xEditGridCell56.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell57.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell57.ApplyPaintingEvent = true;
            this.xEditGridCell57.CellName = "order_date";
            this.xEditGridCell57.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell57.CellWidth = 75;
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.EnableSort = true;
            this.xEditGridCell57.ExecuteQuery = null;
            this.xEditGridCell57.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsReadOnly = true;
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            this.xEditGridCell57.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell58.CellName = "doctor";
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.ExecuteQuery = null;
            this.xEditGridCell58.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsReadOnly = true;
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            this.xEditGridCell58.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell14.ApplyPaintingEvent = true;
            this.xEditGridCell14.CellName = "ord_danui";
            this.xEditGridCell14.CellWidth = 47;
            this.xEditGridCell14.Col = 8;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell59.CellName = "hope_date_yn";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            this.xEditGridCell59.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsReadOnly = true;
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            this.xEditGridCell59.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell17.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell17.ApplyPaintingEvent = true;
            this.xEditGridCell17.CellName = "bogyong_code";
            this.xEditGridCell17.CellWidth = 70;
            this.xEditGridCell17.Col = 10;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell60.ApplyPaintingEvent = true;
            this.xEditGridCell60.CellName = "suryang";
            this.xEditGridCell60.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell60.CellWidth = 60;
            this.xEditGridCell60.Col = 5;
            this.xEditGridCell60.ExecuteQuery = null;
            this.xEditGridCell60.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
            this.xEditGridCell60.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell16.ApplyPaintingEvent = true;
            this.xEditGridCell16.CellName = "dv";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell16.CellWidth = 47;
            this.xEditGridCell16.Col = 7;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell15.ApplyPaintingEvent = true;
            this.xEditGridCell15.CellName = "dv_time";
            this.xEditGridCell15.CellWidth = 35;
            this.xEditGridCell15.Col = 6;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell61.CellName = "slip_code";
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.ExecuteQuery = null;
            this.xEditGridCell61.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsReadOnly = true;
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            this.xEditGridCell61.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell64.ApplyPaintingEvent = true;
            this.xEditGridCell64.CellName = "jusa_yn";
            this.xEditGridCell64.CellWidth = 22;
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            this.xEditGridCell64.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            this.xEditGridCell64.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell74.ApplyPaintingEvent = true;
            this.xEditGridCell74.CellLen = 25;
            this.xEditGridCell74.CellName = "mix_group";
            this.xEditGridCell74.CellWidth = 27;
            this.xEditGridCell74.Col = -1;
            this.xEditGridCell74.ExecuteQuery = null;
            this.xEditGridCell74.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsReadOnly = true;
            this.xEditGridCell74.IsVisible = false;
            this.xEditGridCell74.Row = -1;
            this.xEditGridCell74.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell74.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell76.CellName = "old_acting_flag";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            this.xEditGridCell76.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsUpdatable = false;
            this.xEditGridCell76.IsUpdCol = false;
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            this.xEditGridCell76.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell66.CellLen = 200;
            this.xEditGridCell66.CellName = "silsi_remark";
            this.xEditGridCell66.CellWidth = 60;
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.ExecuteQuery = null;
            this.xEditGridCell66.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            this.xEditGridCell66.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell67.CellName = "hope_date";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            this.xEditGridCell67.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            this.xEditGridCell67.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell68.CellName = "order_gubun";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            this.xEditGridCell68.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            this.xEditGridCell68.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell86.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell86.CellName = "tonggye_code_name";
            this.xEditGridCell86.CellWidth = 153;
            this.xEditGridCell86.Col = 9;
            this.xEditGridCell86.ExecuteQuery = null;
            this.xEditGridCell86.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsReadOnly = true;
            this.xEditGridCell86.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell86.SuppressRepeating = true;
            // 
            // dtpActingDate
            // 
            this.dtpActingDate.AccessibleDescription = null;
            this.dtpActingDate.AccessibleName = null;
            resources.ApplyResources(this.dtpActingDate, "dtpActingDate");
            this.dtpActingDate.BackgroundImage = null;
            this.dtpActingDate.IsVietnameseYearType = false;
            this.dtpActingDate.Name = "dtpActingDate";
            this.dtpActingDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpActingDate_DataValidating);
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(249))))));
            this.xLabel4.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(249))))));
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // pnlFillInBottom
            // 
            this.pnlFillInBottom.AccessibleDescription = null;
            this.pnlFillInBottom.AccessibleName = null;
            resources.ApplyResources(this.pnlFillInBottom, "pnlFillInBottom");
            this.pnlFillInBottom.BackgroundImage = null;
            this.pnlFillInBottom.Controls.Add(this.xPanel10);
            this.pnlFillInBottom.Controls.Add(this.xPanel1);
            this.pnlFillInBottom.DrawBorder = true;
            this.pnlFillInBottom.Font = null;
            this.pnlFillInBottom.Name = "pnlFillInBottom";
            // 
            // xPanel10
            // 
            this.xPanel10.AccessibleDescription = null;
            this.xPanel10.AccessibleName = null;
            resources.ApplyResources(this.xPanel10, "xPanel10");
            this.xPanel10.BackgroundImage = null;
            this.xPanel10.Controls.Add(this.xPanel4);
            this.xPanel10.Controls.Add(this.pnlDetailFill);
            this.xPanel10.Controls.Add(this.pnlDetailTop);
            this.xPanel10.Font = null;
            this.xPanel10.Name = "xPanel10";
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.btnCmtClear);
            this.xPanel4.Controls.Add(this.dboxCmt);
            this.xPanel4.Controls.Add(this.txtSilsiRemark);
            this.xPanel4.Controls.Add(this.xLabel7);
            this.xPanel4.Controls.Add(this.xLabel2);
            this.xPanel4.Controls.Add(this.fbxCmt);
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // btnCmtClear
            // 
            this.btnCmtClear.AccessibleDescription = null;
            this.btnCmtClear.AccessibleName = null;
            resources.ApplyResources(this.btnCmtClear, "btnCmtClear");
            this.btnCmtClear.BackgroundImage = null;
            this.btnCmtClear.ImageIndex = 14;
            this.btnCmtClear.ImageList = this.ImageList;
            this.btnCmtClear.Name = "btnCmtClear";
            // 
            // dboxCmt
            // 
            this.dboxCmt.AccessibleDescription = null;
            this.dboxCmt.AccessibleName = null;
            resources.ApplyResources(this.dboxCmt, "dboxCmt");
            this.dboxCmt.EdgeRounding = false;
            this.dboxCmt.Image = null;
            this.dboxCmt.Name = "dboxCmt";
            // 
            // txtSilsiRemark
            // 
            this.txtSilsiRemark.AccessibleDescription = null;
            this.txtSilsiRemark.AccessibleName = null;
            resources.ApplyResources(this.txtSilsiRemark, "txtSilsiRemark");
            this.txtSilsiRemark.BackgroundImage = null;
            this.txtSilsiRemark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSilsiRemark.EnterKeyToTab = false;
            this.txtSilsiRemark.Name = "txtSilsiRemark";
            this.txtSilsiRemark.Text = global::IHIS.OCSO.Properties.Resources.String1;
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
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
            // fbxCmt
            // 
            this.fbxCmt.AccessibleDescription = null;
            this.fbxCmt.AccessibleName = null;
            resources.ApplyResources(this.fbxCmt, "fbxCmt");
            this.fbxCmt.BackgroundImage = null;
            this.fbxCmt.FindWorker = this.fwkCmt;
            this.fbxCmt.Name = "fbxCmt";
            // 
            // pnlDetailFill
            // 
            this.pnlDetailFill.AccessibleDescription = null;
            this.pnlDetailFill.AccessibleName = null;
            resources.ApplyResources(this.pnlDetailFill, "pnlDetailFill");
            this.pnlDetailFill.BackgroundImage = null;
            this.pnlDetailFill.Controls.Add(this.grdDetail);
            this.pnlDetailFill.Font = null;
            this.pnlDetailFill.Name = "pnlDetailFill";
            // 
            // pnlDetailTop
            // 
            this.pnlDetailTop.AccessibleDescription = null;
            this.pnlDetailTop.AccessibleName = null;
            resources.ApplyResources(this.pnlDetailTop, "pnlDetailTop");
            this.pnlDetailTop.BackgroundImage = null;
            this.pnlDetailTop.Controls.Add(this.pnlDetailDate);
            this.pnlDetailTop.Controls.Add(this.pnlDetailInfo);
            this.pnlDetailTop.Font = null;
            this.pnlDetailTop.Name = "pnlDetailTop";
            // 
            // pnlDetailDate
            // 
            this.pnlDetailDate.AccessibleDescription = null;
            this.pnlDetailDate.AccessibleName = null;
            resources.ApplyResources(this.pnlDetailDate, "pnlDetailDate");
            this.pnlDetailDate.BackgroundImage = null;
            this.pnlDetailDate.Controls.Add(this.dw1);
            this.pnlDetailDate.Controls.Add(this.xDataWindow1);
            this.pnlDetailDate.Controls.Add(this.grdOCS1003);
            this.pnlDetailDate.Font = null;
            this.pnlDetailDate.Name = "pnlDetailDate";
            // 
            // dw1
            // 
            resources.ApplyResources(this.dw1, "dw1");
            this.dw1.DataWindowObject = "d_jusa_label";
            this.dw1.LibraryList = "INJS\\injs.inj1001u01.pbd";
            this.dw1.Name = "dw1";
            // 
            // xDataWindow1
            // 
            resources.ApplyResources(this.xDataWindow1, "xDataWindow1");
            this.xDataWindow1.DataWindowObject = "d_inj_ho_dong";
            this.xDataWindow1.LibraryList = "INJS\\injs.inj1001u01.pbd";
            this.xDataWindow1.Name = "xDataWindow1";
            // 
            // grdOCS1003
            // 
            resources.ApplyResources(this.grdOCS1003, "grdOCS1003");
            this.grdOCS1003.ApplyPaintEventToAllColumn = true;
            this.grdOCS1003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell73,
            this.xEditGridCell75,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell92});
            this.grdOCS1003.ColPerLine = 5;
            this.grdOCS1003.Cols = 6;
            this.grdOCS1003.ExecuteQuery = null;
            this.grdOCS1003.FixedCols = 1;
            this.grdOCS1003.FixedRows = 1;
            this.grdOCS1003.HeaderHeights.Add(21);
            this.grdOCS1003.Name = "grdOCS1003";
            this.grdOCS1003.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS1003.ParamList")));
            this.grdOCS1003.RowHeaderVisible = true;
            this.grdOCS1003.Rows = 2;
            this.grdOCS1003.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS1003.ToolTipActive = true;
            this.grdOCS1003.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS1003_RowFocusChanged);
            this.grdOCS1003.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS1003_GridCellPainting);
            this.grdOCS1003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS1003_QueryStarting);
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell71.CellName = "reser_date";
            this.xEditGridCell71.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell71.CellWidth = 91;
            this.xEditGridCell71.Col = 2;
            this.xEditGridCell71.ExecuteQuery = null;
            this.xEditGridCell71.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsReadOnly = true;
            this.xEditGridCell71.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell72.CellName = "order_date";
            this.xEditGridCell72.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell72.CellWidth = 96;
            this.xEditGridCell72.Col = 1;
            this.xEditGridCell72.ExecuteQuery = null;
            this.xEditGridCell72.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsReadOnly = true;
            this.xEditGridCell72.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell73.CellName = "acting_date";
            this.xEditGridCell73.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell73.CellWidth = 92;
            this.xEditGridCell73.Col = 3;
            this.xEditGridCell73.ExecuteQuery = null;
            this.xEditGridCell73.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsReadOnly = true;
            this.xEditGridCell73.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell75.CellName = "gwa";
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.ExecuteQuery = null;
            this.xEditGridCell75.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsReadOnly = true;
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            this.xEditGridCell75.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell79.CellName = "gwa_name";
            this.xEditGridCell79.CellWidth = 69;
            this.xEditGridCell79.Col = 4;
            this.xEditGridCell79.ExecuteQuery = null;
            this.xEditGridCell79.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsReadOnly = true;
            this.xEditGridCell79.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell80.CellName = "doctor";
            this.xEditGridCell80.CellWidth = 180;
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.ExecuteQuery = null;
            this.xEditGridCell80.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsReadOnly = true;
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            this.xEditGridCell80.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell81.CellName = "doctor_name";
            this.xEditGridCell81.CellWidth = 111;
            this.xEditGridCell81.Col = 5;
            this.xEditGridCell81.ExecuteQuery = null;
            this.xEditGridCell81.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsReadOnly = true;
            this.xEditGridCell81.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell92.CellName = "if_data_send_yn";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            this.xEditGridCell92.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            this.xEditGridCell92.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // pnlDetailInfo
            // 
            this.pnlDetailInfo.AccessibleDescription = null;
            this.pnlDetailInfo.AccessibleName = null;
            resources.ApplyResources(this.pnlDetailInfo, "pnlDetailInfo");
            this.pnlDetailInfo.BackgroundImage = null;
            this.pnlDetailInfo.Controls.Add(this.dw_jusa_lable);
            this.pnlDetailInfo.Controls.Add(this.dw_jusa);
            this.pnlDetailInfo.Font = null;
            this.pnlDetailInfo.Name = "pnlDetailInfo";
            // 
            // dw_jusa_lable
            // 
            this.dw_jusa_lable.AllowDrop = true;
            resources.ApplyResources(this.dw_jusa_lable, "dw_jusa_lable");
            this.dw_jusa_lable.DataWindowObject = "d_inj_jusa_lable";
            this.dw_jusa_lable.LibraryList = "INJS\\injs.inj1001u01.pbd";
            this.dw_jusa_lable.Name = "dw_jusa_lable";
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(249))))));
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.pbxReserDate);
            this.xPanel1.Controls.Add(this.pbxCPL);
            this.xPanel1.Controls.Add(this.btnCPL);
            this.xPanel1.Controls.Add(this.btnTodayOrder);
            this.xPanel1.Controls.Add(this.btnPostOrder);
            this.xPanel1.Controls.Add(this.btnPreOrder);
            this.xPanel1.Controls.Add(this.dtpActingDate);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // pbxReserDate
            // 
            this.pbxReserDate.AccessibleDescription = null;
            this.pbxReserDate.AccessibleName = null;
            resources.ApplyResources(this.pbxReserDate, "pbxReserDate");
            this.pbxReserDate.BackColor = System.Drawing.Color.LightBlue;
            this.pbxReserDate.BackgroundImage = null;
            this.pbxReserDate.Font = null;
            this.pbxReserDate.ImageLocation = null;
            this.pbxReserDate.Name = "pbxReserDate";
            this.pbxReserDate.TabStop = false;
            // 
            // pbxCPL
            // 
            this.pbxCPL.AccessibleDescription = null;
            this.pbxCPL.AccessibleName = null;
            resources.ApplyResources(this.pbxCPL, "pbxCPL");
            this.pbxCPL.BackColor = System.Drawing.Color.LightBlue;
            this.pbxCPL.BackgroundImage = null;
            this.pbxCPL.Font = null;
            this.pbxCPL.ImageLocation = null;
            this.pbxCPL.Name = "pbxCPL";
            this.pbxCPL.TabStop = false;
            // 
            // btnCPL
            // 
            this.btnCPL.AccessibleDescription = null;
            this.btnCPL.AccessibleName = null;
            resources.ApplyResources(this.btnCPL, "btnCPL");
            this.btnCPL.BackColor = System.Drawing.Color.LightBlue;
            this.btnCPL.BackgroundImage = null;
            this.btnCPL.Font = null;
            this.btnCPL.ImageList = this.ImageList;
            this.btnCPL.Name = "btnCPL";
            this.btnCPL.UseVisualStyleBackColor = false;
            this.btnCPL.Click += new System.EventHandler(this.btnCPL_Click);
            // 
            // btnTodayOrder
            // 
            this.btnTodayOrder.AccessibleDescription = null;
            this.btnTodayOrder.AccessibleName = null;
            resources.ApplyResources(this.btnTodayOrder, "btnTodayOrder");
            this.btnTodayOrder.BackColor = System.Drawing.Color.LightBlue;
            this.btnTodayOrder.BackgroundImage = null;
            this.btnTodayOrder.Font = null;
            this.btnTodayOrder.ImageList = this.ImageList;
            this.btnTodayOrder.Name = "btnTodayOrder";
            this.btnTodayOrder.UseVisualStyleBackColor = false;
            this.btnTodayOrder.Click += new System.EventHandler(this.btnTodayOrder_Click);
            // 
            // btnPostOrder
            // 
            this.btnPostOrder.AccessibleDescription = null;
            this.btnPostOrder.AccessibleName = null;
            resources.ApplyResources(this.btnPostOrder, "btnPostOrder");
            this.btnPostOrder.BackColor = System.Drawing.Color.LightBlue;
            this.btnPostOrder.BackgroundImage = null;
            this.btnPostOrder.Font = null;
            this.btnPostOrder.ImageList = this.ImageList;
            this.btnPostOrder.Name = "btnPostOrder";
            this.btnPostOrder.UseVisualStyleBackColor = false;
            this.btnPostOrder.Click += new System.EventHandler(this.btnPostOrder_Click);
            // 
            // btnPreOrder
            // 
            this.btnPreOrder.AccessibleDescription = null;
            this.btnPreOrder.AccessibleName = null;
            resources.ApplyResources(this.btnPreOrder, "btnPreOrder");
            this.btnPreOrder.BackColor = System.Drawing.Color.LightBlue;
            this.btnPreOrder.BackgroundImage = null;
            this.btnPreOrder.Font = null;
            this.btnPreOrder.ImageList = this.ImageList;
            this.btnPreOrder.Name = "btnPreOrder";
            this.btnPreOrder.UseVisualStyleBackColor = false;
            this.btnPreOrder.Click += new System.EventHandler(this.btnPreOrder_Click);
            // 
            // fwkActor
            // 
            this.fwkActor.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkActor.ExecuteQuery = null;
            this.fwkActor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkActor.ParamList")));
            this.fwkActor.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkActor.ServerFilter = true;
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo3.ColName = "user_id";
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "user_name";
            this.findColumnInfo4.ColWidth = 140;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // layLableNew
            // 
            this.layLableNew.ExecuteQuery = null;
            this.layLableNew.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem48});
            this.layLableNew.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layLableNew.ParamList")));
            this.layLableNew.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layLableNew_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "suname";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "suname2";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "age";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "sex";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "order_date";
            this.multiLayoutItem6.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "cnt";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "order_suryang";
            this.multiLayoutItem8.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "order_danui";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "bogyong_name";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "jusa";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "jaeryo_name";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "order_remark";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "data_gubun";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "mix_yn";
            // 
            // layOrderPrint
            // 
            this.layOrderPrint.ExecuteQuery = null;
            this.layOrderPrint.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem36,
            this.multiLayoutItem37,
            this.multiLayoutItem38,
            this.multiLayoutItem39,
            this.multiLayoutItem40,
            this.multiLayoutItem41,
            this.multiLayoutItem42,
            this.multiLayoutItem43,
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem46,
            this.multiLayoutItem47,
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
            this.multiLayoutItem52,
            this.multiLayoutItem53,
            this.multiLayoutItem54});
            this.layOrderPrint.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderPrint.ParamList")));
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "serial_v";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "bunho";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "suname";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "suname2";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "age";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "sex";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "order_date";
            this.multiLayoutItem40.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "jubsu_date";
            this.multiLayoutItem41.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "dv";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "order_suryang";
            this.multiLayoutItem43.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "order_danui";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "bogyong_name";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "jusa";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "jaeryo_name";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "order_remark";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "data_gubun";
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "birth";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "doctor_name";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "gwa_name";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "order_remark_temp";
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell77.CellName = "jujongja";
            this.xEditGridCell77.Col = 16;
            this.xEditGridCell77.ExecuteQuery = null;
            this.xEditGridCell77.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // layTemp
            // 
            this.layTemp.ExecuteQuery = null;
            this.layTemp.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem55,
            this.multiLayoutItem56,
            this.multiLayoutItem57,
            this.multiLayoutItem58,
            this.multiLayoutItem59,
            this.multiLayoutItem60,
            this.multiLayoutItem61,
            this.multiLayoutItem62,
            this.multiLayoutItem63,
            this.multiLayoutItem64,
            this.multiLayoutItem65,
            this.multiLayoutItem66,
            this.multiLayoutItem67,
            this.multiLayoutItem68,
            this.multiLayoutItem69,
            this.multiLayoutItem70,
            this.multiLayoutItem71,
            this.multiLayoutItem72,
            this.multiLayoutItem73});
            this.layTemp.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layTemp.ParamList")));
            this.layTemp.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layTemp_QueryEnd);
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "serial_v";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "bunho";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "suname";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "suname2";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "age";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "sex";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "order_date";
            this.multiLayoutItem61.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "jubsu_date";
            this.multiLayoutItem62.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "dv";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "order_suryang";
            this.multiLayoutItem64.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "order_danui";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "bogyong_name";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "jusa";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "jaeryo_name";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "order_remark";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "data_gubun";
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "birth";
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "doctor_name";
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "gwa_name";
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMixGroup.Images.SetKeyName(0, "20.gif");
            this.imageListMixGroup.Images.SetKeyName(1, "1.gif");
            this.imageListMixGroup.Images.SetKeyName(2, "2.gif");
            this.imageListMixGroup.Images.SetKeyName(3, "3.gif");
            this.imageListMixGroup.Images.SetKeyName(4, "4.gif");
            this.imageListMixGroup.Images.SetKeyName(5, "5.gif");
            this.imageListMixGroup.Images.SetKeyName(6, "6.gif");
            this.imageListMixGroup.Images.SetKeyName(7, "7.gif");
            this.imageListMixGroup.Images.SetKeyName(8, "8.gif");
            this.imageListMixGroup.Images.SetKeyName(9, "9.gif");
            this.imageListMixGroup.Images.SetKeyName(10, "10.gif");
            this.imageListMixGroup.Images.SetKeyName(11, "11.gif");
            this.imageListMixGroup.Images.SetKeyName(12, "12.gif");
            this.imageListMixGroup.Images.SetKeyName(13, "13.gif");
            this.imageListMixGroup.Images.SetKeyName(14, "14.gif");
            this.imageListMixGroup.Images.SetKeyName(15, "15.gif");
            this.imageListMixGroup.Images.SetKeyName(16, "16.gif");
            this.imageListMixGroup.Images.SetKeyName(17, "17.gif");
            this.imageListMixGroup.Images.SetKeyName(18, "18.gif");
            this.imageListMixGroup.Images.SetKeyName(19, "19.gif");
            // 
            // layReserDate
            // 
            this.layReserDate.ExecuteQuery = null;
            this.layReserDate.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem15});
            this.layReserDate.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserDate.ParamList")));
            this.layReserDate.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layReserDate_QueryStarting);
            this.layReserDate.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layReserDate_QueryEnd);
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "reser_date";
            this.multiLayoutItem15.DataType = IHIS.Framework.DataType.Date;
            // 
            // layCPLOrderYN
            // 
            this.layCPLOrderYN.ExecuteQuery = null;
            this.layCPLOrderYN.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layCPLOrderYN.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCPLOrderYN.ParamList")));
            this.layCPLOrderYN.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layCPLOrderYN_QueryStarting);
            this.layCPLOrderYN.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layCPLOrderYN_QueryEnd);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "cpl_order_yn";
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell70.CellName = "doctor";
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.ExecuteQuery = null;
            this.xEditGridCell70.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            this.xEditGridCell70.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 1;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            // 
            // layPrintName
            // 
            this.layPrintName.ExecuteQuery = null;
            this.layPrintName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layPrintName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPrintName.ParamList")));
            this.layPrintName.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPrintName_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "print_name";
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            // 
            // mlayConstantInfo
            // 
            this.mlayConstantInfo.ExecuteQuery = null;
            this.mlayConstantInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem16,
            this.multiLayoutItem17});
            this.mlayConstantInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("mlayConstantInfo.ParamList")));
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "code";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "code_name";
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell90.CellName = "trial_patient";
            this.xEditGridCell90.Col = 1;
            this.xEditGridCell90.ExecuteQuery = null;
            this.xEditGridCell90.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsReadOnly = true;
            this.xEditGridCell90.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell90.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCINJ1001U01
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackGroundColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(249))))));
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFillInBottom);
            this.Name = "UCINJ1001U01";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.INJ1001U01_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.pnlFillInBottom.ResumeLayout(false);
            this.xPanel10.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            this.xPanel4.PerformLayout();
            this.pnlDetailFill.ResumeLayout(false);
            this.pnlDetailTop.ResumeLayout(false);
            this.pnlDetailDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).EndInit();
            this.pnlDetailInfo.ResumeLayout(false);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxReserDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCPL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layLableNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region 자동생성

        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
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
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XMstGrid grdDetail;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XEditGridCell xEditGridCell35;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XEditGridCell xEditGridCell39;
        private IHIS.Framework.XEditGridCell xEditGridCell40;
        private IHIS.Framework.XEditGridCell xEditGridCell41;
        private IHIS.Framework.XEditGridCell xEditGridCell42;
        private IHIS.Framework.XEditGridCell xEditGridCell43;
        private IHIS.Framework.XEditGridCell xEditGridCell44;
        private IHIS.Framework.XEditGridCell xEditGridCell45;
        private IHIS.Framework.XEditGridCell xEditGridCell46;
        private IHIS.Framework.XEditGridCell xEditGridCell47;
        private IHIS.Framework.XEditGridCell xEditGridCell48;
        private IHIS.Framework.XEditGridCell xEditGridCell49;
        private IHIS.Framework.XEditGridCell xEditGridCell50;
        private IHIS.Framework.XEditGridCell xEditGridCell51;
        private IHIS.Framework.XEditGridCell xEditGridCell52;
        private IHIS.Framework.XEditGridCell xEditGridCell53;
        private IHIS.Framework.XEditGridCell xEditGridCell54;
        private IHIS.Framework.XEditGridCell xEditGridCell55;
        private IHIS.Framework.XEditGridCell xEditGridCell56;
        private IHIS.Framework.XEditGridCell xEditGridCell57;
        private IHIS.Framework.XEditGridCell xEditGridCell58;
        private IHIS.Framework.XEditGridCell xEditGridCell59;
        private IHIS.Framework.XEditGridCell xEditGridCell60;
        private IHIS.Framework.XEditGridCell xEditGridCell61;
        private IHIS.Framework.XGridCell xGridCell1;
        private IHIS.Framework.XGridCell xGridCell2;
        private IHIS.Framework.XPanel pnlFillInBottom;
        private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell64;
        private IHIS.Framework.XEditGridCell xEditGridCell74;
        private IHIS.Framework.XDatePicker dtpActingDate;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XPanel xPanel1;
        private System.Windows.Forms.Button btnTodayOrder;
        private System.Windows.Forms.Button btnPostOrder;
        private System.Windows.Forms.Button btnPreOrder;
        private IHIS.Framework.XDataWindow dw_jusa_lable;
        private IHIS.Framework.MultiLayout layLableNew;
        private IHIS.Framework.MultiLayout layOrderPrint;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private MultiLayout layTemp;
        private XDataWindow dw_jusa;
        private XEditGridCell xEditGridCell66;
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
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem48;
        private ImageList imageListMixGroup;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell68;
        private MultiLayout layReserDate;
        private MultiLayoutItem multiLayoutItem15;
        private PictureBox pbxReserDate;
        private PictureBox pbxCPL;
        private Button btnCPL;
        private SingleLayout layCPLOrderYN;
        private SingleLayoutItem singleLayoutItem1;
        private XGridHeader xGridHeader2;
        private XEditGridCell xEditGridCell70;
        private XPanel xPanel10;
        private XPanel pnlDetailFill;
        private XPanel pnlDetailTop;
        private XPanel pnlDetailInfo;
        private XPanel pnlDetailDate;
        private XEditGrid grdOCS1003;
        private XEditGridCell xEditGridCell71;
        private XEditGridCell xEditGridCell72;
        private XEditGridCell xEditGridCell73;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell81;
        private XGridHeader xGridHeader1;
        private XEditGridCell xEditGridCell86;
        private PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private SingleLayout layPrintName;
        private SingleLayoutItem singleLayoutItem2;
        private XFindWorker fwkActor;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private SingleLayout layCommon;
        private MultiLayout mlayConstantInfo;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem36;
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem38;
        private MultiLayoutItem multiLayoutItem39;
        private MultiLayoutItem multiLayoutItem40;
        private MultiLayoutItem multiLayoutItem41;
        private MultiLayoutItem multiLayoutItem42;
        private MultiLayoutItem multiLayoutItem43;
        private MultiLayoutItem multiLayoutItem44;
        private MultiLayoutItem multiLayoutItem45;
        private MultiLayoutItem multiLayoutItem46;
        private MultiLayoutItem multiLayoutItem47;
        private MultiLayoutItem multiLayoutItem49;
        private MultiLayoutItem multiLayoutItem50;
        private MultiLayoutItem multiLayoutItem51;
        private MultiLayoutItem multiLayoutItem52;
        private MultiLayoutItem multiLayoutItem53;
        private MultiLayoutItem multiLayoutItem54;
        private MultiLayoutItem multiLayoutItem55;
        private MultiLayoutItem multiLayoutItem56;
        private MultiLayoutItem multiLayoutItem57;
        private MultiLayoutItem multiLayoutItem58;
        private MultiLayoutItem multiLayoutItem59;
        private MultiLayoutItem multiLayoutItem60;
        private MultiLayoutItem multiLayoutItem61;
        private MultiLayoutItem multiLayoutItem62;
        private MultiLayoutItem multiLayoutItem63;
        private MultiLayoutItem multiLayoutItem64;
        private MultiLayoutItem multiLayoutItem65;
        private MultiLayoutItem multiLayoutItem66;
        private MultiLayoutItem multiLayoutItem67;
        private MultiLayoutItem multiLayoutItem68;
        private MultiLayoutItem multiLayoutItem69;
        private MultiLayoutItem multiLayoutItem70;
        private MultiLayoutItem multiLayoutItem71;
        private MultiLayoutItem multiLayoutItem72;
        private MultiLayoutItem multiLayoutItem73;
        private XFindWorker fwkCmt;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell92;
        private System.ComponentModel.IContainer components = null;

        #endregion
        private XDataWindow dw1;
        private XDataWindow xDataWindow1;
        private XPanel xPanel4;
        private XButton btnCmtClear;
        private XDisplayBox dboxCmt;
        private XRichTextBox txtSilsiRemark;
        private XLabel xLabel7;
        private XLabel xLabel2;
        private XFindBox fbxCmt;
    }
}
