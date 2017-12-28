using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;
using System.Data;

namespace IHIS.DRGS
{
    /// <summary>
    /// FINDPA에 대한 요약 설명입니다.
    /// </summary>
    public class CommentForm : IHIS.Framework.XForm
    {
        private string bunho;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XMstGrid grdOrder;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XEditGridCell xEditGridCell69;
        private IHIS.Framework.XEditGridCell xEditGridCell70;
        private IHIS.Framework.XEditGridCell xEditGridCell74;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGrid grdOrderList;
        private IHIS.Framework.XEditGridCell xEditGridCell83;
        private IHIS.Framework.XEditGridCell xEditGridCell84;
        private IHIS.Framework.XEditGridCell xEditGridCell85;
        private IHIS.Framework.XEditGridCell xEditGridCell86;
        private IHIS.Framework.XEditGridCell xEditGridCell87;
        private IHIS.Framework.XEditGridCell xEditGridCell88;
        private IHIS.Framework.XEditGridCell xEditGridCell61;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell89;
        private IHIS.Framework.XEditGridCell xEditGridCell62;
        private IHIS.Framework.XEditGridCell xEditGridCell90;
        private IHIS.Framework.XEditGridCell xEditGridCell63;
        private IHIS.Framework.XEditGridCell xEditGridCell91;
        private IHIS.Framework.XEditGridCell xEditGridCell92;
        private IHIS.Framework.XEditGridCell xEditGridCell93;
        private IHIS.Framework.XEditGridCell xEditGridCell60;
        private IHIS.Framework.XEditGridCell xEditGridCell94;
        private IHIS.Framework.XEditGridCell xEditGridCell95;
        private IHIS.Framework.XEditGridCell xEditGridCell96;
        private IHIS.Framework.XEditGridCell xEditGridCell97;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell64;
        private IHIS.Framework.XEditGridCell xEditGridCell99;
        private IHIS.Framework.XEditGridCell xEditGridCell100;
        private IHIS.Framework.XEditGridCell xEditGridCell101;
        private IHIS.Framework.XEditGridCell xEditGridCell102;
        private IHIS.Framework.XEditGridCell xEditGridCell103;
        private IHIS.Framework.XEditGridCell xEditGridCell104;
        private IHIS.Framework.XEditGridCell xEditGridCell105;
        private IHIS.Framework.XEditGridCell xEditGridCell39;
        private IHIS.Framework.XEditGridCell xEditGridCell65;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell40;
        private IHIS.Framework.XEditGridCell xEditGridCell41;
        private IHIS.Framework.XEditGridCell xEditGridCell67;
        private IHIS.Framework.XEditGridCell xEditGridCell68;
        private IHIS.Framework.XEditGridCell xEditGridCell59;
        private IHIS.Framework.XEditGridCell xEditGridCell66;
        private IHIS.Framework.XEditGridCell xEditGridCell71;
        private IHIS.Framework.XEditGridCell xEditGridCell73;
        private IHIS.Framework.XEditGridCell xEditGridCell72;
        private IHIS.Framework.XEditGridCell xEditGridCell75;
        private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private IHIS.Framework.XButton btnExit;
        private IHIS.Framework.XButton btnSave;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public CommentForm(string Bunho)
        {
            InitializeComponent();

            bunho = Bunho;
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

        #region Windows Form 디자이너에서 생성한 코드
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommentForm));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnSave = new IHIS.Framework.XButton();
            this.btnExit = new IHIS.Framework.XButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdOrderList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.grdOrder = new IHIS.Framework.XMstGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnSave);
            this.xPanel1.Controls.Add(this.btnExit);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdOrderList);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // grdOrderList
            // 
            this.grdOrderList.CallerID = '2';
            this.grdOrderList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell61,
            this.xEditGridCell17,
            this.xEditGridCell89,
            this.xEditGridCell62,
            this.xEditGridCell90,
            this.xEditGridCell63,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell60,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell38,
            this.xEditGridCell37,
            this.xEditGridCell64,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell102,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell105,
            this.xEditGridCell39,
            this.xEditGridCell65,
            this.xEditGridCell12,
            this.xEditGridCell14,
            this.xEditGridCell36,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell59,
            this.xEditGridCell66,
            this.xEditGridCell71,
            this.xEditGridCell73,
            this.xEditGridCell72,
            this.xEditGridCell2,
            this.xEditGridCell77,
            this.xEditGridCell75,
            this.xEditGridCell76});
            this.grdOrderList.ColPerLine = 13;
            this.grdOrderList.Cols = 14;
            this.grdOrderList.ControlBinding = true;
            resources.ApplyResources(this.grdOrderList, "grdOrderList");
            this.grdOrderList.FixedCols = 1;
            this.grdOrderList.FixedRows = 1;
            this.grdOrderList.HeaderHeights.Add(32);
            this.grdOrderList.MasterLayout = this.grdOrder;
            this.grdOrderList.Name = "grdOrderList";
            this.grdOrderList.QuerySQL = resources.GetString("grdOrderList.QuerySQL");
            this.grdOrderList.RowHeaderVisible = true;
            this.grdOrderList.Rows = 2;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "bunho";
            this.xEditGridCell83.CellWidth = 25;
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.IsReadOnly = true;
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "drg_bunho";
            this.xEditGridCell84.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.IsReadOnly = true;
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "naewon_date";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.IsReadOnly = true;
            this.xEditGridCell85.IsUpdCol = false;
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "group_ser";
            this.xEditGridCell86.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell86.CellWidth = 22;
            this.xEditGridCell86.Col = -1;
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsReadOnly = true;
            this.xEditGridCell86.IsUpdCol = false;
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "jubsu_date";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.IsReadOnly = true;
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "order_date";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.IsReadOnly = true;
            this.xEditGridCell88.IsUpdCol = false;
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.ApplyPaintingEvent = true;
            this.xEditGridCell61.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell61.CellName = "jaeryo_code";
            this.xEditGridCell61.CellWidth = 74;
            this.xEditGridCell61.Col = 2;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsReadOnly = true;
            this.xEditGridCell61.IsUpdCol = false;
            this.xEditGridCell61.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.ApplyPaintingEvent = true;
            this.xEditGridCell17.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell17.CellName = "nalsu";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell17.CellWidth = 50;
            this.xEditGridCell17.Col = 7;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "divide";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.IsReadOnly = true;
            this.xEditGridCell89.IsUpdCol = false;
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.ApplyPaintingEvent = true;
            this.xEditGridCell62.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell62.CellName = "ord_suryang";
            this.xEditGridCell62.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell62.CellWidth = 63;
            this.xEditGridCell62.Col = 4;
            this.xEditGridCell62.DecimalDigits = 3;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsReadOnly = true;
            this.xEditGridCell62.IsUpdCol = false;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "order_suryang";
            this.xEditGridCell90.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.IsReadOnly = true;
            this.xEditGridCell90.IsUpdCol = false;
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.ApplyPaintingEvent = true;
            this.xEditGridCell63.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell63.CellName = "order_danui";
            this.xEditGridCell63.CellWidth = 83;
            this.xEditGridCell63.Col = 8;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsReadOnly = true;
            this.xEditGridCell63.IsUpdCol = false;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "subul_danui";
            this.xEditGridCell91.Col = -1;
            this.xEditGridCell91.IsReadOnly = true;
            this.xEditGridCell91.IsUpdCol = false;
            this.xEditGridCell91.IsVisible = false;
            this.xEditGridCell91.Row = -1;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "group_yn";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.IsReadOnly = true;
            this.xEditGridCell92.IsUpdCol = false;
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "jaeryo_gubun";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.IsReadOnly = true;
            this.xEditGridCell93.IsUpdCol = false;
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.ApplyPaintingEvent = true;
            this.xEditGridCell60.CellName = "bogyong_code";
            this.xEditGridCell60.CellWidth = 65;
            this.xEditGridCell60.Col = -1;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
            this.xEditGridCell60.IsUpdCol = false;
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "bogyong_name";
            this.xEditGridCell94.CellWidth = 95;
            this.xEditGridCell94.Col = 10;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsReadOnly = true;
            this.xEditGridCell94.IsUpdCol = false;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "caution_name";
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.IsReadOnly = true;
            this.xEditGridCell95.IsUpdCol = false;
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "caution_code";
            this.xEditGridCell96.Col = -1;
            this.xEditGridCell96.IsReadOnly = true;
            this.xEditGridCell96.IsUpdCol = false;
            this.xEditGridCell96.IsVisible = false;
            this.xEditGridCell96.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "mix_yn";
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.IsReadOnly = true;
            this.xEditGridCell97.IsUpdCol = false;
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.ApplyPaintingEvent = true;
            this.xEditGridCell38.CellLen = 35;
            this.xEditGridCell38.CellName = "atc_yn";
            this.xEditGridCell38.CellWidth = 28;
            this.xEditGridCell38.Col = -1;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsUpdCol = false;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.ApplyPaintingEvent = true;
            this.xEditGridCell37.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell37.CellName = "dv";
            this.xEditGridCell37.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell37.CellWidth = 51;
            this.xEditGridCell37.Col = 6;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.IsUpdCol = false;
            this.xEditGridCell37.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.ApplyPaintingEvent = true;
            this.xEditGridCell64.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell64.CellName = "dv_time";
            this.xEditGridCell64.CellWidth = 33;
            this.xEditGridCell64.Col = 5;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsReadOnly = true;
            this.xEditGridCell64.IsUpdCol = false;
            this.xEditGridCell64.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "dc_yn";
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.IsReadOnly = true;
            this.xEditGridCell99.IsUpdCol = false;
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "bannab_yn";
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.IsReadOnly = true;
            this.xEditGridCell100.IsUpdCol = false;
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "source_fkocs1003";
            this.xEditGridCell101.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell101.Col = -1;
            this.xEditGridCell101.IsReadOnly = true;
            this.xEditGridCell101.IsUpdCol = false;
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "fkocs1003";
            this.xEditGridCell102.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell102.Col = -1;
            this.xEditGridCell102.IsReadOnly = true;
            this.xEditGridCell102.IsVisible = false;
            this.xEditGridCell102.Row = -1;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "fkout1001";
            this.xEditGridCell103.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell103.Col = -1;
            this.xEditGridCell103.IsReadOnly = true;
            this.xEditGridCell103.IsUpdCol = false;
            this.xEditGridCell103.IsVisible = false;
            this.xEditGridCell103.Row = -1;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "sunab_date";
            this.xEditGridCell104.Col = -1;
            this.xEditGridCell104.IsReadOnly = true;
            this.xEditGridCell104.IsUpdCol = false;
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "pattern";
            this.xEditGridCell105.Col = -1;
            this.xEditGridCell105.IsReadOnly = true;
            this.xEditGridCell105.IsUpdCol = false;
            this.xEditGridCell105.IsVisible = false;
            this.xEditGridCell105.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.ApplyPaintingEvent = true;
            this.xEditGridCell39.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell39.CellName = "jaeryo_name";
            this.xEditGridCell39.CellWidth = 229;
            this.xEditGridCell39.Col = 3;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsUpdCol = false;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellLen = 35;
            this.xEditGridCell65.CellName = "sunab_nalsu";
            this.xEditGridCell65.CellWidth = 35;
            this.xEditGridCell65.Col = -1;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsReadOnly = true;
            this.xEditGridCell65.IsUpdCol = false;
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "wonyoi_yn";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 4000;
            this.xEditGridCell14.CellName = "order_remark";
            this.xEditGridCell14.CellWidth = 95;
            this.xEditGridCell14.Col = 11;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdCol = false;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "act_date";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsUpdCol = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "mayak";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsUpdCol = false;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "tpn_joje_gubun";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsUpdCol = false;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "ui_jusa_yn";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.IsReadOnly = true;
            this.xEditGridCell67.IsUpdCol = false;
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "subul_suryang";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.IsReadOnly = true;
            this.xEditGridCell68.IsUpdCol = false;
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.ApplyPaintingEvent = true;
            this.xEditGridCell59.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell59.CellName = "serial_v";
            this.xEditGridCell59.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell59.CellWidth = 25;
            this.xEditGridCell59.Col = 1;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.SuppressRepeating = true;
            this.xEditGridCell59.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.ApplyPaintingEvent = true;
            this.xEditGridCell66.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell66.CellName = "powder_yn";
            this.xEditGridCell66.CellWidth = 56;
            this.xEditGridCell66.Col = 9;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsReadOnly = true;
            this.xEditGridCell66.IsUpdCol = false;
            this.xEditGridCell66.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell71.CellName = "gyunbon_yn";
            this.xEditGridCell71.CellWidth = 25;
            this.xEditGridCell71.Col = -1;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsUpdCol = false;
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            this.xEditGridCell71.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "print_yn";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.IsUpdatable = false;
            this.xEditGridCell73.IsUpdCol = false;
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "old_gyunbon_yn";
            this.xEditGridCell72.Col = -1;
            this.xEditGridCell72.IsUpdatable = false;
            this.xEditGridCell72.IsUpdCol = false;
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 1000;
            this.xEditGridCell2.CellName = "rp_comment";
            this.xEditGridCell2.CellWidth = 63;
            this.xEditGridCell2.Col = 12;
            this.xEditGridCell2.DisplayMemoText = true;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellLen = 1000;
            this.xEditGridCell77.CellName = "jaeryo_comments";
            this.xEditGridCell77.CellWidth = 180;
            this.xEditGridCell77.Col = 13;
            this.xEditGridCell77.DisplayMemoText = true;
            this.xEditGridCell77.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "bohum";
            this.xEditGridCell75.CellWidth = 30;
            this.xEditGridCell75.Col = -1;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "huntak";
            this.xEditGridCell76.CellWidth = 30;
            this.xEditGridCell76.Col = -1;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsUpdCol = false;
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // grdOrder
            // 
            this.grdOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell6,
            this.xEditGridCell32,
            this.xEditGridCell5,
            this.xEditGridCell33,
            this.xEditGridCell4,
            this.xEditGridCell8,
            this.xEditGridCell21,
            this.xEditGridCell7,
            this.xEditGridCell34,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell1,
            this.xEditGridCell74,
            this.xEditGridCell9});
            this.grdOrder.ColPerLine = 10;
            this.grdOrder.ColResizable = true;
            this.grdOrder.Cols = 11;
            resources.ApplyResources(this.grdOrder, "grdOrder");
            this.grdOrder.FixedCols = 1;
            this.grdOrder.FixedRows = 1;
            this.grdOrder.HeaderHeights.Add(21);
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.QuerySQL = resources.GetString("grdOrder.QuerySQL");
            this.grdOrder.RowHeaderVisible = true;
            this.grdOrder.Rows = 2;
            this.grdOrder.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOrder_RowFocusChanged);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.ApplyPaintingEvent = true;
            this.xEditGridCell3.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell3.CellName = "drg_bunho";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell3.CellWidth = 87;
            this.xEditGridCell3.Col = 2;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "bunho";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "order_date";
            this.xEditGridCell30.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell30.CellWidth = 83;
            this.xEditGridCell30.Col = 1;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsUpdCol = false;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "jubsu_date";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell31.CellWidth = 92;
            this.xEditGridCell31.Col = 6;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.ApplyPaintingEvent = true;
            this.xEditGridCell6.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell6.CellName = "jubsu_time";
            this.xEditGridCell6.CellWidth = 45;
            this.xEditGridCell6.Col = -1;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Mask = "##:##";
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "doctor";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.IsUpdCol = false;
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.ApplyPaintingEvent = true;
            this.xEditGridCell5.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell5.CellLen = 30;
            this.xEditGridCell5.CellName = "doctor_name";
            this.xEditGridCell5.CellWidth = 85;
            this.xEditGridCell5.Col = 4;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "gwa";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsUpdatable = false;
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.ApplyPaintingEvent = true;
            this.xEditGridCell4.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell4.CellLen = 30;
            this.xEditGridCell4.CellName = "buseo_name";
            this.xEditGridCell4.CellWidth = 100;
            this.xEditGridCell4.Col = 3;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.ApplyPaintingEvent = true;
            this.xEditGridCell8.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell8.CellName = "act_date";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.CellWidth = 107;
            this.xEditGridCell8.Col = 7;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsUpdCol = false;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.ApplyPaintingEvent = true;
            this.xEditGridCell21.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell21.CellName = "act_yn";
            this.xEditGridCell21.CellWidth = 36;
            this.xEditGridCell21.Col = -1;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsUpdCol = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.ApplyPaintingEvent = true;
            this.xEditGridCell7.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell7.CellName = "sunab_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.CellWidth = 83;
            this.xEditGridCell7.Col = 5;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "chulgo_date";
            this.xEditGridCell34.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.IsUpdatable = false;
            this.xEditGridCell34.IsUpdCol = false;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell69.ApplyPaintingEvent = true;
            this.xEditGridCell69.CellName = "boryu_yn";
            this.xEditGridCell69.CellWidth = 36;
            this.xEditGridCell69.Col = -1;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsReadOnly = true;
            this.xEditGridCell69.IsUpdCol = false;
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            this.xEditGridCell69.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "chulgo_buseo";
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.IsUpdCol = false;
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.ApplyPaintingEvent = true;
            this.xEditGridCell1.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell1.CellName = "wonyoi_yn";
            this.xEditGridCell1.CellWidth = 55;
            this.xEditGridCell1.Col = 8;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdCol = false;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellLen = 1000;
            this.xEditGridCell74.CellName = "comments";
            this.xEditGridCell74.CellWidth = 160;
            this.xEditGridCell74.Col = 9;
            this.xEditGridCell74.DisplayMemoText = true;
            this.xEditGridCell74.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "print_yn";
            this.xEditGridCell9.CellWidth = 35;
            this.xEditGridCell9.Col = 10;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdOrder);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // CommentForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Name = "CommentForm";
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.xPanel3, 0);
            this.Controls.SetChildIndex(this.xPanel2, 0);
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region common property
        private string mHospCode = EnvironInfo.HospCode;
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            grdOrder.SetBindVarValue("f_bunho", bunho);
            grdOrder.SetBindVarValue("f_hosp_code", mHospCode);
            if (!grdOrder.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
        }
        #endregion

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                Service.BeginTransaction();
                if (grdOrder.SaveLayout())
                {
                    if (!grdOrderList.SaveLayout())
                    {
                        throw new Exception(Service.ErrFullMsg);
                    }
                }
                else
                {
                    throw new Exception(Service.ErrFullMsg);
                }
            }
            catch (Exception xe)
            {
                Service.RollbackTransaction();
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                return;
            }
            Service.CommitTransaction();
        }


        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void grdOrder_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            grdOrderList.SetBindVarValue("f_jubsu_date", grdOrder.GetItemString(e.CurrentRow, "jubsu_date"));
            grdOrderList.SetBindVarValue("f_drg_bunho", grdOrder.GetItemString(e.CurrentRow, "drg_bunho"));
            grdOrderList.SetBindVarValue("f_wonyol_order_yn", grdOrder.GetItemString(e.CurrentRow, "wonyoi_yn"));
            grdOrderList.SetBindVarValue("f_bunho", grdOrder.GetItemString(e.CurrentRow, "bunho"));
            grdOrderList.SetBindVarValue("f_hosp_code", mHospCode);

            if (!grdOrderList.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
        }

        #region [ XSavePerformer ]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private CommentForm parent = null;
            public XSavePerformer(CommentForm parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE DRG9041
                                               SET UPD_ID      = :q_user_id
                                                 , UPD_DATE     = SYSDATE
                                                 , INPUT_DATE   = TRUNC(SYSDATE)
                                                 , INPUT_USER   = :q_user_id
                                                 , ORDER_REMARK = :f_drg9040_o_remark
                                                 , DRG_REMARK   = :f_drg9040_d_remark
                                             WHERE BUNHO        = :f_bunho
                                               AND HOSP_CODE    = :f_hosp_code";
                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    cmdText = "";
                                    cmdText = @"INSERT INTO DRG9041( SYS_DATE
                                                                    ,SYS_ID
                                                                    ,BUNHO
                                                                    ,INPUT_DATE
                                                                    ,INPUT_USER
                                                                    ,ORDER_REMARK
                                                                    ,DRG_REMARK
                                                                    ,HOSP_CODE
                                                                    )
                                                             VALUES( SYSDATE
                                                                    ,:q_user_id
                                                                    ,:f_bunho
                                                                    ,TRUNC(SYSDATE)
                                                                    ,:q_user_id
                                                                    ,:f_drg9040_o_remark
                                                                    ,:f_drg9040_d_remark
                                                                    ,:f_hosp_code
                                                                    )";
                                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                    {
                                        XMessageBox.Show(Service.ErrFullMsg);
                                        return false;
                                    }
                                }

                                cmdText = @"UPDATE DRG9040
                                               SET UPD_ID       = :q_user_id
                                                 , UPD_DATE     = SYSDATE
                                                 , INPUT_DATE   = TRUNC(SYSDATE)
                                                 , INPUT_USER   = :q_user_id
                                                 , ORDER_REMARK = :f_order_remark
                                                 , DRG_REMARK   = :f_drg_remark
                                             WHERE IN_OUT_GUBUN = 'O'
                                               AND JUBSU_DATE   = :f_jubsu_date
                                               AND DRG_BUNHO    = :f_drg_bunho
                                               AND HOSP_CODE    = :f_hosp_code";
                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    cmdText = @"INSERT INTO DRG9040( SYS_DATE
                                                                    ,SYS_ID
                                                                    ,IN_OUT_GUBUN
                                                                    ,JUBSU_DATE
                                                                    ,DRG_BUNHO
                                                                    ,BUNHO
                                                                    ,INPUT_DATE
                                                                    ,INPUT_USER
                                                                    ,ORDER_REMARK
                                                                    ,DRG_REMARK
                                                                    ,HOSP_CODE
                                                                    )
                                                             VALUES( SYSDATE
                                                                    ,:q_user_id
                                                                    ,'O'
                                                                    ,:f_jubsu_date
                                                                    ,:f_drg_bunho
                                                                    ,:f_bunho
                                                                    ,TRUNC(SYSDATE)
                                                                    ,:q_user_id
                                                                    ,:f_order_remark
                                                                    ,:f_drg_remark
                                                                    ,:f_hosp_code
                                                                    )";
                                }
                                break;
                            case DataRowState.Deleted:
                                cmdText = @"";
                                break;
                        }
                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE DRG9042
                                               SET UPD_ID       = :q_user_id
                                                 , UPD_DATE      = SYSDATE
                                                 , ORDER_REMARK = :f_order_remark
                                                 , DRG_REMARK   = :f_drg_remark
                                             WHERE IN_OUT_GUBUN = 'O'
                                               AND FKOCS        = :f_fkocs
                                               AND HOSP_CODE    = :f_hosp_code";
                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    cmdText = @"INSERT INTO DRG9042( SYS_DATE
                                                                    ,SYS_ID
                                                                    ,IN_OUT_GUBUN
                                                                    ,FKOCS
                                                                    ,BUNHO
                                                                    ,INPUT_DATE
                                                                    ,INPUT_USER
                                                                    ,ORDER_REMARK
                                                                    ,DRG_REMARK
                                                                    ,HOSP_CODE
                                                                    )
                                                             VALUES( SYSDATE
                                                                    ,:q_user_id
                                                                    ,'O'
                                                                    ,:f_fkocs
                                                                    ,:f_bunho
                                                                    ,TRUNC(SYSDATE)
                                                                    ,:q_user_id
                                                                    ,:f_order_remark
                                                                    ,:f_drg_remark
                                                                    ,:f_hosp_code
                                                                   )";
                                }
                                break;
                            case DataRowState.Deleted:
                                cmdText = @"";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion
    }
}
