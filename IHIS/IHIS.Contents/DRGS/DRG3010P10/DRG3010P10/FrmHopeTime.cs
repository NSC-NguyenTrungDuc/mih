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
    /// FrmHopeTime에 대한 요약 설명입니다.
    /// </summary>
    public class FrmHopeTime : IHIS.Framework.XForm
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XEditGrid grdPaQuery;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell332;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XComboItem xComboItem5;
        private IHIS.Framework.XComboItem xComboItem6;
        private IHIS.Framework.XComboItem xComboItem10;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell83;
        private IHIS.Framework.XEditGridCell xEditGridCell87;
        private IHIS.Framework.XEditGridCell xEditGridCell75;
        private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private IHIS.Framework.XEditGridCell xEditGridCell78;
        private IHIS.Framework.XEditGridCell xEditGridCell79;
        private IHIS.Framework.XEditGridCell xEditGridCell80;
        private IHIS.Framework.XEditGridCell xEditGridCell81;
        private IHIS.Framework.XEditGridCell xEditGridCell82;
        private IHIS.Framework.XEditGridCell xEditGridCell84;
        private IHIS.Framework.XEditGridCell xEditGridCell85;
        private IHIS.Framework.XEditGridCell xEditGridCell86;
        private IHIS.Framework.XEditGridCell xEditGridCell89;
        private IHIS.Framework.XEditGridCell xEditGridCell90;
        private IHIS.Framework.XEditGridCell xEditGridCell91;
        private IHIS.Framework.XEditGridCell xEditGridCell92;
        private IHIS.Framework.XEditGridCell xEditGridCell93;
        private IHIS.Framework.XEditGridCell xEditGridCell94;
        private IHIS.Framework.XEditGridCell xEditGridCell95;
        private IHIS.Framework.XEditGridCell xEditGridCell96;
        private IHIS.Framework.XEditGridCell xEditGridCell97;
        private IHIS.Framework.XEditGridCell xEditGridCell98;
        private IHIS.Framework.XEditGridCell xEditGridCell100;
        private IHIS.Framework.XEditGridCell xEditGridCell99;
        private IHIS.Framework.XEditGridCell xEditGridCell316;
        private IHIS.Framework.XEditGridCell xEditGridCell320;
        private IHIS.Framework.XEditGridCell xEditGridCell318;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell322;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell70;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell65;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XEditGridCell xEditGridCell64;
        private IHIS.Framework.XEditGridCell xEditGridCell60;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell39;
        private IHIS.Framework.XEditGridCell xEditGridCell69;
        private IHIS.Framework.XEditGridCell xEditGridCell58;
        private IHIS.Framework.XEditGridCell xEditGridCell68;
        private IHIS.Framework.XEditGridCell xEditGridCell66;
        private IHIS.Framework.XEditGridCell xEditGridCell71;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell59;
        private IHIS.Framework.XEditGridCell xEditGridCell67;
        private IHIS.Framework.XEditGridCell xEditGridCell72;
        private IHIS.Framework.XEditGridCell xEditGridCell74;
        private IHIS.Framework.XEditGridCell xEditGridCell73;
        private IHIS.Framework.XEditGridCell xEditGridCell315;
        private IHIS.Framework.XEditGridCell xEditGridCell319;
        private IHIS.Framework.XEditGridCell xEditGridCell317;
        private IHIS.Framework.XEditGridCell xEditGridCell61;
        private IHIS.Framework.XEditGridCell xEditGridCell321;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XButtonList btnList1;
        private IHIS.Framework.XEditGrid grdTimeListJUSAOrder;
        private IHIS.Framework.XEditGrid grdTimeListOrder;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XButton btnSave;
        private IHIS.Framework.XButton btnCurSave;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmHopeTime(string bunho)
        {
            //
            // Windows Form 디자이너 지원에 필요합니다.
            //
            InitializeComponent();

            //저장 수행자 Set
            this.grdPaQuery.SavePerformer = new XSavePerformer(this);
            this.grdTimeListOrder.SavePerformer = this.grdPaQuery.SavePerformer;
            this.grdTimeListJUSAOrder.SavePerformer = this.grdPaQuery.SavePerformer;
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdPaQuery);
            this.SaveLayoutList.Add(this.grdTimeListOrder);
            this.SaveLayoutList.Add(this.grdTimeListJUSAOrder);

            paBox.SetPatientID(bunho);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHopeTime));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.grdTimeListOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell315 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell319 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell317 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell321 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.grdTimeListJUSAOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell316 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell320 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell318 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell322 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.grdPaQuery = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell332 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xComboItem10 = new IHIS.Framework.XComboItem();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnCurSave = new IHIS.Framework.XButton();
            this.btnSave = new IHIS.Framework.XButton();
            this.btnList1 = new IHIS.Framework.XButtonList();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTimeListOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTimeListJUSAOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaQuery)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList1)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.paBox);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 5);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1202, 32);
            this.xPanel1.TabIndex = 1;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.paBox.Location = new System.Drawing.Point(0, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(1198, 30);
            this.paBox.TabIndex = 17;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xPanel4);
            this.xPanel2.Controls.Add(this.grdPaQuery);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(5, 37);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel2.Size = new System.Drawing.Size(1202, 634);
            this.xPanel2.TabIndex = 2;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.grdTimeListOrder);
            this.xPanel4.Controls.Add(this.grdTimeListJUSAOrder);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel4.Location = new System.Drawing.Point(372, 2);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(826, 628);
            this.xPanel4.TabIndex = 1;
            // 
            // grdTimeListOrder
            // 
            this.grdTimeListOrder.ApplyPaintEventToAllColumn = true;
            this.grdTimeListOrder.CallerID = '2';
            this.grdTimeListOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell18,
            this.xEditGridCell70,
            this.xEditGridCell19,
            this.xEditGridCell65,
            this.xEditGridCell38,
            this.xEditGridCell64,
            this.xEditGridCell60,
            this.xEditGridCell20,
            this.xEditGridCell39,
            this.xEditGridCell69,
            this.xEditGridCell58,
            this.xEditGridCell68,
            this.xEditGridCell66,
            this.xEditGridCell71,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell17,
            this.xEditGridCell59,
            this.xEditGridCell67,
            this.xEditGridCell72,
            this.xEditGridCell74,
            this.xEditGridCell73,
            this.xEditGridCell315,
            this.xEditGridCell319,
            this.xEditGridCell317,
            this.xEditGridCell61,
            this.xEditGridCell321,
            this.xEditGridCell12,
            this.xEditGridCell16});
            this.grdTimeListOrder.ColPerLine = 16;
            this.grdTimeListOrder.ColResizable = true;
            this.grdTimeListOrder.Cols = 17;
            this.grdTimeListOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTimeListOrder.FixedCols = 1;
            this.grdTimeListOrder.FixedRows = 1;
            this.grdTimeListOrder.HeaderHeights.Add(40);
            this.grdTimeListOrder.Location = new System.Drawing.Point(0, 0);
            this.grdTimeListOrder.Name = "grdTimeListOrder";
            this.grdTimeListOrder.QuerySQL = resources.GetString("grdTimeListOrder.QuerySQL");
            this.grdTimeListOrder.RowHeaderVisible = true;
            this.grdTimeListOrder.Rows = 2;
            this.grdTimeListOrder.Size = new System.Drawing.Size(826, 628);
            this.grdTimeListOrder.TabIndex = 20;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "order_date";
            this.xEditGridCell18.CellWidth = 77;
            this.xEditGridCell18.Col = 1;
            this.xEditGridCell18.HeaderText = "オーダ日付";
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.SuppressRepeating = true;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "mix_group";
            this.xEditGridCell70.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell70.CellWidth = 20;
            this.xEditGridCell70.Col = 2;
            this.xEditGridCell70.HeaderText = "M\r\nI\r\nX";
            this.xEditGridCell70.IsReadOnly = true;
            this.xEditGridCell70.IsUpdCol = false;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "jaeryo_code";
            this.xEditGridCell19.CellWidth = 77;
            this.xEditGridCell19.Col = 3;
            this.xEditGridCell19.HeaderText = "オーダコード";
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdCol = false;
            this.xEditGridCell19.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "jaeryo_name";
            this.xEditGridCell65.CellWidth = 202;
            this.xEditGridCell65.Col = 4;
            this.xEditGridCell65.HeaderText = "オーダコード名";
            this.xEditGridCell65.IsReadOnly = true;
            this.xEditGridCell65.IsUpdCol = false;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "ord_suryang";
            this.xEditGridCell38.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell38.CellWidth = 40;
            this.xEditGridCell38.Col = 5;
            this.xEditGridCell38.HeaderText = "数量";
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsUpdCol = false;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "dv_time";
            this.xEditGridCell64.CellWidth = 22;
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.HeaderText = "DV";
            this.xEditGridCell64.IsReadOnly = true;
            this.xEditGridCell64.IsUpdCol = false;
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            this.xEditGridCell64.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "dv";
            this.xEditGridCell60.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell60.CellWidth = 22;
            this.xEditGridCell60.Col = 6;
            this.xEditGridCell60.HeaderText = "回\r\n数";
            this.xEditGridCell60.IsReadOnly = true;
            this.xEditGridCell60.IsUpdCol = false;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "nalsu";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell20.CellWidth = 22;
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.HeaderText = "日\r\n数";
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdCol = false;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "order_danui";
            this.xEditGridCell39.CellWidth = 50;
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.HeaderText = "単位";
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsUpdCol = false;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "danui_name";
            this.xEditGridCell69.CellWidth = 49;
            this.xEditGridCell69.Col = 7;
            this.xEditGridCell69.HeaderText = "単位";
            this.xEditGridCell69.IsReadOnly = true;
            this.xEditGridCell69.IsUpdCol = false;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "bogyong_code";
            this.xEditGridCell58.CellWidth = 197;
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.HeaderText = "用法";
            this.xEditGridCell58.IsReadOnly = true;
            this.xEditGridCell58.IsUpdCol = false;
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "bogyong_name";
            this.xEditGridCell68.CellWidth = 127;
            this.xEditGridCell68.Col = 8;
            this.xEditGridCell68.HeaderText = "用法";
            this.xEditGridCell68.IsReadOnly = true;
            this.xEditGridCell68.IsUpdCol = false;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "powder_yn";
            this.xEditGridCell66.CellWidth = 21;
            this.xEditGridCell66.Col = 9;
            this.xEditGridCell66.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell66.HeaderText = "粉\r\n砕";
            this.xEditGridCell66.IsReadOnly = true;
            this.xEditGridCell66.IsUpdCol = false;
            this.xEditGridCell66.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "remark";
            this.xEditGridCell71.CellWidth = 43;
            this.xEditGridCell71.Col = 14;
            this.xEditGridCell71.DisplayMemoText = true;
            this.xEditGridCell71.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell71.HeaderText = "コメント";
            this.xEditGridCell71.IsUpdCol = false;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "dv_1";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "朝";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdCol = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "dv_2";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "昼";
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "dv_3";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderText = "夕";
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdCol = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "dv_4";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.HeaderText = "就寝";
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "dv_5";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.HeaderText = "dv_5";
            this.xEditGridCell59.IsReadOnly = true;
            this.xEditGridCell59.IsUpdCol = false;
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "hubal_change_yn";
            this.xEditGridCell67.CellWidth = 21;
            this.xEditGridCell67.Col = 12;
            this.xEditGridCell67.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell67.HeaderText = "入\r\n院";
            this.xEditGridCell67.IsReadOnly = true;
            this.xEditGridCell67.IsUpdCol = false;
            this.xEditGridCell67.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "pharmacy";
            this.xEditGridCell72.CellWidth = 30;
            this.xEditGridCell72.Col = 10;
            this.xEditGridCell72.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell72.HeaderText = "簡易\r\n懸濁";
            this.xEditGridCell72.IsReadOnly = true;
            this.xEditGridCell72.IsUpdCol = false;
            this.xEditGridCell72.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "drg_pack_yn";
            this.xEditGridCell74.CellWidth = 21;
            this.xEditGridCell74.Col = 11;
            this.xEditGridCell74.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell74.HeaderText = "一\r\n包";
            this.xEditGridCell74.IsReadOnly = true;
            this.xEditGridCell74.IsUpdCol = false;
            this.xEditGridCell74.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "jusa";
            this.xEditGridCell73.CellWidth = 43;
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.HeaderText = "注射";
            this.xEditGridCell73.IsReadOnly = true;
            this.xEditGridCell73.IsUpdCol = false;
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            this.xEditGridCell73.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell315
            // 
            this.xEditGridCell315.CellName = "suname";
            this.xEditGridCell315.Col = -1;
            this.xEditGridCell315.HeaderText = "성명";
            this.xEditGridCell315.IsUpdCol = false;
            this.xEditGridCell315.IsVisible = false;
            this.xEditGridCell315.Row = -1;
            // 
            // xEditGridCell319
            // 
            this.xEditGridCell319.CellName = "drg_bunho";
            this.xEditGridCell319.Col = -1;
            this.xEditGridCell319.HeaderText = "투약번호";
            this.xEditGridCell319.IsUpdCol = false;
            this.xEditGridCell319.IsVisible = false;
            this.xEditGridCell319.Row = -1;
            // 
            // xEditGridCell317
            // 
            this.xEditGridCell317.CellName = "fkocs2003";
            this.xEditGridCell317.Col = -1;
            this.xEditGridCell317.HeaderText = "key";
            this.xEditGridCell317.IsVisible = false;
            this.xEditGridCell317.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "append_yn";
            this.xEditGridCell61.CellWidth = 21;
            this.xEditGridCell61.Col = 13;
            this.xEditGridCell61.HeaderText = "臨\r\n時";
            this.xEditGridCell61.IsReadOnly = true;
            this.xEditGridCell61.IsUpdatable = false;
            this.xEditGridCell61.IsUpdCol = false;
            // 
            // xEditGridCell321
            // 
            this.xEditGridCell321.CellName = "re_use_yn";
            this.xEditGridCell321.Col = -1;
            this.xEditGridCell321.IsUpdCol = false;
            this.xEditGridCell321.IsVisible = false;
            this.xEditGridCell321.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "hope_date";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell12.Col = 15;
            this.xEditGridCell12.HeaderText = "印刷日付";
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "hope_time";
            this.xEditGridCell16.CellWidth = 35;
            this.xEditGridCell16.Col = 16;
            this.xEditGridCell16.HeaderText = "時間";
            // 
            // grdTimeListJUSAOrder
            // 
            this.grdTimeListJUSAOrder.ApplyPaintEventToAllColumn = true;
            this.grdTimeListJUSAOrder.CallerID = '3';
            this.grdTimeListJUSAOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell75,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell89,
            this.xEditGridCell90,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell98,
            this.xEditGridCell100,
            this.xEditGridCell99,
            this.xEditGridCell316,
            this.xEditGridCell320,
            this.xEditGridCell318,
            this.xEditGridCell37,
            this.xEditGridCell322,
            this.xEditGridCell22,
            this.xEditGridCell23});
            this.grdTimeListJUSAOrder.ColPerLine = 17;
            this.grdTimeListJUSAOrder.ColResizable = true;
            this.grdTimeListJUSAOrder.Cols = 18;
            this.grdTimeListJUSAOrder.ControlBinding = true;
            this.grdTimeListJUSAOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTimeListJUSAOrder.FixedCols = 1;
            this.grdTimeListJUSAOrder.FixedRows = 1;
            this.grdTimeListJUSAOrder.HeaderHeights.Add(41);
            this.grdTimeListJUSAOrder.Location = new System.Drawing.Point(0, 0);
            this.grdTimeListJUSAOrder.Name = "grdTimeListJUSAOrder";
            this.grdTimeListJUSAOrder.QuerySQL = resources.GetString("grdTimeListJUSAOrder.QuerySQL");
            this.grdTimeListJUSAOrder.RowHeaderVisible = true;
            this.grdTimeListJUSAOrder.Rows = 2;
            this.grdTimeListJUSAOrder.Size = new System.Drawing.Size(826, 628);
            this.grdTimeListJUSAOrder.TabIndex = 21;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "order_date";
            this.xEditGridCell75.CellWidth = 77;
            this.xEditGridCell75.Col = 1;
            this.xEditGridCell75.HeaderText = "オーダ日付";
            this.xEditGridCell75.IsReadOnly = true;
            this.xEditGridCell75.IsUpdCol = false;
            this.xEditGridCell75.SuppressRepeating = true;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "mix_group";
            this.xEditGridCell76.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell76.CellWidth = 20;
            this.xEditGridCell76.Col = 2;
            this.xEditGridCell76.HeaderText = "M\r\nI\r\nX";
            this.xEditGridCell76.IsReadOnly = true;
            this.xEditGridCell76.IsUpdCol = false;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "jaeryo_code";
            this.xEditGridCell77.CellWidth = 77;
            this.xEditGridCell77.Col = 3;
            this.xEditGridCell77.HeaderText = "オーダコード";
            this.xEditGridCell77.IsReadOnly = true;
            this.xEditGridCell77.IsUpdCol = false;
            this.xEditGridCell77.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "jaeryo_name";
            this.xEditGridCell78.CellWidth = 203;
            this.xEditGridCell78.Col = 4;
            this.xEditGridCell78.HeaderText = "オーダコード名";
            this.xEditGridCell78.IsReadOnly = true;
            this.xEditGridCell78.IsUpdCol = false;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "ord_suryang";
            this.xEditGridCell79.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell79.CellWidth = 40;
            this.xEditGridCell79.Col = 5;
            this.xEditGridCell79.HeaderText = "数量";
            this.xEditGridCell79.IsReadOnly = true;
            this.xEditGridCell79.IsUpdCol = false;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "dv_time";
            this.xEditGridCell80.CellWidth = 22;
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.HeaderText = "DV";
            this.xEditGridCell80.IsReadOnly = true;
            this.xEditGridCell80.IsUpdCol = false;
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            this.xEditGridCell80.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "dv";
            this.xEditGridCell81.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell81.CellWidth = 22;
            this.xEditGridCell81.Col = 6;
            this.xEditGridCell81.HeaderText = "回\r\n数";
            this.xEditGridCell81.IsReadOnly = true;
            this.xEditGridCell81.IsUpdCol = false;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "nalsu";
            this.xEditGridCell82.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell82.CellWidth = 22;
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.HeaderText = "日\r\n数";
            this.xEditGridCell82.IsReadOnly = true;
            this.xEditGridCell82.IsUpdCol = false;
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "order_danui";
            this.xEditGridCell84.CellWidth = 50;
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.HeaderText = "単位";
            this.xEditGridCell84.IsReadOnly = true;
            this.xEditGridCell84.IsUpdCol = false;
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "danui_name";
            this.xEditGridCell85.CellWidth = 49;
            this.xEditGridCell85.Col = 7;
            this.xEditGridCell85.HeaderText = "単位";
            this.xEditGridCell85.IsReadOnly = true;
            this.xEditGridCell85.IsUpdCol = false;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "bogyong_code";
            this.xEditGridCell86.CellWidth = 197;
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.HeaderText = "用法";
            this.xEditGridCell86.IsReadOnly = true;
            this.xEditGridCell86.IsUpdCol = false;
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "bogyong_name";
            this.xEditGridCell89.CellWidth = 72;
            this.xEditGridCell89.Col = 8;
            this.xEditGridCell89.HeaderText = "注射\r\n速度";
            this.xEditGridCell89.IsReadOnly = true;
            this.xEditGridCell89.IsUpdCol = false;
            this.xEditGridCell89.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "powder_yn";
            this.xEditGridCell90.CellWidth = 19;
            this.xEditGridCell90.Col = 10;
            this.xEditGridCell90.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell90.HeaderText = "粉\r\n砕";
            this.xEditGridCell90.IsReadOnly = true;
            this.xEditGridCell90.IsUpdCol = false;
            this.xEditGridCell90.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "remark";
            this.xEditGridCell91.CellWidth = 35;
            this.xEditGridCell91.Col = 15;
            this.xEditGridCell91.DisplayMemoText = true;
            this.xEditGridCell91.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell91.HeaderText = "コメント";
            this.xEditGridCell91.IsUpdCol = false;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "dv_1";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.HeaderText = "朝";
            this.xEditGridCell92.IsReadOnly = true;
            this.xEditGridCell92.IsUpdCol = false;
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "dv_2";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.HeaderText = "昼";
            this.xEditGridCell93.IsReadOnly = true;
            this.xEditGridCell93.IsUpdCol = false;
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "dv_3";
            this.xEditGridCell94.Col = -1;
            this.xEditGridCell94.HeaderText = "夕";
            this.xEditGridCell94.IsReadOnly = true;
            this.xEditGridCell94.IsUpdCol = false;
            this.xEditGridCell94.IsVisible = false;
            this.xEditGridCell94.Row = -1;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "dv_4";
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.HeaderText = "就寝";
            this.xEditGridCell95.IsReadOnly = true;
            this.xEditGridCell95.IsUpdCol = false;
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "dv_5";
            this.xEditGridCell96.Col = -1;
            this.xEditGridCell96.HeaderText = "dv_5";
            this.xEditGridCell96.IsReadOnly = true;
            this.xEditGridCell96.IsUpdCol = false;
            this.xEditGridCell96.IsVisible = false;
            this.xEditGridCell96.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "hubal_change_yn";
            this.xEditGridCell97.CellWidth = 19;
            this.xEditGridCell97.Col = 13;
            this.xEditGridCell97.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell97.HeaderText = "入\r\n院";
            this.xEditGridCell97.IsReadOnly = true;
            this.xEditGridCell97.IsUpdCol = false;
            this.xEditGridCell97.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "pharmacy";
            this.xEditGridCell98.CellWidth = 30;
            this.xEditGridCell98.Col = 11;
            this.xEditGridCell98.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell98.HeaderText = "簡易\r\n懸濁";
            this.xEditGridCell98.IsReadOnly = true;
            this.xEditGridCell98.IsUpdCol = false;
            this.xEditGridCell98.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "drg_pack_yn";
            this.xEditGridCell100.CellWidth = 19;
            this.xEditGridCell100.Col = 12;
            this.xEditGridCell100.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell100.HeaderText = "一\r\n包";
            this.xEditGridCell100.IsReadOnly = true;
            this.xEditGridCell100.IsUpdCol = false;
            this.xEditGridCell100.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "jusa";
            this.xEditGridCell99.CellWidth = 79;
            this.xEditGridCell99.Col = 9;
            this.xEditGridCell99.HeaderText = "注射";
            this.xEditGridCell99.IsReadOnly = true;
            this.xEditGridCell99.IsUpdCol = false;
            // 
            // xEditGridCell316
            // 
            this.xEditGridCell316.CellName = "suname";
            this.xEditGridCell316.CellWidth = 32;
            this.xEditGridCell316.Col = -1;
            this.xEditGridCell316.HeaderText = "성명";
            this.xEditGridCell316.IsUpdCol = false;
            this.xEditGridCell316.IsVisible = false;
            this.xEditGridCell316.Row = -1;
            // 
            // xEditGridCell320
            // 
            this.xEditGridCell320.CellName = "drg_bunho";
            this.xEditGridCell320.Col = -1;
            this.xEditGridCell320.HeaderText = "투약번호";
            this.xEditGridCell320.IsUpdCol = false;
            this.xEditGridCell320.IsVisible = false;
            this.xEditGridCell320.Row = -1;
            // 
            // xEditGridCell318
            // 
            this.xEditGridCell318.CellName = "fkocs2003";
            this.xEditGridCell318.Col = -1;
            this.xEditGridCell318.HeaderText = "key";
            this.xEditGridCell318.IsVisible = false;
            this.xEditGridCell318.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "append_yn";
            this.xEditGridCell37.CellWidth = 19;
            this.xEditGridCell37.Col = 14;
            this.xEditGridCell37.HeaderText = "臨\r\n時";
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.IsUpdatable = false;
            this.xEditGridCell37.IsUpdCol = false;
            // 
            // xEditGridCell322
            // 
            this.xEditGridCell322.CellName = "re_use_yn";
            this.xEditGridCell322.CellWidth = 24;
            this.xEditGridCell322.Col = -1;
            this.xEditGridCell322.IsUpdCol = false;
            this.xEditGridCell322.IsVisible = false;
            this.xEditGridCell322.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "hope_date";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell22.Col = 16;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell22.HeaderText = "入力日付";
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "hope_time";
            this.xEditGridCell23.CellWidth = 35;
            this.xEditGridCell23.Col = 17;
            this.xEditGridCell23.HeaderText = "時間";
            // 
            // grdPaQuery
            // 
            this.grdPaQuery.ApplyPaintEventToAllColumn = true;
            this.grdPaQuery.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell21,
            this.xEditGridCell332,
            this.xEditGridCell10,
            this.xEditGridCell31,
            this.xEditGridCell83,
            this.xEditGridCell87,
            this.xEditGridCell9,
            this.xEditGridCell11,
            this.xEditGridCell8});
            this.grdPaQuery.ColPerLine = 7;
            this.grdPaQuery.Cols = 8;
            this.grdPaQuery.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdPaQuery.FixedCols = 1;
            this.grdPaQuery.FixedRows = 1;
            this.grdPaQuery.HeaderHeights.Add(41);
            this.grdPaQuery.Location = new System.Drawing.Point(2, 2);
            this.grdPaQuery.Name = "grdPaQuery";
            this.grdPaQuery.QuerySQL = resources.GetString("grdPaQuery.QuerySQL");
            this.grdPaQuery.RowHeaderVisible = true;
            this.grdPaQuery.Rows = 2;
            this.grdPaQuery.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdPaQuery.Size = new System.Drawing.Size(370, 628);
            this.grdPaQuery.TabIndex = 2;
            this.grdPaQuery.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPaQuery_GridCellPainting);
            this.grdPaQuery.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPaQuery_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.CellWidth = 75;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.HeaderText = "患者番号";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "suname";
            this.xEditGridCell2.CellWidth = 85;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.HeaderText = "患者氏名";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdCol = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "sex";
            this.xEditGridCell3.CellWidth = 20;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "性\r\n別";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "age";
            this.xEditGridCell4.CellWidth = 30;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "年\r\n齢";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "ho_dong";
            this.xEditGridCell5.CellWidth = 40;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.EnableSort = true;
            this.xEditGridCell5.HeaderText = "病棟";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.SuppressRepeating = true;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "doctor";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "doctor_name";
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.EnableSort = true;
            this.xEditGridCell7.HeaderText = "診療医";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "magam_yn";
            this.xEditGridCell21.CellWidth = 30;
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.EnableSort = true;
            this.xEditGridCell21.HeaderText = "締\r\n切";
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdCol = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            this.xEditGridCell21.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell332
            // 
            this.xEditGridCell332.CellName = "ho_dong1";
            this.xEditGridCell332.CellWidth = 33;
            this.xEditGridCell332.Col = 5;
            this.xEditGridCell332.HeaderText = "病棟";
            this.xEditGridCell332.IsReadOnly = true;
            this.xEditGridCell332.IsUpdatable = false;
            this.xEditGridCell332.IsUpdCol = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "append_yn";
            this.xEditGridCell10.CellWidth = 33;
            this.xEditGridCell10.Col = 1;
            this.xEditGridCell10.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6,
            this.xComboItem10});
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell10.HeaderText = "正規\r\n臨時";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            // 
            // xComboItem5
            // 
            this.xComboItem5.DisplayItem = "正規";
            this.xComboItem5.ValueItem = "N";
            // 
            // xComboItem6
            // 
            this.xComboItem6.DisplayItem = "臨時";
            this.xComboItem6.ValueItem = "Y";
            // 
            // xComboItem10
            // 
            this.xComboItem10.DisplayItem = "全体";
            this.xComboItem10.ValueItem = "%";
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "jusa_yn";
            this.xEditGridCell31.CellWidth = 24;
            this.xEditGridCell31.Col = 7;
            this.xEditGridCell31.HeaderText = "注\r\n射";
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.IsUpdatable = false;
            this.xEditGridCell31.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "hope_date";
            this.xEditGridCell83.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell83.CellWidth = 85;
            this.xEditGridCell83.Col = 2;
            this.xEditGridCell83.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell83.HeaderText = "印刷日付";
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "hope_time";
            this.xEditGridCell87.CellWidth = 36;
            this.xEditGridCell87.Col = 3;
            this.xEditGridCell87.HeaderText = "時間";
            this.xEditGridCell87.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "old_hope_date";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "old_hope_time";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "chk";
            this.xEditGridCell8.CellWidth = 35;
            this.xEditGridCell8.Col = 4;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell8.HeaderText = "変更";
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnCurSave);
            this.xPanel3.Controls.Add(this.btnSave);
            this.xPanel3.Controls.Add(this.btnList1);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(5, 671);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(1202, 36);
            this.xPanel3.TabIndex = 3;
            // 
            // btnCurSave
            // 
            this.btnCurSave.Image = ((System.Drawing.Image)(resources.GetObject("btnCurSave.Image")));
            this.btnCurSave.Location = new System.Drawing.Point(116, 3);
            this.btnCurSave.Name = "btnCurSave";
            this.btnCurSave.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnCurSave.Size = new System.Drawing.Size(168, 28);
            this.btnCurSave.TabIndex = 291;
            this.btnCurSave.Text = "システム指定日付変更";
            this.btnCurSave.Click += new System.EventHandler(this.btnCurSave_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnSave.Size = new System.Drawing.Size(112, 28);
            this.btnSave.TabIndex = 290;
            this.btnSave.Text = "指定日付変更";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnList1
            // 
            this.btnList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList1.IsVisiblePreview = false;
            this.btnList1.IsVisibleReset = false;
            this.btnList1.Location = new System.Drawing.Point(1037, 0);
            this.btnList1.Name = "btnList1";
            this.btnList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList1.Size = new System.Drawing.Size(163, 34);
            this.btnList1.TabIndex = 289;
            // 
            // FrmHopeTime
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(1212, 734);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Name = "FrmHopeTime";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "印刷日変更";
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.xPanel3, 0);
            this.Controls.SetChildIndex(this.xPanel2, 0);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTimeListOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTimeListJUSAOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaQuery)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            grdPaQuery.SetBindVarValue("f_bunho", paBox.BunHo);
            if (!grdPaQuery.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }

        private void grdPaQuery_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            string magam_bunryu = "1", magam_gubun = "N";

            string jusa_yn = grdPaQuery.GetItemString(e.CurrentRow, "jusa_yn");
            magam_gubun = grdPaQuery.GetItemString(e.CurrentRow, "append_yn");
            //내복, 외용
            if (jusa_yn == "N")
            {
                magam_bunryu = "1";
                grdTimeListOrder.Visible = true;
                grdTimeListJUSAOrder.Visible = false;

                grdTimeListOrder.SetBindVarValue("f_hope_date", grdPaQuery.GetItemString(e.CurrentRow, "hope_date"));
                grdTimeListOrder.SetBindVarValue("f_hope_time", grdPaQuery.GetItemString(e.CurrentRow, "hope_time"));
                grdTimeListOrder.SetBindVarValue("f_bunho", grdPaQuery.GetItemString(e.CurrentRow, "bunho"));
                grdTimeListOrder.SetBindVarValue("f_ho_dong", grdPaQuery.GetItemString(e.CurrentRow, "ho_dong"));
                grdTimeListOrder.SetBindVarValue("f_doctor", grdPaQuery.GetItemString(e.CurrentRow, "doctor"));
                grdTimeListOrder.SetBindVarValue("f_magam_gubun", magam_gubun);
                grdTimeListOrder.SetBindVarValue("f_magam_bunryu", magam_bunryu);

                if (!grdTimeListOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
            //주사
            if (jusa_yn == "Y")
            {
                magam_bunryu = "2";
                grdTimeListOrder.Visible = false;
                grdTimeListJUSAOrder.Visible = true;

                grdTimeListOrder.SetBindVarValue("f_hope_date", grdPaQuery.GetItemString(e.CurrentRow, "hope_date"));
                grdTimeListOrder.SetBindVarValue("f_hope_time", grdPaQuery.GetItemString(e.CurrentRow, "hope_time"));
                grdTimeListOrder.SetBindVarValue("f_bunho", grdPaQuery.GetItemString(e.CurrentRow, "bunho"));
                grdTimeListOrder.SetBindVarValue("f_ho_dong", grdPaQuery.GetItemString(e.CurrentRow, "ho_dong"));
                grdTimeListOrder.SetBindVarValue("f_doctor", grdPaQuery.GetItemString(e.CurrentRow, "doctor"));
                grdTimeListOrder.SetBindVarValue("f_magam_gubun", magam_gubun);
                grdTimeListOrder.SetBindVarValue("f_magam_bunryu", magam_bunryu);

                if (!grdTimeListJUSAOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
        }


        #region Save
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!grdPaQuery.SaveLayout()) { XMessageBox.Show(Service.ErrFullMsg); return; }
            if (!grdTimeListOrder.SaveLayout()) { XMessageBox.Show(Service.ErrFullMsg); return; }
            if (!grdTimeListJUSAOrder.SaveLayout()) { XMessageBox.Show(Service.ErrFullMsg); return; }
        }

        private void btnCurSave_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < grdPaQuery.RowCount; i++)
            {
                if (grdPaQuery.GetItemString(i, "chk") == "Y")
                {
                    grdPaQuery.SetItemValue(i, "hope_date", EnvironInfo.GetSysDate());
                    grdPaQuery.SetItemValue(i, "hope_time", DateTime.Now.ToString("hhmm"));
                }
            }

            if (!grdPaQuery.SaveLayout()) { XMessageBox.Show(Service.ErrFullMsg); return; }
            if (!grdTimeListOrder.SaveLayout()) { XMessageBox.Show(Service.ErrFullMsg); return; }
            if (!grdTimeListJUSAOrder.SaveLayout()) { XMessageBox.Show(Service.ErrFullMsg); return; }
        }
        #endregion

        private void grdPaQuery_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (grdPaQuery.GetItemString(e.RowNumber, "jusa_yn") == "Y")
                e.ForeColor = Color.Brown;

        }

        #region [ XSavePerformer ]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private FrmHopeTime parent = null;
            public XSavePerformer(FrmHopeTime parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Modified:
                                cmdText = @"UPDATE DRG3010
                                               SET USER_ID   = :q_user_id
                                                  ,UPD_DATE  = SYSDATE
                                                  ,HOPE_DATE = :f_hope_date
                                                  ,HOPE_TIME = :f_hope_time
                                             WHERE BUNHO     = :f_bunho
                                               AND RESIDENT  = :f_resident
                                               AND HOPE_DATE = :f_old_hope_date
                                               AND HOPE_TIME = :f_old_hope_time
                                               AND BUNRYU1   <> '4'
                                               AND :f_jusa_yn = 'N'";

                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return false;
                                }

                                cmdText = @"UPDATE DRG3010
                                               SET USER_ID   = :q_user_id
                                                  ,UPD_DATE  = SYSDATE
                                                  ,HOPE_DATE = :f_hope_date
                                                  ,HOPE_TIME = :f_hope_time
                                             WHERE BUNHO     = :f_bunho
                                               AND RESIDENT  = :f_resident
                                               AND HOPE_DATE = :f_old_hope_date
                                               AND HOPE_TIME = :f_old_hope_time
                                               AND BUNRYU1   = '4'
                                               AND :f_jusa_yn = 'Y'";
                                break;
                        }
                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Modified:
                                cmdText = @"UPDATE DRG3010
                                               SET USER_ID   = :q_user_id
                                                  ,UPD_DATE  = SYSDATE
                                                  ,HOPE_DATE = :f_hope_date
                                                  ,HOPE_TIME = :f_hope_time
                                             WHERE FKOCS2003 = :f_fkocs2003";
                                break;
                        }
                        break;

                    case '3':
                        switch (item.RowState)
                        {
                            case DataRowState.Modified:
                                cmdText = @"UPDATE DRG3010
                                               SET USER_ID   = :q_user_id
                                                 , UPD_DATE  = SYSDATE
                                                 , HOPE_DATE = :f_hope_date
                                                 , HOPE_TIME = :f_hope_time
                                             WHERE FKOCS2003 = :f_fkocs2003";
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
