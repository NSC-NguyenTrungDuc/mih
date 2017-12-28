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
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Schs;
using IHIS.CloudConnector.Contracts.Models.Schs;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Schs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.SCHS.Properties;

#endregion

namespace IHIS.SCHS
{
	/// <summary>
	/// SCH3001U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class SCH3001U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XPanel xPanel5;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
		private IHIS.Framework.XFindWorker fbxHangmogCode;
		private IHIS.Framework.XEditGrid grdSCH0002;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.SingleLayout vsvHangmogCode;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XPanel xPanel7;
		private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XPanel xPanel8;
		private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XLabel xLabel7;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XMstGrid grdSCH0001;
		private IHIS.Framework.XEditGrid grdSCH3000;
		private IHIS.Framework.XEditGrid grdSCH3101;
        private IHIS.Framework.XEditGrid grdSCH3100;
		private IHIS.Framework.XLabel xLabel8;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XButton btnMake1;
		private IHIS.Framework.XEditMask xemRow1;
		private IHIS.Framework.XEditMask xemSpaceTime1;
		private IHIS.Framework.XEditMask xemTime1;
		private IHIS.Framework.XEditMask xemRow2;
		private IHIS.Framework.XButton btnMake2;
		private IHIS.Framework.XEditMask xemTime2;
        private IHIS.Framework.XEditMask xemSpaceTime2;
		private IHIS.Framework.XLabel xLabel18;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XLabel xLabel9;
		private IHIS.Framework.XEditGrid grdJukyongDate;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XLabel xLabel11;
        private IHIS.Framework.XEditGridCell xEditGridCell41;
        private IHIS.Framework.XEditGridCell xEditGridCell49;
		private IHIS.Framework.XEditGridCell xEditGridCell50;
        private IHIS.Framework.XPanel xPanel6;
		private IHIS.Framework.SingleLayout vsvUserName;
        private IHIS.Framework.XEditGridCell xEditGridCell52;
        private XDictComboBox cboGumsa;
        private XLabel xLabel12;
        private XPanel pnlLeft;
        private XPanel pnlGrdSch0001;
        private XPanel pnlGrdSch0002;
        private XLabel xLabel13;
        private XPanel pnlTab;
        private XTabControl tabReserSch;
        private IHIS.X.Magic.Controls.TabPage tabPage1;
        private IHIS.X.Magic.Controls.TabPage tabPage2;
        private XPanel pnlReserSchedule;
        private XPanel xPanel2;
        private XLabel xLabel14;
        private XDatePicker dtpJukyongDate1;
        private XCheckBox cbx1;
        private XCheckBox cbx7;
        private XCheckBox cbx6;
        private XCheckBox cbx5;
        private XCheckBox cbx4;
        private XCheckBox cbx3;
        private XCheckBox cbx2;
        private XDatePicker dtpJukyongDate2;
        private XLabel xLabel17;
        private XLabel xLabel21;
        private XLabel xLabel4;
        private XLabel xLabel20;
        private XLabel xLabel24;
        private XLabel xLabel2;
        private XLabel xLabel16;
        private MultiLayout laySaveSCH3000;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private XEditMask xemInwon2;
        private XEditMask xemInwon1;
        private XLabel xLabel3;
        private XLabel xLabel22;
        private XLabel xLabel10;
        private XLabel xLabel19;
        private XLabel xLabel15;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell42;
        private XEditGridCell xEditGridCell43;
        private XEditGridCell xEditGridCell44;
        private XEditGridCell xEditGridCell45;
        private XEditGridCell xEditGridCell46;
        private XEditGridCell xEditGridCell47;
        private XEditGridCell xEditGridCell48;
        private XPanel xPanel11;
        private XPanel xPanel9;
        private XEditGridCell xEditGridCell53;
        private SingleLayout layDupOCS0103;
        private SingleLayoutItem singleLayoutItem1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private SCH3001U00GrdSCH0001RowFocusChangedResult grdSCH0001RowFocusChangedResult;
        private SCH3001U00LoadDataForGridRequestInCaseDeleteResult loadDataForGridRequestInCaseDeleteResult;
        private List<SCH3001U00GrdSCH0002Info> lstGrdSch0002Info;
        private XEditMask xEditMask1;
        private XLabel xLabel23;
        private XLabel xLabel25;
        private XEditGridCell xEditGridCell55;
	    private List<SCH3001U00GrdSCH3100Info> lstGrdSch3100Info;
        private string str_xemTime1 = "";
        private int int_xemSpaceTime1 = 0;
        private string str_xemInwon1 = "";
        private string str_xemRow1 = "";
        private string str_xEditMask1 = "";

		public SCH3001U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            Size = new System.Drawing.Size(rc.Width - 60, rc.Height - 145);

            this.grdSCH0001.SavePerformer = new XSavePerformer(this);
            this.grdSCH0002.SavePerformer = this.grdSCH0001.SavePerformer;
            this.grdJukyongDate.SavePerformer = this.grdSCH0001.SavePerformer;
            this.grdSCH3000.SavePerformer = this.grdSCH0001.SavePerformer;
            this.grdSCH3100.SavePerformer = this.grdSCH0001.SavePerformer;
            this.grdSCH3101.SavePerformer = this.grdSCH0001.SavePerformer;

            // Create ParamList and ExecuteQuery for Grid
            grdSCH0001.ParamList = new List<string>(new String[] { "f_jundal_table" });
		    grdSCH0001.ExecuteQuery = GrdSCH0001_ExecuteQuery;

            grdJukyongDate.ParamList = new List<string>(new String[] { "f_jundal_table", "f_jundal_part", "f_gumsaja"});
		    grdJukyongDate.ExecuteQuery = GrdJukyongDate_ExecuteQuery;

            grdSCH3000.ParamList = new List<string>(new String[] { "f_jukyong_date", "f_jundal_table", "f_jundal_part", "f_gumsaja", "f_yoil_gubun" });
		    grdSCH3000.ExecuteQuery = GrdSCH3000_ExecuteQuery;

            grdSCH3101.ParamList = new List<string>(new String[] { "f_jundal_table", "f_jundal_part", "f_gumsaja", "f_reser_date" });
		    grdSCH3101.ExecuteQuery = GrdSCH3101_ExecuteQuery;

            // Connect to cloud get data for cboGumsa
		    cboGumsa.ExecuteQuery = cboGumsa_ExecuteQuery;
		    cboGumsa.SetDictDDLB();

            // https://sofiamedix.atlassian.net/browse/MED-15147
            dtpJukyongDate2.IsJapanYearType = (NetInfo.Language == LangMode.Jr);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCH3001U00));
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdSCH3000 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.grdSCH0001 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.fbxHangmogCode = new IHIS.Framework.XFindWorker();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.cboGumsa = new IHIS.Framework.XDictComboBox();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.xPanel9 = new IHIS.Framework.XPanel();
            this.grdSCH3101 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.btnMake2 = new IHIS.Framework.XButton();
            this.xemRow2 = new IHIS.Framework.XEditMask();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel22 = new IHIS.Framework.XLabel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.xemInwon2 = new IHIS.Framework.XEditMask();
            this.xLabel21 = new IHIS.Framework.XLabel();
            this.dtpJukyongDate2 = new IHIS.Framework.XDatePicker();
            this.xemTime2 = new IHIS.Framework.XEditMask();
            this.xemSpaceTime2 = new IHIS.Framework.XEditMask();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.grdSCH3100 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.grdJukyongDate = new IHIS.Framework.XEditGrid();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.dtpJukyongDate1 = new IHIS.Framework.XDatePicker();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xEditMask1 = new IHIS.Framework.XEditMask();
            this.xLabel23 = new IHIS.Framework.XLabel();
            this.xLabel25 = new IHIS.Framework.XLabel();
            this.xemRow1 = new IHIS.Framework.XEditMask();
            this.xemSpaceTime1 = new IHIS.Framework.XEditMask();
            this.xemInwon1 = new IHIS.Framework.XEditMask();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel20 = new IHIS.Framework.XLabel();
            this.xLabel24 = new IHIS.Framework.XLabel();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.cbx1 = new IHIS.Framework.XCheckBox();
            this.cbx7 = new IHIS.Framework.XCheckBox();
            this.cbx6 = new IHIS.Framework.XCheckBox();
            this.cbx5 = new IHIS.Framework.XCheckBox();
            this.cbx4 = new IHIS.Framework.XCheckBox();
            this.cbx3 = new IHIS.Framework.XCheckBox();
            this.cbx2 = new IHIS.Framework.XCheckBox();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.btnMake1 = new IHIS.Framework.XButton();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xemTime1 = new IHIS.Framework.XEditMask();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.grdSCH0002 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.vsvHangmogCode = new IHIS.Framework.SingleLayout();
            this.vsvUserName = new IHIS.Framework.SingleLayout();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.pnlGrdSch0002 = new IHIS.Framework.XPanel();
            this.pnlGrdSch0001 = new IHIS.Framework.XPanel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.pnlTab = new IHIS.Framework.XPanel();
            this.tabReserSch = new IHIS.Framework.XTabControl();
            this.tabPage1 = new IHIS.X.Magic.Controls.TabPage();
            this.pnlReserSchedule = new IHIS.Framework.XPanel();
            this.xPanel11 = new IHIS.Framework.XPanel();
            this.tabPage2 = new IHIS.X.Magic.Controls.TabPage();
            this.laySaveSCH3000 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.layDupOCS0103 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSCH3000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSCH0001)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel8.SuspendLayout();
            this.xPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSCH3101)).BeginInit();
            this.xPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSCH3100)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJukyongDate)).BeginInit();
            this.xPanel5.SuspendLayout();
            this.xPanel7.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSCH0002)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlGrdSch0002.SuspendLayout();
            this.pnlGrdSch0001.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.tabReserSch.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlReserSchedule.SuspendLayout();
            this.xPanel11.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.laySaveSCH3000)).BeginInit();
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
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdSCH3000
            // 
            resources.ApplyResources(this.grdSCH3000, "grdSCH3000");
            this.grdSCH3000.CallerID = '2';
            this.grdSCH3000.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell40,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell13,
            this.xEditGridCell37,
            this.xEditGridCell14,
            this.xEditGridCell16,
            this.xEditGridCell18,
            this.xEditGridCell55});
            this.grdSCH3000.ColPerLine = 4;
            this.grdSCH3000.Cols = 5;
            this.grdSCH3000.ExecuteQuery = null;
            this.grdSCH3000.FixedCols = 1;
            this.grdSCH3000.FixedRows = 1;
            this.grdSCH3000.FocusColumnName = "start_time";
            this.grdSCH3000.HeaderHeights.Add(27);
            this.grdSCH3000.Name = "grdSCH3000";
            this.grdSCH3000.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSCH3000.ParamList")));
            this.grdSCH3000.RowHeaderVisible = true;
            this.grdSCH3000.Rows = 2;
            this.grdSCH3000.ToolTipActive = true;
            this.grdSCH3000.UseDefaultTransaction = false;
            this.grdSCH3000.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdSCH3000_PreSaveLayout);
            this.grdSCH3000.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSCH3000_QueryStarting);
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "jukyong_date";
            this.xEditGridCell40.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "jundal_table";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "jundal_part";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "gumsaja";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.ApplyPaintingEvent = true;
            this.xEditGridCell13.CellName = "yoil_gubun";
            this.xEditGridCell13.CellWidth = 68;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "start_time";
            this.xEditGridCell37.CellWidth = 83;
            this.xEditGridCell37.Col = 1;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsNotNull = true;
            this.xEditGridCell37.Mask = "##:##";
            this.xEditGridCell37.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "end_time";
            this.xEditGridCell14.CellWidth = 77;
            this.xEditGridCell14.Col = 2;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsNotNull = true;
            this.xEditGridCell14.Mask = "##:##";
            this.xEditGridCell14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "inwon";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell16.Col = 3;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsNotNull = true;
            this.xEditGridCell16.MaxinumCipher = 2;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "add_inwon";
            this.xEditGridCell18.CellWidth = 67;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            this.xEditGridCell18.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "out_hosp_slot";
            this.xEditGridCell55.CellWidth = 118;
            this.xEditGridCell55.Col = 4;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grdSCH0001
            // 
            resources.ApplyResources(this.grdSCH0001, "grdSCH0001");
            this.grdSCH0001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell12,
            this.xEditGridCell51,
            this.xEditGridCell3,
            this.xEditGridCell50,
            this.xEditGridCell21,
            this.xEditGridCell41,
            this.xEditGridCell53});
            this.grdSCH0001.ColPerLine = 3;
            this.grdSCH0001.ColResizable = true;
            this.grdSCH0001.Cols = 4;
            this.grdSCH0001.ExecuteQuery = null;
            this.grdSCH0001.FixedCols = 1;
            this.grdSCH0001.FixedRows = 1;
            this.grdSCH0001.FocusColumnName = "jundal_part";
            this.grdSCH0001.HeaderHeights.Add(28);
            this.grdSCH0001.Name = "grdSCH0001";
            this.grdSCH0001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSCH0001.ParamList")));
            this.grdSCH0001.RowHeaderVisible = true;
            this.grdSCH0001.Rows = 2;
            this.grdSCH0001.ToolTipActive = true;
            this.grdSCH0001.UseDefaultTransaction = false;
            this.grdSCH0001.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdSCH0001_GridColumnChanged);
            this.grdSCH0001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdSCH0001_RowFocusChanged);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "jundal_table";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "jundal_part";
            this.xEditGridCell51.CellWidth = 124;
            this.xEditGridCell51.Col = 1;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsUpdatable = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "gumsaja";
            this.xEditGridCell3.CellWidth = 52;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "gumsaja_name";
            this.xEditGridCell50.CellWidth = 74;
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsReadOnly = true;
            this.xEditGridCell50.IsUpdatable = false;
            this.xEditGridCell50.IsUpdCol = false;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellLen = 30;
            this.xEditGridCell21.CellName = "jundal_part_name";
            this.xEditGridCell21.CellWidth = 139;
            this.xEditGridCell21.Col = 2;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "gwa_gubun";
            this.xEditGridCell41.CellWidth = 35;
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            this.xEditGridCell41.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellLen = 3;
            this.xEditGridCell53.CellName = "gumsa_time";
            this.xEditGridCell53.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell53.CellWidth = 66;
            this.xEditGridCell53.Col = 3;
            this.xEditGridCell53.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.MaxinumCipher = 3;
            // 
            // fbxHangmogCode
            // 
            this.fbxHangmogCode.ExecuteQuery = null;
            this.fbxHangmogCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fbxHangmogCode.ParamList")));
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.xLabel12);
            this.xPanel1.Controls.Add(this.cboGumsa);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xLabel12
            // 
            this.xLabel12.AccessibleDescription = null;
            this.xLabel12.AccessibleName = null;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.Image = null;
            this.xLabel12.Name = "xLabel12";
            // 
            // cboGumsa
            // 
            this.cboGumsa.AccessibleDescription = null;
            this.cboGumsa.AccessibleName = null;
            resources.ApplyResources(this.cboGumsa, "cboGumsa");
            this.cboGumsa.BackgroundImage = null;
            this.cboGumsa.ExecuteQuery = null;
            this.cboGumsa.Name = "cboGumsa";
            this.cboGumsa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboGumsa.ParamList")));
            this.cboGumsa.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboGumsa.SelectedValueChanged += new System.EventHandler(this.cboGumsa_SelectedValueChanged);
            // 
            // xPanel8
            // 
            this.xPanel8.AccessibleDescription = null;
            this.xPanel8.AccessibleName = null;
            resources.ApplyResources(this.xPanel8, "xPanel8");
            this.xPanel8.BackgroundImage = null;
            this.xPanel8.Controls.Add(this.xPanel9);
            this.xPanel8.Controls.Add(this.grdSCH3100);
            this.xPanel8.Controls.Add(this.xLabel9);
            this.xPanel8.Controls.Add(this.xLabel5);
            this.xPanel8.DrawBorder = true;
            this.xPanel8.Font = null;
            this.xPanel8.Name = "xPanel8";
            // 
            // xPanel9
            // 
            this.xPanel9.AccessibleDescription = null;
            this.xPanel9.AccessibleName = null;
            resources.ApplyResources(this.xPanel9, "xPanel9");
            this.xPanel9.BackgroundImage = null;
            this.xPanel9.Controls.Add(this.grdSCH3101);
            this.xPanel9.Controls.Add(this.xPanel6);
            this.xPanel9.DrawBorder = true;
            this.xPanel9.Font = null;
            this.xPanel9.Name = "xPanel9";
            // 
            // grdSCH3101
            // 
            resources.ApplyResources(this.grdSCH3101, "grdSCH3101");
            this.grdSCH3101.CallerID = '5';
            this.grdSCH3101.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell29,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell9,
            this.xEditGridCell30});
            this.grdSCH3101.ColPerLine = 3;
            this.grdSCH3101.Cols = 4;
            this.grdSCH3101.ExecuteQuery = null;
            this.grdSCH3101.FixedCols = 1;
            this.grdSCH3101.FixedRows = 1;
            this.grdSCH3101.HeaderHeights.Add(21);
            this.grdSCH3101.Name = "grdSCH3101";
            this.grdSCH3101.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSCH3101.ParamList")));
            this.grdSCH3101.RowHeaderVisible = true;
            this.grdSCH3101.Rows = 2;
            this.grdSCH3101.ToolTipActive = true;
            this.grdSCH3101.UseDefaultTransaction = false;
            this.grdSCH3101.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdSCH3101_PreSaveLayout);
            this.grdSCH3101.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSCH3101_QueryStarting);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "jundal_table";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "jundal_part";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "gumsaja";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "reser_date";
            this.xEditGridCell33.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "start_time";
            this.xEditGridCell6.CellWidth = 110;
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsNotNull = true;
            this.xEditGridCell6.Mask = "##:##";
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "end_time";
            this.xEditGridCell7.CellWidth = 110;
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsNotNull = true;
            this.xEditGridCell7.Mask = "##:##";
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "inwon";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell9.CellWidth = 60;
            this.xEditGridCell9.Col = 3;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsNotNull = true;
            this.xEditGridCell9.MaxinumCipher = 2;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "add_inwon";
            this.xEditGridCell30.CellWidth = 70;
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            this.xEditGridCell30.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel6
            // 
            this.xPanel6.AccessibleDescription = null;
            this.xPanel6.AccessibleName = null;
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.BackgroundImage = null;
            this.xPanel6.Controls.Add(this.btnMake2);
            this.xPanel6.Controls.Add(this.xemRow2);
            this.xPanel6.Controls.Add(this.xLabel3);
            this.xPanel6.Controls.Add(this.xLabel22);
            this.xPanel6.Controls.Add(this.xLabel10);
            this.xPanel6.Controls.Add(this.xLabel19);
            this.xPanel6.Controls.Add(this.xLabel15);
            this.xPanel6.Controls.Add(this.xemInwon2);
            this.xPanel6.Controls.Add(this.xLabel21);
            this.xPanel6.Controls.Add(this.dtpJukyongDate2);
            this.xPanel6.Controls.Add(this.xemTime2);
            this.xPanel6.Controls.Add(this.xemSpaceTime2);
            this.xPanel6.Controls.Add(this.xLabel11);
            this.xPanel6.Controls.Add(this.xLabel8);
            this.xPanel6.Font = null;
            this.xPanel6.Name = "xPanel6";
            // 
            // btnMake2
            // 
            this.btnMake2.AccessibleDescription = null;
            this.btnMake2.AccessibleName = null;
            resources.ApplyResources(this.btnMake2, "btnMake2");
            this.btnMake2.BackgroundImage = null;
            this.btnMake2.Name = "btnMake2";
            this.btnMake2.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnMake2.Click += new System.EventHandler(this.btnMake2_Click);
            // 
            // xemRow2
            // 
            this.xemRow2.AccessibleDescription = null;
            this.xemRow2.AccessibleName = null;
            resources.ApplyResources(this.xemRow2, "xemRow2");
            this.xemRow2.BackgroundImage = null;
            this.xemRow2.EditMaskType = IHIS.Framework.MaskType.Number;
            this.xemRow2.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.xemRow2.Font = null;
            this.xemRow2.IsVietnameseYearType = false;
            this.xemRow2.Name = "xemRow2";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Font = null;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel22
            // 
            this.xLabel22.AccessibleDescription = null;
            this.xLabel22.AccessibleName = null;
            resources.ApplyResources(this.xLabel22, "xLabel22");
            this.xLabel22.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel22.EdgeRounding = false;
            this.xLabel22.Font = null;
            this.xLabel22.Image = null;
            this.xLabel22.Name = "xLabel22";
            // 
            // xLabel10
            // 
            this.xLabel10.AccessibleDescription = null;
            this.xLabel10.AccessibleName = null;
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.Font = null;
            this.xLabel10.Image = null;
            this.xLabel10.Name = "xLabel10";
            // 
            // xLabel19
            // 
            this.xLabel19.AccessibleDescription = null;
            this.xLabel19.AccessibleName = null;
            resources.ApplyResources(this.xLabel19, "xLabel19");
            this.xLabel19.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel19.EdgeRounding = false;
            this.xLabel19.Font = null;
            this.xLabel19.Image = null;
            this.xLabel19.Name = "xLabel19";
            // 
            // xLabel15
            // 
            this.xLabel15.AccessibleDescription = null;
            this.xLabel15.AccessibleName = null;
            resources.ApplyResources(this.xLabel15, "xLabel15");
            this.xLabel15.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel15.EdgeRounding = false;
            this.xLabel15.Font = null;
            this.xLabel15.Image = null;
            this.xLabel15.Name = "xLabel15";
            // 
            // xemInwon2
            // 
            this.xemInwon2.AccessibleDescription = null;
            this.xemInwon2.AccessibleName = null;
            resources.ApplyResources(this.xemInwon2, "xemInwon2");
            this.xemInwon2.BackgroundImage = null;
            this.xemInwon2.EditMaskType = IHIS.Framework.MaskType.Number;
            this.xemInwon2.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.xemInwon2.Font = null;
            this.xemInwon2.IsVietnameseYearType = false;
            this.xemInwon2.Name = "xemInwon2";
            // 
            // xLabel21
            // 
            this.xLabel21.AccessibleDescription = null;
            this.xLabel21.AccessibleName = null;
            resources.ApplyResources(this.xLabel21, "xLabel21");
            this.xLabel21.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel21.Font = null;
            this.xLabel21.ForeColor = IHIS.Framework.XColor.NormalBorderColor;
            this.xLabel21.Image = null;
            this.xLabel21.Name = "xLabel21";
            // 
            // dtpJukyongDate2
            // 
            this.dtpJukyongDate2.AccessibleDescription = null;
            this.dtpJukyongDate2.AccessibleName = null;
            resources.ApplyResources(this.dtpJukyongDate2, "dtpJukyongDate2");
            this.dtpJukyongDate2.BackgroundImage = null;
            this.dtpJukyongDate2.Font = null;
            this.dtpJukyongDate2.IsJapanYearType = true;
            this.dtpJukyongDate2.IsVietnameseYearType = false;
            this.dtpJukyongDate2.Name = "dtpJukyongDate2";
            // 
            // xemTime2
            // 
            this.xemTime2.AccessibleDescription = null;
            this.xemTime2.AccessibleName = null;
            resources.ApplyResources(this.xemTime2, "xemTime2");
            this.xemTime2.BackgroundImage = null;
            this.xemTime2.EditMaskType = IHIS.Framework.MaskType.Time;
            this.xemTime2.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.xemTime2.Font = null;
            this.xemTime2.IsVietnameseYearType = false;
            this.xemTime2.Mask = "HH:MI";
            this.xemTime2.Name = "xemTime2";
            // 
            // xemSpaceTime2
            // 
            this.xemSpaceTime2.AccessibleDescription = null;
            this.xemSpaceTime2.AccessibleName = null;
            resources.ApplyResources(this.xemSpaceTime2, "xemSpaceTime2");
            this.xemSpaceTime2.BackgroundImage = null;
            this.xemSpaceTime2.EditMaskType = IHIS.Framework.MaskType.Number;
            this.xemSpaceTime2.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.xemSpaceTime2.Font = null;
            this.xemSpaceTime2.IsVietnameseYearType = false;
            this.xemSpaceTime2.Name = "xemSpaceTime2";
            // 
            // xLabel11
            // 
            this.xLabel11.AccessibleDescription = null;
            this.xLabel11.AccessibleName = null;
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel11.Font = null;
            this.xLabel11.ForeColor = IHIS.Framework.XColor.NormalBorderColor;
            this.xLabel11.Image = null;
            this.xLabel11.Name = "xLabel11";
            // 
            // xLabel8
            // 
            this.xLabel8.AccessibleDescription = null;
            this.xLabel8.AccessibleName = null;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel8.Font = null;
            this.xLabel8.ForeColor = IHIS.Framework.XColor.NormalBorderColor;
            this.xLabel8.Image = null;
            this.xLabel8.Name = "xLabel8";
            // 
            // grdSCH3100
            // 
            resources.ApplyResources(this.grdSCH3100, "grdSCH3100");
            this.grdSCH3100.CallerID = '4';
            this.grdSCH3100.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell17,
            this.xEditGridCell24,
            this.xEditGridCell28,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdSCH3100.ColPerLine = 2;
            this.grdSCH3100.Cols = 3;
            this.grdSCH3100.ControlBinding = true;
            this.grdSCH3100.ExecuteQuery = null;
            this.grdSCH3100.FixedCols = 1;
            this.grdSCH3100.FixedRows = 1;
            this.grdSCH3100.HeaderHeights.Add(30);
            this.grdSCH3100.Name = "grdSCH3100";
            this.grdSCH3100.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSCH3100.ParamList")));
            this.grdSCH3100.RowHeaderVisible = true;
            this.grdSCH3100.Rows = 2;
            this.grdSCH3100.ToolTipActive = true;
            this.grdSCH3100.UseDefaultTransaction = false;
            this.grdSCH3100.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdSCH3100_RowFocusChanged);
            this.grdSCH3100.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSCH3100_QueryStarting);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "jundal_table";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "jundal_part";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "gumsaja";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsUpdatable = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.BindControl = this.dtpJukyongDate2;
            this.xEditGridCell4.CellName = "reser_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 140;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsNotNull = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "reser_yn";
            this.xEditGridCell5.CellWidth = 98;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel9
            // 
            this.xLabel9.AccessibleDescription = null;
            this.xLabel9.AccessibleName = null;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel9.Font = null;
            this.xLabel9.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel9.Image = null;
            this.xLabel9.Name = "xLabel9";
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel5.Font = null;
            this.xLabel5.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.xPanel8);
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // grdJukyongDate
            // 
            resources.ApplyResources(this.grdJukyongDate, "grdJukyongDate");
            this.grdJukyongDate.CallerID = '6';
            this.grdJukyongDate.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48});
            this.grdJukyongDate.ColPerLine = 8;
            this.grdJukyongDate.Cols = 9;
            this.grdJukyongDate.ControlBinding = true;
            this.grdJukyongDate.ExecuteQuery = null;
            this.grdJukyongDate.FixedCols = 1;
            this.grdJukyongDate.FixedRows = 1;
            this.grdJukyongDate.HeaderHeights.Add(29);
            this.grdJukyongDate.Name = "grdJukyongDate";
            this.grdJukyongDate.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdJukyongDate.ParamList")));
            this.grdJukyongDate.RowHeaderVisible = true;
            this.grdJukyongDate.Rows = 2;
            this.grdJukyongDate.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdJukyongDate.ToolTipActive = true;
            this.grdJukyongDate.UseDefaultTransaction = false;
            this.grdJukyongDate.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdJukyongDate_RowFocusChanged);
            this.grdJukyongDate.GridCellFocusChanged += new IHIS.Framework.XGridCellFocusChangedEventHandler(this.grdJukyongDate_GridCellFocusChanged);
            this.grdJukyongDate.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdJukyongDate_QueryStarting);
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.BindControl = this.dtpJukyongDate1;
            this.xEditGridCell34.CellName = "jukyong_date";
            this.xEditGridCell34.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell34.CellWidth = 97;
            this.xEditGridCell34.Col = 1;
            this.xEditGridCell34.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            // 
            // dtpJukyongDate1
            // 
            this.dtpJukyongDate1.AccessibleDescription = null;
            this.dtpJukyongDate1.AccessibleName = null;
            resources.ApplyResources(this.dtpJukyongDate1, "dtpJukyongDate1");
            this.dtpJukyongDate1.BackgroundImage = null;
            this.dtpJukyongDate1.IsVietnameseYearType = false;
            this.dtpJukyongDate1.Name = "dtpJukyongDate1";
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "jundal_table";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "jundal_part";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "gumsaja";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "old_jukyong_date";
            this.xEditGridCell39.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "mon";
            this.xEditGridCell42.CellWidth = 30;
            this.xEditGridCell42.Col = 2;
            this.xEditGridCell42.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsReadOnly = true;
            this.xEditGridCell42.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "tue";
            this.xEditGridCell43.CellWidth = 23;
            this.xEditGridCell43.Col = 3;
            this.xEditGridCell43.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsReadOnly = true;
            this.xEditGridCell43.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "wed";
            this.xEditGridCell44.CellWidth = 31;
            this.xEditGridCell44.Col = 4;
            this.xEditGridCell44.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsReadOnly = true;
            this.xEditGridCell44.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "thu";
            this.xEditGridCell45.CellWidth = 25;
            this.xEditGridCell45.Col = 5;
            this.xEditGridCell45.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsReadOnly = true;
            this.xEditGridCell45.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "fri";
            this.xEditGridCell46.CellWidth = 26;
            this.xEditGridCell46.Col = 6;
            this.xEditGridCell46.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsReadOnly = true;
            this.xEditGridCell46.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "sat";
            this.xEditGridCell47.CellWidth = 23;
            this.xEditGridCell47.Col = 7;
            this.xEditGridCell47.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsReadOnly = true;
            this.xEditGridCell47.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "sun";
            this.xEditGridCell48.CellWidth = 23;
            this.xEditGridCell48.Col = 8;
            this.xEditGridCell48.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsReadOnly = true;
            this.xEditGridCell48.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel5
            // 
            this.xPanel5.AccessibleDescription = null;
            this.xPanel5.AccessibleName = null;
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.BackgroundImage = null;
            this.xPanel5.Controls.Add(this.xPanel7);
            this.xPanel5.Name = "xPanel5";
            // 
            // xPanel7
            // 
            this.xPanel7.AccessibleDescription = null;
            this.xPanel7.AccessibleName = null;
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.BackgroundImage = null;
            this.xPanel7.Controls.Add(this.grdSCH3000);
            this.xPanel7.Controls.Add(this.xPanel2);
            this.xPanel7.DrawBorder = true;
            this.xPanel7.Font = null;
            this.xPanel7.Name = "xPanel7";
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.xEditMask1);
            this.xPanel2.Controls.Add(this.xLabel23);
            this.xPanel2.Controls.Add(this.xLabel25);
            this.xPanel2.Controls.Add(this.xemRow1);
            this.xPanel2.Controls.Add(this.xemSpaceTime1);
            this.xPanel2.Controls.Add(this.xemInwon1);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.xLabel16);
            this.xPanel2.Controls.Add(this.xLabel4);
            this.xPanel2.Controls.Add(this.xLabel20);
            this.xPanel2.Controls.Add(this.xLabel24);
            this.xPanel2.Controls.Add(this.xLabel17);
            this.xPanel2.Controls.Add(this.cbx1);
            this.xPanel2.Controls.Add(this.cbx7);
            this.xPanel2.Controls.Add(this.cbx6);
            this.xPanel2.Controls.Add(this.cbx5);
            this.xPanel2.Controls.Add(this.cbx4);
            this.xPanel2.Controls.Add(this.cbx3);
            this.xPanel2.Controls.Add(this.cbx2);
            this.xPanel2.Controls.Add(this.xLabel14);
            this.xPanel2.Controls.Add(this.dtpJukyongDate1);
            this.xPanel2.Controls.Add(this.btnMake1);
            this.xPanel2.Controls.Add(this.xLabel7);
            this.xPanel2.Controls.Add(this.xLabel6);
            this.xPanel2.Controls.Add(this.xemTime1);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // xEditMask1
            // 
            this.xEditMask1.AccessibleDescription = null;
            this.xEditMask1.AccessibleName = null;
            resources.ApplyResources(this.xEditMask1, "xEditMask1");
            this.xEditMask1.BackgroundImage = null;
            this.xEditMask1.EditMaskType = IHIS.Framework.MaskType.Number;
            this.xEditMask1.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.xEditMask1.IsVietnameseYearType = false;
            this.xEditMask1.Name = "xEditMask1";
            // 
            // xLabel23
            // 
            this.xLabel23.AccessibleDescription = null;
            this.xLabel23.AccessibleName = null;
            resources.ApplyResources(this.xLabel23, "xLabel23");
            this.xLabel23.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel23.EdgeRounding = false;
            this.xLabel23.Image = null;
            this.xLabel23.Name = "xLabel23";
            // 
            // xLabel25
            // 
            this.xLabel25.AccessibleDescription = null;
            this.xLabel25.AccessibleName = null;
            resources.ApplyResources(this.xLabel25, "xLabel25");
            this.xLabel25.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel25.ForeColor = IHIS.Framework.XColor.NormalBorderColor;
            this.xLabel25.Image = null;
            this.xLabel25.Name = "xLabel25";
            // 
            // xemRow1
            // 
            this.xemRow1.AccessibleDescription = null;
            this.xemRow1.AccessibleName = null;
            resources.ApplyResources(this.xemRow1, "xemRow1");
            this.xemRow1.BackgroundImage = null;
            this.xemRow1.EditMaskType = IHIS.Framework.MaskType.Number;
            this.xemRow1.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.xemRow1.IsVietnameseYearType = false;
            this.xemRow1.Name = "xemRow1";
            // 
            // xemSpaceTime1
            // 
            this.xemSpaceTime1.AccessibleDescription = null;
            this.xemSpaceTime1.AccessibleName = null;
            resources.ApplyResources(this.xemSpaceTime1, "xemSpaceTime1");
            this.xemSpaceTime1.BackgroundImage = null;
            this.xemSpaceTime1.EditMaskType = IHIS.Framework.MaskType.Number;
            this.xemSpaceTime1.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.xemSpaceTime1.IsVietnameseYearType = false;
            this.xemSpaceTime1.Name = "xemSpaceTime1";
            // 
            // xemInwon1
            // 
            this.xemInwon1.AccessibleDescription = null;
            this.xemInwon1.AccessibleName = null;
            resources.ApplyResources(this.xemInwon1, "xemInwon1");
            this.xemInwon1.BackgroundImage = null;
            this.xemInwon1.EditMaskType = IHIS.Framework.MaskType.Number;
            this.xemInwon1.EditVietnameseMaskType = IHIS.Framework.MaskType.Number;
            this.xemInwon1.IsVietnameseYearType = false;
            this.xemInwon1.Name = "xemInwon1";
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel16
            // 
            this.xLabel16.AccessibleDescription = null;
            this.xLabel16.AccessibleName = null;
            resources.ApplyResources(this.xLabel16, "xLabel16");
            this.xLabel16.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel16.EdgeRounding = false;
            this.xLabel16.Image = null;
            this.xLabel16.Name = "xLabel16";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel20
            // 
            this.xLabel20.AccessibleDescription = null;
            this.xLabel20.AccessibleName = null;
            resources.ApplyResources(this.xLabel20, "xLabel20");
            this.xLabel20.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel20.EdgeRounding = false;
            this.xLabel20.Image = null;
            this.xLabel20.Name = "xLabel20";
            // 
            // xLabel24
            // 
            this.xLabel24.AccessibleDescription = null;
            this.xLabel24.AccessibleName = null;
            resources.ApplyResources(this.xLabel24, "xLabel24");
            this.xLabel24.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel24.EdgeRounding = false;
            this.xLabel24.Image = null;
            this.xLabel24.Name = "xLabel24";
            // 
            // xLabel17
            // 
            this.xLabel17.AccessibleDescription = null;
            this.xLabel17.AccessibleName = null;
            resources.ApplyResources(this.xLabel17, "xLabel17");
            this.xLabel17.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel17.ForeColor = IHIS.Framework.XColor.NormalBorderColor;
            this.xLabel17.Image = null;
            this.xLabel17.Name = "xLabel17";
            // 
            // cbx1
            // 
            this.cbx1.AccessibleDescription = null;
            this.cbx1.AccessibleName = null;
            resources.ApplyResources(this.cbx1, "cbx1");
            this.cbx1.BackgroundImage = null;
            this.cbx1.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.cbx1.Name = "cbx1";
            this.cbx1.UseVisualStyleBackColor = false;
            // 
            // cbx7
            // 
            this.cbx7.AccessibleDescription = null;
            this.cbx7.AccessibleName = null;
            resources.ApplyResources(this.cbx7, "cbx7");
            this.cbx7.BackgroundImage = null;
            this.cbx7.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.cbx7.Name = "cbx7";
            this.cbx7.UseVisualStyleBackColor = false;
            // 
            // cbx6
            // 
            this.cbx6.AccessibleDescription = null;
            this.cbx6.AccessibleName = null;
            resources.ApplyResources(this.cbx6, "cbx6");
            this.cbx6.BackgroundImage = null;
            this.cbx6.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.cbx6.Name = "cbx6";
            this.cbx6.UseVisualStyleBackColor = false;
            // 
            // cbx5
            // 
            this.cbx5.AccessibleDescription = null;
            this.cbx5.AccessibleName = null;
            resources.ApplyResources(this.cbx5, "cbx5");
            this.cbx5.BackgroundImage = null;
            this.cbx5.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.cbx5.Name = "cbx5";
            this.cbx5.UseVisualStyleBackColor = false;
            // 
            // cbx4
            // 
            this.cbx4.AccessibleDescription = null;
            this.cbx4.AccessibleName = null;
            resources.ApplyResources(this.cbx4, "cbx4");
            this.cbx4.BackgroundImage = null;
            this.cbx4.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.cbx4.Name = "cbx4";
            this.cbx4.UseVisualStyleBackColor = false;
            // 
            // cbx3
            // 
            this.cbx3.AccessibleDescription = null;
            this.cbx3.AccessibleName = null;
            resources.ApplyResources(this.cbx3, "cbx3");
            this.cbx3.BackgroundImage = null;
            this.cbx3.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.cbx3.Name = "cbx3";
            this.cbx3.UseVisualStyleBackColor = false;
            // 
            // cbx2
            // 
            this.cbx2.AccessibleDescription = null;
            this.cbx2.AccessibleName = null;
            resources.ApplyResources(this.cbx2, "cbx2");
            this.cbx2.BackgroundImage = null;
            this.cbx2.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.cbx2.Name = "cbx2";
            this.cbx2.UseVisualStyleBackColor = false;
            // 
            // xLabel14
            // 
            this.xLabel14.AccessibleDescription = null;
            this.xLabel14.AccessibleName = null;
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel14.EdgeRounding = false;
            this.xLabel14.Image = null;
            this.xLabel14.Name = "xLabel14";
            // 
            // btnMake1
            // 
            this.btnMake1.AccessibleDescription = null;
            this.btnMake1.AccessibleName = null;
            resources.ApplyResources(this.btnMake1, "btnMake1");
            this.btnMake1.BackgroundImage = null;
            this.btnMake1.Name = "btnMake1";
            this.btnMake1.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnMake1.Click += new System.EventHandler(this.btnMake1_Click);
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel7.ForeColor = IHIS.Framework.XColor.NormalBorderColor;
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel6.ForeColor = IHIS.Framework.XColor.NormalBorderColor;
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            // 
            // xemTime1
            // 
            this.xemTime1.AccessibleDescription = null;
            this.xemTime1.AccessibleName = null;
            resources.ApplyResources(this.xemTime1, "xemTime1");
            this.xemTime1.BackgroundImage = null;
            this.xemTime1.EditMaskType = IHIS.Framework.MaskType.Time;
            this.xemTime1.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.xemTime1.IsVietnameseYearType = false;
            this.xemTime1.Mask = "HH:MI";
            this.xemTime1.Name = "xemTime1";
            // 
            // xLabel18
            // 
            this.xLabel18.AccessibleDescription = null;
            this.xLabel18.AccessibleName = null;
            resources.ApplyResources(this.xLabel18, "xLabel18");
            this.xLabel18.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel18.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel18.EdgeRounding = false;
            this.xLabel18.Font = null;
            this.xLabel18.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel18.Image = null;
            this.xLabel18.Name = "xLabel18";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // grdSCH0002
            // 
            resources.ApplyResources(this.grdSCH0002, "grdSCH0002");
            this.grdSCH0002.CallerID = '3';
            this.grdSCH0002.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell15,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell49,
            this.xEditGridCell52});
            this.grdSCH0002.ColPerLine = 3;
            this.grdSCH0002.ColResizable = true;
            this.grdSCH0002.Cols = 4;
            this.grdSCH0002.ExecuteQuery = null;
            this.grdSCH0002.FixedCols = 1;
            this.grdSCH0002.FixedRows = 1;
            this.grdSCH0002.FocusColumnName = "hangmog_code";
            this.grdSCH0002.HeaderHeights.Add(28);
            this.grdSCH0002.Name = "grdSCH0002";
            this.grdSCH0002.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSCH0002.ParamList")));
            this.grdSCH0002.RowHeaderVisible = true;
            this.grdSCH0002.Rows = 2;
            this.grdSCH0002.ToolTipActive = true;
            this.grdSCH0002.UseDefaultTransaction = false;
            this.grdSCH0002.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdSCH0002_GridColumnChanged);
            this.grdSCH0002.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdSCH0002_GridFindClick);
            this.grdSCH0002.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSCH0002_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "jundal_table";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "jundal_part";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "gumsaja";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "hangmog_code";
            this.xEditGridCell22.CellWidth = 98;
            this.xEditGridCell22.Col = 1;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsUpdatable = false;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellLen = 80;
            this.xEditGridCell23.CellName = "hangmog_name";
            this.xEditGridCell23.CellWidth = 173;
            this.xEditGridCell23.Col = 2;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellLen = 3;
            this.xEditGridCell49.CellName = "gumsa_time";
            this.xEditGridCell49.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell49.CellWidth = 64;
            this.xEditGridCell49.Col = 3;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.MaxinumCipher = 3;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "disp_yn";
            this.xEditGridCell52.CellWidth = 31;
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "comments";
            this.xEditGridCell11.CellWidth = 238;
            this.xEditGridCell11.Col = 9;
            this.xEditGridCell11.DisplayMemoText = true;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "hangmog_name";
            this.xEditGridCell8.CellWidth = 199;
            this.xEditGridCell8.Col = 3;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "hangmog_code";
            this.xEditGridCell19.CellWidth = 84;
            this.xEditGridCell19.Col = 3;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "hangmog_name";
            this.xEditGridCell20.CellWidth = 166;
            this.xEditGridCell20.Col = 4;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "am_avg_time";
            this.xEditGridCell10.Col = 8;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            // 
            // vsvHangmogCode
            // 
            this.vsvHangmogCode.ExecuteQuery = null;
            this.vsvHangmogCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvHangmogCode.ParamList")));
            this.vsvHangmogCode.QuerySQL = "SELECT HANGMOG_NAME\r\nFROM OCS0103\r\nWHERE HANGMOG_CODE = :f_code";
            // 
            // vsvUserName
            // 
            this.vsvUserName.ExecuteQuery = null;
            this.vsvUserName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvUserName.ParamList")));
            this.vsvUserName.QuerySQL = "SELECT FN_ADM_LOAD_USER_NAME(:f_code)\r\nFROM DUAL";
            // 
            // pnlLeft
            // 
            this.pnlLeft.AccessibleDescription = null;
            this.pnlLeft.AccessibleName = null;
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.BackgroundImage = null;
            this.pnlLeft.Controls.Add(this.pnlGrdSch0002);
            this.pnlLeft.Controls.Add(this.pnlGrdSch0001);
            this.pnlLeft.Font = null;
            this.pnlLeft.Name = "pnlLeft";
            // 
            // pnlGrdSch0002
            // 
            this.pnlGrdSch0002.AccessibleDescription = null;
            this.pnlGrdSch0002.AccessibleName = null;
            resources.ApplyResources(this.pnlGrdSch0002, "pnlGrdSch0002");
            this.pnlGrdSch0002.BackgroundImage = null;
            this.pnlGrdSch0002.Controls.Add(this.grdSCH0002);
            this.pnlGrdSch0002.Controls.Add(this.xLabel1);
            this.pnlGrdSch0002.DrawBorder = true;
            this.pnlGrdSch0002.Font = null;
            this.pnlGrdSch0002.Name = "pnlGrdSch0002";
            // 
            // pnlGrdSch0001
            // 
            this.pnlGrdSch0001.AccessibleDescription = null;
            this.pnlGrdSch0001.AccessibleName = null;
            resources.ApplyResources(this.pnlGrdSch0001, "pnlGrdSch0001");
            this.pnlGrdSch0001.BackgroundImage = null;
            this.pnlGrdSch0001.Controls.Add(this.grdSCH0001);
            this.pnlGrdSch0001.Controls.Add(this.xLabel13);
            this.pnlGrdSch0001.DrawBorder = true;
            this.pnlGrdSch0001.Font = null;
            this.pnlGrdSch0001.Name = "pnlGrdSch0001";
            // 
            // xLabel13
            // 
            this.xLabel13.AccessibleDescription = null;
            this.xLabel13.AccessibleName = null;
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel13.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel13.EdgeRounding = false;
            this.xLabel13.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel13.Image = null;
            this.xLabel13.Name = "xLabel13";
            // 
            // pnlTab
            // 
            this.pnlTab.AccessibleDescription = null;
            this.pnlTab.AccessibleName = null;
            resources.ApplyResources(this.pnlTab, "pnlTab");
            this.pnlTab.BackgroundImage = null;
            this.pnlTab.Controls.Add(this.tabReserSch);
            this.pnlTab.DrawBorder = true;
            this.pnlTab.Font = null;
            this.pnlTab.Name = "pnlTab";
            // 
            // tabReserSch
            // 
            this.tabReserSch.AccessibleDescription = null;
            this.tabReserSch.AccessibleName = null;
            resources.ApplyResources(this.tabReserSch, "tabReserSch");
            this.tabReserSch.BackgroundImage = null;
            this.tabReserSch.Font = null;
            this.tabReserSch.IDEPixelArea = false;
            this.tabReserSch.IDEPixelBorder = false;
            this.tabReserSch.Name = "tabReserSch";
            this.tabReserSch.SelectedIndex = 0;
            this.tabReserSch.SelectedTab = this.tabPage1;
            this.tabReserSch.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            // 
            // tabPage1
            // 
            this.tabPage1.AccessibleDescription = null;
            this.tabPage1.AccessibleName = null;
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.BackgroundImage = null;
            this.tabPage1.Controls.Add(this.pnlReserSchedule);
            this.tabPage1.Font = null;
            this.tabPage1.Name = "tabPage1";
            // 
            // pnlReserSchedule
            // 
            this.pnlReserSchedule.AccessibleDescription = null;
            this.pnlReserSchedule.AccessibleName = null;
            resources.ApplyResources(this.pnlReserSchedule, "pnlReserSchedule");
            this.pnlReserSchedule.BackgroundImage = null;
            this.pnlReserSchedule.Controls.Add(this.xPanel11);
            this.pnlReserSchedule.Controls.Add(this.xLabel18);
            this.pnlReserSchedule.Font = null;
            this.pnlReserSchedule.Name = "pnlReserSchedule";
            // 
            // xPanel11
            // 
            this.xPanel11.AccessibleDescription = null;
            this.xPanel11.AccessibleName = null;
            resources.ApplyResources(this.xPanel11, "xPanel11");
            this.xPanel11.BackgroundImage = null;
            this.xPanel11.Controls.Add(this.xPanel5);
            this.xPanel11.Controls.Add(this.grdJukyongDate);
            this.xPanel11.Font = null;
            this.xPanel11.Name = "xPanel11";
            // 
            // tabPage2
            // 
            this.tabPage2.AccessibleDescription = null;
            this.tabPage2.AccessibleName = null;
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.BackgroundImage = null;
            this.tabPage2.Controls.Add(this.xPanel4);
            this.tabPage2.Font = null;
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            // 
            // laySaveSCH3000
            // 
            this.laySaveSCH3000.CallerID = '2';
            this.laySaveSCH3000.ExecuteQuery = null;
            this.laySaveSCH3000.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9});
            this.laySaveSCH3000.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySaveSCH3000.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "jukyong_date";
            this.multiLayoutItem1.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem1.IsUpdItem = true;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "jundal_table";
            this.multiLayoutItem2.IsUpdItem = true;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "jundal_part";
            this.multiLayoutItem3.IsUpdItem = true;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "gumsaja";
            this.multiLayoutItem4.IsUpdItem = true;
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "yoil_gubun";
            this.multiLayoutItem5.IsUpdItem = true;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "start_time";
            this.multiLayoutItem6.IsUpdItem = true;
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "end_time";
            this.multiLayoutItem7.IsUpdItem = true;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "inwon";
            this.multiLayoutItem8.IsUpdItem = true;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "add_inwon";
            this.multiLayoutItem9.IsUpdItem = true;
            // 
            // layDupOCS0103
            // 
            this.layDupOCS0103.ExecuteQuery = null;
            this.layDupOCS0103.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layDupOCS0103.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupOCS0103.ParamList")));
            this.layDupOCS0103.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDupOCS0103_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "dup_yn";
            // 
            // SCH3001U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlTab);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.MaximumSize = new System.Drawing.Size(1233, 780);
            this.Name = "SCH3001U00";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SCH3001U00_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSCH3000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSCH0001)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel8.ResumeLayout(false);
            this.xPanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSCH3101)).EndInit();
            this.xPanel6.ResumeLayout(false);
            this.xPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSCH3100)).EndInit();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdJukyongDate)).EndInit();
            this.xPanel5.ResumeLayout(false);
            this.xPanel7.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSCH0002)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlGrdSch0002.ResumeLayout(false);
            this.pnlGrdSch0001.ResumeLayout(false);
            this.pnlTab.ResumeLayout(false);
            this.tabReserSch.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnlReserSchedule.ResumeLayout(false);
            this.xPanel11.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.laySaveSCH3000)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
        bool mIsLoaded = false;
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			if (this.OpenParam != null ) 
			{
				//this.cbxJundalPart.SetDataValue(this.OpenParam["jundal_part"].ToString());
			}
            DateTime sysDate = EnvironInfo.GetSysDate();

            this.cboGumsa.SelectedIndex = 0;
            
            this.dtpJukyongDate1.SetDataValue(sysDate);
            this.dtpJukyongDate2.SetDataValue(sysDate);
            mIsLoaded = true;
			grdSCH0001_Query();

           
		}
		#endregion

        public override object Command(string command, CommonItemCollection commandParam)
        {
            #region
            if (commandParam.Contains("OCS0103") && (MultiLayout)commandParam["OCS0103"] != null &&
                ((MultiLayout)commandParam["OCS0103"]).RowCount > 0)
            {
                int set_row = -1;

                if (this.grdSCH0002.CurrentRowNumber >= 0)
                    set_row = this.grdSCH0002.CurrentRowNumber;

                int cnt = 0;

                foreach (DataRow row in ((MultiLayout)commandParam["OCS0103"]).LayoutTable.Rows)
                {
                    string hangmog_code = row["hangmog_code"].ToString();
                    string hangmog_name = row["hangmog_name"].ToString();

                    if (cnt != 0)
                    {
                        set_row = grdSCH0002.InsertRow();
                    }

                    this.grdSCH0002.SetItemValue(set_row, "hangmog_name", hangmog_name);
                    this.grdSCH0002.SetFocusToItem(set_row, "hangmog_code");
                    this.grdSCH0002.SetEditorValue(hangmog_code);


                    grdSCH0002.SetItemValue(set_row, "jundal_table", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_table"));
                    grdSCH0002.SetItemValue(set_row, "jundal_part", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_part"));
                    grdSCH0002.SetItemValue(set_row, "gumsaja", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "gumsaja")); //무조건 %
                    grdSCH0002.AcceptData();

                    cnt++;
                }

                grdSCH0002.AcceptData();
            }

            #endregion

            return base.Command(command, commandParam);
        }

		#region fields
		string mStartDay = EnvironInfo.GetSysDate().DayOfWeek.ToString();
		//string mYoilGubun = "";
		#endregion

		#region 기본버튼
        private bool mIsSaveSuccess = true;
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			string jundal_table = ""; 
            jundal_table = this.cboGumsa.GetDataValue();

            selectedYoil.Clear();

            if (cbx2.Checked) selectedYoil.Add("2"); //yoil_gubun = "1";
            if (cbx3.Checked) selectedYoil.Add("3"); //yoil_gubun = "2";
            if (cbx4.Checked) selectedYoil.Add("4"); //yoil_gubun = "3";
            if (cbx5.Checked) selectedYoil.Add("5"); //yoil_gubun = "4";
            if (cbx6.Checked) selectedYoil.Add("6"); //yoil_gubun = "5";
            if (cbx7.Checked) selectedYoil.Add("7"); //yoil_gubun = "6";
            if (cbx1.Checked) selectedYoil.Add("1"); //yoil_gubun = "7";

			switch( e.Func )
			{
				case FunctionType.Update:
                    e.IsBaseCall = false; 
                    mIsSaveSuccess = true;
					
                    if(!PreSave())
					{
						e.IsSuccess = false;
						break;
					}

                    for (int i = 0; i < grdSCH3000.RowCount; i++)
                    {
                        if (this.grdSCH3000.GetItemString(i, "start_time") == "")
                        {
                            XMessageBox.Show(Resources.MSG001_MSG, Resources.MSG001_CAP, MessageBoxIcon.Error);
                            this.tabReserSch.SelectedTab = this.tabPage1;
                            this.grdSCH3000.SetFocusToItem(i, "start_time");
                            e.IsSuccess = false;
                            return;
                        }

                        if (this.grdSCH3000.GetItemString(i, "end_time") == "")
                        {
                            XMessageBox.Show(Resources.MSG002_MSG, Resources.MSG001_CAP, MessageBoxIcon.Error);
                            this.tabReserSch.SelectedTab = this.tabPage1;
                            this.grdSCH3000.SetFocusToItem(i, "end_time");
                            e.IsSuccess = false;
                            return;
                        }

                        if (this.grdSCH3000.GetItemString(i, "inwon") == "")
                        {
                            XMessageBox.Show(Resources.MSG003_MSG, Resources.MSG001_CAP, MessageBoxIcon.Error);
                            this.tabReserSch.SelectedTab = this.tabPage1;
                            this.grdSCH3000.SetFocusToItem(i, "inwon");
                            e.IsSuccess = false;
                            return;
                        }
                    }

                    for (int i = 0; i < grdSCH3100.RowCount; i++)
                    {
                        if (this.grdSCH3100.GetItemString(i, "reser_date") == "")
                        {
                            XMessageBox.Show(Resources.MSG004_MSG, Resources.MSG001_CAP, MessageBoxIcon.Error);
                            this.tabReserSch.SelectedTab = this.tabPage2;
                            this.grdSCH3100.SetFocusToItem(i, "reser_date");
                            e.IsSuccess = false;
                            return;
                        }
                    }

                    for (int i = 0; i < grdSCH3101.RowCount; i++)
                    {
                        if (this.grdSCH3101.GetItemString(i, "start_time") == "")
                        {
                            XMessageBox.Show(Resources.MSG001_MSG, Resources.MSG001_CAP, MessageBoxIcon.Error);
                            this.tabReserSch.SelectedTab = this.tabPage2;
                            this.grdSCH3101.SetFocusToItem(i, "start_time");
                            e.IsSuccess = false;
                            return;
                        }

                        if (this.grdSCH3101.GetItemString(i, "end_time") == "")
                        {
                            XMessageBox.Show(Resources.MSG002_MSG, Resources.MSG001_CAP, MessageBoxIcon.Error);
                            this.tabReserSch.SelectedTab = this.tabPage2;
                            this.grdSCH3101.SetFocusToItem(i, "end_time");
                            e.IsSuccess = false;
                            return;
                        }

                        if (this.grdSCH3101.GetItemString(i, "inwon") == "")
                        {
                            XMessageBox.Show(Resources.MSG003_MSG, Resources.MSG001_CAP, MessageBoxIcon.Error);
                            this.tabReserSch.SelectedTab = this.tabPage2;
                            this.grdSCH3101.SetFocusToItem(i, "inwon");
                            e.IsSuccess = false;
                            return;
                        }
                    }

                    try
                    {
                        // TODO comment: use connect to cloud
//                        Service.BeginTransaction();
//
//                        mErrMsg = "";
//
//                        if (!this.grdSCH0001.SaveLayout())
//                            throw new Exception();
//
//                        if (!this.grdSCH0002.SaveLayout())
//                            throw new Exception();
//
//                        if (!this.grdJukyongDate.SaveLayout())
//                            throw new Exception();
//
//                        if (!this.grdSCH3000.SaveLayout())
//                            throw new Exception();
//
//                        if (!this.grdSCH3100.SaveLayout())
//                            throw new Exception();
//
//                        if (!this.grdSCH3101.SaveLayout())
//                            throw new Exception();
//
//                        Service.CommitTransaction();

                        // Connect to cloud service

                        
                        UpdateResult updateResult = SCH3001U00BtnBtnListUpdate(true);
                        if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
                            updateResult.Result == false)
                            throw new Exception();
                        // End connect cloud
                        grdSCH3000.ResetUpdate();
                        grdSCH3101.ResetUpdate();
                        e.IsSuccess = true;
                        XMessageBox.Show(Resources.MSG005_MSG, Resources.MSG005_CAP);

                        // grdSCH0001_Query();
                    }
                    catch
                    {
//                        Service.RollbackTransaction();
                        e.IsSuccess = false;
                        mIsSaveSuccess = false;
                        if (mErrMsg != "")
                            XMessageBox.Show(Resources.MSG006_MSG + mErrMsg, Resources.MSG006_CAP, MessageBoxIcon.Warning);
                        else
                        {
                            XMessageBox.Show(Resources.MSG006_MSG + Service.ErrFullMsg, Resources.MSG006_CAP, MessageBoxIcon.Warning);
                        }
                        return;
                    }

					break;
				case FunctionType.Insert:

					e.IsBaseCall = false;

					if (this.CurrMSLayout == grdSCH0001)
					{
						int row = grdSCH0001.InsertRow();
                        grdSCH0001.SetItemValue(row, "gumsaja", "%");
						grdSCH0001.SetItemValue(row, "jundal_table", jundal_table);
						grdSCH0001.AcceptData();
                        grdSCH0001.SetFocusToItem(row, "jundal_part");
					}
					
					if (this.CurrMSLayout == grdJukyongDate)
					{
                        //신규추가는 막고 수정만 가능.디테일 그리드를 통해 자동으로 저장되도록 처리한다.
                        //int row = grdJukyongDate.InsertRow();
                        //grdJukyongDate.SetItemValue(row, "jukyong_date",     DateTime.Now.ToString("yyyy/MM/dd"));
                        //grdJukyongDate.SetItemValue(row, "old_jukyong_date", DateTime.Now.ToString("yyyy/MM/dd"));
                        //grdJukyongDate.SetItemValue(row, "jundal_table", jundal_table);
                        //grdJukyongDate.SetItemValue(row, "jundal_part",  grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber,"jundal_part"));
                        //grdJukyongDate.SetItemValue(row, "gumsaja",      grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber,"gumsaja"));

                        //grdJukyongDate.AcceptData();
					}

					if (this.CurrMSLayout == grdSCH3000)
					{
						#region 입력 validation 체크
                        //string msg = "";
                        //if (grdJukyongDate.CurrentRowNumber < 0)
                        //{
                        //    msg = (NetInfo.Language == LangMode.Ko ? "오른쪽 적용일자를 먼저 입력하세요."
                        //        : "右側の適用日付を先に入力してください。");
                        //    XMessageBox.Show(msg,"知らせ");
                        //    return;
                        //}
						#endregion

                        if (this.grdSCH0001.RowCount > 0 && this.grdSCH0001.CurrentRowNumber > -1)
                        {
                            int row = grdSCH3000.InsertRow();
                            grdSCH3000.SetItemValue(row, "jundal_table", jundal_table);
                            grdSCH3000.SetItemValue(row, "jundal_part", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_part"));
                            grdSCH3000.SetItemValue(row, "gumsaja", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "gumsaja"));//무조건 %
                            //grdSCH3000.SetItemValue(row, "yoil_gubun",   yoil_gubun);

                            grdSCH3000.AcceptData();
                            grdSCH3000.SetFocusToItem(row, "start_time");
                        }
					}
					
					if (this.CurrMSLayout == grdSCH0002)
					{
                        if (this.grdSCH0001.RowCount > 0 && this.grdSCH0001.CurrentRowNumber > -1)
                        {
                            this.layDupOCS0103.QueryLayout();

                            if (this.layDupOCS0103.GetItemValue("dup_yn").ToString() == "Y")
                            {
                                string jundal_part = this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "jundal_part");
                                XMessageBox.Show("「" + jundal_part + Resources.MSG007_MSG

                                                , Resources.MSG001_CAP, MessageBoxIcon.Warning);

                                int row = this.grdSCH0001.InsertRow();
                                grdSCH0001.SetItemValue(row, "gumsaja", "%");
                                grdSCH0001.SetItemValue(row, "jundal_table", jundal_table);
                                grdSCH0001.SetItemValue(row, "jundal_part", jundal_part + "1");
                                grdSCH0001.AcceptData();
                                grdSCH0001.SetFocusToItem(row, "jundal_part");

                            }
                            else
                            {
                                int row = grdSCH0002.InsertRow();
                                grdSCH0002.SetItemValue(row, "jundal_table", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_table"));
                                grdSCH0002.SetItemValue(row, "jundal_part", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_part"));
                                grdSCH0002.SetItemValue(row, "gumsaja", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "gumsaja")); //무조건 %
                                grdSCH0002.AcceptData();
                                grdSCH0002.SetFocusToItem(row, "hangmog_code");
                            }
                        }
					}
					
					if (this.CurrMSLayout == grdSCH3100)
					{
                        if (this.grdSCH0001.RowCount > 0 && this.grdSCH0001.CurrentRowNumber > -1)
                        {
                            int row = grdSCH3100.InsertRow();
                            grdSCH3100.SetItemValue(row, "jundal_table", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_table"));
                            grdSCH3100.SetItemValue(row, "jundal_part", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_part"));
                            grdSCH3100.SetItemValue(row, "gumsaja", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "gumsaja"));//무조건 %
                            grdSCH3100.SetItemValue(row, "reser_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                            this.dtpJukyongDate2.SetDataValue(EnvironInfo.GetSysDate());
                            grdSCH3100.AcceptData();
                            grdSCH3100.SetFocusToItem(row, "reser_date");
                        }
					}
					
					if (this.CurrMSLayout == grdSCH3101)
					{
                        if (this.grdSCH0001.RowCount > 0 && this.grdSCH0001.CurrentRowNumber > -1)
                        {
                            if (this.grdSCH3100.RowCount > 0 && this.grdSCH3100.CurrentRowNumber > -1)
                            {
                                int row = grdSCH3101.InsertRow();
                                grdSCH3101.SetItemValue(row, "jundal_table", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_table"));
                                grdSCH3101.SetItemValue(row, "jundal_part", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_part"));
                                grdSCH3101.SetItemValue(row, "gumsaja", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "gumsaja"));
                                grdSCH3101.SetItemValue(row, "reser_date", grdSCH3100.GetItemString(grdSCH3100.CurrentRowNumber, "reser_date"));
                                grdSCH3101.AcceptData();
                                grdSCH3101.SetFocusToItem(row, "start_time");
                            }
                        }
					}
					
					break;

				case FunctionType.Query:
					e.IsBaseCall = false;

					// 검사종목 조회
					grdSCH0001_Query();

					if ( this.CurrMQLayout == null )
					{
						this.CurrMQLayout = this.grdSCH0001;
					}

					break;
				case FunctionType.Delete:
					if (this.CurrMSLayout == grdSCH0001)
					{
						e.IsBaseCall = false;
                        if ((grdSCH3000.RowCount == 0) && (grdSCH0002.RowCount == 0) && (grdSCH3100.RowCount == 0))
                        {
                            grdSCH0001.DeleteRow(grdSCH0001.CurrentRowNumber);

                            // TODO comment: connect to cloud
//                            grdSCH3000_Query();
//                            grdSCH0002_Query();
//                            grdSCH3100_Query();
                            
                            // Connect to cloud service
                            loadDataForGridRequestInCaseDeleteResult = LoadDataForGridRequestInCaseDelete();
                            if (loadDataForGridRequestInCaseDeleteResult != null &&
                                loadDataForGridRequestInCaseDeleteResult.ExecutionStatus == ExecutionStatus.Success)
                            {
                                lstGrdSch3100Info = loadDataForGridRequestInCaseDeleteResult.GrdSch3100Info;
                                lstGrdSch0002Info = loadDataForGridRequestInCaseDeleteResult.GrdSch0002Info;
                            }
                            grdSCH3000.ExecuteQuery = GrdSCH3000_ExecuteQuery2;
                            grdSCH3000.QueryLayout(true);

                            grdSCH0002.ExecuteQuery = GrdSCH0002_ExecuteQuery;
                            grdSCH0002.QueryLayout(true);

                            grdSCH3100.ExecuteQuery = GrdSCH3100_ExecuteQuery;
                            grdSCH3100.QueryLayout(true);
                            // End connect cloud

                        }
                        else
                        {
                            XMessageBox.Show(Resources.MSG008_MSG, Resources.MSG001_CAP, MessageBoxIcon.Warning);
                        }
					}					
					if (this.CurrMSLayout == grdSCH3100)
					{
						e.IsBaseCall = false;
						if (grdSCH3101.RowCount == 0)
						{
							grdSCH3100.DeleteRow(grdSCH3100.CurrentRowNumber);

							grdSCH3101_Query();
						}
					}

					break;
				default:
					break;
			}
		}

	    

	    #endregion

		
		#region btnList_PostButtonClick
		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
		}
		#endregion


		#region grdSCH0001_Query [파트 조회]
		private void grdSCH0001_Query()
		{
            this.grdSCH0001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
	        this.grdSCH0001.SetBindVarValue("f_jundal_table",this.cboGumsa.GetDataValue());

			if (this.grdSCH0001.QueryLayout(false))
			{
				// 아무것도 없을때 초기화 해준다.
				if (this.grdSCH0001.RowCount < 1)
				{
					this.grdSCH0002.Reset();
					this.grdSCH3000.Reset();
					this.grdSCH3101.Reset();
					this.grdSCH3100.Reset();
				}
			}
			else
			{
				MessageBox.Show(Service.ErrMsg);
			}
		}
		#endregion

		#region grdJukyongDate_Query [적용일 조회]
		private void grdJukyongDate_Query()
		{
            if (!this.grdJukyongDate.QueryLayout(false))
                MessageBox.Show(Service.ErrMsg);
		}
		#endregion

		#region grdSCH3000_Query [파트별 예약시간 조회]
		private void grdSCH3000_Query()
		{
            string yoil_gubun = "1";

            //if (xrt1.Checked) yoil_gubun = "1";
            //if (xrt2.Checked) yoil_gubun = "2";
            //if (xrt3.Checked) yoil_gubun = "3";
            //if (xrt4.Checked) yoil_gubun = "4";
            //if (xrt5.Checked) yoil_gubun = "5";
            //if (xrt6.Checked) yoil_gubun = "6";
            //if (xrt7.Checked) yoil_gubun = "7";

            selectedYoil.Clear();

            if (grdJukyongDate.GetItemString(grdJukyongDate.CurrentRowNumber, "sun") == "Y") selectedYoil.Add("1"); //yoil_gubun = "1";
            if (grdJukyongDate.GetItemString(grdJukyongDate.CurrentRowNumber, "mon") == "Y") selectedYoil.Add("2"); //yoil_gubun = "2";
            if (grdJukyongDate.GetItemString(grdJukyongDate.CurrentRowNumber, "tue") == "Y") selectedYoil.Add("3"); //yoil_gubun = "3";
            if (grdJukyongDate.GetItemString(grdJukyongDate.CurrentRowNumber, "wed") == "Y") selectedYoil.Add("4"); //yoil_gubun = "4";
            if (grdJukyongDate.GetItemString(grdJukyongDate.CurrentRowNumber, "thu") == "Y") selectedYoil.Add("5"); //yoil_gubun = "5";
            if (grdJukyongDate.GetItemString(grdJukyongDate.CurrentRowNumber, "fri") == "Y") selectedYoil.Add("6"); //yoil_gubun = "6";
            if (grdJukyongDate.GetItemString(grdJukyongDate.CurrentRowNumber, "sat") == "Y") selectedYoil.Add("7"); //yoil_gubun = "7";

            if(selectedYoil.Count > 0)
                yoil_gubun = selectedYoil[0].ToString();

            this.grdSCH3000.SetBindVarValue("f_yoil_gubun", yoil_gubun);

            if (!this.grdSCH3000.QueryLayout(false))
                MessageBox.Show(Service.ErrMsg);
		}
		#endregion

		#region grdSCH0002_Query [파트별 예약항목 조회]
		private void grdSCH0002_Query()
		{
            if (!this.grdSCH0002.QueryLayout(false))
                MessageBox.Show(Service.ErrMsg);
		}
		#endregion

		#region grdSCH3100_Query [예약 조회, 예외사항]
		private void grdSCH3100_Query()
		{
            if (!this.grdSCH3100.QueryLayout(false))
                MessageBox.Show(Service.ErrMsg);
		}
		#endregion

		#region grdSCH3101_Query [예약 조회, 예외사항]
		private void grdSCH3101_Query()
		{
            if (!this.grdSCH3101.QueryLayout(false))
                MessageBox.Show(Service.ErrMsg);
		}
		#endregion

		private void cbJundalTable_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			grdSCH0001_Query();
		}

		private void cbxJundalPart_SelectedValueChanged(object sender, System.EventArgs e)
		{
			grdSCH0001_Query();
		}

		private void cbJundalTable_SelectedValueChanged(object sender, System.EventArgs e)
		{
			grdSCH0001_Query();
		}

        private void grdSCH0002_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();

            //param.Add("hangmog_code", grdSCH0002.GetItemString(grdSCH0002.CurrentRowNumber, "hangmog_code"));
            param.Add( "multiSelect", true);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseFixed, param);

            //if (this.mLayHangmogCode != null)
            //{
            //    //int row = grdSCH0002.InsertRow();
            //    this.grdSCH0002.SetFocusToItem(e.RowNumber, "hangmog_code");
            //    this.grdSCH0002.SetEditorValue(this.mLayHangmogCode.GetItemString(0, "hangmog_code"));
            //    this.grdSCH0002.AcceptData();
            //    this.mLayHangmogCode.Dispose();
            //}
        }

		private void vsvHangmogCode_PreServiceCall(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			this.vsvHangmogCode.SetBindVarValue("f_code", grdSCH0002.GetItemString(grdSCH0002.CurrentRowNumber, "hangmog_code"));
		}

		#region 전달 테이블 선택
		private void xrbXRT_CheckedChanged(object sender, System.EventArgs e)
		{
			grdSCH0001_Query();
		}

		private void xrbCPL_CheckedChanged(object sender, System.EventArgs e)
		{
			grdSCH0001_Query();
		}

		private void xrbPFE_CheckedChanged(object sender, System.EventArgs e)
		{
			grdSCH0001_Query();
		}

		private void xrbPHY_CheckedChanged(object sender, System.EventArgs e)
		{
			grdSCH0001_Query();
		}

		#endregion

		private void grdSCH0001_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			grdJukyongDate.Reset();
			grdSCH3000.Reset();
			grdSCH0002.Reset();
			grdSCH3100.Reset();
			grdSCH3101.Reset();

            // TODO comment use connect cloud
//			grdJukyongDate_Query();
//			//grdSCH3000_Query();
//			grdSCH0002_Query();
//			grdSCH3100_Query();
            
            // Connect to cloud service
		    grdSCH0001RowFocusChangedResult = EnsureSCH3001U00GrdSCH0001RowFocusChangedResultProceed();
            if (grdSCH0001RowFocusChangedResult != null && grdSCH0001RowFocusChangedResult.ExecutionStatus == ExecutionStatus.Success)
            {
                lstGrdSch3100Info = grdSCH0001RowFocusChangedResult.GrdSch3100Info;
                lstGrdSch0002Info = grdSCH0001RowFocusChangedResult.GrdSch0002Info;
            }

            grdJukyongDate.ExecuteQuery = GrdJukyongDate_ExecuteQuery2;
		    

		    grdSCH0002.ExecuteQuery = GrdSCH0002_ExecuteQuery;
		    grdSCH0002.QueryLayout(true);

		    grdSCH3100.ExecuteQuery = GrdSCH3100_ExecuteQuery;
		    grdSCH3100.QueryLayout(true);
            // End connect cloud

			valueClear();
            grdJukyongDate.QueryLayout(true);

            
		}

		private void grdSCH3100_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
            this.dtpJukyongDate2.SetDataValue(this.grdSCH3100.GetItemString(e.CurrentRow, "reser_date"));
			grdSCH3101_Query();

			valueClear();
		}

		#region Make btn
        ArrayList selectedYoil = new ArrayList();

		private void btnMake1_Click(object sender, System.EventArgs e)
		{
			string jundal_table = ""; //, yoil_gubun = ""; 

            jundal_table = this.cboGumsa.GetDataValue();

			#region 일괄생성 validation 체크
			string msg = "";
			if (xemTime1.GetDataValue().ToString() == "0000" || xemTime1.GetDataValue().ToString() == "")
			{
				msg = (Resources.MSG001_MSG);
				XMessageBox.Show(msg,Resources.XMsg0001);
				return;
			}
			if (xemSpaceTime1.GetDataValue().ToString() == "" || xemSpaceTime1.GetDataValue().ToString() == "0")
			{
				msg = (Resources.XMsg0002);
				XMessageBox.Show(msg,Resources.XMsg0001);
				return;
            }
            if (xemInwon1.GetDataValue().ToString() == "" || xemInwon1.GetDataValue().ToString() == "0")
            {
                msg = (NetInfo.Language == LangMode.Ko ? "인수를 입력해 주세요."
                    : Resources.MSG003_MSG);
                XMessageBox.Show(msg, Resources.XMsg0001);
                return;
            }
			if (xemRow1.GetDataValue().ToString() == "" || xemRow1.GetDataValue().ToString() == "0")
			{
				msg = (Resources.XMsg003);
				XMessageBox.Show(msg,Resources.XMsg0001);
				return;
			}

            if ((xEditMask1.GetDataValue().ToString().Trim() != "") && Convert.ToInt32(xemInwon1.GetDataValue().ToString()) < Convert.ToInt32(xEditMask1.GetDataValue().ToString()))
            {
                XMessageBox.Show(Resources.MSG012_MSG, Resources.MSG001_CAP, MessageBoxIcon.Error);
                return;
            }
			#endregion

            selectedYoil.Clear();
            this.grdSCH3000.Reset();

            if (cbx1.Checked) selectedYoil.Add("1");
            if (cbx2.Checked) selectedYoil.Add("2");
            if (cbx3.Checked) selectedYoil.Add("3");
            if (cbx4.Checked) selectedYoil.Add("4");
            if (cbx5.Checked) selectedYoil.Add("5");
            if (cbx6.Checked) selectedYoil.Add("6");
            if (cbx7.Checked) selectedYoil.Add("7");

            if (selectedYoil.Count < 1)
            {
                msg = Resources.XMsg0004;
                XMessageBox.Show(msg, Resources.XMsg0001);
                return;
            }
			int rowCount = int.Parse(xemRow1.GetDataValue());
			Double spaceTime = Double.Parse(xemSpaceTime1.GetDataValue());
			int row;
			
			DateTime startTime;
			DateTime endTime;

			endTime = DateTime.Parse(DateTime.Today.ToString("yyyy/MM/dd ") + xemTime1.Text);
			
			int grdSCH3000_row = grdSCH3000.RowCount - 1;

            for (int i = grdSCH3000_row ; i < rowCount + grdSCH3000_row; i++)
            {
                startTime = endTime;
                endTime = endTime.AddMinutes(spaceTime);

                row = grdSCH3000.InsertRow(i);
                grdSCH3000.SetItemValue(row, "start_time", startTime.ToString("HHmm"));
                grdSCH3000.SetItemValue(row, "end_time", endTime.ToString("HHmm"));

                grdSCH3000.SetItemValue(row, "jundal_table", jundal_table);
                grdSCH3000.SetItemValue(row, "jundal_part", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_part"));
                grdSCH3000.SetItemValue(row, "gumsaja", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "gumsaja"));
                //grdSCH3000.SetItemValue(row, "inwon", "1");
                grdSCH3000.SetItemValue(row, "inwon", xemInwon1.GetDataValue().ToString());
                grdSCH3000.SetItemValue(row, "out_hosp_slot", xEditMask1.GetDataValue().ToString());
                //grdSCH3000.SetItemValue(row, "yoil_gubun", yoil_gubun);
            }

            grdSCH3000.AcceptData();
            
            this.grdSCH3000.CallerID = '7';

            try
            {
                // TODO comment: user connect cloud
//                Service.BeginTransaction();
//                for (int i = 0; i < selectedYoil.Count; i++)
//                {
//                    string cmdText = @"DELETE SCH3000
//                                     WHERE HOSP_CODE        = :f_hosp_code 
//                                       AND JUKYONG_DATE     = :f_jukyong_date
//                                       AND JUNDAL_TABLE     = :f_jundal_table
//                                       AND JUNDAL_PART      = :f_jundal_part
//                                       AND YOIL_GUBUN       = :f_yoil_gubun 
//                                       AND GUMSAJA          = NVL(:f_gumsaja,'%')";
//
//                    BindVarCollection bc = new BindVarCollection();
//                    bc.Add("f_hosp_code", EnvironInfo.HospCode);
//                    bc.Add("f_jukyong_date", this.dtpJukyongDate1.GetDataValue());
//                    bc.Add("f_jundal_table", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_table"));
//                    bc.Add("f_jundal_part", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_part"));
//                    bc.Add("f_gumsaja", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "gumsaja"));
//                    bc.Add("f_yoil_gubun", selectedYoil[i].ToString());
//
//                    if (!Service.ExecuteNonQuery(cmdText, bc))
//                    {
//                        if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
//                            throw new Exception();
//                    }
//                }
//
//                if (!this.grdSCH3000.SaveLayout())
//                    throw new Exception();
//
//                Service.CommitTransaction();

                // Connect to cloud
                List<DataStringListItemInfo> lstDataStringListItemInfo = new List<DataStringListItemInfo>();
                for (int i = 0; i < selectedYoil.Count; i++)
                {
                    DataStringListItemInfo dataStringListItemInfo = new DataStringListItemInfo();
                    dataStringListItemInfo.DataValue = selectedYoil[i].ToString();
                    lstDataStringListItemInfo.Add(dataStringListItemInfo);
                }
                SCH3001U00DeleteSelectedYoilArgs args = new SCH3001U00DeleteSelectedYoilArgs();
                args.SelectedYoil = lstDataStringListItemInfo;
                args.JukyongDate = this.dtpJukyongDate1.GetDataValue();
                args.JundalTable = grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_table");
                args.Gumsaja = grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "gumsaja");
                args.JundalPart = grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_part");
                UpdateResult updateResult =
                    CloudService.Instance.Submit<UpdateResult, SCH3001U00DeleteSelectedYoilArgs>(args);
                if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success || updateResult.Result == false)
                    throw new Exception();


                UpdateResult updateResult1 = SCH3001U00BtnBtnListUpdate(false);
                if (updateResult1 == null || updateResult1.ExecutionStatus != ExecutionStatus.Success ||
                    updateResult1.Result == false)
                    throw new Exception();
                // End connect to cloud 
                btnList.PerformClick(FunctionType.Query);

                grdJukyongDate_Query();
            }
            catch
            {
//                Service.RollbackTransaction();
                XMessageBox.Show(Resources.XMsg0006 + "\r\n" + Service.ErrFullMsg, Resources.XMsg0007, MessageBoxIcon.Error);
            }
            this.grdSCH3000.CallerID = '2';

		}

		private void btnMake2_Click(object sender, System.EventArgs e)
		{
			string jundal_table = "";
            jundal_table = this.cboGumsa.GetDataValue();

			#region 일괄생성 validation 체크
			string msg = "";
            if (grdSCH3100.CurrentRowNumber < 0)
            {
                //msg = (NetInfo.Language == LangMode.Ko ? "오른쪽 예약일자를 먼저 입력하세요."
                //    : "左側の予約日付を先に入力してください。");
                //XMessageBox.Show(msg, "知らせ");
                //return;
                int rowNum = grdSCH3100.InsertRow();
                grdSCH3100.SetItemValue(rowNum, "jundal_table", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_table"));
                grdSCH3100.SetItemValue(rowNum, "jundal_part", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_part"));
                grdSCH3100.SetItemValue(rowNum, "gumsaja", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "gumsaja"));
                grdSCH3100.SetItemValue(rowNum, "reser_date", this.dtpJukyongDate2.GetDataValue());
                grdSCH3100.AcceptData();

            }
            else
            {
                if (this.grdSCH3100.CurrentRowNumber < 0)
                {
                    msg = Resources.XMsg0009;
                    XMessageBox.Show(msg, Resources.XMsg0001);
                    return;
                }
            }

			if (xemTime2.GetDataValue().ToString() == "0000" || xemTime2.GetDataValue().ToString() == "")
			{
				msg = (Resources.MSG001_MSG);
				XMessageBox.Show(msg,Resources.XMsg0001);
				return;
			}
			if (xemSpaceTime2.GetDataValue().ToString() == "" || xemSpaceTime2.GetDataValue().ToString() == "0")
			{
				msg = (Resources.XMsg0002);
				XMessageBox.Show(msg,Resources.XMsg0001);
				return;
            }
            if (xemInwon2.GetDataValue().ToString() == "" || xemInwon2.GetDataValue().ToString() == "0")
            {
                msg = (Resources.MSG003_MSG);
                XMessageBox.Show(msg, Resources.XMsg0001);
                return;
            }
			if (xemRow2.GetDataValue().ToString() == "" || xemRow2.GetDataValue().ToString() == "0")
			{
				msg = (Resources.XMsg003);
				XMessageBox.Show(msg,Resources.XMsg0001);
				return;
			}
			#endregion

			int rowCount = int.Parse(xemRow2.GetDataValue());
			Double spaceTime = Double.Parse(xemSpaceTime2.GetDataValue());
			int row;
			
			DateTime startTime;
			DateTime endTime;

			endTime = DateTime.Parse(DateTime.Today.ToString("yyyy/MM/dd ") + xemTime2.Text);
			
			int grdSCH3101_row = grdSCH3101.RowCount - 1;			
			for (int i = grdSCH3101_row ; i < rowCount + grdSCH3101_row; i++)
			{
				startTime = endTime;
				endTime   = endTime.AddMinutes(spaceTime);

				row = grdSCH3101.InsertRow(i);
				grdSCH3101.SetItemValue(row, "start_time", startTime.ToString("HHmm"));
				grdSCH3101.SetItemValue(row, "end_time"  , endTime.ToString("HHmm"));
				
				grdSCH3101.SetItemValue(row, "jundal_table", jundal_table);
				grdSCH3101.SetItemValue(row, "jundal_part",  grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber,"jundal_part"));
				grdSCH3101.SetItemValue(row, "gumsaja",      grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber,"gumsaja"));
				grdSCH3101.SetItemValue(row, "inwon",        xemInwon2.GetDataValue());

                grdSCH3101.SetItemValue(row, "reser_date", this.dtpJukyongDate2.GetDataValue());
			}
			
			grdSCH3101.AcceptData();

            try
            {
                // TODO comment: Use connect to cloud
//                Service.BeginTransaction();
//
//                if (!this.grdSCH3101.SaveLayout())
//                    throw new Exception();
//
//                if (!this.grdSCH3100.SaveLayout())
//                    throw new Exception();
//
//                Service.CommitTransaction();

                // Connect to cloud service
                UpdateResult updateResult = SCH3001U00BtnMake2SaveLayout();
                if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success)
                    throw new Exception();
                // End 

                grdSCH3100_Query();
            }
            catch
            {
//                Service.RollbackTransaction();
                XMessageBox.Show(Resources.XMsg0008 + "\r\n" + Service.ErrFullMsg, Resources.XMsg0007, MessageBoxIcon.Error);
            }
		}
		#endregion

        private void grdSCH3000_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            grdSCH3000.SetItemValue(e.RowNumber, "jukyong_date", this.dtpJukyongDate1.GetDataValue());
            grdSCH3000.SetItemValue(e.RowNumber, "jundal_table", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_table"));
            grdSCH3000.SetItemValue(e.RowNumber, "jundal_part", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_part"));
            grdSCH3000.SetItemValue(e.RowNumber, "gumsaja", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "gumsaja"));
            this.grdSCH3000.AcceptData();
        }

        private void grdJukyongDate_GridCellFocusChanged(object sender, XGridCellFocusChangedEventArgs e)
        {
            if (e.ColName != "jukyong_date")           
            {
                string yoil_gubun = "1";
                this.cbx1.Checked = false;
                this.cbx2.Checked = false;
                this.cbx3.Checked = false;
                this.cbx4.Checked = false;
                this.cbx5.Checked = false;
                this.cbx6.Checked = false;
                this.cbx7.Checked = false;
                switch (e.ColName)
                {
                    case "sun":
                        yoil_gubun = "1";
                        this.cbx1.Checked = true;
                        break;
                    case "mon":
                        yoil_gubun = "2";
                        this.cbx2.Checked = true;
                        break;
                    case "tue":
                        yoil_gubun = "3";
                        this.cbx3.Checked = true;
                        break;
                    case "wed":
                        yoil_gubun = "4";
                        this.cbx4.Checked = true;
                        break;
                    case "thu":
                        yoil_gubun = "5";
                        this.cbx5.Checked = true;
                        break;
                    case "fri":
                        yoil_gubun = "6";
                        this.cbx6.Checked = true;
                        break;
                    case "sat":
                        yoil_gubun = "7";
                        this.cbx7.Checked = true;
                        break;
                }


                this.grdSCH3000.SetBindVarValue("f_yoil_gubun", yoil_gubun);

                if (!this.grdSCH3000.QueryLayout(false))
                    MessageBox.Show(Service.ErrMsg);
            }
            //else
            //{
            //    grdSCH3000_Query();
            //}
        }

		private void grdJukyongDate_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            this.cbx1.SetDataValue(this.grdJukyongDate.GetItemString(e.CurrentRow, "sun"));
            this.cbx2.SetDataValue(this.grdJukyongDate.GetItemString(e.CurrentRow, "mon"));
            this.cbx3.SetDataValue(this.grdJukyongDate.GetItemString(e.CurrentRow, "tue"));
            this.cbx4.SetDataValue(this.grdJukyongDate.GetItemString(e.CurrentRow, "wed"));
            this.cbx5.SetDataValue(this.grdJukyongDate.GetItemString(e.CurrentRow, "thu"));
            this.cbx6.SetDataValue(this.grdJukyongDate.GetItemString(e.CurrentRow, "fri"));
            this.cbx7.SetDataValue(this.grdJukyongDate.GetItemString(e.CurrentRow, "sat"));

			grdSCH3000_Query();
			valueClear();

            //https://sofiamedix.atlassian.net/browse/MED-14287
            xemTime1.Text = str_xemTime1;
            xemSpaceTime1.Text = int_xemSpaceTime1.ToString();
            xemInwon1.Text = str_xemInwon1;
            xemRow1.Text = str_xemRow1;
            xEditMask1.Text = str_xEditMask1;
		}

		#region 일괄생성기능값 clear
		private void valueClear()
		{
            xemTime1.SetDataValue("");
            xemSpaceTime1.SetDataValue("");
            xemRow1.SetDataValue("");
            xemTime2.SetDataValue("");
            xemSpaceTime2.SetDataValue("");
            xemRow2.SetDataValue("");
            xemInwon1.SetDataValue("");
            xemInwon2.SetDataValue("");
            xEditMask1.SetDataValue("");
		}
		#endregion

		#region	grdSCH0001_GridColumnChanged
		private void grdSCH0001_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			switch (e.ColName)
			{
				case "gumsaja":
                    //this.vsvUserName.SetBindVarValue("f_code",grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber,"gumsaja"));
                    ////vsvUserName.QueryLayout();
                    //if (grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber,"gumsaja_name").Length == 0)
                    //{
                    //    grdSCH0001.SetItemValue(grdSCH0001.CurrentRowNumber, "gumsaja", "");
                    //    string msg = (NetInfo.Language == LangMode.Ko ? "등록되지 않은 사용자입니다. 사용자코드를 확인하세요."
                    //        : "登録されてない使用者です。使用者コードを確認してください。");
                    //    XMessageBox.Show(msg,"知らせ");

                    //    grdSCH0001.SetFocusToItem(grdSCH0001.CurrentRowNumber, "gumsaja");
                    //    return;
                    //}
					break;
				default:
					break;
			}
		}
		#endregion

        #region	grdSCH0002_GridColumnChanged
        private void grdSCH0002_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName == "hangmog_code")
            {
                SetMsg("");
                // TODO comment: use connect cloud

//                string cmdText = @" SELECT HANGMOG_NAME
//                                  FROM OCS0103
//                                 WHERE HOSP_CODE    = :f_hosp_code
//                                   AND HANGMOG_CODE = :f_hangmog_code
//                                   AND TRUNC(SYSDATE) BETWEEN START_DATE AND NVL( END_DATE, TO_DATE('99981231', 'YYYYMMDD'))";
//                BindVarCollection bc = new BindVarCollection();
//                bc.Add("f_hosp_code", EnvironInfo.HospCode);
//                bc.Add("f_hangmog_code", e.ChangeValue.ToString());
//
//                object hangmog_name = Service.ExecuteScalar(cmdText, bc);
                
                // Connect to cloud service
                SCH3001U00GrdSCH0002ValidateGridColumnChangedArgs args = new SCH3001U00GrdSCH0002ValidateGridColumnChangedArgs();
                args.HangmogCode = e.ChangeValue.ToString();
                SCH3001U00GrdSCH0002ValidateGridColumnChangedResult result =
                    CloudService.Instance
                        .Submit
                        <SCH3001U00GrdSCH0002ValidateGridColumnChangedResult,
                            SCH3001U00GrdSCH0002ValidateGridColumnChangedArgs>(args);
                if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                {
                    this.grdSCH0002.SetItemValue(e.RowNumber, "hangmog_name", result.HangmogName);
                }
                else
                {
                    e.Cancel = true;
                    SetMsg(Resources.MSG009_MSG, MsgType.Error);
                }
                // End connect cloud service
            }

        }
        #endregion

		private bool PreSave()
		{
			string reser_date = "";
			string start_time = "";
			int    row = 0;

			for (int i = 0; i<grdSCH3100.RowCount; i++)
			{
				if ((grdSCH3100.GetRowState(i) == DataRowState.Added) || (grdSCH3100.GetRowState(i) == DataRowState.Modified))
				{
					reser_date = grdSCH3100.GetItemString(i, "reser_date");
					row = i;
				}
			}

			for (int i = 0; i<grdSCH3100.RowCount; i++)
			{
				if ((reser_date != "")&& (grdSCH3100.GetItemString(i,"reser_date") == reser_date) && (i!=row))
				{
					MessageBox.Show(Resources.MSG010_MSG);
					grdSCH3100.SetFocusToItem(row, "reser_date");
					return false;
				}
			}

			row = 0;
			for (int i = 0; i<grdSCH3101.RowCount; i++)
			{
				if ((grdSCH3101.GetRowState(i) == DataRowState.Added) || (grdSCH3101.GetRowState(i) == DataRowState.Modified))
				{
					start_time = grdSCH3101.GetItemString(i, "start_time");
					row = i;
				}
			}

			for (int i = 0; i<grdSCH3101.RowCount; i++)
			{
				if ((start_time != "")&& (grdSCH3101.GetItemString(i,"start_time") == start_time) && (i!=row))
				{
                    MessageBox.Show(Resources.MSG011_MSG);
					grdSCH3101.SetFocusToItem(row, "start_time");
					return false;
				}
			}
			return true;
		}

        private void grdJukyongDate_QueryStarting(object sender, CancelEventArgs e)
        {
            cbx1.ResetData();
            cbx2.ResetData();
            cbx3.ResetData();
            cbx4.ResetData();
            cbx5.ResetData();
            cbx6.ResetData();
            cbx7.ResetData();
            this.grdJukyongDate.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdJukyongDate.SetBindVarValue("f_jundal_table", this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "jundal_table"));
            this.grdJukyongDate.SetBindVarValue("f_jundal_part", this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "jundal_part"));
            this.grdJukyongDate.SetBindVarValue("f_gumsaja", this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "gumsaja"));
        }
       
        private void grdSCH3000_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdSCH3000.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdSCH3000.SetBindVarValue("f_jukyong_date", this.grdJukyongDate.GetItemString(this.grdJukyongDate.CurrentRowNumber, "jukyong_date"));
            this.grdSCH3000.SetBindVarValue("f_jundal_table", this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "jundal_table"));
            this.grdSCH3000.SetBindVarValue("f_jundal_part", this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "jundal_part"));
            this.grdSCH3000.SetBindVarValue("f_gumsaja", this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "gumsaja"));
        }

        private void grdSCH0002_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdSCH0002.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdSCH0002.SetBindVarValue("f_jundal_table", this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "jundal_table"));
            this.grdSCH0002.SetBindVarValue("f_jundal_part", this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "jundal_part"));
        }

        private void grdSCH3100_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdSCH3100.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdSCH3100.SetBindVarValue("f_jundal_table", this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "jundal_table"));
            this.grdSCH3100.SetBindVarValue("f_jundal_part", this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "jundal_part"));
            this.grdSCH3100.SetBindVarValue("f_gumsaja", this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "gumsaja"));
        }

        private void grdSCH3101_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdSCH3101.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdSCH3101.SetBindVarValue("f_jundal_table", this.grdSCH3100.GetItemString(this.grdSCH3100.CurrentRowNumber, "jundal_table"));
            this.grdSCH3101.SetBindVarValue("f_jundal_part", this.grdSCH3100.GetItemString(this.grdSCH3100.CurrentRowNumber, "jundal_part"));
            this.grdSCH3101.SetBindVarValue("f_gumsaja", this.grdSCH3100.GetItemString(this.grdSCH3100.CurrentRowNumber, "gumsaja"));
            this.grdSCH3101.SetBindVarValue("f_reser_date", this.grdSCH3100.GetItemString(this.grdSCH3100.CurrentRowNumber, "reser_date"));
        }

        private void cboGumsa_SelectedValueChanged(object sender, EventArgs e)
        {
            if (mIsLoaded)
            {
                grdSCH0001_Query();
            }
        }

        private void grdSCH3101_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            this.grdSCH3101.SetItemValue(e.RowNumber, "reser_date", this.dtpJukyongDate2.GetDataValue());
        }

        private void layDupOCS0103_QueryStarting(object sender, CancelEventArgs e)
        {
            layDupOCS0103.ParamList = new List<string>(new String[] { "f_jundal_part" });
            layDupOCS0103.ExecuteQuery = LayDupOCS0103_ExecuteQuery;

            this.layDupOCS0103.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDupOCS0103.SetBindVarValue("f_jundal_part", this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "jundal_part"));
        } 

        #region XSavePerformer
        string mErrMsg = "";
        private class XSavePerformer : ISavePerformer
        {
            SCH3001U00 parent;

            public XSavePerformer(SCH3001U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                parent.mErrMsg = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (callerID)
                {
                    case '1': /* grdSCH0001 */

                        switch (item.RowState)
                        { 
                            case DataRowState.Added:

                                cmdText = @"INSERT INTO SCH0001 
                                                 ( SYS_DATE
                                                 , SYS_ID
                                                 , UPD_DATE
                                                 , UPD_ID
                                                 , HOSP_CODE
                                                 , JUNDAL_TABLE
                                                 , JUNDAL_PART
                                                 , GUMSAJA
                                                 , JUNDAL_PART_NAME
                                                 , GWA_GUBUN   
                                                 , GUMSA_TIME       ) 
                                            VALUES 
                                                 ( SYSDATE
                                                 , :q_user_id
                                                 , SYSDATE
                                                 , :q_user_id
                                                 , :f_hosp_code
                                                 , :f_jundal_table
                                                 , :f_jundal_part
                                                 , NVL(:f_gumsaja,'%')
                                                 , :f_jundal_part_name
                                                 , NVL(:f_gwa_gubun,'%')
                                                 , :f_gumsa_time
                                                 ) ";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE SCH0001
                                               SET UPD_ID           = :q_user_id
                                                 , UPD_DATE         = SYSDATE
                                                 , JUNDAL_PART_NAME = :f_jundal_part_name
                                                 , GWA_GUBUN        = :f_gwa_gubun
                                                 , GUMSA_TIME       = :f_gumsa_time
                                             WHERE HOSP_CODE        = :f_hosp_code 
                                               AND JUNDAL_TABLE     = :f_jundal_table      
                                               AND JUNDAL_PART      = :f_jundal_part
                                               AND GUMSAJA          = NVL(:f_gumsaja,'%')";
                                break;

                            case DataRowState.Deleted:

                                cmdText = @"DELETE SCH0001
                                             WHERE HOSP_CODE       = :f_hosp_code 
                                               AND JUNDAL_TABLE    = :f_jundal_table
                                               AND JUNDAL_PART     = :f_jundal_part
                                               AND GUMSAJA         = NVL(:f_gumsaja,'%')";

                                break;
                        }

                        break;

                    case '2': /* SCH3000 */

                        switch (item.RowState)
                        { 
                            case DataRowState.Added:

                                for (int i = 0; i < parent.selectedYoil.Count; i++)
                                {
                                    cmdText = @"INSERT INTO SCH3000 
                                                 ( SYS_DATE
                                                 , SYS_ID
                                                 , UPD_DATE
                                                 , UPD_ID
                                                 , HOSP_CODE
                                                 , JUKYONG_DATE
                                                 , JUNDAL_TABLE
                                                 , JUNDAL_PART 
                                                 , GUMSAJA     
                                                 , YOIL_GUBUN  
                                                 , START_TIME  
                                                 , END_TIME    
                                                 , INWON       
                                                 , ADD_INWON  )
                                            VALUES 
                                                 ( SYSDATE
                                                 , :q_user_id
                                                 , SYSDATE
                                                 , :q_user_id
                                                 , :f_hosp_code
                                                 , NVL(:f_jukyong_date,TRUNC(SYSDATE))
                                                 , :f_jundal_table
                                                 , :f_jundal_part
                                                 , NVL(:f_gumsaja,'%')
                                                 , :f_yoil_gubun
                                                 , :f_start_time
                                                 , :f_end_time
                                                 , :f_inwon
                                                 , :f_add_inwon  )";

                                    item.BindVarList.Add("f_yoil_gubun", parent.selectedYoil[i].ToString());
                                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                    {
                                        parent.mErrMsg = Service.ErrFullMsg;
                                        return false;
                                    }
                                }
                                return true;

                            case DataRowState.Modified:

                                for (int i = 0; i < parent.selectedYoil.Count; i++)
                                {
                                    cmdText = @"UPDATE SCH3000
                                                   SET UPD_ID           = :q_user_id
                                                     , UPD_DATE         = SYSDATE
                                                     , END_TIME         = :f_end_time
                                                     , INWON            = :f_inwon
                                                     , ADD_INWON        = :f_add_inwon
                                                 WHERE HOSP_CODE        = :f_hosp_code 
                                                   AND JUKYONG_DATE     = :f_jukyong_date
                                                   AND JUNDAL_TABLE     = :f_jundal_table
                                                   AND JUNDAL_PART      = :f_jundal_part
                                                   AND GUMSAJA          = NVL(:f_gumsaja,'%')
                                                   AND YOIL_GUBUN       = :f_yoil_gubun
                                                   AND START_TIME       = :f_start_time       ";

                                    item.BindVarList.Add("f_yoil_gubun", parent.selectedYoil[i].ToString());
                                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                    {
                                        if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                        {
                                            parent.mErrMsg = Service.ErrFullMsg;
                                            return false;
                                        }
                                    }
                                }
                                return true;

                            case DataRowState.Deleted:
                                for (int i = 0; i < parent.selectedYoil.Count; i++)
                                {
                                    cmdText = @"DELETE SCH3000
                                             WHERE HOSP_CODE        = :f_hosp_code 
                                               AND JUKYONG_DATE     = :f_jukyong_date
                                               AND JUNDAL_TABLE     = :f_jundal_table
                                               AND JUNDAL_PART      = :f_jundal_part
                                               AND GUMSAJA          = NVL(:f_gumsaja,'%')
                                               AND YOIL_GUBUN       = :f_yoil_gubun
                                               AND START_TIME       = :f_start_time";

                                    item.BindVarList.Add("f_yoil_gubun", parent.selectedYoil[i].ToString());
                                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                    {
                                        if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                        {
                                            parent.mErrMsg = Service.ErrFullMsg;
                                            return false;
                                        }
                                    }
                                }
                                return true;
                        }
                        break;

                    case '3': /* SCH0002 */
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"UPDATE SCH0201
                                               SET JUNDAL_TABLE        = :f_jundal_table
                                                 , JUNDAL_PART         = :f_jundal_part
                                             WHERE HOSP_CODE           = :f_hosp_code 
                                               AND HANGMOG_CODE        = :f_hangmog_code
                                               AND ACTING_DATE         IS NULL
                                               AND NVL(CANCEL_YN,'N')  = 'N'
                                               AND NVL(:f_gumsaja,'%') = '%'";

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"INSERT INTO SCH0002 
                                                 ( SYS_DATE
                                                 , SYS_ID
                                                 , UPD_DATE
                                                 , UPD_ID
                                                 , HOSP_CODE
                                                 , JUNDAL_TABLE
                                                 , JUNDAL_PART
                                                 , GUMSAJA
                                                 , HANGMOG_CODE
                                                 , HANGMOG_NAME
                                                 , GUMSA_TIME     ) 
                                            VALUES 
                                                 ( SYSDATE
                                                 , :q_user_id
                                                 , SYSDATE
                                                 , :q_user_id
                                                 , :f_hosp_code 
                                                 , :f_jundal_table
                                                 , :f_jundal_part
                                                 , NVL(:f_gumsaja,'%')
                                                 , :f_hangmog_code
                                                 , :f_hangmog_name
                                                 , :f_gumsa_time      )";

                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE SCH0002
                                               SET UPD_ID        = :q_user_id
                                                 , UPD_DATE      = SYSDATE
                                                 , HANGMOG_NAME  = :f_hangmog_name
                                                 , GUMSA_TIME    = :f_gumsa_time
                                             WHERE HOSP_CODE     = :f_hosp_code 
                                               AND JUNDAL_TABLE  = :f_jundal_table
                                               AND JUNDAL_PART   = :f_jundal_part
                                               AND HANGMOG_CODE  = :f_hangmog_code";

                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE SCH0002
                                             WHERE HOSP_CODE     = :f_hosp_code 
                                               AND JUNDAL_TABLE  = :f_jundal_table
                                               AND JUNDAL_PART   = :f_jundal_part
                                               AND HANGMOG_CODE  = :f_hangmog_code";

                                break;
                        }
                        break;

                    case '4':  /* SCH3100 */
                        switch (item.RowState)
                        { 
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO SCH3100 
                                                 ( SYS_DATE
                                                 , SYS_ID
                                                 , UPD_DATE
                                                 , UPD_ID
                                                 , HOSP_CODE
                                                 , JUNDAL_TABLE
                                                 , JUNDAL_PART
                                                 , GUMSAJA
                                                 , RESER_DATE
                                                 , RESER_YN     ) 
                                            VALUES 
                                                 ( SYSDATE
                                                 , :q_user_id
                                                 , SYSDATE
                                                 , :q_user_id
                                                 , :f_hosp_code
                                                 , :f_jundal_table
                                                 , :f_jundal_part 
                                                 , :f_gumsaja     
                                                 , :f_reser_date  
                                                 , :f_reser_yn    
                                                 )";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE SCH3100
                                               SET UPD_ID        = :q_user_id
                                                 , UPD_DATE      = SYSDATE
                                                 , RESER_YN      = :f_reser_yn
                                             WHERE HOSP_CODE     = :f_hosp_code 
                                               AND JUNDAL_TABLE  = :f_jundal_table
                                               AND JUNDAL_PART   = :f_jundal_part
                                               AND GUMSAJA       = :f_gumsaja
                                               AND RESER_DATE    = :f_reser_date";

                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE SCH3100
                                             WHERE HOSP_CODE     = :f_hosp_code 
                                               AND JUNDAL_TABLE  = :f_jundal_table
                                               AND JUNDAL_PART   = :f_jundal_part
                                               AND GUMSAJA       = :f_gumsaja
                                               AND RESER_DATE    = :f_reser_date";

                                break;
                        }
                        break;

                    case '5': /*SCH3101*/
                        switch (item.RowState)
                        { 
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO SCH3101 
                                                 ( SYS_DATE
                                                 , SYS_ID
                                                 , UPD_DATE
                                                 , UPD_ID
                                                 , HOSP_CODE
                                                 , JUNDAL_TABLE
                                                 , JUNDAL_PART 
                                                 , GUMSAJA     
                                                 , RESER_DATE  
                                                 , START_TIME  
                                                 , END_TIME    
                                                 , INWON       
                                                 , ADD_INWON    ) 
                                            VALUES 
                                                 ( SYSDATE
                                                 , :q_user_id
                                                 , SYSDATE
                                                 , :q_user_id
                                                 , :f_hosp_code
                                                 , :f_jundal_table
                                                 , :f_jundal_part 
                                                 , :f_gumsaja     
                                                 , :f_reser_date  
                                                 , :f_start_time  
                                                 , :f_end_time    
                                                 , :f_inwon       
                                                 , :f_add_inwon   )";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE SCH3101
                                               SET UPD_ID        = :q_user_id
                                                 , UPD_DATE      = SYSDATE
                                                 , END_TIME      = :f_end_time
                                                 , INWON         = :f_inwon
                                                 , ADD_INWON     = :f_add_inwon
                                             WHERE HOSP_CODE     = :f_hosp_code 
                                               AND JUNDAL_TABLE  = :f_jundal_table
                                               AND JUNDAL_PART   = :f_jundal_part
                                               AND GUMSAJA       = :f_gumsaja
                                               AND RESER_DATE    = :f_reser_date
                                               AND START_TIME    = :f_start_time";

                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE SCH3101
                                             WHERE HOSP_CODE     = :f_hosp_code 
                                               AND JUNDAL_TABLE  = :f_jundal_table
                                               AND JUNDAL_PART   = :f_jundal_part
                                               AND GUMSAJA       = :f_gumsaja
                                               AND RESER_DATE    = :f_reser_date
                                               AND START_TIME    = :f_start_time";
                                break;
                        }
                        break;

                    case '6': /*SCH3000*/
                        switch (item.RowState)
                        {
                            case DataRowState.Modified:
                                cmdText = @"UPDATE SCH3000
                                               SET UPD_ID        = :q_user_id
                                                 , UPD_DATE      = SYSDATE
                                                 , JUKYONG_DATE  = :f_jukyong_date
                                             WHERE HOSP_CODE     = :f_hosp_code 
                                               AND JUKYONG_DATE  = :f_old_jukyong_date
                                               AND JUNDAL_TABLE  = :f_jundal_table
                                               AND JUNDAL_PART   = :f_jundal_part
                                               AND GUMSAJA       = NVL(:f_gumsaja,'%')";

                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE SCH3000
                                             WHERE HOSP_CODE     = :f_hosp_code 
                                               AND JUKYONG_DATE  = :f_old_jukyong_date
                                               AND JUNDAL_TABLE  = :f_jundal_table
                                               AND JUNDAL_PART   = :f_jundal_part
                                               AND GUMSAJA       = NVL(:f_gumsaja,'%')";
                                break;
                        }
                        break;

                    case '7': /* SCH3000 */
                       
                        for (int i = 0; i < parent.selectedYoil.Count; i++)
                        {
                            cmdText = @"INSERT INTO SCH3000 
                                         ( SYS_DATE
                                         , SYS_ID
                                         , UPD_DATE
                                         , UPD_ID
                                         , HOSP_CODE
                                         , JUKYONG_DATE
                                         , JUNDAL_TABLE
                                         , JUNDAL_PART 
                                         , GUMSAJA     
                                         , YOIL_GUBUN  
                                         , START_TIME  
                                         , END_TIME    
                                         , INWON       
                                         , ADD_INWON  )
                                    VALUES 
                                         ( SYSDATE
                                         , :q_user_id
                                         , SYSDATE
                                         , :q_user_id
                                         , :f_hosp_code
                                         , NVL(:f_jukyong_date,TRUNC(SYSDATE))
                                         , :f_jundal_table
                                         , :f_jundal_part
                                         , NVL(:f_gumsaja,'%')
                                         , :f_yoil_gubun
                                         , :f_start_time
                                         , :f_end_time
                                         , :f_inwon
                                         , :f_add_inwon  )";

                            item.BindVarList.Add("f_yoil_gubun", parent.selectedYoil[i].ToString());
                            if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                            {
                                parent.mErrMsg = Service.ErrFullMsg;
                                return false;
                            }
                        }
                        return true;                               
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void SCH3001U00_Closing(object sender, CancelEventArgs e)
        {
            if (!this.mIsSaveSuccess)
                e.Cancel = true;

            this.mIsSaveSuccess = true;
        }


        #region connect to cloud service

        /// <summary>
        /// GrdSCH0001_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
	    private IList<object[]> GrdSCH0001_ExecuteQuery(BindVarCollection varCollection)
	    {
	        List<object[]> res = new List<object[]>();
	        SCH3001U00GrdSCH0001Args vSCH3001U00GrdSCH0001Args = new SCH3001U00GrdSCH0001Args();
	        vSCH3001U00GrdSCH0001Args.JundalTable = varCollection["f_jundal_table"].VarValue;
	        SCH3001U00GrdSCH0001Result result =
	            CloudService.Instance.Submit<SCH3001U00GrdSCH0001Result, SCH3001U00GrdSCH0001Args>(
	                vSCH3001U00GrdSCH0001Args);
	        if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            List<SCH3001U00GrdSCH0001Info> lstGrdSch0001Info = result.GrdSch0001List;
	            if (lstGrdSch0001Info != null && lstGrdSch0001Info.Count > 0)
	            {
	                foreach (SCH3001U00GrdSCH0001Info item in result.GrdSch0001List)
	                {
	                    object[] objects =
	                    {
	                        item.JundalTable,
	                        item.JundalPart,
	                        item.Gumsaja,
	                        item.GumsajaName,
	                        item.JundalPartName,
	                        item.GwaGubun,
	                        item.GumsaTime,
	                        item.DataRowState
	                    };
	                    res.Add(objects);
	                }
	            }
	        }
	        return res; 

	    }

       /// <summary>
       /// grdJukyongDate_ExecuteQuery
       /// </summary>
       /// <param name="varCollection"></param>
       /// <returns></returns>
       private IList<object[]> GrdJukyongDate_ExecuteQuery(BindVarCollection varCollection)
       {
           IList<object[]> res = new List<object[]>();
           SCH3001U00GrdJukyongDateArgs vSCH3001U00GrdJukyongDateArgs = new SCH3001U00GrdJukyongDateArgs();
           vSCH3001U00GrdJukyongDateArgs.JundalTable = varCollection["f_jundal_table"].VarValue;
           vSCH3001U00GrdJukyongDateArgs.JundalPart = varCollection["f_jundal_part"].VarValue;
           vSCH3001U00GrdJukyongDateArgs.Gumsaja = varCollection["f_gumsaja"].VarValue;
           SCH3001U00GrdJukyongDateResult result =
               CloudService.Instance.Submit<SCH3001U00GrdJukyongDateResult, SCH3001U00GrdJukyongDateArgs>(
                   vSCH3001U00GrdJukyongDateArgs);
           if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
           {
               List<SCH3001U00GrdJukyongDateInfo> lstGrdJukyongDateInfo = result.GrdJukyongDateList;

               res = GrdJukyongDate_ConvertToListObject(lstGrdJukyongDateInfo);
           }
           return res;
       }

	    /// <summary>
	    /// GrdSCH3000_ExecuteQuery
	    /// </summary>
	    /// <param name="bc"></param>
	    /// <returns></returns>
	    private IList<object[]> GrdSCH3000_ExecuteQuery(BindVarCollection bc)
	    {
	        IList<object[]> res = new List<object[]>();
	        SCH3001U00GrdSCH3000Args vSCH3001U00GrdSCH3000Args = new SCH3001U00GrdSCH3000Args();
	        vSCH3001U00GrdSCH3000Args.JukyongDate = bc["f_jukyong_date"].VarValue;
	        vSCH3001U00GrdSCH3000Args.JundalTable = bc["f_jundal_table"].VarValue;
	        vSCH3001U00GrdSCH3000Args.JundalPart = bc["f_jundal_part"].VarValue;
	        vSCH3001U00GrdSCH3000Args.Gumsaja = bc["f_gumsaja"].VarValue;
	        vSCH3001U00GrdSCH3000Args.YoilGubun = bc["f_yoil_gubun"].VarValue;
	        SCH3001U00GrdSCH3000Result result =
	            CloudService.Instance.Submit<SCH3001U00GrdSCH3000Result, SCH3001U00GrdSCH3000Args>(
	                vSCH3001U00GrdSCH3000Args);
	        if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            res = GrdSCH3000_ConvertToListObject(result.GrdSch3000List);
            }
            else
            {
                str_xemTime1 = "";
                int_xemSpaceTime1 = 0;
                str_xemInwon1 = "";
                str_xemRow1 = "";
                str_xEditMask1 = "";
            }
	        return res;
	    }

        
        /// <summary>
        /// GrdSCH3000_ExecuteQuery2
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
	    private IList<object[]> GrdSCH3000_ExecuteQuery2(BindVarCollection bc)
        {
            IList<object[]> lstObject = new List<object[]>();
            if (loadDataForGridRequestInCaseDeleteResult != null &&
                loadDataForGridRequestInCaseDeleteResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<SCH3001U00GrdSCH3000Info> lstGrdSch3000Info = loadDataForGridRequestInCaseDeleteResult.GrdSch3000List;
                lstObject = GrdSCH3000_ConvertToListObject(lstGrdSch3000Info);
            }
            return lstObject;
        }

        /// <summary>
        /// GrdSCH3000_ConvertToListObject
        /// </summary>
        /// <param name="lstGrdSch3000Info"></param>
        /// <returns></returns>
        private IList<object[]> GrdSCH3000_ConvertToListObject(List<SCH3001U00GrdSCH3000Info> lstGrdSch3000Info)
        {
            List<object[]> res = new List<object[]>();
            if (lstGrdSch3000Info != null && lstGrdSch3000Info.Count > 0)
            {
                foreach (SCH3001U00GrdSCH3000Info item in lstGrdSch3000Info)
                {
                    object[] objects =
                    {
                        item.JukyongDate,
                        item.JundalTable,
                        item.JundalPart,
                        item.Gumsaja,
                        item.YoilGubun,
                        item.StartTime,
                        item.EndTime,
                        item.Iwon,
                        item.AddIwon,
                        item.OutHospSlot,
                        item.DataRowState
                    };
                    res.Add(objects);
                }
                if (lstGrdSch3000Info.Count > 0)
                {
                    str_xemTime1 = (lstGrdSch3000Info[0].StartTime.ToString()).Insert(2, ":");
                    int_xemSpaceTime1 = Int32.Parse(lstGrdSch3000Info[0].EndTime) - Int32.Parse(lstGrdSch3000Info[0].StartTime);
                    str_xemInwon1 = lstGrdSch3000Info[0].Iwon.ToString();
                    str_xemRow1 = lstGrdSch3000Info.Count.ToString();
                    str_xEditMask1 = lstGrdSch3000Info[0].OutHospSlot.ToString();
                }
                
               

            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private SCH3001U00GrdSCH0001RowFocusChangedResult EnsureSCH3001U00GrdSCH0001RowFocusChangedResultProceed()
        {
            SCH3001U00GrdSCH0001RowFocusChangedArgs vSCH3001U00GrdSCH0001RowFocusChangedArgs = new SCH3001U00GrdSCH0001RowFocusChangedArgs();
            vSCH3001U00GrdSCH0001RowFocusChangedArgs.JundalTable = this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "jundal_table"); ;
            vSCH3001U00GrdSCH0001RowFocusChangedArgs.JundalPart = this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "jundal_part");
            vSCH3001U00GrdSCH0001RowFocusChangedArgs.Gumsaja = this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "gumsaja");

            return
                CloudService.Instance
                    .Submit<SCH3001U00GrdSCH0001RowFocusChangedResult, SCH3001U00GrdSCH0001RowFocusChangedArgs>(
                        vSCH3001U00GrdSCH0001RowFocusChangedArgs);
        }

        /// <summary>
        /// GrdJukyongDate_ExecuteQuery
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
	    private IList<object[]> GrdJukyongDate_ExecuteQuery2(BindVarCollection bc)
	    {
	        IList<object[]> res = new List<object[]>();
	        if (grdSCH0001RowFocusChangedResult != null &&
	            grdSCH0001RowFocusChangedResult.ExecutionStatus == ExecutionStatus.Success)
	        {
	            List<SCH3001U00GrdJukyongDateInfo> lstGrdJukyongDateInfo =
	                grdSCH0001RowFocusChangedResult.JukyongDateInfo;
                res = GrdJukyongDate_ConvertToListObject(lstGrdJukyongDateInfo);
	        }

	        return res;
	    }

        /// <summary>
        /// GrdJukyongDate_ConvertToListObject
        /// </summary>
        /// <param name="lstGrdJukyongDateInfo"></param>
        /// <returns></returns>
	    private IList<object[]> GrdJukyongDate_ConvertToListObject(List<SCH3001U00GrdJukyongDateInfo> lstGrdJukyongDateInfo)
	    {
	        IList<object[]> res = new List<object[]>();
	        if (lstGrdJukyongDateInfo != null && lstGrdJukyongDateInfo.Count > 0)
	        {
	            foreach (SCH3001U00GrdJukyongDateInfo item in lstGrdJukyongDateInfo)
	            {
	                object[] objects =
	                {
	                    item.JukyongDate,
	                    item.JundalTable,
	                    item.JundalPart,
	                    item.Gumsaja,
	                    item.OldJukyongDate,
	                    item.MonDay,
	                    item.TueDay,
	                    item.WedDay,
	                    item.ThuDay,
	                    item.FriDay,
	                    item.StaDay,
	                    item.SunDay
	                };
	                res.Add(objects);
	            }
	        }
	        return res;
	    }

        /// <summary>
        /// GrdSCH0002_ExecuteQuery
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> GrdSCH0002_ExecuteQuery(BindVarCollection bc)
        {
            return GrdSCH0002_ConvertToListObject(lstGrdSch0002Info);
        }

        /// <summary>
        /// GrdSCH0002_ConvertToListObject
        /// </summary>
        /// <param name="lstGrdSch0002Info"></param>
        /// <returns></returns>
	    private IList<object[]> GrdSCH0002_ConvertToListObject(List<SCH3001U00GrdSCH0002Info> lstGrdSch0002Info)
	    {
            IList<object[]> res = new List<object[]>();
            if (lstGrdSch0002Info != null && lstGrdSch0002Info.Count > 0)
            {
                foreach (SCH3001U00GrdSCH0002Info item in lstGrdSch0002Info)
                {
                    object[] objects =
                    {
                        item.JundalTable,
                        item.JundalPart,
                        item.Gumsaja,
                        item.HangmogCode,
                        item.HangmogName,
                        item.GumsaTime,
                    };
                    res.Add(objects);
                }
            }
            return res;
	    }

        /// <summary>
        /// GrdSCH3100_ExecuteQuery
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> GrdSCH3100_ExecuteQuery(BindVarCollection bc)
        {
            return GrdSCH3100_ConvertToListObject(lstGrdSch3100Info);
        }

        /// <summary>
        /// GrdSCH3100_ConvertToListObject
        /// </summary>
        /// <param name="lstGrdSch3100Info"></param>
        /// <returns></returns>
	    private IList<object[]> GrdSCH3100_ConvertToListObject(List<SCH3001U00GrdSCH3100Info> lstGrdSch3100Info)
	    {
            IList<object[]> res = new List<object[]>();
            if (lstGrdSch3100Info != null && lstGrdSch3100Info.Count > 0)
            {
                foreach (SCH3001U00GrdSCH3100Info item in lstGrdSch3100Info)
                {
                    object[] objects =
                        {
                            item.JundalTable,
                            item.JundalPart,
                            item.Gumsaja,
                            item.ReserDate,
                            item.ReserYn,
                        };
                    res.Add(objects);
                }
            }
	        return res;
	    }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> GrdSCH3101_ExecuteQuery(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            SCH3001U00GrdSCH3101Args vSCH3001U00GrdSCH3101Args = new SCH3001U00GrdSCH3101Args();
            vSCH3001U00GrdSCH3101Args.JundalTable = bc["f_jundal_table"].VarValue;
            vSCH3001U00GrdSCH3101Args.JundalPart = bc["f_jundal_part"].VarValue;
            vSCH3001U00GrdSCH3101Args.Gumsaja = bc["f_gumsaja"].VarValue;
            vSCH3001U00GrdSCH3101Args.ReserDate = bc["f_reser_date"].VarValue;
            SCH3001U00GrdSCH3101Result result = CloudService.Instance.Submit<SCH3001U00GrdSCH3101Result, SCH3001U00GrdSCH3101Args>(vSCH3001U00GrdSCH3101Args);
            if (result != null)
            {
                foreach (SCH3001U00GrdSCH3101Info item in result.GrdSch3101List)
                {
                    object[] objects = 
				{ 
					item.JundalTable, 
					item.JundalPart, 
					item.Gumsaja, 
					item.ReserDate, 
					item.StartTime, 
					item.EndTime, 
					item.Iwon, 
					item.AddIwon
				};
                    res.Add(objects);
                }
            }
            return res;
        }
        
        /// <summary>
        /// LoadDataForGridRequestInCaseDelete
        /// </summary>
        /// <returns></returns>
        private SCH3001U00LoadDataForGridRequestInCaseDeleteResult LoadDataForGridRequestInCaseDelete()
        {
            SCH3001U00LoadDataForGridArgsInCaseDeleteArgs args = new SCH3001U00LoadDataForGridArgsInCaseDeleteArgs();
            args.JukyongDate = this.grdJukyongDate.GetItemString(this.grdJukyongDate.CurrentRowNumber, "jukyong_date");
            args.JundalTable = this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "jundal_table");
            args.JundalPart = this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "jundal_part");
            args.Gumsaja = this.grdSCH0001.GetItemString(this.grdSCH0001.CurrentRowNumber, "gumsaja");

            string yoil_gubun = "1";
            selectedYoil.Clear();
            if (grdJukyongDate.GetItemString(grdJukyongDate.CurrentRowNumber, "sun") == "Y") selectedYoil.Add("1"); //yoil_gubun = "1";
            if (grdJukyongDate.GetItemString(grdJukyongDate.CurrentRowNumber, "mon") == "Y") selectedYoil.Add("2"); //yoil_gubun = "2";
            if (grdJukyongDate.GetItemString(grdJukyongDate.CurrentRowNumber, "tue") == "Y") selectedYoil.Add("3"); //yoil_gubun = "3";
            if (grdJukyongDate.GetItemString(grdJukyongDate.CurrentRowNumber, "wed") == "Y") selectedYoil.Add("4"); //yoil_gubun = "4";
            if (grdJukyongDate.GetItemString(grdJukyongDate.CurrentRowNumber, "thu") == "Y") selectedYoil.Add("5"); //yoil_gubun = "5";
            if (grdJukyongDate.GetItemString(grdJukyongDate.CurrentRowNumber, "fri") == "Y") selectedYoil.Add("6"); //yoil_gubun = "6";
            if (grdJukyongDate.GetItemString(grdJukyongDate.CurrentRowNumber, "sat") == "Y") selectedYoil.Add("7"); //yoil_gubun = "7";

            if (selectedYoil.Count > 0)
                yoil_gubun = selectedYoil[0].ToString();

            args.YoilGubun = yoil_gubun;

            return CloudService.Instance.Submit<SCH3001U00LoadDataForGridRequestInCaseDeleteResult, SCH3001U00LoadDataForGridArgsInCaseDeleteArgs>(args);
           
        }

        /// <summary>
        /// LayDupOCS0103_ExecuteQuery
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LayDupOCS0103_ExecuteQuery(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            SCH3001U00LayDupOCS0103Args vSCH3001U00LayDupOCS0103Args = new SCH3001U00LayDupOCS0103Args();
            vSCH3001U00LayDupOCS0103Args.JundalPart = bc["f_jundal_part"].VarValue;
            SCH3001U00LayDupOCS0103Result result = CloudService.Instance.Submit<SCH3001U00LayDupOCS0103Result, SCH3001U00LayDupOCS0103Args>(vSCH3001U00LayDupOCS0103Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<DataStringListItemInfo> lsDataStringListItemInfo = result.ItemInfo;
                if (lsDataStringListItemInfo != null && lsDataStringListItemInfo.Count > 0)
                {
                    foreach (DataStringListItemInfo item in lsDataStringListItemInfo)
                    {
                        object[] objects =
                        {
                            item.DataValue
                        };
                        res.Add(objects);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// cboGumsa_ExecuteQuery
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> cboGumsa_ExecuteQuery(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            SCH3001U00GetCboGumsaArgs vSCH3001U00GetCboGumsaArgs = new SCH3001U00GetCboGumsaArgs();
            SCH3001U00GetCboGumsaResult result = CacheService.Instance.Get<SCH3001U00GetCboGumsaArgs, SCH3001U00GetCboGumsaResult>(vSCH3001U00GetCboGumsaArgs, delegate(SCH3001U00GetCboGumsaResult gumsaResult)
            {
                return gumsaResult != null && gumsaResult.ExecutionStatus == ExecutionStatus.Success &&
                       gumsaResult.ListItem != null && gumsaResult.ListItem.Count > 0;
            });

            // 2015.07.09 AnhNV Added
            //SCH3001U00GetCboGumsaResult result = CloudService.Instance.Submit<SCH3001U00GetCboGumsaResult, SCH3001U00GetCboGumsaArgs>(new SCH3001U00GetCboGumsaArgs());

            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> lstComboListItemInfo = result.ListItem;
                if (lstComboListItemInfo != null && lstComboListItemInfo.Count > 0)
                {
                    foreach (ComboListItemInfo item in result.ListItem)
                    {
                        object[] objects =
                        {
                            item.Code,
                            item.CodeName
                        };
                        res.Add(objects);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// btnMake2 save layout
        /// </summary>
        /// <returns></returns>
	    private UpdateResult SCH3001U00BtnMake2SaveLayout()
	    {
	        SCH3001U00BtnMake2SaveLayoutArgs args = new SCH3001U00BtnMake2SaveLayoutArgs();
            args.GrdSch3101Info = CreateListSCH3001U00GrdSCH3101Info();
            args.GrdSch3100Info = CreateLstSCH3001U00GrdSCH3100Info();
            args.SysId = UserInfo.UserID;

            return
                CloudService.Instance.Submit<UpdateResult, SCH3001U00BtnMake2SaveLayoutArgs>(args);

	    }

        /// <summary>
        /// SCH3001U00BtnBtnListUpdate
        /// </summary>
        /// <returns></returns>
	    private UpdateResult SCH3001U00BtnBtnListUpdate(bool updateAll)
	    {
            if ((xEditMask1.GetDataValue().ToString().Trim() != "") && Convert.ToInt32(xemInwon1.GetDataValue().ToString()) < Convert.ToInt32(xEditMask1.GetDataValue().ToString()))
            {
                XMessageBox.Show(Resources.MSG012_MSG, Resources.MSG001_CAP, MessageBoxIcon.Error);
                return null;
            }
	        SCH3001U00BtnBtnListUpdateArgs args = new SCH3001U00BtnBtnListUpdateArgs();
            args.GrdSch0001Info = CreateListSCH3001U00GrdSCH0001Info();
            args.GrdSch0002Info = CreateListSCH3001U00GrdSCH0002Info();
            args.GrdJukyongDateInfo = CreateListSCH3001U00GrdJukyongDateInfo();
            args.GrdSch3000Info = CreateListSCH3001U00GrdSCH3000Info();
            args.GrdSch3100Info = CreateLstSCH3001U00GrdSCH3100Info();
            args.GrdSch3101Info = CreateListSCH3001U00GrdSCH3101Info();
            args.UserId = UserInfo.UserID;
            args.SelectedYoil = CreateDataStringListItemInfo();
            args.OutHospCodeSlot = xEditMask1.GetDataValue().ToString();
            if (!updateAll)
            {
                args.GrdSch0001Info.Clear();
                args.GrdSch0002Info.Clear();
                args.GrdJukyongDateInfo.Clear();
                args.GrdSch3100Info.Clear();
                args.GrdSch3101Info.Clear();
            }

            return CloudService.Instance.Submit<UpdateResult, SCH3001U00BtnBtnListUpdateArgs>(args);
	    }

        /// <summary>
        /// CreateListSCH3001U00GrdSCH3101Info
        /// </summary>
        /// <returns></returns>
	    private List<SCH3001U00GrdSCH3101Info> CreateListSCH3001U00GrdSCH3101Info()
	    {
	        List<SCH3001U00GrdSCH3101Info> lstGrdSch3101Info = new List<SCH3001U00GrdSCH3101Info>();
	        for (int i = 0; i < grdSCH3101.RowCount; i++)
	        {

                //pre-save
                this.grdSCH3101.SetItemValue(i, "reser_date", this.dtpJukyongDate2.GetDataValue());

                //begin
	            if (grdSCH3101.GetRowState(i) == DataRowState.Added || grdSCH3101.GetRowState(i) == DataRowState.Modified)
	            {
	                SCH3001U00GrdSCH3101Info grdSch3101Info = new SCH3001U00GrdSCH3101Info();
	                grdSch3101Info.JundalTable = grdSCH3101.GetItemString(i, "jundal_table");
	                grdSch3101Info.JundalPart = grdSCH3101.GetItemString(i, "jundal_part");
	                grdSch3101Info.Gumsaja = grdSCH3101.GetItemString(i, "gumsaja");
	                grdSch3101Info.ReserDate = grdSCH3101.GetItemString(i, "reser_date");
	                grdSch3101Info.StartTime = grdSCH3101.GetItemString(i, "start_time");
	                grdSch3101Info.EndTime = grdSCH3101.GetItemString(i, "end_time");
	                grdSch3101Info.Iwon = grdSCH3101.GetItemString(i, "inwon");
	                grdSch3101Info.AddIwon = grdSCH3101.GetItemString(i, "add_inwon");
	                grdSch3101Info.DataRowState = grdSCH3101.GetRowState(i).ToString();

	                lstGrdSch3101Info.Add(grdSch3101Info);
	            }
	        }

            if (grdSCH3101.DeletedRowTable != null && grdSCH3101.DeletedRowCount > 0)
	        {
                foreach (DataRow row in grdSCH3101.DeletedRowTable.Rows)
	            {
                    SCH3001U00GrdSCH3101Info grdSch3101Info = new SCH3001U00GrdSCH3101Info();
                    grdSch3101Info.JundalTable = row["jundal_table"].ToString();
                    grdSch3101Info.JundalPart = row["jundal_part"].ToString();
                    grdSch3101Info.Gumsaja = row["gumsaja"].ToString();
                    grdSch3101Info.ReserDate = row["reser_date"].ToString();
                    grdSch3101Info.StartTime = row["start_time"].ToString();
                    grdSch3101Info.EndTime = row["end_time"].ToString();
                    grdSch3101Info.Iwon = row["inwon"].ToString();
                    grdSch3101Info.AddIwon = row["add_inwon"].ToString();
	                grdSch3101Info.DataRowState = DataRowState.Deleted.ToString();

                    lstGrdSch3101Info.Add(grdSch3101Info);
	            }
	        }
            return lstGrdSch3101Info;
	    }

        /// <summary>
        /// CreateLstSCH3001U00GrdSCH3100Info
        /// </summary>
        /// <returns></returns>
	    private List<SCH3001U00GrdSCH3100Info> CreateLstSCH3001U00GrdSCH3100Info()
	    {
	        List<SCH3001U00GrdSCH3100Info> lstSch3001U00GrdSch3100Info = new List<SCH3001U00GrdSCH3100Info>();
            for (int i = 0; i < grdSCH3100.RowCount; i++)
	        {
	            if (grdSCH3100.GetRowState(i) == DataRowState.Added || grdSCH3100.GetRowState(i) == DataRowState.Modified)
	            {
	                for (int j = 0; j < grdSCH3100.RowCount; j++)
	                {
	                    SCH3001U00GrdSCH3100Info grdSch3100Info = new SCH3001U00GrdSCH3100Info();
	                    grdSch3100Info.JundalTable = grdSCH3100.GetItemString(i, "jundal_table");
	                    grdSch3100Info.JundalPart = grdSCH3100.GetItemString(i, "jundal_part");
	                    grdSch3100Info.Gumsaja = grdSCH3100.GetItemString(i, "gumsaja");
	                    grdSch3100Info.ReserDate = grdSCH3100.GetItemString(i, "reser_date");
	                    grdSch3100Info.ReserYn = grdSCH3100.GetItemString(i, "reser_yn");
	                    grdSch3100Info.DataRowState = grdSCH3100.GetRowState(i).ToString();

	                    lstSch3001U00GrdSch3100Info.Add(grdSch3100Info);
	                }
	            }
	        }

            if (grdSCH3100.DeletedRowTable != null && grdSCH3100.DeletedRowCount > 0)
	        {
                foreach (DataRow row in grdSCH3100.DeletedRowTable.Rows)
	            {
                    SCH3001U00GrdSCH3100Info grdSch3100Info = new SCH3001U00GrdSCH3100Info();
                    grdSch3100Info.JundalTable = row["jundal_table"].ToString();
                    grdSch3100Info.JundalPart = row["jundal_part"].ToString();
                    grdSch3100Info.Gumsaja = row["gumsaja"].ToString();
                    grdSch3100Info.ReserDate = row["reser_date"].ToString();
                    grdSch3100Info.ReserYn = row["reser_yn"].ToString();
                    grdSch3100Info.DataRowState = DataRowState.Deleted.ToString();

                    lstSch3001U00GrdSch3100Info.Add(grdSch3100Info);
	            }
	        }

            return lstSch3001U00GrdSch3100Info;
	    }

        /// <summary>
        /// CreateListSCH3001U00GrdSCH0001Info
        /// </summary>
        /// <returns></returns>
	    private List<SCH3001U00GrdSCH0001Info> CreateListSCH3001U00GrdSCH0001Info()
	    {
	        List<SCH3001U00GrdSCH0001Info> lstSch3001U00GrdSch0001Info = new List<SCH3001U00GrdSCH0001Info>();
            for (int i = 0; i < grdSCH0001.RowCount; i++)
	        {
	            if (grdSCH0001.GetRowState(i) == DataRowState.Added || grdSCH0001.GetRowState(i) == DataRowState.Deleted)
	            {
	                SCH3001U00GrdSCH0001Info grdSch0001Info = new SCH3001U00GrdSCH0001Info();
	                grdSch0001Info.JundalTable = grdSCH0001.GetItemString(i, "jundal_table");
	                grdSch0001Info.JundalPart = grdSCH0001.GetItemString(i, "jundal_part");
	                grdSch0001Info.Gumsaja = grdSCH0001.GetItemString(i, "gumsaja");
	                grdSch0001Info.GumsajaName = grdSCH0001.GetItemString(i, "gumsaja_name");
	                grdSch0001Info.JundalPartName = grdSCH0001.GetItemString(i, "jundal_part_name");
	                grdSch0001Info.GwaGubun = grdSCH0001.GetItemString(i, "gwa_gubun");
	                grdSch0001Info.GumsaTime = grdSCH0001.GetItemString(i, "gumsa_time");
	                grdSch0001Info.DataRowState = grdSCH0001.GetRowState(i).ToString();

	                lstSch3001U00GrdSch0001Info.Add(grdSch0001Info);
	            }
	        }

            if (grdSCH0001.DeletedRowTable != null && grdSCH0001.DeletedRowCount > 0)
	        {
                foreach (DataRow row in grdSCH0001.DeletedRowTable.Rows)
                {
                    SCH3001U00GrdSCH0001Info grdSch0001Info = new SCH3001U00GrdSCH0001Info();
                    grdSch0001Info.JundalTable = row["jundal_table"].ToString();
                    grdSch0001Info.JundalPart = row["jundal_part"].ToString();
                    grdSch0001Info.Gumsaja = row["gumsaja"].ToString();
                    grdSch0001Info.GumsajaName = row["gumsaja_name"].ToString();
                    grdSch0001Info.JundalPartName = row["jundal_part_name"].ToString();
                    grdSch0001Info.GwaGubun = row["gwa_gubun"].ToString();
                    grdSch0001Info.GumsaTime = row["gumsa_time"].ToString();
                    grdSch0001Info.DataRowState = DataRowState.Deleted.ToString();

                    lstSch3001U00GrdSch0001Info.Add(grdSch0001Info);
                }
	        }

            return lstSch3001U00GrdSch0001Info;
	    }

        /// <summary>
        /// CreateListSCH3001U00GrdSCH0002Info
        /// </summary>
        /// <returns></returns>
	    private List<SCH3001U00GrdSCH0002Info> CreateListSCH3001U00GrdSCH0002Info()
	    {
	        List<SCH3001U00GrdSCH0002Info> lstSch3001U00GrdSch0002Info = new List<SCH3001U00GrdSCH0002Info>();
            for (int i = 0; i < grdSCH0002.RowCount; i++)
	        {
	            if (grdSCH0002.GetRowState(i) == DataRowState.Added || grdSCH0002.GetRowState(i) == DataRowState.Modified)
	            {
	                SCH3001U00GrdSCH0002Info grdSch0002Info = new SCH3001U00GrdSCH0002Info();
	                grdSch0002Info.JundalTable = grdSCH0002.GetItemString(i, "jundal_table");
	                grdSch0002Info.JundalPart = grdSCH0002.GetItemString(i, "jundal_part");
	                grdSch0002Info.Gumsaja = grdSCH0002.GetItemString(i, "gumsaja");
	                grdSch0002Info.HangmogCode = grdSCH0002.GetItemString(i, "hangmog_code");
	                grdSch0002Info.HangmogName = grdSCH0002.GetItemString(i, "hangmog_name");
	                grdSch0002Info.GumsaTime = grdSCH0002.GetItemString(i, "gumsa_time");
	                grdSch0002Info.DataRowState = grdSCH0002.GetRowState(i).ToString();

                    lstSch3001U00GrdSch0002Info.Add(grdSch0002Info);
	            }
	        }

	        if (grdSCH0002.DeletedRowTable != null && grdSCH0002.DeletedRowCount > 0)
	        {
                foreach (DataRow row in grdSCH0002.DeletedRowTable.Rows)
	            {
                    SCH3001U00GrdSCH0002Info grdSch0002Info = new SCH3001U00GrdSCH0002Info();
	                grdSch0002Info.JundalTable = row["jundal_table"].ToString();
	                grdSch0002Info.JundalPart = row["jundal_part"].ToString();
	                grdSch0002Info.Gumsaja = row["gumsaja"].ToString();
	                grdSch0002Info.HangmogCode = row["hangmog_code"].ToString();
	                grdSch0002Info.HangmogName = row["hangmog_name"].ToString();
	                grdSch0002Info.GumsaTime = row["gumsa_time"].ToString();
	                grdSch0002Info.DataRowState = DataRowState.Deleted.ToString();

                    lstSch3001U00GrdSch0002Info.Add(grdSch0002Info);
	            }
	        }
	        return lstSch3001U00GrdSch0002Info;
	    }

        /// <summary>
        /// CreateListSCH3001U00GrdJukyongDateInfo
        /// </summary>
        /// <returns></returns>
        private List<SCH3001U00GrdJukyongDateInfo> CreateListSCH3001U00GrdJukyongDateInfo()
	    {
            List<SCH3001U00GrdJukyongDateInfo> lstGrdJukyongDateInfo = new List<SCH3001U00GrdJukyongDateInfo>();
            for (int i = 0; i < grdJukyongDate.RowCount; i++)
            {
                if (grdJukyongDate.GetRowState(i) == DataRowState.Added ||
                    grdJukyongDate.GetRowState(i) == DataRowState.Modified)
                {
                    SCH3001U00GrdJukyongDateInfo grdJukyongDateInfo = new SCH3001U00GrdJukyongDateInfo();
                    grdJukyongDateInfo.JukyongDate = grdJukyongDate.GetItemString(i, "jukyong_date");
                    grdJukyongDateInfo.JundalTable = grdJukyongDate.GetItemString(i, "jundal_table");
                    grdJukyongDateInfo.JundalPart = grdJukyongDate.GetItemString(i, "jundal_part");
                    grdJukyongDateInfo.Gumsaja = grdJukyongDate.GetItemString(i, "gumsaja");
                    grdJukyongDateInfo.OldJukyongDate = grdJukyongDate.GetItemString(i, "old_jukyong_date");
                    grdJukyongDateInfo.MonDay = grdJukyongDate.GetItemString(i, "mon");
                    grdJukyongDateInfo.TueDay = grdJukyongDate.GetItemString(i, "tue");
                    grdJukyongDateInfo.WedDay = grdJukyongDate.GetItemString(i, "wed");
                    grdJukyongDateInfo.ThuDay = grdJukyongDate.GetItemString(i, "thu");
                    grdJukyongDateInfo.FriDay = grdJukyongDate.GetItemString(i, "fri");
                    grdJukyongDateInfo.StaDay = grdJukyongDate.GetItemString(i, "sat");
                    grdJukyongDateInfo.SunDay = grdJukyongDate.GetItemString(i, "sun");
                    grdJukyongDateInfo.DataRowState = grdJukyongDate.GetRowState(i).ToString();

                    lstGrdJukyongDateInfo.Add(grdJukyongDateInfo);
                }
                
            }
            if (grdJukyongDate.DeletedRowTable != null && grdJukyongDate.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdJukyongDate.DeletedRowTable.Rows)
                {
                    SCH3001U00GrdJukyongDateInfo grdJukyongDateInfo = new SCH3001U00GrdJukyongDateInfo();
                    grdJukyongDateInfo.JukyongDate = row["jukyong_date"].ToString();
                    grdJukyongDateInfo.JundalTable = row["jundal_table"].ToString();
                    grdJukyongDateInfo.JundalPart = row["jundal_part"].ToString();
                    grdJukyongDateInfo.Gumsaja = row["gumsaja"].ToString();
                    grdJukyongDateInfo.OldJukyongDate = row["old_jukyong_date"].ToString();
                    grdJukyongDateInfo.MonDay = row["mon"].ToString();
                    grdJukyongDateInfo.TueDay = row["tue"].ToString();
                    grdJukyongDateInfo.WedDay = row["wed"].ToString();
                    grdJukyongDateInfo.ThuDay = row["thu"].ToString();
                    grdJukyongDateInfo.FriDay = row["fri"].ToString();
                    grdJukyongDateInfo.StaDay = row["sat"].ToString();
                    grdJukyongDateInfo.SunDay = row["sun"].ToString();
                    grdJukyongDateInfo.DataRowState = DataRowState.Deleted.ToString();

                    lstGrdJukyongDateInfo.Add(grdJukyongDateInfo);
                }
            }
            return lstGrdJukyongDateInfo;
	    }

        /// <summary>
        /// CreateListSCH3001U00GrdSCH3000Info
        /// </summary>
        /// <returns></returns>
	    private List<SCH3001U00GrdSCH3000Info> CreateListSCH3001U00GrdSCH3000Info()
	    {
	        List<SCH3001U00GrdSCH3000Info> lstGrdSch3000Info = new List<SCH3001U00GrdSCH3000Info>();
            for (int i = 0; i < grdSCH3000.RowCount; i++)
	        {

                //pre-saving
                grdSCH3000.SetItemValue(i, "jukyong_date", this.dtpJukyongDate1.GetDataValue());
                grdSCH3000.SetItemValue(i, "jundal_table", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_table"));
                grdSCH3000.SetItemValue(i, "jundal_part", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "jundal_part"));
                grdSCH3000.SetItemValue(i, "gumsaja", grdSCH0001.GetItemString(grdSCH0001.CurrentRowNumber, "gumsaja"));
                this.grdSCH3000.AcceptData();

                //begin
	            if (grdSCH3000.GetRowState(i) == DataRowState.Added || grdSCH3000.GetRowState(i) == DataRowState.Modified)
	            {
                    SCH3001U00GrdSCH3000Info grdSch3000Info = new SCH3001U00GrdSCH3000Info();
                    grdSch3000Info.JukyongDate = grdSCH3000.GetItemString(i, "jukyong_date");
                    grdSch3000Info.JundalTable = grdSCH3000.GetItemString(i, "jundal_table");
                    grdSch3000Info.JundalPart = grdSCH3000.GetItemString(i, "jundal_part");
                    grdSch3000Info.Gumsaja = grdSCH3000.GetItemString(i, "gumsaja");
                    grdSch3000Info.YoilGubun = grdSCH3000.GetItemString(i, "yoil_gubun");
                    grdSch3000Info.StartTime = grdSCH3000.GetItemString(i, "start_time");
                    grdSch3000Info.EndTime = grdSCH3000.GetItemString(i, "end_time");
                    grdSch3000Info.Iwon = grdSCH3000.GetItemString(i, "inwon");
                    grdSch3000Info.AddIwon = grdSCH3000.GetItemString(i, "add_inwon");
                    grdSch3000Info.OutHospSlot = grdSCH3000.GetItemString(i, "out_hosp_slot");
	                grdSch3000Info.DataRowState = grdSCH3000.GetRowState(i).ToString();

                    lstGrdSch3000Info.Add(grdSch3000Info);
	            }
	        }

	        if (grdSCH3000.DeletedRowTable != null && grdSCH3000.DeletedRowCount > 0)
	        {
	            foreach (DataRow row in grdSCH3000.DeletedRowTable.Rows)
	            {
                    SCH3001U00GrdSCH3000Info grdSch3000Info = new SCH3001U00GrdSCH3000Info();
                    grdSch3000Info.JukyongDate = row["jukyong_date"].ToString();
                    grdSch3000Info.JundalTable = row["jundal_table"].ToString();
                    grdSch3000Info.JundalPart = row["jundal_part"].ToString();
                    grdSch3000Info.Gumsaja = row["gumsaja"].ToString();
                    grdSch3000Info.YoilGubun = row["yoil_gubun"].ToString();
                    grdSch3000Info.StartTime = row["start_time"].ToString();
                    grdSch3000Info.EndTime = row["end_time"].ToString();
                    grdSch3000Info.Iwon = row["inwon"].ToString();
                    grdSch3000Info.AddIwon = row["add_inwon"].ToString();
                    grdSch3000Info.OutHospSlot = row["out_hosp_slot"].ToString();
	                grdSch3000Info.DataRowState = DataRowState.Deleted.ToString();

                    lstGrdSch3000Info.Add(grdSch3000Info);
	            }
	        }
            return lstGrdSch3000Info;
	    }

        /// <summary>
        /// CreateDataStringListItemInfo
        /// </summary>
        /// <returns></returns>
	    private List<DataStringListItemInfo> CreateDataStringListItemInfo()
	    {
	        List<DataStringListItemInfo> lstItemInfo = new List<DataStringListItemInfo>();
	        if (selectedYoil != null && selectedYoil.Count > 0)
	        {
                foreach (string s in selectedYoil)
	            {
	                DataStringListItemInfo dataStringListItemInfo = new DataStringListItemInfo();
	                dataStringListItemInfo.DataValue = s;
                    lstItemInfo.Add(dataStringListItemInfo);
	            }
	        }
	        return lstItemInfo;
	    }
	    #endregion
	}
}

