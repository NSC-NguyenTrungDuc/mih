using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Resources;
using System.Windows.Forms;
using System.Xml;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework.Properties;
using Microsoft.Win32;
using IHIS.X.Magic.Docking;
using IHIS.X.Magic.Menus;
using IHIS.CloudConnector.Contracts.Results;

namespace IHIS.Framework
{
    /// <summary>
    /// MdiForm에 대한 요약 설명입니다.
    /// </summary>
    public class MdiForm : System.Windows.Forms.Form
    {
        #region User Msg Define
        const int MSG_IHIS_INSTANCE_FOCUS = (int)(Win32.Msgs.WM_USER + 101);
        const int MSG_SYSTEM_INSTANCE_FOCUS = (int)(Win32.Msgs.WM_USER + 102);
        const int MSG_SYSTEM_WINDOW_HANDLE_SEND = (int)(Win32.Msgs.WM_USER + 103);
        const int MSG_SYSTEM_USER_LOGIN = (int)(Win32.Msgs.WM_USER + 106); //사용자 LOGIN MSG
        const int MSG_SYSTEM_USER_LOGOUT = (int)(Win32.Msgs.WM_USER + 107); //사용자 LOGOUT MSG
        const int MSG_SYSTEM_USER_CHANGED = (int)(Win32.Msgs.WM_USER + 108); //사용자변경을 IHIS에 알림
        const int MSG_XMSG_DISPLAY = (int)(Win32.Msgs.WM_USER + 111); //메세지 보기 MSG
        #endregion

        #region Fields
        const string DOCKING_REGISTRY_PATH = "SOFTWARE\\IHIS\\DOCKING\\";  //Docking 메뉴 관리 Registry Key Path
        private Font DEFAULT_FONT = new Font("MS UI Gothic", 9.75F);
        private System.ComponentModel.IContainer components = null;
        private IHIS.X.Magic.Menus.MenuControl mdiMenu = null;
        private System.Windows.Forms.StatusBar mdiStatusBar;
        //StatusBar내 ProgressBar 관련
        private XStatusProgressBar sProgBar = null;
        private MenuItem myMenuItem = null;  //MyMenu를 관리하는 MenuItem

        private ResourceManager imageResource;
        private IHIS.Framework.XTabControl mdiTabControl = null;

        private IHIS.X.Magic.Controls.TabPage tabPageMouseHovered = null;

        // Context Menus
        protected IHIS.X.Magic.Menus.PopupMenu tabContextMenu = new PopupMenu();

        // Docking
        private DockingManager dockManager = null;
        private MenuViewForm menuViewForm = null;

        // MdiClient 및 Background Image
        private MdiClient mdiClient = null;
        private Bitmap backImage = null;
        private Size oldClientSize = new Size(0, 0);

        private System.Windows.Forms.StatusBarPanel pnlMessage;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.StatusBarPanel pnlUserName;
        private System.Windows.Forms.StatusBarPanel pnlDeptName;
        private System.Windows.Forms.StatusBarPanel pnlTrmNo;
        private System.Windows.Forms.StatusBarPanel pnlWorkTime;

        private bool initFail = false;
        private bool isAddedTabStubHandler = false; //Docking된 화면Open시에 TabStubClickAtContentHidden Event를 연결했는지 여부

        //Docking하는 화면을 관리하는 환자명단 메뉴 관련
        private ArrayList checkMenuList = new ArrayList(); //체크형식의 메뉴의 List
        private Hashtable checkMenuItemList = new Hashtable(); //체크메뉴의 ScreenItem을 관리하는 List

        // <<2013.12.08>> LKH : 사용자 변경 전 사용자 ID
        private String m_preUserID = "";

        #endregion

        #region 그룹,시스템관련 정보 Fields, Properties
        // 업무시스템 정보
        private string groupID = "";
        private string groupName = "";
        private string systemID = "";
        private string systemName = "";

        private int X1, Y1, X2, Y2;

        public string GroupID
        {
            get { return groupID; }
        }
        public string GroupName
        {
            get { return groupName; }
        }
        public string SystemID
        {
            get { return systemID; }
        }
        public string SystemName
        {
            get { return systemName; }
        }
        //이 시스템에서 Open된 Group, System의 List
        //Key값은 GroupID, SystemID로 하고, Value는 DirName(그룹Delegator를 Call한 
        private Hashtable openedGroupList = new Hashtable();
        private StatusBarPanel pnlHyperLink;
        private Hashtable openedSystemList = new Hashtable();
        #endregion

        #region Constructor

        public MdiForm()
        {
            //Thread.CurrentThread.CurrentCulture = XLocalizable.CultureInfo;
            //Thread.CurrentThread.CurrentUICulture = XLocalizable.CultureInfo;
            //
            // Windows Form 디자이너 지원에 필요합니다.
            //

            InitializeComponent();

            // Designer에서 지원되지 않는 속성 Set
            this.mdiTabControl.Appearance = IHIS.X.Magic.Common.VisualAppearance.MultiBox;
            this.mdiTabControl.HotTrack = true;
            this.mdiTabControl.ShowArrows = true;
            this.mdiTabControl.ShowClose = true;
            this.mdiTabControl.ShrinkPagesToFit = false;
            this.mdiTabControl.Dock = DockStyle.Top;

            //Status ProgressBar Set
            this.sProgBar = new XStatusProgressBar(this.progressBar, this.mdiStatusBar, 0);

            //StatusBar Set
            SetStatusBar(UserInfo.UserName, UserInfo.BuseoName, UserInfo.UserID);
        }
        public MdiForm(string groupID, string groupName, string systemID, string systemName)
            : this()
        {
            // 시스템 SET
            this.groupID = groupID;
            this.groupName = groupName;
            this.systemID = systemID;
            this.systemName = systemName;
        }
        #endregion

        #region Dispose
        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MdiForm));
            this.mdiStatusBar = new System.Windows.Forms.StatusBar();
            this.pnlMessage = new System.Windows.Forms.StatusBarPanel();
            this.pnlHyperLink = new System.Windows.Forms.StatusBarPanel();
            this.pnlUserName = new System.Windows.Forms.StatusBarPanel();
            this.pnlDeptName = new System.Windows.Forms.StatusBarPanel();
            this.pnlTrmNo = new System.Windows.Forms.StatusBarPanel();
            this.pnlWorkTime = new System.Windows.Forms.StatusBarPanel();
            this.mdiTabControl = new IHIS.Framework.XTabControl();
            this.mdiClient = new System.Windows.Forms.MdiClient();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHyperLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDeptName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTrmNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWorkTime)).BeginInit();
            this.SuspendLayout();
            // 
            // mdiStatusBar
            // 
            this.mdiStatusBar.AccessibleDescription = null;
            this.mdiStatusBar.AccessibleName = null;
            resources.ApplyResources(this.mdiStatusBar, "mdiStatusBar");
            this.mdiStatusBar.BackgroundImage = null;
            this.mdiStatusBar.Font = null;
            this.mdiStatusBar.Name = "mdiStatusBar";
            this.mdiStatusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.pnlMessage,
            this.pnlHyperLink,
            this.pnlUserName,
            this.pnlDeptName,
            this.pnlTrmNo,
            this.pnlWorkTime});
            this.mdiStatusBar.ShowPanels = true;
            this.mdiStatusBar.SizingGrip = false;
            this.mdiStatusBar.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.mdiStatusBar_PanelClick);
            this.mdiStatusBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mdiStatusBar_MouseMove);
            this.mdiStatusBar.DrawItem += new System.Windows.Forms.StatusBarDrawItemEventHandler(this.mdiStatusBar_DrawItem);
            this.mdiStatusBar.MouseHover += new System.EventHandler(this.mdiStatusBar_MouseHover);
            // 
            // pnlMessage
            // 
            resources.ApplyResources(this.pnlMessage, "pnlMessage");
            this.pnlMessage.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.pnlMessage.Icon = null;
            // 
            // pnlHyperLink
            // 
            resources.ApplyResources(this.pnlHyperLink, "pnlHyperLink");
            this.pnlHyperLink.Icon = null;
            // 
            // pnlUserName
            // 
            resources.ApplyResources(this.pnlUserName, "pnlUserName");
            this.pnlUserName.Icon = null;
            // 
            // pnlDeptName
            // 
            resources.ApplyResources(this.pnlDeptName, "pnlDeptName");
            this.pnlDeptName.Icon = null;
            // 
            // pnlTrmNo
            // 
            resources.ApplyResources(this.pnlTrmNo, "pnlTrmNo");
            this.pnlTrmNo.Icon = null;
            // 
            // pnlWorkTime
            // 
            resources.ApplyResources(this.pnlWorkTime, "pnlWorkTime");
            this.pnlWorkTime.Icon = null;
            // 
            // mdiTabControl
            // 
            this.mdiTabControl.AccessibleDescription = null;
            this.mdiTabControl.AccessibleName = null;
            resources.ApplyResources(this.mdiTabControl, "mdiTabControl");
            this.mdiTabControl.BackgroundImage = null;
            this.mdiTabControl.Font = null;
            this.mdiTabControl.IDEPixelArea = true;
            this.mdiTabControl.IDEPixelBorder = false;
            this.mdiTabControl.Name = "mdiTabControl";
            this.mdiTabControl.SelectionChanged += new System.EventHandler(this.OnTabControlSelectionChanged);
            this.mdiTabControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnTabControlMouseUp);
            this.mdiTabControl.ClosePressed += new System.EventHandler(this.OnTabControlClosePressed);
            this.mdiTabControl.SelectionChanging += new System.EventHandler(this.OnTabControlSelectionChanging);
            // 
            // mdiClient
            // 
            this.mdiClient.AccessibleDescription = null;
            this.mdiClient.AccessibleName = null;
            resources.ApplyResources(this.mdiClient, "mdiClient");
            this.mdiClient.BackgroundImage = null;
            this.mdiClient.Font = null;
            this.mdiClient.Name = "mdiClient";
            // 
            // progressBar
            // 
            this.progressBar.AccessibleDescription = null;
            this.progressBar.AccessibleName = null;
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.BackgroundImage = null;
            this.progressBar.Font = null;
            this.progressBar.Name = "progressBar";
            // 
            // MdiForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = null;
            this.Controls.Add(this.mdiTabControl);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.mdiStatusBar);
            this.Controls.Add(this.mdiClient);
            this.IsMdiContainer = true;
            this.Name = "MdiForm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHyperLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDeptName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTrmNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWorkTime)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region OnActivated
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            // 활성화 될때 환경정보 다시 설정
            // 환경정보는 전체에 하나, 각 업무시스템은 여러개이므로
            // 업무시스템이 활성화 될때 현재업무시스템의 메뉴를 설정
            // 현재업무시스템 정보 다시 설정
            EnvironInfo.MdiForm = this;
            EnvironInfo.CurrGroupID = this.groupID;
            EnvironInfo.CurrGroupName = this.groupName;
            EnvironInfo.CurrSystemID = this.systemID;
            EnvironInfo.CurrSystemName = this.systemName;

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(System.EventArgs e)
        {

            //ImageResouce Get
            imageResource = new ResourceManager("IHIS.Framework.IHISImage", Assembly.GetExecutingAssembly());

            // Background Image (IHIS/Images/MdiForm.bmp로 설정함, 2006.02.02 Resource에서 가져오지 않고 동적으로 생성)
            try
            {
                CloudService.Instance.Connect();

                String ServerType = Service.GetConfigString("SERVER", "IP", "127.0.0.1");
                if (ServerType.Equals("192.168.11.11"))
                    EnvironInfo.IsReal = true;
                else
                    EnvironInfo.IsReal = false;

                string fileName = "";
                //fileName = EnvironInfo.ImagePath + "\\MdiForm.bmp";
                if (EnvironInfo.IsReal)
                    fileName = EnvironInfo.ImagePath + "\\MdiForm.bmp";
                else
                    fileName = EnvironInfo.ImagePath + "\\MdiFormDev.bmp";

                //
                if (File.Exists(fileName))
                    backImage = Image.FromFile(fileName) as Bitmap;
            }
            catch { }
            if (backImage != null)
                mdiClient.Layout += new LayoutEventHandler(mdiClient_Layout);

            // Docking Manager
            dockManager = new DockingManager(this, X.Magic.Common.VisualStyle.IDE);
            //dockManager.ZoneMinMax = true;
            //dockManager.CaptionFont = DEFAULT_FONT;
            //2005.09.14 dockManager의 FONT을 MS UI Gothic으로 할 경우 왼쪽 Docking된 메뉴보기등의 일본어
            //TITLE이 TEXT를 Size를 측정시에 더 작게 나옴. 그래서, Title이 잘려서 보인다.
            //이를 방지하기 위해 dockManager는 굴림체로 하여 처리한다.(일본어 이상없음)
            //dockManager.CaptionFont = new Font("굴림체", 9.75f);

            if (NetInfo.Language == LangMode.Jr)
            {
                dockManager.CaptionFont = DEFAULT_FONT;
            }
            else
            {
                dockManager.CaptionFont = Service.COMMON_FONT;
            }

            dockManager.OuterControl = mdiTabControl;

            // 환경정보에 MdiMenu 및 MdiForm 설정
            EnvironInfo.MdiMenu = this.mdiMenu;
            EnvironInfo.MdiForm = this;
            EnvironInfo.CurrGroupID = this.groupID;
            EnvironInfo.CurrGroupName = this.groupName;
            EnvironInfo.CurrSystemID = this.systemID;
            EnvironInfo.CurrSystemName = this.systemName;

            //DesignMode시에는 더이상 기능 수행 없음
            if (this.DesignMode) return;

            //<MONITOR> 2006.12.04 Registry에 등록된 MDI의 모니터 위치를 고려하여 해당 모니터에 띄우기
            SetMDIPositionByRegistry();

            //Group, SystemDelgator Handling
            //openedGroupList, openedSystemList에 Add하고 Delegator의 Method Call
            this.HandlingDelegator(this.groupID, this.systemID);

            // Cloud Service
            MdiFormMainMenuResult menuResult = LoadAllMenu();

            // Main Menu 작성.
            CreateMainMenu(false, menuResult.Result, menuResult.Msg, menuResult.MenuItemInfo);

            // 메뉴보기 
            OpenMenuTree(true);

            // 환자리스트에 보여진 CheckMenu에서 초기에 선택된 메뉴 실행
            this.PerformCheckMenu();

            //Icon Set
            SetSystemIcon();

            //Text 설정
            this.Text = this.systemID + "[" + this.systemName + "]";

            //if (EnvironInfo.IsReal)
            //    this.Text = this.systemID + "[" + this.systemName + "]";
            //else
            //    this.Text = this.systemID + "[" + this.systemName + "]" + Resources.MdiForm_OnLoad_text;
            //
            //PC시간과 서버시간 동기화(가끔 TPEPROTO에러발생, 원인 확인후 처리해야함. 일단 COMMENT처리
            //기존에는 XMSG로 MSG_SYSTEM_USER_LOGIN을 보내고 시간 동기화를 했는데, 이 경우에는 TPEOS, TPEPROTO에러가
            //발생을 했음. 순서를 맨 마지막으로 변경하면서 에러가 발생하지 않음
            //<개발중> 개발중에서는 Server가 이전날짜이므로 경고창이 계속 떠서 일단 Comment 처리함.
            //SynchronizeSystemTime();

            //시스템 메인화면 OPEN
            OpenMainScreen(menuResult);

            //IHIS에 Handle 등록, LOGIN 처리
            SendLoginMsgToIHIS();
        }
        #endregion

        #region SetMDIPositionByRegistry (Registry에 지정된 모니터로 MDI 띄우기)
        protected virtual void SetMDIPositionByRegistry()
        {
            try
            {
                int mIndex = EnvironInfo.GetMDIMonitorIndex();  //mIndex는 1부터 시작 (1st Monitor, 2nd Monitor, ..)
                if (mIndex > 1) //첫번째 이상이면
                {
                    if (this.WindowState == FormWindowState.Maximized) //Maximize 상태에서는 이동불가하므로 Normal로
                        this.WindowState = FormWindowState.Normal;
                    Rectangle wRect = Screen.AllScreens[mIndex - 1].WorkingArea;
                    this.Location = new Point(wRect.X, wRect.Y);
                    //Maximize
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    //Maximize
                    this.WindowState = FormWindowState.Maximized;
                }
            }
            catch (Exception xe)
            {
                Logs.WriteLog("SetMDIPositionByRegistry Error=" + xe.Message);
            }
        }
        #endregion

        #region Protected override
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

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            //2006.01.11 MDI Close시에 MdiChild의 OnClosing을 호출하여 e.Cancel을 설정하는데,
            //메인화면의 경우 닫지 못하게 하므로 Mdi를 닫지 못하는 경우가 발생한다. 따라서, Mdi는 무조건 Close가능하도록 Cancel = false로 설정함
            e.Cancel = false;

            //시스템 종료시에 IHIS에 사용자 LOGOUT MSG 전달 wParam에 SystemID + "\t" + UserID
            IntPtr IHISHandle = EnvironInfo.FindIHISHandle();
            if (IHISHandle != IntPtr.Zero)
            {
                string param = this.SystemID + "\t" + UserInfo.UserID;
                IntPtr wParam = Marshal.StringToHGlobalAnsi(param);
                User32.SendMessage(IHISHandle, MSG_SYSTEM_USER_LOGOUT, wParam, IntPtr.Zero);
                //Memory 해제
                if (wParam != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(wParam);
            }

            //시스템사용자 등록해제
            UserInfoUtil.UnRegisterSystemUser(this.systemID, UserInfo.UserID);

        }
        #endregion

        #region CreateMainMenu, CreateManageMenu, CreateSystemMenu, RegenMyMenu
        protected virtual void CreateMainMenu(bool recreate, bool result, string msg, IEnumerable<MdiFormMenuItemInfo> listMenuItemInfo)
        {
            if (!recreate)
            {
                SuspendLayout();

                mdiMenu = new IHIS.X.Magic.Menus.MenuControl();
                mdiMenu.Font = DEFAULT_FONT;

                if (NetInfo.Language != LangMode.Jr)
                {
                    mdiMenu.Font = Service.COMMON_FONT;
                }

                // MainMenu 속성 Set
                mdiMenu.Dock = DockStyle.Top;
                mdiMenu.Style = IHIS.X.Magic.Common.VisualStyle.IDE;
                mdiMenu.MultiLine = true;
                mdiMenu.Animate = IHIS.X.Magic.Menus.Animate.System;
                mdiMenu.AnimateTime = 100;
                mdiMenu.MdiContainer = this;
            }

            //화면관리 메뉴 구성
            CreateManageMenu();
            //사용자 등록 메뉴 구성
            //2005.10.20 Menu영역이 작아 MyMenu를 보이지 않게 함(어디에 놓을지는 추후 확정후 반영)
            //CreateMyMenu(true);


            //각 업무시스템에서 화면메뉴 동적구성
            this.initFail = !CreateSystemMenu(result, msg, listMenuItemInfo);

            if (!recreate)
            {
                // Bind the MainMenu to Form
                Controls.Add(mdiMenu);
                ResumeLayout(true);
            }
        }
        private void CreateManageMenu()
        {
            #region 업무관리 Menu 작성
            string title = "";
            // 업무관리 =====================================
            title = XMsg.GetField("F017"); // 업무관리
            MenuItem managerMenu = new MenuItem(title, MenuFunc.None, (IList)mdiMenu.MenuCommands);
            // 업무전환
            title = XMsg.GetField("F018"); // 업무전환" : "業務転換");
            MenuItem chngSystemMenu = new MenuItem(title, new EventHandler(MenuClick), MenuFunc.ChangeSystem, GetIcon("ChangeSystem"), (IList)managerMenu.MenuCommands);
            // 메세지보기
            title = XMsg.GetField("F019"); // 메세지보기" : "メッセージ一覧");
            MenuItem msgViewMenu = new MenuItem(title, new EventHandler(MenuClick), MenuFunc.ViewMsg, GetIcon("ShowMessage"), (IList)managerMenu.MenuCommands);
            // 모니터 설정
            title = XMsg.GetField("F056"); // 모니터설정" : "モニター設定");
            MenuItem monitorMenu = new MenuItem(title, new EventHandler(MenuClick), MenuFunc.SelectMonitor, GetIcon("Program"), (IList)managerMenu.MenuCommands);
            // Separator
            MenuItem sepMenuF0 = new MenuItem("-", MenuFunc.None, (IList)managerMenu.MenuCommands);
            // TreeView Menu 보기
            title = XMsg.GetField("F020"); // 메뉴보기" : "メニュー一覧");
            MenuItem menuViewFormMenu = new MenuItem(title, new EventHandler(MenuClick), MenuFunc.ViewMenu, GetIcon("ViewMenu"), (IList)managerMenu.MenuCommands);
            // 메뉴재생성
            title = XMsg.GetField("F021"); // 메뉴재생성" : "メニュー再生成");
            MenuItem regenMenu = new MenuItem(title, new EventHandler(MenuClick), MenuFunc.RegenMenu, GetIcon("RegenMenu"), (IList)managerMenu.MenuCommands);
            // Separator
            MenuItem sepMenuF1 = new MenuItem("-", MenuFunc.None, (IList)managerMenu.MenuCommands);
            // 로그아웃
            title = XMsg.GetField("F022"); // 사용자로그아웃" : "ユーザーログアウト");
            MenuItem logoutMenu = new MenuItem(title, new EventHandler(MenuClick), MenuFunc.LogoutUser, GetIcon("LogoutUser"), (IList)managerMenu.MenuCommands);
            //사용자변경
            title = XMsg.GetField("F023"); // 사용자변경" : "ユーザー変更");
            MenuItem changeUserMenu = new MenuItem(title, new EventHandler(MenuClick), MenuFunc.UserChange, GetIcon("ChangeUser"), (IList)managerMenu.MenuCommands);
            //비밀번호 변경
            title = XMsg.GetField("F024"); // 비밀번호변경" : "バスワード変更");
            MenuItem changePswdMenu = new MenuItem(title, new EventHandler(MenuClick), MenuFunc.PswdChange, GetIcon("ChangePswd"), (IList)managerMenu.MenuCommands);
            // Separator
            MenuItem sepMenuF2 = new MenuItem("-", MenuFunc.None, (IList)managerMenu.MenuCommands);
            // 화면잠금
            title = XMsg.GetField("F025"); // 화면잠금" : "画面ロック");
            MenuItem leaveMenu = new MenuItem(title, new EventHandler(MenuClick), MenuFunc.Leave, GetIcon("Leave"), (IList)managerMenu.MenuCommands);
            // 화면인쇄
            title = XMsg.GetField("F026"); // 화면인쇄" : "画面印刷");
            MenuItem prtScreenMenu = new MenuItem(title, new EventHandler(MenuClick), MenuFunc.PrtScreen, GetIcon("Print"), (IList)managerMenu.MenuCommands);
            // 화면캡쳐
            title = XMsg.GetField("F027"); // 화면캡쳐" : "画面キャプチャー");
            MenuItem capScreenMenu = new MenuItem(title, new EventHandler(MenuClick), MenuFunc.CapScreen, GetIcon("PrintPreview"), (IList)managerMenu.MenuCommands);
            // Separator
            MenuItem sepMenuF3 = new MenuItem("-", MenuFunc.None, (IList)managerMenu.MenuCommands);
            // 창전체닫기
            title = XMsg.GetField("F028"); // 전체화면닫기" : "全体画面閉じる");
            MenuItem allCloseMenu = new MenuItem(title, new EventHandler(MenuClick), MenuFunc.AllClose, GetIcon("AllClose"), (IList)managerMenu.MenuCommands);
            // Separator
            MenuItem sepMenuF4 = new MenuItem("-", MenuFunc.None, (IList)managerMenu.MenuCommands);
            //사용자정보(나중에 처리)
            //			title = XMsg.GetField("F029"); // 사용자정보" : "ユーザー情報");
            //			MenuItem userInfoMenu = new MenuItem(title, new EventHandler(MenuClick), MenuFunc.UserInfo, GetIcon("ViewLog"), (IList)managerMenu.MenuCommands);
            // Separator
            //			MenuItem sepMenuF5 = new MenuItem("-", MenuFunc.None, (IList)managerMenu.MenuCommands);
            // 종료
            title = XMsg.GetField("F030"); // 끝내기" : "システム終了");
            MenuItem exitMenu = new MenuItem(title, new EventHandler(MenuClick), MenuFunc.Exit, GetIcon("Close"), (IList)managerMenu.MenuCommands);
            #endregion
        }

        private void CreateMyMenu(bool createMyMenuItem)
        {

            //업무관리메뉴 다음에 사용자메뉴를 두고 그 밑에 사용자가 등록한 메뉴 SET
            //createMyMenuItem은 최초생성시 true, 메뉴일람에서 변경후 반영시는 false로 하여 생성하지 않음
            if (createMyMenuItem)
            {
                // 사용자메뉴 =====================================
                string title = "[" + UserInfo.UserName + "]" + XMsg.GetField("F031"); //[ + UserInfo.UserName + "]님즐겨찾기
                this.myMenuItem = new MenuItem(title, MenuFunc.None, (IList)mdiMenu.MenuCommands);
            }
            /*마이메뉴 생성 순서
             * PR_ADM_GEN_MY_MENU Call 마이메뉴 생성
             * ADM4500(사용자 즐겨찾기 메뉴) 조회하여 즐겨찾기 메뉴 구성
             */
            string spName = "PR_ADM_GEN_MY_MENU";
            //Input = 사용자 ID
            //실패시 Msg Set
            if (!Service.ExecuteProcedure(spName, UserInfo.UserID))
            {
                SetMsg(Service.ErrMsg, MsgType.Error);
                return;
            }

            string cmdText
                = "SELECT A.MENU_TP, A.MENU_LEVEL, A.TR_ID, A.MENU_TITLE, A.PGM_ID, A.PGM_OPEN_TP, A.MENU_PARAM "
                + "  FROM ADM4500 A "
                + " WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + "'"
                + "   AND A.USER_ID = '" + UserInfo.UserID + "'";

            DataTable table = Service.ExecuteDataTable(cmdText);
            if (table != null)  //조회 성공시
            {
                string menuLevel = "";
                //총 9단계 까지만 적용(더이상을 등록하지 않음)
                MyMenuItem menuL1 = null, menuL2 = null, menuL3 = null, menuL4 = null, menuL5 = null, menuL6 = null, menuL7 = null, menuL8 = null, menuL9 = null;
                foreach (DataRow dtRow in table.Rows)
                {
                    menuLevel = dtRow[0].ToString();
                    switch (menuLevel)
                    {
                        case "1":
                            menuL1 = new MyMenuItem(dtRow, new EventHandler(MenuClick), (IList)myMenuItem.MenuCommands);
                            break;
                        case "2":
                            if (menuL1 != null)
                                menuL2 = new MyMenuItem(dtRow, new EventHandler(MenuClick), (IList)menuL1.MenuCommands);
                            break;
                        case "3":
                            if (menuL2 != null)
                                menuL3 = new MyMenuItem(dtRow, new EventHandler(MenuClick), (IList)menuL2.MenuCommands);
                            break;
                        case "4":
                            if (menuL3 != null)
                                menuL4 = new MyMenuItem(dtRow, new EventHandler(MenuClick), (IList)menuL3.MenuCommands);
                            break;
                        case "5":
                            if (menuL4 != null)
                                menuL5 = new MyMenuItem(dtRow, new EventHandler(MenuClick), (IList)menuL4.MenuCommands);
                            break;
                        case "6":
                            if (menuL5 != null)
                                menuL6 = new MyMenuItem(dtRow, new EventHandler(MenuClick), (IList)menuL5.MenuCommands);
                            break;
                        case "7":
                            if (menuL6 != null)
                                menuL7 = new MyMenuItem(dtRow, new EventHandler(MenuClick), (IList)menuL6.MenuCommands);
                            break;
                        case "8":
                            if (menuL7 != null)
                                menuL8 = new MyMenuItem(dtRow, new EventHandler(MenuClick), (IList)menuL7.MenuCommands);
                            break;
                        case "9":
                            if (menuL8 != null)
                                menuL9 = new MyMenuItem(dtRow, new EventHandler(MenuClick), (IList)menuL8.MenuCommands);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private bool CreateSystemMenu()
        {
            //체크 메뉴 (환자명단) 리스트 Clear
            //환자명단 메뉴 List에는 화면시스템ID.화면ID로 string 관리
            //checkMenuItemList에는 Key로 화면시스템ID.화면ID, value에 ScreenMenuItem 관리
            this.checkMenuList.Clear();
            this.checkMenuItemList.Clear();

            /* 메뉴 작성 순서
             * 1.PR_ADM_GEN_MENU CALL (INPUT 사용자ID, 시스템 ID)
             * ADM4300(사용자메뉴 구성)에서 데이타 조회
             */

            string spName = "PR_ADM_GEN_MENU";
            //Input = 사용자 ID
            //실패시 Msg Set
            if (!Service.ExecuteProcedure(spName, UserInfo.UserID, this.systemID))
            {
                SetMsg(Service.ErrMsg, MsgType.Error);
                return false;
            }

            string cmdText
                = "SELECT A.MENU_LEVEL, A.MENU_TP, A.PGM_NM, A.TR_ID, A.PGM_ID, A.PGM_SYS_ID, A.PGM_ENT_GRAD, A.PGM_UPD_GRAD, A.PGM_SCRT,"
                + "       A.PGM_DUP_YN, A.PGM_OPEN_TP, A.SHORT_CUT, A.ASM_NAME, A.ASM_PATH, A.ASM_VER, A.MENU_PARAM "
                + "  FROM ADM4300 A"
                + " WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + "'"
                + "   AND A.USER_ID = '" + UserInfo.UserID + "'"
                + "   AND A.SYS_ID  = '" + this.systemID + "'"
                + " ORDER BY A.SEQ";

            DataTable table = Service.ExecuteDataTable(cmdText);
            if (table == null) //조회 실패
            {
                SetMsg(Service.ErrMsg, MsgType.Error);
                return false;
            }

            // 사용자 업무 Menu 동적구성
            string menuLevel, pgmID;
            ScreenMenuItem menuL1 = null, menuL2 = null, menuL3 = null;
            bool isCheckMenu = false;
            foreach (DataRow dtRow in table.Rows)
            {
                menuLevel = dtRow[0].ToString();
                pgmID = dtRow[4].ToString();
                //첫번째 메뉴ID(PGMID)가 PALIST이면 이후 메뉴는 Check 메뉴로 적용
                if (menuLevel == "1")
                {
                    if (pgmID == "PALIST")
                        isCheckMenu = true;
                    else
                        isCheckMenu = false;
                }
                switch (menuLevel)
                {
                    case "1":			// Level 1 Menu
                        menuL1 = new ScreenMenuItem(dtRow, new EventHandler(MenuClick), (IList)mdiMenu.MenuCommands);
                        break;
                    case "2":			// Level 2 Menu
                        if (menuL1 != null)
                        {
                            if (isCheckMenu)  //환자 LIST Docking 화면
                            {
                                //Event Handling은 MenuChecked에서 처리함.
                                menuL2 = new ScreenMenuItem(dtRow, new EventHandler(MenuChecked), (IList)menuL1.MenuCommands);
                                //체크메뉴 List에는 화면ID(UNIQUE)관리
                                //checkMenuItemList에는 KeyName과 해당하는 ScreenMenuItem 관리
                                this.checkMenuList.Add(pgmID);
                                this.checkMenuItemList.Add(pgmID, menuL2);
                            }
                            else
                                menuL2 = new ScreenMenuItem(dtRow, new EventHandler(MenuClick), (IList)menuL1.MenuCommands);
                        }
                        break;
                    case "3":			// Level 3 Menu
                        if (menuL2 != null)
                        {
                            menuL3 = new ScreenMenuItem(dtRow, new EventHandler(MenuClick), (IList)menuL2.MenuCommands);
                        }
                        break;
                }
            }
            return true;
        }
        private bool CreateSystemMenu(bool result, string msg, IEnumerable<MdiFormMenuItemInfo> listMenuItemInfo)
        {
            //체크 메뉴 (환자명단) 리스트 Clear
            //환자명단 메뉴 List에는 화면시스템ID.화면ID로 string 관리
            //checkMenuItemList에는 Key로 화면시스템ID.화면ID, value에 ScreenMenuItem 관리
            this.checkMenuList.Clear();
            this.checkMenuItemList.Clear();

            /* 메뉴 작성 순서
             * 1.PR_ADM_GEN_MENU CALL (INPUT 사용자ID, 시스템 ID)
             * ADM4300(사용자메뉴 구성)에서 데이타 조회
             */
            // Cloud service
            if (!result)
            {
                SetMsg(msg, MsgType.Error);
                return false;
            }

            if (listMenuItemInfo == null)
            {
                SetMsg("No response data", MsgType.Error);
                return false;
            }

            // 사용자 업무 Menu 동적구성
            string menuLevel, pgmID;
            ScreenMenuItem menuL1 = null, menuL2 = null, menuL3 = null;
            bool isCheckMenu = false;
            foreach (MdiFormMenuItemInfo item in listMenuItemInfo)
            {
                menuLevel = item.MenuLevel;
                pgmID = item.PgmId;
                //첫번째 메뉴ID(PGMID)가 PALIST이면 이후 메뉴는 Check 메뉴로 적용
                if (menuLevel == "1")
                {
                    if (pgmID == "PALIST")
                        isCheckMenu = true;
                    else
                        isCheckMenu = false;
                }
                switch (menuLevel)
                {
                    case "1":			// Level 1 Menu
                        menuL1 = new ScreenMenuItem(item, new EventHandler(MenuClick), (IList)mdiMenu.MenuCommands);
                        break;
                    case "2":			// Level 2 Menu
                        if (menuL1 != null)
                        {
                            if (isCheckMenu)  //환자 LIST Docking 화면
                            {
                                //Event Handling은 MenuChecked에서 처리함.
                                menuL2 = new ScreenMenuItem(item, new EventHandler(MenuChecked), (IList)menuL1.MenuCommands);
                                //체크메뉴 List에는 화면ID(UNIQUE)관리
                                //checkMenuItemList에는 KeyName과 해당하는 ScreenMenuItem 관리
                                this.checkMenuList.Add(pgmID);
                                this.checkMenuItemList.Add(pgmID, menuL2);
                            }
                            else
                                menuL2 = new ScreenMenuItem(item, new EventHandler(MenuClick), (IList)menuL1.MenuCommands);
                        }
                        break;
                    case "3":			// Level 3 Menu
                        if (menuL2 != null)
                        {
                            menuL3 = new ScreenMenuItem(item, new EventHandler(MenuClick), (IList)menuL2.MenuCommands);
                        }
                        break;
                }
            }
            return true;
        }
        //마이메뉴 다시 생성하기
        internal void RegenMyMenu()
        {
            //기존 마이 메뉴 Clear
            this.myMenuItem.MenuCommands.Clear();
            //마이메뉴 재생성(myMenuItem은 생성하지 않음)
            this.CreateMyMenu(false);
        }
        #endregion

        #region HandlingDelegator(시스템 Delegator Handling)
        internal void HandlingDelegator(string grpID, string sysID)
        {
            //Group, System Delegator Handling (현재는 GroupUserLogOn만 call하도록 설계함, 추후 필요에 따라
            //Delegator의 Method 추가할 예정임

            //기 OPEN된 Group List에 해당그룹이 없으면 CallOnGroupUserLogOn 하고 List 에 Add
            if (!this.openedGroupList.Contains(grpID))
            {
                CallOnGroupUserLogOn(grpID, sysID, true);
                this.openedGroupList.Add(grpID, sysID);
            }

            //기 OPEN된 SystemLIst에 해당 System이 없으면 List 에 Add (Delegator Method 추가여부는 업무확정후 결정
            if (!this.openedSystemList.Contains(sysID))
            {
                this.openedSystemList.Add(sysID, sysID);
            }

        }
        private void CallOnGroupUserLogOn(string grpID, string sysID, bool isFirst)
        {
            /*
             * 어셈블리명은 그룹ID.Lib.GroupDelegator
             * 파일위치는 현재그룹ID와 그룹ID가 동일하면 C:\IHIS\현재시스템ID\그룹ID.Lib.GroupDelegator
             * 다른 시스템이면 C:\IHIS\전달된시스템ID\그룹ID.Lib.GroupDelegator
             * ClassType은 IHIS.그룹ID.GroupDelegator
             * Method명은 Method명은 OnGroupUserLogOn(string userID, bool isMyGroup, bool isFirst)
             * isMyGroup(동일한 Group인지 여부), isFirst(첫번째로 call되었는지 여부, false는 사용자변경등에 의한 다시 Call될때)
            */
            try
            {
                bool isSameGroup = true;
                //서로 다른 Group이면 Flag Set
                if (this.groupID != grpID)
                    isSameGroup = false;

                string asmName = grpID + ".Lib.GroupDelegator";

                string fileName = "";
                if (isSameGroup)
                    fileName = Directory.GetParent(Application.StartupPath).FullName + "\\" + this.systemID + "\\" + asmName + ".dll";
                else
                    fileName = Directory.GetParent(Application.StartupPath).FullName + "\\" + sysID + "\\" + asmName + ".dll";

                string classTypeName = "IHIS." + grpID + ".GroupDelegator";
                string methodName = "OnGroupUserLogOn";

                //File이 존재하는지 여부 Check
                if (!File.Exists(fileName)) return;
                //SystemDelegator가 Loaded 되어 있느지 확인
                Assembly asm = LoadedAssembly(asmName);
                if (asm == null)
                {
                    asm = Assembly.LoadFrom(fileName);
                }
                Type classType = asm.GetType(classTypeName);
                if (classType == null) return;
                MethodInfo mInfo = classType.GetMethod(methodName);
                if (mInfo == null) return;
                //Argument는 userID, isMySystem, isFirst
                object[] objParams = new object[] { UserInfo.UserID, isSameGroup, isFirst };
                //Method Invoke
                mInfo.Invoke(null, objParams);
            }
            catch (Exception xe)
            {
                Logs.WriteLog("MdiForm::CallOnGroupUserLogOn 그룹[" + grpID + "],Error[" + xe.Message + "]");
            }
        }
        private Assembly LoadedAssembly(string asmName)
        {
            Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly asm in asms)
            {
                if (asm.GetName().Name.ToLower() == asmName.ToLower())
                    return asm;
            }

            return null;
        }
        #endregion

        #region MenuTreeView Open Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="panelUse"> Hidden으로 처리하면 true, 바로 보이게 하면 false </param>
        protected virtual void OpenMenuTree(bool panelUse)
        {
            try
            {
                this.menuViewForm = new MenuViewForm(mdiMenu);
                Icon menuIcon = Icon.FromHandle(GetIcon("ViewMenu").GetHicon());
                string text = XMsg.GetField("F020"); // 메뉴보기" : "メニュー一覧");
                Content menuContent = new Content(dockManager, menuViewForm, text, menuIcon);
                menuContent.HideButton = false;
                menuContent.CloseButton = false;
                menuContent.CaptionBar = true;
                menuContent.CloseOnHide = true;
                //최초 Content의 Width를 0로 하여 Docking이 생기면 생기는 잔상을 없앰
                int width = menuViewForm.Size.Width;
                int height = menuViewForm.Size.Height;
                menuContent.FloatingSize = menuViewForm.Size;
                //menuContent.DisplaySize = menuViewForm.Size;
                menuContent.DisplaySize = new Size(0, height);
                menuContent.AutoHideSize = menuViewForm.Size;
                dockManager.Contents.Add(menuContent);
                dockManager.AddContentWithState(menuContent, State.DockLeft, panelUse);

                //Content.DisplaySize의 Width를 원래 위치로 다시 복구
                this.ResizeDockingScreen(text, width);

            }
            catch (Exception e)
            {
                Debug.WriteLine("MdiForm::OpenMenuTree, Error=" + e.Message);
            }
        }
        #endregion

        #region Menu Item Click Event Handler
        /// <summary>
        /// Menu Item Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuClick(object sender, System.EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            string msg = "", title = "";
            switch (menuItem.MenuFunc)
            {
                case MenuFunc.ChangeSystem:
                    //AMIS 메인 Window에 활성화 MSG SEND
                    try
                    {
                        IntPtr ifcHandle = IntPtr.Zero;
                        ifcHandle = User32.FindWindow(null, "[IHIS]");
                        if (ifcHandle != IntPtr.Zero)
                            User32.SendMessage(ifcHandle, MSG_IHIS_INSTANCE_FOCUS, 0, 0);
                    }
                    catch { }
                    break;
                case MenuFunc.ViewMsg:  //메세지 보기
                    //AMIS 메인 Window에 활성화 MSG SEND
                    IntPtr wParam = IntPtr.Zero;
                    try
                    {
                        IntPtr ifcHandle = IntPtr.Zero;
                        ifcHandle = User32.FindWindow(null, "[IHIS]");
                        if (ifcHandle != IntPtr.Zero)
                        {

                            //사용자ID를 wParam으로 보내기
                            wParam = Marshal.StringToHGlobalAnsi(UserInfo.UserID);
                            User32.SendMessage(ifcHandle, MSG_XMSG_DISPLAY, wParam, IntPtr.Zero);
                        }
                    }
                    catch { }
                    finally
                    {
                        //Memory 해제
                        if (wParam != IntPtr.Zero)
                            Marshal.FreeCoTaskMem(wParam);
                    }
                    break;
                case MenuFunc.ViewMenu:		// TreeView Menu 보기
                    //Content List에 MenuView가 없으면 생성후 Display
                    title = XMsg.GetField("F020"); // 메뉴보기
                    if (dockManager.Contents[title] == null)
                    {
                        OpenMenuTree(false);
                    }
                    else
                    {
                        Content menuViewFormCont = dockManager.Contents[title];
                        if (!menuViewFormCont.Visible)
                        {
                            dockManager.ShowContent(menuViewFormCont);
                        }
                        if (menuViewFormCont.AutoHidePanel != null)
                        {
                            menuViewFormCont.AutoHidePanel.BringContentIntoView(menuViewFormCont);
                        }
                    }
                    menuViewForm.Focus();
                    break;
                case MenuFunc.RegenMenu:	// Menu재생성
                    RegenUserMenu();  //사용자 메뉴 재생성
                    break;
                case MenuFunc.LogoutUser:  //로그 아웃
                    LogoutUser();
                    break;
                case MenuFunc.Leave:	// 화면잠금
                    LockupScreen();  //화면 잠금 처리
                    break;
                case MenuFunc.PrtScreen:	// 화면인쇄
                    if (this.ActiveMdiChild != null)
                    {
                        MdiChild mc = ActiveMdiChild as MdiChild;
                        if (mc != null)
                            mc.PrintScreen();
                    }
                    else
                    {
                        msg = XMsg.GetMsg("M011"); //열려있는 화면이 없습니다.
                        title = XMsg.GetField("F026"); //화면인쇄
                        XMessageBox.Show(msg, title);
                    }
                    break;
                case MenuFunc.CapScreen:	// 화면캡쳐
                    if (this.ActiveMdiChild != null)
                    {
                        // Capture Form
                        Graphics g1 = this.CreateGraphics();
                        Image CapImage = new Bitmap(ActiveMdiChild.Bounds.Width, ActiveMdiChild.Bounds.Height, g1);
                        Graphics g2 = Graphics.FromImage(CapImage);
                        IntPtr dc1 = g1.GetHdc();
                        IntPtr dc2 = g2.GetHdc();
                        Point pos = this.mdiClient.PointToScreen(ActiveMdiChild.Location);
                        Gdi32.BitBlt(dc2, 0, 0, ActiveMdiChild.Bounds.Width, ActiveMdiChild.Bounds.Height,
                            dc1, pos.X, pos.Y - 26, 13369376);
                        g1.ReleaseHdc(dc1);
                        g2.ReleaseHdc(dc2);
                        g1.Dispose();
                        g2.Dispose();

                        // Save Image
                        SaveFileDialog saveFile1 = new SaveFileDialog();
                        saveFile1.DefaultExt = "*.bmp";
                        saveFile1.Filter = "BMP Files|*.BMP|JPG Files|*.JPG";

                        // Determine if the user selected a file name from the saveFileDialog.
                        if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                            saveFile1.FileName.Length > 0)
                        {
                            CapImage.Save(saveFile1.FileName, saveFile1.FilterIndex == 1 ? ImageFormat.Bmp : ImageFormat.Jpeg);
                        }
                    }
                    else
                    {
                        msg = XMsg.GetMsg("M011"); //열려있는 화면이 없습니다.
                        title = XMsg.GetField("F027"); //화면캡쳐
                        XMessageBox.Show(msg, title);
                    }
                    break;
                case MenuFunc.AllClose:  //창 전체 닫기
                    foreach (Form child in this.MdiChildren)
                    {
                        if (child != null) child.Close();
                    }
                    break;
                case MenuFunc.UserChange:	// 사용자변경
                    ChangeUser("", true);   //사용자 변경 처리
                    break;
                case MenuFunc.PswdChange:	// 비밀번호변경
                    ChangePassword();
                    break;
                case MenuFunc.UserInfo:	// 사용자정보
                    break;
                case MenuFunc.Exit:			// 종료
                    {
                        this.Close();
                        Application.Exit();
                        break;
                    }
                case MenuFunc.SelectMonitor:
                    {
                        EnvironInfo.SetMDIMonitorIndex();
                        break;
                    }
                case MenuFunc.Pgm:			// Program
                    {
                        ScreenMenuItem screenItem = (ScreenMenuItem)sender;
                        //2005.10.10 MenuParam이 있으면 OpenParam으로 전달
                        //2006.02.27 MenuParam이 있으면 OpenCommand로 전달함(OpenParam은 추후 생략예정임)
                        //CommonItemCollection openParam = null;
                        OpenCommand openCmd = null;
                        if (screenItem.MenuParam.Trim() != "")
                        {
                            openCmd = new OpenCommand("MENU_PARAM");
                            openCmd.Items.Add("MenuParam", screenItem.MenuParam);

                        }
                        //새로운 화면 열기
                        OpenNewScreen(this, screenItem.MenuScreenInfo, openCmd);
                        break;
                    }
                case MenuFunc.MyPgm:  //마이 메뉴로 등록된 화면
                    {
                        MyMenuItem myMenuItem = (MyMenuItem)sender;
                        //MenuParameter가 있으면 MenuParameter로 OpenParam을 만들어
                        //OpenScreenWithParam으로 Call
                        //2006.02.27 MenuParam이 있으면 OpenCommand로 전달함(OpenParam은 추후 생략예정임)
                        //CommonItemCollection openParam = null;
                        OpenCommand openCmd = null;
                        if (myMenuItem.MenuInfo.MenuParam.Trim() != "")
                        {
                            //openParam = new CommonItemCollection();
                            //openParam.Add("MenuParam", myMenuItem.MenuInfo.MenuParam);
                            openCmd = new OpenCommand("MENU_PARAM");
                            openCmd.Items.Add("MenuParam", myMenuItem.MenuInfo.MenuParam);
                        }
                        //화면 Open
                        ScreenManager.OpenScreenWithCommand(this, myMenuItem.MenuInfo.PgmID,
                            myMenuItem.MenuInfo.OpenStyle, ScreenAlignment.Default, openCmd);

                        break;
                    }
                default:
                    break;
            }
        }
        #endregion

        #region OpenNewScreen
        internal IXScreen OpenNewScreen(object opener, ScreenInfo screenInfo, CommonItemCollection openParam)
        {
            object obj = null;
            string msg = "";
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                //Progress Start
                this.sProgBar.Start();
                this.sProgBar.Progress(10);
                //Pgm이 Docking Style로 Open되면 이미 해당 Pgm이 있으면 다시 Load하지 않음
                if (screenInfo.OpenStyle == ScreenOpenStyle.Docking)
                {
                    //2005.10.10 Docking 화면은 시스템의 환자LIST에 등록된 화면만 Open가능
                    string keyName = screenInfo.PgmID;
                    if (!this.checkMenuList.Contains(keyName))
                    {
                        msg = XMsg.GetMsg("M012"); // 환자리스트에 등록된 화면만 Docking으로 오픈가능합니다."
                        XMessageBox.Show(msg, "Screen Open");
                        return null;
                    }
                    if (dockManager.Contents[screenInfo.Title] != null)
                    {
                        Content scrContent = dockManager.Contents[screenInfo.Title];
                        scrContent.UpdateVisibility();
                        if (!scrContent.Visible)
                        {
                            dockManager.ShowContent(scrContent);
                        }
                        if (scrContent.AutoHidePanel != null)
                        {
                            scrContent.AutoHidePanel.BringContentIntoView(scrContent);
                        }
                        return (IXScreen)scrContent.Control;
                    }
                }

                //화면중복오픈 불가시 기존에 열려있는 화면이 있으면 해당화면 Activate
                if (!screenInfo.AlowDupl)
                {
                    foreach (XScreen screen in ScreenManager.OpenScreenList)
                    {
                        if (screen.ScreenInfo != null && screen.ScreenInfo.PgmID == screenInfo.PgmID)
                        {
                            //해당화면을 포함하는 MdiChild 활성화
                            if (screen.ContainerMdiChild != null)
                            {
                                //최소화 되어 있으면 다시 Normal
                                if (screen.ContainerMdiChild.WindowState == FormWindowState.Minimized)
                                    screen.ContainerMdiChild.WindowState = FormWindowState.Normal;

                                screen.ContainerMdiChild.Activate();

                                //ScreenOpen Event 발생처리
                                screen.OnScreenOpen(new XScreenOpenEventArgs(openParam));

                            }
                            return (IXScreen)screen;
                        }
                    }
                }
                //Progress Set
                this.sProgBar.Progress(30);
                string asmVer = "";
                obj = ScreenLoader.Load(opener, screenInfo, null, openParam, out asmVer);
                //Progress Set
                this.sProgBar.Progress(70);
                if (obj != null)
                {
                    if (!(obj is XScreen))
                    {
                        msg = XMsg.GetMsg("M009"); // 지원되는 유형의 화면이 아닙니다.
                        this.SetMsg(msg, MsgType.Error);
                        return null;
                    }
                    if (!(obj is IXScreen))
                    {
                        msg = XMsg.GetMsg("M009"); // 지원되는 유형의 화면이 아닙니다.
                        this.SetMsg(msg, MsgType.Error);
                        return null;
                    }

                    //현재그룹과 Screen의 그룹이 다를때 처음 그룹이 열릴때 GroupDelegator의 OnGroupUserLogOn Method call
                    //Call순서는 현재는 OnGroupUserLogOn만 Call함 (추후 협의후 추가할 예정임)
                    HandlingDelegator(screenInfo.PgmGroupID, screenInfo.PgmSystemID);

                    //OpenStyle이 Docking이면 Screen을 바로 dockManager에 Add
                    if (screenInfo.OpenStyle == ScreenOpenStyle.Docking)
                    {
                        //obj는 IXScreen 개체, obj에 Screen정보
                        //2006.02.27 screenInfo는 OpenArg로 ScreenLoader.Load시에 설정함
                        //((XScreen)obj).ScreenInfo = screenInfo;
                        ((XScreen)obj).ContainerMdiForm = this;

                        Icon icon = Icon.FromHandle(GetIcon("Program").GetHicon());
                        Content scrContent = new Content(dockManager, (Control)obj, screenInfo.Title, icon);
                        scrContent.HideButton = false;
                        scrContent.CloseButton = false;
                        scrContent.CaptionBar = true;
                        scrContent.CloseOnHide = true;
                        scrContent.FloatingSize = ((Control)obj).Size;
                        //최초 Content의 Width를 0로 하여 Docking이 생기면 생기는 잔상을 없앰
                        int width = ((Control)obj).Size.Width;
                        int height = ((Control)obj).Size.Height;
                        scrContent.DisplaySize = new Size(0, height);
                        scrContent.AutoHideSize = ((Control)obj).Size;
                        dockManager.Contents.Add(scrContent);
                        dockManager.AddContentWithState(scrContent, State.DockLeft, true);

                        if (scrContent.AutoHidePanel != null)
                        {
                            //TabStubClickAtContentHidden Event는 AutoHidePanel의 Event이므로 Docking화면 Open시 마다 Event 설정하지 않고
                            //한번만 설정, 화면 Open시 마다 연결하면 Docking된 각 화면의 Content를 누를때 여러번 발생함.
                            if (!this.isAddedTabStubHandler)
                            {
                                scrContent.AutoHidePanel.TabStubClickAtContentHidden += new IHIS.X.Magic.Docking.TabStub.TabStubHandler(OnTabStubClickAtContentHidden);
                                this.isAddedTabStubHandler = true;
                            }
                        }

                        //2005.10.10 Docking화면은 환자리스트의 메뉴의 Check상태로 변경
                        //Registry에 등록여부는 사용자가 메뉴를 Click했을 경우만 Registry에 등록
                        string keyName = screenInfo.PgmID;
                        if (this.checkMenuItemList.Contains(keyName))
                            ((ScreenMenuItem)this.checkMenuItemList[keyName]).Checked = true;

                        //Content.DisplaySize의 Width를 원래 위치로 다시 복구
                        this.ResizeDockingScreen(screenInfo.Title, width);

                        //동적생성한 화면이 최초 Mouse Move Event를 받게 하기 위해 TickTock
                        TickTock();
                    }
                    else //Popup, Response
                    {

                        MdiChild mdiChild = null;
                        bool isPopup = false;
                        //Response는 MdiParent를 지정하지 않고 생성하고, Popup은 MdiParent를 지정하도록 생성함
                        //Popup은 MdiParent를 지정하여 MdiClient영역내에서만 관리되도록하고, Response는 ShowDialog로
                        //띄워야 하므로 MdiParent를 지정하지 않음(MdiParent를 지정하면 ShowDialog할 수 없음)
                        //2006.12.04 PopupSingleSizable, PopupSingleFixed 반영
                        //Popup형태중에 MdiClient내에서 움직이는 것이 아닌 Mdi와 관계없이 Single화면으로 움직이는 화면 방식
                        if ((screenInfo.OpenStyle == ScreenOpenStyle.ResponseFixed) || (screenInfo.OpenStyle == ScreenOpenStyle.ResponseSizable))
                            mdiChild = new MdiChild();
                        else if ((screenInfo.OpenStyle == ScreenOpenStyle.PopupSingleFixed) || (screenInfo.OpenStyle == ScreenOpenStyle.PopupSingleSizable))
                            mdiChild = new MdiChild();
                        else
                        {
                            isPopup = true; //Modalless Show
                            mdiChild = new MdiChild(this);
                        }

                        //2005.10.17 MdiChild의 TabStop이 true일 경우 여러개의 MdiChild가 있을때 첫번째 MdiChild에 Focus가 있지 않을때 
                        //Docking Window를 Open했다가 Hide시나 Docking Window를 Open후에 다시 현재 Active한 MdiChild를 찍을때
                        //IFC.X.Magic::AutoHidePanel::RemoveDisplayedWindow에서 현재 Display된 Docking화면을 관리하는 WindowContentTabbed를
                        //Remove할때 ControlHelper.Remove(_currentPanel.Controls, _currentWCT); 무슨이유에서인지 Stack Flow를 보면 다음 Control로
                        //SelectNextControl시에 첫번째 MdiChild가 Select되면서 첫번째 MdiChild가 Activate되는 현상이 발생한다.(정확한 원인은 알 수 없음)
                        //SelectNextControl시에 TabStop이 있는 다음 Control을 Select하는데, 다음 Control이 MdiChild가 되지 않도록 MdiChild의 TabStop을
                        //false로 설정하면 이 Remove시에 발생하는 이상한 현상이 나타나지 않음. 따라서, TabStop을 false로 설정한다.
                        //정확한 원인은 추후 확인해야 할 것 같음
                        mdiChild.TabStop = false;

                        mdiChild.Icon = this.Icon;
                        //Sizable이면 popUp의 FormBorderStyle을 Sizable, Fixed이면 FixedSingle로 SET
                        if ((screenInfo.OpenStyle == ScreenOpenStyle.PopUpSizable) || (screenInfo.OpenStyle == ScreenOpenStyle.ResponseSizable) || (screenInfo.OpenStyle == ScreenOpenStyle.PopupSingleSizable))
                            mdiChild.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                        else
                            mdiChild.FormBorderStyle = FormBorderStyle.FixedToolWindow;


                        mdiChild.OpenNewScreen(obj, screenInfo, this);

                        //Form Location Set (화면Alignment에 따른 Form의 위치 설정)
                        mdiChild.Location = CalcFormLocation(screenInfo, mdiChild);

                        //오픈된 화면 List를 관리하는 TabControl에 Add (단 Modal일때는 제외함)
                        if (isPopup)
                            AddTabPage(mdiChild);
                        //Modalless
                        if ((screenInfo.OpenStyle == ScreenOpenStyle.PopUpFixed) || (screenInfo.OpenStyle == ScreenOpenStyle.PopUpSizable))
                        {
                            mdiChild.Show();
                            //동적생성한 화면이 최초 Mouse Move Event를 받게 하기 위해 TickTock
                            TickTock();
                        }
                        else if ((screenInfo.OpenStyle == ScreenOpenStyle.PopupSingleFixed) || (screenInfo.OpenStyle == ScreenOpenStyle.PopupSingleSizable)) //Modaless, Single
                        {
                            mdiChild.Owner = this;
                            mdiChild.Show();
                            //동적생성한 화면이 최초 Mouse Move Event를 받게 하기 위해 TickTock
                            TickTock();
                        }
                        else
                        {
                            //Progress Stop (Modal로 띄우므로 먼저 Stop)
                            this.sProgBar.Stop();
                            mdiChild.ShowDialog(this); //Modal
                            mdiChild.Dispose();
                        }
                    }
                }
            }
            catch (Exception e)
            {

                this.SetMsg("MdiForm::OpenNewScreen Error[" + e.Message + "]", MsgType.Error);
                return null;
            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default;
                this.sProgBar.Stop();
            }

            return obj as IXScreen;
        }
        //2006.02.27 OpenCommand를 받아서 화면 열기
        internal IXScreen OpenNewScreen(object opener, ScreenInfo screenInfo, OpenCommand openCommand)
        {
            object obj = null;
            string msg = "";
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                //Progress Start
                this.sProgBar.Start();
                this.sProgBar.Progress(10);
                //Pgm이 Docking Style로 Open되면 이미 해당 Pgm이 있으면 다시 Load하지 않음
                if (screenInfo.OpenStyle == ScreenOpenStyle.Docking)
                {
                    //2005.10.10 Docking 화면은 시스템의 환자LIST에 등록된 화면만 Open가능
                    string keyName = screenInfo.PgmID;
                    if (!this.checkMenuList.Contains(keyName))
                    {
                        msg = XMsg.GetMsg("M012"); // 환자리스트에 등록된 화면만 Docking으로 오픈가능합니다."
                        XMessageBox.Show(msg, "Screen Open");
                        return null;
                    }
                    if (dockManager.Contents[screenInfo.Title] != null)
                    {
                        Content scrContent = dockManager.Contents[screenInfo.Title];
                        scrContent.UpdateVisibility();
                        if (!scrContent.Visible)
                        {
                            dockManager.ShowContent(scrContent);
                        }
                        if (scrContent.AutoHidePanel != null)
                        {
                            scrContent.AutoHidePanel.BringContentIntoView(scrContent);
                        }
                        return (IXScreen)scrContent.Control;
                    }
                }

                //화면중복오픈 불가시 기존에 열려있는 화면이 있으면 해당화면 Activate
                if (!screenInfo.AlowDupl)
                {
                    foreach (XScreen screen in ScreenManager.OpenScreenList)
                    {
                        if (screen.ScreenInfo.PgmID == screenInfo.PgmID)
                        {
                            //해당화면을 포함하는 MdiChild 활성화
                            if (screen.ContainerMdiChild != null)
                            {
                                //최소화 되어 있으면 다시 Normal
                                if (screen.ContainerMdiChild.WindowState == FormWindowState.Minimized)
                                    screen.ContainerMdiChild.WindowState = FormWindowState.Normal;

                                screen.ContainerMdiChild.Activate();

                                //ScreenOpen Event 발생처리
                                screen.OnScreenOpen(new XScreenOpenEventArgs(openCommand));

                            }
                            return (IXScreen)screen;
                        }
                    }
                }
                //Progress Set
                this.sProgBar.Progress(30);
                string asmVer = "";
                obj = ScreenLoader.Load(opener, screenInfo, openCommand, null, out asmVer);
                //Progress Set
                this.sProgBar.Progress(70);
                if (obj != null)
                {
                    if (!(obj is XScreen))
                    {
                        msg = XMsg.GetMsg("M009"); // 지원되는 유형의 화면이 아닙니다.
                        this.SetMsg(msg, MsgType.Error);
                        return null;
                    }
                    if (!(obj is IXScreen))
                    {
                        msg = XMsg.GetMsg("M009"); // 지원되는 유형의 화면이 아닙니다.
                        this.SetMsg(msg, MsgType.Error);
                        return null;
                    }

                    //해당 프로그램의 시스템의 OnSystemUserLogOn Method Call (Delegator Handling)
                    HandlingDelegator(screenInfo.PgmGroupID, screenInfo.PgmSystemID);

                    //OpenStyle이 Docking이면 Screen을 바로 dockManager에 Add
                    if (screenInfo.OpenStyle == ScreenOpenStyle.Docking)
                    {
                        //obj는 IXScreen 개체, obj에 Screen정보
                        //2006.02.27 screenInfo는 OpenArg로 ScreenLoader.Load시에 설정함
                        //((XScreen)obj).ScreenInfo = screenInfo;
                        ((XScreen)obj).ContainerMdiForm = this;

                        Icon icon = Icon.FromHandle(GetIcon("Program").GetHicon());
                        Content scrContent = new Content(dockManager, (Control)obj, screenInfo.Title, icon);
                        scrContent.HideButton = false;
                        scrContent.CloseButton = false;
                        scrContent.CaptionBar = true;
                        scrContent.CloseOnHide = true;
                        scrContent.FloatingSize = ((Control)obj).Size;
                        //최초 Content의 Width를 0로 하여 Docking이 생기면 생기는 잔상을 없앰
                        int width = ((Control)obj).Size.Width;
                        int height = ((Control)obj).Size.Height;
                        scrContent.DisplaySize = new Size(0, height);
                        scrContent.AutoHideSize = ((Control)obj).Size;
                        dockManager.Contents.Add(scrContent);
                        dockManager.AddContentWithState(scrContent, State.DockLeft, true);

                        if (scrContent.AutoHidePanel != null)
                        {
                            //TabStubClickAtContentHidden Event는 AutoHidePanel의 Event이므로 Docking화면 Open시 마다 Event 설정하지 않고
                            //한번만 설정, 화면 Open시 마다 연결하면 Docking된 각 화면의 Content를 누를때 여러번 발생함.
                            if (!this.isAddedTabStubHandler)
                            {
                                scrContent.AutoHidePanel.TabStubClickAtContentHidden += new IHIS.X.Magic.Docking.TabStub.TabStubHandler(OnTabStubClickAtContentHidden);
                                this.isAddedTabStubHandler = true;
                            }
                        }

                        //2005.10.10 Docking화면은 환자리스트의 메뉴의 Check상태로 변경
                        //Registry에 등록여부는 사용자가 메뉴를 Click했을 경우만 Registry에 등록
                        string keyName = screenInfo.PgmID;
                        if (this.checkMenuItemList.Contains(keyName))
                            ((ScreenMenuItem)this.checkMenuItemList[keyName]).Checked = true;

                        //Content.DisplaySize의 Width를 원래 위치로 다시 복구
                        this.ResizeDockingScreen(screenInfo.Title, width);

                        //동적생성한 화면이 최초 Mouse Move Event를 받게 하기 위해 TickTock
                        TickTock();
                    }
                    else //Popup, Response
                    {

                        MdiChild mdiChild = null;
                        bool isPopup = false;
                        //Response는 MdiParent를 지정하지 않고 생성하고, Popup은 MdiParent를 지정하도록 생성함
                        //Popup은 MdiParent를 지정하여 MdiClient영역내에서만 관리되도록하고, Response는 ShowDialog로
                        //띄워야 하므로 MdiParent를 지정하지 않음(MdiParent를 지정하면 ShowDialog할 수 없음)
                        //2006.12.04 PopupSingleSizable, PopupSingleFixed 반영
                        //Popup형태중에 MdiClient내에서 움직이는 것이 아닌 Mdi와 관계없이 Single화면으로 움직이는 화면 방식
                        if ((screenInfo.OpenStyle == ScreenOpenStyle.ResponseFixed) || (screenInfo.OpenStyle == ScreenOpenStyle.ResponseSizable))
                            mdiChild = new MdiChild();
                        else if ((screenInfo.OpenStyle == ScreenOpenStyle.PopupSingleFixed) || (screenInfo.OpenStyle == ScreenOpenStyle.PopupSingleSizable))
                            mdiChild = new MdiChild();
                        else
                        {
                            isPopup = true; //Modalless Show
                            mdiChild = new MdiChild(this);
                        }

                        //2005.10.17 MdiChild의 TabStop이 true일 경우 여러개의 MdiChild가 있을때 첫번째 MdiChild에 Focus가 있지 않을때 
                        //Docking Window를 Open했다가 Hide시나 Docking Window를 Open후에 다시 현재 Active한 MdiChild를 찍을때
                        //IHIS.X.Magic::AutoHidePanel::RemoveDisplayedWindow에서 현재 Display된 Docking화면을 관리하는 WindowContentTabbed를
                        //Remove할때 ControlHelper.Remove(_currentPanel.Controls, _currentWCT); 무슨이유에서인지 Stack Flow를 보면 다음 Control로
                        //SelectNextControl시에 첫번째 MdiChild가 Select되면서 첫번째 MdiChild가 Activate되는 현상이 발생한다.(정확한 원인은 알 수 없음)
                        //SelectNextControl시에 TabStop이 있는 다음 Control을 Select하는데, 다음 Control이 MdiChild가 되지 않도록 MdiChild의 TabStop을
                        //false로 설정하면 이 Remove시에 발생하는 이상한 현상이 나타나지 않음. 따라서, TabStop을 false로 설정한다.
                        //정확한 원인은 추후 확인해야 할 것 같음
                        mdiChild.TabStop = false;

                        mdiChild.Icon = this.Icon;
                        //Sizable이면 popUp의 FormBorderStyle을 Sizable, Fixed이면 FixedSingle로 SET
                        if ((screenInfo.OpenStyle == ScreenOpenStyle.PopUpSizable) || (screenInfo.OpenStyle == ScreenOpenStyle.ResponseSizable))
                            mdiChild.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                        else
                            mdiChild.FormBorderStyle = FormBorderStyle.FixedToolWindow;


                        mdiChild.OpenNewScreen(obj, screenInfo, this);

                        //Form Location Set (화면Alignment에 따른 Form의 위치 설정)
                        mdiChild.Location = CalcFormLocation(screenInfo, mdiChild);

                        //오픈된 화면 List를 관리하는 TabControl에 Add (단 Modal일때는 제외함)
                        if (isPopup)
                            AddTabPage(mdiChild);
                        //Modalless
                        if ((screenInfo.OpenStyle == ScreenOpenStyle.PopUpFixed) || (screenInfo.OpenStyle == ScreenOpenStyle.PopUpSizable))
                        {
                            mdiChild.Show();
                            //동적생성한 화면이 최초 Mouse Move Event를 받게 하기 위해 TickTock
                            TickTock();
                        }
                        else if ((screenInfo.OpenStyle == ScreenOpenStyle.PopupSingleFixed) || (screenInfo.OpenStyle == ScreenOpenStyle.PopupSingleSizable)) //Modaless, Single
                        {
                            mdiChild.Owner = this;
                            mdiChild.Show();
                            //동적생성한 화면이 최초 Mouse Move Event를 받게 하기 위해 TickTock
                            TickTock();
                        }
                        else
                        {
                            //Progress Stop (Modal로 띄우므로 먼저 Stop)
                            this.sProgBar.Stop();
                            mdiChild.ShowDialog(this); //Modal
                            mdiChild.Dispose();
                        }
                    }
                }
            }
            catch (Exception e)
            {

                this.SetMsg("MdiForm::OpenNewScreen Error[" + e.Message + "]", MsgType.Error);
                return null;
            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default;
                this.sProgBar.Stop();
            }

            return obj as IXScreen;
        }
        #endregion

        #region TickTock
        private void TickTock()
        {
            //화면을 TabPage에 붙일때 동적생성한 화면이 최초 Mouse Move Event를 받게 하기 위해
            //TabPage에 Add후에 Form을 보였다가 사라지게해서 최초 MouseMove시 반응하도록 처리
            TickTockForm dlg = new TickTockForm();
            dlg.ShowDialog();  //ShowDialog후에 0.1sec후에 timer에 의해 Close됨
            dlg.Dispose();
        }
        #endregion

        #region OnTabStubClickAtContentHidden
        private void OnTabStubClickAtContentHidden(IHIS.X.Magic.Docking.TabStub sender)
        {
            //Docking된 화면을 다시보여줄때(TabStub를 Click)시에 필요한 작업을 할 수 있도록
            //Content의 Control이 AScreen이면 AScreen의 OnClickHiddenDockingScreen Call
            //개발자는 ClickHiddenDockingScreen Event를 handling하여 필요한 작업을 처리함
            if ((sender.TabPages.Count == 1) && (sender.TabPages[0].Tag is IHIS.X.Magic.Docking.Content))
            {
                Control cont = ((IHIS.X.Magic.Docking.Content)sender.TabPages[0].Tag).Control;
                if (cont is XScreen)
                {
                    ((XScreen)cont).OnHiddenDockingScreenAppearing(EventArgs.Empty);
                }
            }
        }
        #endregion

        #region GetIcon
        internal Bitmap GetIcon(string iconName)
        {
            try
            {
                Bitmap icon = (Bitmap)imageResource.GetObject(iconName);
                return icon;
            }
            catch { }

            return null;
        }
        #endregion

        #region TabControl Event Handler
        /// <summary>
        /// Tab Control에서 Right Button Click시 PopUp Menu Display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTabControlMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                XTabControl tabCont = (XTabControl)sender;
                // Popup시의 TabPage 보관
                tabPageMouseHovered = null;
                for (int i = 0; i < tabCont.TabCount; i++)
                {
                    if (tabCont.GetTabRect(i).Contains(new Point(e.X, e.Y)))
                    {
                        tabPageMouseHovered = tabCont.TabPages[i];
                        break;
                    }
                }
                if (tabPageMouseHovered == null) return;

                // context menu
                tabContextMenu.MenuCommands.Clear();
                tabContextMenu.MenuCommands.AddRange(new MenuItem[] { new MenuItem(XMsg.GetField("F032"), new EventHandler(ContextMenu_Click), Shortcut.None, MenuFunc.CloseScreen, GetIcon("Close")) }); //화면닫기
                tabContextMenu.Style = IHIS.X.Magic.Common.VisualStyle.IDE;
                tabContextMenu.TrackPopup(tabCont.PointToScreen(new Point(e.X, e.Y)));
            }
        }

        /// <summary>
        /// Contect Menu Click시 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenu_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

            switch (menuItem.MenuFunc)
            {
                case MenuFunc.CloseScreen:	// 화면 닫기
                    if (tabPageMouseHovered != null)
                    {
                        if (tabPageMouseHovered.Tag != null)
                        {
                            ((Form)tabPageMouseHovered.Tag).Close();
                            tabPageMouseHovered = null;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Tab Control TabPage 변경시 연결 창 활성화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTabControlSelectionChanged(object sender, System.EventArgs e)
        {
            XTabControl tabControl = (XTabControl)sender;
            if (tabControl != null)
            {
                if (tabControl.SelectedTab != null)
                {
                    if (tabControl.SelectedTab.Tag != null)
                    {
                        Form form = (Form)tabControl.SelectedTab.Tag;
                        form.Activate();
                        //메세지 Clear
                        this.SetMsg("", MsgType.Normal);
                        //이전화면 Index Set(2006.02.21) 
                        //화면을 닫을때 OnTabControlSelectionChanging에 의해 SelectedIndex 설정시 닫힌 화면의 Index가 설정되었으면 현재
                        //Index로 PreviousScreenIndex Set
                        //						if (XScreen.PreviousScreenIndex >= tabControl.TabPages.Count)
                        //						{
                        //							XScreen.PreviousScreenIndex = tabControl.SelectedIndex;
                        //						}
                    }
                }
                else //선택된 Tab이 없으면 XScreen.CurrentScreen = null
                {
                    XScreen.CurrentScreen = null;
                    //PreviousScreenIndex = -1로 Reset(2006.02.21)
                    //					XScreen.PreviousScreenIndex = -1;
                }
            }
        }
        private void OnTabControlSelectionChanging(object sender, System.EventArgs e)
        {
            //XScreen의 이전화면의 Index Set
            XScreen.PreviousScreenIndex = this.mdiTabControl.SelectedIndex;
            //2006.02.21 최초 화면 Open시에 PreviousScreenIndex = -1이면 맨 처음(0)로 설정
            //Previous와 CurrentScreen을 나누어 처리하도록 유도하자.
            //			if ((mdiTabControl.TabCount == 1) && (XScreen.PreviousScreenIndex < 0))
            //				XScreen.PreviousScreenIndex = 0;
        }

        /// <summar>
        /// Tab Control Close Buton Click시 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTabControlClosePressed(object sender, System.EventArgs e)
        {
            XTabControl tabCont = (XTabControl)sender;

            if (tabCont != null)
            {
                if (tabCont.SelectedIndex >= 0)
                {
                    // TabPage 연결창 닫기
                    if (tabCont.SelectedTab.Tag != null)
                    {
                        ((Form)tabCont.SelectedTab.Tag).Close();
                    }
                }
            }
        }
        #endregion

        #region Tab 관련 Methods
        // MDI에 TabPage 추가
        protected virtual void AddTabPage(MdiChild form)
        {
            if (form == null) return;
            string title = form.Text;
            if (form.Tag != null)  //2006.02.16 form의 Text는 Title[ScreenID]로 하고 Tag에 Title을 저장, Tab에는 Title만 보여줌
                title = form.Tag.ToString();
            IHIS.X.Magic.Controls.TabPage tabPage = new IHIS.X.Magic.Controls.TabPage(title);
            this.mdiTabControl.TabPages.Add(tabPage);
            tabPage.Tag = form;		// Tag에 Form참조 보관
            form.Closed += new EventHandler(TabForm_Closed);
            form.Activated += new EventHandler(TabForm_Activated);
            //form.GotFocus += new EventHandler(TabForm_GotFocus);

            this.mdiTabControl.SelectedTab = tabPage;
        }

        // MDI에서 TabPage 제거
        protected virtual int RemoveTabPage(IHIS.X.Magic.Controls.TabPage tabPage)
        {
            if (tabPage == null) return -1;
            this.mdiTabControl.TabPages.Remove(tabPage);

            //XScreen의 이전화면의 Index Reset
            XScreen.PreviousScreenIndex = -1;

            //모든 화면이 제거 되었으면 XScreen.CurrentScreen Reset
            if (this.mdiTabControl.TabPages.Count < 1)
                XScreen.CurrentScreen = null;

            return 1;
        }

        /// <summary>
        /// Tab연결 창 Closed Event발생시 TabPage제거
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabForm_Closed(object sender, System.EventArgs e)
        {
            Form form = (Form)sender;
            foreach (IHIS.X.Magic.Controls.TabPage tabPage in mdiTabControl.TabPages)
            {
                if (tabPage.Tag == sender)
                {
                    RemoveTabPage(tabPage);
                    break;
                }
            }
        }

        /// <summary>
        /// MdiChild 화면 변경시 TabControl의 SelectedTab변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabForm_Activated(object sender, System.EventArgs e)
        {
            Form form = (Form)sender;
            foreach (X.Magic.Controls.TabPage tabPage in mdiTabControl.TabPages)
            {
                if (tabPage.Tag == sender)
                {
                    mdiTabControl.SelectedTab = tabPage;
                    //Popup으로 열린 창 활성화시에 XScreen.CurrentScreen SET
                    if (form is MdiChild)
                    {
                        XScreen.CurrentScreen = ((MdiChild)form).ActiveScreen;
                    }
                    break;
                }
            }
        }

        private void TabForm_GotFocus(object sender, System.EventArgs e)
        {
            Form form = (Form)sender;
            Debug.WriteLine("MdiForm::TabForm_GotFocus Title=" + form.Text);
        }
        #endregion

        #region mdiClient Event Handler (배경Image Display)
        protected virtual void mdiClient_Layout(object sender, LayoutEventArgs e)
        {
            if (e.AffectedProperty != "Bounds")
                return;

            Size clientSize = mdiClient.ClientSize;
            if ((Math.Abs(oldClientSize.Width - clientSize.Width) < 50) &&
                (Math.Abs(oldClientSize.Height - clientSize.Height) < 50))
                return;

            oldClientSize = clientSize;

            if ((clientSize.Width != 0) && (clientSize.Height != 0))
            {
                Rectangle rc = new Rectangle(0, 0, clientSize.Width, clientSize.Height);
                Bitmap image = new Bitmap(clientSize.Width, clientSize.Height, backImage.PixelFormat);
                Color backColor = backImage.GetPixel(0, 0);
                Graphics gfx = Graphics.FromImage(image);
                gfx.FillRectangle(new SolidBrush(backColor), rc);
                gfx.DrawImage(backImage, Math.Max(rc.Width - backImage.Width, 0), Math.Max(rc.Height - backImage.Height, 0),
                    backImage.Width, backImage.Height);
                gfx.Dispose();
                if (mdiClient.BackgroundImage != null)
                    mdiClient.BackgroundImage.Dispose();
                mdiClient.BackgroundImage = image;
            }
        }
        #endregion

        #region WndProc Override
        protected override void WndProc(ref Message msg)
        {
            // UdpMsg를 받아 System의 MainHandle로 WM_COPYDATA를 통해 데이타 전송하는 경우
            if (msg.Msg == (int)Win32.Msgs.WM_COPYDATA)
            {
                try
                {
                    //LParam에 전달된 데이타를 COPYDATASTRUCT로 변환
                    Win32.COPYDATASTRUCT st = (Win32.COPYDATASTRUCT)Marshal.PtrToStructure(msg.LParam, typeof(Win32.COPYDATASTRUCT));
                    //Win2000이상 UniCode, Win98 : Ansi (현재시스템 설정)
                    //UpdMessage 전체가 string으로 변환되어 COPY됨
                    string recvData = Marshal.PtrToStringAuto(st.lpData);
                    byte[] recvBytes = Service.BaseEncoding.GetBytes(recvData);
                    //UdpMessage 생성
                    UdpMessage udpMsg = UdpMessage.FromReceivedMessage(recvBytes);
                    switch (udpMsg.MsgType)
                    {
                        case UdpMsgType.SMG:

                            //시스템 Delegator가 처리
                            //SystemProcessMessage는 해당시스템에 있는 SystemDelegator Assembly에서 OnReceiveMessage Method Call
                            HandlingSystemMsg(udpMsg.Command, udpMsg.Message);
                            break;
                        case UdpMsgType.SCM:
                            //열려있는 화면중 화면 ID가 일치하는 화면에 Command
                            XScreen xScreen = null;
                            foreach (XScreen screen in ScreenManager.OpenScreenList)
                            {
                                // 화면 ID가 일치하면
                                if ((screen.ScreenInfo != null) && screen.ScreenInfo.PgmID.Equals(udpMsg.ScreenID))
                                {
                                    xScreen = screen;
                                    break;
                                }
                            }
                            if (xScreen != null)
                            {
                                //Command Argument Set (수신Msg)
                                CommonItemCollection cItems = new CommonItemCollection();
                                cItems.Add("UdpData", udpMsg.Message);
                                //Command Send (
                                xScreen.Command(udpMsg.Command, cItems);
                            }
                            break;
                    }
                }
                catch { }
            }
            else if (msg.Msg == MSG_SYSTEM_INSTANCE_FOCUS)
            {
                if (this.WindowState == FormWindowState.Minimized)
                    this.WindowState = FormWindowState.Normal;
                this.Activate();
                if (!this.Focused)
                    this.Focus();
            }
            else
                base.WndProc(ref msg);
        }
        #endregion

        #region HideDockingScreen, RemoveDockingScreen, ResizeDockingScreen
        /// <summary>
        /// Docking된 영역에서 해당 화면의 Content 제거
        /// </summary>
        /// <param name="screenName"></param>
        internal void RemoveDockingScreen(ScreenInfo screenInfo)
        {
            try
            {
                //DockManger의 Content에 List가 있으면 Content Remove
                Content content = dockManager.Contents[screenInfo.Title];
                if (content != null)
                {
                    //Content Remove
                    dockManager.Contents.Remove(content);

                    //2005.10.10 환자명단에 있는 Check된 메뉴 Check상태 해제
                    string keyName = screenInfo.PgmID;
                    if (this.checkMenuItemList.Contains(keyName))
                        ((ScreenMenuItem)this.checkMenuItemList[keyName]).Checked = false;
                }
            }
            catch { }

        }
        /// <summary>
        /// 해당 화면의 Docking된 화면 Hide
        /// </summary>
        /// <param name="screenName"></param>
        internal void HideDockingScreen(string screenName)
        {
            try
            {
                if (dockManager.Contents[screenName] != null)
                {
                    //Visible한 Content Window Hide
                    dockManager.HideContentWindow(dockManager.Contents[screenName]);
                }
            }
            catch { }
        }
        /// <summary>
        /// Docking된 화면의 Size 조정
        /// </summary>
        /// <param name="screenName"></param>
        /// <param name="width"></param>
        internal void ResizeDockingScreen(string screenName, int width)
        {
            if (dockManager.Contents[screenName] != null)
            {
                dockManager.ResizeDockingContent(dockManager.Contents[screenName], width);
            }
        }
        #endregion

        #region ActivateScreen
        /// <summary>
        /// Screen정보로 열려있는 화면 Activate
        /// </summary>
        /// <param name="screenInfo"></param>
        internal void ActivateScreen(ScreenInfo screenInfo)
        {
            if (screenInfo == null) return;

            //Pgm이 Docking Style로 Open되면 이미 해당 Pgm이 있으면 Content Show
            if (screenInfo.OpenStyle == ScreenOpenStyle.Docking)
            {
                if (dockManager.Contents[screenInfo.Title] != null)
                {
                    Content scrContent = dockManager.Contents[screenInfo.Title];
                    scrContent.UpdateVisibility();
                    if (!scrContent.Visible)
                    {
                        dockManager.ShowContent(scrContent);
                    }
                    if (scrContent.AutoHidePanel != null)
                    {
                        scrContent.AutoHidePanel.BringContentIntoView(scrContent);
                    }
                }
                return;
            }
            //열려있는 화면중 해당화면 Activate
            foreach (XScreen screen in ScreenManager.OpenScreenList)
            {
                if (screen.ScreenInfo.PgmID == screenInfo.PgmID)
                {
                    //해당화면을 포함하는 MdiChild 활성화
                    if (screen.ContainerMdiChild != null)
                    {
                        //최소화 되어 있으면 다시 Normal
                        if (screen.ContainerMdiChild.WindowState == FormWindowState.Minimized)
                            screen.ContainerMdiChild.WindowState = FormWindowState.Normal;

                        screen.ContainerMdiChild.Activate();

                    }
                    return;
                }
            }
        }
        #endregion

        #region SetMsg,
        /// <summary>
        /// StatusBar Message
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="msgType"></param>
        public virtual void SetMsg(string msg, MsgType msgType)
        {
            pnlMessage.Text = msg;
            switch (msgType)
            {
                case MsgType.Normal:
                    if (pnlMessage.Style != StatusBarPanelStyle.Text)
                        pnlMessage.Style = StatusBarPanelStyle.Text;
                    break;
                case MsgType.Error:
                    if (pnlMessage.Style != StatusBarPanelStyle.OwnerDraw)
                        pnlMessage.Style = StatusBarPanelStyle.OwnerDraw;
                    break;
            }
            //this.mdiStatusBar.Refresh();
        }
        /// <summary>
        /// Status Bar Set
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="deptName"></param>
        /// <param name="trmNo"></param>
        public virtual void SetStatusBar(string userName, string deptName, string trmNo)
        {
            // MED-14401
            if (NetInfo.Language != LangMode.Jr)
            {
                this.mdiStatusBar.Font = Service.COMMON_FONT;
            }

            // updated by AnhNV
            SetHyperLink();
            pnlHyperLink.Style = StatusBarPanelStyle.OwnerDraw;
            this.pnlUserName.Text = userName;
            this.pnlDeptName.Text = deptName;
            this.pnlTrmNo.Text = trmNo;
            this.pnlUserName.AutoSize = StatusBarPanelAutoSize.Contents;
            this.pnlDeptName.AutoSize = StatusBarPanelAutoSize.Contents;
            this.pnlTrmNo.AutoSize = StatusBarPanelAutoSize.Contents;
            this.pnlHyperLink.AutoSize = StatusBarPanelAutoSize.Contents;
            this.mdiStatusBar.Refresh();
        }

        /// <summary>
        /// StatusBar Work Time
        /// </summary>
        /// <param name="msg"></param>
        public virtual void SetWorkTime(string workTime)
        {
            this.pnlWorkTime.Text = workTime;
            this.mdiStatusBar.Refresh();
        }
        /// <summary>
        /// Message OwnerDraw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="sbdevent"></param>
        private void mdiStatusBar_DrawItem(object sender, System.Windows.Forms.StatusBarDrawItemEventArgs sbdevent)
        {
            if (sbdevent.Panel == pnlHyperLink)
            {
                X1 = sbdevent.Bounds.X;
                Y1 = sbdevent.Bounds.Y;
                X2 = sbdevent.Bounds.X + sbdevent.Bounds.Width;
                Y2 = sbdevent.Bounds.Y + sbdevent.Bounds.Height;
                sbdevent.Graphics.DrawString(pnlHyperLink.Text,
                        new Font(mdiStatusBar.Font, FontStyle.Regular),
                        Brushes.Blue,
                        new Rectangle(sbdevent.Bounds.X + 2, sbdevent.Bounds.Y + 2,
                        sbdevent.Bounds.Width - 2, sbdevent.Bounds.Height - 2));
            }

            if (sbdevent.Panel == pnlMessage)
                if (pnlMessage.Style == StatusBarPanelStyle.OwnerDraw)
                {
                    sbdevent.Graphics.DrawString(pnlMessage.Text,
                        new Font(mdiStatusBar.Font, FontStyle.Bold),
                        new SolidBrush(XColor.ErrMsgForeColor.Color),
                        new Rectangle(sbdevent.Bounds.X + 2, sbdevent.Bounds.Y + 2,
                        sbdevent.Bounds.Width - 2, sbdevent.Bounds.Height - 2));
                }
        }
        #endregion

        #region CalcFormLocation (화면정보에 지정된 ScreenAlign를 적용하여 MdiChild의 Location Set)
        //화면정보에 지정된 ScreenAlign를 적용하여 MdiChild의 Location Set
        //2Monitor사용도 고려해야함
        private Point CalcFormLocation(ScreenInfo scrInfo, Form popupForm)
        {
            Point scrPt = new Point(0, 0);
            if (scrInfo == null) return scrPt;
            //OpenStyle이 Docking 이면 적용할 필요없음
            if (scrInfo.OpenStyle == ScreenOpenStyle.Docking) return scrPt;

            /* PopUp은 MdiClient내에서만 정의되므로 Screen에 따른 Parent에 따른 값이 다를 수 없음
             * (0,0)는 항상 MdiClient의 LeftTop영역이 됨.
             * Response는 Screen기준과 Parent기준이 다르게 적용되어야 함 */

            //OpenStyle이 Popup일때 ScreenAlignment가 Default이면 기본값(0,0) SET
            //OpenStyle이 Response일때 ScreenAlignment가 Default이면 ScreenMiddleCenter 적용
            ScreenAlignment screenAlign = scrInfo.ScreenAlign;
            bool isPopupForm = false;
            if ((scrInfo.OpenStyle == ScreenOpenStyle.PopUpFixed) || (scrInfo.OpenStyle == ScreenOpenStyle.PopUpSizable))
            {
                isPopupForm = true; //Popup(Modalless)
                if (screenAlign == ScreenAlignment.Default)
                    return scrPt;
            }
            else if (screenAlign == ScreenAlignment.Default) //Response Default
            {
                //mins update 2011.03.10 default monitor 기준이 아니고 parent monitor 기준
                //screenAlign = ScreenAlignment.ScreenMiddleCenter;
                screenAlign = ScreenAlignment.ParentMiddleCenter;
            }

            string alignStr = screenAlign.ToString();
            int xPos = 0, yPos = 0;

            Rectangle rc = Screen.PrimaryScreen.WorkingArea; //Primary화면의 Rect
            //Modalless는 mdiClient 영역내에서만 기준이 되므로 rc는 mdiClient의 영역
            //Modal는 Parent기준은 mdiClient의 Screen기준좌표로 관리함
            if (isPopupForm)
                rc = new Rectangle(0, 0, this.mdiClient.Width, this.mdiClient.Height);
            else  //Modal, PopupSingle
            {
                //<MONITOR> 2006.12.04 Registy에 해당 화면이 모니터가 지정되어 있으면 기준 Rect는 해당 모니터의 좌표로 설정함.
                int mIndex = EnvironInfo.GetScreenMonitorIndex(scrInfo);
                if (mIndex > 0) //0은 등록안됨 OR 기본값
                {
                    rc = Screen.AllScreens[mIndex - 1].WorkingArea;
                }
                else
                {
                    //Parent기준은 mdiClient의 화면기준 좌표
                    if (alignStr.IndexOf("Parent") >= 0)
                    {
                        Point sPt = this.mdiClient.PointToScreen(new Point(0, 0));
                        rc = new Rectangle(sPt.X, sPt.Y, this.mdiClient.Width, this.mdiClient.Height);
                    }
                    //2006.03.28 모니터가 3개이상일때도 고려하여 반영하기
                    else if ((SystemInformation.MonitorCount > 1) && (alignStr.IndexOf("Screen") >= 0))
                    {

                        //두번째 Monitor 부터 몇번쨰 Monitor에 MDI가 위치하는지 확인하여 rc를 지정함
                        for (int i = 1; i < SystemInformation.MonitorCount; i++)
                        {
                            Rectangle wRect = Screen.AllScreens[i].WorkingArea;
                            /* 2006.12.04 TEST 결과 2번째 모니터에 Mdi가 있을때 this.Location.X는 2번째 모니터의 X보다 조금 작게 나타남.
                             * 1st 1280*1024, 2nd : 1024*76일때 Mdi가 2번째 Moniter일때 Location = 1276, -4 임,
                             * 따라서, 아래 Logic이 적용되지 못한다. 그래서 Margin은 5정도 주어서 계산해야 한다.
                             */
                            if (((this.Location.X + 5) >= wRect.X) && ((this.Location.X + 5) <= wRect.Right))
                            {
                                rc = wRect;
                                break;
                            }
                        }
                    }
                }
            }
            //X좌표 Left,Center,Right 적용
            if (alignStr.IndexOf("Left") >= 0)
            {
                xPos = rc.X;
            }
            else if (alignStr.IndexOf("Center") >= 0) //Center
            {
                xPos = Math.Max(rc.X, rc.X + rc.Width / 2 - popupForm.Width / 2);
            }
            else //Right
            {
                xPos = Math.Max(rc.X, rc.X + rc.Width - popupForm.Width);
                xPos -= 5;  //Scroll이 생기지 않도록 약간 왼쪽으로
            }
            //Y좌표 Top, Middle, Bottom 적용
            if (alignStr.IndexOf("Top") >= 0)  //Top
            {
                yPos = rc.Y;
            }
            else if (alignStr.IndexOf("Middle") >= 0)  //Middle
            {
                yPos = Math.Max(rc.Y, rc.Y + rc.Height / 2 - popupForm.Height / 2);
            }
            else  //Bottom
            {
                yPos = Math.Max(rc.Y, rc.Y + rc.Height - popupForm.Height);
                yPos -= 5; //Scroll이 생기지 않도록 약간 올림)
            }
            return new Point(xPos, yPos);
        }
        #endregion

        #region GetScreenByTabpageIndex (지정한 Index의 TabControl위에 있는 화면 Get, XScreen::GetPreviousScreenPAID에서 Call)
        internal XScreen GetScreenByTabPageIndex(int index)
        {
            if ((index < 0) || (index >= this.mdiTabControl.TabPages.Count)) return null;

            try
            {
                IHIS.X.Magic.Controls.TabPage tabPage = null;
                tabPage = (IHIS.X.Magic.Controls.TabPage)this.mdiTabControl.TabPages[index];
                if (tabPage != null)
                {
                    //TagPage의 Tag에 MdiChild 보관함)
                    if ((tabPage.Tag != null) && (tabPage.Tag is MdiChild))
                    {
                        return ((MdiChild)tabPage.Tag).ActiveScreen;
                    }
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
            return null;
        }
        #endregion

        #region RegenUserMenu (사용자 메뉴 재구성)
        private void RegenUserMenu()
        {
            SuspendLayout();

            //Docking된 Content중에서 메뉴보기를 제외한 화면은 모두 Close
            ArrayList removeContentList = new ArrayList();
            foreach (Content cont in dockManager.Contents)
            {
                if (cont.Title != XMsg.GetField("F017")) //업무관리
                    removeContentList.Add(cont);
            }
            foreach (Content content in removeContentList)
            {
                if (content.Control is XScreen)
                    ((XScreen)content.Control).Close();
            }

            // 기작성 Menu Clear
            mdiMenu.MenuCommands.Clear();

            // Cloud service
            // 2015.10.23 fixed https://nextop-asia.atlassian.net/browse/MED-4849
            //MdiFormSystemMenuArgs args = new MdiFormSystemMenuArgs();
            //args.UserId = UserInfo.UserID;
            //args.SystemId = this.systemID;
            //MdiFormSystemMenuResult result = CloudService.Instance.Submit<MdiFormSystemMenuResult, MdiFormSystemMenuArgs>(args);
            MdiFormMainMenuArgs args = new MdiFormMainMenuArgs();
            args.UserId = UserInfo.UserID;
            args.SystemId = this.systemID;
            args.HospCode = ""; // Get from server
            MdiFormMainMenuResult result = CloudService.Instance.Submit<MdiFormMainMenuResult, MdiFormMainMenuArgs>(args);

            // 재작성
            CreateMainMenu(true, result.Result, result.Msg, result.MenuItemInfo);

            //Docking된 화면 설정(환자리스트 Docking 화면)
            this.PerformCheckMenu();

            if (menuViewForm != null)
                menuViewForm.SetMenuTree();
            ResumeLayout(true);
        }
        #endregion

        #region ChangeUser (사용자 변경 처리)
        internal DialogResult ChangeUser(string userID, bool isEditableUserID)
        {
            // <<2013.12.08>> LKH : 사용자 변경 전 사용자 ID
            this.m_preUserID = UserInfo.UserID;
            //
            ChangeUserForm dlg = new ChangeUserForm(userID, isEditableUserID);
            DialogResult result = dlg.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                //사용자 변경 Sub Logic Call
                ChangeUserSub();
            }
            dlg.Dispose();
            //DialogResult Return
            return result;
        }
        //사용자변경, 사용자 Logout 서브 Logic
        private void ChangeUserSub()
        {
            //Delegator의 OnGroupUserLogOn, Method Call
            //현재 열려있는 GroupList ,SystemList를 검색하여 설정(현재는 GroupUserLogOn만 Call)
            //grpID 와 SysID, isFirst = false(처음 Call되는 것이 아니라, 사용자 변경에 의해 Call됨)
            foreach (string key in this.openedGroupList.Keys)
            {
                this.CallOnGroupUserLogOn(key, this.openedGroupList[key].ToString(), false);
            }

            //메뉴 재생성 처리
            this.RegenUserMenu();

            //현재 열려있는 화면에 사용자변경 Event Invoker Call
            try
            {
                foreach (XScreen screen in ScreenManager.OpenScreenList)
                {
                    if (screen.ScreenInfo != null)
                        screen.OnUserChanged();
                }
            }
            catch { }

            //IHIS 메인 Window에 MSG_SYSTEM_USER_CHANGED(사용자변경됨을 알림, XMSG에 변경사용자 전달)
            IntPtr wParam = IntPtr.Zero;
            string param = "";
            try
            {
                IntPtr IHISHandle = EnvironInfo.FindIHISHandle();
                if (IHISHandle != IntPtr.Zero)
                {
                    // <<2013.12.08>> LKH : 변경을 기존사용자 logout, 신규사용자 logon 으로 처리로 변경
                    ////wParam에 시스템ID + \t + 변경후사용자ID + \t + 변경후사용자명
                    //string param = this.SystemID + "\t" + UserInfo.UserID + "\t" + UserInfo.UserName;
                    //wParam = Marshal.StringToHGlobalAnsi(param);
                    //User32.PostMessage(IHISHandle, MSG_SYSTEM_USER_CHANGED, wParam, IntPtr.Zero);

                    // <<2013.12.08>> LKH : 사용자 변경 전 사용자 ID
                    if (this.m_preUserID.ToString().Equals(UserInfo.UserID.ToString())) { /* null */ ;}
                    else
                    {
                        Logs.WriteLog("change : old=" + this.m_preUserID + ", new=" + UserInfo.UserID);
                        // 새사용자 logon
                        wParam = Marshal.StringToHGlobalAnsi(this.SystemID);
                        User32.SendMessage(IHISHandle, MSG_SYSTEM_WINDOW_HANDLE_SEND, wParam, this.Handle);

                        //IHIS에 사용자 LOGIN MSG 전달  wParam에 SystemID + "\t" + SystemName + "\t" + UserID + "\t" + UserName + "\t" + Pswd
                        param = this.SystemID + "\t" + this.SystemName + "\t" + UserInfo.UserID + "\t" + UserInfo.UserName + "\t" + UserInfo.UserPswd;
                        wParam = Marshal.StringToHGlobalAnsi(param);
                        User32.PostMessage(IHISHandle, MSG_SYSTEM_USER_LOGIN, wParam, IntPtr.Zero);

                        // 기존사용자 logout
                        wParam = Marshal.StringToHGlobalAnsi(this.SystemID);
                        User32.SendMessage(IHISHandle, MSG_SYSTEM_WINDOW_HANDLE_SEND, wParam, this.Handle);

                        param = this.SystemID + "\t" + this.m_preUserID;
                        wParam = Marshal.StringToHGlobalAnsi(param);
                        User32.SendMessage(IHISHandle, MSG_SYSTEM_USER_LOGOUT, wParam, IntPtr.Zero);

                    }
                }
            }
            catch { }
            finally
            {
                //Memory 해제
                if (wParam != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(wParam);
            }

            //StatusBar Set
            SetStatusBar(UserInfo.UserName, UserInfo.BuseoName, UserInfo.UserID);

        }
        #endregion

        #region LogoutUser (사용자 Logout 처리, LogoutUserMenuClick, XScreen.LogoutUser에서 Call)
        internal void LogoutUser()
        {
            LogoutUserForm dlg = new LogoutUserForm();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                //사용자 변경 Sub Logic Call
                ChangeUserSub();
                dlg.Dispose();
            }
            else  //시스템 종료
            {
                dlg.Dispose();
                this.Close();
                Application.Exit();
            }

        }
        #endregion

        #region LockupSystem (화면 잠금 처리, 메뉴 Click , XScreen.LockupScreen에서 Call)
        internal void LockupScreen()
        {
            LeaveForm leaveForm = new LeaveForm(this.Location, this.Size);
            leaveForm.ShowDialog(this);
            leaveForm.Dispose();
        }
        #endregion

        #region ChangePassword (사용자 비밀번호 변경)
        internal DialogResult ChangePassword()
        {
            ChangePswdForm dlg = new ChangePswdForm(UserInfo.UserID);
            return dlg.ShowDialog();
        }
        #endregion

        #region SetSystemIcon(시스템 Icon 설정)
        protected virtual void SetSystemIcon()
        {
            FileStream fs = null;
            try
            {
                string fileName = EnvironInfo.ImagePath + "\\" + EnvironInfo.CurrSystemID + ".ico";
                if (File.Exists(fileName))
                {
                    fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    FileInfo fi = new FileInfo(fileName);
                    byte[] binary = new byte[fi.Length];
                    fs.Read(binary, 0, binary.Length);
                    MemoryStream ms = new MemoryStream(binary);
                    Icon icon = new Icon(ms, 16, 16);
                    if (icon != null)
                        this.Icon = icon;
                }
                else //없으면 공통 Icon 사용 (IHIS.ico)
                {
                    fileName = EnvironInfo.ImagePath + "\\IHIS.ico";
                    this.Icon = new Icon(fileName);
                }

            }
            catch { }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
        #endregion

        #region HandlingSystemMsg
        private void HandlingSystemMsg(string command, string udpMsg)
        {
            string msg = "";
            try
            {
                //어셈블리명은 시스템ID.Lib.SystemDelegator
                //파일위치는 C:\IHIS\시스템ID\시스템ID.Lib.SystemDelegator.dll
                //ClassType은 IHIS.시스템ID.SystemDelegator
                //Method명은 OnReceiveMessage(string command, string msg)
                string asmName = this.systemID + ".Lib.SystemDelegator";
                string fileName = Directory.GetParent(Application.StartupPath).FullName + "\\" + this.systemID + "\\" + asmName + ".dll";
                string classTypeName = "IHIS." + this.systemID + ".SystemDelegator";
                string methodName = "OnReceiveMessage";

                //File이 존재하는지 여부 Check
                if (!File.Exists(fileName))
                {
                    msg = XMsg.GetMsg("M074"); // 시스템메세지를 처리할 파일이 존재하지 않습니다.
                    this.SetMsg(msg, MsgType.Error);
                    return;
                }
                //SystemDelegator가 Loaded 되어 있느지 확인
                Assembly asm = LoadedAssembly(asmName);
                if (asm == null)
                {
                    asm = Assembly.LoadFrom(fileName);
                }
                Type classType = asm.GetType(classTypeName);
                if (classType == null)
                {
                    msg = XMsg.GetMsg("M075"); // 시스템메세지를 처리하지 못했습니다[처리Class미존재]"
                    this.SetMsg(msg, MsgType.Error);
                    return;
                }
                MethodInfo mInfo = classType.GetMethod(methodName);
                if (mInfo == null)
                {
                    msg = XMsg.GetMsg("M076"); // 시스템메세지를 처리하지 못했습니다[처리메서드미존재]"
                    this.SetMsg(msg, MsgType.Error);
                    return;
                }
                //Argument는 command, msg
                object[] objParams = new object[] { command, udpMsg };
                //Method Invoke
                mInfo.Invoke(null, objParams);
            }
            catch (Exception xe)
            {
                msg = XMsg.GetMsg("M077", xe); // 시스템메세지를 처리하지 못했습니다.에러[" + xe.Message + "]"
                this.SetMsg(msg, MsgType.Error);
                Debug.WriteLine("FormMdiParent::HandlingSystemMsg Error=" + xe.Message);
                Logs.WriteLog("FormMdiParent::HandlingSystemMsg Error[" + xe.Message + "]");
            }
        }
        #endregion

        #region SynchronizeSystemTime(PC시간과 서버시간 동기화)
        const long TIME_INTERVAL = 3000000000; //Ticks기준 5분(5분*60초*1천만)
        protected virtual void SynchronizeSystemTime()
        {
            try
            {
                DateTime serverTime = EnvironInfo.GetSysDateTime();

                //시간차이가 5분이상 발생시 동기화 경고창 띄움
                if (Math.Abs(serverTime.Ticks - DateTime.Now.Ticks) < TIME_INTERVAL) return;

                SetTimeForm dlg = new SetTimeForm(serverTime);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    //시간 동기화
                    Win32.SYSTEMTIME ST = new Win32.SYSTEMTIME();
                    //표준시간적용 (우리나라 표준시는 그리니치 표준시간보다 9시간 빠름)
                    serverTime = serverTime.AddHours(-9);
                    ST.Year = (ushort)serverTime.Year;
                    ST.Month = (ushort)serverTime.Month;
                    ST.Day = (ushort)serverTime.Day;
                    ST.Hour = (ushort)serverTime.Hour;
                    ST.Minute = (ushort)serverTime.Minute;
                    ST.Second = (ushort)serverTime.Second;
                    //SystemTime Set
                    Kernel32.SetSystemTime(ST);
                }
                dlg.Dispose();
            }
            catch { }
        }
        #endregion

        #region Check형식의 메뉴(환자명단에 속하는 메뉴 Handling)
        private void MenuChecked(object sender, EventArgs e)
        {
            ScreenMenuItem item = (ScreenMenuItem)sender;

            if (!item.Checked)  //UnChecked상태이면 성공시 Check
            {
                //해당 화면 Docking으로 Open
                if (item.MenuScreenInfo != null)
                {
                    //새로운 Docking으로 열기
                    //열기 성공시에 Registry에 HKLM/SOFTWARE/IHIS/DOCKING/사용자ID현재시스템ID/화면ID로 설정
                    item.MenuScreenInfo.OpenStyle = ScreenOpenStyle.Docking;
                    if (OpenNewScreen(this, item.MenuScreenInfo, (OpenCommand)null) != null)
                    {
                        SetRegistryDockingPgmID(true, item.MenuScreenInfo.PgmID);
                        //Checked 변경은 OpenNewScreen에서 처리함.
                    }
                }
            }
            else
            {
                //DockManager의 해당 화면 Close
                //RemoveDockingScreen을 하면 Contents에서는 사라지나 화면이 Dispose가 안됨
                //따라서, 화면.Close()를 통해 Contents를 닫고 Dispose함
                if (dockManager.Contents[item.MenuScreenInfo.Title] != null)
                {
                    ((XScreen)dockManager.Contents[item.MenuScreenInfo.Title].Control).Close();
                }
                //Registry에서 사용여부 N로 설정
                SetRegistryDockingPgmID(false, item.MenuScreenInfo.PgmID);
                //Check상태 변경은 RemoveDockingScreen에서 처리함
            }
        }
        private string GetSubKeyName()
        {
            //SubKey값(DOCKING_REGISTRY_PATH + 사용자ID
            /*return DOCKING_REGISTRY_PATH + UserInfo.UserID;*/
            return Constants.CacheKeyCbo.CACHE_COMMON_DOCKING_PREFIX + UserInfo.UserID + ".";
        }
        private void SetRegistryDockingPgmID(bool isReg, string pgmID)
        {
/*            RegistryKey rKey = Registry.LocalMachine;
            //SubKey값(DOCKING_REGISTRY_PATH + 사용자ID + 현재시스템ID)
            string keyName = GetSubKeyName();
            RegistryKey rKey1 = rKey.OpenSubKey(keyName, true);
            if (rKey1 == null)
                rKey1 = rKey.CreateSubKey(keyName);
            //프로그램ID의 값, 등록시 Y, 등록해제시 N
            rKey1.SetValue(pgmID, (isReg ? "Y" : "N"));
            rKey1.Close();*/
            string keyName = GetSubKeyName();
            CacheService.Instance.Set(keyName + pgmID, (isReg ? "Y" : "N"), TimeSpan.MaxValue);
        }
        protected virtual void PerformCheckMenu()
        {
            //메뉴 생성후 최초 LKLM/SOFTWARE/IHIS/DOCKING/현재시스템ID에 등록된 화면 List중에서 Y(Check된상태인 메뉴는
            //Click Event를 발생시켜 환자리스트 보여주기
            //최초 기준은 Registry에 등록이 Y인 메뉴, MenuItem.MenuParam이 Y(메뉴정보의 Parameter에 
            //최초 오픈 여부 관리)인 메뉴는 모두 등록
            if (this.checkMenuList.Count < 1) return;

            /*RegistryKey rKey = Registry.LocalMachine;
            //SubKey값
            string keyName = GetSubKeyName();
            RegistryKey rKey1 = rKey.OpenSubKey(keyName, true);
            if (rKey1 == null)
                rKey1 = rKey.CreateSubKey(keyName);*/
            string keyName = GetSubKeyName();
            ScreenMenuItem menuItem = null;
            string keyValue = "";
            foreach (string pgmID in this.checkMenuList)
            {
                if (this.checkMenuItemList.Contains(pgmID))
                {
                    menuItem = this.checkMenuItemList[pgmID] as ScreenMenuItem;
                    /*keyValue = rKey1.GetValue(pgmID, "N").ToString();*/
                    keyValue = CacheService.Instance.Get(keyName + pgmID, "N").ToString();
                    if (menuItem != null)
                    {
                        //개발자가 Y로 설정한 메뉴우선 -> Registry에 Y로 등록된 메뉴 Check
                        //개발자가 Y로 설정한 메뉴는 Check상태에서 UnCheck불가
                        if (menuItem.MenuParam == "Y")  //MenuParam에 최초 Open여부가 Y이면
                        {
                            MenuChecked(menuItem, EventArgs.Empty);
                            //개발자가 Y로 Check한 화면은 UnCheck불가하게 처리함.
                            menuItem.Enabled = false;
                        }
                        else if (keyValue == "Y")  //Registry에 Y로 등록된 Check 메뉴
                            MenuChecked(menuItem, EventArgs.Empty);

                    }
                }
            }
            /*rKey1.Close();*/

        }
        #endregion

        #region OpenMainScreen (시스템별 메인화면을 조회하여 메인 Screen Open)
        private void OpenMainScreen(MdiFormMainMenuResult mainMenuResult)
        {
            //ADM0500.시스템별 메인화면
            /*string cmdText = "SELECT PGM_SYS_ID, PGM_ID FROM ADM0500 WHERE SYS_ID = '" + this.systemID + "'";
            DataTable table = Service.ExecuteDataTable(cmdText);
            if (table != null)
            {
                foreach (DataRow dtRow in table.Rows)
                {
                    ScreenManager.OpenMainScreen(this, dtRow[0].ToString(), dtRow[1].ToString());
                }
            }*/

            // updated by Cloud
            MdiFormOpenMainScreenArgs args = new MdiFormOpenMainScreenArgs();
            args.SystemId = this.systemID;
            MdiFormOpenMainScreenResult res = CloudService.Instance.Submit<MdiFormOpenMainScreenResult, MdiFormOpenMainScreenArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (MdiFormOpenMainScreenInfo item in res.MainScreenItem)
                {
                    //SUB-TASK MED-13259
                    if(NetInfo.Language == LangMode.Vi && this.SystemID == "OUTS")
                    {
                        ScreenManager.OpenMainScreen(this, item.PgmSysId, item.PgmId);
                        ScreenManager.OpenMainScreen(this, "NURO", "OUT0101U02");
                        ScreenManager.OpenMainScreen(this, "NURO","OUT1001U01");
                    }
                    else
                        ScreenManager.OpenMainScreen(this, item.PgmSysId, item.PgmId);
                }
            }
        }
        #endregion

        #region SendLoginMsgToIHIS (IHIS로 Handle 및 LOGIN 메세지 전달)
        //IFC에 Mdi의 Handle을 등록하고, LOGIN을 등록함 (OATV등 메세지시스템에서는 기능 없음)
        protected virtual void SendLoginMsgToIHIS()
        {
            //선택창에 Mdi의 Handle을 보내 Handle을 관리하게 함
            //시스템명은 wParam에 WindowHandle은 LParam으로 보냄
            IntPtr IHISHandle = EnvironInfo.FindIHISHandle();
            if (IHISHandle != IntPtr.Zero)
            {
                IntPtr wParam = Marshal.StringToHGlobalAnsi(this.SystemID);
                User32.SendMessage(IHISHandle, MSG_SYSTEM_WINDOW_HANDLE_SEND, wParam, this.Handle);

                Logs.WriteLog("logon : " + UserInfo.UserID);
                //IHIS에 사용자 LOGIN MSG 전달  wParam에 SystemID + "\t" + SystemName + "\t" + UserID + "\t" + UserName + "\t" + Pswd
                string param = this.SystemID + "\t" + this.SystemName + "\t" + UserInfo.UserID + "\t" + UserInfo.UserName + "\t" + UserInfo.UserPswd;
                wParam = Marshal.StringToHGlobalAnsi(param);
                User32.PostMessage(IHISHandle, MSG_SYSTEM_USER_LOGIN, wParam, IntPtr.Zero);
            }
        }
        #endregion

        #region SetActiveColorStyle (ColorStyle 적용)
        public virtual bool SetActiveColorStyle(string styleName)
        {
            if (ColorStyle.SetActiveColorStyle(styleName))
            {
                //Invalidate를 Call하여 변경된 색을 반영
                //MenuControl Gradient 색깔 변경
                //DockingManager Gradient 색깔 변경
                this.dockManager.SetGradientColor(XColor.DockingGradientStartColor.Color, XColor.DockingGradientEndColor.Color);
                this.mdiMenu.SetGradientColor(XColor.MenuGradientStartColor.Color, XColor.MenuGradientEndColor.Color);
                this.Invalidate(true);
                return true;
            }
            return false;
        }
        #endregion

        private MdiFormMainMenuResult LoadAllMenu()
        {
            MdiFormMainMenuArgs args = new MdiFormMainMenuArgs();
            args.UserId = UserInfo.UserID;
            args.SystemId = this.systemID;
            args.HospCode = ""; // Get from server
            return CloudService.Instance.Submit<MdiFormMainMenuResult, MdiFormMainMenuArgs>(args);
        }

        private void SetHyperLink()
        {
            pnlHyperLink.Text = Service.GetConfigString("HOMEPAGE", "URL", string.Empty);
        }

        private void mdiStatusBar_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {
            if (e.StatusBarPanel.Name == "pnlHyperLink")
            {
                string homePage = Service.GetConfigString("HOMEPAGE", "URL", string.Empty);
                Process.Start(homePage);
            }
        }

        private void mdiStatusBar_MouseHover(object sender, EventArgs e)
        {
            //Cursor = Cursors.Hand;
        }

        private void mdiStatusBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >= X1 && e.X <= X2 && e.Y >= Y1 && e.Y <= Y2)
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }


    }

    #region TickTockForm
    /// <summary>
    /// TickTockForm에 대한 요약 설명입니다.
    /// </summary>
    internal class TickTockForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;

        public TickTockForm()
        {
            //
            // Windows Form 디자이너 지원에 필요합니다.
            //
            InitializeComponent();

        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormTemp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(10, 10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTemp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormTemp";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;

        }
        #endregion

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
    #endregion
}