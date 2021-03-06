using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;

namespace IHIS.Framework
{
	/// <summary>
	/// FindPatientForm에 대한 요약 설명입니다.
	/// </summary>
	internal class FindPatientForm : System.Windows.Forms.Form
	{
		#region Fields and Properties
		private Color  selectedBackColor = Color.PaleTurquoise;
		private Color  unSelectedBackColor = Color.FromArgb(227,248,181);
		[DataBindable]
		public string Gubun
		{
			get { return this.rboAll.Checked ? "A" : "J";} //A.전체, J.재원만
		}
		#endregion

        private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XGridCell xGridCell3;
		private IHIS.Framework.XGridCell xGridCell4;
		private IHIS.Framework.XGridCell xGridCell5;
		private IHIS.Framework.XGridCell xGridCell6;
		private IHIS.Framework.XGridCell xGridCell7;
		private IHIS.Framework.XGridCell xGridCell8;
		private IHIS.Framework.XGridCell xGridCell9;
		private IHIS.Framework.XButton btnSearch;
		private IHIS.Framework.XButton btnSelect;
        private IHIS.Framework.XButton btnClose;
		private IHIS.Framework.XGrid grdPatientList;
		private IHIS.Framework.XGridCell xGridCell10;
        private IHIS.Framework.XToolTip xToolTip1;
        private XLabel lblName;
        private XTextBox txtSuname;
        private XLabel lblSex;
        private XDictComboBox cboSex;
        private XLabel lblBirth;
        private XDatePicker dtpBirth;
        private XLabel lblTel;
        private XTextBox txtTel;
        private RadioButton rboAll;
        private RadioButton rboOnly;
        private XPanel xPanel1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private const string CACHE_FINDPATIENT_COMBO_LIST_ITEM_KEYS = "System.Findpatien.CboSexItem"; 

		public FindPatientForm(Control cont)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

            // Connect Cloud
            grdPatientList.ExecuteQuery = grdPatientList_ExecuteQuery;
		    cboSex.ExecuteQuery = GetDataForCboSex;

            //TODO disable IN Hospital Tab MED-5790
            rboOnly.Visible = false;

		    //
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			// 위치조정(Find창을 Call한 Control의 하단에
			if (cont != null)
			{
				/*Screen이 2개이상일 경우에는 rc의 Width는 두 모니터의 Width를 더한값, Height는
				 *Second화면의 해상도가 같으면 관계없으나, 해상도가 다르면 Second화면의 WorkingArea의 Y는
				 *0부터시작하지않고, Primary의 기준에서 얼만큼 높이에 있는냐로 처리됨.
				 *ex> Primary : 1280*1024 Second 1024*768이면 Primary.WorkingArea(0,0,1280,994) Second.WorkingArea(1280,256,1024,768)
				 *따라서, 높이는 Second의 WorkingArea의 Y + Height로 설정해야함
				 */
				Rectangle rc = Screen.PrimaryScreen.WorkingArea;
				// 위치 조정(Dual Monitor일때 Second화면에 있으면 X값은 Primary화면의Width + Second에서의 위치로 표시됨
				// 2006.03.28 모니터 3개이상도 고려하여 반영
				Point pos = cont.PointToScreen(new Point(0, cont.Height));
				if (SystemInformation.MonitorCount > 1)
				{
					//pos.X가 Second Monitor 이상에 있으면 rc 변경
					if (pos.X > rc.Width)
					{
						//두번째 Monitor 부터 위치 파악
						for (int i = 1 ; i < SystemInformation.MonitorCount; i++)
						{
							Rectangle sRect = Screen.AllScreens[i].WorkingArea;
							//cont가 위치하는 Monitor 확인
							if ((pos.X >= sRect.Left) && (pos.X <= sRect.Right))
							{
								rc = new Rectangle(rc.X, rc.Y, sRect.Right, sRect.Y + sRect.Height);
								break;
							}
						}
					}
				}

				if (this.Width > rc.Width - pos.X)
				{
					pos.X = Math.Max(rc.Width - this.Width, 0);
				}
				if (this.Height > rc.Height - pos.Y)
				{
					if (this.Height > pos.Y - cont.Height)
						pos.Y = Math.Max(rc.Height - this.Height, 0);
					else
						pos.Y -= (this.Height + cont.Height);
				}
				this.Location = pos;
			}
		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Property

		public string BunHo
		{
			get 
			{
				if (this.grdPatientList.CurrentRowNumber >= 0)
					return this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber,"bunho").ToString();
				else
					return "";
			}
		}

		#endregion

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindPatientForm));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnSearch = new IHIS.Framework.XButton();
            this.btnSelect = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.grdPatientList = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.xGridCell6 = new IHIS.Framework.XGridCell();
            this.xGridCell7 = new IHIS.Framework.XGridCell();
            this.xGridCell8 = new IHIS.Framework.XGridCell();
            this.xGridCell9 = new IHIS.Framework.XGridCell();
            this.xGridCell10 = new IHIS.Framework.XGridCell();
            this.xToolTip1 = new IHIS.Framework.XToolTip();
            this.lblName = new IHIS.Framework.XLabel();
            this.txtSuname = new IHIS.Framework.XTextBox();
            this.lblSex = new IHIS.Framework.XLabel();
            this.cboSex = new IHIS.Framework.XDictComboBox();
            this.lblBirth = new IHIS.Framework.XLabel();
            this.dtpBirth = new IHIS.Framework.XDatePicker();
            this.lblTel = new IHIS.Framework.XLabel();
            this.txtTel = new IHIS.Framework.XTextBox();
            this.rboAll = new System.Windows.Forms.RadioButton();
            this.rboOnly = new System.Windows.Forms.RadioButton();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientList)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.btnSearch);
            this.xPanel2.Controls.Add(this.btnSelect);
            this.xPanel2.Controls.Add(this.btnClose);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleDescription = null;
            this.btnSearch.AccessibleName = null;
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.BackgroundImage = null;
            this.btnSearch.Font = null;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleDescription = null;
            this.btnSelect.AccessibleName = null;
            resources.ApplyResources(this.btnSelect, "btnSelect");
            this.btnSelect.BackgroundImage = null;
            this.btnSelect.Font = null;
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleDescription = null;
            this.btnClose.AccessibleName = null;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackgroundImage = null;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = null;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdPatientList
            // 
            resources.ApplyResources(this.grdPatientList, "grdPatientList");
            this.grdPatientList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell3,
            this.xGridCell4,
            this.xGridCell5,
            this.xGridCell6,
            this.xGridCell7,
            this.xGridCell8,
            this.xGridCell9,
            this.xGridCell10});
            this.grdPatientList.ColPerLine = 10;
            this.grdPatientList.ColResizable = true;
            this.grdPatientList.Cols = 10;
            this.grdPatientList.ExecuteQuery = null;
            this.grdPatientList.FixedRows = 1;
            this.grdPatientList.HeaderHeights.Add(24);
            this.grdPatientList.Name = "grdPatientList";
            this.grdPatientList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPatientList.ParamList")));
            this.grdPatientList.QuerySQL = "SELECT A.BUNHO";
            this.grdPatientList.Rows = 2;
            this.grdPatientList.ToolTipActive = true;
            this.grdPatientList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPatientList_QueryStarting);
            this.grdPatientList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdPatientList_MouseDown);
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "bunho";
            this.xGridCell1.CellWidth = 76;
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            this.xGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell2
            // 
            this.xGridCell2.CellName = "suname";
            this.xGridCell2.CellWidth = 175;
            this.xGridCell2.Col = 1;
            resources.ApplyResources(this.xGridCell2, "xGridCell2");
            // 
            // xGridCell3
            // 
            this.xGridCell3.CellName = "suname2";
            this.xGridCell3.CellWidth = 175;
            this.xGridCell3.Col = 2;
            resources.ApplyResources(this.xGridCell3, "xGridCell3");
            // 
            // xGridCell4
            // 
            this.xGridCell4.CellName = "sex";
            this.xGridCell4.CellWidth = 87;
            this.xGridCell4.Col = 3;
            resources.ApplyResources(this.xGridCell4, "xGridCell4");
            this.xGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell5
            // 
            this.xGridCell5.CellName = "birth";
            this.xGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell5.CellWidth = 102;
            this.xGridCell5.Col = 4;
            resources.ApplyResources(this.xGridCell5, "xGridCell5");
            // 
            // xGridCell6
            // 
            this.xGridCell6.CellName = "last_naewon_date";
            this.xGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell6.CellWidth = 120;
            this.xGridCell6.Col = 5;
            resources.ApplyResources(this.xGridCell6, "xGridCell6");
            // 
            // xGridCell7
            // 
            this.xGridCell7.CellName = "address";
            this.xGridCell7.CellWidth = 219;
            this.xGridCell7.Col = 7;
            resources.ApplyResources(this.xGridCell7, "xGridCell7");
            // 
            // xGridCell8
            // 
            this.xGridCell8.CellName = "ipwon_yn";
            this.xGridCell8.CellWidth = 60;
            this.xGridCell8.Col = 8;
            resources.ApplyResources(this.xGridCell8, "xGridCell8");
            // 
            // xGridCell9
            // 
            this.xGridCell9.CellName = "ho_dong";
            this.xGridCell9.CellWidth = 120;
            this.xGridCell9.Col = 9;
            resources.ApplyResources(this.xGridCell9, "xGridCell9");
            // 
            // xGridCell10
            // 
            this.xGridCell10.CellName = "tel";
            this.xGridCell10.CellWidth = 104;
            this.xGridCell10.Col = 6;
            resources.ApplyResources(this.xGridCell10, "xGridCell10");
            // 
            // lblName
            // 
            this.lblName.AccessibleDescription = null;
            this.lblName.AccessibleName = null;
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblName.EdgeRounding = false;
            this.lblName.Font = null;
            this.lblName.Image = null;
            this.lblName.Name = "lblName";
            // 
            // txtSuname
            // 
            this.txtSuname.AccessibleDescription = null;
            this.txtSuname.AccessibleName = null;
            resources.ApplyResources(this.txtSuname, "txtSuname");
            this.txtSuname.BackgroundImage = null;
            this.txtSuname.Font = null;
            this.txtSuname.Name = "txtSuname";
            this.txtSuname.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSuname_DataValidating);
            // 
            // lblSex
            // 
            this.lblSex.AccessibleDescription = null;
            this.lblSex.AccessibleName = null;
            resources.ApplyResources(this.lblSex, "lblSex");
            this.lblSex.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSex.EdgeRounding = false;
            this.lblSex.Font = null;
            this.lblSex.Image = null;
            this.lblSex.Name = "lblSex";
            // 
            // cboSex
            // 
            this.cboSex.AccessibleDescription = null;
            this.cboSex.AccessibleName = null;
            resources.ApplyResources(this.cboSex, "cboSex");
            this.cboSex.BackgroundImage = null;
            this.cboSex.ExecuteQuery = null;
            this.cboSex.Name = "cboSex";
            this.cboSex.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboSex.ParamList")));
            this.cboSex.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboSex.SelectedIndexChanged += new System.EventHandler(this.cboSex_SelectedIndexChanged);
            // 
            // lblBirth
            // 
            this.lblBirth.AccessibleDescription = null;
            this.lblBirth.AccessibleName = null;
            resources.ApplyResources(this.lblBirth, "lblBirth");
            this.lblBirth.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBirth.EdgeRounding = false;
            this.lblBirth.Font = null;
            this.lblBirth.Image = null;
            this.lblBirth.Name = "lblBirth";
            // 
            // dtpBirth
            // 
            this.dtpBirth.AccessibleDescription = null;
            this.dtpBirth.AccessibleName = null;
            resources.ApplyResources(this.dtpBirth, "dtpBirth");
            this.dtpBirth.BackgroundImage = null;
            this.dtpBirth.Font = null;
            this.dtpBirth.IsVietnameseYearType = false;
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpBirth_DataValidating);
            // 
            // lblTel
            // 
            this.lblTel.AccessibleDescription = null;
            this.lblTel.AccessibleName = null;
            resources.ApplyResources(this.lblTel, "lblTel");
            this.lblTel.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblTel.EdgeRounding = false;
            this.lblTel.Font = null;
            this.lblTel.Image = null;
            this.lblTel.Name = "lblTel";
            // 
            // txtTel
            // 
            this.txtTel.AccessibleDescription = null;
            this.txtTel.AccessibleName = null;
            resources.ApplyResources(this.txtTel, "txtTel");
            this.txtTel.BackgroundImage = null;
            this.txtTel.Font = null;
            this.txtTel.Name = "txtTel";
            this.txtTel.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtTel_DataValidating);
            // 
            // rboAll
            // 
            this.rboAll.AccessibleDescription = null;
            this.rboAll.AccessibleName = null;
            resources.ApplyResources(this.rboAll, "rboAll");
            this.rboAll.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rboAll.BackgroundImage = null;
            this.rboAll.Checked = true;
            this.rboAll.Font = null;
            this.rboAll.Name = "rboAll";
            this.rboAll.TabStop = true;
            this.rboAll.UseVisualStyleBackColor = false;
            this.rboAll.CheckedChanged += new System.EventHandler(this.rboAll_CheckedChanged);
            // 
            // rboOnly
            // 
            this.rboOnly.AccessibleDescription = null;
            this.rboOnly.AccessibleName = null;
            resources.ApplyResources(this.rboOnly, "rboOnly");
            this.rboOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(248)))), ((int)(((byte)(181)))));
            this.rboOnly.BackgroundImage = null;
            this.rboOnly.Font = null;
            this.rboOnly.Name = "rboOnly";
            this.rboOnly.UseVisualStyleBackColor = false;
            this.rboOnly.CheckedChanged += new System.EventHandler(this.rboOnly_CheckedChanged);
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.rboOnly);
            this.xPanel1.Controls.Add(this.rboAll);
            this.xPanel1.Controls.Add(this.txtTel);
            this.xPanel1.Controls.Add(this.lblTel);
            this.xPanel1.Controls.Add(this.dtpBirth);
            this.xPanel1.Controls.Add(this.lblBirth);
            this.xPanel1.Controls.Add(this.cboSex);
            this.xPanel1.Controls.Add(this.lblSex);
            this.xPanel1.Controls.Add(this.txtSuname);
            this.xPanel1.Controls.Add(this.lblName);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // FindPatientForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.CancelButton = this.btnClose;
            this.Controls.Add(this.grdPatientList);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = null;
            this.KeyPreview = true;
            this.Name = "FindPatientForm";
            this.Load += new System.EventHandler(this.FindPatientForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindPatientForm_KeyDown);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region Grid Mouse Down 이벤트

		private void grdPatientList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				int rowNum = this.grdPatientList.GetHitRowNumber(e.Y);

				if (rowNum < 0)
					return;

				this.DialogResult = DialogResult.OK;
			}
		}

		#endregion

		#region XButton

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			/* 조회가 가능한지 조건 검색 */
			if (this.txtSuname.GetDataValue() == "")
			{
                //Fix bug MED-9411
                //if (this.cboSex.GetDataValue() != "" && this.dtpBirth.GetDataValue() != "")
                //{
                //    this.LoadData();
                //    return;
                //}
                if (this.cboSex.GetDataValue() != "" || this.dtpBirth.GetDataValue().ToString() != "")
                {
                    this.LoadData();
                    return;
                }

                if (this.txtTel.GetDataValue() != "" && this.txtTel.GetDataValue().Length >= 3)
                {
                    this.LoadData();
                }
             
			}
			else
			{
				this.LoadData();
			}
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		#endregion

		#region DataLoad

		private void LoadData()
		{
			/* 가나 변환 */
			string halfKanaName = this.txtSuname.GetDataValue();
			if (NetInfo.Language == LangMode.Jr) //일본어 모드일때만 Half Kata로 변경
				halfKanaName = JapanTextHelper.GetHalfKatakana(halfKanaName, false);
            
            // Get data for grid from cloud
            grdPatientList.ParamList = CreateParamList();
            grdPatientList.QueryLayout(false);
		    /* 서비스 셋팅 */
		    //this.dsvQuery.SetInValue("suname", halfKanaName);

		    //this.dsvQuery.Call();
		}

		#endregion

		#region Form 단축키 지정

		private void FindPatientForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.KeyCode == Keys.F2) && !e.Shift && !e.Alt && !e.Control)
			{
				this.btnSearch.PerformClick();
				e.Handled = true;
			}

			if ((e.KeyCode == Keys.Escape) && !e.Shift && !e.Alt && !e.Control)
			{
				this.btnClose.PerformClick();
				e.Handled = true;
			}
		}

		#endregion

		#region 조회 조건의 변화별 조회

		#region 환자명 Validating

		private void txtSuname_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			// 조회 조건 
			// 이름이 있거나
			// 이름이 없더라도 성별과 생년월일이 입력되거나 전화번호가 입력되면 조회
			if (e.DataValue != "")
			{
				this.btnSearch.PerformClick();
			}
			else
			{
				if (cboSex.GetDataValue() != "" && this.dtpBirth.GetDataValue() != "")
				{
					this.btnSearch.PerformClick();
				}

				if (this.txtTel.GetDataValue() != "" )
				{
					this.btnSearch.PerformClick();
				}

				if (this.cboSex.GetDataValue() == "" && this.dtpBirth.GetDataValue() == "" &&
					this.txtTel.GetDataValue() == "" )
				{
					this.grdPatientList.Reset();
				}
			}
		}

		#endregion

		#region 생년월일 Validating

		private void dtpBirth_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if (e.DataValue != "")
			{
				this.btnSearch.PerformClick();
			}
			else
			{
				if (this.cboSex.GetDataValue() != "")
				{
					this.btnSearch.PerformClick();
				}

				if (this.txtSuname.GetDataValue() == "" && this.cboSex.GetDataValue() == "" &&
					this.txtTel.GetDataValue() == "" )
				{
					this.grdPatientList.Reset();
				}
			}
		}

		#endregion

		#region 전화번호 Validating

		private void txtTel_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if (e.DataValue != "")
			{
				if (e.DataValue.Length >= 3)
					this.btnSearch.PerformClick();
			}
			else
			{
				if (this.txtSuname.GetDataValue() == "" && this.cboSex.GetDataValue() == "" &&
					this.dtpBirth.GetDataValue() == "" )
				{
					this.grdPatientList.Reset();
				}
			}
		}

		#endregion

		#region 성별 SelectIndex Change

		private void cboSex_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (this.cboSex.SelectedIndex >= 0)
			{
				/* 환자 이름이 입력되지 않았다면 조회하지 않음 */
                if (this.txtSuname.GetDataValue() == "")
				{
					// 환자 이름이 입력되지 않았더라도 생년월일이 입력 되었다면 조회
					if (this.dtpBirth.GetDataValue() != "")
					{
						this.btnSearch.PerformClick();
						return;
					}

					return;
				}

				this.btnSearch.PerformClick();
			}
		}

		#endregion

		#endregion

		#region Patient Form Load 이벤트

		private void FindPatientForm_Load(object sender, System.EventArgs e)
		{
			this.grdPatientList.FixedCols = 3;
            // Get data for cboSex
            this.cboSex.ParamList = CreateParamForCboSex();
            this.cboSex.SetDictDDLB();
		}

		#endregion

		#region SetControlTextByLangMode(한국 Format 확정하여 나중에 적용하자)
		//일본어, 한글 모드에 따른 Text 설정
		private void SetControlTextByLangMode()
		{
			if (NetInfo.Language == LangMode.Ko)
			{
				this.dtpBirth.IsJapanYearType = false; //일본연호형식 아님
				this.txtSuname.ImeMode = ImeMode.Hangul;
				this.Text = "환자검색";
				this.lblName.Text = "성 명";
				this.lblBirth.Text = "생년월일";
				this.lblSex.Text = "성별";
				this.lblTel.Text = "전화번호";
				this.btnSearch.Text = "검 색[F2]";
				this.btnSelect.Text = "선 택";
				this.btnClose.Text = "취 소";
				this.rboAll.Text = "전체";
				this.rboOnly.Text = "재원만";
				this.grdPatientList[0,0].Value = "환자번호";
				this.grdPatientList[0,1].Value = "성 명";
				this.grdPatientList[0,2].Value = "성명(한자)";
				this.grdPatientList[0,3].Value = "성별";
				this.grdPatientList[0,4].Value = "생년월일";
				this.grdPatientList[0,5].Value = "최종내원일";
				this.grdPatientList[0,6].Value = "전화번호";
				this.grdPatientList[0,7].Value = "주 소";
				this.grdPatientList[0,8].Value = "입원";
				this.grdPatientList[0,9].Value = "병동";
			}
			else  //일본어
			{
				this.dtpBirth.IsJapanYearType = true; //일본연호형식
				this.txtSuname.ImeMode = ImeMode.KatakanaHalf;
				this.Text = "患者検索";
				this.lblName.Text = "氏名(ｶﾅ)";
				this.lblBirth.Text = "生年月日";
				this.lblSex.Text = "性別";
				this.lblTel.Text = "電話番号";
				this.btnSearch.Text = "検 索[F2]";
				this.btnSelect.Text = "選 択";
				this.btnClose.Text = "取 消";
				this.rboAll.Text = "全体";
				this.rboOnly.Text = "在院のみ";
				this.grdPatientList[0,0].Value = "患者番号";
				this.grdPatientList[0,1].Value = "氏名(漢字)";
				this.grdPatientList[0,2].Value = "氏名(ｶﾅ)";
				this.grdPatientList[0,3].Value = "性別";
				this.grdPatientList[0,4].Value = "生年月日";
				this.grdPatientList[0,5].Value = "最終来院日";
				this.grdPatientList[0,6].Value = "電話番号";
				this.grdPatientList[0,7].Value = "住 所";
				this.grdPatientList[0,8].Value = "入院";
				this.grdPatientList[0,9].Value = "病棟";
			}
		}
		#endregion

		private void rboAll_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.rboAll.Checked)
			{
				this.rboAll.BackColor = this.selectedBackColor;
				//조회
				this.btnSearch.PerformClick();
			}
			else
				this.rboAll.BackColor = this.unSelectedBackColor;
		}

		private void rboOnly_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.rboOnly.Checked)
			{
				this.rboOnly.BackColor = this.selectedBackColor;
				//조회
				this.btnSearch.PerformClick();
			}
			else
				this.rboOnly.BackColor = this.unSelectedBackColor;
		}

        private void grdPatientList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPatientList.SetBindVarValue("f_suname2", txtSuname.GetDataValue());
            this.grdPatientList.SetBindVarValue("f_sex", cboSex.GetDataValue());
            this.grdPatientList.SetBindVarValue("f_birth", dtpBirth.GetDataValue());
            this.grdPatientList.SetBindVarValue("f_tel", txtTel.GetDataValue());
            this.grdPatientList.SetBindVarValue("f_gubun", Gubun);
        }

	    private List<string> CreateParamList()
	    {
	        List<string> listParam = new List<string>();
            listParam.Add("f_suname2");
            listParam.Add("f_sex");
            listParam.Add("f_birth");
            listParam.Add("f_tel");
            listParam.Add("f_gubun");
            // https://sofiamedix.atlassian.net/browse/MED-13700
            listParam.Add("f_type");
            listParam.Add("f_page_number");
            listParam.Add("f_offset");
	        return listParam;
	    }

        private IList<object[]> grdPatientList_ExecuteQuery(BindVarCollection lisCollection)
	    {
            
            IList<object[]> listResult = new List<object[]>();
            FindPatientFromArgs findPatientFromArgs = new FindPatientFromArgs();
            // https://sofiamedix.atlassian.net/browse/MED-13700
            findPatientFromArgs.Brith = lisCollection["f_birth"].VarValue;
            findPatientFromArgs.Sex = lisCollection["f_sex"].VarValue;
            findPatientFromArgs.Tel = lisCollection["f_tel"].VarValue;
            findPatientFromArgs.Type = lisCollection["f_gubun"].VarValue;
            findPatientFromArgs.PatientName2 = lisCollection["f_suname2"].VarValue;
            findPatientFromArgs.PageNumber = lisCollection["f_page_number"].VarValue;
            findPatientFromArgs.Offset = "200";

                //lisCollection["f_suname2"].VarValue,
                //lisCollection["f_sex"].VarValue,
                //lisCollection["f_birth"].VarValue,
                //lisCollection["f_tel"].VarValue,
                //lisCollection["f_gubun"].VarValue,
                //"200"
                //);

            FindPatientFromResult patientFromResult =
                CloudService.Instance.Submit<FindPatientFromResult, FindPatientFromArgs>(findPatientFromArgs);
            if (patientFromResult != null)
            {
                IList<FindPatientInfo> listpPatientInfo = patientFromResult.PatientInfoItem;
                if (listpPatientInfo != null && listpPatientInfo.Count > 0)
                {
                    foreach (FindPatientInfo findPatientInfo in listpPatientInfo)
                    {
                        object[] objPationInfo =
                    {
                        findPatientInfo.PatientCode,
                        findPatientInfo.PatientName,
                        findPatientInfo.PatientName2,
                        findPatientInfo.Sex,
                        findPatientInfo.Birth,
                        findPatientInfo.LastCommingDate,
                        findPatientInfo.Address,
                        findPatientInfo.IpwonYn,
                        findPatientInfo.TreatmentArea,
                        findPatientInfo.Tel
                    };
                        listResult.Add(objPationInfo);

                    }
                }
            }
            
            return listResult;
	    }

        private List<string> CreateParamForCboSex()
        {
            List<string> lstParam = new List<string>();
            lstParam.Add("code_type");
            return lstParam;
        }

	    private IList<object[]> GetDataForCboSex(BindVarCollection bindVarCollection)
	    {
	        IList<object[]> lstDataResult = new List<object[]>();

	        ComboListByCodeTypeArgs comboListByCodeTypeArgs = new ComboListByCodeTypeArgs("SEX_GUBUN", false);
//                ComboListItemResult result =
//                    CloudService.Instance.Submit<ComboListItemResult, ComboListByCodeTypeArgs>(
//                        comboListByCodeTypeArgs);
	        ComboListItemResult result = CacheService.Instance.Get<ComboListByCodeTypeArgs, ComboListItemResult>(comboListByCodeTypeArgs);
	        if (result != null)
	        {
	            IList<ComboListItemInfo> listItemInfos = result.ListItemInfos;
	            if (listItemInfos != null && listItemInfos.Count > 0)
	            {
	                foreach (ComboListItemInfo comboListItemInfo in listItemInfos)
	                {
	                    object[] cboItem =
	                    {
	                        comboListItemInfo.Code,
	                        comboListItemInfo.CodeName
	                    };
	                    lstDataResult.Add(cboItem);
	                }
	            }
	        }
	        return lstDataResult;
        }
	}
}
