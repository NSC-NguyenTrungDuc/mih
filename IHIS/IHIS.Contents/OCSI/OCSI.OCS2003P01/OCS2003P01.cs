using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.OCS;

namespace IHIS.OCSI
{
    public partial class OCS2003P01 : IHIS.Framework.XScreen
    {
        public OCS2003P01()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        #region 각종변수들
        public int mInsertedOrderCnt = 0;
        public int mUpdatedOrderCnt  = 0;
        public int mDeletedOrderCnt  = 0;

        public int mInsteadInsertedOrderCnt = 0;
        public int mInsteadUpdatedOrderCnt = 0;
        public int mInsteadDeletedOrderCnt = 0;

        private bool mPostApprove_Visible = false;
        private bool mApprove_Force = false;

        public string mPatientHoDongCode = "";
        public string mDrgGwaCode = "";
        public bool mPostApproveYN = false;

        private int patientListdisplayedcount = 0;

        private const string NotCodeSyoubyou = "0000999";
        //Message처리
        string mbxMsg = "", mbxCap = "";

        private string IO_Gubun = "I";

        private string mMsg = "";
        private string mCap = "";
        private string mClickedOrderButton = "";
        public string mChangeBeforeGwa = "";

        private bool ToiwonGojiYN_by_CanSaveFlg = true;
        // Do, Set Order用
        // 포커스를 위한 로우 번호
        private int mFocusRow = -1;

        private Hashtable groupInfo;
        private string iInputGubun = "";
        private string iInputGubunName = ""; // 입력구분명 Do, Setオーダ用
        //Doオーダ関連変数
        private string INPUTTAB = ""; // 내복약 (01) 
        private const string IOEGUBUN = "I";     // 입외구분(외래)

        private string mInputPart = "";      // 입력파트(01)
        //insert by jc [選択された患者の保険を取得]
        private string mClickedGubun = "";

        // CP관련 키
        private string mMembGubun = "";
        private string mCpCode = "";
        private string mJaewonil = "";
        private string mCpPathCode = "";
        private string mCpMasterkey = "";

        // 셋트오더 관련 _ 키
        private string mMemb = "";
        private string mYaksokCode = "";  // 셋트이면 약속코드, Cp 이면 Cp Code 가 들어감.

        //공통
        private string mOrderDate = "";
        private OrderVariables.OrderMode mOrderMode;
        
        //insert by jc[Sysdateを保存ボタンを押す時点の時間にするため]
        internal string mSave_time = "";

        ///////////////////////////////////////////////////////////////////////////////////
        // 상병 확장 관련
        ///////////////////////////////////////////////////////////////////////////////////

        const int mSizeSB = 185;

        //private int mExpandedIndex = 2;
        //private int mUnExpandedIndex = 1;

        //private int mExpandedSize = 219;
        //private int mUnExpandedSize = 37;

        //private bool mIsExpanded = true;

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
        // 입력구분 색관련
        ///////////////////////////////////////////////////////////////////////////////////
        private XColor mExistInputGubunColor = new XColor(Color.Red);
        private XColor mNormalInputGubunColor = new XColor(Color.Black);

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
        protected OCS.OrderBiz mOrderBiz = new IHIS.OCS.OrderBiz("OCS2003P01");
        private OCS.OrderFunc mOrderFunc = new IHIS.OCS.OrderFunc("OCS2003P01");
        private OCS.HangmogInfo mHangmogInfo = new HangmogInfo("OCS2003P01");
        private OCS.CommonForms mCommonForms = new CommonForms();
        private OCS.OrderInterface mInterface = new OrderInterface();


        ///////////////////////////////////////////////////////////////////////////////////
        // 로컬변수
        ///////////////////////////////////////////////////////////////////////////////////
        private string mParamNaewonKey = "";
        private string mParamNaewonDate = "";
        private string mParamBunho = "";
        private ArrayList mBunhoInfoControls = new ArrayList();

        private bool mDoctorLogin = false;
        private bool mIsOCSSystem = false;
        public string mInputGubun = "";
        private string mInputGwa = "";

        private const string mInputGubunDoctor = "D%";

        private string mCurrentInputTab = "";

        private bool mIsCheck = false;

        private bool mIsCalledbyOtherScreen = false;

        // 팝업메뉴
        private IHIS.X.Magic.Menus.PopupMenu mMenuPFEResult = new IHIS.X.Magic.Menus.PopupMenu();
        private IHIS.X.Magic.Menus.PopupMenu mMenuInputGubunResult = new IHIS.X.Magic.Menus.PopupMenu();
        private IHIS.X.Magic.Menus.PopupMenu mMenuCycleOrderGubun = new IHIS.X.Magic.Menus.PopupMenu();

        ArrayList mCplPrintList = new ArrayList();

        #endregion

        #region [ Screen 이벤트 ]

        private void OCS1003P00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // 화면 사이즈 조정
            // 화면 크기를 화면에 맞게 최대화 시킨다 (다른 화면에서 연경우가 아닌경우)
            //if (this.Opener is IHIS.Framework.MdiForm &&
            //    (this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed))
            //if (this.Opener is IHIS.Framework.MdiForm)
            //{
            //    Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            //    this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 120);
            //}

            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 120);

            // 환자번호 입력자릿수 설정
            this.fbxBunho.MaxLength = EnvironInfo.BunhoLength;

            // 환자번호 컨트롤 셋팅
            this.mBunhoInfoControls.Add(this.fbxBunho );
            this.mBunhoInfoControls.Add(this.lbSuname );
            this.mBunhoInfoControls.Add(this.lbSuname2);
            this.mBunhoInfoControls.Add(this.lbSexAge );
            this.mBunhoInfoControls.Add(this.lbWeight);
            this.mBunhoInfoControls.Add(this.lbHeight);
            this.mBunhoInfoControls.Add(this.lbGubunName );
            this.mBunhoInfoControls.Add(this.lbChojaeName);

            
                      
            
            // 각종 변수 초기화
            this.mSelectedPatientInfo = new IHIS.OCS.PatientInfo(this.Name);  // 환자정보 

            // SavePerformer Setting 
            this.layDeletedData.SavePerformer = new XSavePeformer(this);
            this.laySaveLayout.SavePerformer = this.layDeletedData.SavePerformer;
            this.grdOutSang.SavePerformer = this.layDeletedData.SavePerformer;

            // 현재 시스템이 ocs인지 여부 확인.
            if (EnvironInfo.CurrSystemID == "OCSO" ||
                EnvironInfo.CurrSystemID == "OCSI" ||
                EnvironInfo.CurrSystemID == "OCSA")
            {
                this.mIsOCSSystem = true;
            }

            this.mIsCheck = true;
            this.OCS1003P00_UserChanged(this, new EventArgs());
            this.mIsCheck = false;

            if (mIsCalledbyOtherScreen)
                this.btnClose.Visible = true;

            this.initScreen();
        }

        private void setSubutton()
        {
            mMenuInputGubunResult.MenuCommands.Clear();
            IHIS.X.Magic.Menus.MenuCommand popUpMenu_InputGubun;

            if (this.mInputGubun == "CK" && !this.mPostApproveYN)
            {
                popUpMenu_InputGubun = new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "代行処方" : "대행처방", (Image)this.ImageList.Images[45], new EventHandler(PopUpMenuInputGubunResult_Click));
                popUpMenu_InputGubun.Tag = "CK";
                mMenuInputGubunResult.MenuCommands.Add(popUpMenu_InputGubun);
            }
            else
            {
                popUpMenu_InputGubun = new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "定期処方" : "정기처방", (Image)this.ImageList.Images[6], new EventHandler(PopUpMenuInputGubunResult_Click));
                popUpMenu_InputGubun.Tag = "D0";
                mMenuInputGubunResult.MenuCommands.Add(popUpMenu_InputGubun);
                popUpMenu_InputGubun = new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "臨時処方" : "임시처방", (Image)this.ImageList.Images[5], new EventHandler(PopUpMenuInputGubunResult_Click));
                popUpMenu_InputGubun.Tag = "D4";
                mMenuInputGubunResult.MenuCommands.Add(popUpMenu_InputGubun);
                popUpMenu_InputGubun = new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "退院時処方" : "퇴원시처방", (Image)this.ImageList.Images[42], new EventHandler(PopUpMenuInputGubunResult_Click));
                popUpMenu_InputGubun.Tag = "D7";
                mMenuInputGubunResult.MenuCommands.Add(popUpMenu_InputGubun);
            }
        }

        private void initScreen()
        {
            this.mPostApproveYN = false;
            this.lblApproveFlag.Text = "事前";

            // 팝업메뉴 초기화
            // 오더 팝업메뉴
            // 처방Grid PopupMenu
            mMenuPFEResult.MenuCommands.Clear();
            IHIS.X.Magic.Menus.MenuCommand popUpMenu;
            popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "内視鏡画像結果" : "화상결과", (Image)this.ImageList.Images[31], new EventHandler(PopUpMenuPfeResult_Click));
            popUpMenu.Tag = "1";
            mMenuPFEResult.MenuCommands.Add(popUpMenu);
            popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "内視鏡レポート照会" : "레포트결과", (Image)this.ImageList.Images[14], new EventHandler(PopUpMenuPfeResult_Click));
            popUpMenu.Tag = "2";
            mMenuPFEResult.MenuCommands.Add(popUpMenu);
            popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "心電図結果" : "심전도결과", (Image)this.ImageList.Images[10], new EventHandler(PopUpMenuPfeResult_Click));
            popUpMenu.Tag = "3";
            mMenuPFEResult.MenuCommands.Add(popUpMenu);

            //mMenuInputGubunResult.MenuCommands.Clear();
            //IHIS.X.Magic.Menus.MenuCommand popUpMenu_InputGubun;

            //if (this.mInputGubun == "CK" && !this.mPostApproveYN)
            //{
            //    popUpMenu_InputGubun = new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "代行処方" : "대행처방", (Image)this.ImageList.Images[45], new EventHandler(PopUpMenuInputGubunResult_Click));
            //    popUpMenu_InputGubun.Tag = "CK";
            //    mMenuInputGubunResult.MenuCommands.Add(popUpMenu_InputGubun);
            //}
            //else
            //{
            //    popUpMenu_InputGubun = new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "定期処方" : "정기처방", (Image)this.ImageList.Images[6], new EventHandler(PopUpMenuInputGubunResult_Click));
            //    popUpMenu_InputGubun.Tag = "D0";
            //    mMenuInputGubunResult.MenuCommands.Add(popUpMenu_InputGubun);
            //    popUpMenu_InputGubun = new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "臨時処方" : "임시처방", (Image)this.ImageList.Images[5], new EventHandler(PopUpMenuInputGubunResult_Click));
            //    popUpMenu_InputGubun.Tag = "D4";
            //    mMenuInputGubunResult.MenuCommands.Add(popUpMenu_InputGubun);
            //    popUpMenu_InputGubun = new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "退院時処方" : "퇴원시처방", (Image)this.ImageList.Images[42], new EventHandler(PopUpMenuInputGubunResult_Click));
            //    popUpMenu_InputGubun.Tag = "D7";
            //    mMenuInputGubunResult.MenuCommands.Add(popUpMenu_InputGubun);
            //}

            mMenuCycleOrderGubun.MenuCommands.Clear();
            IHIS.X.Magic.Menus.MenuCommand popUpMenu_CycleOrderGubun;
            popUpMenu_CycleOrderGubun = new IHIS.X.Magic.Menus.MenuCommand("赤", (Image)this.ImageList.Images[43], new EventHandler(mMenuCycleOrderGubun_Click));
            popUpMenu_CycleOrderGubun.Tag = "P";
            mMenuCycleOrderGubun.MenuCommands.Add(popUpMenu_CycleOrderGubun);
            popUpMenu_CycleOrderGubun = new IHIS.X.Magic.Menus.MenuCommand("緑", (Image)this.ImageList.Images[44], new EventHandler(mMenuCycleOrderGubun_Click));
            popUpMenu_CycleOrderGubun.Tag = "G";
            mMenuCycleOrderGubun.MenuCommands.Add(popUpMenu_CycleOrderGubun);
            popUpMenu_CycleOrderGubun = new IHIS.X.Magic.Menus.MenuCommand("無", (Image)this.ImageList.Images[28], new EventHandler(mMenuCycleOrderGubun_Click));
            popUpMenu_CycleOrderGubun.Tag = "E";
            mMenuCycleOrderGubun.MenuCommands.Add(popUpMenu_CycleOrderGubun);

            this.btnAll.BackColor = Color.Red;

            if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "EMR_POP_YN", this.IO_Gubun) == "Y")
                this.cbxOpenEmr.Checked = true;

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
                //this.cbxMsgSysYN.Visible = false;
            }
        }

        //private void PostOpenEvent()
        //{
        //    this.InitializeScreen(true);
        //}
        private void SetToiwonGojiYNforBtn()
        {
            SingleLayout layToiwonGojiYN = new SingleLayout();
            layToiwonGojiYN.LayoutItems.Add("ToiwonGojiYN");
            layToiwonGojiYN.InitializeLifetimeService();

            layToiwonGojiYN.QuerySQL = @"SELECT NVL(A.TOIWON_GOJI_YN ,'N') TOIWON_GOJI_YN
                                           FROM VW_OCS_INP1001_02 A
                                          WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
                                            AND A.PKINP1001 = :f_pkinp1001";

            layToiwonGojiYN.SetBindVarValue("f_pkinp1001", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            layToiwonGojiYN.QueryLayout();

            ToiwonGojiYN_by_CanSaveFlg = true;

            if (layToiwonGojiYN.GetItemValue("ToiwonGojiYN").ToString() == "Y")
                ToiwonGojiYN_by_CanSaveFlg = false;

//            object layToiwonGojiYN = null;
//            string cmd = @"SELECT NVL(A.TOIWON_GOJI_YN ,'N') TOIWON_GOJI_YN
//                                           FROM VW_OCS_INP1001_02 A
//                                          WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
//                                            AND A.PKINP1001 = :f_pkinp1001";

//            BindVarCollection bindVar = new BindVarCollection();

//            bindVar.Add("f_pkinp1001", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

//            layToiwonGojiYN = Service.ExecuteNonQuery(cmd, bindVar);

//            ToiwonGojiYN_by_CanSaveFlg = true;

//            if (layToiwonGojiYN.ToString() == "Y")
//                ToiwonGojiYN_by_CanSaveFlg = false;
        }
        private void OCS1003P00_UserChanged(object sender, EventArgs e)
        {
            // 일단 전체 클리어 해놓고 
            this.tabInputGubun.SelectionChanged -= new System.EventHandler(this.tabInputGubun_SelectionChanged);
            this.cboQryHodong.SelectedIndexChanged -= new EventHandler(cboQryHodong_SelectedIndexChanged);
            this.cboQryGwa.SelectedValueChanged -= new EventHandler(cboQryGwa_SelectedValueChanged);
            this.cboQryDoctor.SelectedValueChanged -= new EventHandler(cboQryDoctor_SelectedValueChanged);
            
            this.Reset();
            
            this.cboQryHodong.SelectedIndexChanged += new EventHandler(cboQryHodong_SelectedIndexChanged);
            this.cboQryGwa.SelectedValueChanged += new EventHandler(cboQryGwa_SelectedValueChanged);
            this.cboQryDoctor.SelectedValueChanged += new EventHandler(cboQryDoctor_SelectedValueChanged);
            this.tabInputGubun.SelectionChanged += new System.EventHandler(this.tabInputGubun_SelectionChanged);

            // 사용자권한체크
            IsOrderInputUserCheck(true);

            this.InitializeScreen(mIsCheck);

        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        
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
            if (!this.IsPatientSelected()) return;

            if (mSelectedPatientInfo != null && mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                this.OpenScreen_OUTSANGU00(IO_Gubun, this.fbxBunho.GetDataValue(), this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(), this.dtpOrderDate.GetDataValue());

                // 환자상병조회
                this.LoadOutSang(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                , this.dtpOrderDate.GetDataValue()
                                , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());

            }
        }

        // CP환자등록 버튼
        private void btnCPReg_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_OCS6010U00();
        }

        // 진료의뢰 화면 오픈
        private void btnConsult_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            //this.OpenScreen_OCS0503U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
            //                          , this.dtpOrderDate.GetDataValue()
            //                          , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
            //                          , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());
            this.OpenScreen_OCS0503U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                      , this.dtpOrderDate.GetDataValue()
                                      , UserInfo.Gwa
                                      , UserInfo.DoctorID);

        }

        /// <summary>
        /// 바이탈 사인 조회 화면 오픈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVitalSign_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_NUR1020Q00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                      , this.dtpOrderDate.GetDataValue());
        }

        /// <summary>
        /// 치료계획 화면 오픈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChiryoKekaku_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            this.OpenScreen_OCS6010U10();
        }

        /// <summary>
        /// 환자 특기사항
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 퇴원예고
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToiwonRes_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.mOrderBiz.GetNotApproveOrderCnt(IO_Gubun, UserInfo.UserID, "Y", "N", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) > 0)
            {
                if (XMessageBox.Show("現在の患者さんの未承認オーダーが存在します。承認画面にて確認してください。", "確認", MessageBoxButtons.OK, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    this.btnApprove.PerformClick();
                    return;
                }
            }

            this.OpenScreen_OCS2003U99(this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
        }

        /// <summary>
        /// 의사지시서
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintJisi_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;


            OpenScreen_OCS2003R00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                 , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                 , this.mInputGubun
                                 , this.dtpOrderDate.GetDataValue()
                                 , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                 , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                 , false);
        }

        // 오더정보조회
        private void btnQryOrderInfo_Click(object sender, EventArgs e)
        {
            //if (!this.IsPatientSelected()) return;

            this.OpenScreen_OCS1003Q05();
        }

        // DC, 반납화면 오픈
        private void btnDcBannab_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_OCS2003U01();

            this.btnList.PerformClick(FunctionType.Query);
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

                this.mCurrentInputTab = control.Tag.ToString();

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

        private void setVisible_InputGubun(bool OnOff)
        {
            //this.rbtD0.Visible = OnOff;
            //this.rbtD4.Visible = OnOff;
            //this.rbtD7.Visible = OnOff;
        }

        #region [ 각종 오더 입력 버튼 ]

        /// <summary>
        /// 약오더 입력버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrgOrder_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            this.mClickedOrderButton = "10";

            if (this.IsPatientSelected() == false) return;

            //this.setVisible_InputGubun(true);

            //if(this.mDoctorLogin || (this.mInputGubun == "CK" && this.mPostApproveYN))
            //    this.mMenuInputGubunResult.TrackPopup(this.PointToScreen(new Point(this.xPanel5.Width + this.xPanel7.Width + button.Location.X - 115, this.xPanel1.Height + this.xPanel2.Height + button.Location.Y + 5)));
            //else if (this.mInputGubun == "CK" && !this.mPostApproveYN)
            //    this.OpenScreen_OCS0103U10(this.mInputGubun);
            //else
            //    this.mMenuInputGubunResult.TrackPopup(this.PointToScreen(new Point(this.xPanel5.Width + this.xPanel7.Width + button.Location.X - 115, this.xPanel1.Height + this.xPanel2.Height + button.Location.Y + 5)));

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    this.mMenuInputGubunResult.TrackPopup(this.PointToScreen(new Point(this.xPanel5.Width + this.xPanel7.Width + button.Location.X - 115, this.xPanel1.Height + this.xPanel2.Height + button.Location.Y + 5)));
                else
                    this.OpenScreen_OCS0103U10(this.mInputGubun);
            }
            else
            {
                this.mMenuInputGubunResult.TrackPopup(this.PointToScreen(new Point(this.xPanel5.Width + this.xPanel7.Width + button.Location.X - 115, this.xPanel1.Height + this.xPanel2.Height + button.Location.Y + 5)));
            }
        }

        /// <summary>
        /// 주사오더 입력버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJusaOrder_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            this.mClickedOrderButton = "12";

            if (this.IsPatientSelected() == false) return;

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    this.mMenuInputGubunResult.TrackPopup(this.PointToScreen(new Point(this.xPanel5.Width + this.xPanel7.Width + button.Location.X - 115, this.xPanel1.Height + this.xPanel2.Height + button.Location.Y + 5)));
                else
                    this.OpenScreen_OCS0103U12(this.mInputGubun);
            }
            else
            {
                this.mMenuInputGubunResult.TrackPopup(this.PointToScreen(new Point(this.xPanel5.Width + this.xPanel7.Width + button.Location.X - 115, this.xPanel1.Height + this.xPanel2.Height + button.Location.Y + 5)));
            }

               

            //if (this.IsPatientSelected() == false) return;

            //if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            //this.OpenScreen_OCS0103U12();
        }

        /// <summary>
        /// 검체검사 오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCplOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.OpenScreen_OCS0103U13();
        }

        /// <summary>
        /// 생리검사 오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPfeOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.OpenScreen_OCS0103U14();
        }

        /// <summary>
        /// 병리검사 오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAplOrder_Click(object sender, EventArgs e)
        {
            return; // 未使用

            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.OpenScreen_OCS0103U15();
        }

        /// <summary>
        /// 방사선 오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXrtOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.OpenScreen_OCS0103U16();
        }

        /// <summary>
        /// 처치오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChuchiOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.OpenScreen_OCS0103U17();
        }

        /// <summary>
        /// 마취 수술오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSusulOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.OpenScreen_OCS0103U18();
        }

        /// <summary>
        /// 기타 오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEtcOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.OpenScreen_OCS0103U19();
        }

        /// <summary>
        /// 지시사항
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDoctorJisi_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.OpenScreen_OCS2004U00(this.tabInputGubun.SelectedTab.Tag.ToString());

            this.PatientListQuery(this.dtpOrderDate.GetDataValue(), this.cboQryHodong.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());
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

                    if (this.mDoctorLogin)
                        this.DislplayOrderDataWindow(tpg.Tag.ToString(), this.mCurrentInputTab);
                    else
                        this.DislplayOrderDataWindow(tpg.Tag.ToString(), this.mCurrentInputTab);
                }
                else
                {
                    tpg.ImageIndex = 4;
                }
            }

            if (this.mDoctorLogin)
                iInputGubun = this.tabInputGubun.SelectedTab.Tag.ToString();
            else
                iInputGubun = this.mInputGubun;

            this.mOrderBiz.LoadColumnCodeName("code", "INPUT_GUBUN", iInputGubun, ref this.iInputGubunName);
        }

        #endregion

        #region [ 콤보박스 ]

        void cboQryGwa_SelectedValueChanged(object sender, EventArgs e)
        {
            // 닥터콤보 재구성
            this.ReLoadDoctorCombo(this.dtpOrderDate.GetDataValue(), this.cboQryGwa.GetDataValue());

            // 환자리스트 로드 
            this.PatientListQuery(this.dtpOrderDate.GetDataValue(), this.cboQryHodong.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());

        }

        void cboQryDoctor_SelectedValueChanged(object sender, EventArgs e)
        {
            // 환자리스트 로드 
            this.PatientListQuery(this.dtpOrderDate.GetDataValue(), this.cboQryHodong.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());
        }

        #endregion

        #region [ 버튼 리스트 ]

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query: // 조회
                    
                    e.IsBaseCall = false;

                    // 변경된 데이터 체크후 저장
                    if (this.IsOrderDataModifed() == true)
                    {
                        this.btnList.PerformClick(FunctionType.Update);
                    }

                    if (this.cboQryDoctor.GetDataValue() == "")
                        return;

                    // 조회시작
                    if (this.mSelectedPatientInfo == null ||
                        this.mSelectedPatientInfo.GetPatientInfo == null ||
                        this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != this.fbxBunho.GetDataValue())
                    {
                        return ;
                    }

                    // 이전 오더 데이터 초기화
                    this.ClearOrderData();

                    // 대기환자
                    this.PatientListQuery(this.dtpOrderDate.GetDataValue(), this.cboQryHodong.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());

                    // 환자상병조회
                    this.LoadOutSang(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                    ,this.dtpOrderDate.GetDataValue()
                                    //,this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());
                                    , "%");
                    
                    //診療科のコンボボックス作成
                    if (this.cboOutSang.GetDataValue().ToString() != "")
                    {
                        this.MakeJinryoGwa();
                    }

                    // 오더조회
                    if (this.mDoctorLogin)
                    {
                        this.LoadOutOrder(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                         , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                         , (this.mDoctorLogin == true ? "D" : "N")
                                         , this.mInputGubun
                                         , this.dtpOrderDate.GetDataValue());
                    }
                    else
                    {
                        this.LoadOutOrder(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                         , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                         , (this.mDoctorLogin == true ? "D" : "N")
                                         , this.mInputGubun
                                         , this.dtpOrderDate.GetDataValue());
                    }

                    

                    // 오더 조회후 화면 Display
                    this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);

                    break;

                //case FunctionType.Insert: // 상병입력

                //    e.IsBaseCall = false;

                //    this.AcceptData();

                //    if (this.SangInputCheck(ref this.mMsg) == false)
                //    {
                //        MessageBox.Show(this.mMsg, XMsg.GetMsg("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }

                //    int newRow = -1;
                //    // 상병 로우 생성 
                //    newRow = this.grdOutSang.InsertRow();

                //    // 상병 로우의 초기화
                //    this.InitializeSangGrid(this.grdOutSang, this.mSelectedPatientInfo, newRow);

                //    break;

                case FunctionType.Update: // 저장

                    e.IsBaseCall = false;

                    if (!this.IsPatientSelected()) return;

                    if (!this.AcceptData()) return;

                    // 저장시작
                    // 1. 각각의 레이아웃을 저장 레이아웃으로 merge 한다.
                    // 2. 저장전 체크 사항을 체크한다.
                    // 3. 저장시작
                    //    3-1. Delete 항목에 대하여 저장을 한다. ( 에러시 이후 진행 불가 )
                    //    3-2. Update 항목에 대하여 저장을 한다. 

                    this.mInsertedOrderCnt = 0;
                    this.mUpdatedOrderCnt = 0;
                    this.mDeletedOrderCnt = 0;

                    this.mInsteadInsertedOrderCnt = 0;
                    this.mInsteadUpdatedOrderCnt = 0;
                    this.mInsteadDeletedOrderCnt = 0;

                    if (this.MergeToSaveLayout() == false) return;

                    //退院予約されてオーダ終了されたのかチェックしてオーダ終了されているなら保存できなくする。
                    if (!this.ToiwonGojiYN_by_CanSaveFlg) 
                    {
                        MessageBox.Show(XMsg.GetMsg("M008"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } 

                    if (this.OrderValidationCheck() == false) return;

                    //20130322 MX Interface　未定

                    //this.mInterface.MakeIFDataLayout("I", this.layDeletedData.LayoutTable, true, false, true);

                    //this.mInterface.MakeIFDataLayout("I", this.laySaveLayout.LayoutTable, false, true, false);

                    //this.mInterface.MakeIFDataLayout("I", this.laySaveLayout.LayoutTable, false, false, false);
                    
                    this.mOrderFunc.DeleteEmptyNewRow(this.grdOutSang);

                    

                    // 트랜잭션 시작
                    try
                    {
                        Service.BeginTransaction();

                        //傷病チェック
                        if (this.grdOutSang.RowCount <= 0)
                        {
                            if (MessageBox.Show("現在登録されている傷病がありません。このまま確定しますか？？\n確定[はい(Y)]、確定キャンセル[いいえ(N)]", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            {
                                this.btnListSB.Focus();
                                this.btnListSB.PerformClick(FunctionType.Insert);
                                return;
                            }
                        }

                        if (this.grdOutSang.SaveLayout() == false)
                        {
                            Service.RollbackTransaction(); // 롤백

                            //this.mMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...
                            this.mMsg = XMsg.GetMsg("M005") + "\r\n" + Service.ErrMsg;

                            MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;
                        }

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
                                    XMessageBox.Show("既に承認したオーダーです。削除できません。", "確認");
                                    return;
                                }
                            }

                            this.layDeletedData.SetItemValue(i, "dummy", "mageshin");
                        }

                        if (this.layDeletedData.SaveLayout() == false)
                        {
                            Service.RollbackTransaction(); // 롤백

                            //this.mMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...
                            this.mMsg = XMsg.GetMsg("M005") + "\r\n" + Service.ErrMsg;

                            MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;
                        }

                        //20130322 MX Interface　未定
                        //if (this.mInterface.InsertDeletedDataToTempTable() == false)
                        //{
                        //}

                        // insert by jc [OCS2003のSYSDATEを統一化させるために] START
                        string cmd = " SELECT TO_CHAR(SYSDATE, 'YYYY/MM/DD HH24:MI:SS') FROM SYS.DUAL ";

                        object value = Service.ExecuteScalar(cmd);

                        if (value != null &&
                            TypeCheck.IsDateTime(value.ToString()))
                            mSave_time = value.ToString();
                        // insert by jc END

                        if (this.laySaveLayout.SaveLayout() == false)
                        {
                            Service.RollbackTransaction();  // 롤백

                            //this.mMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...
                            this.mMsg = XMsg.GetMsg("M005") + "\r\n" + Service.ErrMsg;

                            MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;
                        }
                        else
                        {
                            // 저장이 완료된 후에 NDAY 건을 처리하기 위하여 NDAY OCCUR YN 프로시져를 호출한다.
                            string procName = "PR_OCS_APPLY_NDAY_ORDER";
                            ArrayList inList = new ArrayList();
                            ArrayList outList = new ArrayList();

                            inList.Add(this.fbxBunho.GetDataValue());
                            inList.Add(this.dtpOrderDate.GetDataValue());

                            if (Service.ExecuteProcedure(procName, inList, outList) == false)
                            {
                                Service.RollbackTransaction();  // 롤백

                                this.mMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                                MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }
                            else
                            {
                                if (outList[0].ToString() != "0")
                                {
                                    Service.RollbackTransaction();  // 롤백

                                    this.mMsg = XMsg.GetMsg("M005") + " - " + outList[0].ToString();  // 저장에 실패하였습니다 + 에러메세지...

                                    MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    return;
                                }
                            }
                        }
                    }
                    catch(Exception ee)
                    {
                        XMessageBox.Show(ee.Message);
                        Service.RollbackTransaction();

                        this.mInsertedOrderCnt = 0;
                        this.mUpdatedOrderCnt = 0;
                        this.mDeletedOrderCnt = 0;

                        this.mInsteadInsertedOrderCnt = 0;
                        this.mInsteadUpdatedOrderCnt = 0;
                        this.mInsteadDeletedOrderCnt = 0;
                    }

                    Service.CommitTransaction();  // 커밋

                    string MsgSysMSG = "";
                    string MsgTitle = "";

                    

                    //public void SendMessageSystem(string aTitle, string aRow1, string aRow2, string aRow3, string aRow4, string aRow5, string aComment, string aSenderID, string aReciverGubun, string aReciverID)

                    if (this.mDoctorLogin)
                    {
                        if (this.mInsertedOrderCnt > 0)
                        {
                            MsgSysMSG += "追加 : " + this.mInsertedOrderCnt + "件\r\n";
                            MsgTitle += "[追加]";
                        }
                        if (this.mUpdatedOrderCnt > 0)
                        {
                            MsgSysMSG += "変更 : " + this.mUpdatedOrderCnt + "件\r\n";
                            MsgTitle += "[変更]";
                        }
                        if (this.mDeletedOrderCnt > 0)
                        {
                            MsgSysMSG += "削除 : " + this.mDeletedOrderCnt + "件\r\n";
                            MsgTitle += "[削除]";
                        }

                        if (this.cbxMsgSysYN.Checked == true)
                        {
                            if (MsgSysMSG != "")
                            {
                                // 看護師
                                this.mOrderBiz.SendMessageSystem(MsgTitle + " オーダー更新お知らせ(臨時、退院処方のみ)"
                                                     , "患者番号 : " + this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                     , "患者氏名 : " + this.mSelectedPatientInfo.GetPatientInfo["suname"].ToString()
                                                     , "患者病室 : " + this.mSelectedPatientInfo.GetPatientInfo["ho_dong"].ToString() + " " + this.mSelectedPatientInfo.GetPatientInfo["ho_code"].ToString() + "号室"
                                                     , ""
                                                     , ""
                                                     , MsgSysMSG
                                                     , UserInfo.UserID
                                                     , "G"
                                                     , this.mPatientHoDongCode
                                                     , "看護グループ"
                                                        );
                                // 薬局
                                this.mOrderBiz.SendMessageSystem(MsgTitle + "オーダー更新お知らせ(臨時、退院処方のみ)"
                                                     , "患者番号 : " + this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                     , "患者氏名 : " + this.mSelectedPatientInfo.GetPatientInfo["suname"].ToString()
                                                     , "患者病室 : " + this.mSelectedPatientInfo.GetPatientInfo["ho_dong"].ToString() + " " + this.mSelectedPatientInfo.GetPatientInfo["ho_code"].ToString() + "号室"
                                                     , ""
                                                     , ""
                                                     , MsgSysMSG
                                                     , UserInfo.UserID
                                                     , "G"
                                                     , this.mDrgGwaCode
                                                     , "薬局"
                                                        );
                            }
                        }
                    }
                    else if (UserInfo.Gwa == "CK")
                    {
                        if (this.mInsteadInsertedOrderCnt > 0)
                        {
                            MsgSysMSG += "追加 : " + this.mInsteadInsertedOrderCnt + "件\r\n";
                            MsgTitle += "[追加]";
                        }
                        if (this.mInsteadUpdatedOrderCnt > 0)
                        {
                            MsgSysMSG += "変更 : " + this.mInsteadUpdatedOrderCnt + "件\r\n";
                            MsgTitle += "[変更]";
                        }
                        if (this.mInsteadDeletedOrderCnt > 0)
                        {
                            MsgSysMSG += "削除 : " + this.mInsteadDeletedOrderCnt + "件\r\n";
                            MsgTitle += "[削除]";
                        }

                        if (this.cbxMsgSysYN.Checked == true)
                        {
                            if (MsgSysMSG != "")
                            {
                                // 承認医師へ
                                this.mOrderBiz.SendMessageSystem(MsgTitle + " 代行オーダー更新のお知らせ"
                                                     , "患者番号 : " + this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                     , "患者氏名 : " + this.mSelectedPatientInfo.GetPatientInfo["suname"].ToString()
                                                     , "患者病室 : " + this.mSelectedPatientInfo.GetPatientInfo["ho_dong"].ToString() + " " + this.mSelectedPatientInfo.GetPatientInfo["ho_code"].ToString() + "号室"
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
                    //20130322 MX Interface　未定
                    // 삭제는 삭제전 먼저 태워야 한다.
                    //if (this.mInterface.SendData(true, false) == false)
                    //{
                    //    // 메세지 처리.
                    //}

                    //// 업데이트 
                    //if (this.mInterface.SendData(false, true) == false)
                    //{
                    //}

                    //if (this.mInterface.SendData(false, false) == false)
                    //{
                    //    // 메세지 처리.
                    //}

                    #region 방사선 조사록 출력

                    // XRT방사선 조사록 출력
                    //string currentJundalPart = "XX";
                    //Hashtable printYn = new Hashtable();
                    //foreach (DataRow dr in this.layXrtOrder.LayoutTable.Rows)
                    //{
                    //    //inser by jc 希望日が変更された場合、再印刷されるように変更。
                    //    //if (dr.RowState == DataRowState.Added &&
                    //    if(dr.RowState != DataRowState.Unchanged &&
                    //        ( dr["jundal_part"].ToString() == "CR" ||
                    //          dr["jundal_part"].ToString() == "CT" ||
                    //          dr["jundal_part"].ToString() == "DR") &&
                    //        dr["jundal_part"].ToString() != currentJundalPart)
                    //    {
                    //        if (printYn.Contains(dr["jundal_part"].ToString()) == false)
                    //        {
                    //            this.PrintXRTJosa(dr);
                    //            currentJundalPart = dr["jundal_part"].ToString();
                    //            printYn.Add(dr["jundal_part"].ToString(), "Y");
                    //        }
                    //    }
                    //}

                    //// 삭제된 내용중 방사선 관련 내용이 있는지 확인
                    //foreach (DataRow dr in this.layDeletedData.LayoutTable.Rows)
                    //{
                    //    if (dr["jundal_part"].ToString() == "CR" ||
                    //        dr["jundal_part"].ToString() == "CT" ||
                    //        dr["jundal_part"].ToString() == "DR")
                    //    {
                    //        if (printYn.Contains(dr["jundal_part"].ToString()) == false)
                    //        {
                    //            if (this.layXrtOrder.LayoutTable.Select("jundal_part='" + dr["jundal_part"].ToString() + "'").Length > 0)
                    //            {
                    //                this.PrintXRTJosa(dr);
                    //                printYn.Add(dr["jundal_part"].ToString(), "Y");
                    //            }
                    //        }
                    //    }
                    //}

                    #endregion
                    /*
                    #region 검체검사 출력 리스트 작성

                    Hashtable cplInfo;
                    this.mCplPrintList.Clear();

                    foreach (DataRow cplRow in this.layCplOrder.LayoutTable.Rows)
                    {
                        if (cplRow.RowState != DataRowState.Unchanged &&
                            cplRow["slip_code"].ToString() == "B000")
                        {
                            cplInfo = new Hashtable();
                            cplInfo.Add("group_ser", cplRow["group_ser"].ToString());
                            cplInfo.Add("hangmog_code", cplRow["hangmog_code"].ToString());
                            cplInfo.Add("specimen_code", cplRow["specimen_code"].ToString());
                            cplInfo.Add("emergency", cplRow["emergency"].ToString());

                            this.mCplPrintList.Add(cplInfo);
                        }
                    }

                    #endregion
                    */
                    #region 검체검사 출력 리스트 작성

                    //Hashtable cplInfo;
                    //this.mCplPrintList.Clear();
                    //ArrayList specimen_list = new ArrayList();

                    //foreach (DataRow cplRow in this.layCplOrder.LayoutTable.Rows)
                    //{
                    //    if (cplRow.RowState != DataRowState.Unchanged &&
                    //        cplRow["slip_code"].ToString() == "B000")
                    //    {
                    //        cplInfo = new Hashtable();
                    //        cplInfo.Add("group_ser", cplRow["group_ser"].ToString());
                    //        cplInfo.Add("hangmog_code", cplRow["hangmog_code"].ToString());
                    //        cplInfo.Add("specimen_code", cplRow["specimen_code"].ToString());
                    //        cplInfo.Add("emergency", cplRow["emergency"].ToString());

                    //        if (specimen_list.Contains(cplRow["specimen_code"].ToString()) == false)
                    //        {
                    //            this.mCplPrintList.Add(cplInfo);
                    //            specimen_list.Add(cplRow["specimen_code"].ToString());
                    //        }

                    //    }
                    //}

                    #endregion
                    
                    /*
                    #region [ 검체검사 출력 시작 ]
                    // 출력 시작
                    ArrayList printedIdx = new ArrayList();
                    foreach (DataRow printRow in this.layCplOrder.LayoutTable.Rows)
                    {
                        for (int i = 0; i < this.mCplPrintList.Count; i++)
                        {
                            cplInfo = this.mCplPrintList[i] as Hashtable;

                            if (printRow["group_ser"].ToString() == cplInfo["group_ser"].ToString() &&
                                printRow["hangmog_code"].ToString() == cplInfo["hangmog_code"].ToString() &&
                                printRow["specimen_code"].ToString() == cplInfo["specimen_code"].ToString() &&
                                printRow["emergency"].ToString() == cplInfo["emergency"].ToString())
                            {
                                if (printedIdx.Contains(i) == false)
                                {
                                    this.OpenScreen_CPL2010R02(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                              , this.dtpOrderDate.GetDataValue()
                                                              , this.IO_Gubun
                                                              , printRow["pkocskey"].ToString());
                                    printedIdx.Add(i);
                                }
                            }
                        }
                    }

                    #endregion
                    */
                    #region [ 검체검사 출력 시작 ]
                    // 출력 시작
                    //ArrayList specimen_list2 = new ArrayList();
                    //ArrayList printedIdx = new ArrayList();
                    //foreach (DataRow printRow in this.layCplOrder.LayoutTable.Rows)
                    //{
                    //    for (int i = 0; i < this.mCplPrintList.Count; i++)
                    //    {
                    //        cplInfo = this.mCplPrintList[i] as Hashtable;

                    //        if (printRow["group_ser"].ToString() == cplInfo["group_ser"].ToString() &&
                    //            printRow["hangmog_code"].ToString() == cplInfo["hangmog_code"].ToString() &&
                    //            printRow["specimen_code"].ToString() == cplInfo["specimen_code"].ToString() &&
                    //            printRow["emergency"].ToString() == cplInfo["emergency"].ToString())
                    //        {

                    //            if (specimen_list2.Contains(cplInfo["specimen_code"].ToString()) == false)
                    //            {

                    //                if (printedIdx.Contains(i) == false)
                    //                {
                    //                    this.OpenScreen_CPL2010R02(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                    //                                              , this.dtpOrderDate.GetDataValue()
                    //                                              , this.IO_Gubun
                    //                                              , this.cboQryGwa.GetDataValue()
                    //                                              , this.cboQryDoctor.GetDataValue()
                    //                                              , cplInfo["specimen_code"].ToString()
                    //                                              , "Y");

                    //                    printedIdx.Add(i);
                    //                }
                    //                specimen_list2.Add(cplInfo["specimen_code"].ToString());
                    //            }
                    //        }
                    //    }
                    //}

                    #endregion

                    #region リハビリ依頼書出力

                    Hashtable printYn = new Hashtable();
                    foreach (DataRow dr in this.layRehaOrder.LayoutTable.Rows)
                    {
                        //inser by jc 希望日が追加された場合、再印刷されるように変更。（修正された分はPHY8002画面にて出力）
                        if ((dr.RowState == DataRowState.Added) &&
                            (dr["jundal_part"].ToString() == "HOM" && (dr["specific_comment"].ToString() == "18" || dr["specific_comment"].ToString() == "19")))
                        {
                            this.PrintRehaIraisyo(dr);
                            printYn.Add(dr["pkocskey"].ToString(), "Y");
                        }
                    }

                    #endregion

                    this.ClearOrderData();

                    this.btnList.PerformClick(FunctionType.Query);

                    break;

                case FunctionType.Process: //患者選択解除する。
                    // 이전데이터 저장여부
                    if (this.IsOrderDataModifed() == true)
                    {
                        // 저장안된 데이터 있다. 저장한다.
                        // 저장여부는 내부에서 판단.
                        this.btnList.PerformClick(FunctionType.Update);
                    }
                    this.InitializeBunho(false);
                    this.AcceptData();
                    break;
            }
        }

        #endregion


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
                        XMessageBox.Show("傷病コードを変えることはできません。修正の場合は削除後追加してください。", "確認");
                        return;
                    }

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
                                    sang_code, grd.GetItemString(e.RowNumber, "display_sang_name"), this.dtpOrderDate.GetDataValue(), IO_Gubun,
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

                        ///MessageBox.Show("END Valid");

                    }

                    break;
                case "sang_start_date":

                    #region 発症日

                    //発症日は診断日より同じ及び過去である。
                    if (int.Parse(grd.GetItemString(e.RowNumber, "sang_start_date").Replace("/", "")) > int.Parse(grd.GetItemString(e.RowNumber, "sang_jindan_date").Replace("/", "")))
                    {
                        XMessageBox.Show("発症日が間違っています。もう一度ご確認ください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                        return;
                    }

                    #endregion

                    break;
                case "sang_jindan_date":

                    #region 診断日

                    //発症日は診断日より同じ及び過去である。
                    if (int.Parse(grd.GetItemString(e.RowNumber, "sang_start_date").Replace("/", "")) > int.Parse(grd.GetItemString(e.RowNumber, "sang_jindan_date").Replace("/", "")))
                    {
                        XMessageBox.Show("診断日が間違っています。もう一度ご確認ください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                        return;
                    }

                    #endregion

                    break;
                case "sang_end_date":

                    #region 終了日

                    //発症日は診断日より同じ及び過去である。
                    if (int.Parse(grd.GetItemString(e.RowNumber, "sang_start_date").Replace("/", "")) > int.Parse(grd.GetItemString(e.RowNumber, "sang_end_date").Replace("/", ""))
                        || int.Parse(grd.GetItemString(e.RowNumber, "sang_jindan_date").Replace("/", "")) > int.Parse(grd.GetItemString(e.RowNumber, "sang_end_date").Replace("/", "")))
                    {
                        XMessageBox.Show("終了日が間違っています。もう一度ご確認ください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                        return;
                    }

                    if (e.ChangeValue.ToString() == "")
                    {
                        grd.SetItemValue(e.RowNumber, "sang_end_sayu", "");
                        return;
                    }

                    #endregion

                    break;
                case "gwa":
                    string cmd = @"SELECT FN_BAS_LOAD_GWA_NAME('" + e.ChangeValue.ToString() + "', '" + this.dtpOrderDate.GetDataValue() + "') FROM SYS.DUAL";

                    object obj = Service.ExecuteScalar(cmd);

                    this.grdOutSang.SetItemValue(e.RowNumber, "gwa_name", obj.ToString());
                    break;
                case "display_sang_name": // Display 상병명
                    
                    #region sang_codeがない時、傷病をワープロで入力されたら自動で0000999が入るように

                    ClearSangName(grdOutSang, e.RowNumber);
                    grdOutSang.SetItemValue(e.RowNumber, "sang_code", OCS.OrderVariables.WORD_SANG_CODE);
                    grdOutSang.SetItemValue(e.RowNumber, "sang_name", e.ChangeValue);
                    break;
                    
                    #endregion
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
            int rowNumber = -1;

            rowNumber = grid.GetHitRowNumber(e.Y);

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (rowNumber < 0)
                {
                    return;
                }

                if (grid.CurrentColName == "doubt")
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

                        this.mParamNaewonKey = this.grdPatientList.GetItemString(rowNumber, "pk_naewon");

                        //同名二人CHECK2013/08/23

                        if (IsSameNameCHK() == true)
                        {
                            if (MessageBox.Show("同じ名字又は名前の患者さんが入院されています。\n[漢字名：" + this.grdPatientList.GetItemString(rowNumber, "suname") + "], \n[カナ名："
                                                                                          + this.grdPatientList.GetItemString(rowNumber, "suname2") + "], \n[年齢："
                                                                                          + this.grdPatientList.GetItemString(rowNumber, "age") + "], \n[病室："
                                                                                          + this.grdPatientList.GetItemString(rowNumber, "ho_dong_name") + " " + this.grdPatientList.GetItemString(rowNumber, "ho_code") + "号室] \n"
                                                                                          + "\nこの患者さんでよろしいでしょうか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                return;
                        }

                        if (this.mDoctorLogin)
                        {
                            if (this.IsCommonDoctorConsult(rowNumber))
                            {
                                this.ProcessCommonDoctorRequest(rowNumber);
                            }
                        }

                        this.fbxBunho.SetEditValue(this.grdPatientList.GetItemString(rowNumber, "bunho"));
                        this.fbxBunho.AcceptData();
                    }
                    finally
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                    }
                    
                }
            }
            else if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                this.grdPatientList.UnSelectAll();
                this.grdPatientList.SelectRow(this.grdPatientList.GetHitRowNumber(e.Y));
                this.mMenuCycleOrderGubun.TrackPopup(this.PointToScreen(new Point(e.X+5, e.Y+this.grdPatientList.Location.Y)));
            }
        }

        private void grdPatientList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            if (grid.GetItemString(e.RowNumber, "reser_yn") == "Y")
            {
                e.BackColor = Color.LightBlue;
            }

            if (grid.GetItemString(e.RowNumber, "consult_gubun") == "Y")
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
            if (e.DataRow["doctor"].ToString().Substring(2) == UserInfo.UserID)
                e.Font = new Font("MS UI Gothic", (float)9.75, FontStyle.Bold);

            if (e.ColName == "ho_code_name" && e.DataRow["cycle_order_group"].ToString() != "")
            {
                switch (e.DataRow["cycle_order_group"].ToString())
                {
                    case "P":
                        e.BackColor = Color.Pink;
                        break;
                    case "G":
                        e.BackColor = Color.LightGreen;
                        break;
                }
            }

            if (this.patientListdisplayedcount != this.grdPatientList.DisplayRowCount)
            {
                SetPatientListImage(grid);
                this.patientListdisplayedcount = this.grdPatientList.DisplayRowCount;
            }
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
        private bool PatientListQuery(string aNaewonDate, string aHodong, string aGwa, string aDoctor)
        {
            string prevKey = "";

            int approve_cnt = this.mOrderBiz.GetNotApproveOrderCnt(this.IO_Gubun, UserInfo.UserID, "Y", "N", "%");

            this.btnApprove.Text = "承認待ちオーダー(" + approve_cnt + "件)";

            if (approve_cnt > 0)
                this.pbxApprove.Visible = true;
            else
                this.pbxApprove.Visible = false;
             

            if (this.grdPatientList.RowCount > 0 && this.grdPatientList.CurrentRowNumber >= 0)
            {
                prevKey = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "pk_naewon");
            }

            this.grdPatientList.SetBindVarValue("f_input_gubun", this.mInputGubun);

            this.grdPatientList.SetBindVarValue("f_ho_dong", aHodong);

            if(aDoctor == "")
                this.grdPatientList.SetBindVarValue("f_doctor", "%");
            else
                this.grdPatientList.SetBindVarValue("f_doctor", aDoctor);

            if(this.mDoctorLogin)
                this.grdPatientList.SetBindVarValue("f_approve_doctor", aDoctor);
            else if(UserInfo.Gwa == "CK")
                this.grdPatientList.SetBindVarValue("f_approve_doctor", TypeCheck.NVL(this.cboQryAppDoctor.GetDataValue().Substring(2), aDoctor).ToString());
            else
                this.grdPatientList.SetBindVarValue("f_approve_doctor", aDoctor);

            this.grdPatientList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            this.grdPatientList.SetBindVarValue("f_bunho", "%");

            this.grdPatientList.SetBindVarValue("f_order_date", this.dtpOrderDate.GetDataValue());

            this.grdPatientList.SetBindVarValue("f_gwa", aGwa);

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
        private void ReLoadHodongCombo(string aNaewonDate)
        {
            //this.cboQryHodong.SelectedValueChanged -= new EventHandler(cboQryGwa_SelectedValueChanged);
            string aCurrentHodong = this.cboQryHodong.GetDataValue();
            DataTable dt = this.mOrderBiz.LoadComboDataSource("ho_dong", aNaewonDate).LayoutTable;
            DataTable temp = new DataTable();
            DataRow dr;

            temp.Columns.Add("code");
            temp.Columns.Add("code_name");

            if (dt.Rows.Count > 0)
            {
                dr = temp.NewRow();
                dr["code"] = "%";
                dr["code_name"] = "全体";
                temp.Rows.Add(dr);
            }
            foreach ( DataRow row in dt.Rows)
            {
                temp.ImportRow(row);
            }


            this.cboQryHodong.SetComboItems(temp, "code_name", "code");

            if (mDoctorLogin == true)
            {
                this.cboQryHodong.SetDataValue("%");
            }
            else
            {

                if (aCurrentHodong != "" && this.cboQryHodong.ComboItems.Contains(aCurrentHodong))
                {
                    this.cboQryHodong.SetDataValue(aCurrentHodong);
                }
                else
                {
                    if (UserInfo.UserGubun == UserType.Nurse)
                    {
                        this.cboQryHodong.SetDataValue(UserInfo.HoDong);
                    }
                    else
                    {
                        this.cboQryHodong.SelectedIndex = 0;
                    }
                }
            }

            //this.cboQryHodong.SelectedValueChanged += new EventHandler(cboQryGwa_SelectedValueChanged);
        }

        private void ReLoadGwaCombo(string aNaewonDate)
        {
            this.cboQryGwa.SelectedValueChanged -= new EventHandler(cboQryGwa_SelectedValueChanged);
            string aCurrentGwa = this.cboQryGwa.GetDataValue();
            DataTable dt = this.mOrderBiz.LoadComboDataSource("gwa", aNaewonDate).LayoutTable;

            this.cboQryGwa.SetComboItems(dt, "code_name", "code");

            if (mDoctorLogin == true)
            {
                this.cboQryGwa.SetDataValue(UserInfo.Gwa);
            }
            else
            {

                if (aCurrentGwa != "" && this.cboQryGwa.ComboItems.Contains(aCurrentGwa))
                {
                    this.cboQryGwa.SetDataValue(aCurrentGwa);
                }
                else
                {
                    if (this.mInputGwa != "" && this.cboQryHodong.ComboItems.Contains(this.mInputGwa))
                    {
                        this.cboQryGwa.SetDataValue(this.mInputGwa);
                    }
                    else
                    {
                        this.cboQryGwa.SelectedIndex = 0;
                    }
                }
            }

            if (!this.mDoctorLogin)
            {
                this.cboQryAppGwa.SetComboItems(dt, "code_name", "code");

                if (aCurrentGwa != "" && this.cboQryAppGwa.ComboItems.Contains(aCurrentGwa))
                {
                    this.cboQryAppGwa.SetDataValue(aCurrentGwa);
                }
                else
                {
                    if (this.mInputGwa != "" && this.cboQryHodong.ComboItems.Contains(this.mInputGwa))
                    {
                        this.cboQryAppGwa.SetDataValue(this.mInputGwa);
                    }
                    else
                    {
                        this.cboQryAppGwa.SelectedIndex = 0;
                    }
                }
            }

            //if (this.mDoctorLogin == false)
            //{
            //    if (UserInfo.UserGubun == UserType.Doctor && this.cboQryGwa.ComboItems.Contains(UserInfo.Gwa))
            //    {
            //        this.cboQryGwa.SetDataValue(UserInfo.Gwa);
            //    }
            //}

            this.cboQryGwa.SelectedValueChanged += new EventHandler(cboQryGwa_SelectedValueChanged);
        }

        private void MakeJinryoGwa()
        {
            //insert by jc [診療科のコンボボックス追加]　START
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
					                 
                                     SELECT '%' as GWA, '全体' as GWA_NAME 
                                       FROM SYS.DUAL
					                  ORDER BY GWA";

            layJinryoGwa.QueryLayout(false);

            this.MakeJinryoGwaCombo(layJinryoGwa);
            //insert by jc [診療科のコンボボックス追加]　END
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
        /// 조회용 주치의 콤보 재구성
        /// </summary>
        /// <param name="aNaewonDate">내원일자</param>
        /// <param name="aGwa">진료과</param>
        private void ReLoadDoctorCombo(string aNaewonDate, string aGwa)
        {
            this.cboQryDoctor.SelectedValueChanged -= new EventHandler(cboQryDoctor_SelectedValueChanged);
            string aCurrentDoctor = this.cboQryDoctor.GetDataValue();
            DataTable dt = this.mOrderBiz.LoadComboDataSource("doctor_all", aNaewonDate, aGwa).LayoutTable;

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

            //if (this.mDoctorLogin == false)
            //{
            //    if (UserInfo.UserGubun == UserType.Doctor && this.cboQryDoctor.ComboItems.Contains(UserInfo.DoctorID))
            //    {
            //        this.cboQryDoctor.SetDataValue(UserInfo.DoctorID);
            //    }
            //}

            this.cboQryDoctor.SelectedValueChanged += new EventHandler(cboQryDoctor_SelectedValueChanged);
        }

        private void ReLoadAppDoctorCombo(string aNaewonDate, string aGwa)
        {
            this.cboQryAppDoctor.SelectedIndexChanged -= new EventHandler(cboQryAppDoctor_SelectedIndexChanged);
            string aCurrentDoctor = this.cboQryAppDoctor.GetDataValue();
            DataTable dt = this.mOrderBiz.LoadComboDataSource("doctor", aNaewonDate, aGwa).LayoutTable;

            this.cboQryAppDoctor.SetComboItems(dt, "code_name", "code");

            if (this.mDoctorLogin == true)
            {
                this.cboQryAppDoctor.SetDataValue(UserInfo.DoctorID);
            }
            else
            {
                if (aCurrentDoctor != "" && this.cboQryAppDoctor.ComboItems.Contains(aCurrentDoctor))
                {
                    this.cboQryAppDoctor.SetDataValue(aCurrentDoctor);
                }
                else
                {
                    this.cboQryAppDoctor.SelectedIndex = 0;
                }
            }

            //if (this.mDoctorLogin == false)
            //{
            //    if (UserInfo.UserGubun == UserType.Doctor && this.cboQryDoctor.ComboItems.Contains(UserInfo.DoctorID))
            //    {
            //        this.cboQryDoctor.SetDataValue(UserInfo.DoctorID);
            //    }
            //}

            this.cboQryAppDoctor.SelectedIndexChanged += new EventHandler(cboQryAppDoctor_SelectedIndexChanged);

            this.lblApproveDoctorName.Text = "⇒ " + this.cboQryAppDoctor.ComboItems[this.cboQryAppDoctor.SelectedIndex].DisplayItem;
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
            this.grdOutSang.SetBindVarValue("f_bunho"      , aBunho);
            this.grdOutSang.SetBindVarValue("f_naewon_date", aNaewonDate);
            this.grdOutSang.SetBindVarValue("f_gwa"        , aGwa);
            this.grdOutSang.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            //insert by jc [今回の入院件の傷病のみ] 2012/10/26
            //modify by jc [入院ごと管理せず患者別傷病管理] 2013/02/24
            //this.grdOutSang.SetBindVarValue("f_fkinp1001", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            this.grdOutSang.QueryLayout(true);

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

        private bool LoadOutOrder(string aBunho, string aFkINP1001, string aQueryGubun, string aInputGubun, string aOrderDate)
        {
            this.layQueryLayout.SetBindVarValue("f_bunho", aBunho);
            this.layQueryLayout.SetBindVarValue("f_fkinp1001", aFkINP1001);
            this.layQueryLayout.SetBindVarValue("f_query_gubun", aQueryGubun);
            this.layQueryLayout.SetBindVarValue("f_input_gubun", aInputGubun);
            this.layQueryLayout.SetBindVarValue("f_order_date", aOrderDate);
            this.layQueryLayout.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            if (UserInfo.UserGubun == UserType.Doctor)
                this.layQueryLayout.SetBindVarValue("f_input_doctor", UserInfo.DoctorID);
            else
                this.layQueryLayout.SetBindVarValue("f_input_doctor", UserInfo.UserID);
            

            this.layQueryLayout.QueryLayout(true);

            // 중간 레이아웃 초기화
            this.layDrugOrder.Reset();
            this.layJusaOrder.Reset();
            this.layCplOrder.Reset();
            this.layPfeOrder.Reset();
            this.layAplOrder.Reset();
            this.layXrtOrder.Reset();
            this.layChuchiOrder.Reset();
            this.laySusulOrder.Reset();
            this.layEtcOrder.Reset();
            // リハビリ追加 [照会したオーダを各おーたごとに分配] 2012/11/22 
            this.layRehaOrder.Reset();
            this.layDeletedData.Reset();
            this.laySaveLayout.Reset();

            this.mInsertedOrderCnt = 0;
            this.mUpdatedOrderCnt = 0;
            this.mDeletedOrderCnt = 0;

            this.ClearInputGubunColor();

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

                    case "09": // 마취 수술오더 

                        this.laySusulOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "10": // リハビリ

                        this.layRehaOrder.LayoutTable.ImportRow(dr);

                        break;


                    case "11": // 기타 오더

                        this.layEtcOrder.LayoutTable.ImportRow(dr);

                        break;
                }                
            }

            this.LoadDoOrder_Grid();

            this.tabInputGubun.Refresh();

            return true;
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        #region [ 비지니스 로직들... ]

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

            this.SetPatientListImage(this.grdPatientList);
        }

        /// <summary>
        /// 환자별로 Visible 셋팅될것들...
        /// </summary>
        private void SettingVisiblebyUser()
        {

            this.btnList.FunctionItems.Clear();
            this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Query, Shortcut.None, "照 会", -1, ""));
            this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Update, Shortcut.None, "確 定", -1, ""));

            if (UserInfo.Gwa != "CK")
                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Process, Shortcut.None, "診療終了", -1, "OliveGreen"));

            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.Location = new Point(this.Parent.Width - 370, this.Parent.Height - 35);
            this.btnList.InitializeButtons();
            this.btnList.Refresh();


            // 의사가 로그인 한 경우
            if (this.mDoctorLogin == true)
            {
                this.pbxApprove.Visible = this.mOrderBiz.GetNotApproveOrderCnt(this.IO_Gubun, UserInfo.UserID, "Y", "N", "%") > 0 ? true : false;
            }
            // 의사 이외의 사람들이 로그인 한 경우
            else
            {
                this.pbxApprove.Visible = false;

                //insert by jc
                this.pbxCpPatient.Visible = false;
                this.pbxIsNoAnwerOfConsulted.Visible = false;
                //this.pbxToiwonRes.Visible = false;
            }

            this.pnlUser.Visible = false;           
            this.pnlApproveUser.Visible = !this.mDoctorLogin;

            this.btnConsult.Enabled     = this.mDoctorLogin;
            this.btnConsultAnswer.Enabled = this.mDoctorLogin;
            this.btnCPReg.Enabled       = this.mDoctorLogin;
            this.btnToiwonRes.Enabled   = this.mDoctorLogin;
            this.btnApprove.Visible     = this.mDoctorLogin;
            this.btnSiksa.Enabled       = this.mDoctorLogin;
            this.btnDoctorJisi.Enabled  = this.mDoctorLogin;
        }

        private bool IsOrderInputUserCheck(bool aIsCloseYN)
        {
            if (UserInfo.UserGubun == UserType.Doctor)
            {
                // 나중에 bas0270 에 ocs status 체크 하는것으로 변경 
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
                    this.mMsg = "該当画面に使用権限がない使用者です。ご確認下さい。(ERR : INPUT_GUBUN)";
                    this.mCap = "使用権限確認";

                    MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
                this.mDoctorLogin = false;
                this.mInputGubun = UserInfo.InputGubun;

                if (UserInfo.UserGubun == UserType.Nurse)
                    this.mInputGwa = TypeCheck.NVL(UserInfo.HoDong, UserInfo.Gwa).ToString();
                else
                    this.mInputGwa = UserInfo.Gwa;

                if (this.mInputGubun == "CK")
                {
                    this.lblApproveLabel.Visible = true;
                    this.lblApproveFlag.Visible = true;
                }
            }

            if (TypeCheck.IsNull(this.mInputGwa))
            {
                if (this.OpenParam != null && this.OpenParam.Contains("input_gwa"))
                {
                    this.mInputGwa = this.OpenParam["input_gwa"].ToString();
                }
                else
                {
                    this.mInputGwa = mCommonForms.SelectGwa("1", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
                }
                //this.mInputGwa = mCommonForms.SelectGwa("1", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));

                if (TypeCheck.IsNull(this.mInputGwa))
                {
                    this.mMsg = "該当画面に使用権限がない使用者です。ご確認下さい。(ERR : INPUT_GWA)";
                    this.mCap = "使用権限確認";

                    MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }

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

            //入院日
            this.lblIpwonDate.Text = "入:" + aPatientInfo["naewon_date"].ToString();
            //this.lblIpwonDateCNT.Text = (EnvironInfo.GetSysDate().AddDays(1) - DateTime.Parse(aPatientInfo["naewon_date"].ToString())).Days.ToString() +"日";
            this.lblIpwonDateCNT.Text = aPatientInfo["jaewon_display"].ToString();
            this.lblHodong.Text = aPatientInfo["ho_dong"].ToString() + "棟 " + aPatientInfo["ho_code"].ToString() + "室";
            this.lblDoctor.Text = aPatientInfo["doctor_name"].ToString();
            this.lblGwa.Text = aPatientInfo["gwa"].ToString();
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
            bool isAllergyYn = false; 
            // 알레르기 팝업
            // insert by jc [使用者オプションによる表示・非表示] 2012/09/24
            if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "ALLERGY_POP_YN", this.IO_Gubun) != "N")
                this.mOrderBiz.OpenAllergyInfo(this, aBunho, aNaewonDate, ref isAllergyYn);

            // 타과의뢰 내역 있는지 여부
            //if (this.mOrderBiz.LoadConsultYN(aBunho, aNaewonDate, aGwa, aDoctor) == true)
            //if (this.mOrderBiz.LoadConsultYN(aBunho, aNaewonDate, aGwa, aDoctor, this.IO_Gubun) == true && this.mDoctorLogin == true)
            //{
            //    this.pbxIsNoReturnConsult.Visible = true;
            //}

            if(this.mDoctorLogin == true)
            {
                //진료의뢰여부응답여부 // 진료의뢰 화면 오픈
                string req_date = this.mOrderBiz.LoadConsultEndYN(aBunho, aDoctor);
                if (req_date != "")
                    this.pbxIsNoConfirmOfReturnedConsult.Visible = true;
                    

                // insert by jc [返事がない依頼件があるか確認してあれば点滅させて知らせる] 2012/11/09
                if (this.mOrderBiz.IsNoConfirmConsult(aBunho, this.dtpOrderDate.GetDataValue().ToString(), aGwa, aDoctor, IO_Gubun))
                    this.pbxIsNoAnwerOfConsulted.Visible = true;
            }
            // CP환자 여부
            
            //if (this.mOrderBiz.IsCPPatient(this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()))
            if (this.mOrderBiz.IsCPPatient(this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) && this.mDoctorLogin == true)
            {
                this.pbxCpPatient.Visible = true;
            }

            // 퇴원예고 환자 연부
            if (this.mOrderBiz.IsTOIWON_RES_YN(this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()))
            {
                pbxToiwonRes.Visible = true;
            }

            // 코맨트
            string commemt = this.mOrderBiz.LoadPatientSpecificComment(aBunho);

            //if (commemt != "")
            //{
            //    this.mCap = "患者特記事項";

            //    MessageBox.Show(commemt, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    this.pbxExistBunhoComment.Visible = true;
            //}
            if (commemt != "" && this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "SPECIALWRITE_POP_YN", this.IO_Gubun) != "N")
            {
                this.mCap = "患者特記事項";
                MessageBox.Show(commemt, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.pbxExistBunhoComment.Visible = true;
            }
            else if (commemt != "")
            {
                this.pbxExistBunhoComment.Visible = true;
            }

            // 오늘 측정한 신체계측 정보 있으면 자동팝업
            if (this.mSelectedPatientInfo.GetPatientInfo["today_vital_yn"].ToString() == "Y")
            {
                this.pbxVital.Visible = true;
            }
            ////アレルギー情報があるのか確認
            //if (this.mOrderBiz.ExistAllergyData(aBunho))
            //    this.pbxExistAllergy.Visible = true;
        
        }

        /// <summary>
        /// 변경된 데이터 체크
        /// </summary>
        /// <returns>true : 데이터가 있고 저장을 선택한 경우, false : 데이터가 없거나 저장을 선택하지 않은 경우</returns>
        private bool IsOrderDataModifed()
        {
            bool isExistModifiedData = false;

            this.mOrderFunc.DeleteEmptyNewRow(this.grdOutSang);
            
            if (this.grdOutSang.GetChangedRowCount('A') > 0 )
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
                    //リハビリオーダ追加 2012/11/22
                    this.layRehaOrder.GetChangedRowCount('A') > 0 ||
                    this.layEtcOrder.GetChangedRowCount('A') > 0 ||
                    this.layDeletedData.RowCount > 0)
                {
                    isExistModifiedData = true;
                }
            }

            if (isExistModifiedData == true)
            {
                this.mMsg = "保存していないデータが存在します。変更された内容を保存しますか？";
                this.mCap = "保存可否";

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

            for (int i=0; i<aDataSource.Rows.Count; i++)
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

        // 환자 그리드 이미지 셋팅
        private void SetPatientListImage(XEditGrid grid)
        {
            //for (int i = 0; i < grid.RowCount; i++)
            for (int i = 0; i < grid.DisplayRowCount; i++)
            {
                // 입원 예약환자.
                if (grid.GetItemString(i, "reser_yn") == "Y")
                {
                    grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[19];
                    grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + "/予約患者";
                }

                // 컨설트 환자
                if (grid.GetItemString(i, "consult_gubun") == "Y")
                {
                    grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[22];
                    grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + "/診療依頼";
                }

                // 공통의사
                if (grid.GetItemString(i, "common_doctor_yn") == "Y")
                {
                    grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[35];
                    grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + "/共通医";
                }

                //未承認オーダーあり
                if (this.grdPatientList.GetItemString(i, "unapprove_yn") == "Y")
                {
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 3].Image = this.ImageList.Images[45];
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 3].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 3].ToolTipText + "/未承認オーダーあり";
                }
            }
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
                        for ( int i=0; i<aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layDrugOrder.LayoutTable.ImportRow(dr);

                        //// 접수정보 
                        //this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
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

                case "OCS0103U12": // 주사오더인경우 

                    this.layJusaOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    //insert by jc [同じオーダ日に同じグループが存在するかチェックして存在する場合は競合しないように変更する]
                    if(aGrid.RowCount > 0)
                        this.SetSameOrderDateGroupSer(aGrid);
                    //inert by jc

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layJusaOrder.LayoutTable.ImportRow(dr);

                        //// 접수정보 
                        //this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                    }



                    break;

                case "OCS0103U13": // 검체검사 

                    this.layCplOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layCplOrder.LayoutTable.ImportRow(dr);

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    break;

                case "OCS0103U14": // 생리검사 

                    this.layPfeOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layPfeOrder.LayoutTable.ImportRow(dr);

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    break;

                case "OCS0103U15": // 병리검사 

                    this.layAplOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layAplOrder.LayoutTable.ImportRow(dr);

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    break;

                case "OCS0103U16": // 방사선 

                    this.layXrtOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layXrtOrder.LayoutTable.ImportRow(dr);

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
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
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layChuchiOrder.LayoutTable.ImportRow(dr);

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    break;

                case "OCS0103U18": // 마취 수술오더 

                    this.laySusulOrder.Reset();
                    
                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.laySusulOrder.LayoutTable.ImportRow(dr);

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    break;

                case "OCS0103U19": // 기타 오더

                    this.layEtcOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layEtcOrder.LayoutTable.ImportRow(dr);

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    break;
            }

            this.SetInputGubunColor();
        }

        private void RecieveAndSetOrderInfo(string aCommand, MultiLayout aSourceLayout)
        {
            switch (aCommand)
            {
                case "OCS0103U10": // 약오더인경우 

                    this.layDrugOrder.Reset();

                    // 삭제 데이터 셋팅
                    //if (aSourceLayout.DeletedRowCount > 0 && aSourceLayout.DeletedRowTable != null)
                    //{
                    //    // 삭제된 로우를 셋팅한다.
                    //    for (int i = 0; i < aSourceLayout.DeletedRowTable.Rows.Count; i++)
                    //    {
                    //        if (layDeletedData.LayoutTable.Select("pkocskey=" + aSourceLayout.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                    //        this.layDeletedData.LayoutTable.ImportRow(aSourceLayout.DeletedRowTable.Rows[i]);
                    //        this.layDeletedData.SetItemValue(i, "dummy", "Y");
                    //    }
                    //}

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
                    {
                        this.layDrugOrder.LayoutTable.ImportRow(dr);

                        //// 접수정보 
                        //this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                    }

                    break;

                case "OCS0103U11": // リハビリオーダ追加 2012/09/26

                    this.layRehaOrder.Reset();

                    //// 삭제 데이터 셋팅
                    //if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    //{
                    //    // 삭제된 로우를 셋팅한다.
                    //    for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                    //    {
                    //        if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                    //        this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                    //        //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                    //    }
                    //}

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
                    {
                        this.layRehaOrder.LayoutTable.ImportRow(dr);

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layRehaOrder.SetItemValue(this.layRehaOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layRehaOrder.SetItemValue(this.layRehaOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    break;

                case "OCS0103U12": // 주사오더인경우 

                    this.layJusaOrder.Reset();

                    // 삭제 데이터 셋팅
                    //if (aSourceLayout.DeletedRowCount > 0 && aSourceLayout.DeletedRowTable != null)
                    //{
                    //    // 삭제된 로우를 셋팅한다.
                    //    for (int i = 0; i < aSourceLayout.DeletedRowTable.Rows.Count; i++)
                    //    {
                    //        if (layDeletedData.LayoutTable.Select("pkocskey=" + aSourceLayout.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                    //        this.layDeletedData.LayoutTable.ImportRow(aSourceLayout.DeletedRowTable.Rows[i]);
                    //        this.layDeletedData.SetItemValue(i, "dummy", "Y");
                    //    }
                    //}

                    //insert by jc [同じオーダ日に同じグループが存在するかチェックして存在する場合は競合しないように変更する]
                    //if (aSourceLayout.RowCount > 0)
                    //    this.SetSameOrderDateGroupSer(aSourceLayout);
                    //inert by jc

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
                    {
                        this.layJusaOrder.LayoutTable.ImportRow(dr);

                        //// 접수정보 
                        //this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                    }



                    break;

                case "OCS0103U13": // 검체검사 

                    this.layCplOrder.Reset();

                    // 삭제 데이터 셋팅
                    //if (aSourceLayout.DeletedRowCount > 0 && aSourceLayout.DeletedRowTable != null)
                    //{
                    //    // 삭제된 로우를 셋팅한다.
                    //    for (int i = 0; i < aSourceLayout.DeletedRowTable.Rows.Count; i++)
                    //    {
                    //        if (layDeletedData.LayoutTable.Select("pkocskey=" + aSourceLayout.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                    //        this.layDeletedData.LayoutTable.ImportRow(aSourceLayout.DeletedRowTable.Rows[i]);
                    //        this.layDeletedData.SetItemValue(i, "dummy", "Y");
                    //    }
                    //}

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
                    {
                        this.layCplOrder.LayoutTable.ImportRow(dr);

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    break;

                case "OCS0103U14": // 생리검사 

                    this.layPfeOrder.Reset();

                    // 삭제 데이터 셋팅
                    //if (aSourceLayout.DeletedRowCount > 0 && aSourceLayout.DeletedRowTable != null)
                    //{
                    //    // 삭제된 로우를 셋팅한다.
                    //    for (int i = 0; i < aSourceLayout.DeletedRowTable.Rows.Count; i++)
                    //    {
                    //        if (layDeletedData.LayoutTable.Select("pkocskey=" + aSourceLayout.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                    //        this.layDeletedData.LayoutTable.ImportRow(aSourceLayout.DeletedRowTable.Rows[i]);
                    //        this.layDeletedData.SetItemValue(i, "dummy", "Y");
                    //    }
                    //}

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
                    {
                        this.layPfeOrder.LayoutTable.ImportRow(dr);

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    break;

                case "OCS0103U15": // 병리검사 

                    this.layAplOrder.Reset();

                    // 삭제 데이터 셋팅
                    //if (aSourceLayout.DeletedRowCount > 0 && aSourceLayout.DeletedRowTable != null)
                    //{
                    //    // 삭제된 로우를 셋팅한다.
                    //    for (int i = 0; i < aSourceLayout.DeletedRowTable.Rows.Count; i++)
                    //    {
                    //        if (layDeletedData.LayoutTable.Select("pkocskey=" + aSourceLayout.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                    //        this.layDeletedData.LayoutTable.ImportRow(aSourceLayout.DeletedRowTable.Rows[i]);
                    //        this.layDeletedData.SetItemValue(i, "dummy", "Y");
                    //    }
                    //}

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
                    {
                        this.layAplOrder.LayoutTable.ImportRow(dr);

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    break;

                case "OCS0103U16": // 방사선 

                    this.layXrtOrder.Reset();

                    // 삭제 데이터 셋팅
                    //if (aSourceLayout.DeletedRowCount > 0 && aSourceLayout.DeletedRowTable != null)
                    //{
                    //    // 삭제된 로우를 셋팅한다.
                    //    for (int i = 0; i < aSourceLayout.DeletedRowTable.Rows.Count; i++)
                    //    {
                    //        if (layDeletedData.LayoutTable.Select("pkocskey=" + aSourceLayout.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                    //        this.layDeletedData.LayoutTable.ImportRow(aSourceLayout.DeletedRowTable.Rows[i]);
                    //        this.layDeletedData.SetItemValue(i, "dummy", "Y");
                    //    }
                    //}

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
                    {
                        this.layXrtOrder.LayoutTable.ImportRow(dr);

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    break;

                case "OCS0103U17": // 처치 

                    this.layChuchiOrder.Reset();

                    // 삭제 데이터 셋팅
                    //if (aSourceLayout.DeletedRowCount > 0 && aSourceLayout.DeletedRowTable != null)
                    //{
                    //    // 삭제된 로우를 셋팅한다.
                    //    for (int i = 0; i < aSourceLayout.DeletedRowTable.Rows.Count; i++)
                    //    {
                    //        if (layDeletedData.LayoutTable.Select("pkocskey=" + aSourceLayout.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                    //        this.layDeletedData.LayoutTable.ImportRow(aSourceLayout.DeletedRowTable.Rows[i]);
                    //        this.layDeletedData.SetItemValue(i, "dummy", "Y");
                    //    }
                    //}

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
                    {
                        this.layChuchiOrder.LayoutTable.ImportRow(dr);

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    break;

                case "OCS0103U18": // 마취 수술오더 

                    this.laySusulOrder.Reset();

                    // 삭제 데이터 셋팅
                    //if (aSourceLayout.DeletedRowCount > 0 && aSourceLayout.DeletedRowTable != null)
                    //{
                    //    // 삭제된 로우를 셋팅한다.
                    //    for (int i = 0; i < aSourceLayout.DeletedRowTable.Rows.Count; i++)
                    //    {
                    //        if (layDeletedData.LayoutTable.Select("pkocskey=" + aSourceLayout.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                    //        this.layDeletedData.LayoutTable.ImportRow(aSourceLayout.DeletedRowTable.Rows[i]);
                    //        this.layDeletedData.SetItemValue(i, "dummy", "Y");
                    //    }
                    //}

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
                    {
                        this.laySusulOrder.LayoutTable.ImportRow(dr);

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    break;

                case "OCS0103U19": // 기타 오더

                    this.layEtcOrder.Reset();

                    // 삭제 데이터 셋팅
                    //if (aSourceLayout.DeletedRowCount > 0 && aSourceLayout.DeletedRowTable != null)
                    //{
                    //    // 삭제된 로우를 셋팅한다.
                    //    for (int i = 0; i < aSourceLayout.DeletedRowTable.Rows.Count; i++)
                    //    {
                    //        if (layDeletedData.LayoutTable.Select("pkocskey=" + aSourceLayout.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                    //        this.layDeletedData.LayoutTable.ImportRow(aSourceLayout.DeletedRowTable.Rows[i]);
                    //        this.layDeletedData.SetItemValue(i, "dummy", "Y");
                    //    }
                    //}

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
                    {
                        this.layEtcOrder.LayoutTable.ImportRow(dr);

                        //if (dr.RowState == DataRowState.Added)
                        //{
                        //    // 접수정보 
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                        //    this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        //}
                    }

                    break;
            }

            this.SetInputGubunColor();
        }

        private void SetDisplayLayout(string aInputGubun, string aInputTab)
        {
            this.layDisplayLayout.Reset();

            MultiLayout layTemp = this.layDisplayLayout.Clone();
            MultiLayout sourceLay = this.layQueryLayout.Clone();

            #region [ 내복약 ]

            if (aInputTab == "01" || aInputTab == "%")    // 내복약
            {
                sourceLay.Reset();

                // 의사가 로그인한 경우
                if (this.mDoctorLogin)
                {
                    // 내복약 셋팅
                    //foreach (DataRow drugFilter in this.layDrugOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(drugFilter);
                    //}
                    for (int i = 0; i < this.layDrugOrder.RowCount; i++)
                    {
                        if (this.layDrugOrder.GetItemString(i, "input_gubun") == aInputGubun || aInputGubun == "DA")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layDrugOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                // 의사 이외의 사람이 로그인한 경우
                else
                {
                    // 내복약 셋팅
                    //foreach (DataRow drugFilter in this.layDrugOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(drugFilter);
                    //}
                    for (int i = 0; i < this.layDrugOrder.RowCount; i++)
                    {
                        if (this.layDrugOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layDrugOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layDrugOrder.LayoutTable.Rows[i]);
                        }
                    }
                }

                this.mOrderBiz.SetDisplayOrderData(IO_Gubun, sourceLay, layTemp);

                foreach (DataRow drugRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(drugRow);
                }
            }

            #endregion

            #region [ 주사약 ]

            if (aInputTab == "03" || aInputTab == "%")    // 주사약
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 주사약 셋팅
                    //foreach (DataRow jusaFilter in this.layJusaOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(jusaFilter);
                    //}
                    for (int i = 0; i < this.layJusaOrder.RowCount; i++)
                    {
                        if (this.layJusaOrder.GetItemString(i, "input_gubun") == aInputGubun || aInputGubun == "DA")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layJusaOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 주사약 셋팅
                    //foreach (DataRow jusaFilter in this.layJusaOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(jusaFilter);
                    //}
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
                    //foreach (DataRow cplFilter in this.layCplOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(cplFilter);
                    //}
                    for (int i = 0; i < this.layCplOrder.RowCount; i++)
                    {
                        if (this.layCplOrder.GetItemString(i, "input_gubun") == aInputGubun || aInputGubun == "DA")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layCplOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 검체검사 셋팅
                    //foreach (DataRow cplFilter in this.layCplOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(cplFilter);
                    //}
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
                    //foreach (DataRow pfeFilter in this.layPfeOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(pfeFilter);
                    //}
                    for (int i = 0; i < this.layPfeOrder.RowCount; i++)
                    {
                        if (this.layPfeOrder.GetItemString(i, "input_gubun") == aInputGubun || aInputGubun == "DA")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layPfeOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 생리검사 셋팅
                    //foreach (DataRow pfeFilter in this.layPfeOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(pfeFilter);
                    //}
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
                    //foreach (DataRow aplFilter in this.layAplOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(aplFilter);
                    //}
                    for (int i = 0; i < this.layAplOrder.RowCount; i++)
                    {
                        if (this.layAplOrder.GetItemString(i, "input_gubun") == aInputGubun || aInputGubun == "DA")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layAplOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 병리검사 셋팅
                    //foreach (DataRow aplFilter in this.layAplOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(aplFilter);
                    //}
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
                    //foreach (DataRow xrtFilter in this.layXrtOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(xrtFilter);
                    //}
                    for (int i = 0; i < this.layXrtOrder.RowCount; i++)
                    {
                        if (this.layXrtOrder.GetItemString(i, "input_gubun") == aInputGubun || aInputGubun == "DA")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layXrtOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 병리검사 셋팅
                    //foreach (DataRow xrtFilter in this.layXrtOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(xrtFilter);
                    //}
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
                    //foreach (DataRow chuchiFilter in this.layChuchiOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(chuchiFilter);
                    //}
                    for (int i = 0; i < this.layChuchiOrder.RowCount; i++)
                    {
                        if (this.layChuchiOrder.GetItemString(i, "input_gubun") == aInputGubun || aInputGubun == "DA")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layChuchiOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 처치오더 셋팅
                    //foreach (DataRow chuchiFilter in this.layChuchiOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(chuchiFilter);
                    //}
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
                    //foreach (DataRow susulFilter in this.laySusulOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(susulFilter);
                    //}
                    for (int i = 0; i < this.laySusulOrder.RowCount; i++)
                    {
                        if (this.laySusulOrder.GetItemString(i, "input_gubun") == aInputGubun || aInputGubun == "DA")
                        {
                            sourceLay.LayoutTable.ImportRow(this.laySusulOrder.LayoutTable.Rows[i]);
                        }
                    }
                }
                else
                {
                    // 수술오더 셋팅
                    //foreach (DataRow susulFilter in this.laySusulOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(susulFilter);
                    //}
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

            #region [ リハビリ ] リハビリオーダ追加 2012/11/22

            if (aInputTab == "10" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    for (int i = 0; i < this.layRehaOrder.RowCount; i++)
                    {
                        if (this.layRehaOrder.GetItemString(i, "input_gubun") == aInputGubun || aInputGubun == "DA")
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
                        if (this.layEtcOrder.GetItemString(i, "input_gubun") == aInputGubun || aInputGubun == "DA")
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

        private void SetInputGubunColor(string aInputGubun)
        {
            //this.ClearInputGubunColor();

            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabInputGubun.TabPages)
            {
                if (this.mDoctorLogin)
                {
                    if (tpg.Tag.ToString() == aInputGubun)
                    {
                        tpg.TitleTextColor = this.mExistInputGubunColor.Color;
                        this.tabInputGubun.TabPages[0].TitleTextColor = this.mExistInputGubunColor.Color;
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

        private void SetInputGubunColor()
        {
            bool isExist = false;
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabInputGubun.TabPages)
            {
                if (tpg.Tag.ToString() == "DA")
                {
                    if (this.layDrugOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                    {
                        this.SetInputGubunColor(tpg.Tag.ToString());
                        continue;
                    }
                    if (this.layJusaOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                    {
                        this.SetInputGubunColor(tpg.Tag.ToString());
                        continue;
                    }
                
                    if (this.layCplOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                    {
                        this.SetInputGubunColor(tpg.Tag.ToString());
                        continue;
                    }
                
                    if (this.layPfeOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                    {
                        this.SetInputGubunColor(tpg.Tag.ToString());
                        continue;
                    }
                
                    if (this.layAplOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                    {
                        this.SetInputGubunColor(tpg.Tag.ToString());
                        continue;
                    }

                    if (this.layXrtOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                    {
                        this.SetInputGubunColor(tpg.Tag.ToString());
                        continue;
                    }

                    if (this.layChuchiOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                    {
                        this.SetInputGubunColor(tpg.Tag.ToString());
                        continue;
                    }

                    if (this.laySusulOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                    {
                        this.SetInputGubunColor(tpg.Tag.ToString());
                        continue;
                    }

                    if (this.layEtcOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                    {
                        this.SetInputGubunColor(tpg.Tag.ToString());
                        continue;
                    }
                }

                else if (tpg.Tag.ToString() != "DA")
                {
                    #region [ 약 ]

                    if (this.mDoctorLogin)
                    {
                        if (this.layDrugOrder.LayoutTable.Select("input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }
                    else
                    {
                        if (this.layDrugOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }

                    #endregion

                    #region [ 주사 ]

                    if (this.mDoctorLogin)
                    {
                        if (this.layJusaOrder.LayoutTable.Select("input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }
                    else
                    {
                        if (this.layJusaOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }

                    #endregion

                    #region [ 검체검사 ]

                    if (this.mDoctorLogin)
                    {
                        if (this.layCplOrder.LayoutTable.Select("input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }
                    else
                    {
                        if (this.layCplOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }

                    #endregion

                    #region [ 생리검사 ]

                    if (this.mDoctorLogin)
                    {
                        if (this.layPfeOrder.LayoutTable.Select("input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }
                    else
                    {
                        if (this.layPfeOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }

                    #endregion

                    #region [ 병리검사 ]

                    if (this.mDoctorLogin)
                    {
                        if (this.layAplOrder.LayoutTable.Select("input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }
                    else
                    {
                        if (this.layAplOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }

                    #endregion

                    #region [ 방사선 ]

                    if (this.mDoctorLogin)
                    {
                        if (this.layXrtOrder.LayoutTable.Select("input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }
                    else
                    {
                        if (this.layXrtOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }

                    #endregion

                    #region [ 처치 ]

                    if (this.mDoctorLogin)
                    {
                        if (this.layChuchiOrder.LayoutTable.Select("input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }
                    else
                    {
                        if (this.layChuchiOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }

                    #endregion

                    #region [ 수술 마취 ]

                    if (this.mDoctorLogin)
                    {
                        if (this.laySusulOrder.LayoutTable.Select("input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }
                    else
                    {
                        if (this.laySusulOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }

                    #endregion

                    #region [ 기타오더 ]

                    if (this.mDoctorLogin)
                    {
                        if (this.layEtcOrder.LayoutTable.Select("input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }
                    else
                    {
                        if (this.layEtcOrder.LayoutTable.Select("input_gubun like 'D%' OR input_gubun='" + tpg.Tag.ToString() + "'").Length > 0)
                        {
                            this.SetInputGubunColor(tpg.Tag.ToString());
                            continue;
                        }
                    }
                    #endregion
                }

                
            }
        }

        private void DislplayOrderDataWindow(string aInputGubun, string aInputTab)
        {
            this.SetInputTabRadioColor(aInputGubun);

            this.SetDisplayLayout(aInputGubun, aInputTab);

            this.grdDebug.Reset();
            foreach (DataRow dr in this.layDisplayLayout.LayoutTable.Rows)
            {
                this.grdDebug.LayoutTable.ImportRow(dr);
            }
            this.grdDebug.DisplayData();

            this.dwOrderInfo.Reset();

            this.dwOrderInfo.FillData(this.layDisplayLayout.LayoutTable);

            this.SetOrderButtons(aInputGubun);
        }

        private void SetOrderButtons(string aInputGubun)
        {
            //switch (aInputGubun)
            //{
            //    case "DA": // 全体
            //        this.tabInputGubun.SelectedIndex = 0;
            //        break;
            //    case "D0": // 通常
            //        this.tabInputGubun.SelectedIndex = 0;
            //        break;
            //    case "D4": // 臨時
            //        this.tabInputGubun.SelectedIndex = 0;
            //        break;
            //    case "D7": // 退院
            //        this.tabInputGubun.SelectedIndex = 0;
            //        break;
            //    default:
                    
            //        break;
            //}
        }
        private void SetInputTabRadioColor(string aInputGubun)
        {
            XRadioButton allButton = null;
            XRadioButton control;
            bool isExistOrder = false;


            if (aInputGubun == "DA")
            {
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
                                // リハビリオーダ追加 2012/11/22
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

                    if (isExistOrder == true)
                    {
                        allButton.ForeColor = new XColor(Color.Red);
                    }
                }
            }
            else
            {
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


                            switch (ctl.Tag.ToString())
                            {
                                case "01":     // 약
                                    if (this.layDrugOrder.LayoutTable.Select("input_gubun='" + aInputGubun + "'").Length > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "03":     // 주사
                                    if (this.layJusaOrder.LayoutTable.Select("input_gubun='" + aInputGubun + "'").Length > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "04":     // 검체검사
                                    if (this.layCplOrder.LayoutTable.Select("input_gubun='" + aInputGubun + "'").Length > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "05":     // 생리검사
                                    if (this.layPfeOrder.LayoutTable.Select("input_gubun='" + aInputGubun + "'").Length > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "06":     // 병리검사
                                    if (this.layAplOrder.LayoutTable.Select("input_gubun='" + aInputGubun + "'").Length > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "07":     // 방사선
                                    if (this.layXrtOrder.LayoutTable.Select("input_gubun='" + aInputGubun + "'").Length > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "08":     // 처치
                                    if (this.layChuchiOrder.LayoutTable.Select("input_gubun='" + aInputGubun + "'").Length > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "09":     // 마취, 수술
                                    if (this.laySusulOrder.LayoutTable.Select("input_gubun='" + aInputGubun + "'").Length > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                // リハビリオーダ追加 2012/11/22
                                case "10":     // リハビリ
                                    if (this.layRehaOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "11":     // 기타
                                    if (this.layEtcOrder.LayoutTable.Select("input_gubun='" + aInputGubun + "'").Length > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                            }
                        }
                    }

                    if (isExistOrder == true)
                    {
                        allButton.ForeColor = new XColor(Color.Red);
                    }
                }
            }
        }

        private bool IsPatientSelected()
        {
            if (this.fbxBunho.GetDataValue() == "" ||
                this.mSelectedPatientInfo == null ||
                this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() == "")
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "患者が選択されていません。" : "환자가선택되어있지않습니다.";
                mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
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
            this.layPfeOrder.Reset();
            this.layCplOrder.Reset();
            this.layAplOrder.Reset();
            this.layXrtOrder.Reset();
            this.layJusaOrder.Reset();
            this.layChuchiOrder.Reset();
            this.laySusulOrder.Reset();
            // リハビリオーダ追加 2012/11/22
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

            // 주사약오더
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

            // 생리검사오더
            foreach (DataRow dr in this.layXrtOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 병리검사오더
            foreach (DataRow dr in this.layAplOrder.LayoutTable.Rows)
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

            // リハビリオーダ追加 2012/11/22
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
            this.layDrugOrder.Reset();

            foreach (DataRow dr in aQueryLayout.LayoutTable.Rows)
            {
                // 내복약인경우
                switch (dr["input_tab"].ToString())
                {
                    case "01":  // 내복약인경우

                        this.layDrugOrder.LayoutTable.ImportRow(dr);

                        break;
                }
            }

            return true;
        }

        private bool OrderValidationCheck()
        {
            int dupRow = -1;
            string inputid = "";
            string hangmog_code = "";
            string hangmog_name = "";
            string hope_date = "";

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
                    XMessageBox.Show("終了された傷病については「転帰」を入力してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.grdOutSang.SetFocusToItem(i, "sang_end_sayu");
                    return false;
                }
            }
            #endregion

            for (int i=0; i<this.laySaveLayout.RowCount; i++)
            {
                // Interface 대상이면서 Key 가 없으면 
                // 여기서 키를 딴다.
                if (this.mInterface.IsInterfaceHangmog(false, "I", this.laySaveLayout.LayoutTable.Rows[i]) && this.laySaveLayout.GetItemString(i, "pkocskey") == "")
                {
                    this.laySaveLayout.SetItemValue(i, "pkocskey", this.mOrderFunc.GetOrderKey(OrderVariables.OrderMode.InpOrder));
                }

                // 承認したオーダーを代行者が修正できなくする。
                if (   this.mInputGubun == "CK"
                    && this.laySaveLayout.GetItemString(i, "pkocskey") != ""
                    && this.laySaveLayout.LayoutTable.Rows[i].RowState != DataRowState.Unchanged)
                {
                    if (!this.mOrderBiz.IsPossibleInsteadOrder(this.laySaveLayout.GetItemString(i, "pkocskey"), this.laySaveLayout.GetItemString(i, "input_gubun"), this.IO_Gubun))
                    {
                        XMessageBox.Show("既に承認したオーダーです。修正できません。", "確認");
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

                if (i != 0)
                {
                    string cmd = " SELECT FN_CPL_LOAD_DUP_GRD_HANGMOG('" + this.laySaveLayout.GetItemString(i, "hangmog_code") + "', '"
                               + this.laySaveLayout.GetItemString(i, "specimen_code") + "', '"
                               + this.laySaveLayout.GetItemString(i - 1, "hangmog_code") + "', '"
                               + this.laySaveLayout.GetItemString(i - 1, "specimen_code") + "') "
                               + "   FROM SYS.DUAL ";

                    object check = Service.ExecuteScalar(cmd);

                    if (TypeCheck.IsNull(check) == false)
                    {
                        if (check.ToString() != "0")
                        {
                            this.mMsg = check.ToString() + "\n" + "===================================================\n" +
                                        "このまま保存しますか?";

                            if (MessageBox.Show(this.mMsg, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                            {
                                return false;
                            }
                        }
                    }


                }

                hangmog_code = this.laySaveLayout.GetItemString(i, "hangmog_code");
                hangmog_name = this.laySaveLayout.GetItemString(i, "hangmog_name");
                hope_date = TypeCheck.NVL(this.laySaveLayout.GetItemString(i, "hope_date"), this.dtpOrderDate.GetDataValue()).ToString();
                //insert by jc [返却/取消されたオーダは重複チェック対象から外す] START
                if (  (   this.laySaveLayout.GetItemString(i, "dc_yn") != "Y"
                       || this.laySaveLayout.GetItemString(i, "bannab_yn") != "Y"
                       || this.laySaveLayout.GetItemString(i, "dc_gubun") != "Y"
                      )
                      && int.Parse(this.laySaveLayout.GetItemString(i, "nalsu")) > 0
                      && this.laySaveLayout.GetItemString(i, "order_gubun").Substring(1, 1) != "B"  // JUSA NO CHECK
                    )
                //insert by jc [返却/取消されたオーダは重複チェック対象から外す] END
                {

                    for (int j = i + 1; j < this.laySaveLayout.RowCount; j++)
                    {
                        if (   hangmog_code == this.laySaveLayout.GetItemString(j, "hangmog_code") 
                            && hope_date    == TypeCheck.NVL(this.laySaveLayout.GetItemString(j, "hope_date"), this.dtpOrderDate.GetDataValue()).ToString()
                            && this.laySaveLayout.GetItemString(j, "bannab_yn") != "Y"

                            )
                        {
                            string message = "<   項目コード   " + hangmog_code + "   " + "案内" + "  >" + "\r\n\r\n\r\n" +
                                            "[ " + hangmog_name + " ]" + "\r\n\r\n\r\n" +
                                            " " + "当日 重複オーダ です";

                            this.mMsg = message + "\n" + "===================================================\n" +
                                            "このまま保存しますか?";

                            if (MessageBox.Show(this.mMsg, "確認", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
                            {
                                return false;
                            }
                        }
                    }
                }
                
            }

            #region [処置で処置結果が入力されてないと見なされるオーダーチェック]
            /*
                             * 液体酸素・可搬式液化酸素容器（ＬＧＣ）
                             * 人工呼吸
                             * 人工呼吸（鼻マスク式人工呼吸器）
                             * 呼吸心拍監視
                             */
            bool finish_chuci = true;
            string cmd_chuchi = @" SELECT A.CODE, A.GROUP_KEY
                                     FROM OCS0132 A
                                    WHERE A.HOSP_CODE = :f_hosp_code
                                      AND A.CODE_TYPE = 'MARUME_ORDER'
                                      AND A.VALUE_POINT = '2'
                                    ";
            BindVarCollection bind_chuci = new BindVarCollection();
            bind_chuci.Add("f_hosp_code", EnvironInfo.HospCode);

            DataTable dt = Service.ExecuteDataTable(cmd_chuchi, bind_chuci);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < this.laySaveLayout.RowCount; i++)
                    {
                        if (   dr["code"].ToString() == this.laySaveLayout.GetItemString(i, "hangmog_code")
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
                                result = XMessageBox.Show(this.laySaveLayout.GetItemString(i, "hangmog_name") + "の施行時間が指定されてない可能性があります。時間指定しますか？", "確認", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button1);

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
                if (   this.laySaveLayout.GetItemString(i, "input_tab") == "01" 
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
                        XMessageBox.Show("[" + dr[j]["group_ser"].ToString() + "]グループのオーダの回数が不一致します。", "確認");
                        return false;
                    }
                }
            }

            // 중복처방체크 
            if (this.mOrderBiz.IsProtecedDupInputInpOrder(this.laySaveLayout, this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                         , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                                         , this.dtpOrderDate.GetDataValue()
                                                         , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                                         , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                                         , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                                                         , ref dupRow) == true)
            {                
                return false;
            }

            return true;
        }

        #endregion

        #region [ 공통의 선택시 로직들 ]

        private void ProcessCommonDoctorRequest(int aRowNumber)
        {
            string cmd = " UPDATE OCS0503 "
                       + "    SET CONSULT_DOCTOR = :f_doctor "
                       + "      , UPD_ID = 'UPD_REC_' "
                       + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                       + "    AND PKOCS0503 = :f_pkocs0503 ";

            BindVarCollection bindVar = new BindVarCollection();
            if (this.mDoctorLogin)
            {
                bindVar.Add("f_doctor", UserInfo.DoctorID);
            }
            else
            {
                bindVar.Add("f_doctor", this.cboQryDoctor.GetDataValue());
            }
            bindVar.Add("f_pkocs0503", this.grdPatientList.GetItemString(aRowNumber, "consult_key"));

            Service.ExecuteNonQuery(cmd, bindVar);
        }

        private bool IsCommonDoctorConsult(int aRowNumber)
        {
            string cmd = " SELECT 'Y' "
                       + "   FROM BAS0270 A "
                       + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                       + "    AND A.DOCTOR = :f_doctor "
                       + "    AND NVL(A.COMMON_DOCTOR_YN, 'N') = 'Y' "
                       + "    AND A.START_DATE = ( SELECT MAX(X.START_DATE) "
                       + "                           FROM BAS0270 X "
                       + "                          WHERE X.HOSP_CODE = A.HOSP_CODE "
                       + "                            AND X.DOCTOR = A.DOCTOR "
                       + "                            AND X.START_DATE <= :f_date ) ";

            BindVarCollection bindVar;
            object commonDoctorYn = null;

            if (this.grdPatientList.GetItemString(aRowNumber, "consult_gubun") == "Y")
            {
                bindVar = new BindVarCollection();
                bindVar.Add("f_doctor", this.grdPatientList.GetItemString(aRowNumber, "doctor"));
                bindVar.Add("f_date", this.dtpOrderDate.GetDataValue());

                commonDoctorYn = Service.ExecuteScalar(cmd, bindVar);

                if (commonDoctorYn == null || commonDoctorYn.ToString() != "Y")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #endregion

        private bool IsSameNameCHK()
        {
            if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "SAME_NAME_CHECK_YN", this.IO_Gubun) == "N")
                return false;

            string cmd = @"SELECT FN_ADM_IS_SAME_NAME_YN_INP_T(:f_bunho) FROM SYS.DUAL";

            BindVarCollection bindVar = new BindVarCollection();

            bindVar.Add("f_bunho", this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho"));
            
            object val = Service.ExecuteScalar(cmd, bindVar);

            if (TypeCheck.IsNull(val) == false && val.ToString() == "Y")
                return true;
            else
                return false;
        }


        #region 조사록 자동출력

        private void PrintXRTJosa(DataRow aRow)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("doctor", aRow["doctor"].ToString());
            param.Add("bunho", aRow["bunho"].ToString());
            param.Add("order_date", aRow["order_date"].ToString());
            param.Add("pkocskey", aRow["pkocskey"].ToString());
            param.Add("in_out_gubun", "I");
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        #region [ 다른 화면 오픈 ]

        private void OpenScreen_OCS2003U01()
        {
            //CommonItemCollection param = new CommonItemCollection();

            //param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            //param.Add("fkinp1001", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            //if (this.mDoctorLogin)
            //    param.Add("doctor", UserInfo.DoctorID);
            //else
            //    param.Add("doctor", this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

            //if (this.mDoctorLogin)
            //    param.Add("input_part", UserInfo.Gwa);
            //else
            //    param.Add("input_part", this.mInputGwa);

            //param.Add("input_gubun", this.mInputGubun);
            //param.Add("order_date", this.dtpOrderDate.GetDataValue());

            //XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003U01", ScreenOpenStyle.ResponseFixed, param);

            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("fkinp1001", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            if (this.mDoctorLogin)
                param.Add("doctor", UserInfo.DoctorID);
            else
                param.Add("doctor", this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

            if (this.mDoctorLogin)
                param.Add("gwa", UserInfo.Gwa);
            else
                param.Add("gwa", this.mInputGwa);

            //param.Add("input_gubun", this.mInputGubun);
            param.Add("query_date", this.dtpOrderDate.GetDataValue());

            XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003U03", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_OCS6010U10()
        {
            //modify by yoon [popup -> tab] 2012/03/06
            
            IHIS.Framework.IXScreen aScreen;
            aScreen = XScreen.FindScreen("OCSI", "OCS6010U10");
            if (aScreen == null)
            {
                CommonItemCollection param = new CommonItemCollection();
                param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
                param.Add("fkinp1001", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
                if (EnvironInfo.CurrSystemID == "OCSI" || EnvironInfo.CurrSystemID == "INSI")
                    XScreen.OpenScreenWithParam(this, "OCSI", "OCS6010U10", IHIS.Framework.ScreenOpenStyle.PopUpSizable, ScreenAlignment.ParentTopLeft, param);
                else
                    XScreen.OpenScreenWithParam(this, "OCSI", "OCS6010U10", IHIS.Framework.ScreenOpenStyle.ResponseSizable, ScreenAlignment.ParentTopLeft, param);
                
            }
            else
            {
                aScreen.Activate();
                XPatientInfo paInfo = new XPatientInfo(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(), "", "", "", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString(), PatientPKGubun.In, this.ScreenID);
                XScreen.SendPatientInfo(paInfo);
            }            

            
            //CommonItemCollection param = new CommonItemCollection();

            //param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            //param.Add("fkinp1001", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            //XScreen.OpenScreenWithParam(this, "OCSI", "OCS6010U10", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 의사 지시사항 조회
        /// </summary>
        private void OpenScreen_OCS2004U00(string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("fkinp1001", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("order_date", this.dtpOrderDate.GetDataValue());
            param.Add("input_gubun", aInputGubun);

            if (UserInfo.UserGubun == UserType.Doctor)
            {   
                param.Add("input_gwa", UserInfo.Gwa);
                param.Add("input_doctor", UserInfo.DoctorID);
            }
            else
            {
                param.Add("input_gwa", this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());
                param.Add("input_doctor", this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());
            }

            XScreen.OpenScreenWithParam(this, "OCSI", "OCS2004U00", ScreenOpenStyle.ResponseSizable, param);
        }

        private void OpenScreen_OUT0101Q01()
        {
            CommonItemCollection param = new CommonItemCollection();

            XScreen.OpenScreenWithParam(this, "OUTS", "OUT0101Q01", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 바이탈 사인 조회 화면 오픈
        /// </summary>
        /// <param name="aBunho"></param>
        /// <param name="aDate"></param>
        private void OpenScreen_NUR1020Q00(string aBunho, string aDate)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("sysid", EnvironInfo.CurrSystemID);
            openParams.Add("screen", this.Name);
            openParams.Add("date", aDate);
            openParams.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "NURI", "NUR1020Q00", ScreenOpenStyle.PopUpSizable, ScreenAlignment.ParentTopLeft, openParams);
        }

        /// <summary>
        /// 진료의뢰 화면 오픈
        /// </summary>
        /// <param name="aBbunho"></param>
        /// <param name="aReqDate"></param>
        /// <param name="aReqGwa"></param>
        /// <param name="aReqDoctor"></param>
        private void OpenScreen_OCS0503U00(string aBbunho, string aReqDate, string aReqGwa, string aReqDoctor)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBbunho);
            openParams.Add("req_date", aReqDate);
            openParams.Add("req_gwa", aReqGwa);
            openParams.Add("req_doctor", aReqDoctor);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0503U00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        /// <summary>
        /// CP 등록화면
        /// </summary>
        private void OpenScreen_OCS6010U00()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("order_date", this.dtpOrderDate.GetDataValue());
            
            XScreen.OpenScreenWithParam(this, "OCSI", "OCS6010U00", ScreenOpenStyle.ResponseSizable, ScreenAlignment.ParentTopLeft, param);
        }

        private void visibleSetToDA()
        {
            if (XScreen.CurrentScreen.ScreenID == "OCS2003P01")
                this.tabInputGubun.SelectedIndex = 0;
        }
        private void postSelectInputGubun(string aInputGubun)
        {
            switch (aInputGubun)
            {
                case "D0": this.tabInputGubun.SelectedIndex = 0; break;
                case "D4": this.tabInputGubun.SelectedIndex = 1; break;
                case "D7": this.tabInputGubun.SelectedIndex = 2; break;
            }
        }

        /// <summary>
        /// 내복약 입력화면 오픈
        /// </summary>
        //private void OpenScreen_OCS0103U10()
        //{
        //    CommonItemCollection param = new CommonItemCollection();

        //    param.Add("order_date", this.dtpOrderDate.GetDataValue());
        //    param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        //    param.Add("io_gubun", IO_Gubun);
        //    if (this.mDoctorLogin || this.mPostApproveYN)
        //        param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
        //    else
        //        param.Add("input_gubun", this.mInputGubun);
        //    param.Add("input_part", this.mInputGwa);

        //    param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
        //    param.Add("patient_info", this.mSelectedPatientInfo);
        //    param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
        //    param.Add("in_data_row", this.layDrugOrder.LayoutTable);
        //    param.Add("caller_screen_id", this.ScreenID);
        //    param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
        //    param.Add("order_mode", OrderVariables.OrderMode.InpOrder);

        //    XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U10", ScreenOpenStyle.ResponseFixed, param);
        //    visibleSetToDA();
        //}

        private void OpenScreen_OCS0103U10(string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layDrugOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);
            
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U10", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        private void OpenScreen_OCS0103U10(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (this.mDoctorLogin || this.mPostApproveYN)
                param.Add("input_gubun", aDw.GetItemString(aCurrentRowNum, "input_gubun_code"));
            else
                param.Add("input_gubun", this.mInputGubun);

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layDrugOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);

            //insert by jc [DataWindowDoubleClickEvent用]
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U10", ScreenOpenStyle.ResponseFixed, param);
        }
        /// <summary>
        /// リハビリオーダ登録画面オープン
        /// リハビリオーダ追加 2012/09/26
        /// </summary>
        private void OpenScreen_OCS0103U11()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
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
                if (this.mDoctorLogin)
                    param.Add("input_gubun", "D0");
                else
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

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U11", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        private void OpenScreen_OCS0103U11(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
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
                if (this.mDoctorLogin)
                    param.Add("input_gubun", "D0");
                else
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
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U11", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        /// <summary>
        /// 주사오더 입력화면 오픈
        /// </summary>
        //private void OpenScreen_OCS0103U12()
        //{
        //    CommonItemCollection param = new CommonItemCollection();

        //    param.Add("order_date", this.dtpOrderDate.GetDataValue());
        //    param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        //    param.Add("io_gubun", IO_Gubun);
        //    if (this.mDoctorLogin || this.mPostApproveYN)
        //        param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
        //    else
        //        param.Add("input_gubun", this.mInputGubun);

        //    param.Add("input_part", this.mInputGwa);
        //    param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
        //    param.Add("patient_info", this.mSelectedPatientInfo);
        //    param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
        //    param.Add("in_data_row", this.layJusaOrder.LayoutTable);
        //    param.Add("caller_screen_id", this.ScreenID);
        //    param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
        //    param.Add("order_mode", OrderVariables.OrderMode.InpOrder);

        //    XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U12", ScreenOpenStyle.ResponseFixed, param);
        //    visibleSetToDA();
        //}

        private void OpenScreen_OCS0103U12(string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);
            
            param.Add("input_gubun", aInputGubun);

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layJusaOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U12", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }

        private void OpenScreen_OCS0103U12(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (this.mDoctorLogin || this.mPostApproveYN)
                param.Add("input_gubun", aDw.GetItemString(aCurrentRowNum, "input_gubun_code"));
            else
                param.Add("input_gubun", this.mInputGubun);

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layJusaOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);
            //insert by jc [DataWindowDoubleClickEvent用]
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U12", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        /// <summary>
        /// 검체검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U13()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            //if (this.mDoctorLogin || this.mPostApproveYN)
            //    param.Add("input_gubun", "D0");
            //else
            //    param.Add("input_gubun", this.mInputGubun);
            //param.Add("input_part", this.mInputGwa);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                if(this.mDoctorLogin)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layCplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U13", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        private void OpenScreen_OCS0103U13(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
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
                if (this.mDoctorLogin)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layCplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);
            //insert by jc [DataWindowDoubleClickEvent用]
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U13", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        /// <summary>
        /// 생리검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U14()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
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
                if (this.mDoctorLogin)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layPfeOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U14", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        private void OpenScreen_OCS0103U14(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
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
                if (this.mDoctorLogin)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layPfeOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);
            //insert by jc [DataWindowDoubleClickEvent用]
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U14", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        /// <summary>
        /// 병리검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U15()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
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
                if (this.mDoctorLogin)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layAplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U15", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        /// <summary>
        /// 방사선오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U16()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
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
                if (this.mDoctorLogin)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layXrtOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U16", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        private void OpenScreen_OCS0103U16(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
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
                if (this.mDoctorLogin)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layXrtOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);
            //insert by jc [DataWindowDoubleClickEvent用]
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U16", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        /// <summary>
        /// 처치오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U17()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
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
                if (this.mDoctorLogin)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layChuchiOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U17", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        private void OpenScreen_OCS0103U17(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
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
                if (this.mDoctorLogin)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layChuchiOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);
            //insert by jc [DataWindowDoubleClickEvent用]
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U17", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        /// <summary>
        /// 수술오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U18()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
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
                if (this.mDoctorLogin)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.laySusulOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U18", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        private void OpenScreen_OCS0103U18(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
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
                if (this.mDoctorLogin)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.laySusulOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);
            //insert by jc [DataWindowDoubleClickEvent用]
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U18", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        /// <summary>
        /// 기타오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U19()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
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
                if (this.mDoctorLogin)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name",    this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layEtcOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U19", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        private void OpenScreen_OCS0103U19(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", this.dtpOrderDate.GetDataValue());
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
                if (this.mDoctorLogin)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.tabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", this.tabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layEtcOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.InpOrder);
            //insert by jc [DataWindowDoubleClickEvent用]
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U19", ScreenOpenStyle.ResponseFixed, param);
            visibleSetToDA();
        }
        /// <summary>
        /// 사용자별 상병입력 
        /// </summary>
        /// <param name="aMemb">사용자</param>
        private void OpenScreen_OCS0204Q00(string aMemb)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("sang_code", "");
            openParams.Add("memb", UserInfo.UserID);

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
            openParams.Add("user_id",  UserInfo.UserID);
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

        private void OpenScreen_OUT0106U00(string aBunho)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "OUTS", "OUT0106U00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_OCS2003U99(string fkinp1001)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("fkinp1001", fkinp1001);
            param.Add("doctor_nurse_gubun", "D");

            XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003U99", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_OCS2003R00(string aBunho, string aFkinp1001, string aInputGubun, string aOrderDate
                                          , string aDoctor, string aGwa, bool aAutoClose)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho"      , aBunho     );
            param.Add("fkinp1001"  , aFkinp1001 );
            param.Add("input_gubun", aInputGubun);
            param.Add("order_date" , aOrderDate );
            param.Add("doctor"     , aDoctor    );
            param.Add("gwa"        , aGwa       );
            param.Add("auto_close" , aAutoClose );

            XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003R00", ScreenOpenStyle.ResponseFixed, param);
        }

        //modify by jc
        //private void OpenScreen_CPL0000Q00(string aBunho)
        //{
        //    CommonItemCollection openParam = new CommonItemCollection();

        //    openParam.Add("bunho", aBunho);

        //    XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, openParam);
        //}
        private void OpenScreen_CPL0000Q01(string aBunho)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", aBunho);
            openParams.Add("send_yn", "Y");
            openParams.Add("close_yn", "Y");

            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q01", ScreenOpenStyle.PopUpFixed, openParams);
        }

        private void OpenScreen_INJ0000Q00(string aBunho)
        {
            CommonItemCollection openParam = new CommonItemCollection();

            openParam.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "INJS", "INJ0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, openParam);
        }

        private void OpenScreen_OCS1003Q05()
        {
            // 처방 입력 가능 여부

            //해당 내원의 처방정보를 가져온다.
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            openParams.Add("gwa", mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());
            openParams.Add("doctor", mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());
            openParams.Add("input_gubun", this.mInputGubun);
            openParams.Add("naewon_date", this.dtpOrderDate.GetDataValue());
            openParams.Add("tel_yn", "%"); // 약만 타러온 환자건도 있다
            openParams.Add("auto_close", false);
            openParams.Add("io_gubun", this.IO_Gubun);
            openParams.Add("childYN", "N");

            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q05", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_ScanViewer(string aBunho)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);

            //XScreen.OpenScreenWithParam(this, "CPLS", "SCANVIEWER", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, param);
            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q00", ScreenOpenStyle.PopUpSizable, ScreenAlignment.ParentTopLeft, param);
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

        //modify by jc
        //private void OpenScreen_CPL2010R02(string aBunho, string aOrderDate, string aInOutGubun, string aOcskey)
        private void OpenScreen_CPL2010R02(string aBunho, string aOrderDate, string aInOutGubun, string aGwa, string aDoctor, string aSpecimen_code, string aAutoPrintYN)
        {
            CommonItemCollection param = new CommonItemCollection();

            //param.Add("bunho", aBunho);
            //param.Add("order_date", aOrderDate);
            //param.Add("in_out_gubun", aInOutGubun);
            //param.Add("ocs_key", aOcskey);

            param.Add("bunho", aBunho);
            param.Add("order_date", aOrderDate);
            param.Add("in_out_gubun", aInOutGubun);
            param.Add("gwa", aGwa);
            param.Add("doctor", aDoctor);
            param.Add("specimen_code", aSpecimen_code);
            param.Add("auto_print_yn", aAutoPrintYN);

            XScreen.OpenScreenWithParam(this, "CPLS", "CPL2010R02", ScreenOpenStyle.ResponseFixed, param);
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

        #endregion

        #region [ 각종 초기화 ]

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
            //    if (this.mOrderBiz.IsGrantOcsInputDoctor(inputid, this.dtpOrderDate.GetDataValue()) == false)
            //    {
            //        MessageBox.Show(XMsg.GetMsg("M002"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //}

            return true;
        }

        // 화면 초기화
        private void InitializeScreen(bool aIsCalledbyOpenning)
        {
            // InputGubun 탭 구성
            this.MakeInputGubunTab();

            // 모드 설정 ( 의사가 로긴한건지, 의사가 아닌 다른사람들이 로긴한건지 판단 )
            if (UserInfo.UserGubun == UserType.Doctor)
            {
                this.mDoctorLogin = true;
            }
            else
            {
                this.mDoctorLogin = false;
            }

            // 유저의 구분에 따라 보이거나 사라져야 할 로직들...
            this.SettingVisiblebyUser();


            // 다른 화면에서 오픈된경우
            if (this.OpenParam != null)
            {
                mIsCalledbyOtherScreen = true;

                // 내원 일자 
                if (this.OpenParam.Contains("order_date"))
                {
                    this.dtpOrderDate.SetDataValue(this.OpenParam["order_date"].ToString());
                }
                else
                {
                    this.dtpOrderDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
                }

                // 내원키(입워ㅜㄴ키)
                if (this.OpenParam.Contains("naewon_key"))
                {
                    this.mParamNaewonKey = this.OpenParam["naewon_key"].ToString();
                }

                // 환자번호
                if (this.OpenParam.Contains("bunho"))
                {
                    // 환자번호 셋팅후
                    this.fbxBunho.SetEditValue(this.OpenParam["bunho"].ToString());
                    this.fbxBunho.AcceptData();
                }

                // 프로텍트 해야지...파라미터로 담은거니깐...
                //this.dtpOrderDate.Protect = true;
                this.fbxBunho.Protect = true;
            }
            // 독자적 실행
            else
            {
                // 내원일자 디폴트는 오늘로
                this.dtpOrderDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));

                this.InitializeBunho(aIsCalledbyOpenning);

                // 이건 여기서 이ㅣㅂ력받을 수 있으니깐 프로텍트 하면 안되요...
                this.dtpOrderDate.Protect = false;
                this.fbxBunho.Protect = false;

            }

            // 혹시 다른 스크린에서 받아올수 있는지 판단.
            // 이전 스크린의 등록번호를 가져온다
            if (this.fbxBunho.GetDataValue() == "")
            {
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                {
                    // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                    patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                }

                if (patientInfo != null && !TypeCheck.IsNull(patientInfo.BunHo))
                {
                    this.fbxBunho.Focus();
                    this.fbxBunho.SetEditValue(patientInfo.BunHo);
                    this.fbxBunho.AcceptData();
                }
            }

            // 병동 
            this.cboQryHodong.SelectedIndexChanged -= new EventHandler(cboQryHodong_SelectedIndexChanged);
            ReLoadHodongCombo(this.dtpOrderDate.GetDataValue());
            this.cboQryHodong.SelectedIndexChanged += new EventHandler(cboQryHodong_SelectedIndexChanged);
            
            // 진료과 콤보 구성
            ReLoadGwaCombo(this.dtpOrderDate.GetDataValue());

            // 주치의 콤보 구성
            ReLoadDoctorCombo(this.dtpOrderDate.GetDataValue(), this.cboQryGwa.GetDataValue());

            // 내원자 리스트 조회
            PatientListQuery(this.dtpOrderDate.GetDataValue(), this.cboQryHodong.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());

            //// InputGubun 탭 구성
            //this.MakeInputGubunTab();

            PostCallHelper.PostCall(new PostMethod(PostOpenEvent));
            //// InputTab 탭 구성
            //this.MakeInputTab();

        }
        private void PostOpenEvent()
        {
            // InputTab 탭 구성 -- 사이즈 계산을 제대로 못함. 여기서 해야함
            this.MakeInputTab();
        }

        // 환자번호 초기화시 설정파일
        private void InitializeBunho(bool aIsCalledbyOpening)
        {
            
            ClearPatientInfoLabel();
            //this.mParamNaewonKey = "";
            this.mSelectedPatientInfo.ClearPatientInfo();

            //
            if(this.mIsCalledbyOtherScreen == false)
                this.fbxBunho.SetDataValue("");

            //insert by jc START
            this.cboOutSang.ComboItems.Clear();
            this.cboOutSang.RefreshComboItems();
            this.cboJinryoGwa.ComboItems.Clear();
            this.cboJinryoGwa.RefreshComboItems();
            //insert by jc END

            this.paInfoBox.Reset();

            // 각종 YN 클리어 ( 껌뻑이는 컨트롤 )
            this.pbxIsNoAnwerOfConsulted.Visible = false;
            //this.pbxEtcJubsu.Visible = false;
            this.pbxExistBunhoComment.Visible = false;
            //this.pbxInpReserYN.Visible = false;
            this.pbxCpPatient.Visible = false;
            this.pbxToiwonRes.Visible = false;
            this.pbxIsNoConfirmOfReturnedConsult.Visible = false;

            this.pbxVital.Visible = false;

            // 코맨트 패널 visible false
            //this.pnlComment.Visible = false;

            this.InitializeOrderInfo();

            if (aIsCalledbyOpening == false)
            {
                //this.mParamNaewonKey 
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
            // 상병그리드 클리어
            this.grdOutSang.Reset();

            // 상병 콤보박스 클리어
            this.cboOutSang.ComboItems.Clear();

            // 오더정보 클리어
            try
            {
                this.ClearInputGubunColor();
                this.ClearOrderData();
                this.dwOrderInfo.Reset();

                
            }
            catch { }

            this.layDeletedData.Reset();

            this.layDisplayLayout.Reset();

            this.layDrugOrder.Reset();

        }

        private void ClearInputGubunColor()
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabInputGubun.TabPages)
            {
                tpg.TitleTextColor = this.mNormalInputGubunColor.Color;
            }
        }

        // 입력탭 라디오 동적 구성
        private void MakeInputTab()
        {
            MultiLayout dtLayout = new MultiLayout();

            dtLayout = this.mOrderBiz.LoadComboDataSource("code", "INPUT_TAB");
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

                rbnButton.Text = "全体";
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
                //insert by jc
                if (dr["code_name"].ToString() != "複合")
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

                mInputGubun.QuerySQL = @"SELECT 'DA', '全体', 0
                                           FROM OCS0132 
                                          UNION
                                         SELECT A.CODE, A.CODE_NAME, A.SORT_KEY
                                           FROM OCS0132 A
                                          WHERE A.CODE_TYPE LIKE 'INPUT_GUBUN' 
                                            AND A.CODE LIKE 'D%' 
                                            AND A.HOSP_CODE = '" + EnvironInfo.HospCode + @"' 
                                            AND A.VALUE_POINT = '1'  -- 画面上表示
                                          ORDER BY 3
                                            ";
            }
            else if (EnvironInfo.CurrSystemID == "NURO" || EnvironInfo.CurrSystemID == "NURI")
            {
                mInputGubun.QuerySQL = "SELECT CODE, CODE_NAME "
                                     + "  FROM OCS0132 "
                                     + " WHERE CODE_TYPE LIKE 'INPUT_GUBUN' "
                                     + "   AND CODE LIKE 'NR' "
                                     + "   AND HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                                     + "   AND VALUE_POINT = '1' " // 画面上表示
                                     + " ORDER BY SORT_KEY, CODE ";
            }
            // 기타유저인경우
            else
            {
                mInputGubun.QuerySQL = "SELECT CODE, CODE_NAME "
                                     + "  FROM OCS0132 "
                                     + " WHERE CODE_TYPE LIKE 'INPUT_GUBUN' "
                                     + "   AND CODE LIKE '" + this.mInputGubun + "' "
                                     + "   AND HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                                     + "   AND VALUE_POINT = '1' " // 画面上表示
                                     + " ORDER BY SORT_KEY, CODE ";
            }

            mInputGubun.QueryLayout(true);

            // 입력구분이 없는 유저가 등록된경우
            if (mInputGubun.RowCount <= 0)
            {
                this.mMsg = "該当画面に使用権限がない使用者です。ご確認下さい。（ERR : INPUT_GUBUN ）";
                this.mCap = "使用権限確認";

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
                    tpgInputGubun = new IHIS.X.Magic.Controls.TabPage(dr["code_name"].ToString() + "及び医師オーダ照会");

                tpgInputGubun.Tag = dr["code"].ToString();
                tpgInputGubun.ImageList = this.ImageList;
                tpgInputGubun.ImageIndex = 4;

                this.tabInputGubun.TabPages.Add(tpgInputGubun);
            }

            //if (UserInfo.UserGubun != UserType.Doctor)
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
            aGrid.SetItemValue(aRow, "naewon_date", this.dtpOrderDate.GetDataValue());
            // jubsu_no
            aGrid.SetItemValue(aRow, "jubsu_no", aPatientInfo.GetPatientInfo["jubsu_no"].ToString());
            // last_naewon_date
            aGrid.SetItemValue(aRow, "last_naewon_date", this.dtpOrderDate.GetDataValue());
            // last_doctor
            
            if(UserInfo.Gwa == "CK")
                aGrid.SetItemValue(aRow, "last_doctor", aPatientInfo.GetPatientInfo["approve_doctor"].ToString());
            else 
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
            aGrid.SetItemValue(aRow, "sang_start_date", this.dtpOrderDate.GetDataValue());
            // 診断日
            aGrid.SetItemValue(aRow, "sang_jindan_date", this.dtpOrderDate.GetDataValue());

            aGrid.SetFocusToItem(aRow, "sang_code");
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
                case "fbxBunho":

                    #region 환자번호 벨리데이팅 서비스

                    // 내원일자 입력체크
                    if (this.dtpOrderDate.GetDataValue() == "")
                    {
                        this.mMsg = "先に来院日付を入力して下さい。";
                        this.mCap = "来院日付確認";

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

                    // 스탠다드 번호로 변경 
                    bunho = BizCodeHelper.GetStandardBunHo(e.DataValue);
                    //bunho = e.DataValue;

                    // 각종체크 들어가 주시고....
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    // 환자정보 로드해 봅시다....
                    // 파라미터 셋팅
                    this.mPatientInfoParam.NaewonDate = this.dtpOrderDate.GetDataValue();
                    //this.mPatientInfoParam.NaewonKey  = this.mParamNaewonKey;
                    this.mPatientInfoParam.InputID = this.cboQryDoctor.GetDataValue();
                    this.mPatientInfoParam.IOEGubun = this.IO_Gubun; // 입원
                    this.mPatientInfoParam.Bunho = bunho;

                    if(!this.mDoctorLogin)
                        this.mPatientInfoParam.ApproveDoctor = this.cboQryAppDoctor.GetDataValue();
                    
                    this.mSelectedPatientInfo.Parameter = this.mPatientInfoParam;

                    if (this.mSelectedPatientInfo.LoadPatientInfo(IHIS.OCS.PatientInfo.QueryMode.NawonFullInfo) == false)
                    {
                        this.mMsg = "該当する患者が見つかりません。患者番号を確認してください。";
                        this.mCap = "患者番号確認";

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
                        string cmd = @"SELECT FN_DRG_CONV_BUSEO_CODE(:f_gwa) FROM SYS.DUAL";
                        BindVarCollection bind = new BindVarCollection();
                        // 病棟
                        bind.Add("f_gwa", this.mSelectedPatientInfo.GetPatientInfo["ho_dong"].ToString());
                        object obj = Service.ExecuteScalar(cmd, bind);
                        if (obj != null && obj.ToString() != "")
                            this.mPatientHoDongCode = obj.ToString();
                        // 薬局
                        bind.Add("f_gwa", "DRG");
                        obj = Service.ExecuteScalar(cmd, bind);
                        if (obj != null && obj.ToString() != "")
                            this.mDrgGwaCode = obj.ToString();

                        
                    }

                    // 재원환자 체크 
                    if (this.mOrderBiz.IsJaewonPatient(bunho, true) == false)
                    {
                        this.mMsg = "現在入院中の患者様ではありません。入院オーダは使用できません｡";
                        this.mCap = "患者番号確認";

                        MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.SetMsg(this.mMsg, MsgType.Error);

                        postCallArguments = new Hashtable();

                        ((Hashtable)postCallArguments).Add("success_yn", "N");
                        ((Hashtable)postCallArguments).Add("bunho", bunho);

                        PostCallHelper.PostCall(new PostMethodObject(PostBunhoValidating), postCallArguments);

                        return;
                    }

                    // 기타 사항들 체크 및 visible 셋팅
                    //this.CheckPatientEtcInfo(this.dtpOrderDate.GetDataValue(), bunho
                    //                        , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(), this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());
                    //modify by jc [主治医ではない場合もあるので患者から診療科、ドクターを取得するものではない]
                    this.CheckPatientEtcInfo(this.dtpOrderDate.GetDataValue(), bunho
                                            , UserInfo.Gwa, UserInfo.DoctorID);

                    // 환자정보 라벨들 셋팅
                    this.SetPatientInfoLabel(this.mSelectedPatientInfo.GetPatientInfo);

                    // 환자정보박스
                    this.paInfoBox.SetPatientID(bunho);

                    //insert by jc
                    this.SetToiwonGojiYNforBtn();

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

                    // 未承認オーダーがあれば承認画面POPUP 無ければDOオーダーPOPUP
                    if (this.mDoctorLogin && this.mOrderBiz.GetNotApproveOrderCnt(IO_Gubun, UserInfo.UserID, "Y", "N", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) > 0)
                    {
                        this.btnApprove.PerformClick();
                    }
                    else
                    {
                        // insert by jc [使用者オプションによる表示・非表示] 2013/03/30
                        if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "DO_ORDER_POP_YN", this.IO_Gubun) != "N"
                            && this.mOrderBiz.GetOrderCount(this.IO_Gubun, bunho, this.dtpOrderDate.GetDataValue().ToString()) > 0
                            //&& this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_yn") != "E"
                            )
                        {
                            this.btnDoOrder.PerformClick();
                        }
                    }

                    //患者選択時傷病リストが拡張されてる状態に見せる。2013/07/28
                    if (!this.mIsExpanded)
                        this.btnExpand.PerformClick();
                    if (!this.mIsExpandedSB)
                        this.btnExpandSB.PerformClick();
                    
                    this.setSubutton();

                    this.mPostApproveYN = this.mOrderBiz.getEnablePostApprove("I", this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString());

                    if (this.mPostApproveYN)
                        this.lblApproveFlag.Text = "事後";
                    else
                        this.lblApproveFlag.Text = "事前";

                    break;

                // 내원일자
                case "dtpOrderDate":

                    #region 내원일자 벨리데이팅 

                    if (e.DataValue != "" && this.mDoctorLogin == false)
                    {
                        // 진료과 콤보 재조회
                        this.ReLoadGwaCombo(e.DataValue);

                        // 의사 콤보 재조회
                        //this.ReLoadDoctorCombo(e.DataValue, this.cboQryGwa.GetDataValue());
                    }

                    // 내원자 리스트 조회
                    PatientListQuery(e.DataValue, this.cboQryHodong.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());

                    //this.InitializeBunho(false);

                    postCallArguments = new Hashtable();
                    ((Hashtable)postCallArguments).Add("success_yn", "Y");
                    ((Hashtable)postCallArguments).Add("bunho", this.fbxBunho.GetDataValue());

                    PostCallHelper.PostCall(new PostMethodObject(PostBunhoValidating), postCallArguments);

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

                // insert by jc [使用者オプションによる表示・非表示] 2013/03/30
                if (this.mIsCalledbyOtherScreen == false && this.cbxOpenEmr.Checked)
                    this.btnEMR.PerformClick();

                // insert by jc [使用者オプションによる表示・非表示] 2013/03/30
                if (this.pbxVital.Visible && this.mDoctorLogin && this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "VITALSIGNS_POP_YN", this.IO_Gubun) != "N")
                    this.btnVital.PerformClick();

                this.btnList.PerformClick(FunctionType.Query);
            }
        }

        #endregion

        #region [ 기타 다른 화면 오픈 ]

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

                case "CHT0110Q01" :    // 상병 조회

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("CHT0110"))
                        {
                            this.ApplySangInfo(this.grdOutSang, (MultiLayout)commandParam["CHT0110"], false);
                        }
                    }

                    break;

                case "OCS0204Q00":    // 사용자별 상병조회

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("OCS0205"))
                        {
                            this.ApplySangInfo(this.grdOutSang, (MultiLayout)commandParam["OCS0205"], true);
                        }
                    }

                    break;

                case "CHT0115Q00":

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
                    }

                    break;

                case "OCS0103U10": // 약오더 화면

                    this.setVisible_InputGubun(false);

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("drug_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["drug_order"]);
                            //this.RecieveAndSetOrderInfo(command, (MultiLayout)commandParam["drug_order"]);
                            if (this.mDoctorLogin)
                                this.DislplayOrderDataWindow("DA", this.mCurrentInputTab);
                            else
                                this.DislplayOrderDataWindow(this.mInputGubun, this.mCurrentInputTab);
                        }
                    }
                    this.tabInputGubun.SelectedIndex = 0;

                    break;
                case "OCS0103U11": // リハビリ

                    #region リハビリ

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("reha_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["reha_order"]);
                            if (this.mDoctorLogin)
                                this.DislplayOrderDataWindow("DA", this.mCurrentInputTab);
                            else
                                this.DislplayOrderDataWindow(this.mInputGubun, this.mCurrentInputTab);
                        }
                    }
                    this.tabInputGubun.SelectedIndex = 0;

                    #endregion

                    break;

                case "OCS0103U12": // 주사오더 화면

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("jusa_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["jusa_order"]);
                            //this.RecieveAndSetOrderInfo(command, (MultiLayout)commandParam["jusa_order"]);
                            if (this.mDoctorLogin)
                                this.DislplayOrderDataWindow("DA", this.mCurrentInputTab);
                            else
                                this.DislplayOrderDataWindow(this.mInputGubun, this.mCurrentInputTab);
                        }
                    }
                    this.tabInputGubun.SelectedIndex = 0;

                    break;

                case "OCS0103U13": // 검체검사오더

                    #region 검체검사오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("gumsa_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["gumsa_order"]);
                            //this.RecieveAndSetOrderInfo(command, (MultiLayout)commandParam["gumsa_order"]);
                            if(this.mDoctorLogin)
                                this.DislplayOrderDataWindow("DA", this.mCurrentInputTab);
                            else
                                this.DislplayOrderDataWindow(this.mInputGubun, this.mCurrentInputTab);
                        }
                    }
                    this.tabInputGubun.SelectedIndex = 0;

                    #endregion

                    break;

                case "OCS0103U14": // 생리검사오더

                    #region 생리검사오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("pfe_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["pfe_order"]);
                            //this.RecieveAndSetOrderInfo(command, (MultiLayout)commandParam["pfe_order"]);
                            if (this.mDoctorLogin)
                                this.DislplayOrderDataWindow("DA", this.mCurrentInputTab);
                            else
                                this.DislplayOrderDataWindow(this.mInputGubun, this.mCurrentInputTab);
                        }
                    }
                    this.tabInputGubun.SelectedIndex = 0;

                    #endregion

                    break;

                case "OCS0103U15": // 병리검사오더

                    #region 병리검사오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("apl_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["apl_order"]);
                            //this.RecieveAndSetOrderInfo(command, (MultiLayout)commandParam["apl_order"]);
                            if (this.mDoctorLogin)
                                this.DislplayOrderDataWindow("DA", this.mCurrentInputTab);
                            else
                                this.DislplayOrderDataWindow(this.mInputGubun, this.mCurrentInputTab);
                        }
                    }
                    this.tabInputGubun.SelectedIndex = 0;

                    #endregion

                    break;

                case "OCS0103U16": // 방사선오더

                    #region 방사선오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("xrt_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["xrt_order"]);
                            //this.RecieveAndSetOrderInfo(command, (MultiLayout)commandParam["xrt_order"]);
                            if (this.mDoctorLogin)
                                this.DislplayOrderDataWindow("DA", this.mCurrentInputTab);
                            else
                                this.DislplayOrderDataWindow(this.mInputGubun, this.mCurrentInputTab);
                        }
                    }
                    this.tabInputGubun.SelectedIndex = 0;

                    #endregion

                    break;

                case "OCS0103U17": // 처치오더

                    #region 처치 오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("chuchi_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["chuchi_order"]);
                            //this.RecieveAndSetOrderInfo(command, (MultiLayout)commandParam["chuchi_order"]);
                            if (this.mDoctorLogin)
                                this.DislplayOrderDataWindow("DA", this.mCurrentInputTab);
                            else
                                this.DislplayOrderDataWindow(this.mInputGubun, this.mCurrentInputTab);
                        }
                    }
                    this.tabInputGubun.SelectedIndex = 0;

                    #endregion

                    break;

                case "OCS0103U18": // 수술오더

                    #region 수술오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("susul_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["susul_order"]);
                            //this.RecieveAndSetOrderInfo(command, (MultiLayout)commandParam["susul_order"]);
                            if (this.mDoctorLogin)
                                this.DislplayOrderDataWindow("DA", this.mCurrentInputTab);
                            else
                                this.DislplayOrderDataWindow(this.mInputGubun, this.mCurrentInputTab);
                        }
                    }
                    this.tabInputGubun.SelectedIndex = 0;

                    #endregion

                    break;

                case "OCS0103U19": // 기타오더

                    #region 기타오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("etc_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["etc_order"]);
                            //this.RecieveAndSetOrderInfo(command, (MultiLayout)commandParam["etc_order"]);
                            if (this.mDoctorLogin)
                                this.DislplayOrderDataWindow("DA", this.mCurrentInputTab);
                            else
                                this.DislplayOrderDataWindow(this.mInputGubun, this.mCurrentInputTab);
                        }
                    }
                    this.tabInputGubun.SelectedIndex = 0;

                    #endregion

                    break;

                case "OCS2003U01": // 반납취소화면

                    if (commandParam.Contains("retrieve"))
                    {
                        if (commandParam["retrieve"].ToString() == "Y")
                        {
                            this.btnList.PerformClick(FunctionType.Query);
                        }
                    }

                    break;
                case "OCS0301Q09":
                    string OCS0301Q09_InputGubun = "";
                    if (commandParam.Contains("input_gubun"))
                    {
                        OCS0301Q09_InputGubun = commandParam["input_gubun"].ToString();
                    }

                    if (commandParam.Contains("OCS0303"))
                    {

                        MultiLayout lyOCS0303 = new MultiLayout();
                        this.groupInfo = new Hashtable();
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
                        this.layEtcOrder_Do.Reset();
                        this.layRehaOrder_Do.Reset();
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
                            MessageBox.Show("重複された" + cntDupleSpeciment + "件のオーダは登録対象外としました。");
                        }
                        //insert by jc [通常]

                        if (this.mDoctorLogin || mPostApproveYN)
                            iInputGubun = OCS0301Q09_InputGubun;
                        else
                            iInputGubun = this.mInputGubun;

                        this.mOrderBiz.LoadColumnCodeName("code", "INPUT_GUBUN", iInputGubun, ref this.iInputGubunName);
                        //[分けたオーダを架空する。]



                        //[group情報生成]

                        #region 薬

                        //[group情報生成]
                        if (this.layDrugOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "01";
                            this.INPUTTAB = "01";
                            this.mOrderDate = this.dtpOrderDate.GetDataValue();

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
                            this.mOrderDate = this.dtpOrderDate.GetDataValue();

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
                            this.mOrderDate = this.dtpOrderDate.GetDataValue();

                            //MakeDoOrderGrouping2(this.layCplOrder_Do, this.layCplOrder, this.grdOrder_Cpl, "04", "OCS0103U13", "cpl");
                            if (this.mDoctorLogin || mPostApproveYN)
                                this.ApplyCopyOrderInfoCpl(this.layCplOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Cpl, "D0");
                            else
                                this.ApplyCopyOrderInfoCpl(this.layCplOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Cpl, this.iInputGubun);

                            this.RecieveAndSetOrderInfo("OCS0103U13", this.grdOrder_Cpl);

                        }
                        #endregion


                        #region 生理検査
                        if (this.layPfeOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "05";
                            this.INPUTTAB = "05";
                            this.mOrderDate = this.dtpOrderDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.layPfeOrder_Do, this.layPfeOrder, this.grdOrder_Pfe, "05", "OCS0103U14", "pfe");
                            if (this.mDoctorLogin || mPostApproveYN)
                                this.ApplyCopyOrderInfoPfe(this.layPfeOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Pfe, "D0");
                            else
                                this.ApplyCopyOrderInfoPfe(this.layPfeOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Pfe, this.iInputGubun);

                            this.RecieveAndSetOrderInfo("OCS0103U14", this.grdOrder_Pfe);
                        }
                        #endregion

                        #region 病理検査
                        if (this.layAplOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "06";
                            this.INPUTTAB = "06";
                            this.mOrderDate = this.dtpOrderDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.layAplOrder_Do, this.layAplOrder, this.grdOrder_Apl, "06", "OCS0103U15", "apl");
                            if (this.mDoctorLogin || mPostApproveYN)
                                this.ApplyCopyOrderInfoApl(this.layAplOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Apl, "D0");
                            else
                                this.ApplyCopyOrderInfoApl(this.layAplOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Apl, this.iInputGubun);

                            this.RecieveAndSetOrderInfo("OCS0103U15", this.grdOrder_Apl);
                        }
                        #endregion

                        #region 放射線
                        if (this.layXrtOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "07";
                            this.INPUTTAB = "07";
                            this.mOrderDate = this.dtpOrderDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.layXrtOrder_Do, this.layXrtOrder, this.grdOrder_Xrt, "07", "OCS0103U16", "xrt");
                            if (this.mDoctorLogin || mPostApproveYN)
                                this.ApplyCopyOrderInfoXrt(this.layXrtOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Xrt, "D0");
                            else
                                this.ApplyCopyOrderInfoXrt(this.layXrtOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Xrt, this.iInputGubun);

                            this.RecieveAndSetOrderInfo("OCS0103U16", this.grdOrder_Xrt);
                        }
                        #endregion

                        #region 処置
                        if (this.layChuchiOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "08";
                            this.INPUTTAB = "08";
                            this.mOrderDate = this.dtpOrderDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.layChuchiOrder_Do, this.layChuchiOrder, this.grdOrder_Chuchi, "08", "OCS0103U17", "chuchi");
                            if (this.mDoctorLogin || mPostApproveYN)
                                this.ApplyCopyOrderInfoChuchi(this.layChuchiOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Chuchi, "D0");
                            else
                                this.ApplyCopyOrderInfoChuchi(this.layChuchiOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Chuchi, this.iInputGubun);

                            this.RecieveAndSetOrderInfo("OCS0103U17", this.grdOrder_Chuchi);
                        }
                        #endregion

                        #region 手術
                        if (this.laySusulOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "09";
                            this.INPUTTAB = "09";
                            this.mOrderDate = this.dtpOrderDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.laySusulOrder_Do, this.laySusulOrder, this.grdOrder_Susul, "09", "OCS0103U18", "susul");
                            if (this.mDoctorLogin || mPostApproveYN)
                                this.ApplyCopyOrderInfoSusul(this.laySusulOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Susul, "D0");
                            else
                                this.ApplyCopyOrderInfoSusul(this.laySusulOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Susul, this.iInputGubun);

                            this.RecieveAndSetOrderInfo("OCS0103U18", this.grdOrder_Susul);
                        }
                        #endregion

                        #region リハビリ
                        if (this.layRehaOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "10";
                            this.INPUTTAB = "10";
                            this.mOrderDate = this.dtpOrderDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.layEtcOrder_Do, this.layEtcOrder, this.grdOrder_Etc, "11", "OCS0103U19", "etc");
                            if (this.mDoctorLogin || mPostApproveYN)
                                this.ApplyCopyOrderInfoReha(this.layRehaOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Reha, "D0");
                            else
                                this.ApplyCopyOrderInfoReha(this.layRehaOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Reha, this.iInputGubun);

                            this.RecieveAndSetOrderInfo("OCS0103U11", this.grdOrder_Reha);
                        }
                        #endregion


                        #region その他
                        if (this.layEtcOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "11";
                            this.INPUTTAB = "11";
                            this.mOrderDate = this.dtpOrderDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.layEtcOrder_Do, this.layEtcOrder, this.grdOrder_Etc, "11", "OCS0103U19", "etc");
                            if (this.mDoctorLogin || mPostApproveYN)
                                this.ApplyCopyOrderInfoEtc(this.layEtcOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Etc, "D0");
                            else
                                this.ApplyCopyOrderInfoEtc(this.layEtcOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy, this.grdOrder_Etc, this.iInputGubun);

                            this.RecieveAndSetOrderInfo("OCS0103U19", this.grdOrder_Etc);
                        }
                        #endregion

                        this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                    }
                    break;
                //insert by jc Do オーダSTART
                case "OCS1003Q09":
                    #region Doオーダ
                    string OCS1003Q09_InputGubun = "";
                    if (commandParam != null)
                    {
                        if (commandParam.Contains("input_gubun"))
                        {
                            OCS1003Q09_InputGubun = commandParam["input_gubun"].ToString();
                        }

                        if (commandParam.Contains("OCS1003"))
                        {

                            MultiLayout lyOCS1003 = new MultiLayout();
                            this.groupInfo = new Hashtable();
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
                            this.layRehaOrder_Do.Reset();
                            this.layEtcOrder_Do.Reset();
                            //this.SetVisibleStatusBar(true);
                            //this.InitStatusBar(lyOCS1003.RowCount);
                            //this.SetStatusBar(0);

                            //[各部門毎にオーダを分ける]
                            foreach (DataRow dr in lyOCS1003.LayoutTable.Rows)
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
                                MessageBox.Show("重複された" + cntDupleSpeciment + "件のオーダは登録対象外としました。");
                            }
                            //insert by jc [通常]

                            if (this.mDoctorLogin || mPostApproveYN) 
                                iInputGubun = OCS1003Q09_InputGubun;
                            else
                                iInputGubun = this.mInputGubun;

                            this.mOrderBiz.LoadColumnCodeName("code", "INPUT_GUBUN", iInputGubun, ref this.iInputGubunName);


                            //[分けたオーダを架空する。]

                            #region 薬

                            //[group情報生成]
                            if (this.layDrugOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "01";
                                this.INPUTTAB = "01";
                                this.mOrderDate = this.dtpOrderDate.GetDataValue();

                                this.ApplyCopyOrderInfoDrug(this.layDrugOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Drug);
                                this.RecieveAndSetOrderInfo("OCS0103U10", this.grdOrder_Drug);
                            }
                            #endregion

                            #region 注射
                            if (this.layJusaOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "03";
                                this.INPUTTAB = "03";
                                this.mOrderDate = this.dtpOrderDate.GetDataValue();

                                this.ApplyCopyOrderInfoJusa(this.layJusaOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Jusa);
                                this.RecieveAndSetOrderInfo("OCS0103U12", this.grdOrder_Jusa);
                            }
                            #endregion

                            #region 検体検査

                            if (this.layCplOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "04";
                                this.INPUTTAB = "04";
                                this.mOrderDate = this.dtpOrderDate.GetDataValue();

                                if (this.mDoctorLogin || mPostApproveYN)
                                    this.ApplyCopyOrderInfoCpl(this.layCplOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Cpl, "D0");
                                else
                                    this.ApplyCopyOrderInfoCpl(this.layCplOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Cpl, this.iInputGubun);

                                this.RecieveAndSetOrderInfo("OCS0103U13", this.grdOrder_Cpl);

                            }
                            #endregion


                            #region 生理検査
                            if (this.layPfeOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "05";
                                this.INPUTTAB = "05";
                                this.mOrderDate = this.dtpOrderDate.GetDataValue();

                                if (this.mDoctorLogin || mPostApproveYN)
                                    this.ApplyCopyOrderInfoPfe(this.layPfeOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Pfe, "D0");
                                else
                                    this.ApplyCopyOrderInfoPfe(this.layPfeOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Pfe, this.iInputGubun);

                                this.RecieveAndSetOrderInfo("OCS0103U14", this.grdOrder_Pfe);
                            }
                            #endregion

                            #region 病理検査
                            if (this.layAplOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "06";
                                this.INPUTTAB = "06";
                                this.mOrderDate = this.dtpOrderDate.GetDataValue();

                                if (this.mDoctorLogin || mPostApproveYN)
                                    this.ApplyCopyOrderInfoApl(this.layAplOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Apl, "D0");
                                else
                                    this.ApplyCopyOrderInfoApl(this.layAplOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Apl, this.iInputGubun);

                                this.RecieveAndSetOrderInfo("OCS0103U15", this.grdOrder_Apl);
                            }
                            #endregion

                            #region 放射線
                            if (this.layXrtOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "07";
                                this.INPUTTAB = "07";
                                this.mOrderDate = this.dtpOrderDate.GetDataValue();

                                if (this.mDoctorLogin || mPostApproveYN)
                                    this.ApplyCopyOrderInfoXrt(this.layXrtOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Xrt, "D0");
                                else
                                    this.ApplyCopyOrderInfoXrt(this.layXrtOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Xrt, this.iInputGubun);

                                this.RecieveAndSetOrderInfo("OCS0103U16", this.grdOrder_Xrt);
                            }
                            #endregion

                            #region 処置
                            if (this.layChuchiOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "08";
                                this.INPUTTAB = "08";
                                this.mOrderDate = this.dtpOrderDate.GetDataValue();

                                if (this.mDoctorLogin || mPostApproveYN)
                                    this.ApplyCopyOrderInfoChuchi(this.layChuchiOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Chuchi, "D0");
                                else
                                    this.ApplyCopyOrderInfoChuchi(this.layChuchiOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Chuchi, this.iInputGubun);

                                this.RecieveAndSetOrderInfo("OCS0103U17", this.grdOrder_Chuchi);
                            }
                            #endregion

                            #region 手術
                            if (this.laySusulOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "09";
                                this.INPUTTAB = "09";
                                this.mOrderDate = this.dtpOrderDate.GetDataValue();

                                if (this.mDoctorLogin || mPostApproveYN)
                                    this.ApplyCopyOrderInfoSusul(this.laySusulOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Susul, "D0");
                                else
                                    this.ApplyCopyOrderInfoSusul(this.laySusulOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Susul, this.iInputGubun);

                                this.RecieveAndSetOrderInfo("OCS0103U18", this.grdOrder_Susul);
                            }
                            #endregion

                            #region リハビリ
                            if (this.layRehaOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "10";
                                this.INPUTTAB = "10";
                                this.mOrderDate = this.dtpOrderDate.GetDataValue();

                                if (this.mDoctorLogin || mPostApproveYN)
                                    this.ApplyCopyOrderInfoEtc(this.layRehaOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Reha, "D0");
                                else
                                    this.ApplyCopyOrderInfoEtc(this.layRehaOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Reha, this.iInputGubun);

                                this.RecieveAndSetOrderInfo("OCS0103U11", this.grdOrder_Reha);
                            }
                            #endregion

                            #region その他
                            if (this.layEtcOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "11";
                                this.INPUTTAB = "11";
                                this.mOrderDate = this.dtpOrderDate.GetDataValue();

                                if (this.mDoctorLogin || mPostApproveYN)
                                    this.ApplyCopyOrderInfoEtc(this.layEtcOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Etc, "D0");
                                else
                                    this.ApplyCopyOrderInfoEtc(this.layEtcOrder_Do, HangmogInfo.ExecutiveMode.BeforeOrderCopy, this.grdOrder_Etc, this.iInputGubun);

                                this.RecieveAndSetOrderInfo("OCS0103U19", this.grdOrder_Etc);
                            }
                            #endregion

                            this.DislplayOrderDataWindow(this.tabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);

                        }
                    }
                    break;
                    #endregion
                //insert by jc Do オーダEND

                    case "OCS0503U00":
                        //// insert by jc [返事がない依頼件があるか確認してあれば点滅させて知らせる] 2012/11/09
                        //if (this.mOrderBiz.IsNoReturnConsult(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(),
                        //                                     this.dtpOrderDate.GetDataValue().ToString(),
                        //                                     //this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(),
                        //                                     UserInfo.Gwa,
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
                                                         this.dtpOrderDate.GetDataValue(),
                                                         //this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(),
                                                         UserInfo.Gwa,
                                                         UserInfo.DoctorID,
                                                         IO_Gubun))
                    {
                        this.pbxIsNoAnwerOfConsulted.Visible = true;
                    }
                    else
                        this.pbxIsNoAnwerOfConsulted.Visible = false;
                    break;
            }
            //this.btnList.PerformClick(FunctionType.Query);
            return base.Command(command, commandParam);
        }

        #endregion

        #region 카피 오더의 경우 ( 카피, 셋트, Do 오더의 경우 )

        // aSourceLayout : this.layDrugOrder_Do
        // grdOrder      : this.grdOrder_Drug
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
            this.mHangmogInfo.Parameter.Ho_dong = this.mSelectedPatientInfo.GetPatientInfo["ho_dong"].ToString();
            this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = "Y";

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

        private void ApplyCopyOrderInfoCpl(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode, XEditGrid grdOrder, string zInputGubun)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;

            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = zInputGubun;
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
                this.OrderGridCreateNewRow(-1, grdOrder, zInputGubun);
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
                            && groupInfo["group_ser"].ToString() == grdOrder.GetItemString(i, "group_ser")
                            && grdOrder.GetItemString(i, "input_gubun") == "D0")
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
                        this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder, zInputGubun);
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
                XMessageBox.Show("既に登録されているオーダは対象外として処理しました。", "お知らせ");
            if (mParentList.Count > 0)
                this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList, grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        private void ApplyCopyOrderInfoPfe(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode, XEditGrid grdOrder, string zInputGubun)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;

            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = zInputGubun;
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
                this.OrderGridCreateNewRow(-1, grdOrder, zInputGubun);
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
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder, zInputGubun);
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

        private void ApplyCopyOrderInfoApl(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode, XEditGrid grdOrder, string zInputGubun)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;

            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = zInputGubun;
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
                this.OrderGridCreateNewRow(-1, grdOrder, zInputGubun);
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
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder, zInputGubun);
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

        private void ApplyCopyOrderInfoXrt(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode, XEditGrid grdOrder, string zInputGubun)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;

            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = zInputGubun;
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
                this.OrderGridCreateNewRow(-1, grdOrder, zInputGubun);
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
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder, zInputGubun);
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

        private void ApplyCopyOrderInfoChuchi(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode, XEditGrid grdOrder, string zInputGubun)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;

            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = zInputGubun;
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
                this.OrderGridCreateNewRow(-1, grdOrder, zInputGubun);
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
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder, zInputGubun);
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

        private void ApplyCopyOrderInfoSusul(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode, XEditGrid grdOrder, string zInputGubun)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;

            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = zInputGubun;
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
                this.OrderGridCreateNewRow(-1, grdOrder, zInputGubun);
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
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder, zInputGubun);
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

        // リハビリ
        private void ApplyCopyOrderInfoReha(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode, XEditGrid grdOrder, string zInputGubun)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;

            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = zInputGubun;
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
                this.OrderGridCreateNewRow(-1, grdOrder, zInputGubun);
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
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder, zInputGubun);
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

                string pkocskey = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocskey");
                string str = @"SELECT A.FK_OCS
                                 FROM PHY8002 A 
                                WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"' 
                                  AND A.FK_OCS = " + pkocskey;
                object obj = Service.ExecuteScalar(str);

                if (this.mOrderMode != OrderVariables.OrderMode.SetOrder
                    && this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
                {
                    if (obj == null && grdOrder.GetItemString(settingRow, "specific_comment") != "")
                        grdOrder.DeleteRow(grdOrder.CurrentRowNumber);
                }
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList, grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        private void ApplyCopyOrderInfoEtc(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode, XEditGrid grdOrder, string zInputGubun)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;

            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = zInputGubun;
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
                this.OrderGridCreateNewRow(-1, grdOrder, zInputGubun);
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
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder, zInputGubun);
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



        #region 오더코드 그리드에 셋팅

        #region 카피오더중 현재 그룹으로 합치지 않고 나누어 지는경우의 셋팅
        // aSourceLayout : HangmogInfoから取得したデータ(追加しようとするデータ)
        // aDestGrid     : this.grdOrder_Drug(既存データ)
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
                // この時点でAcceptDataをやらないとBUGが・・・
                aDestGrid.AcceptData();


                for (int i = 0; i < rows.Length; i++)
                {

                    if (i != 0)
                    {
                        this.OrderGridCreateNewRow(-1, aDestGrid);
                        currRow = aDestGrid.CurrentRowNumber;
                    }
                    // この時点でAcceptDataをやらないとBUGが・・・
                    aDestGrid.AcceptData();

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
                            aDestGrid.LayoutTable.Rows[currRow]["nday_yn"] = "N";
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

        // 新規グループ作成
        //private Hashtable MakeNewOrderGroup(MultiLayout aSourceLayout, string gubun)
        //{
        //    Hashtable groupInfo = new Hashtable();

        //    int groupSer = (this.mHangmogInfo.GetMaxGroupSer(aSourceLayout) + 1);
        //    if (groupSer == 1)
        //    {
        //        switch (gubun)
        //        {
        //            case "drug":
        //                groupSer = 101;
        //                break;
        //            case "jusa":
        //                groupSer = 301;
        //                break;
        //            case "cpl":
        //                groupSer = 401;
        //                break;
        //            case "pfe":
        //                groupSer = 501;
        //                break;
        //            case "apl":
        //                groupSer = 601;
        //                break;
        //            case "xrt":
        //                groupSer = 701;
        //                break;
        //            case "chuchi":
        //                groupSer = 801;
        //                break;
        //            case "susul":
        //                groupSer = 901;
        //                break;
        //            case "etc":
        //                groupSer = 1001;
        //                break;
        //        }

        //    }
        //    switch (gubun)
        //    {
        //        case "drug":
        //            groupInfo.Add("bogyong_code", "");
        //            groupInfo.Add("bogyong_name", "");
        //            groupInfo.Add("nalsu", "0");
        //            groupInfo.Add("wonyoi_order_yn", "Y");
        //            break;
        //        case "jusa":
        //            groupInfo.Add("jusa", "");
        //            groupInfo.Add("jusa_name", "");
        //            groupInfo.Add("nalsu", "0");
        //            groupInfo.Add("wonyoi_order_yn", "Y");
        //            break;
        //        case "cpl":
        //        case "pfe":
        //        case "apl":
        //        case "xrt":
        //        case "chuchi":
        //        case "susul":
        //        case "etc":
        //            break;
        //    }
        //    groupInfo.Add("group_ser", groupSer);
        //    groupInfo.Add("group_name", groupSer.ToString() + " グループ");
        //    groupInfo.Add("emergency", "N");


        //    return groupInfo;
        //}

        private Hashtable MakeNewOrderGroup(MultiLayout aSourceLayout, string gubun)
        {
            Hashtable groupInfo = new Hashtable();

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
                                                                     , "OCS2003"));
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

        //private Hashtable MakeNewOrderGroup(XEditGrid aSourceLayout, string gubun)
        //{
        //    Hashtable groupInfo = new Hashtable();

        //    int groupSer = (this.mHangmogInfo.GetMaxGroupSer(aSourceLayout) + 1);
        //    if (groupSer == 1)
        //    {
        //        switch (gubun)
        //        {
        //            case "drug":
        //                groupSer = 101;
        //                break;
        //            case "jusa":
        //                groupSer = 301;
        //                break;
        //            case "cpl":
        //                groupSer = 401;
        //                break;
        //            case "pfe":
        //                groupSer = 501;
        //                break;
        //            case "apl":
        //                groupSer = 601;
        //                break;
        //            case "xrt":
        //                groupSer = 701;
        //                break;
        //            case "chuchi":
        //                groupSer = 801;
        //                break;
        //            case "susul":
        //                groupSer = 901;
        //                break;
        //            case "etc":
        //                groupSer = 1001;
        //                break;
        //        }

        //    }
        //    switch (gubun)
        //    {
        //        case "drug":
        //            groupInfo.Add("bogyong_code", "");
        //            groupInfo.Add("bogyong_name", "");
        //            groupInfo.Add("nalsu", "0");
        //            groupInfo.Add("wonyoi_order_yn", "Y");

        //            break;
        //        case "jusa":
        //            groupInfo.Add("jusa", "");
        //            groupInfo.Add("jusa_name", "");
        //            groupInfo.Add("nalsu", "0");
        //            groupInfo.Add("wonyoi_order_yn", "Y");

        //            break;
        //        case "cpl":
        //        case "pfe":
        //        case "apl":
        //        case "xrt":
        //        case "chuchi":
        //        case "susul":
        //        case "etc":
        //            break;
        //    }
        //    groupInfo.Add("group_ser", groupSer);
        //    groupInfo.Add("group_name", groupSer.ToString() + " グループ");
        //    groupInfo.Add("emergency", "N");

        //    return groupInfo;
        //}

        private Hashtable MakeNewOrderGroup(XEditGrid aSourceLayout, string gubun)
        {
            Hashtable groupInfo = new Hashtable();
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
                                                                     , "OCS2003"));

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

        #region 오더 그리드 신규 로우 생성
        private void OrderGridCreateNewRow(int aRowNumber, XEditGrid grdOrder, string aInputgubun)
        {
            grdOrder.InsertRow(aRowNumber);

            // 그룹 기준 셋팅
            this.GridInitValueSetting(grdOrder, grdOrder.CurrentRowNumber, aInputgubun);
        }

        #endregion

        #region 그리드 신규 로우 초기값 셋팅

        private void GridInitValueSetting(XEditGrid aGrid, int aRowNumber, string aInputgubun)
        {
            string temp = "";
            string tempInputGubun = "";

            // 환자정보
            if ((this.mOrderMode != OrderVariables.OrderMode.SetOrder && this.mOrderMode != OrderVariables.OrderMode.CpSetOrder) && this.mSelectedPatientInfo != null)
            {
                aGrid.SetItemValue(aRowNumber, "bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            }

            // 입력탭 정보
            aGrid.SetItemValue(aRowNumber, "input_tab", INPUTTAB);
            this.mOrderBiz.LoadColumnCodeName("code", "INPUT_TAB", INPUTTAB, ref temp);
            aGrid.SetItemValue(aRowNumber, "input_tab_name", temp);


            aGrid.SetItemValue(aRowNumber, "order_date", this.dtpOrderDate.GetDataValue());
            aGrid.SetItemValue(aRowNumber, "input_part", this.mInputPart);

            this.mOrderBiz.LoadColumnCodeName("code", "INPUT_GUBUN", aInputgubun, ref tempInputGubun);
            aGrid.SetItemValue(aRowNumber, "input_gubun", aInputgubun);
            aGrid.SetItemValue(aRowNumber, "input_gubun_name", tempInputGubun);

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
                    aGrid.SetItemValue(aRowNumber, "input_doctor", this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString());
                    aGrid.SetItemValue(aRowNumber, "input_gwa", this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
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


            aGrid.SetItemValue(aRowNumber, "order_date", this.dtpOrderDate.GetDataValue());
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
                else if (UserInfo.Gwa == "CK")
                {
                    aGrid.SetItemValue(aRowNumber, "input_doctor", this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString());
                    aGrid.SetItemValue(aRowNumber, "input_gwa", this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
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

        #region[検体検査重複チェック]
        private bool IsDupleSpeciment(DataRow dr)
        {
            for (int i = 0; i < this.layCplOrder.RowCount; i++)
            {
                if (layCplOrder.LayoutTable.Rows[i]["hangmog_code"].ToString() == dr["hangmog_code"].ToString()
                    && layCplOrder.LayoutTable.Rows[i]["acting_date"].ToString() == ""
                    && layCplOrder.LayoutTable.Rows[i]["input_gubun"].ToString() == iInputGubun)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region PROGRESS CONTROL
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
        #endregion 

        private void mMenuCycleOrderGubun_Click(object sender, System.EventArgs e)
        {
            IHIS.X.Magic.Menus.MenuCommand btn = sender as IHIS.X.Magic.Menus.MenuCommand;
            ArrayList inList  = new ArrayList();
            ArrayList outList = new ArrayList();
            int currRow = this.grdPatientList.CurrentRowNumber;
            inList.Clear();
            outList.Clear();
            inList.Add(EnvironInfo.HospCode);
            inList.Add(this.grdPatientList.GetItemString(currRow, "bunho"));
            inList.Add(btn.Tag.ToString());

            string spName = "PR_OCS_SET_CYCLE_ORDER_GROUP";

            if (Service.ExecuteProcedure(spName, inList, outList) == false)
            {
                MessageBox.Show(Service.ErrFullMsg, "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                this.grdPatientList.QueryLayout(true);

            this.grdPatientList.SetFocusToItem(currRow, "ho_code_name");
        }

        private void PopUpMenuInputGubunResult_Click(object sender, System.EventArgs e)
        {
            IHIS.X.Magic.Menus.MenuCommand btn = sender as IHIS.X.Magic.Menus.MenuCommand;

            if (this.IsGrantOrderUser(btn.Tag.ToString()) == false) return;

            switch (this.mClickedOrderButton)
            {
                case "10":
                    this.OpenScreen_OCS0103U10(btn.Tag.ToString());
                    break;
                case "12":
                    this.OpenScreen_OCS0103U12(btn.Tag.ToString());
                    break;
            }
            
        }

        #region [ 내시경 결과 조회 ]

        // 처방행삭제
        private void PopUpMenuPfeResult_Click(object sender, System.EventArgs e)
        {
            IHIS.X.Magic.Menus.MenuCommand menu = sender as IHIS.X.Magic.Menus.MenuCommand;

            string targetUrl = "";
            string serverIP = "192.168.150.114";

            string cmdText = @"SELECT CODE_NAME
                                 FROM OCS0132
                                WHERE HOSP_CODE '" + EnvironInfo.HospCode + @"'
                                  AND CODE_TYPE = 'SERVER_IP'
                                  AND CODE = 'ENDO'";

            object retVal = Service.ExecuteScalar(cmdText);

            if (!TypeCheck.IsNull(retVal))
            {
                serverIP = retVal.ToString();
            }

            switch (menu.Tag.ToString())
            {
                case "1":     // 이미지 결과 조회

                    try
                    {
                        //targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=" + this.fbxBunho.GetDataValue() + "TYPE=1";

                        //System.Diagnostics.Process.Start(targetUrl);
                    }
                    catch (System.ComponentModel.Win32Exception noBrowser)
                    {
                        MessageBox.Show("browser msg : " + noBrowser.Message);
                    }
                    catch (System.Exception other)
                    {
                        MessageBox.Show("other msg : " + other.Message);
                    }

                    break;

                case "2":

                    try
                    {
                        //targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=" + this.fbxBunho.GetDataValue() + "TYPE=2";

                        //System.Diagnostics.Process.Start(targetUrl);
                    }
                    catch (System.ComponentModel.Win32Exception noBrowser)
                    {
                        MessageBox.Show("browser msg : " + noBrowser.Message);
                    }
                    catch (System.Exception other)
                    {
                        MessageBox.Show("other msg : " + other.Message);
                    }


                    break;   // 레포트 결과 조회

                case "3":    // 심전도 결과 조회

                    if (this.IsPatientSelected() == true)
                    {
                        EkgCallHelper.CallViewer(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
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

        #region [ 검체검사 결과 조회 ]

        private void btnCplResult_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            if (this.mSelectedPatientInfo != null &&
                this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                //modify bj jc
                this.OpenScreen_CPL0000Q01(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
                //this.OpenScreen_CPL0000Q00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            }
        }

        #endregion

        #region [ 이미지 결과 조회 ]

        private void btnImageResult_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_ScanViewer(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        }

        #endregion

        #region [ 주사 경과 기록 ]

        private void btnJusaResult_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            if (this.mSelectedPatientInfo != null &&
                this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                this.OpenScreen_INJ0000Q00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            }
        }

        #endregion

        #region [ 방사선 결과 조회 ]

        private void btnXRTResult_Click_1(object sender, EventArgs e)
        {
            if (this.IsPatientSelected())
            {
                this.OpenScreen_XRT0000Q00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            }
        }

        #endregion

        #region [ 신체계측 조회 ]

        private void btnVital_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_NUR7001U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        }

        #endregion

        #region [ EMR 실행 ]

        private void btnEMR_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected())
            {
                IHIS.Framework.EMRHelper.ExecuteEMR(EMRIOTGubun.IN, this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                   , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                                   , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                                   , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                                   , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            }
        }

        #endregion

        #region [group_ser重複除去 注射のみ]
        private void SetSameOrderDateGroupSer(XEditGrid grd)
        {
            bool isSameGroupSer = false;           
            //[現在登録されているGROUP_SERリスト取得]
            MultiLayout GroupSerList = new MultiLayout();
            GroupSerList.LayoutItems.Add("group_ser", DataType.String);
            GroupSerList.InitializeLayoutTable();

            GroupSerList.QuerySQL = @"select distinct(a.group_ser) group_ser
                                        from ocs2003 a 
                                       where a.hosp_code    = :f_hosp_code
                                         and a.order_date   = :f_order_date
                                         and a.input_tab    = :f_input_tab
                                         and a.dc_yn       != 'Y' 
                                         and a.bannab_yn   != 'Y'
                                         and a.bunho        = :f_bunho
                                         and a.input_doctor = :f_input_doctor
                                         and a.acting_date is null
                                         and a.group_ser not in (select distinct(b.group_ser) 
                                                                   from ocs2003 b 
					                                              where b.hosp_cdoe    = a.hosp_code
                                                                    and b.order_date   = :f_order_date
					                                                and b.input_tab    = :f_input_tab
					                                                and b.bunho        = :f_bunho
					                                                and b.input_doctor = :f_input_doctor)
                                         order by a.group_ser";

            GroupSerList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            GroupSerList.SetBindVarValue("f_order_date", this.dtpOrderDate.GetDataValue());
            GroupSerList.SetBindVarValue("f_input_tab", "03");
            GroupSerList.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue());
            GroupSerList.SetBindVarValue("f_input_doctor", UserInfo.DoctorID);

            if (GroupSerList.QueryLayout(false) == false) return;
            for (int i = 0; i < grd.RowCount; i++)
            {
                isSameGroupSer = false;

                for (int j = 0; j < GroupSerList.RowCount; j++)
                {
                    // 既に施行されたオーダは対象外とする。pkocskeyがnullであるオーダだけをチェックを行う。（保存されてないオーダだけ）
                    if (grd.GetItemString(i, "acting_date") == "" 
                        && grd.GetItemString(i, "group_ser") == GroupSerList.GetItemString(j, "group_ser")
                        && grd.GetRowState(i) == DataRowState.Added
                        && grd.GetItemString(i, "pkocskey") == "")
                    {
                        isSameGroupSer = true;
                        break;
                    }
                }

                if (isSameGroupSer == true)
                {
                    string str = grd.GetItemString(i, "group_ser");
                    int max_group_ser = int.Parse(GroupSerList.GetItemString(GroupSerList.RowCount - 1, "group_ser")) + 1 > (MaxGroup_ser("03", grd)) + 1 ? int.Parse(GroupSerList.GetItemString(GroupSerList.RowCount - 1, "group_ser")) + 1 : (MaxGroup_ser("03", grd)) + 1;
                    
                    for (int k = 0; k < grd.RowCount; k++)
                    {
                        if (grd.GetItemString(k, "group_ser") == str && grd.GetItemString(k, "acting_date") == "")
                        {
                            grd.SetItemValue(k, "group_ser", max_group_ser);
                            grd.AcceptData();
                        }
                    }
                }
            }

        }

        private void SetSameOrderDateGroupSer(MultiLayout grd)
        {
            bool isSameGroupSer = false;
            //[現在登録されているGROUP_SERリスト取得]
            MultiLayout GroupSerList = new MultiLayout();
            GroupSerList.LayoutItems.Add("group_ser", DataType.String);
            GroupSerList.InitializeLayoutTable();

            GroupSerList.QuerySQL = @"select distinct(a.group_ser) group_ser
                                        from ocs2003 a 
                                       where a.hosp_code    = :f_hosp_code
                                         and a.order_date   = :f_order_date
                                         and a.input_tab    = :f_input_tab
                                         and a.dc_yn       != 'Y' 
                                         and a.bannab_yn   != 'Y'
                                         and a.bunho        = :f_bunho
                                         and a.input_doctor = :f_input_doctor
                                         and a.acting_date is null
                                         and a.group_ser not in (select distinct(b.group_ser) 
                                                                   from ocs2003 b 
					                                              where b.hosp_cdoe    = :f_hosp_code 
                                                                    and b.order_date   = :f_order_date
					                                                and b.input_tab    = :f_input_tab
					                                                and b.bunho        = :f_bunho
					                                                and b.input_doctor = :f_input_doctor)
                                         order by a.group_ser";

            GroupSerList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            GroupSerList.SetBindVarValue("f_order_date", this.dtpOrderDate.GetDataValue());
            GroupSerList.SetBindVarValue("f_input_tab", "03");
            GroupSerList.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue());
            GroupSerList.SetBindVarValue("f_input_doctor", UserInfo.DoctorID);

            if (GroupSerList.QueryLayout(false) == false) return;
            for (int i = 0; i < grd.RowCount; i++)
            {
                isSameGroupSer = false;

                for (int j = 0; j < GroupSerList.RowCount; j++)
                {
                    // 既に施行されたオーダは対象外とする。pkocskeyがnullであるオーダだけをチェックを行う。（保存されてないオーダだけ）
                    if (grd.GetItemString(i, "acting_date") == ""
                        && grd.GetItemString(i, "group_ser") == GroupSerList.GetItemString(j, "group_ser")
                        && grd.LayoutTable.Rows[i].RowState == DataRowState.Added
                        && grd.GetItemString(i, "pkocskey") == "")
                    {
                        isSameGroupSer = true;
                        break;
                    }
                }

                if (isSameGroupSer == true)
                {
                    string str = grd.GetItemString(i, "group_ser");
                    int max_group_ser = int.Parse(GroupSerList.GetItemString(GroupSerList.RowCount - 1, "group_ser")) + 1 > (MaxGroup_ser("03", grd)) + 1 ? int.Parse(GroupSerList.GetItemString(GroupSerList.RowCount - 1, "group_ser")) + 1 : (MaxGroup_ser("03", grd)) + 1;

                    for (int k = 0; k < grd.RowCount; k++)
                    {
                        if (grd.GetItemString(k, "group_ser") == str && grd.GetItemString(k, "acting_date") == "")
                        {
                            grd.SetItemValue(k, "group_ser", max_group_ser);
                            grd.AcceptData();
                        }
                    }
                }
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
        private int MaxGroup_ser(string aInput_tab, XEditGrid aLayout)
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

        #region [환자정보 Reques/Receive Event]
        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            if (info != null && !TypeCheck.IsNull(info.BunHo))
            {
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

        private void xPanel3_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right && this.btnDoOrder.Visible == false)
            //{
            //    this.btnDoOrder.Visible = true;
            //    this.btnSetOrder.Visible = true;
            //}
            //else if (e.Button == MouseButtons.Right && this.btnDoOrder.Visible == true)
            //{
            //    this.btnDoOrder.Visible = false;
            //    this.btnSetOrder.Visible = false;
            //}
        }

        private void btnDoOrder_Click(object sender, EventArgs e)
        {
            //if (!this.IsPatientSelected()) return;

            if (mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                this.mOrderMode = OrderVariables.OrderMode.InpOrder;
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

            openParams.Add("input_gubun", this.mInputGubun);
            openParams.Add("naewon_date", this.dtpOrderDate.GetDataValue());
            
            //openParams.Add("tel_yn"     , "N"); // 간호 입력분은 뺀다 
            openParams.Add("tel_yn", "%"); // 약만 타러온 환자건도 있다

            openParams.Add("auto_close", aIsAutoClose);
            //openParams.Add("input_tab", "01");
            openParams.Add("io_gubun", this.IO_Gubun);

            openParams.Add("childYN", "N");
            openParams.Add("patient_info", this.mSelectedPatientInfo);

            //전처방조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q09", ScreenOpenStyle.ResponseSizable, openParams);
            visibleSetToDA();
        }

        private void btnSetOrder_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            if (mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                this.mOrderMode = OrderVariables.OrderMode.InpOrder;
                this.OpenScreen_OCS0301Q09(false);
            }            
        }

        private void btnSetDirect_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            if (mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                this.mOrderMode = OrderVariables.OrderMode.InpOrder;
                this.OpenScreen_OCS0301Q09_Direct(false);
            }
        }

        private void OpenScreen_OCS0301Q09_Direct(bool aIsAutoClose)
        {

            string naewon_date = this.dtpOrderDate.GetDataValue().PadRight(10).Substring(0, 10).Replace("-", "/");
            
            string path = "";

            this.mOrderBiz.LoadColumnCodeName("code", "SET_DIRECT_PATH", UserInfo.UserID, ref path);

            if(path == "")
                this.mOrderBiz.LoadColumnCodeName("code", "SET_DIRECT_PATH", "ALL", ref path);

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("memb", (UserInfo.UserGubun == UserType.Doctor ? UserInfo.DoctorID : UserInfo.UserID));
            openParams.Add("input_tab", "%");
            if (UserInfo.UserGubun == UserType.Doctor)
                openParams.Add("gwa", UserInfo.Gwa);
            else if (UserInfo.UserGubun == UserType.Nurse)
                openParams.Add("gwa", TypeCheck.NVL(UserInfo.HoDong, UserInfo.Gwa));
            openParams.Add("io_gubun", "I");

            openParams.Add("direct_path", path);
            //약속코드조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0301Q09", ScreenOpenStyle.ResponseSizable, openParams);
            visibleSetToDA();

        }

        private void OpenScreen_OCS0301Q09(bool aIsAutoClose)
        {

            string naewon_date = this.dtpOrderDate.GetDataValue().PadRight(10).Substring(0, 10).Replace("-", "/");

            CommonItemCollection openParams = new CommonItemCollection();
            //openParams.Add("memb", (UserInfo.UserGubun == UserType.Doctor ? UserInfo.DoctorID : UserInfo.UserID));

            openParams.Add("input_tab", "%");

            if (UserInfo.UserGubun == UserType.Doctor)
            {
                openParams.Add("memb", UserInfo.DoctorID);
                openParams.Add("gwa", UserInfo.Gwa);
            }
            else if (UserInfo.UserGubun == UserType.Nurse)
            {
                openParams.Add("gwa", TypeCheck.NVL(UserInfo.HoDong, UserInfo.Gwa));
                openParams.Add("memb", UserInfo.UserID);
            }
            else if (this.mInputGubun == "CK")
            {
                openParams.Add("gwa", this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
                openParams.Add("memb", this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString());
            }
            else
            {
                openParams.Add("gwa", TypeCheck.NVL(UserInfo.HoDong, UserInfo.Gwa));
                openParams.Add("memb", UserInfo.UserID);
            }

            //else
            //    openParams.Add("gwa", TypeCheck.NVL(this.mInputPart, UserInfo.Gwa));

            openParams.Add("io_gubun", "I");

            openParams.Add("input_gubun", this.mInputGubun);
            openParams.Add("naewon_key", mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            openParams.Add("patient_info", this.mSelectedPatientInfo);
            
            //약속코드조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0301Q09", ScreenOpenStyle.ResponseSizable, openParams);
            visibleSetToDA();

        }

        private void cboJinryoGwa_SelectedValueChanged(object sender, EventArgs e)
        {
            // 환자상병조회
            this.LoadOutSang(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                            , this.dtpOrderDate.GetDataValue()
                            , this.cboJinryoGwa.GetDataValue().ToString());
        }

        private void dwOrderInfo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Sybase.DataWindow.ObjectAtPointer oap = dwOrderInfo.ObjectUnderMouse;
                int row = oap.RowNumber;
                int startRowNum = -1;
                string colname, reser_yn, data_col, suntak_yn = "N", groupSer, groupSerSubStr, order_gubun, input_tab = "", bogyong_code_yn, pkocskey, hangmog_code = "";

                colname = oap.Gob.Name;

                //XMessageBox.Show("行" + row + "、hangmog_code：" + dwOrderInfo.GetItemString(row, "hangmog_code"));
                if (colname == "hangmog_name" || colname == "order_info" || colname == "order_detail")
                {
                    if (dwOrderInfo.GetItemString(row, colname).Trim() == "") return;
                    input_tab = dwOrderInfo.GetItemString(row, "input_tab");
                    bogyong_code_yn = dwOrderInfo.GetItemString(row, "bogyong_code_yn");
                    if (bogyong_code_yn == "N")
                    {
                        //XMessageBox.Show("行" + row + "、pkocskey：" + dwOrderInfo.GetItemString(row, "pkocskey"));
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
                            //insert by jc string 調合してパラメーターとして送る。
                            OpenScreen_OCS0103U10(dwOrderInfo, row, colname);
                            break;
                        case "03":
                            OpenScreen_OCS0103U12(dwOrderInfo, row, colname);
                            break;
                        case "04":
                            OpenScreen_OCS0103U13(dwOrderInfo, row, colname);
                            break;
                        case "05":
                            OpenScreen_OCS0103U14(dwOrderInfo, row, colname);
                            break;
                        case "06":
                            XMessageBox.Show("病理検査" + colname);
                            break;
                        case "07":
                            OpenScreen_OCS0103U16(dwOrderInfo, row, colname);
                            break;
                        case "08":
                            OpenScreen_OCS0103U17(dwOrderInfo, row, colname);
                            break;
                        case "09":
                            OpenScreen_OCS0103U18(dwOrderInfo, row, colname);
                            break;
                        // リハビリオーダ追加 2012/11/22
                        case "10":
                            OpenScreen_OCS0103U11(dwOrderInfo, row, colname);
                            break;
                        case "11":
                            OpenScreen_OCS0103U19(dwOrderInfo, row, colname);
                            break;

                    }
                }

            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);

            }
        }

        private void dwOrderInfo_Click(object sender, EventArgs e)
        {

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

                    for (int i = 0; i < this.grdOutSang.RowCount; i++)
                    {
                        if (this.grdOutSang.GetItemString(i, "sang_code") == "" && this.grdOutSang.GetItemString(i, "sang_name") == "")
                        {
                            this.grdOutSang.SetFocusToItem(i, "sang_code");
                            return;
                        }
                    }

                    int newRow = -1;
                    // 상병 로우 생성 
                    newRow = this.grdOutSang.InsertRow(-1);

                    // 상병 로우의 초기화
                    this.InitializeSangGrid(this.grdOutSang, this.mSelectedPatientInfo, newRow);

                    break;
            }
        }

        //診療依頼件があるのかチェック 2012/09/10
        private void btnConsultAnswer_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            //if (!this.pbxConsultAnswer.Visible) return;

            if (this.IsGrantOrderUser() == false) return;

            this.OpenScreen_OCS0503U01(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                      , this.dtpOrderDate.GetDataValue().ToString()
                                      , UserInfo.Gwa
                                      , UserInfo.DoctorID);
        }

        private void btnReha_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;
            bool checkflg = false;
            for (int i = 0; i < this.grdOutSang.RowCount; i++)
            {
                //if (this.grdOutSang.LayoutTable.Rows[i].RowState == DataRowState.Unchanged)
                if (this.grdOutSang.GetRowState(i) == DataRowState.Unchanged)
                {
                    checkflg = true;
                    break;
                }
                else
                {
                    if (this.grdOutSang.SaveLayout() == false)
                    {
                        this.mMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg;  // 저장에 실패하였습니다 + 에러메세지...

                        MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkflg = false;
                        break;
                    }
                    else
                    {
                        checkflg = true;
                        break;
                    }
                }

            }
            if (checkflg)
            {
                if (this.IsGrantOrderUser(this.tabInputGubun.SelectedTab.Tag.ToString()) == false) return;

                this.OpenScreen_OCS0103U11();
            }
            else
            {
                XMessageBox.Show("リハビリ依頼を出す際には一つ以上の傷病が必要とされますので傷病を登録した後でやり直してください。\nまたは傷病を保存してください。", "確認");
                this.btnListSB.PerformClick(FunctionType.Insert);
            }
        }

        //insert by jc [未コード化傷病対応]
        private void grdOutSang_Validated(object sender, EventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            int currentRow = grd.CurrentRowNumber;
            if (grd.CurrentColName == "display_sang_name" && this.grdOutSang.GetItemString(currentRow, "sang_code") == NotCodeSyoubyou)
            {
                this.grdOutSang.SetItemValue(currentRow, "sang_name", this.grdOutSang.GetItemString(currentRow, "display_sang_name"));
            }
        }

        private void btnRehaActedOrder_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_OCS1003Q10(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(), this.dtpOrderDate.GetDataValue());
        }
        private void OpenScreen_OCS1003Q10(string aBunho, string aOrderDate)
        {
            CommonItemCollection openParam = new CommonItemCollection();

            openParam.Add("bunho", aBunho);
            openParam.Add("order_date", aOrderDate);
            openParam.Add("io_gubun", IO_Gubun);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS3003Q10", ScreenOpenStyle.ResponseFixed, openParam);
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            this.fbxBunho.SetEditValue("");
            this.fbxBunho.AcceptData();

            this.dtpOrderDate.SetDataValue(DateTime.Parse(this.dtpOrderDate.GetDataValue()).AddDays(-1));
            this.dtpOrderDate.AcceptData();
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            this.fbxBunho.SetEditValue("");
            this.fbxBunho.AcceptData();

            this.dtpOrderDate.SetDataValue(DateTime.Parse(this.dtpOrderDate.GetDataValue()).AddDays(1));
            this.dtpOrderDate.AcceptData();
            this.btnList.PerformClick(FunctionType.Query);
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

        private void btnSiksa_Click(object sender, EventArgs e)
        {

            string naewon_date = this.dtpOrderDate.GetDataValue().PadRight(10).Substring(0, 10).Replace("-", "/");

            CommonItemCollection openParams = new CommonItemCollection();
            
            openParams.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());

            if(this.mSelectedPatientInfo.GetPatientInfo[41].ToString() == "")
                openParams.Add("hodong", "EMPTY");
            else
                openParams.Add("hodong", this.mSelectedPatientInfo.GetPatientInfo[41].ToString());

            if(this.mSelectedPatientInfo.GetPatientInfo[42].ToString() == "")
                openParams.Add("hocode", "EMPTY");
            else
                openParams.Add("hocode", this.mSelectedPatientInfo.GetPatientInfo[42].ToString());
            
            //약속코드조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS2005U02", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (mIsCalledbyOtherScreen)
            {
                this.Close();
            }
        }

        private void btnKensaReser_Click(object sender, EventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            openParams.Add("gwa", this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());
            openParams.Add("naewon_date", this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString());
            openParams.Add("caller_name", "OCS2003P01");
            //약속코드조회 화면 Open
            XScreen.OpenScreenWithParam(this, "SCHS", "SCH0201U99", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void btnSangCopy_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            if (mSelectedPatientInfo != null && mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("io_gubun", "O");
                openParams.Add("bunho", this.fbxBunho.GetDataValue());
                openParams.Add("gwa", "%");
                openParams.Add("naewon_date", this.dtpOrderDate.GetDataValue());

                XScreen.OpenScreenWithParam(this, "OCSO", "OUTSANGU00", ScreenOpenStyle.ResponseSizable, openParams);
            
            }

            this.btnList.PerformClick(FunctionType.Query);
        }

        private void cboQryHodong_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        //private void btnInputGubun_Click(object sender, EventArgs e)
        //{
        //    Control ctl = sender as Control;
        //    OpenScreen_OCS0103U10(ctl.Tag.ToString());
        //    this.setVisible_InputGubun(false);

        //    switch (ctl.Tag.ToString())
        //    {
        //        case "D0":
        //            this.tabInputGubun.SelectedIndex = 0;
        //            break;
        //        case "D4":
        //            this.tabInputGubun.SelectedIndex = 1;
        //            break;
        //        case "D7":
        //            this.tabInputGubun.SelectedIndex = 2;
        //            break;
        //    }
            
        //}

        //private void rbtInputGubun_Click(object sender, EventArgs e)
        //{
        //    Control ctl = sender as Control;
        //    OpenScreen_OCS0103U10(ctl.Tag.ToString());
        //    this.setVisible_InputGubun(false);

        //    switch (ctl.Tag.ToString())
        //    {
        //        case "D0":
        //            this.tabInputGubun.SelectedIndex = 0;
        //            break;
        //        case "D4":
        //            this.tabInputGubun.SelectedIndex = 1;
        //            break;
        //        case "D7":
        //            this.tabInputGubun.SelectedIndex = 2;
        //            break;
        //    }
        //}

        private void btnAll_Click(object sender, EventArgs e)
        {
            XButton btn = sender as XButton;
            
            this.btnAll.BackColor = Color.Black;
            this.btnA.BackColor = Color.Black;
            this.btnB.BackColor = Color.Black;
            this.btnC2.BackColor = Color.Black;
            this.btnC3.BackColor = Color.Black;

            this.cboQryHodong.SelectedValue = btn.Tag.ToString();
            
            btn.BackColor = Color.Red;
        }

        private void grdOrder_Drug_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            //XMessageBox.Show(e.ColName + "   /   " + e.DataRow[e.ColName].ToString() + "   /   " + e.ChangeValue.ToString() + " / " + e.RowNumber);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            this.OpenScreen_OCSAPPROVE(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());

            this.pbxApprove.Visible = this.mOrderBiz.GetNotApproveOrderCnt(this.IO_Gubun, UserInfo.UserID, "Y", "N", "%") > 0 ? true : false;
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void OpenScreen_OCSAPPROVE(string aBunho)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBunho);
            openParams.Add("caller_sys_id", this.Name);
            openParams.Add("io_gubun", "I");
            openParams.Add("doctor_id", UserInfo.UserID);
            openParams.Add("fk_io_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            XScreen.OpenScreenWithParam(this, "OCSA", "OCSAPPROVE", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, openParams);
        }

        private void grdPatientList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPatientList.SetBindVarValue("f_doctor_yn", this.mDoctorLogin == true ? "Y":"N");
        }

        private void grdPatientList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.patientListdisplayedcount = this.grdPatientList.DisplayRowCount;
        }

        private void cboQryAppGwa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 닥터콤보 재구성
            this.ReLoadAppDoctorCombo(this.dtpOrderDate.GetDataValue(), this.cboQryAppGwa.GetDataValue());
        }

        private void cboQryAppDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PatientListQuery(this.dtpOrderDate.GetDataValue(), this.cboQryHodong.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());
            this.fbxBunho.SetEditValue("");
            this.fbxBunho.AcceptData();

            this.mPostApproveYN = this.mOrderBiz.getEnablePostApprove("I", this.cboQryAppDoctor.SelectedValue.ToString());

            if (this.mPostApproveYN)
                this.lblApproveFlag.Text = "事後";
            else
                this.lblApproveFlag.Text = "事前";

            this.lblApproveDoctorName.Text = "⇒ " + this.cboQryAppDoctor.ComboItems[this.cboQryAppDoctor.SelectedIndex].DisplayItem;
        }

        private void btnApproveOnOff_Click(object sender, EventArgs e)
        {
            if (this.pnlUser.Visible)
            {
                this.pnlUser.Visible = false;
                this.btnApproveOnOff.ImageIndex = 46; // ↓
            }
            else
            {
                this.pnlUser.Visible = true;
                this.btnApproveOnOff.ImageIndex = 47; // ↑
            }
        }
    }

    #region XSavePeformer
    public class XSavePeformer : ISavePerformer
    {
        private OCS2003P01 parent = null;
        private IHIS.OCS.OrderBiz mOrderBiz = new OrderBiz("OCS2003P01");

        public XSavePeformer(OCS2003P01 parent)
        {
            this.parent = parent;
        }

        public bool Execute(char callerId, RowDataItem item)
        {
            string cmdText = "";
            string spName = "";
            object t_chk = "";
            object reusltSang = "";
            string cmdTextsang = "";
            string changeBeforePKSEQ = "";
            ArrayList inList = new ArrayList();
            ArrayList outList = new ArrayList();

            item.BindVarList.Add("q_user_id", UserInfo.UserID);
            item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
            switch (callerId)
            {
                case '1':   // 상병입력 

                    #region 상병입력

                    switch (item.RowState)
                    {
                        case DataRowState.Added:

                            cmdText = " SELECT MAX(Z.PK_SEQ)+1 PK_SEQ "
                                    + "  FROM OUTSANG Z"
                                    + " WHERE Z.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                                    + "   AND Z.BUNHO     = '" + item.BindVarList["f_bunho"].VarValue + "' "
                                    + "   AND Z.GWA       = '" + item.BindVarList["f_gwa"].VarValue + "' "
                                    + "   AND Z.IO_GUBUN  = '" + item.BindVarList["f_io_gubun"].VarValue + "' ";

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
                                    + "  FROM OUTSANG Z"
                                    + " WHERE Z.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                                    + "   AND Z.BUNHO    = '" + item.BindVarList["f_bunho"].VarValue + "' ";

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
                                XMessageBox.Show("傷病が重複しています。もう一度確認してから登録してください。", "確認");
                                return false;
                            }

                            #endregion

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
                                               FKOUT1001      , SANG_JINDAN_DATE  , DATA_GUBUN    )
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
                                XMessageBox.Show("傷病が重複しています。もう一度確認してから登録してください。", "確認");
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

                                         WHERE HOSP_CODE          = '" + EnvironInfo.HospCode + @"'
                                           AND BUNHO              = :f_bunho   
                                           AND GWA                = '" + parent.mChangeBeforeGwa + @"'      
                                           AND IO_GUBUN           = :f_io_gubun
                                           AND PK_SEQ             = '" + changeBeforePKSEQ + @"'    ";

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
                                //cmdText = " DELETE FROM OUTSANG           "
                                //        + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                                //        + "    AND BUNHO    = :f_bunho    "
                                //        + "    AND GWA      = :f_gwa      "
                                //        + "    AND IO_GUBUN = :f_io_gubun "
                                //        + "    AND PK_SEQ   = :f_pk_seq   ";

                                //break;
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
                                             , DATA_GUBUN         = 'D'

                                         WHERE HOSP_CODE          = '" + EnvironInfo.HospCode + @"'
                                           AND BUNHO              = :f_bunho   
                                           AND GWA                = '" + parent.mChangeBeforeGwa + @"'    
                                           AND IO_GUBUN           = :f_io_gubun
                                           AND PK_SEQ             = '" + changeBeforePKSEQ + @"'  ";
                            }
                            break;
                    }

                    #endregion

                    break;
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
                            MessageBox.Show(Service.ErrFullMsg, "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    if (
                        (  item.BindVarList["f_input_gubun"].VarValue.Substring(1, 1) == "4"
                        || item.BindVarList["f_input_gubun"].VarValue.Substring(1, 1) == "7")

                        && (  item.BindVarList["f_order_gubun"].VarValue.Substring(1, 1) == "B"
                           || item.BindVarList["f_order_gubun"].VarValue.Substring(1, 1) == "C"
                           || item.BindVarList["f_order_gubun"].VarValue.Substring(1, 1) == "D")
                        )
                    {
                        parent.mDeletedOrderCnt++;
                    }

                    if (item.BindVarList["f_instead_yn"].VarValue == "Y")
                    {
                        parent.mInsteadDeletedOrderCnt++;
                    }
                    

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
                                        + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                                        + "    AND BUNHO = '" + item.BindVarList["f_bunho"].VarValue + "' " 
                                        + "    AND FKINP1001 = " + item.BindVarList["f_in_out_key"].VarValue
                                        + "    AND ORDER_DATE = TO_DATE('" + item.BindVarList["f_order_date"].VarValue + "', 'YYYY/MM/DD')  " ;

                                t_chk = Service.ExecuteScalar(cmdText);

                                if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "")
                                {
                                    t_chk = "1";
                                }

                                item.BindVarList.Remove("f_seq");
                                item.BindVarList.Add("f_seq", t_chk.ToString());
                            }

                            item.BindVarList.Add("f_instead_yn", "N");

                            if (parent.mInputGubun == "CK")
                            {
                                item.BindVarList.Add("f_instead_yn"  , "Y");
                                item.BindVarList.Add("f_instead_id"  , UserInfo.UserID);
                                item.BindVarList.Add("f_instead_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                                item.BindVarList.Add("f_instead_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                            }

                            item.BindVarList.Add("f_approve_yn", "N");

                            if(parent.mPostApproveYN)
                                item.BindVarList.Add("f_postapprove_yn", "Y");
                            else
                                item.BindVarList.Add("f_postapprove_yn", "N");

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
                                    + "        POWDER_YN            , HOPE_DATE            , HOPE_TIME         , "
                                    + "        DV_1                 , DV_2                 , DV_3              , DV_4                    ,                         "
                                    + "        DV_5                 , DV_6                 , DV_7              , DV_8                    ,                         "
                                    + "        MIX_GROUP            , ORDER_REMARK          , "
                                    + "        NURSE_REMARK         , BOM_OCCUR_YN         , BOM_SOURCE_KEY    , DISPLAY_YN              , NURSE_CONFIRM_USER    , "
                                    + "        NURSE_CONFIRM_DATE   , NURSE_CONFIRM_TIME   , TEL_YN            , "
                                    + "        REGULAR_YN           , INPUT_TAB            , HUBAL_CHANGE_YN   , PHARMACY                , INPUT_DOCTOR          , "
                                    + "        JUSA_SPD_GUBUN       , DRG_PACK_YN          , SORT_FKOCSKEY     , FKINP1001               , INPUT_GWA             , "
                                    + "        NDAY_OCCUR_YN        , PKOCS1024            , BROUGHT_DRG_YN    , INSTEAD_YN              , INSTEAD_ID            , "
                                    + "        INSTEAD_DATE         , INSTEAD_TIME         , APPROVE_YN        , POSTAPPROVE_YN) "
                                    + " VALUES "
                                    //modify by jc SYSDATE -> parent.mSave_time
                                    + "      ( TO_DATE('" + parent.mSave_time + "', 'YYYY/MM/DD HH24:MI:SS'), :q_user_id           , SYSDATE           , :q_user_id              , :f_hosp_code             , "
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
                                    + "        :f_powder_yn         , :f_hope_date         , :f_hope_time                                , "
                                    + "        :f_dv_1              , :f_dv_2              , :f_dv_3           , :f_dv_4                 , "
                                    + "        :f_dv_5              , :f_dv_6              , :f_dv_7           , :f_dv_8                 , "
                                    + "        :f_mix_group         , :f_order_remark                                                    , "
                                    + "        :f_nurse_remark      , :f_bom_occur_yn      , :f_bom_source_key , 'Y'                     , :f_nurse_confirm_user    , "
                                    + "        :f_nurse_confirm_date, :f_nurse_confirm_time, :f_tel_yn         , "
                                    + "        :f_regular_yn        , :f_input_tab         , :f_hubal_change_yn, :f_pharmacy             , :f_input_doctor          , "
                                    + "        :f_jusa_spd_gubun    , :f_drg_pack_yn       , :f_sort_fkocskey  , :f_in_out_key           , :f_input_gwa             , "
                                    + "        'N'                  , :f_pkocs1024         , :f_brought_drg_yn , :f_instead_yn           , :f_instead_id            , "
                                    + "        :f_instead_date      , :f_instead_time      , :f_approve_yn     , :f_postapprove_yn) ";

                            if (
                                (  item.BindVarList["f_input_gubun"].VarValue.Substring(1, 1) == "4"
                                || item.BindVarList["f_input_gubun"].VarValue.Substring(1, 1) == "7")

                                && (  item.BindVarList["f_order_gubun"].VarValue.Substring(1, 1) == "B"
                                   || item.BindVarList["f_order_gubun"].VarValue.Substring(1, 1) == "C"
                                   || item.BindVarList["f_order_gubun"].VarValue.Substring(1, 1) == "D")
                                )
                            {
                                parent.mInsertedOrderCnt++;
                            }

                            if (item.BindVarList["f_instead_yn"] != null && item.BindVarList["f_instead_yn"].VarValue == "Y")
                            {
                                parent.mInsteadInsertedOrderCnt++;
                            }


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
                                    + "      , GROUP_SER        = :f_group_ser "
                                    + "      , INPUT_GUBUN      = :f_input_gubun "
                                    + "      , BROUGHT_DRG_YN   = :f_brought_drg_yn "
                                    //+ "      , SOURCE_FKOCS2003 = NULL "
                                    + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                                    + "    AND PKOCS2003 = :f_pkocskey ";

                            if (
                                (item.BindVarList["f_input_gubun"].VarValue.Substring(1, 1) == "4"
                                || item.BindVarList["f_input_gubun"].VarValue.Substring(1, 1) == "7")

                                && (item.BindVarList["f_order_gubun"].VarValue.Substring(1, 1) == "B"
                                   || item.BindVarList["f_order_gubun"].VarValue.Substring(1, 1) == "C"
                                   || item.BindVarList["f_order_gubun"].VarValue.Substring(1, 1) == "D")
                                )
                            {
                                parent.mUpdatedOrderCnt++;
                            }

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
            //if (callerId == '3' && isSuccess)
            //{
            //    if (this.mOrderBiz.SaveRegularOrder("2", item.BindVarList["f_pkocskey"].VarValue) == false)
            //    {
            //        isSuccess = false;
            //    }
            //    else
            //    {
            //        isSuccess = true;
            //    }
            //}

            return isSuccess;
        }
    }
    #endregion
}