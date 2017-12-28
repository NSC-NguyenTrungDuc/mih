#region 사용 NameSpace 지정

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CHTS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Chts;
using IHIS.CloudConnector.Contracts.Models.Chts;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Chts;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
#endregion

namespace IHIS.CHTS
{
	/// <summary>
	/// CHT0117U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CHT0117U00 : IHIS.Framework.XScreen
	{
		#region 필수 디자이너 변수

		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XEditGrid grdCHT0117;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XEditGrid grdCHT0118;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XTextBox txtSearchWord;
		private IHIS.Framework.XDatePicker dtpQueryDate;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.SingleLayout layCheck;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem1;
		private IHIS.Framework.SingleLayout layDup;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem2;
        private IHIS.Framework.SingleLayout layNextSubBuwiCd;
        private IHIS.Framework.SingleLayoutItem singleLayoutItem3;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private const int maxRowpage = 200;

		#endregion

		#region 생성자

		public CHT0117U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            // TODO comment use connect cloud
			/*this.grdCHT0117.SavePerformer = new XSavePerformer(this);
			this.grdCHT0118.SavePerformer = this.grdCHT0117.SavePerformer;*/

            grdCHT0117.ParamList = new List<string>(new String[] { "f_query_date", "f_search_word", "f_page_number", "f_offset" });
		    grdCHT0117.ExecuteQuery = ExecuteQueryGrdCHT0117;

            grdCHT0118.ParamList = new List<string>(new String[] { "f_query_date", "f_buwi", "f_page_number", "f_offset" });
		    grdCHT0118.ExecuteQuery = ExecuteQueryGrdCHT0118;

		    layNextSubBuwiCd.ExecuteQuery = ExecuteQueryLayNextSubBuwiCd;


		}

		#endregion

		#region 소멸자

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

		#endregion

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CHT0117U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dtpQueryDate = new IHIS.Framework.XDatePicker();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.txtSearchWord = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.grdCHT0117 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grdCHT0118 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layCheck = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layDup = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.layNextSubBuwiCd = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCHT0117)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCHT0118)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.dtpQueryDate);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.txtSearchWord);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // dtpQueryDate
            // 
            this.dtpQueryDate.AccessibleDescription = null;
            this.dtpQueryDate.AccessibleName = null;
            resources.ApplyResources(this.dtpQueryDate, "dtpQueryDate");
            this.dtpQueryDate.BackgroundImage = null;
            this.dtpQueryDate.Font = null;
            this.dtpQueryDate.Name = "dtpQueryDate";
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Font = null;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.AccessibleDescription = null;
            this.txtSearchWord.AccessibleName = null;
            resources.ApplyResources(this.txtSearchWord, "txtSearchWord");
            this.txtSearchWord.BackgroundImage = null;
            this.txtSearchWord.Font = null;
            this.txtSearchWord.Name = "txtSearchWord";
            this.txtSearchWord.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSearchWord_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Font = null;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // grdCHT0117
            // 
            resources.ApplyResources(this.grdCHT0117, "grdCHT0117");
            this.grdCHT0117.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell13});
            this.grdCHT0117.ColPerLine = 5;
            this.grdCHT0117.Cols = 5;
            this.grdCHT0117.ExecuteQuery = null;
            this.grdCHT0117.FixedRows = 1;
            this.grdCHT0117.HeaderHeights.Add(25);
            this.grdCHT0117.Name = "grdCHT0117";
            this.grdCHT0117.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdCHT0117.ParamList")));
            this.grdCHT0117.Rows = 2;
            this.grdCHT0117.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdCHT0117_GridColumnChanged);
            this.grdCHT0117.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdCHT0117_RowFocusChanged);
            this.grdCHT0117.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grd_SaveEnd);
            this.grdCHT0117.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdCHT0117_QueryStarting);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "start_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 104;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "end_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 100;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 6;
            this.xEditGridCell1.CellName = "buwi";
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 50;
            this.xEditGridCell2.CellName = "buwi_name";
            this.xEditGridCell2.CellWidth = 183;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "sort_key";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell3.CellWidth = 67;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "remark";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // splitter1
            // 
            this.splitter1.AccessibleDescription = null;
            this.splitter1.AccessibleName = null;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackgroundImage = null;
            this.splitter1.Font = null;
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // grdCHT0118
            // 
            resources.ApplyResources(this.grdCHT0118, "grdCHT0118");
            this.grdCHT0118.CallerID = '2';
            this.grdCHT0118.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell12,
            this.xEditGridCell14});
            this.grdCHT0118.ColPerLine = 5;
            this.grdCHT0118.Cols = 5;
            this.grdCHT0118.ExecuteQuery = null;
            this.grdCHT0118.FixedRows = 1;
            this.grdCHT0118.HeaderHeights.Add(25);
            this.grdCHT0118.Name = "grdCHT0118";
            this.grdCHT0118.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdCHT0118.ParamList")));
            this.grdCHT0118.Rows = 2;
            this.grdCHT0118.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grd_SaveEnd);
            this.grdCHT0118.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdCHT0118_QueryStarting);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "start_date";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell10.CellWidth = 90;
            this.xEditGridCell10.Col = 3;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsNotNull = true;
            this.xEditGridCell10.IsUpdatable = false;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "end_date";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.CellWidth = 89;
            this.xEditGridCell11.Col = 4;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 6;
            this.xEditGridCell6.CellName = "buwi";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsNotNull = true;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 6;
            this.xEditGridCell7.CellName = "sub_buwi";
            this.xEditGridCell7.CellWidth = 90;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 50;
            this.xEditGridCell8.CellName = "sub_buwi_name";
            this.xEditGridCell8.CellWidth = 132;
            this.xEditGridCell8.Col = 1;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "sort_key";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell9.CellWidth = 67;
            this.xEditGridCell9.Col = 2;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "remark";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "nosai_jy_rate";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.DecimalDigits = 2;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Font = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // layCheck
            // 
            this.layCheck.ExecuteQuery = null;
            this.layCheck.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layCheck.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCheck.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "dup_yn";
            // 
            // layDup
            // 
            this.layDup.ExecuteQuery = null;
            this.layDup.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layDup.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDup.ParamList")));
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "dup_yn";
            // 
            // layNextSubBuwiCd
            // 
            this.layNextSubBuwiCd.ExecuteQuery = null;
            this.layNextSubBuwiCd.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem3});
            this.layNextSubBuwiCd.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layNextSubBuwiCd.ParamList")));
//            this.layNextSubBuwiCd.QuerySQL = "SELECT LPAD(MAX(A.SUB_BUWI)+1,3,0) AS SUB_BUWI \r\n  FROM CHT0118 A\r\n WHERE A.HOSP_" +
//                "CODE = :f_hosp_code";
            this.layNextSubBuwiCd.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNextSubBuwiCd_QueryStarting);
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "f_buwi_next";
            // 
            // CHT0117U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.grdCHT0118);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grdCHT0117);
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Name = "CHT0117U00";
            this.Load += new System.EventHandler(this.CHT0117U00_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCHT0117)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCHT0118)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수

		private string mMsg = "";
		private string mCap = "";

		#endregion

		#region Function

		private void InitScreen ()
		{
			// 조회 일자 우선은 오늘날자
			this.dtpQueryDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

			// 검색
			this.txtSearchWord.SetDataValue("");
		}

		private void SetCHT0117Default()
		{
			this.grdCHT0117.SetItemValue(grdCHT0117.CurrentRowNumber, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            this.grdCHT0117.SetItemValue(grdCHT0117.CurrentRowNumber, "end_date", "9998/12/31");
		}

		private void SetCHT0118Default()
		{
            
            this.grdCHT0118.SetItemValue(grdCHT0118.CurrentRowNumber, "start_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            this.grdCHT0118.SetItemValue(grdCHT0118.CurrentRowNumber, "end_date", "9998/12/31");
            this.grdCHT0118.SetItemValue(grdCHT0118.CurrentRowNumber, "buwi", this.grdCHT0117.GetItemString(grdCHT0117.CurrentRowNumber, "buwi"));
		}

		#endregion

		#region DataLoad

		private void Load_CHT0117 ()
		{
			this.grdCHT0117.QueryLayout(false);

			if (this.grdCHT0117.RowCount <= 0)
			{
				this.grdCHT0118.Reset();
			}
		}

		private void Load_CHT0118()
		{
			this.grdCHT0118.QueryLayout(false);
		}

		#endregion

		#region Screen Load

		private void CHT0117U00_Load(object sender, System.EventArgs e)
		{
			this.InitScreen();

			this.Load_CHT0117();
		}

		#endregion

		#region XEdit Grid

		private void grdCHT0117_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if (e.CurrentRow >= 0)
				this.Load_CHT0118();
		}

		#endregion

		#region XButtonList

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Update :

					e.IsBaseCall = false;

					try
					{
                        // TODO comment use connect cloud
						/*Service.BeginTransaction();
						
						this.grdCHT0117.SaveLayout();
						this.grdCHT0118.SaveLayout();
						
						Service.CommitTransaction();	*/
					    e.IsSuccess = SaveLayout();
                        if (!e.IsSuccess)
					    {
                            XMessageBox.Show(this.mMsg + "-" + Service.ErrFullMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
					    }

                        // query end

					    isSuccess1 = e.IsSuccess;
					    isCalled1 = true;

					    isSuccess2 = e.IsSuccess;
					    isCalled2 = true;

					    if (isCalled1 && isCalled2)
					    {
					        if (isSuccess1 && isSuccess2)
					        {
					            this.mMsg = Resources.MSG003_MSG;

					            XMessageBox.Show(this.mMsg, Resources.MSG003_CAP, MessageBoxButtons.OK, MessageBoxIcon.Information);

					            this.Load_CHT0117();
					        }

					        isSuccess1 = false;
					        isSuccess2 = false;
					        isCalled1 = false;
					        isCalled2 = false;
					    }
					}
					catch
					{
//						Service.RollbackTransaction();
						this.mMsg = Resources.MSG001_MSG;
						this.mCap = Resources.MSG001_CAP;
						XMessageBox.Show(this.mMsg + "-" + Service.ErrFullMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					}

					break;

				case FunctionType.Query:

					e.IsBaseCall = false;

					this.grdCHT0117.QueryLayout(false);

					this.grdCHT0118.QueryLayout(false);

					break;

				case FunctionType.Delete:
					
					if(this.CurrMSLayout == this.grdCHT0117)
					{
						if(this.grdCHT0118.RowCount > 0)
						{
							XMessageBox.Show(Resources.MSG002_MSG,Resources.MSG002_CAP);
							e.IsBaseCall = false;
							return;
						}
					}

					if(this.CurrMSLayout == this.grdCHT0118)
					{
						if(this.grdCHT0118.RowCount < 1)
						{
							this.grdCHT0117.DeleteRow();
						}
					}
					break;
			}
		}

		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Insert :

					if (this.CurrMSLayout == this.grdCHT0117)
					{
						this.SetCHT0117Default();
					}
					else
					{
						this.SetCHT0118Default();
                        this.grdCHT0118.SetFocusToItem(this.grdCHT0118.CurrentRowNumber, "sub_buwi");
                        //this.grdCHT0118.SetFocusToItem(grdCHT0118.CurrentRowNumber, "sub_buwi");

					}

					break;

				case FunctionType.Reset:

					this.dtpQueryDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

					break;
			}
		}

		#endregion

		#region BIND 변수 설정

		private void grdCHT0117_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.grdCHT0117.SetBindVarValue("f_query_date", this.dtpQueryDate.GetDataValue());
			this.grdCHT0117.SetBindVarValue("f_search_word", this.txtSearchWord.GetDataValue());
            this.grdCHT0117.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
		}

		private void grdCHT0118_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
            this.grdCHT0118.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.grdCHT0118.SetBindVarValue("f_query_date", this.dtpQueryDate.GetDataValue());
			this.grdCHT0118.SetBindVarValue("f_buwi", this.grdCHT0117.GetItemString(this.grdCHT0117.CurrentRowNumber, "buwi"));
		}
		#endregion

		#region grd_SaveEnd

		private bool isSuccess1 = false;
		private bool isSuccess2 = false;

		private bool isCalled1 = false;
		private bool isCalled2 = false;

		private void grd_SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
		{
			if(e.CallerID == '1')
			{
				isSuccess1 = e.IsSuccess;
				isCalled1 = true;
			}

			if(e.CallerID == '2')
			{
				isSuccess2 = e.IsSuccess;
				isCalled2 = true;
			}

			if(isCalled1 && isCalled2)
			{
				if(isSuccess1 && isSuccess2)
				{
					this.mMsg = Resources.MSG003_MSG;

					XMessageBox.Show(this.mMsg, Resources.MSG003_CAP, MessageBoxButtons.OK, MessageBoxIcon.Information);

					this.Load_CHT0117();
				}

				isSuccess1 = false;
				isSuccess2 = false;
				isCalled1 = false;
				isCalled2 = false;
			}
		}

		#endregion

		#region txtSearchWord_DataValidating

		private void txtSearchWord_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			XTextBox txtBox = sender as XTextBox;

			if(txtBox.GetDataValue() != "")
			{
				this.grdCHT0117.QueryLayout(false);
				this.grdCHT0118.QueryLayout(false);
			}
		}

		#endregion

		#region Validation Check

		private void grdCHT0117_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			//그리드상의 중복체크
			int currentRow = this.grdCHT0117.CurrentRowNumber;

			for(int row = 0 ; row < this.grdCHT0117.RowCount ; row++)
			{
				if(row == currentRow)
					continue;

				if(this.grdCHT0117.GetItemString(row, "buwi") == this.grdCHT0117.GetItemString(currentRow, "buwi"))
				{
					XMessageBox.Show(Resources.MSG004_MSG);
					e.Cancel = true;
				}
			}

            // TODO NOT USE
			//DB상의 중복체크
			/*this.layDup.QuerySQL = "SELECT 'Y'												"
								 + "  FROM DUAL												"
								 + " WHERE EXISTS ( SELECT 'X'								"
								 + "                  FROM CHT0117							"
								 + "                 WHERE BUWI        = :f_buwi			";

            this.layDup.ParamList = new List<string>(new String[] { "f_buwi" });
			this.layDup.SetBindVarValue("f_buwi", this.grdCHT0117.GetItemString(currentRow, "buwi"));
		     this.layDup.ExecuteQuery = ExecuteQueryLayDup;
			if(this.layDup.QueryLayout())
			{
				if(this.layDup.GetItemValue("dup_yn").ToString() == "Y")
				{
					XMessageBox.Show(Resources.MSG004_MSG, Resources.MSG002_CAP);
					e.Cancel = true;
				}
			}*/

        }		
		#endregion

        #region Connect cloud service

        /// <summary>
        /// ExecuteQueryGrdCHT0117
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdCHT0117(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CHT0117GrdCHT0117InitArgs vCHT0117GrdCHT0117InitArgs = new CHT0117GrdCHT0117InitArgs();
            vCHT0117GrdCHT0117InitArgs.QueryDate = bc["f_query_date"] != null ? bc["f_query_date"].VarValue : "";
            vCHT0117GrdCHT0117InitArgs.SearchWord = bc["f_search_word"] != null ? bc["f_search_word"].VarValue : "";
            vCHT0117GrdCHT0117InitArgs.PageNumber = bc["f_page_number"] != null ? bc["f_page_number"].VarValue : "";
            vCHT0117GrdCHT0117InitArgs.Offset = maxRowpage.ToString();
            CHT0117GrdCHT0117InitResult result = CloudService.Instance.Submit<CHT0117GrdCHT0117InitResult, CHT0117GrdCHT0117InitArgs>(vCHT0117GrdCHT0117InitArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CHT0117GrdCHT0117InitListItemInfo item in result.ListItemInfo)
                {
                    object[] objects =
                    {
                        item.StartDate,
                        item.EndDate,
                        item.Buwi,
                        item.BuwiName,
                        item.SortKey,
                        item.Remark,
                        item.ContKey
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdCHT0118
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdCHT0118(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CHT0117GrdCHT0118InitArgs vCHT0117GrdCHT0118InitArgs = new CHT0117GrdCHT0118InitArgs();
            vCHT0117GrdCHT0118InitArgs.Buwi = bc["f_buwi"] != null ? bc["f_buwi"].VarValue : "";
            vCHT0117GrdCHT0118InitArgs.QueryDate = bc["f_query_date"] != null ? bc["f_query_date"].VarValue : "";
            vCHT0117GrdCHT0118InitArgs.PageNumber = bc["f_page_number"] != null ? bc["f_page_number"].VarValue : "";
            vCHT0117GrdCHT0118InitArgs.Offset = maxRowpage.ToString();
            CHT0117GrdCHT0118InitResult result = CloudService.Instance.Submit<CHT0117GrdCHT0118InitResult, CHT0117GrdCHT0118InitArgs>(vCHT0117GrdCHT0118InitArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CHT0117GrdCHT0118InitListItemInfo item in result.ListItemInfo)
                {
                    object[] objects =
                    {
                        item.StartDate,
                        item.EndDate,
                        item.Buwi,
                        item.SubBuwi,
                        item.SubBuwiName,
                        item.SortKey,
                        item.Remark,
                        item.ContKey,
                        item.NosaiJyRate
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryLayNextSubBuwiCd
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryLayNextSubBuwiCd(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CHT0117LayNextSubBuwiCdArgs vCHT0117LayNextSubBuwiCdArgs = new CHT0117LayNextSubBuwiCdArgs();
            CHT0117LayNextSubBuwiCdResult result = CloudService.Instance.Submit<CHT0117LayNextSubBuwiCdResult, CHT0117LayNextSubBuwiCdArgs>(vCHT0117LayNextSubBuwiCdArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[] {result.SubBuwi});
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryLayDup
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryLayDup(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CHT0117grdCHT0117CheckArgs vCHT0117grdCHT0117CheckArgs = new CHT0117grdCHT0117CheckArgs();
            vCHT0117grdCHT0117CheckArgs.Buwi = bc["f_buwi"] != null ? bc["f_buwi"].VarValue : "";
            CHT0117grdCHT0117CheckResult result = CloudService.Instance.Submit<CHT0117grdCHT0117CheckResult, CHT0117grdCHT0117CheckArgs>(vCHT0117grdCHT0117CheckArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[] {result.ChkResult});
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
	    private bool SaveLayout()
	    {
	        CHT0117TransactionalArgs args = new CHT0117TransactionalArgs();
	        args.ListInput1 = CreateListGrdCHT0117();
	        args.ListInput2 = CreateListGrdCHT0118();
            //if (args.ListInput1.Count < 1 && args.ListInput2.Count < 1) return false;
	        args.UserId = UserInfo.UserID;
	        UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, CHT0117TransactionalArgs>(args);
	        if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
	            updateResult.Result == false)
	        {
                if ("MSG005_MSG".Equals(updateResult.Msg))
	            {
                    XMessageBox.Show(Resources.MSG005_MSG, Resources.MSG002_CAP);
	            }
                if ("MSG006_MSG".Equals(updateResult.Msg))
	            {
                    XMessageBox.Show(Resources.MSG006_MSG, Resources.MSG002_CAP);
	            }
	            return false;
	        }
	        return true;
	    }

        /// <summary>
        /// CreateListGrdCHT0117
        /// </summary>
        /// <returns></returns>
	    private List<CHT0117GrdCHT0117InitListItemInfo> CreateListGrdCHT0117()
	    {
	        List<CHT0117GrdCHT0117InitListItemInfo> ListGrdCHT0117Item = new List<CHT0117GrdCHT0117InitListItemInfo>();
	        for (int i = 0; i < grdCHT0117.RowCount; i++)
	        {
	            if (grdCHT0117.GetRowState(i) == DataRowState.Added || grdCHT0117.GetRowState(i) == DataRowState.Modified)
	            {
	                CHT0117GrdCHT0117InitListItemInfo itemInfo = new CHT0117GrdCHT0117InitListItemInfo();
	                itemInfo.StartDate = grdCHT0117.GetItemString(i, "start_date");
	                itemInfo.EndDate = grdCHT0117.GetItemString(i, "end_date");
	                itemInfo.Buwi = grdCHT0117.GetItemString(i, "buwi");
	                itemInfo.BuwiName = grdCHT0117.GetItemString(i, "buwi_name");
	                itemInfo.SortKey = grdCHT0117.GetItemString(i, "sort_key");
	                itemInfo.Remark = grdCHT0117.GetItemString(i, "remark");
	                itemInfo.RowState = grdCHT0117.GetRowState(i).ToString();
	                ListGrdCHT0117Item.Add(itemInfo);
	            }
	        }

            if (grdCHT0117.DeletedRowTable != null && grdCHT0117.DeletedRowCount > 0)
	        {
                foreach (DataRow row in grdCHT0117.DeletedRowTable.Rows)
	            {
                    CHT0117GrdCHT0117InitListItemInfo itemInfo = new CHT0117GrdCHT0117InitListItemInfo();
                    itemInfo.StartDate = row["start_date"].ToString();
                    itemInfo.EndDate = row["end_date"].ToString(); 
                    itemInfo.Buwi = row["buwi"].ToString();
                    itemInfo.BuwiName = row["buwi_name"].ToString();
                    itemInfo.SortKey = row["sort_key"].ToString();
                    itemInfo.Remark = row["remark"].ToString();
                    
	                itemInfo.RowState = DataRowState.Deleted.ToString();
                    ListGrdCHT0117Item.Add(itemInfo);
	            }
	        }
	        
	        return ListGrdCHT0117Item;
	    }

        /// <summary>
        /// CreateListGrdCHT0118
        /// </summary>
        /// <returns></returns>
	    private List<CHT0117GrdCHT0118InitListItemInfo> CreateListGrdCHT0118()
	    {
	        List<CHT0117GrdCHT0118InitListItemInfo> grdCht0118InitListItemInfo = new List<CHT0117GrdCHT0118InitListItemInfo>();
	        for (int i = 0; i < grdCHT0118.RowCount; i++)
	        {
	            if (grdCHT0118.GetRowState(i) == DataRowState.Added || grdCHT0118.GetRowState(i) == DataRowState.Modified)
	            {
	                CHT0117GrdCHT0118InitListItemInfo itemInfo = new CHT0117GrdCHT0118InitListItemInfo();
	                itemInfo.StartDate = grdCHT0118.GetItemString(i, "start_date");
	                itemInfo.EndDate = grdCHT0118.GetItemString(i, "end_date");
	                itemInfo.Buwi = grdCHT0118.GetItemString(i, "buwi");
	                itemInfo.SubBuwi = grdCHT0118.GetItemString(i, "sub_buwi");
	                itemInfo.SubBuwiName = grdCHT0118.GetItemString(i, "sub_buwi_name");
	                itemInfo.SortKey = grdCHT0118.GetItemString(i, "sort_key");
	                itemInfo.Remark = grdCHT0118.GetItemString(i, "remark");
	                itemInfo.NosaiJyRate = grdCHT0118.GetItemString(i, "nosai_jy_rate");
	                itemInfo.RowState = grdCHT0118.GetRowState(i).ToString();

	                grdCht0118InitListItemInfo.Add(itemInfo);
	            }
	        }
	        if (grdCHT0118.DeletedRowTable != null && grdCHT0118.DeletedRowCount > 0)
	        {
                foreach (DataRow row in grdCHT0118.DeletedRowTable.Rows)
	            {
                    CHT0117GrdCHT0118InitListItemInfo itemInfo = new CHT0117GrdCHT0118InitListItemInfo();
                    itemInfo.StartDate = row["start_date"].ToString();
                    itemInfo.EndDate = row["end_date"].ToString();
                    itemInfo.Buwi = row["buwi"].ToString();
                    itemInfo.SubBuwi = row["sub_buwi"].ToString();
                    itemInfo.SubBuwiName = row["sub_buwi_name"].ToString();
                    itemInfo.SortKey = row["sort_key"].ToString();
                    itemInfo.Remark = row["remark"].ToString();
                    itemInfo.NosaiJyRate = row["nosai_jy_rate"].ToString();
	                itemInfo.RowState = DataRowState.Deleted.ToString();

                    grdCht0118InitListItemInfo.Add(itemInfo);
	            }
	        }
	        return grdCht0118InitListItemInfo;
	    }
        #endregion

        #region XSavePerformer

        private class XSavePerformer : IHIS.Framework.ISavePerformer
		{
			CHT0117U00 parent = null;

			public XSavePerformer(CHT0117U00 parent)
			{
				this.parent = parent;
			}

			public bool Execute(char callerID, RowDataItem item)
			{
				string cmdText = "";

				switch(callerID)
				{
					case '1':

					switch(item.RowState)
					{
						case DataRowState.Added:

							parent.layCheck.QuerySQL = "SELECT 'Y'												"
													 + "  FROM DUAL												"
													 + " WHERE EXISTS ( SELECT 'X'								"
													 + "                  FROM CHT0117							"
													 + "                 WHERE BUWI        = :f_buwi			"
													 + "                   AND START_DATE >= :f_start_date)		";

							parent.layCheck.SetBindVarValue("f_buwi", item.BindVarList["f_buwi"].VarValue);
							parent.layCheck.SetBindVarValue("f_start_date", item.BindVarList["f_start_date"].VarValue);

							if(parent.layCheck.GetItemValue("dup_yn").ToString() == "Y")
							{
								parent.grdCHT0117.SetFocusToItem(parent.grdCHT0117.CurrentRowNumber,"buwi");
								XMessageBox.Show(Resources.MSG005_MSG, Resources.MSG002_CAP);
								return false;
							}

							cmdText = "BEGIN															"
									+ "    UPDATE CHT0117												"
									+ "       SET END_DATE = TO_DATE(:f_start_date, 'YYYY/MM/DD')-1		"
									+ "     WHERE BUWI     = :f_buwi									"
									+ "       AND END_DATE = '9998/12/31'								"
                                    + "       AND HOSP_CODE = :f_hosp_code;								"
									+ "    INSERT INTO CHT0117											"
									+ "         ( SYS_DATE		, SYS_ID		                        "
									+ "         , START_DATE	, END_DATE      , BUWI					"
									+ "         , BUWI_NAME     , SORT_KEY      , REMARK    , HOSP_CODE)"
									+ "    VALUES														"
                                    + "         ( SYSDATE       , :q_user_id                            "
									+ "         , :f_start_date , '9998/12/31'  , :f_buwi				"
									+ "         , :f_buwi_name  , :f_sort_key   , :f_remark, :f_hosp_code);"
									+ "END;																";

							break;

						case DataRowState.Modified:

							cmdText = "UPDATE CHT0117								"
									+ "   SET UPD_ID         = :q_user_id			"
                                    + "     , UPD_DATE       = SYSDATE	        	"
									+ "     , BUWI_NAME      = :f_buwi_name			"
									+ "     , SORT_KEY       = :f_sort_key			"
									+ "     , REMARK         = :f_remark			"
									+ " WHERE BUWI           = :f_buwi				"
									+ "   AND START_DATE     = :f_start_date		"
                                    + "   AND HOSP_CODE      = :f_hosp_code		    ";

							break;

						case DataRowState.Deleted:

							cmdText = "BEGIN															"
									+ "    UPDATE CHT0117												"
									+ "       SET END_DATE = '9998/12/31'								"
									+ "     WHERE BUWI     = :f_buwi									"
									+ "       AND END_DATE = TO_DATE(:f_start_date, 'YYYY/MM/DD') - 1	"
                                    + "       AND HOSP_CODE   = :f_hosp_code;							"
									+ "    DELETE FROM CHT0117											"
									+ "     WHERE BUWI        = :f_buwi									"
									+ "       AND START_DATE  = :f_start_date							"
                                    + "       AND HOSP_CODE   = :f_hosp_code;							"
									+ "END;																";

							break;
					}

						break;

					case '2':

					switch(item.RowState)
					{
						case DataRowState.Added:

							parent.layCheck.QuerySQL = "SELECT 'Y'												"
													 + "  FROM DUAL												"
													 + " WHERE EXISTS (SELECT 'X'								"
													 + "                 FROM CHT0118							"
													 + "                WHERE BUWI        = :f_buwi				"
													 + "                  AND SUB_BUWI    = :f_sub_buwi			"
													 + "                  AND START_DATE >= :f_start_date     )	";

                            parent.layCheck.SetBindVarValue("f_buwi", item.BindVarList["f_buwi"].VarValue);

                            parent.layNextSubBuwiCd.QueryLayout();

                            if (parent.layNextSubBuwiCd.GetItemValue("f_buwi_next").ToString().Equals(""))
                                parent.grdCHT0118.SetItemValue(parent.grdCHT0118.CurrentRowNumber, "sub_buwi", "001");
                            else
                                parent.grdCHT0118.SetItemValue(parent.grdCHT0118.CurrentRowNumber, "sub_buwi", parent.layNextSubBuwiCd.GetItemValue("f_buwi_next").ToString());

                            parent.layCheck.SetBindVarValue("f_sub_buwi", parent.layNextSubBuwiCd.GetItemValue("f_buwi_next").ToString());
                            parent.layCheck.SetBindVarValue("f_start_date", item.BindVarList["f_start_date"].VarValue);
                            parent.layCheck.QueryLayout();
                            item.BindVarList.Add("f_sub_buwi", parent.layNextSubBuwiCd.GetItemValue("f_buwi_next").ToString());

							if(parent.layCheck.GetItemValue("dup_yn").ToString() == "Y")
							{
                                parent.grdCHT0118.SetFocusToItem(parent.grdCHT0118.CurrentRowNumber, "sub_buwi");
                                XMessageBox.Show(Resources.MSG006_MSG, Resources.MSG002_CAP);
								return false;
							}

							cmdText = "BEGIN																"
									+ "    UPDATE CHT0118													"
									+ "       SET END_DATE = TO_DATE(:f_start_date, 'YYYY/MM/DD') - 1		"
									+ "     WHERE BUWI     = :f_buwi										"
									+ "       AND SUB_BUWI = :f_sub_buwi									"
									+ "       AND END_DATE = '9998/12/31'									"
                                    + "       AND HOSP_CODE = :f_hosp_code;									"
									+ "     INSERT INTO CHT0118												"
									+ "         ( SYS_DATE			, SYS_ID			                    "
									+ "         , START_DATE		, END_DATE			, BUWI				"
									+ "         , SUB_BUWI	        , SUB_BUWI_NAME		, SORT_KEY			"
									+ "         , REMARK            , NOSAI_JY_RATE		, HOSP_CODE)        "
									+ "    VALUES															"
									+ "         ( SYSDATE           , :q_user_id                            "
									+ "         , :f_start_date     , '9998/12/31'      , :f_buwi			"
									+ "         , :f_sub_buwi       , :f_sub_buwi_name  , :f_sort_key		"
                                    + "         , :f_remark         , :f_nosai_jy_rate , :f_hosp_code);     "
									+ "END;																	";


							break;

						case DataRowState.Modified:

							cmdText = "UPDATE CHT0118								"
									+ "   SET UPD_ID       = :q_user_id			    "
									+ "     , UPD_DATE      = SYSDATE				"
									+ "     , SUB_BUWI_NAME = :f_sub_buwi_name		"
									+ "     , SORT_KEY      = :f_sort_key			"
									+ "     , REMARK        = :f_remark				"
									+ "     , NOSAI_JY_RATE = :f_nosai_jy_rate		"
									+ " WHERE BUWI          = :f_buwi				"
									+ "   AND SUB_BUWI      = :f_sub_buwi			"
									+ "   AND START_DATE    = :f_start_date			"
                                    + "   AND HOSP_CODE     = :f_hosp_code			";

							break;

						case DataRowState.Deleted:

							cmdText = "BEGIN																"
									+ "    UPDATE CHT0118													"
									+ "       SET END_DATE = '9998/12/31'									"
									+ "     WHERE BUWI     = :f_buwi										"
									+ "       AND SUB_BUWI = :f_sub_buwi									"
									+ "       AND END_DATE = TO_DATE(:f_start_date, 'YYYY/MM/DD') - 1		"
                                    + "       AND HOSP_CODE     = :f_hosp_code;			                    "
									+ "    DELETE FROM CHT0118												"
									+ "     WHERE BUWI          = :f_buwi									"
									+ "       AND SUB_BUWI      = :f_sub_buwi								"
									+ "       AND START_DATE    = :f_start_date							    "
                                    + "       AND HOSP_CODE     = :f_hosp_code;			                    "
									+ "END;																	";


							break;
					}

						break;
				}
				cmdText = cmdText.Replace("\r", " ");
				item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
				return Service.ExecuteNonQuery(cmdText, item.BindVarList);
			}
		}

		#endregion 

        private void layNextSubBuwiCd_QueryStarting(object sender, CancelEventArgs e)
        {
            layNextSubBuwiCd.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
	}
}

