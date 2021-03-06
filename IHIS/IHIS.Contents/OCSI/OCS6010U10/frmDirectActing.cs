using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

using IHIS.Framework;

namespace IHIS.OCSI
{
	public class frmDirectActing : IHIS.Framework.XForm
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
        private string mSource_order_date = "";

        private string mPkOcs        = "";

        // Hospital Code
        private string mHospCode     = EnvironInfo.HospCode;
		#endregion

		private IHIS.Framework.XFlatLabel xFlatLabel1;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XGrid grdNUR0113;
		private IHIS.Framework.XTextBox txtAct_result_text;
		private IHIS.Framework.XFlatLabel xFlatLabel5;
		private IHIS.Framework.XDatePicker dtpAct_date;
		private IHIS.Framework.XDisplayBox dpbAct_id_name;
		private IHIS.Framework.XDisplayBox dpbAct_time;
        private IHIS.Framework.XEditGrid grdOCS2015;
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
		private System.ComponentModel.IContainer components = null;

		public frmDirectActing()
        {
            /* SavePerformer 생성 */
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            this.grdOCS2015.SavePerformer = new XSavePerformer(this);
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdOCS2015);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDirectActing));
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdNUR0113 = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.grdOCS2015 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.dtpAct_date = new IHIS.Framework.XDatePicker();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.dpbAct_id_name = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.txtAct_result_text = new IHIS.Framework.XTextBox();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.dpbAct_time = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xFlatLabel5 = new IHIS.Framework.XFlatLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0113)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2015)).BeginInit();
            this.SuspendLayout();
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xFlatLabel1.Location = new System.Drawing.Point(214, 8);
            this.xFlatLabel1.Name = "xFlatLabel1";
            this.xFlatLabel1.Size = new System.Drawing.Size(58, 20);
            this.xFlatLabel1.TabIndex = 6;
            this.xFlatLabel1.Text = "施行日";
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.Location = new System.Drawing.Point(320, 2);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Process;
            this.xButtonList1.Size = new System.Drawing.Size(244, 34);
            this.xButtonList1.TabIndex = 9;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdNUR0113
            // 
            this.grdNUR0113.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2});
            this.grdNUR0113.ColHeaderVisible = false;
            this.grdNUR0113.ColPerLine = 1;
            this.grdNUR0113.Cols = 1;
            this.grdNUR0113.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdNUR0113.FixedRows = 1;
            this.grdNUR0113.HeaderHeights.Add(0);
            this.grdNUR0113.Location = new System.Drawing.Point(0, 0);
            this.grdNUR0113.Name = "grdNUR0113";
            this.grdNUR0113.QuerySQL = resources.GetString("grdNUR0113.QuerySQL");
            this.grdNUR0113.Rows = 2;
            this.grdNUR0113.Size = new System.Drawing.Size(205, 191);
            this.grdNUR0113.TabIndex = 44;
            this.grdNUR0113.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR0113_QueryStarting);
            this.grdNUR0113.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdNUR0113_MouseDown);
            this.grdNUR0113.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdNUR0113_GiveFeedback);
            this.grdNUR0113.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdNUR0113_DragEnter);
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "nur_act_code";
            this.xGridCell1.Col = -1;
            this.xGridCell1.HeaderText = "nur_act_code";
            this.xGridCell1.IsVisible = false;
            this.xGridCell1.Row = -1;
            // 
            // xGridCell2
            // 
            this.xGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell2.CellName = "nur_act_name";
            this.xGridCell2.CellWidth = 185;
            this.xGridCell2.HeaderText = "nur_act_name";
            this.xGridCell2.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell2.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdOCS2015);
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 191);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(578, 38);
            this.xPanel1.TabIndex = 45;
            // 
            // grdOCS2015
            // 
            this.grdOCS2015.CallerID = '5';
            this.grdOCS2015.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16});
            this.grdOCS2015.ColPerLine = 16;
            this.grdOCS2015.Cols = 16;
            this.grdOCS2015.ControlBinding = true;
            this.grdOCS2015.FixedRows = 1;
            this.grdOCS2015.HeaderHeights.Add(21);
            this.grdOCS2015.Location = new System.Drawing.Point(3, 67);
            this.grdOCS2015.Name = "grdOCS2015";
            this.grdOCS2015.QuerySQL = resources.GetString("grdOCS2015.QuerySQL");
            this.grdOCS2015.Rows = 2;
            this.grdOCS2015.Size = new System.Drawing.Size(3, 3);
            this.grdOCS2015.TabIndex = 55;
            this.grdOCS2015.UseDefaultTransaction = false;
            this.grdOCS2015.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS2015_QueryStarting);
            this.grdOCS2015.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdOCS2015_SaveEnd);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.HeaderText = "bunho";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "fkinp1001";
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.HeaderText = "fkinp1001";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "order_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.HeaderText = "order_date";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "input_gubun";
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.HeaderText = "input_gubun";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "input_id";
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.HeaderText = "input_id";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "pk_seq";
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.HeaderText = "pk_seq";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "seq";
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.HeaderText = "seq";
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.BindControl = this.dtpAct_date;
            this.xEditGridCell8.CellName = "act_date";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.HeaderText = "act_date";
            // 
            // dtpAct_date
            // 
            this.dtpAct_date.IsJapanYearType = true;
            this.dtpAct_date.Location = new System.Drawing.Point(269, 8);
            this.dtpAct_date.Name = "dtpAct_date";
            this.dtpAct_date.Size = new System.Drawing.Size(110, 20);
            this.dtpAct_date.TabIndex = 50;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "act_id";
            this.xEditGridCell9.Col = 8;
            this.xEditGridCell9.HeaderText = "act_id";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.BindControl = this.dpbAct_id_name;
            this.xEditGridCell10.CellName = "act_id_name";
            this.xEditGridCell10.Col = 9;
            this.xEditGridCell10.HeaderText = "act_id_name";
            // 
            // dpbAct_id_name
            // 
            this.dpbAct_id_name.Location = new System.Drawing.Point(380, 8);
            this.dpbAct_id_name.Name = "dpbAct_id_name";
            this.dpbAct_id_name.Size = new System.Drawing.Size(127, 21);
            this.dpbAct_id_name.TabIndex = 51;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "act_result_code";
            this.xEditGridCell11.Col = 10;
            this.xEditGridCell11.HeaderText = "act_result_code";
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.BindControl = this.txtAct_result_text;
            this.xEditGridCell12.CellLen = 400;
            this.xEditGridCell12.CellName = "act_result_text";
            this.xEditGridCell12.Col = 11;
            this.xEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell12.HeaderText = "act_result_text";
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "pkocs2015";
            this.xEditGridCell13.Col = 12;
            this.xEditGridCell13.HeaderText = "pkocs2015";
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "input_gwa";
            this.xEditGridCell14.Col = 13;
            this.xEditGridCell14.HeaderText = "input_gwa";
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "input_doctor";
            this.xEditGridCell15.Col = 14;
            this.xEditGridCell15.HeaderText = "input_doctor";
            // 
            // xEditGridCell16
            //
            this.xEditGridCell16.BindControl = this.dpbAct_time;
            this.xEditGridCell16.CellName = "act_time";
            this.xEditGridCell16.Col = 15;
            this.xEditGridCell16.HeaderText = "act_time";
            // 
            // txtAct_result_text
            // 
            this.txtAct_result_text.AllowDrop = true;
            this.txtAct_result_text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAct_result_text.ApplyByteLimit = true;
            this.txtAct_result_text.Location = new System.Drawing.Point(210, 60);
            this.txtAct_result_text.MaxLength = 400;
            this.txtAct_result_text.Multiline = true;
            this.txtAct_result_text.Name = "txtAct_result_text";
            this.txtAct_result_text.Size = new System.Drawing.Size(364, 125);
            this.txtAct_result_text.TabIndex = 47;
            this.txtAct_result_text.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtAct_result_text_DragDrop);
            this.txtAct_result_text.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtAct_result_text_DragEnter);
            this.txtAct_result_text.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.txtAct_result_text_GiveFeedback);
            // 
            // dpbAct_time
            // 
            this.dpbAct_time.Location = new System.Drawing.Point(508, 8);
            this.dpbAct_time.Name = "dpbAct_time";
            this.dpbAct_time.Size = new System.Drawing.Size(60, 21);
            this.dpbAct_time.TabIndex = 52;
            this.dpbAct_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xFlatLabel5
            // 
            this.xFlatLabel5.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel5.Image = ((System.Drawing.Image)(resources.GetObject("xFlatLabel5.Image")));
            this.xFlatLabel5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xFlatLabel5.Location = new System.Drawing.Point(214, 34);
            this.xFlatLabel5.Name = "xFlatLabel5";
            this.xFlatLabel5.Size = new System.Drawing.Size(82, 20);
            this.xFlatLabel5.TabIndex = 48;
            this.xFlatLabel5.Text = "      内容";
            // 
            // frmDirectActing
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(578, 251);
            this.ControlBox = false;
            this.Controls.Add(this.dpbAct_time);
            this.Controls.Add(this.dpbAct_id_name);
            this.Controls.Add(this.dtpAct_date);
            this.Controls.Add(this.txtAct_result_text);
            this.Controls.Add(this.xFlatLabel5);
            this.Controls.Add(this.grdNUR0113);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xFlatLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDirectActing";
            this.Load += new System.EventHandler(this.frmDirectActing_Load);
            this.Controls.SetChildIndex(this.xFlatLabel1, 0);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.grdNUR0113, 0);
            this.Controls.SetChildIndex(this.xFlatLabel5, 0);
            this.Controls.SetChildIndex(this.txtAct_result_text, 0);
            this.Controls.SetChildIndex(this.dtpAct_date, 0);
            this.Controls.SetChildIndex(this.dpbAct_id_name, 0);
            this.Controls.SetChildIndex(this.dpbAct_time, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0113)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2015)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
			if(TypeCheck.IsNull(mBunho)) this.DialogResult = DialogResult.Cancel;
			if(!TypeCheck.IsInt(mFkinp1001)) this.DialogResult = DialogResult.Cancel;
			if(!TypeCheck.IsDateTime(mOrder_date)) this.DialogResult = DialogResult.Cancel;
			if(!TypeCheck.IsInt(mOcs2005_seq)) this.DialogResult = DialogResult.Cancel;
			if(TypeCheck.IsNull(mDirect_gubun)) this.DialogResult = DialogResult.Cancel;
			if(TypeCheck.IsNull(mDirect_code)) this.DialogResult = DialogResult.Cancel;
			if(TypeCheck.IsNull(mUser_id)) this.DialogResult = DialogResult.Cancel;

            if (!grdNUR0113.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

            if (!grdOCS2015.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

			//Insert
			if(grdOCS2015.RowCount < 1)
			{
                firstInput = "Y";
				int insertRow = grdOCS2015.InsertRow(-1);

                dtpAct_date.SetDataValue(mOrder_date);

                grdOCS2015.SetItemValue(insertRow, "bunho",       mBunho);
                grdOCS2015.SetItemValue(insertRow, "fkinp1001",   mFkinp1001);
                grdOCS2015.SetItemValue(insertRow, "order_date",  mSource_order_date);
                grdOCS2015.SetItemValue(insertRow, "input_gubun", mInput_gubun);
                grdOCS2015.SetItemValue(insertRow, "pk_seq",      mOcs2005_seq);

                grdOCS2015.SetItemValue(insertRow, "act_date",    dtpAct_date.GetDataValue());

				grdOCS2015.SetItemValue(insertRow, "act_id"     , mUser_id    );
                grdOCS2015.SetItemValue(insertRow, "act_id_name", mUser_name);

                if (UserInfo.UserGubun == UserType.Doctor)
                {
                    grdOCS2015.SetItemValue(insertRow, "input_id", UserInfo.DoctorID);
                }
                else grdOCS2015.SetItemValue(insertRow, "input_id", mUser_id);
			}
			else
			{
                firstInput = "N";
				grdOCS2015.SetItemValue(0, "act_id"     , mUser_id    );
				grdOCS2015.SetItemValue(0, "act_id_name", mUser_name  );
			}
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

        public string PKOCS
        {
            get
            {
                return mPkOcs;
            }
            set
            {
                mPkOcs = value;
            }
        }
        
        

		#endregion

		#region [grdNUR0113]

		private void grdNUR0113_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int curRowIndex = -1;			
			
			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				curRowIndex = grdNUR0113.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;
				string result_text = txtAct_result_text.GetDataValue() + " " + grdNUR0113.GetItemString(curRowIndex, "nur_act_name");
				txtAct_result_text.SetEditValue(result_text);
				
				txtAct_result_text.Focus();
				txtAct_result_text.SelectionStart = txtAct_result_text.Text.Length;

                // 선택된 실시코멘트 코드를 grdOCS2015의 act_result_code 셋팅   2011/01/24 KHJ
                grdOCS2015.SetItemValue(0, "act_result_code", grdNUR0113.GetItemString(curRowIndex, "nur_act_code"));
			}
			else if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				curRowIndex = grdNUR0113.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;

				string dragInfo = grdNUR0113.GetItemString(curRowIndex, "nur_act_name");
				DragHelper.CreateDragCursor(grdNUR0113, dragInfo, this.Font);
				txtAct_result_text.DoDragDrop("NUR0113|" + grdNUR0113.GetItemString(curRowIndex, "nur_act_name"), DragDropEffects.Move);	
			}		
		}

		private void grdNUR0113_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;  // Move 표시		
		}

		private void grdNUR0113_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
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

            // 선택된 실시코멘트 코드를 grdOCS2015의 act_result_code 셋팅   2011/01/24 KHJ
            grdOCS2015.SetItemValue(0, "act_result_code", grdNUR0113.GetItemString(grdNUR0113.CurrentRowNumber, "nur_act_code"));
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

		#region [Button List Event]
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				
				case FunctionType.Process:
					
					e.IsBaseCall = false;
                    
					this.AcceptData();

                    if (grdOCS2015.SaveLayout())
					{
						mbxMsg = "保存が完了しました。";
						SetMsg(mbxMsg);
						mActing_yn = "Y";
						this.DialogResult = DialogResult.OK;
					}
					else
					{
						mbxMsg = "保存に失敗しました。"; 
						mbxMsg = mbxMsg + Service.ErrFullMsg;
						mbxCap = "保存エラー";
						XMessageBox.Show(mbxMsg, mbxCap);
                        this.DialogResult = DialogResult.No;
                    }

					break;

				case FunctionType.Cancel:

					e.IsBaseCall = false;

					//acting 일자 null
					dtpAct_date.SetDataValue("");
					grdOCS2015.SetItemValue(grdOCS2015.CurrentRowNumber, "act_date", "");

                    if (grdOCS2015.RowCount < 1) return;

                    grdOCS2015.DeleteRow();

                    if (grdOCS2015.SaveLayout())
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が完了しました。" : "저장이 완료되었습니다.";
						SetMsg(mbxMsg);
						mActing_yn = "N";
						this.DialogResult = DialogResult.OK;
					}
					else
					{
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "保存に失敗しました。" : "저장이 실패하였습니다."; 
						mbxMsg = mbxMsg + Service.ErrMsg;
						mbxCap = NetInfo.Language == LangMode.Jr ? "保存エラー" : "Save Error";
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

		#region 저장 후 이벤트
        private void grdOCS2015_SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
		{
			if(e.IsSuccess == true)
			{
				return;
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

        #region [ 각 그리드에 바인드변수 설정 ]
        private void grdNUR0113_QueryStarting(object sender, CancelEventArgs e)
        {
            grdNUR0113.SetBindVarValue("f_nur_md_code", mDirect_code);
            grdNUR0113.SetBindVarValue("f_hosp_code",   mHospCode);
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
        #endregion


        #region XSavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private frmDirectActing parent = null;
            public XSavePerformer(frmDirectActing parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                item.BindVarList.Add("q_user_id",   UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                switch (item.RowState)
                {
                    case DataRowState.Added:

                        object chkDup = null;
                        cmdText = @"SELECT NVL(MAX(A.SEQ), 0) + 1 AS SEQ
                                      FROM OCS2015 A
                                     WHERE A.HOSP_CODE   = :f_hosp_code
                                       AND A.BUNHO       = :f_bunho
                                       AND A.FKINP1001   = :f_fkinp1001
                                       AND A.ORDER_DATE  = :f_order_date
                                       AND A.INPUT_GUBUN = :f_input_gubun
                                       AND A.PK_SEQ      = :f_pk_seq
                                       AND ROWNUM = 1";
                        chkDup = Service.ExecuteScalar(cmdText, item.BindVarList);
                        item.BindVarList.Remove("f_seq");
                        item.BindVarList.Add("f_seq", chkDup.ToString());

                        cmdText = "SELECT OCS2015_SEQ.NEXTVAL FROM DUAL";
                        chkDup = Service.ExecuteScalar(cmdText);
                        item.BindVarList.Remove("f_pkocs2015");
                        item.BindVarList.Add("f_pkocs2015", chkDup.ToString());

                        cmdText = @"INSERT INTO OCS2015
                                         ( SYS_DATE     , SYS_ID            , PKOCS2015         , BUNHO      , UPD_DATE, UPD_ID,
                                           FKINP1001    , ORDER_DATE        , INPUT_GUBUN       , INPUT_ID   ,
                                           PK_SEQ       , SEQ               , DRT_DATE          , ACT_DATE   ,
                                           ACT_ID       , ACT_RESULT_CODE   , ACT_RESULT_TEXT   , HOSP_CODE  ,
                                           INPUT_GWA    , INPUT_DOCTOR  )
                                    VALUES      
                                         ( SYSDATE      , :q_user_id        , :f_pkocs2015      , :f_bunho   , SYSDATE, :q_user_id,
                                           :f_fkinp1001 , :f_order_date     , :f_input_gubun    , :f_input_id,
                                           :f_pk_seq    , :f_seq            , :f_order_date     , :f_act_date,
                                           :f_act_id    , :f_act_result_code, :f_act_result_text, :f_hosp_code,
                                           :f_input_gwa , :f_input_doctor   )";

                        break;

                    case DataRowState.Modified:

                        cmdText = @"UPDATE OCS2015
                                       SET UPD_ID           = :f_act_id             ,
                                           UPD_DATE         = SYSDATE               ,
                                           ACT_DATE         = :f_act_date           ,
                                           ACT_ID           = DECODE(:f_act_date, NULL, NULL, :f_act_id) ,
                                           ACT_RESULT_CODE  = :f_act_result_code    ,
                                           ACT_RESULT_TEXT  = :f_act_result_text
                                     WHERE HOSP_CODE        = :f_hosp_code
                                       AND PKOCS2015        = :f_pkocs2015
                                       /*
                                           BUNHO           = :f_bunho
                                       AND FKINP1001       = :f_fkinp1001
                                       AND ORDER_DATE      = :f_order_date
                                       AND INPUT_GUBUN     = :f_input_gubun
                                       AND PK_SEQ          = :f_pk_seq
                                       AND SEQ             = :f_seq
                                       AND HOSP_CODE       = :f_hosp_code
                                       */";

                        break;

                    case DataRowState.Deleted:

                        cmdText = @"DELETE OCS2015
                                     WHERE HOSP_CODE        = :f_hosp_code
                                       AND PKOCS2015        = :f_pkocs2015
                                       /*
                                           BUNHO           = :f_bunho
                                       AND FKINP1001       = :f_fkinp1001
                                       AND ORDER_DATE      = :f_order_date
                                       AND INPUT_GUBUN     = :f_input_gubun
                                       AND PK_SEQ          = :f_pk_seq
                                       AND SEQ             = :f_seq
                                       AND HOSP_CODE       = :f_hosp_code
                                       */";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

    }
}

