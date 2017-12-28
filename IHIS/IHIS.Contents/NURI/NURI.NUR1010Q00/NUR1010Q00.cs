#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.NURI
{
    /// <summary>
    /// NUR1010Q00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class NUR1010Q00 : IHIS.Framework.XScreen
    {
        #region 배치 관련 변수
        /*
		private int HOCNT_PER_LINE = 6;    //한 라인의 호실수
		int BEDCNT_PER_HOSIL = 6;  //한 호실의 병상수
		const int LEFT_MARGIN = 5;      //병실배치 시작 left Margin
		const int TOP_MARGIN = 5;       //병실배치 시작 Top Margin
		const int HOSILBOX_GAP = 10;	 //호실 사이의 간격	
		const int HOSILBOX_TOP_MARGIN = 30;   //병상배치시 호실에서 시작 Top Margin
		const int HOSILBOX_BOTTOM_MARGIN = 4; //호실Box의 아래 Margin
		const int HOSILBOX_LEFT_MARGIN = 6;   //병상배치시에 호실Box시작위치에서 병상 시작위치 Margin
		const int BEDBOX_FULL_WIDTH = 102;    //병상의 전체기본너비so	
		const int BEDBOX_SMALL_WIDTH = 90;    //공병상의 기본너비
		const int BEDBOX_HEIGHT = 36;    //병상의 기본높이
		const int BEDBOX_VERT_GAP = 1;   //한 호실내에서 병상간 수직간격 
		*/

        private int HOCNT_PER_LINE = 8;    //한 라인의 호실수
        const int MAXBED_PER_HOSIL = 6;    // 한 호실의 최대 병상수
        //int BEDCNT_PER_HOSIL = 2;          //한 호실의 병상수
        const int LEFT_MARGIN = 5;      //병실배치 시작 left Margin
        const int TOP_MARGIN = 5;       //병실배치 시작 Top Margin
        const int HOSILBOX_GAP = 20;	 //호실 사이의 간격	 20
        const int HOSILBOX_TOP_MARGIN = 25;   //병상배치시 호실에서 시작 Top Margin 25
        const int HOSILBOX_BOTTOM_MARGIN = 4; //호실Box의 아래 Margin
        const int HOSILBOX_LEFT_MARGIN = 6;   //병상배치시에 호실Box시작위치에서 병상 시작위치 Margin
        const int BEDBOX_FULL_WIDTH = 130;    //병상의 전체기본너비
        const int BEDBOX_SMALL_WIDTH = 118;    //공병상의 기본너비
        const int BEDBOX_HEIGHT = 54;    //병상의 기본높이
        const int BEDBOX_VERT_GAP = 1;   //한 호실내에서 병상간 수직간격 
        
        #endregion

        #region Fields
        private Hashtable hoSilBoxList = new Hashtable();  //HoSilBox Control List 관리
        private Hashtable bedBoxList = new Hashtable();    //BedBox Control List관리
        private BedBox selectedBedBox = null; //현재 선택된 BedBox
        private BedBox ForeBedBox = null; //현재 선택된 BedBox를 셋팅
        #endregion

        #region 전실,전Bed 변경 관련 Field, 속성
        //이동하는 환자의 Key, 병실,병상 
        private string mMovePkInp1001 = "";
        private string mMoveHoCode = "";
        private string mMoveHoBed = "";
        //속성은 전실,전Bed시 Input으로 사용함
        [DataBindable]
        public string MovePKInp1001
        {
            get { return mMovePkInp1001; }
        }
        [DataBindable]
        public string MoveHoCode
        {
            get { return mMoveHoCode; }
        }
        [DataBindable]
        public string MoveHoBed
        {
            get { return mMoveHoBed; }
        }
        #endregion

        #region 팝업메뉴 코드 관리
        IHIS.X.Magic.Menus.PopupMenu popMenu = new IHIS.X.Magic.Menus.PopupMenu();	//팝업메뉴
        private ArrayList jobCodeList = new ArrayList();
        private ArrayList bedStatusList = new ArrayList();

        private class JobItem
        {
            public int Code = 0;
            public string CodeName = "";
            public string BedNumber = "";
            public string HoCode = "";
            public JobItem(int code, string codeName)
            {
                this.Code = code;
                this.CodeName = codeName;

            }
            public JobItem(int code, string codeName, string hoCode, string bedNumber)
            {
                this.Code = code;
                this.CodeName = codeName;
                this.BedNumber = bedNumber;
                this.HoCode = hoCode;
            }
        }
        #endregion

        #region 자동생성
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label26;
        private IHIS.Framework.XImageButton btnHelp;
        private IHIS.Framework.XBuseoCombo cboHoDong;
        private IHIS.Framework.MultiLayout layHosilList;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label27;
        private IHIS.Framework.MultiLayout layPatientList;
        private System.Windows.Forms.ImageList jobImageList;
        private IHIS.Framework.XButton btnBedsore;
        private IHIS.Framework.XButton btnGanhodo;
        private IHIS.Framework.XButton btnDamdang_Nurse;
        private IHIS.Framework.XTextBox txtCmmt;
        private IHIS.Framework.XDisplayBox dbxBedEtcTotal;
        private IHIS.Framework.XDisplayBox dbxBedEtcNoUse;
        private IHIS.Framework.XDisplayBox dbxBedEtcUse;
        private IHIS.Framework.XDisplayBox dbxBedSpecUseTotal;
        private IHIS.Framework.XDisplayBox dbxBedSpecUseNoUse;
        private IHIS.Framework.XDisplayBox dbxBedSpecUse;
        private IHIS.Framework.XDisplayBox dbxBedWomanTotal;
        private IHIS.Framework.XDisplayBox dbxBedWomanNoUse;
        private IHIS.Framework.XDisplayBox dbxBedWomanUse;
        private IHIS.Framework.XDisplayBox dbxBedManTotal;
        private IHIS.Framework.XDisplayBox dbxBedManNoUse;
        private IHIS.Framework.XDisplayBox dbxBedManUse;
        private IHIS.Framework.XDisplayBox dbxBedNoUse;
        private IHIS.Framework.XDisplayBox dbxBedUse;
        private IHIS.Framework.XDisplayBox dbxBedTotal;
        private IHIS.Framework.XDisplayBox dbxOutWeek;
        private IHIS.Framework.XDisplayBox dbxTaewonWeek;
        private IHIS.Framework.XDisplayBox dbxInWeek;
        private IHIS.Framework.XDisplayBox dbxIpwonWeek;
        private IHIS.Framework.XDisplayBox dbxOutNext;
        private IHIS.Framework.XDisplayBox dbxTaewonNext;
        private IHIS.Framework.XDisplayBox dbxInNext;
        private IHIS.Framework.XDisplayBox dbxIpwonNext;
        private IHIS.Framework.XDisplayBox dbxOutToday;
        private IHIS.Framework.XDisplayBox dbxTaewonToday;
        private IHIS.Framework.XDisplayBox dbxInToday;
        private IHIS.Framework.XDisplayBox dbxIpwonToday;
        private IHIS.Framework.XDisplayBox dbxIpwonWoman;
        private IHIS.Framework.XDisplayBox dbxIpwonMan;
        private IHIS.Framework.XDisplayBox dbxIpwonTotal;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XButton btnPlan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label28;
        private IHIS.Framework.XButton btnJunipConfirm;
        private IHIS.Framework.XPictureBox pbxJunip;
        private IHIS.Framework.XDisplayBox dbxDansongCnt;
        private IHIS.Framework.XDisplayBox dbxHosongCnt;
        private IHIS.Framework.XDisplayBox dbxDokboCnt;
        private IHIS.Framework.XComboBox cboDoctorList;
        private IHIS.Framework.XBuseoCombo cboGwa;
        private IHIS.Framework.XButton btnOCS2003U02Open;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private IHIS.Framework.XButton btnQuery;
        private IHIS.Framework.XButton btnSetHo_sex;
        private IHIS.Framework.MultiLayout layBedList;
        private IHIS.Framework.XButton btnVisible;
        private SingleLayout layConfirmData;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayoutItem singleLayoutItem5;
        private SingleLayoutItem singleLayoutItem6;
        private SingleLayoutItem singleLayoutItem7;
        private SingleLayoutItem singleLayoutItem8;
        private SingleLayoutItem singleLayoutItem9;
        private SingleLayoutItem singleLayoutItem10;
        private SingleLayoutItem singleLayoutItem11;
        private SingleLayoutItem singleLayoutItem12;
        private SingleLayoutItem singleLayoutItem13;
        private SingleLayoutItem singleLayoutItem14;
        private SingleLayoutItem singleLayoutItem15;
        private SingleLayoutItem singleLayoutItem16;
        private SingleLayoutItem singleLayoutItem17;
        private SingleLayout layCommon;
        private SingleLayoutItem singleLayoutItem18;
        private SingleLayoutItem singleLayoutItem19;
        private XButton ibtnGanhoReser;
        private XButton ibtnChangeGwa;
        private SingleLayoutItem singleLayoutItem21;
        private SingleLayoutItem singleLayoutItem22;
        private XButton btnReadOrder;
        private Timer timer;
        private SingleLayout layChekNonConfirmOrder;
        private SingleLayoutItem singleLayoutItem23;
        private XCheckBox cbxTimer;
        private XButton btnSang;
        private MultiLayoutItem multiLayoutItem46;
        private MultiLayoutItem multiLayoutItem47;
        private MultiLayoutItem multiLayoutItem49;
        private MultiLayoutItem multiLayoutItem50;
        private MultiLayoutItem multiLayoutItem51;
        private MultiLayoutItem multiLayoutItem52;
        private MultiLayoutItem multiLayoutItem53;
        private XButton btnWorkSheet;
        private Label label3;
        private XButton btnVital;
        private SingleLayoutItem singleLayoutItem24;
        private SingleLayoutItem singleLayoutItem25;
        private XEditGrid grdGwaCount;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private Panel pnlLeft;
        private PictureBox pbxHelp;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XGridHeader xGridHeader1;
        private XButton btnADLWork;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem54;
        private MultiLayoutItem multiLayoutItem55;
        private MultiLayoutItem multiLayoutItem56;
        private MultiLayoutItem multiLayoutItem57;
        private MultiLayoutItem multiLayoutItem58;
        private MultiLayoutItem multiLayoutItem59;
        private MultiLayoutItem multiLayoutItem60;
        private MultiLayoutItem multiLayoutItem61;
        private MultiLayoutItem multiLayoutItem62;
        private MultiLayoutItem multiLayoutItem63;
        private MultiLayoutItem multiLayoutItem64;
        private MultiLayoutItem multiLayoutItem65;
        private MultiLayoutItem multiLayoutItem66;
        private MultiLayoutItem multiLayoutItem67;
        private MultiLayoutItem multiLayoutItem68;
        private MultiLayoutItem multiLayoutItem69;
        private MultiLayoutItem multiLayoutItem70;
        private MultiLayoutItem multiLayoutItem71;
        private MultiLayoutItem multiLayoutItem72;
        private MultiLayoutItem multiLayoutItem73;
        private MultiLayoutItem multiLayoutItem74;
        private MultiLayoutItem multiLayoutItem75;
        private MultiLayoutItem multiLayoutItem76;
        private MultiLayoutItem multiLayoutItem77;
        private MultiLayoutItem multiLayoutItem78;
        private MultiLayoutItem multiLayoutItem79;
        private MultiLayoutItem multiLayoutItem80;
        private MultiLayoutItem multiLayoutItem82;
        private MultiLayoutItem multiLayoutItem83;
        private MultiLayoutItem multiLayoutItem84;
        private MultiLayoutItem multiLayoutItem86;
        private MultiLayoutItem multiLayoutItem87;
        private MultiLayoutItem multiLayoutItem90;
        private MultiLayoutItem multiLayoutItem92;
        private MultiLayoutItem multiLayoutItem93;
        private MultiLayoutItem multiLayoutItem94;
        private MultiLayoutItem multiLayoutItem95;
        private MultiLayoutItem multiLayoutItem96;
        private MultiLayoutItem multiLayoutItem97;
        private MultiLayoutItem multiLayoutItem98;
        private MultiLayoutItem multiLayoutItem99;
        private MultiLayoutItem multiLayoutItem108;
        private MultiLayoutItem multiLayoutItem109;
        private MultiLayoutItem multiLayoutItem110;
        private MultiLayoutItem multiLayoutItem111;
        private MultiLayoutItem multiLayoutItem112;
        private MultiLayoutItem multiLayoutItem116;
        private MultiLayoutItem multiLayoutItem117;
        private MultiLayoutItem multiLayoutItem118;
        private MultiLayoutItem multiLayoutItem121;
        private MultiLayoutItem multiLayoutItem125;
        private System.ComponentModel.IContainer components;
        #endregion

        #region 생성자
        public NUR1010Q00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            jobCodeList.Add(new JobItem(0, "アナムネーゼ"));
            jobCodeList.Add(new JobItem(1, "褥瘡管理-Ｒ"));
            //jobCodeList.Add(new JobItem(2, "看護度管理"));
            //jobCodeList.Add(new JobItem(3, "日常生活自立度管理"));
            jobCodeList.Add(new JobItem(2, "担当看護師管理"));
            jobCodeList.Add(new JobItem(3, "温度板"));
            jobCodeList.Add(new JobItem(4, "転科転室"));
            //jobCodeList.Add(new JobItem(5, "注射実施"));
            jobCodeList.Add(new JobItem(5, "投薬記録"));
            jobCodeList.Add(new JobItem(6, "外出 ・外泊"));
            //jobCodeList.Add(new JobItem(7, "ICU患者管理"));
            //jobCodeList.Add(new JobItem(8, "助産記録登録"));
            jobCodeList.Add(new JobItem(9, "看護経過記録"));
            jobCodeList.Add(new JobItem(10, "看護計画"));
            jobCodeList.Add(new JobItem(11, "治療計画"));
            jobCodeList.Add(new JobItem(12, "食事箋"));
            jobCodeList.Add(new JobItem(13, "退院予告"));
            //jobCodeList.Add(new JobItem(14, "オーダ実施"));
            //jobCodeList.Add(new JobItem(15, "看護確認"));
            //jobCodeList.Add(new JobItem(16, "病棟採血"));
            //jobCodeList.Add(new JobItem(26, "病理検査ラベル出力"));
            //jobCodeList.Add(new JobItem(19, "諸証明出力"));
            //jobCodeList.Add(new JobItem(20, "患者案内書"));
            //jobCodeList.Add(new JobItem(21, "カルテ"));
            //jobCodeList.Add(new JobItem(22, "様式 1 生成[旧]"));
            //jobCodeList.Add(new JobItem(27, "様式 1 生成[新]"));
            //jobCodeList.Add(new JobItem(27, "様式 1 生成"));
            jobCodeList.Add(new JobItem(23, "検査予約"));
            //jobCodeList.Add(new JobItem(24, "患者情報チェックリスト"));
            jobCodeList.Add(new JobItem(25, "褥瘡患者マットレス"));
            jobCodeList.Add(new JobItem(28, "EMR"));

            //병동환자리스트 Docking화면
            if (XScreen.FindScreen("NURI", "NUR1001D00") == null)
            {
                //XScreen.OpenScreen(this, "NURI", "NUR1001D00", ScreenOpenStyle.Docking);
                XScreen.OpenScreen(this, "NURI1001D00", ScreenOpenStyle.Docking);
            }
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
        #endregion

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1010Q00));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnADLWork = new IHIS.Framework.XButton();
            this.btnVital = new IHIS.Framework.XButton();
            this.jobImageList = new System.Windows.Forms.ImageList(this.components);
            this.btnWorkSheet = new IHIS.Framework.XButton();
            this.ibtnChangeGwa = new IHIS.Framework.XButton();
            this.ibtnGanhoReser = new IHIS.Framework.XButton();
            this.btnSang = new IHIS.Framework.XButton();
            this.btnGanhodo = new IHIS.Framework.XButton();
            this.btnReadOrder = new IHIS.Framework.XButton();
            this.btnSetHo_sex = new IHIS.Framework.XButton();
            this.btnOCS2003U02Open = new IHIS.Framework.XButton();
            this.cboGwa = new IHIS.Framework.XBuseoCombo();
            this.btnPlan = new IHIS.Framework.XButton();
            this.btnDamdang_Nurse = new IHIS.Framework.XButton();
            this.btnBedsore = new IHIS.Framework.XButton();
            this.btnHelp = new IHIS.Framework.XImageButton();
            this.cboHoDong = new IHIS.Framework.XBuseoCombo();
            this.label26 = new System.Windows.Forms.Label();
            this.pbxJunip = new IHIS.Framework.XPictureBox();
            this.cboDoctorList = new IHIS.Framework.XComboBox();
            this.btnQuery = new IHIS.Framework.XButton();
            this.btnVisible = new IHIS.Framework.XButton();
            this.btnJunipConfirm = new IHIS.Framework.XButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grdGwaCount = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxTimer = new IHIS.Framework.XCheckBox();
            this.dbxDansongCnt = new IHIS.Framework.XDisplayBox();
            this.dbxHosongCnt = new IHIS.Framework.XDisplayBox();
            this.dbxDokboCnt = new IHIS.Framework.XDisplayBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.txtCmmt = new IHIS.Framework.XTextBox();
            this.dbxBedEtcTotal = new IHIS.Framework.XDisplayBox();
            this.dbxBedEtcNoUse = new IHIS.Framework.XDisplayBox();
            this.dbxBedEtcUse = new IHIS.Framework.XDisplayBox();
            this.dbxBedSpecUseTotal = new IHIS.Framework.XDisplayBox();
            this.dbxBedSpecUseNoUse = new IHIS.Framework.XDisplayBox();
            this.dbxBedSpecUse = new IHIS.Framework.XDisplayBox();
            this.dbxBedWomanTotal = new IHIS.Framework.XDisplayBox();
            this.dbxBedWomanNoUse = new IHIS.Framework.XDisplayBox();
            this.dbxBedWomanUse = new IHIS.Framework.XDisplayBox();
            this.dbxBedManTotal = new IHIS.Framework.XDisplayBox();
            this.dbxBedManNoUse = new IHIS.Framework.XDisplayBox();
            this.dbxBedManUse = new IHIS.Framework.XDisplayBox();
            this.dbxBedNoUse = new IHIS.Framework.XDisplayBox();
            this.dbxBedUse = new IHIS.Framework.XDisplayBox();
            this.dbxBedTotal = new IHIS.Framework.XDisplayBox();
            this.dbxOutWeek = new IHIS.Framework.XDisplayBox();
            this.dbxTaewonWeek = new IHIS.Framework.XDisplayBox();
            this.dbxInWeek = new IHIS.Framework.XDisplayBox();
            this.dbxIpwonWeek = new IHIS.Framework.XDisplayBox();
            this.dbxOutNext = new IHIS.Framework.XDisplayBox();
            this.dbxTaewonNext = new IHIS.Framework.XDisplayBox();
            this.dbxInNext = new IHIS.Framework.XDisplayBox();
            this.dbxIpwonNext = new IHIS.Framework.XDisplayBox();
            this.dbxOutToday = new IHIS.Framework.XDisplayBox();
            this.dbxTaewonToday = new IHIS.Framework.XDisplayBox();
            this.dbxInToday = new IHIS.Framework.XDisplayBox();
            this.dbxIpwonToday = new IHIS.Framework.XDisplayBox();
            this.dbxIpwonWoman = new IHIS.Framework.XDisplayBox();
            this.dbxIpwonMan = new IHIS.Framework.XDisplayBox();
            this.dbxIpwonTotal = new IHIS.Framework.XDisplayBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.layHosilList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem52 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
            this.layPatientList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem57 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem58 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem59 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem60 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem61 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem62 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem63 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem64 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem65 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem66 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem67 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem68 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem69 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem70 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem71 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem72 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem73 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem74 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem75 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem76 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem77 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem78 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem79 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem80 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem82 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem83 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem84 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem86 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem87 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem90 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem92 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem93 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem94 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem95 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem96 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem97 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem98 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem99 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem108 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem109 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem110 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem111 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem112 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem116 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem117 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem118 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem121 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem125 = new IHIS.Framework.MultiLayoutItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pbxHelp = new System.Windows.Forms.PictureBox();
            this.layBedList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.layConfirmData = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem7 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem8 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem9 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem10 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem11 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem12 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem13 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem14 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem15 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem16 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem17 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem21 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem22 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem24 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem25 = new IHIS.Framework.SingleLayoutItem();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem18 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem19 = new IHIS.Framework.SingleLayoutItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.layChekNonConfirmOrder = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem23 = new IHIS.Framework.SingleLayoutItem();
            this.pnlTop.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGwa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxJunip)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGwaCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layHosilList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPatientList)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBedList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            this.ImageList.Images.SetKeyName(5, "help_okada.jpg");
            this.ImageList.Images.SetKeyName(6, "");
            this.ImageList.Images.SetKeyName(7, "32_3.ico");
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.panel3);
            this.pnlTop.Controls.Add(this.btnReadOrder);
            this.pnlTop.Controls.Add(this.btnSetHo_sex);
            this.pnlTop.Controls.Add(this.btnOCS2003U02Open);
            this.pnlTop.Controls.Add(this.cboGwa);
            this.pnlTop.Controls.Add(this.btnPlan);
            this.pnlTop.Controls.Add(this.btnDamdang_Nurse);
            this.pnlTop.Controls.Add(this.btnBedsore);
            this.pnlTop.Controls.Add(this.btnHelp);
            this.pnlTop.Controls.Add(this.cboHoDong);
            this.pnlTop.Controls.Add(this.label26);
            this.pnlTop.Controls.Add(this.pbxJunip);
            this.pnlTop.Controls.Add(this.cboDoctorList);
            this.pnlTop.Controls.Add(this.btnQuery);
            this.pnlTop.Controls.Add(this.btnVisible);
            this.pnlTop.Controls.Add(this.btnJunipConfirm);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.pnlTop.Size = new System.Drawing.Size(1211, 58);
            this.pnlTop.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnADLWork);
            this.panel3.Controls.Add(this.btnVital);
            this.panel3.Controls.Add(this.btnWorkSheet);
            this.panel3.Controls.Add(this.ibtnChangeGwa);
            this.panel3.Controls.Add(this.ibtnGanhoReser);
            this.panel3.Controls.Add(this.btnSang);
            this.panel3.Controls.Add(this.btnGanhodo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(623, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(583, 58);
            this.panel3.TabIndex = 97;
            // 
            // btnADLWork
            // 
            this.btnADLWork.Image = ((System.Drawing.Image)(resources.GetObject("btnADLWork.Image")));
            this.btnADLWork.Location = new System.Drawing.Point(3, 1);
            this.btnADLWork.Name = "btnADLWork";
            this.btnADLWork.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnADLWork.Size = new System.Drawing.Size(82, 58);
            this.btnADLWork.TabIndex = 198;
            this.btnADLWork.Text = "ADL";
            this.btnADLWork.Visible = false;
            this.btnADLWork.Click += new System.EventHandler(this.btnADLWork_Click);
            // 
            // btnVital
            // 
            this.btnVital.Image = ((System.Drawing.Image)(resources.GetObject("btnVital.Image")));
            this.btnVital.ImageIndex = 3;
            this.btnVital.ImageList = this.jobImageList;
            this.btnVital.Location = new System.Drawing.Point(167, 1);
            this.btnVital.Name = "btnVital";
            this.btnVital.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnVital.Size = new System.Drawing.Size(82, 58);
            this.btnVital.TabIndex = 197;
            this.btnVital.Text = "温度板";
            this.btnVital.Click += new System.EventHandler(this.btnVital_Click);
            // 
            // jobImageList
            // 
            this.jobImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("jobImageList.ImageStream")));
            this.jobImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.jobImageList.Images.SetKeyName(0, "");
            this.jobImageList.Images.SetKeyName(1, "");
            this.jobImageList.Images.SetKeyName(2, "");
            this.jobImageList.Images.SetKeyName(3, "");
            this.jobImageList.Images.SetKeyName(4, "");
            this.jobImageList.Images.SetKeyName(5, "");
            this.jobImageList.Images.SetKeyName(6, "");
            this.jobImageList.Images.SetKeyName(7, "");
            this.jobImageList.Images.SetKeyName(8, "");
            this.jobImageList.Images.SetKeyName(9, "");
            this.jobImageList.Images.SetKeyName(10, "");
            this.jobImageList.Images.SetKeyName(11, "");
            this.jobImageList.Images.SetKeyName(12, "");
            this.jobImageList.Images.SetKeyName(13, "");
            this.jobImageList.Images.SetKeyName(14, "");
            this.jobImageList.Images.SetKeyName(15, "");
            this.jobImageList.Images.SetKeyName(16, "");
            this.jobImageList.Images.SetKeyName(17, "");
            this.jobImageList.Images.SetKeyName(18, "");
            this.jobImageList.Images.SetKeyName(19, "");
            this.jobImageList.Images.SetKeyName(20, "");
            this.jobImageList.Images.SetKeyName(21, "");
            this.jobImageList.Images.SetKeyName(22, "");
            this.jobImageList.Images.SetKeyName(23, "");
            this.jobImageList.Images.SetKeyName(24, "");
            this.jobImageList.Images.SetKeyName(25, "");
            this.jobImageList.Images.SetKeyName(26, "");
            this.jobImageList.Images.SetKeyName(27, "");
            this.jobImageList.Images.SetKeyName(28, "EMR.ico");
            this.jobImageList.Images.SetKeyName(29, "");
            this.jobImageList.Images.SetKeyName(30, "");
            this.jobImageList.Images.SetKeyName(31, "");
            // 
            // btnWorkSheet
            // 
            this.btnWorkSheet.Image = ((System.Drawing.Image)(resources.GetObject("btnWorkSheet.Image")));
            this.btnWorkSheet.ImageIndex = 19;
            this.btnWorkSheet.ImageList = this.jobImageList;
            this.btnWorkSheet.Location = new System.Drawing.Point(85, 1);
            this.btnWorkSheet.Name = "btnWorkSheet";
            this.btnWorkSheet.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnWorkSheet.Size = new System.Drawing.Size(82, 58);
            this.btnWorkSheet.TabIndex = 196;
            this.btnWorkSheet.Text = "ワーク\r\nシート";
            this.btnWorkSheet.Click += new System.EventHandler(this.btnWorkSheet_Click);
            // 
            // ibtnChangeGwa
            // 
            this.ibtnChangeGwa.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnChangeGwa.Location = new System.Drawing.Point(495, 1);
            this.ibtnChangeGwa.Name = "ibtnChangeGwa";
            this.ibtnChangeGwa.Size = new System.Drawing.Size(89, 58);
            this.ibtnChangeGwa.TabIndex = 85;
            this.ibtnChangeGwa.Text = "転科転室";
            this.ibtnChangeGwa.Click += new System.EventHandler(this.ibtnChangeGwa_Click);
            // 
            // ibtnGanhoReser
            // 
            this.ibtnGanhoReser.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnGanhoReser.Location = new System.Drawing.Point(413, 1);
            this.ibtnGanhoReser.Name = "ibtnGanhoReser";
            this.ibtnGanhoReser.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.ibtnGanhoReser.Size = new System.Drawing.Size(82, 58);
            this.ibtnGanhoReser.TabIndex = 0;
            this.ibtnGanhoReser.Text = "治療計画";
            this.ibtnGanhoReser.Click += new System.EventHandler(this.ibtnGanhoReser_Click);
            // 
            // btnSang
            // 
            this.btnSang.Image = ((System.Drawing.Image)(resources.GetObject("btnSang.Image")));
            this.btnSang.ImageIndex = 0;
            this.btnSang.ImageList = this.jobImageList;
            this.btnSang.Location = new System.Drawing.Point(249, 1);
            this.btnSang.Name = "btnSang";
            this.btnSang.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnSang.Size = new System.Drawing.Size(82, 58);
            this.btnSang.TabIndex = 194;
            this.btnSang.Text = "傷病照会";
            this.btnSang.Click += new System.EventHandler(this.btnSang_Click);
            // 
            // btnGanhodo
            // 
            this.btnGanhodo.Image = ((System.Drawing.Image)(resources.GetObject("btnGanhodo.Image")));
            this.btnGanhodo.Location = new System.Drawing.Point(331, 1);
            this.btnGanhodo.Name = "btnGanhodo";
            this.btnGanhodo.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnGanhodo.Size = new System.Drawing.Size(82, 58);
            this.btnGanhodo.TabIndex = 87;
            this.btnGanhodo.Text = "管理項目";
            this.btnGanhodo.Click += new System.EventHandler(this.btnGanhodo_Click);
            // 
            // btnReadOrder
            // 
            this.btnReadOrder.ImageIndex = 6;
            this.btnReadOrder.ImageList = this.ImageList;
            this.btnReadOrder.Location = new System.Drawing.Point(363, 29);
            this.btnReadOrder.Name = "btnReadOrder";
            this.btnReadOrder.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnReadOrder.Size = new System.Drawing.Size(119, 26);
            this.btnReadOrder.TabIndex = 193;
            this.btnReadOrder.Text = "オーダ情報照会";
            this.btnReadOrder.Visible = false;
            this.btnReadOrder.Click += new System.EventHandler(this.btnReadOrder_Click);
            // 
            // btnSetHo_sex
            // 
            this.btnSetHo_sex.ImageIndex = 3;
            this.btnSetHo_sex.ImageList = this.ImageList;
            this.btnSetHo_sex.Location = new System.Drawing.Point(631, 10);
            this.btnSetHo_sex.Name = "btnSetHo_sex";
            this.btnSetHo_sex.Size = new System.Drawing.Size(29, 16);
            this.btnSetHo_sex.TabIndex = 99;
            this.btnSetHo_sex.Text = "病室性別設定";
            this.btnSetHo_sex.Visible = false;
            this.btnSetHo_sex.Click += new System.EventHandler(this.btnSetHo_sex_Click);
            // 
            // btnOCS2003U02Open
            // 
            this.btnOCS2003U02Open.ImageIndex = 0;
            this.btnOCS2003U02Open.ImageList = this.ImageList;
            this.btnOCS2003U02Open.Location = new System.Drawing.Point(459, 3);
            this.btnOCS2003U02Open.Name = "btnOCS2003U02Open";
            this.btnOCS2003U02Open.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnOCS2003U02Open.Size = new System.Drawing.Size(145, 26);
            this.btnOCS2003U02Open.TabIndex = 95;
            this.btnOCS2003U02Open.Text = "入院看護オーダ登録";
            this.btnOCS2003U02Open.Visible = false;
            this.btnOCS2003U02Open.Click += new System.EventHandler(this.btnOCS2003U02Open_Click);
            // 
            // cboGwa
            // 
            this.cboGwa.IsAppendAll = true;
            this.cboGwa.Location = new System.Drawing.Point(506, 6);
            this.cboGwa.MaxDropDownItems = 50;
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.Size = new System.Drawing.Size(120, 21);
            this.cboGwa.TabIndex = 94;
            this.cboGwa.Visible = false;
            this.cboGwa.SelectedIndexChanged += new System.EventHandler(this.cboGwa_SelectedIndexChanged);
            // 
            // btnPlan
            // 
            this.btnPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnPlan.Image")));
            this.btnPlan.Location = new System.Drawing.Point(484, 29);
            this.btnPlan.Name = "btnPlan";
            this.btnPlan.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnPlan.Size = new System.Drawing.Size(96, 26);
            this.btnPlan.TabIndex = 91;
            this.btnPlan.Text = "看護計画";
            this.btnPlan.Visible = false;
            this.btnPlan.Click += new System.EventHandler(this.btnPlan_Click);
            // 
            // btnDamdang_Nurse
            // 
            this.btnDamdang_Nurse.Image = ((System.Drawing.Image)(resources.GetObject("btnDamdang_Nurse.Image")));
            this.btnDamdang_Nurse.Location = new System.Drawing.Point(129, 29);
            this.btnDamdang_Nurse.Name = "btnDamdang_Nurse";
            this.btnDamdang_Nurse.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnDamdang_Nurse.Size = new System.Drawing.Size(112, 26);
            this.btnDamdang_Nurse.TabIndex = 89;
            this.btnDamdang_Nurse.Text = "担当看護師";
            this.btnDamdang_Nurse.Visible = false;
            this.btnDamdang_Nurse.Click += new System.EventHandler(this.btnDamdang_Nurse_Click);
            // 
            // btnBedsore
            // 
            this.btnBedsore.Image = ((System.Drawing.Image)(resources.GetObject("btnBedsore.Image")));
            this.btnBedsore.Location = new System.Drawing.Point(241, 29);
            this.btnBedsore.Name = "btnBedsore";
            this.btnBedsore.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnBedsore.Size = new System.Drawing.Size(122, 26);
            this.btnBedsore.TabIndex = 83;
            this.btnBedsore.Text = "褥瘡患者管理";
            this.btnBedsore.Visible = false;
            this.btnBedsore.Click += new System.EventHandler(this.btnBedsore_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.HoveredImage = ((System.Drawing.Image)(resources.GetObject("btnHelp.HoveredImage")));
            this.btnHelp.Location = new System.Drawing.Point(6, 30);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnHelp.NormalImage")));
            this.btnHelp.PushedImage = ((System.Drawing.Image)(resources.GetObject("btnHelp.PushedImage")));
            this.btnHelp.Size = new System.Drawing.Size(126, 22);
            this.btnHelp.TabIndex = 82;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // cboHoDong
            // 
            this.cboHoDong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboHoDong.Location = new System.Drawing.Point(36, 6);
            this.cboHoDong.MaxDropDownItems = 40;
            this.cboHoDong.Name = "cboHoDong";
            this.cboHoDong.Size = new System.Drawing.Size(92, 21);
            this.cboHoDong.TabIndex = 81;
            this.cboHoDong.SelectedIndexChanged += new System.EventHandler(this.cboHoDong_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label26.Location = new System.Drawing.Point(4, 6);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(32, 22);
            this.label26.TabIndex = 80;
            this.label26.Text = "病棟";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxJunip
            // 
            this.pbxJunip.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.pbxJunip.Image = ((System.Drawing.Image)(resources.GetObject("pbxJunip.Image")));
            this.pbxJunip.Location = new System.Drawing.Point(368, 10);
            this.pbxJunip.Name = "pbxJunip";
            this.pbxJunip.Protect = false;
            this.pbxJunip.Size = new System.Drawing.Size(12, 12);
            this.pbxJunip.TabIndex = 192;
            this.pbxJunip.TabStop = false;
            this.pbxJunip.Visible = false;
            // 
            // cboDoctorList
            // 
            this.cboDoctorList.Location = new System.Drawing.Point(506, 33);
            this.cboDoctorList.MaxDropDownItems = 50;
            this.cboDoctorList.Name = "cboDoctorList";
            this.cboDoctorList.Size = new System.Drawing.Size(118, 21);
            this.cboDoctorList.TabIndex = 93;
            this.cboDoctorList.Visible = false;
            this.cboDoctorList.SelectedValueChanged += new System.EventHandler(this.cboDoctorList_SelectedValueChanged);
            // 
            // btnQuery
            // 
            this.btnQuery.ImageIndex = 2;
            this.btnQuery.ImageList = this.ImageList;
            this.btnQuery.Location = new System.Drawing.Point(129, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(112, 26);
            this.btnQuery.TabIndex = 98;
            this.btnQuery.Text = "照 会";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnVisible
            // 
            this.btnVisible.ImageIndex = 4;
            this.btnVisible.ImageList = this.ImageList;
            this.btnVisible.Location = new System.Drawing.Point(241, 3);
            this.btnVisible.Name = "btnVisible";
            this.btnVisible.Size = new System.Drawing.Size(122, 26);
            this.btnVisible.TabIndex = 100;
            this.btnVisible.Tag = "Y";
            this.btnVisible.Text = "画面調整";
            this.btnVisible.Click += new System.EventHandler(this.btnVisible_Click);
            // 
            // btnJunipConfirm
            // 
            this.btnJunipConfirm.Enabled = false;
            this.btnJunipConfirm.Location = new System.Drawing.Point(363, 3);
            this.btnJunipConfirm.Name = "btnJunipConfirm";
            this.btnJunipConfirm.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnJunipConfirm.Size = new System.Drawing.Size(96, 26);
            this.btnJunipConfirm.TabIndex = 191;
            this.btnJunipConfirm.Text = "  転入確認";
            this.btnJunipConfirm.Click += new System.EventHandler(this.btnTransConfirm_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdGwaCount);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbxTimer);
            this.panel2.Controls.Add(this.dbxDansongCnt);
            this.panel2.Controls.Add(this.dbxHosongCnt);
            this.panel2.Controls.Add(this.dbxDokboCnt);
            this.panel2.Controls.Add(this.xLabel1);
            this.panel2.Controls.Add(this.txtCmmt);
            this.panel2.Controls.Add(this.dbxBedEtcTotal);
            this.panel2.Controls.Add(this.dbxBedEtcNoUse);
            this.panel2.Controls.Add(this.dbxBedEtcUse);
            this.panel2.Controls.Add(this.dbxBedSpecUseTotal);
            this.panel2.Controls.Add(this.dbxBedSpecUseNoUse);
            this.panel2.Controls.Add(this.dbxBedSpecUse);
            this.panel2.Controls.Add(this.dbxBedWomanTotal);
            this.panel2.Controls.Add(this.dbxBedWomanNoUse);
            this.panel2.Controls.Add(this.dbxBedWomanUse);
            this.panel2.Controls.Add(this.dbxBedManTotal);
            this.panel2.Controls.Add(this.dbxBedManNoUse);
            this.panel2.Controls.Add(this.dbxBedManUse);
            this.panel2.Controls.Add(this.dbxBedNoUse);
            this.panel2.Controls.Add(this.dbxBedUse);
            this.panel2.Controls.Add(this.dbxBedTotal);
            this.panel2.Controls.Add(this.dbxOutWeek);
            this.panel2.Controls.Add(this.dbxTaewonWeek);
            this.panel2.Controls.Add(this.dbxInWeek);
            this.panel2.Controls.Add(this.dbxIpwonWeek);
            this.panel2.Controls.Add(this.dbxOutNext);
            this.panel2.Controls.Add(this.dbxTaewonNext);
            this.panel2.Controls.Add(this.dbxInNext);
            this.panel2.Controls.Add(this.dbxIpwonNext);
            this.panel2.Controls.Add(this.dbxOutToday);
            this.panel2.Controls.Add(this.dbxTaewonToday);
            this.panel2.Controls.Add(this.dbxInToday);
            this.panel2.Controls.Add(this.dbxIpwonToday);
            this.panel2.Controls.Add(this.dbxIpwonWoman);
            this.panel2.Controls.Add(this.dbxIpwonMan);
            this.panel2.Controls.Add(this.dbxIpwonTotal);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(936, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 836);
            this.panel2.TabIndex = 2;
            this.panel2.Visible = false;
            // 
            // grdGwaCount
            // 
            this.grdGwaCount.AddedHeaderLine = 1;
            this.grdGwaCount.ApplyPaintEventToAllColumn = true;
            this.grdGwaCount.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdGwaCount.ColPerLine = 3;
            this.grdGwaCount.Cols = 3;
            this.grdGwaCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdGwaCount.Enabled = false;
            this.grdGwaCount.FixedRows = 2;
            this.grdGwaCount.HeaderHeights.Add(21);
            this.grdGwaCount.HeaderHeights.Add(0);
            this.grdGwaCount.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdGwaCount.Location = new System.Drawing.Point(0, 613);
            this.grdGwaCount.Name = "grdGwaCount";
            this.grdGwaCount.QuerySQL = resources.GetString("grdGwaCount.QuerySQL");
            this.grdGwaCount.Rows = 3;
            this.grdGwaCount.Size = new System.Drawing.Size(275, 206);
            this.grdGwaCount.TabIndex = 193;
            this.grdGwaCount.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdGwaCount_QueryEnd);
            this.grdGwaCount.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdGwaCount_QueryStarting);
            this.grdGwaCount.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdGwaCount_GridCellPainting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "gwa";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "gwa";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "gwa_name";
            this.xEditGridCell2.CellWidth = 106;
            this.xEditGridCell2.HeaderText = "診療科";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.Row = 1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "count";
            this.xEditGridCell3.CellWidth = 114;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.HeaderText = "人数";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.RowSpan = 2;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "gwa_color";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "gwa_color";
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "color";
            this.xEditGridCell5.CellWidth = 52;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.HeaderText = "color";
            this.xEditGridCell5.Row = 1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "診療科";
            this.xGridHeader1.HeaderWidth = 106;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(1, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 26);
            this.label3.TabIndex = 192;
            // 
            // cbxTimer
            // 
            this.cbxTimer.AutoSize = true;
            this.cbxTimer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxTimer.Checked = true;
            this.cbxTimer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxTimer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cbxTimer.Location = new System.Drawing.Point(0, 819);
            this.cbxTimer.Name = "cbxTimer";
            this.cbxTimer.Size = new System.Drawing.Size(275, 17);
            this.cbxTimer.TabIndex = 191;
            this.cbxTimer.Text = "追加オーダ確認";
            this.cbxTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxTimer.UseVisualStyleBackColor = false;
            this.cbxTimer.CheckedChanged += new System.EventHandler(this.cbxTimer_CheckedChanged);
            // 
            // dbxDansongCnt
            // 
            this.dbxDansongCnt.Location = new System.Drawing.Point(224, 422);
            this.dbxDansongCnt.Name = "dbxDansongCnt";
            this.dbxDansongCnt.Size = new System.Drawing.Size(46, 21);
            this.dbxDansongCnt.TabIndex = 190;
            this.dbxDansongCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxHosongCnt
            // 
            this.dbxHosongCnt.Location = new System.Drawing.Point(133, 422);
            this.dbxHosongCnt.Name = "dbxHosongCnt";
            this.dbxHosongCnt.Size = new System.Drawing.Size(46, 21);
            this.dbxHosongCnt.TabIndex = 189;
            this.dbxHosongCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxDokboCnt
            // 
            this.dbxDokboCnt.Location = new System.Drawing.Point(43, 422);
            this.dbxDokboCnt.Name = "dbxDokboCnt";
            this.dbxDokboCnt.Size = new System.Drawing.Size(46, 21);
            this.dbxDokboCnt.TabIndex = 188;
            this.dbxDokboCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel1
            // 
            this.xLabel1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel1.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xLabel1.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.CornflowerBlue);
            this.xLabel1.GradientStartColor = IHIS.Framework.XColor.XFormBackColor;
            this.xLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel1.Location = new System.Drawing.Point(4, 38);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(272, 22);
            this.xLabel1.TabIndex = 184;
            // 
            // txtCmmt
            // 
            this.txtCmmt.Location = new System.Drawing.Point(4, 62);
            this.txtCmmt.Multiline = true;
            this.txtCmmt.Name = "txtCmmt";
            this.txtCmmt.ReadOnly = true;
            this.txtCmmt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCmmt.Size = new System.Drawing.Size(268, 134);
            this.txtCmmt.TabIndex = 183;
            this.txtCmmt.TabStop = false;
            // 
            // dbxBedEtcTotal
            // 
            this.dbxBedEtcTotal.Location = new System.Drawing.Point(218, 538);
            this.dbxBedEtcTotal.Name = "dbxBedEtcTotal";
            this.dbxBedEtcTotal.Size = new System.Drawing.Size(46, 21);
            this.dbxBedEtcTotal.TabIndex = 182;
            this.dbxBedEtcTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBedEtcNoUse
            // 
            this.dbxBedEtcNoUse.Location = new System.Drawing.Point(218, 516);
            this.dbxBedEtcNoUse.Name = "dbxBedEtcNoUse";
            this.dbxBedEtcNoUse.Size = new System.Drawing.Size(46, 21);
            this.dbxBedEtcNoUse.TabIndex = 181;
            this.dbxBedEtcNoUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBedEtcUse
            // 
            this.dbxBedEtcUse.Location = new System.Drawing.Point(218, 494);
            this.dbxBedEtcUse.Name = "dbxBedEtcUse";
            this.dbxBedEtcUse.Size = new System.Drawing.Size(46, 21);
            this.dbxBedEtcUse.TabIndex = 180;
            this.dbxBedEtcUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBedSpecUseTotal
            // 
            this.dbxBedSpecUseTotal.Location = new System.Drawing.Point(160, 538);
            this.dbxBedSpecUseTotal.Name = "dbxBedSpecUseTotal";
            this.dbxBedSpecUseTotal.Size = new System.Drawing.Size(46, 21);
            this.dbxBedSpecUseTotal.TabIndex = 179;
            this.dbxBedSpecUseTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBedSpecUseNoUse
            // 
            this.dbxBedSpecUseNoUse.Location = new System.Drawing.Point(160, 516);
            this.dbxBedSpecUseNoUse.Name = "dbxBedSpecUseNoUse";
            this.dbxBedSpecUseNoUse.Size = new System.Drawing.Size(46, 21);
            this.dbxBedSpecUseNoUse.TabIndex = 178;
            this.dbxBedSpecUseNoUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBedSpecUse
            // 
            this.dbxBedSpecUse.Location = new System.Drawing.Point(160, 494);
            this.dbxBedSpecUse.Name = "dbxBedSpecUse";
            this.dbxBedSpecUse.Size = new System.Drawing.Size(46, 21);
            this.dbxBedSpecUse.TabIndex = 177;
            this.dbxBedSpecUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBedWomanTotal
            // 
            this.dbxBedWomanTotal.Location = new System.Drawing.Point(104, 538);
            this.dbxBedWomanTotal.Name = "dbxBedWomanTotal";
            this.dbxBedWomanTotal.Size = new System.Drawing.Size(46, 21);
            this.dbxBedWomanTotal.TabIndex = 176;
            this.dbxBedWomanTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBedWomanNoUse
            // 
            this.dbxBedWomanNoUse.Location = new System.Drawing.Point(104, 516);
            this.dbxBedWomanNoUse.Name = "dbxBedWomanNoUse";
            this.dbxBedWomanNoUse.Size = new System.Drawing.Size(46, 21);
            this.dbxBedWomanNoUse.TabIndex = 175;
            this.dbxBedWomanNoUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBedWomanUse
            // 
            this.dbxBedWomanUse.Location = new System.Drawing.Point(104, 494);
            this.dbxBedWomanUse.Name = "dbxBedWomanUse";
            this.dbxBedWomanUse.Size = new System.Drawing.Size(46, 21);
            this.dbxBedWomanUse.TabIndex = 174;
            this.dbxBedWomanUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBedManTotal
            // 
            this.dbxBedManTotal.Location = new System.Drawing.Point(46, 538);
            this.dbxBedManTotal.Name = "dbxBedManTotal";
            this.dbxBedManTotal.Size = new System.Drawing.Size(46, 21);
            this.dbxBedManTotal.TabIndex = 173;
            this.dbxBedManTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBedManNoUse
            // 
            this.dbxBedManNoUse.Location = new System.Drawing.Point(46, 516);
            this.dbxBedManNoUse.Name = "dbxBedManNoUse";
            this.dbxBedManNoUse.Size = new System.Drawing.Size(46, 21);
            this.dbxBedManNoUse.TabIndex = 172;
            this.dbxBedManNoUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBedManUse
            // 
            this.dbxBedManUse.Location = new System.Drawing.Point(46, 494);
            this.dbxBedManUse.Name = "dbxBedManUse";
            this.dbxBedManUse.Size = new System.Drawing.Size(46, 21);
            this.dbxBedManUse.TabIndex = 171;
            this.dbxBedManUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBedNoUse
            // 
            this.dbxBedNoUse.Location = new System.Drawing.Point(224, 444);
            this.dbxBedNoUse.Name = "dbxBedNoUse";
            this.dbxBedNoUse.Size = new System.Drawing.Size(46, 21);
            this.dbxBedNoUse.TabIndex = 170;
            this.dbxBedNoUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBedUse
            // 
            this.dbxBedUse.Location = new System.Drawing.Point(133, 444);
            this.dbxBedUse.Name = "dbxBedUse";
            this.dbxBedUse.Size = new System.Drawing.Size(46, 21);
            this.dbxBedUse.TabIndex = 169;
            this.dbxBedUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxBedTotal
            // 
            this.dbxBedTotal.Location = new System.Drawing.Point(43, 444);
            this.dbxBedTotal.Name = "dbxBedTotal";
            this.dbxBedTotal.Size = new System.Drawing.Size(46, 21);
            this.dbxBedTotal.TabIndex = 168;
            this.dbxBedTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxOutWeek
            // 
            this.dbxOutWeek.Location = new System.Drawing.Point(200, 368);
            this.dbxOutWeek.Name = "dbxOutWeek";
            this.dbxOutWeek.Size = new System.Drawing.Size(46, 21);
            this.dbxOutWeek.TabIndex = 167;
            this.dbxOutWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxTaewonWeek
            // 
            this.dbxTaewonWeek.Location = new System.Drawing.Point(200, 346);
            this.dbxTaewonWeek.Name = "dbxTaewonWeek";
            this.dbxTaewonWeek.Size = new System.Drawing.Size(46, 21);
            this.dbxTaewonWeek.TabIndex = 166;
            this.dbxTaewonWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxInWeek
            // 
            this.dbxInWeek.Location = new System.Drawing.Point(200, 324);
            this.dbxInWeek.Name = "dbxInWeek";
            this.dbxInWeek.Size = new System.Drawing.Size(46, 21);
            this.dbxInWeek.TabIndex = 165;
            this.dbxInWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxIpwonWeek
            // 
            this.dbxIpwonWeek.Location = new System.Drawing.Point(200, 302);
            this.dbxIpwonWeek.Name = "dbxIpwonWeek";
            this.dbxIpwonWeek.Size = new System.Drawing.Size(46, 21);
            this.dbxIpwonWeek.TabIndex = 164;
            this.dbxIpwonWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxOutNext
            // 
            this.dbxOutNext.Location = new System.Drawing.Point(128, 368);
            this.dbxOutNext.Name = "dbxOutNext";
            this.dbxOutNext.Size = new System.Drawing.Size(46, 21);
            this.dbxOutNext.TabIndex = 163;
            this.dbxOutNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxTaewonNext
            // 
            this.dbxTaewonNext.Location = new System.Drawing.Point(128, 346);
            this.dbxTaewonNext.Name = "dbxTaewonNext";
            this.dbxTaewonNext.Size = new System.Drawing.Size(46, 21);
            this.dbxTaewonNext.TabIndex = 162;
            this.dbxTaewonNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxInNext
            // 
            this.dbxInNext.Location = new System.Drawing.Point(128, 324);
            this.dbxInNext.Name = "dbxInNext";
            this.dbxInNext.Size = new System.Drawing.Size(46, 21);
            this.dbxInNext.TabIndex = 161;
            this.dbxInNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxIpwonNext
            // 
            this.dbxIpwonNext.Location = new System.Drawing.Point(128, 302);
            this.dbxIpwonNext.Name = "dbxIpwonNext";
            this.dbxIpwonNext.Size = new System.Drawing.Size(46, 21);
            this.dbxIpwonNext.TabIndex = 160;
            this.dbxIpwonNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxOutToday
            // 
            this.dbxOutToday.Location = new System.Drawing.Point(58, 368);
            this.dbxOutToday.Name = "dbxOutToday";
            this.dbxOutToday.Size = new System.Drawing.Size(46, 21);
            this.dbxOutToday.TabIndex = 159;
            this.dbxOutToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxTaewonToday
            // 
            this.dbxTaewonToday.Location = new System.Drawing.Point(58, 346);
            this.dbxTaewonToday.Name = "dbxTaewonToday";
            this.dbxTaewonToday.Size = new System.Drawing.Size(46, 21);
            this.dbxTaewonToday.TabIndex = 158;
            this.dbxTaewonToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxInToday
            // 
            this.dbxInToday.Location = new System.Drawing.Point(58, 324);
            this.dbxInToday.Name = "dbxInToday";
            this.dbxInToday.Size = new System.Drawing.Size(46, 21);
            this.dbxInToday.TabIndex = 157;
            this.dbxInToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxIpwonToday
            // 
            this.dbxIpwonToday.Location = new System.Drawing.Point(58, 302);
            this.dbxIpwonToday.Name = "dbxIpwonToday";
            this.dbxIpwonToday.Size = new System.Drawing.Size(46, 21);
            this.dbxIpwonToday.TabIndex = 156;
            this.dbxIpwonToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxIpwonWoman
            // 
            this.dbxIpwonWoman.Location = new System.Drawing.Point(223, 228);
            this.dbxIpwonWoman.Name = "dbxIpwonWoman";
            this.dbxIpwonWoman.Size = new System.Drawing.Size(46, 21);
            this.dbxIpwonWoman.TabIndex = 155;
            this.dbxIpwonWoman.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxIpwonMan
            // 
            this.dbxIpwonMan.Location = new System.Drawing.Point(136, 228);
            this.dbxIpwonMan.Name = "dbxIpwonMan";
            this.dbxIpwonMan.Size = new System.Drawing.Size(46, 21);
            this.dbxIpwonMan.TabIndex = 154;
            this.dbxIpwonMan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxIpwonTotal
            // 
            this.dbxIpwonTotal.Location = new System.Drawing.Point(51, 228);
            this.dbxIpwonTotal.Name = "dbxIpwonTotal";
            this.dbxIpwonTotal.Size = new System.Drawing.Size(46, 21);
            this.dbxIpwonTotal.TabIndex = 153;
            this.dbxIpwonTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 538);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 21);
            this.label22.TabIndex = 149;
            this.label22.Text = "合計";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(8, 516);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 21);
            this.label21.TabIndex = 148;
            this.label21.Text = "空床";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(8, 494);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 21);
            this.label20.TabIndex = 147;
            this.label20.Text = "使用";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(220, 473);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 21);
            this.label18.TabIndex = 146;
            this.label18.Text = "(他)";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(162, 473);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 21);
            this.label16.TabIndex = 145;
            this.label16.Text = "(特)";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(106, 473);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 21);
            this.label15.TabIndex = 144;
            this.label15.Text = "(女)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(48, 473);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(41, 21);
            this.label27.TabIndex = 143;
            this.label27.Text = "(男)";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(200, 280);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 21);
            this.label12.TabIndex = 142;
            this.label12.Text = "明日";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(13, 368);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 21);
            this.label11.TabIndex = 141;
            this.label11.Text = "転出";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(13, 346);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 21);
            this.label10.TabIndex = 140;
            this.label10.Text = "退院";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(13, 324);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 21);
            this.label9.TabIndex = 139;
            this.label9.Text = "転入";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 21);
            this.label8.TabIndex = 138;
            this.label8.Text = "入院";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(128, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 21);
            this.label7.TabIndex = 137;
            this.label7.Text = "本日";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(58, 280);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 21);
            this.label14.TabIndex = 136;
            this.label14.Text = "昨日";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(9, 228);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 21);
            this.label19.TabIndex = 135;
            this.label19.Text = "(合計)";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(189, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 21);
            this.label4.TabIndex = 134;
            this.label4.Text = "(女)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(101, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 21);
            this.label6.TabIndex = 133;
            this.label6.Text = "(男)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(4, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 129;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Image = ((System.Drawing.Image)(resources.GetObject("label13.Image")));
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(4, 394);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(246, 24);
            this.label13.TabIndex = 131;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Image = ((System.Drawing.Image)(resources.GetObject("label17.Image")));
            this.label17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label17.Location = new System.Drawing.Point(4, 254);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(246, 24);
            this.label17.TabIndex = 130;
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.Color.Blue;
            this.label25.Location = new System.Drawing.Point(184, 422);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 21);
            this.label25.TabIndex = 152;
            this.label25.Text = "(担送)";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.Color.Blue;
            this.label24.Location = new System.Drawing.Point(93, 422);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 21);
            this.label24.TabIndex = 151;
            this.label24.Text = "(護送)";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.Color.Blue;
            this.label23.Location = new System.Drawing.Point(3, 422);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 21);
            this.label23.TabIndex = 150;
            this.label23.Text = "(独歩)";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(184, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 21);
            this.label1.TabIndex = 187;
            this.label1.Text = "(空床)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(93, 444);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 21);
            this.label5.TabIndex = 186;
            this.label5.Text = "(使用)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.ForeColor = System.Drawing.Color.Blue;
            this.label28.Location = new System.Drawing.Point(3, 444);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 21);
            this.label28.TabIndex = 185;
            this.label28.Text = "(合計)";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layHosilList
            // 
            this.layHosilList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem46,
            this.multiLayoutItem47,
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
            this.multiLayoutItem52,
            this.multiLayoutItem53});
            this.layHosilList.QuerySQL = resources.GetString("layHosilList.QuerySQL");
            this.layHosilList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layHosilList_QueryStarting);
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "ho_code";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "ho_status";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "ho_total_bed";
            this.multiLayoutItem49.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "ho_sex";
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "ho_code_name";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "double_ho_yn";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "ho_sort";
            // 
            // layPatientList
            // 
            this.layPatientList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem54,
            this.multiLayoutItem55,
            this.multiLayoutItem56,
            this.multiLayoutItem57,
            this.multiLayoutItem58,
            this.multiLayoutItem59,
            this.multiLayoutItem60,
            this.multiLayoutItem61,
            this.multiLayoutItem62,
            this.multiLayoutItem63,
            this.multiLayoutItem64,
            this.multiLayoutItem65,
            this.multiLayoutItem66,
            this.multiLayoutItem67,
            this.multiLayoutItem68,
            this.multiLayoutItem69,
            this.multiLayoutItem70,
            this.multiLayoutItem71,
            this.multiLayoutItem72,
            this.multiLayoutItem73,
            this.multiLayoutItem74,
            this.multiLayoutItem75,
            this.multiLayoutItem76,
            this.multiLayoutItem77,
            this.multiLayoutItem78,
            this.multiLayoutItem79,
            this.multiLayoutItem80,
            this.multiLayoutItem82,
            this.multiLayoutItem83,
            this.multiLayoutItem84,
            this.multiLayoutItem86,
            this.multiLayoutItem87,
            this.multiLayoutItem90,
            this.multiLayoutItem92,
            this.multiLayoutItem93,
            this.multiLayoutItem94,
            this.multiLayoutItem95,
            this.multiLayoutItem96,
            this.multiLayoutItem97,
            this.multiLayoutItem98,
            this.multiLayoutItem99,
            this.multiLayoutItem108,
            this.multiLayoutItem109,
            this.multiLayoutItem110,
            this.multiLayoutItem111,
            this.multiLayoutItem112,
            this.multiLayoutItem116,
            this.multiLayoutItem117,
            this.multiLayoutItem118,
            this.multiLayoutItem121,
            this.multiLayoutItem125});
            this.layPatientList.QuerySQL = resources.GetString("layPatientList.QuerySQL");
            this.layPatientList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPatientList_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "reser_gubun";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "ho_code";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "bunho";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "suname";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "suname2";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "sex";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "pkinp1001";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "ho_bed";
            this.multiLayoutItem55.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem55.IsNotNull = true;
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "team";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "pa_gubun";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "order_status";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "birth_date";
            this.multiLayoutItem59.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "sex_age";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "ipwon_date";
            this.multiLayoutItem61.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "jaewon_nalsu";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "gaw_name";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "doctor_name";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "resident_name";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "nurse_name";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "ganhodo";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "life_self_grade";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "guho_gubun";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "out_sleep_yn";
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "toiwon_res_date";
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "toiwon_res_time";
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "doctor";
            // 
            // multiLayoutItem74
            // 
            this.multiLayoutItem74.DataName = "gwa";
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "bunman_yn";
            // 
            // multiLayoutItem76
            // 
            this.multiLayoutItem76.DataName = "ipwon_reser_info";
            // 
            // multiLayoutItem77
            // 
            this.multiLayoutItem77.DataName = "ipwon_mokjuk";
            // 
            // multiLayoutItem78
            // 
            this.multiLayoutItem78.DataName = "bed_status";
            // 
            // multiLayoutItem79
            // 
            this.multiLayoutItem79.DataName = "is_out";
            // 
            // multiLayoutItem80
            // 
            this.multiLayoutItem80.DataName = "ingong_yn";
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "secret_yn";
            // 
            // multiLayoutItem83
            // 
            this.multiLayoutItem83.DataName = "toiwon_goji_yn";
            // 
            // multiLayoutItem84
            // 
            this.multiLayoutItem84.DataName = "bed_lock_text";
            // 
            // multiLayoutItem86
            // 
            this.multiLayoutItem86.DataName = "status_flag1";
            // 
            // multiLayoutItem87
            // 
            this.multiLayoutItem87.DataName = "status_flag1_name";
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "status_flag2";
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "status_flag2_name";
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "status_flag3";
            // 
            // multiLayoutItem94
            // 
            this.multiLayoutItem94.DataName = "status_flag3_name";
            // 
            // multiLayoutItem95
            // 
            this.multiLayoutItem95.DataName = "status_flag4";
            // 
            // multiLayoutItem96
            // 
            this.multiLayoutItem96.DataName = "status_flag4_name";
            // 
            // multiLayoutItem97
            // 
            this.multiLayoutItem97.DataName = "status_flag5";
            // 
            // multiLayoutItem98
            // 
            this.multiLayoutItem98.DataName = "status_flag5_name";
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "cp_yn";
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "sang_name";
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "code";
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "rgb";
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "yokchang_yn";
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "gamyum_yn";
            // 
            // multiLayoutItem116
            // 
            this.multiLayoutItem116.DataName = "gamyum_name";
            // 
            // multiLayoutItem117
            // 
            this.multiLayoutItem117.DataName = "ipwon_today";
            // 
            // multiLayoutItem118
            // 
            this.multiLayoutItem118.DataName = "kaikei_hodong";
            // 
            // multiLayoutItem121
            // 
            this.multiLayoutItem121.DataName = "kaikei_hocode";
            // 
            // multiLayoutItem125
            // 
            this.multiLayoutItem125.DataName = "not_yet_drg_date";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlLeft);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1211, 836);
            this.panel1.TabIndex = 3;
            // 
            // pnlLeft
            // 
            this.pnlLeft.AutoScroll = true;
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLeft.Controls.Add(this.pbxHelp);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(936, 836);
            this.pnlLeft.TabIndex = 1;
            this.pnlLeft.Click += new System.EventHandler(this.pnlLeft_Click);
            // 
            // pbxHelp
            // 
            this.pbxHelp.BackgroundImage = global::IHIS.NURI.Properties.Resources.help;
            this.pbxHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxHelp.Location = new System.Drawing.Point(0, 0);
            this.pbxHelp.Name = "pbxHelp";
            this.pbxHelp.Size = new System.Drawing.Size(618, 557);
            this.pbxHelp.TabIndex = 0;
            this.pbxHelp.TabStop = false;
            this.pbxHelp.Visible = false;
            // 
            // layBedList
            // 
            this.layBedList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10});
            this.layBedList.QuerySQL = resources.GetString("layBedList.QuerySQL");
            this.layBedList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layBedList_QueryStarting);
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "ho_dong";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "ho_code";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "bed_no";
            this.multiLayoutItem9.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "team";
            // 
            // layConfirmData
            // 
            this.layConfirmData.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3,
            this.singleLayoutItem4,
            this.singleLayoutItem5,
            this.singleLayoutItem6,
            this.singleLayoutItem7,
            this.singleLayoutItem8,
            this.singleLayoutItem9,
            this.singleLayoutItem10,
            this.singleLayoutItem11,
            this.singleLayoutItem12,
            this.singleLayoutItem13,
            this.singleLayoutItem14,
            this.singleLayoutItem15,
            this.singleLayoutItem16,
            this.singleLayoutItem17,
            this.singleLayoutItem21,
            this.singleLayoutItem22,
            this.singleLayoutItem24,
            this.singleLayoutItem25});
            this.layConfirmData.QuerySQL = resources.GetString("layConfirmData.QuerySQL");
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "fkinp1001";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "bunho";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "start_date";
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "trans_time";
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.DataName = "to_gwa";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "to_doctor";
            // 
            // singleLayoutItem7
            // 
            this.singleLayoutItem7.DataName = "to_resident";
            // 
            // singleLayoutItem8
            // 
            this.singleLayoutItem8.DataName = "to_ho_code1";
            // 
            // singleLayoutItem9
            // 
            this.singleLayoutItem9.DataName = "to_ho_dong1";
            // 
            // singleLayoutItem10
            // 
            this.singleLayoutItem10.DataName = "to_ho_code2";
            // 
            // singleLayoutItem11
            // 
            this.singleLayoutItem11.DataName = "to_ho_dong2";
            // 
            // singleLayoutItem12
            // 
            this.singleLayoutItem12.DataName = "trans_gubun";
            // 
            // singleLayoutItem13
            // 
            this.singleLayoutItem13.DataName = "to_bed_no";
            // 
            // singleLayoutItem14
            // 
            this.singleLayoutItem14.DataName = "to_bed_no2";
            // 
            // singleLayoutItem15
            // 
            this.singleLayoutItem15.DataName = "from_ho_code1";
            // 
            // singleLayoutItem16
            // 
            this.singleLayoutItem16.DataName = "from_ho_dong1";
            // 
            // singleLayoutItem17
            // 
            this.singleLayoutItem17.DataName = "from_bed_no";
            // 
            // singleLayoutItem21
            // 
            this.singleLayoutItem21.DataName = "to_ho_grade1";
            // 
            // singleLayoutItem22
            // 
            this.singleLayoutItem22.DataName = "to_ho_grade2";
            // 
            // singleLayoutItem24
            // 
            this.singleLayoutItem24.DataName = "to_kaikei_hodong";
            // 
            // singleLayoutItem25
            // 
            this.singleLayoutItem25.DataName = "to_kaikei_hocode";
            // 
            // layCommon
            // 
            this.layCommon.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem18,
            this.singleLayoutItem19});
            // 
            // singleLayoutItem18
            // 
            this.singleLayoutItem18.DataName = "retVal1";
            // 
            // singleLayoutItem19
            // 
            this.singleLayoutItem19.DataName = "retVal2";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 300000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // layChekNonConfirmOrder
            // 
            this.layChekNonConfirmOrder.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem23});
            this.layChekNonConfirmOrder.QuerySQL = resources.GetString("layChekNonConfirmOrder.QuerySQL");
            this.layChekNonConfirmOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layChekNonConfirmOrder_QueryStarting);
            // 
            // singleLayoutItem23
            // 
            this.singleLayoutItem23.DataName = "exist_yn";
            // 
            // NUR1010Q00
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Name = "NUR1010Q00";
            this.Size = new System.Drawing.Size(1211, 894);
            this.Load += new System.EventHandler(this.NUR1010Q00_Load);
            this.UserChanged += new System.EventHandler(this.NUR1010Q00_UserChanged);
            this.pnlTop.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboGwa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxJunip)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGwaCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layHosilList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPatientList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBedList)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// 메세지 일괄 처리
        /// </summary>
        /// <param name="aMesgGubun">
        /// 메세지 구분
        /// </param>
        #region 메세지처리
        private void GetMessage(string aMesgGubun)
        {
            string Setmsg = string.Empty;
            string caption = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_code", aMesgGubun);

            switch (aMesgGubun)
            {
                case "bunho":
                    Setmsg = (NetInfo.Language == LangMode.Ko ? "환자를 선택해 주세요."
                        : "患者を選択してください。");
                    caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "お知らせ");
                    XMessageBox.Show(Setmsg, caption, MessageBoxIcon.Information);
                    break;
                case "ho_dong":
                    Setmsg = (NetInfo.Language == LangMode.Ko ? "병동이 선택되지 않았습니다."
                        : "病棟が選択されていません。");
                    caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "お知らせ");
                    XMessageBox.Show(Setmsg, caption, MessageBoxIcon.Information);
                    break;
                case "null":
                    Setmsg = "検索条件が合わないか、データがありません。";
                    XMessageBox.Show(Setmsg, "エラー", MessageBoxIcon.Hand);
                    break;
                case "error":
                    Setmsg = "エラーが発生しました。";
                    XMessageBox.Show(Setmsg, "エラー", MessageBoxIcon.Hand);
                    break;
                case "3559":
                case "286":
                case "462":
                case "463":
                case "464":
                case "141":
                case "3268":
                    Setmsg = "SELECT NVL(FN_ADM_MSG(:f_code), 'ERROR') FROM DUAL";
                    if (Service.ExecuteScalar(Setmsg, bindVars) != null && !TypeCheck.IsNull(Service.ExecuteScalar(Setmsg, bindVars)))
                    {
                        XMessageBox.Show(Service.ExecuteScalar(Setmsg, bindVars).ToString(), "お知らせ", MessageBoxIcon.Information);
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [환자정보 Reques/Receive Event]
        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(this.selectedBedBox))
            {
                if (!TypeCheck.IsNull(this.selectedBedBox.Bunho))
                {
                    return new XPatientInfo(this.selectedBedBox.Bunho, "", "", "", this.Name);
                }
            }

            return null;
        }
        #endregion

        #region OnLoad
        private string mHospCode = "";
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            mHospCode = EnvironInfo.HospCode;
            // 화면 크기를 화면에 맞게 최대화 시킨다 (다른 화면에서 연경우가 아닌경우)
            if (this.Opener is IHIS.Framework.MdiForm &&
                (this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed))
            {
                Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                //this.ParentForm.Size = new System.Drawing.Size(rc.Width - 45, rc.Height - 130);
                this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 105);
            }

            this.cboGwa.SetDataValue("");

            //사용자 구분이 Nurse(간호사)이고, 
            if (UserInfo.UserGubun == UserType.Nurse)
            {
                if (UserInfo.HoDong != "")
                    this.cboHoDong.SetEditValue(UserInfo.HoDong);
                else
                    this.cboHoDong.SetEditValue("1");

                this.cboHoDong.AcceptData();

                if (this.cboHoDong.GetDataValue() == "C3")
                    btnADLWork.Visible = true;
                else
                    btnADLWork.Visible = false;
            }

            this.cboGwa.SetDataValue("%");
            this.panel2.Visible = true;
            this.btnVisible.Tag = "N";
        }
        #endregion

        #region 타Screen에서 Open (Command)
        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command.Trim())
            {
                case "IPWONMSG":
                    CommonItemCollection cic = new CommonItemCollection();
                    cic.Add("Msg", "");

                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR1010Q01", ScreenOpenStyle.PopUpSizable, cic);
                    break;

                case "UserChanged": // 사용자 변경
                    break;

                case "OCS6010U10":
                    ExecuteQuery();
                    break;  
            }

            return base.Command(command, commandParam);
        }
        #endregion

        #region ExecuteQuery(병동정보 조회 처리)
        private void ExecuteQuery()
        {
            this.timer.Enabled = false;

            try
            {
                // 각 병상정보 Clear
                dbxIpwonTotal.Text = "0";
                dbxIpwonMan.Text = "0";
                dbxIpwonWoman.Text = "0";

                dbxIpwonToday.Text = "0";
                dbxIpwonNext.Text = "0";
                dbxIpwonWeek.Text = "0";
                dbxInToday.Text = "0";
                dbxInNext.Text = "0";
                dbxInWeek.Text = "0";
                dbxTaewonToday.Text = "0";
                dbxTaewonNext.Text = "0";
                dbxTaewonWeek.Text = "0";
                dbxOutToday.Text = "0";
                dbxOutNext.Text = "0";
                dbxOutWeek.Text = "0";

                dbxDokboCnt.Text = "0";
                dbxHosongCnt.Text = "0";
                dbxDansongCnt.Text = "0";
                dbxBedTotal.Text = "0";
                dbxBedUse.Text = "0";
                dbxBedNoUse.Text = "0";

                dbxBedManUse.Text = "0";
                dbxBedManNoUse.Text = "0";
                dbxBedManTotal.Text = "0";
                dbxBedWomanUse.Text = "0";
                dbxBedWomanNoUse.Text = "0";
                dbxBedWomanTotal.Text = "0";
                dbxBedSpecUse.Text = "0";
                dbxBedSpecUseNoUse.Text = "0";
                dbxBedSpecUseTotal.Text = "0";
                dbxBedEtcUse.Text = "0";
                dbxBedEtcNoUse.Text = "0";
                dbxBedEtcTotal.Text = "0";
                // 각 병상정보 Clear

                /* 선택환자 Clear
                 * Right 병동기본정보 조회
                 * 해당 병동의 병실정보 조회 -> HoSilBox, 공배드 배치 구성
                 * 해당 병동의 환자정보 조회 -> BedBox의 속성 설정
                 * 헬프이미지 조회시 안보이게 처리
                 */

                this.pbxHelp.Visible = false;
                shownHelpImage = false;

                //선택된 BedBox Clear
                this.ForeBedBox = null;

                if (this.selectedBedBox != null)
                {
                    this.ForeBedBox = this.selectedBedBox;
                }

                this.selectedBedBox = null;
                //선택된 환자 정보 Clear
                this.txtCmmt.Clear();


                //병동기본정보 조회 (Layout 확정후 반영)
                string cmdText = string.Empty;
                BindVarCollection bindVars = new BindVarCollection();
                DataTable resTable = new DataTable();
                object retVal = new object();

                /* 구호구분환자수 처리 */
                // :o_dokbo_total, :o_hosong_total, :o_dansong_total
                cmdText = @"   SELECT NVL(SUM(DECODE(NVL(B.DIRECT_CONT1, '3'),'3',1,0)), 0) DOKBO,
                               NVL(SUM(DECODE(B.DIRECT_CONT1,'2',1,0)), 0) HOSONG,
                               NVL(SUM(DECODE(B.DIRECT_CONT1,'1',1,0)), 0) DANSONG
                          FROM VW_OCS_INP1001_01 A
                             , (SELECT A.HOSP_CODE, A.FKINP1001, A.DIRECT_CONT1 
                                  FROM OCS2005 A
                                     , (SELECT MAX(Z.PKOCS2005) PKOCS2005, Z.HOSP_CODE, Z.FKINP1001, Z.DIRECT_GUBUN, Z.DIRECT_CODE
                                          FROM OCS2005 Z
                                         WHERE Z.ORDER_DATE <= TRUNC(SYSDATE)
                                           AND Z.DIRECT_CODE = '0021'
                                         GROUP BY Z.HOSP_CODE, Z.FKINP1001, Z.DIRECT_GUBUN, Z.DIRECT_CODE) B
                                 WHERE B.HOSP_CODE = A.HOSP_CODE
                                   AND B.FKINP1001 = A.FKINP1001
                                   AND B.DIRECT_GUBUN = A.DIRECT_GUBUN
                                   AND B.DIRECT_CODE = A.DIRECT_CODE
                                   AND B.PKOCS2005 = A.PKOCS2005) B
                         WHERE A.HOSP_CODE = :f_hosp_code
                           AND A.HO_DONG1  = :f_ho_dong
                           AND B.HOSP_CODE(+)  = A.HOSP_CODE
                           AND NVL(A.CANCEL_YN,'N') = 'N'
                           AND B.FKINP1001(+) = A.PKINP1001";

                bindVars.Add("f_hosp_code", this.mHospCode);
                bindVars.Add("f_ho_dong", cboHoDong.GetDataValue());
                resTable = Service.ExecuteDataTable(cmdText, bindVars);
                //XMessageBox.Show(Service.ErrFullMsg);

                if (resTable.Rows.Count > 0)
                {
                    dbxDokboCnt.Text = resTable.Rows[0]["dokbo"].ToString();
                    dbxHosongCnt.Text = resTable.Rows[0]["hosong"].ToString();
                    dbxDansongCnt.Text = resTable.Rows[0]["dansong"].ToString();
                }
                else
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                    throw new Exception();
                }

                /* 총환자수 ,남자환자수, 여자환자수 GET */
                // :o_ipwon_man, :o_ipwon_woman, :o_ipwon_total
                cmdText = string.Empty;
                resTable.Clear();
                cmdText = @"SELECT NVL(SUM(A.HO_SEX_MAIL),0) MAN_CNT
                              ,NVL(SUM(A.HO_SEX_FEMAIL),0) WOMAN_CNT
                          FROM BAS0250 A
                          WHERE A.HOSP_CODE = :f_hosp_code 
                           AND A.HO_DONG = :f_ho_dong
                           AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE";
                resTable = Service.ExecuteDataTable(cmdText, bindVars);

                if (resTable.Rows.Count > 0)
                {
                    dbxIpwonMan.Text = resTable.Rows[0]["man_cnt"].ToString();
                    dbxIpwonWoman.Text = resTable.Rows[0]["woman_cnt"].ToString();
                    dbxIpwonTotal.Text = (Convert.ToInt32(resTable.Rows[0]["man_cnt"]) + Convert.ToInt32(resTable.Rows[0]["woman_cnt"])).ToString();
                }
                else
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                    throw new Exception();
                }

                /* 각 병상 합계 */
                cmdText = string.Empty;
                resTable.Clear();
                // o_bed_spec_total, o_bed_spec_use, o_bed_spec_nouse
                // o_bed_man_total, o_bed_man_use, o_bed_man_nouse
                // o_bed_woman_total, o_bed_woman_use, o_bed_woman_nouse
                // o_bed_etc_total, o_bed_etc_use
                cmdText = @"SELECT NVL(A.HO_SEX,'C') HO_SEX
                              ,NVL(A.HO_SPECIAL_YN,'N') HO_SPECIAL_YN
                              --,NVL(SUM(A.REPORT_TOTAL_BED),0) TOTAL_BED
                              ,NVL(SUM(A.HO_TOTAL_BED),0) TOTAL_BED
                              ,NVL(SUM(A.HO_USED_BED),0) USED_BED
                          FROM BAS0250 A
                         WHERE A.HOSP_CODE = :f_hosp_code 
                           AND A.HO_DONG = :f_ho_dong
                           AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE
                         GROUP BY NVL(A.HO_SEX,'C'), NVL(A.HO_SPECIAL_YN,'N')";
                resTable = Service.ExecuteDataTable(cmdText, bindVars);

                if (resTable.Rows.Count > 0)
                {
                    int totalBed = 0;
                    int usedBed = 0;

                    //추가 2011.12.06 woo
                    int specTotal = 0;
                    int specUsed = 0;
                    for (int i = 0; i < resTable.Rows.Count; i++)
                    {
                        if (resTable.Rows[i]["ho_special_yn"] != null && resTable.Rows[i]["ho_special_yn"].ToString().Equals("Y"))
                        {
                            //dbxBedSpecUseTotal.Text = resTable.Rows[i]["total_bed"].ToString();
                            //dbxBedSpecUse.Text = resTable.Rows[i]["used_bed"].ToString();
                            //dbxBedSpecUseNoUse.Text = (Convert.ToInt32(resTable.Rows[i]["total_bed"]) - Convert.ToInt32(resTable.Rows[i]["used_bed"])).ToString();

                            //아래로 변경 2011.12.06 woo
                            specTotal += Int32.Parse(resTable.Rows[i]["total_bed"].ToString());
                            specUsed += Int32.Parse(resTable.Rows[i]["used_bed"].ToString());
                        }
                        else if (resTable.Rows[i]["ho_sex"] != null && resTable.Rows[i]["ho_sex"].Equals("M"))
                        {
                            dbxBedManTotal.Text = resTable.Rows[i]["total_bed"].ToString();
                            dbxBedManUse.Text = resTable.Rows[i]["used_bed"].ToString();
                            dbxBedManNoUse.Text = (Convert.ToInt32(resTable.Rows[i]["total_bed"]) - Convert.ToInt32(resTable.Rows[i]["used_bed"])).ToString();
                        }
                        else if (resTable.Rows[i]["ho_sex"] != null && resTable.Rows[i]["ho_sex"].Equals("F"))
                        {
                            dbxBedWomanTotal.Text = resTable.Rows[i]["total_bed"].ToString();
                            dbxBedWomanUse.Text = resTable.Rows[i]["used_bed"].ToString();
                            dbxBedWomanNoUse.Text = (Convert.ToInt32(resTable.Rows[i]["total_bed"]) - Convert.ToInt32(resTable.Rows[i]["used_bed"])).ToString();
                        }
                        else
                        {
                            dbxBedEtcTotal.Text = resTable.Rows[i]["total_bed"].ToString();
                            dbxBedEtcUse.Text = resTable.Rows[i]["used_bed"].ToString();
                            if (dbxBedEtcTotal.GetDataValue().Equals("0"))
                            {
                                dbxBedEtcNoUse.Text = (Convert.ToInt32(resTable.Rows[i]["total_bed"]) + Convert.ToInt32(resTable.Rows[i]["used_bed"])).ToString();
                            }
                            else
                            {
                                dbxBedEtcNoUse.Text = (Convert.ToInt32(resTable.Rows[i]["total_bed"]) - Convert.ToInt32(resTable.Rows[i]["used_bed"])).ToString();
                            }
                        }
                        totalBed += Convert.ToInt32(resTable.Rows[i]["total_bed"]);
                        usedBed += Convert.ToInt32(resTable.Rows[i]["used_bed"]);
                    }
                    dbxBedTotal.Text = totalBed.ToString();
                    dbxBedUse.Text = usedBed.ToString();
                    dbxBedNoUse.Text = (totalBed - usedBed).ToString();

                    //추가 2011.12.06 woo
                    this.dbxBedSpecUseTotal.SetDataValue(specTotal.ToString());
                    this.dbxBedSpecUse.SetDataValue(specUsed.ToString());
                    this.dbxBedSpecUseNoUse.SetDataValue((specTotal - specUsed).ToString());
                }

                /* 이동자정보 조회 */
                /*:o_ipwon_today    := C2.IPWON_TODAY;          dbxIpwonToday
                  :o_ipwon_nextday  := C2.IPWON_NEXTDAY;        dbxIpwonNext
                  :o_ipwon_week     := C2.IPWON_NEXTNEXTDAY;    dbxIpwonWeek
                  :o_in_today       := C2.IN_TODAY;             dbxInToDay
                  :o_in_nextday     := C2.IN_NEXTDAY;           dbxInNext
                  :o_in_week        := C2.IN_NEXTNEXTDAY;       dbxInWeek
                  :o_taewon_today   := C2.TOIWON_TODAY;         dbxTaewonToday
                  :o_taewon_nextday := C2.TOIWON_NEXTDAY;       dbxTaewonNext
                  :o_taewon_week    := C2.TOIWON_NEXTNEXTDAY;   dbxTaewonWeek
                  :o_out_today      := C2.OUT_TODAY;            dbxOutToday
                  :o_out_nextday    := C2.OUT_NEXTDAY;          dbxOutNext
                  :o_out_week       := C2.OUT_NEXTNEXTDAY;      dbxOutWeek
                 */
                cmdText = string.Empty;
                resTable.Clear();
                cmdText = @"SELECT NVL(FN_INPS_LOAD_ILSU_ETC('01', :f_ho_dong, TRUNC(SYSDATE)-1),0) IPWON_TODAY
                                 , NVL(FN_INPS_LOAD_ILSU_ETC('01', :f_ho_dong, TRUNC(SYSDATE)),0) IPWON_NEXTDAY
                                 , NVL(FN_INPS_LOAD_ILSU_ETC('03', :f_ho_dong, TRUNC(SYSDATE)-1),0) IPWON_NEXTNEXTDAY
                                 , NVL(FN_INPS_LOAD_ILSU_ETC('04', :f_ho_dong, TRUNC(SYSDATE)-1),0) IN_TODAY
                                 , NVL(FN_INPS_LOAD_ILSU_ETC('05', :f_ho_dong, TRUNC(SYSDATE)-1),0) IN_NEXTDAY
                                 , NVL(FN_INPS_LOAD_ILSU_ETC('06', :f_ho_dong, TRUNC(SYSDATE)-1),0) IN_NEXTNEXTDAY
                                 , NVL(FN_INPS_LOAD_ILSU_ETC('07', :f_ho_dong, TRUNC(SYSDATE)-1),0) TOIWON_TODAY
                                 , NVL(FN_INPS_LOAD_ILSU_ETC('08', :f_ho_dong, TRUNC(SYSDATE)-1),0) TOIWON_NEXTDAY
                                 , NVL(FN_INPS_LOAD_ILSU_ETC('09', :f_ho_dong, TRUNC(SYSDATE)-1),0) TOIWON_NEXTNEXTDAY
                                 , NVL(FN_INPS_LOAD_ILSU_ETC('10', :f_ho_dong, TRUNC(SYSDATE)-1),0) OUT_TODAY
                                 , NVL(FN_INPS_LOAD_ILSU_ETC('11', :f_ho_dong, TRUNC(SYSDATE)-1),0) OUT_NEXTDAY
                                 , NVL(FN_INPS_LOAD_ILSU_ETC('12', :f_ho_dong, TRUNC(SYSDATE)-1),0) OUT_NEXTNEXTDAY
                              FROM DUAL";
                resTable = Service.ExecuteDataTable(cmdText, bindVars);

                if (resTable.Rows.Count > 0)
                {
                    dbxIpwonToday.Text = resTable.Rows[0]["ipwon_today"].ToString();
                    dbxIpwonNext.Text = resTable.Rows[0]["ipwon_nextday"].ToString();
                    dbxIpwonWeek.Text = resTable.Rows[0]["ipwon_nextnextday"].ToString();
                    dbxInToday.Text = resTable.Rows[0]["in_today"].ToString();
                    dbxInNext.Text = resTable.Rows[0]["in_nextday"].ToString();
                    dbxInWeek.Text = resTable.Rows[0]["in_nextnextday"].ToString();
                    dbxTaewonToday.Text = resTable.Rows[0]["toiwon_today"].ToString();
                    dbxTaewonNext.Text = resTable.Rows[0]["toiwon_nextday"].ToString();
                    dbxTaewonWeek.Text = resTable.Rows[0]["toiwon_nextnextday"].ToString();
                    dbxOutToday.Text = resTable.Rows[0]["out_today"].ToString();
                    dbxOutNext.Text = resTable.Rows[0]["out_nextday"].ToString();
                    dbxOutWeek.Text = resTable.Rows[0]["out_nextnextday"].ToString();
                }
                
                //과별 환자 수 조회
                grdGwaCount.QueryLayout(true);

                //병동,병상정보조회후 병상 Control 생성
                if (layHosilList.QueryLayout(false))
                {
                    //병실, 병상  Control 배치
                    ArrangeHoSilBox();
                    //병동환자정보 조회하여 병상 Control에 값 설정
                    if (layPatientList.QueryLayout(false))
                        SetBedBoxProperties();
                }
                else
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                    throw new Exception();
                }

                if (this.ForeBedBox != null)
                {
                    if (this.selectedBedBox != null)
                        this.selectedBedBox.Selected = false;

                    if (ForeBedBox.HoDong == this.cboHoDong.GetDataValue())
                    {
                        this.selectedBedBox = (BedBox)this.bedBoxList[this.ForeBedBox.HoCode + ForeBedBox.BedNumber.ToString()];
                        this.selectedBedBox.Selected = true; //선택상태 변경
                        this.ForeBedBox.Dispose();

                        this.OnBedBoxMouseUp(selectedBedBox, new MouseEventArgs(MouseButtons.Left, 1, selectedBedBox.Left, Top, 0));
                    }
                    else
                    {
                        this.ForeBedBox = null;
                    }
                }

                //공지사항 조회(업무 확정후 반영)

                //전입확인건 체크
                cmdText = string.Empty;
                cmdText = @"SELECT COUNT(1)
                          FROM INP2004 A
                         WHERE A.HOSP_CODE  = :f_hosp_code
                           AND A.START_DATE BETWEEN TO_DATE(:f_order_date, 'YYYY/MM/DD') -1
                                                 AND TO_DATE(:f_order_date, 'YYYY/MM/DD')
                           AND A.TO_HO_DONG1 = :f_ho_dong
                           AND A.CANCEL_YN != 'Y'
                           AND A.TRANS_GUBUN IN('02','04')
                           AND A.TO_NURSE_CONFIRM_DATE IS NULL";
                bindVars.Add("f_order_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")); // f_ho_dong 에 이어, f_order_date 도 add

                retVal = Service.ExecuteScalar(cmdText, bindVars);

                if (!TypeCheck.IsNull(retVal))
                {
                    if (Convert.ToInt32(retVal) > 0)
                    {
                        this.pbxJunip.Visible = true;
                        this.btnJunipConfirm.Enabled = true;
                    }
                    else
                    {
                        this.pbxJunip.Visible = false;
                        this.btnJunipConfirm.Enabled = false;
                    }
                }
                else if (TypeCheck.IsNull(retVal))
                {
                }
                else
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                    throw new Exception();
                }
            }
            catch(Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                this.timer.Enabled = true;
            }
        }

        /// <summary>
        /// 병동 병실정보로 HoSilBox, 기본 BedBox(공병상) 배치
        private void ArrangeHoSilBox()
        {
            // 기존 HoSilBox Clear
            foreach (Control cont in this.hoSilBoxList.Values)
            {
                this.pnlLeft.Controls.Remove(cont);
                //<MEMORY> 2007.10.13 명시적으로 JinryoBox를 Dispose하지 않으면 Event가 연결되어 있어 List에서 Clear시에 Dispose되지 않는다. 반드시 명시적으로 Dispose해야 한다.
                cont.Dispose();
            }
            // 기존 BedBox Clear
            foreach (Control cont in this.bedBoxList.Values)
            {
                this.pnlLeft.Controls.Remove(cont);
                //<MEMORY> 2007.10.13 명시적으로 JinryoBox를 Dispose하지 않으면 Event가 연결되어 있어 List에서 Clear시에 Dispose되지 않는다. 반드시 명시적으로 Dispose해야 한다.
                cont.Dispose();
            }

            //기존 Data Clear
            this.hoSilBoxList.Clear();
            this.bedBoxList.Clear();

            //해당병동의 호실수, 호실별 병상수에 따라 배치
            //한 라인에 총 6개 호실 배치, 한호실에 6개까지 병상 배치가능,  //예전 주석인듯.. 
            //ICU처럼 호실 하나에 병상이 많으면 같은 호실을 두개 이상으로 나눔
            if (this.layHosilList.RowCount < 1) return;

            ArrayList hosilLocationList = new ArrayList();
            HoSilLocation hLocation = null;
            string hoCode, hoCodeName, hoSort, hoStatus, hoSex, double_ho_Yn, next_ho_code, next_ho_sort;  //wingGubun,
            int hoTotalBed = 0, next_hoTotalBed = 0, modifier = 0, remain = 0;
            int startX = LEFT_MARGIN, startY = TOP_MARGIN, totalHoCount = 1, height = 0;
            bool isExceedHoCount = false;

            int bedCntPerHosil = 1;

            //string currentFloor = "";
            // 1인실갯수
            int oneBedRoomCnt = 0;
            int oneBedRoomCntPerLine = 3;
            int floorStartY = startY;

            for (int j = 0; j < this.layHosilList.RowCount; j++ )
            //foreach (DataRow dtRow in this.layHosilList.LayoutTable.Rows)
            {
                hoCode = this.layHosilList.GetItemString(j, "ho_code");
                hoTotalBed = this.layHosilList.GetItemInt(j, "ho_total_bed");
                hoSort = this.layHosilList.GetItemString(j, "ho_sort");

                if (j + 1 < this.layHosilList.RowCount)
                {
                    //다음병실 호코드 담아뒀다가 층확인할때 사용
                    next_ho_code = this.layHosilList.GetItemString(j + 1, "ho_code");
                    next_ho_sort = this.layHosilList.GetItemString(j + 1, "ho_sort");

                    //다음병실 병상수 담아뒀다가 층확인할때 사용
                    next_hoTotalBed = this.layHosilList.GetItemInt(j + 1, "ho_total_bed");
                }
                else
                {
                    next_ho_code = "";
                    next_ho_sort = "";
                    next_hoTotalBed = 0;
                }

                hoStatus = this.layHosilList.GetItemString(j, "ho_status");
                hoSex = this.layHosilList.GetItemString(j, "ho_sex");
                hoCodeName = this.layHosilList.GetItemString(j, "ho_code_name");
                double_ho_Yn = this.layHosilList.GetItemString(j, "double_ho_yn"); 
                //wingGubun = dtRow["wing_gubun"].ToString();

                if (hoTotalBed == 1)
                    oneBedRoomCnt++;
                else
                    oneBedRoomCnt = 0;

                //호실의 총 베드 수가 최대 베드 수 보다 많을 경우엔 최대 베드 수, 아니면 현 베드 수
                bedCntPerHosil = hoTotalBed > MAXBED_PER_HOSIL ? MAXBED_PER_HOSIL : hoTotalBed;

                //if (hoTotalBed > bedCntPerHosil)
                //{
                //    if (hoTotalBed > 5)
                //        bedCntPerHosil = 5;
                //    else
                //        bedCntPerHosil = hoTotalBed;
                //}

                //한 병실을 몇개로 나누어 보여줄지 여부 
                modifier = (hoTotalBed == 0 ? 0 : ((hoTotalBed - 1) / bedCntPerHosil) + 1);
                remain = (hoTotalBed == 0 ? 0 : (hoTotalBed % bedCntPerHosil == 0 ? bedCntPerHosil : hoTotalBed % bedCntPerHosil));

                for (int i = 0; i < modifier; i++)
                {
                    hLocation = new HoSilLocation();
                    hLocation.HoCode = hoCode;
                    hLocation.HoCodeName = hoCodeName;
                    hLocation.HoSex = hoSex;
                    hLocation.Seq = i;
                    hLocation.HoStatus = GetHoSilStatus(hoStatus);
                    //hLocation.wingGubun = GetWingGubun(hoCode.Substring(0,1));

                    hLocation.X = startX;
                    hLocation.Y = startY;
                    hLocation.Width = BEDBOX_FULL_WIDTH;

                    if (modifier == 1)  //한개의 병실로 표시될 때
                    {
                        hLocation.Height = HOSILBOX_TOP_MARGIN + remain * (BEDBOX_HEIGHT + BEDBOX_VERT_GAP) + HOSILBOX_BOTTOM_MARGIN;
                        hLocation.BedCount = remain;  //호실의 병상수 SET
                    }
                    else if (i == modifier - 1)  //2개이상으로 병실로 표시될 때의 마지막 병실
                    {
                        hLocation.Height = HOSILBOX_TOP_MARGIN + remain * (BEDBOX_HEIGHT + BEDBOX_VERT_GAP) + HOSILBOX_BOTTOM_MARGIN;
                        hLocation.BedCount = remain;  //호실의 병상수 SET
                    }
                    else //2개이상일때 꽉차는 호실
                    {
                        hLocation.Height = HOSILBOX_TOP_MARGIN + bedCntPerHosil * (BEDBOX_HEIGHT + BEDBOX_VERT_GAP) + HOSILBOX_BOTTOM_MARGIN;
                        hLocation.BedCount = bedCntPerHosil;  //호실의 병상수 SET
                    }

                    //다음 시작위치는 BedBox의 너비 + HosilBox 간격
                    startX += BEDBOX_FULL_WIDTH + HOSILBOX_GAP;

                    //한라인을 넘었으면 startX위치 처음으로 //Y좌표의 시작위치는 한라인을 넘어선 경우에만 다시 설정

                    
                    // 현업요구에 따라 베드 배치처리 
                    //if (hoCode == "B305")
                    //{
                    //    startX = LEFT_MARGIN;
                    //    startY += HOSILBOX_TOP_MARGIN + bedCntPerHosil * (BEDBOX_HEIGHT + BEDBOX_VERT_GAP) + HOSILBOX_BOTTOM_MARGIN + HOSILBOX_GAP;
                    //    totalHoCount = -1;
                    //}

                    if (totalHoCount % HOCNT_PER_LINE == 0)// || totalHoCount == 11)
                    {
                        startX = LEFT_MARGIN;
                        //기존위치 + 6개가 꽉찬 병실의 높이 + 호실사이의 간격
                        height = bedCntPerHosil * (BEDBOX_HEIGHT + BEDBOX_VERT_GAP);
                        startY += HOSILBOX_TOP_MARGIN + height + HOSILBOX_BOTTOM_MARGIN + HOSILBOX_GAP;
                        floorStartY = startY;

                        bedCntPerHosil = 1;

                    }

                    // 층이 바뀌면 한줄 내려서 그림
                    if (next_ho_sort != "")
                    {
                        //다른층일 때 (ho_sort의 첫번째 = 층, 두번째 = 순번)
                        if (hoSort.Substring(0, 1) != next_ho_sort.Substring(0, 1))
                        {
                            startX = LEFT_MARGIN;                         
                            //기존위치 + 6개가 꽉찬 병실의 높이 + 호실사이의 간격
                            height = MAXBED_PER_HOSIL * (BEDBOX_HEIGHT + BEDBOX_VERT_GAP);
                            //height = 100 * (BEDBOX_HEIGHT + BEDBOX_VERT_GAP);
                            startY = HOSILBOX_TOP_MARGIN + height + HOSILBOX_BOTTOM_MARGIN + HOSILBOX_GAP;
                            floorStartY = startY;

                            bedCntPerHosil = 1;
                            totalHoCount = 0;
                            
                        }
                        else //같은층일경우
                        {
                            // 1인실의경우 두줄or세줄로 표시
                            if (hoTotalBed == 1)
                            {
                                if (next_hoTotalBed == 1)
                                {
                                    if (oneBedRoomCnt % oneBedRoomCntPerLine != 0)
                                    {
                                        // 다음 병실도 1인실일 경우 X값 다시 앞으로 땡겨서
                                        startX -= (BEDBOX_FULL_WIDTH + HOSILBOX_GAP);
                                        //Y값만 밑으로 내려줌
                                        startY += HOSILBOX_TOP_MARGIN + BEDBOX_HEIGHT + BEDBOX_VERT_GAP + 5;

                                        totalHoCount--;
                                    }
                                    else
                                    {
                                        startY = floorStartY;                                        
                                    }   
                                }
                                else
                                {
                                    if (oneBedRoomCnt > 1)
                                        startY = floorStartY;
                                }

                            }
                        }
                    }

                    totalHoCount++;  //전체 호실의 갯수 증가

                    //List에 Add
                    hosilLocationList.Add(hLocation);
                }

                //호실 갯수 초과시 Break
                if (isExceedHoCount) break;
            }

            //생성된 호실정보로 호실 Control 생성
            HoSilBox hoBox = null;
            BedBox bBox = null;
            int bedCnt = 0;

            //각 호실별 병상수에 따라 기본 병상 Box SET
            this.layBedList.Reset();
            if (!layBedList.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }

            foreach (HoSilLocation hs in hosilLocationList)
            {
                hoBox = new HoSilBox();
                if (hs.HoCodeName != "")
                    hoBox.Title = hs.HoCodeName;
                else
                    hoBox.Title = hs.HoCode;

                hoBox.HStatus = hs.HoStatus;
                hoBox.WingGubun = hs.wingGubun;
                hoBox.Size = new Size(hs.Width, hs.Height);
                hoBox.Location = new Point(hs.X, hs.Y);
                hoBox.HSex = hs.HoSex;
                this.pnlLeft.Controls.Add(hoBox);

                //호실Box 관리 List(Hashtable에 Add Key는 HoCode + 순번)
                this.hoSilBoxList.Add(hs.HoCode + hs.Seq.ToString(), hoBox);

                bedCnt = 0;
                foreach (DataRow dr in this.layBedList.LayoutTable.Rows)
                {
                    if (hs.BedCount <= bedCnt)
                        break;

                    if (hs.HoCode != dr["ho_code"].ToString())
                        continue;

                    if (this.bedBoxList.ContainsKey(hs.HoCode + dr["bed_no"].ToString()))
                        continue;

                    bBox = new BedBox();
                    bBox.Size = new Size(BEDBOX_SMALL_WIDTH, BEDBOX_HEIGHT);  //최초 너비는 공병상너비 기준으로 설정
                    //위치는 해당 병실의 HoSilBox 에 위치 (BedBox사이는 2Pixel을 띄움
                    bBox.Location = new Point(hs.X + HOSILBOX_LEFT_MARGIN, hs.Y + HOSILBOX_TOP_MARGIN + (BEDBOX_HEIGHT + BEDBOX_VERT_GAP) * bedCnt);
                    //bBox.Location = new Point(hs.X + HOSILBOX_LEFT_MARGIN, hs.Y + HOSILBOX_TOP_MARGIN + (BEDBOX_HEIGHT + BEDBOX_VERT_GAP)*i);
                    bBox.HoCode = hs.HoCode;  //이 병상의 병실번호 SET
                    bBox.HoSex = hs.HoSex;
                    bBox.HoDong = cboHoDong.GetDataValue();
                    bBox.RTStatus = GetRightTopStatus(dr["team"].ToString());

                    //bBox.BedNumber = hs.Seq*bedCntPerHosil + i + 1; //병상번호 SET (같은 호실에서의 순번*한병실의 BED수 + i + 1(1번부터 시작)
                    bBox.BedNumber = int.Parse(dr["bed_no"].ToString());

                    if(!TypeCheck.IsNull(this.ForeBedBox))
                    {
                        if( (bBox.HoDong == ForeBedBox.HoDong) && (bBox.HoCode == ForeBedBox.HoCode) && (bBox.BedNumber == ForeBedBox.BedNumber))
                        {
                            bBox.Selected = true;
                        }
                    }

                    //환자명DoubleClick, Click Event Set
                    bBox.SuNameDoubleClick += new EventHandler(OnBedBoxSuNameDoubleClick);
                    //BedBox MouseDown,MouseMove Event Set
                    bBox.MouseDown += new MouseEventHandler(OnBedBoxMouseDown);
                    bBox.MouseMove += new MouseEventHandler(OnBedBoxMouseMove); //경계쪽으로 이동 했을 때, 화면도 같이 이동
                    bBox.MouseUp += new MouseEventHandler(OnBedBoxMouseUp);
                    //추가오더발생영역 DoubleClick Event Set
                    bBox.BottomLeftDoubleClick += new EventHandler(OnBedBoxBottomLeftDoubleClick);
                    //MouseEnter, MouseLeave Event Handling (toolTip)
                    bBox.MouseEnter += new EventHandler(OnBedBoxMouseEnter);
                    bBox.MouseLeave += new EventHandler(OnBedBoxMouseLeave);
                    
                    bBox.AllowDrop = true;
                    bBox.DragEnter += new DragEventHandler(OnBedBoxDragEnter);
                    bBox.DragDrop += new DragEventHandler(OnBedBoxDragDrop);                    
                    bBox.GiveFeedback += new GiveFeedbackEventHandler(OnBedBoxGiveFeedback);

                    //병상리스트에 Add, Key는 hoCode + BedNumber(1부터 시작)
                    this.bedBoxList.Add(hs.HoCode + bBox.BedNumber.ToString(), bBox);
                    //pnlLeft에 Controls에 Add
                    pnlLeft.Controls.Add(bBox);
                    bBox.BringToFront();

                    bedCnt++;
                }
            }
        }

        //환자정보를 조회하여 병상Box의 Property 설정
        private void SetBedBoxProperties()
        {
            //환자정보에 따라 병상 배치
            //환자정보는 호실순, 병상번호순으로 조회하여 처리함

            if (this.layPatientList.RowCount < 1) return;

            //조회된 환자정보를 가지고 해당 BedBox의 속성 설정
            string hoCode = "", bedNumber;
            BedBox bBox = null;
            PatientItem pItem = null;
            int bed = 0;
            string sysDate = IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
           
            foreach (DataRow dtRow in this.layPatientList.LayoutTable.Rows)
            {
                if (hoCode != dtRow["ho_code"].ToString())
                    bed = 1;
                else
                    bed++;
                hoCode = dtRow["ho_code"].ToString();
                bedNumber = dtRow["ho_bed"].ToString();

                //bedBoxList의 Key는 병실 + Bed번호
                if (this.bedBoxList.ContainsKey(hoCode + bedNumber))
                {
                    bBox = (BedBox)bedBoxList[hoCode + bedNumber];
                    bBox.Redraw = false; //그리기 중지
                    //BedBox에 보여줄 이름을 한자어로 할지, 가나어로 할지는 미정(일단 한자어로 SET)
                    bBox.Pkinp1001 = int.Parse(dtRow["pkinp1001"].ToString());
                    bBox.Bunho = dtRow["bunho"].ToString();

                    bBox.Kaikei_HoDong = dtRow["kaikei_hodong"].ToString();
                    bBox.Kaikei_HoCode = dtRow["kaikei_hocode"].ToString();

                    bBox.Rgb = dtRow["rgb"].ToString();

                    if (dtRow["yokchang_yn"].ToString() == "Y")
                    {
                        bBox.SuName = "[褥]" + dtRow["suname"].ToString();
                    }
                    else
                    {
                        bBox.SuName = dtRow["suname"].ToString();
                    }

                    if (dtRow["gamyum_yn"].ToString() == "Y")
                    {
                        bBox.SuName = "[感]" + bBox.SuName;
                    }

                    bBox.SexKind = (dtRow["sex"].ToString() == "M" ? HumanSex.Man : HumanSex.Woman);

                    
                    //미래예약데이타 공석처리
                    if (dtRow["reser_gubun"].ToString() == "R" || dtRow["reser_gubun"].ToString() == "B")
                        bBox.BedStatus = GetBedStatus("R");
                    else
                    {
                        //구호구분
                        if (dtRow["guho_gubun"].ToString() != "")
                            bBox.BedStatus = GetBedStatus(dtRow["guho_gubun"].ToString().Substring(0, 1));
                        else
                            bBox.BedStatus = GetBedStatus("");
                    }

//                    bBox.RTStatus = GetRightTopStatus(dtRow["team"].ToString());
                    if (!TypeCheck.IsNull(dtRow["pa_gubun"]))
                        bBox.RBStatus = GetRightBottomStatus(dtRow["pa_gubun"].ToString());
                    if (!TypeCheck.IsNull(dtRow["order_status"]))
                        bBox.BLStatus = GetBottomLeftStatus(dtRow["order_status"].ToString());
                        //bBox.BLStatus = BottomLeftStatus.State2;
                    if (!TypeCheck.IsNull(dtRow["cp_yn"]))
                        bBox.BRStatus = GetBottomRightStatus(dtRow["cp_yn"].ToString());
                    
                    //당일입원
                    if(dtRow["ipwon_today"].ToString() == "Y")
                        bBox.IsTodayIpwon = true;                    

                    ////분만여부
                    //if (dtRow["bunman_yn"].ToString() == "Y")
                    //    bBox.IsBunman = true;

                    //
                    if (dtRow["is_out"].ToString() != "")
                        bBox.IsOut = true;

                    ////인공호흡기
                    //if (dtRow["ingong_yn"].ToString() == "Y")
                    //    bBox.IsIngongYn = true;

                    //비밀로해야하는 환자인지 여부
                    if (dtRow["secret_yn"].ToString() == "Y")
                        bBox.IssecYn = true;

                    //입원목적
                    if (dtRow["ipwon_mokjuk"].ToString() != "")
                    {
                        bBox.IpwonMokjuk = dtRow["ipwon_mokjuk"].ToString();
                    }

                    //해당베드 미래예약여부
                    if (dtRow["ipwon_reser_info"].ToString() != "")
                    {
                        bBox.IsIpwonReser = true;
                        bBox.ReserInfo = dtRow["ipwon_reser_info"].ToString();
                    }

                    //욕창환자여부
                    if (dtRow["yokchang_yn"].ToString() == "Y")
                    {
                        bBox.IsYokchangYn = "Y";
                    }

                    //감염증환자여부
                    if (dtRow["gamyum_yn"].ToString() == "Y")
                    {
                        bBox.IsGamyumYn = "Y";
                    }

                    //오더종료여부
                    if (dtRow["toiwon_goji_yn"].ToString() == "Y")
                    {
                        bBox.ToiwonGojiYn = "Y";
                    }

                    //병상잠금
                    if (dtRow["bed_lock_text"].ToString() != "")
                    {
                        bBox.BedLockText = dtRow["bed_lock_text"].ToString();
                    }

                    //베드상태(청소중..)
                    bBox.BedCStatus = dtRow["bed_status"].ToString();

                    //bBox.toiwonres

                    bBox.ToiwonResDate = dtRow["toiwon_res_date"].ToString();

                    //Status
                    if (dtRow["status_flag1"].ToString() == "Y")
                        bBox.Status_Flag1 = true;
                    if (dtRow["status_flag2"].ToString() == "Y")
                        bBox.Status_Flag2 = true;
                    if (dtRow["status_flag3"].ToString() == "Y")
                        bBox.Status_Flag3 = true;
                    if (dtRow["status_flag4"].ToString() == "Y")
                        bBox.Status_Flag4 = true;
                    if (dtRow["status_flag5"].ToString() == "Y")
                        bBox.Status_Flag5 = true;
                    
                    //투약 여부
                    bBox.Not_yet_drg_date = dtRow["not_yet_drg_date"].ToString();

                    //Tag에 PatientItem(환자정보 Item SET)
                    pItem = new PatientItem();
                    pItem.Bunho = dtRow["bunho"].ToString();
                    pItem.Suname = dtRow["suname"].ToString();
                    pItem.Suname2 = dtRow["suname2"].ToString();
                    pItem.Pkinp1001 = dtRow["pkinp1001"].ToString();
                    pItem.BirthDate = dtRow["birth_date"].ToString();
                    pItem.SexAge = dtRow["sex_age"].ToString();
                    pItem.IpwonDate = dtRow["ipwon_date"].ToString();
                    pItem.JaewonNalsu = dtRow["jaewon_nalsu"].ToString();
                    pItem.GwaName = dtRow["gaw_name"].ToString();
                    pItem.DoctorName = dtRow["doctor_name"].ToString();
                    pItem.ResidentName = dtRow["resident_name"].ToString();
                    pItem.NurseName = dtRow["nurse_name"].ToString();
                    pItem.SangName = dtRow["sang_name"].ToString();
                    pItem.Ganhodo = dtRow["ganhodo"].ToString();
                    pItem.Life_self_grade = dtRow["life_self_grade"].ToString();
                    pItem.IpwonMokjuk = dtRow["ipwon_mokjuk"].ToString();

                    if (dtRow["ipwon_reser_info"].ToString() != "")
                        pItem.ReserInfo = dtRow["ipwon_reser_info"].ToString();

                    pItem.ToiwonResDate = dtRow["toiwon_res_date"].ToString();
                    pItem.ToiwonResTime = dtRow["toiwon_res_time"].ToString();
                    pItem.BedStatus = dtRow["bed_status"].ToString();
                    pItem.YokchangYn = dtRow["yokchang_yn"].ToString();
                    pItem.GamyumYn = dtRow["gamyum_yn"].ToString();
                    pItem.GamyumName = dtRow["gamyum_name"].ToString();
                    pItem.IsOut = dtRow["is_out"].ToString();
                    pItem.NotYetDrgDate = dtRow["not_yet_drg_date"].ToString();


                    //Status Flag Text 
                    for (int i = 1; i <= 5; i++)
                    {
                        if (dtRow["status_flag"+i.ToString()].ToString() == "Y")
                        {
                            pItem.Status_Flag_Text += dtRow["status_flag"+ i.ToString() + "_name"].ToString() + ", ";
                        }
                    }
                    if (pItem.Status_Flag_Text != "")
                    {
                        pItem.Status_Flag_Text = pItem.Status_Flag_Text.Substring(0, pItem.Status_Flag_Text.LastIndexOf(","));
                    }

                    if (dtRow["bed_lock_text"].ToString() != "")
                        pItem.BedLockText = dtRow["bed_lock_text"].ToString();
                    bBox.Tag = pItem;
                    bBox.Redraw = true; //다시 그림          
          
                    //bBox.BedBoxPaint();
                }
            }
        }
        #endregion

        #region Data -> Enum으로 변경
        //호실의 성격(현재는 1.일반실, 2.특실로만 처리함)
        private HoSilStatus GetHoSilStatus(string hoStatus)
        {
            HoSilStatus hStatus = HoSilStatus.General;
            switch (hoStatus)
            {
                case "2":
                    hStatus = HoSilStatus.Special;
                    break;
                case "3":
                    hStatus = HoSilStatus.Other;
                    break;
            }
            return hStatus;
        }
        private WingGubun GetWingGubun(string wingGubun)
        {
            WingGubun wGubun = WingGubun.State1;
            switch (wingGubun)
            {
                case "H": //HCU
                    wGubun = WingGubun.State1;
                    break;
                case "E": //동
                    wGubun = WingGubun.State2;
                    break;
                case "W": //서
                    wGubun = WingGubun.State3;
                    break;
                case "S": //남
                    wGubun = WingGubun.State4;
                    break;
                case "N": //북
                    wGubun = WingGubun.State5;
                    break;
                case "G": //기타
                    wGubun = WingGubun.State6;
                    break;
                case "O": //신관, 구관
                    wGubun = WingGubun.State7;
                    break;
            }
            return wGubun;
        }
        //병상의 성격 (환자성격에 따라 구분)
        private BedStatus GetBedStatus(string guho_gubun)
        {
            BedStatus status = BedStatus.State1;//공석;
            //미래예약데이타 공석처리
            if (guho_gubun == "R")
            {
                status = BedStatus.State1;  //공석
            }
            else
            {
                status = BedStatus.State2;  //독보
                switch (guho_gubun)
                {

                    case "2"://호송
                        status = BedStatus.State3;
                        break;
                    case "1"://단송
                        status = BedStatus.State4;
                        break;
                    default:
                        status = BedStatus.State2;
                        break;
                }
            }

            return status;
        }
        //간호팀 구분에 따라 오른쪽 위의 상태 SET
        private RightTopStatus GetRightTopStatus(string team)
        {
            RightTopStatus status = RightTopStatus.State1; //A.팀 (Red)
            switch (team)
            {
                case "B":
                    status = RightTopStatus.State2;  //Blue
                    break;
                case "C":
                    status = RightTopStatus.State3;  //Yellow
                    break;
                case "D":
                    status = RightTopStatus.State4;  //Green
                    break;
                case "E":
                    status = RightTopStatus.State5;  //Pink
                    break;
            }
            return status;
        }
        //환자유형에 따라 오른쪽 아래 상태 SET(확정후 변경필요)
        private RightBottomStatus GetRightBottomStatus(string paGubun)
        {
            //환자유형에 따라 정보 설정(환자유형 2자리중 앞자리에 따라 자보,산재등을 구분함으로 한자리로 비교하여 SET)
            //1.국민보험, 2.노인보험, 3.노재,4.자동차보험,5.일반, 그외 6.기타 하트라이프
            //1.국민보험, 2.사보, 3.자동차보험, 5.노재, 그외 6.기타 오카다
            RightBottomStatus status = RightBottomStatus.State1;
            switch (paGubun[0])
            {
                case '1':
                    //status = RightBottomStatus.State5;
                    status = RightBottomStatus.State1;
                    break;
                case '2':
                    status = RightBottomStatus.State2;
                    break;
                case '3':
                    status = RightBottomStatus.State3;
                    break;
                case '4':
                    status = RightBottomStatus.State4;
                    break;
                case '5':
                    status = RightBottomStatus.State5;
                    break;
                default:
                    status = RightBottomStatus.State6;
                    break;
            }
            return status;
        }
        //추가오더 존재여부에 따라 왼쪽아래 상태 SET
        private BottomLeftStatus GetBottomLeftStatus(string orderStatus)
        {
            //환자 Order상태에 따라 State설정
            //첫번째는 Order존재여부(Y/N), 두번째는 확인여부(YN)
            //따라서 YN이면 Order가 존재하는데 간호사 미확인이므로 State2로 설정
            BottomLeftStatus status = BottomLeftStatus.State1;  //기본 N. LightYello
            switch (orderStatus)
            {
                case "Y1":
                    status = BottomLeftStatus.State2; //당일 오더 확인이 필요한 환자
                    break;
                case "Y2":
                    status = BottomLeftStatus.State3; //추후 오더 확인이 필요한 환자
                    break;
            }
            return status;
        }
        //CP환자여부에 따라 오른쪽아래 상태 SET
        private BottomRightStatus GetBottomRightStatus(string cpYn)
        {
            BottomRightStatus status = BottomRightStatus.State1;  //Cp환자여부 기본 N. MintCream
            switch (cpYn)
            {
                case "Y":
                    status = BottomRightStatus.State2; //Y.Lime
                    break;
            }
            return status;
        }
        #endregion

        #region BedBox EventHandler
        private bool canDrag = false;
        private int dragPointX = 0;
        private int dragPointY = 0;
        private Font dragFont = new Font("MS UI Gothic", 10.0f);
        private void OnBedBoxMouseDown(object sender, MouseEventArgs e)
        {
            //Left Click이고 BedBox의 병상상태가 환자가 있으면(Status1이 아니면)
            BedBox bBox = (BedBox)sender;

            //기존 선택된 Box 선택상태 변경
            if (this.selectedBedBox != null)
                this.selectedBedBox.Selected = false;


            //선택된 BedBox를 SET
            this.selectedBedBox = (BedBox)sender;
            this.selectedBedBox.Selected = true; //선택상태 변경

            if (bBox.BedStatus != BedStatus.State1)
            {
                ////기존 선택된 Box 선택상태 변경
                //if (this.selectedBedBox != null)
                //    this.selectedBedBox.Selected = false;

                ////선택된 BedBox를 SET
                //this.selectedBedBox = (BedBox)sender;
                //this.selectedBedBox.Selected = true; //선택상태 변경

                //Drag관련 변수 SET
                canDrag = true;
                dragPointX = e.X;
                dragPointY = e.Y;
            }
        }
        private void OnBedBoxMouseMove(object sender, MouseEventArgs e)
        {
            BedBox bBox = (BedBox)sender;
            //Left인 상태에서 Move시
            if ((e.Button == MouseButtons.Left) && (bBox.BedStatus != BedStatus.State1) && canDrag && (Math.Abs(e.X - dragPointX) > 3 || Math.Abs(e.Y - dragPointY) > 3))
            {
                canDrag = false;
                //코드로 DragCursor Create
                DragHelper.CreateDragCursor(bBox, bBox.SuName, dragFont);
                bBox.DoDragDrop(bBox, DragDropEffects.Move);
            }
        }
        private void OnBedBoxDragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            //BedBox Drag시 Drag상태 유지
            if (e.Data.GetDataPresent(typeof(IHIS.NURI.BedBox)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void OnBedBoxGiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }
        private void OnBedBoxDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            try
            {
                //DragDrop시에 
                BedBox dragBed = null;
                if (e.Data.GetDataPresent(typeof(IHIS.NURI.BedBox)))
                    dragBed = e.Data.GetData(typeof(IHIS.NURI.BedBox)) as BedBox;

                if (dragBed == null) return;

                BedBox dropBed = (BedBox)sender;

                //동일한 병실,병상이면 Return
                if ((dragBed.HoCode == dropBed.HoCode) && (dragBed.BedNumber == dropBed.BedNumber)) return;

                string title = (NetInfo.Language == LangMode.Ko ? "이동확인" : "移動確認");
                string msg = "";
                string drag_suname = "";
                string drop_suname = "";

                if (dragBed != null)
                {
                    //병실 성별 체크.
                    if (dropBed.HoSex != "" && (dropBed.HoSex == "M" ? HumanSex.Man : HumanSex.Woman) != dragBed.SexKind)
                    {
                        //msg = (NetInfo.Language == LangMode.Ko ? (dragBed.SexKind == HumanSex.Man ? "남성환자를 여성병실로 이동할 수 없습니다." : "여성환자를 남성병실로 이동할 수 없습니다.")
                        //    : (dragBed.SexKind == HumanSex.Man ? "男性患者は女性病室に移動できません。" : "女性患者は男性病室に移動できません。"));
                        msg = dragBed.SexKind == HumanSex.Man ? "移動先の病室が女性部屋です。\r\n" : "移動先の病室が男性部屋です。\r\n";
                        //msg += "\r\nこのまま移動しますか。";
                        //DialogResult dr = XMessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        //if(dr == DialogResult.No)
                        //    return;
                    }
                    drag_suname = dragBed.SuName;

                    if (dragBed.IsYokchangYn == "Y")
                    {
                        drag_suname = drag_suname.Replace("[褥]", "");
                    }

                    if (dragBed.IsGamyumYn == "Y")
                    {
                        drag_suname = drag_suname.Replace("[感]", "");
                    }

                    drag_suname = "「" + drag_suname + "」";

                    if (dragBed.ToiwonGojiYn == "Y")
                    {
                        msg = (NetInfo.Language == LangMode.Ko ? "오더종료처리되어 이동할 수 없습니다.." : drag_suname + "さんはオーダ終了処理されているので移動できません。");
                        XMessageBox.Show(msg, title, MessageBoxIcon.Information);
                        return;                    
                    }

                    drop_suname = dropBed.SuName;

                    if (dropBed.IsYokchangYn == "Y")
                    {
                        drop_suname = drop_suname.Replace("[褥]", "");
                    }

                    if (dropBed.IsGamyumYn == "Y")
                    {
                        drop_suname = drop_suname.Replace("[感]", "");
                    }

                    drop_suname = "「" + drop_suname + "」";

                    if (dropBed.ToiwonGojiYn == "Y")
                    {
                        msg = (NetInfo.Language == LangMode.Ko ? "오더종료처리되어 이동할 수 없습니다.." : drop_suname + "さんはオーダ終了処理されているので移動できません。");
                        XMessageBox.Show(msg, title, MessageBoxIcon.Information);
                        return;

                    }

                }

                //DropBed가 공상이면 change
                if (dropBed.BedStatus == BedStatus.State1)
                {
                    //전실,전Bed여부 확인
                    msg += (NetInfo.Language == LangMode.Ko ? drag_suname + "님을" + dropBed.HoCode + "병실 " + dropBed.BedNumber.ToString() + "호로 이동하시겠습니까?"
                        : drag_suname + "さんを" + dropBed.HoCode + "病室 " + dropBed.BedNumber.ToString() + "病床に移動しますか?");

                    if (XMessageBox.Show(msg, title, MessageBoxButtons.YesNo) != DialogResult.Yes) return;

                    //전과,전실처리 (과,주치의,병동은 바꾸지 않고 병실,Bed만 변경함)
                    this.mMovePkInp1001 = ((PatientItem)dragBed.Tag).Pkinp1001;
                    //HoCode가 다르면 변경 병실 SET
                    if (dragBed.HoCode != dropBed.HoCode)
                        this.mMoveHoCode = dropBed.HoCode;
                    else
                        this.mMoveHoCode = "";
                    this.mMoveHoBed = dropBed.BedNumber.ToString(); //병상번호 SET

                    /*
                     * 병상이동 시 간호사 아이디 확인 
                     */
                    if (!CheckNurseID())
                        return;
                    
                    //if ((dropBed.SexKind != dragBed.SexKind) || (dropBed.HoSex != ""))
                    //{
                    //    msg = (NetInfo.Language == LangMode.Ko ? "성별이 다른 병실로 이동할 수 없습니다."
                    //        : "性別が異なる病室に転室できません");
                    //    XMessageBox.Show(msg, title, MessageBoxButtons.OK);
                    //    return;
                    //}

                    //* MoveHosil()
                    if (MoveHosil(dragBed, dropBed))
                    {
                        //전과,전실 성공시 다시 Refresh (전과전실 업무 확정후 반영하기, 일단 TEST로 변경해봄)
                        //DragBed와 DrapBed 위치 변경
                        dragBed.Redraw = false;
                        dropBed.Redraw = false;
                        dropBed.SuName = dragBed.SuName;
                        dropBed.Pkinp1001 = dragBed.Pkinp1001;
                        dropBed.Bunho = dragBed.Bunho;
                        dropBed.SexKind = dragBed.SexKind;
                        dropBed.BedCStatus = dragBed.BedCStatus;
                        dropBed.BedStatus = dragBed.BedStatus;
                        dropBed.RTStatus = dragBed.RTStatus;
                        dropBed.RBStatus = dragBed.RBStatus;
                        dropBed.BLStatus = dragBed.BLStatus;
                        dropBed.BRStatus = dragBed.BRStatus;
                        dropBed.Tag = dragBed.Tag;

                        //DragBed Clear
                        dragBed.SuName = "";
                        dragBed.Pkinp1001 = 0;
                        dragBed.Bunho = "";
                        dragBed.BedStatus = BedStatus.State1;
                        dragBed.RTStatus = RightTopStatus.State1;
                        dragBed.RBStatus = RightBottomStatus.State1;
                        dragBed.BLStatus = BottomLeftStatus.State1;
                        dragBed.BRStatus = BottomRightStatus.State1;
                        dragBed.Tag = null;

                        //Select Clear
                        dragBed.Selected = false;
                        dropBed.Selected = true;
                        dragBed.Redraw = true;
                        dropBed.Redraw = true;

                        //선택된 Bed 설정
                        this.selectedBedBox = dropBed;

                        /* 재 조회 처리 */
                        ExecuteQuery();
                    }
                }
                /*병상교체*/
                else
                {                    
                    if (dragBed.Bunho.ToString() == dropBed.Bunho.ToString())
                    {
                        //전실,전Bed여부 확인
                        msg = (NetInfo.Language == LangMode.Ko ? dragBed.SuName + "님을" + "하이케어실로부터 귀실 처리를 하겠습니까?"
                            : drag_suname + "さんを " + "ハイケア室からの帰室処理をしますか？");
                        if (XMessageBox.Show(msg, title, MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                    }
                    else
                    {
                        //전실,전Bed여부 확인
                        msg = (NetInfo.Language == LangMode.Ko ? dragBed.SuName + "님을" + dropBed.HoCode + "병실 " + dropBed.BedNumber.ToString() + "호로 이동하시겠습니까?"
                            : drag_suname + "さんと" + drop_suname + "さんの病床を変更しますか?");
                        if (XMessageBox.Show(msg, title, MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                    }

                    //전과,전실처리 (과,주치의,병동은 바꾸지 않고 병실,Bed만 변경함)
                    this.mMovePkInp1001 = ((PatientItem)dragBed.Tag).Pkinp1001;
                    //HoCode가 다르면 변경 병실 SET
                    if (dragBed.HoCode != dropBed.HoCode)
                        this.mMoveHoCode = dropBed.HoCode;
                    else
                        this.mMoveHoCode = "";
                    this.mMoveHoBed = dropBed.BedNumber.ToString(); //병상번호 SET

                    /*
                     * 병상이동 시 간호사 아이디 확인 
                     */
                    if (!CheckNurseID())
                        return;

                    //전과,전실 성공시 다시 Refresh (전과전실 업무 확정후 반영하기, 일단 TEST로 변경해봄)
                    //if (this.DataServiceCall(this.dsvChangeHosil))
                    if(ChangeHosil(dragBed, dropBed))
                    {
                        //DragBed와 DrapBed 위치 변경
                        dragBed.Redraw = false;
                        dropBed.Redraw = false;

                        BedBox changeBed = new BedBox();
                        changeBed.SuName = dropBed.SuName;
                        changeBed.Pkinp1001 = dropBed.Pkinp1001;
                        changeBed.Bunho = dropBed.Bunho;
                        changeBed.SexKind = dropBed.SexKind;
                        changeBed.BedStatus = dropBed.BedStatus;
                        changeBed.RTStatus = dropBed.RTStatus;
                        changeBed.RBStatus = dropBed.RBStatus;
                        changeBed.BLStatus = dropBed.BLStatus;
                        changeBed.BRStatus = dropBed.BRStatus;
                        changeBed.Tag = dropBed.Tag;

                        dropBed.SuName = dragBed.SuName;
                        dropBed.Pkinp1001 = dragBed.Pkinp1001;
                        dropBed.Bunho = dragBed.Bunho;
                        dropBed.SexKind = dragBed.SexKind;
                        dropBed.BedStatus = dragBed.BedStatus;
                        dropBed.RTStatus = dragBed.RTStatus;
                        dropBed.RBStatus = dragBed.RBStatus;
                        dropBed.BLStatus = dragBed.BLStatus;
                        dropBed.BRStatus = dragBed.BRStatus;
                        dropBed.Tag = dragBed.Tag;

                    //    //DragBed Clear
                        dragBed.SuName = changeBed.SuName;
                        dragBed.Pkinp1001 = changeBed.Pkinp1001;
                        dragBed.Bunho = changeBed.Bunho;
                        dragBed.SexKind = changeBed.SexKind;
                        dragBed.BedStatus = changeBed.BedStatus;
                        dragBed.RTStatus = changeBed.RTStatus;
                        dragBed.RBStatus = changeBed.RBStatus;
                        dragBed.BLStatus = changeBed.BLStatus;
                        dragBed.BRStatus = changeBed.BRStatus;
                        dragBed.Tag = changeBed.Tag;

                    //    //Select Clear
                        dragBed.Selected = false;
                        dropBed.Selected = true;
                        dragBed.Redraw = true;
                        dropBed.Redraw = true;

                    //    //선택된 Bed 설정
                        this.selectedBedBox = dropBed;

                    //    /* 재 조회 처리 */
                        ExecuteQuery();
                    }
                }
            }
            catch (Exception xe)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("OnBedBoxDragDrop Error = " + xe.Message + "\n\r " + xe.StackTrace, "エラー", MessageBoxIcon.Hand);
            }
        }

        private void OnBedBoxSuNameDoubleClick(object sender, EventArgs e)
        {
            //이름 Double Click시에 환자상세 정보내역 조회(확정필요)
            BedBox bBox = (BedBox)sender;
        }
        private void OnBedBoxBottomLeftDoubleClick(object sender, EventArgs e)
        {
            //추가Order발생 역역 Click시에 간호확인 화면 Open(확정필요)
            BedBox bBox = (BedBox)sender;
        }
        private void OnBedBoxMouseEnter(object sender, EventArgs e)
        {
            //MouseEnter시에 환자정보 ToolTop Display(세부내역은 확정필요)
            BedBox bBox = (BedBox)sender;
            //공상이 아니면 ToolTip Set

            //if (bBox.BedStatus == BedStatus.General) //공상
            //{
            //    this.toolTip1.SetToolTip(bBox, "");
            //}
            //else
            //{
            string text = "";

            if (bBox == null)
                return;

            //Tag에 저장된 PatientItem에서 정보 Get
            PatientItem pItem = (PatientItem)bBox.Tag;

            if (pItem == null)
                return;

            if (pItem.Bunho != "")
                text += "患者番号 : " + pItem.Bunho + "\n";
            if (pItem.BirthDate != "")
                text += "生年月日 : " + pItem.BirthDate + " (" + pItem.SexAge + ")" + "\n";
            if (pItem.IpwonDate != "")
                text += "入院日 : " + pItem.IpwonDate + " (" + pItem.JaewonNalsu + "日)" + "\n";
            if (pItem.GwaName != "")
                text += "診療科 : " + pItem.GwaName + "\n";
            if (pItem.DoctorName != "")
                text += "主治医 : " + pItem.DoctorName + "\n";
            //if (pItem.ResidentName != "")
            //    text += "担当医 : " + pItem.ResidentName + "\n";
            if (pItem.NurseName != "")
                text += "担当看護師 :" + pItem.NurseName + "\n";
            if (pItem.SangName != "")
                text += "疾病名 : " + pItem.SangName + "\n";
            if (pItem.GamyumName != "")
                text += "感染症 : " + pItem.GamyumName + "\n";
            if (pItem.ReserInfo != "")
                text += "予約 : " + pItem.ReserInfo + "\n";

            if (pItem.Status_Flag_Text != "")
                text += "管理 : " + pItem.Status_Flag_Text + "\n";

            if (pItem.IsOut != "")
                text += "外出中 : " + pItem.IsOut + "まで\n";

            if (pItem.NotYetDrgDate != "")
                text += "未投与日 : " + pItem.NotYetDrgDate + "\n";

            if (pItem.BedLockText != "")
                text += pItem.BedLockText + "\n";
            if (text != "")
                text = text.Substring(0, text.Length - 1); //마지막 NL 제거

            this.toolTip1.SetToolTip(bBox, text);
            //}
        }
        private void OnBedBoxMouseLeave(object sender, EventArgs e)
        {
            BedBox bBox = (BedBox)sender;
            //ToolTip Clear
            this.toolTip1.SetToolTip(bBox, "");
            //this.toolTip1.Active = false;
        }

        string mIpwonDate = "";
        string mGwa = "";
        string mDoctor = "";
        private void OnBedBoxMouseUp(object sender, MouseEventArgs e)
        {
            BedBox bBox = (BedBox)sender;

            this.txtCmmt.Text = "";
            this.mIpwonDate = "";
            this.mGwa = ""; 
            this.mDoctor = "";

            string text = "";
            //Tag에 저장된 PatientItem에서 정보 Get

            if (bBox.Tag != null)
            {
                PatientItem pItem = (PatientItem)bBox.Tag;
                if (pItem.Bunho != "")
                    text += "患者番号 : " + pItem.Bunho + "\r\n";
                if (pItem.Suname != "")
                    text += "患者氏名 : " + pItem.Suname + "\r\n";
                if (pItem.BirthDate != "")
                    text += "生年月日 : " + pItem.BirthDate + " (" + pItem.SexAge + ")" + "\r\n";
                if (pItem.IpwonDate != "")
                {
                    text += "入院日 : " + pItem.IpwonDate + " (" + pItem.JaewonNalsu + "日)" + "\r\n";
                    mIpwonDate = pItem.IpwonDate;
                }
                if (pItem.GwaName != "")
                {
                    text += "診療科 : " + pItem.GwaName + "\r\n";
                    this.mGwa = "";
                }
                if (pItem.DoctorName != "")
                    text += "主治医 : " + pItem.DoctorName + "\r\n";
                if (pItem.NurseName != "")
                    text += "担当看護師 :" + pItem.NurseName + "\r\n";
                if (pItem.SangName != "")
                    text += "疾病名 : " + pItem.SangName + "\r\n";
                if (pItem.Ganhodo != "")
                    text += "看護度 : " + pItem.Ganhodo + "\r\n";
                if (pItem.Life_self_grade != "")
                    text += "日常生活自立度 : " + pItem.Life_self_grade + "\r\n";
                if (pItem.IpwonMokjuk != "")
                    text += "入院目的 : " + pItem.IpwonMokjuk + "\r\n";

                if (pItem.ToiwonResDate != "")
                    text += "退院予定日 : " + pItem.ToiwonResDate + "\r\n";
                
                //if (pItem.ToiwonResTime != "")
                //    text += "退院予告時間 : " + pItem.ToiwonResTime.Substring(0, 2) + ":" + pItem.ToiwonResTime.Substring(2, 2) + "\r\n";

                if (pItem.GamyumYn == "Y")
                    text += "感染症 : " + pItem.GamyumName + "\r\n"; 

                if (pItem.ReserInfo != "")
                    text += "予約情報 : " + pItem.ReserInfo + "\r\n";

                if (pItem.Status_Flag_Text != "")
                    text += "管理項目 : " + pItem.Status_Flag_Text + "\r\n";

                if (pItem.IsOut != "")
                    text += "外出中 : " + pItem.IsOut + "　帰院予定\r\n";

                if (pItem.NotYetDrgDate != "")
                    text += "未投与日 : " + pItem.NotYetDrgDate + "\n";

                if (pItem.BedLockText != "")
                    text += pItem.BedLockText;

                this.mDoctor = "";
                if(!TypeCheck.IsNull(selectedBedBox))
                {
                    this.mDoctor = layPatientList.LayoutTable.Select("pkinp1001 = '" + selectedBedBox.Pkinp1001.ToString() + "'")[0]["doctor"].ToString();
                }

                this.txtCmmt.Text = text;

                //공상이 아니면
                if (bBox.BedStatus != BedStatus.State1)
                {
                    //Left인 상태에서 Move시
                    if ((e.Button == MouseButtons.Right))
                    {
                        //메뉴초기화
                        popMenu.MenuCommands.Clear();

                        //PopupMenu 메뉴 구성  //Tag에 Code 저장
                        IHIS.X.Magic.Menus.MenuCommand menuCmd = null;

                        foreach (JobItem item in jobCodeList)
                        {
                            //PopupMenu 구성, Tag에 JobItem 보관
                            menuCmd = new IHIS.X.Magic.Menus.MenuCommand(item.CodeName, (Image)jobImageList.Images[item.Code], new EventHandler(OnPopMenuClick));
                            menuCmd.Tag = item;

                            popMenu.MenuCommands.Add(menuCmd);

                            //중환자실이 아닌 경우 중환자실 관리메뉴 false
                            string hodong = this.cboHoDong.GetDataValue().ToString();
                            if (hodong == "ICU" || hodong == "MICU" || hodong == "NICU" || hodong == "SICU"
                                || hodong == "CCU")
                            {
                            }
                            else
                            {
                                if (item.Code == 7)
                                    menuCmd.Enabled = false;
                            }
                        }
                        popMenu.TrackPopup(bBox.PointToScreen(new Point(e.X, e.Y)));
                    }
                }
                else
                //공상이면 베드상태 변경 팝업메뉴
                {
                    //Left인 상태에서 Move시
                    if ((e.Button == MouseButtons.Right))
                    {
                        bedStatusList.Clear();
                        //청소중세팅
                        bedStatusList.Add(new JobItem(17, "清掃中", bBox.HoCode, bBox.BedNumber.ToString().PadLeft(2, '0')));
                        bedStatusList.Add(new JobItem(18, "空床", bBox.HoCode, bBox.BedNumber.ToString().PadLeft(2, '0')));
                        
                        //병상잠금
                        bedStatusList.Add(new JobItem(30, "病床ロック", bBox.HoCode, bBox.BedNumber.ToString().PadLeft(2, '0')));
                        bedStatusList.Add(new JobItem(31, "病床ロック解除", bBox.HoCode, bBox.BedNumber.ToString().PadLeft(2, '0')));
                                

                        //메뉴초기화
                        popMenu.MenuCommands.Clear();

                        //PopupMenu 메뉴 구성  //Tag에 Code 저장
                        IHIS.X.Magic.Menus.MenuCommand menuCmd = null;

                        foreach (JobItem item in bedStatusList)
                        {
                            //PopupMenu 구성, Tag에 JobItem 보관
                            menuCmd = new IHIS.X.Magic.Menus.MenuCommand(item.CodeName, (Image)jobImageList.Images[item.Code], new EventHandler(OnPopMenuClick));
                            menuCmd.Tag = item;

                            popMenu.MenuCommands.Add(menuCmd);

                            //청소중
                            if (bBox.BedCStatus == "04")
                            {
                                if (item.Code == 17)
                                    menuCmd.Enabled = false;
                                if (item.Code == 30)
                                    menuCmd.Enabled = false;
                                if (item.Code == 31)
                                    menuCmd.Enabled = false;
                            }
                            //공상
                            else
                            {
                                if (item.Code == 18)
                                    menuCmd.Enabled = false;

                                //병상잠금중
                                if (bBox.BedCStatus == "05")
                                {
                                    if (item.Code == 17)
                                        menuCmd.Enabled = false;
                                    if (item.Code == 18)
                                        menuCmd.Enabled = false;
                                    if (item.Code == 30)
                                        menuCmd.Enabled = false;
                                }
                                else
                                {
                                    if (item.Code == 31)
                                        menuCmd.Enabled = false;
                                }
                            }
                        }
                        popMenu.TrackPopup(bBox.PointToScreen(new Point(e.X, e.Y)));
                    }
                }
            }
        }
        #endregion

        #region 병상설명 Display
        private bool shownHelpImage = false;
        private void btnHelp_Click(object sender, System.EventArgs e)
        {
            //병상상태 설명 Image Show
            if (shownHelpImage)
                this.pbxHelp.Visible = false;
            else
            {
                this.pbxHelp.Visible = true;
                this.pbxHelp.BringToFront();
            }

            shownHelpImage = !shownHelpImage;

        }
        #endregion

        #region 병동 변경시에 해당 병동내역 조회
        private void cboHoDong_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.cboHoDong.GetDataValue().ToString() == "") return;

            if (this.cboGwa.GetDataValue().ToString() == "") return;

            if (this.cboHoDong.GetDataValue() == "C3")
                btnADLWork.Visible = true;
            else
                btnADLWork.Visible = false;

            this.cboGwa.SetEditValue("%");
            this.cboGwa.AcceptData();
            ExecuteQuery();
            pnlLeft.Focus();
        }
        #endregion

        #region PopupMenu Handling
        private void OnPopMenuClick(object sender, EventArgs e)
        {
            //Tag에 저장된 JobItem Get
            JobItem item = (JobItem)((IHIS.X.Magic.Menus.MenuCommand)sender).Tag;

            string msg = "";

            this.timer.Enabled = false;

            CommonItemCollection cic = new CommonItemCollection();

            switch (item.Code.ToString())
            {
                case "0"://병동환자관리
                    cic.Add("bunho", this.selectedBedBox.Bunho);

                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR1001U00", ScreenOpenStyle.PopUpFixed, cic);
                    break;
                case "1"://욕창환자관리

                    cic.Add("bunho", this.selectedBedBox.Bunho);
                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR6011U01", ScreenOpenStyle.PopUpFixed, cic);
                    break;
                case "2"://담당간호사

                    cic.Add("bunho", this.selectedBedBox.Bunho);
                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR1010U00", ScreenOpenStyle.ResponseFixed, cic);
                    break;
                case "3"://바이탈사인조회
                    cic.Add("date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    cic.Add("bunho", this.selectedBedBox.Bunho);
                    cic.Add("hodong", this.selectedBedBox.HoDong);
                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR1020Q00", ScreenOpenStyle.PopUpFixed, cic);
                    break;
                case "4"://전과전실

                    cic.Add("bunho", this.selectedBedBox.Bunho);
                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR2004U00", ScreenOpenStyle.ResponseFixed, cic);
                    break;
                case "5"://투약기록
                    cic.Add("bunho", this.selectedBedBox.Bunho);
                    cic.Add("order_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR2017U01", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopCenter, cic);
                    break;
                case "6"://외출외박관리
                    cic.Add("bunho", this.selectedBedBox.Bunho);
                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR1014U00", ScreenOpenStyle.ResponseFixed, cic);
                    break;
                //case "7"://ICU환자관리
                //    cic.Add("bunho", this.selectedBedBox.Bunho);
                //    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR8001U00", ScreenOpenStyle.ResponseFixed, cic);
                //    break;
                //case "8"://조산기록등록

                //    IHIS.Framework.XScreen.OpenScreen(this, "NUR5001U00", ScreenOpenStyle.PopUpFixed);
                //    break;
                case "9"://간호경과기록
                    cic.Add("bunho", this.selectedBedBox.Bunho);
                    cic.Add("record_date", IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    cic.Add("fkinp1001", this.selectedBedBox.Pkinp1001);

                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR9001U00", ScreenOpenStyle.PopUpFixed, cic);
                    break;
                case "10"://간호계획관리
                    cic.Add("bunho", this.selectedBedBox.Bunho);
                    cic.Add("record_date", IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR4001U00", ScreenOpenStyle.PopUpFixed, cic);
                    //IHIS.Framework.XScreen.OpenScreen(this,"NURI","NUR4002U00", ScreenOpenStyle.PopUpFixed);
                    break;
                case "11"://치료계획관리

                    IXScreen screen = XScreen.FindScreen("OCSI", "OCS6010U10");

                    if (screen == null)
                    {
                        cic.Add("bunho", this.selectedBedBox.Bunho);
                        cic.Add("fkinp1001", this.selectedBedBox.Pkinp1001);
                        IHIS.Framework.XScreen.OpenScreenWithParam(this, "OCSI", "OCS6010U10", ScreenOpenStyle.PopUpFixed, cic);
                    }
                    else
                    {
                        screen.Activate();
                        XPatientInfo pInfo = new XPatientInfo(this.selectedBedBox.Bunho, "", "", "", this.selectedBedBox.Pkinp1001.ToString(), PatientPKGubun.In, this.ScreenID);
                        XScreen.SendPatientInfo(pInfo);
                    }


                    break;
                case "12"://식사오다
                    //cic.Add("hodong", this.cboHoDong.GetDataValue().ToString());
                    //if (!TypeCheck.IsNull(UserInfo.NurseTeam.ToString()))
                    //    cic.Add("team", UserInfo.NurseTeam.ToString());
                    //else
                    //    cic.Add("team", "%");
                    if (this.selectedBedBox == null)
                    {
                        cic.Add("hodong", this.cboHoDong.GetDataValue());
                        cic.Add("hocode","");
                        cic.Add("bunho", "");
                    }
                    else
                    {
                        cic.Add("hodong", this.selectedBedBox.HoDong);
                        cic.Add("hocode", this.selectedBedBox.HoCode);
                        cic.Add("bunho", this.selectedBedBox.Bunho);
                    }
                    //cic.Add("orderdate", IHIS.Framework.EnvironInfo.GetSysDate());

                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "OCSI", "OCS2005U02", ScreenOpenStyle.PopUpFixed, cic);
                    break;
                case "13"://퇴원예고등록

                    cic.Add("fkinp1001", this.selectedBedBox.Pkinp1001);
                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003U99", ScreenOpenStyle.ResponseFixed, cic);
                    break;
                //case "14"://오다실시
                //    //cic.Add("bunho", this.selectedBedBox.Bunho);
                //    IHIS.Framework.XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003U02", ScreenOpenStyle.ResponseFixed, cic);
                    //break;
                //case "15"://간호확인
                //    cic.Add("bunho", this.selectedBedBox.Bunho);
                //    IHIS.Framework.XScreen.OpenScreen(this, "OCS2003U10", ScreenOpenStyle.ResponseFixed);
                //    break;
                case "16"://병동채혈
                    cic.Add("bunho", this.selectedBedBox.Bunho);
                    cic.Add("hodong", this.cboHoDong.GetDataValue().ToString());

                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "CPLS", "CPL2010U01", ScreenOpenStyle.ResponseFixed, cic);
                    break;
                case "17"://청소중처리
                    msg = (NetInfo.Language == LangMode.Ko ? "[" + item.BedNumber + "]의 베드를 청소중으로 바꾸시겠습니까?"
                        : "[" + item.BedNumber + "]の病床を清掃中に変更しますか？");
                    this.SetBedStatus(item, msg, "04");
                    break;
                case "18"://공상처리
                    msg = (NetInfo.Language == LangMode.Ko ? "[" + item.BedNumber + "]의 베드를 공상로 바꾸시겠습니까?"
                        : "[" + item.BedNumber + "]の病床を空床に変更しますか？");
                    this.SetBedStatus(item, msg, "00");
                    break;
                case "19"://제증명출력

                    //cic.Add("bunho", this.selectedBedBox.Bunho);
                    //IHIS.Framework.XScreen.OpenScreenWithParam(this, "DOCS", "DOC2001U00", ScreenOpenStyle.PopUpFixed, cic);
                    break;
                //case "20"://환자안내서
                //    cic.Add("bunho", this.selectedBedBox.Bunho);

                //    IHIS.Framework.XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003R02", ScreenOpenStyle.ResponseFixed, cic);
                //    break;
                //case "21"://EMR연동
                //    //EMR 설치여부를 check한다.
                //    if (!checkExistEMR()) return;

                //    try
                //    {
                //        //command = user id + user password + "2" + 환자번호
                //        //command도 프로그램에 맞게 생성
                //        string command = UserInfo.UserID + " " + UserInfo.UserPswd + " " + "2" + "  " + this.selectedBedBox.Bunho;
                //        System.Diagnostics.Process proExecute = new System.Diagnostics.Process();
                //        proExecute.StartInfo.FileName = @"C:\ICM\ezEMR\ezEMR.exe";
                //        proExecute.StartInfo.Arguments = command;
                //        proExecute.Start();

                //    }
                //    catch (Exception ex)
                //    {
                //        XMessageBox.Show(ex.Message, "ezEMR ERROR", MessageBoxIcon.Error);
                //    }
                //    break;
                //case "22"://양식1생성

                //    cic.Add("bunho", this.selectedBedBox.Bunho);
                //    cic.Add("pkinp1001", this.selectedBedBox.Pkinp1001);
                //    cic.Add("input_gubun", "N");

                //    IHIS.Framework.XScreen.OpenScreenWithParam(this, "DPCS", "DPC6001U00", ScreenOpenStyle.ResponseFixed, cic);
                //    //return;

                    //break;
                case "23"://검사예약
                    cic.Add("bunho", this.selectedBedBox.Bunho);

                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "SCHS", "SCH0201U99", ScreenOpenStyle.PopUpFixed, cic);
                    break;
                //case "24"://환자정보체크리스트
                //    IHIS.Framework.XScreen.OpenScreen(this, "NUR9003U00", ScreenOpenStyle.PopUpFixed);
                //    break;
                case "25"://욕창매트리스
                    cic.Add("bunho", this.selectedBedBox.Bunho);
                    cic.Add("fkinp1001", this.selectedBedBox.Pkinp1001);
                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR6005U00", ScreenOpenStyle.ResponseFixed, cic);
                    break;

                case "28"://EMR
                    IHIS.Framework.EMRHelper.ExecuteEMR(EMRIOTGubun.IN, this.selectedBedBox.Bunho
                                                       , this.mIpwonDate
                                                       , this.mGwa
                                                       , this.mDoctor
                                                       , this.selectedBedBox.Pkinp1001.ToString());

                    break;
                case "30"://병상잠금
                    msg = (NetInfo.Language == LangMode.Ko ? "[" + item.BedNumber + "]의 베드를 잠그시겠습니까?"
                        : "[" + item.BedNumber + "]の病床をロックしますか？");
                    this.SetBedStatus(item, msg, "05");
                    break;
                case "31"://병상잠금해제
                    msg = (NetInfo.Language == LangMode.Ko ? "[" + item.BedNumber + "]의 베드를 잠금해제하시겠습니까?"
                        : "[" + item.BedNumber + "]の病床をロック解除しますか？");
                    this.SetBedStatus(item, msg, "00");

                    break;
                //case "26"://병리검사라벨출력
                //    cic.Add("bunho", this.selectedBedBox.Bunho);
                //    cic.Add("hodong", this.cboHoDong.GetDataValue().ToString());

                //    IHIS.Framework.XScreen.OpenScreenWithParam(this, "APLS", "APL0201R82", ScreenOpenStyle.ResponseFixed, cic);
                //    break;
                //case "27"://양식1생성

                //    /*////////////////////////////////////   NTT DPC  ///////////////////////////////////////////////////
                //    C:\IHIS\bin> IHIS.exe [システム名] [ユーザID] [パスワード] [スクリーンID] [患者番号]
                //    例）IHIS.exe DPCS(固定) ICM000 1111 DPC7001Q01(固定) 0000000001
                //    */
                //    ///////////////////////////////////////////////////////////////////////////////////////////////////

                //    if (TypeCheck.IsNull(this.selectedBedBox.Bunho)) return;

                //    string opencommand = @"C:\IHIS\bin\SET_NLS_LANG.bat";
                //    string dpcExists = @"C:\IHIS\bin\IHIS.exe";
                //    string arguments = string.Empty;

                //    if (!System.IO.File.Exists(dpcExists))
                //    {
                //        string mesg = (NetInfo.Language == LangMode.Ko ? "DPC 시스템이 설치되지 않았습니다."
                //            : "DPC SYSTEMが設置されていません。");
                //        string cap = (NetInfo.Language == LangMode.Ko ? "확인"
                //            : "確認");

                //        XMessageBox.Show(mesg, cap);
                //        return;
                //    }

                //    string user_id = string.Empty;
                //    string pswd = string.Empty;

                //    //사무원이 아니면 패스워드 1111로 전달
                //    if (IHIS.Framework.UserInfo.UserGubun.ToString() == "4")
                //        pswd = UserInfo.UserPswd;
                //    else
                //        pswd = "1111";

                //    arguments = " " + "DPCS" + " " + UserInfo.UserID + " " + pswd + " " + "DPC7001Q01" + " " + this.selectedBedBox.Bunho;

                //    System.Diagnostics.Process process = new System.Diagnostics.Process();
                //    process.EnableRaisingEvents = false;
                //    process.StartInfo.FileName = opencommand;

                //    //process.StartInfo
                //    process.StartInfo.Arguments = arguments;

                //    process.Start();
                //    break;
                default:
                    break;
            }
            //재조회

            this.timer.Enabled = true;
            this.ExecuteQuery();

        }
        #endregion

        #region EMR설치여부 체크
        private bool checkExistEMR()
        {
            bool returnValue = System.IO.Directory.Exists(@"C:\ICM\ezEMR");

            if (!returnValue)
            {
                string xMsg = NetInfo.Language == LangMode.Jr ? "電子カルテが設置されていません。担当者に連絡してください。" : "전자카르테가 설치되지 않았습니다. 담당자에게 연락바랍니다.";
                string xCap = NetInfo.Language == LangMode.Jr ? "" : "";
                XMessageBox.Show(xMsg, xCap);
            }

            return returnValue;
        }
        #endregion

        #region 베드 상태 변경처리(청소중,공상)
        private void SetBedStatus(JobItem item, string aMsg, string aBedStatus)
        {
            string cmdText = @"UPDATE BAS0253
                                  SET BED_STATUS    = :f_bed_status
                                    , BED_LOCK_TEXT = :f_bed_lock_text
                                WHERE HOSP_CODE     = :f_hosp_code 
                                  AND HO_DONG       = :f_ho_dong
                                  AND HO_CODE       = :f_ho_code
                                  AND BED_NO        = :f_bed_no
                                  AND TRUNC(SYSDATE) BETWEEN FROM_BED_DATE AND NVL(TO_BED_DATE,'9998/12/31')
                                  --AND BED_STATUS != '05'";
            BindVarCollection bindVars = new BindVarCollection();

            if (XMessageBox.Show(aMsg, "病床状態変更", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            bindVars.Add("f_hosp_code", this.mHospCode);
            bindVars.Add("f_ho_dong", cboHoDong.GetDataValue());
            bindVars.Add("f_ho_code", item.HoCode);
            bindVars.Add("f_bed_no", item.BedNumber);
            bindVars.Add("f_bed_status", aBedStatus);

            if (aBedStatus == "05")
            {
                BedLockForm blf = new BedLockForm();
                blf.ShowDialog();

                if (blf.BedLockText != "")
                {
                    bindVars.Add("f_bed_lock_text", blf.BedLockText);
                    blf.Dispose();
                }
                else
                    return;
            }
            else
            {
                bindVars.Add("f_bed_lock_text", "");            
            }

            if (Service.ExecuteNonQuery(cmdText, bindVars))
            {
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
        }
        #endregion
        
        #region 각종 버튼 이벤트

        //전과전실
        private void ibtnChangeGwa_Click(object sender, System.EventArgs e)
        {
            if (this.selectedBedBox == null || this.selectedBedBox.Bunho == "")
            {
                this.GetMessage("bunho");
                return;
            }

            CommonItemCollection cic = new CommonItemCollection();
            cic.Add("bunho", this.selectedBedBox.Bunho);

            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR2004U00", ScreenOpenStyle.ResponseFixed, cic);

            //재조회
            this.ExecuteQuery();
        }

        //간호관리항목
        private void btnGanhodo_Click(object sender, System.EventArgs e)
        {
            if (this.selectedBedBox == null || this.selectedBedBox.Bunho == "")
            {
                this.GetMessage("bunho");
                return;
            }

            CommonItemCollection cic = new CommonItemCollection();
            cic.Add("bunho", this.selectedBedBox.Bunho);
            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR2005U00", ScreenOpenStyle.ResponseFixed, cic);
            //재조회
            this.ExecuteQuery();
        }

        //담당간호사
        private void btnDamdang_Nurse_Click(object sender, System.EventArgs e)
        {
            if (this.selectedBedBox == null || this.selectedBedBox.Bunho == "")
            {
                this.GetMessage("bunho");
                return;
            }

            CommonItemCollection cic = new CommonItemCollection();
            cic.Add("bunho", this.selectedBedBox.Bunho);

            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR1010U00", ScreenOpenStyle.ResponseFixed, cic);
            //재조회
            this.ExecuteQuery();
        }

        //오더정보조회 2011.12.24 Merry Christmas~ -woo
        private void btnReadOrder_Click(object sender, EventArgs e)
        {
            if (this.selectedBedBox == null || this.selectedBedBox.Bunho == "")
            {
                this.GetMessage("bunho");
                return;
            }
            CommonItemCollection cic = new CommonItemCollection();
            cic.Add("bunho", this.selectedBedBox.Bunho);

            IHIS.Framework.XScreen.OpenScreenWithParam(this, "OCSI", "OCS1003Q05", ScreenOpenStyle.ResponseFixed, cic);
            //재조회
            this.ExecuteQuery();
        }
        #endregion

        #region 치료계획
        private void ibtnGanhoReser_Click(object sender, System.EventArgs e)
        {
            if (this.selectedBedBox == null || this.selectedBedBox.Bunho == "")
			{
				this.GetMessage("bunho");
				return;
			}

            IXScreen screen = XScreen.FindScreen("OCSI", "OCS6010U10");

            if (screen == null)
            {
                CommonItemCollection cic = new CommonItemCollection();
                cic.Add("bunho", this.selectedBedBox.Bunho);
                cic.Add("fkinp1001", this.selectedBedBox.Pkinp1001);
                IHIS.Framework.XScreen.OpenScreenWithParam(this, "OCSI", "OCS6010U10", ScreenOpenStyle.PopUpFixed, cic);
            }
            else
            {
                screen.Activate();
                XPatientInfo pInfo = new XPatientInfo(this.selectedBedBox.Bunho, "", "", "", this.selectedBedBox.Pkinp1001.ToString(), PatientPKGubun.In, this.ScreenID);
                XScreen.SendPatientInfo(pInfo);
            }
        }
        #endregion

        #region 식이처방
        private void ibtnDietOrder_Click(object sender, System.EventArgs e)
        {
            //CommonItemCollection cic = new CommonItemCollection();

            //cic.Add("hodong", this.cboHoDong.GetDataValue().ToString());
            //if (!TypeCheck.IsNull(UserInfo.NurseTeam.ToString()))
            //    cic.Add("team", UserInfo.NurseTeam.ToString());
            //else
            //    cic.Add("team", "%");
            //if (this.selectedBedBox == null)
            //{
            //    cic.Add("hocode", "");
            //    cic.Add("bunho", "");
            //}
            //else
            //{
            //    cic.Add("hocode", this.selectedBedBox.HoCode);
            //    cic.Add("bunho", this.selectedBedBox.Bunho);
            //}
            //cic.Add("orderdate", IHIS.Framework.EnvironInfo.GetSysDate());

            //IHIS.Framework.XScreen.OpenScreenWithParam(this, "NUTS", "NUT3003U00", ScreenOpenStyle.PopUpFixed, cic);
        }
        #endregion

        #region 욕창환자
        private void btnBedsore_Click(object sender, System.EventArgs e)
        {
            if (this.selectedBedBox == null || this.selectedBedBox.Bunho == "")
            {
                this.GetMessage("bunho");
                return;
            }

            CommonItemCollection cic = new CommonItemCollection();
            cic.Add("bunho", this.selectedBedBox.Bunho);

            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR6011U01", ScreenOpenStyle.PopUpFixed, cic);
            //재조회
            this.ExecuteQuery();
        }
        #endregion

        #region 간호계획
        private void btnPlan_Click(object sender, System.EventArgs e)
        {
            if (this.selectedBedBox == null || this.selectedBedBox.Bunho == "")
            {
                this.GetMessage("bunho");
                return;
            }

            CommonItemCollection cic = new CommonItemCollection();

            cic.Add("bunho", this.selectedBedBox.Bunho);
            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR4001U00", ScreenOpenStyle.PopUpFixed, cic);
        }
        #endregion

        #region 전입확인처리
        private void btnTransConfirm_Click(object sender, System.EventArgs e)
        {
            CommonItemCollection cic = new CommonItemCollection();
            cic.Add("hodong", this.cboHoDong.GetDataValue());

            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR2004U01", ScreenOpenStyle.ResponseFixed, cic);

            //재조회
            this.ExecuteQuery();
        }
        #endregion

        #region HoSilLocation(호실박스의 위치관리 class)
        private class HoSilLocation
        {
            public string HoCode;
            public string HoCodeName;
            public string HoSex;
            public int Seq = 0; //같은 호실을 가지는 호실Box의 순번
            public HoSilStatus HoStatus = HoSilStatus.General;
            public WingGubun wingGubun = WingGubun.State1;
            public int BedCount = 0;  //호실의 병상수
            public int X = 0;   //X
            public int Y = 0;   //Y
            public int Width = 0;  //W
            public int Height = 0;

        }
        #endregion

        #region PatientItem 환자정보 관리 Class
        private class PatientItem
        {
            public string Bunho = "";            //환자번호
            public string Suname = "";           //한자명
            public string Suname2 = "";          //가나명
            public string Pkinp1001 = "";        //입원환자 Key값
            public string BirthDate = "";        //생년월일
            public string SexAge = "";           //성별 + 나이
            public string IpwonDate = "";        //입원일자
            public string JaewonNalsu = "";      //재원일수
            public string GwaName = "";          //과명
            public string DoctorName = "";       //주치의명
            public string ResidentName = "";     //담당의명
            public string NurseName = "";        //담당간호사명
            public string SangName = "";         //주상병명
            public string Ganhodo = "";          //간호도
            public string Life_self_grade = "";  //일상생활자립도
            public string IpwonMokjuk = "";      // 미래예약자및 목적
            public string ReserInfo = "";        // 미래예약자정보
            public string ToiwonResDate = "";    //퇴원예고날짜
            public string ToiwonResTime = "";    //퇴원예고시간
            public string BedStatus = "";        //베드상태->예약중('01'),입원중('02'),퇴원예약('03'),청소중('04'),공상('00')
            public string YokchangYn = "";       //욕창환자여부
            public string GamyumYn = "";         //감염환자여부
            public string GamyumName = "";       //감염증명
            public string BedLockText = "";      //베드 잠금 텍스트
            public string Status_Flag_Text = ""; //상태 텍스트
            public string IsOut = "";            //외출중 확인
            public string NotYetDrgDate = ""; //최근 미 투여 일자
        }
        #endregion

        #region 담당의사별로 조회를 한다.
        private void cboDoctorList_SelectedValueChanged(object sender, System.EventArgs e)
        {
            ExecuteQuery();
        }
        #endregion

        #region 간호처방화면 오픈
        private void btnOCS2003U02Open_Click(object sender, System.EventArgs e)
        {
            if (this.selectedBedBox == null || this.selectedBedBox.Bunho == "")
            {
                this.GetMessage("bunho");
                return;
            }

            CommonItemCollection cic = new CommonItemCollection();
            cic.Add("bunho", this.selectedBedBox.Bunho);

            IHIS.Framework.XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003P01", ScreenOpenStyle.PopUpSizable, cic);
        }
        #endregion

        #region 진료과 변경을 했을 때
        private void cboGwa_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.cboHoDong.GetDataValue().ToString() == "") return;

            if (this.cboGwa.GetDataValue().ToString() == "") return;

            ExecuteQuery();
        }
        #endregion

        #region 사용자변경이 있을 때
        private void NUR1010Q00_UserChanged(object sender, System.EventArgs e)
        {
            this.cboGwa.SetEditValue("");
            this.cboGwa.AcceptData();

            //사용자 구분이 Nurse(간호사)이고, 
            if (UserInfo.UserGubun == UserType.Nurse)
            {
                this.cboHoDong.SetDataValue(UserInfo.HoDong);
                //호동을 변경하면서 SelectedIndexChanged가 발생하면서 병동조회함
            }

            this.cboGwa.SetEditValue("%");
            this.cboGwa.AcceptData();
            ExecuteQuery();
        }
        #endregion

        #region 입원처방화면 오픈
        private void btnOCS2003U00Open_Click(object sender, System.EventArgs e)
        {
            CommonItemCollection cic = new CommonItemCollection();
            cic.Add("bunho", this.selectedBedBox.Bunho.ToString());
            cic.Add("naewon_key", this.selectedBedBox.Pkinp1001);

            IHIS.Framework.XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003U00", ScreenOpenStyle.ResponseFixed, cic);

        }
        #endregion

        #region 조회버튼을 클릭을 했을 때
        private void btnQuery_Click(object sender, System.EventArgs e)
        {
            if (this.cboHoDong.GetDataValue().ToString() == "") return;

            if (this.cboGwa.GetDataValue().ToString() == "") return;

            this.timer.Enabled = true; // 시간 다시 수행

            ExecuteQuery();
        }
        #endregion

        #region 병실성별설정 화면을 오픈한다.
        private void btnSetHo_sex_Click(object sender, System.EventArgs e)
        {
            if (this.cboHoDong.GetDataValue() == "")
            {
                this.GetMessage("ho_dong");
                return;
            }

            CommonItemCollection cic = new CommonItemCollection();
            cic.Add("ho_dong", this.cboHoDong.GetDataValue().ToString());

            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR1010U01", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter, cic);
        }
        #endregion

        #region 화면조정
        private void btnVisible_Click(object sender, System.EventArgs e)
        {
            if (this.btnVisible.Tag.ToString() == "N")
            {
                this.panel2.Visible = false;
                this.btnVisible.Tag = "Y";
                HOCNT_PER_LINE = 10;
                /* 재 조회 처리 */
                ExecuteQuery();
            }
            else
            {
                this.panel2.Visible = true;
                this.btnVisible.Tag = "N";
                HOCNT_PER_LINE = 8;
                /* 재 조회 처리 */
                ExecuteQuery();
            }
        }
        #endregion

        #region 주산기시스템 인터페이스
        private void btnJusangi_Click(object sender, System.EventArgs e)
        {
            //if (this.selectedBedBox == null)
            //{
            //    this.GetMessage("bunho");
            //    return;
            //}

            //string target = "http://172.16.21.2/obis_heartlife/session/SystemLogin.aspx?pid=" + this.selectedBedBox.Bunho + "&uid=" + UserInfo.UserID + "&pwd=" + UserInfo.UserPswd;
            //try
            //{
            //    System.Diagnostics.Process.Start(target);
            //}
            //catch (System.ComponentModel.Win32Exception noBrowser)
            //{
            //    if (noBrowser.ErrorCode == -2147467259)
            //        MessageBox.Show(noBrowser.Message);
            //}
            //catch (System.Exception other)
            //{
            //    MessageBox.Show(other.Message);
            //}
        }
        #endregion

        #region 각 layout에 bind 변수 설정
        private void layHosilList_QueryStarting(object sender, CancelEventArgs e)
        {
            layHosilList.SetBindVarValue("f_hosp_code", this.mHospCode);
            layHosilList.SetBindVarValue("f_ho_dong",    cboHoDong.GetDataValue());
        }

        private void layPatientList_QueryStarting(object sender, CancelEventArgs e)
        {
            layPatientList.SetBindVarValue("f_hosp_code", this.mHospCode);
            layPatientList.SetBindVarValue("f_ho_dong", cboHoDong.GetDataValue());
           // layPatientList.SetBindVarValue("f_doctor",  cboDoctorList.GetDataValue());
            layPatientList.SetBindVarValue("f_gwa",  cboGwa.GetDataValue());
        }

        private void layBedList_QueryStarting(object sender, CancelEventArgs e)
        {
            layBedList.SetBindVarValue("f_hosp_code", this.mHospCode);
            layBedList.SetBindVarValue("f_ho_dong", cboHoDong.GetDataValue());
        }
        #endregion


        
//        #region 각 layout 조회 후 처리
//        private void layHosilList_QueryEnd(object sender, QueryEndEventArgs e)
//        {
//             //필요없을듯 20120117 KBH
////            if (layHosilList.RowCount <= 0) return;

////            string cmdText = @"SELECT COUNT(1)
////                                 FROM BAS0253
////                                WHERE HOSP_CODE = :f_hosp_code
////                                  AND HO_CODE   = :f_ho_code
////                                  AND TRUNC(SYSDATE) BETWEEN FROM_BED_DATE AND NVL(TO_BED_DATE,'9998/12/31')
////                                  AND BED_STATUS != '05'";
////            BindVarCollection bindVars = new BindVarCollection();
////            object retVal = null;
////            try
////            {
////                for (int i = 0; i < layHosilList.RowCount; i++)
////                {
////                    bindVars.Clear();
////                    bindVars.Add("f_hosp_code", this.mHospCode);
////                    bindVars.Add("f_ho_code", layHosilList.GetItemString(i, "ho_code"));
////                    retVal = Service.ExecuteScalar(cmdText, bindVars);
////                    layHosilList.SetItemValue(i, "ho_total_bed", retVal.ToString());
////                }
////            }
////            catch (Exception xe)
////            {
////                XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
////                return;
////            }
//            /* */
//        }

//        private void layPatientList_QueryEnd(object sender, QueryEndEventArgs e)
//        {
//            /* */
//            string cmdText = @"";
//            BindVarCollection bindVars = new BindVarCollection();
//            object retVal = null;

//            for (int i = 0; i < layPatientList.RowCount; i++)
//            {
//                if (layPatientList.GetItemValue(i, "bunho").ToString() == "")
//                    continue;

//                bindVars.Clear();
//                bindVars.Add("f_hosp_code", this.mHospCode);
//                bindVars.Add("f_bunho", layPatientList.GetItemValue(i, "bunho").ToString());
//                bindVars.Add("f_pkinp1001", layPatientList.GetItemValue(i, "pkinp1001").ToString());
//                bindVars.Add("f_doctor", layPatientList.GetItemValue(i, "doctor").ToString());
//                bindVars.Add("f_gwa", layPatientList.GetItemValue(i, "gwa").ToString());
//                bindVars.Add("f_ipwon_date", layPatientList.GetItemValue(i, "ipwon_date").ToString());


//                /* Default Value, BR_CODE, CP_YN, SANG_NAME은 일단 보류
//                   CP_YN은 OCS6007에 있으면 Y 없으면 N (보류) */
//                cmdText = @"SELECT 'Y'
//                              FROM OCS6010
//                             WHERE HOSP_CODE = :f_hosp_code
//                               AND BUNHO     = :f_bunho
//                               AND FKINP1001 = :f_pkinp1001
//                               AND CP_YN     = 'Y'
//                               AND TRUNC(SYSDATE) < NVL(CP_END_DATE,TRUNC(SYSDATE) + 1)";
//                retVal = Service.ExecuteScalar(cmdText, bindVars);
//                if (!TypeCheck.IsNull(retVal))
//                {
//                    layPatientList.SetItemValue(i, "cp_yn", "Y");
//                    retVal = null;
//                }

//                /* RGB조회
//                   환자의 주치의가 간호기준정보테이블에 있으면 RGB값을 BAS0270에서
//                   없으면 BAS0260에서 조회를 한다. */
////                cmdText = @"SELECT 'Y'
////                              FROM NUR0102
////                             WHERE HOSP_CODE = :f_hosp_code
////                               AND CODE_TYPE = 'DOCTOR'
////                               AND CODE      = :f_doctor";
////                retVal = Service.ExecuteScalar(cmdText, bindVars);
//                //if (!TypeCheck.IsNull(retVal))
//                //{
//                    //layPatientList.SetItemValue(i, "code", retVal.ToString());
//                /* BAS0270 테이블에서 RGB값을 조회 (의사별 색상 지정 ) */
//                    retVal = null;
////                    cmdText = @"SELECT DOCTOR_COLOR
////                                  FROM BAS0270
////                                 WHERE HOSP_CODE  = :f_hosp_code
////                                   AND TO_DATE(:f_ipwon_date, 'YYYY/MM/DD') BETWEEN START_DATE AND END_DATE
////                                   AND DOCTOR_GWA = :f_gwa
////                                   AND DOCTOR     = :f_doctor";

////                    if (layPatientList.GetItemValue(i, "doctor").ToString() != "")
////                        retVal = Service.ExecuteScalar(cmdText, bindVars);

//                    if (TypeCheck.IsNull(retVal))
//                    {
//                        /* BAS0260테이블에서 RGB값을 조회 */
//                        cmdText = @"SELECT GWA_COLOR
//                                      FROM BAS0260
//                                     WHERE HOSP_CODE = :f_hosp_code
//                                       AND GWA = :f_gwa
//                                       AND TO_DATE(:f_ipwon_date, 'YYYY/MM/DD') BETWEEN START_DATE AND END_DATE";
//                        retVal = Service.ExecuteScalar(cmdText, bindVars);
                        
//                        if (!TypeCheck.IsNull(retVal))
//                        {
//                            layPatientList.SetItemValue(i, "rgb", retVal.ToString());
//                            retVal = null;
//                        }
//                        else
//                        {
//                            //XMessageBox.Show(Service.ErrFullMsg + "\n\r" + Service.ErrCode);
//                            //return;
//                        }
//                    }
//                    else if (!TypeCheck.IsNull(retVal))
//                    {
//                        layPatientList.SetItemValue(i, "rgb", retVal.ToString());
//                        retVal = null;
//                    }
//                    else
//                    {
//                        //XMessageBox.Show(Service.ErrFullMsg + "\n\r" + Service.ErrCode);
//                        //return;
//                    }

//                //욕창환자여부를 조회한다.
//                cmdText = @"SELECT 'Y'
//                              FROM NUR6001 A
//                             WHERE A.HOSP_CODE    = :f_hosp_code
//                               AND A.BUNHO        = :f_bunho
//                               AND A.FKINP1001    = :f_pkinp1001
//                               AND TRUNC(SYSDATE) BETWEEN A.FROM_DATE 
//                                                      AND NVL(A.END_DATE, TO_DATE('9998/12/31', 'YYYY/MM/DD'))";
//                retVal = Service.ExecuteScalar(cmdText, bindVars);
//                if (!TypeCheck.IsNull(retVal))
//                {
//                    layPatientList.SetItemValue(i, "yokchang_yn", retVal.ToString());
//                }
//                else if (TypeCheck.IsNull(retVal))
//                {
//                }
//                else
//                {
//                    //XMessageBox.Show(Service.ErrFullMsg + "\n\r" + Service.ErrCode);
//                    //return;
//                }

//                //감염증환자여부를 조회한다.
//                cmdText = @"SELECT FN_NUR_LOAD_CODE_NAME('INFE_CODE', A.INFE_CODE) GAMYUM
//                              FROM NUR1017 A
//                             WHERE A.HOSP_CODE = :f_hosp_code
//                               AND A.BUNHO     = :f_bunho
//                               AND NVL(A.CANCEL_YN, 'N') = 'N'
//                               AND SYSDATE BETWEEN A.START_DATE AND NVL(A.END_DATE, TO_DATE('9998/12/31','YYYY/MM/DD')) ";
                
//                DataTable dt = Service.ExecuteDataTable(cmdText, bindVars);
//                string gamyum_names = "";
//                if (!TypeCheck.IsNull(dt))
//                {
//                    if (dt.Rows.Count > 0)
//                    {
//                        layPatientList.SetItemValue(i, "gamyum_yn", "Y");
//                        foreach (DataRow row in dt.Rows)
//                        {
//                            gamyum_names += ", " + row["gamyum"].ToString();
//                        }
//                        if (gamyum_names != "")
//                            gamyum_names = gamyum_names.Substring(1);
//                    }
//                }
//                layPatientList.SetItemValue(i, "gamyum_name", gamyum_names);
//            }
//            //*/
//        }
//        #endregion

        #region CheckNurseID()
        
        private string mNurseID = "";

        private bool CheckNurseID()
        {
            string cmdText = "";           

            mNurseID = "";

            CheckNurse cnForm = new CheckNurse();
            cnForm.ShowDialog();
            mNurseID = cnForm.NurseID;

            BindVarCollection bindVar = new BindVarCollection();
            bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVar.Add("f_user_id", this.mNurseID);

            if (mNurseID != "")
            {
                cmdText = @"SELECT 'Y'
                              FROM DUAL
                             WHERE EXISTS ( SELECT 'Y'
                                              FROM ADM3200 
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND USER_GROUP LIKE 'NUR%'
                                               AND USER_ID = :f_user_id)";
                object retval = Service.ExecuteScalar(cmdText, bindVar);
                
                if (!TypeCheck.IsNull(retval))
                {
                    if (retval.ToString() == "Y")
                        return true;
                }
                else
                {
                    XMessageBox.Show("病床移動の権限の無い看護IDです。\r\nご確認ください。", "確認", MessageBoxIcon.Error);
                    return false;
                }
            }

            return false;
        }

        #endregion

        #region MoveHosil()   dsvMoveHosil 서비스
        /// <summary>
        /// 병실 이동
        /// </summary>
        /// <param name="dragBed"></param>
        /// <param name="dropBed"></param>
        /// <returns></returns>
        private bool MoveHosil(BedBox dragBed, BedBox dropBed)
        {
            //-- DataService 변환 properties  2010.05. 河中  ---------------------*
            string cmdText = string.Empty;
            DataTable resTable = new DataTable();
            object retVal = new object();
            BindVarCollection bindVars = new BindVarCollection();

            string to_kaikei_hodong = "";
            string to_kaikei_hocode = "";

            //회계병동 병실 변경 여부 확인
            if (XMessageBox.Show("[ " + dragBed.SuName + "] さんの\r\n扱い病室情報を \r\n\r\n" +
                                 "　元　：　" + dragBed.Kaikei_HoDong + "棟　" + dragBed.Kaikei_HoCode + "号室から\r\n" +
                                 "　現　：　" + dropBed.HoDong + "棟　" + dropBed.HoCode + "号室に\r\n\r\n" +
                                 "変更しますか？", "確認",
                                 MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                to_kaikei_hodong = dropBed.HoDong;
                to_kaikei_hocode = dropBed.HoCode;
            }
            else
            {
                to_kaikei_hodong = dragBed.Kaikei_HoDong;
                to_kaikei_hocode = dragBed.Kaikei_HoCode;
            }



            //--------------------------------------------------------------------*

            /* -------------------------------------------------------------------*
             * dsvMoveHosil 서비스            2010.05. 河中
             * -------------------------------------------------------------------*/
            // 바인드 변수 설정
            bindVars.Add("i_hosp_code",     this.mHospCode);
            bindVars.Add("i_fkinp1001",     dragBed.Pkinp1001.ToString());

            bindVars.Add("i_bunho",         dragBed.Bunho);
            bindVars.Add("i_from_ho_dong",  cboHoDong.GetDataValue());
            bindVars.Add("i_to_ho_dong",    cboHoDong.GetDataValue());
            bindVars.Add("i_from_ho_code",  dragBed.HoCode);
            bindVars.Add("i_to_ho_code",    dropBed.HoCode);
            bindVars.Add("i_from_bed_no",   dragBed.BedNumber.ToString().PadLeft(2, '0'));
            bindVars.Add("i_to_bed_no",     dropBed.BedNumber.ToString().PadLeft(2, '0'));
            bindVars.Add("i_from_kaikei_hodong", dragBed.Kaikei_HoDong);
            bindVars.Add("i_from_kaikei_hocode", dragBed.Kaikei_HoCode);

            bindVars.Add("q_user_id", IHIS.Framework.UserInfo.UserID);

            cmdText = @"SELECT 'Y'
                          FROM DUAL
                         WHERE EXISTS (SELECT 'X'
                                         FROM INP2004 A
                                        WHERE A.HOSP_CODE           = :i_hosp_code
                                          AND A.BUNHO               = :i_bunho
                                          AND NVL(A.CANCEL_YN, 'N') = 'N'
                                          AND A.FKINP1001           = :i_fkinp1001
                                          AND A.TO_NURSE_CONFIRM_DATE IS NULL)";
            retVal = Service.ExecuteScalar(cmdText, bindVars);
            if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
            {
                /*공상으로 이동처리를 못함*/
                GetMessage("3559");
                return false;
            }

            /*from 환자의 병동병실정보 변경됨.*/
            cmdText = string.Empty;
            retVal = null;
            //INTO: o_flag
            cmdText = @"SELECT 'Y'
                          FROM DUAL
                         WHERE EXISTS ( SELECT 'X'
                                          FROM VW_OCS_INP1001_01
                                         WHERE HOSP_CODE = :i_hosp_code 
                                           AND PKINP1001 = :i_fkinp1001
                                           AND HO_DONG1  = :i_from_ho_dong
                                           AND HO_CODE1  = :i_from_ho_code
                                           AND BED_NO    = :i_from_bed_no )";
            retVal = Service.ExecuteScalar(cmdText, bindVars);
            if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
            {
            }
            else
            {
                GetMessage("462");
                return false;
            }

            /*공상으로 변경인데 새로입원처리된경우*/
            cmdText = string.Empty;
            retVal = null;
            //INTO: o_check
            cmdText = @"SELECT 'Y'
                          FROM DUAL
                         WHERE EXISTS (SELECT 'X'
                                         FROM VW_OCS_INP1001_01 A
                                        WHERE A.HOSP_CODE           = :i_hosp_code
                                          AND A.HO_DONG1            = :i_to_ho_dong
                                          AND A.HO_CODE1            = :i_to_ho_code
                                          AND A.BED_NO              = :i_to_bed_no
                                          AND A.JAEWON_FLAG         = 'Y'
                                          AND NVL(A.CANCEL_YN, 'N') = 'N')";
            retVal = Service.ExecuteScalar(cmdText, bindVars);
            if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
            {
                GetMessage("463");
                return false;
            }

            /*전과전실횟차 로드*/
            cmdText = string.Empty;
            retVal = null;
            //INTO: o_trans_cnt
            cmdText = @"SELECT NVL(MAX(TRANS_CNT),0) + 1
                                  FROM INP2004
                                 WHERE HOSP_CODE = :i_hosp_code
                                   AND BUNHO     = :i_bunho
                                   AND FKINP1001 = :i_fkinp1001";
            retVal = Service.ExecuteScalar(cmdText, bindVars);
            if (!TypeCheck.IsNull(retVal))
            {
                bindVars.Add("o_trans_cnt", retVal.ToString());
            }
            else
            {
                GetMessage("464");
                return false;
            }

            cmdText = string.Empty;
            cmdText = @"SELECT A.GWA
                              ,A.DOCTOR
                              ,A.RESIDENT
                              ,A.HO_CODE1
                              ,A.HO_DONG1
                              ,A.HO_GRADE1
                              ,A.HO_CODE2
                              ,A.HO_DONG2
                              ,A.HO_GRADE2
                              ,A.BED_NO
                          FROM VW_OCS_INP1001_01 A
                         WHERE A.HOSP_CODE = :i_hosp_code 
                           AND A.PKINP1001 = :i_fkinp1001";
            resTable = Service.ExecuteDataTable(cmdText, bindVars);

            if (resTable.Rows.Count > 0)
            {
                bindVars.Add("o_to_gwa", resTable.Rows[0]["gwa"].ToString());
                bindVars.Add("o_to_doctor", resTable.Rows[0]["doctor"].ToString());
                bindVars.Add("o_to_resident", resTable.Rows[0]["resident"].ToString());
                bindVars.Add("o_to_ho_code1", resTable.Rows[0]["ho_code1"].ToString());
                bindVars.Add("o_to_ho_dong1", resTable.Rows[0]["ho_dong1"].ToString());
                bindVars.Add("o_to_ho_grade1", resTable.Rows[0]["ho_grade1"].ToString());
                bindVars.Add("o_to_ho_code2", resTable.Rows[0]["ho_code2"].ToString());
                bindVars.Add("o_to_ho_dong2", resTable.Rows[0]["ho_dong2"].ToString());
                bindVars.Add("o_to_ho_grade2", resTable.Rows[0]["ho_grade2"].ToString());
                bindVars.Add("o_to_bed_no", resTable.Rows[0]["bed_no"].ToString());
                bindVars.Add("o_to_kaikei_hodong", to_kaikei_hodong);
                bindVars.Add("o_to_kaikei_hocode", to_kaikei_hocode);
            }
            else
            {
                GetMessage("464");
                return false;
            }

            /* 예비실이 아닌 경우에만 새로 병실의 등급을 조회를 해서 처리 */
//            cmdText = string.Empty;
//            retVal = null;
//            // INTO :o_wing_gubun
//            cmdText = @"SELECT A.WING_GUBUN
//                                  FROM BAS0250 A
//                                 WHERE A.HOSP_CODE   = :i_hosp_code
//                                   AND A.HO_DONG     = :i_to_ho_dong
//                                   AND A.HO_CODE     = :i_to_ho_code
//                                   AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE";
//            retVal = Service.ExecuteScalar(cmdText, bindVars);
//            if (TypeCheck.IsNull(retVal))
//            {
//                GetMessage("null");
//                return false;
//            }
//            if (retVal.ToString() != "99")
//            {
            /* HO_GRADE를 조회한다. */
            cmdText = string.Empty;
            resTable.Clear();
            //INTO :o_to_ho_grade1, :o_to_ho_status1
            cmdText = @"SELECT A.HO_GRADE       HO_GRADE
                               --, A.HO_STATUS
                              FROM BAS0250 A
                             WHERE A.HOSP_CODE = :i_hosp_code
                               AND A.HO_DONG   = :i_to_ho_dong
                               AND A.HO_CODE   = :i_to_ho_code
                               AND NVL(:o_junpyo_date, TRUNC(SYSDATE)) BETWEEN A.START_DATE AND A.END_DATE";
            resTable = Service.ExecuteDataTable(cmdText, bindVars);
            if (resTable.Rows.Count > 0)
            {
                bindVars.Remove("o_to_ho_grade1");
                //bindVars.Remove("o_to_ho_status1");
                bindVars.Add("o_to_ho_grade1", resTable.Rows[0]["ho_grade"].ToString());
                //bindVars.Add("o_to_ho_status1", resTable.Rows[0]["ho_status"].ToString());
            }
            else
            {
                /*HO_GRADE 조회 에러.*/
                //GetMessage("141");
                XMessageBox.Show("病室等級の照会中にエラーが発生しました。", "お知らせ", MessageBoxIcon.Information);
                return false;
            }
            //}


            cmdText = string.Empty;
            retVal = null;
            /* 하이케어실을 2중병실로 관리 */
            // INTO :o_double_ho_yn
            cmdText = @"SELECT 'Y'
                          FROM DUAL
                         WHERE EXISTS (SELECT 'X'
                                         FROM BAS0250 A
                                        WHERE A.HOSP_CODE          = :i_hosp_code
                                          AND A.HO_DONG            = :i_to_ho_dong
                                          AND A.HO_CODE            = :i_to_ho_code
                                          AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE
                                          AND NVL(A.DOUBLE_HO_YN, 'N') = 'Y')";
            retVal = Service.ExecuteScalar(cmdText, bindVars);

            //if (!TypeCheck.IsNull(retVal) && !retVal.ToString().Equals("Y"))
            //{
            //    XMessageBox.Show(Service.ErrFullMsg);
            //    return false;
            //}

            if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
            {
                /*INP2004생성*/
                cmdText = string.Empty;
                cmdText = @"
        INSERT INTO INP2004   
                              ( SYS_DATE,               SYS_ID,                     UPD_DATE,                   UPD_ID,        HOSP_CODE,
                                FKINP1001,              BUNHO,                      TRANS_CNT,                  TRANS_TIME,    
                                START_DATE,             TONGGYE_DATE,               FROM_GWA,                   TO_GWA,
                                FROM_DOCTOR,            TO_DOCTOR,                  FROM_RESIDENT,              TO_RESIDENT,         
                                CANCEL_SAYU,            
                                FROM_HO_CODE1,          FROM_HO_DONG1,              TO_HO_CODE1,                TO_HO_DONG1,  
                                FROM_HO_CODE2,          FROM_HO_DONG2,              TO_HO_CODE2,                TO_HO_DONG2,   
                                CANCEL_YN,              END_DATE,        
                                TO_NURSE_CONFIRM_ID,    TO_NURSE_CONFIRM_DATE,      
                                TRANS_GUBUN,            FROM_BED_NO,                TO_BED_NO,                  TO_NURSE_CONFIRM_TIME,
                                TO_HO_GRADE1,           TO_HO_GRADE2, 
                                FROM_KAIKEI_HODONG,     FROM_KAIKEI_HOCODE,         TO_KAIKEI_HODONG,           TO_KAIKEI_HOCODE)
                    VALUES    ( SYSDATE,                :q_user_id,                 SYSDATE,                    :q_user_id,    :i_hosp_code,
                                :i_fkinp1001,           :i_bunho,                   NVL(TRIM(:o_trans_cnt),1),  TO_CHAR(SYSDATE,'HH24MI'),  
                                TRUNC(SYSDATE),         SYSDATE,                    TRIM(:o_to_gwa),            TRIM(:o_to_gwa),
                                :o_to_doctor,           :o_to_doctor,               :o_to_resident,             :o_to_resident,
                                null,                   
                                :i_from_ho_code,        :i_from_ho_dong,            :i_to_ho_code,              :i_to_ho_dong,              
                                :i_from_ho_code,        :i_from_ho_dong,            :i_to_ho_code,              :i_to_ho_dong,                       
                                'N',                    TO_DATE('9998/12/31', 'YYYY/MM/DD'),        
                                :q_user_id,              TRUNC(SYSDATE),             
                                '03',                   :i_from_bed_no,             :i_to_bed_no,               TO_CHAR(SYSDATE, 'HH24MI'),
                                :o_to_ho_grade1,        :o_to_ho_grade2,
                                :i_from_kaikei_hodong,  :i_from_kaikei_hocode,      :o_to_kaikei_hodong,        :o_to_kaikei_hocode)";
            }
            else
            {
                /* 하이케어실에 입실이 되 있는 상태이면 2중병실을 그대로 관리를 한다. */
//                cmdText = string.Empty;
//                retVal = null;
//                //INTO: o_double_room_yn
//                cmdText = @"
//                        SELECT 'Y'
//                          FROM DUAL
//                         WHERE EXISTS (SELECT 'X'
//                                         FROM VW_OCS_INP1001_01 A
//                                        WHERE A.HOSP_CODE = :i_hosp_code
//                                          AND A.PKINP1001 = :i_fkinp1001
//                                          AND A.BUNHO     = :i_bunho
//                                          AND NVL(A.JAEWON_FLAG, 'N') = 'Y'
//                                          AND NVL(A.CANCEL_YN, 'N')   = 'N'
//                                          AND A.HO_DONG2              = :i_from_ho_dong
//                                          AND A.HO_CODE2              IN (SELECT B.HO_CODE
//                                                                            FROM BAS0250 B
//                                                                           WHERE B.HOSP_CODE = :i_hosp_code
//                                                                             AND B.HO_DONG = A.HO_DONG2
//                                                                             AND TRUNC(SYSDATE) BETWEEN B.START_DATE AND B.END_DATE
//                                                                             AND NVL(B.DOUBLE_HO_YN, 'N') = 'Y'))";
//                retVal = Service.ExecuteScalar(cmdText, bindVars);
//                if (retVal != null && retVal.ToString().Equals("Y"))
//                {
//                    cmdText = @"
//            INSERT INTO INP2004 
//                 ( SYS_DATE,                SYS_ID,                 UPD_DATE,               UPD_ID,                 HOSP_CODE,
//                   FKINP1001,               BUNHO,                  TRANS_CNT,              TRANS_TIME,             
//                   START_DATE,              TONGGYE_DATE,           FROM_GWA,               TO_GWA,                 
//                   FROM_DOCTOR,             TO_DOCTOR,              FROM_RESIDENT,          TO_RESIDENT,
//                   CANCEL_SAYU,             
//                   FROM_HO_CODE1,           FROM_HO_DONG1,          TO_HO_CODE1,            TO_HO_DONG1,        
//                   FROM_HO_CODE2,           FROM_HO_DONG2,          TO_HO_CODE2,            TO_HO_DONG2,      
//                   CANCEL_YN,               END_DATE,   
//                   TO_NURSE_CONFIRM_ID,     TO_NURSE_CONFIRM_DATE,
//                   TRANS_GUBUN,             FROM_BED_NO,            TO_BED_NO,              TO_NURSE_CONFIRM_TIME, 
//                   TO_HO_GRADE1,            TO_HO_GRADE2)
//            VALUES    
//                ( SYSDATE,                  :q_user_id,             SYSDATE,                    :q_user_id,              :i_hosp_code,
//                  :i_fkinp1001,             :i_bunho,               NVL(TRIM(:o_trans_cnt),1),  TO_CHAR(SYSDATE,'HH24MI'),  
//                  TRUNC(SYSDATE),           SYSDATE,                TRIM(:o_to_gwa),            TRIM(:o_to_gwa),
//                  :o_to_doctor,             :o_to_doctor,           :o_to_resident,             :o_to_resident,
//                  null,                     
//                  :i_from_ho_code,          :i_from_ho_dong,        :i_to_ho_code,              :i_to_ho_dong,              
//                  :o_to_ho_code2,           :o_to_ho_dong2,         :o_to_ho_code2,             :o_to_ho_dong2,                    
//                  'N',                      TO_DATE('9998/12/31', 'YYYY/MM/DD') ,         
//                  :q_user_id,               TRUNC(SYSDATE),    
//                  '03',                     :i_from_bed_no,         :i_to_bed_no,               TO_CHAR(SYSDATE, 'HH24MI'),
//                  :o_to_ho_grade1,          :o_to_ho_grade2)";
//                }
//                else
//                {
                    cmdText = string.Empty;
                    retVal = null;
                    cmdText = @"
            INSERT INTO INP2004  
                  ( SYS_DATE,               SYS_ID,                 UPD_DATE,               UPD_ID,         HOSP_CODE,
                    FKINP1001,              BUNHO,                  TRANS_CNT,              TRANS_TIME,         
                    START_DATE,             TONGGYE_DATE,           FROM_GWA,               TO_GWA,
                    FROM_DOCTOR,            TO_DOCTOR,              FROM_RESIDENT,          TO_RESIDENT,
                    CANCEL_SAYU,            
                    FROM_HO_CODE1,          FROM_HO_DONG1,          TO_HO_CODE1,            TO_HO_DONG1,            
                    FROM_HO_CODE2,          FROM_HO_DONG2,          TO_HO_CODE2,            TO_HO_DONG2,     
                    CANCEL_YN,              END_DATE, 
                    TO_NURSE_CONFIRM_ID,    TO_NURSE_CONFIRM_DATE,
                    TRANS_GUBUN,            FROM_BED_NO,            TO_BED_NO          ,    TO_NURSE_CONFIRM_TIME, 
                    TO_HO_GRADE1,            TO_HO_GRADE2, 
                    FROM_KAIKEI_HODONG   , FROM_KAIKEI_HOCODE    , TO_KAIKEI_HODONG          , TO_KAIKEI_HOCODE)
             VALUES 
                  ( SYSDATE,                :q_user_id,             SYSDATE,                    :q_user_id,    :i_hosp_code,
                    :i_fkinp1001,           :i_bunho,               NVL(TRIM(:o_trans_cnt),1),  TO_CHAR(SYSDATE,'HH24MI'),  
                    TRUNC(SYSDATE),         SYSDATE,                TRIM(:o_to_gwa),            TRIM(:o_to_gwa),
                    :o_to_doctor,           :o_to_doctor,           :o_to_resident,             :o_to_resident,
                    null,                   
                    :i_from_ho_code,        :i_from_ho_dong,        :i_to_ho_code,              :i_to_ho_dong,             
                    NULL,                   NULL,                   NULL,                       NULL,   
                    'N',                    TO_DATE('9998/12/31', 'YYYY/MM/DD'),
                    :q_user_id,             TRUNC(SYSDATE),     
                    '03',                   :i_from_bed_no,         :i_to_bed_no,               TO_CHAR(SYSDATE, 'HH24MI'),
                    :o_to_ho_grade1,        :o_to_ho_grade2,
                    :i_from_kaikei_hodong,  :i_from_kaikei_hocode,  :o_to_kaikei_hodong,       :o_to_kaikei_hocode   )";
                //}
            }

            try
            {
                Service.BeginTransaction();
                if (!Service.ExecuteNonQuery(cmdText, bindVars))
                {
                    throw new Exception("転室データの生成に失敗しました。\n\r" + Service.ErrFullMsg);
                }

                int pkinp1001 = int.Parse(bindVars["i_fkinp1001"].VarValue);
                int transCnt  = int.Parse(bindVars["o_trans_cnt"].VarValue);
                string bedNo  = bindVars["i_to_bed_no"].VarValue;
                string if_key = string.Empty;

                int varResult = GetConfirmData(pkinp1001, transCnt, bedNo, UserInfo.UserID,"N");

                if (varResult != 0)
                    throw new Exception("転入確認中にてエラーが発生しました。\n\r" + Service.ErrFullMsg);
                               
                
                Service.CommitTransaction();


                //病床だけ変える時はサクラに転送しない。 20130621
                if (dragBed.Kaikei_HoDong == to_kaikei_hodong && dragBed.Kaikei_HoCode == to_kaikei_hocode)
                {
                    return true;
                }

                if_key = SakuraChangeTrans("2", "I", dragBed.Bunho, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), to_kaikei_hodong,
                                           to_kaikei_hocode, bedNo, bindVars["o_to_gwa"].VarValue, bindVars["o_to_doctor"].VarValue, pkinp1001.ToString(), mNurseID, "");
                
                if(!if_key.Equals(string.Empty))
                {
                    IFServiceCall(if_key);
                }
            }
            catch 
            {
                Service.RollbackTransaction();
                //XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                return false;
            }
            return true;
        }
        #endregion


        #region SakuraChangeTrans
        /// <summary>
        /// 転科転室転送情報作成(IFS3011)
        /// PR_IFS_MAKE_IPWON_HISTORY 사용
        /// </summary>
        /// <param name="data_gubun">1：入院, 2：転入, 4：退院</param>
        /// <param name="proc_gubun">I：登録, U：修正, D：削除</param>
        /// <param name="bunho">患者番号</param>
        /// <param name="data_date">データ日付</param>
        /// <param name="ho_dong">棟コード</param>
        /// <param name="ho_code">室コード</param>
        /// <param name="bed_no">床コード</param>
        /// <param name="gwa">科コード</param>
        /// <param name="doctor">医師コード</param>
        /// <param name="pkinp1001">PKINP1001</param>
        /// <param name="userid">登録者ID</param>
        /// <param name="toiwon_gubun">[""可] １：治癒、２：死亡、３：中止、４：他移、５：転医、６：転科、７：軽快、８：転棟、９：転室</param>

        private string SakuraChangeTrans(string data_gubun, string proc_gubun, string bunho, string data_date, string ho_dong, string ho_code, string bed_no, string gwa, string doctor, string pkinp1001, string userid, string toiwon_gubun)
        {
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add(EnvironInfo.HospCode);
            inputList.Add(proc_gubun);
            inputList.Add(bunho);
            inputList.Add(data_date);
            inputList.Add(ho_dong);
            inputList.Add(ho_code);
            inputList.Add(""); //inputList.Add(bed_no); ベッド番号は会計に必要ない。(20130621)
            inputList.Add(gwa);
            inputList.Add(doctor);
            inputList.Add(pkinp1001);
            inputList.Add(userid);
            inputList.Add(data_gubun);
            inputList.Add(toiwon_gubun);

            if (!Service.ExecuteProcedure("PR_IFS_MAKE_IPWON_HISTORY", inputList, outputList))
            {
                XMessageBox.Show("SAKURAへのデータ処理に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg,
                                  "処理失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return string.Empty;
            }
            else
            {
                if (outputList[1].ToString() != "0")
                {
                    XMessageBox.Show("SAKURAへのデータ処理に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg,
                                     "処理失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
                return outputList[0].ToString();
            }
        }

        private bool IFServiceCall(string If_key)
        {

            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText = "00231" + If_key;

            //XMessageBox.Show(msgText);

            int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);

            if (ret == -1)
            {
                XMessageBox.Show("SAKURAへのデータ転送に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg,
                                 "転送失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            XMessageBox.Show("SAKURAへのデータ転送が完了しました。",
                             "転送完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }

        #endregion

        #region ChangeHosil() dsvChangeHosil
        private bool ChangeHosil(BedBox dragBed, BedBox dropBed)
        {
            //-- DataService 변환 properties  2010.05. 河中  ---------------------*
            string cmdText = string.Empty;
            DataTable resTable = new DataTable();
            object retVal = new object();
            BindVarCollection bindVars = new BindVarCollection();
            //--------------------------------------------------------------------*
            /*--------------------------------------------------------------------*
             * dsvChangeHosil Service 변환                  2010.05. 河中
             * -------------------------------------------------------------------*/
            // bind 변수 설정
            bindVars.Add("i_hosp_code", this.mHospCode);
            bindVars.Add("i_from_fkinp1001", dragBed.Pkinp1001.ToString());
            bindVars.Add("i_to_fkinp1001",   dropBed.Pkinp1001.ToString());
            bindVars.Add("i_from_bunho",     dragBed.Bunho);
            bindVars.Add("i_to_bunho",       dropBed.Bunho);
            bindVars.Add("i_from_ho_dong",   cboHoDong.GetDataValue());
            bindVars.Add("i_to_ho_dong",     cboHoDong.GetDataValue());
            bindVars.Add("i_from_ho_code",   dragBed.HoCode);
            bindVars.Add("i_to_ho_code",     dropBed.HoCode);
            bindVars.Add("i_from_bed_no",    dragBed.BedNumber.ToString().PadLeft(2, '0'));
            bindVars.Add("i_to_bed_no",      dropBed.BedNumber.ToString().PadLeft(2, '0'));

            bindVars.Add("q_user_id", UserInfo.UserID);
            
            /* FROM 환자 */
            cmdText = @"SELECT 'Y'
                          FROM DUAL
                         WHERE EXISTS (SELECT 'X'
                                         FROM INP2004 A
                                        WHERE A.HOSP_CODE           = :i_hosp_code
                                          AND A.BUNHO               = :i_from_bunho
                                          AND NVL(A.CANCEL_YN, 'N') = 'N'
                                          AND A.FKINP1001           = :i_from_fkinp1001
                                          AND A.TO_NURSE_CONFIRM_DATE IS NULL)";
            retVal = Service.ExecuteScalar(cmdText, bindVars);
            
            if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
            {
                /*전실맞바꿈 처리를 못함*/
                GetMessage("3559");
                return false;
            }

            cmdText = string.Empty;
            retVal = null;

            /* TO 환자 */
            cmdText = @"SELECT 'Y'
                          FROM DUAL
                         WHERE EXISTS (SELECT 'X'
                                         FROM INP2004 A
                                        WHERE A.HOSP_CODE           = :i_hosp_code
                                          AND A.BUNHO               = :i_to_bunho
                                          AND NVL(A.CANCEL_YN, 'N') = 'N'
                                          AND A.FKINP1001           = :i_to_fkinp1001
                                          AND A.TO_NURSE_CONFIRM_DATE IS NULL)";
            retVal = Service.ExecuteScalar(cmdText, bindVars);

            if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
            {
                /*전실맞바꿈 처리를 못함*/
                GetMessage("3559");
                return false;
            }

            cmdText = string.Empty;
            retVal = null;

            string doubleHoYn = "";

            /* 1.병실맞바꿈을 할 때 이동 병실에 하이케어실이 들어 가 있는 경우는 같은 환자의 경우에만 이동이 허용) */
            /* 2. 이동하는 병실이 하이케어실인지를 조회를 한다. */
            /* FROM 병실이 하이케어실인지 조회를 한다. */
            cmdText = @"SELECT 'Y'
                          FROM DUAL
                         WHERE EXISTS (SELECT 'X'
                                         FROM BAS0250 A
                                        WHERE A.HOSP_CODE = :i_hosp_code
                                          AND A.HO_DONG   = :i_from_ho_dong
                                          AND A.HO_CODE   = :i_from_ho_code
                                          AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE
                                          AND NVL(A.DOUBLE_HO_YN, 'N') = 'Y'";
            retVal = Service.ExecuteScalar(cmdText, bindVars);

            if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
            {
                doubleHoYn = retVal.ToString();
            }
            else if(!TypeCheck.IsNull(retVal))
            {
                XMessageBox.Show("DOUBLE_ROOM CHECK ERROR", "ERROR", MessageBoxIcon.Hand);
                return false;
            }

            if(TypeCheck.IsNull(retVal))
            {
                /* TO 병실이 하이케어실인지를 조회한다. */
                cmdText = "";
                retVal = null;
                cmdText = @"SELECT 'Y'
                              FROM DUAL
                             WHERE EXISTS (SELECT 'X'
                                             FROM BAS0250 A
                                            WHERE A.HOSP_CODE = :i_hosp_code
                                              AND A.HO_DONG   = :i_to_ho_dong   --:i_from_ho_dong
                                              AND A.HO_CODE   = :i_to_ho_code   --:i_from_ho_code                                              
                                              AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE
                                              AND NVL(A.DOUBLE_HO_YN, 'N') = 'Y')";
                retVal = Service.ExecuteScalar(cmdText, bindVars);

                if (!TypeCheck.IsNull(retVal) && Service.ErrCode != 0)
                {
                    XMessageBox.Show("DOUBLE_ROOM CHECK ERROR", "ERROR", MessageBoxIcon.Hand);
                    return false;
                }
            }

            /* 병실 맞바꿈에서 이동 병실에 하이케어실이 들어 가면 같은 환자일 경우에만 병실 맞바꿈이 일어남 */
            if (doubleHoYn.Equals("Y") && !bindVars["i_from_fkinp1001"].VarValue.Equals(bindVars["i_to_fkinp1001"].VarValue))
            {
                /* 하이케어실의 병실 맞바꿈은 같은 환자일 경우에만 가능합니다.*/
                GetMessage("3268");
                return false;
            }

            /* 하이케어실에서 원래의 병실로 돌아 갈 경우*/
            if (bindVars["i_from_ho_dong"].VarValue.Equals(bindVars["i_to_ho_dong"].VarValue) &&
                bindVars["i_from_fkinp1001"].VarValue.Equals(bindVars["i_to_fkinp1001"].VarValue))
            {
                bindVars.Add("o_junpyo_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
               
                /*전과전실횟차 로드*/
                cmdText = string.Empty;
                retVal = null;
                cmdText = @"SELECT MAX(TRANS_CNT) + 1
                          FROM INP2004
                         WHERE HOSP_CODE = :i_hosp_code
                           AND FKINP1001 = :i_from_fkinp1001";
                retVal = Service.ExecuteScalar(cmdText, bindVars);
                if (Service.ErrCode != 0 && Service.ErrCode != 1403 && !TypeCheck.IsNull(retVal)) //1432
                {
                    /*전과전실 도중 에러가 발생하였습니다.*/
                    GetMessage("464");
                    return false;
                }
                else if(!TypeCheck.IsNull(retVal))
                {
                    bindVars.Add("o_trans_cnt", retVal.ToString());
                }

                cmdText = string.Empty;
                cmdText = @"SELECT A.GWA
                                  ,A.DOCTOR
                                  ,A.RESIDENT
                                  ,A.HO_CODE1
                                  ,A.HO_DONG1
                                  ,A.HO_CODE2
                                  ,A.HO_DONG2
                                  ,A.BED_NO
                                  ,A.BED_NO2
                              FROM VW_OCS_INP1001_01 A
                             WHERE A.HOSP_CODE = :i_hosp_code
                               AND A.PKINP1001 = :i_from_fkinp1001";
                resTable = Service.ExecuteDataTable(cmdText, bindVars);
                if (resTable.Rows.Count > 0)
                {
                    bindVars.Add("o_to_gwa", resTable.Rows[0]["gwa"].ToString());
                    bindVars.Add("o_to_doctor", resTable.Rows[0]["doctor"].ToString());
                    bindVars.Add("o_to_resident", resTable.Rows[0]["resident"].ToString());
                    bindVars.Add("o_to_ho_code1", resTable.Rows[0]["ho_code1"].ToString());
                    bindVars.Add("o_to_ho_dong1", resTable.Rows[0]["ho_dong1"].ToString());
                    bindVars.Add("o_to_ho_code2", resTable.Rows[0]["ho_code2"].ToString());
                    bindVars.Add("o_to_ho_dong2", resTable.Rows[0]["ho_dong2"].ToString());
                    bindVars.Add("o_to_bed_no", resTable.Rows[0]["bed_no"].ToString());
                    bindVars.Add("o_to_bed_no2", resTable.Rows[0]["bed_no2"].ToString());
                }
                else if (Service.ErrCode != 0 && Service.ErrCode != 1403 && !TypeCheck.IsNull(retVal)) //1432
                {
                    /*전과전실 도중 에러가 발생하였습니다.*/
                    GetMessage("464");
                    return false;
                }

                cmdText = "";
                retVal = null;

                /* 예비실이 아닌 경우에만 새로 병실의 등급을 조회를 해서 처리 */
//                cmdText = @"SELECT A.WING_GUBUN
//                          FROM BAS0250 A
//                         WHERE A.HOSP_CODE   = :i_hosp_code
//                           AND A.HO_DONG     = :i_to_ho_dong
//                           AND A.HO_CODE     = :i_to_ho_code
//                           AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE";
//                retVal = Service.ExecuteScalar(cmdText, bindVars);

//                if (!TypeCheck.IsNull(retVal))
//                {
//                    if (!retVal.ToString().Equals("99"))
//                    {
                /* HO_GRADE를 조회한다. */
                cmdText = "";
                resTable.Clear();
                cmdText = @"SELECT A.HO_GRADE       HO_GRADE
                               --, A.HO_STATUS
                              FROM BAS0250 A
                             WHERE A.HOSP_CODE = :i_hosp_code
                               AND A.HO_DONG   = :i_to_ho_dong
                               AND A.HO_CODE   = :i_to_ho_code
                               AND NVL(:o_junpyo_date, TRUNC(SYSDATE)) BETWEEN A.START_DATE AND A.END_DATE";
                resTable = Service.ExecuteDataTable(cmdText, bindVars);

                if (resTable.Rows.Count > 0)
                {
                    bindVars.Add("o_to_ho_grade1", resTable.Rows[0]["ho_grade"].ToString());
                    bindVars.Add("o_to_ho_status1", resTable.Rows[0]["ho_status"].ToString());
                }
                else if (Service.ErrCode != 0 && resTable.Rows.Count > 0)
                {
                    //GetMessage("141");
                    XMessageBox.Show("病室等級の照会中にエラーが発生しました。", "お知らせ", MessageBoxIcon.Information);
                    return false;
                }
//                    }
//                }
//                else if (Service.ErrCode != 0 && Service.ErrCode != 1432 && !TypeCheck.IsNull(retVal))
//                {
//                    return false;
//                }

                cmdText = "";
                cmdText = @"
                INSERT INTO INP2004   
                         ( SYS_DATE,                SYS_ID,                 UPD_DATE,               UPD_ID,      HOSP_CODE,
                           FKINP1001,               BUNHO,                  TRANS_CNT,              TRANS_TIME,         
                           START_DATE,              TONGGYE_DATE,           FROM_GWA,               TO_GWA,
                           FROM_DOCTOR,             TO_DOCTOR,              FROM_RESIDENT,          TO_RESIDENT,
                           CANCEL_SAYU,             FROM_HO_CODE1,
                           FROM_HO_DONG1,           TO_HO_CODE1,            TO_HO_DONG1,            FROM_HO_CODE2,      
                           FROM_HO_DONG2,           TO_HO_CODE2,            TO_HO_DONG2,        
                           CANCEL_YN,               END_DATE,    
                           TO_NURSE_CONFIRM_ID,     TO_NURSE_CONFIRM_DATE,
                           TRANS_GUBUN,             FROM_BED_NO,            TO_BED_NO,                  TO_NURSE_CONFIRM_TIME)
                    VALUES               
                         ( SYSDATE,                 :q_user_id,             SYSDATE,                    :q_user_id,   :i_hosp_code,
                           :i_from_fkinp1001,       :i_from_bunho,          NVL(TRIM(:o_trans_cnt),1),  TO_CHAR(SYSDATE,'HH24MI'),  
                           :o_junpyo_date,          :o_junpyo_date,         TRIM(:o_to_gwa),            TRIM(:o_to_gwa),
                           :o_to_doctor,            :o_to_doctor,           :o_to_resident,             :o_to_resident,
                           null,                    :o_to_ho_code2,
                           :o_to_ho_dong2,          :o_to_ho_code1,         :o_to_ho_dong1,             NULL,               
                           NULL,                    NULL,                   NULL,             
                           'N',                     TO_DATE('9998/12/31', 'YYYY/MM/DD'),
                           :q_user_id,                 TRUNC(SYSDATE),     
                           '03',                    :o_to_bed_no2,          :o_to_bed_no,               TO_CHAR(SYSDATE, 'HH24MI'))";
                try
                {
                    Service.BeginTransaction();
                    if (!Service.ExecuteNonQuery(cmdText, bindVars))
                    {
                        throw new Exception("転室データの生成に失敗しました。\n\r" + Service.ErrFullMsg);
                    }

                    if (GetConfirmData(int.Parse(bindVars["i_from_fkinp1001"].VarValue),
                        int.Parse(bindVars["o_trans_cnt"].VarValue), bindVars["o_to_bed_no"].VarValue, UserInfo.UserID,"Y") == 0)
                    {
                    }
                    else
                    {
                        throw new Exception("転入確認にてエラーが発生しました。");
                    }
                    Service.CommitTransaction();
                }
                catch (Exception xe)
                {
                    Service.RollbackTransaction();
					//https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                    return false;
                }
            }
            else /* 다른환자끼리 병실을 맞바꿈을 할 경우 */
            {
                /*from 환자의 병동병실정보 변경됨.*/
                cmdText = @"SELECT 'Y'
                              FROM DUAL
                             WHERE EXISTS ( SELECT 'X'
                                                  FROM VW_OCS_INP1001_01
                                                 WHERE HOSP_CODE = :i_hosp_code 
                                                   AND PKINP1001 = :i_from_fkinp1001
                                                   AND HO_DONG1  = :i_from_ho_dong
                                                   AND HO_CODE1  = :i_from_ho_code
                                                   AND BED_NO    = :i_from_bed_no )";
                retVal = Service.ExecuteScalar(cmdText, bindVars);
                if (Service.ErrCode != 0)
                {
                    //転室する患者の病床情報が変更されました。ご確認下さい
                    GetMessage("462");
                    return false;
                }

                cmdText = "";
                retVal = null;
                /*To 환자의 병동병실정보 변경됨.*/
                cmdText = @"SELECT 'Y'
                              FROM DUAL
                             WHERE EXISTS ( SELECT 'X'
                                              FROM VW_OCS_INP1001_01
                                             WHERE HOSP_CODE = :i_hosp_code 
                                               AND PKINP1001 = :i_to_fkinp1001
                                               AND HO_DONG1  = :i_to_ho_dong
                                               AND HO_CODE1  = :i_to_ho_code
                                               AND BED_NO    = :i_to_bed_no )";
                retVal = Service.ExecuteScalar(cmdText, bindVars);
                if (Service.ErrCode != 0)
                {
                    GetMessage("462");
                    return false;
                }

                cmdText = "";
                cmdText = @"SELECT MAX(TRANS_CNT) + 1 TRANS_CNT
                              FROM INP2004
                             WHERE HOSP_CODE = :i_hosp_code
                               AND FKINP1001 = :i_from_fkinp1001";
                object from_trans_cnt = Service.ExecuteScalar(cmdText, bindVars);

                if (!TypeCheck.IsNull(from_trans_cnt))
                {
                    bindVars.Add("o_from_trans_cnt", from_trans_cnt.ToString());
                }

                cmdText = "";
                cmdText = @"SELECT MAX(TRANS_CNT) + 1 TRANS_CNT
                              FROM INP2004
                             WHERE HOSP_CODE = :i_hosp_code
                               AND FKINP1001 = :i_to_fkinp1001";
                object to_trans_cnt = Service.ExecuteScalar(cmdText, bindVars);

                if (!TypeCheck.IsNull(to_trans_cnt))
                {
                    bindVars.Add("o_to_trans_cnt", to_trans_cnt.ToString());
                }

                string from_kaikei_change = "N";
                string to_kaikei_change = "N";

                string from_kaikei_hodong = dragBed.Kaikei_HoDong;
                string from_kaikei_hocode = dragBed.Kaikei_HoCode;
                string to_kaikei_hodong = dropBed.Kaikei_HoDong;
                string to_kaikei_hocode = dropBed.Kaikei_HoCode;


                if (dragBed.Kaikei_HoDong != dropBed.HoDong || dragBed.Kaikei_HoCode != dropBed.HoCode)
                {
                    if (XMessageBox.Show("[ " + dragBed.SuName + "] さんの\r\n扱い病室情報を \r\n\r\n" +
                         "　元　：　" + dragBed.Kaikei_HoDong + "棟　" + dragBed.Kaikei_HoCode + "号室から\r\n" +
                         "　現　：　" + dropBed.HoDong + "棟　" + dropBed.HoCode + "号室に\r\n\r\n" +
                         "変更しますか？", "確認",
                         MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        from_kaikei_change = "Y";

                        from_kaikei_hodong = dropBed.HoDong;
                        from_kaikei_hocode = dropBed.HoCode;
                    }
                }

                if (dropBed.Kaikei_HoDong != dragBed.HoDong || dropBed.Kaikei_HoCode != dragBed.HoCode)
                {
                    if (XMessageBox.Show("[ " + dropBed.SuName + "] さんの\r\n扱い病室情報を \r\n\r\n" +
                         "　元　：　" + dropBed.Kaikei_HoDong + "棟　" + dropBed.Kaikei_HoCode + "号室から\r\n" +
                         "　現　：　" + dragBed.HoDong + "棟　" + dragBed.HoCode + "号室に\r\n\r\n" +
                         "変更しますか？", "確認",
                         MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        to_kaikei_change = "Y";

                        to_kaikei_hodong = dragBed.HoDong;
                        to_kaikei_hocode = dragBed.HoCode;
                    }
                }
                
                ArrayList inputList = new ArrayList();
                ArrayList outputList = new ArrayList();
                inputList.Add(bindVars["i_from_fkinp1001"].VarValue);
                inputList.Add(bindVars["i_to_fkinp1001"].VarValue);
                inputList.Add(bindVars["i_from_bunho"].VarValue);
                inputList.Add(bindVars["i_to_bunho"].VarValue);
                inputList.Add(from_kaikei_change);
                inputList.Add(to_kaikei_change);
                inputList.Add(bindVars["o_from_trans_cnt"].VarValue);
                inputList.Add(bindVars["o_to_trans_cnt"].VarValue);
                inputList.Add(bindVars["q_user_id"].VarValue);
                //inputList.Add(this.mHospCode);

                try
                {
                    Service.BeginTransaction();
                    /*INP2004생성*/
                    if (Service.ExecuteProcedure("PR_NUR_CHANGE_HOCODE", inputList, outputList))
                    {
                        if (!outputList[0].ToString().Equals("0"))
                        //if (!flag.Equals("0"))
                        {
                            //GetMessage("462");
                            throw new Exception("転室データの生成に失敗しました。\n\r" + Service.ErrFullMsg);
                        }
                    }
                    else
                    {
                        throw new Exception("転室データの生成に失敗しました。\n\r" + Service.ErrFullMsg);
                    }

                    /*from전과전실확인처리*/
                    if (GetConfirmData(int.Parse(bindVars["i_from_fkinp1001"].VarValue),
                            int.Parse(bindVars["o_from_trans_cnt"].VarValue), bindVars["i_to_bed_no"].VarValue, UserInfo.UserID, "Y") != 0)
                    {
                        throw new Exception("転入確認中にてエラーが発生しました。\n\r" + Service.ErrFullMsg);
                    }
                    /*to전과전실확인처리*/
                    if (GetConfirmData(int.Parse(bindVars["i_to_fkinp1001"].VarValue),
                            int.Parse(bindVars["o_to_trans_cnt"].VarValue), bindVars["i_from_bed_no"].VarValue, UserInfo.UserID, "Y") != 0)
                    {
                        throw new Exception("転入確認中にてエラーが発生しました。\n\r" + Service.ErrFullMsg);
                    }


                    Service.CommitTransaction();

                    inputList.Clear();
                    outputList.Clear();

                    inputList.Add(EnvironInfo.HospCode);
                    inputList.Add(this.cboHoDong.GetDataValue());

                    Service.ExecuteProcedure("PR_BAS_BAS0250_REFRESH", inputList, outputList);

                    
                    //사쿠라 전송 2회

                    //전송 여부 다시한번 확인. (관리용 병실정보만 바뀌었을 경우에는 전송 안함)

                    string gwa = "";
                    string doctor ="";

                    DataRow[] temp;

                    // from의 전송
                    if (dragBed.Kaikei_HoDong == from_kaikei_hodong && dragBed.Kaikei_HoCode == from_kaikei_hocode)
                    {
                        return true;
                    }
                    else
                    {
                        temp = layPatientList.LayoutTable.Select("pkinp1001 = '" + dragBed.Pkinp1001.ToString() + "'");

                        if (temp.Length > 0)
                        {
                            gwa = temp[0]["gwa"].ToString();
                            doctor = temp[0]["doctor"].ToString();

                            string if_key = SakuraChangeTrans("2", "I", dragBed.Bunho, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), from_kaikei_hodong, from_kaikei_hocode,
                                                               "", gwa, doctor, dragBed.Pkinp1001.ToString(), mNurseID, "");

                            if (!if_key.Equals(string.Empty))
                            {
                                IFServiceCall(if_key);
                            }
                        }
                    }

                    // to의 전송
                    if (dropBed.Kaikei_HoDong == to_kaikei_hodong && dropBed.Kaikei_HoCode == to_kaikei_hocode)
                    {
                        return true;
                    }
                    else
                    {
                        temp = layPatientList.LayoutTable.Select("pkinp1001 = '" + dropBed.Pkinp1001.ToString() + "'");

                        if (temp.Length > 0)
                        {
                            gwa = temp[0]["gwa"].ToString();
                            doctor = temp[0]["doctor"].ToString();

                            string if_key = SakuraChangeTrans("2", "I", dropBed.Bunho, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), to_kaikei_hodong, to_kaikei_hocode,
                                                               "", layConfirmData.GetItemValue("to_gwa").ToString(), layConfirmData.GetItemValue("to_doctor").ToString(),
                                                               dropBed.Pkinp1001.ToString(), mNurseID, "");

                            if (!if_key.Equals(string.Empty))
                            {
                                IFServiceCall(if_key);
                            }
                        }
                    }

                }
                catch (Exception xe)
                {
                    Service.RollbackTransaction();
					//https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region GetConfirmData()
        /// <summary>
        /// 전과전실확인 처리
        /// </summary>
        /// <param name="param_pkinp1001"></param>
        /// <param name="param_trans_cnt"></param>
        /// <param name="param_bed_no"></param>
        /// <param name="param_user_id"></param>
        /// <returns></returns>
        public int GetConfirmData(int param_pkinp1001, int param_trans_cnt, string param_bed_no, string param_user_id, string param_change_gubun)
        {
            int rtnValue = 0;
            int o_max_trans = 0;
            int o_new_trans = 0;
            BindVarCollection confirmBindVar = new BindVarCollection();
            BindVarCollection sub_confirmBindVar = new BindVarCollection();
            string junpyo_date = string.Empty;
            /*입원정보 변경처리
              심사마감체크처리
               0.INP1001 정보변경처리
               2.이중유형에 대한 전실처리.->전과는 무시하고 전실은 이중유형에도 반영
               3.전실처리시(병동병실변경시) 영양실 네임카드 자동출력
               4.영양실 식이처방 병동병실정보수정
               5.특진여부 변경시 OCS2011반영
               6.고정차지 실행(반드시 영양실반영후 처리)
               7.슬립재처리(PR_INP_TRANS_SLIP)             */

            this.layConfirmData.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layConfirmData.SetBindVarValue("f_fkinp1001", param_pkinp1001.ToString());
            this.layConfirmData.SetBindVarValue("f_trans_cnt", param_trans_cnt.ToString());

            if (!this.layConfirmData.QueryLayout())
            {
                if (!TypeCheck.IsNull(this.layConfirmData.GetItemValue("fkinp1001")))
                {
                    XMessageBox.Show("該当患者の転室情報ロード中にエラーが発生しました。", "エラー", MessageBoxIcon.Error);
                    return 1;
                }
            }

            string o_fkinp1001          = this.layConfirmData.GetItemValue("fkinp1001").ToString();
            string o_bunho              = this.layConfirmData.GetItemValue("bunho").ToString();
            string o_order_date         = this.layConfirmData.GetItemValue("start_date").ToString();
            string o_trans_time         = this.layConfirmData.GetItemValue("trans_time").ToString();
            string o_to_gwa             = this.layConfirmData.GetItemValue("to_gwa").ToString(); 
            string o_to_doctor          = this.layConfirmData.GetItemValue("to_doctor").ToString();
            string o_to_resident        = this.layConfirmData.GetItemValue("to_resident").ToString(); 
            string o_to_ho_code1        = this.layConfirmData.GetItemValue("to_ho_code1").ToString(); 
            string o_to_ho_dong1        = this.layConfirmData.GetItemValue("to_ho_dong1").ToString();
            string o_to_ho_code2        = this.layConfirmData.GetItemValue("to_ho_code2").ToString(); 
            string o_to_ho_dong2        = this.layConfirmData.GetItemValue("to_ho_dong2").ToString(); 
            string o_trans_gubun        = this.layConfirmData.GetItemValue("trans_gubun").ToString(); 
            string o_to_bed_no          = this.layConfirmData.GetItemValue("to_bed_no").ToString(); 
            string o_to_bed_no2         = this.layConfirmData.GetItemValue("to_bed_no2").ToString(); 
            string o_from_ho_code1      = this.layConfirmData.GetItemValue("from_ho_code1").ToString();
            string o_from_ho_dong1      = this.layConfirmData.GetItemValue("from_ho_dong1").ToString();
            string o_from_bed_no        = this.layConfirmData.GetItemValue("from_bed_no").ToString();
            string o_to_grade1          = this.layConfirmData.GetItemValue("to_grade1").ToString();
            string o_to_grade2          = this.layConfirmData.GetItemValue("to_grade2").ToString();
            string o_to_kaikei_hodong   = this.layConfirmData.GetItemValue("to_kaikei_hodong").ToString();
            string o_to_kaikei_hocode   = this.layConfirmData.GetItemValue("to_kaikei_hocode").ToString(); 
            string o_msg = string.Empty;

            /*0.퇴원예고체크*/
            string subStrSql = @"SELECT 'Y'
                                   FROM DUAL
                                  WHERE EXISTS (SELECT 'X'
                                                  FROM VW_OCS_INP1001_01 A
                                                 WHERE A.HOSP_CODE      = :f_hosp_code
                                                   AND A.PKINP1001      = TO_NUMBER(:f_fkinp1001)
                                                   AND A.TOIWON_GOJI_YN = 'Y')";

            sub_confirmBindVar.Add("f_hosp_code", this.mHospCode);
            sub_confirmBindVar.Add("f_fkinp1001", o_fkinp1001);
            Object rtn_value = Service.ExecuteScalar(subStrSql, sub_confirmBindVar);
            sub_confirmBindVar.Clear();

            if (rtn_value != null && rtn_value.ToString().Equals("Y"))
            {
                XMessageBox.Show("オーダ終了処理されているので転棟転室できません。", "注意", MessageBoxIcon.Asterisk);
                return 1;
            }

            string cmd = @" SELECT FN_INP_LOAD_SIMSA_YN(TO_NUMBER(:f_fkinp1001))
                                   FROM DUAL";
            sub_confirmBindVar.Add("f_fkinp1001", o_fkinp1001);
            object inner_rtn = Service.ExecuteScalar(cmd, sub_confirmBindVar);
            sub_confirmBindVar.Clear();

            if (inner_rtn != null && inner_rtn.ToString().Equals("0"))
            {
                XMessageBox.Show("該当患者は実施締切が完了され転室できません。", "注意", MessageBoxIcon.Asterisk);
                return 1;
            }

            /*확인베드로 변경*/
            o_to_bed_no = param_bed_no;

            if (o_to_ho_dong1 == o_from_ho_dong1 &&
                o_to_ho_code1 == o_from_ho_code1 &&
                o_to_bed_no == o_from_bed_no)
            { }
            else
            {
                /* 병상이동이 아닌 병상맞바꿈시에는 빈병상인지 체크할 필요 없음 */
                if (param_change_gubun != "Y")
                {
                    /*현재 확인된 베드체크*/
                    subStrSql = @" SELECT 'Y'
                             FROM DUAL
                            WHERE EXISTS (SELECT 'X'
                                            FROM BAS0253 B
                                           WHERE HOSP_CODE = :f_hosp_code 
                                             AND B.HO_DONG = :f_to_ho_dong1
                                             AND B.HO_CODE = :f_to_ho_code1
                                             AND B.BED_NO  = :f_to_bed_no
                                             AND B.BED_STATUS   IN ('00', '01')
                                             AND TRUNC(SYSDATE) BETWEEN FROM_BED_DATE
                                            AND NVL(TO_BED_DATE, TO_DATE('9998/12/31', 'YYYY/MM/DD')))";

                    sub_confirmBindVar.Add("f_hosp_code", this.mHospCode);
                    sub_confirmBindVar.Add("f_to_ho_dong1", o_to_ho_dong1);
                    sub_confirmBindVar.Add("f_to_ho_code1", o_to_ho_code1);
                    sub_confirmBindVar.Add("f_to_bed_no", o_to_bed_no);
                    rtn_value = Service.ExecuteScalar(subStrSql, sub_confirmBindVar);
                    sub_confirmBindVar.Clear();

                    if (TypeCheck.IsNull(rtn_value))
                    {
                        XMessageBox.Show("変更先病床が空床ではありません。ご確認ください。", "注意", MessageBoxIcon.Asterisk);
                        return 1;
                    }
                }
            }
            /*현재베드 상태 체크*/
            subStrSql = @"SELECT 'Y'
                            FROM DUAL
                            WHERE EXISTS ( SELECT 'X'
                                             FROM VW_OCS_INP1001_01 B
                                            WHERE B.HOSP_CODE     = :f_hosp_code 
                                              AND B.HO_DONG1      = :f_to_ho_dong1
                                              AND B.HO_CODE1      = :f_to_ho_code1
                                              AND B.BED_NO        = :f_to_bed_no
                                              AND B.BUNHO        != TO_NUMBER(:f_bunho)
                                              AND :f_change_gubun = 'N')";

            sub_confirmBindVar.Add("f_hosp_code", this.mHospCode);
            sub_confirmBindVar.Add("f_to_ho_dong1", o_to_ho_dong1);
            sub_confirmBindVar.Add("f_to_ho_code1", o_to_ho_code1);
            sub_confirmBindVar.Add("f_to_bed_no", o_to_bed_no);
            sub_confirmBindVar.Add("f_bunho", o_bunho);
            sub_confirmBindVar.Add("f_change_gubun", param_change_gubun);

            rtn_value = Service.ExecuteScalar(subStrSql, sub_confirmBindVar);
            sub_confirmBindVar.Clear();

            if (!TypeCheck.IsNull(rtn_value) && rtn_value.ToString().Equals("Y"))
            {
                XMessageBox.Show("変更先病床は既に割り当てられた病床です。ご確認ください。", "注意", MessageBoxIcon.Asterisk);
                return 1;
            }

            /* 먼저 여러번 전동 신청후 전동확인을 나중에 하는 경우 trans_cnt를 마지막으로 재부여 */
            this.layCommon.QuerySQL = @"SELECT MAX(TRANS_CNT)         max_trans_cnt,
                                             MAX(TRANS_CNT) + 1     new_trans_cnt
                                        FROM INP2004
                                       WHERE HOSP_CODE = :f_hosp_code
                                         AND FKINP1001 = :f_fkinp1001
                                         --AND TRUNC(SYSDATE) BETWEEN START_DATE AND END_DATE
　　　　　　　　　　　　　　　　　　　　　";

            this.layCommon.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layCommon.SetBindVarValue("f_fkinp1001", o_fkinp1001);

            if (this.layCommon.QueryLayout())
            {
                o_max_trans = Convert.ToInt32(this.layCommon.GetItemValue("retVal1"));
                o_new_trans = Convert.ToInt32(this.layCommon.GetItemValue("retVal2"));
            }

            if (o_max_trans != param_trans_cnt)
            {
                o_max_trans = o_new_trans;
            }

            /*INP2004 전과전실확인*/
            ConfirmTrans(UserInfo.UserID, o_max_trans, param_bed_no, o_fkinp1001, param_trans_cnt);

            ConfirmTransCancel(UserInfo.UserID, o_fkinp1001);

            junpyo_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

            /*0.입원정보변경처리*/

            BindVarCollection innerBindVar = new BindVarCollection();
            string innerSql = @"UPDATE INP1001                       
                                   SET UPD_DATE   = SYSDATE
                                     , UPD_ID     = :q_user_id
                                     , GWA        = TRIM(:f_to_gwa)  
                                     , DOCTOR     = :f_to_doctor     
                                     , RESIDENT   = :f_to_resident   
                                     , HO_CODE1   = :f_to_ho_code1 
                                     , HO_DONG1   = :f_to_ho_dong1 
                                     , BED_NO     = :f_to_bed_no   
                                     , BED_NO2    = :f_to_bed_no2     
                                     , HO_CODE2   = :f_to_ho_code2   
                                     , HO_DONG2   = :f_to_ho_dong2 
                                     , HO_GRADE1  = :f_to_ho_grade1 
                                     , HO_GRADE2  = :f_to_ho_grade2 
                                     , KAIKEI_HODONG = :f_to_kaikei_hodong
                                     , KAIKEI_HOCODE = :f_to_kaikei_hocode
                                 WHERE HOSP_CODE  = :f_hosp_code
                                   AND PKINP1001  = TO_NUMBER(:f_fkinp1001)";

            innerBindVar.Add("q_user_id", UserInfo.UserID);
            innerBindVar.Add("f_hosp_code", this.mHospCode);
            innerBindVar.Add("f_to_gwa", o_to_gwa);
            innerBindVar.Add("f_to_doctor", o_to_doctor);
            innerBindVar.Add("f_to_resident", o_to_resident);
            innerBindVar.Add("f_to_ho_code1", o_to_ho_code1);
            innerBindVar.Add("f_to_ho_dong1", o_to_ho_dong1);
            innerBindVar.Add("f_to_bed_no", o_to_bed_no);
            innerBindVar.Add("f_to_bed_no2", o_to_bed_no2);
            innerBindVar.Add("f_to_ho_code2", o_to_ho_code2);
            innerBindVar.Add("f_to_ho_dong2", o_to_ho_dong2);
            innerBindVar.Add("f_to_ho_grade1", o_to_grade1);
            innerBindVar.Add("f_to_ho_grade2", o_to_grade2);
            innerBindVar.Add("f_fkinp1001", param_pkinp1001.ToString());
            innerBindVar.Add("f_to_kaikei_hodong", o_to_kaikei_hodong);
            innerBindVar.Add("f_to_kaikei_hocode", o_to_kaikei_hocode);

            if (!Service.ExecuteNonQuery(innerSql, innerBindVar))
            {
                rtnValue = 1;
                throw new Exception("該当患者の入院情報病室変更時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
            }
            innerBindVar.Clear();

            if (o_from_ho_dong1.Equals(o_to_ho_dong1) && 
                o_from_ho_code1.Equals(o_to_ho_code1))// NurseCall Interface 전과전실
            {
                rtnValue = 0;
            }
            /*2.이중유형에 대한 전실처리.->전과는 무시하고 전실은 이중유형에도 반영*/
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add('I');
            inputList.Add(param_user_id);
            inputList.Add(param_pkinp1001.ToString());
            inputList.Add('0');
            inputList.Add(o_bunho);
            inputList.Add(o_order_date);
            inputList.Add(o_trans_time);
            inputList.Add(o_to_ho_code1);
            inputList.Add(o_to_ho_dong1);
            inputList.Add(o_to_grade1);
            inputList.Add(o_to_ho_code2);
            inputList.Add(o_to_ho_dong2);
            inputList.Add(o_to_grade2);
            inputList.Add(o_to_bed_no);

            if (!Service.ExecuteProcedure("PR_INP_UPDATE_JENGWA", inputList, outputList))
            {
                rtnValue = 1;
                throw new Exception("該当患者の入院情報病室変更時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
            }

            if (outputList[0].ToString() != "0")
            {
                rtnValue = 1;
                throw new Exception("該当患者の二重入院情報病室変更時エラーが発生しました。");
            }
            else
            {
                rtnValue = 0;
            }

            inputList.Clear();
            outputList.Clear();
            /*
                3.전실처리시(병동병실변경시) 영양실 네임카드 자동출력
                4.영양실 식이처방 병동병실정보수정
                5.특진여부 변경시 OCS2011반영
                6.고정차지 실행(반드시 영양실반영후 처리)
            */
            inputList.Add(param_pkinp1001.ToString());
            inputList.Add(o_bunho);
            inputList.Add(o_order_date);
            inputList.Add(junpyo_date);
            inputList.Add(o_to_doctor);
            inputList.Add(o_to_resident);
            inputList.Add(o_trans_gubun);
            inputList.Add(o_to_ho_dong1);
            inputList.Add(o_to_ho_code1);
            inputList.Add(param_user_id);

            if (Service.ExecuteProcedure("PR_NUR_CHANGE_GWAHODONG", inputList, outputList))
            {
                o_msg = outputList[0].ToString();
                if (o_msg != "0")
                {
                    rtnValue = 1;
                    throw new Exception("該当患者の入院情報病室変更時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
                }
            }
            else
            {
                rtnValue = 1;
                throw new Exception("該当患者の入院情報病室変更時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
            }

            sub_confirmBindVar.Clear();

            return rtnValue;
        }
        #endregion

        #region ConfirmTrans()
        private void ConfirmTrans(string param_userId, int param_trans_cnt, string param_bed_no, string param_pkinp1001, int param_i_trans_cnt)
        {
            BindVarCollection bindVars = new BindVarCollection();
            try
            {
                string strSql = @"UPDATE INP2004
                                     SET UPD_DATE              = SYSDATE
                                       , UPD_ID                = :f_user_id
                                       , TRANS_CNT             = :f_trans_cnt
                                       , TO_NURSE_CONFIRM_ID   = :f_user_id
                                       , TO_NURSE_CONFIRM_DATE = TO_CHAR(SYSDATE, 'YYYY/MM/DD')
                                       , TO_NURSE_CONFIRM_TIME = TO_CHAR(SYSDATE, 'HH24MI')
                                       , TO_BED_NO             = DECODE(TRIM(:f_bed_no),NULL,TO_BED_NO,'',TO_BED_NO,:f_bed_no)
                                   WHERE HOSP_CODE             = :f_hosp_code
                                     AND FKINP1001             = :f_fkinp1001
                                     AND TRANS_CNT             = :f_i_trans_cnt";
                bindVars.Add("f_hosp_code", this.mHospCode);
                bindVars.Add("f_user_id", param_userId);
                bindVars.Add("f_trans_cnt", param_trans_cnt.ToString());
                bindVars.Add("f_bed_no", param_bed_no);
                bindVars.Add("f_fkinp1001", param_pkinp1001);
                bindVars.Add("f_i_trans_cnt", param_i_trans_cnt.ToString());

                if(!Service.ExecuteNonQuery(strSql, bindVars))
                {
                    //if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                        throw new Exception("該当患者の転室情報確認時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
                }
            
                bindVars.Clear();
            }
            catch
            {
                throw new Exception("該当患者の転室情報確認時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
            }

        }
        //전입전실을 취소 했을 경우. 간호사 확인 전..

        private void ConfirmTransCancel(string param_userId, string param_pkinp1001)
        {
            BindVarCollection bindVars = new BindVarCollection();
            try
            {
                string strSql = @"UPDATE INP2004
                                     SET UPD_DATE  = SYSDATE
                                       , UPD_ID    = :f_user_id
                                       , CANCEL_YN = 'Y'
                                   WHERE HOSP_CODE = :f_hosp_code
                                    AND FKINP1001 = :f_fkinp1001
                                    AND TO_NURSE_CONFIRM_DATE IS NULL";

                bindVars.Add("f_hosp_code", this.mHospCode);
                bindVars.Add("f_user_id", param_userId);
                bindVars.Add("f_fkinp1001", param_pkinp1001);

                if (!Service.ExecuteNonQuery(strSql, bindVars))
                {
                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                        throw new Exception("該当患者の転室情報確認時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
                }
                
                bindVars.Clear();

            }
            catch 
            {
                throw new Exception("該当患者の転室情報確認時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
            }

        }
        #endregion

        private void pnlLeft_Click(object sender, EventArgs e)
        {
            this.pnlLeft.Focus();
        }

        //int mReconnectCnt = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!cbxTimer.Checked)
                return;

            this.timer.Enabled = false; // 시간 멈춤	
            if (!this.layChekNonConfirmOrder.QueryLayout())
            {
                //if (Service.ErrFullMsg == "DB Connection is not opened")
                //{
                //    mReconnectCnt++;
                //    //int auto_hide_time = (this.timer.Interval - 10000) / 1000;
                //    //XMessageBox.Show("データベースと繋がっていません。再接続します。\r\n" + //プログラムを再起動してください。\r\n" + 
                //    //                 "問題が続く場合は電算室にお問い合わせください。（" + mReconnectCnt.ToString() + "回再接続しました。）", "DBコネクションエラー", MessageBoxButtons.OK, MessageBoxDefaultButton.Button1, MessageBoxIcon.Information, auto_hide_time);

                //    if (Service.Connect())
                //    {
                //        mReconnectCnt = 0;                        
                //    }
                //    else
                //    {
                //        if (mReconnectCnt == 5)
                //        {
                //            this.cbxTimer.Checked = false;
                //            XMessageBox.Show("データベースと繋がっていません。\r\n" +
                //                             "ネットワーク上の問題だと思われます。再起動してください。\r\n" +
                //                             "再起動しても直らない場合は電算室にお問い合わせください。", "DBコネクションエラー（再起動必要）", MessageBoxIcon.Warning);

                //            mReconnectCnt = 0;  
                //        }
                //    }

                //    return;
                //}
            }
            this.timer.Enabled = true; // 시간 다시 수행


            if (this.layChekNonConfirmOrder.GetItemValue("exist_yn").ToString() == "Y")
            {
                DateTime beforeTime = DateTime.Now;
                try
                {
                    this.timer.Enabled = false; // 시간 멈춤					

                    // 알림 Sound						
                    try { IHIS.Framework.Kernel32.Nofify(); }
                    catch { };

                    NewOrder noForm = new NewOrder();
                    noForm.ShowDialog(this);
                    //noForm.BringToFront();
                    //XMessageBox.Show("sdfa");
                    //XScreen.OpenScreen(this, "OCS2003Q03", ScreenOpenStyle.ResponseFixed);

                }
                finally
                {
                    this.timer.Enabled = true; // 시간 다시 수행

                    //this.Activate();
                    //재조회
                    this.ExecuteQuery();

                    //// 미시행 메세지 화면을 오픈한지 5분이후에 확인한 경우 데이타 재조회..
                    //if (beforeTime.AddMinutes(5) <= DateTime.Now)
                    //{
                    //    // 미실행추가처방 리스트 조회 Service Call
                    //    this.QueryNoConfirmList(this.dtpFrom_Order_Date.GetDataValue(), this.dtpTo_Order_Date.GetDataValue(),
                    //        this.cboHo_Dong.GetDataValue(), this.fbxHo_Team.GetDataValue(), false);
                    //}

                    
                }
                
            }
        }

        private void btnSang_Click(object sender, EventArgs e)
        {
            if (this.selectedBedBox == null || this.selectedBedBox.Bunho == "")
            {
                this.GetMessage("bunho");
                return;
            }

            CommonItemCollection openParams = new CommonItemCollection();
            //openParams.Add("naewon_date", this.grdInp1001.GetItemDateTime(this.grdInp1001.CurrentRowNumber, "ipwon_date").ToString("yyyy/MM/dd"));
            openParams.Add("bunho", this.selectedBedBox.Bunho);
            openParams.Add("io_gubun", "I");
            //openParams.Add("gwa", this.layNUR1001A.GetItemValue("gwa").ToString());
            XScreen.OpenScreenWithParam(this, "OCSO", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void btnVital_Click(object sender, EventArgs e)
        {
            CommonItemCollection cic = new CommonItemCollection();

            cic.Add("date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            if (this.selectedBedBox != null && this.selectedBedBox.Bunho != "")
            {
                cic.Add("bunho", selectedBedBox.Bunho);
            }
            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR1020U00", ScreenOpenStyle.PopUpFixed, cic);
        }

        private void btnWorkSheet_Click(object sender, EventArgs e)
        {
            CommonItemCollection cic = new CommonItemCollection();

            cic.Add("date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "OCS2003Q11", ScreenOpenStyle.PopUpFixed, cic);
        }

        private void cbxTimer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTimer.Checked)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }

        private void NUR1010Q00_Load(object sender, EventArgs e)
        {
            btnVital.Image = jobImageList.Images[3];
        }

        private void grdGwaCount_QueryStarting(object sender, CancelEventArgs e)
        {
            grdGwaCount.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdGwaCount.SetBindVarValue("f_ho_dong", cboHoDong.GetDataValue());

        }

        private void grdGwaCount_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (grdGwaCount.GetItemString(e.RowNumber, "gwa") == "04")
            {
                if (e.ColName == "count")
                {
                    e.ForeColor = Color.Red;
                }
                else if (e.ColName == "gwa_name")
                {
                    e.BackColor = Color.Pink;
                }
            }

            if (e.ColName == "color")
            {
                string rgb = grdGwaCount.GetItemString(e.RowNumber, "gwa_color");

                e.BackColor = Color.FromArgb(int.Parse(rgb.Split(',')[0]), int.Parse(rgb.Split(',')[1]), int.Parse(rgb.Split(',')[2]));
            }
        }

        private void layChekNonConfirmOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layChekNonConfirmOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layChekNonConfirmOrder.SetBindVarValue("f_ho_dong", this.cboHoDong.GetDataValue());
        }

        private void grdGwaCount_QueryEnd(object sender, QueryEndEventArgs e)
        {
            grdGwaCount.UnSelectAll();
        }

        private void btnADLWork_Click(object sender, EventArgs e)
        {
            XScreen.OpenScreen(this, "NUR8050U00", ScreenOpenStyle.PopUpFixed);
        }

    }
}