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
    /// DRG3010Q07에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class DRG3010Q07 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XPatientBox paid;
        private IHIS.Framework.XPanel panTop;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell62;
        private IHIS.Framework.XEditGridCell xEditGridCell63;
        private IHIS.Framework.XEditGridCell xEditGridCell64;
        private IHIS.Framework.XEditGridCell xEditGridCell65;
        private IHIS.Framework.XEditGridCell xEditGridCell66;
        private IHIS.Framework.XEditGridCell xEditGridCell67;
        private IHIS.Framework.XEditGridCell xEditGridCell68;
        private IHIS.Framework.XEditGridCell xEditGridCell69;
        private IHIS.Framework.XEditGridCell xEditGridCell70;
        private IHIS.Framework.XEditGridCell xEditGridCell71;
        private IHIS.Framework.XEditGridCell xEditGridCell72;
        private IHIS.Framework.XEditGridCell xEditGridCell73;
        private IHIS.Framework.XEditGridCell xEditGridCell74;
        private IHIS.Framework.XEditGridCell xEditGridCell75;
        private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private IHIS.Framework.XEditGridCell xEditGridCell78;
        private IHIS.Framework.XEditGridCell xEditGridCell79;
        private IHIS.Framework.XEditGridCell xEditGridCell80;
        private IHIS.Framework.XEditGridCell xEditGridCell81;
        private IHIS.Framework.XEditGridCell xEditGridCell82;
        private IHIS.Framework.XEditGridCell xEditGridCell83;
        private IHIS.Framework.XEditGridCell xEditGridCell84;
        private IHIS.Framework.XEditGridCell xEditGridCell85;
        private IHIS.Framework.XEditGridCell xEditGridCell86;
        private IHIS.Framework.XEditGridCell xEditGridCell87;
        private IHIS.Framework.XEditGridCell xEditGridCell88;
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
        private IHIS.Framework.XEditGrid grdDrg3010;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public DRG3010Q07()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG3010Q07));
            this.paid = new IHIS.Framework.XPatientBox();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdDrg3010 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.panTop = new IHIS.Framework.XPanel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            ((System.ComponentModel.ISupportInitialize)(this.paid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg3010)).BeginInit();
            this.panTop.SuspendLayout();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // paid
            // 
            this.paid.BoxType = IHIS.Framework.PatientBoxType.NormalDetail;
            this.paid.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paid.Location = new System.Drawing.Point(8, 5);
            this.paid.Name = "paid";
            this.paid.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.paid.Size = new System.Drawing.Size(928, 32);
            this.paid.TabIndex = 24;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(700, 2);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.xButtonList1.Size = new System.Drawing.Size(244, 34);
            this.xButtonList1.TabIndex = 1;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdDrg3010
            // 
            this.grdDrg3010.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell6,
            this.xEditGridCell4,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell17,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell1,
            this.xEditGridCell94,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell98});
            this.grdDrg3010.ColPerLine = 31;
            this.grdDrg3010.ColResizable = true;
            this.grdDrg3010.Cols = 32;
            this.grdDrg3010.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDrg3010.FixedCols = 1;
            this.grdDrg3010.FixedRows = 1;
            this.grdDrg3010.HeaderHeights.Add(42);
            this.grdDrg3010.Location = new System.Drawing.Point(2, 2);
            this.grdDrg3010.Name = "grdDrg3010";
            this.grdDrg3010.QuerySQL = resources.GetString("grdDrg3010.QuerySQL");
            this.grdDrg3010.RowHeaderVisible = true;
            this.grdDrg3010.Rows = 2;
            this.grdDrg3010.Size = new System.Drawing.Size(944, 499);
            this.grdDrg3010.TabIndex = 3;
            this.grdDrg3010.ToolTipActive = true;
            this.grdDrg3010.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDrg3010_QueryStarting);
            this.grdDrg3010.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdDrg3010_GridCellPainting);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "fkocs2003";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.ApplyPaintingEvent = true;
            this.xEditGridCell3.AutoInsertAtEnterKey = true;
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.CellWidth = 65;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "患者番号";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.SuppressRepeating = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.ApplyPaintingEvent = true;
            this.xEditGridCell6.CellName = "order_date";
            this.xEditGridCell6.CellWidth = 73;
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.HeaderText = "オーダ日付";
            this.xEditGridCell6.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.ApplyPaintingEvent = true;
            this.xEditGridCell4.CellName = "jubsu_date";
            this.xEditGridCell4.CellWidth = 73;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.HeaderText = "受付日付";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.ApplyPaintingEvent = true;
            this.xEditGridCell7.AutoInsertAtEnterKey = true;
            this.xEditGridCell7.CellName = "drg_bunho";
            this.xEditGridCell7.CellWidth = 33;
            this.xEditGridCell7.Col = 3;
            this.xEditGridCell7.HeaderText = "投薬\r\n番号";
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.ApplyPaintingEvent = true;
            this.xEditGridCell8.CellName = "ho_code";
            this.xEditGridCell8.CellWidth = 28;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "病室";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.SuppressRepeating = true;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.ApplyPaintingEvent = true;
            this.xEditGridCell9.CellName = "ho_dong";
            this.xEditGridCell9.CellWidth = 29;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "病棟";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            this.xEditGridCell9.SuppressRepeating = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.ApplyPaintingEvent = true;
            this.xEditGridCell10.CellName = "doctor";
            this.xEditGridCell10.CellWidth = 61;
            this.xEditGridCell10.Col = 8;
            this.xEditGridCell10.HeaderText = "診療医師";
            this.xEditGridCell10.IsReadOnly = true;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.ApplyPaintingEvent = true;
            this.xEditGridCell11.CellName = "gwa";
            this.xEditGridCell11.CellWidth = 49;
            this.xEditGridCell11.Col = 7;
            this.xEditGridCell11.HeaderText = "診療科";
            this.xEditGridCell11.IsReadOnly = true;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.ApplyPaintingEvent = true;
            this.xEditGridCell13.CellName = "jaeryo_code";
            this.xEditGridCell13.CellWidth = 41;
            this.xEditGridCell13.Col = 19;
            this.xEditGridCell13.HeaderText = "薬品\r\nコード";
            this.xEditGridCell13.IsReadOnly = true;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.ApplyPaintingEvent = true;
            this.xEditGridCell14.CellName = "nalsu";
            this.xEditGridCell14.CellWidth = 23;
            this.xEditGridCell14.Col = 14;
            this.xEditGridCell14.HeaderText = "日\r\n数";
            this.xEditGridCell14.IsReadOnly = true;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "divide";
            this.xEditGridCell17.CellWidth = 33;
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.ApplyPaintingEvent = true;
            this.xEditGridCell21.CellName = "order_suryang";
            this.xEditGridCell21.CellWidth = 33;
            this.xEditGridCell21.Col = 11;
            this.xEditGridCell21.HeaderText = "1回\r\n数量";
            this.xEditGridCell21.IsReadOnly = true;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.ApplyPaintingEvent = true;
            this.xEditGridCell22.CellName = "subul_suryang";
            this.xEditGridCell22.CellWidth = 37;
            this.xEditGridCell22.Col = 15;
            this.xEditGridCell22.HeaderText = "受払\r\n数量";
            this.xEditGridCell22.IsReadOnly = true;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.ApplyPaintingEvent = true;
            this.xEditGridCell24.CellName = "ord_suryang";
            this.xEditGridCell24.CellWidth = 33;
            this.xEditGridCell24.Col = 10;
            this.xEditGridCell24.HeaderText = "1日\r\n数量";
            this.xEditGridCell24.IsReadOnly = true;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.ApplyPaintingEvent = true;
            this.xEditGridCell25.CellName = "order_danui";
            this.xEditGridCell25.CellWidth = 29;
            this.xEditGridCell25.Col = 16;
            this.xEditGridCell25.HeaderText = "処方\r\n単位";
            this.xEditGridCell25.IsReadOnly = true;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.ApplyPaintingEvent = true;
            this.xEditGridCell26.CellName = "subul_danui";
            this.xEditGridCell26.CellWidth = 29;
            this.xEditGridCell26.Col = 17;
            this.xEditGridCell26.HeaderText = "受払\r\n単位";
            this.xEditGridCell26.IsReadOnly = true;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "bunryu1";
            this.xEditGridCell27.CellWidth = 35;
            this.xEditGridCell27.Col = 23;
            this.xEditGridCell27.HeaderText = "分類1";
            this.xEditGridCell27.IsReadOnly = true;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "bunryu2";
            this.xEditGridCell28.CellWidth = 36;
            this.xEditGridCell28.Col = 24;
            this.xEditGridCell28.HeaderText = "分類2";
            this.xEditGridCell28.IsReadOnly = true;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.ApplyPaintingEvent = true;
            this.xEditGridCell29.CellName = "bogyong_code";
            this.xEditGridCell29.CellWidth = 44;
            this.xEditGridCell29.Col = 22;
            this.xEditGridCell29.HeaderText = "服用法";
            this.xEditGridCell29.IsReadOnly = true;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "caution_code";
            this.xEditGridCell62.CellWidth = 126;
            this.xEditGridCell62.Col = 21;
            this.xEditGridCell62.HeaderText = "注意事項";
            this.xEditGridCell62.IsReadOnly = true;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.ApplyPaintingEvent = true;
            this.xEditGridCell63.CellName = "mix_yn";
            this.xEditGridCell63.CellWidth = 25;
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.HeaderText = "MIX";
            this.xEditGridCell63.IsReadOnly = true;
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "toiwon_drg_yn";
            this.xEditGridCell64.CellWidth = 23;
            this.xEditGridCell64.Col = 26;
            this.xEditGridCell64.HeaderText = "退\r\n院\r\n/\r\n外\r\n出";
            this.xEditGridCell64.IsReadOnly = true;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "emergency";
            this.xEditGridCell65.CellWidth = 18;
            this.xEditGridCell65.Col = 27;
            this.xEditGridCell65.HeaderText = "救\r\n急";
            this.xEditGridCell65.IsReadOnly = true;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "append_yn";
            this.xEditGridCell66.CellWidth = 18;
            this.xEditGridCell66.Col = 28;
            this.xEditGridCell66.HeaderText = "追\r\n加";
            this.xEditGridCell66.IsReadOnly = true;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "magam_gubun";
            this.xEditGridCell67.CellWidth = 31;
            this.xEditGridCell67.CodeDisplay = false;
            this.xEditGridCell67.Col = 29;
            this.xEditGridCell67.DictColumn = "MAGAM_GUBUN";
            this.xEditGridCell67.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell67.HeaderText = "締切\r\n区分";
            this.xEditGridCell67.IsReadOnly = true;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "magam_ser";
            this.xEditGridCell68.CellWidth = 29;
            this.xEditGridCell68.Col = 30;
            this.xEditGridCell68.HeaderText = "締切\r\n順番";
            this.xEditGridCell68.IsReadOnly = true;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "dc_yn";
            this.xEditGridCell69.CellWidth = 19;
            this.xEditGridCell69.Col = 31;
            this.xEditGridCell69.HeaderText = "取\r\n消";
            this.xEditGridCell69.IsReadOnly = true;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "bannab_yn";
            this.xEditGridCell70.CellWidth = 19;
            this.xEditGridCell70.Col = 9;
            this.xEditGridCell70.HeaderText = "返\r\n納";
            this.xEditGridCell70.IsReadOnly = true;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.ApplyPaintingEvent = true;
            this.xEditGridCell71.CellLen = 4000;
            this.xEditGridCell71.CellName = "remark";
            this.xEditGridCell71.CellWidth = 48;
            this.xEditGridCell71.Col = 25;
            this.xEditGridCell71.DisplayMemoText = true;
            this.xEditGridCell71.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell71.HeaderText = "コメント";
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.ApplyPaintingEvent = true;
            this.xEditGridCell72.CellName = "dv_time";
            this.xEditGridCell72.CellWidth = 20;
            this.xEditGridCell72.Col = 12;
            this.xEditGridCell72.HeaderText = "類\r\n型";
            this.xEditGridCell72.IsReadOnly = true;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.ApplyPaintingEvent = true;
            this.xEditGridCell91.CellName = "dv";
            this.xEditGridCell91.CellWidth = 18;
            this.xEditGridCell91.Col = 13;
            this.xEditGridCell91.HeaderText = "回\r\n数";
            this.xEditGridCell91.IsReadOnly = true;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "powder_yn";
            this.xEditGridCell92.CellWidth = 15;
            this.xEditGridCell92.Col = 18;
            this.xEditGridCell92.HeaderText = "粉\r\n砕";
            this.xEditGridCell92.IsReadOnly = true;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "jubsu_ilsi";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.IsReadOnly = true;
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AutoInsertAtEnterKey = true;
            this.xEditGridCell1.CellName = "group_ser";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell1.CellWidth = 18;
            this.xEditGridCell1.Col = 5;
            this.xEditGridCell1.HeaderText = "G\r\nR";
            this.xEditGridCell1.IsReadOnly = true;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.ApplyPaintingEvent = true;
            this.xEditGridCell94.AutoInsertAtEnterKey = true;
            this.xEditGridCell94.CellName = "mix_group";
            this.xEditGridCell94.CellWidth = 20;
            this.xEditGridCell94.Col = 6;
            this.xEditGridCell94.HeaderText = "M\r\nI\r\nX";
            this.xEditGridCell94.IsReadOnly = true;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.ApplyPaintingEvent = true;
            this.xEditGridCell96.CellName = "jaeryo_name";
            this.xEditGridCell96.CellWidth = 108;
            this.xEditGridCell96.Col = 20;
            this.xEditGridCell96.HeaderText = "薬品名";
            this.xEditGridCell96.IsReadOnly = true;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.ApplyPaintingEvent = true;
            this.xEditGridCell97.CellName = "bunho_name";
            this.xEditGridCell97.CellWidth = 63;
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.HeaderText = "患者氏名";
            this.xEditGridCell97.IsReadOnly = true;
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            this.xEditGridCell97.SuppressRepeating = true;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.ApplyPaintingEvent = true;
            this.xEditGridCell98.AutoInsertAtEnterKey = true;
            this.xEditGridCell98.CellName = "serial_v";
            this.xEditGridCell98.CellWidth = 17;
            this.xEditGridCell98.Col = 4;
            this.xEditGridCell98.HeaderText = "R\r\nP";
            this.xEditGridCell98.IsReadOnly = true;
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.paid);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.DrawBorder = true;
            this.panTop.Location = new System.Drawing.Point(5, 5);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(950, 35);
            this.panTop.TabIndex = 3;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdDrg3010);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 40);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel1.Size = new System.Drawing.Size(950, 505);
            this.xPanel1.TabIndex = 4;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(5, 545);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(950, 40);
            this.xPanel2.TabIndex = 5;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "dv";
            this.xEditGridCell73.Col = 30;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "powder_yn";
            this.xEditGridCell74.Col = 31;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "jubsu_ilsi";
            this.xEditGridCell75.Col = 32;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "mix_group";
            this.xEditGridCell76.Col = 33;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "order_danui";
            this.xEditGridCell77.Col = 34;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "dv";
            this.xEditGridCell78.Col = 35;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "powder_yn";
            this.xEditGridCell79.Col = 36;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "jubsu_ilsi";
            this.xEditGridCell80.Col = 37;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "mix_group";
            this.xEditGridCell81.Col = 38;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "ord_danui";
            this.xEditGridCell82.Col = 30;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "jaeryo_name";
            this.xEditGridCell83.Col = 31;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "subul_danui";
            this.xEditGridCell84.Col = 32;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "dv";
            this.xEditGridCell85.Col = 33;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "powder_yn";
            this.xEditGridCell86.Col = 34;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "jubsu_ilsi";
            this.xEditGridCell87.Col = 35;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "mix_group";
            this.xEditGridCell88.Col = 36;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "jaeryo_name";
            this.xEditGridCell89.Col = 37;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "subul_danui";
            this.xEditGridCell90.Col = 38;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "subul_danui";
            this.xEditGridCell95.Col = 34;
            // 
            // DRG3010Q07
            // 
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.panTop);
            this.Name = "DRG3010Q07";
            this.Padding = new System.Windows.Forms.Padding(5);
            ((System.ComponentModel.ISupportInitialize)(this.paid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg3010)).EndInit();
            this.panTop.ResumeLayout(false);
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        #endregion

        #region xButtonList1_ButtonClick
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    this.CurrMQLayout = this.grdDrg3010;
                    break;
            }
        }
        #endregion

        private void grdDrg3010_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            // DC 인경우 빨간 줄을 끈다
            if (e.DataRow["dc_yn"].ToString() == "Y")
            {
                e.DrawMiddleLine = true;
                e.MiddleLineColor = Color.Red;
            }

            // 마약인경우 빨간색으로 표현한다
            if (e.DataRow["bunryu2"].ToString() == "1")
            {
                e.ForeColor = Color.Red;
            }

            // 미마감을 파란색으로한다
            if (e.DataRow["magam_gubun"].ToString() == "")
            {
                e.ForeColor = Color.Blue;
            }

        }

        private void grdDrg3010_QueryStarting(object sender, CancelEventArgs e)
        {
            grdDrg3010.SetBindVarValue("f_bunho", paid.BunHo);
        }
    }
}

