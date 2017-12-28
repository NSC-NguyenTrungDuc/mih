#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.DRGS
{
    /// <summary>
    /// DRG2010Q02에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class DRG2010Q02 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XDatePicker dptFrDt;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XDatePicker dptToDt;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGrid grdPHY1002;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
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
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XDisplayBox dbxJaeryo;
        private IHIS.Framework.XFindBox fbxJaeryo;
        private IHIS.Framework.XLabel xLabel40;
        private IHIS.Framework.XFindWorker fwkCommon;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XDWWorker xdwWorker1;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private XBuseoCombo cbxBuseo;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public DRG2010Q02()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG2010Q02));
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.cbxBuseo = new IHIS.Framework.XBuseoCombo();
            this.dbxJaeryo = new IHIS.Framework.XDisplayBox();
            this.fbxJaeryo = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xLabel40 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.dptToDt = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dptFrDt = new IHIS.Framework.XDatePicker();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdPHY1002 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xdwWorker1 = new IHIS.Framework.XDWWorker();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxBuseo)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPHY1002)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.xButtonList1);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Location = new System.Drawing.Point(5, 579);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1028, 36);
            this.pnlBottom.TabIndex = 2;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisiblePreview = false;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(782, 0);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.xButtonList1.Size = new System.Drawing.Size(244, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.cbxBuseo);
            this.xPanel1.Controls.Add(this.dbxJaeryo);
            this.xPanel1.Controls.Add(this.fbxJaeryo);
            this.xPanel1.Controls.Add(this.xLabel40);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Controls.Add(this.dptToDt);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.dptFrDt);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 5);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1028, 36);
            this.xPanel1.TabIndex = 3;
            // 
            // xLabel2
            // 
            this.xLabel2.Location = new System.Drawing.Point(306, 8);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(75, 20);
            this.xLabel2.TabIndex = 30;
            this.xLabel2.Text = "診療科";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxBuseo
            // 
            this.cbxBuseo.IsAppendAll = true;
            this.cbxBuseo.Location = new System.Drawing.Point(382, 8);
            this.cbxBuseo.Name = "cbxBuseo";
            this.cbxBuseo.Size = new System.Drawing.Size(121, 21);
            this.cbxBuseo.TabIndex = 29;
            // 
            // dbxJaeryo
            // 
            this.dbxJaeryo.Location = new System.Drawing.Point(703, 8);
            this.dbxJaeryo.Name = "dbxJaeryo";
            this.dbxJaeryo.Size = new System.Drawing.Size(310, 20);
            this.dbxJaeryo.TabIndex = 28;
            // 
            // fbxJaeryo
            // 
            this.fbxJaeryo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxJaeryo.FindWorker = this.fwkCommon;
            this.fbxJaeryo.Location = new System.Drawing.Point(591, 8);
            this.fbxJaeryo.MaxLength = 10;
            this.fbxJaeryo.Name = "fbxJaeryo";
            this.fbxJaeryo.Size = new System.Drawing.Size(112, 20);
            this.fbxJaeryo.TabIndex = 26;
            this.fbxJaeryo.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxJaeryo_DataValidating);
            this.fbxJaeryo.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxJaeryo_FindSelected);
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkCommon.FormText = "材料コード";
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fwkCommon.ServerFilter = true;
            this.fwkCommon.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkCommon_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "jaeryo_code";
            this.findColumnInfo1.ColWidth = 121;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "材料コード";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "jaeryo_name";
            this.findColumnInfo2.ColWidth = 233;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "材料コード名";
            // 
            // xLabel40
            // 
            this.xLabel40.Location = new System.Drawing.Point(515, 8);
            this.xLabel40.Name = "xLabel40";
            this.xLabel40.Size = new System.Drawing.Size(75, 20);
            this.xLabel40.TabIndex = 27;
            this.xLabel40.Text = "薬品コード";
            this.xLabel40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel4
            // 
            this.xLabel4.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel4.Location = new System.Drawing.Point(183, 12);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(16, 20);
            this.xLabel4.TabIndex = 24;
            this.xLabel4.Text = "~";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dptToDt
            // 
            this.dptToDt.Location = new System.Drawing.Point(199, 8);
            this.dptToDt.Name = "dptToDt";
            this.dptToDt.Size = new System.Drawing.Size(96, 20);
            this.dptToDt.TabIndex = 2;
            this.dptToDt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLabel1
            // 
            this.xLabel1.Location = new System.Drawing.Point(8, 8);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(78, 20);
            this.xLabel1.TabIndex = 1;
            this.xLabel1.Text = "オーダ日付";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dptFrDt
            // 
            this.dptFrDt.Location = new System.Drawing.Point(87, 8);
            this.dptFrDt.Name = "dptFrDt";
            this.dptFrDt.Size = new System.Drawing.Size(96, 20);
            this.dptFrDt.TabIndex = 0;
            this.dptFrDt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdPHY1002);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(5, 41);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel2.Size = new System.Drawing.Size(1028, 538);
            this.xPanel2.TabIndex = 4;
            // 
            // grdPHY1002
            // 
            this.grdPHY1002.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell11,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell1,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell4});
            this.grdPHY1002.ColPerLine = 13;
            this.grdPHY1002.ColResizable = true;
            this.grdPHY1002.Cols = 14;
            this.grdPHY1002.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPHY1002.FixedCols = 1;
            this.grdPHY1002.FixedRows = 1;
            this.grdPHY1002.HeaderHeights.Add(27);
            this.grdPHY1002.Location = new System.Drawing.Point(2, 2);
            this.grdPHY1002.Name = "grdPHY1002";
            this.grdPHY1002.QuerySQL = resources.GetString("grdPHY1002.QuerySQL");
            this.grdPHY1002.ReadOnly = true;
            this.grdPHY1002.RowHeaderVisible = true;
            this.grdPHY1002.Rows = 2;
            this.grdPHY1002.Size = new System.Drawing.Size(1022, 532);
            this.grdPHY1002.TabIndex = 0;
            this.grdPHY1002.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPHY1002_QueryStarting);
            this.grdPHY1002.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPHY1002_GridCellPainting);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "jaeryo_code";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "jaeryo_name";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "gwa_name";
            this.xEditGridCell11.CellWidth = 92;
            this.xEditGridCell11.Col = 2;
            this.xEditGridCell11.HeaderText = "依頼科";
            this.xEditGridCell11.SuppressRepeating = true;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "divide";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell17.CellWidth = 36;
            this.xEditGridCell17.Col = 9;
            this.xEditGridCell17.HeaderText = "回数";
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "dv_time";
            this.xEditGridCell18.CellWidth = 29;
            this.xEditGridCell18.Col = 8;
            this.xEditGridCell18.HeaderText = "DV";
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "ord_suryang";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell19.CellWidth = 45;
            this.xEditGridCell19.Col = 10;
            this.xEditGridCell19.HeaderText = "1日量";
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "order_suryang";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell20.CellWidth = 43;
            this.xEditGridCell20.Col = 7;
            this.xEditGridCell20.HeaderText = "1回量";
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "order_danui";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.HeaderText = "単位";
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "subul_danui";
            this.xEditGridCell22.CellWidth = 49;
            this.xEditGridCell22.Col = 13;
            this.xEditGridCell22.HeaderText = "単位";
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "order_date";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell23.Col = 1;
            this.xEditGridCell23.HeaderText = "オーダ日付";
            this.xEditGridCell23.SuppressRepeating = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "drg_bunho";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell1.CellWidth = 63;
            this.xEditGridCell1.Col = 5;
            this.xEditGridCell1.HeaderText = "投薬番号";
            this.xEditGridCell1.SuppressRepeating = true;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "dc_yn";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "bannab_yn";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "bunho";
            this.xEditGridCell26.CellWidth = 88;
            this.xEditGridCell26.Col = 3;
            this.xEditGridCell26.HeaderText = "患者番号";
            this.xEditGridCell26.SuppressRepeating = true;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "suname";
            this.xEditGridCell27.CellWidth = 114;
            this.xEditGridCell27.Col = 4;
            this.xEditGridCell27.HeaderText = "患者氏名";
            this.xEditGridCell27.SuppressRepeating = true;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "fkocs1003";
            this.xEditGridCell28.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "subul_suryang";
            this.xEditGridCell29.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell29.CellWidth = 62;
            this.xEditGridCell29.Col = 12;
            this.xEditGridCell29.HeaderText = "受払数量";
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "bogyong_name";
            this.xEditGridCell30.CellWidth = 235;
            this.xEditGridCell30.Col = 6;
            this.xEditGridCell30.HeaderText = "服用法";
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "source_fkocs1003";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "jubsu_date";
            this.xEditGridCell32.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "nalsu";
            this.xEditGridCell33.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell33.CellWidth = 39;
            this.xEditGridCell33.Col = 11;
            this.xEditGridCell33.HeaderText = "日数";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "remark";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xdwWorker1
            // 
            this.xdwWorker1.DataWindowObject = "d_drg900";
            this.xdwWorker1.IsPreviewStatusPopup = true;
            this.xdwWorker1.LibraryList = "..\\DRGS\\drgs.drg2010q02.pbd";
            this.xdwWorker1.PaperSize = IHIS.Framework.DataWindowPaperSize.A4;
            this.xdwWorker1.PrintStart += new System.ComponentModel.CancelEventHandler(this.xdwWorker1_PrintStart);
            // 
            // DRG2010Q02
            // 
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.pnlBottom);
            this.Name = "DRG2010Q02";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1038, 620);
            this.Load += new System.EventHandler(this.DRG2010Q02_Load);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.PHY1002Q02_ScreenOpen);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxBuseo)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPHY1002)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Common Properties
        private string mHospCode = EnvironInfo.HospCode;
        #endregion

        private void DRG2010Q02_Load(object sender, EventArgs e)
        {
            fwkCommon.InputSQL = @"SELECT JAERYO_CODE, JAERYO_NAME
                                     FROM INV0110
                                    WHERE HOSP_CODE    = '" + mHospCode + @"'
                                      AND (JAERYO_CODE LIKE  :f_find1||'%'
                                       OR JAERYO_NAME  LIKE  '%'||:f_find1||'%')
                                      AND JAERYO_GUBUN = 'A'
                                    ORDER BY 2";
        }

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    if (!this.grdPHY1002.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
                    break;
                case FunctionType.Print:
                    xdwWorker1.Print();
                    break;
                default:
                    break;
            }
        }

        private void PHY1002Q02_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            dptFrDt.SetDataValue(EnvironInfo.GetSysDate());
            dptToDt.SetDataValue(EnvironInfo.GetSysDate());
        }

        private void fbxJaeryo_FindSelected(object sender, IHIS.Framework.FindEventArgs e)
        {
            dbxJaeryo.SetDataValue(e.ReturnValues[1].ToString());
        }

        private void grdPHY1002_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (e.DataRow["dc_yn"].ToString() == "Y")
            {
                e.DrawMiddleLine = true;
                e.MiddleLineColor = Color.Red;

            }
        }

        private void fbxJaeryo_DataValidating(object sender, DataValidatingEventArgs e)
        {
            object retVal =
                Service.ExecuteScalar("SELECT JAERYO_NAME FROM INV0110 WHERE JAERYO_CODE = '" + e.DataValue + "' AND HOSP_CODE = '"
                + mHospCode + "'");

            if (!TypeCheck.IsNull(retVal))
            {
                dbxJaeryo.SetEditValue(retVal.ToString());
            }
        }

        private void fwkCommon_QueryStarting(object sender, CancelEventArgs e)
        {
            //fwkCommon.SetBindVarValue("f_find1", fbxJaeryo.GetDataValue());

        }

        private void xdwWorker1_PrintStart(object sender, CancelEventArgs e)
        {
            this.xdwWorker1.SourceTable = this.grdPHY1002.LayoutTable;
        }

        private void grdPHY1002_QueryStarting(object sender, CancelEventArgs e)
        {
            grdPHY1002.SetBindVarValue("f_fr_jubsu_date", dptFrDt.GetDataValue());
            grdPHY1002.SetBindVarValue("f_to_jubsu_date", dptToDt.GetDataValue());
            grdPHY1002.SetBindVarValue("f_gwa", cbxBuseo.GetDataValue());
            grdPHY1002.SetBindVarValue("f_jaeryo_code", fbxJaeryo.GetDataValue());
            grdPHY1002.SetBindVarValue("f_hosp_code", mHospCode);
        }
    }
}

