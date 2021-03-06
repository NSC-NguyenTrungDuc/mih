using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

using IHIS.Framework;

namespace IHIS.OCSI
{
	public class frmARActing : IHIS.Framework.XForm
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
        private string mDirect_cont  = "";
		private string mActing_yn    = "";
		private string mUser_id      = "";
		private string mUser_name    = "";
        private string mPkOCS2005    = "";
        private string mPkOCS6015    = "";
        private string mInput_gwa    = "";
        private string mInput_doctor = "";
        private string mSource_order_date = "";
        private string mDefaultLiter = "1";

        //Hospital Code
        private string mHospCode = EnvironInfo.HospCode;
		#endregion

		private IHIS.Framework.XFlatLabel xFlatLabel1;
		private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGrid grdOCS2015;
		private IHIS.Framework.XDisplayBox dpxAct_date;
        private XEditGrid grdOCS2016;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell31;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell30;
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
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
        private XPanel pnlTop;
        private XPanel pnlBody;
        private XCheckBox cbxLimit7;
        private XEditGridCell xEditGridCell37;
		private System.ComponentModel.IContainer components = null;

		public frmARActing()
        {
            /* SavePerformer 생성 */
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            this.grdOCS2015.SavePerformer = new XSavePerformer(this);
            this.grdOCS2016.SavePerformer = this.grdOCS2015.SavePerformer;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmARActing));
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.dpxAct_date = new IHIS.Framework.XDisplayBox();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.grdOCS2015 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.grdOCS2016 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.cbxLimit7 = new IHIS.Framework.XCheckBox();
            this.pnlBody = new IHIS.Framework.XPanel();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2015)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2016)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xFlatLabel1.Location = new System.Drawing.Point(6, 5);
            this.xFlatLabel1.Name = "xFlatLabel1";
            this.xFlatLabel1.Size = new System.Drawing.Size(58, 20);
            this.xFlatLabel1.TabIndex = 6;
            this.xFlatLabel1.Text = "施行日";
            // 
            // dpxAct_date
            // 
            this.dpxAct_date.EditMaskType = IHIS.Framework.MaskType.Date;
            this.dpxAct_date.Location = new System.Drawing.Point(65, 4);
            this.dpxAct_date.Name = "dpxAct_date";
            this.dpxAct_date.Size = new System.Drawing.Size(136, 22);
            this.dpxAct_date.TabIndex = 55;
            this.dpxAct_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(276, 0);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.Size = new System.Drawing.Size(406, 33);
            this.xButtonList1.TabIndex = 9;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.xButtonList1);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Location = new System.Drawing.Point(0, 255);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(684, 35);
            this.pnlBottom.TabIndex = 45;
            // 
            // grdOCS2015
            // 
            this.grdOCS2015.ApplyPaintEventToAllColumn = true;
            this.grdOCS2015.CallerID = '5';
            this.grdOCS2015.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell34,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell16,
            this.xEditGridCell15,
            this.xEditGridCell17,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37});
            this.grdOCS2015.ColPerLine = 7;
            this.grdOCS2015.Cols = 8;
            this.grdOCS2015.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS2015.FixedCols = 1;
            this.grdOCS2015.FixedRows = 1;
            this.grdOCS2015.HeaderHeights.Add(21);
            this.grdOCS2015.Location = new System.Drawing.Point(0, 0);
            this.grdOCS2015.Name = "grdOCS2015";
            this.grdOCS2015.QuerySQL = resources.GetString("grdOCS2015.QuerySQL");
            this.grdOCS2015.RowHeaderVisible = true;
            this.grdOCS2015.Rows = 2;
            this.grdOCS2015.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS2015.Size = new System.Drawing.Size(684, 255);
            this.grdOCS2015.TabIndex = 54;
            this.grdOCS2015.UseDefaultTransaction = false;
            this.grdOCS2015.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS2015_QueryEnd);
            this.grdOCS2015.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS2015_QueryStarting);
            this.grdOCS2015.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS2015_GridColumnProtectModify);
            this.grdOCS2015.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS2015_GridColumnChanged);
            this.grdOCS2015.Validating += new System.ComponentModel.CancelEventHandler(this.grdOCS2015_Validating);
            this.grdOCS2015.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS2015_GridCellPainting);
            this.grdOCS2015.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS2015_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "bunho";
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "fkinp1001";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "fkinp1001";
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "order_date";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "orderdate";
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "input_gubun";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "input_gubun";
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "input_id";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "input_id";
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "pk_seq";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "pk_seq";
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "seq";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.HeaderText = "SEQ";
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "pkocs2015";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "pkocs2015";
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "act_date";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.CellWidth = 105;
            this.xEditGridCell8.Col = 2;
            this.xEditGridCell8.HeaderText = "開始日付";
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "act_id";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "act_id";
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "dv";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell10.CellWidth = 47;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "回/分";
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "change_qty";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell11.CellWidth = 58;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "1回換算量";
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "fio2";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell12.CellWidth = 44;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "FiO2(%)";
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "suryang";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell13.CellWidth = 90;
            this.xEditGridCell13.Col = 1;
            this.xEditGridCell13.DecimalDigits = 3;
            this.xEditGridCell13.HeaderText = "分あたり(ℓ)";
            this.xEditGridCell13.IsNotNull = true;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "start_time";
            this.xEditGridCell14.CellWidth = 105;
            this.xEditGridCell14.Col = 3;
            this.xEditGridCell14.HeaderText = "開始時間";
            this.xEditGridCell14.IsNotNull = true;
            this.xEditGridCell14.Mask = "##:##";
            this.xEditGridCell14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "end_date";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell16.CellWidth = 105;
            this.xEditGridCell16.Col = 4;
            this.xEditGridCell16.HeaderText = "終了日付";
            this.xEditGridCell16.IsNotNull = true;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "end_time";
            this.xEditGridCell15.CellWidth = 105;
            this.xEditGridCell15.Col = 5;
            this.xEditGridCell15.HeaderText = "終了時間";
            this.xEditGridCell15.IsNotNull = true;
            this.xEditGridCell15.Mask = "##:##";
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellLen = 30;
            this.xEditGridCell17.CellName = "act_id_name";
            this.xEditGridCell17.CellWidth = 69;
            this.xEditGridCell17.Col = 7;
            this.xEditGridCell17.HeaderText = "記録者";
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsUpdCol = false;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "input_gwa";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.HeaderText = "input_gwa";
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "input_doctor";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.HeaderText = "input_doctor";
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // grdOCS2016
            // 
            this.grdOCS2016.CallerID = '6';
            this.grdOCS2016.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell33,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell32});
            this.grdOCS2016.ColPerLine = 6;
            this.grdOCS2016.Cols = 7;
            this.grdOCS2016.FixedCols = 1;
            this.grdOCS2016.FixedRows = 1;
            this.grdOCS2016.HeaderHeights.Add(21);
            this.grdOCS2016.Location = new System.Drawing.Point(690, 0);
            this.grdOCS2016.Name = "grdOCS2016";
            this.grdOCS2016.QuerySQL = resources.GetString("grdOCS2016.QuerySQL");
            this.grdOCS2016.RowHeaderVisible = true;
            this.grdOCS2016.Rows = 2;
            this.grdOCS2016.Size = new System.Drawing.Size(669, 254);
            this.grdOCS2016.TabIndex = 58;
            this.grdOCS2016.UseDefaultTransaction = false;
            this.grdOCS2016.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS2016_QueryStarting);
            this.grdOCS2016.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS2016_PreSaveLayout);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "fkocs2015";
            this.xEditGridCell18.Col = 1;
            this.xEditGridCell18.HeaderText = "fkocs2015";
            this.xEditGridCell18.IsReadOnly = true;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "pkocs2016";
            this.xEditGridCell19.Col = 2;
            this.xEditGridCell19.HeaderText = "pkocs2016";
            this.xEditGridCell19.IsReadOnly = true;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "seq";
            this.xEditGridCell33.Col = 3;
            this.xEditGridCell33.HeaderText = "seq";
            this.xEditGridCell33.IsReadOnly = true;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "hangmog_code";
            this.xEditGridCell20.Col = 4;
            this.xEditGridCell20.HeaderText = "hangmog_code";
            this.xEditGridCell20.IsReadOnly = true;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "suryang";
            this.xEditGridCell21.Col = 5;
            this.xEditGridCell21.HeaderText = "suryang";
            this.xEditGridCell21.IsReadOnly = true;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "nalsu";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.HeaderText = "nalsu";
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "ord_danui";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.HeaderText = "ord_danui";
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "bogyong_code";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.HeaderText = "bogyong_code";
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "jusa_code";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.HeaderText = "jusa_code";
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "jusa_spd_gubun";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.HeaderText = "jusa_spd_gubun";
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "dv";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.HeaderText = "dv";
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "dv_time";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.HeaderText = "dv_time";
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "bom_source_key";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.HeaderText = "bom_source_key";
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "bom_yn";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.HeaderText = "bom_yn";
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "hangmog_name";
            this.xEditGridCell32.Col = 6;
            this.xEditGridCell32.HeaderText = "発生オーダ";
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.IsUpdCol = false;
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.Controls.Add(this.cbxLimit7);
            this.pnlTop.Controls.Add(this.dpxAct_date);
            this.pnlTop.Controls.Add(this.xFlatLabel1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(684, 32);
            this.pnlTop.TabIndex = 59;
            // 
            // cbxLimit7
            // 
            this.cbxLimit7.AutoSize = true;
            this.cbxLimit7.Checked = true;
            this.cbxLimit7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxLimit7.Location = new System.Drawing.Point(469, 9);
            this.cbxLimit7.Name = "cbxLimit7";
            this.cbxLimit7.Size = new System.Drawing.Size(208, 17);
            this.cbxLimit7.TabIndex = 56;
            this.cbxLimit7.Tag = "7";
            this.cbxLimit7.Text = "最新一週間内の内訳のみ照会する";
            this.cbxLimit7.UseVisualStyleBackColor = false;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.grdOCS2015);
            this.pnlBody.Controls.Add(this.grdOCS2016);
            this.pnlBody.Controls.Add(this.pnlBottom);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 32);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(684, 290);
            this.pnlBody.TabIndex = 60;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "total_min";
            this.xEditGridCell37.CellWidth = 57;
            this.xEditGridCell37.Col = 6;
            this.xEditGridCell37.HeaderText = "実施(分)";
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.IsUpdatable = false;
            this.xEditGridCell37.IsUpdCol = false;
            this.xEditGridCell37.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmARActing
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(684, 344);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmARActing";
            this.ShowInTaskbar = true;
            this.Load += new System.EventHandler(this.frmDirectActing_Load);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2015)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2016)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region [Form]
        
		private void frmDirectActing_Load(object sender, System.EventArgs e)
		{	
            //CreateCombo();
			PostCallHelper.PostCall(new PostMethod(PostLoad));

            string cmd = "";
            cmd = @"SELECT A.SURYANG
                      FROM OCS2006 A
                     WHERE A.HOSP_CODE = :f_hosp_code
                       AND A.FKOCS2005 = :f_fkocs2005
                       AND A.ORD_DANUI = '037'";
            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_hosp_code", EnvironInfo.HospCode);
            bind.Add("f_fkocs2005", this.mPkOCS2005);

            object obj = Service.ExecuteScalar(cmd, bind);
            if (obj != null)
            {
                this.mDefaultLiter = obj.ToString();
            }
		}

		private void PostLoad()
		{
			if(TypeCheck.IsNull(mBunho)) this.DialogResult = DialogResult.Cancel;
			if(!TypeCheck.IsInt(mFkinp1001)) this.DialogResult = DialogResult.Cancel;
			if(!TypeCheck.IsDateTime(mOrder_date)) this.DialogResult = DialogResult.Cancel;
			if(!TypeCheck.IsInt(mOcs2005_seq)) this.DialogResult = DialogResult.Cancel;
			if(TypeCheck.IsNull(mDirect_gubun)) this.DialogResult = DialogResult.Cancel;
			if(TypeCheck.IsNull(mDirect_code)) this.DialogResult = DialogResult.Cancel;
			if(TypeCheck.IsNull(mUser_id)) this.DialogResult = DialogResult.Cancel;	
			
			dpxAct_date.SetDataValue(mOrder_date);


            #region [ 화면로드 시 자동입력 ]
            /**/ 
			//시행여부
            if (!grdOCS2015.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

            DataGridCell chkCell = GetEmptyNewRow(grdOCS2015);

			//Insert
            if (grdOCS2015.RowCount < 1)
            {
                int insertRow = grdOCS2015.InsertRow(-1);
                grdOCS2015.SetItemValue(insertRow, "bunho", mBunho);
                grdOCS2015.SetItemValue(insertRow, "fkinp1001", mFkinp1001);
                grdOCS2015.SetItemValue(insertRow, "order_date", mSource_order_date);
                grdOCS2015.SetItemValue(insertRow, "input_gubun", mInput_gubun);
                grdOCS2015.SetItemValue(insertRow, "pk_seq", mOcs2005_seq);
                grdOCS2015.SetItemValue(insertRow, "act_id", mUser_id);
                grdOCS2015.SetItemValue(insertRow, "act_id_name", mUser_name);
                grdOCS2015.SetItemValue(insertRow, "act_date", dpxAct_date.GetDataValue());

                grdOCS2015.SetItemValue(insertRow, "input_id", mUser_id);
                grdOCS2015.SetItemValue(insertRow, "input_gwa", mInput_gwa);
                grdOCS2015.SetItemValue(insertRow, "input_doctor", mInput_doctor);

                grdOCS2015.SetItemValue(insertRow, "pkocs2015", GetPkOCS2015());  // pkocs2015 SEQUENCE

                grdOCS2015.SetItemValue(insertRow, "suryang", this.mDefaultLiter);

                SetOCS2016();

                //chkCell = GetEmptyNewRow(grdOCS2015);
                //this.grdOCS2015.SetFocusToItem(insertRow, "suryang");
            }
            else
            {
                //this.grdOCS2015.SetFocusToItem(this.grdOCS2015.RowCount - 1, "end_date");
                if (this.grdOCS2015.GetItemString(this.grdOCS2015.RowCount - 1, "end_date") == "")
                    this.grdOCS2015.SetItemValue(this.grdOCS2015.RowCount - 1, "end_date", dpxAct_date.Text);
            }

            chkCell = GetEmptyNewRow(grdOCS2015);
            grdOCS2015.SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber - 1);

            #endregion

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

        #region GetPkOCS2015()
        /// <summary>
        /// OCS2015 의 PKOCS2015 값을 가져온다.
        /// </summary>
        /// <returns>pkocs2015</returns>
        private string GetPkOCS2015()
        {
            string cmdText = "SELECT OCS2015_SEQ.NEXTVAL AS PKOCS2015 FROM DUAL";
            string retVal = Service.ExecuteScalar(cmdText).ToString();

            return retVal;
        }
        #endregion

        #region [Button List Event]
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
                case FunctionType.Query:

                    e.IsBaseCall = false;

                    grdOCS2015.Reset();
                    grdOCS2016.Reset();

                    if(!grdOCS2015.QueryLayout(false))
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                    }
                    break;

				case FunctionType.Insert:

					e.IsBaseCall = false;

					int insertRow = -1;
					
					DataGridCell chkCell = GetEmptyNewRow(grdOCS2015);

					if(chkCell.RowNumber < 0)
					{
                        insertRow = grdOCS2015.InsertRow(-1);
                        grdOCS2015.SetItemValue(insertRow, "bunho",       mBunho);
                        grdOCS2015.SetItemValue(insertRow, "fkinp1001",   mFkinp1001);
                        grdOCS2015.SetItemValue(insertRow, "order_date",  mSource_order_date);
                        grdOCS2015.SetItemValue(insertRow, "input_gubun", mInput_gubun);
                        grdOCS2015.SetItemValue(insertRow, "pk_seq",      mOcs2005_seq);
                        grdOCS2015.SetItemValue(insertRow, "act_id",      mUser_id);
                        grdOCS2015.SetItemValue(insertRow, "act_id_name", mUser_name);
                        grdOCS2015.SetItemValue(insertRow, "act_date",    dpxAct_date.GetDataValue());
                        grdOCS2015.SetItemValue(insertRow, "input_id",    mUser_id);

                        grdOCS2015.SetItemValue(insertRow, "input_gwa",   mInput_gwa);
                        grdOCS2015.SetItemValue(insertRow, "input_doctor",mInput_doctor);

                        grdOCS2015.SetItemValue(insertRow, "pkocs2015",   GetPkOCS2015());  // pkocs2015 SEQUENCE

                        grdOCS2015.SetItemValue(insertRow, "suryang", this.mDefaultLiter);
                        SetOCS2016();

                        
                        //grdOCS2015.SetFocusToItem(insertRow, "suryang");
					}
                    //else
                    chkCell = GetEmptyNewRow(grdOCS2015);
                    grdOCS2015.SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber-1);

                    break;
				case FunctionType.Update:
					e.IsBaseCall = false;
                    
					this.AcceptData();

					if(!ChkData()) return;

                    SavePerformer();    // grdOCS2015 및 grdOCS2016, PR_OCS_DIRECT_ACT_AR 실행 메소드

					break;

                case FunctionType.Delete:

                    e.IsBaseCall = false;

                    if (CurrMSLayout == grdOCS2015)
                    {
                        string fkocs2015 = CurrMSLayout.GetItemValue(CurrMSLayout.CurrentRowNumber, "pkocs2015").ToString();


                        for (int i = 0; i < grdOCS2016.RowCount; i++)
                        {
                            if (grdOCS2016.GetItemString(i, "fkocs2015") == fkocs2015)
                            {
                                grdOCS2016.DeleteRow(i);
                                i--;
                            }
                        }

                        grdOCS2015.DeleteRow(CurrMSLayout.CurrentRowNumber);
                    }

                    break;

				case FunctionType.Close:

					this.DialogResult = DialogResult.Cancel;
					break;

				default:

					break;
			}
		}
		
		private bool ChkData()
		{
			for(int i = 0; i < this.grdOCS2015.RowCount; i++)
			{
                if (TypeCheck.IsNull(this.grdOCS2015.GetItemString(i, "end_time")))
                    this.grdOCS2015.SetItemValue(i, "end_date", "");

                if (TypeCheck.IsNull(this.grdOCS2015.GetItemValue(i, "suryang").ToString()) || this.grdOCS2015.GetItemValue(i, "suryang").ToString() == "0")
				{	
					mbxMsg = NetInfo.Language == LangMode.Jr ? "酸素量(ℓ)が正確ではありません。 ご確認ください。" : "주입량이 정확하지않습니다. 확인바랍니다.";
					mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
					XMessageBox.Show(mbxMsg, mbxCap);
                    this.grdOCS2015.SetFocusToItem(i, "start_time");
                    this.grdOCS2015.SetFocusToItem(i, "suryang");
					return false;
				}

                if (TypeCheck.IsNull(this.grdOCS2015.GetItemValue(i, "start_time").ToString()))
				{
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "開始時間が正確ではありません。 ご確認ください。" : "시작시간이 정확하지않습니다. 확인바랍니다.";
					mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
					XMessageBox.Show(mbxMsg, mbxCap);
                    this.grdOCS2015.SetFocusToItem(i, "start_time");
					return false;
				}

                if (TypeCheck.IsNull(this.grdOCS2015.GetItemValue(i, "end_time").ToString()))
				{
//					mbxMsg = NetInfo.Language == LangMode.Jr ? "終了時間が正確でがはないです。 確認してください。" : "종료시간이 정확하지않습니다. 확인바랍니다.";
//					mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
//					XMessageBox.Show(mbxMsg, mbxCap);
//					this.grdOCS2015.SetFocusToItem(i, "end_time");
//					return false;
				}
			}
			return true;
		}
		#endregion

		/// <summary>
		/// 메세지 일괄 처리
		/// </summary>
		/// <param name="aMesgGubun">
		/// 메세지 구분
		/// </param>
		#region 메세지처리
		private void GetMessage(string aMesgGubun)
		{
			string msg = string.Empty;
			string caption = string.Empty;
			
			switch(aMesgGubun)
			{
				case "suryang":
					msg = (NetInfo.Language == LangMode.Ko ? "분당ℓ를 확인해 주세요"
						: "分あたり(ℓ)を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "start_time":
					msg = (NetInfo.Language == LangMode.Ko ? "시작시간을 확인해 주세요."
						: "開始時間を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "act_date":
					msg = (NetInfo.Language == LangMode.Ko ? "실시일자를 확인해 주세요."
						: "施行日を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption);
					break;
				case "save_true":
					msg = NetInfo.Language == LangMode.Ko ? "보존했습니다."
						: "保存しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "お知らせ";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_false":
//					msg = NetInfo.Language == LangMode.Ko ? "저장 실패하였습니다. 확인바랍니다." 
//						: "保存に失敗しました。確認願います。";
//					msg += "\r\n[" + this.dsvSave.ErrFullMsg + "]";
//					caption = NetInfo.Language == LangMode.Ko ? "알림" 
//						: "エラー";
//					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				default:
					break;
			}
		}
		#endregion

		#region [산소량계산]

		private double CalO2Suryang(int aDv, int aChangeSuryang, int aFio2)
		{
			double suryang       = 0.0;
			int    dv            = 0;
			if(TypeCheck.IsInt(aDv))
				dv = aDv;

			int    changeSuryang = 0;
			if(TypeCheck.IsInt(aChangeSuryang) )
				changeSuryang = aChangeSuryang;

			int    fio2          = 0;
			if(TypeCheck.IsInt(aFio2) )
				fio2 = aFio2;
			
			suryang = ((dv * changeSuryang * fio2)/10000.0)/10.0;

			return suryang;

		}

		#endregion

		#region Insert한 Row 중에 Not Null필드 미입력 Row Search (GetEmptyNewRow)
		/// <summary>
		/// Insert한 Row 중에 Not Null필드 미입력 Row Search
		/// <remarks>
		/// Grid 컬럼 속성이 Not Null과 Visible, Not ReadOnly 항목으로 체크한다..
		/// </remarks>
		/// <param name="aGrd"> XEditGrid  </param>
        /// <returns> celReturn.RowNumber 0 미입력데이타 없음 </returns>
        /// </summary>
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
                    if (celReturn.RowNumber < 0)
                    {
                        for (int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
                        {
                            if ((grdChk.GetRowState(rowIndex) == DataRowState.Added || grdChk.GetRowState(rowIndex) == DataRowState.Modified) && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
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

			}

			return celReturn;
		}

		#endregion

		#region XEditGrid에 값을 세팅하되 이전의 RowState를 유지하며, Option 해당 컬럼에서 포커스를 유지시킨다 (UndoPreviousValue)
		/// <summary> 
		/// XEditGrid에 값을 세팅하되 이전의 RowState를 유지하며, Option해당 컬럼에서 포커스를 유지시킨다
		/// </summary>
		/// <param name="aGrd"> XEditGrid </param>
		/// <param name="aRow"> int Row </param>
		/// <param name="aColName"> string 컬럼 </param>
		/// <param name="aPreviousValue"> object Setting할 Value </param>
		/// <param name="aIsProtecedFocus"> bool Optional 포커스이동막을지여부(Defalut : True) </param>
		/// <returns> void </returns>
		public void UndoPreviousValue(XEditGrid aGrd, int aRow, string aColName, object aPreviousValue)
		{
			this.UndoPreviousValue(aGrd, aRow, aColName, aPreviousValue, true);
		}
		public void UndoPreviousValue(XEditGrid aGrd, int aRow, string aColName, object aPreviousValue, bool aIsProtecedFocus)
		{
			if (aGrd == null || aRow < 0 || aColName == "") return;

			// 이전 값으로 세팅한다
			// 값을 세팅하면 Row의 상태가 변화가 되므로, 해당 Row의 상태가 UnChanged인 경우는 변경후에 다시 UnChanged로 바꾸어 준다
			// 단, Added인 경우는 Detached 상태였으면, Detached로 바꾸어 줘야 하나, A___Grid는 InsertRow시 이미 Added상태이므로, 처리불가함
			DataRowState previousRowState = aGrd.GetRowState(aRow);

			if (previousRowState != DataRowState.Deleted) aGrd.SetItemValue(aRow, aColName, aPreviousValue); // 이전 데이타로 복귀

			// 이전 Row상태가 UnChanged인 경우 UnChanged로 Undo시킴
			if (previousRowState == DataRowState.Unchanged) aGrd.LayoutTable.Rows[aRow].AcceptChanges();

			if (aIsProtecedFocus) // 포커스이동막을지여부
			{
				Objects objects = new Objects(aGrd, aRow, aColName);
				PostCallHelper.PostCall(new PostMethodObject(PostSetFocusToItem), ((object)objects)); // 현재 Column으로 Focus이동처리
			}
		}

		#region Objects Class(PostCall 메소드 사용용)
		// PostCall 메소드 사용시 Argument로 Object 하나만 넘길수 있다. 두개이상 Argument가 필요한 경우 아래의 구조체를 사용하자
		public class Objects
		{
			public object obj1; public object obj2; public object obj3; public object obj4; public object obj5;

			public Objects(object aObj1, object aObj2)
			{
				obj1 = aObj1; obj2 = aObj2; obj3 = null; obj4 = null; obj5 = null;
			}
			public Objects(object aObj1, object aObj2, object aObj3)
			{
				obj1 = aObj1; obj2 = aObj2; obj3 = aObj3; obj4 = null; obj5 = null;
			}
			public Objects(object aObj1, object aObj2, object aObj3, object aObj4)
			{
				obj1 = aObj1; obj2 = aObj2; obj3 = aObj3; obj4 = aObj4; obj5 = null;
			}
			public Objects(object aObj1, object aObj2, object aObj3, object aObj4, object aObj5)
			{
				obj1 = aObj1; obj2 = aObj2; obj3 = aObj3; obj4 = aObj4; obj5 = aObj5;
			}
		}
		#endregion

		#region XGrid에 해당컬럼에 Focus (PostCall용) (PostSetFocusToItem)
		/// <summary> 
		/// XGrid에 해당컬럼에 Focus (PostCall용)
		/// </summary>
		/// <param name="object"> aObjs (**OrderVariables.Objects Type임** : Grid, Int Row, String ColName) </param>
		/// <returns> void </returns>
		public void PostSetFocusToItem(object aObjs) 
		{			
			try
			{
				Objects objects = (Objects)aObjs;
				((XGrid)objects.obj1).Focus();
				((XGrid)objects.obj1).SetFocusToItem(((int)objects.obj2), ((string)objects.obj3));
			}
			catch{}
		}
		#endregion

		
		
		#endregion

        #region [ SetOCS2016() - OCS2016 Basic Set ]
        /// <summary>
        /// OCS2005/OCS2006 에 저장된 기준정보의 값과 수정값을 가져와 grdOCS2016 에 셋팅한다.
        /// </summary>
        private void SetOCS2016()
        {
            string cmdText = @"SELECT A.HANGMOG_CODE
                                    , A.SURYANG
                                    , A.BOM_YN
                                    , A.BOM_SOURCE_KEY
                                    , B.HANGMOG_NAME
                                    , A.FKOCS2005
                                    , C.ORDER_DATE
                                    , C.DRT_FROM_DATE
                                    , C.DRT_TO_DATE
                                 FROM OCS2006 A    ,
                                      OCS0103 B    ,
                                      OCS2005 C
                                WHERE A.HOSP_CODE      = :f_hosp_code
                                  AND A.BUNHO          = :f_bunho
                                  AND A.FKINP1001      = :f_fkinp1001
                                  AND A.INPUT_GUBUN    = :f_input_gubun
                                  AND A.PK_SEQ         = :f_pk_seq
                                  AND B.HOSP_CODE      = A.HOSP_CODE
                                  AND B.HANGMOG_CODE   = A.HANGMOG_CODE
                                  AND C.HOSP_CODE      = A.HOSP_CODE   
                                  AND C.BUNHO          = A.BUNHO
                                  AND C.ORDER_DATE     = A.ORDER_DATE
                                  AND C.PK_SEQ         = A.PK_SEQ
                                  AND :f_order_date BETWEEN C.DRT_FROM_DATE AND NVL(C.DRT_TO_DATE, '9998/12/31')
                                ORDER BY A.BOM_YN DESC";
            DataTable dtResult = new DataTable();
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_bunho",       mBunho);
            bindVars.Add("f_fkinp1001",   mFkinp1001);
            bindVars.Add("f_order_date",  mSource_order_date);
            bindVars.Add("f_input_gubun", mInput_gubun);
            bindVars.Add("f_pk_seq",      mOcs2005_seq);
            bindVars.Add("f_hosp_code",   mHospCode);

            dtResult = Service.ExecuteDataTable(cmdText, bindVars);

            int seq = 0;
            cmdText = @"SELECT NVL(MAX(A.SEQ), 0) AS SEQ
                          FROM OCS2016 A
                         WHERE A.HOSP_CODE = :f_hosp_code
                           AND A.FKOCS2015 = :f_fkocs2015";
            bindVars.Clear();
            bindVars.Add("f_hosp_code", mHospCode);
            bindVars.Add("f_fkocs2015", grdOCS2015.GetItemString(grdOCS2015.CurrentRowNumber, "pkocs2015"));

            seq = Convert.ToInt32(Service.ExecuteScalar(cmdText, bindVars));

            int insertRow = -1;

            if (dtResult.Rows.Count > 0)
            {
                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    // 행위코드를 제외한 재료코드만 저장. 행위코드는 프로시져에서 저장.
                    //if (!dtResult.Rows[i]["bom_yn"].ToString().Equals("C")) continue;

                    insertRow = grdOCS2016.InsertRow(-1);

                    seq = seq + 1;

                    grdOCS2016.SetItemValue(insertRow, "hangmog_code",      dtResult.Rows[i]["hangmog_code"].ToString());
                    grdOCS2016.SetItemValue(insertRow, "suryang",           dtResult.Rows[i]["suryang"].ToString());
                    grdOCS2016.SetItemValue(insertRow, "bom_yn",            dtResult.Rows[i]["bom_yn"].ToString());
                    grdOCS2016.SetItemValue(insertRow, "bom_source_key",    dtResult.Rows[i]["bom_source_key"].ToString());
                    grdOCS2016.SetItemValue(insertRow, "seq",               seq.ToString());
                    grdOCS2016.SetItemValue(insertRow, "fkocs2015",         grdOCS2015.GetItemString(grdOCS2015.CurrentRowNumber, "pkocs2015"));
                }
            }
        }
        #endregion

        #region [사용자명]

        private string GetAdminUSER_NAME(string aUser_id)
		{
			string user_name = "";
            string cmdText = "";
            object retVal = null;

			cmdText = ""
				+ " SELECT USER_NM   "
				+ "   FROM ADM3200   "
				+ "  WHERE HOSP_CODE = '" + mHospCode + "' "
                + "    AND USER_ID   = '" + aUser_id + "' ";

            retVal = Service.ExecuteScalar(cmdText);

            if(!TypeCheck.IsNull(retVal))
				user_name = retVal.ToString();	

			return user_name;
		}

        #endregion

        #region [ 각 그리드 바인드 변수 설정 ]
        private void grdOCS2015_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS2015.SetBindVarValue("f_bunho",       mBunho);
            grdOCS2015.SetBindVarValue("f_fkinp1001",   mFkinp1001);
            grdOCS2015.SetBindVarValue("f_order_date",  mSource_order_date);
            grdOCS2015.SetBindVarValue("f_act_date",    mOrder_date);
            grdOCS2015.SetBindVarValue("f_input_gubun", mInput_gubun);
            grdOCS2015.SetBindVarValue("f_pk_seq",      mOcs2005_seq);
            grdOCS2015.SetBindVarValue("f_hosp_code",   mHospCode);
            grdOCS2015.SetBindVarValue("f_limit7",      this.cbxLimit7.Checked == true ? "Y" : "N");
            grdOCS2015.SetBindVarValue("f_kijun_date",  dpxAct_date.Text);
            
        }

        private void grdOCS2016_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS2016.SetBindVarValue("f_fkocs2015", grdOCS2015.GetItemString(grdOCS2015.CurrentRowNumber, "pkocs2015"));
            grdOCS2016.SetBindVarValue("f_hosp_code", mHospCode);
        }
        #endregion

        private void grdOCS2015_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            e.Cancel = false;

            object previousValue = grdOCS2015.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // 이전 Value
            string start_time = "";
            string end_time = "";
            double suryang = 0;
            int dv = 0;
            if (TypeCheck.IsInt(grdOCS2015.GetItemString(e.RowNumber, "dv")))
                dv = grdOCS2015.GetItemInt(e.RowNumber, "dv");

            int change_qty = 0;
            if (TypeCheck.IsInt(grdOCS2015.GetItemString(e.RowNumber, "change_qty")))
                change_qty = grdOCS2015.GetItemInt(e.RowNumber, "change_qty");

            int fio2 = 0;
            if (TypeCheck.IsInt(grdOCS2015.GetItemString(e.RowNumber, "fio2")))
                fio2 = grdOCS2015.GetItemInt(e.RowNumber, "fio2");

            switch (e.ColName)
            {
                case "dv":

                    if (TypeCheck.IsNull(e.ChangeValue))
                    {
                        this.grdOCS2015.SetItemValue(e.RowNumber, "suryang", suryang);
                        break;
                    }

                    suryang = this.CalO2Suryang(int.Parse(e.ChangeValue.ToString()), change_qty, fio2);
                    this.grdOCS2015.SetItemValue(e.RowNumber, "suryang", suryang);

                    break;
                case "change_qty":

                    if (TypeCheck.IsNull(e.ChangeValue))
                    {
                        this.grdOCS2015.SetItemValue(e.RowNumber, "suryang", suryang);
                        break;
                    }

                    suryang = this.CalO2Suryang(dv, int.Parse(e.ChangeValue.ToString()), fio2);
                    this.grdOCS2015.SetItemValue(e.RowNumber, "suryang", suryang);

                    break;
                case "fio2":

                    if (TypeCheck.IsNull(e.ChangeValue))
                    {
                        this.grdOCS2015.SetItemValue(e.RowNumber, "suryang", suryang);
                        break;
                    }

                    suryang = this.CalO2Suryang(dv, change_qty, int.Parse(e.ChangeValue.ToString()));
                    this.grdOCS2015.SetItemValue(e.RowNumber, "suryang", suryang);

                    break;
                case "start_time":

                    for (int i = 0; i < this.grdOCS2015.RowCount; i++)
                    {
                        if (e.RowNumber == i)
                            continue;

                        if(this.grdOCS2015.GetItemString(i, "act_date") == this.grdOCS2015.GetItemString(e.RowNumber, "act_date"))
                        {
                            if (this.grdOCS2015.GetItemString(i, "start_time") != "" && this.grdOCS2015.GetItemString(i, "end_time") != "")
                            {
                                if (int.Parse(this.grdOCS2015.GetItemString(i, "start_time")) <= int.Parse(e.ChangeValue.ToString())
                                    && int.Parse(this.grdOCS2015.GetItemString(i, "end_time")) >= int.Parse(e.ChangeValue.ToString()))
                                {
                                    mbxMsg = NetInfo.Language == LangMode.Jr ? "時間が重複しています。" : "";
                                    mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                                    XMessageBox.Show(mbxMsg, mbxCap);
                                    this.UndoPreviousValue(grdOCS2015, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다
                                    return;
                                }
                            }
                        }
                    }


                    if (TypeCheck.IsNull(e.ChangeValue) || e.ChangeValue.ToString().Length < 4)
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "開始時間が正確ではありません。ご確認ください。" : "시작시간이 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        this.UndoPreviousValue(grdOCS2015, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다
                        return;
                    }

                    if (e.ChangeValue.ToString() == "2359" || !TypeCheck.IsDateTime("9999/01/01 " + e.ChangeValue.ToString().Substring(0, 2) + ":" + e.ChangeValue.ToString().Substring(2, 2)))
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "開始時間に誤りがあります。 ご確認ください。(範囲 00:00～23:58)" : "시작시간이 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        this.UndoPreviousValue(grdOCS2015, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다
                        return;
                    }

                    if (e.DataRow["act_date"].ToString() != "" && e.DataRow["start_time"].ToString() != ""
                        && e.DataRow["end_date"].ToString() != "" && e.DataRow["end_time"].ToString() != "")
                    {
                        if (DateTime.Parse(DateTime.Parse(e.DataRow["end_date"].ToString() + " " + e.DataRow["end_time"].ToString().Substring(0, 2) + ":" + e.DataRow["end_time"].ToString().Substring(2, 2)).ToString("yyyy/MM/dd HH:mm:ss"))
                            <= DateTime.Parse(DateTime.Parse(e.DataRow["act_date"].ToString() + " " + e.DataRow["start_time"].ToString().Substring(0, 2) + ":" + e.DataRow["start_time"].ToString().Substring(2, 2)).ToString("yyyy/MM/dd HH:mm:ss")))
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "終了時間は開始時間より後の時間を指定して下さい。" : "종료시간은 시작시간보다 커야합니다. 확인하세요.";
                            mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            this.UndoPreviousValue(grdOCS2015, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다
                            return;
                        }
                    }
                    break;


                case "end_time":

                    if (TypeCheck.IsNull(e.ChangeValue))
                    {
                        grdOCS2015.SetItemValue(e.RowNumber, "end_date", "");
                        return;
                    }

                    for (int i = 0; i < this.grdOCS2015.RowCount; i++)
                    {
                        if (e.RowNumber == i)
                            continue;

                        if (this.grdOCS2015.GetItemString(i, "act_date") == this.grdOCS2015.GetItemString(e.RowNumber, "act_date"))
                        {
                            if (this.grdOCS2015.GetItemString(i, "start_time") != "" && this.grdOCS2015.GetItemString(i, "end_time") != "")
                            {
                                if (int.Parse(this.grdOCS2015.GetItemString(e.RowNumber, "start_time")) < int.Parse(this.grdOCS2015.GetItemString(i, "start_time")))
                                {
                                    if (int.Parse(e.ChangeValue.ToString()) > int.Parse(this.grdOCS2015.GetItemString(i, "start_time")))
                                    {
                                        mbxMsg = NetInfo.Language == LangMode.Jr ? "時間が重複しています。" : "";
                                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                                        XMessageBox.Show(mbxMsg, mbxCap);
                                        this.UndoPreviousValue(grdOCS2015, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다
                                        return;
                                    }
                                }
                                
                            }
                        }
                    }

                    if (e.ChangeValue.ToString().Length < 4)
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "終了時間が正確ではありません。ご確認ください。" : "종료시간이 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        this.UndoPreviousValue(grdOCS2015, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다
                        return;
                    }

                    if (!TypeCheck.IsDateTime("9999/01/01 " + e.ChangeValue.ToString().Substring(0, 2) + ":" + e.ChangeValue.ToString().Substring(2, 2)))
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "終了時間に誤りがあります。 ご確認ください。(範囲 00:01～23:59)" : "종료시간이 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        this.UndoPreviousValue(grdOCS2015, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다
                        return;
                    }

                    if (e.DataRow["act_date"].ToString() != "" && e.DataRow["start_time"].ToString() != ""
                        && e.DataRow["end_date"].ToString() != "" && e.DataRow["end_time"].ToString() != "")
                    {
                        if (DateTime.Parse(DateTime.Parse(e.DataRow["end_date"].ToString() + " " + e.DataRow["end_time"].ToString().Substring(0, 2) + ":" + e.DataRow["end_time"].ToString().Substring(2, 2)).ToString("yyyy/MM/dd HH:mm:ss"))
                            <= DateTime.Parse(DateTime.Parse(e.DataRow["act_date"].ToString() + " " + e.DataRow["start_time"].ToString().Substring(0, 2) + ":" + e.DataRow["start_time"].ToString().Substring(2, 2)).ToString("yyyy/MM/dd HH:mm:ss")))
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "終了時間は開始時間より後の時間を指定して下さい。" : "종료시간은 시작시간보다 커야합니다. 확인하세요.";
                            mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            this.UndoPreviousValue(grdOCS2015, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다
                            return;
                        }
                    }
                    break;

                case "act_date":
                case "end_date":
                    if (e.ChangeValue.ToString() == "")
                    {
                        if (e.ColName == "act_date")
                            this.grdOCS2015.SetItemValue(e.RowNumber, "start_time", "");
                        else if (e.ColName == "end_date")
                            this.grdOCS2015.SetItemValue(e.RowNumber, "end_time", "");

                    }
                    if (   e.DataRow["act_date"].ToString() != "" && e.DataRow["start_time"].ToString() != ""
                        && e.DataRow["end_date"].ToString() != "" && e.DataRow["end_time"].ToString() != "")
                    {
                        if (   DateTime.Parse(DateTime.Parse(e.DataRow["end_date"].ToString() + " " + e.DataRow["end_time"].ToString().Substring(0, 2) + ":" + e.DataRow["end_time"].ToString().Substring(2, 2)).ToString("yyyy/MM/dd HH:mm:ss"))
                            <= DateTime.Parse(DateTime.Parse(e.DataRow["act_date"].ToString() + " " + e.DataRow["start_time"].ToString().Substring(0, 2) + ":" + e.DataRow["start_time"].ToString().Substring(2, 2)).ToString("yyyy/MM/dd HH:mm:ss")))
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "終了時間は開始時間より後の時間を指定して下さい。" : "종료시간은 시작시간보다 커야합니다. 확인하세요.";
                            mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            this.UndoPreviousValue(grdOCS2015, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다
                            return;
                        }
                    }
                    break;
                case "suryang": // 2011/01/13 KHJ
                    //for (int i = 0; i < grdOCS2016.RowCount; i++)
                    //{
                    //    if (grdOCS2016.GetItemString(i, "fkocs2015") == grdOCS2015.GetItemString(e.RowNumber, "pkocs2015"))
                    //    {
                    //        grdOCS2016.SetItemValue(i, "suryang", e.ChangeValue.ToString());
                    //    }
                    //}
                    break;
                default:
                    break;
            }

            SetTotalMinutes(e.RowNumber);
        }

        private void grdOCS2016_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            AcceptData();

            for (int rowIndex = 0; rowIndex < grdOCS2016.RowCount; rowIndex++)
            {
                if (grdOCS2016.LayoutTable.Rows[rowIndex].RowState == DataRowState.Unchanged) continue;

                if (grdOCS2016.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOCS2016.GetItemString(rowIndex, "hangmog_code").Trim() == "")
                    {
                        grdOCS2016.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                }
            }		
        }

        private void grdOCS2015_QueryEnd(object sender, QueryEndEventArgs e)
        {
            for (int i = 0; i < this.grdOCS2015.RowCount; i++)
            {
                SetTotalMinutes(i);
                this.grdOCS2015.LayoutTable.Rows[i].RejectChanges();
            }
        }

        private void grdOCS2015_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (this.grdOCS2015.GetRowState(e.RowNumber) == DataRowState.Unchanged)
            {
                //시행된 시행사항은 수정을 막는다.
                if (!TypeCheck.IsNull(e.DataRow["end_time"].ToString()))
                    e.Protect = true;
                else
                    e.Protect = false;
            }
        }


        #region SavePerformer
        /// <summary>
        /// SavePerformer
        /// </summary>
        private void SavePerformer()
        {
            string cmdText = "";
            string spName = "";
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            BindVarCollection BindVar2015 = new BindVarCollection();
            BindVarCollection BindVar2016 = new BindVarCollection();

            try
            {
                Service.BeginTransaction();
                // DELETE 처리
                for (int i = 0; i < grdOCS2015.DeletedRowCount; i++)
                {
                    string spName_dup = "PR_OCSI_IS_JISI_DATETIME";
                    ArrayList inputList_dup = new ArrayList();
                    ArrayList outputList_dup = new ArrayList();

                    if (!TypeCheck.IsNull(grdOCS2015.DeletedRowTable.Rows[i]["act_date"].ToString())
                        && !TypeCheck.IsNull(grdOCS2015.DeletedRowTable.Rows[i]["start_time"].ToString())
                        && !TypeCheck.IsNull(grdOCS2015.DeletedRowTable.Rows[i]["end_date"].ToString())
                        && !TypeCheck.IsNull(grdOCS2015.DeletedRowTable.Rows[i]["end_time"].ToString()))
                    {
                        inputList_dup.Add(EnvironInfo.HospCode);
                        inputList_dup.Add("D");
                        inputList_dup.Add("AR");
                        inputList_dup.Add(grdOCS2015.DeletedRowTable.Rows[i]["bunho"].ToString());
                        inputList_dup.Add(grdOCS2015.DeletedRowTable.Rows[i]["fkinp1001"].ToString());
                        inputList_dup.Add(grdOCS2015.DeletedRowTable.Rows[i]["act_date"].ToString());
                        inputList_dup.Add(grdOCS2015.DeletedRowTable.Rows[i]["start_time"].ToString());
                        inputList_dup.Add(grdOCS2015.DeletedRowTable.Rows[i]["end_date"].ToString());
                        inputList_dup.Add(grdOCS2015.DeletedRowTable.Rows[i]["end_time"].ToString());
                        inputList_dup.Add(grdOCS2015.DeletedRowTable.Rows[i]["act_id"].ToString());

                        if (Service.ExecuteProcedure(spName_dup, inputList_dup, outputList_dup))
                        {
                            if (!outputList_dup[0].ToString().Equals("T"))  // flag
                                throw new Exception(outputList_dup[1].ToString());
                        }
                        else
                            throw new Exception(Service.ErrFullMsg);
                    }

//                    string cmd_pkocs2003 = @"SELECT C.FKOCS2003 
//                                                       FROM OCS2015 B
//                                                           ,OCS2016 C
//                                                      WHERE B.HOSP_CODE = '" + mHospCode + @"'
//                                                        AND B.PKOCS2015 = '" + grdOCS2015.DeletedRowTable.Rows[i]["pkocs2015"].ToString() + @"'
//                                                        AND C.HOSP_CODE = B.HOSP_CODE
//                                                        AND C.FKOCS2015 = B.PKOCS2015";

//                    DataTable dt = Service.ExecuteDataTable(cmd_pkocs2003);
//                    string pkocs2003 = "";
//                    if (dt.Rows.Count == 0)
//                        throw new Exception("削除対象がありません。");
//                    else
//                    {
//                        foreach (DataRow dr in dt.Rows)
//                        {
//                            pkocs2003 = dr["fkocs2003"].ToString();

//                            // 丸めオーダー削除
//                            spName_dup = "PR_OCSI_MARUME_IUD";
//                            inputList_dup = new ArrayList();
//                            outputList_dup = new ArrayList();

//                            /*
//                               I_IUD_GUBUN     IN     VARCHAR2
//                            , I_PKOCS2003     IN     NUMBER            -- DELETE
//                            , O_ERR           OUT    NUMBER
//                             */

//                            inputList_dup.Add("DELETE");
//                            inputList_dup.Add(pkocs2003);
//                            //inputList_dup.Add(null);

//                            if (Service.ExecuteProcedure(spName_dup, inputList_dup, outputList_dup))
//                            {
//                                if (!outputList_dup[0].ToString().Equals("1"))  // flag
//                                    throw new Exception(outputList_dup[1].ToString());
//                            }
//                            else
//                                throw new Exception(Service.ErrFullMsg);
//                        }
                        
//                    }

                    // << 2014/10/26 >>
                    #region MARUMEオーダー登録

                    /*
                        I_IUD_GUBUN     IN     VARCHAR2
                        I_PKOCS2015     IN     NUMBER   
                        O_ERR           OUT    NUMBER
                        O_ERR_MSG       OUT    VARCHAR2
                     */

                    spName = "PR_OCSI_MARUME_IUD";
                    inputList = new ArrayList();
                    outputList = new ArrayList();

                    inputList.Add("DELETE");
                    inputList.Add(this.grdOCS2015.DeletedRowTable.Rows[i]["pkocs2015"].ToString());

                    if (Service.ExecuteProcedure(spName, inputList, outputList))
                    {
                        if (!outputList[0].ToString().Equals("1"))  // 1 : TRUE, 0 : FALSE
                        {
                            throw new Exception(outputList[0].ToString());
                        }
                        {

                        }
                    }
                    else throw new Exception(Service.ErrFullMsg);

                    #endregion MARUMEオーダー登録
                    // << 2014/10/26 >>
                        

                    cmdText = @"DELETE 
                                  FROM OCS2003
                                 WHERE HOSP_CODE = '" + mHospCode + @"' --:f_pkocs2016
                                   AND PKOCS2003 IN (SELECT C.FKOCS2003 
                                                       FROM OCS2015 B
                                                           ,OCS2016 C
                                                      WHERE B.HOSP_CODE = '" + mHospCode + @"'
                                                        AND B.PKOCS2015 = '" + grdOCS2015.DeletedRowTable.Rows[i]["pkocs2015"].ToString() + @"'
                                                        AND C.HOSP_CODE = B.HOSP_CODE
                                                        AND C.FKOCS2015 = B.PKOCS2015 )
                            ";
                    if (!Service.ExecuteNonQuery(cmdText)) throw new Exception(Service.ErrFullMsg);

                    cmdText = @"DELETE FROM OCS2015
                                 WHERE HOSP_CODE = '" + mHospCode + @"'   --:f_pkocs2015
                                   AND PKOCS2015 = '" + grdOCS2015.DeletedRowTable.Rows[i]["pkocs2015"].ToString() + "'";
                    if (!Service.ExecuteNonQuery(cmdText)) throw new Exception(Service.ErrFullMsg);

                    cmdText = @"DELETE FROM OCS2016
                                 WHERE HOSP_CODE = '" + mHospCode + @"' --:f_pkocs2016
                                   AND FKOCS2015 = '" + grdOCS2015.DeletedRowTable.Rows[i]["pkocs2015"].ToString() + "'";
                    if (!Service.ExecuteNonQuery(cmdText)) throw new Exception(Service.ErrFullMsg);


                }

                // << 2014/10/26 >>
                ArrayList aList = new ArrayList();
                // << 2014/10/26 >>

                foreach (DataRow row2015 in grdOCS2015.LayoutTable.Rows)
                {
                    cmdText = "";
                    BindVar2015.Clear();

                    inputList.Clear();
                    outputList.Clear();

                    BindVar2015.Add("f_hosp_code", mHospCode);
                    foreach (XEditGridCell item2015 in grdOCS2015.CellInfos)
                    {
                        BindVar2015.Add("f_" + item2015.CellName, row2015[item2015.CellName].ToString());
                    }

                    int process_days = int.Parse((DateTime.Parse(TypeCheck.NVL(row2015["end_date"].ToString(), row2015["act_date"].ToString()).ToString())
                                                - DateTime.Parse(row2015["act_date"].ToString())).Days.ToString()) + 1;


                    switch (row2015.RowState)
                    {
                            case DataRowState.Added:

                                string start_time = row2015["start_time"].ToString();
                                string end_time = row2015["end_time"].ToString();

                                for (int i = 1; i <= process_days; i++)
                                {
                                    BindVar2015["f_act_date"].VarValue = DateTime.Parse(row2015["act_date"].ToString()).AddDays(i - 1).ToString("yyyy/MM/dd");
                                    if (process_days > 1)
                                        BindVar2015["f_end_date"].VarValue = BindVar2015["f_act_date"].VarValue;


                                    if (i == 1)
                                    {
                                        BindVar2015["f_start_time"].VarValue = start_time;
                                        if (process_days > 1)
                                            BindVar2015["f_end_time"].VarValue = "2359";
                                    }
                                    else if (i != 1 && i != process_days)
                                    {
                                        BindVar2015["f_start_time"].VarValue = "0000";
                                        BindVar2015["f_end_time"].VarValue = "2359";
                                        BindVar2015["f_pkocs2015"].VarValue = GetPkOCS2015();
                                    }
                                    else if (i == process_days)
                                    {
                                        BindVar2015["f_start_time"].VarValue = "0000";
                                        BindVar2015["f_end_time"].VarValue = end_time;
                                        BindVar2015["f_pkocs2015"].VarValue = GetPkOCS2015();
                                    }

                                    #region DUPLICATION CHECK
                                    string spName_dup = "PR_OCSI_IS_JISI_DATETIME";
                                    ArrayList inputList_dup = new ArrayList();
                                    ArrayList outputList_dup = new ArrayList();

                                    if (   !TypeCheck.IsNull(BindVar2015["f_act_date"].VarValue)
                                        && !TypeCheck.IsNull(BindVar2015["f_start_time"].VarValue)
                                        && !TypeCheck.IsNull(BindVar2015["f_end_date"].VarValue)
                                        && !TypeCheck.IsNull(BindVar2015["f_end_time"].VarValue))
                                    {
                                        inputList_dup.Add(BindVar2015["f_hosp_code"].VarValue);
                                        inputList_dup.Add("I");
                                        inputList_dup.Add("AR");
                                        inputList_dup.Add(BindVar2015["f_bunho"].VarValue);
                                        inputList_dup.Add(BindVar2015["f_fkinp1001"].VarValue);
                                        inputList_dup.Add(BindVar2015["f_act_date"].VarValue);
                                        inputList_dup.Add(BindVar2015["f_start_time"].VarValue);
                                        inputList_dup.Add(BindVar2015["f_end_date"].VarValue);
                                        inputList_dup.Add(BindVar2015["f_end_time"].VarValue);
                                        inputList_dup.Add(BindVar2015["f_act_id"].VarValue);

                                        if (Service.ExecuteProcedure(spName_dup, inputList_dup, outputList_dup))
                                        {
                                            if (!outputList_dup[0].ToString().Equals("T"))  // flag
                                                throw new Exception(outputList_dup[1].ToString());
                                        }
                                        else
                                            throw new Exception(Service.ErrFullMsg);
                                    }
                                    #endregion DUPLICATION CHECK

                                    string ocs2005seq = "";
                                    cmdText = @"SELECT NVL(MAX(A.SEQ), 0) + 1 AS SEQ
                                                  FROM OCS2015 A
                                                 WHERE A.HOSP_CODE   = :f_hosp_code
                                                   AND A.BUNHO       = :f_bunho
                                                   AND A.FKINP1001   = :f_fkinp1001
                                                   AND A.ORDER_DATE  = :f_order_date
                                                   AND A.INPUT_GUBUN = :f_input_gubun
                                                   AND A.PK_SEQ      = :f_pk_seq";
                                    ocs2005seq = Service.ExecuteScalar(cmdText, BindVar2015).ToString();

                                    BindVar2015.Remove("f_seq");
                                    BindVar2015.Add("f_seq", ocs2005seq);
                                    BindVar2015.Remove("f_fkocs2005");
                                    BindVar2015.Add("f_fkocs2005", this.mPkOCS2005);
                                    cmdText = @"INSERT INTO OCS2015
                                                         ( SYS_DATE          , SYS_ID         , UPD_DATE       , BUNHO     ,
                                                           FKINP1001         , ORDER_DATE     , INPUT_GUBUN    , INPUT_ID  ,
                                                           PK_SEQ            , SEQ            , INPUT_GWA      , INPUT_DOCTOR,
                                                           DRT_DATE          , ACT_DATE       , ACT_ID    ,
                                                           ACT_RESULT_TEXT   , HOSP_CODE      , PKOCS2015      ,
                                                           DV                , CHANGE_QTY     , FIO2           , SURYANG   ,
                                                           START_TIME        , END_TIME       , END_DATE       , FKOCS2005)
                                                     VALUES
                                                         ( SYSDATE           , :q_user_id     , SYSDATE        , :f_bunho   ,
                                                           :f_fkinp1001      , :f_order_date  , :f_input_gubun , :f_input_id ,
                                                           :f_pk_seq         , :f_seq         , :f_input_gwa   , :f_input_doctor,
                                                           :f_order_date     , :f_act_date    , DECODE(:f_act_date, NULL, NULL, :f_act_id) ,
                                                           :f_act_result_text, :f_hosp_code   , :f_pkocs2015   ,
                                                           :f_dv             , :f_change_qty  , :f_fio2        , :f_suryang ,
                                                           :f_start_time     , :f_end_time    , :f_end_date    , :f_fkocs2005)";

                                    // << 2014/10/26 >>
                                    // MARUMEオーダー用
                                    aList.Add(BindVar2015["f_pkocs2015"].VarValue);
                                    // << 2014/10/26 >>

                                    if (!Service.ExecuteNonQuery(cmdText, BindVar2015)) throw new Exception(Service.ErrFullMsg);

                                    #region ---===============[[  grdOCS2016 Save  ]]===============---
                                    foreach (DataRow row2016 in grdOCS2016.LayoutTable.Rows)
                                    {
                                        cmdText = "";
                                        BindVar2016.Clear();
                                        BindVar2016.Add("f_hosp_code", mHospCode);
                                        BindVar2016.Add("q_user_id",   mUser_id);

                                        foreach (XEditGridCell item2016 in grdOCS2016.CellInfos)
                                        {
                                            BindVar2016.Add("f_" + item2016.CellName, row2016[item2016.CellName].ToString());
                                        }

                                        string seq = "";
                                        BindVarCollection bindVars = new BindVarCollection();
                                        cmdText = @"SELECT NVL(MAX(A.SEQ), 0) + 1 AS SEQ
                                                  FROM OCS2016 A
                                                 WHERE A.HOSP_CODE = :f_hosp_code
                                                   AND A.FKOCS2015 = :f_fkocs2015";
                                        bindVars.Clear();
                                        bindVars.Add("f_hosp_code", mHospCode);
                                        bindVars.Add("f_fkocs2015", BindVar2015["f_pkocs2015"].VarValue);

                                        seq = Service.ExecuteScalar(cmdText, bindVars).ToString();

                                        BindVar2016["f_seq"].VarValue = seq;
                                        BindVar2016["f_fkocs2015"].VarValue = BindVar2015["f_pkocs2015"].VarValue;

                                        switch (row2016.RowState)
                                        {
                                            case DataRowState.Added:

                                                cmdText = @"SELECT OCS2016_SEQ.NEXTVAL FROM DUAL";
                                                string pkocs2016 = Service.ExecuteScalar(cmdText).ToString();
                                                BindVar2016.Remove("f_pkocs2016");
                                                BindVar2016.Add("f_pkocs2016", pkocs2016);

                                                cmdText = @"INSERT INTO OCS2016 (
                                                                         SYS_DATE,     SYS_ID,            UPD_DATE,
                                                                         UPD_ID,       HOSP_CODE,         FKOCS2015,
                                                                         PKOCS2016,    HANGMOG_CODE,      SURYANG,
                                                                         BOM_YN,       BOM_SOURCE_KEY,    SEQ )
                                                            VALUES     ( SYSDATE,      :q_user_id,        SYSDATE,
                                                                         :q_user_id,   :f_hosp_code,      :f_fkocs2015,
                                                                         :f_pkocs2016, :f_hangmog_code,   :f_suryang,
                                                                         :f_bom_yn,    :f_bom_source_key, :f_seq )";

                                                break;

                                            case DataRowState.Modified:
                                                break;
                                        }

                                        if (!Service.ExecuteNonQuery(cmdText, BindVar2016)) throw new Exception(Service.ErrFullMsg);
                                    }
                                    #endregion ---===============[[  grdOCS2016 Save  ]]===============---

                                    #region [ PR_OCS_DIRECT_ACT_AR ]
                                    spName = "PR_OCS_DIRECT_ACT_AR";
                                    inputList = new ArrayList();

                                    inputList.Add(BindVar2015["f_bunho"].VarValue);
                                    inputList.Add(BindVar2015["f_fkinp1001"].VarValue);
                                    inputList.Add(BindVar2015["f_order_date"].VarValue);
                                    inputList.Add(BindVar2015["f_input_gubun"].VarValue);
                                    inputList.Add(BindVar2015["f_pk_seq"].VarValue);
                                    inputList.Add(BindVar2015["f_act_date"].VarValue);
                                    inputList.Add(BindVar2015["f_seq"].VarValue);
                                    inputList.Add(BindVar2015["f_start_time"].VarValue);
                                    inputList.Add(BindVar2015["f_end_time"].VarValue);
                                    inputList.Add(BindVar2015["f_act_id"].VarValue);
                                    inputList.Add(BindVar2015["f_pkocs2015"].VarValue);
                                    

                                    if (Service.ExecuteProcedure(spName, inputList, outputList))
                                    {
                                        if (!outputList[1].ToString().Equals("0"))  // flag
                                        {
                                            throw new Exception(outputList[0].ToString());
                                        }
                                    }
                                    else throw new Exception(Service.ErrFullMsg);
                                    #endregion [ PR_OCS_DIRECT_ACT_AR ]
                                } // for end

                                // << 2014/10/26 >>
                                #region MARUMEオーダー登録
                                for (int i = 0; i < aList.Count; i++)
                                {
                                    /*
                                        I_IUD_GUBUN     IN     VARCHAR2
                                        I_PKOCS2015     IN     NUMBER   
                                        O_ERR           OUT    NUMBER
                                        O_ERR_MSG       OUT    VARCHAR2
                                     */

                                    spName = "PR_OCSI_MARUME_IUD";
                                    inputList = new ArrayList();
                                    outputList = new ArrayList();

                                    inputList.Add("INSERT");
                                    inputList.Add(aList[i].ToString());

                                    if (Service.ExecuteProcedure(spName, inputList, outputList))
                                    {
                                        if (!outputList[0].ToString().Equals("1"))  // 1 : TRUE, 0 : FALSE
                                        {
                                            throw new Exception(outputList[0].ToString());
                                        }
                                        {

                                        }
                                    }
                                    else throw new Exception(Service.ErrFullMsg);
                                }
                                #endregion MARUMEオーダー登録
                                // << 2014/10/26 >>

                            break;

                        case DataRowState.Modified:
                            end_time = BindVar2015["f_end_time"].VarValue;
                            start_time = BindVar2015["f_start_time"].VarValue;

                            for (int i = 1; i <= process_days; i++)
                            {

                                BindVar2015["f_act_date"].VarValue = DateTime.Parse(row2015["act_date"].ToString()).AddDays(i - 1).ToString("yyyy/MM/dd");

                                if (i == 1)
                                {
                                    BindVar2015["f_start_time"].VarValue = start_time;
                                    if (process_days > 1)
                                        BindVar2015["f_end_time"].VarValue = "2359";
                                }
                                else if (i != 1 && i != process_days)
                                {
                                    BindVar2015["f_start_time"].VarValue = "0000";
                                    BindVar2015["f_end_time"].VarValue = "2359";
                                    BindVar2015["f_pkocs2015"].VarValue = GetPkOCS2015();
                                }
                                else if (i == process_days)
                                {
                                    BindVar2015["f_start_time"].VarValue = "0000";
                                    BindVar2015["f_end_time"].VarValue = end_time;
                                    BindVar2015["f_pkocs2015"].VarValue = GetPkOCS2015();
                                }

                                if (process_days > 1) //
                                {
                                    BindVar2015["f_end_date"].VarValue = BindVar2015["f_act_date"].VarValue;
                                }

                                // DUP_CHECK
                                string spName_dup = "PR_OCSI_IS_JISI_DATETIME";
                                ArrayList inputList_dup = new ArrayList();
                                ArrayList outputList_dup = new ArrayList();

                                if (   !TypeCheck.IsNull(BindVar2015["f_act_date"].VarValue)
                                    && !TypeCheck.IsNull(BindVar2015["f_start_time"].VarValue)
                                    && !TypeCheck.IsNull(BindVar2015["f_end_date"].VarValue)
                                    && !TypeCheck.IsNull(BindVar2015["f_end_time"].VarValue))
                                {
                                    inputList_dup.Add(BindVar2015["f_hosp_code"].VarValue);
                                    inputList_dup.Add("I");
                                    inputList_dup.Add("AR");
                                    inputList_dup.Add(BindVar2015["f_bunho"].VarValue);
                                    inputList_dup.Add(BindVar2015["f_fkinp1001"].VarValue);
                                    inputList_dup.Add(BindVar2015["f_act_date"].VarValue);
                                    inputList_dup.Add(BindVar2015["f_start_time"].VarValue);
                                    inputList_dup.Add(BindVar2015["f_end_date"].VarValue);
                                    inputList_dup.Add(BindVar2015["f_end_time"].VarValue);
                                    inputList_dup.Add(BindVar2015["f_act_id"].VarValue);

                                    if (Service.ExecuteProcedure(spName_dup, inputList_dup, outputList_dup))
                                    {
                                        if (!outputList_dup[0].ToString().Equals("T"))  // flag
                                            throw new Exception(outputList_dup[1].ToString());
                                    }
                                    else
                                        throw new Exception(Service.ErrFullMsg);
                                }

                                if (i == 1)
                                {

                                    cmdText = @"UPDATE OCS2015
                                                   SET UPD_ID          = :f_act_id                                  ,
                                                       UPD_DATE        = SYSDATE                                    ,
                                                       ACT_DATE        = :f_act_date                                ,
                                                       ACT_ID          = DECODE(:f_act_date, NULL, NULL, :f_act_id) ,
                                                       ACT_RESULT_TEXT = :f_act_result_text                         ,
                                                       SURYANG         = :f_suryang                                 ,
                                                       DV              = :f_dv                                      ,
                                                       CHANGE_QTY      = :f_change_qty                              ,
                                                       FIO2            = :f_fio2                                    ,
                                                       START_TIME      = :f_start_time                              ,
                                                       END_TIME        = :f_end_time                                ,
                                                       END_DATE        = :f_end_date
                                                 WHERE HOSP_CODE       = :f_hosp_code
                                                   AND PKOCS2015       = :f_pkocs2015";

                                    // << 2014/10/26 >>
                                    // MARUMEオーダー用
                                    aList.Add(BindVar2015["f_pkocs2015"].VarValue);
                                    // << 2014/10/26 >>

                                    if (!Service.ExecuteNonQuery(cmdText, BindVar2015)) throw new Exception(Service.ErrFullMsg);
                                    //数量、時間

                                    //int start_hour = int.Parse(row2015["start_time"].ToString().Substring(0, 2));
                                    //int end_hour = int.Parse(row2015["end_time"].ToString().Substring(0, 2));
                                    //int start_minute = int.Parse(row2015["start_time"].ToString().Substring(2, 2));
                                    //int end_minute = int.Parse(row2015["end_time"].ToString().Substring(2, 2));


                                    //int result_hour = end_hour - start_hour;
                                    //int result_minute = end_minute - start_minute;

                                    //int total_minute = (result_hour * 60) + result_minute;

                                    int nalsu = 0;

                                    inputList = new ArrayList();
                                    outputList = new ArrayList();

                                    #region [ PR_OCS_DIRECT_ACT_AR ]
                                    spName = "PR_OCS_DIRECT_ACT_AR";

                                    inputList.Add(BindVar2015["f_bunho"].VarValue);
                                    inputList.Add(BindVar2015["f_fkinp1001"].VarValue);
                                    inputList.Add(BindVar2015["f_order_date"].VarValue);
                                    inputList.Add(BindVar2015["f_input_gubun"].VarValue);
                                    inputList.Add(BindVar2015["f_pk_seq"].VarValue);
                                    inputList.Add(BindVar2015["f_act_date"].VarValue);
                                    inputList.Add(BindVar2015["f_seq"].VarValue);
                                    inputList.Add(BindVar2015["f_start_time"].VarValue);
                                    inputList.Add(BindVar2015["f_end_time"].VarValue);  // PROCEDUREで　NULLの場合　RETURN
                                    inputList.Add(BindVar2015["f_act_id"].VarValue);
                                    inputList.Add(BindVar2015["f_pkocs2015"].VarValue);
                                    if (Service.ExecuteProcedure(spName, inputList, outputList))
                                    {
                                        if (!outputList[1].ToString().Equals("0"))  // flag
                                        {
                                            throw new Exception(outputList[0].ToString());
                                        }
                                    }
                                    else throw new Exception(Service.ErrFullMsg);
                                    #endregion [ PR_OCS_DIRECT_ACT_AR ]
                                }
                                else
                                {
                                    string ocs2005seq = "";
                                    cmdText = @"SELECT NVL(MAX(A.SEQ), 0) + 1 AS SEQ
                                                  FROM OCS2015 A
                                                 WHERE A.HOSP_CODE   = :f_hosp_code
                                                   AND A.BUNHO       = :f_bunho
                                                   AND A.FKINP1001   = :f_fkinp1001
                                                   AND A.ORDER_DATE  = :f_order_date
                                                   AND A.INPUT_GUBUN = :f_input_gubun
                                                   AND A.PK_SEQ      = :f_pk_seq";
                                    ocs2005seq = Service.ExecuteScalar(cmdText, BindVar2015).ToString();

                                    BindVar2015.Remove("f_seq");
                                    BindVar2015.Add("f_seq", ocs2005seq);
                                    BindVar2015.Remove("f_fkocs2005");
                                    BindVar2015.Add("f_fkocs2005", this.mPkOCS2005);
                                    cmdText = @"INSERT INTO OCS2015
                                                         ( SYS_DATE          , SYS_ID         , UPD_DATE       , BUNHO     ,
                                                           FKINP1001         , ORDER_DATE     , INPUT_GUBUN    , INPUT_ID  ,
                                                           PK_SEQ            , SEQ            , INPUT_GWA      , INPUT_DOCTOR,
                                                           DRT_DATE          , ACT_DATE       , ACT_ID    ,
                                                           ACT_RESULT_TEXT   , HOSP_CODE      , PKOCS2015      ,
                                                           DV                , CHANGE_QTY     , FIO2           , SURYANG   ,
                                                           START_TIME        , END_TIME       , END_DATE       , FKOCS2005)
                                                     VALUES
                                                         ( SYSDATE           , :q_user_id     , SYSDATE        , :f_bunho   ,
                                                           :f_fkinp1001      , :f_order_date  , :f_input_gubun , :f_input_id ,
                                                           :f_pk_seq         , :f_seq         , :f_input_gwa   , :f_input_doctor,
                                                           :f_order_date     , :f_act_date    , DECODE(:f_act_date, NULL, NULL, :f_act_id) ,
                                                           :f_act_result_text, :f_hosp_code   , :f_pkocs2015   ,
                                                           :f_dv             , :f_change_qty  , :f_fio2        , :f_suryang ,
                                                           :f_start_time     , :f_end_time    , :f_end_date    , :f_fkocs2005)";

                                    // << 2014/10/26 >>
                                    // MARUMEオーダー用
                                    aList.Add(BindVar2015["f_pkocs2015"].VarValue);
                                    // << 2014/10/26 >>

                                    if (!Service.ExecuteNonQuery(cmdText, BindVar2015)) throw new Exception(Service.ErrFullMsg);

                                    #region ---===============[[  grdOCS2016 Save  ]]===============---
                                    foreach (DataRow row2016 in grdOCS2016.LayoutTable.Rows)
                                    {
                                        cmdText = "";
                                        BindVar2016.Clear();
                                        BindVar2016.Add("f_hosp_code", mHospCode);
                                        BindVar2016.Add("q_user_id", mUser_id);

                                        foreach (XEditGridCell item2016 in grdOCS2016.CellInfos)
                                        {
                                            BindVar2016.Add("f_" + item2016.CellName, row2016[item2016.CellName].ToString());
                                        }

                                        if (i != 1)
                                        {
                                            string seq = "";
                                            BindVarCollection bindVars = new BindVarCollection();
                                            cmdText = @"SELECT NVL(MAX(A.SEQ), 0) + 1 AS SEQ
                                                  FROM OCS2016 A
                                                 WHERE A.HOSP_CODE = :f_hosp_code
                                                   AND A.FKOCS2015 = :f_fkocs2015";
                                            bindVars.Clear();
                                            bindVars.Add("f_hosp_code", mHospCode);
                                            bindVars.Add("f_fkocs2015", BindVar2015["f_pkocs2015"].VarValue);

                                            seq = Service.ExecuteScalar(cmdText, bindVars).ToString();

                                            BindVar2016["f_seq"].VarValue = seq;
                                            BindVar2016["f_fkocs2015"].VarValue = BindVar2015["f_pkocs2015"].VarValue;
                                        }
                                        //switch (row2016.RowState)
                                        //{
                                        //    case DataRowState.Added:

                                                cmdText = @"SELECT OCS2016_SEQ.NEXTVAL FROM DUAL";
                                                string pkocs2016 = Service.ExecuteScalar(cmdText).ToString();
                                                BindVar2016.Remove("f_pkocs2016");
                                                BindVar2016.Add("f_pkocs2016", pkocs2016);

                                                cmdText = @"INSERT INTO OCS2016 (
                                                                         SYS_DATE,     SYS_ID,            UPD_DATE,
                                                                         UPD_ID,       HOSP_CODE,         FKOCS2015,
                                                                         PKOCS2016,    HANGMOG_CODE,      SURYANG,
                                                                         BOM_YN,       BOM_SOURCE_KEY,    SEQ )
                                                            VALUES     ( SYSDATE,      :q_user_id,        SYSDATE,
                                                                         :q_user_id,   :f_hosp_code,      :f_fkocs2015,
                                                                         :f_pkocs2016, :f_hangmog_code,   :f_suryang,
                                                                         :f_bom_yn,    :f_bom_source_key, :f_seq )";

                                                //break;

                                            //case DataRowState.Modified:
                                            //    break;
                                        //}

                                        if (!Service.ExecuteNonQuery(cmdText, BindVar2016)) throw new Exception(Service.ErrFullMsg);
                                    }
                                    #endregion ---===============[[  grdOCS2016 Save  ]]===============---

                                    #region [ PR_OCS_DIRECT_ACT_AR ]
                                    spName = "PR_OCS_DIRECT_ACT_AR";
                                    inputList = new ArrayList();

                                    inputList.Add(BindVar2015["f_bunho"].VarValue);
                                    inputList.Add(BindVar2015["f_fkinp1001"].VarValue);
                                    inputList.Add(BindVar2015["f_order_date"].VarValue);
                                    inputList.Add(BindVar2015["f_input_gubun"].VarValue);
                                    inputList.Add(BindVar2015["f_pk_seq"].VarValue);
                                    inputList.Add(BindVar2015["f_act_date"].VarValue);
                                    inputList.Add(BindVar2015["f_seq"].VarValue);
                                    inputList.Add(BindVar2015["f_start_time"].VarValue);
                                    inputList.Add(BindVar2015["f_end_time"].VarValue);
                                    inputList.Add(BindVar2015["f_act_id"].VarValue);
                                    inputList.Add(BindVar2015["f_pkocs2015"].VarValue);
                                    if (Service.ExecuteProcedure(spName, inputList, outputList))
                                    {
                                        if (!outputList[1].ToString().Equals("0"))  // flag
                                        {
                                            throw new Exception(outputList[0].ToString());
                                        }
                                    }
                                    else throw new Exception(Service.ErrFullMsg);
                                    #endregion [ PR_OCS_DIRECT_ACT_AR ]
                                }
                            }

                            // << 2014/10/26 >>
                            #region MARUMEオーダー登録
                            for (int i = 0; i < aList.Count; i++)
                            {
                                /*
                                    I_IUD_GUBUN     IN     VARCHAR2
                                    I_PKOCS2015     IN     NUMBER   
                                    O_ERR           OUT    NUMBER
                                    O_ERR_MSG       OUT    VARCHAR2
                                 */

                                spName = "PR_OCSI_MARUME_IUD";
                                inputList = new ArrayList();
                                outputList = new ArrayList();

                                inputList.Add("INSERT");
                                inputList.Add(aList[i].ToString());

                                if (Service.ExecuteProcedure(spName, inputList, outputList))
                                {
                                    if (!outputList[0].ToString().Equals("1"))  // 1 : TRUE, 0 : FALSE
                                    {
                                        throw new Exception(outputList[0].ToString());
                                    }
                                    {

                                    }
                                }
                                else throw new Exception(Service.ErrFullMsg);
                            }
                            #endregion MARUMEオーダー登録
                            // << 2014/10/26 >>

                            break;
                    }
                }
            }
            catch (Exception xe)
            {
                Service.RollbackTransaction();

                mbxMsg = "保存に失敗しました｡";
                mbxMsg = mbxMsg + "\n\r" + xe.Message;
                mbxCap = "保存エラー";

                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Error);
                return;
            }

            Service.CommitTransaction();

            mbxMsg = "保存が完了しました。";
            SetMsg(mbxMsg);
            mActing_yn = "Y";
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region [ XSavePerformer ]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private frmARActing parent = null;
            public XSavePerformer(frmARActing parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                //Grid에서 넘어온 Bind 변수에 q_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                switch (callerID)
                {
                    #region /****** grdOCS2015 Save ******/
                    case '5':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                string ocs2005seq = "";
                                cmdText = @"SELECT NVL(MAX(A.SEQ), 0) + 1 AS SEQ
                                              FROM OCS2015 A
                                             WHERE A.HOSP_CODE   = :f_hosp_code
                                               AND A.BUNHO       = :f_bunho
                                               AND A.FKINP1001   = :f_fkinp1001
                                               AND A.ORDER_DATE  = :f_order_date
                                               AND A.INPUT_GUBUN = :f_input_gubun
                                               AND A.PK_SEQ      = :f_pk_seq";

                                ocs2005seq = Service.ExecuteScalar(cmdText, item.BindVarList).ToString();

                                item.BindVarList.Remove("f_seq");
                                item.BindVarList.Add("f_seq", ocs2005seq);
                                item.BindVarList.Remove("f_fkocs2005");
                                item.BindVarList.Add("f_fkocs2005", parent.mPkOCS2005);
                                cmdText = @"INSERT INTO OCS2015
                                                 ( SYS_DATE          , SYS_ID         , UPD_DATE       , BUNHO     ,
                                                   FKINP1001         , ORDER_DATE     , INPUT_GUBUN    , INPUT_ID  ,
                                                   PK_SEQ            , SEQ            , INPUT_GWA      , INPUT_DOCTOR,
                                                   DRT_DATE          , ACT_DATE       , ACT_ID    ,
                                                   ACT_RESULT_TEXT   , HOSP_CODE      , PKOCS2015      ,
                                                   DV                , CHANGE_QTY     , FIO2           , SURYANG   ,
                                                   START_TIME        , END_TIME       , END_DATE       , FKOCS2005        )
                                             VALUES
                                                 ( SYSDATE           , :q_user_id     , SYSDATE        , :f_bunho   ,
                                                   :f_fkinp1001      , :f_order_date  , :f_input_gubun , :f_input_id ,
                                                   :f_pk_seq         , :f_seq         , :f_input_gwa   , :f_input_doctor,
                                                   :f_order_date     , :f_act_date    , DECODE(:f_act_date, NULL, NULL, :f_act_id) ,
                                                   :f_act_result_text, :f_hosp_code   , :f_pkocs2015   ,
                                                   :f_dv             , :f_change_qty  , :f_fio2        , :f_suryang ,
                                                   :f_start_time     , :f_end_time    , :f_end_date    , :f_fkocs2005 )";
                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE OCS2015
                                               SET UPD_ID          = :f_act_id                                  ,
                                                   UPD_DATE        = SYSDATE                                    ,
                                                   ACT_DATE        = :f_act_date                                ,
                                                   ACT_ID          = DECODE(:f_act_date, NULL, NULL, :f_act_id) ,
                                                   ACT_RESULT_TEXT = :f_act_result_text                         ,
                                                   SURYANG         = :f_suryang                                 ,
                                                   DV              = :f_dv                                      ,
                                                   CHANGE_QTY      = :f_change_qty                              ,
                                                   FIO2            = :f_fio2                                    ,
                                                   START_TIME      = :f_start_time                              ,
                                                   END_TIME        = :f_end_time                                ,
                                                   END_DATE        = :f_end_date
                                             WHERE HOSP_CODE       = :f_hosp_code
                                               AND PKOCS2015       = :f_pkocs2015";

                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE FROM OCS2015
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND PKOCS2015 = :f_pkocs2015";

                                break;
                        }
                        break;
                    #endregion

                    #region /****** grdOCS2016 Save ******/
                    case '6':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"SELECT OCS2016_SEQ.NEXTVAL FROM DUAL";
                                string pkocs2016 = Service.ExecuteScalar(cmdText).ToString();
                                item.BindVarList.Remove("f_pkocs2016");
                                item.BindVarList.Add("f_pkocs2016", pkocs2016);

                                cmdText = @"INSERT INTO OCS2016
            (
             SYS_DATE,        SYS_ID,     UPD_DATE,  UPD_ID,          HOSP_CODE,  FKOCS2015,     PKOCS2016,
             HANGMOG_CODE,    SURYANG,    BOM_YN,    BOM_SOURCE_KEY,  SEQ
            )
VALUES      (
             SYSDATE,         :q_user_id, SYSDATE,   :q_user_id,     :f_hosp_code, :f_fkocs2015, :f_pkocs2016,
             :f_hangmog_code, :f_suryang, :f_bom_yn, :f_bom_source_key, :f_seq
            )";

                                break;
                            case DataRowState.Modified:
                                cmdText = @"";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE FROM OCS2016
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND PKOCS2016 = :f_pkocs2016";
                                break;
                        }
                        break;
                    #endregion
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void grdOCS2015_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            grdOCS2016.Reset();
            grdOCS2016.QueryLayout(false);
        }

        private void grdOCS2015_Validating(object sender, CancelEventArgs e)
        {
            if (this.grdOCS2015.CurrentColName == "end_date" && this.grdOCS2015.GetItemString(this.grdOCS2015.CurrentRowNumber, "end_date") == "")
                this.grdOCS2015.SetItemValue(this.grdOCS2015.CurrentRowNumber, this.grdOCS2015.CurrentColName, dpxAct_date.Text);

            if (this.grdOCS2015.CurrentColName == "end_time" && this.grdOCS2015.GetItemString(this.grdOCS2015.CurrentRowNumber, "end_date") == "")
                this.grdOCS2015.SetItemValue(this.grdOCS2015.CurrentRowNumber, "end_date", dpxAct_date.Text);
        }

        private void grdOCS2015_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["act_date"].ToString() == mOrder_date)
                e.BackColor = Color.LightGreen;
        }
        private void SetTotalMinutes(int currRow)
        {
            double totalMinutes = 0;

            if (this.grdOCS2015.GetItemString(currRow, "act_date") != ""
                && this.grdOCS2015.GetItemString(currRow, "start_time") != ""
                && this.grdOCS2015.GetItemString(currRow, "end_date") != ""
                && this.grdOCS2015.GetItemString(currRow, "end_time") != ""
                )
            {
                totalMinutes = (DateTime.Parse(this.grdOCS2015.GetItemString(currRow, "end_date") + " " + this.grdOCS2015.GetItemString(currRow, "end_time").Substring(0, 2) + ":" + this.grdOCS2015.GetItemString(currRow, "end_time").Substring(2, 2)) - DateTime.Parse(this.grdOCS2015.GetItemString(currRow, "act_date") + " " + this.grdOCS2015.GetItemString(currRow, "start_time").Substring(0, 2) + ":" + this.grdOCS2015.GetItemString(currRow, "start_time").Substring(2, 2))).TotalMinutes + 1;
            }

            this.grdOCS2015.SetItemValue(currRow, "total_min", totalMinutes.ToString());
        }
    }
}

