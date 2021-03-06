using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

using IHIS.Framework;

namespace IHIS.OCSI
{
	public class frmInsulinActing : IHIS.Framework.XForm
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
        private string mInput_gwa    = "";
        private string mInput_doctor = "";
        private string mPkOCS2005    = "";
        private string mPkOCS6015    = "";
        private string mSource_order_date = "";
        private OCS.OrderBiz mOrderBiz = new IHIS.OCS.OrderBiz();
		//Control
        private Hashtable htControl = new Hashtable();

        // HOSPITAL CODE
        private string mHospCode = EnvironInfo.HospCode;
		#endregion

		private IHIS.Framework.XFlatLabel xFlatLabel1;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XDisplayBox dpbAct_id_name;
		private IHIS.Framework.XPanel pnlDirectText;
		private IHIS.Framework.XTextBox txtDirect_text;
        private IHIS.Framework.XFlatLabel xFlatLabel5;
		private IHIS.Framework.XPanel pnlActingInfo;
		private IHIS.Framework.XPanel pnlAct_date;
		private IHIS.Framework.MultiLayout layOCS2005;
        private IHIS.Framework.MultiLayout layOCS2006;
        private IHIS.Framework.XDisplayBox dpbAct_date;
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
        private XEditGrid grdOCS2015;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell50;
        private XEditGridCell xEditGridCell51;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell58;
        private XEditGrid grdOCS2016;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem48;
        private MultiLayoutItem multiLayoutItem49;
        private MultiLayoutItem multiLayoutItem50;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XPanel pnlBody;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XCheckBox cbxCreateOCS2003_YN;
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
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XCheckBox cbxCreateOCS2003BS_YN;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell19;
		private System.ComponentModel.IContainer components = null;

		public frmInsulinActing()
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

        public frmInsulinActing(string i_bunho,
                                string i_fkinp1001,
                                string i_order_date,
                                string i_input_gubun,
                                string i_ocs2005_seq,
                                string i_direct_gubun,
                                string i_direct_code,
                                string i_user_id,
                                string i_input_gwa,
                                string i_input_doctor,
                                string i_pkocs2005,
                                string i_pkocs6015,
                                string i_source_order_date)
        {

            mBunho = i_bunho;
            mFkinp1001 = i_fkinp1001;
            mOrder_date = i_order_date;
            mInput_gubun = i_input_gubun;
            mOcs2005_seq = i_ocs2005_seq;
            mDirect_gubun = i_direct_gubun;
            mDirect_code = i_direct_code;
            mUser_id = i_user_id;
            mUser_name = GetAdminUSER_NAME(i_user_id);
            mInput_gwa = i_input_gwa;
            mInput_doctor = i_input_doctor;
            mPkOCS2005 = i_pkocs2005;
            mPkOCS6015 = i_pkocs6015;
            mSource_order_date = i_source_order_date;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInsulinActing));
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cbxCreateOCS2003BS_YN = new IHIS.Framework.XCheckBox();
            this.cbxCreateOCS2003_YN = new IHIS.Framework.XCheckBox();
            this.grdOCS2015 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.grdOCS2016 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.dpbAct_id_name = new IHIS.Framework.XDisplayBox();
            this.pnlActingInfo = new IHIS.Framework.XPanel();
            this.pnlAct_date = new IHIS.Framework.XPanel();
            this.dpbAct_date = new IHIS.Framework.XDisplayBox();
            this.pnlDirectText = new IHIS.Framework.XPanel();
            this.txtDirect_text = new IHIS.Framework.XTextBox();
            this.xFlatLabel5 = new IHIS.Framework.XFlatLabel();
            this.layOCS2005 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.layOCS2006 = new IHIS.Framework.MultiLayout();
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
            this.pnlBody = new IHIS.Framework.XPanel();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2015)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2016)).BeginInit();
            this.pnlActingInfo.SuspendLayout();
            this.pnlAct_date.SuspendLayout();
            this.pnlDirectText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS2005)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS2006)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xFlatLabel1.Location = new System.Drawing.Point(12, 6);
            this.xFlatLabel1.Name = "xFlatLabel1";
            this.xFlatLabel1.Size = new System.Drawing.Size(58, 20);
            this.xFlatLabel1.TabIndex = 6;
            this.xFlatLabel1.Text = "施行日";
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(483, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(406, 34);
            this.btnList.TabIndex = 9;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.cbxCreateOCS2003BS_YN);
            this.xPanel1.Controls.Add(this.cbxCreateOCS2003_YN);
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 280);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(891, 36);
            this.xPanel1.TabIndex = 45;
            // 
            // cbxCreateOCS2003BS_YN
            // 
            this.cbxCreateOCS2003BS_YN.AutoSize = true;
            this.cbxCreateOCS2003BS_YN.Location = new System.Drawing.Point(147, 9);
            this.cbxCreateOCS2003BS_YN.Name = "cbxCreateOCS2003BS_YN";
            this.cbxCreateOCS2003BS_YN.Size = new System.Drawing.Size(196, 17);
            this.cbxCreateOCS2003BS_YN.TabIndex = 10;
            this.cbxCreateOCS2003BS_YN.Text = "検体検査（グルコース）オーダ生成";
            this.cbxCreateOCS2003BS_YN.UseVisualStyleBackColor = false;
            // 
            // cbxCreateOCS2003_YN
            // 
            this.cbxCreateOCS2003_YN.AutoSize = true;
            this.cbxCreateOCS2003_YN.Location = new System.Drawing.Point(348, 9);
            this.cbxCreateOCS2003_YN.Name = "cbxCreateOCS2003_YN";
            this.cbxCreateOCS2003_YN.Size = new System.Drawing.Size(126, 17);
            this.cbxCreateOCS2003_YN.TabIndex = 10;
            this.cbxCreateOCS2003_YN.Text = "インスリンオーダ生成";
            this.cbxCreateOCS2003_YN.UseVisualStyleBackColor = false;
            // 
            // grdOCS2015
            // 
            this.grdOCS2015.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell58,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell54,
            this.xEditGridCell7,
            this.xEditGridCell6,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell19});
            this.grdOCS2015.ColPerLine = 17;
            this.grdOCS2015.Cols = 17;
            this.grdOCS2015.ControlBinding = true;
            this.grdOCS2015.FixedRows = 1;
            this.grdOCS2015.HeaderHeights.Add(21);
            this.grdOCS2015.Location = new System.Drawing.Point(6, 250);
            this.grdOCS2015.Name = "grdOCS2015";
            this.grdOCS2015.QuerySQL = resources.GetString("grdOCS2015.QuerySQL");
            this.grdOCS2015.Rows = 2;
            this.grdOCS2015.Size = new System.Drawing.Size(599, 223);
            this.grdOCS2015.TabIndex = 56;
            this.grdOCS2015.UseDefaultTransaction = false;
            this.grdOCS2015.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS2015_QueryEnd);
            this.grdOCS2015.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS2015_QueryStarting);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "bunho";
            this.xEditGridCell21.CellWidth = 89;
            this.xEditGridCell21.HeaderText = "bunho";
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "fkinp1001";
            this.xEditGridCell22.Col = 1;
            this.xEditGridCell22.HeaderText = "fkinp1001";
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "order_date";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell23.Col = 2;
            this.xEditGridCell23.HeaderText = "order_date";
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "input_gubun";
            this.xEditGridCell24.Col = 3;
            this.xEditGridCell24.HeaderText = "input_gubun";
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "input_id";
            this.xEditGridCell58.Col = 4;
            this.xEditGridCell58.HeaderText = "input_id";
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "pk_seq";
            this.xEditGridCell25.Col = 5;
            this.xEditGridCell25.HeaderText = "pk_seq";
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "drt_date";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell26.Col = 6;
            this.xEditGridCell26.HeaderText = "drt_date";
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "act_date";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.DateTime;
            this.xEditGridCell27.Col = 7;
            this.xEditGridCell27.HeaderText = "act_date";
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "act_id";
            this.xEditGridCell28.Col = 8;
            this.xEditGridCell28.HeaderText = "act_id";
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "act_result_text";
            this.xEditGridCell29.Col = 9;
            this.xEditGridCell29.HeaderText = "act_result_text";
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdatable = false;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "act_id_name";
            this.xEditGridCell50.Col = 10;
            this.xEditGridCell50.HeaderText = "act_id_name";
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "act_time";
            this.xEditGridCell51.Col = 11;
            this.xEditGridCell51.HeaderText = "act_time";
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "blood_sugar";
            this.xEditGridCell54.Col = 12;
            this.xEditGridCell54.HeaderText = "blood_sugar";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "time_gubun";
            this.xEditGridCell7.Col = 14;
            this.xEditGridCell7.HeaderText = "time_gubun";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "pkocs2015";
            this.xEditGridCell6.Col = 13;
            this.xEditGridCell6.HeaderText = "pkocs2015";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "input_gwa";
            this.xEditGridCell10.Col = 15;
            this.xEditGridCell10.HeaderText = "input_gwa";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "input_doctor";
            this.xEditGridCell11.Col = 16;
            this.xEditGridCell11.HeaderText = "input_doctor";
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "fkocs2005";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.HeaderText = "fkocs2005";
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // grdOCS2016
            // 
            this.grdOCS2016.CallerID = '2';
            this.grdOCS2016.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell8,
            this.xEditGridCell5,
            this.xEditGridCell9,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17});
            this.grdOCS2016.ColPerLine = 7;
            this.grdOCS2016.Cols = 7;
            this.grdOCS2016.ControlBinding = true;
            this.grdOCS2016.FixedRows = 1;
            this.grdOCS2016.HeaderHeights.Add(36);
            this.grdOCS2016.IncludeUnChangedRowAtSaving = true;
            this.grdOCS2016.Location = new System.Drawing.Point(6, 6);
            this.grdOCS2016.Name = "grdOCS2016";
            this.grdOCS2016.QuerySQL = resources.GetString("grdOCS2016.QuerySQL");
            this.grdOCS2016.Rows = 2;
            this.grdOCS2016.Size = new System.Drawing.Size(599, 238);
            this.grdOCS2016.TabIndex = 57;
            this.grdOCS2016.UseDefaultTransaction = false;
            this.grdOCS2016.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS2016_QueryStarting);
            this.grdOCS2016.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS2016_GridColumnProtectModify);
            this.grdOCS2016.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS2016_GridColumnChanged);
            this.grdOCS2016.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdOCS2016_GridFindSelected);
            this.grdOCS2016.GridDDLBSetting += new IHIS.Framework.GridDDLBSettingEventHandler(this.grdOCS2016_GridDDLBSetting);
            this.grdOCS2016.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOCS2016_GridFindClick);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "fkocs2015";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "fkocs2015";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "pkocs2016";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "pkocs2016";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "hangmog_code";
            this.xEditGridCell3.CellWidth = 266;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell3.HeaderText = "薬剤";
            this.xEditGridCell3.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell3.UserSQL = resources.GetString("xEditGridCell3.UserSQL");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 2;
            this.xEditGridCell4.CellName = "suryang";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell4.CellWidth = 43;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.HeaderText = "数量";
            this.xEditGridCell4.MaxinumCipher = 2;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 4;
            this.xEditGridCell8.CellName = "blood_sugar";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell8.CellWidth = 50;
            this.xEditGridCell8.Col = 1;
            this.xEditGridCell8.HeaderText = "血糖";
            this.xEditGridCell8.MaxinumCipher = 4;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "time_gubun";
            this.xEditGridCell5.CellWidth = 54;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "時間区分";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "seq";
            this.xEditGridCell9.CellWidth = 42;
            this.xEditGridCell9.HeaderText = "順番";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "act_time";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell12.Col = 2;
            this.xEditGridCell12.HeaderText = "実施時間";
            this.xEditGridCell12.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell12.Mask = "HH:MI";
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "ymd";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "ymd";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "ord_danui";
            this.xEditGridCell14.CellWidth = 43;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "ord_danui_name";
            this.xEditGridCell15.CellWidth = 42;
            this.xEditGridCell15.Col = 5;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell15.HeaderText = "オーダ\r\n単位";
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "muhyo";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderText = "無効";
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "brought_drg_yn";
            this.xEditGridCell17.CellWidth = 49;
            this.xEditGridCell17.Col = 6;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell17.HeaderText = "持参薬";
            // 
            // dpbAct_id_name
            // 
            this.dpbAct_id_name.Location = new System.Drawing.Point(196, 6);
            this.dpbAct_id_name.Name = "dpbAct_id_name";
            this.dpbAct_id_name.Size = new System.Drawing.Size(127, 21);
            this.dpbAct_id_name.TabIndex = 51;
            // 
            // pnlActingInfo
            // 
            this.pnlActingInfo.Controls.Add(this.grdOCS2016);
            this.pnlActingInfo.Controls.Add(this.grdOCS2015);
            this.pnlActingInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActingInfo.Location = new System.Drawing.Point(281, 0);
            this.pnlActingInfo.Name = "pnlActingInfo";
            this.pnlActingInfo.Size = new System.Drawing.Size(610, 248);
            this.pnlActingInfo.TabIndex = 1;
            // 
            // pnlAct_date
            // 
            this.pnlAct_date.Controls.Add(this.dpbAct_date);
            this.pnlAct_date.Controls.Add(this.dpbAct_id_name);
            this.pnlAct_date.Controls.Add(this.xFlatLabel1);
            this.pnlAct_date.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAct_date.Location = new System.Drawing.Point(0, 0);
            this.pnlAct_date.Name = "pnlAct_date";
            this.pnlAct_date.Size = new System.Drawing.Size(891, 32);
            this.pnlAct_date.TabIndex = 0;
            // 
            // dpbAct_date
            // 
            this.dpbAct_date.EditMaskType = IHIS.Framework.MaskType.Date;
            this.dpbAct_date.IsJapanYearType = true;
            this.dpbAct_date.Location = new System.Drawing.Point(56, 6);
            this.dpbAct_date.Name = "dpbAct_date";
            this.dpbAct_date.Size = new System.Drawing.Size(136, 21);
            this.dpbAct_date.TabIndex = 52;
            this.dpbAct_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDirectText
            // 
            this.pnlDirectText.Controls.Add(this.txtDirect_text);
            this.pnlDirectText.Controls.Add(this.xFlatLabel5);
            this.pnlDirectText.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlDirectText.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDirectText.DrawBorder = true;
            this.pnlDirectText.Location = new System.Drawing.Point(0, 0);
            this.pnlDirectText.Name = "pnlDirectText";
            this.pnlDirectText.Size = new System.Drawing.Size(281, 248);
            this.pnlDirectText.TabIndex = 57;
            // 
            // txtDirect_text
            // 
            this.txtDirect_text.AllowDrop = true;
            this.txtDirect_text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirect_text.ApplyByteLimit = true;
            this.txtDirect_text.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtDirect_text.Location = new System.Drawing.Point(8, 24);
            this.txtDirect_text.MaxLength = 1000;
            this.txtDirect_text.Multiline = true;
            this.txtDirect_text.Name = "txtDirect_text";
            this.txtDirect_text.ReadOnly = true;
            this.txtDirect_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDirect_text.Size = new System.Drawing.Size(251, 203);
            this.txtDirect_text.TabIndex = 4;
            this.txtDirect_text.TabStop = false;
            // 
            // xFlatLabel5
            // 
            this.xFlatLabel5.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel5.Image = ((System.Drawing.Image)(resources.GetObject("xFlatLabel5.Image")));
            this.xFlatLabel5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xFlatLabel5.Location = new System.Drawing.Point(8, 4);
            this.xFlatLabel5.Name = "xFlatLabel5";
            this.xFlatLabel5.Size = new System.Drawing.Size(130, 20);
            this.xFlatLabel5.TabIndex = 21;
            this.xFlatLabel5.Text = "     指示事項 内容";
            // 
            // layOCS2005
            // 
            this.layOCS2005.CallerID = '9';
            this.layOCS2005.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem48,
            this.multiLayoutItem49,
            this.multiLayoutItem50});
            this.layOCS2005.QuerySQL = resources.GetString("layOCS2005.QuerySQL");
            this.layOCS2005.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layOCS2005_QueryStarting);
            this.layOCS2005.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layOCS2005_QueryEnd);
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "bunho";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "fkinp1001";
            this.multiLayoutItem22.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "order_date";
            this.multiLayoutItem23.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "input_gubun";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "input_id";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "pk_seq";
            this.multiLayoutItem26.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "direct_gubun";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "direct_code";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "direct_cont1";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "direct_cont2";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "direct_text";
            // 
            // layOCS2006
            // 
            this.layOCS2006.CallerID = '9';
            this.layOCS2006.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem13});
            this.layOCS2006.QuerySQL = resources.GetString("layOCS2006.QuerySQL");
            this.layOCS2006.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layOCS2006_QueryStarting);
            this.layOCS2006.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layOCS2006_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "fkinp1001";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "order_date";
            this.multiLayoutItem3.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "input_gubun";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "direct_gubun";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "direct_code";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "pk_seq";
            this.multiLayoutItem7.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "hangmog_code";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "suryang";
            this.multiLayoutItem9.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "insulin_from";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "insulin_to";
            this.multiLayoutItem11.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "time_gubun";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "seq";
            this.multiLayoutItem13.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "bunho";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "fkinp1001";
            this.multiLayoutItem30.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "order_date";
            this.multiLayoutItem31.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "input_gubun";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "direct_gubun";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "direct_code";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "pk_seq";
            this.multiLayoutItem35.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "direct_detail";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "str_val1";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "str_val2";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "str_val3";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "str_val4";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "str_val5";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "num_val1";
            this.multiLayoutItem42.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "num_val2";
            this.multiLayoutItem43.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "num_val3";
            this.multiLayoutItem44.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "num_va4";
            this.multiLayoutItem45.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "num_val5";
            this.multiLayoutItem46.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "seq";
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlActingInfo);
            this.pnlBody.Controls.Add(this.pnlDirectText);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 32);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(891, 248);
            this.pnlBody.TabIndex = 58;
            // 
            // frmInsulinActing
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(891, 338);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlAct_date);
            this.Controls.Add(this.xPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInsulinActing";
            this.ShowInTaskbar = true;
            this.Load += new System.EventHandler(this.frmInsulinActing_Load);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.pnlAct_date, 0);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2015)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2016)).EndInit();
            this.pnlActingInfo.ResumeLayout(false);
            this.pnlAct_date.ResumeLayout(false);
            this.pnlDirectText.ResumeLayout(false);
            this.pnlDirectText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS2005)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS2006)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region [Form]
        
		private void frmInsulinActing_Load(object sender, System.EventArgs e)
		{
            if (TypeCheck.IsNull(mBunho)) this.DialogResult = DialogResult.Cancel;
            if (!TypeCheck.IsInt(mFkinp1001)) this.DialogResult = DialogResult.Cancel;
            if (!TypeCheck.IsDateTime(mOrder_date)) this.DialogResult = DialogResult.Cancel;
            if (!TypeCheck.IsInt(mOcs2005_seq)) this.DialogResult = DialogResult.Cancel;
            if (TypeCheck.IsNull(mDirect_gubun)) this.DialogResult = DialogResult.Cancel;
            if (TypeCheck.IsNull(mDirect_code)) this.DialogResult = DialogResult.Cancel;
            if (TypeCheck.IsNull(mUser_id)) this.DialogResult = DialogResult.Cancel;

            string cmd = @"SELECT A.CODE_NAME
                             FROM OCS0132 A
                            WHERE A.HOSP_CODE = :f_hosp_code
                              AND A.CODE_TYPE = 'AUTO_JISI_PROCESS'
                              AND A.CODE      = 'INSULIN_YN'";

            string cmd_bs = @"SELECT A.CODE_NAME
                             FROM OCS0132 A
                            WHERE A.HOSP_CODE = :f_hosp_code
                              AND A.CODE_TYPE = 'AUTO_JISI_PROCESS'
                              AND A.CODE      = 'BS_CHECK_YN'";

            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_hosp_code", EnvironInfo.HospCode);

            // インスリンオーダ
            object obj = Service.ExecuteScalar(cmd, bind);
            if (obj != null && obj.ToString() == "Y")
                this.cbxCreateOCS2003_YN.Checked = true;
            else
                this.cbxCreateOCS2003_YN.Checked = false;
            this.cbxCreateOCS2003_YN.Protect = true;

            // グルコースオーダ
            obj = Service.ExecuteScalar(cmd_bs, bind);
            if (obj != null && obj.ToString() == "Y")
                this.cbxCreateOCS2003BS_YN.Checked = true;
            else
                this.cbxCreateOCS2003BS_YN.Checked = false;
            this.cbxCreateOCS2003BS_YN.Protect = true;

			//Control setting			
			SetControl(this.pnlAct_date  );
			SetControl(this.pnlActingInfo);
			SetControl(this.pnlDirectText);

			//Combo생성
            //CreateCombo();

			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{
            this.dpbAct_date.SetDataValue(mOrder_date);
			this.dpbAct_id_name.SetDataValue(mUser_name);
			
			//시행여부
            if (!grdOCS2015.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

            if (grdOCS2015.RowCount > 0)
            {
                dpbAct_date.SetDataValue(grdOCS2015.GetItemString(0, "act_date"));
                //dpbAct_id_name.SetDataValue(grdOCS2015.GetItemString(0, "act_id_name"));
            }
            

            //지시사항
            //layOCS2005.SetBindVarValue("f_bunho"      , mBunho      );
            //layOCS2005.SetBindVarValue("f_fkinp1001"  , mFkinp1001  );
            //layOCS2005.SetBindVarValue("f_order_date" , mOrder_date );
            //layOCS2005.SetBindVarValue("f_input_gubun", mInput_gubun);
            //layOCS2005.SetBindVarValue("f_pk_seq"     , mOcs2005_seq);

            if (!layOCS2005.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

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

		#region [Button List Event]
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{

                case FunctionType.Delete:
                    e.IsBaseCall = true;
                    //grdOCS2016.DeleteRow(grdOCS2016.RowCount - 1);
                    break;

                case FunctionType.Insert:
                    e.IsBaseCall = false;

                    int rownum = -1;

                    if (grdOCS2015.RowCount < 1)
                    {
                        grdOCS2015.InsertRow(-1);

                        grdOCS2015.SetItemValue(0, "pkocs2015", GetPkOCS2015());
                        grdOCS2015.SetItemValue(0, "bunho", mBunho);
                        grdOCS2015.SetItemValue(0, "fkinp1001", mFkinp1001);
                        grdOCS2015.SetItemValue(0, "order_date", mSource_order_date);
                        grdOCS2015.SetItemValue(0, "input_gubun", mInput_gubun);
                        grdOCS2015.SetItemValue(0, "pk_seq", mOcs2005_seq);
                        grdOCS2015.SetItemValue(0, "act_date", mOrder_date);
                        grdOCS2015.SetItemValue(0, "act_id", mUser_id);
                        grdOCS2015.SetItemValue(0, "act_id_name", mUser_name);
                        grdOCS2015.SetItemValue(0, "input_id", mUser_id);
                        grdOCS2015.SetItemValue(0, "input_gwa", mInput_gwa);
                        grdOCS2015.SetItemValue(0, "input_doctor", mInput_doctor);
                        grdOCS2015.SetItemValue(0, "fkocs2005", mPkOCS2005);

                    }

                    rownum = grdOCS2016.InsertRow(-1);

                    if (mDirect_code == "2030")
                    {
                        //스케일표인 경우 해당 hangmog_code setting
                        grdOCS2016.SetItemValue(rownum, "hangmog_code", layOCS2006.GetItemString(0, "hangmog_code"));
                    }
                    else
                    {
                        for (int i = 0; i < layOCS2006.RowCount; i++)
                        {
                            grdOCS2016.SetItemValue(i, "hangmog_code", layOCS2006.GetItemString(i, "hangmog_code"));

                            if(grdOCS2016.GetItemString(i, "suryang") == "")
                                grdOCS2016.SetItemValue(i, "suryang", this.layOCS2006.GetItemString(i, "suryang"));
                        }
                    }


                    string cmd = @" SELECT DISTINCT C.ORD_DANUI ORD_DANUI, D.CODE_NAME ORD_DANUI_NAME
                                      FROM OCS2015 A
                                          ,OCS2006 B
                                          ,NUR0115 C
                                          ,OCS0132 D
                                     WHERE A.HOSP_CODE  = :f_hosp_code
                                       AND A.BUNHO      = :f_bunho
                                       AND A.ORDER_DATE >= :f_order_date
                                       --   
                                       AND B.HOSP_CODE  = A.HOSP_CODE
                                       AND B.BUNHO      = A.BUNHO
                                       AND B.ORDER_DATE = A.ORDER_DATE
                                       AND B.PK_SEQ     = A.PK_SEQ
                                       --
                                       AND C.HOSP_CODE    = B.HOSP_CODE
                                       AND C.NUR_GR_CODE  = B.DIRECT_GUBUN
                                       AND C.NUR_MD_CODE  = B.DIRECT_CODE
                                       AND C.HANGMOG_CODE = B.HANGMOG_CODE
                                       AND (C.NUR_MD_CODE  = '2030' OR C.NUR_MD_CODE  = '2033') -- 2030 : インスリンスケール、2033：インスリン
                                       --
                                       AND D.HOSP_CODE = C.HOSP_CODE
                                       AND D.CODE_TYPE = 'ORD_DANUI'
                                       AND D.CODE      = C.ORD_DANUI";

                    BindVarCollection bind = new BindVarCollection();
                    bind.Add("f_hosp_code", EnvironInfo.HospCode);
                    bind.Add("f_bunho", grdOCS2015.GetItemString(0, "bunho"));
                    bind.Add("f_order_date", grdOCS2015.GetItemString(0, "order_date"));

                    DataTable dt = Service.ExecuteDataTable(cmd, bind);

                    if (dt.Rows.Count > 0)
                    {
                        grdOCS2016.SetItemValue(rownum, "ord_danui", dt.Rows[0]["ord_danui"].ToString());
                        grdOCS2016.SetItemValue(rownum, "ord_danui_name", dt.Rows[0]["ord_danui_name"].ToString());
                    }
                    else
                    {
                        grdOCS2016.SetItemValue(rownum, "ord_danui", "028");
                        grdOCS2016.SetItemValue(rownum, "ord_danui_name", "単位");
                    }

                    grdOCS2016.SetItemValue(rownum, "fkocs2015", grdOCS2015.GetItemString(0, "pkocs2015"));
                    grdOCS2016.SetItemValue(rownum, "seq", (rownum + 1).ToString());
                    grdOCS2016.SetItemValue(rownum, "time_gubun", rownum);

                    if (grdOCS2016.GetItemString(rownum, "ymd") == "")
                        grdOCS2016.SetItemValue(rownum, "ymd", mOrder_date.Replace("/", "").Replace("-", ""));

                    grdOCS2016.SetFocusToItem(rownum, "blood_sugar");

                    break; 
				case FunctionType.Process:
					e.IsBaseCall = false;
                    

                    if (grdOCS2016.RowCount == 0)
                    {
                        grdOCS2015.DeleteRow(-1);
                    }

					this.AcceptData();

                    if (!ChkData())
                        return;

                    try
                    {
                        Service.BeginTransaction();

                        if (grdOCS2015.SaveLayout())
                        {
                            if (grdOCS2016.SaveLayout())
                            {
                                
                            }
                            else
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
                        mbxMsg = "保存に失敗しました。";
                        mbxMsg = mbxMsg + xe.Message;
                        mbxCap = "保存エラー";
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Error);
                        return;
                    }

                    Service.CommitTransaction();
                    mbxMsg = "保存が完了しました。";
                    SetMsg(mbxMsg);
                    mActing_yn = "Y";
                    this.DialogResult = DialogResult.OK;
                    /*
                    if (grdOCS2015.SaveLayout())
                    {
                        ArrayList inputList = new ArrayList();
                        ArrayList outputList = new ArrayList();

                        inputList.Add(grdOCS2015.GetItemString(0, "bunho"));
                        inputList.Add(grdOCS2015.GetItemString(0, "fkinp1001"));
                        inputList.Add(grdOCS2015.GetItemString(0, "order_date"));
                        inputList.Add(grdOCS2015.GetItemString(0, "input_gubun"));
                        inputList.Add(grdOCS2015.GetItemString(0, "pk_seq"));
                        inputList.Add(grdOCS2015.GetItemString(0, "act_date"));
                        inputList.Add(grdOCS2015.GetItemString(0, "act_id"));

                        if (Service.ExecuteProcedure("PR_OCS_DIRECT_ACT_ORDER", inputList, outputList))
                        {
                            if (!outputList[1].ToString().Equals("0"))
                            {
                                //throw new Exception(outputList[1].ToString() + "\n\r" + outputList[0].ToString());
                                XMessageBox.Show(outputList[1].ToString() + "\n\r" + outputList[0].ToString());
                            }
                        }
                        else
                        {
                            XMessageBox.Show(Service.ErrFullMsg);
                        }
                        mActing_yn = "Y";

                    }*/
                    break;

				case FunctionType.Close:
					this.DialogResult = DialogResult.Cancel;
					break;

				default:

					break;
			}
		}
		
	
		#endregion

        #region Validation Check

        private bool ChkData()
		{
			for(int i = 0; i < this.grdOCS2016.RowCount; i++)
			{
				if(this.grdOCS2016.GetRowState(i) == DataRowState.Unchanged ) continue;

                if (TypeCheck.IsNull(this.grdOCS2016.GetItemValue(i, "act_time").ToString()))
                {
                    XMessageBox.Show("実施時間が入力されていません。ご確認ください。", "確認");
                    this.grdOCS2016.SetFocusToItem(i, "act_time");
                    return false;
                }


                //if(TypeCheck.IsNull(this.grdOCS2015.GetItemValue(i, "start_time").ToString()))
                //{	
                //    mbxMsg = NetInfo.Language == LangMode.Jr ? "開始時間に誤りがあります。 ご確認ください。" : "시작시간이 정확하지않습니다. 확인바랍니다.";
                //    mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                //    XMessageBox.Show(mbxMsg, mbxCap);
                //    this.grdOCS2015.SetFocusToItem(i, "start_time");
                //    return false;
                //}

			}
			return true;
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
					for( int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
					{
						if(grdChk.GetRowState(rowIndex) == DataRowState.Added && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
						{
							celReturn.ColumnNumber = cell.Col;
							celReturn.RowNumber   = rowIndex;
							break;
						}
					}

					if(celReturn.RowNumber < 0) 
						continue;
					else
						break;
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

		#region [Control Set HashTable]
		/// <summary>
		/// 1.Hashtable에 각 DataControl를 Load시켜서 해당 Control의 제어를 용이하게 한다.
		/// </summary>
		private void SetControl(XPanel pnl)
		{
			string colName = "";

			foreach(object obj in pnl.Controls)
			{
				try
				{
                    if (obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
                    {
                        colName = ((XComboBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
                    {
                        colName = ((XTextBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
                    {
                        colName = ((XEditMask)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XCheckBox") >= 0)
                    {
                        colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDisplayBox") >= 0)
                    {
                        colName = ((XDisplayBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XFindBox") >= 0)
                    {
                        colName = ((XFindBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDatePicker") >= 0)
                    {
                        colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                    }
				}
				catch(Exception ex)
				{
					XMessageBox.Show(ex.Message);
				}
			}
		}
		#endregion

		#region [QueryEnd Event]

        private void grdOCS2015_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            if (grdOCS2015.RowCount < 1)
            {
                string pkOcs2015 = GetPkOCS2015();

                grdOCS2015.SetItemValue(0, "pkocs2015", pkOcs2015);
                grdOCS2015.SetItemValue(0, "bunho", mBunho);
                grdOCS2015.SetItemValue(0, "fkinp1001", mFkinp1001);
                grdOCS2015.SetItemValue(0, "order_date", mSource_order_date);
                grdOCS2015.SetItemValue(0, "input_gubun", mInput_gubun);
                grdOCS2015.SetItemValue(0, "pk_seq", mOcs2005_seq);
                grdOCS2015.SetItemValue(0, "act_date", mOrder_date);
                grdOCS2015.SetItemValue(0, "act_id", mUser_id);
                grdOCS2015.SetItemValue(0, "act_id_name", mUser_name);
                grdOCS2015.SetItemValue(0, "input_id", mUser_id);
                grdOCS2015.SetItemValue(0, "input_gwa", mInput_gwa);
                grdOCS2015.SetItemValue(0, "input_doctor", mInput_doctor);
            }

            if (grdOCS2015.RowCount > 0)
            {
                

                grdOCS2016.QueryLayout(false);
            }
            /* 201012 KHJ * / 
			ClearControl(this.pnlActingInfo);

			if(grdOCS2015.RowCount > 0)
			{
				this.LoadData(0);

				if( !TypeCheck.IsNull(grdOCS2015.GetItemString(0, "fkocs2003_act1")) )
					lblHangmog_1.ForeColor = new XColor(Color.Red);
				else
					lblHangmog_1.ForeColor = XColor.NormalForeColor;
				

				if(grdOCS2015.GetItemString(0, "ocs_flag_1") == "2" || grdOCS2015.GetItemString(0, "ocs_flag_1") == "3")
				{
					cboHangmog_code_1.Enabled = false;
					emkNum_val1.Enabled = false;
					emkNum_val5.Enabled = false;
				}
				else
				{
					cboHangmog_code_1.Enabled = true;
					emkNum_val1.Enabled = true;
					
					if(grdOCS2015.GetItemString(0, "ocs_flag_5") == "2" || grdOCS2015.GetItemString(0, "ocs_flag_5") == "3")
						emkNum_val5.Enabled = false;
					else
						emkNum_val5.Enabled = true;
				}

				if( !TypeCheck.IsNull(grdOCS2015.GetItemString(0, "fkocs2003_act2")) )
					lblHangmog_2.ForeColor = new XColor(Color.Red);
				else
					lblHangmog_2.ForeColor = XColor.NormalForeColor;

				if(grdOCS2015.GetItemString(0, "ocs_flag_2") == "2" || grdOCS2015.GetItemString(0, "ocs_flag_2") == "3")
				{
					cboHangmog_code_2.Enabled = false;
					emkNum_val2.Enabled = false;
					emkNum_val6.Enabled = false;
				}
				else
				{
					cboHangmog_code_2.Enabled = true;
					emkNum_val2.Enabled = true;
					
					if(grdOCS2015.GetItemString(0, "ocs_flag_6") == "2" || grdOCS2015.GetItemString(0, "ocs_flag_6") == "3")
						emkNum_val6.Enabled = false;
					else
						emkNum_val6.Enabled = true;
				}

				if( !TypeCheck.IsNull(grdOCS2015.GetItemString(0, "fkocs2003_act3")) )
					lblHangmog_3.ForeColor = new XColor(Color.Red);
				else
					lblHangmog_3.ForeColor = XColor.NormalForeColor;

				if(grdOCS2015.GetItemString(0, "ocs_flag_3") == "2" || grdOCS2015.GetItemString(0, "ocs_flag_3") == "3")
				{
					cboHangmog_code_3.Enabled = false;
					emkNum_val3.Enabled = false;
					emkNum_val7.Enabled = false;
				}
				else
				{
					cboHangmog_code_3.Enabled = true;
					emkNum_val3.Enabled = true;
					if(grdOCS2015.GetItemString(0, "ocs_flag_7") == "2" || grdOCS2015.GetItemString(0, "ocs_flag_7") == "3")
						emkNum_val7.Enabled = false;
					else
						emkNum_val7.Enabled = true;
				}

				if( !TypeCheck.IsNull(grdOCS2015.GetItemString(0, "fkocs2003_act4")) )
					lblHangmog_4.ForeColor = new XColor(Color.Red);
				else
					lblHangmog_4.ForeColor = XColor.NormalForeColor;

				if(grdOCS2015.GetItemString(0, "ocs_flag_4") == "2" || grdOCS2015.GetItemString(0, "ocs_flag_4") == "3")
				{
					cboHangmog_code_4.Enabled = false;
					emkNum_val4.Enabled = false;
					emkNum_val8.Enabled = false;
				}
				else
				{
					cboHangmog_code_4.Enabled = true;
					emkNum_val4.Enabled = true;
					if(grdOCS2015.GetItemString(0, "ocs_flag_8") == "2" || grdOCS2015.GetItemString(0, "ocs_flag_8") == "3")
						emkNum_val8.Enabled = false;
					else
						emkNum_val8.Enabled = true;
				}
			}
		/**/
		}

        private void layOCS2005_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            //지시세부사항
            if (!layOCS2006.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);            
		}
		#endregion

		#region [Scroll]
		/// <summary>
		/// Number인 경우 Scroll시 증가,감소처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void vsbNumber_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			VScrollBar vsb = sender as VScrollBar;
            
			string colName = vsb.Name.Substring(3).ToLower();
			
			double incrementValue = 1;
			double maxIncrement   = 999;
			double controlValue   = 0;
			
			switch (e.Type)
			{
				case System.Windows.Forms.ScrollEventType.LargeIncrement:
				case System.Windows.Forms.ScrollEventType.SmallIncrement:
					//감소
					controlValue = double.Parse(((IDataControl)htControl[colName]).DataValue.ToString() == "" ? "0" : ((IDataControl)htControl[colName]).DataValue.ToString());
					controlValue = controlValue - incrementValue;

					if(controlValue < 0 ) controlValue = 0;

					((IDataControl)htControl[colName]).DataValue = controlValue;

					break;
				case System.Windows.Forms.ScrollEventType.LargeDecrement:
				case System.Windows.Forms.ScrollEventType.SmallDecrement:

					//증가
					controlValue = double.Parse(((IDataControl)htControl[colName]).DataValue.ToString() == "" ? "0" : ((IDataControl)htControl[colName]).DataValue.ToString());
					controlValue = controlValue + incrementValue;

					if( controlValue >= maxIncrement) controlValue = 0;

					((IDataControl)htControl[colName]).DataValue = controlValue;
					
					break;
			}
		
		}

		
		#endregion

		#region [Fucntion]

		/// <summary>
		/// Control의 값들을 Reset한다.
		/// </summary>
		/// <param name="pnl"></param>
		private void ClearControl(XPanel pnl)
		{
			foreach(object obj in pnl.Controls)
			{
				try
				{
					if( obj.GetType().ToString().IndexOf("XComboBox" ) >= 0)
					{
						if(((XComboBox)obj).DataSource != null)
							((XComboBox)obj).SelectedIndex = 0;

					}
					else if( obj.GetType().ToString().IndexOf("XDisplayBox" ) >= 0)
						((XDisplayBox)obj).SetDataValue("");
					else if( obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
						((XTextBox)obj).SetDataValue("");
					else if( obj.GetType().Name.ToString().IndexOf("XEditMask" ) >= 0)
					{						
						if(((XEditMask)obj).EditMaskType == MaskType.Number || ((XEditMask)obj).EditMaskType == MaskType.Decimal)
							((XEditMask)obj).SetDataValue(0);
						else if(((XEditMask)obj).Mask == "##:##")
							((XEditMask)obj).SetDataValue("0000");

					}
					else if( obj.GetType().ToString().IndexOf("XCheckBox" ) >= 0)
						((XCheckBox)obj).Checked = false;
					else if( obj.GetType().ToString().IndexOf("XRadioButton" ) >= 0)
						((XRadioButton)obj).Checked = false;
					else if( obj.GetType().ToString().IndexOf("XDatePicker" ) >= 0)
						((XDatePicker)obj).SetDataValue("");
					else if( obj.GetType().ToString().IndexOf("XEditGrid" ) >= 0)
					{
						((XEditGrid)obj).Reset();
					}
					
				}
				catch(Exception ex)
				{
					XMessageBox.Show(ex.Message);
				}
			}			
		}
        
		/// <summary>
		/// grid의 Data를 Control에 반영한다.
		/// </summary>
		/// <param name="rowIndex"></param>
		private void LoadData(int rowIndex)
		{
			if(rowIndex == -1) return;

			foreach(XEditGridCell cell in grdOCS2015.CellInfos)
			{
				if(htControl.Contains(cell.CellName))
					((IDataControl)htControl[cell.CellName]).DataValue = grdOCS2015.GetItemValue(rowIndex, cell.CellName);
			}
		}

        /// <summary>
        /// Control의 Data를 Grid에 반영한다.
        /// </summary>
        /// <param name="rowIndex"></param>
        private void ApplyData(int rowIndex)
		{
			if(rowIndex == -1) return;

			grdOCS2015.SetItemValue(rowIndex, "act_id", mUser_id);

			foreach(object obj in htControl.Keys)
			{				
				if(grdOCS2015.CellInfos.Contains(obj.ToString()))
				{
					if(( ((XGridCell)grdOCS2015.CellInfos[obj.ToString()]).CellType == IHIS.Framework.XCellDataType.Number ||
						((XGridCell)grdOCS2015.CellInfos[obj.ToString()]).CellType == IHIS.Framework.XCellDataType.Decimal ) &&
						TypeCheck.IsNull(((IDataControl)htControl[obj.ToString()]).DataValue.ToString()) )
						grdOCS2015.SetItemValue(rowIndex, obj.ToString(), 0);
					else
						grdOCS2015.SetItemValue(rowIndex, obj.ToString(), ((IDataControl)htControl[obj.ToString()]).DataValue);
				}
			}
		}

        private string GetPkOCS2015()
        {
            string cmdText = @"SELECT OCS2015_SEQ.NEXTVAL FROM DUAL";
            string retVal = Service.ExecuteScalar(cmdText).ToString();

            return retVal;
        }

        private int Get2016Seq(string fkocs2015)
        {
            string cmdText = @"SELECT NVL(MAX(SEQ), 0) AS SEQ
                                 FROM OCS2016
                                WHERE HOSP_CODE = '" + mHospCode + @"'
                                  AND FKOCS2015 = '" + fkocs2015 + "'";

            int retVal = Convert.ToInt32(Service.ExecuteScalar(cmdText));

            return retVal;
        }

            
        private string LoadSeq()
        {
            int maxSeq = -1;
            return maxSeq.ToString();
        }

        private int SetDanui(int calValue)
		{
			int returnValue = 0;
			
			int startValue  = 0;
			int endValue    = 0;
			int setValue    = 0;

			foreach(DataRow row in layOCS2006.LayoutTable.Rows)
			{
                startValue = 0; //num_val2
				if(!TypeCheck.IsInt(row["insulin_from"].ToString()))
					continue;
				else
                    startValue = int.Parse(row["insulin_from"].ToString());

                endValue = 0;   //num_val3
				if(!TypeCheck.IsInt(row["insulin_to"].ToString()))
					endValue = 999;
				else
                    endValue = int.Parse(row["insulin_to"].ToString());

                setValue = 0;   //num_val1
				if(!TypeCheck.IsInt(row["suryang"].ToString()))
					continue;
				else
                    setValue = int.Parse(row["suryang"].ToString());

				if( startValue <= calValue && endValue >= calValue )
				{
					returnValue = setValue;
					break;
				}
			}

			return returnValue;

		}
		#endregion

		#region [Control Event]

		private void emkCal_val_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
            //XEditMask control = sender as XEditMask;
            
            //string colName = control.Name.Substring(3).ToLower();
			
            //int setValue    = 0;
            //if(TypeCheck.IsInt(e.DataValue))
            //    setValue = SetDanui(int.Parse(e.DataValue));

            //if(setValue == 0) return;

            //switch (colName)
            //{
            //    case "num_val5":
            //        this.emkNum_val1.SetDataValue(setValue);
            //        break;

            //    case "num_val6":
            //        this.emkNum_val2.SetDataValue(setValue);
            //        break;

            //    case "num_val7":
            //        this.emkNum_val3.SetDataValue(setValue);
            //        break;

            //    case "num_val8":
            //        this.emkNum_val4.SetDataValue(setValue);
            //        break;

            //    case "num_val10":
            //        this.emkNum_val9.SetDataValue(setValue);
            //        break;

            //    case "num_val12":
            //        this.emkNum_val11.SetDataValue(setValue);
            //        break;
            //}
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

        private Hashtable htTable = new Hashtable();

        #region XSavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private frmInsulinActing parent = null;
            bool result;

            public XSavePerformer(frmInsulinActing parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
                item.BindVarList.Add("q_user_id", UserInfo.UserID);

                // 프로시져 입력 ArrayList
                ArrayList inputList = new ArrayList();
                ArrayList outputList = new ArrayList();
                // 프로시져명 변수
                string spName = "";

                switch (callerID)
                {
                    #region  grdOCS2015
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO OCS2015
                                             ( SYS_DATE       , SYS_ID         , UPD_DATE       , PKOCS2015      , HOSP_CODE    ,
                                               BUNHO          , FKINP1001      , ORDER_DATE     , INPUT_GUBUN    , INPUT_GWA    , INPUT_DOCTOR  ,
                                               INPUT_ID       , PK_SEQ         , DRT_DATE       , ACT_DATE       ,
                                               ACT_ID         , ACT_RESULT_TEXT, BLOOD_SUGAR    , FKOCS2005
                                             )
                                         VALUES
                                             ( SYSDATE        ,:q_user_id      , SYSDATE        , :f_pkocs2015   , :f_hosp_code ,
                                               :f_bunho       ,:f_fkinp1001    , :f_order_date  , :f_input_gubun , :f_input_gwa , :f_input_doctor ,
                                               :f_input_id    ,:f_pk_seq       , :f_order_date  , :f_act_date    ,
                                               DECODE(:f_act_date, NULL, NULL, :f_act_id) ,:f_act_result_text, :f_blood_sugar   , :f_fkocs2005
                                             )";

                                result = Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                break;

                            #region DataRowState.Modified
                            case DataRowState.Modified:
//                                spName = "PR_OCS_UPD_DIRECT_ACT_ORDER";  // 오더 수정 프로시져

//                                /* 1 */
//                                inputList.Clear();
//                                outputList.Clear();
//                                inputList.Add("1");
//                                inputList.Add(item.BindVarList["f_bunho"].VarValue);
//                                inputList.Add(item.BindVarList["f_fkinp1001"].VarValue);
//                                inputList.Add(item.BindVarList["f_order_date"].VarValue);
//                                inputList.Add(item.BindVarList["f_input_gubun"].VarValue);
//                                inputList.Add(item.BindVarList["f_ocs2005_seq"].VarValue);
//                                inputList.Add(item.BindVarList["f_hangmog_code"].VarValue);
//                                inputList.Add(item.BindVarList["f_suryang"].VarValue);
//                                inputList.Add(item.BindVarList["f_act_id"].VarValue);

//                                if (Service.ExecuteProcedure(spName, inputList, outputList))
//                                {
//                                    if (!outputList[1].ToString().Equals("0"))
//                                    {
//                                        XMessageBox.Show(outputList[0].ToString());
//                                        return false;
//                                    }
//                                }
//                                else
//                                {
//                                    return false;
//                                }
                                break;
                            #endregion

                            case DataRowState.Deleted:

                                //spName = "PR_OCS_DEL_DIRECT_ACT_ORDER";  // 오더삭제 프로시져

                                //inputList.Clear();
                                //outputList.Clear();
                                //inputList.Add(item.BindVarList["f_bunho"].VarValue);
                                //inputList.Add(item.BindVarList["f_fkinp1001"].VarValue);
                                //inputList.Add(item.BindVarList["f_order_date"].VarValue);
                                //inputList.Add(item.BindVarList["f_input_gubun"].VarValue);
                                //inputList.Add(item.BindVarList["f_ocs2005_seq"].VarValue);
                                //inputList.Add("0");
                                //inputList.Add(item.BindVarList["f_act_id"].VarValue);

                                //if (Service.ExecuteProcedure(spName, inputList, outputList))
                                //{
                                //    if (!outputList[1].ToString().Equals("0"))
                                //    {
                                //        XMessageBox.Show(outputList[0].ToString());
                                //        return false;
                                //    }
                                //}

                                cmdText = @"DELETE OCS2015
                                             WHERE HOSP_CODE     = :f_hosp_code
                                               AND BUNHO         = :f_bunho
                                               AND FKINP1001     = :f_fkinp1001
                                               AND ORDER_DATE    = :f_order_date
                                               AND INPUT_GUBUN   = :f_input_gubun
                                               AND PK_SEQ        = :f_pk_seq";

                                result = Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                break;
                        }
                        break;
                    #endregion

                    case '2':
                        item.BindVarList.Add("f_fkinp1001", parent.grdOCS2015.GetItemString(parent.grdOCS2015.CurrentRowNumber, "fkinp1001"));
                        item.BindVarList.Add("f_bunho",     parent.grdOCS2015.GetItemString(parent.grdOCS2015.CurrentRowNumber, "bunho"));
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                //item.BindVarList.Add("f_act_time",  parent.grdOCS2015.GetItemString(parent.grdOCS2015.CurrentRowNumber, "act_time"));

//                                cmdText = @"INSERT INTO OCS2016
//        (   SYS_DATE,       SYS_ID,         UPD_DATE,       UPD_ID,         HOSP_CODE,
//            PKOCS2016,      FKOCS2015,      SEQ,
//            HANGMOG_CODE,   SURYANG,        BLOOD_SUGAR,    TIME_GUBUN          )
//VALUES
//        (   SYSDATE,        :q_user_id,     SYSDATE,        :f_act_id,      :f_hosp_code,
//     OCS2016_SEQ.NEXTVAL,   :f_fkocs2015,   :f_seq,
//            :f_hangmog_code, :f_suryang,    :f_blood_sugar, :f_time_gubun       )";
                                string cmd_pk = "SELECT OCS2016_SEQ.NEXTVAL FROM SYS.DUAL";
                                object obj_pk = Service.ExecuteScalar(cmd_pk);

                                if(obj_pk != null)
                                    item.BindVarList.Add("f_pkocs2016", obj_pk.ToString());

                                if (item.BindVarList.Contains("q_user_id"))
                                    item.BindVarList["q_user_id"].VarValue = parent.mUser_id;

                                cmdText = @"BEGIN
                                            INSERT INTO OCS2016
                                                    (   SYS_DATE,       SYS_ID,         UPD_DATE,       UPD_ID,         HOSP_CODE,
                                                        PKOCS2016,      FKOCS2015,      SEQ,
                                                        HANGMOG_CODE,   SURYANG,        BLOOD_SUGAR,    TIME_GUBUN,     ORD_DANUI,
                                                        MUHYO,          BROUGHT_DRG_YN)
                                            VALUES
                                                    (   SYSDATE,         :q_user_id,     to_date(:f_ymd || :f_act_time, 'YYYYMMDDHH24MI'), :f_act_id, :f_hosp_code,
                                                        :f_pkocs2016,    :f_fkocs2015,   :f_seq,
                                                        :f_hangmog_code, :f_suryang,     :f_blood_sugar, :f_time_gubun,  :f_ord_danui,
                                                        :f_muhyo,        :f_brought_drg_yn);
                                                        
                                            IF :f_blood_sugar IS NOT NULL THEN
                                                INSERT INTO NUR1020(SYS_DATE     , SYS_ID      , UPD_DATE     , UPD_ID,
                                                                    HOSP_CODE    , BUNHO       , FKINP1001    , YMD     ,
                                                                    TIME_GUBUN   , PR_GUBUN    , PR_VALUE     , FKOCS2016)
                                                VALUES             (SYSDATE      , :q_user_id  , SYSDATE      , :q_user_id  ,
                                                                    :f_hosp_code , :f_bunho    , :f_fkinp1001 , :f_ymd ,
                                                                    :f_act_time  , 'BS'        , :f_blood_sugar, :f_pkocs2016);
                                            END IF;

                                            EXCEPTION WHEN DUP_VAL_ON_INDEX THEN

                                                UPDATE NUR1020
                                                   SET UPD_ID     = :q_user_id
                                                     , UPD_DATE   = SYSDATE
                                                     , PR_VALUE   = :f_blood_sugar
                                                 WHERE HOSP_CODE  = :f_hosp_code 
                                                   AND BUNHO      = :f_bunho
                                                   AND FKINP1001  = :f_fkinp1001
                                                   AND YMD        = :f_ymd
                                                   AND TIME_GUBUN = :f_act_time
                                                   AND PR_GUBUN   = 'BS';

                                            END;";

                                result = Service.ExecuteNonQuery(cmdText, item.BindVarList);
                                
                                // CREATE OCS2003 INSULIN INJECT
                                if (parent.cbxCreateOCS2003_YN.Checked == true && int.Parse(TypeCheck.NVL(item.BindVarList["f_suryang"].VarValue, "0").ToString()) > 0)
                                {
                                    inputList = new ArrayList();
                                    outputList = new ArrayList();

                                    inputList.Add(parent.grdOCS2015.GetItemString(0, "bunho"));
                                    inputList.Add(parent.grdOCS2015.GetItemString(0, "fkinp1001"));
                                    inputList.Add(parent.grdOCS2015.GetItemString(0, "order_date"));
                                    inputList.Add(parent.grdOCS2015.GetItemString(0, "input_gubun"));
                                    inputList.Add(parent.grdOCS2015.GetItemString(0, "pkocs2015"));
                                    inputList.Add(parent.grdOCS2015.GetItemString(0, "act_date"));
                                    inputList.Add(parent.grdOCS2015.GetItemString(0, "act_id"));

                                    if (Service.ExecuteProcedure("PR_OCS_DIRECT_ACT_ORDER", inputList, outputList))
                                    {
                                        if (!outputList[1].ToString().Equals("0"))
                                        {
                                            throw new Exception(outputList[1].ToString() + "\n\r" + outputList[0].ToString());
                                        }
                                        else
                                        {

                                        }
                                    }
                                }

                                // CREATE OCS2003 BSCHECK ORDER
                                //if (parent.cbxCreateOCS2003BS_YN.Checked == true && int.Parse(TypeCheck.NVL(item.BindVarList["f_blood_sugar"].VarValue, "0").ToString()) > 0)
                                //{
                                //    inputList = new ArrayList();
                                //    outputList = new ArrayList();

                                //    inputList.Add(parent.grdOCS2015.GetItemString(0, "bunho"));
                                //    inputList.Add(parent.grdOCS2015.GetItemString(0, "fkinp1001"));
                                //    inputList.Add(parent.grdOCS2015.GetItemString(0, "input_gubun"));
                                //    inputList.Add(parent.grdOCS2015.GetItemString(0, "act_date"));
                                //    inputList.Add(parent.grdOCS2015.GetItemString(0, "act_id"));
                                    
                                //    inputList.Add("I");
                                //    inputList.Add("OCS");
                                //    inputList.Add(obj_pk.ToString());
                                //    inputList.Add("");
                                //    //inputList.Add(parent.grdOCS2015.GetItemString(0, "pkocs2015"));

                                //    //inputList.Add(parent.grdOCS2015.GetItemString(0, "order_date"));


                                //    //inputList.Add(parent.grdOCS2015.GetItemString(0, "pkocs2015"));


                                //    if (Service.ExecuteProcedure("PR_OCS_DIRECT_ACT_CPL_ORDER", inputList, outputList))
                                //    {
                                //        if (!outputList[1].ToString().Equals("0"))
                                //        {
                                //            throw new Exception(outputList[1].ToString() + "\n\r" + outputList[0].ToString());
                                //        }
                                //    }
                                //}
                                break;

                            case DataRowState.Unchanged:
                            case DataRowState.Modified:
//                                cmdText = @"UPDATE OCS2016
                                            //   SET SURYANG     = :f_suryang     ,
                                            //       BLOOD_SUGAR = :f_blood_sugar
                                            // WHERE PKOCS2016   = :f_pkocs2016
                                            //   AND HOSP_CODE   = :f_hosp_code";

                                cmdText = @"BEGIN
                                            UPDATE OCS2016
                                               SET SURYANG     = :f_suryang
                                                 , BLOOD_SUGAR = :f_blood_sugar
                                                 , UPD_DATE    = TO_DATE(:f_ymd || :f_act_time, 'YYYYMMDDHH24MI')
                                                 , SEQ         = :f_seq
                                                 , TIME_GUBUN  = :f_time_gubun
                                             WHERE HOSP_CODE   = :f_hosp_code
                                               AND PKOCS2016   = :f_pkocs2016;

                                            UPDATE NUR1020
                                               SET UPD_ID     = :q_user_id
                                                 , UPD_DATE   = SYSDATE
                                                 , PR_VALUE   = :f_blood_sugar
                                                 , TIME_GUBUN = :f_act_time
                                             WHERE HOSP_CODE  = :f_hosp_code 
                                               AND BUNHO      = :f_bunho
                                               AND FKINP1001  = :f_fkinp1001
                                               AND YMD        = :f_query_ymd
                                               AND TIME_GUBUN = :f_query_time
                                               AND PR_GUBUN   = 'BS';
                                            END;";

                                result = Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                break;

                            case DataRowState.Deleted:

                                string cmdText_delete = "";

                                // OCS2003 DELETE 처리
                                cmdText_delete = @"DELETE OCS2003 A
                                                    WHERE A.HOSP_CODE = :f_hosp_code
                                                      AND A.PKOCS2003 IN (SELECT C.FKOCS2003 
                                                                            FROM OCS2016 C
                                                                           WHERE C.HOSP_CODE = :f_hosp_code
                                                                             AND C.PKOCS2016 = :f_pkocs2016
                                                                          )
                                        ";
                                if (!Service.ExecuteNonQuery(cmdText_delete, item.BindVarList)) throw new Exception(Service.ErrFullMsg);

                               
                                //for (int i = 0; i < parent.grdOCS2016.DeletedRowCount; i++)
                                //{
                                //    inputList = new ArrayList();
                                //    outputList = new ArrayList();

                                //    inputList.Add(parent.grdOCS2015.GetItemString(0, "bunho"));
                                //    inputList.Add(parent.grdOCS2015.GetItemString(0, "fkinp1001"));
                                //    inputList.Add(parent.grdOCS2015.GetItemString(0, "input_gubun"));
                                //    inputList.Add(parent.grdOCS2015.GetItemString(0, "act_date"));
                                //    inputList.Add(parent.grdOCS2015.GetItemString(0, "act_id"));
                                    
                                //    inputList.Add("D");
                                //    inputList.Add("OCS");
                                //    inputList.Add(parent.grdOCS2016.DeletedRowTable.Rows[i]["pkocs2016"].ToString());
                                //    inputList.Add("");
                                //    //inputList.Add(parent.grdOCS2015.GetItemString(0, "pkocs2015"));
                                //    //inputList.Add(parent.grdOCS2015.GetItemString(0, "order_date"));


                                //    //inputList.Add(parent.grdOCS2015.GetItemString(0, "pkocs2015"));


                                //    if (Service.ExecuteProcedure("PR_OCS_DIRECT_ACT_CPL_ORDER", inputList, outputList))
                                //    {
                                //        if (!outputList[1].ToString().Equals("0"))
                                //        {
                                //            throw new Exception(outputList[1].ToString() + "\n\r" + outputList[0].ToString());
                                //        }
                                //    }
                                //}



                                cmdText_delete = @"BEGIN

                                                  DELETE NUR1020 A
                                                   WHERE A.HOSP_CODE  = :f_hosp_code 
                                                     AND A.BUNHO      = :f_bunho
                                                     AND A.FKOCS2016  = :f_pkocs2016
                                                     AND A.PR_GUBUN   = 'BS';

                                                   DELETE OCS2016 A
                                                    WHERE A.HOSP_CODE = :f_hosp_code
                                                      AND A.PKOCS2016 = :f_pkocs2016
                                                      ;

                                                  
                                                   END;
                                            ";

                                if (!Service.ExecuteNonQuery(cmdText_delete, item.BindVarList)) throw new Exception(Service.ErrFullMsg);

                                if (parent.grdOCS2016.RowCount == 0)
                                {
                                    cmdText_delete = @"DELETE FROM OCS2015
                                                        WHERE HOSP_CODE = :f_hosp_code   --:f_pkocs2015
                                                          AND PKOCS2015 = '" + parent.grdOCS2015.GetItemString(parent.grdOCS2015.CurrentRowNumber, "pkocs2015") + "'";
                                    if (!Service.ExecuteNonQuery(cmdText_delete, item.BindVarList)) throw new Exception(Service.ErrFullMsg);
                                }
                                result = true;

                                break;
                        }
                        break;
                }

                //return Service.ExecuteNonQuery(cmdText, item.BindVarList);
                return result;
            }
        }
        #endregion

        private void grdOCS2015_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS2015.SetBindVarValue("f_bunho", mBunho);
            grdOCS2015.SetBindVarValue("f_fkinp1001", mFkinp1001);
            grdOCS2015.SetBindVarValue("f_order_date", mSource_order_date);
            grdOCS2015.SetBindVarValue("f_act_date", mOrder_date);
            grdOCS2015.SetBindVarValue("f_input_gubun", mInput_gubun);
            grdOCS2015.SetBindVarValue("f_pk_seq", mOcs2005_seq);
            grdOCS2015.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void layOCS2005_QueryStarting(object sender, CancelEventArgs e)
        {
            layOCS2005.SetBindVarValue("f_hosp_code", mHospCode);
            layOCS2005.SetBindVarValue("f_pkocs2005", mPkOCS2005);
        }

        private void layOCS2006_QueryStarting(object sender, CancelEventArgs e)
        {
            layOCS2006.SetBindVarValue("f_bunho", mBunho);
            layOCS2006.SetBindVarValue("f_fkinp1001", mFkinp1001);
            layOCS2006.SetBindVarValue("f_order_date", mOrder_date);
            layOCS2006.SetBindVarValue("f_input_gubun", mInput_gubun);
            layOCS2006.SetBindVarValue("f_direct_gubun", mDirect_gubun);
            layOCS2006.SetBindVarValue("f_direct_code", mDirect_code);
            layOCS2006.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void layOCS2006_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (layOCS2006.RowCount > 0)
            {
                txtDirect_text.SetDataValue(layOCS2005.GetItemString(0, "direct_text"));                
            }
        }

        private void grdOCS2016_GridDDLBSetting(object sender, GridDDLBSettingEventArgs e)
        {
            grdOCS2016.SetComboBindVarValue("hangmog_code", "f_nur_gr_code", mDirect_gubun);
            grdOCS2016.SetComboBindVarValue("hangmog_code", "f_nur_md_code", mDirect_code);
       }

        private void grdOCS2016_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS2016.SetBindVarValue("f_fkocs2015", grdOCS2015.GetItemString(0, "pkocs2015"));
            grdOCS2016.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdOCS2016_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            DataRow[] dr;
            if (e.ColName == "blood_sugar")
            {
                dr = layOCS2006.LayoutTable.Select("insulin_from <= " + grdOCS2016.GetItemString(grdOCS2016.CurrentRowNumber, e.ColName) +
                                             " and insulin_to >= " + grdOCS2016.GetItemString(grdOCS2016.CurrentRowNumber, e.ColName));

                if (dr.Length > 0)
                {
                    grdOCS2016.SetItemValue(grdOCS2016.CurrentRowNumber, "suryang", dr[0]["suryang"].ToString());
                }
                
            }
        }

        private void grdOCS2016_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            switch (e.ColName)
            {
                case "ord_danui_name":  // 오더단위

                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker(e.ColName, grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;
            }
        }

        private void grdOCS2016_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {
            object[] obj = e.ReturnValues;
            this.grdOCS2016.SetItemValue(e.RowNumber, "ord_danui", obj[1].ToString());
        }

        private void grdOCS2016_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            //시행된 시행사항은 수정을 막는다.
            if (this.grdOCS2016.GetRowState(e.RowNumber) == DataRowState.Unchanged)
            {
                if (!TypeCheck.IsNull(e.DataRow["act_time"].ToString()))
                    e.Protect = true;
                else
                    e.Protect = false;
            }
        }
    }
}

