#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.BASS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
#endregion

namespace IHIS.BASS
{
	/// <summary>
	/// BAS0210U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0210U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPanel panel1;
        private IHIS.Framework.XDatePicker dtpApplyDate;
        private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XEditGrid grdBAS0210;
		private IHIS.Framework.XLabel xLabel18;
		private IHIS.Framework.XFindBox fbxSearchGubun;
        private IHIS.Framework.XDisplayBox dbxSearchGubunName;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.SingleLayout layCommon;
		private IHIS.Framework.SingleLayout layDupCheck;
        private System.Windows.Forms.PictureBox pictureBox1;
		private IHIS.Framework.XPanel xPanel1;
        private XFindWorker fwkCommon;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XGridHeader xGridHeader1;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BAS0210U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            // Create ParamList and ExecuteQuery
            this.grdBAS0210.ParamList = new List<string>(new String[] { "f_gubun_code", "f_start_date" });
		    this.grdBAS0210.ExecuteQuery = ExecuteQueryGrdBAS0210;

            this.fwkCommon.ParamList = new List<string>(new String[] { "f_find" });
		    this.fwkCommon.ExecuteQuery = ExecuteQueryFwkCommon;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0210U00));
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdBAS0210 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.panel1 = new IHIS.Framework.XPanel();
            this.dbxSearchGubunName = new IHIS.Framework.XDisplayBox();
            this.fbxSearchGubun = new IHIS.Framework.XFindBox();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dtpApplyDate = new IHIS.Framework.XDatePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.layDupCheck = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1 = new IHIS.Framework.XPanel();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0210)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdBAS0210
            // 
            this.grdBAS0210.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdBAS0210, "grdBAS0210");
            this.grdBAS0210.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15});
            this.grdBAS0210.ColPerLine = 7;
            this.grdBAS0210.Cols = 7;
            this.grdBAS0210.ExecuteQuery = null;
            this.grdBAS0210.FixedRows = 2;
            this.grdBAS0210.HeaderHeights.Add(21);
            this.grdBAS0210.HeaderHeights.Add(0);
            this.grdBAS0210.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdBAS0210.Name = "grdBAS0210";
            this.grdBAS0210.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBAS0210.ParamList")));
            this.grdBAS0210.QuerySQL = resources.GetString("grdBAS0210.QuerySQL");
            this.grdBAS0210.Rows = 3;
            this.grdBAS0210.ToolTipActive = true;
            this.grdBAS0210.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdBAS0210_GridFindSelected);
            this.grdBAS0210.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdBAS0210_GridColumnChanged);
            this.grdBAS0210.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdBAS0210_RowFocusChanged);
            this.grdBAS0210.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBAS0210_QueryStarting);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 2;
            this.xEditGridCell6.CellName = "gubun";
            this.xEditGridCell6.CellWidth = 56;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.RowSpan = 2;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 30;
            this.xEditGridCell9.CellName = "gubun_name";
            this.xEditGridCell9.CellWidth = 168;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.RowSpan = 2;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "retrieve_yn";
            this.xEditGridCell10.CellWidth = 30;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "start_date";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.CellWidth = 95;
            this.xEditGridCell11.Col = 3;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.RowSpan = 2;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "end_date";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell12.CellWidth = 95;
            this.xEditGridCell12.Col = 4;
            this.xEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.RowSpan = 2;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 2;
            this.xEditGridCell13.CellName = "johap_gubun";
            this.xEditGridCell13.CellWidth = 49;
            this.xEditGridCell13.Col = 5;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.Row = 1;
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkCommon.ExecuteQuery = null;
            this.fwkCommon.FormText = global::IHIS.BASS.Properties.Resource.fwkCommonFormText;
            this.fwkCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCommon.ParamList")));
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkCommon.ServerFilter = true;
            this.fwkCommon.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkCommon_QueryStarting);
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "code";
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "code_name";
            this.findColumnInfo4.ColWidth = 180;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "johap_gubun_name";
            this.xEditGridCell14.CellWidth = 90;
            this.xEditGridCell14.Col = 6;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.Row = 1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "gongbi_yn";
            this.xEditGridCell15.CellWidth = 57;
            this.xEditGridCell15.Col = 2;
            this.xEditGridCell15.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.RowSpan = 2;
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "Y";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "N";
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 5;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 49;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 216;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackgroundImage = null;
            this.panel1.Controls.Add(this.dbxSearchGubunName);
            this.panel1.Controls.Add(this.fbxSearchGubun);
            this.panel1.Controls.Add(this.xLabel18);
            this.panel1.Controls.Add(this.xLabel1);
            this.panel1.Controls.Add(this.dtpApplyDate);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // dbxSearchGubunName
            // 
            this.dbxSearchGubunName.AccessibleDescription = null;
            this.dbxSearchGubunName.AccessibleName = null;
            resources.ApplyResources(this.dbxSearchGubunName, "dbxSearchGubunName");
            this.dbxSearchGubunName.Image = null;
            this.dbxSearchGubunName.Name = "dbxSearchGubunName";
            // 
            // fbxSearchGubun
            // 
            this.fbxSearchGubun.AccessibleDescription = null;
            this.fbxSearchGubun.AccessibleName = null;
            resources.ApplyResources(this.fbxSearchGubun, "fbxSearchGubun");
            this.fbxSearchGubun.BackgroundImage = null;
            this.fbxSearchGubun.FindWorker = this.fwkCommon;
            this.fbxSearchGubun.Name = "fbxSearchGubun";
            this.fbxSearchGubun.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            // 
            // xLabel18
            // 
            this.xLabel18.AccessibleDescription = null;
            this.xLabel18.AccessibleName = null;
            resources.ApplyResources(this.xLabel18, "xLabel18");
            this.xLabel18.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel18.EdgeRounding = false;
            this.xLabel18.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel18.Image = null;
            this.xLabel18.Name = "xLabel18";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // dtpApplyDate
            // 
            this.dtpApplyDate.AccessibleDescription = null;
            this.dtpApplyDate.AccessibleName = null;
            resources.ApplyResources(this.dtpApplyDate, "dtpApplyDate");
            this.dtpApplyDate.BackgroundImage = null;
            this.dtpApplyDate.IsVietnameseYearType = false;
            this.dtpApplyDate.Name = "dtpApplyDate";
            this.dtpApplyDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dptApplyDate_DateValidating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleDescription = null;
            this.pictureBox1.AccessibleName = null;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Font = null;
            this.pictureBox1.ImageLocation = null;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            // 
            // layDupCheck
            // 
            this.layDupCheck.ExecuteQuery = null;
            this.layDupCheck.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2});
            this.layDupCheck.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupCheck.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "dup_yn";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "code_name";
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // BAS0210U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.grdBAS0210);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "BAS0210U00";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.BAS0210U00_Closing);
            this.Load += new System.EventHandler(this.BAS0210U00_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0210)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen_Load

		private void BAS0210U00_Load(object sender, System.EventArgs e)
		{
            this.grdBAS0210.SavePerformer = new XSavePeformer(this);

			this.dtpApplyDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            //this.grdBAS0210.QueryLayout(false);
            this.grdBAS0210.QueryLayout(true);
		}

		#endregion

		private bool DupCheck(string aValue, string aDate)
		{
			if (this.grdBAS0210.DeletedRowTable != null)
			{
				foreach (DataRow dr in grdBAS0210.DeletedRowTable.Rows)
				{
					if (dr["gubun"].ToString() == aValue)
					{
						return false;
					}
				}
			}

			// 현재 그리드에서 찾는다.
			for (int i=0; i<this.grdBAS0210.RowCount; i++)
			{
				if (i != this.grdBAS0210.CurrentRowNumber &&
					this.grdBAS0210.GetItemString(i, "gubun") == aValue &&
                    this.grdBAS0210.GetItemString(i, "start_date") == aDate)
				{
					return true;
				}
			} 

			// DB에서 체크한다.
            // TODO comment use connect to cloud
            /*this.layDupCheck.QuerySQL = @"SELECT 'Y'
                                            FROM BAS0210
                                           WHERE HOSP_CODE   = :f_hosp_code
                                             AND GUBUN       = :f_gubun
                                             AND START_DATE  = :f_start_date";

            this.layDupCheck.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDupCheck.SetBindVarValue("f_gubun", aValue);
            this.layDupCheck.SetBindVarValue("f_start_date", aDate);
			this.layDupCheck.QueryLayout();*/

            // Connect to cloud 
            BAS0210U00DupCheckArgs vBAS0210U00DupCheckArgs = new BAS0210U00DupCheckArgs();
		    vBAS0210U00DupCheckArgs.Gubun = aValue;
		    vBAS0210U00DupCheckArgs.StartDate = aDate;
            BAS0210U00DupCheckResult result = CloudService.Instance.Submit<BAS0210U00DupCheckResult, BAS0210U00DupCheckArgs>(vBAS0210U00DupCheckArgs);
            
//			if (this.layDupCheck.GetItemValue("dup_yn").ToString() == "Y")
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success && result.DupCheck == "Y")
			{
				return true;
			}

			return false;
        }
        private void grdBAS0210_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            string msg = "";
            e.Cancel = false;

            if (e.ChangeValue.ToString() == "")
            {
                this.grdBAS0210.SetItemValue(e.RowNumber, "johap_gubun_name","");
                this.SetMsg(msg);
                return;
            }
            
            switch (e.ColName)
            {
                case "gubun":
                case "start_date":
                    if (this.DupCheck(this.grdBAS0210.GetItemString(e.RowNumber, "gubun"), this.grdBAS0210.GetItemString(e.RowNumber, "start_date")))
                    {
                        msg = (Resource.TEXT1);
                        this.SetMsg(msg, MsgType.Error);
                        e.Cancel = true;
                    }
                    break;
                case "johap_gubun":

                    // TODO comment use connect cloud
                    /*this.layDupCheck.QuerySQL = @"SELECT 'Y', A.CODE_NAME
                                                    FROM BAS0102 A
                                                   WHERE A.HOSP_CODE = :f_hosp_code 
                                                     AND A.CODE_TYPE = 'JOHAP_GUBUN'
                                                     AND A.CODE      = :f_code";*/

                    this.layDupCheck.ParamList = new List<string>(new String[] { "f_code", "f_col_name" });
                    this.layDupCheck.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layDupCheck.SetBindVarValue("f_code", e.ChangeValue.ToString());
                    this.layDupCheck.SetBindVarValue("f_col_name", "johap_gubun");
                    this.layDupCheck.ExecuteQuery = ExecuteQueryGrdBAS0210GridColumnChanged;
                    this.layDupCheck.QueryLayout();

                    if (this.layDupCheck.GetItemValue("dup_yn").ToString() != "Y")
                    {
                        msg = (NetInfo.Language == LangMode.Ko ? "등록되지않은보험구분입니다." : Resource.TEXT2);
                        this.SetMsg(msg, MsgType.Error);
                        e.Cancel = true;
                    }
                    this.grdBAS0210.SetItemValue(e.RowNumber, "johap_gubun_name", this.layDupCheck.GetItemValue("code_name").ToString());
                    break;
            }
        }

		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Reset:
					//this.grdBAS0210.SetItemValue(grdBAS0210.CurrentRowNumber, "gubun_ymd", this.dtpApplyDate.GetDataValue());
					this.dtpApplyDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
					break;
			}
		}
		private void grdBAS0210_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
            //if (this.grdBAS0210.GetItemString(e.CurrentRow, "retrieve_yn") == "Y")
            //{
            //    this.ControlProtect(true);
            //}
            //else
            //{
            //    this.ControlProtect(false);
            //}		
		}

		private void ControlProtect (bool aIsProtect)
		{
            //this.txtGubun.Protect = aIsProtect;
		}

        private void grdBAS0210_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdBAS0210.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdBAS0210.SetBindVarValue("f_gubun_code", this.fbxSearchGubun.GetDataValue());
            this.grdBAS0210.SetBindVarValue("f_start_date", this.dtpApplyDate.GetDataValue());
        }

        private void fbx_DataValidating(object sender, DataValidatingEventArgs e)
        {
            XFindBox control = (XFindBox)sender;
            SingleLayoutItem sli = new SingleLayoutItem();

            this.layCommon.LayoutItems.Clear();

            switch (control.Name)
            {
                case "fbxSearchGubun":
                    /*this.layCommon.QuerySQL = @"SELECT A.CODE_NAME
                                              FROM BAS0102 A
                                             WHERE A.HOSP_CODE   = :f_hosp_code 
                                               AND A.CODE_TYPE   = :f_code_type
                                               AND A.CODE        = :f_code ";*/
                    sli.DataName = "gubun_name";
                    sli.BindControl = this.dbxSearchGubunName;
                    this.layCommon.LayoutItems.Add(sli);

                    this.layCommon.ParamList = new List<string>(new String[] {"f_code", "f_code_type", "f_control_name"});
                    this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layCommon.SetBindVarValue("f_code", fbxSearchGubun.GetDataValue());
                    this.layCommon.SetBindVarValue("f_code_type", "JOHAP_GUBUN");
                    this.layCommon.SetBindVarValue("f_control_name", "fbxSearchGubun");
                    this.layCommon.ExecuteQuery = ExecuteFbxDataValidating;
                    this.layCommon.QueryLayout();
                    //this.grdBAS0210.QueryLayout(false);
                    this.grdBAS0210.QueryLayout(true);
                    break;
            }
        }
       
        private void grdBAS0210_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {
            if (e.ColName == "johap_gubun")
            {
//                this.layCommon.QuerySQL = @"SELECT A.CODE_NAME
//                                                  FROM BAS0102 A 
//                                                 WHERE A.CODE_TYPE = 'JOHAP_GUBUN' 
//                                                   AND A.CODE = :f_code";
//                this.layCommon.LayoutItems.Add("code_name");
//                this.layCommon.SetBindVarValue("f_code", e.ReturnValues[0].ToString());
//                this.layCommon.QueryLayout();
                this.grdBAS0210.SetItemValue(e.RowNumber, "johap_gubun_name", e.ReturnValues[1].ToString());
            }
        }

        string mMsg = "";
        string mCap = "";
        string mCheck = "";
        bool boolSave = true;

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            this.boolSave = true;

            switch (e.Func)
            {
                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    int rowNum = this.grdBAS0210.InsertRow(-1);
                    this.grdBAS0210.SetItemValue(rowNum, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    this.grdBAS0210.SetItemValue(rowNum, "end_date", "9998/12/31");
                    this.grdBAS0210.SetFocusToItem(rowNum, "gubun");
                    break;

                case FunctionType.Update:                    
                    e.IsBaseCall = false;

//                    if (this.grdBAS0210.SaveLayout())
                    if (GrdBAS0210SaveLayout())
                    {
                        this.mMsg = Resource.TEXT3;

                        this.mCap = Resource.TEXT4;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.grdBAS0210.QueryLayout(false);
                        this.grdBAS0210.QueryLayout(true);
                    }
                    else
                    {
                        this.boolSave = false;
                        this.mCap = Resource.TEXT5;
                        if (Service.ErrFullMsg == "")
                        {
                            string mesg = Resource.TEXT6;
                            this.mMsg = this.mCheck + mesg;
                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            this.mMsg = Resource.TEXT7;
                            this.mMsg += "\r\n" + Service.ErrFullMsg;
                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
            }
        }

        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private BAS0210U00 parent = null;

            public XSavePeformer(BAS0210U00 parent)
            {
                this.parent = parent;
            }
            #region 입력값 체크
            private int Validateion_Check(BindVarCollection BindVarList)
            {
                int value = 0;
                string messg = "";
                if (BindVarList["f_gubun"].VarValue == "")
                {
                    messg += NetInfo.Language == LangMode.Ko ? "보험종별" : Resource.TEXT8;
                    value = 1;
                }
                if (BindVarList["f_gubun_name"].VarValue == "")
                {
                    if (value == 1)
                    {
                        messg += ",";
                    }
                    messg += NetInfo.Language == LangMode.Ko ? "보험종별명" : Resource.TEXT9;
                    value = 1;
                }
                if (BindVarList["f_start_date"].VarValue == "")
                {
                    if (value == 1)
                    {
                        messg += ",";
                    }
                    messg += NetInfo.Language == LangMode.Ko ? "적용일자" : Resource.TEXT10;
                    value = 1;
                }
                if (BindVarList["f_start_date"].VarValue == "")
                {
                    if (value == 1)
                    {
                        messg += ",";
                    }
                    messg += NetInfo.Language == LangMode.Ko ? "종료일자" : Resource.TEXT11;
                    value = 1;
                }
                parent.mCheck = messg;
                return value;
            }
            #endregion
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                object t_dup_check = "";

                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                item.BindVarList.Add("f_user_id", UserInfo.UserID);

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                if (Validateion_Check(item.BindVarList) != 0)
                                {
                                    return false;
                                }
                                cmdText = @"SELECT 'Y' 
            	                              FROM DUAL
            	                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0210
                                                             WHERE HOSP_CODE   = :f_hosp_code
                                                               AND GUBUN       = :f_gubun
                                                               AND START_DATE  = :f_start_date) ";

                                t_dup_check = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_dup_check))
                                {
                                    if (t_dup_check.ToString() == "Y")
                                    {
                                        XMessageBox.Show(Resource.TEXT12+":「" + item.BindVarList["f_gubun"].VarValue + "」"+
                                                         Resource.TEXT13+":「" + item.BindVarList["f_start_date"].VarValue + "」\r\n" +
                                                         Resource.TEXT14, Resource.TEXT15, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                cmdText = @" UPDATE BAS0210
                                                SET UPD_DATE    = SYSDATE
                                                  , UPD_ID      = :f_user_id
                                                  , END_DATE = TO_DATE(:f_start_date) - 1
                                              WHERE HOSP_CODE   = :f_hosp_code 
                                                AND GUBUN       = :f_gubun
                                                AND START_DATE  <= :f_start_date ";
                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"INSERT INTO BAS0210
                                                 ( SYS_DATE          , SYS_ID              , UPD_DATE       , UPD_ID        , HOSP_CODE                               
                                                 , START_DATE        , END_DATE            , GUBUN          , GUBUN_NAME            
                                                 , JOHAP_GUBUN       , GONGBI_YN           )
                                            VALUES
                                                 ( SYSDATE           , :f_user_id          , SYSDATE        , :f_user_id     , :f_hosp_code
                                                 , :f_start_date     , :f_end_date         , :f_gubun       , :f_gubun_name        
                                                 , :f_johap_gubun    , :f_gongbi_yn        )";

                                break;

                            case DataRowState.Modified:
                                if (Validateion_Check(item.BindVarList) != 0)
                                {
                                    return false;
                                }
                                cmdText = @"UPDATE BAS0210
                                               SET UPD_ID       = :f_user_id
                                                 , UPD_DATE     = SYSDATE
                                                 , END_DATE     = :f_end_date
                                                 , GUBUN_NAME   = :f_gubun_name
                                                 , JOHAP_GUBUN  = :f_johap_gubun
                                                 , GONGBI_YN    = :f_gongbi_yn
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND GUBUN        = :f_gubun
                                               AND START_DATE   = :f_start_date";

                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE FROM BAS0210
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND GUBUN        = :f_gubun
                                               AND START_DATE   = :f_start_date";

                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void dptApplyDate_DateValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue != "")
            {
                //this.grdBAS0210.QueryLayout(false);
                this.grdBAS0210.QueryLayout(true);
            }
        }

        private void fwkCommon_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void BAS0210U00_Closing(object sender, CancelEventArgs e)
        {
            if (this.boolSave == false)
            {
                e.Cancel = true;
            }
        }

        #region connect to cloud

        /// <summary>
        /// ExecuteQueryGrdBAS0210
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdBAS0210(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0210U00grdBAS0210Args vBAS0210U00grdBAS0210Args = new BAS0210U00grdBAS0210Args();
            vBAS0210U00grdBAS0210Args.GubunCode = bc["f_gubun_code"] != null ? bc["f_gubun_code"].VarValue : "";
            vBAS0210U00grdBAS0210Args.StartDate = bc["f_start_date"] != null ? bc["f_start_date"].VarValue : "";
            BAS0210U00grdBAS0210Result result = CloudService.Instance.Submit<BAS0210U00grdBAS0210Result, BAS0210U00grdBAS0210Args>(vBAS0210U00grdBAS0210Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0210U00grdBAS0210ItemInfo item in result.GrdBas0210)
                {
                    object[] objects =
                    {
                        item.Gubun,
                        item.GubunName,
                        item.RetrieveYn,
                        item.StartDate,
                        item.EndDate,
                        item.JohapGubun,
                        item.JohapName,
                        item.GonbiYn
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdBAS0210GridColumnChanged
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdBAS0210GridColumnChanged(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0210U00grdBAS0210GridColumnChangedArgs vBAS0210U00grdBAS0210GridColumnChangedArgs = new BAS0210U00grdBAS0210GridColumnChangedArgs();
            vBAS0210U00grdBAS0210GridColumnChangedArgs.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            vBAS0210U00grdBAS0210GridColumnChangedArgs.ColName = bc["f_col_name"] != null ? bc["f_col_name"].VarValue : "";
            BAS0210U00grdBAS0210GridColumnChangedResult result = CloudService.Instance.Submit<BAS0210U00grdBAS0210GridColumnChangedResult, BAS0210U00grdBAS0210GridColumnChangedArgs>(vBAS0210U00grdBAS0210GridColumnChangedArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0210U00grdBAS0210GridColumnChangedItemInfo item in result.GridColumnChanged)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteFbxDataValidating
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteFbxDataValidating(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0210U00fbxDataValidatingArgs vBAS0210U00fbxDataValidatingArgs = new BAS0210U00fbxDataValidatingArgs();
            vBAS0210U00fbxDataValidatingArgs.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            vBAS0210U00fbxDataValidatingArgs.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            vBAS0210U00fbxDataValidatingArgs.ControlName = bc["f_control_name"] != null ? bc["f_control_name"].VarValue : "";
            BAS0210U00fbxDataValidatingResult result = CloudService.Instance.Submit<BAS0210U00fbxDataValidatingResult, BAS0210U00fbxDataValidatingArgs>(vBAS0210U00fbxDataValidatingArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new String[] { result.CodeName });
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryFwkCommon
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryFwkCommon(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0210U00fwkCommonArgs vBAS0210U00fwkCommonArgs = new BAS0210U00fwkCommonArgs();
            vBAS0210U00fwkCommonArgs.Find = bc["f_find"] != null ? bc["f_find"].VarValue : "";
            BAS0210U00fwkCommonResult result = CloudService.Instance.Submit<BAS0210U00fwkCommonResult, BAS0210U00fwkCommonArgs>(vBAS0210U00fwkCommonArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.FwkCommon)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// GrdBAS0210SaveLayout
        /// </summary>
        /// <returns></returns>
	    private bool GrdBAS0210SaveLayout()
	    {
            // Validateion_Check
	        for (int i = 0; i < grdBAS0210.RowCount; i++)
	        {
	            if (grdBAS0210.GetRowState(i) == DataRowState.Added || grdBAS0210.GetRowState(i) == DataRowState.Modified)
	            {
	                int validateion = Validateion_Check(grdBAS0210.GetItemString(i, "gubun"),
	                    grdBAS0210.GetItemString(i, "gubun_name"),
	                    grdBAS0210.GetItemString(i, "start_date"), grdBAS0210.GetItemString(i, "end_date"));
	                if (validateion != 0)
	                {
	                    return false;
	                }
	            }
	        }

            // SaveLayout
	        BAS0210U00SaveLayoutArgs args = new BAS0210U00SaveLayoutArgs();
	        args.ItemInfo = CreateListGrdBass0210Item();
	        args.UserId = UserInfo.UserID;
	        UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, BAS0210U00SaveLayoutArgs>(args);
	        if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
	            updateResult.Result == false)
	        {
	            return false;
	        }
	        return true;
	    }

        /// <summary>
        /// CreateListGrdBass0210Item
        /// </summary>
        /// <returns></returns>
	    private List<BAS0210U00grdBAS0210ItemInfo> CreateListGrdBass0210Item()
	    {
	        List<BAS0210U00grdBAS0210ItemInfo> lstGrdBas0210ItemInfo = new List<BAS0210U00grdBAS0210ItemInfo>();
	        for (int i = 0; i < grdBAS0210.RowCount; i++)
	        {
	            if (grdBAS0210.GetRowState(i) == DataRowState.Added || grdBAS0210.GetRowState(i) == DataRowState.Modified)
	            {
	                BAS0210U00grdBAS0210ItemInfo itemInfo = new BAS0210U00grdBAS0210ItemInfo();
	                itemInfo.Gubun = grdBAS0210.GetItemString(i, "gubun");
	                itemInfo.GubunName = grdBAS0210.GetItemString(i, "gubun_name");
	                itemInfo.RetrieveYn = grdBAS0210.GetItemString(i, "retrieve_yn");
	                itemInfo.StartDate = grdBAS0210.GetItemString(i, "start_date");
	                itemInfo.EndDate = grdBAS0210.GetItemString(i, "end_date");
	                itemInfo.JohapGubun = grdBAS0210.GetItemString(i, "johap_gubun");
                    itemInfo.JohapName = grdBAS0210.GetItemString(i, "johap_gubun_name");
                    itemInfo.GonbiYn = grdBAS0210.GetItemString(i, "gongbi_yn");
	                itemInfo.DataRowState = grdBAS0210.GetRowState(i).ToString();
	                lstGrdBas0210ItemInfo.Add(itemInfo);
	            }
	        }
	        if (grdBAS0210.DeletedRowTable != null && grdBAS0210.RowCount > 0)
	        {
                foreach (DataRow row in grdBAS0210.DeletedRowTable.Rows)
	            {
                    BAS0210U00grdBAS0210ItemInfo itemInfo = new BAS0210U00grdBAS0210ItemInfo();
                    itemInfo.Gubun = row["gubun"].ToString();
                    itemInfo.GubunName = row["gubun_name"].ToString();
                    itemInfo.RetrieveYn = row["retrieve_yn"].ToString();
                    itemInfo.StartDate = row["start_date"].ToString();
                    itemInfo.EndDate = row["end_date"].ToString();
                    itemInfo.JohapGubun = row["johap_gubun"].ToString();
                    itemInfo.JohapName = row["johap_gubun_name"].ToString();
                    itemInfo.GonbiYn = row["gongbi_yn"].ToString();
	                itemInfo.DataRowState = DataRowState.Deleted.ToString();
                    lstGrdBas0210ItemInfo.Add(itemInfo);
	            }
                
	        }
	        return lstGrdBas0210ItemInfo;
	    }

        /// <summary>
        /// Validateion_Check
        /// </summary>
        /// <param name="aGubun"></param>
        /// <param name="aGubunName"></param>
        /// <param name="aStartDate"></param>
        /// <param name="aEndDate"></param>
        /// <returns></returns>
        private int Validateion_Check(string aGubun, string aGubunName, string aStartDate, string aEndDate)
	    {
            int value = 0;
            string messg = "";
            if (aGubun == "")
            {
                messg += Resource.TEXT8;
                value = 1;
            }
            if (aGubunName == "")
            {
                if (value == 1)
                {
                    messg += ",";
                }
                messg += Resource.TEXT9;
                value = 1;
            }
            if (aStartDate == "")
            {
                if (value == 1)
                {
                    messg += ",";
                }
                messg += Resource.TEXT10;
                value = 1;
            }
            if (aEndDate == "")
            {
                if (value == 1)
                {
                    messg += ",";
                }
                messg += Resource.TEXT11;
                value = 1;
            }

            mCheck = messg;
            return value;
	    }

	    #endregion
    }
}
