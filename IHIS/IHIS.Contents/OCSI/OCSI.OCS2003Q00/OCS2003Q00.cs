#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.OCS;
#endregion

namespace IHIS.OCSI
{
	/// <summary>
	/// OCS2003Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS2003Q00 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
		private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리
		private IHIS.OCS.InputControl mInputControl = null;   // 입력제어 그룹 라이브러리 
		#endregion

		#region [Instance Variable]		
		//Message처리
		string mbxMsg = "", mbxCap = "";		

		//등록번호
		private string mBunho = "";
		//입원Key
		private int mFkinp1001 = 0;
		//입력구분
		private string mInput_gubun = "";
		//처방일자
		private string mGijun_date = "";
		//tel처방여부
		private string mTel_yn = "%";

		private string mOrderGubun = ""; 

		//Data가 없는 경우 화면 닫을지 여부
		private bool mAuto_close = false;

	    //신규그룹번호발생여부
		private bool   mIsNewGroupSer = false;

		private IHIS.X.Magic.Menus.PopupMenu popupMenu = new IHIS.X.Magic.Menus.PopupMenu(); 

		private string qryLoadOrderDataList = "";		// 처방일자 LIST 조회			workTP = 1
		private string qryLoadOCS2003 = "";				// 처방정보 조회				workTP = 2
		private string qryLoadOCS2005 = "";				// 지시사항 조회				workTP = 3
		private string qryLoadOUT1001 = "";				// 외래처방일자 LIST 조회		workTP = 4
		private string qryLoadOCS1001 = "";				// 외래상병정보 조회			workTP = 5
		private string qryLoadOCS1003 = "";				// 외래처방정보 조회			workTP = 6
		private string qryLoadGumsaOrderDataList = "";	// 입원검사처방일자 LIST 조회	workTP = 7
		private string qryLoadGumsaOCS2003 = "";		// 입원검사처방 조회			workTP = 8
		private string qryLoadGumsaOUT1001 = "";		// 입원검사처장일자 LIST 조회	workTP = 9
		private string qryLoadGumsaOCS1003 = "";		// 외래검사처방일자 조회		workTP = 0
		#endregion

		#region Design 
		 
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XPanel xPanel3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XMstGrid grdOrdList;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
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
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
		private IHIS.Framework.XEditGridCell xEditGridCell38;
		private IHIS.Framework.XEditGridCell xEditGridCell39;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
		private IHIS.Framework.XEditGridCell xEditGridCell43;
		private IHIS.Framework.XEditGridCell xEditGridCell44;
		private IHIS.Framework.XEditGridCell xEditGridCell45;
		private IHIS.Framework.XEditGridCell xEditGridCell46;
		private IHIS.Framework.XEditGridCell xEditGridCell47;
		private IHIS.Framework.XEditGridCell xEditGridCell48;
		private IHIS.Framework.XEditGridCell xEditGridCell52;
		private IHIS.Framework.XEditGridCell xEditGridCell53;
		private IHIS.Framework.XEditGridCell xEditGridCell54;
		private IHIS.Framework.XEditGridCell xEditGridCell55;
		private IHIS.Framework.XEditGridCell xEditGridCell59;
		private IHIS.Framework.XEditGridCell xEditGridCell60;
		private IHIS.Framework.XEditGridCell xEditGridCell61;
		private IHIS.Framework.XEditGridCell xEditGridCell64;
		private IHIS.Framework.XEditGridCell xEditGridCell65;
		private IHIS.Framework.XEditGridCell xEditGridCell66;
		private IHIS.Framework.XEditGridCell xEditGridCell67;
		private IHIS.Framework.XEditGridCell xEditGridCell68;
		private IHIS.Framework.XEditGridCell xEditGridCell69;
		private IHIS.Framework.XEditGridCell xEditGridCell71;
		private IHIS.Framework.XEditGridCell xEditGridCell72;
		private IHIS.Framework.XEditGridCell xEditGridCell73;
		private IHIS.Framework.XEditGridCell xEditGridCell74;
		private IHIS.Framework.XEditGridCell xEditGridCell87;
		private IHIS.Framework.XEditGridCell xEditGridCell88;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XDatePicker dpkOrdList_date;
		private IHIS.Framework.XEditGridCell xEditGridCell94;
		private IHIS.Framework.MultiLayout dloSelectOCS2003;
		private IHIS.Framework.MultiLayout dloOrder_danui;
		private IHIS.Framework.XEditGridCell xEditGridCell95;
		private IHIS.Framework.XEditGridCell xEditGridCell97;
		private IHIS.Framework.XLabel lblSelectOrder;
		private IHIS.Framework.XEditGridCell xEditGridCell102;
		private IHIS.Framework.XButton btnProcess;
		private IHIS.Framework.XPanel pnlInput_gubun;
		private IHIS.Framework.XEditGrid grdOCS2003;
		private IHIS.Framework.XRadioButton rbt;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGrid grdOCS2005;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell49;
		private IHIS.Framework.XEditGridCell xEditGridCell50;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
		private IHIS.Framework.XEditGridCell xEditGridCell56;
		private IHIS.Framework.XEditGridCell xEditGridCell57;
		private IHIS.Framework.XEditGridCell xEditGridCell58;
		private IHIS.Framework.XEditGridCell xEditGridCell62;
		private IHIS.Framework.XEditGridCell xEditGridCell63;
		private IHIS.Framework.XEditGridCell xEditGridCell70;
		private IHIS.Framework.XEditGridCell xEditGridCell75;
		private IHIS.Framework.XEditGridCell xEditGridCell76;
		private IHIS.Framework.XEditGridCell xEditGridCell77;
		private IHIS.Framework.XEditGridCell xEditGridCell78;
		private IHIS.Framework.XLabel lblSelectDirect;
		private IHIS.Framework.MultiLayout dloSelectOCS2005;
		private IHIS.Framework.XEditGridCell xEditGridCell79;
		private IHIS.Framework.XEditGridCell xEditGridCell80;
		private IHIS.Framework.XEditGridCell xEditGridCell81;
		private IHIS.Framework.XEditGridCell xEditGridCell82;
		private IHIS.Framework.XEditGridCell xEditGridCell83;
		private IHIS.Framework.XEditGridCell xEditGridCell84;
		private IHIS.Framework.XEditGridCell xEditGridCell85;
		private IHIS.Framework.XEditGridCell xEditGridCell86;
		private System.Windows.Forms.CheckBox chkIsNewGroup;
		private IHIS.Framework.XEditGridCell xEditGridCell89;
		private System.Windows.Forms.ImageList imageListMixGroup;
		private IHIS.Framework.XEditGridCell xEditGridCell90;
		private IHIS.Framework.MultiLayout dloCheckLayout;
		private IHIS.Framework.XEditGridCell xEditGridCell91;
		private IHIS.Framework.XEditGridCell xEditGridCell92;
		private IHIS.Framework.XEditGridCell xEditGridCell93;
		private IHIS.Framework.XEditGridCell xEditGridCell96;
		private IHIS.Framework.XEditGridCell xEditGridCell98;
		private IHIS.Framework.XEditGridCell xEditGridCell99;
		private IHIS.Framework.XPanel pnlIn;
		private System.Windows.Forms.RadioButton rbtIn;
		private System.Windows.Forms.RadioButton rbtOut;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XPanel pnlOut;
		private IHIS.Framework.XEditGrid grdOCS1001;
		private IHIS.Framework.XLabel lblSelectSang;
		private IHIS.Framework.XEditGridCell xEditGridCell100;
		private IHIS.Framework.XEditGridCell xEditGridCell101;
		private IHIS.Framework.XEditGridCell xEditGridCell125;
		private IHIS.Framework.XEditGridCell xEditGridCell103;
		private IHIS.Framework.XEditGridCell xEditGridCell104;
		private IHIS.Framework.XEditGridCell xEditGridCell105;
		private IHIS.Framework.XEditGridCell xEditGridCell106;
		private IHIS.Framework.XEditGridCell xEditGridCell107;
		private IHIS.Framework.XEditGridCell xEditGridCell108;
		private IHIS.Framework.XEditGridCell xEditGridCell109;
		private IHIS.Framework.XEditGridCell xEditGridCell110;
		private IHIS.Framework.XEditGridCell xEditGridCell111;
		private IHIS.Framework.XEditGridCell xEditGridCell130;
		private IHIS.Framework.XEditGridCell xEditGridCell112;
		private IHIS.Framework.XEditGridCell xEditGridCell126;
		private IHIS.Framework.XEditGridCell xEditGridCell113;
		private IHIS.Framework.XEditGridCell xEditGridCell114;
		private IHIS.Framework.XEditGridCell xEditGridCell115;
		private IHIS.Framework.XEditGridCell xEditGridCell116;
		private IHIS.Framework.XEditGridCell xEditGridCell117;
		private IHIS.Framework.XEditGridCell xEditGridCell118;
		private IHIS.Framework.XEditGridCell xEditGridCell119;
		private IHIS.Framework.XEditGridCell xEditGridCell120;
		private IHIS.Framework.XEditGridCell xEditGridCell121;
		private IHIS.Framework.XEditGridCell xEditGridCell122;
		private IHIS.Framework.XEditGridCell xEditGridCell123;
		private IHIS.Framework.XEditGridCell xEditGridCell124;
		private IHIS.Framework.XEditGridCell xEditGridCell127;
		private IHIS.Framework.XEditGridCell xEditGridCell128;
		private IHIS.Framework.XEditGridCell xEditGridCell129;
		private IHIS.Framework.XEditGridCell xEditGridCell131;
		private IHIS.Framework.XEditGridCell xEditGridCell132;
		private IHIS.Framework.XEditGridCell xEditGridCell133;
		private IHIS.Framework.XEditGridCell xEditGridCell134;
		private IHIS.Framework.XEditGridCell xEditGridCell135;
		private IHIS.Framework.XEditGridCell xEditGridCell136;
		private IHIS.Framework.XEditGridCell xEditGridCell137;
		private IHIS.Framework.XEditGridCell xEditGridCell138;
		private IHIS.Framework.XEditGridCell xEditGridCell139;
		private IHIS.Framework.XMstGrid grdOUT1001;
		private IHIS.Framework.XEditGridCell xEditGridCell233;
		private IHIS.Framework.XEditGridCell xEditGridCell234;
		private IHIS.Framework.XEditGridCell xEditGridCell235;
		private IHIS.Framework.XEditGridCell xEditGridCell236;
		private IHIS.Framework.XEditGridCell xEditGridCell237;
		private IHIS.Framework.XEditGridCell xEditGridCell238;
		private IHIS.Framework.XEditGridCell xEditGridCell239;
		private IHIS.Framework.XEditGridCell xEditGridCell240;
		private IHIS.Framework.XEditGridCell xEditGridCell241;
		private IHIS.Framework.XEditGridCell xEditGridCell242;
		private IHIS.Framework.XEditGridCell xEditGridCell243;
		private IHIS.Framework.XEditGridCell xEditGridCell244;
		private IHIS.Framework.XEditGridCell xEditGridCell245;
		private IHIS.Framework.XLabel lblSelectOutOrder;
		private IHIS.Framework.MultiLayout dloSelectOCS1003;
		private IHIS.Framework.MultiLayout dloSelectOCS1001;
		private IHIS.Framework.XEditGridCell xEditGridCell246;
		private IHIS.Framework.XEditGridCell xEditGridCell248;
		private IHIS.Framework.XEditGrid grdOCS1003;
		private IHIS.Framework.XEditGridCell xEditGridCell140;
		private IHIS.Framework.XEditGridCell xEditGridCell141;
		private IHIS.Framework.XEditGridCell xEditGridCell142;
		private IHIS.Framework.XEditGridCell xEditGridCell143;
		private IHIS.Framework.XEditGridCell xEditGridCell144;
		private IHIS.Framework.XEditGridCell xEditGridCell145;
		private IHIS.Framework.XEditGridCell xEditGridCell146;
		private IHIS.Framework.XEditGridCell xEditGridCell147;
		private IHIS.Framework.XEditGridCell xEditGridCell148;
		private IHIS.Framework.XEditGridCell xEditGridCell149;
		private IHIS.Framework.XEditGridCell xEditGridCell150;
		private IHIS.Framework.XEditGridCell xEditGridCell151;
		private IHIS.Framework.XEditGridCell xEditGridCell152;
		private IHIS.Framework.XEditGridCell xEditGridCell153;
		private IHIS.Framework.XEditGridCell xEditGridCell154;
		private IHIS.Framework.XEditGridCell xEditGridCell155;
		private IHIS.Framework.XEditGridCell xEditGridCell156;
		private IHIS.Framework.XEditGridCell xEditGridCell157;
		private IHIS.Framework.XEditGridCell xEditGridCell158;
		private IHIS.Framework.XEditGridCell xEditGridCell159;
		private IHIS.Framework.XEditGridCell xEditGridCell160;
		private IHIS.Framework.XEditGridCell xEditGridCell161;
		private IHIS.Framework.XEditGridCell xEditGridCell162;
		private IHIS.Framework.XEditGridCell xEditGridCell163;
		private IHIS.Framework.XEditGridCell xEditGridCell164;
		private IHIS.Framework.XEditGridCell xEditGridCell165;
		private IHIS.Framework.XEditGridCell xEditGridCell166;
		private IHIS.Framework.XEditGridCell xEditGridCell167;
		private IHIS.Framework.XEditGridCell xEditGridCell168;
		private IHIS.Framework.XEditGridCell xEditGridCell169;
		private IHIS.Framework.XEditGridCell xEditGridCell170;
		private IHIS.Framework.XEditGridCell xEditGridCell171;
		private IHIS.Framework.XEditGridCell xEditGridCell172;
		private IHIS.Framework.XEditGridCell xEditGridCell173;
		private IHIS.Framework.XEditGridCell xEditGridCell174;
		private IHIS.Framework.XEditGridCell xEditGridCell175;
		private IHIS.Framework.XEditGridCell xEditGridCell176;
		private IHIS.Framework.XEditGridCell xEditGridCell177;
		private IHIS.Framework.XEditGridCell xEditGridCell178;
		private IHIS.Framework.XEditGridCell xEditGridCell179;
		private IHIS.Framework.XEditGridCell xEditGridCell180;
		private IHIS.Framework.XEditGridCell xEditGridCell181;
		private IHIS.Framework.XEditGridCell xEditGridCell182;
		private IHIS.Framework.XEditGridCell xEditGridCell183;
		private IHIS.Framework.XEditGridCell xEditGridCell184;
		private IHIS.Framework.XEditGridCell xEditGridCell185;
		private IHIS.Framework.XEditGridCell xEditGridCell186;
		private IHIS.Framework.XEditGridCell xEditGridCell187;
		private IHIS.Framework.XEditGridCell xEditGridCell188;
		private IHIS.Framework.XEditGridCell xEditGridCell189;
		private IHIS.Framework.XEditGridCell xEditGridCell190;
		private IHIS.Framework.XEditGridCell xEditGridCell191;
		private IHIS.Framework.XEditGridCell xEditGridCell192;
		private IHIS.Framework.XEditGridCell xEditGridCell193;
		private IHIS.Framework.XEditGridCell xEditGridCell194;
		private IHIS.Framework.XEditGridCell xEditGridCell195;
		private IHIS.Framework.XEditGridCell xEditGridCell196;
		private IHIS.Framework.XEditGridCell xEditGridCell197;
		private IHIS.Framework.XEditGridCell xEditGridCell198;
		private IHIS.Framework.XEditGridCell xEditGridCell199;
		private IHIS.Framework.XEditGridCell xEditGridCell200;
		private IHIS.Framework.XEditGridCell xEditGridCell201;
		private IHIS.Framework.XEditGridCell xEditGridCell202;
		private IHIS.Framework.XEditGridCell xEditGridCell203;
		private IHIS.Framework.XEditGridCell xEditGridCell204;
		private IHIS.Framework.XGridHeader xGridHeader2;
		private IHIS.Framework.XEditGridCell xEditGridCell205;
		private IHIS.Framework.XEditGridCell xEditGridCell206;
		private IHIS.Framework.XTabControl tabOrderGubun;
		private IHIS.X.Magic.Controls.TabPage tabPage1;
		private IHIS.X.Magic.Controls.TabPage tabPage2;
		private IHIS.X.Magic.Controls.TabPage tabPage3;
		private IHIS.X.Magic.Controls.TabPage tabPage4;
		private IHIS.Framework.XEditGridCell xEditGridCell207;
		private IHIS.Framework.XEditGridCell xEditGridCell208;
		private IHIS.Framework.XPanel pnlOutOrder;
		private System.Windows.Forms.Splitter sptOut;
		private IHIS.Framework.XPanel pnlOutSang;
		private IHIS.Framework.XPanel pnlJisi;
		private IHIS.Framework.XPanel pnlOrder;
		private IHIS.Framework.XEditGridCell xEditGridCell209;
		private IHIS.Framework.XEditGridCell xEditGridCell210;
		private IHIS.Framework.XEditGridCell xEditGridCell211;
		private IHIS.Framework.XEditGridCell xEditGridCell212;
		private IHIS.Framework.XEditGridCell xEditGridCell213;
		private IHIS.Framework.XEditGridCell xEditGridCell214;
		private IHIS.Framework.XEditGridCell xEditGridCell215;
		private IHIS.Framework.XEditGridCell xEditGridCell216;
		private IHIS.X.Magic.Controls.TabPage tabPage5;
		private IHIS.Framework.XEditGridCell xEditGridCell217;
		private IHIS.Framework.XEditGridCell xEditGridCell218;
		private IHIS.Framework.XEditGridCell xEditGridCell219;
		private IHIS.Framework.XEditGridCell xEditGridCell220;
		private IHIS.Framework.XEditGridCell xEditGridCell221;
		private IHIS.Framework.XEditGridCell xEditGridCell222;
		private IHIS.Framework.XEditGridCell xEditGridCell223;
		private IHIS.Framework.XEditGridCell xEditGridCell224;
		private IHIS.X.Magic.Controls.TabPage tabPage6;
		private IHIS.X.Magic.Controls.TabPage tabPage7;
		private IHIS.X.Magic.Controls.TabPage tabPage8;
		private System.Windows.Forms.ToolTip toolTip1;
		private IHIS.Framework.XEditGridCell xEditGridCell225;
		private IHIS.Framework.XEditGridCell xEditGridCell226;
		private IHIS.Framework.XEditGridCell xEditGridCell227;
		private IHIS.Framework.XEditGridCell xEditGridCell228;
		private IHIS.Framework.XEditGridCell xEditGridCell229;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
		private IHIS.Framework.XEditGridCell xEditGridCell230;
		private IHIS.Framework.XEditGridCell xEditGridCell231;
		private IHIS.Framework.XEditGridCell xEditGridCell232;
		private System.ComponentModel.IContainer components;

		#endregion 

		public OCS2003Q00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
			this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리			
			this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.ScreenID);    // OCS 항목정보 그룹 라이브러리
			this.mInputControl = new IHIS.OCS.InputControl(this.ScreenID);  // 입력제어 그룹 라이브러리 		
	
			// 쿼리 설정.
			#region qryLoadOrderDataList
			this.qryLoadOrderDataList 
				= "SELECT DISTINCT                                                                                                                                                                           "
				+ "       A.ORDER_DATE              ,                                                                                                                                                        "
				+ "       A.BUNHO                   ,                                                                                                                                                        "
				+ "       A.FKINP1001               ,                                                                                                                                                        "
				+ "       DECODE( B.USER_GUBUN, '1', C.GWA, D.GWA )                                                                                                                                          "
				+ "                                         GWA        ,                                                                                                                                     "
				+ "       FN_BAS_LOAD_GWA_NAME( DECODE( B.USER_GUBUN, '1', C.GWA, D.GWA ), A.ORDER_DATE )                                                                                                    "
				+ "                                         GWA_NAME   ,                                                                                                                                     "
				+ "       DECODE( B.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )                                                                                                                                  "
				+ "                                         DOCTOR     ,                                                                                                                                     "
				+ "       FN_BAS_LOAD_DOCTOR_NAME(DECODE( B.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR ), A.ORDER_DATE )                                                                                          "
				+ "                                         DOCTOR_NAME,                                                                                                                                     "
				+ "       :f_input_gubun                    INPUT_GUBUN,                                                                                                                                     "
				+ "       TO_DATE(:f_order_date,'YYYY/MM/DD')           GIJUN_DATE ,                                                                                                                         "
				+ "       A.BUNHO||TRIM(TO_CHAR(A.FKINP1001, '0000000000'))||TO_CHAR(A.ORDER_DATE,'YYYYMMDD')||DECODE( B.USER_GUBUN, '1', C.GWA, D.GWA )||DECODE( B.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )  "
				+ "                                         PK_ORDER   ,                                                                                                                                     "
				+ "       :f_tel_yn                         TEL_YN     ,                                                                                                                                     "
				+ "       FN_OCS_CHK_DOCTOR_TOIWON_DRG(A.BUNHO, A.FKINP1001, A.ORDER_DATE, DECODE( B.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR ))                                                                "
				+ "                                         TOIWON_DRG ,                                                                                                                                     "
				+ "       TO_CHAR(A.ORDER_DATE, 'YYYYMMDD')||DECODE( B.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )                                                                                               "
				+ "                                         CONT_KEY                                                                                                                                         "
				+ "  FROM INP1001 D,                                                                                                                                                                         "
				+ "       BAS0260 C,                                                                                                                                                                         "
				+ "       ADM3200 B,                                                                                                                                                                         "
				+ "       OCS2003 A                                                                                                                                                                          "
				+ " WHERE A.BUNHO                = :f_bunho                                                                                                                                                  "
				+ "   AND A.ORDER_DATE           < TO_DATE(:f_order_date,'YYYY/MM/DD')                                                                                                                       "
				+ "   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR                                                                                                                                            "
				+ "        ( :f_input_gubun = 'NR'           ) OR                                                                                                                                            "
				+ "        ( :f_input_gubun = 'D%'           ))                                                                                                                                              "
				+ "   AND A.IO_GUBUN             IS NULL                                                                                                                                                     "
				+ "   AND A.NALSU                >= 0                                                                                                                                                        "
				+ "   AND NVL(A.DISPLAY_YN,'Y')  = 'Y'                                                                                                                                                       "
				+ "   AND NVL(A.DC_YN,'N')       = 'N'                                                                                                                                                       "
				+ "   AND NVL(A.OCS_DATA_YN,'Y') = 'Y'                                                                                                                                                       "
				+ "   AND (( :f_order_gubun = '%'           ) OR                                                                                                                                             "
				+ "        ( :f_order_gubun = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'         ) OR                                                                                                         "
				+ "        ( :f_order_gubun = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'         ) OR                                                                                                         "
				+ "        ( :f_order_gubun = '3' AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B') ) OR                                                                                                         "
				+ "        ( :f_order_gubun = '4' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'         ) OR                                                                                                         "
				+ "        ( :f_order_gubun = '5' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'         ) OR                                                                                                         "
				+ "        ( :f_order_gubun = '6' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'H'         ) OR                                                                                                         "
				+ "        ( :f_order_gubun = '7' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'G'         ))                                                                                                           "
				+ "   AND A.FKINP1001            = ( SELECT MAX(B.PKINP1001)                                                                                                                                 "
				+ "                                    FROM INP1001 B                                                                                                                                        "
				+ "                                   WHERE B.BUNHO               = :f_bunho                                                                                                                 "
				+ "                                     AND B.PKINP1001           < :f_fkinp1001                                                                                                             "
				+ "                                     AND NVL(B.CANCEL_YN, 'N') = 'N' )                                                                                                                    "
				+ "   AND B.USER_ID              = A.INPUT_ID                                                                                                                                                "
				+ "   AND B.DEPT_CODE            = C.BUSEO_CODE                                                                                                                                              "
				+ "   AND C.BUSEO_YMD            = ( SELECT MAX(D.BUSEO_YMD)                                                                                                                                 "
				+ "                                    FROM BAS0260 D                                                                                                                                        "
				+ "                                   WHERE D.BUSEO_CODE = C.BUSEO_CODE                                                                                                                      "
				+ "                                     AND D.BUSEO_YMD  <= A.ORDER_DATE )                                                                                                                   "
				+ "   AND D.PKINP1001            = A.FKINP1001                                                                                                                                               "
				+ "UNION                                                                                                                                                                                     "
				+ "SELECT DISTINCT                                                                                                                                                                           "
				+ "       A.ORDER_DATE              ,                                                                                                                                                        "
				+ "       A.BUNHO                   ,                                                                                                                                                        "
				+ "       A.FKINP1001               ,                                                                                                                                                        "
				+ "       DECODE( B.USER_GUBUN, '1', C.GWA, D.GWA )                                                                                                                                          "
				+ "                                         GWA        ,                                                                                                                                     "
				+ "       FN_BAS_LOAD_GWA_NAME( DECODE( B.USER_GUBUN, '1', C.GWA, D.GWA ), A.ORDER_DATE )                                                                                                    "
				+ "                                         GWA_NAME   ,                                                                                                                                     "
				+ "       DECODE( B.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )                                                                                                                                  "
				+ "                                         DOCTOR     ,                                                                                                                                     "
				+ "       FN_BAS_LOAD_DOCTOR_NAME(DECODE( B.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR ), A.ORDER_DATE )                                                                                          "
				+ "                                         DOCTOR_NAME,                                                                                                                                     "
				+ "       :f_input_gubun                    INPUT_GUBUN,                                                                                                                                     "
				+ "       TO_DATE(:f_order_date,'YYYY/MM/DD')     GIJUN_DATE ,                                                                                                                               "
				+ "       A.BUNHO||TRIM(TO_CHAR(A.FKINP1001, '0000000000'))||TO_CHAR(A.ORDER_DATE,'YYYYMMDD')||DECODE( B.USER_GUBUN, '1', C.GWA, D.GWA )||DECODE( B.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )  "
				+ "                                         PK_ORDER   ,                                                                                                                                     "
				+ "       :f_tel_yn                         TEL_YN     ,                                                                                                                                     "
				+ "       FN_OCS_CHK_DOCTOR_TOIWON_DRG(A.BUNHO, A.FKINP1001, A.ORDER_DATE, DECODE( B.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR ))                                                                "
				+ "                                         TOIWON_DRG ,                                                                                                                                     "
				+ "       TO_CHAR(A.ORDER_DATE, 'YYYYMMDD')||DECODE( B.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )                                                                                               "
				+ "                                         CONT_KEY                                                                                                                                         "
				+ "  FROM INP1001 D,                                                                                                                                                                         "
				+ "       BAS0260 C,                                                                                                                                                                         "
				+ "       ADM3200 B,                                                                                                                                                                         "
				+ "       OCS2003 A                                                                                                                                                                          "
				+ " WHERE A.BUNHO                = :f_bunho                                                                                                                                                  "
				+ "   AND A.FKINP1001            = :f_fkinp1001                                                                                                                                              "
				+ "   AND A.ORDER_DATE           < TO_DATE(:f_order_date,'YYYY/MM/DD')                                                                                                                       "
				+ "   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR                                                                                                                                            "
				+ "        ( :f_input_gubun = 'NR'           ) OR                                                                                                                                            "
				+ "        ( :f_input_gubun = 'D%'           ))                                                                                                                                              "
				+ "   AND A.IO_GUBUN             IS NULL                                                                                                                                                     "
				+ "   AND A.NALSU                >= 0                                                                                                                                                        "
				+ "   AND NVL(A.DISPLAY_YN,'Y')  = 'Y'                                                                                                                                                       "
				+ "   AND NVL(A.DC_YN,'N')       = 'N'                                                                                                                                                       "
				+ "   AND NVL(A.OCS_DATA_YN,'Y') = 'Y'                                                                                                                                                       "
				+ "   AND (( :f_order_gubun = '%'           ) OR                                                                                                                                             "
				+ "        ( :f_order_gubun = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'         ) OR                                                                                                         "
				+ "        ( :f_order_gubun = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'         ) OR                                                                                                         "
				+ "        ( :f_order_gubun = '3' AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B') ) OR                                                                                                         "
				+ "        ( :f_order_gubun = '4' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'         ) OR                                                                                                         "
				+ "        ( :f_order_gubun = '5' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'         ) OR                                                                                                         "
				+ "        ( :f_order_gubun = '6' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'H'         ) OR                                                                                                         "
				+ "        ( :f_order_gubun = '7' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'G'         ))                                                                                                           "
				+ "   AND B.USER_ID              = A.INPUT_ID                                                                                                                                                "
				+ "   AND B.DEPT_CODE            = C.BUSEO_CODE                                                                                                                                              "
				+ "   AND C.BUSEO_YMD            = ( SELECT MAX(D.BUSEO_YMD)                                                                                                                                 "
				+ "                                    FROM BAS0260 D                                                                                                                                        "
				+ "                                   WHERE D.BUSEO_CODE = C.BUSEO_CODE                                                                                                                      "
				+ "                                     AND D.BUSEO_YMD  <= A.ORDER_DATE )                                                                                                                   "
				+ "   AND D.PKINP1001            = A.FKINP1001                                                                                                                                               "
				+ " ORDER BY 13 DESC                                                                                                                                                                         ";
			#endregion 

			#region qryLoadOCS2003

			this.qryLoadOCS2003 
				= "SELECT A.BUNHO||TRIM(TO_CHAR(A.FKINP1001, '0000000000'))||TO_CHAR(A.ORDER_DATE,'YYYYMMDD')||DECODE( G.USER_GUBUN, '1', H.GWA, I.GWA )||DECODE( G.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )                                                                       "
				+ "                                                                  PK_ORDER                ,                                                                                                                                                                    "
				+ "       ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'                                                                                                                                                                                                           "
				+ "              THEN A.BUNHO||TRIM(TO_CHAR(A.FKINP1001, '0000000000'))||TO_CHAR(A.ORDER_DATE,'YYYYMMDD')||DECODE( G.USER_GUBUN, '1', H.GWA, I.GWA )||DECODE( G.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )                                                           "
				+ "              ELSE ' ' END )                                      PK_ORDER_1              ,                                                                                                                                                                    "
				+ "       ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'                                                                                                                                                                                                           "
				+ "              THEN A.BUNHO||TRIM(TO_CHAR(A.FKINP1001, '0000000000'))||TO_CHAR(A.ORDER_DATE,'YYYYMMDD')||DECODE( G.USER_GUBUN, '1', H.GWA, I.GWA )||DECODE( G.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )                                                           "
				+ "              ELSE ' ' END )                                      PK_ORDER_2              ,                                                                                                                                                                    "
				+ "       ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B')                                                                                                                                                                                                   "
				+ "              THEN A.BUNHO||TRIM(TO_CHAR(A.FKINP1001, '0000000000'))||TO_CHAR(A.ORDER_DATE,'YYYYMMDD')||DECODE( G.USER_GUBUN, '1', H.GWA, I.GWA )||DECODE( G.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )                                                           "
				+ "              ELSE ' ' END )                                      PK_ORDER_3              ,                                                                                                                                                                    "
				+ "       ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'                                                                                                                                                                                                           "
				+ "              THEN A.BUNHO||TRIM(TO_CHAR(A.FKINP1001, '0000000000'))||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))),'YYYYMMDD')||DECODE( G.USER_GUBUN, '1', H.GWA, I.GWA )||DECODE( G.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )  "
				+ "              ELSE ' ' END )                                      PK_ORDER_4              ,                                                                                                                                                                    "
				+ "       ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'                                                                                                                                                                                                           "
				+ "              THEN A.BUNHO||TRIM(TO_CHAR(A.FKINP1001, '0000000000'))||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))),'YYYYMMDD')||DECODE( G.USER_GUBUN, '1', H.GWA, I.GWA )||DECODE( G.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )  "
				+ "              ELSE ' ' END )                                      PK_ORDER_5              ,                                                                                                                                                                    "
				+ "       ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) = 'H'                                                                                                                                                                                                           "
				+ "              THEN A.BUNHO||TRIM(TO_CHAR(A.FKINP1001, '0000000000'))||TO_CHAR(A.ORDER_DATE,'YYYYMMDD')||DECODE( G.USER_GUBUN, '1', H.GWA, I.GWA )||DECODE( G.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )                                                           "
				+ "              ELSE ' ' END )                                      PK_ORDER_6              ,                                                                                                                                                                    "
				+ "       ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) = 'G'                                                                                                                                                                                                           "
				+ "              THEN A.BUNHO||TRIM(TO_CHAR(A.FKINP1001, '0000000000'))||TO_CHAR(A.ORDER_DATE,'YYYYMMDD')||DECODE( G.USER_GUBUN, '1', H.GWA, I.GWA )||DECODE( G.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )                                                           "
				+ "              ELSE ' ' END )                                      PK_ORDER_7              ,                                                                                                                                                                    "
				+ "       A.PKOCS2003                                                PKOCS2003               ,                                                                                                                                                                    "
				+ "       A.BUNHO                                                    BUNHO                   ,                                                                                                                                                                    "
				+ "       A.FKINP1001                                                FKINP1001               ,                                                                                                                                                                    "
				+ "       A.INPUT_GUBUN                                              INPUT_GUBUN             ,                                                                                                                                                                    "
				+ "       A.SEQ                                                      SEQ                     ,                                                                                                                                                                    "
				+ "       A.ORDER_DATE                                               ORDER_DATE              ,                                                                                                                                                                    "
				+ "       A.GROUP_SER                                                GROUP_SER               ,                                                                                                                                                                    "
				+ "       NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,                                                                                                                                                                    "
				+ "       A.HANGMOG_CODE                                             HANGMOG_CODE            ,                                                                                                                                                                    "
				+ "       B.HANGMOG_NAME                                             HANGMOG_NAME            ,                                                                                                                                                                    "
				+ "       A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,                                                                                                                                                                    "
				+ "       E.SPECIMEN_NAME                                            SPECIMEN_NAME           ,                                                                                                                                                                    "
				+ "       A.SURYANG                                                  SURYANG                 ,                                                                                                                                                                    "
				+ "       A.ORD_DANUI                                                ORD_DANUI               ,                                                                                                                                                                    "
				+ "       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,                                                                                                                                                                    "
				+ "       A.DV_TIME                                                  DV_TIME                 ,                                                                                                                                                                    "
				+ "       A.DV                                                       DV                      ,                                                                                                                                                                    "
				+ "       A.NALSU                                                    NALSU                   ,                                                                                                                                                                    "
				+ "       A.JUSA                                                     JUSA                    ,                                                                                                                                                                    "
				+ "       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,                                                                                                                                                                    "
				+ "       A.BOGYONG_CODE                                             BOGYONG_CODE            ,                                                                                                                                                                    "
				+ "       FN_OCS_LOAD_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE)                                                                                                                                                                                             "
				+ "                                                                  BOGYONG_NAME            ,                                                                                                                                                                    "
				+ "       A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,                                                                                                                                                                    "
				+ "       A.WONNAE_SAYU_CODE                                         WONNAE_SAYU_CODE        ,                                                                                                                                                                    "
				+ "       A.EMERGENCY                                                EMERGENCY               ,                                                                                                                                                                    "
				+ "       A.PAY                                                      PAY                     ,                                                                                                                                                                    "
				+ "       A.FLUID_YN                                                 FLUID_YN                ,                                                                                                                                                                    "
				+ "       A.TPN_YN                                                   TPN_YN                  ,                                                                                                                                                                    "
				+ "       A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,                                                                                                                                                                    "
				+ "       A.MUHYO                                                    MUHYO                   ,                                                                                                                                                                    "
				+ "       A.PORTABLE_YN                                              PORTABLE_YN             ,                                                                                                                                                                    "
				+ "       A.SYMYA                                                    SYMYA                   ,                                                                                                                                                                    "
				+ "       '0'                                                        OCS_FLAG                ,                                                                                                                                                                    "
				+ "       A.ORDER_GUBUN                                              ORDER_GUBUN             ,                                                                                                                                                                    "
				+ "       A.JAERYO_JUNDAL_YN                                         JAERYO_JUNDAL_YN        ,                                                                                                                                                                    "
				+ "       A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,                                                                                                                                                                    "
				+ "       A.JUNDAL_PART                                              JUNDAL_PART             ,                                                                                                                                                                    "
				+ "       A.MOVE_PART                                                MOVE_PART               ,                                                                                                                                                                    "
				+ "       A.SUB_SUSUL                                                SUB_SUSUL               ,                                                                                                                                                                    "
				+ "       A.AMT                                                      AMT                     ,                                                                                                                                                                    "
				+ "       A.NALSU_SAYU_CODE                                          NALSU_SAYU_CODE         ,                                                                                                                                                                    "
				+ "       A.PHYSICAL_CODE                                            PHYSICAL_CODE           ,                                                                                                                                                                    "
				+ "       A.DV_1                                                     DV_1                    ,                                                                                                                                                                    "
				+ "       A.DV_2                                                     DV_2                    ,                                                                                                                                                                    "
				+ "       A.DV_3                                                     DV_3                    ,                                                                                                                                                                    "
				+ "       A.DV_4                                                     DV_4                    ,                                                                                                                                                                    "
				+ "       A.HOPE_DATE                                                HOPE_DATE               ,                                                                                                                                                                    "
				+ "       A.ORDER_REMARK                                             ORDER_REMARK            ,                                                                                                                                                                    "
				+ "       A.NURSE_REMARK                                             NURSE_REMAR             ,                                                                                                                                                                    "
				+ "       A.MIX_GROUP                                                MIX_GROUP               ,                                                                                                                                                                    "
				+ "       NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,                                                                                                                                                                    "
				+ "       B.SLIP_CODE                                                SLIP_CODE               ,                                                                                                                                                                    "
				+ "       B.GROUP_YN                                                 GROUP_YN                ,                                                                                                                                                                    "
				+ "       B.SG_CODE                                                  SG_CODE                 ,                                                                                                                                                                    "
				+ "       B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,                                                                                                                                                                    "
				+ "       B.INPUT_CONTROL                                            INPUT_CONTROL           ,                                                                                                                                                                    "
				+ "       ( CASE WHEN FN_OCS_BULYONG_CHECK(A.HANGMOG_CODE, :f_gijun_date)  <> 'Y'                                                                                                                                                                                 "
				+ "              THEN 'N'                                                                                                                                                                                                                                         "
				+ "              WHEN FN_OCS_BULYONG_CHECK(A.HANGMOG_CODE, :f_gijun_date)  = 'Y'                                                                                                                                                                                  "
				+ "               AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', A.HANGMOG_CODE, A.BUNHO, :f_gijun_date) <> A.HANGMOG_CODE                                                                                                                                             "
				+ "              THEN 'Z'                                                                                                                                                                                                                                         "
				+ "              ELSE 'Y' END )                                      BULYONG_CHECK           ,                                                                                                                                                                    "
				+ "       NVL(D.CODE_NAME, 'Etc')                                    INPUT_GUBUN_NAME        ,                                                                                                                                                                    "
				+ "       DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,                                                                                                                                                                    "
				+ "       B.ORD_DANUI                                                ORD_DANUI_BAS           ,                                                                                                                                                                    "
				+ "       F.BUN_CODE                                                 BUN_CODE                ,                                                                                                                                                                    "
				+ "       F.SG_GESAN                                                 SG_GESAN                ,                                                                                                                                                                    "
				+ "       ( CASE WHEN NVL(G.USER_GUBUN, '3') = '1'                                                                                                                                                                                                                "
				+ "               AND NVL(G.DEPT_CODE , 'X') <> TRIM(:t_user_buseo_code)   THEN 'Y'                                                                                                                                                                               "
				+ "              ELSE 'N' END )                                      OTHER_GWA               ,                                                                                                                                                                    "
				+ "       TRIM(TO_CHAR(A.FKINP1001))||TO_CHAR(A.ORDER_DATE,'YYYYMMDD')||A.INPUT_GUBUN                                                                                                                                                                             "
				+ "                                                                  DATA_CONTROL            ,                                                                                                                                                                    "
				+ "       LTRIM(TO_CHAR(NVL(D.SORT_KEY, 99), '00'))||LTRIM(TO_CHAR(NVL(C.SORT_KEY, 99), '00'))||LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||LTRIM(TO_CHAR(A.SEQ, '0000'))                                                                         "
				+ "                                                                  CONT_KEY                                                                                                                                                                                     "
				+ "  FROM INP1001 I,                                                                                                                                                                                                                                              "
				+ "       BAS0260 H,                                                                                                                                                                                                                                              "
				+ "       ADM3200 G,                                                                                                                                                                                                                                              "
				+ "       BAS0310 F,                                                                                                                                                                                                                                              "
				+ "       OCS0116 E,                                                                                                                                                                                                                                              "
				+ "       OCS0132 D,                                                                                                                                                                                                                                              "
				+ "       OCS0132 C,                                                                                                                                                                                                                                              "
				+ "       OCS0103 B,                                                                                                                                                                                                                                              "
				+ "       OCS2003 A                                                                                                                                                                                                                                               "
				+ " WHERE A.BUNHO                = :f_bunho                                                                                                                                                                                                                       "
				+ "   AND A.FKINP1001            = :f_fkinp1001                                                                                                                                                                                                                   "
				+ "   AND A.ORDER_DATE           = TO_DATE(:f_order_date,'YYYY/MM/DD')                                                                                                                                                                                            "
				+ "   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR                                                                                                                                                                                                                 "
				+ "        ( :f_input_gubun = 'NR'           ) OR                                                                                                                                                                                                                 "
				+ "        ( :f_input_gubun = 'D%'           ))                                                                                                                                                                                                                   "
				+ "   AND A.IO_GUBUN             IS NULL                                                                                                                                                                                                                          "
				+ "   AND A.NALSU                >= 0                                                                                                                                                                                                                             "
				+ "   AND NVL(A.DISPLAY_YN,'Y')  = 'Y'                                                                                                                                                                                                                            "
				+ "   AND NVL(A.DC_YN,'N')       = 'N'                                                                                                                                                                                                                            "
				+ "   AND NVL(A.OCS_DATA_YN,'N') = 'Y'                                                                                                                                                                                                                            "
				+ "   AND NVL(A.TEL_YN     ,'N') LIKE :f_tel_yn                                                                                                                                                                                                                   "
				+ "   AND (( :f_order_gubun = '%'           ) OR                                                                                                                                                                                                                  "
				+ "        ( :f_order_gubun = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'         ) OR                                                                                                                                                                              "
				+ "        ( :f_order_gubun = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'         ) OR                                                                                                                                                                              "
				+ "        ( :f_order_gubun = '3' AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B') ) OR                                                                                                                                                                              "
				+ "        ( :f_order_gubun = '4' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'         ) OR                                                                                                                                                                              "
				+ "        ( :f_order_gubun = '5' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'         ) OR                                                                                                                                                                              "
				+ "        ( :f_order_gubun = '6' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'H'         ) OR                                                                                                                                                                              "
				+ "        ( :f_order_gubun = '7' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'G'         ))                                                                                                                                                                                "
				+ "   AND B.HANGMOG_CODE         = A.HANGMOG_CODE                                                                                                                                                                                                                 "
				+ "   AND C.CODE     (+)         = A.ORDER_GUBUN                                                                                                                                                                                                                  "
				+ "   AND C.CODE_TYPE(+)         = 'ORDER_GUBUN'                                                                                                                                                                                                                  "
				+ "   AND D.CODE     (+)         = A.INPUT_GUBUN                                                                                                                                                                                                                  "
				+ "   AND D.CODE_TYPE(+)         = 'INPUT_GUBUN'                                                                                                                                                                                                                  "
				+ "   AND E.SPECIMEN_CODE(+)     = A.SPECIMEN_CODE                                                                                                                                                                                                                "
				+ "   AND F.SG_CODE  (+)         = B.SG_CODE                                                                                                                                                                                                                      "
				+ "   AND G.USER_ID              = A.INPUT_ID                                                                                                                                                                                                                     "
				+ "   AND H.BUSEO_CODE           = G.DEPT_CODE                                                                                                                                                                                                                    "
				+ "   AND H.BUSEO_YMD            = ( SELECT MAX(J.BUSEO_YMD)                                                                                                                                                                                                      "
				+ "                                    FROM BAS0260 J                                                                                                                                                                                                             "
				+ "                                   WHERE J.BUSEO_CODE = H.BUSEO_CODE                                                                                                                                                                                           "
				+ "                                     AND J.BUSEO_YMD <= A.ORDER_DATE )                                                                                                                                                                                         "
				+ "   AND I.PKINP1001            = A.FKINP1001                                                                                                                                                                                                                    "
				+ "   AND DECODE( G.USER_GUBUN, '1', H.GWA     , I.GWA    ) = :f_gwa                                                                                                                                                                                              "
				+ "   AND DECODE( G.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR ) = :f_doctor                                                                                                                                                                                           "
				+ "   AND NOT EXISTS ( SELECT 'X'                                                                                                                                                                                                                                 "
				+ "                      FROM OCS6013 K,                                                                                                                                                                                                                          "
				+ "                           OCS6017 L                                                                                                                                                                                                                           "
				+ "                     WHERE K.FKOCS2003              = A.PKOCS2003                                                                                                                                                                                              "
				+ "                       AND L.PKOCS6017              = K.FKOCS6017                                                                                                                                                                                              "
				+ "                       AND NVL(L.ORDER_END_YN, 'N') = 'Y'                                                                                                                                                                                                      "
				+ "                       AND L.ORDER_END_DATE         < A.ORDER_DATE )                                                                                                                                                                                           "
				+ " ORDER BY NVL(D.SORT_KEY, 99), NVL(C.SORT_KEY, 99), A.GROUP_SER, NVL(A.MIX_GROUP, ' '), A.SEQ                                                                                                                                                                  ";

			#endregion 

			#region qryLoadOCS2005
			this.qryLoadOCS2005 
				= "SELECT A.BUNHO||A.FKINP1001||TO_CHAR(A.ORDER_DATE,'YYYYMMDD') PK_ORDER, "
+ "       A.BUNHO       ,                                                  "
+ "       A.FKINP1001   ,                                                  "
+ "       A.ORDER_DATE  ,                                                  "
+ "       A.INPUT_GUBUN ,                                                  "
+ "       A.PK_SEQ      ,                                                  "
+ "       A.DIRECT_GUBUN,                                                  "
+ "       B.NUR_GR_NAME ,                                                  "
+ "       A.DIRECT_CODE ,                                                  "
+ "       C.NUR_MD_NAME ,                                                  "
+ "       A.DIRECT_CONT1,                                                  "
+ "       A.DIRECT_CONT2,                                                  "
+ "       A.CNT_PERHOUR ,                                                  "
+ "       A.CNT_PERDAY  ,                                                  "
+ "       A.ACT_DAY     ,                                                  "
+ "       A.FRENCH      ,                                                  "
+ "       A.ACT_DQ1     ,                                                  "
+ "       A.ACT_DQ2     ,                                                  "
+ "       A.ACT_DQ3     ,                                                  "
+ "       A.ACT_DQ4     ,                                                  "
+ "       A.ACT_TIME    ,                                                  "
+ "       A.DIRECT_TEXT ,                                                  "
+ "       NVL(D.CODE_NAME, 'Etc')                        INPUT_GUBUN_NAME,  "      
+ "       A.INPUT_GUBUN||LTRIM(TO_CHAR(A.PK_SEQ, '000')) CONT_KEY          "
+ "  FROM OCS2005 A,                                                       "
+ "       NUR0110 B,                                                       "
+ "       NUR0111 C,                                                       "
+ "       OCS0132 D                                                        "
+ " WHERE A.BUNHO                = :f_bunho                                "
+ "   AND A.FKINP1001            = :f_fkinp1001                            "
+ "   AND A.ORDER_DATE           = TO_DATE(:f_order_date,'YYYY/MM/DD')        "
+ "   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR                          "
+ "        ( :f_input_gubun = 'D%'           ))                            "
+ "   AND B.NUR_GR_CODE          = A.DIRECT_GUBUN                          "
+ "   AND C.NUR_GR_CODE          = A.DIRECT_GUBUN                          "
+ "   AND C.NUR_MD_CODE          = A.DIRECT_CODE                           "
+ "   AND D.CODE     (+)         = A.INPUT_GUBUN                           "
+ "   AND D.CODE_TYPE(+)         = 'INPUT_GUBUN'                           "
+ " ORDER BY A.INPUT_GUBUN, A.PK_SEQ                                       ";
			#endregion 

			#region qryLoadOUT1001
			this.qryLoadOUT1001 
				= "SELECT A.NAEWON_DATE                     NAEWON_DATE,                                                              "
				+ "       A.GWA                             GWA,                                                                      "
				+ "       FN_BAS_LOAD_GWA_NAME( A.GWA, A.NAEWON_DATE)                                                                 "
				+ "                                         GWA_NAME,                                                                 "
				+ "       FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE)                                                            "
				+ "                                         DOCTOR_NAME,                                                              "
				+ "       0                                 NALSU,                                                                    "
				+ "       A.BUNHO                           BUNHO,                                                                    "
				+ "       A.DOCTOR                          DOCTOR,                                                                   "
				+ "       FN_BAS_LOAD_GUBUN_NAME(A.GUBUN, A.NAEWON_DATE)                                                              "
				+ "                                         GUBUN_NAME ,                                                              "
				+ "       FN_BAS_LOAD_CODE_NAME ('CHOJAE', A.CHOJAE)                                                                  "
				+ "                                         CHOJAE_NAME,                                                              "
				+ "       A.NAEWON_TYPE                     NAEWON_TYPE,                                                              "
				+ "       A.JUBSU_NO                        JUBSU_NO   ,                                                              "
				+ "       A.BUNHO||TO_CHAR(A.NAEWON_DATE,'YYYYMMDD')||A.GWA||A.DOCTOR||A.NAEWON_TYPE||LTRIM(TO_CHAR(A.JUBSU_NO))      "
				+ "                                         PK_ORDER,                                                                 "
				+ "       TRIM(RPAD(:f_input_gubun,10))     INPUT_GUBUN,                                                              "
				+ "       :f_tel_yn                         TEL_YN                                                                    "
				+ "  FROM OUT1001 A                                                                                                   "
				+ " WHERE A.BUNHO        = :f_bunho                                                                                   "
				+ "   AND A.NAEWON_DATE  < TO_DATE(:f_order_date,'YYYY/MM/DD')                                        "
				+ "   AND EXISTS( SELECT 'X'                                                                                          "
				+ "                 FROM OCS1003 B                                                                                    "
				+ "                WHERE B.BUNHO        = A.BUNHO                                                                     "
				+ "                  AND B.NAEWON_DATE  = A.NAEWON_DATE                                                               "
				+ "                  AND B.GWA          = A.GWA                                                                       "
				+ "                  AND B.DOCTOR       = A.DOCTOR                                                                    "
				+ "                  AND B.NAEWON_TYPE  = A.NAEWON_TYPE                                                               "
				+ "                  AND B.JUBSU_NO     = A.JUBSU_NO                                                                  "
				+ "                  AND (( B.INPUT_GUBUN  = :f_input_gubun ) OR                                                      "
				+ "                       ( :f_input_gubun = 'NR'           ) OR                                                      "
				+ "                       ( :f_input_gubun = 'D%'           ))                                                        "
				+ "                  AND NVL(B.TEL_YN, 'N') LIKE :f_tel_yn                                                            "
				+ "                  AND (( :f_order_gubun = '%'           ) OR                                                       "
				+ "                       ( :f_order_gubun = '1' AND SUBSTR(B.ORDER_GUBUN, 2, 1) = 'C'         ) OR                   "
				+ "                       ( :f_order_gubun = '2' AND SUBSTR(B.ORDER_GUBUN, 2, 1) = 'D'         ) OR                   "
				+ "                       ( :f_order_gubun = '3' AND SUBSTR(B.ORDER_GUBUN, 2, 1) IN ('A', 'B') ) OR                   "
				+ "                       ( :f_order_gubun = '4' AND SUBSTR(B.ORDER_GUBUN, 2, 1) = 'F'         ) OR                   "
				+ "                       ( :f_order_gubun = '5' AND SUBSTR(B.ORDER_GUBUN, 2, 1) = 'E'         ) OR                   "
				+ "                       ( :f_order_gubun = '6' AND SUBSTR(B.ORDER_GUBUN, 2, 1) = 'H'         ) OR                   "
				+ "                       ( :f_order_gubun = '7' AND SUBSTR(B.ORDER_GUBUN, 2, 1) = 'G'         ))                     "
				+ "                  AND ROWNUM = 1                                                                                   "
				+ "               UNION ALL                                                                                           "
				+ "               SELECT 'X'                                                                                          "
				+ "                 FROM OCS1001 C                                                                                    "
				+ "                WHERE :f_order_gubun = '%'                                                                         "
				+ "                  AND C.BUNHO        = A.BUNHO                                                                     "
				+ "                  AND C.NAEWON_DATE  = A.NAEWON_DATE                                                               "
				+ "                  AND C.GWA          = A.GWA                                                                       "
				+ "                  AND C.DOCTOR       = A.DOCTOR                                                                    "
				+ "                  AND C.NAEWON_TYPE  = A.NAEWON_TYPE                                                               "
				+ "                  AND C.JUBSU_NO     = A.JUBSU_NO                                                                  "
				+ "                  AND ROWNUM = 1 )                                                                                 "
				+ "UNION                                                                                                              "
				+ "SELECT B.JINRYO_PRE_DATE                 NAEWON_DATE,                                                              "
				+ "       B.GWA                             GWA,                                                                      "
				+ "       FN_BAS_LOAD_GWA_NAME( B.GWA, B.JINRYO_PRE_DATE)                                                             "
				+ "                                         GWA_NAME,                                                                 "
				+ "       FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR, B.JINRYO_PRE_DATE)                                                        "
				+ "                                         DOCTOR_NAME,                                                              "
				+ "       0                                 NALSU,                                                                    "
				+ "       B.BUNHO                           BUNHO,                                                                    "
				+ "       B.DOCTOR                          DOCTOR,                                                                   "
				+ "       FN_BAS_LOAD_GUBUN_NAME(B.GUBUN, B.JINRYO_PRE_DATE)                                                          "
				+ "                                         GUBUN_NAME ,                                                              "
				+ "       FN_BAS_LOAD_CODE_NAME ('CHOJAE', B.CHOJAE)                                                                  "
				+ "                                         CHOJAE_NAME,                                                              "
				+ "       B.NAEWON_TYPE                     NAEWON_TYPE,                                                              "
				+ "       1                                 JUBSU_NO,                                                                 "
				+ "       B.BUNHO||TO_CHAR(B.JINRYO_PRE_DATE,'YYYYMMDD')||B.GWA||B.DOCTOR||B.NAEWON_TYPE||LTRIM(TO_CHAR(B.JUBSU_NO))  "
				+ "                                         PK_ORDER,                                                                 "
				+ "       TRIM(RPAD(:f_input_gubun,10))     INPUT_GUBUN,                                                              "
				+ "       :f_tel_yn                         TEL_YN                                                                    "
				+ "  FROM RES1001 B                                                                                                   "
				+ " WHERE B.BUNHO           = :f_bunho                                                                                "
				+ "   AND B.JINRYO_PRE_DATE < TO_DATE(:f_order_date,'YYYY/MM/DD')                                         "
				+ "   AND EXISTS ( SELECT 'X'                                                                                         "
				+ "                  FROM OCS1003 Z                                                                                   "
				+ "                 WHERE Z.BUNHO        = B.BUNHO                                                                    "
				+ "                   AND Z.NAEWON_DATE  = B.JINRYO_PRE_DATE                                                          "
				+ "                   AND Z.GWA          = B.GWA                                                                      "
				+ "                   AND Z.DOCTOR       = B.DOCTOR                                                                   "
				+ "                   AND Z.NAEWON_TYPE  = B.NAEWON_TYPE                                                              "
				+ "                   AND (( Z.INPUT_GUBUN  = :f_input_gubun ) OR                                                     "
				+ "                        ( :f_input_gubun = 'NR'           ) OR                                                     "
				+ "                        ( :f_input_gubun = 'D%'           ))                                                       "
				+ "                   AND NVL(Z.TEL_YN, 'N') LIKE :f_tel_yn                                                           "
				+ "                   AND (( :f_order_gubun = '%'           ) OR                                                      "
				+ "                        ( :f_order_gubun = '1' AND SUBSTR(Z.ORDER_GUBUN, 2, 1) = 'C'         ) OR                  "
				+ "                        ( :f_order_gubun = '2' AND SUBSTR(Z.ORDER_GUBUN, 2, 1) = 'D'         ) OR                  "
				+ "                        ( :f_order_gubun = '3' AND SUBSTR(Z.ORDER_GUBUN, 2, 1) IN ('A', 'B') ) OR                  "
				+ "                        ( :f_order_gubun = '4' AND SUBSTR(Z.ORDER_GUBUN, 2, 1) = 'F'         ) OR                  "
				+ "                        ( :f_order_gubun = '5' AND SUBSTR(Z.ORDER_GUBUN, 2, 1) = 'E'         ) OR                  "
				+ "                        ( :f_order_gubun = '6' AND SUBSTR(Z.ORDER_GUBUN, 2, 1) = 'H'         ) OR                  "
				+ "                        ( :f_order_gubun = '7' AND SUBSTR(Z.ORDER_GUBUN, 2, 1) = 'G'         ))                    "
				+ "                   AND ROWNUM = 1)                                                                                 "
				+ "  ORDER BY 12 DESC                                                                                                 ";
			#endregion 

			#region  qryLoadOCS1001
			this.qryLoadOCS1001
				= "SELECT A.JU_SANG_YN        ,                                                                                  "
				+ "       A.SANG_CODE         ,                                                                                  "
				+ "       A.SER               ,                                                                                  "
				+ "       A.PRE_MODIFIER_NAME||A.SANG_NAME||A.POST_MODIFIER_NAME                                                 "
				+ "                                                DIS_SANG_NAME,                                                "
				+ "       A.SANG_START_DATE   ,                                                                                  "
				+ "       A.SANG_END_DATE     ,                                                                                  "
				+ "       A.SANG_END_SAYU     ,                                                                                  "
				+ "       A.BUNHO             ,                                                                                  "
				+ "       A.NAEWON_DATE       ,                                                                                  "
				+ "       A.GWA               ,                                                                                  "
				+ "       A.DOCTOR            ,                                                                                  "
				+ "       A.NAEWON_TYPE       ,                                                                                  "
				+ "       A.JUBSU_NO          ,                                                                                  "
				+ "       A.BUNHO||TO_CHAR(A.NAEWON_DATE,'YYYYMMDD')||A.GWA||A.DOCTOR||A.NAEWON_TYPE||LTRIM(TO_CHAR(A.JUBSU_NO)) "
				+ "                                                                    PK_ORDER,                                 "
				+ "       A.SANG_NAME         ,                                                                                  "
				+ "       A.PRE_MODIFIER1     ,                                                                                  "
				+ "       A.PRE_MODIFIER2     ,                                                                                  "
				+ "       A.PRE_MODIFIER3     ,                                                                                  "
				+ "       A.PRE_MODIFIER4     ,                                                                                  "
				+ "       A.PRE_MODIFIER5     ,                                                                                  "
				+ "       A.PRE_MODIFIER6     ,                                                                                  "
				+ "       A.PRE_MODIFIER7     ,                                                                                  "
				+ "       A.PRE_MODIFIER8     ,                                                                                  "
				+ "       A.PRE_MODIFIER9     ,                                                                                  "
				+ "       A.PRE_MODIFIER10    ,                                                                                  "
				+ "       A.PRE_MODIFIER_NAME ,                                                                                  "
				+ "       A.POST_MODIFIER1    ,                                                                                  "
				+ "       A.POST_MODIFIER2    ,                                                                                  "
				+ "       A.POST_MODIFIER3    ,                                                                                  "
				+ "       A.POST_MODIFIER4    ,                                                                                  "
				+ "       A.POST_MODIFIER5    ,                                                                                  "
				+ "       A.POST_MODIFIER6    ,                                                                                  "
				+ "       A.POST_MODIFIER7    ,                                                                                  "
				+ "       A.POST_MODIFIER8    ,                                                                                  "
				+ "       A.POST_MODIFIER9    ,                                                                                  "
				+ "       A.POST_MODIFIER10   ,                                                                                  "
				+ "       A.POST_MODIFIER_NAME,                                                                                  "
				+ "       DECODE(A.SANG_END_DATE, NULL, 'N', 'Y')               END_YN  ,                                        "
				+ "       TO_CHAR(A.SANG_START_DATE,'YYYYMMDD')||TO_CHAR(A.SER) CONT_KEY                                         "
				+ "  FROM OCS1001 A                                                                                              "
				+ " WHERE A.BUNHO       = :f_bunho                                                                               "
				+ "   AND A.NAEWON_DATE = TO_DATE(:f_naewon_date,'YYYY/MM/DD')                                                                         "
				+ "   AND A.GWA         = :f_gwa                                                                                 "
				+ "   AND A.DOCTOR      = :f_doctor                                                                              "
				+ "   AND A.NAEWON_TYPE = :f_naewon_type                                                                         "
				+ "   AND A.JUBSU_NO    = :f_jubsu_no                                                                            "
				+ " ORDER BY 39                                                                                                  ";
			#endregion 

			#region qryLoadOCS1003
			this.qryLoadOCS1003
				= "SELECT A.BUNHO||TO_CHAR(A.NAEWON_DATE,'YYYYMMDD')||A.GWA||A.DOCTOR||A.NAEWON_TYPE||LTRIM(TO_CHAR(A.JUBSU_NO))                                  "
				+ "                                                                   PK_ORDER                ,                                                   "
				+ "        ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'                                                                                          "
				+ "               THEN A.BUNHO||TO_CHAR(A.NAEWON_DATE,'YYYYMMDD')||A.GWA||A.DOCTOR||A.NAEWON_TYPE||LTRIM(TO_CHAR(A.JUBSU_NO))                     "
				+ "               ELSE ' ' END )                                      PK_ORDER_1              ,                                                   "
				+ "        ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'                                                                                          "
				+ "               THEN A.BUNHO||TO_CHAR(A.NAEWON_DATE,'YYYYMMDD')||A.GWA||A.DOCTOR||A.NAEWON_TYPE||LTRIM(TO_CHAR(A.JUBSU_NO))                     "
				+ "               ELSE ' ' END )                                      PK_ORDER_2              ,                                                   "
				+ "        ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B')                                                                                  "
				+ "               THEN A.BUNHO||TO_CHAR(A.NAEWON_DATE,'YYYYMMDD')||A.GWA||A.DOCTOR||A.NAEWON_TYPE||LTRIM(TO_CHAR(A.JUBSU_NO))                     "
				+ "               ELSE ' ' END )                                      PK_ORDER_3              ,                                                   "
				+ "        ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'                                                                                          "
				+ "               THEN A.BUNHO||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.NAEWON_DATE))),'YYYYMMDD')||A.GWA||A.DOCTOR       "
				+ "               ELSE ' ' END )                                      PK_ORDER_4              ,                                                   "
				+ "        ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'                                                                                          "
				+ "               THEN A.BUNHO||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.NAEWON_DATE))),'YYYYMMDD')||A.GWA||A.DOCTOR       "
				+ "               ELSE ' ' END )                                      PK_ORDER_5              ,                                                   "
				+ "        ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) = 'H'                                                                                          "
				+ "               THEN A.BUNHO||TO_CHAR(A.NAEWON_DATE,'YYYYMMDD')||A.GWA||A.DOCTOR||A.NAEWON_TYPE||LTRIM(TO_CHAR(A.JUBSU_NO))                     "
				+ "               ELSE ' ' END )                                      PK_ORDER_6              ,                                                   "
				+ "        ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) = 'G'                                                                                          "
				+ "               THEN A.BUNHO||TO_CHAR(A.NAEWON_DATE,'YYYYMMDD')||A.GWA||A.DOCTOR||A.NAEWON_TYPE||LTRIM(TO_CHAR(A.JUBSU_NO))                     "
				+ "               ELSE ' ' END )                                      PK_ORDER_7              ,                                                   "
				+ "        A.PKOCS1003                                                PKOCS2003               ,                                                   "
				+ "        A.BUNHO                                                    BUNHO                   ,                                                   "
				+ "        0                                                          FKINP1001               ,                                                   "
				+ "        A.INPUT_GUBUN                                              INPUT_GUBUN             ,                                                   "
				+ "        A.SEQ                                                      SEQ                     ,                                                   "
				+ "        A.NAEWON_DATE                                               ORDER_DATE              ,                                                  "
				+ "        A.GROUP_SER                                                GROUP_SER               ,                                                   "
				+ "        NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,                                                   "
				+ "        A.HANGMOG_CODE                                             HANGMOG_CODE            ,                                                   "
				+ "        B.HANGMOG_NAME                                             HANGMOG_NAME            ,                                                   "
				+ "        A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,                                                   "
				+ "        E.SPECIMEN_NAME                                            SPECIMEN_NAME           ,                                                   "
				+ "        A.SURYANG                                                  SURYANG                 ,                                                   "
				+ "        A.ORD_DANUI                                                ORD_DANUI               ,                                                   "
				+ "        FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,                                                   "
				+ "        A.DV_TIME                                                  DV_TIME                 ,                                                   "
				+ "        A.DV                                                       DV                      ,                                                   "
				+ "        A.NALSU                                                    NALSU                   ,                                                   "
				+ "        A.JUSA                                                     JUSA                    ,                                                   "
				+ "        FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,                                                   "
				+ "        A.BOGYONG_CODE                                             BOGYONG_CODE            ,                                                   "
				+ "        FN_OCS_LOAD_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE)                                                                            "
				+ "                                                                   BOGYONG_NAME            ,                                                   "
				+ "        A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,                                                   "
				+ "        A.WONNAE_SAYU_CODE                                         WONNAE_SAYU_CODE        ,                                                   "
				+ "        A.EMERGENCY                                                EMERGENCY               ,                                                   "
				+ "        A.PAY                                                      PAY                     ,                                                   "
				+ "        A.FLUID_YN                                                 FLUID_YN                ,                                                   "
				+ "        A.TPN_YN                                                   TPN_YN                  ,                                                   "
				+ "        A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,                                                   "
				+ "        A.MUHYO                                                    MUHYO                   ,                                                   "
				+ "        A.PORTABLE_YN                                              PORTABLE_YN             ,                                                   "
				+ "        A.SYMYA                                                    SYMYA                   ,                                                   "
				+ "        '0'                                                        OCS_FLAG                ,                                                   "
				+ "        A.ORDER_GUBUN                                              ORDER_GUBUN             ,                                                   "
				+ "        A.JAERYO_JUNDAL_YN                                         JAERYO_JUNDAL_YN        ,                                                   "
				+ "        A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,                                                   "
				+ "        A.JUNDAL_PART                                              JUNDAL_PART             ,                                                   "
				+ "        A.MOVE_PART                                                MOVE_PART               ,                                                   "
				+ "        A.SUB_SUSUL                                                SUB_SUSUL               ,                                                   "
				+ "        A.AMT                                                      AMT                     ,                                                   "
				+ "        A.NALSU_SAYU_CODE                                          NALSU_SAYU_CODE         ,                                                   "
				+ "        A.PHYSICAL_CODE                                            PHYSICAL_CODE           ,                                                   "
				+ "        A.DV_1                                                     DV_1                    ,                                                   "
				+ "        A.DV_2                                                     DV_2                    ,                                                   "
				+ "        A.DV_3                                                     DV_3                    ,                                                   "
				+ "        A.DV_4                                                     DV_4                    ,                                                   "
				+ "        A.HOPE_DATE                                                HOPE_DATE               ,                                                   "
				+ "        A.ORDER_REMARK                                             ORDER_REMARK            ,                                                   "
				+ "        NULL                                                       NURSE_REMARK            ,                                                   "
				+ "        A.MIX_GROUP                                                MIX_GROUP               ,                                                   "
				+ "        NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,                                                   "
				+ "        B.SLIP_CODE                                                SLIP_CODE               ,                                                   "
				+ "        B.GROUP_YN                                                 GROUP_YN                ,                                                   "
				+ "        B.SG_CODE                                                  SG_CODE                 ,                                                   "
				+ "        B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,                                                   "
				+ "        B.INPUT_CONTROL                                            INPUT_CONTROL           ,                                                   "
				+ "        ( CASE WHEN FN_OCS_BULYONG_CHECK(A.HANGMOG_CODE, :f_gijun_date)  <> 'Y'                                                                "
				+ "               THEN 'N'                                                                                                                        "
				+ "               WHEN FN_OCS_BULYONG_CHECK(A.HANGMOG_CODE, :f_gijun_date)  = 'Y'                                                                 "
				+ "                AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', A.HANGMOG_CODE, A.BUNHO, :f_gijun_date) <> A.HANGMOG_CODE                            "
				+ "               THEN 'Z'                                                                                                                        "
				+ "               ELSE 'Y' END )                                      BULYONG_CHECK           ,                                                   "
				+ "        NVL(D.CODE_NAME, 'Etc')                                    INPUT_GUBUN_NAME        ,                                                   "
				+ "        DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,                                                   "
				+ "        B.ORD_DANUI                                                ORD_DANUI_BAS           ,                                                   "
				+ "        F.BUN_CODE                                                 BUN_CODE                ,                                                   "
				+ "        F.SG_GESAN                                                 SG_GESAN                ,                                                   "
				+ "        'N'                                                        OTHER_GWA               ,                                                   "
				+ "        A.BUNHO||TO_CHAR(A.NAEWON_DATE,'YYYYMMDD')||A.GWA||A.DOCTOR||A.NAEWON_TYPE||LTRIM(TO_CHAR(A.JUBSU_NO))                                 "
				+ "                                                                   DATA_CONTROL            ,                                                   "
				+ "        A.TEL_YN||LTRIM(TO_CHAR(NVL(C.SORT_KEY, 99), '00'))||LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||LTRIM(TO_CHAR(A.SEQ, '0000')) "
				+ "                                                                   CONT_KEY                                                                    "
				+ "   FROM BAS0310 F,                                                                                                                             "
				+ "        OCS0116 E,                                                                                                                             "
				+ "        OCS0132 D,                                                                                                                             "
				+ "        OCS0132 C,                                                                                                                             "
				+ "        OCS0103 B,                                                                                                                             "
				+ "        OCS1003 A                                                                                                                              "
				+ "  WHERE A.BUNHO            = :f_bunho                                                                                                          "
				+ "    AND A.NAEWON_DATE      = TO_DATE(:f_naewon_date,'YYYY/MM/DD')                                                              "
				+ "    AND A.GWA              = :f_gwa                                                                                                            "
				+ "    AND A.DOCTOR           = :f_doctor                                                                                                         "
				+ "    AND A.NAEWON_TYPE      = :f_naewon_type                                                                                                    "
				+ "   AND A.JUBSU_NO         = :f_jubsu_no                                                                                                        "
				+ "    AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR                                                                                                "
				+ "         ( :f_input_gubun = 'NR'           ) OR                                                                                                "
				+ "         ( :f_input_gubun = 'D%'           ))                                                                                                  "
				+ "    AND (( :f_order_gubun = '%'           ) OR                                                                                                 "
				+ "         ( :f_order_gubun = '1' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'C'         ) OR                                                             "
				+ "         ( :f_order_gubun = '2' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'D'         ) OR                                                             "
				+ "         ( :f_order_gubun = '3' AND SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B') ) OR                                                             "
				+ "         ( :f_order_gubun = '4' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'         ) OR                                                             "
				+ "         ( :f_order_gubun = '5' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'         ) OR                                                             "
				+ "         ( :f_order_gubun = '6' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'H'         ) OR                                                             "
				+ "         ( :f_order_gubun = '7' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'G'         ))                                                               "
				+ "    AND B.HANGMOG_CODE     = A.HANGMOG_CODE                                                                                                    "
				+ "    AND C.CODE     (+)     = A.ORDER_GUBUN                                                                                                     "
				+ "    AND C.CODE_TYPE(+)     = 'ORDER_GUBUN'                                                                                                     "
				+ "    AND D.CODE     (+)     = A.INPUT_GUBUN                                                                                                     "
				+ "    AND D.CODE_TYPE(+)     = 'INPUT_GUBUN'                                                                                                     "
				+ "    AND E.SPECIMEN_CODE(+) = A.SPECIMEN_CODE                                                                                                   "
				+ "    AND F.SG_CODE  (+)     = B.SG_CODE                                                                                                         "
				+ " ORDER BY 73                                                                                                                                   ";
			#endregion 

			#region qryLoadGumsaOrderDataList
			this.qryLoadGumsaOrderDataList 
				= "SELECT DISTINCT                                                                                                                                                                                                                                    "
				+ "       NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)))                                                                                                                                                                       "
				+ "                       ORDER_DATE,                                                                                                                                                                                                                 "
				+ "       A.BUNHO                   ,                                                                                                                                                                                                                 "
				+ "       A.FKINP1001               ,                                                                                                                                                                                                                 "
				+ "       DECODE( B.USER_GUBUN, '1', C.GWA, D.GWA )                                                                                                                                                                                                   "
				+ "                                         GWA        ,                                                                                                                                                                                              "
				+ "       FN_BAS_LOAD_GWA_NAME( DECODE( B.USER_GUBUN, '1', C.GWA, D.GWA ), A.ORDER_DATE )                                                                                                                                                             "
				+ "                                         GWA_NAME   ,                                                                                                                                                                                              "
				+ "       DECODE( B.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )                                                                                                                                                                                           "
				+ "                                         DOCTOR     ,                                                                                                                                                                                              "
				+ "       FN_BAS_LOAD_DOCTOR_NAME(DECODE( B.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR ), A.ORDER_DATE )                                                                                                                                                   "
				+ "                                         DOCTOR_NAME,                                                                                                                                                                                              "
				+ "       :f_input_gubun                    INPUT_GUBUN,                                                                                                                                                                                              "
				+ "       TO_DATE(:f_order_date,'YYYY/MM/DD')      GIJUN_DATE ,                                                                                                                                                                                       "
				+ "       A.BUNHO||TRIM(TO_CHAR(A.FKINP1001, '0000000000'))||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))),'YYYYMMDD')||DECODE( B.USER_GUBUN, '1', C.GWA, D.GWA )||DECODE( B.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )  "
				+ "                                         PK_ORDER   ,                                                                                                                                                                                              "
				+ "       :f_tel_yn                         TEL_YN     ,                                                                                                                                                                                              "
				+ "       FN_OCS_CHK_DOCTOR_TOIWON_DRG(A.BUNHO, A.FKINP1001, A.ORDER_DATE, DECODE( B.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR ))                                                                                                                         "
				+ "                                         TOIWON_DRG ,                                                                                                                                                                                              "
				+ "       TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))),'YYYYMMDD')||DECODE( B.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )                                                                                                "
				+ "                                         CONT_KEY                                                                                                                                                                                                  "
				+ "  FROM INP1001 D,                                                                                                                                                                                                                                  "
				+ "       BAS0260 C,                                                                                                                                                                                                                                  "
				+ "       ADM3200 B,                                                                                                                                                                                                                                  "
				+ "       OCS2003 A                                                                                                                                                                                                                                   "
				+ " WHERE A.BUNHO                = :f_bunho                                                                                                                                                                                                           "
				+ "   AND A.FKINP1001            = :f_fkinp1001                                                                                                                                                                                                       "
				+ "   AND A.ORDER_DATE           < TO_DATE(:f_order_date,'YYYY/MM/DD')                                                                                                                                                                                "
				+ "   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR                                                                                                                                                                                                     "
				+ "        ( :f_input_gubun = 'NR'           ) OR                                                                                                                                                                                                     "
				+ "        ( :f_input_gubun = 'D%'           ))                                                                                                                                                                                                       "
				+ "   AND A.IO_GUBUN             IS NULL                                                                                                                                                                                                              "
				+ "   AND A.NALSU                >= 0                                                                                                                                                                                                                 "
				+ "   AND NVL(A.DISPLAY_YN,'Y')  = 'Y'                                                                                                                                                                                                                "
				+ "   AND NVL(A.DC_YN,'N')       = 'N'                                                                                                                                                                                                                "
				+ "   AND NVL(A.OCS_DATA_YN,'Y') = 'Y'                                                                                                                                                                                                                "
				+ "   AND (( :f_order_gubun = '4' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'         ) OR                                                                                                                                                                  "
				+ "        ( :f_order_gubun = '5' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'         ))                                                                                                                                                                    "
				+ "   AND B.USER_ID              = A.INPUT_ID                                                                                                                                                                                                         "
				+ "   AND C.BUSEO_CODE           = B.DEPT_CODE                                                                                                                                                                                                        "
				+ "   AND C.BUSEO_YMD            = ( SELECT MAX(D.BUSEO_YMD)                                                                                                                                                                                          "
				+ "                                    FROM BAS0260 D                                                                                                                                                                                                 "
				+ "                                   WHERE D.BUSEO_CODE = C.BUSEO_CODE                                                                                                                                                                               "
				+ "                                     AND D.BUSEO_YMD  <= A.ORDER_DATE )                                                                                                                                                                            "
				+ "   AND NOT EXISTS ( SELECT 'X'                                                                                                                                                                                                                     "
				+ "                      FROM OCS6013 I,                                                                                                                                                                                                              "
				+ "                           OCS6017 J                                                                                                                                                                                                               "
				+ "                     WHERE I.FKOCS2003              = A.PKOCS2003                                                                                                                                                                                  "
				+ "                       AND J.PKOCS6017              = I.FKOCS6017                                                                                                                                                                                  "
				+ "                       AND NVL(J.ORDER_END_YN, 'N') = 'Y'                                                                                                                                                                                          "
				+ "                       AND J.ORDER_END_DATE         < A.ORDER_DATE )                                                                                                                                                                               "
				+ "   AND D.PKINP1001           = A.FKINP1001                                                                                                                                                                                                         "
				+ " ORDER BY 13 DESC                                                                                                                                                                                                                                  ";
			#endregion 

			#region qryLoadGumsaOCS2003
			this.qryLoadGumsaOCS2003 
				= "SELECT A.BUNHO||TRIM(TO_CHAR(A.FKINP1001, '0000000000'))||TO_CHAR(A.ORDER_DATE,'YYYYMMDD')||DECODE( G.USER_GUBUN, '1', H.GWA, I.GWA )||DECODE( G.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )                                                                         "
				+ "                                                                  PK_ORDER                ,                                                                                                                                                                      "
				+ "       ' '                                                        PK_ORDER_1              ,                                                                                                                                                                      "
				+ "       ' '                                                        PK_ORDER_2              ,                                                                                                                                                                      "
				+ "       ' '                                                        PK_ORDER_3              ,                                                                                                                                                                      "
				+ "       ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'                                                                                                                                                                                                             "
				+ "              THEN A.BUNHO||TRIM(TO_CHAR(A.FKINP1001, '0000000000'))||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))),'YYYYMMDD')||DECODE( G.USER_GUBUN, '1', H.GWA, I.GWA )||DECODE( G.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )    "
				+ "              ELSE ' ' END )                                      PK_ORDER_4              ,                                                                                                                                                                      "
				+ "       ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'                                                                                                                                                                                                             "
				+ "              THEN A.BUNHO||TRIM(TO_CHAR(A.FKINP1001, '0000000000'))||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))),'YYYYMMDD')||DECODE( G.USER_GUBUN, '1', H.GWA, I.GWA )||DECODE( G.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR )    "
				+ "              ELSE ' ' END )                                      PK_ORDER_5              ,                                                                                                                                                                      "
				+ "       ' '                                                        PK_ORDER_6              ,                                                                                                                                                                      "
				+ "       ' '                                                        PK_ORDER_7              ,                                                                                                                                                                      "
				+ "       A.PKOCS2003                                                PKOCS2003               ,                                                                                                                                                                      "
				+ "       A.BUNHO                                                    BUNHO                   ,                                                                                                                                                                      "
				+ "       A.FKINP1001                                                FKINP1001               ,                                                                                                                                                                      "
				+ "       A.INPUT_GUBUN                                              INPUT_GUBUN             ,                                                                                                                                                                      "
				+ "       A.SEQ                                                      SEQ                     ,                                                                                                                                                                      "
				+ "       A.ORDER_DATE                                               ORDER_DATE              ,                                                                                                                                                                      "
				+ "       A.GROUP_SER                                                GROUP_SER               ,                                                                                                                                                                      "
				+ "       NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,                                                                                                                                                                      "
				+ "       A.HANGMOG_CODE                                             HANGMOG_CODE            ,                                                                                                                                                                      "
				+ "       B.HANGMOG_NAME                                             HANGMOG_NAME            ,                                                                                                                                                                      "
				+ "       A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,                                                                                                                                                                      "
				+ "       E.SPECIMEN_NAME                                            SPECIMEN_NAME           ,                                                                                                                                                                      "
				+ "       A.SURYANG                                                  SURYANG                 ,                                                                                                                                                                      "
				+ "       A.ORD_DANUI                                                ORD_DANUI               ,                                                                                                                                                                      "
				+ "       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,                                                                                                                                                                      "
				+ "       A.DV_TIME                                                  DV_TIME                 ,                                                                                                                                                                      "
				+ "       A.DV                                                       DV                      ,                                                                                                                                                                      "
				+ "       A.NALSU                                                    NALSU                   ,                                                                                                                                                                      "
				+ "       A.JUSA                                                     JUSA                    ,                                                                                                                                                                      "
				+ "       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,                                                                                                                                                                      "
				+ "       A.BOGYONG_CODE                                             BOGYONG_CODE            ,                                                                                                                                                                      "
				+ "       FN_OCS_LOAD_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE)                                                                                                                                                                                               "
				+ "                                                                  BOGYONG_NAME            ,                                                                                                                                                                      "
				+ "       A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,                                                                                                                                                                      "
				+ "       A.WONNAE_SAYU_CODE                                         WONNAE_SAYU_CODE        ,                                                                                                                                                                      "
				+ "       A.EMERGENCY                                                EMERGENCY               ,                                                                                                                                                                      "
				+ "       A.PAY                                                      PAY                     ,                                                                                                                                                                      "
				+ "       A.FLUID_YN                                                 FLUID_YN                ,                                                                                                                                                                      "
				+ "       A.TPN_YN                                                   TPN_YN                  ,                                                                                                                                                                      "
				+ "       A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,                                                                                                                                                                      "
				+ "       A.MUHYO                                                    MUHYO                   ,                                                                                                                                                                      "
				+ "       A.PORTABLE_YN                                              PORTABLE_YN             ,                                                                                                                                                                      "
				+ "       A.SYMYA                                                    SYMYA                   ,                                                                                                                                                                      "
				+ "       '0'                                                        OCS_FLAG                ,                                                                                                                                                                      "
				+ "       A.ORDER_GUBUN                                              ORDER_GUBUN             ,                                                                                                                                                                      "
				+ "       A.JAERYO_JUNDAL_YN                                         JAERYO_JUNDAL_YN        ,                                                                                                                                                                      "
				+ "       A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,                                                                                                                                                                      "
				+ "       A.JUNDAL_PART                                              JUNDAL_PART             ,                                                                                                                                                                      "
				+ "       A.MOVE_PART                                                MOVE_PART               ,                                                                                                                                                                      "
				+ "       A.SUB_SUSUL                                                SUB_SUSUL               ,                                                                                                                                                                      "
				+ "       A.AMT                                                      AMT                     ,                                                                                                                                                                      "
				+ "       A.NALSU_SAYU_CODE                                          NALSU_SAYU_CODE         ,                                                                                                                                                                      "
				+ "       A.PHYSICAL_CODE                                            PHYSICAL_CODE           ,                                                                                                                                                                      "
				+ "       A.DV_1                                                     DV_1                    ,                                                                                                                                                                      "
				+ "       A.DV_2                                                     DV_2                    ,                                                                                                                                                                      "
				+ "       A.DV_3                                                     DV_3                    ,                                                                                                                                                                      "
				+ "       A.DV_4                                                     DV_4                    ,                                                                                                                                                                      "
				+ "       A.HOPE_DATE                                                HOPE_DATE               ,                                                                                                                                                                      "
				+ "       A.ORDER_REMARK                                             ORDER_REMARK            ,                                                                                                                                                                      "
				+ "       A.NURSE_REMARK                                             NURSE_REMAR             ,                                                                                                                                                                      "
				+ "       A.MIX_GROUP                                                MIX_GROUP               ,                                                                                                                                                                      "
				+ "       NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,                                                                                                                                                                      "
				+ "       B.SLIP_CODE                                                SLIP_CODE               ,                                                                                                                                                                      "
				+ "       B.GROUP_YN                                                 GROUP_YN                ,                                                                                                                                                                      "
				+ "       B.SG_CODE                                                  SG_CODE                 ,                                                                                                                                                                      "
				+ "       B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,                                                                                                                                                                      "
				+ "       B.INPUT_CONTROL                                            INPUT_CONTROL           ,                                                                                                                                                                      "
				+ "       ( CASE WHEN FN_OCS_BULYONG_CHECK(A.HANGMOG_CODE, :f_gijun_date)  <> 'Y'                                                                                                                                                                                   "
				+ "              THEN 'N'                                                                                                                                                                                                                                           "
				+ "              WHEN FN_OCS_BULYONG_CHECK(A.HANGMOG_CODE, :f_gijun_date)  = 'Y'                                                                                                                                                                                    "
				+ "               AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', A.HANGMOG_CODE, A.BUNHO, :f_gijun_date) <> A.HANGMOG_CODE                                                                                                                                               "
				+ "              THEN 'Z'                                                                                                                                                                                                                                           "
				+ "              ELSE 'Y' END )                                      BULYONG_CHECK           ,                                                                                                                                                                      "
				+ "       NVL(D.CODE_NAME, 'Etc')                                    INPUT_GUBUN_NAME        ,                                                                                                                                                                      "
				+ "       DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,                                                                                                                                                                      "
				+ "       B.ORD_DANUI                                                ORD_DANUI_BAS           ,                                                                                                                                                                      "
				+ "       F.BUN_CODE                                                 BUN_CODE                ,                                                                                                                                                                      "
				+ "       F.SG_GESAN                                                 SG_GESAN                ,                                                                                                                                                                      "
				+ "       ( CASE WHEN NVL(G.USER_GUBUN, '3') = '1'                                                                                                                                                                                                                  "
				+ "               AND NVL(G.DEPT_CODE , 'X') <> TRIM(:t_user_buseo_code)   THEN 'Y'                                                                                                                                                                                 "
				+ "              ELSE 'N' END )                                      OTHER_GWA               ,                                                                                                                                                                      "
				+ "       TRIM(TO_CHAR(A.FKINP1001))||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))),'YYYYMMDD')||A.INPUT_GUBUN                                                                                                                      "
				+ "                                                                  DATA_CONTROL            ,                                                                                                                                                                      "
				+ "       LTRIM(TO_CHAR(NVL(D.SORT_KEY, 99), '00'))||LTRIM(TO_CHAR(NVL(C.SORT_KEY, 99), '00'))||LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||LTRIM(TO_CHAR(A.SEQ, '0000'))                                                                           "
				+ "                                                                  CONT_KEY                                                                                                                                                                                       "
				+ "  FROM INP1001 I,                                                                                                                                                                                                                                                "
				+ "       BAS0260 H,                                                                                                                                                                                                                                                "
				+ "       ADM3200 G,                                                                                                                                                                                                                                                "
				+ "       BAS0310 F,                                                                                                                                                                                                                                                "
				+ "       OCS0116 E,                                                                                                                                                                                                                                                "
				+ "       OCS0132 D,                                                                                                                                                                                                                                                "
				+ "       OCS0132 C,                                                                                                                                                                                                                                                "
				+ "       OCS0103 B,                                                                                                                                                                                                                                                "
				+ "       OCS2003 A                                                                                                                                                                                                                                                 "
				+ " WHERE A.BUNHO                = :f_bunho                                                                                                                                                                                                                         "
				+ "   AND A.FKINP1001            = :f_fkinp1001                                                                                                                                                                                                                     "
				+ "   AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) = TO_DATE(:f_order_date,'YYYY/MM/DD')                                                                                                                                               "
				+ "   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR                                                                                                                                                                                                                   "
				+ "        ( :f_input_gubun = 'NR'           ) OR                                                                                                                                                                                                                   "
				+ "        ( :f_input_gubun = 'D%'           ))                                                                                                                                                                                                                     "
				+ "   AND A.IO_GUBUN             IS NULL                                                                                                                                                                                                                            "
				+ "   AND A.NALSU                >= 0                                                                                                                                                                                                                               "
				+ "   AND NVL(A.DISPLAY_YN,'Y')  = 'Y'                                                                                                                                                                                                                              "
				+ "   AND NVL(A.DC_YN,'N')       = 'N'                                                                                                                                                                                                                              "
				+ "   AND NVL(A.OCS_DATA_YN,'N') = 'Y'                                                                                                                                                                                                                              "
				+ "   AND (( :f_order_gubun = '4' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'         ) OR                                                                                                                                                                                "
				+ "        ( :f_order_gubun = '5' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'         ))                                                                                                                                                                                  "
				+ "   AND B.HANGMOG_CODE         = A.HANGMOG_CODE                                                                                                                                                                                                                   "
				+ "   AND C.CODE     (+)         = A.ORDER_GUBUN                                                                                                                                                                                                                    "
				+ "   AND C.CODE_TYPE(+)         = 'ORDER_GUBUN'                                                                                                                                                                                                                    "
				+ "   AND D.CODE     (+)         = A.INPUT_GUBUN                                                                                                                                                                                                                    "
				+ "   AND D.CODE_TYPE(+)         = 'INPUT_GUBUN'                                                                                                                                                                                                                    "
				+ "   AND E.SPECIMEN_CODE(+)     = A.SPECIMEN_CODE                                                                                                                                                                                                                  "
				+ "   AND F.SG_CODE  (+)         = B.SG_CODE                                                                                                                                                                                                                        "
				+ "   AND G.USER_ID              = A.INPUT_ID                                                                                                                                                                                                                       "
				+ "   AND H.BUSEO_CODE           = G.DEPT_CODE                                                                                                                                                                                                                      "
				+ "   AND H.BUSEO_YMD            = ( SELECT MAX(J.BUSEO_YMD)                                                                                                                                                                                                        "
				+ "                                    FROM BAS0260 J                                                                                                                                                                                                               "
				+ "                                   WHERE J.BUSEO_CODE = H.BUSEO_CODE                                                                                                                                                                                             "
				+ "                                     AND J.BUSEO_YMD <= A.ORDER_DATE )                                                                                                                                                                                           "
				+ "   AND I.PKINP1001            = A.FKINP1001                                                                                                                                                                                                                      "
				+ "   AND DECODE( G.USER_GUBUN, '1', H.GWA     , I.GWA    ) = :f_gwa                                                                                                                                                                                                "
				+ "   AND DECODE( G.USER_GUBUN, '1', A.INPUT_ID, A.DOCTOR ) = :f_doctor                                                                                                                                                                                             "
				+ "   AND NOT EXISTS ( SELECT 'X'                                                                                                                                                                                                                                   "
				+ "                      FROM OCS6013 K,                                                                                                                                                                                                                            "
				+ "                           OCS6017 L                                                                                                                                                                                                                             "
				+ "                     WHERE K.FKOCS2003              = A.PKOCS2003                                                                                                                                                                                                "
				+ "                       AND L.PKOCS6017              = K.FKOCS6017                                                                                                                                                                                                "
				+ "                       AND NVL(L.ORDER_END_YN, 'N') = 'Y'                                                                                                                                                                                                        "
				+ "                       AND L.ORDER_END_DATE         < A.ORDER_DATE )                                                                                                                                                                                             "
				+ " ORDER BY NVL(D.SORT_KEY, 99), NVL(C.SORT_KEY, 99), A.GROUP_SER, NVL(A.MIX_GROUP, ' '), A.SEQ                                                                                                                                                                    ";
			#endregion 

			#region qryLoadGumsaOUT1001
			this.qryLoadGumsaOUT1001
				= "SELECT DISTINCT                                                                                                              "
				+ "       NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.NAEWON_DATE)))                                                "
				+ "                                         NAEWON_DATE,                                                                        "
				+ "       A.GWA                             GWA,                                                                                "
				+ "       FN_BAS_LOAD_GWA_NAME( A.GWA, A.NAEWON_DATE)                                                                           "
				+ "                                         GWA_NAME,                                                                           "
				+ "       FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE)                                                                      "
				+ "                                         DOCTOR_NAME,                                                                        "
				+ "       0                                 NALSU,                                                                              "
				+ "       A.BUNHO                           BUNHO,                                                                              "
				+ "       A.DOCTOR                          DOCTOR,                                                                             "
				+ "       ''                                GUBUN_NAME ,                                                                        "
				+ "       ''                                CHOJAE_NAME,                                                                        "
				+ "       '0'                               NAEWON_TYPE,                                                                        "
				+ "       0                                 JUBSU_NO   ,                                                                        "
				+ "       A.BUNHO||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.NAEWON_DATE))),'YYYYMMDD')||A.GWA||A.DOCTOR  "
				+ "                                         PK_ORDER,                                                                           "
				+ "       TRIM(RPAD(:f_input_gubun,10))     INPUT_GUBUN,                                                                        "
				+ "       :f_tel_yn                         TEL_YN                                                                              "
				+ "  FROM OCS1003 A                                                                                                             "
				+ " WHERE A.BUNHO        = :f_bunho                                                                                             "
				+ "   AND A.NAEWON_DATE < TO_DATE(:f_order_date,'YYYY/MM/DD')                                                                   "
				+ "   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR                                                                               "
				+ "        ( :f_input_gubun = 'NR'           ) OR                                                                               "
				+ "        ( :f_input_gubun = 'D%'           ))                                                                                 "
				+ "   AND NVL(A.DISPLAY_YN , 'Y') = 'Y'                                                                                         "
				+ "   AND NVL(A.OCS_DATA_YN, 'Y') = 'Y'                                                                                         "
				+ "   AND NVL(A.DC_YN,'N')        = 'N'                                                                                         "
				+ "   AND A.NALSU                 >= 0                                                                                          "
				+ "   AND (( :f_order_gubun = '4' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'         ) OR                                            "
				+ "        ( :f_order_gubun = '5' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'         ))                                              "
				+ "  ORDER BY 12 DESC                                                                                                           ";
			#endregion 

			#region qryLoadGumsaOCS1003
			this.qryLoadGumsaOCS1003 
				= "SELECT A.BUNHO||TO_CHAR(A.NAEWON_DATE,'YYYYMMDD')||A.GWA||A.DOCTOR||A.NAEWON_TYPE||LTRIM(TO_CHAR(A.JUBSU_NO))                               "
				+ "                                                                  PK_ORDER                ,                                                 "
				+ "       ' '                                                        PK_ORDER_1              ,                                                 "
				+ "       ' '                                                        PK_ORDER_2              ,                                                 "
				+ "       ' '                                                        PK_ORDER_3              ,                                                 "
				+ "       ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'                                                                                        "
				+ "              THEN A.BUNHO||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.NAEWON_DATE))),'YYYYMMDD')||A.GWA||A.DOCTOR     "
				+ "              ELSE ' ' END )                                      PK_ORDER_4              ,                                                 "
				+ "       ( CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'                                                                                        "
				+ "              THEN A.BUNHO||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.NAEWON_DATE))),'YYYYMMDD')||A.GWA||A.DOCTOR     "
				+ "              ELSE ' ' END )                                      PK_ORDER_5              ,                                                 "
				+ "       ' '                                                        PK_ORDER_6              ,                                                 "
				+ "       ' '                                                        PK_ORDER_7              ,                                                 "
				+ "       A.PKOCS1003                                                PKOCS2003               ,                                                 "
				+ "       A.BUNHO                                                    BUNHO                   ,                                                 "
				+ "       0                                                          FKINP1001               ,                                                 "
				+ "       A.INPUT_GUBUN                                              INPUT_GUBUN             ,                                                 "
				+ "       A.SEQ                                                      SEQ                     ,                                                 "
				+ "       A.NAEWON_DATE                                               ORDER_DATE              ,                                                "
				+ "       A.GROUP_SER                                                GROUP_SER               ,                                                 "
				+ "       NVL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,                                                 "
				+ "       A.HANGMOG_CODE                                             HANGMOG_CODE            ,                                                 "
				+ "       B.HANGMOG_NAME                                             HANGMOG_NAME            ,                                                 "
				+ "       A.SPECIMEN_CODE                                            SPECIMEN_CODE           ,                                                 "
				+ "       E.SPECIMEN_NAME                                            SPECIMEN_NAME           ,                                                 "
				+ "       A.SURYANG                                                  SURYANG                 ,                                                 "
				+ "       A.ORD_DANUI                                                ORD_DANUI               ,                                                 "
				+ "       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)            ORD_DANUI_NAME          ,                                                 "
				+ "       A.DV_TIME                                                  DV_TIME                 ,                                                 "
				+ "       A.DV                                                       DV                      ,                                                 "
				+ "       A.NALSU                                                    NALSU                   ,                                                 "
				+ "       A.JUSA                                                     JUSA                    ,                                                 "
				+ "       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                      JUSA_NAME               ,                                                 "
				+ "       A.BOGYONG_CODE                                             BOGYONG_CODE            ,                                                 "
				+ "       FN_OCS_LOAD_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE)                                                                          "
				+ "                                                                  BOGYONG_NAME            ,                                                 "
				+ "       A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,                                                 "
				+ "       A.WONNAE_SAYU_CODE                                         WONNAE_SAYU_CODE        ,                                                 "
				+ "       A.EMERGENCY                                                EMERGENCY               ,                                                 "
				+ "       A.PAY                                                      PAY                     ,                                                 "
				+ "       A.FLUID_YN                                                 FLUID_YN                ,                                                 "
				+ "       A.TPN_YN                                                   TPN_YN                  ,                                                 "
				+ "       A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,                                                 "
				+ "       A.MUHYO                                                    MUHYO                   ,                                                 "
				+ "       A.PORTABLE_YN                                              PORTABLE_YN             ,                                                 "
				+ "       A.SYMYA                                                    SYMYA                   ,                                                 "
				+ "       '0'                                                        OCS_FLAG                ,                                                 "
				+ "       A.ORDER_GUBUN                                              ORDER_GUBUN             ,                                                 "
				+ "       A.JAERYO_JUNDAL_YN                                         JAERYO_JUNDAL_YN        ,                                                 "
				+ "       A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,                                                 "
				+ "       A.JUNDAL_PART                                              JUNDAL_PART             ,                                                 "
				+ "       A.MOVE_PART                                                MOVE_PART               ,                                                 "
				+ "       A.SUB_SUSUL                                                SUB_SUSUL               ,                                                 "
				+ "       A.AMT                                                      AMT                     ,                                                 "
				+ "       A.NALSU_SAYU_CODE                                          NALSU_SAYU_CODE         ,                                                 "
				+ "       A.PHYSICAL_CODE                                            PHYSICAL_CODE           ,                                                 "
				+ "       A.DV_1                                                     DV_1                    ,                                                 "
				+ "       A.DV_2                                                     DV_2                    ,                                                 "
				+ "       A.DV_3                                                     DV_3                    ,                                                 "
				+ "       A.DV_4                                                     DV_4                    ,                                                 "
				+ "       A.HOPE_DATE                                                HOPE_DATE               ,                                                 "
				+ "       A.ORDER_REMARK                                             ORDER_REMARK            ,                                                 "
				+ "       NULL                                                       NURSE_REMARK            ,                                                 "
				+ "       A.MIX_GROUP                                                MIX_GROUP               ,                                                 "
				+ "       NVL(A.REGULAR_YN, 'N')                                     REGULAR_YN              ,                                                 "
				+ "       B.SLIP_CODE                                                SLIP_CODE               ,                                                 "
				+ "       B.GROUP_YN                                                 GROUP_YN                ,                                                 "
				+ "       B.SG_CODE                                                  SG_CODE                 ,                                                 "
				+ "       B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,                                                 "
				+ "       B.INPUT_CONTROL                                            INPUT_CONTROL           ,                                                 "
				+ "       ( CASE WHEN FN_OCS_BULYONG_CHECK(A.HANGMOG_CODE, :f_gijun_date)  <> 'Y'                                                              "
				+ "              THEN 'N'                                                                                                                      "
				+ "              WHEN FN_OCS_BULYONG_CHECK(A.HANGMOG_CODE, :f_gijun_date)  = 'Y'                                                               "
				+ "               AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', A.HANGMOG_CODE, A.BUNHO, :f_gijun_date) <> A.HANGMOG_CODE                          "
				+ "              THEN 'Z'                                                                                                                      "
				+ "              ELSE 'Y' END )                                      BULYONG_CHECK           ,                                                 "
				+ "       NVL(D.CODE_NAME, 'Etc')                                    INPUT_GUBUN_NAME        ,                                                 "
				+ "       DECODE(B.ORD_DANUI, NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,                                                 "
				+ "       B.ORD_DANUI                                                ORD_DANUI_BAS           ,                                                 "
				+ "       F.BUN_CODE                                                 BUN_CODE                ,                                                 "
				+ "       F.SG_GESAN                                                 SG_GESAN                ,                                                 "
				+ "       'N'                                                        OTHER_GWA               ,                                                 "
				+ "       A.BUNHO||TO_CHAR(NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.NAEWON_DATE))),'YYYYMMDD')||A.GWA||A.DOCTOR                 "
				+ "                                                                  DATA_CONTROL            ,                                                 "
				+ "       A.TEL_YN||LTRIM(TO_CHAR(NVL(C.SORT_KEY, 99), '00'))||LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||LTRIM(TO_CHAR(A.SEQ, '0000')) "
				+ "                                                                  CONT_KEY                                                                  "
				+ "  FROM BAS0310 F,                                                                                                                           "
				+ "       OCS0116 E,                                                                                                                           "
				+ "       OCS0132 D,                                                                                                                           "
				+ "       OCS0132 C,                                                                                                                           "
				+ "       OCS0103 B,                                                                                                                           "
				+ "       OCS1003 A                                                                                                                            "
				+ " WHERE A.BUNHO            = :f_bunho                                                                                                        "
				+ "   AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.NAEWON_DATE))) = TO_DATE(:f_naewon_date,'YYYY/MM/DD')                        "
				+ "   AND A.GWA              = :f_gwa                                                                                                          "
				+ "   AND A.DOCTOR           = :f_doctor                                                                                                       "
				+ "   AND (( A.INPUT_GUBUN  = :f_input_gubun ) OR                                                                                              "
				+ "        ( :f_input_gubun = 'NR'           ) OR                                                                                              "
				+ "        ( :f_input_gubun = 'D%'           ))                                                                                                "
				+ "   AND NVL(A.DISPLAY_YN , 'Y') = 'Y'                                                                                                        "
				+ "   AND NVL(A.OCS_DATA_YN, 'Y') = 'Y'                                                                                                        "
				+ "   AND NVL(A.DC_YN,'N')   = 'N'                                                                                                             "
				+ "   AND A.NALSU           >= 0                                                                                                               "
				+ "   AND (( :f_order_gubun = '4' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'F'         ) OR                                                           "
				+ "        ( :f_order_gubun = '5' AND SUBSTR(A.ORDER_GUBUN, 2, 1) = 'E'         ))                                                             "
				+ "   AND B.HANGMOG_CODE     = A.HANGMOG_CODE                                                                                                  "
				+ "   AND C.CODE     (+)     = A.ORDER_GUBUN                                                                                                   "
				+ "   AND C.CODE_TYPE(+)     = 'ORDER_GUBUN'                                                                                                   "
				+ "   AND D.CODE     (+)     = A.INPUT_GUBUN                                                                                                   "
				+ "   AND D.CODE_TYPE(+)     = 'INPUT_GUBUN'                                                                                                   "
				+ "   AND E.SPECIMEN_CODE(+) = A.SPECIMEN_CODE                                                                                                 "
				+ "   AND F.SG_CODE  (+)     = B.SG_CODE                                                                                                       "
				+ " ORDER BY 73                                                                                                                                ";
			#endregion 

			this.dloCheckLayout.QuerySQL = this.qryLoadOrderDataList;
			this.grdOrdList.QuerySQL = this.qryLoadOrderDataList;
			this.grdOCS2003.QuerySQL = this.qryLoadOCS2003;
			this.grdOCS2005.QuerySQL = this.qryLoadOCS2005;
			this.grdOUT1001.QuerySQL = this.qryLoadOUT1001;
			this.grdOCS1001.QuerySQL = this.qryLoadOCS1001;
			this.grdOCS1003.QuerySQL = this.qryLoadOCS1003;



			
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OCS2003Q00));
			this.xPanel1 = new IHIS.Framework.XPanel();
			this.dpkOrdList_date = new IHIS.Framework.XDatePicker();
			this.xLabel5 = new IHIS.Framework.XLabel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.xPanel2 = new IHIS.Framework.XPanel();
			this.chkIsNewGroup = new System.Windows.Forms.CheckBox();
			this.btnProcess = new IHIS.Framework.XButton();
			this.xButtonList1 = new IHIS.Framework.XButtonList();
			this.xPanel3 = new IHIS.Framework.XPanel();
			this.grdOUT1001 = new IHIS.Framework.XMstGrid();
			this.xEditGridCell233 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell234 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell235 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell236 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell237 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell238 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell239 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell205 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell206 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell240 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell241 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell242 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell243 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell244 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell207 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell245 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell246 = new IHIS.Framework.XEditGridCell();
			this.grdOrdList = new IHIS.Framework.XMstGrid();
			this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell226 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell227 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell228 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell229 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell225 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell208 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
			this.tabOrderGubun = new IHIS.Framework.XTabControl();
			this.tabPage1 = new IHIS.X.Magic.Controls.TabPage();
			this.tabPage2 = new IHIS.X.Magic.Controls.TabPage();
			this.tabPage3 = new IHIS.X.Magic.Controls.TabPage();
			this.tabPage4 = new IHIS.X.Magic.Controls.TabPage();
			this.tabPage5 = new IHIS.X.Magic.Controls.TabPage();
			this.tabPage6 = new IHIS.X.Magic.Controls.TabPage();
			this.tabPage7 = new IHIS.X.Magic.Controls.TabPage();
			this.tabPage8 = new IHIS.X.Magic.Controls.TabPage();
			this.xPanel4 = new IHIS.Framework.XPanel();
			this.rbtIn = new System.Windows.Forms.RadioButton();
			this.rbtOut = new System.Windows.Forms.RadioButton();
			this.pnlInput_gubun = new IHIS.Framework.XPanel();
			this.rbt = new IHIS.Framework.XRadioButton();
			this.pnlIn = new IHIS.Framework.XPanel();
			this.pnlOrder = new IHIS.Framework.XPanel();
			this.grdOCS2003 = new IHIS.Framework.XEditGrid();
			this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell209 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell210 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell211 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell217 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell222 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell223 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell224 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell215 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
			this.xGridHeader1 = new IHIS.Framework.XGridHeader();
			this.lblSelectOrder = new IHIS.Framework.XLabel();
			this.pnlJisi = new IHIS.Framework.XPanel();
			this.grdOCS2005 = new IHIS.Framework.XEditGrid();
			this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
			this.lblSelectDirect = new IHIS.Framework.XLabel();
			this.dloSelectOCS2003 = new IHIS.Framework.MultiLayout();
			this.dloOrder_danui = new IHIS.Framework.MultiLayout();
			this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
			this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
			this.dloSelectOCS2005 = new IHIS.Framework.MultiLayout();
			this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
			this.dloCheckLayout = new IHIS.Framework.MultiLayout();
			this.pnlOut = new IHIS.Framework.XPanel();
			this.pnlOutOrder = new IHIS.Framework.XPanel();
			this.grdOCS1003 = new IHIS.Framework.XEditGrid();
			this.xEditGridCell140 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell212 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell213 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell214 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell218 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell219 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell220 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell221 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell141 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell142 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell143 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell144 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell145 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell146 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell147 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell150 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell151 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell152 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell153 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell154 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell155 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell156 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell157 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell158 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell159 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell160 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell161 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell162 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell163 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell164 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell165 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell166 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell167 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell168 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell169 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell170 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell171 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell172 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell173 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell174 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell175 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell176 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell177 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell178 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell179 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell180 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell181 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell182 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell183 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell184 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell185 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell186 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell187 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell188 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell189 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell190 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell216 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell191 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell192 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell193 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell194 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell195 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell196 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell197 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell198 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell199 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell200 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell201 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell202 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell203 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell204 = new IHIS.Framework.XEditGridCell();
			this.xGridHeader2 = new IHIS.Framework.XGridHeader();
			this.lblSelectOutOrder = new IHIS.Framework.XLabel();
			this.sptOut = new System.Windows.Forms.Splitter();
			this.pnlOutSang = new IHIS.Framework.XPanel();
			this.grdOCS1001 = new IHIS.Framework.XEditGrid();
			this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell110 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell111 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell130 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell112 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
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
			this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell131 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell132 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell133 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell136 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell137 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell138 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell248 = new IHIS.Framework.XEditGridCell();
			this.lblSelectSang = new IHIS.Framework.XLabel();
			this.dloSelectOCS1003 = new IHIS.Framework.MultiLayout();
			this.dloSelectOCS1001 = new IHIS.Framework.MultiLayout();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.xEditGridCell230 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell231 = new IHIS.Framework.XEditGridCell();
			this.xEditGridCell232 = new IHIS.Framework.XEditGridCell();
			this.xPanel1.SuspendLayout();
			this.xPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
			this.xPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdOUT1001)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdOrdList)).BeginInit();
			this.tabOrderGubun.SuspendLayout();
			this.xPanel4.SuspendLayout();
			this.pnlInput_gubun.SuspendLayout();
			this.pnlIn.SuspendLayout();
			this.pnlOrder.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdOCS2003)).BeginInit();
			this.pnlJisi.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdOCS2005)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS2003)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dloOrder_danui)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS2005)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dloCheckLayout)).BeginInit();
			this.pnlOut.SuspendLayout();
			this.pnlOutOrder.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).BeginInit();
			this.pnlOutSang.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdOCS1001)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS1003)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS1001)).BeginInit();
			this.SuspendLayout();
			// 
			// ImageList
			// 
			this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
			// 
			// xPanel1
			// 
			this.xPanel1.Controls.Add(this.dpkOrdList_date);
			this.xPanel1.Controls.Add(this.xLabel5);
			this.xPanel1.Controls.Add(this.pictureBox1);
			this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.xPanel1.DrawBorder = true;
			this.xPanel1.Location = new System.Drawing.Point(0, 0);
			this.xPanel1.Name = "xPanel1";
			this.xPanel1.Size = new System.Drawing.Size(960, 30);
			this.xPanel1.TabIndex = 0;
			// 
			// dpkOrdList_date
			// 
			this.dpkOrdList_date.Location = new System.Drawing.Point(110, 6);
			this.dpkOrdList_date.Name = "dpkOrdList_date";
			this.dpkOrdList_date.Size = new System.Drawing.Size(102, 20);
			this.dpkOrdList_date.TabIndex = 5;
			this.dpkOrdList_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkOrdList_date_DataValidating);
			// 
			// xLabel5
			// 
			this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
			this.xLabel5.EdgeRounding = false;
			this.xLabel5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xLabel5.Location = new System.Drawing.Point(10, 6);
			this.xLabel5.Name = "xLabel5";
			this.xLabel5.Size = new System.Drawing.Size(98, 19);
			this.xLabel5.TabIndex = 4;
			this.xLabel5.Text = "オ―ダ日付";
			this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(958, 28);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// xPanel2
			// 
			this.xPanel2.Controls.Add(this.chkIsNewGroup);
			this.xPanel2.Controls.Add(this.btnProcess);
			this.xPanel2.Controls.Add(this.xButtonList1);
			this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.xPanel2.DrawBorder = true;
			this.xPanel2.Location = new System.Drawing.Point(0, 548);
			this.xPanel2.Name = "xPanel2";
			this.xPanel2.Size = new System.Drawing.Size(960, 42);
			this.xPanel2.TabIndex = 1;
			// 
			// chkIsNewGroup
			// 
			this.chkIsNewGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkIsNewGroup.Appearance = System.Windows.Forms.Appearance.Button;
			this.chkIsNewGroup.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.chkIsNewGroup.Checked = true;
			this.chkIsNewGroup.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkIsNewGroup.Cursor = System.Windows.Forms.Cursors.Hand;
			this.chkIsNewGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.chkIsNewGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.chkIsNewGroup.ImageIndex = 1;
			this.chkIsNewGroup.ImageList = this.ImageList;
			this.chkIsNewGroup.Location = new System.Drawing.Point(188, 6);
			this.chkIsNewGroup.Name = "chkIsNewGroup";
			this.chkIsNewGroup.Size = new System.Drawing.Size(218, 24);
			this.chkIsNewGroup.TabIndex = 23;
			this.chkIsNewGroup.Text = "     新規オーダグループ番号生成可否";
			this.chkIsNewGroup.CheckedChanged += new System.EventHandler(this.chkIsNewGroup_CheckedChanged);
			// 
			// btnProcess
			// 
			this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
			this.btnProcess.Location = new System.Drawing.Point(612, 6);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(98, 28);
			this.btnProcess.TabIndex = 6;
			this.btnProcess.Text = "選択";
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			// 
			// xButtonList1
			// 
			this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xButtonList1.IsVisibleReset = false;
			this.xButtonList1.Location = new System.Drawing.Point(710, 2);
			this.xButtonList1.Name = "xButtonList1";
			this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
			this.xButtonList1.Size = new System.Drawing.Size(163, 34);
			this.xButtonList1.TabIndex = 0;
			this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
			// 
			// xPanel3
			// 
			this.xPanel3.Controls.Add(this.grdOUT1001);
			this.xPanel3.Controls.Add(this.grdOrdList);
			this.xPanel3.Controls.Add(this.tabOrderGubun);
			this.xPanel3.Controls.Add(this.xPanel4);
			this.xPanel3.Dock = System.Windows.Forms.DockStyle.Left;
			this.xPanel3.DrawBorder = true;
			this.xPanel3.Location = new System.Drawing.Point(0, 30);
			this.xPanel3.Name = "xPanel3";
			this.xPanel3.Size = new System.Drawing.Size(260, 518);
			this.xPanel3.TabIndex = 2;
			// 
			// grdOUT1001
			// 
			this.grdOUT1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
																				  this.xEditGridCell233,
																				  this.xEditGridCell234,
																				  this.xEditGridCell235,
																				  this.xEditGridCell236,
																				  this.xEditGridCell237,
																				  this.xEditGridCell238,
																				  this.xEditGridCell239,
																				  this.xEditGridCell205,
																				  this.xEditGridCell206,
																				  this.xEditGridCell240,
																				  this.xEditGridCell241,
																				  this.xEditGridCell242,
																				  this.xEditGridCell243,
																				  this.xEditGridCell244,
																				  this.xEditGridCell207,
																				  this.xEditGridCell245,
																				  this.xEditGridCell246});
			this.grdOUT1001.ColPerLine = 6;
			this.grdOUT1001.Cols = 6;
			this.grdOUT1001.EnableMultiSelection = true;
			this.grdOUT1001.FixedRows = 1;
			this.grdOUT1001.HeaderHeights.Add(21);
			this.grdOUT1001.ImageList = this.ImageList;
			this.grdOUT1001.Location = new System.Drawing.Point(12, 188);
			this.grdOUT1001.Name = "grdOUT1001";
			this.grdOUT1001.Rows = 2;
			this.grdOUT1001.RowStateCheckOnPaint = false;
			this.grdOUT1001.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
			this.grdOUT1001.Size = new System.Drawing.Size(256, 464);
			this.grdOUT1001.TabIndex = 31;
			this.grdOUT1001.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOUT1001_QueryEnd);
			this.grdOUT1001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOUT1001_RowFocusChanged);
			this.grdOUT1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOUT1001_QueryStarting);
			// 
			// xEditGridCell233
			// 
			this.xEditGridCell233.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell233.CellName = "naewon_date";
			this.xEditGridCell233.CellType = IHIS.Framework.XCellDataType.Date;
			this.xEditGridCell233.CellWidth = 87;
			this.xEditGridCell233.Col = 1;
			this.xEditGridCell233.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
			this.xEditGridCell233.HeaderText = "オ―ダ日付";
			this.xEditGridCell233.IsUpdatable = false;
			this.xEditGridCell233.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell233.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell234
			// 
			this.xEditGridCell234.CellName = "gwa";
			this.xEditGridCell234.Col = -1;
			this.xEditGridCell234.HeaderText = "gwa";
			this.xEditGridCell234.IsVisible = false;
			this.xEditGridCell234.Row = -1;
			// 
			// xEditGridCell235
			// 
			this.xEditGridCell235.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell235.CellName = "gwa_name";
			this.xEditGridCell235.CellWidth = 51;
			this.xEditGridCell235.Col = 2;
			this.xEditGridCell235.HeaderText = "診療科";
			this.xEditGridCell235.IsUpdatable = false;
			this.xEditGridCell235.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell235.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell236
			// 
			this.xEditGridCell236.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell236.CellName = "doctor_name";
			this.xEditGridCell236.CellWidth = 66;
			this.xEditGridCell236.Col = 3;
			this.xEditGridCell236.HeaderText = "医師";
			this.xEditGridCell236.IsUpdatable = false;
			this.xEditGridCell236.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell236.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell237
			// 
			this.xEditGridCell237.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell237.CellName = "nalsu";
			this.xEditGridCell237.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell237.CellWidth = 40;
			this.xEditGridCell237.Col = -1;
			this.xEditGridCell237.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xEditGridCell237.HeaderText = "日数";
			this.xEditGridCell237.IsVisible = false;
			this.xEditGridCell237.Row = -1;
			this.xEditGridCell237.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell237.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell238
			// 
			this.xEditGridCell238.CellName = "bunho";
			this.xEditGridCell238.Col = -1;
			this.xEditGridCell238.HeaderText = "bunho";
			this.xEditGridCell238.IsUpdatable = false;
			this.xEditGridCell238.IsVisible = false;
			this.xEditGridCell238.Row = -1;
			// 
			// xEditGridCell239
			// 
			this.xEditGridCell239.CellName = "doctor";
			this.xEditGridCell239.Col = -1;
			this.xEditGridCell239.HeaderText = "doctor";
			this.xEditGridCell239.IsUpdatable = false;
			this.xEditGridCell239.IsVisible = false;
			this.xEditGridCell239.Row = -1;
			// 
			// xEditGridCell205
			// 
			this.xEditGridCell205.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell205.CellName = "gubun_name";
			this.xEditGridCell205.Col = 4;
			this.xEditGridCell205.HeaderText = "保険種別";
			this.xEditGridCell205.IsUpdatable = false;
			this.xEditGridCell205.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell205.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell206
			// 
			this.xEditGridCell206.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell206.CellName = "chojae";
			this.xEditGridCell206.Col = 5;
			this.xEditGridCell206.HeaderText = "初再診";
			this.xEditGridCell206.IsUpdatable = false;
			this.xEditGridCell206.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell206.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell240
			// 
			this.xEditGridCell240.CellName = "naewon_type";
			this.xEditGridCell240.Col = -1;
			this.xEditGridCell240.HeaderText = "naewon_type";
			this.xEditGridCell240.IsUpdatable = false;
			this.xEditGridCell240.IsVisible = false;
			this.xEditGridCell240.Row = -1;
			// 
			// xEditGridCell241
			// 
			this.xEditGridCell241.CellName = "jubsu_no";
			this.xEditGridCell241.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell241.Col = -1;
			this.xEditGridCell241.HeaderText = "jubsu_no";
			this.xEditGridCell241.IsUpdatable = false;
			this.xEditGridCell241.IsVisible = false;
			this.xEditGridCell241.Row = -1;
			// 
			// xEditGridCell242
			// 
			this.xEditGridCell242.CellName = "pk_order";
			this.xEditGridCell242.Col = -1;
			this.xEditGridCell242.HeaderText = "pk_order";
			this.xEditGridCell242.IsUpdatable = false;
			this.xEditGridCell242.IsVisible = false;
			this.xEditGridCell242.Row = -1;
			// 
			// xEditGridCell243
			// 
			this.xEditGridCell243.CellName = "input_gubun";
			this.xEditGridCell243.Col = -1;
			this.xEditGridCell243.HeaderText = "input_gubun";
			this.xEditGridCell243.IsUpdatable = false;
			this.xEditGridCell243.IsVisible = false;
			this.xEditGridCell243.Row = -1;
			// 
			// xEditGridCell244
			// 
			this.xEditGridCell244.CellName = "tel_yn";
			this.xEditGridCell244.Col = -1;
			this.xEditGridCell244.HeaderText = "tel_yn";
			this.xEditGridCell244.IsUpdatable = false;
			this.xEditGridCell244.IsVisible = false;
			this.xEditGridCell244.Row = -1;
			// 
			// xEditGridCell207
			// 
			this.xEditGridCell207.CellName = "order_gubun";
			this.xEditGridCell207.Col = -1;
			this.xEditGridCell207.HeaderText = "order_gubun";
			this.xEditGridCell207.IsUpdatable = false;
			this.xEditGridCell207.IsVisible = false;
			this.xEditGridCell207.Row = -1;
			// 
			// xEditGridCell245
			// 
			this.xEditGridCell245.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell245.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.xEditGridCell245.AlterateRowImageIndex = 0;
			this.xEditGridCell245.CellName = "select";
			this.xEditGridCell245.CellWidth = 34;
			this.xEditGridCell245.HeaderText = "選択";
			this.xEditGridCell245.ImageList = this.ImageList;
			this.xEditGridCell245.IsUpdatable = false;
			this.xEditGridCell245.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.xEditGridCell245.RowImageIndex = 0;
			this.xEditGridCell245.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell245.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell246
			// 
			this.xEditGridCell246.CellName = "other_gwa";
			this.xEditGridCell246.Col = -1;
			this.xEditGridCell246.HeaderText = "other_gwa";
			this.xEditGridCell246.IsUpdatable = false;
			this.xEditGridCell246.IsUpdCol = false;
			this.xEditGridCell246.IsVisible = false;
			this.xEditGridCell246.Row = -1;
			// 
			// grdOrdList
			// 
			this.grdOrdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
																				  this.xEditGridCell1,
																				  this.xEditGridCell5,
																				  this.xEditGridCell6,
																				  this.xEditGridCell226,
																				  this.xEditGridCell227,
																				  this.xEditGridCell228,
																				  this.xEditGridCell229,
																				  this.xEditGridCell9,
																				  this.xEditGridCell7,
																				  this.xEditGridCell8,
																				  this.xEditGridCell91,
																				  this.xEditGridCell225,
																				  this.xEditGridCell208,
																				  this.xEditGridCell95,
																				  this.xEditGridCell99});
			this.grdOrdList.ColPerLine = 5;
			this.grdOrdList.Cols = 6;
			this.grdOrdList.EnableMultiSelection = true;
			this.grdOrdList.FixedCols = 1;
			this.grdOrdList.FixedRows = 1;
			this.grdOrdList.HeaderHeights.Add(21);
			this.grdOrdList.ImageList = this.ImageList;
			this.grdOrdList.Location = new System.Drawing.Point(26, 72);
			this.grdOrdList.Name = "grdOrdList";
			this.grdOrdList.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
			this.grdOrdList.RowHeaderVisible = true;
			this.grdOrdList.Rows = 2;
			this.grdOrdList.RowStateCheckOnPaint = false;
			this.grdOrdList.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
			this.grdOrdList.Size = new System.Drawing.Size(210, 404);
			this.grdOrdList.TabIndex = 0;
			this.grdOrdList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOrdList_QueryEnd);
			this.grdOrdList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOrdList_RowFocusChanged);
			this.grdOrdList.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOrdList_GridColumnChanged);
			this.grdOrdList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrdList_QueryStarting);
			// 
			// xEditGridCell1
			// 
			this.xEditGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell1.CellName = "order_date";
			this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
			this.xEditGridCell1.CellWidth = 87;
			this.xEditGridCell1.Col = 2;
			this.xEditGridCell1.HeaderText = "オ―ダ日付";
			this.xEditGridCell1.IsUpdatable = false;
			this.xEditGridCell1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell5
			// 
			this.xEditGridCell5.CellName = "bunho";
			this.xEditGridCell5.Col = -1;
			this.xEditGridCell5.HeaderText = "bunho";
			this.xEditGridCell5.IsUpdatable = false;
			this.xEditGridCell5.IsVisible = false;
			this.xEditGridCell5.Row = -1;
			// 
			// xEditGridCell6
			// 
			this.xEditGridCell6.CellName = "fkinp1001";
			this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell6.Col = -1;
			this.xEditGridCell6.HeaderText = "fkinp1001";
			this.xEditGridCell6.IsUpdatable = false;
			this.xEditGridCell6.IsVisible = false;
			this.xEditGridCell6.Row = -1;
			// 
			// xEditGridCell226
			// 
			this.xEditGridCell226.CellName = "gwa";
			this.xEditGridCell226.Col = -1;
			this.xEditGridCell226.HeaderText = "gwa";
			this.xEditGridCell226.IsUpdatable = false;
			this.xEditGridCell226.IsVisible = false;
			this.xEditGridCell226.Row = -1;
			// 
			// xEditGridCell227
			// 
			this.xEditGridCell227.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell227.CellName = "gwa_name";
			this.xEditGridCell227.CellWidth = 51;
			this.xEditGridCell227.Col = 3;
			this.xEditGridCell227.HeaderText = "診療科";
			this.xEditGridCell227.IsUpdatable = false;
			this.xEditGridCell227.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell227.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell228
			// 
			this.xEditGridCell228.CellName = "doctor";
			this.xEditGridCell228.Col = -1;
			this.xEditGridCell228.HeaderText = "doctor";
			this.xEditGridCell228.IsUpdatable = false;
			this.xEditGridCell228.IsVisible = false;
			this.xEditGridCell228.Row = -1;
			// 
			// xEditGridCell229
			// 
			this.xEditGridCell229.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell229.CellName = "doctor_name";
			this.xEditGridCell229.CellWidth = 66;
			this.xEditGridCell229.Col = 4;
			this.xEditGridCell229.HeaderText = "診療医師";
			this.xEditGridCell229.IsUpdatable = false;
			this.xEditGridCell229.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell229.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell9
			// 
			this.xEditGridCell9.CellName = "input_gubun";
			this.xEditGridCell9.Col = -1;
			this.xEditGridCell9.HeaderText = "input_gubun";
			this.xEditGridCell9.IsUpdatable = false;
			this.xEditGridCell9.IsVisible = false;
			this.xEditGridCell9.Row = -1;
			// 
			// xEditGridCell7
			// 
			this.xEditGridCell7.CellName = "gijun_date";
			this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
			this.xEditGridCell7.Col = -1;
			this.xEditGridCell7.HeaderText = "gijun_date";
			this.xEditGridCell7.IsUpdatable = false;
			this.xEditGridCell7.IsVisible = false;
			this.xEditGridCell7.Row = -1;
			// 
			// xEditGridCell8
			// 
			this.xEditGridCell8.CellName = "pk_order";
			this.xEditGridCell8.Col = 5;
			this.xEditGridCell8.HeaderText = "pk_order";
			this.xEditGridCell8.IsUpdatable = false;
			// 
			// xEditGridCell91
			// 
			this.xEditGridCell91.CellName = "tel_yn";
			this.xEditGridCell91.Col = -1;
			this.xEditGridCell91.HeaderText = "tel_yn";
			this.xEditGridCell91.IsUpdatable = false;
			this.xEditGridCell91.IsVisible = false;
			this.xEditGridCell91.Row = -1;
			// 
			// xEditGridCell225
			// 
			this.xEditGridCell225.CellName = "toiwon_drg";
			this.xEditGridCell225.Col = -1;
			this.xEditGridCell225.HeaderText = "toiwon_drg";
			this.xEditGridCell225.IsUpdatable = false;
			this.xEditGridCell225.IsVisible = false;
			this.xEditGridCell225.Row = -1;
			// 
			// xEditGridCell208
			// 
			this.xEditGridCell208.CellName = "order_gubun";
			this.xEditGridCell208.Col = -1;
			this.xEditGridCell208.HeaderText = "order_gubun";
			this.xEditGridCell208.IsUpdatable = false;
			this.xEditGridCell208.IsVisible = false;
			this.xEditGridCell208.Row = -1;
			// 
			// xEditGridCell95
			// 
			this.xEditGridCell95.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell95.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.xEditGridCell95.AlterateRowImageIndex = 0;
			this.xEditGridCell95.CellName = "select";
			this.xEditGridCell95.CellWidth = 34;
			this.xEditGridCell95.Col = 1;
			this.xEditGridCell95.HeaderText = "選択";
			this.xEditGridCell95.ImageList = this.ImageList;
			this.xEditGridCell95.IsUpdatable = false;
			this.xEditGridCell95.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.xEditGridCell95.RowImageIndex = 0;
			this.xEditGridCell95.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell95.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell99
			// 
			this.xEditGridCell99.CellName = "other_gwa";
			this.xEditGridCell99.Col = -1;
			this.xEditGridCell99.HeaderText = "other_gwa";
			this.xEditGridCell99.IsUpdatable = false;
			this.xEditGridCell99.IsUpdCol = false;
			this.xEditGridCell99.IsVisible = false;
			this.xEditGridCell99.Row = -1;
			// 
			// tabOrderGubun
			// 
			this.tabOrderGubun.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabOrderGubun.IDEPixelArea = true;
			this.tabOrderGubun.IDEPixelBorder = false;
			this.tabOrderGubun.ImageList = this.ImageList;
			this.tabOrderGubun.Location = new System.Drawing.Point(0, 28);
			this.tabOrderGubun.Name = "tabOrderGubun";
			this.tabOrderGubun.SelectedIndex = 0;
			this.tabOrderGubun.SelectedTab = this.tabPage1;
			this.tabOrderGubun.ShowClose = false;
			this.tabOrderGubun.Size = new System.Drawing.Size(258, 24);
			this.tabOrderGubun.TabIndex = 32;
			this.tabOrderGubun.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
																						 this.tabPage1,
																						 this.tabPage2,
																						 this.tabPage3,
																						 this.tabPage4,
																						 this.tabPage5,
																						 this.tabPage6,
																						 this.tabPage7,
																						 this.tabPage8});
			this.tabOrderGubun.SelectionChanged += new System.EventHandler(this.tabOrderGubun_SelectionChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.ImageIndex = 1;
			this.tabPage1.ImageList = this.ImageList;
			this.tabPage1.Location = new System.Drawing.Point(0, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(258, 0);
			this.tabPage1.TabIndex = 3;
			this.tabPage1.Tag = "%";
			this.tabPage1.Title = " 全体";
			// 
			// tabPage2
			// 
			this.tabPage2.ImageIndex = 0;
			this.tabPage2.ImageList = this.ImageList;
			this.tabPage2.Location = new System.Drawing.Point(0, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Selected = false;
			this.tabPage2.Size = new System.Drawing.Size(258, -1);
			this.tabPage2.TabIndex = 4;
			this.tabPage2.Tag = "1";
			this.tabPage2.Title = "内服";
			this.tabPage2.Visible = false;
			// 
			// tabPage3
			// 
			this.tabPage3.ImageIndex = 0;
			this.tabPage3.ImageList = this.ImageList;
			this.tabPage3.Location = new System.Drawing.Point(0, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Selected = false;
			this.tabPage3.Size = new System.Drawing.Size(258, -1);
			this.tabPage3.TabIndex = 5;
			this.tabPage3.Tag = "2";
			this.tabPage3.Title = "外用";
			this.tabPage3.Visible = false;
			// 
			// tabPage4
			// 
			this.tabPage4.ImageIndex = 0;
			this.tabPage4.ImageList = this.ImageList;
			this.tabPage4.Location = new System.Drawing.Point(0, 25);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Selected = false;
			this.tabPage4.Size = new System.Drawing.Size(258, -1);
			this.tabPage4.TabIndex = 6;
			this.tabPage4.Tag = "3";
			this.tabPage4.Title = " 注射";
			this.tabPage4.Visible = false;
			// 
			// tabPage5
			// 
			this.tabPage5.ImageIndex = 0;
			this.tabPage5.ImageList = this.ImageList;
			this.tabPage5.Location = new System.Drawing.Point(0, 25);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Selected = false;
			this.tabPage5.Size = new System.Drawing.Size(258, -1);
			this.tabPage5.TabIndex = 7;
			this.tabPage5.Tag = "4";
			this.tabPage5.Title = "検査";
			// 
			// tabPage6
			// 
			this.tabPage6.ImageIndex = 0;
			this.tabPage6.ImageList = this.ImageList;
			this.tabPage6.Location = new System.Drawing.Point(0, 25);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Selected = false;
			this.tabPage6.Size = new System.Drawing.Size(258, -1);
			this.tabPage6.TabIndex = 8;
			this.tabPage6.Tag = "5";
			this.tabPage6.Title = "画像診断";
			// 
			// tabPage7
			// 
			this.tabPage7.ImageIndex = 0;
			this.tabPage7.ImageList = this.ImageList;
			this.tabPage7.Location = new System.Drawing.Point(0, 25);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Selected = false;
			this.tabPage7.Size = new System.Drawing.Size(258, -1);
			this.tabPage7.TabIndex = 9;
			this.tabPage7.Tag = "6";
			this.tabPage7.Title = "処置";
			// 
			// tabPage8
			// 
			this.tabPage8.ImageIndex = 0;
			this.tabPage8.ImageList = this.ImageList;
			this.tabPage8.Location = new System.Drawing.Point(0, 25);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Selected = false;
			this.tabPage8.Size = new System.Drawing.Size(258, -1);
			this.tabPage8.TabIndex = 10;
			this.tabPage8.Tag = "7";
			this.tabPage8.Title = "手術";
			// 
			// xPanel4
			// 
			this.xPanel4.Controls.Add(this.rbtIn);
			this.xPanel4.Controls.Add(this.rbtOut);
			this.xPanel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.xPanel4.Location = new System.Drawing.Point(0, 0);
			this.xPanel4.Name = "xPanel4";
			this.xPanel4.Size = new System.Drawing.Size(258, 28);
			this.xPanel4.TabIndex = 30;
			// 
			// rbtIn
			// 
			this.rbtIn.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtIn.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.rbtIn.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtIn.Checked = true;
			this.rbtIn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.rbtIn.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rbtIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.rbtIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.rbtIn.ImageIndex = 1;
			this.rbtIn.ImageList = this.ImageList;
			this.rbtIn.Location = new System.Drawing.Point(2, 1);
			this.rbtIn.Name = "rbtIn";
			this.rbtIn.Size = new System.Drawing.Size(128, 27);
			this.rbtIn.TabIndex = 28;
			this.rbtIn.TabStop = true;
			this.rbtIn.Text = "入院";
			this.rbtIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtIn.CheckedChanged += new System.EventHandler(this.rbtIn_CheckedChanged);
			// 
			// rbtOut
			// 
			this.rbtOut.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbtOut.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.rbtOut.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbtOut.Cursor = System.Windows.Forms.Cursors.Hand;
			this.rbtOut.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rbtOut.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.rbtOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.rbtOut.ImageIndex = 0;
			this.rbtOut.ImageList = this.ImageList;
			this.rbtOut.Location = new System.Drawing.Point(130, 1);
			this.rbtOut.Name = "rbtOut";
			this.rbtOut.Size = new System.Drawing.Size(128, 27);
			this.rbtOut.TabIndex = 29;
			this.rbtOut.Text = "外来";
			this.rbtOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnlInput_gubun
			// 
			this.pnlInput_gubun.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.pnlInput_gubun.Controls.Add(this.rbt);
			this.pnlInput_gubun.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlInput_gubun.Location = new System.Drawing.Point(0, 0);
			this.pnlInput_gubun.Name = "pnlInput_gubun";
			this.pnlInput_gubun.Size = new System.Drawing.Size(624, 28);
			this.pnlInput_gubun.TabIndex = 3;
			// 
			// rbt
			// 
			this.rbt.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbt.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
			this.rbt.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
			this.rbt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.rbt.ImageIndex = 0;
			this.rbt.ImageList = this.ImageList;
			this.rbt.Location = new System.Drawing.Point(2, 2);
			this.rbt.Name = "rbt";
			this.rbt.Size = new System.Drawing.Size(112, 26);
			this.rbt.TabIndex = 11;
			// 
			// pnlIn
			// 
			this.pnlIn.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.pnlIn.Controls.Add(this.pnlOrder);
			this.pnlIn.Controls.Add(this.pnlJisi);
			this.pnlIn.Controls.Add(this.pnlInput_gubun);
			this.pnlIn.Location = new System.Drawing.Point(314, 22);
			this.pnlIn.Name = "pnlIn";
			this.pnlIn.Size = new System.Drawing.Size(624, 490);
			this.pnlIn.TabIndex = 4;
			// 
			// pnlOrder
			// 
			this.pnlOrder.Controls.Add(this.grdOCS2003);
			this.pnlOrder.Controls.Add(this.lblSelectOrder);
			this.pnlOrder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlOrder.Location = new System.Drawing.Point(0, 28);
			this.pnlOrder.Name = "pnlOrder";
			this.pnlOrder.Size = new System.Drawing.Size(624, 462);
			this.pnlOrder.TabIndex = 21;
			// 
			// grdOCS2003
			// 
			this.grdOCS2003.AddedHeaderLine = 1;
			this.grdOCS2003.ApplyPaintEventToAllColumn = true;
			this.grdOCS2003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
																				  this.xEditGridCell52,
																				  this.xEditGridCell209,
																				  this.xEditGridCell210,
																				  this.xEditGridCell211,
																				  this.xEditGridCell217,
																				  this.xEditGridCell222,
																				  this.xEditGridCell223,
																				  this.xEditGridCell224,
																				  this.xEditGridCell54,
																				  this.xEditGridCell47,
																				  this.xEditGridCell2,
																				  this.xEditGridCell42,
																				  this.xEditGridCell53,
																				  this.xEditGridCell48,
																				  this.xEditGridCell19,
																				  this.xEditGridCell102,
																				  this.xEditGridCell20,
																				  this.xEditGridCell21,
																				  this.xEditGridCell83,
																				  this.xEditGridCell22,
																				  this.xEditGridCell23,
																				  this.xEditGridCell84,
																				  this.xEditGridCell24,
																				  this.xEditGridCell25,
																				  this.xEditGridCell26,
																				  this.xEditGridCell27,
																				  this.xEditGridCell85,
																				  this.xEditGridCell28,
																				  this.xEditGridCell86,
																				  this.xEditGridCell29,
																				  this.xEditGridCell30,
																				  this.xEditGridCell31,
																				  this.xEditGridCell32,
																				  this.xEditGridCell33,
																				  this.xEditGridCell34,
																				  this.xEditGridCell35,
																				  this.xEditGridCell36,
																				  this.xEditGridCell37,
																				  this.xEditGridCell38,
																				  this.xEditGridCell39,
																				  this.xEditGridCell40,
																				  this.xEditGridCell41,
																				  this.xEditGridCell43,
																				  this.xEditGridCell44,
																				  this.xEditGridCell45,
																				  this.xEditGridCell46,
																				  this.xEditGridCell55,
																				  this.xEditGridCell59,
																				  this.xEditGridCell60,
																				  this.xEditGridCell61,
																				  this.xEditGridCell64,
																				  this.xEditGridCell65,
																				  this.xEditGridCell66,
																				  this.xEditGridCell67,
																				  this.xEditGridCell90,
																				  this.xEditGridCell94,
																				  this.xEditGridCell3,
																				  this.xEditGridCell68,
																				  this.xEditGridCell215,
																				  this.xEditGridCell69,
																				  this.xEditGridCell74,
																				  this.xEditGridCell71,
																				  this.xEditGridCell72,
																				  this.xEditGridCell73,
																				  this.xEditGridCell87,
																				  this.xEditGridCell88,
																				  this.xEditGridCell81,
																				  this.xEditGridCell82,
																				  this.xEditGridCell92,
																				  this.xEditGridCell93,
																				  this.xEditGridCell96,
																				  this.xEditGridCell89,
																				  this.xEditGridCell230,
																				  this.xEditGridCell97});
			this.grdOCS2003.ColPerLine = 22;
			this.grdOCS2003.ColResizable = true;
			this.grdOCS2003.Cols = 23;
			this.grdOCS2003.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdOCS2003.EnableMultiSelection = true;
			this.grdOCS2003.FixedCols = 1;
			this.grdOCS2003.FixedRows = 2;
			this.grdOCS2003.HeaderHeights.Add(29);
			this.grdOCS2003.HeaderHeights.Add(0);
			this.grdOCS2003.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
																					  this.xGridHeader1});
			this.grdOCS2003.Location = new System.Drawing.Point(0, 24);
			this.grdOCS2003.MasterLayout = this.grdOrdList;
			this.grdOCS2003.Name = "grdOCS2003";
			this.grdOCS2003.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
			this.grdOCS2003.RowHeaderVisible = true;
			this.grdOCS2003.Rows = 3;
			this.grdOCS2003.RowStateCheckOnPaint = false;
			this.grdOCS2003.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
			this.grdOCS2003.Size = new System.Drawing.Size(624, 438);
			this.grdOCS2003.TabIndex = 0;
			this.grdOCS2003.ToolTipActive = true;
			this.grdOCS2003.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS2003_RowFocusChanged);
			this.grdOCS2003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS2003_MouseDown);
			this.grdOCS2003.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS2003_QueryEnd);
			this.grdOCS2003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS2003_QueryStarting);
			this.grdOCS2003.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS2003_GridCellPainting);
			// 
			// xEditGridCell52
			// 
			this.xEditGridCell52.CellName = "pk_order";
			this.xEditGridCell52.Col = 22;
			this.xEditGridCell52.HeaderText = "pk_order";
			this.xEditGridCell52.IsUpdatable = false;
			this.xEditGridCell52.Row = 1;
			// 
			// xEditGridCell209
			// 
			this.xEditGridCell209.CellName = "pk_order_1";
			this.xEditGridCell209.Col = -1;
			this.xEditGridCell209.HeaderText = "pk_order_1";
			this.xEditGridCell209.IsUpdatable = false;
			this.xEditGridCell209.IsVisible = false;
			this.xEditGridCell209.Row = -1;
			// 
			// xEditGridCell210
			// 
			this.xEditGridCell210.CellName = "pk_order_2";
			this.xEditGridCell210.Col = -1;
			this.xEditGridCell210.HeaderText = "pk_order_2";
			this.xEditGridCell210.IsUpdatable = false;
			this.xEditGridCell210.IsVisible = false;
			this.xEditGridCell210.Row = -1;
			// 
			// xEditGridCell211
			// 
			this.xEditGridCell211.CellName = "pk_order_3";
			this.xEditGridCell211.Col = -1;
			this.xEditGridCell211.HeaderText = "pk_order_3";
			this.xEditGridCell211.IsUpdatable = false;
			this.xEditGridCell211.IsVisible = false;
			this.xEditGridCell211.Row = -1;
			// 
			// xEditGridCell217
			// 
			this.xEditGridCell217.CellName = "pk_order_4";
			this.xEditGridCell217.Col = -1;
			this.xEditGridCell217.HeaderText = "pk_order_4";
			this.xEditGridCell217.IsUpdatable = false;
			this.xEditGridCell217.IsVisible = false;
			this.xEditGridCell217.Row = -1;
			// 
			// xEditGridCell222
			// 
			this.xEditGridCell222.CellName = "pk_order_5";
			this.xEditGridCell222.Col = -1;
			this.xEditGridCell222.HeaderText = "pk_order_5";
			this.xEditGridCell222.IsUpdatable = false;
			this.xEditGridCell222.IsVisible = false;
			this.xEditGridCell222.Row = -1;
			// 
			// xEditGridCell223
			// 
			this.xEditGridCell223.CellName = "pk_order_6";
			this.xEditGridCell223.Col = -1;
			this.xEditGridCell223.HeaderText = "pk_order_6";
			this.xEditGridCell223.IsUpdatable = false;
			this.xEditGridCell223.IsVisible = false;
			this.xEditGridCell223.Row = -1;
			// 
			// xEditGridCell224
			// 
			this.xEditGridCell224.CellName = "pk_order_7";
			this.xEditGridCell224.Col = -1;
			this.xEditGridCell224.HeaderText = "pk_order_7";
			this.xEditGridCell224.IsUpdatable = false;
			this.xEditGridCell224.IsVisible = false;
			this.xEditGridCell224.Row = -1;
			// 
			// xEditGridCell54
			// 
			this.xEditGridCell54.CellName = "pkocs2003";
			this.xEditGridCell54.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell54.Col = -1;
			this.xEditGridCell54.HeaderText = "pkocs2003";
			this.xEditGridCell54.IsUpdatable = false;
			this.xEditGridCell54.IsVisible = false;
			this.xEditGridCell54.Row = -1;
			// 
			// xEditGridCell47
			// 
			this.xEditGridCell47.CellName = "bunho";
			this.xEditGridCell47.Col = -1;
			this.xEditGridCell47.HeaderText = "bunho";
			this.xEditGridCell47.IsUpdatable = false;
			this.xEditGridCell47.IsVisible = false;
			this.xEditGridCell47.Row = -1;
			// 
			// xEditGridCell2
			// 
			this.xEditGridCell2.CellName = "fkinp1001";
			this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell2.Col = -1;
			this.xEditGridCell2.HeaderText = "fkinp1001";
			this.xEditGridCell2.IsUpdatable = false;
			this.xEditGridCell2.IsVisible = false;
			this.xEditGridCell2.Row = -1;
			// 
			// xEditGridCell42
			// 
			this.xEditGridCell42.CellName = "input_gubun";
			this.xEditGridCell42.Col = -1;
			this.xEditGridCell42.HeaderText = "input_gubun";
			this.xEditGridCell42.IsUpdatable = false;
			this.xEditGridCell42.IsVisible = false;
			this.xEditGridCell42.Row = -1;
			// 
			// xEditGridCell53
			// 
			this.xEditGridCell53.CellName = "seq";
			this.xEditGridCell53.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell53.Col = -1;
			this.xEditGridCell53.HeaderText = "seq";
			this.xEditGridCell53.IsUpdatable = false;
			this.xEditGridCell53.IsVisible = false;
			this.xEditGridCell53.Row = -1;
			// 
			// xEditGridCell48
			// 
			this.xEditGridCell48.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell48.CellName = "order_date";
			this.xEditGridCell48.CellType = IHIS.Framework.XCellDataType.Date;
			this.xEditGridCell48.Col = 2;
			this.xEditGridCell48.HeaderText = "オ―ダ日付";
			this.xEditGridCell48.IsUpdatable = false;
			this.xEditGridCell48.RowSpan = 2;
			this.xEditGridCell48.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell48.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell19
			// 
			this.xEditGridCell19.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell19.CellName = "group_ser";
			this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell19.CellWidth = 21;
			this.xEditGridCell19.Col = 4;
			this.xEditGridCell19.HeaderText = "G\r\nR";
			this.xEditGridCell19.IsUpdatable = false;
			this.xEditGridCell19.RowSpan = 2;
			this.xEditGridCell19.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell19.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell102
			// 
			this.xEditGridCell102.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell102.CellName = "order_gubun_name";
			this.xEditGridCell102.CellWidth = 64;
			this.xEditGridCell102.Col = 3;
			this.xEditGridCell102.HeaderText = "オ―ダ\r\n区分";
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
			this.xEditGridCell20.CellWidth = 74;
			this.xEditGridCell20.Col = 6;
			this.xEditGridCell20.HeaderText = "オ―ダコード";
			this.xEditGridCell20.IsUpdatable = false;
			this.xEditGridCell20.RowSpan = 2;
			this.xEditGridCell20.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell20.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell21
			// 
			this.xEditGridCell21.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell21.CellName = "hangmog_name";
			this.xEditGridCell21.CellWidth = 191;
			this.xEditGridCell21.Col = 7;
			this.xEditGridCell21.HeaderText = "オ―ダ名";
			this.xEditGridCell21.IsUpdatable = false;
			this.xEditGridCell21.RowSpan = 2;
			this.xEditGridCell21.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell21.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell83
			// 
			this.xEditGridCell83.CellName = "specimen_code";
			this.xEditGridCell83.Col = -1;
			this.xEditGridCell83.HeaderText = "specimen_code";
			this.xEditGridCell83.IsUpdatable = false;
			this.xEditGridCell83.IsVisible = false;
			this.xEditGridCell83.Row = -1;
			// 
			// xEditGridCell22
			// 
			this.xEditGridCell22.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell22.CellName = "specimen_name";
			this.xEditGridCell22.CellWidth = 33;
			this.xEditGridCell22.Col = 8;
			this.xEditGridCell22.HeaderText = "検体";
			this.xEditGridCell22.IsUpdatable = false;
			this.xEditGridCell22.RowSpan = 2;
			this.xEditGridCell22.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell22.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell23
			// 
			this.xEditGridCell23.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell23.CellName = "suryang";
			this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Decimal;
			this.xEditGridCell23.CellWidth = 46;
			this.xEditGridCell23.Col = 9;
			this.xEditGridCell23.DecimalDigits = 2;
			this.xEditGridCell23.HeaderText = "数量";
			this.xEditGridCell23.IsUpdatable = false;
			this.xEditGridCell23.RowSpan = 2;
			this.xEditGridCell23.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell23.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell84
			// 
			this.xEditGridCell84.CellName = "ord_danui";
			this.xEditGridCell84.Col = -1;
			this.xEditGridCell84.HeaderText = "ord_danui";
			this.xEditGridCell84.IsUpdatable = false;
			this.xEditGridCell84.IsVisible = false;
			this.xEditGridCell84.Row = -1;
			// 
			// xEditGridCell24
			// 
			this.xEditGridCell24.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell24.CellName = "ord_danui_name";
			this.xEditGridCell24.CellWidth = 69;
			this.xEditGridCell24.Col = 10;
			this.xEditGridCell24.HeaderText = "単位";
			this.xEditGridCell24.IsUpdatable = false;
			this.xEditGridCell24.RowSpan = 2;
			this.xEditGridCell24.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell24.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell25
			// 
			this.xEditGridCell25.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell25.CellName = "dv_time";
			this.xEditGridCell25.CellWidth = 24;
			this.xEditGridCell25.Col = 11;
			this.xEditGridCell25.HeaderText = "dv_time";
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
			this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell26.CellWidth = 30;
			this.xEditGridCell26.Col = 12;
			this.xEditGridCell26.HeaderText = "dv";
			this.xEditGridCell26.IsUpdatable = false;
			this.xEditGridCell26.Row = 1;
			this.xEditGridCell26.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell26.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell27
			// 
			this.xEditGridCell27.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell27.CellName = "nalsu";
			this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell27.CellWidth = 34;
			this.xEditGridCell27.Col = 13;
			this.xEditGridCell27.HeaderText = "日数";
			this.xEditGridCell27.IsUpdatable = false;
			this.xEditGridCell27.RowSpan = 2;
			this.xEditGridCell27.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell27.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell85
			// 
			this.xEditGridCell85.CellName = "jusa";
			this.xEditGridCell85.Col = -1;
			this.xEditGridCell85.HeaderText = "jusa";
			this.xEditGridCell85.IsUpdatable = false;
			this.xEditGridCell85.IsVisible = false;
			this.xEditGridCell85.Row = -1;
			// 
			// xEditGridCell28
			// 
			this.xEditGridCell28.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell28.CellName = "jusa_name";
			this.xEditGridCell28.CellWidth = 34;
			this.xEditGridCell28.Col = 14;
			this.xEditGridCell28.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
			this.xEditGridCell28.HeaderText = "注射";
			this.xEditGridCell28.IsUpdatable = false;
			this.xEditGridCell28.RowSpan = 2;
			this.xEditGridCell28.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell28.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell86
			// 
			this.xEditGridCell86.CellName = "bogyong_code";
			this.xEditGridCell86.Col = -1;
			this.xEditGridCell86.HeaderText = "bogyong_code";
			this.xEditGridCell86.IsUpdatable = false;
			this.xEditGridCell86.IsVisible = false;
			this.xEditGridCell86.Row = -1;
			// 
			// xEditGridCell29
			// 
			this.xEditGridCell29.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell29.CellName = "bogyong_name";
			this.xEditGridCell29.CellWidth = 69;
			this.xEditGridCell29.Col = 15;
			this.xEditGridCell29.HeaderText = "用法";
			this.xEditGridCell29.IsUpdatable = false;
			this.xEditGridCell29.RowSpan = 2;
			this.xEditGridCell29.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell29.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell30
			// 
			this.xEditGridCell30.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell30.CellName = "wonyoi_order_yn";
			this.xEditGridCell30.CellWidth = 22;
			this.xEditGridCell30.Col = 16;
			this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
			this.xEditGridCell30.HeaderText = "院\r\n外";
			this.xEditGridCell30.IsUpdatable = false;
			this.xEditGridCell30.RowSpan = 2;
			this.xEditGridCell30.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell30.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell31
			// 
			this.xEditGridCell31.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell31.CellName = "wonnae_sayu_code";
			this.xEditGridCell31.CellWidth = 61;
			this.xEditGridCell31.Col = -1;
			this.xEditGridCell31.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xEditGridCell31.HeaderText = "院内事由";
			this.xEditGridCell31.IsUpdatable = false;
			this.xEditGridCell31.IsVisible = false;
			this.xEditGridCell31.Row = -1;
			this.xEditGridCell31.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell31.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell32
			// 
			this.xEditGridCell32.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell32.CellName = "emergency";
			this.xEditGridCell32.CellWidth = 21;
			this.xEditGridCell32.Col = 17;
			this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
			this.xEditGridCell32.HeaderText = "緊\r\n急";
			this.xEditGridCell32.IsUpdatable = false;
			this.xEditGridCell32.RowSpan = 2;
			this.xEditGridCell32.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell32.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell33
			// 
			this.xEditGridCell33.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell33.CellName = "pay";
			this.xEditGridCell33.CellWidth = 36;
			this.xEditGridCell33.Col = 20;
			this.xEditGridCell33.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
			this.xEditGridCell33.HeaderText = "請求\r\n区分";
			this.xEditGridCell33.IsUpdatable = false;
			this.xEditGridCell33.RowSpan = 2;
			this.xEditGridCell33.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell33.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			this.xEditGridCell33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xEditGridCell34
			// 
			this.xEditGridCell34.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell34.CellName = "fluid_yn";
			this.xEditGridCell34.CellWidth = 32;
			this.xEditGridCell34.Col = -1;
			this.xEditGridCell34.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xEditGridCell34.HeaderText = "輸液";
			this.xEditGridCell34.IsUpdatable = false;
			this.xEditGridCell34.IsVisible = false;
			this.xEditGridCell34.Row = -1;
			this.xEditGridCell34.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell34.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell35
			// 
			this.xEditGridCell35.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell35.CellName = "tpn_yn";
			this.xEditGridCell35.CellWidth = 33;
			this.xEditGridCell35.Col = -1;
			this.xEditGridCell35.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xEditGridCell35.HeaderText = "TPN";
			this.xEditGridCell35.IsUpdatable = false;
			this.xEditGridCell35.IsVisible = false;
			this.xEditGridCell35.Row = -1;
			this.xEditGridCell35.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell35.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell36
			// 
			this.xEditGridCell36.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell36.CellName = "anti_cancer_yn";
			this.xEditGridCell36.CellWidth = 45;
			this.xEditGridCell36.Col = -1;
			this.xEditGridCell36.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xEditGridCell36.HeaderText = "抗癌剤";
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
			this.xEditGridCell37.HeaderText = "muhyo";
			this.xEditGridCell37.IsUpdatable = false;
			this.xEditGridCell37.IsVisible = false;
			this.xEditGridCell37.Row = -1;
			// 
			// xEditGridCell38
			// 
			this.xEditGridCell38.CellName = "portable_yn";
			this.xEditGridCell38.Col = -1;
			this.xEditGridCell38.HeaderText = "portable_yn";
			this.xEditGridCell38.IsUpdatable = false;
			this.xEditGridCell38.IsVisible = false;
			this.xEditGridCell38.Row = -1;
			// 
			// xEditGridCell39
			// 
			this.xEditGridCell39.CellName = "symya";
			this.xEditGridCell39.Col = -1;
			this.xEditGridCell39.HeaderText = "symya";
			this.xEditGridCell39.IsUpdatable = false;
			this.xEditGridCell39.IsVisible = false;
			this.xEditGridCell39.Row = -1;
			// 
			// xEditGridCell40
			// 
			this.xEditGridCell40.CellName = "ocs_flag";
			this.xEditGridCell40.Col = -1;
			this.xEditGridCell40.HeaderText = "ocs_flag";
			this.xEditGridCell40.IsUpdatable = false;
			this.xEditGridCell40.IsVisible = false;
			this.xEditGridCell40.Row = -1;
			// 
			// xEditGridCell41
			// 
			this.xEditGridCell41.CellName = "order_gubun";
			this.xEditGridCell41.Col = -1;
			this.xEditGridCell41.HeaderText = "order_gubun";
			this.xEditGridCell41.IsUpdatable = false;
			this.xEditGridCell41.IsVisible = false;
			this.xEditGridCell41.Row = -1;
			// 
			// xEditGridCell43
			// 
			this.xEditGridCell43.CellName = "jaeryo_jundal_yn";
			this.xEditGridCell43.Col = -1;
			this.xEditGridCell43.HeaderText = "jaeryo_jundal_yn";
			this.xEditGridCell43.IsUpdatable = false;
			this.xEditGridCell43.IsVisible = false;
			this.xEditGridCell43.Row = -1;
			// 
			// xEditGridCell44
			// 
			this.xEditGridCell44.CellName = "jundal_table";
			this.xEditGridCell44.Col = -1;
			this.xEditGridCell44.HeaderText = "jundal_table";
			this.xEditGridCell44.IsUpdatable = false;
			this.xEditGridCell44.IsVisible = false;
			this.xEditGridCell44.Row = -1;
			// 
			// xEditGridCell45
			// 
			this.xEditGridCell45.CellName = "jundal_part";
			this.xEditGridCell45.Col = -1;
			this.xEditGridCell45.HeaderText = "jundal_part";
			this.xEditGridCell45.IsUpdatable = false;
			this.xEditGridCell45.IsVisible = false;
			this.xEditGridCell45.Row = -1;
			// 
			// xEditGridCell46
			// 
			this.xEditGridCell46.CellName = "move_part";
			this.xEditGridCell46.Col = -1;
			this.xEditGridCell46.HeaderText = "move_part";
			this.xEditGridCell46.IsUpdatable = false;
			this.xEditGridCell46.IsVisible = false;
			this.xEditGridCell46.Row = -1;
			// 
			// xEditGridCell55
			// 
			this.xEditGridCell55.CellName = "sub_susul";
			this.xEditGridCell55.Col = -1;
			this.xEditGridCell55.HeaderText = "sub_susul";
			this.xEditGridCell55.IsUpdatable = false;
			this.xEditGridCell55.IsVisible = false;
			this.xEditGridCell55.Row = -1;
			// 
			// xEditGridCell59
			// 
			this.xEditGridCell59.CellName = "amt";
			this.xEditGridCell59.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell59.Col = -1;
			this.xEditGridCell59.HeaderText = "amt";
			this.xEditGridCell59.IsUpdatable = false;
			this.xEditGridCell59.IsVisible = false;
			this.xEditGridCell59.Row = -1;
			// 
			// xEditGridCell60
			// 
			this.xEditGridCell60.CellName = "nalsu_sayu_code";
			this.xEditGridCell60.Col = -1;
			this.xEditGridCell60.HeaderText = "nalsu_sayu_code";
			this.xEditGridCell60.IsUpdatable = false;
			this.xEditGridCell60.IsVisible = false;
			this.xEditGridCell60.Row = -1;
			// 
			// xEditGridCell61
			// 
			this.xEditGridCell61.CellName = "physical_code";
			this.xEditGridCell61.Col = -1;
			this.xEditGridCell61.HeaderText = "physical_code";
			this.xEditGridCell61.IsUpdatable = false;
			this.xEditGridCell61.IsVisible = false;
			this.xEditGridCell61.Row = -1;
			// 
			// xEditGridCell64
			// 
			this.xEditGridCell64.CellName = "dv_1";
			this.xEditGridCell64.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell64.Col = -1;
			this.xEditGridCell64.HeaderText = "dv_1";
			this.xEditGridCell64.IsUpdatable = false;
			this.xEditGridCell64.IsVisible = false;
			this.xEditGridCell64.Row = -1;
			// 
			// xEditGridCell65
			// 
			this.xEditGridCell65.CellName = "dv_2";
			this.xEditGridCell65.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell65.Col = -1;
			this.xEditGridCell65.HeaderText = "dv_2";
			this.xEditGridCell65.IsUpdatable = false;
			this.xEditGridCell65.IsVisible = false;
			this.xEditGridCell65.Row = -1;
			// 
			// xEditGridCell66
			// 
			this.xEditGridCell66.CellName = "dv_3";
			this.xEditGridCell66.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell66.Col = -1;
			this.xEditGridCell66.HeaderText = "dv_3";
			this.xEditGridCell66.IsUpdatable = false;
			this.xEditGridCell66.IsVisible = false;
			this.xEditGridCell66.Row = -1;
			// 
			// xEditGridCell67
			// 
			this.xEditGridCell67.CellName = "dv_4";
			this.xEditGridCell67.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell67.Col = -1;
			this.xEditGridCell67.HeaderText = "dv_4";
			this.xEditGridCell67.IsUpdatable = false;
			this.xEditGridCell67.IsVisible = false;
			this.xEditGridCell67.Row = -1;
			// 
			// xEditGridCell90
			// 
			this.xEditGridCell90.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell90.CellName = "hope_date";
			this.xEditGridCell90.CellType = IHIS.Framework.XCellDataType.Date;
			this.xEditGridCell90.CellWidth = 96;
			this.xEditGridCell90.Col = 21;
			this.xEditGridCell90.HeaderText = "希望日";
			this.xEditGridCell90.IsUpdatable = false;
			this.xEditGridCell90.RowSpan = 2;
			this.xEditGridCell90.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell90.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell94
			// 
			this.xEditGridCell94.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell94.CellLen = 2000;
			this.xEditGridCell94.CellName = "order_remark";
			this.xEditGridCell94.Col = 18;
			this.xEditGridCell94.DisplayMemoText = true;
			this.xEditGridCell94.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
			this.xEditGridCell94.HeaderText = "Comment";
			this.xEditGridCell94.IsUpdatable = false;
			this.xEditGridCell94.RowSpan = 2;
			this.xEditGridCell94.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell94.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell3
			// 
			this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell3.CellLen = 2000;
			this.xEditGridCell3.CellName = "nurse_remark";
			this.xEditGridCell3.Col = 19;
			this.xEditGridCell3.DisplayMemoText = true;
			this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
			this.xEditGridCell3.HeaderText = "看護\r\nComment";
			this.xEditGridCell3.IsUpdatable = false;
			this.xEditGridCell3.RowSpan = 2;
			this.xEditGridCell3.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell3.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell68
			// 
			this.xEditGridCell68.CellName = "mix_group";
			this.xEditGridCell68.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell68.Col = -1;
			this.xEditGridCell68.HeaderText = "mix_group";
			this.xEditGridCell68.IsUpdatable = false;
			this.xEditGridCell68.IsVisible = false;
			this.xEditGridCell68.Row = -1;
			// 
			// xEditGridCell215
			// 
			this.xEditGridCell215.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell215.CellName = "regular_yn";
			this.xEditGridCell215.CellWidth = 24;
			this.xEditGridCell215.Col = 5;
			this.xEditGridCell215.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
			this.xEditGridCell215.HeaderText = "定\r\n時";
			this.xEditGridCell215.IsUpdatable = false;
			this.xEditGridCell215.RowSpan = 2;
			this.xEditGridCell215.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell215.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell69
			// 
			this.xEditGridCell69.CellName = "slip_code";
			this.xEditGridCell69.Col = -1;
			this.xEditGridCell69.HeaderText = "slip_code";
			this.xEditGridCell69.IsUpdatable = false;
			this.xEditGridCell69.IsVisible = false;
			this.xEditGridCell69.Row = -1;
			// 
			// xEditGridCell74
			// 
			this.xEditGridCell74.CellName = "group_yn";
			this.xEditGridCell74.Col = -1;
			this.xEditGridCell74.HeaderText = "group_yn";
			this.xEditGridCell74.IsUpdatable = false;
			this.xEditGridCell74.IsVisible = false;
			this.xEditGridCell74.Row = -1;
			// 
			// xEditGridCell71
			// 
			this.xEditGridCell71.CellName = "sg_code";
			this.xEditGridCell71.Col = -1;
			this.xEditGridCell71.HeaderText = "sg_code";
			this.xEditGridCell71.IsUpdatable = false;
			this.xEditGridCell71.IsVisible = false;
			this.xEditGridCell71.Row = -1;
			// 
			// xEditGridCell72
			// 
			this.xEditGridCell72.CellName = "order_gubun_bas";
			this.xEditGridCell72.Col = -1;
			this.xEditGridCell72.HeaderText = "order_gubun_bas";
			this.xEditGridCell72.IsUpdatable = false;
			this.xEditGridCell72.IsVisible = false;
			this.xEditGridCell72.Row = -1;
			// 
			// xEditGridCell73
			// 
			this.xEditGridCell73.CellName = "input_control";
			this.xEditGridCell73.Col = -1;
			this.xEditGridCell73.HeaderText = "input_control";
			this.xEditGridCell73.IsUpdatable = false;
			this.xEditGridCell73.IsVisible = false;
			this.xEditGridCell73.Row = -1;
			// 
			// xEditGridCell87
			// 
			this.xEditGridCell87.CellName = "bulyong_check";
			this.xEditGridCell87.Col = -1;
			this.xEditGridCell87.HeaderText = "bulyong_check";
			this.xEditGridCell87.IsUpdatable = false;
			this.xEditGridCell87.IsVisible = false;
			this.xEditGridCell87.Row = -1;
			// 
			// xEditGridCell88
			// 
			this.xEditGridCell88.CellName = "input_gubun_name";
			this.xEditGridCell88.Col = -1;
			this.xEditGridCell88.HeaderText = "input_gubun_name";
			this.xEditGridCell88.IsUpdatable = false;
			this.xEditGridCell88.IsVisible = false;
			this.xEditGridCell88.Row = -1;
			// 
			// xEditGridCell81
			// 
			this.xEditGridCell81.CellName = "ord_danui_check";
			this.xEditGridCell81.Col = -1;
			this.xEditGridCell81.HeaderText = "ord_danui_check";
			this.xEditGridCell81.IsUpdatable = false;
			this.xEditGridCell81.IsVisible = false;
			this.xEditGridCell81.Row = -1;
			// 
			// xEditGridCell82
			// 
			this.xEditGridCell82.CellName = "ord_danui_bas";
			this.xEditGridCell82.Col = -1;
			this.xEditGridCell82.HeaderText = "ord_danui_bas";
			this.xEditGridCell82.IsUpdatable = false;
			this.xEditGridCell82.IsVisible = false;
			this.xEditGridCell82.Row = -1;
			// 
			// xEditGridCell92
			// 
			this.xEditGridCell92.CellName = "bun_code";
			this.xEditGridCell92.Col = -1;
			this.xEditGridCell92.HeaderText = "bun_code";
			this.xEditGridCell92.IsUpdatable = false;
			this.xEditGridCell92.IsVisible = false;
			this.xEditGridCell92.Row = -1;
			// 
			// xEditGridCell93
			// 
			this.xEditGridCell93.CellName = "sg_gesan";
			this.xEditGridCell93.Col = -1;
			this.xEditGridCell93.HeaderText = "sg_gesan";
			this.xEditGridCell93.IsUpdatable = false;
			this.xEditGridCell93.IsVisible = false;
			this.xEditGridCell93.Row = -1;
			// 
			// xEditGridCell96
			// 
			this.xEditGridCell96.CellName = "other_gwa";
			this.xEditGridCell96.Col = -1;
			this.xEditGridCell96.HeaderText = "other_gwa";
			this.xEditGridCell96.IsUpdatable = false;
			this.xEditGridCell96.IsVisible = false;
			this.xEditGridCell96.Row = -1;
			// 
			// xEditGridCell89
			// 
			this.xEditGridCell89.CellName = "data_control";
			this.xEditGridCell89.Col = -1;
			this.xEditGridCell89.HeaderText = "data_control";
			this.xEditGridCell89.IsUpdatable = false;
			this.xEditGridCell89.IsVisible = false;
			this.xEditGridCell89.Row = -1;
			// 
			// xEditGridCell97
			// 
			this.xEditGridCell97.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell97.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.xEditGridCell97.AlterateRowImageIndex = 0;
			this.xEditGridCell97.CellName = "select";
			this.xEditGridCell97.CellWidth = 36;
			this.xEditGridCell97.Col = 1;
			this.xEditGridCell97.HeaderText = "選択";
			this.xEditGridCell97.ImageList = this.ImageList;
			this.xEditGridCell97.IsUpdatable = false;
			this.xEditGridCell97.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.xEditGridCell97.RowImageIndex = 0;
			this.xEditGridCell97.RowSpan = 2;
			this.xEditGridCell97.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell97.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xGridHeader1
			// 
			this.xGridHeader1.Col = 11;
			this.xGridHeader1.ColSpan = 2;
			this.xGridHeader1.HeaderText = "回数";
			this.xGridHeader1.HeaderWidth = 24;
			this.xGridHeader1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xGridHeader1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// lblSelectOrder
			// 
			this.lblSelectOrder.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
			this.lblSelectOrder.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblSelectOrder.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblSelectOrder.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
			this.lblSelectOrder.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
			this.lblSelectOrder.Image = ((System.Drawing.Image)(resources.GetObject("lblSelectOrder.Image")));
			this.lblSelectOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblSelectOrder.ImageIndex = 0;
			this.lblSelectOrder.ImageList = this.ImageList;
			this.lblSelectOrder.Location = new System.Drawing.Point(0, 0);
			this.lblSelectOrder.Name = "lblSelectOrder";
			this.lblSelectOrder.Size = new System.Drawing.Size(624, 24);
			this.lblSelectOrder.TabIndex = 16;
			this.lblSelectOrder.Text = " 全体選択";
			this.lblSelectOrder.Click += new System.EventHandler(this.lblSelectOrder_Click);
			// 
			// pnlJisi
			// 
			this.pnlJisi.Controls.Add(this.grdOCS2005);
			this.pnlJisi.Controls.Add(this.lblSelectDirect);
			this.pnlJisi.Location = new System.Drawing.Point(0, 28);
			this.pnlJisi.Name = "pnlJisi";
			this.pnlJisi.Size = new System.Drawing.Size(624, 130);
			this.pnlJisi.TabIndex = 19;
			this.pnlJisi.Visible = false;
			// 
			// grdOCS2005
			// 
			this.grdOCS2005.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
																				  this.xEditGridCell4,
																				  this.xEditGridCell10,
																				  this.xEditGridCell11,
																				  this.xEditGridCell12,
																				  this.xEditGridCell13,
																				  this.xEditGridCell14,
																				  this.xEditGridCell15,
																				  this.xEditGridCell16,
																				  this.xEditGridCell17,
																				  this.xEditGridCell18,
																				  this.xEditGridCell49,
																				  this.xEditGridCell50,
																				  this.xEditGridCell51,
																				  this.xEditGridCell56,
																				  this.xEditGridCell57,
																				  this.xEditGridCell58,
																				  this.xEditGridCell62,
																				  this.xEditGridCell63,
																				  this.xEditGridCell70,
																				  this.xEditGridCell75,
																				  this.xEditGridCell76,
																				  this.xEditGridCell77,
																				  this.xEditGridCell80,
																				  this.xEditGridCell79,
																				  this.xEditGridCell78,
																				  this.xEditGridCell98});
			this.grdOCS2005.ColPerLine = 4;
			this.grdOCS2005.Cols = 5;
			this.grdOCS2005.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdOCS2005.FixedCols = 1;
			this.grdOCS2005.FixedRows = 1;
			this.grdOCS2005.HeaderHeights.Add(21);
			this.grdOCS2005.Location = new System.Drawing.Point(0, 24);
			this.grdOCS2005.Name = "grdOCS2005";
			this.grdOCS2005.ReadOnly = true;
			this.grdOCS2005.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
			this.grdOCS2005.RowHeaderVisible = true;
			this.grdOCS2005.Rows = 2;
			this.grdOCS2005.RowStateCheckOnPaint = false;
			this.grdOCS2005.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
			this.grdOCS2005.Size = new System.Drawing.Size(624, 106);
			this.grdOCS2005.TabIndex = 17;
			this.grdOCS2005.ToolTipActive = true;
			this.grdOCS2005.Visible = false;
			this.grdOCS2005.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS2005_MouseDown);
			this.grdOCS2005.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS2005_QueryEnd);
			this.grdOCS2005.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS2005_QueryStarting);
			// 
			// xEditGridCell4
			// 
			this.xEditGridCell4.CellName = "pk_order";
			this.xEditGridCell4.Col = -1;
			this.xEditGridCell4.HeaderText = "pk_order";
			this.xEditGridCell4.IsUpdatable = false;
			this.xEditGridCell4.IsVisible = false;
			this.xEditGridCell4.Row = -1;
			// 
			// xEditGridCell10
			// 
			this.xEditGridCell10.CellName = "bunho";
			this.xEditGridCell10.Col = -1;
			this.xEditGridCell10.HeaderText = "bunho";
			this.xEditGridCell10.IsUpdatable = false;
			this.xEditGridCell10.IsVisible = false;
			this.xEditGridCell10.Row = -1;
			// 
			// xEditGridCell11
			// 
			this.xEditGridCell11.CellName = "fkinp1001";
			this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell11.Col = -1;
			this.xEditGridCell11.HeaderText = "fkinp1001";
			this.xEditGridCell11.IsUpdatable = false;
			this.xEditGridCell11.IsVisible = false;
			this.xEditGridCell11.Row = -1;
			// 
			// xEditGridCell12
			// 
			this.xEditGridCell12.CellName = "order_date";
			this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Date;
			this.xEditGridCell12.Col = -1;
			this.xEditGridCell12.HeaderText = "order_date";
			this.xEditGridCell12.IsUpdatable = false;
			this.xEditGridCell12.IsVisible = false;
			this.xEditGridCell12.Row = -1;
			// 
			// xEditGridCell13
			// 
			this.xEditGridCell13.CellName = "input_gubun";
			this.xEditGridCell13.Col = -1;
			this.xEditGridCell13.HeaderText = "input_gubun";
			this.xEditGridCell13.IsUpdatable = false;
			this.xEditGridCell13.IsVisible = false;
			this.xEditGridCell13.Row = -1;
			// 
			// xEditGridCell14
			// 
			this.xEditGridCell14.CellName = "pk_seq";
			this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell14.Col = -1;
			this.xEditGridCell14.HeaderText = "pk_seq";
			this.xEditGridCell14.IsUpdatable = false;
			this.xEditGridCell14.IsVisible = false;
			this.xEditGridCell14.Row = -1;
			// 
			// xEditGridCell15
			// 
			this.xEditGridCell15.CellName = "direct_gubun";
			this.xEditGridCell15.Col = -1;
			this.xEditGridCell15.HeaderText = "direct_gubun";
			this.xEditGridCell15.IsUpdatable = false;
			this.xEditGridCell15.IsVisible = false;
			this.xEditGridCell15.Row = -1;
			// 
			// xEditGridCell16
			// 
			this.xEditGridCell16.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell16.CellName = "direct_gubun_name";
			this.xEditGridCell16.CellWidth = 102;
			this.xEditGridCell16.Col = 2;
			this.xEditGridCell16.HeaderText = "指示区分";
			this.xEditGridCell16.IsUpdatable = false;
			this.xEditGridCell16.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell16.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			this.xEditGridCell16.SuppressRepeating = true;
			// 
			// xEditGridCell17
			// 
			this.xEditGridCell17.CellName = "direct_code";
			this.xEditGridCell17.Col = -1;
			this.xEditGridCell17.HeaderText = "direct_code";
			this.xEditGridCell17.IsUpdatable = false;
			this.xEditGridCell17.IsVisible = false;
			this.xEditGridCell17.Row = -1;
			// 
			// xEditGridCell18
			// 
			this.xEditGridCell18.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell18.CellName = "direct_code_name";
			this.xEditGridCell18.CellWidth = 185;
			this.xEditGridCell18.Col = 3;
			this.xEditGridCell18.HeaderText = "指示事項";
			this.xEditGridCell18.IsUpdatable = false;
			this.xEditGridCell18.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell18.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell49
			// 
			this.xEditGridCell49.CellName = "direct_cont1";
			this.xEditGridCell49.Col = -1;
			this.xEditGridCell49.HeaderText = "direct_cont1";
			this.xEditGridCell49.IsUpdatable = false;
			this.xEditGridCell49.IsVisible = false;
			this.xEditGridCell49.Row = -1;
			// 
			// xEditGridCell50
			// 
			this.xEditGridCell50.CellName = "direct_cont2";
			this.xEditGridCell50.Col = -1;
			this.xEditGridCell50.HeaderText = "direct_cont2";
			this.xEditGridCell50.IsUpdatable = false;
			this.xEditGridCell50.IsVisible = false;
			this.xEditGridCell50.Row = -1;
			// 
			// xEditGridCell51
			// 
			this.xEditGridCell51.CellName = "cnt_perhour";
			this.xEditGridCell51.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell51.Col = -1;
			this.xEditGridCell51.HeaderText = "cnt_perhour";
			this.xEditGridCell51.IsVisible = false;
			this.xEditGridCell51.Row = -1;
			// 
			// xEditGridCell56
			// 
			this.xEditGridCell56.CellName = "cnt_perday";
			this.xEditGridCell56.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell56.Col = -1;
			this.xEditGridCell56.HeaderText = "cnt_perday";
			this.xEditGridCell56.IsUpdatable = false;
			this.xEditGridCell56.IsVisible = false;
			this.xEditGridCell56.Row = -1;
			// 
			// xEditGridCell57
			// 
			this.xEditGridCell57.CellName = "act_day";
			this.xEditGridCell57.Col = -1;
			this.xEditGridCell57.HeaderText = "act_day";
			this.xEditGridCell57.IsUpdatable = false;
			this.xEditGridCell57.IsVisible = false;
			this.xEditGridCell57.Row = -1;
			// 
			// xEditGridCell58
			// 
			this.xEditGridCell58.CellName = "french";
			this.xEditGridCell58.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell58.Col = -1;
			this.xEditGridCell58.HeaderText = "french";
			this.xEditGridCell58.IsUpdatable = false;
			this.xEditGridCell58.IsVisible = false;
			this.xEditGridCell58.Row = -1;
			// 
			// xEditGridCell62
			// 
			this.xEditGridCell62.CellName = "act_dq1";
			this.xEditGridCell62.Col = -1;
			this.xEditGridCell62.HeaderText = "act_dq1";
			this.xEditGridCell62.IsUpdatable = false;
			this.xEditGridCell62.IsVisible = false;
			this.xEditGridCell62.Row = -1;
			// 
			// xEditGridCell63
			// 
			this.xEditGridCell63.CellName = "act_dq2";
			this.xEditGridCell63.Col = -1;
			this.xEditGridCell63.HeaderText = "act_dq2";
			this.xEditGridCell63.IsUpdatable = false;
			this.xEditGridCell63.IsVisible = false;
			this.xEditGridCell63.Row = -1;
			// 
			// xEditGridCell70
			// 
			this.xEditGridCell70.CellName = "act_dq3";
			this.xEditGridCell70.Col = -1;
			this.xEditGridCell70.HeaderText = "act_dq3";
			this.xEditGridCell70.IsUpdatable = false;
			this.xEditGridCell70.IsVisible = false;
			this.xEditGridCell70.Row = -1;
			// 
			// xEditGridCell75
			// 
			this.xEditGridCell75.CellName = "act_dq4";
			this.xEditGridCell75.Col = -1;
			this.xEditGridCell75.HeaderText = "act_dq4";
			this.xEditGridCell75.IsUpdatable = false;
			this.xEditGridCell75.IsVisible = false;
			this.xEditGridCell75.Row = -1;
			// 
			// xEditGridCell76
			// 
			this.xEditGridCell76.CellName = "act_time";
			this.xEditGridCell76.Col = -1;
			this.xEditGridCell76.HeaderText = "act_time";
			this.xEditGridCell76.IsUpdatable = false;
			this.xEditGridCell76.IsVisible = false;
			this.xEditGridCell76.Row = -1;
			// 
			// xEditGridCell77
			// 
			this.xEditGridCell77.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell77.CellLen = 1000;
			this.xEditGridCell77.CellName = "direct_text";
			this.xEditGridCell77.CellWidth = 436;
			this.xEditGridCell77.Col = 4;
			this.xEditGridCell77.DisplayMemoText = true;
			this.xEditGridCell77.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
			this.xEditGridCell77.HeaderText = "内容";
			this.xEditGridCell77.IsUpdatable = false;
			this.xEditGridCell77.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell77.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell80
			// 
			this.xEditGridCell80.CellName = "input_gubun_name";
			this.xEditGridCell80.Col = -1;
			this.xEditGridCell80.HeaderText = "input_gubun_name";
			this.xEditGridCell80.IsUpdatable = false;
			this.xEditGridCell80.IsVisible = false;
			this.xEditGridCell80.Row = -1;
			// 
			// xEditGridCell79
			// 
			this.xEditGridCell79.CellName = "bulyong_check";
			this.xEditGridCell79.Col = -1;
			this.xEditGridCell79.HeaderText = "bulyong_check";
			this.xEditGridCell79.IsUpdatable = false;
			this.xEditGridCell79.IsVisible = false;
			this.xEditGridCell79.Row = -1;
			// 
			// xEditGridCell78
			// 
			this.xEditGridCell78.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell78.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.xEditGridCell78.CellName = "select";
			this.xEditGridCell78.CellWidth = 38;
			this.xEditGridCell78.Col = 1;
			this.xEditGridCell78.HeaderText = "選択";
			this.xEditGridCell78.IsUpdatable = false;
			this.xEditGridCell78.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.xEditGridCell78.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell78.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell98
			// 
			this.xEditGridCell98.CellName = "other_gwa";
			this.xEditGridCell98.Col = -1;
			this.xEditGridCell98.HeaderText = "other_gwa";
			this.xEditGridCell98.IsUpdatable = false;
			this.xEditGridCell98.IsUpdCol = false;
			this.xEditGridCell98.IsVisible = false;
			this.xEditGridCell98.Row = -1;
			// 
			// lblSelectDirect
			// 
			this.lblSelectDirect.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
			this.lblSelectDirect.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblSelectDirect.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblSelectDirect.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
			this.lblSelectDirect.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
			this.lblSelectDirect.Image = ((System.Drawing.Image)(resources.GetObject("lblSelectDirect.Image")));
			this.lblSelectDirect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblSelectDirect.ImageIndex = 0;
			this.lblSelectDirect.ImageList = this.ImageList;
			this.lblSelectDirect.Location = new System.Drawing.Point(0, 0);
			this.lblSelectDirect.Name = "lblSelectDirect";
			this.lblSelectDirect.Size = new System.Drawing.Size(624, 24);
			this.lblSelectDirect.TabIndex = 18;
			this.lblSelectDirect.Text = " 全体選択";
			this.lblSelectDirect.Visible = false;
			this.lblSelectDirect.Click += new System.EventHandler(this.lblSelectDirect_Click);
			// 
			// dloSelectOCS2003
			// 
			this.dloSelectOCS2003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dloSelectOCS2003_QueryStarting);
			// 
			// dloOrder_danui
			// 
			this.dloOrder_danui.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
																							  this.multiLayoutItem1,
																							  this.multiLayoutItem2});
			// 
			// multiLayoutItem1
			// 
			this.multiLayoutItem1.DataName = "code";
			// 
			// multiLayoutItem2
			// 
			this.multiLayoutItem2.DataName = "code_name";
			// 
			// dloSelectOCS2005
			// 
			this.dloSelectOCS2005.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dloSelectOCS2005_QueryStarting);
			// 
			// imageListMixGroup
			// 
			this.imageListMixGroup.ImageSize = new System.Drawing.Size(16, 16);
			this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
			this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// pnlOut
			// 
			this.pnlOut.Controls.Add(this.pnlOutOrder);
			this.pnlOut.Controls.Add(this.sptOut);
			this.pnlOut.Controls.Add(this.pnlOutSang);
			this.pnlOut.Location = new System.Drawing.Point(388, 48);
			this.pnlOut.Name = "pnlOut";
			this.pnlOut.Size = new System.Drawing.Size(700, 515);
			this.pnlOut.TabIndex = 6;
			// 
			// pnlOutOrder
			// 
			this.pnlOutOrder.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.pnlOutOrder.Controls.Add(this.grdOCS1003);
			this.pnlOutOrder.Controls.Add(this.lblSelectOutOrder);
			this.pnlOutOrder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlOutOrder.Location = new System.Drawing.Point(0, 145);
			this.pnlOutOrder.Name = "pnlOutOrder";
			this.pnlOutOrder.Size = new System.Drawing.Size(700, 370);
			this.pnlOutOrder.TabIndex = 7;
			// 
			// grdOCS1003
			// 
			this.grdOCS1003.AddedHeaderLine = 1;
			this.grdOCS1003.ApplyPaintEventToAllColumn = true;
			this.grdOCS1003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
																				  this.xEditGridCell140,
																				  this.xEditGridCell212,
																				  this.xEditGridCell213,
																				  this.xEditGridCell214,
																				  this.xEditGridCell218,
																				  this.xEditGridCell219,
																				  this.xEditGridCell220,
																				  this.xEditGridCell221,
																				  this.xEditGridCell141,
																				  this.xEditGridCell142,
																				  this.xEditGridCell143,
																				  this.xEditGridCell144,
																				  this.xEditGridCell145,
																				  this.xEditGridCell146,
																				  this.xEditGridCell147,
																				  this.xEditGridCell148,
																				  this.xEditGridCell149,
																				  this.xEditGridCell150,
																				  this.xEditGridCell151,
																				  this.xEditGridCell152,
																				  this.xEditGridCell153,
																				  this.xEditGridCell154,
																				  this.xEditGridCell155,
																				  this.xEditGridCell156,
																				  this.xEditGridCell157,
																				  this.xEditGridCell158,
																				  this.xEditGridCell159,
																				  this.xEditGridCell160,
																				  this.xEditGridCell161,
																				  this.xEditGridCell162,
																				  this.xEditGridCell163,
																				  this.xEditGridCell164,
																				  this.xEditGridCell165,
																				  this.xEditGridCell166,
																				  this.xEditGridCell167,
																				  this.xEditGridCell168,
																				  this.xEditGridCell169,
																				  this.xEditGridCell170,
																				  this.xEditGridCell171,
																				  this.xEditGridCell172,
																				  this.xEditGridCell173,
																				  this.xEditGridCell174,
																				  this.xEditGridCell175,
																				  this.xEditGridCell176,
																				  this.xEditGridCell177,
																				  this.xEditGridCell178,
																				  this.xEditGridCell179,
																				  this.xEditGridCell180,
																				  this.xEditGridCell181,
																				  this.xEditGridCell182,
																				  this.xEditGridCell183,
																				  this.xEditGridCell184,
																				  this.xEditGridCell185,
																				  this.xEditGridCell186,
																				  this.xEditGridCell187,
																				  this.xEditGridCell188,
																				  this.xEditGridCell189,
																				  this.xEditGridCell190,
																				  this.xEditGridCell216,
																				  this.xEditGridCell191,
																				  this.xEditGridCell192,
																				  this.xEditGridCell193,
																				  this.xEditGridCell194,
																				  this.xEditGridCell195,
																				  this.xEditGridCell196,
																				  this.xEditGridCell197,
																				  this.xEditGridCell198,
																				  this.xEditGridCell199,
																				  this.xEditGridCell200,
																				  this.xEditGridCell201,
																				  this.xEditGridCell202,
																				  this.xEditGridCell203,
																				  this.xEditGridCell231,
																				  this.xEditGridCell204});
			this.grdOCS1003.ColPerLine = 20;
			this.grdOCS1003.ColResizable = true;
			this.grdOCS1003.Cols = 21;
			this.grdOCS1003.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdOCS1003.EnableMultiSelection = true;
			this.grdOCS1003.FixedCols = 1;
			this.grdOCS1003.FixedRows = 2;
			this.grdOCS1003.HeaderHeights.Add(29);
			this.grdOCS1003.HeaderHeights.Add(0);
			this.grdOCS1003.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
																					  this.xGridHeader2});
			this.grdOCS1003.Location = new System.Drawing.Point(0, 24);
			this.grdOCS1003.MasterLayout = this.grdOUT1001;
			this.grdOCS1003.Name = "grdOCS1003";
			this.grdOCS1003.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
			this.grdOCS1003.RowHeaderVisible = true;
			this.grdOCS1003.Rows = 3;
			this.grdOCS1003.RowStateCheckOnPaint = false;
			this.grdOCS1003.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
			this.grdOCS1003.Size = new System.Drawing.Size(700, 346);
			this.grdOCS1003.TabIndex = 17;
			this.grdOCS1003.ToolTipActive = true;
			this.grdOCS1003.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS1003_RowFocusChanged);
			this.grdOCS1003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS1003_MouseDown);
			this.grdOCS1003.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS1003_QueryEnd);
			this.grdOCS1003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS1003_QueryStarting);
			this.grdOCS1003.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS1003_GridCellPainting);
			// 
			// xEditGridCell140
			// 
			this.xEditGridCell140.CellName = "pk_order";
			this.xEditGridCell140.Col = -1;
			this.xEditGridCell140.HeaderText = "pk_order";
			this.xEditGridCell140.IsUpdatable = false;
			this.xEditGridCell140.IsVisible = false;
			this.xEditGridCell140.Row = -1;
			// 
			// xEditGridCell212
			// 
			this.xEditGridCell212.CellName = "pk_order_1";
			this.xEditGridCell212.Col = -1;
			this.xEditGridCell212.HeaderText = "pk_order_1";
			this.xEditGridCell212.IsUpdatable = false;
			this.xEditGridCell212.IsVisible = false;
			this.xEditGridCell212.Row = -1;
			// 
			// xEditGridCell213
			// 
			this.xEditGridCell213.CellName = "pk_order_2";
			this.xEditGridCell213.Col = -1;
			this.xEditGridCell213.HeaderText = "pk_order_2";
			this.xEditGridCell213.IsUpdatable = false;
			this.xEditGridCell213.IsVisible = false;
			this.xEditGridCell213.Row = -1;
			// 
			// xEditGridCell214
			// 
			this.xEditGridCell214.CellName = "pk_order_3";
			this.xEditGridCell214.Col = -1;
			this.xEditGridCell214.HeaderText = "pk_order_3";
			this.xEditGridCell214.IsUpdatable = false;
			this.xEditGridCell214.IsVisible = false;
			this.xEditGridCell214.Row = -1;
			// 
			// xEditGridCell218
			// 
			this.xEditGridCell218.CellName = "pk_order_4";
			this.xEditGridCell218.Col = -1;
			this.xEditGridCell218.HeaderText = "pk_order_4";
			this.xEditGridCell218.IsUpdatable = false;
			this.xEditGridCell218.IsVisible = false;
			this.xEditGridCell218.Row = -1;
			// 
			// xEditGridCell219
			// 
			this.xEditGridCell219.CellName = "pk_order_5";
			this.xEditGridCell219.Col = -1;
			this.xEditGridCell219.HeaderText = "pk_order_5";
			this.xEditGridCell219.IsUpdatable = false;
			this.xEditGridCell219.IsVisible = false;
			this.xEditGridCell219.Row = -1;
			// 
			// xEditGridCell220
			// 
			this.xEditGridCell220.CellName = "pk_order_6";
			this.xEditGridCell220.Col = -1;
			this.xEditGridCell220.HeaderText = "pk_order_6";
			this.xEditGridCell220.IsUpdatable = false;
			this.xEditGridCell220.IsVisible = false;
			this.xEditGridCell220.Row = -1;
			// 
			// xEditGridCell221
			// 
			this.xEditGridCell221.CellName = "pk_order_7";
			this.xEditGridCell221.Col = -1;
			this.xEditGridCell221.HeaderText = "pk_order_7";
			this.xEditGridCell221.IsUpdatable = false;
			this.xEditGridCell221.IsVisible = false;
			this.xEditGridCell221.Row = -1;
			// 
			// xEditGridCell141
			// 
			this.xEditGridCell141.CellName = "pkocs1003";
			this.xEditGridCell141.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell141.Col = -1;
			this.xEditGridCell141.HeaderText = "pkocs1003";
			this.xEditGridCell141.IsUpdatable = false;
			this.xEditGridCell141.IsVisible = false;
			this.xEditGridCell141.Row = -1;
			// 
			// xEditGridCell142
			// 
			this.xEditGridCell142.CellName = "bunho";
			this.xEditGridCell142.Col = -1;
			this.xEditGridCell142.HeaderText = "bunho";
			this.xEditGridCell142.IsUpdatable = false;
			this.xEditGridCell142.IsVisible = false;
			this.xEditGridCell142.Row = -1;
			// 
			// xEditGridCell143
			// 
			this.xEditGridCell143.CellName = "fkinp1001";
			this.xEditGridCell143.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell143.Col = -1;
			this.xEditGridCell143.HeaderText = "fkinp1001";
			this.xEditGridCell143.IsUpdatable = false;
			this.xEditGridCell143.IsVisible = false;
			this.xEditGridCell143.Row = -1;
			// 
			// xEditGridCell144
			// 
			this.xEditGridCell144.CellName = "input_gubun";
			this.xEditGridCell144.Col = -1;
			this.xEditGridCell144.HeaderText = "input_gubun";
			this.xEditGridCell144.IsUpdatable = false;
			this.xEditGridCell144.IsVisible = false;
			this.xEditGridCell144.Row = -1;
			// 
			// xEditGridCell145
			// 
			this.xEditGridCell145.CellName = "seq";
			this.xEditGridCell145.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell145.Col = -1;
			this.xEditGridCell145.HeaderText = "seq";
			this.xEditGridCell145.IsUpdatable = false;
			this.xEditGridCell145.IsVisible = false;
			this.xEditGridCell145.Row = -1;
			// 
			// xEditGridCell146
			// 
			this.xEditGridCell146.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell146.CellName = "order_date";
			this.xEditGridCell146.CellType = IHIS.Framework.XCellDataType.Date;
			this.xEditGridCell146.Col = 2;
			this.xEditGridCell146.HeaderText = "オ―ダ日付";
			this.xEditGridCell146.IsUpdatable = false;
			this.xEditGridCell146.RowSpan = 2;
			this.xEditGridCell146.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell146.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell147
			// 
			this.xEditGridCell147.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell147.CellName = "group_ser";
			this.xEditGridCell147.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell147.CellWidth = 21;
			this.xEditGridCell147.Col = 4;
			this.xEditGridCell147.HeaderText = "G\r\nR";
			this.xEditGridCell147.IsUpdatable = false;
			this.xEditGridCell147.RowSpan = 2;
			this.xEditGridCell147.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell147.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell148
			// 
			this.xEditGridCell148.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell148.CellName = "order_gubun_name";
			this.xEditGridCell148.CellWidth = 64;
			this.xEditGridCell148.Col = 3;
			this.xEditGridCell148.HeaderText = "オ―ダ\r\n区分";
			this.xEditGridCell148.IsUpdatable = false;
			this.xEditGridCell148.RowSpan = 2;
			this.xEditGridCell148.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell148.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			this.xEditGridCell148.SuppressRepeating = true;
			// 
			// xEditGridCell149
			// 
			this.xEditGridCell149.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell149.CellName = "hangmog_code";
			this.xEditGridCell149.CellWidth = 74;
			this.xEditGridCell149.Col = 6;
			this.xEditGridCell149.HeaderText = "オ―ダコード";
			this.xEditGridCell149.IsUpdatable = false;
			this.xEditGridCell149.RowSpan = 2;
			this.xEditGridCell149.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell149.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell150
			// 
			this.xEditGridCell150.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell150.CellName = "hangmog_name";
			this.xEditGridCell150.CellWidth = 191;
			this.xEditGridCell150.Col = 7;
			this.xEditGridCell150.HeaderText = "オ―ダ名";
			this.xEditGridCell150.IsUpdatable = false;
			this.xEditGridCell150.RowSpan = 2;
			this.xEditGridCell150.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell150.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell151
			// 
			this.xEditGridCell151.CellName = "specimen_code";
			this.xEditGridCell151.Col = -1;
			this.xEditGridCell151.HeaderText = "specimen_code";
			this.xEditGridCell151.IsUpdatable = false;
			this.xEditGridCell151.IsVisible = false;
			this.xEditGridCell151.Row = -1;
			// 
			// xEditGridCell152
			// 
			this.xEditGridCell152.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell152.CellName = "specimen_name";
			this.xEditGridCell152.CellWidth = 33;
			this.xEditGridCell152.Col = 8;
			this.xEditGridCell152.HeaderText = "検体";
			this.xEditGridCell152.IsUpdatable = false;
			this.xEditGridCell152.RowSpan = 2;
			this.xEditGridCell152.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell152.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell153
			// 
			this.xEditGridCell153.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell153.CellName = "suryang";
			this.xEditGridCell153.CellType = IHIS.Framework.XCellDataType.Decimal;
			this.xEditGridCell153.CellWidth = 46;
			this.xEditGridCell153.Col = 9;
			this.xEditGridCell153.DecimalDigits = 2;
			this.xEditGridCell153.HeaderText = "数量";
			this.xEditGridCell153.IsUpdatable = false;
			this.xEditGridCell153.RowSpan = 2;
			this.xEditGridCell153.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell153.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell154
			// 
			this.xEditGridCell154.CellName = "ord_danui";
			this.xEditGridCell154.Col = -1;
			this.xEditGridCell154.HeaderText = "ord_danui";
			this.xEditGridCell154.IsUpdatable = false;
			this.xEditGridCell154.IsVisible = false;
			this.xEditGridCell154.Row = -1;
			// 
			// xEditGridCell155
			// 
			this.xEditGridCell155.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell155.CellName = "ord_danui_name";
			this.xEditGridCell155.CellWidth = 69;
			this.xEditGridCell155.Col = 10;
			this.xEditGridCell155.HeaderText = "単位";
			this.xEditGridCell155.IsUpdatable = false;
			this.xEditGridCell155.RowSpan = 2;
			this.xEditGridCell155.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell155.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell156
			// 
			this.xEditGridCell156.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell156.CellName = "dv_time";
			this.xEditGridCell156.CellWidth = 24;
			this.xEditGridCell156.Col = 11;
			this.xEditGridCell156.HeaderText = "dv_time";
			this.xEditGridCell156.IsUpdatable = false;
			this.xEditGridCell156.Row = 1;
			this.xEditGridCell156.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell156.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			this.xEditGridCell156.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xEditGridCell157
			// 
			this.xEditGridCell157.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell157.CellName = "dv";
			this.xEditGridCell157.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell157.CellWidth = 30;
			this.xEditGridCell157.Col = 12;
			this.xEditGridCell157.HeaderText = "dv";
			this.xEditGridCell157.IsUpdatable = false;
			this.xEditGridCell157.Row = 1;
			this.xEditGridCell157.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell157.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell158
			// 
			this.xEditGridCell158.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell158.CellName = "nalsu";
			this.xEditGridCell158.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell158.CellWidth = 34;
			this.xEditGridCell158.Col = 13;
			this.xEditGridCell158.HeaderText = "日数";
			this.xEditGridCell158.IsUpdatable = false;
			this.xEditGridCell158.RowSpan = 2;
			this.xEditGridCell158.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell158.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell159
			// 
			this.xEditGridCell159.CellName = "jusa";
			this.xEditGridCell159.Col = -1;
			this.xEditGridCell159.HeaderText = "jusa";
			this.xEditGridCell159.IsUpdatable = false;
			this.xEditGridCell159.IsVisible = false;
			this.xEditGridCell159.Row = -1;
			// 
			// xEditGridCell160
			// 
			this.xEditGridCell160.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell160.CellName = "jusa_name";
			this.xEditGridCell160.CellWidth = 34;
			this.xEditGridCell160.Col = 14;
			this.xEditGridCell160.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
			this.xEditGridCell160.HeaderText = "注射";
			this.xEditGridCell160.IsUpdatable = false;
			this.xEditGridCell160.RowSpan = 2;
			this.xEditGridCell160.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell160.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell161
			// 
			this.xEditGridCell161.CellName = "bogyong_code";
			this.xEditGridCell161.Col = -1;
			this.xEditGridCell161.HeaderText = "bogyong_code";
			this.xEditGridCell161.IsUpdatable = false;
			this.xEditGridCell161.IsVisible = false;
			this.xEditGridCell161.Row = -1;
			// 
			// xEditGridCell162
			// 
			this.xEditGridCell162.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell162.CellName = "bogyong_name";
			this.xEditGridCell162.CellWidth = 69;
			this.xEditGridCell162.Col = 15;
			this.xEditGridCell162.HeaderText = "用法";
			this.xEditGridCell162.IsUpdatable = false;
			this.xEditGridCell162.RowSpan = 2;
			this.xEditGridCell162.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell162.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell163
			// 
			this.xEditGridCell163.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell163.CellName = "wonyoi_order_yn";
			this.xEditGridCell163.CellWidth = 22;
			this.xEditGridCell163.Col = 16;
			this.xEditGridCell163.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
			this.xEditGridCell163.HeaderText = "院\r\n外";
			this.xEditGridCell163.IsUpdatable = false;
			this.xEditGridCell163.RowSpan = 2;
			this.xEditGridCell163.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell163.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell164
			// 
			this.xEditGridCell164.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell164.CellName = "wonnae_sayu_code";
			this.xEditGridCell164.CellWidth = 61;
			this.xEditGridCell164.Col = -1;
			this.xEditGridCell164.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xEditGridCell164.HeaderText = "院内事由";
			this.xEditGridCell164.IsUpdatable = false;
			this.xEditGridCell164.IsVisible = false;
			this.xEditGridCell164.Row = -1;
			this.xEditGridCell164.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell164.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell165
			// 
			this.xEditGridCell165.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell165.CellName = "emergency";
			this.xEditGridCell165.CellWidth = 21;
			this.xEditGridCell165.Col = 17;
			this.xEditGridCell165.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
			this.xEditGridCell165.HeaderText = "緊\r\n急";
			this.xEditGridCell165.IsUpdatable = false;
			this.xEditGridCell165.RowSpan = 2;
			this.xEditGridCell165.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell165.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell166
			// 
			this.xEditGridCell166.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell166.CellName = "pay";
			this.xEditGridCell166.CellWidth = 36;
			this.xEditGridCell166.Col = 19;
			this.xEditGridCell166.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
			this.xEditGridCell166.HeaderText = "請求\r\n区分";
			this.xEditGridCell166.IsUpdatable = false;
			this.xEditGridCell166.RowSpan = 2;
			this.xEditGridCell166.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell166.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			this.xEditGridCell166.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xEditGridCell167
			// 
			this.xEditGridCell167.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell167.CellName = "fluid_yn";
			this.xEditGridCell167.CellWidth = 32;
			this.xEditGridCell167.Col = -1;
			this.xEditGridCell167.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xEditGridCell167.HeaderText = "輸液";
			this.xEditGridCell167.IsUpdatable = false;
			this.xEditGridCell167.IsVisible = false;
			this.xEditGridCell167.Row = -1;
			this.xEditGridCell167.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell167.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell168
			// 
			this.xEditGridCell168.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell168.CellName = "tpn_yn";
			this.xEditGridCell168.CellWidth = 33;
			this.xEditGridCell168.Col = -1;
			this.xEditGridCell168.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xEditGridCell168.HeaderText = "TPN";
			this.xEditGridCell168.IsUpdatable = false;
			this.xEditGridCell168.IsVisible = false;
			this.xEditGridCell168.Row = -1;
			this.xEditGridCell168.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell168.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell169
			// 
			this.xEditGridCell169.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell169.CellName = "anti_cancer_yn";
			this.xEditGridCell169.CellWidth = 45;
			this.xEditGridCell169.Col = -1;
			this.xEditGridCell169.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
			this.xEditGridCell169.HeaderText = "抗癌剤";
			this.xEditGridCell169.IsUpdatable = false;
			this.xEditGridCell169.IsVisible = false;
			this.xEditGridCell169.Row = -1;
			this.xEditGridCell169.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell169.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell170
			// 
			this.xEditGridCell170.CellName = "muhyo";
			this.xEditGridCell170.Col = -1;
			this.xEditGridCell170.HeaderText = "muhyo";
			this.xEditGridCell170.IsUpdatable = false;
			this.xEditGridCell170.IsVisible = false;
			this.xEditGridCell170.Row = -1;
			// 
			// xEditGridCell171
			// 
			this.xEditGridCell171.CellName = "portable_yn";
			this.xEditGridCell171.Col = -1;
			this.xEditGridCell171.HeaderText = "portable_yn";
			this.xEditGridCell171.IsUpdatable = false;
			this.xEditGridCell171.IsVisible = false;
			this.xEditGridCell171.Row = -1;
			// 
			// xEditGridCell172
			// 
			this.xEditGridCell172.CellName = "symya";
			this.xEditGridCell172.Col = -1;
			this.xEditGridCell172.HeaderText = "symya";
			this.xEditGridCell172.IsUpdatable = false;
			this.xEditGridCell172.IsVisible = false;
			this.xEditGridCell172.Row = -1;
			// 
			// xEditGridCell173
			// 
			this.xEditGridCell173.CellName = "ocs_flag";
			this.xEditGridCell173.Col = -1;
			this.xEditGridCell173.HeaderText = "ocs_flag";
			this.xEditGridCell173.IsUpdatable = false;
			this.xEditGridCell173.IsVisible = false;
			this.xEditGridCell173.Row = -1;
			// 
			// xEditGridCell174
			// 
			this.xEditGridCell174.CellName = "order_gubun";
			this.xEditGridCell174.Col = -1;
			this.xEditGridCell174.HeaderText = "order_gubun";
			this.xEditGridCell174.IsUpdatable = false;
			this.xEditGridCell174.IsVisible = false;
			this.xEditGridCell174.Row = -1;
			// 
			// xEditGridCell175
			// 
			this.xEditGridCell175.CellName = "jaeryo_jundal_yn";
			this.xEditGridCell175.Col = -1;
			this.xEditGridCell175.HeaderText = "jaeryo_jundal_yn";
			this.xEditGridCell175.IsUpdatable = false;
			this.xEditGridCell175.IsVisible = false;
			this.xEditGridCell175.Row = -1;
			// 
			// xEditGridCell176
			// 
			this.xEditGridCell176.CellName = "jundal_table";
			this.xEditGridCell176.Col = -1;
			this.xEditGridCell176.HeaderText = "jundal_table";
			this.xEditGridCell176.IsUpdatable = false;
			this.xEditGridCell176.IsVisible = false;
			this.xEditGridCell176.Row = -1;
			// 
			// xEditGridCell177
			// 
			this.xEditGridCell177.CellName = "jundal_part";
			this.xEditGridCell177.Col = -1;
			this.xEditGridCell177.HeaderText = "jundal_part";
			this.xEditGridCell177.IsUpdatable = false;
			this.xEditGridCell177.IsVisible = false;
			this.xEditGridCell177.Row = -1;
			// 
			// xEditGridCell178
			// 
			this.xEditGridCell178.CellName = "move_part";
			this.xEditGridCell178.Col = -1;
			this.xEditGridCell178.HeaderText = "move_part";
			this.xEditGridCell178.IsUpdatable = false;
			this.xEditGridCell178.IsVisible = false;
			this.xEditGridCell178.Row = -1;
			// 
			// xEditGridCell179
			// 
			this.xEditGridCell179.CellName = "sub_susul";
			this.xEditGridCell179.Col = -1;
			this.xEditGridCell179.HeaderText = "sub_susul";
			this.xEditGridCell179.IsUpdatable = false;
			this.xEditGridCell179.IsVisible = false;
			this.xEditGridCell179.Row = -1;
			// 
			// xEditGridCell180
			// 
			this.xEditGridCell180.CellName = "amt";
			this.xEditGridCell180.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell180.Col = -1;
			this.xEditGridCell180.HeaderText = "amt";
			this.xEditGridCell180.IsUpdatable = false;
			this.xEditGridCell180.IsVisible = false;
			this.xEditGridCell180.Row = -1;
			// 
			// xEditGridCell181
			// 
			this.xEditGridCell181.CellName = "nalsu_sayu_code";
			this.xEditGridCell181.Col = -1;
			this.xEditGridCell181.HeaderText = "nalsu_sayu_code";
			this.xEditGridCell181.IsUpdatable = false;
			this.xEditGridCell181.IsVisible = false;
			this.xEditGridCell181.Row = -1;
			// 
			// xEditGridCell182
			// 
			this.xEditGridCell182.CellName = "physical_code";
			this.xEditGridCell182.Col = -1;
			this.xEditGridCell182.HeaderText = "physical_code";
			this.xEditGridCell182.IsUpdatable = false;
			this.xEditGridCell182.IsVisible = false;
			this.xEditGridCell182.Row = -1;
			// 
			// xEditGridCell183
			// 
			this.xEditGridCell183.CellName = "dv_1";
			this.xEditGridCell183.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell183.Col = -1;
			this.xEditGridCell183.HeaderText = "dv_1";
			this.xEditGridCell183.IsUpdatable = false;
			this.xEditGridCell183.IsVisible = false;
			this.xEditGridCell183.Row = -1;
			// 
			// xEditGridCell184
			// 
			this.xEditGridCell184.CellName = "dv_2";
			this.xEditGridCell184.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell184.Col = -1;
			this.xEditGridCell184.HeaderText = "dv_2";
			this.xEditGridCell184.IsUpdatable = false;
			this.xEditGridCell184.IsVisible = false;
			this.xEditGridCell184.Row = -1;
			// 
			// xEditGridCell185
			// 
			this.xEditGridCell185.CellName = "dv_3";
			this.xEditGridCell185.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell185.Col = -1;
			this.xEditGridCell185.HeaderText = "dv_3";
			this.xEditGridCell185.IsUpdatable = false;
			this.xEditGridCell185.IsVisible = false;
			this.xEditGridCell185.Row = -1;
			// 
			// xEditGridCell186
			// 
			this.xEditGridCell186.CellName = "dv_4";
			this.xEditGridCell186.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell186.Col = -1;
			this.xEditGridCell186.HeaderText = "dv_4";
			this.xEditGridCell186.IsUpdatable = false;
			this.xEditGridCell186.IsVisible = false;
			this.xEditGridCell186.Row = -1;
			// 
			// xEditGridCell187
			// 
			this.xEditGridCell187.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell187.CellName = "hope_date";
			this.xEditGridCell187.CellType = IHIS.Framework.XCellDataType.Date;
			this.xEditGridCell187.CellWidth = 96;
			this.xEditGridCell187.Col = 20;
			this.xEditGridCell187.HeaderText = "希望日";
			this.xEditGridCell187.IsUpdatable = false;
			this.xEditGridCell187.RowSpan = 2;
			this.xEditGridCell187.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell187.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell188
			// 
			this.xEditGridCell188.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell188.CellLen = 2000;
			this.xEditGridCell188.CellName = "order_remark";
			this.xEditGridCell188.Col = 18;
			this.xEditGridCell188.DisplayMemoText = true;
			this.xEditGridCell188.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
			this.xEditGridCell188.HeaderText = "Comment";
			this.xEditGridCell188.IsUpdatable = false;
			this.xEditGridCell188.RowSpan = 2;
			this.xEditGridCell188.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell188.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell189
			// 
			this.xEditGridCell189.CellLen = 2000;
			this.xEditGridCell189.CellName = "nurse_remark";
			this.xEditGridCell189.Col = -1;
			this.xEditGridCell189.HeaderText = "nurse_remark";
			this.xEditGridCell189.IsUpdatable = false;
			this.xEditGridCell189.IsVisible = false;
			this.xEditGridCell189.Row = -1;
			// 
			// xEditGridCell190
			// 
			this.xEditGridCell190.CellName = "mix_group";
			this.xEditGridCell190.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell190.Col = -1;
			this.xEditGridCell190.HeaderText = "mix_group";
			this.xEditGridCell190.IsUpdatable = false;
			this.xEditGridCell190.IsVisible = false;
			this.xEditGridCell190.Row = -1;
			// 
			// xEditGridCell216
			// 
			this.xEditGridCell216.CellName = "regular_yn";
			this.xEditGridCell216.CellWidth = 20;
			this.xEditGridCell216.Col = 5;
			this.xEditGridCell216.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
			this.xEditGridCell216.HeaderText = "定\r\n時";
			this.xEditGridCell216.IsUpdatable = false;
			this.xEditGridCell216.RowSpan = 2;
			// 
			// xEditGridCell191
			// 
			this.xEditGridCell191.CellName = "slip_code";
			this.xEditGridCell191.Col = -1;
			this.xEditGridCell191.HeaderText = "slip_code";
			this.xEditGridCell191.IsUpdatable = false;
			this.xEditGridCell191.IsVisible = false;
			this.xEditGridCell191.Row = -1;
			// 
			// xEditGridCell192
			// 
			this.xEditGridCell192.CellName = "group_yn";
			this.xEditGridCell192.Col = -1;
			this.xEditGridCell192.HeaderText = "group_yn";
			this.xEditGridCell192.IsUpdatable = false;
			this.xEditGridCell192.IsVisible = false;
			this.xEditGridCell192.Row = -1;
			// 
			// xEditGridCell193
			// 
			this.xEditGridCell193.CellName = "sg_code";
			this.xEditGridCell193.Col = -1;
			this.xEditGridCell193.HeaderText = "sg_code";
			this.xEditGridCell193.IsUpdatable = false;
			this.xEditGridCell193.IsVisible = false;
			this.xEditGridCell193.Row = -1;
			// 
			// xEditGridCell194
			// 
			this.xEditGridCell194.CellName = "order_gubun_bas";
			this.xEditGridCell194.Col = -1;
			this.xEditGridCell194.HeaderText = "order_gubun_bas";
			this.xEditGridCell194.IsUpdatable = false;
			this.xEditGridCell194.IsVisible = false;
			this.xEditGridCell194.Row = -1;
			// 
			// xEditGridCell195
			// 
			this.xEditGridCell195.CellName = "input_control";
			this.xEditGridCell195.Col = -1;
			this.xEditGridCell195.HeaderText = "input_control";
			this.xEditGridCell195.IsUpdatable = false;
			this.xEditGridCell195.IsVisible = false;
			this.xEditGridCell195.Row = -1;
			// 
			// xEditGridCell196
			// 
			this.xEditGridCell196.CellName = "bulyong_check";
			this.xEditGridCell196.Col = -1;
			this.xEditGridCell196.HeaderText = "bulyong_check";
			this.xEditGridCell196.IsUpdatable = false;
			this.xEditGridCell196.IsVisible = false;
			this.xEditGridCell196.Row = -1;
			// 
			// xEditGridCell197
			// 
			this.xEditGridCell197.CellName = "input_gubun_name";
			this.xEditGridCell197.Col = -1;
			this.xEditGridCell197.HeaderText = "input_gubun_name";
			this.xEditGridCell197.IsUpdatable = false;
			this.xEditGridCell197.IsVisible = false;
			this.xEditGridCell197.Row = -1;
			// 
			// xEditGridCell198
			// 
			this.xEditGridCell198.CellName = "ord_danui_check";
			this.xEditGridCell198.Col = -1;
			this.xEditGridCell198.HeaderText = "ord_danui_check";
			this.xEditGridCell198.IsUpdatable = false;
			this.xEditGridCell198.IsVisible = false;
			this.xEditGridCell198.Row = -1;
			// 
			// xEditGridCell199
			// 
			this.xEditGridCell199.CellName = "ord_danui_bas";
			this.xEditGridCell199.Col = -1;
			this.xEditGridCell199.HeaderText = "ord_danui_bas";
			this.xEditGridCell199.IsUpdatable = false;
			this.xEditGridCell199.IsVisible = false;
			this.xEditGridCell199.Row = -1;
			// 
			// xEditGridCell200
			// 
			this.xEditGridCell200.CellName = "bun_code";
			this.xEditGridCell200.Col = -1;
			this.xEditGridCell200.HeaderText = "bun_code";
			this.xEditGridCell200.IsUpdatable = false;
			this.xEditGridCell200.IsVisible = false;
			this.xEditGridCell200.Row = -1;
			// 
			// xEditGridCell201
			// 
			this.xEditGridCell201.CellName = "sg_gesan";
			this.xEditGridCell201.Col = -1;
			this.xEditGridCell201.HeaderText = "sg_gesan";
			this.xEditGridCell201.IsUpdatable = false;
			this.xEditGridCell201.IsVisible = false;
			this.xEditGridCell201.Row = -1;
			// 
			// xEditGridCell202
			// 
			this.xEditGridCell202.CellName = "other_gwa";
			this.xEditGridCell202.Col = -1;
			this.xEditGridCell202.HeaderText = "other_gwa";
			this.xEditGridCell202.IsUpdatable = false;
			this.xEditGridCell202.IsVisible = false;
			this.xEditGridCell202.Row = -1;
			// 
			// xEditGridCell203
			// 
			this.xEditGridCell203.CellName = "data_control";
			this.xEditGridCell203.Col = -1;
			this.xEditGridCell203.HeaderText = "data_control";
			this.xEditGridCell203.IsUpdatable = false;
			this.xEditGridCell203.IsVisible = false;
			this.xEditGridCell203.Row = -1;
			// 
			// xEditGridCell204
			// 
			this.xEditGridCell204.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell204.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.xEditGridCell204.AlterateRowImageIndex = 0;
			this.xEditGridCell204.CellName = "select";
			this.xEditGridCell204.CellWidth = 36;
			this.xEditGridCell204.Col = 1;
			this.xEditGridCell204.HeaderText = "選択";
			this.xEditGridCell204.ImageList = this.ImageList;
			this.xEditGridCell204.IsUpdatable = false;
			this.xEditGridCell204.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.xEditGridCell204.RowImageIndex = 0;
			this.xEditGridCell204.RowSpan = 2;
			this.xEditGridCell204.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell204.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xGridHeader2
			// 
			this.xGridHeader2.Col = 11;
			this.xGridHeader2.ColSpan = 2;
			this.xGridHeader2.HeaderText = "回数";
			this.xGridHeader2.HeaderWidth = 24;
			this.xGridHeader2.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xGridHeader2.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// lblSelectOutOrder
			// 
			this.lblSelectOutOrder.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
			this.lblSelectOutOrder.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblSelectOutOrder.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblSelectOutOrder.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
			this.lblSelectOutOrder.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
			this.lblSelectOutOrder.Image = ((System.Drawing.Image)(resources.GetObject("lblSelectOutOrder.Image")));
			this.lblSelectOutOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblSelectOutOrder.ImageIndex = 0;
			this.lblSelectOutOrder.ImageList = this.ImageList;
			this.lblSelectOutOrder.Location = new System.Drawing.Point(0, 0);
			this.lblSelectOutOrder.Name = "lblSelectOutOrder";
			this.lblSelectOutOrder.Size = new System.Drawing.Size(700, 24);
			this.lblSelectOutOrder.TabIndex = 16;
			this.lblSelectOutOrder.Text = " 全体選択";
			this.lblSelectOutOrder.Click += new System.EventHandler(this.lblSelectOutOrder_Click);
			// 
			// sptOut
			// 
			this.sptOut.Dock = System.Windows.Forms.DockStyle.Top;
			this.sptOut.Location = new System.Drawing.Point(0, 142);
			this.sptOut.Name = "sptOut";
			this.sptOut.Size = new System.Drawing.Size(700, 3);
			this.sptOut.TabIndex = 6;
			this.sptOut.TabStop = false;
			// 
			// pnlOutSang
			// 
			this.pnlOutSang.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.pnlOutSang.Controls.Add(this.grdOCS1001);
			this.pnlOutSang.Controls.Add(this.lblSelectSang);
			this.pnlOutSang.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlOutSang.Location = new System.Drawing.Point(0, 0);
			this.pnlOutSang.Name = "pnlOutSang";
			this.pnlOutSang.Size = new System.Drawing.Size(700, 142);
			this.pnlOutSang.TabIndex = 4;
			// 
			// grdOCS1001
			// 
			this.grdOCS1001.ApplyPaintEventToAllColumn = true;
			this.grdOCS1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
																				  this.xEditGridCell100,
																				  this.xEditGridCell101,
																				  this.xEditGridCell125,
																				  this.xEditGridCell103,
																				  this.xEditGridCell104,
																				  this.xEditGridCell105,
																				  this.xEditGridCell106,
																				  this.xEditGridCell107,
																				  this.xEditGridCell108,
																				  this.xEditGridCell109,
																				  this.xEditGridCell110,
																				  this.xEditGridCell111,
																				  this.xEditGridCell130,
																				  this.xEditGridCell112,
																				  this.xEditGridCell126,
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
																				  this.xEditGridCell127,
																				  this.xEditGridCell128,
																				  this.xEditGridCell129,
																				  this.xEditGridCell131,
																				  this.xEditGridCell132,
																				  this.xEditGridCell133,
																				  this.xEditGridCell134,
																				  this.xEditGridCell135,
																				  this.xEditGridCell136,
																				  this.xEditGridCell137,
																				  this.xEditGridCell138,
																				  this.xEditGridCell232,
																				  this.xEditGridCell139,
																				  this.xEditGridCell248});
			this.grdOCS1001.ColPerLine = 7;
			this.grdOCS1001.Cols = 8;
			this.grdOCS1001.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdOCS1001.EnableMultiSelection = true;
			this.grdOCS1001.FixedCols = 1;
			this.grdOCS1001.FixedRows = 1;
			this.grdOCS1001.HeaderHeights.Add(21);
			this.grdOCS1001.Location = new System.Drawing.Point(0, 24);
			this.grdOCS1001.MasterLayout = this.grdOUT1001;
			this.grdOCS1001.Name = "grdOCS1001";
			this.grdOCS1001.ReadOnly = true;
			this.grdOCS1001.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
			this.grdOCS1001.RowHeaderVisible = true;
			this.grdOCS1001.Rows = 2;
			this.grdOCS1001.RowStateCheckOnPaint = false;
			this.grdOCS1001.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
			this.grdOCS1001.Size = new System.Drawing.Size(700, 118);
			this.grdOCS1001.TabIndex = 0;
			this.grdOCS1001.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS1001_MouseDown);
			this.grdOCS1001.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS1001_QueryEnd);
			this.grdOCS1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS1001_QueryStarting);
			this.grdOCS1001.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS1001_GridCellPainting);
			// 
			// xEditGridCell100
			// 
			this.xEditGridCell100.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell100.CellName = "ju_sang_yn";
			this.xEditGridCell100.CellWidth = 25;
			this.xEditGridCell100.Col = 2;
			this.xEditGridCell100.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
			this.xEditGridCell100.HeaderText = "主";
			this.xEditGridCell100.ImageList = this.ImageList;
			this.xEditGridCell100.IsUpdatable = false;
			this.xEditGridCell100.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell100.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell101
			// 
			this.xEditGridCell101.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell101.CellName = "sang_code";
			this.xEditGridCell101.CellWidth = 75;
			this.xEditGridCell101.Col = 3;
			this.xEditGridCell101.HeaderText = "傷病コード";
			this.xEditGridCell101.ImageList = this.ImageList;
			this.xEditGridCell101.IsUpdatable = false;
			this.xEditGridCell101.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell101.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell125
			// 
			this.xEditGridCell125.CellName = "ser";
			this.xEditGridCell125.CellType = IHIS.Framework.XCellDataType.Number;
			this.xEditGridCell125.Col = -1;
			this.xEditGridCell125.HeaderText = "ser";
			this.xEditGridCell125.IsUpdatable = false;
			this.xEditGridCell125.IsVisible = false;
			this.xEditGridCell125.Row = -1;
			// 
			// xEditGridCell103
			// 
			this.xEditGridCell103.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell103.CellName = "display_sang_name";
			this.xEditGridCell103.CellWidth = 323;
			this.xEditGridCell103.Col = 4;
			this.xEditGridCell103.HeaderText = "傷病名";
			this.xEditGridCell103.ImageList = this.ImageList;
			this.xEditGridCell103.IsUpdatable = false;
			this.xEditGridCell103.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell103.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell104
			// 
			this.xEditGridCell104.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell104.CellName = "sang_start_date";
			this.xEditGridCell104.CellType = IHIS.Framework.XCellDataType.Date;
			this.xEditGridCell104.Col = 5;
			this.xEditGridCell104.HeaderText = "開始日付";
			this.xEditGridCell104.IsUpdatable = false;
			this.xEditGridCell104.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell104.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell105
			// 
			this.xEditGridCell105.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell105.CellName = "sang_end_date";
			this.xEditGridCell105.CellType = IHIS.Framework.XCellDataType.Date;
			this.xEditGridCell105.Col = 6;
			this.xEditGridCell105.HeaderText = "終了日付";
			this.xEditGridCell105.IsUpdatable = false;
			this.xEditGridCell105.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell105.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell106
			// 
			this.xEditGridCell106.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell106.CellName = "sang_end_sayu";
			this.xEditGridCell106.CellWidth = 60;
			this.xEditGridCell106.Col = 7;
			this.xEditGridCell106.HeaderImageStretch = true;
			this.xEditGridCell106.HeaderText = "終了事由";
			this.xEditGridCell106.IsUpdatable = false;
			this.xEditGridCell106.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell106.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell107
			// 
			this.xEditGridCell107.CellName = "bunho";
			this.xEditGridCell107.Col = -1;
			this.xEditGridCell107.HeaderText = "bunho";
			this.xEditGridCell107.IsUpdatable = false;
			this.xEditGridCell107.IsVisible = false;
			this.xEditGridCell107.Row = -1;
			// 
			// xEditGridCell108
			// 
			this.xEditGridCell108.CellName = "naewon_date";
			this.xEditGridCell108.Col = -1;
			this.xEditGridCell108.HeaderText = "naewon_date";
			this.xEditGridCell108.IsUpdatable = false;
			this.xEditGridCell108.IsVisible = false;
			this.xEditGridCell108.Row = -1;
			// 
			// xEditGridCell109
			// 
			this.xEditGridCell109.CellName = "gwa";
			this.xEditGridCell109.Col = -1;
			this.xEditGridCell109.HeaderText = "gwa";
			this.xEditGridCell109.IsUpdatable = false;
			this.xEditGridCell109.IsVisible = false;
			this.xEditGridCell109.Row = -1;
			// 
			// xEditGridCell110
			// 
			this.xEditGridCell110.CellName = "doctor";
			this.xEditGridCell110.Col = -1;
			this.xEditGridCell110.HeaderText = "doctor";
			this.xEditGridCell110.IsUpdatable = false;
			this.xEditGridCell110.IsVisible = false;
			this.xEditGridCell110.Row = -1;
			// 
			// xEditGridCell111
			// 
			this.xEditGridCell111.CellName = "naewon_type";
			this.xEditGridCell111.Col = -1;
			this.xEditGridCell111.HeaderText = "naewon_type";
			this.xEditGridCell111.IsUpdatable = false;
			this.xEditGridCell111.IsVisible = false;
			this.xEditGridCell111.Row = -1;
			// 
			// xEditGridCell130
			// 
			this.xEditGridCell130.CellName = "jubsu_no";
			this.xEditGridCell130.Col = -1;
			this.xEditGridCell130.HeaderText = "jubsu_no";
			this.xEditGridCell130.IsUpdatable = false;
			this.xEditGridCell130.IsVisible = false;
			this.xEditGridCell130.Row = -1;
			// 
			// xEditGridCell112
			// 
			this.xEditGridCell112.CellName = "pk_order";
			this.xEditGridCell112.Col = -1;
			this.xEditGridCell112.HeaderText = "pk_order";
			this.xEditGridCell112.IsUpdatable = false;
			this.xEditGridCell112.IsVisible = false;
			this.xEditGridCell112.Row = -1;
			// 
			// xEditGridCell126
			// 
			this.xEditGridCell126.CellName = "sang_name";
			this.xEditGridCell126.Col = -1;
			this.xEditGridCell126.HeaderText = "sang_name";
			this.xEditGridCell126.IsUpdatable = false;
			this.xEditGridCell126.IsVisible = false;
			this.xEditGridCell126.Row = -1;
			// 
			// xEditGridCell113
			// 
			this.xEditGridCell113.CellName = "pre_modifier1";
			this.xEditGridCell113.Col = -1;
			this.xEditGridCell113.HeaderText = "pre_modifier1";
			this.xEditGridCell113.IsUpdatable = false;
			this.xEditGridCell113.IsVisible = false;
			this.xEditGridCell113.Row = -1;
			// 
			// xEditGridCell114
			// 
			this.xEditGridCell114.CellName = "pre_modifier2";
			this.xEditGridCell114.Col = -1;
			this.xEditGridCell114.HeaderText = "pre_modifier2";
			this.xEditGridCell114.IsUpdatable = false;
			this.xEditGridCell114.IsVisible = false;
			this.xEditGridCell114.Row = -1;
			// 
			// xEditGridCell115
			// 
			this.xEditGridCell115.CellName = "pre_modifier3";
			this.xEditGridCell115.Col = -1;
			this.xEditGridCell115.HeaderText = "pre_modifier3";
			this.xEditGridCell115.IsUpdatable = false;
			this.xEditGridCell115.IsVisible = false;
			this.xEditGridCell115.Row = -1;
			// 
			// xEditGridCell116
			// 
			this.xEditGridCell116.CellName = "pre_modifier4";
			this.xEditGridCell116.Col = -1;
			this.xEditGridCell116.HeaderText = "pre_modifier4";
			this.xEditGridCell116.IsUpdatable = false;
			this.xEditGridCell116.IsVisible = false;
			this.xEditGridCell116.Row = -1;
			// 
			// xEditGridCell117
			// 
			this.xEditGridCell117.CellName = "pre_modifier5";
			this.xEditGridCell117.Col = -1;
			this.xEditGridCell117.HeaderText = "pre_modifier5";
			this.xEditGridCell117.IsUpdatable = false;
			this.xEditGridCell117.IsVisible = false;
			this.xEditGridCell117.Row = -1;
			// 
			// xEditGridCell118
			// 
			this.xEditGridCell118.CellName = "pre_modifier6";
			this.xEditGridCell118.Col = -1;
			this.xEditGridCell118.HeaderText = "pre_modifier6";
			this.xEditGridCell118.IsUpdatable = false;
			this.xEditGridCell118.IsVisible = false;
			this.xEditGridCell118.Row = -1;
			// 
			// xEditGridCell119
			// 
			this.xEditGridCell119.CellName = "pre_modifier7";
			this.xEditGridCell119.Col = -1;
			this.xEditGridCell119.HeaderText = "pre_modifier7";
			this.xEditGridCell119.IsUpdatable = false;
			this.xEditGridCell119.IsVisible = false;
			this.xEditGridCell119.Row = -1;
			// 
			// xEditGridCell120
			// 
			this.xEditGridCell120.CellName = "pre_modifier8";
			this.xEditGridCell120.Col = -1;
			this.xEditGridCell120.HeaderText = "pre_modifier8";
			this.xEditGridCell120.IsUpdatable = false;
			this.xEditGridCell120.IsVisible = false;
			this.xEditGridCell120.Row = -1;
			// 
			// xEditGridCell121
			// 
			this.xEditGridCell121.CellName = "pre_modifier9";
			this.xEditGridCell121.Col = -1;
			this.xEditGridCell121.HeaderText = "pre_modifier9";
			this.xEditGridCell121.IsUpdatable = false;
			this.xEditGridCell121.IsVisible = false;
			this.xEditGridCell121.Row = -1;
			// 
			// xEditGridCell122
			// 
			this.xEditGridCell122.CellName = "pre_modifier10";
			this.xEditGridCell122.Col = -1;
			this.xEditGridCell122.HeaderText = "pre_modifier10";
			this.xEditGridCell122.IsUpdatable = false;
			this.xEditGridCell122.IsVisible = false;
			this.xEditGridCell122.Row = -1;
			// 
			// xEditGridCell123
			// 
			this.xEditGridCell123.CellName = "pre_modifier_name";
			this.xEditGridCell123.Col = -1;
			this.xEditGridCell123.HeaderText = "pre_modifier_name";
			this.xEditGridCell123.IsUpdatable = false;
			this.xEditGridCell123.IsVisible = false;
			this.xEditGridCell123.Row = -1;
			// 
			// xEditGridCell124
			// 
			this.xEditGridCell124.CellName = "post_modifier1";
			this.xEditGridCell124.Col = -1;
			this.xEditGridCell124.HeaderText = "post_modifier1";
			this.xEditGridCell124.IsUpdatable = false;
			this.xEditGridCell124.IsVisible = false;
			this.xEditGridCell124.Row = -1;
			// 
			// xEditGridCell127
			// 
			this.xEditGridCell127.CellName = "post_modifier2";
			this.xEditGridCell127.Col = -1;
			this.xEditGridCell127.HeaderText = "post_modifier2";
			this.xEditGridCell127.IsUpdatable = false;
			this.xEditGridCell127.IsVisible = false;
			this.xEditGridCell127.Row = -1;
			// 
			// xEditGridCell128
			// 
			this.xEditGridCell128.CellName = "post_modifier3";
			this.xEditGridCell128.Col = -1;
			this.xEditGridCell128.HeaderText = "post_modifier3";
			this.xEditGridCell128.IsUpdatable = false;
			this.xEditGridCell128.IsVisible = false;
			this.xEditGridCell128.Row = -1;
			// 
			// xEditGridCell129
			// 
			this.xEditGridCell129.CellName = "post_modifier4";
			this.xEditGridCell129.Col = -1;
			this.xEditGridCell129.HeaderText = "post_modifier4";
			this.xEditGridCell129.IsUpdatable = false;
			this.xEditGridCell129.IsVisible = false;
			this.xEditGridCell129.Row = -1;
			// 
			// xEditGridCell131
			// 
			this.xEditGridCell131.CellName = "post_modifier5";
			this.xEditGridCell131.Col = -1;
			this.xEditGridCell131.HeaderText = "post_modifier5";
			this.xEditGridCell131.IsUpdatable = false;
			this.xEditGridCell131.IsVisible = false;
			this.xEditGridCell131.Row = -1;
			// 
			// xEditGridCell132
			// 
			this.xEditGridCell132.CellName = "post_modifier6";
			this.xEditGridCell132.Col = -1;
			this.xEditGridCell132.HeaderText = "post_modifier6";
			this.xEditGridCell132.IsUpdatable = false;
			this.xEditGridCell132.IsVisible = false;
			this.xEditGridCell132.Row = -1;
			// 
			// xEditGridCell133
			// 
			this.xEditGridCell133.CellName = "post_modifier7";
			this.xEditGridCell133.Col = -1;
			this.xEditGridCell133.HeaderText = "post_modifier7";
			this.xEditGridCell133.IsUpdatable = false;
			this.xEditGridCell133.IsVisible = false;
			this.xEditGridCell133.Row = -1;
			// 
			// xEditGridCell134
			// 
			this.xEditGridCell134.CellName = "post_modifier8";
			this.xEditGridCell134.Col = -1;
			this.xEditGridCell134.HeaderText = "post_modifier8";
			this.xEditGridCell134.IsUpdatable = false;
			this.xEditGridCell134.IsVisible = false;
			this.xEditGridCell134.Row = -1;
			// 
			// xEditGridCell135
			// 
			this.xEditGridCell135.CellName = "post_modifier9";
			this.xEditGridCell135.Col = -1;
			this.xEditGridCell135.HeaderText = "post_modifier9";
			this.xEditGridCell135.IsUpdatable = false;
			this.xEditGridCell135.IsVisible = false;
			this.xEditGridCell135.Row = -1;
			// 
			// xEditGridCell136
			// 
			this.xEditGridCell136.CellName = "post_modifier10";
			this.xEditGridCell136.Col = -1;
			this.xEditGridCell136.HeaderText = "post_modifier10";
			this.xEditGridCell136.IsUpdatable = false;
			this.xEditGridCell136.IsVisible = false;
			this.xEditGridCell136.Row = -1;
			// 
			// xEditGridCell137
			// 
			this.xEditGridCell137.CellName = "post_modifier_name";
			this.xEditGridCell137.Col = -1;
			this.xEditGridCell137.HeaderText = "post_modifier_name";
			this.xEditGridCell137.IsUpdatable = false;
			this.xEditGridCell137.IsVisible = false;
			this.xEditGridCell137.Row = -1;
			// 
			// xEditGridCell138
			// 
			this.xEditGridCell138.CellName = "bulyong_check";
			this.xEditGridCell138.Col = -1;
			this.xEditGridCell138.HeaderText = "bulyong_check";
			this.xEditGridCell138.IsUpdatable = false;
			this.xEditGridCell138.IsVisible = false;
			this.xEditGridCell138.Row = -1;
			// 
			// xEditGridCell139
			// 
			this.xEditGridCell139.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell139.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.xEditGridCell139.AlterateRowImageIndex = 0;
			this.xEditGridCell139.CellName = "select";
			this.xEditGridCell139.CellWidth = 41;
			this.xEditGridCell139.Col = 1;
			this.xEditGridCell139.HeaderText = "選択";
			this.xEditGridCell139.ImageList = this.ImageList;
			this.xEditGridCell139.IsUpdatable = false;
			this.xEditGridCell139.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.xEditGridCell139.RowImageIndex = 0;
			this.xEditGridCell139.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
			this.xEditGridCell139.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
			// 
			// xEditGridCell248
			// 
			this.xEditGridCell248.CellName = "other_gwa";
			this.xEditGridCell248.Col = -1;
			this.xEditGridCell248.HeaderText = "other_gwa";
			this.xEditGridCell248.IsUpdatable = false;
			this.xEditGridCell248.IsUpdCol = false;
			this.xEditGridCell248.IsVisible = false;
			this.xEditGridCell248.Row = -1;
			// 
			// lblSelectSang
			// 
			this.lblSelectSang.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
			this.lblSelectSang.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblSelectSang.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblSelectSang.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
			this.lblSelectSang.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
			this.lblSelectSang.Image = ((System.Drawing.Image)(resources.GetObject("lblSelectSang.Image")));
			this.lblSelectSang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblSelectSang.ImageIndex = 0;
			this.lblSelectSang.ImageList = this.ImageList;
			this.lblSelectSang.Location = new System.Drawing.Point(0, 0);
			this.lblSelectSang.Name = "lblSelectSang";
			this.lblSelectSang.Size = new System.Drawing.Size(700, 24);
			this.lblSelectSang.TabIndex = 17;
			this.lblSelectSang.Text = " 全体選択";
			this.lblSelectSang.Click += new System.EventHandler(this.lblSelectSang_Click);
			
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 5000;
			this.toolTip1.InitialDelay = 10;
			this.toolTip1.ReshowDelay = 100;
			// 
			// xEditGridCell230
			// 
			this.xEditGridCell230.CellName = "cont_key";
			this.xEditGridCell230.Col = -1;
			this.xEditGridCell230.IsVisible = false;
			this.xEditGridCell230.Row = -1;
			// 
			// xEditGridCell231
			// 
			this.xEditGridCell231.CellName = "cont_key";
			this.xEditGridCell231.Col = -1;
			this.xEditGridCell231.IsVisible = false;
			this.xEditGridCell231.Row = -1;
			// 
			// xEditGridCell232
			// 
			this.xEditGridCell232.CellName = "cont_key";
			this.xEditGridCell232.Col = -1;
			this.xEditGridCell232.IsVisible = false;
			this.xEditGridCell232.Row = -1;
			// 
			// OCS2003Q00
			// 
			this.Controls.Add(this.pnlIn);
			this.Controls.Add(this.pnlOut);
			this.Controls.Add(this.xPanel3);
			this.Controls.Add(this.xPanel2);
			this.Controls.Add(this.xPanel1);
			this.Name = "OCS2003Q00";
			this.xPanel1.ResumeLayout(false);
			this.xPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
			this.xPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdOUT1001)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdOrdList)).EndInit();
			this.tabOrderGubun.ResumeLayout(false);
			this.xPanel4.ResumeLayout(false);
			this.pnlInput_gubun.ResumeLayout(false);
			this.pnlIn.ResumeLayout(false);
			this.pnlOrder.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdOCS2003)).EndInit();
			this.pnlJisi.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdOCS2005)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS2003)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dloOrder_danui)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS2005)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dloCheckLayout)).EndInit();
			this.pnlOut.ResumeLayout(false);
			this.pnlOutOrder.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).EndInit();
			this.pnlOutSang.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdOCS1001)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS1003)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS1001)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		
		public override object Command(string command, CommonItemCollection commandParam)
		{	
			return base.Command (command, commandParam);
		}

		protected override void OnLoad(EventArgs e)
		{	
			base.OnLoad (e);

			grdOCS2003.AutoSizeColumn(2, 0);
			grdOCS1003.AutoSizeColumn(2, 0);

			mOrderGubun = tabOrderGubun.SelectedTab.Tag.ToString();

			try
			{
				popupMenu.MenuCommands.Clear();
				popupMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "検査情報照会" : "검사정보조회", (Image)this.ImageList.Images[2], 
					new EventHandler(this.PopUpMenuGumsaInfo_Click)));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("bunho"))
					{
						if(TypeCheck.IsNull(OpenParam["bunho"].ToString().Trim()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が正確ではないです. 確認してください." : "환자번호가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
							XMessageBox.Show(mbxMsg, mbxCap);
							this.Close();
							return;
						}
						else
							mBunho = OpenParam["bunho"].ToString().Trim();
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が正確ではないです. 確認してください." : "환자번호가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);	
						this.Close();
						return;
					}

					if(OpenParam.Contains("fkinp1001"))
					{
						if(!TypeCheck.IsInt(OpenParam["fkinp1001"].ToString()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "入院情報が正確ではないです. 確認してください." : "입원정보가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
							XMessageBox.Show(mbxMsg, mbxCap);	
							this.Close();
							return;
						}
						else
							mFkinp1001 = int.Parse(OpenParam["fkinp1001"].ToString().Trim());
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "入院情報が正確ではないです. 確認してください." : "입원정보가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);	
						this.Close();
						return;
					}

					if(OpenParam.Contains("input_gubun"))
					{
						if(TypeCheck.IsNull(OpenParam["input_gubun"].ToString().Trim()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "入力区分が正確ではないです. 確認してください." : "입력구분이 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
							XMessageBox.Show(mbxMsg, mbxCap);
							this.Close();
							return;
						}
						else
							mInput_gubun = OpenParam["input_gubun"].ToString().Trim();
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "入力区分が正確ではないです. 確認してください." : "입력구분이 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);	
						this.Close();
						return;
					}					
					
					mGijun_date = DateTime.Now.ToString("yyyy/MM/dd");
					if(OpenParam.Contains("order_date"))
					{
						if(TypeCheck.IsDateTime(OpenParam["order_date"].ToString()))
							mGijun_date = OpenParam["order_date"].ToString();
					}
					dpkOrdList_date.SetDataValue(mGijun_date);

					//Data가 없는 경우 화면 닫을지 여부
					if(OpenParam.Contains("auto_close"))
					{
						mAuto_close = bool.Parse(OpenParam["auto_close"].ToString().Trim());
						if(mAuto_close) this.ParentForm.WindowState = FormWindowState.Minimized;
					}

					if(OpenParam.Contains("tel_yn"))
					{
						mTel_yn = OpenParam["tel_yn"].ToString().Trim();
					}

					if(TypeCheck.IsNull(mTel_yn))
						mTel_yn = "%";

				}
				catch (Exception ex)
				{
					XMessageBox.Show(ex.Message, "");	
					this.Close();
					return;
				}
			}
			else
			{
				mBunho = "00400032";
				mFkinp1001 = 38259;
				mGijun_date = DateTime.Now.ToString("yyyy/MM/dd");
				dpkOrdList_date.SetDataValue(mGijun_date);
				mInput_gubun = "D%";
			}
            
			InitialDesign();

			
			PostCallHelper.PostCall(new PostMethod(PostLoad));			
		}
        
		/// <summary>
		/// Load시 별도 Design할 부분이 있는 경우 여기서 Coding처리
		/// </summary>
		private void InitialDesign()
		{
			pnlInput_gubun.Controls.Clear();
			//Fixed column 설정
			this.grdOCS2003.FixedCols = 8; 
			this.grdOCS1003.FixedCols = 8; 

			// Dock 처리
			this.grdOrdList.Dock = DockStyle.Fill;			
			this.grdOUT1001.Dock = DockStyle.Fill;
			this.grdOUT1001.Visible =false;
			this.pnlIn.Dock = DockStyle.Fill;			
			this.pnlOut.Dock = DockStyle.Fill;			
			this.pnlOut.Visible = false;	

		}

		private void PostLoad()
		{	
			//comboBox생성
			CreateCombo();

			//DataLayout 생성
		    CreateLayout();

			//check layout
			//FormWindowState가 Normal로 돌아가면서 문제가 생겨서 check Layout으로 check
			if(mAuto_close)
			{
				dloCheckLayout = grdOrdList.CloneToLayout();
				dloCheckLayout.QuerySQL = this.qryLoadOrderDataList;
				this.dloCheckLayout.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dloCheckLayout_QueryStarting);

				if(!dloCheckLayout.QueryLayout(true))
					XMessageBox.Show("Err DloCheckLayout");

				if(dloCheckLayout.RowCount < 1)
				{
					dloCheckLayout.Dispose();
					dloSelectOCS2003.Dispose();
					dloSelectOCS2005.Dispose();
					dloSelectOCS1001.Dispose();
					dloSelectOCS1003.Dispose();
					this.Close();
				}
				else
					dloCheckLayout.Dispose();
			}
			
			if(mAuto_close) this.ParentForm.WindowState = FormWindowState.Normal;

			this.grdOrdList.QuerySQL = this.qryLoadOrderDataList;			 
			//외래처방리스트조회
			this.grdOUT1001.QuerySQL = this.qryLoadOUT1001;
			
			try
			{	
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				SetMsg("");
				
				if(!this.grdOrdList.QueryLayout(true))
					XMessageBox.Show("Err - grdOrdList Call ");

				if(!this.grdOUT1001.QueryLayout(true))
					XMessageBox.Show("Err - grdOUT1001 Call ");

			}
			finally
			{
				SetMsg(" ");
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}

		}
        
		/// <summary>
		/// DataLayout LayoutItems생성
		/// </summary>
		private void CreateLayout()
		{
			//OCS2003
			dloSelectOCS2003 = grdOCS2003.CloneToLayout();

			//OCS2005
			dloSelectOCS2005 = grdOCS2005.CloneToLayout();

			//OCS1001
			dloSelectOCS1001 = grdOCS1001.CloneToLayout();
			
			//OCS1003
			dloSelectOCS1003 = grdOCS1003.CloneToLayout();

			this.dloSelectOCS2003.QuerySQL = this.qryLoadOCS2003;
			this.dloSelectOCS2005.QuerySQL = this.qryLoadOCS2005;
			this.dloSelectOCS1001.QuerySQL = this.qryLoadOCS1001;
			this.dloSelectOCS1003.QuerySQL = this.qryLoadOCS1003;

			this.dloSelectOCS1003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dloSelectOCS1003_QueryStarting);
			this.dloSelectOCS1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dloSelectOCS1001_QueryStarting);
			this.dloSelectOCS2003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dloSelectOCS2003_QueryStarting);
			this.dloSelectOCS2005.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dloSelectOCS2005_QueryStarting);
		}

		/// <summary>
		/// 기준정보 DataLayout생성
		/// </summary>
		private void LoadBaseData()
		{
			//Order 단위
			this.dloOrder_danui.QuerySQL =  ""
				+ " SELECT CODE    "
				+ "   FROM OCS0132 "
				+ "  WHERE CODE_TYPE = 'ORD_DANUI' "
				+ "  ORDER BY 1 ";

			this.dloOrder_danui.QueryLayout(true);
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

			layoutCombo.QuerySQL= " SELECT CODE, CODE_NAME "
				+ "   FROM OCS0132 "
				+ "  WHERE CODE_TYPE = 'JUSA' "
				+ "  ORDER BY 1 ";

			if( layoutCombo.QueryLayout(true))
			{
				grdOCS2003.SetComboItems( "jusa", layoutCombo.LayoutTable, "code_name", "code");
				grdOCS1003.SetComboItems( "jusa", layoutCombo.LayoutTable, "code_name", "code");
			}
			
			//급여구분
			layoutCombo.Reset();
			layoutCombo.LayoutItems.Clear();
			layoutCombo.LayoutItems.Add("code", DataType.String);
			layoutCombo.LayoutItems.Add("code_name", DataType.String);
			layoutCombo.InitializeLayoutTable();
			
			layoutCombo.QuerySQL = " SELECT CODE, CODE_NAME"
				+ "   FROM BAS0102 "
				+ "  WHERE CODE_TYPE = 'PAY' "
				+ "  ORDER BY 1 ";
			
			if( layoutCombo.QueryLayout(true))
			{ 
				grdOCS2003.SetComboItems( "pay", layoutCombo.LayoutTable, "code_name", "code");	
				grdOCS1003.SetComboItems( "pay", layoutCombo.LayoutTable, "code_name", "code");
			}

		}
		#endregion
        
		#region [DataService Event]

		#region [입원]
		private void grdOrdList_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			
			if( e.IsSuccess )
			{
				//select 정보 reset			
//				dloSelectOCS2003.Reset();
//				dloSelectOCS2005.Reset();

				bool isSelect = false;
				for(int i = 0; i < grdOrdList.RowCount; i++)
				{
					string pk_order = grdOrdList.GetItemString(i, "pk_order");
					isSelect = false;

					if(tabOrderGubun.SelectedTab.Tag.ToString() == "1" )
					{
						if( dloSelectOCS2003.LayoutTable.Select( " pk_order_1 = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
					
						for(int j = 0; j < grdOCS2003.RowCount; j++)
						{
							if( grdOCS2003.GetItemString(j, "pk_order_1") == pk_order && grdOCS2003.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}
					}
					else if(tabOrderGubun.SelectedTab.Tag.ToString() == "2" )
					{
						if( dloSelectOCS2003.LayoutTable.Select( " pk_order_2 = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
					
						for(int j = 0; j < grdOCS2003.RowCount; j++)
						{
							if( grdOCS2003.GetItemString(j, "pk_order_2") == pk_order && grdOCS2003.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}
					}
					else if(tabOrderGubun.SelectedTab.Tag.ToString() == "3" )
					{
						if( dloSelectOCS2003.LayoutTable.Select( " pk_order_3 = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
					
						for(int j = 0; j < grdOCS2003.RowCount; j++)
						{
							if( grdOCS2003.GetItemString(j, "pk_order_3") == pk_order && grdOCS2003.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}
					}
					else if(tabOrderGubun.SelectedTab.Tag.ToString() == "4" )
					{
						if( dloSelectOCS2003.LayoutTable.Select( " pk_order_4 = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
					
						for(int j = 0; j < grdOCS2003.RowCount; j++)
						{
							if( grdOCS2003.GetItemString(j, "pk_order_4") == pk_order && grdOCS2003.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}
					}
					else if(tabOrderGubun.SelectedTab.Tag.ToString() == "5" )
					{
						if( dloSelectOCS2003.LayoutTable.Select( " pk_order_5 = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
					
						for(int j = 0; j < grdOCS2003.RowCount; j++)
						{
							if( grdOCS2003.GetItemString(j, "pk_order_5") == pk_order && grdOCS2003.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}
					}
					else if(tabOrderGubun.SelectedTab.Tag.ToString() == "6" )
					{
						if( dloSelectOCS2003.LayoutTable.Select( " pk_order_6 = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
					
						for(int j = 0; j < grdOCS2003.RowCount; j++)
						{
							if( grdOCS2003.GetItemString(j, "pk_order_6") == pk_order && grdOCS2003.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}
					}
					else if(tabOrderGubun.SelectedTab.Tag.ToString() == "7" )
					{
						if( dloSelectOCS2003.LayoutTable.Select( " pk_order_7 = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
					
						for(int j = 0; j < grdOCS2003.RowCount; j++)
						{
							if( grdOCS2003.GetItemString(j, "pk_order_7") == pk_order && grdOCS2003.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}
					}
					else
					{
						if( dloSelectOCS2005.LayoutTable.Select( " pk_order = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
						for(int j = 0; j < grdOCS2005.RowCount; j++)
						{
							if( grdOCS2005.GetItemString(j, "pk_order") == pk_order && grdOCS2005.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}
						if( dloSelectOCS2003.LayoutTable.Select( " pk_order = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
						for(int j = 0; j < grdOCS2003.RowCount; j++)
						{
							if( grdOCS2003.GetItemString(j, "pk_order") == pk_order && grdOCS2003.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}

					}

					if(isSelect)
						grdOrdList.SetItemValue(i, "select", " ");
				}

				SelectionBackColorChange(grdOrdList);
				this.DisplayListImage(grdOrdList);
			}
			else
			{
				XMessageBox.Show(e.ErrMsg);
			}
		}


		private void grdOCS2005_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{

			if( e.IsSuccess)
			{
				grdOCS2005.ClearFilter();

				string pk_order = grdOrdList.GetItemString(grdOrdList.CurrentRowNumber, "pk_order");
				///이전에 선택한 지시사항이 있으면 선택상태로
				foreach(DataRow row in dloSelectOCS2005.LayoutTable.Select( " pk_order = '" + pk_order + "' ", "") )
				{
					for(int i = 0; i < grdOCS2005.RowCount; i++)
					{
						if(grdOCS2005.GetItemString(i, "input_gubun") == row["input_gubun"].ToString() && grdOCS2005.GetItemString(i, "pk_seq") == row["pk_seq"].ToString())
							grdOCS2005.SetItemValue(i, "select", " ");
					}
				}
            
				//이전 선택정보를 삭제한다.
				for(int i = 0; i < dloSelectOCS2005.RowCount; i++)
				{
					if(dloSelectOCS2005.GetItemString(i, "pk_order") == pk_order)
					{
						dloSelectOCS2005.LayoutTable.Rows.Remove(dloSelectOCS2005.LayoutTable.Rows[i]);
						i = i -1;
					}
				}

				ShowInput_gubun();
			}
			else
			{
				XMessageBox.Show(e.ErrMsg);
			}
		}


		private void grdOCS2003_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			if( e.IsSuccess)
			{
				//지시사항은 안보이도록 수정 보이게 할 경우에는 여기서 input_gubun생성을 막는다.
				ShowInput_gubun();

				PostCallHelper.PostCall(new PostMethod(SelectOCS2003));	
			}
			else
			{
				XMessageBox.Show(e.ErrMsg);
			}
		}

		private void SelectOCS2003()
		{
			grdOCS2003.ClearFilter();			

			string pk_order = grdOrdList.GetItemString(grdOrdList.CurrentRowNumber, "pk_order");

			///이전에 선택한 Order가 있으면 선택상태로
			if(tabOrderGubun.SelectedTab.Tag.ToString() == "1" )
			{
				foreach(DataRow row in dloSelectOCS2003.LayoutTable.Select( " pk_order_1 = '" + pk_order + "' ", "" ) )
				{
					for(int i = 0; i < grdOCS2003.RowCount; i++)
					{
						if(grdOCS2003.GetItemString(i, "pkocs2003") == row["pkocs2003"].ToString())
							grdOCS2003.SetItemValue(i, "select", " ");
					}
				}
            
				//이전 선택정보를 삭제한다.
				for(int i = 0; i < dloSelectOCS2003.RowCount; i++)
				{
					if(dloSelectOCS2003.GetItemString(i, "pk_order_1") == pk_order )
					{
						dloSelectOCS2003.LayoutTable.Rows.Remove(dloSelectOCS2003.LayoutTable.Rows[i]);
						i = i -1;
					}
				}
			}
			else if(tabOrderGubun.SelectedTab.Tag.ToString() == "2")
			{
				foreach(DataRow row in dloSelectOCS2003.LayoutTable.Select( " pk_order_2 = '" + pk_order + "' ", "" ) )
				{
					for(int i = 0; i < grdOCS2003.RowCount; i++)
					{
						if(grdOCS2003.GetItemString(i, "pkocs2003") == row["pkocs2003"].ToString())
							grdOCS2003.SetItemValue(i, "select", " ");
					}
				}
            
				//이전 선택정보를 삭제한다.
				for(int i = 0; i < dloSelectOCS2003.RowCount; i++)
				{
					if(dloSelectOCS2003.GetItemString(i, "pk_order_2") == pk_order )
					{
						dloSelectOCS2003.LayoutTable.Rows.Remove(dloSelectOCS2003.LayoutTable.Rows[i]);
						i = i -1;
					}
				}
			}
			else if(tabOrderGubun.SelectedTab.Tag.ToString() == "3")
			{
				foreach(DataRow row in dloSelectOCS2003.LayoutTable.Select( " pk_order_3 = '" + pk_order + "' ", "" ) )
				{
					for(int i = 0; i < grdOCS2003.RowCount; i++)
					{
						if(grdOCS2003.GetItemString(i, "pkocs2003") == row["pkocs2003"].ToString())
							grdOCS2003.SetItemValue(i, "select", " ");
					}
				}
            
				//이전 선택정보를 삭제한다.
				for(int i = 0; i < dloSelectOCS2003.RowCount; i++)
				{
					if(dloSelectOCS2003.GetItemString(i, "pk_order_3") == pk_order )
					{
						dloSelectOCS2003.LayoutTable.Rows.Remove(dloSelectOCS2003.LayoutTable.Rows[i]);
						i = i -1;
					}
				}
			}
			else if(tabOrderGubun.SelectedTab.Tag.ToString() == "4" )
			{
				foreach(DataRow row in dloSelectOCS2003.LayoutTable.Select( " pk_order_4 = '" + pk_order + "' ", "" ) )
				{
					for(int i = 0; i < grdOCS2003.RowCount; i++)
					{
						if(grdOCS2003.GetItemString(i, "pkocs2003") == row["pkocs2003"].ToString())
							grdOCS2003.SetItemValue(i, "select", " ");
					}
				}
            
				//이전 선택정보를 삭제한다.
				for(int i = 0; i < dloSelectOCS2003.RowCount; i++)
				{
					if(dloSelectOCS2003.GetItemString(i, "pk_order_4") == pk_order )
					{
						dloSelectOCS2003.LayoutTable.Rows.Remove(dloSelectOCS2003.LayoutTable.Rows[i]);
						i = i -1;
					}
				}
			}
			else if(tabOrderGubun.SelectedTab.Tag.ToString() == "5")
			{
				foreach(DataRow row in dloSelectOCS2003.LayoutTable.Select( " pk_order_5 = '" + pk_order + "' ", "" ) )
				{
					for(int i = 0; i < grdOCS2003.RowCount; i++)
					{
						if(grdOCS2003.GetItemString(i, "pkocs2003") == row["pkocs2003"].ToString())
							grdOCS2003.SetItemValue(i, "select", " ");
					}
				}
            
				//이전 선택정보를 삭제한다.
				for(int i = 0; i < dloSelectOCS2003.RowCount; i++)
				{
					if(dloSelectOCS2003.GetItemString(i, "pk_order_5") == pk_order )
					{
						dloSelectOCS2003.LayoutTable.Rows.Remove(dloSelectOCS2003.LayoutTable.Rows[i]);
						i = i -1;
					}
				}
			}
			else if(tabOrderGubun.SelectedTab.Tag.ToString() == "6")
			{
				foreach(DataRow row in dloSelectOCS2003.LayoutTable.Select( " pk_order_6 = '" + pk_order + "' ", "" ) )
				{
					for(int i = 0; i < grdOCS2003.RowCount; i++)
					{
						if(grdOCS2003.GetItemString(i, "pkocs2003") == row["pkocs2003"].ToString())
							grdOCS2003.SetItemValue(i, "select", " ");
					}
				}
            
				//이전 선택정보를 삭제한다.
				for(int i = 0; i < dloSelectOCS2003.RowCount; i++)
				{
					if(dloSelectOCS2003.GetItemString(i, "pk_order_6") == pk_order )
					{
						dloSelectOCS2003.LayoutTable.Rows.Remove(dloSelectOCS2003.LayoutTable.Rows[i]);
						i = i -1;
					}
				}
			}
			else if(tabOrderGubun.SelectedTab.Tag.ToString() == "7")
			{
				foreach(DataRow row in dloSelectOCS2003.LayoutTable.Select( " pk_order_7 = '" + pk_order + "' ", "" ) )
				{
					for(int i = 0; i < grdOCS2003.RowCount; i++)
					{
						if(grdOCS2003.GetItemString(i, "pkocs2003") == row["pkocs2003"].ToString())
							grdOCS2003.SetItemValue(i, "select", " ");
					}
				}
            
				//이전 선택정보를 삭제한다.
				for(int i = 0; i < dloSelectOCS2003.RowCount; i++)
				{
					if(dloSelectOCS2003.GetItemString(i, "pk_order_7") == pk_order )
					{
						dloSelectOCS2003.LayoutTable.Rows.Remove(dloSelectOCS2003.LayoutTable.Rows[i]);
						i = i -1;
					}
				}
			}
			else
			{
				foreach(DataRow row in dloSelectOCS2003.LayoutTable.Select( " pk_order = '" + pk_order + "' ", "" ) )
				{
					for(int i = 0; i < grdOCS2003.RowCount; i++)
					{
						if(grdOCS2003.GetItemString(i, "pkocs2003") == row["pkocs2003"].ToString())
							grdOCS2003.SetItemValue(i, "select", " ");
					}
				}
            
				//이전 선택정보를 삭제한다.
				for(int i = 0; i < dloSelectOCS2003.RowCount; i++)
				{
					if(dloSelectOCS2003.GetItemString(i, "pk_order") == pk_order)
					{
						dloSelectOCS2003.LayoutTable.Rows.Remove(dloSelectOCS2003.LayoutTable.Rows[i]);
						i = i -1;
					}
				}
			}
            
			
            
			string input_gubun = "";
			if(pnlInput_gubun.Controls.Count > 0)
			{
				foreach( object obj in pnlInput_gubun.Controls)
				{
					if ( ((XRadioButton)obj).Checked )
					{
						input_gubun = ((XRadioButton)obj).Tag.ToString();
						break;
					}
				}

				if(grdOCS2003.RowCount > 0) grdOCS2003.SetFilter("input_gubun = '" + input_gubun + "' ");
				SelectionBackColorChange(grdOCS2003);
			}
			
			grdOCS2003.CustomScrollPosition = new Point(0, 0);
			
		}

		#endregion

		#region [외래]

		private void grdOUT1001_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			if( e.IsSuccess)
			{

				//select 정보 reset
//				dloSelectOCS1001.Reset();
//				dloSelectOCS1003.Reset();

				bool isSelect = false;
				for(int i = 0; i < grdOUT1001.RowCount; i++)
				{
					string pk_order = grdOUT1001.GetItemString(i, "pk_order");
					isSelect = false;

					if(tabOrderGubun.SelectedTab.Tag.ToString() == "1" )
					{
						if( dloSelectOCS1003.LayoutTable.Select( " pk_order_1 = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
					
						for(int j = 0; j < grdOCS1003.RowCount; j++)
						{
							if( grdOCS1003.GetItemString(j, "pk_order_1") == pk_order && grdOCS1003.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}
					}
					else if(tabOrderGubun.SelectedTab.Tag.ToString() == "2" )
					{
						if( dloSelectOCS1003.LayoutTable.Select( " pk_order_2 = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
					
						for(int j = 0; j < grdOCS1003.RowCount; j++)
						{
							if( grdOCS1003.GetItemString(j, "pk_order_2") == pk_order && grdOCS1003.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}
					}
					else if(tabOrderGubun.SelectedTab.Tag.ToString() == "3" )
					{
						if( dloSelectOCS1003.LayoutTable.Select( " pk_order_3 = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
					
						for(int j = 0; j < grdOCS1003.RowCount; j++)
						{
							if( grdOCS1003.GetItemString(j, "pk_order_3") == pk_order && grdOCS1003.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}
					}
					else if(tabOrderGubun.SelectedTab.Tag.ToString() == "4")
					{
						if( dloSelectOCS1003.LayoutTable.Select( " pk_order_4 = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
					
						for(int j = 0; j < grdOCS1003.RowCount; j++)
						{
							if( grdOCS1003.GetItemString(j, "pk_order_4") == pk_order && grdOCS1003.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}
					}
					else if(tabOrderGubun.SelectedTab.Tag.ToString() == "5")
					{
						if( dloSelectOCS1003.LayoutTable.Select( " pk_order_5 = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
					
						for(int j = 0; j < grdOCS1003.RowCount; j++)
						{
							if( grdOCS1003.GetItemString(j, "pk_order_5") == pk_order && grdOCS1003.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}
					}
					else if(tabOrderGubun.SelectedTab.Tag.ToString() == "6")
					{
						if( dloSelectOCS1003.LayoutTable.Select( " pk_order_6 = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
					
						for(int j = 0; j < grdOCS1003.RowCount; j++)
						{
							if( grdOCS1003.GetItemString(j, "pk_order_6") == pk_order && grdOCS1003.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}
					}
					else if(tabOrderGubun.SelectedTab.Tag.ToString() == "7")
					{
						if( dloSelectOCS1003.LayoutTable.Select( " pk_order_7 = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
					
						for(int j = 0; j < grdOCS1003.RowCount; j++)
						{
							if( grdOCS1003.GetItemString(j, "pk_order_7") == pk_order && grdOCS1003.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}
					}
					else
					{
						if( dloSelectOCS1001.LayoutTable.Select( " pk_order = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
						for(int j = 0; j < grdOCS1001.RowCount; j++)
						{
							if( grdOCS1001.GetItemString(j, "pk_order") == pk_order && grdOCS1001.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}
						if( dloSelectOCS1003.LayoutTable.Select( " pk_order = '" + pk_order + "' ", "").Length > 0 )
							isSelect = true;
						for(int j = 0; j < grdOCS1003.RowCount; j++)
						{
							if( grdOCS1003.GetItemString(j, "pk_order") == pk_order && grdOCS1003.GetItemString(j, "select") == " " )
							{
								isSelect = true;
								break;
							}
						}

					}

					if(isSelect)
						grdOUT1001.SetItemValue(i, "select", " ");
				}

				SelectionBackColorChange(grdOUT1001);
			}
			else
			{
				XMessageBox.Show(e.ErrMsg);
			}
		}

		private void grdOCS1001_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			if( e.IsSuccess)
			{
				string pk_order = grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "pk_order");
				///이전에 선택한 상병이 있으면 선택상태로
				foreach(DataRow row in dloSelectOCS1001.LayoutTable.Select( " pk_order = '" + pk_order + "' ", "") )
				{
					for(int i = 0; i < grdOCS1001.RowCount; i++)
					{
						if(grdOCS1001.GetItemString(i, "sang_code") == row["sang_code"].ToString())
							grdOCS1001.SetItemValue(i, "select", " ");
					}
				}
            
				//이전 선택정보를 삭제한다.
				for(int i = 0; i < dloSelectOCS1001.RowCount; i++)
				{
					if(dloSelectOCS1001.GetItemString(i, "pk_order") == pk_order)
					{
						dloSelectOCS1001.LayoutTable.Rows.Remove(dloSelectOCS1001.LayoutTable.Rows[i]);
						i = i -1;
					}
				}

				SelectionBackColorChange(grdOCS1001);
			}
			else
			{
				XMessageBox.Show(e.ErrMsg);
			}
		}

		private void grdOCS1003_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			if( e.IsSuccess )
			{
				string pk_order = grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "pk_order");
			
				///이전에 선택한 Order가 있으면 선택상태로
				if(tabOrderGubun.SelectedTab.Tag.ToString() == "1" )
				{
					foreach(DataRow row in dloSelectOCS1003.LayoutTable.Select( " pk_order_1 = '" + pk_order + "' ", "" ) )
					{
						for(int i = 0; i < grdOCS1003.RowCount; i++)
						{
							if(grdOCS1003.GetItemString(i, "pkocs1003") == row["pkocs1003"].ToString())
								grdOCS1003.SetItemValue(i, "select", " ");
						}
					}
            
					//이전 선택정보를 삭제한다.
					for(int i = 0; i < dloSelectOCS1003.RowCount; i++)
					{
						if(dloSelectOCS1003.GetItemString(i, "pk_order_1") == pk_order )
						{
							dloSelectOCS1003.LayoutTable.Rows.Remove(dloSelectOCS1003.LayoutTable.Rows[i]);
							i = i -1;
						}
					}
				}
				else if(tabOrderGubun.SelectedTab.Tag.ToString() == "2")
				{
					foreach(DataRow row in dloSelectOCS1003.LayoutTable.Select( " pk_order_2 = '" + pk_order + "' ", "" ) )
					{
						for(int i = 0; i < grdOCS1003.RowCount; i++)
						{
							if(grdOCS1003.GetItemString(i, "pkocs1003") == row["pkocs1003"].ToString())
								grdOCS1003.SetItemValue(i, "select", " ");
						}
					}
            
					//이전 선택정보를 삭제한다.
					for(int i = 0; i < dloSelectOCS1003.RowCount; i++)
					{
						if(dloSelectOCS1003.GetItemString(i, "pk_order_2") == pk_order )
						{
							dloSelectOCS1003.LayoutTable.Rows.Remove(dloSelectOCS1003.LayoutTable.Rows[i]);
							i = i -1;
						}
					}
				}
				else if(tabOrderGubun.SelectedTab.Tag.ToString() == "3")
				{
					foreach(DataRow row in dloSelectOCS1003.LayoutTable.Select( " pk_order_3 = '" + pk_order + "' ", "" ) )
					{
						for(int i = 0; i < grdOCS1003.RowCount; i++)
						{
							if(grdOCS1003.GetItemString(i, "pkocs1003") == row["pkocs1003"].ToString())
								grdOCS1003.SetItemValue(i, "select", " ");
						}
					}
            
					//이전 선택정보를 삭제한다.
					for(int i = 0; i < dloSelectOCS1003.RowCount; i++)
					{
						if(dloSelectOCS1003.GetItemString(i, "pk_order_3") == pk_order )
						{
							dloSelectOCS1003.LayoutTable.Rows.Remove(dloSelectOCS1003.LayoutTable.Rows[i]);
							i = i -1;
						}
					}
				}
				else if(tabOrderGubun.SelectedTab.Tag.ToString() == "4")
				{
					foreach(DataRow row in dloSelectOCS1003.LayoutTable.Select( " pk_order_4 = '" + pk_order + "' ", "" ) )
					{
						for(int i = 0; i < grdOCS1003.RowCount; i++)
						{
							if(grdOCS1003.GetItemString(i, "pkocs1003") == row["pkocs1003"].ToString())
								grdOCS1003.SetItemValue(i, "select", " ");
						}
					}
            
					//이전 선택정보를 삭제한다.
					for(int i = 0; i < dloSelectOCS1003.RowCount; i++)
					{
						if(dloSelectOCS1003.GetItemString(i, "pk_order_4") == pk_order )
						{
							dloSelectOCS1003.LayoutTable.Rows.Remove(dloSelectOCS1003.LayoutTable.Rows[i]);
							i = i -1;
						}
					}
				}
				else if(tabOrderGubun.SelectedTab.Tag.ToString() == "5")
				{
					foreach(DataRow row in dloSelectOCS1003.LayoutTable.Select( " pk_order_5 = '" + pk_order + "' ", "" ) )
					{
						for(int i = 0; i < grdOCS1003.RowCount; i++)
						{
							if(grdOCS1003.GetItemString(i, "pkocs1003") == row["pkocs1003"].ToString())
								grdOCS1003.SetItemValue(i, "select", " ");
						}
					}
            
					//이전 선택정보를 삭제한다.
					for(int i = 0; i < dloSelectOCS1003.RowCount; i++)
					{
						if(dloSelectOCS1003.GetItemString(i, "pk_order_5") == pk_order )
						{
							dloSelectOCS1003.LayoutTable.Rows.Remove(dloSelectOCS1003.LayoutTable.Rows[i]);
							i = i -1;
						}
					}
				}
				else if(tabOrderGubun.SelectedTab.Tag.ToString() == "6")
				{
					foreach(DataRow row in dloSelectOCS1003.LayoutTable.Select( " pk_order_6 = '" + pk_order + "' ", "" ) )
					{
						for(int i = 0; i < grdOCS1003.RowCount; i++)
						{
							if(grdOCS1003.GetItemString(i, "pkocs1003") == row["pkocs1003"].ToString())
								grdOCS1003.SetItemValue(i, "select", " ");
						}
					}
            
					//이전 선택정보를 삭제한다.
					for(int i = 0; i < dloSelectOCS1003.RowCount; i++)
					{
						if(dloSelectOCS1003.GetItemString(i, "pk_order_6") == pk_order )
						{
							dloSelectOCS1003.LayoutTable.Rows.Remove(dloSelectOCS1003.LayoutTable.Rows[i]);
							i = i -1;
						}
					}
				}
				else if(tabOrderGubun.SelectedTab.Tag.ToString() == "7")
				{
					foreach(DataRow row in dloSelectOCS1003.LayoutTable.Select( " pk_order_7 = '" + pk_order + "' ", "" ) )
					{
						for(int i = 0; i < grdOCS1003.RowCount; i++)
						{
							if(grdOCS1003.GetItemString(i, "pkocs1003") == row["pkocs1003"].ToString())
								grdOCS1003.SetItemValue(i, "select", " ");
						}
					}
            
					//이전 선택정보를 삭제한다.
					for(int i = 0; i < dloSelectOCS1003.RowCount; i++)
					{
						if(dloSelectOCS1003.GetItemString(i, "pk_order_7") == pk_order )
						{
							dloSelectOCS1003.LayoutTable.Rows.Remove(dloSelectOCS1003.LayoutTable.Rows[i]);
							i = i -1;
						}
					}
				}
				else
				{
					foreach(DataRow row in dloSelectOCS1003.LayoutTable.Select( " pk_order = '" + pk_order + "' ", "" ) )
					{
						for(int i = 0; i < grdOCS1003.RowCount; i++)
						{
							if(grdOCS1003.GetItemString(i, "pkocs1003") == row["pkocs1003"].ToString())
								grdOCS1003.SetItemValue(i, "select", " ");
						}
					}
            
					//이전 선택정보를 삭제한다.
					for(int i = 0; i < dloSelectOCS1003.RowCount; i++)
					{
						if(dloSelectOCS1003.GetItemString(i, "pk_order") == pk_order)
						{
							dloSelectOCS1003.LayoutTable.Rows.Remove(dloSelectOCS1003.LayoutTable.Rows[i]);
							i = i -1;
						}
					}
				}


				SelectionBackColorChange(grdOCS1003);
			}
			else
			{
				XMessageBox.Show(e.ErrMsg);
			}
		}

		#endregion

		#endregion

		#region [Return Layout 생성]

		private void CreateReturnLayout()
		{
			if(rbtIn.Checked)
				CreateReturnLayoutIn();
			else
				CreateReturnLayoutOut();
		}
        
		//날수 및 기타 기본정보변경
		private void CreateReturnLayoutIn()
		{
			this.AcceptData();

			//현재선택된 row trans		

			//OCS2003
			grdOCS2003.ClearFilter();
			grdOCS2005.ClearFilter();

			for(int i = 0; i < grdOCS2003.RowCount; i++)
			{
				if(grdOCS2003.GetItemString(i, "select") == " ")
					dloSelectOCS2003.LayoutTable.ImportRow(grdOCS2003.LayoutTable.Rows[i]);
			}

			//OCS2005
			for(int i = 0; i < grdOCS2005.RowCount; i++)
			{
				if(grdOCS2005.GetItemString(i, "select") == " ")
					dloSelectOCS2005.LayoutTable.ImportRow(grdOCS2005.LayoutTable.Rows[i]);
			}
		

			foreach(DataRow row in dloSelectOCS2003.LayoutTable.Rows)
			{
				//order 단위가 현재 존재하지 않는 경우
				if(row["ord_danui_check"].ToString() == "Y")
				{
					//order 단위가 없는 경우에는 SKip
					if(row["ord_danui"].ToString().Trim() == "") 
						break;
					else
					{
						if( !CheckOrd_danui(row["hangmog_code"].ToString(), row["ord_danui"].ToString()) )
							break;
					}
				}
				
				//order_gubun
				//header '0':정규
				row["order_gubun"] = "0" + row["order_gubun"].ToString().Substring(1, 1);
				
			}

			if(dloSelectOCS2003.LayoutTable.Rows.Count < 1 && dloSelectOCS2005.LayoutTable.Rows.Count < 1)
			{
				this.Close();
				return;
			}

			if(chkIsNewGroup.Checked)
				mIsNewGroupSer = true;
			else
				mIsNewGroupSer = false;
 
			
			//약속코드선택정보가 있는 경우 Return Value
			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "isnewgroup", mIsNewGroupSer  );
			commandParams.Add( "OCS2003"   , dloSelectOCS2003);
			commandParams.Add( "OCS2005"   , dloSelectOCS2005);
			commandParams.Add( "io_gubun"  , "I");
			scrOpener.Command(ScreenID, commandParams);

			this.Close();
		}

		//날수 및 기타 기본정보변경
		private void CreateReturnLayoutOut()
		{
			this.AcceptData();

			//현재선택된 row trans
			//OCS1001
			for(int i = 0; i < grdOCS1001.RowCount; i++)
			{
				if(grdOCS1001.GetItemString(i, "select") == " ")
					dloSelectOCS1001.LayoutTable.ImportRow(grdOCS1001.LayoutTable.Rows[i]);
			}

			//OCS1003
			for(int i = 0; i < grdOCS1003.RowCount; i++)
			{
				if(grdOCS1003.GetItemString(i, "select") == " ")
					dloSelectOCS1003.LayoutTable.ImportRow(grdOCS1003.LayoutTable.Rows[i]);
			}

			DataRow row;
			for(int i = 0; i < dloSelectOCS1003.RowCount; i++)
			{
				row = dloSelectOCS1003.LayoutTable.Rows[i];

				//order 단위가 현재 존재하지 않는 경우
				if(row["ord_danui_check"].ToString() == "Y")
				{
					//order 단위가 없는 경우에는 SKip
					if(row["ord_danui"].ToString().Trim() == "") 
					{
						dloSelectOCS1003.LayoutTable.Rows.Remove(row);
						i--;
						continue;
					}
					else
					{
						if( !CheckOrd_danui(row["hangmog_code"].ToString(), row["ord_danui"].ToString()) )
						{
							dloSelectOCS1003.LayoutTable.Rows.Remove(row);
							i--;
							continue;
						}
					}
				}
				
			
				//order_gubun
				//header '0':정규
				row["order_gubun"] = "0" + row["order_gubun"].ToString().Substring(1, 1);

				//원외는 다 원내로
				row["wonyoi_order_yn"] = "N";

				
			}

			if(dloSelectOCS1001.LayoutTable.Rows.Count < 1 && dloSelectOCS1003.LayoutTable.Rows.Count < 1)
				this.Close();

			if(chkIsNewGroup.Checked)
				mIsNewGroupSer = true;
			else
				mIsNewGroupSer = false;
 
			
			//약속코드선택정보가 있는 경우 Return Value
			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "isnewgroup", mIsNewGroupSer  );
			commandParams.Add( "OCS2001"   , dloSelectOCS1001);
			commandParams.Add( "OCS2003"   , dloSelectOCS1003);
			commandParams.Add( "io_gubun"  , "O");
			scrOpener.Command(ScreenID, commandParams);

			this.Close();
		}
		#endregion

		#region [ButtonList]

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:

					//select 정보 reset
					if( this.CurrMQLayout == grdOUT1001)
					{
						dloSelectOCS1001.Reset();
						dloSelectOCS1003.Reset();
					}

					if( this.CurrMQLayout == grdOrdList)
					{
						dloSelectOCS2005.Reset();
						dloSelectOCS2003.Reset();
					}

					break;

				case FunctionType.Close:

					dloSelectOCS2003.Dispose();
					dloSelectOCS2005.Dispose();
					dloSelectOCS1001.Dispose();
					dloSelectOCS1003.Dispose();

					this.mOrderBiz  = null;                      // OCS 그룹 Business 라이브러리
					this.mOrderFunc = null;                     // OCS 그룹 Function 라이브러리			
					this.mHangmogInfo = null;    // OCS 항목정보 그룹 라이브러리
					this.mInputControl = null;  // 입력제어 그룹 라이브러리 		
					break;

				default:

					break;
			}			
		}

		#endregion

		#region [grdOrdList Event]

		private void grdOrdList_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if(e.PreviousRow > -1)
			{
				//현재선택된 row trans
				//OCS2003
				grdOCS2003.ClearFilter();
				grdOCS2005.ClearFilter();

				for(int i = 0; i < grdOCS2003.RowCount; i++)
				{
					if(grdOCS2003.GetItemString(i, "select") == " ")
						dloSelectOCS2003.LayoutTable.ImportRow(grdOCS2003.LayoutTable.Rows[i]);
				}

				//OCS2005
				for(int i = 0; i < grdOCS2005.RowCount; i++)
				{
					if(grdOCS2005.GetItemString(i, "select") == " ")
						dloSelectOCS2005.LayoutTable.ImportRow(grdOCS2005.LayoutTable.Rows[i]);
				}
			}
		
			lblSelectOrder.ImageIndex = 0;
			lblSelectOrder.Text = " 全体選択";

			lblSelectDirect.ImageIndex = 0;
			lblSelectDirect.Text = " 全体選択";
			
		}
		
		private void grdOrdList_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			DisplayListImage(grdOrdList);
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
					if      (aGrd.GetItemValue(i, "toiwon_drg").ToString().Trim() == "Y") // 퇴원약
					{
						aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];
						aGrd[i + aGrd.HeaderHeights.Count, 0].ToolTipText = aGrd[i + aGrd.HeaderHeights.Count, 0].ToolTipText + (NetInfo.Language == LangMode.Jr ? "退院薬" : "퇴원약");
					}					
				}
			}
			catch{}
			finally
			{
				
			}
		}

		#endregion

		#region [grdOCS2003 Event]

		private void grdOCS2003_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if(e.DataRow["bulyong_check"].ToString() == "Y" || e.DataRow["bulyong_check"].ToString() == "Z" )
			{
				e.BackColor = ((XEditGridCell)grdOCS2003.CellInfos[e.ColName]).RowBackColor.Color;
				e.ForeColor = Color.Red;
			}
			else if(e.DataRow["other_gwa"].ToString() == "Y")
			{
				e.BackColor = ((XEditGridCell)grdOCS2003.CellInfos[e.ColName]).RowBackColor.Color;
				e.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			}
		}

		private void grdOCS2003_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int rowIndex;
			if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				rowIndex = grdOCS2003.GetHitRowNumber(e.Y);				
				if(rowIndex < 0) return;

				if(grdOCS2003.CurrentColNumber == 0)
				{
					//불용처리된 것은 선택을 막는다.
					if(grdOCS2003.GetItemString(rowIndex, "bulyong_check") == "Y") 
					{
						//불용인 경우에는 해당 항목의 심사기준을 보여준다.
						mbxMsg = this.mOrderBiz.LoadSimsa_comment(grdOCS2003.GetItemString(rowIndex, "hangmog_code")); 
						mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
						if( !TypeCheck.IsNull(mbxMsg) ) XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);

						return;
					}

					if(grdOCS2003.GetItemString(rowIndex, "select") == "")
					{
						grdOCS2003.SetItemValue(rowIndex, "select", " ");
						SelectionBackColorChange(sender, rowIndex, "Y");
					}
					else
					{
						grdOCS2003.SetItemValue(rowIndex, "select", "");
						SelectionBackColorChange(sender, rowIndex, "N");
					}

					SetSelectOrdList();
				}
			}	
			else if (e.Button == MouseButtons.Right && e.Clicks == 1)
			{
				rowIndex = grdOCS2003.GetHitRowNumber(e.Y);
				if(rowIndex < 0) return;

				if(grdOCS2003.GetItemString(rowIndex, "slip_code").Substring(0, 1) != "B") return;

				popupMenu.TrackPopup(((IHIS.Framework.XEditGrid)sender).PointToScreen(new Point(e.X,e.Y)));
			}
		}

		private void grdOCS2003_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
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

		#region [grdOCS2005 Event]

		private void grdOCS2005_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				int rowIndex = grdOCS2005.GetHitRowNumber(e.Y);				
				if(rowIndex < 0) return;

				if(grdOCS2005.CurrentColNumber == 0)
				{
					if(grdOCS2005.GetItemString(rowIndex, "select") == "")
					{
						grdOCS2005.SetItemValue(rowIndex, "select", " ");
						SelectionBackColorChange(sender, rowIndex, "Y");
					}
					else
					{
						grdOCS2005.SetItemValue(rowIndex, "select", "");
						SelectionBackColorChange(sender, rowIndex, "N");
					}

					SetSelectOrdList();
				}
			}	
		
		}        

		#endregion

		#region [grdOUT1001 Event]

		private void grdOUT1001_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if(e.PreviousRow > -1)
			{
				//현재선택된 row trans
				//OCS1001
				for(int i = 0; i < grdOCS1001.RowCount; i++)
				{
					if(grdOCS1001.GetItemString(i, "select") == " ")
						dloSelectOCS1001.LayoutTable.ImportRow(grdOCS1001.LayoutTable.Rows[i]);
				}

				//OCS1003
				for(int i = 0; i < grdOCS1003.RowCount; i++)
				{
					if(grdOCS1003.GetItemString(i, "select") == " ")
						dloSelectOCS1003.LayoutTable.ImportRow(grdOCS1003.LayoutTable.Rows[i]);
				}
			}

			lblSelectSang.ImageIndex = 0;
			lblSelectSang.Text = " 全体選択";

			lblSelectOrder.ImageIndex = 0;
			lblSelectOrder.Text = " 全体選択";
		}		

		#endregion

		#region [grdOCS1001 Event]

		private void grdOCS1001_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				int rowIndex = grdOCS1001.GetHitRowNumber(e.Y);				
				if(rowIndex < 0) return;

				if(grdOCS1001.CurrentColNumber == 0)
				{
					//종료된 상병은 선택을 막는다.
					if(grdOCS1001.GetItemString(rowIndex, "bulyong_check") == "Y") return;

					if(grdOCS1001.GetItemString(rowIndex, "select") == "")
					{
						grdOCS1001.SetItemValue(rowIndex, "select", " ");
						SelectionBackColorChange(sender, rowIndex, "Y");
					}
					else
					{
						grdOCS1001.SetItemValue(rowIndex, "select", "");
						SelectionBackColorChange(sender, rowIndex, "N");
					}

					SetSelectNaewon();
				}
			}		
		}	

		private void grdOCS1001_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			if(e.DataRow["bulyong_check"].ToString() == "Y")
			{
				e.BackColor = ((XEditGridCell)grd.CellInfos[e.ColName]).RowBackColor.Color;
				e.ForeColor = Color.Red;
			}

			// 상병종료일이 입력되지 않은 경우는 종료사유 입력 불가
			switch (e.ColName)
			{
				case "display_sang_name": // Display 상병명
					
					// 암 관련 상병명 암 표현법 (癌표시를 CA로 표시함) 
					grd[e.RowNumber, e.ColName].DisplayText = this.mOrderBiz.DisplayCancerSangName(OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items["input_part"].ToString(), grd[e.RowNumber, e.ColName].DisplayText);

					break;		
			}
		}


		#endregion

		#region [grdOCS1003 Event]

		private void grdOCS1003_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if(e.DataRow["bulyong_check"].ToString() == "Y" || e.DataRow["bulyong_check"].ToString() == "Z" )
			{
				e.BackColor = ((XEditGridCell)grdOCS1003.CellInfos[e.ColName]).RowBackColor.Color;
				e.ForeColor = Color.Red;
			}
		}

		private void grdOCS1003_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int rowIndex;

			if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				rowIndex = grdOCS1003.GetHitRowNumber(e.Y);				
				if(rowIndex < 0) return;

				if(grdOCS1003.CurrentColNumber == 0)
				{
					//불용처리된 것은 선택을 막는다.
					if(grdOCS1003.GetItemString(rowIndex, "bulyong_check") == "Y")
					{
						//불용인 경우에는 해당 항목의 심사기준을 보여준다.
						mbxMsg = this.mOrderBiz.LoadSimsa_comment(grdOCS1003.GetItemString(rowIndex, "hangmog_code")); 
						mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
						if( !TypeCheck.IsNull(mbxMsg) ) XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);

						return;
					}

					if(grdOCS1003.GetItemString(rowIndex, "select") == "")
					{
						grdOCS1003.SetItemValue(rowIndex, "select", " ");
						SelectionBackColorChange(sender, rowIndex, "Y");
					}
					else
					{
						grdOCS1003.SetItemValue(rowIndex, "select", "");
						SelectionBackColorChange(sender, rowIndex, "N");
					}

					SetSelectNaewon();
				}
			}	
			else if (e.Button == MouseButtons.Right && e.Clicks == 1)
			{
				rowIndex = grdOCS1003.GetHitRowNumber(e.Y);
				if(rowIndex < 0) return;

				if(grdOCS1003.GetItemString(rowIndex, "slip_code").Substring(0, 1) != "B") return;

				popupMenu.TrackPopup(((IHIS.Framework.XEditGrid)sender).PointToScreen(new Point(e.X,e.Y)));
			}
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

		private void dpkOrdList_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			string bunho = mBunho;
			string fkInp1001 = mFkinp1001.ToString();
			string orderDate = e.DataValue;
			string inputGubun = mInput_gubun;
			string telYN = mTel_yn;
			string orderGubun = mOrderGubun;

			if( inputGubun == "D" )
				inputGubun = "D%";

		

			try
			{	
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				SetMsg("");

				
				dloSelectOCS2005.Reset();
				dloSelectOCS2003.Reset();
				
				dloSelectOCS1001.Reset();
				dloSelectOCS1003.Reset();

				this.grdOrdList.QuerySQL = this.qryLoadOrderDataList;
			 
				//외래처방리스트조회
				this.grdOUT1001.QuerySQL = this.qryLoadOUT1001;
			
				grdOrdList.QueryLayout(true);
					
				grdOUT1001.QueryLayout(true);
					
				
			}
			finally
			{
				SetMsg(" ");
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}

		private void SetSelectOrdList()
		{
			int  currentRow = grdOrdList.CurrentRowNumber;
			bool select     = false;

			// OCS2003
			for(int i = 0; i < grdOCS2003.RowCount; i++)
			{
				if( grdOCS2003.GetItemString(i, "select") != " " ) continue;
				select = true;
				break;
			}

			// OCS2005
			for(int i = 0; i < grdOCS2005.RowCount; i++)
			{
				if( grdOCS2005.GetItemString(i, "select") != " " ) continue;
				select = true;
				break;
			}

			if(select)
			{
				grdOrdList.SetItemValue(currentRow, "select", " ");
				SelectionBackColorChange(grdOrdList, currentRow, "Y");
			}
			else
			{
				grdOrdList.SetItemValue(currentRow, "select", "");
				SelectionBackColorChange(grdOrdList, currentRow, "N");
			}
		}

		private void SetSelectNaewon()
		{
			int  currentRow = grdOUT1001.CurrentRowNumber;
			bool select     = false;

			// OCS1001
			for(int i = 0; i < grdOCS1001.RowCount; i++)
			{
				if( grdOCS1001.GetItemString(i, "select") != " " ) continue;
				select = true;
				break;
			}

			// OCS1003
			for(int i = 0; i < grdOCS1003.RowCount; i++)
			{
				if( grdOCS1003.GetItemString(i, "select") != " " ) continue;
				select = true;
				break;
			}

			if(select)
			{
				grdOUT1001.SetItemValue(currentRow, "select", " ");
				SelectionBackColorChange(grdOUT1001, currentRow, "Y");
			}
			else
			{
				grdOUT1001.SetItemValue(currentRow, "select", "");
				SelectionBackColorChange(grdOUT1001, currentRow, "N");
			}
		}
		
		
		#endregion

		#region [Input_gubun RadioBotton 생성]
        
		const int INPUT_GUBUN_WIDTH  = 112;
		const int INPUT_GUBUN_HEIGHT = 26;		

		private void ShowInput_gubun()
		{
			pnlInput_gubun.Controls.Clear();

			IHIS.Framework.MultiLayout    layInput_gubun = new MultiLayout();            
			layInput_gubun.Reset();
			layInput_gubun.LayoutItems.Clear();
			layInput_gubun.LayoutItems.Add("input_gubun"     , DataType.String);
			layInput_gubun.LayoutItems.Add("input_gubun_name", DataType.String);
			layInput_gubun.InitializeLayoutTable();
            
			string input_gubun  = "";
			int    insertRowNum;

			foreach(DataRow row in grdOCS2003.LayoutTable.Rows)
			{
				if(input_gubun != row["input_gubun"].ToString())
				{
					insertRowNum = layInput_gubun.InsertRow(-1);
					layInput_gubun.SetItemValue(insertRowNum, "input_gubun"     , row["input_gubun"]     );
					layInput_gubun.SetItemValue(insertRowNum, "input_gubun_name", row["input_gubun_name"]);
					input_gubun = row["input_gubun"].ToString();
				}
			}
            
			//지시사항의 Input_gubun
			input_gubun = "";
			foreach(DataRow row in grdOCS2005.LayoutTable.Rows)
			{
				if(input_gubun != row["input_gubun"].ToString() && layInput_gubun.LayoutTable.Select(" input_gubun = '" + row["input_gubun"].ToString() + "' ", "").Length == 0 )
				{
					insertRowNum = layInput_gubun.InsertRow(-1);
					layInput_gubun.SetItemValue(insertRowNum, "input_gubun"     , row["input_gubun"]     );
					layInput_gubun.SetItemValue(insertRowNum, "input_gubun_name", row["input_gubun_name"]);
					input_gubun = row["input_gubun"].ToString();
				}
			}

			XRadioButton rbtInput_gubun;

			int startX = 2;

			foreach(DataRow row in layInput_gubun.LayoutTable.Select("", "input_gubun ASC"))
			{
				if(input_gubun != row["input_gubun"].ToString())
				{
					rbtInput_gubun = new XRadioButton();
					rbtInput_gubun.Appearance = System.Windows.Forms.Appearance.Button;
					rbtInput_gubun.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
					rbtInput_gubun.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
					rbtInput_gubun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
					rbtInput_gubun.ImageList = this.ImageList;
					rbtInput_gubun.ImageIndex = 0;			
					rbtInput_gubun.Location = new System.Drawing.Point(startX, 2);
					rbtInput_gubun.Name = "rbt" + row["input_gubun"];
					rbtInput_gubun.Size = new System.Drawing.Size(112, 26);			
					rbtInput_gubun.Text = "     " + row["input_gubun_name"].ToString();
					rbtInput_gubun.Tag  = row["input_gubun"].ToString();
					rbtInput_gubun.Click += new System.EventHandler(this.rbtInput_gubun_Click);
                    pnlInput_gubun.Controls.Add(rbtInput_gubun);
					
					startX = startX + INPUT_GUBUN_WIDTH;
					input_gubun = row["input_gubun"].ToString();
				}
			}
            
			if(pnlInput_gubun.Controls.Count > 0)
				rbtInput_gubun_Click(pnlInput_gubun.Controls[0], null);			
		}

		private void rbtInput_gubun_Click(object sender, System.EventArgs e)
		{
			XRadioButton rbt = sender as XRadioButton;

			foreach( object obj in pnlInput_gubun.Controls)
			{
				if( ((XRadioButton)obj).Name == rbt.Name )
				{
					 ((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
					 ((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
					 ((XRadioButton)obj).ImageIndex = 1;

					 if ( !((XRadioButton)obj).Checked )
						 ((XRadioButton)obj).Checked = true;

				}
				else
				{
					((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
					((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
					((XRadioButton)obj).ImageIndex = 0;  

					if ( ((XRadioButton)obj).Checked )
						((XRadioButton)obj).Checked = false;
				}
			}

			//해당 input_gubun filter
			string input_gubun = rbt.Tag.ToString();
			grdOCS2003.ClearFilter();
			if(grdOCS2003.RowCount > 0) grdOCS2003.SetFilter("input_gubun = '" + input_gubun + "' ");
            
			grdOCS2005.ClearFilter();
			if(grdOCS2005.RowCount > 0) grdOCS2005.SetFilter("input_gubun = '" + input_gubun + "' ");

			SelectionBackColorChange(grdOCS2003);
			SelectionBackColorChange(grdOCS2005);

		}
		#endregion

		#region [Cotrol Event]

		private void lblSelectDirect_Click(object sender, System.EventArgs e)
		{
			if(lblSelectDirect.ImageIndex == 0)
			{
				grdSelectAll(grdOCS2005, true);
				lblSelectDirect.ImageIndex = 1;
				lblSelectDirect.Text = " 全体選択取消";
			}
			else
			{
				grdSelectAll(grdOCS2005, false);
				lblSelectDirect.ImageIndex = 0;
				lblSelectDirect.Text = " 全体選択";
			}		
		
		}

		private void lblSelectOrder_Click(object sender, System.EventArgs e)
		{
			if(lblSelectOrder.ImageIndex == 0)
			{
				grdSelectAll(grdOCS2003, true);
				lblSelectOrder.ImageIndex = 1;
				lblSelectOrder.Text = " 全体選択取消";
			}
			else
			{
				grdSelectAll(grdOCS2003, false);
				lblSelectOrder.ImageIndex = 0;
				lblSelectOrder.Text = " 全体選択";
			}
		}

		private void lblSelectSang_Click(object sender, System.EventArgs e)
		{
			if(lblSelectSang.ImageIndex == 0)
			{
				grdSelectAll(grdOCS1001, true);
				lblSelectSang.ImageIndex = 1;
				lblSelectSang.Text = " 全体選択取消";
			}	
			else
			{
				grdSelectAll(grdOCS1001, false);
				lblSelectSang.ImageIndex = 0;
				lblSelectSang.Text = " 全体選択";
			}
		}

		private void lblSelectOutOrder_Click(object sender, System.EventArgs e)
		{
			if(lblSelectOrder.ImageIndex == 0)
			{
				grdSelectAll(grdOCS1003, true);
				lblSelectOrder.ImageIndex = 1;
				lblSelectOrder.Text = " 全体選択取消";
			}
			else
			{
				grdSelectAll(grdOCS1003, false);
				lblSelectOrder.ImageIndex = 0;
				lblSelectOrder.Text = " 全体選択";
			}
		}
        
		/// <summary>
		/// 해당 Grid 전체선택 해제
		/// </summary>
		/// <param name="grd"></param>
		/// <param name="select"></param>
		private void grdSelectAll(XGrid grdObject, bool select)
		{
			int rowIndex = -1;

			if(select)
			{
				for(rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
				{
					if(grdObject.GetItemString( rowIndex, "bulyong_check") != "Y" ) grdObject.SetItemValue(rowIndex, "select", " ");
				}
			}
			else
			{
				for(rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
				{
					if(grdObject.GetItemString( rowIndex, "bulyong_check") != "Y" ) grdObject.SetItemValue(rowIndex, "select", "");
				}
			}

			SelectionBackColorChange(grdObject);
            
			//선택된 Row 표시
			SetSelectOrdList();

		}

		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			CreateReturnLayout();

		}	
	
		private void chkIsNewGroup_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkIsNewGroup.Checked)
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
		

		#endregion

		#region [처방단위 CHECK]
        
		private bool CheckOrd_danui(string hangmog_code, string ord_danui)
		{
			bool chkExists = false;

			string cmdText = ""
				+ " SELECT FN_OCS_EXISTS_ORD_DANUI('" + hangmog_code + "', '" + ord_danui + "') "
				+ "   FROM DUAL ";

			object retVal = Service.ExecuteScalar(cmdText);

			if( retVal == null )
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
								aGrd.GetItemValue(i, "group_ser"  ).ToString().Trim() == aGrd.GetItemValue(j, "group_ser"  ).ToString().Trim() &&
								aGrd.GetItemValue(i, "mix_group"  ).ToString().Trim() == aGrd.GetItemValue(j, "mix_group"  ).ToString().Trim() &&
								aGrd.GetItemValue(i, "hope_date"  ).ToString().Trim() == aGrd.GetItemValue(j, "hope_date"  ).ToString().Trim())
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
			if(data == "Y")
			{
				//image 변경
				if(grdObject.RowHeaderVisible) 
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];					
				else 
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];		
			}
			else
			{
				//image 변경
				if(grdObject.RowHeaderVisible) 
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];					
				else 
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];		
			}

			for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
			{
				if(data == "Y")
				{
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
				}
				else 
				{
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;					

					if(grdObject.GetItemString(currentRowIndex, "other_gwa").ToString() != "Y") 
						grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
					else
						grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
				}
			}
		}

	
		
		private void SelectionBackColorChange(object grid)
		{
			XEditGrid grdObject = (XEditGrid)grid;

			//기존의 색으로 변경을 시킨다
			for(int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
			{
				//불용은 넘어간다.
				if(grdObject.CellInfos.Contains("bulyong_check") && grdObject.GetItemString(rowIndex, "bulyong_check") == "Y" ) continue;

				if(grdObject.GetItemString(rowIndex, "select").ToString() == " ")
				{
					//image 변경
					if(grdObject.RowHeaderVisible) 
						grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];					
					else 
						grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];				

					//ColorYn Y :색을 변경, N :색을 변경 해제
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
					}
				}
				else
				{
					//image 변경
					if(grdObject.RowHeaderVisible) 
						grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];					
					else 
						grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];	

					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{						
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
						if(grdObject.GetItemString(rowIndex, "other_gwa").ToString() != "Y") 
							grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
						else
							grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);

					}
				}
			}

			if( grdObject.Name == "grdOCS2003") DiaplayMixGroup(grdObject);
		}
		#endregion

		#region [외래/입원전환]

		private void rbtIn_CheckedChanged(object sender, System.EventArgs e)
		{
			//외래
			if(rbtOut.Checked)
			{
				rbtOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
				rbtOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
				rbtOut.ImageIndex = 1;

				rbtIn.BackColor = System.Drawing.SystemColors.InactiveCaption;
				rbtIn.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				rbtIn.ImageIndex = 0;

				grdOrdList.Visible = false;
				pnlIn.Visible = false;
				grdOUT1001.Visible = true;
				pnlOut.Visible = true;

			}
				//입원
			else
			{				
				rbtIn.BackColor = System.Drawing.SystemColors.ActiveCaption;
				rbtIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
				rbtIn.ImageIndex = 1;

				rbtOut.BackColor = System.Drawing.SystemColors.InactiveCaption;
				rbtOut.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				rbtOut.ImageIndex = 0;

				grdOUT1001.Visible = false;
				pnlOut.Visible = false;
				grdOrdList.Visible = true;
				pnlIn.Visible = true;
			}
		
		}

		#endregion
				
		#region Order_gubun Tab 변경
		/// <summary>
		/// tab 변경시 해당 처방조회
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tabOrderGubun_SelectionChanged(object sender, System.EventArgs e)
		{
			if( tabOrderGubun.SelectedTab == null ) return;

			//현재선택된 row trans
			//OCS2003
			grdOCS2003.ClearFilter();
			grdOCS2005.ClearFilter();

			for(int i = 0; i < grdOCS2003.RowCount; i++)
			{
				if(grdOCS2003.GetItemString(i, "select") == " ")
					dloSelectOCS2003.LayoutTable.ImportRow(grdOCS2003.LayoutTable.Rows[i]);
			}

			//OCS2005
			for(int i = 0; i < grdOCS2005.RowCount; i++)
			{
				if(grdOCS2005.GetItemString(i, "select") == " ")
					dloSelectOCS2005.LayoutTable.ImportRow(grdOCS2005.LayoutTable.Rows[i]);
			}

			//OCS1001
			for(int i = 0; i < grdOCS1001.RowCount; i++)
			{
				if(grdOCS1001.GetItemString(i, "select") == " ")
					dloSelectOCS1001.LayoutTable.ImportRow(grdOCS1001.LayoutTable.Rows[i]);
			}

			//OCS1003
			for(int i = 0; i < grdOCS1003.RowCount; i++)
			{
				if(grdOCS1003.GetItemString(i, "select") == " ")
					dloSelectOCS1003.LayoutTable.ImportRow(grdOCS1003.LayoutTable.Rows[i]);
			}

			foreach( IHIS.X.Magic.Controls.TabPage page in tabOrderGubun.TabPages)
			{
				if(tabOrderGubun.SelectedTab == page)
					page.ImageIndex = 1;
				else
					page.ImageIndex = 0;
			}

			//검사인 경우에는 실시일 기준으로 조회한다.
			if(tabOrderGubun.SelectedTab.Tag.ToString() == "4" || tabOrderGubun.SelectedTab.Tag.ToString() == "5" )
			{
				
				grdOUT1001[0, grdOUT1001.CellInfos["naewon_date"].Col].Value = NetInfo.Language == LangMode.Jr ? "日付" : "일자";
				grdOrdList[0, grdOrdList.CellInfos["order_date"].Col].Value = NetInfo.Language == LangMode.Jr ? "日付" : "일자";
				this.grdOUT1001.AutoSizeColumn(4, 0);
				this.grdOUT1001.AutoSizeColumn(5, 0);

				grdOCS2003.AutoSizeColumn(2, 80);
				grdOCS1003.AutoSizeColumn(2, 80);
				
				this.grdOrdList.QuerySQL = this.qryLoadGumsaOrderDataList;
				this.grdOCS2003.QuerySQL = this.qryLoadGumsaOCS2003;
				this.grdOUT1001.QuerySQL = this.qryLoadGumsaOUT1001;
				this.grdOCS1003.QuerySQL = this.qryLoadGumsaOCS1003;
				
				this.pnlOutSang.Visible= false;
				this.sptOut.Visible= false;

			}
			else
			{
				grdOUT1001[0, grdOUT1001.CellInfos["naewon_date"].Col].Value = NetInfo.Language == LangMode.Jr ? "オ―ダ日付" : "Order일자";
				grdOrdList[0, grdOrdList.CellInfos["order_date"].Col].Value = NetInfo.Language == LangMode.Jr ? "オ―ダ日付" : "Order일자";
				this.grdOUT1001.AutoSizeColumn(4, 80);
				this.grdOUT1001.AutoSizeColumn(5, 80);

				grdOCS2003.AutoSizeColumn(2, 0);
				grdOCS1003.AutoSizeColumn(2, 0);

				this.grdOrdList.QuerySQL = this.qryLoadOrderDataList;
				this.grdOCS2003.QuerySQL = this.qryLoadOCS2003;
				this.grdOUT1001.QuerySQL = this.qryLoadOUT1001;
				this.grdOCS1003.QuerySQL = this.qryLoadOCS1003;
				
				this.pnlOutSang.Visible= true;
				this.sptOut.Visible= true;
			}

			this.mOrderGubun = tabOrderGubun.SelectedTab.Tag.ToString();
			
			try
			{	
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				SetMsg("");

				if(!this.grdOrdList.QueryLayout(true))
					XMessageBox.Show("Err - grdOrdList Call! ");

				if(!this.grdOUT1001.QueryLayout(true))
					XMessageBox.Show("Err - grdOUT1001 Call! ");
				
			}
			finally
			{
				SetMsg(" ");
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}

		#endregion

		#region [검사정보조회]

		// 검사정보조회
		private void PopUpMenuGumsaInfo_Click(object sender, System.EventArgs e)
		{
			if(this.CurrMQLayout == null || CurrMQLayout.CurrentRowNumber < 0) return;

			CommonItemCollection openParams  = new CommonItemCollection();
			openParams.Add("hangmog_code", CurrMQLayout.GetItemValue(CurrMQLayout.CurrentRowNumber, "hangmog_code"));
			XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q01", ScreenOpenStyle.ResponseFixed, openParams);			
		}

		#endregion

		#region QueryStarting BindVar 변수 셋팅 

		private void grdOrdList_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string inputGubun = mInput_gubun;

			if( inputGubun == "D")
				inputGubun = "D%";

			this.grdOrdList.SetBindVarValue("f_bunho", this.mBunho);
			this.grdOrdList.SetBindVarValue("f_fkinp1001", this.mFkinp1001.ToString());
			this.grdOrdList.SetBindVarValue("f_order_date",this.mGijun_date);
			this.grdOrdList.SetBindVarValue("f_order_gubun",this.mOrderGubun);
			this.grdOrdList.SetBindVarValue("f_tel_yn",this.mTel_yn);
			this.grdOrdList.SetBindVarValue("f_input_gubun",inputGubun);
		}

		private void dloCheckLayout_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string inputGubun = mInput_gubun;

			if( inputGubun == "D")
				inputGubun = "D%";

			this.dloCheckLayout.SetBindVarValue("f_bunho", this.mBunho);
			this.dloCheckLayout.SetBindVarValue("f_fkinp1001", this.mFkinp1001.ToString());
			this.dloCheckLayout.SetBindVarValue("f_order_date",this.mGijun_date);
			this.dloCheckLayout.SetBindVarValue("f_order_gubun",this.mOrderGubun);
			this.dloCheckLayout.SetBindVarValue("f_tel_yn",this.mTel_yn);
			this.dloCheckLayout.SetBindVarValue("f_input_gubun",inputGubun);
		
		}

		private void grdOUT1001_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string inputGubun = mInput_gubun;

			if( inputGubun == "D")
				inputGubun = "D%";

			this.grdOUT1001.SetBindVarValue("f_bunho",this.mBunho);
			this.grdOUT1001.SetBindVarValue("f_order_date",this.mGijun_date);
			this.grdOUT1001.SetBindVarValue("f_input_gubun",inputGubun);
			this.grdOUT1001.SetBindVarValue("f_order_gubun",this.mOrderGubun);
			this.grdOUT1001.SetBindVarValue("f_tel_yn", this.mTel_yn);
		}

		private void grdOCS2005_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			int rowNum = this.grdOrdList.CurrentRowNumber;

			if( this.grdOrdList.RowCount < 1 ) 
			{
				// 오더리스트가 없습니다.
				XMessageBox.Show("Order List No");
				return;
			}

			this.grdOCS2005.SetBindVarValue("f_bunho",this.grdOrdList.GetItemString(rowNum,"bunho"));
			this.grdOCS2005.SetBindVarValue("f_fkinp1001",this.grdOrdList.GetItemString(rowNum,"fkinp1001"));
			this.grdOCS2005.SetBindVarValue("f_order_date",this.grdOrdList.GetItemString(rowNum,"order_date").Substring(0,10));
			this.grdOCS2005.SetBindVarValue("f_input_gubun",this.grdOrdList.GetItemString(rowNum,"input_gubun"));
			this.grdOCS2005.SetBindVarValue("f_gijun_date",this.grdOrdList.GetItemString(rowNum,"gijun_date"));


		}

		
		private void grdOCS2003_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			int rowNum = this.grdOrdList.CurrentRowNumber;

			if( this.grdOrdList.RowCount < 1 ) 
			{
				// 오더리스트가 없습니다.
				XMessageBox.Show("Order List No");
				return;
			}

			this.grdOCS2003.SetBindVarValue("f_bunho",this.grdOrdList.GetItemString(rowNum,"bunho"));
			this.grdOCS2003.SetBindVarValue("f_fkinp1001",this.grdOrdList.GetItemString(rowNum,"fkinp1001"));
			this.grdOCS2003.SetBindVarValue("f_order_date",this.grdOrdList.GetItemString(rowNum,"order_date").Substring(0,10));
			this.grdOCS2003.SetBindVarValue("f_input_gubun",this.grdOrdList.GetItemString(rowNum,"input_gubun"));
			this.grdOCS2003.SetBindVarValue("f_gijun_date",this.grdOrdList.GetItemString(rowNum,"gijun_date"));
			this.grdOCS2003.SetBindVarValue("f_gwa",this.grdOrdList.GetItemString(rowNum,"gwa"));
			this.grdOCS2003.SetBindVarValue("f_doctor",this.grdOrdList.GetItemString(rowNum,"doctor"));
			this.grdOCS2003.SetBindVarValue("f_tel_yn",this.grdOrdList.GetItemString(rowNum,"tel_yn"));
			this.grdOCS2003.SetBindVarValue("f_order_gubun",this.mOrderGubun);
			//this.grdOCS2003.SetBindVarValue("f_order_gubun",this.grdOrdList.GetItemString(rowNum,"order_gubun"));
		}

		private void grdOCS1001_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			int rowNum = this.grdOUT1001.CurrentRowNumber;

			if( this.grdOUT1001.RowCount < 1 ) 
			{
				// 오더리스트가 없습니다.
				XMessageBox.Show("Order OUT1001 List No");
				return;
			}

			this.grdOCS1001.SetBindVarValue("f_bunho",this.grdOUT1001.GetItemString(rowNum,"bunho"));
			this.grdOCS1001.SetBindVarValue("f_naewon_date",this.grdOUT1001.GetItemString(rowNum,"naewon_date").Substring(0,10));			
			this.grdOCS1001.SetBindVarValue("f_gwa",this.grdOUT1001.GetItemString(rowNum,"gwa"));
			this.grdOCS1001.SetBindVarValue("f_doctor",this.grdOUT1001.GetItemString(rowNum,"doctor"));
			this.grdOCS1001.SetBindVarValue("f_naewon_type",this.grdOUT1001.GetItemString(rowNum,"naewon_type"));
			this.grdOCS1001.SetBindVarValue("f_jubsu_no",this.grdOUT1001.GetItemString(rowNum,"jubsu_no"));
		}

		
		private void grdOCS1003_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			int rowNum = this.grdOUT1001.CurrentRowNumber;
			string inputGubun = this.grdOUT1001.GetItemString(rowNum,"input_gubun");

			if( this.grdOUT1001.RowCount < 1 ) 
			{
				// 오더리스트가 없습니다.
				XMessageBox.Show("Order OUT1001 List No");
				return;
			}

			if(  inputGubun== "D" )
				inputGubun = "D%";

			this.grdOCS1003.SetBindVarValue("f_bunho",this.grdOUT1001.GetItemString(rowNum,"bunho"));
			this.grdOCS1003.SetBindVarValue("f_naewon_date",this.grdOUT1001.GetItemString(rowNum,"naewon_date").Substring(0,10));			
			this.grdOCS1003.SetBindVarValue("f_gwa",this.grdOUT1001.GetItemString(rowNum,"gwa"));
			this.grdOCS1003.SetBindVarValue("f_doctor",this.grdOUT1001.GetItemString(rowNum,"doctor"));
			this.grdOCS1003.SetBindVarValue("f_naewon_type",this.grdOUT1001.GetItemString(rowNum,"naewon_type"));
			this.grdOCS1003.SetBindVarValue("f_jubsu_no",this.grdOUT1001.GetItemString(rowNum,"jubsu_no"));
			this.grdOCS1003.SetBindVarValue("f_input_gubun",inputGubun);
			this.grdOCS1003.SetBindVarValue("f_gijun_date",mGijun_date);
			this.grdOCS1003.SetBindVarValue("f_tel_yn",this.grdOUT1001.GetItemString(rowNum,"tel_yn"));
			this.grdOCS1003.SetBindVarValue("f_order_gubun",this.mOrderGubun);

		}

		
		private void dloSelectOCS2003_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			int rowNum = this.grdOrdList.CurrentRowNumber;

			if( this.grdOrdList.RowCount < 1 ) 
			{
				// 오더리스트가 없습니다.
				XMessageBox.Show("Order List No");
				return;
			}

			this.grdOCS2003.SetBindVarValue("f_bunho",this.grdOrdList.GetItemString(rowNum,"bunho"));
			this.grdOCS2003.SetBindVarValue("f_fkinp1001",this.grdOrdList.GetItemString(rowNum,"fkinp1001"));
			this.grdOCS2003.SetBindVarValue("f_order_date",this.grdOrdList.GetItemString(rowNum,"order_date").Substring(0,10));
			this.grdOCS2003.SetBindVarValue("f_input_gubun",this.grdOrdList.GetItemString(rowNum,"input_gubun"));
			this.grdOCS2003.SetBindVarValue("f_gijun_date",this.grdOrdList.GetItemString(rowNum,"gijun_date"));
			this.grdOCS2003.SetBindVarValue("f_gwa",this.grdOrdList.GetItemString(rowNum,"gwa"));
			this.grdOCS2003.SetBindVarValue("f_doctor",this.grdOrdList.GetItemString(rowNum,"doctor"));
			this.grdOCS2003.SetBindVarValue("f_tel_yn",this.grdOrdList.GetItemString(rowNum,"tel_yn"));
			this.grdOCS2003.SetBindVarValue("f_order_gubun",this.mOrderGubun);
		}

		private void dloSelectOCS2005_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			int rowNum = this.grdOrdList.CurrentRowNumber;

			if( this.grdOrdList.RowCount < 1 ) 
			{
				// 오더리스트가 없습니다.
				XMessageBox.Show("Order List No");
				return;
			}

			this.grdOCS2005.SetBindVarValue("f_bunho",this.grdOrdList.GetItemString(rowNum,"bunho"));
			this.grdOCS2005.SetBindVarValue("f_fkinp1001",this.grdOrdList.GetItemString(rowNum,"fkinp1001"));
			this.grdOCS2005.SetBindVarValue("f_order_date",this.grdOrdList.GetItemString(rowNum,"order_date").Substring(0,10));
			this.grdOCS2005.SetBindVarValue("f_input_gubun",this.grdOrdList.GetItemString(rowNum,"input_gubun"));
			this.grdOCS2005.SetBindVarValue("f_gijun_date",this.grdOrdList.GetItemString(rowNum,"gijun_date"));
		}

		private void dloSelectOCS1003_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			int rowNum = this.grdOUT1001.CurrentRowNumber;
			string inputGubun = this.grdOUT1001.GetItemString(rowNum,"input_gubun");

			if( this.grdOUT1001.RowCount < 1 ) 
			{
				// 오더리스트가 없습니다.
				XMessageBox.Show("Order OUT1001 List No");
				return;
			}

			if(  inputGubun== "D" )
				inputGubun = "D%";

			this.grdOCS1003.SetBindVarValue("f_bunho",this.grdOUT1001.GetItemString(rowNum,"bunho"));
			this.grdOCS1003.SetBindVarValue("f_naewon_date",this.grdOUT1001.GetItemString(rowNum,"naewon_date").Substring(0,10));			
			this.grdOCS1003.SetBindVarValue("f_gwa",this.grdOUT1001.GetItemString(rowNum,"gwa"));
			this.grdOCS1003.SetBindVarValue("f_doctor",this.grdOUT1001.GetItemString(rowNum,"doctor"));
			this.grdOCS1003.SetBindVarValue("f_naewon_type",this.grdOUT1001.GetItemString(rowNum,"naewon_type"));
			this.grdOCS1003.SetBindVarValue("f_jubsu_no",this.grdOUT1001.GetItemString(rowNum,"jubsu_no"));
			this.grdOCS1003.SetBindVarValue("f_input_gubun",inputGubun);
			this.grdOCS1003.SetBindVarValue("f_gijun_date",mGijun_date);
			this.grdOCS1003.SetBindVarValue("f_tel_yn",this.grdOUT1001.GetItemString(rowNum,"tel_yn"));
			this.grdOCS1003.SetBindVarValue("f_order_gubun",this.mOrderGubun);
		}

		private void dloSelectOCS1001_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			int rowNum = this.grdOUT1001.CurrentRowNumber;

			if( this.grdOUT1001.RowCount < 1 ) 
			{
				// 오더리스트가 없습니다.
				XMessageBox.Show("Order OUT1001 List No");
				return;
			}

			this.grdOCS1001.SetBindVarValue("f_bunho",this.grdOUT1001.GetItemString(rowNum,"bunho"));
			this.grdOCS1001.SetBindVarValue("f_naewon_date",this.grdOUT1001.GetItemString(rowNum,"naewon_date").Substring(0,10));			
			this.grdOCS1001.SetBindVarValue("f_gwa",this.grdOUT1001.GetItemString(rowNum,"gwa"));
			this.grdOCS1001.SetBindVarValue("f_doctor",this.grdOUT1001.GetItemString(rowNum,"doctor"));
			this.grdOCS1001.SetBindVarValue("f_naewon_type",this.grdOUT1001.GetItemString(rowNum,"naewon_type"));
			this.grdOCS1001.SetBindVarValue("f_jubsu_no",this.grdOUT1001.GetItemString(rowNum,"jubsu_no"));
		}



		#endregion 


		
	}
}

