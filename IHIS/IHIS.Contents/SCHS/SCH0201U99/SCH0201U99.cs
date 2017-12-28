#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Schs;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Schs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.Framework;
using IHIS.SCHS.Properties;
using DataStringListItemInfo = IHIS.CloudConnector.Contracts.Models.System.DataStringListItemInfo;
using SchsSCH0201U99DateScheduleItemInfo = IHIS.CloudConnector.Contracts.Models.Schs.SchsSCH0201U99DateScheduleItemInfo;
using SchsSCH0201U99GrdOrderListInfo = IHIS.CloudConnector.Contracts.Models.Schs.SchsSCH0201U99GrdOrderListInfo;
using SchsSCH0201U99GrdTimeListInfo = IHIS.CloudConnector.Contracts.Models.Schs.SchsSCH0201U99GrdTimeListInfo;
using SchsSCH0201U99LayoutCommonListInfo = IHIS.CloudConnector.Contracts.Models.Schs.SchsSCH0201U99LayoutCommonListInfo;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Globalization;
using IHIS.SCHS.Reports;


#endregion

namespace IHIS.SCHS
{
	/// <summary>
	/// SCH0201U99에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class SCH0201U99 : XScreen
	{
		#region [Instance Variable]		
		//Message처리
		//string mbxMsg = "", mbxCap = "";
        //PKOCS KEY
        private string pkocs = "";
        //PKINP1001 KEY
        private string pkinp1001 = "";
		//患者番号
		private string mBunho = "";
		//診療科
		private string mGwa = "";
		//診療医
		private string mDoctor = "";		
		//내원일자
		private string mNaewon_date = "";
		//입력구분
		//private string mInput_gubun =  "";
		//창구
        //private string mChanggu = "OCSO";
        //現在選択されている日付
        private string mCurrentDate = "";
        private string mHospCode = "";
        private string mCallerName = "";
       
        // Set tooltip text for showing patient information
        private int curPreRowIndex = -1;
        private int curPreX = -1;
        private ToolTip toolTip1;

		#endregion

		#region [자동생성]
		private XPanel xPanel2;
        private XPanel xPanel1;
		private Panel panel1;
        private XCalendar calSchedule;
        private XLabel xlbReserList;
        private XButtonList xButtonList1;
		private XPanel pnlPatient;
		private XPanel pnlDoctor;
        private XPatientBox paBox;
		private MultiLayout layDateSchedule;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell52;
        private MultiLayout layReserList;
        private XButton btnReserScript;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private XButton btnReserOrder;
        private Splitter splitter1;
        private XEditGrid grdOrderlist;
        private XEditGridCell xEditGridCell86;
        private XEditGridCell xEditGridCell87;
        private XEditGridCell xEditGridCell88;
        private XEditGridCell xEditGridCell89;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell91;
        private XEditGridCell xEditGridCell92;
        private XEditGridCell xEditGridCell93;
        private XEditGridCell xEditGridCell94;
        private XEditGridCell xEditGridCell95;
        private XEditGridCell xEditGridCell96;
        private XEditGridCell xEditGridCell97;
        private XEditGridCell xEditGridCell98;
        private XEditGridCell xEditGridCell99;
        private XEditGridCell xEditGridCell100;
        private MultiLayout layTimeList;
        private XLabel xLabel2;
        private XEditGrid grdTimeList;
        private XEditGridCell xEditGridCell44;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private SingleLayout layCommon;
        private SingleLayout layReserTimeChk;
        private SingleLayoutItem singleLayoutItem4;
        private XEditGridCell xEditGridCell4;
        private XLabel xlbJundalPart;
        private XLabel xlbSelectedDate;
        private XEditGridCell xEditGridCell5;
        private XButton btnComment;
        private XEditGridCell xEditGridCell6;
        private XButton btnExpand;
		#endregion
        private ToolTip toolTip;
        private XEditGridCell xEditGridCell7;
        private XEditGrid grdPkschList;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XLabel xLabel12;
        private XDictComboBox cboGumsa;
        private XLabel xLabel1;
        private XDictComboBox cboReserStatus;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XComboItem xComboItem3;
        private XDictComboBox cboGumsaPart;
        private XButton btnInsertSch;
        private XLabel xLabel3;
        private XDisplayBox dbxLinkHospName;
        private XFindBox fbxLinkHospCode;
        private XLabel xLabel4;
        private RadioButton rbtOtherClinic;
        private RadioButton rbtMyClinic;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private XDisplayBox dbxDoctor_name;
        private XFindBox fbxDoctor;
        private XLabel xLabel6;
        private XFindWorker fwkLinkHospCode;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private XButton btnClear;
        private IContainer components;
        private string mHospCodeLink = "";
        private XComboBox cboGwa;
        private XLabel xLabel5;
        private string mBunhoLink = "";
        private bool tabIsAll = false;
        private const string CACHE_COMBOCHOJAE_KEYS = "Nuro.RES1001U00.CmbChoJae";
        private string mbxCap = "";
        private string mbxMsg = "";
        DataTable tbl_ClinicInfo;
        private XEditGridCell xEditGridCell19;
        private SplitContainer splitContainer1;
        DataTable tbl_ListBooking;
        private string[] msgOrca = { "00", "K3", "K4", "K5" };
		#region [생성자]
		public SCH0201U99()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            Size = new System.Drawing.Size(rc.Width - 45, rc.Height - 115);
            // Set param list and ExecuteQuery for grdOrderlist
            grdOrderlist.ParamList = new List<string>(new String[] { "f_flag", "f_fkocs", "f_bunho", "f_reser_gubun", "f_reser_part", "f_reser_status" });
		    grdOrderlist.ExecuteQuery = grdOrderlist_ExecuteQuery;

            // Set param list and ExecuteQuery for grdTimeList
            grdTimeList.ParamList = new List<string>(new String[] { "f_ip_addr" });
		    grdTimeList.ExecuteQuery = grdTimeList_ExecuteQuery;

		    cboGumsa.ExecuteQuery = cboGumsa_ExecuteQuery;
		    cboGumsa.SetDictDDLB();

		    cboGumsaPart.ExecuteQuery = cboGumsaPart_ExecuteQuery;
            toolTip1 = new ToolTip();
		}
		#endregion

		#region [소멸자]
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCH0201U99));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdOrderlist = new IHIS.Framework.XEditGrid();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.calSchedule = new IHIS.Framework.XCalendar();
            this.pnlPatient = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnInsertSch = new IHIS.Framework.XButton();
            this.btnComment = new IHIS.Framework.XButton();
            this.btnReserOrder = new IHIS.Framework.XButton();
            this.btnReserScript = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.pnlDoctor = new IHIS.Framework.XPanel();
            this.cboGwa = new IHIS.Framework.XComboBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.btnClear = new IHIS.Framework.XButton();
            this.dbxDoctor_name = new IHIS.Framework.XDisplayBox();
            this.fbxDoctor = new IHIS.Framework.XFindBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.dbxLinkHospName = new IHIS.Framework.XDisplayBox();
            this.fbxLinkHospCode = new IHIS.Framework.XFindBox();
            this.fwkLinkHospCode = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.rbtOtherClinic = new System.Windows.Forms.RadioButton();
            this.rbtMyClinic = new System.Windows.Forms.RadioButton();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.cboGumsaPart = new IHIS.Framework.XDictComboBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cboReserStatus = new IHIS.Framework.XDictComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.cboGumsa = new IHIS.Framework.XDictComboBox();
            this.xlbSelectedDate = new IHIS.Framework.XLabel();
            this.xlbJundalPart = new IHIS.Framework.XLabel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExpand = new IHIS.Framework.XButton();
            this.grdTimeList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.grdPkschList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xlbReserList = new IHIS.Framework.XLabel();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.layDateSchedule = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.layReserList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.layTimeList = new IHIS.Framework.MultiLayout();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.layReserTimeChk = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calSchedule)).BeginInit();
            this.pnlPatient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.pnlDoctor.SuspendLayout();
            this.xPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTimeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPkschList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDateSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTimeList)).BeginInit();
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
            this.ImageList.Images.SetKeyName(5, "");
            this.ImageList.Images.SetKeyName(6, "");
            this.ImageList.Images.SetKeyName(7, "");
            this.ImageList.Images.SetKeyName(8, "");
            this.ImageList.Images.SetKeyName(9, "행삭제.gif");
            this.ImageList.Images.SetKeyName(10, "이름바꾸기.gif");
            this.ImageList.Images.SetKeyName(11, "타과의뢰.gif");
            this.ImageList.Images.SetKeyName(12, "입원처방.ico");
            this.ImageList.Images.SetKeyName(13, "환자조회.gif");
            this.ImageList.Images.SetKeyName(14, "SCHS.ico");
            this.ImageList.Images.SetKeyName(15, "입력.gif");
            this.ImageList.Images.SetKeyName(16, "autoSizeHeight.gif");
            this.ImageList.Images.SetKeyName(17, "autoSizeHeight2.gif");
            this.ImageList.Images.SetKeyName(18, "YESEN1.ico");
            this.ImageList.Images.SetKeyName(19, "YESUP1.ico");
            // 
            // splitContainer1
            // 
            this.splitContainer1.AccessibleDescription = null;
            this.splitContainer1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.BackgroundImage = null;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Font = null;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AccessibleDescription = null;
            this.splitContainer1.Panel1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.BackgroundImage = null;
            this.splitContainer1.Panel1.Controls.Add(this.grdOrderlist);
            this.splitContainer1.Panel1.Font = null;
            this.toolTip.SetToolTip(this.splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.ToolTip"));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AccessibleDescription = null;
            this.splitContainer1.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.BackgroundImage = null;
            this.splitContainer1.Panel2.Controls.Add(this.calSchedule);
            this.splitContainer1.Panel2.Font = null;
            this.toolTip.SetToolTip(this.splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.ToolTip"));
            this.toolTip.SetToolTip(this.splitContainer1, resources.GetString("splitContainer1.ToolTip"));
            // 
            // grdOrderlist
            // 
            resources.ApplyResources(this.grdOrderlist, "grdOrderlist");
            this.grdOrderlist.ApplyPaintEventToAllColumn = true;
            this.grdOrderlist.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell4,
            this.xEditGridCell90,
            this.xEditGridCell91,
            this.xEditGridCell3,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell100,
            this.xEditGridCell5,
            this.xEditGridCell98,
            this.xEditGridCell2,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell99,
            this.xEditGridCell19});
            this.grdOrderlist.ColPerLine = 10;
            this.grdOrderlist.Cols = 10;
            this.grdOrderlist.ExecuteQuery = null;
            this.grdOrderlist.FixedRows = 1;
            this.grdOrderlist.HeaderHeights.Add(35);
            this.grdOrderlist.ImageList = this.ImageList;
            this.grdOrderlist.Name = "grdOrderlist";
            this.grdOrderlist.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrderlist.ParamList")));
            this.grdOrderlist.Rows = 2;
            this.toolTip.SetToolTip(this.grdOrderlist, resources.GetString("grdOrderlist.ToolTip"));
            this.grdOrderlist.ToolTipActive = true;
            this.grdOrderlist.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.xGridOrderlist_GridButtonClick);
            this.grdOrderlist.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.xGridOrderlist_QueryEnd);
            this.grdOrderlist.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.xGridOrderlist_RowFocusChanged);
            this.grdOrderlist.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrderlist_GridCellPainting);
            this.grdOrderlist.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOrderlist_GridColumnProtectModify);
            this.grdOrderlist.QueryStarting += new System.ComponentModel.CancelEventHandler(this.xGridOrderlist_QueryStarting);
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell86.CellName = "hangmog_code";
            this.xEditGridCell86.CellWidth = 40;
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            this.xEditGridCell86.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            this.xEditGridCell86.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell87.CellName = "hangmog_name";
            this.xEditGridCell87.CellWidth = 175;
            this.xEditGridCell87.Col = 1;
            this.xEditGridCell87.ExecuteQuery = null;
            this.xEditGridCell87.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsReadOnly = true;
            this.xEditGridCell87.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell88.CellName = "jundal_table";
            this.xEditGridCell88.CellWidth = 83;
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            this.xEditGridCell88.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            this.xEditGridCell88.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell89.CellName = "jundal_part";
            this.xEditGridCell89.CellWidth = 120;
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            this.xEditGridCell89.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            this.xEditGridCell89.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "jundal_part_name";
            this.xEditGridCell4.CellWidth = 130;
            this.xEditGridCell4.Col = 5;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell90.CellName = "pksch0201";
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.ExecuteQuery = null;
            this.xEditGridCell90.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            this.xEditGridCell90.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell91.CellName = "bunho";
            this.xEditGridCell91.Col = -1;
            this.xEditGridCell91.ExecuteQuery = null;
            this.xEditGridCell91.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsVisible = false;
            this.xEditGridCell91.Row = -1;
            this.xEditGridCell91.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellName = "suname";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell92.CellName = "gwa";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            this.xEditGridCell92.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            this.xEditGridCell92.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell93.CellName = "gwa_name";
            this.xEditGridCell93.CellWidth = 75;
            this.xEditGridCell93.Col = 2;
            this.xEditGridCell93.ExecuteQuery = null;
            this.xEditGridCell93.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsReadOnly = true;
            this.xEditGridCell93.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell94.CellName = "doctor";
            this.xEditGridCell94.Col = -1;
            this.xEditGridCell94.ExecuteQuery = null;
            this.xEditGridCell94.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsVisible = false;
            this.xEditGridCell94.Row = -1;
            this.xEditGridCell94.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell95.CellName = "doctor_name";
            this.xEditGridCell95.CellWidth = 70;
            this.xEditGridCell95.Col = 3;
            this.xEditGridCell95.ExecuteQuery = null;
            this.xEditGridCell95.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            this.xEditGridCell95.IsReadOnly = true;
            this.xEditGridCell95.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell96.CellName = "order_date";
            this.xEditGridCell96.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell96.CellWidth = 100;
            this.xEditGridCell96.Col = 4;
            this.xEditGridCell96.ExecuteQuery = null;
            this.xEditGridCell96.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            this.xEditGridCell96.IsReadOnly = true;
            this.xEditGridCell96.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell97.CellName = "emergency";
            this.xEditGridCell97.CellWidth = 48;
            this.xEditGridCell97.Col = 8;
            this.xEditGridCell97.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell97.ExecuteQuery = null;
            this.xEditGridCell97.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            this.xEditGridCell97.IsReadOnly = true;
            this.xEditGridCell97.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell97.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell100.CellName = "reser_date";
            this.xEditGridCell100.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell100.CellWidth = 144;
            this.xEditGridCell100.Col = 6;
            this.xEditGridCell100.ExecuteQuery = null;
            this.xEditGridCell100.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsReadOnly = true;
            this.xEditGridCell100.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellName = "reser_time";
            this.xEditGridCell5.Col = 7;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.Mask = "##:##";
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell98.CellName = "order_remark";
            this.xEditGridCell98.Col = 9;
            this.xEditGridCell98.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell98.ExecuteQuery = null;
            this.xEditGridCell98.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.HeaderTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xEditGridCell98.IsReadOnly = true;
            this.xEditGridCell98.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell98.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellName = "reser_yn";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellName = "pkout1001";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellName = "group_ser";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell99.CellName = "button";
            this.xEditGridCell99.CellWidth = 82;
            this.xEditGridCell99.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell99.ExecuteQuery = null;
            this.xEditGridCell99.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell99.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell99.ToolTipText = "予約を登録します。";
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.CellName = "out_hosp_code";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            this.xEditGridCell19.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // calSchedule
            // 
            this.calSchedule.AccessibleDescription = null;
            this.calSchedule.AccessibleName = null;
            resources.ApplyResources(this.calSchedule, "calSchedule");
            this.calSchedule.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Inset;
            this.calSchedule.EnableMultiSelection = false;
            this.calSchedule.Footer.ShowToday = false;
            this.calSchedule.FullHolidaySelectable = true;
            this.calSchedule.Header.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calSchedule.ImageList = this.ImageList;
            this.calSchedule.IsJapanYearType = true;
            this.calSchedule.MaxDate = new System.DateTime(2030, 1, 11, 0, 0, 0, 0);
            this.calSchedule.MinDate = new System.DateTime(1996, 1, 11, 0, 0, 0, 0);
            this.calSchedule.Name = "calSchedule";
            this.calSchedule.ShowFooter = false;
            this.calSchedule.ToggleSelection = true;
            this.toolTip.SetToolTip(this.calSchedule, resources.GetString("calSchedule.ToolTip"));
            this.calSchedule.WeekDays.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.calSchedule.DaySelected += new IHIS.Framework.XCalendarDaySelectedEventHandler(this.calSchedule_DaySelected);
            this.calSchedule.DayClick += new IHIS.Framework.XCalendarDayClickEventHandler(this.calSchedule_DayClick);
            this.calSchedule.MonthChanged += new IHIS.Framework.XCalendarMonthChangedEventHandler(this.calSchedule_MonthChanged);
            // 
            // pnlPatient
            // 
            this.pnlPatient.AccessibleDescription = null;
            this.pnlPatient.AccessibleName = null;
            resources.ApplyResources(this.pnlPatient, "pnlPatient");
            this.pnlPatient.BackgroundImage = null;
            this.pnlPatient.Controls.Add(this.paBox);
            this.pnlPatient.Font = null;
            this.pnlPatient.Name = "pnlPatient";
            this.toolTip.SetToolTip(this.pnlPatient, resources.GetString("pnlPatient.ToolTip"));
            // 
            // paBox
            // 
            this.paBox.AccessibleDescription = null;
            this.paBox.AccessibleName = null;
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.BackgroundImage = null;
            this.paBox.Name = "paBox";
            this.toolTip.SetToolTip(this.paBox, resources.GetString("paBox.ToolTip"));
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel2.Controls.Add(this.btnInsertSch);
            this.xPanel2.Controls.Add(this.btnComment);
            this.xPanel2.Controls.Add(this.btnReserOrder);
            this.xPanel2.Controls.Add(this.btnReserScript);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            this.toolTip.SetToolTip(this.xPanel2, resources.GetString("xPanel2.ToolTip"));
            // 
            // btnInsertSch
            // 
            this.btnInsertSch.AccessibleDescription = null;
            this.btnInsertSch.AccessibleName = null;
            resources.ApplyResources(this.btnInsertSch, "btnInsertSch");
            this.btnInsertSch.BackgroundImage = null;
            this.btnInsertSch.ImageIndex = 14;
            this.btnInsertSch.ImageList = this.ImageList;
            this.btnInsertSch.Name = "btnInsertSch";
            this.btnInsertSch.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.toolTip.SetToolTip(this.btnInsertSch, resources.GetString("btnInsertSch.ToolTip"));
            this.btnInsertSch.Click += new System.EventHandler(this.btnInsertSch_Click);
            // 
            // btnComment
            // 
            this.btnComment.AccessibleDescription = null;
            this.btnComment.AccessibleName = null;
            resources.ApplyResources(this.btnComment, "btnComment");
            this.btnComment.BackgroundImage = null;
            this.btnComment.ImageIndex = 5;
            this.btnComment.ImageList = this.ImageList;
            this.btnComment.Name = "btnComment";
            this.btnComment.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.toolTip.SetToolTip(this.btnComment, resources.GetString("btnComment.ToolTip"));
            this.btnComment.Click += new System.EventHandler(this.btnComment_Click);
            // 
            // btnReserOrder
            // 
            this.btnReserOrder.AccessibleDescription = null;
            this.btnReserOrder.AccessibleName = null;
            resources.ApplyResources(this.btnReserOrder, "btnReserOrder");
            this.btnReserOrder.BackgroundImage = null;
            this.btnReserOrder.ImageIndex = 10;
            this.btnReserOrder.ImageList = this.ImageList;
            this.btnReserOrder.Name = "btnReserOrder";
            this.btnReserOrder.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.toolTip.SetToolTip(this.btnReserOrder, resources.GetString("btnReserOrder.ToolTip"));
            // 
            // btnReserScript
            // 
            this.btnReserScript.AccessibleDescription = null;
            this.btnReserScript.AccessibleName = null;
            resources.ApplyResources(this.btnReserScript, "btnReserScript");
            this.btnReserScript.BackgroundImage = null;
            this.btnReserScript.ImageIndex = 8;
            this.btnReserScript.ImageList = this.ImageList;
            this.btnReserScript.Name = "btnReserScript";
            this.btnReserScript.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.toolTip.SetToolTip(this.btnReserScript, resources.GetString("btnReserScript.ToolTip"));
            this.btnReserScript.Click += new System.EventHandler(this.btnReserScript_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.toolTip.SetToolTip(this.xButtonList1, resources.GetString("xButtonList1.ToolTip"));
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // pnlDoctor
            // 
            this.pnlDoctor.AccessibleDescription = null;
            this.pnlDoctor.AccessibleName = null;
            resources.ApplyResources(this.pnlDoctor, "pnlDoctor");
            this.pnlDoctor.Controls.Add(this.cboGwa);
            this.pnlDoctor.Controls.Add(this.xLabel5);
            this.pnlDoctor.Controls.Add(this.btnClear);
            this.pnlDoctor.Controls.Add(this.dbxDoctor_name);
            this.pnlDoctor.Controls.Add(this.fbxDoctor);
            this.pnlDoctor.Controls.Add(this.xLabel6);
            this.pnlDoctor.Controls.Add(this.dbxLinkHospName);
            this.pnlDoctor.Controls.Add(this.fbxLinkHospCode);
            this.pnlDoctor.Controls.Add(this.xLabel4);
            this.pnlDoctor.Controls.Add(this.rbtOtherClinic);
            this.pnlDoctor.Controls.Add(this.rbtMyClinic);
            this.pnlDoctor.Controls.Add(this.xLabel3);
            this.pnlDoctor.Controls.Add(this.cboGumsaPart);
            this.pnlDoctor.Controls.Add(this.xLabel1);
            this.pnlDoctor.Controls.Add(this.cboReserStatus);
            this.pnlDoctor.Controls.Add(this.xLabel12);
            this.pnlDoctor.Controls.Add(this.cboGumsa);
            this.pnlDoctor.Controls.Add(this.xlbSelectedDate);
            this.pnlDoctor.Controls.Add(this.xlbJundalPart);
            this.pnlDoctor.Font = null;
            this.pnlDoctor.Name = "pnlDoctor";
            this.toolTip.SetToolTip(this.pnlDoctor, resources.GetString("pnlDoctor.ToolTip"));
            // 
            // cboGwa
            // 
            this.cboGwa.AccessibleDescription = null;
            this.cboGwa.AccessibleName = null;
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.BackgroundImage = null;
            this.cboGwa.Name = "cboGwa";
            this.toolTip.SetToolTip(this.cboGwa, resources.GetString("cboGwa.ToolTip"));
            this.cboGwa.SelectedIndexChanged += new System.EventHandler(this.cboGwa_SelectedIndexChanged);
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            this.toolTip.SetToolTip(this.xLabel5, resources.GetString("xLabel5.ToolTip"));
            // 
            // btnClear
            // 
            this.btnClear.AccessibleDescription = null;
            this.btnClear.AccessibleName = null;
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.BackgroundImage = null;
            this.btnClear.ImageIndex = 9;
            this.btnClear.ImageList = this.ImageList;
            this.btnClear.Name = "btnClear";
            this.toolTip.SetToolTip(this.btnClear, resources.GetString("btnClear.ToolTip"));
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dbxDoctor_name
            // 
            this.dbxDoctor_name.AccessibleDescription = null;
            this.dbxDoctor_name.AccessibleName = null;
            resources.ApplyResources(this.dbxDoctor_name, "dbxDoctor_name");
            this.dbxDoctor_name.EdgeRounding = false;
            this.dbxDoctor_name.Image = null;
            this.dbxDoctor_name.Name = "dbxDoctor_name";
            this.toolTip.SetToolTip(this.dbxDoctor_name, resources.GetString("dbxDoctor_name.ToolTip"));
            // 
            // fbxDoctor
            // 
            this.fbxDoctor.AccessibleDescription = null;
            this.fbxDoctor.AccessibleName = null;
            resources.ApplyResources(this.fbxDoctor, "fbxDoctor");
            this.fbxDoctor.BackgroundImage = null;
            this.fbxDoctor.EnableEdit = false;
            this.fbxDoctor.Name = "fbxDoctor";
            this.fbxDoctor.ReadOnly = true;
            this.fbxDoctor.TabStop = false;
            this.toolTip.SetToolTip(this.fbxDoctor, resources.GetString("fbxDoctor.ToolTip"));
            this.fbxDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxDoctor_DataValidating);
            this.fbxDoctor.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxDoctor_FindClick);
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            this.toolTip.SetToolTip(this.xLabel6, resources.GetString("xLabel6.ToolTip"));
            // 
            // dbxLinkHospName
            // 
            this.dbxLinkHospName.AccessibleDescription = null;
            this.dbxLinkHospName.AccessibleName = null;
            resources.ApplyResources(this.dbxLinkHospName, "dbxLinkHospName");
            this.dbxLinkHospName.EdgeRounding = false;
            this.dbxLinkHospName.Image = null;
            this.dbxLinkHospName.Name = "dbxLinkHospName";
            this.toolTip.SetToolTip(this.dbxLinkHospName, resources.GetString("dbxLinkHospName.ToolTip"));
            // 
            // fbxLinkHospCode
            // 
            this.fbxLinkHospCode.AccessibleDescription = null;
            this.fbxLinkHospCode.AccessibleName = null;
            resources.ApplyResources(this.fbxLinkHospCode, "fbxLinkHospCode");
            this.fbxLinkHospCode.BackgroundImage = null;
            this.fbxLinkHospCode.EnableEdit = false;
            this.fbxLinkHospCode.FindWorker = this.fwkLinkHospCode;
            this.fbxLinkHospCode.Name = "fbxLinkHospCode";
            this.fbxLinkHospCode.ReadOnly = true;
            this.fbxLinkHospCode.TabStop = false;
            this.toolTip.SetToolTip(this.fbxLinkHospCode, resources.GetString("fbxLinkHospCode.ToolTip"));
            this.fbxLinkHospCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxLinkHospCode_DataValidating);
            this.fbxLinkHospCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxLinkHospCode_FindClick);
            // 
            // fwkLinkHospCode
            // 
            this.fwkLinkHospCode.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2,
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkLinkHospCode.ExecuteQuery = null;
            this.fwkLinkHospCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkLinkHospCode.ParamList")));
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "hosp_code";
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "hosp_name";
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "address";
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "tel";
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            this.toolTip.SetToolTip(this.xLabel4, resources.GetString("xLabel4.ToolTip"));
            // 
            // rbtOtherClinic
            // 
            this.rbtOtherClinic.AccessibleDescription = null;
            this.rbtOtherClinic.AccessibleName = null;
            resources.ApplyResources(this.rbtOtherClinic, "rbtOtherClinic");
            this.rbtOtherClinic.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtOtherClinic.BackgroundImage = null;
            this.rbtOtherClinic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtOtherClinic.Font = null;
            this.rbtOtherClinic.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbtOtherClinic.ImageList = this.ImageList;
            this.rbtOtherClinic.Name = "rbtOtherClinic";
            this.toolTip.SetToolTip(this.rbtOtherClinic, resources.GetString("rbtOtherClinic.ToolTip"));
            this.rbtOtherClinic.UseVisualStyleBackColor = false;
            this.rbtOtherClinic.CheckedChanged += new System.EventHandler(this.rbtOtherClinic_CheckedChanged);
            // 
            // rbtMyClinic
            // 
            this.rbtMyClinic.AccessibleDescription = null;
            this.rbtMyClinic.AccessibleName = null;
            resources.ApplyResources(this.rbtMyClinic, "rbtMyClinic");
            this.rbtMyClinic.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbtMyClinic.BackgroundImage = null;
            this.rbtMyClinic.Checked = true;
            this.rbtMyClinic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtMyClinic.Font = null;
            this.rbtMyClinic.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbtMyClinic.ImageList = this.ImageList;
            this.rbtMyClinic.Name = "rbtMyClinic";
            this.rbtMyClinic.TabStop = true;
            this.toolTip.SetToolTip(this.rbtMyClinic, resources.GetString("rbtMyClinic.ToolTip"));
            this.rbtMyClinic.UseVisualStyleBackColor = false;
            this.rbtMyClinic.CheckedChanged += new System.EventHandler(this.rbtMyClinic_CheckedChanged);
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            this.toolTip.SetToolTip(this.xLabel3, resources.GetString("xLabel3.ToolTip"));
            // 
            // cboGumsaPart
            // 
            this.cboGumsaPart.AccessibleDescription = null;
            this.cboGumsaPart.AccessibleName = null;
            resources.ApplyResources(this.cboGumsaPart, "cboGumsaPart");
            this.cboGumsaPart.BackgroundImage = null;
            this.cboGumsaPart.ExecuteQuery = null;
            this.cboGumsaPart.Name = "cboGumsaPart";
            this.cboGumsaPart.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboGumsaPart.ParamList")));
            this.cboGumsaPart.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.toolTip.SetToolTip(this.cboGumsaPart, resources.GetString("cboGumsaPart.ToolTip"));
            this.cboGumsaPart.SelectedIndexChanged += new System.EventHandler(this.cboGumsaPart_SelectedIndexChanged);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            this.toolTip.SetToolTip(this.xLabel1, resources.GetString("xLabel1.ToolTip"));
            // 
            // cboReserStatus
            // 
            this.cboReserStatus.AccessibleDescription = null;
            this.cboReserStatus.AccessibleName = null;
            resources.ApplyResources(this.cboReserStatus, "cboReserStatus");
            this.cboReserStatus.BackgroundImage = null;
            this.cboReserStatus.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3});
            this.cboReserStatus.ExecuteQuery = null;
            this.cboReserStatus.Name = "cboReserStatus";
            this.cboReserStatus.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboReserStatus.ParamList")));
            this.toolTip.SetToolTip(this.cboReserStatus, resources.GetString("cboReserStatus.ToolTip"));
            this.cboReserStatus.SelectedIndexChanged += new System.EventHandler(this.cboReserStatus_SelectedIndexChanged);
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "A";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "D";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "T";
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
            this.toolTip.SetToolTip(this.xLabel12, resources.GetString("xLabel12.ToolTip"));
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
            this.toolTip.SetToolTip(this.cboGumsa, resources.GetString("cboGumsa.ToolTip"));
            this.cboGumsa.SelectedIndexChanged += new System.EventHandler(this.cboGumsa_SelectedIndexChanged);
            // 
            // xlbSelectedDate
            // 
            this.xlbSelectedDate.AccessibleDescription = null;
            this.xlbSelectedDate.AccessibleName = null;
            resources.ApplyResources(this.xlbSelectedDate, "xlbSelectedDate");
            this.xlbSelectedDate.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xlbSelectedDate.BorderColor = IHIS.Framework.XColor.XMatrixLineColor;
            this.xlbSelectedDate.ForeColor = IHIS.Framework.XColor.XRotatorBorderColor;
            this.xlbSelectedDate.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.SkyBlue);
            this.xlbSelectedDate.Image = null;
            this.xlbSelectedDate.Name = "xlbSelectedDate";
            this.toolTip.SetToolTip(this.xlbSelectedDate, resources.GetString("xlbSelectedDate.ToolTip"));
            // 
            // xlbJundalPart
            // 
            this.xlbJundalPart.AccessibleDescription = null;
            this.xlbJundalPart.AccessibleName = null;
            resources.ApplyResources(this.xlbJundalPart, "xlbJundalPart");
            this.xlbJundalPart.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xlbJundalPart.BorderColor = IHIS.Framework.XColor.XMatrixLineColor;
            this.xlbJundalPart.ForeColor = IHIS.Framework.XColor.XRotatorBorderColor;
            this.xlbJundalPart.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.SkyBlue);
            this.xlbJundalPart.Image = null;
            this.xlbJundalPart.Name = "xlbJundalPart";
            this.toolTip.SetToolTip(this.xlbJundalPart, resources.GetString("xlbJundalPart.ToolTip"));
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.splitContainer1);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            this.toolTip.SetToolTip(this.xPanel1, resources.GetString("xPanel1.ToolTip"));
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel2.Name = "xLabel2";
            this.toolTip.SetToolTip(this.xLabel2, resources.GetString("xLabel2.ToolTip"));
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackgroundImage = null;
            this.panel1.Controls.Add(this.btnExpand);
            this.panel1.Controls.Add(this.grdTimeList);
            this.panel1.Controls.Add(this.grdPkschList);
            this.panel1.Controls.Add(this.xlbReserList);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            this.toolTip.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
            // 
            // btnExpand
            // 
            this.btnExpand.AccessibleDescription = null;
            this.btnExpand.AccessibleName = null;
            resources.ApplyResources(this.btnExpand, "btnExpand");
            this.btnExpand.BackgroundImage = null;
            this.btnExpand.ImageIndex = 16;
            this.btnExpand.ImageList = this.ImageList;
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.toolTip.SetToolTip(this.btnExpand, resources.GetString("btnExpand.ToolTip"));
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // grdTimeList
            // 
            resources.ApplyResources(this.grdTimeList, "grdTimeList");
            this.grdTimeList.ApplyPaintEventToAllColumn = true;
            this.grdTimeList.CallerID = '2';
            this.grdTimeList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell44,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell17,
            this.xEditGridCell1,
            this.xEditGridCell18,
            this.xEditGridCell9,
            this.xEditGridCell16,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12});
            this.grdTimeList.ColPerLine = 8;
            this.grdTimeList.Cols = 9;
            this.grdTimeList.ExecuteQuery = null;
            this.grdTimeList.FixedCols = 1;
            this.grdTimeList.FixedRows = 1;
            this.grdTimeList.HeaderHeights.Add(32);
            this.grdTimeList.Name = "grdTimeList";
            this.grdTimeList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdTimeList.ParamList")));
            this.grdTimeList.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdTimeList.RowHeaderVisible = true;
            this.grdTimeList.Rows = 2;
            this.grdTimeList.Tag = "0900";
            this.toolTip.SetToolTip(this.grdTimeList, resources.GetString("grdTimeList.ToolTip"));
            this.grdTimeList.ToolTipActive = true;
            this.grdTimeList.MouseLeave += new System.EventHandler(this.grdTimeList_MouseLeave);
            this.grdTimeList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.xEditGridTimeList_MouseDoubleClick);
            this.grdTimeList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grdTimeList_MouseMove);
            this.grdTimeList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdTimeList_GridCellPainting);
            this.grdTimeList.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOrderlist_GridColumnProtectModify);
            this.grdTimeList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.xEditGridTimeList_QueryStarting);
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell44.CellName = "from_time";
            this.xEditGridCell44.CellWidth = 130;
            this.xEditGridCell44.Col = 2;
            this.xEditGridCell44.ExecuteQuery = null;
            this.xEditGridCell44.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsReadOnly = true;
            this.xEditGridCell44.Mask = "##:##";
            this.xEditGridCell44.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell44.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.CellName = "bunho";
            this.xEditGridCell13.CellWidth = 1;
            this.xEditGridCell13.Col = 3;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell14.CellName = "suname";
            this.xEditGridCell14.CellWidth = 83;
            this.xEditGridCell14.Col = 4;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell15.CellName = "hangmog_name";
            this.xEditGridCell15.CellWidth = 189;
            this.xEditGridCell15.Col = 5;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.CellName = "doctor_name";
            this.xEditGridCell17.CellWidth = 88;
            this.xEditGridCell17.Col = 6;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellName = "input_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 103;
            this.xEditGridCell1.Col = 7;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell18.CellName = "order_date";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellName = "reser_date";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell9.CellWidth = 120;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.CellName = "pksch0201";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.CellName = "hosp_code";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.CellLen = 100;
            this.xEditGridCell11.CellName = "yoyang_name";
            this.xEditGridCell11.Col = 8;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.CellName = "temp";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // grdPkschList
            // 
            resources.ApplyResources(this.grdPkschList, "grdPkschList");
            this.grdPkschList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell8});
            this.grdPkschList.ColPerLine = 1;
            this.grdPkschList.Cols = 1;
            this.grdPkschList.ExecuteQuery = null;
            this.grdPkschList.FixedRows = 1;
            this.grdPkschList.HeaderHeights.Add(18);
            this.grdPkschList.Name = "grdPkschList";
            this.grdPkschList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPkschList.ParamList")));
            this.grdPkschList.Rows = 2;
            this.toolTip.SetToolTip(this.grdPkschList, resources.GetString("grdPkschList.ToolTip"));
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellName = "pksch";
            this.xEditGridCell8.CellWidth = 89;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xlbReserList
            // 
            this.xlbReserList.AccessibleDescription = null;
            this.xlbReserList.AccessibleName = null;
            resources.ApplyResources(this.xlbReserList, "xlbReserList");
            this.xlbReserList.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xlbReserList.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xlbReserList.Name = "xlbReserList";
            this.toolTip.SetToolTip(this.xlbReserList, resources.GetString("xlbReserList.ToolTip"));
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell33.CellLen = 1;
            this.xEditGridCell33.CellName = "newrow";
            this.xEditGridCell33.Col = 8;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell27.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell27.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell27.ButtonImage")));
            this.xEditGridCell27.CellName = "modify";
            this.xEditGridCell27.CellWidth = 68;
            this.xEditGridCell27.Col = 6;
            this.xEditGridCell27.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell27.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layDateSchedule
            // 
            this.layDateSchedule.ExecuteQuery = null;
            this.layDateSchedule.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            this.layDateSchedule.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDateSchedule.ParamList")));
            this.layDateSchedule.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDateSchedule_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "dayofmon";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "check_yn";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "inwon";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "outwon";
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell52.CellName = "res_gubun";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            this.xEditGridCell52.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsUpdatable = false;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            this.xEditGridCell52.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // layReserList
            // 
            this.layReserList.ExecuteQuery = null;
            this.layReserList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19});
            this.layReserList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserList.ParamList")));
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "jinryo_pre_date";
            this.multiLayoutItem15.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "jinryo_pre_time";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "gwa_name";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "doctor_name";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "gwa";
            // 
            // splitter1
            // 
            this.splitter1.AccessibleDescription = null;
            this.splitter1.AccessibleName = null;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackgroundImage = null;
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Font = null;
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            this.toolTip.SetToolTip(this.splitter1, resources.GetString("splitter1.ToolTip"));
            // 
            // layTimeList
            // 
            this.layTimeList.ExecuteQuery = null;
            this.layTimeList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layTimeList.ParamList")));
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            // 
            // layReserTimeChk
            // 
            this.layReserTimeChk.ExecuteQuery = null;
            this.layReserTimeChk.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem4});
            this.layReserTimeChk.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserTimeChk.ParamList")));
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "reser_chk";
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // SCH0201U99
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.pnlDoctor);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.pnlPatient);
            this.Name = "SCH0201U99";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.SCH0201U99_Load);
            this.UserChanged += new System.EventHandler(this.SCH0201U99_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.SCH0201U99_ScreenOpen);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calSchedule)).EndInit();
            this.pnlPatient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.pnlDoctor.ResumeLayout(false);
            this.pnlDoctor.PerformLayout();
            this.xPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTimeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPkschList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDateSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTimeList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]

        public override object Command(string command, CommonItemCollection commandParam)
        {
            if (command == "OCS0270Q00")
            {
                cboGwa.SetDataValue(commandParam["gwa"].ToString());
                fbxDoctor.SetEditValue(commandParam["doctor"].ToString());
                fbxDoctor.AcceptData();
                fbxDoctor.Focus();
                fbxDoctor.SelectAll();
            }           
            return base.Command(command, commandParam);
        }

        #region OnLoad [OnLoadイベント]
        protected override void OnLoad(EventArgs e)
        {
            Form form = ((Form)Parent.Parent);

            Size formSize = new Size(1000, 500);
            //form.MinimumSize = formSize;

			base.OnLoad (e);
            mHospCode = EnvironInfo.HospCode;

            if(NetInfo.Language != LangMode.Jr)
                calSchedule.IsJapanYearType = false;
            XPatientInfo patientInfo = GetPreviousScreenBunHo(true);
			if (patientInfo != null)
			    mBunho = patientInfo.BunHo;
            // add new feature Kobari
            fwkLinkHospCode.ExecuteQuery = LoadDataLinkHospCode;


			PostCallHelper.PostCall(PostLoad);
        }
        #endregion

        #region ScreenOpen [ScreenOpenイベント]
        private void SCH0201U99_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            LookAndFeel("B");
            mHospCode = EnvironInfo.HospCode;
			//CreateCombo();         

            //화면 사이즈 조정
            Rectangle rc = Screen.PrimaryScreen.WorkingArea;


			// Call된 경우
			if ( OpenParam != null )
            {
				try
				{
					// 등록번호
					if(OpenParam.Contains("bunho")) 
					{
						if(!TypeCheck.IsNull(OpenParam["bunho"].ToString().Trim()))
							mBunho = OpenParam["bunho"].ToString().Trim();
					}

					// 등록번호
                    if (OpenParam.Contains("pkinp1001")) 
					{
                        if (!TypeCheck.IsNull(OpenParam["pkinp1001"].ToString().Trim()))
                            pkinp1001 = OpenParam["pkinp1001"].ToString().Trim();
					}
                    
					// 진료과, 진료의사
					if(OpenParam.Contains("gwa"))
					{
						if(!TypeCheck.IsNull(OpenParam["gwa"].ToString().Trim()))
						{
							mGwa = OpenParam["gwa"].ToString().Trim();

							if(OpenParam.Contains("doctor"))
							{
								if(!TypeCheck.IsNull(OpenParam["doctor"].ToString().Trim()))
								{
									mDoctor = OpenParam["doctor"].ToString().Trim();
								}							
							}
						}
					}
				
					if(OpenParam.Contains("naewon_date"))
					{
						if(TypeCheck.IsDateTime(OpenParam["naewon_date"].ToString()))
							mNaewon_date = OpenParam["naewon_date"].ToString();
					}

                    if (OpenParam.Contains("caller_name"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["caller_name"].ToString().Trim()))
                        {
                            mCallerName = OpenParam["caller_name"].ToString().Trim();
                        }
                    }
                }
				catch (Exception ex)
				{
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, Resources.MSGTitleError,MessageBoxButtons.OK,MessageBoxIcon.Error);	
					Close();
				}
			}
			else
			{
                // 혹시 다른 스크린에서 받아올수 있는지 판단.
                // 이전 스크린의 등록번호를 가져온다
                if (paBox.BunHo == "")
                {
                    XPatientInfo patientInfo = GetPreviousScreenBunHo(true);

                    if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                    {
                        // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                        patientInfo = GetOtherScreenBunHo(this, true);
                    }

                    if (patientInfo != null && !TypeCheck.IsNull(patientInfo.BunHo))
                    {
                        paBox.SetPatientID(patientInfo.BunHo);
                    }
                }
			}
        }
        #endregion

        #region PostLoad [PostLoadイベント]
        //private bool mCalledByPostLoad = false;
		private void PostLoad()
		{
            //현재 년,월로 Active
            calSchedule.SetActiveMonth(int.Parse(EnvironInfo.GetSysDate().ToString("yyyy")), int.Parse(EnvironInfo.GetSysDate().ToString("MM")));

            //현재 일자 select
            calSchedule.DaySelected -= calSchedule_DaySelected;
            if (mNaewon_date != "")
                calSchedule.SelectDate(Convert.ToDateTime(mNaewon_date));
            else
                calSchedule.SelectDate(EnvironInfo.GetSysDate());
            calSchedule.DaySelected += calSchedule_DaySelected;

            if (calSchedule.SelectedDays.Count > 0)
            {
                mCurrentDate = calSchedule.SelectedDays[0].Date.ToString("yyyy/MM/dd").Replace("-","/");
            }

			// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
            //mCalledByPostLoad = true;
            //this.SCH0201U99_UserChanged(this, new System.EventArgs());
            //mCalledByPostLoad = false;
			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			
            //if(UserInfo.UserGubun != UserType.Doctor)
            //{
            //    if( !TypeCheck.IsNull(mGwa) )
            //    {
            //        this.cboGwa.SetEditValue(mGwa);

            //        if( !TypeCheck.IsNull(mDoctor) )
            //        {
            //            this.fbxDoctor.SetEditValue(mDoctor);

            //            this.fbxDoctor.AcceptData();
            //        }
            //    }
            //}

            //else if (UserInfo.UserGubun == UserType.Doctor)
            //{
            //    this.cboGwa.SetEditValue(UserInfo.Gwa);
            //    SetDataDoctorSchedule(UserInfo.DoctorID, EnvironInfo.GetSysDate().ToString("yyyyMM"));
            //    this.fbxDoctor.SetEditValue(UserInfo.DoctorID);
            //}

			// 등록번호
			if( !TypeCheck.IsNull(mBunho) )
				paBox.SetPatientID(mBunho);

            //if(UserInfo.UserGubun != UserType.Doctor)
            //{
            //    XMessageBox.Show("入力されている予約者IDと自分のIDが違う場合には予約者IDに自分のIDを入力してください。", "予約者ID確認", MessageBoxIcon.Information);
            //    this.txtUser.Focus();
            //    this.txtUser.SelectAll();
            //}


            // 検査区分Default選択
            cboGumsa.SetEditValue("%");
            // 検査状況Default選択
            cboReserStatus.SetEditValue("A");
            
        }
        #endregion

        private void SCH0201U99_UserChanged(object sender, EventArgs e)
		{
            //if(UserInfo.UserGubun == UserType.Doctor)
            //{
            //    mInput_gubun = "D";
            //    //포스트로드에서 불릴 경우 오픈파람을 그대로 사용함
            //    if (!mCalledByPostLoad)
            //    {
            //        mDoctor = UserInfo.DoctorID;
            //        mGwa = UserInfo.Gwa;
            //    }

            //    if (mDoctor == "")
            //        mDoctor = UserInfo.DoctorID;

            //    if (mGwa == "")
            //        mGwa = UserInfo.Gwa;

            //    //mChanggu = "OCSO";
            //    mChanggu = UserInfo.UserID;
			
            //    this.cboGwa.SetEditValue(mGwa);
              

            //    this.fbxDoctor.SetEditValue(mDoctor);
            //    this.fbxDoctor.AcceptData();
            //    this.fbxDoctor.Focus();
            //    this.fbxDoctor.SelectAll();
				
            //}
            //else if(UserInfo.UserGubun == UserType.Nurse)
            //{
            //    mInput_gubun = "N";
            //    //mChanggu = "SCHS";
            //    mChanggu = UserInfo.UserID;
            //    mGwa = this.cboGwa.GetDataValue();
                 
            //}
            //else
            //{   
            //    mInput_gubun = "E";
            //    //mChanggu = "OUTO";
            //    mChanggu = UserInfo.UserID; 
            //    mGwa = this.cboGwa.GetDataValue();
              
            //}	
		}

		#endregion

        #region CreateCombo　[Combo 生成]

        private void CreateCombo()
        {
            MultiLayout layoutCombo = new MultiLayout();

            //초재구분
            layoutCombo.Reset();
            layoutCombo.LayoutItems.Clear();
            layoutCombo.LayoutItems.Add("code", DataType.String);
            layoutCombo.LayoutItems.Add("code_name", DataType.String);
            layoutCombo.InitializeLayoutTable();


            layoutCombo.ExecuteQuery = ComboChoJae;

            //if (layoutCombo.QueryLayout(true) && layoutCombo.RowCount > 0)
            //{
            //    grdOUT1001_AM.SetComboItems("chojae", layoutCombo.LayoutTable, "code_name", "code");
            //    grdOUT1001_PM.SetComboItems("chojae", layoutCombo.LayoutTable, "code_name", "code");
            //}

            //if(mInput_gubun != "D") return;

            //진료과
            layoutCombo.Reset();
            layoutCombo.LayoutItems.Clear();
            layoutCombo.LayoutItems.Add("gwa", DataType.String);
            layoutCombo.LayoutItems.Add("gwa_name", DataType.String);
            layoutCombo.InitializeLayoutTable();

            layoutCombo.ExecuteQuery = ComboGwa;

            layoutCombo.ParamList = new List<string>(new String[] { "f_hosp_code" });
            layoutCombo.SetBindVarValue("f_hosp_code", mHospCode);
            if (layoutCombo.QueryLayout(true) && layoutCombo.RowCount > 0)
            {
                cboGwa.SelectedIndexChanged -= cboGwa_SelectedIndexChanged;
                cboGwa.SetComboItems(layoutCombo.LayoutTable, "gwa_name", "gwa");
                cboGwa.SelectedIndex = 0;
                cboGwa.SelectedIndexChanged += cboGwa_SelectedIndexChanged;
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
                paBox.Focus();
                paBox.SetPatientID(info.BunHo);
            }
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(paBox.BunHo.ToString()))
            {
                return new XPatientInfo(paBox.BunHo.ToString(), "", "", "", ScreenName);
            }

            return null;
        }
        #endregion


        #region xButtonList1_ButtonClick　[照会ボタンクリックイベント]

        private void xButtonList1_ButtonClick(object sender, ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
                case FunctionType.Query:

                    //mDoctor = this.fbxDoctor.GetDataValue().Trim();

                    // 患者番号チェック
                    if (TypeCheck.IsNull(paBox.BunHo))
                    {
                        paBox.Focus();
                        return;
                    }
                    if (rbtOtherClinic.Checked)
                    {
                        if (!String.IsNullOrEmpty(fbxLinkHospCode.Text))
                                grdOrderlist.QueryLayout(true);
                    }
                    else
                    {
                    // https://sofiamedix.atlassian.net/browse/MED-7507
                        GetTooltip();
                    }
					break;
			}	
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

        #region paBox_PatientSelected　[患者番号選択]
        private void paBox_PatientSelected(object sender, EventArgs e)
		{
			mBunho = paBox.BunHo;

            //// 呼出されてパラメータがある場合
            //if (this.OpenParam != null)
            //{
            //    // 生理検査(OCS0103U14)、放射線(OCS0103U16)、手術(OCS0103U18)
            //    if (this.mCallerName.Equals("OCS0103U14") || this.mCallerName.Equals("OCS0103U16") || this.mCallerName.Equals("OCS0103U18") || this.mCallerName.Equals("FormIlgwalChange"))
            //    {
            //        if (this.isReserAsPkocs()) this.grdOrderlist.QueryLayout(true);
            //    }
            //}
            //else
            //{
            if (rbtMyClinic.Checked)
            {
                grdOrderlist.QueryLayout(true);
            }
            //}
		}

		private void paBox_PatientSelectionFailed(object sender, EventArgs e)
		{
			mBunho = "";

            grdOrderlist.QueryLayout(true);
		}
		#endregion

        #region [setReserViewer] オーダ画面から渡されたパラメータを設定する。

        private bool isReserAsPkocs()
        {
            bool returnVal = false;

            if (OpenParam.Contains("pkocs"))
            {
                if (!TypeCheck.IsNull(OpenParam["pkocs"].ToString().Trim()))
                {
                    pkocs = OpenParam["pkocs"].ToString().Trim();
                    returnVal = true;
                }
            }
            return returnVal;
        }

        private void setReserViewer()
        {
            string hangmog_code = "";
            string hangmog_name = "";
            string jundal_table = "";
            string jundal_part = "";
            //string gwa_name = this.cboGwa.GetItemText(this.cboGwa.SelectedItem);
            //string doctor_name = this.dbxDoctor_name.GetDataValue();
            string order_date = "";
            string emergency = "";
            string order_remark = "";
            string reser_yn = "N";

            if (OpenParam.Contains("pkocs"))
            {
                if (!TypeCheck.IsNull(OpenParam["pkocs"].ToString().Trim()))
                {
                    pkocs = OpenParam["pkocs"].ToString().Trim();
                }
            }
            if (OpenParam.Contains("hangmog_code"))
            {
                if (!TypeCheck.IsNull(OpenParam["hangmog_code"].ToString().Trim()))
                {
                    hangmog_code = OpenParam["hangmog_code"].ToString().Trim();
                }
            }
            if (OpenParam.Contains("hangmog_name"))
            {
                if (!TypeCheck.IsNull(OpenParam["hangmog_name"].ToString().Trim()))
                {
                    hangmog_name = OpenParam["hangmog_name"].ToString().Trim();
                }
            }
            if (OpenParam.Contains("jundal_table"))
            {
                if (!TypeCheck.IsNull(OpenParam["jundal_table"].ToString().Trim()))
                {
                    jundal_table = OpenParam["jundal_table"].ToString().Trim();
                }
            }
            if (OpenParam.Contains("jundal_part"))
            {
                if (!TypeCheck.IsNull(OpenParam["jundal_part"].ToString().Trim()))
                {
                    jundal_part = OpenParam["jundal_part"].ToString().Trim();
                }
            }
            if (OpenParam.Contains("order_date"))
            {
                if (!TypeCheck.IsNull(OpenParam["order_date"].ToString().Trim()))
                {
                    order_date = OpenParam["order_date"].ToString().Trim();
                }
            }
            if (OpenParam.Contains("emergency"))
            {
                if (!TypeCheck.IsNull(OpenParam["emergency"].ToString().Trim()))
                {
                    emergency = OpenParam["emergency"].ToString().Trim();
                }
            }
            if (OpenParam.Contains("order_remark"))
            {
                if (!TypeCheck.IsNull(OpenParam["order_remark"].ToString().Trim()))
                {
                    order_remark = OpenParam["order_remark"].ToString().Trim();
                }
            }

            string jundal_part_name = GetCodeName("jundal_part_name", jundal_part);

            int rowIndex = grdOrderlist.InsertRow(-1, true);

            grdOrderlist.SetItemValue(rowIndex, "hangmog_code", hangmog_code);
            grdOrderlist.SetItemValue(rowIndex, "hangmog_name", hangmog_name);
            grdOrderlist.SetItemValue(rowIndex, "jundal_table", jundal_table);
            grdOrderlist.SetItemValue(rowIndex, "jundal_part", jundal_part);
            grdOrderlist.SetItemValue(rowIndex, "jundal_part_name", jundal_part_name);
            //this.grdOrderlist.SetItemValue(rowIndex, "gwa_name", gwa_name);
            //this.grdOrderlist.SetItemValue(rowIndex, "doctor_name", doctor_name);
            grdOrderlist.SetItemValue(rowIndex, "order_date", order_date);
            grdOrderlist.SetItemValue(rowIndex, "emergency", emergency);
            grdOrderlist.SetItemValue(rowIndex, "order_remark", order_remark);
            grdOrderlist.SetItemValue(rowIndex, "reser_yn", reser_yn);

            xGridOrderlistRowFocusChanged(-1, 0);
        }
        #endregion

		#region [Control Event ]
		private void cboGwa_SelectedIndexChanged(object sender, EventArgs e)
		{
            //mGwa = cboGwa.SelectedValue.ToString();
            //this.fbxDoctor.SetEditValue("");
            //this.fbxDoctor.AcceptData();
            //this.fbxDoctor.Focus();
            //this.fbxDoctor.SelectAll();
		}

        //private void fbxDoctor_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        //{
        //    if (TypeCheck.IsNull(this.cboGwa.GetDataValue().Trim()))
        //    {
        //        dbxDoctor_name.SetEditValue("");
        //        return;
        //    }
        //    if(TypeCheck.IsNull(e.DataValue.ToString().Trim())) 
        //    {
        //        dbxDoctor_name.SetEditValue("");
        //        return;
        //    }

        //    // 診療医氏名照会
        //    string codeName = this.GetCodeName("doctor_name", e.DataValue.ToString());
 
        //    // 診療医氏名設定
        //    this.dbxDoctor_name.SetEditValue(codeName);
        //}
        #endregion

        #region GetCodeName [コートデータに対してコード名を取得（医師コード：医師コード名）]
        private string GetCodeName(string codeMode, string code)
        {
            string codeName = "";

            if (code.Trim() == "") return codeName;

            switch (codeMode)
            {
                case "doctor_name":

                    string gwa = cboGwa.GetDataValue();

                    if (TypeCheck.IsNull(gwa))
                    {
                        codeName = "XXX";
                        break;
                    }

                    // BAS0270에서 RESER_YN = Y 인 의사만 가능하도록
                    layCommon.Reset();

                    //                    this.layCommon.QuerySQL = @"SELECT A.DOCTOR_NAME   
                    //                                                     , NVL(A.RESER_YN, 'N')    RESER_YN                                       
                    //                                                 FROM BAS0270 A                                                       
                    //                                                WHERE A.HOSP_CODE  = :f_hosp_code
                    //                                                  AND A.DOCTOR     = :f_doctor
                    //                                                  AND A.DOCTOR_GWA = :f_gwa
                    //                                                  --AND NVL(A.RESER_YN, 'N') = 'Y'
                    //                                                  AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE ";
                    List<string> param = new List<string>();
                    param.Add("f_doctor");
                    param.Add("f_gwa");


                    layCommon.ParamList = param;
                    layCommon.ExecuteQuery = LoadDoctor;

                    layCommon.LayoutItems.Clear();
                    layCommon.LayoutItems.Add("doctor_name");
                    layCommon.LayoutItems.Add("reser_yn");

                    layCommon.SetBindVarValue("f_hosp_code", mHospCode);
                    layCommon.SetBindVarValue("f_doctor", code);
                    layCommon.SetBindVarValue("f_gwa", gwa);

                    layCommon.QueryLayout();

                    codeName = "";

                    if (layCommon.GetItemValue("reser_yn").ToString() != "Y")
                    {
                        codeName = "NO_RESER";
                        return codeName;
                    }

                    if (!TypeCheck.IsNull(layCommon.GetItemValue("doctor_name")))
                        codeName = layCommon.GetItemValue("doctor_name").ToString();

                    break;

                default:
                    break;
            }

            return codeName;
        }

        #endregion

		#region 예약자구분 Image Display (DisplayResGubun)
		/// <summary>
		/// 예약자구분 Image Display
		/// </summary>
		/// <param name="aGrd"> XEditGrid </param>
		/// <returns> void  </returns>
		private void DisplayResGubun(XEditGrid aGrd)
		{
			if (aGrd == null) return;

			try
			{
                //for (int i = 0; i < aGrd.RowCount; i++) 
                //    aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;

				for (int i = 0; i < aGrd.RowCount; i++)
				{
                    aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;
                    //aGrd[i, "ipwon_image"].Image = null;

					if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "input_gubun")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
					{
						//의사
						if(aGrd.GetItemString(i, "input_gubun") == "D")
							aGrd[i + aGrd.HeaderHeights.Count, 0].Image = ImageList.Images[3];
						//간호사
						else if(aGrd.GetItemString(i, "input_gubun") == "N")
							aGrd[i + aGrd.HeaderHeights.Count, 0].Image = ImageList.Images[4];
						//기타
                        else if (aGrd.GetItemString(i, "input_gubun") == "E")
							aGrd[i + aGrd.HeaderHeights.Count, 0].Image = ImageList.Images[5];
					}

                    if(!TypeCheck.IsNull(aGrd.GetItemValue(i, "jinryo_irai_yn")))
                    {
                        if (aGrd.GetItemValue(i, "jinryo_irai_yn").ToString() == "Y")
                        {
                            aGrd[i + aGrd.HeaderHeights.Count, 0].Image = ImageList.Images[11];
                        
                        }                    
                    }

                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "ipwon_yn")))
                    {
                        if (aGrd.GetItemValue(i, "ipwon_yn").ToString() == "Y")
                        {
                            //aGrd[i, "ipwon_image"].Image = this.ImageList.Images[12];
                        }

                    }
				}
			}
			catch(Exception xe)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(xe.Data.ToString());
            }
		}

		private void DisplayResGubun(XEditGrid aGrd, int rowIndex)
		{
			if (aGrd == null || rowIndex < 0 ) return;

			try
			{
				aGrd[rowIndex + aGrd.HeaderHeights.Count, 0].Image = null;

				if(TypeCheck.IsNull(aGrd.GetItemString(rowIndex, "input_gubun"))) return;

				//의사
				if(aGrd.GetItemString(rowIndex, "input_gubun") == "D")
					aGrd[rowIndex + aGrd.HeaderHeights.Count, 0].Image = ImageList.Images[3];
				//간호사
				else if(aGrd.GetItemString(rowIndex, "input_gubun") == "N")
					aGrd[rowIndex + aGrd.HeaderHeights.Count, 0].Image = ImageList.Images[4];
				//기타
                else if (aGrd.GetItemString(rowIndex, "input_gubun") == "E")
					aGrd[rowIndex + aGrd.HeaderHeights.Count, 0].Image = ImageList.Images[5];
						
			}
			catch{}
		}
		#endregion


        #region fbxDoctor_FindClick [診療医データセット]
        private void fbxDoctor_FindClick(object sender, CancelEventArgs e)
		{
			CommonItemCollection openParams  = new CommonItemCollection();
			openParams.Add("gwa", cboGwa.GetDataValue().ToString());
			openParams.Add("word", "");
			openParams.Add("all_gubun", "N");
			openParams.Add("query_gubun", "%");
            openParams.Add("hosp_code", (String.IsNullOrEmpty(mHospCodeLink)) ? UserInfo.HospCode : mHospCodeLink);
            if (rbtOtherClinic.Checked)
            {
                //just load doctors who have setting for out-clinic 
                openParams.Add("reser_out_yn", true);
            }
			OpenScreenWithParam(this, "OCSA", "OCS0270Q00", ScreenOpenStyle.ResponseFixed, openParams);
		}
		#endregion

        //# region btnClear_Click [診療医データをクリアする。]
        //private void btnClear_Click(object sender, EventArgs e)
        //{
        //    this.fbxDoctor.Clear();
        //    this.dbxDoctor_name.Text = "";
        //}
        //#endregion

        
        //#region btnReserOrder_Click [予約順番]
        //private void btnReserOrder_Click(object sender, EventArgs e)
        //{
        //    IHIS.Framework.IXScreen aScreen;

        //    string bunho = this.paBox.BunHo;

        //    aScreen = XScreen.FindScreen("SCHS", "SCH0201U10");

        //    if (aScreen == null)
        //    {
        //        CommonItemCollection openParams = new CommonItemCollection();
        //        openParams.Add("bunho", bunho);

        //        XScreen.OpenScreenWithParam(this, "SCHS", "SCH0201U10", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter, openParams);
        //    }
        //    else
        //    {
        //        ((XScreen)aScreen).Activate();
        //    }
        //}
        //#endregion



        /*
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 2012 08 28 by Park.W.J
         * 
         * 
         * 
         * 
         * 
         *     
         *   */


        #region xGridOrderlist_QueryStarting
        private void xGridOrderlist_QueryStarting(object sender, CancelEventArgs e)
        {
            // 患者番号チェック
            if (TypeCheck.IsNull(paBox.BunHo))
                return;

            // QUERY区分フラグ（N:一般、O:OCSから呼出）
            string flag = "N";
            
            if (!pkocs.Equals("")) flag = "O";
            
            grdOrderlist.SetBindVarValue("f_hosp_code", mHospCode);
            grdOrderlist.SetBindVarValue("f_flag", flag);
            grdOrderlist.SetBindVarValue("f_fkocs", pkocs);
            grdOrderlist.SetBindVarValue("f_bunho", paBox.BunHo);
            //this.grdOrderlist.SetBindVarValue("f_gwa", mGwa);
            //this.grdOrderlist.SetBindVarValue("f_doctor", mDoctor);
            grdOrderlist.SetBindVarValue("f_reser_gubun", cboGumsa.GetDataValue());
            grdOrderlist.SetBindVarValue("f_reser_part", cboGumsaPart.GetDataValue());
            grdOrderlist.SetBindVarValue("f_reser_status", cboReserStatus.GetDataValue());
        }
        #endregion

        #region [xGridOrderlist_QueryEnd]
        private void xGridOrderlist_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (grdOrderlist.RowCount < 1)
            {
                calSchedule.Dates.Clear();
                calSchedule.Refresh();
                grdTimeList.Reset();
            }
          
        }
        #endregion

        private List<SCH0201U99ListFkschInfo> _pkschList;
        #region xGridOrderlist_RowFocusChanged [RowFocusChanged イベント処理]
        private void xGridOrderlist_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
           ;
            // 検体検査の場合､オーダGROUP_SERの単位で予約を取る。
            if (grdOrderlist.GetItemString(e.CurrentRow, "jundal_table").Equals("CPL"))
            {
                string groupSer = grdOrderlist.GetItemString(e.CurrentRow, "group_ser");
                string orderDate = grdOrderlist.GetItemString(e.CurrentRow, "order_date");
                string reserDate = grdOrderlist.GetItemString(e.CurrentRow, "reser_date");

                //this.grdPkschList.Reset();
                //_pkschList = new List<string>();
                _pkschList = null;
                 _pkschList = new List<SCH0201U99ListFkschInfo>();
                //int newRow = 0;

                for (int i = 0; i < grdOrderlist.RowCount; i++)
                {
                    if (grdOrderlist.GetItemString(i, "group_ser").Equals(groupSer) &&
                        grdOrderlist.GetItemString(i, "order_date").Equals(orderDate) &&
                        grdOrderlist.GetItemString(i, "reser_date").Equals(reserDate) &&
                        grdOrderlist.GetItemString(i, "jundal_table").Equals("CPL"))
                    {
                        grdOrderlist.SelectRow(i);

                        //this.grdPkschList.InsertRow(newRow);

                        //this.grdPkschList.SetItemValue(newRow, "pksch", this.grdOrderlist.GetItemString(i, "pksch0201"));
                        _pkschList.Add(new SCH0201U99ListFkschInfo(grdOrderlist.GetItemString(i, "pksch0201"))); 
                        //newRow = newRow + 1;
                    }
                }
            }
           
            // カレンダー選定、スケジュール表設定
           xGridOrderlistRowFocusChanged(e.PreviousRow, e.CurrentRow);
        }
        #endregion

        #region [xGridOrderlistRowFocusChanged] カレンダー選定、スケジュール表設定
        private void xGridOrderlistRowFocusChanged(int previousRow, int currentRow)
        {
            // 検査項目の予約時間チェック
            if (grdOrderlist.RowCount < 1 && pkocs.Equals(""))
                return;

            // ”BUTTON”をクリックした時、FOCUSを設定する。（イベント重複を防ぐために）
            if (grdOrderlist.CurrentColName.Equals("button") && !previousRow.ToString().Equals("-1"))
            {
                grdOrderlist.SetFocusToItem(previousRow, "hangmog_name");
                return;
            }

            // 予約ボタンのイメージ、活性化/非活性化を設定
            change_xGridOrderlist_button();

            // 検査予約情報をカレンダーに表示
            SetDateSchSchedule();

            // 予約可否によるCalendarの日付選択
            setCalendarDate();

            xlbJundalPart.Text = grdOrderlist.GetItemString(currentRow, "jundal_part_name");

            // https://sofiamedix.atlassian.net/browse/MED-7507
            if (rbtMyClinic.Checked)
            {
                GetTooltip();
            }
        }
        #endregion

        #region xGridOrderlist_GridButtonClick [予約登録/取消ボタンイベント処理]
        private void xGridOrderlist_GridButtonClick(object sender, GridButtonClickEventArgs e)
        {
            // 入浴、その他は SCH0201から物理削除する。
            string table = grdOrderlist.GetItemString(e.RowNumber, "jundal_table");
            if (table.Equals("BAT") || table.Equals("ETC"))
            {
                deleteSch0201(grdOrderlist.GetItemString(e.RowNumber, "pksch0201"));
                // GRID再照会
                grdOrderlist.QueryLayout(true);
            }
            else goReserAction(e.ColName, e.RowNumber);
        }
        #endregion

        #region xEditGridTimeList_MouseDoubleClick [予約登録イベント処理]
        private void xEditGridTimeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "out_hosp_code") != UserInfo.HospCode) return;
            
            if (e.Button == MouseButtons.Right) return;

            // 患者番号チェック
            if (TypeCheck.IsNull(paBox.BunHo))
                return;

            // 検査項目の予約時間チェック
            if (grdTimeList.RowCount < 1)
                return;

            // 予約可能可否チェック
            if (!reserDateCheck()) return;

            // 既に予約登録されている場合
            if (grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "reser_yn").Equals("Y"))
            {
                if (TypeCheck.IsNull(grdTimeList.GetItemString(grdTimeList.CurrentRowNumber, "pksch0201")))
                {
                    if (XMessageBox.Show(Resources.SCH0201U99_XMessageBox1945, Resources.SCH0201U99_XMessageBox1945_cap, MessageBoxButtons.OKCancel) != DialogResult.OK) return;
                    else
                    {
                        //// 予約時間ダブりチェック
                        //if (reserTimeCheck()) return;

                        // オーダ画面に｢予約日付｣｢予約時間｣を渡す｡
                        if (isRtnReserInfo("mouse")) return;

                        // 予約変更処理
                        //this.goReserUpdAction("U");

                        // 予約変更開始
                        regReserProcess("U");
                    }
                }
                else
                {
                    if (grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "pksch0201").Equals(grdTimeList.GetItemString(grdTimeList.CurrentRowNumber, "pksch0201")))
                    {
                        if (XMessageBox.Show(Resources.SCH0201U99_XMessageBox1965, Resources.SCH0201U99_XMessageBox1965_cap, MessageBoxButtons.OKCancel) != DialogResult.OK) return;
                        else
                            // GRIDの取消ボタンを押した時と同じイベントを起こす。
                            goReserAction("button", grdOrderlist.CurrentRowNumber);
                    }
                }
            }
            else
            {
                // GRIDの取消ボタンを押した時と同じイベントを起こす。
                goReserAction("button", grdOrderlist.CurrentRowNumber);
            }

            // https://sofiamedix.atlassian.net/browse/MED-7507
            if (rbtMyClinic.Checked)
            {
                GetTooltip();
            }
        }
        #endregion

        #region goReserAction [予約変更/取消ボタンイベント処理]
        private void goReserAction(string colName, int rowNum)
        {
            //if (!this.reserDateCheck()) return;

            if (colName == "button")
            {
                if (isRtnReserInfo("button")) return;

                string reserYn = grdOrderlist.GetItemString(rowNum, "reser_yn");

                // [PR_SCH_SCH0201_INSERT]のパラメタ設定
                string i_fksch0201 = grdOrderlist.GetItemString(rowNum, "pksch0201");
                string i_hangmog_code = grdOrderlist.GetItemString(rowNum, "hangmog_code");
                string i_reser_date = mCurrentDate;
                string i_reser_time = grdTimeList.GetItemString(grdTimeList.CurrentRowNumber, "from_time");

                // ｢N｣ → 予約日付が無いと予約登録が出来る｡
                if (reserYn.Equals("N"))
                {
                    // 患者番号チェック
                    if (TypeCheck.IsNull(paBox.BunHo))
                        return;


                    if (!grdOrderlist.GetItemString(rowNum, "jundal_table").Equals("CPL"))
                    {
                        // 検査項目の予約時間チェック
                        if (grdTimeList.RowCount < 1)
                            return;
                    }

                    if (XMessageBox.Show(Resources.SCH0201U99_XMessageBox1945, Resources.SCH0201U99_XMessageBox1945_cap, MessageBoxButtons.OKCancel) != DialogResult.OK) return;
                    else
                    {
                        // 予約変更開始
                        regReserProcess("U");
                    }
                }

                // ｢Y｣ → 予約日付があると予約登録を取消す｡
                if (reserYn.Equals("Y"))
                {
                    if (XMessageBox.Show(Resources.SCH0201U99_XMessageBox1965, Resources.SCH0201U99_XMessageBox1965_cap, MessageBoxButtons.OKCancel) != DialogResult.OK) return;
                    else
                    {
                        // 予約取消開始
                        regReserProcess("D");
                    }
                }
            }
        }
        #endregion

        #region [isRtnReserInfo ] オーダ画面に｢予約日付｣｢予約時間｣を渡すチェック
        private bool isRtnReserInfo(string kindEvent)
        {
            /* １．オーダ登録画面から呼出された場合、予約日付、予約時間を渡す。
             * ２．予約システムからの場合、登録処理を行う。
             */
            if (OpenParam != null)
            {
                // 生理検査(OCS0103U14)、放射線(OCS0103U16)、手術(OCS0103U18)
                if (mCallerName.Equals("OCS0103U14") || mCallerName.Equals("OCS0103U16") || mCallerName.Equals("OCS0103U18") || mCallerName.Equals("FormIlgwalChange"))
                {
                    string i_reser_date = mCurrentDate;
                    string i_reser_time = grdTimeList.GetItemString(grdTimeList.CurrentRowNumber, "from_time");
                    XScreen scrOpener = null;
                    XForm scrForm = null;

                    
                    if (mCallerName.Equals("FormIlgwalChange"))
                        scrForm = (XForm)Opener;
                    else
                        scrOpener = (XScreen)Opener;

                    CommonItemCollection commandParams = new CommonItemCollection();
                    // 予約登録処理の場合
                    if (grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "reser_yn").Equals("N"))
                    {
                        commandParams.Add("reser_date", i_reser_date);
                        commandParams.Add("reser_time", i_reser_time);
                    }
                    else
                    {
                        // オーダ画面からの呼出の場合､マウスダブルクリック時､予約変更処理を行う｡
                        if (kindEvent.Equals("mouse"))
                        {
                            commandParams.Add("reser_date", i_reser_date);
                            commandParams.Add("reser_time", i_reser_time);
                        }
                        else
                        {
                            // オーダ画面からの呼出の場合､ボタンクリック時､予約取消処理を行う｡
                            commandParams.Add("reser_date", "");
                            commandParams.Add("reser_time", "");
                        }
                    }

                    if (mCallerName.Equals("FormIlgwalChange"))
                        scrForm.Command(ScreenID, commandParams);
                    else
                        scrOpener.Command(ScreenID, commandParams);

                    

                    

                    Close();

                    return true;
                }
                else return false;
            }
            else return false;
        }
        #endregion

        #region [goReserUpdAction] 予約変更処理
        //private void goReserUpdAction()
        //{
        //    // [PR_SCH_SCH0201_INSERT]のパラメタ設定
        //    string i_fksch0201 = this.grdOrderlist.GetItemString(this.grdOrderlist.CurrentRowNumber, "pksch0201");
        //    string i_hangmog_code = this.grdOrderlist.GetItemString(this.grdOrderlist.CurrentRowNumber, "hangmog_code");
        //    string i_reser_date = this.mCurrentDate;
        //    string i_reser_time = this.grdTimeList.GetItemString(this.grdTimeList.CurrentRowNumber, "from_time");
        //    string i_seq = "";

        //    // 予約変更開始
        //    this.regReserProcess(i_fksch0201, i_hangmog_code, i_reser_date, i_reser_time, i_seq,"U");
        //}
        #endregion

        #region regReserProcess [予約登録/取消開始]
        private void regReserProcess(string reserIUD)
        {
          
            // 検体検査の場合､オーダGROUP_SERの単位で予約を取る。
            if (grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "jundal_table").Equals("CPL"))
            {
                               
                    string i_reser_date = mCurrentDate;
                    string i_reser_time = grdTimeList.GetItemString(grdTimeList.CurrentRowNumber, "from_time");
                    string jundalPart = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "jundal_part"); ;//jundal_part
                    string jundalTable = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "jundal_table");
                    string out_hospcode = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "out_hosp_code");
                    string aReserDate = reserIUD == "D" ? null : i_reser_date;
                    string aReserTime = reserIUD == "D" ? null : i_reser_time;
                    //string preTime = "";
                    //if (aReserTime != null)
                    //{
                    //     preTime = aReserTime.Insert(2,":") + ":00";
                    //}
                    string nameKanji = paBox.SuName2;
                    string nameKana = paBox.SuName;
                    if (rbtOtherClinic.Checked && reserIUD != "D")
                    {
                        //string msgOutput = "";                        
                        if (!CheckBeforeInsert(aReserDate, aReserTime)) return;                        
                        //if (AccType != "00")
                        //{
                        InsertBookingLabs(_pkschList, aReserDate, aReserTime, nameKanji, nameKana);
                        #region Comment by MED-8095

                        // AnhNV moved from InsertBookingLabs
                        //grdOrderlist.RowFocusChanged -= xGridOrderlist_RowFocusChanged;
                        //this.setFocusProcess(p_fksch0201);
                        //}
                        //else
                        //{
                        //    try
                        //    {
                        //        ORCA.BookingInfo bk = new ORCA.BookingInfo(mBunhoLink, paBox.SuName, paBox.SuName2,
                        //                       this.calSchedule.SelectedDays[0].Date.ToString("yyyy-MM-dd"), preTime, "", IfCodeGwa,
                        //                       IfCodeDoctor, IfCodeGwa, "01", "");

                        //        ORCA.ORCAServices sentBk = new ORCA.ORCAServices(bk);
                        //        sentBk.SentBooking(out msgOutput, OrcaIp, OrcaUser, OrcaPassword);
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        Service.WriteLog("Error : " + ex);
                        //    }
                        //    if (msgOutput.Substring(0, 2) == "00")
                        //    {
                        //        InsertBookingLabs(_pkschList, aReserDate, aReserTime);

                        //        // AnhNV moved from InsertBookingLabs
                        //        //grdOrderlist.RowFocusChanged -= xGridOrderlist_RowFocusChanged;
                        //        //this.setFocusProcess(_pkschList[0].Fkshc);
                        //    }
                        //    else
                        //    {
                        //        XMessageBox.Show(msgOutput.Remove(0,2),Resources.MSGTitleError,MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    }

                        //} 
                        #endregion
                    }
                    else
                    {
                        // https://sofiamedix.atlassian.net/browse/MED-7896
                        //SchsSCH0201U99ExecIUDResult execIudResult = ExecutePrSchSCH0201Iud(reserIUD, i_fksch0201, aReserDate, null, UserInfo.UserID, jundalTable, jundalPart);
                        SchsSCH0201U99ExecIUDResult execIudResult = ExecutePrSchSCH0201Iud(reserIUD, _pkschList, aReserDate, aReserTime, UserInfo.UserID, jundalTable, jundalPart, out_hospcode);

                        if (execIudResult == null || execIudResult.ExecutionStatus != ExecutionStatus.Success)
                        {
                            throw new Exception(Resources.Error_execute_PR_SCH_SCH0201_IUD);
                        }
                        else
                        {
                            if (!TypeCheck.IsNull(execIudResult.IoErr))
                            {
                                //Check Validate
                                if (execIudResult.IoErr.Equals("1"))
                                {
                                    XMessageBox.Show(Resources.MSGVal007 + calSchedule.SelectedDays[0].Date.ToString("yyyy/MM/dd"), "Error", MessageBoxIcon.Error);
                                    return;
                                }
                                // [PR_SCH_SCH0201_INSERT]のリターン値チェック
                                if (execIudResult.IoErr.Equals("X"))
                                {
                                    XMessageBox.Show(execIudResult.IoErr, "PR_SCH_SCH0201_IUD", MessageBoxIcon.Error);
                                    return;
                                }

                                if (execIudResult.IoErr.Equals("0"))
                                {  
                                    //success
                                    grdOrderlist.QueryLayout(false);
                                    this.setFocusProcess(_pkschList[0].Fkshc);
                                }
                            }
                        }
                        // End connect to cloud
                    }

                    // GRID再照会
                
                  
                
                }
            else
            {
                _pkschList = null;
                _pkschList = new List<SCH0201U99ListFkschInfo>();
                string i_fksch0201 = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "pksch0201");
                _pkschList.Add(new SCH0201U99ListFkschInfo(i_fksch0201));

                string i_reser_date = mCurrentDate;
                string i_reser_time = grdTimeList.GetItemString(grdTimeList.CurrentRowNumber, "from_time");
                string jundalPart = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "jundal_part"); ;//jundal_part
                string jundalTable = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "jundal_table");
                string out_hospcode = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "out_hosp_code");
                // Start Connect to cloud 
                string aReserDate = reserIUD == "D" ? null : i_reser_date;
                string aReserTime = reserIUD == "D" ? null : i_reser_time;
                string nameKanji = paBox.SuName2;
                string nameKana = paBox.SuName;
                //Check before insert SCH0201 other clinic
                if (rbtOtherClinic.Checked && reserIUD != "D")
                {
                    //string preTime = aReserTime.Insert(2, ":") + ":00";
                    //string msgOutput = "";
                    if (!CheckBeforeInsert(aReserDate, aReserTime)) return;
                    //if (AccType != "00")
                    //{
                        InsertBookingLabs(_pkschList, aReserDate, aReserTime,nameKanji,nameKana);
                        #region Comment by MED-8095
                        //}
                        //else
                        //{
                        //    try
                        //    {
                        //        ORCA.BookingInfo bk = new ORCA.BookingInfo(mBunhoLink, paBox.SuName, paBox.SuName2,
                        //                       this.calSchedule.SelectedDays[0].Date.ToString("yyyy-MM-dd"), preTime, "", IfCodeGwa,
                        //                       IfCodeDoctor, IfCodeGwa, "01", "");

                        //        ORCA.ORCAServices sentBk = new ORCA.ORCAServices(bk);
                        //        sentBk.SentBooking(out msgOutput, OrcaIp, OrcaUser, OrcaPassword);
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        Service.WriteLog("Error : " + ex);
                        //    }
                        //    if (msgOutput.Substring(0, 2) == "00")
                        //    {
                        //        InsertBookingLabs(_pkschList, aReserDate, aReserTime);
                        //    }
                        //    else
                        //    {
                        //        XMessageBox.Show(msgOutput.Remove(0, 2), Resources.MSGTitleError, MessageBoxIcon.Error);
                        //    }

                        //} 
                        #endregion
                }

                else
                {

                    SchsSCH0201U99ExecIUDResult execIudResult = ExecutePrSchSCH0201Iud(reserIUD, _pkschList, aReserDate, aReserTime, UserInfo.UserID, jundalTable, jundalPart, out_hospcode);

                    if (execIudResult == null || execIudResult.ExecutionStatus != ExecutionStatus.Success)
                    {
                        throw new Exception(Resources.Error_execute_PR_SCH_SCH0201_IUD);
                    }
                    else
                    {
                        if (!TypeCheck.IsNull(execIudResult.IoErr))
                        {
                            //Check Validate
                            if (execIudResult.IoErr.Equals("1"))
                            {
                                XMessageBox.Show(Resources.MSGVal007 + calSchedule.SelectedDays[0].Date.ToString("yyyy/MM/dd"), Resources.MSGTitleError, MessageBoxIcon.Error);
                            }
                            // [PR_SCH_SCH0201_INSERT]のリターン値チェック
                            if (execIudResult.IoErr.Equals("X"))
                            {
                                XMessageBox.Show(execIudResult.IoErr, "PR_SCH_SCH0201_IUD", MessageBoxIcon.Error);
                            }

                            if (execIudResult.IoErr.Equals("0"))
                            {
                                //success
                                grdOrderlist.QueryLayout(false);
                                this.setFocusProcess(_pkschList[0].Fkshc);
                            }
                        }
                    }
                }
            }

            // https://sofiamedix.atlassian.net/browse/MED-15246
            //grdTimeList.QueryLayout(false);
            grdTimeList.QueryLayout(true);

            calSchedule.ResumeLayout();
            calSchedule.Refresh();
            this.setFocusProcess(_pkschList[0].Fkshc);
        }
        #endregion

        #region setFocusProcess [予約/取消した後、FOCUS設定]
        private void setFocusProcess(string fksch0201)
        {
            int rowIndex = grdOrderlist.RowCount;

            string fksch = "";

            for (int i = 0; i < rowIndex; i++)
            {
                fksch = grdOrderlist.GetItemString(i, "pksch0201");

                if (fksch.Equals(fksch0201))
                {
                    grdOrderlist.SetFocusToItem(i, "hangmog_name");
                    return;
                }
            }
        }
        #endregion

        #region reserDateCheck [予約可能可否チェック]
        private bool reserDateCheck()
        {
            bool returnVal = true;

            string calDay = "";
            string isReserYn = "";

            // 選択日付の予約可否チェック
            for (int i = 0; i < layDateSchedule.RowCount; i++)
            {
                calDay = layDateSchedule.GetItemString(i, "dayofmon").Substring(0, 10);
                if (calDay.Equals(mCurrentDate))
                {
                    isReserYn = layDateSchedule.GetItemString(i, "check_yn");
                }
            }

            //// 予約登録処理の場合
            //if (this.grdOrderlist.GetItemString(this.grdOrderlist.CurrentRowNumber, "reser_yn").Equals("N"))
            //{
                if (isReserYn.Equals("N"))
                {
                    XMessageBox.Show(Resources.SCH0201U99_XMessageBox2277, Resources.SCH0201U99_XMessageBox2277_cap, MessageBoxIcon.Information);
                    returnVal = false;
                }

                string pksch0201 = grdTimeList.GetItemString(grdTimeList.CurrentRowNumber, "pksch0201");
                if (pksch0201.Trim() != "")
                {
                    XMessageBox.Show(Resources.SCH0201U99_XMessageBox2284, Resources.SCH0201U99_XMessageBox2284_cap, MessageBoxIcon.Information);
                    returnVal = false;
                }

                // 予約時間ダブりチェック
                if (reserTimeCheck()) returnVal = false;
            //}

            return returnVal;
        }
        #endregion

        #region reserTimeCheck [予約時間ダブりチェック]
        private bool reserTimeCheck()
        {
            layReserTimeChk.ParamList = new List<string>(new String[] { "f_bunho", "f_reser_date", "f_reser_time", "f_pksch0201"}); 
            layReserTimeChk.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layReserTimeChk.SetBindVarValue("f_bunho", paBox.BunHo);
            layReserTimeChk.SetBindVarValue("f_reser_date", mCurrentDate);
            layReserTimeChk.SetBindVarValue("f_reser_time", grdTimeList.GetItemString(grdTimeList.CurrentRowNumber, "from_time"));
            layReserTimeChk.SetBindVarValue("f_pksch0201", grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "pksch0201"));
            layReserTimeChk.ExecuteQuery = layReserTimeChk_ExecuteQuery;

            if (layReserTimeChk.QueryLayout())
            {
                if (layReserTimeChk.GetItemValue("reser_chk").ToString() == "Y")
                {
                    string msg = Resources.SCH0201U99_msg1 + "\n\r" + Resources.SCH0201U99_msg2;
                    if (XMessageBox.Show(msg, Resources.SCH0201U99_XMessageBox2311_c, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        return false;
                    else
                        return true;
                }
            }
            return false;
        }
        #endregion

        #region xEditGridTimeList_QueryStarting [ 検査項目による予約可能な日付と時間をLOAD ]
        private void xEditGridTimeList_QueryStarting(object sender, CancelEventArgs e)
        {
             grdTimeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdTimeList.SetBindVarValue("f_ip_addr", Service.ClientIP);

            string ip_address = Service.ClientIP;
            string jundal_table = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "jundal_table");
            string jundal_part = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "jundal_part");
            string hangmog_code = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "hangmog_code");
            string selectedDate = mCurrentDate;
            
//            if (!Service.ExecuteProcedure("PR_SCH_TIME_LIST", ip_address, jundal_table, jundal_part, hangmog_code, selectedDate))
//            {
//                XMessageBox.Show(Service.ErrFullMsg);
//                return;
//            }

            // Connect to cloud service
            SchsSCH0201U99ExecTimeListArgs execTimeListArgs = new SchsSCH0201U99ExecTimeListArgs();
            execTimeListArgs.IIpAddress = Service.ClientIP;
            execTimeListArgs.IJundalTable = jundal_table;
            execTimeListArgs.IJundalPart = jundal_part;
            execTimeListArgs.IGumsaja = hangmog_code;
            execTimeListArgs.IReserDate = selectedDate;
            if (rbtOtherClinic.Checked)
            {
                execTimeListArgs.HospCodeLink = fbxLinkHospCode.GetDataValue();
            }
            else
            {
                execTimeListArgs.HospCodeLink = "";
            }
            SchsSCH0201U99StoreProcedureResult result =
                CloudService.Instance.Submit<SchsSCH0201U99StoreProcedureResult, SchsSCH0201U99ExecTimeListArgs>(
                    execTimeListArgs);
            if (result == null && result.ExecutionStatus != ExecutionStatus.Success)
            {
                XMessageBox.Show(Resources.Error_Execute_PR_SCH_TIME_LIST,Resources.MSGTitleError,MessageBoxIcon.Error);
                return;
            }
            // End connect to cloud
        }
        #endregion

        #region calSchedule_DayClick [カレンダーの日付クリックイベント]
        private void calSchedule_DayClick(object sender, XCalendarDayClickEventArgs e)
        {
            // 予約時間検索
            //this.grdTimeList.QueryLayout(true);
        }
        #endregion

        #region calSchedule_DaySelected [カレンダーの日付選択イベント]
        private void calSchedule_DaySelected(object sender, XCalendarDaySelectedEventArgs e)
        {
            mCurrentDate = e.DateItems[0].Date.ToString().Substring(0, 10);

            // 予約時間検索
            grdTimeList.QueryLayout(true);

            xlbSelectedDate.Text = mCurrentDate;

            // https://sofiamedix.atlassian.net/browse/MED-7507
            if (rbtMyClinic.Checked)
            {
                GetTooltip();
            }
        }
        #endregion

        #region calSchedule_MonthChanged
        private void calSchedule_MonthChanged(object sender, XCalendarMonthChangedEventArgs e)
        {
            SetDateSchSchedule();

            grdTimeList.QueryLayout(true);
        }
        #endregion

        #region layDateSchedule_QueryStarting
        private void layDateSchedule_QueryStarting(object sender, CancelEventArgs e)
        {
            string f_jundal_table = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "jundal_table");
            string f_jundal_part = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "jundal_part");
            string f_hangmog_code = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "hangmog_code");

            // 現在表示月の最初日取得
            string startDate = calSchedule.DisplayStartDate.ToString("yyyy/MM/dd").Replace("-","/");
            //string endDate = calSchedule.DisplayEndDate.ToShortDateString();
            layDateSchedule.ParamList = new List<string>(new String[] { "f_jundal_table", "f_jundal_part", "f_hangmog_code", "f_start_date" });
            layDateSchedule.SetBindVarValue("f_jundal_table", f_jundal_table);
            layDateSchedule.SetBindVarValue("f_jundal_part", f_jundal_part);
            layDateSchedule.SetBindVarValue("f_hangmog_code", f_hangmog_code);
            layDateSchedule.SetBindVarValue("f_start_date", startDate);
            layDateSchedule.ExecuteQuery = layDateSchedule_ExecuteQuery;
        }
        #endregion

        #region SetDateSchSchedule [ 検査予約情報をカレンダーに表示 ]
        private void SetDateSchSchedule()
        {
            calSchedule.SuspendLayout();
            calSchedule.Dates.Clear();

            layDateSchedule.Reset();

            string f_jundal_table = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "jundal_table");
            string f_jundal_part = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "jundal_part");
            string f_hangmog_code = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "hangmog_code");

            // 現在表示月の最初日取得
            string startDate = calSchedule.DisplayStartDate.ToString("yyyy/MM/dd").Replace("-","/");
            //string endDate = calSchedule.DisplayEndDate.ToShortDateString();

            layDateSchedule.SetBindVarValue("f_jundal_table", f_jundal_table);
            layDateSchedule.SetBindVarValue("f_jundal_part", f_jundal_part);
            layDateSchedule.SetBindVarValue("f_hangmog_code", f_hangmog_code);
            layDateSchedule.SetBindVarValue("f_start_date", startDate);


            // 予約可能日付検索
            if (layDateSchedule.QueryLayout(true))
            {
                // カレンダーの日別情報を再設定
                XCalendarDate dateItem;

                foreach (DataRow row in layDateSchedule.LayoutTable.Rows)
                {
                    dateItem = new XCalendarDate(DateTime.Parse(row["dayofmon"].ToString()));
                    dateItem.Tag = row["check_yn"].ToString();
                    dateItem.ContentText = row["inwon"].ToString() + "\r\n" + row["outwon"].ToString();
                    dateItem.ContentMultiLine = true;
                    dateItem.ContentTextColorMultiLine = XColor.UpdatedForeColor;
                    

                    switch (row["check_yn"].ToString())
                    {
                        case "Y":
                            dateItem.ImageIndex = 15; // 予約可能アイコン
                            break;

                        case "N":
                            dateItem.ImageIndex = 2; // 予約不可アイコン
                            dateItem.BackColor = new XColor(Color.LightGray); // カレンダー日付のBackGroundColor
                            break;

                        default:
                            break;
                    }

                    calSchedule.Dates.Add(dateItem);
                }

                calSchedule.ResumeLayout();
                calSchedule.Refresh();
            }
            else
            {
                XMessageBox.Show(Resources.SCH0201U99_XMessageBox2445, Resources.SCH0201U99_XMessageBox2445_c, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region setCalendarDate [検査予約情報をカレンダーに表示]
        private void setCalendarDate()
        {
            // 予約されている検査はカレンダーに予約日を選択させる。
            if (grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "reser_yn").Equals("Y"))
            {
                string strDate = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "reser_date");

                // 予約年、月にセット
                calSchedule.SetActiveMonth(int.Parse(strDate.Substring(0, 4)), int.Parse(strDate.Substring(5, 2)));

                // 予約日付にセット
                calSchedule.DaySelected -= calSchedule_DaySelected;
                calSchedule.SelectDate(Convert.ToDateTime(strDate));
                calSchedule.DaySelected += calSchedule_DaySelected;

                // 選択された日付をセットする。
                mCurrentDate = strDate;
            }


            // 予約されてない検査は現在日付を選択させる。
            if (grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "reser_yn").Equals("N"))
            {
                // 現在年、月にセット
                calSchedule.SetActiveMonth(int.Parse(EnvironInfo.GetSysDate().ToString("yyyy")), int.Parse(EnvironInfo.GetSysDate().ToString("MM")));

                // 現在日付にセット
                calSchedule.DaySelected -= calSchedule_DaySelected;
                calSchedule.SelectDate(EnvironInfo.GetSysDate());
                calSchedule.DaySelected += calSchedule_DaySelected;

                // 選択された日付をセットする。
                mCurrentDate = EnvironInfo.GetSysDate().ToString().Substring(0,10);
            }

            // 予約時間検索
            grdTimeList.QueryLayout(true);

            xlbSelectedDate.Text = mCurrentDate;
        }
        #endregion

        #region change_xGridOrderlist_button [予約ボタンのイメージ、活性化/非活性化を設定]
        private void change_xGridOrderlist_button()
        {
            int rowIndex = grdOrderlist.RowCount;

            for (int i = 0; i < rowIndex; i++)
            {
                // 予約日付ｶﾞあると予約出来ない｡
                if (grdOrderlist.GetItemString(i, "reser_yn").Trim().Equals("Y"))
                {
                    grdOrderlist.ChangeButtonImage("button", i, grdOrderlist.ImageList.Images[0]);
                }
                else
                {
                    grdOrderlist.ChangeButtonImage("button", i, grdOrderlist.ImageList.Images[15]);
                }
                // 非活性化
                grdOrderlist.ChangeButtonEnable("button", i, false);
            }

            // リハビリの場合、照会のみ出来る。予約や取消の登録は部門システムで行う。
            if (grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "jundal_table") != "PHY")
            {
                // 活性化
                grdOrderlist.ChangeButtonEnable("button", grdOrderlist.CurrentRowNumber, true);
            }
        }
        #endregion

        #region [btnReserScript_Click 검사(진료)예약표화면 열기]
        private void btnReserScript_Click(object sender, EventArgs e)
        {
            if (grdOrderlist.RowCount < 1) return;
            else
            {
                if (grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "reser_date").Equals(""))
                {
                    XMessageBox.Show(Resources.SCH0201U99_XMessageBox2531, Resources.SCH0201U99_XMessageBox2531_c, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (rbtOtherClinic.Checked)
                    {
                        PrintOrder();
                    }
                    else
                    {
                        CommonItemCollection openParams = new CommonItemCollection();

                        openParams.Add("bunho", paBox.BunHo); //mBunhoLink
                        openParams.Add("auto_close", "Y");
                        openParams.Add("reser_date", grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "reser_date"));
                        //openParams.Add("jundal_table", this.grdOrderlist.GetItemString(this.grdOrderlist.CurrentRowNumber, "jundal_table"));
                        //openParams.Add("jundal_part", this.grdOrderlist.GetItemString(this.grdOrderlist.CurrentRowNumber, "jundal_part"));

                        OpenScreenWithParam(this, "NURO", "NUR1001R98", ScreenOpenStyle.ResponseFixed, openParams);
                    }
                }
            }
        }

        private void PrintOrder()
        {
            GetDataTables();
            DataSet ds = new DataSet();
            string barcode = paBox.BunHo;
            XtraReportBooking rpt = new XtraReportBooking(barcode);
            ds.Tables.Add(tbl_ClinicInfo);
            ds.Tables.Add(tbl_ListBooking);
            rpt.DataSource = ds;
            rpt.DataMember = "tblClinicInfo";
            rpt.Print();
        }

        private void GetDataTables()
        {
            tbl_ClinicInfo = new DataTable("tblClinicInfo");
            tbl_ListBooking = new DataTable("tblListBooking");
            try
            {
                SCH0201U99GetListBookingArgs args = new SCH0201U99GetListBookingArgs();
                args.BunhoLink = mBunhoLink;
                args.HospCodeLink = fbxLinkHospCode.GetDataValue();
                args.HangmogCode = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "hangmog_code");
                args.ReserDate = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "reser_date");
                args.ReserTime = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "reser_time");
                SCH0201U99GetListBookingResult result = CloudService.Instance
                    .Submit<SCH0201U99GetListBookingResult, SCH0201U99GetListBookingArgs>(args);
                if (result != null)
               {
                tbl_ClinicInfo.Columns.Add("yoyang_name_link");
                tbl_ClinicInfo.Columns.Add("suname");
                tbl_ClinicInfo.Columns.Add("birth_day");
                tbl_ClinicInfo.Columns.Add("birth_month");
                tbl_ClinicInfo.Columns.Add("birth_year");
                tbl_ClinicInfo.Columns.Add("gwa_name");
                tbl_ClinicInfo.Columns.Add("age");
                tbl_ClinicInfo.Columns.Add("yoyang_name");
                tbl_ClinicInfo.Columns.Add("doctor_name");
                tbl_ClinicInfo.Columns.Add("bunho");
                tbl_ClinicInfo.Columns.Add("reser_date_day");
                tbl_ClinicInfo.Columns.Add("reser_date_month");
                tbl_ClinicInfo.Columns.Add("reser_date_year");
                tbl_ClinicInfo.Columns.Add("bunho_link");
                tbl_ClinicInfo.Columns.Add("address_link");
                tbl_ClinicInfo.Columns.Add("tel_link");
                string yoyangNameLink = result.YoyangNameLink;
                string suname = result.Suname;
                string birthDay = "";
                string birthMonth = "";
                string birthYear = "";
                String fullBirth = result.Birth;
                if (fullBirth != "")
                {
                    String[] BirthArray = fullBirth.Split('/');
                    birthYear = BirthArray[0];
                    birthMonth = BirthArray[1];
                    birthDay = BirthArray[2];
                }
                string gwaName = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "gwa_name");
                string age = result.Age;
                string yoyangName = UserInfo.HospName;
                string doctorName = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "doctor_name");
                string bunho = result.Bunho;
                string reserDateDay = "";
                string reserDateMonth = "";
                string reserDateYear = "";
                string bunhoLink = mBunhoLink;
                string addressLink = result.AddressLink;
                string telLink = result.TelLink;
                String fullReserDate = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "reser_date");
                if (fullReserDate != "")
                {
                    String[] ReserDateArray = fullReserDate.Split('/');
                    reserDateYear = ReserDateArray[0];
                    reserDateMonth = ReserDateArray[1];
                    reserDateDay = ReserDateArray[2];
                }

                tbl_ClinicInfo.Rows.Add(yoyangNameLink, suname, birthDay, birthMonth, birthYear, gwaName, age, yoyangName, doctorName, bunho, reserDateDay, reserDateMonth, reserDateYear, bunhoLink, addressLink, telLink);
                GetDataTableType(tbl_ListBooking, result.BookingList);
                }

            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message, Resources.Cap_01, MessageBoxIcon.Error);
            }
          
        }

        private void GetDataTableType(DataTable dtName, List<SCH0201U99BookingInfo> currentDataType)
        {
            dtName.Columns.Add("hangmong_name");
            dtName.Columns.Add("reser_time");
            dtName.Columns.Add("move_comment");

            if (currentDataType != null)
            {
                foreach (SCH0201U99BookingInfo item in currentDataType)
                {
                    string orderName = item.HangmogName;
                    string orderTime = item.ReserTime.Substring(0, 2) + ":" + item.ReserTime.Substring(2, 2);
                    string orderMoveComment = item.MoveComment;

                    dtName.Rows.Add(orderName, orderTime, orderMoveComment);
                }
            }
        }
        #endregion

        #region [btnComment_Click コメント内容設定]
        private void btnComment_Click(object sender, EventArgs e)
        {
            if (paBox.BunHo == "")
                return;


            string bunho = paBox.BunHo;
            string reser_date = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "reser_date");

            if (reser_date == "")
            {
                XMessageBox.Show(Resources.SCH0201U99_XMessageBox2562, Resources.SCH0201U99_XMessageBox2562_c, MessageBoxIcon.Warning);
                return;
            }

			#region gwa
            string gwa = "%";

            //layLoginGwa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //layLoginGwa.SetBindVarValue("f_user_id", UserInfo.UserID);

            //if (layLoginGwa.QueryLayout())
            //    gwa = layLoginGwa.GetItemValue("gwa").ToString();
            //else
            //    gwa = UserInfo.Gwa;

            //if (gwa == "")
            //    gwa = "%";

            //if (IHIS.Framework.EnvironInfo.CurrSystemID == "HPCS")	gwa = "HC";					
            //if (IHIS.Framework.EnvironInfo.CurrSystemID == "AKUS")	gwa = "08";			
            //if (gwa == "OUT")	gwa = "01";
			#endregion

			FINDCmt dlg = new FINDCmt(bunho, reser_date, gwa);
		    
			dlg.ShowDialog();
        }
        #endregion

        #region [예약정보 의사회계로 전송]
        public bool Send_IF(XEditGrid grd, int rowIndex, string proc_gubun)
        {
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            /*
                I_HOSP_CODE         IN          VARCHAR2
              , I_PKOUT1001         IN          VARCHAR2
              , I_PROC_GUBUN        IN          VARCHAR2
              , I_YOYAKU_GUBUN      IN          VARCHAR2
              , I_IO_GUBUN          IN          VARCHAR2
              , I_USER_ID           IN          VARCHAR2
              , I_BUNHO             IN          VARCHAR2
              , I_GWA               IN          VARCHAR2
              , I_DOCTOR            IN          VARCHAR2
              , I_NAEWON_DATE       IN          VARCHAR2             
              , I_JUBSU_TIME        IN          VARCHAR2
            */

            inputList.Add(EnvironInfo.HospCode);
            inputList.Add(grd.GetItemString(rowIndex, "pkout1001"));
            inputList.Add(proc_gubun);
            inputList.Add("1");
            inputList.Add("O");
            inputList.Add(UserInfo.UserID);
            inputList.Add(paBox.BunHo);
            inputList.Add(grd.GetItemString(rowIndex, "gwa"));
            inputList.Add(grd.GetItemString(rowIndex, "doctor"));
            inputList.Add(grd.GetItemDateTime(rowIndex, "reser_date").ToString("yyyyMMdd"));
            inputList.Add(grd.GetItemString(rowIndex, "reser_time"));


            if (!Service.ExecuteProcedure("PR_IFS_MAKE_YOYAKU", inputList, outputList))
            {
                XMessageBox.Show("IFS1002 Make error" + Service.ErrFullMsg);
                return false;
            }

            if (TypeCheck.IsNull(outputList[0]))
            {
                return false;
            }

            else
            {
                tcpHelper tcpSender = new tcpHelper();
                string msgText = "";

                msgText = "10111" + outputList[0].ToString();

                int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
                if (ret == -1)
                {
                    XMessageBox.Show("Reser data Send Error：" + msgText);
                    return false;
                }
                return true;
            }
        }
        #endregion

        #region 환자리스트 그리드 확장/축소
        private void btnExpand_Click(object sender, EventArgs e)
        {
            string tipText = "";
            if (grdTimeList.CellInfos["bunho"].CellWidth > 1)
            {
                grdTimeList.CellInfos["bunho"].CellWidth = 1;
                grdTimeList.AutoSizeColumn(3, 1);
                btnExpand.ImageIndex = 16;
                tipText = Resources.SCH0201U99_tipText2662;
                toolTip.SetToolTip((Control)sender, tipText);
                grdTimeList.Refresh();
            }
            else
            {
                grdTimeList.CellInfos["bunho"].CellWidth = 80;
                grdTimeList.AutoSizeColumn(3, 80);
                btnExpand.ImageIndex = 17;
                tipText =Resources.SCH0201U99_tiptext2676;
                toolTip.SetToolTip((Control)sender, tipText);
                grdTimeList.Refresh();
            }
        }
        #endregion

        #region [cboGumsa_SelectedIndexChanged 検査区分選択]
        private void cboGumsa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeCheck.IsNull(paBox.BunHo)) return;

            cboGumsaPart.ResetData();

//            if (this.cboGumsa.GetDataValue().Equals("%"))
//            {
//                this.cboGumsaPart.UserSQL = @"SELECT '%'    CODE
//                                                   , '全体' CODE_NAME
//                                                FROM DUAL";
//            }
//            else
//            {
//                this.cboGumsaPart.UserSQL = @"SELECT '%'    CODE
//                                                   , '全体' CODE_NAME
//                                                FROM DUAL
//                                               UNION ALL
//                                              SELECT A.JUNDAL_PART       CODE
//                                                   , A.JUNDAL_PART_NAME  CODE_NAME
//                                                FROM SCH0001 A
//                                               WHERE A.HOSP_CODE    = 'K01'
//                                                 AND A.JUNDAL_TABLE LIKE '" + this.cboGumsa.GetDataValue() + @"'
//                                            ORDER BY CODE";
//            }

            cboGumsaPart.ParamList = new List<string>(new String[] { "cboGumsa_value" });
            cboGumsaPart.SetBindVarValue("cboGumsa_value", cboGumsa.GetDataValue());

            cboGumsaPart.SetDictDDLB();

            // 検査PART Default選択
            cboGumsaPart.SetEditValue("%");

            if(rbtOtherClinic.Checked)
            { 
                if(!String.IsNullOrEmpty(fbxLinkHospCode.Text))
                    grdOrderlist.QueryLayout(true);
            }
            else
                grdOrderlist.QueryLayout(true);



            // https://sofiamedix.atlassian.net/browse/MED-7507
            if (rbtMyClinic.Checked)
            {
                GetTooltip();
            }
        }
        #endregion

        #region [cboGumsa_SelectedIndexChanged 検査区分選択]
        private void cboGumsaPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeCheck.IsNull(paBox.BunHo)) return;

            if (rbtOtherClinic.Checked)
            {
                if (!String.IsNullOrEmpty(fbxLinkHospCode.Text))
                    grdOrderlist.QueryLayout(true);
            }
            else
                grdOrderlist.QueryLayout(true);

            // https://sofiamedix.atlassian.net/browse/MED-7507
            if (rbtMyClinic.Checked)
            {
                GetTooltip();
            }
        }
        #endregion

        #region [cboReserStatus_SelectedIndexChanged 検査状況選択]
        private void cboReserStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeCheck.IsNull(paBox.BunHo)) return;

            if (rbtOtherClinic.Checked)
            {
                if (!String.IsNullOrEmpty(fbxLinkHospCode.Text))
                    grdOrderlist.QueryLayout(true);
            }
            else
                grdOrderlist.QueryLayout(true);

            // https://sofiamedix.atlassian.net/browse/MED-7507
            if (rbtMyClinic.Checked)
            {
                GetTooltip();
            }
        }
        #endregion

        #region [患者入浴/その他　日程登録 PROC]
        private void btnInsertSch_Click(object sender, EventArgs e)
        {   
            string table = cboGumsa.GetDataValue();
            string part = cboGumsaPart.GetDataValue();

            if (table.Equals("BAT") || table.Equals("ETC"))
            {
                if (table.Equals("%"))
                {
                    XMessageBox.Show(Resources.SCH0201U99_XMessageBox2742, Resources.SCH0201U99_XMessageBox2742_c, MessageBoxIcon.Warning);
                    return;
                }

                if (part.Equals("%"))
                {
                    XMessageBox.Show(Resources.SCH0201U99_XMessageBox2748, Resources.SCH0201U99_XMessageBox2748_c, MessageBoxIcon.Warning);
                    return;
                }

                // 項目コード取得
                string hangmog_code = getHangmogCode(part);
                if (hangmog_code.Equals("E"))
                {
                    XMessageBox.Show(Resources.SCH0201U99_XMessageBox2756, Resources.SCH0201U99_XMessageBox2756_c, MessageBoxIcon.Warning);
                    return;
                }

                Hashtable inputList = new Hashtable();
                Hashtable outputList = new Hashtable();

                inputList.Clear();
                outputList.Clear();

                inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
                inputList.Add("I_BUNHO", paBox.BunHo);
                inputList.Add("I_JUNDAL_TABLE", table);
                inputList.Add("I_JUNDAL_PART", part);
                inputList.Add("I_HANGMOG_CODE", hangmog_code);
                inputList.Add("I_USER_ID", UserInfo.UserID);

                // Connect to cloud service
                SchsSCH0201U99ExecEtcInsertArgs execEtcInsertArgs = new SchsSCH0201U99ExecEtcInsertArgs();
                execEtcInsertArgs.IBunho = paBox.BunHo;
                execEtcInsertArgs.IJundalTable = table;
                execEtcInsertArgs.IJundalPart = part;
                execEtcInsertArgs.IHangmogCode = hangmog_code;
                execEtcInsertArgs.IUserId = UserInfo.UserID;
                SchsSCH0201U99StoreProcedureResult result =
                    CloudService.Instance.Submit<SchsSCH0201U99StoreProcedureResult, SchsSCH0201U99ExecEtcInsertArgs>(
                        execEtcInsertArgs);

//                if (!Service.ExecuteProcedure("PR_SCH_SCH0201_ETC_INSERT", inputList, outputList))
//                {
//                    Service.RollbackTransaction();
//                    XMessageBox.Show(Service.ErrFullMsg);
//                    return;
//                }
                if (result == null || result.ExecutionStatus != ExecutionStatus.Success)
                {
                    XMessageBox.Show(Resources.Error_Execute_PR_SCH_SCH0201_ETC_INSERT);
                    return;
                }
                else grdOrderlist.QueryLayout(true);
                // End Connect to cloud
            }
            else
            {
                XMessageBox.Show(Resources.SCH0201U99_CHK, Resources.SCH0201U99_XMessageBox2742_c, MessageBoxIcon.Warning);
                return;
            }
        }

        private string getHangmogCode(string part)
        {
            string rtnVal = null;

            if(part.Equals("B")) rtnVal = "S000000001";
            else if(part.Equals("C2")) rtnVal = "S000000002";
            else if(part.Equals("C3-1")) rtnVal = "S000000003";
            else if (part.Equals("C3-2")) rtnVal = "S000000004";
            else if (part.Equals("AUT")) rtnVal = "ETC0000002";
            else if (part.Equals("IC")) rtnVal = "ETC0000001";
            else if (part.Equals("ITV")) rtnVal = "ETC0000003";
            else if (part.Equals("SPT")) rtnVal = "ETC0000004";
            else rtnVal = "E";

            return rtnVal;
        }

        private void deleteSch0201(string pksch)
        {
            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_pksch", pksch);

            try{
                // TODO comment: Use cloud service
//                Service.BeginTransaction();
//
//                string cmdText = @" DELETE FROM SCH0201 A
//                                     WHERE A.HOSP_CODE = :f_hosp_code
//                                       AND A.PKSCH0201 = :f_pksch";
//
//                if (!Service.ExecuteNonQuery(cmdText, bc))
//                    throw new Exception();
//                else Service.CommitTransaction();
                
                // End comment

                SchsSCH0201U99DeleteSCH0201Args deleteSch0201Args = new SchsSCH0201U99DeleteSCH0201Args();
                deleteSch0201Args.FPksch = pksch;
                UpdateResult updateResult =
                    CloudService.Instance.Submit<UpdateResult, SchsSCH0201U99DeleteSCH0201Args>(deleteSch0201Args);
                if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success)
                {
                    throw new Exception();
                }
            }
            catch
            {
//                Service.RollbackTransaction();
                XMessageBox.Show(Resources.deleteSch0201_Error_deleteSch0201);
                return;
            }
        }
        #endregion

        #region [Connect to cloud service]
        /// <summary>
        /// Execute Query grdOrderlist
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> grdOrderlist_ExecuteQuery(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            SchsSCH0201U99GrdOrderListArgs vSchsSCH0201U99GrdOrderListArgs = new SchsSCH0201U99GrdOrderListArgs();
            vSchsSCH0201U99GrdOrderListArgs.FBunho = bc["f_bunho"].VarValue;
            vSchsSCH0201U99GrdOrderListArgs.FFkocs = bc["f_fkocs"].VarValue;
            vSchsSCH0201U99GrdOrderListArgs.FReserStatus = bc["f_reser_status"].VarValue;
            vSchsSCH0201U99GrdOrderListArgs.FFlag = bc["f_flag"].VarValue;
            vSchsSCH0201U99GrdOrderListArgs.FReserGubun = bc["f_reser_gubun"].VarValue;
            vSchsSCH0201U99GrdOrderListArgs.FReserPart = bc["f_reser_part"].VarValue;
            if (rbtMyClinic.Checked)
            {
                vSchsSCH0201U99GrdOrderListArgs.IsMyClinnic = "Y";
            }
            else
            {
                vSchsSCH0201U99GrdOrderListArgs.IsMyClinnic = "N";
            }
            SchsSCH0201U99GrdOrderListResult result =
                CloudService.Instance.Submit<SchsSCH0201U99GrdOrderListResult, SchsSCH0201U99GrdOrderListArgs>(
                    vSchsSCH0201U99GrdOrderListArgs);
            if (result != null)
            {
                foreach (SchsSCH0201U99GrdOrderListInfo item in result.OrderList)
                {
                    object[] objects =
                    {
                        item.HangmogCode,
                        item.HangmogName,
                        item.JundalTable,
                        item.JundalPart,
                        item.JundalPartName,
                        item.Pksch0201,
                        item.Bunho,
                        item.Suname,
                        item.Gwa,
                        item.GwaName,
                        item.Doctor,
                        item.DoctorName,
                        item.OrderDate,
                        item.Emergency,
                        item.ReserDate,
                        item.ReserTime,
                        item.OrderRemark,
                        item.ReserYn,
                        item.Pkout1001,
                        item.GroupSer,
                        null,
                        item.OutHospCode
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// get data for grid grdTimeList
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> grdTimeList_ExecuteQuery(BindVarCollection bc)
        {           
            List<object[]> res = new List<object[]>();
            SchsSCH0201U99GrdTimeListArgs vSchsSCH0201U99GrdTimeListArgs = new SchsSCH0201U99GrdTimeListArgs();
            vSchsSCH0201U99GrdTimeListArgs.IpAddr = bc["f_ip_addr"].VarValue;
            if (rbtOtherClinic.Checked)
            {
                vSchsSCH0201U99GrdTimeListArgs.OutHospcode = fbxLinkHospCode.GetDataValue();
            }
            else
            {
                vSchsSCH0201U99GrdTimeListArgs.OutHospcode = "";
            }
            SchsSCH0201U99GrdTimeListResult result =
                CloudService.Instance.Submit<SchsSCH0201U99GrdTimeListResult, SchsSCH0201U99GrdTimeListArgs>(
                    vSchsSCH0201U99GrdTimeListArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<SchsSCH0201U99GrdTimeListInfo> lstGrdTimeListInfo = result.OrderList;
                if (lstGrdTimeListInfo != null && lstGrdTimeListInfo.Count > 0)
                {
                    foreach (SchsSCH0201U99GrdTimeListInfo item in lstGrdTimeListInfo)
                    {
                        object[] objects =
                        {
                            item.FromTime,
                            item.Bunho,
                            item.Suname,
                            item.HangmogName,
                            item.DoctorName,
                            item.InputDate,
                            item.OrderDate,
                            item.ReserDate,
                            item.Pksch0201,
                            item.OutHospCode,
                            item.YoyangName                            
                        };
                        res.Add(objects);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// layDateSchedule get data from cloud service
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> layDateSchedule_ExecuteQuery(BindVarCollection bc)
	    {
	        List<object[]> res = new List<object[]>();
	        SchsSCH0201U99DateScheduleListArgs vSchsSCH0201U99DateScheduleListArgs =
	            new SchsSCH0201U99DateScheduleListArgs();
	        vSchsSCH0201U99DateScheduleListArgs.FStartDate = bc["f_start_date"].VarValue;
	        vSchsSCH0201U99DateScheduleListArgs.FJundalTable = bc["f_jundal_table"].VarValue;
	        vSchsSCH0201U99DateScheduleListArgs.FJundalPart = bc["f_jundal_part"].VarValue;
	        vSchsSCH0201U99DateScheduleListArgs.FHangmogCode = bc["f_hangmog_code"].VarValue;
            if (fbxLinkHospCode.Text != string.Empty && rbtOtherClinic.Checked)
            {
                vSchsSCH0201U99DateScheduleListArgs.OutHospLink = fbxLinkHospCode.GetDataValue();
            }
            else
            {
                vSchsSCH0201U99DateScheduleListArgs.OutHospLink = "";
            }            
	        SchsSCH0201U99DateScheduleListResult result =
	            CloudService.Instance.Submit<SchsSCH0201U99DateScheduleListResult, SchsSCH0201U99DateScheduleListArgs>(
	                vSchsSCH0201U99DateScheduleListArgs);
	        if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
	        {
                List<SchsSCH0201U99DateScheduleItemInfo> lstDateScheduleItem = result.DateScheduleItem;
	            if (lstDateScheduleItem != null && lstDateScheduleItem.Count > 0)
	            {
	                foreach (SchsSCH0201U99DateScheduleItemInfo item in lstDateScheduleItem)
	                {
	                    object[] objects =
	                    {
	                        item.Dayofmon,
                            item.CheckYn,
                            item.Inwon,
                            item.Outwon
	                    };
	                    res.Add(objects);
	                }
	            }
	        }
	        return res;
	    }

        /// <summary>
        /// layReserTimeChk get data from cloud service
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> layReserTimeChk_ExecuteQuery(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            SchsSCH0201U99ReserTimeChkArgs vSchsSCH0201U99ReserTimeChkArgs = new SchsSCH0201U99ReserTimeChkArgs();
            vSchsSCH0201U99ReserTimeChkArgs.Bunho = bc["f_bunho"].VarValue;
            vSchsSCH0201U99ReserTimeChkArgs.ReserDate = bc["f_reser_date"].VarValue;
            vSchsSCH0201U99ReserTimeChkArgs.ReserTime = bc["f_reser_time"].VarValue;
            vSchsSCH0201U99ReserTimeChkArgs.Pksch0201 = bc["f_pksch0201"] != null ? bc["f_pksch0201"].VarValue : "";
            SchsSCH0201U99ReserTimeChkResult result =
                CloudService.Instance.Submit<SchsSCH0201U99ReserTimeChkResult, SchsSCH0201U99ReserTimeChkArgs>(
                    vSchsSCH0201U99ReserTimeChkArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<DataStringListItemInfo> lstItemInfo = result.ChkCheck;
                if (lstItemInfo != null && lstItemInfo.Count > 0)
                {
                    foreach (DataStringListItemInfo item in result.ChkCheck)
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
        /// GetCodeName
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> GetCodeName(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            SchsSCH0201U99LayoutCommonListArgs vSchsSCH0201U99LayoutCommonListArgs = new SchsSCH0201U99LayoutCommonListArgs();
            vSchsSCH0201U99LayoutCommonListArgs.Doctor = bc["f_doctor"].VarValue;
            vSchsSCH0201U99LayoutCommonListArgs.FGwa = bc["f_gwa"].VarValue;
            SchsSCH0201U99LayoutCommonListResult result = CloudService.Instance.Submit<SchsSCH0201U99LayoutCommonListResult, SchsSCH0201U99LayoutCommonListArgs>(vSchsSCH0201U99LayoutCommonListArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<SchsSCH0201U99LayoutCommonListInfo> lstLayoutCommonListInfo = result.CommonList;
                if (lstLayoutCommonListInfo != null && lstLayoutCommonListInfo.Count > 0)
                {
                    foreach (SchsSCH0201U99LayoutCommonListInfo item in lstLayoutCommonListInfo)
                    {
                        object[] objects =
                        {
                            item.DoctorName,
                            item.ReserYn
                        };
                        res.Add(objects);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// Execute PR_SCH_SCH0201_IUD
        /// </summary>
        /// <param name="aIudGubun"></param>
        /// <param name="aFksch0201"></param>
        /// <param name="aReserDate"></param>
        /// <param name="aReserTime"></param>
        /// <param name="aInputId"></param>
        /// <returns></returns>

        //MED-10590
        private SchsSCH0201U99ExecIUDResult ExecutePrSchSCH0201Iud(string aIudGubun, List<SCH0201U99ListFkschInfo> aFksch0201, string aReserDate, string aReserTime, string aInputId, string ajundalTable, string ajundalPart, string out_hospcode) 
	    {
	        SchsSCH0201U99ExecIUDArgs sch0201U99ExecIudArgs = new SchsSCH0201U99ExecIUDArgs();
            sch0201U99ExecIudArgs.IIudGubun = aIudGubun;
            sch0201U99ExecIudArgs.LstFksch = aFksch0201;
            sch0201U99ExecIudArgs.IReserDate = aReserDate;
            sch0201U99ExecIudArgs.IReserTime = aReserTime;
            sch0201U99ExecIudArgs.IInputId = aInputId;
            sch0201U99ExecIudArgs.JundalPart = ajundalPart;
            sch0201U99ExecIudArgs.JundalTable = ajundalTable;
            sch0201U99ExecIudArgs.OutHospcode = out_hospcode;
            
            return
                CloudService.Instance.Submit<SchsSCH0201U99ExecIUDResult, SchsSCH0201U99ExecIUDArgs>(
                    sch0201U99ExecIudArgs);
	    }

        /// <summary>
        /// cboGumsa_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
	    private IList<object[]> cboGumsa_ExecuteQuery(BindVarCollection varCollection)
	    {
	        IList<object[]> listObject = new List<object[]>();
	        ComboGumsaArgs comboGumsaArgs = new ComboGumsaArgs();
            //ComboResult comboResult =
            //    CacheService.Instance.Get<ComboGumsaArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_SCH_COMBO_GUMSA_KEYS,
            //        comboGumsaArgs);

            //ComboResult comboResult = CloudService.Instance.Submit<ComboResult, ComboGumsaArgs>(new ComboGumsaArgs());
            ComboResult comboResult = CacheService.Instance.Get<ComboGumsaArgs, ComboResult>(comboGumsaArgs);

	        if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
	        {
	            List<ComboListItemInfo> lstItemInfo = comboResult.ComboItem;
	            if (lstItemInfo != null && lstItemInfo.Count > 0)
	            {
	                foreach (ComboListItemInfo itemInfo in lstItemInfo)
	                {
	                    listObject.Add(new object[]
	                    {
	                        itemInfo.Code,
                            itemInfo.CodeName
	                    });
	                }
	            }
	        }
	        return listObject;
	    }

        /// <summary>
        /// cboGumsaPart_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
	    private IList<object[]> cboGumsaPart_ExecuteQuery(BindVarCollection varCollection)
	    {
            IList<object[]> listObject = new List<object[]>();
            string cboGumsaValue = varCollection["cboGumsa_value"].VarValue;
            if (string.IsNullOrEmpty(cboGumsaValue))
            {
                return listObject;
            }
            SchsSCH0201U99ComboGumsaPartArgs comboGumsaPartArgs = new SchsSCH0201U99ComboGumsaPartArgs();
            comboGumsaPartArgs.JundalTable = cboGumsaValue;
            ComboResult comboResult =
                CloudService.Instance.Submit<ComboResult, SchsSCH0201U99ComboGumsaPartArgs>(comboGumsaPartArgs);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> lstItemInfo = comboResult.ComboItem;
                if (lstItemInfo != null && lstItemInfo.Count > 0)
                {
                    foreach (ComboListItemInfo itemInfo in lstItemInfo)
                    {
                        listObject.Add(new object[]
	                    {
	                        itemInfo.Code,
                            itemInfo.CodeName
	                    });
                    }
                }
            }
            return listObject;
	    }
        #endregion

        #region Update Feature Kobari
        
        private void rbtMyClinic_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMyClinic.Checked)
            {
                rbtMyClinic.BackColor = SystemColors.ActiveCaption;
                rbtMyClinic.ImageIndex = 19;
                grdOrderlist.QueryLayout(true);
                GetTooltip();
            }
            else
            {
                rbtMyClinic.BackColor = SystemColors.InactiveCaption;
                rbtMyClinic.ImageIndex = 18;
            }
        }

        private void rbtOtherClinic_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtOtherClinic.Checked)
            {
                rbtOtherClinic.BackColor = SystemColors.ActiveCaption;
                rbtOtherClinic.ImageIndex = 19;
                xLabel4.Visible = true;
                fbxLinkHospCode.Visible = true;
                dbxLinkHospName.Visible = true;
                xLabel6.Visible = true;
                fbxDoctor.Visible = true;
                dbxDoctor_name.Visible = true;
                xLabel5.Visible = true;
                cboGwa.Visible = true;                
                LookAndFeel("A");

                //xButtonList1.PerformClick(FunctionType.Query);
                if (fbxLinkHospCode.GetDataValue() == string.Empty)
                {
                    grdOrderlist.Reset();
                    grdTimeList.Reset();
                    calSchedule.Dates.Clear();
                    calSchedule.Refresh();

                }
                else
                {
                    grdOrderlist.QueryLayout(false);
                }
                if (grdOrderlist.RowCount > 0)
                {
                    grdOrderlist.SetFocusToItem(1, "hangmog_code");
                }
            }
            else
            {
                rbtOtherClinic.BackColor = SystemColors.InactiveCaption;
                rbtOtherClinic.ImageIndex = 18;
                xLabel4.Visible = false;
                fbxLinkHospCode.Visible = false;
                dbxLinkHospName.Visible = false;
                xLabel6.Visible = false;
                fbxDoctor.Visible = false;
                dbxDoctor_name.Visible = false;
                xLabel5.Visible = false;
                cboGwa.Visible = false;
                LookAndFeel("B");
            }
        }

        private void fbxLinkHospCode_FindClick(object sender, CancelEventArgs e)
        {
            XFindBox control = sender as XFindBox;
            

        }

        private void fbxLinkHospCode_DataValidating(object sender, DataValidatingEventArgs e)
        {
            RES1001U00FbxHospCodeLinkDataValidatingArgs args = new RES1001U00FbxHospCodeLinkDataValidatingArgs();
            args.HospCode = e.DataValue;
            args.Bunho = paBox.BunHo;
            RES1001U00FbxHospCodeLinkDataValidatingResult result = CloudService.Instance.Submit<RES1001U00FbxHospCodeLinkDataValidatingResult, RES1001U00FbxHospCodeLinkDataValidatingArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (result.HospName != "")
                {
                    dbxLinkHospName.SetDataValue(result.HospName);
                    mHospCodeLink = e.DataValue;
                    mBunhoLink = result.BunhoLink;
                    // load combo gwa
                    CreateCombo();
                    //xButtonList1.PerformClick(FunctionType.Query);
                    grdOrderlist.QueryLayout(true);
                    if (grdOrderlist.RowCount > 0)
                    {
                        grdOrderlist.SetFocusToItem(1, "hangmog_code");
                    }
                }
            }
            else
            {
                dbxLinkHospName.SetDataValue("");
                mHospCodeLink = "";
            }
            if (dbxLinkHospName.Text == string.Empty)
            {
                fbxDoctor.Enabled = false;
            }
            else
            {
                fbxDoctor.Enabled = true; ;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            fbxDoctor.Clear();
            dbxDoctor_name.Text = "";
        }

        private IList<object[]> LoadDataLinkHospCode(BindVarCollection list)
        {

            IList<object[]> lstResult = new List<object[]>();

            RES1001U00FbxHospCodeLinkArgs args = new RES1001U00FbxHospCodeLinkArgs();
            args.Bunho = (String.IsNullOrEmpty(paBox.BunHo)) ? "" : paBox.BunHo;

            RES1001U00FbxHospCodeLinkResult result = CloudService.Instance
                .Submit<RES1001U00FbxHospCodeLinkResult, RES1001U00FbxHospCodeLinkArgs>(args);

            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                IList<RES1001U00FbxHospCodeLinkListItemInfo> listItem = result.FbxHospCodeList;

                foreach (RES1001U00FbxHospCodeLinkListItemInfo item in listItem)
                {

                    object[] objects =
                    {
                        item.HospCode,
                        item.HospName,
                        item.Address,
                        item.Telephone
                    };
                    lstResult.Add(objects);
                }
            }

            return lstResult;
        }

        private IList<object[]> ComboChoJae(BindVarCollection list)
        {
            IList<object[]> data = new List<object[]>();

            ComboListByCodeTypeArgs argsCombo = new ComboListByCodeTypeArgs();
            argsCombo.CodeType = "CHOJAE";
            argsCombo.IsAll = false;
            argsCombo.HospCodeLink = mHospCodeLink;
            argsCombo.TabIsAll = tabIsAll;
            ComboListItemResult result = CacheService.Instance.Get<ComboListByCodeTypeArgs, ComboListItemResult>(argsCombo);

            if (result != null && result.ListItemInfos.Count > 0)
            {
                foreach (ComboListItemInfo item in result.ListItemInfos)
                {
                    data.Add(new object[]
                             {
                                 item.Code,
                                 item.CodeName
                             });
                }
            }

            return data;
        }

        private IList<object[]> ComboGwa(BindVarCollection bc)
        {
            IList<object[]> lstResult = new List<object[]>();

            NuroRES0102U00CboGwaArgs argsCboGwa = new NuroRES0102U00CboGwaArgs();
            argsCboGwa.HospCode = bc["f_hosp_code"].VarValue;
            argsCboGwa.AppDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now);
            argsCboGwa.HospCodeLink = mHospCodeLink;
            argsCboGwa.TabIsAll = tabIsAll;

            NuroRES0102U00CboGwaResult result =
                CloudService.Instance
                    .Submit<NuroRES0102U00CboGwaResult, NuroRES0102U00CboGwaArgs>(argsCboGwa);

            if (result != null)
            {
                IList<ComboListItemInfo> listItem = result.CboItemInfo;

                foreach (ComboListItemInfo item in listItem)
                {

                    object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                    lstResult.Add(objects);
                }
            }
            return lstResult;
        }

        private void fbxDoctor_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (TypeCheck.IsNull(cboGwa.GetDataValue().Trim()))
            {
                dbxDoctor_name.SetEditValue("");
                return;
            }
            if (TypeCheck.IsNull(e.DataValue.ToString().Trim()))
            {
                dbxDoctor_name.SetEditValue("");
                return;
            }
            //Check Origin Data
            string codeName = GetCodeName("doctor_name", e.DataValue.ToString());

            if (TypeCheck.IsNull(codeName))
            {
                mbxMsg = Resources.MSG007_MSG;
                mbxCap = "";
                XMessageBox.Show(mbxMsg, mbxCap);
                e.Cancel = true;

            }
            else if (codeName == "XXX")
            {
                mbxMsg = Resources.MSG007_MSG;
                mbxCap = "";
                XMessageBox.Show(mbxMsg, mbxCap);
                e.Cancel = true;
            }
            else if (codeName == "NO_RESER")
            {
                mbxMsg = Resources.MSG008_MSG;
                mbxCap = "";
                XMessageBox.Show(mbxMsg, mbxCap);
                e.Cancel = true;
            }
            else
            {
                dbxDoctor_name.SetEditValue(codeName);

                mDoctor = e.DataValue.ToString().Trim();
               // xButtonList1.PerformClick(FunctionType.Query);
            

               
            }
        }

        private IList<object[]> LoadDoctor(BindVarCollection list)
        {
            IList<object[]> data = new List<object[]>();

            NuroRES1001U00DoctorReservationStatusListArgs args = new NuroRES1001U00DoctorReservationStatusListArgs();
            args.DepartmentCode = list["f_gwa"].VarValue;
            args.DoctorCode = list["f_doctor"].VarValue;
            args.HospCodeLink = mHospCodeLink;
            args.TabIsAll = tabIsAll;

            NuroRES1001U00DoctorReservationStatusListResult result = CloudService.Instance
                .Submit<NuroRES1001U00DoctorReservationStatusListResult, NuroRES1001U00DoctorReservationStatusListArgs>(
                    args);

            if (result != null)
            {
                foreach (NuroRES1001U00DoctorReservationStatusListItemInfo items in result.DoctorResStatusListItem)
                {
                    object[] objects =
                    {
                        items.DoctorName,
                        items.ReservationStatus
                    };

                    data.Add(objects);
                }
            }
            return data;
        }

        private void LookAndFeel(string look)
        {
            if (look == "A") // click button other clinic
            {
                pnlDoctor.Height = 90;
                xPanel1.Location = new Point(0, 125);
                panel1.Location = new Point(682, 123);
            }
            if(look == "B") // click button my clinic
            {
                pnlDoctor.Height = 65;
                xPanel1.Location = new Point(0, 100);
                panel1.Location = new Point(682, 98);
            }
        }

        #region Check before insert table SCH0201

        #region Comment by MED-8095
        //private string IfCodeDoctor = "";
        //private string IfCodeGwa = "";
        //private string OrcaIp = "";
        //private string OrcaPassword = "";
        //private string OrcaUser = "";
        //private string AccType = ""; 
        #endregion

        private bool CheckBeforeInsert(string reserDate, string reserTime)
        {
            IList<object[]> lstResult = new List<object[]>();
            if (dbxDoctor_name.Text == string.Empty)
            {
                mbxMsg = Resources.MSG009_MSG;
                XMessageBox.Show(mbxMsg, "", MessageBoxIcon.Warning);
                return false;
            }
  
            // Datavalidate
            Schs0201U99CheckORCAEnvInfoArgs args = new Schs0201U99CheckORCAEnvInfoArgs();
            args.HospCode = fbxLinkHospCode.GetDataValue();
            args.Gwa = cboGwa.GetDataValue();
            args.HangmogCode = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "hangmog_code");
            args.NaewonDate = reserDate;
            args.Doctor = fbxDoctor.GetDataValue();
            args.CodeType = "ACCT_ORCA"; //todo
            args.BunhoLink = paBox.BunHo;
            args.JundalTable = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "jundal_table");
            args.JundalPart = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "jundal_part");
            args.ReserDate = reserDate;
            args.ReserTime = reserTime;
            args.InputGubun = "O";
            
            
            //todo
            Schs0201U99CheckORCAEnvInfoResult result = CloudService.Instance.Submit<Schs0201U99CheckORCAEnvInfoResult, Schs0201U99CheckORCAEnvInfoArgs>(args);

            if (result.ErrCode != "0") // 0 - > booking labs
            {
                string msgCap = Resources.MSGTitleConfirm;
                string msg = "";
                switch (result.ErrCode)
                {
                    case "1":
                        msg = Resources.MSGVal001;
                        break;
                    case "2":
                        msg = Resources.MSGVal002;
                        break;
                    case "3":
                        msg = Resources.MSGVal003;
                        break;
                    case "4":
                        msg = Resources.MSGVal004;
                        break;
                    case "5":
                        msg = Resources.MSGVal005;
                        break;
                    default:
                        msg = Resources.MSGTitleError;
                        break;

                }
                XMessageBox.Show(msg, msgCap, MessageBoxIcon.Error);
                return false;
            }
            #region Comment by MED-8095
            //else
            //{
            //    if (result.LstData.Count > 0)
            //    {
            //        foreach (Schs0201U99CheckORCAEnvInfoInfo item in result.LstData)
            //        {

            //            object[] objects =
            //        {
            //            item.IfCodeDoctor,
            //            item.IfCodeGwa,
            //            item.OrcaIp,
            //            item.OrcaPassword,
            //            item.OrcaUser,
            //            item.AccType
            //        };
            //            lstResult.Add(objects);

            //        }
            //        IfCodeDoctor = lstResult[0][0].ToString();
            //        IfCodeGwa = lstResult[0][1].ToString();
            //        OrcaIp = lstResult[0][2].ToString();
            //        OrcaPassword = lstResult[0][3].ToString();
            //        OrcaUser = lstResult[0][4].ToString();
            //        AccType = lstResult[0][5].ToString();
            //    }
            //} 
            #endregion

            return true;
        }

        private void InsertBookingLabs(List<SCH0201U99ListFkschInfo> i_fksch0201, string aReserDate, string aReserTime,string nameKanji, string nameKana)
        {
            //done booking ok
            Schs0201U99BookingLabArgs args = new Schs0201U99BookingLabArgs();
            args.BunhoLink = mBunhoLink;
            args.Changu = UserInfo.UserID;
            args.Chojae = "4";
            args.Doctor = fbxDoctor.GetDataValue();
            args.LstFksch = i_fksch0201;
            args.Gubun = string.Empty; //todo
            args.Gwa = cboGwa.GetDataValue();
            args.HospCode = mHospCodeLink;
            args.InputGubun = "O";
            args.InputId = string.Empty;
            args.IudGubun = "U";
            args.NaewonDate = aReserDate;
            args.OutHospcode = UserInfo.HospCode;
            args.Pkout1001 = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "pkout1001");
            args.ReserComment = string.Empty;
            args.ReserDate = aReserDate;
            args.ReserTime = aReserTime;
            args.ReserYn = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "reser_yn");
            args.ResGubun = "Y";
            args.NameKanji = nameKanji;
            args.NameKana = nameKana;
            
            Schs0201U99BookingLabResult result = CloudService.Instance.Submit<Schs0201U99BookingLabResult, Schs0201U99BookingLabArgs>(args);
            if (result.ErrCode != "0")
            {
                if (Array.IndexOf(msgOrca, result.ErrCode) < 0)
                {
                    XMessageBox.Show(Utilities.MessageOrcaBooking(result.ErrCode), result.ErrCode, MessageBoxIcon.Warning);                   
                }
                else
                {
                    XMessageBox.Show(Resources.MSGErrorBooking, Resources.MSGTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
                Service.WriteLog(" [SCH0201U99][Error code]: " + result.ErrCode);
            }
            
            // AnhNV deleted to increase load performance
            //this.grdOrderlist.QueryLayout(true);
            //this.setFocusProcess(i_fksch0201);
            }

        #endregion

        #endregion

        #region Show Tooltip when hovers on time list

        private List<TooltipInfo> _lstTooltipInfo;

        private void GetTooltip()
        {
            List<TooltipInfo> tiLst = new List<TooltipInfo>();

            List<SCH0201U99EMRLinkInfo> lstItem = new List<SCH0201U99EMRLinkInfo>();
            for (int i = 0; i < grdTimeList.RowCount; i++)
            {
                // Skips rows contain no orders
                if (grdTimeList.GetItemString(i, "bunho") == "") continue;

                SCH0201U99EMRLinkInfo item = new SCH0201U99EMRLinkInfo();
                item.Bunho = grdTimeList.GetItemString(i, "bunho");
                item.HospCodeLink = grdTimeList.GetItemString(i, "hosp_code");

                lstItem.Add(item);
        }
       
            if (lstItem.Count > 0)
            {
                SCH0201U99BookingDetailArgs args = new SCH0201U99BookingDetailArgs();
                args.JundalTable = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "jundal_table");
                args.JundalPart = grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "jundal_part");
                args.ReserDate = mCurrentDate != "" ? mCurrentDate : grdOrderlist.GetItemString(grdOrderlist.CurrentRowNumber, "reser_date");
                args.Reservation = cboReserStatus.GetDataValue();
                args.EmrLinkItem = lstItem;
                SCH0201U99BookingDetailResult res = CloudService.Instance.Submit<SCH0201U99BookingDetailResult, SCH0201U99BookingDetailArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    res.DetailInfo.ForEach(delegate(SCH0201U99BookingDetailInfo item)
                    {
                        TooltipInfo ti = new TooltipInfo();
                        ti.PatientID = item.Bunho;
                        ti.PatientName = item.Suname;
                        ti.Birth = Utilities.GetDateByLangMode(item.Birth, NetInfo.Language);
                        ti.Sex = item.Sex == "M" ? Resources.TXT_SEX_MALE : Resources.TXT_SEX_FEMALE;
                        ti.BookingClinicID = item.HospCode;
                        ti.BookingClinicName = item.YoyangName;
                        ti.BookingDate = FormatDateStr(item.BookingDate);
                        ti.LinkEMRInfo = item.LinkEmrFlg == "1" ? Resources.TXT_YES : Resources.TXT_NO;
                        ti.HangmogCode = item.HangmogCode;
                        ti.ReserTime = item.ReserTime;
       
                        tiLst.Add(ti);
                    });
                }
            }

            _lstTooltipInfo = tiLst;
        }

        private string MakeTooltipText(List<TooltipInfo> tiLst, string reserTime, string bunho, out bool hasReser)
        {
            hasReser = false;
            StringBuilder sb = new StringBuilder();

            foreach (TooltipInfo ti in tiLst)
            {
                if (ti.PatientID == bunho && ti.ReserTime == reserTime)
                {
                    sb.AppendLine(Resources.TXT_PATIENT_INFORMATION);
                    sb.AppendLine(string.Format("\t{0}:\t\t{1}\t", Resources.TXT_PATIENT_ID, ti.PatientID));
                    sb.AppendLine(string.Format("\t{0}:\t\t{1}\t", Resources.TXT_PATIENT_NAME, ti.PatientName));
                    sb.AppendLine(string.Format("\t{0}:\t\t{1}\t", Resources.TXT_DATE_OF_BIRTH, ti.Birth));
                    sb.AppendLine(string.Format("\t{0}:\t\t\t{1}\t", Resources.TXT_SEX, ti.Sex));
                    if (UserInfo.HospCode != ti.BookingClinicID.Trim())
                    {
                        sb.AppendLine(Resources.TXT_EXAM_INFO);
                    }
                    else
                    {
                        sb.AppendLine(Resources.GetToolTipText_15);
                    }
                    sb.AppendLine(string.Format("\t{0}:\t\t{1}\t", Resources.TXT_BOOKING_CLINIC_ID, ti.BookingClinicID));
                    sb.AppendLine(string.Format("\t{0}:\t\t{1}\t", Resources.TXT_BOOKING_CLINIC_NAME, ti.BookingClinicName));
                    sb.AppendLine(string.Format("\t{0}:\t\t\t{1}\t", Resources.TXT_TEL, ti.Tel));
                    sb.AppendLine(string.Format("\t{0}:\t\t{1}\t", Resources.TXT_BOOKING_DATE, ti.BookingDate));
                    sb.AppendLine(string.Format("\t{0}:\t{1}\t", Resources.TXT_LINK_EMR_INFO, ti.LinkEMRInfo));

                    hasReser = true;
                    break;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Gets date string from (yyyy/mm/dd hhMM)
        /// </summary>
        /// <param name="date">(yyyy/mm/dd hhMM)</param>
        /// <returns>(yyyy/mm/dd hh:MM)</returns>
        private string FormatDateStr(string date)
        {
            string resultDt = "";

            if (!TypeCheck.IsNull(date))
            {
                string[] dateArr = date.Split(' ');
                if (dateArr.Length > 1)
                {
                    string ymdStr = dateArr[0];
                    string timeStr = dateArr[1];

                    if (!TypeCheck.IsNull(timeStr))
                    {
                        DateTime dt = DateTime.ParseExact(timeStr, "HHmm", CultureInfo.InvariantCulture);

                        switch (NetInfo.Language)
                        {
                            case LangMode.Jr:
                                resultDt = string.Format("{0} {1}", Utilities.GetDateByLangMode(ymdStr, NetInfo.Language), dt.ToString("h時mm分"));
                                break;
                            default:
                                resultDt = string.Format("{0} {1}", ymdStr, dt.ToString("hh:MM")); // hh:MM
                                break;
                        }
                    }
                    else
                    {
                        resultDt = Utilities.GetDateByLangMode(ymdStr, NetInfo.Language);
                    }
                }
            }

            return resultDt;
        }

        /// <summary>
        /// Disable the default tooltip of XEditGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdTimeList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            grd[e.RowNumber, e.ColName].ToolTipText = " ";
            if (e.DataRow["hosp_code"].ToString() != "" && e.DataRow["hosp_code"].ToString() != UserInfo.HospCode)
            {
                e.BackColor = Color.Khaki;
            }

        }

        private void grdTimeList_MouseMove(object sender, MouseEventArgs e)
        {
            // Tooltip has not been set
            if (_lstTooltipInfo == null) return;

            XEditGrid grd = sender as XEditGrid;
            if (grd != null)
            {
                if (rbtMyClinic.Checked)
                {
                    int curRowIndex = -1;
                    curRowIndex = grd.GetHitRowNumber(e.Y);
                    if (curRowIndex < 0)
                    {
                        toolTip1.Active = false;
                        curPreRowIndex = -1;
                        curPreX = -1;
                    }
                    else if ((curPreRowIndex != curRowIndex || Math.Abs(e.X - curPreX) > 20) && curRowIndex >= 0)
                    {
                        bool hasReser;
                        string reserTime = grd.GetItemString(curRowIndex, "from_time");
                        string bunho = grd.GetItemString(curRowIndex, "bunho");
                        string textTip = MakeTooltipText(_lstTooltipInfo, reserTime, bunho, out hasReser);
                        if (hasReser)
                        {
                            toolTip1.Active = true;
                            toolTip1.ShowAlways = true;
                            curPreRowIndex = curRowIndex;
                            toolTip1.Show(textTip, grd, e.Location);
                            curPreX = e.X;
                        }
                        else
                        {
                            toolTip1.Active = false;
                            curPreRowIndex = -1;
                            curPreX = -1;
                        }
                    }
                }
            }
            else
            {
                toolTip1.Active = false;
                curPreRowIndex = -1;
                curPreX = -1;
            }
        }

        private void grdTimeList_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Active = false;
            curPreRowIndex = -1;
            curPreX = -1;
        }

        private class TooltipInfo
        {
            // Patient info
            public string PatientID = "";
            public string PatientName = "";
            public string Birth = "";
            public string Sex = "";

            // Booking info
            public string BookingClinicID = "";
            public string BookingClinicName = "";
            public string Tel = "";
            public string BookingDate = "";
            public string LinkEMRInfo = "";
            public string HangmogCode = "";
            public string ReserTime = "";
        }

        #endregion

        private void grdOrderlist_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            //if (rbtMyClinic.Checked)
            //{
            //    if (e.DataRow["out_hosp_code"].ToString() == UserInfo.HospCode || e.DataRow["out_hosp_code"].ToString() == string.Empty)
            //    {
            //        e.Protect = false;
            //    }
            //    else
            //    {
            //        e.Protect = true;
            //    }
            //}
            //else
            //{
            //    e.Protect = true;
            //}
        }

        private void grdTimeList_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (rbtMyClinic.Checked)
            {
                if (e.DataRow["hosp_code"].ToString() == UserInfo.HospCode || e.DataRow["out_hosp_code"].ToString() == string.Empty)
                {
                    e.Protect = false;
                }
                else
                {
                    e.Protect = true;
                }
            }
            
        }

        private void grdOrderlist_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["out_hosp_code"].ToString() != "" && e.DataRow["out_hosp_code"].ToString() != UserInfo.HospCode)
            {
                e.BackColor = Color.Khaki;
            }

        }

        private void SCH0201U99_Load(object sender, EventArgs e)
        {
            Form form = Parent.Parent as Form;
            if (form != null)
            {
                form.Size = form.MinimumSize;
            }
        }
    }
}