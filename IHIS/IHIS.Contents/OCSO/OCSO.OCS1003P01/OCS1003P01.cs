using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.OCS;
using System.Threading;
using IHIS.OCSO.Properties;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;

namespace IHIS.OCSO
{
    public partial class OCS1003P01 : IHIS.Framework.XScreen
    {
        public OCS1003P01()
        {
            try
            {
                InitializeComponent();
                btnAplOrder.Enabled = true;
                // https://nextop-asia.atlassian.net/browse/MED-5780
                btnIpwonReser.Visible = false;
                grdOutSang.ParamList = new List<string>(new string[] { "f_bunho", "f_naewon_date", "f_gwa" });
                //Fix bug MED-8253
                if (UserInfo.HospCode == "342")
                {
                    btnChuchiOrder.Text = "Nha Khoa";
                }             
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
            }
        }

        #region 각종변수들
        //Message처리
        string mbxMsg = "", mbxCap = "";
        private string IO_Gubun = "O";
        private Hashtable groupInfo;
        private string iInputGubunName = ""; // 입력구분명 Do, Setオーダ用

        public bool mPostApproveYN = false;
        private bool mPostApprove_Visible = false;
        private bool mApprove_Force = false;

        public int mInsteadInsertedOrderCnt = 0;
        public int mInsteadUpdatedOrderCnt = 0;
        public int mInsteadDeletedOrderCnt = 0;
        private String allWarning = "";

        //Group
        ArrayList groupCount;

        public string mChangeBeforeGwa = "";
        private string mClickedOrderButton = "";
        // CP관련 키
        private string mMembGubun = "";
        private string mCpCode = "";
        private string mJaewonil = "";
        private string mCpPathCode = "";
        private string mCpMasterkey = "";

        //입원외래 order
        private string mPkInOutKey = "";

        // 셋트오더 관련 _ 키
        private string mMemb = "";
        private string mYaksokCode = "";  // 셋트이면 약속코드, Cp 이면 Cp Code 가 들어감.

        // 포커스를 위한 로우 번호
        private int mFocusRow = -1;

        private string mMsg = "";
        private string mCap = "";

        ///////////////////////////////////////////////////////////////////////////////////
        // 대기환자리스트 관련
        ///////////////////////////////////////////////////////////////////////////////////
        private XColor mReserPatientColor = new XColor(Color.LightGreen);

        private XColor mKensaReserPatientColor = new XColor(Color.SkyBlue);


        ///////////////////////////////////////////////////////////////////////////////////
        // 입력구분 색관련
        ///////////////////////////////////////////////////////////////////////////////////
        private XColor mExistInputGubunColor = new XColor(Color.Red);
        private XColor mNormalInputGubunColor = new XColor(Color.Black);

        ///////////////////////////////////////////////////////////////////////////////////
        // 상병 확장 관련
        ///////////////////////////////////////////////////////////////////////////////////

        const int mSizeSB = 185;

        private int mExpandedIndex = 2;//↑
        private int mUnExpandedIndex = 1;//↓

        private int mExpandedSize = mSizeSB;
        private int mUnExpandedSize = 0; //37

        private bool mIsExpanded = true;

        private int mExpandedSBIndex = 1; //↑
        private int mUnExpandedSBIndex = 2; //↓

        private int mExpandedSBSize = (mSizeSB * 2);
        private int mUnExpandedSBSize = mSizeSB; //37

        private bool mIsExpandedSB = false;



        ///////////////////////////////////////////////////////////////////////////////////
        // 라디오버튼 관련
        ///////////////////////////////////////////////////////////////////////////////////
        private XColor mSelectedBackColor = new XColor(Color.FromName("ActiveCaption"));
        private XColor mSelectedForeColor = new XColor(Color.FromName("ActiveCaptionText"));

        private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));
        private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));

        private int mInputTabDefaultWidth = 90;
        private int mInputTabDefaultHeight = 26;
        private int mInputTabDefaultYLoc = 4;
        private int mInputTabDefaultXLoc = 38;

        ///////////////////////////////////////////////////////////////////////////////////
        // 라이브러리
        ///////////////////////////////////////////////////////////////////////////////////
        private OCS.PatientInfo.clsParameter mPatientInfoParam = new IHIS.OCS.PatientInfo.clsParameter();
        private OCS.PatientInfo mSelectedPatientInfo;
        private OCS.OrderBiz mOrderBiz = new IHIS.OCS.OrderBiz("OCS1003P01");
        private OCS.OrderFunc mOrderFunc = new IHIS.OCS.OrderFunc("OCS1003P01");
        private OCS.HangmogInfo mHangmogInfo = new HangmogInfo("OCS1003P01");
        private OCS.CommonForms mCommonForms = new CommonForms();
        private OCS.OrderInterface mInterface = new OrderInterface();


        ///////////////////////////////////////////////////////////////////////////////////
        // 로컬변수
        ///////////////////////////////////////////////////////////////////////////////////
        private string mParamNaewonKey = "";
        //private string mParamNaewonDate = "";
        private string mParamBunho = "";
        private string mParamGwa = "";
        private string mParamDoctor = "";
        private ArrayList mBunhoInfoControls = new ArrayList();

        private bool mDoctorLogin = false;
        private bool mIsOCSSystem = false;

        private bool mPatientDoubleClick = false;

        // Do, Set Order用
        private string iInputGubun = "";
        // 既存外来オーダ情報照会用
        public string mInputGubun = "";
        private string mInputGwa = "";
        //GROUP_KEY
        private string mGroup_key = "";

        private string mClickedNaewonKey = "";
        //insert by jc [選択された患者の保険を取得]
        private string mClickedGubun = "";

        private const string mInputGubunDoctor = "D%";

        //Doオーダ関連変数
        private string INPUTTAB = ""; // 내복약 (01) 
        private const string IOEGUBUN = "O";     // 입외구분(외래)

        private string mInputPart = "";      // 입력파트(01)
        //private string mCallerSysID = "";
        //private string mCallerScreenID = "";

        //공통
        private string mOrderDate = "";
        private OrderVariables.OrderMode mOrderMode;

        //insert by jc[Sysdateを保存ボタンを押す時点の時間にするため]
        //internal string mSave_time = "";

        // 저장용 flag 변수 
        bool mIsUpdateSuccess = false;


        // 체크용 플레그 변수
        bool mIsCheck = false;

        // 팝업메뉴
        private IHIS.X.Magic.Menus.PopupMenu mMenuPFEResult = new IHIS.X.Magic.Menus.PopupMenu();
        private IHIS.X.Magic.Menus.PopupMenu mMenuInputGubunResult = new IHIS.X.Magic.Menus.PopupMenu();

        ///////////////////////////////////////////////////////////////////////////////////
        // 진료 종료 관련
        ///////////////////////////////////////////////////////////////////////////////////
        private const string JINRYO_END = "E";
        private const string JINRYO_BORYU = "H";
        private const string MI_JINRYO = "Y";

        private string mCurrentInputTab = "";

        private bool mIsCalledbyOtherScreen = false;

        // CPL 출력 리스트 관련
        private ArrayList mCplPrintList = new ArrayList();

        // Key for save cache master data
        private const string GET_DEPARTMENT_KEYS = "Combo.Gwa";
        private const string MAKE_INPUT_GUBUN_TAB_NR_KEY = "MakeInputGubunTab.NR";
        private const string MAKE_INPUT_GUBUN_TAB_D0_KEY = "MakeInputGubunTab.D0";

        private List<OcsoOCS1003P01LayoutQueryInfo> lstOutOrderInfo;
        private OCS1003P01GrdPatientResult grdPatientResult;
        private String mProtocolID = "";

        #endregion

        #region [ Screen 이벤트 ]

        private void OCS1003P01_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // https://sofiamedix.atlassian.net/browse/MED-12895
            btnQryOrderInfo.Location = new Point(7, btnQryOrderInfo.Location.Y);
            btnEtcJinryo.Location = new Point(7, btnEtcJinryo.Location.Y);
            btnAllergy.Location = new Point(7, btnAllergy.Location.Y);
            btnComment.Location = new Point(7, btnComment.Location.Y);
            btnVital.Location = new Point(7, btnVital.Location.Y);
            btnSetOrder.Location = new Point(7, btnSetOrder.Location.Y);
            btnDoOrder.Location = new Point(7, btnDoOrder.Location.Y);

            if (SystemInformation.VirtualScreen.Width == 1440 && SystemInformation.VirtualScreen.Height == 900)
            {
                btnApprove.Location = new Point(btnApprove.Location.X - 110, btnApprove.Location.Y);
                pbxApprove.Location = new Point(pbxApprove.Location.X - 110, pbxApprove.Location.Y);
            }

            if (SystemInformation.VirtualScreen.Width == 1366 && SystemInformation.VirtualScreen.Height == 768)
            {
                btnKensaReser.Location = new Point(btnKensaReser.Location.X - 50, btnKensaReser.Location.Y);
                btnApprove.Location = new Point(btnApprove.Location.X - 130, btnApprove.Location.Y);
                pbxApprove.Location = new Point(pbxApprove.Location.X - 130, pbxApprove.Location.Y);
            }

            if (SystemInformation.VirtualScreen.Width == 1280 && SystemInformation.VirtualScreen.Height == 1024)
            {
                btnKensaReser.Location = new Point(btnKensaReser.Location.X - 50, btnKensaReser.Location.Y);
                btnApprove.Location = new Point(btnApprove.Location.X - 220, btnApprove.Location.Y);
                pbxApprove.Location = new Point(pbxApprove.Location.X - 220, pbxApprove.Location.Y);
            }

            if (EnvironInfo.CurrSystemID == "INSI" && UserInfo.Gwa != "CK")
            {
                return;
            }
            // 화면 사이즈 조정
            // 화면 크기를 화면에 맞게 최대화 시킨다 (다른 화면에서 연경우가 아닌경우)
            //if (this.Opener is IHIS.Framework.MdiForm &&
            //    (this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed))
            //{ 
            //    Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            //    this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 110);
            //}

            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 110);

            // 환자번호 입력자릿수 설정
            this.fbxBunho.MaxLength = EnvironInfo.BunhoLength;
            

            // 환자번호 컨트롤 셋팅
            this.mBunhoInfoControls.Add(this.fbxBunho);
            this.mBunhoInfoControls.Add(this.lbSuname);
            this.mBunhoInfoControls.Add(this.lbSuname2);
            this.mBunhoInfoControls.Add(this.lbSexAge);
            this.mBunhoInfoControls.Add(this.lbWeight);
            this.mBunhoInfoControls.Add(this.lbHeight);
            this.mBunhoInfoControls.Add(this.lbGubunName);
            this.mBunhoInfoControls.Add(this.lbChojaeName);

            // 각종 변수 초기화
            this.mSelectedPatientInfo = new IHIS.OCS.PatientInfo(this.Name);  // 환자정보 

            if (EnvironInfo.CurrSystemID == "OCSA" ||
                EnvironInfo.CurrSystemID == "OCSO" ||
                EnvironInfo.CurrSystemID == "OCSI")
            {
                this.mIsOCSSystem = true;
            }

            // 팝업메뉴 초기화
            // 오더 팝업메뉴
            // 처방Grid PopupMenu
            mMenuPFEResult.MenuCommands.Clear();
            btnENDOResult.Location = new Point(3, 645);
            CheckHideButtonArgs args = new CheckHideButtonArgs();
            args.CodeType = "RESULT_BUTTON_USE_YN";
            CheckHideButtonResult result = CloudService.Instance.Submit<CheckHideButtonResult, CheckHideButtonArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                bool check = false;
                foreach (CheckHideButtonInfo item in result.Dt)
                {
                    if (item.CodeName.Equals("Y"))
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    CheckHideButtonInfo item;
                    IHIS.X.Magic.Menus.MenuCommand popUpMenu;
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_6, (Image)this.ImageList.Images[21], new EventHandler(btnImageResult_Click));
                    popUpMenu.Tag = "1";
                    item = GetItemHideButton(result.Dt, "CPL");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_7, (Image)this.ImageList.Images[19], new EventHandler(btnXRTResult_Click));
                    popUpMenu.Tag = "2";
                    item = GetItemHideButton(result.Dt, "XRT");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_1, (Image)this.ImageList.Images[29], new EventHandler(PopUpMenuPfeResult_Click));
                    popUpMenu.Tag = "3";
                    item = GetItemHideButton(result.Dt, "END");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_2, (Image)this.ImageList.Images[14], new EventHandler(PopUpMenuPfeResult_Click));
                    popUpMenu.Tag = "4";
                    item = GetItemHideButton(result.Dt, "ENDR");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_3, (Image)this.ImageList.Images[10], new EventHandler(PopUpMenuPfeResult_Click));
                    popUpMenu.Tag = "5";
                    item = GetItemHideButton(result.Dt, "EKG");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_8, (Image)this.ImageList.Images[38], new EventHandler(xbtRehaActedOrder_Click));
                    popUpMenu.Tag = "6";
                    item = GetItemHideButton(result.Dt, "REH");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                }
                else
                {
                    btnENDOResult.Visible = false;
                }
            }



            mMenuInputGubunResult.MenuCommands.Clear();
            IHIS.X.Magic.Menus.MenuCommand popUpMenu_InputGubun;

            popUpMenu_InputGubun = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_4, (Image)this.ImageList.Images[6], new EventHandler(PopUpMenuInputGubunResult_Click));
            popUpMenu_InputGubun.Tag = "D0";
            mMenuInputGubunResult.MenuCommands.Add(popUpMenu_InputGubun);

            popUpMenu_InputGubun = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_5, (Image)this.ImageList.Images[45], new EventHandler(PopUpMenuInputGubunResult_Click));
            popUpMenu_InputGubun.Tag = "CK";
            mMenuInputGubunResult.MenuCommands.Add(popUpMenu_InputGubun);


            // SavePerformer Setting 
            this.layDeletedData.SavePerformer = new XSavePeformer(this);
            this.laySaveLayout.SavePerformer = this.layDeletedData.SavePerformer;
            this.grdOutSang.SavePerformer = this.layDeletedData.SavePerformer;

            // User Change 이벤트 구동
            this.mIsCheck = true;
            this.OCS1003P01_UserChanged(this, new EventArgs());
            this.mIsCheck = false;

            //this.btnHelp2.Location = new Point(btnHelp2.Location.X, this.btnHelp2.Location.Y - this.pnlUser.Size.Height);
            //this.pnlHelp2.Location = new Point(pnlHelp2.Location.X, this.pnlHelp2.Location.Y - this.pnlUser.Size.Height);

            PostCallHelper.PostCall(new PostMethod(PostOpenEvent));

            this.initScreen();
            if (this.OpenParam != null)
            {
                if (this.OpenParam.Contains("bunho"))
                {
                    this.fbxBunho.SetEditValue(this.OpenParam["bunho"].ToString());
                    this.fbxBunho.AcceptData();
                }
            }
        }

        private CheckHideButtonInfo GetItemHideButton(List<CheckHideButtonInfo> lst, string code)
        {
            foreach (CheckHideButtonInfo item in lst)
            {
                if (item.Code.Equals(code)) return item;
            }
            return null;
        }

        private void PopUpMenuInputGubunResult_Click(object sender, System.EventArgs e)
        {
            IHIS.X.Magic.Menus.MenuCommand btn = sender as IHIS.X.Magic.Menus.MenuCommand;

            if (this.IsGrantOrderUser(btn.Tag.ToString()) == false) return;

            switch (this.mClickedOrderButton)
            {
                case "10":
                    this.OpenScreen_OCS0103U10(true, btn.Tag.ToString());
                    break;
                case "11":
                    this.OpenScreen_OCS0103U11(true, btn.Tag.ToString());
                    break;
                case "12":
                    this.OpenScreen_OCS0103U12(true, btn.Tag.ToString());
                    break;
                case "13":
                    this.OpenScreen_OCS0103U13(true, btn.Tag.ToString());
                    break;
                case "14":
                    this.OpenScreen_OCS0103U14(true, btn.Tag.ToString());
                    break;
                case "15":
                    this.OpenScreen_OCS0103U15(true, btn.Tag.ToString());
                    break;
                case "16":
                    this.OpenScreen_OCS0103U16(true, btn.Tag.ToString());
                    break;
                case "17":
                    this.OpenScreen_OCS0103U17(true, btn.Tag.ToString());
                    break;
                case "18":
                    this.OpenScreen_OCS0103U18(true, btn.Tag.ToString());
                    break;
                case "19":
                    this.OpenScreen_OCS0103U19(true, btn.Tag.ToString());
                    break;
            }

        }

        private void initScreen()
        {
            if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "EMR_POP_YN", this.IO_Gubun) == "Y")

                //this.grdReserOrderList.AutoSizeColumn(1, 0); // オーダー日
                this.grdReserOrderList.AutoSizeColumn(2, 0); // 実施予定日
            this.grdReserOrderList.AutoSizeColumn(3, 0); // 診療科
            //this.grdReserOrderList.AutoSizeColumn(5, 0); // 診療医
            //this.grdReserOrderList.AutoSizeColumn(4, 0); // オーダー名
            this.grdReserOrderList.AutoSizeColumn(6, 0); // 実施部署
            this.grdReserOrderList.AutoSizeColumn(7, 0); // 当/予
            this.grdReserOrderList.AutoSizeColumn(8, 0); // 予約日付
            this.grdReserOrderList.AutoSizeColumn(9, 0); // 未/完

            this.mPostApproveYN = false;
            this.lblApproveFlag.Text = Resources.LBLAPPROVEFLAG_TEXT_1;

            // 承認プロセス関連FLAG取得
            this.mOrderBiz.GetApproveFlags(ref this.mPostApprove_Visible, ref this.mApprove_Force);

            //if (!this.mPostApprove_Visible)
            //    this.lblApprove.Visible = false;　// 事後承認を見せない

            // ログインしたユーザーが代行者であれば
            if (UserInfo.Gwa == "CK")
            {
                this.cbxMsgSysYN.Visible = true;
                this.cbxMsgSysYN.Checked = true;
            }
            else
            {
                this.cbxMsgSysYN.Visible = false;
            }
        }

        private void PostOpenEvent()
        {
            // InputTab 탭 구성 -- 사이즈 계산을 제대로 못함. 여기서 해야함
            this.MakeInputTab();

            this.lblJinryoGwa.Location = new Point(this.cboOutSang.Location.X + this.cboOutSang.Size.Width + 10, 5);

            this.cboJinryoGwa.Location = new Point(this.lblJinryoGwa.Location.X + this.lblJinryoGwa.Size.Width + 5, 5);

        }

        private void OCS1003P01_UserChanged(object sender, EventArgs e)
        {
            // 일단 전체 클리어 해놓고 
            this.cboQryGwa.SelectedValueChanged -= new EventHandler(cboQryGwa_SelectedValueChanged);
            this.Reset();
            this.cboQryGwa.SelectedValueChanged += new EventHandler(cboQryGwa_SelectedValueChanged);
            // 사용자권한체크
            IsOrderInputUserCheck(true);

            this.InitializeScreen(mIsCheck);
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        #region [ 각종 오더 입력 버튼 ]

        /// <summary>
        /// 약오더 입력버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrgOrder_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.mClickedOrderButton = button.Tag.ToString();

            this.OpenScreen_OCS0103U10(true);

        }

        /// <summary>
        /// 주사오더 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJusaOrder_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.mClickedOrderButton = button.Tag.ToString();

            this.OpenScreen_OCS0103U12(true);

        }

        /// <summary>
        /// 검체검사 오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCplOrder_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.mClickedOrderButton = button.Tag.ToString();

            this.OpenScreen_OCS0103U13(true);
        }

        /// <summary>
        /// 처치오더 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChuchiOrder_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.mClickedOrderButton = button.Tag.ToString();

            this.OpenScreen_OCS0103U17(true);
        }

        /// <summary>
        /// 수술오더 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSusulOrder_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.mClickedOrderButton = button.Tag.ToString();

            this.OpenScreen_OCS0103U18(true);

        }

        /// <summary>
        /// 생리검사 오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPfeOrder_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.mClickedOrderButton = button.Tag.ToString();

            this.OpenScreen_OCS0103U14(true);

        }

        /// <summary>
        /// 병리검사 오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAplOrder_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.mClickedOrderButton = button.Tag.ToString();

            this.OpenScreen_OCS0103U15(true);
        }

        /// <summary>
        /// 방사선 오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXrtOrder_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.mClickedOrderButton = button.Tag.ToString();

            this.OpenScreen_OCS0103U16(true);
        }

        /// <summary>
        /// 기타 오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEtcOrder_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.mClickedOrderButton = button.Tag.ToString();

            this.OpenScreen_OCS0103U19(true);
        }

        /// <summary>
        /// リハビリ依頼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReha_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            bool checkflg = false;
            int ChangedCnt = 0;

            if (this.IsPatientSelected() == false) return;

            // 修正されているROWがあるかチェック
            for (int i = 0; i < this.grdOutSang.RowCount; i++)
            {
                if (this.grdOutSang.GetRowState(i) != DataRowState.Unchanged)
                    ChangedCnt++;
            }

            // 修正されているROWがあればまず保存する
            if (ChangedCnt >= 0)
            {
                //tungtx
                // Save grdOutSang
                List<OcsoOCS1003P01GridOutSangInfo> grdList = LoadListFromGrdOutSang();
                OcsoOCS1003P01GrdOutSangSaveLayoutArgs args = new OcsoOCS1003P01GrdOutSangSaveLayoutArgs();
                args.GrdOutSangList = grdList;
                args.UserId = UserInfo.UserID;
                UpdateResult result = CloudService.Instance.Submit<UpdateResult, OcsoOCS1003P01GrdOutSangSaveLayoutArgs>(args);

                //if (this.grdOutSang.SaveLayout() == false)
                //tungtx
                if (result == null || result.Result == false)
                {
                    this.mMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                    MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkflg = false;
                }
            }

            // 現在傷病があるかチェックしあれば画面を開く、傷病がなければ傷病登録させる
            if (this.grdOutSang.RowCount >= 1)
                checkflg = true;
            else
                checkflg = false;

            if (checkflg)
            {
                if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

                this.mClickedOrderButton = button.Tag.ToString();

                this.OpenScreen_OCS0103U11(true);
            }
            else
            {
                XMessageBox.Show(Resources.MSG001_MSG, Resources.MSG001_CAP);
                this.btnListSB.PerformClick(FunctionType.Insert);
            }
        }



        #endregion

        #region [ 버튼 이벤트  ]

        #region [ 상병 확장버튼 ]

        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (this.mIsExpanded)
            {
                this.pnlSang.Size = new Size(this.pnlSang.Size.Width, this.mUnExpandedSize);
                this.btnExpand.ImageIndex = this.mUnExpandedIndex;

                this.mIsExpanded = false;
            }
            else
            {
                this.pnlSang.Size = new Size(this.pnlSang.Size.Width, this.mExpandedSize);
                this.btnExpand.ImageIndex = this.mExpandedIndex;

                this.mIsExpanded = true;
            }
        }

        #endregion



        private void btnOpenOutSang_Click(object sender, EventArgs e)
        {
            if (mSelectedPatientInfo != null && mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                this.OpenScreen_OUTSANGU00(IO_Gubun, this.fbxBunho.GetDataValue(), this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(), this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString());

                // 환자상병조회
                this.LoadOutSang(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());

            }

        }

        private void btnIpwonReser_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser() == false) return;

            // 未承認オーダーがあれば入院時オーダー
            if (this.mOrderBiz.GetNotBeforeApproveOrderCnt(IO_Gubun, UserInfo.UserID, "Y", "N", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) > 0)
            {
                XMessageBox.Show(Resources.MSG002_MSG, Resources.MSG001_CAP, MessageBoxButtons.OK);
                this.btnApprove.PerformClick();
                return;
            }

            this.OpenScreen_INP1003U01(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                      , this.dtpNaewonDate.GetDataValue()
                                      , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            if (EnvironInfo.CurrSystemID != "INSO")
            {
                if (this.mOrderBiz.IsIpwonReserStatus(this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                                     , this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()) == true)
                {
                    this.pbxInpReserYN.Visible = true;

                    if (this.mOrderBiz.GetNaewonYN(this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) != "E"
                        && XMessageBox.Show(Resources.MSG003_MSG, Resources.MSG001_CAP, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        this.btnList.PerformClick(FunctionType.Process);
                    }
                }
                else
                {
                    this.pbxInpReserYN.Visible = false;
                }
            }
        }

        private void btnConsult_Click(object sender, EventArgs e)
        {
            //if (!this.IsPatientSelected()) return;

            if (this.IsGrantOrderUser() == false) return;

            this.OpenScreen_OCS0503U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                //insert by jc
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            if (this.mDoctorLogin)
            {
                int etcJinryoCnt = this.mOrderBiz.GetOutTaGwaJinryoCnt(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                                                      , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());

                if (etcJinryoCnt > 0)
                {
                    this.pbxEtcJinryo.Visible = true;

                    // 진료의뢰후 메세지 출력
                    //MessageBox.Show(XMsg.GetMsg("M011"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.pbxEtcJinryo.Visible = false;
                }
            }




        }

        private void btnConsultAnswer_Click(object sender, EventArgs e)
        {
            //if (!this.pbxConsultAnswer.Visible) return;

            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser() == false) return;

            this.OpenScreen_OCS0503U01(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

        }

        private void btnOrderPrint_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_OCS1003R00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                      , false);
        }

        private void btnOrderGuide_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_OCS1003R02(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                      , false);
        }

        private void btnDCBANNAB_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            OpenScreen_OCS1003U01(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                                 , this.mInputGubun);
        }

        // 오더정보조회 화면 오픈 
        private void btnQryOrderInfo_Click(object sender, EventArgs e)
        {
            //if (!this.IsPatientSelected()) return;

            this.OpenScreen_OCS1003Q05(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(), this.dtpNaewonDate.GetDataValue());
        }

        private void btnEtcJinryo_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_OCS1003Q02(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());


        }

        private void btnImageResult_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_ScanViewer(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        }

        private void btnVital_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_NUR7001U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        }

        #endregion

        #region [ 라디오 버튼 ]

        #region [ 오더구분 라디오 버튼 ]

        private void rbnOrder_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton control = sender as XRadioButton;

            if (control.Checked)
            {
                control.ImageIndex = 3;
                control.BackColor = this.mSelectedBackColor;
                control.ForeColor = this.mSelectedForeColor;

                mCurrentInputTab = control.Tag.ToString();

                this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
            }
            else
            {
                control.ImageIndex = 4;
                control.BackColor = this.mUnSelectedBackColor;
                control.ForeColor = this.mUnSelectedForeColor;
            }
        }

        #endregion

        #region [ 진료여부 라디오 버튼 ]

        private void rbnNotJinryo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton control = sender as RadioButton;

            if (control.Checked)
            {
                control.ImageIndex = 3;
                control.BackColor = this.mSelectedBackColor.Color;
                control.ForeColor = this.mSelectedForeColor.Color;

                // 환자 리스트 필터링
                this.SetPatientListGridFilter();
            }
            else
            {
                control.ImageIndex = 4;
                control.BackColor = this.mUnSelectedBackColor.Color;
                control.ForeColor = this.mUnSelectedForeColor.Color;
            }
        }

        #endregion

        #endregion

        #region [ 파인드 박스 ]

        private void fbxBunho_FindClick(object sender, CancelEventArgs e)
        {
            this.OpenScreen_OUT0101Q01();
        }

        #endregion

        #region [ 탭 페이지 ]

        private void tabInputGubun_SelectionChanged(object sender, EventArgs e)
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabInputGubun.TabPages)
            {
                if (tpg == this.tabInputGubun.SelectedTab)
                {
                    tpg.ImageIndex = 3;

                    this.DislplayOrderDataWindow(tpg.Tag.ToString(), this.mCurrentInputTab);
                }
                else
                {
                    tpg.ImageIndex = 4;
                }
            }
        }

        #endregion

        #region [ 콤보박스 ]

        void cboQryGwa_SelectedValueChanged(object sender, EventArgs e)
        {
            this.ChangeUser();
        }

        private void ChangeUser()
        {
            #region [再ログイン]

            string gwa = this.cboQryGwa.GetDataValue();
            string gwaName = "";
            string errMsg = "";

            if (gwa == "")
                return;

            //ドクターの場合のみ再ログインをする。
            if (this.mDoctorLogin)
            {

                //string cmdStr = "SELECT A.GWA_NAME"
                //                + "  FROM BAS0260 A"
                //                + " WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'"
                //                + "   AND A.GWA   = '" + gwa + "'"
                //                + "   AND SYSDATE BETWEEN A.START_DATE AND A.END_DATE";

                //object retVal = Service.ExecuteScalar(cmdStr);

                //if (!TypeCheck.IsNull(retVal))
                //{
                //    gwaName = retVal.ToString();
                //}

                //tungtx
                OCS1003P01ChangeUserArgs args = new OCS1003P01ChangeUserArgs();
                args.Gwa = gwa;
                OCS1003P01ChangeUserResult result =
                    CloudService.Instance.Submit<OCS1003P01ChangeUserResult, OCS1003P01ChangeUserArgs>(args);
                if (result != null)
                {
                    if (!String.IsNullOrEmpty(result.GwaName))
                    {
                        gwaName = result.GwaName;
                    }
                }


                //사용자 정보 Check 실패시 return
                if (!UserInfoUtil.CheckUserDoctor(EnvironInfo.CurrSystemID, UserInfo.UserID, UserInfo.UserPswd, false, gwa, gwaName, out errMsg))
                {
                    //lbMsg.Text = errMsg;
                    //this.txtUserID.Focus();
                    return;
                }

                //시스템 사용자 진입 등록
                UserInfoUtil.RegisterSystemUser(EnvironInfo.CurrSystemID, UserInfo.UserID);

                //ID 저장시 Registry에 SET
                UserInfoUtil.SetSystemUserToRegistry(EnvironInfo.CurrSystemID, UserInfo.UserID, true);

                //mdiForm.SetStatusBar(UserInfo.UserName, UserInfo.BuseoName, "");
                //mdiForm.Refresh();
            }

            this.SettingVisiblebyUser();

            #endregion

            //// 주치의 콤보박스 재구성
            //this.ReLoadDoctorCombo(this.dtpNaewonDate.GetDataValue(), this.cboQryGwa.GetDataValue());

            //// 환자리스트 로드 
            //this.PatientListQuery(this.dtpNaewonDate.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());

            // 주치의 콤보박스 재구성
            this.ReLoadDoctorCombo(this.dtpNaewonDate.GetDataValue(), this.cboQryGwa.GetDataValue());

            // 환자리스트 로드 
            this.PatientListQuery(this.dtpNaewonDate.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());
        }

        void cboQryDoctor_SelectedValueChanged(object sender, EventArgs e)
        {
            // 환자리스트 로드 
            this.PatientListQuery(this.dtpNaewonDate.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());

            this.mPostApproveYN = this.mOrderBiz.getEnablePostApprove("O", this.cboQryDoctor.SelectedValue.ToString());

            if (this.mPostApproveYN)
                this.lblApproveFlag.Text = Resources.LBLAPPROVEFLAG_TEXT_2;
            else
                this.lblApproveFlag.Text = Resources.LBLAPPROVEFLAG_TEXT_1;

            this.lblApproveDoctorName.Text = "⇒ " + this.cboQryDoctor.ComboItems[this.cboQryDoctor.SelectedIndex].DisplayItem;
        }

        #endregion

        #region [ 버튼 리스트 ]

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query: // 조회

                    //reset kinki check
                    this.allWarning = "";

                    e.IsBaseCall = false;

                    // 변경된 데이터 체크후 저장
                    if (this.IsOrderDataModifed() == true)
                    {
                        this.btnList.PerformClick(FunctionType.Update);
                    }

                    // 조회시작
                    if (this.mSelectedPatientInfo == null ||
                        this.mSelectedPatientInfo.GetPatientInfo == null ||
                        this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != this.fbxBunho.GetDataValue())
                    {
                        return;
                    }

                    // Linhnt
                    ReloadScreeenOCS1003P01();

                    // TODO comment: use cloud
                    /*
                     *
                    // 환자상병조회
                    this.LoadOutSang(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                    , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                    , "%");

                    //診療科のコンボボックス作成
                    if (this.cboOutSang.GetDataValue().ToString() != "")
                    {
                        this.MakeJinryoGwa();
                    }

                    // 오더조회
                   this.LoadOutOrder(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                        , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                        , (this.mDoctorLogin == true ? "D" : "N")
                                        , this.mInputGubun);
                    
                   this.grdReserOrderList.QueryLayout(false);
                   */

                    //insert by jc [grdOrder_Drugに情報LOAD] START
                    //this.LoadDoOrder_Grid();
                    //insert by jc [grdOrder_Drugに情報LOAD] END


                    break;

                //case FunctionType.Insert : // 상병입력

                //    e.IsBaseCall = false;

                //    this.AcceptData();

                //    if (this.SangInputCheck(ref this.mMsg) == false)
                //    {
                //        MessageBox.Show(this.mMsg, XMsg.GetMsg("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }

                //    int newRow = -1;
                //    // 상병 로우 생성 
                //    newRow = this.grdOutSang.InsertRow(-1);

                //    // 상병 로우의 초기화
                //    this.InitializeSangGrid(this.grdOutSang, this.mSelectedPatientInfo, newRow);

                //    break;

                case FunctionType.Update: // 저장
                    //Kinki check
                    if (!String.IsNullOrEmpty(this.allWarning))
                    {
                        XMessageBox.Show(allWarning, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    e.IsBaseCall = false;

                    if (!this.IsPatientSelected()) return;

                    // 登録しようとしている患者に対して自分が担当医であるのかを保存する直前にチェックする。
                    if (this.mDoctorLogin)
                    {
                        if (!this.IsCanUpdateDoctor(UserInfo.DoctorID, this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(), this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()))
                        {
                            return;
                        }
                    }
                    if (!this.AcceptData())
                    {
                        mIsUpdateSuccess = false;
                        return;
                    }

                    this.mInsteadInsertedOrderCnt = 0;
                    this.mInsteadUpdatedOrderCnt = 0;
                    this.mInsteadDeletedOrderCnt = 0;

                    // 저장시작
                    // 1. 각각의 레이아웃을 저장 레이아웃으로 merge 한다.
                    // 2. 저장전 체크 사항을 체크한다.
                    // 3. 저장시작
                    //    3-1. Delete 항목에 대하여 저장을 한다. ( 에러시 이후 진행 불가 )
                    //    3-2. Update 항목에 대하여 저장을 한다. 



                    if (this.MergeToSaveLayout() == false)
                    {
                        mIsUpdateSuccess = false;
                        return;
                    }

                    if (this.OrderValidationCheck() == false)
                    {
                        mIsUpdateSuccess = false;
                        return;
                    }

                    //20130322 MX Interface 未定

                    //this.mInterface.MakeIFDataLayout("O", this.layDeletedData.LayoutTable, true, false, true);

                    //this.mInterface.MakeIFDataLayout("O", this.laySaveLayout.LayoutTable, false, true, false);

                    //this.mInterface.MakeIFDataLayout("O", this.laySaveLayout.LayoutTable, false, false, false);

                    // 트랜잭션 시작
                    try
                    {
                        // Connect Cloud
                        /*if (this.grdOutSang.RowCount <= 0)
                        {
                            if (MessageBox.Show("現在登録されている傷病がありません。このまま保存しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                return;
                        }*/

                        // 입력안된 뉴로우는 자동삭제 합니다.
                        this.mOrderFunc.DeleteEmptyNewRow(this.grdOutSang);
                        // 삭제시에는 삭제테이블의 데이터를 건드려 줘야 함.
                        for (int i = 0; i < this.layDeletedData.RowCount; i++)
                        {
                            // 承認したオーダーを代行者が削除できなくする。
                            if (this.mInputGubun == "CK"
                                && this.layDeletedData.GetItemString(i, "pkocskey") != "")
                            {

                                string PostApproveYN = TypeCheck.NVL(this.layDeletedData.GetItemString(i, "postapprove_yn"), "N").ToString();

                                PostApproveYN = PostApproveYN == "Y" ? "D0" : this.mInputGubun;

                                if (!this.mOrderBiz.IsPossibleInsteadOrder(this.layDeletedData.GetItemString(i, "pkocskey"), PostApproveYN, this.IO_Gubun))
                                {
                                    XMessageBox.Show(Resources.MSG004_MSG, Resources.MSG001_CAP);
                                    return;
                                }
                            }

                            this.layDeletedData.SetItemValue(i, "dummy", "mageshin");
                        }


                        // Connect cloud Update data
                        OCS1003P01SaveLayOutArgs saveLayoutArgs = new OCS1003P01SaveLayOutArgs();

                        List<OcsoOCS1003P01GridOutSangInfo> lstOutSangInfo = LoadListFromGrdOutSang();
                        List<OCS1003P01LayDeletedDataListItemInfo> lstDeletedDataInfo = LoadListFromLayDeletedData();
                        List<OCS1003P01LaySaveLayoutListItemInfo> lstLaySaveLayoutInfo = LoadListFromLaySaveLayout();
                        string naewonKey = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                        string naewondate = this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();

                        saveLayoutArgs.GrdOutSangList = lstOutSangInfo;
                        saveLayoutArgs.LayDeleteList = lstDeletedDataInfo;
                        saveLayoutArgs.LaySaveList = lstLaySaveLayoutInfo;
                        saveLayoutArgs.UserId = UserInfo.UserID;
                        saveLayoutArgs.NaewonKey = naewonKey;
                        saveLayoutArgs.NaewonDate = naewondate;
                        UpdateResult result = CloudService.Instance.Submit<UpdateResult, OCS1003P01SaveLayOutArgs>(saveLayoutArgs);
                        if (result.ExecutionStatus != ExecutionStatus.Success)
                        {
                            this.mMsg = XMsg.GetMsg("M005");
                            MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            mIsUpdateSuccess = false;

                            return;
                        }
                        #region TODO Comment: use connect cloud
                        //Service.BeginTransaction();

                        ////if (this.grdOutSang.RowCount <= 0)
                        ////{
                        ////    if (MessageBox.Show("現在登録されている傷病がありません。このまま保存しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        ////        return;
                        ////}

                        //// 상병등록시작

                        //// 입력안된 뉴로우는 자동삭제 합니다.
                        //this.mOrderFunc.DeleteEmptyNewRow(this.grdOutSang);

                        //if (this.grdOutSang.SaveLayout() == false)
                        //{
                        //    Service.RollbackTransaction(); // 롤백

                        //    //this.mMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...
                        //    this.mMsg = XMsg.GetMsg("M005") + "\r\n" + Service.ErrMsg;

                        //    MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //    mIsUpdateSuccess = false;

                        //    return;
                        //}


                        ////20130322 MX Interface 未定

                        //// Insert IF Temp Table
                        ////if (this.mInterface.InsertDeletedDataToTempTable() == false)
                        ////{

                        ////}

                        //// 삭제시에는 삭제테이블의 데이터를 건드려 줘야 함.
                        //for (int i = 0; i < this.layDeletedData.RowCount; i++)
                        //{
                        //    // 承認したオーダーを代行者が削除できなくする。
                        //    if (this.mInputGubun == "CK"
                        //        && this.layDeletedData.GetItemString(i, "pkocskey") != "")
                        //    {
                        //        string PostApproveYN = TypeCheck.NVL(this.layDeletedData.GetItemString(i, "postapprove_yn"), "N").ToString();

                        //        PostApproveYN = PostApproveYN == "Y" ? "D0" : this.mInputGubun;

                        //        if (!this.mOrderBiz.IsPossibleInsteadOrder(this.layDeletedData.GetItemString(i, "pkocskey"), PostApproveYN, this.IO_Gubun))
                        //        {
                        //            XMessageBox.Show(Resources.MSG004_MSG, Resources.MSG001_CAP);
                        //            return;
                        //        }
                        //    }

                        //    this.layDeletedData.SetItemValue(i, "dummy", "mageshin");
                        //}

                        //// 삭제 오더
                        //if (this.layDeletedData.SaveLayout() == false)
                        //{
                        //    Service.RollbackTransaction(); // 롤백

                        //    //this.mMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...
                        //    this.mMsg = XMsg.GetMsg("M005") + "\r\n" + Service.ErrMsg;

                        //    MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //    mIsUpdateSuccess = false;

                        //    return;
                        //}

                        //// 변경 및 추가 오더 
                        //// insert by jc [OCS1003のSYSDATEを統一化させるために] START
                        //string cmd = " SELECT TO_CHAR(SYSDATE, 'YYYY/MM/DD HH24:MI:SS') FROM SYS.DUAL ";

                        //object value = Service.ExecuteScalar(cmd);

                        ////if (value != null &&
                        ////    TypeCheck.IsDateTime(value.ToString()))
                        ////    mSave_time = value.ToString();
                        //// insert by jc END



                        //if (this.laySaveLayout.SaveLayout() == false)
                        //{
                        //    Service.RollbackTransaction();  // 롤백

                        //    //this.mMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...
                        //    this.mMsg = XMsg.GetMsg("M005") + "\r\n" + Service.ErrMsg;

                        //    MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //    mIsUpdateSuccess = false;

                        //    return;
                        //}

                        //#region PR_OCS_OUT_ORDER_END_TEMP

                        //// Order end 프로시져 콜 ( 여기서 투약번호를 딴다)
                        //ArrayList inVarList = new ArrayList();
                        //ArrayList outVarList = new ArrayList();
                        //string proName = "PR_OCS_OUT_ORDER_END_TEMP";

                        //inVarList.Add(this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
                        //inVarList.Add(this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString());

                        //outVarList.Clear();

                        //if (Service.ExecuteProcedure(proName, inVarList, outVarList) == false)
                        //{
                        //    Service.RollbackTransaction();

                        //    this.mMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                        //    MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //    mIsUpdateSuccess = false;

                        //    return;
                        //}
                        #endregion End comment

                        //医師ではない人が保存ボタンを押下する場合、自動診療終了までする。
                        //this.mSubUserAutoEndFlag = "N";
                        //if (UserInfo.UserGubun != UserType.Doctor && this.mGroup_key != "1" && this.mGroup_key != "")
                        //{
                        //    mIsUpdateSuccess = true;
                        //    this.mSubUserAutoEndFlag = "Y";
                        //    this.btnList.PerformClick(FunctionType.Process);
                        //}

                        if (UserInfo.UserGubun != UserType.Doctor && this.mGroup_key == "1" && this.mGroup_key != "")
                        {
                            // 部門オーダ記録出力
                            if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "ORDER_LABEL_PRT_YN", this.IO_Gubun) != "N")
                            {
                                if (this.layDisplayLayout.RowCount > 0 && this.IsPatientSelected())
                                {
                                    if (this.cbxIsiSijisyo.Checked == true)
                                    {
                                        // TODO comment: not deploy 
                                        //this.OpenScreen_OCS1003R00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                        //                              , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                        //                              , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                        //                              , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                        //                              , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                                        //                              , this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
                                        //                              , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                        //                              , true
                                        //                              , false);
                                    }
                                    else
                                    {
                                        if (MessageBox.Show(Resources.MSG005_MSG, Resources.MSG001_CAP, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                        {
                                            // TODO comment: not deploy 
                                            //this.OpenScreen_OCS1003R00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                            //                          , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                            //                          , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                            //                          , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                            //                          , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                                            //                          , this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
                                            //                          , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                            //                          , true
                                            //                          , false);
                                        }
                                    }
                                }
                            }
                        }

        #endregion

                    }
                    catch
                    {
                        //Service.RollbackTransaction();

                        mIsUpdateSuccess = false;

                        this.mInsteadInsertedOrderCnt = 0;
                        this.mInsteadUpdatedOrderCnt = 0;
                        this.mInsteadDeletedOrderCnt = 0;

                        return;
                    }

                    //Service.CommitTransaction();  // 커밋

                    mIsUpdateSuccess = true;

                    string MsgSysMSG = "";
                    string MsgTitle = "";

                    if (UserInfo.Gwa == "CK")
                    {
                        if (this.mInsteadInsertedOrderCnt > 0)
                        {
                            MsgSysMSG += Resources.SYS_MSG_1 + this.mInsteadInsertedOrderCnt + Resources.SYS_MSG_SUFFIX;
                            MsgTitle += Resources.SYS_MSG_TITLE_1;
                        }
                        if (this.mInsteadUpdatedOrderCnt > 0)
                        {
                            MsgSysMSG += Resources.SYS_MSG_2 + this.mInsteadUpdatedOrderCnt + Resources.SYS_MSG_SUFFIX;
                            MsgTitle += Resources.SYS_MSG_TITLE_2;
                        }
                        if (this.mInsteadDeletedOrderCnt > 0)
                        {
                            MsgSysMSG += Resources.SYS_MSG_3 + this.mInsteadDeletedOrderCnt + Resources.SYS_MSG_SUFFIX;
                            MsgTitle += Resources.SYS_MSG_TITLE_3;
                        }

                        if (this.cbxMsgSysYN.Checked == true)
                        {
                            if (MsgSysMSG != "")
                            {
                                // 承認医師へ
                                // Approval to doctor
                                string gwa_name = "";
                                this.mOrderBiz.LoadColumnCodeName("gwa", this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(), EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), ref gwa_name);

                                this.mOrderBiz.SendMessageSystem(MsgTitle + Resources.MORDER_BIZ_TITLE_1
                                                                 , Resources.MORDER_BIZ_TITLE_2 + this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                                 , Resources.MORDER_BIZ_TITLE_3 + this.mSelectedPatientInfo.GetPatientInfo["suname"].ToString()
                                                                 , Resources.MORDER_BIZ_TITLE_4 + gwa_name
                                                                 , ""
                                                                 , ""
                                                                 , MsgSysMSG
                                                                 , UserInfo.UserID
                                                                 , "U"
                                                                 , this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString().Length - 5)
                                                                 , ""
                                                                    );
                            }
                        }
                    }

                    #region 방사선 조사록 출력

                    #endregion

                    #region 약 처방전 출력

                    #endregion

                    #region 검체검사 출력 리스트 작성

                    #endregion

                    #region リハビリ依頼書出力 BEAR-D

                    Hashtable printYn = new Hashtable();
                    foreach (DataRow dr in this.layRehaOrder.LayoutTable.Rows)
                    {
                        //inser by jc 希望日が追加された場合、再印刷されるように変更。（修正された分はPHY8002画面にて出力）
                        //if ((dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified)&&
                        if ((dr.RowState == DataRowState.Added) &&
                            (dr["jundal_part"].ToString() == "HOM" && (dr["specific_comment"].ToString() == "18" || dr["specific_comment"].ToString() == "19")))
                        {
                            // TODO: Stop printing process
                            //this.PrintRehaIraisyo(dr);
                            printYn.Add(dr["pkocskey"].ToString(), "Y");

                            //問診データI/F
                            if (this.mDoctorLogin)
                            {
                                // TODO
                                //this.mOrderBiz.procHQNInterface(mSelectedPatientInfo, IO_Gubun);
                            }
                            else if (UserInfo.Gwa == "CK" && this.mPostApproveYN)
                            {
                                this.mOrderBiz.procHQNInterface(mSelectedPatientInfo, IO_Gubun);
                            }
                        }
                    }
                    #endregion

                    this.ClearOrderData();

                    // Reload data
                    //this.btnList.PerformClick(FunctionType.Query);
                    ReloadScreeenOCS1003P01();


                    break;

                case FunctionType.Process:   // 진료 종료

                    e.IsBaseCall = false;

                    // jubsu_gubun が　診察　AND doctor_yn =　N　であるときは終了できない。
                    if (!this.IsPatientSelected()) return;

                    if (this.mDoctorLogin == false && this.mGroup_key == "1")
                    {
                        //MessageBox.Show(XMsg.GetMsg("M006"), XMsg.GetField("F002"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show(Resources.MSG029_MSG, Resources.MSG029_CAP, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    mIsUpdateSuccess = false;

                    // 診療終了前に該当する患者に未承認オーダーが存在するかチェック
                    if (this.mOrderBiz.GetNotApproveOrderCnt(IO_Gubun, UserInfo.UserID, "Y", "N", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) > 0)
                    {
                        XMessageBox.Show(Resources.MSG002_MSG, Resources.MSG001_CAP, MessageBoxButtons.OK);
                        this.btnApprove.PerformClick();
                        return;
                    }

                    this.btnList.PerformClick(FunctionType.Update);

                    if (mIsUpdateSuccess)
                    {
                        //傷病チェック
                        if (this.grdOutSang.RowCount <= 0)
                        {
                            //if (MessageBox.Show("現在登録されている傷病がありません。傷病登録をしますか？\n登録する[はい(Y)]、登録しない[いいえ(N)]", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            if (MessageBox.Show(Resources.MSG006_MSG, Resources.MSG001_CAP, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            {
                                this.btnListSB.Focus();
                                this.btnListSB.PerformClick(FunctionType.Insert);
                                return;
                            }
                        }




                        //insert by jc [保存する際に医師指示書出力可否を表示] 2012/03/30
                        //checkplz 医師指示指示書出力有無チェック追加

                        #region [医師指示書出力]
                        if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "ORDER_LABEL_PRT_YN", this.IO_Gubun) != "N")
                        {
                            if (this.layDisplayLayout.RowCount > 0 && this.IsPatientSelected())
                            {
                                if (this.cbxIsiSijisyo.Checked == true)
                                {
                                    // TODO comment: not deploy 
                                    //this.OpenScreen_OCS1003R00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                    //                              , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                    //                              , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                    //                              , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                    //                              , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                                    //                              , this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
                                    //                              , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                    //                              , true
                                    //                              , false);
                                }
                                else
                                {
                                    if (MessageBox.Show(Resources.MSG005_MSG, Resources.MSG001_CAP, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                    {
                                        // TODO comment: not deploy 
                                        //this.OpenScreen_OCS1003R00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                        //                          , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                        //                          , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                        //                          , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                        //                          , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                                        //                          , this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
                                        //                          , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                        //                          , true
                                        //                          , false);
                                    }
                                }
                            }
                        }
                        #endregion


                        #region [検査予約票出力]
                        Hashtable reserPrintYn = new Hashtable();
                        foreach (DataRow dr in this.layQueryLayout.LayoutTable.Rows)
                        {
                            if ((dr["jundal_table"].ToString() == "CPL" || dr["jundal_table"].ToString() == "PFE" || dr["jundal_table"].ToString() == "XRT" || dr["jundal_table"].ToString() == "OP")
                                 && dr["hope_date"].ToString() != "")
                            {
                                if (!reserPrintYn.Contains(dr["hope_date"].ToString()))
                                    reserPrintYn.Add(dr["hope_date"].ToString(), dr["hangmog_code"].ToString());
                            }
                        }

                        foreach (string reser_date in reserPrintYn.Keys)
                        {
                            CommonItemCollection openParams = new CommonItemCollection();

                            openParams.Add("bunho", this.paInfoBox.BunHo);
                            openParams.Add("auto_close", "Y");
                            openParams.Add("reser_date", reser_date);

                            XScreen.OpenScreenWithParam(this, "NURO", "NUR1001R98", ScreenOpenStyle.ResponseFixed, openParams);
                        }
                        #endregion
                        if (this.SaveJubsuInfo(this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString(), JINRYO_END))
                        {
                            this.PatientListQuery(this.dtpNaewonDate.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());

                            // 진료 종료후 클리어.
                            this.fbxBunho.SetEditValue("");
                            this.fbxBunho.AcceptData();
                        }
                        //}
                    }

                    break;

                case FunctionType.Reset:   // 진료 보류

                    e.IsBaseCall = false;

                    if (!this.IsPatientSelected()) return;

                    if (this.mDoctorLogin == false)
                    {
                        MessageBox.Show(XMsg.GetMsg("M006"), XMsg.GetField("F002"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    mIsUpdateSuccess = false;

                    if (this.mOrderBiz.GetNaewonYN(mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(), mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(), mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) == "H")
                    {
                        this.btnList.PerformClick(FunctionType.Cancel);
                        this.SettingVisiblebyUser();
                    }
                    else
                    {

                        this.btnList.PerformClick(FunctionType.Update);

                        if (mIsUpdateSuccess)
                        {
                            if (this.SaveJubsuInfo(this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString(), JINRYO_BORYU))
                            {
                                this.PatientListQuery(this.dtpNaewonDate.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());

                                // 진료 종료후 클리어.
                                this.fbxBunho.SetEditValue("");
                                this.fbxBunho.AcceptData();
                            }
                        }
                        //this.SettingVisiblebyUser(); //診療保留後患者番号をクリアするためボタンのリセットが要らない。
                    }
                    break;

                case FunctionType.Cancel: // 진료종료 취소 -- 이거는 out1001 에 naewon_yn 만 N으로 업데이트 하자

                    e.IsBaseCall = false;

                    if (this.IsPatientSelected() == false) return;

                    if (this.SaveJubsuInfo(this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString(), MI_JINRYO))
                        this.PatientListQuery(this.dtpNaewonDate.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());

                    break;
            }
        }

        /// <summary>
        /// ReloadScreeenOCS1003P01
        /// </summary>
        private void ReloadScreeenOCS1003P01()
        {
            // 이전 오더 데이터 초기화
            this.ClearOrderData();

            // 대기환자 리스트 조회
            this.PatientListQuery(this.dtpNaewonDate.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());

            string bunho = mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
            string naewonDate = mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
            string gwa = "%";
            string fkout1001 = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();

            // 2015.08.27 https://nextop-asia.atlassian.net/browse/MED-3790
            //string queryGubun = (this.mDoctorLogin == true ? "D" : "N");
            string queryGubun = "N";
            string inputGubun = mInputGubun;
            string bunho2 = this.paInfoBox.BunHo;
            string naewonDate2 = this.dtpNaewonDate.GetDataValue();

            OcsoOCS1003P01BtnListQueryResult btnListQueryResult = btnList_queryData(bunho, gwa, naewonDate,
                fkout1001, queryGubun, inputGubun, bunho2, naewonDate2);
            if (btnListQueryResult != null)
            {
                // physical patient lookup
                this.LoadOutSang(btnListQueryResult.GridOutSangItem);

                // Create combo box if department
                if (this.cboOutSang.GetDataValue() != "")
                {
                    MakeJinryoGwaCombo(btnListQueryResult.CboItem);
                }

                // Order inquiry
                lstOutOrderInfo = btnListQueryResult.OutOrder;
                this.LoadOutOrder(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                , (this.mDoctorLogin == true ? "D" : "N")
                                , this.mInputGubun);

                IList<object[]> listObject = grdReserOrderList_createData(btnListQueryResult.ReserOrder);
                grdReserOrderList.setDataForGrid(listObject);
                grdReserOrderList_QueryEnd(null, null);
            }
            // 오더 조회후 화면 Display
            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
        }


        #region [ 그리드 이벤트 ]

        #region [ 상병 그리드 ]

        private void grdOutSang_Enter(object sender, EventArgs e)
        {
            // 포커스가 왔을때
            // 상병 입력이 가능한 상태이고
            // 현재 그리드에 로우가 하나도 없다면 
            // 자동으로 로우 한개 생성한다.
            if (this.SangInputCheck(ref this.mMsg) == true &&
                this.grdOutSang.RowCount == 0)
            {
                this.btnList.PerformClick(FunctionType.Insert);
            }


        }

        private void grdOutSang_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;

            switch (e.ColName)
            {
                case "display_sang_name": // 상병명 ( 화면 조회용 )

                    // 비코드화 상병명일때는 입력이 가능함.
                    if (this.mOrderBiz.IsDirectInputSangName(e.DataRow["sang_code"].ToString()) || e.DataRow["sang_code"].ToString().Trim() == "")
                        e.Protect = false;
                    else
                        e.Protect = true;

                    break;

                case "susik_button": // 수식어 버튼

                    // 비코드화 상병일때는 수식어가 필요없지...어차피 입력할테니...
                    if (this.mOrderBiz.IsDirectInputSangName(e.DataRow["sang_code"].ToString()))
                        e.Protect = true;
                    else
                        e.Protect = false;

                    break;

                case "sang_end_sayu":  // 전귀사유

                    if (TypeCheck.IsNull(e.DataRow["sang_end_date"])) e.Protect = true;

                    break;

                case "doubt":    // 의증 컬럼

                    e.Protect = true;

                    break;

                case "gwa":
                    if (this.grdOutSang.GetItemString(e.RowNumber, e.ColName) != "%" && this.grdOutSang.GetRowState(e.RowNumber) == DataRowState.Unchanged)
                        e.Protect = true;
                    else
                        e.Protect = false;
                    break;
                case "susik":
                    if (grd.GetItemString(e.RowNumber, "sang_code") == OCS.OrderVariables.WORD_SANG_CODE)
                    {
                        e.Protect = true;
                    }
                    break;
                case "user_sang":
                    if (grd.GetItemString(e.RowNumber, "sang_code") == OCS.OrderVariables.WORD_SANG_CODE)
                    {
                        e.Protect = true;
                    }
                    break;

            }

            //this.mDoctorLogin == falseであれば傷病追加、修正、削除できない。
            //if (this.mDoctorLogin == false)
            //    e.Protect = true;
        }

        private void grdOutSang_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            switch (e.ColName)
            {
                case "sang_code":

                    if (this.fbxBunho.GetDataValue() == "")
                    {
                        return;
                    }

                    this.OpenScreen_CHT0110Q00("", true, grd.GetItemString(e.RowNumber, "sang_start_date"));

                    break;

                case "gwa":

                    if (this.fbxBunho.GetDataValue() == "")
                        return;
                    if (this.grdOutSang.GetItemString(e.RowNumber, e.ColName) != "%" && this.grdOutSang.GetRowState(e.RowNumber) == DataRowState.Unchanged)
                        ((XFindBox)((XEditGridCell)grdOutSang.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = null;
                    else
                        ((XFindBox)((XEditGridCell)grdOutSang.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("gwa", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    break;
            }
        }

        private void grdOutSang_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;

            // 필드속성이 수정불가인 경우 BackColor를 회색으로 바꾸어 유저한테 입력불가상태임을 알린다
            // ReadOnly인 경우 
            if (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable &&
                  (grd.GetRowState(e.RowNumber) == DataRowState.Unchanged || grd.GetRowState(e.RowNumber) == DataRowState.Modified) ||
                 (((XEditGridCell)grd.CellInfos[e.ColName]).IsReadOnly))
            {
                //e.DrawMode = IFC.Framework.XCellDrawMode.Raised3D;
                e.BackColor = OrderVariables.DisplayFieldColor.Color; // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;
            }
            else
            {
                // 상병종료일이 입력되지 않은 경우는 종료사유 입력 불가
                switch (e.ColName)
                {
                    case "display_sang_name": // Display 상병명
                        // 직접입력가능 상병코드인 경우는 상병명 직접입력가능(상병코드 : OCS.OrderVariables.WORD_SANG_CODE)
                        //if (!this.mOrderBiz.IsDirectInputSangName(grd.GetItemString(e.RowNumber, "sang_code")))
                        if (e.DataRow["sang_code"].ToString().Trim() != OCS.OrderVariables.WORD_SANG_CODE && e.DataRow["sang_code"].ToString().Trim() != "")
                        {
                            //e.DrawMode = IFC.Framework.XCellDrawMode.Raised3D;
                            e.BackColor = OrderVariables.DisplayFieldColor.Color; // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;						
                        }

                        // 암 관련 상병명 암 표현법 (癌표시를 CA로 표시함)                             // 사용자 입력부서
                        grd[e.RowNumber, e.ColName].DisplayText = this.mOrderBiz.DisplayCancerSangName(this.mInputGwa, grd[e.RowNumber, e.ColName].DisplayText);

                        break;

                    case "susik_button":
                    case "suspend_button":// 수식, ..
                        // 직접입력가능 상병코드인 경우는 수식등 선택못함 (상병코드 : OCS.OrderVariables.WORD_SANG_CODE)
                        if (this.mOrderBiz.IsDirectInputSangName(grd.GetItemString(e.RowNumber, "sang_code")))
                        {
                            //e.DrawMode = IFC.Framework.XCellDrawMode.Raised3D;
                            e.BackColor = OrderVariables.DisplayFieldColor.Color; // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;						
                        }
                        break;

                    case "sang_end_sayu": // 상병종료사유
                        if (TypeCheck.IsNull(grd.GetItemValue(e.RowNumber, "sang_end_date")))
                        {
                            //e.DrawMode = IFC.Framework.XCellDrawMode.Raised3D;
                            e.BackColor = OrderVariables.DisplayFieldColor.Color; // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;
                        }
                        break;

                    case "doubt": // image처리

                        if (e.DataRow["sang_code"].ToString().Trim() == OCS.OrderVariables.WORD_SANG_CODE)
                        {
                            e.Image = this.ImageList.Images[28];
                            return;
                        }

                        if (CheckDoubt(grd, e.RowNumber))
                            e.Image = this.ImageList.Images[27];
                        else
                            e.Image = this.ImageList.Images[26];
                        break;
                    case "gwa":
                        if (this.grdOutSang.GetItemString(e.RowNumber, e.ColName) != "%")
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                        }
                        break;
                }
            }
        }

        private void grdOutSang_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            object previousValue = grd.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // 이전 Value

            switch (e.ColName)
            {
                case "sang_code":

                    // sang_codeの修正は認めない。
                    if (previousValue.ToString() != e.ChangeValue.ToString() && previousValue.ToString() != "")
                    {
                        this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다
                        XMessageBox.Show(Resources.MSG007_MSG, Resources.MSG001_CAP);
                        return;
                    }

                    #region 상병코드

                    string pre_modifier_name = e.DataRow["pre_modifier_name"].ToString();
                    string post_modifier_name = e.DataRow["post_modifier_name"].ToString();

                    grd.SetItemValue(e.RowNumber, "sang_name", "");


                    if (e.ChangeValue.ToString().Trim() == OCS.OrderVariables.WORD_SANG_CODE)
                    {
                        //display상병명을 상병명으로 가져간다.
                        ClearSangName(grd, e.RowNumber);
                        grd.SetItemValue(e.RowNumber, "sang_name", e.DataRow["display_sang_name"]);
                        //grd.SetItemValue(e.RowNumber, "icd9_code", "");

                        break;
                    }

                    string display_sang_name = pre_modifier_name + post_modifier_name;

                    grd.SetItemValue(e.RowNumber, "display_sang_name", display_sang_name);

                    if (TypeCheck.IsNull(e.ChangeValue))
                    {
                        //grd.SetItemValue(e.RowNumber, "icd9_code", "");
                        break;
                    }
                    else
                    {
                        string sang_code = e.ChangeValue.ToString().TrimEnd();

                        DataRow dRow = this.mOrderBiz.LoadCht0110Info(sang_code);

                        if (dRow == null)
                        {
                            //							mbxMsg = NetInfo.Language == LangMode.Jr ? "傷病コードが正確ではないです. 確認してください." : "상병코드가 정확하지 않습니다. 확인바랍니다.";
                            //							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            //							XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

                            this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다

                            //상병 미존재시 Find창을 띄운다.
                            this.OpenScreen_CHT0110Q00(sang_code, true, grd.GetItemString(e.RowNumber, "sang_start_date"));

                            return;
                        }

                        pre_modifier_name = grd.GetItemString(e.RowNumber, "pre_modifier_name");
                        post_modifier_name = grd.GetItemString(e.RowNumber, "post_modifier_name");
                        string sang_name = dRow["sang_name"].ToString();
                        display_sang_name = this.mOrderBiz.GetDisplaySangName(pre_modifier_name, sang_name, post_modifier_name);



                        // 상병별 항목별 제한사항 체크
                        if (!TypeCheck.IsNull(sang_code))
                        {
                            for (int i = 0; i < this.layDrugOrder.RowCount; i++)
                            {
                                // break_gubun과 나이기준을 확인한다..
                                if (!this.mHangmogInfo.CheckHangSangInfo(this.layDrugOrder.GetItemString(i, "hangmog_code"), this.layDrugOrder.GetItemString(i, "hangmog_name"),
                                    sang_code, grd.GetItemString(e.RowNumber, "display_sang_name"), this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(), IO_Gubun,
                                    (mSelectedPatientInfo.GetPatientInfo == null ? "" : mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()),
                                    (mSelectedPatientInfo.GetPatientInfo == null ? "" : mSelectedPatientInfo.GetPatientInfo["birth"].ToString())))
                                {
                                    this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다
                                    return;
                                }
                            }
                        }

                        grd.SetItemValue(e.RowNumber, "sang_name", sang_name);
                        //grd.SetItemValue(e.RowNumber, "icd9_code", dRow["icd9_code"]);

                        //display 상병명
                        grd.SetItemValue(e.RowNumber, "display_sang_name", display_sang_name);

                        // kkb => 법정전염병 신고대상 환자입니다. 신고 하시겠습니까?

                        //MessageBox.Show("END Valid");

                    }

                    #endregion

                    break;

                case "sang_start_date":

                    #region 発症日
                    if (e.ChangeValue.ToString() != "" && grd.GetItemString(e.RowNumber, "sang_jindan_date") != "")
                    {
                        //発症日は診断日より同じ及び過去である。
                        if (int.Parse(grd.GetItemString(e.RowNumber, "sang_start_date").Replace("/", "")) > int.Parse(grd.GetItemString(e.RowNumber, "sang_jindan_date").Replace("/", "")))
                        {
                            XMessageBox.Show(Resources.MSG008_MSG, Resources.MSG001_CAP, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                            return;
                        }
                    }
                    #endregion

                    break;
                case "sang_jindan_date":

                    #region 診断日

                    if (e.ChangeValue.ToString() != "" && grd.GetItemString(e.RowNumber, "sang_start_date") != "")
                    {
                        //発症日は診断日より同じ及び過去である。
                        if (int.Parse(grd.GetItemString(e.RowNumber, "sang_start_date").Replace("/", "")) > int.Parse(grd.GetItemString(e.RowNumber, "sang_jindan_date").Replace("/", "")))
                        {
                            XMessageBox.Show(Resources.MSG009_MSG, Resources.MSG001_CAP, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                            return;
                        }
                    }
                    #endregion

                    break;
                case "sang_end_date":

                    #region 終了日

                    if (e.ChangeValue.ToString() == "")
                    {
                        grd.SetItemValue(e.RowNumber, "sang_end_sayu", "");
                    }
                    else if (grd.GetItemString(e.RowNumber, "sang_jindan_date") == "" || grd.GetItemString(e.RowNumber, "sang_start_date") == "")
                    {
                        XMessageBox.Show(Resources.MSG010_MSG, Resources.MSG001_CAP, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                        return;
                    }
                    else
                    {
                        //発症日は診断日より同じ及び過去である。
                        if (int.Parse(grd.GetItemString(e.RowNumber, "sang_start_date").Replace("/", "")) > int.Parse(grd.GetItemString(e.RowNumber, "sang_end_date").Replace("/", ""))
                            || int.Parse(grd.GetItemString(e.RowNumber, "sang_jindan_date").Replace("/", "")) > int.Parse(grd.GetItemString(e.RowNumber, "sang_end_date").Replace("/", "")))
                        {
                            XMessageBox.Show(Resources.MSG011_MSG, Resources.MSG001_CAP, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                            return;
                        }
                    }


                    #endregion

                    break;
                case "gwa":
                    //                    string cmd = @"SELECT FN_BAS_LOAD_GWA_NAME('" + e.ChangeValue.ToString() + "', '" + this.dtpNaewonDate.GetDataValue() + "') FROM SYS.DUAL";
                    //
                    //                    object obj = Service.ExecuteScalar(cmd);
                    //                    this.grdOutSang.SetItemValue(e.RowNumber, "gwa_name", obj.ToString());

                    // Connet to cloud service
                    OcsoOCS1003P01BasLoadGwaNameArgs args = new OcsoOCS1003P01BasLoadGwaNameArgs();
                    args.Gwa = e.ChangeValue.ToString();
                    args.BuseoYmd = this.dtpNaewonDate.GetDataValue();
                    OcsoOCS1003P01BasLoadGwaNameResult result = CloudService.Instance.Submit<OcsoOCS1003P01BasLoadGwaNameResult, OcsoOCS1003P01BasLoadGwaNameArgs>(args);
                    if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        this.grdOutSang.SetItemValue(e.RowNumber, "gwa_name", result.GwaName);
                    }

                    break;

                case "display_sang_name": // Display 상병명

                    ClearSangName(grdOutSang, e.RowNumber);
                    grdOutSang.SetItemValue(e.RowNumber, "sang_code", OCS.OrderVariables.WORD_SANG_CODE);
                    grdOutSang.SetItemValue(e.RowNumber, "sang_name", e.ChangeValue);
                    break;

                //if (this.grdOutSang.GetItemString(e.RowNumber, "sang_code") == OCS.OrderVariables.WORD_SANG_CODE)
                //{
                //    this.grdOutSang.SetItemValue(e.RowNumber, "sang_name", this.grdOutSang.GetItemString(e.RowNumber, "display_sang_name"));
                //}
                //break;
            }
        }

        private void grdOutSang_GridButtonClick(object sender, GridButtonClickEventArgs e)
        {
            switch (e.ColName)
            {
                case "user_sang":

                    this.OpenScreen_OCS0204Q00(UserInfo.UserID);

                    break;

                case "susik":

                    this.OpenScreen_CHT0115Q00(e.RowNumber);

                    break;
            }
        }

        private void grdOutSang_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            int rowNumber = grid.GetHitRowNumber(e.Y);

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (grid.CurrentColName == "doubt" && this.mDoctorLogin == true)
                {
                    if (grid.GetItemString(rowNumber, "sang_code") != OrderVariables.WORD_SANG_CODE)
                    {
                        if (CheckDoubt(grid, rowNumber))
                        {
                            SetDoubt(false, grid, rowNumber);
                        }
                        else
                        {
                            SetDoubt(true, grid, rowNumber);
                        }
                    }
                }
            }
        }

        #endregion

        #region [ 대기환자 그리드 ]

        private void grdPatientList_MouseDown(object sender, MouseEventArgs e)
        {
            int rowNumber = -1;
            XEditGrid grd = sender as XEditGrid;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                rowNumber = this.grdPatientList.GetHitRowNumber(e.Y);

                // 현재 선택된 로우의 환자번호 적용
                if (rowNumber >= 0)
                {
                    // 현재 파인드 박스의 환자번호와 선택된 번호가 
                    // 동일한경우는 스킵
                    try
                    {
                        this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                        //this.mParamNaewonKey = this.grdPatientList.GetItemString(rowNumber, "pk_naewon");
                        this.mClickedNaewonKey = this.grdPatientList.GetItemString(rowNumber, "pk_naewon");
                        //insert by jc [選択された患者の保険を取得]
                        this.mClickedGubun = this.grdPatientList.GetItemString(rowNumber, "gubun");

                        //同名二人CHECK2013/01/05

                        if (IsSameNameCHK() == true)
                        {
                            if (MessageBox.Show(Resources.MSG012_MSG_1 + this.grdPatientList.GetItemString(rowNumber, "suname") + Resources.MSG012_MSG_2
                                                                                          + this.grdPatientList.GetItemString(rowNumber, "suname2") + Resources.MSG012_MSG_3
                                                                                          + this.grdPatientList.GetItemString(rowNumber, "age") + Resources.MSG012_MSG_4, Resources.MSG001_CAP, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                return;
                        }

                        //insert by jc [共通医を選択すると診療を進めるかを聞くメッセージを表示する。] 2012/03/12
                        if (IsCommonDoctorJubsu(this.grdPatientList.GetItemString(rowNumber, "pk_naewon")) == true)
                        {
                            if (MessageBox.Show(Resources.MSG013_MSG, Resources.MSG001_CAP, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                return;
                            else
                            {
                                if (this.mDoctorLogin)
                                    this.ProcessCommonDoctor(this.grdPatientList.GetItemString(rowNumber, "pk_naewon"));
                            }
                        }
                        this.mPatientDoubleClick = true;
                        this.fbxBunho.SetEditValue(this.grdPatientList.GetItemString(rowNumber, "bunho"));
                        this.fbxBunho.AcceptData();

                        EMRGetLatestWarningStatusArgs args = new EMRGetLatestWarningStatusArgs(this.grdPatientList.GetItemString(rowNumber, "bunho"));
                        EMRGetLatestWarningStatusResult result = CloudService.Instance.Submit<EMRGetLatestWarningStatusResult, EMRGetLatestWarningStatusArgs>(args);
                        if (result.ExecutionStatus == ExecutionStatus.Success)
                        {
                            this.mProtocolID = result.WarningStatusInfo.ClisProtocolId;
                        }
                    }
                    finally
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                    }
                }
            }
        }

        private void grdPatientList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            // 예약환자인경우
            if (grid.GetItemString(e.RowNumber, "reser_yn") == "Y")
            {
                e.BackColor = this.mReserPatientColor.Color;
            }

            // 検査予約(次回)
            if (grid.GetItemString(e.RowNumber, "kensa_yn") == "Y")
            {
                e.BackColor = this.mKensaReserPatientColor.Color;
            }

            // 진료의뢰환자의 경우 핑크
            if (grid.GetItemString(e.RowNumber, "consult_yn") == "Y")
            {
                e.BackColor = Color.LightPink;
            }

            // 공통의인경우 
            if (e.ColName == "suname")
            {
                if (grid.GetItemString(e.RowNumber, "common_doctor_yn") == "Y")
                {
                    e.BackColor = Color.Khaki;
                }
            }

            //if (grid.GetItemString(e.RowNumber, "jubsu_gubun") == "20" || grid.GetItemString(e.RowNumber, "jubsu_gubun") == "21" || grid.GetItemString(e.RowNumber, "jubsu_gubun") == "22")
            //{
            //   e.BackColor = Color.LightGreen;
            //}
        }

        #endregion

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        #region [ 각종 쿼리 및 데이터 로드.... ]

        /// <summary>
        /// 대기환자 그리드 쿼리
        /// </summary>
        /// <param name="aNaewonDate">내원일자</param>
        /// <param name="aGwa">진료과</param>
        /// <param name="aDoctor">주치의</param>
        /// <returns>성공시 true</returns>
        private bool PatientListQuery(string aNaewonDate, string aGwa, string aDoctor)
        {
            // Connect cloud 
            grdPatientResult = grdPatient_getData(aNaewonDate, aDoctor);
            if (grdPatientList == null)
            {
                return false;
            }

            string prevKey = "";

            int approve_cnt = 0;
            if (!string.IsNullOrEmpty(grdPatientResult.CntValue))
            {
                approve_cnt = Int32.Parse(grdPatientResult.CntValue);
            }

            this.btnApprove.Text = Resources.PRE_APPROVE_BUTTON_TEXT + approve_cnt + Resources.SUFFIX_APPROVE_BUTTON_TEXT;

            if (approve_cnt > 0)
                this.pbxApprove.Visible = true;
            else
                this.pbxApprove.Visible = false;

            if (this.grdPatientList.RowCount > 0 &&
                this.grdPatientList.CurrentRowNumber >= 0)
            {
                prevKey = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "pk_naewon");
            }


            grdPatientList.ExecuteQuery = grdPatientList_CreateData;

            if (this.grdPatientList.QueryLayout(true) == true)
            {
                // 조회후 현재 라디오 버튼에 따른 필터링.

                this.SetPatientListGridFilter();

                // 이전 환자 선택 없으면 제일처음
                if (prevKey != "")
                {
                    for (int i = 0; i < this.grdPatientList.RowCount; i++)
                    {
                        if (this.grdPatientList.GetItemString(i, "pk_naewon") == prevKey)
                        {
                            this.grdPatientList.SetFocusToItem(i, 0);
                            break;
                        }
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// 조회용 진료과 콤보 재구성
        /// </summary>
        /// <param name="aNaewonDate">내원일자</param>
        private void ReLoadGwaCombo(string aNaewonDate)
        {
            this.cboQryGwa.SelectedValueChanged -= new EventHandler(cboQryGwa_SelectedValueChanged);
            string aCurrentGwa = this.cboQryGwa.GetDataValue();
            //DataTable dt = this.mOrderBiz.LoadComboDataSource("gwa", aNaewonDate).LayoutTable;
            cboQryGwa.ExecuteQuery = LoadDataCboGwa;

            if (aCurrentGwa == "")
            {
                aCurrentGwa = this.mParamGwa;
            }

            //this.cboQryGwa.SetComboItems(dt, "code_name", "code");
            this.cboQryGwa.SetDictDDLB();

            if (mDoctorLogin == true)
            {
                this.cboQryGwa.SetDataValue(this.mInputGwa);
            }
            else
            {

                if (aCurrentGwa != "" && this.cboQryGwa.ComboItems.Contains(aCurrentGwa))
                {
                    this.cboQryGwa.SetDataValue(aCurrentGwa);
                }
                else
                {
                    if (this.mInputGwa != "" && this.cboQryGwa.ComboItems.Contains(mInputGwa))
                    {
                        this.cboQryGwa.SetDataValue(mInputGwa);
                    }
                    else
                    {
                        this.cboQryGwa.SelectedIndex = 0;
                    }
                }
            }

            this.cboQryGwa.SelectedValueChanged += new EventHandler(cboQryGwa_SelectedValueChanged);
        }


        /// <summary>
        /// 조회용 주치의 콤보 재구성
        /// </summary>
        /// <param name="aNaewonDate">내원일자</param>
        /// <param name="aGwa">진료과</param>
        private void ReLoadDoctorCombo(string aNaewonDate, string aGwa)
        {
            this.cboQryDoctor.SelectedValueChanged -= new EventHandler(cboQryDoctor_SelectedValueChanged);
            string aCurrentDoctor = this.cboQryDoctor.GetDataValue();
            DataTable dt = this.mOrderBiz.LoadComboDataSource("doctor", aNaewonDate, aGwa).LayoutTable;

            if (aCurrentDoctor == "")
            {
                aCurrentDoctor = this.mParamDoctor;
            }
            else
            {
                //変更された後の診療科に設定。
                aCurrentDoctor = aGwa + aCurrentDoctor.Substring(2);
            }

            this.cboQryDoctor.SetComboItems(dt, "code_name", "code");

            if (this.mDoctorLogin == true)
            {
                this.cboQryDoctor.SetDataValue(UserInfo.DoctorID);
            }
            else
            {
                if (aCurrentDoctor != "" && this.cboQryDoctor.ComboItems.Contains(aCurrentDoctor))
                {
                    this.cboQryDoctor.SetDataValue(aCurrentDoctor);
                }
                else
                {
                    this.cboQryDoctor.SelectedIndex = 0;
                }
            }

            this.cboQryDoctor.SelectedValueChanged += new EventHandler(cboQryDoctor_SelectedValueChanged);

            this.lblApproveDoctorName.Text = "⇒ " + this.cboQryDoctor.ComboItems[this.cboQryDoctor.SelectedIndex].DisplayItem;
        }

        private void MakeJinryoGwa()
        {
            //insert by jc [診療科のコンボボックス追加] START
            MultiLayout layJinryoGwa = new MultiLayout();

            layJinryoGwa.LayoutItems.Add("GWA", DataType.String);
            layJinryoGwa.LayoutItems.Add("GWA_NAME", DataType.String);
            layJinryoGwa.InitializeLayoutTable();

            layJinryoGwa.QuerySQL = @"SELECT A.GWA, A.GWA_NAME                                               
                                        FROM VW_BAS_GWA A                                                    
                                       WHERE A.OUT_JUBSU_YN = 'Y'                                            
                                         AND A.START_DATE = FN_BAS_LOAD_VW_BAS_GWA_YMD(A.GWA, TRUNC(SYSDATE) )
                                         AND A.HOSP_CODE  = '" + EnvironInfo.HospCode + @"'
                                       UNION
                                      SELECT '%' as GWA, FN_ADM_MSG(221) as GWA_NAME 
                                        FROM SYS.DUAL
			                           ORDER BY GWA";

            layJinryoGwa.QueryLayout(false);

            this.MakeJinryoGwaCombo(layJinryoGwa);
            //insert by jc [診療科のコンボボックス追加] END
        }

        /// <summary>
        /// 상병로드
        /// </summary>
        /// <param name="aBunho">환자번호</param>
        /// <param name="aNaewonDate">내원일ㅈㅏ</param>
        /// <param name="aGwa">진료과</param>
        /// <returns>로우수</returns>
        private int LoadOutSang(string aBunho, string aNaewonDate, string aGwa)
        {

            this.grdOutSang.SetBindVarValue("f_bunho", aBunho);
            this.grdOutSang.SetBindVarValue("f_naewon_date", aNaewonDate);
            this.grdOutSang.SetBindVarValue("f_gwa", aGwa);

            this.grdOutSang.ExecuteQuery = grdOutSang_grdOutSang;
            this.grdOutSang.QueryLayout(true);

            this.MakePatientSangCombo(this.grdOutSang.LayoutTable);

            return this.grdOutSang.RowCount;
        }

        /// <summary>
        /// LoadOutSang use connect cloud
        /// </summary>
        /// <param name="lstGridOutSangInfo"></param>
        /// <returns></returns>
        private int LoadOutSang(List<OcsoOCS1003P01GridOutSangInfo> lstGridOutSangInfo)
        {
            IList<object[]> lstObject = grdOutSang_convertListInfoToListObject(lstGridOutSangInfo);
            grdOutSang.setDataForGrid(lstObject);

            this.MakePatientSangCombo(this.grdOutSang.LayoutTable);

            return this.grdOutSang.RowCount;
        }


        // 画面がLOADされる時既存のデータを各GRIDに保存する
        private void LoadDoOrder_Grid()
        {
            this.grdOrder_Drug.Reset();
            this.grdOrder_Jusa.Reset();
            this.grdOrder_Cpl.Reset();
            this.grdOrder_Pfe.Reset();
            this.grdOrder_Apl.Reset();
            this.grdOrder_Xrt.Reset();
            this.grdOrder_Chuchi.Reset();
            this.grdOrder_Susul.Reset();
            this.grdOrder_Etc.Reset();
            this.grdOrder_Reha.Reset();

            if (this.layDrugOrder.RowCount > 0)
            {
                foreach (DataRow dr in this.layDrugOrder.LayoutTable.Rows)
                    this.grdOrder_Drug.LayoutTable.ImportRow(dr);
                this.grdOrder_Drug.DisplayData();
            }
            else
                this.grdOrder_Drug.Reset();

            if (this.layJusaOrder.RowCount > 0)
            {
                foreach (DataRow dr in this.layJusaOrder.LayoutTable.Rows)
                    this.grdOrder_Jusa.LayoutTable.ImportRow(dr);
                this.grdOrder_Jusa.DisplayData();
            }
            else
                this.grdOrder_Jusa.Reset();

            if (this.layCplOrder.RowCount > 0)
            {
                foreach (DataRow dr in this.layCplOrder.LayoutTable.Rows)
                    this.grdOrder_Cpl.LayoutTable.ImportRow(dr);
                this.grdOrder_Cpl.DisplayData();
            }
            else
                this.grdOrder_Cpl.Reset();

            if (this.layPfeOrder.RowCount > 0)
            {
                foreach (DataRow dr in this.layPfeOrder.LayoutTable.Rows)
                    this.grdOrder_Pfe.LayoutTable.ImportRow(dr);
                this.grdOrder_Pfe.DisplayData();
            }
            else
                this.grdOrder_Pfe.Reset();

            if (this.layAplOrder.RowCount > 0)
            {
                foreach (DataRow dr in this.layAplOrder.LayoutTable.Rows)
                    this.grdOrder_Apl.LayoutTable.ImportRow(dr);
                this.grdOrder_Apl.DisplayData();
            }
            else
                this.grdOrder_Apl.Reset();

            if (this.layXrtOrder.RowCount > 0)
            {
                foreach (DataRow dr in this.layXrtOrder.LayoutTable.Rows)
                    this.grdOrder_Xrt.LayoutTable.ImportRow(dr);
                this.grdOrder_Xrt.DisplayData();
            }
            else
                this.grdOrder_Xrt.Reset();

            if (this.layChuchiOrder.RowCount > 0)
            {
                foreach (DataRow dr in this.layChuchiOrder.LayoutTable.Rows)
                    this.grdOrder_Chuchi.LayoutTable.ImportRow(dr);
                this.grdOrder_Chuchi.DisplayData();
            }
            else
                this.grdOrder_Chuchi.Reset();

            if (this.laySusulOrder.RowCount > 0)
            {
                foreach (DataRow dr in this.laySusulOrder.LayoutTable.Rows)
                    this.grdOrder_Susul.LayoutTable.ImportRow(dr);
                this.grdOrder_Susul.DisplayData();
            }
            else
                this.grdOrder_Susul.Reset();

            // リハビリオーダ追加 2012/09/26
            if (this.layRehaOrder.RowCount > 0)
            {
                foreach (DataRow dr in this.layRehaOrder.LayoutTable.Rows)
                    this.grdOrder_Reha.LayoutTable.ImportRow(dr);
                this.grdOrder_Reha.DisplayData();
            }
            else
                this.grdOrder_Reha.Reset();

            if (this.layEtcOrder.RowCount > 0)
            {
                foreach (DataRow dr in this.layEtcOrder.LayoutTable.Rows)
                    this.grdOrder_Etc.LayoutTable.ImportRow(dr);
                this.grdOrder_Etc.DisplayData();
            }
            else
                this.grdOrder_Etc.Reset();
        }
        /// <summary>
        /// load outOrder 
        /// </summary>
        /// <param name="aBunho"></param>
        /// <param name="aFkout1001"></param>
        /// <param name="aQueryGubun"></param>
        /// <param name="aInputGubun"></param>
        /// <returns></returns>
        private bool LoadOutOrder(string aBunho, string aFkout1001, string aQueryGubun, string aInputGubun)
        {
            /*this.layQueryLayout.SetBindVarValue("f_bunho", aBunho);
            this.layQueryLayout.SetBindVarValue("f_fkout1001", aFkout1001);
            this.layQueryLayout.SetBindVarValue("f_query_gubun", aQueryGubun);
            this.layQueryLayout.SetBindVarValue("f_input_gubun", aInputGubun);*/

            this.layQueryLayout.ExecuteQuery = layQueryLayout_getData;
            this.layQueryLayout.QueryLayout(true);

            // 중간 레이아웃 초기화
            this.layDrugOrder.Reset();
            this.layJusaOrder.Reset();
            this.layCplOrder.Reset();
            this.layPfeOrder.Reset();
            this.layAplOrder.Reset();
            this.layXrtOrder.Reset();
            // 2012/09/26
            this.layRehaOrder.Reset();
            this.laySusulOrder.Reset();
            this.layChuchiOrder.Reset();
            this.layEtcOrder.Reset();

            foreach (DataRow dr in this.layQueryLayout.LayoutTable.Rows)
            {
                this.SetInputGubunColor(dr["input_gubun"].ToString());
                switch (dr["input_tab"].ToString())
                {
                    case "01":  // 내복약오더

                        this.layDrugOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "03":  // 주사오더

                        this.layJusaOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "04":  // 검체검사 오더

                        this.layCplOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "05":  // 생리검사 오더

                        this.layPfeOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "06":  // 병리검사 오더

                        this.layAplOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "07":  // 방사선 오더

                        this.layXrtOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "08":  // 처치

                        this.layChuchiOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "09":  // 마취 수술

                        this.laySusulOrder.LayoutTable.ImportRow(dr);

                        break;

                    // リハビリオーダ追加 2012/09/26
                    case "10":  // Reha

                        this.layRehaOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "11":  // 기타 오더

                        this.layEtcOrder.LayoutTable.ImportRow(dr);

                        break;
                }
            }

            this.LoadDoOrder_Grid();

            return true;
        }

        #endregion

        #region 접수 저장 처리

        /// <summary>
        /// Save JubsuInfo
        /// </summary>
        /// <param name="aPkNaewonKey"></param>
        /// <param name="aNaewonYN"></param>
        /// <returns></returns>
        private bool SaveJubsuInfo(string aPkNaewonKey, string aNaewonYN)
        {
            /*string cmdText = " UPDATE OUT1001 A"
                           + "    SET A.NAEWON_YN = '" + aNaewonYN + "' "
                           + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                           + "    AND A.PKOUT1001 = " + aPkNaewonKey;

            if (Service.ExecuteNonQuery(cmdText) == false)*/

            // Connect cloud
            OcsoOCS1003P01UpdateJubsuArgs JubsuInfo = new OcsoOCS1003P01UpdateJubsuArgs();
            JubsuInfo.NaewonYn = aNaewonYN;
            JubsuInfo.PkNaewonKey = aPkNaewonKey;
            UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, OcsoOCS1003P01UpdateJubsuArgs>(JubsuInfo);
            if (updateResult == null)
            {
                return false;
            }

            return updateResult.Result;
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        #region [ 비지니스 로직들... ]

        private bool IsGrantOrderUser()
        {
            return IsGrantOrderUser("D0");
        }

        private bool IsGrantOrderUser(string aInputGubun)
        {
            string inputid = "";

            // 권한체크 
            if (this.mDoctorLogin)
            {
                inputid = UserInfo.DoctorID;
            }
            else
            {
                inputid = UserInfo.UserID;
            }

            //if (aInputGubun.Substring(0, 1) == "D")
            //{
            //    // 오더 권한 체크 
            //    if (this.mOrderBiz.IsGrantOcsInputDoctor(inputid, this.dtpNaewonDate.GetDataValue()) == false)
            //    {
            //        MessageBox.Show(XMsg.GetMsg("M002"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //}

            return true;
        }

        /// <summary>
        /// 대기환자 그리드 필터링 셋팅
        /// </summary>
        private void SetPatientListGridFilter()
        {
            //if (this.grdPatientList.RowCount <= 0) return;

            string filter = "";

            if (this.rbnNotJinryo.Checked)
            {
                filter = "jinryo_end_yn='N'";
            }
            else if (this.rbnJinryo.Checked)
            {
                filter = "jinryo_end_yn='Y'";
            }

            this.grdPatientList.SetFilter(filter);

            SetPatientListImage();
        }

        /// <summary>
        /// 환자별로 Visible 셋팅될것들...
        /// </summary>
        private void SettingVisiblebyUser()
        {
            // 의사가 로그인 한 경우
            if (this.mDoctorLogin == true)
            {
                // tungtx
                // Connect cloud
                OCS1003P01SettingVisibleByUserArgs args = new OCS1003P01SettingVisibleByUserArgs();
                if (grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "bunho").ToString() != "")
                {
                    NaewonYNInfo1 yninfo = new NaewonYNInfo1();
                    yninfo.Bunho = mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                    yninfo.NaewonDate = mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
                    yninfo.Pkout1001 = mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                    args.NaewonParam = yninfo;
                }

                NotApproveOrderCntInfo cntInfo = new NotApproveOrderCntInfo();
                cntInfo.IoGubun = this.IO_Gubun;
                cntInfo.UserId = UserInfo.UserID;
                cntInfo.InsteadYn = "Y";
                cntInfo.ApproveYn = "N";
                cntInfo.Key = "%";

                args.CountParam = cntInfo;
                OCS1003P01SettingVisibleByUserResult result =
                    CloudService.Instance
                        .Submit<OCS1003P01SettingVisibleByUserResult, OCS1003P01SettingVisibleByUserArgs>(args);
                int countValue = 0;
                if (result != null && result.CountValue != null)
                {
                    countValue = Int32.Parse(result.CountValue);
                }
                // End connect cloud

                this.pnlUser.Visible = false;
                this.cboQryDoctor.Protect = true;
                //this.btnIpwonReser.Visible = true;
                this.btnConsult.Visible = true;
                this.btnConsultAnswer.Visible = true;
                this.btnJinryoReser.Visible = true;
                //this.pnlBtnListSB.Visible = true;

                this.btnList.FunctionItems.Clear();
                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Query, Shortcut.None, Resources.QUERY_BUTTON_TEXT, -1, ""));
                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Cancel, Shortcut.None, Resources.CANCEL_BUTTON_TEXT, -1, "OliveGreen"));
                //該当する患者のステータスが保留であれば診療保留ボタンを保留取消に切り替えるように修正 2012/09/10
                if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho").ToString() != "")
                {
                    //if (this.mOrderBiz.GetNaewonYN(mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(), mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(), mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) == "H")
                    //    this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Reset, Shortcut.None, Resources.RESET1_BUTTON_TEXT, -1, "HotPink"));
                    //else
                    //    this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Reset, Shortcut.None, Resources.RESET2_BUTTON_TEXT, -1, "HotPink"));

                    if (!String.IsNullOrEmpty(result.YnValue) && "H".Equals(result.YnValue))
                        this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Reset, Shortcut.None, Resources.RESET1_BUTTON_TEXT, -1, "HotPink"));
                    else
                        this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Reset, Shortcut.None, Resources.RESET2_BUTTON_TEXT, -1, "HotPink"));
                }
                else
                    this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Reset, Shortcut.None, Resources.RESET2_BUTTON_TEXT, -1, "HotPink"));
                //this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Insert, Shortcut.None, "傷病入力", -1, ""));
                //this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Delete, Shortcut.None, "傷病削除", -1, ""));
                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Update, Shortcut.None, Resources.UPDATE_BUTTON_TEXT, -1, ""));
                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Process, Shortcut.None, Resources.PROCESS_BUTTON_TEXT, -1, "OliveGreen"));
                //this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Close, Shortcut.None, "閉じる", -1, ""));
                this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                //this.btnList.Location = new Point(this.Parent.Width - 720, this.Parent.Height - 35);
                this.btnList.Location = new Point(this.Parent.Width - 460, this.Parent.Height - 35);
                this.btnList.InitializeButtons();
                this.btnList.Refresh();

                this.btnApprove.Visible = true;

                //this.pbxApprove.Visible = this.mOrderBiz.GetNotApproveOrderCnt(this.IO_Gubun, UserInfo.UserID, "Y", "N", "%") > 0 ? true : false;
                this.pbxApprove.Visible = countValue > 0 ? true : false;

            }
            // 의사 이외의 사람들이 로그인 한 경우
            else
            {
                this.pnlUser.Visible = true;

                this.btnIpwonReser.Visible = false;
                this.btnConsult.Visible = false;
                this.btnConsultAnswer.Visible = false;
                this.btnJinryoReser.Visible = false;
                //this.pnlBtnListSB.Visible = false;

                this.btnList.FunctionItems.Clear();

                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Query, Shortcut.None, Resources.QUERY_BUTTON_TEXT, -1, ""));
                //this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Insert, Shortcut.None, "傷病入力", -1, ""));
                //this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Delete, Shortcut.None, "傷病削除", -1, ""));
                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Update, Shortcut.None, Resources.UPDATE_BUTTON_TEXT, -1, ""));

                if (UserInfo.Gwa != "CK")
                    this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Process, Shortcut.None, Resources.PROCESS_BUTTON_TEXT, -1, "OliveGreen"));

                //this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Close, Shortcut.None, "閉じる", -1, ""));
                this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                //this.btnList.Location = new Point(this.Parent.Width - 450, this.Parent.Height - 35);
                this.btnList.Location = new Point(this.Parent.Width - 270, this.Parent.Height - 35);
                this.btnList.InitializeButtons();
                this.btnList.Refresh();

                this.btnApprove.Visible = false;
                this.pbxApprove.Visible = false;
            }
        }

        private bool IsOrderInputUserCheck(bool aIsCloseYN)
        {
            if (UserInfo.UserGubun == UserType.Doctor)
            {
                //나중에 bas0270 에 ocs status 체크 하는것으로 변경 
                //if (TypeCheck.IsNull(OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["gwa"].ToString()))
                //{
                //    this.mMsg = "該当画面に使用権限がない使用者です。ご確認下さい。";
                //    this.mCap = "使用権限確認";

                //    MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    return false;
                //}

                this.mDoctorLogin = true;
                this.mInputGubun = TypeCheck.NVL(UserInfo.InputGubun, "D%").ToString();
                this.mInputGwa = UserInfo.Gwa;

                this.lblApprove.Visible = false;

            }
            else
            {
                if (TypeCheck.IsNull(UserInfo.InputGubun))
                {
                    this.mMsg = Resources.MSG014_MSG;
                    this.mCap = Resources.MSG014_CAP;

                    MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
                this.mDoctorLogin = false;
                this.mInputGubun = UserInfo.InputGubun;
                this.mInputGwa = UserInfo.Gwa;

                if (this.mInputGubun == "CK")
                {
                    this.lblApproveFlag.Visible = true;
                    this.lblApproveLabel.Visible = true;
                }
            }

            //if (TypeCheck.IsNull(this.mInputGwa))
            //{
            //    //if (this.OpenParam != null && this.OpenParam.Contains("input_gwa"))
            //    //{
            //    //    this.mInputGwa = this.OpenParam["input_gwa"].ToString();
            //    //}
            //    //else
            //    //{
            //    //    this.mInputGwa = mCommonForms.SelectGwa("1", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            //    //}

            //    //if (TypeCheck.IsNull(this.mInputGwa))
            //    //{
            //    //    this.mMsg = Resources.MSG014_MSG;
            //    //    this.mCap = Resources.MSG014_CAP;

            //    //    MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    //    return false;
            //    //}
            //}

            return true;
        }

        private void SetPatientInfoLabel(DataRow aPatientInfo)
        {
            if (aPatientInfo == null) return;

            this.lbSuname.Text = aPatientInfo["suname"].ToString();
            this.lbSuname2.Text = aPatientInfo["suname2"].ToString();
            this.lbSexAge.Text = aPatientInfo["sex"].ToString() + "/" + aPatientInfo["age"].ToString();
            this.lbWeight.Text = aPatientInfo["weight"].ToString();
            this.lbHeight.Text = aPatientInfo["height"].ToString();
            this.lbGubunName.Text = aPatientInfo["gubun_name"].ToString();
            this.lbChojaeName.Text = aPatientInfo["chojae_name"].ToString();
        }

        private void ClearPatientInfoLabel()
        {
            // 환자정보 컨트롤 클리어
            for (int i = 0; i < this.mBunhoInfoControls.Count; i++)
            {
                if (((Control)mBunhoInfoControls[i]).Name == "fbxBunho") continue;

                if (((Control)mBunhoInfoControls[i]) is XLabel)
                {
                    ((XLabel)mBunhoInfoControls[i]).Text = "";
                }
                else if (((Control)mBunhoInfoControls[i]) is XTextBox)
                {
                    ((XTextBox)mBunhoInfoControls[i]).SetDataValue("");
                }
            }
        }

        /// <summary>
        /// 환자번호 입력시 각종체크들 ( 알레르기, 타과진료, 진료의뢰, 환자특기사항 )
        /// </summary>
        /// <param name="aNaewonDate">내원일자</param>
        /// <param name="aBunho">환자번호</param>
        /// <param name="aGwa">진료과</param>
        /// <param name="aDoctor">진료의</param>
        private void CheckPatientEtcInfo(string aNaewonDate, string aBunho, string aGwa, string aDoctor)
        {
            // TODO comment: use connect to cloud
            /*            bool isAllergyYn = false;
                        // 알레르기 팝업
                        //this.mOrderBiz.OpenAllergyInfo(this, aBunho, aNaewonDate, ref isAllergyYn);
                        // insert by jc [使用者オプションによる表示・非表示] 2012/09/24
                        if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "ALLERGY_POP_YN", this.IO_Gubun) != "N")
                            this.mOrderBiz.OpenAllergyInfo(this, aBunho, aNaewonDate, ref isAllergyYn);*/

            bool isAllergyYn = CheckOpenAllergyInfo(aBunho, aNaewonDate);
            if (isAllergyYn)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", aBunho);
                openParams.Add("order_date", aNaewonDate);
                openParams.Add("read_only", true);

                //약속코드조회 화면 Open
                XScreen.OpenScreenWithParam(this, "NURI", "NUR1016U00", ScreenOpenStyle.ResponseSizable, openParams);
            }

            if (this.mDoctorLogin)
            {
                // Consult 의뢰가 있는 경우에 표시한다.
                //if (this.mOrderBiz.LoadConsultYN(aBunho, aNaewonDate, aGwa, aDoctor))
                // 確認していない依頼が存在すれば点滅させて知らせる 2012/11/22
                //if (this.mOrderBiz.IsNoConfirmConsult(aBunho, aNaewonDate, aGwa, aDoctor, IO_Gubun))
                //    this.pbxConsultAnswer.Visible = true;

                // insert by jc [返事がない依頼件があるか確認してあれば点滅させて知らせる] 2012/11/09
                //if (this.mOrderBiz.IsNoReturnConsult(aBunho, this.dtpNaewonDate.GetDataValue(), aGwa, aDoctor, IO_Gubun))
                //    this.pbxIsNoReturnConsult.Visible = true;

                ////진료의뢰여부응답여부
                //string req_date = this.mOrderBiz.LoadConsultEndYN(aBunho, aDoctor);
                //if (req_date != "")
                //{
                //    if (!this.mIsCalledbyOtherScreen)
                //    {
                //        this.pbxConsultAnswer.Visible = true;
                //        // 진료의뢰 화면을 연다.
                //        //this.btnConsult.PerformClick();
                //    }
                //}

                string req_date = "";
                bool IsNoConfirmConsult = false;

                // Connect to cloud
                OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultResult loadResult = LoadConsultEndYnAndIsNoConfirmConsult(aBunho, aDoctor, aGwa, IO_Gubun);

                if (loadResult != null && loadResult.ExecutionStatus == ExecutionStatus.Success)
                {
                    req_date = loadResult.ReqDate;
                    IsNoConfirmConsult = loadResult.IsNoReturnConsultYn;
                }

                //string req_date = this.mOrderBiz.LoadConsultEndYN(aBunho, aDoctor);
                if (req_date != "")
                    this.pbxIsNoConfirmOfReturnedConsult.Visible = true;


                // insert by jc [返事がない依頼件があるか確認してあれば点滅させて知らせる] 2012/11/09
                //if (this.mOrderBiz.IsNoConfirmConsult(aBunho, this.dtpNaewonDate.GetDataValue().ToString(), aGwa, aDoctor, IO_Gubun))
                if (IsNoConfirmConsult)
                    this.pbxIsNoAnwerOfConsulted.Visible = true;

                // 입원예약여부-- 외래 오픈시에는 이걸뺀다
                //if (this.mOrderBiz.IsIpwonReserStatus(aDoctor, aBunho) == true)
                //{
                //    if (this.mDoctorLogin)
                //        this.pbxInpReserYN.Visible = true;
                //}
            }

            // Connect to cloud 
            bool IsKensaReser_yn = false;
            string commemt = "";
            string getUserOption = "";
            int etcJinryoCnt = 0;
            int etcJinryoCommentCnt = 0;
            bool existAllergyData = false;
            bool isIpwonReserStatus = false;
            OCS1003P01CheckPatientEtcResult checkPatientEtcResult = CheckPatientEtcResult(aBunho, aNaewonDate, aGwa, aDoctor);
            if (checkPatientEtcResult != null && checkPatientEtcResult.ExecutionStatus == ExecutionStatus.Success)
            {
                if (checkPatientEtcResult.KensaReserValue != null && checkPatientEtcResult.KensaReserValue == "Y")
                {
                    IsKensaReser_yn = true;
                }
                commemt = checkPatientEtcResult.SpecificComment;
                getUserOption = checkPatientEtcResult.UserOption;
                if (TypeCheck.IsInt(checkPatientEtcResult.OutTaGwaJinryoCnt))
                {
                    etcJinryoCnt = int.Parse(checkPatientEtcResult.OutTaGwaJinryoCnt);
                }
                if (TypeCheck.IsInt(checkPatientEtcResult.OutJinryoComment))
                {
                    etcJinryoCommentCnt = int.Parse(checkPatientEtcResult.OutJinryoComment);
                }
                if (checkPatientEtcResult.AllergyData != null)
                {
                    existAllergyData = checkPatientEtcResult.AllergyData;
                }
                if (checkPatientEtcResult.IpwonReserStatus != null)
                {
                    isIpwonReserStatus = checkPatientEtcResult.IpwonReserStatus;
                }
            }

            // 今日を除いて未実施状態の検査予約件があるのかチェック。
            //this.pbxIsKensaReser.Visible = this.mOrderBiz.IsKensaReser(aBunho, aNaewonDate);
            this.pbxIsKensaReser.Visible = IsKensaReser_yn;


            // 코맨트
            //string commemt = this.mOrderBiz.LoadPatientSpecificComment(aBunho);
            // insert by jc [使用者オプションによる表示・非表示] 2012/09/24

            // insert by jc [使用者オプションによる表示・非表示] 2012/09/24
            //if(this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "SPECIALWRITE_POP_YN"))
            //    commemt = this.mOrderBiz.LoadPatientSpecificComment(aBunho);

            //if (commemt != "")
            //{
            //    this.mCap = "患者特記事項";

            //    MessageBox.Show(commemt, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    this.pbxExistBunhoComment.Visible = true;
            //}

            // insert by jc [使用者オプションによる表示・非表示] 2012/09/24

            //commemt = this.mOrderBiz.LoadPatientSpecificComment(aBunho);

            //if (commemt != "" && this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "SPECIALWRITE_POP_YN", this.IO_Gubun) != "N")
            if (commemt != "" && getUserOption != "N")
            {
                this.mCap = Resources.MSG015_CAP;
                MessageBox.Show(commemt, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.pbxExistBunhoComment.Visible = true;
            }
            else if (commemt != "")
            {
                this.pbxExistBunhoComment.Visible = true;
            }

            if (this.mDoctorLogin)
            {
                //int etcJinryoCnt = this.mOrderBiz.GetOutTaGwaJinryoCnt(aBunho, aNaewonDate, aGwa);

                if (etcJinryoCnt > 0)
                {
                    this.pbxEtcJinryo.Visible = true;
                }
                else
                {
                    this.pbxEtcJinryo.Visible = false;
                }
            }

            if (this.mDoctorLogin)
            {
                //int etcJinryoCommentCnt = this.mOrderBiz.GetOutJinryoCommentCnt(aBunho, aNaewonDate, aGwa, aDoctor);

                if (etcJinryoCommentCnt > 0)
                {
                    this.pbxJinryoComment.Visible = true;
                }
                else
                {
                    this.pbxJinryoComment.Visible = false;
                }
            }

            // 오늘 측정한 바이탈 사인이 있는경우 자동 팝업
            if (this.mSelectedPatientInfo.GetPatientInfo["today_vital_yn"].ToString() == "Y")
                this.pbxVital.Visible = true;

            //this.pbxExistAllergy.Visible = this.mOrderBiz.ExistAllergyData(aBunho);//アレルギー情報があるのか確認
            this.pbxExistAllergy.Visible = existAllergyData;
            if (EnvironInfo.CurrSystemID != "INSO")
                //this.pbxInpReserYN.Visible = this.mOrderBiz.IsIpwonReserStatus(aDoctor, aBunho);//入院時オーダ有無チェック
                this.pbxInpReserYN.Visible = isIpwonReserStatus;

        }
        /// <summary>
        /// 변경된 데이터 체크
        /// </summary>
        /// <returns>true : 데이터가 있고 저장을 선택한 경우, false : 데이터가 없거나 저장을 선택하지 않은 경우</returns>
        private bool IsOrderDataModifed()
        {
            bool isExistModifiedData = false;

            this.mOrderFunc.DeleteEmptyNewRow(this.grdOutSang);

            if (this.grdOutSang.GetChangedRowCount('A') > 0)
            //			    this.cbxWonyoi_Order_Yn_Wonmu.DataChanged  || this.fbxWonnae_Sayu_Code_Wonmu.DataChanged  ||
            //				this.emDrg_Nalsu.DataChanged               || this.cbxHubal_Change_Yn.DataChanged ||
            //				this.cboJinryo_Result.DataChanged          || this.cbxSoa_Nutjido_Yn.DataChanged ||
            //				this.cboAtc_Yn.DataChanged                 || this.cbxNext_jinryo_yn.DataChanged)
            {
                isExistModifiedData = true;
            }

            if (isExistModifiedData == false)
            {
                if (this.layDrugOrder.GetChangedRowCount('A') > 0 ||
                    this.layJusaOrder.GetChangedRowCount('A') > 0 ||
                    this.layCplOrder.GetChangedRowCount('A') > 0 ||
                    this.layPfeOrder.GetChangedRowCount('A') > 0 ||
                    this.layAplOrder.GetChangedRowCount('A') > 0 ||
                    this.layChuchiOrder.GetChangedRowCount('A') > 0 ||
                    this.laySusulOrder.GetChangedRowCount('A') > 0 ||
                    this.layXrtOrder.GetChangedRowCount('A') > 0 ||
                    //リハビリオーダ追加 2012/09/26
                    this.layRehaOrder.GetChangedRowCount('A') > 0 ||
                    this.layEtcOrder.GetChangedRowCount('A') > 0 ||
                    this.layDeletedData.RowCount > 0)
                {
                    isExistModifiedData = true;
                }
            }

            if (isExistModifiedData == true)
            {
                this.mMsg = Resources.MSG016_MSG;
                this.mCap = Resources.MSG016_CAP;

                DialogResult result = MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    return true;
                }
            }

            return false;
        }

        private void MakePatientSangCombo(DataTable aDataSource)
        {
            string code = "";
            string name = "";

            this.cboOutSang.DataSource = null;
            this.cboOutSang.ComboItems.Clear();

            for (int i = 0; i < aDataSource.Rows.Count; i++)
            {
                code = aDataSource.Rows[i]["sang_code"] + "_" + i.ToString();
                if (aDataSource.Rows[i]["ju_sang_yn"].ToString() == "Y")
                {
                    name = "(主)  " + aDataSource.Rows[i]["display_sang_name"].ToString();
                    //name = "√  " + aDataSource.Rows[i]["display_sang_name"].ToString(); 
                }
                else
                {
                    name = "    " + aDataSource.Rows[i]["display_sang_name"].ToString();
                }

                this.cboOutSang.ComboItems.Add(code, name);
            }

            this.cboOutSang.DataSource = this.cboOutSang.ComboItems;
            this.cboOutSang.ValueMember = "ValueItem";
            this.cboOutSang.DisplayMember = "DisplayItem";
            if (this.cboOutSang.ComboItems.Count > 0)
                this.cboOutSang.SelectedIndex = this.cboOutSang.ComboItems.Count - 1;
        }

        //inser by jc 
        private void MakeJinryoGwaCombo(MultiLayout gwaData)
        {
            this.cboJinryoGwa.DataSource = null;
            this.cboJinryoGwa.ComboItems.Clear();

            foreach (DataRow dr in gwaData.LayoutTable.Rows)
            {
                this.cboJinryoGwa.ComboItems.Add(dr["GWA"].ToString(), dr["GWA_NAME"].ToString());

            }

            this.cboJinryoGwa.DataSource = this.cboJinryoGwa.ComboItems;
            this.cboJinryoGwa.ValueMember = "ValueItem";
            this.cboJinryoGwa.DisplayMember = "DisplayItem";
            if (this.cboJinryoGwa.ComboItems.Count > 0)
                this.cboJinryoGwa.SelectedIndex = 0;


        }

        /// <summary>
        /// MakeJinryoGwaCombo use connect cloud
        /// </summary>
        /// <param name="lstComboListItemInfo"></param>
        private void MakeJinryoGwaCombo(List<ComboListItemInfo> lstComboListItemInfo)
        {
            this.cboJinryoGwa.DataSource = null;
            this.cboJinryoGwa.ComboItems.Clear();

            foreach (ComboListItemInfo itemInfo in lstComboListItemInfo)
            {
                this.cboJinryoGwa.ComboItems.Add(itemInfo.Code, itemInfo.CodeName);
            }

            this.cboJinryoGwa.DataSource = this.cboJinryoGwa.ComboItems;
            this.cboJinryoGwa.ValueMember = "ValueItem";
            this.cboJinryoGwa.DisplayMember = "DisplayItem";
            if (this.cboJinryoGwa.ComboItems.Count > 0)
                this.cboJinryoGwa.SelectedIndex = 0;

        }


        private void SetPatientListImage()
        {
            for (int i = 0; i < this.grdPatientList.RowCount; i++)
            {
                // 예약환자
                if (this.grdPatientList.GetItemString(i, "reser_yn") == "Y")
                {
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = this.ImageList.Images[19];
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/予約患者";
                //MED-6663 edit by TungTX
                //Start
                    this.grdPatientList.SetItemValue(i, "arrive_time", "");
                    this.grdPatientList.ResetUpdate();
                }
                else
                {
                    this.grdPatientList.SetItemValue(i, "jinryo_time", "");
                    this.grdPatientList.ResetUpdate();
                }
                //End

                if (this.grdPatientList.GetItemString(i, "kensa_yn") == "Y")
                {
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = this.ImageList.Images[29];
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/検査予約あり";
                }

                // 컨설트 환자
                if (this.grdPatientList.GetItemString(i, "consult_yn") == "Y")
                {
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = this.ImageList.Images[22];
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/診療依頼";
                }

                // 공통의 환자
                if (this.grdPatientList.GetItemString(i, "common_doctor_yn") == "Y")
                {
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = this.ImageList.Images[34];
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/共通医";
                }

                switch (this.grdPatientList.GetItemString(i, "jubsu_gubun"))
                {
                    case "07":    // 약만의 환자

                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = this.ImageList.Images[6];
                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/薬のみ";

                        break;

                    case "14":    // 긴급환자

                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = this.ImageList.Images[30];
                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/救急";

                        break;

                    case "15":  // 건강진단

                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = this.ImageList.Images[33];
                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/健康診断";

                        break;

                    case "20":  // 外診１

                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = this.ImageList.Images[41];
                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/健康診断";

                        break;

                    case "21":  // 外診２

                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = this.ImageList.Images[42];
                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/健康診断";

                        break;

                    case "22":  // 再診

                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = this.ImageList.Images[43];
                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/健康診断";

                        break;
                }

                if (this.grdPatientList.GetItemString(i, "unapprove_yn") == "Y")
                {
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 3].Image = this.ImageList.Images[44];
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 3].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 3].ToolTipText + "/未承認オーダーあり";
                }
            }
        }

        //insert by jc
        /// <summary>[保存、診療保留、診療終了際の担当医確認]</summary>
        /// <param name ="aActionDoctor">行為をしているドクターの番号</param>
        /// <param name ="aBunho">診察中の患者番号</param>
        /// <param name ="aNaewon_key">受付番号</param>
        /// <param name ="return">保存可能：Y、保存不可能：N</param>
        private bool IsCanUpdateDoctor(string aActionDoctor, string aBunho, string aNaewon_key)
        {
            //            SingleLayout lyCheckCanUpdateDoctor = new SingleLayout();

            //            lyCheckCanUpdateDoctor.LayoutItems.Add("result");

            //            lyCheckCanUpdateDoctor.QuerySQL = @"SELECT 'X' 
            //                                                  FROM OUT1001 A 
            //                                                 WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
            //                                                   AND A.DOCTOR    = :f_actiondoctor 
            //                                                   AND A.BUNHO     = :f_bunho 
            //                                                   AND A.PKOUT1001 = :f_naewon_key";

            //            lyCheckCanUpdateDoctor.SetBindVarValue("f_actiondoctor", aActionDoctor);
            //            lyCheckCanUpdateDoctor.SetBindVarValue("f_bunho", aBunho);
            //            lyCheckCanUpdateDoctor.SetBindVarValue("f_naewon_key", aNaewon_key);

            //            //check
            //            if (lyCheckCanUpdateDoctor.QueryLayout() && lyCheckCanUpdateDoctor.GetItemValue("result").ToString() != "")
            //            {
            //                return true;
            //            }

            OcsoOCS1003P01CheckXArgs checkUpdateDoctorArg = new OcsoOCS1003P01CheckXArgs();
            checkUpdateDoctorArg.ActionDoctor = aActionDoctor;
            checkUpdateDoctorArg.Bunho = aBunho;
            checkUpdateDoctorArg.NaewonKey = aNaewon_key;
            OcsoOCS1003P01CheckXResult result = CloudService.Instance.Submit<OcsoOCS1003P01CheckXResult, OcsoOCS1003P01CheckXArgs>(checkUpdateDoctorArg);
            if (result != null && result.XValue != "")
            {
                return true;
            }
            else
            {
                string mbxMsg = Resources.MSG017_MSG;
                string mbxCap = Resources.MSG017_CAP;
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }


        #region 상병관련

        /// <summary>
        /// 상병입력가능여부
        /// </summary>
        /// <param name="aErrMsg">입력불가일경우의 사유</param>
        /// <returns>true, false</returns>
        private bool SangInputCheck(ref string aErrMsg)
        {
            // 상병 입력가능 여부 체크
            if (this.fbxBunho.GetDataValue() == "")
            {
                aErrMsg = XMsg.GetMsg("M001"); //진료대상환자를 선택해 주세요.
                return false;
            }

            return true;
        }


        /// <summary>
        /// 해당 Row에 의증이 등록되어 있는지 check한다.
        /// </summary>
        private bool CheckDoubt(XEditGrid grdObject, int currentRow)
        {
            bool returnValue = false;

            //접미어
            if (grdObject.GetItemString(currentRow, "post_modifier1").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier2").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier3").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier4").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier5").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier6").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier7").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier8").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier9").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier10").Trim() == "8002")
                returnValue = true;

            return returnValue;
        }

        /// <summary>
        /// 해당 Row에 의증을 set/Reset한다.
        /// </summary>		
        private void SetDoubt(bool addMode, XEditGrid grdObject, int currentRow)
        {
            string colName = "";
            if (addMode)
            {
                for (int i = 1; i <= 10; i++)
                {
                    colName = "post_modifier" + i.ToString();
                    if (grdObject.GetItemString(currentRow, colName).Trim() == "")
                    {
                        grdObject.SetItemValue(currentRow, colName, "8002");
                        grdObject.SetItemValue(currentRow, "post_modifier_name", grdObject.GetItemString(currentRow, "post_modifier_name") + "の疑い");
                        grdObject.SetItemValue(currentRow, "display_sang_name", grdObject.GetItemString(currentRow, "display_sang_name") + "の疑い");
                        break;
                    }
                }
            }
            else
            {
                for (int i = 1; i <= 10; i++)
                {
                    colName = "post_modifier" + i.ToString();
                    if (grdObject.GetItemString(currentRow, colName).Trim() == "8002")
                    {
                        grdObject.SetItemValue(currentRow, colName, "");
                        grdObject.SetItemValue(currentRow, "post_modifier_name", grdObject.GetItemString(currentRow, "post_modifier_name").Replace("の疑い", ""));
                        grdObject.SetItemValue(currentRow, "display_sang_name", grdObject.GetItemString(currentRow, "display_sang_name").Replace("の疑い", ""));
                        break;
                    }
                }
            }

            grdObject.Refresh();
        }

        /// <summary>
        /// 해당 Row의 수식어를 Clear한다.
        /// </summary>
        private void ClearSangName(XEditGrid grdObject, int currentRow)
        {
            string colName = "";

            for (int i = 1; i <= 10; i++)
            {
                colName = "pre_modifier" + i.ToString();
                if (grdObject.GetItemString(currentRow, colName).Trim() != "")
                    grdObject.SetItemValue(currentRow, colName, "");

                colName = "post_modifier" + i.ToString();
                if (grdObject.GetItemString(currentRow, colName).Trim() != "")
                    grdObject.SetItemValue(currentRow, colName, "");
            }

            grdObject.SetItemValue(currentRow, "pre_modifier_name", "");
            grdObject.SetItemValue(currentRow, "post_modifier_name", "");
        }

        private void ApplySangInfo(XEditGrid aGrid, MultiLayout aLayout, bool aIsUserSang)
        {
            int rowNumber = -1;
            string display_sang_name = "";

            if (!aIsUserSang)
            {
                foreach (DataRow dr in aLayout.LayoutTable.Rows)
                {
                    if (aGrid.RowCount <= 0)
                    {
                        this.btnListSB.PerformClick(FunctionType.Insert);
                    }

                    if (aGrid.GetItemString(aGrid.CurrentRowNumber, "sang_code") != "")
                    {
                        this.btnListSB.PerformClick(FunctionType.Insert);
                    }

                    rowNumber = aGrid.CurrentRowNumber;

                    aGrid.SetFocusToItem(rowNumber, "sang_code", true);
                    aGrid.SetEditorValue(dr["sang_code"].ToString());
                    if (aGrid.AcceptData() == false)
                    {
                        return;
                    }
                }
            }
            else
            {
                foreach (DataRow dr in aLayout.LayoutTable.Rows)
                {
                    if (aGrid.RowCount <= 0)
                    {
                        this.btnListSB.PerformClick(FunctionType.Insert);
                    }

                    if (aGrid.GetItemString(aGrid.CurrentRowNumber, "sang_code") != "")
                    {
                        this.btnListSB.PerformClick(FunctionType.Insert);
                    }

                    rowNumber = aGrid.CurrentRowNumber;

                    foreach (XEditGridCell cell in grdOutSang.CellInfos)
                    {
                        if (aLayout.LayoutItems.Contains(cell.CellName))
                            aGrid.SetItemValue(rowNumber, cell.CellName, dr[cell.CellName]);
                    }

                    //display 상병명
                    display_sang_name = this.mOrderBiz.GetDisplaySangName(aGrid.GetItemString(rowNumber, "pre_modifier_name"),
                        aGrid.GetItemString(rowNumber, "sang_name"),
                        aGrid.GetItemString(rowNumber, "post_modifier_name"));
                    aGrid.SetItemValue(rowNumber, "display_sang_name", display_sang_name);

                    aGrid.Refresh();
                }

                aGrid.AcceptData();
            }
        }

        #endregion

        #region [ 오더 관련 ]

        private void RecieveAndSetOrderInfo(string aCommand, XEditGrid aGrid)
        {
            switch (aCommand)
            {
                case "OCS0103U10": // 약오더인경우 

                    this.layDrugOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layDrugOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    break;
                case "OCS0103U11": // リハビリオーダ追加 2012/09/26

                    this.layRehaOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layRehaOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layRehaOrder.SetItemValue(this.layRehaOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layRehaOrder.SetItemValue(this.layRehaOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    break;
                case "OCS0103U12": // 주사오더 

                    this.layJusaOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layJusaOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layJusaOrder.SetItemValue(this.layJusaOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layJusaOrder.SetItemValue(this.layJusaOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    break;

                case "OCS0103U13": // 검체검사오더인경우 

                    this.layCplOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layCplOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    break;

                case "OCS0103U14": // 생리검사오더 

                    this.layPfeOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layPfeOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layPfeOrder.SetItemValue(this.layPfeOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layPfeOrder.SetItemValue(this.layPfeOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    break;

                case "OCS0103U15": // 병리검사오더 

                    this.layAplOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layAplOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layAplOrder.SetItemValue(this.layAplOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layAplOrder.SetItemValue(this.layAplOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    break;

                case "OCS0103U16": // 방사선오더 

                    this.layXrtOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layXrtOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layXrtOrder.SetItemValue(this.layXrtOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layXrtOrder.SetItemValue(this.layXrtOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    break;

                case "OCS0103U17": // 처치 

                    this.layChuchiOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layChuchiOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    break;

                case "OCS0103U18": // 수술 

                    this.laySusulOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.laySusulOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.laySusulOrder.SetItemValue(this.laySusulOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.laySusulOrder.SetItemValue(this.laySusulOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    break;

                case "OCS0103U19": // 기타

                    this.layEtcOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layEtcOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layEtcOrder.SetItemValue(this.layEtcOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layEtcOrder.SetItemValue(this.layEtcOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    break;

            }
        }


        private void SetDisplayLayout(string aInputGubun, string aInputTab)
        {
            this.layDisplayLayout.Reset();

            MultiLayout layTemp = this.layDisplayLayout.Clone();
            MultiLayout sourceLay = this.layQueryLayout.Clone();

            Hashtable existOrder = new Hashtable();

            #region [ 내복약 ]

            if (aInputTab == "01" || aInputTab == "%")    // 내복약
            {
                sourceLay.Reset();

                // 의사가 로그인한 경우
                if (this.mDoctorLogin)
                {
                    // 내복약 셋팅

                    for (int i = 0; i < this.layDrugOrder.RowCount; i++)
                    {
                        if (this.layDrugOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layDrugOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layDrugOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                // 의사 이외의 사람이 로그인한 경우
                else
                {
                    // 내복약 셋팅

                    for (int i = 0; i < this.layDrugOrder.RowCount; i++)
                    {
                        if (this.layDrugOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layDrugOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layDrugOrder.LayoutTable.Rows[i]);
                        }
                    }
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);

                foreach (DataRow drugRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(drugRow);
                    //this.grdDebug.LayoutTable.ImportRow(drugRow);
                }

                //this.grdDebug.DisplayData();
            }

            #endregion

            #region [ 주사약 ]

            if (aInputTab == "03" || aInputTab == "%")    // 주사약
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 주사약 셋팅

                    for (int i = 0; i < this.layJusaOrder.RowCount; i++)
                    {
                        if (this.layJusaOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layJusaOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layJusaOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 주사약 셋팅

                    for (int i = 0; i < this.layJusaOrder.RowCount; i++)
                    {
                        if (this.layJusaOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layJusaOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layJusaOrder.LayoutTable.Rows[i]);
                        }
                    }
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);

                foreach (DataRow jusaRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(jusaRow);
                }
            }

            #endregion

            #region [ 검체검사 ]

            if (aInputTab == "04" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 검체검사 셋팅

                    for (int i = 0; i < this.layCplOrder.RowCount; i++)
                    {
                        if (this.layCplOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layCplOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layCplOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 검체검사 셋팅

                    for (int i = 0; i < this.layCplOrder.RowCount; i++)
                    {
                        if (this.layCplOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layCplOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layCplOrder.LayoutTable.Rows[i]);
                        }
                    }
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 검체검사 오더 셋팅

                foreach (DataRow cplRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(cplRow);
                }
            }

            #endregion

            #region [ 생리검사 ]

            if (aInputTab == "05" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 생리검사 셋팅

                    for (int i = 0; i < this.layPfeOrder.RowCount; i++)
                    {
                        if (this.layPfeOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layPfeOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layPfeOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 생리검사 셋팅

                    for (int i = 0; i < this.layPfeOrder.RowCount; i++)
                    {
                        if (this.layPfeOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layPfeOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layPfeOrder.LayoutTable.Rows[i]);
                        }
                    }
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 생리검사 오더 셋팅

                foreach (DataRow pfeRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(pfeRow);
                }
            }

            #endregion

            #region [ 병리검사 ]

            if (aInputTab == "06" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 병리검사 셋팅

                    for (int i = 0; i < this.layAplOrder.RowCount; i++)
                    {
                        if (this.layAplOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layAplOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layAplOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 병리검사 셋팅

                    for (int i = 0; i < this.layAplOrder.RowCount; i++)
                    {
                        if (this.layAplOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layAplOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layAplOrder.LayoutTable.Rows[i]);
                        }
                    }
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 병리검사 오더 셋팅

                foreach (DataRow aplRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(aplRow);
                }
            }

            #endregion

            #region [ 방사선 ]

            if (aInputTab == "07" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 방사선 셋팅

                    for (int i = 0; i < this.layXrtOrder.RowCount; i++)
                    {
                        if (this.layXrtOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layXrtOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layXrtOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 병리검사 셋팅

                    for (int i = 0; i < this.layXrtOrder.RowCount; i++)
                    {
                        if (this.layXrtOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layXrtOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layXrtOrder.LayoutTable.Rows[i]);
                        }
                    }
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 병리검사 오더 셋팅

                foreach (DataRow xrtRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(xrtRow);
                }
            }

            #endregion

            #region [ 처치오더 ]

            if (aInputTab == "08" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 처치오더 셋팅

                    for (int i = 0; i < this.layChuchiOrder.RowCount; i++)
                    {
                        if (this.layChuchiOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layChuchiOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layChuchiOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 처치오더 셋팅

                    for (int i = 0; i < this.layChuchiOrder.RowCount; i++)
                    {
                        if (this.layChuchiOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layChuchiOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layChuchiOrder.LayoutTable.Rows[i]);
                        }
                    }
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 처치 오더 셋팅

                foreach (DataRow chuchiRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(chuchiRow);
                }
            }

            #endregion

            #region [ 수술오더 ]

            if (aInputTab == "09" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 수술오더 셋팅

                    for (int i = 0; i < this.laySusulOrder.RowCount; i++)
                    {
                        if (this.laySusulOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.laySusulOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.laySusulOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 수술오더 셋팅

                    for (int i = 0; i < this.laySusulOrder.RowCount; i++)
                    {
                        if (this.laySusulOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.laySusulOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.laySusulOrder.LayoutTable.Rows[i]);
                        }
                    }
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 수술오더  셋팅

                foreach (DataRow susulRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(susulRow);
                }
            }

            #endregion

            #region [ リハビリ ] リハビリオーダ追加 2012/09/26

            if (aInputTab == "10" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {

                    for (int i = 0; i < this.layRehaOrder.RowCount; i++)
                    {
                        if (this.layRehaOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layRehaOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layRehaOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {

                    for (int i = 0; i < this.layRehaOrder.RowCount; i++)
                    {
                        if (this.layRehaOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layRehaOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layRehaOrder.LayoutTable.Rows[i]);
                        }
                    }
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);

                foreach (DataRow rehaRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(rehaRow);
                }
            }

            #endregion

            #region [ 기타오더 ]

            if (aInputTab == "11" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 기타오더 셋팅
                    //foreach (DataRow etcFilter in this.layEtcOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(etcFilter);
                    //}
                    for (int i = 0; i < this.layEtcOrder.RowCount; i++)
                    {
                        if (this.layEtcOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layEtcOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layEtcOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 기타오더 셋팅
                    //foreach (DataRow etcFilter in this.layEtcOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(etcFilter);
                    //}
                    for (int i = 0; i < this.layEtcOrder.RowCount; i++)
                    {
                        if (this.layEtcOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layEtcOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layEtcOrder.LayoutTable.Rows[i]);
                        }
                    }
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 기타오더  셋팅

                foreach (DataRow etcRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(etcRow);
                }
            }

            #endregion
        }

        private void DislplayOrderDataWindow(string aInputGubun, string aInputTab)
        {
            this.SetInputTabRadioColor(aInputGubun);

            this.SetDisplayLayout(aInputGubun, aInputTab);

            // 全体Ｄｏオーダ関連
            this.LoadDoOrder_Grid();

            this.grdDebug.Reset();
            foreach (DataRow dr in this.layDisplayLayout.LayoutTable.Rows)
            {
                this.grdDebug.LayoutTable.ImportRow(dr);
            }
            this.grdDebug.DisplayData();

            this.dwOrderInfo.Reset();

            this.dwOrderInfo.FillData(this.layDisplayLayout.LayoutTable);
        }

        private void SetInputTabRadioColor(string aInputGubun)
        {
            XRadioButton allButton = null;
            XRadioButton control;
            bool isExistOrder = false;

            foreach (Control ctl in pnlInputTab.Controls)
            {
                if (ctl is XRadioButton)
                {
                    control = ctl as XRadioButton;
                    // control forecolor reset
                    if (control.Checked)
                    {
                        control.ForeColor = this.mSelectedForeColor;
                    }
                    else
                    {
                        control.ForeColor = this.mUnSelectedForeColor;
                    }

                    if (ctl.Tag.ToString() == "%")
                    {
                        allButton = ctl as XRadioButton;
                    }
                    else
                    {
                        //insert by jc
                        if (ctl.Tag != null)
                        {
                            switch (ctl.Tag.ToString())
                            {
                                case "01":     // 약
                                    if (this.layDrugOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "03":     // 주사
                                    if (this.layJusaOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "04":     // 검체검사
                                    if (this.layCplOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "05":     // 생리검사
                                    if (this.layPfeOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "06":     // 병리검사
                                    if (this.layAplOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "07":     // 방사선
                                    if (this.layXrtOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "08":     // 처치
                                    if (this.layChuchiOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "09":     // 마취, 수술
                                    if (this.laySusulOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                // リハビリオーダ追加 2012/09/26
                                case "10":     // リハビリ
                                    if (this.layRehaOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "11":     // 기타
                                    if (this.layEtcOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                            }
                        }
                    }
                }

                if (isExistOrder == true)
                {
                    allButton.ForeColor = new XColor(Color.Red);
                }
            }
        }

        private bool IsPatientSelected()
        {
            if (this.fbxBunho.GetDataValue() == "" ||
                this.mSelectedPatientInfo == null ||
                this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() == "")
            {
                mbxMsg = Resources.MSG018_MSG;
                mbxCap = Resources.MSG001_CAP;
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ClearOrderData()
        {
            this.layDeletedData.Reset();
            this.layDisplayLayout.Reset();
            this.layDrugOrder.Reset();
            this.layJusaOrder.Reset();
            this.layCplOrder.Reset();
            this.layPfeOrder.Reset();
            this.layAplOrder.Reset();
            this.layXrtOrder.Reset();
            this.layChuchiOrder.Reset();
            this.laySusulOrder.Reset();
            // リハビリオーダ追加 2012/09/26
            this.layRehaOrder.Reset();
            this.layEtcOrder.Reset();
            this.layQueryLayout.Reset();
            this.laySaveLayout.Reset();

            return true;
        }

        private bool MergeToSaveLayout()
        {
            // 약부터 시작해서 차례로 넣는다.

            this.laySaveLayout.Reset();

            // 내복약오더
            foreach (DataRow dr in this.layDrugOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 주사오더
            foreach (DataRow dr in this.layJusaOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 검체검사오더
            foreach (DataRow dr in this.layCplOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 생리검사오더
            foreach (DataRow dr in this.layPfeOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 병리검사오더
            foreach (DataRow dr in this.layAplOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 방사선 오더
            foreach (DataRow dr in this.layXrtOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 처치오더
            foreach (DataRow dr in this.layChuchiOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 수술오더
            foreach (DataRow dr in this.laySusulOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // リハビリオーダ追加 2012/09/26
            foreach (DataRow dr in this.layRehaOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 기타오더
            foreach (DataRow dr in this.layEtcOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            return true;
        }

        private bool SplitToEachLayout(MultiLayout aQueryLayout)
        {
            // 각각의 레이아웃 Reset
            this.layDrugOrder.Reset(); // 약
            this.layJusaOrder.Reset(); // 주사


            foreach (DataRow dr in aQueryLayout.LayoutTable.Rows)
            {
                // 내복약인경우
                switch (dr["input_tab"].ToString())
                {
                    case "01":  // 약인경우

                        this.layDrugOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "03": // 주사

                        this.layJusaOrder.LayoutTable.ImportRow(dr);

                        break;
                }
            }

            return true;
        }

        private bool OrderValidationCheck()
        {
            int dupRow = -1;
            string inputid = "";
            //string hangmog_code = "";
            //string hangmog_name = "";
            //string hope_date = "";
            string errMsg = "";

            // 권한체크 
            if (this.mDoctorLogin)
            {
                inputid = UserInfo.DoctorID;
            }
            else
            {
                inputid = UserInfo.UserID;
            }

            #region [終了された傷病に必ず事由をいれる事をチェック]
            XEditGrid CurrGRD = this.grdOutSang;
            for (int i = 0; i < CurrGRD.RowCount; i++)
            {
                if (CurrGRD.GetItemString(i, "sang_end_date") != "" && CurrGRD.GetItemString(i, "sang_end_sayu") == "")
                {
                    XMessageBox.Show(Resources.MSG019_MSG, Resources.MSG001_CAP, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.grdOutSang.SetFocusToItem(i, "sang_end_sayu");
                    return false;
                }
            }
            #endregion

            int UnchangedCNT = 0;

            for (int i = 0; i < this.laySaveLayout.RowCount; i++)
            {
                if (this.laySaveLayout.LayoutTable.Rows[i].RowState != DataRowState.Unchanged)
                {
                    UnchangedCNT++;
                }
                // Interface 대상이면서 Key 가 없으면 
                // 여기서 키를 딴다.
                if (this.mInterface.IsInterfaceHangmog(false, "O", this.laySaveLayout.LayoutTable.Rows[i]) && this.laySaveLayout.GetItemString(i, "pkocskey") == "")
                {
                    this.laySaveLayout.SetItemValue(i, "pkocskey", this.mOrderFunc.GetOrderKey(OrderVariables.OrderMode.OutOrder));
                }

                // 承認したオーダーを代行者が修正できなくする。
                if (this.mInputGubun == "CK"
                    && this.laySaveLayout.GetItemString(i, "pkocskey") != ""
                    && this.laySaveLayout.LayoutTable.Rows[i].RowState != DataRowState.Unchanged)
                {
                    string PostApproveYN = TypeCheck.NVL(this.laySaveLayout.GetItemString(i, "postapprove_yn"), "N").ToString();

                    PostApproveYN = PostApproveYN == "Y" ? "D0" : this.mInputGubun;

                    //if (!this.mOrderBiz.IsPossibleInsteadOrder(this.laySaveLayout.GetItemString(i, "pkocskey"), this.laySaveLayout.GetItemString(i, "input_gubun"), this.IO_Gubun))
                    if (!this.mOrderBiz.IsPossibleInsteadOrder(this.laySaveLayout.GetItemString(i, "pkocskey"), PostApproveYN, this.IO_Gubun))
                    {
                        XMessageBox.Show(Resources.MSG020_MSG, Resources.MSG001_CAP);
                        return false;
                    }
                }

                // 의뢰지 작성여부 체크 
                if (this.laySaveLayout.GetItemString(i, "specific_comment_not_null") == "Y" &&
                    this.laySaveLayout.GetItemString(i, "specific_comment") != "CM")
                {
                    if (this.mOrderBiz.IsSpeciFicCommentInputYn(this.laySaveLayout.GetItemString(i, "hangmog_code"), this.laySaveLayout.GetItemString(i, "pkocskey")))
                    {
                        this.mMsg = "▶ " + "[ " + this.laySaveLayout.GetItemString(i, "hangmog_code") + " ] " + this.laySaveLayout.GetItemString(i, "hangmog_name") + "\r\n"
                                  + "\n=================================================================\n"
                                  + XMsg.GetMsg("M003"); //반드시 의뢰지를 작성해야 하는 항목입니다. 의뢰지를 작성하십시오.
                        MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }

                // 원외처방인 경우는 비치일수 없음.
                if (this.laySaveLayout.GetItemString(i, "wonyoi_order_yn") == "Y" &&
                    this.laySaveLayout.GetItemString(i, "bichi_yn") == "Y")
                {
                    this.mMsg = "▶ " + "[ " + this.laySaveLayout.GetItemString(i, "hangmog_code") + " ] " + this.laySaveLayout.GetItemString(i, "hangmog_name") + "\r\n"
                                  + "\n=================================================================\n"
                                  + XMsg.GetMsg("M004"); //반드시 의뢰지를 작성해야 하는 항목입니다. 의뢰지를 작성하십시오.

                    MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

                // 환자상태에 따른 금지
                if (this.mOrderBiz.CheckPatientStatus(this.laySaveLayout.GetItemString(i, "bunho"), this.laySaveLayout.GetItemString(i, "hangmog_code"), this.laySaveLayout.GetItemString(i, "hangmog_name")) == true)
                {
                    return false;
                }

                // 처치 부위 체크 
                if (this.laySaveLayout.GetItemString(i, "input_control") == "A" && this.laySaveLayout.GetItemString(i, "bogyong_code") == "")
                {
                    this.mMsg = "▶ " + "[ " + this.laySaveLayout.GetItemString(i, "hangmog_code") + " ] " + this.laySaveLayout.GetItemString(i, "hangmog_name") + "\r\n"
                                  + "\n=================================================================\n"
                                  + XMsg.GetMsg("M007"); //반드시 의뢰지를 작성해야 하는 항목입니다. 의뢰지를 작성하십시오.

                    MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

                //if (i != 0)
                //{
                //    string cmd = " SELECT FN_CPL_LOAD_DUP_GRD_HANGMOG('" + this.laySaveLayout.GetItemString(i, "hangmog_code") + "', '"
                //               + this.laySaveLayout.GetItemString(i, "specimen_code") + "', '"
                //               + this.laySaveLayout.GetItemString(i - 1, "hangmog_code") + "', '"
                //               + this.laySaveLayout.GetItemString(i - 1, "specimen_code") + "') "
                //               + "   FROM DUAL ";

                //    object check = Service.ExecuteScalar(cmd);

                //    if (TypeCheck.IsNull(check) == false)
                //    {
                //        if (check.ToString() != "0")
                //        {
                //            this.mMsg = check.ToString() + "\n" + "===================================================\n" +
                //                        "このまま保存しますか?";

                //            if (MessageBox.Show(this.mMsg, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                //            {
                //                return false;
                //            }
                //        }
                //    }


                //}

                //hangmog_code = this.laySaveLayout.GetItemString(i, "hangmog_code");
                //hangmog_name = this.laySaveLayout.GetItemString(i, "hangmog_name");
                //hope_date = TypeCheck.NVL(this.laySaveLayout.GetItemString(i, "hope_date"), this.dtpNaewonDate.GetDataValue()).ToString();
                //for (int j = i + 1; j < this.laySaveLayout.RowCount; j++)
                //{
                //    if (hangmog_code == this.laySaveLayout.GetItemString(j, "hangmog_code") &&
                //        hope_date == TypeCheck.NVL(this.laySaveLayout.GetItemString(j, "hope_date"), this.dtpNaewonDate.GetDataValue()).ToString())
                //    {
                //        string message = "<   項目コード   " + hangmog_code + "   " + "案内" + "  >" + "\r\n\r\n\r\n" +
                //                        "[ " + hangmog_name + " ]" + "\r\n\r\n\r\n" +
                //                        " " + "当日 重複オーダ です";

                //        this.mMsg = message + "\n" + "===================================================\n" +
                //                        "このまま保存しますか?";

                //        if (MessageBox.Show(this.mMsg, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                //        {
                //            return false;
                //        }
                //    }
                //}


            }

            #region [処置で処置結果が入力されてないと見なされるオーダーチェック]
            /*
                             * 液体酸素・可搬式液化酸素容器（ＬＧＣ）
                             * 人工呼吸
                             * 人工呼吸（鼻マスク式人工呼吸器）
                             * 呼吸心拍監視
                             */
            bool finish_chuci = true;
            //            string cmd_chuchi = @" SELECT A.CODE, A.GROUP_KEY
            //                                     FROM OCS0132 A
            //                                    WHERE A.HOSP_CODE = :f_hosp_code
            //                                      AND A.CODE_TYPE = 'MARUME_ORDER'
            //                                      AND A.VALUE_POINT = '2'
            //                                    ";
            //            BindVarCollection bind_chuci = new BindVarCollection();
            //            bind_chuci.Add("f_hosp_code", EnvironInfo.HospCode);

            //            DataTable dt = Service.ExecuteDataTable(cmd_chuchi, bind_chuci);

            DataTable dt = null;

            // Connet to cloud service
            OcsoOCS1003P01GetChuciArgs vOcsoOCS1003P01GetChuciArgs = new OcsoOCS1003P01GetChuciArgs();
            vOcsoOCS1003P01GetChuciArgs.CodeType = "MARUME_ORDER";
            vOcsoOCS1003P01GetChuciArgs.ValuePoint = "2";
            OcsoOCS1003P01GetChuciResult chuciResult = CloudService.Instance.Submit<OcsoOCS1003P01GetChuciResult, OcsoOCS1003P01GetChuciArgs>(vOcsoOCS1003P01GetChuciArgs);

            if (chuciResult != null && chuciResult.ExecutionStatus == ExecutionStatus.Success)
            {
                dt = Utility.ConvertToDataTable(chuciResult.ChuciItem);
            }
            // End connect to cloud
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < this.laySaveLayout.RowCount; i++)
                    {
                        if (dr["code"].ToString() == this.laySaveLayout.GetItemString(i, "hangmog_code")
                            && this.laySaveLayout.GetItemString(i, "jundal_table") == "HOM")
                        {
                            switch (dr["group_key"].ToString())
                            {
                                case "OK":// 数量(分あたり注入量(ℓ)), 日数(注入分)
                                    if (this.laySaveLayout.GetItemString(i, "nalsu") == "1")
                                        finish_chuci = false;
                                    break;

                                case "AH":// 数量(時間), 日数(分)
                                    if (this.laySaveLayout.GetItemString(i, "suryang") == "0"
                                        && this.laySaveLayout.GetItemString(i, "nalsu") == "1")
                                        finish_chuci = false;
                                    break;

                                case "MN":// 数量(分), 日数(固定)
                                    if (this.laySaveLayout.GetItemString(i, "suryang") == "1")
                                        finish_chuci = false;
                                    break;
                            }

                            DialogResult result = new DialogResult();
                            if (!finish_chuci)
                            {
                                result = XMessageBox.Show(this.laySaveLayout.GetItemString(i, "hangmog_name") + Resources.MSG021_MSG, Resources.MSG001_CAP, MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button1);

                                if (result != DialogResult.No)
                                    return false;
                                else
                                    return true;
                            }
                        }
                    }
                }
            }
            #endregion [処置で処置結果が入力されてないと見なされるオーダーチェック]

            // 同一グループ内頓服回数チェック
            ArrayList arrGroupSerList = new ArrayList();
            for (int i = 0; i < this.laySaveLayout.RowCount; i++)
            {
                if (this.laySaveLayout.GetItemString(i, "input_tab") == "01"
                    && this.laySaveLayout.GetItemString(i, "donbog_yn") == "Y")
                {
                    if (!arrGroupSerList.Contains(this.laySaveLayout.GetItemString(i, "group_ser")))
                        arrGroupSerList.Add(this.laySaveLayout.GetItemString(i, "group_ser"));
                }
            }

            for (int i = 0; i < arrGroupSerList.Count; i++)
            {
                DataRow[] dr = this.laySaveLayout.LayoutTable.Select("group_ser = '" + arrGroupSerList[i].ToString() + "'");

                string dv1th = dr[0]["dv"].ToString();
                string group_ser1th = dr[0]["group_ser"].ToString();
                for (int j = 0; j < dr.Length; j++)
                {
                    if (group_ser1th == dr[j]["group_ser"].ToString()
                        && dv1th != dr[j]["dv"].ToString())
                    {
                        XMessageBox.Show("[" + dr[j]["group_ser"].ToString() + Resources.MSG022_MSG, Resources.MSG001_CAP);
                        return false;
                    }
                }
            }

            if (UnchangedCNT > 0 && UserInfo.Gwa == "CK")
            {
                string isInstead = "";
                isInstead = this.mOrderBiz.isAbleInsteadOrder(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                            , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                                            , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString());

                if (isInstead != "")
                {
                    XMessageBox.Show(isInstead, Resources.MSG001_CAP, MessageBoxIcon.Stop);
                    return false;
                }
            }

            // 중복처방체크 
            if (this.mOrderBiz.IsProtecedDupInputOutOrder(this.laySaveLayout, this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                         , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                                         , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                                         , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                                         , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                                                         , this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
                                                         , ref dupRow) == true)
            {
                return false;
            }

            // 원내원외 체크 
            if (this.mOrderBiz.CheckExistWonnaeWonyoiDrg(this.laySaveLayout.LayoutTable, ref errMsg) == true)
            {
                this.mMsg = errMsg + XMsg.GetMsg("M008");
                this.mCap = XMsg.GetField("F001");

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private void SetInputGubunColor(string aInputGubun)
        {
            this.ClearInputGubunColor();

            //foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabInputGubun.TabPages)
            //{
            //    if (this.mDoctorLogin)
            //    {
            //        if (tpg.Tag.ToString() == aInputGubun)
            //        {
            //            tpg.TitleTextColor = this.mExistInputGubunColor.Color;
            //        }
            //    }
            //    else
            //    {
            //        if (tpg.Tag.ToString() == "D%")
            //        {
            //            if (tpg.Tag.ToString().Substring(0, 1) == aInputGubun.Substring(0, 1))
            //                tpg.TitleTextColor = this.mExistInputGubunColor.Color;
            //        }
            //        else
            //        {
            //            if (tpg.Tag.ToString() == aInputGubun)
            //                tpg.TitleTextColor = this.mExistInputGubunColor.Color;
            //        }
            //    }
            //}

            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabInputGubun.TabPages)
            {
                if (this.mDoctorLogin)
                {
                    if (tpg.Tag.ToString() == aInputGubun)
                    {
                        tpg.TitleTextColor = this.mExistInputGubunColor.Color;
                    }
                }
                else
                {
                    if (aInputGubun == tpg.Tag.ToString() ||
                        aInputGubun.Substring(0, 1) == "D")
                    //if (tpg.Tag.ToString() == "D%")
                    {
                        //if  (tpg.Tag.ToString().Substring(0, 1) == aInputGubun.Substring(0, 1))
                        //    tpg.TitleTextColor = this.mExistInputGubunColor.Color;
                        tpg.TitleTextColor = this.mExistInputGubunColor.Color;
                    }
                    //else
                    //{
                    //    if (tpg.Tag.ToString() == aInputGubun)
                    //        tpg.TitleTextColor = this.mExistInputGubunColor.Color;
                    //}
                }
            }
        }

        #endregion

        #region [ 공통의 선택시 로직들 ]

        /// <summary>
        /// Process Common Doctor
        /// </summary>
        /// <param name="aPkNaewonKey"></param>
        private void ProcessCommonDoctor(string aPkNaewonKey)
        {
            //            if (IsCommonDoctorJubsu(aPkNaewonKey) == true)
            //            {
            //                // 공통의 환자를 선택하는 순간 
            //                // 해당 환자는 선택한 의사의 환자가 된다.
            //                string cmd = @"UPDATE OUT1001 A
            //                                  SET A.DOCTOR    = :f_doctor
            //                                     , A.GWA      = :f_gwa
            //                                WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
            //                                  AND A.PKOUT1001 = :f_pk_naewon";

            //                BindVarCollection bindVar = new BindVarCollection();

            //                if (this.mDoctorLogin)
            //                {
            //                    bindVar.Add("f_doctor", UserInfo.DoctorID);
            //                    bindVar.Add("f_gwa", UserInfo.Gwa);
            //                }
            //                else
            //                {
            //                    bindVar.Add("f_doctor", this.cboQryDoctor.GetDataValue());
            //                    bindVar.Add("f_gwa", this.cboQryGwa.GetDataValue());
            //                }
            //                bindVar.Add("f_pk_naewon", aPkNaewonKey);

            //                Service.ExecuteNonQuery(cmd, bindVar);
            //            }

            // Connect To cloud: update doctor
            string doctor = "";
            string gwa = "";
            if (this.mDoctorLogin)
            {
                doctor = UserInfo.DoctorID;
                gwa = UserInfo.Gwa;
            }
            else
            {
                doctor = this.cboQryDoctor.GetDataValue();
                gwa = this.cboQryGwa.GetDataValue();
            }
            ProcessUpdateDoctor(doctor, gwa, aPkNaewonKey);
        }

        /// <summary>
        /// Check Is Common Doctor Jubsu
        /// </summary>
        /// <param name="aPkNaewonKey"></param>
        /// <returns></returns>
        private bool IsCommonDoctorJubsu(string aPkNaewonKey)
        {
            //            string cmd = @"SELECT 'Y'
            //                             FROM DUAL
            //                            WHERE EXISTS ( SELECT 'X'
            //                                             FROM OUT1001 A
            //                                                  , BAS0270 B
            //                                            WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
            //                                              AND A.PKOUT1001 = :f_naewon_key
            //                                              AND B.HOSP_CODE = A.HOSP_CODE
            //                                              AND B.DOCTOR = A.DOCTOR
            //                                              AND B.DOCTOR_GWA = A.GWA
            //                                              AND A.NAEWON_DATE BETWEEN B.START_DATE
            //                                                                    AND NVL(B.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))
            //                                              AND NVL(B.COMMON_DOCTOR_YN, 'N') = 'Y')";

            //            BindVarCollection bindVar = new BindVarCollection();
            //            bindVar.Add("f_naewon_key", aPkNaewonKey);

            //            object val = Service.ExecuteScalar(cmd, bindVar);

            // Connect cloud
            OcsoOCS1003P01CheckYArgs checkYArgs = new OcsoOCS1003P01CheckYArgs();
            checkYArgs.NaewonKey = aPkNaewonKey;
            OcsoOCS1003P01CheckYResult val = CloudService.Instance.Submit<OcsoOCS1003P01CheckYResult, OcsoOCS1003P01CheckYArgs>(checkYArgs);

            if (TypeCheck.IsNull(val) == false && "Y".Equals(val.NaewonKeyValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsSameNameCHK()
        {
            if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "SAME_NAME_CHECK_YN", this.IO_Gubun) == "N")
                return false;

            //            string cmd = @"SELECT FN_ADM_IS_SAME_NAME_YN(:f_hosp_code, 
            //                                                         :f_naewon_date, 
            //                                                         :f_gwa, 
            //                                                         :f_naewon_yn, 
            //                                                         :f_reser_yn, 
            //                                                         :f_doctor_mode_yn, 
            //                                                         :f_doctor, 
            //                                                         :f_suname,
            //                                                         :f_bunho) 
            //                             FROM SYS.DUAL";

            // TODO comment: user connect cloud
            //            string cmd = @"SELECT FN_ADM_IS_SAME_NAME_YN_T(
            //                                                         :f_naewon_date, 
            //                                                         :f_gwa, 
            //                                                         :f_naewon_yn, 
            //                                                         :f_reser_yn, 
            //                                                         :f_doctor_mode_yn, 
            //                                                         :f_doctor, 
            //                                                         :f_bunho) 
            //                             FROM SYS.DUAL";

            //            BindVarCollection bindVar = new BindVarCollection();

            //            bindVar.Add("f_naewon_date", this.dtpNaewonDate.GetDataValue());
            //            bindVar.Add("f_gwa", this.cboQryGwa.GetDataValue());
            //            bindVar.Add("f_doctor", TypeCheck.NVL(this.cboQryDoctor.GetDataValue(), "%").ToString());
            //            bindVar.Add("f_bunho", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho"));
            //            bindVar.Add("f_reser_yn", "%");
            //            bindVar.Add("f_naewon_yn", "%");

            //            if (this.mDoctorLogin)
            //                bindVar.Add("f_doctor_mode_yn", "Y");
            //            else
            //                bindVar.Add("f_doctor_mode_yn", "N");

            //            object val = Service.ExecuteScalar(cmd, bindVar);
            //            if (TypeCheck.IsNull(val) == false && val.ToString() == "Y")
            //            {
            //                return true;
            //            }
            //            else
            //            {
            //                return false;
            //            }
            // End Comment

            // Connect to cloud service
            OcsoOCS1003P01CheckIsSameNameYnArgs vOcsoOCS1003P01CheckIsSameNameYnArgs = new OcsoOCS1003P01CheckIsSameNameYnArgs();
            vOcsoOCS1003P01CheckIsSameNameYnArgs.NaewonDate = this.dtpNaewonDate.GetDataValue();
            vOcsoOCS1003P01CheckIsSameNameYnArgs.Gwa = this.cboQryGwa.GetDataValue();
            vOcsoOCS1003P01CheckIsSameNameYnArgs.NaewonYn = "%";
            vOcsoOCS1003P01CheckIsSameNameYnArgs.ReserYn = "%";
            vOcsoOCS1003P01CheckIsSameNameYnArgs.Doctor = TypeCheck.NVL(this.cboQryDoctor.GetDataValue(), "%").ToString();
            vOcsoOCS1003P01CheckIsSameNameYnArgs.Bunho = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho");
            if (this.mDoctorLogin)
                vOcsoOCS1003P01CheckIsSameNameYnArgs.DoctorModeYn = "Y";
            else
                vOcsoOCS1003P01CheckIsSameNameYnArgs.DoctorModeYn = "N";
            OcsoOCS1003P01CheckIsSameNameYnResult result = CloudService.Instance.Submit<OcsoOCS1003P01CheckIsSameNameYnResult, OcsoOCS1003P01CheckIsSameNameYnArgs>(vOcsoOCS1003P01CheckIsSameNameYnArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success && result.ValueCheck == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 조사록 자동출력

        private void PrintXRTJosa(DataRow aRow)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("doctor", aRow["doctor"].ToString());
            param.Add("bunho", aRow["bunho"].ToString());
            param.Add("order_date", aRow["order_date"].ToString());
            param.Add("pkocskey", aRow["pkocskey"].ToString());
            param.Add("in_out_gubun", "O");
            param.Add("hangmog_code", aRow["hangmog_code"].ToString());
            param.Add("isReadOnly", "Y");
            param.Add("print_only", "Y");
            param.Add("jundal_part", aRow["jundal_part"].ToString());
            param.Add("naewon_key", aRow["in_out_key"].ToString());

            XScreen.OpenScreenWithParam(this, "XRTS", "XRT1002U00", ScreenOpenStyle.ResponseFixed, param);
        }

        #endregion

        #region リハビリ依頼書自動出力

        private void PrintRehaIraisyo(DataRow aRow)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aRow["bunho"].ToString());
            openParams.Add("order_date", aRow["order_date"].ToString());
            openParams.Add("pkocskey", aRow["pkocskey"].ToString());
            openParams.Add("in_out_gubun", this.IO_Gubun);
            openParams.Add("hangmog_code", aRow["hangmog_code"].ToString());
            openParams.Add("gwa", aRow["gwa"].ToString());
            openParams.Add("doctor", aRow["doctor"].ToString());
            openParams.Add("jundal_part", aRow["jundal_part"].ToString());
            openParams.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            openParams.Add("AutoCloseYN", "Y");

            if (aRow["specific_comment"].ToString() == "18")
                XScreen.OpenScreenWithParam(this, "PHYS", "PHY8002U00", ScreenOpenStyle.ResponseFixed, openParams);
            else
                XScreen.OpenScreenWithParam(this, "PHYS", "PHY8002U01", ScreenOpenStyle.ResponseFixed, openParams);
        }

        #endregion

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        #region [ 다른 화면 오픈 ]

        private void OpenScreen_OUT0101Q01()
        {
            CommonItemCollection param = new CommonItemCollection();

            XScreen.OpenScreenWithParam(this, "NURO", "OUT0101Q01", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 내복약 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U10(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layDrugOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("isOpenPopUp", openPopup);
            param.Add("protocol_id", this.mProtocolID);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("dt_grdoutsang", grdOutSang.LayoutTable);
            param.Add("injection_dt", this.layJusaOrder.LayoutTable);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U10", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U10(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layDrugOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("isOpenPopUp", openPopup);
            param.Add("protocol_id", this.mProtocolID);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("dt_grdoutsang", grdOutSang.LayoutTable);
            param.Add("injection_dt", this.layJusaOrder.LayoutTable);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U10", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U10(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName, int aStartRowNum)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            //if (this.mDoctorLogin)
            //    param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            //else if (this.mInputGubun == "CK" && this.mPostApproveYN)
            //    param.Add("input_gubun", "D0");
            //else
            //    param.Add("input_gubun", this.mInputGubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layDrugOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("in_do_data_row", this.layDrugOrder_Do);
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("isOpenPopUp", true);
            param.Add("injection_dt", this.layJusaOrder.LayoutTable);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("dt_grdoutsang", grdOutSang.LayoutTable);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U10", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// リハビリオーダ登録画面オープン
        /// リハビリオーダ追加 2012/09/26
        /// </summary>
        private void OpenScreen_OCS0103U11(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layRehaOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("isOpenPopUp", openPopup);
            param.Add("protocol_id", this.mProtocolID);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U11", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U11(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layRehaOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("isOpenPopUp", openPopup);
            param.Add("protocol_id", this.mProtocolID);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U11", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U11(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName, int aStartRowNum)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layRehaOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("in_do_data_row", this.layRehaOrder_Do);
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("isOpenPopUp", true);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U11", ScreenOpenStyle.ResponseFixed, param);
        }
        /// <summary>
        /// 주사약 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U12(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layJusaOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("isOpenPopUp", openPopup);
            param.Add("drug_dt", this.layDrugOrder.LayoutTable);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("dt_grdoutsang", grdOutSang.LayoutTable);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U12", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_OCS0103U12(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layJusaOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("isOpenPopUp", openPopup);
            param.Add("drug_dt", this.layDrugOrder.LayoutTable);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("dt_grdoutsang", grdOutSang.LayoutTable);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U12", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_OCS0103U12(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName, int aStartRowNum)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layJusaOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("isOpenPopUp", true);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("dt_grdoutsang", grdOutSang.LayoutTable);
            param.Add("drug_dt", this.layDrugOrder.LayoutTable);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U12", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 검체검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U13(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layCplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("open_popup", openPopup);
            param.Add("protocol_id", this.mProtocolID);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U13", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U13(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (this.mDoctorLogin)
                param.Add("input_gubun", aInputGubun);
            else
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", "CK");
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layCplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("open_popup", openPopup);
            param.Add("protocol_id", this.mProtocolID);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U13", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U13(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName, int aStartRowNum)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layCplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);

            //insert by jc
            param.Add("in_do_data_row", this.layCplOrder_Do);
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("open_popup", true);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U13", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 생리검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U14(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layPfeOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("isOpenPopUp", openPopup);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U14", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U14(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layPfeOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("isOpenPopUp", openPopup);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U14", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U14(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName, int aStartRowNum)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layPfeOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("in_do_data_row", this.layPfeOrder_Do);
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("isOpenPopUp", true);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U14", ScreenOpenStyle.ResponseFixed, param);
        }
        /// <summary>
        /// 병리검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U15(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layAplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("isOpenPopUp", openPopup);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U15", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U15(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layAplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("isOpenPopUp", openPopup);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U15", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U15(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName, int aStartRowNum)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layAplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("in_do_data_row", this.layAplOrder_Do);
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("isOpenPopUp", true);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U15", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 방사선오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U16(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layXrtOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("protocol_id", this.mProtocolID);
            param.Add("isOpenPopUp", openPopup);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U16", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U16(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layXrtOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("protocol_id", this.mProtocolID);
            param.Add("isOpenPopUp", openPopup);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U16", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U16(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName, int aStartRowNum)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layXrtOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("protocol_id", this.mProtocolID);
            param.Add("isOpenPopUp", true);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U16", ScreenOpenStyle.ResponseFixed, param);
        }
        /// <summary>
        /// 처치오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U17(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layChuchiOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("isOpenPopUp", openPopup);
            param.Add("protocol_id", this.mProtocolID);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U17", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U17(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layChuchiOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);

            param.Add("isOpenPopUp", openPopup);
            param.Add("protocol_id", this.mProtocolID);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U17", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U17(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName, int aStartRowNum)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layChuchiOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by Cloud
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("isOpenPopUp", true);
            param.Add("protocol_id", this.mProtocolID);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U17", ScreenOpenStyle.ResponseFixed, param);
        }
        /// <summary>
        /// 수술오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U18(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.laySusulOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("isOpenPopUp", openPopup);
            param.Add("protocol_id", this.mProtocolID);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U18", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U18(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.laySusulOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("isOpenPopUp", openPopup);
            param.Add("protocol_id", this.mProtocolID);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U18", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U18(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName, int aStartRowNum)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.laySusulOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("isOpenPopUp", true);
            param.Add("protocol_id", this.mProtocolID);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U18", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 기타오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U19(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layEtcOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("protocol_id", this.mProtocolID);
            param.Add("isOpenPopUp", openPopup);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U19", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U19(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layEtcOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("protocol_id", this.mProtocolID);
            param.Add("isOpenPopUp", openPopup);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U19", ScreenOpenStyle.ResponseFixed, param);
        }
        private void OpenScreen_OCS0103U19(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName, int aStartRowNum)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layEtcOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("protocol_id", this.mProtocolID);
            param.Add("isOpenPopUp", true);
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U19", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 사용자별 상병입력 
        /// </summary>
        /// <param name="aMemb">사용자</param>
        private void OpenScreen_OCS0204Q00(string aMemb)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("sang_code", "");
            if (this.mDoctorLogin)
            {
                openParams.Add("memb", UserInfo.DoctorID);
            }
            else
            {
                openParams.Add("memb", UserInfo.UserID);
            }
            openParams.Add("gwa", this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());
            openParams.Add("doctor", this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0204Q00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        /// <summary>
        /// 수식어 입력창 오픈
        /// </summary>
        /// <param name="aRowNumber">현재 상병 그리드의 로우번호</param>
        private void OpenScreen_CHT0115Q00(int aRowNumber)
        {
            MultiLayout laySusikInfo = new MultiLayout();
            laySusikInfo.LayoutItems.Add("sang_name", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier1", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier2", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier3", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier4", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier5", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier6", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier7", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier8", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier9", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier10", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier_name", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier1", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier2", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier3", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier4", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier5", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier6", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier7", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier8", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier9", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier10", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier_name", DataType.String);
            laySusikInfo.InitializeLayoutTable();

            int insertRow = laySusikInfo.InsertRow(-1);

            foreach (XEditGridCell cell in this.grdOutSang.CellInfos)
            {
                if (laySusikInfo.LayoutItems.Contains(cell.CellName))
                    laySusikInfo.SetItemValue(insertRow, cell.CellName, grdOutSang.GetItemValue(aRowNumber, cell.CellName));
            }

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("SANGINFO", laySusikInfo);
            openParams.Add("user_id", UserInfo.UserID);
            openParams.Add("io_gubun", this.IO_Gubun);
            //서식지처방 조회 화면 Open
            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0115Q00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        // 환자별 상병 입력창 오픈
        private void OpenScreen_OUTSANGU00(string aIOGubun, string aBunho, string aGwa, string aNaewonDate)
        {
            if (aBunho != "")
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("io_gubun", aIOGubun);
                openParams.Add("bunho", aBunho);
                openParams.Add("gwa", aGwa);
                openParams.Add("naewon_date", aNaewonDate);

                XScreen.OpenScreenWithParam(this, "OCSO", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
            }
            else
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("io_gubun", aIOGubun);
                openParams.Add("bunho", aBunho);
                openParams.Add("naewon_date", aNaewonDate);
                XScreen.OpenScreenWithParam(this, "OCSO", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
            }
        }

        private void OpenScreen_CHT0110Q00(string aSangINX, bool aIsMultiSelect, string aDate)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("sang_inx", aSangINX);
            param.Add("multiSelect", "True");
            param.Add("date", aDate);
            param.Add("io_gubun", IO_Gubun);
            param.Add("user_id", UserInfo.UserID);

            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_INP1003U01(string aBunho, string aReserDate, string aGwa, string aDoctor, string aNaewonType, string aJubsuNo, string aFkout1001)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", aBunho);

            if (int.Parse(aReserDate.ToString().Replace("/", "")) < int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
            {
                openParams.Add("reser_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            }
            else
            {
                openParams.Add("reser_date", aReserDate.Replace("-", "/"));
            }

            openParams.Add("gwa", aGwa);
            openParams.Add("doctor", aDoctor);
            openParams.Add("naewon_type", aNaewonType);
            openParams.Add("jubsu_no", aJubsuNo);
            openParams.Add("fkout1001", aFkout1001);

            XScreen.OpenScreenWithParam(this, "INPS", "INP1003U01", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS2003P01(string aBunho, string aReserDate, string aPkinp1001)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", aBunho);
            openParams.Add("naewon_key", aPkinp1001);
            if (aReserDate != null) openParams.Add("order_date", aReserDate);

            // 입원오더 메인
            XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003P01", ScreenOpenStyle.ResponseSizable, ScreenAlignment.ParentTopLeft, openParams);
        }

        //modify by jc
        private void OpenScreen_OCS0503U00(string aBbunho, string aReqDate, string aReqGwa, string aReqDoctor, string aNaewon_key)
        //private void OpenScreen_OCS0503U00(string aBbunho, string aReqDate, string aReqGwa, string aReqDoctor)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBbunho);
            openParams.Add("req_date", aReqDate);
            openParams.Add("req_gwa", aReqGwa);
            openParams.Add("req_doctor", aReqDoctor);
            //insert by jc
            openParams.Add("naewon_key", aNaewon_key);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0503U00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS0503U01(string aBunho, string aReqDate, string aConsultGwa, string aConsultDoctor)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBunho);
            openParams.Add("req_date", aReqDate);
            openParams.Add("consult_gwa", aConsultGwa);
            openParams.Add("consult_doctor", aConsultDoctor);
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0503U01", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS1003R00(string aBunho, string aNaewonDate, string aGwa, string aDoctor, string aNaewonType, string aJubsuNo, string aJubsukey, bool aAutoClose, bool abacode_flg)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", aBunho);
            openParams.Add("naewon_date", aNaewonDate);
            openParams.Add("gwa", aGwa);
            openParams.Add("doctor", aDoctor);
            openParams.Add("naewon_type", aNaewonType);
            openParams.Add("jubsu_no", aJubsuNo);
            //openParams.Add("input_gubun", mInputGubun);
            openParams.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            openParams.Add("auto_close", aAutoClose); // 출력후 닫기
            openParams.Add("jubsu_key", aJubsukey);
            openParams.Add("bacode_flg", abacode_flg);


            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003R00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS1003R00(string aBunho, string aNaewonDate, string aGwa, string aDoctor, string aNaewonType, string aJubsuNo, string aJubsukey, bool aAutoClose)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", aBunho);
            openParams.Add("naewon_date", aNaewonDate);
            openParams.Add("gwa", aGwa);
            openParams.Add("doctor", aDoctor);
            openParams.Add("naewon_type", aNaewonType);
            openParams.Add("jubsu_no", aJubsuNo);
            //openParams.Add("input_gubun", mInputGubun);
            openParams.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            openParams.Add("auto_close", aAutoClose); // 출력후 닫기
            openParams.Add("jubsu_key", aJubsukey);



            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003R00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS1003R02(string aBunho, string aNaewonDate, string aGwa, string aDoctor, string aNaewonType, string aJubsuNo, string aNaewonKey, bool aAutoClose)
        {
            try
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", aBunho);
                openParams.Add("naewon_date", aNaewonDate);
                openParams.Add("gwa", aGwa);
                openParams.Add("doctor", aDoctor);
                openParams.Add("naewon_type", aNaewonType);
                openParams.Add("jubsu_no", aJubsuNo);
                openParams.Add("input_gubun", mInputGubun);
                openParams.Add("auto_close", aAutoClose); // 출력후 닫기
                openParams.Add("pk_naewon", aNaewonKey);

                XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003R02", ScreenOpenStyle.ResponseSizable, openParams);
            }
            catch { }
        }

        private void OpenScreen_OCS1003U01(string aBunho, string aNaewonDate, string aGwa, string aDoctor, string aNaewonType, string aInputGubun)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBunho);
            openParams.Add("naewon_date", aNaewonDate);
            openParams.Add("gwa", aGwa);
            openParams.Add("doctor", aDoctor);
            openParams.Add("naewon_type", aNaewonType);
            openParams.Add("input_gubun", aInputGubun);

            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003U01", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void OpenScreen_OUT0123U00(string aBunho, string aGwa, string aDoctor, string aNaewonKey)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBunho);
            openParams.Add("req_gwa", aGwa);
            openParams.Add("req_doctor", aDoctor);
            openParams.Add("pkout1001", aNaewonKey);

            XScreen.OpenScreenWithParam(this, "OUTS", "OUT0123U00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void OpenScreen_NUR1001R98(string aBunho)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBunho);
            openParams.Add("auto_close", "N");
            openParams.Add("reser_date", this.dtpNaewonDate.GetDataValue());

            XScreen.OpenScreenWithParam(this, "NURO", "NUR1001R98", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void OpenScreen_NUR1016U00(string aBunho)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "NURO", "NUR1016U00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void OpenScreen_OUT0106U00(string aBunho)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "OUTS", "OUT0106U00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_OCSAPPROVE(string aBunho)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBunho);
            openParams.Add("caller_sys_id", this.Name);
            openParams.Add("io_gubun", "O");
            openParams.Add("doctor_id", UserInfo.UserID);
            openParams.Add("fk_io_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            XScreen.OpenScreenWithParam(this, "OCSA", "OCSAPPROVE", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, openParams);
        }

        //modify bu jc CPL0000Q00 -> CPL0000Q01
        private void OpenScreen_CPL0000Q01(string aBunho)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", aBunho);
            openParams.Add("send_yn", "Y");
            openParams.Add("close_yn", "Y");

            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q01", ScreenOpenStyle.PopUpFixed, openParams);

            //CommonItemCollection openParam = new CommonItemCollection();

            //openParam.Add("bunho", aBunho);

            //XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, openParam);
        }

        private void OpenScreen_INJ0000Q00(string aBunho)
        {
            CommonItemCollection openParam = new CommonItemCollection();

            openParam.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "INJS", "INJ0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, openParam);
        }

        private void OpenScreen_OCS1003Q05(string aBunho, string aOrderDate)
        {
            //CommonItemCollection openParam = new CommonItemCollection();

            //openParam.Add("bunho", aBunho);
            //openParam.Add("order_date", aOrderDate);

            //XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q05", ScreenOpenStyle.ResponseFixed, openParam);

            // 처방 입력 가능 여부

            //해당 내원의 처방정보를 가져온다.
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            openParams.Add("gwa", mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());
            openParams.Add("doctor", mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

            openParams.Add("naewon_date", this.dtpNaewonDate.GetDataValue());
            if (this.mDoctorLogin)
                openParams.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            else
                openParams.Add("input_gubun", this.mInputGubun);

            openParams.Add("tel_yn", "%"); // 약만 타러온 환자건도 있다

            openParams.Add("auto_close", false);
            openParams.Add("input_tab", "%");
            openParams.Add("io_gubun", this.IO_Gubun);

            openParams.Add("childYN", "N");

            //전처방조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q05", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS1003Q02(string aBunho, string aNaewonDate, string aGwa, string aDoctor)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("naewon_date", aNaewonDate);
            param.Add("doctor", aDoctor);
            param.Add("gwa", aGwa);
            param.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q02", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_ScanViewer(string aBunho)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);

            //XScreen.OpenScreenWithParam(this, "CPLS", "SCANVIEWER", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, param);
            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, param);
        }

        private void OpenScreen_XRT0000Q00(string aBunho)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "XRTS", "XRT0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, param);
        }

        private void OpenScreen_NUR7001U00(string aBunho)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "NURI", "NUR7001U00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_RES1001U00(string aBunho, string aNaewonDate, string aGwa, string aDoctor)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);
            param.Add("naewon_date", aNaewonDate);

            param.Add("gwa", aGwa);
            param.Add("doctor", aDoctor);

            XScreen.OpenScreenWithParam(this, "NURO", "RES1001U00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_DRG2010R00()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("pkout1001", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            XScreen.OpenScreenWithParam(this, "DRGS", "DRG2010R00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_CPL2010R02(string aBunho, string aOrderDate, string aInOutGubun, string aGwa, string aDoctor, string aSpecimen_code, string aAutoPrintYN, string aHopeDate)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);
            param.Add("order_date", aOrderDate);
            param.Add("in_out_gubun", aInOutGubun);
            param.Add("gwa", aGwa);
            param.Add("doctor", aDoctor);
            param.Add("specimen_code", aSpecimen_code);
            param.Add("auto_print_yn", aAutoPrintYN);
            param.Add("hope_date", aHopeDate);

            XScreen.OpenScreenWithParam(this, "CPLS", "CPL2010R02", ScreenOpenStyle.ResponseFixed, param);
        }

        #endregion

        #region [ 각종 초기화 ]

        // 화면 초기화
        private void InitializeScreen(bool aIsCalledbyOpenning)
        {
            // 모드 설정 ( 의사가 로긴한건지, 의사가 아닌 다른사람들이 로긴한건지 판단 )
            //if (UserInfo.UserGubun == UserType.Doctor && 
            //    ( EnvironInfo.CurrSystemID  == "OCSO" || EnvironInfo.CurrSystemID == "OCSI") )
            //if (UserInfo.UserGubun == UserType.Doctor)
            //{
            //    this.mDoctorLogin = true;
            //}
            //else
            //{
            //    this.mDoctorLogin = false;
            //}

            // 유저의 구분에 따라 보이거나 사라져야 할 로직들...
            this.SettingVisiblebyUser();


            // 다른 화면에서 오픈된경우
            if (this.OpenParam != null)
            {
                mIsCalledbyOtherScreen = true;
                // 내원 일자 
                if (this.OpenParam.Contains("naewon_date"))
                {
                    this.dtpNaewonDate.SetDataValue(this.OpenParam["naewon_date"].ToString());
                }
                else
                {
                    this.dtpNaewonDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
                }

                // 환자번호
                if (this.OpenParam.Contains("bunho"))
                {
                    this.mParamBunho = this.OpenParam["bunho"].ToString();
                    // 환자번호 셋팅후
                    //this.fbxBunho.SetEditValue(this.OpenParam["bunho"].ToString());
                    //this.fbxBunho.AcceptData();
                }

                // 내원 키
                if (this.OpenParam.Contains("naewon_key"))
                {
                    this.mParamNaewonKey = this.OpenParam["naewon_key"].ToString();
                }

                // 진료과
                if (this.OpenParam.Contains("gwa"))
                {
                    this.mParamGwa = this.OpenParam["gwa"].ToString();
                }

                // 진료의
                if (this.OpenParam.Contains("doctor"))
                {
                    this.mParamDoctor = this.OpenParam["doctor"].ToString();
                }

                // 프로텍트 해야지...파라미터로 담은거니깐...
                //this.dtpNaewonDate.Protect = true;
                //this.fbxBunho.Protect = true;
            }
            // 독자적 실행
            else
            {
                // 내원일자 디폴트는 오늘로
                this.dtpNaewonDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));

                this.InitializeBunho(aIsCalledbyOpenning);

                // 이건 여기서 이ㅣㅂ력받을 수 있으니깐 프로텍트 하면 안되요...
                this.dtpNaewonDate.Protect = false;
                this.fbxBunho.Protect = false;

            }
            // InputGubun 탭 구성
            this.MakeInputGubunTab();
            // 진료과 콤보 구성
            ReLoadGwaCombo(this.dtpNaewonDate.GetDataValue());

            // 주치의 콤보 구성
            ReLoadDoctorCombo(this.dtpNaewonDate.GetDataValue(), this.cboQryGwa.GetDataValue());



            // 내원자 리스트 조회
            PatientListQuery(this.dtpNaewonDate.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());

            



            // 혹시 다른 스크린에서 받아올수 있는지 판단.
            // 이전 스크린의 등록번호를 가져온다
            if (this.mParamBunho == "")
            {
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                {
                    // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                    patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                }

                if (patientInfo != null && !TypeCheck.IsNull(patientInfo.BunHo))
                {
                    this.mParamBunho = patientInfo.BunHo;
                }
            }

            // 다른화면에서 파라미터로 받던, 혹은 이전스크린에서 가져오던 
            // 환자번호를 받은경우는 적용한다.
            //if (this.mParamBunho != "")
            //{
            //    this.fbxBunho.Focus();
            //    this.fbxBunho.SetEditValue(this.mParamBunho);
            //    this.fbxBunho.AcceptData();
            //}
        }

        // 환자번호 초기화시 설정파일
        private void InitializeBunho(bool aIsCalledbyOpening)
        {
            ClearPatientInfoLabel();
            this.mSelectedPatientInfo.ClearPatientInfo();

            this.fbxBunho.SetDataValue("");
            //insert by jc
            this.cboOutSang.ComboItems.Clear();
            this.cboOutSang.RefreshComboItems();

            this.cboJinryoGwa.ComboItems.Clear();
            this.cboJinryoGwa.RefreshComboItems();

            this.paInfoBox.Reset();

            // 각종 YN 클리어 ( 껌뻑이는 컨트롤 )
            this.pbxIsNoAnwerOfConsulted.Visible = false;
            this.pbxExistBunhoComment.Visible = false;
            this.pbxInpReserYN.Visible = false;
            this.pbxEtcJinryo.Visible = false;
            this.pbxVital.Visible = false;
            this.pbxJinryoComment.Visible = false;
            this.pbxExistAllergy.Visible = false;
            this.pbxIsNoConfirmOfReturnedConsult.Visible = false;

            // 코맨트 창 visible flase 
            //this.pnlComment.Visible = false;

            this.InitializeOrderInfo();

            if (aIsCalledbyOpening == false)
            {
                this.mParamNaewonKey = "";
            }

            XRadioButton inputtab;
            foreach (Control ctl in this.pnlInputTab.Controls)
            {
                if (ctl is XRadioButton)
                {
                    inputtab = ctl as XRadioButton;

                    if (inputtab.Checked)
                    {
                        inputtab.ForeColor = this.mSelectedForeColor;
                    }
                    else
                    {
                        inputtab.ForeColor = this.mUnSelectedForeColor;
                    }
                }
            }
        }

        // 오더 및 상병정보 초기화
        private void InitializeOrderInfo()
        {
            // grdOrder_XXXクリア
            this.grdOrder_Drug.Reset();
            this.grdOrder_Jusa.Reset();
            this.grdOrder_Cpl.Reset();
            this.grdOrder_Pfe.Reset();
            this.grdOrder_Apl.Reset();
            this.grdOrder_Xrt.Reset();
            this.grdOrder_Chuchi.Reset();
            this.grdOrder_Susul.Reset();
            this.grdOrder_Etc.Reset();
            this.grdOrder_Reha.Reset();

            // 상병그리드 클리어
            this.grdOutSang.Reset();

            // 상병 콤보박스 클리어
            this.cboOutSang.ComboItems.Clear();
            this.cboJinryoGwa.ComboItems.Clear();
            // 오더정보 클리어
            try
            {
                this.ClearOrderData();
                this.dwOrderInfo.Reset();


            }
            catch { }

            this.layDeletedData.Reset();

            this.layDisplayLayout.Reset();

            this.layDrugOrder.Reset();

        }

        // 입력탭 라디오 동적 구성
        private void MakeInputTab()
        {
            //            MultiLayout dtLayout = this.mOrderBiz.LoadComboDataSource("code", "INPUT_TAB");

            IHIS.Framework.MultiLayout dtLayout = new MultiLayout();

            dtLayout.Reset();
            dtLayout.LayoutItems.Clear();
            dtLayout.LayoutItems.Add("code", DataType.String);
            dtLayout.LayoutItems.Add("code_name", DataType.String);

            dtLayout.InitializeLayoutTable();
            dtLayout.ExecuteQuery = LoadComboDataSoureByCode;
            dtLayout.QueryLayout(true);

            XRadioButton rbnButton;

            int rowCount = 0;

            // 기존 내역삭제
            foreach (Control control in this.pnlInputTab.Controls)
            {
                if (control is XRadioButton)
                {
                    this.pnlInputTab.Controls.Remove(control);
                }
            }

            int count = 0;

            if (dtLayout.RowCount > 0)
            {
                //insert by jc rbnButtonを作る前にまずクリアしてから作る。 START
                this.pnlInputTab.Controls.Clear();
                this.pnlInputTab.Height = 35;
                this.pnlInputTab.Controls.Add(this.btnExpand);
                //insert by jc rbnButtonを作る前にまずクリアしてから作る。 END
                // 화면 끝 체크
                if ((this.pnlInputTab.Size.Width - this.mInputTabDefaultXLoc - (this.mInputTabDefaultWidth * count)) < this.mInputTabDefaultWidth)
                {
                    rowCount++;
                    this.pnlInputTab.Size = new Size(this.pnlInputTab.Size.Width, this.pnlInputTab.Height + this.mInputTabDefaultHeight);
                    count = 0;
                }

                rbnButton = new XRadioButton();

                rbnButton.Text = Resources.RBN_BUTTON_TEXT;
                rbnButton.Size = new Size(this.mInputTabDefaultWidth, this.mInputTabDefaultHeight);
                rbnButton.Location = new Point((this.mInputTabDefaultXLoc + (this.mInputTabDefaultWidth * count)), this.mInputTabDefaultYLoc + (this.mInputTabDefaultHeight * rowCount));
                rbnButton.TextAlign = ContentAlignment.MiddleCenter;
                rbnButton.Font = new Font("MS UI Gothic", (float)9.75, FontStyle.Bold);
                rbnButton.Appearance = Appearance.Button;
                rbnButton.ImageList = this.ImageList;
                rbnButton.ImageIndex = 4;
                rbnButton.ImageAlign = ContentAlignment.MiddleLeft;

                rbnButton.BackColor = this.mUnSelectedBackColor;
                rbnButton.ForeColor = this.mUnSelectedForeColor;
                rbnButton.CheckedChanged += new EventHandler(rbnOrder_CheckedChanged);

                rbnButton.Tag = "%";

                this.pnlInputTab.Controls.Add(rbnButton);

                count++;

            }

            foreach (DataRow dr in dtLayout.LayoutTable.Rows)
            {
                // TODO remove hardcode
                //insert by jc
                if (dr["code_name"].ToString() != Resources.code_name_compare)
                {
                    // 화면 끝 체크
                    if ((this.pnlInputTab.Size.Width - this.mInputTabDefaultXLoc - (this.mInputTabDefaultWidth * count)) < this.mInputTabDefaultWidth)
                    {
                        rowCount++;
                        this.pnlInputTab.Size = new Size(this.pnlInputTab.Size.Width, this.pnlInputTab.Height + this.mInputTabDefaultHeight);
                        count = 0;
                    }

                    rbnButton = new XRadioButton();

                    rbnButton.Text = dr["code_name"].ToString();
                    rbnButton.Size = new Size(this.mInputTabDefaultWidth, this.mInputTabDefaultHeight);
                    rbnButton.Location = new Point((this.mInputTabDefaultXLoc + (this.mInputTabDefaultWidth * count)), this.mInputTabDefaultYLoc + (this.mInputTabDefaultHeight * rowCount));
                    rbnButton.TextAlign = ContentAlignment.MiddleCenter;
                    rbnButton.Font = new Font("MS UI Gothic", (float)9.75, FontStyle.Bold);
                    rbnButton.Appearance = Appearance.Button;
                    rbnButton.ImageList = this.ImageList;
                    rbnButton.ImageIndex = 4;
                    rbnButton.ImageAlign = ContentAlignment.MiddleLeft;

                    rbnButton.BackColor = this.mUnSelectedBackColor;
                    rbnButton.ForeColor = this.mUnSelectedForeColor;
                    rbnButton.CheckedChanged += new EventHandler(rbnOrder_CheckedChanged);

                    rbnButton.Tag = dr["code"].ToString();

                    this.pnlInputTab.Controls.Add(rbnButton);

                    count++;
                }
            }

            // 전체를 체크해 놓는다.
            foreach (Control control in this.pnlInputTab.Controls)
            {
                if (control is XRadioButton && control.Tag.ToString() == "%")
                {
                    ((XRadioButton)control).Checked = true;
                }
            }


        }

        // 입력구분 탭 동적 구성 
        private void MakeInputGubunTab()
        {
            MultiLayout mInputGubun = new MultiLayout();

            mInputGubun.LayoutItems.Add("code", DataType.String);
            mInputGubun.LayoutItems.Add("code_name", DataType.String);
            mInputGubun.InitializeLayoutTable();

            // 의사가 로긴한경우
            if (this.mDoctorLogin == true)
            {
                //mInputGubun.QuerySQL = "SELECT A.CODE, A.CODE_NAME "
                //                     + "  FROM OCS0132 A "
                //                     + " WHERE A.CODE_TYPE  LIKE 'INPUT_GUBUN' "
                //                     + "   AND A.CODE       LIKE 'D0' "
                //                     + "   AND A.HOSP_CODE  = '" + EnvironInfo.HospCode + "' "
                //                     + " ORDER BY A.SORT_KEY, A.CODE ";

                mInputGubun.ExecuteQuery = LoadDataMInputGubunCase1;
            }
            else if (EnvironInfo.CurrSystemID == "NURO" || EnvironInfo.CurrSystemID == "NURI")
            {
                //mInputGubun.QuerySQL = "SELECT A.CODE, A.CODE_NAME "
                //                     + "  FROM OCS0132 A"
                //                     + " WHERE A.CODE_TYPE  LIKE 'INPUT_GUBUN' "
                //                     + "   AND A.CODE       LIKE 'NR' "
                //                     + "   AND A.HOSP_CODE  = '" + EnvironInfo.HospCode + "' "
                //                     + " ORDER BY A.SORT_KEY, A.CODE ";
                mInputGubun.ExecuteQuery = LoadDataMInputGubunCase2;
            }
            // 기타유저인경우
            else
            {
                //mInputGubun.QuerySQL = "SELECT A.CODE, A.CODE_NAME "
                //                     + "  FROM OCS0132 A"
                //                     + " WHERE A.CODE_TYPE  LIKE 'INPUT_GUBUN' "
                //                     + "   AND A.CODE       LIKE '" + this.mInputGubun + "' "
                //                     + "   AND A.HOSP_CODE  = '" + EnvironInfo.HospCode + "' "
                //                     + " ORDER BY A.SORT_KEY, A.CODE ";
                mInputGubun.ExecuteQuery = LoadDataMInputGubunCase3;
            }

            mInputGubun.QueryLayout(true);

            // 입력구분이 없는 유저가 등록된경우
            if (mInputGubun.RowCount <= 0)
            {
                this.mMsg = Resources.MSG014_MSG;
                this.mCap = Resources.MSG014_CAP;

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (this.OpenParam != null)
                {
                    this.Close();
                    return;
                }
            }

            // 이벤트 삭제
            this.tabInputGubun.SelectionChanged -= new EventHandler(tabInputGubun_SelectionChanged);

            IHIS.X.Magic.Controls.TabPage tpgInputGubun;
            try
            {
                this.tabInputGubun.TabPages.Clear();
            }
            finally
            {
                this.tabInputGubun.Refresh();
            }

            foreach (DataRow dr in mInputGubun.LayoutTable.Rows)
            {
                if (this.mDoctorLogin)
                    tpgInputGubun = new IHIS.X.Magic.Controls.TabPage(dr["code_name"].ToString());
                else
                    tpgInputGubun = new IHIS.X.Magic.Controls.TabPage(dr["code_name"].ToString() + Resources.TGPINPUTGUBUN_TEXT);

                tpgInputGubun.Tag = dr["code"].ToString();
                tpgInputGubun.ImageList = this.ImageList;
                tpgInputGubun.ImageIndex = 4;

                this.tabInputGubun.TabPages.Add(tpgInputGubun);
            }

            //if (UserInfo.UserGubun != UserType.Doctor)
            //if (!this.mDoctorLogin)
            //{
            //    tpgInputGubun = new IHIS.X.Magic.Controls.TabPage("医師オーダ照会及び追加");
            //    tpgInputGubun.Tag = "D%";
            //    tpgInputGubun.ImageList = this.ImageList;
            //    tpgInputGubun.ImageIndex = 4;

            //    this.tabInputGubun.TabPages.Add(tpgInputGubun);
            //}

            this.tabInputGubun.SelectionChanged += new EventHandler(tabInputGubun_SelectionChanged);

            this.tabInputGubun_SelectionChanged(this.tabInputGubun, new EventArgs());
        }

        private void InitializeSangGrid(XEditGrid aGrid, OCS.PatientInfo aPatientInfo, int aRow)
        {
            // 상병 그리드 new row 생성후 초기화
            // 초기화항목
            // bunho, gwa, io_gubun, naewon_date, jubsu_no, last_naewon_date, last_doctor, last_naewon_type, last_jubsu_no
            // fkinp1001, input_id, ju_sang_yn, sang_start_date

            //診療科名
            aGrid.SetItemValue(aRow, "gwa_name", aPatientInfo.GetPatientInfo["gwa"].ToString());
            // 환자번호
            aGrid.SetItemValue(aRow, "bunho", aPatientInfo.GetPatientInfo["bunho"].ToString());
            // 진료과
            aGrid.SetItemValue(aRow, "gwa", aPatientInfo.GetPatientInfo["gwa"].ToString());
            // IO_Gubun
            aGrid.SetItemValue(aRow, "io_gubun", this.IO_Gubun);
            // naewon_date
            aGrid.SetItemValue(aRow, "naewon_date", aPatientInfo.GetPatientInfo["naewon_date"].ToString());
            // jubsu_no
            aGrid.SetItemValue(aRow, "jubsu_no", aPatientInfo.GetPatientInfo["jubsu_no"].ToString());
            // last_naewon_date
            aGrid.SetItemValue(aRow, "last_naewon_date", aPatientInfo.GetPatientInfo["naewon_date"].ToString());
            // last_doctor
            aGrid.SetItemValue(aRow, "last_doctor", aPatientInfo.GetPatientInfo["doctor"].ToString());
            // last_naewon_type 
            aGrid.SetItemValue(aRow, "last_naewon_type", aPatientInfo.GetPatientInfo["naewon_type"].ToString()); ;
            // jubsu_no
            aGrid.SetItemValue(aRow, "last_jubsu_no", aPatientInfo.GetPatientInfo["jubsu_no"].ToString());
            // 내원 혹은 입원 키
            if (this.IO_Gubun == "O")
            {
                aGrid.SetItemValue(aRow, "pkout1001", aPatientInfo.GetPatientInfo["naewon_key"].ToString());
            }
            else
            {
                aGrid.SetItemValue(aRow, "fkinp1001", aPatientInfo.GetPatientInfo["naewon_key"].ToString());
            }
            // input_id  (입력자 id)
            aGrid.SetItemValue(aRow, "input_id", UserInfo.UserID);
            // ju_sang_yn ( 주상병)
            aGrid.SetItemValue(aRow, "ju_sang_yn", "N");
            // 상병 시작일 ( 새로 입력이므로 내원일자를 집어넣자...)
            aGrid.SetItemValue(aRow, "sang_start_date", aPatientInfo.GetPatientInfo["naewon_date"].ToString());

            //inser by jc [診断日基本SETTINGは来院日]
            aGrid.SetItemValue(aRow, "sang_jindan_date", aPatientInfo.GetPatientInfo["naewon_date"].ToString());

        }

        private void ClearInputGubunColor()
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabInputGubun.TabPages)
            {
                tpg.TitleTextColor = this.mNormalInputGubunColor.Color;
            }
        }

        #endregion

        #region [ 밸리데이팅 관련 ]

        private void Control_DataValidating(object sender, DataValidatingEventArgs e)
        {
            Control control = sender as Control;
            string bunho = "";
            object postCallArguments;

            switch (control.Name)
            {
                // 환자번호
                case "fbxBunho": // ★注意:TextBoxから直接入力される場合もあるので<< this.grdPatientList.CurrentRowNumber >>使用禁止

                    // 스탠다드 번호로 변경 
                    bunho = BizCodeHelper.GetStandardBunHo(e.DataValue);
                    //bunho = e.DataValue;

                    #region 患者の診療科と今の診療科が違うと患者の診療科に合わせるように

                    string gwa = "";

                    // CurrentRowNumber 代わりに　DBから取得 単数・複数可能性あり
                    MultiLayout layPat = new MultiLayout();
                    layPat.LayoutItems.Add("gwa", DataType.String);
                    layPat.LayoutItems.Add("bunho", DataType.String);
                    layPat.LayoutItems.Add("doctor", DataType.String);
                    layPat.LayoutItems.Add("group_key", DataType.String);
                    layPat.LayoutItems.Add("naewon_yn", DataType.String);
                    layPat.LayoutItems.Add("login_doctor_yn", DataType.String);


                    layPat.InitializeLayoutTable();

                    //                    layPat.QuerySQL = @"SELECT A.GWA, A.BUNHO, A.DOCTOR, B.GROUP_KEY, A.NAEWON_YN
                    //                                          FROM OUT1001 A
                    //                                              ,BAS0102 B
                    //                                         WHERE A.HOSP_CODE         = :f_hosp_code
                    //                                           AND SUBSTR(A.DOCTOR, 3) = SUBSTR(:f_doctor, 3)
                    //                                           AND A.BUNHO             = :f_bunho
                    //                                           AND A.NAEWON_DATE       = :f_naewon_date
                    //                                           AND B.HOSP_CODE = A.HOSP_CODE
                    //                                           AND B.CODE_TYPE = 'JUBSU_GUBUN'
                    //                                           AND B.CODE      = A.JUBSU_GUBUN
                    //                                           AND ((:f_login_doctor_yn = 'Y' AND B.GROUP_KEY = '1') OR (:f_login_doctor_yn = 'N'))
                    //                                    ";

                    layPat.ParamList = new List<string>(new string[] { "f_doctor", "f_bunho", "f_naewon_date", "f_login_doctor_yn" });

                    layPat.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    layPat.SetBindVarValue("f_doctor", this.cboQryDoctor.GetDataValue());
                    layPat.SetBindVarValue("f_bunho", bunho);
                    layPat.SetBindVarValue("f_naewon_date", this.dtpNaewonDate.GetDataValue());
                    if (this.mDoctorLogin)
                        layPat.SetBindVarValue("f_login_doctor_yn", "Y");
                    else
                        layPat.SetBindVarValue("f_login_doctor_yn", "N");

                    // Connect cloud
                    layPat.ExecuteQuery = ExecuteQueryOcsoOCS1003P01LayPatInfo;
                    layPat.QueryLayout(false);

                    if (this.mPatientDoubleClick)
                    {
                        this.cboQryGwa.SetDataValue(this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa"));
                    }
                    else if (layPat.RowCount == 1)
                    {
                        gwa = layPat.GetItemString(0, "gwa");
                        if (gwa != this.cboQryGwa.GetDataValue())
                            this.cboQryGwa.SetDataValue(gwa);
                    }

                    //else if (layPat.RowCount > 1)
                    //{
                    //    XMessageBox.Show("選択した患者の複数の診療科が存在します。直接画面から患者を選んでください。", "注意");
                    //    return;
                    //}
                    //else if (this.grdPatientList.CurrentRowNumber > -1 && this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa") != this.cboQryGwa.GetDataValue())
                    //{
                    //    this.cboQryGwa.SetDataValue(this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa"));
                    //}

                    //else if (this.grdPatientList.CurrentRowNumber == -1 && e.DataValue != "")
                    //{

                    //}


                    //if (this.grdPatientList.CurrentRowNumber > -1 && this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa") != this.cboQryGwa.GetDataValue())
                    //    this.cboQryGwa.SetDataValue(this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa"));

                    #endregion

                    #region 환자번호 벨리데이팅 서비스

                    // 내원일자 입력체크
                    if (this.dtpNaewonDate.GetDataValue() == "")
                    {
                        this.mMsg = Resources.MSG026_MSG;
                        this.mCap = Resources.MSG026_CAP;

                        MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.SetMsg(this.mMsg, MsgType.Error);

                        return;
                    }

                    // 이전데이터 저장여부
                    if (this.IsOrderDataModifed() == true)
                    {
                        // 저장안된 데이터 있다. 저장한다.
                        // 저장여부는 내부에서 판단.
                        this.btnList.PerformClick(FunctionType.Update);
                    }

                    // 번호 변경시의 초기화
                    this.InitializeBunho(false);

                    if (e.DataValue == "")
                    {
                        this.InitializeBunho(false);
                        this.SetMsg("");

                        return;
                    }



                    // 각종체크 들어가 주시고....
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    // 환자정보 로드해 봅시다....
                    // 파라미터 셋팅
                    this.mPatientInfoParam.NaewonDate = this.dtpNaewonDate.GetDataValue();
                    this.mPatientInfoParam.NaewonKey = TypeCheck.NVL(this.mClickedNaewonKey, this.mParamNaewonKey).ToString();
                    // 최초 로그인시 의사이ㅣㄴ경우 doctor combo 구성후 해당 의사로 셋팅해 놓고 안보이게 함.
                    // 따라서 그 의사만 계혹 설정될꺼고
                    // 의사가 아니면 콤보 박스가 변경이 가능할꺼고...
                    this.mPatientInfoParam.InputID = this.cboQryDoctor.GetDataValue();
                    this.mPatientInfoParam.Gwa = this.cboQryGwa.GetDataValue();
                    this.mPatientInfoParam.Doctor = this.cboQryDoctor.GetDataValue();

                    this.mPatientInfoParam.ApproveDoctor = this.cboQryDoctor.GetDataValue();

                    this.mPatientInfoParam.IOEGubun = "O"; // 외래 
                    this.mPatientInfoParam.Bunho = bunho;
                    this.mPatientInfoParam.IsEnableIpwonReser = true;


                    this.mSelectedPatientInfo.Parameter = this.mPatientInfoParam;

                    //mGroup_key初期化
                    this.mGroup_key = "";

                    if (this.mSelectedPatientInfo.LoadPatientInfo(IHIS.OCS.PatientInfo.QueryMode.NawonFullInfo) == false)
                    {
                        this.mMsg = Resources.MSG027_MSG;
                        this.mCap = Resources.MSG027_CAP;

                        MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.SetMsg(this.mMsg, MsgType.Error);

                        postCallArguments = new Hashtable();

                        ((Hashtable)postCallArguments).Add("success_yn", "N");
                        ((Hashtable)postCallArguments).Add("bunho", bunho);

                        PostCallHelper.PostCall(new PostMethodObject(PostBunhoValidating), postCallArguments);

                        return;
                    }
                    else
                    {
                        if (this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString() != this.cboQryGwa.GetDataValue())
                            this.cboQryGwa.SetDataValue(this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());

                        if (this.mPatientDoubleClick)
                        {
                            this.mGroup_key = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "group_key");
                        }
                        else if (layPat.RowCount == 1)
                        {
                            this.mGroup_key = layPat.GetItemString(0, "group_key");
                        }
                        else if (this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString() != "")
                        {
                            //                            string cmd = @"SELECT B.GROUP_KEY
                            //                                          FROM OUT1001 A
                            //                                              ,BAS0102 B
                            //                                         WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + @"'
                            //                                           AND A.PKOUT1001  = '" + this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString() + @"'
                            //                                           AND B.HOSP_CODE  = A.HOSP_CODE
                            //                                           AND B.CODE_TYPE  = 'JUBSU_GUBUN'
                            //                                           AND B.CODE       = A.JUBSU_GUBUN
                            //                                           
                            //                                    ";
                            //                            object obj = Service.ExecuteScalar(cmd);

                            // Connect cloud
                            OcsoOCS1003P01GetGroupKeyArgs args = new OcsoOCS1003P01GetGroupKeyArgs();
                            args.Pkout1001 = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                            args.CodeType = "JUBSU_GUBUN";
                            OcsoOCS1003P01GetGroupKeyResult result = CloudService.Instance.Submit<OcsoOCS1003P01GetGroupKeyResult, OcsoOCS1003P01GetGroupKeyArgs>(args);
                            if (result != null)
                            {
                                this.mGroup_key = result.GroupKey;
                            }

                        }
                        //else if (layPat.RowCount > 1)
                        //{
                        //    XMessageBox.Show("選択した患者の複数の診療科が存在します。直接画面から患者を選んでください。", "注意");
                        //    return;
                        //}
                        //else if (this.grdPatientList.CurrentRowNumber == -1 && e.DataValue != "")
                        //    this.mGroup_key = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "group_key");
                    }

                    // TODO linhnt:  Load OCS1003Q09
                    // 未承認オーダーがあれば承認画面POPUP 無ければDOオーダーPOPUP
                    if (this.mDoctorLogin && this.mOrderBiz.GetNotApproveOrderCnt(IO_Gubun, UserInfo.UserID, "Y", "N", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) > 0)
                    {
                        this.btnApprove.PerformClick();
                    }
                    else
                    {
                        string userOption = "";
                        int orderCount = 0;
                        OCS1003P01GetUserOptionAndOrderCountResult checkResult = GetUserOptionAndOrderCount(bunho);
                        if (checkResult != null && checkResult.ExecutionStatus == ExecutionStatus.Success)
                        {
                            if (!TypeCheck.IsNull(checkResult.UserOptionValue))
                            {
                                userOption = checkResult.UserOptionValue;
                            }
                            if (TypeCheck.IsInt(checkResult.OrderCountValue))
                            {
                                orderCount = int.Parse(checkResult.OrderCountValue);
                            }
                        }
                        // insert by jc [使用者オプションによる表示・非表示] 2012/09/24
                        if (this.mPatientDoubleClick)
                        {
                            //if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "DO_ORDER_POP_YN", this.IO_Gubun) != "N"
                            //&& this.mOrderBiz.GetOrderCount(this.IO_Gubun, bunho, this.dtpNaewonDate.GetDataValue().ToString()) > 0
                            //&& this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_yn") != "E")
                            if (userOption != "N" && orderCount > 0
                                && this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_yn") != "E")
                            {
                                this.btnDoOrder.PerformClick();
                            }
                        }
                        else if (layPat.RowCount == 1)
                        {
                            //if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "DO_ORDER_POP_YN", this.IO_Gubun) != "N"
                            //&& this.mOrderBiz.GetOrderCount(this.IO_Gubun, bunho, this.dtpNaewonDate.GetDataValue().ToString()) > 0
                            //&& layPat.GetItemString(0, "naewon_yn") != "E")
                            //if (userOption != "N" && orderCount > 0
                            //    && layPat.GetItemString(0, "naewon_yn") != "E")
                            //{
                            //    this.btnDoOrder.PerformClick();
                            //}
                        }
                        else if (this.mSelectedPatientInfo.GetPatientInfo["naewon_yn"].ToString() != "")
                        {
                            //if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "DO_ORDER_POP_YN", this.IO_Gubun) != "N"
                            //&& this.mOrderBiz.GetOrderCount(this.IO_Gubun, bunho, this.dtpNaewonDate.GetDataValue().ToString()) > 0
                            //&& this.mSelectedPatientInfo.GetPatientInfo["naewon_yn"].ToString() != "E")
                            //if (userOption != "N" && orderCount > 0
                            //    && this.mSelectedPatientInfo.GetPatientInfo["naewon_yn"].ToString() != "E")
                            //{
                            //    this.btnDoOrder.PerformClick();
                            //}
                        }
                    }
                    // TODO end

                    if (this.mClickedNaewonKey != "")
                    {
                        this.mClickedNaewonKey = "";
                    }

                    if (this.mParamNaewonKey != "")
                    {
                        this.mParamNaewonKey = "";
                    }

                    // 내원 체크 
                    if (this.mSelectedPatientInfo.GetPatientInfo["naewon_yn"].ToString() == "N")
                    {
                        if (MessageBox.Show(XMsg.GetMsg("M010"), XMsg.GetField("F001"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                        {
                            postCallArguments = new Hashtable();

                            ((Hashtable)postCallArguments).Add("success_yn", "N");
                            ((Hashtable)postCallArguments).Add("bunho", bunho);

                            PostCallHelper.PostCall(new PostMethodObject(PostBunhoValidating), postCallArguments);

                            return;

                        }
                    }

                    // 재원환자 체크 
                    if (this.mOrderBiz.IsJaewonPatient(e.DataValue))
                    {
                        this.mMsg = Resources.MSG028_MSG;
                        this.mCap = Resources.MSG027_CAP;

                        MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.SetMsg(this.mMsg, MsgType.Error);

                        postCallArguments = new Hashtable();

                        ((Hashtable)postCallArguments).Add("success_yn", "N");
                        ((Hashtable)postCallArguments).Add("bunho", bunho);

                        PostCallHelper.PostCall(new PostMethodObject(PostBunhoValidating), postCallArguments);

                        return;
                    }

                    // 入院予約がある患者さんの場合、代行オーダーを入院オーダーにて登録するようにする。
                    if (UserInfo.Gwa == "CK")
                    {
                        string isInstead = "";
                        isInstead = this.mOrderBiz.isAbleInsteadOrder(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                            , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                                            , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString());

                        if (isInstead != "")
                        {
                            XMessageBox.Show(isInstead, Resources.MSG001_CAP, MessageBoxIcon.Stop);
                            return;
                        }
                    }


                    // 기타 사항들 체크 및 visible 셋팅
                    this.CheckPatientEtcInfo(this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(), bunho
                                            , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(), this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

                    // 환자정보 라벨들 셋팅
                    this.SetPatientInfoLabel(this.mSelectedPatientInfo.GetPatientInfo);

                    // 환자정보 박스 기동
                    this.paInfoBox.SetPatientID(bunho);




                    postCallArguments = new Hashtable();
                    ((Hashtable)postCallArguments).Add("success_yn", "Y");
                    ((Hashtable)postCallArguments).Add("bunho", bunho);

                    PostCallHelper.PostCall(new PostMethodObject(PostBunhoValidating), postCallArguments);

                    #endregion

                    //insert by jc [患者を選択する際、InputTabの初期化（全体）するように] 2012/03/13
                    // 전체를 체크해 놓는다.
                    foreach (Control inputTabcontrol in this.pnlInputTab.Controls)
                    {
                        if (inputTabcontrol is XRadioButton && inputTabcontrol.Tag.ToString() == "%")
                        {
                            ((XRadioButton)inputTabcontrol).Checked = true;
                        }
                    }
                    //inser by jc [診療保留、診療保留取消の切り替えのため] 2012/09/08
                    this.SettingVisiblebyUser();

                    // TODO comment linhnt
                    /*
                                        // 未承認オーダーがあれば承認画面POPUP 無ければDOオーダーPOPUP
                                        if (this.mDoctorLogin && this.mOrderBiz.GetNotApproveOrderCnt(IO_Gubun, UserInfo.UserID, "Y", "N", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) > 0)
                                        {
                                            this.btnApprove.PerformClick();
                                        }
                                        else
                                        {
                                            // insert by jc [使用者オプションによる表示・非表示] 2012/09/24
                                            if (this.mPatientDoubleClick)
                                            {
                                                if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "DO_ORDER_POP_YN", this.IO_Gubun) != "N"
                                                && this.mOrderBiz.GetOrderCount(this.IO_Gubun, bunho, this.dtpNaewonDate.GetDataValue().ToString()) > 0
                                                && this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_yn") != "E")
                                                {
                                                    this.btnDoOrder.PerformClick();
                                                }
                                            }
                                            else if (layPat.RowCount == 1)
                                            {
                                                if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "DO_ORDER_POP_YN", this.IO_Gubun) != "N"
                                                && this.mOrderBiz.GetOrderCount(this.IO_Gubun, bunho, this.dtpNaewonDate.GetDataValue().ToString()) > 0
                                                && layPat.GetItemString(0, "naewon_yn") != "E")
                                                {
                                                    this.btnDoOrder.PerformClick();
                                                }
                                            }
                                            else if (this.mSelectedPatientInfo.GetPatientInfo["naewon_yn"].ToString() != "")
                                            {
                                                if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "DO_ORDER_POP_YN", this.IO_Gubun) != "N"
                                                && this.mOrderBiz.GetOrderCount(this.IO_Gubun, bunho, this.dtpNaewonDate.GetDataValue().ToString()) > 0
                                                && this.mSelectedPatientInfo.GetPatientInfo["naewon_yn"].ToString() != "E")
                                                {
                                                    this.btnDoOrder.PerformClick();
                                                }
                                            }
                                        }*/

                    //else if (layPat.RowCount > 1)
                    //{
                    //    XMessageBox.Show("選択した患者の複数の診療科が存在します。直接画面から患者を選んでください。", "注意");
                    //    return;
                    //}

                    this.mPatientDoubleClick = false;
                    //if (this.grdPatientList.CurrentRowNumber > -1)
                    //{
                    //    if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "DO_ORDER_POP_YN", this.IO_Gubun) != "N"
                    //        && this.mOrderBiz.GetOrderCount(this.IO_Gubun, bunho, this.dtpNaewonDate.GetDataValue().ToString()) > 0
                    //        && this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_yn") != "E")
                    //    {
                    //        this.btnDoOrder.PerformClick();
                    //    }
                    //}

                    //患者選択時傷病リストが拡張されてる状態に見せる。2013/04/29
                    if (!this.mIsExpandedSB)
                        this.btnExpandSB.PerformClick();

                    this.grdReserOrderList.ExecuteQuery = ExecuteQueryOcsoOCS1003P01GridReserOrderListInfo;
                    this.grdReserOrderList.QueryLayout(false);

                    this.mPostApproveYN = this.mOrderBiz.getEnablePostApprove("I", this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString());

                    if (this.mPostApproveYN)
                        this.lblApproveFlag.Text = Resources.LBLAPPROVEFLAG_TEXT_2;
                    else
                        this.lblApproveFlag.Text = Resources.LBLAPPROVEFLAG_TEXT_1;

                    break;

                // 내원일자
                case "dtpNaewonDate":

                    #region 내원일자 벨리데이팅

                    if (e.DataValue != "" && this.mDoctorLogin == false)
                    {
                        // 진료과 콤보 재조회
                        this.ReLoadGwaCombo(e.DataValue);

                        // 의사 콤보 재조회
                        this.ReLoadDoctorCombo(e.DataValue, this.cboQryGwa.GetDataValue());
                    }

                    // 내원자 리스트 조회
                    PatientListQuery(e.DataValue, this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());

                    this.InitializeBunho(false);

                    #endregion

                    break;
            }
        }

        #endregion

        #region [ Post 이벤트 메소드들... ]

        /// <summary>
        /// 환자번호 벨리데이팅 후 타게되는 메소드
        /// </summary>
        /// <param name="aArguments">Hashtable : [success_yn]  벨리데이션 성공여부, [bunho] 9자리 환자번호 </param>
        private void PostBunhoValidating(object aArguments)
        {
            Hashtable arguments = aArguments as Hashtable;

            if (arguments["success_yn"].ToString() != "Y")
            {

                this.fbxBunho.SetDataValue("");

                this.InitializeBunho(false);
            }
            else
            {
                this.fbxBunho.SetDataValue(arguments["bunho"].ToString());

                //if (this.cbxOpenEmr.Checked && this.mIsCalledbyOtherScreen == false)
                // insert by jc [使用者オプションによる表示・非表示] 2012/09/24
                //if (this.cbxOpenEmr.Checked && this.mIsCalledbyOtherScreen == false && this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "EMR_POP_YN", this.IO_Gubun) != "N")
                //{
                //    this.btnEMR.PerformClick();
                //}

                // 오더정보조회 OPEN
                //if (this.mSelectedPatientInfo.GetPatientInfo["real_naewon_yn"].ToString() != "E" && this.mSelectedPatientInfo.GetPatientInfo["real_naewon_yn"].ToString() != "H")
                //    this.btnQryOrderInfo.PerformClick();

                // 오늘 측정한 바이탈 정보가 있으면 창을 띄운다.
                //if (this.pbxVital.Visible && this.mDoctorLogin && this.mSelectedPatientInfo.GetPatientInfo["real_naewon_yn"].ToString() == "Y")
                // insert by jc [使用者オプションによる表示・非表示] 2012/09/24
                if (this.pbxVital.Visible && this.mDoctorLogin && this.mSelectedPatientInfo.GetPatientInfo["real_naewon_yn"].ToString() == "Y" && this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "VITALSIGNS_POP_YN", this.IO_Gubun) != "N")
                    this.btnVital.PerformClick();

                this.btnList.PerformClick(FunctionType.Query);
            }
        }

        #endregion

        #region [ Command ]

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "OUT0101":

                    if (commandParam != null)
                    {
                        this.fbxBunho.Focus();
                        this.fbxBunho.SetEditValue(((MultiLayout)commandParam[0]).GetItemString(0, "bunho"));
                        this.fbxBunho.AcceptData();
                    }

                    break;

                case "CHT0110Q01": // 상병 조회

                    #region 상병조회

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("CHT0110"))
                        {
                            this.ApplySangInfo(this.grdOutSang, (MultiLayout)commandParam["CHT0110"], false);
                        }
                    }

                    #endregion

                    break;

                case "OCS0204Q00": // 사용자별 상병조회

                    #region 사용자별 상병조회

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("OCS0205"))
                        {
                            this.ApplySangInfo(this.grdOutSang, (MultiLayout)commandParam["OCS0205"], true);
                        }
                    }

                    #endregion

                    break;

                case "CHT0115Q00":

                    #region 수식어

                    string display_sang_name = "";

                    if (commandParam != null)
                    {
                        this.grdOutSang.Focus();
                        this.grdOutSang.SetFocusToItem(this.grdOutSang.CurrentRowNumber, "sang_code");

                        foreach (XEditGridCell cell in grdOutSang.CellInfos)
                        {
                            if (((MultiLayout)commandParam["CHT0115"]).LayoutItems.Contains(cell.CellName))
                                grdOutSang.SetItemValue(grdOutSang.CurrentRowNumber, cell.CellName, ((MultiLayout)commandParam["CHT0115"]).GetItemString(0, cell.CellName));
                        }

                        //display 상병명
                        display_sang_name = this.mOrderBiz.GetDisplaySangName(grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "pre_modifier_name"),
                            grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "sang_name"),
                            grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "post_modifier_name"));
                        grdOutSang.SetItemValue(grdOutSang.CurrentRowNumber, "display_sang_name", display_sang_name);

                        grdOutSang.Refresh();

                        this.MakePatientSangCombo(this.grdOutSang.LayoutTable);

                        this.grdOutSang.AcceptData();
                    }

                    #endregion

                    break;

                case "OCS0103U10": // 약오더 화면

                    #region 약 처방

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("drug_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["drug_order"]);
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                        }
                        if (commandParam.Contains("allWarning"))
                        {
                            this.allWarning = commandParam["allWarning"].ToString();
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U11": // リハビリ

                    #region リハビリ

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("reha_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["reha_order"]);
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U12": // 주사오더 화면

                    #region 주사 처방

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("jusa_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["jusa_order"]);
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                        }
                        if (commandParam.Contains("allWarning"))
                        {
                            this.allWarning = commandParam["allWarning"].ToString();
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U13": // 검체검사오더

                    #region 검체검사오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("gumsa_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["gumsa_order"]);
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U14": // 생리검사오더

                    #region 생리검사오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("pfe_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["pfe_order"]);
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U15": // 병리검사오더

                    #region 병리검사

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("apl_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["apl_order"]);
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U16": // 방사선오더

                    #region 방사선검사

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("xrt_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["xrt_order"]);
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U17": // 처치오더

                    #region 처치 오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("chuchi_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["chuchi_order"]);
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U18": // 수술오더

                    #region 수술 오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("susul_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["susul_order"]);
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U19": // 기타오더

                    #region 기타오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("etc_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["etc_order"]);
                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                        }
                    }

                    #endregion

                    break;

                case "INP1003U01": // 입원시 오더

                    #region 입원시 오더

                    this.pbxInpReserYN.Visible = false;

                    if (commandParam.Contains("pkinp1001") && commandParam["pkinp1001"] != null &&
                        commandParam.Contains("bunho") && commandParam["bunho"] != null)
                    {
                        this.OpenScreen_OCS2003P01(commandParam["bunho"].ToString(), commandParam["reser_date"].ToString(), commandParam["pkinp1001"].ToString());
                    }

                    #endregion

                    break;

                case "OCS1003U01":  // 반납 취소

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("retrieve"))
                        {
                            if (commandParam["retrieve"].ToString() == "Y")
                            {
                                this.btnList.PerformClick(FunctionType.Query);
                            }
                        }
                    }

                    break;
                //insert by jc START
                case "OCS0301Q09":
                    if (commandParam.Contains("OCS0303"))
                    {

                        MultiLayout lyOCS0303 = new MultiLayout();

                        //this.ApplyCopyOrderInfo((MultiLayout)commandParam["OCS0303"], HangmogInfo.ExecutiveMode.YaksokCopy);
                        lyOCS0303 = (MultiLayout)commandParam["OCS0303"];
                        int cntDupleSpeciment = 0;
                        this.layDrugOrder_Do.Reset();
                        this.layJusaOrder_Do.Reset();
                        this.layCplOrder_Do.Reset();
                        this.layPfeOrder_Do.Reset();
                        this.layAplOrder_Do.Reset();
                        this.layXrtOrder_Do.Reset();
                        this.layChuchiOrder_Do.Reset();
                        this.laySusulOrder_Do.Reset();
                        // リハビリオーダ追加 2012/09/26
                        this.layRehaOrder_Do.Reset();
                        this.layEtcOrder_Do.Reset();
                        //this.SetVisibleStatusBar(true);
                        //this.InitStatusBar(lyOCS1003.RowCount);
                        //this.SetStatusBar(0);

                        //[各部門毎にオーダを分ける]
                        foreach (DataRow dr in lyOCS0303.LayoutTable.Rows)
                        {
                            //this.SetInputGubunColor(dr["input_gubun"].ToString());
                            switch (dr["input_tab"].ToString())
                            {
                                case "01":  // 내복약오더
                                    this.layDrugOrder_Do.LayoutTable.ImportRow(dr);
                                    break;

                                case "03":  // 주사오더
                                    this.layJusaOrder_Do.LayoutTable.ImportRow(dr);
                                    break;

                                case "04":  // 검체검사 오더
                                    //重複検査して重複除去
                                    if (!IsDupleSpeciment(dr))
                                    {
                                        this.layCplOrder_Do.LayoutTable.ImportRow(dr);
                                    }
                                    else
                                        cntDupleSpeciment++;

                                    break;

                                case "05":  // 생리검사 오더
                                    this.layPfeOrder_Do.LayoutTable.ImportRow(dr);
                                    break;

                                case "06":  // 병리검사 오더
                                    this.layAplOrder_Do.LayoutTable.ImportRow(dr);
                                    break;

                                case "07":  // 방사선 오더
                                    this.layXrtOrder_Do.LayoutTable.ImportRow(dr);
                                    break;

                                case "08":  // 처치
                                    this.layChuchiOrder_Do.LayoutTable.ImportRow(dr);
                                    break;

                                case "09":  // 마취 수술
                                    this.laySusulOrder_Do.LayoutTable.ImportRow(dr);
                                    break;
                                // リハビリオーダ追加 2012/09/26
                                case "10":  // リハビリオーダ
                                    this.layRehaOrder_Do.LayoutTable.ImportRow(dr);
                                    break;
                                case "11":  // 기타 오더
                                    this.layEtcOrder_Do.LayoutTable.ImportRow(dr);
                                    break;
                            }
                        }
                        //重複された検体検査オーダがあれば何件が重複されていて登録できなかったのかMSGで知らせる
                        if (cntDupleSpeciment > 0)
                        {
                            MessageBox.Show(Resources.MSG023_MSG_1 + cntDupleSpeciment + Resources.MSG023_MSG_2);
                        }
                        //insert by jc [通常]

                        if (UserInfo.Gwa == "CK")
                        {
                            if (this.mPostApproveYN)
                                iInputGubun = "D0";
                            else
                                iInputGubun = this.mInputGubun;
                        }
                        else
                        {
                            iInputGubun = this.tabInputGubun.SelectedTab.Tag.ToString();
                        }

                        //if (this.mDoctorLogin)
                        //    iInputGubun = this.tabInputGubun.SelectedTab.Tag.ToString();
                        //else
                        //    iInputGubun = this.mInputGubun;

                        this.mOrderBiz.LoadColumnCodeName("code", "INPUT_GUBUN", iInputGubun, ref this.iInputGubunName);
                        //[分けたオーダを架空する。]



                        //[group情報生成]

                        #region 薬

                        //[group情報生成]
                        if (this.layDrugOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "01";
                            this.INPUTTAB = "01";
                            this.mOrderDate = this.dtpNaewonDate.GetDataValue();

                            //MakeDoOrderGrouping2(this.layDrugOrder_Do, this.layDrugOrder, this.grdOrder_Drug, "01", "OCS0103U10", "drug");
                            this.ApplyCopyOrderInfoDrug(this.layDrugOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Drug);
                            this.RecieveAndSetOrderInfo("OCS0103U10", this.grdOrder_Drug);
                        }
                        #endregion

                        #region 注射
                        if (this.layJusaOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "03";
                            this.INPUTTAB = "03";
                            this.mOrderDate = this.dtpNaewonDate.GetDataValue();

                            //MakeDoOrderGrouping2(this.layJusaOrder_Do, this.layJusaOrder, this.grdOrder_Jusa, "03", "OCS0103U12", "jusa");
                            this.ApplyCopyOrderInfoJusa(this.layJusaOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Jusa);
                            this.RecieveAndSetOrderInfo("OCS0103U12", this.grdOrder_Jusa);
                        }
                        #endregion

                        #region 検体検査

                        if (this.layCplOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "04";
                            this.INPUTTAB = "04";
                            this.mOrderDate = this.dtpNaewonDate.GetDataValue();

                            //MakeDoOrderGrouping2(this.layCplOrder_Do, this.layCplOrder, this.grdOrder_Cpl, "04", "OCS0103U13", "cpl");
                            this.ApplyCopyOrderInfoCpl(this.layCplOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Cpl);
                            this.RecieveAndSetOrderInfo("OCS0103U13", this.grdOrder_Cpl);

                        }
                        #endregion

                        #region 生理検査
                        if (this.layPfeOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "05";
                            this.INPUTTAB = "05";
                            this.mOrderDate = this.dtpNaewonDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.layPfeOrder_Do, this.layPfeOrder, this.grdOrder_Pfe, "05", "OCS0103U14", "pfe");
                            this.ApplyCopyOrderInfoPfe(this.layPfeOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Pfe);
                            this.RecieveAndSetOrderInfo("OCS0103U14", this.grdOrder_Pfe);
                        }
                        #endregion

                        #region 病理検査
                        if (this.layAplOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "06";
                            this.INPUTTAB = "06";
                            this.mOrderDate = this.dtpNaewonDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.layAplOrder_Do, this.layAplOrder, this.grdOrder_Apl, "06", "OCS0103U15", "apl");
                            this.ApplyCopyOrderInfoApl(this.layAplOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Apl);
                            this.RecieveAndSetOrderInfo("OCS0103U15", this.grdOrder_Apl);
                        }
                        #endregion

                        #region 放射線
                        if (this.layXrtOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "07";
                            this.INPUTTAB = "07";
                            this.mOrderDate = this.dtpNaewonDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.layXrtOrder_Do, this.layXrtOrder, this.grdOrder_Xrt, "07", "OCS0103U16", "xrt");
                            this.ApplyCopyOrderInfoXrt(this.layXrtOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Xrt);
                            this.RecieveAndSetOrderInfo("OCS0103U16", this.grdOrder_Xrt);
                        }
                        #endregion

                        #region 処置
                        if (this.layChuchiOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "08";
                            this.INPUTTAB = "08";
                            this.mOrderDate = this.dtpNaewonDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.layChuchiOrder_Do, this.layChuchiOrder, this.grdOrder_Chuchi, "08", "OCS0103U17", "chuchi");
                            this.ApplyCopyOrderInfoChuchi(this.layChuchiOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Chuchi);
                            this.RecieveAndSetOrderInfo("OCS0103U17", this.grdOrder_Chuchi);
                        }
                        #endregion

                        #region 手術
                        if (this.laySusulOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "09";
                            this.INPUTTAB = "09";
                            this.mOrderDate = this.dtpNaewonDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.laySusulOrder_Do, this.laySusulOrder, this.grdOrder_Susul, "09", "OCS0103U18", "susul");
                            this.ApplyCopyOrderInfoSusul(this.laySusulOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Susul);
                            this.RecieveAndSetOrderInfo("OCS0103U18", this.grdOrder_Susul);
                        }
                        #endregion

                        // リハビリオーダ追加 2012/09/26
                        //#region リハビリ
                        if (this.layRehaOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "10";
                            this.INPUTTAB = "10";
                            this.mOrderDate = this.dtpNaewonDate.GetDataValue();
                            this.ApplyCopyOrderInfoReha(this.layRehaOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Reha);
                            this.RecieveAndSetOrderInfo("OCS0103U11", this.grdOrder_Reha);
                        }
        #endregion

                        #region その他
                        if (this.layEtcOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "11";
                            this.INPUTTAB = "11";
                            this.mOrderDate = this.dtpNaewonDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.layEtcOrder_Do, this.layEtcOrder, this.grdOrder_Etc, "11", "OCS0103U19", "etc");
                            this.ApplyCopyOrderInfoEtc(this.layEtcOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Etc);
                            this.RecieveAndSetOrderInfo("OCS0103U19", this.grdOrder_Etc);
                        }
                        #endregion

                        this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                    }
                    //2015-11-23: Kinki check
                    KinkiChecking(GetSetOrder(this.layDrugOrder_Do, this.layJusaOrder_Do));
                    break;
                //insert by jc START
                case "OCS1003Q09":

                    #region Doオーダ

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("OCS1003"))
                        {

                            MultiLayout lyOCS1003 = new MultiLayout();

                            //this.ApplyCopyOrderInfo((MultiLayout)commandParam["OCS0303"], HangmogInfo.ExecutiveMode.YaksokCopy);
                            lyOCS1003 = (MultiLayout)commandParam["OCS1003"];
                            int cntDupleSpeciment = 0;
                            this.layDrugOrder_Do.Reset();
                            this.layJusaOrder_Do.Reset();
                            this.layCplOrder_Do.Reset();
                            this.layPfeOrder_Do.Reset();
                            this.layAplOrder_Do.Reset();
                            this.layXrtOrder_Do.Reset();
                            this.layChuchiOrder_Do.Reset();
                            this.laySusulOrder_Do.Reset();
                            // リハビリオーダ追加 2012/09/26
                            this.layRehaOrder_Do.Reset();
                            this.layEtcOrder_Do.Reset();
                            //this.SetVisibleStatusBar(true);
                            //this.InitStatusBar(lyOCS1003.RowCount);
                            //this.SetStatusBar(0);

                            //[各部門毎にオーダを分ける]
                            foreach (DataRow dr in lyOCS1003.LayoutTable.Rows)
                            {
                                this.SetInputGubunColor(dr["input_gubun"].ToString());
                                switch (dr["input_tab"].ToString())
                                {
                                    case "01":  // 내복약오더
                                        this.layDrugOrder_Do.LayoutTable.ImportRow(dr);
                                        break;

                                    case "03":  // 주사오더
                                        this.layJusaOrder_Do.LayoutTable.ImportRow(dr);
                                        break;

                                    case "04":  // 검체검사 오더
                                        //重複検査して重複除去
                                        if (!IsDupleSpeciment(dr))
                                        {
                                            this.layCplOrder_Do.LayoutTable.ImportRow(dr);
                                        }
                                        else
                                            cntDupleSpeciment++;

                                        break;

                                    case "05":  // 생리검사 오더
                                        this.layPfeOrder_Do.LayoutTable.ImportRow(dr);
                                        break;

                                    case "06":  // 병리검사 오더
                                        this.layAplOrder_Do.LayoutTable.ImportRow(dr);
                                        break;

                                    case "07":  // 방사선 오더
                                        this.layXrtOrder_Do.LayoutTable.ImportRow(dr);
                                        break;

                                    case "08":  // 처치
                                        this.layChuchiOrder_Do.LayoutTable.ImportRow(dr);
                                        break;

                                    case "09":  // 마취 수술
                                        this.laySusulOrder_Do.LayoutTable.ImportRow(dr);
                                        break;

                                    // リハビリオーダ追加 2012/09/26
                                    case "10":  // リハビリ
                                        this.layRehaOrder_Do.LayoutTable.ImportRow(dr);
                                        break;
                                    case "11":  // 기타 오더
                                        this.layEtcOrder_Do.LayoutTable.ImportRow(dr);
                                        break;
                                }
                            }

                            //重複された検体検査オーダがあれば何件が重複されていて登録できなかったのかMSGで知らせる
                            if (cntDupleSpeciment > 0)
                            {
                                MessageBox.Show(Resources.MSG023_MSG_1 + cntDupleSpeciment + Resources.MSG023_MSG_2);
                            }
                            //insert by jc [通常]

                            if (UserInfo.Gwa == "CK")
                            {
                                if (this.mPostApproveYN)
                                    iInputGubun = "D0";
                                else
                                    iInputGubun = this.mInputGubun;
                            }
                            else
                            {
                                iInputGubun = this.tabInputGubun.SelectedTab.Tag.ToString();
                            }

                            //if (this.mDoctorLogin)
                            //    iInputGubun = this.tabInputGubun.SelectedTab.Tag.ToString();
                            //else
                            //    iInputGubun = this.mInputGubun;

                            this.mOrderBiz.LoadColumnCodeName("code", "INPUT_GUBUN", iInputGubun, ref this.iInputGubunName);


                            //[分けたオーダを架空する。]

                            #region 薬

                            //[group情報生成]
                            if (this.layDrugOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "01";
                                this.INPUTTAB = "01";
                                this.mOrderDate = this.dtpNaewonDate.GetDataValue();

                                //MakeDoOrderGrouping2(this.layDrugOrder_Do, this.layDrugOrder, this.grdOrder_Drug, "01", "OCS0103U10", "drug");
                                this.ApplyCopyOrderInfoDrug(this.layDrugOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Drug);
                                this.RecieveAndSetOrderInfo("OCS0103U10", this.grdOrder_Drug);
                            }
                            #endregion

                            #region 注射
                            if (this.layJusaOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "03";
                                this.INPUTTAB = "03";
                                this.mOrderDate = this.dtpNaewonDate.GetDataValue();

                                //MakeDoOrderGrouping2(this.layJusaOrder_Do, this.layJusaOrder, this.grdOrder_Jusa, "03", "OCS0103U12", "jusa");
                                this.ApplyCopyOrderInfoJusa(this.layJusaOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Jusa);
                                this.RecieveAndSetOrderInfo("OCS0103U12", this.grdOrder_Jusa);
                            }
                            #endregion

                            #region 検体検査

                            if (this.layCplOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "04";
                                this.INPUTTAB = "04";
                                this.mOrderDate = this.dtpNaewonDate.GetDataValue();

                                //MakeDoOrderGrouping2(this.layCplOrder_Do, this.layCplOrder, this.grdOrder_Cpl, "04", "OCS0103U13", "cpl");
                                this.ApplyCopyOrderInfoCpl(this.layCplOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Cpl);
                                this.RecieveAndSetOrderInfo("OCS0103U13", this.grdOrder_Cpl);

                            }
                            #endregion


                            #region 生理検査
                            if (this.layPfeOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "05";
                                this.INPUTTAB = "05";
                                this.mOrderDate = this.dtpNaewonDate.GetDataValue();
                                //MakeDoOrderGrouping2(this.layPfeOrder_Do, this.layPfeOrder, this.grdOrder_Pfe, "05", "OCS0103U14", "pfe");
                                this.ApplyCopyOrderInfoPfe(this.layPfeOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Pfe);
                                this.RecieveAndSetOrderInfo("OCS0103U14", this.grdOrder_Pfe);
                            }
                            #endregion

                            #region 病理検査
                            if (this.layAplOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "06";
                                this.INPUTTAB = "06";
                                this.mOrderDate = this.dtpNaewonDate.GetDataValue();
                                //MakeDoOrderGrouping2(this.layAplOrder_Do, this.layAplOrder, this.grdOrder_Apl, "06", "OCS0103U15", "apl");
                                this.ApplyCopyOrderInfoApl(this.layAplOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Apl);
                                this.RecieveAndSetOrderInfo("OCS0103U15", this.grdOrder_Apl);
                            }
                            #endregion

                            #region 放射線
                            if (this.layXrtOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "07";
                                this.INPUTTAB = "07";
                                this.mOrderDate = this.dtpNaewonDate.GetDataValue();
                                //MakeDoOrderGrouping2(this.layXrtOrder_Do, this.layXrtOrder, this.grdOrder_Xrt, "07", "OCS0103U16", "xrt");
                                this.ApplyCopyOrderInfoXrt(this.layXrtOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Xrt);
                                this.RecieveAndSetOrderInfo("OCS0103U16", this.grdOrder_Xrt);
                            }
                            #endregion

                            #region 処置
                            if (this.layChuchiOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "08";
                                this.INPUTTAB = "08";
                                this.mOrderDate = this.dtpNaewonDate.GetDataValue();
                                //MakeDoOrderGrouping2(this.layChuchiOrder_Do, this.layChuchiOrder, this.grdOrder_Chuchi, "08", "OCS0103U17", "chuchi");
                                this.ApplyCopyOrderInfoChuchi(this.layChuchiOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Chuchi);
                                this.RecieveAndSetOrderInfo("OCS0103U17", this.grdOrder_Chuchi);
                            }
                            #endregion

                            #region 手術
                            if (this.laySusulOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "09";
                                this.INPUTTAB = "09";
                                this.mOrderDate = this.dtpNaewonDate.GetDataValue();
                                //MakeDoOrderGrouping2(this.laySusulOrder_Do, this.laySusulOrder, this.grdOrder_Susul, "09", "OCS0103U18", "susul");
                                this.ApplyCopyOrderInfoSusul(this.laySusulOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Susul);
                                this.RecieveAndSetOrderInfo("OCS0103U18", this.grdOrder_Susul);
                            }
                            #endregion

                            // リハビリオーダ追加 2012/09/26
                            #region リハビリ
                            if (this.layRehaOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "10";
                                this.INPUTTAB = "10";
                                this.mOrderDate = this.dtpNaewonDate.GetDataValue();
                                this.ApplyCopyOrderInfoReha(this.layRehaOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Reha);
                                this.RecieveAndSetOrderInfo("OCS0103U11", this.grdOrder_Reha);
                            }
                            #endregion

                            #region その他
                            if (this.layEtcOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "11";
                                this.INPUTTAB = "11";
                                this.mOrderDate = this.dtpNaewonDate.GetDataValue();
                                //MakeDoOrderGrouping2(this.layEtcOrder_Do, this.layEtcOrder, this.grdOrder_Etc, "11", "OCS0103U19", "etc");
                                this.ApplyCopyOrderInfoEtc(this.layEtcOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Etc);
                                this.RecieveAndSetOrderInfo("OCS0103U19", this.grdOrder_Etc);
                            }
                            #endregion

                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);

                        }
                    }

                    //2015-11-23: Kinki check
                    KinkiChecking(GetSetOrder(this.layDrugOrder_Do, this.layJusaOrder_Do));
                    break;
                    #endregion

                case "OCS0503U00":
                    // insert by jc [返事がない依頼件があるか確認してあれば点滅させて知らせる] 2012/11/09
                    //if (this.mOrderBiz.IsNoReturnConsult(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(),
                    //                                     this.dtpNaewonDate.GetDataValue(),
                    //                                     this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(),
                    //                                     UserInfo.DoctorID,
                    //                                     IO_Gubun))
                    //{
                    //    this.pbxIsNoConfirmOfReturnedConsult.Visible = true;
                    //}
                    //else
                    //    this.pbxIsNoConfirmOfReturnedConsult.Visible = false;
                    break;

                case "OCS0503U01":
                    // insert by jc [確認していない依頼があればあれば点滅させて知らせる] 2012/11/22
                    if (this.mOrderBiz.IsNoConfirmConsult(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(),
                                                         this.dtpNaewonDate.GetDataValue(),
                                                         this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(),
                                                         UserInfo.DoctorID,
                                                         IO_Gubun))
                    {
                        this.pbxIsNoAnwerOfConsulted.Visible = true;
                    }
                    else
                        this.pbxIsNoAnwerOfConsulted.Visible = false;
                    break;

                case "SCH0201Q12":
                    XMessageBox.Show("SCH0201Q12");
                    break;

            }
            return base.Command(command, commandParam);
        }

        #region[検体検査重複チェック]
        private bool IsDupleSpeciment(DataRow dr)
        {
            for (int i = 0; i < this.layCplOrder.RowCount; i++)
            {
                if (layCplOrder.LayoutTable.Rows[i]["hangmog_code"].ToString() == dr["hangmog_code"].ToString()
                    && layCplOrder.LayoutTable.Rows[i]["group_ser"].ToString() == dr["group_ser"].ToString()
                    && layCplOrder.LayoutTable.Rows[i]["acting_date"].ToString() == "")
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region [group_ser重複除去]
        private void SetSameOrderDateGroupSer(MultiLayout aLaySetData, MultiLayout aAddedData, string aInputTab)
        {
            bool isSameGroupSer = false;
            //[現在登録されているGROUP_SERリスト取得]

            for (int i = 0; i < aLaySetData.RowCount; i++)
            {
                isSameGroupSer = false;

                if (aAddedData.RowCount > 0)
                {
                    for (int j = 0; j < aAddedData.RowCount; j++)
                    {
                        if (aLaySetData.GetItemString(i, "group_ser") == aAddedData.GetItemString(j, "group_ser"))
                        {
                            isSameGroupSer = true;
                            break;
                        }
                    }

                    if (isSameGroupSer == true)
                    {
                        string str = aLaySetData.GetItemString(i, "group_ser");
                        int max_group_ser = (MaxGroup_ser(aInputTab, aAddedData)) + 1 > (MaxGroup_ser(aInputTab, aLaySetData)) + 1 ? (MaxGroup_ser(aInputTab, aAddedData)) + 1 : (MaxGroup_ser(aInputTab, aLaySetData)) + 1;
                        for (int k = 0; k < aAddedData.RowCount; k++)
                        {
                            if (aLaySetData.GetItemString(k, "group_ser") == str)
                            {
                                aLaySetData.SetItemValue(k, "group_ser", max_group_ser);
                                aLaySetData.AcceptData();
                            }
                        }
                    }
                }
                //else
                //{
                //    for (int j = i + 1; j < aLaySetData.RowCount; j++)
                //    {
                //        if (aLaySetData.GetItemString(i, "group_ser") == aAddedData.GetItemString(j, "group_ser"))
                //        {
                //            isSameGroupSer = true;
                //            break;
                //        }
                //    }

                //    if (isSameGroupSer == true)
                //    {
                //        string str = aLaySetData.GetItemString(i, "group_ser");
                //        int max_group_ser = (MaxGroup_ser("01", aAddedData)) + 1 > (MaxGroup_ser("01", aLaySetData)) + 1 ? (MaxGroup_ser("01", aAddedData)) + 1 : (MaxGroup_ser("01", aLaySetData)) + 1;
                //        for (int k = 0; k < aAddedData.RowCount; k++)
                //        {
                //            if (aLaySetData.GetItemString(k, "group_ser") == str)
                //            {
                //                aLaySetData.SetItemValue(k, "group_ser", max_group_ser);
                //                aLaySetData.AcceptData();
                //            }
                //        }
                //    }
                //}
            }

        }
        #endregion

        private int MaxGroup_ser(string aInput_tab, MultiLayout aLayout)
        {
            int max = 0;

            for (int i = 0; i < aLayout.RowCount; i++)
            {
                if (aInput_tab == aLayout.GetItemString(i, "input_tab") && max < int.Parse(aLayout.GetItemString(i, "group_ser")))
                {
                    max = int.Parse(aLayout.GetItemString(i, "group_ser"));
                }
            }

            return max;
        }

        #region 카피 오더의 경우 ( 카피, 셋트, Do 오더의 경우 )

        private void ApplyCopyOrderInfoDrug(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aExcutiveMode, XEditGrid grdOrder)
        {
            // HangmogInfoのパラメータ情報作成。（UserID, InputPart, InputGubun, INPUTTAB, IOEGUBUN, OrderDate, WonyoiOrderYN）
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;
            this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = "Y";

            ////一般名関連start
            //if (this.mGeneral_disp_yn == "Y" && this.mOrderBiz.IsGeneralYN(aHangmogCode) != "")
            //    this.mHangmogInfo.Parameter.GenericSearchYN = "Y";
            //else
            //    this.mHangmogInfo.Parameter.GenericSearchYN = this.mGenericSearchYN;

            //if (this.rbtGenericSearch.Checked == true || this.mHangmogInfo.Parameter.GenericSearchYN == "Y")
            //    this.mHangmogInfo.Parameter.Generic_name = this.mOrderBiz.IsGeneralYN(aHangmogCode);
            ////一般名end

            // OrderModeがSetOrder, CpSetOrderではない場合だけ患者情報（bunho, naewon_key, gubun, birth, gwa）をHangmogInfoにパラメータ追加する
            // SetOrder, CpSetOrderに患者情報が必要ではない理由は該当する情報が患者情報を元に作られてないので
            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.fbxBunho.GetDataValue();
                this.mHangmogInfo.Parameter.NaewonKey = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mClickedGubun;
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            // LoadHangmogInfoを通してHangmogInfoを取得
            if (this.mHangmogInfo.LoadHangmogInfo(aExcutiveMode, aSourceLayout) == false)
            {
                return;
            }
            // HangmogInfo格納
            MultiLayout layOrderData = this.mHangmogInfo.GetHangmogInfo;

            if (aExcutiveMode == HangmogInfo.ExecutiveMode.BeforeOrderCopy ||
                aExcutiveMode == HangmogInfo.ExecutiveMode.YaksokCopy ||
                aExcutiveMode == HangmogInfo.ExecutiveMode.RegularDrugCopy)
            {
                // 현재 커런트 그룹정보와 동일하지 않은 그룹정보의 오더가 존재 한다면

                // 동일 정보에 복용코드가 틀린 오더가 여러건 존재한다면...
                // 동일 그룹으로 머지 할건지...하니면 다른 그룹으로 분리할건지 결정한다.
                // 만일 멀티가 아니면? 현재그룹으로 강제 셋팅?

                // 정시약 ㅋㅏ피인경우는 정시약 테이블에 긴급여부와 워ㅜㄴ외처방여부 컬럼이 없기에
                // 현재 기준을 따라간다.
                // Set 오더 인경우는 bogyong_code, nalsu, 긴급, 원외 등의 값이 없는 경우는 현재 그룹에 맞추어 간다.
                if (aExcutiveMode == HangmogInfo.ExecutiveMode.YaksokCopy)
                {
                    for (int row = 0; row < layOrderData.RowCount; row++)
                    {
                        if (layOrderData.GetItemString(row, "bogyong_code") == "" && groupInfo.Contains("bogyong_code"))
                        {
                            layOrderData.SetItemValue(row, "bogyong_code", groupInfo["bogyong_code"]);
                        }

                        if (layOrderData.GetItemString(row, "nalsu") == "" && groupInfo.Contains("nalsu"))
                        {
                            layOrderData.SetItemValue(row, "nalsu", groupInfo["nalsu"]);
                        }

                        if (layOrderData.GetItemString(row, "emergency") == "" && groupInfo.Contains("emergency"))
                        {
                            layOrderData.SetItemValue(row, "emergency", groupInfo["emergency"]);
                        }

                        if (layOrderData.GetItemString(row, "wonyoi_order_yn") == "" && groupInfo.Contains("wonyoi_order_yn"))
                        {
                            layOrderData.SetItemValue(row, "wonyoi_order_yn", groupInfo["wonyoi_order_yn"]);
                        }
                    }
                }

                //if (aExcutiveMode == HangmogInfo.ExecutiveMode.BeforeOrderCopy)
                //{
                //    for (int i = 0; i < aSourceLayout.RowCount; i++)
                //    {
                //        layOrderData.SetItemValue(i, "donbog_yn", aSourceLayout.GetItemString(i, "donbog_yn"));
                //    }
                //}

            }

            // 머지여부
            // Do, SetオーダはisMergeが基本falseである


            // 인서트 후 포커스 로우
            this.mFocusRow = grdOrder.RowCount - 1 + layOrderData.RowCount;

            //Do,Setオーダは基本isMergeがfalseであるためここの下のロジックに乗る。
            this.ApplyDivideOrderInfo(aExcutiveMode, layOrderData, grdOrder, grdOrder.CurrentRowNumber);
        }

        private void ApplyCopyOrderInfoJusa(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aExcutiveMode, XEditGrid grdOrder)
        {
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder && this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
                this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = "Y";
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aExcutiveMode, aSourceLayout) == false)
            {
                return;
            }

            MultiLayout layOrderData = this.mHangmogInfo.GetHangmogInfo;

            if (aExcutiveMode == HangmogInfo.ExecutiveMode.BeforeOrderCopy ||
                aExcutiveMode == HangmogInfo.ExecutiveMode.YaksokCopy ||
                aExcutiveMode == HangmogInfo.ExecutiveMode.RegularDrugCopy)
            {
                // 현재 커런트 그룹정보와 동일하지 않은 그룹정보의 오더가 존재 한다면


                // 동일 정보에 복용코드가 틀린 오더가 여러건 존재한다면...
                // 동일 그룹으로 머지 할건지...하니면 다른 그룹으로 분리할건지 결정한다.
                // 만일 멀티가 아니면? 현재그룹으로 강제 셋팅?



                // Set 오더 인경우는 jusa, 긴급, 원외 등의 값이 없는 경우는 현재 그룹에 맞추어 간다.
                if (aExcutiveMode == HangmogInfo.ExecutiveMode.YaksokCopy)
                {
                    for (int row = 0; row < layOrderData.RowCount; row++)
                    {
                        if (layOrderData.GetItemString(row, "jusa") == "" && groupInfo.Contains("jusa"))
                        {
                            layOrderData.SetItemValue(row, "jusa", groupInfo["jusa"]);
                        }

                        if (layOrderData.GetItemString(row, "emergency") == "" && groupInfo.Contains("emergency"))
                        {
                            layOrderData.SetItemValue(row, "emergency", groupInfo["emergency"]);
                        }

                        if (layOrderData.GetItemString(row, "wonyoi_order_yn") == "" && groupInfo.Contains("wonyoi_order_yn"))
                        {
                            layOrderData.SetItemValue(row, "wonyoi_order_yn", groupInfo["wonyoi_order_yn"]);
                        }
                    }
                }
            }

            // 머지여부


            // 인서트 후 포커스 로우
            this.mFocusRow = grdOrder.RowCount - 1 + layOrderData.RowCount;

            this.ApplyDivideOrderInfoOther(layOrderData, grdOrder, grdOrder.CurrentRowNumber);

        }

        private void ApplyCopyOrderInfoCpl(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode, XEditGrid grdOrder)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo = new Hashtable();
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }

            if (grdOrder.RowCount < 1)
            {
                groupInfo = MakeNewOrderGroup(grdOrder, "cpl");
            }
            else
            {
                groupInfo["group_ser"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser");
                groupInfo["emergency"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "emergency");
                groupInfo["group_name"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser") + " グループ";
            }

            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(-1, grdOrder);
                settingStart = grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;

            // 그룹정보
            //groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            bool continueFlg = true;
            bool dspMsgFlg = false;

            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                //insert by jc START
                if (aMode == HangmogInfo.ExecutiveMode.BeforeOrderCopy
                    || HangmogInfo.ExecutiveMode.YaksokCopy == aMode
                    || HangmogInfo.ExecutiveMode.OrderCopy == aMode)
                {
                    for (int i = 0; i < grdOrder.RowCount; i++)
                    {
                        if (dr["hangmog_code"].ToString() == grdOrder.GetItemString(i, "hangmog_code")
                            && grdOrder.GetItemString(i, "acting_date") == ""
                            && dr["group_ser"].ToString() == grdOrder.GetItemString(i, "group_ser"))
                        {
                            continueFlg = false;
                            dspMsgFlg = true;
                        }
                    }

                }
                //insert by jc END
                if (continueFlg)
                {
                    emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

                    if (emptyNewCell == null)
                    {
                        this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder);
                        settingRow = grdOrder.CurrentRowNumber;
                    }
                    else
                    {
                        settingRow = emptyNewCell.Row;
                    }

                    // 긴급 관련
                    if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                    {
                        break;
                    }

                    foreach (DataColumn cl in grdOrder.LayoutTable.Columns)
                    {
                        if (groupInfo.Contains(cl.ColumnName))
                        {
                            grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                        }
                        else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                        {
                            if (cl.ColumnName != "child_gubun" &&
                                cl.ColumnName != "parent_gubun")
                                grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                        }
                    }

                    // 오더 구분 관련 
                    if (dr["order_gubun"].ToString().Length < 2)
                        grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString();
                    else
                        grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString().Substring(1, 1);

                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                    else
                        grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                    else
                        grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                    if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                    {
                        grdOrder.SetItemValue(settingRow, "child_yn", "N");
                        mParentInfo = new Hashtable();
                        mParentInfo.Add("row_num", settingRow);
                        mParentInfo.Add("key", dr["org_key"].ToString());

                        mParentList.Add(mParentInfo);
                    }
                    else
                    {
                        grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                    }

                    // 추후 오더소팅과 포커스와 관련 있는 컬럼
                    grdOrder.SetItemValue(settingRow, "dummy", "mageshin");
                    //insert by jc START
                    grdOrder.LayoutTable.Rows[settingRow]["dangil_gumsa_order_yn"] = dr["dangil_gumsa_order_yn"];
                    grdOrder.LayoutTable.Rows[settingRow]["dangil_gumsa_result_yn"] = dr["dangil_gumsa_result_yn"];
                    //insert by jc END
                }
                else
                    continueFlg = true;
            }
            //insert by jc
            if (dspMsgFlg)
                XMessageBox.Show(Resources.MSG024_MSG, Resources.MSG024_CAP);
            if (mParentList.Count > 0)
                this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList, grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        private void ApplyCopyOrderInfoPfe(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode, XEditGrid grdOrder)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo = new Hashtable();
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }
            //groupInfo = MakeNewOrderGroup(this.grdOrder_Pfe, "pfe");
            if (grdOrder.RowCount < 1)
            {
                groupInfo = MakeNewOrderGroup(grdOrder, "pfe");
            }
            else
            {
                groupInfo["group_ser"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser");
                groupInfo["emergency"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "emergency");
                groupInfo["group_name"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser") + " グループ";
            }

            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(-1, grdOrder);
                settingStart = grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;


            //foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder);
                    settingRow = grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                {
                    break;
                }

                foreach (DataColumn cl in grdOrder.LayoutTable.Columns)
                {
                    if (groupInfo.Contains(cl.ColumnName))
                    {
                        grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                    }
                    else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        if (cl.ColumnName != "child_gubun" &&
                            cl.ColumnName != "parent_gubun")
                            grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (dr["order_gubun"].ToString().Length < 2)
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString();
                else
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString().Substring(1, 1);

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "N");
                    mParentInfo = new Hashtable();
                    mParentInfo.Add("row_num", settingRow);
                    mParentInfo.Add("key", dr["org_key"].ToString());

                    mParentList.Add(mParentInfo);
                }
                else
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                }

                grdOrder.SetItemValue(settingRow, "dummy", "mageshin");
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList, grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));

        }

        private void ApplyCopyOrderInfoApl(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode, XEditGrid grdOrder)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo = new Hashtable();
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }
            //groupInfo = MakeNewOrderGroup(this.grdOrder_Apl, "apl");

            if (grdOrder.RowCount < 1)
            {
                groupInfo = MakeNewOrderGroup(grdOrder, "apl");
            }
            else
            {
                groupInfo["group_ser"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser");
                groupInfo["emergency"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "emergency");
                groupInfo["group_name"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser") + " グループ";
            }

            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(-1, grdOrder);
                settingStart = grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;

            // 그룹정보
            //groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            //foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder);
                    settingRow = grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                {
                    break;
                }

                foreach (DataColumn cl in grdOrder.LayoutTable.Columns)
                {
                    if (groupInfo.Contains(cl.ColumnName))
                    {
                        grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                    }
                    else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        if (cl.ColumnName != "child_gubun" &&
                            cl.ColumnName != "parent_gubun")
                            grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (dr["order_gubun"].ToString().Length < 2)
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString();
                else
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString().Substring(1, 1);

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "N");
                    mParentInfo = new Hashtable();
                    mParentInfo.Add("row_num", settingRow);
                    mParentInfo.Add("key", dr["org_key"].ToString());

                    mParentList.Add(mParentInfo);
                }
                else
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                }

                grdOrder.SetItemValue(settingRow, "dummy", "mageshin");
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList, grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        private void ApplyCopyOrderInfoXrt(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode, XEditGrid grdOrder)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo = new Hashtable();
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }
            //groupInfo = MakeNewOrderGroup(this.grdOrder_Xrt, "xrt");
            if (grdOrder.RowCount < 1)
            {
                groupInfo = MakeNewOrderGroup(grdOrder, "xrt");
            }
            else
            {
                groupInfo["group_ser"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser");
                groupInfo["emergency"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "emergency");
                groupInfo["group_name"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser") + " グループ";
            }
            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(-1, grdOrder);
                settingStart = grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;

            //foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder);
                    settingRow = grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                {
                    break;
                }

                foreach (DataColumn cl in grdOrder.LayoutTable.Columns)
                {
                    if (groupInfo.Contains(cl.ColumnName))
                    {
                        grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                    }
                    else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        if (cl.ColumnName != "child_gubun" &&
                            cl.ColumnName != "parent_gubun")
                            grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (dr["order_gubun"].ToString().Length < 2)
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString();
                else
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString().Substring(1, 1);

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "N");
                    mParentInfo = new Hashtable();
                    mParentInfo.Add("row_num", settingRow);
                    mParentInfo.Add("key", dr["org_key"].ToString());

                    mParentList.Add(mParentInfo);
                }
                else
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                }

                grdOrder.SetItemValue(settingRow, "dummy", "mageshin");
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList, grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        private void ApplyCopyOrderInfoChuchi(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode, XEditGrid grdOrder)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo = new Hashtable();
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }
            //groupInfo = MakeNewOrderGroup(this.grdOrder_Chuchi, "chuchi");
            if (grdOrder.RowCount < 1)
            {
                groupInfo = MakeNewOrderGroup(grdOrder, "chuchi");
            }
            else
            {
                groupInfo["group_ser"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser");
                groupInfo["emergency"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "emergency");
                groupInfo["group_name"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser") + " グループ";
            }
            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(-1, grdOrder);
                settingStart = grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;

            // 그룹정보
            //groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            //foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder);
                    settingRow = grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                {
                    break;
                }

                foreach (DataColumn cl in grdOrder.LayoutTable.Columns)
                {
                    if (groupInfo.Contains(cl.ColumnName))
                    {
                        grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                    }
                    else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        if (cl.ColumnName != "child_gubun" &&
                            cl.ColumnName != "parent_gubun")
                            grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (dr["order_gubun"].ToString().Length < 2)
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString();
                else
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString().Substring(1, 1);

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "N");
                    mParentInfo = new Hashtable();
                    mParentInfo.Add("row_num", settingRow);
                    mParentInfo.Add("key", dr["org_key"].ToString());

                    mParentList.Add(mParentInfo);
                }
                else
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                }

                grdOrder.SetItemValue(settingRow, "dummy", "mageshin");
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList, grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        private void ApplyCopyOrderInfoSusul(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode, XEditGrid grdOrder)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo = new Hashtable();
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }
            //groupInfo = MakeNewOrderGroup(this.grdOrder_Susul, "susul");
            if (grdOrder.RowCount < 1)
            {
                groupInfo = MakeNewOrderGroup(grdOrder, "susul");
            }
            else
            {
                groupInfo["group_ser"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser");
                groupInfo["emergency"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "emergency");
                groupInfo["group_name"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser") + " グループ";
            }
            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(-1, grdOrder);
                settingStart = grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;

            // 그룹정보
            //groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            //foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder);
                    settingRow = grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                {
                    break;
                }

                foreach (DataColumn cl in grdOrder.LayoutTable.Columns)
                {
                    if (groupInfo.Contains(cl.ColumnName))
                    {
                        grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                    }
                    else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        if (cl.ColumnName != "child_gubun" &&
                            cl.ColumnName != "parent_gubun")
                            grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (dr["order_gubun"].ToString().Length < 2)
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString();
                else
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString().Substring(1, 1);

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "N");
                    mParentInfo = new Hashtable();
                    mParentInfo.Add("row_num", settingRow);
                    mParentInfo.Add("key", dr["org_key"].ToString());

                    mParentList.Add(mParentInfo);
                }
                else
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                }

                grdOrder.SetItemValue(settingRow, "dummy", "mageshin");
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList, grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        private void ApplyCopyOrderInfoEtc(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode, XEditGrid grdOrder)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo = new Hashtable();
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }

            if (grdOrder.RowCount < 1)
            {
                groupInfo = MakeNewOrderGroup(grdOrder, "etc");
            }
            else
            {
                groupInfo["group_ser"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser");
                groupInfo["emergency"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "emergency");
                groupInfo["group_name"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser") + " グループ";
            }
            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(-1, grdOrder);
                settingStart = grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;

            // 그룹정보
            //groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            //foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder);
                    settingRow = grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                {
                    break;
                }

                foreach (DataColumn cl in grdOrder.LayoutTable.Columns)
                {
                    if (groupInfo.Contains(cl.ColumnName))
                    {
                        grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                    }
                    else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        if (cl.ColumnName != "child_gubun" &&
                            cl.ColumnName != "parent_gubun")
                            grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (dr["order_gubun"].ToString().Length < 2)
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString();
                else
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString().Substring(1, 1);

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "N");
                    mParentInfo = new Hashtable();
                    mParentInfo.Add("row_num", settingRow);
                    mParentInfo.Add("key", dr["org_key"].ToString());

                    mParentList.Add(mParentInfo);
                }
                else
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                }

                grdOrder.SetItemValue(settingRow, "dummy", "mageshin");
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList, grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        #endregion


        private void ApplyCopyOrderInfoReha(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode, XEditGrid grdOrder)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo = new Hashtable();
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }

            if (grdOrder.RowCount < 1)
            {
                groupInfo = MakeNewOrderGroup(grdOrder, "reha");
            }
            else
            {
                groupInfo["group_ser"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser");
                groupInfo["emergency"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "emergency");
                groupInfo["group_name"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser") + " グループ";
            }
            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(-1, grdOrder);
                settingStart = grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;

            // 그룹정보
            //groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            //foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder);
                    settingRow = grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                {
                    break;
                }

                foreach (DataColumn cl in grdOrder.LayoutTable.Columns)
                {
                    if (groupInfo.Contains(cl.ColumnName))
                    {
                        grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                    }
                    else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        if (cl.ColumnName != "child_gubun" &&
                            cl.ColumnName != "parent_gubun")
                            grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (dr["order_gubun"].ToString().Length < 2)
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString();
                else
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString().Substring(1, 1);

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "N");
                    mParentInfo = new Hashtable();
                    mParentInfo.Add("row_num", settingRow);
                    mParentInfo.Add("key", dr["org_key"].ToString());

                    mParentList.Add(mParentInfo);
                }
                else
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                }

                grdOrder.SetItemValue(settingRow, "dummy", "mageshin");

                // 依頼書作成中保存せず閉じたとしたらPHY8002 テーブルに FK_OCS キーがないため キーがないと保存してないと見なし、オーダを生成しない。
                string pkocskey = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocskey");
                //                string str = @"SELECT A.FK_OCS
                //                                 FROM PHY8002 A 
                //                                WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"' 
                //                                  AND A.FK_OCS = " + pkocskey;
                //                object obj = Service.ExecuteScalar(str);

                // Connect cloud
                OcsoOCS1003P01CheckFkOcsArgs args = new OcsoOCS1003P01CheckFkOcsArgs();
                args.FkOcs = pkocskey;
                OcsoOCS1003P01CheckFkOcsResult result = CloudService.Instance.Submit<OcsoOCS1003P01CheckFkOcsResult, OcsoOCS1003P01CheckFkOcsArgs>(args);

                if (this.mOrderMode != OrderVariables.OrderMode.SetOrder
                    && this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
                {
                    if (result != null)
                    {
                        if (result.FkOcs == null && grdOrder.GetItemString(settingRow, "specific_comment") != "")
                            grdOrder.DeleteRow(grdOrder.CurrentRowNumber);
                    }
                }
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList, grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        #region 오더코드 그리드에 셋팅

        #region 카피오더중 현재 그룹으로 합치지 않고 나누어 지는경우의 셋팅

        private void ApplyDivideOrderInfo(HangmogInfo.ExecutiveMode aExecutiveMode, MultiLayout aSourceLayout, XEditGrid aDestGrid, int aRowNumber)
        {
            string ordergubunname = "";  // 헤더를 붙인 오더구분을 넣는다.
            int currRow = aRowNumber;
            int startRow = aRowNumber;
            Hashtable currGroupInfo;
            int cnt = 0;

            if (aSourceLayout.RowCount <= 0) return;

            // 먼저 넘어온 데이터에서 그룹정보만을 셋팅 한다.
            #region
            string aCurrBogyongCode = "";
            string aCurrNalsu = "";
            string aCurrEmergency = "";
            string aCurrWonyoiOrderYn = "";
            string aCurrGroupSer = "";

            Hashtable groupInfo;
            ArrayList groupInfoList = new ArrayList();
            bool isAddGroupInfo = true;
            foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            {
                if (dr.Table.Columns.Contains("group_ser") && dr["group_ser"].ToString() != "")
                {
                    if (dr["bogyong_code"].ToString() != aCurrBogyongCode ||
                        dr["nalsu"].ToString() != aCurrNalsu ||
                        dr["emergency"].ToString() != aCurrEmergency ||
                        dr["wonyoi_order_yn"].ToString() != aCurrWonyoiOrderYn ||
                        dr["group_ser"].ToString() != aCurrGroupSer)
                    {
                        //[groupInfoList全体をもう一度検索して同じgroupInfoがあるか確認する]
                        for (int i = 0; i < groupInfoList.Count; i++)
                        {
                            if (((Hashtable)groupInfoList[i])["group_ser"].ToString() == dr["group_ser"].ToString()
                                && ((Hashtable)groupInfoList[i])["bogyong_code"].ToString() == dr["bogyong_code"].ToString()
                                && ((Hashtable)groupInfoList[i])["nalsu"].ToString() == dr["nalsu"].ToString()
                                && ((Hashtable)groupInfoList[i])["emergency"].ToString() == dr["emergency"].ToString()
                                && ((Hashtable)groupInfoList[i])["wonyoi_order_yn"].ToString() == dr["wonyoi_order_yn"].ToString())
                            {
                                isAddGroupInfo = false;
                            }
                        }

                        if (isAddGroupInfo)
                        {
                            groupInfo = new Hashtable();

                            groupInfo.Add("bogyong_code", dr["bogyong_code"].ToString());
                            groupInfo.Add("nalsu", dr["nalsu"].ToString());
                            groupInfo.Add("emergency", dr["emergency"].ToString());
                            groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());
                            groupInfo.Add("group_ser", dr["group_ser"].ToString());
                            groupInfo.Add("bogyong_name", dr["bogyong_name"].ToString());

                            groupInfoList.Add(groupInfo);

                            aCurrBogyongCode = dr["bogyong_code"].ToString();
                            aCurrNalsu = dr["nalsu"].ToString();
                            aCurrEmergency = dr["emergency"].ToString();
                            aCurrWonyoiOrderYn = dr["wonyoi_order_yn"].ToString();
                            aCurrGroupSer = dr["group_ser"].ToString();
                        }
                        isAddGroupInfo = true;
                    }
                }
                else
                {
                    if (dr["bogyong_code"].ToString() != aCurrBogyongCode ||
                        dr["nalsu"].ToString() != aCurrNalsu ||
                        dr["emergency"].ToString() != aCurrEmergency ||
                        dr["wonyoi_order_yn"].ToString() != aCurrWonyoiOrderYn)
                    {
                        groupInfo = new Hashtable();

                        groupInfo.Add("bogyong_code", dr["bogyong_code"].ToString());
                        groupInfo.Add("nalsu", dr["nalsu"].ToString());
                        groupInfo.Add("emergency", dr["emergency"].ToString());
                        groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());
                        groupInfo.Add("bogyong_name", dr["bogyong_name"].ToString());

                        groupInfoList.Add(groupInfo);

                        aCurrBogyongCode = dr["bogyong_code"].ToString();
                        aCurrNalsu = dr["nalsu"].ToString();
                        aCurrEmergency = dr["emergency"].ToString();
                        aCurrWonyoiOrderYn = dr["wonyoi_order_yn"].ToString();

                    }
                }
            }

            #endregion

            #region 그룹 정보를 돌면서 셋팅한다.
            int groupInfoCnt = 0;
            foreach (Hashtable info in groupInfoList)
            {
                string filter = "";
                if (info.Contains("group_ser"))
                {
                    filter = "bogyong_code='" + info["bogyong_code"].ToString() + "' AND " +
                             "nalsu=" + info["nalsu"].ToString() + " AND " +
                             "emergency='" + info["emergency"].ToString() + "' AND " +
                             "wonyoi_order_yn='" + info["wonyoi_order_yn"].ToString() + "' AND " +
                             "group_ser='" + info["group_ser"].ToString() + "'";
                }
                else
                {
                    filter = "bogyong_code='" + info["bogyong_code"].ToString() + "' AND " +
                             "nalsu=" + info["nalsu"].ToString() + " AND " +
                             "emergency='" + info["emergency"].ToString() + "' AND " +
                             "wonyoi_order_yn='" + info["wonyoi_order_yn"].ToString() + "'";
                }

                DataRow[] rows = aSourceLayout.LayoutTable.Select(filter);

                // 커런트 그룹정보가 동일한지 여부
                //    - 커런트 그룹이 아직 복용코드 정보가 입력되지 않은 경우는 현재 그룹정보를 
                //      지금 그룹으로 변경해 버린다.
                //    - 그렇지 않은 경우는 새 그룹 생성

                //if (this.fbxBogyongCode.GetDataValue() == "" && this.mOrderFunc.IsEmptyGroup(aDestGrid, this.groupInfo))
                //{
                //    // 그룹정보 맞추기
                //    this.cboNalsu.SetDataValue(info["nalsu"].ToString());
                //    this.cbxEmergency.SetDataValue(info["emergency"].ToString());
                //    this.cbxWonyoiOrderYN.SetDataValue(info["wonyoi_order_yn"].ToString());
                //    this.fbxBogyongCode.SetEditValue(info["bogyong_code"].ToString());
                //    this.fbxBogyongCode.AcceptData();
                //}

                //if (this.IsSameCurrentGroupInfo(info["bogyong_code"].ToString(), info["nalsu"].ToString(), info["emergency"].ToString(), info["wonyoi_order_yn"].ToString()) == false)
                //{
                //    // 신규 그룹생성
                //    this.btnList.PerformClick(FunctionType.Process);
                //    // 그룹정보 맞추기
                //    this.cboNalsu.SetDataValue(info["nalsu"].ToString());
                //    this.cbxEmergency.SetDataValue(info["emergency"].ToString());
                //    this.cbxWonyoiOrderYN.SetDataValue(info["wonyoi_order_yn"].ToString());
                //    this.fbxBogyongCode.SetEditValue(info["bogyong_code"].ToString());
                //    this.fbxBogyongCode.AcceptData();
                //}

                //신규 그룹생성
                //this.btnList.PerformClick(FunctionType.Process);
                ////그룹정보 맞추기
                //this.cboNalsu.SetDataValue(info["nalsu"].ToString());
                //this.cbxEmergency.SetDataValue(info["emergency"].ToString());
                //this.cbxWonyoiOrderYN.SetDataValue(info["wonyoi_order_yn"].ToString());
                //this.fbxBogyongCode.SetEditValue(info["bogyong_code"].ToString());
                //this.fbxBogyongCode.AcceptData();


                groupInfo = MakeNewOrderGroup(this.grdOrder_Drug, "drug");
                groupInfo["nalsu"] = ((Hashtable)groupInfoList[cnt])["nalsu"].ToString();
                groupInfo["emergency"] = ((Hashtable)groupInfoList[cnt])["emergency"].ToString();
                groupInfo["wonyoi_order_yn"] = ((Hashtable)groupInfoList[cnt])["wonyoi_order_yn"].ToString();
                groupInfo["bogyong_code"] = ((Hashtable)groupInfoList[cnt])["bogyong_code"].ToString();
                groupInfo["bogyong_name"] = ((Hashtable)groupInfoList[cnt++])["bogyong_name"].ToString();



                if (currRow < 0)
                {
                    this.OrderGridCreateNewRow(-1, aDestGrid);
                    currRow = aDestGrid.CurrentRowNumber;
                    startRow = aDestGrid.CurrentRowNumber;
                }
                else
                {
                    XCell newCell = this.mOrderFunc.GetEmptyNewRow(aDestGrid);

                    if (newCell != null)
                    {
                        currRow = newCell.Row;
                        startRow = newCell.Row;
                    }
                    else
                    {
                        this.OrderGridCreateNewRow(-1, aDestGrid);
                        currRow = aDestGrid.CurrentRowNumber;
                        startRow = aDestGrid.CurrentRowNumber;
                    }
                }

                for (int i = 0; i < rows.Length; i++)
                {

                    if (i != 0)
                    {
                        this.OrderGridCreateNewRow(-1, aDestGrid);
                        currRow = aDestGrid.CurrentRowNumber;
                    }

                    if (IsExistDifferntDrugGroup(groupInfo["group_ser"].ToString(), rows[i]["order_gubun_bas"].ToString(), aDestGrid) == true)
                    {
                        //같은그룹에 외용약과 내복약은 혼재할 수 없습니다.
                        MessageBox.Show(XMsg.GetMsg("M009"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        aDestGrid.DeleteRow(aDestGrid.CurrentRowNumber);
                        return;
                    }

                    // 긴급 관련
                    if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, aSourceLayout.LayoutTable.Rows[i]) == false)
                    {
                        return;
                    }

                    foreach (DataColumn cl in aDestGrid.LayoutTable.Columns)
                    {
                        // 그룹정보내의 정보이면 그룹정보에서 가져가고
                        if (cl.ColumnName != "dv" && cl.ColumnName != "dv_time" && groupInfo.Contains(cl.ColumnName))
                        {
                            aDestGrid.LayoutTable.Rows[currRow][cl.ColumnName] = groupInfo[cl.ColumnName].ToString();
                        }
                        // 아닌것들은 로우에서 가져간다.
                        else if (aSourceLayout.LayoutTable.Columns.Contains(cl.ColumnName))
                        {
                            aDestGrid.LayoutTable.Rows[currRow][cl.ColumnName] = rows[i][cl.ColumnName];
                        }
                    }

                    // 입원인경우 nday_yn 셋팅 
                    if (this.IO_Gubun == "I")
                    {
                        string nalsu = aDestGrid.LayoutTable.Rows[currRow]["nalsu"].ToString();

                        if (TypeCheck.IsInt(nalsu) && int.Parse(nalsu) > 1)
                        {
                            aDestGrid.LayoutTable.Rows[currRow]["nday_yn"] = "Y";
                        }
                        else
                        {
                            aDestGrid.LayoutTable.Rows[currRow]["nday_yn"] = "N";
                        }
                    }

                    // 오더 구분 관련 
                    if (rows[i]["order_gubun"].ToString().Length < 2)
                        aDestGrid.LayoutTable.Rows[currRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, aDestGrid, currRow) + rows[i]["order_gubun"].ToString();
                    else
                        aDestGrid.LayoutTable.Rows[currRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, aDestGrid, currRow) + rows[i]["order_gubun"].ToString().Substring(1, 1);

                    // 외용이냐 내복이냐에 따라 일수표시에 대산 부분이 visible Setting 
                    // 현재 화면이 외래 모드인경우만 인서트     
                    if (IOEGUBUN == "O")
                        aDestGrid.LayoutTable.Rows[currRow]["jundal_table"] = rows[i]["jundal_table_out"].ToString();
                    else
                        aDestGrid.LayoutTable.Rows[currRow]["jundal_table"] = rows[i]["jundal_table_inp"].ToString();

                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        aDestGrid.LayoutTable.Rows[currRow]["jundal_part"] = rows[i]["jundal_part_out"].ToString();
                    else
                        aDestGrid.LayoutTable.Rows[currRow]["jundal_part"] = rows[i]["jundal_part_inp"].ToString();

                    //insert by jc 2013/01/11
                    // 돈복, 내용, 외용에 따른 dv_time 셋팅 이건 강제 셋팅 하자...
                    //if (aExecutiveMode != HangmogInfo.ExecutiveMode.BeforeOrderCopy &&
                    //    aExecutiveMode != HangmogInfo.ExecutiveMode.YaksokCopy &&
                    //    aExecutiveMode != HangmogInfo.ExecutiveMode.OrderCopy)
                    //{
                    //    if (aDestGrid.LayoutTable.Rows[currRow]["order_gubun"].ToString().Substring(1, 1) == "C")
                    //    {
                    //        if (this.groupInfo.Contains("donbog_yn") && this.groupInfo["donbog_yn"].ToString() == "Y")
                    //        {
                    //            aDestGrid.LayoutTable.Rows[currRow]["dv_time"] = "*";
                    //        }
                    //        else
                    //        {
                    //            aDestGrid.LayoutTable.Rows[currRow]["dv_time"] = "/";
                    //        }
                    //    }
                    //    else
                    //    {
                    //        aDestGrid.LayoutTable.Rows[currRow]["dv_time"] = "*";
                    //    }
                    //}

                    aDestGrid.DisplayData();

                    //if (this.tabGroup.SelectedTab.Tag != null)
                    //    this.ApplyGroupInfoToRow((Hashtable)this.tabGroup.SelectedTab.Tag, currRow);

                    this.mFocusRow = currRow;
                }

                this.mHangmogInfo.SetAlignMixGroup(aDestGrid, startRow, currRow);

                aDestGrid.DisplayData();

                //this.SetOrderImage(aDestGrid);

                // 외용, 내복에 따른 변경부분셋팅
                //this.SetGroupControlVisible(this.groupInfo["group_ser"].ToString());
                aDestGrid.AcceptData();
            }

            #endregion
        }

        #endregion

        #endregion

        #region 오더코드 그리드에 셋팅 주사

        #region 카피오더중 현재 그룹으로 합치지 않고 나누어 지는경우의 셋팅 注射

        private void ApplyDivideOrderInfoOther(MultiLayout aSourceLayout, XEditGrid aDestGrid, int aRowNumber)
        {
            string ordergubunname = "";  // 헤더를 붙인 오더구분을 넣는다.
            int currRow = aRowNumber;
            int startRow = aRowNumber;
            int cnt = 0;
            if (aSourceLayout.RowCount <= 0) return;

            // 먼저 넘어온 데이터에서 그룹정보만을 셋팅 한다.
            #region
            string aJusa = "";
            string aCurrNalsu = "";
            string aCurrEmergency = "";
            string aCurrWonyoiOrderYn = "";
            string aCurrGroupSer = "";

            Hashtable groupInfo;
            ArrayList groupInfoList = new ArrayList();
            bool isAddGroupInfo = true;
            foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            {
                if (dr.Table.Columns.Contains("group_ser") && dr["group_ser"].ToString() != "")
                {
                    if (dr["jusa"].ToString() != aJusa ||
                        dr["nalsu"].ToString() != aCurrNalsu ||
                        dr["emergency"].ToString() != aCurrEmergency ||
                        dr["wonyoi_order_yn"].ToString() != aCurrWonyoiOrderYn ||
                        dr["group_ser"].ToString() != aCurrGroupSer)
                    {
                        //[groupInfoList全体をもう一度検索して同じgroupInfoがあるか確認する]
                        for (int i = 0; i < groupInfoList.Count; i++)
                        {
                            if (((Hashtable)groupInfoList[i])["group_ser"].ToString() == dr["group_ser"].ToString()
                                && ((Hashtable)groupInfoList[i])["jusa"].ToString() == dr["jusa"].ToString()
                                && ((Hashtable)groupInfoList[i])["nalsu"].ToString() == dr["nalsu"].ToString()
                                && ((Hashtable)groupInfoList[i])["emergency"].ToString() == dr["emergency"].ToString()
                                && ((Hashtable)groupInfoList[i])["wonyoi_order_yn"].ToString() == dr["wonyoi_order_yn"].ToString())
                            {
                                isAddGroupInfo = false;
                            }
                        }

                        if (isAddGroupInfo)
                        {
                            groupInfo = new Hashtable();

                            groupInfo.Add("jusa", dr["jusa"].ToString());
                            groupInfo.Add("nalsu", dr["nalsu"].ToString());
                            groupInfo.Add("emergency", dr["emergency"].ToString());
                            groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());
                            groupInfo.Add("group_ser", dr["group_ser"].ToString());
                            groupInfo.Add("jusa_name", dr["jusa_name"].ToString());

                            groupInfoList.Add(groupInfo);

                            aJusa = dr["jusa"].ToString();
                            aCurrNalsu = dr["nalsu"].ToString();
                            aCurrEmergency = dr["emergency"].ToString();
                            aCurrWonyoiOrderYn = dr["wonyoi_order_yn"].ToString();
                            aCurrGroupSer = dr["group_ser"].ToString();
                        }
                    }
                }
                else
                {
                    if (dr["jusa"].ToString() != aJusa ||
                        dr["nalsu"].ToString() != aCurrNalsu ||
                        dr["emergency"].ToString() != aCurrEmergency ||
                        dr["wonyoi_order_yn"].ToString() != aCurrWonyoiOrderYn)
                    {
                        groupInfo = new Hashtable();

                        groupInfo.Add("jusa", dr["jusa"].ToString());
                        groupInfo.Add("nalsu", dr["nalsu"].ToString());
                        groupInfo.Add("emergency", dr["emergency"].ToString());
                        groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());
                        groupInfo.Add("jusa_name", dr["jusa_name"].ToString());

                        groupInfoList.Add(groupInfo);

                        aJusa = dr["jusa"].ToString();
                        aCurrNalsu = dr["nalsu"].ToString();
                        aCurrEmergency = dr["emergency"].ToString();
                        aCurrWonyoiOrderYn = dr["wonyoi_order_yn"].ToString();
                    }
                }
            }

            #endregion

            #region 그룹 정보를 돌면서 셋팅한다.

            foreach (Hashtable info in groupInfoList)
            {
                string filter = "";
                if (info.Contains("group_ser"))
                {
                    filter = "jusa='" + info["jusa"].ToString() + "' AND " +
                             "nalsu=" + info["nalsu"].ToString() + " AND " +
                             "emergency='" + info["emergency"].ToString() + "' AND " +
                             "wonyoi_order_yn='" + info["wonyoi_order_yn"].ToString() + "' AND " +
                             "group_ser=" + info["group_ser"].ToString();
                }
                else
                {
                    filter = "jusa='" + info["jusa"].ToString() + "' AND " +
                             "nalsu=" + info["nalsu"].ToString() + " AND " +
                             "emergency='" + info["emergency"].ToString() + "' AND " +
                             "wonyoi_order_yn='" + info["wonyoi_order_yn"].ToString() + "'";
                }

                DataRow[] rows = aSourceLayout.LayoutTable.Select(filter);

                // 커런트 그룹정보가 동일한지 여부
                //    - 커런트 그룹이 아직 복용코드 정보가 입력되지 않은 경우는 현재 그룹정보를 
                //      지금 그룹으로 변경해 버린다.
                //    - 그렇지 않은 경우는 새 그룹 생성

                //if (this.fbxJusa.GetDataValue() == "" && this.mOrderFunc.IsEmptyGroup(this.grdOrder, (((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"]).ToString()))
                //{
                //    // 그룹정보 맞추기
                //    this.cboNalsu.SelectedValueChanged -= new EventHandler(cboNalsu_SelectedValueChanged);
                //    this.cboNalsu.SetDataValue(info["nalsu"].ToString());
                //    this.cboNalsu.SelectedValueChanged += new EventHandler(cboNalsu_SelectedValueChanged);
                //    this.cbxEmergency.SetDataValue(info["emergency"].ToString());
                //    this.cbxWonyoiOrderYN.SetDataValue(info["wonyoi_order_yn"].ToString());
                //    this.fbxJusa.SetEditValue(info["jusa"].ToString());
                //    this.fbxJusa.AcceptData();
                //}



                // 신규 그룹생성
                //this.btnList.PerformClick(FunctionType.Process);
                //// 그룹정보 맞추기
                //this.cboNalsu.SelectedValueChanged -= new EventHandler(cboNalsu_SelectedValueChanged);
                //this.cboNalsu.SetDataValue(info["nalsu"].ToString());
                //this.cboNalsu.SelectedValueChanged += new EventHandler(cboNalsu_SelectedValueChanged);
                //this.cbxEmergency.SetDataValue(info["emergency"].ToString());
                //this.cbxWonyoiOrderYN.SetDataValue(info["wonyoi_order_yn"].ToString());

                //groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

                //if (info["jusa"].ToString() != "")
                //{
                //    this.fbxJusa.SetEditValue(info["jusa"].ToString());
                //    this.fbxJusa.AcceptData();
                //}

                groupInfo = MakeNewOrderGroup(this.grdOrder_Jusa, "jusa");
                groupInfo["nalsu"] = ((Hashtable)groupInfoList[cnt])["nalsu"].ToString();
                groupInfo["emergency"] = ((Hashtable)groupInfoList[cnt])["emergency"].ToString();
                groupInfo["wonyoi_order_yn"] = ((Hashtable)groupInfoList[cnt])["wonyoi_order_yn"].ToString();
                groupInfo["jusa"] = ((Hashtable)groupInfoList[cnt])["jusa"].ToString();
                groupInfo["jusa_name"] = ((Hashtable)groupInfoList[cnt++])["jusa_name"].ToString();

                if (currRow < 0)
                {
                    this.OrderGridCreateNewRow(-1, aDestGrid);
                    currRow = aDestGrid.CurrentRowNumber;
                    startRow = aDestGrid.CurrentRowNumber;
                }
                else
                {
                    XCell newCell = this.mOrderFunc.GetEmptyNewRow(aDestGrid);

                    if (newCell != null)
                    {
                        currRow = newCell.Row;
                        startRow = newCell.Row;
                    }
                    else
                    {
                        this.OrderGridCreateNewRow(-1, aDestGrid);
                        currRow = aDestGrid.CurrentRowNumber;
                        startRow = aDestGrid.CurrentRowNumber;
                    }
                }

                for (int i = 0; i < rows.Length; i++)
                {

                    if (i != 0)
                    {
                        this.OrderGridCreateNewRow(-1, aDestGrid);
                        currRow = aDestGrid.CurrentRowNumber;
                    }

                    // 긴급 관련
                    if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, aSourceLayout.LayoutTable.Rows[i]) == false)
                    {
                        return;
                    }

                    foreach (DataColumn cl in aDestGrid.LayoutTable.Columns)
                    {
                        // 그룹정보내의 정보이면 그룹정보에서 가져가고
                        if (groupInfo.Contains(cl.ColumnName))
                        {
                            aDestGrid.LayoutTable.Rows[currRow][cl.ColumnName] = groupInfo[cl.ColumnName].ToString();
                        }
                        // 아닌것들은 로우에서 가져간다.
                        else
                            if (aSourceLayout.LayoutTable.Columns.Contains(cl.ColumnName))
                            {
                                aDestGrid.LayoutTable.Rows[currRow][cl.ColumnName] = rows[i][cl.ColumnName];
                            }
                    }

                    // 오더 구분 관련 
                    if (rows[i]["order_gubun"].ToString().Length < 2)
                        aDestGrid.LayoutTable.Rows[currRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, aDestGrid, currRow) + rows[i]["order_gubun"].ToString();
                    else
                        aDestGrid.LayoutTable.Rows[currRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, aDestGrid, currRow) + rows[i]["order_gubun"].ToString().Substring(1, 1);

                    // 외용이냐 내복이냐에 따라 일수표시에 대산 부분이 visible Setting 
                    // 현재 화면이 외래 모드인경우만 인서트     
                    if (IOEGUBUN == "O")
                        aDestGrid.LayoutTable.Rows[currRow]["jundal_table"] = rows[i]["jundal_table_out"].ToString();
                    else
                        aDestGrid.LayoutTable.Rows[currRow]["jundal_table"] = rows[i]["jundal_table_inp"].ToString();

                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        aDestGrid.LayoutTable.Rows[currRow]["jundal_part"] = rows[i]["jundal_part_out"].ToString();
                    else
                        aDestGrid.LayoutTable.Rows[currRow]["jundal_part"] = rows[i]["jundal_part_inp"].ToString();

                    aDestGrid.DisplayData();


                }

                this.mHangmogInfo.SetAlignMixGroup(aDestGrid, startRow, currRow);

                aDestGrid.DisplayData();

                //this.SetOrderImage(aDestGrid);

            }

            #endregion
        }

        #endregion

        #endregion

        #region [Group情報同期化]

        private void ApplyGroupInfoToRow(Hashtable aExistGroupInfo, int aSetRowNumber, XEditGrid grdOrder)
        {
            string bogyongCode = "";
            string bogyongName = "";
            string dv = "";
            string nalsu = "";
            string emergency = "N";
            string wonyoi_order_yn = "N";
            string donbog_yn = "N";

            if (aExistGroupInfo.Contains("bogyong_code"))
            {
                bogyongCode = aExistGroupInfo["bogyong_code"].ToString();
            }
            if (aExistGroupInfo.Contains("bogyong_name"))
            {
                bogyongName = aExistGroupInfo["bogyong_name"].ToString();
            }
            if (aExistGroupInfo.Contains("dv"))
            {
                dv = aExistGroupInfo["dv"].ToString();
            }
            if (aExistGroupInfo.Contains("nalsu"))
            {
                nalsu = aExistGroupInfo["nalsu"].ToString();
            }
            if (aExistGroupInfo.Contains("emergency"))
            {
                emergency = aExistGroupInfo["emergency"].ToString();
            }
            if (aExistGroupInfo.Contains("wonyoi_order_yn"))
            {
                wonyoi_order_yn = aExistGroupInfo["wonyoi_order_yn"].ToString();
            }
            if (aExistGroupInfo.Contains("donbog_yn"))
            {
                donbog_yn = aExistGroupInfo["donbog_yn"].ToString();
            }

            // 접수하기 전의 오더만 가능
            // 주사방법을 기준으로 변경 가능한것만 그룹정보 업데이트 한다.
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder ||
                this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IO_Gubun, grdOrder, aSetRowNumber, "bogyong_code", OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay))
            {
                // 복용코드
                if (grdOrder.GetItemString(aSetRowNumber, "bogyong_code") != bogyongCode)
                {
                    grdOrder.SetItemValue(aSetRowNumber, "bogyong_code", bogyongCode);
                }

                // 복용법 명칭
                if (grdOrder.GetItemString(aSetRowNumber, "bogyong_name") != bogyongName)
                {
                    grdOrder.SetItemValue(aSetRowNumber, "bogyong_name", bogyongName);
                }

                // DV
                if (this.IsOutDrugGroup(aExistGroupInfo["group_ser"].ToString()) == false)
                {
                    if (dv != "" && grdOrder.GetItemString(aSetRowNumber, "dv") != dv)
                    {
                        grdOrder.SetItemValue(aSetRowNumber, "dv", dv);
                    }
                }

                // 날수
                if (grdOrder.GetItemString(aSetRowNumber, "nalsu") != nalsu)
                {
                    grdOrder.SetItemValue(aSetRowNumber, "nalsu", nalsu);
                }

                // 날수 셋팅에 따른 Nday_YN 설정.
                if (this.IO_Gubun == "O")
                {
                    if (TypeCheck.IsInt(nalsu) && int.Parse(nalsu) > 1)
                    {
                        grdOrder.SetItemValue(aSetRowNumber, "nday_yn", "Y");
                    }
                    else
                    {
                        grdOrder.SetItemValue(aSetRowNumber, "nday_yn", "N");
                    }
                }
                // 긴급
                if (grdOrder.GetItemString(aSetRowNumber, "emergency") != emergency)
                {
                    grdOrder.SetItemValue(aSetRowNumber, "emergency", emergency);
                }

                // 원외여부
                if (grdOrder.GetItemString(aSetRowNumber, "wonyoi_order_yn") != wonyoi_order_yn)
                {
                    grdOrder.SetItemValue(aSetRowNumber, "wonyoi_order_yn", wonyoi_order_yn);
                }

                // 돈복여부
                if (grdOrder.GetItemString(aSetRowNumber, "donbog_yn") != donbog_yn)
                {
                    grdOrder.SetItemValue(aSetRowNumber, "donbog_yn", donbog_yn);
                }
            }

            //this.MakePreviewStatus();
        }
        #endregion

        #region 외용약 내복약 같은 그룹에 혼재 방지용 체크

        private bool IsExistDifferntDrugGroup(string aGroupSer, string aOrderGubunBas, XEditGrid grdOrder)
        {
            for (int i = 0; i < grdOrder.RowCount; i++)
            {
                if (grdOrder.GetItemString(i, "order_gubun_bas") != "" &&
                    aOrderGubunBas != grdOrder.GetItemString(i, "order_gubun_bas") &&
                    aGroupSer == grdOrder.GetItemString(i, "group_ser"))
                {
                    if (i == grdOrder.CurrentRowNumber && grdOrder.GetItemString(i, "hangmog_code") == "")
                        continue;

                    return true;
                }
            }

            return false;
        }

        #endregion

        #region 오더 그리드 신규 로우 생성

        private void OrderGridCreateNewRow(int aRowNumber, XEditGrid grdOrder)
        {
            grdOrder.InsertRow(aRowNumber);

            // 그룹 기준 셋팅
            this.GridInitValueSetting(grdOrder, grdOrder.CurrentRowNumber);
        }

        #endregion

        #region 그리드 신규 로우 초기값 셋팅

        private void GridInitValueSetting(XEditGrid aGrid, int aRowNumber)
        {
            string temp = "";

            //if (tabGroup.SelectedTab == null) return;

            //Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            // 그룹시리얼 셋팅
            //if (groupInfo.Contains("group_ser"))
            //    aGrid.SetItemValue(aRowNumber, "group_ser", this.groupInfo["group_ser"].ToString());

            //// 복용코드
            //if (groupInfo.Contains("bogyong_code"))
            //    aGrid.SetItemValue(aRowNumber, "bogyong_code", this.groupInfo["bogyong_code"].ToString());

            //// 긴급
            //if (groupInfo.Contains("emergency"))
            //    aGrid.SetItemValue(aRowNumber, "emergency", this.groupInfo["emergency"].ToString());

            //// 원외처방
            //if (groupInfo.Contains("wonyoi_order_yn"))
            //    aGrid.SetItemValue(aRowNumber, "wonyoi_order_yn", this.groupInfo["wonyoi_order_yn"].ToString());

            // 환자정보
            if ((this.mOrderMode != OrderVariables.OrderMode.SetOrder && this.mOrderMode != OrderVariables.OrderMode.CpSetOrder) && this.mSelectedPatientInfo != null)
            {
                aGrid.SetItemValue(aRowNumber, "bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            }

            // 입력탭 정보
            aGrid.SetItemValue(aRowNumber, "input_tab", INPUTTAB);
            this.mOrderBiz.LoadColumnCodeName("code", "INPUT_TAB", INPUTTAB, ref temp);
            aGrid.SetItemValue(aRowNumber, "input_tab_name", temp);


            aGrid.SetItemValue(aRowNumber, "order_date", this.dtpNaewonDate.GetDataValue());
            aGrid.SetItemValue(aRowNumber, "input_part", this.mInputPart);

            aGrid.SetItemValue(aRowNumber, "input_gubun", this.iInputGubun);
            aGrid.SetItemValue(aRowNumber, "input_gubun_name", this.iInputGubunName);

            // 진료정보 ( 오더일자, 진료과, 의사 )
            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                if (UserInfo.UserGubun == UserType.Doctor)
                {
                    aGrid.SetItemValue(aRowNumber, "input_doctor", UserInfo.DoctorID);
                    aGrid.SetItemValue(aRowNumber, "input_gwa", UserInfo.Gwa);
                }
                else
                {
                    aGrid.SetItemValue(aRowNumber, "input_doctor", this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());
                    aGrid.SetItemValue(aRowNumber, "input_gwa", this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());

                    // 간호사인경우는 간호픽업 데이트를 자동입력한다.
                    if (UserInfo.UserGubun == UserType.Nurse)
                    {
                        aGrid.SetItemValue(aRowNumber, "nurse_pickup_user", UserInfo.UserID);
                        aGrid.SetItemValue(aRowNumber, "nurse_pickup_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                        aGrid.SetItemValue(aRowNumber, "nurse_pickup_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                    }
                }



                // 입력구분
                aGrid.SetItemValue(aRowNumber, "input_id", UserInfo.UserID);
                //aGrid.SetItemValue(aRowNumber, "input_part", this.mInputPart);

                //aGrid.SetItemValue(aRowNumber, "input_doctor", UserInfo.DoctorID);
                //aGrid.SetItemValue(aRowNumber, "input_gwa", UserInfo.Gwa);

                //aGrid.SetItemValue(aRowNumber, "order_date", this.dpkOrder_Date.GetDataValue());
                aGrid.SetItemValue(aRowNumber, "gwa", this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());
                aGrid.SetItemValue(aRowNumber, "doctor", this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());
                aGrid.SetItemValue(aRowNumber, "resident", this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

                // 접수및 입원정보
                if (this.IO_Gubun == "O")
                {
                    aGrid.SetItemValue(aRowNumber, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                }

                if (this.mOrderMode == OrderVariables.OrderMode.CpOrder)
                {
                    aGrid.SetItemValue(aRowNumber, "cp_code", this.mCpCode);
                    aGrid.SetItemValue(aRowNumber, "cp_path_code", this.mCpPathCode);
                    aGrid.SetItemValue(aRowNumber, "jaewonil", this.mJaewonil);
                    aGrid.SetItemValue(aRowNumber, "in_out_key", this.mCpMasterkey);
                }
                else
                {
                    // 접수 키
                    aGrid.SetItemValue(aRowNumber, "in_out_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
                }

            }
            // 셋트오더인경우
            else
            {
                if (this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
                    aGrid.SetItemValue(aRowNumber, "in_out_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

                aGrid.SetItemValue(aRowNumber, "input_gwa", UserInfo.Gwa);
                aGrid.SetItemValue(aRowNumber, "memb", this.mMemb);
                aGrid.SetItemValue(aRowNumber, "yaksok_code", this.mYaksokCode);

                if (this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
                {
                    aGrid.SetItemValue(aRowNumber, "memb_gubun", this.mMembGubun);
                    aGrid.SetItemValue(aRowNumber, "cp_code", this.mCpCode);
                    aGrid.SetItemValue(aRowNumber, "cp_path_code", this.mCpPathCode);
                    aGrid.SetItemValue(aRowNumber, "jaewonil", this.mJaewonil);
                }
            }

            // nday occur yn   n데이 오더 발생여부
            if (this.mInputPart == "01" || this.mInputPart == "03")
                aGrid.SetItemValue(aRowNumber, "nday_occur_yn", "N");
        }

        #endregion

        // 新規グループ作成
        private Hashtable MakeNewOrderGroup(MultiLayout aSourceLayout, string gubun)
        {
            Hashtable groupInfo = new Hashtable();

            //int groupSer = (this.mHangmogInfo.GetMaxGroupSer(aSourceLayout) + 1);
            string input_tab = "";
            switch (gubun)
            {
                case "drug":
                    input_tab = "01";
                    break;
                case "jusa":
                    input_tab = "03";
                    break;
                case "cpl":
                    input_tab = "04";
                    break;
                case "pfe":
                    input_tab = "05";
                    break;
                case "apl":
                    input_tab = "06";
                    break;
                case "xrt":
                    input_tab = "07";
                    break;
                case "chuchi":
                    input_tab = "08";
                    break;
                case "susul":
                    input_tab = "09";
                    break;
                case "etc":
                    input_tab = "10";
                    break;
                case "reha":
                    input_tab = "11";
                    break;
            }

            int groupSer = int.Parse(this.mHangmogInfo.GetNextGroupSer(input_tab
                                                                     , this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                                     , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                                                     , "OCS1003"));
            if (groupSer == 1)
            {
                switch (gubun)
                {
                    case "drug":
                        groupSer = 101;
                        break;
                    case "jusa":
                        groupSer = 301;
                        break;
                    case "cpl":
                        groupSer = 401;
                        break;
                    case "pfe":
                        groupSer = 501;
                        break;
                    case "apl":
                        groupSer = 601;
                        break;
                    case "xrt":
                        groupSer = 701;
                        break;
                    case "chuchi":
                        groupSer = 801;
                        break;
                    case "susul":
                        groupSer = 901;
                        break;
                    case "etc":
                        groupSer = 1001;
                        break;
                    case "reha":
                        groupSer = 1101;
                        break;
                }

            }
            switch (gubun)
            {
                case "drug":
                    groupInfo.Add("bogyong_code", "");
                    groupInfo.Add("bogyong_name", "");
                    groupInfo.Add("nalsu", "0");
                    groupInfo.Add("wonyoi_order_yn", "Y");
                    break;
                case "jusa":
                    groupInfo.Add("jusa", "");
                    groupInfo.Add("jusa_name", "");
                    groupInfo.Add("nalsu", "0");
                    groupInfo.Add("wonyoi_order_yn", "Y");
                    break;
                case "cpl":
                case "pfe":
                case "apl":
                case "xrt":
                case "chuchi":
                case "susul":
                case "etc":
                case "reha":
                    break;
            }
            groupInfo.Add("group_ser", groupSer);
            groupInfo.Add("group_name", groupSer.ToString() + " グループ");
            groupInfo.Add("emergency", "N");


            return groupInfo;
        }

        private Hashtable MakeNewOrderGroup(XEditGrid aSourceLayout, string gubun)
        {
            Hashtable groupInfo = new Hashtable();

            //int groupSer = (this.mHangmogInfo.GetMaxGroupSer(aSourceLayout) + 1);
            string input_tab = "";
            switch (gubun)
            {
                case "drug":
                    input_tab = "01";
                    break;
                case "jusa":
                    input_tab = "03";
                    break;
                case "cpl":
                    input_tab = "04";
                    break;
                case "pfe":
                    input_tab = "05";
                    break;
                case "apl":
                    input_tab = "06";
                    break;
                case "xrt":
                    input_tab = "07";
                    break;
                case "chuchi":
                    input_tab = "08";
                    break;
                case "susul":
                    input_tab = "09";
                    break;
                case "etc":
                    input_tab = "10";
                    break;
                case "reha":
                    input_tab = "11";
                    break;

            }

            int groupSer = int.Parse(this.mHangmogInfo.GetNextGroupSer(input_tab
                                                                     , this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                                     , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                                                     , "OCS1003"));
            if (groupSer == 1)
            {
                switch (gubun)
                {
                    case "drug":
                        groupSer = 101;
                        break;
                    case "jusa":
                        groupSer = 301;
                        break;
                    case "cpl":
                        groupSer = 401;
                        break;
                    case "pfe":
                        groupSer = 501;
                        break;
                    case "apl":
                        groupSer = 601;
                        break;
                    case "xrt":
                        groupSer = 701;
                        break;
                    case "chuchi":
                        groupSer = 801;
                        break;
                    case "susul":
                        groupSer = 901;
                        break;
                    case "etc":
                        groupSer = 1001;
                        break;
                    case "reha":
                        groupSer = 1101;
                        break;
                }

            }
            switch (gubun)
            {
                case "drug":
                    groupInfo.Add("bogyong_code", "");
                    groupInfo.Add("bogyong_name", "");
                    groupInfo.Add("nalsu", "0");
                    groupInfo.Add("wonyoi_order_yn", "Y");

                    break;
                case "jusa":
                    groupInfo.Add("jusa", "");
                    groupInfo.Add("jusa_name", "");
                    groupInfo.Add("nalsu", "0");
                    groupInfo.Add("wonyoi_order_yn", "Y");

                    break;
                case "cpl":
                case "pfe":
                case "apl":
                case "xrt":
                case "chuchi":
                case "susul":
                case "etc":
                case "reha":
                    break;
            }
            groupInfo.Add("group_ser", groupSer);
            groupInfo.Add("group_name", groupSer.ToString() + " グループ");
            groupInfo.Add("emergency", "N");

            return groupInfo;
        }
        /*
        private Hashtable MakeNewOrderGroup(MultiLayout aSourceLayout, string gubun, string aBogyong_code, string aBogyong_name, string aEmergency, string aNalsu, string aWonyoi_order_yn)
        {
            Hashtable groupInfo = new Hashtable();

            int groupSer = (this.mHangmogInfo.GetMaxGroupSer(aSourceLayout) + 1);
            if (groupSer == 1)
            {
                switch (gubun)
                {
                    case "drug":
                        groupSer = 101;
                        break;
                    case "jusa":
                        groupSer = 301;
                        break;
                    case "cpl":
                        groupSer = 401;
                        break;
                    case "pfe":
                        groupSer = 501;
                        break;
                    case "apl":
                        groupSer = 601;
                        break;
                    case "xrt":
                        groupSer = 701;
                        break;
                    case "chuchi":
                        groupSer = 801;
                        break;
                    case "susul":
                        groupSer = 901;
                        break;
                    case "etc":
                        groupSer = 1001;
                        break;
                }

            }

            groupInfo.Add("group_ser", groupSer);
            groupInfo.Add("group_name", groupSer.ToString() + " グループ");
            groupInfo.Add("bogyong_code", aBogyong_code);
            groupInfo.Add("bogyong_name", aBogyong_name);
            groupInfo.Add("emergency", aEmergency);
            groupInfo.Add("nalsu", aNalsu);
            groupInfo.Add("wonyoi_order_yn", aWonyoi_order_yn);

            return groupInfo;
        }
        */
        #region 현재 그룹이 내복약인지 외용약인지 여부

        private bool IsOutDrugGroup(string aGroupSer)
        {
            DataRow[] rows = this.grdOrder_Drug.LayoutTable.Select("group_ser=" + aGroupSer);

            if (rows.Length <= 0) return false;

            foreach (DataRow dr in rows)
            {
                if (dr["order_gubun"].ToString() != "" && dr["order_gubun"].ToString().Substring(1, 1) == "D")
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        //private void SetOrderImage(XEditGrid aGrid)
        //{
        //    // 의사가 입력하는 경우는 스킵
        //    if (this.iInputGubun.Substring(0, 1) == "D") return;

        //    for (int i = 0; i < aGrid.RowCount; i++)
        //    {
        //        // 의사 오더인경우
        //        if (aGrid.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
        //        {
        //            aGrid[i + aGrid.HeaderHeights.Count, 0].Image = this.ImageList.Images[8];
        //            aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText = "医師オーダ" + aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText;
        //        }
        //    }
        //}

        private void SetVisibleStatusBar(bool aIsVisible)
        {
            this.pnlStatus.Visible = aIsVisible;
        }
        private void InitStatusBar(int aMaxValue)
        {
            this.pgbProgress.Minimum = 0;
            this.pgbProgress.Maximum = aMaxValue;
            this.lbStatus.Text = "";
        }
        private void SetStatusBar(int aCurrentValue)
        {
            this.pgbProgress.Value = aCurrentValue;
            this.pgbProgress.Refresh();
            this.lbStatus.Text = aCurrentValue.ToString() + "/" + this.pgbProgress.Maximum.ToString();
            this.lbStatus.Refresh();
        }

        #region [환자정보 Reques/Receive Event]
        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            if (info != null && !TypeCheck.IsNull(info.BunHo))
            {
                //insert into yoonB 2012/03/03
                if (info.ScreenName == "OUT1101Q01")
                {
                    this.dtpNaewonDate.SetDataValue(info.HoDong);
                }

                this.fbxBunho.Focus();
                this.fbxBunho.SetEditValue(info.BunHo);
                this.fbxBunho.AcceptData();
                this.Focus();
            }
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(this.fbxBunho.GetDataValue()))
            {
                return new XPatientInfo(this.fbxBunho.GetDataValue(), this.lbSuname.Text, "", "", this.ScreenName);
            }

            return null;
        }
        #endregion

        #region [ 내시경 결과 조회 ]

        // 처방행삭제
        private void PopUpMenuPfeResult_Click(object sender, System.EventArgs e)
        {
            IHIS.X.Magic.Menus.MenuCommand menu = sender as IHIS.X.Magic.Menus.MenuCommand;

            string targetUrl = "";
            // TODO remove hardcode
            string serverIP = "192.168.150.114";
            //string serverIP = "localhost";

            //            string cmdText = @"SELECT A.CODE_NAME
            //                                 FROM OCS0132 A
            //                                WHERE A.CODE_TYPE   = 'SERVER_IP'
            //                                  AND A.CODE        = 'ENDO'
            //                                  AND A.HOSP_CODE   = '" + EnvironInfo.HospCode + "' "
            //                              ;

            //            object retVal = Service.ExecuteScalar(cmdText);

            // Connect cloud
            NuroNUR1001R98PageCountArgs args = new NuroNUR1001R98PageCountArgs();
            args.Code = "ENDO";
            args.CodeType = "SERVER_IP";
            NuroNUR1001R98PageCountResult result = CloudService.Instance.Submit<NuroNUR1001R98PageCountResult, NuroNUR1001R98PageCountArgs>(args);

            if (!TypeCheck.IsNull(result))
            {
                serverIP = result.Count;
            }

            switch (menu.Tag.ToString())
            {
                case "3":     // 이미지 결과 조회

                    try
                    {
                        //targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=" + this.fbxBunho.GetDataValue() + "&TYPE=1";//&KEY=12345";
                        //System.Diagnostics.Process.Start(targetUrl);
                    }
                    catch (System.ComponentModel.Win32Exception noBrowser)
                    {
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //MessageBox.Show("browser msg : " + noBrowser.Message);
                    }
                    catch (System.Exception other)
                    {
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //MessageBox.Show("other msg : " + other.Message);
                    }

                    break;

                case "4":

                    try
                    {
                        //targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=" + this.fbxBunho.GetDataValue() + "&TYPE=2";//&KEY=12345";
                        //System.Diagnostics.Process.Start(targetUrl);
                    }
                    catch (System.ComponentModel.Win32Exception noBrowser)
                    {
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //MessageBox.Show("browser msg : " + noBrowser.Message);
                    }
                    catch (System.Exception other)
                    {
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //MessageBox.Show("other msg : " + other.Message);
                    }


                    break;   // 레포트 결과 조회

                case "5":    // 심전도 결과 조회

                    if (this.IsPatientSelected() == true)
                    {
                        EkgCallHelper.CallViewer(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
                    }
                    try
                    {
                        //targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=" + this.fbxBunho.GetDataValue() + "&TYPE=2";//&KEY=12345";
                        //targetUrl = "http://" + serverIP + "/PFE/";//&KEY=12345";

                        //System.Diagnostics.Process.Start(targetUrl);
                    }
                    catch (System.ComponentModel.Win32Exception noBrowser)
                    {
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //MessageBox.Show("browser msg : " + noBrowser.Message);
                    }
                    catch (System.Exception other)
                    {
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //MessageBox.Show("other msg : " + other.Message);
                    }


                    break;
            }
        }

        private void btnENDOResult_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected())
            {
                this.mMenuPFEResult.TrackPopup(this.PointToScreen(new Point(button.Location.X, button.Location.Y)));
            }
        }


        #endregion

        #region [ 방사선 결과 조회 ]

        private void btnXRTResult_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected())
            {
                this.OpenScreen_XRT0000Q00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            }
        }

        #endregion

        #region [ Approve Order creating by the Clerk ]
        private void btnApprove_Click(object sender, EventArgs e)
        {
            this.OpenScreen_OCSAPPROVE(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());

            this.pbxApprove.Visible = this.mOrderBiz.GetNotApproveOrderCnt(this.IO_Gubun, UserInfo.UserID, "Y", "N", "%") > 0 ? true : false;
            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion [ Approve Order creating by the Clerk ]

        #region [ 검체검사 결과 조회 ]

        private void btnCplResult_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.mSelectedPatientInfo != null &&
                this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                //modify bj jc
                this.OpenScreen_CPL0000Q01(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
                //this.OpenScreen_CPL0000Q00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            }
        }

        #endregion

        #region [ 주사 경과 기록 조회 ]

        private void btnJusaResult_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.mSelectedPatientInfo != null &&
                this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                this.OpenScreen_INJ0000Q00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            }
        }

        #endregion

        /*#region [ EMR 실행 ]

        private void btnEMR_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected())
            {
                IHIS.Framework.EMRHelper.ExecuteEMR(EMRIOTGubun.OUT, this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                   , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                                   , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                                   , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                                   , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            }
        }

        #endregion*/

        #region 환자 코맨트

        private void btnComment_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;
            //if (this.pnlComment.Visible == false)
            //{
            //    this.pacComment.SetCommentInfo(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(), "B");
            //    this.pacComment.TabCreate();
            //    this.pnlComment.Visible = true;
            //}
            //else
            //{
            //    this.pnlComment.Visible = false;
            //}
            this.OpenScreen_OUT0106U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        }

        #endregion

        private void tmrPaList_Tick(object sender, EventArgs e)
        {
            this.PatientListQuery(this.dtpNaewonDate.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());
        }

        private void OCS1003P01_MouseMove(object sender, MouseEventArgs e)
        {
            this.tmrPaList.Stop();
            this.tmrPaList.Start();
        }

        private void btnJinryoReser_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected())
            {
                this.OpenScreen_RES1001U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(),
                                            this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(),
                                            this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(),
                                            this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());
            }
        }

        private void grdPatientList_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {

        }

        private void btnDoOrder_Click(object sender, EventArgs e)
        {
            //if (this.IsPatientSelected() == false) return;

            if (mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                this.mOrderMode = OrderVariables.OrderMode.OutOrder;
                this.OpenScreen_OCS1003Q09(false);
            }
        }

        private void OpenScreen_OCS1003Q09(bool aIsAutoClose)
        {
            // 처방 입력 가능 여부

            //해당 내원의 처방정보를 가져온다.
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());

            if (UserInfo.Gwa == "CK")
            {
                openParams.Add("gwa", this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
                openParams.Add("doctor", this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString());
            }
            else
            {
                openParams.Add("gwa", mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());
                openParams.Add("doctor", mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());
            }

            openParams.Add("naewon_key", mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            openParams.Add("naewon_date", this.dtpNaewonDate.GetDataValue());
            if (this.mDoctorLogin)
                openParams.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            else
                openParams.Add("input_gubun", this.mInputGubun);

            //openParams.Add("tel_yn"     , "N"); // 간호 입력분은 뺀다 
            openParams.Add("tel_yn", "%"); // 약만 타러온 환자건도 있다

            openParams.Add("auto_close", aIsAutoClose);
            openParams.Add("input_tab", "%");
            openParams.Add("io_gubun", this.IO_Gubun);

            openParams.Add("childYN", "N");
            openParams.Add("patient_info", this.mSelectedPatientInfo);

            //전처방조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q09", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS0301Q09(bool aIsAutoClose)
        {

            string naewon_date = this.dtpNaewonDate.GetDataValue().PadRight(10).Substring(0, 10).Replace("-", "/");

            CommonItemCollection openParams = new CommonItemCollection();


            openParams.Add("input_tab", "%");
            openParams.Add("naewon_key", mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            if (this.mDoctorLogin)
                openParams.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            else
                openParams.Add("input_gubun", this.mInputGubun);

            if (UserInfo.Gwa == "CK")
            {
                openParams.Add("gwa", this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
                openParams.Add("memb", this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString());
            }
            else if (UserInfo.UserGubun == UserType.Doctor)
            {
                openParams.Add("gwa", UserInfo.Gwa);
                openParams.Add("memb", UserInfo.DoctorID);
            }
            else if (UserInfo.UserGubun == UserType.Nurse)
            {
                openParams.Add("gwa", TypeCheck.NVL(UserInfo.HoDong, UserInfo.Gwa));
                openParams.Add("memb", UserInfo.UserID);
            }
            else
            {
                openParams.Add("gwa", TypeCheck.NVL(this.mInputPart, UserInfo.Gwa));
                openParams.Add("memb", UserInfo.UserID);
            }

            openParams.Add("io_gubun", "O");
            openParams.Add("patient_info", this.mSelectedPatientInfo);
            openParams.Add("protocol_id", this.mProtocolID);

            //약속코드조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0301Q09", ScreenOpenStyle.ResponseSizable, openParams);

        }

        private void cboJinryoGwa_SelectedValueChanged(object sender, EventArgs e)
        {
            // 환자상병조회
            this.LoadOutSang(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                            , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                            , this.cboJinryoGwa.GetDataValue().ToString());
        }

        private void btnSetOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                this.mOrderMode = OrderVariables.OrderMode.OutOrder;
                this.OpenScreen_OCS0301Q09(false);
            }

        }

        private void dwOrderInfo_Click(object sender, EventArgs e)
        {

        }

        private void dwOrderInfo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Sybase.DataWindow.ObjectAtPointer oap = dwOrderInfo.ObjectUnderMouse;
                int row = oap.RowNumber;
                int startRowNum = -1;
                string colname, reser_yn, data_col, suntak_yn = "N", groupSer, groupSerSubStr, order_gubun, input_tab = "", bogyong_code_yn, hangmog_code = "";

                colname = oap.Gob.Name;

                //XMessageBox.Show("行" + row + "、hangmog_code：" + dwOrderInfo.GetItemString(row, "hangmog_code"));

                if (colname == "hangmog_name" || colname == "order_info" || colname == "order_detail")
                {
                    if (dwOrderInfo.GetItemString(row, colname).Trim() == "") return;
                    //groupSerSubStr = dwOrderInfo.GetItemString(row, "group_ser").Substring(0, dwOrderInfo.GetItemString(row, "group_ser").Length-2);
                    //groupSer = dwOrderInfo.GetItemString(row, "group_ser");
                    //order_gubun = dwOrderInfo.GetItemString(row, "order_gubun");
                    input_tab = dwOrderInfo.GetItemString(row, "input_tab");
                    bogyong_code_yn = dwOrderInfo.GetItemString(row, "bogyong_code_yn");
                    if (bogyong_code_yn == "N")
                    {
                        hangmog_code = dwOrderInfo.GetItemString(row, "hangmog_code");
                    }

                    for (int i = 1; i < dwOrderInfo.RowCount; i++)
                    {
                        if (dwOrderInfo.GetItemString(i, "input_tab") == input_tab)
                        {
                            startRowNum = i;
                            break;
                        }
                    }

                    switch (input_tab)
                    {
                        case "01":
                            OpenScreen_OCS0103U10(dwOrderInfo, row, colname, startRowNum);
                            break;
                        case "03":
                            OpenScreen_OCS0103U12(dwOrderInfo, row, colname, startRowNum);
                            break;
                        case "04":
                            //insert by jc string 調合してパラメーターとして送る。
                            OpenScreen_OCS0103U13(dwOrderInfo, row, colname, startRowNum);
                            break;
                        case "05":
                            OpenScreen_OCS0103U14(dwOrderInfo, row, colname, startRowNum);
                            break;
                        case "06":
                            OpenScreen_OCS0103U15(dwOrderInfo, row, colname, startRowNum);
                            //XMessageBox.Show("病理検査" + colname);
                            break;
                        case "07":
                            OpenScreen_OCS0103U16(dwOrderInfo, row, colname, startRowNum);
                            break;
                        case "08":
                            OpenScreen_OCS0103U17(dwOrderInfo, row, colname, startRowNum);
                            break;
                        case "09":
                            OpenScreen_OCS0103U18(dwOrderInfo, row, colname, startRowNum);
                            break;
                        // リハビリオーダ追加 2012/09/26
                        case "10":
                            OpenScreen_OCS0103U11(dwOrderInfo, row, colname, startRowNum);
                            break;
                        case "11":
                            OpenScreen_OCS0103U19(dwOrderInfo, row, colname, startRowNum);
                            break;

                    }
                }

            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);

            }
        }

        private void btnJinryoComment_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_OUT0123U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            if (this.mDoctorLogin)
            {
                int etcJinryoCommentCnt = this.mOrderBiz.GetOutJinryoCommentCnt(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(), this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(), this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(), this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

                if (etcJinryoCommentCnt > 0)
                {
                    this.pbxJinryoComment.Visible = true;
                }
                else
                {
                    this.pbxJinryoComment.Visible = false;
                }
            }
        }

        private void btnKensaReserPrint_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_NUR1001R98(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        }

        private void btnAllergy_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            this.OpenScreen_NUR1016U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        }

        private void grdOutSang_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOutSang.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdPatientList_QueryStarting(object sender, CancelEventArgs e)
        {
            //            this.grdPatientList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void layQueryLayout_QueryStarting(object sender, CancelEventArgs e)
        {
            //            this.layQueryLayout.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void btnListSB_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert: // 상병입력

                    e.IsBaseCall = false;

                    this.AcceptData();

                    if (this.SangInputCheck(ref this.mMsg) == false)
                    {
                        MessageBox.Show(this.mMsg, XMsg.GetMsg("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int newRow = -1;
                    // 상병 로우 생성 
                    newRow = this.grdOutSang.InsertRow(-1);

                    // 상병 로우의 초기화
                    this.InitializeSangGrid(this.grdOutSang, this.mSelectedPatientInfo, newRow);

                    break;

                //case FunctionType.Delete :
                //    // PHY8003で使われる傷病は削除できないようにする。
                //    e.IsBaseCall = false;

                //    if (IsUsedSangForPHY8003(this.grdOutSang.GetItemString(this.grdOutSang.CurrentRowNumber, "pkoutsang")))
                //    {
                //        XMessageBox.Show("PHY8003で使われている傷病なので削除できません。");
                //        return;
                //    }
                //    break;
            }
        }

        private bool IsUsedSangForPHY8003(string aPKOUTSANG)
        {
            string cmd = @"SELECT COUNT(*) CNT 
                             FROM PHY8003 A 
                            WHERE A.HOSP_CODE   = '" + EnvironInfo.HospCode + @"'
                              AND A.FKOUTSANG   = '" + aPKOUTSANG + @"'
                              AND A.DATA_KUBUN != 'D'";

            object val = Service.ExecuteScalar(cmd);

            if (int.Parse(val.ToString()) > 0)
                return true;
            else
                return false;
        }


        //insert by jc [未コード化傷病対応]
        private void grdOutSang_Validated(object sender, EventArgs e)
        {
            //XEditGrid grd = sender as XEditGrid;
            //int currentRow = grd.CurrentRowNumber;
            //if (grd.CurrentColName == "display_sang_name" && this.grdOutSang.GetItemString(currentRow, "sang_code") == NotCodeSyoubyou)
            //{
            //    this.grdOutSang.SetItemValue(currentRow, "sang_name", this.grdOutSang.GetItemString(currentRow, "display_sang_name"));
            //}
        }

        private void xbtRehaActedOrder_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_OCS1003Q10(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(), this.dtpNaewonDate.GetDataValue());
        }

        private void OpenScreen_OCS1003Q10(string aBunho, string aOrderDate)
        {
            CommonItemCollection openParam = new CommonItemCollection();

            openParam.Add("bunho", aBunho);
            openParam.Add("order_date", aOrderDate);
            openParam.Add("io_gubun", IO_Gubun);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS3003Q10", ScreenOpenStyle.ResponseFixed, openParam);
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            this.fbxBunho.SetEditValue("");
            this.fbxBunho.AcceptData();
            if (!TypeCheck.IsNull(dtpNaewonDate.GetDataValue()))
            {
                this.dtpNaewonDate.SetDataValue(DateTime.Parse(this.dtpNaewonDate.GetDataValue()).AddDays(1));
                this.dtpNaewonDate.AcceptData();
            }

            this.btnList.PerformClick(FunctionType.Query);
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            this.fbxBunho.SetEditValue("");
            this.fbxBunho.AcceptData();

            this.dtpNaewonDate.SetDataValue(DateTime.Parse(this.dtpNaewonDate.GetDataValue()).AddDays(-1));
            this.dtpNaewonDate.AcceptData();
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void grdOrder_Drug_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {

        }

        private void grdOutSang_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {

            switch (e.ColName)
            {
                case "gwa":
                    //    string cmd = @"SELECT FN_BAS_LOAD_GWA_NAME('" + e.ChangeValue.ToString() + "', '" + this.dtpNaewonDate.GetDataValue() + "') FROM SYS.DUAL";

                    //    object obj = Service.ExecuteScalar(cmd);

                    // Connect cloud

                    OcsoOCS1003P01BasLoadGwaNameArgs args = new OcsoOCS1003P01BasLoadGwaNameArgs();
                    args.Gwa = e.ChangeValue.ToString();
                    args.BuseoYmd = this.dtpNaewonDate.GetDataValue();
                    OcsoOCS1003P01BasLoadGwaNameResult result = CloudService.Instance.Submit<OcsoOCS1003P01BasLoadGwaNameResult, OcsoOCS1003P01BasLoadGwaNameArgs>(args);
                    if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        this.grdOutSang.SetItemValue(e.RowNumber, "gwa_name", result.GwaName);
                    }

                    break;
            }
        }

        private void laySaveLayout_QueryStarting(object sender, CancelEventArgs e)
        {
            for (int i = 0; i < this.laySaveLayout.RowCount; i++)
            {
                if (this.laySaveLayout.GetItemString(i, "order_gubun") == "C"
                    || this.laySaveLayout.GetItemString(i, "order_gubun") == "D")
                {

                }
            }
        }

        private void btnExpandSB_Click(object sender, EventArgs e)
        {
            if (this.mIsExpandedSB)
            {
                this.pnlSang.Size = new Size(this.pnlSang.Size.Width, this.mUnExpandedSBSize);
                this.btnExpandSB.ImageIndex = this.mExpandedSBIndex;

                this.mIsExpandedSB = false;
            }
            else
            {
                this.pnlSang.Size = new Size(this.pnlSang.Size.Width, this.mExpandedSBSize);
                this.btnExpandSB.ImageIndex = this.mUnExpandedSBIndex;

                this.mIsExpandedSB = true;
            }
            this.grdOutSang.Refresh();
        }

        private void btnKensaReser_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            CommonItemCollection param = new CommonItemCollection();
            param.Add("bunho", this.grdPatientList.GetItemValue(this.grdPatientList.CurrentRowNumber, "bunho").ToString());

            param.Add("initial_btn", "C"); //  /*「A」：未実施、「P」：過去、「C」：当日、「F」：未来*/
            param.Add("naewon_date", this.dtpNaewonDate.GetDataValue());
            param.Add("fkout1001", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            IHIS.Framework.XScreen.OpenScreenWithParam(this, "SCHS", "SCH0201Q12", ScreenOpenStyle.ResponseFixed, param);

            //画面が消えるときにもう一回チェック
            this.pbxIsKensaReser.Visible = this.mOrderBiz.IsKensaReser(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(), this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString());
        }

        private void btnHelp2_Click(object sender, EventArgs e)
        {
            pnlHelp2.Visible = !pnlHelp2.Visible;
        }

        private void pnlUser_VisibleChanged(object sender, EventArgs e)
        {
            if (this.pnlUser.Visible == false)
            {
                this.btnHelp2.Location = new Point(this.btnHelp2.Location.X, this.btnHelp2.Location.Y - this.pnlUser.Height);
                this.pnlHelp2.Location = new Point(this.pnlHelp2.Location.X, this.pnlHelp2.Location.Y - this.pnlUser.Height);
            }
            else
            {

            }


        }

        private void pbxApprove_Click(object sender, EventArgs e)
        {

        }

        private void grdReserOrderList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdReserOrderList.ParamList = new List<string>(new string[] { "f_bunho", "f_naewon_date", "f_stat_flg" });
            this.grdReserOrderList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdReserOrderList.SetBindVarValue("f_bunho", this.paInfoBox.BunHo);
            this.grdReserOrderList.SetBindVarValue("f_naewon_date", this.dtpNaewonDate.GetDataValue());
        }

        private void btnReserListExpend_Click(object sender, EventArgs e)
        {
            if (this.pnlReserOrderList.Width > 50)
            {
                this.pnlReserOrderList.Width = 50;
                this.btnReserListExpend.Image = this.ImageList.Images[46];
            }
            else
            {
                this.pnlReserOrderList.Width = 287;
                this.btnReserListExpend.Image = this.ImageList.Images[45];
            }
        }

        private void grdReserOrderList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.grdReserOrderList.RowCount > 0)
            {
                this.pbxReserOrderList.Visible = true;
                this.pnlReserOrderList.Width = 287;
                this.btnReserListExpend.Image = this.ImageList.Images[45];
            }
            else
            {
                this.pbxReserOrderList.Visible = false;
                this.pnlReserOrderList.Width = 50;
                this.btnReserListExpend.Image = this.ImageList.Images[46];
            }
        }

        private void xBtnReset_Click(object sender, EventArgs e)
        {
            this.grdReserOrderList.SetBindVarValue("f_stat_flg", ((XButton)sender).Tag.ToString());

            this.grdReserOrderList.ExecuteQuery = ExecuteQueryOcsoOCS1003P01GridReserOrderListInfo;
            this.grdReserOrderList.QueryLayout(false);
        }

        private void grdPatientList_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell63.ExecuteQuery = xEditGridCell63_ExecuteQuery;
            this.xEditGridCell170.ExecuteQuery = xEditGridCell170_ExecuteQuery;
            this.xEditGridCell170.ExecuteQuery = xEditGridCell170_ExecuteQuery;

        }

        #region Connect cloud

        /// <summary>
        /// Create data for grid Patient list
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> grdPatientList_CreateData(BindVarCollection varCollection)
        {
            return LoadDataGrdPatientList(grdPatientResult.GrdPatientList);
        }

        /// <summary>
        /// Convert to List<object[]>s
        /// </summary>
        /// <param name="grdList"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdPatientList(List<OCS1003P01GrdPatientListItemInfo> grdList)
        {
            List<object[]> dataList = new List<object[]>();
            if (grdList != null && grdList.Count > 0)
            {
                foreach (OCS1003P01GrdPatientListItemInfo info in grdList)
                {
                    dataList.Add(new object[]
                    {
                        info.Bunho,
                        info.NaewonDate,
                        info.Gwa,
                        info.Doctor,
                        info.NaewonType,
                        info.ReserYn,
                        info.JubsuTime,
                        info.ArriveTime,
                        info.Suname,
                        info.Suname2,
                        info.Sex,
                        info.Age,
                        info.GubunName,
                        info.GwaName,
                        info.DoctorName,
                        info.ChojaeName,
                        info.JinryoEndYn,
                        info.PkNaewon,
                        info.NaewonYn,
                        info.SunnabYn,
                        info.JubsuGubun1,
                        info.OtherGwa,
                        info.ConsultYn,
                        info.JubsuGubun2,
                        info.CommonDoctorYn,
                        info.Gubun,
                        info.GroupKey,
                        info.KensaYn,
                        info.UnapproveYn
                    });
                }
            }
            return dataList;
        }

        private IList<object[]> LoadDataMInputGubunCase3(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            OCS1003P01MakeInputGubunTabArgs args = new OCS1003P01MakeInputGubunTabArgs();
            args.Code = this.mInputGubun;
            OCS1003P01MakeInputGubunTabResult result =
                CloudService.Instance.Submit<OCS1003P01MakeInputGubunTabResult, OCS1003P01MakeInputGubunTabArgs>(args);
            if (result != null)
            {
                List<ComboListItemInfo> tablist = result.TabList;
                foreach (ComboListItemInfo info in tablist)
                {
                    dataList.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return dataList;
        }

        /// <summary>
        /// Load Data Input Gubun with Code = "NR"
        /// </summary>
        /// <param name="varlist"></param>
        /// <returns></returns>
        private IList<object[]> LoadDataMInputGubunCase2(BindVarCollection varlist)
        {
            {
                IList<object[]> dataList = new List<object[]>();
                OCS1003P01MakeInputGubunTabArgs args = new OCS1003P01MakeInputGubunTabArgs();
                args.Code = "NR";

                //String key = UserInfo.HospCode + Constants.CacheKeyCbo.MAKE_INPUT_GUBUN_TAB_NR_KEY;
                OCS1003P01MakeInputGubunTabResult result =
                    CacheService.Instance.Get<OCS1003P01MakeInputGubunTabArgs, OCS1003P01MakeInputGubunTabResult>(args, delegate(OCS1003P01MakeInputGubunTabResult tabResult)
                {
                    return tabResult != null && tabResult.ExecutionStatus == ExecutionStatus.Success
                        && tabResult.TabList != null && tabResult.TabList.Count > 0;
                });
                if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                {
                    List<ComboListItemInfo> tablist = result.TabList;
                    foreach (ComboListItemInfo info in tablist)
                    {
                        dataList.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                    }
                }
                return dataList;
            }
        }

        /// <summary>
        /// Load Data Input Gubun with Code = "D0"
        /// 
        /// </summary>
        /// <param name="varlist"></param>
        /// <returns></returns>
        private IList<object[]> LoadDataMInputGubunCase1(BindVarCollection varlist)
        {
            {
                IList<object[]> dataList = new List<object[]>();
                OCS1003P01MakeInputGubunTabArgs args = new OCS1003P01MakeInputGubunTabArgs();
                args.Code = "D0";
                //String key = UserInfo.HospCode + Constants.CacheKeyCbo.MAKE_INPUT_GUBUN_TAB_D0_KEY;
                OCS1003P01MakeInputGubunTabResult result =
                    CacheService.Instance.Get<OCS1003P01MakeInputGubunTabArgs, OCS1003P01MakeInputGubunTabResult>(args, delegate(OCS1003P01MakeInputGubunTabResult tabResult)
                    {
                        return tabResult.ExecutionStatus == ExecutionStatus.Success && tabResult.TabList.Count > 0;
                    });
                if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                {
                    List<ComboListItemInfo> tablist = result.TabList;
                    foreach (ComboListItemInfo info in tablist)
                    {
                        dataList.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                    }
                }
                return dataList;
            }
        }

        /// <summary>
        /// Get data for grdPatient
        /// </summary>
        /// <param name="aNaewonDate"></param>
        /// <param name="aDoctor"></param>
        /// <returns></returns>
        private OCS1003P01GrdPatientResult grdPatient_getData(string aNaewonDate, string aDoctor)
        {
            NotApproveOrderCntInfo cntInfo = new NotApproveOrderCntInfo();
            cntInfo.IoGubun = IO_Gubun;
            cntInfo.UserId = UserInfo.UserID;
            cntInfo.InsteadYn = "Y";
            cntInfo.ApproveYn = "N";
            cntInfo.Key = "%";

            OCS1003P01GrdPatientArgs args = new OCS1003P01GrdPatientArgs();
            args.OrderCnt = cntInfo;
            args.NaewonYn = "%";
            args.NaewonDate = aNaewonDate;
            args.ReserYn = "%";
            args.Doctor = TypeCheck.NVL(aDoctor, "%").ToString();
            if (this.mDoctorLogin)
            {
                args.DoctorModeYn = "Y";
                args.Doctor = "%";
            }
            else
                args.DoctorModeYn = "N";
            args.Bunho = "%";

            OCS1003P01GrdPatientResult grdPatientResult =
                CloudService.Instance.Submit<OCS1003P01GrdPatientResult, OCS1003P01GrdPatientArgs>(args);
            return grdPatientResult;
        }

        /// <summary>
        /// Get data for btnList_Query
        /// </summary>
        /// <param name="aBunho"></param>
        /// <param name="aGwa"></param>
        /// <param name="aNaewonDate"></param>
        /// <param name="aFkout1001"></param>
        /// <param name="aQueryGubun"></param>
        /// <param name="aInputGubun"></param>
        /// <param name="aBunho2"></param>
        /// <param name="aNaewonDate2"></param>
        /// <returns></returns>
        private OcsoOCS1003P01BtnListQueryResult btnList_queryData(string aBunho, string aGwa,
            string aNaewonDate,
            string aFkout1001,
            string aQueryGubun,
            string aInputGubun,
            string aBunho2,
            string aNaewonDate2)
        {
            OcsoOCS1003P01BtnListQueryArgs btnListQueryArgs = new OcsoOCS1003P01BtnListQueryArgs();
            btnListQueryArgs.Bunho = aBunho;
            btnListQueryArgs.Gwa = aGwa;
            btnListQueryArgs.NaewonDate = aNaewonDate;
            btnListQueryArgs.Fkout1001 = aFkout1001;
            btnListQueryArgs.QueryGubun = aQueryGubun;
            btnListQueryArgs.InputGubun = this.mDoctorLogin ? "NR" : aInputGubun;
            btnListQueryArgs.Bunho2 = aBunho2;
            btnListQueryArgs.NaewonDate2 = aNaewonDate2;

            OcsoOCS1003P01BtnListQueryResult listQueryResult =
                CloudService.Instance.Submit<OcsoOCS1003P01BtnListQueryResult, OcsoOCS1003P01BtnListQueryArgs>(
                    btnListQueryArgs);

            return listQueryResult;
        }

        /// <summary>
        /// get data for grdOutSang
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> grdOutSang_grdOutSang(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            string aBunho = varCollection["f_bunho"].VarValue;
            string aNaewonDate = varCollection["f_naewon_date"].VarValue;
            string aGwa = varCollection["f_gwa"].VarValue;

            OcsoOCS1003P01GridOutSangArgs gridOutSangArgs = new OcsoOCS1003P01GridOutSangArgs();
            gridOutSangArgs.Bunho = aBunho;
            gridOutSangArgs.NaewonDate = aNaewonDate;
            gridOutSangArgs.Gwa = aGwa;

            OcsoOCS1003P01GridOutSangResult gridOutSangResult =
                CloudService.Instance.Submit<OcsoOCS1003P01GridOutSangResult, OcsoOCS1003P01GridOutSangArgs>(
                    gridOutSangArgs);
            if (gridOutSangResult != null)
            {
                List<OcsoOCS1003P01GridOutSangInfo> lstGridOutSangInfos = gridOutSangResult.GridOutSangItem;
                if (lstGridOutSangInfos != null && lstGridOutSangInfos.Count > 0)
                {
                    lstObject = grdOutSang_convertListInfoToListObject(lstGridOutSangInfos);
                }
            }
            return lstObject;
        }

        /// <summary>
        /// Convert list object OcsoOCS1003P01GridOutSangInfo to List object[]
        /// </summary>
        /// <param name="lstGridOutSangInfo"></param>
        /// <returns></returns>
        private IList<object[]> grdOutSang_convertListInfoToListObject(
            List<OcsoOCS1003P01GridOutSangInfo> lstGridOutSangInfo)
        {
            IList<object[]> lstObject = new List<object[]>();

            if (lstGridOutSangInfo != null && lstGridOutSangInfo.Count > 0)
            {
                foreach (OcsoOCS1003P01GridOutSangInfo gridOutSangInfo in lstGridOutSangInfo)
                {
                    lstObject.Add(new object[]
                    {
                        gridOutSangInfo.Bunho,
                        gridOutSangInfo.Gwa,
                        gridOutSangInfo.GwaName,
                        gridOutSangInfo.IoGubun,
                        gridOutSangInfo.PkSeq,
                        gridOutSangInfo.NaewonDate,
                        gridOutSangInfo.JubsuNo,
                        gridOutSangInfo.LastNaewonDate,
                        gridOutSangInfo.LastDoctor,
                        gridOutSangInfo.LastNaewonType,
                        gridOutSangInfo.LastJubsuNo,
                        gridOutSangInfo.Fkout1001,
                        gridOutSangInfo.Fkinp1001,
                        gridOutSangInfo.InputId,
                        gridOutSangInfo.Ser,
                        gridOutSangInfo.SangCode,
                        gridOutSangInfo.JuSangYn,
                        gridOutSangInfo.SangName,
                        gridOutSangInfo.ModifierName,
                        gridOutSangInfo.SangStartDate,
                        gridOutSangInfo.SangEndDate,
                        gridOutSangInfo.SangEndSayu,
                        gridOutSangInfo.PreModifier1,
                        gridOutSangInfo.PreModifier2,
                        gridOutSangInfo.PreModifier3,
                        gridOutSangInfo.PreModifier4,
                        gridOutSangInfo.PreModifier5,
                        gridOutSangInfo.PreModifier6,
                        gridOutSangInfo.PreModifier7,
                        gridOutSangInfo.PreModifier8,
                        gridOutSangInfo.PreModifier9,
                        gridOutSangInfo.PreModifier10,
                        gridOutSangInfo.PreModifierName,
                        gridOutSangInfo.PostModifier1,
                        gridOutSangInfo.PostModifier2,
                        gridOutSangInfo.PostModifier3,
                        gridOutSangInfo.PostModifier4,
                        gridOutSangInfo.PostModifier5,
                        gridOutSangInfo.PostModifier6,
                        gridOutSangInfo.PostModifier7,
                        gridOutSangInfo.PostModifier8,
                        gridOutSangInfo.PostModifier9,
                        gridOutSangInfo.PostModifier10,
                        gridOutSangInfo.PostModifierName,
                        gridOutSangInfo.SangJindanDate,
                        gridOutSangInfo.Pkoutsang,
                        gridOutSangInfo.DataGubun,
                        gridOutSangInfo.IfDataSendYn,
                        gridOutSangInfo.OrderByKey,
                        gridOutSangInfo.NaewonType
                    });
                }
            }

            return lstObject;
        }

        /// <summary>
        /// Get data for layQueryLayout
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> layQueryLayout_getData(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();

            if (lstOutOrderInfo != null && lstOutOrderInfo.Count > 0)
            {
                foreach (OcsoOCS1003P01LayoutQueryInfo layoutQueryInfo in lstOutOrderInfo)
                {
                    lstObject.Add(new object[]
                    {
                        layoutQueryInfo.InOutKey,
                        layoutQueryInfo.Pkocskey,
                        layoutQueryInfo.Bunho,
                        layoutQueryInfo.OrderDate,
                        layoutQueryInfo.Gwa,
                        layoutQueryInfo.Doctor,
                        layoutQueryInfo.Resident,
                        layoutQueryInfo.NaewonType,
                        layoutQueryInfo.JubsuNo,
                        layoutQueryInfo.InputId,
                        layoutQueryInfo.InputPart,
                        layoutQueryInfo.InputGwa,
                        layoutQueryInfo.InputDoctor,
                        layoutQueryInfo.InputGubun,
                        layoutQueryInfo.InputGubunName,
                        layoutQueryInfo.GroupSer,
                        layoutQueryInfo.InputTab,
                        layoutQueryInfo.InputTabName,
                        layoutQueryInfo.OrderGubun,
                        layoutQueryInfo.OrderGubunName,
                        layoutQueryInfo.GroupYn,
                        layoutQueryInfo.Seq,
                        layoutQueryInfo.SlipCode,
                        layoutQueryInfo.HangmogCode,
                        layoutQueryInfo.HangmogName,
                        layoutQueryInfo.SpecimenCode,
                        layoutQueryInfo.SpecimenName,
                        layoutQueryInfo.Suryang,
                        layoutQueryInfo.SunabSuryang,
                        layoutQueryInfo.SubulSuryang,
                        layoutQueryInfo.OrdDanui,
                        layoutQueryInfo.OrdDanuiName,
                        layoutQueryInfo.DvTime,
                        layoutQueryInfo.Dv,
                        layoutQueryInfo.Dv1,
                        layoutQueryInfo.Dv2,
                        layoutQueryInfo.Dv3,
                        layoutQueryInfo.Dv4,
                        layoutQueryInfo.Nalsu,
                        layoutQueryInfo.SunabNalsu,
                        layoutQueryInfo.Jusa,
                        layoutQueryInfo.JusaName,
                        layoutQueryInfo.JusaSpdGubun,
                        layoutQueryInfo.BogyongCode,
                        layoutQueryInfo.BogyongName,
                        layoutQueryInfo.Emergency,
                        layoutQueryInfo.JaeryoJundalYn,
                        layoutQueryInfo.JundalTable,
                        layoutQueryInfo.JundalPart,
                        layoutQueryInfo.MovePart,
                        layoutQueryInfo.PortableYn,
                        layoutQueryInfo.PowderYn,
                        layoutQueryInfo.HubalChangeYn,
                        layoutQueryInfo.Pharmacy,
                        layoutQueryInfo.DrgPackYn,
                        layoutQueryInfo.Muhyo,
                        layoutQueryInfo.PrnYn,
                        layoutQueryInfo.ToiwonDrgYn,
                        layoutQueryInfo.PrnNurse,
                        layoutQueryInfo.AppendYn,
                        layoutQueryInfo.OrderRemark,
                        layoutQueryInfo.NurseRemark,
                        layoutQueryInfo.Comments,
                        layoutQueryInfo.MixGroup,
                        layoutQueryInfo.Amt,
                        layoutQueryInfo.Pay,
                        layoutQueryInfo.WonyoiOrderYn,
                        layoutQueryInfo.DangilGumsaOrderYn,
                        layoutQueryInfo.DangilGumsaResultYn,
                        layoutQueryInfo.BomOccurYn,
                        layoutQueryInfo.BomSourceKey,
                        layoutQueryInfo.DisplayYn,
                        layoutQueryInfo.SunabYn,
                        layoutQueryInfo.SunabDate,
                        layoutQueryInfo.SunabTime,
                        layoutQueryInfo.HopeDate,
                        layoutQueryInfo.HopeTime,
                        layoutQueryInfo.NurseConfirmUser,
                        layoutQueryInfo.NurseConfirmDate,
                        layoutQueryInfo.NurseConfirmTime,
                        layoutQueryInfo.NursePickupUser,
                        layoutQueryInfo.NursePickupDate,
                        layoutQueryInfo.NursePickupTime,
                        layoutQueryInfo.NurseHoldUser,
                        layoutQueryInfo.NurseHoldDate,
                        layoutQueryInfo.NurseHoldTime,
                        layoutQueryInfo.ReserDate,
                        layoutQueryInfo.ReserTime,
                        layoutQueryInfo.JubsuDate,
                        layoutQueryInfo.JubsuTime,
                        layoutQueryInfo.ActingDate,
                        layoutQueryInfo.ActingTime,
                        layoutQueryInfo.ActingDay,
                        layoutQueryInfo.ResultDate,
                        layoutQueryInfo.DcGubun,
                        layoutQueryInfo.DcYn,
                        layoutQueryInfo.BannabYn,
                        layoutQueryInfo.BannabConfirm,
                        layoutQueryInfo.SourceOrdKey,
                        layoutQueryInfo.OcsFlag,
                        layoutQueryInfo.SgCode,
                        layoutQueryInfo.SgYmd,
                        layoutQueryInfo.IoGubun,
                        layoutQueryInfo.AfterActYn,
                        layoutQueryInfo.BichiYn,
                        layoutQueryInfo.DrgBunho,
                        layoutQueryInfo.SubSusul,
                        layoutQueryInfo.PrintYn,
                        layoutQueryInfo.Chisik,
                        layoutQueryInfo.TelYn,
                        layoutQueryInfo.OrderGubunBas,
                        layoutQueryInfo.InputControl,
                        layoutQueryInfo.SugsugaYn,
                        layoutQueryInfo.JjaeryoYn,
                        layoutQueryInfo.WonyoiCheck,
                        layoutQueryInfo.EmergencyCheck,
                        layoutQueryInfo.SpecimenCheck,
                        layoutQueryInfo.PortportableCheck,
                        layoutQueryInfo.BulyongCheck,
                        layoutQueryInfo.SunabCheck,
                        layoutQueryInfo.DcCheck,
                        layoutQueryInfo.DcGubunCheck,
                        layoutQueryInfo.ConfirmCheck,
                        layoutQueryInfo.ReserYnCheck,
                        layoutQueryInfo.ChisikYn,
                        layoutQueryInfo.NdayYn,
                        layoutQueryInfo.DefaultJaeryoJundalYn,
                        layoutQueryInfo.DefaultWonyoiYn,
                        layoutQueryInfo.SpecificComment,
                        layoutQueryInfo.CommentName,
                        layoutQueryInfo.CommentSysId,
                        layoutQueryInfo.CommentPgmId,
                        layoutQueryInfo.CommentNotNull,
                        layoutQueryInfo.CommentTableId,
                        layoutQueryInfo.CommentColId,
                        layoutQueryInfo.DonbogYn,
                        layoutQueryInfo.OrderGubunBasName,
                        layoutQueryInfo.ActDoctor,
                        layoutQueryInfo.ActBuseo,
                        layoutQueryInfo.ActGwa,
                        layoutQueryInfo.HomeCareYn,
                        layoutQueryInfo.RegularYn,
                        layoutQueryInfo.SortFkocskey,
                        layoutQueryInfo.ChildYn,
                        layoutQueryInfo.IfInputControl,
                        layoutQueryInfo.SlipNslipName,
                        layoutQueryInfo.OrgKey,
                        layoutQueryInfo.ParentKey,
                        layoutQueryInfo.BunCode,
                        layoutQueryInfo.WonnaeDrgYn,
                        layoutQueryInfo.HubalChangeCheck,
                        layoutQueryInfo.DrgPackCheck,
                        layoutQueryInfo.PharmacyCheck,
                        layoutQueryInfo.PowerCheck,
                        layoutQueryInfo.ImsiDrugYn,
                        layoutQueryInfo.GeneralDispYn,
                        layoutQueryInfo.Dv5,
                        layoutQueryInfo.Dv6,
                        layoutQueryInfo.Dv7,
                        layoutQueryInfo.Dv8,
                        layoutQueryInfo.BogyongCodeSub,
                        layoutQueryInfo.BogyongNameSub,
                        layoutQueryInfo.LimitNalsu,
                        layoutQueryInfo.LimitSuryang,
                        layoutQueryInfo.GwaName,
                        layoutQueryInfo.InsteadYn,
                        layoutQueryInfo.ApproveYn,
                        layoutQueryInfo.PostapproveYn,
                        layoutQueryInfo.OrderByKey
                    });
                }
            }
            return lstObject;
        }

        /// <summary>
        /// Get data for combo box gwa
        /// </summary>
        /// <param name="varlist"></param>
        /// <returns></returns>
        private IList<object[]> LoadDataCboGwa(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            ComboGwaArgs args = new ComboGwaArgs();
            //String key = UserInfo.HospCode + Constants.CacheKeyCbo.GET_DEPARTMENT_KEYS;
            GetDataForComboResult cboListItemResult = CacheService.Instance.Get<ComboGwaArgs, GetDataForComboResult>(args, delegate(GetDataForComboResult result)
            {
                return result != null && result.ExecutionStatus == ExecutionStatus.Success && result.ComboDepartmentItem.Count > 0;
            });
            if (cboListItemResult != null)
            {
                List<ComboListItemInfo> cboList = cboListItemResult.ComboDepartmentItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }

            return dataList;
        }

        //tungtx
        /// <summary>
        /// Savelayout
        /// </summary>
        /// <returns></returns>
        private List<OCS1003P01LaySaveLayoutListItemInfo> LoadListFromLaySaveLayout()
        {
            List<OCS1003P01LaySaveLayoutListItemInfo> dataList = new List<OCS1003P01LaySaveLayoutListItemInfo>();
            if (laySaveLayout.LayoutTable.Rows.Count > 0)
            {
                foreach (DataRow row in laySaveLayout.LayoutTable.Rows)
                {
                    OCS1003P01LaySaveLayoutListItemInfo info = new OCS1003P01LaySaveLayoutListItemInfo();

                    string test = row["sunab_suryang"].ToString();

                    info.Pkocskey = row["pkocskey"].ToString();
                    info.NaewonType = row["naewon_type"].ToString();
                    info.HangmogCode = row["hangmog_code"].ToString();
                    info.SpecimenCode = row["specimen_code"].ToString();
                    info.Nalsu = row["nalsu"].ToString();
                    info.JundalTable = row["jundal_table"].ToString();
                    //info.AntiCancerYn = row["anti_cancer_yn"].ToString();
                    info.DcGubun = row["dc_gubun"].ToString();
                    info.ActBuseo = row["act_buseo"].ToString();
                    info.AfterActYn = row["after_act_yn"].ToString();
                    //info.SutakYn = row["sutak_yn"].ToString();
                    info.Dv2 = row["dv_2"].ToString();
                    info.NurseRemark = row["nurse_remark"].ToString();
                    info.NurseConfirmDate = row["nurse_confirm_date"].ToString();
                    info.HomeCareYn = row["home_care_yn"].ToString();
                    info.JusaSpdGubun = row["jusa_spd_gubun"].ToString();
                    info.GeneralDispYn = row["general_disp_yn"].ToString();
                    info.BogyongCodeSub = row["bogyong_code_sub"].ToString();
                    info.ApproveYn = row["approve_yn"].ToString();
                    info.Bunho = row["bunho"].ToString();
                    info.InputId = row["input_id"].ToString();
                    info.GroupSer = row["group_ser"].ToString();
                    info.Suryang = row["suryang"].ToString();
                    info.Jusa = row["jusa"].ToString();
                    info.JundalPart = row["jundal_part"].ToString();
                    info.Pay = row["pay"].ToString();
                    info.BannabYn = row["bannab_yn"].ToString();
                    info.OcsFlag = row["ocs_flag"].ToString();
                    info.BichiYn = row["bichi_yn"].ToString();
                    info.PowderYn = row["powder_yn"].ToString();
                    info.Dv3 = row["dv_3"].ToString();
                    info.BomOccurYn = row["bom_occur_yn"].ToString();
                    info.NurseConfirmTime = row["nurse_confirm_time"].ToString();
                    info.RegularYn = row["regular_yn"].ToString();
                    info.DrgPackYn = row["drg_pack_yn"].ToString();
                    info.Dv5 = row["dv_5"].ToString();
                    info.InsteadYn = row["instead_yn"].ToString();
                    info.PostapproveYn = row["postapprove_yn"].ToString();
                    info.OrderDate = row["order_date"].ToString();
                    info.InputPart = row["input_part"].ToString();
                    info.SlipCode = row["slip_code"].ToString();
                    info.OrdDanui = row["ord_danui"].ToString();
                    info.BogyongCode = row["bogyong_code"].ToString();
                    info.MovePart = row["move_part"].ToString();
                    info.ReserDate = row["reser_date"].ToString();
                    info.BannabConfirm = row["bannab_confirm"].ToString();
                    info.SgCode = row["sg_code"].ToString();
                    info.DrgBunho = row["drg_bunho"].ToString();
                    info.HopeDate = row["hope_date"].ToString();
                    info.Dv4 = row["dv_4"].ToString();
                    info.BomSourceKey = row["bom_source_key"].ToString();
                    info.TelYn = row["tel_yn"].ToString();
                    info.InputTab = row["input_tab"].ToString();
                    info.SortFkocskey = row["sort_fkocskey"].ToString();
                    info.Dv6 = row["dv_6"].ToString();
                    //info.InsteadId = row["instead_id"].ToString();
                    info.Gwa = row["gwa"].ToString();
                    info.InputGubun = row["input_gubun"].ToString();
                    info.NdayYn = row["nday_yn"].ToString();
                    info.DvTime = row["dv_time"].ToString();
                    info.Emergency = row["emergency"].ToString();
                    info.Muhyo = row["muhyo"].ToString();
                    info.ReserTime = row["reser_time"].ToString();
                    info.ActDoctor = row["act_doctor"].ToString();
                    info.SgYmd = row["sg_ymd"].ToString();
                    info.SubSusul = row["sub_susul"].ToString();
                    info.HopeTime = row["hope_time"].ToString();
                    info.MixGroup = row["mix_group"].ToString();
                    info.DisplayYn = row["display_yn"].ToString();
                    info.DangilGumsaOrderYn = row["dangil_gumsa_order_yn"].ToString();
                    info.HubalChangeYn = row["hubal_change_yn"].ToString();
                    info.InOutKey = row["in_out_key"].ToString();
                    info.Dv7 = row["dv_7"].ToString();
                    //info.InsteadDate = row["instead_date"].ToString();
                    info.Doctor = row["doctor"].ToString();
                    info.Seq = row["seq"].ToString();
                    info.OrderGubun = row["order_gubun"].ToString();
                    info.Dv = row["dv"].ToString();
                    info.JaeryoJundalYn = row["jaeryo_jundal_yn"].ToString();
                    info.PortableYn = row["portable_yn"].ToString();
                    info.DcYn = row["dc_yn"].ToString();
                    info.ActGwa = row["act_gwa"].ToString();
                    info.IoGubun = row["io_gubun"].ToString();
                    info.WonyoiOrderYn = row["wonyoi_order_yn"].ToString();
                    info.Dv1 = row["dv_1"].ToString();
                    info.OrderRemark = row["order_remark"].ToString();
                    info.NurseConfirmUser = row["nurse_confirm_user"].ToString();
                    info.DangilGumsaResultYn = row["dangil_gumsa_result_yn"].ToString();
                    info.Pharmacy = row["pharmacy"].ToString();
                    info.ImsiDrugYn = row["imsi_drug_yn"].ToString();
                    info.Dv8 = row["dv_8"].ToString();
                    //info.InsteadTime = row["instead_time"].ToString();
                    info.RowState = row.RowState.ToString();

                    dataList.Add(info);
                }
            }
            return dataList;


        }

        /// <summary>
        /// Create list OCS1003P01LayDeletedDataListItemInfo
        /// </summary>
        /// <returns></returns>
        private List<OCS1003P01LayDeletedDataListItemInfo> LoadListFromLayDeletedData()
        {
            List<OCS1003P01LayDeletedDataListItemInfo> dataList = new List<OCS1003P01LayDeletedDataListItemInfo>();
            for (int i = 0; i < layDeletedData.RowCount; i++)
            {
                OCS1003P01LayDeletedDataListItemInfo info = new OCS1003P01LayDeletedDataListItemInfo();
                info.Pkocskey = layDeletedData.GetItemString(i, "pkocskey");
                info.SourceOrdKey = layDeletedData.GetItemString(i, "source_ord_key");

                dataList.Add(info);
            }

            return dataList;
        }

        /// <summary>
        /// Create list OcsoOCS1003P01GridOutSangInfo
        /// </summary>
        /// <returns></returns>
        private List<OcsoOCS1003P01GridOutSangInfo> LoadListFromGrdOutSang()
        {
            List<OcsoOCS1003P01GridOutSangInfo> dataList = new List<OcsoOCS1003P01GridOutSangInfo>();
            for (int i = 0; i < grdOutSang.RowCount; i++)
            {
                if (grdOutSang.GetRowState(i) == DataRowState.Added || grdOutSang.GetRowState(i) == DataRowState.Modified)
                {
                    OcsoOCS1003P01GridOutSangInfo info = new OcsoOCS1003P01GridOutSangInfo();
                    info.Bunho = grdOutSang.GetItemString(i, "bunho");
                    info.Gwa = grdOutSang.GetItemString(i, "gwa");
                    info.GwaName = grdOutSang.GetItemString(i, "gwa_name");
                    info.IoGubun = grdOutSang.GetItemString(i, "io_gubun");
                    info.PkSeq = grdOutSang.GetItemString(i, "pk_seq");
                    info.NaewonDate = grdOutSang.GetItemString(i, "naewon_date");
                    info.JubsuNo = grdOutSang.GetItemString(i, "jubsu_no");
                    info.LastNaewonDate = grdOutSang.GetItemString(i, "last_naewon_date");
                    info.LastDoctor = grdOutSang.GetItemString(i, "last_doctor");
                    info.LastNaewonType = grdOutSang.GetItemString(i, "last_naewon_type");
                    info.LastJubsuNo = grdOutSang.GetItemString(i, "last_jubsu_no");
                    info.Fkinp1001 = grdOutSang.GetItemString(i, "fkinp1001");
                    info.InputId = grdOutSang.GetItemString(i, "input_id");
                    info.Ser = grdOutSang.GetItemString(i, "ser");
                    info.SangCode = grdOutSang.GetItemString(i, "sang_code");
                    info.JuSangYn = grdOutSang.GetItemString(i, "ju_sang_yn");
                    info.SangName = grdOutSang.GetItemString(i, "sang_name");
                    info.SangStartDate = grdOutSang.GetItemString(i, "sang_start_date");
                    info.SangEndDate = grdOutSang.GetItemString(i, "sang_end_date");
                    info.SangEndSayu = grdOutSang.GetItemString(i, "sang_end_sayu");
                    info.PreModifier1 = grdOutSang.GetItemString(i, "pre_modifier1");
                    info.PreModifier2 = grdOutSang.GetItemString(i, "pre_modifier2");
                    info.PreModifier3 = grdOutSang.GetItemString(i, "pre_modifier3");
                    info.PreModifier4 = grdOutSang.GetItemString(i, "pre_modifier4");
                    info.PreModifier5 = grdOutSang.GetItemString(i, "pre_modifier5");
                    info.PreModifier6 = grdOutSang.GetItemString(i, "pre_modifier6");
                    info.PreModifier7 = grdOutSang.GetItemString(i, "pre_modifier7");
                    info.PreModifier8 = grdOutSang.GetItemString(i, "pre_modifier8");
                    info.PreModifier8 = grdOutSang.GetItemString(i, "pre_modifier9");
                    info.PreModifier10 = grdOutSang.GetItemString(i, "pre_modifier10");
                    info.PostModifierName = grdOutSang.GetItemString(i, "pre_modifier_name");
                    info.PostModifier1 = grdOutSang.GetItemString(i, "post_modifier1");
                    info.PostModifier2 = grdOutSang.GetItemString(i, "post_modifier2");
                    info.PostModifier3 = grdOutSang.GetItemString(i, "post_modifier3");
                    info.PostModifier4 = grdOutSang.GetItemString(i, "post_modifier4");
                    info.PostModifier5 = grdOutSang.GetItemString(i, "post_modifier5");
                    info.PostModifier6 = grdOutSang.GetItemString(i, "post_modifier6");
                    info.PostModifier7 = grdOutSang.GetItemString(i, "post_modifier7");
                    info.PostModifier8 = grdOutSang.GetItemString(i, "post_modifier8");
                    info.PostModifier9 = grdOutSang.GetItemString(i, "post_modifier9");
                    info.PostModifier10 = grdOutSang.GetItemString(i, "post_modifier10");
                    info.PostModifierName = grdOutSang.GetItemString(i, "post_modifier_name");
                    info.SangJindanDate = grdOutSang.GetItemString(i, "sang_jindan_date");
                    info.Pkoutsang = grdOutSang.GetItemString(i, "pkoutsang");
                    info.DataGubun = grdOutSang.GetItemString(i, "data_gubun");
                    info.IfDataSendYn = grdOutSang.GetItemString(i, "if_data_send_yn");
                    //info.NaewonType = grdOutSang.GetItemString(i, "naewon_type");
                    //info.Fkout1001 = grdOutSang.GetItemString(i, "fkout1001");

                    info.DataRowSate = grdOutSang.GetRowState(i).ToString();
                    if (info.DataRowSate.Equals(DataRowState.Added.ToString()))
                    {
                        info.DataGubun = "I";
                    }
                    else if (info.DataRowSate.Equals(DataRowState.Modified.ToString()))
                    {
                        info.DataGubun = "U";
                    }

                    dataList.Add(info);
                }

            }

            if (grdOutSang.DeletedRowTable != null && grdOutSang.DeletedRowTable.Rows.Count > 0)
            {
                foreach (DataRow row in grdOutSang.DeletedRowTable.Rows)
                {
                    OcsoOCS1003P01GridOutSangInfo info = new OcsoOCS1003P01GridOutSangInfo();
                    info.Bunho = row["bunho"].ToString();
                    info.Gwa = row["gwa"].ToString();
                    info.GwaName = row["gwa_name"].ToString();
                    info.IoGubun = row["io_gubun"].ToString();
                    info.PkSeq = row["pk_seq"].ToString();
                    info.NaewonDate = row["naewon_date"].ToString();
                    info.JubsuNo = row["jubsu_no"].ToString();
                    info.LastNaewonDate = row["last_naewon_date"].ToString();
                    info.LastDoctor = row["last_doctor"].ToString();
                    info.LastNaewonType = row["last_naewon_type"].ToString();
                    info.LastJubsuNo = row["last_jubsu_no"].ToString();
                    info.Fkinp1001 = row["fkinp1001"].ToString();
                    info.InputId = row["input_id"].ToString();
                    info.Ser = row["ser"].ToString();
                    info.SangCode = row["sang_code"].ToString();
                    info.JuSangYn = row["ju_sang_yn"].ToString();
                    info.SangName = row["sang_name"].ToString();
                    info.SangStartDate = row["sang_start_date"].ToString();
                    info.SangEndDate = row["sang_end_date"].ToString();
                    info.SangEndSayu = row["sang_end_sayu"].ToString();
                    info.PreModifier1 = row["pre_modifier1"].ToString();
                    info.PreModifier2 = row["pre_modifier2"].ToString();
                    info.PreModifier3 = row["pre_modifier3"].ToString();
                    info.PreModifier4 = row["pre_modifier4"].ToString();
                    info.PreModifier5 = row["pre_modifier5"].ToString();
                    info.PreModifier6 = row["pre_modifier6"].ToString();
                    info.PreModifier7 = row["pre_modifier7"].ToString();
                    info.PreModifier8 = row["pre_modifier8"].ToString();
                    info.PreModifier8 = row["pre_modifier9"].ToString();
                    info.PreModifier10 = row["pre_modifier10"].ToString();
                    info.PostModifierName = row["pre_modifier_name"].ToString();
                    info.PostModifier1 = row["post_modifier1"].ToString();
                    info.PostModifier2 = row["post_modifier2"].ToString();
                    info.PostModifier3 = row["post_modifier3"].ToString();
                    info.PostModifier4 = row["post_modifier4"].ToString();
                    info.PostModifier5 = row["post_modifier5"].ToString();
                    info.PostModifier6 = row["post_modifier6"].ToString();
                    info.PostModifier7 = row["post_modifier7"].ToString();
                    info.PostModifier8 = row["post_modifier8"].ToString();
                    info.PostModifier9 = row["post_modifier9"].ToString();
                    info.PostModifier10 = row["post_modifier10"].ToString();
                    info.PostModifierName = row["post_modifier_name"].ToString();
                    info.SangJindanDate = row["sang_jindan_date"].ToString();
                    info.Pkoutsang = row["pkoutsang"].ToString();
                    info.DataGubun = row["data_gubun"].ToString();
                    info.IfDataSendYn = row["if_data_send_yn"].ToString();
                    //info.NaewonType = row["naewon_type"].ToString();
                    //info.Fkout1001 = row["fkout1001"].ToString();
                    info.DataRowSate = DataRowState.Deleted.ToString();
                    info.DataGubun = "D";

                    dataList.Add(info);
                }
            }
            return dataList;
        }

        /// <summary>
        /// Get data for grdReserOrderList
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryOcsoOCS1003P01GridReserOrderListInfo(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            OcsoOCS1003P01GridReserOrderListArgs vOcsoOCS1003P01GridReserOrderListArgs = new OcsoOCS1003P01GridReserOrderListArgs();
            vOcsoOCS1003P01GridReserOrderListArgs.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            vOcsoOCS1003P01GridReserOrderListArgs.NaewonDate = bc["f_naewon_date"] != null ? bc["f_naewon_date"].VarValue : "";
            OcsoOCS1003P01GridReserOrderListResult result = CloudService.Instance.Submit<OcsoOCS1003P01GridReserOrderListResult, OcsoOCS1003P01GridReserOrderListArgs>(vOcsoOCS1003P01GridReserOrderListArgs);
            if (result != null)
            {
                res = grdReserOrderList_createData(result.GridReserOrderList);
            }
            return res;
        }

        private IList<object[]> grdReserOrderList_createData(
            List<OcsoOCS1003P01GridReserOrderListInfo> lstGridReserOrderListInfo)
        {
            IList<object[]> lstObject = new List<object[]>();
            if (lstGridReserOrderListInfo != null && lstGridReserOrderListInfo.Count > 0)
            {
                foreach (OcsoOCS1003P01GridReserOrderListInfo gridReserOrderListInfo in lstGridReserOrderListInfo)
                {
                    lstObject.Add(new object[]
                    {
                        gridReserOrderListInfo.KizyunDate,
                        gridReserOrderListInfo.Gwa,
                        gridReserOrderListInfo.GwaName,
                        gridReserOrderListInfo.Doctor,
                        gridReserOrderListInfo.DoctorName,
                        gridReserOrderListInfo.HangmogCode,
                        gridReserOrderListInfo.HangmogName,
                        gridReserOrderListInfo.JundalTable,
                        gridReserOrderListInfo.JundalPart,
                        gridReserOrderListInfo.JundalPartName,
                        gridReserOrderListInfo.ReserTime,
                        gridReserOrderListInfo.ReserYn,
                        gridReserOrderListInfo.ActYn,
                        gridReserOrderListInfo.OrderDate,
                        gridReserOrderListInfo.Pksch
                    });
                }
            }

            return lstObject;
        }

        /// <summary>
        /// Connect to cloud service. update doctor
        /// </summary>
        /// <param name="aDoctor"></param>
        /// <param name="aGwa"></param>
        /// <param name="aPkNaewonKey"></param>
        /// <returns></returns>
        private bool ProcessUpdateDoctor(string aDoctor, string aGwa, string aPkNaewonKey)
        {
            if (TypeCheck.IsNull(aDoctor) || TypeCheck.IsNull(aGwa) || TypeCheck.IsNull(aPkNaewonKey))
            {
                return false;
            }
            // Connect cloud
            OcsoOCS1003P01UpdateDoctorArgs args = new OcsoOCS1003P01UpdateDoctorArgs();
            args.Doctor = aDoctor;
            args.Gwa = aGwa;
            args.PkNaewon = aPkNaewonKey;

            UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, OcsoOCS1003P01UpdateDoctorArgs>(args);
            if (updateResult == null)
            {
                return false;
            }
            return updateResult.Result;
        }

        /// <summary>
        /// Get data for layPat
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryOcsoOCS1003P01LayPatInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OcsoOCS1003P01LayPatArgs vOcsoOCS1003P01LayPatArgs = new OcsoOCS1003P01LayPatArgs();
            vOcsoOCS1003P01LayPatArgs.FDoctor = bc["f_doctor"].VarValue;
            vOcsoOCS1003P01LayPatArgs.FBunho = bc["f_bunho"].VarValue;
            vOcsoOCS1003P01LayPatArgs.FNaewonDate = bc["f_naewon_date"].VarValue;
            vOcsoOCS1003P01LayPatArgs.FLoginDoctorYn = bc["f_login_doctor_yn"].VarValue;
            OcsoOCS1003P01LayPatResult result = CloudService.Instance.Submit<OcsoOCS1003P01LayPatResult, OcsoOCS1003P01LayPatArgs>(vOcsoOCS1003P01LayPatArgs);
            if (result != null)
            {
                foreach (OcsoOCS1003P01LayPatInfo item in result.LayPatInfo)
                {
                    object[] objects = 
				{ 
					item.Gwa, 
					item.Bunho, 
					item.Doctor, 
					item.GroupKey, 
					item.NaewonYn
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// xEditGridCell63_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> xEditGridCell65_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            ComboJubsuGubunArgs comboJubsuGubunArgs = new ComboJubsuGubunArgs();
            //String key = UserInfo.HospCode + Constants.CacheKeyCbo.CACHE_OCS_COMBO_JUBSU_GUBUN_KEYS;
            ComboResult comboResult =
                CacheService.Instance.Get<ComboJubsuGubunArgs, ComboResult>(comboJubsuGubunArgs, delegate(ComboResult result)
                {
                    return result != null && result.ExecutionStatus == ExecutionStatus.Success &&
                           result.ComboItem != null && result.ComboItem.Count > 0;
                });
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> listItemInfo = comboResult.ComboItem;
                if (listItemInfo != null && listItemInfo.Count > 0)
                {
                    lstObject = ConvertListCombolistItemInfoToListObject(listItemInfo);
                }

            }
            return lstObject;
        }

        /// <summary>
        /// xEditGridCell20_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> xEditGridCell20_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            ComboSangEndSayuArgs comboSangEndSayuArgs = new ComboSangEndSayuArgs();
            //String key = UserInfo.HospCode + Constants.CacheKeyCbo.CACHE_OCS_COMBO_SANG_END_SAYU_KEYS;
            ComboResult comboResult =
                CacheService.Instance.Get<ComboSangEndSayuArgs, ComboResult>(comboSangEndSayuArgs, delegate(ComboResult result)
                {
                    return result != null && result.ExecutionStatus == ExecutionStatus.Success &&
                           result.ComboItem != null && result.ComboItem.Count > 0;
                });
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> listItemInfo = comboResult.ComboItem;
                if (listItemInfo != null && listItemInfo.Count > 0)
                {
                    lstObject = ConvertListCombolistItemInfoToListObject(listItemInfo);
                }

            }
            return lstObject;
        }

        /// <summary>
        /// xEditGridCell63_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> xEditGridCell63_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            ComboNaewonYnArgs comboNaewonYnArgs = new ComboNaewonYnArgs();
            //String key = UserInfo.HospCode + Constants.CacheKeyCbo.CACHE_OCS_COMBO_NAEWON_YN_KEYS;
            ComboResult comboResult =
                CacheService.Instance.Get<ComboNaewonYnArgs, ComboResult>(comboNaewonYnArgs, delegate(ComboResult result)
                {
                    return result != null && result.ExecutionStatus == ExecutionStatus.Success &&
                           result.ComboItem != null && result.ComboItem.Count > 0;
                });
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> listItemInfo = comboResult.ComboItem;
                if (listItemInfo != null && listItemInfo.Count > 0)
                {
                    lstObject = ConvertListCombolistItemInfoToListObject(listItemInfo);
                }

            }
            return lstObject;
        }

        /// <summary>
        /// xEditGridCell170_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> xEditGridCell170_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            ComboJusaSpdGubunArgs comboJusaSpdGubunArgs = new ComboJusaSpdGubunArgs();
            //String key = UserInfo.HospCode + Constants.CacheKeyCbo.CACHE_OCS_COMBO_JUSA_SPD_GUBUN_KEYS;
            ComboResult comboResult =
                CacheService.Instance.Get<ComboJusaSpdGubunArgs, ComboResult>(comboJusaSpdGubunArgs, delegate(ComboResult result)
                {
                    return result != null && result.ExecutionStatus == ExecutionStatus.Success &&
                           result.ComboItem != null && result.ComboItem.Count > 0;
                });
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> listItemInfo = comboResult.ComboItem;
                if (listItemInfo != null && listItemInfo.Count > 0)
                {
                    lstObject = ConvertListCombolistItemInfoToListObject(listItemInfo);
                }

            }
            return lstObject;
        }

        /// <summary>
        /// LoadComboDataSoureByCode
        /// </summary>
        /// <param name="varlist"></param>
        /// <returns></returns>
        private IList<object[]> LoadComboDataSoureByCode(BindVarCollection varlist)
        {
            IList<object[]> lstObject = new List<object[]>();

            ComboDataSourceInfo comboDataSourceInfo = new ComboDataSourceInfo();
            comboDataSourceInfo.ColName = "code";
            comboDataSourceInfo.Arg1 = "INPUT_TAB";

            LoadComboDataSourceArgs args = new LoadComboDataSourceArgs();
            args.DataInfo = comboDataSourceInfo;
            //String key = UserInfo.HospCode + Constants.CacheKeyCbo.CACHE_CBO_DATASOURCE_BY_CODE_AND_INPUT_TAB;
            LoadComboDataSourceResult ComboDataResult =
                CacheService.Instance.Get<LoadComboDataSourceArgs, LoadComboDataSourceResult>(args, delegate(LoadComboDataSourceResult result)
                    {
                        return result != null && result.ExecutionStatus == ExecutionStatus.Success &&
                               result.DataInfo != null && result.DataInfo.Count > 0;
                    });
            if (ComboDataResult != null && ComboDataResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> listItemInfo = ComboDataResult.DataInfo;
                if (listItemInfo != null && listItemInfo.Count > 0)
                {
                    lstObject = ConvertListCombolistItemInfoToListObject(listItemInfo);
                }
            }
            return lstObject;
        }

        /// <summary>
        /// GetUserOptionAndOrderCount
        /// </summary>
        /// <returns></returns>
        private OCS1003P01GetUserOptionAndOrderCountResult GetUserOptionAndOrderCount(string aBunho)
        {
            OCS1003P01GetUserOptionAndOrderCountArgs args = new OCS1003P01GetUserOptionAndOrderCountArgs();
            GetUserOptionInfo userOptionInfo = new GetUserOptionInfo();
            userOptionInfo.Doctor = UserInfo.UserID;
            userOptionInfo.Gwa = UserInfo.Gwa;
            userOptionInfo.Keyword = "DO_ORDER_POP_YN";
            userOptionInfo.IoGubun = this.IO_Gubun;

            GetOrderCountInfo orderCountInfo = new GetOrderCountInfo();
            orderCountInfo.IoGubun = this.IO_Gubun;
            orderCountInfo.Bunho = aBunho;
            orderCountInfo.OrderDate = this.dtpNaewonDate.GetDataValue().ToString();

            args.UserOption = userOptionInfo;
            args.OrderCount = orderCountInfo;
            return CloudService.Instance.Submit<OCS1003P01GetUserOptionAndOrderCountResult, OCS1003P01GetUserOptionAndOrderCountArgs>(args);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aBunho"></param>
        /// <param name="aNaewonDate"></param>
        /// <returns></returns>
        private bool CheckOpenAllergyInfo(string aBunho, string aNaewonDate)
        {
            bool isAllergyYn = false;
            OCS1003P01OpenAllergyInforArgs args = new OCS1003P01OpenAllergyInforArgs();
            args.Doctor = UserInfo.UserID;
            args.Gwa = UserInfo.Gwa;
            args.Keyword = "ALLERGY_POP_YN";
            args.IoGubun = this.IO_Gubun;
            args.Bunho = aBunho;
            args.NaewonDate = aNaewonDate;

            OCS1003P01OpenAllergyInforResult result = CloudService.Instance.Submit<OCS1003P01OpenAllergyInforResult, OCS1003P01OpenAllergyInforArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success && result.AllergyResult != null)
            {
                if (result.AllergyResult == "Y")
                    isAllergyYn = true;
            }

            return isAllergyYn;
        }

        /// <summary>
        /// LoadConsultEndYnAndIsNoConfirmConsult
        /// </summary>
        /// <param name="aBunho"></param>
        /// <param name="aDoctor"></param>
        /// <param name="aGwa"></param>
        /// <param name="aIOGubun"></param>
        /// <returns></returns>
        private OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultResult LoadConsultEndYnAndIsNoConfirmConsult(string aBunho, string aDoctor, string aGwa, string aIOGubun)
        {
            OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultArgs args = new OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultArgs();
            LoadConsultEndYNInfo consultEndYNInfo = new LoadConsultEndYNInfo();
            consultEndYNInfo.Bunho = aBunho;
            consultEndYNInfo.ReqDoctor = aDoctor.Substring(2);
            NoConfirmConsultInfo noConfirmConsultInfo = new NoConfirmConsultInfo();
            noConfirmConsultInfo.Bunho = aBunho;
            noConfirmConsultInfo.Naewondate = this.dtpNaewonDate.GetDataValue().ToString();
            noConfirmConsultInfo.Gwa = aGwa;
            noConfirmConsultInfo.Doctor = aDoctor;
            noConfirmConsultInfo.IoGubun = aIOGubun;

            args.ItemInfo = consultEndYNInfo;
            args.ConfirmConsultInfo = noConfirmConsultInfo;
            return CloudService.Instance.Submit<OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultResult, OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultArgs>(args);

        }

        /// <summary>
        /// CheckPatientEtcResult
        /// </summary>
        /// <param name="aBunho"></param>
        /// <param name="aNaewonDate"></param>
        /// <param name="aGwa"></param>
        /// <param name="aDoctor"></param>
        /// <returns></returns>
        private OCS1003P01CheckPatientEtcResult CheckPatientEtcResult(string aBunho, string aNaewonDate, string aGwa, string aDoctor)
        {
            KensaReserInfo kensaReserInfo = new KensaReserInfo();
            kensaReserInfo.Bunho = aBunho;
            kensaReserInfo.NaewonDate = aNaewonDate;

            GetUserOptionInfo getUserOptionInfo = new GetUserOptionInfo();
            getUserOptionInfo.Doctor = UserInfo.UserID;
            getUserOptionInfo.Gwa = UserInfo.Gwa;
            getUserOptionInfo.Keyword = "SPECIALWRITE_POP_YN";
            getUserOptionInfo.IoGubun = this.IO_Gubun;

            OutTaGwaJinryoCntInfo outTaGwaJinryoCntInfo = new OutTaGwaJinryoCntInfo();
            outTaGwaJinryoCntInfo.Bunho = aBunho;
            outTaGwaJinryoCntInfo.NaewonDate = aNaewonDate;
            outTaGwaJinryoCntInfo.Gwa = aGwa;

            GetOutJinryoCommentCntInfo getOutJinryoCommentCntInfo = new GetOutJinryoCommentCntInfo();
            getOutJinryoCommentCntInfo.Bunho = aBunho;
            getOutJinryoCommentCntInfo.Doctor = aDoctor;
            getOutJinryoCommentCntInfo.NaewonDate = aNaewonDate;
            getOutJinryoCommentCntInfo.Gwa = aGwa;

            IpwonReserStatusInfo reserStatusInfo = new IpwonReserStatusInfo();
            reserStatusInfo.Doctor = aDoctor;
            reserStatusInfo.Bunho = aBunho;

            OCS1003P01CheckPatientEtcArgs args = new OCS1003P01CheckPatientEtcArgs();
            args.Bunho = aBunho;
            args.KensaReserInfo = kensaReserInfo;
            args.UserOptionInfo = getUserOptionInfo;
            args.OutTaGwaJinryoCnt = outTaGwaJinryoCntInfo;
            args.CommentCntInfo = getOutJinryoCommentCntInfo;
            args.ReserStatusInfo = reserStatusInfo;

            return CloudService.Instance.Submit<OCS1003P01CheckPatientEtcResult, OCS1003P01CheckPatientEtcArgs>(args);
        }
        #endregion

        #region Convert List<ComboListItemInfo> to List<object[]>
        /// <summary>
        /// ConvertListCombolistItemInfoToListObject
        /// </summary>
        /// <param name="listItemInfos"></param>
        /// <returns></returns>
        private IList<object[]> ConvertListCombolistItemInfoToListObject(List<ComboListItemInfo> listItemInfos)
        {
            IList<object[]> lstObject = new List<object[]>();
            if (listItemInfos != null && listItemInfos.Count > 0)
            {
                foreach (ComboListItemInfo itemInfo in listItemInfos)
                {
                    lstObject.Add(new object[]
	                {
	                    itemInfo.Code,
                        itemInfo.CodeName
	                });
                }
            }
            return lstObject;
        }
        #endregion

        private void grdOutSang_PreEndInitializing(object sender, EventArgs e)
        {
            xEditGridCell90.ExecuteQuery = LoadDataCboGwa;
            this.xEditGridCell20.ExecuteQuery = xEditGridCell20_ExecuteQuery;
        }

        #region Kinki Checking

        private void KinkiChecking(DataTable grOrder)
        {
            try
            {
                DataTable oldOrderDt = new DataTable();
                oldOrderDt.Columns.Add(new DataColumn("yj_code", typeof(string)));
                oldOrderDt.Columns.Add(new DataColumn("hangmog_code", typeof(string)));
                oldOrderDt.Columns.Add(new DataColumn("hangmog_name", typeof(string)));
                DataTable newOrderDt = oldOrderDt.Clone();
                DataTable allOrderDt = oldOrderDt.Clone();
                if (this.layJusaOrder != null && this.layJusaOrder.RowCount > 0)
                {
                    DataTable grdJusaOrder = this.layJusaOrder.LayoutTable;
                    for (int i = 0; i < grdJusaOrder.Rows.Count; i++)
                    {
                        if (grdJusaOrder.Rows[i]["yj_code"].ToString() == "") continue;
                        oldOrderDt.Rows.Add(new object[] { grdJusaOrder.Rows[i]["yj_code"].ToString(), grdJusaOrder.Rows[i]["hangmog_code"].ToString(), grdJusaOrder.Rows[i]["hangmog_name"].ToString() });
                        allOrderDt.Rows.Add(new object[] { grdJusaOrder.Rows[i]["yj_code"].ToString(), grdJusaOrder.Rows[i]["hangmog_code"].ToString(), grdJusaOrder.Rows[i]["hangmog_name"].ToString() });
                    }
                }

                if (this.layDrugOrder != null && this.layDrugOrder.RowCount > 0)
                {
                    DataTable grdDrugOrder = this.layDrugOrder.LayoutTable;
                    for (int i = 0; i < grdDrugOrder.Rows.Count; i++)
                    {
                        if (grdDrugOrder.Rows[i]["yj_code"].ToString() == "") continue;
                        oldOrderDt.Rows.Add(new object[] { grdDrugOrder.Rows[i]["yj_code"].ToString(), grdDrugOrder.Rows[i]["hangmog_code"].ToString(), grdDrugOrder.Rows[i]["hangmog_name"].ToString() });
                        allOrderDt.Rows.Add(new object[] { grdDrugOrder.Rows[i]["yj_code"].ToString(), grdDrugOrder.Rows[i]["hangmog_code"].ToString(), grdDrugOrder.Rows[i]["hangmog_name"].ToString() });
                    }
                }

                for (int i = 0; i < grOrder.Rows.Count; i++)
                {
                    if (grOrder.Rows[i]["yj_code"].ToString() != "")
                    {
                        if (i < grOrder.Rows.Count - 1)
                            oldOrderDt.Rows.Add(new object[] { grOrder.Rows[i]["yj_code"].ToString(), grOrder.Rows[i]["hangmog_code"].ToString(), grOrder.Rows[i]["hangmog_name"].ToString() });
                        else
                            newOrderDt.Rows.Add(new object[] { grOrder.Rows[i]["yj_code"].ToString(), grOrder.Rows[i]["hangmog_code"].ToString(), grOrder.Rows[i]["hangmog_name"].ToString() });

                        allOrderDt.Rows.Add(new object[] { grOrder.Rows[i]["yj_code"].ToString(), grOrder.Rows[i]["hangmog_code"].ToString(), grOrder.Rows[i]["hangmog_name"].ToString() });
                    }
                }


                this.allWarning = HandlingData.ProcessCheck(allOrderDt, grdOutSang.LayoutTable, oldOrderDt, newOrderDt);
            }
            catch (Exception ex)
            {
                Service.WriteLog("Process check error: " + ex.StackTrace);
            }
        }
        /// <summary>
        /// Get set of orders from ocs0301Q09
        /// </summary>
        /// <param name="drugOrder"></param>
        /// <param name="injOrder"></param>
        /// <returns></returns>
        private DataTable GetSetOrder(MultiLayout drugOrder, MultiLayout injOrder)
        {
            DataTable grdOrder = new DataTable();
            grdOrder.Columns.Add(new DataColumn("yj_code", typeof(string)));
            grdOrder.Columns.Add(new DataColumn("hangmog_code", typeof(string)));
            grdOrder.Columns.Add(new DataColumn("hangmog_name", typeof(string)));


            if (drugOrder.LayoutTable != null && drugOrder.LayoutTable.Rows.Count > 0)
            {
                foreach (DataRow item in drugOrder.LayoutTable.Rows)
                {
                    if (item["yj_code"] == "") continue;
                    grdOrder.Rows.Add(new object[] { item["yj_code"], item["hangmog_code"], item["hangmog_name"] });
                }
            }

            if (injOrder.LayoutTable != null && injOrder.LayoutTable.Rows.Count > 0)
            {
                foreach (DataRow item in injOrder.LayoutTable.Rows)
                {
                    if (item["yj_code"] == "") continue;
                    grdOrder.Rows.Add(new object[] { item["yj_code"], item["hangmog_code"], item["hangmog_name"] });
                }
            }
            return grdOrder;
        }
        #endregion
    }

    #region XSavePeformer
    public class XSavePeformer : ISavePerformer
    {
        private OCS1003P01 parent = null;
        private IHIS.OCS.OrderBiz mOrderBiz = new OrderBiz("OCS1003P01");

        public XSavePeformer(OCS1003P01 parent)
        {
            this.parent = parent;
        }

        public bool Execute(char callerId, RowDataItem item)
        {
            string cmdText = "";
            string sprName = "";
            object t_chk = "";
            object reusltSang = "";
            string cmdTextsang = "";
            string changeBeforePKSEQ = "";
            item.BindVarList.Add("q_user_id", UserInfo.UserID);
            item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
            switch (callerId)
            {
                case '1':   // 상병입력 

                    #region 상병입력

                    switch (item.RowState)
                    {
                        case DataRowState.Added:

                            ////insert by jc [未コード化傷病コードの場合直接sang_nameにinsertする。] 2012/10/26
                            //if (item.BindVarList["f_sang_code"].VarValue == "0000999")
                            //    item.BindVarList["f_sang_name"].VarValue = item.BindVarList["f_display_sang_name"].VarValue;

                            cmdText = " SELECT MAX(Z.PK_SEQ)+1 PK_SEQ "
                                    + "   FROM OUTSANG Z"
                                    + "  WHERE Z.BUNHO       = '" + item.BindVarList["f_bunho"].VarValue + "' "
                                    + "    AND Z.GWA         = '" + item.BindVarList["f_gwa"].VarValue + "' "
                                    + "    AND Z.IO_GUBUN    = '" + item.BindVarList["f_io_gubun"].VarValue + "' "
                                    + "    AND Z.HOSP_CODE   = '" + EnvironInfo.HospCode + "' "
                                    ;

                            t_chk = Service.ExecuteScalar(cmdText);

                            if (TypeCheck.IsNull(t_chk) == true ||
                                t_chk.ToString() == "")
                            {
                                t_chk = "1";
                            }

                            if (item.BindVarList.Contains("f_pk_seq"))
                                item.BindVarList.Remove("f_pk_seq");
                            item.BindVarList.Add("f_pk_seq", t_chk.ToString());

                            cmdText = " SELECT MAX(Z.PK_SEQ)+1 PK_SEQ "
                                    + "   FROM OUTSANG Z"
                                    + "  WHERE Z.BUNHO       = '" + item.BindVarList["f_bunho"].VarValue + "' "
                                    + "    AND Z.HOSP_CODE   = '" + EnvironInfo.HospCode + "' "
                                    ;

                            t_chk = Service.ExecuteScalar(cmdText);

                            if (TypeCheck.IsNull(t_chk) == true ||
                                t_chk.ToString() == "")
                            {
                                t_chk = "1";
                            }

                            if (item.BindVarList.Contains("f_ser"))
                                item.BindVarList.Remove("f_ser");
                            item.BindVarList.Add("f_ser", t_chk.ToString());



                            #region [傷病重複チェック[重複あり：ＴＲＵＥ、重複なし：ＦＡＬＳＥ]] 2012/09/10

                            cmdTextsang = @"SELECT FN_OCS_SANG_DUP_CHK('" + item.BindVarList["f_hosp_code"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_io_gubun"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_gwa"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_bunho"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_fkinp1001"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_code"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_name"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_post_modifier_name"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_pre_modifier_name"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_start_date"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_end_date"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_jindan_date"].VarValue + @"'
                                                                         , 'I'
                                                                         , '" + item.BindVarList["f_ju_sang_yn"].VarValue + @"') FROM SYS.DUAL";
                            reusltSang = Service.ExecuteScalar(cmdTextsang);
                            if (reusltSang.ToString() == "Y")
                            {
                                XMessageBox.Show(Resources.MSG025_MSG, Resources.MSG001_CAP);
                                return false;
                            }

                            #endregion

                            //#region [傷病重複チェック[重複あり：ＴＲＵＥ、重複なし：ＦＡＬＳＥ]] 2012/09/10
                            //if (this.mOrderBiz.IsDupSangCheck(item.BindVarList["f_bunho"].VarValue,
                            //                                  item.BindVarList["f_io_gubun"].VarValue,
                            //                                  item.BindVarList["f_gwa"].VarValue,
                            //                                  item.BindVarList["f_sang_code"].VarValue,
                            //                                  item.BindVarList["f_pre_modifier_name"].VarValue,
                            //                                  item.BindVarList["f_post_modifier_name"].VarValue,
                            //                                  item.BindVarList["f_sang_start_date"].VarValue,
                            //                                  item.BindVarList["f_sang_end_date"].VarValue,
                            //                                  item.BindVarList["f_sang_end_sayu"].VarValue,
                            //                                  item.BindVarList["f_ju_sang_yn"].VarValue,
                            //                                  item.BindVarList["f_pk_seq"].VarValue,
                            //                                  DataRowState.Modified)
                            //                                 )
                            //{
                            //    XMessageBox.Show(XMsg.GetMsg("M012"), XMsg.GetField("F001"));
                            //    return true;
                            //}
                            //#endregion

                            cmdText = @"INSERT INTO OUTSANG
                                             ( SYS_DATE       , SYS_ID            , UPD_DATE         , BUNHO           ,
                                               GWA            , IO_GUBUN          , PK_SEQ           , NAEWON_DATE     ,
                                               DOCTOR         , NAEWON_TYPE       , JUBSU_NO         , LAST_NAEWON_DATE,
                                               LAST_DOCTOR    , LAST_NAEWON_TYPE  , LAST_JUBSU_NO    , FKINP1001       ,
                                               INPUT_ID       , SER               , SANG_CODE        , JU_SANG_YN      ,
                                               SANG_NAME      , SANG_START_DATE   , SANG_END_DATE    , SANG_END_SAYU   ,
                                               PRE_MODIFIER1  , PRE_MODIFIER2     , PRE_MODIFIER3    , PRE_MODIFIER4   ,
                                               PRE_MODIFIER5  , PRE_MODIFIER6     , PRE_MODIFIER7    , PRE_MODIFIER8   ,
                                               PRE_MODIFIER9  , PRE_MODIFIER10    , PRE_MODIFIER_NAME, POST_MODIFIER1  ,
                                               POST_MODIFIER2 , POST_MODIFIER3    , POST_MODIFIER4   , POST_MODIFIER5  ,
                                               POST_MODIFIER6 , POST_MODIFIER7    , POST_MODIFIER8   , POST_MODIFIER9  ,
                                               POST_MODIFIER10, POST_MODIFIER_NAME, HOSP_CODE        , UPD_ID          ,
                                               FKOUT1001      , SANG_JINDAN_DATE  , DATA_GUBUN)
                                        VALUES 
                                             ( SYSDATE           , :q_user_id           , SYSDATE             , :f_bunho           ,
                                               :f_gwa            , :f_io_gubun          , :f_pk_seq           , :f_naewon_date     ,
                                               :f_last_doctor    , :f_naewon_type       , :f_jubsu_no         , :f_last_naewon_date,
                                               :f_last_doctor    , :f_last_naewon_type  , :f_last_jubsu_no    , :f_fkinp1001       ,
                                               :f_input_id       , :f_ser               , :f_sang_code        , :f_ju_sang_yn      ,
                                               :f_sang_name      , :f_sang_start_date   , :f_sang_end_date    , :f_sang_end_sayu   ,
                                               :f_pre_modifier1  , :f_pre_modifier2     , :f_pre_modifier3    , :f_pre_modifier4   ,
                                               :f_pre_modifier5  , :f_pre_modifier6     , :f_pre_modifier7    , :f_pre_modifier8   ,
                                               :f_pre_modifier9  , :f_pre_modifier10    , :f_pre_modifier_name, :f_post_modifier1  ,
                                               :f_post_modifier2 , :f_post_modifier3    , :f_post_modifier4   , :f_post_modifier5  ,
                                               :f_post_modifier6 , :f_post_modifier7    , :f_post_modifier8   , :f_post_modifier9  ,
                                               :f_post_modifier10, :f_post_modifier_name, :f_hosp_code        , :q_user_id         ,
                                               :f_fkout1001      , :f_sang_jindan_date  , 'I')       ";

                            break;

                        case DataRowState.Modified:


                            #region [診療科が%の際更新したドクターの診療科に変わる]
                            if (item.BindVarList["f_gwa"].VarValue == "%")
                                item.BindVarList["f_gwa"].VarValue = UserInfo.Gwa;
                            #endregion

                            string cmd = @"select a.gwa 
                                             from outsang a 
                                            where a.hosp_code = fn_adm_load_hosp_code() 
                                              and a.pkoutsang = " + item.BindVarList["f_pkoutsang"].VarValue;
                            object val = Service.ExecuteScalar(cmd);

                            parent.mChangeBeforeGwa = val.ToString();

                            changeBeforePKSEQ = item.BindVarList["f_pk_seq"].VarValue;

                            //移行科のみSEQを再取得する。
                            if (parent.mChangeBeforeGwa == "%")
                            {


                                cmdText = " SELECT MAX(Z.PK_SEQ)+1 PK_SEQ "
                                    + "   FROM OUTSANG Z"
                                    + "  WHERE Z.BUNHO       = '" + item.BindVarList["f_bunho"].VarValue + "' "
                                    + "    AND Z.GWA         = '" + item.BindVarList["f_gwa"].VarValue + "' "
                                    + "    AND Z.IO_GUBUN    = '" + item.BindVarList["f_io_gubun"].VarValue + "' "
                                    + "    AND Z.HOSP_CODE   = '" + EnvironInfo.HospCode + "' "
                                    ;

                                t_chk = Service.ExecuteScalar(cmdText);

                                if (TypeCheck.IsNull(t_chk) == true ||
                                    t_chk.ToString() == "")
                                {
                                    t_chk = "1";
                                }

                                if (item.BindVarList.Contains("f_pk_seq"))
                                    item.BindVarList.Remove("f_pk_seq");
                                item.BindVarList.Add("f_pk_seq", t_chk.ToString());

                                cmdText = " SELECT MAX(Z.PK_SEQ)+1 PK_SEQ "
                                        + "   FROM OUTSANG Z"
                                        + "  WHERE Z.BUNHO       = '" + item.BindVarList["f_bunho"].VarValue + "' "
                                        + "    AND Z.HOSP_CODE   = '" + EnvironInfo.HospCode + "' "
                                        ;

                                t_chk = Service.ExecuteScalar(cmdText);

                                if (TypeCheck.IsNull(t_chk) == true ||
                                    t_chk.ToString() == "")
                                {
                                    t_chk = "1";
                                }

                                if (item.BindVarList.Contains("f_ser"))
                                    item.BindVarList.Remove("f_ser");
                                item.BindVarList.Add("f_ser", t_chk.ToString());
                            }

                            #region [傷病重複チェック[重複あり：ＴＲＵＥ、重複なし：ＦＡＬＳＥ]] 2012/09/10

                            cmdTextsang = @"SELECT FN_OCS_SANG_DUP_CHK('" + item.BindVarList["f_hosp_code"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_io_gubun"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_gwa"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_bunho"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_fkinp1001"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_code"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_name"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_post_modifier_name"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_pre_modifier_name"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_start_date"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_end_date"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_jindan_date"].VarValue + @"'
                                                                         , 'U'
                                                                         , '" + item.BindVarList["f_ju_sang_yn"].VarValue + @"') FROM SYS.DUAL";
                            reusltSang = Service.ExecuteScalar(cmdTextsang);
                            if (reusltSang.ToString() == "Y")
                            {
                                XMessageBox.Show(Resources.MSG025_MSG, Resources.MSG001_CAP);
                                return false;
                            }

                            #endregion

                            //#region [傷病重複チェック[重複あり：ＴＲＵＥ、重複なし：ＦＡＬＳＥ]] 2012/09/10
                            //if (this.mOrderBiz.IsDupSangCheck(item.BindVarList["f_bunho"].VarValue,
                            //                                  item.BindVarList["f_io_gubun"].VarValue,
                            //                                  item.BindVarList["f_gwa"].VarValue,
                            //                                  item.BindVarList["f_sang_code"].VarValue,
                            //                                  item.BindVarList["f_pre_modifier_name"].VarValue,
                            //                                  item.BindVarList["f_post_modifier_name"].VarValue,
                            //                                  item.BindVarList["f_sang_start_date"].VarValue,
                            //                                  item.BindVarList["f_sang_end_date"].VarValue,
                            //                                  item.BindVarList["f_sang_end_sayu"].VarValue,
                            //                                  item.BindVarList["f_ju_sang_yn"].VarValue,
                            //                                  item.BindVarList["f_pk_seq"].VarValue,
                            //                                  DataRowState.Modified)
                            //                                 )
                            //{
                            //    XMessageBox.Show(XMsg.GetMsg("M012"), XMsg.GetField("F001"));
                            //    return true;
                            //}
                            //#endregion

                            cmdText = @"UPDATE OUTSANG
                                           SET JU_SANG_YN         = :f_ju_sang_yn        
                                             , SANG_NAME          = :f_sang_name         
                                             --, SANG_CODE          = :f_sang_code
                                             , SANG_START_DATE    = :f_sang_start_date   
                                             , SANG_END_DATE      = :f_sang_end_date     
                                             , SANG_END_SAYU      = :f_sang_end_sayu     
                                             , PRE_MODIFIER1      = :f_pre_modifier1     
                                             , PRE_MODIFIER2      = :f_pre_modifier2     
                                             , PRE_MODIFIER3      = :f_pre_modifier3     
                                             , PRE_MODIFIER4      = :f_pre_modifier4     
                                             , PRE_MODIFIER5      = :f_pre_modifier5     
                                             , PRE_MODIFIER6      = :f_pre_modifier6     
                                             , PRE_MODIFIER7      = :f_pre_modifier7     
                                             , PRE_MODIFIER8      = :f_pre_modifier8     
                                             , PRE_MODIFIER9      = :f_pre_modifier9     
                                             , PRE_MODIFIER10     = :f_pre_modifier10    
                                             , PRE_MODIFIER_NAME  = :f_pre_modifier_name 
                                             , POST_MODIFIER1     = :f_post_modifier1    
                                             , POST_MODIFIER2     = :f_post_modifier2    
                                             , POST_MODIFIER3     = :f_post_modifier3    
                                             , POST_MODIFIER4     = :f_post_modifier4    
                                             , POST_MODIFIER5     = :f_post_modifier5    
                                             , POST_MODIFIER6     = :f_post_modifier6    
                                             , POST_MODIFIER7     = :f_post_modifier7    
                                             , POST_MODIFIER8     = :f_post_modifier8    
                                             , POST_MODIFIER9     = :f_post_modifier9    
                                             , POST_MODIFIER10    = :f_post_modifier10   
                                             , POST_MODIFIER_NAME = :f_post_modifier_name 
                                             , UPD_ID             = :q_user_id
                                             , UPD_DATE           = SYSDATE
                                             , SANG_JINDAN_DATE   = :f_sang_jindan_date 
                                             , GWA                = :f_gwa
                                             , DATA_GUBUN         = 'U'
                                             , PK_SEQ             = :f_pk_seq
                                             , SER                = :f_ser

                                         WHERE BUNHO              = :f_bunho   
                                           AND GWA                = '" + parent.mChangeBeforeGwa + @"'     
                                           AND IO_GUBUN           = :f_io_gubun
                                           AND PK_SEQ             = '" + changeBeforePKSEQ + @"'  
                                           AND HOSP_CODE          = :f_hosp_code";

                            break;

                        case DataRowState.Deleted:

                            //削除するタイミングでif_data_send_ynを取得してチェックをする（画面上はまだ未更新の場合あるので）
                            cmdText = @"SELECT A.IF_DATA_SEND_YN
                                          FROM OUTSANG A
                                         WHERE A.HOSP_CODE = :f_hosp_code
                                           AND A.BUNHO     = :f_bunho
                                           AND A.GWA       = :f_gwa
                                           AND A.IO_GUBUN  = :f_io_gubun
                                           AND A.PK_SEQ    = :f_pk_seq";
                            val = Service.ExecuteScalar(cmdText, item.BindVarList);

                            item.BindVarList["f_if_data_send_yn"].VarValue = val.ToString();

                            if (item.BindVarList["f_data_gubun"].VarValue == "I" && item.BindVarList["f_if_data_send_yn"].VarValue == "N")
                            {
                                cmdText = " DELETE FROM OUTSANG A                "
                                        + "  WHERE A.BUNHO        = :f_bunho     "
                                        + "    AND A.GWA          = :f_gwa       "
                                        + "    AND A.IO_GUBUN     = :f_io_gubun  "
                                        + "    AND A.PK_SEQ       = :f_pk_seq    "
                                        + "    AND A.HOSP_CODE    = :f_hosp_code "
                                        ;
                            }
                            else
                            {
                                #region [診療科が%の際更新したドクターの診療科に変わる]
                                if (item.BindVarList["f_gwa"].VarValue == "%")
                                    item.BindVarList["f_gwa"].VarValue = UserInfo.Gwa;
                                #endregion

                                cmd = @"select a.gwa 
                                                 from outsang a 
                                                where a.hosp_code = fn_adm_load_hosp_code() 
                                                  and a.pkoutsang = " + item.BindVarList["f_pkoutsang"].VarValue;
                                val = Service.ExecuteScalar(cmd);

                                changeBeforePKSEQ = item.BindVarList["f_pk_seq"].VarValue;

                                parent.mChangeBeforeGwa = val.ToString();

                                //移行科のみSEQを再取得する。
                                if (parent.mChangeBeforeGwa == "%")
                                {
                                    cmdText = " SELECT MAX(Z.PK_SEQ)+1 PK_SEQ "
                                        + "   FROM OUTSANG Z"
                                        + "  WHERE Z.BUNHO       = '" + item.BindVarList["f_bunho"].VarValue + "' "
                                        + "    AND Z.GWA         = '" + item.BindVarList["f_gwa"].VarValue + "' "
                                        + "    AND Z.IO_GUBUN    = '" + item.BindVarList["f_io_gubun"].VarValue + "' "
                                        + "    AND Z.HOSP_CODE   = '" + EnvironInfo.HospCode + "' "
                                        ;

                                    t_chk = Service.ExecuteScalar(cmdText);

                                    if (TypeCheck.IsNull(t_chk) == true ||
                                        t_chk.ToString() == "")
                                    {
                                        t_chk = "1";
                                    }

                                    if (item.BindVarList.Contains("f_pk_seq"))
                                        item.BindVarList.Remove("f_pk_seq");
                                    item.BindVarList.Add("f_pk_seq", t_chk.ToString());

                                    cmdText = " SELECT MAX(Z.PK_SEQ)+1 PK_SEQ "
                                            + "   FROM OUTSANG Z"
                                            + "  WHERE Z.BUNHO       = '" + item.BindVarList["f_bunho"].VarValue + "' "
                                            + "    AND Z.HOSP_CODE   = '" + EnvironInfo.HospCode + "' "
                                            ;

                                    t_chk = Service.ExecuteScalar(cmdText);

                                    if (TypeCheck.IsNull(t_chk) == true ||
                                        t_chk.ToString() == "")
                                    {
                                        t_chk = "1";
                                    }

                                    if (item.BindVarList.Contains("f_ser"))
                                        item.BindVarList.Remove("f_ser");
                                    item.BindVarList.Add("f_ser", t_chk.ToString());
                                }

                                cmdText = @"UPDATE OUTSANG
                                           SET JU_SANG_YN         = :f_ju_sang_yn        
                                             , SANG_NAME          = :f_sang_name         
                                             , SANG_START_DATE    = :f_sang_start_date   
                                             , SANG_END_DATE      = :f_sang_end_date     
                                             , SANG_END_SAYU      = :f_sang_end_sayu     
                                             , PRE_MODIFIER1      = :f_pre_modifier1     
                                             , PRE_MODIFIER2      = :f_pre_modifier2     
                                             , PRE_MODIFIER3      = :f_pre_modifier3     
                                             , PRE_MODIFIER4      = :f_pre_modifier4     
                                             , PRE_MODIFIER5      = :f_pre_modifier5     
                                             , PRE_MODIFIER6      = :f_pre_modifier6     
                                             , PRE_MODIFIER7      = :f_pre_modifier7     
                                             , PRE_MODIFIER8      = :f_pre_modifier8     
                                             , PRE_MODIFIER9      = :f_pre_modifier9     
                                             , PRE_MODIFIER10     = :f_pre_modifier10    
                                             , PRE_MODIFIER_NAME  = :f_pre_modifier_name 
                                             , POST_MODIFIER1     = :f_post_modifier1    
                                             , POST_MODIFIER2     = :f_post_modifier2    
                                             , POST_MODIFIER3     = :f_post_modifier3    
                                             , POST_MODIFIER4     = :f_post_modifier4    
                                             , POST_MODIFIER5     = :f_post_modifier5    
                                             , POST_MODIFIER6     = :f_post_modifier6    
                                             , POST_MODIFIER7     = :f_post_modifier7    
                                             , POST_MODIFIER8     = :f_post_modifier8    
                                             , POST_MODIFIER9     = :f_post_modifier9    
                                             , POST_MODIFIER10    = :f_post_modifier10   
                                             , POST_MODIFIER_NAME = :f_post_modifier_name 
                                             , UPD_ID             = :q_user_id
                                             , UPD_DATE           = SYSDATE
                                             , SANG_JINDAN_DATE   = :f_sang_jindan_date 
                                             , GWA                = :f_gwa
                                             , DATA_GUBUN         = 'D'
                                             , PK_SEQ             = :f_pk_seq
                                             , SER                = :f_ser

                                         WHERE BUNHO              = :f_bunho   
                                           AND GWA                = '" + parent.mChangeBeforeGwa + @"'    
                                           AND IO_GUBUN           = :f_io_gubun
                                           AND PK_SEQ             = '" + changeBeforePKSEQ + @"'
                                           AND HOSP_CODE          = :f_hosp_code";
                            }
                            break;
                    }

                    #endregion

                    break;

                case '2':    // 삭제로직...

                    #region 오더 삭제

                    // 인터페이스 용 임시테이블에 인서트
                    if (item.BindVarList["f_source_ord_key"].VarValue != "")
                    {
                        // 삭제시 DC 반납 원오더 원래대로 위치
                        ArrayList inList = new ArrayList();
                        ArrayList outList = new ArrayList();

                        inList.Add("O");
                        inList.Add(item.BindVarList["f_source_ord_key"].VarValue);

                        sprName = "PR_OCS_UPDATE_DC_YN";

                        if (Service.ExecuteProcedure(sprName, inList, outList) == false)
                        {
                            MessageBox.Show(Service.ErrFullMsg, Resources.MSG017_CAP, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    cmdText = " DELETE FROM OCS1003 "
                            + "  WHERE HOSP_CODE = :f_hosp_code "
                            + "    AND PKOCS1003 = :f_pkocskey ";

                    if (item.BindVarList["f_instead_yn"].VarValue == "Y")
                    {
                        parent.mInsteadDeletedOrderCnt++;
                    }

                    #endregion

                    break;

                case '3':    // 인서트 & 업데이트 

                    #region 오더 입력

                    switch (item.RowState)
                    {
                        case DataRowState.Added:

                            // 키가 입력되지 않은경우 키를 따야함..
                            if (item.BindVarList["f_pkocskey"].VarValue == "")
                            {
                                cmdText = " SELECT OCSKEY_SEQ.NEXTVAL "
                                        + "   FROM SYS.DUAL ";

                                t_chk = Service.ExecuteScalar(cmdText);

                                item.BindVarList.Remove("f_pkocskey");
                                item.BindVarList.Add("f_pkocskey", t_chk.ToString());
                            }

                            // 시퀀스 가져오기
                            if (item.BindVarList["f_seq"].VarValue == "")
                            {
                                cmdText = " SELECT MAX(SEQ)+1 SEQ "
                                        + "   FROM OCS1003 "
                                        + "  WHERE FKOUT1001 = " + item.BindVarList["f_in_out_key"].VarValue
                                        + "    AND HOSP_CODE = '" + EnvironInfo.HospCode + "' ";
                                t_chk = Service.ExecuteScalar(cmdText);

                                if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "")
                                {
                                    t_chk = "1";
                                }

                                item.BindVarList.Remove("f_seq");
                                item.BindVarList.Add("f_seq", t_chk.ToString());
                            }

                            if (item.BindVarList["f_general_disp_yn"].VarValue == "")
                                item.BindVarList["f_general_disp_yn"].VarValue = "N";

                            if (parent.mInputGubun == "CK")
                            {
                                item.BindVarList.Add("f_instead_yn", "Y");
                                item.BindVarList.Add("f_instead_id", UserInfo.UserID);
                                item.BindVarList.Add("f_instead_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                                item.BindVarList.Add("f_instead_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                            }

                            item.BindVarList.Add("f_approve_yn", "N");

                            // dv_1.. dv_8 まで 0 -> null
                            if (item.BindVarList["f_dv_1"].VarValue == "0") item.BindVarList["f_dv_1"].VarValue = "";
                            if (item.BindVarList["f_dv_2"].VarValue == "0") item.BindVarList["f_dv_2"].VarValue = "";
                            if (item.BindVarList["f_dv_3"].VarValue == "0") item.BindVarList["f_dv_3"].VarValue = "";
                            if (item.BindVarList["f_dv_4"].VarValue == "0") item.BindVarList["f_dv_4"].VarValue = "";
                            if (item.BindVarList["f_dv_5"].VarValue == "0") item.BindVarList["f_dv_5"].VarValue = "";
                            if (item.BindVarList["f_dv_6"].VarValue == "0") item.BindVarList["f_dv_6"].VarValue = "";
                            if (item.BindVarList["f_dv_7"].VarValue == "0") item.BindVarList["f_dv_7"].VarValue = "";
                            if (item.BindVarList["f_dv_8"].VarValue == "0") item.BindVarList["f_dv_8"].VarValue = "";

                            if (parent.mPostApproveYN)
                                item.BindVarList.Add("f_postapprove_yn", "Y");
                            else
                                item.BindVarList.Add("f_postapprove_yn", "N");

                            cmdText = " INSERT INTO OCS1003 "
                                    + "      ( SYS_DATE             , SYS_ID               , UPD_DATE          , UPD_ID                  , HOSP_CODE             , "
                                    + "        PKOCS1003            , BUNHO                , ORDER_DATE        , GWA                     , DOCTOR                , "
                                    + "        NAEWON_TYPE          , INPUT_ID             , INPUT_PART        , INPUT_GUBUN             , SEQ                   , "
                                    + "        HANGMOG_CODE         , GROUP_SER            , SLIP_CODE         , NDAY_YN                 , ORDER_GUBUN           , "
                                    + "        SPECIMEN_CODE        , SURYANG              , ORD_DANUI         , DV_TIME                 , DV                    , "
                                    + "        NALSU                , JUSA                 , BOGYONG_CODE      , EMERGENCY               , JAERYO_JUNDAL_YN      , "
                                    + "        JUNDAL_TABLE         , JUNDAL_PART          , MOVE_PART         , MUHYO                   , PORTABLE_YN           , "
                                    + "        ANTI_CANCER_YN       , PAY                  , RESER_DATE        , RESER_TIME              , DC_YN                 , "
                                    + "        DC_GUBUN             , BANNAB_YN            , BANNAB_CONFIRM    , ACT_DOCTOR              , ACT_GWA               , "
                                    + "        ACT_BUSEO            , OCS_FLAG             , SG_CODE           , SG_YMD                  , IO_GUBUN              , "
                                    + "        AFTER_ACT_YN         , BICHI_YN             , DRG_BUNHO         , SUB_SUSUL               , WONYOI_ORDER_YN       , "
                                    + "        SUTAK_YN             , POWDER_YN            , HOPE_DATE         , HOPE_TIME               , DV_1                  , "
                                    + "        DV_2                 , DV_3                 , DV_4              , MIX_GROUP               , ORDER_REMARK          , "
                                    + "        NURSE_REMARK         , BOM_OCCUR_YN         , BOM_SOURCE_KEY    , DISPLAY_YN              , NURSE_CONFIRM_USER    , "
                                    + "        NURSE_CONFIRM_DATE   , NURSE_CONFIRM_TIME   , TEL_YN            , DANGIL_GUMSA_ORDER_YN   , DANGIL_GUMSA_RESULT_YN, "
                                    + "        HOME_CARE_YN         , REGULAR_YN           , INPUT_TAB         , HUBAL_CHANGE_YN         , PHARMACY              , "
                                    + "        JUSA_SPD_GUBUN       , DRG_PACK_YN          , SORT_FKOCSKEY     , FKOUT1001               , IMSI_DRUG_YN          , "
                                    + "        GENERAL_DISP_YN      , DV_5                 , DV_6              , DV_7                    , DV_8                  , "
                                    + "        BOGYONG_CODE_SUB     , INSTEAD_YN           , INSTEAD_ID        , INSTEAD_DATE            , INSTEAD_TIME          , "
                                    + "        APPROVE_YN           , POSTAPPROVE_YN) "
                                    + " VALUES "
                                //modify by jc SYSDATE -> parent.mSave_time
                                    + "        SYSDATE              , :q_user_id           , SYSDATE           , :q_user_id              , :f_hosp_code             , "
                                    + "        :f_pkocskey          , :f_bunho             , :f_order_date     , :f_gwa                  , :f_doctor                , "
                                    + "        :f_naewon_type       , :f_input_id          , :f_input_part     , :f_input_gubun          , :f_seq                   , "
                                    + "        :f_hangmog_code      , :f_group_ser         , :f_slip_code      , :f_nday_yn              , :f_order_gubun           , "
                                    + "        :f_specimen_code     , :f_suryang           , :f_ord_danui      , :f_dv_time              , :f_dv                    , "
                                    + "        :f_nalsu             , :f_jusa              , :f_bogyong_code   , :f_emergency            , :f_jaeryo_jundal_yn      , "
                                    + "        :f_jundal_table      , :f_jundal_part       , :f_move_part      , :f_muhyo                , :f_portable_yn           , "
                                    + "        'N'                  , :f_pay               , :f_reser_date     , :f_reser_time           , :f_dc_yn                 , "
                                    + "        :f_dc_gubun          , :f_bannab_yn         , :f_bannab_confirm , :f_act_doctor           , :f_act_gwa               , "
                                    + "        :f_act_buseo         , :f_ocs_flag          , :f_sg_code        , :f_sg_ymd               , :f_io_gubun              , "
                                    + "        :f_after_act_yn      , :f_bichi_yn          , :f_drg_bunho      , :f_sub_susul            , :f_wonyoi_order_yn       , "
                                    + "        'N'                  , :f_powder_yn         , :f_hope_date      , :f_hope_time            , :f_dv_1                  , "
                                    + "        :f_dv_2              , :f_dv_3              , :f_dv_4           , :f_mix_group            , :f_order_remark          , "
                                    + "        :f_nurse_remark      , :f_bom_occur_yn      , :f_bom_source_key , :f_display_yn           , :f_nurse_confirm_user    , "
                                    + "        :f_nurse_confirm_date, :f_nurse_confirm_time, :f_tel_yn         , :f_dangil_gumsa_order_yn, :f_dangil_gumsa_result_yn, "
                                    + "        :f_home_care_yn      , :f_regular_yn        , :f_input_tab      , :f_hubal_change_yn      , :f_pharmacy              , "
                                    + "        :f_jusa_spd_gubun    , :f_drg_pack_yn       , :f_sort_fkocskey  , :f_in_out_key           , :f_imsi_drug_yn          , "
                                    + "        :f_general_disp_yn   , :f_dv_5              , :f_dv_6           , :f_dv_7                 , :f_dv_8                  , "
                                    + "        :f_bogyong_code_sub  , :f_instead_yn        , :f_instead_id     , :f_instead_date         , :f_instead_time          , "
                                    + "        :f_approve_yn        , :f_postapprove_yn) ";


                            if (item.BindVarList["f_instead_yn"] != null && item.BindVarList["f_instead_yn"].VarValue == "Y")
                            {
                                parent.mInsteadInsertedOrderCnt++;
                            }

                            break;

                        case DataRowState.Modified:

                            //薬以外はgeneral_disp_yn値がないからデフォルトで「N」を入れる。
                            //general_disp_ynに値がないとdisplay時オーダ名が表示されないから
                            if (item.BindVarList["f_general_disp_yn"].VarValue == "")
                                item.BindVarList["f_general_disp_yn"].VarValue = "N";

                            // dv_1.. dv_8 まで 0 -> null
                            if (item.BindVarList["f_dv_1"].VarValue == "0") item.BindVarList["f_dv_1"].VarValue = "";
                            if (item.BindVarList["f_dv_2"].VarValue == "0") item.BindVarList["f_dv_2"].VarValue = "";
                            if (item.BindVarList["f_dv_3"].VarValue == "0") item.BindVarList["f_dv_3"].VarValue = "";
                            if (item.BindVarList["f_dv_4"].VarValue == "0") item.BindVarList["f_dv_4"].VarValue = "";
                            if (item.BindVarList["f_dv_5"].VarValue == "0") item.BindVarList["f_dv_5"].VarValue = "";
                            if (item.BindVarList["f_dv_6"].VarValue == "0") item.BindVarList["f_dv_6"].VarValue = "";
                            if (item.BindVarList["f_dv_7"].VarValue == "0") item.BindVarList["f_dv_7"].VarValue = "";
                            if (item.BindVarList["f_dv_8"].VarValue == "0") item.BindVarList["f_dv_8"].VarValue = "";

                            cmdText = " UPDATE OCS1003 "
                                    + "    SET UPD_DATE         = SYSDATE "
                                    + "      , UPD_ID           = :q_user_id "
                                    + "      , ORDER_GUBUN      = :f_order_gubun "
                                    + "      , SURYANG          = :f_suryang "
                                    + "      , ORD_DANUI        = :f_ord_danui "
                                    + "      , DV_TIME          = :f_dv_time "
                                    + "      , DV               = :f_dv "
                                    + "      , NALSU            = :f_nalsu "
                                    + "      , JUSA             = :f_jusa  "
                                    + "      , BOGYONG_CODE     = :f_bogyong_code "
                                    + "      , EMERGENCY        = :f_emergency "
                                    + "      , JAERYO_JUNDAL_YN = :f_jaeryo_jundal_yn "
                                    + "      , JUNDAL_TABLE     = :f_jundal_table "
                                    + "      , JUNDAL_PART      = :f_jundal_part "
                                    + "      , MOVE_PART        = :f_move_part "
                                    + "      , MUHYO            = :f_muhyo "
                                    + "      , PORTABLE_YN      = :f_portable_yn "
                                    + "      , ANTI_CANCER_YN   = :f_anti_cancer_yn "
                                    + "      , DC_YN            = :f_dc_yn "
                                    + "      , DC_GUBUN         = :f_dc_gubun "
                                    + "      , BANNAB_YN        = :f_bannab_yn "
                                    + "      , BANNAB_CONFIRM   = :f_bannab_confirm "
                                    + "      , SUTAK_YN         = :f_sutak_yn "
                                    + "      , POWDER_YN        = :f_powder_yn "
                                    + "      , HOPE_DATE        = :f_hope_date "
                                    + "      , HOPE_TIME        = :f_hope_time "
                                    + "      , DV_1             = :f_dv_1 "
                                    + "      , DV_2             = :f_dv_2 "
                                    + "      , DV_3             = :f_dv_3 "
                                    + "      , DV_4             = :f_dv_4 "
                                    + "      , DV_5             = :f_dv_5 "
                                    + "      , DV_6             = :f_dv_6 "
                                    + "      , DV_7             = :f_dv_7 "
                                    + "      , DV_8             = :f_dv_8 "
                                    + "      , MIX_GROUP        = :f_mix_group "
                                    + "      , ORDER_REMARK     = :f_order_remark "
                                    + "      , NURSE_REMARK     = :f_nurse_remark "
                                    + "      , BOM_OCCUR_YN     = :f_bom_occur_yn "
                                    + "      , BOM_SOURCE_KEY   = :f_bom_source_key "
                                    + "      , NURSE_CONFIRM_USER = :f_nurse_confirm_user "
                                    + "      , NURSE_CONFIRM_DATE = :f_nurse_confirm_date "
                                    + "      , NURSE_CONFIRM_TIME = :f_nurse_confirm_time "
                                    + "      , DANGIL_GUMSA_ORDER_YN = :f_dangil_gumsa_order_yn "
                                    + "      , DANGIL_GUMSA_RESULT_YN = :f_dangil_gumsa_result_yn "
                                    + "      , HOME_CARE_YN     = :f_home_care_yn "
                                    + "      , REGULAR_YN       = :f_regular_yn "
                                    + "      , HUBAL_CHANGE_YN  = :f_hubal_change_yn "
                                    + "      , PHARMACY         = :f_pharmacy "
                                    + "      , JUSA_SPD_GUBUN   = :f_jusa_spd_gubun "
                                    + "      , DRG_PACK_YN      = :f_drg_pack_yn "
                                    + "      , SORT_FKOCSKEY    = :f_sort_fkocskey "
                                    + "      , WONYOI_ORDER_YN  = :f_wonyoi_order_yn "
                                    + "      , IMSI_DRUG_YN     = :f_imsi_drug_yn "
                                    + "      , SPECIMEN_CODE    = :f_specimen_code "
                                    + "      , GENERAL_DISP_YN  = :f_general_disp_yn "
                                    + "      , BOGYONG_CODE_SUB = :f_bogyong_code_sub "
                                    + "      , GROUP_SER        = :f_group_ser "
                                    + "  WHERE PKOCS1003 = :f_pkocskey "
                                    + "    AND HOSP_CODE = :f_hosp_code "
                                    ;

                            if (item.BindVarList["f_instead_yn"] != null && item.BindVarList["f_instead_yn"].VarValue == "Y")
                            {
                                parent.mInsteadUpdatedOrderCnt++;
                            }

                            break;

                    }

                    #endregion

                    break;
            }

            bool isSuccess = Service.ExecuteNonQuery(cmdText, item.BindVarList);

            // 오더 업데이트의 경우는 정시약도 같이 업데이트 되어야 함.
            if (callerId == '3' && isSuccess)
            {
                if (this.mOrderBiz.SaveRegularOrder("1", item.BindVarList["f_pkocskey"].VarValue) == false)
                {
                    isSuccess = false;
                }
                else
                {
                    isSuccess = true;
                }
            }

            return isSuccess;
        }
    }
    #endregion
}