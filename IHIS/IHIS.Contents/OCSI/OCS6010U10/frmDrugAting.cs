using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

using IHIS.Framework;

namespace IHIS.OCSI
{
	public class frmDrugActing : IHIS.Framework.XForm
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

        private ArrayList mPKOCS2016 = new ArrayList();
        // Hospital Code
        private string mHospCode     = EnvironInfo.HospCode;
		#endregion

        private XPanel xPanel2;
        private XDisplayBox dpbAct_id_name;
        private XDatePicker dtpAct_date;
        private XFlatLabel xFlatLabel1;
        private XFlatLabel xFlatLabel2;
        private XFlatLabel xFlatLabel3;
        private XFlatLabel xFlatLabel4;
        private XTextBox txtAct_result_text;
        private XPanel pnlBottom;
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
        private XEditGridCell xEditGridCell52;
        private XPanel pnlBody;
        private ImageList imageList1;
        private XCheckBox cbxAutoProcess;
        private XEditGridCell xEditGridCell53;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell55;
        private XGridHeader xGridHeader1;

        private System.ComponentModel.IContainer components = null;

        public frmDrugActing()
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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDrugActing));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.dpbAct_id_name = new IHIS.Framework.XDisplayBox();
            this.dtpAct_date = new IHIS.Framework.XDatePicker();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel2 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel4 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel3 = new IHIS.Framework.XFlatLabel();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.cbxAutoProcess = new IHIS.Framework.XCheckBox();
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
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.txtAct_result_text = new IHIS.Framework.XTextBox();
            this.grdOCS2006 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.grdNUR0114 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.pnlBody = new IHIS.Framework.XPanel();
            this.xPanel2.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2016)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2015)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2006)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0114)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel2
            // 
            this.xPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel2.BackgroundImage")));
            this.xPanel2.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel2.Controls.Add(this.dpbAct_id_name);
            this.xPanel2.Controls.Add(this.dtpAct_date);
            this.xPanel2.Controls.Add(this.xFlatLabel1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel2.Location = new System.Drawing.Point(0, 0);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(951, 30);
            this.xPanel2.TabIndex = 69;
            // 
            // dpbAct_id_name
            // 
            this.dpbAct_id_name.Location = new System.Drawing.Point(174, 5);
            this.dpbAct_id_name.Name = "dpbAct_id_name";
            this.dpbAct_id_name.Size = new System.Drawing.Size(127, 21);
            this.dpbAct_id_name.TabIndex = 61;
            // 
            // dtpAct_date
            // 
            this.dtpAct_date.IsJapanYearType = true;
            this.dtpAct_date.Location = new System.Drawing.Point(59, 5);
            this.dtpAct_date.Name = "dtpAct_date";
            this.dtpAct_date.Size = new System.Drawing.Size(110, 20);
            this.dtpAct_date.TabIndex = 60;
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xFlatLabel1.Location = new System.Drawing.Point(8, 5);
            this.xFlatLabel1.Name = "xFlatLabel1";
            this.xFlatLabel1.Size = new System.Drawing.Size(58, 20);
            this.xFlatLabel1.TabIndex = 59;
            this.xFlatLabel1.Text = "施行日";
            // 
            // xFlatLabel2
            // 
            this.xFlatLabel2.Image = ((System.Drawing.Image)(resources.GetObject("xFlatLabel2.Image")));
            this.xFlatLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xFlatLabel2.Location = new System.Drawing.Point(6, 201);
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
            this.xFlatLabel4.Location = new System.Drawing.Point(709, 16);
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
            this.xFlatLabel3.Location = new System.Drawing.Point(6, 16);
            this.xFlatLabel3.Name = "xFlatLabel3";
            this.xFlatLabel3.Size = new System.Drawing.Size(117, 23);
            this.xFlatLabel3.TabIndex = 73;
            this.xFlatLabel3.Text = "    オーダ発生薬剤";
            this.xFlatLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.pnlBottom.Controls.Add(this.cbxAutoProcess);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 316);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(951, 36);
            this.pnlBottom.TabIndex = 76;
            // 
            // cbxAutoProcess
            // 
            this.cbxAutoProcess.AutoSize = true;
            this.cbxAutoProcess.Location = new System.Drawing.Point(683, 11);
            this.cbxAutoProcess.Name = "cbxAutoProcess";
            this.cbxAutoProcess.Size = new System.Drawing.Size(101, 17);
            this.cbxAutoProcess.TabIndex = 1;
            this.cbxAutoProcess.Text = "自動投薬処理";
            this.cbxAutoProcess.UseVisualStyleBackColor = false;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(785, 3);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(163, 34);
            this.btnList.TabIndex = 0;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            this.btnList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnList_MouseDown);
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
            this.xEditGridCell48});
            this.grdOCS2016.ColPerLine = 14;
            this.grdOCS2016.Cols = 14;
            this.grdOCS2016.FixedRows = 1;
            this.grdOCS2016.HeaderHeights.Add(21);
            this.grdOCS2016.Location = new System.Drawing.Point(3, 465);
            this.grdOCS2016.Name = "grdOCS2016";
            this.grdOCS2016.QuerySQL = resources.GetString("grdOCS2016.QuerySQL");
            this.grdOCS2016.Rows = 2;
            this.grdOCS2016.Size = new System.Drawing.Size(935, 120);
            this.grdOCS2016.TabIndex = 78;
            this.grdOCS2016.UseDefaultTransaction = false;
            this.grdOCS2016.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS2016_QueryEnd);
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
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell52});
            this.grdOCS2015.ColPerLine = 14;
            this.grdOCS2015.Cols = 14;
            this.grdOCS2015.ControlBinding = true;
            this.grdOCS2015.FixedRows = 1;
            this.grdOCS2015.HeaderHeights.Add(21);
            this.grdOCS2015.Location = new System.Drawing.Point(4, 343);
            this.grdOCS2015.Name = "grdOCS2015";
            this.grdOCS2015.QuerySQL = resources.GetString("grdOCS2015.QuerySQL");
            this.grdOCS2015.Rows = 2;
            this.grdOCS2015.Size = new System.Drawing.Size(934, 116);
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
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Date;
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
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "input_id";
            this.xEditGridCell50.Col = 11;
            this.xEditGridCell50.HeaderText = "input_id";
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "input_doctor";
            this.xEditGridCell51.Col = 12;
            this.xEditGridCell51.HeaderText = "input_doctor";
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "input_gwa";
            this.xEditGridCell52.Col = 13;
            this.xEditGridCell52.HeaderText = "input_gwa";
            // 
            // txtAct_result_text
            // 
            this.txtAct_result_text.AllowDrop = true;
            this.txtAct_result_text.Location = new System.Drawing.Point(4, 224);
            this.txtAct_result_text.Multiline = true;
            this.txtAct_result_text.Name = "txtAct_result_text";
            this.txtAct_result_text.Size = new System.Drawing.Size(944, 59);
            this.txtAct_result_text.TabIndex = 72;
            this.txtAct_result_text.DragDrop += new System.Windows.Forms.DragEventHandler(this.Mouse_DragDrop);
            this.txtAct_result_text.DragEnter += new System.Windows.Forms.DragEventHandler(this.Mouse_DragEnter);
            this.txtAct_result_text.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Mouse_GiveFeedback);
            // 
            // grdOCS2006
            // 
            this.grdOCS2006.AddedHeaderLine = 1;
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
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55});
            this.grdOCS2006.ColPerLine = 9;
            this.grdOCS2006.Cols = 9;
            this.grdOCS2006.FixedRows = 2;
            this.grdOCS2006.HeaderHeights.Add(21);
            this.grdOCS2006.HeaderHeights.Add(0);
            this.grdOCS2006.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOCS2006.ImageList = this.imageList1;
            this.grdOCS2006.Location = new System.Drawing.Point(4, 42);
            this.grdOCS2006.Name = "grdOCS2006";
            this.grdOCS2006.QuerySQL = resources.GetString("grdOCS2006.QuerySQL");
            this.grdOCS2006.Rows = 3;
            this.grdOCS2006.RowStateCheckOnPaint = false;
            this.grdOCS2006.Size = new System.Drawing.Size(702, 157);
            this.grdOCS2006.TabIndex = 77;
            this.grdOCS2006.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEvent);
            this.grdOCS2006.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdOCS2006_ItemValueChanging);
            this.grdOCS2006.DoubleClick += new System.EventHandler(this.Grid_DoubleClick);
            this.grdOCS2006.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS2006_QueryStarting);
            this.grdOCS2006.Click += new System.EventHandler(this.grdOCS2006_Click);
            this.grdOCS2006.DragEnter += new System.Windows.Forms.DragEventHandler(this.Mouse_DragEnter);
            this.grdOCS2006.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS2006_GridCellPainting);
            this.grdOCS2006.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Mouse_GiveFeedback);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "chk";
            this.xEditGridCell1.CellWidth = 28;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell1.HeaderText = "選択";
            this.xEditGridCell1.ImageList = this.imageList1;
            this.xEditGridCell1.RowImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell1.RowImage")));
            this.xEditGridCell1.RowImageIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "YESEN1.ICO");
            this.imageList1.Images.SetKeyName(1, "YESUP1.ICO");
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
            this.xEditGridCell3.CellWidth = 226;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.HeaderText = "薬品名称";
            this.xEditGridCell3.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "suryang";
            this.xEditGridCell4.CellWidth = 37;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell4.HeaderText = "数量";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "ord_danui";
            this.xEditGridCell5.CellWidth = 54;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell5.HeaderText = "単位";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "dv";
            this.xEditGridCell6.CellWidth = 25;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell6.HeaderText = "dv";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.Row = 1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "dv_time";
            this.xEditGridCell7.CellWidth = 22;
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.HeaderText = "dv_time";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.Row = 1;
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
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "jusa_code_name";
            this.xEditGridCell53.CellWidth = 116;
            this.xEditGridCell53.Col = 6;
            this.xEditGridCell53.HeaderText = "注射";
            this.xEditGridCell53.IsReadOnly = true;
            this.xEditGridCell53.RowSpan = 2;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "jusa_spd_name";
            this.xEditGridCell54.CellWidth = 64;
            this.xEditGridCell54.Col = 8;
            this.xEditGridCell54.HeaderText = "速度単位";
            this.xEditGridCell54.IsReadOnly = true;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "bogyong_name";
            this.xEditGridCell55.CellWidth = 110;
            this.xEditGridCell55.Col = 7;
            this.xEditGridCell55.HeaderText = "服用法/注射速度";
            this.xEditGridCell55.IsReadOnly = true;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 4;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "回数";
            this.xGridHeader1.HeaderWidth = 22;
            // 
            // grdNUR0114
            // 
            this.grdNUR0114.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell22,
            this.xEditGridCell20,
            this.xEditGridCell21});
            this.grdNUR0114.ColPerLine = 2;
            this.grdNUR0114.Cols = 2;
            this.grdNUR0114.FixedRows = 1;
            this.grdNUR0114.HeaderHeights.Add(21);
            this.grdNUR0114.Location = new System.Drawing.Point(712, 42);
            this.grdNUR0114.Name = "grdNUR0114";
            this.grdNUR0114.QuerySQL = resources.GetString("grdNUR0114.QuerySQL");
            this.grdNUR0114.Rows = 2;
            this.grdNUR0114.RowStateCheckOnPaint = false;
            this.grdNUR0114.Size = new System.Drawing.Size(236, 157);
            this.grdNUR0114.TabIndex = 71;
            this.grdNUR0114.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEvent);
            this.grdNUR0114.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdNUR0114_ItemValueChanging);
            this.grdNUR0114.DoubleClick += new System.EventHandler(this.Grid_DoubleClick);
            this.grdNUR0114.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR0114_QueryStarting);
            this.grdNUR0114.DragEnter += new System.Windows.Forms.DragEventHandler(this.Mouse_DragEnter);
            this.grdNUR0114.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Mouse_GiveFeedback);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "chk";
            this.xEditGridCell22.CellWidth = 28;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell22.HeaderText = "選択";
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
            this.xEditGridCell21.CellWidth = 194;
            this.xEditGridCell21.Col = 1;
            this.xEditGridCell21.HeaderText = "コメント";
            this.xEditGridCell21.IsReadOnly = true;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.xFlatLabel3);
            this.pnlBody.Controls.Add(this.grdNUR0114);
            this.pnlBody.Controls.Add(this.grdOCS2016);
            this.pnlBody.Controls.Add(this.txtAct_result_text);
            this.pnlBody.Controls.Add(this.grdOCS2006);
            this.pnlBody.Controls.Add(this.grdOCS2015);
            this.pnlBody.Controls.Add(this.xFlatLabel4);
            this.pnlBody.Controls.Add(this.xFlatLabel2);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 30);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(951, 322);
            this.pnlBody.TabIndex = 79;
            // 
            // frmDrugActing
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(951, 374);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.xPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDrugActing";
            this.Load += new System.EventHandler(this.frmDirectActing_Load);
            this.Controls.SetChildIndex(this.xPanel2, 0);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2016)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2015)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2006)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0114)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Form]
        
		private void frmDirectActing_Load(object sender, System.EventArgs e)
		{
            string cmd = @"SELECT A.CODE_NAME
                             FROM OCS0132 A
                            WHERE A.HOSP_CODE = :f_hosp_code
                              AND A.CODE_TYPE = 'AUTO_JISI_PROCESS'
                              AND A.CODE      = 'AUTO_YN'";
            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_hosp_code", EnvironInfo.HospCode);

            object obj = Service.ExecuteScalar(cmd, bind);

            if (obj != null && obj.ToString() == "Y")
                this.cbxAutoProcess.Checked = true;
            else
                this.cbxAutoProcess.Checked = false;

			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

        private string firstInput = "Y";

		private void PostLoad()
		{
			if(TypeCheck.IsNull(mBunho)) this.DialogResult = DialogResult.Cancel;
			if(!TypeCheck.IsInt(mFkinp1001)) this.DialogResult = DialogResult.Cancel;
			if(!TypeCheck.IsDateTime(mOrder_date)) this.DialogResult = DialogResult.Cancel;
			if(!TypeCheck.IsInt(mOcs2005_seq)) this.DialogResult = DialogResult.Cancel;
			if(TypeCheck.IsNull(mDirect_gubun)) this.DialogResult = DialogResult.Cancel;
			if(TypeCheck.IsNull(mDirect_code)) this.DialogResult = DialogResult.Cancel;
			if(TypeCheck.IsNull(mUser_id)) this.DialogResult = DialogResult.Cancel;

            dtpAct_date.SetDataValue(mOrder_date);  //EnvironInfo.GetSysDate());
            dpbAct_id_name.SetDataValue(mUser_name);

            CreateCombo();

            DataQuery();
		}

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
                grdOCS2006.SetComboItems("ord_danui", layCombo.LayoutTable, "code_name", "code");
            }

            //this.mOrderBiz.SetNumCombo(this.grdOCS2006, "dv", false);
            this.mOrderBiz.SetNumCombo(this.grdOCS2006, "suryang", false);
        }

        private void CreateCombo(string hangmogCode)
        {
            MultiLayout layCombo = new MultiLayout();
            layCombo.LayoutItems.Add("code", DataType.String);
            layCombo.LayoutItems.Add("code_name", DataType.String);
            layCombo.InitializeLayoutTable();

            layCombo.QuerySQL = @"SELECT B.ORD_DANUI
                                       , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)  ORD_NAME
                                    FROM OCS0103 A
                                       , OCS0108 B
                                   WHERE A.HOSP_CODE          = :f_hosp_code
                                     AND A.HANGMOG_CODE       = :f_hangmog_code
                                     AND TRUNC(SYSDATE) BETWEEN A.START_DATE
                                                            AND NVL(A.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))
                                     AND B.HOSP_CODE          = A.HOSP_CODE
                                     AND B.HANGMOG_CODE       = A.HANGMOG_CODE
                                     AND B.HANGMOG_START_DATE = A.START_DATE";
            layCombo.SetBindVarValue("f_hangmog_code", hangmogCode);
            layCombo.SetBindVarValue("f_hosp_code", mHospCode);

            if (layCombo.QueryLayout(false))
            {
                grdOCS2006.SetComboItems("ord_danui", layCombo.LayoutTable, "code_name", "code");
            }

            ((XComboBox)((XEditGridCell)grdOCS2006.CellInfos["ord_danui"]).CellEditor.Editor).DropDownWidth = 100;
        }
        #endregion

        private void DataQuery()
        {
            grdOCS2006.Reset();
            grdNUR0114.Reset();
            grdOCS2015.Reset();

            if (!grdOCS2006.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            if (!grdNUR0114.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            if (!grdOCS2015.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }

        private string GetPKOCS(string ocsGubun)
        {
            string pkocs = "";
            string cmdText = "";
            if(ocsGubun.Equals("2015"))
            {
                cmdText = "SELECT OCS2015_SEQ.NEXTVAL FROM DUAL";
                pkocs = Service.ExecuteScalar(cmdText).ToString();
            }
            else if(ocsGubun.Equals("2016"))
            {
                cmdText = "SELECT OCS2016_SEQ.NEXTVAL FROM DUAL";
                pkocs = Service.ExecuteScalar(cmdText).ToString();
            }

            return pkocs;
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

        public string INPUT_GWA
        {
            get
            {
                return mInput_gwa;
            }
            set
            {
                mInput_gwa = value;
            }
        }

        public string INPUT_DOCTOR
        {
            get
            {
                return mInput_doctor;
            }
            set
            {
                mInput_doctor = value;
            }
        }

		#endregion

		#region [grdNUR0114]

		private void grdNUR0114_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            /*
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
            */
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

        private void grdOCS2006_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            /*
            if (e.Button == MouseButtons.Left && e.Clicks != 2 && !grdOCS2006.CurrentColName.Equals("hangmog_name")) return;

            int curRowIndex = -1;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                curRowIndex = grdOCS2006.GetHitRowNumber(e.Y);
                if (curRowIndex < 0) return;
                string result_text = txtAct_result_text.GetDataValue() + " " + grdOCS2006.GetItemString(curRowIndex, "hangmog_name");
                txtAct_result_text.SetEditValue(result_text);

                txtAct_result_text.Focus();
                txtAct_result_text.SelectionStart = txtAct_result_text.Text.Length;
            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                curRowIndex = grdOCS2006.GetHitRowNumber(e.Y);
                if (curRowIndex < 0) return;

                string dragInfo = grdOCS2006.GetItemString(curRowIndex, "hangmog_name");
                DragHelper.CreateDragCursor(grdOCS2006, dragInfo, this.Font);
                txtAct_result_text.DoDragDrop("薬品名 | " + grdOCS2006.GetItemString(curRowIndex, "hangmog_name"), DragDropEffects.Move);
            }
             * */
        }

        private void grdOCS2006_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;  // Move 표시		
        }

        private void grdOCS2006_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
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
			string result_text = txtAct_result_text.GetDataValue() + " " + e.Data.GetData("System.String").ToString().Split('|')[1];
			txtAct_result_text.SetEditValue(result_text);
			txtAct_result_text.Focus();
			txtAct_result_text.SelectionStart = txtAct_result_text.Text.Length;
		}

		private void txtAct_result_text_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;  // Move 표시			
		}

		private void txtAct_result_text_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{
				Cursor.Current = DragHelper.DragCursor;
			}			
		}

		#endregion

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

        #region [Button List Event]
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
            string spName = ""; // 호출프로시져명

			switch (e.Func)
			{
				case FunctionType.Process:
					
					e.IsBaseCall = false;
                    
					this.AcceptData();

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
                                else
                                {
                                    spName = "PR_OCS_DIRECT_ACT_ORDER";

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
                    DialogResult result = new DialogResult();
                    if (grdOCS2015.RowCount > 0)
                    {
                        result = XMessageBox.Show("実施記録を削除します。\n\rよろしいですか？", "実施記録削除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }

                    if (result == DialogResult.Yes)
                    {
                        String pkOCS2015 = grdOCS2015.GetItemString(grdOCS2015.CurrentRowNumber, "pkocs2015");

                        grdOCS2015.DeleteRow(grdOCS2015.CurrentRowNumber);

                        for (int i = 0; i < grdOCS2016.RowCount; i++)
                        {
                            if (grdOCS2016.GetItemString(i, "fkocs2015").Equals(pkOCS2015))
                            {
                                grdOCS2016.DeleteRow(i);
                                i--;
                            }
                        }
                    }

                    try
                    {
                        Service.BeginTransaction();
                        if (!grdOCS2015.SaveLayout()) throw new Exception(Service.ErrFullMsg);
                        if (!grdOCS2016.SaveLayout()) throw new Exception(Service.ErrFullMsg);
                    }
                    catch (Exception xe)
                    {
                        Service.RollbackTransaction();
                        mbxMsg = "保存に失敗しました。";
                        mbxMsg = mbxMsg + "\n\r" + xe.Message;
                        mbxCap = "保存エラー";
                        XMessageBox.Show(mbxMsg, mbxCap);
                    }

                    Service.CommitTransaction();
                    mbxMsg = "保存しました。";
                    SetMsg(mbxMsg);
                    mActing_yn = "N";
                    this.DialogResult = DialogResult.OK;

                    /*
                    if (grdOCS2015.SaveLayout())
					{
                        if (grdOCS2016.SaveLayout())
                        {
                            mbxMsg = "保存が完了しました。";
                            SetMsg(mbxMsg);
                            mActing_yn = "N";
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                        }
					}
					else
					{
                        mbxMsg = "保存に失敗しました。"; 
						mbxMsg = mbxMsg + Service.ErrMsg;
						mbxCap = "保存エラー";
						XMessageBox.Show(mbxMsg, mbxCap);
					}
                     */
					break;


				case FunctionType.Close:

					this.DialogResult = DialogResult.Cancel;
					break;

				default:

					break;
			}
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


        #region XSavePerformaer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private frmDrugActing parent = null;
            public XSavePerformer(frmDrugActing parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                item.BindVarList.Add("q_user_id", parent.USER_ID);
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
                                                      ( SYS_DATE,     SYS_ID,        HOSP_CODE,      PKOCS2015,    BUNHO,   UPD_DATE, UPD_ID,
                                                        FKINP1001,    ORDER_DATE,    INPUT_GUBUN,    INPUT_ID,     INPUT_GWA,   INPUT_DOCTOR,
                                                        PK_SEQ,       SEQ,           DRT_DATE,       ACT_DATE,     ACT_ID,
                                                        ACT_RESULT_CODE,    ACT_RESULT_TEXT,         SURYANG        )
                                            VALUES    ( SYSDATE,      :q_user_id,    :f_hosp_code,   :f_pkocs2015, :f_bunho, SYSDATE, :q_user_id,
                                                        :f_fkinp1001, :f_order_date, :f_input_gubun, :f_input_id,  :f_input_gwa, :f_input_doctor,
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
                                cmdText = @"DELETE OCS2015
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND PKOCS2015 = :f_pkocs2015";
                                break;
                        }
                        break;

                    case '6':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                string seq = "";
                                string pk_key = "";

                                // pkocs2016값을 insert 일 경우에만 새로 넣어준다.
                                //item.BindVarList.Remove("f_pkocs2016");
                                //item.BindVarList.Add("f_pkocs2016", parent.GetPKOCS("2016"));

                                // seq
                                cmdText = @"SELECT NVL(MAX(SEQ), 0) + 1 AS SEQ
                                              FROM OCS2016
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND FKOCS2015 = :f_fkocs2015";
                                seq = Service.ExecuteScalar(cmdText, item.BindVarList).ToString();

                                item.BindVarList.Remove("f_seq");
                                item.BindVarList.Add("f_seq", seq);
                                

                                cmdText = @"SELECT OCS2016_SEQ.NEXTVAL
                                              FROM SYS.DUAL";
                                pk_key = Service.ExecuteScalar(cmdText).ToString();
                                item.BindVarList.Remove("f_pk_key");
                                item.BindVarList.Add("f_pk_key", pk_key);

                                cmdText = @"INSERT INTO OCS2016
                                                      ( SYS_DATE,     SYS_ID,          HOSP_CODE,       PKOCS2016,
                                                        FKOCS2015,    SEQ,             HANGMOG_CODE,    SURYANG,           NALSU,
                                                        ORD_DANUI,    BOGYONG_CODE,    JUSA_CODE,       JUSA_SPD_GUBUN,
                                                        DV,           DV_TIME,         TIME_GUBUN,      BOM_SOURCE_KEY,    BOM_YN       )
                                            VALUES    ( SYSDATE,      :q_user_id,      :f_hosp_code,    :f_pk_key,
                                                        :f_fkocs2015, :f_seq,          :f_hangmog_code, :f_suryang,        :f_nalsu,
                                                        :f_ord_danui, :f_bogyong_code, :f_jusa_code,    :f_jusa_spd_gubun,
                                                        :f_dv,        :f_dv_time,      :f_time_gubun,   :f_bom_source_key, :f_bom_yn    )";

                                parent.mPKOCS2016.Add(pk_key);

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
                                cmdText = @"DELETE OCS2016
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND PKOCS2016 = :f_pkocs2016";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);

            }
        }
        #endregion

        #region [ 각 그리드에 바인드변수 설정 - 쿼리 실행 시 - ]
        private void grdOCS2006_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS2006.SetBindVarValue("f_fkocs2005", mPkOCS2005);
            grdOCS2006.SetBindVarValue("f_pk_seq",    mOcs2005_seq);
            grdOCS2006.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdNUR0114_QueryStarting(object sender, CancelEventArgs e)
        {
            grdNUR0114.SetBindVarValue("f_direct_gubun",  mDirect_gubun);
            grdNUR0114.SetBindVarValue("f_direct_code",   mDirect_code);
            grdNUR0114.SetBindVarValue("f_direct_detail", mDirect_cont);
            grdNUR0114.SetBindVarValue("f_hosp_code",     mHospCode);
        }

        private void grdOCS2015_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS2015.SetBindVarValue("f_bunho",       mBunho);
            grdOCS2015.SetBindVarValue("f_fkinp1001",   mFkinp1001);
            grdOCS2015.SetBindVarValue("f_order_date",  mSource_order_date);
            grdOCS2015.SetBindVarValue("f_act_date",    mOrder_date);
            grdOCS2015.SetBindVarValue("f_input_gubun", mInput_gubun);
            grdOCS2015.SetBindVarValue("f_pk_seq",      mOcs2005_seq);
            grdOCS2015.SetBindVarValue("f_hosp_code",   mHospCode);
        }

        private void grdOCS2016_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS2016.SetBindVarValue("f_fkocs2015", grdOCS2015.GetItemString(grdOCS2015.CurrentRowNumber, "pkocs2015"));
            grdOCS2016.SetBindVarValue("f_hosp_code", mHospCode);
        }
        #endregion

        private void grdOCS2006_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ChangeValue.Equals("N")) return;
            if (e.ColName.Equals("ord_danui")) return;

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
                              + grdOCS2006.GetItemString(e.RowNumber, "suryang") +  " "
                              + danui;

            txtAct_result_text.SetDataValue(text);
            txtAct_result_text.Focus();
            txtAct_result_text.SelectionStart = txtAct_result_text.Text.Length;
        }

        private void grdNUR0114_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ChangeValue.Equals("N")) return;

            string text = txtAct_result_text.Text;

            text = text + " " + grdNUR0114.GetItemString(e.RowNumber, "nur_act_name");

            txtAct_result_text.SetDataValue(text);
            txtAct_result_text.Focus();
            txtAct_result_text.SelectionStart = txtAct_result_text.Text.Length;
        }

        private void grdOCS2015_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (grdOCS2015.RowCount > 0)
            {
                if (!grdOCS2016.QueryLayout(false))
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                }

                txtAct_result_text.SetEditValue(grdOCS2015.GetItemString(0, "act_result_text"));
            }
        }

        #region [ PreSaveLayout() - grdOCS2015 행추가, 데이터 셋팅 - ]
        /// <summary>
        /// 
        /// </summary>
        private void PreSaveLayout()
        {
            int chkCount = 0;

            for (int i = 0; i < grdOCS2006.RowCount; i++)
            {
                if (grdOCS2006.GetItemString(i, "chk").Equals("Y"))
                {
                    chkCount++;
                }
            }

            if (chkCount > 0)
            {
                //Insert
                if (grdOCS2015.RowCount < 1)
                {
                    firstInput = "Y";
                    int insertRow = grdOCS2015.InsertRow();
                    grdOCS2015.SetItemValue(insertRow, "bunho",           mBunho);
                    grdOCS2015.SetItemValue(insertRow, "fkinp1001",       mFkinp1001);
                    grdOCS2015.SetItemValue(insertRow, "order_date",      mSource_order_date);
                    grdOCS2015.SetItemValue(insertRow, "input_gubun",     mInput_gubun);
                    grdOCS2015.SetItemValue(insertRow, "pk_seq",          mOcs2005_seq);

                    grdOCS2015.SetItemValue(insertRow, "act_id",          mUser_id);
                    grdOCS2015.SetItemValue(insertRow, "act_date",        dtpAct_date.GetDataValue());

                    grdOCS2015.SetItemValue(insertRow, "pkocs2015",       GetPKOCS("2015"));
                    grdOCS2015.SetItemValue(insertRow, "act_result_code", ActResultCode());
                    grdOCS2015.SetItemValue(insertRow, "input_id",        mUser_id);
                    grdOCS2015.SetItemValue(insertRow, "input_gwa",       mInput_gwa);
                    grdOCS2015.SetItemValue(insertRow, "input_doctor",    mInput_doctor);
                }
                else
                {
                    firstInput = "N";
                    grdOCS2015.SetItemValue(0, "act_id",          mUser_id);
                    grdOCS2015.SetItemValue(0, "act_date",        dtpAct_date.GetDataValue());
                    grdOCS2015.SetItemValue(0, "act_result_code", ActResultCode());
                }

                grdOCS2015.SetItemValue(0, "act_result_text", txtAct_result_text.Text);
            }
            else if(txtAct_result_text.Text.Trim().Length > 0)  // 발생되는 오더없이 결과만 텍스트로 입력하는 경우
            {
                string resultText = txtAct_result_text.Text;
                firstInput = "Y";
                int insertRow = 0;
                if (grdOCS2015.RowCount <= 0)    // 발생오더 없는 경우는 로우 하나만 추가하고, 그 이후에 결과는 텍스트로만 저장한다.
                {
                    insertRow = grdOCS2015.InsertRow();
                    grdOCS2015.SetItemValue(insertRow, "bunho",           mBunho);
                    grdOCS2015.SetItemValue(insertRow, "fkinp1001",       mFkinp1001);
                    grdOCS2015.SetItemValue(insertRow, "order_date",      mSource_order_date);
                    grdOCS2015.SetItemValue(insertRow, "input_gubun",     mInput_gubun);
                    grdOCS2015.SetItemValue(insertRow, "pk_seq",          mOcs2005_seq);

                    grdOCS2015.SetItemValue(insertRow, "act_id",          mUser_id);
                    grdOCS2015.SetItemValue(insertRow, "act_date",        dtpAct_date.GetDataValue());

                    grdOCS2015.SetItemValue(insertRow, "pkocs2015",       GetPKOCS("2015"));
                    grdOCS2015.SetItemValue(insertRow, "act_result_code", ActResultCode());
                    grdOCS2015.SetItemValue(insertRow, "input_id",        mUser_id);
                    grdOCS2015.SetItemValue(insertRow, "input_gwa",       mInput_gwa);
                    grdOCS2015.SetItemValue(insertRow, "input_doctor",    mInput_doctor);
                }

                grdOCS2015.SetItemValue(insertRow, "act_result_text", resultText);

            }

            grdOCS2015.SetItemValue(grdOCS2015.CurrentRowNumber, "act_result_text", txtAct_result_text.Text);

            if (firstInput == "N" && grdOCS2016.RowCount > 0)
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

                    grdOCS2016.SetItemValue(insertRow, "fkocs2015",      grdOCS2015.GetItemString(grdOCS2015.CurrentRowNumber, "pkocs2015"));
                    grdOCS2016.SetItemValue(insertRow, "hangmog_code",   grdOCS2006.GetItemString(i, "hangmog_code"));
                    grdOCS2016.SetItemValue(insertRow, "suryang",        grdOCS2006.GetItemString(i, "suryang"));
                    grdOCS2016.SetItemValue(insertRow, "nalsu",          grdOCS2006.GetItemString(i, "nalsu"));
                    grdOCS2016.SetItemValue(insertRow, "ord_danui",      grdOCS2006.GetItemString(i, "ord_danui"));
                    grdOCS2016.SetItemValue(insertRow, "bogyong_code",   grdOCS2006.GetItemString(i, "bogyong_code"));
                    grdOCS2016.SetItemValue(insertRow, "jusa_code",      grdOCS2006.GetItemString(i, "jusa_code"));
                    grdOCS2016.SetItemValue(insertRow, "jusa_spd_gubun", grdOCS2006.GetItemString(i, "jusa_spd_gubun"));
                    grdOCS2016.SetItemValue(insertRow, "dv",             grdOCS2006.GetItemString(i, "dv"));
                    grdOCS2016.SetItemValue(insertRow, "dv_time",        grdOCS2006.GetItemString(i, "dv_time"));
                }
            }
        }
        #endregion

        private OCS.OrderBiz mOrderBiz = new IHIS.OCS.OrderBiz();

        private void grdOCS2006_Click(object sender, EventArgs e)
        {
            if (this.grdOCS2006.CurrentColName == "ord_danui")
            {
                CreateCombo(grdOCS2006.GetItemString(grdOCS2006.CurrentRowNumber, "hangmog_code"));
            }
        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            if (grd.RowCount == 0) return;

            grd.SetItemValue(grd.CurrentRowNumber, "chk", "Y");

            if(grd.Name.Contains("2006"))
                grdOCS2006_ItemValueChanging(sender, new ItemValueChangingEventArgs(grd.CurrentRowNumber, "chk", grd.LayoutTable.Rows[grd.CurrentRowNumber], "Y"));
            else if(grd.Name.Contains("0114"))
                grdNUR0114_ItemValueChanging(sender, new ItemValueChangingEventArgs(grd.CurrentRowNumber, "chk", grd.LayoutTable.Rows[grd.CurrentRowNumber], "Y"));
        }

        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            if (grd.RowCount == 0) return;

            //if (e.Button == MouseButtons.Left && e.Clicks == 1)
            //{
            //    Hashtable dragInfo = new Hashtable();

            //    if (grd.Name.Contains("2006")) dragInfo.Add("name", "【 " + grd.GetItemString(grd.CurrentRowNumber, "hangmog_name") + " 】");
            //    else dragInfo.Add("name", "【 " + grd.GetItemString(grd.CurrentRowNumber, "nur_act_name") + " 】");

            //    dragInfo.Add("grd", grd);

            //    DragHelper.CreateDragCursor(grd, dragInfo["name"].ToString(), this.Font);
            //    grd.DoDragDrop(dragInfo, DragDropEffects.Move);
            //}
        }

        private void Mouse_DragDrop(object sender, DragEventArgs e)
        {
            Hashtable htTable = (Hashtable)e.Data.GetData("System.Collections.Hashtable");

            Grid_DoubleClick(htTable["grd"], new EventArgs());
        }

        private void Mouse_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void Mouse_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;

            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void btnList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control) // 마우스오른쪽클릭 + Ctrl Key 입력시 
            {
                if (this.CurrMQLayout != null) this.mOrderBiz.GridDisplayValue((XGrid)this.CurrMQLayout); // 현재 Current Row의 모든 값을 디스플레이한다
            }
        }

        private void test(object sender, MouseEventArgs e)
        {
            //DataGrid grid = (DataGrid) sender;
            ////指定された（クリックされた）座標位置の情報を取得する
            //System.Windows.Forms.DataGrid.HitTestInfo hti;
            //hti = grid.HitTest(e.X, e.Y);

            ////クリックされた場所の情報を取得
            //switch (hti.Type)
            //{
            //    case System.Windows.Forms.DataGrid.HitTestType.None:
            //        Console.WriteLine("バックグランドがクリックされました。");
            //        break;
            //    case System.Windows.Forms.DataGrid.HitTestType.Cell:
            //        Console.WriteLine("行{0}列{1}のセルがクリックされました。",
            //            hti.Row, hti.Column);
            //        break;
            //    case System.Windows.Forms.DataGrid.HitTestType.ColumnHeader:
            //        Console.WriteLine("列ヘッダ'{0}'がクリックされました。",
            //            hti.Column);
            //        break;
            //}

            XEditGrid grid = sender as XEditGrid;

            if (int.Parse(grid.HeaderHeights[0].ToString()) > e.Y)
            {
                XMessageBox.Show( "◎Header : " + grid.HeaderHeights[0].ToString() + "\n\r - " + e.Y.ToString());
            }
            else
            {
                XMessageBox.Show( "☆Not Header : " + grid.HeaderHeights[0].ToString() + "\n\r - " + e.Y.ToString());
            }
        }

        private void grdOCS2016_QueryEnd(object sender, QueryEndEventArgs e)
        {
            
            
        }

        private void btnList_PostButtonClick(object sender, PostButtonClickEventArgs e)
        {
            try
            {
                Service.BeginTransaction();

                if (this.cbxAutoProcess.Checked == true)
                {
                    #region 自動処方箋出力
                    // PKOCS2015
                    //CommonItemCollection param = new CommonItemCollection();

                    //param.Add("in_data_row", this.grdOCS2016.LayoutTable);
                    //param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
                    //param.Add("cancel_yn", "N");
                    //param.Add("auto_close_yn", "Y");

                    //XScreen.OpenScreenWithParam(this, "DRGS", "DRG3010P99", ScreenOpenStyle.ResponseFixed, param);
                    #endregion
                    string fkocs2003 = "";

                    string cmdOCS2003 = "";
                    string cmdOCS2017 = "";
                    string cmdOCS2016 = "";
                    BindVarCollection bindOCS2003 = new BindVarCollection();
                    BindVarCollection bindOCS2017 = new BindVarCollection();
                    BindVarCollection bindOCS2016 = new BindVarCollection();

                    // 指示事項で生成された薬は自動ACTING処理
                    cmdOCS2003 = @"UPDATE OCS2003 A
                                   SET A.ACTING_DATE = :f_acting_date
                                     , A.ACTING_TIME = TO_CHAR(SYSDATE, 'HH24MI')
                                     , A.ACTING_DAY  = A.NALSU
                                     , A.OCS_FLAG    = :f_ocs_flag
                                     , A.ACT_BUSEO   = :f_act_buseo
                                 WHERE A.HOSP_CODE   = :f_hosp_code
                                   AND A.PKOCS2003   = :f_pkocs2003
                    ";

                    // 自動投薬実施
                    cmdOCS2017 = @"UPDATE OCS2017
                                   SET UPD_ID       = :f_user_id
                                     , UPD_DATE     = SYSDATE
                                     , ACTING_DATE  = :f_acting_date
                                     , PASS_DATE    = :f_acting_date
                                     , ACTING_TIME  = TO_CHAR(SYSDATE, 'HH24MI')
                                     , ACT_USER     = :f_act_user
                                 WHERE HOSP_CODE    = :f_hosp_code
                                   AND FKOCS2003    = :f_fkocs2003
                                   AND ACT_RES_DATE = :f_act_res_date
                                   --AND HANGMOG_CODE = :f_hangmog_code -- 必要ないでしょう？FKOCS2003があるから！
                                   --AND SEQ          = :f_seq -- 登録された回数全部投薬処理
                    ";

                    cmdOCS2016 = @"SELECT A.FKOCS2003
                                     FROM OCS2016 A
                                    WHERE A.HOSP_CODE = :f_hosp_code
                                      AND A.PKOCS2016 = :f_pkocs2016
                    ";

                    for (int i = 0; i < this.mPKOCS2016.Count; i++)
                    {
                        bindOCS2016.Add("f_hosp_code", EnvironInfo.HospCode);
                        bindOCS2016.Add("f_pkocs2016", this.mPKOCS2016[i].ToString());
                        fkocs2003 = Service.ExecuteScalar(cmdOCS2016, bindOCS2016).ToString();


                        bindOCS2003.Add("f_acting_date", this.dtpAct_date.GetDataValue());
                        bindOCS2003.Add("f_ocs_flag", "3");
                        bindOCS2003.Add("f_act_buseo", "PA");
                        bindOCS2003.Add("f_hosp_code", EnvironInfo.HospCode);
                        bindOCS2003.Add("f_pkocs2003", fkocs2003);

                        Service.ExecuteScalar(cmdOCS2003, bindOCS2003);

                        bindOCS2017.Add("f_user_id", UserInfo.UserID);
                        bindOCS2017.Add("f_acting_date", this.dtpAct_date.GetDataValue());
                        bindOCS2017.Add("f_act_user", UserInfo.UserID);
                        bindOCS2017.Add("f_hosp_code", EnvironInfo.HospCode);
                        bindOCS2017.Add("f_fkocs2003", fkocs2003);
                        bindOCS2017.Add("f_act_res_date", this.dtpAct_date.GetDataValue());

                        Service.ExecuteScalar(cmdOCS2017, bindOCS2017);

                    }

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

            this.mPKOCS2016.Clear();
            Service.CommitTransaction();
        }

        private void grdOCS2006_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.ColName == "suryang")
                e.BackColor = Color.LightGreen;
        }
    }
}

