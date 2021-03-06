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
using IHIS.OCSA.Properties;
using System.Reflection;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using SystemModels = IHIS.CloudConnector.Contracts.Models.System;
using System.Text.RegularExpressions;
using IHIS.CloudConnector.Contracts.Results;

namespace IHIS.OCSA
{
    public partial class OCS0103U16 : XScreen
    {
        #region Constructor
        public OCS0103U16()
        {
           // MessageBox.Show("Constructor start");

            InitializeComponent();
            mainControl = new UCOCS0103U16();
            mainControl.Size = new Size(this.pnlFill.Size.Width, this.pnlFill.Size.Height);
            this.pnlFill.Controls.Add(this.mainControl);
            this.mainControl.MContainer = this;
            this.mainControl.MPnlTop = this.pnlTop;
            this.mainControl.MBtnList = this.btnList;
            this.mainControl.MBtnCopy = this.btnCopy;
            this.mainControl.MBtnPaste = this.btnPaste;
            //this.mainControl.MBtnMix = this.btnMix;
            //this.mainControl.MBtnMixCancel = this.btnMixCancel;
            //this.mainControl.MBtnChangeWonyoi = this.btnChangeWonyoi;
            //this.mainControl.MDbxWonyoiOrderYn = this.dbxWonyoiOrderYN;
            //this.mainControl.MPbxCopy = this.pbxCopy;    

            //MED6991
            InitializeLookAndFeel();
        }

        private void InitializeLookAndFeel()
        {
            if (NetInfo.Language != LangMode.Jr)
            {
                dbxInputGubunName.Width += 10;
            }
        }
        #endregion

        #region 2. Form변수를 정의한다

        private UCOCS0103U16 mainControl;
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
        //private int OrderExtendWidth = 1081;
        private int OrderExtendWidth = 1000;
        //private int OrderNormalWidth = 753;
        private int OrderNormalWidth = 850;
        private bool mIsExtended = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // 조회부분 화면 확장 관련
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //private int OrderMinWidth = 618;
        private int OrderMinWidth = 750;
        private bool mIsSearchExtended = false;

        private int SearchHangmogNameNormalWidth = 329;
        private int SearchHangmogNameMaxWidth = 468;

        //private int SlipHangmogNameNormalWidth = 175;
        private int SlipHangmogNameNormalWidth = 270;
        //private int SlipHangmogNameMaxWidth = 314;
        private int SlipHangmogNameMaxWidth = 385;

        private int SangYongHangmogNormalWidth = 330;
        private int SangYongHangmogMaxWidth = 466;

        ///////////// Order 기본값 /////////////////////////////////////////////////////////////////////////
        private const string INPUTTAB = "07"; // 방사선 (01) 
        private string IOEGUBUN    = "O";     // 입외구분(외래)
        private string mInputGubun = "D0";    // 입력구분(의사처방)
        private string mInputGubunName = "";  // 입력구분명
        private string mInputPart  = "";      // 입력파트
        private string mCallerSysID = "";
        private string mCallerScreenID = "";
        private int mInitialGroupSer = 700;

        //공통
        private string mOrderDate  = "";
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
        private int  mDragX = 0;
        private int  mDragY = 0;
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

        #endregion

        #region Events

        /// <summary>
        /// Screen Open시 Parameter를 받는다 (등록번호 연계)
        /// </summary>
        /// <remarks>
        /// 해당 등록번호와 내원정보로 외래처방 데이타 조회
        /// </remarks>
        private void OCS0103U10_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            mInputGubunName = this.mainControl.ScreenOpen(this.OpenParam);
            this.mainControl.MOpener = (XScreen)this.Opener;

            // 오더일자와 환자번호는 변경할수 없도록 프로텍트 처리
            if (e.OpenParam != null) // 다른 화면에서 콜되는 경우
            {
                if (this.OpenParam.Contains("order_date"))
                {
                    this.dpkOrder_Date.SetDataValue(this.OpenParam["order_date"].ToString());
                }
                else
                {
                    this.dpkOrder_Date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
                }

                // 환자번호
                if (this.OpenParam.Contains("bunho"))
                {
                    this.fbxBunho.SetEditValue(this.OpenParam["bunho"].ToString());
                    this.fbxBunho.AcceptData();
                }

                // 입력구분 셋팅
                if (this.OpenParam.Contains("input_gubun"))
                {
                    this.dbxInputGubunName.SetDataValue("【 " + this.mInputGubunName + " 】");
                }

                // 환자정보
                if (this.OpenParam.Contains("patient_info"))
                {
                    this.SetPatientInfo();
                }

                this.dpkOrder_Date.Protect = true;
                this.fbxBunho.Protect = true;

            }

            //PostCallHelper.PostCall(new PostMethod(PostLoad));

        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            return this.mainControl.Command(command, commandParam);
        }

        private void btnCopy_Click(object sender, System.EventArgs e)
        {
            this.mainControl.HandleBtnCopyClick(false);
        }
        private void btnCut_Click(object sender, System.EventArgs e)
        {
            this.mainControl.HandleBtnCopyClick(true);
        }

        private void btnPaste_Click(object sender, System.EventArgs e)
        {
            this.mainControl.HandleBtnPasteClick();
        }

        private void OCS0103U10_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = false;

        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            this.mainControl.HandleBtnListButtonClick(e.Func);
            e.IsBaseCall = false;
        }

        private void btnList_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender == null) return;

            if (e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control) // 마우스오른쪽클릭 + Ctrl Key 입력시 
            {
                if (this.CurrMQLayout != null) this.mainControl.MOrderBiz.GridDisplayValue((XGrid)this.CurrMQLayout); // 현재 Current Row의 모든 값을 디스플레이한다
            }
        }


        private void btnIlgwalChange_Click(object sender, EventArgs e)
        {
            this.mainControl.btnIlgwalChange_Click(sender, e);
        }

        #endregion (events)

        /// <summary>
        /// 환자정보 라벨 셋팅
        /// </summary>
        private void SetPatientInfo()
        {
            try
            {
                // 환자정보
                this.dbxSuname.SetDataValue(this.mainControl.MPatientInfo.GetPatientInfo["suname"].ToString() + " " + this.mainControl.MPatientInfo.GetPatientInfo["suname2"].ToString());
                // 성별 나이
                this.dbxAge_Sex.SetDataValue(this.mainControl.MPatientInfo.GetPatientInfo["sex_age"].ToString());
                // 보험 이ㅣ름
                this.dbxGubun_name.SetDataValue(this.mainControl.MPatientInfo.GetPatientInfo["gubun_name"].ToString());
                // 진료정보 ( 여기다가 뭘 넣을까.... )

                // 신장, 체중
                this.dbxWeight_height.SetDataValue(this.mainControl.MPatientInfo.GetPatientInfo["weight_height"].ToString());

                //MED-8418
                if (this.mainControl.MPatientInfo.GetPatientInfo["chojae_name"] != null)
                {
                    this.dbxChojae_name.SetDataValue(this.mainControl.MPatientInfo.GetPatientInfo["chojae_name"].ToString());
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("Exception on Method SetPatientInfo: " + ex.StackTrace);
            }
        }
    }
    
}
