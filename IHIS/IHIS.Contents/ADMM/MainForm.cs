using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Threading;
using System.Xml.XPath;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Utility;
using Microsoft.Win32;
using IHIS.Framework;

namespace IHIS.ADMM 
{
	/// <summary>
	/// MainForm에 대한 요약 설명입니다.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{

		#region static Fields, Property
		//메세지시스템의 ProductID, ServiceName
		//Registry에 관리할 수신보류,알람, 알람사운드 파일의 Key
		const string RKEY_MSG_RECV_DENY = "MsgRecvDeny";
		const string RKEY_MSG_RECV_ALARM = "TurnOnMsgAlarm";
		const string RKEY_MSG_SOUND_FILE = "MsgSoundFile";
		const string MSG_SYS_ID = "ADMM";
        // <<2013.12.08>> LKH
        //const string FILE_USER_ID = "IHISfile";  //첨부파일 FTP 접속 ID (Password도 동일함)
        const string FILE_USER_ID = "ihismsg";  //첨부파일 FTP 접속 ID (Password도 동일함)

		const int MAX_MSG_LENGTH = 2000; //최대 메세지의 길이
		private static ArrayList userItemList = new ArrayList();
		public static ArrayList UserItemList  //현재 업무시스템에 LOGIN한 사용자정보를 관리하는 리스트
		{
			get { return userItemList;}
		}
		private static int popupFormCount = 0;  //메세지수신창의 갯수
		public static int PopupFormCount
		{
			get { return popupFormCount;}
			set { popupFormCount = value;}
		}
		private static string currUserID = "";
		[DataBindable]
		public static string CurrUserID
		{
			get { return currUserID;}
			set { currUserID = value;}
		}
		#endregion

		#region Fields and Properties
		private ArrayList msgTreeItemList = new ArrayList();
		private bool isCheckUserList = true; //메세지시스템 창이 보일때 사용자리스트를 Check할지 여부(메세지수신창에서 Call시는 false로 설정하여 Check하지 않음)
		private string systemName = "";
		private string groupID = "";
		private string groupName = "";
		private string systemID = "";
		private Font   selectedFont = new Font("MS UI Gothic",9.0f, FontStyle.Bold);  //선택된 Radio Font
		private Font   unSelectedFont = new Font("MS UI Gothic",9.0f); //선택해제된 Radio Font
		private Color  selectedBackColor = Color.PaleTurquoise;
		private Color  unSelectedBackColor = Color.FromArgb(227,248,181);
		private bool   isCallCheckedChanged = true; //전체삭제,확인 CheckBox Event 수행여부
		private string soundFileName = "";
		private ArrayList addedFileItems = new ArrayList();  //첨부된파일정보(AddedFileItem)을 관리하는 LIST
		private string fileServerIP = "";  //첨부파일 관리 ServerIP
		private string fileServerUserID = "";  //첨부파일 관리 Server UserID
		private string fileServerPswd = "";    //첨부파일 관리 Server User Pswd
        private string mHospCode = "";

		//첨부파일 서버 정보(AddFileListForm에서 다운로드시 사용함)
		internal string FileServerIP
		{
			get { return fileServerIP;}
		}
		internal string FileServerUserID
		{
			get { return fileServerUserID;}
		}
		internal string FileServerPwsd
		{
			get { return fileServerPswd;}
		}
		/// <summary>
		/// 송신내역 조회구분(Y.송신확인, N.송신미확인, %.전체)
		/// </summary>
		[DataBindable]
		public string SendQryGubun
		{
			get 
			{
				if (this.rbxSendNo.Checked)
					return "N";
				else if (this.rbxSendYes.Checked)
					return "Y";
				else
					return "%";
			}
		}
		/// <summary>
		/// 수신내역 조회구분(Y.확인, N.미확인, %.전체)
		/// </summary>
		[DataBindable]
		public string RecvQryGubun
		{
			get 
			{
				if (this.rbxRecvNo.Checked)
					return "N";
				else if (this.rbxRecvYes.Checked)
					return "Y";
				else
					return "%";
			}
		}
		#endregion

		#region 사용자 정의 MSG ID
		const int MSG_SYSTEM_WINDOW_HANDLE_SEND = (int)(Win32.Msgs.WM_USER + 103); //ADMM 시스템 WindowHandle을 IHIS로 보냄
		const int MSG_SYSTEM_USER_LOGIN			= (int)(Win32.Msgs.WM_USER + 106); //시스템사용자 LOGIN MSG
		const int MSG_SYSTEM_USER_LOGOUT		= (int)(Win32.Msgs.WM_USER + 107); //시스템사용자 LOGOUT 메세지
		const int MSG_SYSTEM_USER_CHANGED		= (int)(Win32.Msgs.WM_USER + 108); //시스템 사용자 변경 메세지
		const int MSG_XMSG_DISPLAY				= (int)(Win32.Msgs.WM_USER + 111); //ADMM 시스템 Display 메세지
		#endregion

		#region Control 정의
		private IHIS.Framework.XButton btnCloseRecv;
		private IHIS.Framework.XButton btnCloseSend;
		private System.Windows.Forms.TextBox txtSendTitle;
		private IHIS.Framework.XTextBox txtResvTitle;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label6;
		private IHIS.Framework.XButton btnSendDetail;
		private System.Windows.Forms.GroupBox groupBox2;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XButton btnResvCopy;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.TextBox txtRecvSpot;


		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MenuItem menuShow;
		private System.Windows.Forms.MenuItem menuHide;
		private IHIS.Framework.XButton btnClear;
		private IHIS.Framework.XButton btnSend;
		private IHIS.Framework.XButton btnSearch;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGrid grdRecv;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGrid grdSend;
		private IHIS.Framework.XEditGrid grdResv;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private System.Windows.Forms.Panel panel4;
		private IHIS.Framework.XButton btnResvAdd;
		private IHIS.Framework.XButton btnResvDelete;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.RadioButton rbxRecvAll;
		private System.Windows.Forms.RadioButton rbxRecvYes;
		private System.Windows.Forms.RadioButton rbxRecvNo;
		private System.Windows.Forms.RadioButton rbxSendAll;
		private System.Windows.Forms.RadioButton rbxSendYes;
		private System.Windows.Forms.RadioButton rbxSendNo;
		private IHIS.Framework.XDatePicker dtpRecvFrdt;
		private IHIS.Framework.XDatePicker dtpRecvTodt;
		private IHIS.Framework.XDatePicker dtpSendFrDt;
		private IHIS.Framework.XDatePicker dtpSendToDt;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XButton btnDeleteSend;
		private IHIS.Framework.XButton btnRecvCnfm;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XButton btnReply;
		private System.Windows.Forms.TextBox txtResvMsg;
		private System.Windows.Forms.TextBox txtSendMsg;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
		private System.Windows.Forms.CheckBox cbxSendDel;
		private System.Windows.Forms.CheckBox cbxRecvDel;
		private System.Windows.Forms.CheckBox cbxRecvCnfm;
		private System.Windows.Forms.CheckBox cbxRecvDeny;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox cbxAlarm;
		private IHIS.Framework.XButton btnMySound;
		private IHIS.Framework.XButton btnAddFile;
		private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.MultiLayout layRecverList;
		private System.Windows.Forms.CheckBox cbxSendAllCnfm;
		private System.Windows.Forms.Label lbRecvQryDate;
		private System.Windows.Forms.GroupBox gbxResvMemo;
		private System.Windows.Forms.GroupBox gbxWriteMsg;
		private System.Windows.Forms.GroupBox gbxSendMsgList;
		private System.Windows.Forms.Label lbResvMsgTitle;
		private System.Windows.Forms.Label lbRecver;
		private System.Windows.Forms.Label lbMsgTitle;
		private System.Windows.Forms.Label lbMsgContents;
		private System.Windows.Forms.Label lbSendQryDate;
		private System.Windows.Forms.NotifyIcon trayIcon;
		private IHIS.Framework.XButton btnUserChange;
        private MultiLayout layFileList;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private XEditGridCell xEditGridCell20;
        private CheckBox cbxSendCnfm;
        private XEditGridCell xEditGridCell23;
		private System.Windows.Forms.ContextMenu ctxMenu;

		#endregion

		#region 생성자
		public MainForm(string groupID, string groupName, string systemID, string systemName) 
		{
			InitializeComponent();

			this.groupID = groupID;
			this.groupName = groupName;
			this.systemID = systemID;
            this.systemName = systemName;
            this.mHospCode = EnvironInfo.HospCode;

			//일본어 전환
			SetControlNameByLangMode();

		}
		#endregion

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ctxMenu = new System.Windows.Forms.ContextMenu();
            this.menuShow = new System.Windows.Forms.MenuItem();
            this.menuHide = new System.Windows.Forms.MenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbxRecvCnfm = new System.Windows.Forms.CheckBox();
            this.cbxRecvDel = new System.Windows.Forms.CheckBox();
            this.grdRecv = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReply = new IHIS.Framework.XButton();
            this.rbxRecvAll = new System.Windows.Forms.RadioButton();
            this.rbxRecvYes = new System.Windows.Forms.RadioButton();
            this.lbRecvQryDate = new System.Windows.Forms.Label();
            this.btnRecvCnfm = new IHIS.Framework.XButton();
            this.rbxRecvNo = new System.Windows.Forms.RadioButton();
            this.dtpRecvFrdt = new IHIS.Framework.XDatePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpRecvTodt = new IHIS.Framework.XDatePicker();
            this.btnCloseRecv = new IHIS.Framework.XButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbxSendMsgList = new System.Windows.Forms.GroupBox();
            this.cbxSendDel = new System.Windows.Forms.CheckBox();
            this.cbxSendCnfm = new System.Windows.Forms.CheckBox();
            this.grdSend = new IHIS.Framework.XEditGrid();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpSendFrDt = new IHIS.Framework.XDatePicker();
            this.dtpSendToDt = new IHIS.Framework.XDatePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbxSendAll = new System.Windows.Forms.RadioButton();
            this.rbxSendYes = new System.Windows.Forms.RadioButton();
            this.rbxSendNo = new System.Windows.Forms.RadioButton();
            this.btnDeleteSend = new IHIS.Framework.XButton();
            this.btnSendDetail = new IHIS.Framework.XButton();
            this.lbSendQryDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCloseSend = new IHIS.Framework.XButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbxWriteMsg = new System.Windows.Forms.GroupBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnAddFile = new IHIS.Framework.XButton();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.lbMsgContents = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtSendTitle = new System.Windows.Forms.TextBox();
            this.lbMsgTitle = new System.Windows.Forms.Label();
            this.btnSearch = new IHIS.Framework.XButton();
            this.lbRecver = new System.Windows.Forms.Label();
            this.txtRecvSpot = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbxSendAllCnfm = new System.Windows.Forms.CheckBox();
            this.btnClear = new IHIS.Framework.XButton();
            this.btnSend = new IHIS.Framework.XButton();
            this.gbxResvMemo = new System.Windows.Forms.GroupBox();
            this.grdResv = new IHIS.Framework.XEditGrid();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtResvMsg = new System.Windows.Forms.TextBox();
            this.txtResvTitle = new IHIS.Framework.XTextBox();
            this.lbResvMsgTitle = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnResvCopy = new IHIS.Framework.XButton();
            this.btnResvAdd = new IHIS.Framework.XButton();
            this.btnResvDelete = new IHIS.Framework.XButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cbxRecvDeny = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbxAlarm = new System.Windows.Forms.CheckBox();
            this.btnMySound = new IHIS.Framework.XButton();
            this.btnUserChange = new IHIS.Framework.XButton();
            this.layRecverList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.layFileList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbxSendMsgList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSend)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbxWriteMsg.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.gbxResvMemo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResv)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layRecverList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layFileList)).BeginInit();
            this.SuspendLayout();
            // 
            // ctxMenu
            // 
            this.ctxMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuShow,
            this.menuHide});
            // 
            // menuShow
            // 
            this.menuShow.Index = 0;
            this.menuShow.Text = "열  기";
            this.menuShow.Click += new System.EventHandler(this.menuShow_Click);
            // 
            // menuHide
            // 
            this.menuHide.Index = 1;
            this.menuHide.Text = "닫  기";
            this.menuHide.Click += new System.EventHandler(this.menuHide_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(764, 475);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.tabPage1.Controls.Add(this.cbxRecvCnfm);
            this.tabPage1.Controls.Add(this.cbxRecvDel);
            this.tabPage1.Controls.Add(this.grdRecv);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(756, 442);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "메세지 받기";
            // 
            // cbxRecvCnfm
            // 
            this.cbxRecvCnfm.Location = new System.Drawing.Point(34, 56);
            this.cbxRecvCnfm.Name = "cbxRecvCnfm";
            this.cbxRecvCnfm.Size = new System.Drawing.Size(14, 14);
            this.cbxRecvCnfm.TabIndex = 22;
            this.cbxRecvCnfm.CheckedChanged += new System.EventHandler(this.cbxRecvCnfm_CheckedChanged);
            // 
            // cbxRecvDel
            // 
            this.cbxRecvDel.Location = new System.Drawing.Point(62, 56);
            this.cbxRecvDel.Name = "cbxRecvDel";
            this.cbxRecvDel.Size = new System.Drawing.Size(14, 14);
            this.cbxRecvDel.TabIndex = 21;
            this.cbxRecvDel.CheckedChanged += new System.EventHandler(this.cbxRecvDel_CheckedChanged);
            // 
            // grdRecv
            // 
            this.grdRecv.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell21,
            this.xEditGridCell12,
            this.xEditGridCell26,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell10,
            this.xEditGridCell18,
            this.xEditGridCell8,
            this.xEditGridCell30,
            this.xEditGridCell28});
            this.grdRecv.ColPerLine = 10;
            this.grdRecv.Cols = 11;
            this.grdRecv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRecv.FixedCols = 1;
            this.grdRecv.FixedRows = 1;
            this.grdRecv.HeaderHeights.Add(32);
            this.grdRecv.Location = new System.Drawing.Point(0, 39);
            this.grdRecv.Name = "grdRecv";
            this.grdRecv.QuerySQL = resources.GetString("grdRecv.QuerySQL");
            this.grdRecv.RowHeaderVisible = true;
            this.grdRecv.Rows = 2;
            this.grdRecv.RowStateCheckOnPaint = false;
            this.grdRecv.Size = new System.Drawing.Size(756, 403);
            this.grdRecv.TabIndex = 5;
            this.grdRecv.ToolTipActive = true;
            this.grdRecv.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdRecv_ItemValueChanging);
            this.grdRecv.DoubleClick += new System.EventHandler(this.grdRecv_DoubleClick);
            this.grdRecv.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdRecv_QueryStarting);
            this.grdRecv.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdRecv_GridColumnProtectModify);
            this.grdRecv.GridContDisplayed += new IHIS.Framework.XGridContDisplayedEventHandler(this.grdRecv_GridContDisplayed);
            this.grdRecv.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdRecv_GridButtonClick);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "send_dt";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 73;
            this.xEditGridCell1.Col = 3;
            this.xEditGridCell1.HeaderText = "작성일";
            this.xEditGridCell1.IsReadOnly = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "sender_id";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "사번";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "send_seq";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "순번";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "recv_spot";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "recver_id";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "send_time";
            this.xEditGridCell26.CellWidth = 55;
            this.xEditGridCell26.Col = 4;
            this.xEditGridCell26.HeaderText = "작성시각";
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "msg_title";
            this.xEditGridCell4.CellWidth = 160;
            this.xEditGridCell4.Col = 7;
            this.xEditGridCell4.HeaderText = "제목";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdCol = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "msg_contents";
            this.xEditGridCell5.CellWidth = 35;
            this.xEditGridCell5.Col = 8;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell5.HeaderText = "내용";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdCol = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "send_spot_nm";
            this.xEditGridCell6.CellWidth = 98;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.HeaderText = "보낸곳";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdCol = false;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "sender_nm";
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.HeaderText = "작성자";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "recv_spot_nm";
            this.xEditGridCell10.CellWidth = 98;
            this.xEditGridCell10.Col = 9;
            this.xEditGridCell10.HeaderText = "받은곳";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "orig_cnfm_yn";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "cnfm_yn";
            this.xEditGridCell8.CellWidth = 28;
            this.xEditGridCell8.Col = 1;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell8.HeaderText = "확인";
            this.xEditGridCell8.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.ButtonText = "파일";
            this.xEditGridCell30.CellName = "file_atch_yn";
            this.xEditGridCell30.CellWidth = 52;
            this.xEditGridCell30.Col = 10;
            this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell30.HeaderText = "첨부";
            this.xEditGridCell30.InitValue = "N";
            this.xEditGridCell30.IsUpdCol = false;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "del_yn";
            this.xEditGridCell28.CellWidth = 28;
            this.xEditGridCell28.Col = 2;
            this.xEditGridCell28.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell28.HeaderText = "삭제";
            this.xEditGridCell28.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xEditGridCell28.InitValue = "N";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReply);
            this.groupBox1.Controls.Add(this.rbxRecvAll);
            this.groupBox1.Controls.Add(this.rbxRecvYes);
            this.groupBox1.Controls.Add(this.lbRecvQryDate);
            this.groupBox1.Controls.Add(this.btnRecvCnfm);
            this.groupBox1.Controls.Add(this.rbxRecvNo);
            this.groupBox1.Controls.Add(this.dtpRecvFrdt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpRecvTodt);
            this.groupBox1.Controls.Add(this.btnCloseRecv);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 39);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnReply
            // 
            this.btnReply.Image = ((System.Drawing.Image)(resources.GetObject("btnReply.Image")));
            this.btnReply.Location = new System.Drawing.Point(480, 10);
            this.btnReply.Name = "btnReply";
            this.btnReply.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnReply.Size = new System.Drawing.Size(66, 26);
            this.btnReply.TabIndex = 25;
            this.btnReply.Text = "답 장";
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // rbxRecvAll
            // 
            this.rbxRecvAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbxRecvAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(248)))), ((int)(((byte)(181)))));
            this.rbxRecvAll.Location = new System.Drawing.Point(412, 10);
            this.rbxRecvAll.Name = "rbxRecvAll";
            this.rbxRecvAll.Size = new System.Drawing.Size(66, 24);
            this.rbxRecvAll.TabIndex = 21;
            this.rbxRecvAll.Text = "전체조회";
            this.rbxRecvAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbxRecvAll.UseVisualStyleBackColor = false;
            this.rbxRecvAll.CheckedChanged += new System.EventHandler(this.rbxRecvAll_CheckedChanged);
            // 
            // rbxRecvYes
            // 
            this.rbxRecvYes.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbxRecvYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(248)))), ((int)(((byte)(181)))));
            this.rbxRecvYes.Location = new System.Drawing.Point(344, 10);
            this.rbxRecvYes.Name = "rbxRecvYes";
            this.rbxRecvYes.Size = new System.Drawing.Size(68, 24);
            this.rbxRecvYes.TabIndex = 20;
            this.rbxRecvYes.Text = "확인조회";
            this.rbxRecvYes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbxRecvYes.UseVisualStyleBackColor = false;
            this.rbxRecvYes.CheckedChanged += new System.EventHandler(this.rbxRecvYes_CheckedChanged);
            // 
            // lbRecvQryDate
            // 
            this.lbRecvQryDate.Location = new System.Drawing.Point(2, 12);
            this.lbRecvQryDate.Name = "lbRecvQryDate";
            this.lbRecvQryDate.Size = new System.Drawing.Size(58, 23);
            this.lbRecvQryDate.TabIndex = 19;
            this.lbRecvQryDate.Text = "조회일자";
            this.lbRecvQryDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRecvCnfm
            // 
            this.btnRecvCnfm.Image = ((System.Drawing.Image)(resources.GetObject("btnRecvCnfm.Image")));
            this.btnRecvCnfm.Location = new System.Drawing.Point(546, 10);
            this.btnRecvCnfm.Name = "btnRecvCnfm";
            this.btnRecvCnfm.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnRecvCnfm.Size = new System.Drawing.Size(140, 26);
            this.btnRecvCnfm.TabIndex = 13;
            this.btnRecvCnfm.Text = "메세지 확인(삭제)";
            this.btnRecvCnfm.Click += new System.EventHandler(this.btnRecvCnfm_Click);
            // 
            // rbxRecvNo
            // 
            this.rbxRecvNo.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbxRecvNo.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rbxRecvNo.Checked = true;
            this.rbxRecvNo.Location = new System.Drawing.Point(260, 10);
            this.rbxRecvNo.Name = "rbxRecvNo";
            this.rbxRecvNo.Size = new System.Drawing.Size(84, 24);
            this.rbxRecvNo.TabIndex = 0;
            this.rbxRecvNo.TabStop = true;
            this.rbxRecvNo.Text = "미확인조회";
            this.rbxRecvNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbxRecvNo.UseVisualStyleBackColor = false;
            this.rbxRecvNo.CheckedChanged += new System.EventHandler(this.rbxRecvNo_CheckedChanged);
            // 
            // dtpRecvFrdt
            // 
            this.dtpRecvFrdt.Location = new System.Drawing.Point(62, 12);
            this.dtpRecvFrdt.Name = "dtpRecvFrdt";
            this.dtpRecvFrdt.Size = new System.Drawing.Size(94, 20);
            this.dtpRecvFrdt.TabIndex = 0;
            this.dtpRecvFrdt.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpRecvFrdt_DataValidating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "~";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpRecvTodt
            // 
            this.dtpRecvTodt.Location = new System.Drawing.Point(166, 12);
            this.dtpRecvTodt.Name = "dtpRecvTodt";
            this.dtpRecvTodt.Size = new System.Drawing.Size(92, 20);
            this.dtpRecvTodt.TabIndex = 1;
            this.dtpRecvTodt.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpRecvTodt_DataValidating);
            // 
            // btnCloseRecv
            // 
            this.btnCloseRecv.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseRecv.Image")));
            this.btnCloseRecv.Location = new System.Drawing.Point(686, 10);
            this.btnCloseRecv.Name = "btnCloseRecv";
            this.btnCloseRecv.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnCloseRecv.Size = new System.Drawing.Size(66, 26);
            this.btnCloseRecv.TabIndex = 24;
            this.btnCloseRecv.Text = "닫 기";
            this.btnCloseRecv.Click += new System.EventHandler(this.btnCloseRecv_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.tabPage2.Controls.Add(this.gbxSendMsgList);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(756, 442);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "메세지 보내기";
            // 
            // gbxSendMsgList
            // 
            this.gbxSendMsgList.Controls.Add(this.cbxSendCnfm);
            this.gbxSendMsgList.Controls.Add(this.cbxSendDel);
            this.gbxSendMsgList.Controls.Add(this.grdSend);
            this.gbxSendMsgList.Controls.Add(this.panel2);
            this.gbxSendMsgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxSendMsgList.Location = new System.Drawing.Point(0, 247);
            this.gbxSendMsgList.Name = "gbxSendMsgList";
            this.gbxSendMsgList.Size = new System.Drawing.Size(756, 195);
            this.gbxSendMsgList.TabIndex = 3;
            this.gbxSendMsgList.TabStop = false;
            this.gbxSendMsgList.Text = "보낸 메세지 목록";
            // 
            // cbxSendDel
            // 
            this.cbxSendDel.Location = new System.Drawing.Point(65, 34);
            this.cbxSendDel.Name = "cbxSendDel";
            this.cbxSendDel.Size = new System.Drawing.Size(14, 14);
            this.cbxSendDel.TabIndex = 20;
            this.cbxSendDel.CheckedChanged += new System.EventHandler(this.cbxSendDel_CheckedChanged);
            // 
            // cbxSendCnfm
            // 
            this.cbxSendCnfm.Location = new System.Drawing.Point(36, 34);
            this.cbxSendCnfm.Name = "cbxSendCnfm";
            this.cbxSendCnfm.Size = new System.Drawing.Size(14, 14);
            this.cbxSendCnfm.TabIndex = 23;
            this.cbxSendCnfm.CheckedChanged += new System.EventHandler(this.cbxSendCnfm_CheckedChanged);
            // 
            // grdSend
            // 
            this.grdSend.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell11,
            this.xEditGridCell17,
            this.xEditGridCell13,
            this.xEditGridCell27,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell20,
            this.xEditGridCell23,
            this.xEditGridCell9,
            this.xEditGridCell31,
            this.xEditGridCell29});
            this.grdSend.ColPerLine = 8;
            this.grdSend.Cols = 9;
            this.grdSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSend.FixedCols = 1;
            this.grdSend.FixedRows = 1;
            this.grdSend.HeaderHeights.Add(33);
            this.grdSend.Location = new System.Drawing.Point(3, 16);
            this.grdSend.Name = "grdSend";
            this.grdSend.QuerySQL = resources.GetString("grdSend.QuerySQL");
            this.grdSend.RowHeaderVisible = true;
            this.grdSend.Rows = 2;
            this.grdSend.RowStateCheckOnPaint = false;
            this.grdSend.Size = new System.Drawing.Size(526, 176);
            this.grdSend.TabIndex = 5;
            this.grdSend.ToolTipActive = true;
            this.grdSend.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdSend_ItemValueChanging);
            this.grdSend.DoubleClick += new System.EventHandler(this.grdSend_DoubleClick);
            this.grdSend.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSend_QueryStarting);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "send_dt";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.CellWidth = 72;
            this.xEditGridCell11.Col = 3;
            this.xEditGridCell11.HeaderText = "작성일";
            this.xEditGridCell11.IsReadOnly = true;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "sender_id";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "send_seq";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "순번";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "send_time";
            this.xEditGridCell27.CellWidth = 59;
            this.xEditGridCell27.Col = 4;
            this.xEditGridCell27.HeaderText = "작성시각";
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "msg_title";
            this.xEditGridCell14.CellWidth = 155;
            this.xEditGridCell14.Col = 5;
            this.xEditGridCell14.HeaderText = "제목";
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdCol = false;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "msg_contents";
            this.xEditGridCell15.CellWidth = 48;
            this.xEditGridCell15.Col = 6;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell15.HeaderText = "내용";
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdCol = false;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "send_all_cnfm_yn";
            this.xEditGridCell16.CellWidth = 30;
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderText = "전체\r\n확인";
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "recv_cnt";
            this.xEditGridCell20.CellWidth = 47;
            this.xEditGridCell20.Col = 7;
            this.xEditGridCell20.HeaderText = "수신\r\n자수";
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.IsUpdCol = false;
            this.xEditGridCell20.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "orig_cnfm_yn";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "cnfm_yn";
            this.xEditGridCell9.CellWidth = 30;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell9.HeaderText = "확인";
            this.xEditGridCell9.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "file_atch_yn";
            this.xEditGridCell31.CellWidth = 37;
            this.xEditGridCell31.Col = 8;
            this.xEditGridCell31.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell31.HeaderText = "파일\r\n첨부";
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.IsUpdCol = false;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "del_yn";
            this.xEditGridCell29.CellWidth = 28;
            this.xEditGridCell29.Col = 2;
            this.xEditGridCell29.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell29.HeaderText = "삭제";
            this.xEditGridCell29.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xEditGridCell29.InitValue = "N";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpSendFrDt);
            this.panel2.Controls.Add(this.dtpSendToDt);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.btnDeleteSend);
            this.panel2.Controls.Add(this.btnSendDetail);
            this.panel2.Controls.Add(this.lbSendQryDate);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnCloseSend);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(529, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 176);
            this.panel2.TabIndex = 19;
            // 
            // dtpSendFrDt
            // 
            this.dtpSendFrDt.Location = new System.Drawing.Point(8, 20);
            this.dtpSendFrDt.Name = "dtpSendFrDt";
            this.dtpSendFrDt.Size = new System.Drawing.Size(96, 20);
            this.dtpSendFrDt.TabIndex = 20;
            // 
            // dtpSendToDt
            // 
            this.dtpSendToDt.Location = new System.Drawing.Point(116, 20);
            this.dtpSendToDt.Name = "dtpSendToDt";
            this.dtpSendToDt.Size = new System.Drawing.Size(96, 20);
            this.dtpSendToDt.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbxSendAll);
            this.groupBox2.Controls.Add(this.rbxSendYes);
            this.groupBox2.Controls.Add(this.rbxSendNo);
            this.groupBox2.Location = new System.Drawing.Point(2, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 34);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            // 
            // rbxSendAll
            // 
            this.rbxSendAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbxSendAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(248)))), ((int)(((byte)(181)))));
            this.rbxSendAll.Location = new System.Drawing.Point(152, 8);
            this.rbxSendAll.Name = "rbxSendAll";
            this.rbxSendAll.Size = new System.Drawing.Size(66, 24);
            this.rbxSendAll.TabIndex = 23;
            this.rbxSendAll.Text = "전체조회";
            this.rbxSendAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbxSendAll.UseVisualStyleBackColor = false;
            this.rbxSendAll.CheckedChanged += new System.EventHandler(this.rbxSendAll_CheckedChanged);
            // 
            // rbxSendYes
            // 
            this.rbxSendYes.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbxSendYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(248)))), ((int)(((byte)(181)))));
            this.rbxSendYes.Location = new System.Drawing.Point(84, 8);
            this.rbxSendYes.Name = "rbxSendYes";
            this.rbxSendYes.Size = new System.Drawing.Size(68, 24);
            this.rbxSendYes.TabIndex = 22;
            this.rbxSendYes.Text = "확인조회";
            this.rbxSendYes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbxSendYes.UseVisualStyleBackColor = false;
            this.rbxSendYes.CheckedChanged += new System.EventHandler(this.rbxSendYes_CheckedChanged);
            // 
            // rbxSendNo
            // 
            this.rbxSendNo.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbxSendNo.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rbxSendNo.Checked = true;
            this.rbxSendNo.Location = new System.Drawing.Point(0, 8);
            this.rbxSendNo.Name = "rbxSendNo";
            this.rbxSendNo.Size = new System.Drawing.Size(84, 24);
            this.rbxSendNo.TabIndex = 21;
            this.rbxSendNo.TabStop = true;
            this.rbxSendNo.Text = "미확인조회";
            this.rbxSendNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbxSendNo.UseVisualStyleBackColor = false;
            this.rbxSendNo.CheckedChanged += new System.EventHandler(this.rbxSendNo_CheckedChanged);
            // 
            // btnDeleteSend
            // 
            this.btnDeleteSend.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteSend.Image")));
            this.btnDeleteSend.Location = new System.Drawing.Point(6, 130);
            this.btnDeleteSend.Name = "btnDeleteSend";
            this.btnDeleteSend.Size = new System.Drawing.Size(148, 26);
            this.btnDeleteSend.TabIndex = 25;
            this.btnDeleteSend.Text = "메세지 확인(삭제)";
            this.btnDeleteSend.Click += new System.EventHandler(this.btnDeleteSend_Click);
            // 
            // btnSendDetail
            // 
            this.btnSendDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnSendDetail.Image")));
            this.btnSendDetail.Location = new System.Drawing.Point(6, 104);
            this.btnSendDetail.Name = "btnSendDetail";
            this.btnSendDetail.Size = new System.Drawing.Size(148, 26);
            this.btnSendDetail.TabIndex = 24;
            this.btnSendDetail.Text = "송신메세지상세조회";
            this.btnSendDetail.Click += new System.EventHandler(this.btnSendDetail_Click);
            // 
            // lbSendQryDate
            // 
            this.lbSendQryDate.Location = new System.Drawing.Point(8, 4);
            this.lbSendQryDate.Name = "lbSendQryDate";
            this.lbSendQryDate.Size = new System.Drawing.Size(64, 18);
            this.lbSendQryDate.TabIndex = 23;
            this.lbSendQryDate.Text = "조회일자";
            this.lbSendQryDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(106, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "~";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCloseSend
            // 
            this.btnCloseSend.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseSend.Image")));
            this.btnCloseSend.Location = new System.Drawing.Point(156, 104);
            this.btnCloseSend.Name = "btnCloseSend";
            this.btnCloseSend.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnCloseSend.Size = new System.Drawing.Size(66, 52);
            this.btnCloseSend.TabIndex = 18;
            this.btnCloseSend.Text = "닫 기";
            this.btnCloseSend.Click += new System.EventHandler(this.btnCloseSend_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gbxWriteMsg);
            this.panel3.Controls.Add(this.gbxResvMemo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(756, 247);
            this.panel3.TabIndex = 2;
            // 
            // gbxWriteMsg
            // 
            this.gbxWriteMsg.Controls.Add(this.panel9);
            this.gbxWriteMsg.Controls.Add(this.panel8);
            this.gbxWriteMsg.Controls.Add(this.panel7);
            this.gbxWriteMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxWriteMsg.Location = new System.Drawing.Point(260, 0);
            this.gbxWriteMsg.Name = "gbxWriteMsg";
            this.gbxWriteMsg.Size = new System.Drawing.Size(496, 247);
            this.gbxWriteMsg.TabIndex = 2;
            this.gbxWriteMsg.TabStop = false;
            this.gbxWriteMsg.Text = "글쓰기";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnAddFile);
            this.panel9.Controls.Add(this.txtSendMsg);
            this.panel9.Controls.Add(this.lbMsgContents);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(3, 94);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(490, 150);
            this.panel9.TabIndex = 3;
            // 
            // btnAddFile
            // 
            this.btnAddFile.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFile.Image")));
            this.btnAddFile.Location = new System.Drawing.Point(6, 94);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(64, 44);
            this.btnAddFile.TabIndex = 18;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtSendMsg.Location = new System.Drawing.Point(74, 2);
            this.txtSendMsg.MaxLength = 1500;
            this.txtSendMsg.Multiline = true;
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSendMsg.Size = new System.Drawing.Size(412, 145);
            this.txtSendMsg.TabIndex = 13;
            // 
            // lbMsgContents
            // 
            this.lbMsgContents.Location = new System.Drawing.Point(5, 4);
            this.lbMsgContents.Name = "lbMsgContents";
            this.lbMsgContents.Size = new System.Drawing.Size(68, 102);
            this.lbMsgContents.TabIndex = 12;
            this.lbMsgContents.Text = "내   용";
            this.lbMsgContents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtSendTitle);
            this.panel8.Controls.Add(this.lbMsgTitle);
            this.panel8.Controls.Add(this.btnSearch);
            this.panel8.Controls.Add(this.lbRecver);
            this.panel8.Controls.Add(this.txtRecvSpot);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 42);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(490, 52);
            this.panel8.TabIndex = 2;
            // 
            // txtSendTitle
            // 
            this.txtSendTitle.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtSendTitle.Location = new System.Drawing.Point(75, 27);
            this.txtSendTitle.MaxLength = 50;
            this.txtSendTitle.Name = "txtSendTitle";
            this.txtSendTitle.Size = new System.Drawing.Size(411, 20);
            this.txtSendTitle.TabIndex = 11;
            // 
            // lbMsgTitle
            // 
            this.lbMsgTitle.Location = new System.Drawing.Point(5, 29);
            this.lbMsgTitle.Name = "lbMsgTitle";
            this.lbMsgTitle.Size = new System.Drawing.Size(68, 17);
            this.lbMsgTitle.TabIndex = 10;
            this.lbMsgTitle.Text = "제   목";
            this.lbMsgTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(459, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnSearch.Size = new System.Drawing.Size(28, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "수신자 지정";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbRecver
            // 
            this.lbRecver.Location = new System.Drawing.Point(5, 6);
            this.lbRecver.Name = "lbRecver";
            this.lbRecver.Size = new System.Drawing.Size(68, 17);
            this.lbRecver.TabIndex = 7;
            this.lbRecver.Text = "수신자";
            this.lbRecver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRecvSpot
            // 
            this.txtRecvSpot.Location = new System.Drawing.Point(75, 4);
            this.txtRecvSpot.Name = "txtRecvSpot";
            this.txtRecvSpot.ReadOnly = true;
            this.txtRecvSpot.Size = new System.Drawing.Size(383, 20);
            this.txtRecvSpot.TabIndex = 8;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cbxSendAllCnfm);
            this.panel7.Controls.Add(this.btnClear);
            this.panel7.Controls.Add(this.btnSend);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 16);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(490, 26);
            this.panel7.TabIndex = 1;
            // 
            // cbxSendAllCnfm
            // 
            this.cbxSendAllCnfm.Location = new System.Drawing.Point(0, 2);
            this.cbxSendAllCnfm.Name = "cbxSendAllCnfm";
            this.cbxSendAllCnfm.Size = new System.Drawing.Size(92, 24);
            this.cbxSendAllCnfm.TabIndex = 18;
            this.cbxSendAllCnfm.Text = "전체확인";
            this.cbxSendAllCnfm.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(306, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 26);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "초기화";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSend
            // 
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(390, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnSend.Size = new System.Drawing.Size(96, 26);
            this.btnSend.TabIndex = 16;
            this.btnSend.Text = "송  신";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // gbxResvMemo
            // 
            this.gbxResvMemo.Controls.Add(this.grdResv);
            this.gbxResvMemo.Controls.Add(this.panel1);
            this.gbxResvMemo.Controls.Add(this.panel4);
            this.gbxResvMemo.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbxResvMemo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gbxResvMemo.Location = new System.Drawing.Point(0, 0);
            this.gbxResvMemo.Name = "gbxResvMemo";
            this.gbxResvMemo.Size = new System.Drawing.Size(260, 247);
            this.gbxResvMemo.TabIndex = 0;
            this.gbxResvMemo.TabStop = false;
            this.gbxResvMemo.Text = "예약글";
            // 
            // grdResv
            // 
            this.grdResv.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell19,
            this.xEditGridCell24,
            this.xEditGridCell22,
            this.xEditGridCell25});
            this.grdResv.ColPerLine = 2;
            this.grdResv.Cols = 2;
            this.grdResv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResv.FixedRows = 1;
            this.grdResv.HeaderHeights.Add(23);
            this.grdResv.Location = new System.Drawing.Point(3, 43);
            this.grdResv.Name = "grdResv";
            this.grdResv.QuerySQL = resources.GetString("grdResv.QuerySQL");
            this.grdResv.Rows = 2;
            this.grdResv.RowStateCheckOnPaint = false;
            this.grdResv.Size = new System.Drawing.Size(254, 101);
            this.grdResv.TabIndex = 1;
            this.grdResv.ToolTipActive = true;
            this.grdResv.DoubleClick += new System.EventHandler(this.grdResv_DoubleClick);
            this.grdResv.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdResv_QueryStarting);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "user_id";
            this.xEditGridCell19.CellWidth = 31;
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.HeaderText = "사용자";
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "seq";
            this.xEditGridCell24.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell24.CellWidth = 31;
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.HeaderText = "순번";
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "msg_title";
            this.xEditGridCell22.CellWidth = 162;
            this.xEditGridCell22.HeaderText = "제  목";
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdCol = false;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "msg_contents";
            this.xEditGridCell25.CellWidth = 67;
            this.xEditGridCell25.Col = 1;
            this.xEditGridCell25.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell25.HeaderText = "예약글";
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdCol = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtResvMsg);
            this.panel1.Controls.Add(this.txtResvTitle);
            this.panel1.Controls.Add(this.lbResvMsgTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 100);
            this.panel1.TabIndex = 13;
            // 
            // txtResvMsg
            // 
            this.txtResvMsg.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtResvMsg.Location = new System.Drawing.Point(4, 27);
            this.txtResvMsg.MaxLength = 1500;
            this.txtResvMsg.Multiline = true;
            this.txtResvMsg.Name = "txtResvMsg";
            this.txtResvMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResvMsg.Size = new System.Drawing.Size(246, 68);
            this.txtResvMsg.TabIndex = 12;
            // 
            // txtResvTitle
            // 
            this.txtResvTitle.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtResvTitle.Location = new System.Drawing.Point(56, 4);
            this.txtResvTitle.MaxLength = 20;
            this.txtResvTitle.Name = "txtResvTitle";
            this.txtResvTitle.Size = new System.Drawing.Size(192, 20);
            this.txtResvTitle.TabIndex = 2;
            // 
            // lbResvMsgTitle
            // 
            this.lbResvMsgTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbResvMsgTitle.Location = new System.Drawing.Point(4, 6);
            this.lbResvMsgTitle.Name = "lbResvMsgTitle";
            this.lbResvMsgTitle.Size = new System.Drawing.Size(52, 17);
            this.lbResvMsgTitle.TabIndex = 11;
            this.lbResvMsgTitle.Text = "제 목";
            this.lbResvMsgTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnResvCopy);
            this.panel4.Controls.Add(this.btnResvAdd);
            this.panel4.Controls.Add(this.btnResvDelete);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel4.Location = new System.Drawing.Point(3, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(254, 27);
            this.panel4.TabIndex = 0;
            // 
            // btnResvCopy
            // 
            this.btnResvCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnResvCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnResvCopy.Image")));
            this.btnResvCopy.Location = new System.Drawing.Point(132, 2);
            this.btnResvCopy.Name = "btnResvCopy";
            this.btnResvCopy.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnResvCopy.Size = new System.Drawing.Size(100, 26);
            this.btnResvCopy.TabIndex = 19;
            this.btnResvCopy.Text = "예약글복사";
            this.btnResvCopy.Click += new System.EventHandler(this.btnResvCopy_Click);
            // 
            // btnResvAdd
            // 
            this.btnResvAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnResvAdd.Image")));
            this.btnResvAdd.Location = new System.Drawing.Point(68, 2);
            this.btnResvAdd.Name = "btnResvAdd";
            this.btnResvAdd.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnResvAdd.Size = new System.Drawing.Size(62, 26);
            this.btnResvAdd.TabIndex = 17;
            this.btnResvAdd.Text = "추 가";
            this.btnResvAdd.Click += new System.EventHandler(this.btnResvAdd_Click);
            // 
            // btnResvDelete
            // 
            this.btnResvDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnResvDelete.Image")));
            this.btnResvDelete.Location = new System.Drawing.Point(4, 2);
            this.btnResvDelete.Name = "btnResvDelete";
            this.btnResvDelete.Size = new System.Drawing.Size(62, 26);
            this.btnResvDelete.TabIndex = 16;
            this.btnResvDelete.Text = "삭 제";
            this.btnResvDelete.Click += new System.EventHandler(this.btnResvDelete_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // cbxRecvDeny
            // 
            this.cbxRecvDeny.Location = new System.Drawing.Point(236, 4);
            this.cbxRecvDeny.Name = "cbxRecvDeny";
            this.cbxRecvDeny.Size = new System.Drawing.Size(82, 20);
            this.cbxRecvDeny.TabIndex = 3;
            this.cbxRecvDeny.Text = "수신 보류";
            this.toolTip1.SetToolTip(this.cbxRecvDeny, "메세지를 받을때 메세지 수신창을 띄우지 않습니다.");
            this.cbxRecvDeny.CheckedChanged += new System.EventHandler(this.cbxRecvDeny_CheckedChanged);
            // 
            // cbxAlarm
            // 
            this.cbxAlarm.Checked = true;
            this.cbxAlarm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAlarm.Location = new System.Drawing.Point(332, 4);
            this.cbxAlarm.Name = "cbxAlarm";
            this.cbxAlarm.Size = new System.Drawing.Size(116, 20);
            this.cbxAlarm.TabIndex = 4;
            this.cbxAlarm.Text = "수신시 알람";
            this.toolTip1.SetToolTip(this.cbxAlarm, "메세지를 받을때 알람을 울립니다.");
            this.cbxAlarm.CheckedChanged += new System.EventHandler(this.cbxAlarm_CheckedChanged);
            // 
            // btnMySound
            // 
            this.btnMySound.Image = ((System.Drawing.Image)(resources.GetObject("btnMySound.Image")));
            this.btnMySound.Location = new System.Drawing.Point(498, 2);
            this.btnMySound.Name = "btnMySound";
            this.btnMySound.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnMySound.Size = new System.Drawing.Size(144, 24);
            this.btnMySound.TabIndex = 5;
            this.btnMySound.Text = "알람 사운드 지정";
            this.toolTip1.SetToolTip(this.btnMySound, "메세지를 받을때 울릴 알람 사운드를 지정합니다.");
            this.btnMySound.Click += new System.EventHandler(this.btnMySound_Click);
            // 
            // btnUserChange
            // 
            this.btnUserChange.Image = ((System.Drawing.Image)(resources.GetObject("btnUserChange.Image")));
            this.btnUserChange.Location = new System.Drawing.Point(646, 2);
            this.btnUserChange.Name = "btnUserChange";
            this.btnUserChange.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnUserChange.Size = new System.Drawing.Size(108, 24);
            this.btnUserChange.TabIndex = 6;
            this.btnUserChange.Text = "사용자 변경";
            this.toolTip1.SetToolTip(this.btnUserChange, "메세지를 받을때 울릴 알람 사운드를 지정합니다.");
            this.btnUserChange.Click += new System.EventHandler(this.btnUserChange_Click);
            // 
            // layRecverList
            // 
            this.layRecverList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14});
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "user_id";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "msg_title";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "msg_contents";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "send_all_cnfm_yn";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "file_atch_yn";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "recver_gubun";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "recver_id";
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenu = this.ctxMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "IHIS Message System";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // layFileList
            // 
            this.layFileList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem2,
            this.multiLayoutItem3});
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "file_nm";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "uni_file_nm";
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(764, 475);
            this.ControlBox = false;
            this.Controls.Add(this.btnUserChange);
            this.Controls.Add(this.btnMySound);
            this.Controls.Add(this.cbxAlarm);
            this.Controls.Add(this.cbxRecvDeny);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "メッセージシステム";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRecv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.gbxSendMsgList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSend)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.gbxWriteMsg.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.gbxResvMemo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layRecverList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layFileList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Dipose
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
		#endregion

		#region Main
		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main(string[] args) 
		{
			string groupID = "";
			string groupName = "";
			string systemID = "";
			string systemName = "";
			string userID = "";

			if (args.Length == 5)
			{
				try
				{
					groupID		= args[0];
					groupName	= args[1];
					systemID	= args[2];
					systemName	= args[3];
					userID      = args[4];
				}
				catch
				{
					return;
				}

                //// Service Session 설정 및 기본 IO Object Set
                //Service.DefaultSession.DefaultInput = new ServiceInput();
                //Service.DefaultSession.DefaultOutput = new ServiceOutput();
			
				// 시스템 예외 처리 핸들러 생성
				SystemExceptionHandler sh = new SystemExceptionHandler();
				// Thread Exception 발생시 시스템 예외 처리 Event 구동
				Application.ThreadException += new ThreadExceptionEventHandler(sh.OnThreadException);

				Application.Run(new MainForm(groupID, groupName, systemID, systemName));
			}
			else
			{
				string msg = (NetInfo.Language == LangMode.Ko ? "해당 시스템은 단독으로 실행할 수 없습니다."
					: "当該システムは単独では実行できません。");
				XMessageBox.Show(msg);
			}
		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			//최초 Load시에 Form 잔상 생기지 않게 하기위해 Screen 영역 밖으로 Location 설정
			this.Location = new Point(0 - this.Width, 0 - this.Height);

			//선택창에 Mdi의 Handle을 보내 Handle을 관리하게 함
			//시스템명은 wParam에 WindowHandle은 LParam으로 보냄
			IntPtr IHISHandle = EnvironInfo.FindIHISHandle();
			IntPtr wParam = Marshal.StringToHGlobalAnsi(this.systemID);
			if (IHISHandle != IntPtr.Zero)
				User32.SendMessage(IHISHandle, MSG_SYSTEM_WINDOW_HANDLE_SEND, wParam, this.Handle);

			//From일자는 To일자의 하루전일로 설정
			//this.dtpRecvFrdt.Value = this.dtpRecvTodt.Value.AddDays(-1);
			//this.dtpSendFrDt.Value = this.dtpSendToDt.Value.AddDays(-1);

            // Service Conncect
            Service.Connect();

			//수신보류, 알람, 사운드파일 Registry에서 읽어서 SET
			this.cbxRecvDeny.Checked = (GetRegistryValue(RKEY_MSG_RECV_DENY, "N") == "Y" ? true : false);
			this.cbxAlarm.Checked = (GetRegistryValue(RKEY_MSG_RECV_ALARM, "Y") == "Y" ? true : false);
			this.soundFileName = GetRegistryValue(RKEY_MSG_SOUND_FILE, "");

			//2005.06.29 첨부파일 서버 정보 조회
			this.GetFileServerInfo();

			IHIS.Framework.PostCallHelper.PostCall(new PostMethod(SystemHide));

		}
		protected override bool ProcessDialogKey(Keys keyData)
		{
			
			//Alt F4를 눌러 Window를 닫는 것을 방지(처리하지 않으면 Alt F4일때 Window 닫힘)
			if ((keyData & Keys.Alt) == Keys.Alt)
			{
				Keys keyCode = (Keys)(((int)keyData << 16) >> 16);		// Modifier Clear
				if (keyCode == Keys.F4)
					return true;  //Alt F4로 Window 닫지 못하게 함
			}
			return base.ProcessDialogKey(keyData);
		}
		#endregion

		#region SystemHide
		private void SystemHide()
		{
			this.Hide();
		}
		#endregion

		#region Methods
		//수신 메세시 리스트 가져오기
		private void GetReceiveMsgList()
		{
			string msg = "";
			//일자 From, To Check
			if (dtpRecvFrdt.GetDataValue().CompareTo(dtpRecvTodt.GetDataValue()) > 0)
			{
				msg = (NetInfo.Language == LangMode.Ko ? "조회시작일이 잘못 입력되었습니다."
					: "照会開始日が有効ではありません。");
				XMessageBox.Show(msg);
				dtpRecvFrdt.Focus();
				return;
			}

            if (this.grdRecv.QueryLayout(false))
            {
                //file_atch_yn(첨부여부:Y/N)에 따라 첨부버튼 활성화 비활성화 처리
                ChangeGridButtonEnable(0, grdRecv.RowCount);
            }
            else
            {
                msg = (NetInfo.Language == LangMode.Ko ? "수신내역 조회에러[" + Service.ErrFullMsg + "]"
                    : "受信内訳の照会エラー[" + Service.ErrFullMsg + "]");
                XMessageBox.Show(msg);
            }
            
		}

		private void ChangeGridButtonEnable(int startRow, int endRow)
		{
			//file_atch_yn(첨부여부:Y/N)에 따라 첨부버튼 활성화 비활성화 처리
			try
			{
				string attachYn = "N";
				for (int i = startRow ; i < endRow ; i++)
				{
					attachYn = grdRecv.GetItemString(i, "file_atch_yn");
					if (attachYn == "N")
						grdRecv.ChangeButtonEnable("file_atch_yn", i, false);
				}
			}
			catch{}
		}
		//전송메세지리스트 가져오기
		private void GetSendMsgList()
		{
			string msg = "";
			//일자 From, To Check
			if (dtpSendFrDt.GetDataValue().CompareTo(dtpSendToDt.GetDataValue()) > 0)
			{
				msg = (NetInfo.Language == LangMode.Ko ? "조회시작일이 잘못 입력되었습니다."
					: "照会開始日が有効ではありません。");
				XMessageBox.Show(msg);
				dtpSendFrDt.Focus();
				return;
			}

            if (this.grdSend.QueryLayout(false) == false)
            {
                msg = "送信内訳の照会エラー[" + Service.ErrFullMsg + "]";
                XMessageBox.Show(msg);
            }
		}
		//메세지수신 세부내역 가져오기(송신내역 상세정보)
		private void GetDetailReceiveMsgList()
		{
			int rowNum = grdSend.CurrentRowNumber;
			if (rowNum < 0)
			{
				string msg = (NetInfo.Language == LangMode.Ko ? "상세내역을 조회할 전송내역을 선택하십시오"
					: "詳細内訳を照会する転送内訳を選択してください。");
				XMessageBox.Show(msg);
				return;
			}
			string sendDt   = grdSend.GetItemString(rowNum, "send_dt");
			string senderID = grdSend.GetItemString(rowNum, "sender_id");
			string sendSeq  = grdSend.GetItemString(rowNum, "send_seq");
			DetailRecvListForm dlg = new DetailRecvListForm(this, sendDt, senderID, sendSeq);
			dlg.ShowDialog();
			dlg.Dispose();
		}
		//예약글 내역 가져오기
		private void GetReservedMsgList()
		{
            if (this.grdResv.QueryLayout(false) == false)
            {
                string msg = "予約文字の内訳の照会エラー[" + Service.ErrFullMsg + "]";
                XMessageBox.Show(msg);
            }
		}
		private void ChangeSystemUser(string sysID, string afUserID, string afUserName)
		{
			try
			{
				UserItem changeItem = null;
				foreach (UserItem item in MainForm.UserItemList)
				{
					if (item.SystemID == sysID)
					{
						changeItem = item;
						break;
					}
				}
				if (changeItem == null) return;

				//changeItem의 UserID, UserName 변경
				changeItem.UserID = afUserID;
				changeItem.UserName = afUserName;
			}
			catch{}
		}
		
		//PopupForm에서 메세지확인하기를 누를때 Call
		internal void ShowAndSelectRecvList(string userID)
		{
			//메세지수신창에서 수신할 UserID를 보내면 수신자리스트에 있는지 확인후에 미수신내역 조회해 주기
			//PopupForm에서 메세지확인하기하면 발생함
			//Show (menuShow_Click에서 사용자리스트 Check하지 않음
			//현재환자 SET
			bool isUserChanged = true; //사용자 변경여부
			if (MainForm.CurrUserID == userID)
				isUserChanged = false;

			MainForm.CurrUserID = userID;
			this.isCheckUserList = false;
			this.menuShow_Click(this, EventArgs.Empty);

			//조회일 Default로 SET
			SetDefaultQryDate();
			//수신메세지 Select
			this.tabControl1.SelectedIndex = 0;
			if (!this.rbxRecvNo.Checked)
				this.rbxRecvNo.Checked = true; //CheckedChanged에서 미수신건 조회
			else //이미 Check되어 있으면 조회
				this.GetReceiveMsgList();
			//Flag 복구
			this.isCheckUserList = true;

			//사용자가 바뀌었으면 해당사용자의 전송내역,예약글내역 조회
			if (isUserChanged)
			{
				this.GetSendMsgList();
				this.GetReservedMsgList();
				//보내는 메세지 초기화
				this.btnClear.PerformClick();
				//예약글 입력 Control 초기화
				this.txtResvTitle.Text = "";
				this.txtResvMsg.Text = "";
			}

            this.Show();
            this.Activate();
		}
		private void PopUpAllim(string userID, string userName)
		{
            string msg = "";
			//현재 사용자 ID Set
			MainForm.CurrUserID = userID;

			//조회일 Default로 SET
			SetDefaultQryDate();

			//미확인수신건수 조회
            object count = null;
            string cmd = @"SELECT COUNT(1) 
                             FROM ADM0710             A                                   -- 메세지 수신내역
                            WHERE A.HOSP_CODE         = :f_hosp_code 
                              AND A.SEND_DT           BETWEEN TO_DATE(:f_frdt, 'YYYY/MM/DD')
                                                          AND TO_DATE(:f_todt, 'YYYY/MM/DD') 
                              AND A.RECVER_ID         = :f_user_id
                              --
                              AND NVL(A.VALID_YN,'N') = 'Y'
                              AND NVL(A.CNFM_YN,'N')  = 'N'
                          ";

            BindVarCollection bindVar = new BindVarCollection();

            bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVar.Add("f_frdt", this.dtpRecvFrdt.GetDataValue());
            bindVar.Add("f_todt", this.dtpRecvTodt.GetDataValue());
            bindVar.Add("f_user_id", MainForm.currUserID);

            count = Service.ExecuteScalar(cmd, bindVar);

            if (count != null)
            {
                if (TypeCheck.IsInt(count.ToString()))
                {
                    int cnt = int.Parse(count.ToString());

                    if (cnt > 0)
                    {
                        msg = "\r\n" + userName + "様の未確認のメッセージ " + cnt.ToString() + " 件\n\n" + "確認してください";
                        AllimForm dlg = new AllimForm(this, userID, msg);
                        dlg.Owner = this;
                        dlg.Show();
                    }
                }
            }
		}
		private void SetDefaultQryDate()
        {
            this.dtpRecvTodt.DataValidating -= new IHIS.Framework.DataValidatingEventHandler(this.dtpRecvTodt_DataValidating);
            this.dtpRecvFrdt.DataValidating -= new IHIS.Framework.DataValidatingEventHandler(this.dtpRecvFrdt_DataValidating);

			this.dtpRecvTodt.SetDataValue(DateTime.Today);
			this.dtpSendToDt.SetDataValue(DateTime.Today);
			this.dtpRecvFrdt.SetDataValue(DateTime.Today.AddDays(-2));
            this.dtpSendFrDt.SetDataValue(DateTime.Today.AddDays(-2));

            this.dtpRecvTodt.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpRecvTodt_DataValidating);
            this.dtpRecvFrdt.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpRecvFrdt_DataValidating);
		}
		#endregion

		#region WndProc
		protected override void WndProc(ref Message m)
		{

			// UdpMsg를 받아 System의 MainHandle로 WM_COPYDATA를 통해 데이타 전송하는 경우
			if (m.Msg == (int) Win32.Msgs.WM_COPYDATA)
			{
				try	
				{
					//LParam에 전달된 데이타를 COPYDATASTRUCT로 변환
					Win32.COPYDATASTRUCT st = (Win32.COPYDATASTRUCT)Marshal.PtrToStructure(m.LParam, typeof(Win32.COPYDATASTRUCT));
					//Win2000이상 UniCode, Win98 : Ansi (현재시스템 설정)
					//UpdMessage 전체가 string으로 변환되어 COPY됨
					string recvData = Marshal.PtrToStringAuto(st.lpData);
					byte[] recvBytes = Service.JpEncoding.GetBytes(recvData);
					//UdpMessage 생성
					UdpMessage udpMsg = UdpMessage.FromReceivedMessage(recvBytes);
					switch (udpMsg.MsgType)
					{
						case UdpMsgType.SMG:
                            //메세지에 송신자명@송신자ID@수신자명@수신자ID@TITLE@메세지
							string[] msgInfos = udpMsg.Message.Split(new char[]{'@'});
							if (msgInfos.Length >= 6)
							{
								//수신자가 UserItemList에 있는지 여부 확인
								bool isFound = false;
								foreach (UserItem item in MainForm.UserItemList)
								{
									if (item.UserID == msgInfos[3])
									{
										isFound = true;
										break;
									}
								}
								//2005.06.21 수신보류 Check시는 창 띄우지 않음
								if (isFound && !this.cbxRecvDeny.Checked)
								{
									//Popup창 Show (위치조정은 Popup창의 OnLoad에서 처리함)
									PopupForm dlg = new PopupForm(this, msgInfos);
									dlg.Owner = this;
									dlg.Show();
									//2005.06.21 Alram 기능 추가
									if (this.cbxAlarm.Checked)
									{
										try
										{
											//파일이 있으면 파일 Play
											if (this.soundFileName != "")
												Kernel32.PlaySound(this.soundFileName, IntPtr.Zero, Win32.SoundFlags.SND_FILENAME | Win32.SoundFlags.SND_ASYNC);
											else  //없으면 기본 Sound
												IHIS.Framework.Kernel32.Nofify();
										}
										catch{}
									}
								}
							}
							//메세지 처리로직 추가
							break;
					}
				}
				catch{}
			}
			else if (m.Msg == MSG_SYSTEM_USER_LOGIN)  //사용자가 업무시스템 LOGIN시에 받는 MSG
			{
				try
				{
					if (m.WParam != IntPtr.Zero) //WParam이 전달되었으면
					{
						string[] logInfos = Marshal.PtrToStringAnsi(m.WParam).Split(new char[]{'\t'});
						//Wparam = 시스템ID + 시스템명 + 사용자ID + 사용자명 + 비밀번호
						if (logInfos.Length == 5) //추가처리
						{
							//사용자 리스트 관리 추가 (사용자Item생성 리스트에 추가)
							MainForm.UserItemList.Add(new UserItem(logInfos[2], logInfos[3], logInfos[0], logInfos[1]));
							/* 창이 보이지 않는 경우
							 * 2005.09.19 수신내역조회시 자꾸 TPEOS에러가 발생함. 일단 알림 Comment 처리 */
                            if (!this.Visible)
                            {
                                //해당사용자의 미확인건이 있으면 미확인건 있음을 알림
                                PopUpAllim(logInfos[2], logInfos[3]);
                            }
                            else
                            {
                                // <<2013.12.08>> LKH : 이미 떠있는 창의 id 변경 처리
                                // 사용자리스트 체크 하지 않고 메세지 창 보여줌
                                this.ShowAndSelectRecvList(logInfos[2]);
                            }
                        }
					}
				}
				catch{}
			}
			else if (m.Msg == MSG_SYSTEM_USER_LOGOUT)  //사용자가 업무시스템 LOGOUT시에 받는 MSG
			{
				try
				{
					if (m.WParam != IntPtr.Zero) //WParam이 전달되었으면
					{
						string[] logInfos = Marshal.PtrToStringAnsi(m.WParam).Split(new char[]{'\t'});

						//Wparam = 시스템ID + 사용자ID
						if (logInfos.Length == 2) //추가처리
						{
							//사용자 리스트에서 삭제
							int index = 0;
							bool isFound = false;
							foreach (UserItem item in MainForm.UserItemList)
							{
								if ((item.SystemID == logInfos[0]) && (item.UserID == logInfos[1]))
								{
									isFound = true;
									break;
								}
								index++;
							}
							if (isFound)
								MainForm.UserItemList.RemoveAt(index);
						}
					}
				}
				catch{}
			}
			else if (m.Msg == MSG_SYSTEM_USER_CHANGED)  //사용자가 업무시스템에서 사용자 변경시 받는 MSG
			{
				try
				{
					if (m.WParam != IntPtr.Zero) //WParam이 전달되었으면
					{
						string[] logInfos = Marshal.PtrToStringAnsi(m.WParam).Split(new char[]{'\t'});

						//Wparam = 시스템ID + 변경후 사용자ID + 변경후사용자명
						if (logInfos.Length == 3) //추가처리
						{
							//시스템사용자리스트 변경
							this.ChangeSystemUser(logInfos[0], logInfos[1], logInfos[2]);
						}
					}
				}
				catch{}
			}
			else if (m.Msg == MSG_XMSG_DISPLAY)  //IHIS에서 메세지보기 BUTTON CLICK시에 받는 MSG
			{
				try
				{
					//wParam이 IntPtr.Zero가 아닐경우 전달된 wParam에 사용자 ID Get
					if (m.WParam != IntPtr.Zero)  //업무시스템에서 메세지보기를 눌러 사용자ID가 전달된 경우
					{
						string userID = Marshal.PtrToStringAnsi(m.WParam);
						//사용자리스트 체크 하지 않고 메세지 창 보여줌
						this.ShowAndSelectRecvList(userID);
					}
					else  //IHIS에서 메세지 보기를 눌렀을때 wParam이 전달안되는 경우
					{
						//업무시스템사용자가 2이상이면 LIST를 보여주고 사용자 선택하여 Main화면 Show
						menuShow_Click(this, EventArgs.Empty);
					}
				}
				catch{}

			}
			else
			{
				//TrayIcon Dispose
				if (m.Msg == (int) Win32.Msgs.WM_CLOSE)
				{
					this.trayIcon.Visible = false;
					this.trayIcon.Dispose();
				}

				base.WndProc (ref m);
			}
		}
		#endregion

		#region TrayIcon, Menu Event
		private void menuShow_Click(object sender, System.EventArgs e)
		{
			bool isUserChanged = true; //현재User의 변경여부

			if (!this.Visible)
			{
				/*사용자 선택 (MainForm.UserItemList가 없으면 사용자Login창 Open
				 * 사용자가 한명이면 해당 사용자선택
				 * 2명이상이면 사용자 선택창 Open하여 선택 */
				//사용자리스트 Check Flag일때만 Check
				if (this.isCheckUserList)
				{
					if (MainForm.UserItemList.Count < 1)
					{
						UserLoginForm dlg = new UserLoginForm(this);
						if (dlg.ShowDialog(this) != DialogResult.OK) return;
						//현재사용자설정, 이 사용자는 UserItemList에 보관하지 않음
						//UserID 변경시 Flag Set
						//if ((MainForm.CurrUserID != "") && (MainForm.CurrUserID != dlg.UserID))
						if (MainForm.CurrUserID == dlg.UserID)
							isUserChanged = false;

						//ADMM 시스템 사용자 등록
						this.RegisterADMMSystemUser(dlg.UserID);

						MainForm.UserItemList.Add(new UserItem(dlg.UserID, dlg.UserName, MSG_SYS_ID,"メッセージシステム"));
						MainForm.CurrUserID = dlg.UserID;
						dlg.Dispose();
					}
					else if (MainForm.UserItemList.Count == 1)
					{
						string userID = ((UserItem) MainForm.UserItemList[0]).UserID;
						//UserID 변경시 Flag Set
						//if ((MainForm.CurrUserID != "") && (MainForm.CurrUserID != userID))
						if (MainForm.CurrUserID == userID)
							isUserChanged = false;
						MainForm.CurrUserID = userID;
					}
					else //2개이상(2개이상이라도 서로다른 ID만 설정함)
					{
						string bfUserID = "";
						int    userCount = 0;
						foreach (UserItem item in MainForm.UserItemList)
						{
							if (item.UserID != bfUserID)
								userCount++;
							bfUserID = item.UserID;
						}
						if (userCount > 1)
						{
							UserSelectForm dlg = new UserSelectForm();
							if (dlg.ShowDialog(this) != DialogResult.OK) return;
							//UserID 변경시 Flag Set
							//if ((MainForm.CurrUserID != "") && (MainForm.CurrUserID != dlg.SelectedUserItem.UserID))
							if (MainForm.CurrUserID == dlg.SelectedUserItem.UserID)
								isUserChanged = false;
							MainForm.CurrUserID = dlg.SelectedUserItem.UserID;
							dlg.Dispose();
						}
						else
						{
							string userID = ((UserItem) MainForm.UserItemList[0]).UserID;
							//UserID 변경시 Flag Set
							//if ((MainForm.CurrUserID != "") && (MainForm.CurrUserID != userID))
							if (MainForm.CurrUserID == userID)
								isUserChanged = false;
							MainForm.CurrUserID = userID;
						}
					}
				}

				//RightBottom Show
				Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
				this.Location = new Point(rc.Width - this.Width, rc.Height - this.Height);
				
				this.Show();
				this.Activate();
                //this.PopUpAllim(MainForm.currUserID, "ADM001");
			}
			else  //이미 보여주고 있으면 활성화만 시킴
				this.Activate();

			this.Text = (NetInfo.Language == LangMode.Ko ? "메세지시스템 사용자ID[" + MainForm.CurrUserID + "]"
				:"メッセージシステム ユーザーID[" + MainForm.CurrUserID + "]");

			//수신내역,송신내역,예약글내역 조회 (User가 변경되었으면)
			if (isUserChanged)
			{
				//조회일 Default로 SET
				SetDefaultQryDate();

				this.GetReceiveMsgList();
				this.GetSendMsgList();
				this.GetReservedMsgList();
				//보내는 메세지 초기화
				this.btnClear.PerformClick();
				//예약글 입력 Control 초기화
				this.txtResvTitle.Text = "";
				this.txtResvMsg.Text = "";
			}
		}

		private void menuHide_Click(object sender, System.EventArgs e)
		{
			if (this.Visible)
			{
				this.Hide();
			}
		}

		private void trayIcon_DoubleClick(object sender, System.EventArgs e)
		{
			if (this.Visible)
			{
				//Hide
				menuHide_Click(this, EventArgs.Empty);
			}
			else
			{
				//Show
				menuShow_Click(this, EventArgs.Empty);
			}
		}
		#endregion

		#region RegisterADMMSystemUser (ADMM 시스템 사용자진입현황(ADM3400)에 등록)
		public void RegisterADMMSystemUser(string userID)
		{
			//ADMM 시스템 사용자 등록
			UserInfoUtil.RegisterSystemUser(MSG_SYS_ID, userID);
		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			MsgTreeForm dlg = new MsgTreeForm(this, this.msgTreeItemList);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				//기존 msgTreeItemList Clear후 다시 설정, 배포목록 Text 설정
				this.msgTreeItemList.Clear();
				this.txtRecvSpot.Text = "";
				string text = "";
				foreach (MsgTreeItem item in dlg.MsgTreeItemList)
				{
					text += item.Title + ",";
					this.msgTreeItemList.Add(item);
				}
				if (text != "")
					text = text.Substring(0, text.Length - 1); //마지막, 제거
				this.txtRecvSpot.Text = text;
			}
			dlg.Dispose();
		}

		private void btnResvDelete_Click(object sender, System.EventArgs e)
		{
			//예약글 현재행 삭제
			int rowNum = grdResv.CurrentRowNumber;
			if (rowNum >= 0)
			{
				string userID = grdResv.GetItemString(rowNum, "user_id");
				string seq = grdResv.GetItemString(rowNum, "seq");

                string cmdText = @" DELETE ADM0730        A
                                     WHERE A.HOSP_CODE    = :f_hosp_code
                                       AND A.USER_ID      = :f_user_id
                                       AND A.SEQ          = :f_seq
                                  ";
                BindVarCollection bc = new BindVarCollection();
                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                bc.Add("f_user_id", userID);
                bc.Add("f_seq", seq);
                
                if (Service.ExecuteNonQuery(cmdText, bc))  //삭제성공시에 해당행 삭제
                {
                    grdResv.DeleteRow(rowNum);
                    grdResv.ResetUpdate();
                }
                else
                {
                    string msg = (NetInfo.Language == LangMode.Ko ? "예약글 삭제에러[" + Service.ErrFullMsg + "]"
                        : "予約文の削除エラー[" + Service.ErrFullMsg + "]");
                    XMessageBox.Show(msg);
                }
			}
		}

		private void btnResvAdd_Click(object sender, System.EventArgs e)
		{
			string msg = "";
			//예약글제목,예약글내용 입력여부 확인
			if (this.txtResvTitle.Text.Trim() == "")
			{
				msg = (NetInfo.Language == LangMode.Ko ? "예약글 제목을 입력하십시오"
					: "予約文のタイトルを入力してください。");
				XMessageBox.Show(msg);
				this.txtResvTitle.Focus();
				return;
			}
			if (this.txtResvMsg.Text.Trim() == "")
			{
				msg = (NetInfo.Language == LangMode.Ko ? "예약글 내용을 입력하십시오"
					: "予約文の内容を入力してください。");
				XMessageBox.Show(msg);
				this.txtResvMsg.Focus();
				return;
			}
			//Encoding 기준으로 2000byte초과하면 안됨
			int txtLen = Service.JpEncoding.GetByteCount(txtResvMsg.Text.Trim());
			if (txtLen >= 2000)
			{
				msg = (NetInfo.Language == LangMode.Ko ? "예약글의 길이가 너무 길어 저장할 수 없습니다."
					: "予約文が長すぎます。予約文は2000字以内で入力してください。");
				XMessageBox.Show(msg);
				txtResvMsg.Focus();
				return;
			}

            string cmdText = @" DECLARE
                                  T_SEQ            NUMBER := 0;
                                BEGIN
                                  -- 해당 USER의 예약글 MAX 순번 GET
                                  SELECT NVL(MAX(A.SEQ), 0) + 1 
                                    INTO T_SEQ 
                                    FROM ADM0730       A 
                                   WHERE A.HOSP_CODE   = :f_hosp_code
                                     AND A.USER_ID     = :f_user_id
                                  ;
                                  --
                                  INSERT INTO ADM0730 ( 
                                                         HOSP_CODE      , USER_ID            , SEQ
                                                       , MSG_TITLE      , MSG_CONTENTS
                                                       , CR_MEMB        , CR_TIME            , CR_TRM
                                            ) VALUES (
                                                         :f_hosp_code   , :f_user_id         , T_SEQ
                                                       , :f_msg_title   , :f_msg_contents   
                                                       , :f_user_id     , SYSDATE            , :q_user_trm
                                            );
                                END;
                              ";
            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_user_id", MainForm.CurrUserID);
            bc.Add("f_msg_title", this.txtResvTitle.Text);
            bc.Add("f_msg_contents", this.txtResvMsg.Text);

            if (Service.ExecuteNonQuery(cmdText, bc))
            {
                //성공시 예약글 리스트 다시조회
                this.GetReservedMsgList();
            }
            else
            {
                msg = (NetInfo.Language == LangMode.Ko ? "예약글 저장에러[" + Service.ErrFullMsg + "]"
                    : "予約文の保存エラー[" + Service.ErrFullMsg + "]");
                XMessageBox.Show(msg);
            }

			
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			//받을곳, 제목, 보낼내용 Clear
			this.txtRecvSpot.Text = "";
			this.txtSendTitle.Text = "";
			this.txtSendMsg.Text = "";
			//수신메세지리스트 삭제
			this.msgTreeItemList.Clear();
			//첨부목록 List Clear
			this.addedFileItems.Clear();
		}
		
		#region Button Event
		private void btnCloseRecv_Click(object sender, System.EventArgs e)
		{
			//Form Hide
			this.Hide();
		}
		#endregion

		private void btnRecvQry_Click(object sender, System.EventArgs e)
		{
			//수신메세지 조회
			this.GetReceiveMsgList();
		}

		private void btnSendQry_Click(object sender, System.EventArgs e)
		{
			//송신메세지조회, 예약글내역 조회
			this.GetSendMsgList();
			this.GetReservedMsgList();
		}

		private void btnCloseSend_Click(object sender, System.EventArgs e)
		{
			//Form Hide
			this.Hide();
		}

		private void grdResv_DoubleClick(object sender, System.EventArgs e)
		{
			//예약글 Double Click시에 제목, 내용 복사
			int rowNum = grdResv.CurrentRowNumber;
			if ( rowNum >= 0)
			{
				this.txtSendTitle.Text = grdResv.GetItemValue(rowNum, "msg_title").ToString();
				this.txtSendMsg.Text = grdResv.GetItemValue(rowNum, "msg_contents").ToString();
			}
		}

		private void btnResvCopy_Click(object sender, System.EventArgs e)
		{
			//예약글 제목, 내용 복사
			int rowNum = grdResv.CurrentRowNumber;
			if ( rowNum >= 0)
			{
				this.txtSendTitle.Text = grdResv.GetItemValue(rowNum, "msg_title").ToString();
				this.txtSendMsg.Text = grdResv.GetItemValue(rowNum, "msg_contents").ToString();
			}
		}

		private void RadioCheckedChanged(object sender, bool isSend)
		{
			RadioButton rbo = (RadioButton) sender;
			if (rbo.Checked)
			{
				rbo.BackColor = this.selectedBackColor;
				if (isSend)
				{
					this.GetSendMsgList();
					this.isCallCheckedChanged = false; //전체삭제 CheckBox의 CheckedChanged Event 수행하지 않음
                    this.cbxSendCnfm.Checked = false;
                    this.cbxSendDel.Checked = false;
                    this.isCallCheckedChanged = true;
				}
				else
				{
					this.GetReceiveMsgList();
					this.isCallCheckedChanged = false; //전체삭제,확인 CheckBox의 CheckedChanged Event 수행하지 않음
					this.cbxRecvCnfm.Checked = false;
					this.cbxRecvDel.Checked = false;
					this.isCallCheckedChanged = true;
				}
			}
			else
			{
				rbo.BackColor = this.unSelectedBackColor;
			}
		}

		private void rbxRecvNo_CheckedChanged(object sender, System.EventArgs e)
		{
			RadioCheckedChanged(sender, false);
		}

		private void rbxRecvYes_CheckedChanged(object sender, System.EventArgs e)
		{
			RadioCheckedChanged(sender, false);

		}

		private void rbxRecvAll_CheckedChanged(object sender, System.EventArgs e)
		{
			RadioCheckedChanged(sender, false);
		}

		private void rbxSendNo_CheckedChanged(object sender, System.EventArgs e)
		{
			RadioCheckedChanged(sender, true);
		}

		private void rbxSendYes_CheckedChanged(object sender, System.EventArgs e)
		{
			RadioCheckedChanged(sender, true);
		}

		private void rbxSendAll_CheckedChanged(object sender, System.EventArgs e)
		{
			RadioCheckedChanged(sender, true);
		}

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			/*글 올리기
			 * 1.수신자 입력여부 확인
			 * 2.제목,내용 입력여부 확인, 내용 2000byte초과여부 확인
			 * 3.다시한번 전송여부를 묻고 전송처리
			 */
			string msg = "";
			if (this.txtRecvSpot.Text == "")
			{
				msg = (NetInfo.Language == LangMode.Ko ? "수신자가 선택되지 않았습니다."
					:"受信先が選択されていません。");
				XMessageBox.Show(msg);
				return;
			}
			if (this.txtSendTitle.Text.Trim() == "")
			{
				msg = (NetInfo.Language == LangMode.Ko ? "제목이 입력되지 않았습니다."
					:"タイトルを入力してください。");
				XMessageBox.Show(msg);
				txtSendTitle.Focus();
				return;
			}
			if (this.txtSendMsg.Text.Trim() == "")
			{
				msg = (NetInfo.Language == LangMode.Ko ? "내용이 입력되지 않았습니다."
					:"内容を入力してください。");
				XMessageBox.Show(msg);
				txtSendMsg.Focus();
				return;
			}
			//Encoding 기준으로 2000byte초과하면 안됨
			int txtLen = Service.JpEncoding.GetByteCount(txtSendMsg.Text.Trim());
			if (txtLen >= 2000)
			{
				msg = (NetInfo.Language == LangMode.Ko ? "메세지의 길이가 너무 길어 저장할 수 없습니다."
					:"メッセージが長すぎて保存できません。");
				XMessageBox.Show(msg);
				txtSendMsg.Focus();
				return;
			}
			msg = (NetInfo.Language == LangMode.Ko ? "수신자[" + txtRecvSpot.Text + "]\n\n" +
				"제목[" + txtSendTitle.Text + "]\n\n" + 
				"메세지 전송하시겠습니까?"
				: "受信先[" + txtRecvSpot.Text + "]\n\n" +
				"タイトル[" + txtSendTitle.Text + "]\n\n" + 
				"メッセージを送信しますか" );
			string title = (NetInfo.Language == LangMode.Ko ? "송신확인" : "送信の確認");
			if (XMessageBox.Show(msg, title, MessageBoxButtons.YesNo) != DialogResult.Yes) return;

			/*2005.06.29 첨부파일 확인, 첨부파일이 있으면 첨부파일 Upload 성공시만 전송가능
			 * 첨부파일은 192.168.1.100(SERVICE로 서버IP 가져오기) id하나를 받아서 일자별로 첨부파일 관리
			 * 첨부파일명은 GUID로 UNIQUE한 파일명으로 관리하고, AMSGFILE에는 실제파일명과 UNIQUE파일명을 관리함.
			 */
			//첨부파일내역 리스트 COPY(비동기식전송시에 ftpWorker_DataTransferCompleted에서 Clear함으로 
			//foreach문을 돌면서 데이타를 확인할 수가 없음
			ArrayList attachedFileList = new ArrayList();

            string fileAtached_yn = "N";
			//첨부파일 관리 ServerIP,UserID, Pswd GET
			if (this.addedFileItems.Count > 0)
			{
                fileAtached_yn = "Y";
				//OnLoad시에 
				if (this.fileServerIP == "")
				{
					//첨부파일 관리서버 정보 가져오기 실패시 return
					if (!this.GetFileServerInfo()) return;
				}
				ftpWorker = new XFTPWorker(this.fileServerUserID, this.fileServerPswd, this.fileServerIP);
				//Async로 Call하므로 한건 전송 완료시 다음 건 전송하도록 처리함.(비동기식)
				ftpWorker.DataTransferCompleted += new DataTransferCompletedEventHandler(ftpWorker_DataTransferCompleted);
				if (!ftpWorker.Connected)
				{
					msg = (NetInfo.Language == LangMode.Ko ? "첨부파일 관리서버에 접속하지 못했습니다.\n\n" +
						"첨부 파일을 전송할 수 없습니다."
						: "添付ファィルの管理サーバーに接続できませんでした。\n\n" +
                        "添付ファィルを送信できませんでした。");
					XMessageBox.Show(msg);
					return;
				}
				//현재일자로 Dir로 Server Dir 이동
				string dirName = EnvironInfo.GetSysDate().ToString("yyyyMMdd");
				if (!ftpWorker.ChangeDir(dirName))
				{
					//2006.04.12 Dir이 없으면 Make Dir후 이동
					if (!ftpWorker.MakeDir(dirName))
					{
						msg = (NetInfo.Language == LangMode.Ko ? "첨부파일 관리서버의 디렉토리를 생성하지 못했습니다.\n\n" +
							"첨부 파일을 전송할 수 없습니다."
							: "添付ファィルの管理サーバーのディレクトリーが生成できませんでした。\n\n" +
							"添付ファィルを送信できませんでした。");
						XMessageBox.Show(msg);
						return;
					}
					//Dir 변경
					if (!ftpWorker.ChangeDir(dirName))
					{
						msg = (NetInfo.Language == LangMode.Ko ? "첨부파일 관리서버의 디렉토리를 변경하지 못했습니다.\n\n" +
							"첨부 파일을 전송할 수 없습니다."
							: "添付ファィルの管理サーバーのディレクトリーが変更できませんでした。\n\n" +
                            "添付ファィルを送信できませんでした。");
						XMessageBox.Show(msg);
						return;
					}
				}
				//AddedFileItem 복사
				attachedFileList.AddRange(addedFileItems.ToArray());
				//파일 전송(비동기식)
				this.sendFileCount = 0;
				AddedFileItem fItem = this.addedFileItems[0] as AddedFileItem;
				if (fItem != null)
					if (!ftpWorker.SendLargeFileToServer(fItem.FullName, fItem.UniqueName)) return;
				
				//동기식으로 전송
                //foreach (AddedFileItem item in this.addedFileItems)
                //{
                //    //파일 전송 실패에 Return
                //    if (!ftpWorker.SendFileToServer(item.FullName, item.UniqueName)) return;
                //}
			}

			//laySendMsg(전송메세지 관리 Layout에 데이타 SET
			//사용자ID + 메세지타이틀 + 메세지내용 + 송신전체확인여부 + 파일첨부여부
            //int rowNum = this.laySendMsg.InsertRow(-1);
            //this.laySendMsg.SetItemValue(rowNum, "user_id", MainForm.CurrUserID);
            //this.laySendMsg.SetItemValue(rowNum, "msg_title", this.txtSendTitle.Text);
            //this.laySendMsg.SetItemValue(rowNum, "msg_contents", this.txtSendMsg.Text);
            //if (this.cbxSendAllCnfm.Checked)
            //    this.laySendMsg.SetItemValue(rowNum, "send_all_cnfm_yn", "Y");
            //else
            //    this.laySendMsg.SetItemValue(rowNum, "send_all_cnfm_yn", "N");
            //if (attachedFileList.Count > 0)
            //    this.laySendMsg.SetItemValue(rowNum, "file_atch_yn", "Y");
            //else
            //    this.laySendMsg.SetItemValue(rowNum, "file_atch_yn", "N");

			//수신자리스트 Layout 데이타 생성
			string recverGubun, recverID;
			foreach (MsgTreeItem item in this.msgTreeItemList)
			{
                BindVarCollection bindVar = new BindVarCollection(); ;
                String cmd = "";
                DataTable beopoList = null;
                int rowNum;

				switch (item.ItemType)
				{
					case ItemType.Beopo: //B.배포그룹
						recverID = item.BeopoID;

                        // 배포 LIST 
                        cmd = @"SELECT B.BEOPO_GUBUN      AS BEOPO_GUBUN
                                     , B.RECV_SPOT        AS RECV_SPOT
                                  FROM ADM0750        B
                                     , ADM0740        A
                                 WHERE A.HOSP_CODE    = :f_hosp_code
                                   AND A.USER_ID      = :f_user_id
                                   AND A.SEQ          = :f_beopo_id
                                   --
                                   AND B.HOSP_CODE    = A.HOSP_CODE
                                   AND B.USER_ID      = A.USER_ID
                                   AND B.SEQ          = A.SEQ
                               ";
                        bindVar.Clear();
                        bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                        bindVar.Add("f_user_id", MainForm.CurrUserID);
                        bindVar.Add("f_beopo_id", recverID);
                        //
                        beopoList = Service.ExecuteDataTable(cmd, bindVar);
                        foreach (DataRow row in beopoList.Rows)
                        {
                            switch (row["BEOPO_GUBUN"].ToString())
                            {
                                case "B"://G.조직그룹
                                    recverGubun = "G";
                                    recverID = row["RECV_SPOT"].ToString();

                                    rowNum = this.layRecverList.InsertRow(-1);
                                    this.layRecverList.SetItemValue(rowNum, "recver_gubun", recverGubun);
                                    this.layRecverList.SetItemValue(rowNum, "recver_id", recverID);
                                    this.layRecverList.SetItemValue(rowNum, "user_id", MainForm.CurrUserID);
                                    this.layRecverList.SetItemValue(rowNum, "msg_title", this.txtSendTitle.Text);
                                    this.layRecverList.SetItemValue(rowNum, "msg_contents", this.txtSendMsg.Text);
                                    this.layRecverList.SetItemValue(rowNum, "send_all_cnfm_yn", "N");
                                    this.layRecverList.SetItemValue(rowNum, "file_atch_yn", fileAtached_yn);

                                    break;
                                default://U.사용자
                                    recverGubun = "U";
                                    recverID = row["RECV_SPOT"].ToString();

                                    rowNum = this.layRecverList.InsertRow(-1);
                                    this.layRecverList.SetItemValue(rowNum, "recver_gubun", recverGubun);
                                    this.layRecverList.SetItemValue(rowNum, "recver_id", recverID);
                                    this.layRecverList.SetItemValue(rowNum, "user_id", MainForm.CurrUserID);
                                    this.layRecverList.SetItemValue(rowNum, "msg_title", this.txtSendTitle.Text);
                                    this.layRecverList.SetItemValue(rowNum, "msg_contents", this.txtSendMsg.Text);
                                    this.layRecverList.SetItemValue(rowNum, "send_all_cnfm_yn", "N");
                                    this.layRecverList.SetItemValue(rowNum, "file_atch_yn", fileAtached_yn);

                                    break;
                            }
                        }


						break;
					case ItemType.Buseo: //G.조직그룹
						recverGubun = "G";
						recverID = item.Buseo;

                        rowNum = this.layRecverList.InsertRow(-1);
                        this.layRecverList.SetItemValue(rowNum, "recver_gubun", recverGubun);
                        this.layRecverList.SetItemValue(rowNum, "recver_id", recverID);
                        this.layRecverList.SetItemValue(rowNum, "user_id", MainForm.CurrUserID);
                        this.layRecverList.SetItemValue(rowNum, "msg_title", this.txtSendTitle.Text);
                        this.layRecverList.SetItemValue(rowNum, "msg_contents", this.txtSendMsg.Text);
                        this.layRecverList.SetItemValue(rowNum, "send_all_cnfm_yn", "N");
                        this.layRecverList.SetItemValue(rowNum, "file_atch_yn", fileAtached_yn);

                        break;
					default: //U.사용자
						recverGubun = "U";
						recverID = item.UserID;

                        rowNum = this.layRecverList.InsertRow(-1);
                        this.layRecverList.SetItemValue(rowNum, "recver_gubun", recverGubun);
                        this.layRecverList.SetItemValue(rowNum, "recver_id", recverID);
                        this.layRecverList.SetItemValue(rowNum, "user_id", MainForm.CurrUserID);
                        this.layRecverList.SetItemValue(rowNum, "msg_title", this.txtSendTitle.Text);
                        this.layRecverList.SetItemValue(rowNum, "msg_contents", this.txtSendMsg.Text);
                        this.layRecverList.SetItemValue(rowNum, "send_all_cnfm_yn", "N");
                        this.layRecverList.SetItemValue(rowNum, "file_atch_yn", fileAtached_yn);

						break;
				}
			}

			//첨부파일Layout생성
			foreach (AddedFileItem fItem in attachedFileList)
			{
                int rowNum = this.layFileList.InsertRow(-1);
                this.layFileList.SetItemValue(rowNum, "file_nm", fItem.FileName);
                this.layFileList.SetItemValue(rowNum, "uni_file_nm", fItem.UniqueName);
			}

            if (this.SendMsg() == true)
            {
                this.GetSendMsgList();
            }            


			//Layout Data Clear
			//this.laySendMsg.Reset();
			this.layRecverList.Reset();
			this.layFileList.Reset();

			//제목,내용은 Clear
			this.txtSendTitle.Text = "";
			this.txtSendMsg.Text = "";
			//첨부파일 리스트 Clear 
			//동기식
			this.addedFileItems.Clear();
		}

        private bool SendMsg()
        {
            // Msg Insert 
            string cmd = "";
            //string newLine = "\r\n";
            string senderID = "";
            string senderName = "";
            string senderBuseo = "";
            object tempobject = null;
            string sendSeq = "";
            DataTable temp = null;
            DataTable temp2 = null;
            BindVarCollection bindVar = new BindVarCollection(); ;
            string msg = "";
            //string cap = "";
            ArrayList recvList = new ArrayList();

            if (this.layRecverList.RowCount > 0)
            {
                senderID = layRecverList.GetItemString(0, "user_id");
                bindVar.Clear();
                bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVar.Add("f_sender_id", senderID);

                // 사용자 이름 가져오기
                cmd = @"SELECT A.USER_NM
                             , A.DEPT_CODE
                          FROM ADM3200          A
                         WHERE A.HOSP_CODE      = :f_hosp_code
                           AND A.USER_ID        = :f_sender_id
                       ";
                //
                temp = Service.ExecuteDataTable(cmd, bindVar);

                if (temp != null && temp.Rows.Count > 0)
                {
                    senderName = temp.Rows[0]["USER_NM"].ToString();
                    senderBuseo = temp.Rows[0]["DEPT_CODE"].ToString();
                }

                //해당일자,해당사용자의 MAX 송신순번
                cmd = @"SELECT NVL(MAX(A.SEND_SEQ), 0) + 1
                          FROM ADM0700          A
                         WHERE A.HOSP_CODE      = :f_hosp_code
                           AND A.SEND_DT        = TRUNC(SYSDATE) 
                           AND A.SENDER_ID      = :f_sender_id 
                       ";

                tempobject = Service.ExecuteScalar(cmd, bindVar);

                if (tempobject == null || tempobject.ToString() == "")
                {
                    sendSeq = "1";
                }
                else
                {
                    sendSeq = tempobject.ToString();
                }


                try
                {
                    Service.BeginTransaction();

                    // 송신내역 insert 
                    cmd = @"INSERT INTO ADM0700 (
                                                   HOSP_CODE
                                                 , SEND_DT         , SENDER_ID            , SEND_SEQ              , SEND_SPOT
                                                 , MSG_TITLE       , MSG_CONTENTS      
                                                 , VALID_YN        , SEND_ALL_CNFM_YN     , RECV_ALL_CNFM_YN      , FILE_ATCH_YN      
                                                 , CR_MEMB         , CR_TIME              , CR_TRM  
                                       ) VALUES (
                                                   :f_hosp_code
                                                 , TRUNC(SYSDATE)  , :f_sender_id         , :f_send_seq           , :f_sender_buseo
                                                 , :f_msg_title    , :f_msg_contents   
                                                 , 'Y'             , :f_send_all_cnfm_yn  , 'N'                   , :f_file_atch_yn   
                                                 , :f_user_id      , SYSDATE              , :f_user_trm
                                       )
                           ";
                    bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                    bindVar.Add("f_send_seq", sendSeq);
                    bindVar.Add("f_sender_buseo", senderBuseo);
                    bindVar.Add("f_msg_title", layRecverList.GetItemString(0, "msg_title"));
                    bindVar.Add("f_msg_contents", layRecverList.GetItemString(0, "msg_contents"));
                    bindVar.Add("f_send_all_cnfm_yn", layRecverList.GetItemString(0, "send_all_cnfm_yn"));
                    bindVar.Add("f_file_atch_yn", layRecverList.GetItemString(0, "file_atch_yn"));
                    bindVar.Add("f_user_id", senderID);
                    bindVar.Add("f_user_trm", "");

                    if (Service.ExecuteNonQuery(cmd, bindVar) == false)
                    {
                        msg = "送信内訳の生成に失敗しました。[" + Service.ErrFullMsg + "]";
                        throw new Exception(msg);
                    }


                    foreach (DataRow row in this.layRecverList.LayoutTable.Rows)
                    {
                        switch (row["recver_gubun"].ToString())
                        {
                            case "G": // BUSEO
                                cmd = @"SELECT A.BUSEO_CODE           AS BUSEO_CODE
                                          FROM BAS0260        A
                                         WHERE A.HOSP_CODE    = :f_hosp_code
                                           AND A.START_DATE   = (SELECT MAX(Z.START_DATE)
                                                                   FROM BAS0260         Z
                                                                  WHERE Z.HOSP_CODE     = A.HOSP_CODE
                                                                    AND Z.BUSEO_CODE    = A.BUSEO_CODE
                                                                    --
                                                                    AND Z.START_DATE    <= TRUNC(SYSDATE)
                                                                    AND (   Z.END_DATE  IS NULL
                                                                         OR Z.END_DATE  >= TRUNC(SYSDATE)
                                                                        )
                                                                )
                                           AND (   A.END_DATE IS NULL
                                                OR A.END_DATE >= TRUNC(SYSDATE)
                                               )
                                         START WITH (    A.HOSP_CODE   = :f_hosp_code
                                                     AND A.BUSEO_CODE  = :f_recver_id
                                                    )
                                        CONNECT BY PRIOR A.BUSEO_CODE = A.PARENT_BUSEO 
                                       ";

                                bindVar.Clear();
                                bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                                bindVar.Add("f_recver_id", row["recver_id"].ToString());

                                temp = Service.ExecuteDataTable(cmd, bindVar);

                                if (temp != null)
                                {
                                    foreach (DataRow buseoRow in temp.Rows)
                                    {
                                        cmd = @" SELECT A.USER_ID 
                                                  FROM ADM3200 A 
                                                 WHERE A.HOSP_CODE            = '" + EnvironInfo.HospCode.ToString() + @"'
                                                   AND A.DEPT_CODE            = '" + buseoRow["buseo_code"].ToString() + @"'
                                                   AND (   A.USER_END_YMD     IS NULL
                                                        OR A.USER_END_YMD     >= TRUNC(SYSDATE)
                                                       )
                                               ";
                                        temp2 = Service.ExecuteDataTable(cmd);
                                        if (temp2 != null)
                                        {
                                            foreach (DataRow usrRow in temp2.Rows)
                                            {
                                                cmd = @"DECLARE
                                                          T_CHECK           VARCHAR2(1);
                                                        BEGIN
                                                          T_CHECK      := 'N';
                                                          --
                                                          FOR R1 IN ( SELECT 'X'
                                                                        FROM ADM0710          X
                                                                       WHERE A.HOSP_CODE      = '" + EnvironInfo.HospCode.ToString() + @"'
                                                                         AND A.SEND_DT        = TRUNC(SYSDATE)
                                                                         AND A.SENDER_ID      = '" + row["user_id"].ToString() + @"'
                                                                         AND A.SEND_SEQ       = " + sendSeq + @"
                                                                         AND A.RECV_SPOT      = '" + buseoRow["buseo_code"].ToString() + @"'
                                                                         AND A.RECVER_ID      = '" + usrRow["user_id"].ToString() + @"'
                                                                    )
                                                          LOOP
                                                            T_CHECK    := 'Y';
                                                          END LOOP;
                                                          --
                                                          IF (T_CHECK = 'N') THEN
                                                            INSERT INTO ADM0710 (
                                                                                   HOSP_CODE
                                                                                 , SEND_DT                     , SENDER_ID             , SEND_SEQ
                                                                                 , RECV_SPOT                   , RECVER_ID             , RECV_SPOT_YN      
                                                                                 , CNFM_YN                     , RECV_ALL_CNFM_YN      , FILE_ATCH_YN                , VALID_YN  
                                                                                 --
                                                                                 , UP_MEMB                     , UP_TIME                , UP_TRM
                                                                                 , CR_MEMB                     , CR_TIME                , CR_TRM 
                                                                       ) VALUES (
                                                                                   '" + EnvironInfo.HospCode.ToString() + @"'
                                                                                 , TRUNC(SYSDATE)                             , '" + row["user_id"].ToString() + @"'          , " + sendSeq + @"
                                                                                 , '" + buseoRow["buseo_code"].ToString() + @"' , '" + usrRow["user_id"].ToString() + @"'     , 'Y'
                                                                                 , 'N'                                        , 'N'                                           , '" + row["file_atch_yn"].ToString() + @"'     , 'Y'
                                                                                 --
                                                                                 , '" + row["user_id"].ToString() + @"'       , SYSDATE                                       , ''                                         
                                                                                 , '" + row["user_id"].ToString() + @"'       , SYSDATE                                       , '' 
                                                                       );
                                                          END IF;
                                                        END;
                                                       ";

                                                if (Service.ExecuteNonQuery(cmd) == false)
                                                {
                                                    msg = "送信内訳の生成に失敗しました。[" + Service.ErrFullMsg + "]";
                                                    throw new Exception(msg);
                                                }

                                                if (recvList.Contains(usrRow["user_id"].ToString()) == false)
                                                {
                                                    recvList.Add(usrRow["user_id"].ToString());
                                                }
                                            }
                                        }
                                    }
                                }

                                break;
                            case "U": // USER
                                object recv_spot = null;

                                cmd = @"SELECT A.DEPT_CODE
                                          FROM ADM3200        A
                                         WHERE A.HOSP_CODE            = '" + EnvironInfo.HospCode.ToString() + @"' 
                                           AND A.USER_ID              = '" + row["recver_id"].ToString() + @"' 
                                           AND (   A.USER_END_YMD     IS NULL
                                                OR A.USER_END_YMD     >= TRUNC(SYSDATE)
                                               )
                                       ";

                                recv_spot = Service.ExecuteScalar(cmd);

                                if (recv_spot == null)
                                {
                                    recv_spot = "";
                                }

                                cmd = @"DECLARE
                                          T_CHECK         VARCHAR2(1);
                                        BEGIN
                                          T_CHECK         := 'N';
                                          --
                                          FOR R1 IN ( SELECT 'X'
                                                       FROM ADM0710           A
                                                       WHERE A.HOSP_CODE      = '" + EnvironInfo.HospCode.ToString() + @"'
                                                         AND A.SEND_DT        = TRUNC(SYSDATE)
                                                         AND A.SENDER_ID      = '" + row["user_id"].ToString() + @"'
                                                         AND A.SEND_SEQ       = " + sendSeq + @"
                                                         AND A.RECV_SPOT      = '" + recv_spot.ToString() + @"'
                                                         AND A.RECVER_ID      = '" + row["recver_id"].ToString() + @"'
                                                    )
                                          LOOP
                                            T_CHECK       := 'Y';
                                          END LOOP;
                                          --
                                          IF T_CHECK != 'Y' THEN
                                            INSERT INTO ADM0710 (
                                                                   HOSP_CODE
                                                                 , SEND_DT                         , SENDER_ID                      , SEND_SEQ                        
                                                                 , RECV_SPOT                       , RECVER_ID                      , RECV_SPOT_YN
                                                                 , CNFM_YN                         , RECV_ALL_CNFM_YN               , FILE_ATCH_YN                    , VALID_YN
                                                                 --    
                                                                 , UP_MEMB                         , UP_TIME                        , UP_TRM
                                                                 , CR_MEMB                         , CR_TIME                        , CR_TRM           
                                                       ) VALUES (
                                                                   '" + EnvironInfo.HospCode.ToString() + @"'
                                                                 , TRUNC(SYSDATE)                               , '" + row["user_id"].ToString() + @"'     , " + sendSeq + @"
                                                                 , '" + recv_spot.ToString() + @"'              , '" + row["recver_id"].ToString() + @"'   , 'Y'
                                                                 , 'N'                                          , 'N'                                      , '" + row["file_atch_yn"].ToString() + @"'    , 'Y'
                                                                 --
                                                                 , '" + row["user_id"].ToString() + @"'         , SYSDATE                                  , ''                                           
                                                                 , '" + row["user_id"].ToString() + @"'         , SYSDATE                                  , '' 
                                                       );
                                          END IF;
                                        END;
                                       ";
                                if (Service.ExecuteNonQuery(cmd) == false)
                                {
                                    msg = "送信内訳の生成に失敗しました。[" + Service.ErrFullMsg + "]";
                                    throw new Exception(msg);
                                }

                                if (recvList.Contains(row["recver_id"].ToString()) == false)
                                {
                                    recvList.Add(row["recver_id"].ToString());
                                }

                                break;
                        }

                    }

                    bindVar.Clear();
                    bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                    bindVar.Add("f_sender_id", senderID);
                    bindVar.Add("f_send_seq", sendSeq);

                    for (int i = 1; i <= this.layFileList.RowCount; i++)
                    {
                        bindVar.Add("f_atch_file_seq", i.ToString());
                        bindVar.Add("f_atch_file_nm", this.layFileList.GetItemString(i - 1, "file_nm"));
                        bindVar.Add("f_atch_uni_file_nm", this.layFileList.GetItemString(i- 1, "uni_file_nm"));

                        cmd = @"INSERT INTO ADM0720 (
                                                        HOSP_CODE
                                                      , SEND_DT          , SENDER_ID         , SEND_SEQ
                                                      , ATCH_FILE_SEQ    , ATCH_FILE_NM      , ATCH_UNI_FILE_NM
                                           ) VALUES (
                                                        :f_hosp_code
                                                      , TRUNC(SYSDATE)   , :f_sender_id      , :f_send_seq
                                                      , :f_atch_file_seq , :f_atch_file_nm   , :f_atch_uni_file_nm 
                                           )
                               ";
                        if (Service.ExecuteNonQuery(cmd, bindVar) == false)
                        {
                            msg = "送信内訳の生成に失敗しました。[" + Service.ErrFullMsg + "]";
                            throw new Exception(msg);
                        }

                    }

                    Service.CommitTransaction();

                    if (layRecverList.RowCount > 0)
                        this.SendMsgUdp(senderID, recvList, sendSeq);
                }
                catch(Exception xe)
                {
                    Service.RollbackTransaction();
					//https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(xe.Message, "送信失敗", MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;

        }

        private bool SendMsgUdp(string aSenderId, ArrayList aRecvList, string aSendSeq)
        {
            foreach (string recver in aRecvList)
                IHIS.Framework.UdpHelper.SendMsgToID(aSenderId, recver, this.txtSendTitle.Text, this.txtSendMsg.Text);
            //foreach (string recver in aRecvList)
            //    IHIS.Framework.UdpHelper.SendMsgToID(recver, aSenderId, this.txtSendTitle.Text, this.txtSendMsg.Text);

            return true;
        }

		private int sendFileCount = 0;
		private XFTPWorker ftpWorker = null;
		private void ftpWorker_DataTransferCompleted(object sender, DataTransferCompletedEventArgs e)
		{
			//전송 파일 갯수 증가
			sendFileCount++;
			if (this.addedFileItems.Count > sendFileCount)
			{
				AddedFileItem fItem = addedFileItems[sendFileCount] as AddedFileItem;
				if ((fItem != null) && (ftpWorker != null))
					ftpWorker.SendLargeFileToServer(fItem.FullName, fItem.UniqueName);
			}
			else
			{
				//비동기식일 경우에는 여기서 Clear
				this.addedFileItems.Clear();
			}

		}

		private void btnSendDetail_Click(object sender, System.EventArgs e)
		{
			//수신자 상세정보 조회
			GetDetailReceiveMsgList();
		}

		private void grdSend_DoubleClick(object sender, System.EventArgs e)
		{
			//수신자 상세정보 조회
			GetDetailReceiveMsgList();
		}

		private void btnDeleteSend_Click(object sender, System.EventArgs e)
		{
            string msg = "";
			string title = (NetInfo.Language == LangMode.Ko ? "삭제확인" : "削除確認");
			int delCount = 0;
			foreach (DataRow dtRow in grdSend.LayoutTable.Rows)
                if (dtRow["del_yn"].ToString() == "Y")
                   delCount++;

			//if (delCount < 1)
			//{
			//	msg = (NetInfo.Language == LangMode.Ko ? "삭제할 메세지를 체크하십시오."
			//		: "削除するメッセージをチェックしてください。");
			//	XMessageBox.Show(msg, title);
			//	return;
			//}

		   //삭제여부 다시 확인
           if (delCount > 1)
           {
               msg = (NetInfo.Language == LangMode.Ko ? "메세지 " + delCount.ToString() + "건을 삭제하시겠습니까?"
                   : "メッセージ " + delCount.ToString() + "件を削除しますか。");
               if (XMessageBox.Show(msg, title, MessageBoxButtons.YesNo) != DialogResult.Yes) return;
           }

            string cmdText = @"UPDATE ADM0700            A
                                  SET A.VALID_YN         = DECODE(:f_del_yn, 'Y', 'N', 'Y')
                                    , A.RECV_ALL_CNFM_YN = :f_cnfm_yn
                                    , A.UP_MEMB          = :f_user_id
                                    , A.UP_TIME          = SYSDATE
                                    , A.UP_TRM           = :q_user_trm
                                WHERE A.HOSP_CODE        = :f_hosp_code
                                  AND A.SEND_DT          = :f_send_dt
                                  AND A.SENDER_ID        = :f_sender_id
                                  AND A.SEND_SEQ         = :f_send_seq
                              ";
            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_user_id", MainForm.currUserID);

            try
            {
                Service.BeginTransaction();

                for (int i = 0; i < this.grdSend.RowCount; i++)
                {
                    if ((this.grdSend.GetItemString(i, "cnfm_yn") != this.grdSend.GetItemString(i, "orig_cnfm_yn")) ||
                         this.grdSend.GetItemString(i, "del_yn") == "Y")
                    {                       
                        bc.Remove("f_send_dt");
                        bc.Remove("f_sender_id");
                        bc.Remove("f_send_seq");
                        //
                        bc.Remove("f_del_yn");
                        bc.Remove("f_cnfm_yn");
                        //
                        bc.Add("f_send_dt", this.grdSend.GetItemString(i, "send_dt"));
                        bc.Add("f_sender_id", this.grdSend.GetItemString(i, "sender_id"));
                        bc.Add("f_send_seq", this.grdSend.GetItemString(i, "send_seq"));
                        //
                        bc.Add("f_cnfm_yn", this.grdSend.GetItemString(i, "cnfm_yn"));
                        bc.Add("f_del_yn", this.grdSend.GetItemString(i, "del_yn"));
                        //
                        if (!Service.ExecuteNonQuery(cmdText, bc))  
                            throw new Exception();
                    }
                }
                Service.CommitTransaction();
                //삭제성공시 송신건 다시조회
                this.cbxSendCnfm.Checked = false;
                this.cbxSendDel.Checked = false;
                //
                this.GetSendMsgList();
            }
            catch
            {
                Service.RollbackTransaction();
                //msg = (NetInfo.Language == LangMode.Ko ? "메세지삭제에러[" + Service.ErrFullMsg + "]"
                //    : "メッセージ削除エラー[" + Service.ErrFullMsg + "]");
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(msg);            
            }
		}

		private void grdRecv_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
		{
			//조회후 확인된 건은 수정불가 
			if (e.ColName == "cnfm_yn")
			{
                //if (e.DataRow["orig_cnfm_yn"].ToString() == "Y")
                //    e.Protect = true;
                //else
                //    e.Protect = false;
			}
		}

		private void grdRecv_GridContDisplayed(object sender, IHIS.Framework.XGridContDisplayedEventArgs e)
		{
			//연속조회로 보여진후에 첨부파일 버튼 Enable 상태 변경(첨부파일이 없으면 Disable)
			ChangeGridButtonEnable(e.BeforeDisplayCount, e.AfterDisplayCount);
		}

		private void btnRecvCnfm_Click(object sender, System.EventArgs e)
		{
//            this.GetReceiveMsgList();

            if (this.UpdateConfirmRecvList())
            {
                this.cbxRecvCnfm.Checked = false;
                this.cbxRecvDel.Checked = false;
                //
                this.GetReceiveMsgList();
            }
			//수신확인 서비스 Call
            //if (this.dsvCnfmRecvList.Call())
            //{
            //    //수신리스트 다시 조회			
            //    this.GetReceiveMsgList();
            //}
            //else
            //{
            //    string msg = (NetInfo.Language == LangMode.Ko ? "수신확인에러[" + dsvCnfmRecvList.ErrMsg + "]"
            //        : "受信確認エラー[" + dsvCnfmRecvList.ErrMsg + "]");
            //    XMessageBox.Show(msg);
            //}
		}

        private bool UpdateConfirmRecvList()
        {
            string cmd = "";
            Service.BeginTransaction();
            foreach (DataRow dr in this.grdRecv.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                {
                    if ( (dr["cnfm_yn"].ToString() != dr["orig_cnfm_yn"].ToString()) ||
                         dr["del_yn"].ToString() == "Y")
                    {
                        cmd = @"UPDATE ADM0710              A
                                   SET A.CNFM_YN            = '" + dr["cnfm_yn"].ToString() + @"'
                                     --, A.VALID_YN           = '" + dr["del_yn"].ToString() + @"'
                                     , A.VALID_YN           = DECODE('" + dr["del_yn"].ToString() + @"', 'Y', 'N', A.VALID_YN)
                                     --
                                     , A.UP_MEMB            = '" + dr["sender_id"].ToString() + @"'
                                     , A.UP_TIME            = SYSDATE
                                     --, A.UP_TRM             = :q_user_trm
                                 WHERE A.HOSP_CODE          = '" + EnvironInfo.HospCode.ToString() + @"'
                                   AND A.SEND_DT            = TO_DATE('" + dr["send_dt"].ToString() + @"', 'YYYY/MM/DD')
                                   AND A.SENDER_ID          = '" + dr["sender_id"].ToString() + @"'
                                   AND A.SEND_SEQ           = " + dr["send_seq"].ToString() + @"
                                   AND A.RECV_SPOT          = '" + dr["recv_spot"].ToString() + @"'
                                   AND A.RECVER_ID          = '" + dr["recver_id"].ToString() + @"' 
                               ";

                        if (Service.ExecuteNonQuery(cmd) == false)
                        {
                            Service.RollbackTransaction();

                            XMessageBox.Show("受信確認に失敗しました。[" + Service.ErrFullMsg + "]", "受信確認失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return false;
                        }

                    }

                }
            }

            Service.CommitTransaction();

            return true;
        }

		private void grdRecv_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
		{
			if (e.ColName == "del_yn") //삭제 컬럼
			{
				//원 확인여부가 N이건은 삭제 Check시에 확인도 Check
				if (e.ChangeValue.ToString() == "Y")
				{
					if (e.DataRow["orig_cnfm_yn"].ToString() == "N")
						grdRecv.SetItemValue(e.RowNumber, "cnfm_yn","Y");
				}
				
			}
		}

        private void grdSend_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ColName == "del_yn") //삭제 컬럼
            {
                //원 확인여부가 N이건은 삭제 Check시에 확인도 Check
                if (e.ChangeValue.ToString() == "Y")
                {
                    if (e.DataRow["orig_cnfm_yn"].ToString() == "N")
                        grdSend.SetItemValue(e.RowNumber, "cnfm_yn", "Y");
                }

            }

        }

		private void btnReply_Click(object sender, System.EventArgs e)
		{
			int rowNum = this.grdRecv.CurrentRowNumber;
			if (rowNum >= 0)
			{
				string senderID = grdRecv.GetItemString(rowNum, "sender_id");  //답장수신자ID
				string senderName = grdRecv.GetItemString(rowNum, "sender_nm");  //답장수신자명
                //ReplyForm dlg = new ReplyForm(this, senderID, senderName, btnReply);
                ReplyForm dlg = new ReplyForm(this, this.grdRecv.LayoutTable.Rows[this.grdRecv.CurrentRowNumber], senderID, senderName, btnReply);

                // <<2014.01.03>> LKH START : 답신 후 해당 메세지는 확인 처리한다.
                //dlg.ShowDialog(this);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    //this.grdRecv.QueryLayout(true);
                    this.GetReceiveMsgList();
                    if ((rowNum + 1) > this.grdRecv.RowCount) rowNum = this.grdRecv.RowCount - 1;
                    if (rowNum >= 0) this.grdRecv.SetFocusToItem(rowNum, 1);
                }
                // <<2014.01.03>> LKH END   : 답신 후 해당 메세지는 확인 처리한다.

				dlg.Dispose();
			}
		}

		private void grdRecv_DoubleClick(object sender, System.EventArgs e)
		{
			//Double Click시에 답장창 PopUp
			this.btnReply.PerformClick();
		}

		private void cbxSendDel_CheckedChanged(object sender, System.EventArgs e)
		{
			//리스트 조회시 Check 변경시에는 아래 작업 수행하지 않음
			if (!this.isCallCheckedChanged) return;

			//전체삭제 Check
            string dataValue = "N";
            if (cbxSendDel.Checked)
            {
                dataValue = "Y";
            }
            for (int i = 0; i < grdSend.RowCount; i++)
            {
                grdSend.SetItemValue(i, "del_yn", dataValue);
                //원 확인여부가 N이건은 삭제 Check시에 확인도 Check
                if ((dataValue == "Y") && (grdSend.GetItemString(i, "orig_cnfm_yn") == "N"))
                    grdSend.SetItemValue(i, "cnfm_yn", "Y");
            }
        }

        private void cbxSendCnfm_CheckedChanged(object sender, EventArgs e)
        {
            //리스트 조회시 Check 변경시에는 아래 작업 수행하지 않음
            if (!this.isCallCheckedChanged) return;
            string dataValue = "N";
            if (cbxSendCnfm.Checked)
                dataValue = "Y";
            for (int i = 0; i < grdSend.RowCount; i++)
            {
                //원확인건이 N인 건만 확인 변경
                if (grdSend.GetItemString(i, "orig_cnfm_yn") == "N")
                    grdSend.SetItemValue(i, "cnfm_yn", dataValue);
            }
        }

        private void cbxRecvDel_CheckedChanged(object sender, System.EventArgs e)
		{
            
			//리스트 조회시 Check 변경시에는 아래 작업 수행하지 않음
			if (!this.isCallCheckedChanged) return;
			//전체삭제 Check
            string dataValue = "N";
            if (cbxRecvDel.Checked) 
            {
                dataValue = "Y";
            }
            for (int i = 0; i < grdRecv.RowCount; i++)
			{
                grdRecv.SetItemValue(i, "del_yn", dataValue); 
                //원 확인여부가 N이건은 삭제 Check시에 확인도 Check
                if ((dataValue == "Y") && (grdRecv.GetItemString(i, "orig_cnfm_yn") == "N")) 
                    grdRecv.SetItemValue(i, "cnfm_yn", "Y");
			}
		}

		private void cbxRecvCnfm_CheckedChanged(object sender, System.EventArgs e)
		{
			//리스트 조회시 Check 변경시에는 아래 작업 수행하지 않음
			if (!this.isCallCheckedChanged) return;
			string dataValue = "N";
			if (cbxRecvCnfm.Checked)
				dataValue = "Y";
			for (int i = 0 ; i < grdRecv.RowCount ; i++)
			{
				//원확인건이 N인 건만 확인 변경
				if (grdRecv.GetItemString(i, "orig_cnfm_yn") == "N")
					grdRecv.SetItemValue(i, "cnfm_yn", dataValue);
			}
		}

		private void cbxRecvDeny_CheckedChanged(object sender, System.EventArgs e)
		{
			//Registry에 Flag Set
			string dataValue = (this.cbxRecvDeny.Checked ? "Y" : "N");
			SetRegistryValue(RKEY_MSG_RECV_DENY, dataValue);

		}
		private void cbxAlarm_CheckedChanged(object sender, System.EventArgs e)
		{
			//알람지정 Flag Registry에 SET
			string dataValue = (this.cbxAlarm.Checked ? "Y" : "N");
			SetRegistryValue(RKEY_MSG_RECV_ALARM, dataValue);
		}

		private void btnMySound_Click(object sender, System.EventArgs e)
		{
			//.wav 파일을 지정하여 자신만의 알람 Sound 지정하기
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "WAV 파일(*.wav)|*.wav";
			if (dlg.ShowDialog(this) != DialogResult.OK) return;

			//Sound 파일명 SET
			this.soundFileName = dlg.FileName;
			//Registry에 Sound 파일명 SET
			SetRegistryValue(RKEY_MSG_SOUND_FILE, this.soundFileName);
		}
		private void SetRegistryValue(string dataName, string dataValue)
		{
			try
			{
				/*RegistryKey rkey = Registry.LocalMachine;
				RegistryKey rkey1 = rkey.OpenSubKey("SOFTWARE\\IHIS\\USER", true);
				if (rkey1 == null)
				{
					rkey1 = rkey.CreateSubKey("SOFTWARE\\IHIS\\USER");
				}
				rkey1.SetValue(dataName, dataValue);
				rkey1.Close();*/
                CacheService.Instance.Set(Constants.CacheKeyCbo.CACHE_COMMON_ADMM_PREFIX + dataName, dataValue, TimeSpan.MaxValue);
			}
			catch{}
		}
		private string GetRegistryValue(string dataName, string defaultValue)
		{
			try
			{
				/*RegistryKey rkey = Registry.LocalMachine;
				RegistryKey rkey1 = rkey.OpenSubKey("SOFTWARE\\IHIS\\USER");
				if (rkey1 != null)
				{
					return rkey1.GetValue(dataName, defaultValue).ToString();
				}
				else
					return defaultValue;*/
                return CacheService.Instance.Get(Constants.CacheKeyCbo.CACHE_COMMON_ADMM_PREFIX + dataName, defaultValue).ToString();
			}
			catch
			{
				return string.Empty;
			}
		}

		#region 파일첨부처리
		private void btnAddFile_Click(object sender, System.EventArgs e)
		{
			AddFileForm dlg = new AddFileForm(this.addedFileItems);
			dlg.ShowDialog(this);
		}
		#endregion

		#region 파일첨부관리 서버의 IP, UserID, Pswd Get
		private bool GetFileServerInfo()
		{
			try
			{
				//2006.04.13 서비스를 CALL하지 않고, 고정처리함. IP는 EnvironInfo에서 가져옴
				this.fileServerIP = EnvironInfo.GetDownloadServerIP();
				this.fileServerUserID = FILE_USER_ID;
				this.fileServerPswd = FILE_USER_ID;
				
                //DataServiceSISO dsv = new DataServiceSISO();
                //dsv.ProductName = PROD_ID;
                //dsv.ServiceName = SVC_NAME;
                //dsv.WorkTp = 'D';
                ////Input없음, OutPut은 ServerIP, UserID, Password
                //dsv.SetOutValue("ServerIP",DataType.String,"");
                //dsv.SetOutValue("UserID",DataType.String,"");
                //dsv.SetOutValue("Password",DataType.String,"");
                //if (dsv.Call())
                //{
                //    this.fileServerIP = dsv.GetOutValue("ServerIP").ToString();
                //    this.fileServerUserID = dsv.GetOutValue("UserID").ToString();
                //    this.fileServerPswd = dsv.GetOutValue("Password").ToString();
                //}
				
				return true;
			}
			catch(Exception xe)
			{
				//https://sofiamedix.atlassian.net/browse/MED-10610
				//string msg = (NetInfo.Language == LangMode.Ko ? "첨부파일 서버정보조회 에러[" + xe.Message + "]"
				//	: "添付ファィルのサーバー情報照会エラー[" + xe.Message + "]");
				//XMessageBox.Show(msg);
				//XMessageBox.Show(xe.StackTrace);
				return false;
			}
		}
		#endregion

		#region 수신첨부파일 Grid 버튼 Click(해당수신건의 첨부파일 리스트를 보여줌)
		private void grdRecv_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
		{
			if (e.ColName == "file_atch_yn")
			{
				AddFileListForm dlg = new AddFileListForm(this, e.DataRow["send_dt"].ToString(), e.DataRow["sender_id"].ToString(), e.DataRow["send_seq"].ToString());
				dlg.ShowDialog(this);
			}
		}
		#endregion

		#region SetControlNameByLangMode (일본어 변경)
		private void SetControlNameByLangMode()
		{
			//파일 첨부 Text Set
			this.btnAddFile.Text = (NetInfo.Language == LangMode.Ko ? "파일\n" + "첨부" :"ファィル\n" + "添付") ;

			if (NetInfo.Language == LangMode.Jr)
			{
				//Popup 메뉴
				this.menuShow.Text = "開く";//"열  기";
				this.menuHide.Text = "閉じる";//"닫  기";
				//tabpage
				this.tabPage1.Text = "メッセージ受信";//"메세지 받기";
				this.tabPage2.Text = "メッセージ送信";//"메세지 보내기";
				//Radio, Check,groupBox
				this.rbxRecvAll.Text = "全体照会";//"전체조회";
				this.rbxRecvYes.Text = "確認照会";//"확인조회";
				this.rbxRecvNo.Text = "未確認照会";//"미확인조회";
				this.rbxSendAll.Text = "全体照会";//"전체조회";
				this.rbxSendYes.Text = "確認照会"; //"확인조회";
				this.rbxSendNo.Text = "未確認照会"; //"미확인조회";
				this.cbxSendAllCnfm.Text = "全体確認";//"전체확인";
				this.cbxRecvDeny.Text = "受信保留";//"수신 보류";
				this.cbxAlarm.Text = "受信の際、アラム";//"수신시 알람";
				this.gbxSendMsgList.Text = "送信済みリスト";//"보낸 메세지 목록";
				this.gbxWriteMsg.Text = "書き込み";//"글쓰기";
				this.gbxResvMemo.Text = "予約文";//"예약글";
				//Label
				this.lbSendQryDate.Text = "照会日付";//"조회일자";
				this.lbRecvQryDate.Text = "照会日付";//"조회일자";
				this.lbMsgContents.Text = "内   容";//"내   용";
				this.lbMsgTitle.Text = "タイトル";//"제   목";
				this.lbRecver.Text = "受信先";//"수신자";
				this.lbResvMsgTitle.Text = "タイトル";//"제 목";

				//버튼
				this.btnReply.Text = "返 信";//"답 장";
				this.btnRecvCnfm.Text = "メッセージ確認(削除)";//"메세지확인(삭제)";
				this.btnCloseRecv.Text = "閉じる";//"닫 기";
                //this.btnDeleteSend.Text = "送信メッセージ削除";//"보낸 메세지 삭제";
                this.btnDeleteSend.Text = "メッセージ確認(削除)";//"메세지확인(삭제)";
                this.btnSendDetail.Text = "送信メッセージ詳細";//"수신현황 조회";
				this.btnCloseSend.Text = "閉じる";//"닫 기";
				this.btnClear.Text = "クリアー";//"초기화";
				this.btnSend.Text = "送  信";//"글올리기";
				this.btnSearch.Text = "受信先の指定";//"수신자 지정";
				this.btnResvCopy.Text = "予約文挿入";//"예약글복사";
				this.btnResvAdd.Text = "追 加";//"추 가";
				this.btnResvDelete.Text = "削 除";//"삭 제";
				this.btnMySound.Text = "アラム音の設定";//"알람사운드 지정";
				this.btnUserChange.Text = "ユーザー変更";   //사용자 변경

				//ToolTip
				//"메세지를 받을때 메세지 수신창을 띄우지 않습니다."
				this.toolTip1.SetToolTip(this.cbxRecvDeny, "メッセージ受信時は受信ウィンドウを表示しません。");
				//"메세지를 받을때 알람을 울립니다."
				this.toolTip1.SetToolTip(this.cbxAlarm, "メッセージ受信時アラムを鳴らします。");
				//"메세지를 받을때 울릴 알람 사운드를 지정합니다."
				this.toolTip1.SetToolTip(this.btnMySound,"メッセージ受信時のお知らせサウンドを指定します。" );

				//Grid Header
				grdResv[0, 0].Value = "タイトル";//제목
				grdResv[0, 1].Value = "予約文";//예약글

                grdSend[0, 1].Value = "確認"; //확인
                grdSend[0, 2].Value = "削除"; //삭제
				grdSend[0, 3].Value = "作成日"; //작성일
				grdSend[0, 4].Value = "作成時刻"; //작성시각
				grdSend[0, 5].Value = "タイトル"; //제목
				grdSend[0, 6].Value = "内容"; //내용
                //grdSend[0, 6].Value = "全体\r\n" + "確認"; //전체확인
                grdSend[0, 7].Value = "受信\r\n" + "人数"; //수신자수
                //grdSend[0, 7].Value = "全体\r\n" + "受信"; //전체수신
				grdSend[0, 8].Value = "添付"; //파일첨부

				grdRecv[0, 1].Value = "確認"; //확인
				grdRecv[0, 2].Value = "削除"; //삭제
				grdRecv[0, 3].Value = "作成日"; //작성일
				grdRecv[0, 4].Value = "作成時刻"; //작성시각
                grdRecv[0, 5].Value = "送信元"; //보낸곳
				grdRecv[0, 6].Value = "作成者"; //작성자
				grdRecv[0, 7].Value = "タイトル"; //제목
				grdRecv[0, 8].Value = "内容"; //내용
				grdRecv[0, 9].Value = "受信先"; //받은곳
				grdRecv[0, 10].Value = "添付"; //첨부

				this.xEditGridCell30.ButtonText = "ファィル"; //파일
			}
		}
		#endregion

		#region 사용자 변경 처리
		private void btnUserChange_Click(object sender, System.EventArgs e)
		{
			UserChangeForm dlg = new UserChangeForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				bool isUserChanged = false;
				bool isSuccess = false;
				//추가된 사용자이면 AMSG 사용자가 있으면 사용자 변경, 없으면 AMSG 사용자로 추가
				if (dlg.IsAddedUser)
				{
					foreach (UserItem item in MainForm.UserItemList)
					{
						if (item.SystemID == MSG_SYS_ID)  //ADMM 사용자이면 사용자변경
						{
							//사용자 ID, 비밀번호 변경
							string bfUserID = item.UserID;
							item.UserID = dlg.SelectedUserItem.UserID;
							item.UserName = dlg.SelectedUserItem.UserName;
							//사용자 변경 Service Call
							UserInfoUtil.ChangeSystemUser(MSG_SYS_ID, bfUserID, item.UserID);
							//현재 사용자 변경
							MainForm.CurrUserID = item.UserID;

							//Flag set
							isUserChanged = true;
							isSuccess = true;
							break;
						}
					}
					//ADMM User가 없으면 AMSG 사용자 등록
					if (!isUserChanged)
					{
						//메세지 시스템 사용자 등록
						UserInfoUtil.RegisterSystemUser(MSG_SYS_ID, dlg.SelectedUserItem.UserID);

						string sysName = (NetInfo.Language == LangMode.Ko ? "메세지시스템" : "メッセージシステム");
						MainForm.UserItemList.Add(new UserItem(dlg.SelectedUserItem.UserID, dlg.SelectedUserItem.UserName, MSG_SYS_ID, sysName));
						MainForm.CurrUserID = dlg.SelectedUserItem.UserID;
						isSuccess = true;
					}
				}
				else  //다른 사용자를 선택하였으면 현재사용자 변경
				{
					MainForm.CurrUserID = dlg.SelectedUserItem.UserID;
					isSuccess = true;
				}
				//사용자 변경 성공시 기존내역 Clear 및 재조회
				if (isSuccess)
				{
					//Title Set
					this.Text = (NetInfo.Language == LangMode.Ko ? "메세지시스템 사용자ID[" + MainForm.CurrUserID + "]"
						:"メッセージシステム ユーザーID[" + MainForm.CurrUserID + "]");

					//조회일 Default로 SET
					SetDefaultQryDate();

					this.GetReceiveMsgList();
					this.GetSendMsgList();
					this.GetReservedMsgList();
					//보내는 메세지 초기화
					this.btnClear.PerformClick();
					//예약글 입력 Control 초기화
					this.txtResvTitle.Text = "";
					this.txtResvMsg.Text = "";
				}
			}
		}
		#endregion

        private void grdRecv_QueryStarting(object sender, CancelEventArgs e)
        {
            string querytype = "";

            this.grdRecv.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdRecv.SetBindVarValue("f_user_id", MainForm.currUserID);
            this.grdRecv.SetBindVarValue("f_frdt", this.dtpRecvFrdt.GetDataValue());
            this.grdRecv.SetBindVarValue("f_todt", this.dtpRecvTodt.GetDataValue());
            if (this.rbxRecvAll.Checked)
            {
                querytype = "%";
            }
            else if (this.rbxRecvYes.Checked)
            {
                querytype = "Y";
            }
            else if (this.rbxRecvNo.Checked)
            {
                querytype = "N";
            }

            this.grdRecv.SetBindVarValue("f_qry_tp", querytype);
        }

        private void grdSend_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdSend.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdSend.SetBindVarValue("f_user_id", MainForm.currUserID);
            this.grdSend.SetBindVarValue("f_frdt", this.dtpRecvFrdt.GetDataValue());
            this.grdSend.SetBindVarValue("f_todt", this.dtpRecvTodt.GetDataValue());
            string querytype = "";

            if (this.rbxSendAll.Checked)
            {
                querytype = "%";
            }
            else if (this.rbxSendNo.Checked)
            {
                querytype = "N";
            }
            else if (this.rbxSendYes.Checked)
            {
                querytype = "Y";
            }

            this.grdSend.SetBindVarValue("f_qry_tp", querytype);
        }

        private void grdResv_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdResv.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdResv.SetBindVarValue("f_user_id", MainForm.currUserID);
        }

        private void dtpRecvFrdt_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.GetReceiveMsgList();
        }

        private void dtpRecvTodt_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.GetReceiveMsgList();
        }

	}	

	#region UserItem
	/// <summary>
	/// 업뭇시스템에 접속한 사용자 정보
	/// </summary>
	internal class UserItem
	{
		private string userID = "";
		private string userName = "";
		private string systemID = "";  //LOGIN한 시스템
		private string systemName = ""; //LOGIN한 시스템명
		public string UserID 
		{
			get { return userID;}
			set { userID = value;}
		}
		public string UserName 
		{
			get { return userName;}
			set { userName = value;}
		}
		public string SystemID 
		{
			get { return systemID;}
			set { systemID = value;}
		}
		public string SystemName 
		{
			get { return systemName;}
			set { systemName = value;}
		}
		public UserItem(string userID, string userName, string systemID, string systemName)
		{
			this.userID = userID;
			this.userName = userName;
			this.systemID = systemID;
			this.systemName = systemName;
		}
	}
	#endregion

	#region AddedFileItem (첨부파일 Item)
	internal class AddedFileItem
	{
		private string fileName = "";  //파일명만 관리
		private string fullName = "";  //전체경로를 포함한 파일명
		private string uniqueName = ""; //GUID로 부여한 Unique한 파일명
		public string FileName
		{
			get { return fileName;}
			set { fileName = value;}
		}
		public string FullName
		{
			get { return fullName;}
			set { fullName = value;}
		}
		public string UniqueName
		{
			get { return uniqueName;}
			set { uniqueName = value;}
		}
		public AddedFileItem(string fileName, string fullName)
		{
			this.fileName = fileName;
			this.fullName = fullName;
		}
		public AddedFileItem()
		{
		}
	}
	#endregion
}