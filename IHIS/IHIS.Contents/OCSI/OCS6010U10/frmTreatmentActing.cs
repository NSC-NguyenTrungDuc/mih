using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

using IHIS.Framework;

namespace IHIS.OCSI
{
    public class frmTreatmentActing : IHIS.Framework.XForm
    {
        #region [Instance Variable]
        //Message처리
        private string mbxMsg = "", mbxCap = "";
        private string mBunho        = "";
        private string mFkinp1001    = "";
        private string mOrder_date   = "";
        private string mInput_gubun  = "";
        private string mOcs2005_seq  = "";
        private string mDirect_gubun = "";
        private string mDirect_code  = "";
        private string mActing_yn    = "";
        private string mUser_id      = "";
        private string mUser_name    = "";
        private string mCan_acting_yn = "";
        private string mDirect_cont  = "";
        private string mPkOCS2005    = "";
        private string mPkOCS6015    = "";
        private string mSource_order_date = "";
        private string mInput_gwa    = "";
        private string mInput_doctor = "";

        // Hospital Code
        private string mHospCode = EnvironInfo.HospCode;
        #endregion

        private XPanel pnlTop;
        private XDisplayBox dpbAct_id_name;
        private XDatePicker dtpAct_date;
        private XFlatLabel xFlatLabel1;
        private XFlatLabel xFlatLabel2;
        private XFlatLabel xFlatLabel3;
        private XFlatLabel xFlatLabel4;
        private XTextBox txtAct_result_text;
        private XPanel pnlBottomUnder;
        private XButtonList btnList;
        private XEditGrid grdOCS2006;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XEditGrid grdNUR0114;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGrid grdOCS2015;
        private XEditGrid grdOCS2016;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell31;
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell37;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell40;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell42;
        private XEditGridCell xEditGridCell43;
        private XEditGridCell xEditGridCell44;
        private XEditGridCell xEditGridCell45;
        private XEditGridCell xEditGridCell46;
        private XEditGridCell xEditGridCell47;
        private XEditGridCell xEditGridCell48;
        private XEditGridCell xEditGridCell49;
        private XEditGridCell xEditGridCell50;
        private XEditGridCell xEditGridCell51;
        private ImageList imageList;
        private XEditGridCell xEditGridCell52;
        private XEditGridCell xEditGridCell53;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell55;
        private XEditGridCell xEditGridCell56;
        private XPanel pnlBody;
        private XEditGridCell xEditGridCell57;
        private XPanel xPanel1;
        private XPanel xPanel2;
        private XPanel xPanel3;
        private XPanel xPanel4;
        private XPanel pnlBottom;
        private XPanel pnlCenter;

        private System.ComponentModel.IContainer components = null;

        public frmTreatmentActing()
        {
            /* SavePerformer 생성 */
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            this.grdOCS2015.SavePerformer = new XSavePerformer(this);
            this.grdOCS2016.SavePerformer = grdOCS2015.SavePerformer;
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdOCS2015);
            this.SaveLayoutList.Add(this.grdOCS2016);

            // TODO: InitializeComponent를 호출한 다음 초기화 작업을 추가합니다.
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

        #region 디자이너에서 생성한 코드
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTreatmentActing));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.dpbAct_id_name = new IHIS.Framework.XDisplayBox();
            this.dtpAct_date = new IHIS.Framework.XDatePicker();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel2 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel4 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel3 = new IHIS.Framework.XFlatLabel();
            this.pnlBottomUnder = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdOCS2016 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.grdOCS2015 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.txtAct_result_text = new IHIS.Framework.XTextBox();
            this.grdOCS2006 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.grdNUR0114 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.pnlBody = new IHIS.Framework.XPanel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.pnlCenter = new IHIS.Framework.XPanel();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.pnlTop.SuspendLayout();
            this.pnlBottomUnder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2016)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2015)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2006)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0114)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.pnlTop.Controls.Add(this.dpbAct_id_name);
            this.pnlTop.Controls.Add(this.dtpAct_date);
            this.pnlTop.Controls.Add(this.xFlatLabel1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(684, 30);
            this.pnlTop.TabIndex = 69;
            // 
            // dpbAct_id_name
            // 
            this.dpbAct_id_name.Location = new System.Drawing.Point(168, 5);
            this.dpbAct_id_name.Name = "dpbAct_id_name";
            this.dpbAct_id_name.Size = new System.Drawing.Size(127, 21);
            this.dpbAct_id_name.TabIndex = 61;
            // 
            // dtpAct_date
            // 
            this.dtpAct_date.IsJapanYearType = true;
            this.dtpAct_date.Location = new System.Drawing.Point(53, 5);
            this.dtpAct_date.Name = "dtpAct_date";
            this.dtpAct_date.Size = new System.Drawing.Size(110, 20);
            this.dtpAct_date.TabIndex = 60;
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xFlatLabel1.Location = new System.Drawing.Point(4, 5);
            this.xFlatLabel1.Name = "xFlatLabel1";
            this.xFlatLabel1.Size = new System.Drawing.Size(46, 20);
            this.xFlatLabel1.TabIndex = 59;
            this.xFlatLabel1.Text = "施行日";
            // 
            // xFlatLabel2
            // 
            this.xFlatLabel2.Image = ((System.Drawing.Image)(resources.GetObject("xFlatLabel2.Image")));
            this.xFlatLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xFlatLabel2.Location = new System.Drawing.Point(6, 205);
            this.xFlatLabel2.Name = "xFlatLabel2";
            this.xFlatLabel2.Size = new System.Drawing.Size(72, 23);
            this.xFlatLabel2.TabIndex = 75;
            this.xFlatLabel2.Text = "    コメント";
            this.xFlatLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xFlatLabel4
            // 
            this.xFlatLabel4.Image = ((System.Drawing.Image)(resources.GetObject("xFlatLabel4.Image")));
            this.xFlatLabel4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xFlatLabel4.Location = new System.Drawing.Point(3, 5);
            this.xFlatLabel4.Name = "xFlatLabel4";
            this.xFlatLabel4.Size = new System.Drawing.Size(94, 23);
            this.xFlatLabel4.TabIndex = 74;
            this.xFlatLabel4.Text = "    実施コメント";
            this.xFlatLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xFlatLabel3
            // 
            this.xFlatLabel3.Image = ((System.Drawing.Image)(resources.GetObject("xFlatLabel3.Image")));
            this.xFlatLabel3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xFlatLabel3.Location = new System.Drawing.Point(3, 5);
            this.xFlatLabel3.Name = "xFlatLabel3";
            this.xFlatLabel3.Size = new System.Drawing.Size(106, 23);
            this.xFlatLabel3.TabIndex = 73;
            this.xFlatLabel3.Text = "    オーダ発生処置";
            this.xFlatLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottomUnder
            // 
            this.pnlBottomUnder.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.pnlBottomUnder.Controls.Add(this.btnList);
            this.pnlBottomUnder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomUnder.Location = new System.Drawing.Point(0, 64);
            this.pnlBottomUnder.Name = "pnlBottomUnder";
            this.pnlBottomUnder.Size = new System.Drawing.Size(684, 36);
            this.pnlBottomUnder.TabIndex = 76;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Location = new System.Drawing.Point(438, 1);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Process;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdOCS2016
            // 
            this.grdOCS2016.CallerID = '6';
            this.grdOCS2016.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell52,
            this.xEditGridCell53});
            this.grdOCS2016.ColPerLine = 16;
            this.grdOCS2016.Cols = 16;
            this.grdOCS2016.FixedRows = 1;
            this.grdOCS2016.HeaderHeights.Add(21);
            this.grdOCS2016.Location = new System.Drawing.Point(7, 331);
            this.grdOCS2016.Name = "grdOCS2016";
            this.grdOCS2016.QuerySQL = resources.GetString("grdOCS2016.QuerySQL");
            this.grdOCS2016.Rows = 2;
            this.grdOCS2016.Size = new System.Drawing.Size(344, 218);
            this.grdOCS2016.TabIndex = 78;
            this.grdOCS2016.UseDefaultTransaction = false;
            this.grdOCS2016.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS2016_QueryStarting);
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "pkocs2016";
            this.xEditGridCell35.HeaderText = "pkocs2016";
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "fkocs2015";
            this.xEditGridCell36.Col = 1;
            this.xEditGridCell36.HeaderText = "fkocs2015";
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "seq";
            this.xEditGridCell37.Col = 2;
            this.xEditGridCell37.HeaderText = "seq";
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "hangmog_code";
            this.xEditGridCell38.Col = 3;
            this.xEditGridCell38.HeaderText = "hangmog_code";
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "hangmog_name";
            this.xEditGridCell39.Col = 4;
            this.xEditGridCell39.HeaderText = "hangmog_name";
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "suryang";
            this.xEditGridCell40.Col = 5;
            this.xEditGridCell40.HeaderText = "数量";
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "nalsu";
            this.xEditGridCell41.Col = 6;
            this.xEditGridCell41.HeaderText = "日数";
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "ord_danui";
            this.xEditGridCell42.Col = 7;
            this.xEditGridCell42.HeaderText = "単位";
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "bogyong_code";
            this.xEditGridCell43.Col = 8;
            this.xEditGridCell43.HeaderText = "bogyong_code";
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "jusa_code";
            this.xEditGridCell44.Col = 9;
            this.xEditGridCell44.HeaderText = "jusa_code";
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "jusa_spd_gubun";
            this.xEditGridCell45.Col = 10;
            this.xEditGridCell45.HeaderText = "jusa_spd_gubun";
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "dv";
            this.xEditGridCell46.Col = 11;
            this.xEditGridCell46.HeaderText = "dv";
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "dv_time";
            this.xEditGridCell47.Col = 12;
            this.xEditGridCell47.HeaderText = "dv_time";
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "fkocs2003";
            this.xEditGridCell48.Col = 13;
            this.xEditGridCell48.HeaderText = "fkocs2003";
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "bom_yn";
            this.xEditGridCell52.Col = 14;
            this.xEditGridCell52.HeaderText = "bom_yn";
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "bom_source_key";
            this.xEditGridCell53.Col = 15;
            this.xEditGridCell53.HeaderText = "bom_source_key";
            // 
            // grdOCS2015
            // 
            this.grdOCS2015.CallerID = '5';
            this.grdOCS2015.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell23,
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
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56});
            this.grdOCS2015.ColPerLine = 14;
            this.grdOCS2015.Cols = 14;
            this.grdOCS2015.FixedRows = 1;
            this.grdOCS2015.HeaderHeights.Add(21);
            this.grdOCS2015.Location = new System.Drawing.Point(357, 331);
            this.grdOCS2015.Name = "grdOCS2015";
            this.grdOCS2015.QuerySQL = resources.GetString("grdOCS2015.QuerySQL");
            this.grdOCS2015.Rows = 2;
            this.grdOCS2015.Size = new System.Drawing.Size(506, 218);
            this.grdOCS2015.TabIndex = 77;
            this.grdOCS2015.UseDefaultTransaction = false;
            this.grdOCS2015.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS2015_QueryEnd);
            this.grdOCS2015.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS2015_QueryStarting);
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "pkocs2015";
            this.xEditGridCell23.HeaderText = "pkocs2015";
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "bunho";
            this.xEditGridCell24.Col = 1;
            this.xEditGridCell24.HeaderText = "bunho";
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "fkinp1001";
            this.xEditGridCell25.Col = 2;
            this.xEditGridCell25.HeaderText = "fkinp1001";
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "order_date";
            this.xEditGridCell26.Col = 3;
            this.xEditGridCell26.HeaderText = "order_date";
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "input_gubun";
            this.xEditGridCell27.Col = 4;
            this.xEditGridCell27.HeaderText = "input_gubun";
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "pk_seq";
            this.xEditGridCell28.Col = 5;
            this.xEditGridCell28.HeaderText = "pk_seq";
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "seq";
            this.xEditGridCell29.Col = 6;
            this.xEditGridCell29.HeaderText = "seq";
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.BindControl = this.dtpAct_date;
            this.xEditGridCell30.CellName = "act_date";
            this.xEditGridCell30.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell30.Col = 7;
            this.xEditGridCell30.HeaderText = "act_date";
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "act_id";
            this.xEditGridCell31.Col = 8;
            this.xEditGridCell31.HeaderText = "act_id";
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "act_result_code";
            this.xEditGridCell32.Col = 9;
            this.xEditGridCell32.HeaderText = "act_result_code";
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellLen = 400;
            this.xEditGridCell33.CellName = "act_result_text";
            this.xEditGridCell33.Col = 10;
            this.xEditGridCell33.HeaderText = "act_result_text";
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "input_id";
            this.xEditGridCell54.Col = 11;
            this.xEditGridCell54.HeaderText = "input_id";
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "input_gwa";
            this.xEditGridCell55.Col = 12;
            this.xEditGridCell55.HeaderText = "input_gwa";
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "input_doctor";
            this.xEditGridCell56.Col = 13;
            this.xEditGridCell56.HeaderText = "input_doctor";
            // 
            // txtAct_result_text
            // 
            this.txtAct_result_text.AllowDrop = true;
            this.txtAct_result_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAct_result_text.Location = new System.Drawing.Point(0, 0);
            this.txtAct_result_text.Multiline = true;
            this.txtAct_result_text.Name = "txtAct_result_text";
            this.txtAct_result_text.Size = new System.Drawing.Size(684, 64);
            this.txtAct_result_text.TabIndex = 72;
            this.txtAct_result_text.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtAct_result_text_DragDrop);
            this.txtAct_result_text.DragEnter += new System.Windows.Forms.DragEventHandler(this.Grid_DragEnter);
            this.txtAct_result_text.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Grid_GiveFeedback);
            this.txtAct_result_text.TextChanged += new System.EventHandler(this.txtAct_result_text_TextChanged);
            // 
            // grdOCS2006
            // 
            this.grdOCS2006.ApplyPaintEventToAllColumn = true;
            this.grdOCS2006.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell34,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell49,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell57});
            this.grdOCS2006.ColPerLine = 5;
            this.grdOCS2006.ColResizable = true;
            this.grdOCS2006.Cols = 5;
            this.grdOCS2006.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS2006.FixedRows = 1;
            this.grdOCS2006.HeaderHeights.Add(21);
            this.grdOCS2006.Location = new System.Drawing.Point(0, 33);
            this.grdOCS2006.Name = "grdOCS2006";
            this.grdOCS2006.QuerySQL = resources.GetString("grdOCS2006.QuerySQL");
            this.grdOCS2006.Rows = 2;
            this.grdOCS2006.Size = new System.Drawing.Size(449, 197);
            this.grdOCS2006.TabIndex = 77;
            this.grdOCS2006.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Grid_MouseDown);
            this.grdOCS2006.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdOCS2006_ItemValueChanging);
            this.grdOCS2006.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS2006_QueryEnd);
            this.grdOCS2006.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS2006_QueryStarting);
            this.grdOCS2006.Click += new System.EventHandler(this.grdOCS2006_Click);
            this.grdOCS2006.DragEnter += new System.Windows.Forms.DragEventHandler(this.Grid_DragEnter);
            this.grdOCS2006.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS2006_GridCellPainting);
            this.grdOCS2006.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Grid_GiveFeedback);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "chk";
            this.xEditGridCell1.CellWidth = 28;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell1.HeaderText = "選択";
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "fkocs2005";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.HeaderText = "fkocs2005";
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "hangmog_code";
            this.xEditGridCell2.CellWidth = 211;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "hangmog_code";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "hangmog_name";
            this.xEditGridCell3.CellWidth = 295;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.HeaderText = "指示項目";
            this.xEditGridCell3.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "suryang";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell4.CellWidth = 37;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.HeaderText = "数量";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "ord_danui";
            this.xEditGridCell5.CellWidth = 49;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell5.HeaderText = "単位";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "dv";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "dv";
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "dv_time";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "dv_time";
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "nalsu";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.HeaderText = "日数";
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "bogyong_code";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "bogyong_code";
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "jusa_code";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "jusa_code";
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "jusa_spd_gubun";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "jusa_spd_gubun";
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "bunho";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "bunho";
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "fkinp1001";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "fkinp1001";
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "order_date";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "order_date";
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "input_gubun";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "input_gubun";
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "pk_seq";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderText = "pk_seq";
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "seq";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderText = "seq";
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "direct_gubun";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.HeaderText = "direct_gubun";
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "direct_code";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "direct_code";
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "direct_detail";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.HeaderText = "direct_detail";
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.ApplyPaintingEvent = true;
            this.xEditGridCell50.CellName = "bom_yn";
            this.xEditGridCell50.CellWidth = 18;
            this.xEditGridCell50.Col = 1;
            this.xEditGridCell50.IsReadOnly = true;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "bom_source_key";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.HeaderText = "bom_source_key";
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "jaeryo_yn";
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.HeaderText = "材料YN";
            this.xEditGridCell57.IsReadOnly = true;
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            // 
            // grdNUR0114
            // 
            this.grdNUR0114.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell22,
            this.xEditGridCell20,
            this.xEditGridCell21});
            this.grdNUR0114.ColPerLine = 1;
            this.grdNUR0114.Cols = 1;
            this.grdNUR0114.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR0114.FixedRows = 1;
            this.grdNUR0114.HeaderHeights.Add(21);
            this.grdNUR0114.Location = new System.Drawing.Point(0, 33);
            this.grdNUR0114.Name = "grdNUR0114";
            this.grdNUR0114.QuerySQL = resources.GetString("grdNUR0114.QuerySQL");
            this.grdNUR0114.Rows = 2;
            this.grdNUR0114.RowStateCheckOnPaint = false;
            this.grdNUR0114.Size = new System.Drawing.Size(235, 197);
            this.grdNUR0114.TabIndex = 71;
            this.grdNUR0114.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Grid_MouseDown);
            this.grdNUR0114.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdNUR0114_ItemValueChanging);
            this.grdNUR0114.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR0114_QueryStarting);
            this.grdNUR0114.DragEnter += new System.Windows.Forms.DragEventHandler(this.Grid_DragEnter);
            this.grdNUR0114.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Grid_GiveFeedback);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "chk";
            this.xEditGridCell22.CellWidth = 218;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.HeaderText = "入力";
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "nur_so_code";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.HeaderText = "nur_so_code";
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "nur_act_name";
            this.xEditGridCell21.CellWidth = 214;
            this.xEditGridCell21.HeaderText = "コメント";
            this.xEditGridCell21.IsReadOnly = true;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "+.gif");
            this.imageList.Images.SetKeyName(1, "오른쪽_회색1.gif");
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlCenter);
            this.pnlBody.Controls.Add(this.pnlBottom);
            this.pnlBody.Controls.Add(this.grdOCS2015);
            this.pnlBody.Controls.Add(this.grdOCS2016);
            this.pnlBody.Controls.Add(this.xFlatLabel2);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 30);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(684, 330);
            this.pnlBody.TabIndex = 79;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdOCS2006);
            this.xPanel1.Controls.Add(this.xPanel2);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(449, 230);
            this.xPanel1.TabIndex = 79;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xFlatLabel3);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel2.Location = new System.Drawing.Point(0, 0);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(449, 33);
            this.xPanel2.TabIndex = 0;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdNUR0114);
            this.xPanel3.Controls.Add(this.xPanel4);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.xPanel3.Location = new System.Drawing.Point(449, 0);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(235, 230);
            this.xPanel3.TabIndex = 80;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.xFlatLabel4);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel4.Location = new System.Drawing.Point(0, 0);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(235, 33);
            this.xPanel4.TabIndex = 80;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.xPanel1);
            this.pnlCenter.Controls.Add(this.xPanel3);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(684, 230);
            this.pnlCenter.TabIndex = 81;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.txtAct_result_text);
            this.pnlBottom.Controls.Add(this.pnlBottomUnder);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 230);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(684, 100);
            this.pnlBottom.TabIndex = 82;
            // 
            // frmTreatmentActing
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(684, 382);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTreatmentActing";
            this.Load += new System.EventHandler(this.frmDirectActing_Load);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottomUnder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2016)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2015)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2006)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0114)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region [Form]

        private void frmDirectActing_Load(object sender, System.EventArgs e)
        {
            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private string firstInput = "Y";

        private void PostLoad()
        {
            dtpAct_date.SetDataValue(mOrder_date);  //EnvironInfo.GetSysDate());
            dpbAct_id_name.SetDataValue(mUser_name);

            CreateCombo();

            if (TypeCheck.IsNull(mBunho)) this.DialogResult = DialogResult.Cancel;
            if (!TypeCheck.IsInt(mFkinp1001)) this.DialogResult = DialogResult.Cancel;
            if (!TypeCheck.IsDateTime(mOrder_date)) this.DialogResult = DialogResult.Cancel;
            if (!TypeCheck.IsInt(mOcs2005_seq)) this.DialogResult = DialogResult.Cancel;
            if (TypeCheck.IsNull(mDirect_gubun)) this.DialogResult = DialogResult.Cancel;
            if (TypeCheck.IsNull(mDirect_code)) this.DialogResult = DialogResult.Cancel;
            if (TypeCheck.IsNull(mUser_id)) this.DialogResult = DialogResult.Cancel;

            DataQuery();

            if (grdOCS2015.RowCount <= 0)
            {
                string cmdText = @"SELECT DIRECT_TEXT FROM OCS2005 WHERE HOSP_CODE = '" + mHospCode + "' AND PKOCS2005 = '" + mPkOCS2005 + "'";

                object text = Service.ExecuteScalar(cmdText);

                txtAct_result_text.SetDataValue(text);
            }
        }

        private void DataQuery()
        {
            grdOCS2006.Reset();
            grdNUR0114.Reset();
            grdOCS2015.Reset();
            grdOCS2016.Reset();

            if (!grdOCS2006.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            if (!grdNUR0114.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            if (!grdOCS2015.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }

        private string GetPKOCS(string ocsGubun)
        {
            string pkocs = "";
            string cmdText = "";
            if (ocsGubun.Equals("2015"))
            {
                cmdText = "SELECT OCS2015_SEQ.NEXTVAL FROM DUAL";
                pkocs = Service.ExecuteScalar(cmdText).ToString();
            }
            else if (ocsGubun.Equals("2016"))
            {
                cmdText = "SELECT OCS2016_SEQ.NEXTVAL FROM DUAL";
                pkocs = Service.ExecuteScalar(cmdText).ToString();
            }

            return pkocs;
        }
        #endregion

        #region CreateCombo() / CreateCombo(string hangmogCode)
        private void CreateCombo()
        {
            MultiLayout layCombo = new MultiLayout();
            layCombo.LayoutItems.Add("code", DataType.String);
            layCombo.LayoutItems.Add("code_name", DataType.String);
            layCombo.InitializeLayoutTable();

            layCombo.QuerySQL = @"SELECT CODE, CODE_NAME
                                    FROM OCS0132
                                   WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE
                                     AND CODE_TYPE = 'ORD_DANUI'
                                   ORDER BY CODE";

            if (layCombo.QueryLayout(false))
            {
                grdOCS2006.SetComboItems("ord_danui", layCombo.LayoutTable, "code_name", "code", XComboSetType.AppendNone);
            }
            ((XComboBox)((XEditGridCell)grdOCS2006.CellInfos["ord_danui"]).CellEditor.Editor).DropDownWidth = 100;
        }

        private void CreateCombo(string hangmogCode)
        {
            MultiLayout layCombo = new MultiLayout();
            layCombo.LayoutItems.Add("code", DataType.String);
            layCombo.LayoutItems.Add("code_name", DataType.String);
            layCombo.InitializeLayoutTable();

            layCombo.QuerySQL = @"SELECT B.ORD_DANUI
                                       , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI)  ORD_NAME
                                    FROM OCS0103 A
                                       , OCS0108 B
                                   WHERE A.HOSP_CODE            = :f_hosp_code
                                     AND A.HANGMOG_CODE         = :f_hangmog_code
                                     AND TRUNC(SYSDATE)   BETWEEN A.START_DATE
                                                              AND NVL(A.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))
                                     AND B.HOSP_CODE            = A.HOSP_CODE
                                     AND B.HANGMOG_CODE         = A.HANGMOG_CODE
                                     AND B.HANGMOG_START_DATE   = A.START_DATE";
            layCombo.SetBindVarValue("f_hangmog_code", hangmogCode);
            layCombo.SetBindVarValue("f_hosp_code", mHospCode);

            if (layCombo.QueryLayout(false))
            {
                grdOCS2006.SetComboItems("ord_danui", layCombo.LayoutTable, "code_name", "code");
            }

            ((XComboBox)((XEditGridCell)grdOCS2006.CellInfos["ord_danui"]).CellEditor.Editor).DropDownWidth = 100;
        }
        #endregion

        #region [properties]

        public string BUNHO
        {
            get
            {
                return mBunho;
            }
            set
            {
                mBunho = value;
            }
        }

        public string FKINP1001
        {
            get
            {
                return mFkinp1001;
            }
            set
            {
                mFkinp1001 = value;
            }
        }

        public string ORDER_DATE
        {
            get
            {
                return mOrder_date;
            }
            set
            {
                mOrder_date = value;
            }
        }

        public string INPUT_GUBUN
        {
            get
            {
                return mInput_gubun;
            }
            set
            {
                mInput_gubun = value;
            }
        }

        public string OCS2005_SEQ
        {
            get
            {
                return mOcs2005_seq;
            }
            set
            {
                mOcs2005_seq = value;
            }
        }

        public string DIRECT_GUBUN
        {
            get
            {
                return mDirect_gubun;
            }
            set
            {
                mDirect_gubun = value;
            }
        }

        public string DIRECT_CODE
        {
            get
            {
                return mDirect_code;
            }
            set
            {
                mDirect_code = value;
            }
        }

        public string ACTING_YN
        {
            get
            {
                return mActing_yn;
            }
            set
            {
                mActing_yn = value;
            }
        }

        public string USER_ID
        {
            get
            {
                return mUser_id;
            }
            set
            {
                mUser_id = value;
                mUser_name = GetAdminUSER_NAME(mUser_id);
            }
        }

        public string CAN_ACTING_YN
        {
            get
            {
                return mCan_acting_yn;
            }
            set
            {
                mCan_acting_yn = value;
            }
        }

        public string DIRECT_CONT
        {
            get
            {
                return mDirect_cont;
            }
            set
            {
                mDirect_cont = value;
            }
        }

        public string PKOCS2005
        {
            get
            {
                return mPkOCS2005;
            }
            set
            {
                mPkOCS2005 = value;
            }
        }

        public string PKOCS6015
        {
            get
            {
                return mPkOCS6015;
            }
            set
            {
                mPkOCS6015 = value;
            }
        }

        public string SOURCE_ORDER_DATE
        {
            get
            {
                return mSource_order_date;
            }
            set
            {
                mSource_order_date = value;
            }
        }

        #endregion

        #region [grdNUR0114]

        private void grdNUR0114_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
			int curRowIndex = -1;			
			
			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
                curRowIndex = grdNUR0114.GetHitRowNumber(e.Y);
                if (curRowIndex < 0) return;
                string result_text = txtAct_result_text.GetDataValue() + " " + grdNUR0114.GetItemString(curRowIndex, "nur_act_name");
                txtAct_result_text.SetEditValue(result_text);
				
				txtAct_result_text.Focus();
				txtAct_result_text.SelectionStart = txtAct_result_text.Text.Length;
			}
			else if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
                curRowIndex = grdNUR0114.GetHitRowNumber(e.Y);
                if (curRowIndex < 0) return;

                string dragInfo = grdNUR0114.GetItemString(curRowIndex, "nur_act_name");
                DragHelper.CreateDragCursor(grdNUR0114, dragInfo, this.Font);
                txtAct_result_text.DoDragDrop("条件 | " + grdNUR0114.GetItemString(curRowIndex, "nur_act_name"), DragDropEffects.Move);	
			}
        }

        private void grdNUR0114_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;  // Move 표시		
        }

        private void grdNUR0114_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        #endregion

        #region [grdOCS2006]

        private void Grid_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                string result_text = string.Empty;

                if (grd.GetHitRowNumber(e.Y) < 0) return;

                if(grd.Name.Contains("2006")) result_text = txtAct_result_text.GetDataValue() + " " + grd.GetItemString(grd.GetHitRowNumber(e.Y), "hangmog_name");
                else result_text = txtAct_result_text.GetDataValue() + " " + grd.GetItemString(grd.GetHitRowNumber(e.Y), "nur_act_name");

                txtAct_result_text.SetEditValue(result_text);
                txtAct_result_text.Focus();
                txtAct_result_text.SelectionStart = txtAct_result_text.Text.Length;
            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1 && (grd.CurrentColName == "hangmog_name" || grd.CurrentColName == "nur_act_name"))
            {
                Hashtable dragInfo = new Hashtable();

                if (grd.Name.Contains("2006")) dragInfo.Add("name", "【 " + grd.GetItemString(grd.CurrentRowNumber, "hangmog_name") + " 】");
                else dragInfo.Add("name", "【 " + grd.GetItemString(grd.CurrentRowNumber, "nur_act_name") + " 】");

                dragInfo.Add("grd", grd);

                DragHelper.CreateDragCursor(grd, dragInfo["name"].ToString(), this.Font);
                grd.DoDragDrop(dragInfo, DragDropEffects.Move);
            }
             /* */
        }

        private void Grid_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;  // Move 표시		
        }

        private void Grid_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void grdOCS2006_QueryEnd(object sender, QueryEndEventArgs e)
        {
            // 행위와 재료에 따른 부모자식 관계의 이미지 셋팅
            for (int i = 0; i < grdOCS2006.RowCount; i++)
            {
                if (grdOCS2006.GetItemString(i, "bom_yn").Equals("P"))
                {
                    grdOCS2006[i, "bom_yn"].Image = imageList.Images[0];
                }
                else if (grdOCS2006.GetItemString(i, "bom_yn").Equals("C"))
                {
                    grdOCS2006[i, "bom_yn"].Image = imageList.Images[1];
                }
            }
        }

        #endregion

        #region [Result_text Drag 처리]

        /// <summary>
        /// 내용코드 grid에서 Drag했을 경우 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAct_result_text_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Hashtable htTable = (Hashtable)e.Data.GetData("System.Collections.Hashtable");

            XEditGrid grd = new XEditGrid();

            grd = (XEditGrid)htTable["grd"];
            grd.SetItemValue(grd.CurrentRowNumber, "chk", "Y");

            // grd에 체크를 셋팅해줘도 이벤트를 타지 않기 때문에 이벤트 호출
            if (grd.Name.Contains("2006"))
                grdOCS2006_ItemValueChanging(grd, new ItemValueChangingEventArgs(grd.CurrentRowNumber, "chk", grd.LayoutTable.Rows[grd.CurrentRowNumber], "Y"));
            else
                grdNUR0114_ItemValueChanging(grd, new ItemValueChangingEventArgs(grd.CurrentRowNumber, "chk", grd.LayoutTable.Rows[grd.CurrentRowNumber], "Y"));
        }
        #endregion

        #region [ ActResultCode() - grdNUR0114 선택값 셋팅 - ]
        private string ActResultCode()
        {
            string resultCode = "";
            for (int i = 0; i < grdNUR0114.RowCount; i++)
            {
                if (grdNUR0114.GetItemString(i, "chk").Equals("Y"))
                {
                    resultCode = grdNUR0114.GetItemString(i, "nur_so_code");
                    break;
                }
            }

            return resultCode;
        }
        #endregion

        #region [사용자명]

        private string GetAdminUSER_NAME(string aUser_id)
        {
            string user_name = "";
            string cmdText = "";
            object retVal = null;
            BindVarCollection bindVars = new BindVarCollection();

            cmdText = @"SELECT USER_NM
                          FROM ADM3200
                         WHERE HOSP_CODE = :f_hosp_code
                           AND USER_ID   = :f_user_id";
            bindVars.Add("f_user_id", aUser_id);
            bindVars.Add("f_hosp_code", mHospCode);

            retVal = Service.ExecuteScalar(cmdText, bindVars);

            if (!TypeCheck.IsNull(retVal))
            {
                user_name = retVal.ToString();
            }

            return user_name;
        }

        #endregion

        #region [ grdNUR0114 & grdOCS2006 선택항목 result text 셋팅 ]
        private void grdNUR0114_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ChangeValue.Equals("N")) return;

            string text = txtAct_result_text.Text;

            text = text + " " + grdNUR0114.GetItemString(e.RowNumber, "nur_act_name");

            txtAct_result_text.SetDataValue(text);
            txtAct_result_text.Focus();
            txtAct_result_text.SelectionStart = txtAct_result_text.Text.Length;
        }

        private void grdOCS2006_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ChangeValue.Equals("N")) return;

            if (e.ColName.Equals("ord_danui")) return;

            GroupSelect(e.RowNumber, e.ColName, e.ChangeValue);

            string cmdText = @"SELECT CODE_NAME
                                 FROM OCS0132
                                WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE
                                  AND CODE_TYPE = 'ORD_DANUI'
                                  AND CODE = '" + grdOCS2006.GetItemString(e.RowNumber, "ord_danui") + @"'
                                ORDER BY CODE";

            object objDanui = Service.ExecuteScalar(cmdText);

            string danui = "";
            if (!TypeCheck.IsNull(objDanui))
            {
                danui = objDanui.ToString();
            }

            string text = txtAct_result_text.Text;

            text = text + " " + grdOCS2006.GetItemString(e.RowNumber, "hangmog_name") + " : "
                              + grdOCS2006.GetItemString(e.RowNumber, "suryang") + " "
                              + danui;

            txtAct_result_text.SetDataValue(text);
            txtAct_result_text.Focus();
            txtAct_result_text.SelectionStart = txtAct_result_text.Text.Length;
        }
        #endregion

        #region [ 각 그리드에 바인드변수 설정 - 쿼리 실행 시 - ]
        private void grdOCS2006_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS2006.SetBindVarValue("f_fkocs2005", mPkOCS2005);
            grdOCS2006.SetBindVarValue("f_pk_seq", mOcs2005_seq);
            grdOCS2006.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdNUR0114_QueryStarting(object sender, CancelEventArgs e)
        {
            grdNUR0114.SetBindVarValue("f_direct_gubun", mDirect_gubun);
            grdNUR0114.SetBindVarValue("f_direct_code", mDirect_code);
            grdNUR0114.SetBindVarValue("f_direct_detail", mDirect_cont);
            grdNUR0114.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdOCS2015_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS2015.SetBindVarValue("f_bunho",       mBunho);
            grdOCS2015.SetBindVarValue("f_fkinp1001",   mFkinp1001);
            grdOCS2015.SetBindVarValue("f_order_date",  mSource_order_date);
            grdOCS2015.SetBindVarValue("f_input_gubun", mInput_gubun);
            grdOCS2015.SetBindVarValue("f_pk_seq",      mOcs2005_seq);
            grdOCS2015.SetBindVarValue("f_act_date",    mOrder_date);
            grdOCS2015.SetBindVarValue("f_hosp_code",   mHospCode);
        }

        private void grdOCS2016_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS2016.SetBindVarValue("f_fkocs2015", grdOCS2015.GetItemString(grdOCS2015.CurrentRowNumber, "pkocs2015"));
            grdOCS2016.SetBindVarValue("f_hosp_code", mHospCode);
        }
        #endregion

        #region [ grdOCS2006 의 그룹 일괄선택 ]
        /// <summary>
        /// 행위에 포함된 재료코드 로우를 그룹으로 선택한다.
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="colName"></param>
        /// <param name="changeValue"></param>
        private void GroupSelect(int rowNumber, string colName, object changeValue)
        {
            if (changeValue.Equals("N")) return;

            int row = -1;

            if (grdOCS2006.GetItemString(rowNumber, "bom_yn").Equals("P"))
            {
                grdOCS2006.SetItemValue(row, "chk", "Y");
                row = rowNumber + 1;
            }
            else if (grdOCS2006.GetItemString(rowNumber, "bom_yn").Equals("C"))
            {
                for (int i = rowNumber; i > 0; i--)
                {
                    if (grdOCS2006.GetItemString(i, "bom_yn").Equals("P"))
                    {
                        row = i;
                        break;
                    }
                }
            }

            for (int i = row; i < grdOCS2006.RowCount; i++)
            {
                if (grdOCS2006.GetItemString(i, "bom_yn").Equals("C"))
                {
                    grdOCS2006.SetItemValue(i, "chk", "Y");
                    grdOCS2006.SelectRow(i);
                }
                else if (grdOCS2006.GetItemString(i, "bom_yn").Equals("P"))
                {
                    return;
                }
            }
        }
        #endregion

        #region grdOCS2006 Click - 항목코드에 맞는 오더단위를 조회 -
        private void grdOCS2006_Click(object sender, EventArgs e)
        {
            if (this.grdOCS2006.CurrentColName == "ord_danui")
            {
                CreateCombo(grdOCS2006.GetItemString(grdOCS2006.CurrentRowNumber, "hangmog_code"));
            }
        }
        #endregion

        #region [ result text 변경값 grdOCS2015 적용 ]
        private void txtAct_result_text_TextChanged(object sender, EventArgs e)
        {
            grdOCS2015.SetItemValue(grdOCS2015.CurrentRowNumber, "act_result_text", txtAct_result_text.Text);
        }
        #endregion



        #region [ grdOCS2015 QueryEnd Event ]
        private void grdOCS2015_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (grdOCS2015.RowCount > 0)
            {
                if (!grdOCS2016.QueryLayout(false))
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                }

                txtAct_result_text.ResetText();
                txtAct_result_text.SetEditValue(grdOCS2015.GetItemString(0, "act_result_text"));
            }
        }
        #endregion

        #region PreSaveLayout() - 오더발생그리드 셋팅 -
        /// <summary>
        /// 발생시킬 오더항목그리드(grdOCS2015 및 grdOCS2016)에 로우 추가와 셋팅을 해준다.
        /// </summary>
        private void PreSaveLayout()
        {
            //Insert
            if (grdOCS2015.RowCount < 1)
            {
                firstInput = "Y";
                int insertRow = grdOCS2015.InsertRow();
                grdOCS2015.SetItemValue(insertRow, "bunho",         mBunho);
                grdOCS2015.SetItemValue(insertRow, "fkinp1001",     mFkinp1001);
                grdOCS2015.SetItemValue(insertRow, "order_date",    mSource_order_date);
                grdOCS2015.SetItemValue(insertRow, "input_gubun",   mInput_gubun);
                grdOCS2015.SetItemValue(insertRow, "pk_seq",        mOcs2005_seq);

                grdOCS2015.SetItemValue(insertRow, "act_id",        mUser_id);
                grdOCS2015.SetItemValue(insertRow, "act_date",      dtpAct_date.GetDataValue());
                grdOCS2015.SetItemValue(insertRow, "input_id",      mUser_id);
                grdOCS2015.SetItemValue(insertRow, "input_gwa",     mInput_gwa);
                grdOCS2015.SetItemValue(insertRow, "input_doctor",  mInput_doctor);

                grdOCS2015.SetItemValue(insertRow, "pkocs2015",     GetPKOCS("2015"));
                grdOCS2015.SetItemValue(insertRow, "act_result_code", ActResultCode());

            }
            else
            {
                firstInput = "N";
                grdOCS2015.SetItemValue(0, "act_id",            mUser_id);
                grdOCS2015.SetItemValue(0, "act_date",          dtpAct_date.GetDataValue());
                grdOCS2015.SetItemValue(0, "act_result_code",   ActResultCode());
            }
            grdOCS2015.SetItemValue(0, "act_result_text", txtAct_result_text.Text);

            if (firstInput == "N")
            {
                DialogResult result = XMessageBox.Show("既に入力されたオーダがあります。新しくオーダを追加しますか？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No) return;
            }

            //의사가 내린 지시사항에 수정을 한 후, 오더발생 항목을 체크하면 체크된 항목수 만큼 오더발생시킨다.                    
            for (int i = 0; i < grdOCS2006.RowCount; i++)
            {
                int insertRow = -1;
                if (grdOCS2006.GetItemString(i, "chk").Equals("Y"))
                {
                    insertRow = grdOCS2016.InsertRow(-1);

                    grdOCS2016.SetItemValue(insertRow, "fkocs2015",     grdOCS2015.GetItemString(grdOCS2015.CurrentRowNumber, "pkocs2015"));
                    grdOCS2016.SetItemValue(insertRow, "hangmog_code",  grdOCS2006.GetItemString(i, "hangmog_code"));
                    grdOCS2016.SetItemValue(insertRow, "suryang",       grdOCS2006.GetItemString(i, "suryang"));
                    grdOCS2016.SetItemValue(insertRow, "nalsu",         grdOCS2006.GetItemString(i, "nalsu"));
                    grdOCS2016.SetItemValue(insertRow, "ord_danui",     grdOCS2006.GetItemString(i, "ord_danui"));
                    grdOCS2016.SetItemValue(insertRow, "bogyong_code",  grdOCS2006.GetItemString(i, "bogyong_code"));
                    grdOCS2016.SetItemValue(insertRow, "jusa_code",     grdOCS2006.GetItemString(i, "jusa_code"));
                    grdOCS2016.SetItemValue(insertRow, "jusa_spd_gubun", grdOCS2006.GetItemString(i, "jusa_spd_gubun"));
                    grdOCS2016.SetItemValue(insertRow, "dv",            grdOCS2006.GetItemString(i, "dv"));
                    grdOCS2016.SetItemValue(insertRow, "dv_time",       grdOCS2006.GetItemString(i, "dv_time"));
                    grdOCS2016.SetItemValue(insertRow, "bom_yn",        grdOCS2006.GetItemString(i, "bom_yn"));
                    grdOCS2016.SetItemValue(insertRow, "bom_source_key", grdOCS2006.GetItemString(i, "bom_source_key"));
                }
            }
        }
        #endregion

        #region [ValidationCheck]
        private bool IsUpdateCheck()
        {
            int ActOrderCnt = 0;
            int MaterialOrderCnt = 0;

            int SelectedActOrderCnt = 0;
            int SelectedMaterialOrderCnt = 0;

            int SelectedOrderCnt = 0;

            string msg = "";
            string cap = "確認";

            for (int i = 0; i < this.grdOCS2006.DisplayRowCount; i++)
            {
                if (this.grdOCS2006.GetItemString(i, "jaeryo_yn") == "N")
                    ActOrderCnt++;
                else
                    MaterialOrderCnt++;

                if (this.grdOCS2006.GetItemString(i, "chk") == "Y")
                {
                    SelectedOrderCnt++;

                    if (this.grdOCS2006.GetItemString(i, "jaeryo_yn") == "N")
                        SelectedActOrderCnt++;
                    else
                        SelectedMaterialOrderCnt++;
                }
            }

            if (SelectedOrderCnt == 0)
                msg = "「選択オーダー」がありません。";
            if (ActOrderCnt > 0 && SelectedActOrderCnt == 0)
                msg += "\r\n「行為オーダー」が選択されていません。";
            if (MaterialOrderCnt > 0 && SelectedMaterialOrderCnt == 0)
                msg += "\r\n「材料オーダー」が選択されていません。";

            if (msg != "")
            {
                if (XMessageBox.Show(msg + "このまま処理しますか？", cap, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, MessageBoxIcon.Question) == DialogResult.No)
                    return false;
            }

            return true;
            
        }
        #endregion [ValidationCheck]

        #region [Button List Event]
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            string spName = ""; // 호출프로시져명

            switch (e.Func)
            {
                case FunctionType.Process:

                    e.IsBaseCall = false;

                    this.AcceptData();

                    if (this.IsUpdateCheck() == false)
                        return;

                    // 오더발생 그리드 세팅
                    PreSaveLayout();

                    try
                    {
                        Service.BeginTransaction();
                        if (grdOCS2015.SaveLayout())
                        {
                            if (grdOCS2016.RowCount > 0)
                            {
                                if (!grdOCS2016.SaveLayout()) throw new Exception(Service.ErrFullMsg);
                                
                                // 오더발생 프로시져
                                spName = "PR_OCS_DIRECT_ACT_ORDER_TREAT";

                                ArrayList inputList = new ArrayList();
                                ArrayList outputList = new ArrayList();
                                inputList.Add(grdOCS2015.GetItemString(0, "bunho"));
                                inputList.Add(grdOCS2015.GetItemString(0, "fkinp1001"));
                                inputList.Add(grdOCS2015.GetItemString(0, "order_date"));
                                inputList.Add(grdOCS2015.GetItemString(0, "input_gubun"));
                                inputList.Add(grdOCS2015.GetItemString(0, "pkocs2015"));
                                inputList.Add(grdOCS2015.GetItemString(0, "act_date"));
                                inputList.Add(grdOCS2015.GetItemString(0, "act_id"));

                                if (!Service.ExecuteProcedure(spName, inputList, outputList)) throw new Exception(Service.ErrFullMsg);
                                {
                                    if (!outputList[1].ToString().Equals("0"))  // flag
                                    {
                                        throw new Exception(outputList[0].ToString());
                                    }
                                }

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
                        mbxMsg = xe.Message;
                        mbxCap = "保存エラー";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        return;
                    }

                    mbxMsg = "保存が完了しました。";
                    SetMsg(mbxMsg);
                    mActing_yn = "Y";
                    this.DialogResult = DialogResult.OK;

                    if (DialogResult == DialogResult.OK) Service.CommitTransaction();
                    break;

                case FunctionType.Cancel:

                    e.IsBaseCall = false;

                    //acting 일자 null
                    dtpAct_date.SetDataValue("");
                    grdOCS2015.SetItemValue(grdOCS2015.CurrentRowNumber, "act_date", "");
                    grdOCS2015.SetItemValue(grdOCS2015.CurrentRowNumber, "act_id", "");

                    if (grdOCS2015.SaveLayout())
                    {
                        mbxMsg = "保存が完了しました。";
                        SetMsg(mbxMsg);
                        mActing_yn = "N";
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        mbxMsg = "保存に失敗しました。";
                        mbxMsg = mbxMsg + Service.ErrMsg;
                        mbxCap = "保存エラー";
                        XMessageBox.Show(mbxMsg, mbxCap);
                    }
                    break;


                case FunctionType.Close:

                    this.DialogResult = DialogResult.Cancel;
                    break;

                default:

                    break;
            }
        }
        #endregion


        #region XSavePerformaer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private frmTreatmentActing parent = null;
            public XSavePerformer(frmTreatmentActing parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                // 프로시져 입력 ArrayList
                ArrayList inputList = new ArrayList();
                ArrayList outputList = new ArrayList();
                // 프로시져명 변수
                string spName = "";

                switch (callerID)
                {
                    case '5':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"SELECT NVL(MAX(SEQ), 0) + 1 AS SEQ
                                              FROM OCS2015
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND BUNHO        = :f_bunho
                                               AND FKINP1001    = :f_fkinp1001
                                               AND ORDER_DATE   = :f_order_date
                                               AND INPUT_GUBUN  = :f_input_gubun
                                               AND PK_SEQ       = :f_pk_seq
                                               AND ACT_DATE     = :f_act_date";

                                object seq = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(seq))
                                {
                                    item.BindVarList.Remove("f_seq");
                                    item.BindVarList.Add("f_seq", seq.ToString());
                                }

                                cmdText = @"INSERT INTO OCS2015
                                                      ( SYS_DATE,     SYS_ID,        HOSP_CODE,      PKOCS2015,    BUNHO,    UPD_DATE,
                                                        FKINP1001,    ORDER_DATE,    INPUT_GUBUN,    INPUT_ID,
                                                        PK_SEQ,       SEQ,           DRT_DATE,       ACT_DATE,     ACT_ID,
                                                        ACT_RESULT_CODE,    ACT_RESULT_TEXT,         SURYANG        )
                                            VALUES    ( SYSDATE,      :q_user_id,    :f_hosp_code,   :f_pkocs2015, :f_bunho, SYSDATE,
                                                        :f_fkinp1001, :f_order_date, :f_input_gubun, :f_input_id,
                                                        :f_pk_seq,    :f_seq,        :f_order_date,  :f_act_date,  :f_act_id,
                                                        :f_act_result_code, :f_act_result_text,      :f_suryang     )";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE OCS2015
                                               SET UPD_DATE         = SYSDATE           ,
                                                   UPD_ID           = :q_user_id        ,
                                                   ACT_DATE         = :f_act_date       ,
                                                   ACT_ID           = :f_act_id         ,
                                                   ACT_RESULT_CODE  = :f_act_result_code,
                                                   ACT_RESULT_TEXT  = :f_act_result_text
                                             WHERE HOSP_CODE        = :f_hosp_code
                                               AND PKOCS2015        = :f_pkocs2015";
                                break;

                            case DataRowState.Deleted:
                                //                                cmdText = @"DELETE OCS2015
                                // WHERE PKOCS2015 = :f_pkocs2015
                                //   AND HOSP_CODE = :f_hosp_code";
                                break;
                        }
                        break;

                    case '6':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                string seq = "";

                                // pkocs2016값을 insert 일 경우에만 새로 넣어준다.
                                item.BindVarList.Remove("f_pkocs2016");
                                item.BindVarList.Add("f_pkocs2016", parent.GetPKOCS("2016"));

                                // seq
                                cmdText = @"SELECT NVL(MAX(SEQ), 0) + 1 AS SEQ
                                              FROM OCS2016
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND FKOCS2015 = :f_fkocs2015";
                                seq = Service.ExecuteScalar(cmdText, item.BindVarList).ToString();

                                item.BindVarList.Remove("f_seq");
                                item.BindVarList.Add("f_seq", seq);

                                cmdText = @"INSERT INTO OCS2016
                                                      ( SYS_DATE,     SYS_ID,          HOSP_CODE,       PKOCS2016,
                                                        FKOCS2015,    SEQ,             HANGMOG_CODE,    SURYANG,           NALSU,
                                                        ORD_DANUI,    BOGYONG_CODE,    JUSA_CODE,       JUSA_SPD_GUBUN,
                                                        DV,           DV_TIME,         TIME_GUBUN,      BOM_SOURCE_KEY,    BOM_YN       )
                                            VALUES    ( SYSDATE,      :q_user_id,      :f_hosp_code,    :f_pkocs2016,
                                                        :f_fkocs2015, :f_seq,          :f_hangmog_code, :f_suryang,        :f_nalsu,
                                                        :f_ord_danui, :f_bogyong_code, :f_jusa_code,    :f_jusa_spd_gubun,
                                                        :f_dv,        :f_dv_time,      :f_time_gubun,   :f_bom_source_key, :f_bom_yn    )";

                                //// grdOCS2016 Insert
                                //if (!Service.ExecuteNonQuery(cmdText, item.BindVarList)) return false;

                                //Service.CommitTransaction();

                                //// 오더발생 프로시져 호출
                                //spName = "PR_OCS_DIRECT_ACT_ORDER";
                                //inputList.Add(parent.grdOCS2015.GetItemString(0, "bunho"));
                                //inputList.Add(parent.grdOCS2015.GetItemString(0, "fkinp1001"));
                                //inputList.Add(parent.grdOCS2015.GetItemString(0, "order_date"));
                                //inputList.Add(parent.grdOCS2015.GetItemString(0, "input_gubun"));
                                //inputList.Add(parent.grdOCS2015.GetItemString(0, "pkocs2015"));
                                //inputList.Add(parent.grdOCS2015.GetItemString(0, "act_date"));
                                //inputList.Add(parent.grdOCS2015.GetItemString(0, "act_id"));

                                //if (!Service.ExecuteProcedure(spName, inputList, outputList)) return false;

                                //if (!outputList[1].ToString().Equals("0"))  // flag
                                //{
                                //    XMessageBox.Show(outputList[0].ToString());
                                //    return false;
                                //}

                                //return true;

                                break;

                            case DataRowState.Modified:
                                //                                cmdText = @"UPDATE OCS2016
                                //   SET UPD_DATE      = SYSDATE       ,
                                //       UPD_ID        = :q_user_id    ,
                                //       SURYANG       = :f_suryang    ,
                                //       NALSU         = :f_nalsu      ,
                                //       ORD_DANUI     = :f_ord_danui  ,
                                //       BOGYONG_CODE  = :f_bogyong_code,
                                //       JUSA_CODE     = :f_jusa_code  ,
                                //       JUSA_SPD_GUBUN= :f_jusa_spd_gubun,
                                //       DV            = :f_dv         ,
                                //       DV_TIME       = :f_dv_time
                                // WHERE PKOCS2016     = :f_pkocs2006
                                //   AND HOSP_CODE     = :f_hosp_code ";
                                break;

                            case DataRowState.Deleted:
                                //                                cmdText = @"DELETE OCS2016
                                // WHERE PKOCS2016 = :f_pkocs2016
                                //   AND HOSP_CODE = :f_hosp_code";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);

            }
        }
        #endregion

        private void grdNUR0114_GridButtonClick(object sender, GridButtonClickEventArgs e)
        {
            string text = txtAct_result_text.Text;

            text = text + " " + grdNUR0114.GetItemString(e.RowNumber, "nur_act_name");

            txtAct_result_text.SetDataValue(text);
        }

        private void grdOCS2006_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["jaeryo_yn"].ToString() == "N")
            {
                e.BackColor = Color.LightBlue;
            }
        }

    }
}

