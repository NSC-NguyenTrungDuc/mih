using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using IHIS.Framework;

namespace IHIS.DRGS
{
    /// <summary>
    /// FINDPA에 대한 요약 설명입니다.
    /// </summary>
    public class FrmBatJubsu : IHIS.Framework.XForm
    {
        private string bunho = string.Empty;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButton btnExit;
        private IHIS.Framework.XButton btnSave;
        private IHIS.Framework.XFlatLabel xFlatLabel1;
        private IHIS.Framework.XDatePicker dtpFromDate;
        private IHIS.Framework.XBuseoCombo xBuseoCombo;
        private IHIS.Framework.XFlatLabel xFlatLabel2;
        private IHIS.Framework.XButton btnAllUnCheck;
        private IHIS.Framework.XButton btnAllCheck;
        private IHIS.Framework.XEditGrid grdPaid;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XEditGridCell xEditGridCell109;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell78;
        private IHIS.Framework.XEditGridCell xEditGridCell80;
        private IHIS.Framework.MultiLayout layOrderJungbo;
        private IHIS.Framework.MultiLayout layAntiData;
        private IHIS.Framework.MultiLayout layOrderPrint;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XCheckBox chbOrderPrint;
        private IHIS.Framework.XCheckBox chbDataInterface;
        private IHIS.Framework.XDataWindow dw1;
        private MultiLayoutItem multiLayoutItem81;
        private MultiLayoutItem multiLayoutItem82;
        private MultiLayoutItem multiLayoutItem83;
        private MultiLayoutItem multiLayoutItem84;
        private MultiLayoutItem multiLayoutItem85;
        private MultiLayoutItem multiLayoutItem86;
        private MultiLayoutItem multiLayoutItem87;
        private MultiLayoutItem multiLayoutItem88;
        private MultiLayoutItem multiLayoutItem89;
        private MultiLayoutItem multiLayoutItem90;
        private MultiLayoutItem multiLayoutItem91;
        private MultiLayoutItem multiLayoutItem92;
        private MultiLayoutItem multiLayoutItem93;
        private MultiLayoutItem multiLayoutItem94;
        private MultiLayoutItem multiLayoutItem95;
        private MultiLayoutItem multiLayoutItem96;
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
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
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
        private MultiLayoutItem multiLayoutItem48;
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
        private MultiLayoutItem multiLayoutItem74;
        private MultiLayoutItem multiLayoutItem75;
        private MultiLayoutItem multiLayoutItem76;
        private MultiLayoutItem multiLayoutItem77;
        private MultiLayoutItem multiLayoutItem78;
        private MultiLayoutItem multiLayoutItem79;
        private MultiLayoutItem multiLayoutItem80;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmBatJubsu()
        {
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

        #region Windows Form 디자이너에서 생성한 코드
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBatJubsu));
            this.btnSave = new IHIS.Framework.XButton();
            this.btnExit = new IHIS.Framework.XButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdPaid = new IHIS.Framework.XEditGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.dw1 = new IHIS.Framework.XDataWindow();
            this.chbOrderPrint = new IHIS.Framework.XCheckBox();
            this.chbDataInterface = new IHIS.Framework.XCheckBox();
            this.btnAllUnCheck = new IHIS.Framework.XButton();
            this.btnAllCheck = new IHIS.Framework.XButton();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xFlatLabel2 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.xBuseoCombo = new IHIS.Framework.XBuseoCombo();
            this.layOrderJungbo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem81 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem82 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem83 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem84 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem85 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem86 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem87 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem88 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem89 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem90 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem91 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem92 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem93 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem94 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem95 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem96 = new IHIS.Framework.MultiLayoutItem();
            this.layAntiData = new IHIS.Framework.MultiLayout();
            this.layOrderPrint = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem52 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem74 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem75 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem76 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem77 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem78 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem79 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem80 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaid)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xBuseoCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderJungbo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layAntiData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(230, 54);
            this.btnSave.Name = "btnSave";
            this.btnSave.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnSave.Size = new System.Drawing.Size(134, 38);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "処方箋発行";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(298, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnExit.Size = new System.Drawing.Size(66, 26);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "閉じる";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdPaid);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(5, 105);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel2.Size = new System.Drawing.Size(368, 622);
            this.xPanel2.TabIndex = 5;
            // 
            // grdPaid
            // 
            this.grdPaid.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2,
            this.xEditGridCell26,
            this.xEditGridCell109,
            this.xEditGridCell22,
            this.xEditGridCell25,
            this.xEditGridCell78,
            this.xEditGridCell80,
            this.xEditGridCell1});
            this.grdPaid.ColPerLine = 4;
            this.grdPaid.ColResizable = true;
            this.grdPaid.Cols = 5;
            this.grdPaid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPaid.FixedCols = 1;
            this.grdPaid.FixedRows = 1;
            this.grdPaid.HeaderHeights.Add(28);
            this.grdPaid.Location = new System.Drawing.Point(2, 2);
            this.grdPaid.Name = "grdPaid";
            this.grdPaid.QuerySQL = resources.GetString("grdPaid.QuerySQL");
            this.grdPaid.RowHeaderVisible = true;
            this.grdPaid.Rows = 2;
            this.grdPaid.Size = new System.Drawing.Size(362, 616);
            this.grdPaid.TabIndex = 3;
            this.grdPaid.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPaid_QueryStarting);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.CellWidth = 87;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.HeaderText = "患者番号";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "order_date";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.HeaderText = "オ―ダ日付";
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            this.xEditGridCell26.SuppressRepeating = true;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "drg_bunho";
            this.xEditGridCell109.CellWidth = 71;
            this.xEditGridCell109.Col = 3;
            this.xEditGridCell109.HeaderText = "投薬番号";
            this.xEditGridCell109.IsReadOnly = true;
            this.xEditGridCell109.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "suname";
            this.xEditGridCell22.CellWidth = 118;
            this.xEditGridCell22.Col = 2;
            this.xEditGridCell22.HeaderText = "患者氏名";
            this.xEditGridCell22.IsReadOnly = true;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell25.CellName = "boryu_yn";
            this.xEditGridCell25.CellWidth = 30;
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.HeaderText = "保\r\n留";
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            this.xEditGridCell25.RowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell25.SelectedForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "order_remark";
            this.xEditGridCell78.CellWidth = 20;
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.HeaderText = "オ\r\nー\r\nダ";
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "drg_remark";
            this.xEditGridCell80.CellWidth = 20;
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.HeaderText = "薬\r\n局";
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "chk";
            this.xEditGridCell1.CellWidth = 40;
            this.xEditGridCell1.Col = 4;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell1.HeaderText = "選択";
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.dw1);
            this.xPanel3.Controls.Add(this.chbOrderPrint);
            this.xPanel3.Controls.Add(this.chbDataInterface);
            this.xPanel3.Controls.Add(this.btnAllUnCheck);
            this.xPanel3.Controls.Add(this.btnAllCheck);
            this.xPanel3.Controls.Add(this.dtpFromDate);
            this.xPanel3.Controls.Add(this.xFlatLabel2);
            this.xPanel3.Controls.Add(this.xFlatLabel1);
            this.xPanel3.Controls.Add(this.xBuseoCombo);
            this.xPanel3.Controls.Add(this.btnSave);
            this.xPanel3.Controls.Add(this.btnExit);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(5, 5);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel3.Size = new System.Drawing.Size(368, 100);
            this.xPanel3.TabIndex = 6;
            // 
            // dw1
            // 
            this.dw1.DataWindowObject = "d_drg2010_1";
            this.dw1.LibraryList = "..\\DRGS\\drgs.drg5100p01.pbd";
            this.dw1.Location = new System.Drawing.Point(24, 120);
            this.dw1.Name = "dw1";
            this.dw1.Size = new System.Drawing.Size(194, 104);
            this.dw1.TabIndex = 290;
            // 
            // chbOrderPrint
            // 
            this.chbOrderPrint.Checked = true;
            this.chbOrderPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOrderPrint.ForeColor = IHIS.Framework.XColor.XPanelBorderColor;
            this.chbOrderPrint.Location = new System.Drawing.Point(6, 74);
            this.chbOrderPrint.Name = "chbOrderPrint";
            this.chbOrderPrint.Size = new System.Drawing.Size(88, 24);
            this.chbOrderPrint.TabIndex = 289;
            this.chbOrderPrint.Text = "処方箋出力";
            this.chbOrderPrint.UseVisualStyleBackColor = false;
            // 
            // chbDataInterface
            // 
            this.chbDataInterface.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.chbDataInterface.Location = new System.Drawing.Point(6, 54);
            this.chbDataInterface.Name = "chbDataInterface";
            this.chbDataInterface.Size = new System.Drawing.Size(116, 24);
            this.chbDataInterface.TabIndex = 288;
            this.chbDataInterface.Text = "服薬指導文伝送";
            this.chbDataInterface.UseVisualStyleBackColor = false;
            this.chbDataInterface.Visible = false;
            // 
            // btnAllUnCheck
            // 
            this.btnAllUnCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnAllUnCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllUnCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnAllUnCheck.Image")));
            this.btnAllUnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAllUnCheck.Location = new System.Drawing.Point(128, 54);
            this.btnAllUnCheck.Name = "btnAllUnCheck";
            this.btnAllUnCheck.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnAllUnCheck.Size = new System.Drawing.Size(50, 38);
            this.btnAllUnCheck.TabIndex = 287;
            this.btnAllUnCheck.Click += new System.EventHandler(this.btnAllUnCheck_Click);
            // 
            // btnAllCheck
            // 
            this.btnAllCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnAllCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnAllCheck.Image")));
            this.btnAllCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAllCheck.Location = new System.Drawing.Point(178, 54);
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnAllCheck.Size = new System.Drawing.Size(50, 38);
            this.btnAllCheck.TabIndex = 286;
            this.btnAllCheck.Click += new System.EventHandler(this.btnAllCheck_Click);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(70, 4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(106, 20);
            this.dtpFromDate.TabIndex = 17;
            this.dtpFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFromDate_DataValidating);
            // 
            // xFlatLabel2
            // 
            this.xFlatLabel2.Location = new System.Drawing.Point(4, 4);
            this.xFlatLabel2.Name = "xFlatLabel2";
            this.xFlatLabel2.Size = new System.Drawing.Size(64, 21);
            this.xFlatLabel2.TabIndex = 20;
            this.xFlatLabel2.Text = "オーダ日付";
            this.xFlatLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.Location = new System.Drawing.Point(4, 26);
            this.xFlatLabel1.Name = "xFlatLabel1";
            this.xFlatLabel1.Size = new System.Drawing.Size(64, 21);
            this.xFlatLabel1.TabIndex = 18;
            this.xFlatLabel1.Text = "診療科";
            this.xFlatLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xBuseoCombo
            // 
            this.xBuseoCombo.IsAppendAll = true;
            this.xBuseoCombo.Location = new System.Drawing.Point(70, 26);
            this.xBuseoCombo.MaxDropDownItems = 10;
            this.xBuseoCombo.Name = "xBuseoCombo";
            this.xBuseoCombo.Size = new System.Drawing.Size(158, 21);
            this.xBuseoCombo.TabIndex = 19;
            this.xBuseoCombo.SelectedValueChanged += new System.EventHandler(this.xBuseoCombo_SelectedValueChanged);
            // 
            // layOrderJungbo
            // 
            this.layOrderJungbo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem81,
            this.multiLayoutItem82,
            this.multiLayoutItem83,
            this.multiLayoutItem84,
            this.multiLayoutItem85,
            this.multiLayoutItem86,
            this.multiLayoutItem87,
            this.multiLayoutItem88,
            this.multiLayoutItem89,
            this.multiLayoutItem90,
            this.multiLayoutItem91,
            this.multiLayoutItem92,
            this.multiLayoutItem93,
            this.multiLayoutItem94,
            this.multiLayoutItem95,
            this.multiLayoutItem96});
            // 
            // multiLayoutItem81
            // 
            this.multiLayoutItem81.DataName = "text_1";
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "text_2";
            // 
            // multiLayoutItem83
            // 
            this.multiLayoutItem83.DataName = "text_3";
            // 
            // multiLayoutItem84
            // 
            this.multiLayoutItem84.DataName = "comments";
            // 
            // multiLayoutItem85
            // 
            this.multiLayoutItem85.DataName = "bunho_comments";
            // 
            // multiLayoutItem86
            // 
            this.multiLayoutItem86.DataName = "bar_drg_bunho";
            // 
            // multiLayoutItem87
            // 
            this.multiLayoutItem87.DataName = "bar_rp_bunho";
            // 
            // multiLayoutItem88
            // 
            this.multiLayoutItem88.DataName = "cpl_1";
            // 
            // multiLayoutItem89
            // 
            this.multiLayoutItem89.DataName = "cpl_2";
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "cpl_3";
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "danui_1";
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "danui_2";
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "danui_3";
            // 
            // multiLayoutItem94
            // 
            this.multiLayoutItem94.DataName = "hl_1";
            // 
            // multiLayoutItem95
            // 
            this.multiLayoutItem95.DataName = "hl_2";
            // 
            // multiLayoutItem96
            // 
            this.multiLayoutItem96.DataName = "hl_3";
            // 
            // layOrderPrint
            // 
            this.layOrderPrint.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem34,
            this.multiLayoutItem35,
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
            this.multiLayoutItem48,
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
            this.multiLayoutItem52,
            this.multiLayoutItem53,
            this.multiLayoutItem54,
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
            this.multiLayoutItem73,
            this.multiLayoutItem74,
            this.multiLayoutItem75,
            this.multiLayoutItem76,
            this.multiLayoutItem77,
            this.multiLayoutItem78,
            this.multiLayoutItem79,
            this.multiLayoutItem80});
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "drg_bunho";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "naewon_date";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "group_ser";
            this.multiLayoutItem4.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "jubsu_date";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "order_date";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "jaeryo_code";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "nalsu";
            this.multiLayoutItem8.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "divide";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "ord_surang";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "order_suryang";
            this.multiLayoutItem11.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "order_danui";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "subul_danui";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "group_yn";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "jaeryo_gubun";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "bogyong_code";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "bogyong_name";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "caution_name";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "caution_code";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "mix_yn";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "atc_yn";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "dv";
            this.multiLayoutItem22.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "dv_time";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "dc_yn";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "bannab_yn";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "source_fkocs1003";
            this.multiLayoutItem26.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "fkocs1003";
            this.multiLayoutItem27.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "sunab_date";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "pattern";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "jaeryo_name";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "sunab_nalsu";
            this.multiLayoutItem31.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "wonyoi_yn";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "order_remark";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "act_date";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "mayak";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "tpn_joje_gubun";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "ui_jusa_yn";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "subul_suryang";
            this.multiLayoutItem38.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "serial_v";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "gwa_name";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "doctor_name";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "suname";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "suname2";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "birth";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "age";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "other_gwa";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "do_order";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "hope_nm";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "powder_yn";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "rowno";
            this.multiLayoutItem50.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "kyukyeok";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "licenes";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "bunryu1";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "mix_group";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "donbok_yn";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "tusuk";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "bigo";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "text_color";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "changgo";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "gubun_name";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "johap";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "gaein";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "gaein_no";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "bonin_gubun";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "bon_rate";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "budamja_bunho1";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "sugubja_bunho1";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "budamja_bunho2";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "sugubja_bunho2";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "sunwon_gubun";
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "noin_rate_name";
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "user_id";
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "data_gubun";
            // 
            // multiLayoutItem74
            // 
            this.multiLayoutItem74.DataName = "mayak_license";
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "mayak_doctor";
            // 
            // multiLayoutItem76
            // 
            this.multiLayoutItem76.DataName = "mayak_address1";
            // 
            // multiLayoutItem77
            // 
            this.multiLayoutItem77.DataName = "mayak_address2";
            // 
            // multiLayoutItem78
            // 
            this.multiLayoutItem78.DataName = "gigan_date";
            // 
            // multiLayoutItem79
            // 
            this.multiLayoutItem79.DataName = "hubal_change_yn";
            // 
            // multiLayoutItem80
            // 
            this.multiLayoutItem80.DataName = "hubal_all_yn";
            // 
            // FrmBatJubsu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(378, 754);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Name = "FrmBatJubsu";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "処方箋発行";
            this.Controls.SetChildIndex(this.xPanel3, 0);
            this.Controls.SetChildIndex(this.xPanel2, 0);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaid)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xBuseoCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderJungbo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layAntiData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (EnvironInfo.CurrSystemID == "AKUS")
            {
                xBuseoCombo.SetDataValue("05");
                xBuseoCombo.Enabled = false;
            }

            dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());

            PaQuery();
        }
        #endregion

        #region
        private void PaQuery()
        {
            grdPaid.SetBindVarValue("f_gubun", "1");
            grdPaid.SetBindVarValue("f_wonyoi_yn", "N");

            if (!grdPaid.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }
        #endregion

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            for (int i = 0; i < grdPaid.RowCount; i++)
            {
                if (grdPaid.GetItemString(i, "chk") == "Y")
                {
                    // 접수
                    inputList.Clear();
                    outputList.Clear();
                    inputList.Add(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    inputList.Add(UserInfo.UserID);
                    inputList.Add(grdPaid.GetItemString(i, "order_date"));
                    inputList.Add(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    inputList.Add(grdPaid.GetItemString(i, "drg_bunho"));
                    inputList.Add("N");
                    inputList.Add("Y");
                    inputList.Add("");

                    if (Service.ExecuteProcedure("PR_DRG_MAKE_BONGTU_OUT", inputList, outputList))
                    {
                        #region 처방전 출력
                        if (chbOrderPrint.Checked)
                        {
                            int row;

                            dw1.Reset();
                            layOrderPrint.Reset();
                            layOrderJungbo.Reset();

                            // 처방 내용
                            if (DsvOrderPrint(grdPaid.GetItemString(i, "order_date"), grdPaid.GetItemString(i, "drg_bunho")))
                            {
                                row = layOrderPrint.RowCount;
                                //2011.10.05 yklee
                                dw1.FillChildData("dw_1", layOrderPrint.LayoutTable);
                                //dw1.FillData(layOrderPrint.LayoutTable);
                            }

                            //// 코멘트 내용
                            if (DsvOrderJungbo(grdPaid.GetItemString(i, "order_date"), grdPaid.GetItemString(i, "drg_bunho")))
                            {
                                row = layOrderJungbo.RowCount;
                                dw1.FillChildData("dw_2", layOrderJungbo.LayoutTable);
                            }

                            dw1.AcceptText();

                            dw1.Print();
                        }
                        #endregion

                        #region 복약지도문 전송
                        if (chbDataInterface.Checked)
                        {
                            //DsvAtcSend(grdPaid.GetItemString(i, "order_date"), grdPaid.GetItemString(i, "drg_bunho"), "O");
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show(Service.ErrMsg);
                    }
                }
            }

            PaQuery();
        }

        #region [-- DsvOrderPrint --]
        /// <summary>
        /// dsvOrderPrint Service Conversion PC:DRGPRINCOM, WT:4
        /// </summary>
        /// <param name="orderDate"></param>
        /// <param name="drgBunho"></param>
        /// <returns></returns>
        private bool DsvOrderPrint(string jubsuDate, string drgBunho)
        {
            string o_bunho = string.Empty;
            string o_drg_bunho = string.Empty;
            string o_naewon_date = string.Empty;
            string o_group_ser = string.Empty;
            string o_jubsu_date = string.Empty;
            string o_order_date = string.Empty;
            string o_jaeryo_code = string.Empty;
            string o_nalsu = string.Empty;
            string o_divide = string.Empty;
            string o_ord_suryang = string.Empty;
            string o_order_suryang = string.Empty;
            string o_order_danui = string.Empty;
            string o_subul_danui = string.Empty;
            string o_group_yn = string.Empty;
            string o_jaeryo_gubun = string.Empty;
            string o_bogyong_code = string.Empty;
            string o_bogyong_name = string.Empty;
            string o_caution_name = string.Empty;
            string o_caution_code = string.Empty;
            string o_mix_yn = string.Empty;
            string o_atc_yn = string.Empty;
            string o_dv = string.Empty;
            string o_dv_time = string.Empty;
            string o_dc_yn = string.Empty;
            string o_bannab_yn = string.Empty;
            string o_source_fkocs1003 = string.Empty;
            string o_fkocs1003 = string.Empty;
            string o_sunab_date = string.Empty;
            string o_pattern = string.Empty;
            string o_jaeryo_name = string.Empty;
            string o_sunab_nalsu = string.Empty;
            string o_wonyoi_yn = string.Empty;
            string o_order_remark = string.Empty;
            string o_act_date = string.Empty;
            string o_mayak = string.Empty;
            string o_tpn_joje_gubun = string.Empty;
            string o_ui_jusa_yn = string.Empty;
            string o_subul_suryang = string.Empty;
            string o_serial_v = string.Empty;
            string o_gwa_name = string.Empty;
            string o_doctor_name = string.Empty;
            string o_suname = string.Empty;
            string o_suname2 = string.Empty;
            string o_birth = string.Empty;
            string o_age_sex = string.Empty;
            string o_other_gwa = string.Empty;
            string o_do_order = string.Empty;
            string o_hope_nm = string.Empty;
            string o_powder_yn = string.Empty;
            string o_line = string.Empty;
            string o_serial_cnt = string.Empty;
            string o_kyukyeok = string.Empty;
            string o_licenes = string.Empty;
            string o_bunryu1 = string.Empty;
            string o_mix_group = string.Empty;
            string o_donbok = string.Empty;
            string o_tusuk = string.Empty;
            string o_bigo = string.Empty;
            string o_key = string.Empty;
            string o_text_color = string.Empty;

            string o_gubun_name = string.Empty;
            string o_johap = string.Empty;
            string o_gaein = string.Empty;
            string o_gaein_no = string.Empty;
            string o_bonin_gubun = string.Empty;
            string o_bon_rate = string.Empty;
            string o_budamja_bunho1 = string.Empty;
            string o_sugubja_bunho1 = string.Empty;
            string o_budamja_bunho2 = string.Empty;
            string o_sugubja_bunho2 = string.Empty;
            string o_sunwon_gubun = string.Empty;
            string o_noin_rate_name = string.Empty;
            string o_err = string.Empty;

            string o_changgo = string.Empty;
            string o_serial_text = string.Empty;
            string o_data_gubun = string.Empty;

            string o_mayak_license = string.Empty;
            string o_mayak_doctor = string.Empty;
            string o_mayak_address1 = string.Empty;
            string o_mayak_address2 = string.Empty;

            string o_jigan_date = string.Empty;
            string o_hubal_change_yn = string.Empty;
            string o_hubal_all_yn = string.Empty;

            string q_user_id = UserInfo.UserID;

            string cmdText = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);

            DataTable dtPrinco = new DataTable();
            DataTable dtSerial = new DataTable();
            DataTable dtRemark = new DataTable();

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            int rowNum = 0;
            int r_rec_cnt = 0;

            cmdText = @"SELECT MIN(FKOCS1003) FKOCS1003
                          FROM DRG2010 A
                         WHERE A.ORDER_DATE       = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                           AND A.DRG_BUNHO        = :f_drg_bunho
                           AND A.SOURCE_FKOCS1003 IS NULL
                           AND NVL(A.DC_YN,'N')           = 'N'
                           AND NVL(A.BANNAB_YN,'N')       = 'N'
                           AND A.JUNDAL_PART              = 'PA'";
            try
            {
                if (Service.ExecuteScalar(cmdText, bindVars) != null)
                    o_fkocs1003 = Service.ExecuteScalar(cmdText, bindVars).ToString();

                inputList.Add(o_fkocs1003);
                if (Service.ExecuteProcedure("PR_OUT_LOAD_CHEBANG_PRINT", inputList, outputList))
                {
                    o_gubun_name = outputList[0].ToString();
                    o_johap = outputList[1].ToString();
                    o_gaein = outputList[2].ToString();
                    o_gaein_no = outputList[3].ToString();
                    o_bonin_gubun = outputList[4].ToString();
                    o_bon_rate = outputList[5].ToString();
                    o_budamja_bunho1 = outputList[6].ToString();
                    o_sugubja_bunho1 = outputList[7].ToString();
                    o_budamja_bunho2 = outputList[8].ToString();
                    o_sugubja_bunho2 = outputList[9].ToString();
                    o_sunwon_gubun = outputList[10].ToString();
                    o_noin_rate_name = outputList[11].ToString();
                }

                inputList.Clear();
                outputList.Clear();
                inputList.Add("O");
                inputList.Add(jubsuDate.ToString());
                inputList.Add(drgBunho);

                if (Service.ExecuteProcedure("PR_DRG_LOAD_MAKAY_JUNGBO", inputList, outputList))
                {
                    o_mayak_doctor = outputList[0].ToString();
                    o_mayak_license = outputList[1].ToString();
                    o_mayak_address1 = outputList[2].ToString();
                    o_mayak_address2 = outputList[3].ToString();
                }

                cmdText = @"SELECT DISTINCT
                                   A.BUNHO                                                                      BUNHO
                                 , LTRIM(TO_CHAR(A.DRG_BUNHO))                                                  DRG_BUNHO
                                 , FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.NAEWON_DATE )                            NAEWON_DATE
                                 , TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD')                                           JUBSU_DATE
                                 , FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE)                              ORDER_DATE
                                 , 'Rp.'||E.SERIAL_V||DECODE(A.MIX_GROUP,NULL,'',' M')                           SERIAL_V
                                 , E.SERIAL_V                                                                   SERIAL_TEXT
                                 , FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                    GWA_NAME
                                 , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                              DOCTOR_NAME
                                 , F.SUNAME                                                                     SUNAME
                                 , F.SUNAME2                                                                    SUNAME2
                                 , FN_BAS_TO_JAPAN_DATE_CONVERT('1', F.BIRTH )                                  BIRTH
                                 , F.SEX                                                                        SEX_AGE
                                 , FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.NAEWON_DATE, A.GWA)                 OTHER_GWA
                                 , FN_DRG_DO_ORDER(A.BUNHO, A.NAEWON_DATE, A.GWA, A.DOCTOR, 'O', A.DRG_BUNHO)   DO_ORDER    
                                 , FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.NAEWON_DATE + 3 )                        GIGAM_DATE
                              FROM OUT0101 F
                                 , DRG2030 E
                                 , OCS1003 D
                                 , INV0110 C
                                 , DRG0120 B
                                 , DRG2010 A
                             WHERE A.ORDER_DATE               = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                               AND A.DRG_BUNHO                = :f_drg_bunho
                               AND A.SOURCE_FKOCS1003         IS NULL
                               AND NVL(A.DC_YN,'N')           = 'N'
                               AND NVL(A.BANNAB_YN,'N')       = 'N'
                               AND NVL(A.WONYOI_ORDER_YN,'N') = 'N'
                               AND A.JUNDAL_PART              = 'PA'
                               AND B.BOGYONG_CODE          (+)= A.BOGYONG_CODE
                               AND C.JAERYO_CODE           (+)= A.JAERYO_CODE
                               AND D.PKOCS1003                = A.FKOCS1003
                               AND E.JUBSU_DATE               = A.ORDER_DATE
                               AND E.DRG_BUNHO                = A.DRG_BUNHO
                               AND E.FKOCS1003                = A.FKOCS1003
                               AND F.BUNHO                    = A.BUNHO
                             ORDER BY 6";
                dtPrinco = Service.ExecuteDataTable(cmdText, bindVars);

                for (int i = 0; i < dtPrinco.Rows.Count; i++)
                {
                    o_bunho = dtPrinco.Rows[i]["bunho"].ToString();
                    o_drg_bunho = dtPrinco.Rows[i]["drg_bunho"].ToString();
                    o_naewon_date = dtPrinco.Rows[i]["naewon_date"].ToString();
                    o_jubsu_date = dtPrinco.Rows[i]["jubsu_date"].ToString();
                    o_order_date = dtPrinco.Rows[i]["order_date"].ToString();
                    o_serial_v = dtPrinco.Rows[i]["serial_v"].ToString();
                    o_serial_text = dtPrinco.Rows[i]["serial_text"].ToString();
                    o_gwa_name = dtPrinco.Rows[i]["gwa_name"].ToString();
                    o_doctor_name = dtPrinco.Rows[i]["doctor_name"].ToString();
                    o_suname = dtPrinco.Rows[i]["suname"].ToString();
                    o_suname2 = dtPrinco.Rows[i]["suname2"].ToString();
                    o_birth = dtPrinco.Rows[i]["birth"].ToString();
                    o_age_sex = dtPrinco.Rows[i]["sex_age"].ToString();
                    o_other_gwa = dtPrinco.Rows[i]["other_gwa"].ToString();
                    o_do_order = dtPrinco.Rows[i]["do_order"].ToString();
                    o_jigan_date = dtPrinco.Rows[i]["gigam_date"].ToString();

                    // DRG510001_WN_SERIAL_QRY 에 새로운 바인드 변수 삭제/추가
                    bindVars.Remove("o_serial_text");
                    bindVars.Add("o_serial_text", o_serial_text);

                    /* DRG510001_WN_SERIAL_QRY */
                    cmdText = @"SELECT DISTINCT
                                       A.GROUP_SER                                                                                       GROUP_SER
                                      ,A.JAERYO_CODE                                                                                     JAERYO_CODE
                                      ,DECODE(A.BUNRYU1,'6',0,DECODE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) , 'Y', A.DV,A.NALSU))         NALSU
                                      ,A.DIVIDE                                                                                          DIVIDE
                                      ,A.ORD_SURYANG                                                                                     DRG_ORDER_SURYANG
                                      ,A.ORDER_SURYANG                                                                                   ORDER_SURYANG
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI)                                                   DRG_ORDER_DANUI
                                      ,A.SUBUL_DANUI                                                                                     SUBUL_DANUI
                                      ,A.GROUP_YN                                                                                        GROUP_YN
                                      ,A.JAERYO_GUBUN                                                                                    JAERYO_GUBUN
                                      ,A.BOGYONG_CODE                                                                                    BOGYONG_CODE
                                      ,TRIM(DECODE(A.BUNRYU1,'4', FN_DRG_LOAD_REMARK( E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O'),
                                                             '6', FN_DRG_LOAD_REMARK( E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O') ))
                                       ||' '|| TRIM(B.BOGYONG_NAME) || FN_DRG_LOAD_RP_TEXT('O', E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V)   BOGYONG_NAME
                                      ,''                                                                                                CAUTION_NAME
                                      ,A.CAUTION_CODE                                                                                    CAUTION_CODE
                                      ,A.MIX_YN                                                                                          MIX_YN
                                      ,E.ATC_YN                                                                                          ATC_YN
                                      ,A.DV                                                                                              DV
                                      ,A.DV_TIME                                                                                         DV_TIME
                                      ,A.DC_YN                                                                                           DC_YN
                                      ,A.BANNAB_YN                                                                                       BANNAB_YN
                                      ,A.SOURCE_FKOCS1003                                                                                SOURCE_FKOCS1003
                                      ,A.FKOCS1003                                                                                       FKOCS1003
                                      ,TO_CHAR(A.SUNAB_DATE,'YYYY/MM/DD')                                                                SUNAB_DATE
                                      ,B.PATTERN                                                                                         PATTERN
                                      ,C.JAERYO_NAME                                                                                     JAERYO_NAME
                                      ,NVL(A.SUNAB_NALSU,0)                                                                              SUNAB_NALSU
                                      ,NVL(A.WONYOI_ORDER_YN,'N')                                                                        WONYOI_YN
                                      ,TO_CHAR(A.ACT_DATE,'YYYY/MM/DD')                                                                  ACT_DATE
                                      ,A.BUNRYU2                                                                                         MAYAK
                                      ,A.TPN_JOJE_GUBUN                                                                                  TPN_JOJE_GUBUN
                                      ,NVL(C.MIX_YN_INP,'N')                                                                             UI_JUSA_YN
                                      ,A.SUBUL_SURYANG                                                                                   SUBUL_SURYANG
                                      ,'Rp.'||E.SERIAL_V||DECODE(A.MIX_GROUP,NULL,'',' M')                                                SERIAL_V
                                      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                                         GWA_NAME
                                      ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                                                   DOCTOR_NAME
                                      ,F.SUNAME                                                                                          SUNAME
                                      ,F.SUNAME2                                                                                         SUNAME2
                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', F.BIRTH )                                                       BIRTH
                                      ,F.SEX                                                                                             SEX_AGE
                                      ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.NAEWON_DATE, A.GWA)                                      OTHER_GWA
                                      ,FN_DRG_DO_ORDER(A.BUNHO, A.NAEWON_DATE, A.GWA, A.DOCTOR, 'O', A.DRG_BUNHO)                        DO_ORDER
                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('5', D.HOPE_DATE )                                                   HOPE_DATE
                                      ,FN_DRG_POWDER_YN(E.JUBSU_DATE, E.DRG_BUNHO, 'O')                                                  POWDER_YN
                                      ,E.SERIAL_V                                                                                        LINE
                                      ,TRIM(C.KYUKYEOK)                                                                                  KYUKYEOK
                                      ,DECODE(FN_DRG_MAYAK_CHK(A.JUBSU_DATE, A.DRG_BUNHO, 'O'), 'Y',
                                              SUBSTRB(TRIM(FN_DRG_DOCTOR_LICENSE(A.DOCTOR, TRUNC(SYSDATE),'Y')),1,20))                   LICENSE
                                      ,A.MIX_GROUP                                                                                       MIX_GROUP
                                      ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                                             DONBOK
                                      ,FN_AKU_LOAD_TUSUK_YOIL(A.BUNHO, A.ORDER_DATE)                                                     TUSUK
                                      ,FN_DRG_LOAD_CAUTION_NM(E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O' ,'2')                           CAUTION_NM
                                      ,FN_OCS_LOAD_ORDER_SORT('O', D.INPUT_GUBUN, D.ORDER_GUBUN, D.GROUP_SER,
                                                                   D.MIX_GROUP,   D.SEQ,         D.PKOCS1003)                            ORDER_SORT
                                      ,C.TEXT_COLOR                                                                                      TEXT_COLOR
                                      ,C.CHANGGO1                                                                                        CHANGGO
                                      ,A.HUBAL_CHANGE_YN                                                                                 HUBAL_CHANGE_YN
                                      ,FN_DRG_LOAD_HUBAL_ALL(A.ORDER_DATE, A.DRG_BUNHO)                                                  HUBAL_ALL_YN
                                  FROM OUT0101 F
                                      ,DRG2030 E
                                      ,OCS1003 D
                                      ,INV0110 C
                                      ,DRG0120 B
                                      ,DRG2010 A
                                 WHERE A.ORDER_DATE               = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                                   AND A.DRG_BUNHO                = :f_drg_bunho
                                   AND A.SOURCE_FKOCS1003         IS NULL
                                   AND NVL(A.DC_YN,'N')           = 'N'
                                   AND NVL(A.BANNAB_YN,'N')       = 'N'
                                   AND A.JUNDAL_PART              = 'PA'
                                   AND B.BOGYONG_CODE          (+)= A.BOGYONG_CODE
                                   AND C.JAERYO_CODE           (+)= A.JAERYO_CODE
                                   AND D.PKOCS1003                = A.FKOCS1003
                                   AND E.JUBSU_DATE               = A.ORDER_DATE
                                   AND E.DRG_BUNHO                = A.DRG_BUNHO
                                   AND E.FKOCS1003                = A.FKOCS1003
                                   AND E.SERIAL_V                 = :o_serial_text
                                   AND F.BUNHO                    = A.BUNHO
                                 ORDER BY E.SERIAL_V, A.MIX_GROUP, A.FKOCS1003";

                    dtSerial = Service.ExecuteDataTable(cmdText, bindVars);

                    for (int j = 0; j < dtSerial.Rows.Count; j++)
                    {
                        o_group_ser = dtSerial.Rows[j]["group_ser"].ToString();
                        o_jaeryo_code = dtSerial.Rows[j]["jaeryo_code"].ToString();
                        o_nalsu = dtSerial.Rows[j]["nalsu"].ToString();
                        o_divide = dtSerial.Rows[j]["divide"].ToString();
                        o_ord_suryang = dtSerial.Rows[j]["drg_order_suryang"].ToString();
                        o_order_suryang = dtSerial.Rows[j]["order_suryang"].ToString();
                        o_order_danui = dtSerial.Rows[j]["drg_order_danui"].ToString();
                        o_subul_danui = dtSerial.Rows[j]["subul_danui"].ToString();
                        o_group_yn = dtSerial.Rows[j]["group_yn"].ToString();
                        o_jaeryo_gubun = dtSerial.Rows[j]["jaeryo_gubun"].ToString();
                        o_bogyong_code = dtSerial.Rows[j]["bogyong_code"].ToString();
                        o_bogyong_name = dtSerial.Rows[j]["bogyong_name"].ToString();
                        o_caution_name = dtSerial.Rows[j]["caution_name"].ToString();
                        o_caution_code = dtSerial.Rows[j]["caution_code"].ToString();
                        o_mix_yn = dtSerial.Rows[j]["mix_yn"].ToString();
                        o_atc_yn = dtSerial.Rows[j]["atc_yn"].ToString();
                        o_dv = dtSerial.Rows[j]["dv"].ToString();
                        o_dv_time = dtSerial.Rows[j]["dv_time"].ToString();
                        o_dc_yn = dtSerial.Rows[j]["dc_yn"].ToString();
                        o_bannab_yn = dtSerial.Rows[j]["bannab_yn"].ToString();
                        o_source_fkocs1003 = dtSerial.Rows[j]["source_fkocs1003"].ToString();
                        o_fkocs1003 = dtSerial.Rows[j]["fkocs1003"].ToString();
                        o_sunab_date = dtSerial.Rows[j]["sunab_date"].ToString();
                        o_pattern = dtSerial.Rows[j]["pattern"].ToString();
                        o_jaeryo_name = dtSerial.Rows[j]["jaeryo_name"].ToString();
                        o_sunab_nalsu = dtSerial.Rows[j]["sunab_nalsu"].ToString();
                        o_wonyoi_yn = dtSerial.Rows[j]["wonyoi_yn"].ToString();
                        o_act_date = dtSerial.Rows[j]["act_date"].ToString();
                        o_mayak = dtSerial.Rows[j]["mayak"].ToString();
                        o_tpn_joje_gubun = dtSerial.Rows[j]["tpn_joje_gubun"].ToString();
                        o_ui_jusa_yn = dtSerial.Rows[j]["ui_jusa_yn"].ToString();
                        o_subul_suryang = dtSerial.Rows[j]["subul_suryang"].ToString();
                        o_serial_v = dtSerial.Rows[j]["serial_v"].ToString();
                        o_gwa_name = dtSerial.Rows[j]["gwa_name"].ToString();
                        o_doctor_name = dtSerial.Rows[j]["doctor_name"].ToString();
                        o_suname = dtSerial.Rows[j]["suname"].ToString();
                        o_suname2 = dtSerial.Rows[j]["suname2"].ToString();
                        o_birth = dtSerial.Rows[j]["birth"].ToString();
                        o_age_sex = dtSerial.Rows[j]["sex_age"].ToString();
                        o_other_gwa = dtSerial.Rows[j]["other_gwa"].ToString();
                        o_do_order = dtSerial.Rows[j]["do_order"].ToString();
                        o_hope_nm = dtSerial.Rows[j]["hope_date"].ToString();
                        o_powder_yn = dtSerial.Rows[j]["powder_yn"].ToString();
                        o_serial_cnt = dtSerial.Rows[j]["line"].ToString();
                        o_kyukyeok = dtSerial.Rows[j]["kyukyeok"].ToString();
                        o_licenes = dtSerial.Rows[j]["license"].ToString();
                        o_mix_group = dtSerial.Rows[j]["mix_group"].ToString();
                        o_donbok = dtSerial.Rows[j]["donbok"].ToString();
                        o_tusuk = dtSerial.Rows[j]["tusuk"].ToString();
                        o_bigo = dtSerial.Rows[j]["caution_nm"].ToString();
                        o_key = dtSerial.Rows[j]["order_sort"].ToString();
                        o_text_color = dtSerial.Rows[j]["text_color"].ToString();
                        o_changgo = dtSerial.Rows[j]["changgo"].ToString();
                        o_hubal_change_yn = dtSerial.Rows[j]["hubal_change_yn"].ToString();
                        o_hubal_all_yn = dtSerial.Rows[j]["hubal_all_yn"].ToString();

                        rowNum = layOrderPrint.InsertRow(-1);
                        r_rec_cnt = r_rec_cnt++;

                        layOrderPrint.SetItemValue(rowNum, "bunho", o_bunho);
                        layOrderPrint.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                        layOrderPrint.SetItemValue(rowNum, "naewon_date", o_naewon_date);
                        layOrderPrint.SetItemValue(rowNum, "group_ser", o_group_ser);
                        layOrderPrint.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                        layOrderPrint.SetItemValue(rowNum, "order_date", o_order_date);
                        layOrderPrint.SetItemValue(rowNum, "jaeryo_code", o_jaeryo_code);
                        layOrderPrint.SetItemValue(rowNum, "nalsu", o_nalsu);
                        layOrderPrint.SetItemValue(rowNum, "divide", o_divide);
                        layOrderPrint.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                        layOrderPrint.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                        layOrderPrint.SetItemValue(rowNum, "order_danui", o_order_danui);
                        layOrderPrint.SetItemValue(rowNum, "subul_danui", o_subul_danui);
                        layOrderPrint.SetItemValue(rowNum, "group_yn", o_group_yn);
                        layOrderPrint.SetItemValue(rowNum, "jaeryo_gubun", o_jaeryo_gubun);
                        layOrderPrint.SetItemValue(rowNum, "bogyong_code", o_bogyong_code);
                        layOrderPrint.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                        layOrderPrint.SetItemValue(rowNum, "caution_name", o_caution_name);
                        layOrderPrint.SetItemValue(rowNum, "caution_code", o_caution_code);
                        layOrderPrint.SetItemValue(rowNum, "mix_yn", o_mix_yn);
                        layOrderPrint.SetItemValue(rowNum, "atc_yn", o_atc_yn);
                        layOrderPrint.SetItemValue(rowNum, "dv", o_dv);
                        layOrderPrint.SetItemValue(rowNum, "dv_time", o_dv_time);
                        layOrderPrint.SetItemValue(rowNum, "dc_yn", o_dc_yn);
                        layOrderPrint.SetItemValue(rowNum, "bannab_yn", o_bannab_yn);
                        layOrderPrint.SetItemValue(rowNum, "source_fkocs1003", o_source_fkocs1003);
                        layOrderPrint.SetItemValue(rowNum, "fkocs1003", o_fkocs1003);
                        layOrderPrint.SetItemValue(rowNum, "sunab_date", o_sunab_date);
                        layOrderPrint.SetItemValue(rowNum, "pattern", o_pattern);
                        layOrderPrint.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                        layOrderPrint.SetItemValue(rowNum, "sunab_nalsu", o_sunab_nalsu);
                        layOrderPrint.SetItemValue(rowNum, "wonyoi_yn", o_wonyoi_yn);
                        layOrderPrint.SetItemValue(rowNum, "order_remark", o_order_remark);
                        layOrderPrint.SetItemValue(rowNum, "act_date", o_act_date);
                        layOrderPrint.SetItemValue(rowNum, "mayak", o_mayak);
                        layOrderPrint.SetItemValue(rowNum, "tpn_joje_gubun", o_tpn_joje_gubun);
                        layOrderPrint.SetItemValue(rowNum, "ui_jusa_yn", o_ui_jusa_yn);
                        layOrderPrint.SetItemValue(rowNum, "subul_suryang", o_subul_suryang);
                        layOrderPrint.SetItemValue(rowNum, "serial_v", o_serial_v);
                        layOrderPrint.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                        layOrderPrint.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                        layOrderPrint.SetItemValue(rowNum, "suname", o_suname);
                        layOrderPrint.SetItemValue(rowNum, "suname2", o_suname2);
                        layOrderPrint.SetItemValue(rowNum, "birth", o_birth);
                        layOrderPrint.SetItemValue(rowNum, "age", o_age_sex);
                        layOrderPrint.SetItemValue(rowNum, "other_gwa", o_other_gwa);
                        layOrderPrint.SetItemValue(rowNum, "do_order", o_do_order);
                        layOrderPrint.SetItemValue(rowNum, "hope_nm", o_hope_nm);
                        layOrderPrint.SetItemValue(rowNum, "powder_yn", o_powder_yn);
                        layOrderPrint.SetItemValue(rowNum, "rowno", o_line);
                        layOrderPrint.SetItemValue(rowNum, "kyukyeok", o_kyukyeok);
                        layOrderPrint.SetItemValue(rowNum, "licenes", o_licenes);
                        layOrderPrint.SetItemValue(rowNum, "bunryu1", o_bunryu1);
                        layOrderPrint.SetItemValue(rowNum, "mix_group", o_mix_group);
                        layOrderPrint.SetItemValue(rowNum, "donbok_yn", o_donbok);
                        layOrderPrint.SetItemValue(rowNum, "tusuk", o_tusuk);
                        layOrderPrint.SetItemValue(rowNum, "bigo", o_bigo);
                        layOrderPrint.SetItemValue(rowNum, "text_color", o_text_color);
                        layOrderPrint.SetItemValue(rowNum, "changgo", o_changgo);
                        layOrderPrint.SetItemValue(rowNum, "gubun_name", o_gubun_name);
                        layOrderPrint.SetItemValue(rowNum, "johap", o_johap);
                        layOrderPrint.SetItemValue(rowNum, "gaein", o_gaein);
                        layOrderPrint.SetItemValue(rowNum, "gaein_no", o_gaein_no);
                        layOrderPrint.SetItemValue(rowNum, "bonin_gubun", o_bonin_gubun);
                        layOrderPrint.SetItemValue(rowNum, "bon_rate", o_bon_rate);
                        layOrderPrint.SetItemValue(rowNum, "budamja_bunho1", o_budamja_bunho1);
                        layOrderPrint.SetItemValue(rowNum, "sugubja_bunho1", o_sugubja_bunho1);
                        layOrderPrint.SetItemValue(rowNum, "budamja_bunho2", o_budamja_bunho2);
                        layOrderPrint.SetItemValue(rowNum, "sugubja_bunho2", o_sugubja_bunho2);
                        layOrderPrint.SetItemValue(rowNum, "sunwon_gubun", o_sunwon_gubun);
                        layOrderPrint.SetItemValue(rowNum, "noin_rate_name", o_noin_rate_name);
                        layOrderPrint.SetItemValue(rowNum, "user_id", q_user_id);
                        layOrderPrint.SetItemValue(rowNum, "data_gubun", "A");
                        layOrderPrint.SetItemValue(rowNum, "mayak_license", o_mayak_license);
                        layOrderPrint.SetItemValue(rowNum, "mayak_doctor", o_mayak_doctor);
                        layOrderPrint.SetItemValue(rowNum, "mayak_address1", o_mayak_address1);
                        layOrderPrint.SetItemValue(rowNum, "mayak_address2", o_mayak_address2);
                        layOrderPrint.SetItemValue(rowNum, "gigan_date", o_jigan_date);
                        layOrderPrint.SetItemValue(rowNum, "hubal_change_yn", o_hubal_change_yn);
                        layOrderPrint.SetItemValue(rowNum, "hubal_all_yn", o_hubal_all_yn);
                    }
                    /* 복용법 */
                    /* order 순서 다시 sort*/
                    rowNum = layOrderPrint.InsertRow(-1);
                    r_rec_cnt = r_rec_cnt++;

                    layOrderPrint.SetItemValue(rowNum, "bunho", o_bunho);
                    layOrderPrint.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                    layOrderPrint.SetItemValue(rowNum, "naewon_date", o_naewon_date);
                    layOrderPrint.SetItemValue(rowNum, "group_ser", o_group_ser);
                    layOrderPrint.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                    layOrderPrint.SetItemValue(rowNum, "order_date", o_order_date);
                    layOrderPrint.SetItemValue(rowNum, "jaeryo_code", o_jaeryo_code);
                    layOrderPrint.SetItemValue(rowNum, "nalsu", o_nalsu);
                    layOrderPrint.SetItemValue(rowNum, "divide", o_divide);
                    layOrderPrint.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                    layOrderPrint.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                    layOrderPrint.SetItemValue(rowNum, "order_danui", o_order_danui);
                    layOrderPrint.SetItemValue(rowNum, "subul_danui", o_subul_danui);
                    layOrderPrint.SetItemValue(rowNum, "group_yn", o_group_yn);
                    layOrderPrint.SetItemValue(rowNum, "jaeryo_gubun", o_jaeryo_gubun);
                    layOrderPrint.SetItemValue(rowNum, "bogyong_code", o_bogyong_code);
                    layOrderPrint.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                    layOrderPrint.SetItemValue(rowNum, "caution_name", o_caution_name);
                    layOrderPrint.SetItemValue(rowNum, "caution_code", o_caution_code);
                    layOrderPrint.SetItemValue(rowNum, "mix_yn", o_mix_yn);
                    layOrderPrint.SetItemValue(rowNum, "atc_yn", o_atc_yn);
                    layOrderPrint.SetItemValue(rowNum, "dv", o_dv);
                    layOrderPrint.SetItemValue(rowNum, "dv_time", o_dv_time);
                    layOrderPrint.SetItemValue(rowNum, "dc_yn", o_dc_yn);
                    layOrderPrint.SetItemValue(rowNum, "bannab_yn", o_bannab_yn);
                    layOrderPrint.SetItemValue(rowNum, "source_fkocs1003", o_source_fkocs1003);
                    layOrderPrint.SetItemValue(rowNum, "fkocs1003", o_fkocs1003);
                    layOrderPrint.SetItemValue(rowNum, "sunab_date", o_sunab_date);
                    layOrderPrint.SetItemValue(rowNum, "pattern", o_pattern);
                    layOrderPrint.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                    layOrderPrint.SetItemValue(rowNum, "sunab_nalsu", o_sunab_nalsu);
                    layOrderPrint.SetItemValue(rowNum, "wonyoi_yn", o_wonyoi_yn);
                    layOrderPrint.SetItemValue(rowNum, "order_remark", o_order_remark);
                    layOrderPrint.SetItemValue(rowNum, "act_date", o_act_date);
                    layOrderPrint.SetItemValue(rowNum, "mayak", o_mayak);
                    layOrderPrint.SetItemValue(rowNum, "tpn_joje_gubun", o_tpn_joje_gubun);
                    layOrderPrint.SetItemValue(rowNum, "ui_jusa_yn", o_ui_jusa_yn);
                    layOrderPrint.SetItemValue(rowNum, "subul_suryang", o_subul_suryang);
                    layOrderPrint.SetItemValue(rowNum, "serial_v", o_serial_v);
                    layOrderPrint.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                    layOrderPrint.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                    layOrderPrint.SetItemValue(rowNum, "suname", o_suname);
                    layOrderPrint.SetItemValue(rowNum, "suname2", o_suname2);
                    layOrderPrint.SetItemValue(rowNum, "birth", o_birth);
                    layOrderPrint.SetItemValue(rowNum, "age", o_age_sex);
                    layOrderPrint.SetItemValue(rowNum, "other_gwa", o_other_gwa);
                    layOrderPrint.SetItemValue(rowNum, "do_order", o_do_order);
                    layOrderPrint.SetItemValue(rowNum, "hope_nm", o_hope_nm);
                    layOrderPrint.SetItemValue(rowNum, "powder_yn", o_powder_yn);
                    layOrderPrint.SetItemValue(rowNum, "rowno", o_line);
                    layOrderPrint.SetItemValue(rowNum, "kyukyeok", o_kyukyeok);
                    layOrderPrint.SetItemValue(rowNum, "licenes", o_licenes);
                    layOrderPrint.SetItemValue(rowNum, "bunryu1", o_bunryu1);
                    layOrderPrint.SetItemValue(rowNum, "mix_group", o_mix_group);
                    layOrderPrint.SetItemValue(rowNum, "donbok_yn", o_donbok);
                    layOrderPrint.SetItemValue(rowNum, "tusuk", o_tusuk);
                    layOrderPrint.SetItemValue(rowNum, "bigo", o_bigo);
                    layOrderPrint.SetItemValue(rowNum, "text_color", o_text_color);
                    layOrderPrint.SetItemValue(rowNum, "changgo", o_changgo);
                    layOrderPrint.SetItemValue(rowNum, "gubun_name", o_gubun_name);
                    layOrderPrint.SetItemValue(rowNum, "johap", o_johap);
                    layOrderPrint.SetItemValue(rowNum, "gaein", o_gaein);
                    layOrderPrint.SetItemValue(rowNum, "gaein_no", o_gaein_no);
                    layOrderPrint.SetItemValue(rowNum, "bonin_gubun", o_bonin_gubun);
                    layOrderPrint.SetItemValue(rowNum, "bon_rate", o_bon_rate);
                    layOrderPrint.SetItemValue(rowNum, "budamja_bunho1", o_budamja_bunho1);
                    layOrderPrint.SetItemValue(rowNum, "sugubja_bunho1", o_sugubja_bunho1);
                    layOrderPrint.SetItemValue(rowNum, "budamja_bunho2", o_budamja_bunho2);
                    layOrderPrint.SetItemValue(rowNum, "sugubja_bunho2", o_sugubja_bunho2);
                    layOrderPrint.SetItemValue(rowNum, "sunwon_gubun", o_sunwon_gubun);
                    layOrderPrint.SetItemValue(rowNum, "noin_rate_name", o_noin_rate_name);
                    layOrderPrint.SetItemValue(rowNum, "user_id", q_user_id);
                    layOrderPrint.SetItemValue(rowNum, "data_gubun", "B");
                    layOrderPrint.SetItemValue(rowNum, "mayak_license", o_mayak_license);
                    layOrderPrint.SetItemValue(rowNum, "mayak_doctor", o_mayak_doctor);
                    layOrderPrint.SetItemValue(rowNum, "mayak_address1", o_mayak_address1);
                    layOrderPrint.SetItemValue(rowNum, "mayak_address2", o_mayak_address2);
                    layOrderPrint.SetItemValue(rowNum, "gigan_date", o_jigan_date);
                    layOrderPrint.SetItemValue(rowNum, "hubal_change_yn", o_hubal_change_yn);
                    layOrderPrint.SetItemValue(rowNum, "hubal_all_yn", o_hubal_all_yn);

                    cmdText = @"SELECT DISTINCT
                                       A.GROUP_SER                                                                                    GROUP_SER
                                      ,A.JAERYO_CODE                                                                                  JAERYO_CODE
                                      ,DECODE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) , 'Y', A.DV,A.NALSU)                              NALSU
                                      ,A.DIVIDE                                                                                       DIVIDE
                                      ,A.ORD_SURYANG                                                                                  DRG_ORDER_SURYANG
                                      ,A.ORDER_SURYANG                                                                                ORDER_SURYANG
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI)                                                DRG_ORDER_DANUI
                                      ,A.SUBUL_DANUI                                                                                  SUBUL_DANUI
                                      ,A.GROUP_YN                                                                                     GROUP_YN
                                      ,A.JAERYO_GUBUN                                                                                 JAERYO_GUBUN
                                      ,A.BOGYONG_CODE                                                                                 BOGYONG_CODE
                                      ,TRIM(DECODE(A.BUNRYU1,'4', FN_DRG_LOAD_REMARK( E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O'),
                                                             '6', FN_DRG_LOAD_REMARK( E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O') ))
                                       ||' '|| TRIM(B.BOGYONG_NAME) ||' '||FN_DRG_LOAD_DRG0120_PATTERN('O', A.FKOCS1003)              BOGYONG_NAME
                                      ,''                                                                                             CAUTION_NAME
                                      ,A.CAUTION_CODE                                                                                 CAUTION_CODE
                                      ,A.MIX_YN                                                                                       MIX_YN
                                      ,E.ATC_YN                                                                                       ATC_YN
                                      ,A.DV                                                                                           DV
                                      ,A.DV_TIME                                                                                      DV_TIME
                                      ,A.DC_YN                                                                                        DC_YN
                                      ,A.BANNAB_YN                                                                                    BANNAB_YN
                                      ,A.SOURCE_FKOCS1003                                                                             SOURCE_FKOCS1003
                                      ,A.FKOCS1003                                                                                    FKOCS1003
                                      ,TO_CHAR(A.SUNAB_DATE,'YYYY/MM/DD')                                                             SUNAB_DATE
                                      ,B.PATTERN                                                                                      PATTERN
                                      ,C.JAERYO_NAME                                                                                  JAERYO_NAME
                                      ,NVL(A.SUNAB_NALSU,0)                                                                           SUNAB_NALSU
                                      ,NVL(A.WONYOI_ORDER_YN,'N')                                                                     WONYOI_YN
                                      ,C.JAERYO_NAME || ' : '|| TRIM(DECODE(A.BUNRYU1,'6','', D.ORDER_REMARK||' ')
                                       || FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA_GUBUN))                                                ORDER_REMARK
                                      ,A.ACT_DATE                                                                                     ACT_DATE
                                      ,A.BUNRYU2                                                                                      MAYAK
                                      ,A.TPN_JOJE_GUBUN                                                                               TPN_JOJE_GUBUN
                                      ,NVL(C.MIX_YN_INP,'N')                                                                          UI_JUSA_YN
                                      ,A.SUBUL_SURYANG                                                                                SUBUL_SURYANG
                                      ,'Rp.'||E.SERIAL_V||DECODE(A.MIX_GROUP,NULL,'',' M')                                             SERIAL_V
                                      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.ORDER_DATE)                                                      GWA_NAME
                                      ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                                                DOCTOR_NAME
                                      ,F.SUNAME                                                                                       SUNAME
                                      ,F.SUNAME2                                                                                      SUNAME2
                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', F.BIRTH )                                                    BIRTH
                                      ,F.SEX                                                                                          SEX_AGE
                                      ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.NAEWON_DATE, A.GWA)                                   OTHER_GWA
                                      ,FN_DRG_DO_ORDER(A.BUNHO, A.NAEWON_DATE, A.GWA, A.DOCTOR, 'O', A.DRG_BUNHO)                     DO_ORDER
                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('5', D.HOPE_DATE )                                                HOPE_DATE
                                      ,FN_DRG_POWDER_YN(E.JUBSU_DATE, E.DRG_BUNHO, 'O')                                               POWDER_YN
                                      ,E.SERIAL_V                                                                                     LINE
                                      ,TRIM(C.KYUKYEOK)                                                                               KYUKYEOK
                                      ,DECODE(FN_DRG_MAYAK_CHK(A.JUBSU_DATE, A.DRG_BUNHO, 'O'), 'Y',
                                              SUBSTRB(TRIM(FN_DRG_DOCTOR_LICENSE(A.DOCTOR, TRUNC(SYSDATE),'Y')),1,20))                LICENSE
                                      ,A.MIX_GROUP                                                                                    MIX_GROUP
                                      ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                                          DONBOK
                                      ,FN_AKU_LOAD_TUSUK_YOIL(A.BUNHO, A.ORDER_DATE)                                                  TUSUK
                                      ,FN_DRG_LOAD_CAUTION_NM(E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O' ,'2')                        CAUTION_NM
                                      ,FN_OCS_LOAD_ORDER_SORT('O', D.INPUT_GUBUN, D.ORDER_GUBUN, D.GROUP_SER,
                                                                   D.MIX_GROUP,   D.SEQ,         D.PKOCS1003)                         ORDER_SORT
                                      ,C.TEXT_COLOR                                                                                   TEXT_COLOR
                                      ,C.CHANGGO1                                                                                     CHANGGO
                                      ,A.HUBAL_CHANGE_YN                                                                              HUBAL_CHANGE_YN
                                      ,FN_DRG_LOAD_HUBAL_ALL(A.ORDER_DATE, A.DRG_BUNHO)                                               HUBAL_ALL_YN
                                  FROM OUT0101 F
                                      ,DRG2030 E
                                      ,OCS1003 D
                                      ,INV0110 C
                                      ,DRG0120 B
                                      ,DRG2010 A
                                 WHERE A.ORDER_DATE               = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                                   AND A.DRG_BUNHO                = :f_drg_bunho
                                   AND A.SOURCE_FKOCS1003         IS NULL
                                   AND NVL(A.DC_YN,'N')           = 'N'
                                   AND NVL(A.BANNAB_YN,'N')       = 'N'
                                   AND A.JUNDAL_PART              = 'PA'
                                   AND B.BOGYONG_CODE          (+)= A.BOGYONG_CODE
                                   AND C.JAERYO_CODE           (+)= A.JAERYO_CODE
                                   AND D.PKOCS1003                = A.FKOCS1003
                                   AND TRIM(DECODE(A.BUNRYU1,'6','', D.ORDER_REMARK||' ')|| FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA_GUBUN)) || FN_DRG_LOAD_DRG0120_PATTERN('O', A.FKOCS1003) IS NOT NULL
                                   AND E.JUBSU_DATE               = A.ORDER_DATE
                                   AND E.DRG_BUNHO                = A.DRG_BUNHO
                                   AND E.FKOCS1003                = A.FKOCS1003
                                   AND E.SERIAL_V                 = :o_serial_text
                                   AND F.BUNHO                    = A.BUNHO
                                 ORDER BY E.SERIAL_V, A.MIX_GROUP, A.FKOCS1003";

                    dtRemark = Service.ExecuteDataTable(cmdText, bindVars);

                    for (int h = 0; h < dtRemark.Rows.Count; h++)
                    {
                        o_group_ser = dtRemark.Rows[h]["group_ser"].ToString();
                        o_jaeryo_code = dtRemark.Rows[h]["jaeryo_code"].ToString();
                        o_nalsu = dtRemark.Rows[h]["nalsu"].ToString();
                        o_divide = dtRemark.Rows[h]["divide"].ToString();
                        o_ord_suryang = dtRemark.Rows[h]["drg_order_suryang"].ToString();
                        o_order_suryang = dtRemark.Rows[h]["order_suryang"].ToString();
                        o_order_danui = dtRemark.Rows[h]["drg_order_danui"].ToString();
                        o_subul_danui = dtRemark.Rows[h]["subul_danui"].ToString();
                        o_group_yn = dtRemark.Rows[h]["group_yn"].ToString();
                        o_jaeryo_gubun = dtRemark.Rows[h]["jaeryo_gubun"].ToString();
                        o_bogyong_code = dtRemark.Rows[h]["bogyong_code"].ToString();
                        o_bogyong_name = dtRemark.Rows[h]["bogyong_name"].ToString();
                        o_caution_name = dtRemark.Rows[h]["caution_name"].ToString();
                        o_caution_code = dtRemark.Rows[h]["caution_code"].ToString();
                        o_mix_yn = dtRemark.Rows[h]["mix_yn"].ToString();
                        o_atc_yn = dtRemark.Rows[h]["atc_yn"].ToString();
                        o_dv = dtRemark.Rows[h]["dv"].ToString();
                        o_dv_time = dtRemark.Rows[h]["dv_time"].ToString();
                        o_dc_yn = dtRemark.Rows[h]["dc_yn"].ToString();
                        o_bannab_yn = dtRemark.Rows[h]["bannab_yn"].ToString();
                        o_source_fkocs1003 = dtRemark.Rows[h]["source_fkocs1003"].ToString();
                        o_fkocs1003 = dtRemark.Rows[h]["fkocs1003"].ToString();
                        o_sunab_date = dtRemark.Rows[h]["sunab_date"].ToString();
                        o_pattern = dtRemark.Rows[h]["pattern"].ToString();
                        o_jaeryo_name = dtRemark.Rows[h]["jaeryo_name"].ToString();
                        o_sunab_nalsu = dtRemark.Rows[h]["sunab_nalsu"].ToString();
                        o_wonyoi_yn = dtRemark.Rows[h]["wonyoi_yn"].ToString();
                        o_order_remark = dtRemark.Rows[h]["order_remark"].ToString();
                        o_act_date = dtRemark.Rows[h]["act_date"].ToString();
                        o_mayak = dtRemark.Rows[h]["mayak"].ToString();
                        o_tpn_joje_gubun = dtRemark.Rows[h]["tpn_joje_gubun"].ToString();
                        o_ui_jusa_yn = dtRemark.Rows[h]["ui_jusa_yn"].ToString();
                        o_subul_suryang = dtRemark.Rows[h]["subul_suryang"].ToString();
                        o_serial_v = dtRemark.Rows[h]["serial_v"].ToString();
                        o_gwa_name = dtRemark.Rows[h]["gwa_name"].ToString();
                        o_doctor_name = dtRemark.Rows[h]["doctor_name"].ToString();
                        o_suname = dtRemark.Rows[h]["suname"].ToString();
                        o_suname2 = dtRemark.Rows[h]["suname2"].ToString();
                        o_birth = dtRemark.Rows[h]["birth"].ToString();
                        o_age_sex = dtRemark.Rows[h]["sex_age"].ToString();
                        o_other_gwa = dtRemark.Rows[h]["other_gwa"].ToString();
                        o_do_order = dtRemark.Rows[h]["do_order"].ToString();
                        o_hope_nm = dtRemark.Rows[h]["hope_date"].ToString();
                        o_powder_yn = dtRemark.Rows[h]["powder_yn"].ToString();
                        o_serial_cnt = dtRemark.Rows[h]["line"].ToString();
                        o_kyukyeok = dtRemark.Rows[h]["kyukyeok"].ToString();
                        o_licenes = dtRemark.Rows[h]["license"].ToString();
                        o_mix_group = dtRemark.Rows[h]["mix_group"].ToString();
                        o_donbok = dtRemark.Rows[h]["donbok"].ToString();
                        o_tusuk = dtRemark.Rows[h]["tusuk"].ToString();
                        o_bigo = dtRemark.Rows[h]["caution_nm"].ToString();
                        o_key = dtRemark.Rows[h]["order_sort"].ToString();
                        o_text_color = dtRemark.Rows[h]["text_color"].ToString();
                        o_changgo = dtRemark.Rows[h]["changgo"].ToString();
                        o_hubal_change_yn = dtRemark.Rows[h]["hubal_change_yn"].ToString();
                        o_hubal_all_yn = dtRemark.Rows[h]["hubal_all_yn"].ToString();

                        rowNum = layOrderPrint.InsertRow(-1);
                        r_rec_cnt = r_rec_cnt++;

                        layOrderPrint.SetItemValue(rowNum, "bunho", o_bunho);
                        layOrderPrint.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                        layOrderPrint.SetItemValue(rowNum, "naewon_date", o_naewon_date);
                        layOrderPrint.SetItemValue(rowNum, "group_ser", o_group_ser);
                        layOrderPrint.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                        layOrderPrint.SetItemValue(rowNum, "order_date", o_order_date);
                        layOrderPrint.SetItemValue(rowNum, "jaeryo_code", o_jaeryo_code);
                        layOrderPrint.SetItemValue(rowNum, "nalsu", o_nalsu);
                        layOrderPrint.SetItemValue(rowNum, "divide", o_divide);
                        layOrderPrint.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                        layOrderPrint.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                        layOrderPrint.SetItemValue(rowNum, "order_danui", o_order_danui);
                        layOrderPrint.SetItemValue(rowNum, "subul_danui", o_subul_danui);
                        layOrderPrint.SetItemValue(rowNum, "group_yn", o_group_yn);
                        layOrderPrint.SetItemValue(rowNum, "jaeryo_gubun", o_jaeryo_gubun);
                        layOrderPrint.SetItemValue(rowNum, "bogyong_code", o_bogyong_code);
                        layOrderPrint.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                        layOrderPrint.SetItemValue(rowNum, "caution_name", o_caution_name);
                        layOrderPrint.SetItemValue(rowNum, "caution_code", o_caution_code);
                        layOrderPrint.SetItemValue(rowNum, "mix_yn", o_mix_yn);
                        layOrderPrint.SetItemValue(rowNum, "atc_yn", o_atc_yn);
                        layOrderPrint.SetItemValue(rowNum, "dv", o_dv);
                        layOrderPrint.SetItemValue(rowNum, "dv_time", o_dv_time);
                        layOrderPrint.SetItemValue(rowNum, "dc_yn", o_dc_yn);
                        layOrderPrint.SetItemValue(rowNum, "bannab_yn", o_bannab_yn);
                        layOrderPrint.SetItemValue(rowNum, "source_fkocs1003", o_source_fkocs1003);
                        layOrderPrint.SetItemValue(rowNum, "fkocs1003", o_fkocs1003);
                        layOrderPrint.SetItemValue(rowNum, "sunab_date", o_sunab_date);
                        layOrderPrint.SetItemValue(rowNum, "pattern", o_pattern);
                        layOrderPrint.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                        layOrderPrint.SetItemValue(rowNum, "sunab_nalsu", o_sunab_nalsu);
                        layOrderPrint.SetItemValue(rowNum, "wonyoi_yn", o_wonyoi_yn);
                        layOrderPrint.SetItemValue(rowNum, "order_remark", o_order_remark);
                        layOrderPrint.SetItemValue(rowNum, "act_date", o_act_date);
                        layOrderPrint.SetItemValue(rowNum, "mayak", o_mayak);
                        layOrderPrint.SetItemValue(rowNum, "tpn_joje_gubun", o_tpn_joje_gubun);
                        layOrderPrint.SetItemValue(rowNum, "ui_jusa_yn", o_ui_jusa_yn);
                        layOrderPrint.SetItemValue(rowNum, "subul_suryang", o_subul_suryang);
                        layOrderPrint.SetItemValue(rowNum, "serial_v", "Comment");
                        layOrderPrint.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                        layOrderPrint.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                        layOrderPrint.SetItemValue(rowNum, "suname", o_suname);
                        layOrderPrint.SetItemValue(rowNum, "suname2", o_suname2);
                        layOrderPrint.SetItemValue(rowNum, "birth", o_birth);
                        layOrderPrint.SetItemValue(rowNum, "age", o_age_sex);
                        layOrderPrint.SetItemValue(rowNum, "other_gwa", o_other_gwa);
                        layOrderPrint.SetItemValue(rowNum, "do_order", o_do_order);
                        layOrderPrint.SetItemValue(rowNum, "hope_nm", o_hope_nm);
                        layOrderPrint.SetItemValue(rowNum, "powder_yn", o_powder_yn);
                        layOrderPrint.SetItemValue(rowNum, "rowno", o_line);
                        layOrderPrint.SetItemValue(rowNum, "kyukyeok", o_kyukyeok);
                        layOrderPrint.SetItemValue(rowNum, "licenes", o_licenes);
                        layOrderPrint.SetItemValue(rowNum, "bunryu1", o_bunryu1);
                        layOrderPrint.SetItemValue(rowNum, "mix_group", o_mix_group);
                        layOrderPrint.SetItemValue(rowNum, "donbok_yn", o_donbok);
                        layOrderPrint.SetItemValue(rowNum, "tusuk", o_tusuk);
                        layOrderPrint.SetItemValue(rowNum, "bigo", o_bigo);
                        layOrderPrint.SetItemValue(rowNum, "text_color", o_text_color);
                        layOrderPrint.SetItemValue(rowNum, "changgo", o_changgo);
                        layOrderPrint.SetItemValue(rowNum, "gubun_name", o_gubun_name);
                        layOrderPrint.SetItemValue(rowNum, "johap", o_johap);
                        layOrderPrint.SetItemValue(rowNum, "gaein", o_gaein);
                        layOrderPrint.SetItemValue(rowNum, "gaein_no", o_gaein_no);
                        layOrderPrint.SetItemValue(rowNum, "bonin_gubun", o_bonin_gubun);
                        layOrderPrint.SetItemValue(rowNum, "bon_rate", o_bon_rate);
                        layOrderPrint.SetItemValue(rowNum, "budamja_bunho1", o_budamja_bunho1);
                        layOrderPrint.SetItemValue(rowNum, "sugubja_bunho1", o_sugubja_bunho1);
                        layOrderPrint.SetItemValue(rowNum, "budamja_bunho2", o_budamja_bunho2);
                        layOrderPrint.SetItemValue(rowNum, "sugubja_bunho2", o_sugubja_bunho2);
                        layOrderPrint.SetItemValue(rowNum, "sunwon_gubun", o_sunwon_gubun);
                        layOrderPrint.SetItemValue(rowNum, "noin_rate_name", o_noin_rate_name);
                        layOrderPrint.SetItemValue(rowNum, "user_id", q_user_id);
                        layOrderPrint.SetItemValue(rowNum, "data_gubun", "C");
                        layOrderPrint.SetItemValue(rowNum, "mayak_license", o_mayak_license);
                        layOrderPrint.SetItemValue(rowNum, "mayak_doctor", o_mayak_doctor);
                        layOrderPrint.SetItemValue(rowNum, "mayak_address1", o_mayak_address1);
                        layOrderPrint.SetItemValue(rowNum, "mayak_address2", o_mayak_address2);
                        layOrderPrint.SetItemValue(rowNum, "gigan_date", o_jigan_date);
                        layOrderPrint.SetItemValue(rowNum, "hubal_change_yn", o_hubal_change_yn);
                        layOrderPrint.SetItemValue(rowNum, "hubal_all_yn", o_hubal_all_yn);
                    }
                }
                bindVars.Clear();
                bindVars.Add("r_rec_cnt", r_rec_cnt.ToString());
                cmdText = @"SELECT DECODE(16 - mod(:r_rec_cnt, 16)
                                         ,16, 0 + TRUNC(:r_rec_cnt / 16)
                                         ,16 - mod(:r_rec_cnt, 16) + TRUNC(:r_rec_cnt / 16) ) CNT
                              FROM DUAL";
                int InsertRow = Convert.ToInt32(Service.ExecuteScalar(cmdText, bindVars));
                for (int k = 0; k <= InsertRow; k++)
                {
                    rowNum = layOrderPrint.InsertRow(-1);
                    r_rec_cnt++;

                    layOrderPrint.SetItemValue(rowNum, "bunho", "");
                    layOrderPrint.SetItemValue(rowNum, "drg_bunho", "");
                    layOrderPrint.SetItemValue(rowNum, "naewon_date", "");
                    layOrderPrint.SetItemValue(rowNum, "group_ser", "");
                    layOrderPrint.SetItemValue(rowNum, "jubsu_date", "");
                    layOrderPrint.SetItemValue(rowNum, "order_date", "");
                    layOrderPrint.SetItemValue(rowNum, "jaeryo_code", "");
                    layOrderPrint.SetItemValue(rowNum, "nalsu", "");
                    layOrderPrint.SetItemValue(rowNum, "divide", "");
                    layOrderPrint.SetItemValue(rowNum, "ord_surang", "");
                    layOrderPrint.SetItemValue(rowNum, "order_suryang", "");
                    layOrderPrint.SetItemValue(rowNum, "order_danui", "");
                    layOrderPrint.SetItemValue(rowNum, "subul_danui", "");
                    layOrderPrint.SetItemValue(rowNum, "group_yn", "");
                    layOrderPrint.SetItemValue(rowNum, "jaeryo_gubun", "");
                    layOrderPrint.SetItemValue(rowNum, "bogyong_code", "");
                    layOrderPrint.SetItemValue(rowNum, "bogyong_name", "");
                    layOrderPrint.SetItemValue(rowNum, "caution_name", "");
                    layOrderPrint.SetItemValue(rowNum, "caution_code", "");
                    layOrderPrint.SetItemValue(rowNum, "mix_yn", "");
                    layOrderPrint.SetItemValue(rowNum, "atc_yn", "");
                    layOrderPrint.SetItemValue(rowNum, "dv", "");
                    layOrderPrint.SetItemValue(rowNum, "dv_time", "");
                    layOrderPrint.SetItemValue(rowNum, "dc_yn", "");
                    layOrderPrint.SetItemValue(rowNum, "bannab_yn", "");
                    layOrderPrint.SetItemValue(rowNum, "source_fkocs1003", "");
                    layOrderPrint.SetItemValue(rowNum, "fkocs1003", "");
                    layOrderPrint.SetItemValue(rowNum, "sunab_date", "");
                    layOrderPrint.SetItemValue(rowNum, "pattern", "");
                    if (k == 0) layOrderPrint.SetItemValue(rowNum, "jaeryo_name", "ZZ");
                    else layOrderPrint.SetItemValue(rowNum, "jaeryo_name", "");
                    layOrderPrint.SetItemValue(rowNum, "sunab_nalsu", "");
                    layOrderPrint.SetItemValue(rowNum, "wonyoi_yn", "");
                    layOrderPrint.SetItemValue(rowNum, "order_remark", "");
                    layOrderPrint.SetItemValue(rowNum, "act_date", "");
                    layOrderPrint.SetItemValue(rowNum, "mayak", "");
                    layOrderPrint.SetItemValue(rowNum, "tpn_joje_gubun", "");
                    layOrderPrint.SetItemValue(rowNum, "ui_jusa_yn", "");
                    layOrderPrint.SetItemValue(rowNum, "subul_suryang", "");
                    layOrderPrint.SetItemValue(rowNum, "serial_v", "ZZ");
                    layOrderPrint.SetItemValue(rowNum, "gwa_name", "");
                    layOrderPrint.SetItemValue(rowNum, "doctor_name", "");
                    layOrderPrint.SetItemValue(rowNum, "suname", "");
                    layOrderPrint.SetItemValue(rowNum, "suname2", "");
                    layOrderPrint.SetItemValue(rowNum, "birth", "");
                    layOrderPrint.SetItemValue(rowNum, "age", "");
                    layOrderPrint.SetItemValue(rowNum, "other_gwa", "");
                    layOrderPrint.SetItemValue(rowNum, "do_order", "");
                    layOrderPrint.SetItemValue(rowNum, "hope_nm", "");
                    layOrderPrint.SetItemValue(rowNum, "powder_yn", "");
                    layOrderPrint.SetItemValue(rowNum, "rowno", o_line);
                    layOrderPrint.SetItemValue(rowNum, "kyukyeok", "");
                    layOrderPrint.SetItemValue(rowNum, "licenes", "");
                    layOrderPrint.SetItemValue(rowNum, "bunryu1", "");
                    layOrderPrint.SetItemValue(rowNum, "mix_group", "");
                    layOrderPrint.SetItemValue(rowNum, "donbok_yn", "");
                    layOrderPrint.SetItemValue(rowNum, "tusuk", "");
                    layOrderPrint.SetItemValue(rowNum, "bigo", "");
                    layOrderPrint.SetItemValue(rowNum, "text_color", "");
                    layOrderPrint.SetItemValue(rowNum, "changgo", "");
                    layOrderPrint.SetItemValue(rowNum, "gubun_name", "");
                    layOrderPrint.SetItemValue(rowNum, "johap", "");
                    layOrderPrint.SetItemValue(rowNum, "gaein", "");
                    layOrderPrint.SetItemValue(rowNum, "gaein_no", "");
                    layOrderPrint.SetItemValue(rowNum, "bonin_gubun", "");
                    layOrderPrint.SetItemValue(rowNum, "bon_rate", "");
                    layOrderPrint.SetItemValue(rowNum, "budamja_bunho1", "");
                    layOrderPrint.SetItemValue(rowNum, "sugubja_bunho1", "");
                    layOrderPrint.SetItemValue(rowNum, "budamja_bunho2", "");
                    layOrderPrint.SetItemValue(rowNum, "sugubja_bunho2", "");
                    layOrderPrint.SetItemValue(rowNum, "sunwon_gubun", "");
                    layOrderPrint.SetItemValue(rowNum, "noin_rate_name", "");
                    layOrderPrint.SetItemValue(rowNum, "user_id", "");
                    if (k == 0) layOrderPrint.SetItemValue(rowNum, "data_gubun", "D");
                    else layOrderPrint.SetItemValue(rowNum, "data_gubun", "");
                    layOrderPrint.SetItemValue(rowNum, "mayak_license", o_mayak_license);
                    layOrderPrint.SetItemValue(rowNum, "mayak_doctor", o_mayak_doctor);
                    layOrderPrint.SetItemValue(rowNum, "mayak_address1", o_mayak_address1);
                    layOrderPrint.SetItemValue(rowNum, "mayak_address2", o_mayak_address2);
                    layOrderPrint.SetItemValue(rowNum, "gigan_date", o_jigan_date);
                    layOrderPrint.SetItemValue(rowNum, "hubal_change_yn", "");
                    layOrderPrint.SetItemValue(rowNum, "hubal_all_yn", o_hubal_all_yn);
                }
            }
            catch (Exception xe)
            {
                XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                return false;
            }
            return true;
        }
        #endregion

        #region [-- DsvOrderJungbo --]
        /// <summary>
        /// dsvOrderJungbo Service Conversion PC:DRGPRINCOM, WT:6
        /// </summary>
        /// <param name="orderDate"></param>
        /// <param name="drgBunho"></param>
        /// <returns></returns>
        private bool DsvOrderJungbo(string orderDate, string drgBunho)
        {
            string o_seq_1 = string.Empty;
            string o_seq_2 = string.Empty;

            string o_text_1 = string.Empty;
            string o_text_2 = string.Empty;
            string o_text_3 = string.Empty;
            string o_comments = string.Empty;
            string o_bunho_comments = string.Empty;
            string o_bar_drg_bunho = string.Empty;
            string o_bar_rp_bunho = string.Empty;

            string o_cpl_1 = string.Empty;
            string o_cpl_2 = string.Empty;
            string o_cpl_3 = string.Empty;
            string o_danui_1 = string.Empty;
            string o_danui_2 = string.Empty;
            string o_danui_3 = string.Empty;
            string o_bunho = string.Empty;
            string o_hl_1 = string.Empty;
            string o_hl_2 = string.Empty;
            string o_hl_3 = string.Empty;
            int o_row = 0;

            string t_comments = string.Empty;
            int rowNum = 0;

            string cmdText = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_jubsu_date", orderDate);
            bindVars.Add("f_drg_bunho", drgBunho);

            DataTable dtPrinco = new DataTable();
            DataTable dtJungbo = new DataTable();

            try
            {
                cmdText = @"SELECT '1'                SEQ_1
                                  ,D.SERIAL_V         SEQ_2
                                  ,C.JAERYO_NAME      TEXT_1
                                  ,''                 TEXT_2
                                  ,''                 TEXT_3
                                  ,REPLACE(REPLACE(B.ORDER_REMARK,CHR(13)||CHR(10),' '),CHR(10),' ')     REMARK
                                  ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'   BAR_DRG_BUNHO
                                  ,A.BUNHO            BUNHO
                              FROM DRG2030 D
                                  ,INV0110 C
                                  ,DRG9042 B
                                  ,DRG2010 A
                             WHERE A.ORDER_DATE     = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                               AND A.DRG_BUNHO      = :f_drg_bunho
                               AND B.FKOCS          = A.FKOCS1003
                               AND C.JAERYO_CODE (+)= A.JAERYO_CODE
                               AND D.FKOCS1003   (+)= A.FKOCS1003
                               AND B.ORDER_REMARK IS NOT NULL
                            UNION ALL
                            SELECT DISTINCT '1'       SEQ_1
                                  ,''                 SEQ_2
                                  ,C.JAERYO_NAME      TEXT_1
                                  ,''                 TEXT_2
                                  ,''                 TEXT_3
                                  ,'[' || FN_ADM_MSG(4111) || ']' || REPLACE(REPLACE(C.DRG_COMMENT,CHR(13)||CHR(10),' '),CHR(10),' ') REMARK
                                  ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'   BAR_DRG_BUNHO
                                  ,A.BUNHO            BUNHO
                              FROM DRG2030 D
                                  ,INV0110 C
                                  ,DRG2010 A
                             WHERE A.ORDER_DATE     = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                               AND A.DRG_BUNHO      = :f_drg_bunho
                               AND C.JAERYO_CODE (+)= A.JAERYO_CODE
                               AND NVL(C.CHKD,'N')  = 'Y'
                               AND D.FKOCS1003   (+)= A.FKOCS1003
                            UNION ALL
                            SELECT DISTINCT
                                   '2'                SEQ_1
                                  ,''                 SEQ_2
                                  ,'##'               TEXT_1
                                  ,''                 TEXT_2
                                  ,''                 TEXT_3
                                  ,REPLACE(REPLACE(B.ORDER_REMARK,CHR(13)||CHR(10),' '),CHR(10),' ') REMARK
                                  ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'   BAR_DRG_BUNHO
                                  ,A.BUNHO            BUNHO
                              FROM DRG9040 B
                                  ,DRG2010 A
                             WHERE A.ORDER_DATE  = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                               AND A.DRG_BUNHO   = :f_drg_bunho
                               AND B.JUBSU_DATE  = A.ORDER_DATE
                               AND B.DRG_BUNHO   = A.DRG_BUNHO
                               AND B.ORDER_REMARK IS NOT NULL
                            UNION ALL
                            SELECT DISTINCT
                                   '3'                SEQ_1
                                  ,''                 SEQ_2
                                  ,DECODE(B.BUNHO,NULL,'','$$')  TEXT_1
                                  ,''                 TEXT_2
                                  ,''                 TEXT_3
                                  ,REPLACE(REPLACE(B.ORDER_REMARK,CHR(13)||CHR(10),' '),CHR(10),' ') REMARK
                                  ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'   BAR_DRG_BUNHO
                                  ,A.BUNHO            BUNHO
                              FROM DRG9041 B
                                  ,DRG2010 A
                             WHERE A.ORDER_DATE  = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                               AND A.DRG_BUNHO   = :f_drg_bunho
                               AND B.BUNHO    (+)= A.BUNHO
                               AND B.ORDER_REMARK IS NOT NULL
                             ORDER BY 1, 2";

                dtPrinco = Service.ExecuteDataTable(cmdText, bindVars);

                if (dtPrinco.Rows.Count < 1)
                {
                    cmdText = @"SELECT DISTINCT '*'||TO_CHAR(A.ORDER_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'
                                  FROM DRG2010 A
                                 WHERE A.ORDER_DATE  = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                                   AND A.DRG_BUNHO   = :f_drg_bunho";
                    o_bar_drg_bunho = Service.ExecuteScalar(cmdText, bindVars).ToString();

                    rowNum = layOrderJungbo.InsertRow(-1);

                    layOrderJungbo.SetItemValue(rowNum, "text_1", "");
                    layOrderJungbo.SetItemValue(rowNum, "text_2", "");
                    layOrderJungbo.SetItemValue(rowNum, "text_3", "");
                    layOrderJungbo.SetItemValue(rowNum, "comments", "");
                    layOrderJungbo.SetItemValue(rowNum, "bunho_comments", "");
                    layOrderJungbo.SetItemValue(rowNum, "bar_drg_bunho", o_bar_drg_bunho);
                    layOrderJungbo.SetItemValue(rowNum, "bar_rp_bunho", "");
                    layOrderJungbo.SetItemValue(rowNum, "cpl_1", "");
                    layOrderJungbo.SetItemValue(rowNum, "cpl_2", "");
                    layOrderJungbo.SetItemValue(rowNum, "cpl_3", "");
                    layOrderJungbo.SetItemValue(rowNum, "danui_1", "");
                    layOrderJungbo.SetItemValue(rowNum, "danui_2", "");
                    layOrderJungbo.SetItemValue(rowNum, "danui_3", "");
                    layOrderJungbo.SetItemValue(rowNum, "hl_1", "");
                    layOrderJungbo.SetItemValue(rowNum, "hl_2", "");
                    layOrderJungbo.SetItemValue(rowNum, "hl_3", "");

                    return true;
                }

                for (int i = 0; i < dtPrinco.Rows.Count; i++)
                {
                    o_seq_1 = dtPrinco.Rows[i]["seq_1"].ToString();
                    o_seq_2 = dtPrinco.Rows[i]["seq_2"].ToString();
                    o_text_1 = dtPrinco.Rows[i]["text_1"].ToString();
                    o_text_2 = dtPrinco.Rows[i]["text_2"].ToString();
                    o_text_3 = dtPrinco.Rows[i]["text_3"].ToString();
                    o_comments = dtPrinco.Rows[i]["remark"].ToString();
                    o_bar_drg_bunho = dtPrinco.Rows[i]["bar_drg_bunho"].ToString();
                    o_bunho = dtPrinco.Rows[i]["bunho"].ToString();

                    bindVars.Remove("f_bunho");
                    bindVars.Remove("f_comments");
                    bindVars.Add("f_bunho", o_bunho);
                    bindVars.Add("f_comments", o_comments);

                    cmdText = @"SELECT NVL(FN_NUR_LOAD_WEIGHT_HEIGHT('H', :f_bunho), 0) HEIGHT
                                     , 'Cm'                                             CM
                                     , NVL(FN_NUR_LOAD_WEIGHT_HEIGHT('W', :f_bunho), 0) WEIGHT
                                     , 'Kg'                                             KG
                                     , FN_CPL_HANGMOG_RESULT(:f_bunho, '00077')         CPL_RESULT
                                     , FN_ADM_CONVERT_KATAKANA_FULL(:f_comments)        COMMENTS
                                     , TRUNC(LENGTH(NVL(:f_comments,' ')) / 80)         CNT
                                  FROM DUAL";
                    dtJungbo = Service.ExecuteDataTable(cmdText, bindVars);
                    if (dtJungbo.Rows.Count > 0)
                    {
                        o_cpl_1 = dtJungbo.Rows[0]["height"].ToString();
                        o_danui_1 = dtJungbo.Rows[0]["cm"].ToString();
                        o_cpl_2 = dtJungbo.Rows[0]["weight"].ToString();
                        o_danui_2 = dtJungbo.Rows[0]["kg"].ToString();
                        o_cpl_3 = dtJungbo.Rows[0]["cpl_result"].ToString();
                        o_comments = dtJungbo.Rows[0]["comments"].ToString();
                        o_row = int.Parse(dtJungbo.Rows[0]["cnt"].ToString());
                    }

                    for (int b = 0; b <= o_row; b++)
                    {
                        cmdText = @"SELECT '    ' || SUBSTR('" + o_comments + "', " + b + @" * 80 + 1, 80) FROM DUAL";
                        t_comments = Service.ExecuteScalar(cmdText).ToString();

                        if (b == 0)
                        {
                            rowNum = layOrderJungbo.InsertRow(-1);

                            layOrderJungbo.SetItemValue(rowNum, "text_1", o_text_1);
                            layOrderJungbo.SetItemValue(rowNum, "text_2", o_text_2);
                            layOrderJungbo.SetItemValue(rowNum, "text_3", o_text_3);
                            layOrderJungbo.SetItemValue(rowNum, "comments", o_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bunho_comments", o_bunho_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bar_drg_bunho", o_bar_drg_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "bar_rp_bunho", o_bar_rp_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_1", o_cpl_1);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_2", o_cpl_2);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_3", o_cpl_3);
                            layOrderJungbo.SetItemValue(rowNum, "danui_1", o_danui_1);
                            layOrderJungbo.SetItemValue(rowNum, "danui_2", o_danui_2);
                            layOrderJungbo.SetItemValue(rowNum, "danui_3", o_danui_3);
                            layOrderJungbo.SetItemValue(rowNum, "hl_1", o_hl_1);
                            layOrderJungbo.SetItemValue(rowNum, "hl_2", o_hl_2);
                            layOrderJungbo.SetItemValue(rowNum, "hl_3", o_hl_3);

                            rowNum = layOrderJungbo.InsertRow(-1);

                            layOrderJungbo.SetItemValue(rowNum, "text_1", t_comments);
                            layOrderJungbo.SetItemValue(rowNum, "text_2", o_text_2);
                            layOrderJungbo.SetItemValue(rowNum, "text_3", o_text_3);
                            layOrderJungbo.SetItemValue(rowNum, "comments", t_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bunho_comments", o_bunho_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bar_drg_bunho", o_bar_drg_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "bar_rp_bunho", o_bar_rp_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_1", o_cpl_1);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_2", o_cpl_2);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_3", o_cpl_3);
                            layOrderJungbo.SetItemValue(rowNum, "danui_1", o_danui_1);
                            layOrderJungbo.SetItemValue(rowNum, "danui_2", o_danui_2);
                            layOrderJungbo.SetItemValue(rowNum, "danui_3", o_danui_3);
                            layOrderJungbo.SetItemValue(rowNum, "hl_1", o_hl_1);
                            layOrderJungbo.SetItemValue(rowNum, "hl_2", o_hl_2);
                            layOrderJungbo.SetItemValue(rowNum, "hl_3", o_hl_3);
                        }
                        else
                        {
                            rowNum = layOrderJungbo.InsertRow(-1);

                            layOrderJungbo.SetItemValue(rowNum, "text_1", t_comments);
                            layOrderJungbo.SetItemValue(rowNum, "text_2", o_text_2);
                            layOrderJungbo.SetItemValue(rowNum, "text_3", o_text_3);
                            layOrderJungbo.SetItemValue(rowNum, "comments", t_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bunho_comments", o_bunho_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bar_drg_bunho", o_bar_drg_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "bar_rp_bunho", o_bar_rp_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_1", o_cpl_1);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_2", o_cpl_2);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_3", o_cpl_3);
                            layOrderJungbo.SetItemValue(rowNum, "danui_1", o_danui_1);
                            layOrderJungbo.SetItemValue(rowNum, "danui_2", o_danui_2);
                            layOrderJungbo.SetItemValue(rowNum, "danui_3", o_danui_3);
                            layOrderJungbo.SetItemValue(rowNum, "hl_1", o_hl_1);
                            layOrderJungbo.SetItemValue(rowNum, "hl_2", o_hl_2);
                            layOrderJungbo.SetItemValue(rowNum, "hl_3", o_hl_3);
                        }
                    }
                }

            }
            catch (Exception xe)
            {
                XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                return false;
            }
            return true;
        }
        #endregion

        #region [-- DsvAtcSend --]
        /// <summary>
        /// dsvAtcSend Service Conversion PC:DRGMESSAGE, WT:A
        /// </summary>
        /// <param name="orderDate"></param>
        /// <param name="drgBunho"></param>
        /// <param name="ioGubun"></param>
        private void DsvAtcSend(string orderDate, string drgBunho, string ioGubun)
        {
            string cmdText = @"SELECT MAX(SEQ) + 1
                                 FROM DRG_ATC
                                WHERE JUBSU_DATE   = :f_jubsu_date
                                  AND DRG_BUNHO    = :f_drg_bunho
                                  AND IN_OUT_GUBUN = :f_in_out_gubun";
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("q_user_id", UserInfo.UserID);
            bindVars.Add("f_jubsu_date", orderDate);
            bindVars.Add("f_drg_bunho", drgBunho);
            bindVars.Add("f_in_out_gubun", ioGubun);

            object retVal = Service.ExecuteScalar(cmdText, bindVars);
            if (!TypeCheck.IsNull(retVal))
            {
                bindVars.Add("f_seq", retVal.ToString());
            }

            cmdText = @"INSERT INTO DRG_ATC(SYS_DATE              ,USER_ID              ,UPD_DATE
                                           ,JUBSU_DATE            ,DRG_BUNHO            ,IN_OUT_GUBUN
                                           ,SEQ                   ,INPUT_DATE           ,INPUT_TIME
                                           ,SEND_DATE             ,SEND_TIME            ,END_FLAG)
                                    VALUES (SYSDATE               ,:q_user_id           ,SYSDATE
                                           ,:f_jubsu_date         ,:f_drg_bunho         ,:f_in_out_gubun
                                           ,NVL(:f_seq,1)         ,TRUNC(SYSDATE)       ,TO_CHAR(SYSDATE,'HH24MI')
                                           ,NULL                  ,NULL                 ,'N')";
            try
            {
                Service.BeginTransaction();
                if (!Service.ExecuteNonQuery(cmdText, bindVars)) throw new Exception(Service.ErrFullMsg);
            }
            catch (Exception xe)
            {
                Service.RollbackTransaction();
                XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                return;
            }
            Service.CommitTransaction();
        }
        #endregion

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void dtpFromDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            PaQuery();
        }

        private void xBuseoCombo_SelectedValueChanged(object sender, System.EventArgs e)
        {
            PaQuery();
        }

        private void btnAllCheck_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < grdPaid.RowCount; i++)
            {
                grdPaid.SetItemValue(i, "chk", "Y");
            }
            grdPaid.AcceptData();
        }

        private void btnAllUnCheck_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < grdPaid.RowCount; i++)
            {
                grdPaid.SetItemValue(i, "chk", "N");
            }
            grdPaid.AcceptData();
        }

        private void grdPaid_QueryStarting(object sender, CancelEventArgs e)
        {
            grdPaid.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue().Replace("-", "").Replace("/", "").Substring(0, 8));
            grdPaid.SetBindVarValue("f_to_date", dtpFromDate.GetDataValue().Replace("-", "").Replace("/", "").Substring(0, 8));
            grdPaid.SetBindVarValue("f_gwa", xBuseoCombo.GetDataValue());
        }
    }
}
