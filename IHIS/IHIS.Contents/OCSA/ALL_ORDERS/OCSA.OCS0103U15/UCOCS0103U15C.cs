using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.OCS;
using PatientInfo = IHIS.OCS.PatientInfo;
using IHIS.OCSA.Properties;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;

namespace IHIS.OCSA
{
    public partial class UCOCS0103U15C : XScreen
    {
        #region 1. 생성자를 정의한다

        
        public UCOCS0103U15C()
            : this(false)
        {
        }
        public UCOCS0103U15C(bool initialize)
        {
            if(initialize) EnsureInitialized();
           
        }
        private bool _initialized = false;

        public void EnsureInitialized()
        {
            if (!_initialized)
            {
                // MessageBox.Show("Constructor start");

            InitializeComponent();

            grdOrder.ParamList = new List<string>(new String[] { "memb", "yaksok_code", "fk_in_out_key", "input_tab", "input_gubun", "order_mode" });
            grdOrder.ExecuteQuery = ExecuteQueryGrdOrderListInfo;

            //Fix bug MED-8921
            // grdSangyongOrder
            this.grdSangyongOrder.ParamList = new List<string>(new string[]
                {
                    "f_user",
                    "f_io_gubun",
                    "f_order_gubun",
                    "f_order_date",
                    "f_search_word",
                    "f_wonnae_drg_yn",
                    "f_page_number",
                });
            this.grdSangyongOrder.ExecuteQuery = GetGrdSangyongOrder;

            laySlipCodeTree.ExecuteQuery = ExecuteQueryLaySlipCodeTreeInfo;

            cboSearchCondition.ExecuteQuery = ComboSearchCondition;
            cboSearchCondition.SetDictDDLB();

            // MessageBox.Show("Constructor end");
                _initialized = true;
            }

        }
        #endregion

        #region 2. Form변수를 정의한다

        #region for input excel
        private XScreen mContainer;
        private XPanel mPnlTop;
        private XScreen mOpener;
        private XButtonList mBtnList;
        private XButton mBtnCopy;
        private XButton mBtnPaste;
        private PictureBox mPbxCopy;
        #endregion

        private string mbxMsg = "", mbxCap = "";
        private string mHospCode = EnvironInfo.HospCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // 라디오 버튼 관련 변수
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private XColor mSelectedForeColor = new XColor(Color.FromName("ActiveCaptionText"));
        private XColor mSelectedBackColor = new XColor(Color.FromName("ActiveCaption"));
        private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));
        private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // 오더 화면 확장 관련
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //modify by jc
        private int OrderExtendWidth = 850;
        //private int OrderExtendWidth = 1081;
        private int OrderNormalWidth = 762;
        private bool mIsExtended = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // 조회부분 화면 확장 관련
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private int OrderMinWidth = 618;
        private bool mIsSearchExtended = false;

        private int SearchHangmogNameNormalWidth = 329;
        private int SearchHangmogNameMaxWidth = 468;

        private int SlipHangmogNameNormalWidth = 175;
        private int SlipHangmogNameMaxWidth = 314;

        private int SangYongHangmogNormalWidth = 330;
        private int SangYongHangmogMaxWidth = 466;

        ///////////// Order 기본값 /////////////////////////////////////////////////////////////////////////
        private const string INPUTTAB = "06"; // 病理検査 (06) 
        private string IOEGUBUN = "O";     // 입외구분(외래)
        private string mInputGubun = "D0";    // 입력구분(의사처방)
        private string mInputGubunName = "";  // 입력구분명
        private string mInputPart = "";      // 입력파트
        private string mCallerSysID = "";
        private string mCallerScreenID = "";
        private string mprotocolID = ""; 
        private int mInitialGroupSer = 600;

        //공통
        private string mOrderDate = "";
        private string mBunho = "";
        private MultiLayout mOrderLayout;
        private OrderVariables.OrderMode mOrderMode;
        private int mCurrentRow = -1;
        //입원외래 order
        private string mPkInOutKey = "";
        // 셋트오더 관련 _ 키
        private string mMemb = "";
        private string mYaksokCode = "";
        // CP관련 키
        private string mMembGubun = "";
        private string mCpCode = "";
        private string mJaewonil = "";
        private string mCpPathCode = "";
        private string mCpMasterkey = "";
        //insert by jc OCS1003P01のDoオーダ関連
        private bool mDo_order = false;
        private MultiLayout mInDoDataRow;

        //insert by jc [OCS1003P01のデータウインドウから選択された際、自動ポイント移動に必要な変数]
        private int mCurrentRowNum = -1;
        private XDataWindow mCurrentDataWindow;
        private string mCurrentColName = "";
        private int mStartRowNum = -1;

        // 환자정보관련

        private bool mDoctorLogin = false;

        // 오더 정보 관련
        private DataTable mInDataRow;
        private DataTable mOutDataRow;

        private DataTable mLayDtOrderBuffer = null; // 처방 Copy & Paste용 Buffer DataTable

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////// OCS Library  /////////////////////////////////////////////////////////////////////////
        private IHIS.OCS.OrderBiz mOrderBiz = null;         // OCS 그룹 Business 라이브러리
        private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리
        private IHIS.OCS.PatientInfo mPatientInfo = null;     // OCS 환자정보 그룹 라이브러리 
        private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리 		
        private IHIS.OCS.InputControl mInputControl = null;   // 입력제어 그룹 라이브러리 
        private IHIS.OCS.CommonForms mCommonForms = null;     // OCS 공통Form's 그룹 라이브러리 
        private IHIS.OCS.ColumnControl mColumnControl = null; // OCS 오더별 컬럼 컨트롤 라이브러리
        private IHIS.OCS.OrderInterface mInterface = null;
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////grd Drag //////////////////////////////////////////////////////////////////////////////
        private bool mIsDrag = false;
        private int mDragX = 0;
        private int mDragY = 0;
        private int mDragRowIndex = 0;
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////Popup Menu ////////////////////////////////////////////////////////////////////////////
        private IHIS.X.Magic.Menus.PopupMenu popupOrderMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 처방Grid용
        private IHIS.X.Magic.Menus.PopupMenu popupOftenUsedMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 상용처방Grid용
        private IHIS.X.Magic.Menus.PopupMenu popupYaksokOrderMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 약속처방Grid용
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private Hashtable mHtControl = null;        // Control과 연결할 HashTable

        private bool mIsSuccessBtnList = true;      // 버튼리스트 로직 콜해서 성공여부를 가지고 있는다(PerformClick의 Return값이 없어서)

        private string mPk_Naewon = ""; // 내원/재원환자List에서 환자 선택한 내원/재원Key

        private DataTable mDtOrderGubun;

        // 저장을 하기 위한 Layout
        private Hashtable mSaveLayout;

        // Screen Open check
        private bool mScreenOpen = true;

        // 신규 탭 페이지 
        private IHIS.X.Magic.Controls.TabPage tpgNew = new IHIS.X.Magic.Controls.TabPage();

        // 임시 컬럼
        string mTemp = "";

        #region for input excel

        public XScreen MContainer
        {
            get { return mContainer; }
            set { mContainer = value; }
        }

        public XPanel MPnlTop
        {
            get { return mPnlTop; }
            set { mPnlTop = value; }
        }

        public XScreen MOpener
        {
            get { return mOpener; }
            set { mOpener = value; }
        }

        public XButtonList MBtnList
        {
            get { return mBtnList; }
            set { mBtnList = value; }
        }

        public XButton MBtnCopy
        {
            get { return mBtnCopy; }
            set { mBtnCopy = value; }
        }

        public XButton MBtnPaste
        {
            get { return mBtnPaste; }
            set { mBtnPaste = value; }
        }

        public PictureBox MPbxCopy
        {
            get { return mPbxCopy; }
            set { mPbxCopy = value; }
        }

        public PatientInfo MPatientInfo
        {
            get { return mPatientInfo; }
        }

        public OrderBiz MOrderBiz
        {
            get { return mOrderBiz; }
        }

        #endregion

        #endregion

        #region 3. Properties를 정의한다
        private bool isOpenPopUp = true;
        private bool isEnableGrd = true;
        //Fix bug MED-8921
        private string protocolId = "";
        private bool isSearchFormKeyPress = false;

        public XEditGrid GrdOrder
        {
            get
            {
                return grdOrder;
            }
        }        
        #endregion

        #region 4. OnLoad 및 Main Screen Event를 정의한다

        /// <summary>
        /// 
        /// </summary>
        private void PostLoad(CommonItemCollection aOpenParam)
        {
          
            //MessageBox.Show("PostLoad Start");

            /// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

            if (aOpenParam != null) // 다른 화면에서 콜되는 경우
            {
                //HandleBtnListButtonClick(FunctionType.Query);

                this.MakeGroupTabInfo(IOEGUBUN, this.mPkInOutKey, this.mInputGubun, INPUTTAB);
            }

            // MessageBox.Show(this.grdOrder.CurrentRowNumber.ToString());
            this.setFocusGotoColumn();

            //Customize
            SetEnableRbn();
            if (aOpenParam != null && !aOpenParam["isOpenPopUp"].Equals(true))
            {
                rbnOftenOrder.Checked = true;
                rbnOftenOrder.Dock = DockStyle.Fill;
                //OverrideLookAndFeel();
            }
            else
                this.rbnOftenOrder.Checked = true;
        }

        private void OverrideLookAndFeel()
        {
            txtSearch.Size = new Size(126, 20);
            txtSearch.Location = new Point(150, 37);
            cboSearchCondition.Size = new Size(85, 21);
            if (NetInfo.Language.Equals(LangMode.Jr))
            {
                cboSearchCondition.Location = new Point(280, 36);
            }
            

            pnlSangyong.Location = new Point(764, 100);
            xLabel5.Location = new Point(4, 37);
            xPanel8.Location = new Point(764, 31);
            xPanel6.Location = new Point(764, 489);
            rbnOftenOrder.Location = new Point(144, 1);
            xPanel2.Location = new Point(764, 0);
            btnSpecificComment.Location = new Point(265, 7);
            btnSetOrder.Location = new Point(469, 7);
            btnDoOrder.Location = new Point(367, 7);
            btnExtend.Location = new Point(734, 3);
            pnlFill.Location = new Point(0, 0);
            grdSangyongOrder.Size = new Size(536, 359);
            tabSangyongOrder.Size = new Size(536, 30);
            pnlSangyong.Size = new Size(536, 389);
            cboQueryCon.Size = new Size(190, 20);
            //txtSearch.Size = new Size(121, 20);
            xPanel8.Size = new Size(536, 69);
            //btnInsert.Size = new Size(80, 29);
            btnSelect.Size = new Size(117, 29);
            btnNewSelect.Size = new Size(135, 29);
            xPanel6.Size = new Size(536, 42);
            rbnOftenOrder.Size = new Size(128, 28);
            xPanel2.Size = new Size(536, 31);
            grdOrder.Size = new Size(764, 458);
            xPanel4.Size = new Size(764, 458);
            pnlOrderDetail.Size = new Size(764, 42);
            tabGroup.Size = new Size(764, 29);
            xPanel1.Size = new Size(764, 32);
            pnlOrderInput.Size = new Size(764, 31);
            pnlOrderInfo.Size = new Size(764, 531);
            this.AutoScaleDimensions = new SizeF(6, 13);
            this.Size = new Size(1300, 531);       
        }

        private void SetEnableRbn()
        {
            rbnOftenOrder.Visible = true;
        }

        /// <summary>
        /// 해당 Screen의 각종 Control 관련 Setting
        /// </summary>
        private void InitializeScreen()
        {
            //저장에 필요한 Layout을 정의한다.
            mSaveLayout = new Hashtable();
            mSaveLayout.Add("OCS1003", this.grdOrder);

            // 상용처방을 로드한다.
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder)
            {
                // 유저별 공통 모드인데 이건 어쩔까...
                string name = "";
                this.mOrderBiz.LoadColumnCodeName("gwa_doctor", "%", this.mMemb, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"), ref name);

                if (name == "")
                {
                    // 주과의 상용오더를 가져오자.
                    string mainDoctorCode = this.mOrderBiz.GetMainGwaDoctorCode(this.mMemb);
                    if (mainDoctorCode != "")
                        this.MakeSangyongTab(mainDoctorCode, INPUTTAB);
                    else
                        this.MakeSangyongTab(mMemb, INPUTTAB);
                }
                else
                {
                    this.MakeSangyongTab(mMemb, INPUTTAB);
                }
            }
            else
            {
                // 상용처방을 로드한다.
                if (UserInfo.UserGubun == UserType.Doctor)
                {
                    this.MakeSangyongTab(UserInfo.DoctorID, INPUTTAB);
                }
                else
                    this.MakeSangyongTab(UserInfo.UserID, INPUTTAB);
            }

            // 약오더를 로드한다.
            this.MakeSpecimenOrder();
            xPanel8.Size = new Size(491, 64);
            if (NetInfo.Language.Equals(LangMode.Vi))
            {
                xLabel5.Size = new Size(140, 21);
                xLabel5.Location = new Point(4, 38);
            }
            else
            {
                xLabel5.Size = new Size(140, 20);
                xLabel5.Location = new Point(4, 37);
            }
            
            txtSearch.Size = new Size(126, 20);
            txtSearch.Location = new Point(150, 37);
            if (NetInfo.Language.Equals(LangMode.Vi))
            {
                cboSearchCondition.Size = new Size(85, 21);
                cboSearchCondition.Location = new Point(280, 37);
            }
            else
            {
                cboSearchCondition.Size = new Size(85, 21);
                cboSearchCondition.Location = new Point(280, 36);
            }
            xLabel2.Size = new Size(140, 20);
            cboQueryCon.Location = new Point(150, 12);
            btnSelect.Size = new Size(117, 29);

        }

        private bool _screenActivated = false;
        private CommonItemCollection _aOpenParam;

        public bool ScreenActivated
        {
            get { return _screenActivated; }
        }

        /// <summary>
        /// Screen Open시 Parameter를 받는다 (등록번호 연계)
        /// </summary>
        /// <remarks>
        /// 해당 등록번호와 내원정보로 외래처방 데이타 조회
        /// </remarks>
        public string ScreenOpen(CommonItemCollection aOpenParam)
        {
            if (!_screenActivated)
            {
                _aOpenParam = aOpenParam;
                return "";
            }

            this.grdOrder.Reset();

            if (aOpenParam != null && aOpenParam.Contains("caller_screen_id"))
            {
                this.mCallerScreenID = aOpenParam["caller_screen_id"].ToString();
            }

            SetEnableUcGrid(true);
            isEnableGrd = true;
            if (aOpenParam != null && aOpenParam.Contains("is_enable_grd") && (bool)aOpenParam["is_enable_grd"].Equals(false))
            {
                SetEnableUcGrid(false);
                isEnableGrd = false;
            }

            if (UserInfo.UserGubun == UserType.Doctor)
            {
                this.mDoctorLogin = true;
            }
            /*this.mOrderBiz = new IHIS.OCS.OrderBiz(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());             // OCS 그룹 Business 라이브러리
            this.mOrderFunc = new IHIS.OCS.OrderFunc(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());            // OCS 그룹 Function 라이브러리
            this.mPatientInfo = new IHIS.OCS.PatientInfo(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());        // OCS 환자정보 그룹 라이브러리 
            this.mHangmogInfo = new IHIS.OCS.HangmogInfo(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());        // OCS 항목정보 그룹 라이브러리
            this.mInputControl = new IHIS.OCS.InputControl(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());      // 입력제어 그룹 라이브러리 
            this.mCommonForms = new IHIS.OCS.CommonForms();                 // OCS 공통Form's 그룹 라이브러리 
            this.mColumnControl = new ColumnControl(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());      // 입력제어 그룹 라이브러리 
            this.mInterface = new IHIS.OCS.OrderInterface();*/

            this.mOrderBiz = aOpenParam != null && aOpenParam.Contains("mOrderBiz") ? (IHIS.OCS.OrderBiz)aOpenParam["mOrderBiz"] : new IHIS.OCS.OrderBiz(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString()); // OCS 그룹 Business 라이브러리
            this.mOrderFunc = aOpenParam != null && aOpenParam.Contains("mOrderFunc") ? (IHIS.OCS.OrderFunc)aOpenParam["mOrderFunc"] : new IHIS.OCS.OrderFunc(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString()); // OCS 그룹 Function 라이브러리
            this.mPatientInfo = aOpenParam != null && aOpenParam.Contains("mPatientInfo") ? (IHIS.OCS.PatientInfo)aOpenParam["mPatientInfo"] : new IHIS.OCS.PatientInfo(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());
            // OCS 환자정보 그룹 라이브러리 
            this.mHangmogInfo = aOpenParam != null && aOpenParam.Contains("mHangmogInfo") ? (IHIS.OCS.HangmogInfo)aOpenParam["mHangmogInfo"] : new IHIS.OCS.HangmogInfo(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());        // OCS 항목정보 그룹 라이브러리
            this.mInputControl = aOpenParam != null && aOpenParam.Contains("mInputControl") ? (IHIS.OCS.InputControl)aOpenParam["mInputControl"] : new IHIS.OCS.InputControl(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());      // 입력제어 그룹 라이브러리 
            this.mCommonForms = aOpenParam != null && aOpenParam.Contains("mCommonForms") ? (IHIS.OCS.CommonForms)aOpenParam["mCommonForms"] : new IHIS.OCS.CommonForms();                 // OCS 공통Form's 그룹 라이브러리 
            this.mColumnControl = aOpenParam != null && aOpenParam.Contains("mColumnControl") ? (IHIS.OCS.ColumnControl)aOpenParam["mColumnControl"] : new ColumnControl(TypeCheck.NVL(this.mCallerScreenID, this.Name).ToString());      // OCS 컬럼 컨트롤 그룹 라이브러리 
            this.mInterface = aOpenParam != null && aOpenParam.Contains("mInterface") ? (IHIS.OCS.OrderInterface)aOpenParam["mInterface"] : new IHIS.OCS.OrderInterface();

            /*this.layDeletedData.SavePerformer = new XSavePeformer(this);
            this.laySaveLayout.SavePerformer = this.layDeletedData.SavePerformer;*/

            if (aOpenParam != null) // 다른 화면에서 콜되는 경우
            {
                #region 파라미터 셋팅

                if (aOpenParam.Contains("caller_sys_id"))
                {
                    this.mCallerSysID = aOpenParam["caller_sys_id"].ToString();
                }

                // 오더일자
                if (aOpenParam.Contains("order_date"))
                {
                    this.mOrderDate = aOpenParam["order_date"].ToString();
                }
                else
                {
                    this.mOrderDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
                }

                // 환자번호
                if (aOpenParam.Contains("bunho"))
                {
                    this.mBunho = aOpenParam["bunho"].ToString();
                }

                // 입원외래 구분
                if (aOpenParam.Contains("io_gubun"))
                {
                    this.IOEGUBUN = aOpenParam["io_gubun"].ToString();
                }

                // 입력구분 셋팅
                if (aOpenParam.Contains("input_gubun"))
                {
                    this.mInputGubun = aOpenParam["input_gubun"].ToString();

                    this.mOrderBiz.LoadColumnCodeName("code", "INPUT_GUBUN", this.mInputGubun, ref this.mInputGubunName);
                }

                // 입력파트 셋팅
                if (aOpenParam.Contains("input_part"))
                {
                    this.mInputPart = aOpenParam["input_part"].ToString();
                }
                else
                {
                    this.mInputPart = "*";
                }



                //// 입력구분명 셋팅
                //if (aOpenParam.Contains("input_gubun_name"))
                //{
                //    this.mInputGubunName = aOpenParam["input_gubun_name"].ToString();
                //    this.dbxInputGubunName.SetDataValue("【 " + this.mInputGubunName + " 】");
                //}

                // 외래, 혹은 입원 키가ㅄ
                if (aOpenParam.Contains("naewon_key"))
                {
                    this.mPkInOutKey = aOpenParam["naewon_key"].ToString();
                }

                // 환자정보
                if (aOpenParam.Contains("patient_info"))
                {
                    this.mPatientInfo = ((PatientInfo)aOpenParam["patient_info"]);
                }

                // 오더 입력모드 설저ㅓㅇ
                if (aOpenParam.Contains("order_mode"))
                {
                    this.mOrderMode = (OrderVariables.OrderMode)aOpenParam["order_mode"];
                    this.SetVisiblePatientInfoPanel();
                }

                // 셋트 키
                if (aOpenParam.Contains("memb"))
                {
                    this.mMemb = aOpenParam["memb"].ToString();
                }

                if (aOpenParam.Contains("yaksok_code"))
                {
                    this.mYaksokCode = aOpenParam["yaksok_code"].ToString();
                }

                // CP 키
                if (aOpenParam.Contains("cp_master_key"))
                {
                    this.mCpMasterkey = aOpenParam["cp_master_key"].ToString();
                }

                if (aOpenParam.Contains("memb_gubun"))
                {
                    this.mMembGubun = aOpenParam["memb_gubun"].ToString();
                }

                if (aOpenParam.Contains("cp_code"))
                {
                    this.mCpCode = aOpenParam["cp_code"].ToString();
                }

                if (aOpenParam.Contains("cp_path_code"))
                {
                    this.mCpPathCode = aOpenParam["cp_path_code"].ToString();
                }

                if (aOpenParam.Contains("jaewonil"))
                {
                    this.mJaewonil = aOpenParam["jaewonil"].ToString();
                }

                // 오더 DataRow 
                if (aOpenParam.Contains("in_data_row"))
                {
                    this.mInDataRow = ((DataTable)aOpenParam["in_data_row"]);

                    SetInitialOrderGridData(this.mInDataRow);

                }
                //inset by jc OCS1003P01のDoオーダ関連
                if (aOpenParam.Contains("in_do_data_row"))
                {
                    this.mInDoDataRow = ((MultiLayout)aOpenParam["in_do_data_row"]);
                }

                if (aOpenParam.Contains("do_order"))
                {
                    this.mDo_order = Boolean.Parse(aOpenParam["do_order"].ToString());
                }

                if (this.mDo_order == true)
                {
                    this.ParentForm.WindowState = FormWindowState.Minimized;
                    this.ApplyCopyOrderInfo(this.mInDoDataRow, HangmogInfo.ExecutiveMode.BeforeOrderCopy);
                    //HandleBtnListButtonClick(FunctionType.Update);
                    //HandleBtnListButtonClick(FunctionType.Close);
                    return this.mInputGubunName;
                }
                //his.MakeGroupTabInfo(this.IOEGUBUN, this.mPkInOutKey, this.mInputGubun, INPUTTAB);

                if (aOpenParam.Contains("currentRowNum"))
                {
                    this.mCurrentRowNum = int.Parse(aOpenParam["currentRowNum"].ToString());
                }

                if (aOpenParam.Contains("currentDataWindow"))
                {
                    this.mCurrentDataWindow = (XDataWindow)aOpenParam["currentDataWindow"];
                }

                if (aOpenParam.Contains("currentColName"))
                {
                    this.mCurrentColName = aOpenParam["currentColName"].ToString();
                }

                if (aOpenParam.Contains("startRowNum"))
                {
                    this.mStartRowNum = int.Parse(aOpenParam["startRowNum"].ToString());
                }

                if (aOpenParam.Contains("protocol_id"))
                {
                    this.mprotocolID = aOpenParam["protocol_id"].ToString();
                }

                #endregion

                this.Focus();
            }
            else
            {

                //// 이전 스크린의 등록번호를 가져온다
                //XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                //if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                //{
                //    // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                //    patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                //}

                //if (patientInfo != null && !TypeCheck.IsNull(patientInfo.BunHo))
                //{
                //    this.fbxBunho.Focus();
                //    this.fbxBunho.SetEditValue(patientInfo.BunHo);
                //    this.fbxBunho.AcceptData();
                //}

                //this.Focus();
            }

            //insert into [検索語の検索条件初期化] 2012/10/15 
            //Random selected [like %word%]
            //Front selected [like word%]
            string mSentouSearchYN = this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "SENTOU_SEARCH_YN", this.IOEGUBUN);
            if (mSentouSearchYN == "Y")
                //this.cbxSentou.Checked = true;
                this.cboSearchCondition.SelectedIndex = 1;
            else
                this.cboSearchCondition.SelectedIndex = 0;

            // 신규 탭페이지 설정
            this.tpgNew.Title = XMsg.GetMsg("M002"); // 신규로 작성
            this.tpgNew.ImageIndex = 1;
            Hashtable groupInfo = new Hashtable();
            groupInfo.Add("group_ser", "0");
            groupInfo.Add("group_name", "New");

            // 처방구분정보 Load
            mDtOrderGubun = this.mOrderBiz.LoadComboDataSource("order_gubun_bas").LayoutTable;

            // 라디오 버튼
            if (this.rbnOftenOrder.Checked == false)
            {
                this.rbnOftenOrder.Checked = true;
            }

            this.InitScreen();

            // 수량, 횟수 콤보 구성
            this.mOrderBiz.SetNumCombo(this.grdOrder, "suryang", true);
            // 수량, 횟수 콤보 구성
            this.mOrderBiz.SetNumCombo(this.grdOrder, "nalsu", false);

            this.InitializeScreen();

            //MessageBox.Show("Onload end");

            //PostCallHelper.PostCall(new PostMethod(PostLoad));
            PostLoad(aOpenParam);

            this.btnInsert.Visible = true;
            isOpenPopUp = aOpenParam.Contains("isOpenPopUp") ? (bool)aOpenParam["isOpenPopUp"] : true;
            if (aOpenParam.Contains("isOpenPopUp") && aOpenParam["isOpenPopUp"].Equals(true))
            {
                this.btnInsert.Visible = false;
            }

            return this.mInputGubunName;

        }
        private void SetEnableUcGrid(bool isEnable)
        {
            //tabGroup.Enabled = isEnable;
            grdOrder.Enabled = isEnable;
            grdSangyongOrder.Enabled = isEnable;
            cbxEmergency.Enabled = isEnable;
            pnlOrderDetail.Enabled = isEnable;
            btnSpecificComment.Enabled = isEnable;
            btnDoOrder.Enabled = isEnable;
            btnSetOrder.Enabled = isEnable;
            btnInsert.Enabled = isEnable;
            btnNewSelect.Enabled = isEnable;
            btnSelect.Enabled = isEnable;

            if (isEnable) cbxEmergency.CheckedChanged += cbxEmergency_CheckedChanged;
            else cbxEmergency.CheckedChanged -= cbxEmergency_CheckedChanged;

            if (mBtnCopy != null) mBtnCopy.Enabled = isEnable;
            if (mBtnPaste != null) mBtnPaste.Enabled = isEnable;

            //right
            cboQueryCon.Enabled = isEnable;
            cboSearchCondition.Enabled = isEnable;
            txtSearch.Enabled = isEnable;
        }

        // DataWindowからのクリックで自動フォーカス設定
        private void setFocusGotoColumn()
        {
            //insert by jc [OCS1003P01のデータウインドーウで選択されたROWがあった場合の処理]
            //位置検索はすべてhangmog_codeで検索する
            //コメントのROWにもOrderBizで該当するHangmog_codeを入れているので検索可能である。
            //カーソルのコントロールの際にはgrdOrderのグリドを同時に動かす。
            //pkocskeyは使えない。なぜかというとpkocskeyは保存される際、トリガーによって与えられるので保存されてない状態では使えないのだ

            int currentRow = -1;
            if (mCurrentRowNum > 0)
            {
                //[OCS1003P01のデータウインドウで選択されたcolumnのデータ取得]
                string currentData = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, this.mCurrentColName);
                //[OCS1003P01のデータウインドウで選択されたgroup_ser取得]
                string currentGroupSer = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "group_ser_num");

                //[該当するGROUPTABに移動]
                this.SelectGroupTab(currentGroupSer);

                if (this.mCurrentColName == "hangmog_name"
                    || (this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "bogyong_code_yn") == "N" && this.mCurrentColName == "order_detail")
                    || (this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "bogyong_code_yn") == "N" && this.mCurrentColName == "order_info"))
                {
                    //[OCS1003P01のデータウインドウで選択されたhangmog_name取得]
                    string currentHangmogCode = this.mCurrentDataWindow.GetItemString(this.mCurrentRowNum, "hangmog_code");

                    //[OCS1003P01のデータウインドウで選択されたデータの位置検索]
                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        if (this.grdOrder.GetItemString(i, "hangmog_code") == currentHangmogCode && this.grdOrder.GetItemString(i, "group_ser") == currentGroupSer)
                        {
                            currentRow = i;
                            break;
                        }
                    }
                }

                switch (this.mCurrentColName)
                {
                    case "hangmog_name":
                        this.grdOrder.SetFocusToItem(currentRow, "hangmog_code", true);
                        break;
                    case "order_detail":
                        this.grdOrder.SetFocusToItem(currentRow, "suryang", true);
                        break;
                    case "order_info":
                        if (currentData.Substring(0, 1) == "└")
                        {
                            this.grdOrder.SetFocusToItem(currentRow, "order_remark", true);
                        }
                        else if (currentData.Substring(1, 1) == Resources.TEXT1)
                        {
                            this.grdOrder.SetFocusToItem(currentRow, "hope_date", true);
                        }
                        break;
                }
            }
        }

        // DataWindowからのクリックで自動フォーカス設定
        private void SelectGroupTab(string aGroupSer)
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            {
                if (((Hashtable)tpg.Tag)["group_ser"].ToString() == aGroupSer)
                {
                    this.tabGroup.SelectedTab = tpg;
                    return;
                }
            }
        }

        #endregion

        #region [ 각종 초기화 ]

        private void InitScreen()
        {
            //this.grdOrder.AutoSizeColumn(13, 0);　//비치
            this.grdOrder.AutoSizeColumn(16, 0); //配置

            // 셋트 오더인경우는 정시약, 반납지시 컬럼이 보이면 안됨. 그룹시리얼도
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                this.grdOrder.AutoSizeColumn(2, 0);//返却指示
                //this.grdOrder.AutoSizeColumn(15, 0);
                this.grdOrder.AutoSizeColumn(8, 0);//希望日
                this.grdOrder.AutoSizeColumn(17, 0);//行為部署
            }
            // 의사 오더인 경우는 반납지시 컬럼이 보이지 않는다.
            else if (UserInfo.UserGubun == UserType.Doctor)
            {
                this.grdOrder.AutoSizeColumn(2, 0);//返却指示
            }

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder)
            {
                this.grdOrder.AutoSizeColumn(18, 0);  // 외래 행위부서
                this.grdOrder.AutoSizeColumn(19, 0);  // 입원 행위부서
            }
            else
            {
                this.grdOrder.AutoSizeColumn(17, 0);//行為部署
            }


            // 입원 외래에 따른 조회 조건 기본셋팅값
            if (this.IOEGUBUN == "O")
            {
                this.cboQueryCon.SetDataValue("%"); // 전체 기본
            }
            else
            {
                this.cboQueryCon.SetDataValue("Y"); // 원내 채용약 기본
            }


            // 팝업메뉴 초기화
            // 오더 팝업메뉴
            // 처방Grid PopupMenu
            popupOrderMenu.MenuCommands.Clear();
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.TEXT1, (Image)this.imageListPopupMenu.Images[0],
                new EventHandler(PopUpMenuSelectAll_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.TEXT2, (Image)this.imageListPopupMenu.Images[1],
                new EventHandler(PopUpMenuUnSelectAll_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.TEXT3, (Image)this.imageListPopupMenu.Images[2],
                new EventHandler(PopUpMenuInsert_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.TEXT4, (Image)this.imageListPopupMenu.Images[3],
                new EventHandler(PopUpMenuPaste_Click)));
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.TEXT5, (Image)this.imageListPopupMenu.Images[4],
                new EventHandler(PopUpMenuDelete_Click)));
            //popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.TEXT6, (Image)this.imageListPopupMenu.Images[7],
            //    new EventHandler(PopUpMenuSelectOftenOrder_Click)));
            //popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.TEXT7, (Image)this.imageListPopupMenu.Images[8],
            //    new EventHandler(PopUpMenuRecoverToDandok_Click)));

            // 상용오더 팝업메뉴
            popupOftenUsedMenu.MenuCommands.Clear();
            popupOftenUsedMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.TEXT5, (Image)this.imageListPopupMenu.Images[4],
                new EventHandler(PopUpMenuSelectOftenOrderDelete_Click)));
        }

        private void SetInitialOrderGridData(DataTable aInData)
        {
            //modify by jc
            //foreach (DataRow dr in this.mInDataRow.Rows)
            foreach (DataRow dr in aInData.Rows)
            {
                this.grdOrder.LayoutTable.ImportRow(dr);
            }

            this.grdOrder.DisplayData();

            this.DiaplayMixGroup(this.grdOrder);

            // 부모자식 이미지 셋팅
            this.SetImageToGrid(this.grdOrder);

            // 의사오더 이미지 셋팅
            this.SetOrderImage(this.grdOrder);
        }

        #endregion

        #region [ 다른 화면 오픈 ]

        private void OpenScreen_CHT0117Q00(string aOrderGubun)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("order_gubun", aOrderGubun);

            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0117Q00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        /// <summary>
        /// 항목코드 파인드 창 오픈
        /// </summary>
        /// <param name="aHangmogCode">검색어</param>
        /// <param name="aMultiSelect">복수선택여부</param>
        private void OpenScreen_OCS0103Q00(string aHangmogCode, bool aMultiSelect)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("hangmog_code", aHangmogCode);
            param.Add("multiSelect", true);
            param.Add("input_tab", INPUTTAB);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_OCS0208Q00()
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("suryang", "");
            openParams.Add("dv", "");
            openParams.Add("dv_time", "");
            openParams.Add("dv_1", "");
            openParams.Add("dv_2", "");
            openParams.Add("dv_3", "");
            openParams.Add("dv_4", "");
            openParams.Add("dv_5", "");
            openParams.Add("order_remark", "");

            openParams.Add("bogyong_code", "");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0208Q00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS0301Q09()
        {
            string naewon_date = mOrderDate.PadRight(10).Substring(0, 10).Replace("-", "/");

            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("input_tab", INPUTTAB);

            if (UserInfo.Gwa == "CK")
            {
                openParams.Add("gwa", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
                openParams.Add("memb", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString());
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

            openParams.Add("patient_info", this.mPatientInfo);

            //약속코드조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0301Q09", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS1003Q09(bool aIsAutoClose)
        {
            // 처방 입력 가능 여부

            //해당 내원의 처방정보를 가져온다.
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mPatientInfo.GetPatientInfo["bunho"].ToString());

            if (UserInfo.Gwa == "CK")
            {
                openParams.Add("gwa", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
                openParams.Add("doctor", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString());
            }
            else
            {
                openParams.Add("gwa", mPatientInfo.GetPatientInfo["gwa"].ToString());
                openParams.Add("doctor", mPatientInfo.GetPatientInfo["doctor"].ToString());
            }


            openParams.Add("naewon_date", mOrderDate);
            if (UserInfo.UserGubun == UserType.Doctor)
                openParams.Add("input_gubun", "D%");
            else
                openParams.Add("input_gubun", this.mInputGubun);
            //openParams.Add("tel_yn"     , "N"); // 간호 입력분은 뺀다 
            openParams.Add("tel_yn", "%"); // 약만 타러온 환자건도 있다

            openParams.Add("auto_close", aIsAutoClose);
            openParams.Add("input_tab", INPUTTAB);
            openParams.Add("io_gubun", this.IOEGUBUN);

            openParams.Add("childYN", "N");
            openParams.Add("patient_info", this.mPatientInfo);

            //전처방조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q09", ScreenOpenStyle.ResponseSizable, openParams);
        }

        /// <summary>
        /// 의뢰서 화면 오픈
        /// </summary>
        /// <param name="aGrid"></param>
        /// <param name="aRowNumber"></param>
        private void OpenScreen_SpecificComment(XEditGrid aGrid, int aRowNumber)
        {
            if (aGrid.GetItemString(aRowNumber, "specific_comment_pgm_id") == "")
            {
                MessageBox.Show(XMsg.GetMsg("M008"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aGrid.GetItemString(aRowNumber, "bunho"));
            openParams.Add("order_date", aGrid.GetItemString(aRowNumber, "order_date"));
            if (aGrid.GetItemString(aRowNumber, "pkocskey") == "")
            {
                aGrid.SetItemValue(aRowNumber, "pkocskey", this.mOrderFunc.GetOrderKey(this.mOrderMode));
            }

            openParams.Add("pkocskey", aGrid.GetItemString(aRowNumber, "pkocskey"));

            openParams.Add("in_out_gubun", this.IOEGUBUN);
            openParams.Add("hangmog_code", aGrid.GetItemString(aRowNumber, "hangmog_code"));
            openParams.Add("gwa", aGrid.GetItemString(aRowNumber, "gwa"));
            openParams.Add("doctor", aGrid.GetItemString(aRowNumber, "doctor"));

            string sysid = aGrid.GetItemString(aRowNumber, "specific_comment_sys_id");
            string pgmid = aGrid.GetItemString(aRowNumber, "specific_comment_pgm_id");

            XScreen.OpenScreenWithParam(this, sysid, pgmid, ScreenOpenStyle.ResponseFixed, openParams);
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

        #region [ 각종 비지니스 메소드 ]

        /// <summary>
        /// 그룹탭 선택시 그룹관련 정보들 셋팅
        /// </summary>
        /// <param name="aGroupInfo">그룹정보</param>
        private void SetGroupControl(Hashtable aGroupInfo)
        {
            // 긴급여부
            this.cbxEmergency.SetDataValue(aGroupInfo["emergency"].ToString());
        }

        /// <summary>
        /// 그룹정보 프로텍트 여부 
        /// </summary>
        /// <param name="aGroupSer">그룹시리얼</param>
        private void ProtectGroupControl(string aGroupSer)
        {
            DataRow[] dr = this.grdOrder.LayoutTable.Select("group_ser=" + aGroupSer);
            bool isProtect = false;

            for (int i = 0; i < dr.Length; i++)
            {
                if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                    this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
                {
                    isProtect = false;
                    break;
                }

                //if (dr[i].RowState != DataRowState.Added && dr[i]["ocs_flag"].ToString() != "0" && dr[i]["ocs_flag"].ToString() != "1")
                if (dr[i].RowState != DataRowState.Added && (dr[i]["ocs_flag"].ToString() != "0" && dr[i]["ocs_flag"].ToString() != "1" || dr[i]["sunab_yn"].ToString() == "Y"))
                {
                    isProtect = true;
                    break;
                }
            }

            foreach (Control ctrl in this.pnlOrderDetail.Controls)
            {
                if (ctrl is IDataControl)
                {
                    ((IDataControl)ctrl).Protect = isProtect;
                }
            }
        }

        /// <summary>
        /// 오더모드에 따른 환자정보 패널 셋팅
        /// </summary>
        private void SetVisiblePatientInfoPanel()
        {
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                if (this.MPnlTop != null) this.MPnlTop.Visible = false;
                this.btnDoOrder.Visible = false;
                //delete by jc [セットオーダを登録する際にも既存のセットオーダを参考にしたいという要請] 2012/04/24
                //this.btnSetOrder.Visible = false;
                this.btnSpecificComment.Visible = false;
            }
        }

        private void GridInitValueSetting(XEditGrid aGrid, int aRowNumber)
        {
            string temp = "";

            if (tabGroup.SelectedTab == null) return;

            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            // 그룹시리얼 셋팅
            if (groupInfo.Contains("group_ser"))
                aGrid.SetItemValue(aRowNumber, "group_ser", groupInfo["group_ser"].ToString());

            // 복용코드
            if (groupInfo.Contains("bogyong_code"))
                aGrid.SetItemValue(aRowNumber, "bogyong_code", groupInfo["bogyong_code"].ToString());

            // 긴급
            if (groupInfo.Contains("emergency"))
                aGrid.SetItemValue(aRowNumber, "emergency", groupInfo["emergency"].ToString());

            // 원외처방
            if (groupInfo.Contains("wonyoi_order_yn"))
                aGrid.SetItemValue(aRowNumber, "wonyoi_order_yn", groupInfo["wonyoi_order_yn"].ToString());

            // 환자정보
            if ((this.mOrderMode != OrderVariables.OrderMode.SetOrder && this.mOrderMode != OrderVariables.OrderMode.CpSetOrder) && this.mPatientInfo != null)
            {
                aGrid.SetItemValue(aRowNumber, "bunho", this.mPatientInfo.GetPatientInfo["bunho"].ToString());
            }

            // 입력탭 정보
            aGrid.SetItemValue(aRowNumber, "input_tab", INPUTTAB);
            this.mOrderBiz.LoadColumnCodeName("code", "INPUT_TAB", INPUTTAB, ref temp);
            aGrid.SetItemValue(aRowNumber, "input_tab_name", temp);

            //aGrid.SetItemValue(aRowNumber, "in_out_key", this.mPkInOutKey);
            aGrid.SetItemValue(aRowNumber, "input_part", this.mInputPart);
            aGrid.SetItemValue(aRowNumber, "input_gubun", this.mInputGubun);
            aGrid.SetItemValue(aRowNumber, "input_gubun_name", this.mInputGubunName);

            aGrid.SetItemValue(aRowNumber, "order_date", mOrderDate);

            // 진료정보 ( 오더일자, 진료과, 의사 )
            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                if (UserInfo.UserGubun == UserType.Doctor)
                {
                    aGrid.SetItemValue(aRowNumber, "input_doctor", UserInfo.DoctorID);
                    aGrid.SetItemValue(aRowNumber, "input_gwa", UserInfo.Gwa);
                }
                else if (UserInfo.Gwa == "CK")
                {
                    aGrid.SetItemValue(aRowNumber, "input_doctor", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString());
                    aGrid.SetItemValue(aRowNumber, "input_gwa", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
                }
                else
                {
                    aGrid.SetItemValue(aRowNumber, "input_doctor", this.mPatientInfo.GetPatientInfo["doctor"].ToString());
                    aGrid.SetItemValue(aRowNumber, "input_gwa", this.mPatientInfo.GetPatientInfo["gwa"].ToString());

                    // 간호사인경우는 간호픽업 데이트를 자동입력한다.
                    if (UserInfo.UserGubun == UserType.Nurse)
                    {
                        aGrid.SetItemValue(aRowNumber, "nurse_pickup_user", UserInfo.UserID);
                        aGrid.SetItemValue(aRowNumber, "nurse_pickup_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                        aGrid.SetItemValue(aRowNumber, "nurse_pickup_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                    }
                }

                aGrid.SetItemValue(aRowNumber, "input_id", UserInfo.UserID);

                aGrid.SetItemValue(aRowNumber, "gwa", this.mPatientInfo.GetPatientInfo["gwa"].ToString());
                aGrid.SetItemValue(aRowNumber, "doctor", this.mPatientInfo.GetPatientInfo["doctor"].ToString());
                aGrid.SetItemValue(aRowNumber, "resident", this.mPatientInfo.GetPatientInfo["doctor"].ToString());

                // 접수및 입원정보
                if (this.IOEGUBUN == "O")
                {
                    aGrid.SetItemValue(aRowNumber, "naewon_type", this.mPatientInfo.GetPatientInfo["naewon_type"].ToString());
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
                    aGrid.SetItemValue(aRowNumber, "in_out_key", this.mPkInOutKey);
                }
            }
            // 셋트오더인경우
            else
            {
                if (this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
                    aGrid.SetItemValue(aRowNumber, "in_out_key", this.mPkInOutKey);

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


        }

        private void ApplyDefaultOrderInfo(MultiLayout aSourceLayout, int aSettingRow, bool aIsCallCodeInput)
        {
            int parentKey = -1;
            string ordergubunname = "";
            int settingRow = aSettingRow;
            Hashtable groupInfo;

            if (this.tabGroup.SelectedTab == null)
                HandleBtnListButtonClick(FunctionType.Process);

            groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            // 그리드 상에서 직접 입력할때와 뭔가를 통해 입력할때...
            // 어디다 집어 넣어야 할지에 대한 헷갈림...
            // 직접 넣을 때는 현재 로우에 무조건 넣어야 하는데...
            // 근데... 뭔가를 통해서 넣을때는 현재 로우에 데이터가 있으면 안되거덩...
            // 그래서 저 컬럼을 두고 aIsCallCodeInput 이 true이면 무조건 현재 로우에 넣는거야...
            // 그거는 그리드에서 컬럼 체인지 탈때만...
            if (aIsCallCodeInput == false)
            {
                XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(settingRow);
                    settingRow = this.grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }
            }

            for (int i = 0; i < aSourceLayout.RowCount; i++)
            {
                if (i != 0)
                {
                    this.OrderGridCreateNewRow(settingRow);
                    settingRow = this.grdOrder.CurrentRowNumber;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, aSourceLayout.LayoutTable.Rows[i]) == false)
                {
                    return;
                }

                foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                {
                    if (aSourceLayout.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        this.grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = aSourceLayout.LayoutTable.Rows[i][cl.ColumnName];
                    }
                }

                // 디폴트 일수 
                if (TypeCheck.IsNull(this.grdOrder.LayoutTable.Rows[settingRow]["nalsu"]))
                    this.grdOrder.LayoutTable.Rows[settingRow]["nalsu"] = 1;

                // 오더 구분 관련 
                //if (aSourceLayout.GetItemString(i, "order_gubun").Length < 2)
                //    this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, settingRow) + aSourceLayout.GetItemString(i, "order_gubun");
                //else
                //    this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, settingRow) + aSourceLayout.GetItemString(i, "order_gubun").Substring(1, 1);

                //if (this.mOrderBiz.LoadColumnCodeName("code", "ORDER_GUBUN_BAS", this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"].ToString().Substring(1, 1), ref ordergubunname))
                //{
                //    if (ordergubunname == "")
                //    {
                //        ordergubunname = "そのた";
                //    }
                //}
                //else
                //{
                //    ordergubunname = "そのた";
                //}

                //this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun_name"] = ordergubunname;
                //this.grdOrder.LayoutTable.Rows[currRow]["order_gubun_bas_name"] = ordergubunname;

                // 오더 구분 관련 
                if (aSourceLayout.GetItemString(i, "order_gubun").Length < 2)
                    this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, settingRow) + aSourceLayout.GetItemString(i, "order_gubun");
                else
                    this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, settingRow) + aSourceLayout.GetItemString(i, "order_gubun").Substring(1, 1);

                if (this.mOrderMode == OrderVariables.OrderMode.SetOrder)
                {
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table_out"] = aSourceLayout.GetItemString(i, "jundal_table_out");
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table_inp"] = aSourceLayout.GetItemString(i, "jundal_table_inp");
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part_out"] = aSourceLayout.GetItemString(i, "jundal_part_out");
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part_inp"] = aSourceLayout.GetItemString(i, "jundal_part_inp");
                    this.grdOrder.LayoutTable.Rows[settingRow]["move_part_out"] = aSourceLayout.GetItemString(i, "move_part");
                    this.grdOrder.LayoutTable.Rows[settingRow]["move_part_inp"] = aSourceLayout.GetItemString(i, "move_part");
                }
                else
                {
                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = aSourceLayout.GetItemString(i, "jundal_table_out");
                    else
                        this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = aSourceLayout.GetItemString(i, "jundal_table_inp");

                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = aSourceLayout.GetItemString(i, "jundal_part_out");
                    else
                        this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = aSourceLayout.GetItemString(i, "jundal_part_inp");
                }
                // 입력컨트롤이 시간 분인경우 시간분 입력창을 띄운다...


                // 부모자식 연관관계 셋팅
                if (aSourceLayout.GetItemString(i, "child_yn") == "Y")
                {
                    parentKey = this.mOrderFunc.GetParentOrderKey(this.mOrderMode, this.grdOrder.LayoutTable, settingRow - 1);

                    if (parentKey < 0)
                    {
                        this.grdOrder.LayoutTable.Rows[settingRow]["child_yn"] = "N";
                    }
                    else
                    {
                        this.mOrderFunc.SetParentInfoToChild(this.grdOrder, parentKey.ToString(), settingRow);
                    }
                }
                else
                {
                    this.grdOrder.LayoutTable.Rows[settingRow]["child_yn"] = "N";
                }

                // 나중에 순서 재정렬을 위하여 dummy 값을 채워주고 재정렬후 뺀다.
                this.grdOrder.SetItemValue(settingRow, "dummy", "mageshin");

                this.grdOrder.DisplayData();

                //this.SetOrderImage(this.grdOrder);

            }

        }

        private void ApplySangOrderInfo(string aHangmogCode, int aRowNumber, HangmogInfo.ExecutiveMode mExecutiveMode, bool aIsApplyCurrentRow)
        {
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.mInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IOEGUBUN;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey = this.mPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            #region 그룹정보 및 항목코드 셋팅

            MultiLayout loadExtraInfo = new MultiLayout();

            loadExtraInfo.LayoutItems.Add("hangmog_code", DataType.String);
            loadExtraInfo.LayoutItems.Add("group_ser", DataType.String);
            loadExtraInfo.LayoutItems.Add("emergency", DataType.String);
            loadExtraInfo.InitializeLayoutTable();

            Hashtable groupInfo;

            if (this.tabGroup.SelectedTab == null)
                HandleBtnListButtonClick(FunctionType.Process);

            groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            loadExtraInfo.InsertRow(-1);
            // 항목정보
            loadExtraInfo.SetItemValue(0, "hangmog_code", aHangmogCode);
            // 그룹정보 로드
            // 그룹시리얼
            if (groupInfo.Contains("group_ser"))
            {
                loadExtraInfo.SetItemValue(0, "group_ser", groupInfo["group_ser"].ToString());
            }
            // Emergency
            if (groupInfo.Contains("emergency"))
            {
                loadExtraInfo.SetItemValue(0, "emergency", groupInfo["emergency"].ToString());
            }

            #endregion

            if (this.mHangmogInfo.LoadHangmogInfo(mExecutiveMode, loadExtraInfo) == false)
            {
                return;
            }



            this.ApplyDefaultOrderInfo(this.mHangmogInfo.GetHangmogInfo, aRowNumber, aIsApplyCurrentRow);

            //PostCallHelper.PostCall(new PostMethodObject(PostOrderInsert), currRow);

        }

        private void ApplyCopyOrderInfo(MultiLayout aSourceLayout, OCS.HangmogInfo.ExecutiveMode aMode)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo;

            bool isMerge = true;

            // insert by jc
            if (this.tabGroup.SelectedTab == null)
                HandleBtnListButtonClick(FunctionType.Process);

            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.mInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IOEGUBUN;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey = this.mPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor = this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString();
                //this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = this.cbxWonyoiOrderYN.GetDataValue();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }

            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(this.grdOrder.CurrentRowNumber);
                settingStart = this.grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;

            // 그룹정보
            groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            //foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(this.grdOrder.CurrentRowNumber);
                    settingRow = this.grdOrder.CurrentRowNumber;
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

                foreach (DataColumn cl in this.grdOrder.LayoutTable.Columns)
                {
                    if (groupInfo.Contains(cl.ColumnName))
                    {
                        this.grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                    }
                    else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        if (cl.ColumnName != "child_gubun" &&
                            cl.ColumnName != "parent_gubun")
                            this.grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (dr["order_gubun"].ToString().Length < 2)
                    this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, settingRow) + dr["order_gubun"].ToString();
                else
                    this.grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] = this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, this.grdOrder, settingRow) + dr["order_gubun"].ToString().Substring(1, 1);

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                else
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                else
                    this.grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                {
                    this.grdOrder.SetItemValue(settingRow, "child_yn", "N");
                    mParentInfo = new Hashtable();
                    mParentInfo.Add("row_num", settingRow);
                    mParentInfo.Add("key", dr["org_key"].ToString());

                    mParentList.Add(mParentInfo);
                }
                else
                {
                    this.grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                }

                this.grdOrder.SetItemValue(settingRow, "dummy", "mageshin");
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, this.grdOrder, settingStart, settingEnd, mParentList, this.mCurrentRow);

            PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));

            //this.SetOrderImage(this.grdOrder);
        }

        private void InvokeReturnSendReturnDataTable()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("isOpenPopUp", isOpenPopUp);
            if (this.mOrderMode == OrderVariables.OrderMode.InpOrder && this.mCallerScreenID != "OCS2003P01")
                param.Add("apl_order", this.laySaveLayout);
            else
                param.Add("apl_order", this.grdOrder);

            if (MOpener != null) MOpener.Command("OCS0103U15", param);
        }

        private bool IsUpdateCheck()
        {
            Hashtable groupInfo;
            ArrayList delList = new ArrayList();
            bool isUpdatable = true;
            string msg = "";
            string cap = "";

            #region 체크전 데이터 확인 ( 빈로우, 빈그룹 삭제 )

            if (mOrderFunc == null) return false;

            this.mOrderFunc.DeleteEmptyNewRow(this.grdOrder);

            // 빈그룹 삭제
            foreach (IHIS.X.Magic.Controls.TabPage delgroup in this.tabGroup.TabPages)
            {
                groupInfo = delgroup.Tag as Hashtable;

                if (this.mOrderFunc.IsEmptyGroup(this.grdOrder, groupInfo["group_ser"].ToString()))
                {
                    delList.Add(delgroup);
                }
            }

            for (int i = 0; i < delList.Count; i++)
            {
                this.tabGroup.TabPages.Remove((X.Magic.Controls.TabPage)delList[i]);
            }

            #endregion

            #region 업데이트 체크
            // 그룹정보 입력체크 
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            {
                groupInfo = tpg.Tag as Hashtable;

            }
            ///////////////////////////////////////////////////////////////////////////////////
            if (isUpdatable == false)
            {
                cap = XMsg.GetField("F001"); // 확인

                MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return isUpdatable;
            }

            #endregion

            #region 업데이트 체크

            string dupGroup = "";
            string dupRow = "";
            string colName = "";

            //modify by jc [オーダ登録画面では重複チェックを行わないようにLib修正後パラメータ追加] 2012/03/30
            //if (this.mOrderBiz.CheckSaveOrder(this.grdOrder.LayoutTable, ref dupGroup, ref dupRow, ref colName) == false)
            if (this.mOrderBiz.CheckSaveOrder(this.grdOrder.LayoutTable, ref dupGroup, ref dupRow, ref colName, false) == false)
            {
                isUpdatable = false;
                foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
                {
                    if (((Hashtable)tpg.Tag)["group_ser"].ToString() == dupGroup)
                    {
                        this.tabGroup.SelectedTab = tpg;
                        this.grdOrder.Focus();
                        if (TypeCheck.IsInt(dupRow))
                        {
                            int rowNumber = int.Parse(dupRow);

                            if (rowNumber >= 0)
                            {
                                this.grdOrder.Focus();
                                this.grdOrder.SetFocusToItem(rowNumber, TypeCheck.NVL(colName, "hangmog_code").ToString(), true);
                            }
                        }
                    }
                }
            }

            #endregion

            return isUpdatable;
        }

        #region Mix Group 데이타 Image Display (DiaplayMixGroup)
        /// <summary>
        /// Mix Group 데이타 Image Display
        /// </summary>
        /// <param name="aGrd"> XEditGrid </param>
        /// <returns> void  </returns>
        private void DiaplayMixGroup(XEditGrid aGrd)
        {
            if (aGrd == null) return;

            try
            {
                //aGrd.Redraw = false; // Grid Display 멈춤

                int imageCnt = 0;

                // 기존 image 클리어
                for (int i = 0; i < aGrd.RowCount; i++) aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;

                for (int i = 0; i < aGrd.RowCount; i++)
                {
                    if (aGrd.GetItemString(i, "dc_check") == "Y") continue;

                    // 이미 이미지 세팅이 안된건에 한해서 작업수행
                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
                    {
                        //이미수행한건 빼는로직이 있어야함..
                        int count = 0;
                        for (int j = i; j < aGrd.RowCount; j++)
                        {
                            // 동일 group_ser, 동일 mix_group, 동일 희망일자, 동일 OrderGubun가 Mix구별임..
                            if (aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
                                aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim() &&
                                aGrd.GetItemValue(i, "hope_date").ToString().Trim() == aGrd.GetItemValue(j, "hope_date").ToString().Trim() &&
                                aGrd.GetItemValue(i, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1) ==
                                aGrd.GetItemValue(j, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1))
                            {
                                count++;
                                if (count > 1)
                                {
                                    //      헤더를 빼야 실제 Row
                                    aGrd[j + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
                                    aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
                                }
                            }
                        }
                        // 현재는 image 갯수만큼 처리
                        if (count > 1) imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
                    }
                }
            }
            finally
            {
                //aGrd.Redraw = true; // Grid Display 
            }

        }
        #endregion

        #region 오더 그리드 신규 로우 생성

        private void OrderGridCreateNewRow(int aRowNumber)
        {
            this.grdOrder.InsertRow(aRowNumber);

            // 그룹 기준 셋팅
            this.GridInitValueSetting(this.grdOrder, this.grdOrder.CurrentRowNumber);
        }

        #endregion

        #region  부모 자식 이미지 셋팅

        private void SetImageToGrid(XEditGrid grd)
        {
            for (int i = 0; i < grd.RowCount; i++)
            {
                // 부모인경우
                if (grd.GetItemString(i, "child_yn") != "Y")
                {

                    grd[i + grd.HeaderHeights.Count, 1].Image = this.ImageGrouping.Images[0];

                }
                // 자식인경우
                else
                {
                    grd[i + grd.HeaderHeights.Count, 1].Image = this.ImageGrouping.Images[1];
                }
            }
        }

        #endregion

        #region 부모자식 관련 로우 재구성

        private int SetRowSort()
        {
            MultiLayout mTemp = this.grdOrder.CloneToLayout();
            DataRow[] dtRows = this.grdOrder.LayoutTable.Select("child_yn='N'");
            DataRow[] chRows = this.grdOrder.LayoutTable.Select("child_yn='Y'");
            ArrayList parentList = new ArrayList();
            ArrayList childList = new ArrayList();
            ArrayList addedList = new ArrayList();
            int lastRow = -1;

            // 부모 복사
            for (int i = 0; i < dtRows.Length; i++)
            {
                parentList.Add(dtRows[i]);
            }

            // 자식복사
            for (int j = 0; j < chRows.Length; j++)
            {
                childList.Add(chRows[j]);
            }

            foreach (DataRow tr in parentList)
            {
                mTemp.LayoutTable.ImportRow(tr);

                addedList.Clear();

                foreach (DataRow cr in childList)
                {
                    if (tr["pkocskey"].ToString() == cr["bom_source_key"].ToString())
                    {
                        mTemp.LayoutTable.ImportRow(cr);
                        addedList.Add(cr);
                    }
                }

                foreach (DataRow deldr in addedList)
                {
                    childList.Remove(deldr);
                }
            }


            this.grdOrder.SuspendLayout();


            //this.grdOrder.Reset();
            this.grdOrder.LayoutTable.Clear();

            foreach (DataRow imdr in mTemp.LayoutTable.Rows)
            {
                this.grdOrder.LayoutTable.ImportRow(imdr);
            }

            this.grdOrder.DisplayData();

            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.GetItemString(i, "dummy") == "mageshin")
                {
                    //this.grdOrder.SetFocusToItem(i, "hangmog_code", false);
                    this.grdOrder.SetItemValue(i, "dummy", "");
                    //break;
                    lastRow = i;
                }
            }

            //this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
            this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

            this.grdOrder.ResumeLayout();

            return lastRow;
        }

        #endregion

        #region 오더링 로우 이동

        private void MoveOrderRow(XEditGrid grid, int aSourceRowNumber, int aDestRowNumber)
        {
            if (aSourceRowNumber == aDestRowNumber) return;

            MultiLayout mTempLayout = grid.CloneToLayout();
            int parentKey = -1;

            for (int i = 0; i < grid.RowCount; i++)
            {
                if (i == aSourceRowNumber)
                    continue;

                if (i == aDestRowNumber)
                {
                    parentKey = this.mOrderFunc.GetParentOrderKey(this.mOrderMode, this.grdOrder.LayoutTable, i, true);

                    if (parentKey > 0)
                    {
                        this.grdOrder.SetItemValue(aSourceRowNumber, "child_yn", "Y");
                        this.grdOrder.SetItemValue(aSourceRowNumber, "bom_source_key", parentKey);

                        this.MoveOrderRowSub(grid, aSourceRowNumber);
                    }
                    else
                    {
                        this.grdOrder.SetItemValue(aSourceRowNumber, "child_yn", "N");
                        this.grdOrder.SetItemValue(aSourceRowNumber, "bom_source_key", "");
                    }

                    this.grdOrder.SetItemValue(aSourceRowNumber, "dummy", "mageshin");

                    mTempLayout.LayoutTable.ImportRow(grid.LayoutTable.Rows[aSourceRowNumber]);

                }

                mTempLayout.LayoutTable.ImportRow(grid.LayoutTable.Rows[i]);
            }
        }

        private void MoveOrderRowSub(XEditGrid grid, int aSourceRow)
        {
            if (grid.GetItemString(aSourceRow, "pkocskey") != "")
            {
                foreach (DataRow dr in grid.LayoutTable.Select("bom_source_key=" + grid.GetItemString(aSourceRow, "pkocskey")))
                {
                    dr["bom_source_key"] = grid.GetItemString(aSourceRow, "bom_source_key");
                }
            }
        }

        #endregion

        #region 처방Row 이동시 Control Display 변경처리(OrderRowMovingChangedDisplay)
        /// <summary>
        /// 처방Row 이동시 Control Display 변경처리
        /// </summary>
        /// <param name="aGrd"> XEditGrid  Grid </param>
        /// <param name="aRow"> int  Row </param>
        /// <returns> void </returns>
        private void OrderRowMovingChangedDisplay(XEditGrid aGrd, int aRow)
        {
            if (aGrd == null || aRow < 0) return;

            // 상태에 따른 필드헤더변경 (수량/날수 (마취처방코드인 경우 시간/분으로 표시), 부수술 (체감인경우 체감))
            this.mHangmogInfo.DisplaySpecialColHeader(IOEGUBUN, aGrd, aRow, aGrd.GetItemString(aRow, "hangmog_code").Trim());

            //			// 현재 버튼 크기가 작어서 처리못함
            //			if (!TypeCheck.IsNull(aGrd.GetItemString(aRow, "specific_comment_name")))
            //				this.btnSpecificComment.Text = aGrd.GetItemString(aRow, "specific_comment_name"); // 항목별 서식지관리 명칭
            //			else
            //				this.btnSpecificComment.Text = TypeCheck.NVL(this.btnSpecificComment.Tag, "").ToString(); // 항목별 서식지관리 최초 명칭으로 초기화
        }
        #endregion

        #region 반납 지시 관련 컬럼 보이기

        private void ShowDcGubun(XEditGrid aGrid, string aGroupSer)
        {
            DataRow[] dr = aGrid.LayoutTable.Select("group_ser=" + aGroupSer + " AND dc_gubun='Y'");

            if (dr != null && dr.Length > 0)
            {
                aGrid.AutoSizeColumn(2, 35);
            }
            else
            {
                aGrid.AutoSizeColumn(2, 0);
            }
        }

        #endregion

        #endregion

        #region [ 데이터 로드 ]

        // 탭정보 
        private void LoadGroupTabData(string aIOGubun, string aFkInOutKey, string aInputGubun, string aInputTab)
        {
            this.layGroupTab.SetBindVarValue("io_gubun", aIOGubun);
            this.layGroupTab.SetBindVarValue("fk_in_out_key", aFkInOutKey);
            this.layGroupTab.SetBindVarValue("input_gubun", aInputGubun);
            this.layGroupTab.SetBindVarValue("input_tab", aInputTab);

            this.layGroupTab.QueryLayout(true);
        }

        private void LoadOrderTable(OrderVariables.OrderMode aOrderMode, string aMemb, string aYaksokCode, string aFkInOutKey, string aInputGubun, string aInputTab, string aOrderGubun)
        {
            this.grdOrder.SetBindVarValue("memb", aMemb);
            this.grdOrder.SetBindVarValue("yaksok_code", aYaksokCode);
            this.grdOrder.SetBindVarValue("fk_in_out_key", aFkInOutKey);
            this.grdOrder.SetBindVarValue("input_tab", aInputTab);
            this.grdOrder.SetBindVarValue("input_gubun", aInputGubun);

            this.grdOrder.QueryLayout(true);
        }

        #endregion

        #region [ =======================================  그룹 탭 관련 ]

        #region 그룹탭 생성 관련

        /// <summary>
        /// 빈그룹이 존재하는지 여부
        /// </summary>
        /// <returns>true, false</returns>
        private bool IsExistEmptyGroup()
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            {
                Hashtable groupInfo = tpg.Tag as Hashtable;

                if (this.grdOrder.RowCount > 0)
                {
                    DataRow[] dr = grdOrder.LayoutTable.Select("group_ser=" + groupInfo["group_ser"].ToString());
                    if (dr.Length <= 0) return true;
                    else if (dr.Length == 1 && dr[0]["hangmog_code"].ToString() == "")
                    {
                        return true;
                    }
                }
                else
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 신규그룹페이지 생성하기
        /// </summary>
        private void MakeNewOrderGroup(bool aIsShowFindDlg)
        {
            if (this.IsExistEmptyGroup()) return;

            IHIS.X.Magic.Controls.TabPage tpg = new IHIS.X.Magic.Controls.TabPage();

            //int groupSer = (this.mHangmogInfo.GetMaxGroupSer(this.grdOrder) + 1);

            //2014/06/30 inserted by yjc
            int groupSer = 1;
            if (mPatientInfo.GetPatientInfo != null)
            {
                if (this.IOEGUBUN == "O")
                    //groupSer = (this.mHangmogInfo.GetMaxGroupSer(this.grdOrder) + 1);
                    groupSer = int.Parse(this.mHangmogInfo.GetNextGroupSer(INPUTTAB, this.mPatientInfo.GetPatientInfo["bunho"].ToString(), mPatientInfo.GetPatientInfo["naewon_key"].ToString(), "OCS1003"));
                else
                    groupSer = int.Parse(this.mHangmogInfo.GetNextGroupSer(INPUTTAB, this.mPatientInfo.GetPatientInfo["bunho"].ToString(), mPatientInfo.GetPatientInfo["naewon_key"].ToString(), "OCS2003"));
            }
            if (groupSer == 1)
            {
                groupSer = this.mInitialGroupSer + groupSer;
            }

            tpg.Title = groupSer.ToString() + Resources.TEXT8;
            Hashtable groupInfo = new Hashtable();

            groupInfo.Add("group_ser", groupSer);
            groupInfo.Add("group_name", tpg.Title);
            groupInfo.Add("emergency", "N");

            tpg.Tag = groupInfo;
            tpg.ImageList = this.ImageList;
            tpg.ImageIndex = 1;

            // 이벤트 정지 로직이 들어가야함.
            this.tabGroup.SelectionChanged -= new EventHandler(tabGroup_SelectionChanged);

            this.tabGroup.SuspendLayout();

            // 신규 페이지 작성
            this.tabGroup.TabPages.Add(tpg);

            this.tabGroup.SelectedTab = tpg;

            this.tabGroup.ResumeLayout();

            this.tabGroup.SelectionChanged += new EventHandler(tabGroup_SelectionChanged);

            this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
            //this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

            // 
            //if (aIsShowFindDlg)
            //    this.OpenScreen_OCS0208Q00();

        }

        private void MakeGroupTabInfo(string aIOGubun, string aFkInOutKey, string aInputGubun, string aInputTab)
        {
            if (this.grdOrder.RowCount <= 0)
            {
                // 저장된 그룹탭 정보가 없는경우
                // 신규 그룹을 생성한다.
                HandleBtnListButtonClick(FunctionType.Process);
            }
            else
            {
                this.tabGroup.SelectionChanged -= new EventHandler(tabGroup_SelectionChanged);

                try
                {
                    this.tabGroup.TabPages.Clear();
                }
                catch
                {
                    this.tabGroup.Refresh();
                }

                IHIS.X.Magic.Controls.TabPage ldTab;
                Hashtable groupInfo;
                string curGroupSer = "";
                bool isExist = false;

                foreach (DataRow dr in this.grdOrder.LayoutTable.Rows)
                {
                    // 의사인경우는 넘어온 input_gubun 과 일치하는 입력구분만 보여주고
                    // 의사 이외의 경우는 의사 오더 및 자신의 입력구분에 해당하는 오더를 전부 보여준다.
                    //if ((this.mInputGubun.Substring(0, 1) == "D" && dr["input_gubun"].ToString() == this.mInputGubun) ||
                    //     (this.mInputGubun.Substring(0, 1) != "D" && (dr["input_gubun"].ToString() == this.mInputGubun || dr["input_gubun"].ToString().Substring(0, 1) == "D")))
                    //{
                    if ((UserInfo.UserGubun == UserType.Doctor && dr["input_gubun"].ToString() == this.mInputGubun)
                       || (UserInfo.UserGubun != UserType.Doctor && UserInfo.Gwa != "CK" && (dr["input_gubun"].ToString() == this.mInputGubun || dr["input_gubun"].ToString().Substring(0, 1) == "D"))
                       || (UserInfo.Gwa == "CK" && (dr["input_gubun"].ToString().Substring(0, 1) == "D" || dr["input_gubun"].ToString() == UserInfo.Gwa))
                      )
                    {
                        if (curGroupSer != dr["group_ser"].ToString())
                        {
                            isExist = false;
                            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
                            {
                                if (dr["group_ser"].ToString() == ((Hashtable)tpg.Tag)["group_ser"].ToString())
                                {
                                    isExist = true;
                                    break;
                                }
                            }

                            if (isExist == false)
                            {
                                ldTab = new IHIS.X.Magic.Controls.TabPage();

                                ldTab.Title = dr["group_ser"].ToString() + Resources.TEXT8;
                                ldTab.ImageList = this.ImageList;
                                ldTab.ImageIndex = 1;

                                groupInfo = new Hashtable();
                                groupInfo.Add("group_ser", dr["group_ser"]);
                                groupInfo.Add("group_name", dr["group_ser"].ToString() + Resources.TEXT8);
                                //groupInfo.Add("bogyong_code", dr["bogyong_code"].ToString());
                                //groupInfo.Add("bogyong_name", dr["bogyong_name"].ToString());
                                groupInfo.Add("emergency", dr["emergency"].ToString());
                                //groupInfo.Add("nalsu", dr["nalsu"].ToString());
                                //groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());

                                ldTab.Tag = groupInfo;

                                this.tabGroup.TabPages.Add(ldTab);

                                curGroupSer = dr["group_ser"].ToString();
                            }
                        }
                    }
                }

                if (this.tabGroup.TabPages.Count > 0)
                {
                    this.tabGroup.SelectedTab = this.tabGroup.TabPages[0];

                    this.tabGroup.SelectionChanged += new EventHandler(tabGroup_SelectionChanged);

                    this.tabGroup_SelectionChanged(this, new EventArgs());
                    //this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);
                }
                else
                {
                    HandleBtnListButtonClick(FunctionType.Process);
                }
            }
        }

        #endregion

        #region 그룹탭 관련 적용 모듈

        private void ApplyGroupInfo(Hashtable aExistGroupInfo, string aType, string aValue1, string aValue2, string aValue3, string aValue4)
        {
            string bogyongCode = "";
            string bogyongName = "";
            string dv = "";
            string nalsu = "";
            string emergency = "";
            string wonyoi_order_yn = "";
            string donbogyn = "";
            string orderRemark = "";

            #region 기존 데이터 셋팅

            //if (aExistGroupInfo.Contains("bogyong_code"))
            //{
            //    bogyongCode = aExistGroupInfo["bogyong_code"].ToString();
            //}
            //if (aExistGroupInfo.Contains("bogyong_name"))
            //{
            //    bogyongName = aExistGroupInfo["bogyong_name"].ToString();
            //}
            //if (aExistGroupInfo.Contains("dv"))
            //{
            //    dv = aExistGroupInfo["dv"].ToString();
            //}
            //if (aExistGroupInfo.Contains("nalsu"))
            //{
            //    nalsu = aExistGroupInfo["nalsu"].ToString();
            //}
            if (aExistGroupInfo.Contains("emergency"))
            {
                emergency = aExistGroupInfo["emergency"].ToString();
            }
            //if (aExistGroupInfo.Contains("wonyoi_order_yn"))
            //{
            //    wonyoi_order_yn = aExistGroupInfo["wonyoi_order_yn"].ToString();
            //}
            //if (aExistGroupInfo.Contains("donbog_yn"))
            //{
            //    donbogyn = aExistGroupInfo["donbog_yn"].ToString();
            //}
            //if (aExistGroupInfo.Contains("order_remark"))
            //{
            //    orderRemark = aExistGroupInfo["order_remark"].ToString();
            //}

            #endregion

            #region 변경에 따른 데이터 셋팅

            switch (aType)
            {
                case "bogyong_code":

                    bogyongCode = aValue1;
                    bogyongName = aValue2;
                    dv = aValue3;
                    donbogyn = aValue4;

                    break;

                case "nalsu":

                    nalsu = aValue1;

                    break;

                case "emergency":

                    emergency = aValue1;

                    break;

                case "wonyoi_order_yn":

                    wonyoi_order_yn = aValue1;

                    break;
            }

            #endregion

            this.ApplyGroupInfo(bogyongCode, bogyongName, dv, nalsu, emergency, wonyoi_order_yn, donbogyn, orderRemark);
        }

        /// <summary>
        /// 그룹정보 셋팅
        /// </summary>
        /// <param name="aBogyongCode">복용코드</param>
        /// <param name="aBogyongName">복용코드명칭</param>
        /// <param name="aDv">DV</param>
        /// <param name="aNalsu">날수</param>
        /// <param name="aEmergency">긴급</param>
        /// <param name="aWonyoiOrderYN">원외처방여부</param>
        /// <param name="aDonbogYN">돈복YN</param>
        /// <param name="aOrderRemark">오더코맨트</param>
        private void ApplyGroupInfo(string aBogyongCode, string aBogyongName, string aDv
                                   , string aNalsu, string aEmergency, string aWonyoiOrderYN, string aDonbogYN, string aOrderRemark)
        {
            // 탭인포에 적용
            Hashtable tabInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            this.tabGroup.SelectedTab.Title = tabInfo["group_ser"].ToString() + Resources.TEXT8;

            if (aBogyongCode != "")
            {
                this.tabGroup.SelectedTab.Title += ":" + aBogyongName;
            }


            if (tabInfo.Contains("emergency"))
                tabInfo.Remove("emergency");
            tabInfo.Add("emergency", aEmergency);


            // 오더에 적용
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                // 같은 그룹의 오더들은 변경해준다.
                // 긴급
                if (this.grdOrder.GetItemString(i, "group_ser") == tabInfo["group_ser"].ToString())
                {
                    // 접수하기 전의 오더만 가능
                    if (this.grdOrder.GetRowState(i) == DataRowState.Added ||
                        (this.grdOrder.GetItemString(i, "ocs_flag") == "0" || this.grdOrder.GetItemString(i, "ocs_flag") == "1"))
                    {
                        // 긴급
                        if (this.grdOrder.GetItemString(i, "emergency") != aEmergency)
                        {
                            this.grdOrder.SetItemValue(i, "emergency", aEmergency);
                        }

                    }
                }
            }
        }

        private void ApplyGroupInfoToRow(Hashtable aExistGroupInfo, int aSetRowNumber)
        {
            string bogyongCode = "";
            string bogyongName = "";
            string dv = "";
            string nalsu = "";
            string emergency = "N";
            string wonyoi_order_yn = "N";
            string donbog_yn = "N";

            if (aExistGroupInfo.Contains("emergency"))
            {
                emergency = aExistGroupInfo["emergency"].ToString();
            }

            // 접수하기 전의 오더만 가능
            if (this.grdOrder.GetRowState(aSetRowNumber) == DataRowState.Added ||
                (this.grdOrder.GetItemString(aSetRowNumber, "ocs_flag") == "0" || this.grdOrder.GetItemString(aSetRowNumber, "ocs_flag") == "1"))
            {
                // 긴급
                if (this.grdOrder.GetItemString(aSetRowNumber, "emergency") != emergency)
                {
                    this.grdOrder.SetItemValue(aSetRowNumber, "emergency", emergency);
                }
            }
        }

        #endregion

        #region 현재 그룹 삭제

        private bool DeleteCurrentGroupTab(IHIS.X.Magic.Controls.TabPage aDestTabPage)
        {
            Hashtable groupInfo;

            if (MessageBox.Show(XMsg.GetMsg("M011"), XMsg.GetField("F002"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return false;

            if (aDestTabPage == null) return false;

            // 현재 오더 테이블에서 empty row 는 삭제 
            this.mOrderFunc.DeleteEmptyNewRow(this.grdOrder);

            // 현재 탭의 오더가 전부 삭제 가능한지 확인한다.
            bool isExistActingOrder = false;
            ArrayList deletRows = new ArrayList();
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.IsVisibleRow(i))
                {
                    if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                        this.mOrderMode == OrderVariables.OrderMode.CpSetOrder ||
                        this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, this.grdOrder, i, "", OrderVariables.CheckMode.RowDelete, OrderVariables.ErrorDisplayMode.MessageBox))
                    {
                        deletRows.Add(i);
                    }
                    else
                    {
                        isExistActingOrder = true;
                        break;
                    }
                }
            }

            if (isExistActingOrder == true)
            {
                return false; ;
            }

            for (int j = 0; j < deletRows.Count; j++)
            {
                this.grdOrder.DeleteRow(((int)deletRows[j]) - j);
            }

            if (this.tabGroup.SelectedTab == null)
            {
                return false;
            }

            groupInfo = aDestTabPage.Tag as Hashtable;

            // 오더가 있는경우와 없는경우로 나눈다.
            // 오더가 있는경우는 삭제 불가
            // 오더가 없는 경우만 삭제가 가능하다
            if (this.grdOrder.LayoutTable.Select("group_ser=" + groupInfo["group_ser"].ToString()).Length <= 0)
            {
                this.tabGroup.TabPages.Remove(aDestTabPage);

            }
            else
            {
                MessageBox.Show(XMsg.GetMsg("M012"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        #endregion

        #region 그룹 선택시의 설정들...

        private void DisplayOrderGridGroupInfo(Hashtable aGroupInfo)
        {
            // 오더그리드의 오더항목 visible setting 
            this.mOrderFunc.SetGridRowVisibleByGroupSer(this.grdOrder, aGroupInfo["group_ser"].ToString(), this.mInputGubun);

            // 그룹항목셋팅
            this.SetGroupControl(aGroupInfo);

            // 그룹항목에 대하여 프로텍트 여부 
            this.ProtectGroupControl(aGroupInfo["group_ser"].ToString());

            // dc 구분관련 보일것인가 말것인가..
            this.ShowDcGubun(this.grdOrder, (aGroupInfo["group_ser"].ToString()));

        }

        #endregion

        #endregion

        #region [ 상용오더 모듈 ]

        private void LoadOftenUseOrder(string aMembGubun, string aMemb, string aOrderGubun, string aWonnaeDrgYn, string aSearchWord)
        {
            //Fix bug MED-8921
            //this.grdSangyongOrder.Reset();
            ////insert by jc [検索条件追加] 2012/10/15
            //DataTable dtSangyongData = this.mOrderBiz.LoadOftenUsedInfo(aMembGubun, aMemb, aOrderGubun, aWonnaeDrgYn, TypeCheck.NVL(aSearchWord, "%").ToString(), this.cboSearchCondition.SelectedValue.ToString());

            //if (dtSangyongData != null && dtSangyongData.Rows.Count > 0)
            //{
            //    this.grdSangyongOrder.ImportRowRange(dtSangyongData, 0);
            //    this.grdSangyongOrder.ResetUpdate();
            //    this.grdSangyongOrder.DisplayData();
            //}
            this.grdSangyongOrder.Reset();
            this.grdSangyongOrder.QueryLayout(true);
        }
        // 「LIBへの移動」20120801 delete by jc
        //        private string GetMainGwaDoctorCode(string mMemb)
        //        {
        //            string cmd = @"SELECT DOCTOR
        //                              FROM BAS0270
        //                             WHERE HOSP_CODE = '" + EnvironInfo.HospCode + @"'
        //                               AND SABUN = :f_memb
        //                               AND TRUNC(SYSDATE) BETWEEN START_DATE AND NVL(END_DATE,TO_DATE('99981231', 'YYYYMMDD'))
        //                               AND NVL(MAIN_GWA_YN, 'N') = 'Y'
        //                               AND ROWNUM = 1
        //                             ORDER BY DOCTOR ";

        //            BindVarCollection binVar = new BindVarCollection();
        //            binVar.Add("f_memb", mMemb);

        //            object val = Service.ExecuteScalar(cmd, binVar);

        //            if (TypeCheck.IsNull(val))
        //            {
        //                return mMemb;
        //            }
        //            else
        //            {
        //                return val.ToString();
        //            }
        //        }

        private void MakeSangyongTab(string aMemb, string aInputTab)
        {
            DataTable sangyongTab = this.mOrderBiz.LoadOftenUsedTabInfo(aMemb, aInputTab);
            Hashtable tabInfo;

            this.tabSangyongOrder.SelectionChanged -= new EventHandler(tabSangyongOrder_SelectionChanged);

            try
            {
                this.tabSangyongOrder.TabPages.Clear();
            }
            catch
            {
                this.tabSangyongOrder.Refresh();
            }

            IHIS.X.Magic.Controls.TabPage tpg;

            for (int i = 0; i < sangyongTab.Rows.Count; i++)
            {
                tpg = new IHIS.X.Magic.Controls.TabPage();
                tpg.Title = sangyongTab.Rows[i]["order_gubun_name"].ToString();
                tpg.ImageList = this.ImageList;
                tpg.ImageIndex = 1;

                tabInfo = new Hashtable();
                tabInfo.Add("order_gubun", sangyongTab.Rows[i]["order_gubun"].ToString());
                tabInfo.Add("memb", sangyongTab.Rows[i]["memb"].ToString());
                tpg.Tag = tabInfo;

                this.tabSangyongOrder.TabPages.Add(tpg);
            }

            this.tabSangyongOrder.SelectionChanged += new EventHandler(tabSangyongOrder_SelectionChanged);

            this.tabSangyongOrder_SelectionChanged(this.tabSangyongOrder, new EventArgs());
        }

        void tabSangyongOrder_SelectionChanged(object sender, EventArgs e)
        {
            XTabControl control = sender as XTabControl;
            Hashtable tabInfo;
            string memb = "";

            this.grdSangyongOrder.Reset();

            foreach (IHIS.X.Magic.Controls.TabPage tpg in control.TabPages)
            {
                if (tpg == control.SelectedTab)
                {
                    tpg.ImageIndex = 0;

                    tabInfo = tpg.Tag as Hashtable;
                    memb = tabInfo["memb"].ToString();

                    string wonnaeDrgYn = this.cboQueryCon.GetDataValue();

                    this.LoadOftenUseOrder("1", memb, tabInfo["order_gubun"].ToString(), wonnaeDrgYn, this.txtSearch.GetDataValue());
                }
                else
                {
                    tpg.ImageIndex = 1;
                }
            }
        }

        #endregion

        #region [ 검체오더 모듈 ]

        //TreeNode currNode;

        private void MakeSpecimenOrder()
        {
            // 분류 데이터 로드 
            this.LoadSlipCode();

            TreeNode parentNode = new TreeNode();
            TreeNode childNode;

            string currentParent = "";

            foreach (DataRow dr in this.laySlipCodeTree.LayoutTable.Rows)
            {
                if (currentParent != dr["code"].ToString())
                {
                    //if (currentParent != "")
                    //{
                    //    this.tvwSlipCode.Nodes.Add(parentNode);
                    //}

                    parentNode = new TreeNode(dr["code_name"].ToString(), 5, 6);
                    parentNode.Tag = dr["code"].ToString();

                    childNode = new TreeNode(dr["code_name1"].ToString(), 1, 0);
                    childNode.Tag = dr["code1"].ToString();

                    parentNode.Nodes.Add(childNode);

                    currentParent = dr["code"].ToString();
                }
                else
                {
                    childNode = new TreeNode(dr["code_name1"].ToString(), 1, 0);
                    childNode.Tag = dr["code1"].ToString();

                    parentNode.Nodes.Add(childNode);
                }
            }
        }

        private void LoadSlipCode()
        {
            this.laySlipCodeTree.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.laySlipCodeTree.QueryLayout(true);
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

        #region [ 컨트롤 이벤트 ]

        #region [ 버튼 이벤트 ]

        #region 확장

        private void btnExtend_Click(object sender, EventArgs e)
        {
            if (this.mIsExtended)
            {
                this.pnlOrderInfo.Size = new Size(this.OrderNormalWidth, this.pnlOrderInfo.Size.Height);
                this.btnExtend.ImageIndex = 3;
                this.mIsExtended = false;
            }
            else
            {
                this.pnlOrderInfo.Size = new Size(this.OrderExtendWidth, this.pnlOrderInfo.Size.Height);
                this.btnExtend.ImageIndex = 4;
                this.mIsExtended = true;
            }
            this.grdOrder.Refresh();
        }

        #endregion

        private void btnExpandSearch_Click(object sender, EventArgs e)
        {
            if (this.mIsSearchExtended == false)
            {
                this.btnExpandSearch.ImageIndex = 3;
                this.pnlOrderInfo.Size = new Size(this.OrderMinWidth, this.pnlOrderInfo.Size.Height);

                this.grdSangyongOrder.AutoSizeColumn(1, this.SangYongHangmogMaxWidth);

                this.mIsSearchExtended = true;
            }
            else
            {
                this.btnExpandSearch.ImageIndex = 4;
                this.pnlOrderInfo.Size = new Size(this.OrderNormalWidth, this.pnlOrderInfo.Size.Height);

                this.grdSangyongOrder.AutoSizeColumn(1, this.SangYongHangmogNormalWidth);

                this.mIsSearchExtended = false;
            }
        }

        #region Do Set 오더 버튼

        private void btnSetOrder_Click(object sender, EventArgs e)
        {
            this.mCurrentRow = this.grdOrder.CurrentRowNumber;

            this.OpenScreen_OCS0301Q09();

            this.mCurrentRow = -1;
        }

        private void btnDoOrder_Click(object sender, EventArgs e)
        {
            this.OpenScreen_OCS1003Q09(false);
        }

        #endregion

        #region Copy Paste

        public void HandleBtnCopyClick(bool isCut)
        {
            string mbxMsg = "", mbxCap = "";
            string mCopy_gubun = "";
            mCopy_gubun = isCut ? "0" : "1";

            if (this.grdOrder.LayoutTable == null) return;

            bool isSelectedRow = false; // Select 여부 
            ArrayList selectedRow = new ArrayList();  // Selected Row's

            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.IsSelectedRow(i) && this.grdOrder.IsVisibleRow(i) && this.mOrderFunc.GetEmptyNewRow(this.grdOrder, i) == null) // Select 여부 체크
                {
                    selectedRow.Add(i);
                    isSelectedRow = true;
                }
            }

            if (!isSelectedRow)
            {
                mbxMsg = Resources.TEXT9;

                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                return;
            }

            if (this.MPbxCopy != null) this.MPbxCopy.Visible = false; // 디폴트 Copy할 데이타 선택여부 False

            // DataTable 비워 있는 경우 테이블 구조 복제
            if (this.mLayDtOrderBuffer == null) this.mLayDtOrderBuffer = this.grdOrder.LayoutTable.Clone();

            this.mLayDtOrderBuffer.Rows.Clear(); // Buffer DataTable Clear

            for (int i = 0; i < selectedRow.Count; i++)
            {
                this.mLayDtOrderBuffer.ImportRow(this.grdOrder.LayoutTable.Rows[(int)selectedRow[i]]);
            }

            // コピー後削除
            if (mCopy_gubun == "0")
            {
                for (int i = selectedRow.Count - 1; i >= 0; i--)
                    this.grdOrder.DeleteRow((int)selectedRow[i]);
            }

            //this.pbxCopy.Visible = true; // Copy할 데이타 선택여부 true
            this.grdOrder.UnSelectAll();

            if (mCopy_gubun == "0")
            {
                Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;
                this.DisplayOrderGridGroupInfo(groupInfo);
            }
        }

        public void HandleBtnPasteClick()
        {
            string mbxMsg = "", mbxCap = "";

            //this.AcceptData();

            if (this.mLayDtOrderBuffer == null || this.mLayDtOrderBuffer.Rows.Count == 0)
            {
                mbxMsg = Resources.TEXT10;

                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                return;
            }

            // DataTable 데이타를 처방Grid에 카피한다
            MultiLayout lay = this.mOrderFunc.CloneDataLayoutMIO(this.grdOrder);

            foreach (DataRow dRow in this.mLayDtOrderBuffer.Rows) lay.LayoutTable.ImportRow(dRow);

            this.grdOrder.SetFocusToItem(this.grdOrder.RowCount - 1, "hangmog_code", false);

            this.mCurrentRow = this.grdOrder.CurrentRowNumber;

            this.ApplyCopyOrderInfo(lay, HangmogInfo.ExecutiveMode.OrderCopy);

            //PostCallHelper.PostCall(new PostMethodObject(this.PostOrderInsert), -1);
            // 로직 구동후에 사용자 입력 편의를 위해서 맨 마지막 Row로 이동한다
            //this.grdOrder.SetFocusToItem(this.grdOrder.RowCount - 1, "hangmog_code");

            //this.grdOrder.UnSelectAll();
        }

        #endregion

        #region Mix 설정
        private void btnMix_Click(object sender, System.EventArgs e)
        {
            this.mHangmogInfo.SetMaxMixGroup(this.grdOrder);

            this.DiaplayMixGroup(this.grdOrder); // Mix Group 데이타 Image Display

            //this.mHangmogInfo.SetAlignMixGroup(grdOrder, settingStartRow, settingRow); // Mix Group 정렬

        }
        #endregion

        #region Mix 해제
        private void btnMixCancel_Click(object sender, System.EventArgs e)
        {
            this.mHangmogInfo.ReSetMixGroup(this.grdOrder);

            this.DiaplayMixGroup(this.grdOrder); // Mix Group 데이타 Image Display

            //this.mHangmogInfo.SetAlignMixGroup(grdOrder, settingStartRow, settingRow); // Mix Group 정렬
        }
        #endregion

        #region 신규 그룹으로 생성

        private void btnNewSelect_Click(object sender, EventArgs e)
        {
            //XGrid grid;
            //int applyRow = -1;
            //// 신규 그룹 추가
            //this.MakeNewOrderGroup(false);

            //// 현재 선택된 그리드의 항목코드 셋팅
            //if (rbnOftenOrder.Checked == true)
            //{
            //    grid = this.grdSangyongOrder as XGrid;
            //}
            //else
            //{
            //    grid = this.grdSearchOrder as XGrid;
            //}

            //if (grid.RowCount <= 0 ||
            //    grid.CurrentRowNumber < 0) return;

            //XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.grdOrder);

            //if (emptyNewCell != null)
            //    applyRow = emptyNewCell.Row;
            //else
            //{
            //    applyRow = this.grdOrder.InsertRow();
            //    this.GridInitValueSetting(grdOrder, applyRow);
            //}

            //this.ApplySangOrderInfo(grid.GetItemString(grid.CurrentRowNumber, "hangmog_code"), applyRow);

            //insert by jc [空きのグループがあったら空きのグループ情報をリターンして空きのグループにオーダ登録] 2012/04/10
            //if (this.IsExistEmptyGroup())
            //{
            //    IHIS.X.Magic.Controls.TabPage tpg = new IHIS.X.Magic.Controls.TabPage();
            //    tpg = this.mOrderFunc.GetExistEmptyGroup(this.grdOrder, this.tabGroup);
            //    this.tabGroup.TabPages.Remove(tpg);
            //}

            HandleBtnListButtonClick(FunctionType.Process);

            this.btnSelect.PerformClick();

        }

        #endregion

        #region 선택

        private void btnSelect_Click(object sender, EventArgs e)
        {
            XGrid grid = null;
            int rownumber = -1;

            if (this.tabGroup.SelectedTab == null)
            {
                HandleBtnListButtonClick(FunctionType.Process);
            }

            // 현재 선택된 그리드의 항목코드 셋팅
            if (rbnOftenOrder.Checked == true)
            {
                grid = this.grdSangyongOrder as XGrid;
                rownumber = this.grdOrder.CurrentRowNumber;
            }

            if (grid.RowCount <= 0 ||
                grid.CurrentRowNumber < 0) return;

            this.ApplySangOrderInfo(grid.GetItemString(grid.CurrentRowNumber, "hangmog_code"), this.grdOrder.CurrentRowNumber, HangmogInfo.ExecutiveMode.CodeInput, false);

            PostCallHelper.PostCall(new PostMethod(PostOrderInsert));
        }

        #endregion

        #region 의뢰서

        private void btnSpecificComment_Click(object sender, EventArgs e)
        {
            if (this.grdOrder.CurrentRowNumber < 0) return;

            this.OpenScreen_SpecificComment(this.grdOrder, this.grdOrder.CurrentRowNumber);
        }

        #endregion

        #endregion

        #region [ 오더 라디오 버튼 ]

        private void OrderRadio_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton control = sender as XRadioButton;
            //insert by jc
            string searchVoc = this.txtSearch.GetDataValue();
            string wonnaeDrgYn = this.cboQueryCon.GetDataValue();

            if (control.Checked)
            {
                control.BackColor = this.mSelectedBackColor;
                control.ForeColor = this.mSelectedForeColor;
                control.ImageIndex = 0;

                // 선택된것에 따른 화면 조정
                switch (control.Name)
                {
                    case "rbnOftenOrder":    // 상용오더

                        this.pnlSangyong.Visible = true;
                        PostCallHelper.PostCall(new PostMethod(PostRadioCheckedChanged));
                        this.tabSangyongOrder_SelectionChanged(this.tabSangyongOrder, new EventArgs());

                        break;
                }
            }
            else
            {
                control.BackColor = this.mUnSelectedBackColor;
                control.ForeColor = this.mUnSelectedForeColor;
                control.ImageIndex = 1;
            }
        }
        private void PostRadioCheckedChanged()
        {
            this.txtSearch.Focus();
        }
        #endregion

        #region XTab Control

        private void tabGroup_ClosePressed(object sender, EventArgs e)
        {
            IHIS.X.Magic.Controls.TabControl control = sender as IHIS.X.Magic.Controls.TabControl;
            // 탭 닫기 버튼을 누르는경우
            Hashtable groupInfo = control.SelectedTab.Tag as Hashtable;

            if (groupInfo["group_name"].ToString() == "New")
            {
                return;
            }

            // 오더가 있는경우와 없는경우로 나눈다.
            // 오더가 있는경우는 삭제 불가
            // 오더가 없는 경우만 삭제가 가능하다
            if (this.grdOrder.RowCount <= 0)
            {
                this.tabGroup.TabPages.Remove(control.SelectedTab);
            }
        }


        private void tabGroup_SelectionChanged(object sender, EventArgs e)
        {
            //insert by jc [選択されているgroupがない内はInput_gubunによるVisible設定をやり直す。]
            if (tabGroup.SelectedTab == null)
                mOrderFunc.SetGridRowVisibleByNoGroupSer(this.grdOrder, this.mInputGubun);

            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroup.TabPages)
            {
                if (this.tabGroup.SelectedTab == tpg)
                {
                    tpg.ImageIndex = 0;

                    this.mOrderFunc.DeleteEmptyNewRow(this.grdOrder);

                    this.DisplayOrderGridGroupInfo((Hashtable)tpg.Tag);

                    // 해당 그룹의 젤 마지막 로우로 포커스 이동
                    if (this.mCurrentColName == "") // DataWindowからのデータがない場合はフォーカスを一番下のＲＯＷするがあればＲＯＷ指定する。
                        PostCallHelper.PostCall(new PostMethodInt(this.PostTabSelection), this.mOrderFunc.GetLastRow(this.grdOrder.LayoutTable, ((Hashtable)tpg.Tag)["group_ser"].ToString()));
                }
                else
                {
                    tpg.ImageIndex = 1;
                }
            }
        }

        private void PostTabSelection(int aRowNumber)
        {
            this.grdOrder.SetFocusToItem(aRowNumber, "hangmog_code", false);
        }

        #endregion

        #region [ 버튼 리스트 ]

        public void HandleBtnListButtonClick(FunctionType type)
        {
            switch (type)
            {
                case FunctionType.Process:

                    #region 신규 오더 그룹 탭 추가

                    this.MakeNewOrderGroup(true);
                    this.txtSearch.Focus();

                    #endregion

                    break;

                case FunctionType.Insert:

                    #region 신규 오더 입력

                    if (this.tabGroup.TabPages.Count <= 0)
                        this.HandleBtnListButtonClick(FunctionType.Process);

                    //if (this.AcceptData() == false) return;

                    // Insert한 Row 중에 Not Null필드 미입력 Row Search 하여 해당 Row로 이동
                    XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.grdOrder);

                    if (emptyNewCell != null)
                    {
                        //TODO check IsSuccess
                        //e.IsSuccess = false;    

                        ((XEditGrid)this.grdOrder).SetFocusToItem(emptyNewCell.Row, emptyNewCell.CellName);
                        break;
                    }

                    this.OrderGridCreateNewRow(this.grdOrder.CurrentRowNumber);

                    if (MContainer != null) MContainer.AcceptData();

                    //this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
                    this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

                    // 포커스를 HANGMOG_CODE로
                    //this.grdOrder.SetFocusToItem(this.grdOrder.CurrentRowNumber, "hangmog_code", true);
                    PostCallHelper.PostCall(new PostMethodStr(PostCallAfterInsertRow), "hangmog_code");

                    #endregion

                    break;

                case FunctionType.Query:

                    if (MContainer != null) MContainer.AcceptData();

                    this.LoadOrderTable(this.mOrderMode, this.mMemb, this.mYaksokCode, this.mPkInOutKey, this.mInputGubun, INPUTTAB, "");

                    this.MakeGroupTabInfo(this.IOEGUBUN, this.mPkInOutKey, this.mInputGubun, INPUTTAB);

                    break;

                case FunctionType.Update:

                    #region 저장

                    if (MContainer != null && MContainer.AcceptData() == false)
                        return;

                    if (this.IsUpdateCheck() == false)
                        return;

                    /* -------------------------------------------------------------------------------------------------- */
                    //inser by jc [詳細画面での保存処理] START 2012/04/17
                    //[Merge : grdOrder -> laySaveLayout] 
                    if (this.mOrderMode == OrderVariables.OrderMode.InpOrder && this.mCallerScreenID != "OCS2003P01")
                    {
                        if (this.mOrderBiz.MergeToSaveLayout(this.grdOrder, this.laySaveLayout, this.layDeletedData) == false) return;

                        //[退院予約されてオーダ終了されたのかチェックしてオーダ終了されているなら保存できなくする。]
                        if (this.mOrderBiz.IsToiwonGojiYNandEndOrder(this.mPatientInfo.GetPatientInfo["naewon_key"].ToString()) == false)
                            return;

                        //
                        if (this.mOrderBiz.OrderValidationCheck(this.mDoctorLogin,
                                                                ref this.laySaveLayout,
                                                                this.mPatientInfo.GetPatientInfo["bunho"].ToString(),
                                                                this.mPatientInfo.GetPatientInfo["naewon_key"].ToString(),
                                                                mOrderDate,
                                                                this.mPatientInfo.GetPatientInfo["gwa"].ToString(),
                                                                this.mPatientInfo.GetPatientInfo["doctor"].ToString(),
                                                                this.mPatientInfo.GetPatientInfo["naewon_type"].ToString()) == false)
                        {
                            PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
                            return;
                        }

                        //[InterFace]
                        this.mInterface.MakeIFDataLayout("I", this.layDeletedData.LayoutTable, true, false, true);

                        this.mInterface.MakeIFDataLayout("I", this.laySaveLayout.LayoutTable, false, true, false);

                        this.mInterface.MakeIFDataLayout("I", this.laySaveLayout.LayoutTable, false, false, false);

                        // 트랜잭션 시작
                        try
                        {
                            // Cloud updated code START
                            OCS0103U10SaveLayoutArgs args = new OCS0103U10SaveLayoutArgs();
                            args.SaveLayoutItem = GetListDataForSaveLayout();
                            args.InterfaceInsertItem = GetListDataForInterfaceInsert();
                            args.Bunho = mBunho;
                            args.OrderDate = mOrderDate;

                            OCS0103U10SaveLayoutResult res = CloudService.Instance.Submit<OCS0103U10SaveLayoutResult, OCS0103U10SaveLayoutArgs>(args);

                            if (res == null || !res.Success)
                            {

                                this.mbxMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                                MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }

                            if (res.Result != "0")
                            {
                                this.mbxMsg = XMsg.GetMsg("M005") + " - " + res.Result;  // 저장에 실패하였습니다 + 에러메세지...

                                MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }

                            /*Service.BeginTransaction();

                            // 삭제시에는 삭제테이블의 데이터를 건드려 줘야 함.
                            for (int i = 0; i < this.layDeletedData.RowCount; i++)
                            {
                                this.layDeletedData.SetItemValue(i, "dummy", "mageshin");
                            }

                            if (this.layDeletedData.SaveLayout() == false)
                            {
                                Service.RollbackTransaction(); // 롤백

                                this.mbxMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                                MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }

                            if (this.mInterface.InsertDeletedDataToTempTable() == false)
                            {
                            }

                            if (this.laySaveLayout.SaveLayout() == false)
                            {
                                Service.RollbackTransaction();  // 롤백

                                this.mbxMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                                MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }
                            else
                            {
                                // 저장이 완료된 후에 NDAY 건을 처리하기 위하여 NDAY OCCUR YN 프로시져를 호출한다.
                                string procName = "PR_OCS_APPLY_NDAY_ORDER";
                                ArrayList inList = new ArrayList();
                                ArrayList outList = new ArrayList();

                                inList.Add(this.fbxBunho.GetDataValue());
                                inList.Add(mOrderDate);

                                if (Service.ExecuteProcedure(procName, inList, outList) == false)
                                {
                                    Service.RollbackTransaction();  // 롤백

                                    this.mbxMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                                    MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    return;
                                }
                                else
                                {
                                    if (outList[0].ToString() != "0")
                                    {
                                        Service.RollbackTransaction();  // 롤백

                                        this.mbxMsg = XMsg.GetMsg("M005") + " - " + outList[0].ToString();  // 저장에 실패하였습니다 + 에러메세지...

                                        MessageBox.Show(this.mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        return;
                                    }
                                }
                            }*/
                        }
                        catch
                        {
                            Service.RollbackTransaction();
                            XMessageBox.Show(Resources.SMS_UNSUCCESS, Resources.SMS_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        Service.CommitTransaction();  // 커밋

                        // 삭제는 삭제전 먼저 태워야 한다.
                        if (this.mInterface.SendData(true, false) == false)
                        {
                            // 메세지 처리.
                        }

                        // 업데이트 
                        if (this.mInterface.SendData(false, true) == false)
                        {
                        }

                        if (this.mInterface.SendData(false, false) == false)
                        {
                            // 메세지 처리.
                        }

                        this.mOrderBiz.PrintCPL(this.laySaveLayout, this.mPatientInfo.GetPatientInfo["bunho"].ToString(), mOrderDate, this.IOEGUBUN, this.mPatientInfo.GetPatientInfo["gwa"].ToString(), this.mPatientInfo.GetPatientInfo["doctor"].ToString());
                    }
                    //inser by jc [詳細画面での保存処理] END 2012/04/17
                    /* -------------------------------------------------------------------------------------------------- */

                    this.InvokeReturnSendReturnDataTable();
                    XMessageBox.Show(Resources.SMS_SUCCESS, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MContainer != null && MContainer.Name != "OCS2015U00") MContainer.Close();

                    #endregion

                    break;

                case FunctionType.Delete:

                    if (MContainer != null) MContainer.AcceptData();

                    ArrayList deleteRow = new ArrayList();
                    ArrayList parentKeys = new ArrayList();

                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        if (this.grdOrder.IsSelectedRow(i) && this.grdOrder.IsVisibleRow(i))
                        {
                            deleteRow.Add(i);
                            if (this.grdOrder.GetItemString(i, "child_yn") == "N" && this.grdOrder.GetItemString(i, "pkocskey") != "" &&
                                parentKeys.Contains(this.grdOrder.GetItemString(i, "pkocskey")) == false)
                            {
                                parentKeys.Add(this.grdOrder.GetItemString(i, "pkocskey"));
                            }
                        }
                    }

                    if (deleteRow.Count > 0)
                    {
                        for (int j = 0; j < deleteRow.Count; j++)
                        {
                            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder ||
                                //modify by jc
                                this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, this.grdOrder, (int)deleteRow[j] - j, "", OrderVariables.CheckMode.RowDelete, OrderVariables.ErrorDisplayMode.MessageBox))
                            //this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, this.grdOrder, (int)deleteRow[j], "", OrderVariables.CheckMode.RowDelete, OrderVariables.ErrorDisplayMode.MessageBox))
                            {
                                this.grdOrder.DeleteRow((int)deleteRow[j] - j);
                            }
                        }

                    }
                    else
                    {
                        if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                            this.mOrderMode == OrderVariables.OrderMode.CpSetOrder ||
                            this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, this.grdOrder, this.grdOrder.CurrentRowNumber, "", OrderVariables.CheckMode.RowDelete, OrderVariables.ErrorDisplayMode.MessageBox))
                        {
                            if (this.grdOrder.IsVisibleRow(this.grdOrder.CurrentRowNumber))
                            {
                                if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "child_yn") == "N" && this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocskey") != "" &&
                                    parentKeys.Contains(this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocskey")) == false)
                                {
                                    parentKeys.Add(this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocskey"));
                                }

                                this.grdOrder.DeleteRow(this.grdOrder.CurrentRowNumber);
                            }
                        }
                    }

                    if (parentKeys.Count > 0)
                    {
                        this.mOrderFunc.ReSettingParentKeyAfterDelete(this.grdOrder, parentKeys);
                        PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert)); ;
                    }

                    this.grdOrder.UnSelectAll();

                    //this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
                    this.DisplayOrderGridGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag);

                    PostCallHelper.PostCall(new PostMethodInt(PostCallAfterDeleteRow), this.mOrderFunc.GetLastRow(this.grdOrder.LayoutTable, ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString()));

                    break;

                case FunctionType.Cancel:

                    #region 현재 그룹 탭 삭제

                    this.DeleteCurrentGroupTab(this.tabGroup.SelectedTab);

                    #endregion

                    break;

                case FunctionType.Close:

                    if (MContainer != null) MContainer.AcceptData();
                    if (this.mOrderBiz.IsCloseOrderScreen(this.grdOrder))
                        if (MContainer != null) MContainer.Close();
                        else
                            return;
                    break;
            }
        }
        //-> LIB
        //private bool MergeToSaveLayout()
        //{
        //    this.laySaveLayout.Reset();

        //    // 病理検査
        //    foreach (DataRow dr in this.grdOrder.LayoutTable.Rows)
        //    {
        //        this.laySaveLayout.LayoutTable.ImportRow(dr);
        //    }

        //    if (this.grdOrder.DeletedRowCount > 0 && this.grdOrder.DeletedRowTable != null)
        //    {
        //        // 삭제된 로우를 셋팅한다.
        //        for (int i = 0; i < this.grdOrder.DeletedRowTable.Rows.Count; i++)
        //        {
        //            if (layDeletedData.LayoutTable.Select("pkocskey=" + this.grdOrder.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

        //            this.layDeletedData.LayoutTable.ImportRow(this.grdOrder.DeletedRowTable.Rows[i]);
        //            this.layDeletedData.SetItemValue(i, "dummy", "Y");
        //        }
        //    }
        //    return true;
        //}
        private void PostCallAfterInsertRow(string aFocusColumn)
        {
            this.grdOrder.Focus();
            this.grdOrder.SetFocusToItem(this.grdOrder.CurrentRowNumber, aFocusColumn, true);
        }

        private void PostCallAfterDeleteRow(int aRowNumber)
        {
            this.grdOrder.Focus();
            this.grdOrder.SetFocusToItem(aRowNumber, "hangmog_code", false);
        }

        #endregion

        #region [ 파인드 박스 이벤트 ]

        #endregion

        #region [ 그리드 이벤트 ]

        #region [ 오더 그리드 ]

        private void grdOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            string dv = "";

            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                if (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable &&
                    (grd.GetRowState(e.RowNumber) == DataRowState.Unchanged || grd.GetRowState(e.RowNumber) == DataRowState.Modified) ||
                    (((XEditGridCell)grd.CellInfos[e.ColName]).IsReadOnly) ||
                    (this.mInputControl.IsProtectedColumn(grd.GetItemValue(e.RowNumber, "input_control").ToString(), e.ColName)) ||
                    !this.mHangmogInfo.IsFieldChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName))
                {
                    e.BackColor = OrderVariables.DisplayFieldColor.Color;
                }
            }
            else
            {
                if (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable &&
                    (grd.GetRowState(e.RowNumber) == DataRowState.Unchanged || grd.GetRowState(e.RowNumber) == DataRowState.Modified) ||
                    (((XEditGridCell)grd.CellInfos[e.ColName]).IsReadOnly) ||
                    (this.mInputControl.IsProtectedColumn(grd.GetItemValue(e.RowNumber, "input_control").ToString(), e.ColName)) ||
                    !this.mHangmogInfo.IsFieldChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName) ||
                    !this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName, OrderVariables.CheckMode.Protected, OrderVariables.ErrorDisplayMode.NoDisplay))
                {
                    e.BackColor = OrderVariables.DisplayFieldColor.Color;
                }
            }

            this.mHangmogInfo.ColumnColorForOrderState(IOEGUBUN, grd, e); // 처방상태에 따른 색상 처리

            dv = grd.GetItemString(e.RowNumber, "dv");

            // 공통 이외의 DV 처리
            switch (e.ColName)
            {
                case "dv_1":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y")
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    break;
                case "dv_2":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse("dv") < 2)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                        }
                    }
                    break;
                case "dv_3":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse("dv") < 3)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                        }
                    }
                    break;
                case "dv_4":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.BackColor = OrderVariables.DisplayFieldColor.Color;
                    }
                    else
                    {
                        if (int.Parse("dv") < 4)
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                        }
                    }
                    break;

            }

        }

        private void grdOrder_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            // InputControl별 필드 입력불가 제어
            // 처방 Field DataChange 가능여부 체크 입력불가 제어
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                if (this.mInputControl.IsProtectedColumn(grd.GetItemValue(e.RowNumber, "input_control").ToString(), e.ColName) ||
                    !this.mHangmogInfo.IsFieldChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName))
                    e.Protect = true;
            }
            else
            {
                if (this.mInputControl.IsProtectedColumn(grd.GetItemValue(e.RowNumber, "input_control").ToString(), e.ColName) ||
                    !this.mHangmogInfo.IsFieldChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName) ||
                    !this.mHangmogInfo.IsOrderDataChagnedEnabled(IOEGUBUN, grd, e.RowNumber, e.ColName, OrderVariables.CheckMode.Protected, OrderVariables.ErrorDisplayMode.NoDisplay) ||
                    //insert by jc [CellのWidthが０である場合はProtectを掛けてカーソルが行っても反応しないようにするため] 2012/02/20
                    this.grdOrder[e.RowNumber, e.ColName].AbsoluteRectangle.Width == 0)
                    e.Protect = true;
            }

            string dv = grd.GetItemString(e.RowNumber, "dv");

            // 공통 이외의 DV 처리
            switch (e.ColName)
            {
                case "dv_1":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y")
                        e.Protect = true;
                    break;
                case "dv_2":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        if (int.Parse("dv") < 2)
                        {
                            e.Protect = true;
                        }
                    }
                    break;
                case "dv_3":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        if (int.Parse("dv") < 3)
                        {
                            e.Protect = true;
                        }
                    }
                    break;
                case "dv_4":
                    if (grd.GetItemString(e.RowNumber, "donbog_yn") == "Y" || TypeCheck.IsInt("dv") == false)
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        if (int.Parse("dv") < 4)
                        {
                            e.Protect = true;
                        }
                    }
                    break;

            }
        }

        private void grdOrder_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            switch (e.ColName)
            {
                case "hangmog_code":     // 항목코드 

                    e.Cancel = true; // 별도의 화면 오픈 

                    if (mOrderDate == "")
                    {
                        return;
                    }

                    this.OpenScreen_OCS0103Q00(grid.GetItemString(e.RowNumber, e.ColName), true); // 화면오픈

                    break;

                case "bogyong_code":  // 부위코드

                    e.Cancel = false;

                    if (grid.GetItemString(e.RowNumber, "hangmog_code") != "" && grid.GetItemString(e.RowNumber, "input_control") == "A")
                    {
                        this.OpenScreen_CHT0117Q00(grid.GetItemString(e.RowNumber, "order_gubun_bas"));
                    }

                    break;

                case "specimen_code":

                    e.Cancel = false;

                    if (grid.GetItemString(e.RowNumber, "hangmog_code") != "")
                    {
                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("specimen_code_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }

                    break;

                case "ord_danui_name":  // 오더단위

                    if (grid.GetItemString(e.RowNumber, "hangmog_code") != "")
                    {
                        // ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker(e.ColName, grid.GetItemString(e.RowNumber, "hangmog_code"));

                        // https://sofiamedix.atlassian.net/browse/MED-9500
                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                            LoadFindWorker(e.ColName, grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }

                    break;

                case "jundal_part": // 전달파트
                    // 외래 전달 파트 
                    if (this.IOEGUBUN == "O")
                    {
                        // ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                            LoadFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }
                    // 입원 전달파트 
                    else
                    {
                        // ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                        ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                            LoadFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));
                    }
                    break;

                case "jundal_part_out": // 전달파트 외래

                    // ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                        LoadFindWorker("jundal_part_out_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

                case "jundal_part_inp": // 전달파트 입원

                    // ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    ((XFindBox)((XEditGridCell)grid.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                        LoadFindWorker("jundal_part_inp_hangmog", grid.GetItemString(e.RowNumber, "hangmog_code"));

                    break;

            }
        }

        private XFindWorker LoadFindWorker(string colName, string argu1)
        {
            XFindWorker fdwTemp = new XFindWorker();
            fdwTemp.AutoQuery = true;
            fdwTemp.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            fdwTemp.ParamList = new List<string>(new String[] { "colName", "argu1" });
            fdwTemp.SetBindVarValue("colName", colName);
            fdwTemp.SetBindVarValue("argu1", argu1);
            fdwTemp.ExecuteQuery = LoadDataFdwTemp;

            switch (colName)
            {
                case "ord_danui_name":
                    fdwTemp.ColInfos.Add("ord_danui_name", Resources.XMsg_000029, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwTemp.ColInfos.Add("ord_danui", Resources.XMsg_000030, FindColType.String, 100, 0, true, FilterType.Yes);
                    break;
                case "jundal_part_out_hangmog":
                    fdwTemp.ColInfos.Add("gwa", Resources.XMsg_000031, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwTemp.ColInfos.Add("gwa_name", Resources.XMsg_000032, FindColType.String, 300, 0, true, FilterType.No);
                    break;
                case "jundal_part_inp_hangmog":
                    fdwTemp.ColInfos.Add("gwa", Resources.XMsg_000031, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwTemp.ColInfos.Add("gwa_name", Resources.XMsg_000032, FindColType.String, 300, 0, true, FilterType.No);
                    break;
                default:
                    break;
            }

            return fdwTemp;
        }

        private IList<object[]> LoadDataFdwTemp(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            GetFindWorkerArgs args = new GetFindWorkerArgs();
            GetFindWorkerRequestInfo info = new GetFindWorkerRequestInfo(varlist["colName"].VarValue, varlist["argu1"].VarValue, "", "");
            args.Info1 = info;
            GetFindWorkerResult result = CloudService.Instance.Submit<GetFindWorkerResult, GetFindWorkerArgs>(args);
            if (result != null && result.Info1 != null && result.Info1.Count > 0)
            {
                switch (varlist["colName"].VarValue)
                {
                    case "ord_danui_name":
                        foreach (GetFindWorkerResponseInfo infoC1 in result.Info1)
                        {
                            dataList.Add(new object[]
                            {
                                infoC1.Name,
                                infoC1.Code
                            });
                        }
                        break;

                    case "jundal_part_out_hangmog":
                        foreach (GetFindWorkerResponseInfo infoC1 in result.Info1)
                        {
                            dataList.Add(new object[]
                            {
                                infoC1.Code,
                                infoC1.Name
                            });
                        }
                        break;

                    case "jundal_part_inp_hangmog":
                        foreach (GetFindWorkerResponseInfo infoC1 in result.Info1)
                        {
                            dataList.Add(new object[]
                            {
                                infoC1.Code,
                                infoC1.Name
                            });
                        }
                        break;
                }
            }
            return dataList;
        }

        private void grdOrder_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            string hangmog_code = grid.GetItemString(e.RowNumber, "hangmog_code").Trim();  // 항목코드

            // 이전값을 버퍼로 셋팅
            object previousValue = grid.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer);

            //// 오더가 아닌경우 오더코드가 입력되지 않았다면 메세지 처리
            //if (e.ColName != "hangmog_code" && grid.GetItemString(e.RowNumber, "hangmog_code") == "")
            //{
            //    MessageBox.Show(XMsg.GetMsg("M004"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue); // 이전값으로 되돌린다.
            //}

            ////////////////////// 필드 Validation 및 Value Setting 공통모듈 Call ///////////////////
            // 항목을 제외한 다른 컬럼들의 일반적 validation 은 이안에서 기술한다.                 //
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
            {
                if (!this.mHangmogInfo.ColumnChanged(IOEGUBUN, grid, e)) return;
            }
            else
            {
                if (!this.mHangmogInfo.ColumnChanged(IOEGUBUN, this.mPatientInfo.GetPatientInfo["bunho"].ToString(), this.mPatientInfo.GetPatientInfo["naewon_date"].ToString(), grid, e)) return;
            }
            /////////////////////////////////////////////////////////////////////////////////////////

            switch (e.ColName)
            {
                case "hangmog_code":    // 오더코드 

                    #region 오더코드

                    hangmog_code = e.ChangeValue.ToString().TrimEnd();

                    if (TypeCheck.IsNull(hangmog_code))
                    {
                        //this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue);   // 이전값으로 되돌린다.
                        return;
                    }

                    this.mHangmogInfo.Parameter.Clear();
                    this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
                    this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
                    this.mHangmogInfo.Parameter.InputGubun = this.mInputGubun;
                    this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
                    this.mHangmogInfo.Parameter.IOEGubun = this.IOEGUBUN;
                    this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;
                    this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = "N";

                    if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                        this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
                    {
                        this.mHangmogInfo.Parameter.Bunho = this.mPatientInfo.GetPatientInfo["bunho"].ToString();
                        this.mHangmogInfo.Parameter.NaewonKey = this.mPatientInfo.GetPatientInfo["naewon_key"].ToString();
                        this.mHangmogInfo.Parameter.Gubun = this.mPatientInfo.GetPatientInfo["gubun"].ToString();
                        this.mHangmogInfo.Parameter.Birth_Date = this.mPatientInfo.GetPatientInfo["birth"].ToString();
                        this.mHangmogInfo.Parameter.Gwa = this.mPatientInfo.GetPatientInfo["gwa"].ToString();
                        this.mHangmogInfo.Parameter.ApproveDoctor = this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString();
                    }

                    #region 그룹정보 및 항목코드 셋팅

                    MultiLayout loadExtraInfo = new MultiLayout();

                    loadExtraInfo.LayoutItems.Add("hangmog_code", DataType.String);
                    loadExtraInfo.LayoutItems.Add("group_ser", DataType.String);
                    loadExtraInfo.LayoutItems.Add("emergency", DataType.String);
                    loadExtraInfo.InitializeLayoutTable();

                    Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

                    loadExtraInfo.InsertRow(-1);
                    // 항목정보
                    loadExtraInfo.SetItemValue(0, "hangmog_code", e.ChangeValue.ToString());
                    // 그룹정보 로드
                    // 그룹시리얼
                    if (groupInfo.Contains("group_ser"))
                    {
                        loadExtraInfo.SetItemValue(0, "group_ser", groupInfo["group_ser"].ToString());
                    }
                    // Emergency
                    if (groupInfo.Contains("emergency"))
                    {
                        loadExtraInfo.SetItemValue(0, "emergency", groupInfo["emergency"].ToString());
                    }


                    #endregion

                    if (this.mHangmogInfo.LoadHangmogInfo(HangmogInfo.ExecutiveMode.CodeInput, loadExtraInfo) == false)
                    {
                        this.mOrderFunc.UndoPreviousValue(grid, e.RowNumber, e.ColName, previousValue);
                        this.OpenScreen_OCS0103Q00(e.ChangeValue.ToString(), true);
                        return;
                    }

                    int currentRow = this.grdOrder.CurrentRowNumber;

                    this.ApplyDefaultOrderInfo(this.mHangmogInfo.GetHangmogInfo, this.grdOrder.CurrentRowNumber, false);



                    //this.SetImageToGrid(grdOrder);
                    //this.DiaplayMixGroup(grid);

                    PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                    #endregion

                    break;

                case "ord_danui":

                    string code = "";
                    string codename = "";

                    if (e.ChangeValue.ToString() == "")
                    {
                        this.mOrderBiz.GetDefaultOrdDanui(hangmog_code, ref code, ref codename);

                    }
                    else
                    {
                    }

                    break;

                case "jundal_part":  // 전달 파트 
                case "jundal_part_out":
                case "jundal_part_inp":

                    // 전달 파트에 대한 벨리데이션은 라이브러리에서ㅓ 행하여 지고 여기서는
                    // 전달 파트 변경시 jundal_table과 무브파트를 변경해야 한다.
                    string jundalTable = "";
                    string movePart = "";

                    if (e.ColName == "jundal_part")
                    {
                        //insert by jc [HOMの場合は希望日を入れられない。] 
                        if (grid.GetItemString(e.RowNumber, "jundal_part") == "HOM")
                        {
                            grid.SetItemValue(e.RowNumber, "hope_date", "");
                            grid.SetItemValue(e.RowNumber, "hope_time", "");
                        }
                        //if (this.mOrderBiz.GetJundaTable(this.IOEGUBUN, hangmog_code, grid.GetItemString(e.RowNumber, "order_date"), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        if (this.mOrderBiz.GetJundaTable(this.IOEGUBUN, hangmog_code, TypeCheck.NVL(grid.GetItemString(e.RowNumber, "order_date"), mOrderDate).ToString(), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        {
                            grid.SetItemValue(e.RowNumber, "jundal_table", jundalTable);
                            grid.SetItemValue(e.RowNumber, "move_part", movePart);
                        }
                    }
                    else if (e.ColName == "jundal_part_out")
                    {
                        //if (this.mOrderBiz.GetJundaTable("O", hangmog_code, grid.GetItemString(e.RowNumber, "order_date"), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        if (this.mOrderBiz.GetJundaTable("O", hangmog_code, TypeCheck.NVL(grid.GetItemString(e.RowNumber, "order_date"), mOrderDate).ToString(), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        {
                            grid.SetItemValue(e.RowNumber, "jundal_table_out", jundalTable);
                            grid.SetItemValue(e.RowNumber, "move_part_out", movePart);
                        }
                    }
                    else if (e.ColName == "jundal_part_inp")
                    {
                        //if (this.mOrderBiz.GetJundaTable("I", hangmog_code, grid.GetItemString(e.RowNumber, "order_date"), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        if (this.mOrderBiz.GetJundaTable("I", hangmog_code, TypeCheck.NVL(grid.GetItemString(e.RowNumber, "order_date"), mOrderDate).ToString(), e.ChangeValue.ToString(), ref jundalTable, ref movePart) == true)
                        {
                            grid.SetItemValue(e.RowNumber, "jundal_table_inp", jundalTable);
                            grid.SetItemValue(e.RowNumber, "move_part_inp", movePart);
                        }
                    }

                    break;
            }
        }



        private void grdOrder_Click(object sender, EventArgs e)
        {
            // 포커스가 왔을때 아무것도 입력이 되어 있지 않다면 
            // 신규로우를 하나 자동으로 생성한다.
            if (this.tabGroup.SelectedTab != null)
            {
                DataRow[] dr = this.grdOrder.LayoutTable.Select("group_ser=" + ((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"].ToString());
                if (dr.Length <= 0)
                {
                    HandleBtnListButtonClick(FunctionType.Insert);
                }
            }
        }

        private void grdOrder_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int curRowIndex = -1;
                int parentRowIndex = -1;
                XEditGrid grd = sender as XEditGrid;

                curRowIndex = grd.GetHitRowNumber(e.Y);


                if (e.Button == MouseButtons.Left && e.Clicks == 1)
                {
                    if (curRowIndex < 0) return;

                    // 재료만 이동이 가능함.
                    if (grd.GetItemString(curRowIndex, "if_input_control") != "P")
                    {
                        this.mDragX = e.X;
                        this.mDragY = e.Y;
                        ////Drag시 show info정보
                        //string dragInfo = "[" + grd.GetItemString(curRowIndex, "hangmog_code") + "]" + grd.GetItemString(curRowIndex, "hangmog_name");
                        //DragHelper.CreateDragCursor(grd, dragInfo, this.Font);
                        //grd.DoDragDrop("OrderGrid" + "|" + curRowIndex.ToString(), DragDropEffects.Move);

                        this.mDragRowIndex = curRowIndex;
                        this.mIsDrag = true;
                    }
                }

                if (e.Button == MouseButtons.Right && e.Clicks == 1)
                {
                    this.grdOrder.SetFocusToItem(curRowIndex, "hangmog_name");
                    popupOrderMenu.TrackPopup(grd.PointToScreen(new Point(e.X, e.Y)));
                }

                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    switch (grd.CurrentColName)
                    {
                        case "hangmog_name":
                            // 시간 , 분 처리
                            DataRow dRow = this.mOrderFunc.CopyDataRow(grd.LayoutTable.Rows[grd.CurrentRowNumber]);

                            if (!TypeCheck.IsNull(grd.GetItemString(curRowIndex, "hangmog_code")) && this.mHangmogInfo.GetInputTime(this, dRow))
                            {
                                grd.SetItemValue(curRowIndex, "suryang", dRow["suryang"]);
                                grd.SetItemValue(curRowIndex, "nalsu", dRow["nalsu"]);
                            }

                            break;
                    }
                }
            }
            catch (Exception)
            {
                //todo: check exception
            }
        }

        private void grdOrder_MouseMove(object sender, MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            int offset = Math.Abs(this.mDragY - e.Y);

            if (this.mIsDrag && offset > 5)
            {
                //Drag시 show info정보
                string dragInfo = "[" + grd.GetItemString(this.mDragRowIndex, "hangmog_code") + "]" + grd.GetItemString(this.mDragRowIndex, "hangmog_name");
                DragHelper.CreateDragCursor(grd, dragInfo, this.Font);
                grd.DoDragDrop("OrderGrid" + "|" + this.mDragRowIndex.ToString(), DragDropEffects.Move);
            }
        }

        private void grdOrder_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.mIsDrag && e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                this.mDragX = 0;
                this.mDragY = 0;
                this.mDragRowIndex = -1;
                this.mIsDrag = false;
            }
        }

        #region 드레그엔 드랍 관련

        private void grdOrder_DragDrop(object sender, DragEventArgs e)
        {
            string data = e.Data.GetData("System.String").ToString();
            string gubun = data.Split('|')[0];
            string sourceRow = data.Split('|')[1];
            string hangmogCode = "";

            Point clientPoint = grdOrder.PointToClient(new Point(e.X, e.Y));
            int rowNumber = grdOrder.GetHitRowNumber(clientPoint.Y);

            if (TypeCheck.IsInt(sourceRow) == false)
            {
                return;
            }

            if (this.tabGroup.SelectedTab == null)
            {
                HandleBtnListButtonClick(FunctionType.Process);
            }

            switch (gubun)
            {
                case "SlipHangmog":
                    
                    this.ApplySangOrderInfo(hangmogCode, rowNumber, HangmogInfo.ExecutiveMode.CodeInput, false);

                    PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                    break;

                case "Search":
                    
                    this.ApplySangOrderInfo(hangmogCode, rowNumber, HangmogInfo.ExecutiveMode.CodeInput, false);

                    PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                    break;

                case "SangYong":

                    hangmogCode = this.grdSangyongOrder.GetItemString(int.Parse(sourceRow), "hangmog_code");

                    this.ApplySangOrderInfo(hangmogCode, rowNumber, HangmogInfo.ExecutiveMode.CodeInput, false);

                    PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                    break;

                case "OrderGrid":

                    this.MoveOrderRow(grdOrder, int.Parse(sourceRow), rowNumber);

                    PostCallHelper.PostCall(new PostMethod(PostOrderInsert));

                    break;
            }

            this.mIsDrag = false;
            this.mDragX = 0;
            this.mDragY = 0;
            this.mDragRowIndex = -1;

        }

        private void grdOrder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;  // Move 표시	
        }

        private void grdOrder_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        #endregion

        private void grdOrder_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.OrderRowMovingChangedDisplay((XEditGrid)sender, e.CurrentRow);
        }

        private void SetOrderImage(XEditGrid aGrid)
        {
            // 의사가 입력하는 경우는 스킵
            if (this.mInputGubun.Substring(0, 1) == "D") return;

            for (int i = 0; i < aGrid.RowCount; i++)
            {
                // 의사 오더인경우
                if (aGrid.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                {
                    aGrid[i + aGrid.HeaderHeights.Count, 0].Image = this.ImageList.Images[10];
                    aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText = Resources.TEXT11 + aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText;
                }
            }
        }

        private void grdOrder_GridReservedMemoButtonClick(object sender, GridReservedMemoButtonClickEventArgs e)
        {
            if (sender == null) return;

            XEditGrid grd = sender as XEditGrid;

            CommonItemCollection loadParams;

            switch (e.ColName)
            {
                case "order_remark":

                    loadParams = new CommonItemCollection();
                    loadParams.Add("category_gubun", OrderVariables.CATEGORY_COMMENT); // 처방Comment

                    grd.SetReservedMemoControlLoadParam(e.ColName, loadParams);

                    break;
            }
        }

        #endregion

        #region [ 상용오더 그리드 ]

        private void grdSangyongOrder_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            int rowNumber = -1;
            int applyRow = -1;

            rowNumber = grid.GetHitRowNumber(e.Y);

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (rowNumber < 0) return;

                this.btnSelect.PerformClick();

            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                //Drag시 show info정보
                string dragInfo = "[" + grid.GetItemString(rowNumber, "hangmog_code") + "]" + grid.GetItemString(rowNumber, "hangmog_name");
                DragHelper.CreateDragCursor(grid, dragInfo, this.Font);
                grid.DoDragDrop("SangYong" + "|" + rowNumber.ToString(), DragDropEffects.Move);
            }
            else if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                if (rowNumber < 0) return;

                if (this.grdSangyongOrder.CurrentRowNumber != rowNumber)
                {
                    this.grdSangyongOrder.SetFocusToItem(rowNumber, 0);
                }

                this.popupOftenUsedMenu.TrackPopup(grid.PointToScreen(new Point(e.X, e.Y)));
            }
        }

        private void grdSangyongOrder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void grdSangyongOrder_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void grdSangyongOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            this.mColumnControl.ColumnColorForCodeQueryGrid(IOEGUBUN, grid, e);
        }

        #endregion

        #region [ 검체오더 그리드 ]

        private void grdSlipHangmog_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            int rowNumber = -1;

            rowNumber = grid.GetHitRowNumber(e.Y);

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (rowNumber < 0) return;

                this.btnSelect.PerformClick();

            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                //Drag시 show info정보
                string dragInfo = "[" + grid.GetItemString(rowNumber, "hangmog_code") + "]" + grid.GetItemString(rowNumber, "hangmog_name");
                DragHelper.CreateDragCursor(grid, dragInfo, this.Font);
                grid.DoDragDrop("SlipHangmog" + "|" + rowNumber.ToString(), DragDropEffects.Move);
            }
        }

        private void grdSlipHangmog_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void grdSlipHangmog_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void grdSlipHangmog_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            this.mColumnControl.ColumnColorForCodeQueryGrid(IOEGUBUN, grid, e);
        }

        #endregion

        #region [ 검색 그리드 ]

        private void grdSearchOrder_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            int rowNumber = -1;

            rowNumber = grid.GetHitRowNumber(e.Y);

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (rowNumber < 0) return;

                this.btnSelect.PerformClick();

            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                //Drag시 show info정보
                string dragInfo = "[" + grid.GetItemString(rowNumber, "hangmog_code") + "]" + grid.GetItemString(rowNumber, "hangmog_name");
                DragHelper.CreateDragCursor(grid, dragInfo, this.Font);
                grid.DoDragDrop("Search" + "|" + rowNumber.ToString(), DragDropEffects.Move);
            }
        }

        private void grdSearchOrder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void grdSearchOrder_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void grdSearchOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            this.mColumnControl.ColumnColorForCodeQueryGrid(IOEGUBUN, grid, e);
        }

        #endregion

        #endregion

        #region [ 체크박스 이벤트 ]

        private void cbxEmergency_CheckedChanged(object sender, EventArgs e)
        {
            if (this.tabGroup.SelectedTab == null) return;

            if (this.mOrderBiz.IsAbleEmergencyCheck(this.cbxEmergency.GetDataValue(), ((Hashtable)this.tabGroup.SelectedTab.Tag), this.grdOrder.LayoutTable) == false)
            {
                PostCallHelper.PostCall(new PostMethodStr(this.PostEmergencyCheckedChangeFail), (this.cbxEmergency.GetDataValue() == "Y" ? "N" : "Y"));
            }
            else
            {
                this.ApplyGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag, "emergency", this.cbxEmergency.GetDataValue(), "", "", "");
            }
        }

        private void cbxWonyoiOrderYN_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (this.tabGroup.SelectedTab == null) return;

            this.ApplyGroupInfo((Hashtable)this.tabGroup.SelectedTab.Tag, "wonyoi_order_yn", e.DataValue, "", "", "");
        }

        private void PostEmergencyCheckedChangeFail(string aOrgCheckedValue)
        {
            this.cbxEmergency.CheckedChanged -= new EventHandler(cbxEmergency_CheckedChanged);

            this.cbxEmergency.SetDataValue(aOrgCheckedValue);

            this.cbxEmergency.CheckedChanged += new EventHandler(cbxEmergency_CheckedChanged);
        }

        #endregion

        #region [ 텍스트 박스 이벤트 ]

        private void txtSearch_DataValidating(object sender, DataValidatingEventArgs e)
        {
            //if (e.DataValue == "") return;

            //string wonnaeDrgYn = "";

            //wonnaeDrgYn = this.cboQueryCon.GetDataValue();

            //if (this.rbnSearchOrder.Checked)
            //{
            //    this.LoadSearchOrderInfo(e.DataValue, mOrderDate, INPUTTAB, wonnaeDrgYn);
            //}
            //else if (this.rbnOftenOrder.Checked)
            //{
            //    if (this.tabSangyongOrder.SelectedTab != null)
            //    {
            //        Hashtable tabInfo = this.tabSangyongOrder.SelectedTab.Tag as Hashtable;

            //        this.LoadOftenUseOrder("1", tabInfo["memb"].ToString(), tabInfo["order_gubun"].ToString(), wonnaeDrgYn, e.DataValue);
            //    }
            //}
            //else if (this.rbnSlipHangmog.Checked)
            //{
            //    this.LoadSlipHangmog("2", "%", wonnaeDrgYn, e.DataValue);
            //}

            //PostCallHelper.PostCall(new PostMethod(PostSearchValidating));

        }

        private void PostSearchValidating()
        {
            //this.txtSearch.SetDataValue("");
            //inser by jc
            bool isFocusToTextBox = false;

            if (this.rbnOftenOrder.Checked)
            {
                if (this.grdSangyongOrder.RowCount <= 0)
                    isFocusToTextBox = true;
            }

            if (isFocusToTextBox)
            {
                this.txtSearch.Focus();
                this.txtSearch.SelectAll();
            }
            else
            {
                this.txtSearch.Focus();
                //this.txtSearch.SetDataValue("");
            }
        }

        #endregion

        #region [ 콤보 박스 이벤트 ]

        private void cboQueryCon_SelectedValueChanged(object sender, EventArgs e)
        {
            //string wonnaeDrgYn = "";

            //wonnaeDrgYn = this.cboQueryCon.GetDataValue();

            //if (this.rbnSearchOrder.Checked)
            //{
            //    this.LoadSearchOrderInfo(this.txtSearch.GetDataValue(), mOrderDate, INPUTTAB, wonnaeDrgYn);
            //}
            //else if (this.rbnOftenOrder.Checked)
            //{
            //    if (this.tabSangyongOrder.SelectedTab != null)
            //    {
            //        Hashtable tabInfo = this.tabSangyongOrder.SelectedTab.Tag as Hashtable;

            //        this.LoadOftenUseOrder("1", tabInfo["memb"].ToString(), tabInfo["order_gubun"].ToString(), wonnaeDrgYn, this.txtSearch.GetDataValue());
            //    }
            //}
            //else if (this.rbnSlipHangmog.Checked)
            //{
            //    this.LoadSlipHangmog("2", "%", wonnaeDrgYn, this.txtSearch.GetDataValue());
            //}
            this.Search_text();
        }

        #endregion

        #endregion

        #region [ Command ]

        public override object Command(string command, CommonItemCollection commandParam)
        {
            //this.AcceptData();

            switch (command)
            {
                case "OCS0103Q00":            // 항목검색

                    #region 항목검색

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("OCS0103") && ((MultiLayout)commandParam["OCS0103"]).RowCount > 0)
                        {
                            foreach (DataRow dr in ((MultiLayout)commandParam["OCS0103"]).LayoutTable.Rows)
                            {
                                HandleBtnListButtonClick(FunctionType.Insert);
                                this.ApplySangOrderInfo(dr["hangmog_code"].ToString(), this.grdOrder.CurrentRowNumber, HangmogInfo.ExecutiveMode.CodeInput, true);
                            }
                        }

                        PostCallHelper.PostCall(new PostMethod(PostOrderInsert));
                        this.grdOrder.SetFocusToItem(grdOrder.CurrentRowNumber, "hangmog_code", true);
                        this.grdOrder.SetFocusToItem(grdOrder.CurrentRowNumber, "hangmog_name", false);
                    }

                    #endregion

                    break;

                case "OCS0301Q09":  // 셋 처방



                    #region 셋 처방

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("OCS0303"))
                        {
                            this.ApplyCopyOrderInfo((MultiLayout)commandParam["OCS0303"], HangmogInfo.ExecutiveMode.YaksokCopy);
                        }

                        //PostCallHelper.PostCall(new PostMethodObject(PostOrderInsert), -1);

                        //this.grdOrder.AcceptData();
                    }

                    #endregion

                    break;

                case "OCS1003Q09":  // 전 처방

                    #region 전 처방

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("OCS1003"))
                        {
                            this.ApplyCopyOrderInfo((MultiLayout)commandParam["OCS1003"], HangmogInfo.ExecutiveMode.BeforeOrderCopy);
                        }

                        //PostCallHelper.PostCall(new PostMethodObject(PostOrderInsert), -1);

                        //this.grdOrder.AcceptData();

                    }

                    #endregion

                    break;

            }

            return null;
        }

        #endregion

        #region [PopupMenu 클릭 Event]
        // 처방입력 PopupMenu 클릭시
        // Select All
        private void PopUpMenuSelectAll_Click(object sender, System.EventArgs e)
        {
            if (this.grdOrder == null) return;

            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (!this.grdOrder.IsSelectedRow(i)) this.grdOrder.SelectRow(i);
            }
        }
        // UnSelect All
        private void PopUpMenuUnSelectAll_Click(object sender, System.EventArgs e)
        {
            if (this.grdOrder == null) return;

            this.grdOrder.UnSelectAll();
        }
        // 처방행삭제
        private void PopUpMenuDelete_Click(object sender, System.EventArgs e)
        {
            if (this.MBtnList == null || this.MBtnList.Enabled)
            {
                this.grdOrder.Focus();
                HandleBtnListButtonClick(FunctionType.Delete);
            }
        }
        // Copy
        private void PopUpMenuInsert_Click(object sender, System.EventArgs e)
        {
            if (this.MBtnCopy == null || this.MBtnCopy.Enabled) HandleBtnCopyClick(false);
        }
        // Paster
        private void PopUpMenuPaste_Click(object sender, System.EventArgs e)
        {
            if (this.MBtnPaste == null || this.MBtnPaste.Enabled) HandleBtnPasteClick();
        }
        // 상용오더등록
        private void PopUpMenuSelectOftenOrder_Click(object sender, System.EventArgs e)
        {
            if (this.grdOrder.CurrentRowNumber >= 0 && !TypeCheck.IsNull(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hangmog_code")))
            {
                string memb = "";
                string name = "";
                if (this.mOrderMode == OrderVariables.OrderMode.SetOrder)
                {
                    // 유저별 공통 모드인데 이건 어쩔까...

                    this.mOrderBiz.LoadColumnCodeName("gwa_doctor", "%", this.mMemb, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"), ref name);

                    if (name == "")
                    {
                        // 주과의 상용오더를 가져오자.
                        memb = this.mOrderBiz.GetMainGwaDoctorCode(this.mMemb);
                        if (memb != "")
                            memb = this.mMemb;
                    }
                    else
                    {
                        memb = this.mMemb;
                    }
                }
                else
                {
                    if (UserInfo.UserGubun == UserType.Doctor)
                        memb = UserInfo.DoctorID;
                    else
                        memb = UserInfo.UserID;
                }

                this.mOrderBiz.SaveOfenUsedHangmog("I", "1", memb, grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hangmog_code"), "1", "Y");

                this.tabSangyongOrder_SelectionChanged(this.tabSangyongOrder, new EventArgs());
            }
        }
        // 상용오더 삭제
        private void PopUpMenuSelectOftenOrderDelete_Click(object sender, System.EventArgs e)
        {
            string aMemb = "";
            string aMembGubun = "";
            string aHangmogCode = "";

            aMemb = this.grdSangyongOrder.GetItemString(grdSangyongOrder.CurrentRowNumber, "memb");
            aMembGubun = this.grdSangyongOrder.GetItemString(grdSangyongOrder.CurrentRowNumber, "memb_gubun");
            aHangmogCode = this.grdSangyongOrder.GetItemString(grdSangyongOrder.CurrentRowNumber, "hangmog_code");

            if (this.mOrderBiz.DeleteOftenUsedHangmog(aMembGubun, aMemb, aHangmogCode) == true)
            {
                this.tabSangyongOrder_SelectionChanged(this.tabSangyongOrder, new EventArgs());
            }
        }
        // 재료로 묶여 있는것을 단독으로 변경
        private void PopUpMenuRecoverToDandok_Click(object sender, System.EventArgs e)
        {
            ArrayList selectedRow = new ArrayList();
            int maxRow = -1;
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                if (this.grdOrder.IsSelectedRow(i))
                {
                    selectedRow.Add(i);
                }
            }

            if (selectedRow.Count > 0)
            {
                foreach (int j in selectedRow)
                {
                    this.grdOrder.SetItemValue(j, "child_yn", "N");
                    this.grdOrder.SetItemValue(j, "bom_source_key", "");
                    // 나중에 순서 재정렬을 위하여 dummy 값을 채워주고 재정렬후 뺀다.
                    this.grdOrder.SetItemValue(j, "dummy", "mageshin");

                    maxRow = j;

                }
            }
            else
            {
                this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, "child_yn", "N");
                this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, "bom_source_key", "");
                this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, "dummy", "mageshin");

                maxRow = this.grdOrder.CurrentRowNumber;
            }

            this.grdOrder.DisplayData();

            this.PostOrderInsert();
        }


        #endregion

        #region [ Post 이벤트 들 ]

        private void PostOrderInsert()
        {
            int lastRow = this.SetRowSort();

            this.SetImageToGrid(grdOrder);

            this.SetOrderImage(grdOrder);

            if (lastRow >= 0)
                this.grdOrder.SetFocusToItem(lastRow, "hangmog_code", false);

            this.grdOrder.AcceptData();

            //if (TypeCheck.IsNull(aValidInfo) == false)
            //{
            //    if (TypeCheck.IsInt(aValidInfo.ToString()))
            //    {
            //        this.grdOrder.SetFocusToItem(int.Parse(aValidInfo.ToString()), "hangmog_code", true);
            //    }
            //}
            if (this.mDo_order)
                HandleBtnListButtonClick(FunctionType.Update);
        }

        #endregion

        private void tabGroup_SelectionChanging(object sender, EventArgs e)
        {
            if (this.tabGroup.SelectedTab == null)
                return;

            Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            if (groupInfo.Contains("emergency") && groupInfo["emergency"].ToString() != this.cbxEmergency.GetDataValue())
            {
                this.cbxEmergency.AcceptData();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                isSearchFormKeyPress = true;
                this.Search_text();
            }
        }

        private void Search_text()
        {
            string searchText = this.txtSearch.GetDataValue();
            //Implement with bug MED-6542
            if (searchText == "" /*&& this.rbnOftenOrder.Checked*/)
                searchText = "%";

            if (searchText == "")
                return;

            string wonnaeDrgYn = "";

            wonnaeDrgYn = this.cboQueryCon.GetDataValue();
            
            if (this.rbnOftenOrder.Checked)
            {
                if (this.tabSangyongOrder.SelectedTab != null)
                {
                    Hashtable tabInfo = this.tabSangyongOrder.SelectedTab.Tag as Hashtable;

                    this.LoadOftenUseOrder("1", tabInfo["memb"].ToString(), tabInfo["order_gubun"].ToString(), wonnaeDrgYn, searchText);
                    WarningMessage(grdSangyongOrder);
                }
            }

            PostCallHelper.PostCall(new PostMethod(PostSearchValidating));
        }
        private void cbxSentou_CheckedChanged(object sender, EventArgs e)
        {
            //this.txtSearch.Focus();
            //this.Search_text();
        }

        private void cboSearchCondition_SelectedValueChanged(object sender, EventArgs e)
        {
            this.txtSearch.Focus();
            this.Search_text();
        }

        private void grdSlipHangmog_QueryStarting(object sender, CancelEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            if (this.mOrderMode == OrderVariables.OrderMode.InpOrder || this.mOrderMode == OrderVariables.OrderMode.OutOrder)
                grd.SetBindVarValue("f_order_date", mOrderDate);
            else
                grd.SetBindVarValue("f_order_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
        }

        #region Connect to cloud
        /// <summary>
        /// ExecuteQueryGrdOrderListInfo
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOrderListInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0103U18GrdOrderArgs vOCS0103U18GrdOrderArgs = new OCS0103U18GrdOrderArgs();
            vOCS0103U18GrdOrderArgs.Memb = bc["memb"] != null ? bc["memb"].VarValue : "";
            vOCS0103U18GrdOrderArgs.YaksokCode = bc["yaksok_code"] != null ? bc["yaksok_code"].VarValue : "";
            vOCS0103U18GrdOrderArgs.FkInOutKey = bc["fk_in_out_key"] != null ? bc["fk_in_out_key"].VarValue : "";
            vOCS0103U18GrdOrderArgs.InputTab = bc["input_tab"] != null ? bc["input_tab"].VarValue : "";
            vOCS0103U18GrdOrderArgs.InputGubun = bc["input_gubun"] != null ? bc["input_gubun"].VarValue : "";
            OCS0103U18GrdOrderResult result = CloudService.Instance.Submit<OCS0103U18GrdOrderResult, OCS0103U18GrdOrderArgs>(vOCS0103U18GrdOrderArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0103U13GrdOrderListInfo item in result.GridOrderInfo)
                {
                    object[] objects =
                    {
                        item.PkOrdKey,
                        item.Memb,
                        item.YaksokCode,
                        item.Bunho,
                        item.IoGubun1,
                        item.OrderDate,
                        item.OrderTime,
                        item.Gwa,
                        item.Doctor,
                        item.Resident,
                        item.NaewonType,
                        item.InputId,
                        item.InputPart,
                        item.InputGwa,
                        item.InputDoctor,
                        item.InputGubun,
                        item.InputGubunName,
                        item.GroupSer,
                        item.InputTab,
                        item.InputTabName,
                        item.OrderGubun,
                        item.OrderGubunName,
                        item.NdayYn1,
                        item.Seq,
                        item.SlipCode,
                        item.HangmogCode,
                        item.HangmogName,
                        item.SpecimenCode,
                        item.SpecimenName,
                        item.Suryang,
                        item.SunabSuryang,
                        item.SubulSuryang,
                        item.OrdDanui,
                        item.OrdDanuiName,
                        item.DvTime,
                        item.Dv,
                        item.Dv1,
                        item.Dv2,
                        item.Dv3,
                        item.Dv4,
                        item.Nalsu,
                        item.SunabNalsu,
                        item.Jusa,
                        item.JusaName,
                        item.JusaSpdGubun,
                        item.BogyongCode,
                        item.BogyongName,
                        item.Emergency,
                        item.JaeryoJundalYn,
                        item.JundalTable,
                        item.JundalPart,
                        item.MovePart,
                        item.PortableYn,
                        item.PowderYn,
                        item.HubalChangeYn,
                        item.Phamacy,
                        item.DrgPackYn,
                        item.Muhyo,
                        item.PrnYn,
                        item.ToiwonDrgYn,
                        item.PrnNurse,
                        item.AppendYn,
                        item.OrderRemark,
                        item.NurseRemark,
                        item.MixGroup,
                        item.Amt,
                        item.Pay,
                        item.WonyoiOrderYn,
                        item.DangilGumsaOrderYn,
                        item.DangilGumsaResultYn,
                        item.BomOccurYn,
                        item.BomSourceKey,
                        item.DisplayYn,
                        item.SunabYn,
                        item.SunabDate,
                        item.SunabTime,
                        item.HopeDate,
                        item.HopeTime,
                        item.NurseConfirmUser,
                        item.NurseConfirmDate,
                        item.NurseConfirmTime,
                        item.NursePickupUser,
                        item.NursePickupDate,
                        item.NursePickupTime,
                        item.NurseHoldUser,
                        item.NurseHoldDate,
                        item.NurseHoldTime,
                        item.ReserDate,
                        item.ReserTime,
                        item.JubsuDate,
                        item.JubsuTime,
                        item.ActingDate,
                        item.ActingTime,
                        item.ActingDay,
                        item.ResultDate,
                        item.DcGubun,
                        item.DcYn,
                        item.BannabYn,
                        item.BannabConfirm,
                        item.SourceOrdKey,
                        item.OcsFlag,
                        item.SgCode,
                        item.SgYmd,
                        item.IoGubun2,
                        item.AfterActYn,
                        item.BichiYn,
                        item.DrgBunho,
                        item.SubSusul,
                        item.PrintYn,
                        item.Chisik,
                        item.TelYn,
                        item.OrderGubunBas,
                        item.InputControl,
                        item.SugaYn,
                        item.JaeryoYn,
                        item.WonyoiCheck,
                        item.EmergencyCheck,
                        item.SpecimenCheck,
                        item.PortableCheck,
                        item.BulyongCheck,
                        item.SunabCheck1,
                        item.SunabCheck2,
                        item.DcCheck,
                        item.DcGubunCheck,
                        item.ConfirmCheck,
                        item.ReserYnCheck,
                        item.ChisikCheck,
                        item.NdayYn2,
                        item.DefaultJaeryoJundalYn,
                        item.DefaultWonyoiOrderYn,
                        item.SpecificComments,
                        item.SpecificCommentName,
                        item.SpecificCommentSysId,
                        item.SpecificCommentPgmId,
                        item.OrderByKey,
                        item.SortFkocsKey,
                        item.Fkinp1001,
                        item.RegularYn,
                        item.ActDoctor,
                        item.ActGwa,
                        item.ActBuseo,
                        item.Pkocs2003,
                        item.RowState
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// GetGrdSearchOrder
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdSearchOrder(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U13GrdSearchOrderListArgs arg = new OCS0103U13GrdSearchOrderListArgs();
            arg.OrderDate = bvc["f_order_date"].VarValue;
            arg.SearchWord = bvc["f_search_word"].VarValue;
            arg.PageNumber = bvc["f_page_number"].VarValue;
            arg.Offset = "200";
            arg.ProtocolId = mprotocolID;

            OCS0103U13GrdSearchOrderListResult res = CloudService.Instance.Submit<OCS0103U13GrdSearchOrderListResult,
                OCS0103U13GrdSearchOrderListArgs>(arg);

            if (null != res)
            {
                foreach (OCS0103U13GrdSearchOrderListInfo item in res.GrdSearchOrderListItem)
                {
                    lObj.Add(new object[]
                    {
                        item.TrialFlg,
                        item.SlipCode,
                        item.SlipName,
                        item.HangmogCode,
                        item.HangmogName,
                        item.HospCode,
                    });
                }
            }

            return lObj;
        }

        ////Fix bug MED-8921 
        ///<summary>
        /// GetGrdSangyongOrder
        ///</summary>
        private IList<object[]> GetGrdSangyongOrder(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0103U13GrdSangyongOrderListArgs args = new OCS0103U13GrdSangyongOrderListArgs();
            args.User = bvc["f_user"].VarValue;
            args.IoGubun = bvc["f_io_gubun"].VarValue;
            args.OrderGubun = bvc["f_order_gubun"].VarValue;
            args.OrderDate = bvc["f_order_date"].VarValue;
            args.SearchWord = bvc["f_search_word"].VarValue;
            args.WonnaeDrgYn = bvc["f_wonnae_drg_yn"].VarValue;
            args.ProtocolId = protocolId;
            args.PageNumber = bvc["f_page_number"].VarValue;
            args.Offset = "200";
            OCS0103U13GrdSangyongOrderListResult res = CloudService.Instance.Submit<OCS0103U13GrdSangyongOrderListResult,
                OCS0103U13GrdSangyongOrderListArgs>(args);

            if (null != res)
            {
                foreach (OCS0103U13GrdSangyongOrderListInfo item in res.GrdSangyongItem)
                {
                    lObj.Add(new object[]
                    {
                        item.SlipCode,
                        item.SlipName,
                        item.HangmogCode,
                        item.HangmogName,
                        item.Seq,
                        item.HospCode,
                        item.Memb,
                        item.MembGubun,
                        item.WonnaeDrgYn,
                        item.Rownum,
                        item.TrialFlag,
                    });
                }
            }

            return lObj;
        }

        #endregion

        /// <summary>
        /// GetListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<OCS0103U10SaveLayoutInfo> GetListDataForSaveLayout()
        {
            List<OCS0103U10SaveLayoutInfo> lstResult = new List<OCS0103U10SaveLayoutInfo>();

            for (int i = 0; i < grdOrder.RowCount; i++)
            {
                OCS0103U10SaveLayoutInfo item = new OCS0103U10SaveLayoutInfo();
                item.UserId = UserInfo.UserID;
                item.OrderGubun = grdOrder.GetItemString(i, "order_gubun");
                item.Suryang = grdOrder.GetItemString(i, "suryang");
                item.DvTime = grdOrder.GetItemString(i, "dv_time");
                item.Dv = grdOrder.GetItemString(i, "dv");
                item.NdayYn = grdOrder.GetItemString(i, "nday_yn");
                item.Nalsu = grdOrder.GetItemString(i, "nalsu");
                item.Jusa = grdOrder.GetItemString(i, "jusa");
                item.BogyongCode = grdOrder.GetItemString(i, "bogyong_code");
                item.Emergency = grdOrder.GetItemString(i, "emergency");
                item.JaeryoJundalYn = grdOrder.GetItemString(i, "jaeryo_jundal_yn");
                item.JundalTable = grdOrder.GetItemString(i, "jundal_table");
                item.JundalPart = grdOrder.GetItemString(i, "jundal_part");
                item.MovePart = grdOrder.GetItemString(i, "move_part");
                item.Muhyo = grdOrder.GetItemString(i, "muhyo");
                item.PortableYn = grdOrder.GetItemString(i, "portable_yn");
                //item.AntiCancerYn                   = grdOrder.GetItemString(i, "anti_cancer_yn");
                item.DcYn = grdOrder.GetItemString(i, "dc_yn");
                item.DcGubun = grdOrder.GetItemString(i, "dc_gubun");
                item.BannabYn = grdOrder.GetItemString(i, "bannab_yn");
                item.BannabConfirm = grdOrder.GetItemString(i, "bannab_confirm");
                item.PowderYn = grdOrder.GetItemString(i, "powder_yn");
                item.HopeDate = grdOrder.GetItemString(i, "hope_date");
                item.HopeTime = grdOrder.GetItemString(i, "hope_time");
                item.Dv1 = grdOrder.GetItemString(i, "dv_1");
                item.Dv2 = grdOrder.GetItemString(i, "dv_2");
                item.Dv3 = grdOrder.GetItemString(i, "dv_3");
                item.Dv4 = grdOrder.GetItemString(i, "dv_4");
                //item.Dv5                            = grdOrder.GetItemString(i, "dv_5");
                //item.Dv6                            = grdOrder.GetItemString(i, "dv_6");
                //item.Dv7                            = grdOrder.GetItemString(i, "dv_7");
                //item.Dv8                            = grdOrder.GetItemString(i, "dv_8");
                item.MixGroup = grdOrder.GetItemString(i, "mix_group");
                item.OrderRemark = grdOrder.GetItemString(i, "order_remark");
                item.NurseRemark = grdOrder.GetItemString(i, "nurse_remark");
                item.BomOccurYn = grdOrder.GetItemString(i, "bom_occur_yn");
                item.BomSourceKey = grdOrder.GetItemString(i, "bom_source_key");
                item.NurseConfirmUser = grdOrder.GetItemString(i, "nurse_confirm_user");
                item.NurseConfirmDate = grdOrder.GetItemString(i, "nurse_confirm_date");
                item.NurseConfirmTime = grdOrder.GetItemString(i, "nurse_confirm_time");
                item.RegularYn = grdOrder.GetItemString(i, "regular_yn");
                item.HubalChangeYn = grdOrder.GetItemString(i, "hubal_change_yn");
                item.Pharmacy = grdOrder.GetItemString(i, "pharmacy");
                item.JusaSpdGubun = grdOrder.GetItemString(i, "jusa_spd_gubun");
                item.DrgPackYn = grdOrder.GetItemString(i, "drg_pack_yn");
                item.SortFkocskey = grdOrder.GetItemString(i, "sort_fkocskey");
                item.WonyoiOrderYn = grdOrder.GetItemString(i, "wonyoi_order_yn");
                item.SpecimenCode = grdOrder.GetItemString(i, "specimen_code");
                item.Pkocskey = grdOrder.GetItemString(i, "pkocskey");
                item.InputId = grdOrder.GetItemString(i, "input_id");
                item.HangmogCode = grdOrder.GetItemString(i, "hangmog_code");
                item.ActBuseo = grdOrder.GetItemString(i, "act_buseo");
                item.BichiYn = grdOrder.GetItemString(i, "bichi_yn");
                //item.BogyongCodeSub                 = grdOrder.GetItemString(i, "bogyong_code_sub");
                item.Bunho = grdOrder.GetItemString(i, "bunho");
                item.InputPart = grdOrder.GetItemString(i, "input_part");
                item.GroupSer = grdOrder.GetItemString(i, "group_ser");
                item.Pay = grdOrder.GetItemString(i, "pay");
                item.OcsFlag = grdOrder.GetItemString(i, "ocs_flag");
                item.DrgBunho = grdOrder.GetItemString(i, "drg_bunho");
                item.InputTab = grdOrder.GetItemString(i, "input_tab");
                item.OrderDate = grdOrder.GetItemString(i, "order_date");
                item.InputGubun = grdOrder.GetItemString(i, "input_gubun");
                item.SlipCode = grdOrder.GetItemString(i, "slip_code");
                item.ReserDate = grdOrder.GetItemString(i, "reser_date");
                item.SgCode = grdOrder.GetItemString(i, "sg_code");
                item.SubSusul = grdOrder.GetItemString(i, "sub_susul");
                item.TelYn = grdOrder.GetItemString(i, "tel_yn");
                item.Seq = grdOrder.GetItemString(i, "seq");
                item.ReserTime = grdOrder.GetItemString(i, "reser_time");
                item.ActDoctor = grdOrder.GetItemString(i, "act_doctor");
                item.SgYmd = grdOrder.GetItemString(i, "sg_ymd");
                item.InOutKey = grdOrder.GetItemString(i, "in_out_key");
                item.Doctor = grdOrder.GetItemString(i, "doctor");
                item.ActGwa = grdOrder.GetItemString(i, "act_gwa");
                item.IoGubun = grdOrder.GetItemString(i, "io_gubun");
                item.InputDoctor = grdOrder.GetItemString(i, "input_doctor");
                item.InputGwa = grdOrder.GetItemString(i, "input_gwa");
                item.SourceOrdKey = grdOrder.GetItemString(i, "source_ord_key");

                item.RowState = grdOrder.GetRowState(i).ToString();
                lstResult.Add(item);
            }

            // Delete
            if (null != grdOrder.DeletedRowTable)
            {
                foreach (DataRow dr in grdOrder.DeletedRowTable.Rows)
                {
                    OCS0103U10SaveLayoutInfo item = new OCS0103U10SaveLayoutInfo();
                    item.Pkocskey = Convert.ToString(dr["pkocskey"]);
                    item.RowState = DataRowState.Deleted.ToString();
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }

        /// <summary>
        /// GetListDataForInterfaceInsert
        /// </summary>
        /// <returns></returns>
        private List<PrOcsInterfaceInsertInfo> GetListDataForInterfaceInsert()
        {
            List<PrOcsInterfaceInsertInfo> paramList = new List<PrOcsInterfaceInsertInfo>();

            foreach (Hashtable delItem in this.mInterface.MDeletedIfItems)
            {
                PrOcsInterfaceInsertInfo item = new PrOcsInterfaceInsertInfo(
                    Convert.ToString(delItem["io_gubun"]),
                    Convert.ToString(delItem["key"]),
                    Convert.ToString(delItem["user_id"]));

                paramList.Add(item);
            }

            foreach (Hashtable modItem in this.mInterface.MModifiedItems)
            {
                PrOcsInterfaceInsertInfo item = new PrOcsInterfaceInsertInfo(
                    Convert.ToString(modItem["io_gubun"]),
                    Convert.ToString(modItem["key"]),
                    Convert.ToString(modItem["user_id"]));

                paramList.Add(item);
            }

            return paramList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdSlipHangmogInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0103U15GrdSlipHangmogArgs vOCS0103U15GrdSlipHangmogArgs = new OCS0103U15GrdSlipHangmogArgs();
            vOCS0103U15GrdSlipHangmogArgs.Mode = bc["f_mode"] != null ? bc["f_mode"].VarValue : "";
            vOCS0103U15GrdSlipHangmogArgs.SlipCode = bc["f_slip_code"] != null ? bc["f_slip_code"].VarValue : "";
            vOCS0103U15GrdSlipHangmogArgs.WonnaeDrgYn = bc["f_wonnae_drg_yn"] != null ? bc["f_wonnae_drg_yn"].VarValue : "";
            vOCS0103U15GrdSlipHangmogArgs.OrderDate = bc["f_order_date"] != null ? bc["f_order_date"].VarValue : "";
            vOCS0103U15GrdSlipHangmogArgs.InputTab = bc["f_input_tab"] != null ? bc["f_input_tab"].VarValue : "";
            vOCS0103U15GrdSlipHangmogArgs.SearchWord = bc["f_search_word"] != null ? bc["f_search_word"].VarValue : "";
            vOCS0103U15GrdSlipHangmogArgs.SearchCondition = bc["f_search_condition"] != null ? bc["f_search_condition"].VarValue : "";
            vOCS0103U15GrdSlipHangmogArgs.PageNumber = bc["f_page_number"].VarValue;
            vOCS0103U15GrdSlipHangmogArgs.Offset = "200";
            vOCS0103U15GrdSlipHangmogArgs.ProtocolId = mprotocolID;
            OCS0103U15GrdSlipHangmogResult result = CloudService.Instance.Submit<OCS0103U15GrdSlipHangmogResult, OCS0103U15GrdSlipHangmogArgs>(vOCS0103U15GrdSlipHangmogArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0103U15GrdSlipHangmogInfo item in result.ListItem)
                {
                    object[] objects =
                    {
                        item.TrialFlg,
                        item.SlipCode,
                        item.Position,
                        item.Seq,
                        item.HangmogCode,
                        item.HangmogName,
                        item.SpecimenCode,
                        item.GroupYn,
                        item.BulyongCheck,
                        item.WonnaeDrgYn
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
        private List<object[]> ExecuteQueryLaySlipCodeTreeInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0103U15LaySlipCodeTreeArgs vOCS0103U15LaySlipCodeTreeArgs = new OCS0103U15LaySlipCodeTreeArgs();
            OCS0103U15LaySlipCodeTreeResult result = CloudService.Instance.Submit<OCS0103U15LaySlipCodeTreeResult, OCS0103U15LaySlipCodeTreeArgs>(vOCS0103U15LaySlipCodeTreeArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0103U15LaySlipCodeTreeInfo item in result.ListItem)
                {
                    object[] objects =
                    {
                        item.SlipGubun,
                        item.SlipGubunName,
                        item.SlipCode,
                        item.SlipName
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
        private List<object[]> ComboSearchCondition(BindVarCollection bc)
        {
            List<object[]> result = new List<object[]>();
            ComboSearchConditionArgs args = new ComboSearchConditionArgs();
            args.CodeType = "SEARCH_GUBUN";
            ComboResult comboResult =
                CacheService.Instance.Get<ComboSearchConditionArgs, ComboResult>(args, delegate(ComboResult result1)
                    {
                        return result1 != null && result1.ExecutionStatus == ExecutionStatus.Success &&
                               result1.ComboItem != null && result1.ComboItem.Count > 0;
                    });
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo info in comboResult.ComboItem)
                {
                    result.Add(new object[] { info.Code, info.CodeName });
                }

            }
            return result;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            HandleBtnListButtonClick(FunctionType.Insert);
        }
        public void ReLoadRegularOrder()
        {
            if (this.tabSangyongOrder.SelectedTab != null)
            {
                Hashtable tabInfo = this.tabSangyongOrder.SelectedTab.Tag as Hashtable;

                this.LoadOftenUseOrder("1", tabInfo["memb"].ToString(), tabInfo["order_gubun"].ToString(), this.cboQueryCon.GetDataValue(), this.txtSearch.GetDataValue());
            }
        }

        private void UCOCS0103U15C_Paint(object sender, PaintEventArgs e)
        {
            if (!_screenActivated)
            {
                _screenActivated = true;
                string temp = "";
                ScreenOpen(_aOpenParam);
            }
        }

        private void grdSangyongOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            if (this.mPatientInfo != null)
            {
                this.grdSangyongOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

                if (UserInfo.UserGubun == UserType.Doctor)
                {
                    this.grdSangyongOrder.SetBindVarValue("f_user", UserInfo.UserID);
                }
                else if (this.mPatientInfo.GetPatientInfo != null)
                {
                    if (this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Length >= 2)
                    {
                        this.grdSangyongOrder.SetBindVarValue("f_user", this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(2));
                    }
                }
                else
                {
                    this.grdSangyongOrder.SetBindVarValue("f_user", UserInfo.UserID);
                }

                this.grdSangyongOrder.SetBindVarValue("f_io_gubun", this.IOEGUBUN);
                this.grdSangyongOrder.SetBindVarValue("f_search_word", this.txtSearch.Text);
                /*this.grdSangyongOrder.SetBindVarValue("f_order_gubun", ((Hashtable)this.tabSangyongOrder.SelectedTab.Tag)["order_gubun"].ToString());*/
                //MED-10523
                this.grdSangyongOrder.SetBindVarValue("f_order_gubun", tabSangyongOrder != null && tabSangyongOrder.SelectedTab != null ? ((Hashtable)this.tabSangyongOrder.SelectedTab.Tag)["order_gubun"].ToString() : "");
                this.grdSangyongOrder.SetBindVarValue("f_order_date", mOrderDate);
                this.grdSangyongOrder.SetBindVarValue("f_wonnae_drg_yn", this.cboQueryCon.GetDataValue());
            }
        }

        #region MED-6658
        //Warning message func
        private void WarningMessage(XEditGrid xGrd)
        {
            if (xGrd.RowCount == 0 && isSearchFormKeyPress)
            {
                XMessageBox.Show(Resources.UCOCS0103U15_WarningMessage, Resources.Cap_000033, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isSearchFormKeyPress = false;
            }
        }
        #endregion
    }

    //insert by jc 
    #region XSavePeformer
    /*public class XSavePeformer : ISavePerformer
    {
        private UCOCS0103U15C parent = null;
        private IHIS.OCS.OrderBiz mOrderBiz = new OrderBiz("OCS0103U15");

        public XSavePeformer(UCOCS0103U15C parent)
        {
            this.parent = parent;
        }

        public bool Execute(char callerId, RowDataItem item)
        {
            string cmdText = "";
            object t_chk = "";
            string spName = "";
            ArrayList inList = new ArrayList();
            ArrayList outList = new ArrayList();

            item.BindVarList.Add("q_user_id", UserInfo.UserID);
            item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
            switch (callerId)
            {

                case '2':    // 삭제로직...

                    #region 오더 삭제
                    // 삭제시 DC 반납 원오더 원래대로 위치
                    if (item.BindVarList["f_source_ord_key"].VarValue != "")
                    {
                        inList.Clear();
                        outList.Clear();
                        inList.Add("I");
                        inList.Add(item.BindVarList["f_source_ord_key"].VarValue);

                        spName = "PR_OCS_UPDATE_DC_YN";

                        if (Service.ExecuteProcedure(spName, inList, outList) == false)
                        {
                            MessageBox.Show(Service.ErrFullMsg, Resources.TEXT12, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    // 현재 오더가 n데이 오더인경우 해당 키로 발생된 오더 삭제

                    if (item.BindVarList["f_nday_yn"].VarValue == "Y")
                    {
                        spName = "PR_OCS_DELETE_NDAY_ORDER";
                        inList.Clear();
                        inList.Add(item.BindVarList["f_pkocskey"].VarValue);
                        outList.Clear();

                        if (Service.ExecuteProcedure(spName, inList, outList) == false)
                        {
                            return false;
                        }

                        if (outList[0].ToString() != "0")
                        {
                            return false;
                        }
                    }

                    cmdText = " DELETE FROM OCS2003 "
                            + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                            + "    AND PKOCS2003 = :f_pkocskey ";



                    #endregion

                    break;

                case '3':    // 인서트 & 업데이트 

                    #region 오더 입력 및 변경

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
                                        + "   FROM OCS2003 "
                                        + "  WHERE HOSP_CODE  = '" + EnvironInfo.HospCode + "' "
                                        + "    AND BUNHO      = '" + item.BindVarList["f_bunho"].VarValue + "' "
                                        + "    AND FKINP1001  = " + item.BindVarList["f_in_out_key"].VarValue
                                        + "    AND ORDER_DATE = TO_DATE('" + item.BindVarList["f_order_date"].VarValue + "', 'YYYY/MM/DD')  ";

                                t_chk = Service.ExecuteScalar(cmdText);

                                if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "")
                                {
                                    t_chk = "1";
                                }

                                item.BindVarList.Remove("f_seq");
                                item.BindVarList.Add("f_seq", t_chk.ToString());
                            }

                            cmdText = " INSERT INTO OCS2003 "
                                    + "      ( SYS_DATE             , SYS_ID               , UPD_DATE          , UPD_ID                  , HOSP_CODE             , "
                                    + "        PKOCS2003            , BUNHO                , ORDER_DATE        , ORDER_TIME              , DOCTOR                , "
                                    + "        INPUT_ID             , INPUT_PART           , INPUT_GUBUN       , SEQ                     , RESIDENT              , "
                                    + "        HANGMOG_CODE         , GROUP_SER            , SLIP_CODE         , NDAY_YN                 , ORDER_GUBUN           , "
                                    + "        SPECIMEN_CODE        , SURYANG              , ORD_DANUI         , DV_TIME                 , DV                    , "
                                    + "        NALSU                , JUSA                 , BOGYONG_CODE      , EMERGENCY               , JAERYO_JUNDAL_YN      , "
                                    + "        JUNDAL_TABLE         , JUNDAL_PART          , MOVE_PART         , MUHYO                   , PORTABLE_YN           , "
                                    + "        ANTI_CANCER_YN       , PAY                  , RESER_DATE        , RESER_TIME              , DC_YN                 , "
                                    + "        DC_GUBUN             , BANNAB_YN            , BANNAB_CONFIRM    , ACT_DOCTOR              , ACT_GWA               , "
                                    + "        ACT_BUSEO            , OCS_FLAG             , SG_CODE           , SG_YMD                  , IO_GUBUN              , "
                                    + "        BICHI_YN             , DRG_BUNHO            , SUB_SUSUL         , WONYOI_ORDER_YN         , "
                                    + "        POWDER_YN            , HOPE_DATE            , HOPE_TIME         , DV_1                    , "
                                    + "        DV_2                 , DV_3                 , DV_4              , MIX_GROUP               , ORDER_REMARK          , "
                                    + "        NURSE_REMARK         , BOM_OCCUR_YN         , BOM_SOURCE_KEY    , DISPLAY_YN              , NURSE_CONFIRM_USER    , "
                                    + "        NURSE_CONFIRM_DATE   , NURSE_CONFIRM_TIME   , TEL_YN            , "
                                    + "        REGULAR_YN           , INPUT_TAB            , HUBAL_CHANGE_YN   , PHARMACY                , INPUT_DOCTOR          , "
                                    + "        JUSA_SPD_GUBUN       , DRG_PACK_YN          , SORT_FKOCSKEY     , FKINP1001               , INPUT_GWA             , "
                                    + "        NDAY_OCCUR_YN        ) "
                                    + " VALUES "
                                    + "      ( SYSDATE              , :q_user_id           , SYSDATE           , :q_user_id              , :f_hosp_code             , "
                                    + "        :f_pkocskey          , :f_bunho             , :f_order_date     , TO_CHAR(SYSDATE, 'HH24MI'), :f_doctor               , "
                                    + "        :f_input_id          , :f_input_part        , :f_input_gubun    , :f_seq                  , :f_doctor                , "
                                    + "        :f_hangmog_code      , :f_group_ser         , :f_slip_code      , :f_nday_yn              , :f_order_gubun           , "
                                    + "        :f_specimen_code     , :f_suryang           , :f_ord_danui      , :f_dv_time              , :f_dv                    , "
                                    + "        :f_nalsu             , :f_jusa              , :f_bogyong_code   , :f_emergency            , :f_jaeryo_jundal_yn      , "
                                    + "        :f_jundal_table      , :f_jundal_part       , :f_move_part      , :f_muhyo                , :f_portable_yn           , "
                                    + "        'N'                  , :f_pay               , :f_reser_date     , :f_reser_time           , :f_dc_yn                 , "
                                    + "        :f_dc_gubun          , :f_bannab_yn         , :f_bannab_confirm , :f_act_doctor           , :f_act_gwa               , "
                                    + "        :f_act_buseo         , :f_ocs_flag          , :f_sg_code        , :f_sg_ymd               , :f_io_gubun              , "
                                    + "        :f_bichi_yn          , :f_drg_bunho         , :f_sub_susul      , :f_wonyoi_order_yn      , "
                                    + "        :f_powder_yn         , :f_hope_date         , :f_hope_time      , :f_dv_1                 , "
                                    + "        :f_dv_2              , :f_dv_3              , :f_dv_4           , :f_mix_group            , :f_order_remark          , "
                                    + "        :f_nurse_remark      , :f_bom_occur_yn      , :f_bom_source_key , 'Y'                     , :f_nurse_confirm_user    , "
                                    + "        :f_nurse_confirm_date, :f_nurse_confirm_time, :f_tel_yn         , "
                                    + "        :f_regular_yn        , :f_input_tab         , :f_hubal_change_yn, :f_pharmacy             , :f_input_doctor          , "
                                    + "        :f_jusa_spd_gubun    , :f_drg_pack_yn       , :f_sort_fkocskey  , :f_in_out_key           , :f_input_gwa             , "
                                    + "        'N'                  ) ";



                            break;

                        case DataRowState.Modified:

                            cmdText = " UPDATE OCS2003 "
                                    + "    SET UPD_DATE         = SYSDATE "
                                    + "      , UPD_ID           = :q_user_id "
                                    + "      , ORDER_GUBUN      = :f_order_gubun "
                                    + "      , SURYANG          = :f_suryang "
                                    + "      , DV_TIME          = :f_dv_time "
                                    + "      , DV               = :f_dv "
                                    + "      , NDAY_YN          = :f_nday_yn "
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
                                    + "      , POWDER_YN        = :f_powder_yn "
                                    + "      , HOPE_DATE        = :f_hope_date "
                                    + "      , HOPE_TIME        = :f_hope_time "
                                    + "      , DV_1             = :f_dv_1 "
                                    + "      , DV_2             = :f_dv_2 "
                                    + "      , DV_3             = :f_dv_3 "
                                    + "      , DV_4             = :f_dv_4 "
                                    + "      , MIX_GROUP        = :f_mix_group "
                                    + "      , ORDER_REMARK     = :f_order_remark "
                                    + "      , NURSE_REMARK     = :f_nurse_remark "
                                    + "      , BOM_OCCUR_YN     = :f_bom_occur_yn "
                                    + "      , BOM_SOURCE_KEY   = :f_bom_source_key "
                                    + "      , NURSE_CONFIRM_USER = :f_nurse_confirm_user "
                                    + "      , NURSE_CONFIRM_DATE = :f_nurse_confirm_date "
                                    + "      , NURSE_CONFIRM_TIME = :f_nurse_confirm_time "
                                    + "      , REGULAR_YN       = :f_regular_yn "
                                    + "      , HUBAL_CHANGE_YN  = :f_hubal_change_yn "
                                    + "      , PHARMACY         = :f_pharmacy "
                                    + "      , JUSA_SPD_GUBUN   = :f_jusa_spd_gubun "
                                    + "      , DRG_PACK_YN      = :f_drg_pack_yn "
                                    + "      , SORT_FKOCSKEY    = :f_sort_fkocskey "
                                    + "      , WONYOI_ORDER_YN  = :f_wonyoi_order_yn "
                                    + "      , DISPLAY_YN       = CASE WHEN DC_GUBUN = 'Y' AND SORT_FKOCSKEY IS NOT NULL AND :f_dc_gubun = 'N' THEN 'N' "
                                    + "                                ELSE DISPLAY_YN END "
                                    + "      , SPECIMEN_CODE    = :f_specimen_code "
                                    + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                                    + "    AND PKOCS2003 = :f_pkocskey ";



                            break;

                    }

                    #endregion

                    break;
            }

            bool isSuccess = Service.ExecuteNonQuery(cmdText, item.BindVarList);

            // 오더 업데이트의 경우는 정시약도 같이 업데이트 되어야 함.
            if (callerId == '3' && isSuccess)
            {
                if (this.mOrderBiz.SaveRegularOrder("2", item.BindVarList["f_pkocskey"].VarValue) == false)
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
    }*/
    #endregion
}
