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
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.OCSO.Properties;
using PatientInfo = IHIS.OCS.PatientInfo;

#endregion

namespace IHIS.OCSO
{
    /// <summary>
    /// OCS1003Q00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS1003Q09 : IHIS.Framework.XScreen
    {
        #region [OCS Library]
        private IHIS.OCS.OrderBiz mOrderBiz             = null; // OCS 그룹 Business 라이브러리
        private IHIS.OCS.OrderFunc mOrderFunc           = null; // OCS 그룹 Function 라이브러리		
        private IHIS.OCS.HangmogInfo mHangmogInfo       = null; // OCS 항목정보 그룹 라이브러리
        private IHIS.OCS.InputControl mInputControl     = null; // 입력제어 그룹 라이브러리 
        private IHIS.OCS.ColumnControl mColumnControl   = null; // OCS 오더별 컬럼 컨트롤 라이브러리
        private IHIS.OCS.PatientInfo mPatientInfo       = null; // OCS 患者情報

        #endregion

        #region [Instance Variable]
        //Message처리
        string mbxMsg = "", mbxCap = "";

        //등록번호
        private string mBunho = "";
        //진료과
        private string mGwa = "";
        //입력구분
        private string mInput_gubun = "";

        private ArrayList mCanDoArrList = new ArrayList();

        private bool mIsDrugJusa = false;
        //내원일자
        private string mNaewon_date = "";
        //pk_order
        private string mPk_order = "";
        //tel처방여부
        private string mTel_yn = "%";
        //입력오더구분
        private string mInput_tab = "%";

        //Call한 시스템 외래,입원,응급 구분
        private string mIOgubun = "";

        //Data가 없는 경우 화면 닫을지 여부
        private bool mAuto_close = false;

        //신규그룹번호발생여부
        private bool mIsNewGroupSer = true;

        //자식여부
        private string mChildYN = "";

        private IHIS.X.Magic.Menus.PopupMenu popupMenu = new IHIS.X.Magic.Menus.PopupMenu();

        // 팝업메뉴
        private IHIS.X.Magic.Menus.PopupMenu mMenuPFEResult = new IHIS.X.Magic.Menus.PopupMenu();

        //hospital code
        private string mHospCode = EnvironInfo.HospCode;

        /// <summary>
        /// OCS1003Q09LoadComboDataSourceResult
        /// </summary>
        OCS1003Q09LoadComboDataSourceResult _allCboResult = new OCS1003Q09LoadComboDataSourceResult();
        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XMstGrid grdOUT1001;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGrid grdOCS1003;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XEditGridCell xEditGridCell40;
        private IHIS.Framework.XEditGridCell xEditGridCell41;
        private IHIS.Framework.XEditGridCell xEditGridCell42;
        private IHIS.Framework.XEditGridCell xEditGridCell43;
        private IHIS.Framework.XEditGridCell xEditGridCell44;
        private IHIS.Framework.XEditGridCell xEditGridCell45;
        private IHIS.Framework.XEditGridCell xEditGridCell46;
        private IHIS.Framework.XEditGridCell xEditGridCell47;
        private IHIS.Framework.XEditGridCell xEditGridCell48;
        private IHIS.Framework.XEditGridCell xEditGridCell49;
        private IHIS.Framework.XEditGridCell xEditGridCell50;
        private IHIS.Framework.XEditGridCell xEditGridCell51;
        private IHIS.Framework.XEditGridCell xEditGridCell52;
        private IHIS.Framework.XEditGridCell xEditGridCell53;
        private IHIS.Framework.XEditGridCell xEditGridCell54;
        private IHIS.Framework.XEditGridCell xEditGridCell55;
        private IHIS.Framework.XEditGridCell xEditGridCell56;
        private IHIS.Framework.XEditGridCell xEditGridCell59;
        private IHIS.Framework.XEditGridCell xEditGridCell64;
        private IHIS.Framework.XEditGridCell xEditGridCell65;
        private IHIS.Framework.XEditGridCell xEditGridCell66;
        private IHIS.Framework.XEditGridCell xEditGridCell67;
        private IHIS.Framework.XEditGridCell xEditGridCell68;
        private IHIS.Framework.XEditGridCell xEditGridCell69;
        private IHIS.Framework.XEditGridCell xEditGridCell70;
        private IHIS.Framework.XEditGridCell xEditGridCell71;
        private IHIS.Framework.XEditGridCell xEditGridCell72;
        private IHIS.Framework.XEditGridCell xEditGridCell73;
        private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private IHIS.Framework.XEditGridCell xEditGridCell80;
        private IHIS.Framework.XEditGridCell xEditGridCell81;
        private IHIS.Framework.XEditGridCell xEditGridCell82;
        private IHIS.Framework.XEditGridCell xEditGridCell83;
        private IHIS.Framework.XEditGridCell xEditGridCell84;
        private IHIS.Framework.XEditGridCell xEditGridCell85;
        private IHIS.Framework.XEditGridCell xEditGridCell87;
        private IHIS.Framework.XEditGridCell xEditGridCell88;
        private IHIS.Framework.XEditGridCell xEditGridCell89;
        private IHIS.Framework.XEditGridCell xEditGridCell92;
        private IHIS.Framework.XEditGridCell xEditGridCell93;
        private IHIS.Framework.XGridHeader xGridHeader1;
        private IHIS.Framework.XDatePicker dpkNaewon_date;
        private IHIS.Framework.XEditGridCell xEditGridCell94;
        private IHIS.Framework.MultiLayout dloSelectOCS1003;
        private IHIS.Framework.MultiLayout dloOrder_danui;
        private IHIS.Framework.XEditGridCell xEditGridCell95;
        private IHIS.Framework.XEditGridCell xEditGridCell97;
        private IHIS.Framework.XEditGridCell xEditGridCell102;
        private IHIS.Framework.XButton btnProcessD7;
        private IHIS.Framework.XEditGridCell xEditGridCell127;
        private System.Windows.Forms.CheckBox chkAll;
        private IHIS.Framework.XEditGridCell xEditGridCell128;
        private IHIS.Framework.XEditGridCell xEditGridCell129;
        private IHIS.Framework.XEditGridCell xEditGridCell132;
        private IHIS.Framework.XEditGridCell xEditGridCell133;
        private IHIS.Framework.XEditGridCell xEditGridCell134;
        private IHIS.Framework.XEditGridCell xEditGridCell135;
        private IHIS.Framework.XEditGridCell xEditGridCell136;
        private IHIS.Framework.XEditGridCell xEditGridCell137;
        private System.Windows.Forms.CheckBox chkIsNewGroup;
        private IHIS.Framework.XEditGridCell xEditGridCell139;
        private System.Windows.Forms.ImageList imageListMixGroup;
        private IHIS.Framework.XEditGridCell xEditGridCell140;
        private IHIS.Framework.XEditGridCell xEditGridCell141;
        private IHIS.Framework.XEditGridCell xEditGridCell142;
        private IHIS.Framework.XPanel xPanel6;
        private System.Windows.Forms.RadioButton rbtIn;
        private System.Windows.Forms.RadioButton rbtOut;
        private IHIS.Framework.XEditGridCell xEditGridCell145;
        private IHIS.Framework.XEditGridCell xEditGridCell146;
        private IHIS.Framework.XEditGridCell xEditGridCell147;
        private IHIS.Framework.XEditGridCell xEditGridCell149;
        private IHIS.Framework.XPanel pnlOrder;
        private IHIS.Framework.XEditGridCell xEditGridCell153;
        private IHIS.Framework.XEditGridCell xEditGridCell154;
        private IHIS.Framework.XEditGridCell xEditGridCell155;
        private IHIS.Framework.XEditGridCell xEditGridCell156;
        private IHIS.Framework.XEditGridCell xEditGridCell162;
        private IHIS.Framework.XEditGridCell xEditGridCell163;
        private IHIS.Framework.XEditGridCell xEditGridCell164;
        private IHIS.Framework.XEditGridCell xEditGridCell165;
        private IHIS.Framework.XEditGridCell xEditGridCell166;
        private IHIS.Framework.XEditGridCell xEditGridCell167;
        private IHIS.Framework.XEditGridCell xEditGridCell169;
        private IHIS.Framework.XEditGridCell xEditGridCell170;
        private IHIS.Framework.XEditGridCell xEditGridCell171;
        private IHIS.Framework.XEditGridCell xEditGridCell172;
        private IHIS.Framework.XEditGridCell xEditGridCell173;
        private IHIS.Framework.XEditGridCell xEditGridCell175;
        private IHIS.Framework.XTextBox txtDrg_info;
        private IHIS.Framework.XEditGridCell xEditGridCell176;
        private IHIS.Framework.XEditGridCell xEditGridCell177;
        private IHIS.Framework.XEditGridCell xEditGridCell178;
        private IHIS.Framework.XEditGridCell xEditGridCell180;
        private IHIS.Framework.XEditGridCell xEditGridCell181;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private XTabControl tabGroup;
        private MultiLayout dloSelectOUT1001;
        private XPanel xPanel4;
        private XButton btnSelectAll;
        private XEditGridCell xEditGridCell10;
        protected ImageList imageList1;
        private XButton btnDeleteAll;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XButton btnINJResult;
        private XButton btnPFEResult;
        private XButton btnCplResult;
        private XPatientBox pbxSearch;
        private XTabControl tabOrderGubun;
        private IHIS.X.Magic.Controls.TabPage tabPage4;
        private IHIS.X.Magic.Controls.TabPage tabPage1;
        private IHIS.X.Magic.Controls.TabPage tabPage2;
        private IHIS.X.Magic.Controls.TabPage tabPage3;
        private IHIS.X.Magic.Controls.TabPage tabPage5;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell31;
        private XEditGrid grdSangInfo;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell125;
        private XEditGridCell xEditGridCell57;
        private XEditGridCell xEditGridCell99;
        private XEditGridCell xEditGridCell100;
        private XEditGridCell xEditGridCell101;
        private XEditGridCell xEditGridCell58;
        private XEditGridCell xEditGridCell60;
        private XEditGridCell xEditGridCell61;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XEditGridCell xEditGridCell130;
        private XEditGridCell xEditGridCell74;
        private XEditGridCell xEditGridCell126;
        private XEditGridCell xEditGridCell103;
        private XEditGridCell xEditGridCell104;
        private XEditGridCell xEditGridCell105;
        private XEditGridCell xEditGridCell106;
        private XEditGridCell xEditGridCell107;
        private XEditGridCell xEditGridCell108;
        private XEditGridCell xEditGridCell109;
        private XEditGridCell xEditGridCell110;
        private XEditGridCell xEditGridCell111;
        private XEditGridCell xEditGridCell112;
        private XEditGridCell xEditGridCell113;
        private XEditGridCell xEditGridCell114;
        private XEditGridCell xEditGridCell115;
        private XEditGridCell xEditGridCell116;
        private XEditGridCell xEditGridCell117;
        private XEditGridCell xEditGridCell118;
        private XEditGridCell xEditGridCell119;
        private XEditGridCell xEditGridCell120;
        private XEditGridCell xEditGridCell121;
        private XEditGridCell xEditGridCell122;
        private XEditGridCell xEditGridCell123;
        private XEditGridCell xEditGridCell124;
        private XEditGridCell xEditGridCell98;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell86;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell91;
        private XEditGridCell xEditGridCell96;
        private XCheckBox cbxGeneric_YN;
        private XEditGridCell xEditGridCell131;
        private XEditGridCell xEditGridCell78;
        private XEditGridCell xEditGridCell138;
        private XEditGridCell xEditGridCell143;
        private XEditGridCell xEditGridCell144;
        private XButton btnPre;
        private XButton btnHope_date;
        private XDatePicker dpkSetHopeDate;
        private XButton btnPost;
        private XEditGridCell xEditGridCell148;
        private XButton btnProcessD0;
        private XButton btnProcessD4;
        private XComboBox cboKijunGubun;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XPanel pnlKijun;
        private XLabel lblKijun;
        private XEditGridCell xEditGridCell150;
        private XEditGridCell xEditGridCell151;
        private XComboItem xComboItem3;
        private XComboItem xComboItem4;
        private XComboItem xComboItem5;
        private XComboItem xComboItem6;
        private XComboItem xComboItem7;
        private XComboItem xComboItem8;
        private XComboBox cboNalsu;
        private XButton btnNalsu;
        private XGroupBox gbxNalsu;
        private XGroupBox gbxHopeDate;
        private PictureBox pbxUnderArrow;
        private Timer timer_icon;
        private System.ComponentModel.IContainer components;
        private XEditGridCell xEditGridCell152;
        private XEditGridCell xEditGridCell157;

        // param get data for gridOcs1003 And gridSangInfo
        private OCS1003Q09GridOCS1003AndSangResult gridOcs1003AndSangData;

        public OCS1003Q09()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            this.mOrderBiz      = new IHIS.OCS.OrderBiz();                   // OCS 그룹 Business 라이브러리
            this.mOrderFunc     = new IHIS.OCS.OrderFunc();                  // OCS 그룹 Function 라이브러리			
            this.mHangmogInfo   = new IHIS.OCS.HangmogInfo(this.ScreenID);   // OCS 항목정보 그룹 라이브러리
            this.mInputControl  = new IHIS.OCS.InputControl(this.ScreenID);  // 입력제어 그룹 라이브러리 		
            this.mColumnControl = new IHIS.OCS.ColumnControl(this.ScreenID); // OCS 컬럼 컨트롤 그룹 라이브러리 
            this.mPatientInfo   = new IHIS.OCS.PatientInfo(this.ScreenID);   // 患者情報

            // Create param list for GridOCS1003
            this.grdOCS1003.ParamList = new List<string>(new String[] { "f_bunho", "f_naewon_date", "f_gwa", "f_doctor", "f_naewon_type", "f_input_gubun", "f_tel_yn", "f_input_tab", "f_jubsu_no", "f_pk_order", "f_generic_yn", "f_kijun" });

            // Create param list for grdOUT1001
            grdOUT1001.ParamList = new List<string>(new String[] { "f_gwa", "f_bunho", "f_input_gubun", "f_tel_yn", "f_io_gubun", "f_input_tab", "f_kijun", "f_selected_input_tab", "f_naewon_date" });
            grdOUT1001.ExecuteQuery = grdOUT1001_ExecuteQuery;

            //TODO disable IN Hospital Tab MED-5790
            rbtIn.Visible = false;
        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리    합니다.
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

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS1003Q09));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.pbxSearch = new IHIS.Framework.XPatientBox();
            this.dpkNaewon_date = new IHIS.Framework.XDatePicker();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.gbxHopeDate = new IHIS.Framework.XGroupBox();
            this.btnHope_date = new IHIS.Framework.XButton();
            this.btnPre = new IHIS.Framework.XButton();
            this.btnPost = new IHIS.Framework.XButton();
            this.dpkSetHopeDate = new IHIS.Framework.XDatePicker();
            this.gbxNalsu = new IHIS.Framework.XGroupBox();
            this.cboNalsu = new IHIS.Framework.XComboBox();
            this.btnNalsu = new IHIS.Framework.XButton();
            this.btnINJResult = new IHIS.Framework.XButton();
            this.btnPFEResult = new IHIS.Framework.XButton();
            this.btnCplResult = new IHIS.Framework.XButton();
            this.chkIsNewGroup = new System.Windows.Forms.CheckBox();
            this.btnProcessD0 = new IHIS.Framework.XButton();
            this.btnProcessD4 = new IHIS.Framework.XButton();
            this.btnProcessD7 = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdOUT1001 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell146 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell147 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell142 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell162 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell175 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell150 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.pnlKijun = new IHIS.Framework.XPanel();
            this.lblKijun = new IHIS.Framework.XLabel();
            this.cboKijunGubun = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.tabOrderGubun = new IHIS.Framework.XTabControl();
            this.tabPage1 = new IHIS.X.Magic.Controls.TabPage();
            this.tabPage2 = new IHIS.X.Magic.Controls.TabPage();
            this.tabPage3 = new IHIS.X.Magic.Controls.TabPage();
            this.tabPage4 = new IHIS.X.Magic.Controls.TabPage();
            this.tabPage5 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.rbtIn = new System.Windows.Forms.RadioButton();
            this.rbtOut = new System.Windows.Forms.RadioButton();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.pnlOrder = new IHIS.Framework.XPanel();
            this.pbxUnderArrow = new System.Windows.Forms.PictureBox();
            this.grdOCS1003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell145 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell136 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell137 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell163 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell164 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell165 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell166 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell173 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell140 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell141 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell167 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell153 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell154 = new IHIS.Framework.XEditGridCell();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.xEditGridCell155 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell156 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell169 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell170 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell132 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell171 = new IHIS.Framework.XEditGridCell();
            this.txtDrg_info = new IHIS.Framework.XTextBox();
            this.xEditGridCell172 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell176 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell177 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell178 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell180 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell181 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell133 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xEditGridCell131 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell138 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell143 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell144 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell151 = new IHIS.Framework.XEditGridCell();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xEditGridCell152 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell157 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.cbxGeneric_YN = new IHIS.Framework.XCheckBox();
            this.btnDeleteAll = new IHIS.Framework.XButton();
            this.btnSelectAll = new IHIS.Framework.XButton();
            this.grdSangInfo = new IHIS.Framework.XEditGrid();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell130 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell110 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell111 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell112 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell113 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell114 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell115 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell116 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell117 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell118 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell119 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell120 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell121 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell122 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell123 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell124 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.tabGroup = new IHIS.Framework.XTabControl();
            this.dloSelectOCS1003 = new IHIS.Framework.MultiLayout();
            this.dloOrder_danui = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.dloSelectOUT1001 = new IHIS.Framework.MultiLayout();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer_icon = new System.Windows.Forms.Timer(this.components);
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.gbxHopeDate.SuspendLayout();
            this.gbxNalsu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001)).BeginInit();
            this.pnlKijun.SuspendLayout();
            this.tabOrderGubun.SuspendLayout();
            this.xPanel6.SuspendLayout();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnderArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSangInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS1003)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOrder_danui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOUT1001)).BeginInit();
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
            this.ImageList.Images.SetKeyName(4, "+.gif");
            this.ImageList.Images.SetKeyName(5, "_.gif");
            this.ImageList.Images.SetKeyName(6, "오른쪽_회색1.gif");
            this.ImageList.Images.SetKeyName(7, "RR331.ico");
            this.ImageList.Images.SetKeyName(8, "채열실.ico");
            this.ImageList.Images.SetKeyName(9, "RANG.ico");
            this.ImageList.Images.SetKeyName(10, "통계.ico");
            this.ImageList.Images.SetKeyName(11, "환경설정.gif");
            this.ImageList.Images.SetKeyName(12, "진료요약정보.ico");
            this.ImageList.Images.SetKeyName(13, "보기.ico");
            this.ImageList.Images.SetKeyName(14, "청구심사2_16.ico");
            this.ImageList.Images.SetKeyName(15, "pre.gif");
            this.ImageList.Images.SetKeyName(16, "post.gif");
            this.ImageList.Images.SetKeyName(17, "Untitled.png");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.pbxSearch);
            this.xPanel1.Controls.Add(this.dpkNaewon_date);
            this.xPanel1.Controls.Add(this.xLabel5);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // pbxSearch
            // 
            this.pbxSearch.AccessibleDescription = null;
            this.pbxSearch.AccessibleName = null;
            resources.ApplyResources(this.pbxSearch, "pbxSearch");
            this.pbxSearch.BackgroundImage = null;
            this.pbxSearch.BoxType = IHIS.Framework.PatientBoxType.NormalMiddle;
            this.pbxSearch.Name = "pbxSearch";
            this.pbxSearch.Validated += new System.EventHandler(this.pbxSearch_Validated);
            this.pbxSearch.PatientSelected += new System.EventHandler(this.pbxSearch_PatientSelected);
            // 
            // dpkNaewon_date
            // 
            this.dpkNaewon_date.AccessibleDescription = null;
            this.dpkNaewon_date.AccessibleName = null;
            resources.ApplyResources(this.dpkNaewon_date, "dpkNaewon_date");
            this.dpkNaewon_date.BackgroundImage = null;
            this.dpkNaewon_date.Name = "dpkNaewon_date";
            this.dpkNaewon_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dpkNaewon_date_KeyDown);
            this.dpkNaewon_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkNaewon_date_DataValidating);
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
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.gbxHopeDate);
            this.xPanel2.Controls.Add(this.gbxNalsu);
            this.xPanel2.Controls.Add(this.btnINJResult);
            this.xPanel2.Controls.Add(this.btnPFEResult);
            this.xPanel2.Controls.Add(this.btnCplResult);
            this.xPanel2.Controls.Add(this.chkIsNewGroup);
            this.xPanel2.Controls.Add(this.btnProcessD0);
            this.xPanel2.Controls.Add(this.btnProcessD4);
            this.xPanel2.Controls.Add(this.btnProcessD7);
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // gbxHopeDate
            // 
            this.gbxHopeDate.AccessibleDescription = null;
            this.gbxHopeDate.AccessibleName = null;
            resources.ApplyResources(this.gbxHopeDate, "gbxHopeDate");
            this.gbxHopeDate.BackgroundImage = null;
            this.gbxHopeDate.Controls.Add(this.btnHope_date);
            this.gbxHopeDate.Controls.Add(this.btnPre);
            this.gbxHopeDate.Controls.Add(this.btnPost);
            this.gbxHopeDate.Controls.Add(this.dpkSetHopeDate);
            this.gbxHopeDate.Name = "gbxHopeDate";
            this.gbxHopeDate.Protect = true;
            this.gbxHopeDate.TabStop = false;
            // 
            // btnHope_date
            // 
            this.btnHope_date.AccessibleDescription = null;
            this.btnHope_date.AccessibleName = null;
            resources.ApplyResources(this.btnHope_date, "btnHope_date");
            this.btnHope_date.BackgroundImage = null;
            this.btnHope_date.ImageIndex = 8;
            this.btnHope_date.Name = "btnHope_date";
            this.btnHope_date.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnHope_date.Tag = "0";
            this.btnHope_date.Click += new System.EventHandler(this.btnHope_date_Click);
            // 
            // btnPre
            // 
            this.btnPre.AccessibleDescription = null;
            this.btnPre.AccessibleName = null;
            resources.ApplyResources(this.btnPre, "btnPre");
            this.btnPre.BackgroundImage = null;
            this.btnPre.ImageIndex = 15;
            this.btnPre.ImageList = this.ImageList;
            this.btnPre.Name = "btnPre";
            this.btnPre.Tag = "-";
            this.btnPre.Click += new System.EventHandler(this.btnDatePlusMinus_Click);
            // 
            // btnPost
            // 
            this.btnPost.AccessibleDescription = null;
            this.btnPost.AccessibleName = null;
            resources.ApplyResources(this.btnPost, "btnPost");
            this.btnPost.BackgroundImage = null;
            this.btnPost.ImageIndex = 16;
            this.btnPost.ImageList = this.ImageList;
            this.btnPost.Name = "btnPost";
            this.btnPost.Tag = "+";
            this.btnPost.Click += new System.EventHandler(this.btnDatePlusMinus_Click);
            // 
            // dpkSetHopeDate
            // 
            this.dpkSetHopeDate.AccessibleDescription = null;
            this.dpkSetHopeDate.AccessibleName = null;
            resources.ApplyResources(this.dpkSetHopeDate, "dpkSetHopeDate");
            this.dpkSetHopeDate.BackgroundImage = null;
            this.dpkSetHopeDate.Name = "dpkSetHopeDate";
            this.dpkSetHopeDate.TextChanged += new System.EventHandler(this.dpkSetHopeDate_TextChanged);
            // 
            // gbxNalsu
            // 
            this.gbxNalsu.AccessibleDescription = null;
            this.gbxNalsu.AccessibleName = null;
            resources.ApplyResources(this.gbxNalsu, "gbxNalsu");
            this.gbxNalsu.BackgroundImage = null;
            this.gbxNalsu.Controls.Add(this.cboNalsu);
            this.gbxNalsu.Controls.Add(this.btnNalsu);
            this.gbxNalsu.Name = "gbxNalsu";
            this.gbxNalsu.Protect = true;
            this.gbxNalsu.TabStop = false;
            // 
            // cboNalsu
            // 
            this.cboNalsu.AccessibleDescription = null;
            this.cboNalsu.AccessibleName = null;
            resources.ApplyResources(this.cboNalsu, "cboNalsu");
            this.cboNalsu.BackgroundImage = null;
            this.cboNalsu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboNalsu.Name = "cboNalsu";
            // 
            // btnNalsu
            // 
            this.btnNalsu.AccessibleDescription = null;
            this.btnNalsu.AccessibleName = null;
            resources.ApplyResources(this.btnNalsu, "btnNalsu");
            this.btnNalsu.BackgroundImage = null;
            this.btnNalsu.ImageIndex = 8;
            this.btnNalsu.Name = "btnNalsu";
            this.btnNalsu.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnNalsu.Tag = "0";
            this.btnNalsu.Click += new System.EventHandler(this.btnNalsu_Click);
            // 
            // btnINJResult
            // 
            this.btnINJResult.AccessibleDescription = null;
            this.btnINJResult.AccessibleName = null;
            resources.ApplyResources(this.btnINJResult, "btnINJResult");
            this.btnINJResult.BackgroundImage = null;
            this.btnINJResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnINJResult.ImageIndex = 13;
            this.btnINJResult.ImageList = this.ImageList;
            this.btnINJResult.Name = "btnINJResult";
            this.btnINJResult.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnINJResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnINJResult.Click += new System.EventHandler(this.btnINJResult_Click);
            // 
            // btnPFEResult
            // 
            this.btnPFEResult.AccessibleDescription = null;
            this.btnPFEResult.AccessibleName = null;
            resources.ApplyResources(this.btnPFEResult, "btnPFEResult");
            this.btnPFEResult.BackgroundImage = null;
            this.btnPFEResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPFEResult.ImageIndex = 12;
            this.btnPFEResult.ImageList = this.ImageList;
            this.btnPFEResult.Name = "btnPFEResult";
            this.btnPFEResult.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnPFEResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPFEResult.Click += new System.EventHandler(this.btnPFEResult_Click);
            // 
            // btnCplResult
            // 
            this.btnCplResult.AccessibleDescription = null;
            this.btnCplResult.AccessibleName = null;
            resources.ApplyResources(this.btnCplResult, "btnCplResult");
            this.btnCplResult.BackgroundImage = null;
            this.btnCplResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCplResult.ImageIndex = 9;
            this.btnCplResult.ImageList = this.ImageList;
            this.btnCplResult.Name = "btnCplResult";
            this.btnCplResult.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnCplResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCplResult.Click += new System.EventHandler(this.btnCplResult_Click);
            // 
            // chkIsNewGroup
            // 
            this.chkIsNewGroup.AccessibleDescription = null;
            this.chkIsNewGroup.AccessibleName = null;
            resources.ApplyResources(this.chkIsNewGroup, "chkIsNewGroup");
            this.chkIsNewGroup.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkIsNewGroup.BackgroundImage = null;
            this.chkIsNewGroup.Checked = true;
            this.chkIsNewGroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsNewGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkIsNewGroup.Font = null;
            this.chkIsNewGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkIsNewGroup.ImageList = this.ImageList;
            this.chkIsNewGroup.Name = "chkIsNewGroup";
            this.chkIsNewGroup.UseVisualStyleBackColor = false;
            this.chkIsNewGroup.CheckedChanged += new System.EventHandler(this.chkIsNewGroup_CheckedChanged);
            // 
            // btnProcessD0
            // 
            this.btnProcessD0.AccessibleDescription = null;
            this.btnProcessD0.AccessibleName = null;
            resources.ApplyResources(this.btnProcessD0, "btnProcessD0");
            this.btnProcessD0.BackgroundImage = null;
            this.btnProcessD0.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessD0.Image")));
            this.btnProcessD0.Name = "btnProcessD0";
            this.btnProcessD0.Tag = "D0";
            this.btnProcessD0.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcessD4
            // 
            this.btnProcessD4.AccessibleDescription = null;
            this.btnProcessD4.AccessibleName = null;
            resources.ApplyResources(this.btnProcessD4, "btnProcessD4");
            this.btnProcessD4.BackgroundImage = null;
            this.btnProcessD4.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessD4.Image")));
            this.btnProcessD4.Name = "btnProcessD4";
            this.btnProcessD4.Tag = "D4";
            this.btnProcessD4.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcessD7
            // 
            this.btnProcessD7.AccessibleDescription = null;
            this.btnProcessD7.AccessibleName = null;
            resources.ApplyResources(this.btnProcessD7, "btnProcessD7");
            this.btnProcessD7.BackgroundImage = null;
            this.btnProcessD7.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessD7.Image")));
            this.btnProcessD7.Name = "btnProcessD7";
            this.btnProcessD7.Tag = "D7";
            this.btnProcessD7.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            this.btnList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xButtonList1_MouseDown);
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.grdOUT1001);
            this.xPanel3.Controls.Add(this.pnlKijun);
            this.xPanel3.Controls.Add(this.tabOrderGubun);
            this.xPanel3.Controls.Add(this.xPanel6);
            this.xPanel3.Controls.Add(this.chkAll);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // grdOUT1001
            // 
            resources.ApplyResources(this.grdOUT1001, "grdOUT1001");
            this.grdOUT1001.ApplyPaintEventToAllColumn = true;
            this.grdOUT1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell127,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell146,
            this.xEditGridCell147,
            this.xEditGridCell7,
            this.xEditGridCell129,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell142,
            this.xEditGridCell162,
            this.xEditGridCell149,
            this.xEditGridCell175,
            this.xEditGridCell150,
            this.xEditGridCell95});
            this.grdOUT1001.ColPerLine = 7;
            this.grdOUT1001.Cols = 8;
            this.grdOUT1001.EnableMultiSelection = true;
            this.grdOUT1001.ExecuteQuery = null;
            this.grdOUT1001.FixedCols = 1;
            this.grdOUT1001.FixedRows = 1;
            this.grdOUT1001.HeaderHeights.Add(27);
            this.grdOUT1001.ImageList = this.ImageList;
            this.grdOUT1001.Name = "grdOUT1001";
            this.grdOUT1001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOUT1001.ParamList")));
            this.grdOUT1001.QuerySQL = resources.GetString("grdOUT1001.QuerySQL");
            this.grdOUT1001.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOUT1001.RowHeaderVisible = true;
            this.grdOUT1001.Rows = 2;
            this.grdOUT1001.RowStateCheckOnPaint = false;
            this.grdOUT1001.ToolTipActive = true;
            this.grdOUT1001.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOUT1001_QueryEnd);
            this.grdOUT1001.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOUT1001_MouseDown);
            this.grdOUT1001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOUT1001_RowFocusChanged);
            this.grdOUT1001.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOUT1001_GridCellPainting);
            this.grdOUT1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOUT1001_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.CellName = "naewon_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell1.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "gwa";
            this.xEditGridCell127.Col = -1;
            this.xEditGridCell127.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell127, "xEditGridCell127");
            this.xEditGridCell127.IsVisible = false;
            this.xEditGridCell127.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.CellName = "gwa_name";
            this.xEditGridCell2.CellWidth = 55;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell2.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.CellName = "doctor_name";
            this.xEditGridCell3.CellWidth = 102;
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell3.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.CellName = "nalsu";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell4.CellWidth = 40;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "bunho";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "doctor";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell146.CellName = "gubun_name";
            this.xEditGridCell146.Col = 5;
            this.xEditGridCell146.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell146, "xEditGridCell146");
            this.xEditGridCell146.IsUpdatable = false;
            this.xEditGridCell146.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell146.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell147.CellName = "chojae";
            this.xEditGridCell147.Col = 6;
            this.xEditGridCell147.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell147, "xEditGridCell147");
            this.xEditGridCell147.IsUpdatable = false;
            this.xEditGridCell147.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell147.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "naewon_type";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "jubsu_no";
            this.xEditGridCell129.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell129.Col = -1;
            this.xEditGridCell129.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell129, "xEditGridCell129");
            this.xEditGridCell129.IsUpdatable = false;
            this.xEditGridCell129.IsVisible = false;
            this.xEditGridCell129.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "pk_order";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "input_gubun";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.CellName = "tel_yn";
            this.xEditGridCell142.Col = -1;
            this.xEditGridCell142.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell142, "xEditGridCell142");
            this.xEditGridCell142.IsUpdatable = false;
            this.xEditGridCell142.IsVisible = false;
            this.xEditGridCell142.Row = -1;
            // 
            // xEditGridCell162
            // 
            this.xEditGridCell162.CellName = "toiwon_drg";
            this.xEditGridCell162.Col = -1;
            this.xEditGridCell162.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell162, "xEditGridCell162");
            this.xEditGridCell162.IsUpdatable = false;
            this.xEditGridCell162.IsVisible = false;
            this.xEditGridCell162.Row = -1;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "input_tab";
            this.xEditGridCell149.Col = -1;
            this.xEditGridCell149.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell149, "xEditGridCell149");
            this.xEditGridCell149.IsUpdatable = false;
            this.xEditGridCell149.IsVisible = false;
            this.xEditGridCell149.Row = -1;
            // 
            // xEditGridCell175
            // 
            this.xEditGridCell175.CellName = "io_gubun";
            this.xEditGridCell175.Col = -1;
            this.xEditGridCell175.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell175, "xEditGridCell175");
            this.xEditGridCell175.IsUpdatable = false;
            this.xEditGridCell175.IsVisible = false;
            this.xEditGridCell175.Row = -1;
            // 
            // xEditGridCell150
            // 
            this.xEditGridCell150.CellName = "is_order_yn";
            this.xEditGridCell150.CellWidth = 19;
            this.xEditGridCell150.Col = 7;
            this.xEditGridCell150.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell150, "xEditGridCell150");
            this.xEditGridCell150.IsUpdatable = false;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell95.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell95.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell95.AlterateRowImageIndex = 0;
            this.xEditGridCell95.CellName = "select";
            this.xEditGridCell95.CellWidth = 30;
            this.xEditGridCell95.Col = 1;
            this.xEditGridCell95.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            this.xEditGridCell95.ImageList = this.ImageList;
            this.xEditGridCell95.IsUpdatable = false;
            this.xEditGridCell95.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell95.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell95.RowImageIndex = 0;
            this.xEditGridCell95.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell95.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // pnlKijun
            // 
            this.pnlKijun.AccessibleDescription = null;
            this.pnlKijun.AccessibleName = null;
            resources.ApplyResources(this.pnlKijun, "pnlKijun");
            this.pnlKijun.BackgroundImage = null;
            this.pnlKijun.Controls.Add(this.lblKijun);
            this.pnlKijun.Controls.Add(this.cboKijunGubun);
            this.pnlKijun.Font = null;
            this.pnlKijun.Name = "pnlKijun";
            // 
            // lblKijun
            // 
            this.lblKijun.AccessibleDescription = null;
            this.lblKijun.AccessibleName = null;
            resources.ApplyResources(this.lblKijun, "lblKijun");
            this.lblKijun.Image = null;
            this.lblKijun.Name = "lblKijun";
            // 
            // cboKijunGubun
            // 
            this.cboKijunGubun.AccessibleDescription = null;
            this.cboKijunGubun.AccessibleName = null;
            resources.ApplyResources(this.cboKijunGubun, "cboKijunGubun");
            this.cboKijunGubun.BackgroundImage = null;
            this.cboKijunGubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.cboKijunGubun.Name = "cboKijunGubun";
            this.cboKijunGubun.SelectedIndexChanged += new System.EventHandler(this.cboKijunGubun_SelectedIndexChanged);
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "O";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "H";
            // 
            // tabOrderGubun
            // 
            this.tabOrderGubun.AccessibleDescription = null;
            this.tabOrderGubun.AccessibleName = null;
            resources.ApplyResources(this.tabOrderGubun, "tabOrderGubun");
            this.tabOrderGubun.BackgroundImage = null;
            this.tabOrderGubun.Font = null;
            this.tabOrderGubun.IDEPixelArea = true;
            this.tabOrderGubun.IDEPixelBorder = false;
            this.tabOrderGubun.ImageList = this.ImageList;
            this.tabOrderGubun.Name = "tabOrderGubun";
            this.tabOrderGubun.SelectedIndex = 0;
            this.tabOrderGubun.SelectedTab = this.tabPage1;
            this.tabOrderGubun.ShowClose = false;
            this.tabOrderGubun.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3,
            this.tabPage4,
            this.tabPage5});
            this.tabOrderGubun.SelectionChanged += new System.EventHandler(this.tabOrderGubun_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AccessibleDescription = null;
            this.tabPage1.AccessibleName = null;
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.BackgroundImage = null;
            this.tabPage1.Font = null;
            this.tabPage1.ImageIndex = 1;
            this.tabPage1.ImageList = this.ImageList;
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Tag = "%";
            // 
            // tabPage2
            // 
            this.tabPage2.AccessibleDescription = null;
            this.tabPage2.AccessibleName = null;
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.BackgroundImage = null;
            this.tabPage2.Font = null;
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.ImageList = this.ImageList;
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Tag = "1";
            // 
            // tabPage3
            // 
            this.tabPage3.AccessibleDescription = null;
            this.tabPage3.AccessibleName = null;
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.BackgroundImage = null;
            this.tabPage3.Font = null;
            this.tabPage3.ImageIndex = 0;
            this.tabPage3.ImageList = this.ImageList;
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Tag = "2";
            // 
            // tabPage4
            // 
            this.tabPage4.AccessibleDescription = null;
            this.tabPage4.AccessibleName = null;
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.BackgroundImage = null;
            this.tabPage4.Font = null;
            this.tabPage4.ImageIndex = 0;
            this.tabPage4.ImageList = this.ImageList;
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Tag = "3";
            // 
            // tabPage5
            // 
            this.tabPage5.AccessibleDescription = null;
            this.tabPage5.AccessibleName = null;
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.BackgroundImage = null;
            this.tabPage5.Font = null;
            this.tabPage5.ImageIndex = 0;
            this.tabPage5.ImageList = this.ImageList;
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Selected = false;
            this.tabPage5.Tag = "4";
            // 
            // xPanel6
            // 
            this.xPanel6.AccessibleDescription = null;
            this.xPanel6.AccessibleName = null;
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.BackgroundImage = null;
            this.xPanel6.Controls.Add(this.rbtIn);
            this.xPanel6.Controls.Add(this.rbtOut);
            this.xPanel6.Font = null;
            this.xPanel6.Name = "xPanel6";
            // 
            // rbtIn
            // 
            this.rbtIn.AccessibleDescription = null;
            this.rbtIn.AccessibleName = null;
            resources.ApplyResources(this.rbtIn, "rbtIn");
            this.rbtIn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtIn.BackgroundImage = null;
            this.rbtIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtIn.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbtIn.ImageList = this.ImageList;
            this.rbtIn.Name = "rbtIn";
            this.rbtIn.UseVisualStyleBackColor = false;
            this.rbtIn.CheckedChanged += new System.EventHandler(this.rbtOut_CheckedChanged);
            // 
            // rbtOut
            // 
            this.rbtOut.AccessibleDescription = null;
            this.rbtOut.AccessibleName = null;
            resources.ApplyResources(this.rbtOut, "rbtOut");
            this.rbtOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbtOut.BackgroundImage = null;
            this.rbtOut.Checked = true;
            this.rbtOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbtOut.ImageList = this.ImageList;
            this.rbtOut.Name = "rbtOut";
            this.rbtOut.TabStop = true;
            this.rbtOut.UseVisualStyleBackColor = false;
            this.rbtOut.CheckedChanged += new System.EventHandler(this.rbtOut_CheckedChanged);
            // 
            // chkAll
            // 
            this.chkAll.AccessibleDescription = null;
            this.chkAll.AccessibleName = null;
            resources.ApplyResources(this.chkAll, "chkAll");
            this.chkAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.chkAll.BackgroundImage = null;
            this.chkAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAll.Font = null;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkAll.ImageList = this.ImageList;
            this.chkAll.Name = "chkAll";
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // pnlOrder
            // 
            this.pnlOrder.AccessibleDescription = null;
            this.pnlOrder.AccessibleName = null;
            this.pnlOrder.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this.pnlOrder, "pnlOrder");
            this.pnlOrder.BackgroundImage = null;
            this.pnlOrder.Controls.Add(this.pbxUnderArrow);
            this.pnlOrder.Controls.Add(this.grdOCS1003);
            this.pnlOrder.Controls.Add(this.xPanel4);
            this.pnlOrder.Controls.Add(this.grdSangInfo);
            this.pnlOrder.Controls.Add(this.tabGroup);
            this.pnlOrder.Controls.Add(this.txtDrg_info);
            this.pnlOrder.Font = null;
            this.pnlOrder.Name = "pnlOrder";
            // 
            // pbxUnderArrow
            // 
            this.pbxUnderArrow.AccessibleDescription = null;
            this.pbxUnderArrow.AccessibleName = null;
            resources.ApplyResources(this.pbxUnderArrow, "pbxUnderArrow");
            this.pbxUnderArrow.BackgroundImage = null;
            this.pbxUnderArrow.Font = null;
            this.pbxUnderArrow.ImageLocation = null;
            this.pbxUnderArrow.Name = "pbxUnderArrow";
            this.pbxUnderArrow.TabStop = false;
            // 
            // grdOCS1003
            // 
            this.grdOCS1003.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdOCS1003, "grdOCS1003");
            this.grdOCS1003.ApplyPaintEventToAllColumn = true;
            this.grdOCS1003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell145,
            this.xEditGridCell19,
            this.xEditGridCell102,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell134,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell135,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell136,
            this.xEditGridCell28,
            this.xEditGridCell137,
            this.xEditGridCell29,
            this.xEditGridCell163,
            this.xEditGridCell164,
            this.xEditGridCell165,
            this.xEditGridCell166,
            this.xEditGridCell173,
            this.xEditGridCell30,
            this.xEditGridCell140,
            this.xEditGridCell141,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell167,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell59,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell139,
            this.xEditGridCell94,
            this.xEditGridCell68,
            this.xEditGridCell153,
            this.xEditGridCell154,
            this.xEditGridCell155,
            this.xEditGridCell156,
            this.xEditGridCell169,
            this.xEditGridCell170,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell73,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell83,
            this.xEditGridCell128,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell132,
            this.xEditGridCell171,
            this.xEditGridCell172,
            this.xEditGridCell176,
            this.xEditGridCell177,
            this.xEditGridCell178,
            this.xEditGridCell180,
            this.xEditGridCell181,
            this.xEditGridCell10,
            this.xEditGridCell133,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell31,
            this.xEditGridCell18,
            this.xEditGridCell75,
            this.xEditGridCell79,
            this.xEditGridCell86,
            this.xEditGridCell90,
            this.xEditGridCell91,
            this.xEditGridCell96,
            this.xEditGridCell131,
            this.xEditGridCell97,
            this.xEditGridCell138,
            this.xEditGridCell143,
            this.xEditGridCell144,
            this.xEditGridCell148,
            this.xEditGridCell151,
            this.xEditGridCell152,
            this.xEditGridCell157});
            this.grdOCS1003.ColPerLine = 34;
            this.grdOCS1003.ColResizable = true;
            this.grdOCS1003.Cols = 35;
            this.grdOCS1003.ControlBinding = true;
            this.grdOCS1003.EnableMultiSelection = true;
            this.grdOCS1003.ExecuteQuery = null;
            this.grdOCS1003.FixedCols = 1;
            this.grdOCS1003.FixedRows = 2;
            this.grdOCS1003.HeaderHeights.Add(32);
            this.grdOCS1003.HeaderHeights.Add(-1);
            this.grdOCS1003.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOCS1003.Name = "grdOCS1003";
            this.grdOCS1003.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS1003.ParamList")));
            this.grdOCS1003.QuerySQL = resources.GetString("grdOCS1003.QuerySQL");
            this.grdOCS1003.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS1003.RowHeaderVisible = true;
            this.grdOCS1003.Rows = 3;
            this.grdOCS1003.RowStateCheckOnPaint = false;
            this.grdOCS1003.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS1003.ToolTipActive = true;
            this.grdOCS1003.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS1003_GridColumnChanged);
            this.grdOCS1003.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS1003_QueryEnd);
            this.grdOCS1003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS1003_MouseDown);
            this.grdOCS1003.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS1003_RowFocusChanged);
            this.grdOCS1003.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS1003_GridCellPainting);
            this.grdOCS1003.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS1003_GridColumnProtectModify);
            this.grdOCS1003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS1003_QueryStarting);
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell145.CellName = "input_gubun_name";
            this.xEditGridCell145.CellWidth = 40;
            this.xEditGridCell145.Col = 4;
            this.xEditGridCell145.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell145, "xEditGridCell145");
            this.xEditGridCell145.IsUpdatable = false;
            this.xEditGridCell145.RowSpan = 2;
            this.xEditGridCell145.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell145.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell145.SuppressRepeating = true;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell19.CellName = "group_ser";
            this.xEditGridCell19.CellWidth = 34;
            this.xEditGridCell19.Col = 6;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.RowSpan = 2;
            this.xEditGridCell19.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell19.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell19.SuppressRepeating = true;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell102.CellName = "order_gubun_name";
            this.xEditGridCell102.CellWidth = 59;
            this.xEditGridCell102.Col = 5;
            this.xEditGridCell102.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell102, "xEditGridCell102");
            this.xEditGridCell102.IsUpdatable = false;
            this.xEditGridCell102.RowSpan = 2;
            this.xEditGridCell102.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell102.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell102.SuppressRepeating = true;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.CellName = "hangmog_code";
            this.xEditGridCell20.CellWidth = 75;
            this.xEditGridCell20.Col = 11;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.RowSpan = 2;
            this.xEditGridCell20.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.CellLen = 50;
            this.xEditGridCell21.CellName = "hangmog_name";
            this.xEditGridCell21.CellWidth = 247;
            this.xEditGridCell21.Col = 12;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.RowSpan = 2;
            this.xEditGridCell21.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "specimen_code";
            this.xEditGridCell134.Col = -1;
            this.xEditGridCell134.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell134, "xEditGridCell134");
            this.xEditGridCell134.IsUpdatable = false;
            this.xEditGridCell134.IsVisible = false;
            this.xEditGridCell134.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.CellName = "specimen_name";
            this.xEditGridCell22.CellWidth = 60;
            this.xEditGridCell22.Col = 22;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.RowSpan = 2;
            this.xEditGridCell22.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.CellName = "suryang";
            this.xEditGridCell23.CellWidth = 48;
            this.xEditGridCell23.Col = 14;
            this.xEditGridCell23.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell23.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.MaxDropDownItems = 9;
            this.xEditGridCell23.RowSpan = 2;
            this.xEditGridCell23.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell23.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "ord_danui";
            this.xEditGridCell135.Col = -1;
            this.xEditGridCell135.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell135, "xEditGridCell135");
            this.xEditGridCell135.IsUpdatable = false;
            this.xEditGridCell135.IsVisible = false;
            this.xEditGridCell135.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.CellName = "ord_danui_name";
            this.xEditGridCell24.CellWidth = 49;
            this.xEditGridCell24.Col = 15;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.RowSpan = 2;
            this.xEditGridCell24.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.CellName = "dv_time";
            this.xEditGridCell25.CellWidth = 21;
            this.xEditGridCell25.Col = 16;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.Row = 1;
            this.xEditGridCell25.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.CellName = "dv";
            this.xEditGridCell26.CellWidth = 39;
            this.xEditGridCell26.Col = 17;
            this.xEditGridCell26.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell26.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.Row = 1;
            this.xEditGridCell26.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.CellName = "nalsu";
            this.xEditGridCell27.CellWidth = 45;
            this.xEditGridCell27.Col = 18;
            this.xEditGridCell27.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell27.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.MaxDropDownItems = 12;
            this.xEditGridCell27.RowSpan = 2;
            this.xEditGridCell27.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell27.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellName = "jusa";
            this.xEditGridCell136.Col = -1;
            this.xEditGridCell136.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell136, "xEditGridCell136");
            this.xEditGridCell136.IsUpdatable = false;
            this.xEditGridCell136.IsVisible = false;
            this.xEditGridCell136.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.CellName = "jusa_name";
            this.xEditGridCell28.CellWidth = 50;
            this.xEditGridCell28.Col = 19;
            this.xEditGridCell28.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsUpdatable = false;
            this.xEditGridCell28.RowSpan = 2;
            this.xEditGridCell28.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "bogyong_code";
            this.xEditGridCell137.Col = -1;
            this.xEditGridCell137.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell137, "xEditGridCell137");
            this.xEditGridCell137.IsUpdatable = false;
            this.xEditGridCell137.IsVisible = false;
            this.xEditGridCell137.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell29.CellName = "bogyong_name";
            this.xEditGridCell29.CellWidth = 92;
            this.xEditGridCell29.Col = 21;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.RowSpan = 2;
            this.xEditGridCell29.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell29.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell29.SuppressRepeating = true;
            // 
            // xEditGridCell163
            // 
            this.xEditGridCell163.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell163.CellName = "jusa_spd_gubun";
            this.xEditGridCell163.CellWidth = 40;
            this.xEditGridCell163.Col = 20;
            this.xEditGridCell163.EditorStyle = IHIS.Framework.XCellEditorStyle.ListBox;
            this.xEditGridCell163.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell163, "xEditGridCell163");
            this.xEditGridCell163.IsUpdatable = false;
            this.xEditGridCell163.RowSpan = 2;
            this.xEditGridCell163.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell163.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell164
            // 
            this.xEditGridCell164.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell164.CellName = "hubal_change_yn";
            this.xEditGridCell164.CellWidth = 30;
            this.xEditGridCell164.Col = 31;
            this.xEditGridCell164.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell164.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell164, "xEditGridCell164");
            this.xEditGridCell164.IsUpdatable = false;
            this.xEditGridCell164.RowSpan = 2;
            this.xEditGridCell164.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell164.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell165
            // 
            this.xEditGridCell165.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell165.CellName = "pharmacy";
            this.xEditGridCell165.CellWidth = 20;
            this.xEditGridCell165.Col = 29;
            this.xEditGridCell165.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell165.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell165, "xEditGridCell165");
            this.xEditGridCell165.IsUpdatable = false;
            this.xEditGridCell165.RowSpan = 2;
            this.xEditGridCell165.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell165.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell166
            // 
            this.xEditGridCell166.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell166.CellName = "drg_pack_yn";
            this.xEditGridCell166.CellWidth = 20;
            this.xEditGridCell166.Col = 28;
            this.xEditGridCell166.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell166.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell166, "xEditGridCell166");
            this.xEditGridCell166.IsUpdatable = false;
            this.xEditGridCell166.RowSpan = 2;
            this.xEditGridCell166.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell166.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell173
            // 
            this.xEditGridCell173.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell173.CellName = "powder_yn";
            this.xEditGridCell173.CellWidth = 20;
            this.xEditGridCell173.Col = 30;
            this.xEditGridCell173.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell173.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell173, "xEditGridCell173");
            this.xEditGridCell173.IsUpdatable = false;
            this.xEditGridCell173.RowSpan = 2;
            this.xEditGridCell173.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell173.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.CellName = "wonyoi_order_yn";
            this.xEditGridCell30.CellWidth = 24;
            this.xEditGridCell30.Col = 26;
            this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsUpdatable = false;
            this.xEditGridCell30.RowSpan = 2;
            this.xEditGridCell30.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell140.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell140.CellWidth = 30;
            this.xEditGridCell140.Col = 24;
            this.xEditGridCell140.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell140.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell140, "xEditGridCell140");
            this.xEditGridCell140.IsUpdatable = false;
            this.xEditGridCell140.RowSpan = 2;
            this.xEditGridCell140.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell140.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell141.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell141.CellWidth = 30;
            this.xEditGridCell141.Col = 23;
            this.xEditGridCell141.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell141.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell141, "xEditGridCell141");
            this.xEditGridCell141.IsUpdatable = false;
            this.xEditGridCell141.RowSpan = 2;
            this.xEditGridCell141.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell141.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.CellName = "emergency";
            this.xEditGridCell32.CellWidth = 21;
            this.xEditGridCell32.Col = 25;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.RowSpan = 2;
            this.xEditGridCell32.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.CellName = "pay";
            this.xEditGridCell33.CellWidth = 35;
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsUpdatable = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell36.CellName = "anti_cancer_yn";
            this.xEditGridCell36.CellWidth = 45;
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsUpdatable = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell36.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "muhyo";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsUpdatable = false;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell38.CellName = "portable_yn";
            this.xEditGridCell38.CellWidth = 61;
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsUpdatable = false;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell38.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "ocs_flag";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsUpdatable = false;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "order_gubun";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsUpdatable = false;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell167
            // 
            this.xEditGridCell167.CellName = "input_tab";
            this.xEditGridCell167.Col = -1;
            this.xEditGridCell167.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell167, "xEditGridCell167");
            this.xEditGridCell167.IsUpdatable = false;
            this.xEditGridCell167.IsVisible = false;
            this.xEditGridCell167.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "input_gubun";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsUpdatable = false;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "after_act_yn";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsUpdatable = false;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "jundal_table";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsUpdatable = false;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "jundal_part";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsUpdatable = false;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "move_part";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsUpdatable = false;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "bunho";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsUpdatable = false;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell48.CellName = "naewon_date";
            this.xEditGridCell48.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell48.Col = 3;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsUpdatable = false;
            this.xEditGridCell48.RowSpan = 2;
            this.xEditGridCell48.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell48.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "gwa";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsUpdatable = false;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "doctor";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsUpdatable = false;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "naewon_type";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsUpdatable = false;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "pk_order";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsUpdatable = false;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "seq";
            this.xEditGridCell53.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsUpdatable = false;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "pkocs1003";
            this.xEditGridCell54.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsUpdatable = false;
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "sub_susul";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsUpdatable = false;
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "sutak_yn";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsUpdatable = false;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "amt";
            this.xEditGridCell59.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsUpdatable = false;
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "dv_1";
            this.xEditGridCell64.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsUpdatable = false;
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "dv_2";
            this.xEditGridCell65.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsUpdatable = false;
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "dv_3";
            this.xEditGridCell66.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsUpdatable = false;
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "dv_4";
            this.xEditGridCell67.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsUpdatable = false;
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell139.CellName = "hope_date";
            this.xEditGridCell139.Col = 8;
            this.xEditGridCell139.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell139.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell139, "xEditGridCell139");
            this.xEditGridCell139.RowSpan = 2;
            this.xEditGridCell139.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell139.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell94.CellName = "order_remark";
            this.xEditGridCell94.Col = 27;
            this.xEditGridCell94.DisplayMemoText = true;
            this.xEditGridCell94.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell94.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsUpdatable = false;
            this.xEditGridCell94.RowSpan = 2;
            this.xEditGridCell94.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell94.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "mix_group";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsUpdatable = false;
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell153
            // 
            this.xEditGridCell153.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell153.CellName = "home_care_yn";
            this.xEditGridCell153.CellWidth = 20;
            this.xEditGridCell153.Col = 32;
            this.xEditGridCell153.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell153.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell153, "xEditGridCell153");
            this.xEditGridCell153.IsUpdatable = false;
            this.xEditGridCell153.RowSpan = 2;
            this.xEditGridCell153.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell153.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell154
            // 
            this.xEditGridCell154.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell154.CellName = "regular_yn";
            this.xEditGridCell154.CellWidth = 20;
            this.xEditGridCell154.Col = 9;
            this.xEditGridCell154.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem7,
            this.xComboItem8});
            this.xEditGridCell154.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell154.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell154, "xEditGridCell154");
            this.xEditGridCell154.IsUpdatable = false;
            this.xEditGridCell154.RowSpan = 2;
            this.xEditGridCell154.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell154.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell154.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem7
            // 
            resources.ApplyResources(this.xComboItem7, "xComboItem7");
            this.xComboItem7.ValueItem = "Y";
            // 
            // xComboItem8
            // 
            resources.ApplyResources(this.xComboItem8, "xComboItem8");
            this.xComboItem8.ValueItem = "N";
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.CellName = "gongbi_code";
            this.xEditGridCell155.Col = -1;
            this.xEditGridCell155.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell155, "xEditGridCell155");
            this.xEditGridCell155.IsUpdatable = false;
            this.xEditGridCell155.IsVisible = false;
            this.xEditGridCell155.Row = -1;
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell156.CellName = "gongbi_name";
            this.xEditGridCell156.Col = -1;
            this.xEditGridCell156.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell156, "xEditGridCell156");
            this.xEditGridCell156.IsUpdatable = false;
            this.xEditGridCell156.IsVisible = false;
            this.xEditGridCell156.Row = -1;
            this.xEditGridCell156.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell156.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell169
            // 
            this.xEditGridCell169.CellName = "donbog_yn";
            this.xEditGridCell169.Col = -1;
            this.xEditGridCell169.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell169, "xEditGridCell169");
            this.xEditGridCell169.IsUpdatable = false;
            this.xEditGridCell169.IsVisible = false;
            this.xEditGridCell169.Row = -1;
            // 
            // xEditGridCell170
            // 
            this.xEditGridCell170.CellName = "dv_name";
            this.xEditGridCell170.Col = -1;
            this.xEditGridCell170.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell170, "xEditGridCell170");
            this.xEditGridCell170.IsUpdatable = false;
            this.xEditGridCell170.IsVisible = false;
            this.xEditGridCell170.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "slip_code";
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsUpdatable = false;
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "group_yn";
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsUpdatable = false;
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "sg_code";
            this.xEditGridCell71.Col = -1;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsUpdatable = false;
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "order_gubun_bas";
            this.xEditGridCell72.Col = -1;
            this.xEditGridCell72.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsUpdatable = false;
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "input_control";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsUpdatable = false;
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "suga_yn";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsUpdatable = false;
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "emergency_check";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsUpdatable = false;
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "limit_suryang";
            this.xEditGridCell80.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsUpdatable = false;
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "specimen_yn";
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsUpdatable = false;
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "jaeryo_yn";
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsUpdatable = false;
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "ord_danui_check";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsUpdatable = false;
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "ord_danui_bas";
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell128, "xEditGridCell128");
            this.xEditGridCell128.IsUpdatable = false;
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "jundal_table_out";
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsUpdatable = false;
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "jundal_part_out";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsUpdatable = false;
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "move_part_out";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "jundal_table_inp";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "jundal_part_inp";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "move_part_inp";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "bulyong_check";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsUpdatable = false;
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsUpdatable = false;
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "default_wonyoi_order_yn";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsUpdatable = false;
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "nday_yn";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsUpdatable = false;
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "muhyo_yn";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsUpdatable = false;
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.CellName = "tel_yn";
            this.xEditGridCell132.Col = -1;
            this.xEditGridCell132.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell132, "xEditGridCell132");
            this.xEditGridCell132.IsUpdatable = false;
            this.xEditGridCell132.IsVisible = false;
            this.xEditGridCell132.Row = -1;
            // 
            // xEditGridCell171
            // 
            this.xEditGridCell171.BindControl = this.txtDrg_info;
            this.xEditGridCell171.CellName = "drg_info";
            this.xEditGridCell171.Col = -1;
            this.xEditGridCell171.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell171, "xEditGridCell171");
            this.xEditGridCell171.IsReadOnly = true;
            this.xEditGridCell171.IsUpdatable = false;
            this.xEditGridCell171.IsVisible = false;
            this.xEditGridCell171.Row = -1;
            // 
            // txtDrg_info
            // 
            this.txtDrg_info.AccessibleDescription = null;
            this.txtDrg_info.AccessibleName = null;
            resources.ApplyResources(this.txtDrg_info, "txtDrg_info");
            this.txtDrg_info.BackgroundImage = null;
            this.txtDrg_info.Name = "txtDrg_info";
            this.txtDrg_info.Protect = true;
            this.txtDrg_info.ReadOnly = true;
            this.txtDrg_info.TabStop = false;
            // 
            // xEditGridCell172
            // 
            this.xEditGridCell172.CellName = "drg_bunryu";
            this.xEditGridCell172.Col = -1;
            this.xEditGridCell172.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell172, "xEditGridCell172");
            this.xEditGridCell172.IsReadOnly = true;
            this.xEditGridCell172.IsUpdatable = false;
            this.xEditGridCell172.IsVisible = false;
            this.xEditGridCell172.Row = -1;
            // 
            // xEditGridCell176
            // 
            this.xEditGridCell176.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell176.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell176.CellName = "child_yn";
            this.xEditGridCell176.CellWidth = 19;
            this.xEditGridCell176.Col = 2;
            this.xEditGridCell176.ExecuteQuery = null;
            this.xEditGridCell176.HeaderForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xEditGridCell176, "xEditGridCell176");
            this.xEditGridCell176.IsUpdatable = false;
            this.xEditGridCell176.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell176.RowSpan = 2;
            this.xEditGridCell176.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell177
            // 
            this.xEditGridCell177.CellName = "bom_source_key";
            this.xEditGridCell177.Col = -1;
            this.xEditGridCell177.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell177, "xEditGridCell177");
            this.xEditGridCell177.IsUpdatable = false;
            this.xEditGridCell177.IsVisible = false;
            this.xEditGridCell177.Row = -1;
            // 
            // xEditGridCell178
            // 
            this.xEditGridCell178.CellName = "bom_occur_yn";
            this.xEditGridCell178.Col = -1;
            this.xEditGridCell178.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell178, "xEditGridCell178");
            this.xEditGridCell178.IsUpdatable = false;
            this.xEditGridCell178.IsVisible = false;
            this.xEditGridCell178.Row = -1;
            // 
            // xEditGridCell180
            // 
            this.xEditGridCell180.CellName = "org_key";
            this.xEditGridCell180.Col = -1;
            this.xEditGridCell180.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell180, "xEditGridCell180");
            this.xEditGridCell180.IsUpdatable = false;
            this.xEditGridCell180.IsVisible = false;
            this.xEditGridCell180.Row = -1;
            // 
            // xEditGridCell181
            // 
            this.xEditGridCell181.CellName = "parent_key";
            this.xEditGridCell181.Col = -1;
            this.xEditGridCell181.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell181, "xEditGridCell181");
            this.xEditGridCell181.IsUpdatable = false;
            this.xEditGridCell181.IsVisible = false;
            this.xEditGridCell181.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "bun_code";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell133.CellName = "cont_key";
            this.xEditGridCell133.CellWidth = 28;
            this.xEditGridCell133.Col = -1;
            this.xEditGridCell133.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell133, "xEditGridCell133");
            this.xEditGridCell133.IsUpdatable = false;
            this.xEditGridCell133.IsVisible = false;
            this.xEditGridCell133.Row = -1;
            this.xEditGridCell133.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "fk_key1001";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "wonnae_drg_yn";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "dc_yn";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "result_date";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsUpdatable = false;
            this.xEditGridCell31.IsUpdCol = false;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "confirm_check";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "sunab_check";
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsUpdatable = false;
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "dv_5";
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsUpdatable = false;
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "dv_6";
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsUpdatable = false;
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "dv_7";
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsUpdatable = false;
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "dv_8";
            this.xEditGridCell91.Col = -1;
            this.xEditGridCell91.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsUpdatable = false;
            this.xEditGridCell91.IsVisible = false;
            this.xEditGridCell91.Row = -1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "general_disp_yn";
            this.xEditGridCell96.CellWidth = 49;
            this.xEditGridCell96.Col = 13;
            this.xEditGridCell96.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6});
            this.xEditGridCell96.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell96.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            this.xEditGridCell96.IsReadOnly = true;
            this.xEditGridCell96.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "Y";
            // 
            // xComboItem6
            // 
            resources.ApplyResources(this.xComboItem6, "xComboItem6");
            this.xComboItem6.ValueItem = "N";
            // 
            // xEditGridCell131
            // 
            this.xEditGridCell131.CellLen = 50;
            this.xEditGridCell131.CellName = "generic_name";
            this.xEditGridCell131.Col = -1;
            this.xEditGridCell131.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell131, "xEditGridCell131");
            this.xEditGridCell131.IsVisible = false;
            this.xEditGridCell131.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell97.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell97.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell97.AlterateRowImageIndex = 0;
            this.xEditGridCell97.CellName = "select";
            this.xEditGridCell97.CellWidth = 30;
            this.xEditGridCell97.Col = 1;
            this.xEditGridCell97.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            this.xEditGridCell97.ImageList = this.ImageList;
            this.xEditGridCell97.IsUpdatable = false;
            this.xEditGridCell97.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell97.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell97.RowImageIndex = 0;
            this.xEditGridCell97.RowSpan = 2;
            this.xEditGridCell97.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell97.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellName = "bogyong_code_sub";
            this.xEditGridCell138.CellWidth = 41;
            this.xEditGridCell138.Col = 33;
            this.xEditGridCell138.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell138, "xEditGridCell138");
            this.xEditGridCell138.IsReadOnly = true;
            this.xEditGridCell138.RowSpan = 2;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "bogyong_name_sub";
            this.xEditGridCell143.Col = 34;
            this.xEditGridCell143.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell143, "xEditGridCell143");
            this.xEditGridCell143.IsReadOnly = true;
            this.xEditGridCell143.RowSpan = 2;
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.CellName = "ori_hope_date";
            this.xEditGridCell144.Col = 7;
            this.xEditGridCell144.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell144, "xEditGridCell144");
            this.xEditGridCell144.IsReadOnly = true;
            this.xEditGridCell144.RowSpan = 2;
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellName = "io_yn";
            this.xEditGridCell148.Col = -1;
            this.xEditGridCell148.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell148, "xEditGridCell148");
            this.xEditGridCell148.IsVisible = false;
            this.xEditGridCell148.Row = -1;
            // 
            // xEditGridCell151
            // 
            this.xEditGridCell151.CellName = "brought_drg_yn";
            this.xEditGridCell151.CellWidth = 20;
            this.xEditGridCell151.Col = 10;
            this.xEditGridCell151.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4});
            this.xEditGridCell151.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell151.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell151, "xEditGridCell151");
            this.xEditGridCell151.IsReadOnly = true;
            this.xEditGridCell151.RowSpan = 2;
            this.xEditGridCell151.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "Y";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "N";
            // 
            // xEditGridCell152
            // 
            this.xEditGridCell152.CellName = "trial_flg";
            this.xEditGridCell152.Col = -1;
            this.xEditGridCell152.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell152, "xEditGridCell152");
            this.xEditGridCell152.IsVisible = false;
            this.xEditGridCell152.Row = -1;
            // 
            // xEditGridCell157
            // 
            this.xEditGridCell157.CellName = "yj_code";
            this.xEditGridCell157.Col = -1;
            this.xEditGridCell157.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell157, "xEditGridCell157");
            this.xEditGridCell157.IsVisible = false;
            this.xEditGridCell157.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 16;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 21;
            this.xGridHeader1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridHeader1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.cbxGeneric_YN);
            this.xPanel4.Controls.Add(this.btnDeleteAll);
            this.xPanel4.Controls.Add(this.btnSelectAll);
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // cbxGeneric_YN
            // 
            this.cbxGeneric_YN.AccessibleDescription = null;
            this.cbxGeneric_YN.AccessibleName = null;
            resources.ApplyResources(this.cbxGeneric_YN, "cbxGeneric_YN");
            this.cbxGeneric_YN.BackgroundImage = null;
            this.cbxGeneric_YN.Name = "cbxGeneric_YN";
            this.cbxGeneric_YN.UseVisualStyleBackColor = false;
            this.cbxGeneric_YN.CheckedChanged += new System.EventHandler(this.cbxGeneric_YN_CheckedChanged);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.AccessibleDescription = null;
            this.btnDeleteAll.AccessibleName = null;
            resources.ApplyResources(this.btnDeleteAll, "btnDeleteAll");
            this.btnDeleteAll.BackgroundImage = null;
            this.btnDeleteAll.Image = global::IHIS.OCSO.Properties.Resources.YESEN1;
            this.btnDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.AccessibleDescription = null;
            this.btnSelectAll.AccessibleName = null;
            resources.ApplyResources(this.btnSelectAll, "btnSelectAll");
            this.btnSelectAll.BackgroundImage = null;
            this.btnSelectAll.Image = global::IHIS.OCSO.Properties.Resources.YESUP1;
            this.btnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // grdSangInfo
            // 
            resources.ApplyResources(this.grdSangInfo, "grdSangInfo");
            this.grdSangInfo.ApplyPaintEventToAllColumn = true;
            this.grdSangInfo.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell39,
            this.xEditGridCell125,
            this.xEditGridCell57,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell58,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell130,
            this.xEditGridCell74,
            this.xEditGridCell126,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell105,
            this.xEditGridCell106,
            this.xEditGridCell107,
            this.xEditGridCell108,
            this.xEditGridCell109,
            this.xEditGridCell110,
            this.xEditGridCell111,
            this.xEditGridCell112,
            this.xEditGridCell113,
            this.xEditGridCell114,
            this.xEditGridCell115,
            this.xEditGridCell116,
            this.xEditGridCell117,
            this.xEditGridCell118,
            this.xEditGridCell119,
            this.xEditGridCell120,
            this.xEditGridCell121,
            this.xEditGridCell122,
            this.xEditGridCell123,
            this.xEditGridCell124,
            this.xEditGridCell98,
            this.xEditGridCell78});
            this.grdSangInfo.ColPerLine = 8;
            this.grdSangInfo.Cols = 9;
            this.grdSangInfo.EnableMultiSelection = true;
            this.grdSangInfo.ExecuteQuery = null;
            this.grdSangInfo.FixedCols = 1;
            this.grdSangInfo.FixedRows = 1;
            this.grdSangInfo.HeaderHeights.Add(29);
            this.grdSangInfo.Name = "grdSangInfo";
            this.grdSangInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSangInfo.ParamList")));
            this.grdSangInfo.QuerySQL = resources.GetString("grdSangInfo.QuerySQL");
            this.grdSangInfo.ReadOnly = true;
            this.grdSangInfo.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdSangInfo.RowHeaderVisible = true;
            this.grdSangInfo.Rows = 2;
            this.grdSangInfo.RowStateCheckOnPaint = false;
            this.grdSangInfo.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdSangInfo.ToolTipActive = true;
            this.grdSangInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSangInfo_QueryStarting);
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell34.CellName = "ju_sang_yn";
            this.xEditGridCell34.CellWidth = 25;
            this.xEditGridCell34.Col = 1;
            this.xEditGridCell34.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.ImageList = this.ImageList;
            this.xEditGridCell34.IsUpdatable = false;
            this.xEditGridCell34.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell34.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell35.CellName = "sang_code";
            this.xEditGridCell35.CellWidth = 108;
            this.xEditGridCell35.Col = 3;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.ImageList = this.ImageList;
            this.xEditGridCell35.IsUpdatable = false;
            this.xEditGridCell35.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell35.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "gwa_name";
            this.xEditGridCell39.Col = 2;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsUpdatable = false;
            this.xEditGridCell39.IsUpdCol = false;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.CellName = "ser";
            this.xEditGridCell125.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell125.Col = -1;
            this.xEditGridCell125.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell125, "xEditGridCell125");
            this.xEditGridCell125.IsUpdatable = false;
            this.xEditGridCell125.IsVisible = false;
            this.xEditGridCell125.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell57.CellName = "display_sang_name";
            this.xEditGridCell57.CellWidth = 376;
            this.xEditGridCell57.Col = 4;
            this.xEditGridCell57.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.ImageList = this.ImageList;
            this.xEditGridCell57.IsUpdatable = false;
            this.xEditGridCell57.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell57.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell99.CellName = "sang_start_date";
            this.xEditGridCell99.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell99.CellWidth = 129;
            this.xEditGridCell99.Col = 5;
            this.xEditGridCell99.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsUpdatable = false;
            this.xEditGridCell99.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell99.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell100.CellName = "sang_end_date";
            this.xEditGridCell100.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell100.CellWidth = 103;
            this.xEditGridCell100.Col = 8;
            this.xEditGridCell100.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsUpdatable = false;
            this.xEditGridCell100.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell100.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell101.CellName = "sang_end_sayu";
            this.xEditGridCell101.CellWidth = 114;
            this.xEditGridCell101.Col = 7;
            this.xEditGridCell101.ExecuteQuery = null;
            this.xEditGridCell101.HeaderImageStretch = true;
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsUpdatable = false;
            this.xEditGridCell101.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell101.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "bunho";
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsUpdatable = false;
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "naewon_date";
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsUpdatable = false;
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "gwa";
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsUpdatable = false;
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "doctor";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsUpdatable = false;
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "naewon_type";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsUpdatable = false;
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.CellName = "jubsu_no";
            this.xEditGridCell130.Col = -1;
            this.xEditGridCell130.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell130, "xEditGridCell130");
            this.xEditGridCell130.IsUpdatable = false;
            this.xEditGridCell130.IsVisible = false;
            this.xEditGridCell130.Row = -1;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "pk_order";
            this.xEditGridCell74.Col = -1;
            this.xEditGridCell74.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsUpdatable = false;
            this.xEditGridCell74.IsVisible = false;
            this.xEditGridCell74.Row = -1;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "sang_name";
            this.xEditGridCell126.Col = -1;
            this.xEditGridCell126.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell126, "xEditGridCell126");
            this.xEditGridCell126.IsUpdatable = false;
            this.xEditGridCell126.IsVisible = false;
            this.xEditGridCell126.Row = -1;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "pre_modifier1";
            this.xEditGridCell103.Col = -1;
            this.xEditGridCell103.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.IsUpdatable = false;
            this.xEditGridCell103.IsVisible = false;
            this.xEditGridCell103.Row = -1;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "pre_modifier2";
            this.xEditGridCell104.Col = -1;
            this.xEditGridCell104.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
            this.xEditGridCell104.IsUpdatable = false;
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "pre_modifier3";
            this.xEditGridCell105.Col = -1;
            this.xEditGridCell105.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell105, "xEditGridCell105");
            this.xEditGridCell105.IsUpdatable = false;
            this.xEditGridCell105.IsVisible = false;
            this.xEditGridCell105.Row = -1;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "pre_modifier4";
            this.xEditGridCell106.Col = -1;
            this.xEditGridCell106.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            this.xEditGridCell106.IsUpdatable = false;
            this.xEditGridCell106.IsVisible = false;
            this.xEditGridCell106.Row = -1;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "pre_modifier5";
            this.xEditGridCell107.Col = -1;
            this.xEditGridCell107.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell107, "xEditGridCell107");
            this.xEditGridCell107.IsUpdatable = false;
            this.xEditGridCell107.IsVisible = false;
            this.xEditGridCell107.Row = -1;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "pre_modifier6";
            this.xEditGridCell108.Col = -1;
            this.xEditGridCell108.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell108, "xEditGridCell108");
            this.xEditGridCell108.IsUpdatable = false;
            this.xEditGridCell108.IsVisible = false;
            this.xEditGridCell108.Row = -1;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "pre_modifier7";
            this.xEditGridCell109.Col = -1;
            this.xEditGridCell109.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell109, "xEditGridCell109");
            this.xEditGridCell109.IsUpdatable = false;
            this.xEditGridCell109.IsVisible = false;
            this.xEditGridCell109.Row = -1;
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "pre_modifier8";
            this.xEditGridCell110.Col = -1;
            this.xEditGridCell110.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell110, "xEditGridCell110");
            this.xEditGridCell110.IsUpdatable = false;
            this.xEditGridCell110.IsVisible = false;
            this.xEditGridCell110.Row = -1;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "pre_modifier9";
            this.xEditGridCell111.Col = -1;
            this.xEditGridCell111.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell111, "xEditGridCell111");
            this.xEditGridCell111.IsUpdatable = false;
            this.xEditGridCell111.IsVisible = false;
            this.xEditGridCell111.Row = -1;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "pre_modifier10";
            this.xEditGridCell112.Col = -1;
            this.xEditGridCell112.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell112, "xEditGridCell112");
            this.xEditGridCell112.IsUpdatable = false;
            this.xEditGridCell112.IsVisible = false;
            this.xEditGridCell112.Row = -1;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellName = "pre_modifier_name";
            this.xEditGridCell113.Col = -1;
            this.xEditGridCell113.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell113, "xEditGridCell113");
            this.xEditGridCell113.IsUpdatable = false;
            this.xEditGridCell113.IsVisible = false;
            this.xEditGridCell113.Row = -1;
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "post_modifier1";
            this.xEditGridCell114.Col = -1;
            this.xEditGridCell114.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell114, "xEditGridCell114");
            this.xEditGridCell114.IsUpdatable = false;
            this.xEditGridCell114.IsVisible = false;
            this.xEditGridCell114.Row = -1;
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "post_modifier2";
            this.xEditGridCell115.Col = -1;
            this.xEditGridCell115.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell115, "xEditGridCell115");
            this.xEditGridCell115.IsUpdatable = false;
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "post_modifier3";
            this.xEditGridCell116.Col = -1;
            this.xEditGridCell116.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell116, "xEditGridCell116");
            this.xEditGridCell116.IsUpdatable = false;
            this.xEditGridCell116.IsVisible = false;
            this.xEditGridCell116.Row = -1;
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "post_modifier4";
            this.xEditGridCell117.Col = -1;
            this.xEditGridCell117.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell117, "xEditGridCell117");
            this.xEditGridCell117.IsUpdatable = false;
            this.xEditGridCell117.IsVisible = false;
            this.xEditGridCell117.Row = -1;
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellName = "post_modifier5";
            this.xEditGridCell118.Col = -1;
            this.xEditGridCell118.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell118, "xEditGridCell118");
            this.xEditGridCell118.IsUpdatable = false;
            this.xEditGridCell118.IsVisible = false;
            this.xEditGridCell118.Row = -1;
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "post_modifier6";
            this.xEditGridCell119.Col = -1;
            this.xEditGridCell119.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell119, "xEditGridCell119");
            this.xEditGridCell119.IsUpdatable = false;
            this.xEditGridCell119.IsVisible = false;
            this.xEditGridCell119.Row = -1;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "post_modifier7";
            this.xEditGridCell120.Col = -1;
            this.xEditGridCell120.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell120, "xEditGridCell120");
            this.xEditGridCell120.IsUpdatable = false;
            this.xEditGridCell120.IsVisible = false;
            this.xEditGridCell120.Row = -1;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellName = "post_modifier8";
            this.xEditGridCell121.Col = -1;
            this.xEditGridCell121.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell121, "xEditGridCell121");
            this.xEditGridCell121.IsUpdatable = false;
            this.xEditGridCell121.IsVisible = false;
            this.xEditGridCell121.Row = -1;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellName = "post_modifier9";
            this.xEditGridCell122.Col = -1;
            this.xEditGridCell122.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell122, "xEditGridCell122");
            this.xEditGridCell122.IsUpdatable = false;
            this.xEditGridCell122.IsVisible = false;
            this.xEditGridCell122.Row = -1;
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellName = "post_modifier10";
            this.xEditGridCell123.Col = -1;
            this.xEditGridCell123.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell123, "xEditGridCell123");
            this.xEditGridCell123.IsUpdatable = false;
            this.xEditGridCell123.IsVisible = false;
            this.xEditGridCell123.Row = -1;
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "post_modifier_name";
            this.xEditGridCell124.Col = -1;
            this.xEditGridCell124.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell124, "xEditGridCell124");
            this.xEditGridCell124.IsUpdatable = false;
            this.xEditGridCell124.IsVisible = false;
            this.xEditGridCell124.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "bulyong_check";
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsUpdatable = false;
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "sang_jindan_date";
            this.xEditGridCell78.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell78.CellWidth = 123;
            this.xEditGridCell78.Col = 6;
            this.xEditGridCell78.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            // 
            // tabGroup
            // 
            this.tabGroup.AccessibleDescription = null;
            this.tabGroup.AccessibleName = null;
            resources.ApplyResources(this.tabGroup, "tabGroup");
            this.tabGroup.BackgroundImage = null;
            this.tabGroup.Font = null;
            this.tabGroup.IDEPixelArea = true;
            this.tabGroup.IDEPixelBorder = false;
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.SelectionChanged += new System.EventHandler(this.tabGroup_SelectionChanged);
            // 
            // dloSelectOCS1003
            // 
            this.dloSelectOCS1003.ExecuteQuery = null;
            this.dloSelectOCS1003.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloSelectOCS1003.ParamList")));
            // 
            // dloOrder_danui
            // 
            this.dloOrder_danui.ExecuteQuery = null;
            this.dloOrder_danui.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.dloOrder_danui.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloOrder_danui.ParamList")));
            this.dloOrder_danui.QuerySQL = "SELECT A.CODE\r\n  FROM OCS0132 A\r\n WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE\r\n   A" +
                "ND A.CODE_TYPE = \'ORD_DANUI\'\r\n ORDER BY A.CODE";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_name";
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMixGroup.Images.SetKeyName(0, "");
            this.imageListMixGroup.Images.SetKeyName(1, "");
            this.imageListMixGroup.Images.SetKeyName(2, "");
            this.imageListMixGroup.Images.SetKeyName(3, "");
            this.imageListMixGroup.Images.SetKeyName(4, "");
            this.imageListMixGroup.Images.SetKeyName(5, "");
            this.imageListMixGroup.Images.SetKeyName(6, "");
            this.imageListMixGroup.Images.SetKeyName(7, "");
            this.imageListMixGroup.Images.SetKeyName(8, "");
            this.imageListMixGroup.Images.SetKeyName(9, "");
            this.imageListMixGroup.Images.SetKeyName(10, "");
            this.imageListMixGroup.Images.SetKeyName(11, "");
            this.imageListMixGroup.Images.SetKeyName(12, "");
            this.imageListMixGroup.Images.SetKeyName(13, "");
            this.imageListMixGroup.Images.SetKeyName(14, "");
            this.imageListMixGroup.Images.SetKeyName(15, "");
            this.imageListMixGroup.Images.SetKeyName(16, "");
            this.imageListMixGroup.Images.SetKeyName(17, "");
            this.imageListMixGroup.Images.SetKeyName(18, "");
            this.imageListMixGroup.Images.SetKeyName(19, "");
            // 
            // dloSelectOUT1001
            // 
            this.dloSelectOUT1001.ExecuteQuery = null;
            this.dloSelectOUT1001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloSelectOUT1001.ParamList")));
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "YESEN1.ICO");
            this.imageList1.Images.SetKeyName(1, "YESUP1.ICO");
            // 
            // timer_icon
            // 
            this.timer_icon.Interval = 3000;
            this.timer_icon.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // OCS1003Q09
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS1003Q09";
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.gbxHopeDate.ResumeLayout(false);
            this.gbxHopeDate.PerformLayout();
            this.gbxNalsu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001)).EndInit();
            this.pnlKijun.ResumeLayout(false);
            this.tabOrderGubun.ResumeLayout(false);
            this.xPanel6.ResumeLayout(false);
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnderArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSangInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS1003)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOrder_danui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOUT1001)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region [Screen Event]

        public override object Command(string command, CommonItemCollection commandParam)
        {
            return base.Command(command, commandParam);
        }

        int patientFormX;

        protected override void OnLoad(EventArgs e)
        {
            //https://sofiamedix.atlassian.net/browse/MED-15391
            Form form = Parent.Parent as Form;
            if (form != null)
            {
                Size formSize = new Size(1246, 598);
                form.MinimumSize = formSize;
                form.Size = formSize;
            }

            patientFormX = ParentForm.Location.X;

            //ntt 처방일자
            grdOCS1003.AutoSizeColumn(3, 0);
            grdOUT1001.SetBindVarValue("f_io_gubun", "O");

            try
            {
                popupMenu.MenuCommands.Clear();
                popupMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG001_MSG, (Image)this.ImageList.Images[2],
                    new EventHandler(this.PopUpMenuGumsaInfo_Click)));
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.Message);
            }

            mMenuPFEResult.MenuCommands.Clear();
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
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_6, (Image)this.ImageList.Images[13], new EventHandler(btnAPLResult_Click));
                    popUpMenu.Tag = "1";
                    item = GetItemHideButton(result.Dt, "CPL");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_7, (Image)this.ImageList.Images[11], new EventHandler(btnXRTResult_Click));
                    popUpMenu.Tag = "2";
                    item = GetItemHideButton(result.Dt, "XRT");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG002_MSG, (Image)this.ImageList.Images[10], new EventHandler(PopUpMenuPfeResult_Click));
                    popUpMenu.Tag = "3";
                    item = GetItemHideButton(result.Dt, "END");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG003_MSG, (Image)this.ImageList.Images[17], new EventHandler(PopUpMenuPfeResult_Click));
                    popUpMenu.Tag = "4";
                    item = GetItemHideButton(result.Dt, "ENDR");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_3, (Image)this.ImageList.Images[7], new EventHandler(PopUpMenuPfeResult_Click));
                    popUpMenu.Tag = "5";
                    item = GetItemHideButton(result.Dt, "EKG");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                }
                else
                {
                    btnPFEResult.Visible = false;
                }
            }

            // Call된 경우
            if (this.OpenParam != null)
            {
                try
                {
                    if (OpenParam.Contains("bunho"))
                    {
                        if (OpenParam["bunho"].ToString().Trim() == "")
                        {
                            mbxMsg = Resources.MSG005_MSG;
                            mbxCap = "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            this.Close();
                            return;
                        }
                        else
                            mBunho = OpenParam["bunho"].ToString().Trim();
                    }
                    else
                    {
                        mbxMsg = Resources.MSG005_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        this.Close();
                        return;
                    }

                    if (OpenParam.Contains("gwa"))
                    {
                        if (OpenParam["gwa"].ToString().Trim() == "")
                        {
                            mbxMsg = Resources.MSG006_MSG;
                            mbxCap = "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            this.Close();
                            return;
                        }
                        else
                            mGwa = OpenParam["gwa"].ToString().Trim();
                    }
                    else
                    {
                        mbxMsg = Resources.MSG006_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        this.Close();
                        return;
                    }


                    if (OpenParam.Contains("input_gubun"))
                    {
                        if (OpenParam["input_gubun"].ToString().Trim() == "")
                        {

                            mbxMsg = Resources.MSG007_MSG;
                            mbxCap = "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            this.Close();
                            return;
                        }
                        else
                        {
                            string temp = "";
                            String[] mCanDoList;
                            if (mInput_gubun != "DA")
                            {
                                mInput_gubun = OpenParam["input_gubun"].ToString().Trim();
                                mOrderBiz.LoadColumnCodeName("code", "DO_INPUT_TAB_POSSIBLE", mInput_gubun, ref temp);

                                mCanDoList = temp.Split('/');
                            
                                for(int i = 0; i < mCanDoList.Length; i++)
                                {
                                    mCanDoArrList.Add(mCanDoList[i].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        mbxMsg = Resources.MSG007_MSG;
                        mbxCap = "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        this.Close();
                        return;
                    }
                                      

                    //pk_order
                    if (OpenParam.Contains("pk_order"))
                    {
                        mPk_order = OpenParam["pk_order"].ToString().Trim();
                    }

                    mNaewon_date = DateTime.Now.ToString("yyyy/MM/dd");
                    if (OpenParam.Contains("naewon_date"))
                    {
                        if (TypeCheck.IsDateTime(OpenParam["naewon_date"].ToString()))
                            mNaewon_date = OpenParam["naewon_date"].ToString();
                    }

                    this.dpkNaewon_date.SetDataValue(mNaewon_date);
                    this.dpkSetHopeDate.SetDataValue(mNaewon_date);

                    //Data가 없는 경우 화면 닫을지 여부
                    if (OpenParam.Contains("auto_close"))
                    {
                        mAuto_close = bool.Parse(OpenParam["auto_close"].ToString().Trim());
                        //if(mAuto_close) this.ParentForm.WindowState = FormWindowState.Minimized;
                        if (mAuto_close) this.ParentForm.Location = new Point(0 - ParentForm.Size.Width, ParentForm.Location.Y);
                    }

                    if (OpenParam.Contains("tel_yn"))
                    {
                        mTel_yn = OpenParam["tel_yn"].ToString().Trim();
                    }

                    if (TypeCheck.IsNull(mTel_yn))
                        mTel_yn = "%";

                    if (OpenParam.Contains("input_tab"))
                    {
                        mInput_tab = OpenParam["input_tab"].ToString().Trim();
                    }

                    if (OpenParam.Contains("io_gubun"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["io_gubun"].ToString()))
                        {
                            mIOgubun = OpenParam["io_gubun"].ToString();
                        }
                    }
                    if (OpenParam.Contains("childYN"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["childYN"].ToString()))
                        {
                            mChildYN = OpenParam["childYN"].ToString();
                        }
                    }

                    if(OpenParam.Contains("patient_info"))
                    {
                        this.mPatientInfo = (PatientInfo)OpenParam["patient_info"];
                    }

                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, "");
                    this.Close();
                }
            }
            else
            {
                mBunho = "00044383";
                mGwa = "EN";
                mNaewon_date = DateTime.Now.ToString("yyyy/MM/dd");
                dpkNaewon_date.SetDataValue(mNaewon_date);
                mInput_gubun = "D0";
            }

            // Load all comboboxes
            LoadAllCombos();

            this.initScreen();

            //Set M/D Relation

            grdOCS1003.SetRelationKey("bunho", "bunho");
            grdOCS1003.SetRelationKey("naewon_date", "naewon_date");
            grdOCS1003.SetRelationKey("gwa", "gwa");
            grdOCS1003.SetRelationKey("input_gubun", "input_gubun");

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private CheckHideButtonInfo GetItemHideButton(List<CheckHideButtonInfo> lst, string code)
        {
            foreach (CheckHideButtonInfo item in lst)
            {
                if (item.Code.Equals(code)) return item;
            }
            return null;
        }

        /// <summary>
        /// Load시 별도 Design할 부분이 있는 경우 여기서 Coding처리
        /// </summary>
        private void initScreen()
        {
            this.cboKijunGubun.SelectedIndex = 0;
            // 여기서 처리 하세요
            //this.mOrderBiz.SetNumCombo(this.grdOCS1003, "suryang", true);
            //this.mOrderBiz.SetNumCombo(this.grdOCS1003, "nalsu", false);
            //this.mOrderBiz.SetNumCombo(this.grdOCS1003, "dv", false);
            this.mOrderBiz.SetNumCombo(this.grdOCS1003, "suryang", true, Utility.ConvertToDataTable(_allCboResult.DataForSuryang));
            this.mOrderBiz.SetNumCombo(this.grdOCS1003, "nalsu", true, Utility.ConvertToDataTable(_allCboResult.DataForNalsu));
            this.mOrderBiz.SetNumCombo(this.grdOCS1003, "dv", true, Utility.ConvertToDataTable(_allCboResult.DataForDv));

            if (this.mInput_gubun == "CK" && !this.mOrderBiz.getEnablePostApprove(this.mIOgubun, this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString()))
            {
                this.btnProcessD0.Visible = true;
                this.btnProcessD0.Text = Resources.BTN_PROCESS_D0_1_TEXT;
                this.btnProcessD4.Visible = false;
                this.btnProcessD7.Visible = false;
                this.cboKijunGubun.SelectedIndex = 0;
            }
            else if (this.mIOgubun == "O" || ((XScreen)Opener).ScreenID != "OCS2003P01")
            {
                this.btnProcessD0.Visible = true;
                this.btnProcessD0.Text = Resources.BTN_PROCESS_D0_2_TEXT;
                this.btnProcessD4.Visible = false;
                this.btnProcessD7.Visible = false;
                //this.cboKijunGubun.Visible = false;
                this.cboKijunGubun.SelectedIndex = 0;
            }
            else
                this.cboKijunGubun.SelectedIndex = 1;

            this.grdOUT1001.AutoSizeColumn(5, 0);
            this.grdOUT1001.AutoSizeColumn(6, 0);
            this.grdOUT1001.AutoSizeColumn(7, 0);
        }

        private void PostLoad()
        {
            if (TypeCheck.IsNull(mBunho))
            {
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                {
                    // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                    patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                }

                if (patientInfo != null)
                {
                    this.pbxSearch.SetPatientID(patientInfo.BunHo);
                }
            }
            else
                this.pbxSearch.SetPatientID(mBunho);		

            //comboBox생성
            CreateCombo();

            //DataLayout 생성
            CreateLayout();

            // IO_Gubun 에 대한 라디오 박스 처리
            if (this.mIOgubun == "O")
            {
                this.rbtOut.Checked = true;
            }
            else
            {
                this.rbtIn.Checked = true;
            }

            //check layout
            //FormWindowState가 Normal로 돌아가면서 문제가 생겨서 check Layout으로 check
            if (mAuto_close)
            {
                IHIS.Framework.MultiLayout dloCheckLayout;
                dloCheckLayout = this.grdOUT1001.CloneToLayout();
                dloCheckLayout.QuerySQL = grdOUT1001.QuerySQL;

                // Connect cloud
                dloCheckLayout.ParamList = new List<string>(new String[]{"f_bunho", "f_naewon_date", "f_gwa", "f_input_gubun", "f_tel_yn"});
                dloCheckLayout.ExecuteQuery = dloCheckLayout_ExecuteQuery;
                
                dloCheckLayout.SetBindVarValue("f_bunho",       mBunho);
                dloCheckLayout.SetBindVarValue("f_naewon_date", mNaewon_date);
                dloCheckLayout.SetBindVarValue("f_gwa",         mGwa);
                dloCheckLayout.SetBindVarValue("f_input_gubun", mInput_gubun);
                dloCheckLayout.SetBindVarValue("f_tel_yn",      mTel_yn);
                dloCheckLayout.SetBindVarValue("f_hosp_code",   mHospCode);

                if (!dloCheckLayout.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

                if (dloCheckLayout.RowCount < 1 && mAuto_close) 
                {
                    this.Close();

                    dloSelectOCS1003.Dispose();
                    return;
                }
            }

            if (mAuto_close) this.ParentForm.Location = new Point(patientFormX, ParentForm.Location.Y);

            dpkNaewon_date.SetDataValue(mNaewon_date);

           
            // 전체과 디폴트 선택 
            this.chkAll.Checked = true;

            if (this.mIOgubun == "O")
                this.gbxHopeDate.Enabled = false;

            // 날수 콤보
            //this.mOrderBiz.SetNumCombo(this.cboNalsu, "nalsu", false);
            this.mOrderBiz.SetNumCombo(this.cboNalsu, "nalsu", true, Utility.ConvertToDataTable(_allCboResult.DataForDv));

            this.cboNalsu.MaxDropDownItems = this.cboNalsu.Items.Count;

            if (this.cboNalsu.Items.Count > 0)
                this.cboNalsu.SelectedValue = "7";

            this.Refresh();

            this.btnList.PerformClick(FunctionType.Query);
        }

        /// <summary>
        /// DataLayout LayoutItems생성
        /// </summary>
        private void CreateLayout()
        {
            //OCS1003
            foreach (XGridCell cell in this.grdOCS1003.CellInfos)
            {
                dloSelectOCS1003.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
            }

            dloSelectOCS1003.InitializeLayoutTable();
        }
        #endregion

        #region [Combo 생성]

        private void CreateCombo()
        {
            IHIS.Framework.MultiLayout layoutCombo;
            layoutCombo = new MultiLayout();

            //주사
            layoutCombo.Reset();
            layoutCombo.LayoutItems.Clear();
            layoutCombo.LayoutItems.Add("code", DataType.String);
            layoutCombo.LayoutItems.Add("code_name", DataType.String);
            layoutCombo.InitializeLayoutTable();

            layoutCombo.ExecuteQuery = layoutCombo_ExecuteQuery;
            /*layoutCombo.QuerySQL = @"SELECT A.CODE, A.CODE_NAME
                                       FROM OCS0132 A
                                      WHERE A.CODE_TYPE = 'JUSA'
                                        AND A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
                                      ORDER BY A.CODE";*/
            layoutCombo.QueryLayout(false);

            if (Service.ErrCode == 0 && layoutCombo.LayoutTable != null)
            {
                grdOCS1003.SetComboItems("jusa", layoutCombo.LayoutTable, "code_name", "code");
            }

            if (_allCboResult != null)
            {
                // Combo 세팅
                DataTable dtTemp = null;

                // 급여구분
                //                dtTemp = this.mOrderBiz.LoadComboDataSource("pay").LayoutTable;
                dtTemp = Utility.ConvertToDataTable(_allCboResult.DataForColPay);
                this.grdOCS1003.SetComboItems("pay", dtTemp, "code_name", "code", XComboSetType.NoAppend);

                // 이동촬영여부
                //                dtTemp = this.mOrderBiz.LoadComboDataSource("portable_yn").LayoutTable;
                dtTemp = Utility.ConvertToDataTable(_allCboResult.DataForPortableYn);
                this.grdOCS1003.SetComboItems("portable_yn", dtTemp, "code_name", "code", XComboSetType.NoAppend);

                // 주사스피드구분
                //                dtTemp = this.mOrderBiz.LoadComboDataSource("jusa_spd_gubun").LayoutTable;
                dtTemp = Utility.ConvertToDataTable(_allCboResult.DataForJusaSpdGubun);
                this.grdOCS1003.SetListItems("jusa_spd_gubun", dtTemp, "code_name", "code", XComboSetType.AppendNone);
            }
            // End connect to cloud
        }
        #endregion

        #region [QueryEnd Event]
        private void grdOUT1001_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            //select 정보 reset
            //dloSelectOCS1001.Reset();
            //dloSelectOCS1003.Reset();
            //bool isSelect = false;

            this.SetSelectNaewon(-1);

            //SelectionBackColorChange(grdOUT1001);
            //this.DisplayListImage(grdOUT1001);
        }

        private void grdOCS1003_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            //SelectionBackColorChange(grdOCS1003);
            childSetImage();
        }
        #endregion

        private void setSelectedDloData()
        {
            DataRow [] dr = null;
            for (int i = 0; i < this.grdOCS1003.DisplayRowCount; i++)
            {
                if (this.grdOCS1003.GetItemString(i, "select") == "Y")
                {
                    dr = this.dloSelectOCS1003.LayoutTable.Select("pkocs1003='" + this.grdOCS1003.GetItemString(i, "pkocs1003") + "'");

                    if (dr.Length > 0)
                    {
                        this.grdOCS1003.SetItemValue(i, "hope_date", dr[0]["hope_date"].ToString());
                        this.grdOCS1003.SetItemValue(i, "nalsu", dr[0]["nalsu"].ToString());

                        this.grdOCS1003.SetItemValue(i, "suryang", dr[0]["suryang"].ToString());
                        this.grdOCS1003.SetItemValue(i, "dv", dr[0]["dv"].ToString());
                    }
                }
            }
        }
        string GetMaxGroupSer(MultiLayout layout)
        {
            int max = int.Parse(layout.GetItemString(0, "group_ser"));

            for (int i = 0; i < layout.RowCount; i++)
            {
                for (int j = i; j < layout.RowCount; j++)
                {
                    if (max < int.Parse(layout.GetItemString(j, "group_ser")))
                    {
                        max = int.Parse(layout.GetItemString(j, "group_ser"));
                    }
                }
            }
            max = max + 1;
            return max.ToString();
        }

        #region [Return Layout 생성]
        private void CreateReturnLayout(string aInputGubun)
        {
            this.AcceptData();

            if ((this.mInput_gubun == "CK" && !this.mOrderBiz.getEnablePostApprove(this.mIOgubun, this.mPatientInfo.GetPatientInfo["approve_doctor"].ToString()))
                 || this.mIOgubun               == "O" 
                 || ((XScreen)Opener).ScreenID  != "OCS2003P01"
               )
                aInputGubun = this.mInput_gubun;

            string pk_order = "";
            int base_Nalsu = 0;
            DataRow row;
            //DataRow row2;
            //DataRow row3;

            for (int i = 0; i < dloSelectOCS1003.RowCount; i++)
            {
                row = dloSelectOCS1003.LayoutTable.Rows[i];
                
                //order 단위가 현재 존재하지 않는 경우
                if (row["ord_danui_check"].ToString() == "Y")
                {
                    //order 단위가 없는 경우에는 SKip
                    if (row["ord_danui"].ToString().Trim() == "")
                    {
                        dloSelectOCS1003.LayoutTable.Rows.Remove(row);
                        i--;
                        continue;
                    }
                    else
                    {
                        if (!CheckOrd_danui(row["hangmog_code"].ToString(), row["ord_danui"].ToString()))
                        {
                            dloSelectOCS1003.LayoutTable.Rows.Remove(row);
                            i--;
                            continue;
                        }
                    }
                }
                // general_disp_yn = Y であるオーダはオーダ名を一般名に変えてlib.HangmogInfoに渡してそのまま一般名で返してもらう。
                if (row["general_disp_yn"].ToString().Trim() == "Y")
                {
                    row["hangmog_name"] = row["generic_name"].ToString().Trim();
                }
                pk_order = row["pk_order"].ToString();
                base_Nalsu = int.Parse(row["nalsu"].ToString());


                //order_gubun
                //header '0':정규
                row["order_gubun"] = "0" + row["order_gubun"].ToString().Substring(1, 1);

                //내복약,외용약,주사재택은 DO오더의 일수를 그대로 가져 온다.
                if (row["order_gubun_bas"].ToString() == "C" || row["order_gubun_bas"].ToString() == "D" ||
                    ((row["order_gubun_bas"].ToString() == "A" || row["order_gubun_bas"].ToString() == "B") && row["home_care_yn"].ToString() == "Y"))
                {
                    row["nalsu"] = base_Nalsu;
                }

                //無効フラグはDoで持ってこないように
                row["muhyo"] = "N";
                //
                row["nday_yn"] = "N";
                row["emergency"] = "N";
                
            }

            if (dloSelectOCS1003.LayoutTable.Rows.Count < 1)
                this.Close();

            if (chkIsNewGroup.Checked)
                mIsNewGroupSer = true;
            else
                mIsNewGroupSer = false;


            //약속코드선택정보가 있는 경우 Return Value
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

            CommonItemCollection commandParams = new CommonItemCollection();
            commandParams.Add("isnewgroup", mIsNewGroupSer);
            commandParams.Add("OCS1003", dloSelectOCS1003);
            commandParams.Add("input_gubun", aInputGubun); 
            scrOpener.Command(ScreenID, commandParams);

            this.Close();
        }
        //날수 및 기타 기본정보변경
        private void CreateReturnLayout()
        {
            this.AcceptData();

            string pk_order = "";
            int base_Nalsu = 0;
            DataRow row;
            //DataRow row2;
            //DataRow row3;

            for (int i = 0; i < dloSelectOCS1003.RowCount; i++)
            {
                row = dloSelectOCS1003.LayoutTable.Rows[i];
                //insert by jc[同じgroup_serであれば新しいgroup_serに変える]
                //for (int j = 0; j < i; j++)
                //{
                //    row2 = dloSelectOCS1003.LayoutTable.Rows[j];
                //    if (row["group_ser"].ToString() == row2["group_ser"].ToString()
                //        //&& row["naewon_date"].ToString() != row2["naewon_date"].ToString()
                //        && row["fk_key1001"].ToString() != row2["fk_key1001"].ToString())
                //    {
                //        string MaxGroupSer = GetMaxGroupSer(dloSelectOCS1003);
                //        string str = row["group_ser"].ToString();
                //        for (int k = 0; k < dloSelectOCS1003.RowCount; k++)
                //        {
                //            row3 = dloSelectOCS1003.LayoutTable.Rows[k];
                //            if (str == row3["group_ser"].ToString()
                //          //      && row["naewon_date"].ToString() == row3["naewon_date"].ToString()
                //                && row["fk_key1001"].ToString() == row3["fk_key1001"].ToString())
                //            {
                //                dloSelectOCS1003.SetItemValue(k, "group_ser", MaxGroupSer);
                //            }
                //        }
                //    }
                //}
                //order 단위가 현재 존재하지 않는 경우
                if (row["ord_danui_check"].ToString() == "Y")
                {
                    //order 단위가 없는 경우에는 SKip
                    if (row["ord_danui"].ToString().Trim() == "")
                    {
                        dloSelectOCS1003.LayoutTable.Rows.Remove(row);
                        i--;
                        continue;
                    }
                    else
                    {
                        if (!CheckOrd_danui(row["hangmog_code"].ToString(), row["ord_danui"].ToString()))
                        {
                            dloSelectOCS1003.LayoutTable.Rows.Remove(row);
                            i--;
                            continue;
                        }
                    }
                }
                // general_disp_yn = Y であるオーダはオーダ名を一般名に変えてlib.HangmogInfoに渡してそのまま一般名で返してもらう。
                if (row["general_disp_yn"].ToString().Trim() == "Y")
                {
                    row["hangmog_name"] = row["generic_name"].ToString().Trim();
                }
                pk_order = row["pk_order"].ToString();
                base_Nalsu = int.Parse(row["nalsu"].ToString());


                //order_gubun
                //header '0':정규
                row["order_gubun"] = "0" + row["order_gubun"].ToString().Substring(1, 1);

                //내복약,외용약,주사재택은 DO오더의 일수를 그대로 가져 온다.
                if (row["order_gubun_bas"].ToString() == "C" || row["order_gubun_bas"].ToString() == "D" ||
                    ((row["order_gubun_bas"].ToString() == "A" || row["order_gubun_bas"].ToString() == "B") && row["home_care_yn"].ToString() == "Y"))
                {
                    row["nalsu"] = base_Nalsu;
                }
                //無効フラグはDoで持ってこないように
                row["muhyo"] = "N";
                //
                row["nday_yn"] = "N";
                row["emergency"] = "N"; 
            }

            if (dloSelectOCS1003.LayoutTable.Rows.Count < 1)
                this.Close();

            if (chkIsNewGroup.Checked)
                mIsNewGroupSer = true;
            else
                mIsNewGroupSer = false;


            //약속코드선택정보가 있는 경우 Return Value
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

            CommonItemCollection commandParams = new CommonItemCollection();
            commandParams.Add("isnewgroup", mIsNewGroupSer);
            commandParams.Add("OCS1003", dloSelectOCS1003);
            scrOpener.Command(ScreenID, commandParams);

            this.Close();
        }
        #endregion

        #region [ButtonList]

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    //select 정보 reset
                    if (this.CurrMSLayout == grdOUT1001)
                    {
                        dloSelectOCS1003.Reset();
                    }

                    break;

                case FunctionType.Close:

                    dloSelectOCS1003.Dispose();

                    break;

                default:

                    break;
            }
        }

        #endregion

        #region [grdOUT1001 Event]

        private void grdOUT1001_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            // Connect to cloud get data for grdSangInfo,  grdOCS1003
            gridOcs1003AndSangData = getDataForGridOCS1003AndSangInfo();
            
            this.grdSangInfo.ExecuteQuery = grdSangInfo_ExecuteQuery;
            this.grdSangInfo.QueryLayout(true);

//            this.grdOCS1003.SetBindVarValue     ("f_io_gubun", this.mIOgubun);
            grdOCS1003.ExecuteQuery = grdOCS1003_ExecuteQuery;
            if (!grdOCS1003.QueryLayout(true))
            {
                XMessageBox.Show(Resources.grdOUT1001_RowFocusChanged_Execute_Error);
            }
            // End connect to cloud service

            if (tabOrderGubun.SelectedTab == null) return;

            foreach (IHIS.X.Magic.Controls.TabPage page in tabOrderGubun.TabPages)
            {
                if (tabOrderGubun.SelectedTab == page)
                    page.ImageIndex = 1;
                else
                    page.ImageIndex = 0;
            }

            //검사인 경우에는 실시일 기준으로 조회한다.
            if (tabOrderGubun.SelectedTab.Tag.ToString() == "4")
            {
                //                string filter = @" order_gubun_bas = 'G' 
                //                               or order_gubun_bas = 'H'
                //                               or order_gubun_bas = 'I'
                //                               or order_gubun_bas = 'J'
                //                               or order_gubun_bas = 'K'
                //                               or order_gubun_bas = 'L'
                //                               or order_gubun_bas = 'M'
                //                               or order_gubun_bas = 'N'
                //                               or order_gubun_bas = 'O'
                //                               or order_gubun_bas = 'Z'
                //                                 ";
                string filter = @" order_gubun_bas <> 'A' 
                               and order_gubun_bas <> 'B'
                               and order_gubun_bas <> 'C'
                               and order_gubun_bas <> 'D'
                               and order_gubun_bas <> 'E'
                               and order_gubun_bas <> 'F'
                                 ";
                this.grdOCS1003.SetFilter(filter);
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "3")
            {
                string filter = @" order_gubun_bas = 'F' 
                                or order_gubun_bas = 'E'
                                or order_gubun_bas = 'N'
                                or order_gubun_bas = 'O'";
                this.grdOCS1003.SetFilter(filter);
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "2")
            {
                string filter = " order_gubun_bas = 'A' or order_gubun_bas = 'B' ";
                this.grdOCS1003.SetFilter(filter);
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "1")
            {
                string filter = " order_gubun_bas = 'C' or order_gubun_bas = 'D' ";
                this.grdOCS1003.SetFilter(filter);
            }
            else
            {
                this.grdOCS1003.SetFilter("");
            }

            //this.ClearDetailInfo();

            //this.MakeGroupTab(this.grdOCS1003);

            this.SetInitialOrderGridCheckImage();

            //dloSelectOCS1003.Reset();

            //for(int i = 0; i < this.grdOUT1001.RowCount; i++)
            //{
            //    this.grdOUT1001.SetItemValue(i, "select", "N");
            //    SelectionBackColorChange(this.grdOUT1001, i, "N");
            //}

            this.childSetImage();
        }


        /// <summary>
        /// 오더일자 List에 퇴원약여부 등을 표시한다.
        /// </summary>
        private void DisplayListImage(XGrid aGrd)
        {
            if (aGrd == null) return;

            try
            {
                for (int i = 0; i < aGrd.RowCount; i++)
                {
                    if (aGrd.GetItemValue(i, "toiwon_drg").ToString().Trim() == "Y") // 퇴원약
                    {
                        aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];
                        aGrd[i + aGrd.HeaderHeights.Count, 0].ToolTipText = aGrd[i + aGrd.HeaderHeights.Count, 0].ToolTipText + Resources.MSG008_MSG;
                    }
                }
            }
            catch { }
            finally
            {

            }
        }

        #endregion

        #region [grdOCS1003 Event]

        private void grdOCS1003_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            if (e.DataRow["bulyong_check"].ToString() == "Y" || e.DataRow["bulyong_check"].ToString() == "Z")
            {
                e.BackColor = ((XEditGridCell)grdOCS1003.CellInfos[e.ColName]).RowBackColor.Color;
                e.ForeColor = Color.Red;
                //insert by jc [bulyong_checkがYである時チェックボックスの後ろのNが見えてしまう不具合を修正] 2012/04/06
                if (e.ColName == "select")
                    e.ForeColor = System.Drawing.Color.Transparent;
            }
            if (((this.mIOgubun == "I" && grid.GetItemString(e.RowNumber, "io_yn") == "O")
                  || (this.mIOgubun == "O" && grid.GetItemString(e.RowNumber, "io_yn") == "I")
                  )
                  && this.mInput_gubun != "D7"
                )
            {
                e.BackColor = Color.DarkGray;
                return;
            }

            #region 코드만 화면 Display하는 필드를 명칭으로 ToolTip 처리
            switch (e.ColName)
            {
                case "bogyong_name": // 복용명
                    grdOCS1003[e.RowNumber, e.ColName].ToolTipText = grdOCS1003.GetItemString(e.RowNumber, "bogyong_name") + grdOCS1003.GetItemString(e.RowNumber, "dv_name");
                    if (
                          (
                               (this.mIOgubun == "I" && grdOCS1003.GetItemString(e.RowNumber, "io_yn") == "O")
                            || (this.mIOgubun == "O" && grdOCS1003.GetItemString(e.RowNumber, "io_yn") == "I")
                          )
                          && this.mInput_gubun != "D7"
                        )
                        e.BackColor = Color.Red;
                    
                    break;

                case "child_yn":

                    e.ForeColor = Color.Transparent;

                    break;
                case "general_disp_yn":
                    if (this.grdOCS1003.GetItemString(e.RowNumber, e.ColName) == "Y")
                        e.BackColor = Color.LightCyan;
                    //else
                    //    e.BackColor = Color.Transparent;
                    break;

                case "nalsu":
                    if (e.ColName == "nalsu" && (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C") && e.DataRow["donbog_yn"].ToString() != "Y")
                    {
                        e.ForeColor = Color.Red;
                        e.BackColor = Color.LightGreen;
                        e.Font = new Font(IHIS.Framework.XEditGrid.DefaultFont.FontFamily, 12, FontStyle.Bold);
                        this.gbxNalsu.Enabled = true;
                    }
                    break;

                case "suryang":
                    if (e.ColName == "suryang" && (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "D") || e.DataRow["donbog_yn"].ToString() == "Y")
                    {
                        e.ForeColor = Color.Red;
                        e.BackColor = Color.LightGreen;
                        e.Font = new Font(IHIS.Framework.XEditGrid.DefaultFont.FontFamily, 12, FontStyle.Bold);
                    }
                    break;

                case "dv":
                    if (e.ColName == "dv" && (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C" && TypeCheck.NVL(e.DataRow["donbog_yn"].ToString(), "N").ToString() == "Y"))
                    {
                        e.ForeColor = Color.Red;
                        e.BackColor = Color.LightGreen;
                        e.Font = new Font(IHIS.Framework.XEditGrid.DefaultFont.FontFamily, 12, FontStyle.Bold);
                    }
                    break;

                case "hope_date":
                    //if ((e.DataRow["order_gubun"].ToString().Substring(1, 1) == "D") || (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C"))
                    //{
                        e.ForeColor = Color.Red;
                        e.BackColor = Color.LightGreen;
                        e.Font = new Font(IHIS.Framework.XEditGrid.DefaultFont.FontFamily, 10, FontStyle.Bold);
                    //}
                    break;
                case "brought_drg_yn":
                    if (e.DataRow[e.ColName].ToString() == "Y")
                    {
                        e.ForeColor = Color.Red;
                    }
                    break;
            }
            #endregion

            
            // 処方状態による色変化 처방상태에 따른 색상 처리
            this.mHangmogInfo.ColumnColorForOrderState(mIOgubun, grid, e); // 처방상태에 따른 색상 처리

            //insert by jc [院内採用薬の場合ROWの色を塗る。]
            this.mColumnControl.ColumnColorForCodeQueryGrid(mIOgubun, grid, e); //sunab_check column 追加必！
        }

        private void grdOCS1003_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int rowIndex;
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                rowIndex = grdOCS1003.GetHitRowNumber(e.Y);
                if (rowIndex < 0) return;

                if (grdOCS1003.CurrentColNumber == 0)
                {
                    if (
                          (   (this.mIOgubun == "I" && grdOCS1003.GetItemString(rowIndex, "io_yn") != "O")
                           || (this.mIOgubun == "O" && grdOCS1003.GetItemString(rowIndex, "io_yn") != "I")
                          )
                          && this.mInput_gubun != "D7"
                        )
                    {
                        //불용처리된 것은 선택을 막는다.
                        if (grdOCS1003.GetItemString(rowIndex, "bulyong_check") == "Y")
                        {
                            //불용인 경우에는 해당 항목의 심사기준을 보여준다.
                            mbxMsg = this.mOrderBiz.LoadSimsa_comment(grdOCS1003.GetItemString(rowIndex, "hangmog_code"));
                            mbxCap = NetInfo.Language == LangMode.Jr ? Resources.MSG009_CAP : "확인";
                            if (!TypeCheck.IsNull(mbxMsg)) XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                            return;
                        }
                        //if (!this.mCanDoArrList.Contains(this.grdOCS1003.GetItemString(rowIndex, "input_tab")))
                        //{
                        //    XMessageBox.Show("定期処方で登録可能なオーダです。", "確認");
                        //    return;
                        //}

                        if (grdOCS1003.GetItemString(rowIndex, "select") == "N")
                        {
                            // 入院オーダで院内採用薬ではない場合は確認メッセージ出力
                            if (this.grdOCS1003.GetItemString(rowIndex, "wonnae_drg_yn") != "Y" 
                                && this.mIOgubun == "I"
                                && (this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1) == "C"
                                    || this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1) == "D"
                                    || this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1) == "B"
                                   )
                                )
                            {
                                if (XMessageBox.Show(Resources.MSG009_1_MSG+this.grdOCS1003.GetItemString(rowIndex, "hangmog_name") + Resources.MSG009_2_MSG, Resources.MSG009_CAP, MessageBoxButtons.YesNo) == DialogResult.No)
                                    return;
                            }
                            grdOCS1003.SetItemValue(rowIndex, "select", "Y");
                            this.InsertBackTable(grdOCS1003.LayoutTable.Rows[rowIndex]);
                            SelectionBackColorChange(sender, rowIndex, "Y");


                            //외래오더에서 호출이고 입원do오다 선택시
                            //원외처리
                            if (this.mIOgubun == "O" && this.rbtIn.Checked)
                            {
                                if (this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1, 1) == "C" ||
                                    this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1, 1) == "D")
                                {
                                    SetWonyoiOrderYN(rowIndex);
                                }
                            }
                        }
                        else
                        {
                            this.RemoveBackTable(grdOCS1003.LayoutTable.Rows[rowIndex]);
                            grdOCS1003.SetItemValue(rowIndex, "select", "N");
                            SelectionBackColorChange(sender, rowIndex, "N");
                        }

                        SetSelectNaewon(this.grdOUT1001.CurrentRowNumber);
                    }
                    else
                    {

                    }
                }
            }
            
        }

        private void SetWonyoiOrderYN(int rowIndex)
        {
            string inputSql = "";
            string tusuk_gwa = "";

            inputSql  = " SELECT FN_AKU_LOAD_TUSUK_GWA GWA";
            inputSql += "   FROM SYS.DUAL A ";

            if(!TypeCheck.IsNull(Service.ExecuteScalar(inputSql)))
            {
                tusuk_gwa = Service.ExecuteScalar(inputSql).ToString();
            }

            //투석과이면 무조건 원내
            if (this.mGwa != tusuk_gwa)
            {
                //원외만가능
                if (this.grdOCS1003.GetItemString(rowIndex, "default_wonyoi_order_yn") == "Y")
                    this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "Y");
                //원내만가능
                else if (this.grdOCS1003.GetItemString(rowIndex, "default_wonyoi_order_yn") == "N")
                    this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "N");
                //기본원외
                else if (this.grdOCS1003.GetItemString(rowIndex, "default_wonyoi_order_yn") == "1")
                    this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "Y");
                //기본원내
                else if (this.grdOCS1003.GetItemString(rowIndex, "default_wonyoi_order_yn") == "2")
                    this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "N");
                //그외는 원외처리
                else
                    this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "Y");

            }
            else
                this.grdOCS1003.SetItemValue(rowIndex, "wonyoi_order_yn", "N");

        }

        private void grdOCS1003_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (sender == null) return;

            XEditGrid grd = sender as XEditGrid;

            if (e.CurrentRow >= 0)
            {
                // 상태에 따른 필드헤더변경 (수량/날수 (마취처방코드인 경우 시간/분으로 표시), 부수술 (체감인경우 체감))
                this.mHangmogInfo.DisplaySpecialColHeader("O", grd, e.CurrentRow, grd.GetItemString(e.CurrentRow, "hangmog_code"));
            }
        }

        #endregion

        #region [Fuction]

        private void dpkNaewon_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //select 정보 reset
            dloSelectOCS1003.Reset();

            grdOUT1001.SetBindVarValue("f_naewon_date", e.DataValue);

            if (this.pbxSearch.BunHo.ToString() != "")
            {
                if (!grdOUT1001.QueryLayout(false)) 
                    XMessageBox.Show(Service.ErrFullMsg);
            }
        }

        private void SetSelectNaewon(int aRowNumber)
        {
            int currentRow = aRowNumber;
            bool select = false;
            int start_row = -1;
            int end_row = -1;

            if (aRowNumber < 0)
            {
                start_row = 0;
                end_row = this.grdOUT1001.RowCount;
            }
            else
            {
                start_row = aRowNumber;
                end_row = aRowNumber + 1;
            }

            for (int i=start_row; i<end_row; i++)
            {
               
                if (this.IsExistSelectedOrder(this.grdOUT1001.GetItemString(i, "pk_order"),
                                              this.grdOUT1001.GetItemString(i, "naewon_date"),
                                              this.grdOUT1001.GetItemString(i, "gwa"),
                                              this.grdOUT1001.GetItemString(i, "doctor")))
                    select = true;
                else
                    select = false;
               
               

                if (select)
                {
                    grdOUT1001.SetItemValue(i, "select", "Y");
                    SelectionBackColorChange(grdOUT1001, i, "Y");
                }
                else
                {
                    grdOUT1001.SetItemValue(i, "select", "N");
                    SelectionBackColorChange(grdOUT1001, i, "N");
                }
            }
            this.childSetImage();
        }

        private void SetInitialOrderGridCheckImage()
        {
            try
            {
                for (int i = 0; i < grdOCS1003.RowCount; i++)
                {
                    if (this.IsExistSelectedOrder(this.grdOCS1003.GetItemString(i, "pkocs1003"),
                                                  this.grdOCS1003.GetItemString(i, "naewon_date"),
                                                  this.grdOCS1003.GetItemString(i, "gwa"),
                                                  this.grdOCS1003.GetItemString(i, "doctor"),
                                                  this.grdOCS1003.GetItemString(i, "group_ser")))
                    {
                        grdOCS1003.SetItemValue(i, "select", "Y");
                        SelectionBackColorChange(grdOCS1003, i, "Y");
                    }
                    else
                    {
                        grdOCS1003.SetItemValue(i, "select", "N");
                        SelectionBackColorChange(grdOCS1003, i, "N");
                        
                    }
                }
                this.childSetImage();
                this.setSelectedDloData();
            }
            catch (System.Exception e)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(e.Message);
            }
          
        }

        //delete by jc [参照点がないため削除] 2012/04/10
        //private void MakeGroupTab(XEditGrid aGrid)
        //{
        //    string currentGroupSer = "";
        //    string title = "";
        //    IHIS.X.Magic.Controls.TabPage tpgGroup;

        //    this.tabGroup.SelectionChanged -= new EventHandler(tabGroup_SelectionChanged);

        //    // 탭페이지 클리어
        //    try
        //    {
        //        this.tabGroup.TabPages.Clear();
        //    }
        //    catch
        //    {
        //        this.tabGroup.Refresh();
        //    }

        //    for (int i = 0; i < aGrid.RowCount; i++)
        //    {
        //        if (currentGroupSer != aGrid.GetItemString(i, "group_ser"))
        //        {
        //            if (aGrid.GetItemString(i, "input_tab") == "01") // 약인경우는 그룹탭에 복용법을 같이 보여준다.
        //            {
        //                title = aGrid.GetItemString(i, "group_ser") + " グループ : " + aGrid.GetItemString(i, "bogyong_name");
        //            }
        //            else
        //            {
        //                title = aGrid.GetItemString(i, "group_ser") + " グループ";
        //            }

        //            tpgGroup = new IHIS.X.Magic.Controls.TabPage(title);
        //            tpgGroup.ImageList = this.ImageList;
        //            tpgGroup.ImageIndex = 0;
        //            tpgGroup.Tag = aGrid.GetItemString(i, "group_ser");

        //            this.tabGroup.TabPages.Add(tpgGroup);

        //            currentGroupSer = aGrid.GetItemString(i, "group_ser");
        //        }
        //    }

        //    this.tabGroup.SelectionChanged += new EventHandler(tabGroup_SelectionChanged);

        //    SetInitialOrderGridCheckImage();

        //    this.tabGroup_SelectionChanged(this.tabGroup, new EventArgs());
        //}

        private void ClearDetailInfo()
        {
            //if (this.lblSelectOrder.Tag.ToString() == "Y")
            //{
            //    // 전체선택 해제 인경우 클리어
            //    lblSelectOrder_Click(this.lblSelectOrder, new EventArgs());
            //}

            this.btnDeleteAll.Tag = "N";
            this.btnDeleteAll.ImageIndex = 0;
            this.btnDeleteAll.Text = Resources.BTN_DELETE_ALL_TEXT;

            // 텝페이지 클리어
            try
            {
                this.tabGroup.TabPages.Clear();
            }
            catch
            {
                this.tabGroup.Refresh();
            }
        }

        #endregion

        #region [Cotrol Event]

        //전체진료과를 조회할 건지 여부
        private void chkAll_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkAll.Checked)
            {
                chkAll.BackColor = System.Drawing.SystemColors.ActiveCaption;
                chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                chkAll.ImageIndex = 1;

                grdOUT1001.SetBindVarValue("f_gwa", "%");
            }
            else
            {
                chkAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
                chkAll.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                chkAll.ImageIndex = 0;

                grdOUT1001.SetBindVarValue("f_gwa", mGwa);
            }

            grdOUT1001.SetBindVarValue("f_naewon_date", mNaewon_date);

            if (this.pbxSearch.BunHo.ToString() != "")
            {
                if (!grdOUT1001.QueryLayout(false)) 
                    XMessageBox.Show(Service.ErrFullMsg);
            }

        }
        //private void SetVisibleBtnProcess(bool aONOFF)
        //{
        //    this.btnProcessD4.Visible = aONOFF;
        //    this.btnProcessD7.Visible = aONOFF;
        //}
        
        private void InsertBackTable(DataRow dr)
        {
            if (this.dloSelectOCS1003.LayoutTable.Select("pkocs1003=" + dr["pkocs1003"].ToString()).Length <= 0)
                this.dloSelectOCS1003.LayoutTable.ImportRow(dr);

            if (this.dloSelectOCS1003.LayoutTable.Select("order_gubun LIKE '%B' OR order_gubun LIKE '%C' OR order_gubun LIKE '%D'").Length > 0)
                this.mIsDrugJusa = true;
            else
                this.mIsDrugJusa = false;

            //this.SetVisibleBtnProcess(this.mIsDrugJusa);
            
        }

        private void RemoveBackTable(DataRow dr)
        {
            DataRow[] rows = this.dloSelectOCS1003.LayoutTable.Select("pkocs1003=" + dr["pkocs1003"].ToString());
            foreach (DataRow row in rows)
                this.dloSelectOCS1003.LayoutTable.Rows.Remove(row);

            if (this.dloSelectOCS1003.LayoutTable.Select("order_gubun LIKE '%B' OR order_gubun LIKE '%C' OR order_gubun LIKE '%D'").Length > 0)
                this.mIsDrugJusa = true;
            else
                this.mIsDrugJusa = false;

            //this.SetVisibleBtnProcess(this.mIsDrugJusa);
        }

        private bool IsExistSelectedOrder(string aNaewonKey, string aOrderDate, string aGwa, string aDoctor, string aGroupSer)
        {
            if (rbtOut.Checked == true)
            {
                DataRow[] dr = this.dloSelectOCS1003.LayoutTable.Select("pkocs1003=" + aNaewonKey + " AND group_ser=" + aGroupSer);

                if (dr.Length > 0) return true;
            }
            else
            {
                DataRow[] dr = this.dloSelectOCS1003.LayoutTable.Select("pkocs1003=" + aNaewonKey + " AND naewon_date='" + aOrderDate + "' AND gwa='" + aGwa + "' AND doctor='" + aDoctor + "' AND group_ser=" + aGroupSer);

                if (dr.Length > 0) return true;
            }

            return false;
        }

        private bool IsExistSelectedOrder(string aNaewonKey, string aOrderDate, string aGwa, string aDoctor)
        {
            if (rbtOut.Checked == true)
            {
                DataRow[] dr = this.dloSelectOCS1003.LayoutTable.Select("pk_order=" + aNaewonKey);

                if (dr.Length > 0) return true;
            }
            else
            {
                DataRow[] dr = null;
                //DataRow[] dr = this.dloSelectOCS1003.LayoutTable.Select("pk_order=" + aNaewonKey);

                if (this.cboKijunGubun.SelectedValue.ToString() == "O")
                    dr = this.dloSelectOCS1003.LayoutTable.Select("pk_order=" + aNaewonKey + " AND naewon_date='" + aOrderDate + "' AND gwa='" + aGwa + "' AND doctor='" + aDoctor + "'");
                else
                {
                    dr = this.dloSelectOCS1003.LayoutTable.Select("pk_order=" + aNaewonKey + " AND ((ori_hope_date='" + aOrderDate + "') OR (ori_hope_date is null AND naewon_date='" + aOrderDate + "')) AND gwa='" + aGwa + "' AND doctor='" + aDoctor + "'");

                    //if (dr.Length == 0)
                    //{
                    //    dr = this.dloSelectOCS1003.LayoutTable.Select("pk_order=" + aNaewonKey + " AND naewon_date='" + aOrderDate + "' AND gwa='" + aGwa + "' AND doctor='" + aDoctor + "'");
                    //}
                }

                if (dr.Length > 0) return true;
            }

            return false;
        }

        /// <summary>
        /// 해당 Grid 전체선택 해제
        /// </summary>
        /// <param name="grd"></param>
        /// <param name="select"></param>
        //private bool grdSelectAll(XGrid grdObject, string aGroupSer, bool select)
        private bool grdSelectAll(XGrid grdObject)
        {
            int rowIndex = -1;

            for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                if (this.grdOCS1003.GetItemString(rowIndex, "wonnae_drg_yn") != "Y" 
                    && this.mIOgubun == "I"
                    && (this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1) == "C"
                        || this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1) == "D"
                        || this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1) == "B"
                        )
                    )
                            
                {
                    if (XMessageBox.Show("[ " + this.grdOCS1003.GetItemString(rowIndex, "hangmog_name") + Resources.MSG009_2_MSG, Resources.MSG009_CAP, MessageBoxButtons.YesNo) == DialogResult.No)
                        continue;
                }

                if (grdObject.GetItemString(rowIndex, "bulyong_check") != "Y")
                {
                    if (   
                           (this.mIOgubun == "I" && grdObject.GetItemString(rowIndex, "io_yn") != "O") 
                        || (this.mIOgubun == "O" && grdObject.GetItemString(rowIndex, "io_yn") != "I")
                        || this.mInput_gubun == "D7" 
                        )
                    {
                        //if (!this.mCanDoArrList.Contains(this.grdOCS1003.GetItemString(rowIndex, "input_tab")))
                        //    continue;

                        this.InsertBackTable(grdObject.LayoutTable.Rows[rowIndex]);
                        this.SelectionBackColorChange(grdObject, rowIndex, "Y");
                        grdObject.SetItemValue(rowIndex, "select", "Y");
                    }
                    else
                    {

                    }
                }
            }


            //선택된 Row 표시
            SetSelectNaewon(this.grdOUT1001.CurrentRowNumber);

            return true;

        }

        private bool grdDeleteAll(XGrid grdObject)
        {
            int rowIndex = -1;

            for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                if (grdObject.GetItemString(rowIndex, "bulyong_check") != "Y")
                {
                    this.RemoveBackTable(grdObject.LayoutTable.Rows[rowIndex]);
                    this.SelectionBackColorChange(grdObject, rowIndex, "N");
                    grdObject.SetItemValue(rowIndex, "select", "N");
                }
            }
            //선택된 Row 표시
            SetSelectNaewon(this.grdOUT1001.CurrentRowNumber);

            return true;
        }

        private bool SelectCurrentTab(string aGroupSer, bool IsSelect)
        {
            
            for (int i = 0; i < this.grdOCS1003.RowCount; i++)
            {
                if (this.grdOCS1003.GetItemString(i, "group_ser") == aGroupSer)
                {
                    if (IsSelect)
                        this.InsertBackTable(this.grdOCS1003.LayoutTable.Rows[i]);
                    else
                        this.RemoveBackTable(this.grdOCS1003.LayoutTable.Rows[i]);
                }
            }

            return true;
        }


        private void btnProcess_Click(object sender, System.EventArgs e)
        {
            //this.ParentForm.WindowState = FormWindowState.Minimized;
            //XMessageBox.Show(mIsDrugJusa.ToString());
            if (this.dloSelectOCS1003.RowCount == 0)
            {
                if (XMessageBox.Show(Resources.MSG010_MSG, Resources.MSG009_CAP, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.pbxUnderArrow.Visible = true;
                    timer_icon.Start();
                    return;
                }
            }

            int rowIndex = -1;
            DataTable grdOCS1003Check = grdOCS1003.LayoutTable.Clone();
            grdOCS1003Check.Clear();
            for (rowIndex = 0; rowIndex < grdOCS1003.RowCount; rowIndex++)
            {
                if (grdOCS1003.GetItemString(rowIndex, "select") == "Y")
                {
                    grdOCS1003Check.ImportRow(grdOCS1003.LayoutTable.Rows[rowIndex]);
                }
            }
            //MED-11162
            if (!Utilities.CheckInventory(grdOCS1003Check))
            {
                return;
            }

            CreateReturnLayout((sender as XButton).Tag.ToString());
        }

        
        private void chkIsNewGroup_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkIsNewGroup.Checked)
            {
                chkIsNewGroup.BackColor = System.Drawing.SystemColors.ActiveCaption;
                chkIsNewGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                chkIsNewGroup.ImageIndex = 1;
                mIsNewGroupSer = true;

            }
            else
            {
                chkIsNewGroup.BackColor = System.Drawing.SystemColors.InactiveCaption;
                chkIsNewGroup.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                chkIsNewGroup.ImageIndex = 0;
                mIsNewGroupSer = false;
            }
        }
        
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            //bool isSelect = false;

            this.grdSelectAll(this.grdOCS1003);


        }
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            this.grdDeleteAll(this.grdOCS1003);


        }


        #region [ XTabPage ]

        private void tabGroup_SelectionChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grdOCS1003.RowCount; i++)
            {
                if (this.grdOCS1003.GetItemString(i, "group_ser") == this.tabGroup.SelectedTab.Tag.ToString())
                {
                    this.grdOCS1003.SetRowVisible(i, true);
                }
                else
                {
                    this.grdOCS1003.SetRowVisible(i, false);
                }
            }
        }

        #endregion

        #endregion

        #region [처방단위 CHECK]

        private bool CheckOrd_danui(string hangmog_code, string ord_danui)
        {
            bool chkExists = false;
            string cmdText = string.Empty;
            //object retValu = null;
            //実際項目コードに対してオーダ単位が合っているのか確認
            /*cmdText = "SELECT FN_OCS_EXISTS_ORD_DANUI('" + hangmog_code + "', '" + ord_danui + "') "
                    + "  FROM SYS.DUAL ";
            retValu = Service.ExecuteScalar(cmdText);*/

            // Connect to cloud service 
            OCS1003Q09CheckOrdDanuiArgs args = new OCS1003Q09CheckOrdDanuiArgs();
            args.HangmogCode = hangmog_code;
            args.OrdDanui = ord_danui;
            OCS1003Q09CheckOrdDanuiResult result =
                CloudService.Instance.Submit<OCS1003Q09CheckOrdDanuiResult, OCS1003Q09CheckOrdDanuiArgs>(args);

            if (result.RetValue == "")
                chkExists = false;
            else
                chkExists = true;

            return chkExists;
        }

        #endregion

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
                    // 이미 이미지 세팅이 안된건에 한해서 작업수행
                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
                    {
                        //이미수행한건 빼는로직이 있어야함..
                        int count = 0;
                        for (int j = i; j < aGrd.RowCount; j++)
                        {
                            // 동일 group_ser, 동일 mix_group
                            if (aGrd.GetItemValue(i, "input_gubun").ToString().Trim() == aGrd.GetItemValue(j, "input_gubun").ToString().Trim() &&
                                aGrd.GetItemValue(i, "order_gubun").ToString().Trim() == aGrd.GetItemValue(j, "order_gubun").ToString().Trim() &&
                                aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
                                aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim() &&
                                aGrd.GetItemValue(i, "hope_date").ToString().Trim() == aGrd.GetItemValue(j, "hope_date").ToString().Trim())
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
                        imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
                    }
                }
            }
            finally
            {
                //aGrd.Redraw = true; // Grid Display 
            }

        }
        #endregion

        #region 그리드에서 선택한 Row에 대한 BackColor를 변경한다
        private void SelectionBackColorChange(object grid, int currentRowIndex, string data)
        {
            XEditGrid grdObject = (XEditGrid)grid;

            //선택된 Row에대해서 색을 변경한다
            //data   Y :색을 변경, N :색을 변경 해제
            //image 설정
            if (data == "Y")
            {
                //image 변경
                if (grdObject.RowHeaderVisible)
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
                else
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];
            }
            else
            {
                //image 변경
                if (grdObject.RowHeaderVisible)
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
                else
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];
            }

            //for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
            //{
            //    if (grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
            //    {
            //        // 돈복여부
            //        if (grdObject.GetItemString(currentRowIndex, "donbog_yn") == "Y")
            //        {
            //            grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
            //            continue;
            //        }

            //        // 불균등분할
            //        if (!TypeCheck.IsNull(grdObject.GetItemString(currentRowIndex, "dv_name")))
            //        {
            //            grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
            //            continue;
            //        }
            //    }

            //    if (data == "Y")
            //    {
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;

            //    }
            //    else
            //    {
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
            //        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
            //    }
            //}
            //ntt
            //this.childSetImage();
        }


        private void SelectionBackColorChange(object grid)
        {
            XEditGrid grdObject = (XEditGrid)grid;

            //기존의 색으로 변경을 시킨다
            for (int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                //불용은 넘어간다.
                if (grdObject.CellInfos.Contains("bulyong_check") && grdObject.GetItemString(rowIndex, "bulyong_check") == "Y") continue;

                if (grdObject.GetItemString(rowIndex, "select").ToString() == " ")
                {
                    //image 변경
                    //if (grdObject.RowHeaderVisible)
                    //    grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
                    //else
                    //    grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];

                    //ColorYn Y :색을 변경, N :색을 변경 해제
                    for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                    {
                        if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
                        {
                            // 돈복여부
                            if (grdObject.GetItemString(rowIndex, "donbog_yn") == "Y")
                            {
                                grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
                                continue;
                            }

                            // 불균등분할
                            if (!TypeCheck.IsNull(grdObject.GetItemString(rowIndex, "dv_name")))
                            {
                                grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
                                continue;
                            }
                        }

                        grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
                    }
                }
                else
                {
                    //image 변경
                    //if (grdObject.RowHeaderVisible)
                    //    grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
                    //else
                    //    grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];

                    for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                    {
                        if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
                        {
                            // 돈복여부
                            if (grdObject.GetItemString(rowIndex, "donbog_yn") == "Y")
                            {
                                grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
                                continue;
                            }

                            // 불균등분할
                            if (!TypeCheck.IsNull(grdObject.GetItemString(rowIndex, "dv_name")))
                            {
                                grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
                                continue;
                            }
                        }

                        grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
                    }
                }
            }

            if (grdObject.Name == "grdOCS1003") DiaplayMixGroup(grdObject);

            //ntt
            this.childSetImage();
        }
        #endregion

        #region [외래/입원전환]
        private string IOGubun = "O";
        private void rbtOut_CheckedChanged(object sender, System.EventArgs e)
        {
            //외래
            //select 정보 reset
            //dloSelectOCS1001.Reset();
            //dloSelectOCS1003.Reset();

            //201009 그리드 리셋
            grdOCS1003.Reset();

            //현재선택된 row trans
            //OCS1003
            for (int i = 0; i < grdOCS1003.RowCount; i++)
            {
                if (grdOCS1003.GetItemString(i, "select") == " ")
                    dloSelectOCS1003.LayoutTable.ImportRow(grdOCS1003.LayoutTable.Rows[i]);
            }

            if (rbtOut.Checked)
            {
                //this.cboKijunGubun.Visible = false;
                //this.pnlKijun.Visible = false;
                //입력구분
                //grdOCS1003.AutoSizeColumn(2, 0);

                //당일시행, 당일결과여부
                grdOCS1003.AutoSizeColumn(19, 30);
                grdOCS1003.AutoSizeColumn(20, 30);

                //insert by jc [rbtOut_CheckedChangedイベントを二度乗るのを防ぐ] 2012/03/23
                this.rbtOut.CheckedChanged -= new System.EventHandler(this.rbtOut_CheckedChanged);

                rbtOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
                rbtOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                rbtOut.ImageIndex = 1;

                rbtIn.BackColor = System.Drawing.SystemColors.InactiveCaption;
                rbtIn.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                rbtIn.ImageIndex = 0;

                //grdOUT1001.SetBindVarValue("f_io_gubun", "O");
                IOGubun = "O";

            }
            //입원
            else
            {
                //this.cboKijunGubun.Visible = true;
                //this.pnlKijun.Visible = true;
                //입력구분
                //grdOCS1003.AutoSizeColumn(2, 77);

                //당일시행, 당일결과여부
                grdOCS1003.AutoSizeColumn(19, 30);
                grdOCS1003.AutoSizeColumn(20, 30);

                //insert by jc [rbtOut_CheckedChangedイベントを二度乗るのを防ぐ] 2012/03/23
                this.rbtIn.CheckedChanged -= new System.EventHandler(this.rbtOut_CheckedChanged);

                rbtIn.BackColor = System.Drawing.SystemColors.ActiveCaption;
                rbtIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                rbtIn.ImageIndex = 1;

                rbtOut.BackColor = System.Drawing.SystemColors.InactiveCaption;
                rbtOut.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                rbtOut.ImageIndex = 0;

                //grdOUT1001.SetBindVarValue("f_io_gubun", "I");
                IOGubun = "I";
            }

            grdOUT1001.SetBindVarValue("f_naewon_date", mNaewon_date);

            if (this.pbxSearch.BunHo.ToString() != "")
            {
                if (!grdOUT1001.QueryLayout(false)) 
                    XMessageBox.Show(Service.ErrFullMsg);
            }

            PostCallHelper.PostCall(rbtEventCreate);
        }

        //insert by jc [rbtOut_CheckedChangedイベントを二度乗るのを防ぐ] 2012/03/23
        public void rbtEventCreate()
        {
            if(this.rbtOut.Checked)
                this.rbtOut.CheckedChanged += new System.EventHandler(this.rbtOut_CheckedChanged);
            else    
                this.rbtIn.CheckedChanged += new System.EventHandler(this.rbtOut_CheckedChanged);
        }

        #endregion

        #region 検体検査結果照会　검체검사 결과조회

        private void btnCplResult_Click(object sender, System.EventArgs e)
        {
            if (this.pbxSearch.BunHo.ToString() != "")
            {
                //modify by jc
                this.OpenScreen_CPL0000Q01(this.pbxSearch.BunHo.ToString());
                //this.OpenScreen_CPL0000Q00(this.pbxSearch.BunHo.ToString());
            }
            //// 처방 입력 가능 여부
            //////if (!this.IsOrderInputCheck(true)) return;

            //// 검체검사결과조회 화면 Open
            //CommonItemCollection openParams  = new CommonItemCollection();
            //if(!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
            //    openParams.Add("bunho", this.pbxSearch.BunHo.ToString());
            //XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q00", ScreenOpenStyle.ResponseSizable, openParams);

        }
        #endregion

        #region 放射線検査結果照会　방사선검사 결과조회
        private void btnXRTResult_Click(object sender, System.EventArgs e)
        {
            if (this.pbxSearch.BunHo.ToString() != "")
            {
                this.OpenScreen_XRT0000Q00(this.pbxSearch.BunHo.ToString());
            }

            //// 방사선검사결과조회 화면 Open
            //CommonItemCollection openParams  = new CommonItemCollection();
            //if(!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
            //    openParams.Add("bunho", this.pbxSearch.BunHo.ToString());
            //XScreen.OpenScreenWithParam(this, "XRTS", "XRT0000Q00", ScreenOpenStyle.PopUpSizable, openParams);

        }
        #endregion

        #region 整理検査結果照会　생리검사 결과조회
        private void btnPFEResult_Click(object sender, System.EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.pbxSearch.BunHo.ToString() != "")
            {
                this.mMenuPFEResult.TrackPopup(this.PointToScreen(new Point(button.Location.X, button.Location.Y + (pbxSearch.Height + xPanel3.Height + xPanel4.Height))));
            }

            //// 각종검사결과조회 화면 Open
            //CommonItemCollection openParams  = new CommonItemCollection();
            //if(!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
            //    openParams.Add("bunho", this.pbxSearch.BunHo.ToString());
            //XScreen.OpenScreenWithParam(this, "PFES", "PFE0000Q00", ScreenOpenStyle.PopUpSizable, openParams);
        }
        #endregion

        #region スキャン結果照会
        private void btnAPLResult_Click(object sender, System.EventArgs e)
        {
            if (this.pbxSearch.BunHo.ToString() != "")
            {
                this.OpenScreen_ScanViewer(this.pbxSearch.BunHo.ToString());
            }

            //// 처방 입력 가능 여부
            //////if (!this.IsOrderInputCheck(true)) return;

            //// 각종검사결과조회 화면 Open
            //CommonItemCollection openParams  = new CommonItemCollection();
            //if(!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
            //    openParams.Add("bunho", this.pbxSearch.BunHo.ToString());
            //XScreen.OpenScreenWithParam(this, "APLS", "APL0000Q00", ScreenOpenStyle.PopUpSizable, openParams);
        }
        #endregion

        #region 주사메세지조회
        private void btnINJResult_Click(object sender, System.EventArgs e)
        {
            if (this.pbxSearch.BunHo.ToString() != "")
            {
                this.OpenScreen_INJ0000Q00(this.pbxSearch.BunHo.ToString());
            }

            //// 처방 입력 가능 여부
            //////if (!this.IsOrderInputCheck(true)) return;

            //// 각종검사결과조회 화면 Open
            //CommonItemCollection openParams  = new CommonItemCollection();
            //if(!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
            //    openParams.Add("bunho", this.pbxSearch.BunHo.ToString());
            //XScreen.OpenScreenWithParam(this, "INJS", "INJ0000Q00", ScreenOpenStyle.PopUpSizable, openParams);
        }
        #endregion

        #region unused code
//        #region Order_gubun Tab 변경
//        /// <summary>
//        /// tab 변경시 해당 처방조회
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void tabOrderGubun1_SelectionChanged(object sender, System.EventArgs e)
//        {
//            //if (tabOrderGubun.SelectedTab == null) return;

//            //현재선택된 row trans
//            //OCS1003
//            for (int i = 0; i < grdOCS1003.RowCount; i++)
//            {
//                if (grdOCS1003.GetItemString(i, "select") == " ")
//                    dloSelectOCS1003.LayoutTable.ImportRow(grdOCS1003.LayoutTable.Rows[i]);
//            }



//            foreach (XGridCell cell in grdOCS1003.CellInfos)
//            {
//                if (cell.IsVisible)
//                {
//                    if (mInput_tab == "%" || this.mInputControl.IsVisibleColumn(mInput_tab, cell.CellName))
//                    {
//                        grdOCS1003.AutoSizeColumn(cell.Col, cell.CellWidth);
//                    }
//                    else
//                    {
//                        if (cell.CellName == "child_gubun")
//                            grdOCS1003.AutoSizeColumn(cell.Col, cell.CellWidth);
//                        else
//                            grdOCS1003.AutoSizeColumn(cell.Col, 0);
//                    }
//                }
//            }

//            //검사인 경우에는 실시일 기준으로 조회한다.
//            //検査の場合は実施日基準で照会する。
//            //if (tabOrderGubun.SelectedTab.Tag.ToString() == "4" || tabOrderGubun.SelectedTab.Tag.ToString() == "5")
//            if(mInput_tab.Equals("04") || mInput_tab.Equals("05") || mInput_tab.Equals("06"))
//            {
//                grdOUT1001[0, grdOUT1001.CellInfos["naewon_date"].Col].Value = NetInfo.Language == LangMode.Jr ? "日付" : "일자";
//                this.grdOUT1001.AutoSizeColumn(6, 0);
//                this.grdOUT1001.AutoSizeColumn(7, 0);
//                this.grdOCS1003.AutoSizeColumn(3, 80);

//                #region [[  grdOUT1001 & grdOCS1001 QuerySQL Setting  ]]
//                this.grdOUT1001.QuerySQL = @"SELECT DISTINCT    -- 4
//                                                   NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) NAEWON_DATE,
//                                                   A.GWA                             GWA,
//                                                   FN_BAS_LOAD_GWA_NAME( A.GWA, A.ORDER_DATE)
//                                                                                     GWA_NAME,
//                                                   FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE) DOCTOR_NAME,
//                                                   0                                 NALSU,
//                                                   A.BUNHO                           BUNHO,
//                                                   A.DOCTOR                          DOCTOR,
//                                                   ''                                GUBUN_NAME ,
//                                                   ''                                CHOJAE_NAME,
//                                                   '0'                               NAEWON_TYPE,
//                                                   0                                 JUBSU_NO   ,
//                                                   A.BUNHO||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))),'YYYYMMDD')||A.GWA||A.DOCTOR
//                                                                                     PK_ORDER,
//                                                   TRIM(RPAD(:f_input_gubun,10))     INPUT_GUBUN,
//                                                   :f_tel_yn                         TEL_YN,
//                                                   'N'                               TOIWON_DRG,
//                                                   :f_input_tab                      INPUT_TAB,
//                                                   :f_io_gubun                       IO_GUBUN
//                                              FROM OCS1003 A
//                                             WHERE :f_io_gubun    = 'O'
//                                               AND A.HOSP_CODE    = :f_hosp_code
//                                               AND A.BUNHO        = :f_bunho
//                                               AND A.ORDER_DATE   < :f_naewon_date
//                                               AND A.GWA          LIKE :f_gwa
//                                               AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
//                                                    ( :f_input_gubun = 'NR'           ) OR
//                                                    ( :f_input_gubun = 'D%'           ))
//                                               AND NVL(A.TEL_YN     , 'N') LIKE :f_tel_yn
//                                               AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
//                                               AND NVL(A.DC_YN,'N')        = 'N'
//                                               AND A.NALSU                 >= 0
//                                            --   AND A.INPUT_TAB            = :f_input_tab
//                                            --   AND (( :f_input_tab = '4' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'       ) OR
//                                            --        ( :f_input_tab = '5' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'       ))
//                                                       
//                                            UNION ALL
//                                            SELECT DISTINCT
//                                                   NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)))
//                                                                                     NAEWON_DATE,
//                                                   A.INPUT_GWA                       GWA        ,
//                                                   FN_BAS_LOAD_GWA_NAME( A.INPUT_GWA, A.ORDER_DATE)
//                                                                                     GWA_NAME,
//                                                   FN_BAS_LOAD_DOCTOR_NAME(A.INPUT_DOCTOR, A.ORDER_DATE)
//                                                                                     DOCTOR_NAME,
//                                                   0                                 NALSU,
//                                                   A.BUNHO                           BUNHO      ,
//                                                   A.INPUT_DOCTOR                    DOCTOR     ,
//                                                   ' '                               GUBUN_NAME ,
//                                                   ' '                               CHOJAE_NAME,
//                                                   '0'                               NAEWON_TYPE,
//                                                   A.FKINP1001                       JUBSU_NO   ,
//                                                   A.BUNHO||RTRIM(TO_CHAR(A.FKINP1001))||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))),'YYYYMMDD')||RPAD(A.INPUT_GWA, 10)||RPAD(A.INPUT_DOCTOR, 10)
//                                                                                     PK_ORDER   ,
//                                                   TRIM(RPAD(:f_input_gubun,10))     INPUT_GUBUN,
//                                                   :f_tel_yn                         TEL_YN,
//                                                   'N'                               TOIWON_DRG,
//                                                   :f_input_tab                      INPUT_TAB,
//                                                   :f_io_gubun                       IO_GUBUN
//                                              FROM OCS2003 A
//                                             WHERE :f_io_gubun    = 'I'
//                                               AND A.HOSP_CODE    = :f_hosp_code        
//                                               AND A.BUNHO        = :f_bunho
//                                               AND A.ORDER_DATE  <= :f_naewon_date
//                                               AND A.INPUT_GWA    LIKE :f_gwa
//                                               AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
//                                                    ( :f_input_gubun = 'NR'           ) OR
//                                                    ( :f_input_gubun = 'D%'           ))
//                                               AND A.IO_GUBUN             IS NULL
//                                               AND A.NALSU               >= 0
//                                               AND NVL(A.DISPLAY_YN,'Y')  = 'Y'
//                                               AND NVL(A.DC_YN,'N')       = 'N'
//                                            --   AND A.INPUT_TAB            = :f_input_tab
//                                            --   AND (( :f_input_tab = '4' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'       ) OR
//                                            --        ( :f_input_tab = '5' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'       ))
//                                               AND A.FKINP1001            = ( SELECT MAX(C.PKINP1001)
//                                                                                FROM VW_OCS_INP1001_02 C
//                                                                               WHERE C.BUNHO       = :f_bunho
//                                                                                 AND C.IPWON_DATE <= :f_naewon_date
//                                                                                 AND C.HOSP_CODE   = :f_hosp_code   )
//                                             ORDER BY 12 DESC";

//                this.grdOCS1003.QuerySQL =    @"SELECT F.CODE_NAME                                                INPUT_GUBUN_NAME        ,
//                                                       A.GROUP_SER                                                GROUP_SER               ,
//                                                       NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,
//                                                       A.HANGMOG_CODE                                             HANGMOG_CODE            ,
//                                                       ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
//                                                              THEN NVL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE), '')||B.HANGMOG_NAME
//                                                              ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,
//                                                       A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,
//                                                       D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,
//                                                       A.SURYANG                                                  SURYANG                 ,
//                                                       A.ORD_DANUI                                                ORD_DANUI               ,
//                                                       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,
//                                                       A.DV_TIME                                                  DV_TIME                 ,
//                                                       A.DV                                                       DV                      ,
//                                                       A.NALSU                                                    NALSU                   ,
//                                                       A.JUSA                                                     JUSA                    ,
//                                                       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,
//                                                       A.BOGYONG_CODE                                             BOGYONG_CODE            ,
//                                                       FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
//                                                                                                                  BOGYONG_NAME            ,
//                                                       A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,
//                                                       A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,
//                                                       A.PHARMACY                                                 PHARMACY                ,
//                                                       A.DRG_PACK_YN                                              DRG_PACK_YN             ,
//                                                       A.POWDER_YN                                                POWDER_YN               ,
//                                                       A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,
//                                                       NVL(A.DANGIL_GUMSA_ORDER_YN , 'N')                         DANGIL_GUMSA_ORDER_YN   ,
//                                                       NVL(A.DANGIL_GUMSA_RESULT_YN, 'N')                         DANGIL_GUMSA_RESULT_YN  ,
//                                                       NVL(A.EMERGENCY             , 'N')                         EMERGENCY               ,
//                                                       A.PAY                                                      PAY                     ,
//                                                       A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,
//                                                       A.MUHYO                                                    MUHYO                   ,
//                                                       A.PORTABLE_YN                                              PORTABLE_YN             ,
//                                                       A.OCS_FLAG                                                 OCS_FLAG                ,
//                                                       A.ORDER_GUBUN                                              ORDER_GUBUN             ,
//                                                       A.INPUT_TAB                                                INPUT_TAB               ,
//                                                       A.INPUT_GUBUN                                              INPUT_GUBUN             ,
//                                                       A.AFTER_ACT_YN                                             AFTER_ACT_YN            ,
//                                                       A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,
//                                                       A.JUNDAL_PART                                              JUNDAL_PART             ,
//                                                       A.MOVE_PART                                                MOVE_PART               ,
//                                                       A.BUNHO                                                    BUNHO                   ,
//                                                       A.ORDER_DATE                                               NAEWON_DATE             ,
//                                                       A.GWA                                                      GWA                     ,
//                                                       A.DOCTOR                                                   DOCTOR                  ,
//                                                       A.NAEWON_TYPE                                              NAEWON_TYPE             ,
//                                                       A.FKOUT1001                                                PK_ORDER                ,
//                                                       A.SEQ                                                      SEQ                     ,
//                                                       A.PKOCS1003                                                PKOCS1003               ,
//                                                       A.SUB_SUSUL                                                SUB_SUSUL               ,
//                                                       A.SUTAK_YN                                                 SUTAK_YN                ,
//                                                       A.AMT                                                      AMT                     ,
//                                                       A.DV_1                                                     DV_1                    ,
//                                                       A.DV_2                                                     DV_2                    ,
//                                                       A.DV_3                                                     DV_3                    ,
//                                                       A.DV_4                                                     DV_4                    ,
//                                                       A.HOPE_DATE                                                HOPE_DATE               ,
//                                                       A.ORDER_REMARK                                             ORDER_REMARK            ,
//                                                       A.MIX_GROUP                                                MIX_GROUP               ,
//                                                       A.HOME_CARE_YN                                             HOME_CARE_YN            ,
//                                                       NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,
//                                                       A.GONGBI_CODE                                              GONGBI_CODE             ,
//                                                       FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, A.ORDER_DATE)       GONGBI_NAME             ,
//                                                       DECODE( B.ORDER_GUBUN, 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE), 'N' )
//                                                                                                                  DONBOK_YN               ,
//                                                       FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4, A.DV_5, A.DV_6, A.DV_7, A.DV_8)
//                                                                                                                  DV_NAME                 ,
//                                                       B.SLIP_CODE                                                SLIP_CODE               ,
//                                                       B.GROUP_YN                                                 GROUP_YN                ,
//                                                       B.SG_CODE                                                  SG_CODE                 ,
//                                                       B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,
//                                                       B.INPUT_CONTROL                                            INPUT_CONTROL           ,
//                                                       NVL(B.SUGA_YN,'N')                                         SUGA_YN                 ,
//                                                       DECODE(NVL(B.EMERGENCY,'Z'),'Y','N','N','N','Y')           EMERGENCY_CHECK         ,
//                                                       B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,
//                                                       NVL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,
//                                                       NVL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,
//                                                       DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,
//                                                       B.ORD_DANUI                                                ORD_DANUI_BAS           ,
//                                                       A.JUNDAL_TABLE                                             JUNDAL_TABLE_OUT        ,
//                                                       A.JUNDAL_PART                                              JUNDAL_PART_OUT         ,
//                                                       ( CASE WHEN FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE) <> 'Y'
//                                                              THEN 'N'
//                                                              WHEN FN_OCS_BULYONG_CHECK_OUT   (B.HANGMOG_CODE, SYSDATE) = 'Y'
//                                                               AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', A.HANGMOG_CODE, A.BUNHO, TRUNC(SYSDATE)) <> A.HANGMOG_CODE
//                                                              THEN 'Z'
//                                                              ELSE 'Y' END )                                      BULYONG_CHECK           ,
//                                                       FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE)                   WONYOI_ORDER_CR_YN      ,
//                                                       B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,
//                                                       NVL(B.NDAY_YN,'N')                                         NDAY_YN                 ,
//                                                       NVL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,
//                                                       A.TEL_YN                                                   TEL_YN                  ,
//                                                       E.BUN_CODE                                                 BUN_CODE                ,
//                                                       E.SG_GESAN                                                 SG_GESAN                ,
//                                                       FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE)                        DRG_INFO                ,
//                                                       ''                                                         DRG_BUNRYU              ,
//                                                       DECODE(A.BOM_SOURCE_KEY,NULL,FN_OCS_LOAD_CHILD_GUBUN('O',A.PKOCS1003),'3')      CHILD_GUBUN,
//                                                       A.BOM_SOURCE_KEY                                          BOM_SOURCE_KEY,
//                                                       A.BOM_OCCUR_YN                                            BOM_OCCUR_YN,      
//                                                       A.PKOCS1003                                               PARENTS_KEY,
//                                                       A.BOM_SOURCE_KEY                                          CHILD_KEY,
//                                                       LTRIM(TO_CHAR(NVL(F.SORT_KEY, 99), '00'))||NVL(A.TEL_YN, 'N')||LTRIM(TO_CHAR(NVL(C.SORT_KEY, 99), '00'))||
//                                                       ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B')
//                                                               AND A.HOPE_DATE IS NOT NULL
//                                                              THEN TO_CHAR(A.HOPE_DATE, 'YYYYMMDD')
//                                                              ELSE '00000000' END )||
//                                                       LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||LTRIM(TO_CHAR(A.SEQ, '0000'))
//                                                                                                                    CONT_KEY
//                                                  FROM OCS0140 G,
//                                                       OCS0132 F,
//                                                       BAS0310 E,
//                                                       OCS0116 D,
//                                                       OCS0132 C,
//                                                       OCS0103 B,
//                                                       OCS1003 A
//                                                 WHERE A.HOSP_CODE        = '" + EnvironInfo.HospCode + @"'
//                                                   AND A.BUNHO            = :f_bunho
//                                                   AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) = :f_naewon_date
//                                                   AND A.GWA              = :f_gwa
//                                                   AND A.DOCTOR           = :f_doctor
//                                                   --各部門関係なく照会できるようにするためinput_tabの制限をなくす。
//                                                   --AND A.INPUT_TAB        = :f_input_tab
//                                                   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
//                                                        ( :f_input_gubun = 'NR'           ) OR
//                                                        ( :f_input_gubun = 'D%'           ))
//                                                   AND NVL(A.TEL_YN     , 'N') LIKE :f_tel_yn
//                                                   AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
//                                                   AND NVL(A.DC_YN,'N')   = 'N'
//                                                   AND A.NALSU           >= 0
//                                                   AND B.HOSP_CODE        = A.HOSP_CODE
//                                                   AND B.HANGMOG_CODE     = A.HANGMOG_CODE
//                                                   AND C.HOSP_CODE    (+) = A.HOSP_CODE
//                                                   AND C.CODE         (+) = A.ORDER_GUBUN
//                                                   AND C.CODE_TYPE    (+) = 'ORDER_GUBUN'
//                                                   AND D.HOSP_CODE    (+) = A.HOSP_CODE
//                                                   AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
//                                                   AND E.HOSP_CODE    (+) = B.HOSP_CODE
//                                                   AND E.SG_CODE      (+) = B.SG_CODE
//                                                   AND F.HOSP_CODE    (+) = A.HOSP_CODE
//                                                   AND F.CODE         (+) = A.INPUT_GUBUN
//                                                   AND F.CODE_TYPE    (+) = 'INPUT_GUBUN'
//                                                   AND G.HOSP_CODE        = A.HOSP_CODE
//                                                   AND G.ORDER_GUBUN      = A.ORDER_GUBUN
//                                                   AND G.INPUT_TAB        = A.INPUT_TAB
//                                                --   AND (( :f_input_tab = '%'           ) OR
//                                                --        ( :f_input_tab = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'       ) OR
//                                                --        ( :f_input_tab = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'       ) OR
//                                                --        ( :f_input_tab = '3' AND G.INPUT_TAB                 = '02'      ) OR
//                                                --        ( :f_input_tab = '4' AND G.INPUT_TAB                 = '03'      ) OR
//                                                --        ( :f_input_tab = '5' AND G.INPUT_TAB                 = '04'      ) OR
//                                                --        ( :f_input_tab = '6' AND G.INPUT_TAB                 = '05'      ) OR
//                                                --        ( :f_input_tab = '7' AND G.INPUT_TAB                 = '06'      ) OR
//                                                --        ( :f_input_tab = '8' AND G.INPUT_TAB                 = '07'      ) OR
//                                                --        ( :f_input_tab = '9' AND G.INPUT_TAB                 = '08'      ) )
//                                                UNION ALL
//                                                SELECT F.CODE_NAME                                                INPUT_GUBUN_NAME        ,
//                                                       A.GROUP_SER                                                GROUP_SER               ,
//                                                       NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,
//                                                       A.HANGMOG_CODE                                             HANGMOG_CODE            ,
//                                                       ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
//                                                              THEN NVL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE), '')||B.HANGMOG_NAME
//                                                              ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,
//                                                       A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,
//                                                       D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,
//                                                       A.SURYANG                                                  SURYANG                 ,
//                                                       A.ORD_DANUI                                                ORD_DANUI               ,
//                                                       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,
//                                                       A.DV_TIME                                                  DV_TIME                 ,
//                                                       A.DV                                                       DV                      ,
//                                                       A.NALSU                                                    NALSU                   ,
//                                                       A.JUSA                                                     JUSA                    ,
//                                                       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,
//                                                       A.BOGYONG_CODE                                             BOGYONG_CODE            ,
//                                                       FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
//                                                                                                                  BOGYONG_NAME            ,
//                                                       A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,
//                                                       A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,
//                                                       A.PHARMACY                                                 PHARMACY                ,
//                                                       A.DRG_PACK_YN                                              DRG_PACK_YN             ,
//                                                       A.POWDER_YN                                                POWDER_YN               ,
//                                                       A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,
//                                                       'N'                                                        DANGIL_GUMSA_ORDER_YN   ,
//                                                       'N'                                                        DANGIL_GUMSA_RESULT_YN  ,
//                                                       NVL(A.EMERGENCY  , 'N')                                    EMERGENCY               ,
//                                                       A.PAY                                                      PAY                     ,
//                                                       A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,
//                                                       A.MUHYO                                                    MUHYO                   ,
//                                                       A.PORTABLE_YN                                              PORTABLE_YN             ,
//                                                       A.OCS_FLAG                                                 OCS_FLAG                ,
//                                                       A.ORDER_GUBUN                                              ORDER_GUBUN             ,
//                                                       A.INPUT_TAB                                                INPUT_TAB               ,
//                                                       A.INPUT_GUBUN                                              INPUT_GUBUN             ,
//                                                       'N'                                                        AFTER_ACT_YN            ,
//                                                       A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,
//                                                       A.JUNDAL_PART                                              JUNDAL_PART             ,
//                                                       NULL                                                       MOVE_PART               ,
//                                                       A.BUNHO                                                    BUNHO                   ,
//                                                       A.ORDER_DATE                                               NAEWON_DATE             ,
//                                                       A.INPUT_PART                                               GWA                     ,
//                                                       A.INPUT_ID                                                 DOCTOR                  ,
//                                                       '0'                                                        NAEWON_TYPE             ,
//                                                       A.FKINP1001                                                PK_ORDER                ,
//                                                       A.SEQ                                                      SEQ                     ,
//                                                       A.PKOCS2003                                                PKOCS1003               ,
//                                                       A.SUB_SUSUL                                                SUB_SUSUL               ,
//                                                       NULL                                                       SUTAK_YN                ,
//                                                       A.AMT                                                      AMT                     ,
//                                                       A.DV_1                                                     DV_1                    ,
//                                                       A.DV_2                                                     DV_2                    ,
//                                                       A.DV_3                                                     DV_3                    ,
//                                                       A.DV_4                                                     DV_4                    ,
//                                                       A.HOPE_DATE                                                HOPE_DATE               ,
//                                                       A.ORDER_REMARK                                             ORDER_REMARK            ,
//                                                       A.MIX_GROUP                                                MIX_GROUP               ,
//                                                       'N'                                                        HOME_CARE_YN            ,
//                                                       NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,
//                                                       A.GONGBI_CODE                                              GONGBI_CODE             ,
//                                                       FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, A.ORDER_DATE)       GONGBI_NAME             ,
//                                                       DECODE( B.ORDER_GUBUN, 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE), 'N' )
//                                                                                                                  DONBOK_YN               ,
//                                                       FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4, A.DV_5, A.DV_6, A.DV_7, A.DV_8)
//                                                                                                                  DV_NAME                 ,
//                                                       B.SLIP_CODE                                                SLIP_CODE               ,
//                                                       B.GROUP_YN                                                 GROUP_YN                ,
//                                                       B.SG_CODE                                                  SG_CODE                 ,
//                                                       B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,
//                                                       B.INPUT_CONTROL                                            INPUT_CONTROL           ,
//                                                       NVL(B.SUGA_YN,'N')                                         SUGA_YN                 ,
//                                                       DECODE(NVL(B.EMERGENCY,'Z'),'Y','N','N','N','Y')           EMERGENCY_CHECK         ,
//                                                       B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,
//                                                       NVL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,
//                                                       NVL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,
//                                                       DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,
//                                                       B.ORD_DANUI                                                ORD_DANUI_BAS           ,
//                                                       A.JUNDAL_TABLE                                             JUNDAL_TABLE_OUT        ,
//                                                       A.JUNDAL_PART                                              JUNDAL_PART_OUT         ,
//                                                       FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE)          BULYONG_CHECK           ,
//                                                       FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE)                   WONYOI_ORDER_CR_YN      ,
//                                                       B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,
//                                                       NVL(B.NDAY_YN,'N')                                         NDAY_YN                 ,
//                                                       NVL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,
//                                                       A.TEL_YN                                                   TEL_YN                  ,
//                                                       E.BUN_CODE                                                 BUN_CODE                ,
//                                                       E.SG_GESAN                                                 SG_GESAN                ,
//                                                       FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE)                        DRG_INFO                ,
//                                                       ''                                                         DRG_BUNRYU              ,
//                                                       DECODE(A.BOM_SOURCE_KEY,NULL,FN_OCS_LOAD_CHILD_GUBUN('I',A.PKOCS2003),'3')      CHILD_GUBUN,
//                                                       A.BOM_SOURCE_KEY                                          BOM_SOURCE_KEY,
//                                                       A.BOM_OCCUR_YN                                            BOM_OCCUR_YN,
//                                                       A.PKOCS2003                                               PARENTS_KEY,
//                                                       A.BOM_SOURCE_KEY                                          CHILD_KEY,
//                                                       LTRIM(TO_CHAR(NVL(F.SORT_KEY, 99), '00'))||NVL(A.TEL_YN, 'N')||LTRIM(TO_CHAR(NVL(C.SORT_KEY, 99), '00'))||LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||LTRIM(TO_CHAR(A.SEQ, '0000'))
//                                                                                                                        CONT_KEY
//                                                  FROM OCS0140 G,
//                                                       OCS0132 F,
//                                                       BAS0310 E,
//                                                       OCS0116 D,
//                                                       OCS0132 C,
//                                                       OCS0103 B,
//                                                       OCS2003 A
//                                                 WHERE A.HOSP_CODE        = '" + EnvironInfo.HospCode + @"'
//                                                   AND A.BUNHO            = :f_bunho
//                                                   AND A.FKINP1001        = :f_jubsu_no
//                                                   AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) = :f_naewon_date
//                                                   AND A.INPUT_GWA        = :f_gwa
//                                                   AND A.INPUT_DOCTOR     = :f_doctor
//                                                  --各部門関係なく照会できるようにするためinput_tabの制限をなくす。
//                                                  -- AND A.INPUT_TAB        = :f_input_tab
//                                                   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
//                                                        ( :f_input_gubun = 'NR'           ) OR
//                                                        ( :f_input_gubun = 'D%'           ))
//                                                   AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
//                                                   AND NVL(A.DC_YN,'N')   = 'N'
//                                                   AND A.NALSU           >= 0
//                                                   AND B.HOSP_CODE        = A.HOSP_CODE
//                                                   AND B.HANGMOG_CODE     = A.HANGMOG_CODE
//                                                   AND C.HOSP_CODE    (+) = A.HOSP_CODE    
//                                                   AND C.CODE         (+) = A.ORDER_GUBUN
//                                                   AND C.CODE_TYPE    (+) = 'ORDER_GUBUN'
//                                                   AND F.HOSP_CODE    (+) = A.HOSP_CODE
//                                                   AND F.CODE         (+) = A.INPUT_GUBUN
//                                                   AND F.CODE_TYPE    (+) = 'INPUT_GUBUN'
//                                                   AND D.HOSP_CODE    (+) = A.HOSP_CODE
//                                                   AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
//                                                   AND E.HOSP_CODE    (+) = B.HOSP_CODE
//                                                   AND E.SG_CODE      (+) = B.SG_CODE
//                                                   AND G.HOSP_CODE        = A.HOSP_CODE
//                                                   AND G.ORDER_GUBUN      = A.ORDER_GUBUN
//                                                   AND G.INPUT_TAB        = A.INPUT_TAB
//                                                --   AND (( :f_input_tab = '%'           ) OR
//                                                --        ( :f_input_tab = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'       ) OR
//                                                --        ( :f_input_tab = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'       ) OR
//                                                --        ( :f_input_tab = '3' AND G.INPUT_TAB                 = '02'      ) OR
//                                                --        ( :f_input_tab = '4' AND G.INPUT_TAB                 = '03'      ) OR
//                                                --        ( :f_input_tab = '5' AND G.INPUT_TAB                 = '04'      ) OR
//                                                --        ( :f_input_tab = '6' AND G.INPUT_TAB                 = '05'      ) OR
//                                                --        ( :f_input_tab = '7' AND G.INPUT_TAB                 = '06'      ) OR
//                                                --        ( :f_input_tab = '8' AND G.INPUT_TAB                 = '07'      ) OR
//                                                --        ( :f_input_tab = '9' AND G.INPUT_TAB                 = '08'      ) )
//                                                 ORDER BY 92";
//                #endregion
//                //this.dsvLDOUT1001.WorkTp = '4';
//                //this.dsvLDOCS1003.WorkTp = '5';
//                //this.pnlSang.Visible = false;
//            }
//            else
//            {
//                grdOUT1001[0, grdOUT1001.CellInfos["naewon_date"].Col].Value = NetInfo.Language == LangMode.Jr ? "オ―ダ日付" : "Order일자";
//                this.grdOUT1001.AutoSizeColumn(6, 80);
//                this.grdOUT1001.AutoSizeColumn(7, 80);
//                this.grdOCS1003.AutoSizeColumn(3, 0);

//                #region [[  grdOUT1001 & grdOCS1001 QuerySQL Setting  ]]
//                this.grdOUT1001.QuerySQL =   @" SELECT A.NAEWON_DATE                     NAEWON_DATE,      -- 1
//                                                       A.GWA                             GWA,
//                                                       FN_BAS_LOAD_GWA_NAME( A.GWA, A.NAEWON_DATE)
//                                                                                         GWA_NAME,
//                                                       FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE)
//                                                                                         DOCTOR_NAME,
//                                                       0                                 NALSU,
//                                                       A.BUNHO                           BUNHO,
//                                                       A.DOCTOR                          DOCTOR,
//                                                       FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, A.NAEWON_DATE)
//                                                                                         GUBUN_NAME ,
//                                                       FN_BAS_LOAD_CODE_NAME ('CHOJAE', A.CHOJAE)
//                                                                                         CHOJAE_NAME,
//                                                       A.NAEWON_TYPE                     NAEWON_TYPE,
//                                                       A.JUBSU_NO                        JUBSU_NO   ,
//                                                       A.PKOUT1001                       PK_ORDER,
//                                                       TRIM(RPAD(:f_input_gubun,10))     INPUT_GUBUN,
//                                                       :f_tel_yn                         TEL_YN,
//                                                       'N'                               TOIWON_DRG,
//                                                       :f_input_tab                      INPUT_TAB,
//                                                       :f_io_gubun                       IO_GUBUN
//                                                  FROM OUT1001 A
//                                                 WHERE :f_io_gubun    = 'O'
//                                                   AND A.HOSP_CODE    = :f_hosp_code                                                   
//                                                   AND A.BUNHO        = :f_bunho
//                                                   AND A.NAEWON_DATE <= :f_naewon_date
//                                                   AND A.GWA         LIKE :f_gwa
//                                                   AND EXISTS( SELECT 'X'
//                                                                 FROM OCS0140 C,
//                                                                      OCS1003 B
//                                                                WHERE B.HOSP_CODE    = A.HOSP_CODE
//                                                                  AND B.BUNHO        = A.BUNHO
//                                                                  AND B.ORDER_DATE   = A.NAEWON_DATE
//                                                                  AND B.GWA          = A.GWA
//                                                                  AND B.DOCTOR       = A.DOCTOR
//                                                                  AND B.NAEWON_TYPE  = A.NAEWON_TYPE
//                                                                  AND NVL(B.TEL_YN     , 'N') LIKE :f_tel_yn
//                                                                  AND NVL(B.DISPLAY_YN , 'Y') = 'Y'
//                                                                  AND NVL(B.DC_YN,'N')   = 'N'
//                                                                  AND B.NALSU           >= 0
//                                                                  AND (( B.INPUT_GUBUN  = :f_input_gubun ) OR
//                                                                       ( :f_input_gubun = 'NR'           ) OR
//                                                                       ( :f_input_gubun = 'D%'           ))
//                                                                  AND B.INPUT_TAB       = :f_input_tab
//                                                                  AND C.HOSP_CODE       = B.HOSP_CODE                                                                  
//                                                                  AND C.ORDER_GUBUN     = B.ORDER_GUBUN
//                                                                  AND C.INPUT_TAB       = B.INPUT_TAB
//                                                --                  AND (( :f_input_tab = '%'           ) OR
//                                                --                       ( :f_input_tab = '1' AND SUBSTR(B.ORDER_GUBUN, 2, 1) = 'C'       ) OR
//                                                --                       ( :f_input_tab = '2' AND SUBSTR(B.ORDER_GUBUN, 2, 1) = 'D'       ) OR
//                                                --                       ( :f_input_tab = '3' AND C.INPUT_TAB                 = '02'      ) OR
//                                                --                       ( :f_input_tab = '4' AND C.INPUT_TAB                 = '03'      ) OR
//                                                --                       ( :f_input_tab = '5' AND C.INPUT_TAB                 = '04'      ) OR
//                                                --                       ( :f_input_tab = '6' AND C.INPUT_TAB                 = '05'      ) OR
//                                                --                       ( :f_input_tab = '7' AND C.INPUT_TAB                 = '06'      ) OR
//                                                --                       ( :f_input_tab = '8' AND C.INPUT_TAB                 = '07'      ) OR
//                                                --                       ( :f_input_tab = '9' AND C.INPUT_TAB                 = '08'      ) )
//                                                                  AND ROWNUM = 1 )
//                                                UNION ALL
//                                                SELECT DISTINCT
//                                                       A.ORDER_DATE                      NAEWON_DATE,
//                                                       A.INPUT_GWA                       GWA        ,
//                                                       FN_BAS_LOAD_GWA_NAME( A.INPUT_GWA, A.ORDER_DATE)
//                                                                                         GWA_NAME,
//                                                       FN_BAS_LOAD_DOCTOR_NAME(A.INPUT_DOCTOR, A.ORDER_DATE)
//                                                                                         DOCTOR_NAME,
//                                                       0                                 NALSU,
//                                                       A.BUNHO                           BUNHO      ,
//                                                       A.INPUT_DOCTOR                    DOCTOR     ,
//                                                       ' '                               GUBUN_NAME ,
//                                                       ' '                               CHOJAE_NAME,
//                                                       '0'                               NAEWON_TYPE,
//                                                       A.FKINP1001                       JUBSU_NO   ,
//                                                       A.FKINP1001                       PK_ORDER   ,
//                                                       TRIM(RPAD(:f_input_gubun,10))     INPUT_GUBUN,
//                                                       :f_tel_yn                         TEL_YN     ,
//                                                       FN_OCS_EXISTS_TOIWON_DRG(A.BUNHO, A.FKINP1001, A.ORDER_DATE)
//                                                                                                 TOIWON_DRG,
//                                                       :f_input_tab                      INPUT_TAB,
//                                                       :f_io_gubun                       IO_GUBUN
//                                                  FROM OCS0140  B,
//                                                       OCS2003  A
//                                                 WHERE :f_io_gubun       = 'I'
//                                                   AND A.HOSP_CODE       = :f_hosp_code                                                   
//                                                   AND A.BUNHO           = :f_bunho
//                                                   AND A.ORDER_DATE     <= :f_naewon_date
//                                                   AND A.INPUT_GWA       LIKE :f_gwa
//                                                   AND A.IO_GUBUN        IS NULL
//                                                   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
//                                                        ( :f_input_gubun = 'NR'           ) OR
//                                                        ( :f_input_gubun = 'D%'           ))
//                                                   AND A.NALSU               >= 0
//                                                   AND NVL(A.DISPLAY_YN ,'Y') = 'Y'
//                                                   AND NVL(A.DC_YN      ,'N') = 'N'
//                                                   AND B.HOSP_CODE       = A.HOSP_CODE                                                   
//                                                   AND B.ORDER_GUBUN     = A.ORDER_GUBUN
//                                                   AND B.INPUT_TAB       = A.INPUT_TAB
//                                                   AND B.INPUT_TAB       = :f_input_tab
//                                                --   AND (( :f_input_tab = '%'           ) OR
//                                                --        ( :f_input_tab = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'       ) OR
//                                                --        ( :f_input_tab = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'       ) OR
//                                                --        ( :f_input_tab = '3' AND B.INPUT_TAB                 = '02'      ) OR
//                                                --        ( :f_input_tab = '4' AND B.INPUT_TAB                 = '03'      ) OR
//                                                --        ( :f_input_tab = '5' AND B.INPUT_TAB                 = '04'      ) OR
//                                                --        ( :f_input_tab = '6' AND B.INPUT_TAB                 = '05'      ) OR
//                                                --        ( :f_input_tab = '7' AND B.INPUT_TAB                 = '06'      ) OR
//                                                --        ( :f_input_tab = '8' AND B.INPUT_TAB                 = '07'      ) OR
//                                                --        ( :f_input_tab = '9' AND B.INPUT_TAB                 = '08'      ) )
//                                                   AND A.ORDER_DATE          >= ( SELECT MAX(C.TOIWON_DATE) - 90
//                                                                                    FROM VW_OCS_INP1001_02 C
//                                                                                   WHERE C.BUNHO       = :f_bunho
//                                                                                     AND C.IPWON_DATE <= :f_naewon_date
//                                                                                     AND C.HOSP_CODE   = :f_hosp_code   )
//                                                  ORDER BY 12 DESC";

//                this.grdOCS1003.QuerySQL = @"SELECT F.CODE_NAME                                                INPUT_GUBUN_NAME        ,
//                                                   A.GROUP_SER                                                GROUP_SER               ,
//                                                   NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,
//                                                   A.HANGMOG_CODE                                             HANGMOG_CODE            ,
//                                                   ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
//                                                          THEN NVL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE), '')||B.HANGMOG_NAME
//                                                          ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,
//                                                   A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,
//                                                   D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,
//                                                   A.SURYANG                                                  SURYANG                 ,
//                                                   A.ORD_DANUI                                                ORD_DANUI               ,
//                                                   FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,
//                                                   A.DV_TIME                                                  DV_TIME                 ,
//                                                   A.DV                                                       DV                      ,
//                                                   A.NALSU                                                    NALSU                   ,
//                                                   A.JUSA                                                     JUSA                    ,
//                                                   FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,
//                                                   A.BOGYONG_CODE                                             BOGYONG_CODE            ,
//                                                   FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
//                                                                                                              BOGYONG_NAME            ,
//                                                   A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,
//                                                   A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,
//                                                   A.PHARMACY                                                 PHARMACY                ,
//                                                   A.DRG_PACK_YN                                              DRG_PACK_YN             ,
//                                                   A.POWDER_YN                                                POWDER_YN               ,
//                                                   A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,
//                                                   NVL(A.DANGIL_GUMSA_ORDER_YN , 'N')                         DANGIL_GUMSA_ORDER_YN   ,
//                                                   NVL(A.DANGIL_GUMSA_RESULT_YN, 'N')                         DANGIL_GUMSA_RESULT_YN  ,
//                                                   NVL(A.EMERGENCY             , 'N')                         EMERGENCY               ,
//                                                   A.PAY                                                      PAY                     ,
//                                                   A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,
//                                                   A.MUHYO                                                    MUHYO                   ,
//                                                   A.PORTABLE_YN                                              PORTABLE_YN             ,
//                                                   A.OCS_FLAG                                                 OCS_FLAG                ,
//                                                   A.ORDER_GUBUN                                              ORDER_GUBUN             ,
//                                                   A.INPUT_TAB                                                INPUT_TAB               ,
//                                                   A.INPUT_GUBUN                                              INPUT_GUBUN             ,
//                                                   A.AFTER_ACT_YN                                             AFTER_ACT_YN            ,
//                                                   A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,
//                                                   A.JUNDAL_PART                                              JUNDAL_PART             ,
//                                                   A.MOVE_PART                                                MOVE_PART               ,
//                                                   A.BUNHO                                                    BUNHO                   ,
//                                                   A.ORDER_DATE                                               ORDER_DATE              ,
//                                                   A.GWA                                                      GWA                     ,
//                                                   A.DOCTOR                                                   DOCTOR                  ,
//                                                   A.NAEWON_TYPE                                              NAEWON_TYPE             ,
//                                                   A.FKOUT1001                                                PK_ORDER                ,
//                                                   A.SEQ                                                      SEQ                     ,
//                                                   A.PKOCS1003                                                PKOCS1003               ,
//                                                   A.SUB_SUSUL                                                SUB_SUSUL               ,
//                                                   A.SUTAK_YN                                                 SUTAK_YN                ,
//                                                   A.AMT                                                      AMT                     ,
//                                                   A.DV_1                                                     DV_1                    ,
//                                                   A.DV_2                                                     DV_2                    ,
//                                                   A.DV_3                                                     DV_3                    ,
//                                                   A.DV_4                                                     DV_4                    ,
//                                                   A.HOPE_DATE                                                HOPE_DATE               ,
//                                                   A.ORDER_REMARK                                             ORDER_REMARK            ,
//                                                   A.MIX_GROUP                                                MIX_GROUP               ,
//                                                   A.HOME_CARE_YN                                             HOME_CARE_YN            ,
//                                                   NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,
//                                                   A.GONGBI_CODE                                              GONGBI_CODE             ,
//                                                   FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, A.ORDER_DATE)       GONGBI_NAME             ,
//                                                   DECODE( B.ORDER_GUBUN, 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE), 'N' )
//                                                                                                              DONBOK_YN               ,
//                                                   FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4, A.DV_5, A.DV_6, A.DV_7, A.DV_8)
//                                                                                                              DV_NAME                 ,
//                                                   B.SLIP_CODE                                                SLIP_CODE               ,
//                                                   B.GROUP_YN                                                 GROUP_YN                ,
//                                                   B.SG_CODE                                                  SG_CODE                 ,
//                                                   B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,
//                                                   B.INPUT_CONTROL                                            INPUT_CONTROL           ,
//                                                   NVL(B.SUGA_YN,'N')                                         SUGA_YN                 ,
//                                                   DECODE(NVL(B.EMERGENCY,'Z'),'Y','N','N','N','Y')           EMERGENCY_CHECK         ,
//                                                   B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,
//                                                   NVL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,
//                                                   NVL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,
//                                                   DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,
//                                                   B.ORD_DANUI                                                ORD_DANUI_BAS           ,
//                                                   A.JUNDAL_TABLE                                             JUNDAL_TABLE_OUT        ,
//                                                   A.JUNDAL_PART                                              JUNDAL_PART_OUT         ,
//                                                   ( CASE WHEN FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE) <> 'Y'
//                                                          THEN 'N'
//                                                          WHEN FN_OCS_BULYONG_CHECK_OUT   (B.HANGMOG_CODE, SYSDATE) = 'Y'
//                                                           AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', A.HANGMOG_CODE, A.BUNHO, TRUNC(SYSDATE)) <> A.HANGMOG_CODE
//                                                          THEN 'Z'
//                                                          ELSE 'Y' END )                                      BULYONG_CHECK           ,
//                                                   FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE)                   WONYOI_ORDER_CR_YN      ,
//                                                   B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,
//                                                   NVL(B.NDAY_YN,'N')                                         NDAY_YN                 ,
//                                                   NVL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,
//                                                   A.TEL_YN                                                   TEL_YN                  ,
//                                                   E.BUN_CODE                                                 BUN_CODE                ,
//                                                   E.SG_GESAN                                                 SG_GESAN                ,
//                                                   FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE)                        DRG_INFO                ,
//                                                   ''                                                         DRG_BUNRYU              ,
//                                                   DECODE(A.BOM_SOURCE_KEY,NULL,FN_OCS_LOAD_CHILD_GUBUN('O',A.PKOCS1003),'3')      CHILD_GUBUN,
//                                                   A.BOM_SOURCE_KEY                                          BOM_SOURCE_KEY,
//                                                   A.BOM_OCCUR_YN                                            BOM_OCCUR_YN,   
//                                                   A.PKOCS1003                                               PARENTS_KEY,
//                                                   A.BOM_SOURCE_KEY                                          CHILD_KEY,
//                                                   LTRIM(TO_CHAR(NVL(F.SORT_KEY, 99), '00'))||NVL(A.TEL_YN, 'N')||LTRIM(TO_CHAR(NVL(C.SORT_KEY, 99), '00'))||
//                                                   ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B')
//                                                           AND A.HOPE_DATE IS NOT NULL
//                                                          THEN TO_CHAR(A.HOPE_DATE, 'YYYYMMDD')
//                                                          ELSE '00000000' END )||
//                                                   LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||LTRIM(TO_CHAR(A.SEQ, '0000'))
//                                                                                                              CONT_KEY
//                                              FROM OCS0140 G,
//                                                   OCS0132 F,
//                                                   BAS0310 E,
//                                                   OCS0116 D,
//                                                   OCS0132 C,
//                                                   OCS0103 B,
//                                                   OCS1003 A
//                                             WHERE A.BUNHO            = :f_bunho
//                                               AND A.ORDER_DATE       = :f_naewon_date
//                                               AND A.GWA              = :f_gwa
//                                               AND A.DOCTOR           = :f_doctor
//                                               AND A.NAEWON_TYPE      = :f_naewon_type
//                                               AND A.INPUT_TAB        = :f_input_tab
//                                               AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR
//                                                    ( :f_input_gubun = 'NR'           ) OR
//                                                    ( :f_input_gubun = 'D%'           ))
//                                               AND NVL(A.TEL_YN     , 'N') LIKE :f_tel_yn
//                                               AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
//                                               AND NVL(A.DC_YN,'N')   = 'N'
//                                               AND A.NALSU           >= 0
//                                               AND B.HANGMOG_CODE     = A.HANGMOG_CODE
//                                               AND C.CODE     (+)     = A.ORDER_GUBUN
//                                               AND C.CODE_TYPE(+)     = 'ORDER_GUBUN'
//                                               AND F.CODE     (+)     = A.INPUT_GUBUN
//                                               AND F.CODE_TYPE(+)     = 'INPUT_GUBUN'
//                                               AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
//                                               AND E.SG_CODE  (+)     = B.SG_CODE
//                                               AND G.ORDER_GUBUN      = A.ORDER_GUBUN
//                                               AND G.INPUT_TAB        = A.INPUT_TAB
//                                            --   AND (( :f_input_tab = '%'           ) OR
//                                            --        ( :f_input_tab = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'       ) OR
//                                            --        ( :f_input_tab = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'       ) OR
//                                            --        ( :f_input_tab = '3' AND G.INPUT_TAB                 = '02'      ) OR
//                                            --        ( :f_input_tab = '4' AND G.INPUT_TAB                 = '03'      ) OR
//                                            --        ( :f_input_tab = '5' AND G.INPUT_TAB                 = '04'      ) OR
//                                            --        ( :f_input_tab = '6' AND G.INPUT_TAB                 = '05'      ) OR
//                                            --        ( :f_input_tab = '7' AND G.INPUT_TAB                 = '06'      ) OR
//                                            --        ( :f_input_tab = '8' AND G.INPUT_TAB                 = '07'      ) OR
//                                            --        ( :f_input_tab = '9' AND G.INPUT_TAB                 = '08'      ) )
//                                            UNION ALL
//                                            SELECT F.CODE_NAME                                                INPUT_GUBUN_NAME        ,
//                                                   A.GROUP_SER                                                GROUP_SER               ,
//                                                   NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,
//                                                   A.HANGMOG_CODE                                             HANGMOG_CODE            ,
//                                                   ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
//                                                          THEN NVL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE), '')||B.HANGMOG_NAME
//                                                          ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,
//                                                   A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,
//                                                   D.SPECIMEN_NAME                                            SPECIMEN_NAME           ,
//                                                   A.SURYANG                                                  SURYANG                 ,
//                                                   A.ORD_DANUI                                                ORD_DANUI               ,
//                                                   FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,
//                                                   A.DV_TIME                                                  DV_TIME                 ,
//                                                   A.DV                                                       DV                      ,
//                                                   A.NALSU                                                    NALSU                   ,
//                                                   A.JUSA                                                     JUSA                    ,
//                                                   FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,
//                                                   A.BOGYONG_CODE                                             BOGYONG_CODE            ,
//                                                   FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
//                                                                                                              BOGYONG_NAME            ,
//                                                   A.JUSA_SPD_GUBUN                                           JUSA_SPD_GUBUN          ,
//                                                   A.HUBAL_CHANGE_YN                                          HUBAL_CHANGE_YN         ,
//                                                   A.PHARMACY                                                 PHARMACY                ,
//                                                   A.DRG_PACK_YN                                              DRG_PACK_YN             ,
//                                                   A.POWDER_YN                                                POWDER_YN               ,
//                                                   A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,
//                                                   'N'                                                        DANGIL_GUMSA_ORDER_YN   ,
//                                                   'N'                                                        DANGIL_GUMSA_RESULT_YN  ,
//                                                   NVL(A.EMERGENCY  , 'N')                                    EMERGENCY               ,
//                                                   A.PAY                                                      PAY                     ,
//                                                   A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,
//                                                   A.MUHYO                                                    MUHYO                   ,
//                                                   A.PORTABLE_YN                                              PORTABLE_YN             ,
//                                                   A.OCS_FLAG                                                 OCS_FLAG                ,
//                                                   A.ORDER_GUBUN                                              ORDER_GUBUN             ,
//                                                   A.INPUT_TAB                                                INPUT_TAB               ,
//                                                   A.INPUT_GUBUN                                              INPUT_GUBUN             ,
//                                                   'N'                                                        AFTER_ACT_YN            ,
//                                                   A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,
//                                                   A.JUNDAL_PART                                              JUNDAL_PART             ,
//                                                   NULL                                                       MOVE_PART               ,
//                                                   A.BUNHO                                                    BUNHO                   ,
//                                                   A.ORDER_DATE                                               NAEWON_DATE             ,
//                                                   A.INPUT_PART                                               GWA                     ,
//                                                   A.INPUT_ID                                                 DOCTOR                  ,
//                                                   '0'                                                        NAEWON_TYPE             ,
//                                                   A.FKINP1001                                                PK_ORDER                ,
//                                                   A.SEQ                                                      SEQ                     ,
//                                                   A.PKOCS2003                                                PKOCS1003               ,
//                                                   A.SUB_SUSUL                                                SUB_SUSUL               ,
//                                                   NULL                                                       SUTAK_YN                ,
//                                                   A.AMT                                                      AMT                     ,
//                                                   A.DV_1                                                     DV_1                    ,
//                                                   A.DV_2                                                     DV_2                    ,
//                                                   A.DV_3                                                     DV_3                    ,
//                                                   A.DV_4                                                     DV_4                    ,
//                                                   A.HOPE_DATE                                                HOPE_DATE               ,
//                                                   A.ORDER_REMARK                                             ORDER_REMARK            ,
//                                                   A.MIX_GROUP                                                MIX_GROUP               ,
//                                                   'N'                                                        HOME_CARE_YN            ,
//                                                   NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,
//                                                   A.GONGBI_CODE                                              GONGBI_CODE             ,
//                                                   FN_BAS_LOAD_GONGBI_NAME(A.GONGBI_CODE, A.ORDER_DATE)       GONGBI_NAME             ,
//                                                   DECODE( B.ORDER_GUBUN, 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE), 'N' )
//                                                                                                              DONBOK_YN               ,
//                                                   FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4, A.DV_5, A.DV_6, A.DV_7, A.DV_8)
//                                                                                                              DV_NAME                 ,
//                                                   B.SLIP_CODE                                                SLIP_CODE               ,
//                                                   B.GROUP_YN                                                 GROUP_YN                ,
//                                                   B.SG_CODE                                                  SG_CODE                 ,
//                                                   B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,
//                                                   B.INPUT_CONTROL                                            INPUT_CONTROL           ,
//                                                   NVL(B.SUGA_YN,'N')                                         SUGA_YN                 ,
//                                                   DECODE(NVL(B.EMERGENCY,'Z'),'Y','N','N','N','Y')           EMERGENCY_CHECK         ,
//                                                   B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,
//                                                   NVL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,
//                                                   NVL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,
//                                                   DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,
//                                                   B.ORD_DANUI                                                ORD_DANUI_BAS           ,
//                                                   A.JUNDAL_TABLE                                             JUNDAL_TABLE_OUT        ,
//                                                   A.JUNDAL_PART                                              JUNDAL_PART_OUT         ,
//                                                   FN_OCS_BULYONG_CHECK_OUT(B.HANGMOG_CODE, SYSDATE)          BULYONG_CHECK           ,
//                                                   FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE)                   WONYOI_ORDER_CR_YN      ,
//                                                   B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,
//                                                   NVL(B.NDAY_YN,'N')                                         NDAY_YN                 ,
//                                                   NVL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,
//                                                   A.TEL_YN                                                   TEL_YN                  ,
//                                                   E.BUN_CODE                                                 BUN_CODE                ,
//                                                   E.SG_GESAN                                                 SG_GESAN                ,
//                                                   FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE)                        DRG_INFO                ,
//                                                   ''                                                         DRG_BUNRYU              ,
//                                                   DECODE(A.BOM_SOURCE_KEY,NULL,FN_OCS_LOAD_CHILD_GUBUN('I',A.PKOCS2003),'3')      CHILD_GUBUN,
//                                                   A.BOM_SOURCE_KEY                                          BOM_SOURCE_KEY,
//                                                   A.BOM_OCCUR_YN                                            BOM_OCCUR_YN,   
//                                                   A.PKOCS2003                                               PARENTS_KEY,
//                                                   A.BOM_SOURCE_KEY                                          CHILD_KEY,
//                                                   LTRIM(TO_CHAR(NVL(F.SORT_KEY, 99), '00'))||NVL(A.TEL_YN, 'N')||LTRIM(TO_CHAR(NVL(C.SORT_KEY, 99), '00'))||LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||LTRIM(TO_CHAR(A.SEQ, '0000'))
//                                                                                                              CONT_KEY
//                                              FROM OCS0140 G,
//                                                   OCS0132 F,
//                                                   BAS0310 E,
//                                                   OCS0116 D,
//                                                   OCS0132 C,
//                                                   OCS0103 B,
//                                                   OCS2003 A
//                                             WHERE A.BUNHO            = :f_bunho
//                                               AND A.FKINP1001        = :f_jubsu_no
//                                               AND A.ORDER_DATE       = :f_naewon_date
//                                               AND A.INPUT_GWA        = :f_gwa
//                                               AND A.INPUT_DOCTOR     = :f_doctor
//                                               AND A.INPUT_TAB        = :f_input_tab
//                                               AND (( A.INPUT_GUBUN   = :f_input_gubun ) OR
//                                                    ( :f_input_gubun  = 'NR'           ) OR
//                                                    ( :f_input_gubun  = 'D%'           ))
//                                               AND NVL(A.DISPLAY_YN , 'Y') = 'Y'
//                                               AND NVL(A.DC_YN,'N')   = 'N'
//                                               AND A.NALSU           >= 0
//                                               AND B.HANGMOG_CODE     = A.HANGMOG_CODE
//                                               AND C.CODE     (+)     = A.ORDER_GUBUN
//                                               AND C.CODE_TYPE(+)     = 'ORDER_GUBUN'
//                                               AND F.CODE     (+)     = A.INPUT_GUBUN
//                                               AND F.CODE_TYPE(+)     = 'INPUT_GUBUN'
//                                               AND D.SPECIMEN_CODE(+) = A.SPECIMEN_CODE
//                                               AND E.SG_CODE  (+)     = B.SG_CODE
//                                               AND G.ORDER_GUBUN      = A.ORDER_GUBUN
//                                               AND G.INPUT_TAB        = A.INPUT_TAB
//                                            --   AND (( :f_input_tab = '%'           ) OR
//                                            --        ( :f_input_tab = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'       ) OR
//                                            --        ( :f_input_tab = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'       ) OR
//                                            --        ( :f_input_tab = '3' AND G.INPUT_TAB                 = '02'      ) OR
//                                            --        ( :f_input_tab = '4' AND G.INPUT_TAB                 = '03'      ) OR
//                                            --        ( :f_input_tab = '5' AND G.INPUT_TAB                 = '04'      ) OR
//                                            --        ( :f_input_tab = '6' AND G.INPUT_TAB                 = '05'      ) OR
//                                            --        ( :f_input_tab = '7' AND G.INPUT_TAB                 = '06'      ) OR
//                                            --        ( :f_input_tab = '8' AND G.INPUT_TAB                 = '07'      ) OR
//                                            --        ( :f_input_tab = '9' AND G.INPUT_TAB                 = '08'      ) )
//                                             ORDER BY 92";
//                #endregion
//                //this.dsvLDOUT1001.WorkTp = '1';
//                //this.dsvLDOCS1003.WorkTp = '3';
//                //this.pnlSang.Visible = true;
//            }

//            grdOUT1001.SetBindVarValue("f_naewon_date", dpkNaewon_date.GetDataValue());
//            if (!grdOUT1001.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            
//        }

//        #endregion

        #endregion

        #region [검사정보조회]

        // 검사정보조회
        private void PopUpMenuGumsaInfo_Click(object sender, System.EventArgs e)
        {
            if (this.CurrMSLayout == null || CurrMSLayout.CurrentRowNumber < 0) return;

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("hangmog_code", CurrMSLayout.GetItemValue(CurrMSLayout.CurrentRowNumber, "hangmog_code"));
            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }

        #endregion

        #region ntt childSetImage
        private void childSetImage()
        {
            for (int i = 0; i < this.grdOCS1003.RowCount; i++)
            {
                //this.grdOCS1003[i, "child_yn"].ForeColor = IHIS.Framework.XColor.XGridColHeaderForeColor;
                string child_yn = this.grdOCS1003.GetItemString(i, "child_yn");

                switch (child_yn)
                {
                    case "Y":
                        this.grdOCS1003[i, "child_yn"].Image = this.ImageList.Images[6];
                        break;
                    case "N":
                        this.grdOCS1003[i, "child_yn"].Image = this.ImageList.Images[4];
                        break;
                    default:
                        this.grdOCS1003[i, "child_yn"].Image = this.ImageList.Images[4];
                        break;

                }
                this.grdOCS1003[i, "child_yn"].ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            }
        }
        #endregion

        #region 각 그리드에 바인드 변수 설정
        private void grdOCS1003_QueryStarting(object sender, CancelEventArgs e)
        {
            this.gbxNalsu.Enabled = false;

            XEditGrid grd = this.grdOUT1001;
            int currRow = grd.CurrentRowNumber;

            grdOCS1003.SetBindVarValue("f_bunho"        , grd.GetItemString(currRow, "bunho"));
            grdOCS1003.SetBindVarValue("f_naewon_date"  , grd.GetItemString(currRow, "naewon_date").Replace(" 0:00:00", ""));
            grdOCS1003.SetBindVarValue("f_gwa"          , grd.GetItemString(currRow, "gwa"));
            grdOCS1003.SetBindVarValue("f_doctor"       , grd.GetItemString(currRow, "doctor"));
            grdOCS1003.SetBindVarValue("f_naewon_type"  , grd.GetItemString(currRow, "naewon_type"));
            //grdOCS1003.SetBindVarValue("f_input_gubun", grd.GetItemString(currRow,  "input_gubun"));
            grdOCS1003.SetBindVarValue("f_input_gubun"  , this.mInput_gubun);
            grdOCS1003.SetBindVarValue("f_tel_yn"       , grd.GetItemString(currRow, "tel_yn")); 
            grdOCS1003.SetBindVarValue("f_input_tab"    , grd.GetItemString(currRow, "input_tab"));
            grdOCS1003.SetBindVarValue("f_jubsu_no"     , grd.GetItemString(currRow, "jubsu_no"));
            grdOCS1003.SetBindVarValue("f_pk_order"     , grd.GetItemString(currRow, "pk_order"));
            grdOCS1003.SetBindVarValue("f_hosp_code"    , mHospCode);
            grdOCS1003.SetBindVarValue("f_generic_yn"   , cbxGeneric_YN.GetDataValue());
            grdOCS1003.SetBindVarValue("f_kijun"        , this.cboKijunGubun.SelectedValue.ToString());
        }

        private void grdOUT1001_QueryStarting(object sender, CancelEventArgs e)
        {
            
            if(this.chkAll.Checked)
                grdOUT1001.SetBindVarValue("f_gwa", "%");
            else
                grdOUT1001.SetBindVarValue("f_gwa", this.mGwa);

            grdOUT1001.SetBindVarValue("f_bunho",       this.pbxSearch.BunHo.ToString());
            grdOUT1001.SetBindVarValue("f_input_gubun", this.mInput_gubun);
            grdOUT1001.SetBindVarValue("f_tel_yn",      mTel_yn);
            grdOUT1001.SetBindVarValue("f_hosp_code",   mHospCode);
            grdOUT1001.SetBindVarValue("f_io_gubun",    IOGubun);
            grdOUT1001.SetBindVarValue("f_input_tab",   mInput_tab);

            if (this.cboKijunGubun.SelectedIndex < 0)
                this.cboKijunGubun.SelectedIndex = 0;

            grdOUT1001.SetBindVarValue("f_kijun",       this.cboKijunGubun.SelectedValue.ToString());

            grdOUT1001.SetBindVarValue("f_selected_input_tab", this.tabOrderGubun.SelectedTab.Tag.ToString()); // 1:薬(01) 2:注射(03) 3:検査(04, 05, 06) 4:その他(07, 08, 09, 10)
        }
        #endregion

        private void xButtonList1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control) // 마우스오른쪽클릭 + Ctrl Key 입력시 
            {
                if (this.CurrMQLayout != null) this.mOrderBiz.GridDisplayValue((XGrid)this.CurrMQLayout); // 현재 Current Row의 모든 값을 디스플레이한다
            }
        }

        private void grdOCS1003_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            string currentGroupSer = "";
            string currentColumn = e.ColName;
            string currentNalsu = e.DataRow["nalsu"].ToString();
            XEditGrid grd = sender as XEditGrid;

            object previousValue = grd.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // 이전 Value

            

            switch(e.ColName)
            {
                case "nalsu":
                    currentGroupSer = e.DataRow["group_ser"].ToString();

                    for (int i = 0; i < grd.RowCount; i++)
                    {
                        if (grd.GetItemValue(i, "group_ser").ToString() == currentGroupSer)
                        {
                            grd.SetItemValue(i, "nalsu", currentNalsu);

                            //変更されたROWがすでに選択された状態であればdloSelectOCS1003に変更する前の「日数」が入っているため、変更された「日数」を探して変更されたデータを変更しなければならない。
                            if (grd.GetItemString(i, "select") == "Y")
                            {
                                for (int kk = 0; kk < this.dloSelectOCS1003.RowCount; kk++)
                                {
                                    if(this.dloSelectOCS1003.GetItemString(kk, "pkocs1003") == grd.GetItemString(i, "pkocs1003"))
                                        this.dloSelectOCS1003.SetItemValue(kk, e.ColName, e.ChangeValue.ToString());
                                }
                            }
                        }
                    }
                    break;

                case "suryang":
                    //変更されたROWがすでに選択された状態であればdloSelectOCS1003に変更する前の「数量」が入っているため、変更された「数量」を探して変更されたデータを変更しなければならない。
                    if (grd.GetItemString(e.RowNumber, "select") == "Y")
                    {
                        for (int kk = 0; kk < this.dloSelectOCS1003.RowCount; kk++)
                        {
                            if (this.dloSelectOCS1003.GetItemString(kk, "pkocs1003") == grd.GetItemString(e.RowNumber, "pkocs1003"))
                                this.dloSelectOCS1003.SetItemValue(kk, e.ColName, e.ChangeValue.ToString());
                        }
                    }
                    break;
                case "hope_date":
                
                    #region
                    if (!TypeCheck.IsNull(e.ChangeValue))
                    {
                        if (!TypeCheck.IsDateTime(e.ChangeValue.ToString()))
                        {
                            mbxMsg = Resources.MSG011_MSG;
                            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

                            this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다						
                        }

                        if (int.Parse(e.ChangeValue.ToString().Replace("/", "")) < int.Parse(this.mNaewon_date.Replace("/", "")))
                        {
                            mbxMsg = Resources.MSG012_1_MSG + this.mNaewon_date + Resources.MSG012_2_MSG;
                            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

                            this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다						
                        }

                        // 희망일자 입력시 당임검사, 결과 여부 푼다
                        if (grd.CellInfos.Contains("dangil_gumsa_order_yn")) grd.SetItemValue(e.RowNumber, "dangil_gumsa_order_yn", "N");
                        if (grd.CellInfos.Contains("dangil_gumsa_result_yn")) grd.SetItemValue(e.RowNumber, "dangil_gumsa_result_yn", "N");

                        //変更されたROWがすでに選択された状態であればdloSelectOCS1003に変更する前の「数量」が入っているため、変更された「数量」を探して変更されたデータを変更しなければならない。
                        if (grd.GetItemString(e.RowNumber, "select") == "Y")
                        {
                            for (int kk = 0; kk < this.dloSelectOCS1003.RowCount; kk++)
                            {
                                if (this.dloSelectOCS1003.GetItemString(kk, "pkocs1003") == grd.GetItemString(e.RowNumber, "pkocs1003"))
                                    this.dloSelectOCS1003.SetItemValue(kk, e.ColName, e.ChangeValue.ToString());
                            }
                        }
                    }
                    #endregion

                    
                    break;
            }
        }

        private void grdOUT1001_MouseDown(object sender, MouseEventArgs e)
        {
            //delete by jc [リストで選択機能を外してほしいって事で注釈処理] 2012/03/22
            int rowIndex;

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                rowIndex = grdOUT1001.GetHitRowNumber(e.Y);
                if (rowIndex < 0) return;

                if (grdOUT1001.CurrentColName != "select")
                {
                    return;
                }
                if (grdOUT1001.GetItemString(rowIndex, "select") == "N")
                {
                    grdOUT1001.SetItemValue(rowIndex, "select", "Y");
                    SelectionBackColorChange(grdOUT1001, rowIndex, "Y");
                    this.grdSelectAll(this.grdOCS1003);
                }
                else
                {
                    grdOUT1001.SetItemValue(rowIndex, "select", "N");
                    SelectionBackColorChange(grdOUT1001, rowIndex, "N");
                    this.grdDeleteAll(this.grdOCS1003);
                }
                //if (grdOUT1001.CurrentColNumber == 0)
                //{
                //    if (grdOUT1001.GetItemString(rowIndex, "select") == "N")
                //    {
                //        grdOUT1001.SetItemValue(rowIndex, "select", "Y");
                //        //외래오더에서 호출이고 입원do오다 선택시
                //        //원외처리
                //        if (this.mIOgubun == "O" && this.rbtIn.Checked)
                //        {
                //            if (this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1, 1) == "C" ||
                //                this.grdOCS1003.GetItemString(rowIndex, "order_gubun").Substring(1, 1) == "D")
                //            {
                //                SetWonyoiOrderYN(rowIndex);
                //            }
                //        }
                //    }
                //    else
                //    {
                //        grdOUT1001.SetItemValue(rowIndex, "select", "N");
                //    }
                //    SetSelectNaewon(this.grdOUT1001.CurrentRowNumber);
                //}
            }
        }

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
        private void OpenScreen_XRT0000Q00(string aBunho)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "XRTS", "XRT0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, param);
        }
        private void OpenScreen_INJ0000Q00(string aBunho)
        {
            CommonItemCollection openParam = new CommonItemCollection();

            openParam.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "INJS", "INJ0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, openParam);
        }
        private void OpenScreen_ScanViewer(string aBunho)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);

            //XScreen.OpenScreenWithParam(this, "CPLS", "SCANVIEWER", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, param);
            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, param);
        }
        #region [ 내시경 결과 조회 ]

        // 처방행삭제
        private void PopUpMenuPfeResult_Click(object sender, System.EventArgs e)
        {
            IHIS.X.Magic.Menus.MenuCommand menu = sender as IHIS.X.Magic.Menus.MenuCommand;

            //string targetUrl = "";
            string serverIP = "192.168.150.114";

            string cmdText = @"SELECT CODE_NAME
                                 FROM OCS0132
                                WHERE CODE_TYPE = 'SERVER_IP'
                                  AND CODE = 'ENDO'";

            object retVal = Service.ExecuteScalar(cmdText);

            if (!TypeCheck.IsNull(retVal))
            {
                serverIP = retVal.ToString();
            }

            switch (menu.Tag.ToString())
            {
                case "3":     // 이미지 결과 조회

                    try
                    {
                        //targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=" + this.pbxSearch.BunHo.ToString() + "&TYPE=1";//&KEY=12345";

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
                        //targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=" + this.pbxSearch.BunHo.ToString() + "&TYPE=2";//&KEY=12345";

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

                    if (this.pbxSearch.BunHo.ToString() != "")
                    {
                        EkgCallHelper.CallViewer(this.pbxSearch.BunHo.ToString());
                    }

                    break;
            }
        }
        #endregion

        #region Order_gubun Tab 변경
        private void tabOrderGubun_SelectionChanged(object sender, EventArgs e)
        {
            if (this.pbxSearch.BunHo.ToString() != "")
                this.grdOUT1001.QueryLayout(false);
            
//        /// <summary>
//        /// tab 변경시 해당 처방조회
//        /// </summary>
//        /// 1:全体
//        /// 2:薬
//        /// 3:注射
//        /// 4:検査
//        /// 5:その他
//            /// G 
//            /// H
//            /// I
//            /// J
//            /// K
//            /// L
//            /// M
//            /// N
//            /// O
//            /// Z
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//            if( tabOrderGubun.SelectedTab == null ) return;

//            foreach( IHIS.X.Magic.Controls.TabPage page in tabOrderGubun.TabPages)
//            {
//                if(tabOrderGubun.SelectedTab == page)
//                    page.ImageIndex = 1;
//                else
//                    page.ImageIndex = 0;
//            }

//            for (int i = 0; i < grdOUT1001.RowCount; i++)
//            {
//                grdOUT1001.SetItemValue(i, "select", "N");
//                SelectionBackColorChange(grdOUT1001, i, "N");
//                this.grdDeleteAll(this.grdOCS1003);
//            }
            
//            grdOCS1003.QueryLayout(true);



//            //검사인 경우에는 실시일 기준으로 조회한다.
//            if (tabOrderGubun.SelectedTab.Tag.ToString() == "4")
//            {
//                string filter = @" order_gubun_bas <> 'A' 
//                               and order_gubun_bas <> 'B'
//                               and order_gubun_bas <> 'C'
//                               and order_gubun_bas <> 'D'
//                               and order_gubun_bas <> 'E'
//                               and order_gubun_bas <> 'F'
//                                 ";
//                this.grdOCS1003.SetFilter(filter);
//            }
//            else if(tabOrderGubun.SelectedTab.Tag.ToString() == "3")
//            {
//                string filter = @" order_gubun_bas = 'F' 
//                                or order_gubun_bas = 'E'
//                                or order_gubun_bas = 'N'
//                                or order_gubun_bas = 'O'";
//                this.grdOCS1003.SetFilter(filter);
//            }
//            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "2")
//            {
//                string filter = " order_gubun_bas = 'A' or order_gubun_bas = 'B' ";
//                this.grdOCS1003.SetFilter(filter);
//            }
//            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "1")
//            {
//                string filter = " order_gubun_bas = 'C' or order_gubun_bas = 'D' ";
//                this.grdOCS1003.SetFilter(filter);
//            }
//            else
//            {
//                this.grdOCS1003.SetFilter("");
//            }




//            //else if (tabOrderGubun.SelectedTab.Tag.ToString() == "%")
//            //{
//            //    string filter= @" order_gubun_bas <> '999' ";
//            //    this.grdOCS1003.SetFilter(filter);
//            //}
//            //else
//            //{
//            //    grdOCS1003.QueryLayout(true);
//            //}
            tabOrderGubunChanged();
            this.SetInitialOrderGridCheckImage();
            this.childSetImage();

        }
        #endregion
        private void tabOrderGubunChanged()
        {
            /// <summary>
            /// tab 변경시 해당 처방조회
            /// </summary>
            /// 1:全体
            /// 2:薬
            /// 3:注射
            /// 4:検査
            /// 5:その他
            /// G 
            /// H
            /// I
            /// J
            /// K
            /// L
            /// M
            /// N
            /// O
            /// Z
            /// <param name="sender"></param>
            /// <param name="e"></param>
            if (tabOrderGubun.SelectedTab == null) return;

            foreach (IHIS.X.Magic.Controls.TabPage page in tabOrderGubun.TabPages)
            {
                if (tabOrderGubun.SelectedTab == page)
                    page.ImageIndex = 1;
                else
                    page.ImageIndex = 0;
            }

            //for (int i = 0; i < grdOUT1001.RowCount; i++)
            //{
            //    grdOUT1001.SetItemValue(i, "select", "N");
            //    SelectionBackColorChange(grdOUT1001, i, "N");
            //    this.grdDeleteAll(this.grdOCS1003);
            //}

            //dloSelectOCS1003.Reset();

            //for (int i = 0; i < this.grdOUT1001.RowCount; i++)
            //{
            //    this.grdOUT1001.SetItemValue(i, "select", "N");
            //    SelectionBackColorChange(this.grdOUT1001, i, "N");
            //}

            // Connect to cloud service
            grdOCS1003.ExecuteQuery = ExecuteQueryGrdOCS1003;
            grdOCS1003.QueryLayout(true);
           


            //검사인 경우에는 실시일 기준으로 조회한다.
            if (tabOrderGubun.SelectedTab.Tag.ToString() == "4")
            {
                string filter = @" order_gubun_bas <> 'A' 
                               and order_gubun_bas <> 'B'
                               and order_gubun_bas <> 'C'
                               and order_gubun_bas <> 'D'
                               and order_gubun_bas <> 'E'
                               and order_gubun_bas <> 'F'
                                 ";
                this.grdOCS1003.SetFilter(filter);
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "3")
            {
                string filter = @" order_gubun_bas = 'F' 
                                or order_gubun_bas = 'E'
                                or order_gubun_bas = 'N'
                                or order_gubun_bas = 'O'";
                this.grdOCS1003.SetFilter(filter);
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "2")
            {
                string filter = " order_gubun_bas = 'A' or order_gubun_bas = 'B' ";
                this.grdOCS1003.SetFilter(filter);
            }
            else if (tabOrderGubun.SelectedTab.Tag.ToString() == "1")
            {
                string filter = " order_gubun_bas = 'C' or order_gubun_bas = 'D' ";
                this.grdOCS1003.SetFilter(filter);
            }
            else
            {
                this.grdOCS1003.SetFilter("");
            }

        }
        private void grdOCS1003_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            //内服薬、外用薬を除外して他のオーダは日数を変えることができなくする。
            //if (!(e.DataRow["order_gubun_bas"].ToString() == "C" || e.DataRow["order_gubun_bas"].ToString() == "D"))
            if (e.ColName == "nalsu" && e.DataRow["order_gubun"].ToString().Substring(1, 1) != "C" && TypeCheck.NVL(e.DataRow["donbog_yn"].ToString(), "N").ToString() != "N")
                e.Protect = true;
            else if (e.ColName == "nalsu" && e.DataRow["order_gubun"].ToString().Substring(1, 1) == "C" && TypeCheck.NVL(e.DataRow["donbog_yn"].ToString(), "N").ToString() != "N")
                e.Protect = true;
            else if (e.ColName == "nalsu" && e.DataRow["order_gubun"].ToString().Substring(1, 1) != "C")
                e.Protect = true;

            if (e.ColName == "suryang" && (e.DataRow["order_gubun"].ToString().Substring(1, 1) != "D" && TypeCheck.NVL(e.DataRow["donbog_yn"].ToString(), "N").ToString() != "Y"))
                e.Protect = true;

            if (e.ColName == "dv" && (e.DataRow["order_gubun"].ToString().Substring(1, 1) != "C" || TypeCheck.NVL(e.DataRow["donbog_yn"].ToString(), "N").ToString() != "Y"))
                e.Protect = true;

            //if (e.ColName == "hope_date" && (  e.DataRow["order_gubun"].ToString().Substring(1, 1) != "C" // 内服
            //                                && e.DataRow["order_gubun"].ToString().Substring(1, 1) != "D" // 外用
            //                                && e.DataRow["order_gubun"].ToString().Substring(1, 1) != "E" // 画像検査
            //                                && e.DataRow["order_gubun"].ToString().Substring(1, 1) != "F" // 検体検査
            //                                && e.DataRow["order_gubun"].ToString().Substring(1, 1) != "N" // 生理検査
            //                                )
            //   )
            //    e.Protect = true;

            //if (  
            //     (
            //          (this.mIOgubun == "I" && grdOCS1003.GetItemString(e.RowNumber, "io_yn") == "O")
            //       || (this.mIOgubun == "O" && grdOCS1003.GetItemString(e.RowNumber, "io_yn") == "I")
            //     )
            //     && this.mInput_gubun != "D7"
            //    )
            //    e.Protect = true;

            
        }

        private void grdSangInfo_QueryStarting(object sender, CancelEventArgs e)
        {
//            grdSangInfo.SetBindVarValue("f_bunho",       this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "bunho"));
//            grdSangInfo.SetBindVarValue("f_naewon_date", this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "naewon_date"));
//            grdSangInfo.SetBindVarValue("f_gwa",         this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "gwa"));
//            grdSangInfo.SetBindVarValue("f_doctor",      this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "doctor"));
//            grdSangInfo.SetBindVarValue("f_naewon_type", this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "naewon_type"));
//            grdSangInfo.SetBindVarValue("f_jubsu_no",    this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "jubsu_no"));
//            //grdSangInfo.SetBindVarValue("f_io_gubun", grdOrderDateList.GetItemString(grdOrderDateList.CurrentRowNumber, "io_gubun"));
//            grdSangInfo.SetBindVarValue("f_hosp_code",   EnvironInfo.HospCode);
//
//            if (rbtOut.Checked)
//            {
//                grdSangInfo.SetBindVarValue("f_io_gubun", "O");
//            }
//            else
//            {
//                grdSangInfo.SetBindVarValue("f_io_gubun", "I");
//            }
        }

        private void pbxSearch_PatientSelected(object sender, EventArgs e)
        {
            this.grdSangInfo.Reset();
        }

        private void cbxGeneric_YN_CheckedChanged(object sender, EventArgs e)
        {
            //this.grdOCS1003.QueryLayout(true);
            this.tabOrderGubunChanged();
            childSetImage();
            //this.btnList.PerformClick(FunctionType.Query);
            //this.grdOUT1001.SelectRow(this.grdOUT1001.CurrentRowNumber);
        }  

        private void dpkNaewon_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
                btnList.PerformClick(FunctionType.Close);
        }

        private void pbxSearch_Validated(object sender, EventArgs e)
        {
            if (this.pbxSearch.BunHo.ToString() != "")
                this.grdOUT1001.QueryLayout(false);

            this.dloSelectOCS1003.Reset();
        }

        private void btnDatePlusMinus_Click(object sender, EventArgs e)
        { 
            Control ctl = sender as Control;
            if (ctl.Tag.ToString() == "-")
                this.dpkSetHopeDate.SetDataValue(DateTime.Parse(this.dpkSetHopeDate.GetDataValue()).AddDays(-1));
            else if (ctl.Tag.ToString() == "+")
                this.dpkSetHopeDate.SetDataValue(DateTime.Parse(this.dpkSetHopeDate.GetDataValue()).AddDays(+1));

            this.dpkSetHopeDate.AcceptData();
        }

        private void btnHope_date_Click(object sender, EventArgs e)
        {
            string order_gubun = "";
            XEditGrid grd = this.grdOCS1003;

            if (!IsSelectedOrder())
                return;

            for (int i = 0; i < grd.RowCount; i++)
            {
                order_gubun = this.grdOCS1003.GetItemString(i, "order_gubun").Substring(1, 1);
                // C 内服 D 外用 E 画像検査 F 検体検査 N 生理検査
                //if (this.mCanDoArrList.Contains(grd.GetItemString(i, "input_tab")))
                //{
                    //変更されたROWがすでに選択された状態であればdloSelectOCS1003に変更する
                    if (grd.GetItemString(i, "select") == "Y")
                    {
                        grd.SetItemValue(i, "hope_date", this.dpkSetHopeDate.GetDataValue());
                        grd.SetItemValue(i, "dangil_gumsa_order_yn", "N");
                        grd.SetItemValue(i, "dangil_gumsa_result_yn", "N");

                        for (int kk = 0; kk < this.dloSelectOCS1003.RowCount; kk++)
                        {
                            if (this.dloSelectOCS1003.GetItemString(kk, "pkocs1003") == grd.GetItemString(i, "pkocs1003"))
                                this.dloSelectOCS1003.SetItemValue(kk, "hope_date", this.dpkSetHopeDate.GetDataValue());
                        }
                    }
                //}
            }

            
        }

        private void cboKijunGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboKijunGubun.SelectedIndex == 0)
                this.grdOUT1001.CellInfos[0, 2].HeaderText = Resources.cboKijunGubun_SelectedIndexChanged_MSG1;
            else
                this.grdOUT1001.CellInfos[0, 2].HeaderText = Resources.OCS1003Q09_cboKijunGubun_SelectedIndexChanged_MSG2;

            this.grdOUT1001.InitializeColumns();

            if (this.pbxSearch.BunHo.ToString() != "")
                this.grdOUT1001.QueryLayout(false);
        }

        private void grdOUT1001_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["is_order_yn"].ToString() == "Y")
            {
                e.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private bool IsSelectedOrder()
        {
            XEditGrid grd = this.grdOCS1003;

            int selectedCnt = 0;
            for (int i = 0; i < grd.DisplayRowCount; i++)
            {
                if (grd.GetItemString(i, "select") == "Y")
                {
                    selectedCnt++;
                    break;
                }
            }

            if (selectedCnt == 0)
            {
                XMessageBox.Show(Resources.MSG013_MSG, Resources.MSG009_CAP);
                this.pbxUnderArrow.Visible = true;
                timer_icon.Start();
                return false;
            }

            return true;
        }
        private void btnNalsu_Click(object sender, EventArgs e)
        {
            XEditGrid grd = this.grdOCS1003;

            if (!IsSelectedOrder())
                return;

            for (int i = 0; i < grd.DisplayRowCount; i++)
            {
                if (   grd.GetItemString(i, "order_gubun").Substring(1, 1) == "C"
                    && grd.GetItemString(i, "donbog_yn") != "Y"
                    && grd.GetItemString(i, "select") == "Y"
                   )
                {
                    grd.SetItemValue(i, "nalsu", this.cboNalsu.GetDataValue());

                    for (int kk = 0; kk < this.dloSelectOCS1003.RowCount; kk++)
                    {
                        if (this.dloSelectOCS1003.GetItemString(kk, "pkocs1003") == grd.GetItemString(i, "pkocs1003"))
                            this.dloSelectOCS1003.SetItemValue(kk, "nalsu", this.cboNalsu.GetDataValue());
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbxUnderArrow.Visible == true)
            {
                //System.Threading.Thread.Sleep(5000);
                pbxUnderArrow.Visible = false;
                timer_icon.Stop();
            }
        }

        private void dpkSetHopeDate_TextChanged(object sender, EventArgs e)
        {
            

            if (TypeCheck.IsDateTime(this.dpkSetHopeDate.GetDataValue())
                && TypeCheck.IsDateTime(this.dpkNaewon_date.GetDataValue()))
            {
                DateTime dt_hope_date   = DateTime.Parse(this.dpkSetHopeDate.GetDataValue());
                DateTime dt_naewon_date = DateTime.Parse(this.mNaewon_date);

                if (dt_hope_date < dt_naewon_date)
                {
                    XMessageBox.Show(Resources.MSG012_1_MSG + this.mNaewon_date + "～)", Resources.MSG009_CAP);
                    this.dpkSetHopeDate.SetDataValue(this.mNaewon_date);
                    return;
                }
            }
        }

        #region Connect to cloud service

        /// <summary>
        /// getDataForGrid
        /// </summary>
        /// <returns></returns>
        private OCS1003Q09GridOCS1003AndSangResult getDataForGridOCS1003AndSangInfo()
        {
            OCS1003Q09GridOCS1003AndSangArgs args = new OCS1003Q09GridOCS1003AndSangArgs();

            XEditGrid grd = this.grdOUT1001;
            int currRow = grd.CurrentRowNumber;

            args.Grdocs1003Bunho = grd.GetItemString(currRow, "bunho");
            args.Grdocs1003NaewonDate = grd.GetItemString(currRow, "naewon_date").Replace(" 0:00:00", "");
            args.Grdocs1003Gwa = grd.GetItemString(currRow, "gwa");
            args.Grdocs1003Doctor = grd.GetItemString(currRow, "doctor");
            args.Grdocs1003NaewonType = grd.GetItemString(currRow, "naewon_type");
            args.Grdocs1003InputGubun = this.mInput_gubun;
            args.Grdocs1003TelYn = grd.GetItemString(currRow, "tel_yn");
            args.Grdocs1003InputTab = grd.GetItemString(currRow, "input_tab");
            args.Grdocs1003JubsuNo = grd.GetItemString(currRow, "jubsu_no");
            args.Grdocs1003PkOrder = grd.GetItemString(currRow, "pk_order");
            args.Grdocs1003GenericYn = cbxGeneric_YN.GetDataValue();
            args.Grdocs1003Kijun = cboKijunGubun.SelectedValue.ToString();
            args.Grdocs1003IoGubun = this.mIOgubun;

            args.GrdsangBunho = this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "bunho");
            args.GrdsangNaewonDate = this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "naewon_date");
            args.GrdsangGwa = this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "gwa");
            args.GrdsangDoctor = this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "doctor");
            args.GrdsangNaewonType = this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "naewon_type");
            args.GrdsangJubsuNo = this.grdOUT1001.GetItemString(this.grdOUT1001.CurrentRowNumber, "jubsu_no");
            if (rbtOut.Checked)
            {
                args.GrdsangIoGubun = "O";
            }
            else
            {
                args.GrdsangIoGubun = "I";
            }
            return CloudService.Instance.Submit<OCS1003Q09GridOCS1003AndSangResult, OCS1003Q09GridOCS1003AndSangArgs>(args);
        }

        /// <summary>
        /// grdSangInfo ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        IList<object[]> grdSangInfo_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> listObject = new List<object[]>();
            if (gridOcs1003AndSangData != null && gridOcs1003AndSangData.GridSangInfo != null)
            {
                List<OCS1003Q09GridSangInfo> lstOcs1003Q09GridSangInfo = gridOcs1003AndSangData.GridSangInfo;
                listObject = GridSang_ConvertToListObj(lstOcs1003Q09GridSangInfo);    
            }
            
            return listObject;
        }

        /// <summary>
        /// grdOCS1003 ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        IList<object[]> grdOCS1003_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> listObject = new List<object[]>();
            if (gridOcs1003AndSangData != null && gridOcs1003AndSangData.GridOcs1003Info != null)
            {
                List<OcsoOCS1003Q05OrderListItemInfo> lstDataGridOcs1003Info = gridOcs1003AndSangData.GridOcs1003Info;
                listObject = GridOCS1003_ConvertToListObj(lstDataGridOcs1003Info);
            }
            
            return listObject;
        }

        /// <summary>
        /// ExecuteQueryGrdOCS1003
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        IList<object[]> ExecuteQueryGrdOCS1003(BindVarCollection varCollection)
        {
            IList<object[]> listObject = new List<object[]>();
            OCS1003Q09GridOCS1003Args args = new OCS1003Q09GridOCS1003Args();
            args.Bunho = varCollection["f_bunho"].VarValue;
            args.NaewonDate = varCollection["f_naewon_date"].VarValue;
            args.Gwa = varCollection["f_gwa"].VarValue;
            args.Doctor = varCollection["f_doctor"].VarValue;
            args.NaewonType = varCollection["f_naewon_type"].VarValue;
            args.InputGubun = varCollection["f_input_gubun"].VarValue;
            args.TelYn = varCollection["f_tel_yn"].VarValue;
            args.InputTab = varCollection["f_input_tab"].VarValue;
            args.JubsuNo = varCollection["f_jubsu_no"].VarValue;
            args.PkOrder = varCollection["f_pk_order"].VarValue;
            args.GenericYn = varCollection["f_generic_yn"].VarValue;
            args.Kijun = varCollection["f_kijun"].VarValue;
            args.IoGubun = this.mIOgubun;
            OCS1003Q09GridOCS1003Result ocs1003Result =
                CloudService.Instance.Submit<OCS1003Q09GridOCS1003Result, OCS1003Q09GridOCS1003Args>(args);
            if (ocs1003Result == null)
            {
                return listObject;
            }
            return GridOCS1003_ConvertToListObj(ocs1003Result.RidOcs1003Info);
        }

        /// <summary>
        /// grdOUT1001: get data form cloud service
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        IList<object[]> grdOUT1001_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> listObject = new List<object[]>();
            OCS1003Q09GridOUT1001Args args = new OCS1003Q09GridOUT1001Args();
            args.Gwa = varCollection["f_gwa"].VarValue;
            args.Bunho = varCollection["f_bunho"].VarValue;
            args.InputGubun = varCollection["f_input_gubun"].VarValue;
            args.TelYn = varCollection["f_tel_yn"].VarValue;
            args.IoGubun = varCollection["f_io_gubun"].VarValue;
            args.InputTab = varCollection["f_input_tab"].VarValue;
            args.Kijun = varCollection["f_kijun"].VarValue;
            args.SelectedInputTab = varCollection["f_selected_input_tab"].VarValue;
            args.NaewonDate = varCollection["f_naewon_date"].VarValue;

            OCS1003Q09GridOUT1001Result result =
                CloudService.Instance.Submit<OCS1003Q09GridOUT1001Result, OCS1003Q09GridOUT1001Args>(args);
            if (result != null)
            {
                List<OCS1003Q09GridOUT1001Info> lstGridOut1001Info = result.GridOut1001Info;
                listObject = GridOUT1001_ConvertToListObj(lstGridOut1001Info);
            }
            return listObject;
        }
        
        /// <summary>
        /// dloCheckLayout_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> dloCheckLayout_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            OCS1003DloCheckLayoutArgs args = new OCS1003DloCheckLayoutArgs();
            args.Bunho = varCollection["f_bunho"].VarValue;
            args.NaewonDate = varCollection["f_naewon_date"].VarValue;
            args.Gwa = varCollection["f_gwa"].VarValue;
            args.InputGubun = varCollection["f_input_gubun"].VarValue;
            args.TelYn = varCollection["tel_yn"].VarValue;

            OCS1003DloCheckLayoutResult result =
                CloudService.Instance.Submit<OCS1003DloCheckLayoutResult, OCS1003DloCheckLayoutArgs>(args);
            if (result != null)
            {
                lstObject = GridOUT1001_ConvertToListObj(result.Gridout1001Info);
            }
            return lstObject;
        }

        /// <summary>
        /// layoutCombo load data
        /// </summary>
        /// <param name="bindVarCollection"></param>
        /// <returns></returns>
        private IList<object[]> layoutCombo_ExecuteQuery(BindVarCollection bindVarCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            ComboJusaArgs comboJusaArgs = new ComboJusaArgs();

            // Cached by HospCode
            //string keyCache = string.Concat(UserInfo.HospCode, Constants.CacheKeyCbo.CACHE_OCS_LIBS_JUSA_CBO);
            ComboResult comboResult = CacheService.Instance.Get<ComboJusaArgs, ComboResult>(comboJusaArgs, delegate(ComboResult result)
                    {
                        return result != null && result.ExecutionStatus == ExecutionStatus.Success &&
                               result.ComboItem != null && result.ComboItem.Count > 0;
                    });
            if (comboResult != null)
            {
                List<ComboListItemInfo> lsListItemInfo = comboResult.ComboItem;
                if (lsListItemInfo != null && lsListItemInfo.Count > 0)
                {
                    foreach(ComboListItemInfo itemInfo in lsListItemInfo)
                    {
                        lstObject.Add(new object[]
                        {
                            itemInfo.Code,
                            itemInfo.CodeName
                        });
                    }
                }
            }
            return lstObject;
        }
        #endregion

        #region Convert List<OCS1003Q09GridOCS1003Info> to List<object[]>
        /// <summary>
        /// GridOCS1003_ConvertToListObj
        /// </summary>
        /// <param name="lstOcs1003Info"></param>
        /// <returns></returns>
        private IList<object[]> GridOCS1003_ConvertToListObj(List<OcsoOCS1003Q05OrderListItemInfo> lstDataForOcs1003)
        {
            IList<object[]> lstObjs = new List<object[]>();
            if (lstDataForOcs1003 != null && lstDataForOcs1003.Count > 0)
            {
                foreach (OcsoOCS1003Q05OrderListItemInfo ocs1003Info in lstDataForOcs1003)
                {
                    lstObjs.Add(new object[]
                    {
                        ocs1003Info.InputGubunName,
                        ocs1003Info.GroupSer,
                        ocs1003Info.OrderGubunName,
                        ocs1003Info.HangmogCode,
                        ocs1003Info.HangmogName,
                        ocs1003Info.SpecimenCode,
                        ocs1003Info.SpecimenName,
                        ocs1003Info.Suryang,
                        ocs1003Info.OrdDanui,
                        ocs1003Info.OrdDanuiName,
                        ocs1003Info.DvTime,
                        ocs1003Info.Dv,
                        ocs1003Info.Nalsu,
                        ocs1003Info.Jusa,
                        ocs1003Info.JusaName,
                        ocs1003Info.BogyongCode,
                        ocs1003Info.BogyongName,
                        ocs1003Info.JusaSpdGubun,
                        ocs1003Info.HubalChangeYn,
                        ocs1003Info.Pharmacy,
                        ocs1003Info.DrgPackYn,
                        ocs1003Info.PowderYn,
                        ocs1003Info.WonyoiOrderYn,
                        ocs1003Info.DangilGumsaOrderYn,
                        ocs1003Info.DangilGumsaResultYn,
                        ocs1003Info.Emergency,
                        ocs1003Info.Pay,
                        ocs1003Info.AntiCancerYn,
                        ocs1003Info.Muhyo,
                        ocs1003Info.PortableYn,
                        ocs1003Info.OcsFlag,
                        ocs1003Info.OrderGubun,
                        ocs1003Info.InputTab,
                        ocs1003Info.InputGubun,
                        ocs1003Info.AfterActYn,
                        ocs1003Info.JundalTable,
                        ocs1003Info.JundalPart,
                        ocs1003Info.MovePart,
                        ocs1003Info.Bunho,
                        ocs1003Info.OrderDate,
                        ocs1003Info.Gwa,
                        ocs1003Info.Doctor,
                        ocs1003Info.NaewonType,
                        ocs1003Info.PkOrder,
                        ocs1003Info.Seq,
                        ocs1003Info.Pkocs1003,
                        ocs1003Info.SubSusul,
                        ocs1003Info.SutakYn,
                        ocs1003Info.Amt,
                        ocs1003Info.Dv1,
                        ocs1003Info.Dv2,
                        ocs1003Info.Dv3,
                        ocs1003Info.Dv4,
                        ocs1003Info.HopeDate,
                        ocs1003Info.OrderRemark,
                        ocs1003Info.MixGroup,
                        ocs1003Info.HomeCareYn,
                        ocs1003Info.RegularYn,
                        ocs1003Info.GongbiCode,
                        ocs1003Info.GongbiName,
                        ocs1003Info.DonbokYn,
                        ocs1003Info.DvName,
                        ocs1003Info.SlipCode,
                        ocs1003Info.GroupYn,
                        ocs1003Info.SgCode,
                        ocs1003Info.OrderGubunBas,
                        ocs1003Info.InputControl,
                        ocs1003Info.SugaYn,
                        ocs1003Info.EmergencyCheck,
                        ocs1003Info.LimitSuryang,
                        ocs1003Info.SpecimenYn,
                        ocs1003Info.JaeryoYn,
                        ocs1003Info.OrdDanuiCheck,
                        ocs1003Info.OrdDanuiBas,
                        ocs1003Info.JundalTableOut,
                        ocs1003Info.JundalPartOut,
                        ocs1003Info.MovePartOut,
                        ocs1003Info.JundalTableInp,
                        ocs1003Info.JundalPartInp,
                        ocs1003Info.MovePartInp,
                        ocs1003Info.BulyongCheck,
                        ocs1003Info.WonyoiOrderCrYn,
                        ocs1003Info.DefaultWonyoiOrderYn,
                        ocs1003Info.NdayYn,
                        ocs1003Info.MuhyoYn,
                        ocs1003Info.TelYn,
                        ocs1003Info.DrgInfo,
                        ocs1003Info.DrgBunryu,
                        ocs1003Info.ChildYn,
                        ocs1003Info.BomSourceKey,
                        ocs1003Info.BomOccurYn,
                        ocs1003Info.OrgKey,
                        ocs1003Info.ParentKey,
                        ocs1003Info.BunCode,
                        ocs1003Info.ContKey,
                        ocs1003Info.Fkout1001,
                        ocs1003Info.WonnaeDrgYn,
                        ocs1003Info.DcYn,
                        ocs1003Info.ResultDate,
                        ocs1003Info.ConfirmCheck,
                        ocs1003Info.SunabCheck,
                        ocs1003Info.Dv5,
                        ocs1003Info.Dv6,
                        ocs1003Info.Dv7,
                        ocs1003Info.Dv8,
                        ocs1003Info.GeneralDispYn,
                        ocs1003Info.GenericName,
                        ocs1003Info.State,
                        ocs1003Info.BogyongCodeSub,
                        ocs1003Info.BogyongNameSub,
                        ocs1003Info.OriHopeDate,
                        ocs1003Info.IoYn,
                        ocs1003Info.BroughtDrgYn,
                        ocs1003Info.TrialFlg,
                        ocs1003Info.YjCode
                    });
                }
            }
            return lstObjs;
        }
        #endregion

        #region convert from List<OCS1003Q09GridSangInfo> to List<object[]>
        /// <summary>
        /// GridSang_ConvertToListObj
        /// </summary>
        /// <param name="lstGridSangInfo"></param>
        /// <returns></returns>
        private IList<object[]> GridSang_ConvertToListObj(List<OCS1003Q09GridSangInfo> lstGridSangInfo)
        {
            IList<object[]> lstObjs = new List<object[]>();
            if (lstGridSangInfo != null && lstGridSangInfo.Count > 0)
            {
                foreach (OCS1003Q09GridSangInfo gridSangInfo in lstGridSangInfo)
                {
                    lstObjs.Add(new object[]
                    {
                        gridSangInfo.JuSgYn,
                        gridSangInfo.SgCode,
                        gridSangInfo.Gwne,
                        gridSangInfo.Ser,
                        gridSangInfo.DisSgNe,
                        gridSangInfo.SgSttDe,
                        gridSangInfo.SgEndDe,
                        gridSangInfo.SgEndSu,
                        gridSangInfo.SgEndSuNe,
                        gridSangInfo.Bunho,
                        gridSangInfo.NwonDe,
                        gridSangInfo.Gwa,
                        gridSangInfo.Doctor,
                        gridSangInfo.NwonType,
                        gridSangInfo.JubsuNo,
                        gridSangInfo.PkOrder,
                        gridSangInfo.SgNe,
                        gridSangInfo.PreModifier1,
                        gridSangInfo.PreModifier2,
                        gridSangInfo.PreModifier3,
                        gridSangInfo.PreModifier4,
                        gridSangInfo.PreModifier5,
                        gridSangInfo.PreModifier6,
                        gridSangInfo.PreModifier7,
                        gridSangInfo.PreModifier8,
                        gridSangInfo.PreModifier9,
                        gridSangInfo.PreModifier10,
                        gridSangInfo.PreModifierNe,
                        gridSangInfo.PostModifier1,
                        gridSangInfo.PostModifier2,
                        gridSangInfo.PostModifier3,
                        gridSangInfo.PostModifier4,
                        gridSangInfo.PostModifier5,
                        gridSangInfo.PostModifier6,
                        gridSangInfo.PostModifier7,
                        gridSangInfo.PostModifier8,
                        gridSangInfo.PostModifier9,
                        gridSangInfo.PostModifier10,
                        gridSangInfo.PostModifierNe,
                        gridSangInfo.SgJindDe,
                        gridSangInfo.OrderByKey,
                    });
                }
            }
            return lstObjs;
        }
        #endregion

        #region convert from List<OCS1003Q09GridOUT1001Info> to List<object[]>
        /// <summary>
        /// convert from List<OCS1003Q09GridOUT1001Info> to List<object[]>
        /// </summary>
        /// <param name="lstGridOut1001Info"></param>
        /// <returns></returns>
        private IList<object[]> GridOUT1001_ConvertToListObj(List<OCS1003Q09GridOUT1001Info> lstGridOut1001Info)
        {
            IList<object[]> listObject = new List<object[]>();
            if (lstGridOut1001Info != null && lstGridOut1001Info.Count > 0)
            {
                foreach (OCS1003Q09GridOUT1001Info gridOut1001Info in lstGridOut1001Info)
                {
                    listObject.Add(new object[]
                    {
                        gridOut1001Info.OrderDate,
                        gridOut1001Info.Gwa,
                        gridOut1001Info.GwaName,
                        gridOut1001Info.DoctorName,
                        gridOut1001Info.Nalsu,
                        gridOut1001Info.Bunho,
                        gridOut1001Info.Doctor,
                        gridOut1001Info.GubunName,
                        gridOut1001Info.ChojaeName,
                        gridOut1001Info.NaewonType,
                        gridOut1001Info.JubsuNo,
                        gridOut1001Info.PkOrder,
                        gridOut1001Info.InputGubun,
                        gridOut1001Info.TelYn,
                        gridOut1001Info.ToiwonDrg,
                        gridOut1001Info.InputTab,
                        gridOut1001Info.IoGubun,
                        gridOut1001Info.OcsCnt,
                    });
                }
            }
            return listObject;
        }
        #endregion

        #region LoadAllCombos
        /// <summary>
        /// LoadAllCombos
        /// </summary>
        private void LoadAllCombos()
        {
            // Connect cloud imp LoadComboDataSource function
            OCS1003Q09LoadComboDataSourceArgs args = new OCS1003Q09LoadComboDataSourceArgs();
            args.ForColPay = new ComboDataSourceInfo("pay", null, null, null);
            args.ForPortableYn = new ComboDataSourceInfo("portable_yn", null, null, null);
            args.ForJusaSpdGubun = new ComboDataSourceInfo("jusa_spd_gubun", null, null, null);
            args.ForNalsu = new ComboDataSourceInfo("nalsu", null, null, null);
            args.ForSuryang = new ComboDataSourceInfo("suryang", null, null, null);
            args.ForDv = new ComboDataSourceInfo("dv", null, null, null);

            //string cacheKey = string.Concat(UserInfo.HospCode, Constants.CacheKeyCbo.CACHE_CBO_DOCTOR_CODE_PORTABLEYN);
            _allCboResult = CacheService.Instance.Get<OCS1003Q09LoadComboDataSourceArgs, OCS1003Q09LoadComboDataSourceResult>(args, delegate(OCS1003Q09LoadComboDataSourceResult sourceResult)
                {
                    return sourceResult != null && sourceResult.ExecutionStatus == ExecutionStatus.Success;
                });
        }
        #endregion
    }
}