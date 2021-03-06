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

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0301Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0323Q00 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
		private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리
		private IHIS.OCS.InputControl mInputControl = null;   // 입력제어 그룹 라이브러리 
        private IHIS.OCS.ColumnControl mColumnControl = null; // OCS 오더별 컬럼 컨트롤 라이브러리
		#endregion

		#region [Instance Variable]		
		//Message처리
		string mbxMsg = "", mbxCap = "";		

		//사용자
		private string mMemb = "";
		//진료과
		private string mGwa    = "";
		//진료의사
        //private string mDoctor = "";
		//입력구분 
        private string mInput_tab = "%";
        //Call한 시스템 외래,입원,응급 구분
        private string mIOgubun = "";
        private DataTable mInOrderData;
		//약속코드
        //private string mYaksok_code = "";	
		//내원일자
        //private string mNaewon_date = "";
		//신규그룹번호발생여부
        //private bool   mIsNewGroupSer = true;

		//환자등록번호
		private string mBunho = "";

        //ntt 자식여부
        private string mChildYN = "";

		private IHIS.X.Magic.Menus.PopupMenu popupSetOrderCopy = new IHIS.X.Magic.Menus.PopupMenu(); // Set Gubun		
		private IHIS.X.Magic.Menus.PopupMenu popupMenu         = new IHIS.X.Magic.Menus.PopupMenu();

        private OCS.OrderBiz ob = new OrderBiz();


        // Hospital Code
        private string mHospCode = EnvironInfo.HospCode;
		#endregion

        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList xButtonList1;
        private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.MultiLayout dloOrder_danui;
		private IHIS.Framework.MultiLayout dloSelectOCS0301;
		private IHIS.Framework.MultiLayout dloSelectOCS0303;
        private IHIS.Framework.MultiLayout dloInputControl;
        private IHIS.Framework.XButton btnProcess;
        private System.Windows.Forms.CheckBox chkIsNewGroup;
		private System.Windows.Forms.ImageList imageListMixGroup;
		private IHIS.Framework.XRadioButton rbt;
		private IHIS.Framework.MultiLayout dloMemb;
        private IHIS.Framework.XPanel panMemb;
        private System.Windows.Forms.TreeView tvwOCS0300;
		private IHIS.Framework.XButton btnCPLInfo;
		private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XTextBox txtSearchSetName;
        private IHIS.Framework.MultiLayout dloSetOrderCopy;
        private XEditGridCell xEditGridCell138;
        private XEditGridCell xEditGridCell139;
        private XEditGridCell xEditGridCell140;
        private XEditGridCell xEditGridCell141;
        private XEditGridCell xEditGridCell142;
        private XEditGridCell xEditGridCell144;
        private XEditGridCell xEditGridCell145;
        private XEditGridCell xEditGridCell146;
        private XEditGridCell xEditGridCell147;
        private XMstGrid grdOCS0301;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private XEditGridCell xEditGridCell162;
        private XEditGrid grdOCS0303;
        private XEditGridCell xEditGridCell78;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell81;
        private XEditGridCell xEditGridCell82;
        private XEditGridCell xEditGridCell83;
        private XEditGridCell xEditGridCell84;
        private XEditGridCell xEditGridCell85;
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
        private XEditGridCell xEditGridCell101;
        private XEditGridCell xEditGridCell102;
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
        private XEditGridCell xEditGridCell125;
        private XEditGridCell xEditGridCell126;
        private XEditGridCell xEditGridCell127;
        private XEditGridCell xEditGridCell128;
        private XEditGridCell xEditGridCell129;
        private XEditGridCell xEditGridCell133;
        private XEditGridCell xEditGridCell134;
        private XEditGridCell xEditGridCell135;
        private XEditGridCell xEditGridCell136;
        private XEditGridCell xEditGridCell137;
        private XEditGridCell xEditGridCell143;
        private XEditGridCell xEditGridCell148;
        private XEditGridCell xEditGridCell149;
        private XEditGridCell xEditGridCell151;
        private XEditGridCell xEditGridCell152;
        private XEditGridCell xEditGridCell153;
        private XEditGridCell xEditGridCell154;
        private XEditGridCell xEditGridCell155;
        private XEditGridCell xEditGridCell156;
        private XEditGridCell xEditGridCell157;
        private XEditGridCell xEditGridCell158;
        private XEditGridCell xEditGridCell159;
        private XEditGridCell xEditGridCell160;
        private XEditGridCell xEditGridCell161;
        private XGridHeader xGridHeader1;
        private XPanel pnlOrder;
        private XTabControl tabGroupSerial;
        private XPanel pnlTop;
        private XButton btnSelectAllTab;
        private XButton btnSelectCurrentTab;
        private XPanel pnlFill;
        private XEditGridCell xEditGridCell3;
        private XGridHeader xGridHeader2;
        private XGridHeader xGridHeader3;
        private XEditGridCell xEditGridCell4;
        protected ImageList imageList1;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XCheckBox cbxGeneric_YN;
        private XEditGrid grdOCS0321;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private MultiLayout layOCS0323;
        private XEditGrid grdOCS0323_1;
        private XEditGridCell xEditGridCell74;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell76;
        private XEditGridCell xEditGridCell77;
        private XEditGridCell xEditGridCell130;
        private XEditGridCell xEditGridCell131;
        private XEditGridCell xEditGridCell132;
        private XEditGridCell xEditGridCell150;
        private XEditGridCell xEditGridCell163;
        private XEditGridCell xEditGridCell164;
        private XEditGridCell xEditGridCell165;
        private XEditGridCell xEditGridCell166;
        private XEditGridCell xEditGridCell167;
        private XEditGridCell xEditGridCell168;
        private XEditGridCell xEditGridCell169;
        private XEditGridCell xEditGridCell170;
        private XEditGridCell xEditGridCell171;
        private XEditGridCell xEditGridCell172;
        private XEditGridCell xEditGridCell173;
        private XEditGridCell xEditGridCell174;
        private XEditGridCell xEditGridCell175;
        private XEditGridCell xEditGridCell176;
        private XEditGridCell xEditGridCell177;
        private XEditGridCell xEditGridCell178;
        private XEditGridCell xEditGridCell179;
        private XEditGridCell xEditGridCell180;
        private XEditGridCell xEditGridCell181;
        private XEditGridCell xEditGridCell182;
        private XEditGridCell xEditGridCell183;
        private XEditGridCell xEditGridCell184;
        private XEditGridCell xEditGridCell185;
        private XEditGridCell xEditGridCell186;
        private XEditGridCell xEditGridCell187;
        private XEditGridCell xEditGridCell188;
        private XEditGridCell xEditGridCell189;
        private XEditGridCell xEditGridCell190;
        private XEditGridCell xEditGridCell191;
        private XEditGridCell xEditGridCell192;
        private XEditGridCell xEditGridCell193;
        private XEditGridCell xEditGridCell194;
        private XEditGridCell xEditGridCell195;
        private XEditGridCell xEditGridCell196;
        private XEditGridCell xEditGridCell197;
        private XEditGridCell xEditGridCell198;
        private XEditGridCell xEditGridCell199;
        private XEditGridCell xEditGridCell200;
        private XEditGridCell xEditGridCell201;
        private XEditGridCell xEditGridCell202;
        private XEditGridCell xEditGridCell203;
        private XEditGridCell xEditGridCell204;
        private XEditGridCell xEditGridCell205;
        private XEditGridCell xEditGridCell206;
        private XEditGridCell xEditGridCell207;
        private XEditGridCell xEditGridCell208;
        private XEditGridCell xEditGridCell209;
        private XEditGridCell xEditGridCell210;
        private XEditGridCell xEditGridCell211;
        private XEditGridCell xEditGridCell212;
        private XEditGridCell xEditGridCell213;
        private XEditGridCell xEditGridCell214;
        private XEditGridCell xEditGridCell215;
        private XEditGridCell xEditGridCell216;
        private XEditGridCell xEditGridCell217;
        private XEditGridCell xEditGridCell218;
        private XEditGridCell xEditGridCell219;
        private XEditGridCell xEditGridCell220;
        private XEditGridCell xEditGridCell221;
        private XEditGridCell xEditGridCell222;
        private XEditGridCell xEditGridCell223;
        private XEditGridCell xEditGridCell224;
        private XEditGridCell xEditGridCell225;
        private XEditGridCell xEditGridCell226;
        private XEditGridCell xEditGridCell227;
        private XEditGridCell xEditGridCell228;
        private XEditGridCell xEditGridCell229;
        private XEditGridCell xEditGridCell230;
        private XEditGridCell xEditGridCell231;
        private XEditGridCell xEditGridCell232;
        private XEditGridCell xEditGridCell233;
        private XEditGridCell xEditGridCell234;
        private XEditGridCell xEditGridCell235;
        private XEditGridCell xEditGridCell236;
        private XEditGridCell xEditGridCell237;
        private XEditGridCell xEditGridCell238;
        private XEditGridCell xEditGridCell239;
        private XEditGridCell xEditGridCell240;
        private XEditGridCell xEditGridCell241;
        private XEditGridCell xEditGridCell242;
        private XEditGrid grdOCS0323_9;
        private XEditGridCell xEditGridCell814;
        private XEditGridCell xEditGridCell815;
        private XEditGridCell xEditGridCell816;
        private XEditGridCell xEditGridCell817;
        private XEditGridCell xEditGridCell818;
        private XEditGridCell xEditGridCell819;
        private XEditGridCell xEditGridCell820;
        private XEditGridCell xEditGridCell821;
        private XEditGridCell xEditGridCell822;
        private XEditGridCell xEditGridCell823;
        private XEditGridCell xEditGridCell824;
        private XEditGridCell xEditGridCell825;
        private XEditGridCell xEditGridCell826;
        private XEditGridCell xEditGridCell827;
        private XEditGridCell xEditGridCell828;
        private XEditGridCell xEditGridCell829;
        private XEditGridCell xEditGridCell830;
        private XEditGridCell xEditGridCell831;
        private XEditGridCell xEditGridCell832;
        private XEditGridCell xEditGridCell833;
        private XEditGridCell xEditGridCell834;
        private XEditGridCell xEditGridCell835;
        private XEditGridCell xEditGridCell836;
        private XEditGridCell xEditGridCell837;
        private XEditGridCell xEditGridCell838;
        private XEditGridCell xEditGridCell839;
        private XEditGridCell xEditGridCell840;
        private XEditGridCell xEditGridCell841;
        private XEditGridCell xEditGridCell842;
        private XEditGridCell xEditGridCell843;
        private XEditGridCell xEditGridCell844;
        private XEditGridCell xEditGridCell845;
        private XEditGridCell xEditGridCell846;
        private XEditGridCell xEditGridCell847;
        private XEditGridCell xEditGridCell848;
        private XEditGridCell xEditGridCell849;
        private XEditGridCell xEditGridCell850;
        private XEditGridCell xEditGridCell851;
        private XEditGridCell xEditGridCell852;
        private XEditGridCell xEditGridCell853;
        private XEditGridCell xEditGridCell854;
        private XEditGridCell xEditGridCell855;
        private XEditGridCell xEditGridCell856;
        private XEditGridCell xEditGridCell857;
        private XEditGridCell xEditGridCell858;
        private XEditGridCell xEditGridCell859;
        private XEditGridCell xEditGridCell860;
        private XEditGridCell xEditGridCell861;
        private XEditGridCell xEditGridCell862;
        private XEditGridCell xEditGridCell863;
        private XEditGridCell xEditGridCell864;
        private XEditGridCell xEditGridCell865;
        private XEditGridCell xEditGridCell866;
        private XEditGridCell xEditGridCell867;
        private XEditGridCell xEditGridCell868;
        private XEditGridCell xEditGridCell869;
        private XEditGridCell xEditGridCell870;
        private XEditGridCell xEditGridCell871;
        private XEditGridCell xEditGridCell872;
        private XEditGridCell xEditGridCell873;
        private XEditGridCell xEditGridCell874;
        private XEditGridCell xEditGridCell875;
        private XEditGridCell xEditGridCell876;
        private XEditGridCell xEditGridCell877;
        private XEditGridCell xEditGridCell878;
        private XEditGridCell xEditGridCell879;
        private XEditGridCell xEditGridCell880;
        private XEditGridCell xEditGridCell881;
        private XEditGridCell xEditGridCell882;
        private XEditGridCell xEditGridCell883;
        private XEditGridCell xEditGridCell884;
        private XEditGridCell xEditGridCell885;
        private XEditGridCell xEditGridCell886;
        private XEditGridCell xEditGridCell887;
        private XEditGridCell xEditGridCell888;
        private XEditGridCell xEditGridCell889;
        private XEditGridCell xEditGridCell890;
        private XEditGridCell xEditGridCell891;
        private XEditGridCell xEditGridCell892;
        private XEditGridCell xEditGridCell893;
        private XEditGridCell xEditGridCell894;
        private XEditGridCell xEditGridCell895;
        private XEditGridCell xEditGridCell896;
        private XEditGridCell xEditGridCell897;
        private XEditGridCell xEditGridCell898;
        private XEditGridCell xEditGridCell899;
        private XEditGridCell xEditGridCell900;
        private XEditGridCell xEditGridCell901;
        private XEditGrid grdOCS0323_8;
        private XEditGridCell xEditGridCell726;
        private XEditGridCell xEditGridCell727;
        private XEditGridCell xEditGridCell728;
        private XEditGridCell xEditGridCell729;
        private XEditGridCell xEditGridCell730;
        private XEditGridCell xEditGridCell731;
        private XEditGridCell xEditGridCell732;
        private XEditGridCell xEditGridCell733;
        private XEditGridCell xEditGridCell734;
        private XEditGridCell xEditGridCell735;
        private XEditGridCell xEditGridCell736;
        private XEditGridCell xEditGridCell737;
        private XEditGridCell xEditGridCell738;
        private XEditGridCell xEditGridCell739;
        private XEditGridCell xEditGridCell740;
        private XEditGridCell xEditGridCell741;
        private XEditGridCell xEditGridCell742;
        private XEditGridCell xEditGridCell743;
        private XEditGridCell xEditGridCell744;
        private XEditGridCell xEditGridCell745;
        private XEditGridCell xEditGridCell746;
        private XEditGridCell xEditGridCell747;
        private XEditGridCell xEditGridCell748;
        private XEditGridCell xEditGridCell749;
        private XEditGridCell xEditGridCell750;
        private XEditGridCell xEditGridCell751;
        private XEditGridCell xEditGridCell752;
        private XEditGridCell xEditGridCell753;
        private XEditGridCell xEditGridCell754;
        private XEditGridCell xEditGridCell755;
        private XEditGridCell xEditGridCell756;
        private XEditGridCell xEditGridCell757;
        private XEditGridCell xEditGridCell758;
        private XEditGridCell xEditGridCell759;
        private XEditGridCell xEditGridCell760;
        private XEditGridCell xEditGridCell761;
        private XEditGridCell xEditGridCell762;
        private XEditGridCell xEditGridCell763;
        private XEditGridCell xEditGridCell764;
        private XEditGridCell xEditGridCell765;
        private XEditGridCell xEditGridCell766;
        private XEditGridCell xEditGridCell767;
        private XEditGridCell xEditGridCell768;
        private XEditGridCell xEditGridCell769;
        private XEditGridCell xEditGridCell770;
        private XEditGridCell xEditGridCell771;
        private XEditGridCell xEditGridCell772;
        private XEditGridCell xEditGridCell773;
        private XEditGridCell xEditGridCell774;
        private XEditGridCell xEditGridCell775;
        private XEditGridCell xEditGridCell776;
        private XEditGridCell xEditGridCell777;
        private XEditGridCell xEditGridCell778;
        private XEditGridCell xEditGridCell779;
        private XEditGridCell xEditGridCell780;
        private XEditGridCell xEditGridCell781;
        private XEditGridCell xEditGridCell782;
        private XEditGridCell xEditGridCell783;
        private XEditGridCell xEditGridCell784;
        private XEditGridCell xEditGridCell785;
        private XEditGridCell xEditGridCell786;
        private XEditGridCell xEditGridCell787;
        private XEditGridCell xEditGridCell788;
        private XEditGridCell xEditGridCell789;
        private XEditGridCell xEditGridCell790;
        private XEditGridCell xEditGridCell791;
        private XEditGridCell xEditGridCell792;
        private XEditGridCell xEditGridCell793;
        private XEditGridCell xEditGridCell794;
        private XEditGridCell xEditGridCell795;
        private XEditGridCell xEditGridCell796;
        private XEditGridCell xEditGridCell797;
        private XEditGridCell xEditGridCell798;
        private XEditGridCell xEditGridCell799;
        private XEditGridCell xEditGridCell800;
        private XEditGridCell xEditGridCell801;
        private XEditGridCell xEditGridCell802;
        private XEditGridCell xEditGridCell803;
        private XEditGridCell xEditGridCell804;
        private XEditGridCell xEditGridCell805;
        private XEditGridCell xEditGridCell806;
        private XEditGridCell xEditGridCell807;
        private XEditGridCell xEditGridCell808;
        private XEditGridCell xEditGridCell809;
        private XEditGridCell xEditGridCell810;
        private XEditGridCell xEditGridCell811;
        private XEditGridCell xEditGridCell812;
        private XEditGridCell xEditGridCell813;
        private XEditGrid grdOCS0323_7;
        private XEditGridCell xEditGridCell638;
        private XEditGridCell xEditGridCell639;
        private XEditGridCell xEditGridCell640;
        private XEditGridCell xEditGridCell641;
        private XEditGridCell xEditGridCell642;
        private XEditGridCell xEditGridCell643;
        private XEditGridCell xEditGridCell644;
        private XEditGridCell xEditGridCell645;
        private XEditGridCell xEditGridCell646;
        private XEditGridCell xEditGridCell647;
        private XEditGridCell xEditGridCell648;
        private XEditGridCell xEditGridCell649;
        private XEditGridCell xEditGridCell650;
        private XEditGridCell xEditGridCell651;
        private XEditGridCell xEditGridCell652;
        private XEditGridCell xEditGridCell653;
        private XEditGridCell xEditGridCell654;
        private XEditGridCell xEditGridCell655;
        private XEditGridCell xEditGridCell656;
        private XEditGridCell xEditGridCell657;
        private XEditGridCell xEditGridCell658;
        private XEditGridCell xEditGridCell659;
        private XEditGridCell xEditGridCell660;
        private XEditGridCell xEditGridCell661;
        private XEditGridCell xEditGridCell662;
        private XEditGridCell xEditGridCell663;
        private XEditGridCell xEditGridCell664;
        private XEditGridCell xEditGridCell665;
        private XEditGridCell xEditGridCell666;
        private XEditGridCell xEditGridCell667;
        private XEditGridCell xEditGridCell668;
        private XEditGridCell xEditGridCell669;
        private XEditGridCell xEditGridCell670;
        private XEditGridCell xEditGridCell671;
        private XEditGridCell xEditGridCell672;
        private XEditGridCell xEditGridCell673;
        private XEditGridCell xEditGridCell674;
        private XEditGridCell xEditGridCell675;
        private XEditGridCell xEditGridCell676;
        private XEditGridCell xEditGridCell677;
        private XEditGridCell xEditGridCell678;
        private XEditGridCell xEditGridCell679;
        private XEditGridCell xEditGridCell680;
        private XEditGridCell xEditGridCell681;
        private XEditGridCell xEditGridCell682;
        private XEditGridCell xEditGridCell683;
        private XEditGridCell xEditGridCell684;
        private XEditGridCell xEditGridCell685;
        private XEditGridCell xEditGridCell686;
        private XEditGridCell xEditGridCell687;
        private XEditGridCell xEditGridCell688;
        private XEditGridCell xEditGridCell689;
        private XEditGridCell xEditGridCell690;
        private XEditGridCell xEditGridCell691;
        private XEditGridCell xEditGridCell692;
        private XEditGridCell xEditGridCell693;
        private XEditGridCell xEditGridCell694;
        private XEditGridCell xEditGridCell695;
        private XEditGridCell xEditGridCell696;
        private XEditGridCell xEditGridCell697;
        private XEditGridCell xEditGridCell698;
        private XEditGridCell xEditGridCell699;
        private XEditGridCell xEditGridCell700;
        private XEditGridCell xEditGridCell701;
        private XEditGridCell xEditGridCell702;
        private XEditGridCell xEditGridCell703;
        private XEditGridCell xEditGridCell704;
        private XEditGridCell xEditGridCell705;
        private XEditGridCell xEditGridCell706;
        private XEditGridCell xEditGridCell707;
        private XEditGridCell xEditGridCell708;
        private XEditGridCell xEditGridCell709;
        private XEditGridCell xEditGridCell710;
        private XEditGridCell xEditGridCell711;
        private XEditGridCell xEditGridCell712;
        private XEditGridCell xEditGridCell713;
        private XEditGridCell xEditGridCell714;
        private XEditGridCell xEditGridCell715;
        private XEditGridCell xEditGridCell716;
        private XEditGridCell xEditGridCell717;
        private XEditGridCell xEditGridCell718;
        private XEditGridCell xEditGridCell719;
        private XEditGridCell xEditGridCell720;
        private XEditGridCell xEditGridCell721;
        private XEditGridCell xEditGridCell722;
        private XEditGridCell xEditGridCell723;
        private XEditGridCell xEditGridCell724;
        private XEditGridCell xEditGridCell725;
        private XEditGrid grdOCS0323_6;
        private XEditGridCell xEditGridCell550;
        private XEditGridCell xEditGridCell551;
        private XEditGridCell xEditGridCell552;
        private XEditGridCell xEditGridCell553;
        private XEditGridCell xEditGridCell554;
        private XEditGridCell xEditGridCell555;
        private XEditGridCell xEditGridCell556;
        private XEditGridCell xEditGridCell557;
        private XEditGridCell xEditGridCell558;
        private XEditGridCell xEditGridCell559;
        private XEditGridCell xEditGridCell560;
        private XEditGridCell xEditGridCell561;
        private XEditGridCell xEditGridCell562;
        private XEditGridCell xEditGridCell563;
        private XEditGridCell xEditGridCell564;
        private XEditGridCell xEditGridCell565;
        private XEditGridCell xEditGridCell566;
        private XEditGridCell xEditGridCell567;
        private XEditGridCell xEditGridCell568;
        private XEditGridCell xEditGridCell569;
        private XEditGridCell xEditGridCell570;
        private XEditGridCell xEditGridCell571;
        private XEditGridCell xEditGridCell572;
        private XEditGridCell xEditGridCell573;
        private XEditGridCell xEditGridCell574;
        private XEditGridCell xEditGridCell575;
        private XEditGridCell xEditGridCell576;
        private XEditGridCell xEditGridCell577;
        private XEditGridCell xEditGridCell578;
        private XEditGridCell xEditGridCell579;
        private XEditGridCell xEditGridCell580;
        private XEditGridCell xEditGridCell581;
        private XEditGridCell xEditGridCell582;
        private XEditGridCell xEditGridCell583;
        private XEditGridCell xEditGridCell584;
        private XEditGridCell xEditGridCell585;
        private XEditGridCell xEditGridCell586;
        private XEditGridCell xEditGridCell587;
        private XEditGridCell xEditGridCell588;
        private XEditGridCell xEditGridCell589;
        private XEditGridCell xEditGridCell590;
        private XEditGridCell xEditGridCell591;
        private XEditGridCell xEditGridCell592;
        private XEditGridCell xEditGridCell593;
        private XEditGridCell xEditGridCell594;
        private XEditGridCell xEditGridCell595;
        private XEditGridCell xEditGridCell596;
        private XEditGridCell xEditGridCell597;
        private XEditGridCell xEditGridCell598;
        private XEditGridCell xEditGridCell599;
        private XEditGridCell xEditGridCell600;
        private XEditGridCell xEditGridCell601;
        private XEditGridCell xEditGridCell602;
        private XEditGridCell xEditGridCell603;
        private XEditGridCell xEditGridCell604;
        private XEditGridCell xEditGridCell605;
        private XEditGridCell xEditGridCell606;
        private XEditGridCell xEditGridCell607;
        private XEditGridCell xEditGridCell608;
        private XEditGridCell xEditGridCell609;
        private XEditGridCell xEditGridCell610;
        private XEditGridCell xEditGridCell611;
        private XEditGridCell xEditGridCell612;
        private XEditGridCell xEditGridCell613;
        private XEditGridCell xEditGridCell614;
        private XEditGridCell xEditGridCell615;
        private XEditGridCell xEditGridCell616;
        private XEditGridCell xEditGridCell617;
        private XEditGridCell xEditGridCell618;
        private XEditGridCell xEditGridCell619;
        private XEditGridCell xEditGridCell620;
        private XEditGridCell xEditGridCell621;
        private XEditGridCell xEditGridCell622;
        private XEditGridCell xEditGridCell623;
        private XEditGridCell xEditGridCell624;
        private XEditGridCell xEditGridCell625;
        private XEditGridCell xEditGridCell626;
        private XEditGridCell xEditGridCell627;
        private XEditGridCell xEditGridCell628;
        private XEditGridCell xEditGridCell629;
        private XEditGridCell xEditGridCell630;
        private XEditGridCell xEditGridCell631;
        private XEditGridCell xEditGridCell632;
        private XEditGridCell xEditGridCell633;
        private XEditGridCell xEditGridCell634;
        private XEditGridCell xEditGridCell635;
        private XEditGridCell xEditGridCell636;
        private XEditGridCell xEditGridCell637;
        private XEditGrid grdOCS0323_5;
        private XEditGridCell xEditGridCell462;
        private XEditGridCell xEditGridCell463;
        private XEditGridCell xEditGridCell464;
        private XEditGridCell xEditGridCell465;
        private XEditGridCell xEditGridCell466;
        private XEditGridCell xEditGridCell467;
        private XEditGridCell xEditGridCell468;
        private XEditGridCell xEditGridCell469;
        private XEditGridCell xEditGridCell470;
        private XEditGridCell xEditGridCell471;
        private XEditGridCell xEditGridCell472;
        private XEditGridCell xEditGridCell473;
        private XEditGridCell xEditGridCell474;
        private XEditGridCell xEditGridCell475;
        private XEditGridCell xEditGridCell476;
        private XEditGridCell xEditGridCell477;
        private XEditGridCell xEditGridCell478;
        private XEditGridCell xEditGridCell479;
        private XEditGridCell xEditGridCell480;
        private XEditGridCell xEditGridCell481;
        private XEditGridCell xEditGridCell482;
        private XEditGridCell xEditGridCell483;
        private XEditGridCell xEditGridCell484;
        private XEditGridCell xEditGridCell485;
        private XEditGridCell xEditGridCell486;
        private XEditGridCell xEditGridCell487;
        private XEditGridCell xEditGridCell488;
        private XEditGridCell xEditGridCell489;
        private XEditGridCell xEditGridCell490;
        private XEditGridCell xEditGridCell491;
        private XEditGridCell xEditGridCell492;
        private XEditGridCell xEditGridCell493;
        private XEditGridCell xEditGridCell494;
        private XEditGridCell xEditGridCell495;
        private XEditGridCell xEditGridCell496;
        private XEditGridCell xEditGridCell497;
        private XEditGridCell xEditGridCell498;
        private XEditGridCell xEditGridCell499;
        private XEditGridCell xEditGridCell500;
        private XEditGridCell xEditGridCell501;
        private XEditGridCell xEditGridCell502;
        private XEditGridCell xEditGridCell503;
        private XEditGridCell xEditGridCell504;
        private XEditGridCell xEditGridCell505;
        private XEditGridCell xEditGridCell506;
        private XEditGridCell xEditGridCell507;
        private XEditGridCell xEditGridCell508;
        private XEditGridCell xEditGridCell509;
        private XEditGridCell xEditGridCell510;
        private XEditGridCell xEditGridCell511;
        private XEditGridCell xEditGridCell512;
        private XEditGridCell xEditGridCell513;
        private XEditGridCell xEditGridCell514;
        private XEditGridCell xEditGridCell515;
        private XEditGridCell xEditGridCell516;
        private XEditGridCell xEditGridCell517;
        private XEditGridCell xEditGridCell518;
        private XEditGridCell xEditGridCell519;
        private XEditGridCell xEditGridCell520;
        private XEditGridCell xEditGridCell521;
        private XEditGridCell xEditGridCell522;
        private XEditGridCell xEditGridCell523;
        private XEditGridCell xEditGridCell524;
        private XEditGridCell xEditGridCell525;
        private XEditGridCell xEditGridCell526;
        private XEditGridCell xEditGridCell527;
        private XEditGridCell xEditGridCell528;
        private XEditGridCell xEditGridCell529;
        private XEditGridCell xEditGridCell530;
        private XEditGridCell xEditGridCell531;
        private XEditGridCell xEditGridCell532;
        private XEditGridCell xEditGridCell533;
        private XEditGridCell xEditGridCell534;
        private XEditGridCell xEditGridCell535;
        private XEditGridCell xEditGridCell536;
        private XEditGridCell xEditGridCell537;
        private XEditGridCell xEditGridCell538;
        private XEditGridCell xEditGridCell539;
        private XEditGridCell xEditGridCell540;
        private XEditGridCell xEditGridCell541;
        private XEditGridCell xEditGridCell542;
        private XEditGridCell xEditGridCell543;
        private XEditGridCell xEditGridCell544;
        private XEditGridCell xEditGridCell545;
        private XEditGridCell xEditGridCell546;
        private XEditGridCell xEditGridCell547;
        private XEditGridCell xEditGridCell548;
        private XEditGridCell xEditGridCell549;
        private XEditGrid grdOCS0323_4;
        private XEditGridCell xEditGridCell374;
        private XEditGridCell xEditGridCell375;
        private XEditGridCell xEditGridCell376;
        private XEditGridCell xEditGridCell377;
        private XEditGridCell xEditGridCell378;
        private XEditGridCell xEditGridCell379;
        private XEditGridCell xEditGridCell380;
        private XEditGridCell xEditGridCell381;
        private XEditGridCell xEditGridCell382;
        private XEditGridCell xEditGridCell383;
        private XEditGridCell xEditGridCell384;
        private XEditGridCell xEditGridCell385;
        private XEditGridCell xEditGridCell386;
        private XEditGridCell xEditGridCell387;
        private XEditGridCell xEditGridCell388;
        private XEditGridCell xEditGridCell389;
        private XEditGridCell xEditGridCell390;
        private XEditGridCell xEditGridCell391;
        private XEditGridCell xEditGridCell392;
        private XEditGridCell xEditGridCell393;
        private XEditGridCell xEditGridCell394;
        private XEditGridCell xEditGridCell395;
        private XEditGridCell xEditGridCell396;
        private XEditGridCell xEditGridCell397;
        private XEditGridCell xEditGridCell398;
        private XEditGridCell xEditGridCell399;
        private XEditGridCell xEditGridCell400;
        private XEditGridCell xEditGridCell401;
        private XEditGridCell xEditGridCell402;
        private XEditGridCell xEditGridCell403;
        private XEditGridCell xEditGridCell404;
        private XEditGridCell xEditGridCell405;
        private XEditGridCell xEditGridCell406;
        private XEditGridCell xEditGridCell407;
        private XEditGridCell xEditGridCell408;
        private XEditGridCell xEditGridCell409;
        private XEditGridCell xEditGridCell410;
        private XEditGridCell xEditGridCell411;
        private XEditGridCell xEditGridCell412;
        private XEditGridCell xEditGridCell413;
        private XEditGridCell xEditGridCell414;
        private XEditGridCell xEditGridCell415;
        private XEditGridCell xEditGridCell416;
        private XEditGridCell xEditGridCell417;
        private XEditGridCell xEditGridCell418;
        private XEditGridCell xEditGridCell419;
        private XEditGridCell xEditGridCell420;
        private XEditGridCell xEditGridCell421;
        private XEditGridCell xEditGridCell422;
        private XEditGridCell xEditGridCell423;
        private XEditGridCell xEditGridCell424;
        private XEditGridCell xEditGridCell425;
        private XEditGridCell xEditGridCell426;
        private XEditGridCell xEditGridCell427;
        private XEditGridCell xEditGridCell428;
        private XEditGridCell xEditGridCell429;
        private XEditGridCell xEditGridCell430;
        private XEditGridCell xEditGridCell431;
        private XEditGridCell xEditGridCell432;
        private XEditGridCell xEditGridCell433;
        private XEditGridCell xEditGridCell434;
        private XEditGridCell xEditGridCell435;
        private XEditGridCell xEditGridCell436;
        private XEditGridCell xEditGridCell437;
        private XEditGridCell xEditGridCell438;
        private XEditGridCell xEditGridCell439;
        private XEditGridCell xEditGridCell440;
        private XEditGridCell xEditGridCell441;
        private XEditGridCell xEditGridCell442;
        private XEditGridCell xEditGridCell443;
        private XEditGridCell xEditGridCell444;
        private XEditGridCell xEditGridCell445;
        private XEditGridCell xEditGridCell446;
        private XEditGridCell xEditGridCell447;
        private XEditGridCell xEditGridCell448;
        private XEditGridCell xEditGridCell449;
        private XEditGridCell xEditGridCell450;
        private XEditGridCell xEditGridCell451;
        private XEditGridCell xEditGridCell452;
        private XEditGridCell xEditGridCell453;
        private XEditGridCell xEditGridCell454;
        private XEditGridCell xEditGridCell455;
        private XEditGridCell xEditGridCell456;
        private XEditGridCell xEditGridCell457;
        private XEditGridCell xEditGridCell458;
        private XEditGridCell xEditGridCell459;
        private XEditGridCell xEditGridCell460;
        private XEditGridCell xEditGridCell461;
        private XEditGrid grdOCS0323_3;
        private XEditGridCell xEditGridCell286;
        private XEditGridCell xEditGridCell287;
        private XEditGridCell xEditGridCell288;
        private XEditGridCell xEditGridCell289;
        private XEditGridCell xEditGridCell290;
        private XEditGridCell xEditGridCell291;
        private XEditGridCell xEditGridCell292;
        private XEditGridCell xEditGridCell293;
        private XEditGridCell xEditGridCell294;
        private XEditGridCell xEditGridCell295;
        private XEditGridCell xEditGridCell296;
        private XEditGridCell xEditGridCell297;
        private XEditGridCell xEditGridCell298;
        private XEditGridCell xEditGridCell299;
        private XEditGridCell xEditGridCell300;
        private XEditGridCell xEditGridCell301;
        private XEditGridCell xEditGridCell302;
        private XEditGridCell xEditGridCell303;
        private XEditGridCell xEditGridCell304;
        private XEditGridCell xEditGridCell305;
        private XEditGridCell xEditGridCell306;
        private XEditGridCell xEditGridCell307;
        private XEditGridCell xEditGridCell308;
        private XEditGridCell xEditGridCell309;
        private XEditGridCell xEditGridCell310;
        private XEditGridCell xEditGridCell311;
        private XEditGridCell xEditGridCell312;
        private XEditGridCell xEditGridCell313;
        private XEditGridCell xEditGridCell314;
        private XEditGridCell xEditGridCell315;
        private XEditGridCell xEditGridCell316;
        private XEditGridCell xEditGridCell317;
        private XEditGridCell xEditGridCell318;
        private XEditGridCell xEditGridCell319;
        private XEditGridCell xEditGridCell320;
        private XEditGridCell xEditGridCell321;
        private XEditGridCell xEditGridCell322;
        private XEditGridCell xEditGridCell323;
        private XEditGridCell xEditGridCell324;
        private XEditGridCell xEditGridCell325;
        private XEditGridCell xEditGridCell326;
        private XEditGridCell xEditGridCell327;
        private XEditGridCell xEditGridCell328;
        private XEditGridCell xEditGridCell329;
        private XEditGridCell xEditGridCell330;
        private XEditGridCell xEditGridCell331;
        private XEditGridCell xEditGridCell332;
        private XEditGridCell xEditGridCell333;
        private XEditGridCell xEditGridCell334;
        private XEditGridCell xEditGridCell335;
        private XEditGridCell xEditGridCell336;
        private XEditGridCell xEditGridCell337;
        private XEditGridCell xEditGridCell338;
        private XEditGridCell xEditGridCell339;
        private XEditGridCell xEditGridCell340;
        private XEditGridCell xEditGridCell341;
        private XEditGridCell xEditGridCell342;
        private XEditGridCell xEditGridCell343;
        private XEditGridCell xEditGridCell344;
        private XEditGridCell xEditGridCell345;
        private XEditGridCell xEditGridCell346;
        private XEditGridCell xEditGridCell347;
        private XEditGridCell xEditGridCell348;
        private XEditGridCell xEditGridCell349;
        private XEditGridCell xEditGridCell350;
        private XEditGridCell xEditGridCell351;
        private XEditGridCell xEditGridCell352;
        private XEditGridCell xEditGridCell353;
        private XEditGridCell xEditGridCell354;
        private XEditGridCell xEditGridCell355;
        private XEditGridCell xEditGridCell356;
        private XEditGridCell xEditGridCell357;
        private XEditGridCell xEditGridCell358;
        private XEditGridCell xEditGridCell359;
        private XEditGridCell xEditGridCell360;
        private XEditGridCell xEditGridCell361;
        private XEditGridCell xEditGridCell362;
        private XEditGridCell xEditGridCell363;
        private XEditGridCell xEditGridCell364;
        private XEditGridCell xEditGridCell365;
        private XEditGridCell xEditGridCell366;
        private XEditGridCell xEditGridCell367;
        private XEditGridCell xEditGridCell368;
        private XEditGridCell xEditGridCell369;
        private XEditGridCell xEditGridCell370;
        private XEditGridCell xEditGridCell371;
        private XEditGridCell xEditGridCell372;
        private XEditGridCell xEditGridCell373;
        private XEditGrid grdOCS0323_2;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell31;
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell37;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell40;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell42;
        private XEditGridCell xEditGridCell43;
        private XEditGridCell xEditGridCell44;
        private XEditGridCell xEditGridCell45;
        private XEditGridCell xEditGridCell46;
        private XEditGridCell xEditGridCell47;
        private XEditGridCell xEditGridCell48;
        private XEditGridCell xEditGridCell49;
        private XEditGridCell xEditGridCell50;
        private XEditGridCell xEditGridCell51;
        private XEditGridCell xEditGridCell52;
        private XEditGridCell xEditGridCell53;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell55;
        private XEditGridCell xEditGridCell56;
        private XEditGridCell xEditGridCell57;
        private XEditGridCell xEditGridCell58;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell60;
        private XEditGridCell xEditGridCell61;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XEditGridCell xEditGridCell64;
        private XEditGridCell xEditGridCell65;
        private XEditGridCell xEditGridCell66;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell68;
        private XEditGridCell xEditGridCell69;
        private XEditGridCell xEditGridCell70;
        private XEditGridCell xEditGridCell71;
        private XEditGridCell xEditGridCell72;
        private XEditGridCell xEditGridCell73;
        private XEditGridCell xEditGridCell243;
        private XEditGridCell xEditGridCell244;
        private XEditGridCell xEditGridCell245;
        private XEditGridCell xEditGridCell246;
        private XEditGridCell xEditGridCell247;
        private XEditGridCell xEditGridCell248;
        private XEditGridCell xEditGridCell249;
        private XEditGridCell xEditGridCell250;
        private XEditGridCell xEditGridCell251;
        private XEditGridCell xEditGridCell252;
        private XEditGridCell xEditGridCell253;
        private XEditGridCell xEditGridCell254;
        private XEditGridCell xEditGridCell255;
        private XEditGridCell xEditGridCell256;
        private XEditGridCell xEditGridCell257;
        private XEditGridCell xEditGridCell258;
        private XEditGridCell xEditGridCell259;
        private XEditGridCell xEditGridCell260;
        private XEditGridCell xEditGridCell261;
        private XEditGridCell xEditGridCell262;
        private XEditGridCell xEditGridCell263;
        private XEditGridCell xEditGridCell264;
        private XEditGridCell xEditGridCell265;
        private XEditGridCell xEditGridCell266;
        private XEditGridCell xEditGridCell267;
        private XEditGridCell xEditGridCell268;
        private XEditGridCell xEditGridCell269;
        private XEditGridCell xEditGridCell270;
        private XEditGridCell xEditGridCell271;
        private XEditGridCell xEditGridCell272;
        private XEditGridCell xEditGridCell273;
        private XEditGridCell xEditGridCell274;
        private XEditGridCell xEditGridCell275;
        private XEditGridCell xEditGridCell276;
        private XEditGridCell xEditGridCell277;
        private XEditGridCell xEditGridCell278;
        private XEditGridCell xEditGridCell279;
        private XEditGridCell xEditGridCell280;
        private XEditGridCell xEditGridCell281;
        private XEditGridCell xEditGridCell282;
        private XEditGridCell xEditGridCell283;
        private XEditGridCell xEditGridCell284;
        private XEditGridCell xEditGridCell285;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem36;
        private MultiLayoutItem multiLayoutItem39;
        private MultiLayoutItem multiLayoutItem40;
        private MultiLayoutItem multiLayoutItem41;
        private MultiLayoutItem multiLayoutItem42;
        private MultiLayoutItem multiLayoutItem43;
        private MultiLayoutItem multiLayoutItem44;
        private MultiLayoutItem multiLayoutItem45;
        private MultiLayoutItem multiLayoutItem46;
        private MultiLayoutItem multiLayoutItem47;
        private MultiLayoutItem multiLayoutItem48;
        private MultiLayoutItem multiLayoutItem49;
        private MultiLayoutItem multiLayoutItem50;
        private MultiLayoutItem multiLayoutItem51;
        private MultiLayoutItem multiLayoutItem52;
        private MultiLayoutItem multiLayoutItem53;
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
        private MultiLayoutItem multiLayoutItem81;
        private MultiLayoutItem multiLayoutItem82;
        private MultiLayoutItem multiLayoutItem83;
        private MultiLayoutItem multiLayoutItem84;
        private MultiLayoutItem multiLayoutItem85;
        private MultiLayoutItem multiLayoutItem86;
        private MultiLayoutItem multiLayoutItem87;
        private MultiLayoutItem multiLayoutItem88;
        private MultiLayoutItem multiLayoutItem89;
        private MultiLayoutItem multiLayoutItem90;
        private MultiLayoutItem multiLayoutItem91;
        private MultiLayoutItem multiLayoutItem92;
        private MultiLayoutItem multiLayoutItem93;
        private MultiLayoutItem multiLayoutItem94;
        private MultiLayoutItem multiLayoutItem95;
        private MultiLayoutItem multiLayoutItem96;
        private MultiLayoutItem multiLayoutItem97;
        private MultiLayoutItem multiLayoutItem98;
        private MultiLayoutItem multiLayoutItem99;
        private MultiLayoutItem multiLayoutItem100;
        private MultiLayoutItem multiLayoutItem101;
        private MultiLayoutItem multiLayoutItem102;
        private MultiLayoutItem multiLayoutItem103;
        private MultiLayoutItem multiLayoutItem104;
        private MultiLayoutItem multiLayoutItem105;
        private MultiLayoutItem multiLayoutItem106;
        private MultiLayoutItem multiLayoutItem107;
        private MultiLayoutItem multiLayoutItem108;
        private MultiLayoutItem multiLayoutItem109;
        private MultiLayoutItem multiLayoutItem110;
        private MultiLayoutItem multiLayoutItem111;
        private MultiLayoutItem multiLayoutItem112;
        private MultiLayoutItem multiLayoutItem113;
        private MultiLayoutItem multiLayoutItem114;
        private MultiLayoutItem multiLayoutItem115;
        private MultiLayoutItem multiLayoutItem116;
        private MultiLayoutItem multiLayoutItem117;
        private MultiLayoutItem multiLayoutItem118;
        private MultiLayoutItem multiLayoutItem119;
        private MultiLayoutItem multiLayoutItem120;
        private MultiLayoutItem multiLayoutItem121;
        private MultiLayoutItem multiLayoutItem204;
        private XEditGridCell xEditGridCell902;
        private XEditGridCell xEditGridCell910;
        private XEditGridCell xEditGridCell909;
        private XEditGridCell xEditGridCell908;
        private XEditGridCell xEditGridCell907;
        private XEditGridCell xEditGridCell906;
        private XEditGridCell xEditGridCell905;
        private XEditGridCell xEditGridCell904;
        private XEditGridCell xEditGridCell903;
		private System.ComponentModel.IContainer components;

		public OCS0323Q00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
			this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리			
			this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.ScreenID);    // OCS 항목정보 그룹 라이브러리
			this.mInputControl = new IHIS.OCS.InputControl(this.ScreenID);  // 입력제어 그룹 라이브러리 	
            this.mColumnControl = new IHIS.OCS.ColumnControl(this.ScreenID); // OCS 컬럼 컨트롤 그룹 라이브러리 
			
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0323Q00));
            this.panMemb = new IHIS.Framework.XPanel();
            this.rbt = new IHIS.Framework.XRadioButton();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.txtSearchSetName = new IHIS.Framework.XTextBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnCPLInfo = new IHIS.Framework.XButton();
            this.chkIsNewGroup = new System.Windows.Forms.CheckBox();
            this.btnProcess = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdOCS0301 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell138 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell141 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell140 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell142 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell162 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell144 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell145 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell146 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell147 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dloSelectOCS0301 = new IHIS.Framework.MultiLayout();
            this.dloSelectOCS0303 = new IHIS.Framework.MultiLayout();
            this.dloOrder_danui = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.dloInputControl = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.dloMemb = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.tvwOCS0300 = new System.Windows.Forms.TreeView();
            this.dloSetOrderCopy = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.grdOCS0303 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell133 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell136 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell137 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell143 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader3 = new IHIS.Framework.XGridHeader();
            this.xEditGridCell161 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.pnlOrder = new IHIS.Framework.XPanel();
            this.grdOCS0323_1 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell130 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell131 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell132 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell150 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell205 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell206 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell207 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell208 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell209 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell210 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell211 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell212 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell213 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell214 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell215 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell216 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell217 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell218 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell219 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell220 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell221 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell222 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell223 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell224 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell225 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell226 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell227 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell228 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell229 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell230 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell231 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell232 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell233 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell234 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell235 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell236 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell237 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell238 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell239 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell240 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell241 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell242 = new IHIS.Framework.XEditGridCell();
            this.tabGroupSerial = new IHIS.Framework.XTabControl();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.cbxGeneric_YN = new IHIS.Framework.XCheckBox();
            this.btnSelectAllTab = new IHIS.Framework.XButton();
            this.btnSelectCurrentTab = new IHIS.Framework.XButton();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.grdOCS0321 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.layOCS0323 = new IHIS.Framework.MultiLayout();
            this.grdOCS0323_2 = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell243 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell244 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell245 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell246 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell247 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell248 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell249 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell250 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell251 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell252 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell253 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell254 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell255 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell256 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell257 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell258 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell259 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell260 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell261 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell262 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell263 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell264 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell265 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell266 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell267 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell268 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell269 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell270 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell271 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell272 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell273 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell274 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell275 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell276 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell277 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell278 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell279 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell280 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell281 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell282 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell283 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell284 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell285 = new IHIS.Framework.XEditGridCell();
            this.grdOCS0323_3 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell286 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell287 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell288 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell289 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell290 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell291 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell292 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell293 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell294 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell295 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell296 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell297 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell298 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell299 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell300 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell301 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell302 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell303 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell304 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell305 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell306 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell307 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell308 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell309 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell310 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell311 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell312 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell313 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell314 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell315 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell316 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell317 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell318 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell319 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell320 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell321 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell322 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell323 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell324 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell325 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell326 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell327 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell328 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell329 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell330 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell331 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell332 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell333 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell334 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell335 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell336 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell337 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell338 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell339 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell340 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell341 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell342 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell343 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell344 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell345 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell346 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell347 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell348 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell349 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell350 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell351 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell352 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell353 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell354 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell355 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell356 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell357 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell358 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell359 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell360 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell361 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell362 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell363 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell364 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell365 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell366 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell367 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell368 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell369 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell370 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell371 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell372 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell373 = new IHIS.Framework.XEditGridCell();
            this.grdOCS0323_4 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell374 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell375 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell376 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell377 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell378 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell379 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell380 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell381 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell382 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell383 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell384 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell385 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell386 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell387 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell388 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell389 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell390 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell391 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell392 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell393 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell394 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell395 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell396 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell397 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell398 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell399 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell400 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell401 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell402 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell403 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell404 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell405 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell406 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell407 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell408 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell409 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell410 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell411 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell412 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell413 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell414 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell415 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell416 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell417 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell418 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell419 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell420 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell421 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell422 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell423 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell424 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell425 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell426 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell427 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell428 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell429 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell430 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell431 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell432 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell433 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell434 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell435 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell436 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell437 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell438 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell439 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell440 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell441 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell442 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell443 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell444 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell445 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell446 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell447 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell448 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell449 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell450 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell451 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell452 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell453 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell454 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell455 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell456 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell457 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell458 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell459 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell460 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell461 = new IHIS.Framework.XEditGridCell();
            this.grdOCS0323_5 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell462 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell463 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell464 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell465 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell466 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell467 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell468 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell469 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell470 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell471 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell472 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell473 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell474 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell475 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell476 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell477 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell478 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell479 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell480 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell481 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell482 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell483 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell484 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell485 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell486 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell487 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell488 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell489 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell490 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell491 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell492 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell493 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell494 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell495 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell496 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell497 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell498 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell499 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell500 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell501 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell502 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell503 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell504 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell505 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell506 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell507 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell508 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell509 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell510 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell511 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell512 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell513 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell514 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell515 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell516 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell517 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell518 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell519 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell520 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell521 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell522 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell523 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell524 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell525 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell526 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell527 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell528 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell529 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell530 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell531 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell532 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell533 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell534 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell535 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell536 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell537 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell538 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell539 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell540 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell541 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell542 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell543 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell544 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell545 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell546 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell547 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell548 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell549 = new IHIS.Framework.XEditGridCell();
            this.grdOCS0323_6 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell550 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell551 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell552 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell553 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell554 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell555 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell556 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell557 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell558 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell559 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell560 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell561 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell562 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell563 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell564 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell565 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell566 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell567 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell568 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell569 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell570 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell571 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell572 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell573 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell574 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell575 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell576 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell577 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell578 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell579 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell580 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell581 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell582 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell583 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell584 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell585 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell586 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell587 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell588 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell589 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell590 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell591 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell592 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell593 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell594 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell595 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell596 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell597 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell598 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell599 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell600 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell601 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell602 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell603 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell604 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell605 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell606 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell607 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell608 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell609 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell610 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell611 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell612 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell613 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell614 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell615 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell616 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell617 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell618 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell619 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell620 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell621 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell622 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell623 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell624 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell625 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell626 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell627 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell628 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell629 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell630 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell631 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell632 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell633 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell634 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell635 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell636 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell637 = new IHIS.Framework.XEditGridCell();
            this.grdOCS0323_7 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell638 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell639 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell640 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell641 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell642 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell643 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell644 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell645 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell646 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell647 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell648 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell649 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell650 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell651 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell652 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell653 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell654 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell655 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell656 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell657 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell658 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell659 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell660 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell661 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell662 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell663 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell664 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell665 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell666 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell667 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell668 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell669 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell670 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell671 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell672 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell673 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell674 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell675 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell676 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell677 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell678 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell679 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell680 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell681 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell682 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell683 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell684 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell685 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell686 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell687 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell688 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell689 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell690 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell691 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell692 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell693 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell694 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell695 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell696 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell697 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell698 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell699 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell700 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell701 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell702 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell703 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell704 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell705 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell706 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell707 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell708 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell709 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell710 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell711 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell712 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell713 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell714 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell715 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell716 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell717 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell718 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell719 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell720 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell721 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell722 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell723 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell724 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell725 = new IHIS.Framework.XEditGridCell();
            this.grdOCS0323_8 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell726 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell727 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell728 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell729 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell730 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell731 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell732 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell733 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell734 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell735 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell736 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell737 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell738 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell739 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell740 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell741 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell742 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell743 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell744 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell745 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell746 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell747 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell748 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell749 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell750 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell751 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell752 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell753 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell754 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell755 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell756 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell757 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell758 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell759 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell760 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell761 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell762 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell763 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell764 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell765 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell766 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell767 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell768 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell769 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell770 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell771 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell772 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell773 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell774 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell775 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell776 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell777 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell778 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell779 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell780 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell781 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell782 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell783 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell784 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell785 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell786 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell787 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell788 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell789 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell790 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell791 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell792 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell793 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell794 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell795 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell796 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell797 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell798 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell799 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell800 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell801 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell802 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell803 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell804 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell805 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell806 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell807 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell808 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell809 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell810 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell811 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell812 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell813 = new IHIS.Framework.XEditGridCell();
            this.grdOCS0323_9 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell814 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell815 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell816 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell817 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell818 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell819 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell820 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell821 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell822 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell823 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell824 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell825 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell826 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell827 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell828 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell829 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell830 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell831 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell832 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell833 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell834 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell835 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell836 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell837 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell838 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell839 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell840 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell841 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell842 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell843 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell844 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell845 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell846 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell847 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell848 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell849 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell850 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell851 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell852 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell853 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell854 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell855 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell856 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell857 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell858 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell859 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell860 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell861 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell862 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell863 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell864 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell865 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell866 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell867 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell868 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell869 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell870 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell871 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell872 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell873 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell874 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell875 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell876 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell877 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell878 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell879 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell880 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell881 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell882 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell883 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell884 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell885 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell886 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell887 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell888 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell889 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell890 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell891 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell892 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell893 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell894 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell895 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell896 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell897 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell898 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell899 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell900 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell901 = new IHIS.Framework.XEditGridCell();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem40 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem52 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem81 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem82 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem83 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem84 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem85 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem86 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem87 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem88 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem89 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem90 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem91 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem92 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem93 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem94 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem95 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem96 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem97 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem98 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem99 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem100 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem101 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem102 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem103 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem104 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem105 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem106 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem107 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem108 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem109 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem110 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem111 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem112 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem113 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem114 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem115 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem116 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem117 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem118 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem119 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem120 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem121 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem204 = new IHIS.Framework.MultiLayoutItem();
            this.xEditGridCell902 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell903 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell904 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell905 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell906 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell907 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell908 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell909 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell910 = new IHIS.Framework.XEditGridCell();
            this.panMemb.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0301)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS0301)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS0303)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOrder_danui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloInputControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloMemb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSetOrderCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0303)).BeginInit();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_1)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0321)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS0323)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_9)).BeginInit();
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
            this.ImageList.Images.SetKeyName(5, "");
            this.ImageList.Images.SetKeyName(6, "");
            this.ImageList.Images.SetKeyName(7, "");
            this.ImageList.Images.SetKeyName(8, "");
            // 
            // panMemb
            // 
            this.panMemb.AutoScroll = true;
            this.panMemb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panMemb.BackgroundImage")));
            this.panMemb.Controls.Add(this.rbt);
            this.panMemb.Dock = System.Windows.Forms.DockStyle.Top;
            this.panMemb.Location = new System.Drawing.Point(0, 0);
            this.panMemb.Name = "panMemb";
            this.panMemb.Size = new System.Drawing.Size(1508, 46);
            this.panMemb.TabIndex = 0;
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
            this.rbt.Size = new System.Drawing.Size(140, 26);
            this.rbt.TabIndex = 13;
            this.rbt.Text = "      病院セット";
            this.rbt.UseVisualStyleBackColor = false;
            this.rbt.Visible = false;
            // 
            // xLabel4
            // 
            this.xLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel4.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel4.Image = ((System.Drawing.Image)(resources.GetObject("xLabel4.Image")));
            this.xLabel4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel4.Location = new System.Drawing.Point(1178, 6);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(94, 22);
            this.xLabel4.TabIndex = 20;
            this.xLabel4.Text = "検索語";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearchSetName
            // 
            this.txtSearchSetName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchSetName.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.txtSearchSetName.Location = new System.Drawing.Point(1274, 6);
            this.txtSearchSetName.Name = "txtSearchSetName";
            this.txtSearchSetName.Size = new System.Drawing.Size(228, 20);
            this.txtSearchSetName.TabIndex = 19;
            this.txtSearchSetName.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSearchSetName_DataValidating);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnCPLInfo);
            this.xPanel2.Controls.Add(this.chkIsNewGroup);
            this.xPanel2.Controls.Add(this.btnProcess);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(0, 725);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(1508, 40);
            this.xPanel2.TabIndex = 1;
            // 
            // btnCPLInfo
            // 
            this.btnCPLInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCPLInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnCPLInfo.Image")));
            this.btnCPLInfo.Location = new System.Drawing.Point(190, 5);
            this.btnCPLInfo.Name = "btnCPLInfo";
            this.btnCPLInfo.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnCPLInfo.Size = new System.Drawing.Size(118, 28);
            this.btnCPLInfo.TabIndex = 23;
            this.btnCPLInfo.Text = "検査情報照会";
            this.btnCPLInfo.Visible = false;
            this.btnCPLInfo.Click += new System.EventHandler(this.btnCPLInfo_Click);
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
            this.chkIsNewGroup.Location = new System.Drawing.Point(720, 6);
            this.chkIsNewGroup.Name = "chkIsNewGroup";
            this.chkIsNewGroup.Size = new System.Drawing.Size(218, 24);
            this.chkIsNewGroup.TabIndex = 22;
            this.chkIsNewGroup.Text = "     新規オーダグループ番号生成可否";
            this.chkIsNewGroup.UseVisualStyleBackColor = false;
            this.chkIsNewGroup.Visible = false;
            this.chkIsNewGroup.CheckedChanged += new System.EventHandler(this.chkIsNewGroup_CheckedChanged);
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Location = new System.Drawing.Point(1216, 5);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(98, 28);
            this.btnProcess.TabIndex = 18;
            this.btnProcess.Text = "選択";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(1313, 2);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.Size = new System.Drawing.Size(163, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdOCS0301
            // 
            this.grdOCS0301.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell138,
            this.xEditGridCell141,
            this.xEditGridCell139,
            this.xEditGridCell140,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell142,
            this.xEditGridCell162,
            this.xEditGridCell16,
            this.xEditGridCell144,
            this.xEditGridCell145,
            this.xEditGridCell146,
            this.xEditGridCell147,
            this.xEditGridCell17});
            this.grdOCS0301.ColPerLine = 14;
            this.grdOCS0301.Cols = 14;
            this.grdOCS0301.ControlBinding = true;
            this.grdOCS0301.FixedRows = 1;
            this.grdOCS0301.HeaderHeights.Add(21);
            this.grdOCS0301.Location = new System.Drawing.Point(3, 444);
            this.grdOCS0301.Name = "grdOCS0301";
            this.grdOCS0301.QuerySQL = resources.GetString("grdOCS0301.QuerySQL");
            this.grdOCS0301.Rows = 2;
            this.grdOCS0301.RowStateCheckOnPaint = false;
            this.grdOCS0301.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0301.Size = new System.Drawing.Size(181, 198);
            this.grdOCS0301.TabIndex = 1;
            this.grdOCS0301.Visible = false;
            this.grdOCS0301.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS0301_QueryEnd);
            this.grdOCS0301.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS0301_RowFocusChanged);
            this.grdOCS0301.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0301_QueryStarting);
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellName = "memb";
            this.xEditGridCell138.CellWidth = 65;
            this.xEditGridCell138.HeaderText = "memb";
            this.xEditGridCell138.IsUpdatable = false;
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.CellName = "pk_seq";
            this.xEditGridCell141.Col = 3;
            this.xEditGridCell141.HeaderText = "pk_seq";
            this.xEditGridCell141.IsUpdatable = false;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.CellName = "yaksok_gubun";
            this.xEditGridCell139.Col = 1;
            this.xEditGridCell139.HeaderText = "yaksok_gubun";
            this.xEditGridCell139.IsUpdatable = false;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.CellName = "yaksok_gubun_name";
            this.xEditGridCell140.Col = 2;
            this.xEditGridCell140.HeaderText = "yaksok_gubun_name";
            this.xEditGridCell140.IsUpdatable = false;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "yaksok_code";
            this.xEditGridCell1.Col = 10;
            this.xEditGridCell1.HeaderText = "セットコード";
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "yaksok_name";
            this.xEditGridCell2.Col = 5;
            this.xEditGridCell2.HeaderText = "セットコード名";
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.CellName = "input_tab";
            this.xEditGridCell142.Col = 4;
            this.xEditGridCell142.HeaderText = "input_tab\r\ninput_tab";
            this.xEditGridCell142.IsUpdatable = false;
            // 
            // xEditGridCell162
            // 
            this.xEditGridCell162.CellName = "pk_yaksok";
            this.xEditGridCell162.Col = 11;
            this.xEditGridCell162.HeaderText = "pk_yaksok";
            this.xEditGridCell162.IsUpdatable = false;
            this.xEditGridCell162.IsUpdCol = false;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "input_tab_name";
            this.xEditGridCell16.Col = 12;
            this.xEditGridCell16.HeaderText = "input_tab_name";
            this.xEditGridCell16.IsUpdatable = false;
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.CellName = "select";
            this.xEditGridCell144.Col = 6;
            this.xEditGridCell144.HeaderText = "選択";
            this.xEditGridCell144.IsUpdatable = false;
            this.xEditGridCell144.IsUpdCol = false;
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.CellName = "select_sang";
            this.xEditGridCell145.Col = 7;
            this.xEditGridCell145.HeaderText = "select_sang";
            this.xEditGridCell145.IsUpdatable = false;
            this.xEditGridCell145.IsUpdCol = false;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.CellName = "node1";
            this.xEditGridCell146.Col = 8;
            this.xEditGridCell146.HeaderText = "node1";
            this.xEditGridCell146.IsUpdatable = false;
            this.xEditGridCell146.IsUpdCol = false;
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.CellName = "node2";
            this.xEditGridCell147.Col = 9;
            this.xEditGridCell147.HeaderText = "node2";
            this.xEditGridCell147.IsUpdatable = false;
            this.xEditGridCell147.IsUpdCol = false;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "node3";
            this.xEditGridCell17.Col = 13;
            this.xEditGridCell17.HeaderText = "node3";
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsUpdCol = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 46);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 679);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // dloOrder_danui
            // 
            this.dloOrder_danui.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "code";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "code_name";
            // 
            // dloInputControl
            // 
            this.dloInputControl.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem5,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27});
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "input_control";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "input_control_name";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "specimen_cr_yn";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "suryang_cr_yn";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "ord_danui_cr_yn";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "dv_time_cr_yn";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "dv_cr_yn";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "nalsu_cr_yn";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "jusa_cr_yn";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "bogyong_code_cr_yn";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "toiwon_drg_cr_yn";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "tpn_cr_yn";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "anti_cancer_cr_yn";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "fluid_cr_yn";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "portable_cr_yn";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "doner_cr_yn";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "amt_cr_yn";
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
            // dloMemb
            // 
            this.dloMemb.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "memb";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "memb_name";
            // 
            // tvwOCS0300
            // 
            this.tvwOCS0300.AllowDrop = true;
            this.tvwOCS0300.BackColor = System.Drawing.SystemColors.Window;
            this.tvwOCS0300.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvwOCS0300.HideSelection = false;
            this.tvwOCS0300.HotTracking = true;
            this.tvwOCS0300.ImageIndex = 2;
            this.tvwOCS0300.ImageList = this.ImageList;
            this.tvwOCS0300.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tvwOCS0300.Location = new System.Drawing.Point(1, 46);
            this.tvwOCS0300.Name = "tvwOCS0300";
            this.tvwOCS0300.SelectedImageIndex = 3;
            this.tvwOCS0300.Size = new System.Drawing.Size(187, 679);
            this.tvwOCS0300.TabIndex = 25;
            this.tvwOCS0300.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwOCS0300_AfterSelect);
            this.tvwOCS0300.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwOCS0300_MouseDown);
            // 
            // dloSetOrderCopy
            // 
            this.dloSetOrderCopy.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11});
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "source_memb";
            this.multiLayoutItem6.IsUpdItem = true;
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "source_yaksok_code";
            this.multiLayoutItem7.IsUpdItem = true;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "target_memb";
            this.multiLayoutItem8.IsUpdItem = true;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "yaksok_code";
            this.multiLayoutItem9.IsUpdItem = true;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "yaksok_name";
            this.multiLayoutItem10.IsUpdItem = true;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "input_tab";
            this.multiLayoutItem11.IsUpdItem = true;
            // 
            // grdOCS0303
            // 
            this.grdOCS0303.AddedHeaderLine = 1;
            this.grdOCS0303.ApplyPaintEventToAllColumn = true;
            this.grdOCS0303.CallerID = '2';
            this.grdOCS0303.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell90,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell98,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell102,
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
            this.xEditGridCell125,
            this.xEditGridCell126,
            this.xEditGridCell127,
            this.xEditGridCell128,
            this.xEditGridCell129,
            this.xEditGridCell133,
            this.xEditGridCell134,
            this.xEditGridCell135,
            this.xEditGridCell136,
            this.xEditGridCell137,
            this.xEditGridCell143,
            this.xEditGridCell148,
            this.xEditGridCell149,
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
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell15});
            this.grdOCS0303.ColPerLine = 26;
            this.grdOCS0303.Cols = 27;
            this.grdOCS0303.ControlBinding = true;
            this.grdOCS0303.FixedCols = 1;
            this.grdOCS0303.FixedRows = 2;
            this.grdOCS0303.HeaderHeights.Add(37);
            this.grdOCS0303.HeaderHeights.Add(0);
            this.grdOCS0303.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader3});
            this.grdOCS0303.Location = new System.Drawing.Point(3, 84);
            this.grdOCS0303.Name = "grdOCS0303";
            this.grdOCS0303.QuerySQL = resources.GetString("grdOCS0303.QuerySQL");
            this.grdOCS0303.ReadOnly = true;
            this.grdOCS0303.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS0303.RowHeaderVisible = true;
            this.grdOCS0303.Rows = 3;
            this.grdOCS0303.RowStateCheckOnPaint = false;
            this.grdOCS0303.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0303.Size = new System.Drawing.Size(181, 108);
            this.grdOCS0303.TabIndex = 44;
            this.grdOCS0303.ToolTipActive = true;
            this.grdOCS0303.Visible = false;
            this.grdOCS0303.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0303_MouseDown);
            this.grdOCS0303.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS0303_QueryEnd);
            this.grdOCS0303.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0303_QueryStarting);
            this.grdOCS0303.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0303_GridColumnChanged);
            this.grdOCS0303.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0303_GridCellPainting);
            this.grdOCS0303.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS0303_RowFocusChanged);
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "memb";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.HeaderText = "memb";
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "yaksok_code";
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.HeaderText = "yaksok_code";
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "pk_yaksok";
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.HeaderText = "pk_yaksok";
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "pkocs0303";
            this.xEditGridCell81.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.HeaderText = "pkocs0303";
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "group_ser";
            this.xEditGridCell82.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell82.CellWidth = 25;
            this.xEditGridCell82.Col = 4;
            this.xEditGridCell82.HeaderText = "G\r\nR";
            this.xEditGridCell82.RowSpan = 2;
            this.xEditGridCell82.SuppressRepeating = true;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "mix_group";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.HeaderText = "mix_group";
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "seq";
            this.xEditGridCell84.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.HeaderText = "seq";
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "order_gubun";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.HeaderText = "order_gubun";
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "order_gubun_name";
            this.xEditGridCell86.CellWidth = 65;
            this.xEditGridCell86.Col = 3;
            this.xEditGridCell86.HeaderText = "オ―ダ\r\n区分";
            this.xEditGridCell86.RowSpan = 2;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "input_tab";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.HeaderText = "input_tab";
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "hangmog_code";
            this.xEditGridCell88.CellWidth = 75;
            this.xEditGridCell88.Col = 5;
            this.xEditGridCell88.HeaderText = "オ―ダコード";
            this.xEditGridCell88.RowSpan = 2;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellLen = 80;
            this.xEditGridCell89.CellName = "hangmog_name";
            this.xEditGridCell89.CellWidth = 268;
            this.xEditGridCell89.Col = 6;
            this.xEditGridCell89.HeaderText = "オ―ダ名";
            this.xEditGridCell89.RowSpan = 2;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "specimen_code";
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.HeaderText = "specimen_code";
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellLen = 100;
            this.xEditGridCell91.CellName = "specimen_name";
            this.xEditGridCell91.CellWidth = 60;
            this.xEditGridCell91.Col = 8;
            this.xEditGridCell91.HeaderText = "検体";
            this.xEditGridCell91.RowSpan = 2;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "suryang";
            this.xEditGridCell92.CellWidth = 35;
            this.xEditGridCell92.Col = 9;
            this.xEditGridCell92.HeaderText = "数量";
            this.xEditGridCell92.RowSpan = 2;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "ord_danui";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.HeaderText = "ord_danui";
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellLen = 6;
            this.xEditGridCell94.CellName = "order_danui_name";
            this.xEditGridCell94.CellWidth = 40;
            this.xEditGridCell94.Col = 10;
            this.xEditGridCell94.HeaderText = "単位";
            this.xEditGridCell94.RowSpan = 2;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellLen = 1;
            this.xEditGridCell95.CellName = "dv_time";
            this.xEditGridCell95.CellWidth = 15;
            this.xEditGridCell95.Col = 11;
            this.xEditGridCell95.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell95.HeaderText = "DV類型";
            this.xEditGridCell95.Row = 1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "dv";
            this.xEditGridCell96.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell96.CellWidth = 25;
            this.xEditGridCell96.Col = 12;
            this.xEditGridCell96.HeaderText = "回数";
            this.xEditGridCell96.Row = 1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "dv_1";
            this.xEditGridCell97.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.HeaderText = "dv_1";
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "dv_2";
            this.xEditGridCell98.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.HeaderText = "dv_2";
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "dv_3";
            this.xEditGridCell99.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.HeaderText = "dv_3";
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "dv_4";
            this.xEditGridCell100.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell100.CellWidth = 10;
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.HeaderText = "dv_4";
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "nalsu";
            this.xEditGridCell101.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell101.CellWidth = 35;
            this.xEditGridCell101.Col = 13;
            this.xEditGridCell101.HeaderText = "日数";
            this.xEditGridCell101.RowSpan = 2;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "jusa";
            this.xEditGridCell102.Col = -1;
            this.xEditGridCell102.HeaderText = "jusa";
            this.xEditGridCell102.IsVisible = false;
            this.xEditGridCell102.Row = -1;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellLen = 100;
            this.xEditGridCell103.CellName = "jusa_name";
            this.xEditGridCell103.CellWidth = 68;
            this.xEditGridCell103.Col = 15;
            this.xEditGridCell103.HeaderText = "注射";
            this.xEditGridCell103.RowSpan = 2;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "bogyong_code";
            this.xEditGridCell104.Col = -1;
            this.xEditGridCell104.HeaderText = "bogyong_code";
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "bogyong_name";
            this.xEditGridCell105.CellWidth = 90;
            this.xEditGridCell105.Col = 14;
            this.xEditGridCell105.HeaderText = "用法";
            this.xEditGridCell105.RowSpan = 2;
            this.xEditGridCell105.SuppressRepeating = true;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "jusa_spd_gubun";
            this.xEditGridCell106.CellWidth = 40;
            this.xEditGridCell106.Col = 16;
            this.xEditGridCell106.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell106.HeaderText = "ml\r\nhr";
            this.xEditGridCell106.RowSpan = 2;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "hubal_change_yn";
            this.xEditGridCell107.CellWidth = 30;
            this.xEditGridCell107.Col = 24;
            this.xEditGridCell107.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell107.HeaderText = "後発\r\n不可";
            this.xEditGridCell107.IsUpdatable = false;
            this.xEditGridCell107.RowSpan = 2;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "pharmacy";
            this.xEditGridCell108.CellWidth = 22;
            this.xEditGridCell108.Col = 23;
            this.xEditGridCell108.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell108.HeaderText = "簡\r\n易";
            this.xEditGridCell108.IsUpdatable = false;
            this.xEditGridCell108.RowSpan = 2;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "drg_pack_yn";
            this.xEditGridCell109.CellWidth = 22;
            this.xEditGridCell109.Col = 22;
            this.xEditGridCell109.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell109.HeaderText = "一\r\n包";
            this.xEditGridCell109.IsUpdatable = false;
            this.xEditGridCell109.RowSpan = 2;
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellLen = 1;
            this.xEditGridCell110.CellName = "emergency";
            this.xEditGridCell110.CellWidth = 22;
            this.xEditGridCell110.Col = 19;
            this.xEditGridCell110.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell110.HeaderText = "緊\r\n急";
            this.xEditGridCell110.IsUpdatable = false;
            this.xEditGridCell110.RowSpan = 2;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellLen = 1;
            this.xEditGridCell111.CellName = "pay";
            this.xEditGridCell111.CellWidth = 52;
            this.xEditGridCell111.Col = -1;
            this.xEditGridCell111.HeaderText = "請求\r\n区分";
            this.xEditGridCell111.IsUpdatable = false;
            this.xEditGridCell111.IsVisible = false;
            this.xEditGridCell111.Row = -1;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellLen = 1;
            this.xEditGridCell112.CellName = "portable_yn";
            this.xEditGridCell112.CellWidth = 49;
            this.xEditGridCell112.Col = -1;
            this.xEditGridCell112.HeaderText = "移動\r\n撮影";
            this.xEditGridCell112.IsUpdatable = false;
            this.xEditGridCell112.IsVisible = false;
            this.xEditGridCell112.Row = -1;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellLen = 1;
            this.xEditGridCell113.CellName = "powder_yn";
            this.xEditGridCell113.CellWidth = 22;
            this.xEditGridCell113.Col = -1;
            this.xEditGridCell113.HeaderText = "粉\r\n薬";
            this.xEditGridCell113.IsUpdatable = false;
            this.xEditGridCell113.IsVisible = false;
            this.xEditGridCell113.Row = -1;
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellLen = 1;
            this.xEditGridCell114.CellName = "muhyo";
            this.xEditGridCell114.CellWidth = 25;
            this.xEditGridCell114.Col = 21;
            this.xEditGridCell114.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell114.HeaderText = "無\r\n効";
            this.xEditGridCell114.IsUpdatable = false;
            this.xEditGridCell114.RowSpan = 2;
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellLen = 1;
            this.xEditGridCell115.CellName = "prn_yn";
            this.xEditGridCell115.Col = -1;
            this.xEditGridCell115.HeaderText = "prn_yn";
            this.xEditGridCell115.IsUpdatable = false;
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "order_remark";
            this.xEditGridCell116.CellWidth = 112;
            this.xEditGridCell116.Col = 25;
            this.xEditGridCell116.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell116.HeaderText = "Comment";
            this.xEditGridCell116.IsUpdatable = false;
            this.xEditGridCell116.RowSpan = 2;
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "nurse_remark";
            this.xEditGridCell117.CellWidth = 109;
            this.xEditGridCell117.Col = 26;
            this.xEditGridCell117.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell117.HeaderText = "看護\r\nComment";
            this.xEditGridCell117.IsUpdatable = false;
            this.xEditGridCell117.RowSpan = 2;
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellName = "bulyong_check";
            this.xEditGridCell118.Col = -1;
            this.xEditGridCell118.HeaderText = "bulyong_check";
            this.xEditGridCell118.IsUpdatable = false;
            this.xEditGridCell118.IsVisible = false;
            this.xEditGridCell118.Row = -1;
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "slip_code";
            this.xEditGridCell119.Col = -1;
            this.xEditGridCell119.HeaderText = "slip_code";
            this.xEditGridCell119.IsUpdatable = false;
            this.xEditGridCell119.IsVisible = false;
            this.xEditGridCell119.Row = -1;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "group_yn";
            this.xEditGridCell120.Col = -1;
            this.xEditGridCell120.HeaderText = "group_yn";
            this.xEditGridCell120.IsUpdatable = false;
            this.xEditGridCell120.IsVisible = false;
            this.xEditGridCell120.Row = -1;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellName = "order_gubun_bas";
            this.xEditGridCell121.Col = -1;
            this.xEditGridCell121.HeaderText = "order_gubun_bas";
            this.xEditGridCell121.IsUpdatable = false;
            this.xEditGridCell121.IsVisible = false;
            this.xEditGridCell121.Row = -1;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellName = "input_control";
            this.xEditGridCell122.Col = -1;
            this.xEditGridCell122.HeaderText = "input_control";
            this.xEditGridCell122.IsUpdatable = false;
            this.xEditGridCell122.IsVisible = false;
            this.xEditGridCell122.Row = -1;
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellName = "sg_code";
            this.xEditGridCell123.Col = -1;
            this.xEditGridCell123.HeaderText = "sg_code";
            this.xEditGridCell123.IsUpdatable = false;
            this.xEditGridCell123.IsVisible = false;
            this.xEditGridCell123.Row = -1;
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "suga_yn";
            this.xEditGridCell124.Col = -1;
            this.xEditGridCell124.HeaderText = "suga_yn";
            this.xEditGridCell124.IsUpdatable = false;
            this.xEditGridCell124.IsVisible = false;
            this.xEditGridCell124.Row = -1;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.CellName = "emergency_check";
            this.xEditGridCell125.Col = -1;
            this.xEditGridCell125.HeaderText = "emergency_check";
            this.xEditGridCell125.IsUpdatable = false;
            this.xEditGridCell125.IsVisible = false;
            this.xEditGridCell125.Row = -1;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "limit_suryang";
            this.xEditGridCell126.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell126.Col = -1;
            this.xEditGridCell126.HeaderText = "limit_suryang";
            this.xEditGridCell126.IsUpdatable = false;
            this.xEditGridCell126.IsVisible = false;
            this.xEditGridCell126.Row = -1;
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "specimen_yn";
            this.xEditGridCell127.Col = -1;
            this.xEditGridCell127.HeaderText = "specimen_yn";
            this.xEditGridCell127.IsUpdatable = false;
            this.xEditGridCell127.IsVisible = false;
            this.xEditGridCell127.Row = -1;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "jaeryo_yn";
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.HeaderText = "jaeryo_yn";
            this.xEditGridCell128.IsUpdatable = false;
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "ord_danui_check";
            this.xEditGridCell129.Col = -1;
            this.xEditGridCell129.HeaderText = "ord_danui_check";
            this.xEditGridCell129.IsUpdatable = false;
            this.xEditGridCell129.IsVisible = false;
            this.xEditGridCell129.Row = -1;
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.CellName = "wonyoi_order_yn";
            this.xEditGridCell133.CellWidth = 22;
            this.xEditGridCell133.Col = 20;
            this.xEditGridCell133.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell133.HeaderText = "院\r\n外";
            this.xEditGridCell133.IsUpdatable = false;
            this.xEditGridCell133.RowSpan = 2;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell134.Col = -1;
            this.xEditGridCell134.HeaderText = "施行";
            this.xEditGridCell134.IsUpdatable = false;
            this.xEditGridCell134.IsVisible = false;
            this.xEditGridCell134.Row = -1;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell135.Col = -1;
            this.xEditGridCell135.HeaderText = "結果";
            this.xEditGridCell135.IsUpdatable = false;
            this.xEditGridCell135.IsVisible = false;
            this.xEditGridCell135.Row = -1;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell136.Col = -1;
            this.xEditGridCell136.HeaderText = "wonyoi_order_cr_yn";
            this.xEditGridCell136.IsUpdatable = false;
            this.xEditGridCell136.IsVisible = false;
            this.xEditGridCell136.Row = -1;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "nday_yn";
            this.xEditGridCell137.Col = -1;
            this.xEditGridCell137.HeaderText = "nday_yn";
            this.xEditGridCell137.IsUpdatable = false;
            this.xEditGridCell137.IsVisible = false;
            this.xEditGridCell137.Row = -1;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "muhyo_yn";
            this.xEditGridCell143.Col = -1;
            this.xEditGridCell143.HeaderText = "muhyo_yn";
            this.xEditGridCell143.IsUpdatable = false;
            this.xEditGridCell143.IsVisible = false;
            this.xEditGridCell143.Row = -1;
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellName = "pay_name";
            this.xEditGridCell148.Col = -1;
            this.xEditGridCell148.HeaderText = "pay_name";
            this.xEditGridCell148.IsUpdatable = false;
            this.xEditGridCell148.IsVisible = false;
            this.xEditGridCell148.Row = -1;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "bun_code";
            this.xEditGridCell149.Col = -1;
            this.xEditGridCell149.HeaderText = "bun_code";
            this.xEditGridCell149.IsUpdatable = false;
            this.xEditGridCell149.IsVisible = false;
            this.xEditGridCell149.Row = -1;
            // 
            // xEditGridCell151
            // 
            this.xEditGridCell151.CellName = "data_control";
            this.xEditGridCell151.Col = -1;
            this.xEditGridCell151.HeaderText = "data_control";
            this.xEditGridCell151.IsUpdatable = false;
            this.xEditGridCell151.IsVisible = false;
            this.xEditGridCell151.Row = -1;
            // 
            // xEditGridCell152
            // 
            this.xEditGridCell152.CellName = "donbog_yn";
            this.xEditGridCell152.Col = -1;
            this.xEditGridCell152.HeaderText = "donbog_yn";
            this.xEditGridCell152.IsUpdatable = false;
            this.xEditGridCell152.IsVisible = false;
            this.xEditGridCell152.Row = -1;
            // 
            // xEditGridCell153
            // 
            this.xEditGridCell153.CellName = "dv_name";
            this.xEditGridCell153.Col = -1;
            this.xEditGridCell153.HeaderText = "dv_name";
            this.xEditGridCell153.IsUpdatable = false;
            this.xEditGridCell153.IsVisible = false;
            this.xEditGridCell153.Row = -1;
            // 
            // xEditGridCell154
            // 
            this.xEditGridCell154.CellName = "drg_info";
            this.xEditGridCell154.Col = -1;
            this.xEditGridCell154.HeaderText = "drg_info";
            this.xEditGridCell154.IsReadOnly = true;
            this.xEditGridCell154.IsUpdatable = false;
            this.xEditGridCell154.IsVisible = false;
            this.xEditGridCell154.Row = -1;
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.CellName = "drg_bunryu";
            this.xEditGridCell155.Col = -1;
            this.xEditGridCell155.HeaderText = "drg_bunryu";
            this.xEditGridCell155.IsReadOnly = true;
            this.xEditGridCell155.IsUpdatable = false;
            this.xEditGridCell155.IsVisible = false;
            this.xEditGridCell155.Row = -1;
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.CellName = "child_gubun";
            this.xEditGridCell156.CellWidth = 19;
            this.xEditGridCell156.Col = 2;
            this.xEditGridCell156.IsUpdatable = false;
            this.xEditGridCell156.RowSpan = 2;
            // 
            // xEditGridCell157
            // 
            this.xEditGridCell157.CellName = "bom_source_key";
            this.xEditGridCell157.Col = -1;
            this.xEditGridCell157.IsUpdatable = false;
            this.xEditGridCell157.IsVisible = false;
            this.xEditGridCell157.Row = -1;
            // 
            // xEditGridCell158
            // 
            this.xEditGridCell158.CellName = "haengwee_yn";
            this.xEditGridCell158.Col = -1;
            this.xEditGridCell158.IsUpdatable = false;
            this.xEditGridCell158.IsVisible = false;
            this.xEditGridCell158.Row = -1;
            // 
            // xEditGridCell159
            // 
            this.xEditGridCell159.CellName = "org_key";
            this.xEditGridCell159.Col = -1;
            this.xEditGridCell159.IsUpdatable = false;
            this.xEditGridCell159.IsVisible = false;
            this.xEditGridCell159.Row = -1;
            // 
            // xEditGridCell160
            // 
            this.xEditGridCell160.CellName = "parent_key";
            this.xEditGridCell160.Col = -1;
            this.xEditGridCell160.IsUpdatable = false;
            this.xEditGridCell160.IsVisible = false;
            this.xEditGridCell160.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "fkocs0300_seq";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "child_yn";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "jundal_table_out";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "jundal_part_out";
            this.xEditGridCell8.CellWidth = 65;
            this.xEditGridCell8.Col = 17;
            this.xEditGridCell8.HeaderText = "外来\r\n行為部署";
            this.xEditGridCell8.RowSpan = 2;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "jundal_table_inp";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "jundal_part_inp";
            this.xEditGridCell10.CellWidth = 65;
            this.xEditGridCell10.Col = 18;
            this.xEditGridCell10.HeaderText = "入院\r\n行為部署";
            this.xEditGridCell10.RowSpan = 2;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "move_part_out";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "move_part_inp";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "jundal_part_out_name";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "jundal_part_inp_name";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "wonnae_drg_yn";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "wonnae_drg_yn";
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "dv_5";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "dv_6";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "dv_7";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "dv_8";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "general_disp_yn";
            this.xEditGridCell23.Col = 7;
            this.xEditGridCell23.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell23.HeaderText = "一般名\r\n  表示";
            this.xEditGridCell23.RowSpan = 2;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "generic_name";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.HeaderText = "一般名";
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell15.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell15.CellName = "select";
            this.xEditGridCell15.CellWidth = 30;
            this.xEditGridCell15.Col = 1;
            this.xEditGridCell15.HeaderText = "選択";
            this.xEditGridCell15.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell15.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell15.RowSpan = 2;
            this.xEditGridCell15.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xGridHeader3
            // 
            this.xGridHeader3.Col = 11;
            this.xGridHeader3.ColSpan = 2;
            this.xGridHeader3.HeaderText = "回数";
            this.xGridHeader3.HeaderWidth = 15;
            // 
            // xEditGridCell161
            // 
            this.xEditGridCell161.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell161.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell161.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell161.CellName = "select";
            this.xEditGridCell161.CellWidth = 30;
            this.xEditGridCell161.Col = 1;
            this.xEditGridCell161.HeaderText = "選択";
            this.xEditGridCell161.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell161.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell161.RowSpan = 2;
            this.xEditGridCell161.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // pnlOrder
            // 
            this.pnlOrder.Controls.Add(this.grdOCS0323_9);
            this.pnlOrder.Controls.Add(this.grdOCS0323_8);
            this.pnlOrder.Controls.Add(this.grdOCS0323_7);
            this.pnlOrder.Controls.Add(this.grdOCS0323_6);
            this.pnlOrder.Controls.Add(this.grdOCS0323_5);
            this.pnlOrder.Controls.Add(this.grdOCS0323_4);
            this.pnlOrder.Controls.Add(this.grdOCS0323_3);
            this.pnlOrder.Controls.Add(this.grdOCS0323_2);
            this.pnlOrder.Controls.Add(this.grdOCS0323_1);
            this.pnlOrder.Controls.Add(this.tabGroupSerial);
            this.pnlOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrder.DrawBorder = true;
            this.pnlOrder.Location = new System.Drawing.Point(0, 0);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(1320, 641);
            this.pnlOrder.TabIndex = 19;
            // 
            // grdOCS0323_1
            // 
            this.grdOCS0323_1.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell74,
            this.xEditGridCell75,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell130,
            this.xEditGridCell131,
            this.xEditGridCell132,
            this.xEditGridCell150,
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
            this.xEditGridCell204,
            this.xEditGridCell205,
            this.xEditGridCell206,
            this.xEditGridCell207,
            this.xEditGridCell208,
            this.xEditGridCell209,
            this.xEditGridCell210,
            this.xEditGridCell211,
            this.xEditGridCell212,
            this.xEditGridCell213,
            this.xEditGridCell214,
            this.xEditGridCell215,
            this.xEditGridCell216,
            this.xEditGridCell217,
            this.xEditGridCell218,
            this.xEditGridCell219,
            this.xEditGridCell220,
            this.xEditGridCell221,
            this.xEditGridCell222,
            this.xEditGridCell223,
            this.xEditGridCell224,
            this.xEditGridCell225,
            this.xEditGridCell226,
            this.xEditGridCell227,
            this.xEditGridCell228,
            this.xEditGridCell229,
            this.xEditGridCell230,
            this.xEditGridCell231,
            this.xEditGridCell232,
            this.xEditGridCell233,
            this.xEditGridCell234,
            this.xEditGridCell235,
            this.xEditGridCell236,
            this.xEditGridCell237,
            this.xEditGridCell238,
            this.xEditGridCell239,
            this.xEditGridCell240,
            this.xEditGridCell241,
            this.xEditGridCell242,
            this.xEditGridCell902});
            this.grdOCS0323_1.ColPerLine = 2;
            this.grdOCS0323_1.Cols = 2;
            this.grdOCS0323_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdOCS0323_1.FixedRows = 1;
            this.grdOCS0323_1.HeaderHeights.Add(21);
            this.grdOCS0323_1.Location = new System.Drawing.Point(0, 0);
            this.grdOCS0323_1.Name = "grdOCS0323_1";
            this.grdOCS0323_1.Rows = 2;
            this.grdOCS0323_1.RowStateCheckOnPaint = false;
            this.grdOCS0323_1.Size = new System.Drawing.Size(146, 639);
            this.grdOCS0323_1.TabIndex = 46;
            this.grdOCS0323_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0323_all_MouseDown);
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellLen = 100;
            this.xEditGridCell74.CellName = "memb";
            this.xEditGridCell74.Col = -1;
            this.xEditGridCell74.IsVisible = false;
            this.xEditGridCell74.Row = -1;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellLen = 100;
            this.xEditGridCell75.CellName = "fkocs0321";
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellLen = 100;
            this.xEditGridCell76.CellName = "pk_yaksok";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellLen = 100;
            this.xEditGridCell77.CellName = "pkocs0323";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.CellLen = 100;
            this.xEditGridCell130.CellName = "group_ser";
            this.xEditGridCell130.Col = -1;
            this.xEditGridCell130.IsVisible = false;
            this.xEditGridCell130.Row = -1;
            // 
            // xEditGridCell131
            // 
            this.xEditGridCell131.CellLen = 100;
            this.xEditGridCell131.CellName = "mix_group";
            this.xEditGridCell131.Col = -1;
            this.xEditGridCell131.IsVisible = false;
            this.xEditGridCell131.Row = -1;
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.CellLen = 100;
            this.xEditGridCell132.CellName = "seq";
            this.xEditGridCell132.Col = -1;
            this.xEditGridCell132.IsVisible = false;
            this.xEditGridCell132.Row = -1;
            // 
            // xEditGridCell150
            // 
            this.xEditGridCell150.CellLen = 100;
            this.xEditGridCell150.CellName = "order_gubun";
            this.xEditGridCell150.Col = -1;
            this.xEditGridCell150.IsVisible = false;
            this.xEditGridCell150.Row = -1;
            // 
            // xEditGridCell163
            // 
            this.xEditGridCell163.CellLen = 100;
            this.xEditGridCell163.CellName = "order_gubun_name";
            this.xEditGridCell163.Col = -1;
            this.xEditGridCell163.IsVisible = false;
            this.xEditGridCell163.Row = -1;
            // 
            // xEditGridCell164
            // 
            this.xEditGridCell164.CellLen = 100;
            this.xEditGridCell164.CellName = "input_tab";
            this.xEditGridCell164.Col = -1;
            this.xEditGridCell164.IsVisible = false;
            this.xEditGridCell164.Row = -1;
            // 
            // xEditGridCell165
            // 
            this.xEditGridCell165.CellLen = 100;
            this.xEditGridCell165.CellName = "hangmog_code";
            this.xEditGridCell165.Col = -1;
            this.xEditGridCell165.IsVisible = false;
            this.xEditGridCell165.Row = -1;
            // 
            // xEditGridCell166
            // 
            this.xEditGridCell166.CellLen = 100;
            this.xEditGridCell166.CellName = "hangmog_name";
            this.xEditGridCell166.CellWidth = 115;
            this.xEditGridCell166.Col = 1;
            this.xEditGridCell166.HeaderText = "オーダ名";
            this.xEditGridCell166.IsReadOnly = true;
            // 
            // xEditGridCell167
            // 
            this.xEditGridCell167.CellLen = 100;
            this.xEditGridCell167.CellName = "specimen_code";
            this.xEditGridCell167.Col = -1;
            this.xEditGridCell167.IsVisible = false;
            this.xEditGridCell167.Row = -1;
            // 
            // xEditGridCell168
            // 
            this.xEditGridCell168.CellLen = 100;
            this.xEditGridCell168.CellName = "specimen_name";
            this.xEditGridCell168.Col = -1;
            this.xEditGridCell168.IsVisible = false;
            this.xEditGridCell168.Row = -1;
            // 
            // xEditGridCell169
            // 
            this.xEditGridCell169.CellLen = 100;
            this.xEditGridCell169.CellName = "suryang";
            this.xEditGridCell169.Col = -1;
            this.xEditGridCell169.IsVisible = false;
            this.xEditGridCell169.Row = -1;
            // 
            // xEditGridCell170
            // 
            this.xEditGridCell170.CellLen = 100;
            this.xEditGridCell170.CellName = "ord_danui";
            this.xEditGridCell170.Col = -1;
            this.xEditGridCell170.IsVisible = false;
            this.xEditGridCell170.Row = -1;
            // 
            // xEditGridCell171
            // 
            this.xEditGridCell171.CellLen = 100;
            this.xEditGridCell171.CellName = "order_danui_name";
            this.xEditGridCell171.Col = -1;
            this.xEditGridCell171.IsVisible = false;
            this.xEditGridCell171.Row = -1;
            // 
            // xEditGridCell172
            // 
            this.xEditGridCell172.CellLen = 100;
            this.xEditGridCell172.CellName = "dv_time";
            this.xEditGridCell172.Col = -1;
            this.xEditGridCell172.IsVisible = false;
            this.xEditGridCell172.Row = -1;
            // 
            // xEditGridCell173
            // 
            this.xEditGridCell173.CellLen = 100;
            this.xEditGridCell173.CellName = "dv";
            this.xEditGridCell173.Col = -1;
            this.xEditGridCell173.IsVisible = false;
            this.xEditGridCell173.Row = -1;
            // 
            // xEditGridCell174
            // 
            this.xEditGridCell174.CellLen = 100;
            this.xEditGridCell174.CellName = "dv_1";
            this.xEditGridCell174.Col = -1;
            this.xEditGridCell174.IsVisible = false;
            this.xEditGridCell174.Row = -1;
            // 
            // xEditGridCell175
            // 
            this.xEditGridCell175.CellLen = 100;
            this.xEditGridCell175.CellName = "dv_2";
            this.xEditGridCell175.Col = -1;
            this.xEditGridCell175.IsVisible = false;
            this.xEditGridCell175.Row = -1;
            // 
            // xEditGridCell176
            // 
            this.xEditGridCell176.CellLen = 100;
            this.xEditGridCell176.CellName = "dv_3";
            this.xEditGridCell176.Col = -1;
            this.xEditGridCell176.IsVisible = false;
            this.xEditGridCell176.Row = -1;
            // 
            // xEditGridCell177
            // 
            this.xEditGridCell177.CellLen = 100;
            this.xEditGridCell177.CellName = "dv_4";
            this.xEditGridCell177.Col = -1;
            this.xEditGridCell177.IsVisible = false;
            this.xEditGridCell177.Row = -1;
            // 
            // xEditGridCell178
            // 
            this.xEditGridCell178.CellLen = 100;
            this.xEditGridCell178.CellName = "nalsu";
            this.xEditGridCell178.Col = -1;
            this.xEditGridCell178.IsVisible = false;
            this.xEditGridCell178.Row = -1;
            // 
            // xEditGridCell179
            // 
            this.xEditGridCell179.CellLen = 100;
            this.xEditGridCell179.CellName = "jusa";
            this.xEditGridCell179.Col = -1;
            this.xEditGridCell179.IsVisible = false;
            this.xEditGridCell179.Row = -1;
            // 
            // xEditGridCell180
            // 
            this.xEditGridCell180.CellLen = 100;
            this.xEditGridCell180.CellName = "jusa_name";
            this.xEditGridCell180.Col = -1;
            this.xEditGridCell180.IsVisible = false;
            this.xEditGridCell180.Row = -1;
            // 
            // xEditGridCell181
            // 
            this.xEditGridCell181.CellLen = 100;
            this.xEditGridCell181.CellName = "bogyong_code";
            this.xEditGridCell181.Col = -1;
            this.xEditGridCell181.IsVisible = false;
            this.xEditGridCell181.Row = -1;
            // 
            // xEditGridCell182
            // 
            this.xEditGridCell182.CellLen = 100;
            this.xEditGridCell182.CellName = "bogyong_name";
            this.xEditGridCell182.Col = -1;
            this.xEditGridCell182.IsVisible = false;
            this.xEditGridCell182.Row = -1;
            // 
            // xEditGridCell183
            // 
            this.xEditGridCell183.CellLen = 100;
            this.xEditGridCell183.CellName = "jusa_spd_gubun";
            this.xEditGridCell183.Col = -1;
            this.xEditGridCell183.IsVisible = false;
            this.xEditGridCell183.Row = -1;
            // 
            // xEditGridCell184
            // 
            this.xEditGridCell184.CellLen = 100;
            this.xEditGridCell184.CellName = "hubal_change_yn";
            this.xEditGridCell184.Col = -1;
            this.xEditGridCell184.IsVisible = false;
            this.xEditGridCell184.Row = -1;
            // 
            // xEditGridCell185
            // 
            this.xEditGridCell185.CellLen = 100;
            this.xEditGridCell185.CellName = "pharmacy";
            this.xEditGridCell185.Col = -1;
            this.xEditGridCell185.IsVisible = false;
            this.xEditGridCell185.Row = -1;
            // 
            // xEditGridCell186
            // 
            this.xEditGridCell186.CellLen = 100;
            this.xEditGridCell186.CellName = "drg_pack_yn";
            this.xEditGridCell186.Col = -1;
            this.xEditGridCell186.IsVisible = false;
            this.xEditGridCell186.Row = -1;
            // 
            // xEditGridCell187
            // 
            this.xEditGridCell187.CellLen = 100;
            this.xEditGridCell187.CellName = "emergency";
            this.xEditGridCell187.Col = -1;
            this.xEditGridCell187.IsVisible = false;
            this.xEditGridCell187.Row = -1;
            // 
            // xEditGridCell188
            // 
            this.xEditGridCell188.CellLen = 100;
            this.xEditGridCell188.CellName = "pay";
            this.xEditGridCell188.Col = -1;
            this.xEditGridCell188.IsVisible = false;
            this.xEditGridCell188.Row = -1;
            // 
            // xEditGridCell189
            // 
            this.xEditGridCell189.CellLen = 100;
            this.xEditGridCell189.CellName = "portable_yn";
            this.xEditGridCell189.Col = -1;
            this.xEditGridCell189.IsVisible = false;
            this.xEditGridCell189.Row = -1;
            // 
            // xEditGridCell190
            // 
            this.xEditGridCell190.CellLen = 100;
            this.xEditGridCell190.CellName = "powder_yn";
            this.xEditGridCell190.Col = -1;
            this.xEditGridCell190.IsVisible = false;
            this.xEditGridCell190.Row = -1;
            // 
            // xEditGridCell191
            // 
            this.xEditGridCell191.CellLen = 100;
            this.xEditGridCell191.CellName = "muhyo";
            this.xEditGridCell191.Col = -1;
            this.xEditGridCell191.IsVisible = false;
            this.xEditGridCell191.Row = -1;
            // 
            // xEditGridCell192
            // 
            this.xEditGridCell192.CellLen = 100;
            this.xEditGridCell192.CellName = "prn_yn";
            this.xEditGridCell192.Col = -1;
            this.xEditGridCell192.IsVisible = false;
            this.xEditGridCell192.Row = -1;
            // 
            // xEditGridCell193
            // 
            this.xEditGridCell193.CellLen = 100;
            this.xEditGridCell193.CellName = "order_remark";
            this.xEditGridCell193.Col = -1;
            this.xEditGridCell193.IsVisible = false;
            this.xEditGridCell193.Row = -1;
            // 
            // xEditGridCell194
            // 
            this.xEditGridCell194.CellLen = 100;
            this.xEditGridCell194.CellName = "nurse_remark";
            this.xEditGridCell194.Col = -1;
            this.xEditGridCell194.IsVisible = false;
            this.xEditGridCell194.Row = -1;
            // 
            // xEditGridCell195
            // 
            this.xEditGridCell195.CellLen = 100;
            this.xEditGridCell195.CellName = "bulyong_check";
            this.xEditGridCell195.Col = -1;
            this.xEditGridCell195.IsVisible = false;
            this.xEditGridCell195.Row = -1;
            // 
            // xEditGridCell196
            // 
            this.xEditGridCell196.CellLen = 100;
            this.xEditGridCell196.CellName = "slip_code";
            this.xEditGridCell196.Col = -1;
            this.xEditGridCell196.IsVisible = false;
            this.xEditGridCell196.Row = -1;
            // 
            // xEditGridCell197
            // 
            this.xEditGridCell197.CellLen = 100;
            this.xEditGridCell197.CellName = "group_yn";
            this.xEditGridCell197.Col = -1;
            this.xEditGridCell197.IsVisible = false;
            this.xEditGridCell197.Row = -1;
            // 
            // xEditGridCell198
            // 
            this.xEditGridCell198.CellLen = 100;
            this.xEditGridCell198.CellName = "order_gubun_bas";
            this.xEditGridCell198.Col = -1;
            this.xEditGridCell198.IsVisible = false;
            this.xEditGridCell198.Row = -1;
            // 
            // xEditGridCell199
            // 
            this.xEditGridCell199.CellLen = 100;
            this.xEditGridCell199.CellName = "input_control";
            this.xEditGridCell199.Col = -1;
            this.xEditGridCell199.IsVisible = false;
            this.xEditGridCell199.Row = -1;
            // 
            // xEditGridCell200
            // 
            this.xEditGridCell200.CellLen = 100;
            this.xEditGridCell200.CellName = "sg_code";
            this.xEditGridCell200.Col = -1;
            this.xEditGridCell200.IsVisible = false;
            this.xEditGridCell200.Row = -1;
            // 
            // xEditGridCell201
            // 
            this.xEditGridCell201.CellLen = 100;
            this.xEditGridCell201.CellName = "suga_yn";
            this.xEditGridCell201.Col = -1;
            this.xEditGridCell201.IsVisible = false;
            this.xEditGridCell201.Row = -1;
            // 
            // xEditGridCell202
            // 
            this.xEditGridCell202.CellLen = 100;
            this.xEditGridCell202.CellName = "emergency_check";
            this.xEditGridCell202.Col = -1;
            this.xEditGridCell202.IsVisible = false;
            this.xEditGridCell202.Row = -1;
            // 
            // xEditGridCell203
            // 
            this.xEditGridCell203.CellLen = 100;
            this.xEditGridCell203.CellName = "limit_suryang";
            this.xEditGridCell203.Col = -1;
            this.xEditGridCell203.IsVisible = false;
            this.xEditGridCell203.Row = -1;
            // 
            // xEditGridCell204
            // 
            this.xEditGridCell204.CellLen = 100;
            this.xEditGridCell204.CellName = "specimen_yn";
            this.xEditGridCell204.Col = -1;
            this.xEditGridCell204.IsVisible = false;
            this.xEditGridCell204.Row = -1;
            // 
            // xEditGridCell205
            // 
            this.xEditGridCell205.CellLen = 100;
            this.xEditGridCell205.CellName = "jaeryo_yn";
            this.xEditGridCell205.Col = -1;
            this.xEditGridCell205.IsVisible = false;
            this.xEditGridCell205.Row = -1;
            // 
            // xEditGridCell206
            // 
            this.xEditGridCell206.CellLen = 100;
            this.xEditGridCell206.CellName = "ord_danui_check";
            this.xEditGridCell206.Col = -1;
            this.xEditGridCell206.IsVisible = false;
            this.xEditGridCell206.Row = -1;
            // 
            // xEditGridCell207
            // 
            this.xEditGridCell207.CellLen = 100;
            this.xEditGridCell207.CellName = "wonyoi_order_yn";
            this.xEditGridCell207.Col = -1;
            this.xEditGridCell207.IsVisible = false;
            this.xEditGridCell207.Row = -1;
            // 
            // xEditGridCell208
            // 
            this.xEditGridCell208.CellLen = 100;
            this.xEditGridCell208.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell208.Col = -1;
            this.xEditGridCell208.IsVisible = false;
            this.xEditGridCell208.Row = -1;
            // 
            // xEditGridCell209
            // 
            this.xEditGridCell209.CellLen = 100;
            this.xEditGridCell209.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell209.Col = -1;
            this.xEditGridCell209.IsVisible = false;
            this.xEditGridCell209.Row = -1;
            // 
            // xEditGridCell210
            // 
            this.xEditGridCell210.CellLen = 100;
            this.xEditGridCell210.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell210.Col = -1;
            this.xEditGridCell210.IsVisible = false;
            this.xEditGridCell210.Row = -1;
            // 
            // xEditGridCell211
            // 
            this.xEditGridCell211.CellLen = 100;
            this.xEditGridCell211.CellName = "nday_yn";
            this.xEditGridCell211.Col = -1;
            this.xEditGridCell211.IsVisible = false;
            this.xEditGridCell211.Row = -1;
            // 
            // xEditGridCell212
            // 
            this.xEditGridCell212.CellLen = 100;
            this.xEditGridCell212.CellName = "muhyo_yn";
            this.xEditGridCell212.Col = -1;
            this.xEditGridCell212.IsVisible = false;
            this.xEditGridCell212.Row = -1;
            // 
            // xEditGridCell213
            // 
            this.xEditGridCell213.CellLen = 100;
            this.xEditGridCell213.CellName = "pay_name";
            this.xEditGridCell213.Col = -1;
            this.xEditGridCell213.IsVisible = false;
            this.xEditGridCell213.Row = -1;
            // 
            // xEditGridCell214
            // 
            this.xEditGridCell214.CellLen = 100;
            this.xEditGridCell214.CellName = "bun_code";
            this.xEditGridCell214.Col = -1;
            this.xEditGridCell214.IsVisible = false;
            this.xEditGridCell214.Row = -1;
            // 
            // xEditGridCell215
            // 
            this.xEditGridCell215.CellLen = 100;
            this.xEditGridCell215.CellName = "data_control";
            this.xEditGridCell215.Col = -1;
            this.xEditGridCell215.IsVisible = false;
            this.xEditGridCell215.Row = -1;
            // 
            // xEditGridCell216
            // 
            this.xEditGridCell216.CellLen = 100;
            this.xEditGridCell216.CellName = "donbog_yn";
            this.xEditGridCell216.Col = -1;
            this.xEditGridCell216.IsVisible = false;
            this.xEditGridCell216.Row = -1;
            // 
            // xEditGridCell217
            // 
            this.xEditGridCell217.CellLen = 100;
            this.xEditGridCell217.CellName = "dv_name";
            this.xEditGridCell217.Col = -1;
            this.xEditGridCell217.IsVisible = false;
            this.xEditGridCell217.Row = -1;
            // 
            // xEditGridCell218
            // 
            this.xEditGridCell218.CellLen = 100;
            this.xEditGridCell218.CellName = "drg_info";
            this.xEditGridCell218.Col = -1;
            this.xEditGridCell218.IsVisible = false;
            this.xEditGridCell218.Row = -1;
            // 
            // xEditGridCell219
            // 
            this.xEditGridCell219.CellLen = 100;
            this.xEditGridCell219.CellName = "drg_bunryu";
            this.xEditGridCell219.Col = -1;
            this.xEditGridCell219.IsVisible = false;
            this.xEditGridCell219.Row = -1;
            // 
            // xEditGridCell220
            // 
            this.xEditGridCell220.CellLen = 100;
            this.xEditGridCell220.CellName = "child_gubun";
            this.xEditGridCell220.Col = -1;
            this.xEditGridCell220.IsVisible = false;
            this.xEditGridCell220.Row = -1;
            // 
            // xEditGridCell221
            // 
            this.xEditGridCell221.CellLen = 100;
            this.xEditGridCell221.CellName = "bom_source_key";
            this.xEditGridCell221.Col = -1;
            this.xEditGridCell221.IsVisible = false;
            this.xEditGridCell221.Row = -1;
            // 
            // xEditGridCell222
            // 
            this.xEditGridCell222.CellLen = 100;
            this.xEditGridCell222.CellName = "haengwee_yn";
            this.xEditGridCell222.Col = -1;
            this.xEditGridCell222.IsVisible = false;
            this.xEditGridCell222.Row = -1;
            // 
            // xEditGridCell223
            // 
            this.xEditGridCell223.CellLen = 100;
            this.xEditGridCell223.CellName = "org_key";
            this.xEditGridCell223.Col = -1;
            this.xEditGridCell223.IsVisible = false;
            this.xEditGridCell223.Row = -1;
            // 
            // xEditGridCell224
            // 
            this.xEditGridCell224.CellLen = 100;
            this.xEditGridCell224.CellName = "parent_key";
            this.xEditGridCell224.Col = -1;
            this.xEditGridCell224.IsVisible = false;
            this.xEditGridCell224.Row = -1;
            // 
            // xEditGridCell225
            // 
            this.xEditGridCell225.CellLen = 100;
            this.xEditGridCell225.CellName = "fkocs0300_seq";
            this.xEditGridCell225.Col = -1;
            this.xEditGridCell225.IsVisible = false;
            this.xEditGridCell225.Row = -1;
            // 
            // xEditGridCell226
            // 
            this.xEditGridCell226.CellLen = 100;
            this.xEditGridCell226.CellName = "child_yn";
            this.xEditGridCell226.Col = -1;
            this.xEditGridCell226.IsVisible = false;
            this.xEditGridCell226.Row = -1;
            // 
            // xEditGridCell227
            // 
            this.xEditGridCell227.CellLen = 100;
            this.xEditGridCell227.CellName = "jundal_table_out";
            this.xEditGridCell227.Col = -1;
            this.xEditGridCell227.IsVisible = false;
            this.xEditGridCell227.Row = -1;
            // 
            // xEditGridCell228
            // 
            this.xEditGridCell228.CellLen = 100;
            this.xEditGridCell228.CellName = "jundal_part_out";
            this.xEditGridCell228.Col = -1;
            this.xEditGridCell228.IsVisible = false;
            this.xEditGridCell228.Row = -1;
            // 
            // xEditGridCell229
            // 
            this.xEditGridCell229.CellLen = 100;
            this.xEditGridCell229.CellName = "jundal_table_inp";
            this.xEditGridCell229.Col = -1;
            this.xEditGridCell229.IsVisible = false;
            this.xEditGridCell229.Row = -1;
            // 
            // xEditGridCell230
            // 
            this.xEditGridCell230.CellLen = 100;
            this.xEditGridCell230.CellName = "jundal_part_inp";
            this.xEditGridCell230.Col = -1;
            this.xEditGridCell230.IsVisible = false;
            this.xEditGridCell230.Row = -1;
            // 
            // xEditGridCell231
            // 
            this.xEditGridCell231.CellLen = 100;
            this.xEditGridCell231.CellName = "move_part_out";
            this.xEditGridCell231.Col = -1;
            this.xEditGridCell231.IsVisible = false;
            this.xEditGridCell231.Row = -1;
            // 
            // xEditGridCell232
            // 
            this.xEditGridCell232.CellLen = 100;
            this.xEditGridCell232.CellName = "move_part_inp";
            this.xEditGridCell232.Col = -1;
            this.xEditGridCell232.IsVisible = false;
            this.xEditGridCell232.Row = -1;
            // 
            // xEditGridCell233
            // 
            this.xEditGridCell233.CellLen = 100;
            this.xEditGridCell233.CellName = "jundal_part_out_name";
            this.xEditGridCell233.Col = -1;
            this.xEditGridCell233.IsVisible = false;
            this.xEditGridCell233.Row = -1;
            // 
            // xEditGridCell234
            // 
            this.xEditGridCell234.CellLen = 100;
            this.xEditGridCell234.CellName = "jundal_part_inp_name";
            this.xEditGridCell234.Col = -1;
            this.xEditGridCell234.IsVisible = false;
            this.xEditGridCell234.Row = -1;
            // 
            // xEditGridCell235
            // 
            this.xEditGridCell235.CellLen = 100;
            this.xEditGridCell235.CellName = "wonnae_drg_yn";
            this.xEditGridCell235.Col = -1;
            this.xEditGridCell235.IsVisible = false;
            this.xEditGridCell235.Row = -1;
            // 
            // xEditGridCell236
            // 
            this.xEditGridCell236.CellLen = 100;
            this.xEditGridCell236.CellName = "dv_5";
            this.xEditGridCell236.Col = -1;
            this.xEditGridCell236.IsVisible = false;
            this.xEditGridCell236.Row = -1;
            // 
            // xEditGridCell237
            // 
            this.xEditGridCell237.CellLen = 100;
            this.xEditGridCell237.CellName = "dv_6";
            this.xEditGridCell237.Col = -1;
            this.xEditGridCell237.IsVisible = false;
            this.xEditGridCell237.Row = -1;
            // 
            // xEditGridCell238
            // 
            this.xEditGridCell238.CellLen = 100;
            this.xEditGridCell238.CellName = "dv_7";
            this.xEditGridCell238.Col = -1;
            this.xEditGridCell238.IsVisible = false;
            this.xEditGridCell238.Row = -1;
            // 
            // xEditGridCell239
            // 
            this.xEditGridCell239.CellLen = 100;
            this.xEditGridCell239.CellName = "dv_8";
            this.xEditGridCell239.Col = -1;
            this.xEditGridCell239.IsVisible = false;
            this.xEditGridCell239.Row = -1;
            // 
            // xEditGridCell240
            // 
            this.xEditGridCell240.CellLen = 100;
            this.xEditGridCell240.CellName = "general_disp_yn";
            this.xEditGridCell240.Col = -1;
            this.xEditGridCell240.IsVisible = false;
            this.xEditGridCell240.Row = -1;
            // 
            // xEditGridCell241
            // 
            this.xEditGridCell241.CellLen = 100;
            this.xEditGridCell241.CellName = "generic_name";
            this.xEditGridCell241.Col = -1;
            this.xEditGridCell241.IsVisible = false;
            this.xEditGridCell241.Row = -1;
            // 
            // xEditGridCell242
            // 
            this.xEditGridCell242.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell242.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell242.CellLen = 1;
            this.xEditGridCell242.CellName = "select";
            this.xEditGridCell242.CellWidth = 27;
            this.xEditGridCell242.HeaderText = "選択";
            this.xEditGridCell242.IsReadOnly = true;
            this.xEditGridCell242.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell242.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell242.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // tabGroupSerial
            // 
            this.tabGroupSerial.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabGroupSerial.IDEPixelArea = true;
            this.tabGroupSerial.IDEPixelBorder = false;
            this.tabGroupSerial.ImageList = this.ImageList;
            this.tabGroupSerial.Location = new System.Drawing.Point(0, 0);
            this.tabGroupSerial.Name = "tabGroupSerial";
            this.tabGroupSerial.Size = new System.Drawing.Size(1318, 0);
            this.tabGroupSerial.TabIndex = 0;
            this.tabGroupSerial.SelectionChanged += new System.EventHandler(this.tabGroupSerial_SelectionChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cbxGeneric_YN);
            this.pnlTop.Controls.Add(this.btnSelectAllTab);
            this.pnlTop.Controls.Add(this.btnSelectCurrentTab);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(188, 46);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1320, 38);
            this.pnlTop.TabIndex = 47;
            // 
            // cbxGeneric_YN
            // 
            this.cbxGeneric_YN.AutoSize = true;
            this.cbxGeneric_YN.Location = new System.Drawing.Point(103, 15);
            this.cbxGeneric_YN.Name = "cbxGeneric_YN";
            this.cbxGeneric_YN.Size = new System.Drawing.Size(88, 17);
            this.cbxGeneric_YN.TabIndex = 3;
            this.cbxGeneric_YN.Text = "一般名表示";
            this.cbxGeneric_YN.UseVisualStyleBackColor = false;
            this.cbxGeneric_YN.CheckedChanged += new System.EventHandler(this.cbxGeneric_YN_CheckedChanged);
            // 
            // btnSelectAllTab
            // 
            this.btnSelectAllTab.Image = global::IHIS.OCSA.Properties.Resources.YESEN1;
            this.btnSelectAllTab.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelectAllTab.Location = new System.Drawing.Point(54, 5);
            this.btnSelectAllTab.Name = "btnSelectAllTab";
            this.btnSelectAllTab.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnSelectAllTab.Size = new System.Drawing.Size(43, 29);
            this.btnSelectAllTab.TabIndex = 1;
            this.btnSelectAllTab.Tag = "n";
            this.btnSelectAllTab.Click += new System.EventHandler(this.btnDeleteAllTab_Click);
            // 
            // btnSelectCurrentTab
            // 
            this.btnSelectCurrentTab.Image = global::IHIS.OCSA.Properties.Resources.YESUP1;
            this.btnSelectCurrentTab.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelectCurrentTab.Location = new System.Drawing.Point(6, 5);
            this.btnSelectCurrentTab.Name = "btnSelectCurrentTab";
            this.btnSelectCurrentTab.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnSelectCurrentTab.Size = new System.Drawing.Size(43, 29);
            this.btnSelectCurrentTab.TabIndex = 0;
            this.btnSelectCurrentTab.Click += new System.EventHandler(this.btnSelectAllTab_Click);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.pnlOrder);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(188, 84);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(1320, 641);
            this.pnlFill.TabIndex = 48;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "YESEN1.ICO");
            this.imageList1.Images.SetKeyName(1, "YESUP1.ICO");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "jundal_table_out";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "jundal_table_out";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // grdOCS0321
            // 
            this.grdOCS0321.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28});
            this.grdOCS0321.ColPerLine = 4;
            this.grdOCS0321.Cols = 4;
            this.grdOCS0321.FixedRows = 1;
            this.grdOCS0321.HeaderHeights.Add(21);
            this.grdOCS0321.Location = new System.Drawing.Point(5, 238);
            this.grdOCS0321.Name = "grdOCS0321";
            this.grdOCS0321.QuerySQL = resources.GetString("grdOCS0321.QuerySQL");
            this.grdOCS0321.Rows = 2;
            this.grdOCS0321.Size = new System.Drawing.Size(177, 200);
            this.grdOCS0321.TabIndex = 49;
            this.grdOCS0321.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS0321_QueryEnd);
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "pkocs0320";
            this.xEditGridCell25.HeaderText = "ページキー";
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "page_name";
            this.xEditGridCell26.Col = 1;
            this.xEditGridCell26.HeaderText = "ページ名称";
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "pkocs0321";
            this.xEditGridCell27.Col = 2;
            this.xEditGridCell27.HeaderText = "区分キー";
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "part_name";
            this.xEditGridCell28.Col = 3;
            this.xEditGridCell28.HeaderText = "区分名称";
            // 
            // layOCS0323
            // 
            this.layOCS0323.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem34,
            this.multiLayoutItem35,
            this.multiLayoutItem36,
            this.multiLayoutItem39,
            this.multiLayoutItem40,
            this.multiLayoutItem41,
            this.multiLayoutItem42,
            this.multiLayoutItem43,
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem46,
            this.multiLayoutItem47,
            this.multiLayoutItem48,
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
            this.multiLayoutItem52,
            this.multiLayoutItem53,
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
            this.multiLayoutItem81,
            this.multiLayoutItem82,
            this.multiLayoutItem83,
            this.multiLayoutItem84,
            this.multiLayoutItem85,
            this.multiLayoutItem86,
            this.multiLayoutItem87,
            this.multiLayoutItem88,
            this.multiLayoutItem89,
            this.multiLayoutItem90,
            this.multiLayoutItem91,
            this.multiLayoutItem92,
            this.multiLayoutItem93,
            this.multiLayoutItem94,
            this.multiLayoutItem95,
            this.multiLayoutItem96,
            this.multiLayoutItem97,
            this.multiLayoutItem98,
            this.multiLayoutItem99,
            this.multiLayoutItem100,
            this.multiLayoutItem101,
            this.multiLayoutItem102,
            this.multiLayoutItem103,
            this.multiLayoutItem104,
            this.multiLayoutItem105,
            this.multiLayoutItem106,
            this.multiLayoutItem107,
            this.multiLayoutItem108,
            this.multiLayoutItem109,
            this.multiLayoutItem110,
            this.multiLayoutItem111,
            this.multiLayoutItem112,
            this.multiLayoutItem113,
            this.multiLayoutItem114,
            this.multiLayoutItem115,
            this.multiLayoutItem116,
            this.multiLayoutItem117,
            this.multiLayoutItem118,
            this.multiLayoutItem119,
            this.multiLayoutItem120,
            this.multiLayoutItem121,
            this.multiLayoutItem204});
            this.layOCS0323.QuerySQL = resources.GetString("layOCS0323.QuerySQL");
            this.layOCS0323.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.layOCS0323_SaveEnd);
            this.layOCS0323.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layOCS0323_QueryStarting);
            // 
            // grdOCS0323_2
            // 
            this.grdOCS0323_2.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell73,
            this.xEditGridCell243,
            this.xEditGridCell244,
            this.xEditGridCell245,
            this.xEditGridCell246,
            this.xEditGridCell247,
            this.xEditGridCell248,
            this.xEditGridCell249,
            this.xEditGridCell250,
            this.xEditGridCell251,
            this.xEditGridCell252,
            this.xEditGridCell253,
            this.xEditGridCell254,
            this.xEditGridCell255,
            this.xEditGridCell256,
            this.xEditGridCell257,
            this.xEditGridCell258,
            this.xEditGridCell259,
            this.xEditGridCell260,
            this.xEditGridCell261,
            this.xEditGridCell262,
            this.xEditGridCell263,
            this.xEditGridCell264,
            this.xEditGridCell265,
            this.xEditGridCell266,
            this.xEditGridCell267,
            this.xEditGridCell268,
            this.xEditGridCell269,
            this.xEditGridCell270,
            this.xEditGridCell271,
            this.xEditGridCell272,
            this.xEditGridCell273,
            this.xEditGridCell274,
            this.xEditGridCell275,
            this.xEditGridCell276,
            this.xEditGridCell277,
            this.xEditGridCell278,
            this.xEditGridCell279,
            this.xEditGridCell280,
            this.xEditGridCell281,
            this.xEditGridCell282,
            this.xEditGridCell283,
            this.xEditGridCell284,
            this.xEditGridCell285,
            this.xEditGridCell903});
            this.grdOCS0323_2.ColPerLine = 2;
            this.grdOCS0323_2.Cols = 2;
            this.grdOCS0323_2.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdOCS0323_2.FixedRows = 1;
            this.grdOCS0323_2.HeaderHeights.Add(21);
            this.grdOCS0323_2.Location = new System.Drawing.Point(146, 0);
            this.grdOCS0323_2.Name = "grdOCS0323_2";
            this.grdOCS0323_2.Rows = 2;
            this.grdOCS0323_2.RowStateCheckOnPaint = false;
            this.grdOCS0323_2.Size = new System.Drawing.Size(146, 639);
            this.grdOCS0323_2.TabIndex = 47;
            this.grdOCS0323_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0323_all_MouseDown);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellLen = 100;
            this.xEditGridCell29.CellName = "memb";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellLen = 100;
            this.xEditGridCell30.CellName = "fkocs0321";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellLen = 100;
            this.xEditGridCell31.CellName = "pk_yaksok";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellLen = 100;
            this.xEditGridCell32.CellName = "pkocs0323";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellLen = 100;
            this.xEditGridCell33.CellName = "group_ser";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellLen = 100;
            this.xEditGridCell34.CellName = "mix_group";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellLen = 100;
            this.xEditGridCell35.CellName = "seq";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellLen = 100;
            this.xEditGridCell36.CellName = "order_gubun";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellLen = 100;
            this.xEditGridCell37.CellName = "order_gubun_name";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellLen = 100;
            this.xEditGridCell38.CellName = "input_tab";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellLen = 100;
            this.xEditGridCell39.CellName = "hangmog_code";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellLen = 100;
            this.xEditGridCell40.CellName = "hangmog_name";
            this.xEditGridCell40.CellWidth = 115;
            this.xEditGridCell40.Col = 1;
            this.xEditGridCell40.HeaderText = "オーダ名";
            this.xEditGridCell40.IsReadOnly = true;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellLen = 100;
            this.xEditGridCell41.CellName = "specimen_code";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellLen = 100;
            this.xEditGridCell42.CellName = "specimen_name";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellLen = 100;
            this.xEditGridCell43.CellName = "suryang";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellLen = 100;
            this.xEditGridCell44.CellName = "ord_danui";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellLen = 100;
            this.xEditGridCell45.CellName = "order_danui_name";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellLen = 100;
            this.xEditGridCell46.CellName = "dv_time";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellLen = 100;
            this.xEditGridCell47.CellName = "dv";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellLen = 100;
            this.xEditGridCell48.CellName = "dv_1";
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellLen = 100;
            this.xEditGridCell49.CellName = "dv_2";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellLen = 100;
            this.xEditGridCell50.CellName = "dv_3";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellLen = 100;
            this.xEditGridCell51.CellName = "dv_4";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellLen = 100;
            this.xEditGridCell52.CellName = "nalsu";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellLen = 100;
            this.xEditGridCell53.CellName = "jusa";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellLen = 100;
            this.xEditGridCell54.CellName = "jusa_name";
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellLen = 100;
            this.xEditGridCell55.CellName = "bogyong_code";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellLen = 100;
            this.xEditGridCell56.CellName = "bogyong_name";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellLen = 100;
            this.xEditGridCell57.CellName = "jusa_spd_gubun";
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellLen = 100;
            this.xEditGridCell58.CellName = "hubal_change_yn";
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellLen = 100;
            this.xEditGridCell59.CellName = "pharmacy";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellLen = 100;
            this.xEditGridCell60.CellName = "drg_pack_yn";
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellLen = 100;
            this.xEditGridCell61.CellName = "emergency";
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellLen = 100;
            this.xEditGridCell62.CellName = "pay";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellLen = 100;
            this.xEditGridCell63.CellName = "portable_yn";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellLen = 100;
            this.xEditGridCell64.CellName = "powder_yn";
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellLen = 100;
            this.xEditGridCell65.CellName = "muhyo";
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellLen = 100;
            this.xEditGridCell66.CellName = "prn_yn";
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellLen = 100;
            this.xEditGridCell67.CellName = "order_remark";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellLen = 100;
            this.xEditGridCell68.CellName = "nurse_remark";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellLen = 100;
            this.xEditGridCell69.CellName = "bulyong_check";
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellLen = 100;
            this.xEditGridCell70.CellName = "slip_code";
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellLen = 100;
            this.xEditGridCell71.CellName = "group_yn";
            this.xEditGridCell71.Col = -1;
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellLen = 100;
            this.xEditGridCell72.CellName = "order_gubun_bas";
            this.xEditGridCell72.Col = -1;
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellLen = 100;
            this.xEditGridCell73.CellName = "input_control";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell243
            // 
            this.xEditGridCell243.CellLen = 100;
            this.xEditGridCell243.CellName = "sg_code";
            this.xEditGridCell243.Col = -1;
            this.xEditGridCell243.IsVisible = false;
            this.xEditGridCell243.Row = -1;
            // 
            // xEditGridCell244
            // 
            this.xEditGridCell244.CellLen = 100;
            this.xEditGridCell244.CellName = "suga_yn";
            this.xEditGridCell244.Col = -1;
            this.xEditGridCell244.IsVisible = false;
            this.xEditGridCell244.Row = -1;
            // 
            // xEditGridCell245
            // 
            this.xEditGridCell245.CellLen = 100;
            this.xEditGridCell245.CellName = "emergency_check";
            this.xEditGridCell245.Col = -1;
            this.xEditGridCell245.IsVisible = false;
            this.xEditGridCell245.Row = -1;
            // 
            // xEditGridCell246
            // 
            this.xEditGridCell246.CellLen = 100;
            this.xEditGridCell246.CellName = "limit_suryang";
            this.xEditGridCell246.Col = -1;
            this.xEditGridCell246.IsVisible = false;
            this.xEditGridCell246.Row = -1;
            // 
            // xEditGridCell247
            // 
            this.xEditGridCell247.CellLen = 100;
            this.xEditGridCell247.CellName = "specimen_yn";
            this.xEditGridCell247.Col = -1;
            this.xEditGridCell247.IsVisible = false;
            this.xEditGridCell247.Row = -1;
            // 
            // xEditGridCell248
            // 
            this.xEditGridCell248.CellLen = 100;
            this.xEditGridCell248.CellName = "jaeryo_yn";
            this.xEditGridCell248.Col = -1;
            this.xEditGridCell248.IsVisible = false;
            this.xEditGridCell248.Row = -1;
            // 
            // xEditGridCell249
            // 
            this.xEditGridCell249.CellLen = 100;
            this.xEditGridCell249.CellName = "ord_danui_check";
            this.xEditGridCell249.Col = -1;
            this.xEditGridCell249.IsVisible = false;
            this.xEditGridCell249.Row = -1;
            // 
            // xEditGridCell250
            // 
            this.xEditGridCell250.CellLen = 100;
            this.xEditGridCell250.CellName = "wonyoi_order_yn";
            this.xEditGridCell250.Col = -1;
            this.xEditGridCell250.IsVisible = false;
            this.xEditGridCell250.Row = -1;
            // 
            // xEditGridCell251
            // 
            this.xEditGridCell251.CellLen = 100;
            this.xEditGridCell251.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell251.Col = -1;
            this.xEditGridCell251.IsVisible = false;
            this.xEditGridCell251.Row = -1;
            // 
            // xEditGridCell252
            // 
            this.xEditGridCell252.CellLen = 100;
            this.xEditGridCell252.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell252.Col = -1;
            this.xEditGridCell252.IsVisible = false;
            this.xEditGridCell252.Row = -1;
            // 
            // xEditGridCell253
            // 
            this.xEditGridCell253.CellLen = 100;
            this.xEditGridCell253.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell253.Col = -1;
            this.xEditGridCell253.IsVisible = false;
            this.xEditGridCell253.Row = -1;
            // 
            // xEditGridCell254
            // 
            this.xEditGridCell254.CellLen = 100;
            this.xEditGridCell254.CellName = "nday_yn";
            this.xEditGridCell254.Col = -1;
            this.xEditGridCell254.IsVisible = false;
            this.xEditGridCell254.Row = -1;
            // 
            // xEditGridCell255
            // 
            this.xEditGridCell255.CellLen = 100;
            this.xEditGridCell255.CellName = "muhyo_yn";
            this.xEditGridCell255.Col = -1;
            this.xEditGridCell255.IsVisible = false;
            this.xEditGridCell255.Row = -1;
            // 
            // xEditGridCell256
            // 
            this.xEditGridCell256.CellLen = 100;
            this.xEditGridCell256.CellName = "pay_name";
            this.xEditGridCell256.Col = -1;
            this.xEditGridCell256.IsVisible = false;
            this.xEditGridCell256.Row = -1;
            // 
            // xEditGridCell257
            // 
            this.xEditGridCell257.CellLen = 100;
            this.xEditGridCell257.CellName = "bun_code";
            this.xEditGridCell257.Col = -1;
            this.xEditGridCell257.IsVisible = false;
            this.xEditGridCell257.Row = -1;
            // 
            // xEditGridCell258
            // 
            this.xEditGridCell258.CellLen = 100;
            this.xEditGridCell258.CellName = "data_control";
            this.xEditGridCell258.Col = -1;
            this.xEditGridCell258.IsVisible = false;
            this.xEditGridCell258.Row = -1;
            // 
            // xEditGridCell259
            // 
            this.xEditGridCell259.CellLen = 100;
            this.xEditGridCell259.CellName = "donbog_yn";
            this.xEditGridCell259.Col = -1;
            this.xEditGridCell259.IsVisible = false;
            this.xEditGridCell259.Row = -1;
            // 
            // xEditGridCell260
            // 
            this.xEditGridCell260.CellLen = 100;
            this.xEditGridCell260.CellName = "dv_name";
            this.xEditGridCell260.Col = -1;
            this.xEditGridCell260.IsVisible = false;
            this.xEditGridCell260.Row = -1;
            // 
            // xEditGridCell261
            // 
            this.xEditGridCell261.CellLen = 100;
            this.xEditGridCell261.CellName = "drg_info";
            this.xEditGridCell261.Col = -1;
            this.xEditGridCell261.IsVisible = false;
            this.xEditGridCell261.Row = -1;
            // 
            // xEditGridCell262
            // 
            this.xEditGridCell262.CellLen = 100;
            this.xEditGridCell262.CellName = "drg_bunryu";
            this.xEditGridCell262.Col = -1;
            this.xEditGridCell262.IsVisible = false;
            this.xEditGridCell262.Row = -1;
            // 
            // xEditGridCell263
            // 
            this.xEditGridCell263.CellLen = 100;
            this.xEditGridCell263.CellName = "child_gubun";
            this.xEditGridCell263.Col = -1;
            this.xEditGridCell263.IsVisible = false;
            this.xEditGridCell263.Row = -1;
            // 
            // xEditGridCell264
            // 
            this.xEditGridCell264.CellLen = 100;
            this.xEditGridCell264.CellName = "bom_source_key";
            this.xEditGridCell264.Col = -1;
            this.xEditGridCell264.IsVisible = false;
            this.xEditGridCell264.Row = -1;
            // 
            // xEditGridCell265
            // 
            this.xEditGridCell265.CellLen = 100;
            this.xEditGridCell265.CellName = "haengwee_yn";
            this.xEditGridCell265.Col = -1;
            this.xEditGridCell265.IsVisible = false;
            this.xEditGridCell265.Row = -1;
            // 
            // xEditGridCell266
            // 
            this.xEditGridCell266.CellLen = 100;
            this.xEditGridCell266.CellName = "org_key";
            this.xEditGridCell266.Col = -1;
            this.xEditGridCell266.IsVisible = false;
            this.xEditGridCell266.Row = -1;
            // 
            // xEditGridCell267
            // 
            this.xEditGridCell267.CellLen = 100;
            this.xEditGridCell267.CellName = "parent_key";
            this.xEditGridCell267.Col = -1;
            this.xEditGridCell267.IsVisible = false;
            this.xEditGridCell267.Row = -1;
            // 
            // xEditGridCell268
            // 
            this.xEditGridCell268.CellLen = 100;
            this.xEditGridCell268.CellName = "fkocs0300_seq";
            this.xEditGridCell268.Col = -1;
            this.xEditGridCell268.IsVisible = false;
            this.xEditGridCell268.Row = -1;
            // 
            // xEditGridCell269
            // 
            this.xEditGridCell269.CellLen = 100;
            this.xEditGridCell269.CellName = "child_yn";
            this.xEditGridCell269.Col = -1;
            this.xEditGridCell269.IsVisible = false;
            this.xEditGridCell269.Row = -1;
            // 
            // xEditGridCell270
            // 
            this.xEditGridCell270.CellLen = 100;
            this.xEditGridCell270.CellName = "jundal_table_out";
            this.xEditGridCell270.Col = -1;
            this.xEditGridCell270.IsVisible = false;
            this.xEditGridCell270.Row = -1;
            // 
            // xEditGridCell271
            // 
            this.xEditGridCell271.CellLen = 100;
            this.xEditGridCell271.CellName = "jundal_part_out";
            this.xEditGridCell271.Col = -1;
            this.xEditGridCell271.IsVisible = false;
            this.xEditGridCell271.Row = -1;
            // 
            // xEditGridCell272
            // 
            this.xEditGridCell272.CellLen = 100;
            this.xEditGridCell272.CellName = "jundal_table_inp";
            this.xEditGridCell272.Col = -1;
            this.xEditGridCell272.IsVisible = false;
            this.xEditGridCell272.Row = -1;
            // 
            // xEditGridCell273
            // 
            this.xEditGridCell273.CellLen = 100;
            this.xEditGridCell273.CellName = "jundal_part_inp";
            this.xEditGridCell273.Col = -1;
            this.xEditGridCell273.IsVisible = false;
            this.xEditGridCell273.Row = -1;
            // 
            // xEditGridCell274
            // 
            this.xEditGridCell274.CellLen = 100;
            this.xEditGridCell274.CellName = "move_part_out";
            this.xEditGridCell274.Col = -1;
            this.xEditGridCell274.IsVisible = false;
            this.xEditGridCell274.Row = -1;
            // 
            // xEditGridCell275
            // 
            this.xEditGridCell275.CellLen = 100;
            this.xEditGridCell275.CellName = "move_part_inp";
            this.xEditGridCell275.Col = -1;
            this.xEditGridCell275.IsVisible = false;
            this.xEditGridCell275.Row = -1;
            // 
            // xEditGridCell276
            // 
            this.xEditGridCell276.CellLen = 100;
            this.xEditGridCell276.CellName = "jundal_part_out_name";
            this.xEditGridCell276.Col = -1;
            this.xEditGridCell276.IsVisible = false;
            this.xEditGridCell276.Row = -1;
            // 
            // xEditGridCell277
            // 
            this.xEditGridCell277.CellLen = 100;
            this.xEditGridCell277.CellName = "jundal_part_inp_name";
            this.xEditGridCell277.Col = -1;
            this.xEditGridCell277.IsVisible = false;
            this.xEditGridCell277.Row = -1;
            // 
            // xEditGridCell278
            // 
            this.xEditGridCell278.CellLen = 100;
            this.xEditGridCell278.CellName = "wonnae_drg_yn";
            this.xEditGridCell278.Col = -1;
            this.xEditGridCell278.IsVisible = false;
            this.xEditGridCell278.Row = -1;
            // 
            // xEditGridCell279
            // 
            this.xEditGridCell279.CellLen = 100;
            this.xEditGridCell279.CellName = "dv_5";
            this.xEditGridCell279.Col = -1;
            this.xEditGridCell279.IsVisible = false;
            this.xEditGridCell279.Row = -1;
            // 
            // xEditGridCell280
            // 
            this.xEditGridCell280.CellLen = 100;
            this.xEditGridCell280.CellName = "dv_6";
            this.xEditGridCell280.Col = -1;
            this.xEditGridCell280.IsVisible = false;
            this.xEditGridCell280.Row = -1;
            // 
            // xEditGridCell281
            // 
            this.xEditGridCell281.CellLen = 100;
            this.xEditGridCell281.CellName = "dv_7";
            this.xEditGridCell281.Col = -1;
            this.xEditGridCell281.IsVisible = false;
            this.xEditGridCell281.Row = -1;
            // 
            // xEditGridCell282
            // 
            this.xEditGridCell282.CellLen = 100;
            this.xEditGridCell282.CellName = "dv_8";
            this.xEditGridCell282.Col = -1;
            this.xEditGridCell282.IsVisible = false;
            this.xEditGridCell282.Row = -1;
            // 
            // xEditGridCell283
            // 
            this.xEditGridCell283.CellLen = 100;
            this.xEditGridCell283.CellName = "general_disp_yn";
            this.xEditGridCell283.Col = -1;
            this.xEditGridCell283.IsVisible = false;
            this.xEditGridCell283.Row = -1;
            // 
            // xEditGridCell284
            // 
            this.xEditGridCell284.CellLen = 100;
            this.xEditGridCell284.CellName = "generic_name";
            this.xEditGridCell284.Col = -1;
            this.xEditGridCell284.IsVisible = false;
            this.xEditGridCell284.Row = -1;
            // 
            // xEditGridCell285
            // 
            this.xEditGridCell285.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell285.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell285.CellLen = 1;
            this.xEditGridCell285.CellName = "select";
            this.xEditGridCell285.CellWidth = 27;
            this.xEditGridCell285.HeaderText = "選択";
            this.xEditGridCell285.IsReadOnly = true;
            this.xEditGridCell285.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell285.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell285.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // grdOCS0323_3
            // 
            this.grdOCS0323_3.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell286,
            this.xEditGridCell287,
            this.xEditGridCell288,
            this.xEditGridCell289,
            this.xEditGridCell290,
            this.xEditGridCell291,
            this.xEditGridCell292,
            this.xEditGridCell293,
            this.xEditGridCell294,
            this.xEditGridCell295,
            this.xEditGridCell296,
            this.xEditGridCell297,
            this.xEditGridCell298,
            this.xEditGridCell299,
            this.xEditGridCell300,
            this.xEditGridCell301,
            this.xEditGridCell302,
            this.xEditGridCell303,
            this.xEditGridCell304,
            this.xEditGridCell305,
            this.xEditGridCell306,
            this.xEditGridCell307,
            this.xEditGridCell308,
            this.xEditGridCell309,
            this.xEditGridCell310,
            this.xEditGridCell311,
            this.xEditGridCell312,
            this.xEditGridCell313,
            this.xEditGridCell314,
            this.xEditGridCell315,
            this.xEditGridCell316,
            this.xEditGridCell317,
            this.xEditGridCell318,
            this.xEditGridCell319,
            this.xEditGridCell320,
            this.xEditGridCell321,
            this.xEditGridCell322,
            this.xEditGridCell323,
            this.xEditGridCell324,
            this.xEditGridCell325,
            this.xEditGridCell326,
            this.xEditGridCell327,
            this.xEditGridCell328,
            this.xEditGridCell329,
            this.xEditGridCell330,
            this.xEditGridCell331,
            this.xEditGridCell332,
            this.xEditGridCell333,
            this.xEditGridCell334,
            this.xEditGridCell335,
            this.xEditGridCell336,
            this.xEditGridCell337,
            this.xEditGridCell338,
            this.xEditGridCell339,
            this.xEditGridCell340,
            this.xEditGridCell341,
            this.xEditGridCell342,
            this.xEditGridCell343,
            this.xEditGridCell344,
            this.xEditGridCell345,
            this.xEditGridCell346,
            this.xEditGridCell347,
            this.xEditGridCell348,
            this.xEditGridCell349,
            this.xEditGridCell350,
            this.xEditGridCell351,
            this.xEditGridCell352,
            this.xEditGridCell353,
            this.xEditGridCell354,
            this.xEditGridCell355,
            this.xEditGridCell356,
            this.xEditGridCell357,
            this.xEditGridCell358,
            this.xEditGridCell359,
            this.xEditGridCell360,
            this.xEditGridCell361,
            this.xEditGridCell362,
            this.xEditGridCell363,
            this.xEditGridCell364,
            this.xEditGridCell365,
            this.xEditGridCell366,
            this.xEditGridCell367,
            this.xEditGridCell368,
            this.xEditGridCell369,
            this.xEditGridCell370,
            this.xEditGridCell371,
            this.xEditGridCell372,
            this.xEditGridCell373,
            this.xEditGridCell904});
            this.grdOCS0323_3.ColPerLine = 2;
            this.grdOCS0323_3.Cols = 2;
            this.grdOCS0323_3.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdOCS0323_3.FixedRows = 1;
            this.grdOCS0323_3.HeaderHeights.Add(21);
            this.grdOCS0323_3.Location = new System.Drawing.Point(292, 0);
            this.grdOCS0323_3.Name = "grdOCS0323_3";
            this.grdOCS0323_3.Rows = 2;
            this.grdOCS0323_3.RowStateCheckOnPaint = false;
            this.grdOCS0323_3.Size = new System.Drawing.Size(146, 639);
            this.grdOCS0323_3.TabIndex = 48;
            this.grdOCS0323_3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0323_all_MouseDown);
            // 
            // xEditGridCell286
            // 
            this.xEditGridCell286.CellLen = 100;
            this.xEditGridCell286.CellName = "memb";
            this.xEditGridCell286.Col = -1;
            this.xEditGridCell286.IsVisible = false;
            this.xEditGridCell286.Row = -1;
            // 
            // xEditGridCell287
            // 
            this.xEditGridCell287.CellLen = 100;
            this.xEditGridCell287.CellName = "fkocs0321";
            this.xEditGridCell287.Col = -1;
            this.xEditGridCell287.IsVisible = false;
            this.xEditGridCell287.Row = -1;
            // 
            // xEditGridCell288
            // 
            this.xEditGridCell288.CellLen = 100;
            this.xEditGridCell288.CellName = "pk_yaksok";
            this.xEditGridCell288.Col = -1;
            this.xEditGridCell288.IsVisible = false;
            this.xEditGridCell288.Row = -1;
            // 
            // xEditGridCell289
            // 
            this.xEditGridCell289.CellLen = 100;
            this.xEditGridCell289.CellName = "pkocs0323";
            this.xEditGridCell289.Col = -1;
            this.xEditGridCell289.IsVisible = false;
            this.xEditGridCell289.Row = -1;
            // 
            // xEditGridCell290
            // 
            this.xEditGridCell290.CellLen = 100;
            this.xEditGridCell290.CellName = "group_ser";
            this.xEditGridCell290.Col = -1;
            this.xEditGridCell290.IsVisible = false;
            this.xEditGridCell290.Row = -1;
            // 
            // xEditGridCell291
            // 
            this.xEditGridCell291.CellLen = 100;
            this.xEditGridCell291.CellName = "mix_group";
            this.xEditGridCell291.Col = -1;
            this.xEditGridCell291.IsVisible = false;
            this.xEditGridCell291.Row = -1;
            // 
            // xEditGridCell292
            // 
            this.xEditGridCell292.CellLen = 100;
            this.xEditGridCell292.CellName = "seq";
            this.xEditGridCell292.Col = -1;
            this.xEditGridCell292.IsVisible = false;
            this.xEditGridCell292.Row = -1;
            // 
            // xEditGridCell293
            // 
            this.xEditGridCell293.CellLen = 100;
            this.xEditGridCell293.CellName = "order_gubun";
            this.xEditGridCell293.Col = -1;
            this.xEditGridCell293.IsVisible = false;
            this.xEditGridCell293.Row = -1;
            // 
            // xEditGridCell294
            // 
            this.xEditGridCell294.CellLen = 100;
            this.xEditGridCell294.CellName = "order_gubun_name";
            this.xEditGridCell294.Col = -1;
            this.xEditGridCell294.IsVisible = false;
            this.xEditGridCell294.Row = -1;
            // 
            // xEditGridCell295
            // 
            this.xEditGridCell295.CellLen = 100;
            this.xEditGridCell295.CellName = "input_tab";
            this.xEditGridCell295.Col = -1;
            this.xEditGridCell295.IsVisible = false;
            this.xEditGridCell295.Row = -1;
            // 
            // xEditGridCell296
            // 
            this.xEditGridCell296.CellLen = 100;
            this.xEditGridCell296.CellName = "hangmog_code";
            this.xEditGridCell296.Col = -1;
            this.xEditGridCell296.IsVisible = false;
            this.xEditGridCell296.Row = -1;
            // 
            // xEditGridCell297
            // 
            this.xEditGridCell297.CellLen = 100;
            this.xEditGridCell297.CellName = "hangmog_name";
            this.xEditGridCell297.CellWidth = 115;
            this.xEditGridCell297.Col = 1;
            this.xEditGridCell297.HeaderText = "オーダ名";
            this.xEditGridCell297.IsReadOnly = true;
            // 
            // xEditGridCell298
            // 
            this.xEditGridCell298.CellLen = 100;
            this.xEditGridCell298.CellName = "specimen_code";
            this.xEditGridCell298.Col = -1;
            this.xEditGridCell298.IsVisible = false;
            this.xEditGridCell298.Row = -1;
            // 
            // xEditGridCell299
            // 
            this.xEditGridCell299.CellLen = 100;
            this.xEditGridCell299.CellName = "specimen_name";
            this.xEditGridCell299.Col = -1;
            this.xEditGridCell299.IsVisible = false;
            this.xEditGridCell299.Row = -1;
            // 
            // xEditGridCell300
            // 
            this.xEditGridCell300.CellLen = 100;
            this.xEditGridCell300.CellName = "suryang";
            this.xEditGridCell300.Col = -1;
            this.xEditGridCell300.IsVisible = false;
            this.xEditGridCell300.Row = -1;
            // 
            // xEditGridCell301
            // 
            this.xEditGridCell301.CellLen = 100;
            this.xEditGridCell301.CellName = "ord_danui";
            this.xEditGridCell301.Col = -1;
            this.xEditGridCell301.IsVisible = false;
            this.xEditGridCell301.Row = -1;
            // 
            // xEditGridCell302
            // 
            this.xEditGridCell302.CellLen = 100;
            this.xEditGridCell302.CellName = "order_danui_name";
            this.xEditGridCell302.Col = -1;
            this.xEditGridCell302.IsVisible = false;
            this.xEditGridCell302.Row = -1;
            // 
            // xEditGridCell303
            // 
            this.xEditGridCell303.CellLen = 100;
            this.xEditGridCell303.CellName = "dv_time";
            this.xEditGridCell303.Col = -1;
            this.xEditGridCell303.IsVisible = false;
            this.xEditGridCell303.Row = -1;
            // 
            // xEditGridCell304
            // 
            this.xEditGridCell304.CellLen = 100;
            this.xEditGridCell304.CellName = "dv";
            this.xEditGridCell304.Col = -1;
            this.xEditGridCell304.IsVisible = false;
            this.xEditGridCell304.Row = -1;
            // 
            // xEditGridCell305
            // 
            this.xEditGridCell305.CellLen = 100;
            this.xEditGridCell305.CellName = "dv_1";
            this.xEditGridCell305.Col = -1;
            this.xEditGridCell305.IsVisible = false;
            this.xEditGridCell305.Row = -1;
            // 
            // xEditGridCell306
            // 
            this.xEditGridCell306.CellLen = 100;
            this.xEditGridCell306.CellName = "dv_2";
            this.xEditGridCell306.Col = -1;
            this.xEditGridCell306.IsVisible = false;
            this.xEditGridCell306.Row = -1;
            // 
            // xEditGridCell307
            // 
            this.xEditGridCell307.CellLen = 100;
            this.xEditGridCell307.CellName = "dv_3";
            this.xEditGridCell307.Col = -1;
            this.xEditGridCell307.IsVisible = false;
            this.xEditGridCell307.Row = -1;
            // 
            // xEditGridCell308
            // 
            this.xEditGridCell308.CellLen = 100;
            this.xEditGridCell308.CellName = "dv_4";
            this.xEditGridCell308.Col = -1;
            this.xEditGridCell308.IsVisible = false;
            this.xEditGridCell308.Row = -1;
            // 
            // xEditGridCell309
            // 
            this.xEditGridCell309.CellLen = 100;
            this.xEditGridCell309.CellName = "nalsu";
            this.xEditGridCell309.Col = -1;
            this.xEditGridCell309.IsVisible = false;
            this.xEditGridCell309.Row = -1;
            // 
            // xEditGridCell310
            // 
            this.xEditGridCell310.CellLen = 100;
            this.xEditGridCell310.CellName = "jusa";
            this.xEditGridCell310.Col = -1;
            this.xEditGridCell310.IsVisible = false;
            this.xEditGridCell310.Row = -1;
            // 
            // xEditGridCell311
            // 
            this.xEditGridCell311.CellLen = 100;
            this.xEditGridCell311.CellName = "jusa_name";
            this.xEditGridCell311.Col = -1;
            this.xEditGridCell311.IsVisible = false;
            this.xEditGridCell311.Row = -1;
            // 
            // xEditGridCell312
            // 
            this.xEditGridCell312.CellLen = 100;
            this.xEditGridCell312.CellName = "bogyong_code";
            this.xEditGridCell312.Col = -1;
            this.xEditGridCell312.IsVisible = false;
            this.xEditGridCell312.Row = -1;
            // 
            // xEditGridCell313
            // 
            this.xEditGridCell313.CellLen = 100;
            this.xEditGridCell313.CellName = "bogyong_name";
            this.xEditGridCell313.Col = -1;
            this.xEditGridCell313.IsVisible = false;
            this.xEditGridCell313.Row = -1;
            // 
            // xEditGridCell314
            // 
            this.xEditGridCell314.CellLen = 100;
            this.xEditGridCell314.CellName = "jusa_spd_gubun";
            this.xEditGridCell314.Col = -1;
            this.xEditGridCell314.IsVisible = false;
            this.xEditGridCell314.Row = -1;
            // 
            // xEditGridCell315
            // 
            this.xEditGridCell315.CellLen = 100;
            this.xEditGridCell315.CellName = "hubal_change_yn";
            this.xEditGridCell315.Col = -1;
            this.xEditGridCell315.IsVisible = false;
            this.xEditGridCell315.Row = -1;
            // 
            // xEditGridCell316
            // 
            this.xEditGridCell316.CellLen = 100;
            this.xEditGridCell316.CellName = "pharmacy";
            this.xEditGridCell316.Col = -1;
            this.xEditGridCell316.IsVisible = false;
            this.xEditGridCell316.Row = -1;
            // 
            // xEditGridCell317
            // 
            this.xEditGridCell317.CellLen = 100;
            this.xEditGridCell317.CellName = "drg_pack_yn";
            this.xEditGridCell317.Col = -1;
            this.xEditGridCell317.IsVisible = false;
            this.xEditGridCell317.Row = -1;
            // 
            // xEditGridCell318
            // 
            this.xEditGridCell318.CellLen = 100;
            this.xEditGridCell318.CellName = "emergency";
            this.xEditGridCell318.Col = -1;
            this.xEditGridCell318.IsVisible = false;
            this.xEditGridCell318.Row = -1;
            // 
            // xEditGridCell319
            // 
            this.xEditGridCell319.CellLen = 100;
            this.xEditGridCell319.CellName = "pay";
            this.xEditGridCell319.Col = -1;
            this.xEditGridCell319.IsVisible = false;
            this.xEditGridCell319.Row = -1;
            // 
            // xEditGridCell320
            // 
            this.xEditGridCell320.CellLen = 100;
            this.xEditGridCell320.CellName = "portable_yn";
            this.xEditGridCell320.Col = -1;
            this.xEditGridCell320.IsVisible = false;
            this.xEditGridCell320.Row = -1;
            // 
            // xEditGridCell321
            // 
            this.xEditGridCell321.CellLen = 100;
            this.xEditGridCell321.CellName = "powder_yn";
            this.xEditGridCell321.Col = -1;
            this.xEditGridCell321.IsVisible = false;
            this.xEditGridCell321.Row = -1;
            // 
            // xEditGridCell322
            // 
            this.xEditGridCell322.CellLen = 100;
            this.xEditGridCell322.CellName = "muhyo";
            this.xEditGridCell322.Col = -1;
            this.xEditGridCell322.IsVisible = false;
            this.xEditGridCell322.Row = -1;
            // 
            // xEditGridCell323
            // 
            this.xEditGridCell323.CellLen = 100;
            this.xEditGridCell323.CellName = "prn_yn";
            this.xEditGridCell323.Col = -1;
            this.xEditGridCell323.IsVisible = false;
            this.xEditGridCell323.Row = -1;
            // 
            // xEditGridCell324
            // 
            this.xEditGridCell324.CellLen = 100;
            this.xEditGridCell324.CellName = "order_remark";
            this.xEditGridCell324.Col = -1;
            this.xEditGridCell324.IsVisible = false;
            this.xEditGridCell324.Row = -1;
            // 
            // xEditGridCell325
            // 
            this.xEditGridCell325.CellLen = 100;
            this.xEditGridCell325.CellName = "nurse_remark";
            this.xEditGridCell325.Col = -1;
            this.xEditGridCell325.IsVisible = false;
            this.xEditGridCell325.Row = -1;
            // 
            // xEditGridCell326
            // 
            this.xEditGridCell326.CellLen = 100;
            this.xEditGridCell326.CellName = "bulyong_check";
            this.xEditGridCell326.Col = -1;
            this.xEditGridCell326.IsVisible = false;
            this.xEditGridCell326.Row = -1;
            // 
            // xEditGridCell327
            // 
            this.xEditGridCell327.CellLen = 100;
            this.xEditGridCell327.CellName = "slip_code";
            this.xEditGridCell327.Col = -1;
            this.xEditGridCell327.IsVisible = false;
            this.xEditGridCell327.Row = -1;
            // 
            // xEditGridCell328
            // 
            this.xEditGridCell328.CellLen = 100;
            this.xEditGridCell328.CellName = "group_yn";
            this.xEditGridCell328.Col = -1;
            this.xEditGridCell328.IsVisible = false;
            this.xEditGridCell328.Row = -1;
            // 
            // xEditGridCell329
            // 
            this.xEditGridCell329.CellLen = 100;
            this.xEditGridCell329.CellName = "order_gubun_bas";
            this.xEditGridCell329.Col = -1;
            this.xEditGridCell329.IsVisible = false;
            this.xEditGridCell329.Row = -1;
            // 
            // xEditGridCell330
            // 
            this.xEditGridCell330.CellLen = 100;
            this.xEditGridCell330.CellName = "input_control";
            this.xEditGridCell330.Col = -1;
            this.xEditGridCell330.IsVisible = false;
            this.xEditGridCell330.Row = -1;
            // 
            // xEditGridCell331
            // 
            this.xEditGridCell331.CellLen = 100;
            this.xEditGridCell331.CellName = "sg_code";
            this.xEditGridCell331.Col = -1;
            this.xEditGridCell331.IsVisible = false;
            this.xEditGridCell331.Row = -1;
            // 
            // xEditGridCell332
            // 
            this.xEditGridCell332.CellLen = 100;
            this.xEditGridCell332.CellName = "suga_yn";
            this.xEditGridCell332.Col = -1;
            this.xEditGridCell332.IsVisible = false;
            this.xEditGridCell332.Row = -1;
            // 
            // xEditGridCell333
            // 
            this.xEditGridCell333.CellLen = 100;
            this.xEditGridCell333.CellName = "emergency_check";
            this.xEditGridCell333.Col = -1;
            this.xEditGridCell333.IsVisible = false;
            this.xEditGridCell333.Row = -1;
            // 
            // xEditGridCell334
            // 
            this.xEditGridCell334.CellLen = 100;
            this.xEditGridCell334.CellName = "limit_suryang";
            this.xEditGridCell334.Col = -1;
            this.xEditGridCell334.IsVisible = false;
            this.xEditGridCell334.Row = -1;
            // 
            // xEditGridCell335
            // 
            this.xEditGridCell335.CellLen = 100;
            this.xEditGridCell335.CellName = "specimen_yn";
            this.xEditGridCell335.Col = -1;
            this.xEditGridCell335.IsVisible = false;
            this.xEditGridCell335.Row = -1;
            // 
            // xEditGridCell336
            // 
            this.xEditGridCell336.CellLen = 100;
            this.xEditGridCell336.CellName = "jaeryo_yn";
            this.xEditGridCell336.Col = -1;
            this.xEditGridCell336.IsVisible = false;
            this.xEditGridCell336.Row = -1;
            // 
            // xEditGridCell337
            // 
            this.xEditGridCell337.CellLen = 100;
            this.xEditGridCell337.CellName = "ord_danui_check";
            this.xEditGridCell337.Col = -1;
            this.xEditGridCell337.IsVisible = false;
            this.xEditGridCell337.Row = -1;
            // 
            // xEditGridCell338
            // 
            this.xEditGridCell338.CellLen = 100;
            this.xEditGridCell338.CellName = "wonyoi_order_yn";
            this.xEditGridCell338.Col = -1;
            this.xEditGridCell338.IsVisible = false;
            this.xEditGridCell338.Row = -1;
            // 
            // xEditGridCell339
            // 
            this.xEditGridCell339.CellLen = 100;
            this.xEditGridCell339.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell339.Col = -1;
            this.xEditGridCell339.IsVisible = false;
            this.xEditGridCell339.Row = -1;
            // 
            // xEditGridCell340
            // 
            this.xEditGridCell340.CellLen = 100;
            this.xEditGridCell340.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell340.Col = -1;
            this.xEditGridCell340.IsVisible = false;
            this.xEditGridCell340.Row = -1;
            // 
            // xEditGridCell341
            // 
            this.xEditGridCell341.CellLen = 100;
            this.xEditGridCell341.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell341.Col = -1;
            this.xEditGridCell341.IsVisible = false;
            this.xEditGridCell341.Row = -1;
            // 
            // xEditGridCell342
            // 
            this.xEditGridCell342.CellLen = 100;
            this.xEditGridCell342.CellName = "nday_yn";
            this.xEditGridCell342.Col = -1;
            this.xEditGridCell342.IsVisible = false;
            this.xEditGridCell342.Row = -1;
            // 
            // xEditGridCell343
            // 
            this.xEditGridCell343.CellLen = 100;
            this.xEditGridCell343.CellName = "muhyo_yn";
            this.xEditGridCell343.Col = -1;
            this.xEditGridCell343.IsVisible = false;
            this.xEditGridCell343.Row = -1;
            // 
            // xEditGridCell344
            // 
            this.xEditGridCell344.CellLen = 100;
            this.xEditGridCell344.CellName = "pay_name";
            this.xEditGridCell344.Col = -1;
            this.xEditGridCell344.IsVisible = false;
            this.xEditGridCell344.Row = -1;
            // 
            // xEditGridCell345
            // 
            this.xEditGridCell345.CellLen = 100;
            this.xEditGridCell345.CellName = "bun_code";
            this.xEditGridCell345.Col = -1;
            this.xEditGridCell345.IsVisible = false;
            this.xEditGridCell345.Row = -1;
            // 
            // xEditGridCell346
            // 
            this.xEditGridCell346.CellLen = 100;
            this.xEditGridCell346.CellName = "data_control";
            this.xEditGridCell346.Col = -1;
            this.xEditGridCell346.IsVisible = false;
            this.xEditGridCell346.Row = -1;
            // 
            // xEditGridCell347
            // 
            this.xEditGridCell347.CellLen = 100;
            this.xEditGridCell347.CellName = "donbog_yn";
            this.xEditGridCell347.Col = -1;
            this.xEditGridCell347.IsVisible = false;
            this.xEditGridCell347.Row = -1;
            // 
            // xEditGridCell348
            // 
            this.xEditGridCell348.CellLen = 100;
            this.xEditGridCell348.CellName = "dv_name";
            this.xEditGridCell348.Col = -1;
            this.xEditGridCell348.IsVisible = false;
            this.xEditGridCell348.Row = -1;
            // 
            // xEditGridCell349
            // 
            this.xEditGridCell349.CellLen = 100;
            this.xEditGridCell349.CellName = "drg_info";
            this.xEditGridCell349.Col = -1;
            this.xEditGridCell349.IsVisible = false;
            this.xEditGridCell349.Row = -1;
            // 
            // xEditGridCell350
            // 
            this.xEditGridCell350.CellLen = 100;
            this.xEditGridCell350.CellName = "drg_bunryu";
            this.xEditGridCell350.Col = -1;
            this.xEditGridCell350.IsVisible = false;
            this.xEditGridCell350.Row = -1;
            // 
            // xEditGridCell351
            // 
            this.xEditGridCell351.CellLen = 100;
            this.xEditGridCell351.CellName = "child_gubun";
            this.xEditGridCell351.Col = -1;
            this.xEditGridCell351.IsVisible = false;
            this.xEditGridCell351.Row = -1;
            // 
            // xEditGridCell352
            // 
            this.xEditGridCell352.CellLen = 100;
            this.xEditGridCell352.CellName = "bom_source_key";
            this.xEditGridCell352.Col = -1;
            this.xEditGridCell352.IsVisible = false;
            this.xEditGridCell352.Row = -1;
            // 
            // xEditGridCell353
            // 
            this.xEditGridCell353.CellLen = 100;
            this.xEditGridCell353.CellName = "haengwee_yn";
            this.xEditGridCell353.Col = -1;
            this.xEditGridCell353.IsVisible = false;
            this.xEditGridCell353.Row = -1;
            // 
            // xEditGridCell354
            // 
            this.xEditGridCell354.CellLen = 100;
            this.xEditGridCell354.CellName = "org_key";
            this.xEditGridCell354.Col = -1;
            this.xEditGridCell354.IsVisible = false;
            this.xEditGridCell354.Row = -1;
            // 
            // xEditGridCell355
            // 
            this.xEditGridCell355.CellLen = 100;
            this.xEditGridCell355.CellName = "parent_key";
            this.xEditGridCell355.Col = -1;
            this.xEditGridCell355.IsVisible = false;
            this.xEditGridCell355.Row = -1;
            // 
            // xEditGridCell356
            // 
            this.xEditGridCell356.CellLen = 100;
            this.xEditGridCell356.CellName = "fkocs0300_seq";
            this.xEditGridCell356.Col = -1;
            this.xEditGridCell356.IsVisible = false;
            this.xEditGridCell356.Row = -1;
            // 
            // xEditGridCell357
            // 
            this.xEditGridCell357.CellLen = 100;
            this.xEditGridCell357.CellName = "child_yn";
            this.xEditGridCell357.Col = -1;
            this.xEditGridCell357.IsVisible = false;
            this.xEditGridCell357.Row = -1;
            // 
            // xEditGridCell358
            // 
            this.xEditGridCell358.CellLen = 100;
            this.xEditGridCell358.CellName = "jundal_table_out";
            this.xEditGridCell358.Col = -1;
            this.xEditGridCell358.IsVisible = false;
            this.xEditGridCell358.Row = -1;
            // 
            // xEditGridCell359
            // 
            this.xEditGridCell359.CellLen = 100;
            this.xEditGridCell359.CellName = "jundal_part_out";
            this.xEditGridCell359.Col = -1;
            this.xEditGridCell359.IsVisible = false;
            this.xEditGridCell359.Row = -1;
            // 
            // xEditGridCell360
            // 
            this.xEditGridCell360.CellLen = 100;
            this.xEditGridCell360.CellName = "jundal_table_inp";
            this.xEditGridCell360.Col = -1;
            this.xEditGridCell360.IsVisible = false;
            this.xEditGridCell360.Row = -1;
            // 
            // xEditGridCell361
            // 
            this.xEditGridCell361.CellLen = 100;
            this.xEditGridCell361.CellName = "jundal_part_inp";
            this.xEditGridCell361.Col = -1;
            this.xEditGridCell361.IsVisible = false;
            this.xEditGridCell361.Row = -1;
            // 
            // xEditGridCell362
            // 
            this.xEditGridCell362.CellLen = 100;
            this.xEditGridCell362.CellName = "move_part_out";
            this.xEditGridCell362.Col = -1;
            this.xEditGridCell362.IsVisible = false;
            this.xEditGridCell362.Row = -1;
            // 
            // xEditGridCell363
            // 
            this.xEditGridCell363.CellLen = 100;
            this.xEditGridCell363.CellName = "move_part_inp";
            this.xEditGridCell363.Col = -1;
            this.xEditGridCell363.IsVisible = false;
            this.xEditGridCell363.Row = -1;
            // 
            // xEditGridCell364
            // 
            this.xEditGridCell364.CellLen = 100;
            this.xEditGridCell364.CellName = "jundal_part_out_name";
            this.xEditGridCell364.Col = -1;
            this.xEditGridCell364.IsVisible = false;
            this.xEditGridCell364.Row = -1;
            // 
            // xEditGridCell365
            // 
            this.xEditGridCell365.CellLen = 100;
            this.xEditGridCell365.CellName = "jundal_part_inp_name";
            this.xEditGridCell365.Col = -1;
            this.xEditGridCell365.IsVisible = false;
            this.xEditGridCell365.Row = -1;
            // 
            // xEditGridCell366
            // 
            this.xEditGridCell366.CellLen = 100;
            this.xEditGridCell366.CellName = "wonnae_drg_yn";
            this.xEditGridCell366.Col = -1;
            this.xEditGridCell366.IsVisible = false;
            this.xEditGridCell366.Row = -1;
            // 
            // xEditGridCell367
            // 
            this.xEditGridCell367.CellLen = 100;
            this.xEditGridCell367.CellName = "dv_5";
            this.xEditGridCell367.Col = -1;
            this.xEditGridCell367.IsVisible = false;
            this.xEditGridCell367.Row = -1;
            // 
            // xEditGridCell368
            // 
            this.xEditGridCell368.CellLen = 100;
            this.xEditGridCell368.CellName = "dv_6";
            this.xEditGridCell368.Col = -1;
            this.xEditGridCell368.IsVisible = false;
            this.xEditGridCell368.Row = -1;
            // 
            // xEditGridCell369
            // 
            this.xEditGridCell369.CellLen = 100;
            this.xEditGridCell369.CellName = "dv_7";
            this.xEditGridCell369.Col = -1;
            this.xEditGridCell369.IsVisible = false;
            this.xEditGridCell369.Row = -1;
            // 
            // xEditGridCell370
            // 
            this.xEditGridCell370.CellLen = 100;
            this.xEditGridCell370.CellName = "dv_8";
            this.xEditGridCell370.Col = -1;
            this.xEditGridCell370.IsVisible = false;
            this.xEditGridCell370.Row = -1;
            // 
            // xEditGridCell371
            // 
            this.xEditGridCell371.CellLen = 100;
            this.xEditGridCell371.CellName = "general_disp_yn";
            this.xEditGridCell371.Col = -1;
            this.xEditGridCell371.IsVisible = false;
            this.xEditGridCell371.Row = -1;
            // 
            // xEditGridCell372
            // 
            this.xEditGridCell372.CellLen = 100;
            this.xEditGridCell372.CellName = "generic_name";
            this.xEditGridCell372.Col = -1;
            this.xEditGridCell372.IsVisible = false;
            this.xEditGridCell372.Row = -1;
            // 
            // xEditGridCell373
            // 
            this.xEditGridCell373.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell373.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell373.CellLen = 1;
            this.xEditGridCell373.CellName = "select";
            this.xEditGridCell373.CellWidth = 27;
            this.xEditGridCell373.HeaderText = "選択";
            this.xEditGridCell373.IsReadOnly = true;
            this.xEditGridCell373.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell373.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell373.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // grdOCS0323_4
            // 
            this.grdOCS0323_4.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell374,
            this.xEditGridCell375,
            this.xEditGridCell376,
            this.xEditGridCell377,
            this.xEditGridCell378,
            this.xEditGridCell379,
            this.xEditGridCell380,
            this.xEditGridCell381,
            this.xEditGridCell382,
            this.xEditGridCell383,
            this.xEditGridCell384,
            this.xEditGridCell385,
            this.xEditGridCell386,
            this.xEditGridCell387,
            this.xEditGridCell388,
            this.xEditGridCell389,
            this.xEditGridCell390,
            this.xEditGridCell391,
            this.xEditGridCell392,
            this.xEditGridCell393,
            this.xEditGridCell394,
            this.xEditGridCell395,
            this.xEditGridCell396,
            this.xEditGridCell397,
            this.xEditGridCell398,
            this.xEditGridCell399,
            this.xEditGridCell400,
            this.xEditGridCell401,
            this.xEditGridCell402,
            this.xEditGridCell403,
            this.xEditGridCell404,
            this.xEditGridCell405,
            this.xEditGridCell406,
            this.xEditGridCell407,
            this.xEditGridCell408,
            this.xEditGridCell409,
            this.xEditGridCell410,
            this.xEditGridCell411,
            this.xEditGridCell412,
            this.xEditGridCell413,
            this.xEditGridCell414,
            this.xEditGridCell415,
            this.xEditGridCell416,
            this.xEditGridCell417,
            this.xEditGridCell418,
            this.xEditGridCell419,
            this.xEditGridCell420,
            this.xEditGridCell421,
            this.xEditGridCell422,
            this.xEditGridCell423,
            this.xEditGridCell424,
            this.xEditGridCell425,
            this.xEditGridCell426,
            this.xEditGridCell427,
            this.xEditGridCell428,
            this.xEditGridCell429,
            this.xEditGridCell430,
            this.xEditGridCell431,
            this.xEditGridCell432,
            this.xEditGridCell433,
            this.xEditGridCell434,
            this.xEditGridCell435,
            this.xEditGridCell436,
            this.xEditGridCell437,
            this.xEditGridCell438,
            this.xEditGridCell439,
            this.xEditGridCell440,
            this.xEditGridCell441,
            this.xEditGridCell442,
            this.xEditGridCell443,
            this.xEditGridCell444,
            this.xEditGridCell445,
            this.xEditGridCell446,
            this.xEditGridCell447,
            this.xEditGridCell448,
            this.xEditGridCell449,
            this.xEditGridCell450,
            this.xEditGridCell451,
            this.xEditGridCell452,
            this.xEditGridCell453,
            this.xEditGridCell454,
            this.xEditGridCell455,
            this.xEditGridCell456,
            this.xEditGridCell457,
            this.xEditGridCell458,
            this.xEditGridCell459,
            this.xEditGridCell460,
            this.xEditGridCell461,
            this.xEditGridCell905});
            this.grdOCS0323_4.ColPerLine = 2;
            this.grdOCS0323_4.Cols = 2;
            this.grdOCS0323_4.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdOCS0323_4.FixedRows = 1;
            this.grdOCS0323_4.HeaderHeights.Add(21);
            this.grdOCS0323_4.Location = new System.Drawing.Point(438, 0);
            this.grdOCS0323_4.Name = "grdOCS0323_4";
            this.grdOCS0323_4.Rows = 2;
            this.grdOCS0323_4.RowStateCheckOnPaint = false;
            this.grdOCS0323_4.Size = new System.Drawing.Size(146, 639);
            this.grdOCS0323_4.TabIndex = 49;
            this.grdOCS0323_4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0323_all_MouseDown);
            // 
            // xEditGridCell374
            // 
            this.xEditGridCell374.CellLen = 100;
            this.xEditGridCell374.CellName = "memb";
            this.xEditGridCell374.Col = -1;
            this.xEditGridCell374.IsVisible = false;
            this.xEditGridCell374.Row = -1;
            // 
            // xEditGridCell375
            // 
            this.xEditGridCell375.CellLen = 100;
            this.xEditGridCell375.CellName = "fkocs0321";
            this.xEditGridCell375.Col = -1;
            this.xEditGridCell375.IsVisible = false;
            this.xEditGridCell375.Row = -1;
            // 
            // xEditGridCell376
            // 
            this.xEditGridCell376.CellLen = 100;
            this.xEditGridCell376.CellName = "pk_yaksok";
            this.xEditGridCell376.Col = -1;
            this.xEditGridCell376.IsVisible = false;
            this.xEditGridCell376.Row = -1;
            // 
            // xEditGridCell377
            // 
            this.xEditGridCell377.CellLen = 100;
            this.xEditGridCell377.CellName = "pkocs0323";
            this.xEditGridCell377.Col = -1;
            this.xEditGridCell377.IsVisible = false;
            this.xEditGridCell377.Row = -1;
            // 
            // xEditGridCell378
            // 
            this.xEditGridCell378.CellLen = 100;
            this.xEditGridCell378.CellName = "group_ser";
            this.xEditGridCell378.Col = -1;
            this.xEditGridCell378.IsVisible = false;
            this.xEditGridCell378.Row = -1;
            // 
            // xEditGridCell379
            // 
            this.xEditGridCell379.CellLen = 100;
            this.xEditGridCell379.CellName = "mix_group";
            this.xEditGridCell379.Col = -1;
            this.xEditGridCell379.IsVisible = false;
            this.xEditGridCell379.Row = -1;
            // 
            // xEditGridCell380
            // 
            this.xEditGridCell380.CellLen = 100;
            this.xEditGridCell380.CellName = "seq";
            this.xEditGridCell380.Col = -1;
            this.xEditGridCell380.IsVisible = false;
            this.xEditGridCell380.Row = -1;
            // 
            // xEditGridCell381
            // 
            this.xEditGridCell381.CellLen = 100;
            this.xEditGridCell381.CellName = "order_gubun";
            this.xEditGridCell381.Col = -1;
            this.xEditGridCell381.IsVisible = false;
            this.xEditGridCell381.Row = -1;
            // 
            // xEditGridCell382
            // 
            this.xEditGridCell382.CellLen = 100;
            this.xEditGridCell382.CellName = "order_gubun_name";
            this.xEditGridCell382.Col = -1;
            this.xEditGridCell382.IsVisible = false;
            this.xEditGridCell382.Row = -1;
            // 
            // xEditGridCell383
            // 
            this.xEditGridCell383.CellLen = 100;
            this.xEditGridCell383.CellName = "input_tab";
            this.xEditGridCell383.Col = -1;
            this.xEditGridCell383.IsVisible = false;
            this.xEditGridCell383.Row = -1;
            // 
            // xEditGridCell384
            // 
            this.xEditGridCell384.CellLen = 100;
            this.xEditGridCell384.CellName = "hangmog_code";
            this.xEditGridCell384.Col = -1;
            this.xEditGridCell384.IsVisible = false;
            this.xEditGridCell384.Row = -1;
            // 
            // xEditGridCell385
            // 
            this.xEditGridCell385.CellLen = 100;
            this.xEditGridCell385.CellName = "hangmog_name";
            this.xEditGridCell385.CellWidth = 115;
            this.xEditGridCell385.Col = 1;
            this.xEditGridCell385.HeaderText = "オーダ名";
            this.xEditGridCell385.IsReadOnly = true;
            // 
            // xEditGridCell386
            // 
            this.xEditGridCell386.CellLen = 100;
            this.xEditGridCell386.CellName = "specimen_code";
            this.xEditGridCell386.Col = -1;
            this.xEditGridCell386.IsVisible = false;
            this.xEditGridCell386.Row = -1;
            // 
            // xEditGridCell387
            // 
            this.xEditGridCell387.CellLen = 100;
            this.xEditGridCell387.CellName = "specimen_name";
            this.xEditGridCell387.Col = -1;
            this.xEditGridCell387.IsVisible = false;
            this.xEditGridCell387.Row = -1;
            // 
            // xEditGridCell388
            // 
            this.xEditGridCell388.CellLen = 100;
            this.xEditGridCell388.CellName = "suryang";
            this.xEditGridCell388.Col = -1;
            this.xEditGridCell388.IsVisible = false;
            this.xEditGridCell388.Row = -1;
            // 
            // xEditGridCell389
            // 
            this.xEditGridCell389.CellLen = 100;
            this.xEditGridCell389.CellName = "ord_danui";
            this.xEditGridCell389.Col = -1;
            this.xEditGridCell389.IsVisible = false;
            this.xEditGridCell389.Row = -1;
            // 
            // xEditGridCell390
            // 
            this.xEditGridCell390.CellLen = 100;
            this.xEditGridCell390.CellName = "order_danui_name";
            this.xEditGridCell390.Col = -1;
            this.xEditGridCell390.IsVisible = false;
            this.xEditGridCell390.Row = -1;
            // 
            // xEditGridCell391
            // 
            this.xEditGridCell391.CellLen = 100;
            this.xEditGridCell391.CellName = "dv_time";
            this.xEditGridCell391.Col = -1;
            this.xEditGridCell391.IsVisible = false;
            this.xEditGridCell391.Row = -1;
            // 
            // xEditGridCell392
            // 
            this.xEditGridCell392.CellLen = 100;
            this.xEditGridCell392.CellName = "dv";
            this.xEditGridCell392.Col = -1;
            this.xEditGridCell392.IsVisible = false;
            this.xEditGridCell392.Row = -1;
            // 
            // xEditGridCell393
            // 
            this.xEditGridCell393.CellLen = 100;
            this.xEditGridCell393.CellName = "dv_1";
            this.xEditGridCell393.Col = -1;
            this.xEditGridCell393.IsVisible = false;
            this.xEditGridCell393.Row = -1;
            // 
            // xEditGridCell394
            // 
            this.xEditGridCell394.CellLen = 100;
            this.xEditGridCell394.CellName = "dv_2";
            this.xEditGridCell394.Col = -1;
            this.xEditGridCell394.IsVisible = false;
            this.xEditGridCell394.Row = -1;
            // 
            // xEditGridCell395
            // 
            this.xEditGridCell395.CellLen = 100;
            this.xEditGridCell395.CellName = "dv_3";
            this.xEditGridCell395.Col = -1;
            this.xEditGridCell395.IsVisible = false;
            this.xEditGridCell395.Row = -1;
            // 
            // xEditGridCell396
            // 
            this.xEditGridCell396.CellLen = 100;
            this.xEditGridCell396.CellName = "dv_4";
            this.xEditGridCell396.Col = -1;
            this.xEditGridCell396.IsVisible = false;
            this.xEditGridCell396.Row = -1;
            // 
            // xEditGridCell397
            // 
            this.xEditGridCell397.CellLen = 100;
            this.xEditGridCell397.CellName = "nalsu";
            this.xEditGridCell397.Col = -1;
            this.xEditGridCell397.IsVisible = false;
            this.xEditGridCell397.Row = -1;
            // 
            // xEditGridCell398
            // 
            this.xEditGridCell398.CellLen = 100;
            this.xEditGridCell398.CellName = "jusa";
            this.xEditGridCell398.Col = -1;
            this.xEditGridCell398.IsVisible = false;
            this.xEditGridCell398.Row = -1;
            // 
            // xEditGridCell399
            // 
            this.xEditGridCell399.CellLen = 100;
            this.xEditGridCell399.CellName = "jusa_name";
            this.xEditGridCell399.Col = -1;
            this.xEditGridCell399.IsVisible = false;
            this.xEditGridCell399.Row = -1;
            // 
            // xEditGridCell400
            // 
            this.xEditGridCell400.CellLen = 100;
            this.xEditGridCell400.CellName = "bogyong_code";
            this.xEditGridCell400.Col = -1;
            this.xEditGridCell400.IsVisible = false;
            this.xEditGridCell400.Row = -1;
            // 
            // xEditGridCell401
            // 
            this.xEditGridCell401.CellLen = 100;
            this.xEditGridCell401.CellName = "bogyong_name";
            this.xEditGridCell401.Col = -1;
            this.xEditGridCell401.IsVisible = false;
            this.xEditGridCell401.Row = -1;
            // 
            // xEditGridCell402
            // 
            this.xEditGridCell402.CellLen = 100;
            this.xEditGridCell402.CellName = "jusa_spd_gubun";
            this.xEditGridCell402.Col = -1;
            this.xEditGridCell402.IsVisible = false;
            this.xEditGridCell402.Row = -1;
            // 
            // xEditGridCell403
            // 
            this.xEditGridCell403.CellLen = 100;
            this.xEditGridCell403.CellName = "hubal_change_yn";
            this.xEditGridCell403.Col = -1;
            this.xEditGridCell403.IsVisible = false;
            this.xEditGridCell403.Row = -1;
            // 
            // xEditGridCell404
            // 
            this.xEditGridCell404.CellLen = 100;
            this.xEditGridCell404.CellName = "pharmacy";
            this.xEditGridCell404.Col = -1;
            this.xEditGridCell404.IsVisible = false;
            this.xEditGridCell404.Row = -1;
            // 
            // xEditGridCell405
            // 
            this.xEditGridCell405.CellLen = 100;
            this.xEditGridCell405.CellName = "drg_pack_yn";
            this.xEditGridCell405.Col = -1;
            this.xEditGridCell405.IsVisible = false;
            this.xEditGridCell405.Row = -1;
            // 
            // xEditGridCell406
            // 
            this.xEditGridCell406.CellLen = 100;
            this.xEditGridCell406.CellName = "emergency";
            this.xEditGridCell406.Col = -1;
            this.xEditGridCell406.IsVisible = false;
            this.xEditGridCell406.Row = -1;
            // 
            // xEditGridCell407
            // 
            this.xEditGridCell407.CellLen = 100;
            this.xEditGridCell407.CellName = "pay";
            this.xEditGridCell407.Col = -1;
            this.xEditGridCell407.IsVisible = false;
            this.xEditGridCell407.Row = -1;
            // 
            // xEditGridCell408
            // 
            this.xEditGridCell408.CellLen = 100;
            this.xEditGridCell408.CellName = "portable_yn";
            this.xEditGridCell408.Col = -1;
            this.xEditGridCell408.IsVisible = false;
            this.xEditGridCell408.Row = -1;
            // 
            // xEditGridCell409
            // 
            this.xEditGridCell409.CellLen = 100;
            this.xEditGridCell409.CellName = "powder_yn";
            this.xEditGridCell409.Col = -1;
            this.xEditGridCell409.IsVisible = false;
            this.xEditGridCell409.Row = -1;
            // 
            // xEditGridCell410
            // 
            this.xEditGridCell410.CellLen = 100;
            this.xEditGridCell410.CellName = "muhyo";
            this.xEditGridCell410.Col = -1;
            this.xEditGridCell410.IsVisible = false;
            this.xEditGridCell410.Row = -1;
            // 
            // xEditGridCell411
            // 
            this.xEditGridCell411.CellLen = 100;
            this.xEditGridCell411.CellName = "prn_yn";
            this.xEditGridCell411.Col = -1;
            this.xEditGridCell411.IsVisible = false;
            this.xEditGridCell411.Row = -1;
            // 
            // xEditGridCell412
            // 
            this.xEditGridCell412.CellLen = 100;
            this.xEditGridCell412.CellName = "order_remark";
            this.xEditGridCell412.Col = -1;
            this.xEditGridCell412.IsVisible = false;
            this.xEditGridCell412.Row = -1;
            // 
            // xEditGridCell413
            // 
            this.xEditGridCell413.CellLen = 100;
            this.xEditGridCell413.CellName = "nurse_remark";
            this.xEditGridCell413.Col = -1;
            this.xEditGridCell413.IsVisible = false;
            this.xEditGridCell413.Row = -1;
            // 
            // xEditGridCell414
            // 
            this.xEditGridCell414.CellLen = 100;
            this.xEditGridCell414.CellName = "bulyong_check";
            this.xEditGridCell414.Col = -1;
            this.xEditGridCell414.IsVisible = false;
            this.xEditGridCell414.Row = -1;
            // 
            // xEditGridCell415
            // 
            this.xEditGridCell415.CellLen = 100;
            this.xEditGridCell415.CellName = "slip_code";
            this.xEditGridCell415.Col = -1;
            this.xEditGridCell415.IsVisible = false;
            this.xEditGridCell415.Row = -1;
            // 
            // xEditGridCell416
            // 
            this.xEditGridCell416.CellLen = 100;
            this.xEditGridCell416.CellName = "group_yn";
            this.xEditGridCell416.Col = -1;
            this.xEditGridCell416.IsVisible = false;
            this.xEditGridCell416.Row = -1;
            // 
            // xEditGridCell417
            // 
            this.xEditGridCell417.CellLen = 100;
            this.xEditGridCell417.CellName = "order_gubun_bas";
            this.xEditGridCell417.Col = -1;
            this.xEditGridCell417.IsVisible = false;
            this.xEditGridCell417.Row = -1;
            // 
            // xEditGridCell418
            // 
            this.xEditGridCell418.CellLen = 100;
            this.xEditGridCell418.CellName = "input_control";
            this.xEditGridCell418.Col = -1;
            this.xEditGridCell418.IsVisible = false;
            this.xEditGridCell418.Row = -1;
            // 
            // xEditGridCell419
            // 
            this.xEditGridCell419.CellLen = 100;
            this.xEditGridCell419.CellName = "sg_code";
            this.xEditGridCell419.Col = -1;
            this.xEditGridCell419.IsVisible = false;
            this.xEditGridCell419.Row = -1;
            // 
            // xEditGridCell420
            // 
            this.xEditGridCell420.CellLen = 100;
            this.xEditGridCell420.CellName = "suga_yn";
            this.xEditGridCell420.Col = -1;
            this.xEditGridCell420.IsVisible = false;
            this.xEditGridCell420.Row = -1;
            // 
            // xEditGridCell421
            // 
            this.xEditGridCell421.CellLen = 100;
            this.xEditGridCell421.CellName = "emergency_check";
            this.xEditGridCell421.Col = -1;
            this.xEditGridCell421.IsVisible = false;
            this.xEditGridCell421.Row = -1;
            // 
            // xEditGridCell422
            // 
            this.xEditGridCell422.CellLen = 100;
            this.xEditGridCell422.CellName = "limit_suryang";
            this.xEditGridCell422.Col = -1;
            this.xEditGridCell422.IsVisible = false;
            this.xEditGridCell422.Row = -1;
            // 
            // xEditGridCell423
            // 
            this.xEditGridCell423.CellLen = 100;
            this.xEditGridCell423.CellName = "specimen_yn";
            this.xEditGridCell423.Col = -1;
            this.xEditGridCell423.IsVisible = false;
            this.xEditGridCell423.Row = -1;
            // 
            // xEditGridCell424
            // 
            this.xEditGridCell424.CellLen = 100;
            this.xEditGridCell424.CellName = "jaeryo_yn";
            this.xEditGridCell424.Col = -1;
            this.xEditGridCell424.IsVisible = false;
            this.xEditGridCell424.Row = -1;
            // 
            // xEditGridCell425
            // 
            this.xEditGridCell425.CellLen = 100;
            this.xEditGridCell425.CellName = "ord_danui_check";
            this.xEditGridCell425.Col = -1;
            this.xEditGridCell425.IsVisible = false;
            this.xEditGridCell425.Row = -1;
            // 
            // xEditGridCell426
            // 
            this.xEditGridCell426.CellLen = 100;
            this.xEditGridCell426.CellName = "wonyoi_order_yn";
            this.xEditGridCell426.Col = -1;
            this.xEditGridCell426.IsVisible = false;
            this.xEditGridCell426.Row = -1;
            // 
            // xEditGridCell427
            // 
            this.xEditGridCell427.CellLen = 100;
            this.xEditGridCell427.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell427.Col = -1;
            this.xEditGridCell427.IsVisible = false;
            this.xEditGridCell427.Row = -1;
            // 
            // xEditGridCell428
            // 
            this.xEditGridCell428.CellLen = 100;
            this.xEditGridCell428.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell428.Col = -1;
            this.xEditGridCell428.IsVisible = false;
            this.xEditGridCell428.Row = -1;
            // 
            // xEditGridCell429
            // 
            this.xEditGridCell429.CellLen = 100;
            this.xEditGridCell429.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell429.Col = -1;
            this.xEditGridCell429.IsVisible = false;
            this.xEditGridCell429.Row = -1;
            // 
            // xEditGridCell430
            // 
            this.xEditGridCell430.CellLen = 100;
            this.xEditGridCell430.CellName = "nday_yn";
            this.xEditGridCell430.Col = -1;
            this.xEditGridCell430.IsVisible = false;
            this.xEditGridCell430.Row = -1;
            // 
            // xEditGridCell431
            // 
            this.xEditGridCell431.CellLen = 100;
            this.xEditGridCell431.CellName = "muhyo_yn";
            this.xEditGridCell431.Col = -1;
            this.xEditGridCell431.IsVisible = false;
            this.xEditGridCell431.Row = -1;
            // 
            // xEditGridCell432
            // 
            this.xEditGridCell432.CellLen = 100;
            this.xEditGridCell432.CellName = "pay_name";
            this.xEditGridCell432.Col = -1;
            this.xEditGridCell432.IsVisible = false;
            this.xEditGridCell432.Row = -1;
            // 
            // xEditGridCell433
            // 
            this.xEditGridCell433.CellLen = 100;
            this.xEditGridCell433.CellName = "bun_code";
            this.xEditGridCell433.Col = -1;
            this.xEditGridCell433.IsVisible = false;
            this.xEditGridCell433.Row = -1;
            // 
            // xEditGridCell434
            // 
            this.xEditGridCell434.CellLen = 100;
            this.xEditGridCell434.CellName = "data_control";
            this.xEditGridCell434.Col = -1;
            this.xEditGridCell434.IsVisible = false;
            this.xEditGridCell434.Row = -1;
            // 
            // xEditGridCell435
            // 
            this.xEditGridCell435.CellLen = 100;
            this.xEditGridCell435.CellName = "donbog_yn";
            this.xEditGridCell435.Col = -1;
            this.xEditGridCell435.IsVisible = false;
            this.xEditGridCell435.Row = -1;
            // 
            // xEditGridCell436
            // 
            this.xEditGridCell436.CellLen = 100;
            this.xEditGridCell436.CellName = "dv_name";
            this.xEditGridCell436.Col = -1;
            this.xEditGridCell436.IsVisible = false;
            this.xEditGridCell436.Row = -1;
            // 
            // xEditGridCell437
            // 
            this.xEditGridCell437.CellLen = 100;
            this.xEditGridCell437.CellName = "drg_info";
            this.xEditGridCell437.Col = -1;
            this.xEditGridCell437.IsVisible = false;
            this.xEditGridCell437.Row = -1;
            // 
            // xEditGridCell438
            // 
            this.xEditGridCell438.CellLen = 100;
            this.xEditGridCell438.CellName = "drg_bunryu";
            this.xEditGridCell438.Col = -1;
            this.xEditGridCell438.IsVisible = false;
            this.xEditGridCell438.Row = -1;
            // 
            // xEditGridCell439
            // 
            this.xEditGridCell439.CellLen = 100;
            this.xEditGridCell439.CellName = "child_gubun";
            this.xEditGridCell439.Col = -1;
            this.xEditGridCell439.IsVisible = false;
            this.xEditGridCell439.Row = -1;
            // 
            // xEditGridCell440
            // 
            this.xEditGridCell440.CellLen = 100;
            this.xEditGridCell440.CellName = "bom_source_key";
            this.xEditGridCell440.Col = -1;
            this.xEditGridCell440.IsVisible = false;
            this.xEditGridCell440.Row = -1;
            // 
            // xEditGridCell441
            // 
            this.xEditGridCell441.CellLen = 100;
            this.xEditGridCell441.CellName = "haengwee_yn";
            this.xEditGridCell441.Col = -1;
            this.xEditGridCell441.IsVisible = false;
            this.xEditGridCell441.Row = -1;
            // 
            // xEditGridCell442
            // 
            this.xEditGridCell442.CellLen = 100;
            this.xEditGridCell442.CellName = "org_key";
            this.xEditGridCell442.Col = -1;
            this.xEditGridCell442.IsVisible = false;
            this.xEditGridCell442.Row = -1;
            // 
            // xEditGridCell443
            // 
            this.xEditGridCell443.CellLen = 100;
            this.xEditGridCell443.CellName = "parent_key";
            this.xEditGridCell443.Col = -1;
            this.xEditGridCell443.IsVisible = false;
            this.xEditGridCell443.Row = -1;
            // 
            // xEditGridCell444
            // 
            this.xEditGridCell444.CellLen = 100;
            this.xEditGridCell444.CellName = "fkocs0300_seq";
            this.xEditGridCell444.Col = -1;
            this.xEditGridCell444.IsVisible = false;
            this.xEditGridCell444.Row = -1;
            // 
            // xEditGridCell445
            // 
            this.xEditGridCell445.CellLen = 100;
            this.xEditGridCell445.CellName = "child_yn";
            this.xEditGridCell445.Col = -1;
            this.xEditGridCell445.IsVisible = false;
            this.xEditGridCell445.Row = -1;
            // 
            // xEditGridCell446
            // 
            this.xEditGridCell446.CellLen = 100;
            this.xEditGridCell446.CellName = "jundal_table_out";
            this.xEditGridCell446.Col = -1;
            this.xEditGridCell446.IsVisible = false;
            this.xEditGridCell446.Row = -1;
            // 
            // xEditGridCell447
            // 
            this.xEditGridCell447.CellLen = 100;
            this.xEditGridCell447.CellName = "jundal_part_out";
            this.xEditGridCell447.Col = -1;
            this.xEditGridCell447.IsVisible = false;
            this.xEditGridCell447.Row = -1;
            // 
            // xEditGridCell448
            // 
            this.xEditGridCell448.CellLen = 100;
            this.xEditGridCell448.CellName = "jundal_table_inp";
            this.xEditGridCell448.Col = -1;
            this.xEditGridCell448.IsVisible = false;
            this.xEditGridCell448.Row = -1;
            // 
            // xEditGridCell449
            // 
            this.xEditGridCell449.CellLen = 100;
            this.xEditGridCell449.CellName = "jundal_part_inp";
            this.xEditGridCell449.Col = -1;
            this.xEditGridCell449.IsVisible = false;
            this.xEditGridCell449.Row = -1;
            // 
            // xEditGridCell450
            // 
            this.xEditGridCell450.CellLen = 100;
            this.xEditGridCell450.CellName = "move_part_out";
            this.xEditGridCell450.Col = -1;
            this.xEditGridCell450.IsVisible = false;
            this.xEditGridCell450.Row = -1;
            // 
            // xEditGridCell451
            // 
            this.xEditGridCell451.CellLen = 100;
            this.xEditGridCell451.CellName = "move_part_inp";
            this.xEditGridCell451.Col = -1;
            this.xEditGridCell451.IsVisible = false;
            this.xEditGridCell451.Row = -1;
            // 
            // xEditGridCell452
            // 
            this.xEditGridCell452.CellLen = 100;
            this.xEditGridCell452.CellName = "jundal_part_out_name";
            this.xEditGridCell452.Col = -1;
            this.xEditGridCell452.IsVisible = false;
            this.xEditGridCell452.Row = -1;
            // 
            // xEditGridCell453
            // 
            this.xEditGridCell453.CellLen = 100;
            this.xEditGridCell453.CellName = "jundal_part_inp_name";
            this.xEditGridCell453.Col = -1;
            this.xEditGridCell453.IsVisible = false;
            this.xEditGridCell453.Row = -1;
            // 
            // xEditGridCell454
            // 
            this.xEditGridCell454.CellLen = 100;
            this.xEditGridCell454.CellName = "wonnae_drg_yn";
            this.xEditGridCell454.Col = -1;
            this.xEditGridCell454.IsVisible = false;
            this.xEditGridCell454.Row = -1;
            // 
            // xEditGridCell455
            // 
            this.xEditGridCell455.CellLen = 100;
            this.xEditGridCell455.CellName = "dv_5";
            this.xEditGridCell455.Col = -1;
            this.xEditGridCell455.IsVisible = false;
            this.xEditGridCell455.Row = -1;
            // 
            // xEditGridCell456
            // 
            this.xEditGridCell456.CellLen = 100;
            this.xEditGridCell456.CellName = "dv_6";
            this.xEditGridCell456.Col = -1;
            this.xEditGridCell456.IsVisible = false;
            this.xEditGridCell456.Row = -1;
            // 
            // xEditGridCell457
            // 
            this.xEditGridCell457.CellLen = 100;
            this.xEditGridCell457.CellName = "dv_7";
            this.xEditGridCell457.Col = -1;
            this.xEditGridCell457.IsVisible = false;
            this.xEditGridCell457.Row = -1;
            // 
            // xEditGridCell458
            // 
            this.xEditGridCell458.CellLen = 100;
            this.xEditGridCell458.CellName = "dv_8";
            this.xEditGridCell458.Col = -1;
            this.xEditGridCell458.IsVisible = false;
            this.xEditGridCell458.Row = -1;
            // 
            // xEditGridCell459
            // 
            this.xEditGridCell459.CellLen = 100;
            this.xEditGridCell459.CellName = "general_disp_yn";
            this.xEditGridCell459.Col = -1;
            this.xEditGridCell459.IsVisible = false;
            this.xEditGridCell459.Row = -1;
            // 
            // xEditGridCell460
            // 
            this.xEditGridCell460.CellLen = 100;
            this.xEditGridCell460.CellName = "generic_name";
            this.xEditGridCell460.Col = -1;
            this.xEditGridCell460.IsVisible = false;
            this.xEditGridCell460.Row = -1;
            // 
            // xEditGridCell461
            // 
            this.xEditGridCell461.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell461.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell461.CellLen = 1;
            this.xEditGridCell461.CellName = "select";
            this.xEditGridCell461.CellWidth = 27;
            this.xEditGridCell461.HeaderText = "選択";
            this.xEditGridCell461.IsReadOnly = true;
            this.xEditGridCell461.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell461.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell461.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // grdOCS0323_5
            // 
            this.grdOCS0323_5.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell462,
            this.xEditGridCell463,
            this.xEditGridCell464,
            this.xEditGridCell465,
            this.xEditGridCell466,
            this.xEditGridCell467,
            this.xEditGridCell468,
            this.xEditGridCell469,
            this.xEditGridCell470,
            this.xEditGridCell471,
            this.xEditGridCell472,
            this.xEditGridCell473,
            this.xEditGridCell474,
            this.xEditGridCell475,
            this.xEditGridCell476,
            this.xEditGridCell477,
            this.xEditGridCell478,
            this.xEditGridCell479,
            this.xEditGridCell480,
            this.xEditGridCell481,
            this.xEditGridCell482,
            this.xEditGridCell483,
            this.xEditGridCell484,
            this.xEditGridCell485,
            this.xEditGridCell486,
            this.xEditGridCell487,
            this.xEditGridCell488,
            this.xEditGridCell489,
            this.xEditGridCell490,
            this.xEditGridCell491,
            this.xEditGridCell492,
            this.xEditGridCell493,
            this.xEditGridCell494,
            this.xEditGridCell495,
            this.xEditGridCell496,
            this.xEditGridCell497,
            this.xEditGridCell498,
            this.xEditGridCell499,
            this.xEditGridCell500,
            this.xEditGridCell501,
            this.xEditGridCell502,
            this.xEditGridCell503,
            this.xEditGridCell504,
            this.xEditGridCell505,
            this.xEditGridCell506,
            this.xEditGridCell507,
            this.xEditGridCell508,
            this.xEditGridCell509,
            this.xEditGridCell510,
            this.xEditGridCell511,
            this.xEditGridCell512,
            this.xEditGridCell513,
            this.xEditGridCell514,
            this.xEditGridCell515,
            this.xEditGridCell516,
            this.xEditGridCell517,
            this.xEditGridCell518,
            this.xEditGridCell519,
            this.xEditGridCell520,
            this.xEditGridCell521,
            this.xEditGridCell522,
            this.xEditGridCell523,
            this.xEditGridCell524,
            this.xEditGridCell525,
            this.xEditGridCell526,
            this.xEditGridCell527,
            this.xEditGridCell528,
            this.xEditGridCell529,
            this.xEditGridCell530,
            this.xEditGridCell531,
            this.xEditGridCell532,
            this.xEditGridCell533,
            this.xEditGridCell534,
            this.xEditGridCell535,
            this.xEditGridCell536,
            this.xEditGridCell537,
            this.xEditGridCell538,
            this.xEditGridCell539,
            this.xEditGridCell540,
            this.xEditGridCell541,
            this.xEditGridCell542,
            this.xEditGridCell543,
            this.xEditGridCell544,
            this.xEditGridCell545,
            this.xEditGridCell546,
            this.xEditGridCell547,
            this.xEditGridCell548,
            this.xEditGridCell549,
            this.xEditGridCell906});
            this.grdOCS0323_5.ColPerLine = 2;
            this.grdOCS0323_5.Cols = 2;
            this.grdOCS0323_5.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdOCS0323_5.FixedRows = 1;
            this.grdOCS0323_5.HeaderHeights.Add(21);
            this.grdOCS0323_5.Location = new System.Drawing.Point(584, 0);
            this.grdOCS0323_5.Name = "grdOCS0323_5";
            this.grdOCS0323_5.Rows = 2;
            this.grdOCS0323_5.RowStateCheckOnPaint = false;
            this.grdOCS0323_5.Size = new System.Drawing.Size(146, 639);
            this.grdOCS0323_5.TabIndex = 50;
            this.grdOCS0323_5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0323_all_MouseDown);
            // 
            // xEditGridCell462
            // 
            this.xEditGridCell462.CellLen = 100;
            this.xEditGridCell462.CellName = "memb";
            this.xEditGridCell462.Col = -1;
            this.xEditGridCell462.IsVisible = false;
            this.xEditGridCell462.Row = -1;
            // 
            // xEditGridCell463
            // 
            this.xEditGridCell463.CellLen = 100;
            this.xEditGridCell463.CellName = "fkocs0321";
            this.xEditGridCell463.Col = -1;
            this.xEditGridCell463.IsVisible = false;
            this.xEditGridCell463.Row = -1;
            // 
            // xEditGridCell464
            // 
            this.xEditGridCell464.CellLen = 100;
            this.xEditGridCell464.CellName = "pk_yaksok";
            this.xEditGridCell464.Col = -1;
            this.xEditGridCell464.IsVisible = false;
            this.xEditGridCell464.Row = -1;
            // 
            // xEditGridCell465
            // 
            this.xEditGridCell465.CellLen = 100;
            this.xEditGridCell465.CellName = "pkocs0323";
            this.xEditGridCell465.Col = -1;
            this.xEditGridCell465.IsVisible = false;
            this.xEditGridCell465.Row = -1;
            // 
            // xEditGridCell466
            // 
            this.xEditGridCell466.CellLen = 100;
            this.xEditGridCell466.CellName = "group_ser";
            this.xEditGridCell466.Col = -1;
            this.xEditGridCell466.IsVisible = false;
            this.xEditGridCell466.Row = -1;
            // 
            // xEditGridCell467
            // 
            this.xEditGridCell467.CellLen = 100;
            this.xEditGridCell467.CellName = "mix_group";
            this.xEditGridCell467.Col = -1;
            this.xEditGridCell467.IsVisible = false;
            this.xEditGridCell467.Row = -1;
            // 
            // xEditGridCell468
            // 
            this.xEditGridCell468.CellLen = 100;
            this.xEditGridCell468.CellName = "seq";
            this.xEditGridCell468.Col = -1;
            this.xEditGridCell468.IsVisible = false;
            this.xEditGridCell468.Row = -1;
            // 
            // xEditGridCell469
            // 
            this.xEditGridCell469.CellLen = 100;
            this.xEditGridCell469.CellName = "order_gubun";
            this.xEditGridCell469.Col = -1;
            this.xEditGridCell469.IsVisible = false;
            this.xEditGridCell469.Row = -1;
            // 
            // xEditGridCell470
            // 
            this.xEditGridCell470.CellLen = 100;
            this.xEditGridCell470.CellName = "order_gubun_name";
            this.xEditGridCell470.Col = -1;
            this.xEditGridCell470.IsVisible = false;
            this.xEditGridCell470.Row = -1;
            // 
            // xEditGridCell471
            // 
            this.xEditGridCell471.CellLen = 100;
            this.xEditGridCell471.CellName = "input_tab";
            this.xEditGridCell471.Col = -1;
            this.xEditGridCell471.IsVisible = false;
            this.xEditGridCell471.Row = -1;
            // 
            // xEditGridCell472
            // 
            this.xEditGridCell472.CellLen = 100;
            this.xEditGridCell472.CellName = "hangmog_code";
            this.xEditGridCell472.Col = -1;
            this.xEditGridCell472.IsVisible = false;
            this.xEditGridCell472.Row = -1;
            // 
            // xEditGridCell473
            // 
            this.xEditGridCell473.CellLen = 100;
            this.xEditGridCell473.CellName = "hangmog_name";
            this.xEditGridCell473.CellWidth = 115;
            this.xEditGridCell473.Col = 1;
            this.xEditGridCell473.HeaderText = "オーダ名";
            this.xEditGridCell473.IsReadOnly = true;
            // 
            // xEditGridCell474
            // 
            this.xEditGridCell474.CellLen = 100;
            this.xEditGridCell474.CellName = "specimen_code";
            this.xEditGridCell474.Col = -1;
            this.xEditGridCell474.IsVisible = false;
            this.xEditGridCell474.Row = -1;
            // 
            // xEditGridCell475
            // 
            this.xEditGridCell475.CellLen = 100;
            this.xEditGridCell475.CellName = "specimen_name";
            this.xEditGridCell475.Col = -1;
            this.xEditGridCell475.IsVisible = false;
            this.xEditGridCell475.Row = -1;
            // 
            // xEditGridCell476
            // 
            this.xEditGridCell476.CellLen = 100;
            this.xEditGridCell476.CellName = "suryang";
            this.xEditGridCell476.Col = -1;
            this.xEditGridCell476.IsVisible = false;
            this.xEditGridCell476.Row = -1;
            // 
            // xEditGridCell477
            // 
            this.xEditGridCell477.CellLen = 100;
            this.xEditGridCell477.CellName = "ord_danui";
            this.xEditGridCell477.Col = -1;
            this.xEditGridCell477.IsVisible = false;
            this.xEditGridCell477.Row = -1;
            // 
            // xEditGridCell478
            // 
            this.xEditGridCell478.CellLen = 100;
            this.xEditGridCell478.CellName = "order_danui_name";
            this.xEditGridCell478.Col = -1;
            this.xEditGridCell478.IsVisible = false;
            this.xEditGridCell478.Row = -1;
            // 
            // xEditGridCell479
            // 
            this.xEditGridCell479.CellLen = 100;
            this.xEditGridCell479.CellName = "dv_time";
            this.xEditGridCell479.Col = -1;
            this.xEditGridCell479.IsVisible = false;
            this.xEditGridCell479.Row = -1;
            // 
            // xEditGridCell480
            // 
            this.xEditGridCell480.CellLen = 100;
            this.xEditGridCell480.CellName = "dv";
            this.xEditGridCell480.Col = -1;
            this.xEditGridCell480.IsVisible = false;
            this.xEditGridCell480.Row = -1;
            // 
            // xEditGridCell481
            // 
            this.xEditGridCell481.CellLen = 100;
            this.xEditGridCell481.CellName = "dv_1";
            this.xEditGridCell481.Col = -1;
            this.xEditGridCell481.IsVisible = false;
            this.xEditGridCell481.Row = -1;
            // 
            // xEditGridCell482
            // 
            this.xEditGridCell482.CellLen = 100;
            this.xEditGridCell482.CellName = "dv_2";
            this.xEditGridCell482.Col = -1;
            this.xEditGridCell482.IsVisible = false;
            this.xEditGridCell482.Row = -1;
            // 
            // xEditGridCell483
            // 
            this.xEditGridCell483.CellLen = 100;
            this.xEditGridCell483.CellName = "dv_3";
            this.xEditGridCell483.Col = -1;
            this.xEditGridCell483.IsVisible = false;
            this.xEditGridCell483.Row = -1;
            // 
            // xEditGridCell484
            // 
            this.xEditGridCell484.CellLen = 100;
            this.xEditGridCell484.CellName = "dv_4";
            this.xEditGridCell484.Col = -1;
            this.xEditGridCell484.IsVisible = false;
            this.xEditGridCell484.Row = -1;
            // 
            // xEditGridCell485
            // 
            this.xEditGridCell485.CellLen = 100;
            this.xEditGridCell485.CellName = "nalsu";
            this.xEditGridCell485.Col = -1;
            this.xEditGridCell485.IsVisible = false;
            this.xEditGridCell485.Row = -1;
            // 
            // xEditGridCell486
            // 
            this.xEditGridCell486.CellLen = 100;
            this.xEditGridCell486.CellName = "jusa";
            this.xEditGridCell486.Col = -1;
            this.xEditGridCell486.IsVisible = false;
            this.xEditGridCell486.Row = -1;
            // 
            // xEditGridCell487
            // 
            this.xEditGridCell487.CellLen = 100;
            this.xEditGridCell487.CellName = "jusa_name";
            this.xEditGridCell487.Col = -1;
            this.xEditGridCell487.IsVisible = false;
            this.xEditGridCell487.Row = -1;
            // 
            // xEditGridCell488
            // 
            this.xEditGridCell488.CellLen = 100;
            this.xEditGridCell488.CellName = "bogyong_code";
            this.xEditGridCell488.Col = -1;
            this.xEditGridCell488.IsVisible = false;
            this.xEditGridCell488.Row = -1;
            // 
            // xEditGridCell489
            // 
            this.xEditGridCell489.CellLen = 100;
            this.xEditGridCell489.CellName = "bogyong_name";
            this.xEditGridCell489.Col = -1;
            this.xEditGridCell489.IsVisible = false;
            this.xEditGridCell489.Row = -1;
            // 
            // xEditGridCell490
            // 
            this.xEditGridCell490.CellLen = 100;
            this.xEditGridCell490.CellName = "jusa_spd_gubun";
            this.xEditGridCell490.Col = -1;
            this.xEditGridCell490.IsVisible = false;
            this.xEditGridCell490.Row = -1;
            // 
            // xEditGridCell491
            // 
            this.xEditGridCell491.CellLen = 100;
            this.xEditGridCell491.CellName = "hubal_change_yn";
            this.xEditGridCell491.Col = -1;
            this.xEditGridCell491.IsVisible = false;
            this.xEditGridCell491.Row = -1;
            // 
            // xEditGridCell492
            // 
            this.xEditGridCell492.CellLen = 100;
            this.xEditGridCell492.CellName = "pharmacy";
            this.xEditGridCell492.Col = -1;
            this.xEditGridCell492.IsVisible = false;
            this.xEditGridCell492.Row = -1;
            // 
            // xEditGridCell493
            // 
            this.xEditGridCell493.CellLen = 100;
            this.xEditGridCell493.CellName = "drg_pack_yn";
            this.xEditGridCell493.Col = -1;
            this.xEditGridCell493.IsVisible = false;
            this.xEditGridCell493.Row = -1;
            // 
            // xEditGridCell494
            // 
            this.xEditGridCell494.CellLen = 100;
            this.xEditGridCell494.CellName = "emergency";
            this.xEditGridCell494.Col = -1;
            this.xEditGridCell494.IsVisible = false;
            this.xEditGridCell494.Row = -1;
            // 
            // xEditGridCell495
            // 
            this.xEditGridCell495.CellLen = 100;
            this.xEditGridCell495.CellName = "pay";
            this.xEditGridCell495.Col = -1;
            this.xEditGridCell495.IsVisible = false;
            this.xEditGridCell495.Row = -1;
            // 
            // xEditGridCell496
            // 
            this.xEditGridCell496.CellLen = 100;
            this.xEditGridCell496.CellName = "portable_yn";
            this.xEditGridCell496.Col = -1;
            this.xEditGridCell496.IsVisible = false;
            this.xEditGridCell496.Row = -1;
            // 
            // xEditGridCell497
            // 
            this.xEditGridCell497.CellLen = 100;
            this.xEditGridCell497.CellName = "powder_yn";
            this.xEditGridCell497.Col = -1;
            this.xEditGridCell497.IsVisible = false;
            this.xEditGridCell497.Row = -1;
            // 
            // xEditGridCell498
            // 
            this.xEditGridCell498.CellLen = 100;
            this.xEditGridCell498.CellName = "muhyo";
            this.xEditGridCell498.Col = -1;
            this.xEditGridCell498.IsVisible = false;
            this.xEditGridCell498.Row = -1;
            // 
            // xEditGridCell499
            // 
            this.xEditGridCell499.CellLen = 100;
            this.xEditGridCell499.CellName = "prn_yn";
            this.xEditGridCell499.Col = -1;
            this.xEditGridCell499.IsVisible = false;
            this.xEditGridCell499.Row = -1;
            // 
            // xEditGridCell500
            // 
            this.xEditGridCell500.CellLen = 100;
            this.xEditGridCell500.CellName = "order_remark";
            this.xEditGridCell500.Col = -1;
            this.xEditGridCell500.IsVisible = false;
            this.xEditGridCell500.Row = -1;
            // 
            // xEditGridCell501
            // 
            this.xEditGridCell501.CellLen = 100;
            this.xEditGridCell501.CellName = "nurse_remark";
            this.xEditGridCell501.Col = -1;
            this.xEditGridCell501.IsVisible = false;
            this.xEditGridCell501.Row = -1;
            // 
            // xEditGridCell502
            // 
            this.xEditGridCell502.CellLen = 100;
            this.xEditGridCell502.CellName = "bulyong_check";
            this.xEditGridCell502.Col = -1;
            this.xEditGridCell502.IsVisible = false;
            this.xEditGridCell502.Row = -1;
            // 
            // xEditGridCell503
            // 
            this.xEditGridCell503.CellLen = 100;
            this.xEditGridCell503.CellName = "slip_code";
            this.xEditGridCell503.Col = -1;
            this.xEditGridCell503.IsVisible = false;
            this.xEditGridCell503.Row = -1;
            // 
            // xEditGridCell504
            // 
            this.xEditGridCell504.CellLen = 100;
            this.xEditGridCell504.CellName = "group_yn";
            this.xEditGridCell504.Col = -1;
            this.xEditGridCell504.IsVisible = false;
            this.xEditGridCell504.Row = -1;
            // 
            // xEditGridCell505
            // 
            this.xEditGridCell505.CellLen = 100;
            this.xEditGridCell505.CellName = "order_gubun_bas";
            this.xEditGridCell505.Col = -1;
            this.xEditGridCell505.IsVisible = false;
            this.xEditGridCell505.Row = -1;
            // 
            // xEditGridCell506
            // 
            this.xEditGridCell506.CellLen = 100;
            this.xEditGridCell506.CellName = "input_control";
            this.xEditGridCell506.Col = -1;
            this.xEditGridCell506.IsVisible = false;
            this.xEditGridCell506.Row = -1;
            // 
            // xEditGridCell507
            // 
            this.xEditGridCell507.CellLen = 100;
            this.xEditGridCell507.CellName = "sg_code";
            this.xEditGridCell507.Col = -1;
            this.xEditGridCell507.IsVisible = false;
            this.xEditGridCell507.Row = -1;
            // 
            // xEditGridCell508
            // 
            this.xEditGridCell508.CellLen = 100;
            this.xEditGridCell508.CellName = "suga_yn";
            this.xEditGridCell508.Col = -1;
            this.xEditGridCell508.IsVisible = false;
            this.xEditGridCell508.Row = -1;
            // 
            // xEditGridCell509
            // 
            this.xEditGridCell509.CellLen = 100;
            this.xEditGridCell509.CellName = "emergency_check";
            this.xEditGridCell509.Col = -1;
            this.xEditGridCell509.IsVisible = false;
            this.xEditGridCell509.Row = -1;
            // 
            // xEditGridCell510
            // 
            this.xEditGridCell510.CellLen = 100;
            this.xEditGridCell510.CellName = "limit_suryang";
            this.xEditGridCell510.Col = -1;
            this.xEditGridCell510.IsVisible = false;
            this.xEditGridCell510.Row = -1;
            // 
            // xEditGridCell511
            // 
            this.xEditGridCell511.CellLen = 100;
            this.xEditGridCell511.CellName = "specimen_yn";
            this.xEditGridCell511.Col = -1;
            this.xEditGridCell511.IsVisible = false;
            this.xEditGridCell511.Row = -1;
            // 
            // xEditGridCell512
            // 
            this.xEditGridCell512.CellLen = 100;
            this.xEditGridCell512.CellName = "jaeryo_yn";
            this.xEditGridCell512.Col = -1;
            this.xEditGridCell512.IsVisible = false;
            this.xEditGridCell512.Row = -1;
            // 
            // xEditGridCell513
            // 
            this.xEditGridCell513.CellLen = 100;
            this.xEditGridCell513.CellName = "ord_danui_check";
            this.xEditGridCell513.Col = -1;
            this.xEditGridCell513.IsVisible = false;
            this.xEditGridCell513.Row = -1;
            // 
            // xEditGridCell514
            // 
            this.xEditGridCell514.CellLen = 100;
            this.xEditGridCell514.CellName = "wonyoi_order_yn";
            this.xEditGridCell514.Col = -1;
            this.xEditGridCell514.IsVisible = false;
            this.xEditGridCell514.Row = -1;
            // 
            // xEditGridCell515
            // 
            this.xEditGridCell515.CellLen = 100;
            this.xEditGridCell515.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell515.Col = -1;
            this.xEditGridCell515.IsVisible = false;
            this.xEditGridCell515.Row = -1;
            // 
            // xEditGridCell516
            // 
            this.xEditGridCell516.CellLen = 100;
            this.xEditGridCell516.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell516.Col = -1;
            this.xEditGridCell516.IsVisible = false;
            this.xEditGridCell516.Row = -1;
            // 
            // xEditGridCell517
            // 
            this.xEditGridCell517.CellLen = 100;
            this.xEditGridCell517.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell517.Col = -1;
            this.xEditGridCell517.IsVisible = false;
            this.xEditGridCell517.Row = -1;
            // 
            // xEditGridCell518
            // 
            this.xEditGridCell518.CellLen = 100;
            this.xEditGridCell518.CellName = "nday_yn";
            this.xEditGridCell518.Col = -1;
            this.xEditGridCell518.IsVisible = false;
            this.xEditGridCell518.Row = -1;
            // 
            // xEditGridCell519
            // 
            this.xEditGridCell519.CellLen = 100;
            this.xEditGridCell519.CellName = "muhyo_yn";
            this.xEditGridCell519.Col = -1;
            this.xEditGridCell519.IsVisible = false;
            this.xEditGridCell519.Row = -1;
            // 
            // xEditGridCell520
            // 
            this.xEditGridCell520.CellLen = 100;
            this.xEditGridCell520.CellName = "pay_name";
            this.xEditGridCell520.Col = -1;
            this.xEditGridCell520.IsVisible = false;
            this.xEditGridCell520.Row = -1;
            // 
            // xEditGridCell521
            // 
            this.xEditGridCell521.CellLen = 100;
            this.xEditGridCell521.CellName = "bun_code";
            this.xEditGridCell521.Col = -1;
            this.xEditGridCell521.IsVisible = false;
            this.xEditGridCell521.Row = -1;
            // 
            // xEditGridCell522
            // 
            this.xEditGridCell522.CellLen = 100;
            this.xEditGridCell522.CellName = "data_control";
            this.xEditGridCell522.Col = -1;
            this.xEditGridCell522.IsVisible = false;
            this.xEditGridCell522.Row = -1;
            // 
            // xEditGridCell523
            // 
            this.xEditGridCell523.CellLen = 100;
            this.xEditGridCell523.CellName = "donbog_yn";
            this.xEditGridCell523.Col = -1;
            this.xEditGridCell523.IsVisible = false;
            this.xEditGridCell523.Row = -1;
            // 
            // xEditGridCell524
            // 
            this.xEditGridCell524.CellLen = 100;
            this.xEditGridCell524.CellName = "dv_name";
            this.xEditGridCell524.Col = -1;
            this.xEditGridCell524.IsVisible = false;
            this.xEditGridCell524.Row = -1;
            // 
            // xEditGridCell525
            // 
            this.xEditGridCell525.CellLen = 100;
            this.xEditGridCell525.CellName = "drg_info";
            this.xEditGridCell525.Col = -1;
            this.xEditGridCell525.IsVisible = false;
            this.xEditGridCell525.Row = -1;
            // 
            // xEditGridCell526
            // 
            this.xEditGridCell526.CellLen = 100;
            this.xEditGridCell526.CellName = "drg_bunryu";
            this.xEditGridCell526.Col = -1;
            this.xEditGridCell526.IsVisible = false;
            this.xEditGridCell526.Row = -1;
            // 
            // xEditGridCell527
            // 
            this.xEditGridCell527.CellLen = 100;
            this.xEditGridCell527.CellName = "child_gubun";
            this.xEditGridCell527.Col = -1;
            this.xEditGridCell527.IsVisible = false;
            this.xEditGridCell527.Row = -1;
            // 
            // xEditGridCell528
            // 
            this.xEditGridCell528.CellLen = 100;
            this.xEditGridCell528.CellName = "bom_source_key";
            this.xEditGridCell528.Col = -1;
            this.xEditGridCell528.IsVisible = false;
            this.xEditGridCell528.Row = -1;
            // 
            // xEditGridCell529
            // 
            this.xEditGridCell529.CellLen = 100;
            this.xEditGridCell529.CellName = "haengwee_yn";
            this.xEditGridCell529.Col = -1;
            this.xEditGridCell529.IsVisible = false;
            this.xEditGridCell529.Row = -1;
            // 
            // xEditGridCell530
            // 
            this.xEditGridCell530.CellLen = 100;
            this.xEditGridCell530.CellName = "org_key";
            this.xEditGridCell530.Col = -1;
            this.xEditGridCell530.IsVisible = false;
            this.xEditGridCell530.Row = -1;
            // 
            // xEditGridCell531
            // 
            this.xEditGridCell531.CellLen = 100;
            this.xEditGridCell531.CellName = "parent_key";
            this.xEditGridCell531.Col = -1;
            this.xEditGridCell531.IsVisible = false;
            this.xEditGridCell531.Row = -1;
            // 
            // xEditGridCell532
            // 
            this.xEditGridCell532.CellLen = 100;
            this.xEditGridCell532.CellName = "fkocs0300_seq";
            this.xEditGridCell532.Col = -1;
            this.xEditGridCell532.IsVisible = false;
            this.xEditGridCell532.Row = -1;
            // 
            // xEditGridCell533
            // 
            this.xEditGridCell533.CellLen = 100;
            this.xEditGridCell533.CellName = "child_yn";
            this.xEditGridCell533.Col = -1;
            this.xEditGridCell533.IsVisible = false;
            this.xEditGridCell533.Row = -1;
            // 
            // xEditGridCell534
            // 
            this.xEditGridCell534.CellLen = 100;
            this.xEditGridCell534.CellName = "jundal_table_out";
            this.xEditGridCell534.Col = -1;
            this.xEditGridCell534.IsVisible = false;
            this.xEditGridCell534.Row = -1;
            // 
            // xEditGridCell535
            // 
            this.xEditGridCell535.CellLen = 100;
            this.xEditGridCell535.CellName = "jundal_part_out";
            this.xEditGridCell535.Col = -1;
            this.xEditGridCell535.IsVisible = false;
            this.xEditGridCell535.Row = -1;
            // 
            // xEditGridCell536
            // 
            this.xEditGridCell536.CellLen = 100;
            this.xEditGridCell536.CellName = "jundal_table_inp";
            this.xEditGridCell536.Col = -1;
            this.xEditGridCell536.IsVisible = false;
            this.xEditGridCell536.Row = -1;
            // 
            // xEditGridCell537
            // 
            this.xEditGridCell537.CellLen = 100;
            this.xEditGridCell537.CellName = "jundal_part_inp";
            this.xEditGridCell537.Col = -1;
            this.xEditGridCell537.IsVisible = false;
            this.xEditGridCell537.Row = -1;
            // 
            // xEditGridCell538
            // 
            this.xEditGridCell538.CellLen = 100;
            this.xEditGridCell538.CellName = "move_part_out";
            this.xEditGridCell538.Col = -1;
            this.xEditGridCell538.IsVisible = false;
            this.xEditGridCell538.Row = -1;
            // 
            // xEditGridCell539
            // 
            this.xEditGridCell539.CellLen = 100;
            this.xEditGridCell539.CellName = "move_part_inp";
            this.xEditGridCell539.Col = -1;
            this.xEditGridCell539.IsVisible = false;
            this.xEditGridCell539.Row = -1;
            // 
            // xEditGridCell540
            // 
            this.xEditGridCell540.CellLen = 100;
            this.xEditGridCell540.CellName = "jundal_part_out_name";
            this.xEditGridCell540.Col = -1;
            this.xEditGridCell540.IsVisible = false;
            this.xEditGridCell540.Row = -1;
            // 
            // xEditGridCell541
            // 
            this.xEditGridCell541.CellLen = 100;
            this.xEditGridCell541.CellName = "jundal_part_inp_name";
            this.xEditGridCell541.Col = -1;
            this.xEditGridCell541.IsVisible = false;
            this.xEditGridCell541.Row = -1;
            // 
            // xEditGridCell542
            // 
            this.xEditGridCell542.CellLen = 100;
            this.xEditGridCell542.CellName = "wonnae_drg_yn";
            this.xEditGridCell542.Col = -1;
            this.xEditGridCell542.IsVisible = false;
            this.xEditGridCell542.Row = -1;
            // 
            // xEditGridCell543
            // 
            this.xEditGridCell543.CellLen = 100;
            this.xEditGridCell543.CellName = "dv_5";
            this.xEditGridCell543.Col = -1;
            this.xEditGridCell543.IsVisible = false;
            this.xEditGridCell543.Row = -1;
            // 
            // xEditGridCell544
            // 
            this.xEditGridCell544.CellLen = 100;
            this.xEditGridCell544.CellName = "dv_6";
            this.xEditGridCell544.Col = -1;
            this.xEditGridCell544.IsVisible = false;
            this.xEditGridCell544.Row = -1;
            // 
            // xEditGridCell545
            // 
            this.xEditGridCell545.CellLen = 100;
            this.xEditGridCell545.CellName = "dv_7";
            this.xEditGridCell545.Col = -1;
            this.xEditGridCell545.IsVisible = false;
            this.xEditGridCell545.Row = -1;
            // 
            // xEditGridCell546
            // 
            this.xEditGridCell546.CellLen = 100;
            this.xEditGridCell546.CellName = "dv_8";
            this.xEditGridCell546.Col = -1;
            this.xEditGridCell546.IsVisible = false;
            this.xEditGridCell546.Row = -1;
            // 
            // xEditGridCell547
            // 
            this.xEditGridCell547.CellLen = 100;
            this.xEditGridCell547.CellName = "general_disp_yn";
            this.xEditGridCell547.Col = -1;
            this.xEditGridCell547.IsVisible = false;
            this.xEditGridCell547.Row = -1;
            // 
            // xEditGridCell548
            // 
            this.xEditGridCell548.CellLen = 100;
            this.xEditGridCell548.CellName = "generic_name";
            this.xEditGridCell548.Col = -1;
            this.xEditGridCell548.IsVisible = false;
            this.xEditGridCell548.Row = -1;
            // 
            // xEditGridCell549
            // 
            this.xEditGridCell549.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell549.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell549.CellLen = 1;
            this.xEditGridCell549.CellName = "select";
            this.xEditGridCell549.CellWidth = 27;
            this.xEditGridCell549.HeaderText = "選択";
            this.xEditGridCell549.IsReadOnly = true;
            this.xEditGridCell549.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell549.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell549.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // grdOCS0323_6
            // 
            this.grdOCS0323_6.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell550,
            this.xEditGridCell551,
            this.xEditGridCell552,
            this.xEditGridCell553,
            this.xEditGridCell554,
            this.xEditGridCell555,
            this.xEditGridCell556,
            this.xEditGridCell557,
            this.xEditGridCell558,
            this.xEditGridCell559,
            this.xEditGridCell560,
            this.xEditGridCell561,
            this.xEditGridCell562,
            this.xEditGridCell563,
            this.xEditGridCell564,
            this.xEditGridCell565,
            this.xEditGridCell566,
            this.xEditGridCell567,
            this.xEditGridCell568,
            this.xEditGridCell569,
            this.xEditGridCell570,
            this.xEditGridCell571,
            this.xEditGridCell572,
            this.xEditGridCell573,
            this.xEditGridCell574,
            this.xEditGridCell575,
            this.xEditGridCell576,
            this.xEditGridCell577,
            this.xEditGridCell578,
            this.xEditGridCell579,
            this.xEditGridCell580,
            this.xEditGridCell581,
            this.xEditGridCell582,
            this.xEditGridCell583,
            this.xEditGridCell584,
            this.xEditGridCell585,
            this.xEditGridCell586,
            this.xEditGridCell587,
            this.xEditGridCell588,
            this.xEditGridCell589,
            this.xEditGridCell590,
            this.xEditGridCell591,
            this.xEditGridCell592,
            this.xEditGridCell593,
            this.xEditGridCell594,
            this.xEditGridCell595,
            this.xEditGridCell596,
            this.xEditGridCell597,
            this.xEditGridCell598,
            this.xEditGridCell599,
            this.xEditGridCell600,
            this.xEditGridCell601,
            this.xEditGridCell602,
            this.xEditGridCell603,
            this.xEditGridCell604,
            this.xEditGridCell605,
            this.xEditGridCell606,
            this.xEditGridCell607,
            this.xEditGridCell608,
            this.xEditGridCell609,
            this.xEditGridCell610,
            this.xEditGridCell611,
            this.xEditGridCell612,
            this.xEditGridCell613,
            this.xEditGridCell614,
            this.xEditGridCell615,
            this.xEditGridCell616,
            this.xEditGridCell617,
            this.xEditGridCell618,
            this.xEditGridCell619,
            this.xEditGridCell620,
            this.xEditGridCell621,
            this.xEditGridCell622,
            this.xEditGridCell623,
            this.xEditGridCell624,
            this.xEditGridCell625,
            this.xEditGridCell626,
            this.xEditGridCell627,
            this.xEditGridCell628,
            this.xEditGridCell629,
            this.xEditGridCell630,
            this.xEditGridCell631,
            this.xEditGridCell632,
            this.xEditGridCell633,
            this.xEditGridCell634,
            this.xEditGridCell635,
            this.xEditGridCell636,
            this.xEditGridCell637,
            this.xEditGridCell907});
            this.grdOCS0323_6.ColPerLine = 2;
            this.grdOCS0323_6.Cols = 2;
            this.grdOCS0323_6.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdOCS0323_6.FixedRows = 1;
            this.grdOCS0323_6.HeaderHeights.Add(21);
            this.grdOCS0323_6.Location = new System.Drawing.Point(730, 0);
            this.grdOCS0323_6.Name = "grdOCS0323_6";
            this.grdOCS0323_6.Rows = 2;
            this.grdOCS0323_6.RowStateCheckOnPaint = false;
            this.grdOCS0323_6.Size = new System.Drawing.Size(146, 639);
            this.grdOCS0323_6.TabIndex = 51;
            this.grdOCS0323_6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0323_all_MouseDown);
            // 
            // xEditGridCell550
            // 
            this.xEditGridCell550.CellLen = 100;
            this.xEditGridCell550.CellName = "memb";
            this.xEditGridCell550.Col = -1;
            this.xEditGridCell550.IsVisible = false;
            this.xEditGridCell550.Row = -1;
            // 
            // xEditGridCell551
            // 
            this.xEditGridCell551.CellLen = 100;
            this.xEditGridCell551.CellName = "fkocs0321";
            this.xEditGridCell551.Col = -1;
            this.xEditGridCell551.IsVisible = false;
            this.xEditGridCell551.Row = -1;
            // 
            // xEditGridCell552
            // 
            this.xEditGridCell552.CellLen = 100;
            this.xEditGridCell552.CellName = "pk_yaksok";
            this.xEditGridCell552.Col = -1;
            this.xEditGridCell552.IsVisible = false;
            this.xEditGridCell552.Row = -1;
            // 
            // xEditGridCell553
            // 
            this.xEditGridCell553.CellLen = 100;
            this.xEditGridCell553.CellName = "pkocs0323";
            this.xEditGridCell553.Col = -1;
            this.xEditGridCell553.IsVisible = false;
            this.xEditGridCell553.Row = -1;
            // 
            // xEditGridCell554
            // 
            this.xEditGridCell554.CellLen = 100;
            this.xEditGridCell554.CellName = "group_ser";
            this.xEditGridCell554.Col = -1;
            this.xEditGridCell554.IsVisible = false;
            this.xEditGridCell554.Row = -1;
            // 
            // xEditGridCell555
            // 
            this.xEditGridCell555.CellLen = 100;
            this.xEditGridCell555.CellName = "mix_group";
            this.xEditGridCell555.Col = -1;
            this.xEditGridCell555.IsVisible = false;
            this.xEditGridCell555.Row = -1;
            // 
            // xEditGridCell556
            // 
            this.xEditGridCell556.CellLen = 100;
            this.xEditGridCell556.CellName = "seq";
            this.xEditGridCell556.Col = -1;
            this.xEditGridCell556.IsVisible = false;
            this.xEditGridCell556.Row = -1;
            // 
            // xEditGridCell557
            // 
            this.xEditGridCell557.CellLen = 100;
            this.xEditGridCell557.CellName = "order_gubun";
            this.xEditGridCell557.Col = -1;
            this.xEditGridCell557.IsVisible = false;
            this.xEditGridCell557.Row = -1;
            // 
            // xEditGridCell558
            // 
            this.xEditGridCell558.CellLen = 100;
            this.xEditGridCell558.CellName = "order_gubun_name";
            this.xEditGridCell558.Col = -1;
            this.xEditGridCell558.IsVisible = false;
            this.xEditGridCell558.Row = -1;
            // 
            // xEditGridCell559
            // 
            this.xEditGridCell559.CellLen = 100;
            this.xEditGridCell559.CellName = "input_tab";
            this.xEditGridCell559.Col = -1;
            this.xEditGridCell559.IsVisible = false;
            this.xEditGridCell559.Row = -1;
            // 
            // xEditGridCell560
            // 
            this.xEditGridCell560.CellLen = 100;
            this.xEditGridCell560.CellName = "hangmog_code";
            this.xEditGridCell560.Col = -1;
            this.xEditGridCell560.IsVisible = false;
            this.xEditGridCell560.Row = -1;
            // 
            // xEditGridCell561
            // 
            this.xEditGridCell561.CellLen = 100;
            this.xEditGridCell561.CellName = "hangmog_name";
            this.xEditGridCell561.CellWidth = 115;
            this.xEditGridCell561.Col = 1;
            this.xEditGridCell561.HeaderText = "オーダ名";
            this.xEditGridCell561.IsReadOnly = true;
            // 
            // xEditGridCell562
            // 
            this.xEditGridCell562.CellLen = 100;
            this.xEditGridCell562.CellName = "specimen_code";
            this.xEditGridCell562.Col = -1;
            this.xEditGridCell562.IsVisible = false;
            this.xEditGridCell562.Row = -1;
            // 
            // xEditGridCell563
            // 
            this.xEditGridCell563.CellLen = 100;
            this.xEditGridCell563.CellName = "specimen_name";
            this.xEditGridCell563.Col = -1;
            this.xEditGridCell563.IsVisible = false;
            this.xEditGridCell563.Row = -1;
            // 
            // xEditGridCell564
            // 
            this.xEditGridCell564.CellLen = 100;
            this.xEditGridCell564.CellName = "suryang";
            this.xEditGridCell564.Col = -1;
            this.xEditGridCell564.IsVisible = false;
            this.xEditGridCell564.Row = -1;
            // 
            // xEditGridCell565
            // 
            this.xEditGridCell565.CellLen = 100;
            this.xEditGridCell565.CellName = "ord_danui";
            this.xEditGridCell565.Col = -1;
            this.xEditGridCell565.IsVisible = false;
            this.xEditGridCell565.Row = -1;
            // 
            // xEditGridCell566
            // 
            this.xEditGridCell566.CellLen = 100;
            this.xEditGridCell566.CellName = "order_danui_name";
            this.xEditGridCell566.Col = -1;
            this.xEditGridCell566.IsVisible = false;
            this.xEditGridCell566.Row = -1;
            // 
            // xEditGridCell567
            // 
            this.xEditGridCell567.CellLen = 100;
            this.xEditGridCell567.CellName = "dv_time";
            this.xEditGridCell567.Col = -1;
            this.xEditGridCell567.IsVisible = false;
            this.xEditGridCell567.Row = -1;
            // 
            // xEditGridCell568
            // 
            this.xEditGridCell568.CellLen = 100;
            this.xEditGridCell568.CellName = "dv";
            this.xEditGridCell568.Col = -1;
            this.xEditGridCell568.IsVisible = false;
            this.xEditGridCell568.Row = -1;
            // 
            // xEditGridCell569
            // 
            this.xEditGridCell569.CellLen = 100;
            this.xEditGridCell569.CellName = "dv_1";
            this.xEditGridCell569.Col = -1;
            this.xEditGridCell569.IsVisible = false;
            this.xEditGridCell569.Row = -1;
            // 
            // xEditGridCell570
            // 
            this.xEditGridCell570.CellLen = 100;
            this.xEditGridCell570.CellName = "dv_2";
            this.xEditGridCell570.Col = -1;
            this.xEditGridCell570.IsVisible = false;
            this.xEditGridCell570.Row = -1;
            // 
            // xEditGridCell571
            // 
            this.xEditGridCell571.CellLen = 100;
            this.xEditGridCell571.CellName = "dv_3";
            this.xEditGridCell571.Col = -1;
            this.xEditGridCell571.IsVisible = false;
            this.xEditGridCell571.Row = -1;
            // 
            // xEditGridCell572
            // 
            this.xEditGridCell572.CellLen = 100;
            this.xEditGridCell572.CellName = "dv_4";
            this.xEditGridCell572.Col = -1;
            this.xEditGridCell572.IsVisible = false;
            this.xEditGridCell572.Row = -1;
            // 
            // xEditGridCell573
            // 
            this.xEditGridCell573.CellLen = 100;
            this.xEditGridCell573.CellName = "nalsu";
            this.xEditGridCell573.Col = -1;
            this.xEditGridCell573.IsVisible = false;
            this.xEditGridCell573.Row = -1;
            // 
            // xEditGridCell574
            // 
            this.xEditGridCell574.CellLen = 100;
            this.xEditGridCell574.CellName = "jusa";
            this.xEditGridCell574.Col = -1;
            this.xEditGridCell574.IsVisible = false;
            this.xEditGridCell574.Row = -1;
            // 
            // xEditGridCell575
            // 
            this.xEditGridCell575.CellLen = 100;
            this.xEditGridCell575.CellName = "jusa_name";
            this.xEditGridCell575.Col = -1;
            this.xEditGridCell575.IsVisible = false;
            this.xEditGridCell575.Row = -1;
            // 
            // xEditGridCell576
            // 
            this.xEditGridCell576.CellLen = 100;
            this.xEditGridCell576.CellName = "bogyong_code";
            this.xEditGridCell576.Col = -1;
            this.xEditGridCell576.IsVisible = false;
            this.xEditGridCell576.Row = -1;
            // 
            // xEditGridCell577
            // 
            this.xEditGridCell577.CellLen = 100;
            this.xEditGridCell577.CellName = "bogyong_name";
            this.xEditGridCell577.Col = -1;
            this.xEditGridCell577.IsVisible = false;
            this.xEditGridCell577.Row = -1;
            // 
            // xEditGridCell578
            // 
            this.xEditGridCell578.CellLen = 100;
            this.xEditGridCell578.CellName = "jusa_spd_gubun";
            this.xEditGridCell578.Col = -1;
            this.xEditGridCell578.IsVisible = false;
            this.xEditGridCell578.Row = -1;
            // 
            // xEditGridCell579
            // 
            this.xEditGridCell579.CellLen = 100;
            this.xEditGridCell579.CellName = "hubal_change_yn";
            this.xEditGridCell579.Col = -1;
            this.xEditGridCell579.IsVisible = false;
            this.xEditGridCell579.Row = -1;
            // 
            // xEditGridCell580
            // 
            this.xEditGridCell580.CellLen = 100;
            this.xEditGridCell580.CellName = "pharmacy";
            this.xEditGridCell580.Col = -1;
            this.xEditGridCell580.IsVisible = false;
            this.xEditGridCell580.Row = -1;
            // 
            // xEditGridCell581
            // 
            this.xEditGridCell581.CellLen = 100;
            this.xEditGridCell581.CellName = "drg_pack_yn";
            this.xEditGridCell581.Col = -1;
            this.xEditGridCell581.IsVisible = false;
            this.xEditGridCell581.Row = -1;
            // 
            // xEditGridCell582
            // 
            this.xEditGridCell582.CellLen = 100;
            this.xEditGridCell582.CellName = "emergency";
            this.xEditGridCell582.Col = -1;
            this.xEditGridCell582.IsVisible = false;
            this.xEditGridCell582.Row = -1;
            // 
            // xEditGridCell583
            // 
            this.xEditGridCell583.CellLen = 100;
            this.xEditGridCell583.CellName = "pay";
            this.xEditGridCell583.Col = -1;
            this.xEditGridCell583.IsVisible = false;
            this.xEditGridCell583.Row = -1;
            // 
            // xEditGridCell584
            // 
            this.xEditGridCell584.CellLen = 100;
            this.xEditGridCell584.CellName = "portable_yn";
            this.xEditGridCell584.Col = -1;
            this.xEditGridCell584.IsVisible = false;
            this.xEditGridCell584.Row = -1;
            // 
            // xEditGridCell585
            // 
            this.xEditGridCell585.CellLen = 100;
            this.xEditGridCell585.CellName = "powder_yn";
            this.xEditGridCell585.Col = -1;
            this.xEditGridCell585.IsVisible = false;
            this.xEditGridCell585.Row = -1;
            // 
            // xEditGridCell586
            // 
            this.xEditGridCell586.CellLen = 100;
            this.xEditGridCell586.CellName = "muhyo";
            this.xEditGridCell586.Col = -1;
            this.xEditGridCell586.IsVisible = false;
            this.xEditGridCell586.Row = -1;
            // 
            // xEditGridCell587
            // 
            this.xEditGridCell587.CellLen = 100;
            this.xEditGridCell587.CellName = "prn_yn";
            this.xEditGridCell587.Col = -1;
            this.xEditGridCell587.IsVisible = false;
            this.xEditGridCell587.Row = -1;
            // 
            // xEditGridCell588
            // 
            this.xEditGridCell588.CellLen = 100;
            this.xEditGridCell588.CellName = "order_remark";
            this.xEditGridCell588.Col = -1;
            this.xEditGridCell588.IsVisible = false;
            this.xEditGridCell588.Row = -1;
            // 
            // xEditGridCell589
            // 
            this.xEditGridCell589.CellLen = 100;
            this.xEditGridCell589.CellName = "nurse_remark";
            this.xEditGridCell589.Col = -1;
            this.xEditGridCell589.IsVisible = false;
            this.xEditGridCell589.Row = -1;
            // 
            // xEditGridCell590
            // 
            this.xEditGridCell590.CellLen = 100;
            this.xEditGridCell590.CellName = "bulyong_check";
            this.xEditGridCell590.Col = -1;
            this.xEditGridCell590.IsVisible = false;
            this.xEditGridCell590.Row = -1;
            // 
            // xEditGridCell591
            // 
            this.xEditGridCell591.CellLen = 100;
            this.xEditGridCell591.CellName = "slip_code";
            this.xEditGridCell591.Col = -1;
            this.xEditGridCell591.IsVisible = false;
            this.xEditGridCell591.Row = -1;
            // 
            // xEditGridCell592
            // 
            this.xEditGridCell592.CellLen = 100;
            this.xEditGridCell592.CellName = "group_yn";
            this.xEditGridCell592.Col = -1;
            this.xEditGridCell592.IsVisible = false;
            this.xEditGridCell592.Row = -1;
            // 
            // xEditGridCell593
            // 
            this.xEditGridCell593.CellLen = 100;
            this.xEditGridCell593.CellName = "order_gubun_bas";
            this.xEditGridCell593.Col = -1;
            this.xEditGridCell593.IsVisible = false;
            this.xEditGridCell593.Row = -1;
            // 
            // xEditGridCell594
            // 
            this.xEditGridCell594.CellLen = 100;
            this.xEditGridCell594.CellName = "input_control";
            this.xEditGridCell594.Col = -1;
            this.xEditGridCell594.IsVisible = false;
            this.xEditGridCell594.Row = -1;
            // 
            // xEditGridCell595
            // 
            this.xEditGridCell595.CellLen = 100;
            this.xEditGridCell595.CellName = "sg_code";
            this.xEditGridCell595.Col = -1;
            this.xEditGridCell595.IsVisible = false;
            this.xEditGridCell595.Row = -1;
            // 
            // xEditGridCell596
            // 
            this.xEditGridCell596.CellLen = 100;
            this.xEditGridCell596.CellName = "suga_yn";
            this.xEditGridCell596.Col = -1;
            this.xEditGridCell596.IsVisible = false;
            this.xEditGridCell596.Row = -1;
            // 
            // xEditGridCell597
            // 
            this.xEditGridCell597.CellLen = 100;
            this.xEditGridCell597.CellName = "emergency_check";
            this.xEditGridCell597.Col = -1;
            this.xEditGridCell597.IsVisible = false;
            this.xEditGridCell597.Row = -1;
            // 
            // xEditGridCell598
            // 
            this.xEditGridCell598.CellLen = 100;
            this.xEditGridCell598.CellName = "limit_suryang";
            this.xEditGridCell598.Col = -1;
            this.xEditGridCell598.IsVisible = false;
            this.xEditGridCell598.Row = -1;
            // 
            // xEditGridCell599
            // 
            this.xEditGridCell599.CellLen = 100;
            this.xEditGridCell599.CellName = "specimen_yn";
            this.xEditGridCell599.Col = -1;
            this.xEditGridCell599.IsVisible = false;
            this.xEditGridCell599.Row = -1;
            // 
            // xEditGridCell600
            // 
            this.xEditGridCell600.CellLen = 100;
            this.xEditGridCell600.CellName = "jaeryo_yn";
            this.xEditGridCell600.Col = -1;
            this.xEditGridCell600.IsVisible = false;
            this.xEditGridCell600.Row = -1;
            // 
            // xEditGridCell601
            // 
            this.xEditGridCell601.CellLen = 100;
            this.xEditGridCell601.CellName = "ord_danui_check";
            this.xEditGridCell601.Col = -1;
            this.xEditGridCell601.IsVisible = false;
            this.xEditGridCell601.Row = -1;
            // 
            // xEditGridCell602
            // 
            this.xEditGridCell602.CellLen = 100;
            this.xEditGridCell602.CellName = "wonyoi_order_yn";
            this.xEditGridCell602.Col = -1;
            this.xEditGridCell602.IsVisible = false;
            this.xEditGridCell602.Row = -1;
            // 
            // xEditGridCell603
            // 
            this.xEditGridCell603.CellLen = 100;
            this.xEditGridCell603.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell603.Col = -1;
            this.xEditGridCell603.IsVisible = false;
            this.xEditGridCell603.Row = -1;
            // 
            // xEditGridCell604
            // 
            this.xEditGridCell604.CellLen = 100;
            this.xEditGridCell604.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell604.Col = -1;
            this.xEditGridCell604.IsVisible = false;
            this.xEditGridCell604.Row = -1;
            // 
            // xEditGridCell605
            // 
            this.xEditGridCell605.CellLen = 100;
            this.xEditGridCell605.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell605.Col = -1;
            this.xEditGridCell605.IsVisible = false;
            this.xEditGridCell605.Row = -1;
            // 
            // xEditGridCell606
            // 
            this.xEditGridCell606.CellLen = 100;
            this.xEditGridCell606.CellName = "nday_yn";
            this.xEditGridCell606.Col = -1;
            this.xEditGridCell606.IsVisible = false;
            this.xEditGridCell606.Row = -1;
            // 
            // xEditGridCell607
            // 
            this.xEditGridCell607.CellLen = 100;
            this.xEditGridCell607.CellName = "muhyo_yn";
            this.xEditGridCell607.Col = -1;
            this.xEditGridCell607.IsVisible = false;
            this.xEditGridCell607.Row = -1;
            // 
            // xEditGridCell608
            // 
            this.xEditGridCell608.CellLen = 100;
            this.xEditGridCell608.CellName = "pay_name";
            this.xEditGridCell608.Col = -1;
            this.xEditGridCell608.IsVisible = false;
            this.xEditGridCell608.Row = -1;
            // 
            // xEditGridCell609
            // 
            this.xEditGridCell609.CellLen = 100;
            this.xEditGridCell609.CellName = "bun_code";
            this.xEditGridCell609.Col = -1;
            this.xEditGridCell609.IsVisible = false;
            this.xEditGridCell609.Row = -1;
            // 
            // xEditGridCell610
            // 
            this.xEditGridCell610.CellLen = 100;
            this.xEditGridCell610.CellName = "data_control";
            this.xEditGridCell610.Col = -1;
            this.xEditGridCell610.IsVisible = false;
            this.xEditGridCell610.Row = -1;
            // 
            // xEditGridCell611
            // 
            this.xEditGridCell611.CellLen = 100;
            this.xEditGridCell611.CellName = "donbog_yn";
            this.xEditGridCell611.Col = -1;
            this.xEditGridCell611.IsVisible = false;
            this.xEditGridCell611.Row = -1;
            // 
            // xEditGridCell612
            // 
            this.xEditGridCell612.CellLen = 100;
            this.xEditGridCell612.CellName = "dv_name";
            this.xEditGridCell612.Col = -1;
            this.xEditGridCell612.IsVisible = false;
            this.xEditGridCell612.Row = -1;
            // 
            // xEditGridCell613
            // 
            this.xEditGridCell613.CellLen = 100;
            this.xEditGridCell613.CellName = "drg_info";
            this.xEditGridCell613.Col = -1;
            this.xEditGridCell613.IsVisible = false;
            this.xEditGridCell613.Row = -1;
            // 
            // xEditGridCell614
            // 
            this.xEditGridCell614.CellLen = 100;
            this.xEditGridCell614.CellName = "drg_bunryu";
            this.xEditGridCell614.Col = -1;
            this.xEditGridCell614.IsVisible = false;
            this.xEditGridCell614.Row = -1;
            // 
            // xEditGridCell615
            // 
            this.xEditGridCell615.CellLen = 100;
            this.xEditGridCell615.CellName = "child_gubun";
            this.xEditGridCell615.Col = -1;
            this.xEditGridCell615.IsVisible = false;
            this.xEditGridCell615.Row = -1;
            // 
            // xEditGridCell616
            // 
            this.xEditGridCell616.CellLen = 100;
            this.xEditGridCell616.CellName = "bom_source_key";
            this.xEditGridCell616.Col = -1;
            this.xEditGridCell616.IsVisible = false;
            this.xEditGridCell616.Row = -1;
            // 
            // xEditGridCell617
            // 
            this.xEditGridCell617.CellLen = 100;
            this.xEditGridCell617.CellName = "haengwee_yn";
            this.xEditGridCell617.Col = -1;
            this.xEditGridCell617.IsVisible = false;
            this.xEditGridCell617.Row = -1;
            // 
            // xEditGridCell618
            // 
            this.xEditGridCell618.CellLen = 100;
            this.xEditGridCell618.CellName = "org_key";
            this.xEditGridCell618.Col = -1;
            this.xEditGridCell618.IsVisible = false;
            this.xEditGridCell618.Row = -1;
            // 
            // xEditGridCell619
            // 
            this.xEditGridCell619.CellLen = 100;
            this.xEditGridCell619.CellName = "parent_key";
            this.xEditGridCell619.Col = -1;
            this.xEditGridCell619.IsVisible = false;
            this.xEditGridCell619.Row = -1;
            // 
            // xEditGridCell620
            // 
            this.xEditGridCell620.CellLen = 100;
            this.xEditGridCell620.CellName = "fkocs0300_seq";
            this.xEditGridCell620.Col = -1;
            this.xEditGridCell620.IsVisible = false;
            this.xEditGridCell620.Row = -1;
            // 
            // xEditGridCell621
            // 
            this.xEditGridCell621.CellLen = 100;
            this.xEditGridCell621.CellName = "child_yn";
            this.xEditGridCell621.Col = -1;
            this.xEditGridCell621.IsVisible = false;
            this.xEditGridCell621.Row = -1;
            // 
            // xEditGridCell622
            // 
            this.xEditGridCell622.CellLen = 100;
            this.xEditGridCell622.CellName = "jundal_table_out";
            this.xEditGridCell622.Col = -1;
            this.xEditGridCell622.IsVisible = false;
            this.xEditGridCell622.Row = -1;
            // 
            // xEditGridCell623
            // 
            this.xEditGridCell623.CellLen = 100;
            this.xEditGridCell623.CellName = "jundal_part_out";
            this.xEditGridCell623.Col = -1;
            this.xEditGridCell623.IsVisible = false;
            this.xEditGridCell623.Row = -1;
            // 
            // xEditGridCell624
            // 
            this.xEditGridCell624.CellLen = 100;
            this.xEditGridCell624.CellName = "jundal_table_inp";
            this.xEditGridCell624.Col = -1;
            this.xEditGridCell624.IsVisible = false;
            this.xEditGridCell624.Row = -1;
            // 
            // xEditGridCell625
            // 
            this.xEditGridCell625.CellLen = 100;
            this.xEditGridCell625.CellName = "jundal_part_inp";
            this.xEditGridCell625.Col = -1;
            this.xEditGridCell625.IsVisible = false;
            this.xEditGridCell625.Row = -1;
            // 
            // xEditGridCell626
            // 
            this.xEditGridCell626.CellLen = 100;
            this.xEditGridCell626.CellName = "move_part_out";
            this.xEditGridCell626.Col = -1;
            this.xEditGridCell626.IsVisible = false;
            this.xEditGridCell626.Row = -1;
            // 
            // xEditGridCell627
            // 
            this.xEditGridCell627.CellLen = 100;
            this.xEditGridCell627.CellName = "move_part_inp";
            this.xEditGridCell627.Col = -1;
            this.xEditGridCell627.IsVisible = false;
            this.xEditGridCell627.Row = -1;
            // 
            // xEditGridCell628
            // 
            this.xEditGridCell628.CellLen = 100;
            this.xEditGridCell628.CellName = "jundal_part_out_name";
            this.xEditGridCell628.Col = -1;
            this.xEditGridCell628.IsVisible = false;
            this.xEditGridCell628.Row = -1;
            // 
            // xEditGridCell629
            // 
            this.xEditGridCell629.CellLen = 100;
            this.xEditGridCell629.CellName = "jundal_part_inp_name";
            this.xEditGridCell629.Col = -1;
            this.xEditGridCell629.IsVisible = false;
            this.xEditGridCell629.Row = -1;
            // 
            // xEditGridCell630
            // 
            this.xEditGridCell630.CellLen = 100;
            this.xEditGridCell630.CellName = "wonnae_drg_yn";
            this.xEditGridCell630.Col = -1;
            this.xEditGridCell630.IsVisible = false;
            this.xEditGridCell630.Row = -1;
            // 
            // xEditGridCell631
            // 
            this.xEditGridCell631.CellLen = 100;
            this.xEditGridCell631.CellName = "dv_5";
            this.xEditGridCell631.Col = -1;
            this.xEditGridCell631.IsVisible = false;
            this.xEditGridCell631.Row = -1;
            // 
            // xEditGridCell632
            // 
            this.xEditGridCell632.CellLen = 100;
            this.xEditGridCell632.CellName = "dv_6";
            this.xEditGridCell632.Col = -1;
            this.xEditGridCell632.IsVisible = false;
            this.xEditGridCell632.Row = -1;
            // 
            // xEditGridCell633
            // 
            this.xEditGridCell633.CellLen = 100;
            this.xEditGridCell633.CellName = "dv_7";
            this.xEditGridCell633.Col = -1;
            this.xEditGridCell633.IsVisible = false;
            this.xEditGridCell633.Row = -1;
            // 
            // xEditGridCell634
            // 
            this.xEditGridCell634.CellLen = 100;
            this.xEditGridCell634.CellName = "dv_8";
            this.xEditGridCell634.Col = -1;
            this.xEditGridCell634.IsVisible = false;
            this.xEditGridCell634.Row = -1;
            // 
            // xEditGridCell635
            // 
            this.xEditGridCell635.CellLen = 100;
            this.xEditGridCell635.CellName = "general_disp_yn";
            this.xEditGridCell635.Col = -1;
            this.xEditGridCell635.IsVisible = false;
            this.xEditGridCell635.Row = -1;
            // 
            // xEditGridCell636
            // 
            this.xEditGridCell636.CellLen = 100;
            this.xEditGridCell636.CellName = "generic_name";
            this.xEditGridCell636.Col = -1;
            this.xEditGridCell636.IsVisible = false;
            this.xEditGridCell636.Row = -1;
            // 
            // xEditGridCell637
            // 
            this.xEditGridCell637.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell637.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell637.CellLen = 1;
            this.xEditGridCell637.CellName = "select";
            this.xEditGridCell637.CellWidth = 27;
            this.xEditGridCell637.HeaderText = "選択";
            this.xEditGridCell637.IsReadOnly = true;
            this.xEditGridCell637.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell637.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell637.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // grdOCS0323_7
            // 
            this.grdOCS0323_7.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell638,
            this.xEditGridCell639,
            this.xEditGridCell640,
            this.xEditGridCell641,
            this.xEditGridCell642,
            this.xEditGridCell643,
            this.xEditGridCell644,
            this.xEditGridCell645,
            this.xEditGridCell646,
            this.xEditGridCell647,
            this.xEditGridCell648,
            this.xEditGridCell649,
            this.xEditGridCell650,
            this.xEditGridCell651,
            this.xEditGridCell652,
            this.xEditGridCell653,
            this.xEditGridCell654,
            this.xEditGridCell655,
            this.xEditGridCell656,
            this.xEditGridCell657,
            this.xEditGridCell658,
            this.xEditGridCell659,
            this.xEditGridCell660,
            this.xEditGridCell661,
            this.xEditGridCell662,
            this.xEditGridCell663,
            this.xEditGridCell664,
            this.xEditGridCell665,
            this.xEditGridCell666,
            this.xEditGridCell667,
            this.xEditGridCell668,
            this.xEditGridCell669,
            this.xEditGridCell670,
            this.xEditGridCell671,
            this.xEditGridCell672,
            this.xEditGridCell673,
            this.xEditGridCell674,
            this.xEditGridCell675,
            this.xEditGridCell676,
            this.xEditGridCell677,
            this.xEditGridCell678,
            this.xEditGridCell679,
            this.xEditGridCell680,
            this.xEditGridCell681,
            this.xEditGridCell682,
            this.xEditGridCell683,
            this.xEditGridCell684,
            this.xEditGridCell685,
            this.xEditGridCell686,
            this.xEditGridCell687,
            this.xEditGridCell688,
            this.xEditGridCell689,
            this.xEditGridCell690,
            this.xEditGridCell691,
            this.xEditGridCell692,
            this.xEditGridCell693,
            this.xEditGridCell694,
            this.xEditGridCell695,
            this.xEditGridCell696,
            this.xEditGridCell697,
            this.xEditGridCell698,
            this.xEditGridCell699,
            this.xEditGridCell700,
            this.xEditGridCell701,
            this.xEditGridCell702,
            this.xEditGridCell703,
            this.xEditGridCell704,
            this.xEditGridCell705,
            this.xEditGridCell706,
            this.xEditGridCell707,
            this.xEditGridCell708,
            this.xEditGridCell709,
            this.xEditGridCell710,
            this.xEditGridCell711,
            this.xEditGridCell712,
            this.xEditGridCell713,
            this.xEditGridCell714,
            this.xEditGridCell715,
            this.xEditGridCell716,
            this.xEditGridCell717,
            this.xEditGridCell718,
            this.xEditGridCell719,
            this.xEditGridCell720,
            this.xEditGridCell721,
            this.xEditGridCell722,
            this.xEditGridCell723,
            this.xEditGridCell724,
            this.xEditGridCell725,
            this.xEditGridCell908});
            this.grdOCS0323_7.ColPerLine = 2;
            this.grdOCS0323_7.Cols = 2;
            this.grdOCS0323_7.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdOCS0323_7.FixedRows = 1;
            this.grdOCS0323_7.HeaderHeights.Add(21);
            this.grdOCS0323_7.Location = new System.Drawing.Point(876, 0);
            this.grdOCS0323_7.Name = "grdOCS0323_7";
            this.grdOCS0323_7.Rows = 2;
            this.grdOCS0323_7.RowStateCheckOnPaint = false;
            this.grdOCS0323_7.Size = new System.Drawing.Size(146, 639);
            this.grdOCS0323_7.TabIndex = 52;
            this.grdOCS0323_7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0323_all_MouseDown);
            // 
            // xEditGridCell638
            // 
            this.xEditGridCell638.CellLen = 100;
            this.xEditGridCell638.CellName = "memb";
            this.xEditGridCell638.Col = -1;
            this.xEditGridCell638.IsVisible = false;
            this.xEditGridCell638.Row = -1;
            // 
            // xEditGridCell639
            // 
            this.xEditGridCell639.CellLen = 100;
            this.xEditGridCell639.CellName = "fkocs0321";
            this.xEditGridCell639.Col = -1;
            this.xEditGridCell639.IsVisible = false;
            this.xEditGridCell639.Row = -1;
            // 
            // xEditGridCell640
            // 
            this.xEditGridCell640.CellLen = 100;
            this.xEditGridCell640.CellName = "pk_yaksok";
            this.xEditGridCell640.Col = -1;
            this.xEditGridCell640.IsVisible = false;
            this.xEditGridCell640.Row = -1;
            // 
            // xEditGridCell641
            // 
            this.xEditGridCell641.CellLen = 100;
            this.xEditGridCell641.CellName = "pkocs0323";
            this.xEditGridCell641.Col = -1;
            this.xEditGridCell641.IsVisible = false;
            this.xEditGridCell641.Row = -1;
            // 
            // xEditGridCell642
            // 
            this.xEditGridCell642.CellLen = 100;
            this.xEditGridCell642.CellName = "group_ser";
            this.xEditGridCell642.Col = -1;
            this.xEditGridCell642.IsVisible = false;
            this.xEditGridCell642.Row = -1;
            // 
            // xEditGridCell643
            // 
            this.xEditGridCell643.CellLen = 100;
            this.xEditGridCell643.CellName = "mix_group";
            this.xEditGridCell643.Col = -1;
            this.xEditGridCell643.IsVisible = false;
            this.xEditGridCell643.Row = -1;
            // 
            // xEditGridCell644
            // 
            this.xEditGridCell644.CellLen = 100;
            this.xEditGridCell644.CellName = "seq";
            this.xEditGridCell644.Col = -1;
            this.xEditGridCell644.IsVisible = false;
            this.xEditGridCell644.Row = -1;
            // 
            // xEditGridCell645
            // 
            this.xEditGridCell645.CellLen = 100;
            this.xEditGridCell645.CellName = "order_gubun";
            this.xEditGridCell645.Col = -1;
            this.xEditGridCell645.IsVisible = false;
            this.xEditGridCell645.Row = -1;
            // 
            // xEditGridCell646
            // 
            this.xEditGridCell646.CellLen = 100;
            this.xEditGridCell646.CellName = "order_gubun_name";
            this.xEditGridCell646.Col = -1;
            this.xEditGridCell646.IsVisible = false;
            this.xEditGridCell646.Row = -1;
            // 
            // xEditGridCell647
            // 
            this.xEditGridCell647.CellLen = 100;
            this.xEditGridCell647.CellName = "input_tab";
            this.xEditGridCell647.Col = -1;
            this.xEditGridCell647.IsVisible = false;
            this.xEditGridCell647.Row = -1;
            // 
            // xEditGridCell648
            // 
            this.xEditGridCell648.CellLen = 100;
            this.xEditGridCell648.CellName = "hangmog_code";
            this.xEditGridCell648.Col = -1;
            this.xEditGridCell648.IsVisible = false;
            this.xEditGridCell648.Row = -1;
            // 
            // xEditGridCell649
            // 
            this.xEditGridCell649.CellLen = 100;
            this.xEditGridCell649.CellName = "hangmog_name";
            this.xEditGridCell649.CellWidth = 115;
            this.xEditGridCell649.Col = 1;
            this.xEditGridCell649.HeaderText = "オーダ名";
            this.xEditGridCell649.IsReadOnly = true;
            // 
            // xEditGridCell650
            // 
            this.xEditGridCell650.CellLen = 100;
            this.xEditGridCell650.CellName = "specimen_code";
            this.xEditGridCell650.Col = -1;
            this.xEditGridCell650.IsVisible = false;
            this.xEditGridCell650.Row = -1;
            // 
            // xEditGridCell651
            // 
            this.xEditGridCell651.CellLen = 100;
            this.xEditGridCell651.CellName = "specimen_name";
            this.xEditGridCell651.Col = -1;
            this.xEditGridCell651.IsVisible = false;
            this.xEditGridCell651.Row = -1;
            // 
            // xEditGridCell652
            // 
            this.xEditGridCell652.CellLen = 100;
            this.xEditGridCell652.CellName = "suryang";
            this.xEditGridCell652.Col = -1;
            this.xEditGridCell652.IsVisible = false;
            this.xEditGridCell652.Row = -1;
            // 
            // xEditGridCell653
            // 
            this.xEditGridCell653.CellLen = 100;
            this.xEditGridCell653.CellName = "ord_danui";
            this.xEditGridCell653.Col = -1;
            this.xEditGridCell653.IsVisible = false;
            this.xEditGridCell653.Row = -1;
            // 
            // xEditGridCell654
            // 
            this.xEditGridCell654.CellLen = 100;
            this.xEditGridCell654.CellName = "order_danui_name";
            this.xEditGridCell654.Col = -1;
            this.xEditGridCell654.IsVisible = false;
            this.xEditGridCell654.Row = -1;
            // 
            // xEditGridCell655
            // 
            this.xEditGridCell655.CellLen = 100;
            this.xEditGridCell655.CellName = "dv_time";
            this.xEditGridCell655.Col = -1;
            this.xEditGridCell655.IsVisible = false;
            this.xEditGridCell655.Row = -1;
            // 
            // xEditGridCell656
            // 
            this.xEditGridCell656.CellLen = 100;
            this.xEditGridCell656.CellName = "dv";
            this.xEditGridCell656.Col = -1;
            this.xEditGridCell656.IsVisible = false;
            this.xEditGridCell656.Row = -1;
            // 
            // xEditGridCell657
            // 
            this.xEditGridCell657.CellLen = 100;
            this.xEditGridCell657.CellName = "dv_1";
            this.xEditGridCell657.Col = -1;
            this.xEditGridCell657.IsVisible = false;
            this.xEditGridCell657.Row = -1;
            // 
            // xEditGridCell658
            // 
            this.xEditGridCell658.CellLen = 100;
            this.xEditGridCell658.CellName = "dv_2";
            this.xEditGridCell658.Col = -1;
            this.xEditGridCell658.IsVisible = false;
            this.xEditGridCell658.Row = -1;
            // 
            // xEditGridCell659
            // 
            this.xEditGridCell659.CellLen = 100;
            this.xEditGridCell659.CellName = "dv_3";
            this.xEditGridCell659.Col = -1;
            this.xEditGridCell659.IsVisible = false;
            this.xEditGridCell659.Row = -1;
            // 
            // xEditGridCell660
            // 
            this.xEditGridCell660.CellLen = 100;
            this.xEditGridCell660.CellName = "dv_4";
            this.xEditGridCell660.Col = -1;
            this.xEditGridCell660.IsVisible = false;
            this.xEditGridCell660.Row = -1;
            // 
            // xEditGridCell661
            // 
            this.xEditGridCell661.CellLen = 100;
            this.xEditGridCell661.CellName = "nalsu";
            this.xEditGridCell661.Col = -1;
            this.xEditGridCell661.IsVisible = false;
            this.xEditGridCell661.Row = -1;
            // 
            // xEditGridCell662
            // 
            this.xEditGridCell662.CellLen = 100;
            this.xEditGridCell662.CellName = "jusa";
            this.xEditGridCell662.Col = -1;
            this.xEditGridCell662.IsVisible = false;
            this.xEditGridCell662.Row = -1;
            // 
            // xEditGridCell663
            // 
            this.xEditGridCell663.CellLen = 100;
            this.xEditGridCell663.CellName = "jusa_name";
            this.xEditGridCell663.Col = -1;
            this.xEditGridCell663.IsVisible = false;
            this.xEditGridCell663.Row = -1;
            // 
            // xEditGridCell664
            // 
            this.xEditGridCell664.CellLen = 100;
            this.xEditGridCell664.CellName = "bogyong_code";
            this.xEditGridCell664.Col = -1;
            this.xEditGridCell664.IsVisible = false;
            this.xEditGridCell664.Row = -1;
            // 
            // xEditGridCell665
            // 
            this.xEditGridCell665.CellLen = 100;
            this.xEditGridCell665.CellName = "bogyong_name";
            this.xEditGridCell665.Col = -1;
            this.xEditGridCell665.IsVisible = false;
            this.xEditGridCell665.Row = -1;
            // 
            // xEditGridCell666
            // 
            this.xEditGridCell666.CellLen = 100;
            this.xEditGridCell666.CellName = "jusa_spd_gubun";
            this.xEditGridCell666.Col = -1;
            this.xEditGridCell666.IsVisible = false;
            this.xEditGridCell666.Row = -1;
            // 
            // xEditGridCell667
            // 
            this.xEditGridCell667.CellLen = 100;
            this.xEditGridCell667.CellName = "hubal_change_yn";
            this.xEditGridCell667.Col = -1;
            this.xEditGridCell667.IsVisible = false;
            this.xEditGridCell667.Row = -1;
            // 
            // xEditGridCell668
            // 
            this.xEditGridCell668.CellLen = 100;
            this.xEditGridCell668.CellName = "pharmacy";
            this.xEditGridCell668.Col = -1;
            this.xEditGridCell668.IsVisible = false;
            this.xEditGridCell668.Row = -1;
            // 
            // xEditGridCell669
            // 
            this.xEditGridCell669.CellLen = 100;
            this.xEditGridCell669.CellName = "drg_pack_yn";
            this.xEditGridCell669.Col = -1;
            this.xEditGridCell669.IsVisible = false;
            this.xEditGridCell669.Row = -1;
            // 
            // xEditGridCell670
            // 
            this.xEditGridCell670.CellLen = 100;
            this.xEditGridCell670.CellName = "emergency";
            this.xEditGridCell670.Col = -1;
            this.xEditGridCell670.IsVisible = false;
            this.xEditGridCell670.Row = -1;
            // 
            // xEditGridCell671
            // 
            this.xEditGridCell671.CellLen = 100;
            this.xEditGridCell671.CellName = "pay";
            this.xEditGridCell671.Col = -1;
            this.xEditGridCell671.IsVisible = false;
            this.xEditGridCell671.Row = -1;
            // 
            // xEditGridCell672
            // 
            this.xEditGridCell672.CellLen = 100;
            this.xEditGridCell672.CellName = "portable_yn";
            this.xEditGridCell672.Col = -1;
            this.xEditGridCell672.IsVisible = false;
            this.xEditGridCell672.Row = -1;
            // 
            // xEditGridCell673
            // 
            this.xEditGridCell673.CellLen = 100;
            this.xEditGridCell673.CellName = "powder_yn";
            this.xEditGridCell673.Col = -1;
            this.xEditGridCell673.IsVisible = false;
            this.xEditGridCell673.Row = -1;
            // 
            // xEditGridCell674
            // 
            this.xEditGridCell674.CellLen = 100;
            this.xEditGridCell674.CellName = "muhyo";
            this.xEditGridCell674.Col = -1;
            this.xEditGridCell674.IsVisible = false;
            this.xEditGridCell674.Row = -1;
            // 
            // xEditGridCell675
            // 
            this.xEditGridCell675.CellLen = 100;
            this.xEditGridCell675.CellName = "prn_yn";
            this.xEditGridCell675.Col = -1;
            this.xEditGridCell675.IsVisible = false;
            this.xEditGridCell675.Row = -1;
            // 
            // xEditGridCell676
            // 
            this.xEditGridCell676.CellLen = 100;
            this.xEditGridCell676.CellName = "order_remark";
            this.xEditGridCell676.Col = -1;
            this.xEditGridCell676.IsVisible = false;
            this.xEditGridCell676.Row = -1;
            // 
            // xEditGridCell677
            // 
            this.xEditGridCell677.CellLen = 100;
            this.xEditGridCell677.CellName = "nurse_remark";
            this.xEditGridCell677.Col = -1;
            this.xEditGridCell677.IsVisible = false;
            this.xEditGridCell677.Row = -1;
            // 
            // xEditGridCell678
            // 
            this.xEditGridCell678.CellLen = 100;
            this.xEditGridCell678.CellName = "bulyong_check";
            this.xEditGridCell678.Col = -1;
            this.xEditGridCell678.IsVisible = false;
            this.xEditGridCell678.Row = -1;
            // 
            // xEditGridCell679
            // 
            this.xEditGridCell679.CellLen = 100;
            this.xEditGridCell679.CellName = "slip_code";
            this.xEditGridCell679.Col = -1;
            this.xEditGridCell679.IsVisible = false;
            this.xEditGridCell679.Row = -1;
            // 
            // xEditGridCell680
            // 
            this.xEditGridCell680.CellLen = 100;
            this.xEditGridCell680.CellName = "group_yn";
            this.xEditGridCell680.Col = -1;
            this.xEditGridCell680.IsVisible = false;
            this.xEditGridCell680.Row = -1;
            // 
            // xEditGridCell681
            // 
            this.xEditGridCell681.CellLen = 100;
            this.xEditGridCell681.CellName = "order_gubun_bas";
            this.xEditGridCell681.Col = -1;
            this.xEditGridCell681.IsVisible = false;
            this.xEditGridCell681.Row = -1;
            // 
            // xEditGridCell682
            // 
            this.xEditGridCell682.CellLen = 100;
            this.xEditGridCell682.CellName = "input_control";
            this.xEditGridCell682.Col = -1;
            this.xEditGridCell682.IsVisible = false;
            this.xEditGridCell682.Row = -1;
            // 
            // xEditGridCell683
            // 
            this.xEditGridCell683.CellLen = 100;
            this.xEditGridCell683.CellName = "sg_code";
            this.xEditGridCell683.Col = -1;
            this.xEditGridCell683.IsVisible = false;
            this.xEditGridCell683.Row = -1;
            // 
            // xEditGridCell684
            // 
            this.xEditGridCell684.CellLen = 100;
            this.xEditGridCell684.CellName = "suga_yn";
            this.xEditGridCell684.Col = -1;
            this.xEditGridCell684.IsVisible = false;
            this.xEditGridCell684.Row = -1;
            // 
            // xEditGridCell685
            // 
            this.xEditGridCell685.CellLen = 100;
            this.xEditGridCell685.CellName = "emergency_check";
            this.xEditGridCell685.Col = -1;
            this.xEditGridCell685.IsVisible = false;
            this.xEditGridCell685.Row = -1;
            // 
            // xEditGridCell686
            // 
            this.xEditGridCell686.CellLen = 100;
            this.xEditGridCell686.CellName = "limit_suryang";
            this.xEditGridCell686.Col = -1;
            this.xEditGridCell686.IsVisible = false;
            this.xEditGridCell686.Row = -1;
            // 
            // xEditGridCell687
            // 
            this.xEditGridCell687.CellLen = 100;
            this.xEditGridCell687.CellName = "specimen_yn";
            this.xEditGridCell687.Col = -1;
            this.xEditGridCell687.IsVisible = false;
            this.xEditGridCell687.Row = -1;
            // 
            // xEditGridCell688
            // 
            this.xEditGridCell688.CellLen = 100;
            this.xEditGridCell688.CellName = "jaeryo_yn";
            this.xEditGridCell688.Col = -1;
            this.xEditGridCell688.IsVisible = false;
            this.xEditGridCell688.Row = -1;
            // 
            // xEditGridCell689
            // 
            this.xEditGridCell689.CellLen = 100;
            this.xEditGridCell689.CellName = "ord_danui_check";
            this.xEditGridCell689.Col = -1;
            this.xEditGridCell689.IsVisible = false;
            this.xEditGridCell689.Row = -1;
            // 
            // xEditGridCell690
            // 
            this.xEditGridCell690.CellLen = 100;
            this.xEditGridCell690.CellName = "wonyoi_order_yn";
            this.xEditGridCell690.Col = -1;
            this.xEditGridCell690.IsVisible = false;
            this.xEditGridCell690.Row = -1;
            // 
            // xEditGridCell691
            // 
            this.xEditGridCell691.CellLen = 100;
            this.xEditGridCell691.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell691.Col = -1;
            this.xEditGridCell691.IsVisible = false;
            this.xEditGridCell691.Row = -1;
            // 
            // xEditGridCell692
            // 
            this.xEditGridCell692.CellLen = 100;
            this.xEditGridCell692.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell692.Col = -1;
            this.xEditGridCell692.IsVisible = false;
            this.xEditGridCell692.Row = -1;
            // 
            // xEditGridCell693
            // 
            this.xEditGridCell693.CellLen = 100;
            this.xEditGridCell693.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell693.Col = -1;
            this.xEditGridCell693.IsVisible = false;
            this.xEditGridCell693.Row = -1;
            // 
            // xEditGridCell694
            // 
            this.xEditGridCell694.CellLen = 100;
            this.xEditGridCell694.CellName = "nday_yn";
            this.xEditGridCell694.Col = -1;
            this.xEditGridCell694.IsVisible = false;
            this.xEditGridCell694.Row = -1;
            // 
            // xEditGridCell695
            // 
            this.xEditGridCell695.CellLen = 100;
            this.xEditGridCell695.CellName = "muhyo_yn";
            this.xEditGridCell695.Col = -1;
            this.xEditGridCell695.IsVisible = false;
            this.xEditGridCell695.Row = -1;
            // 
            // xEditGridCell696
            // 
            this.xEditGridCell696.CellLen = 100;
            this.xEditGridCell696.CellName = "pay_name";
            this.xEditGridCell696.Col = -1;
            this.xEditGridCell696.IsVisible = false;
            this.xEditGridCell696.Row = -1;
            // 
            // xEditGridCell697
            // 
            this.xEditGridCell697.CellLen = 100;
            this.xEditGridCell697.CellName = "bun_code";
            this.xEditGridCell697.Col = -1;
            this.xEditGridCell697.IsVisible = false;
            this.xEditGridCell697.Row = -1;
            // 
            // xEditGridCell698
            // 
            this.xEditGridCell698.CellLen = 100;
            this.xEditGridCell698.CellName = "data_control";
            this.xEditGridCell698.Col = -1;
            this.xEditGridCell698.IsVisible = false;
            this.xEditGridCell698.Row = -1;
            // 
            // xEditGridCell699
            // 
            this.xEditGridCell699.CellLen = 100;
            this.xEditGridCell699.CellName = "donbog_yn";
            this.xEditGridCell699.Col = -1;
            this.xEditGridCell699.IsVisible = false;
            this.xEditGridCell699.Row = -1;
            // 
            // xEditGridCell700
            // 
            this.xEditGridCell700.CellLen = 100;
            this.xEditGridCell700.CellName = "dv_name";
            this.xEditGridCell700.Col = -1;
            this.xEditGridCell700.IsVisible = false;
            this.xEditGridCell700.Row = -1;
            // 
            // xEditGridCell701
            // 
            this.xEditGridCell701.CellLen = 100;
            this.xEditGridCell701.CellName = "drg_info";
            this.xEditGridCell701.Col = -1;
            this.xEditGridCell701.IsVisible = false;
            this.xEditGridCell701.Row = -1;
            // 
            // xEditGridCell702
            // 
            this.xEditGridCell702.CellLen = 100;
            this.xEditGridCell702.CellName = "drg_bunryu";
            this.xEditGridCell702.Col = -1;
            this.xEditGridCell702.IsVisible = false;
            this.xEditGridCell702.Row = -1;
            // 
            // xEditGridCell703
            // 
            this.xEditGridCell703.CellLen = 100;
            this.xEditGridCell703.CellName = "child_gubun";
            this.xEditGridCell703.Col = -1;
            this.xEditGridCell703.IsVisible = false;
            this.xEditGridCell703.Row = -1;
            // 
            // xEditGridCell704
            // 
            this.xEditGridCell704.CellLen = 100;
            this.xEditGridCell704.CellName = "bom_source_key";
            this.xEditGridCell704.Col = -1;
            this.xEditGridCell704.IsVisible = false;
            this.xEditGridCell704.Row = -1;
            // 
            // xEditGridCell705
            // 
            this.xEditGridCell705.CellLen = 100;
            this.xEditGridCell705.CellName = "haengwee_yn";
            this.xEditGridCell705.Col = -1;
            this.xEditGridCell705.IsVisible = false;
            this.xEditGridCell705.Row = -1;
            // 
            // xEditGridCell706
            // 
            this.xEditGridCell706.CellLen = 100;
            this.xEditGridCell706.CellName = "org_key";
            this.xEditGridCell706.Col = -1;
            this.xEditGridCell706.IsVisible = false;
            this.xEditGridCell706.Row = -1;
            // 
            // xEditGridCell707
            // 
            this.xEditGridCell707.CellLen = 100;
            this.xEditGridCell707.CellName = "parent_key";
            this.xEditGridCell707.Col = -1;
            this.xEditGridCell707.IsVisible = false;
            this.xEditGridCell707.Row = -1;
            // 
            // xEditGridCell708
            // 
            this.xEditGridCell708.CellLen = 100;
            this.xEditGridCell708.CellName = "fkocs0300_seq";
            this.xEditGridCell708.Col = -1;
            this.xEditGridCell708.IsVisible = false;
            this.xEditGridCell708.Row = -1;
            // 
            // xEditGridCell709
            // 
            this.xEditGridCell709.CellLen = 100;
            this.xEditGridCell709.CellName = "child_yn";
            this.xEditGridCell709.Col = -1;
            this.xEditGridCell709.IsVisible = false;
            this.xEditGridCell709.Row = -1;
            // 
            // xEditGridCell710
            // 
            this.xEditGridCell710.CellLen = 100;
            this.xEditGridCell710.CellName = "jundal_table_out";
            this.xEditGridCell710.Col = -1;
            this.xEditGridCell710.IsVisible = false;
            this.xEditGridCell710.Row = -1;
            // 
            // xEditGridCell711
            // 
            this.xEditGridCell711.CellLen = 100;
            this.xEditGridCell711.CellName = "jundal_part_out";
            this.xEditGridCell711.Col = -1;
            this.xEditGridCell711.IsVisible = false;
            this.xEditGridCell711.Row = -1;
            // 
            // xEditGridCell712
            // 
            this.xEditGridCell712.CellLen = 100;
            this.xEditGridCell712.CellName = "jundal_table_inp";
            this.xEditGridCell712.Col = -1;
            this.xEditGridCell712.IsVisible = false;
            this.xEditGridCell712.Row = -1;
            // 
            // xEditGridCell713
            // 
            this.xEditGridCell713.CellLen = 100;
            this.xEditGridCell713.CellName = "jundal_part_inp";
            this.xEditGridCell713.Col = -1;
            this.xEditGridCell713.IsVisible = false;
            this.xEditGridCell713.Row = -1;
            // 
            // xEditGridCell714
            // 
            this.xEditGridCell714.CellLen = 100;
            this.xEditGridCell714.CellName = "move_part_out";
            this.xEditGridCell714.Col = -1;
            this.xEditGridCell714.IsVisible = false;
            this.xEditGridCell714.Row = -1;
            // 
            // xEditGridCell715
            // 
            this.xEditGridCell715.CellLen = 100;
            this.xEditGridCell715.CellName = "move_part_inp";
            this.xEditGridCell715.Col = -1;
            this.xEditGridCell715.IsVisible = false;
            this.xEditGridCell715.Row = -1;
            // 
            // xEditGridCell716
            // 
            this.xEditGridCell716.CellLen = 100;
            this.xEditGridCell716.CellName = "jundal_part_out_name";
            this.xEditGridCell716.Col = -1;
            this.xEditGridCell716.IsVisible = false;
            this.xEditGridCell716.Row = -1;
            // 
            // xEditGridCell717
            // 
            this.xEditGridCell717.CellLen = 100;
            this.xEditGridCell717.CellName = "jundal_part_inp_name";
            this.xEditGridCell717.Col = -1;
            this.xEditGridCell717.IsVisible = false;
            this.xEditGridCell717.Row = -1;
            // 
            // xEditGridCell718
            // 
            this.xEditGridCell718.CellLen = 100;
            this.xEditGridCell718.CellName = "wonnae_drg_yn";
            this.xEditGridCell718.Col = -1;
            this.xEditGridCell718.IsVisible = false;
            this.xEditGridCell718.Row = -1;
            // 
            // xEditGridCell719
            // 
            this.xEditGridCell719.CellLen = 100;
            this.xEditGridCell719.CellName = "dv_5";
            this.xEditGridCell719.Col = -1;
            this.xEditGridCell719.IsVisible = false;
            this.xEditGridCell719.Row = -1;
            // 
            // xEditGridCell720
            // 
            this.xEditGridCell720.CellLen = 100;
            this.xEditGridCell720.CellName = "dv_6";
            this.xEditGridCell720.Col = -1;
            this.xEditGridCell720.IsVisible = false;
            this.xEditGridCell720.Row = -1;
            // 
            // xEditGridCell721
            // 
            this.xEditGridCell721.CellLen = 100;
            this.xEditGridCell721.CellName = "dv_7";
            this.xEditGridCell721.Col = -1;
            this.xEditGridCell721.IsVisible = false;
            this.xEditGridCell721.Row = -1;
            // 
            // xEditGridCell722
            // 
            this.xEditGridCell722.CellLen = 100;
            this.xEditGridCell722.CellName = "dv_8";
            this.xEditGridCell722.Col = -1;
            this.xEditGridCell722.IsVisible = false;
            this.xEditGridCell722.Row = -1;
            // 
            // xEditGridCell723
            // 
            this.xEditGridCell723.CellLen = 100;
            this.xEditGridCell723.CellName = "general_disp_yn";
            this.xEditGridCell723.Col = -1;
            this.xEditGridCell723.IsVisible = false;
            this.xEditGridCell723.Row = -1;
            // 
            // xEditGridCell724
            // 
            this.xEditGridCell724.CellLen = 100;
            this.xEditGridCell724.CellName = "generic_name";
            this.xEditGridCell724.Col = -1;
            this.xEditGridCell724.IsVisible = false;
            this.xEditGridCell724.Row = -1;
            // 
            // xEditGridCell725
            // 
            this.xEditGridCell725.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell725.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell725.CellLen = 1;
            this.xEditGridCell725.CellName = "select";
            this.xEditGridCell725.CellWidth = 27;
            this.xEditGridCell725.HeaderText = "選択";
            this.xEditGridCell725.IsReadOnly = true;
            this.xEditGridCell725.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell725.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell725.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // grdOCS0323_8
            // 
            this.grdOCS0323_8.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell726,
            this.xEditGridCell727,
            this.xEditGridCell728,
            this.xEditGridCell729,
            this.xEditGridCell730,
            this.xEditGridCell731,
            this.xEditGridCell732,
            this.xEditGridCell733,
            this.xEditGridCell734,
            this.xEditGridCell735,
            this.xEditGridCell736,
            this.xEditGridCell737,
            this.xEditGridCell738,
            this.xEditGridCell739,
            this.xEditGridCell740,
            this.xEditGridCell741,
            this.xEditGridCell742,
            this.xEditGridCell743,
            this.xEditGridCell744,
            this.xEditGridCell745,
            this.xEditGridCell746,
            this.xEditGridCell747,
            this.xEditGridCell748,
            this.xEditGridCell749,
            this.xEditGridCell750,
            this.xEditGridCell751,
            this.xEditGridCell752,
            this.xEditGridCell753,
            this.xEditGridCell754,
            this.xEditGridCell755,
            this.xEditGridCell756,
            this.xEditGridCell757,
            this.xEditGridCell758,
            this.xEditGridCell759,
            this.xEditGridCell760,
            this.xEditGridCell761,
            this.xEditGridCell762,
            this.xEditGridCell763,
            this.xEditGridCell764,
            this.xEditGridCell765,
            this.xEditGridCell766,
            this.xEditGridCell767,
            this.xEditGridCell768,
            this.xEditGridCell769,
            this.xEditGridCell770,
            this.xEditGridCell771,
            this.xEditGridCell772,
            this.xEditGridCell773,
            this.xEditGridCell774,
            this.xEditGridCell775,
            this.xEditGridCell776,
            this.xEditGridCell777,
            this.xEditGridCell778,
            this.xEditGridCell779,
            this.xEditGridCell780,
            this.xEditGridCell781,
            this.xEditGridCell782,
            this.xEditGridCell783,
            this.xEditGridCell784,
            this.xEditGridCell785,
            this.xEditGridCell786,
            this.xEditGridCell787,
            this.xEditGridCell788,
            this.xEditGridCell789,
            this.xEditGridCell790,
            this.xEditGridCell791,
            this.xEditGridCell792,
            this.xEditGridCell793,
            this.xEditGridCell794,
            this.xEditGridCell795,
            this.xEditGridCell796,
            this.xEditGridCell797,
            this.xEditGridCell798,
            this.xEditGridCell799,
            this.xEditGridCell800,
            this.xEditGridCell801,
            this.xEditGridCell802,
            this.xEditGridCell803,
            this.xEditGridCell804,
            this.xEditGridCell805,
            this.xEditGridCell806,
            this.xEditGridCell807,
            this.xEditGridCell808,
            this.xEditGridCell809,
            this.xEditGridCell810,
            this.xEditGridCell811,
            this.xEditGridCell812,
            this.xEditGridCell813,
            this.xEditGridCell909});
            this.grdOCS0323_8.ColPerLine = 2;
            this.grdOCS0323_8.Cols = 2;
            this.grdOCS0323_8.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdOCS0323_8.FixedRows = 1;
            this.grdOCS0323_8.HeaderHeights.Add(21);
            this.grdOCS0323_8.Location = new System.Drawing.Point(1022, 0);
            this.grdOCS0323_8.Name = "grdOCS0323_8";
            this.grdOCS0323_8.Rows = 2;
            this.grdOCS0323_8.RowStateCheckOnPaint = false;
            this.grdOCS0323_8.Size = new System.Drawing.Size(146, 639);
            this.grdOCS0323_8.TabIndex = 53;
            this.grdOCS0323_8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0323_all_MouseDown);
            // 
            // xEditGridCell726
            // 
            this.xEditGridCell726.CellLen = 100;
            this.xEditGridCell726.CellName = "memb";
            this.xEditGridCell726.Col = -1;
            this.xEditGridCell726.IsVisible = false;
            this.xEditGridCell726.Row = -1;
            // 
            // xEditGridCell727
            // 
            this.xEditGridCell727.CellLen = 100;
            this.xEditGridCell727.CellName = "fkocs0321";
            this.xEditGridCell727.Col = -1;
            this.xEditGridCell727.IsVisible = false;
            this.xEditGridCell727.Row = -1;
            // 
            // xEditGridCell728
            // 
            this.xEditGridCell728.CellLen = 100;
            this.xEditGridCell728.CellName = "pk_yaksok";
            this.xEditGridCell728.Col = -1;
            this.xEditGridCell728.IsVisible = false;
            this.xEditGridCell728.Row = -1;
            // 
            // xEditGridCell729
            // 
            this.xEditGridCell729.CellLen = 100;
            this.xEditGridCell729.CellName = "pkocs0323";
            this.xEditGridCell729.Col = -1;
            this.xEditGridCell729.IsVisible = false;
            this.xEditGridCell729.Row = -1;
            // 
            // xEditGridCell730
            // 
            this.xEditGridCell730.CellLen = 100;
            this.xEditGridCell730.CellName = "group_ser";
            this.xEditGridCell730.Col = -1;
            this.xEditGridCell730.IsVisible = false;
            this.xEditGridCell730.Row = -1;
            // 
            // xEditGridCell731
            // 
            this.xEditGridCell731.CellLen = 100;
            this.xEditGridCell731.CellName = "mix_group";
            this.xEditGridCell731.Col = -1;
            this.xEditGridCell731.IsVisible = false;
            this.xEditGridCell731.Row = -1;
            // 
            // xEditGridCell732
            // 
            this.xEditGridCell732.CellLen = 100;
            this.xEditGridCell732.CellName = "seq";
            this.xEditGridCell732.Col = -1;
            this.xEditGridCell732.IsVisible = false;
            this.xEditGridCell732.Row = -1;
            // 
            // xEditGridCell733
            // 
            this.xEditGridCell733.CellLen = 100;
            this.xEditGridCell733.CellName = "order_gubun";
            this.xEditGridCell733.Col = -1;
            this.xEditGridCell733.IsVisible = false;
            this.xEditGridCell733.Row = -1;
            // 
            // xEditGridCell734
            // 
            this.xEditGridCell734.CellLen = 100;
            this.xEditGridCell734.CellName = "order_gubun_name";
            this.xEditGridCell734.Col = -1;
            this.xEditGridCell734.IsVisible = false;
            this.xEditGridCell734.Row = -1;
            // 
            // xEditGridCell735
            // 
            this.xEditGridCell735.CellLen = 100;
            this.xEditGridCell735.CellName = "input_tab";
            this.xEditGridCell735.Col = -1;
            this.xEditGridCell735.IsVisible = false;
            this.xEditGridCell735.Row = -1;
            // 
            // xEditGridCell736
            // 
            this.xEditGridCell736.CellLen = 100;
            this.xEditGridCell736.CellName = "hangmog_code";
            this.xEditGridCell736.Col = -1;
            this.xEditGridCell736.IsVisible = false;
            this.xEditGridCell736.Row = -1;
            // 
            // xEditGridCell737
            // 
            this.xEditGridCell737.CellLen = 100;
            this.xEditGridCell737.CellName = "hangmog_name";
            this.xEditGridCell737.CellWidth = 115;
            this.xEditGridCell737.Col = 1;
            this.xEditGridCell737.HeaderText = "オーダ名";
            this.xEditGridCell737.IsReadOnly = true;
            // 
            // xEditGridCell738
            // 
            this.xEditGridCell738.CellLen = 100;
            this.xEditGridCell738.CellName = "specimen_code";
            this.xEditGridCell738.Col = -1;
            this.xEditGridCell738.IsVisible = false;
            this.xEditGridCell738.Row = -1;
            // 
            // xEditGridCell739
            // 
            this.xEditGridCell739.CellLen = 100;
            this.xEditGridCell739.CellName = "specimen_name";
            this.xEditGridCell739.Col = -1;
            this.xEditGridCell739.IsVisible = false;
            this.xEditGridCell739.Row = -1;
            // 
            // xEditGridCell740
            // 
            this.xEditGridCell740.CellLen = 100;
            this.xEditGridCell740.CellName = "suryang";
            this.xEditGridCell740.Col = -1;
            this.xEditGridCell740.IsVisible = false;
            this.xEditGridCell740.Row = -1;
            // 
            // xEditGridCell741
            // 
            this.xEditGridCell741.CellLen = 100;
            this.xEditGridCell741.CellName = "ord_danui";
            this.xEditGridCell741.Col = -1;
            this.xEditGridCell741.IsVisible = false;
            this.xEditGridCell741.Row = -1;
            // 
            // xEditGridCell742
            // 
            this.xEditGridCell742.CellLen = 100;
            this.xEditGridCell742.CellName = "order_danui_name";
            this.xEditGridCell742.Col = -1;
            this.xEditGridCell742.IsVisible = false;
            this.xEditGridCell742.Row = -1;
            // 
            // xEditGridCell743
            // 
            this.xEditGridCell743.CellLen = 100;
            this.xEditGridCell743.CellName = "dv_time";
            this.xEditGridCell743.Col = -1;
            this.xEditGridCell743.IsVisible = false;
            this.xEditGridCell743.Row = -1;
            // 
            // xEditGridCell744
            // 
            this.xEditGridCell744.CellLen = 100;
            this.xEditGridCell744.CellName = "dv";
            this.xEditGridCell744.Col = -1;
            this.xEditGridCell744.IsVisible = false;
            this.xEditGridCell744.Row = -1;
            // 
            // xEditGridCell745
            // 
            this.xEditGridCell745.CellLen = 100;
            this.xEditGridCell745.CellName = "dv_1";
            this.xEditGridCell745.Col = -1;
            this.xEditGridCell745.IsVisible = false;
            this.xEditGridCell745.Row = -1;
            // 
            // xEditGridCell746
            // 
            this.xEditGridCell746.CellLen = 100;
            this.xEditGridCell746.CellName = "dv_2";
            this.xEditGridCell746.Col = -1;
            this.xEditGridCell746.IsVisible = false;
            this.xEditGridCell746.Row = -1;
            // 
            // xEditGridCell747
            // 
            this.xEditGridCell747.CellLen = 100;
            this.xEditGridCell747.CellName = "dv_3";
            this.xEditGridCell747.Col = -1;
            this.xEditGridCell747.IsVisible = false;
            this.xEditGridCell747.Row = -1;
            // 
            // xEditGridCell748
            // 
            this.xEditGridCell748.CellLen = 100;
            this.xEditGridCell748.CellName = "dv_4";
            this.xEditGridCell748.Col = -1;
            this.xEditGridCell748.IsVisible = false;
            this.xEditGridCell748.Row = -1;
            // 
            // xEditGridCell749
            // 
            this.xEditGridCell749.CellLen = 100;
            this.xEditGridCell749.CellName = "nalsu";
            this.xEditGridCell749.Col = -1;
            this.xEditGridCell749.IsVisible = false;
            this.xEditGridCell749.Row = -1;
            // 
            // xEditGridCell750
            // 
            this.xEditGridCell750.CellLen = 100;
            this.xEditGridCell750.CellName = "jusa";
            this.xEditGridCell750.Col = -1;
            this.xEditGridCell750.IsVisible = false;
            this.xEditGridCell750.Row = -1;
            // 
            // xEditGridCell751
            // 
            this.xEditGridCell751.CellLen = 100;
            this.xEditGridCell751.CellName = "jusa_name";
            this.xEditGridCell751.Col = -1;
            this.xEditGridCell751.IsVisible = false;
            this.xEditGridCell751.Row = -1;
            // 
            // xEditGridCell752
            // 
            this.xEditGridCell752.CellLen = 100;
            this.xEditGridCell752.CellName = "bogyong_code";
            this.xEditGridCell752.Col = -1;
            this.xEditGridCell752.IsVisible = false;
            this.xEditGridCell752.Row = -1;
            // 
            // xEditGridCell753
            // 
            this.xEditGridCell753.CellLen = 100;
            this.xEditGridCell753.CellName = "bogyong_name";
            this.xEditGridCell753.Col = -1;
            this.xEditGridCell753.IsVisible = false;
            this.xEditGridCell753.Row = -1;
            // 
            // xEditGridCell754
            // 
            this.xEditGridCell754.CellLen = 100;
            this.xEditGridCell754.CellName = "jusa_spd_gubun";
            this.xEditGridCell754.Col = -1;
            this.xEditGridCell754.IsVisible = false;
            this.xEditGridCell754.Row = -1;
            // 
            // xEditGridCell755
            // 
            this.xEditGridCell755.CellLen = 100;
            this.xEditGridCell755.CellName = "hubal_change_yn";
            this.xEditGridCell755.Col = -1;
            this.xEditGridCell755.IsVisible = false;
            this.xEditGridCell755.Row = -1;
            // 
            // xEditGridCell756
            // 
            this.xEditGridCell756.CellLen = 100;
            this.xEditGridCell756.CellName = "pharmacy";
            this.xEditGridCell756.Col = -1;
            this.xEditGridCell756.IsVisible = false;
            this.xEditGridCell756.Row = -1;
            // 
            // xEditGridCell757
            // 
            this.xEditGridCell757.CellLen = 100;
            this.xEditGridCell757.CellName = "drg_pack_yn";
            this.xEditGridCell757.Col = -1;
            this.xEditGridCell757.IsVisible = false;
            this.xEditGridCell757.Row = -1;
            // 
            // xEditGridCell758
            // 
            this.xEditGridCell758.CellLen = 100;
            this.xEditGridCell758.CellName = "emergency";
            this.xEditGridCell758.Col = -1;
            this.xEditGridCell758.IsVisible = false;
            this.xEditGridCell758.Row = -1;
            // 
            // xEditGridCell759
            // 
            this.xEditGridCell759.CellLen = 100;
            this.xEditGridCell759.CellName = "pay";
            this.xEditGridCell759.Col = -1;
            this.xEditGridCell759.IsVisible = false;
            this.xEditGridCell759.Row = -1;
            // 
            // xEditGridCell760
            // 
            this.xEditGridCell760.CellLen = 100;
            this.xEditGridCell760.CellName = "portable_yn";
            this.xEditGridCell760.Col = -1;
            this.xEditGridCell760.IsVisible = false;
            this.xEditGridCell760.Row = -1;
            // 
            // xEditGridCell761
            // 
            this.xEditGridCell761.CellLen = 100;
            this.xEditGridCell761.CellName = "powder_yn";
            this.xEditGridCell761.Col = -1;
            this.xEditGridCell761.IsVisible = false;
            this.xEditGridCell761.Row = -1;
            // 
            // xEditGridCell762
            // 
            this.xEditGridCell762.CellLen = 100;
            this.xEditGridCell762.CellName = "muhyo";
            this.xEditGridCell762.Col = -1;
            this.xEditGridCell762.IsVisible = false;
            this.xEditGridCell762.Row = -1;
            // 
            // xEditGridCell763
            // 
            this.xEditGridCell763.CellLen = 100;
            this.xEditGridCell763.CellName = "prn_yn";
            this.xEditGridCell763.Col = -1;
            this.xEditGridCell763.IsVisible = false;
            this.xEditGridCell763.Row = -1;
            // 
            // xEditGridCell764
            // 
            this.xEditGridCell764.CellLen = 100;
            this.xEditGridCell764.CellName = "order_remark";
            this.xEditGridCell764.Col = -1;
            this.xEditGridCell764.IsVisible = false;
            this.xEditGridCell764.Row = -1;
            // 
            // xEditGridCell765
            // 
            this.xEditGridCell765.CellLen = 100;
            this.xEditGridCell765.CellName = "nurse_remark";
            this.xEditGridCell765.Col = -1;
            this.xEditGridCell765.IsVisible = false;
            this.xEditGridCell765.Row = -1;
            // 
            // xEditGridCell766
            // 
            this.xEditGridCell766.CellLen = 100;
            this.xEditGridCell766.CellName = "bulyong_check";
            this.xEditGridCell766.Col = -1;
            this.xEditGridCell766.IsVisible = false;
            this.xEditGridCell766.Row = -1;
            // 
            // xEditGridCell767
            // 
            this.xEditGridCell767.CellLen = 100;
            this.xEditGridCell767.CellName = "slip_code";
            this.xEditGridCell767.Col = -1;
            this.xEditGridCell767.IsVisible = false;
            this.xEditGridCell767.Row = -1;
            // 
            // xEditGridCell768
            // 
            this.xEditGridCell768.CellLen = 100;
            this.xEditGridCell768.CellName = "group_yn";
            this.xEditGridCell768.Col = -1;
            this.xEditGridCell768.IsVisible = false;
            this.xEditGridCell768.Row = -1;
            // 
            // xEditGridCell769
            // 
            this.xEditGridCell769.CellLen = 100;
            this.xEditGridCell769.CellName = "order_gubun_bas";
            this.xEditGridCell769.Col = -1;
            this.xEditGridCell769.IsVisible = false;
            this.xEditGridCell769.Row = -1;
            // 
            // xEditGridCell770
            // 
            this.xEditGridCell770.CellLen = 100;
            this.xEditGridCell770.CellName = "input_control";
            this.xEditGridCell770.Col = -1;
            this.xEditGridCell770.IsVisible = false;
            this.xEditGridCell770.Row = -1;
            // 
            // xEditGridCell771
            // 
            this.xEditGridCell771.CellLen = 100;
            this.xEditGridCell771.CellName = "sg_code";
            this.xEditGridCell771.Col = -1;
            this.xEditGridCell771.IsVisible = false;
            this.xEditGridCell771.Row = -1;
            // 
            // xEditGridCell772
            // 
            this.xEditGridCell772.CellLen = 100;
            this.xEditGridCell772.CellName = "suga_yn";
            this.xEditGridCell772.Col = -1;
            this.xEditGridCell772.IsVisible = false;
            this.xEditGridCell772.Row = -1;
            // 
            // xEditGridCell773
            // 
            this.xEditGridCell773.CellLen = 100;
            this.xEditGridCell773.CellName = "emergency_check";
            this.xEditGridCell773.Col = -1;
            this.xEditGridCell773.IsVisible = false;
            this.xEditGridCell773.Row = -1;
            // 
            // xEditGridCell774
            // 
            this.xEditGridCell774.CellLen = 100;
            this.xEditGridCell774.CellName = "limit_suryang";
            this.xEditGridCell774.Col = -1;
            this.xEditGridCell774.IsVisible = false;
            this.xEditGridCell774.Row = -1;
            // 
            // xEditGridCell775
            // 
            this.xEditGridCell775.CellLen = 100;
            this.xEditGridCell775.CellName = "specimen_yn";
            this.xEditGridCell775.Col = -1;
            this.xEditGridCell775.IsVisible = false;
            this.xEditGridCell775.Row = -1;
            // 
            // xEditGridCell776
            // 
            this.xEditGridCell776.CellLen = 100;
            this.xEditGridCell776.CellName = "jaeryo_yn";
            this.xEditGridCell776.Col = -1;
            this.xEditGridCell776.IsVisible = false;
            this.xEditGridCell776.Row = -1;
            // 
            // xEditGridCell777
            // 
            this.xEditGridCell777.CellLen = 100;
            this.xEditGridCell777.CellName = "ord_danui_check";
            this.xEditGridCell777.Col = -1;
            this.xEditGridCell777.IsVisible = false;
            this.xEditGridCell777.Row = -1;
            // 
            // xEditGridCell778
            // 
            this.xEditGridCell778.CellLen = 100;
            this.xEditGridCell778.CellName = "wonyoi_order_yn";
            this.xEditGridCell778.Col = -1;
            this.xEditGridCell778.IsVisible = false;
            this.xEditGridCell778.Row = -1;
            // 
            // xEditGridCell779
            // 
            this.xEditGridCell779.CellLen = 100;
            this.xEditGridCell779.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell779.Col = -1;
            this.xEditGridCell779.IsVisible = false;
            this.xEditGridCell779.Row = -1;
            // 
            // xEditGridCell780
            // 
            this.xEditGridCell780.CellLen = 100;
            this.xEditGridCell780.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell780.Col = -1;
            this.xEditGridCell780.IsVisible = false;
            this.xEditGridCell780.Row = -1;
            // 
            // xEditGridCell781
            // 
            this.xEditGridCell781.CellLen = 100;
            this.xEditGridCell781.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell781.Col = -1;
            this.xEditGridCell781.IsVisible = false;
            this.xEditGridCell781.Row = -1;
            // 
            // xEditGridCell782
            // 
            this.xEditGridCell782.CellLen = 100;
            this.xEditGridCell782.CellName = "nday_yn";
            this.xEditGridCell782.Col = -1;
            this.xEditGridCell782.IsVisible = false;
            this.xEditGridCell782.Row = -1;
            // 
            // xEditGridCell783
            // 
            this.xEditGridCell783.CellLen = 100;
            this.xEditGridCell783.CellName = "muhyo_yn";
            this.xEditGridCell783.Col = -1;
            this.xEditGridCell783.IsVisible = false;
            this.xEditGridCell783.Row = -1;
            // 
            // xEditGridCell784
            // 
            this.xEditGridCell784.CellLen = 100;
            this.xEditGridCell784.CellName = "pay_name";
            this.xEditGridCell784.Col = -1;
            this.xEditGridCell784.IsVisible = false;
            this.xEditGridCell784.Row = -1;
            // 
            // xEditGridCell785
            // 
            this.xEditGridCell785.CellLen = 100;
            this.xEditGridCell785.CellName = "bun_code";
            this.xEditGridCell785.Col = -1;
            this.xEditGridCell785.IsVisible = false;
            this.xEditGridCell785.Row = -1;
            // 
            // xEditGridCell786
            // 
            this.xEditGridCell786.CellLen = 100;
            this.xEditGridCell786.CellName = "data_control";
            this.xEditGridCell786.Col = -1;
            this.xEditGridCell786.IsVisible = false;
            this.xEditGridCell786.Row = -1;
            // 
            // xEditGridCell787
            // 
            this.xEditGridCell787.CellLen = 100;
            this.xEditGridCell787.CellName = "donbog_yn";
            this.xEditGridCell787.Col = -1;
            this.xEditGridCell787.IsVisible = false;
            this.xEditGridCell787.Row = -1;
            // 
            // xEditGridCell788
            // 
            this.xEditGridCell788.CellLen = 100;
            this.xEditGridCell788.CellName = "dv_name";
            this.xEditGridCell788.Col = -1;
            this.xEditGridCell788.IsVisible = false;
            this.xEditGridCell788.Row = -1;
            // 
            // xEditGridCell789
            // 
            this.xEditGridCell789.CellLen = 100;
            this.xEditGridCell789.CellName = "drg_info";
            this.xEditGridCell789.Col = -1;
            this.xEditGridCell789.IsVisible = false;
            this.xEditGridCell789.Row = -1;
            // 
            // xEditGridCell790
            // 
            this.xEditGridCell790.CellLen = 100;
            this.xEditGridCell790.CellName = "drg_bunryu";
            this.xEditGridCell790.Col = -1;
            this.xEditGridCell790.IsVisible = false;
            this.xEditGridCell790.Row = -1;
            // 
            // xEditGridCell791
            // 
            this.xEditGridCell791.CellLen = 100;
            this.xEditGridCell791.CellName = "child_gubun";
            this.xEditGridCell791.Col = -1;
            this.xEditGridCell791.IsVisible = false;
            this.xEditGridCell791.Row = -1;
            // 
            // xEditGridCell792
            // 
            this.xEditGridCell792.CellLen = 100;
            this.xEditGridCell792.CellName = "bom_source_key";
            this.xEditGridCell792.Col = -1;
            this.xEditGridCell792.IsVisible = false;
            this.xEditGridCell792.Row = -1;
            // 
            // xEditGridCell793
            // 
            this.xEditGridCell793.CellLen = 100;
            this.xEditGridCell793.CellName = "haengwee_yn";
            this.xEditGridCell793.Col = -1;
            this.xEditGridCell793.IsVisible = false;
            this.xEditGridCell793.Row = -1;
            // 
            // xEditGridCell794
            // 
            this.xEditGridCell794.CellLen = 100;
            this.xEditGridCell794.CellName = "org_key";
            this.xEditGridCell794.Col = -1;
            this.xEditGridCell794.IsVisible = false;
            this.xEditGridCell794.Row = -1;
            // 
            // xEditGridCell795
            // 
            this.xEditGridCell795.CellLen = 100;
            this.xEditGridCell795.CellName = "parent_key";
            this.xEditGridCell795.Col = -1;
            this.xEditGridCell795.IsVisible = false;
            this.xEditGridCell795.Row = -1;
            // 
            // xEditGridCell796
            // 
            this.xEditGridCell796.CellLen = 100;
            this.xEditGridCell796.CellName = "fkocs0300_seq";
            this.xEditGridCell796.Col = -1;
            this.xEditGridCell796.IsVisible = false;
            this.xEditGridCell796.Row = -1;
            // 
            // xEditGridCell797
            // 
            this.xEditGridCell797.CellLen = 100;
            this.xEditGridCell797.CellName = "child_yn";
            this.xEditGridCell797.Col = -1;
            this.xEditGridCell797.IsVisible = false;
            this.xEditGridCell797.Row = -1;
            // 
            // xEditGridCell798
            // 
            this.xEditGridCell798.CellLen = 100;
            this.xEditGridCell798.CellName = "jundal_table_out";
            this.xEditGridCell798.Col = -1;
            this.xEditGridCell798.IsVisible = false;
            this.xEditGridCell798.Row = -1;
            // 
            // xEditGridCell799
            // 
            this.xEditGridCell799.CellLen = 100;
            this.xEditGridCell799.CellName = "jundal_part_out";
            this.xEditGridCell799.Col = -1;
            this.xEditGridCell799.IsVisible = false;
            this.xEditGridCell799.Row = -1;
            // 
            // xEditGridCell800
            // 
            this.xEditGridCell800.CellLen = 100;
            this.xEditGridCell800.CellName = "jundal_table_inp";
            this.xEditGridCell800.Col = -1;
            this.xEditGridCell800.IsVisible = false;
            this.xEditGridCell800.Row = -1;
            // 
            // xEditGridCell801
            // 
            this.xEditGridCell801.CellLen = 100;
            this.xEditGridCell801.CellName = "jundal_part_inp";
            this.xEditGridCell801.Col = -1;
            this.xEditGridCell801.IsVisible = false;
            this.xEditGridCell801.Row = -1;
            // 
            // xEditGridCell802
            // 
            this.xEditGridCell802.CellLen = 100;
            this.xEditGridCell802.CellName = "move_part_out";
            this.xEditGridCell802.Col = -1;
            this.xEditGridCell802.IsVisible = false;
            this.xEditGridCell802.Row = -1;
            // 
            // xEditGridCell803
            // 
            this.xEditGridCell803.CellLen = 100;
            this.xEditGridCell803.CellName = "move_part_inp";
            this.xEditGridCell803.Col = -1;
            this.xEditGridCell803.IsVisible = false;
            this.xEditGridCell803.Row = -1;
            // 
            // xEditGridCell804
            // 
            this.xEditGridCell804.CellLen = 100;
            this.xEditGridCell804.CellName = "jundal_part_out_name";
            this.xEditGridCell804.Col = -1;
            this.xEditGridCell804.IsVisible = false;
            this.xEditGridCell804.Row = -1;
            // 
            // xEditGridCell805
            // 
            this.xEditGridCell805.CellLen = 100;
            this.xEditGridCell805.CellName = "jundal_part_inp_name";
            this.xEditGridCell805.Col = -1;
            this.xEditGridCell805.IsVisible = false;
            this.xEditGridCell805.Row = -1;
            // 
            // xEditGridCell806
            // 
            this.xEditGridCell806.CellLen = 100;
            this.xEditGridCell806.CellName = "wonnae_drg_yn";
            this.xEditGridCell806.Col = -1;
            this.xEditGridCell806.IsVisible = false;
            this.xEditGridCell806.Row = -1;
            // 
            // xEditGridCell807
            // 
            this.xEditGridCell807.CellLen = 100;
            this.xEditGridCell807.CellName = "dv_5";
            this.xEditGridCell807.Col = -1;
            this.xEditGridCell807.IsVisible = false;
            this.xEditGridCell807.Row = -1;
            // 
            // xEditGridCell808
            // 
            this.xEditGridCell808.CellLen = 100;
            this.xEditGridCell808.CellName = "dv_6";
            this.xEditGridCell808.Col = -1;
            this.xEditGridCell808.IsVisible = false;
            this.xEditGridCell808.Row = -1;
            // 
            // xEditGridCell809
            // 
            this.xEditGridCell809.CellLen = 100;
            this.xEditGridCell809.CellName = "dv_7";
            this.xEditGridCell809.Col = -1;
            this.xEditGridCell809.IsVisible = false;
            this.xEditGridCell809.Row = -1;
            // 
            // xEditGridCell810
            // 
            this.xEditGridCell810.CellLen = 100;
            this.xEditGridCell810.CellName = "dv_8";
            this.xEditGridCell810.Col = -1;
            this.xEditGridCell810.IsVisible = false;
            this.xEditGridCell810.Row = -1;
            // 
            // xEditGridCell811
            // 
            this.xEditGridCell811.CellLen = 100;
            this.xEditGridCell811.CellName = "general_disp_yn";
            this.xEditGridCell811.Col = -1;
            this.xEditGridCell811.IsVisible = false;
            this.xEditGridCell811.Row = -1;
            // 
            // xEditGridCell812
            // 
            this.xEditGridCell812.CellLen = 100;
            this.xEditGridCell812.CellName = "generic_name";
            this.xEditGridCell812.Col = -1;
            this.xEditGridCell812.IsVisible = false;
            this.xEditGridCell812.Row = -1;
            // 
            // xEditGridCell813
            // 
            this.xEditGridCell813.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell813.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell813.CellLen = 1;
            this.xEditGridCell813.CellName = "select";
            this.xEditGridCell813.CellWidth = 27;
            this.xEditGridCell813.HeaderText = "選択";
            this.xEditGridCell813.IsReadOnly = true;
            this.xEditGridCell813.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell813.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell813.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // grdOCS0323_9
            // 
            this.grdOCS0323_9.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell814,
            this.xEditGridCell815,
            this.xEditGridCell816,
            this.xEditGridCell817,
            this.xEditGridCell818,
            this.xEditGridCell819,
            this.xEditGridCell820,
            this.xEditGridCell821,
            this.xEditGridCell822,
            this.xEditGridCell823,
            this.xEditGridCell824,
            this.xEditGridCell825,
            this.xEditGridCell826,
            this.xEditGridCell827,
            this.xEditGridCell828,
            this.xEditGridCell829,
            this.xEditGridCell830,
            this.xEditGridCell831,
            this.xEditGridCell832,
            this.xEditGridCell833,
            this.xEditGridCell834,
            this.xEditGridCell835,
            this.xEditGridCell836,
            this.xEditGridCell837,
            this.xEditGridCell838,
            this.xEditGridCell839,
            this.xEditGridCell840,
            this.xEditGridCell841,
            this.xEditGridCell842,
            this.xEditGridCell843,
            this.xEditGridCell844,
            this.xEditGridCell845,
            this.xEditGridCell846,
            this.xEditGridCell847,
            this.xEditGridCell848,
            this.xEditGridCell849,
            this.xEditGridCell850,
            this.xEditGridCell851,
            this.xEditGridCell852,
            this.xEditGridCell853,
            this.xEditGridCell854,
            this.xEditGridCell855,
            this.xEditGridCell856,
            this.xEditGridCell857,
            this.xEditGridCell858,
            this.xEditGridCell859,
            this.xEditGridCell860,
            this.xEditGridCell861,
            this.xEditGridCell862,
            this.xEditGridCell863,
            this.xEditGridCell864,
            this.xEditGridCell865,
            this.xEditGridCell866,
            this.xEditGridCell867,
            this.xEditGridCell868,
            this.xEditGridCell869,
            this.xEditGridCell870,
            this.xEditGridCell871,
            this.xEditGridCell872,
            this.xEditGridCell873,
            this.xEditGridCell874,
            this.xEditGridCell875,
            this.xEditGridCell876,
            this.xEditGridCell877,
            this.xEditGridCell878,
            this.xEditGridCell879,
            this.xEditGridCell880,
            this.xEditGridCell881,
            this.xEditGridCell882,
            this.xEditGridCell883,
            this.xEditGridCell884,
            this.xEditGridCell885,
            this.xEditGridCell886,
            this.xEditGridCell887,
            this.xEditGridCell888,
            this.xEditGridCell889,
            this.xEditGridCell890,
            this.xEditGridCell891,
            this.xEditGridCell892,
            this.xEditGridCell893,
            this.xEditGridCell894,
            this.xEditGridCell895,
            this.xEditGridCell896,
            this.xEditGridCell897,
            this.xEditGridCell898,
            this.xEditGridCell899,
            this.xEditGridCell900,
            this.xEditGridCell901,
            this.xEditGridCell910});
            this.grdOCS0323_9.ColPerLine = 2;
            this.grdOCS0323_9.Cols = 2;
            this.grdOCS0323_9.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdOCS0323_9.FixedRows = 1;
            this.grdOCS0323_9.HeaderHeights.Add(21);
            this.grdOCS0323_9.Location = new System.Drawing.Point(1168, 0);
            this.grdOCS0323_9.Name = "grdOCS0323_9";
            this.grdOCS0323_9.Rows = 2;
            this.grdOCS0323_9.RowStateCheckOnPaint = false;
            this.grdOCS0323_9.Size = new System.Drawing.Size(146, 639);
            this.grdOCS0323_9.TabIndex = 54;
            this.grdOCS0323_9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0323_all_MouseDown);
            // 
            // xEditGridCell814
            // 
            this.xEditGridCell814.CellLen = 100;
            this.xEditGridCell814.CellName = "memb";
            this.xEditGridCell814.Col = -1;
            this.xEditGridCell814.IsVisible = false;
            this.xEditGridCell814.Row = -1;
            // 
            // xEditGridCell815
            // 
            this.xEditGridCell815.CellLen = 100;
            this.xEditGridCell815.CellName = "fkocs0321";
            this.xEditGridCell815.Col = -1;
            this.xEditGridCell815.IsVisible = false;
            this.xEditGridCell815.Row = -1;
            // 
            // xEditGridCell816
            // 
            this.xEditGridCell816.CellLen = 100;
            this.xEditGridCell816.CellName = "pk_yaksok";
            this.xEditGridCell816.Col = -1;
            this.xEditGridCell816.IsVisible = false;
            this.xEditGridCell816.Row = -1;
            // 
            // xEditGridCell817
            // 
            this.xEditGridCell817.CellLen = 100;
            this.xEditGridCell817.CellName = "pkocs0323";
            this.xEditGridCell817.Col = -1;
            this.xEditGridCell817.IsVisible = false;
            this.xEditGridCell817.Row = -1;
            // 
            // xEditGridCell818
            // 
            this.xEditGridCell818.CellLen = 100;
            this.xEditGridCell818.CellName = "group_ser";
            this.xEditGridCell818.Col = -1;
            this.xEditGridCell818.IsVisible = false;
            this.xEditGridCell818.Row = -1;
            // 
            // xEditGridCell819
            // 
            this.xEditGridCell819.CellLen = 100;
            this.xEditGridCell819.CellName = "mix_group";
            this.xEditGridCell819.Col = -1;
            this.xEditGridCell819.IsVisible = false;
            this.xEditGridCell819.Row = -1;
            // 
            // xEditGridCell820
            // 
            this.xEditGridCell820.CellLen = 100;
            this.xEditGridCell820.CellName = "seq";
            this.xEditGridCell820.Col = -1;
            this.xEditGridCell820.IsVisible = false;
            this.xEditGridCell820.Row = -1;
            // 
            // xEditGridCell821
            // 
            this.xEditGridCell821.CellLen = 100;
            this.xEditGridCell821.CellName = "order_gubun";
            this.xEditGridCell821.Col = -1;
            this.xEditGridCell821.IsVisible = false;
            this.xEditGridCell821.Row = -1;
            // 
            // xEditGridCell822
            // 
            this.xEditGridCell822.CellLen = 100;
            this.xEditGridCell822.CellName = "order_gubun_name";
            this.xEditGridCell822.Col = -1;
            this.xEditGridCell822.IsVisible = false;
            this.xEditGridCell822.Row = -1;
            // 
            // xEditGridCell823
            // 
            this.xEditGridCell823.CellLen = 100;
            this.xEditGridCell823.CellName = "input_tab";
            this.xEditGridCell823.Col = -1;
            this.xEditGridCell823.IsVisible = false;
            this.xEditGridCell823.Row = -1;
            // 
            // xEditGridCell824
            // 
            this.xEditGridCell824.CellLen = 100;
            this.xEditGridCell824.CellName = "hangmog_code";
            this.xEditGridCell824.Col = -1;
            this.xEditGridCell824.IsVisible = false;
            this.xEditGridCell824.Row = -1;
            // 
            // xEditGridCell825
            // 
            this.xEditGridCell825.CellLen = 100;
            this.xEditGridCell825.CellName = "hangmog_name";
            this.xEditGridCell825.CellWidth = 115;
            this.xEditGridCell825.Col = 1;
            this.xEditGridCell825.HeaderText = "オーダ名";
            this.xEditGridCell825.IsReadOnly = true;
            // 
            // xEditGridCell826
            // 
            this.xEditGridCell826.CellLen = 100;
            this.xEditGridCell826.CellName = "specimen_code";
            this.xEditGridCell826.Col = -1;
            this.xEditGridCell826.IsVisible = false;
            this.xEditGridCell826.Row = -1;
            // 
            // xEditGridCell827
            // 
            this.xEditGridCell827.CellLen = 100;
            this.xEditGridCell827.CellName = "specimen_name";
            this.xEditGridCell827.Col = -1;
            this.xEditGridCell827.IsVisible = false;
            this.xEditGridCell827.Row = -1;
            // 
            // xEditGridCell828
            // 
            this.xEditGridCell828.CellLen = 100;
            this.xEditGridCell828.CellName = "suryang";
            this.xEditGridCell828.Col = -1;
            this.xEditGridCell828.IsVisible = false;
            this.xEditGridCell828.Row = -1;
            // 
            // xEditGridCell829
            // 
            this.xEditGridCell829.CellLen = 100;
            this.xEditGridCell829.CellName = "ord_danui";
            this.xEditGridCell829.Col = -1;
            this.xEditGridCell829.IsVisible = false;
            this.xEditGridCell829.Row = -1;
            // 
            // xEditGridCell830
            // 
            this.xEditGridCell830.CellLen = 100;
            this.xEditGridCell830.CellName = "order_danui_name";
            this.xEditGridCell830.Col = -1;
            this.xEditGridCell830.IsVisible = false;
            this.xEditGridCell830.Row = -1;
            // 
            // xEditGridCell831
            // 
            this.xEditGridCell831.CellLen = 100;
            this.xEditGridCell831.CellName = "dv_time";
            this.xEditGridCell831.Col = -1;
            this.xEditGridCell831.IsVisible = false;
            this.xEditGridCell831.Row = -1;
            // 
            // xEditGridCell832
            // 
            this.xEditGridCell832.CellLen = 100;
            this.xEditGridCell832.CellName = "dv";
            this.xEditGridCell832.Col = -1;
            this.xEditGridCell832.IsVisible = false;
            this.xEditGridCell832.Row = -1;
            // 
            // xEditGridCell833
            // 
            this.xEditGridCell833.CellLen = 100;
            this.xEditGridCell833.CellName = "dv_1";
            this.xEditGridCell833.Col = -1;
            this.xEditGridCell833.IsVisible = false;
            this.xEditGridCell833.Row = -1;
            // 
            // xEditGridCell834
            // 
            this.xEditGridCell834.CellLen = 100;
            this.xEditGridCell834.CellName = "dv_2";
            this.xEditGridCell834.Col = -1;
            this.xEditGridCell834.IsVisible = false;
            this.xEditGridCell834.Row = -1;
            // 
            // xEditGridCell835
            // 
            this.xEditGridCell835.CellLen = 100;
            this.xEditGridCell835.CellName = "dv_3";
            this.xEditGridCell835.Col = -1;
            this.xEditGridCell835.IsVisible = false;
            this.xEditGridCell835.Row = -1;
            // 
            // xEditGridCell836
            // 
            this.xEditGridCell836.CellLen = 100;
            this.xEditGridCell836.CellName = "dv_4";
            this.xEditGridCell836.Col = -1;
            this.xEditGridCell836.IsVisible = false;
            this.xEditGridCell836.Row = -1;
            // 
            // xEditGridCell837
            // 
            this.xEditGridCell837.CellLen = 100;
            this.xEditGridCell837.CellName = "nalsu";
            this.xEditGridCell837.Col = -1;
            this.xEditGridCell837.IsVisible = false;
            this.xEditGridCell837.Row = -1;
            // 
            // xEditGridCell838
            // 
            this.xEditGridCell838.CellLen = 100;
            this.xEditGridCell838.CellName = "jusa";
            this.xEditGridCell838.Col = -1;
            this.xEditGridCell838.IsVisible = false;
            this.xEditGridCell838.Row = -1;
            // 
            // xEditGridCell839
            // 
            this.xEditGridCell839.CellLen = 100;
            this.xEditGridCell839.CellName = "jusa_name";
            this.xEditGridCell839.Col = -1;
            this.xEditGridCell839.IsVisible = false;
            this.xEditGridCell839.Row = -1;
            // 
            // xEditGridCell840
            // 
            this.xEditGridCell840.CellLen = 100;
            this.xEditGridCell840.CellName = "bogyong_code";
            this.xEditGridCell840.Col = -1;
            this.xEditGridCell840.IsVisible = false;
            this.xEditGridCell840.Row = -1;
            // 
            // xEditGridCell841
            // 
            this.xEditGridCell841.CellLen = 100;
            this.xEditGridCell841.CellName = "bogyong_name";
            this.xEditGridCell841.Col = -1;
            this.xEditGridCell841.IsVisible = false;
            this.xEditGridCell841.Row = -1;
            // 
            // xEditGridCell842
            // 
            this.xEditGridCell842.CellLen = 100;
            this.xEditGridCell842.CellName = "jusa_spd_gubun";
            this.xEditGridCell842.Col = -1;
            this.xEditGridCell842.IsVisible = false;
            this.xEditGridCell842.Row = -1;
            // 
            // xEditGridCell843
            // 
            this.xEditGridCell843.CellLen = 100;
            this.xEditGridCell843.CellName = "hubal_change_yn";
            this.xEditGridCell843.Col = -1;
            this.xEditGridCell843.IsVisible = false;
            this.xEditGridCell843.Row = -1;
            // 
            // xEditGridCell844
            // 
            this.xEditGridCell844.CellLen = 100;
            this.xEditGridCell844.CellName = "pharmacy";
            this.xEditGridCell844.Col = -1;
            this.xEditGridCell844.IsVisible = false;
            this.xEditGridCell844.Row = -1;
            // 
            // xEditGridCell845
            // 
            this.xEditGridCell845.CellLen = 100;
            this.xEditGridCell845.CellName = "drg_pack_yn";
            this.xEditGridCell845.Col = -1;
            this.xEditGridCell845.IsVisible = false;
            this.xEditGridCell845.Row = -1;
            // 
            // xEditGridCell846
            // 
            this.xEditGridCell846.CellLen = 100;
            this.xEditGridCell846.CellName = "emergency";
            this.xEditGridCell846.Col = -1;
            this.xEditGridCell846.IsVisible = false;
            this.xEditGridCell846.Row = -1;
            // 
            // xEditGridCell847
            // 
            this.xEditGridCell847.CellLen = 100;
            this.xEditGridCell847.CellName = "pay";
            this.xEditGridCell847.Col = -1;
            this.xEditGridCell847.IsVisible = false;
            this.xEditGridCell847.Row = -1;
            // 
            // xEditGridCell848
            // 
            this.xEditGridCell848.CellLen = 100;
            this.xEditGridCell848.CellName = "portable_yn";
            this.xEditGridCell848.Col = -1;
            this.xEditGridCell848.IsVisible = false;
            this.xEditGridCell848.Row = -1;
            // 
            // xEditGridCell849
            // 
            this.xEditGridCell849.CellLen = 100;
            this.xEditGridCell849.CellName = "powder_yn";
            this.xEditGridCell849.Col = -1;
            this.xEditGridCell849.IsVisible = false;
            this.xEditGridCell849.Row = -1;
            // 
            // xEditGridCell850
            // 
            this.xEditGridCell850.CellLen = 100;
            this.xEditGridCell850.CellName = "muhyo";
            this.xEditGridCell850.Col = -1;
            this.xEditGridCell850.IsVisible = false;
            this.xEditGridCell850.Row = -1;
            // 
            // xEditGridCell851
            // 
            this.xEditGridCell851.CellLen = 100;
            this.xEditGridCell851.CellName = "prn_yn";
            this.xEditGridCell851.Col = -1;
            this.xEditGridCell851.IsVisible = false;
            this.xEditGridCell851.Row = -1;
            // 
            // xEditGridCell852
            // 
            this.xEditGridCell852.CellLen = 100;
            this.xEditGridCell852.CellName = "order_remark";
            this.xEditGridCell852.Col = -1;
            this.xEditGridCell852.IsVisible = false;
            this.xEditGridCell852.Row = -1;
            // 
            // xEditGridCell853
            // 
            this.xEditGridCell853.CellLen = 100;
            this.xEditGridCell853.CellName = "nurse_remark";
            this.xEditGridCell853.Col = -1;
            this.xEditGridCell853.IsVisible = false;
            this.xEditGridCell853.Row = -1;
            // 
            // xEditGridCell854
            // 
            this.xEditGridCell854.CellLen = 100;
            this.xEditGridCell854.CellName = "bulyong_check";
            this.xEditGridCell854.Col = -1;
            this.xEditGridCell854.IsVisible = false;
            this.xEditGridCell854.Row = -1;
            // 
            // xEditGridCell855
            // 
            this.xEditGridCell855.CellLen = 100;
            this.xEditGridCell855.CellName = "slip_code";
            this.xEditGridCell855.Col = -1;
            this.xEditGridCell855.IsVisible = false;
            this.xEditGridCell855.Row = -1;
            // 
            // xEditGridCell856
            // 
            this.xEditGridCell856.CellLen = 100;
            this.xEditGridCell856.CellName = "group_yn";
            this.xEditGridCell856.Col = -1;
            this.xEditGridCell856.IsVisible = false;
            this.xEditGridCell856.Row = -1;
            // 
            // xEditGridCell857
            // 
            this.xEditGridCell857.CellLen = 100;
            this.xEditGridCell857.CellName = "order_gubun_bas";
            this.xEditGridCell857.Col = -1;
            this.xEditGridCell857.IsVisible = false;
            this.xEditGridCell857.Row = -1;
            // 
            // xEditGridCell858
            // 
            this.xEditGridCell858.CellLen = 100;
            this.xEditGridCell858.CellName = "input_control";
            this.xEditGridCell858.Col = -1;
            this.xEditGridCell858.IsVisible = false;
            this.xEditGridCell858.Row = -1;
            // 
            // xEditGridCell859
            // 
            this.xEditGridCell859.CellLen = 100;
            this.xEditGridCell859.CellName = "sg_code";
            this.xEditGridCell859.Col = -1;
            this.xEditGridCell859.IsVisible = false;
            this.xEditGridCell859.Row = -1;
            // 
            // xEditGridCell860
            // 
            this.xEditGridCell860.CellLen = 100;
            this.xEditGridCell860.CellName = "suga_yn";
            this.xEditGridCell860.Col = -1;
            this.xEditGridCell860.IsVisible = false;
            this.xEditGridCell860.Row = -1;
            // 
            // xEditGridCell861
            // 
            this.xEditGridCell861.CellLen = 100;
            this.xEditGridCell861.CellName = "emergency_check";
            this.xEditGridCell861.Col = -1;
            this.xEditGridCell861.IsVisible = false;
            this.xEditGridCell861.Row = -1;
            // 
            // xEditGridCell862
            // 
            this.xEditGridCell862.CellLen = 100;
            this.xEditGridCell862.CellName = "limit_suryang";
            this.xEditGridCell862.Col = -1;
            this.xEditGridCell862.IsVisible = false;
            this.xEditGridCell862.Row = -1;
            // 
            // xEditGridCell863
            // 
            this.xEditGridCell863.CellLen = 100;
            this.xEditGridCell863.CellName = "specimen_yn";
            this.xEditGridCell863.Col = -1;
            this.xEditGridCell863.IsVisible = false;
            this.xEditGridCell863.Row = -1;
            // 
            // xEditGridCell864
            // 
            this.xEditGridCell864.CellLen = 100;
            this.xEditGridCell864.CellName = "jaeryo_yn";
            this.xEditGridCell864.Col = -1;
            this.xEditGridCell864.IsVisible = false;
            this.xEditGridCell864.Row = -1;
            // 
            // xEditGridCell865
            // 
            this.xEditGridCell865.CellLen = 100;
            this.xEditGridCell865.CellName = "ord_danui_check";
            this.xEditGridCell865.Col = -1;
            this.xEditGridCell865.IsVisible = false;
            this.xEditGridCell865.Row = -1;
            // 
            // xEditGridCell866
            // 
            this.xEditGridCell866.CellLen = 100;
            this.xEditGridCell866.CellName = "wonyoi_order_yn";
            this.xEditGridCell866.Col = -1;
            this.xEditGridCell866.IsVisible = false;
            this.xEditGridCell866.Row = -1;
            // 
            // xEditGridCell867
            // 
            this.xEditGridCell867.CellLen = 100;
            this.xEditGridCell867.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell867.Col = -1;
            this.xEditGridCell867.IsVisible = false;
            this.xEditGridCell867.Row = -1;
            // 
            // xEditGridCell868
            // 
            this.xEditGridCell868.CellLen = 100;
            this.xEditGridCell868.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell868.Col = -1;
            this.xEditGridCell868.IsVisible = false;
            this.xEditGridCell868.Row = -1;
            // 
            // xEditGridCell869
            // 
            this.xEditGridCell869.CellLen = 100;
            this.xEditGridCell869.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell869.Col = -1;
            this.xEditGridCell869.IsVisible = false;
            this.xEditGridCell869.Row = -1;
            // 
            // xEditGridCell870
            // 
            this.xEditGridCell870.CellLen = 100;
            this.xEditGridCell870.CellName = "nday_yn";
            this.xEditGridCell870.Col = -1;
            this.xEditGridCell870.IsVisible = false;
            this.xEditGridCell870.Row = -1;
            // 
            // xEditGridCell871
            // 
            this.xEditGridCell871.CellLen = 100;
            this.xEditGridCell871.CellName = "muhyo_yn";
            this.xEditGridCell871.Col = -1;
            this.xEditGridCell871.IsVisible = false;
            this.xEditGridCell871.Row = -1;
            // 
            // xEditGridCell872
            // 
            this.xEditGridCell872.CellLen = 100;
            this.xEditGridCell872.CellName = "pay_name";
            this.xEditGridCell872.Col = -1;
            this.xEditGridCell872.IsVisible = false;
            this.xEditGridCell872.Row = -1;
            // 
            // xEditGridCell873
            // 
            this.xEditGridCell873.CellLen = 100;
            this.xEditGridCell873.CellName = "bun_code";
            this.xEditGridCell873.Col = -1;
            this.xEditGridCell873.IsVisible = false;
            this.xEditGridCell873.Row = -1;
            // 
            // xEditGridCell874
            // 
            this.xEditGridCell874.CellLen = 100;
            this.xEditGridCell874.CellName = "data_control";
            this.xEditGridCell874.Col = -1;
            this.xEditGridCell874.IsVisible = false;
            this.xEditGridCell874.Row = -1;
            // 
            // xEditGridCell875
            // 
            this.xEditGridCell875.CellLen = 100;
            this.xEditGridCell875.CellName = "donbog_yn";
            this.xEditGridCell875.Col = -1;
            this.xEditGridCell875.IsVisible = false;
            this.xEditGridCell875.Row = -1;
            // 
            // xEditGridCell876
            // 
            this.xEditGridCell876.CellLen = 100;
            this.xEditGridCell876.CellName = "dv_name";
            this.xEditGridCell876.Col = -1;
            this.xEditGridCell876.IsVisible = false;
            this.xEditGridCell876.Row = -1;
            // 
            // xEditGridCell877
            // 
            this.xEditGridCell877.CellLen = 100;
            this.xEditGridCell877.CellName = "drg_info";
            this.xEditGridCell877.Col = -1;
            this.xEditGridCell877.IsVisible = false;
            this.xEditGridCell877.Row = -1;
            // 
            // xEditGridCell878
            // 
            this.xEditGridCell878.CellLen = 100;
            this.xEditGridCell878.CellName = "drg_bunryu";
            this.xEditGridCell878.Col = -1;
            this.xEditGridCell878.IsVisible = false;
            this.xEditGridCell878.Row = -1;
            // 
            // xEditGridCell879
            // 
            this.xEditGridCell879.CellLen = 100;
            this.xEditGridCell879.CellName = "child_gubun";
            this.xEditGridCell879.Col = -1;
            this.xEditGridCell879.IsVisible = false;
            this.xEditGridCell879.Row = -1;
            // 
            // xEditGridCell880
            // 
            this.xEditGridCell880.CellLen = 100;
            this.xEditGridCell880.CellName = "bom_source_key";
            this.xEditGridCell880.Col = -1;
            this.xEditGridCell880.IsVisible = false;
            this.xEditGridCell880.Row = -1;
            // 
            // xEditGridCell881
            // 
            this.xEditGridCell881.CellLen = 100;
            this.xEditGridCell881.CellName = "haengwee_yn";
            this.xEditGridCell881.Col = -1;
            this.xEditGridCell881.IsVisible = false;
            this.xEditGridCell881.Row = -1;
            // 
            // xEditGridCell882
            // 
            this.xEditGridCell882.CellLen = 100;
            this.xEditGridCell882.CellName = "org_key";
            this.xEditGridCell882.Col = -1;
            this.xEditGridCell882.IsVisible = false;
            this.xEditGridCell882.Row = -1;
            // 
            // xEditGridCell883
            // 
            this.xEditGridCell883.CellLen = 100;
            this.xEditGridCell883.CellName = "parent_key";
            this.xEditGridCell883.Col = -1;
            this.xEditGridCell883.IsVisible = false;
            this.xEditGridCell883.Row = -1;
            // 
            // xEditGridCell884
            // 
            this.xEditGridCell884.CellLen = 100;
            this.xEditGridCell884.CellName = "fkocs0300_seq";
            this.xEditGridCell884.Col = -1;
            this.xEditGridCell884.IsVisible = false;
            this.xEditGridCell884.Row = -1;
            // 
            // xEditGridCell885
            // 
            this.xEditGridCell885.CellLen = 100;
            this.xEditGridCell885.CellName = "child_yn";
            this.xEditGridCell885.Col = -1;
            this.xEditGridCell885.IsVisible = false;
            this.xEditGridCell885.Row = -1;
            // 
            // xEditGridCell886
            // 
            this.xEditGridCell886.CellLen = 100;
            this.xEditGridCell886.CellName = "jundal_table_out";
            this.xEditGridCell886.Col = -1;
            this.xEditGridCell886.IsVisible = false;
            this.xEditGridCell886.Row = -1;
            // 
            // xEditGridCell887
            // 
            this.xEditGridCell887.CellLen = 100;
            this.xEditGridCell887.CellName = "jundal_part_out";
            this.xEditGridCell887.Col = -1;
            this.xEditGridCell887.IsVisible = false;
            this.xEditGridCell887.Row = -1;
            // 
            // xEditGridCell888
            // 
            this.xEditGridCell888.CellLen = 100;
            this.xEditGridCell888.CellName = "jundal_table_inp";
            this.xEditGridCell888.Col = -1;
            this.xEditGridCell888.IsVisible = false;
            this.xEditGridCell888.Row = -1;
            // 
            // xEditGridCell889
            // 
            this.xEditGridCell889.CellLen = 100;
            this.xEditGridCell889.CellName = "jundal_part_inp";
            this.xEditGridCell889.Col = -1;
            this.xEditGridCell889.IsVisible = false;
            this.xEditGridCell889.Row = -1;
            // 
            // xEditGridCell890
            // 
            this.xEditGridCell890.CellLen = 100;
            this.xEditGridCell890.CellName = "move_part_out";
            this.xEditGridCell890.Col = -1;
            this.xEditGridCell890.IsVisible = false;
            this.xEditGridCell890.Row = -1;
            // 
            // xEditGridCell891
            // 
            this.xEditGridCell891.CellLen = 100;
            this.xEditGridCell891.CellName = "move_part_inp";
            this.xEditGridCell891.Col = -1;
            this.xEditGridCell891.IsVisible = false;
            this.xEditGridCell891.Row = -1;
            // 
            // xEditGridCell892
            // 
            this.xEditGridCell892.CellLen = 100;
            this.xEditGridCell892.CellName = "jundal_part_out_name";
            this.xEditGridCell892.Col = -1;
            this.xEditGridCell892.IsVisible = false;
            this.xEditGridCell892.Row = -1;
            // 
            // xEditGridCell893
            // 
            this.xEditGridCell893.CellLen = 100;
            this.xEditGridCell893.CellName = "jundal_part_inp_name";
            this.xEditGridCell893.Col = -1;
            this.xEditGridCell893.IsVisible = false;
            this.xEditGridCell893.Row = -1;
            // 
            // xEditGridCell894
            // 
            this.xEditGridCell894.CellLen = 100;
            this.xEditGridCell894.CellName = "wonnae_drg_yn";
            this.xEditGridCell894.Col = -1;
            this.xEditGridCell894.IsVisible = false;
            this.xEditGridCell894.Row = -1;
            // 
            // xEditGridCell895
            // 
            this.xEditGridCell895.CellLen = 100;
            this.xEditGridCell895.CellName = "dv_5";
            this.xEditGridCell895.Col = -1;
            this.xEditGridCell895.IsVisible = false;
            this.xEditGridCell895.Row = -1;
            // 
            // xEditGridCell896
            // 
            this.xEditGridCell896.CellLen = 100;
            this.xEditGridCell896.CellName = "dv_6";
            this.xEditGridCell896.Col = -1;
            this.xEditGridCell896.IsVisible = false;
            this.xEditGridCell896.Row = -1;
            // 
            // xEditGridCell897
            // 
            this.xEditGridCell897.CellLen = 100;
            this.xEditGridCell897.CellName = "dv_7";
            this.xEditGridCell897.Col = -1;
            this.xEditGridCell897.IsVisible = false;
            this.xEditGridCell897.Row = -1;
            // 
            // xEditGridCell898
            // 
            this.xEditGridCell898.CellLen = 100;
            this.xEditGridCell898.CellName = "dv_8";
            this.xEditGridCell898.Col = -1;
            this.xEditGridCell898.IsVisible = false;
            this.xEditGridCell898.Row = -1;
            // 
            // xEditGridCell899
            // 
            this.xEditGridCell899.CellLen = 100;
            this.xEditGridCell899.CellName = "general_disp_yn";
            this.xEditGridCell899.Col = -1;
            this.xEditGridCell899.IsVisible = false;
            this.xEditGridCell899.Row = -1;
            // 
            // xEditGridCell900
            // 
            this.xEditGridCell900.CellLen = 100;
            this.xEditGridCell900.CellName = "generic_name";
            this.xEditGridCell900.Col = -1;
            this.xEditGridCell900.IsVisible = false;
            this.xEditGridCell900.Row = -1;
            // 
            // xEditGridCell901
            // 
            this.xEditGridCell901.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell901.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell901.CellLen = 1;
            this.xEditGridCell901.CellName = "select";
            this.xEditGridCell901.CellWidth = 27;
            this.xEditGridCell901.HeaderText = "選択";
            this.xEditGridCell901.IsReadOnly = true;
            this.xEditGridCell901.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell901.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell901.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "memb";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "fkocs0321";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "pk_yaksok";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "pkocs0323";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "group_ser";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "mix_group";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "seq";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "order_gubun";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "order_gubun_name";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "input_tab";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "hangmog_code";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "hangmog_name";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "specimen_code";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "specimen_name";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "suryang";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "ord_danui";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "order_danui_name";
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "dv_time";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "dv";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "dv_1";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "dv_2";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "dv_3";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "dv_4";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "nalsu";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "jusa";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "jusa_name";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "bogyong_code";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "bogyong_name";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "jusa_spd_gubun";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "hubal_change_yn";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "pharmacy";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "drg_pack_yn";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "emergency";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "pay";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "portable_yn";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "powder_yn";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "muhyo";
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "prn_yn";
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "order_remark";
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "nurse_remark";
            // 
            // multiLayoutItem74
            // 
            this.multiLayoutItem74.DataName = "bulyong_check";
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "slip_code";
            // 
            // multiLayoutItem76
            // 
            this.multiLayoutItem76.DataName = "group_yn";
            // 
            // multiLayoutItem77
            // 
            this.multiLayoutItem77.DataName = "order_gubun_bas";
            // 
            // multiLayoutItem78
            // 
            this.multiLayoutItem78.DataName = "input_control";
            // 
            // multiLayoutItem79
            // 
            this.multiLayoutItem79.DataName = "sg_code";
            // 
            // multiLayoutItem80
            // 
            this.multiLayoutItem80.DataName = "suga_yn";
            // 
            // multiLayoutItem81
            // 
            this.multiLayoutItem81.DataName = "emergency_check";
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "limit_suryang";
            // 
            // multiLayoutItem83
            // 
            this.multiLayoutItem83.DataName = "specimen_yn";
            // 
            // multiLayoutItem84
            // 
            this.multiLayoutItem84.DataName = "jaeryo_yn";
            // 
            // multiLayoutItem85
            // 
            this.multiLayoutItem85.DataName = "ord_danui_check";
            // 
            // multiLayoutItem86
            // 
            this.multiLayoutItem86.DataName = "wonyoi_order_yn";
            // 
            // multiLayoutItem87
            // 
            this.multiLayoutItem87.DataName = "dangil_gumsa_order_yn";
            // 
            // multiLayoutItem88
            // 
            this.multiLayoutItem88.DataName = "dangil_gumsa_result_yn";
            // 
            // multiLayoutItem89
            // 
            this.multiLayoutItem89.DataName = "wonyoi_order_cr_yn";
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "nday_yn";
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "muhyo_yn";
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "pay_name";
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "bun_code";
            // 
            // multiLayoutItem94
            // 
            this.multiLayoutItem94.DataName = "data_control";
            // 
            // multiLayoutItem95
            // 
            this.multiLayoutItem95.DataName = "donbog_yn";
            // 
            // multiLayoutItem96
            // 
            this.multiLayoutItem96.DataName = "dv_name";
            // 
            // multiLayoutItem97
            // 
            this.multiLayoutItem97.DataName = "drg_info";
            // 
            // multiLayoutItem98
            // 
            this.multiLayoutItem98.DataName = "drg_bunryu";
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "child_gubun";
            // 
            // multiLayoutItem100
            // 
            this.multiLayoutItem100.DataName = "bom_source_key";
            // 
            // multiLayoutItem101
            // 
            this.multiLayoutItem101.DataName = "haengwee_yn";
            // 
            // multiLayoutItem102
            // 
            this.multiLayoutItem102.DataName = "org_key";
            // 
            // multiLayoutItem103
            // 
            this.multiLayoutItem103.DataName = "parent_key";
            // 
            // multiLayoutItem104
            // 
            this.multiLayoutItem104.DataName = "fkocs0300_seq";
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "child_yn";
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "jundal_table_out";
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "jundal_part_out";
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "jundal_table_inp";
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "jundal_part_inp";
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "move_part_out";
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "move_part_inp";
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "jundal_part_out_name";
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "jundal_part_inp_name";
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "wonnae_drg_yn";
            // 
            // multiLayoutItem115
            // 
            this.multiLayoutItem115.DataName = "dv_5";
            // 
            // multiLayoutItem116
            // 
            this.multiLayoutItem116.DataName = "dv_6";
            // 
            // multiLayoutItem117
            // 
            this.multiLayoutItem117.DataName = "dv_7";
            // 
            // multiLayoutItem118
            // 
            this.multiLayoutItem118.DataName = "dv_8";
            // 
            // multiLayoutItem119
            // 
            this.multiLayoutItem119.DataName = "general_disp_yn";
            // 
            // multiLayoutItem120
            // 
            this.multiLayoutItem120.DataName = "generic_name";
            // 
            // multiLayoutItem121
            // 
            this.multiLayoutItem121.DataName = "select";
            // 
            // multiLayoutItem204
            // 
            this.multiLayoutItem204.DataName = "part_name";
            // 
            // xEditGridCell902
            // 
            this.xEditGridCell902.CellName = "part_name";
            this.xEditGridCell902.Col = -1;
            this.xEditGridCell902.IsVisible = false;
            this.xEditGridCell902.Row = -1;
            // 
            // xEditGridCell903
            // 
            this.xEditGridCell903.CellName = "part_name";
            this.xEditGridCell903.Col = -1;
            this.xEditGridCell903.IsVisible = false;
            this.xEditGridCell903.Row = -1;
            // 
            // xEditGridCell904
            // 
            this.xEditGridCell904.CellName = "part_name";
            this.xEditGridCell904.Col = -1;
            this.xEditGridCell904.IsVisible = false;
            this.xEditGridCell904.Row = -1;
            // 
            // xEditGridCell905
            // 
            this.xEditGridCell905.CellName = "part_name";
            this.xEditGridCell905.Col = -1;
            this.xEditGridCell905.IsVisible = false;
            this.xEditGridCell905.Row = -1;
            // 
            // xEditGridCell906
            // 
            this.xEditGridCell906.CellName = "part_name";
            this.xEditGridCell906.Col = -1;
            this.xEditGridCell906.IsVisible = false;
            this.xEditGridCell906.Row = -1;
            // 
            // xEditGridCell907
            // 
            this.xEditGridCell907.CellName = "part_name";
            this.xEditGridCell907.Col = -1;
            this.xEditGridCell907.IsVisible = false;
            this.xEditGridCell907.Row = -1;
            // 
            // xEditGridCell908
            // 
            this.xEditGridCell908.CellName = "part_name";
            this.xEditGridCell908.Col = -1;
            this.xEditGridCell908.IsVisible = false;
            this.xEditGridCell908.Row = -1;
            // 
            // xEditGridCell909
            // 
            this.xEditGridCell909.CellName = "part_name";
            this.xEditGridCell909.Col = -1;
            this.xEditGridCell909.IsVisible = false;
            this.xEditGridCell909.Row = -1;
            // 
            // xEditGridCell910
            // 
            this.xEditGridCell910.CellName = "part_name";
            this.xEditGridCell910.Col = -1;
            this.xEditGridCell910.IsVisible = false;
            this.xEditGridCell910.Row = -1;
            // 
            // OCS0323Q00
            // 
            this.Controls.Add(this.grdOCS0321);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grdOCS0303);
            this.Controls.Add(this.grdOCS0301);
            this.Controls.Add(this.xLabel4);
            this.Controls.Add(this.txtSearchSetName);
            this.Controls.Add(this.tvwOCS0300);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.panMemb);
            this.Name = "OCS0323Q00";
            this.Size = new System.Drawing.Size(1508, 765);
            this.UserChanged += new System.EventHandler(this.OCS0301Q00_UserChanged);
            this.panMemb.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0301)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS0301)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS0303)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOrder_danui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloInputControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloMemb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSetOrderCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0303)).EndInit();
            this.pnlOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_1)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0321)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS0323)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0323_9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion

        #region [Screen Event]

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command.Trim())
            {
                case "OCS0270Q00": // 의사조회

                    //if (!TypeCheck.IsNull(commandParam["doctor"].ToString()))
                    //{
                    //    this.fbxDoctor.SetEditValue(commandParam["doctor"].ToString());
                    //}

                    //fbxDoctor.AcceptData();
                    //fbxDoctor.Focus();
                    //fbxDoctor.SelectAll();

                    break;

            }
            return base.Command(command, commandParam);
        }

        protected override void OnLoad(EventArgs e)
        {
            // 회수 Header 한칸으로 처리하기
            if (this.grdOCS0303[0, 10] != null)
                this.grdOCS0303[0, 10].RowSpan = 2;
            if (this.grdOCS0303[1, 10] != null)
                this.grdOCS0303[1, 10] = null;
            if (this.grdOCS0303[1, 11] != null)
                this.grdOCS0303[1, 11] = null;

            base.OnLoad(e);

            try
            {
                popupMenu.MenuCommands.Clear();
                popupMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "検査情報照会" : "검사정보조회", (Image)this.ImageList.Images[4],
                    new EventHandler(this.PopUpMenuGumsaInfo_Click)));

                popupSetOrderCopy.MenuCommands.Clear();
                popupSetOrderCopy.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "セットオ―ダコピー" : "Set오더 Copy", (Image)this.ImageList.Images[5],
                    new EventHandler(this.PopUpMenuSetOrderCopy_Click)));
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.Message);
            }

            // Call된 경우
            if (this.OpenParam != null)
            {
                try
                {
                    // 호출한 화면의 사용자 memb
                    if (OpenParam.Contains("memb"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["memb"].ToString()))
                            mMemb = OpenParam["memb"].ToString();
                    }

                    //호출한 화면의 사용자의 과
                    if (OpenParam.Contains("gwa"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["gwa"].ToString()))
                            mGwa = OpenParam["gwa"].ToString();
                    }

                    if (OpenParam.Contains("input_tab"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["input_tab"].ToString()))
                            mInput_tab = OpenParam["input_tab"].ToString();
                    }
                    if (OpenParam.Contains("io_gubun"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["io_gubun"].ToString()))
                        {
                            mIOgubun = OpenParam["io_gubun"].ToString();
                        }
                    }
                    if (OpenParam.Contains("grd_order"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["grd_order"]))
                        {
                            mInOrderData = ((DataTable)OpenParam["grd_order"]);
                        }
                    }
                    //mNaewon_date = DateTime.Now.ToString("yyyy/MM/dd");
                    //if (OpenParam.Contains("naewon_date"))
                    //{
                    //    if (TypeCheck.IsDateTime(OpenParam["naewon_date"].ToString()))
                    //        mNaewon_date = OpenParam["naewon_date"].ToString();
                    //}
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
                //mYaksok_code = "";
            }

            InitialDesign();

            //Set M/D Relation
            grdOCS0303.SetRelationKey("memb", "memb");
            grdOCS0303.SetRelationKey("yaksok_code", "yaksok_code");
            grdOCS0303.SetRelationKey("input_tab", "input_tab");

            grdOCS0303.SetBindVarValue("f_input_tab", mInput_tab);
            grdOCS0303.SetBindVarValue("f_input_tab", mInput_tab);


            //Set Current Grid
            this.CurrMSLayout = this.grdOCS0301;
            this.CurrMQLayout = this.grdOCS0301;

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        /// <summary>
        /// Load시 별도 Design할 부분이 있는 경우 여기서 Coding처리
        /// </summary>
        private void InitialDesign()
        {
            grdOCS0303.FixedCols = 7;
            //panel 경계부분 splitter가 있는 경우 경계부분 panel bordColor처리
            splitter1.BackColor = XColor.XDisplayBoxGradientEndColor.Color;

            //column invible처리
            foreach (XGridCell cell in grdOCS0303.CellInfos)
            {
                if (cell.IsVisible)
                {
                    if (mInput_tab == "%" || this.mInputControl.IsVisibleColumn(mInput_tab, cell.CellName))
                    {
                        grdOCS0303.AutoSizeColumn(cell.Col, cell.CellWidth);
                    }
                    else
                        grdOCS0303.AutoSizeColumn(cell.Col, 0);

                }
            }
        }

        private void PostLoad()
        {
            //comboBox생성
            CreateCombo();

            //DataLayout 생성
            CreateLayout();

            /// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
            this.OCS0301Q00_UserChanged(this, new System.EventArgs());
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void OCS0301Q00_UserChanged(object sender, System.EventArgs e)
        {
            this.panMemb.Visible = true;
            SetUserCheckBox();
        }

        private bool IsDoctor(string aMemb)
        {
            string cmdText = @"SELECT 'Y'
                                  FROM DUAL
                                 WHERE EXISTS ( SELECT DOCTOR
                                                  FROM BAS0270
                                                 WHERE HOSP_CODE = :f_hosp_code
                                                   AND DOCTOR    = :f_doctor
                                                   AND SYSDATE   BETWEEN START_DATE AND END_DATE )";

            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", mHospCode);
            bc.Add("f_doctor", aMemb);

            object retVal = Service.ExecuteScalar(cmdText, bc);
            if (!TypeCheck.IsNull(retVal))
            {
                if (retVal.ToString() == "Y")
                    return true;
            }

            return false;
        }

        //사용자 checkBox 생성
        private void SetUserCheckBox()
        {
            //memb reset
            dloMemb.Reset();
            int insertRow;

            //병원공통약속order			
            insertRow = dloMemb.InsertRow(-1);
            dloMemb.SetItemValue(insertRow, "memb", "ADMIN");
            dloMemb.SetItemValue(insertRow, "memb_name", "病院セット");

            //해당과           
            string gwa_name = "";
            if(mGwa != "")
            {
                if (ob.LoadColumnCodeName("gwa_all", mGwa, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), ref gwa_name))
                {
                    insertRow = dloMemb.InsertRow(-1);
                    dloMemb.SetItemValue(insertRow, "memb", mGwa);
                    dloMemb.SetItemValue(insertRow, "memb_name", gwa_name);
                }
            }
            
            string user_name = "";
            if (this.mMemb != "")
            {
                if (ob.LoadColumnCodeName("gwa_doctor", "%", mMemb, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), ref user_name))
                {
                    // 의사인경우는... 의사공통을 가져가야한다.
                    //해당 사용자 User
                    insertRow = dloMemb.InsertRow(-1);
                    //dloMemb.SetItemValue(insertRow, "memb", mMemb.Replace(mGwa, ""));
                    dloMemb.SetItemValue(insertRow, "memb", UserInfo.UserID); 
                    dloMemb.SetItemValue(insertRow, "memb_name", user_name + "【共通】");
                }
                else if (ob.LoadColumnCodeName("user_id", mMemb, ref user_name))
                {
                }
                //과별개인셋트오더취득
                SingleLayout layCommon = new SingleLayout();
                layCommon.QuerySQL = @" SELECT 'Y'
                                           FROM DUAL 
                                          WHERE EXISTS ( SELECT 'X'
                                                           FROM  OCS0301 Z 
                                                          WHERE  Z.HOSP_CODE = :f_hosp_code
                                                            AND  Z.MEMB      = :f_memb)";
                layCommon.LayoutItems.Add("check_yn");   
                layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                layCommon.SetBindVarValue("f_memb", mMemb);

                if (layCommon.QueryLayout() && (layCommon.GetItemValue("check_yn").ToString()=="Y"))
                {
                    //해당 사용자 User
                    insertRow = dloMemb.InsertRow(-1);
                    dloMemb.SetItemValue(insertRow, "memb", mMemb);
                    dloMemb.SetItemValue(insertRow, "memb_name", user_name + "【" + gwa_name + "】");
                }
            }
            
            //검색어 문제로 해당부분을 막는다.
            //			if(UserInfo.UserGubun == UserType.Nurse && EnvironInfo.CurrSystemID == "NURI")
            //				this.LoadHoDongComUSer(ref dloMemb);

            //사용자 약속코드 정보 Load
            if (dloMemb.RowCount > 0)
            {
                if (dloMemb.RowCount <= 5)
                    panMemb.SetBounds(panMemb.Location.X, panMemb.Location.Y, panMemb.Size.Width, rbt.Location.Y + rbt.Size.Height + 2);
                
                ShowMemb();
            }
            else
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "該当画面に使用権限がない使用者です。ご確認下さい。" : "해당 화면에 사용권한이 없는 사용자입니다. 확인하십시요.";
                mbxCap = NetInfo.Language == LangMode.Jr ? "使用権限" : "사용권한";
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
                this.Close();
            }

        }

        //사용자 ComboBox생성
        //private void SetUserCombo()
        //{
        //    //CreateGwaCombo();
        //}

        /// <summary>
        /// DataLayout LayoutItems생성
        /// </summary>
        private void CreateLayout()
        {
            //OCS0301
            foreach (XGridCell cell in this.grdOCS0301.CellInfos)
            {
                dloSelectOCS0301.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
            }

            dloSelectOCS0301.InitializeLayoutTable();

            //OCS0303
            //foreach (XGridCell cell in this.grdOCS0303.CellInfos)
            //{
            //    dloSelectOCS0303.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
            //}

            //dloSelectOCS0303.InitializeLayoutTable();
            foreach (XGridCell cell in this.grdOCS0323_1.CellInfos)
            {
                dloSelectOCS0303.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
            }

            dloSelectOCS0303.InitializeLayoutTable();
        }

        /// <summary>
        /// 기준정보 DataLayout생성
        /// </summary>
        private void LoadBaseData()
        {
            //Order 단위
            dloOrder_danui.QuerySQL = @"SELECT CODE
                                          FROM OCS0132
                                         WHERE CODE_TYPE = 'ORD_DANUI'
                                           AND HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                         ORDER BY CODE";
            dloOrder_danui.QueryLayout(false);

            //InputControl
            dloInputControl.QuerySQL = @"SELECT INPUT_CONTROL     , 
                                                INPUT_CONTROL_NAME, 
                                                SPECIMEN_CR_YN    , 
                                                SURYANG_CR_YN     , 
                                                ORD_DANUI_CR_YN   , 
                                         --       DV_TIME_CR_YN     , 
                                                DV_CR_YN          , 
                                                NALSU_CR_YN       , 
                                                JUSA_CR_YN        , 
                                                BOGYONG_CODE_CR_YN, 
                                                TOIWON_DRG_CR_YN  , 
                                         --       TPN_CR_YN         , 
                                         --       ANTI_CANCER_CR_YN , 
                                         --       FLUID_CR_YN       , 
                                                PORTABLE_CR_YN    , 
                                         --       DONER_CR_YN       , 
                                                AMT_CR_YN           
                                           FROM OCS0133
                                          WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()";
            dloInputControl.QueryLayout(false);
        }

        #endregion

        #region [병동간호 공통유져]

//        private void LoadHoDongComUSer(ref MultiLayout dloMemb)
//        {
//            IHIS.Framework.MultiLayout layoutCombo = new MultiLayout();

//            //SLIP_GUBUN DataLayout;
//            layoutCombo.Reset();
//            layoutCombo.LayoutItems.Clear();
//            layoutCombo.LayoutItems.Add("memb", DataType.String);
//            layoutCombo.LayoutItems.Add("memb_name", DataType.String);
//            layoutCombo.InitializeLayoutTable();

//            layoutCombo.QuerySQL = @"SELECT A.MEMB, A.MEMB_NAME FROM OCS0130 A         
//                                      WHERE A.MEMB_GUBUN = 'B'
//                                        AND A.HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE()
//                                      ORDER BY MEMB ";

//            layoutCombo.QueryLayout(false);

//            if (Service.ErrCode.ToString() == "0" && layoutCombo.LayoutTable != null)
//            {
//                int insertRow = -1;
//                foreach (DataRow row in layoutCombo.LayoutTable.Rows)
//                {
//                    if (dloMemb.LayoutTable.Select(" memb = '" + row["memb"].ToString() + "' ", "").Length == 0)
//                    {
//                        insertRow = dloMemb.InsertRow(-1);
//                        dloMemb.SetItemValue(insertRow, "memb", row["memb"]);
//                        dloMemb.SetItemValue(insertRow, "memb_name", row["memb_name"]);
//                    }
//                }
//            }

//        }

        #endregion

        #region [사용자공통 USER를 가져옵니다.]

        
        /// <summary>
        /// 해당 사용자의 공통 USER ID를 가져옵니다.
        /// </summary>
        /// <param name="aUser_gubun">공통사용자구분</param>
        /// <param name="aUser_id">사용자ID</param>
        /// <returns></returns>
        //private string GetOCSCOM_USER_ID(string aUser_gubun, string aUser_id)
        //{
        //    string comUser_id = "";
        //    string cmdText = "";
        //    BindVarCollection bindVars = new BindVarCollection();
        //    object retVal = null;

        //    cmdText = "SELECT FN_OCS_LOAD_MEMB_COMID(:f_gubun, :f_user_id) FROM DUAL";
        //    bindVars.Add("f_gubun", aUser_gubun);
        //    bindVars.Add("f_user_id", aUser_id);

        //    retVal = Service.ExecuteScalar(cmdText, bindVars);

        //    if (!TypeCheck.IsNull(retVal))
        //    {
        //        comUser_id = retVal.ToString();
        //    }

        //    return comUser_id;
        //}

        
        #endregion

        #region [사용자 RadioBotton 생성]

        const int INPUT_GUBUN_WIDTH = 160;
        const int INPUT_GUBUN_HEIGHT = 26;//	140, 34	

        private void ShowMemb()
        {
            panMemb.Controls.Clear();

            XRadioButton rbtMemb;

            int startX = 4;
            bool isVisible = true;

            foreach (DataRow row in dloMemb.LayoutTable.Rows)
            {
                rbtMemb = new XRadioButton();
                rbtMemb.Appearance = System.Windows.Forms.Appearance.Button;
                rbtMemb.Cursor = System.Windows.Forms.Cursors.Hand;
                rbtMemb.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtMemb.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtMemb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                rbtMemb.ImageList = this.ImageList;
                rbtMemb.ImageIndex = 0;
                rbtMemb.Location = new System.Drawing.Point(startX, 4);
                rbtMemb.Name = "rbt" + row["memb"];
                rbtMemb.Size = new System.Drawing.Size(INPUT_GUBUN_WIDTH, INPUT_GUBUN_HEIGHT);
                rbtMemb.Text = "     " + row["memb_name"].ToString();
                rbtMemb.Tag = row["memb"].ToString();
                rbtMemb.Visible = isVisible;
                //rbtMemb.Click += new System.EventHandler(this.rbtMemb_Click);
                rbtMemb.CheckedChanged += new EventHandler(rbtMemb_CheckedChanged);
                panMemb.Controls.Add(rbtMemb);

                startX = startX + INPUT_GUBUN_WIDTH;
            }

            // 간호
            //if (UserInfo.UserGubun == UserType.Nurse)
            //{
            //    rbtMemb = new XRadioButton();
            //    rbtMemb.Appearance = System.Windows.Forms.Appearance.Button;
            //    rbtMemb.Cursor = System.Windows.Forms.Cursors.Hand;
            //    rbtMemb.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            //    rbtMemb.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            //    rbtMemb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //    rbtMemb.ImageList = this.ImageList;
            //    rbtMemb.ImageIndex = 0;
            //    rbtMemb.Location = new System.Drawing.Point(startX, 4);
            //    rbtMemb.Name = "rbtGwa";
            //    rbtMemb.Size = new System.Drawing.Size(78, INPUT_GUBUN_HEIGHT);
            //    rbtMemb.Text = "      診療科";
            //    rbtMemb.Tag = "GWA";
            //    rbtMemb.Click += new System.EventHandler(this.rbtMemb_Click);
            //    panMemb.Controls.Add(rbtMemb);
            //    startX = startX + 78;

            //    rbtMemb = new XRadioButton();
            //    rbtMemb.Appearance = System.Windows.Forms.Appearance.Button;
            //    rbtMemb.Cursor = System.Windows.Forms.Cursors.Hand;
            //    rbtMemb.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            //    rbtMemb.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            //    rbtMemb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //    rbtMemb.ImageList = this.ImageList;
            //    rbtMemb.ImageIndex = 0;
            //    rbtMemb.Location = new System.Drawing.Point(startX, 4);
            //    rbtMemb.Name = "rbtDoctor";
            //    rbtMemb.Size = new System.Drawing.Size(78, INPUT_GUBUN_HEIGHT);
            //    rbtMemb.Text = "      医師";
            //    rbtMemb.Tag = "DOCTOR";
            //    rbtMemb.Click += new System.EventHandler(this.rbtMemb_Click);
            //    panMemb.Controls.Add(rbtMemb);
            //}

            if (dloMemb.RowCount > 0)
            {
                if (dloMemb.RowCount >= 3)
                {
                    //정형외과는 정형외과가 선택되도록 변경
                    //if (UserInfo.UserGubun == UserType.Doctor && UserInfo.Gwa == "06")
                    //    rbtMemb_Click(panMemb.Controls[dloMemb.RowCount - 1], null);
                    //else
                    //    rbtMemb_Click(panMemb.Controls[1], null);
                    //rbtMemb_Click(panMemb.Controls[dloMemb.RowCount - 1], null);
                    
                    //this.rbtMemb_CheckedChanged(panMemb.Controls[dloMemb.RowCount - 1], new EventArgs());
                    //공통으로변경
                    ((XRadioButton)panMemb.Controls[2]).Checked = true;
                }
                else
                {
                    //this.rbtMemb_CheckedChanged(panMemb.Controls[dloMemb.RowCount - 1], new EventArgs());
                    ((XRadioButton)panMemb.Controls[0]).Checked = true;
                }
            }
        }

        void rbtMemb_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton rbt = sender as XRadioButton;
            
            if (rbt.Checked)
            {
                rbt.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
                rbt.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                rbt.ImageIndex = 1;

                grdOCS0301.ClearFilter();

                //현재선택된 row trans			
                for (int i = 0; i < grdOCS0301.RowCount; i++)
                {
                    if (grdOCS0301.GetItemString(i, "select") == "Y")
                        dloSelectOCS0301.LayoutTable.ImportRow(grdOCS0301.LayoutTable.Rows[i]);
                }

                //현재선택된 row trans			
                for (int i = 0; i < grdOCS0303.RowCount; i++)
                {
                    if (grdOCS0303.GetItemString(i, "select") == "Y")
                        InsertBackTable(grdOCS0303.LayoutTable.Rows[i]);
                }

                string isGrantNur = "%";

                if (rbt.Tag.ToString() == "GWA")
                {
                    //this.pnlMemb_1.Visible = true;
                    //this.lblGwaDoctor.Text = "診療科";
                    //this.fbxDoctor.Visible = false;
                    //this.dbxDoctor_name.Visible = false;
                    //this.cboGwa.Visible = true;

                    //if (cboGwa.SelectedIndex >= 0)
                    //    mMemb = cboGwa.GetDataValue();
                    //else
                    //    mMemb = "";

                    isGrantNur = "Y";

                }
                else if (rbt.Tag.ToString() == "DOCTOR")
                {
                    //this.pnlMemb_1.Visible = true;
                    //lblGwaDoctor.Text = "医師";
                    //this.fbxDoctor.Visible = true;

                    //주치의 자동세팅
                    //this.fbxDoctor.SetEditValue(mDoctor);
                    //this.fbxDoctor.AcceptData();

                    //this.dbxDoctor_name.Visible = true;
                    //this.cboGwa.Visible = false;

                    //mMemb = fbxDoctor.GetDataValue();

                    isGrantNur = "Y";
                }
                else if (rbt.Tag.ToString() == "ADMIN")
                {
                    //병원공통세트의 경우 의사가 아닌 경우는 간호오더가 가능한 세트만 보여 주도록 한다.
                    if (!IsDoctor(mMemb))
                        isGrantNur = "Y";
                    else
                        isGrantNur = "%";

                    mMemb = rbt.Tag.ToString();
                }
                else
                {
                    //this.pnlMemb_1.Visible = false;
                    mMemb = rbt.Tag.ToString();
                }
                grdOCS0301.SetBindVarValue("memb", mMemb);
                grdOCS0301.SetBindVarValue("yaksok_code", "");
                //grdOCS0301.SetBindVarValue("grant_nur", isGrantNur);
                //grdOCS0301.QueryLayout(true);
                grdOCS0321.QueryLayout(true);
            }
            else
            {
                rbt.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbt.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbt.ImageIndex = 0;
            }
            //modify by yoonB [Query2回実行回避] 2012/03/23
            //foreach (object obj in panMemb.Controls)
            //{
            //    //if (((XRadioButton)obj).Name == rbt.Name)

            //    if (((XRadioButton)obj).Checked == true)
            //    {
            //        ((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
            //        ((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
            //        ((XRadioButton)obj).ImageIndex = 1;

            //        if (!((XRadioButton)obj).Checked)
            //            ((XRadioButton)obj).Checked = true;

            //        grdOCS0301.ClearFilter();

            //        //현재선택된 row trans			
            //        for (int i = 0; i < grdOCS0301.RowCount; i++)
            //        {
            //            if (grdOCS0301.GetItemString(i, "select") == "Y")
            //                dloSelectOCS0301.LayoutTable.ImportRow(grdOCS0301.LayoutTable.Rows[i]);
            //        }

            //        //현재선택된 row trans			
            //        for (int i = 0; i < grdOCS0303.RowCount; i++)
            //        {
            //            if (grdOCS0303.GetItemString(i, "select") == "Y")
            //                InsertBackTable(grdOCS0303.LayoutTable.Rows[i]);
            //        }

            //        string isGrantNur = "%";

            //        if (((XRadioButton)obj).Tag.ToString() == "GWA")
            //        {
            //            //this.pnlMemb_1.Visible = true;
            //            //this.lblGwaDoctor.Text = "診療科";
            //            //this.fbxDoctor.Visible = false;
            //            //this.dbxDoctor_name.Visible = false;
            //            //this.cboGwa.Visible = true;

            //            //if (cboGwa.SelectedIndex >= 0)
            //            //    mMemb = cboGwa.GetDataValue();
            //            //else
            //            //    mMemb = "";

            //            isGrantNur = "Y";

            //        }
            //        else if (((XRadioButton)obj).Tag.ToString() == "DOCTOR")
            //        {
            //            //this.pnlMemb_1.Visible = true;
            //            //lblGwaDoctor.Text = "医師";
            //            //this.fbxDoctor.Visible = true;

            //            //주치의 자동세팅
            //            //this.fbxDoctor.SetEditValue(mDoctor);
            //            //this.fbxDoctor.AcceptData();

            //            //this.dbxDoctor_name.Visible = true;
            //            //this.cboGwa.Visible = false;

            //            //mMemb = fbxDoctor.GetDataValue();

            //            isGrantNur = "Y";
            //        }
            //        else if ((((XRadioButton)obj).Tag.ToString() == "ADMIN"))
            //        {
            //            //병원공통세트의 경우 의사가 아닌 경우는 간호오더가 가능한 세트만 보여 주도록 한다.
            //            if (!IsDoctor(mMemb))
            //                isGrantNur = "Y";
            //            else
            //                isGrantNur = "%";

            //            mMemb = ((XRadioButton)obj).Tag.ToString();
            //        }
            //        else
            //        {
            //            //this.pnlMemb_1.Visible = false;
            //            mMemb = ((XRadioButton)obj).Tag.ToString();
            //        }


            //        grdOCS0301.SetBindVarValue("memb", mMemb);
            //        grdOCS0301.SetBindVarValue("yaksok_code", "");
            //        //grdOCS0301.SetBindVarValue("grant_nur", isGrantNur);
            //        grdOCS0301.QueryLayout(true);

            //    }
            //    else
            //    {
            //        ((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
            //        ((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
            //        ((XRadioButton)obj).ImageIndex = 0;

            //        if (((XRadioButton)obj).Checked)
            //            ((XRadioButton)obj).Checked = false;
            //    }
            //}
        }

        private void rbtMemb_Click(object sender, System.EventArgs e)
        {
            if (!isMouseDown) //탭클링어하는데 이게 자꾸 왜타지냐
                return;

            XRadioButton rbt = sender as XRadioButton;

            foreach (object obj in panMemb.Controls)
            {
                //if (((XRadioButton)obj).Name == rbt.Name)
                if (((XRadioButton)obj).Checked == true)
                {
                    ((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
                    ((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                    ((XRadioButton)obj).ImageIndex = 1;

                    if (!((XRadioButton)obj).Checked)
                        ((XRadioButton)obj).Checked = true;

                    grdOCS0301.ClearFilter();

                    //현재선택된 row trans			
                    for (int i = 0; i < grdOCS0301.RowCount; i++)
                    {
                        if (grdOCS0301.GetItemString(i, "select") == "Y")
                            dloSelectOCS0301.LayoutTable.ImportRow(grdOCS0301.LayoutTable.Rows[i]);
                    }

                    //현재선택된 row trans			
                    for (int i = 0; i < grdOCS0303.RowCount; i++)
                    {
                        if (grdOCS0303.GetItemString(i, "select") == "Y")
                            InsertBackTable(grdOCS0303.LayoutTable.Rows[i]);
                    }

                    string isGrantNur = "%";

                    if (((XRadioButton)obj).Tag.ToString() == "GWA")
                    {
                        //this.pnlMemb_1.Visible = true;
                        //this.lblGwaDoctor.Text = "診療科";
                        //this.fbxDoctor.Visible = false;
                        //this.dbxDoctor_name.Visible = false;
                        //this.cboGwa.Visible = true;

                        //if (cboGwa.SelectedIndex >= 0)
                        //    mMemb = cboGwa.GetDataValue();
                        //else
                        //    mMemb = "";

                        isGrantNur = "Y";

                    }
                    else if (((XRadioButton)obj).Tag.ToString() == "DOCTOR")
                    {
                        //this.pnlMemb_1.Visible = true;
                        //lblGwaDoctor.Text = "医師";
                        //this.fbxDoctor.Visible = true;

                        //주치의 자동세팅
                        //this.fbxDoctor.SetEditValue(mDoctor);
                        //this.fbxDoctor.AcceptData();

                        //this.dbxDoctor_name.Visible = true;
                        //this.cboGwa.Visible = false;

                        //mMemb = fbxDoctor.GetDataValue();

                        isGrantNur = "Y";
                    }
                    else if ((((XRadioButton)obj).Tag.ToString() == "ADMIN"))
                    {
                        //병원공통세트의 경우 의사가 아닌 경우는 간호오더가 가능한 세트만 보여 주도록 한다.
                        if (!IsDoctor(mMemb))
                            isGrantNur = "Y";
                        else
                            isGrantNur = "%";

                        mMemb = ((XRadioButton)obj).Tag.ToString();
                    }
                    else
                    {
                        //this.pnlMemb_1.Visible = false;
                        mMemb = ((XRadioButton)obj).Tag.ToString();
                    }
                     

                    grdOCS0301.SetBindVarValue("memb", mMemb);
                    grdOCS0301.SetBindVarValue("yaksok_code", "");
                    //grdOCS0301.SetBindVarValue("grant_nur", isGrantNur);
                    //grdOCS0301.QueryLayout(true);
                    grdOCS0321.QueryLayout(true);

                }
                else
                {
                    ((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                    ((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                    ((XRadioButton)obj).ImageIndex = 0;

                    if (((XRadioButton)obj).Checked)
                        ((XRadioButton)obj).Checked = false;
                }
            }
        }
        #endregion

        #region [TreeView 약속처방구분]

        private void ShowOCS0300()
        {
            tvwOCS0300.Nodes.Clear();
            if (grdOCS0301.RowCount < 1) return;

            string pk_seq = "";
            string pk_input_gubun = "";
            int rowNum = 0;
            int node1 = -1, node2 = -1, node3 = -1;
            TreeNode node;

            foreach (DataRow row in grdOCS0301.LayoutTable.Rows)
            {
                if (pk_input_gubun != row["input_tab_name"].ToString())
                {
                    node = new TreeNode(row["input_tab_name"].ToString());
                    //node.Tag = row["pk_seq"].ToString();
                    tvwOCS0300.Nodes.Add(node);
                    pk_input_gubun = row["input_tab_name"].ToString();
                    row["node1"] = -1;
                    row["node2"] = -1;
                    row["node3"] = -1;
                    node1 = node1 + 1;
                    node2 = -1;
                    node3 = -1;
                }


                if (pk_seq != row["pk_seq"].ToString())
                {
                    node = new TreeNode(row["yaksok_gubun_name"].ToString());
                    node.Tag = row["pk_seq"].ToString();
                    //tvwOCS0300.Nodes.Add(node);
                    tvwOCS0300.Nodes[tvwOCS0300.Nodes.Count - 1].Nodes.Add(node);
                    pk_seq = row["pk_seq"].ToString();

                    node2 = node2 + 1;
                    node3 = -1;


                }

                node = new TreeNode(row["yaksok_name"].ToString());
                node.Tag = rowNum;

                if (row["select"].ToString() == "Y")
                {
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                }
                else
                {
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                }

                tvwOCS0300.Nodes[tvwOCS0300.Nodes.Count - 1].Nodes[tvwOCS0300.Nodes[tvwOCS0300.Nodes.Count - 1].Nodes.Count - 1].Nodes.Add(node);
                node3 = node3 + 1;
                row["node1"] = node1;
                row["node2"] = node2;
                row["node3"] = node3;

                rowNum++;
            }

            //tvwOCS0300.Nodes.Clear();
            //if (grdOCS0301.RowCount < 1) return;

            //string pk_seq = "";
            //int rowNum = 0;
            //int node1 = -1, node2 = -1;
            //TreeNode node;

            //foreach (DataRow row in grdOCS0301.LayoutTable.Rows)
            //{
            //    if (pk_seq != row["pk_seq"].ToString())
            //    {
            //        node = new TreeNode(row["yaksok_gubun_name"].ToString());
            //        node.Tag = row["pk_seq"].ToString();
            //        tvwOCS0300.Nodes.Add(node);
            //        pk_seq = row["pk_seq"].ToString();

            //        row["node1"] = -1;
            //        row["node1"] = -1;
            //        node1 = node1 + 1;
            //        node2 = -1;
            //    }

            //    node = new TreeNode(row["yaksok_name"].ToString());
            //    node.Tag = rowNum;

            //    if (row["select"].ToString() == "Y")
            //    {
            //        node.ImageIndex = 1;
            //        node.SelectedImageIndex = 1;
            //    }
            //    else
            //    {
            //        node.ImageIndex = 0;
            //        node.SelectedImageIndex = 0;
            //    }

            //    tvwOCS0300.Nodes[tvwOCS0300.Nodes.Count - 1].Nodes.Add(node);
            //    node2 = node2 + 1;
            //    row["node1"] = node1;
            //    row["node2"] = node2;

            //    rowNum++;
            //}

            foreach(TreeNode parentNode in this.tvwOCS0300.Nodes)
            {
                foreach (TreeNode childNode in parentNode.Nodes)
                {
                    if (childNode.ImageIndex == 1)
                    {
                        parentNode.Expand();
                        break;
                    }
                    
                }
            }

        }

        private void ShowOCS0320(XEditGrid aGrid, string aSelectedPkSeq)
        {
            this.tvwOCS0300.Nodes.Clear();
            Hashtable parentNodeInfo;
            Hashtable childNodeInfo;
            TreeNode parentNode = new TreeNode();
            TreeNode childNode;

            string currentParent = "";


            foreach (DataRow dr in this.grdOCS0321.LayoutTable.Rows)
            {
                if (currentParent != dr["pkocs0320"].ToString())
                {
                    parentNode = new TreeNode(dr["page_name"].ToString(), 2, 3);
                    parentNodeInfo = new Hashtable();
                    parentNodeInfo.Add("pkocs0320", dr["pkocs0320"].ToString());
                    parentNode.Tag = parentNodeInfo;

                    //childNode = new TreeNode(dr["part_name"].ToString(), 0, 1);
                    //childNodeInfo = new Hashtable();
                    //childNodeInfo.Add("pkocs0320", dr["pkocs0320"].ToString());
                    //childNodeInfo.Add("pkocs0321", dr["pkocs0321"].ToString());
                    //childNode.Tag = childNodeInfo;

                    //parentNode.Nodes.Add(childNode);

                    tvwOCS0300.Nodes.Add(parentNode);

                    currentParent = dr["pkocs0320"].ToString();
                }
                //else
                //{
                //    childNode = new TreeNode(dr["part_name"].ToString(), 0, 1);
                //    childNodeInfo = new Hashtable();
                //    childNodeInfo.Add("pkocs0320", dr["pkocs0320"].ToString());
                //    childNodeInfo.Add("pkocs0321", dr["pkocs0321"].ToString());
                    
                //    childNode.Tag = childNodeInfo;

                //    parentNode.Nodes.Add(childNode);
                //}
            }


            //tvwOCS0300.Nodes.Clear();
            //if (grdOCS0321.RowCount < 1) return;

            //string pkocs0321 = "";
            //string pkocs0320 = "";
            //int rowNum = 0;
            //TreeNode node;
            //Hashtable nodeInfo;
            //TreeNode selectedNode = null;

            //for (int i = 0; i < aGrid.RowCount; i++)
            //{
            //    nodeInfo = new Hashtable();

            //    foreach (DataColumn cl in aGrid.LayoutTable.Columns)
            //    {
            //        nodeInfo.Add(cl.ColumnName, aGrid.GetItemString(i, cl.ColumnName));
            //    }
            //    nodeInfo.Add("row_number", i);

            //    node = new TreeNode(aGrid.GetItemString(i, "page_name"));
            //    node.Tag = nodeInfo;

            //    tvwOCS0300.Nodes.Add(node);

            //    //pkocs0320 = row["pkocs0320"].ToString();
                
            //    //if (pkocs0321 != row["pkocs0321"].ToString())
            //    //{
            //    //    node = new TreeNode(row["gubun_name"].ToString());
            //    //    node.Tag = row["pkocs0321"].ToString();
            //    //    tvwOCS0300.Nodes[tvwOCS0300.Nodes.Count - 1].Nodes.Add(node);
            //    //    pkocs0321 = row["pkocs0321"].ToString();

            //    //}

            //    //tvwOCS0300.Nodes[tvwOCS0300.Nodes.Count - 1].Nodes[tvwOCS0300.Nodes[tvwOCS0300.Nodes.Count - 1].Nodes.Count - 1].Nodes.Add(node);
            //    //rowNum++;
            //}

            //foreach (TreeNode parentNode in this.tvwOCS0300.Nodes)
            //{
            //    foreach (TreeNode childNode in parentNode.Nodes)
            //    {
            //        if (childNode.ImageIndex == 1)
            //        {
            //            parentNode.Expand();
            //            break;
            //        }

            //    }
            //}

        }
        private void resetOCS0323Data()
        {
            this.grdOCS0323_1.Reset();
            this.grdOCS0323_2.Reset();
            this.grdOCS0323_3.Reset();
            this.grdOCS0323_4.Reset();
            this.grdOCS0323_5.Reset();
            this.grdOCS0323_6.Reset();
            this.grdOCS0323_7.Reset();
            this.grdOCS0323_8.Reset();
            this.grdOCS0323_9.Reset();
        }

        private void setCheckFromOCS0103U13(XEditGrid grdOrder)
        {
            for (int i = 0; i < grdOrder.RowCount; i++)
            {
                for (int j = 0; j < this.mInOrderData.Rows.Count; j++)
                {
                    if (grdOrder.GetItemString(i, "hangmog_code") == this.mInOrderData.Rows[j]["hangmog_code"].ToString())
                    {
                        grdOrder.SetItemValue(i, "select", "Y");
                    }
                }
            }
            //dloSelectOCS0303.LayoutTable.Select(" pk_yaksok = '" + pk_yaksok + "' ", "");
            //dloSelectOCS0303.LayoutTable.LoadDataRow();

        }
        private void tvwOCS0300_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //modify by jc [NodeLevel3でイベントが起きるように修正]
            //if (tvwOCS0300.SelectedNode.Parent == null) return;
            //if (tvwOCS0300.SelectedNode.Parent == null || tvwOCS0300.SelectedNode.Level < 1) return;
            int maxNum = 30;
            string currentOCS0321 = "";
            XEditGrid grd = null;
            int grdcnt = 1;
            int cnt = 0;
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                this.layOCS0323.QueryLayout(false);
                this.resetOCS0323Data();

                foreach(DataRow dr in this.layOCS0323.LayoutTable.Rows)
                {
                    if (cnt != 0 && currentOCS0321 != dr["fkocs0321"].ToString())
                    {
                        grdcnt++;
                        cnt = 0;
                    }

                    switch (grdcnt)
                    {
                        case 1: 
                            grd = this.grdOCS0323_1;
                            
                            break;
                        case 2: 
                            grd = this.grdOCS0323_2; 
                            break;
                        case 3: 
                            grd = this.grdOCS0323_3; 
                            break;
                        case 4: 
                            grd = this.grdOCS0323_4; 
                            break;
                        case 5: 
                            grd = this.grdOCS0323_5; 
                            break;
                        case 6: 
                            grd = this.grdOCS0323_6; 
                            break;
                        case 7: 
                            grd = this.grdOCS0323_7; 
                            break;
                        case 8: 
                            grd = this.grdOCS0323_8; 
                            break;
                        case 9: 
                            grd = this.grdOCS0323_9; 
                            break;
                    }
                    if (cnt % 30 == 0)
                    {
                        grd.CellInfos["hangmog_name"].HeaderText = dr["part_name"].ToString();
                        grd.InitializeColumns();
                    }
                    grd.LayoutTable.ImportRow(dr);
                    currentOCS0321 = dr["fkocs0321"].ToString();
                    cnt++;

                    if (cnt % 30 == 0)
                    {
                        grdcnt++;
                    }

                    
                }

                //foreach(DataRow dr in this.layOCS0323.LayoutTable.Rows)
                //    this.grdOCS0323_1.LayoutTable.ImportRow(dr);
                //this.grdOCS0323_1.DisplayData();
                //this.grdOCS0323_2.DisplayData();
                //this.grdOCS0323_3.DisplayData();
                //this.grdOCS0323_4.DisplayData();
                //this.grdOCS0323_5.DisplayData();
                //this.grdOCS0323_6.DisplayData();
                //this.grdOCS0323_7.DisplayData();
                //this.grdOCS0323_8.DisplayData();
                //this.grdOCS0323_9.DisplayData();

                //SelectionBackColorChange(grdOCS0323_1);
                //SelectionBackColorChange(grdOCS0323_2);
                //SelectionBackColorChange(grdOCS0323_3);
                //SelectionBackColorChange(grdOCS0323_4);
                //SelectionBackColorChange(grdOCS0323_5);
                //SelectionBackColorChange(grdOCS0323_6);
                //SelectionBackColorChange(grdOCS0323_7);
                //SelectionBackColorChange(grdOCS0323_8);
                //SelectionBackColorChange(grdOCS0323_9);
                //////현재선택된 row trans			
                //for (int i = 0; i < grdOCS0323_1.RowCount; i++)
                //{
                //    if (grdOCS0323_1.GetItemString(i, "select") == "Y")
                //        InsertBackTable(grdOCS0323_1.LayoutTable.Rows[i]);
                //}


                //this.grdOCS0323.QueryLayout(true);    
                ////grdOCS0321.SetFocusToItem(int.Parse(tvwOCS0300.SelectedNode.Tag.ToString()), 1);

            }
            finally
            {
                //this.grdOCS0323_1.DisplayData();
                //this.grdOCS0323_2.DisplayData();
                //this.grdOCS0323_3.DisplayData();
                //this.grdOCS0323_4.DisplayData();
                //this.grdOCS0323_5.DisplayData();
                //this.grdOCS0323_6.DisplayData();
                //this.grdOCS0323_7.DisplayData();
                //this.grdOCS0323_8.DisplayData();
                //this.grdOCS0323_9.DisplayData();

                //SelectionBackColorChange(grdOCS0323_1);
                //SelectionBackColorChange(grdOCS0323_2);
                //SelectionBackColorChange(grdOCS0323_3);
                //SelectionBackColorChange(grdOCS0323_4);
                //SelectionBackColorChange(grdOCS0323_5);
                //SelectionBackColorChange(grdOCS0323_6);
                //SelectionBackColorChange(grdOCS0323_7);
                //SelectionBackColorChange(grdOCS0323_8);
                //SelectionBackColorChange(grdOCS0323_9);
                

                for (int i = 1; i <= 9; i++)
                {
                    switch (i)
                    {
                        case 1: grd = this.grdOCS0323_1; break;
                        case 2: grd = this.grdOCS0323_2; break;
                        case 3: grd = this.grdOCS0323_3; break;
                        case 4: grd = this.grdOCS0323_4; break;
                        case 5: grd = this.grdOCS0323_5; break;
                        case 6: grd = this.grdOCS0323_6; break;
                        case 7: grd = this.grdOCS0323_7; break;
                        case 8: grd = this.grdOCS0323_8; break;
                        case 9: grd = this.grdOCS0323_9; break;
                    }
                    grd.DisplayData();

                    if(this.mInOrderData != null)
                        this.setCheckFromOCS0103U13(grd);

                    this.SelectionBackColorChange(grd);
                    ////현재선택된 row trans			
                    for (int ii = 0; ii < grd.RowCount; ii++)
                    {
                        if (grd.GetItemString(ii, "select") == "Y")
                            InsertBackTable(grd.LayoutTable.Rows[ii]);
                    }
                    
                }


                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }

            ////modify by jc [NodeLevel3でイベントが起きるように修正]
            ////if (tvwOCS0300.SelectedNode.Parent == null) return;
            //if (tvwOCS0300.SelectedNode.Parent == null || tvwOCS0300.SelectedNode.Level < 2) return;

            //try
            //{
            //    Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            //    grdOCS0301.SetFocusToItem(int.Parse(tvwOCS0300.SelectedNode.Tag.ToString()), 1);

            //}
            //finally
            //{
            //    Cursor.Current = System.Windows.Forms.Cursors.Default;
            //}

        }

        bool isMouseDown = false;
        private void tvwOCS0300_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                isMouseDown = true;
                if (tvwOCS0300.GetNodeAt(new Point(e.X, e.Y)) == null || tvwOCS0300.GetNodeAt(new Point(e.X, e.Y)).Parent == null) return;

                if (mMemb == UserInfo.YaksokOpenID || TypeCheck.IsNull(UserInfo.YaksokOpenID)) return;
                //PopUp Menu Show
                tvwOCS0300.SelectedNode = tvwOCS0300.GetNodeAt(new Point(e.X, e.Y));
                popupSetOrderCopy.TrackPopup(tvwOCS0300.PointToScreen(new Point(e.X, e.Y)));

                isMouseDown = false;
            }
            //delete by yoonB [ダブルクリックでチェックされるロジック削除] 2012/03/23
            //else if (e.Button == MouseButtons.Left && e.Clicks == 2)
            //{
            //    if (tvwOCS0300.SelectedNode.Level > 1)
            //    {
            //        if (tvwOCS0300.GetNodeAt(new Point(e.X, e.Y)) == null || tvwOCS0300.GetNodeAt(new Point(e.X, e.Y)).Parent == null) return;
            //        tvwOCS0300.SelectedNode = tvwOCS0300.GetNodeAt(new Point(e.X, e.Y));

            //        if ((tvwOCS0300.SelectedNode == null) || (tvwOCS0300.SelectedNode.Parent == null)) return;

            //        TreeNode node = tvwOCS0300.GetNodeAt(new Point(e.X, e.Y));

            //        if (node.ImageIndex == 1)
            //        {
            //            //DeleteRow
            //            node.ImageIndex = 0;
            //            node.SelectedImageIndex = 0;
            //            DeleteRow("%");
            //        }
            //        else
            //        {
            //            node.ImageIndex = 1;
            //            node.SelectedImageIndex = 1;
            //            SelectRow("%");
            //        }
            //    }
            //}
        }



        #endregion

        #region [Combo 생성]

        private void CreateCombo()
        {
            DataTable dtTemp;

            // DV_TIME
            dtTemp = this.mOrderBiz.LoadComboDataSource("dv_time").LayoutTable;
            this.grdOCS0303.SetComboItems("dv_time", dtTemp, "code_name", "code", XComboSetType.NoAppend);

            // 이동촬영여부
            dtTemp = this.mOrderBiz.LoadComboDataSource("portable_yn").LayoutTable;
            this.grdOCS0303.SetComboItems("portable_yn", dtTemp, "code_name", "code", XComboSetType.NoAppend);

            //급여여부
            dtTemp = this.mOrderBiz.LoadComboDataSource("pay").LayoutTable;
            this.grdOCS0303.SetComboItems("pay", dtTemp, "code_name", "code", XComboSetType.NoAppend);

            // 주사스피드구분
            dtTemp = this.mOrderBiz.LoadComboDataSource("jusa_spd_gubun").LayoutTable;
            this.grdOCS0303.SetComboItems("jusa_spd_gubun", dtTemp, "code_name", "code", XComboSetType.AppendNone);

            //CreateGwaCombo();

        }

        #endregion

        #region [Control Event]

        private void txtSearchSetName_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //			//현재선택된 row trans			
            //			for(int i = 0; i < grdOCS0301.RowCount; i++)
            //			{
            //				if(grdOCS0301.GetItemString(i, "select") == " ")
            //					dloSelectOCS0301.LayoutTable.ImportRow(grdOCS0301.LayoutTable.Rows[i]);
            //			}
            //
            //			//현재선택된 row trans			
            //			for(int i = 0; i < grdOCS0303.RowCount; i++)
            //			{
            //				if(grdOCS0303.GetItemString(i, "select") == " ")
            //					dloSelectOCS0303.LayoutTable.ImportRow(grdOCS0303.LayoutTable.Rows[i]);
            //			}	
            //
            //			dsvLDOCS0301.ExhaustiveCall(true);

            grdOCS0301.ClearFilter();

            if (!TypeCheck.IsNull(txtSearchSetName.GetDataValue().Trim()))
            {
                if (grdOCS0301.RowCount > 0)
                    grdOCS0301.SetFilter(" yaksok_name like '%" + txtSearchSetName.GetDataValue().Trim() + "%'");
            }

            //if (grdOCS0301.CurrentRowNumber >= 0 && grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "select_sang") == "Y")
            //    lblSelectSang.ImageIndex = 1;
            //else
            //    lblSelectSang.ImageIndex = 0;

            ShowOCS0300();

        }

        //private void lblSelectOrder_Click(object sender, System.EventArgs e)
        //{
        //    if (lblSelectOrder.ImageIndex == 0)
        //    {
        //        if (grdSelectAll(grdOCS0303, true))
        //        {
        //            lblSelectOrder.ImageIndex = 1;
        //            lblSelectOrder.Text = " 全体選択取消";
        //        }
        //    }
        //    else
        //    {
        //        if (grdSelectAll(grdOCS0303, false))
        //        {
        //            lblSelectOrder.ImageIndex = 0;
        //            lblSelectOrder.Text = " 全体選択";
        //        }
        //    }
        //}

        //private void lblSelectSang_Click(object sender, System.EventArgs e)
        //{
        //    if (lblSelectSang.ImageIndex == 0)
        //    {
        //        lblSelectSang.ImageIndex = 1;
        //        if (grdOCS0301.CurrentRowNumber >= 0)
        //            grdOCS0301.SetItemValue(grdOCS0301.CurrentRowNumber, "select_sang", "Y");

        //    }
        //    else
        //    {
        //        lblSelectSang.ImageIndex = 0;
        //        if (grdOCS0301.CurrentRowNumber >= 0)
        //            grdOCS0301.SetItemValue(grdOCS0301.CurrentRowNumber, "select_sang", "N");
        //    }

        //    //선택된 row 표시
        //    SetSelectYaksok();
        //}

        /// <summary>
        /// 해당 Grid 전체선택 해제
        /// </summary>
        /// <param name="grd"></param>
        /// <param name="select"></param>
        //private bool grdSelectAll(XGrid grdObject, bool select)
        //{
        //    int rowIndex = -1;

        //    if (select)
        //    {
        //        for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
        //        {
        //            /*
        //            //의사인 경우 order 권한 Check한다.
        //            if (UserInfo.UserGubun == UserType.Doctor)
        //            {
        //                if (!this.mOrderBiz.CheckOrderAuthority(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), UserInfo.Gwa, UserInfo.UserID))
        //                {
        //                    mbxMsg = NetInfo.Language == LangMode.Jr ? "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "】の入力権限がありません。確認してください。" : "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "】오더에 대해서 입력권한이 없습니다. 확인바랍니다.";
        //                    mbxCap = NetInfo.Language == LangMode.Jr ? "入力権限" : "입력권한";
        //                    XMessageBox.Show(mbxMsg, mbxCap);
        //                    continue;
        //                }
        //            }

        //            //환자별 특수약제
        //            if (!TypeCheck.IsNull(mBunho) && this.mOrderBiz.CheckSpecialDrugForPatient(mBunho, grdObject.GetItemString(rowIndex, "hangmog_code"), grdObject.GetItemString(rowIndex, "hangmog_name")))
        //                continue;

        //            //자식일 경우
        //            string insertYN = string.Empty;
        //            if (this.mChildYN == "Y")
        //            {
        //                //자식입력여부로드
        //                if (this.mHangmogInfo.LoadChildInsertYN(grdObject.GetItemString(rowIndex, "hangmog_code"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), ref insertYN))
        //                {
        //                    if (insertYN != "Y") continue;
        //                }
        //            }
        //            else
        //            {
        //                //자식일 경우는 스킵
        //                if (grdObject.GetItemString(rowIndex, "child_gubun") != "3")
        //                {
        //                    //단독입력여부로드
        //                    if (this.mHangmogInfo.LoadDandokInsertYN(grdObject.GetItemString(rowIndex, "hangmog_code"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), "%", grdObject.GetItemString(rowIndex, "order_gubun").Substring(1, 1), ref insertYN))
        //                    {
        //                        if (insertYN != "Y") continue;
        //                    }
        //                }
        //            }
        //             //*/

        //            if (grdObject.GetItemString(rowIndex, "bulyong_check") != "Y") grdObject.SetItemValue(rowIndex, "select", " ");
        //        }
        //    }
        //    else
        //    {
        //        for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
        //        {
        //            if (grdObject.GetItemString(rowIndex, "bulyong_check") != "Y") grdObject.SetItemValue(rowIndex, "select", "");
        //        }
        //    }

        //    SelectionBackColorChange(grdObject);

        //    //선택된 row 표시
        //    SetSelectYaksok();
        //    return true;

        //}

        private void btnProcess_Click(object sender, System.EventArgs e)
        {
            // 현재 로우를 반영한다.
            //현재선택된 row trans			
            //for (int i = 0; i < grdOCS0303.RowCount; i++)
            //{
            //    if (grdOCS0303.GetItemString(i, "select") == "Y")
            //        InsertBackTable(grdOCS0303.LayoutTable.Rows[i]);
            //}
            //for (int i = 0; i < grdOCS0303.RowCount; i++)
            //{
            //    if (grdOCS0303.GetItemString(i, "select") == "Y")
            //        InsertBackTable(grdOCS0303.LayoutTable.Rows[i]);
            //}

            CreateReturnLayout();
        }

        private void chkIsNewGroup_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkIsNewGroup.Checked)
            {
                chkIsNewGroup.BackColor = System.Drawing.SystemColors.ActiveCaption;
                chkIsNewGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                chkIsNewGroup.ImageIndex = 1;
                //mIsNewGroupSer = true;

            }
            else
            {
                chkIsNewGroup.BackColor = System.Drawing.SystemColors.InactiveCaption;
                chkIsNewGroup.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                chkIsNewGroup.ImageIndex = 0;
                //mIsNewGroupSer = false;
            }
        }


        #endregion

        #region [DataService Event]

        private void grdOCS0301_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            ///이전에 선택한 약속코드가 있으면 선택상태로
            foreach (DataRow row in dloSelectOCS0301.LayoutTable.Select(" memb = '" + mMemb + "' ", ""))
            {
                for (int i = 0; i < grdOCS0301.RowCount; i++)
                {
                    if (grdOCS0301.GetItemString(i, "pk_seq") == row["pk_seq"].ToString() &&
                        grdOCS0301.GetItemString(i, "yaksok_code") == row["yaksok_code"].ToString())
                    {
                        grdOCS0301.SetItemValue(i, "select", "Y");
                        //grdOCS0301.SetItemValue(i, "select_sang", row["select_sang"].ToString());
                    }
                }
            }

            ////이전 선택정보를 삭제한다.
            //for (int i = 0; i < dloSelectOCS0301.RowCount; i++)
            //{
            //    if (dloSelectOCS0301.GetItemString(i, "memb") == mMemb)
            //    {
            //        dloSelectOCS0301.LayoutTable.Rows.Remove(dloSelectOCS0301.LayoutTable.Rows[i]);
            //        i = i - 1;
            //    }
            //}

            if (!TypeCheck.IsNull(txtSearchSetName.GetDataValue().Trim()))
                grdOCS0301.SetFilter(" yaksok_name like '%" + txtSearchSetName.GetDataValue().Trim() + "%'");

            ShowOCS0300();

            if (this.grdOCS0301.RowCount == 0)
                this.grdOCS0303.Reset();
        }

        private void grdOCS0303_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            string pk_yaksok = grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "pk_yaksok");

            ///이전에 선택한 약속처방이 있으면 선택상태로
            foreach (DataRow row in dloSelectOCS0303.LayoutTable.Select(" pk_yaksok = '" + pk_yaksok + "' ", ""))
            {
                for (int i = 0; i < grdOCS0303.RowCount; i++)
                {
                    if (grdOCS0303.GetItemString(i, "pkocs0303") == row["pkocs0303"].ToString())
                    {
                        //一般名の最新情報で更新
                        //if (grdOCS0303.GetItemString(i, "general_disp_yn") == "Y")
                        //    this.dloSelectOCS0303.SetItemValue(i, "hangmog_name", this.grdOCS0303.GetItemString(i, "generic_name"));
                        //else
                        //    this.dloSelectOCS0303.SetItemValue(i, "hangmog_name", this.grdOCS0303.GetItemString(i, "hangmog_name"));
                        
                        //값 setting
                        foreach (XEditGridCell cell in grdOCS0303.CellInfos)
                        {
                            //if(cell.CellName == "select")
                            //checkplz

                            if (cell.CellName == "hangmog_name" && this.cbxGeneric_YN.GetDataValue() == "Y" && grdOCS0303.GetItemString(i, "general_disp_yn") == "Y")
                            {
                                string generic_name = mHangmogInfo.GetGenericName(grdOCS0303.GetItemString(i, "hangmog_code"));

                                if (generic_name != "")
                                {
                                    grdOCS0303.SetItemValue(i, "hangmog_name", generic_name);
                                }
                            }
                            else if (cell.CellName == "hangmog_name" && this.cbxGeneric_YN.GetDataValue() == "N" && grdOCS0303.GetItemString(i, "general_disp_yn") == "N")
                            {
                                string hangmog_name = mHangmogInfo.GetHangmogName(grdOCS0303.GetItemString(i, "hangmog_code"));

                                if (hangmog_name != "")
                                {
                                    grdOCS0303.SetItemValue(i, "hangmog_name", hangmog_name);
                                }
                            }
                            else
                                grdOCS0303.SetItemValue(i, cell.CellName, row[cell.CellName]);
                            //if(cell.CellName == "hangmog_name")
                            //    mOrderBiz.
                            //    grdOCS0303.SetItemValue(i, cell.CellName, row[cell.CellName]);
                            //else
                            //    grdOCS0303.SetItemValue(i, cell.CellName, row[cell.CellName]);
                        }
                    }
                }
            }

            //이전 선택정보를 삭제한다.
            //for (int i = 0; i < dloSelectOCS0303.RowCount; i++)
            //{
            //    if (dloSelectOCS0303.GetItemString(i, "pk_yaksok") == pk_yaksok)
            //    {
            //        dloSelectOCS0303.LayoutTable.Rows.Remove(dloSelectOCS0303.LayoutTable.Rows[i]);
            //        i = i - 1;
            //    }
            //}

            SelectionBackColorChange(grdOCS0303);

            //MakeGroupTab(this.grdOCS0303);

        }

        private void MakeGroupTab(XEditGrid aGrid)
        {
            string currentGroupSer = "";
            string title = "";
            IHIS.X.Magic.Controls.TabPage tpgGroup;

            this.tabGroupSerial.SelectionChanged -= new EventHandler(tabGroupSerial_SelectionChanged);

            // 탭페이지 클리어
            try
            {
                this.tabGroupSerial.TabPages.Clear();
            }
            catch
            {
                this.tabGroupSerial.Refresh();
            }

            bool isSelected = false;
            for (int i = 0; i < aGrid.RowCount; i++)
            {
                isSelected = false;
                if (currentGroupSer != aGrid.GetItemString(i, "group_ser"))
                {
                    if (aGrid.GetItemString(i, "input_tab") == "01") // 약인경우는 그룹탭에 복용법을 같이 보여준다.
                    {
                        title = aGrid.GetItemString(i, "group_ser") + " グループ : " + aGrid.GetItemString(i, "bogyong_name");
                    }
                    else
                    {
                        title = aGrid.GetItemString(i, "group_ser") + " グループ";
                    }
                    if (aGrid.GetItemString(i, "select") == "Y")
                        isSelected = true;

                    tpgGroup = new IHIS.X.Magic.Controls.TabPage(title);
                    tpgGroup.ImageList = this.ImageList;
                    if (isSelected)
                        tpgGroup.ImageIndex = 1;
                    else
                        tpgGroup.ImageIndex = 0;

                    tpgGroup.Tag = aGrid.GetItemString(i, "group_ser");

                    this.tabGroupSerial.TabPages.Add(tpgGroup);

                    currentGroupSer = aGrid.GetItemString(i, "group_ser");
                }
            }

            this.tabGroupSerial.SelectionChanged += new EventHandler(tabGroupSerial_SelectionChanged);

            SetTabImage();

            this.tabGroupSerial_SelectionChanged(this.tabGroupSerial, new EventArgs());
        }

        //private void SetTabImage()
        //{
        //    string group_ser = "";

        //    for (int j = 0; j < this.tabGroupSerial.TabPages.Count; j++)
        //    {
        //        tabGroupSerial.TabPages[j].ImageIndex = 0;
        //    }
        //    for (int i = 0; i < this.grdOCS0303.RowCount; i++)
        //    {
        //        if (this.grdOCS0303.GetItemString(i, "select") == "Y")
        //        {
        //            group_ser = this.grdOCS0303.GetItemString(i, "group_ser");

        //            for (int j = 0; j < this.tabGroupSerial.TabPages.Count; j++)
        //            {
        //                if (group_ser == this.tabGroupSerial.TabPages[j].Tag.ToString())
        //                {
        //                    tabGroupSerial.TabPages[j].ImageIndex = 1;
        //                }
        //            }
        //        }
        //    }
        //}

        private void SetTabImage()
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroupSerial.TabPages)
            {
                if (this.IsExistSelectedOrder(tpg.Tag.ToString()) == true)
                {
                    tpg.ImageIndex = 1;
                }
                else
                {
                    tpg.ImageIndex = 0;
                }
            }
        }
        private bool IsExistSelectedOrder(string aGroupSer)
        {
            DataRow[] dr = this.dloSelectOCS0303.LayoutTable.Select("group_ser =" + aGroupSer );

            if (dr.Length > 0) return true;
            
            return false;
        }
        #endregion

        #region [grdOCS0301]

        private void grdOCS0301_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            //현재선택된 row trans			
            for (int i = 0; i < grdOCS0303.RowCount; i++)
            {
                if (grdOCS0303.GetItemString(i, "select") == "Y")
                    InsertBackTable(grdOCS0303.LayoutTable.Rows[i]);
            }


            this.grdOCS0303.QueryLayout(true);
        }

        #endregion

        #region [grdOCS0303]
        private void grdOCS0303_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            //insert by jc [院内採用薬の場合ROWの色を塗る。]
            XEditGrid grid = sender as XEditGrid;

            this.mColumnControl.ColumnColorForCodeQueryGrid(mIOgubun, grid, e);

            if (e.DataRow["bulyong_check"].ToString() == "Y" || e.DataRow["bulyong_check"].ToString() == "Z")
            {
                e.BackColor = ((XEditGridCell)grdOCS0303.CellInfos[e.ColName]).RowBackColor.Color;
                if (e.ColName != "child_gubun")
                    e.ForeColor = Color.Red;
                
            }

            switch (e.ColName)
            {
                case "general_disp_yn":
                    if (this.grdOCS0303.GetItemString(e.RowNumber, e.ColName) == "Y")
                        e.BackColor = Color.Green;
                    else
                        e.BackColor = Color.Transparent;
                    break;
            }

            #region 코드만 화면 Display하는 필드를 명칭으로 ToolTip 처리
            switch (e.ColName)
            {

                case "pay": // 급여
                    grdOCS0303[e.RowNumber, e.ColName].ToolTipText = grdOCS0303.GetItemString(e.RowNumber, "pay_name");
                    break;

                case "bogyong_name": // 급여
                    grdOCS0303[e.RowNumber, e.ColName].ToolTipText = grdOCS0303.GetItemString(e.RowNumber, "bogyong_name") + grdOCS0303.GetItemString(e.RowNumber, "dv_name");
                    break;

                case "jundal_part_out": // 전달부서 외래
                    grdOCS0303[e.RowNumber, e.ColName].ToolTipText = grdOCS0303.GetItemString(e.RowNumber, "jundal_part_out_name");
                    break;

                case "jundal_part_inp": // 전달부서 입원
                    grdOCS0303[e.RowNumber, e.ColName].ToolTipText = grdOCS0303.GetItemString(e.RowNumber, "jundal_part_inp_name");
                    break;

            }
            #endregion

        }

        private void grdOCS0303_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int rowIndex;
            rowIndex = grdOCS0303.GetHitRowNumber(e.Y);
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                //return; //무효처리

                if (rowIndex < 0) return;

                if (grdOCS0303.CurrentColNumber == 0)
                {
                    //불용처리된 것은 선택을 막는다.
                    if (grdOCS0303.GetItemString(rowIndex, "bulyong_check") == "Y")
                    {
                        //불용인 경우에는 해당 항목의 심사기준을 보여준다.
                        mbxMsg = this.mOrderBiz.LoadSimsa_comment(grdOCS0303.GetItemString(rowIndex, "hangmog_code"));
                        mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
                        if (!TypeCheck.IsNull(mbxMsg)) XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);

                        return;
                    }

                    if (this.grdOCS0303.GetItemString(rowIndex, "select") == "Y")
                    {
                        this.grdOCS0303.SetItemValue(rowIndex, "select", "N");
                        SelectionBackColorChange(sender, rowIndex, "N");                        
                        this.RemoveBackTable(this.grdOCS0303.LayoutTable.Rows[rowIndex]);
                    }
                    else
                    {
                        this.grdOCS0303.SetItemValue(rowIndex, "select", "Y");
                        SelectionBackColorChange(sender, rowIndex, "Y");
                        this.InsertBackTable(this.grdOCS0303.LayoutTable.Rows[rowIndex]);
                    }
                    
                    /*
                    //의사인 경우 order 권한 Check한다.
                    if (UserInfo.UserGubun == UserType.Doctor)
                    {
                        if (!this.mOrderBiz.CheckOrderAuthority(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), UserInfo.Gwa, UserInfo.UserID))
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "】の入力権限がありません。確認してください。" : "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "】오더에 대해서 입력권한이 없습니다. 확인바랍니다.";
                            mbxCap = NetInfo.Language == LangMode.Jr ? "入力権限" : "입력권한";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            return;
                        }
                    }

                    //환자별 특수약제
                    if (!TypeCheck.IsNull(mBunho) && this.mOrderBiz.CheckSpecialDrugForPatient(mBunho, grdOCS0303.GetItemString(rowIndex, "hangmog_code"), grdOCS0303.GetItemString(rowIndex, "hangmog_name")))
                        return;

                    if (grdOCS0303.GetItemString(rowIndex, "select") == "")
                    {
                        //2009.12.14 ntt 자식입력에서 호출일 경우 재료만 선택가능하게
                        if (this.mChildYN == "Y")
                        {
                            if (!this.mHangmogInfo.IsChildInsert(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), grdOCS0303.GetItemString(rowIndex, "hangmog_name"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")))
                                return;

                            //자식선택일 경우만 반드시 "3"으로 입력
                            grdOCS0303.SetItemValue(rowIndex, "child_gubun", "3");
                        }
                        else
                        {
                            //체크된 오다가 자식인 경우 부모가 선택되어 있는지 체크하여 메시지 처리
                            if (grdOCS0303.GetItemString(rowIndex, "child_gubun") == "3")
                            {
                                string child_key = grdOCS0303.GetItemString(rowIndex, "child_key");
                                bool isInsertYN = false;
                                for (int i = 0; i < grdOCS0303.RowCount; i++)
                                {
                                    if (grdOCS0303.GetItemString(i, "parents_key") == child_key && grdOCS0303.GetItemString(i, "select") == " ")
                                    {
                                        isInsertYN = true;
                                        break;
                                    }
                                    else
                                        isInsertYN = false;

                                }
                                if (!isInsertYN)
                                {
                                    mbxMsg = NetInfo.Language == LangMode.Jr ? "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "】 選択されたオーダは材料オーダですので先に手技オーダを選択して下さい！確認してください。" : "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "　선택된 오다는 재료오더입니다 먼저 수기오다를 선택하십시오!. 확인바랍니다.";
                                    mbxCap = NetInfo.Language == LangMode.Jr ? "入力権限" : "입력권한";
                                    XMessageBox.Show(mbxMsg, mbxCap);
                                    return;
                                }
                            }
                            else
                            {
                                //단독으로 입력할 수 있는지 체크
                                if (!this.mHangmogInfo.IsDandokInsert(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), grdOCS0303.GetItemString(rowIndex, "hangmog_name"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), "%", grdOCS0303.GetItemString(rowIndex, "order_gubun").Substring(1, 1)))
                                    return;
                            }
                        }

                        grdOCS0303.SetItemValue(rowIndex, "select", " ");
                        SelectionBackColorChange(sender, rowIndex, "Y");
                    }
                    else
                    {
                        grdOCS0303.SetItemValue(rowIndex, "select", "");
                        SelectionBackColorChange(sender, rowIndex, "N");
                    }
                     * */

                    SetSelectYaksok();
                    SetTabImage();
                }
            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (rowIndex < 0) return;

                /*
                //2009.12.14 ntt 자식입력에서 호출일 경우 재료만 선택가능하게
                if (this.mChildYN == "Y")
                {
                    if (!this.mHangmogInfo.IsChildInsert(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), grdOCS0303.GetItemString(rowIndex, "hangmog_name"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")))
                        return;

                    //자식선택일 경우만 반드시 "3"으로 입력
                    grdOCS0303.SetItemValue(rowIndex, "child_gubun", "3");
                }
                else
                {
                    //단독입력가능여부 체크
                    if (grdOCS0303.GetItemString(rowIndex, "child_gubun") != "3")
                    {
                        if (!this.mHangmogInfo.IsDandokInsert(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), grdOCS0303.GetItemString(rowIndex, "hangmog_name"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), "%", grdOCS0303.GetItemString(rowIndex, "order_gubun").Substring(1, 1)))
                            return;
                    }
                }
                * */
 
                //CreateReturnLayout();
            }
            else if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                rowIndex = grdOCS0303.GetHitRowNumber(e.Y);
                if (rowIndex < 0) return;

                if (grdOCS0303.GetItemString(rowIndex, "slip_code").Substring(0, 1) != "B") return;

                popupMenu.TrackPopup(((IHIS.Framework.XEditGrid)sender).PointToScreen(new Point(e.X, e.Y)));
            }

        }

        private void InsertBackTable(DataRow dr)
        {
            //DataRow[] rows = this.dloSelectOCS0303.LayoutTable.Select("pkocs0303=" + dr["pkocs0303"].ToString());
            //if(rows.Length < 1)
            //    this.dloSelectOCS0303.LayoutTable.ImportRow(dr);
            DataRow[] rows = this.dloSelectOCS0303.LayoutTable.Select("pkocs0323=" + dr["pkocs0323"].ToString());
            if (rows.Length < 1)
                this.dloSelectOCS0303.LayoutTable.ImportRow(dr);
        }

        private void RemoveBackTable(DataRow dr)
        {
            //DataRow[] rows = this.dloSelectOCS0303.LayoutTable.Select("pkocs0303=" + dr["pkocs0303"].ToString());
            //foreach (DataRow row in rows)
            //    this.dloSelectOCS0303.LayoutTable.Rows.Remove(row);
            DataRow[] rows = this.dloSelectOCS0303.LayoutTable.Select("pkocs0323=" + dr["pkocs0323"].ToString());
            foreach (DataRow row in rows)
                this.dloSelectOCS0303.LayoutTable.Rows.Remove(row);
        }

        private void grdOCS0303_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
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

        #region [ButtonList]

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                default:

                    break;
            }
        }

        #endregion

        #region [Fuction]

        //private void DetailSelect(bool select)
        //{
        //    if (select)
        //    {
        //        // Detail 전체 Select
        //        // OCS0303
        //        for (int i = 0; i < grdOCS0303.RowCount; i++)
        //        {
        //            grdOCS0303.SetItemValue(i, "select", " ");
        //        }

        //        SelectionBackColorChange(grdOCS0303);
        //    }
        //    else
        //    {
        //        // Detail 전체 Select
        //        // OCS0303
        //        for (int i = 0; i < grdOCS0303.RowCount; i++)
        //        {
        //            grdOCS0303.SetItemValue(i, "select", "");
        //        }

        //        SelectionBackColorChange(grdOCS0303);
        //    }
        //}

        private void SetSelectYaksok()
        {
            int currentRow = grdOCS0301.CurrentRowNumber;
            bool select = false;
            
            //modify by jc
            //int node1 = -1, node2 = -1;
            int node1 = -1, node2 = -1, node3 = -1;

            if (grdOCS0301.CurrentRowNumber < 0) return;

            //if (grdOCS0301.CurrentRowNumber >= 0)
            //{
            //    //if (grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "select_sang") == "Y")
            //        select = true;
            //}

            // OCS1003
            if (!select)
            {
                for (int i = 0; i < grdOCS0303.RowCount; i++)
                {
                    if (grdOCS0303.GetItemString(i, "select") != "Y") continue;
                    select = true;
                    break;
                }
            }

            if (select)
            {
                grdOCS0301.SetItemValue(currentRow, "select", "Y");
                //SelectionBackColorChange(grdOCS0301, currentRow, "Y");

                //modify by jc
                //node1 = int.Parse(grdOCS0301.GetItemString(currentRow, "node1"));
                //node2 = int.Parse(grdOCS0301.GetItemString(currentRow, "node2"));
                //tvwOCS0300.Nodes[node1].Nodes[node2].ImageIndex = 1;
                //tvwOCS0300.Nodes[node1].Nodes[node2].SelectedImageIndex = 1;
                node1 = int.Parse(grdOCS0301.GetItemString(currentRow, "node1"));
                node2 = int.Parse(grdOCS0301.GetItemString(currentRow, "node2"));
                node3 = int.Parse(grdOCS0301.GetItemString(currentRow, "node3"));
                tvwOCS0300.Nodes[node1].Nodes[node2].Nodes[node3].ImageIndex = 1;
                tvwOCS0300.Nodes[node1].Nodes[node2].Nodes[node3].SelectedImageIndex = 1;
            }
            else
            {
                grdOCS0301.SetItemValue(currentRow, "select", "N");
                //SelectionBackColorChange(grdOCS0301, currentRow, "N");

                //modify by jc
                //node1 = int.Parse(grdOCS0301.GetItemString(currentRow, "node1"));
                //node2 = int.Parse(grdOCS0301.GetItemString(currentRow, "node2"));
                //tvwOCS0300.Nodes[node1].Nodes[node2].ImageIndex = 0;
                //tvwOCS0300.Nodes[node1].Nodes[node2].SelectedImageIndex = 0;
                node1 = int.Parse(grdOCS0301.GetItemString(currentRow, "node1"));
                node2 = int.Parse(grdOCS0301.GetItemString(currentRow, "node2"));
                node3 = int.Parse(grdOCS0301.GetItemString(currentRow, "node3"));
                tvwOCS0300.Nodes[node1].Nodes[node2].Nodes[node3].ImageIndex = 0;
                tvwOCS0300.Nodes[node1].Nodes[node2].Nodes[node3].SelectedImageIndex = 0;
            }
        }

        #endregion

        #region [Return Layout 생성]

        //날수 및 기타 기본정보변경
        private void CreateReturnLayout()
        {
            grdOCS0301.ClearFilter();

            this.AcceptData();

            
            //if (dloSelectOCS0301.LayoutTable.Rows.Count < 1 && dloSelectOCS0303.LayoutTable.Rows.Count < 1)
            if (dloSelectOCS0303.LayoutTable.Rows.Count < 1)
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "オーダが選択されていません。ご確認下さい。" : "처방이 선택되지 않았습니다. 확인하세요.";
                mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                return;
            }

            // general_disp_yn = Y であるオーダはオーダ名を一般名に変えてlib.HangmogInfoに渡してそのまま一般名で返してもらう。
            DataRow row;

            for (int i = 0; i < dloSelectOCS0303.RowCount; i++)
            {
                row = dloSelectOCS0303.LayoutTable.Rows[i];

                if (row["general_disp_yn"].ToString().Trim() == "Y")
                {
                    row["hangmog_name"] = row["generic_name"].ToString().Trim();
                }
            }
            //if (chkIsNewGroup.Checked)
            //    mIsNewGroupSer = true;
            //else
            //    mIsNewGroupSer = false;

            //약속코드선택정보가 있는 경우 Return Value
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

            CommonItemCollection commandParams = new CommonItemCollection();
            //commandParams.Add("OCS0301", dloSelectOCS0301);
            //commandParams.Add("isnewgroup", mIsNewGroupSer);
            commandParams.Add("OCS0303", dloSelectOCS0303);
            scrOpener.Command("OCS0301Q09", commandParams);

            this.Close();
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
                            if (aGrd.GetItemValue(i, "order_gubun").ToString().Trim() == aGrd.GetItemValue(j, "order_gubun").ToString().Trim() &&
                                aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
                                aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim())
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

        #region [그리드에서 선택한 Row에 대한 BackColor를 변경한다]

        private void SelectionBackColorChange(object grid, int currentRowIndex, string data)
        {
            XEditGrid grdObject = (XEditGrid)grid;

            if (currentRowIndex < 0) return;

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

            for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
            {
                if (grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
                {
                    // 돈복여부
                    if (grdObject.GetItemString(currentRowIndex, "donbog_yn") == "Y")
                    {
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
                        continue;
                    }

                    // 불균등분할
                    if (!TypeCheck.IsNull(grdObject.GetItemString(currentRowIndex, "dv_name")))
                    {
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
                        continue;
                    }
                }

                if (grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName != "select")
                {
                    if (data == "Y")
                    {
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
                    }
                    else
                    {
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
                    }
                }
                else
                { 
                
                }
            }

            //child 이미지 세팅
            ChildSetImage();
        }


        private void SelectionBackColorChange(object grid)
        {
            XEditGrid grdObject = (XEditGrid)grid;

            //기존의 색으로 변경을 시킨다
            for (int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                if (grdObject.GetItemString(rowIndex, "select").ToString() == "Y")
                {
                    //image 변경
                    if (grdObject.RowHeaderVisible)
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
                    else
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];

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
                        if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName != "select")
                        {
                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
                        }
                    }
                }
                else
                {
                    //image 변경
                    if (grdObject.RowHeaderVisible)
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
                    else
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];

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

                        if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName != "select")
                        {
                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
                        }
                    }
                }
            }

            if (grdObject.Name == "grdOCS0303") DiaplayMixGroup(grdObject);


            //child 이미지 세팅
            ChildSetImage();
        }

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

        #region [ SetOrder Copy ]

        // Set Order Copy
        private void PopUpMenuSetOrderCopy_Click(object sender, System.EventArgs e)
        {
            if (tvwOCS0300.SelectedNode.Tag == null) return;

            int currentRow = int.Parse(tvwOCS0300.SelectedNode.Tag.ToString());

            string yaksok_memb = grdOCS0301.GetItemString(currentRow, "memb");
            string yaksok_code = grdOCS0301.GetItemString(currentRow, "yaksok_code");
            string newYaksok_code = "";
            string newYaksok_name = grdOCS0301.GetItemString(currentRow, "yaksok_name");
            string insert_tab = grdOCS0301.GetItemString(currentRow, "tab_gubun");


            if (CheckExistsYasokCode(yaksok_code))
            {
                //약속코드를 입력받는다.
                frmYaksok_code frm = new frmYaksok_code();
                frm.Yaksok_name = newYaksok_name;
                frm.ShowDialog();

                //선택시 처리
                if (frm.DialogResult == DialogResult.OK)
                {
                    newYaksok_code = frm.Yaksok_code;
                    newYaksok_name = frm.Yaksok_name;
                }
                else
                    return;
            }
            else
            {
                newYaksok_code = yaksok_code;
            }

            this.dloSetOrderCopy.Reset();
            int insertRow = this.dloSetOrderCopy.InsertRow(-1);
            this.dloSetOrderCopy.SetItemValue(insertRow, "source_memb", yaksok_memb);
            this.dloSetOrderCopy.SetItemValue(insertRow, "source_yaksok_code", yaksok_code);
            this.dloSetOrderCopy.SetItemValue(insertRow, "target_memb", UserInfo.YaksokOpenID);
            this.dloSetOrderCopy.SetItemValue(insertRow, "yaksok_code", newYaksok_code);
            this.dloSetOrderCopy.SetItemValue(insertRow, "yaksok_name", newYaksok_name);
            this.dloSetOrderCopy.SetItemValue(insertRow, "insert_tab",  insert_tab);

            if (this.SetOrderCopy())
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "セットオ―ダコピーが完了しました。" : "Set Order Copy가 완료되었습니다.";
                mbxCap = NetInfo.Language == LangMode.Jr ? "セットオ―ダコピー" : "Set Order Copy";
                XMessageBox.Show(mbxMsg, mbxCap);
            }
            else
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "セットオ―ダコピーが失敗しました。\n" : "Set Order Copy가 실패하였습니다.";
                mbxMsg = mbxMsg + Service.ErrMsg;
                mbxCap = NetInfo.Language == LangMode.Jr ? "セットオ―ダコピー" : "Set Order Copy";
                XMessageBox.Show(mbxMsg, mbxCap);
            }

        }

        private bool SetOrderCopy()
        {
            ArrayList inputList = new ArrayList();
            inputList.Add(dloSetOrderCopy.GetItemString(0, "source_memb"));
            inputList.Add(dloSetOrderCopy.GetItemString(0, "source_yaksok_code"));
            inputList.Add(dloSetOrderCopy.GetItemString(0, "target_memb"));
            inputList.Add(dloSetOrderCopy.GetItemString(0, "yaksok_code"));
            inputList.Add(dloSetOrderCopy.GetItemString(0, "yaksok_name"));
            ArrayList outputList = new ArrayList();

            if (!Service.ExecuteProcedure("PR_OCS_COPY_SET_ORDER", inputList, outputList))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return false;
            }
            return true;
        }

        private bool CheckExistsYasokCode(string aYasok_code)
        {
            //중복check
            string cmdText = "";
            object retVal = null;
            cmdText = " SELECT YAKSOK_NAME "
                    + "   FROM OCS0301 "
                    + "  WHERE MEMB = '" + UserInfo.YaksokOpenID + "' "
                    + "    AND YAKSOK_CODE = '" + aYasok_code + "' "
                    + "    AND HOSP_CODE   = '" + mHospCode + "' " ;

            retVal = Service.ExecuteScalar(cmdText);

            if (!TypeCheck.IsNull(retVal))
                return false;
            else
                return true;
        }


        #endregion

        #region [선택한 검사정보 조회]
        private void btnCPLInfo_Click(object sender, System.EventArgs e)
        {
            int rowIndex = grdOCS0303.CurrentRowNumber;
            if (rowIndex < 0) return;

            if (grdOCS0303.GetItemString(rowIndex, "slip_code").Substring(0, 1) != "B") return;

            popupMenu.MenuCommands[0].OnClick(null);

        }
        #endregion

        #region ChildSetImage
        private void ChildSetImage()
        {
            for (int i = 0; i < this.grdOCS0303.RowCount; i++)
            {
                this.grdOCS0303[i, "child_gubun"].ForeColor = new XColor(System.Drawing.Color.Transparent);
                switch (this.grdOCS0303.GetItemString(i, "child_gubun"))
                {
                    case "1": //자식있음
                        this.grdOCS0303[i, "child_gubun"].Image = this.ImageList.Images[6];
                        break;
                    case "2": //자식없음
                        this.grdOCS0303[i, "child_gubun"].Image = this.ImageList.Images[7];
                        break;
                    case "3": //자식
                        this.grdOCS0303[i, "child_gubun"].Image = this.ImageList.Images[8];
                        break;
                    default:
                        this.grdOCS0303[i, "child_gubun"].Image = this.ImageList.Images[7];
                        break;
                }
                this.grdOCS0303[i, "child_gubun"].ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            }
        }
        #endregion

        #region 각 그리드에 바인드 변수(병원코드) 설정
        private void grdOCS0301_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0301.SetBindVarValue("f_hosp_code", mHospCode);
            
            //hard coding
            grdOCS0301.SetBindVarValue("f_memb", mMemb);
            grdOCS0301.SetBindVarValue("f_input_tab", mInput_tab);
        }

        private void grdOCS0303_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0303.SetBindVarValue("f_hosp_code", mHospCode);
            //grdOCS0303.SetBindVarValue("f_group_ser", tabGroupSerial.SelectedTab.Title);

            //hard coding
            grdOCS0303.SetBindVarValue("f_memb", mMemb);
            grdOCS0303.SetBindVarValue("f_fkocs0300_seq", grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "pk_seq"));
            grdOCS0303.SetBindVarValue("f_yaksok_code", grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "yaksok_code"));
            grdOCS0303.SetBindVarValue("f_input_tab", grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "input_tab"));
            grdOCS0303.SetBindVarValue("f_generic_yn", cbxGeneric_YN.GetDataValue());
        }
        #endregion

        private void tabGroupSerial_SelectionChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grdOCS0303.RowCount; i++)
            {
                if (this.grdOCS0303.GetItemString(i, "group_ser") == this.tabGroupSerial.SelectedTab.Tag.ToString())
                {
                    this.grdOCS0303.SetRowVisible(i, true);
                }
                else
                {
                    this.grdOCS0303.SetRowVisible(i, false);
                }
            }
        }

        private void btnDeleteAllTab_Click(object sender, EventArgs e)
        {
            //if (this.tabGroupSerial.SelectedTab != null)
            //    SelectRow(this.tabGroupSerial.SelectedTab.Tag.ToString());
            //if (this.tabGroupSerial.SelectedTab != null)
                DeleteRow("%");
        }

        private void btnSelectAllTab_Click(object sender, EventArgs e)
        {
            //if (this.tabGroupSerial.SelectedTab != null)
                SelectRow("%");
        }
        private void SelectRow(string groupSerial)
        {
            if (groupSerial == "%")
            {
                for (int i = 0; i < this.grdOCS0303.RowCount; i++)
                {
                    if (this.grdOCS0303.GetItemString(i, "bulyong_check") == "Y")
                        continue;

                    this.grdOCS0303.SetItemValue(i, "select", "Y");
                    SelectionBackColorChange(grdOCS0303, i, "Y");
                    this.InsertBackTable(this.grdOCS0303.LayoutTable.Rows[i]);
                }
            }
            else
            {
                for (int i = 0; i < this.grdOCS0303.RowCount; i++)
                {
                    if (this.grdOCS0303.GetItemString(i, "group_ser") == groupSerial)
                    {
                        if (this.grdOCS0303.GetItemString(i, "bulyong_check") == "Y")
                            continue;

                        this.grdOCS0303.SetItemValue(i, "select", "Y");
                        SelectionBackColorChange(grdOCS0303, i, "Y");
                        this.InsertBackTable(this.grdOCS0303.LayoutTable.Rows[i]);
                    }
                }
            }

            SetSelectYaksok();
            SetTabImage();
        }

        private void DeleteRow(string groupSerial)
        {
            if (groupSerial == "%")
            {
                for (int i = 0; i < this.grdOCS0303.RowCount; i++)
                {
                    if (this.grdOCS0303.GetItemString(i, "bulyong_check") == "Y")
                        continue;

                    this.grdOCS0303.SetItemValue(i, "select", "N");
                    SelectionBackColorChange(grdOCS0303, i, "N");
                    this.RemoveBackTable(this.grdOCS0303.LayoutTable.Rows[i]);
                }
            }
            else
            {
                //for (int i = 0; i < this.grdOCS0303.RowCount; i++)
                //{
                //    if (this.grdOCS0303.GetItemString(i, "group_ser") == groupSerial)
                //    {
                //        if (this.grdOCS0303.GetItemString(i, "bulyong_check") == "Y")
                //            continue;

                //        this.grdOCS0303.SetItemValue(i, "select", "Y");
                //        SelectionBackColorChange(grdOCS0303, i, "Y");
                //        this.InsertBackTable(this.grdOCS0303.LayoutTable.Rows[i]);
                //    }
                //}
            }

            SetSelectYaksok();
            SetTabImage();
        }


        private void grdOCS0303_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {

        }

        private void cbxGeneric_YN_CheckedChanged(object sender, EventArgs e)
        {
            this.grdOCS0303.QueryLayout(true);
        }

        private void grdOCS0321_QueryEnd(object sender, QueryEndEventArgs e)
        {
            ///이전에 선택한 약속코드가 있으면 선택상태로
            foreach (DataRow row in dloSelectOCS0301.LayoutTable.Select(" memb = '" + mMemb + "' ", ""))
            {
                for (int i = 0; i < grdOCS0301.RowCount; i++)
                {
                    if (grdOCS0301.GetItemString(i, "pk_seq") == row["pk_seq"].ToString() &&
                        grdOCS0301.GetItemString(i, "yaksok_code") == row["yaksok_code"].ToString())
                    {
                        grdOCS0301.SetItemValue(i, "select", "Y");
                        //grdOCS0301.SetItemValue(i, "select_sang", row["select_sang"].ToString());
                    }
                }
            }

            if (!TypeCheck.IsNull(txtSearchSetName.GetDataValue().Trim()))
                grdOCS0301.SetFilter(" yaksok_name like '%" + txtSearchSetName.GetDataValue().Trim() + "%'");

            ShowOCS0320(this.grdOCS0321, "");

            if (this.grdOCS0301.RowCount == 0)
                this.grdOCS0303.Reset();
        }

        private void layOCS0323_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layOCS0323.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layOCS0323.SetBindVarValue("f_fkocs0320", ((Hashtable)this.tvwOCS0300.SelectedNode.Tag)["pkocs0320"].ToString());
            this.layOCS0323.SetBindVarValue("f_generic_yn", "N");
        }

        private void layOCS0323_SaveEnd(object sender, SaveEndEventArgs e)
        {
            XMessageBox.Show(this.layOCS0323.RowCount.ToString());
        }

        private void grdOCS0323_all_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            int rowIndex;
            rowIndex = grd.GetHitRowNumber(e.Y);
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (rowIndex < 0) return;

                if (grd.CurrentColNumber == 0 || grd.CurrentColNumber == 1)
                {
                    ////불용처리된 것은 선택을 막는다.
                    //if (grdOCS0303.GetItemString(rowIndex, "bulyong_check") == "Y")
                    //{
                    //    //불용인 경우에는 해당 항목의 심사기준을 보여준다.
                    //    mbxMsg = this.mOrderBiz.LoadSimsa_comment(grdOCS0303.GetItemString(rowIndex, "hangmog_code"));
                    //    mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
                    //    if (!TypeCheck.IsNull(mbxMsg)) XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);

                    //    return;
                    //}

                    if (grd.GetItemString(rowIndex, "select") == "Y")
                    {
                        grd.SetItemValue(rowIndex, "select", "N");
                        SelectionBackColorChange(sender, rowIndex, "N");
                        this.RemoveBackTable(grd.LayoutTable.Rows[rowIndex]);
                    }
                    else
                    {
                        grd.SetItemValue(rowIndex, "select", "Y");
                        SelectionBackColorChange(sender, rowIndex, "Y");
                        this.InsertBackTable(grd.LayoutTable.Rows[rowIndex]);
                    }
                    //SetSelectYaksok();
                    //SetTabImage();
                }
            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (rowIndex < 0) return;
            }
            else if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                rowIndex = grd.GetHitRowNumber(e.Y);
                if (rowIndex < 0) return;

                if (grdOCS0303.GetItemString(rowIndex, "slip_code").Substring(0, 1) != "B") return;

                popupMenu.TrackPopup(((IHIS.Framework.XEditGrid)sender).PointToScreen(new Point(e.X, e.Y)));
            }
        }
    }
}

