#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Outs;
using IHIS.CloudConnector.Contracts.Models.Outs;
using IHIS.CloudConnector.Contracts.Results.Outs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.NURO.Properties;

#endregion

namespace IHIS.NURO
{
	/// <summary>
	/// OUT0106U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OUT0106U00 : IHIS.Framework.XScreen
	{
		#region 사용자 변수
		string mbxMsg = string.Empty;
		string mbxCap = string.Empty;
		string mnaewon_date = string.Empty;

		private bool mIsWarningForPastData = false;

		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XPatientBox pbxPatient;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGrid grdList;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XTabControl tabOut;
		private IHIS.Framework.XFindWorker fwkFind;
        private IHIS.Framework.XButtonList btnList;
		private IHIS.X.Magic.Controls.TabPage tpgOUT0106;
		private IHIS.Framework.XButton btnPatientInfo;
		private IHIS.Framework.XLabel lbQueryDate;
		private IHIS.Framework.XDatePicker dtpQueryDate;
        private XEditGrid grdOUT0113;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XGridHeader xGridHeader1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

	    private OUT0106U00GridListResult gridListResult;
		#endregion

		public OUT0106U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			SaveLayoutList.Add(this.grdList);
            //SaveLayoutList.Add(this.grdOUT0113);
			this.grdList.SavePerformer = new XSavePerformer(this);
			this.grdOUT0113.SavePerformer = new XSavePerformer(this);
            this.grdList.ExecuteQuery = this.GetGridList;
		    this.grdOUT0113.ExecuteQuery = this.GetPatientCommentList;
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

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OUT0106U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.grdOUT0113 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.fwkFind = new IHIS.Framework.XFindWorker();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.pbxPatient = new IHIS.Framework.XPatientBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnPatientInfo = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.dtpQueryDate = new IHIS.Framework.XDatePicker();
            this.tabOut = new IHIS.Framework.XTabControl();
            this.tpgOUT0106 = new IHIS.X.Magic.Controls.TabPage();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.lbQueryDate = new IHIS.Framework.XLabel();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT0113)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPatient)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.tabOut.SuspendLayout();
            this.tpgOUT0106.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.grdOUT0113);
            this.xPanel1.Controls.Add(this.pbxPatient);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // grdOUT0113
            // 
            this.grdOUT0113.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdOUT0113, "grdOUT0113");
            this.grdOUT0113.CallerID = '2';
            this.grdOUT0113.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell5,
            this.xEditGridCell10,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9});
            this.grdOUT0113.ColPerLine = 5;
            this.grdOUT0113.Cols = 5;
            this.grdOUT0113.ExecuteQuery = null;
            this.grdOUT0113.FixedRows = 2;
            this.grdOUT0113.HeaderHeights.Add(18);
            this.grdOUT0113.HeaderHeights.Add(0);
            this.grdOUT0113.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOUT0113.Name = "grdOUT0113";
            this.grdOUT0113.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOUT0113.ParamList")));
            this.grdOUT0113.QuerySQL = resources.GetString("grdOUT0113.QuerySQL");
            this.grdOUT0113.Rows = 3;
            this.grdOUT0113.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOUT0113_GridColumnChanged);
            this.grdOUT0113.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOUT0113_GridFindClick);
            this.grdOUT0113.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOUT0113_QueryStarting);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AutoTabDataSelected = true;
            this.xEditGridCell5.CellLen = 3;
            this.xEditGridCell5.CellName = "patient_info";
            this.xEditGridCell5.CellWidth = 50;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.FindWorker = this.fwkFind;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsNotNull = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.Row = 1;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkFind
            // 
            this.fwkFind.ExecuteQuery = null;
            this.fwkFind.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkFind.ParamList")));
            this.fwkFind.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkFind.ServerFilter = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 100;
            this.xEditGridCell10.CellName = "patient_info_name";
            this.xEditGridCell10.CellWidth = 160;
            this.xEditGridCell10.Col = 1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.Row = 1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "start_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.CellWidth = 111;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsJapanYearType = true;
            this.xEditGridCell6.IsNotNull = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.RowSpan = 2;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "end_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.CellWidth = 115;
            this.xEditGridCell7.Col = 3;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.InvalidDateIsStringEmpty = false;
            this.xEditGridCell7.IsJapanYearType = true;
            this.xEditGridCell7.RowSpan = 2;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 1000;
            this.xEditGridCell8.CellName = "comment";
            this.xEditGridCell8.CellWidth = 98;
            this.xEditGridCell8.Col = 4;
            this.xEditGridCell8.DisplayMemoText = true;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.RowSpan = 2;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 9;
            this.xEditGridCell9.CellName = "bunho";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsNotNull = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 50;
            // 
            // pbxPatient
            // 
            this.pbxPatient.AccessibleDescription = null;
            this.pbxPatient.AccessibleName = null;
            resources.ApplyResources(this.pbxPatient, "pbxPatient");
            this.pbxPatient.BackgroundImage = null;
            this.pbxPatient.Font = null;
            this.pbxPatient.Name = "pbxPatient";
            this.pbxPatient.PatientSelectionFailed += new System.EventHandler(this.pbxPatient_PatientSelectionFailed);
            this.pbxPatient.PatientSelected += new System.EventHandler(this.pbxPatient_PatientSelected);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.btnPatientInfo);
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnPatientInfo
            // 
            this.btnPatientInfo.AccessibleDescription = null;
            this.btnPatientInfo.AccessibleName = null;
            resources.ApplyResources(this.btnPatientInfo, "btnPatientInfo");
            this.btnPatientInfo.BackgroundImage = null;
            this.btnPatientInfo.Font = null;
            this.btnPatientInfo.ImageIndex = 4;
            this.btnPatientInfo.ImageList = this.ImageList;
            this.btnPatientInfo.Name = "btnPatientInfo";
            this.btnPatientInfo.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnPatientInfo.Click += new System.EventHandler(this.btnPatientInfo_Click);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Font = null;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.dtpQueryDate);
            this.xPanel3.Controls.Add(this.tabOut);
            this.xPanel3.Controls.Add(this.lbQueryDate);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // dtpQueryDate
            // 
            this.dtpQueryDate.AccessibleDescription = null;
            this.dtpQueryDate.AccessibleName = null;
            resources.ApplyResources(this.dtpQueryDate, "dtpQueryDate");
            this.dtpQueryDate.BackgroundImage = null;
            this.dtpQueryDate.Font = null;
            this.dtpQueryDate.Name = "dtpQueryDate";
            this.dtpQueryDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpQueryDate_DataValidating);
            // 
            // tabOut
            // 
            this.tabOut.AccessibleDescription = null;
            this.tabOut.AccessibleName = null;
            resources.ApplyResources(this.tabOut, "tabOut");
            this.tabOut.BackgroundImage = null;
            this.tabOut.Font = null;
            this.tabOut.IDEPixelArea = true;
            this.tabOut.IDEPixelBorder = false;
            this.tabOut.ImageList = this.ImageList;
            this.tabOut.Name = "tabOut";
            this.tabOut.SelectedIndex = 0;
            this.tabOut.SelectedTab = this.tpgOUT0106;
            this.tabOut.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tpgOUT0106});
            this.tabOut.SelectionChanged += new System.EventHandler(this.tabOut_SelectionChanged);
            // 
            // tpgOUT0106
            // 
            this.tpgOUT0106.AccessibleDescription = null;
            this.tpgOUT0106.AccessibleName = null;
            resources.ApplyResources(this.tpgOUT0106, "tpgOUT0106");
            this.tpgOUT0106.BackgroundImage = null;
            this.tpgOUT0106.Controls.Add(this.grdList);
            this.tpgOUT0106.Font = null;
            this.tpgOUT0106.Name = "tpgOUT0106";
            // 
            // grdList
            // 
            resources.ApplyResources(this.grdList, "grdList");
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdList.ColPerLine = 2;
            this.grdList.Cols = 3;
            this.grdList.ExecuteQuery = null;
            this.grdList.FixedCols = 1;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(21);
            this.grdList.Name = "grdList";
            this.grdList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdList.ParamList")));
            this.grdList.QuerySQL = resources.GetString("grdList.QuerySQL");
            this.grdList.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdList.RowHeaderVisible = true;
            this.grdList.Rows = 2;
            this.grdList.ToolTipActive = true;
            this.grdList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.CellLen = 50;
            this.xEditGridCell1.CellName = "comments";
            this.xEditGridCell1.CellWidth = 789;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell2.CellName = "ser";
            this.xEditGridCell2.CellWidth = 50;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.CellLen = 9;
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.CellWidth = 59;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "display_yn";
            this.xEditGridCell4.CellWidth = 71;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.InitValue = "N";
            // 
            // lbQueryDate
            // 
            this.lbQueryDate.AccessibleDescription = null;
            this.lbQueryDate.AccessibleName = null;
            resources.ApplyResources(this.lbQueryDate, "lbQueryDate");
            this.lbQueryDate.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lbQueryDate.EdgeRounding = false;
            this.lbQueryDate.Font = null;
            this.lbQueryDate.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lbQueryDate.Image = null;
            this.lbQueryDate.Name = "lbQueryDate";
            // 
            // OUT0106U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Name = "OUT0106U00";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OUT0106U00_Closing);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OUT0106U00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT0113)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPatient)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            this.tabOut.ResumeLayout(false);
            this.tpgOUT0106.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region ScreenOpen

        private void OUT0106U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			foreach(IHIS.X.Magic.Controls.TabPage tp in this.tabOut.TabPages)
			{
				tp.ImageIndex = 1;
			}

			if (tabOut.TabPages.Count > 0)
			{
				this.tabOut.SelectedTab.ImageIndex = 0;
			}

			// 값을 받아서 조회함
			if (this.OpenParam != null ) 
			{
				pbxPatient.SetPatientID(this.OpenParam["bunho"].ToString());

				if (this.OpenParam.Contains("naewon_date"))
				{
					if (TypeCheck.IsDateTime(this.OpenParam["naewon_date"].ToString()))
						this.dtpQueryDate.SetDataValue(this.OpenParam["naewon_date"].ToString());
				}
				else
					this.dtpQueryDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

				// 조회
				Comments_Query();
			}

			// 입원에서 연 경우...
			if (this.Opener != null && this.Opener is XScreen)
			{
				if ( ((XScreen)this.Opener).ScreenID == "INP1001U01" )
				{
					this.mIsWarningForPastData = true;
				}
			}
		
		}

		#endregion

        #region [환자정보 Reques/Receive Event]
        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            if (info != null && !TypeCheck.IsNull(info.BunHo))
            {
                this.pbxPatient.Focus();
                this.pbxPatient.SetPatientID(info.BunHo);
            }
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(this.pbxPatient.BunHo.ToString()))
            {
                return new XPatientInfo(this.pbxPatient.BunHo.ToString(), "", "", "", this.ScreenName);
            }

            return null;
        }
        #endregion

		#region [     PatientBox 관련    ]

		#region 환자번호 입력 후
		private void pbxPatient_PatientSelected(object sender, System.EventArgs e)
		{
			Comments_Query();
		}
		#endregion

		#region 환자번호 입력 실패시
		private void pbxPatient_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			tabOut.SelectedTab.TabIndex = 0;
			grdList.Reset();
			grdOUT0113.Reset();
		}
		#endregion

		#endregion

		#region [버튼 리스트 관련 컨트롤 및 함수(조회, 입력, 저장, 삭제, 초기화)]
		
		#region 조회
		/// <summary>
		/// 환자의 참고사항을 조회한다.
		/// </summary>
		/// <param name="codeMode"></param>
		/// <returns>void</returns>
		private void Comments_Query()
        {
            this.gridListResult = this.GetGroupedGridListResult(this.pbxPatient.BunHo, this.dtpQueryDate.GetDataValue());
			if(!this.grdList.QueryLayout(false))
			{
				SetMsg(Service.ErrFullMsg.ToString(), MsgType.Error);
				return;
			}

			if(!this.grdOUT0113.QueryLayout(false))
			{
				SetMsg(Service.ErrFullMsg, MsgType.Error);
				return;
			}
		}

		private void PatientInfo_Query ()
        {
            this.grdOUT0113.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.grdOUT0113.SetBindVarValue("f_bunho"      , this.pbxPatient.BunHo);
			
			if (this.OpenParam.Contains("naewon_date"))
			{
				this.grdOUT0113.SetBindVarValue("f_naewon_date", this.OpenParam["naewon_date"].ToString());
			}

			if(!this.grdOUT0113.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg + " : grdOUT0113 Query Error");
				return;
			}
		}
		#endregion

	
		#region 입력
		/// <summary>
		/// 참고사항을 입력한다(Row Insert)
		/// </summary>
		/// <param name="codeMode"></param>
		/// <remarks>참고사항이 빈칸인 경우 insert하지 않고 포커스를 해당 컬럼으로 이동시킴</remarks>
		/// <returns>void</returns>
		private void Comments_Insert()
		{
			string bunho = pbxPatient.BunHo.ToString();
			
			
			if (bunho.Length <= 0 || TypeCheck.IsNull(bunho.ToString()) == true)
			{
				return;
			}

			if (tabOut.SelectedTab.Name == "tpgOUT0106")
			{
				grdList.Focus();
				for (int i = 0; i < grdList.RowCount; i++)
				{
					// 참고사항이 Null인 경우 해당Row로 focus 이동
					if (grdList.GetItemString(i, "comments").ToString().Trim().Length <= 0)
					{
						grdList.SetFocusToItem(i, "comments");
						return;
					}
				}
				// 적용일자가 모두 있으면 insertrow
				grdList.InsertRow(-1);
				grdList.SetItemValue(grdList.CurrentRowNumber, "bunho", bunho);
				grdList.AcceptData();
				grdList.SetFocusToItem(grdList.CurrentRowNumber, "comments");
			}
			else
			{
				grdOUT0113.Focus();
				for (int i = 0; i < grdOUT0113.RowCount; i++)
				{
					// 참고사항이 Null인 경우 해당Row로 focus 이동
					if (TypeCheck.IsNull(grdOUT0113.GetItemString(i, "patient_info").ToString()) == true)
					{
						grdOUT0113.SetFocusToItem(i, "patient_info");
						return;
					}

					if (TypeCheck.IsNull(grdOUT0113.GetItemString(i, "start_date").ToString()) == true)
					{
						grdOUT0113.SetFocusToItem(i, "start_date");
						return;
					}

				}
				// 적용일자가 모두 있으면 insertrow
				grdOUT0113.InsertRow(-1);
				grdOUT0113.SetItemValue(grdOUT0113.CurrentRowNumber, "bunho", bunho);
				
				// start일자는 화면의 XDatePicker의 일자
				this.grdOUT0113.SetItemValue(grdOUT0113.CurrentRowNumber, "start_date", this.dtpQueryDate.GetDataValue());

				//grdOUT0113.AcceptData();
				grdOUT0113.SetFocusToItem(grdOUT0113.CurrentRowNumber, "patient_info");

			}			
		}
		#endregion

		#region 저장

        
		private bool  Comments_Save()
		{
            if (pbxPatient.BunHo.Trim().Length <= 0) return true;

			//grdList.AcceptData();
			// 저장전에 데이터 체크
			for (int i = 0; i < grdList.RowCount; i++)
			{
				// 적용일자가 Null인 경우 해당Row로 focus 이동
				if (grdList.GetItemString(i, "comments").ToString().Trim().Length <= 0)
				{
				    string msg = (i + 1) + Resources.MSG_001;
				    string title = Resources.CAP_001;

					XMessageBox.Show(msg, title);
					grdList.SetFocusToItem(i, "comments");
					return false;
				}

				// Insert시 환자번호 체크
				if(this.grdList.GetRowState(i) == DataRowState.Added)
				{
					if(this.grdList.GetItemString(i, "bunho").ToString() == "")
					{
						XMessageBox.Show(Resources.MSG_002);
                        return false;
					}
				}
				// Update, Delete시 환자번호와 순번 체크
				else if((this.grdList.GetRowState(i) == DataRowState.Modified)||
					(this.grdList.GetRowState(i) == DataRowState.Deleted))
				{
					if(this.grdList.GetItemString(i, "bunho").ToString() == "")
					{
						XMessageBox.Show(Resources.MSG_002);
                        return false;
					}
					
                    //if(this.grdList.GetItemString(i, "ser").ToString() == "")
                    //{
                    //    XMessageBox.Show("順番がありません。");
                    //    return false;
                    //}
				}

				// 삭제인 경우는 체크하지 않음
				if (grdList.GetRowState(i) != DataRowState.Deleted)
				{
					//					// 승인일자가 Null인 경우 해당Row로 focus 이동
					//					if (grdList.GetItemValue(i, "ser").ToString().Trim().Length <= 0)
					//					{
					//						string msg = (NetInfo.Language == LangMode.Ko ? "순번을 입력하십시오!!!"
					//							: "??コ?ドを入力してください!!!");
					//						string title = (NetInfo.Language == LangMode.Ko ? "순번 오류!!!"
					//							: "??コ?ドを入力してください!!!");
					//
					//						XMessageBox.Show(msg, title);
					//						grdList.SetFocusToItem(i, "comments");
					//						return;
					//					}

					//					XMessageBox.Show(grdList.GetItemString(i, "bunho").ToString());
					// 보험회사가 Null인 경우 해당Row로 focus 이동
					if (TypeCheck.IsNull(grdList.GetItemValue(i, "bunho")) == true)
						//if (grdList.GetItemString(i, "bunho").ToString().Trim().Length <= 0)
					{
					    string msg = Resources.MSG_003;
						string title = Resources.CAP_001;

						XMessageBox.Show(msg, title);
						grdList.SetFocusToItem(i, "comments");
                        return false;
					}				
				}
			}

			for(int i=0; i < this.grdOUT0113.RowCount; i++)
			{
				if(this.grdOUT0113.GetRowState(i) == DataRowState.Added)
				{
					if(this.grdOUT0113.GetItemString(i, "bunho").ToString() == "")
					{
						XMessageBox.Show(Resources.MSG_002);
                        return false;
					}

					if(this.grdOUT0113.GetItemString(i, "patient_info").ToString() == "")
					{
						XMessageBox.Show(Resources.MSG_004);
                        return false;
					}

					if(this.grdOUT0113.GetItemString(i, "start_date").ToString() == "")
					{
						XMessageBox.Show(Resources.MSG_005);
                        return false;
					}
				}
			}

//			try
//			{
//				Service.BeginTransaction();
//
//				if(!this.grdList.SaveLayout())
//				{
//					Service.RollbackTransaction();
//					XMessageBox.Show(Resources.MSG_006_1 + Service.ErrFullMsg.ToString(), Resources.MSG_006_2);
//					SetMsg(Service.ErrFullMsg.ToString(), MsgType.Error);
//                    return false;
//				}
//
//				if(!this.grdOUT0113.SaveLayout())
//				{
//					Service.RollbackTransaction();
//					XMessageBox.Show(Service.ErrFullMsg.ToString(), "grdOUT0113 Save Error");
//					SetMsg(Service.ErrFullMsg.ToString(), MsgType.Error);
//                    return false;
//				}
//
//				Service.CommitTransaction();
//
//			    mbxMsg = Resources.MSG_007;
//				mbxCap = Resources.CAP_007;
//				//XMessageBox.Show(mbxMsg, mbxCap);
//			}
//			catch(Exception ex)
//			{
//				Service.RollbackTransaction();
//				XMessageBox.Show("ButtonList Update CommitTransaction "+ex.Message);
//                return false;
//			}

            if (!this.SaveGridData())
            {
                mIsSaveSuccess = false;
                XMessageBox.Show("ButtonList Update CommitTransaction");
                return false;
            }

			// 저장후 조회
			Comments_Query();
            return true;

		}
		#endregion

		#region 삭제
		private void Comments_Delete()
		{
			if (this.tabOut.SelectedTab.Name == "tpgOUT0106")
			{
				if (grdList.RowCount <= 0) return;
			
				grdList.DeleteRow(grdList.CurrentRowNumber);
			}
			else
			{
				if (grdOUT0113.RowCount <= 0) return;
			
				grdOUT0113.DeleteRow(grdOUT0113.CurrentRowNumber);
			}
		}
		#endregion


		#region 버튼 클릭시
        private bool mIsSaveSuccess = true;
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					Comments_Query();
					break;
				case FunctionType.Insert:
					e.IsBaseCall = false;
					Comments_Insert();
					break;
				case FunctionType.Update:
					e.IsBaseCall = false;
                    mIsSaveSuccess = true;

                    if (!Comments_Save())
                        mIsSaveSuccess = false;
                    else
                        this.Close();

					break;
				case FunctionType.Delete:
					e.IsBaseCall = false;
					Comments_Delete();
					break;

				default:
					break;
			}
		}
		#endregion

		#endregion

		#region 탭 클릭시
		private void tabOut_SelectionChanged(object sender, System.EventArgs e)
		{
			foreach(IHIS.X.Magic.Controls.TabPage tp in this.tabOut.TabPages)
			{
				if (tp == this.tabOut.SelectedTab)
				{
					tp.ImageIndex = 0;

					if (tp.Name == "tpgOUT0113")
					{
						this.lbQueryDate.Visible  = true;
						this.dtpQueryDate.Visible = true;
					}
					else
					{
						this.lbQueryDate.Visible  = false;
						this.dtpQueryDate.Visible = false;
					}
				}
				else
				{
					tp.ImageIndex = 1;
				}
			}
		}
		#endregion

		#region XEdit Grid

		#region OUT0113 Gird

		private void grdOUT0113_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
			switch (e.ColName)
			{
				case "patient_info":

                    this.fwkFind.InputSQL = @"SELECT A.PATIENT_INFO
                                                    , A.PATIENT_INFO_NAME
                                                    , A.PATIENT_INFO || TO_CHAR(A.START_DATE, 'YYYY/MM/DD')    CONT_KEY
                                                FROM OUT0112 A
                                                WHERE A.HOSP_CODE = :f_hosp_code 
                                                AND A.PATIENT_INFO LIKE :f_find1 || '%'
                                                AND NVL(:f_naewon_date, TRUNC(SYSDATE)) BETWEEN A.START_DATE AND NVL(A.END_DATE, '9998/12/31')
                                                ORDER BY CONT_KEY";

					if(this.OpenParam.Contains("naewon_date"))
                    {
                        this.fwkFind.BindVarList.Add("f_naewon_date", this.OpenParam["naewon_date"].ToString());
                    }
                    this.fwkFind.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

					this.fwkFind.ColInfos.Clear();
					this.fwkFind.ColInfos.Add("patient_info", Resources.FWK_COL_PATIENT_INFO, FindColType.String, 80, 0, true, FilterType.No);
					this.fwkFind.ColInfos.Add("patient_info_name", Resources.FWK_COL_PATIENT_NAME, FindColType.String, 200, 0, true, FilterType.InitYes);
					this.fwkFind.ColInfos[0].ColAlign = HorizontalAlignment.Center;

					break;
			}
		}

		private void grdOUT0113_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			switch (e.ColName)
			{
				case "patient_info" :

					#region 각종정보

					if (e.ChangeValue.ToString() == "")
					{
						this.grdOUT0113.SetItemValue(e.RowNumber, "patient_info_name", "");
						this.SetMsg("");
						return;
					}

                    string cmdText = @"SELECT A.PATIENT_INFO_NAME
                                         FROM OUT0112 A
                                        WHERE A.HOSP_CODE    = :f_hosp_code
                                          AND A.PATIENT_INFO = :f_patient_info
                                          AND NVL(:f_naewon_date, TRUNC(SYSDATE)) BETWEEN A.START_DATE AND NVL(A.END_DATE, '9998/12/31')";

					BindVarCollection bindVars = new BindVarCollection();

                    bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
					bindVars.Add("f_patient_info", e.ChangeValue.ToString());
					if(this.OpenParam.Contains("naewon_date"))
					{
						bindVars.Add("f_naewon_date", this.OpenParam["naewon_date"].ToString());
					}

					object retVal = Service.ExecuteScalar(cmdText, bindVars);
					if(retVal == null)
					{
						XMessageBox.Show(Resources.MSG_008);
						e.Cancel = true;

						return;
					}
					else
					{
						this.grdOUT0113.SetItemValue(e.RowNumber, "patient_info_name", retVal.ToString());
					}

					#endregion

					break;

				case "start_date" :

					#region 시작일자 

					if (e.ChangeValue.ToString() == "" || !TypeCheck.IsDateTime(e.ChangeValue.ToString()))
					{
						this.SetMsg("");
						return;
					}

					DateTime startDate = DateTime.Parse(e.ChangeValue.ToString());
					string sSystemDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

					if (sSystemDate == "" || !TypeCheck.IsDateTime(sSystemDate))
					{
						return;
					}

					DateTime systemDate = DateTime.Parse(sSystemDate);

					if (startDate < systemDate)
					{
						this.mbxMsg = Resources.MSG_009;
						this.mbxCap = Resources.MSG_010;

						XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}

					#endregion
					
					break;
			}
		}

		#endregion

		#endregion

		#region XButton

		private void btnPatientInfo_Click(object sender, System.EventArgs e)
		{
			if (this.OpenParam.Contains("naewon_date"))
			{
				CommonItemCollection param = new CommonItemCollection();

				param.Add("naewon_date", this.OpenParam["naewon_date"].ToString());

				XScreen.OpenScreenWithParam(this, "NURO", "OUT0112U00", ScreenOpenStyle.ResponseFixed, param);
			}

			else
			{
				XScreen.OpenScreen(this, "OUT0112U00", ScreenOpenStyle.ResponseFixed);
			}
		}

		#endregion

		#region XDatePicker

		#region 조회일자 

		private void dtpQueryDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			PostCallHelper.PostCall(new PostMethod(PostValidating));
		}

		private void PostValidating()
		{
			this.Comments_Query();
		}

		#endregion

		#endregion
		
		#region 저장로직
		private class XSavePerformer : IHIS.Framework.ISavePerformer
		{
			private OUT0106U00 parent = null;

			public XSavePerformer(OUT0106U00 parent)
			{
				this.parent = parent;
			}

			public bool Execute(char callerID, RowDataItem item)
			{
				string cmdQry = null;

                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
				item.BindVarList.Add("f_user_id", UserInfo.UserID);

				if(callerID == '1')
				{
					switch(item.RowState)
					{
						case DataRowState.Added:

                            string cmdText = @"SELECT NVL(MAX(SER), 0) + 1 SER
                                                 FROM OUT0106
                                                WHERE HOSP_CODE = :f_hosp_code
                                                  AND BUNHO = :f_bunho";

                            BindVarCollection bindVars = new BindVarCollection();
                            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
							bindVars.Add("f_bunho", parent.grdList.GetItemString(parent.grdList.CurrentRowNumber, "bunho").ToString());

							object retVal = Service.ExecuteScalar(cmdText, bindVars);
							if(retVal == null)
							{
								XMessageBox.Show(Service.ErrFullMsg + Resources.MSG_011);
								return false;
							}
							else
							{
								item.BindVarList.Add("f_ser1", retVal.ToString());
							}

							cmdQry = @"INSERT INTO OUT0106( SYS_DATE		, SYS_ID    	, UPD_DATE  , UPD_ID
                                                          , HOSP_CODE       , COMMENTS		, SER		, BUNHO
														  , DISPLAY_YN      , CMMT_GUBUN    )
													VALUES( SYSDATE 		, :f_user_id    , SYSDATE   , :f_user_id
                                                          , :f_hosp_code    , :f_comments   , :f_ser1	, :f_bunho
														  , :f_display_yn   , 'B' )";
                            /*
                             * 1. 환자별 코멘트(특이사항)
                                  CMMT_GUBUN : 'B'
                                  - 환자별 특이사항 등록시 해당 파라미터를 'B'로 셋팅하면 됨
                               2. 환자별 파트별 코멘트(특이사항)
                                  CMMT_GUBUN : 'P'
                                  - 환자별 파트별(각 부문 실시 파트 혹은 무브 파트별)로 등록 가능함
                               3. 환자별 오더별 코멘트(특이사항)
                                  CMMT_GUBUN : 'O'

                             * */
                            break;

						case DataRowState.Modified:

							cmdQry = @"UPDATE OUT0106
										  SET UPD_ID          = :f_user_id
											, UPD_DATE        = SYSDATE
											, COMMENTS        = :f_comments
											, DISPLAY_YN      = :f_display_yn
										WHERE HOSP_CODE       = :f_hosp_code 
                                          AND BUNHO           = :f_bunho
										  AND SER             = :f_ser";
							break;

						case DataRowState.Deleted:

							cmdQry = @"DELETE FROM OUT0106
										WHERE HOSP_CODE       = :f_hosp_code 
                                          AND BUNHO           = :f_bunho
										  AND SER             = :f_ser";
							break;
					}
				}
				else if(callerID == '2')
				{
					switch(item.RowState)
					{
						case DataRowState.Added:

                            string cmdText1 = @"SELECT 'Y'
                                                 FROM DUAL
                                                WHERE EXISTS ( SELECT 'X'
                                                                 FROM OUT0112 A
                                                                WHERE A.HOSP_CODE    = :f_hosp_code 
                                                                  AND A.PATIENT_INFO = :f_patient_info
                                                                  AND :f_start_date BETWEEN A.START_DATE AND NVL(A.END_DATE, '9998/12/31'))";

                            BindVarCollection bindVars1 = new BindVarCollection();
                            bindVars1.Add("f_hosp_code", EnvironInfo.HospCode);
							bindVars1.Add("f_patient_info", parent.grdOUT0113.GetItemString(parent.grdOUT0113.CurrentRowNumber, "patient_info").ToString());
							bindVars1.Add("f_start_date"  , parent.grdOUT0113.GetItemString(parent.grdOUT0113.CurrentRowNumber, "start_date").ToString());

							object retVal1 = Service.ExecuteScalar(cmdText1, bindVars1);
							if(retVal1 == null)
							{
							}
							else
							{
								if(retVal1.ToString() != "Y")
								{
									XMessageBox.Show(Resources.MSG_012);
									return false;
								}
							}

							cmdText1 = string.Empty;
                            cmdText1 = @"SELECT 'Y'
                                          FROM DUAL
                                         WHERE EXISTS ( SELECT 'X'
                                                          FROM OUT0113 A
                                                         WHERE A.HOSP_CODE = :f_hosp_code 
                                                           AND A.BUNHO = :f_bunho
                                                           AND A.PATIENT_INFO = :f_patient_info
                                                           AND A.START_DATE >= :f_start_date    )";


							object retVal2 = Service.ExecuteScalar(cmdText1, item.BindVarList);
							if(retVal2 == null)
							{
							}
							else 
							{
								if(retVal2.ToString() == "Y")
								{
                                    XMessageBox.Show(Resources.MSG_013 + item.BindVarList["f_bunho"].VarValue + ", 「" + item.BindVarList["f_patient_info"].VarValue + "」");
									return false;
								}
							}

							cmdQry = @"BEGIN
									   UPDATE OUT0113
										  SET END_DATE = TO_DATE(:f_start_date, 'YYYY/MM/DD') - 1
										WHERE HOSP_CODE = :f_hosp_code 
                                          AND BUNHO = :f_bunho
										  AND PATIENT_INFO = :f_patient_info
										  AND(END_DATE IS NULL OR END_DATE = TO_DATE('9998/12/31', 'YYYY/MM/DD'));
										                        
										INSERT INTO OUT0113
											( SYS_DATE
											, SYS_ID
											, UPD_DATE
                                            , UPD_ID
                                            , HOSP_CODE 
											, BUNHO
											, PATIENT_INFO
											, START_DATE
											, END_DATE
											, COMMENTS    )
										VALUES(SYSDATE
											, :f_user_id
											, SYSDATE
											, :f_user_id
                                            , :f_hosp_code 
											, :f_bunho
											, :f_patient_info
											, :f_start_date
											, :f_end_date
											, :f_comment );
									   END;";

							cmdQry = cmdQry.Replace("\r", " ");

							break;

						case DataRowState.Modified:

							cmdQry = @"UPDATE OUT0113
										  SET COMMENTS     = :f_comment
											, END_DATE     = :f_end_date
										WHERE HOSP_CODE = :f_hosp_code 
                                          AND BUNHO        = :f_bunho
										  AND PATIENT_INFO = :f_patient_info
										  AND START_DATE   = :f_start_date";

							break;

						case DataRowState.Deleted:

							cmdQry = @"BEGIN
									   UPDATE OUT0113
										  SET END_DATE = NULL
										WHERE HOSP_CODE = :f_hosp_code 
                                          AND BUNHO = :f_bunho
										  AND PATIENT_INFO = :f_patient_info
										  AND END_DATE = TO_DATE(:f_start_date, 'YYYY/MM/DD') - 1;
											    
									   DELETE FROM OUT0113
										WHERE HOSP_CODE = :f_hosp_code 
                                          AND BUNHO = :f_bunho
										  AND PATIENT_INFO = :f_patient_info
										  AND START_DATE   = :f_start_date;
									   END;";

							cmdQry = cmdQry.Replace("\r", " ");

							break;
					}
				}
				return Service.ExecuteNonQuery(cmdQry, item.BindVarList);
			}
		}
		#endregion

        private void OUT0106U00_Closing(object sender, CancelEventArgs e)
        {
            if (!this.mIsSaveSuccess)
                e.Cancel = true;

            this.mIsSaveSuccess = true;
        }

        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {

            this.grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdList.SetBindVarValue("f_bunho", this.pbxPatient.BunHo);
        }

        private void grdOUT0113_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOUT0113.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOUT0113.SetBindVarValue("f_bunho", this.pbxPatient.BunHo);
            this.grdOUT0113.SetBindVarValue("f_naewon_date", this.dtpQueryDate.GetDataValue());
        }

        private OUT0106U00GridListResult GetGroupedGridListResult(String bunho, String naewonDate)
        {
            // set arguments
            OUT0106U00GridListArgs gridListArgs = new OUT0106U00GridListArgs();
            gridListArgs.Bunho = bunho;
            gridListArgs.NaewonDate = naewonDate;
            // get results
            OUT0106U00GridListResult result =
                CloudService.Instance.Submit<OUT0106U00GridListResult, OUT0106U00GridListArgs>(gridListArgs);
	        return result;
        }

        private IList<object[]> GetGridList(BindVarCollection list)
        {
            List<object[]> gridList = null;
            if (gridListResult != null)
            {
                gridList = new List<object[]>();
                IList<OUT0106U00GridItemInfo> gridItemInfos = gridListResult.GridItemInfo;
                foreach (OUT0106U00GridItemInfo item in gridItemInfos)
                {
                    gridList.Add(new object[]
                    {
                        item.Comments,
                        item.Ser,
                        item.Bunho,
                        item.DisplayYn
                    });
                }
            }
            return gridList;
        }

        private IList<object[]> GetPatientCommentList(BindVarCollection list)
        {
            List<object[]> patientCommentList = null;
            if (gridListResult != null)
            {
                patientCommentList = new List<object[]>();
                IList<OUT0106U00PatientCommentItemInfo> patientCommentItemInfos = gridListResult.PatientCommentItemInfo;
                foreach (OUT0106U00PatientCommentItemInfo item in patientCommentItemInfos)
                {
                    patientCommentList.Add(new object[]
                    {
                        item.PatientInfo,
                        item.PatientInfoName,
                        item.StartDate,
                        item.EndDate,
                        item.Comments,
                        item.Bunho,
                        item.ContKey
                    });
                }
            }
            return patientCommentList;
        }

	    private bool SaveGridData()
	    {
	        OUT0106U00SaveCommentsArgs args = new OUT0106U00SaveCommentsArgs();
            args.GridItemInfo = CreateGridItemInfosFromGrid();
            args.PatientCommentItemInfo = CreatePatientCommentItemInfosFromGrid();
            args.UserId = UserInfo.UserID;
	        UpdateResult result = CloudService.Instance.Submit<UpdateResult, OUT0106U00SaveCommentsArgs>(args);
	        return result.Result;
	    }

	    private List<OUT0106U00GridItemInfo> CreateGridItemInfosFromGrid()
	    {
	        List<OUT0106U00GridItemInfo> gridItemInfos = new List<OUT0106U00GridItemInfo>();
	        for (int i = 0; i < grdList.RowCount; i++)
	        {
                OUT0106U00GridItemInfo gridItemInfo = new OUT0106U00GridItemInfo();
                gridItemInfo.Comments = grdList.GetItemString(i, "comments");
                gridItemInfo.Ser = grdList.GetItemString(i, "ser");
                gridItemInfo.Bunho = grdList.GetItemString(i, "bunho");
                gridItemInfo.DisplayYn = grdList.GetItemString(i, "display_yn");
                gridItemInfo.DataRowState = grdList.GetRowState(i).ToString();
                
                gridItemInfos.Add(gridItemInfo);
	        }
            // add deleted list
            if (grdList.DeletedRowCount != 0)
            {
                foreach (DataRow row in this.grdList.DeletedRowTable.Rows)
                {
                    OUT0106U00GridItemInfo gridItemInfo = new OUT0106U00GridItemInfo();
                    gridItemInfo.Bunho = row["bunho"].ToString();
                    gridItemInfo.Ser = row["ser"].ToString();
                    gridItemInfo.DataRowState = DataRowState.Deleted.ToString();
                    gridItemInfos.Add(gridItemInfo);
                }
            }
	        return gridItemInfos;
	    }

	    private List<OUT0106U00PatientCommentItemInfo> CreatePatientCommentItemInfosFromGrid()
	    {
	        List<OUT0106U00PatientCommentItemInfo> patientCommentItemInfos = new List<OUT0106U00PatientCommentItemInfo>();
	        for (int i = 0; i < grdOUT0113.RowCount; i++)
	        {
	            OUT0106U00PatientCommentItemInfo patientCommentItemInfo = new OUT0106U00PatientCommentItemInfo();
                patientCommentItemInfo.PatientInfo = grdOUT0113.GetItemString(i, "patient_info");
                patientCommentItemInfo.PatientInfoName = grdOUT0113.GetItemString(i, "patient_info_name");
                patientCommentItemInfo.StartDate = grdOUT0113.GetItemString(i, "start_date");
                patientCommentItemInfo.EndDate = grdOUT0113.GetItemString(i, "end_date");
                patientCommentItemInfo.Comments = grdOUT0113.GetItemString(i, "comments");
                patientCommentItemInfo.Bunho = grdOUT0113.GetItemString(i, "bunho");
                patientCommentItemInfo.ContKey = grdOUT0113.GetItemString(i, "cont_key");
                patientCommentItemInfo.DataRowState = grdOUT0113.GetRowState(i).ToString();

                patientCommentItemInfos.Add(patientCommentItemInfo);
	        }
            // add deleted list
            if (grdOUT0113.DeletedRowCount != 0)
            {
                foreach (DataRow row in this.grdOUT0113.DeletedRowTable.Rows)
                {
                    OUT0106U00PatientCommentItemInfo patientCommentItemInfo = new OUT0106U00PatientCommentItemInfo();
                    patientCommentItemInfo.Bunho = row["bunho"].ToString();
                    patientCommentItemInfo.PatientInfo = row["patient_info"].ToString();
                    patientCommentItemInfo.StartDate = row["start_date"].ToString();
                    patientCommentItemInfo.DataRowState = DataRowState.Deleted.ToString();
                    patientCommentItemInfos.Add(patientCommentItemInfo);
                }
            }
	        return patientCommentItemInfos;
	    }
	}
}

