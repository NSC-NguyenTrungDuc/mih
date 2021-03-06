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

namespace IHIS.OCSI
{
	/// <summary>
	/// OCS6010U10 [치료계획]
	/// - 현재일자를 기준으로 현재일자까지는 지시사항, 처방 Data를 보여주고, 
	///   현재일자 이후에는 예정Data 보여준다.
	///   ** 간호에서 등록한 지시사항 및 처방이 현재는 Input_gubun이 간호로 되어 있어서
	///      문제가 된다 --> 정규로 처리
	///   
	/// 1. 지시사항
	///    1.1 예정지시사항 일자변경 Drag처리 및 POPUP처리, 간호지시사항에 한해서만 변경
	///        가능하도록 한다.
	///        (단, 연속인 경우에는 처리하지 않는다.)
	///    1.2 지시사항 실시 (현재 일자일때만 실시가능하도록 한다.)
	/// 2. 처방
	///    2.1 간호확인
	///    2.2 투약확인(처방과 투약확인Data 구분) - 제외
	/// </summary>
	[ToolboxItem(false)]
	public class OCS6010U10 : IHIS.Framework.XScreen
	{
		#region [OCS Library]		
		private IHIS.OCS.PatientInfo mPatientInfo = null;     // OCS 환자정보 그룹 라이브러리 
		private IHIS.OCS.OrderFunc   mOrderFunc   = null;         // OCS 그룹 Function 라이브러리		
		#endregion

		#region [Instance Variable]
		//Message처리
		string mbxMsg = "", mbxCap = "";	
		string mBunho = "";
		int    mFkinp1001;	
		
		//재원여부
		bool mIsJaewonYn = false;

		private const int WIDTH_PROCESSPLAN = 470;

		//선택항목
		private Hashtable htSelectItem = new Hashtable();

        // Hospital Code
        private string mHospCode = EnvironInfo.HospCode;

        // 오더정보표시창 201202
        private frmOrderInfo frmOrderInfo;
		#endregion

        #region [ 자동생성 ]
        private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPatientBox pbxBunho;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPanel pnlMid_top;
		private System.Windows.Forms.ToolTip toolTip1;
		private IHIS.Framework.MultiLayout dloItemData;
		private IHIS.Framework.MultiLayout dloInput_gubun;
		private IHIS.Framework.XMatrix mtxPlanMgt;
		private IHIS.Framework.XFlatLabel xFlatLabel1;
		private IHIS.Framework.XFlatLabel xFlatLabel2;
		private IHIS.Framework.XButton btnPrePeriod;
		private IHIS.Framework.XDatePicker dpkFrom_date;
		private IHIS.Framework.XDatePicker dpkTo_date;
		private IHIS.Framework.XButton btnNextPeriod;
		private IHIS.Framework.MultiLayout dloProcessInfo;
		private IHIS.Framework.XPanel xPanel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private IHIS.Framework.XRadioButton rbtPJ;
		private IHIS.Framework.XRadioButton rbtAll;
		private IHIS.Framework.XPanel pnlProcessApplyPlan;
		private IHIS.Framework.XButton btnProcessPlan;
		private IHIS.Framework.XButton btnShowProcessPlan;
		private IHIS.Framework.XButton btnProcessPlanClose;
		private IHIS.Framework.XDatePicker dApp_From_date;
		private IHIS.Framework.XDatePicker dtpApp_To_date;
		private IHIS.Framework.MultiLayout dloProcessInfo1;
		private IHIS.Framework.XTabControl tabQuery;
		private IHIS.Framework.XDisplayBox dbxConfirmUserName;
		private IHIS.Framework.XTextBox txtConfirmUser;
		private IHIS.Framework.XLabel lblNurseId;
		private IHIS.Framework.XButton btnClearConfirmUser;
		private IHIS.Framework.XRadioButton rbtJusa;
        private System.Windows.Forms.Panel pnlPosition;
        private MultiLayoutItem multiLayoutItem62;
        private MultiLayoutItem multiLayoutItem63;
        private MultiLayoutItem multiLayoutItem56;
        private MultiLayoutItem multiLayoutItem57;
        private MultiLayoutItem multiLayoutItem58;
        private MultiLayoutItem multiLayoutItem59;
        private MultiLayoutItem multiLayoutItem60;
        private MultiLayoutItem multiLayoutItem61;
        private MultiLayoutItem multiLayoutItem54;
        private MultiLayoutItem multiLayoutItem55;
        private MultiLayoutItem multiLayoutItem64;
        private MultiLayoutItem multiLayoutItem65;
        private MultiLayoutItem multiLayoutItem66;
        private MultiLayoutItem multiLayoutItem67;
        private MultiLayoutItem multiLayoutItem68;
        private MultiLayoutItem multiLayoutItem69;
        private XDataWindow dwSiksaJunpyo;
        private MultiLayout laySiksaJunpyo;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
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
        private XToolTip xToolTip1;
        private XRadioButton rbtSiksa;
        private XButton btnOpenOrder;
        private MultiLayout layQueryLayout;
        private MultiLayoutItem multiLayoutItem1484;
        private MultiLayoutItem multiLayoutItem1485;
        private MultiLayoutItem multiLayoutItem1486;
        private MultiLayoutItem multiLayoutItem1487;
        private MultiLayoutItem multiLayoutItem1488;
        private MultiLayoutItem multiLayoutItem1489;
        private MultiLayoutItem multiLayoutItem1490;
        private MultiLayoutItem multiLayoutItem1491;
        private MultiLayoutItem multiLayoutItem1492;
        private MultiLayoutItem multiLayoutItem1493;
        private MultiLayoutItem multiLayoutItem1494;
        private MultiLayoutItem multiLayoutItem1495;
        private MultiLayoutItem multiLayoutItem1496;
        private MultiLayoutItem multiLayoutItem1497;
        private MultiLayoutItem multiLayoutItem1498;
        private MultiLayoutItem multiLayoutItem1499;
        private MultiLayoutItem multiLayoutItem1517;
        private MultiLayoutItem multiLayoutItem1518;
        private MultiLayoutItem multiLayoutItem1519;
        private MultiLayoutItem multiLayoutItem1520;
        private MultiLayoutItem multiLayoutItem1521;
        private MultiLayoutItem multiLayoutItem1522;
        private MultiLayoutItem multiLayoutItem1523;
        private MultiLayoutItem multiLayoutItem1524;
        private MultiLayoutItem multiLayoutItem1525;
        private MultiLayoutItem multiLayoutItem1526;
        private MultiLayoutItem multiLayoutItem1527;
        private MultiLayoutItem multiLayoutItem1528;
        private MultiLayoutItem multiLayoutItem1529;
        private MultiLayoutItem multiLayoutItem1530;
        private MultiLayoutItem multiLayoutItem1531;
        private MultiLayoutItem multiLayoutItem1532;
        private MultiLayoutItem multiLayoutItem1533;
        private MultiLayoutItem multiLayoutItem1534;
        private MultiLayoutItem multiLayoutItem1535;
        private MultiLayoutItem multiLayoutItem1536;
        private MultiLayoutItem multiLayoutItem1537;
        private MultiLayoutItem multiLayoutItem1538;
        private MultiLayoutItem multiLayoutItem1539;
        private MultiLayoutItem multiLayoutItem1540;
        private MultiLayoutItem multiLayoutItem1541;
        private MultiLayoutItem multiLayoutItem1542;
        private MultiLayoutItem multiLayoutItem1543;
        private MultiLayoutItem multiLayoutItem1544;
        private MultiLayoutItem multiLayoutItem1545;
        private MultiLayoutItem multiLayoutItem1546;
        private MultiLayoutItem multiLayoutItem1547;
        private MultiLayoutItem multiLayoutItem1548;
        private MultiLayoutItem multiLayoutItem1549;
        private MultiLayoutItem multiLayoutItem1550;
        private MultiLayoutItem multiLayoutItem1551;
        private MultiLayoutItem multiLayoutItem1552;
        private MultiLayoutItem multiLayoutItem1553;
        private MultiLayoutItem multiLayoutItem1554;
        private MultiLayoutItem multiLayoutItem1555;
        private MultiLayoutItem multiLayoutItem1556;
        private MultiLayoutItem multiLayoutItem1557;
        private MultiLayoutItem multiLayoutItem1558;
        private MultiLayoutItem multiLayoutItem1559;
        private MultiLayoutItem multiLayoutItem1560;
        private MultiLayoutItem multiLayoutItem1561;
        private MultiLayoutItem multiLayoutItem1562;
        private MultiLayoutItem multiLayoutItem1563;
        private MultiLayoutItem multiLayoutItem1564;
        private MultiLayoutItem multiLayoutItem1565;
        private MultiLayoutItem multiLayoutItem1566;
        private MultiLayoutItem multiLayoutItem1567;
        private MultiLayoutItem multiLayoutItem1568;
        private MultiLayoutItem multiLayoutItem1569;
        private MultiLayoutItem multiLayoutItem1570;
        private MultiLayoutItem multiLayoutItem1571;
        private MultiLayoutItem multiLayoutItem1572;
        private MultiLayoutItem multiLayoutItem1573;
        private MultiLayoutItem multiLayoutItem1574;
        private MultiLayoutItem multiLayoutItem1575;
        private MultiLayoutItem multiLayoutItem1576;
        private MultiLayoutItem multiLayoutItem1577;
        private MultiLayoutItem multiLayoutItem1578;
        private MultiLayoutItem multiLayoutItem1579;
        private MultiLayoutItem multiLayoutItem1580;
        private MultiLayoutItem multiLayoutItem1581;
        private MultiLayoutItem multiLayoutItem1582;
        private MultiLayoutItem multiLayoutItem1583;
        private MultiLayoutItem multiLayoutItem1584;
        private MultiLayoutItem multiLayoutItem1585;
        private MultiLayoutItem multiLayoutItem1586;
        private MultiLayoutItem multiLayoutItem1587;
        private MultiLayoutItem multiLayoutItem1588;
        private MultiLayoutItem multiLayoutItem1589;
        private MultiLayoutItem multiLayoutItem1590;
        private MultiLayoutItem multiLayoutItem1591;
        private MultiLayoutItem multiLayoutItem1592;
        private MultiLayoutItem multiLayoutItem1593;
        private MultiLayoutItem multiLayoutItem1594;
        private MultiLayoutItem multiLayoutItem1595;
        private MultiLayoutItem multiLayoutItem1596;
        private MultiLayoutItem multiLayoutItem1597;
        private MultiLayoutItem multiLayoutItem1598;
        private MultiLayoutItem multiLayoutItem1599;
        private MultiLayoutItem multiLayoutItem1600;
        private MultiLayoutItem multiLayoutItem1601;
        private MultiLayoutItem multiLayoutItem1602;
        private MultiLayoutItem multiLayoutItem1603;
        private MultiLayoutItem multiLayoutItem1604;
        private MultiLayoutItem multiLayoutItem1605;
        private MultiLayoutItem multiLayoutItem1606;
        private MultiLayoutItem multiLayoutItem1607;
        private MultiLayoutItem multiLayoutItem1608;
        private MultiLayoutItem multiLayoutItem1609;
        private MultiLayoutItem multiLayoutItem1610;
        private MultiLayoutItem multiLayoutItem1611;
        private MultiLayoutItem multiLayoutItem1612;
        private MultiLayoutItem multiLayoutItem1613;
        private MultiLayoutItem multiLayoutItem1614;
        private MultiLayoutItem multiLayoutItem1615;
        private MultiLayoutItem multiLayoutItem1616;
        private MultiLayoutItem multiLayoutItem1617;
        private MultiLayoutItem multiLayoutItem1618;
        private MultiLayoutItem multiLayoutItem1619;
        private MultiLayoutItem multiLayoutItem1620;
        private MultiLayoutItem multiLayoutItem1621;
        private MultiLayoutItem multiLayoutItem1622;
        private MultiLayoutItem multiLayoutItem1623;
        private MultiLayoutItem multiLayoutItem1624;
        private MultiLayoutItem multiLayoutItem1625;
        private MultiLayoutItem multiLayoutItem1626;
        private MultiLayoutItem multiLayoutItem1627;
        private MultiLayoutItem multiLayoutItem1628;
        private MultiLayoutItem multiLayoutItem1629;
        private MultiLayoutItem multiLayoutItem1630;
        private MultiLayoutItem multiLayoutItem1631;
        private MultiLayoutItem multiLayoutItem1632;
        private MultiLayoutItem multiLayoutItem1633;
        private MultiLayoutItem multiLayoutItem1634;
        private MultiLayoutItem multiLayoutItem1635;
        private MultiLayoutItem multiLayoutItem1636;
        private MultiLayoutItem multiLayoutItem1637;
        private MultiLayoutItem multiLayoutItem1638;
        private MultiLayoutItem multiLayoutItem1639;
        private MultiLayoutItem multiLayoutItem1640;
        private MultiLayoutItem multiLayoutItem1641;
        private MultiLayoutItem multiLayoutItem1642;
        private MultiLayoutItem multiLayoutItem1643;
        private MultiLayoutItem multiLayoutItem1644;
        private MultiLayoutItem multiLayoutItem1645;
        private MultiLayoutItem multiLayoutItem1660;
        private MultiLayoutItem multiLayoutItem1938;
        private MultiLayoutItem multiLayoutItem1954;
        private MultiLayoutItem multiLayoutItem1955;
        private MultiLayoutItem multiLayoutItem1956;
        private MultiLayoutItem multiLayoutItem1957;
        private MultiLayoutItem multiLayoutItem1958;
        private MultiLayoutItem multiLayoutItem1959;
        private MultiLayoutItem multiLayoutItem1960;
        private MultiLayoutItem multiLayoutItem1961;
        private MultiLayoutItem multiLayoutItem1962;
        private MultiLayout layCplOrder;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem432;
        private MultiLayoutItem multiLayoutItem433;
        private MultiLayoutItem multiLayoutItem434;
        private MultiLayoutItem multiLayoutItem435;
        private MultiLayoutItem multiLayoutItem436;
        private MultiLayoutItem multiLayoutItem437;
        private MultiLayoutItem multiLayoutItem438;
        private MultiLayoutItem multiLayoutItem439;
        private MultiLayoutItem multiLayoutItem440;
        private MultiLayoutItem multiLayoutItem441;
        private MultiLayoutItem multiLayoutItem442;
        private MultiLayoutItem multiLayoutItem443;
        private MultiLayoutItem multiLayoutItem444;
        private MultiLayoutItem multiLayoutItem445;
        private MultiLayoutItem multiLayoutItem446;
        private MultiLayoutItem multiLayoutItem447;
        private MultiLayoutItem multiLayoutItem448;
        private MultiLayoutItem multiLayoutItem449;
        private MultiLayoutItem multiLayoutItem450;
        private MultiLayoutItem multiLayoutItem451;
        private MultiLayoutItem multiLayoutItem452;
        private MultiLayoutItem multiLayoutItem453;
        private MultiLayoutItem multiLayoutItem454;
        private MultiLayoutItem multiLayoutItem455;
        private MultiLayoutItem multiLayoutItem456;
        private MultiLayoutItem multiLayoutItem457;
        private MultiLayoutItem multiLayoutItem458;
        private MultiLayoutItem multiLayoutItem459;
        private MultiLayoutItem multiLayoutItem460;
        private MultiLayoutItem multiLayoutItem461;
        private MultiLayoutItem multiLayoutItem462;
        private MultiLayoutItem multiLayoutItem463;
        private MultiLayoutItem multiLayoutItem464;
        private MultiLayoutItem multiLayoutItem465;
        private MultiLayoutItem multiLayoutItem466;
        private MultiLayoutItem multiLayoutItem467;
        private MultiLayoutItem multiLayoutItem468;
        private MultiLayoutItem multiLayoutItem469;
        private MultiLayoutItem multiLayoutItem470;
        private MultiLayoutItem multiLayoutItem471;
        private MultiLayoutItem multiLayoutItem472;
        private MultiLayoutItem multiLayoutItem473;
        private MultiLayoutItem multiLayoutItem474;
        private MultiLayoutItem multiLayoutItem475;
        private MultiLayoutItem multiLayoutItem476;
        private MultiLayoutItem multiLayoutItem477;
        private MultiLayoutItem multiLayoutItem478;
        private MultiLayoutItem multiLayoutItem479;
        private MultiLayoutItem multiLayoutItem480;
        private MultiLayoutItem multiLayoutItem481;
        private MultiLayoutItem multiLayoutItem482;
        private MultiLayoutItem multiLayoutItem483;
        private MultiLayoutItem multiLayoutItem484;
        private MultiLayoutItem multiLayoutItem485;
        private MultiLayoutItem multiLayoutItem486;
        private MultiLayoutItem multiLayoutItem487;
        private MultiLayoutItem multiLayoutItem488;
        private MultiLayoutItem multiLayoutItem489;
        private MultiLayoutItem multiLayoutItem490;
        private MultiLayoutItem multiLayoutItem491;
        private MultiLayoutItem multiLayoutItem492;
        private MultiLayoutItem multiLayoutItem493;
        private MultiLayoutItem multiLayoutItem494;
        private MultiLayoutItem multiLayoutItem495;
        private MultiLayoutItem multiLayoutItem496;
        private MultiLayoutItem multiLayoutItem497;
        private MultiLayoutItem multiLayoutItem498;
        private MultiLayoutItem multiLayoutItem499;
        private MultiLayoutItem multiLayoutItem500;
        private MultiLayoutItem multiLayoutItem501;
        private MultiLayoutItem multiLayoutItem502;
        private MultiLayoutItem multiLayoutItem503;
        private MultiLayoutItem multiLayoutItem504;
        private MultiLayoutItem multiLayoutItem505;
        private MultiLayoutItem multiLayoutItem506;
        private MultiLayoutItem multiLayoutItem507;
        private MultiLayoutItem multiLayoutItem508;
        private MultiLayoutItem multiLayoutItem509;
        private MultiLayoutItem multiLayoutItem510;
        private MultiLayoutItem multiLayoutItem511;
        private MultiLayoutItem multiLayoutItem512;
        private MultiLayoutItem multiLayoutItem513;
        private MultiLayoutItem multiLayoutItem514;
        private MultiLayoutItem multiLayoutItem515;
        private MultiLayoutItem multiLayoutItem516;
        private MultiLayoutItem multiLayoutItem517;
        private MultiLayoutItem multiLayoutItem518;
        private MultiLayoutItem multiLayoutItem519;
        private MultiLayoutItem multiLayoutItem520;
        private MultiLayoutItem multiLayoutItem521;
        private MultiLayoutItem multiLayoutItem522;
        private MultiLayoutItem multiLayoutItem523;
        private MultiLayoutItem multiLayoutItem524;
        private MultiLayoutItem multiLayoutItem525;
        private MultiLayoutItem multiLayoutItem526;
        private MultiLayoutItem multiLayoutItem527;
        private MultiLayoutItem multiLayoutItem528;
        private MultiLayoutItem multiLayoutItem529;
        private MultiLayoutItem multiLayoutItem530;
        private MultiLayoutItem multiLayoutItem531;
        private MultiLayoutItem multiLayoutItem532;
        private MultiLayoutItem multiLayoutItem533;
        private MultiLayoutItem multiLayoutItem534;
        private MultiLayoutItem multiLayoutItem535;
        private MultiLayoutItem multiLayoutItem536;
        private MultiLayoutItem multiLayoutItem537;
        private MultiLayoutItem multiLayoutItem538;
        private MultiLayoutItem multiLayoutItem539;
        private MultiLayoutItem multiLayoutItem540;
        private MultiLayoutItem multiLayoutItem541;
        private MultiLayoutItem multiLayoutItem542;
        private MultiLayoutItem multiLayoutItem543;
        private MultiLayoutItem multiLayoutItem544;
        private MultiLayoutItem multiLayoutItem545;
        private MultiLayoutItem multiLayoutItem546;
        private MultiLayoutItem multiLayoutItem547;
        private MultiLayoutItem multiLayoutItem548;
        private MultiLayoutItem multiLayoutItem549;
        private MultiLayoutItem multiLayoutItem687;
        private MultiLayoutItem multiLayoutItem688;
        private MultiLayoutItem multiLayoutItem689;
        private MultiLayoutItem multiLayoutItem690;
        private MultiLayoutItem multiLayoutItem691;
        private MultiLayoutItem multiLayoutItem692;
        private MultiLayoutItem multiLayoutItem693;
        private MultiLayoutItem multiLayoutItem694;
        private MultiLayoutItem multiLayoutItem701;
        private MultiLayoutItem multiLayoutItem702;
        private MultiLayoutItem multiLayoutItem703;
        private MultiLayoutItem multiLayoutItem713;
        private MultiLayoutItem multiLayoutItem723;
        private MultiLayoutItem multiLayoutItem724;
        private MultiLayoutItem multiLayoutItem1013;
        private MultiLayoutItem multiLayoutItem1014;
        private MultiLayoutItem multiLayoutItem1015;
        private MultiLayoutItem multiLayoutItem1016;
        private MultiLayoutItem multiLayoutItem1029;
        private MultiLayoutItem multiLayoutItem1928;
        private MultiLayoutItem multiLayoutItem1929;
        private MultiLayoutItem multiLayoutItem1930;
        private MultiLayoutItem multiLayoutItem1931;
        private MultiLayout layJusaOrder;
        private MultiLayoutItem multiLayoutItem1972;
        private MultiLayoutItem multiLayoutItem1973;
        private MultiLayoutItem multiLayoutItem1974;
        private MultiLayoutItem multiLayoutItem1975;
        private MultiLayoutItem multiLayoutItem1976;
        private MultiLayoutItem multiLayoutItem1977;
        private MultiLayoutItem multiLayoutItem1978;
        private MultiLayoutItem multiLayoutItem1979;
        private MultiLayoutItem multiLayoutItem1980;
        private MultiLayoutItem multiLayoutItem1981;
        private MultiLayoutItem multiLayoutItem1982;
        private MultiLayoutItem multiLayoutItem1983;
        private MultiLayoutItem multiLayoutItem1984;
        private MultiLayoutItem multiLayoutItem1985;
        private MultiLayoutItem multiLayoutItem1986;
        private MultiLayoutItem multiLayoutItem1987;
        private MultiLayoutItem multiLayoutItem1988;
        private MultiLayoutItem multiLayoutItem1989;
        private MultiLayoutItem multiLayoutItem1990;
        private MultiLayoutItem multiLayoutItem1991;
        private MultiLayoutItem multiLayoutItem1992;
        private MultiLayoutItem multiLayoutItem1993;
        private MultiLayoutItem multiLayoutItem1994;
        private MultiLayoutItem multiLayoutItem1995;
        private MultiLayoutItem multiLayoutItem1996;
        private MultiLayoutItem multiLayoutItem1997;
        private MultiLayoutItem multiLayoutItem1998;
        private MultiLayoutItem multiLayoutItem1999;
        private MultiLayoutItem multiLayoutItem2000;
        private MultiLayoutItem multiLayoutItem2001;
        private MultiLayoutItem multiLayoutItem2002;
        private MultiLayoutItem multiLayoutItem2003;
        private MultiLayoutItem multiLayoutItem2004;
        private MultiLayoutItem multiLayoutItem2005;
        private MultiLayoutItem multiLayoutItem2006;
        private MultiLayoutItem multiLayoutItem2007;
        private MultiLayoutItem multiLayoutItem2008;
        private MultiLayoutItem multiLayoutItem2009;
        private MultiLayoutItem multiLayoutItem2010;
        private MultiLayoutItem multiLayoutItem2011;
        private MultiLayoutItem multiLayoutItem2012;
        private MultiLayoutItem multiLayoutItem2013;
        private MultiLayoutItem multiLayoutItem2014;
        private MultiLayoutItem multiLayoutItem2015;
        private MultiLayoutItem multiLayoutItem2016;
        private MultiLayoutItem multiLayoutItem2017;
        private MultiLayoutItem multiLayoutItem2018;
        private MultiLayoutItem multiLayoutItem2019;
        private MultiLayoutItem multiLayoutItem2020;
        private MultiLayoutItem multiLayoutItem2021;
        private MultiLayoutItem multiLayoutItem2022;
        private MultiLayoutItem multiLayoutItem2023;
        private MultiLayoutItem multiLayoutItem2024;
        private MultiLayoutItem multiLayoutItem2025;
        private MultiLayoutItem multiLayoutItem2026;
        private MultiLayoutItem multiLayoutItem2027;
        private MultiLayoutItem multiLayoutItem2028;
        private MultiLayoutItem multiLayoutItem2029;
        private MultiLayoutItem multiLayoutItem2030;
        private MultiLayoutItem multiLayoutItem2031;
        private MultiLayoutItem multiLayoutItem2032;
        private MultiLayoutItem multiLayoutItem2033;
        private MultiLayoutItem multiLayoutItem2034;
        private MultiLayoutItem multiLayoutItem2035;
        private MultiLayoutItem multiLayoutItem2036;
        private MultiLayoutItem multiLayoutItem2037;
        private MultiLayoutItem multiLayoutItem2038;
        private MultiLayoutItem multiLayoutItem2039;
        private MultiLayoutItem multiLayoutItem2040;
        private MultiLayoutItem multiLayoutItem2041;
        private MultiLayoutItem multiLayoutItem2042;
        private MultiLayoutItem multiLayoutItem2043;
        private MultiLayoutItem multiLayoutItem2044;
        private MultiLayoutItem multiLayoutItem2045;
        private MultiLayoutItem multiLayoutItem2046;
        private MultiLayoutItem multiLayoutItem2047;
        private MultiLayoutItem multiLayoutItem2048;
        private MultiLayoutItem multiLayoutItem2049;
        private MultiLayoutItem multiLayoutItem2050;
        private MultiLayoutItem multiLayoutItem2051;
        private MultiLayoutItem multiLayoutItem2052;
        private MultiLayoutItem multiLayoutItem2053;
        private MultiLayoutItem multiLayoutItem2054;
        private MultiLayoutItem multiLayoutItem2055;
        private MultiLayoutItem multiLayoutItem2056;
        private MultiLayoutItem multiLayoutItem2057;
        private MultiLayoutItem multiLayoutItem2058;
        private MultiLayoutItem multiLayoutItem2059;
        private MultiLayoutItem multiLayoutItem2060;
        private MultiLayoutItem multiLayoutItem2061;
        private MultiLayoutItem multiLayoutItem2062;
        private MultiLayoutItem multiLayoutItem2063;
        private MultiLayoutItem multiLayoutItem2064;
        private MultiLayoutItem multiLayoutItem2065;
        private MultiLayoutItem multiLayoutItem2066;
        private MultiLayoutItem multiLayoutItem2067;
        private MultiLayoutItem multiLayoutItem2068;
        private MultiLayoutItem multiLayoutItem2069;
        private MultiLayoutItem multiLayoutItem2070;
        private MultiLayoutItem multiLayoutItem2071;
        private MultiLayoutItem multiLayoutItem2072;
        private MultiLayoutItem multiLayoutItem2073;
        private MultiLayoutItem multiLayoutItem2074;
        private MultiLayoutItem multiLayoutItem2075;
        private MultiLayoutItem multiLayoutItem2076;
        private MultiLayoutItem multiLayoutItem2077;
        private MultiLayoutItem multiLayoutItem2078;
        private MultiLayoutItem multiLayoutItem2079;
        private MultiLayoutItem multiLayoutItem2080;
        private MultiLayoutItem multiLayoutItem2081;
        private MultiLayoutItem multiLayoutItem2082;
        private MultiLayoutItem multiLayoutItem2083;
        private MultiLayoutItem multiLayoutItem2084;
        private MultiLayoutItem multiLayoutItem2085;
        private MultiLayoutItem multiLayoutItem2086;
        private MultiLayoutItem multiLayoutItem2087;
        private MultiLayoutItem multiLayoutItem2088;
        private MultiLayoutItem multiLayoutItem2089;
        private MultiLayoutItem multiLayoutItem2090;
        private MultiLayoutItem multiLayoutItem2091;
        private MultiLayoutItem multiLayoutItem2092;
        private MultiLayoutItem multiLayoutItem2093;
        private MultiLayoutItem multiLayoutItem2094;
        private MultiLayoutItem multiLayoutItem2095;
        private MultiLayoutItem multiLayoutItem2096;
        private MultiLayoutItem multiLayoutItem2097;
        private MultiLayoutItem multiLayoutItem2098;
        private MultiLayoutItem multiLayoutItem2099;
        private MultiLayoutItem multiLayoutItem2100;
        private MultiLayoutItem multiLayoutItem2101;
        private MultiLayoutItem multiLayoutItem2102;
        private MultiLayoutItem multiLayoutItem2103;
        private MultiLayoutItem multiLayoutItem2104;
        private MultiLayoutItem multiLayoutItem2105;
        private MultiLayoutItem multiLayoutItem2106;
        private MultiLayoutItem multiLayoutItem2107;
        private MultiLayoutItem multiLayoutItem2108;
        private MultiLayoutItem multiLayoutItem2109;
        private MultiLayoutItem multiLayoutItem2110;
        private MultiLayoutItem multiLayoutItem2111;
        private MultiLayoutItem multiLayoutItem2112;
        private MultiLayoutItem multiLayoutItem2113;
        private MultiLayoutItem multiLayoutItem2114;
        private MultiLayoutItem multiLayoutItem2115;
        private MultiLayoutItem multiLayoutItem2116;
        private MultiLayoutItem multiLayoutItem2117;
        private MultiLayoutItem multiLayoutItem2118;
        private MultiLayoutItem multiLayoutItem2119;
        private MultiLayoutItem multiLayoutItem2120;
        private MultiLayoutItem multiLayoutItem2121;
        private MultiLayoutItem multiLayoutItem2122;
        private MultiLayoutItem multiLayoutItem2123;
        private MultiLayoutItem multiLayoutItem3336;
        private MultiLayout layPfeOrder;
        private MultiLayoutItem multiLayoutItem726;
        private MultiLayoutItem multiLayoutItem727;
        private MultiLayoutItem multiLayoutItem728;
        private MultiLayoutItem multiLayoutItem729;
        private MultiLayoutItem multiLayoutItem730;
        private MultiLayoutItem multiLayoutItem731;
        private MultiLayoutItem multiLayoutItem732;
        private MultiLayoutItem multiLayoutItem733;
        private MultiLayoutItem multiLayoutItem734;
        private MultiLayoutItem multiLayoutItem735;
        private MultiLayoutItem multiLayoutItem736;
        private MultiLayoutItem multiLayoutItem737;
        private MultiLayoutItem multiLayoutItem738;
        private MultiLayoutItem multiLayoutItem739;
        private MultiLayoutItem multiLayoutItem740;
        private MultiLayoutItem multiLayoutItem741;
        private MultiLayoutItem multiLayoutItem742;
        private MultiLayoutItem multiLayoutItem743;
        private MultiLayoutItem multiLayoutItem744;
        private MultiLayoutItem multiLayoutItem745;
        private MultiLayoutItem multiLayoutItem746;
        private MultiLayoutItem multiLayoutItem747;
        private MultiLayoutItem multiLayoutItem748;
        private MultiLayoutItem multiLayoutItem749;
        private MultiLayoutItem multiLayoutItem750;
        private MultiLayoutItem multiLayoutItem751;
        private MultiLayoutItem multiLayoutItem752;
        private MultiLayoutItem multiLayoutItem753;
        private MultiLayoutItem multiLayoutItem754;
        private MultiLayoutItem multiLayoutItem755;
        private MultiLayoutItem multiLayoutItem756;
        private MultiLayoutItem multiLayoutItem757;
        private MultiLayoutItem multiLayoutItem758;
        private MultiLayoutItem multiLayoutItem759;
        private MultiLayoutItem multiLayoutItem760;
        private MultiLayoutItem multiLayoutItem761;
        private MultiLayoutItem multiLayoutItem762;
        private MultiLayoutItem multiLayoutItem763;
        private MultiLayoutItem multiLayoutItem764;
        private MultiLayoutItem multiLayoutItem765;
        private MultiLayoutItem multiLayoutItem766;
        private MultiLayoutItem multiLayoutItem767;
        private MultiLayoutItem multiLayoutItem768;
        private MultiLayoutItem multiLayoutItem769;
        private MultiLayoutItem multiLayoutItem770;
        private MultiLayoutItem multiLayoutItem771;
        private MultiLayoutItem multiLayoutItem772;
        private MultiLayoutItem multiLayoutItem773;
        private MultiLayoutItem multiLayoutItem774;
        private MultiLayoutItem multiLayoutItem775;
        private MultiLayoutItem multiLayoutItem776;
        private MultiLayoutItem multiLayoutItem777;
        private MultiLayoutItem multiLayoutItem778;
        private MultiLayoutItem multiLayoutItem779;
        private MultiLayoutItem multiLayoutItem780;
        private MultiLayoutItem multiLayoutItem781;
        private MultiLayoutItem multiLayoutItem782;
        private MultiLayoutItem multiLayoutItem783;
        private MultiLayoutItem multiLayoutItem784;
        private MultiLayoutItem multiLayoutItem785;
        private MultiLayoutItem multiLayoutItem786;
        private MultiLayoutItem multiLayoutItem787;
        private MultiLayoutItem multiLayoutItem788;
        private MultiLayoutItem multiLayoutItem789;
        private MultiLayoutItem multiLayoutItem790;
        private MultiLayoutItem multiLayoutItem791;
        private MultiLayoutItem multiLayoutItem792;
        private MultiLayoutItem multiLayoutItem793;
        private MultiLayoutItem multiLayoutItem794;
        private MultiLayoutItem multiLayoutItem795;
        private MultiLayoutItem multiLayoutItem796;
        private MultiLayoutItem multiLayoutItem797;
        private MultiLayoutItem multiLayoutItem798;
        private MultiLayoutItem multiLayoutItem799;
        private MultiLayoutItem multiLayoutItem800;
        private MultiLayoutItem multiLayoutItem801;
        private MultiLayoutItem multiLayoutItem802;
        private MultiLayoutItem multiLayoutItem803;
        private MultiLayoutItem multiLayoutItem804;
        private MultiLayoutItem multiLayoutItem805;
        private MultiLayoutItem multiLayoutItem806;
        private MultiLayoutItem multiLayoutItem807;
        private MultiLayoutItem multiLayoutItem808;
        private MultiLayoutItem multiLayoutItem809;
        private MultiLayoutItem multiLayoutItem810;
        private MultiLayoutItem multiLayoutItem811;
        private MultiLayoutItem multiLayoutItem812;
        private MultiLayoutItem multiLayoutItem813;
        private MultiLayoutItem multiLayoutItem814;
        private MultiLayoutItem multiLayoutItem815;
        private MultiLayoutItem multiLayoutItem816;
        private MultiLayoutItem multiLayoutItem817;
        private MultiLayoutItem multiLayoutItem818;
        private MultiLayoutItem multiLayoutItem819;
        private MultiLayoutItem multiLayoutItem820;
        private MultiLayoutItem multiLayoutItem821;
        private MultiLayoutItem multiLayoutItem822;
        private MultiLayoutItem multiLayoutItem823;
        private MultiLayoutItem multiLayoutItem824;
        private MultiLayoutItem multiLayoutItem825;
        private MultiLayoutItem multiLayoutItem826;
        private MultiLayoutItem multiLayoutItem827;
        private MultiLayoutItem multiLayoutItem828;
        private MultiLayoutItem multiLayoutItem829;
        private MultiLayoutItem multiLayoutItem830;
        private MultiLayoutItem multiLayoutItem831;
        private MultiLayoutItem multiLayoutItem832;
        private MultiLayoutItem multiLayoutItem833;
        private MultiLayoutItem multiLayoutItem834;
        private MultiLayoutItem multiLayoutItem835;
        private MultiLayoutItem multiLayoutItem836;
        private MultiLayoutItem multiLayoutItem837;
        private MultiLayoutItem multiLayoutItem838;
        private MultiLayoutItem multiLayoutItem839;
        private MultiLayoutItem multiLayoutItem840;
        private MultiLayoutItem multiLayoutItem841;
        private MultiLayoutItem multiLayoutItem842;
        private MultiLayoutItem multiLayoutItem843;
        private MultiLayoutItem multiLayoutItem844;
        private MultiLayoutItem multiLayoutItem845;
        private MultiLayoutItem multiLayoutItem846;
        private MultiLayoutItem multiLayoutItem847;
        private MultiLayoutItem multiLayoutItem848;
        private MultiLayoutItem multiLayoutItem849;
        private MultiLayoutItem multiLayoutItem850;
        private MultiLayoutItem multiLayoutItem851;
        private MultiLayoutItem multiLayoutItem852;
        private MultiLayoutItem multiLayoutItem853;
        private MultiLayoutItem multiLayoutItem854;
        private MultiLayoutItem multiLayoutItem855;
        private MultiLayoutItem multiLayoutItem856;
        private MultiLayoutItem multiLayoutItem857;
        private MultiLayoutItem multiLayoutItem858;
        private MultiLayoutItem multiLayoutItem859;
        private MultiLayoutItem multiLayoutItem860;
        private MultiLayoutItem multiLayoutItem861;
        private MultiLayoutItem multiLayoutItem862;
        private MultiLayoutItem multiLayoutItem863;
        private MultiLayoutItem multiLayoutItem864;
        private MultiLayoutItem multiLayoutItem865;
        private MultiLayoutItem multiLayoutItem866;
        private MultiLayoutItem multiLayoutItem867;
        private MultiLayoutItem multiLayoutItem868;
        private MultiLayoutItem multiLayoutItem1026;
        private MultiLayoutItem multiLayoutItem1027;
        private MultiLayoutItem multiLayoutItem1028;
        private MultiLayoutItem multiLayoutItem1032;
        private MultiLayoutItem multiLayoutItem1932;
        private MultiLayoutItem multiLayoutItem1948;
        private MultiLayoutItem multiLayoutItem1949;
        private MultiLayout layAplOrder;
        private MultiLayoutItem multiLayoutItem550;
        private MultiLayoutItem multiLayoutItem551;
        private MultiLayoutItem multiLayoutItem552;
        private MultiLayoutItem multiLayoutItem553;
        private MultiLayoutItem multiLayoutItem554;
        private MultiLayoutItem multiLayoutItem555;
        private MultiLayoutItem multiLayoutItem556;
        private MultiLayoutItem multiLayoutItem557;
        private MultiLayoutItem multiLayoutItem558;
        private MultiLayoutItem multiLayoutItem559;
        private MultiLayoutItem multiLayoutItem560;
        private MultiLayoutItem multiLayoutItem561;
        private MultiLayoutItem multiLayoutItem562;
        private MultiLayoutItem multiLayoutItem563;
        private MultiLayoutItem multiLayoutItem564;
        private MultiLayoutItem multiLayoutItem565;
        private MultiLayoutItem multiLayoutItem566;
        private MultiLayoutItem multiLayoutItem567;
        private MultiLayoutItem multiLayoutItem568;
        private MultiLayoutItem multiLayoutItem569;
        private MultiLayoutItem multiLayoutItem570;
        private MultiLayoutItem multiLayoutItem571;
        private MultiLayoutItem multiLayoutItem572;
        private MultiLayoutItem multiLayoutItem573;
        private MultiLayoutItem multiLayoutItem574;
        private MultiLayoutItem multiLayoutItem575;
        private MultiLayoutItem multiLayoutItem576;
        private MultiLayoutItem multiLayoutItem577;
        private MultiLayoutItem multiLayoutItem578;
        private MultiLayoutItem multiLayoutItem579;
        private MultiLayoutItem multiLayoutItem580;
        private MultiLayoutItem multiLayoutItem581;
        private MultiLayoutItem multiLayoutItem582;
        private MultiLayoutItem multiLayoutItem583;
        private MultiLayoutItem multiLayoutItem584;
        private MultiLayoutItem multiLayoutItem585;
        private MultiLayoutItem multiLayoutItem586;
        private MultiLayoutItem multiLayoutItem587;
        private MultiLayoutItem multiLayoutItem588;
        private MultiLayoutItem multiLayoutItem589;
        private MultiLayoutItem multiLayoutItem590;
        private MultiLayoutItem multiLayoutItem591;
        private MultiLayoutItem multiLayoutItem592;
        private MultiLayoutItem multiLayoutItem593;
        private MultiLayoutItem multiLayoutItem594;
        private MultiLayoutItem multiLayoutItem595;
        private MultiLayoutItem multiLayoutItem596;
        private MultiLayoutItem multiLayoutItem597;
        private MultiLayoutItem multiLayoutItem598;
        private MultiLayoutItem multiLayoutItem599;
        private MultiLayoutItem multiLayoutItem600;
        private MultiLayoutItem multiLayoutItem601;
        private MultiLayoutItem multiLayoutItem602;
        private MultiLayoutItem multiLayoutItem603;
        private MultiLayoutItem multiLayoutItem604;
        private MultiLayoutItem multiLayoutItem605;
        private MultiLayoutItem multiLayoutItem606;
        private MultiLayoutItem multiLayoutItem607;
        private MultiLayoutItem multiLayoutItem608;
        private MultiLayoutItem multiLayoutItem609;
        private MultiLayoutItem multiLayoutItem610;
        private MultiLayoutItem multiLayoutItem611;
        private MultiLayoutItem multiLayoutItem612;
        private MultiLayoutItem multiLayoutItem613;
        private MultiLayoutItem multiLayoutItem614;
        private MultiLayoutItem multiLayoutItem615;
        private MultiLayoutItem multiLayoutItem616;
        private MultiLayoutItem multiLayoutItem617;
        private MultiLayoutItem multiLayoutItem618;
        private MultiLayoutItem multiLayoutItem619;
        private MultiLayoutItem multiLayoutItem620;
        private MultiLayoutItem multiLayoutItem621;
        private MultiLayoutItem multiLayoutItem622;
        private MultiLayoutItem multiLayoutItem623;
        private MultiLayoutItem multiLayoutItem624;
        private MultiLayoutItem multiLayoutItem625;
        private MultiLayoutItem multiLayoutItem626;
        private MultiLayoutItem multiLayoutItem627;
        private MultiLayoutItem multiLayoutItem628;
        private MultiLayoutItem multiLayoutItem629;
        private MultiLayoutItem multiLayoutItem630;
        private MultiLayoutItem multiLayoutItem631;
        private MultiLayoutItem multiLayoutItem632;
        private MultiLayoutItem multiLayoutItem633;
        private MultiLayoutItem multiLayoutItem634;
        private MultiLayoutItem multiLayoutItem635;
        private MultiLayoutItem multiLayoutItem636;
        private MultiLayoutItem multiLayoutItem637;
        private MultiLayoutItem multiLayoutItem638;
        private MultiLayoutItem multiLayoutItem639;
        private MultiLayoutItem multiLayoutItem640;
        private MultiLayoutItem multiLayoutItem641;
        private MultiLayoutItem multiLayoutItem642;
        private MultiLayoutItem multiLayoutItem643;
        private MultiLayoutItem multiLayoutItem644;
        private MultiLayoutItem multiLayoutItem645;
        private MultiLayoutItem multiLayoutItem646;
        private MultiLayoutItem multiLayoutItem647;
        private MultiLayoutItem multiLayoutItem648;
        private MultiLayoutItem multiLayoutItem649;
        private MultiLayoutItem multiLayoutItem650;
        private MultiLayoutItem multiLayoutItem651;
        private MultiLayoutItem multiLayoutItem652;
        private MultiLayoutItem multiLayoutItem653;
        private MultiLayoutItem multiLayoutItem654;
        private MultiLayoutItem multiLayoutItem655;
        private MultiLayoutItem multiLayoutItem656;
        private MultiLayoutItem multiLayoutItem657;
        private MultiLayoutItem multiLayoutItem658;
        private MultiLayoutItem multiLayoutItem659;
        private MultiLayoutItem multiLayoutItem660;
        private MultiLayoutItem multiLayoutItem661;
        private MultiLayoutItem multiLayoutItem662;
        private MultiLayoutItem multiLayoutItem663;
        private MultiLayoutItem multiLayoutItem664;
        private MultiLayoutItem multiLayoutItem665;
        private MultiLayoutItem multiLayoutItem666;
        private MultiLayoutItem multiLayoutItem667;
        private MultiLayoutItem multiLayoutItem668;
        private MultiLayoutItem multiLayoutItem669;
        private MultiLayoutItem multiLayoutItem670;
        private MultiLayoutItem multiLayoutItem671;
        private MultiLayoutItem multiLayoutItem672;
        private MultiLayoutItem multiLayoutItem673;
        private MultiLayoutItem multiLayoutItem674;
        private MultiLayoutItem multiLayoutItem675;
        private MultiLayoutItem multiLayoutItem676;
        private MultiLayoutItem multiLayoutItem677;
        private MultiLayoutItem multiLayoutItem678;
        private MultiLayoutItem multiLayoutItem679;
        private MultiLayoutItem multiLayoutItem680;
        private MultiLayoutItem multiLayoutItem681;
        private MultiLayoutItem multiLayoutItem682;
        private MultiLayoutItem multiLayoutItem683;
        private MultiLayoutItem multiLayoutItem684;
        private MultiLayoutItem multiLayoutItem685;
        private MultiLayoutItem multiLayoutItem686;
        private MultiLayoutItem multiLayoutItem704;
        private MultiLayoutItem multiLayoutItem705;
        private MultiLayoutItem multiLayoutItem706;
        private MultiLayoutItem multiLayoutItem714;
        private MultiLayoutItem multiLayoutItem715;
        private MultiLayoutItem multiLayoutItem716;
        private MultiLayoutItem multiLayoutItem1024;
        private MultiLayoutItem multiLayoutItem1025;
        private MultiLayoutItem multiLayoutItem1030;
        private MultiLayoutItem multiLayoutItem1040;
        private MultiLayoutItem multiLayoutItem1933;
        private MultiLayoutItem multiLayoutItem1934;
        private MultiLayoutItem multiLayoutItem1950;
        private MultiLayout laySusulOrder;
        private MultiLayoutItem multiLayoutItem147;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem150;
        private MultiLayoutItem multiLayoutItem151;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem153;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem155;
        private MultiLayoutItem multiLayoutItem36;
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem158;
        private MultiLayoutItem multiLayoutItem38;
        private MultiLayoutItem multiLayoutItem39;
        private MultiLayoutItem multiLayoutItem161;
        private MultiLayoutItem multiLayoutItem162;
        private MultiLayoutItem multiLayoutItem163;
        private MultiLayoutItem multiLayoutItem164;
        private MultiLayoutItem multiLayoutItem165;
        private MultiLayoutItem multiLayoutItem166;
        private MultiLayoutItem multiLayoutItem167;
        private MultiLayoutItem multiLayoutItem168;
        private MultiLayoutItem multiLayoutItem169;
        private MultiLayoutItem multiLayoutItem170;
        private MultiLayoutItem multiLayoutItem171;
        private MultiLayoutItem multiLayoutItem172;
        private MultiLayoutItem multiLayoutItem173;
        private MultiLayoutItem multiLayoutItem174;
        private MultiLayoutItem multiLayoutItem175;
        private MultiLayoutItem multiLayoutItem176;
        private MultiLayoutItem multiLayoutItem177;
        private MultiLayoutItem multiLayoutItem178;
        private MultiLayoutItem multiLayoutItem179;
        private MultiLayoutItem multiLayoutItem180;
        private MultiLayoutItem multiLayoutItem181;
        private MultiLayoutItem multiLayoutItem182;
        private MultiLayoutItem multiLayoutItem183;
        private MultiLayoutItem multiLayoutItem184;
        private MultiLayoutItem multiLayoutItem185;
        private MultiLayoutItem multiLayoutItem186;
        private MultiLayoutItem multiLayoutItem187;
        private MultiLayoutItem multiLayoutItem188;
        private MultiLayoutItem multiLayoutItem189;
        private MultiLayoutItem multiLayoutItem190;
        private MultiLayoutItem multiLayoutItem191;
        private MultiLayoutItem multiLayoutItem192;
        private MultiLayoutItem multiLayoutItem193;
        private MultiLayoutItem multiLayoutItem194;
        private MultiLayoutItem multiLayoutItem195;
        private MultiLayoutItem multiLayoutItem196;
        private MultiLayoutItem multiLayoutItem197;
        private MultiLayoutItem multiLayoutItem198;
        private MultiLayoutItem multiLayoutItem199;
        private MultiLayoutItem multiLayoutItem200;
        private MultiLayoutItem multiLayoutItem201;
        private MultiLayoutItem multiLayoutItem202;
        private MultiLayoutItem multiLayoutItem203;
        private MultiLayoutItem multiLayoutItem204;
        private MultiLayoutItem multiLayoutItem205;
        private MultiLayoutItem multiLayoutItem206;
        private MultiLayoutItem multiLayoutItem207;
        private MultiLayoutItem multiLayoutItem208;
        private MultiLayoutItem multiLayoutItem209;
        private MultiLayoutItem multiLayoutItem210;
        private MultiLayoutItem multiLayoutItem211;
        private MultiLayoutItem multiLayoutItem212;
        private MultiLayoutItem multiLayoutItem213;
        private MultiLayoutItem multiLayoutItem214;
        private MultiLayoutItem multiLayoutItem215;
        private MultiLayoutItem multiLayoutItem216;
        private MultiLayoutItem multiLayoutItem217;
        private MultiLayoutItem multiLayoutItem218;
        private MultiLayoutItem multiLayoutItem219;
        private MultiLayoutItem multiLayoutItem220;
        private MultiLayoutItem multiLayoutItem221;
        private MultiLayoutItem multiLayoutItem222;
        private MultiLayoutItem multiLayoutItem223;
        private MultiLayoutItem multiLayoutItem224;
        private MultiLayoutItem multiLayoutItem225;
        private MultiLayoutItem multiLayoutItem226;
        private MultiLayoutItem multiLayoutItem227;
        private MultiLayoutItem multiLayoutItem228;
        private MultiLayoutItem multiLayoutItem229;
        private MultiLayoutItem multiLayoutItem230;
        private MultiLayoutItem multiLayoutItem231;
        private MultiLayoutItem multiLayoutItem232;
        private MultiLayoutItem multiLayoutItem233;
        private MultiLayoutItem multiLayoutItem234;
        private MultiLayoutItem multiLayoutItem235;
        private MultiLayoutItem multiLayoutItem236;
        private MultiLayoutItem multiLayoutItem237;
        private MultiLayoutItem multiLayoutItem238;
        private MultiLayoutItem multiLayoutItem239;
        private MultiLayoutItem multiLayoutItem240;
        private MultiLayoutItem multiLayoutItem241;
        private MultiLayoutItem multiLayoutItem242;
        private MultiLayoutItem multiLayoutItem243;
        private MultiLayoutItem multiLayoutItem244;
        private MultiLayoutItem multiLayoutItem245;
        private MultiLayoutItem multiLayoutItem246;
        private MultiLayoutItem multiLayoutItem247;
        private MultiLayoutItem multiLayoutItem248;
        private MultiLayoutItem multiLayoutItem249;
        private MultiLayoutItem multiLayoutItem250;
        private MultiLayoutItem multiLayoutItem251;
        private MultiLayoutItem multiLayoutItem252;
        private MultiLayoutItem multiLayoutItem253;
        private MultiLayoutItem multiLayoutItem254;
        private MultiLayoutItem multiLayoutItem255;
        private MultiLayoutItem multiLayoutItem256;
        private MultiLayoutItem multiLayoutItem257;
        private MultiLayoutItem multiLayoutItem258;
        private MultiLayoutItem multiLayoutItem259;
        private MultiLayoutItem multiLayoutItem260;
        private MultiLayoutItem multiLayoutItem261;
        private MultiLayoutItem multiLayoutItem262;
        private MultiLayoutItem multiLayoutItem263;
        private MultiLayoutItem multiLayoutItem264;
        private MultiLayoutItem multiLayoutItem265;
        private MultiLayoutItem multiLayoutItem266;
        private MultiLayoutItem multiLayoutItem267;
        private MultiLayoutItem multiLayoutItem268;
        private MultiLayoutItem multiLayoutItem269;
        private MultiLayoutItem multiLayoutItem270;
        private MultiLayoutItem multiLayoutItem271;
        private MultiLayoutItem multiLayoutItem272;
        private MultiLayoutItem multiLayoutItem273;
        private MultiLayoutItem multiLayoutItem274;
        private MultiLayoutItem multiLayoutItem275;
        private MultiLayoutItem multiLayoutItem276;
        private MultiLayoutItem multiLayoutItem277;
        private MultiLayoutItem multiLayoutItem278;
        private MultiLayoutItem multiLayoutItem279;
        private MultiLayoutItem multiLayoutItem280;
        private MultiLayoutItem multiLayoutItem281;
        private MultiLayoutItem multiLayoutItem282;
        private MultiLayoutItem multiLayoutItem283;
        private MultiLayoutItem multiLayoutItem707;
        private MultiLayoutItem multiLayoutItem708;
        private MultiLayoutItem multiLayoutItem709;
        private MultiLayoutItem multiLayoutItem710;
        private MultiLayoutItem multiLayoutItem721;
        private MultiLayoutItem multiLayoutItem722;
        private MultiLayoutItem multiLayoutItem1022;
        private MultiLayoutItem multiLayoutItem1023;
        private MultiLayoutItem multiLayoutItem1041;
        private MultiLayoutItem multiLayoutItem1186;
        private MultiLayoutItem multiLayoutItem1187;
        private MultiLayoutItem multiLayoutItem1935;
        private MultiLayoutItem multiLayoutItem1951;
        private MultiLayout layEtcOrder;
        private MultiLayoutItem multiLayoutItem1188;
        private MultiLayoutItem multiLayoutItem1189;
        private MultiLayoutItem multiLayoutItem1190;
        private MultiLayoutItem multiLayoutItem1191;
        private MultiLayoutItem multiLayoutItem1192;
        private MultiLayoutItem multiLayoutItem1193;
        private MultiLayoutItem multiLayoutItem1194;
        private MultiLayoutItem multiLayoutItem1195;
        private MultiLayoutItem multiLayoutItem1196;
        private MultiLayoutItem multiLayoutItem1197;
        private MultiLayoutItem multiLayoutItem1198;
        private MultiLayoutItem multiLayoutItem1199;
        private MultiLayoutItem multiLayoutItem1200;
        private MultiLayoutItem multiLayoutItem1201;
        private MultiLayoutItem multiLayoutItem1202;
        private MultiLayoutItem multiLayoutItem1203;
        private MultiLayoutItem multiLayoutItem1204;
        private MultiLayoutItem multiLayoutItem1205;
        private MultiLayoutItem multiLayoutItem1206;
        private MultiLayoutItem multiLayoutItem1207;
        private MultiLayoutItem multiLayoutItem1208;
        private MultiLayoutItem multiLayoutItem1209;
        private MultiLayoutItem multiLayoutItem1210;
        private MultiLayoutItem multiLayoutItem1211;
        private MultiLayoutItem multiLayoutItem1212;
        private MultiLayoutItem multiLayoutItem1213;
        private MultiLayoutItem multiLayoutItem1214;
        private MultiLayoutItem multiLayoutItem1215;
        private MultiLayoutItem multiLayoutItem1216;
        private MultiLayoutItem multiLayoutItem1217;
        private MultiLayoutItem multiLayoutItem1218;
        private MultiLayoutItem multiLayoutItem1219;
        private MultiLayoutItem multiLayoutItem1220;
        private MultiLayoutItem multiLayoutItem1221;
        private MultiLayoutItem multiLayoutItem1222;
        private MultiLayoutItem multiLayoutItem1223;
        private MultiLayoutItem multiLayoutItem1224;
        private MultiLayoutItem multiLayoutItem1225;
        private MultiLayoutItem multiLayoutItem1226;
        private MultiLayoutItem multiLayoutItem1227;
        private MultiLayoutItem multiLayoutItem1228;
        private MultiLayoutItem multiLayoutItem1229;
        private MultiLayoutItem multiLayoutItem1230;
        private MultiLayoutItem multiLayoutItem1231;
        private MultiLayoutItem multiLayoutItem1232;
        private MultiLayoutItem multiLayoutItem1233;
        private MultiLayoutItem multiLayoutItem1234;
        private MultiLayoutItem multiLayoutItem1235;
        private MultiLayoutItem multiLayoutItem1236;
        private MultiLayoutItem multiLayoutItem1237;
        private MultiLayoutItem multiLayoutItem1238;
        private MultiLayoutItem multiLayoutItem1239;
        private MultiLayoutItem multiLayoutItem1240;
        private MultiLayoutItem multiLayoutItem1241;
        private MultiLayoutItem multiLayoutItem1242;
        private MultiLayoutItem multiLayoutItem1243;
        private MultiLayoutItem multiLayoutItem1244;
        private MultiLayoutItem multiLayoutItem1245;
        private MultiLayoutItem multiLayoutItem1246;
        private MultiLayoutItem multiLayoutItem1247;
        private MultiLayoutItem multiLayoutItem1248;
        private MultiLayoutItem multiLayoutItem1249;
        private MultiLayoutItem multiLayoutItem1250;
        private MultiLayoutItem multiLayoutItem1251;
        private MultiLayoutItem multiLayoutItem1252;
        private MultiLayoutItem multiLayoutItem1253;
        private MultiLayoutItem multiLayoutItem1254;
        private MultiLayoutItem multiLayoutItem1255;
        private MultiLayoutItem multiLayoutItem1256;
        private MultiLayoutItem multiLayoutItem1257;
        private MultiLayoutItem multiLayoutItem1258;
        private MultiLayoutItem multiLayoutItem1259;
        private MultiLayoutItem multiLayoutItem1260;
        private MultiLayoutItem multiLayoutItem1261;
        private MultiLayoutItem multiLayoutItem1262;
        private MultiLayoutItem multiLayoutItem1263;
        private MultiLayoutItem multiLayoutItem1264;
        private MultiLayoutItem multiLayoutItem1265;
        private MultiLayoutItem multiLayoutItem1266;
        private MultiLayoutItem multiLayoutItem1267;
        private MultiLayoutItem multiLayoutItem1268;
        private MultiLayoutItem multiLayoutItem1269;
        private MultiLayoutItem multiLayoutItem1270;
        private MultiLayoutItem multiLayoutItem1271;
        private MultiLayoutItem multiLayoutItem1272;
        private MultiLayoutItem multiLayoutItem1273;
        private MultiLayoutItem multiLayoutItem1274;
        private MultiLayoutItem multiLayoutItem1275;
        private MultiLayoutItem multiLayoutItem1276;
        private MultiLayoutItem multiLayoutItem1277;
        private MultiLayoutItem multiLayoutItem1278;
        private MultiLayoutItem multiLayoutItem1279;
        private MultiLayoutItem multiLayoutItem1280;
        private MultiLayoutItem multiLayoutItem1281;
        private MultiLayoutItem multiLayoutItem1282;
        private MultiLayoutItem multiLayoutItem1283;
        private MultiLayoutItem multiLayoutItem1284;
        private MultiLayoutItem multiLayoutItem1285;
        private MultiLayoutItem multiLayoutItem1286;
        private MultiLayoutItem multiLayoutItem1287;
        private MultiLayoutItem multiLayoutItem1288;
        private MultiLayoutItem multiLayoutItem1289;
        private MultiLayoutItem multiLayoutItem1290;
        private MultiLayoutItem multiLayoutItem1291;
        private MultiLayoutItem multiLayoutItem1292;
        private MultiLayoutItem multiLayoutItem1293;
        private MultiLayoutItem multiLayoutItem1294;
        private MultiLayoutItem multiLayoutItem1295;
        private MultiLayoutItem multiLayoutItem1296;
        private MultiLayoutItem multiLayoutItem1297;
        private MultiLayoutItem multiLayoutItem1298;
        private MultiLayoutItem multiLayoutItem1299;
        private MultiLayoutItem multiLayoutItem1300;
        private MultiLayoutItem multiLayoutItem1301;
        private MultiLayoutItem multiLayoutItem1302;
        private MultiLayoutItem multiLayoutItem1303;
        private MultiLayoutItem multiLayoutItem1304;
        private MultiLayoutItem multiLayoutItem1305;
        private MultiLayoutItem multiLayoutItem1306;
        private MultiLayoutItem multiLayoutItem1307;
        private MultiLayoutItem multiLayoutItem1308;
        private MultiLayoutItem multiLayoutItem1309;
        private MultiLayoutItem multiLayoutItem1310;
        private MultiLayoutItem multiLayoutItem1311;
        private MultiLayoutItem multiLayoutItem1312;
        private MultiLayoutItem multiLayoutItem1313;
        private MultiLayoutItem multiLayoutItem1314;
        private MultiLayoutItem multiLayoutItem1315;
        private MultiLayoutItem multiLayoutItem1316;
        private MultiLayoutItem multiLayoutItem1317;
        private MultiLayoutItem multiLayoutItem1318;
        private MultiLayoutItem multiLayoutItem1319;
        private MultiLayoutItem multiLayoutItem1320;
        private MultiLayoutItem multiLayoutItem1321;
        private MultiLayoutItem multiLayoutItem1322;
        private MultiLayoutItem multiLayoutItem1323;
        private MultiLayoutItem multiLayoutItem1324;
        private MultiLayoutItem multiLayoutItem1325;
        private MultiLayoutItem multiLayoutItem1326;
        private MultiLayoutItem multiLayoutItem1327;
        private MultiLayoutItem multiLayoutItem1328;
        private MultiLayoutItem multiLayoutItem1329;
        private MultiLayoutItem multiLayoutItem1330;
        private MultiLayoutItem multiLayoutItem1331;
        private MultiLayoutItem multiLayoutItem1332;
        private MultiLayoutItem multiLayoutItem1333;
        private MultiLayoutItem multiLayoutItem1334;
        private MultiLayoutItem multiLayoutItem1335;
        private MultiLayoutItem multiLayoutItem1936;
        private MultiLayoutItem multiLayoutItem1952;
        private MultiLayout layXrtOrder;
        private MultiLayoutItem multiLayoutItem1336;
        private MultiLayoutItem multiLayoutItem1337;
        private MultiLayoutItem multiLayoutItem1338;
        private MultiLayoutItem multiLayoutItem1339;
        private MultiLayoutItem multiLayoutItem1340;
        private MultiLayoutItem multiLayoutItem1341;
        private MultiLayoutItem multiLayoutItem1342;
        private MultiLayoutItem multiLayoutItem1343;
        private MultiLayoutItem multiLayoutItem1344;
        private MultiLayoutItem multiLayoutItem1345;
        private MultiLayoutItem multiLayoutItem1346;
        private MultiLayoutItem multiLayoutItem1347;
        private MultiLayoutItem multiLayoutItem1348;
        private MultiLayoutItem multiLayoutItem1349;
        private MultiLayoutItem multiLayoutItem1350;
        private MultiLayoutItem multiLayoutItem1351;
        private MultiLayoutItem multiLayoutItem1352;
        private MultiLayoutItem multiLayoutItem1353;
        private MultiLayoutItem multiLayoutItem1354;
        private MultiLayoutItem multiLayoutItem1355;
        private MultiLayoutItem multiLayoutItem1356;
        private MultiLayoutItem multiLayoutItem1357;
        private MultiLayoutItem multiLayoutItem1358;
        private MultiLayoutItem multiLayoutItem1359;
        private MultiLayoutItem multiLayoutItem1360;
        private MultiLayoutItem multiLayoutItem1361;
        private MultiLayoutItem multiLayoutItem1362;
        private MultiLayoutItem multiLayoutItem1363;
        private MultiLayoutItem multiLayoutItem1364;
        private MultiLayoutItem multiLayoutItem1365;
        private MultiLayoutItem multiLayoutItem1366;
        private MultiLayoutItem multiLayoutItem1367;
        private MultiLayoutItem multiLayoutItem1368;
        private MultiLayoutItem multiLayoutItem1369;
        private MultiLayoutItem multiLayoutItem1370;
        private MultiLayoutItem multiLayoutItem1371;
        private MultiLayoutItem multiLayoutItem1372;
        private MultiLayoutItem multiLayoutItem1373;
        private MultiLayoutItem multiLayoutItem1374;
        private MultiLayoutItem multiLayoutItem1375;
        private MultiLayoutItem multiLayoutItem1376;
        private MultiLayoutItem multiLayoutItem1377;
        private MultiLayoutItem multiLayoutItem1378;
        private MultiLayoutItem multiLayoutItem1379;
        private MultiLayoutItem multiLayoutItem1380;
        private MultiLayoutItem multiLayoutItem1381;
        private MultiLayoutItem multiLayoutItem1382;
        private MultiLayoutItem multiLayoutItem1383;
        private MultiLayoutItem multiLayoutItem1384;
        private MultiLayoutItem multiLayoutItem1385;
        private MultiLayoutItem multiLayoutItem1386;
        private MultiLayoutItem multiLayoutItem1387;
        private MultiLayoutItem multiLayoutItem1388;
        private MultiLayoutItem multiLayoutItem1389;
        private MultiLayoutItem multiLayoutItem1390;
        private MultiLayoutItem multiLayoutItem1391;
        private MultiLayoutItem multiLayoutItem1392;
        private MultiLayoutItem multiLayoutItem1393;
        private MultiLayoutItem multiLayoutItem1394;
        private MultiLayoutItem multiLayoutItem1395;
        private MultiLayoutItem multiLayoutItem1396;
        private MultiLayoutItem multiLayoutItem1397;
        private MultiLayoutItem multiLayoutItem1398;
        private MultiLayoutItem multiLayoutItem1399;
        private MultiLayoutItem multiLayoutItem1400;
        private MultiLayoutItem multiLayoutItem1401;
        private MultiLayoutItem multiLayoutItem1402;
        private MultiLayoutItem multiLayoutItem1403;
        private MultiLayoutItem multiLayoutItem1404;
        private MultiLayoutItem multiLayoutItem1405;
        private MultiLayoutItem multiLayoutItem1406;
        private MultiLayoutItem multiLayoutItem1407;
        private MultiLayoutItem multiLayoutItem1408;
        private MultiLayoutItem multiLayoutItem1409;
        private MultiLayoutItem multiLayoutItem1410;
        private MultiLayoutItem multiLayoutItem1411;
        private MultiLayoutItem multiLayoutItem1412;
        private MultiLayoutItem multiLayoutItem1413;
        private MultiLayoutItem multiLayoutItem1414;
        private MultiLayoutItem multiLayoutItem1415;
        private MultiLayoutItem multiLayoutItem1416;
        private MultiLayoutItem multiLayoutItem1417;
        private MultiLayoutItem multiLayoutItem1418;
        private MultiLayoutItem multiLayoutItem1419;
        private MultiLayoutItem multiLayoutItem1420;
        private MultiLayoutItem multiLayoutItem1421;
        private MultiLayoutItem multiLayoutItem1422;
        private MultiLayoutItem multiLayoutItem1423;
        private MultiLayoutItem multiLayoutItem1424;
        private MultiLayoutItem multiLayoutItem1425;
        private MultiLayoutItem multiLayoutItem1426;
        private MultiLayoutItem multiLayoutItem1427;
        private MultiLayoutItem multiLayoutItem1428;
        private MultiLayoutItem multiLayoutItem1429;
        private MultiLayoutItem multiLayoutItem1430;
        private MultiLayoutItem multiLayoutItem1431;
        private MultiLayoutItem multiLayoutItem1432;
        private MultiLayoutItem multiLayoutItem1433;
        private MultiLayoutItem multiLayoutItem1434;
        private MultiLayoutItem multiLayoutItem1435;
        private MultiLayoutItem multiLayoutItem1436;
        private MultiLayoutItem multiLayoutItem1437;
        private MultiLayoutItem multiLayoutItem1438;
        private MultiLayoutItem multiLayoutItem1439;
        private MultiLayoutItem multiLayoutItem1440;
        private MultiLayoutItem multiLayoutItem1441;
        private MultiLayoutItem multiLayoutItem1442;
        private MultiLayoutItem multiLayoutItem1443;
        private MultiLayoutItem multiLayoutItem1444;
        private MultiLayoutItem multiLayoutItem1445;
        private MultiLayoutItem multiLayoutItem1446;
        private MultiLayoutItem multiLayoutItem1447;
        private MultiLayoutItem multiLayoutItem1448;
        private MultiLayoutItem multiLayoutItem1449;
        private MultiLayoutItem multiLayoutItem1450;
        private MultiLayoutItem multiLayoutItem1451;
        private MultiLayoutItem multiLayoutItem1452;
        private MultiLayoutItem multiLayoutItem1453;
        private MultiLayoutItem multiLayoutItem1454;
        private MultiLayoutItem multiLayoutItem1455;
        private MultiLayoutItem multiLayoutItem1456;
        private MultiLayoutItem multiLayoutItem1457;
        private MultiLayoutItem multiLayoutItem1458;
        private MultiLayoutItem multiLayoutItem1459;
        private MultiLayoutItem multiLayoutItem1460;
        private MultiLayoutItem multiLayoutItem1461;
        private MultiLayoutItem multiLayoutItem1462;
        private MultiLayoutItem multiLayoutItem1463;
        private MultiLayoutItem multiLayoutItem1464;
        private MultiLayoutItem multiLayoutItem1465;
        private MultiLayoutItem multiLayoutItem1466;
        private MultiLayoutItem multiLayoutItem1467;
        private MultiLayoutItem multiLayoutItem1468;
        private MultiLayoutItem multiLayoutItem1469;
        private MultiLayoutItem multiLayoutItem1470;
        private MultiLayoutItem multiLayoutItem1471;
        private MultiLayoutItem multiLayoutItem1472;
        private MultiLayoutItem multiLayoutItem1473;
        private MultiLayoutItem multiLayoutItem1474;
        private MultiLayoutItem multiLayoutItem1475;
        private MultiLayoutItem multiLayoutItem1476;
        private MultiLayoutItem multiLayoutItem1477;
        private MultiLayoutItem multiLayoutItem1478;
        private MultiLayoutItem multiLayoutItem1479;
        private MultiLayoutItem multiLayoutItem1480;
        private MultiLayoutItem multiLayoutItem1481;
        private MultiLayoutItem multiLayoutItem1482;
        private MultiLayoutItem multiLayoutItem1483;
        private MultiLayoutItem multiLayoutItem1937;
        private MultiLayoutItem multiLayoutItem1953;
        private MultiLayout layChuchiOrder;
        private MultiLayoutItem multiLayoutItem1031;
        private MultiLayoutItem multiLayoutItem1036;
        private MultiLayoutItem multiLayoutItem1037;
        private MultiLayoutItem multiLayoutItem1038;
        private MultiLayoutItem multiLayoutItem1039;
        private MultiLayoutItem multiLayoutItem1042;
        private MultiLayoutItem multiLayoutItem1043;
        private MultiLayoutItem multiLayoutItem1044;
        private MultiLayoutItem multiLayoutItem1045;
        private MultiLayoutItem multiLayoutItem1046;
        private MultiLayoutItem multiLayoutItem1047;
        private MultiLayoutItem multiLayoutItem1048;
        private MultiLayoutItem multiLayoutItem1049;
        private MultiLayoutItem multiLayoutItem1050;
        private MultiLayoutItem multiLayoutItem1051;
        private MultiLayoutItem multiLayoutItem1052;
        private MultiLayoutItem multiLayoutItem1053;
        private MultiLayoutItem multiLayoutItem1054;
        private MultiLayoutItem multiLayoutItem1055;
        private MultiLayoutItem multiLayoutItem1056;
        private MultiLayoutItem multiLayoutItem1057;
        private MultiLayoutItem multiLayoutItem1058;
        private MultiLayoutItem multiLayoutItem1059;
        private MultiLayoutItem multiLayoutItem1060;
        private MultiLayoutItem multiLayoutItem1061;
        private MultiLayoutItem multiLayoutItem1062;
        private MultiLayoutItem multiLayoutItem1063;
        private MultiLayoutItem multiLayoutItem1064;
        private MultiLayoutItem multiLayoutItem1065;
        private MultiLayoutItem multiLayoutItem1066;
        private MultiLayoutItem multiLayoutItem1067;
        private MultiLayoutItem multiLayoutItem1068;
        private MultiLayoutItem multiLayoutItem1069;
        private MultiLayoutItem multiLayoutItem1070;
        private MultiLayoutItem multiLayoutItem1071;
        private MultiLayoutItem multiLayoutItem1072;
        private MultiLayoutItem multiLayoutItem1073;
        private MultiLayoutItem multiLayoutItem1074;
        private MultiLayoutItem multiLayoutItem1075;
        private MultiLayoutItem multiLayoutItem1076;
        private MultiLayoutItem multiLayoutItem1077;
        private MultiLayoutItem multiLayoutItem1078;
        private MultiLayoutItem multiLayoutItem1079;
        private MultiLayoutItem multiLayoutItem1080;
        private MultiLayoutItem multiLayoutItem1081;
        private MultiLayoutItem multiLayoutItem1082;
        private MultiLayoutItem multiLayoutItem1083;
        private MultiLayoutItem multiLayoutItem1084;
        private MultiLayoutItem multiLayoutItem1085;
        private MultiLayoutItem multiLayoutItem1086;
        private MultiLayoutItem multiLayoutItem1087;
        private MultiLayoutItem multiLayoutItem1088;
        private MultiLayoutItem multiLayoutItem1089;
        private MultiLayoutItem multiLayoutItem1090;
        private MultiLayoutItem multiLayoutItem1091;
        private MultiLayoutItem multiLayoutItem1092;
        private MultiLayoutItem multiLayoutItem1093;
        private MultiLayoutItem multiLayoutItem1094;
        private MultiLayoutItem multiLayoutItem1095;
        private MultiLayoutItem multiLayoutItem1096;
        private MultiLayoutItem multiLayoutItem1097;
        private MultiLayoutItem multiLayoutItem1098;
        private MultiLayoutItem multiLayoutItem1099;
        private MultiLayoutItem multiLayoutItem1100;
        private MultiLayoutItem multiLayoutItem1101;
        private MultiLayoutItem multiLayoutItem1102;
        private MultiLayoutItem multiLayoutItem1103;
        private MultiLayoutItem multiLayoutItem1104;
        private MultiLayoutItem multiLayoutItem1105;
        private MultiLayoutItem multiLayoutItem1106;
        private MultiLayoutItem multiLayoutItem1107;
        private MultiLayoutItem multiLayoutItem1108;
        private MultiLayoutItem multiLayoutItem1109;
        private MultiLayoutItem multiLayoutItem1110;
        private MultiLayoutItem multiLayoutItem1111;
        private MultiLayoutItem multiLayoutItem1112;
        private MultiLayoutItem multiLayoutItem1113;
        private MultiLayoutItem multiLayoutItem1114;
        private MultiLayoutItem multiLayoutItem1115;
        private MultiLayoutItem multiLayoutItem1116;
        private MultiLayoutItem multiLayoutItem1117;
        private MultiLayoutItem multiLayoutItem1118;
        private MultiLayoutItem multiLayoutItem1119;
        private MultiLayoutItem multiLayoutItem1120;
        private MultiLayoutItem multiLayoutItem1121;
        private MultiLayoutItem multiLayoutItem1122;
        private MultiLayoutItem multiLayoutItem1123;
        private MultiLayoutItem multiLayoutItem1124;
        private MultiLayoutItem multiLayoutItem1125;
        private MultiLayoutItem multiLayoutItem1126;
        private MultiLayoutItem multiLayoutItem1127;
        private MultiLayoutItem multiLayoutItem1128;
        private MultiLayoutItem multiLayoutItem1129;
        private MultiLayoutItem multiLayoutItem1130;
        private MultiLayoutItem multiLayoutItem1131;
        private MultiLayoutItem multiLayoutItem1132;
        private MultiLayoutItem multiLayoutItem1133;
        private MultiLayoutItem multiLayoutItem1134;
        private MultiLayoutItem multiLayoutItem1135;
        private MultiLayoutItem multiLayoutItem1136;
        private MultiLayoutItem multiLayoutItem1137;
        private MultiLayoutItem multiLayoutItem1138;
        private MultiLayoutItem multiLayoutItem1139;
        private MultiLayoutItem multiLayoutItem1140;
        private MultiLayoutItem multiLayoutItem1141;
        private MultiLayoutItem multiLayoutItem1142;
        private MultiLayoutItem multiLayoutItem1143;
        private MultiLayoutItem multiLayoutItem1144;
        private MultiLayoutItem multiLayoutItem1145;
        private MultiLayoutItem multiLayoutItem1146;
        private MultiLayoutItem multiLayoutItem1147;
        private MultiLayoutItem multiLayoutItem1148;
        private MultiLayoutItem multiLayoutItem1149;
        private MultiLayoutItem multiLayoutItem1150;
        private MultiLayoutItem multiLayoutItem1151;
        private MultiLayoutItem multiLayoutItem1152;
        private MultiLayoutItem multiLayoutItem1153;
        private MultiLayoutItem multiLayoutItem1154;
        private MultiLayoutItem multiLayoutItem1155;
        private MultiLayoutItem multiLayoutItem1156;
        private MultiLayoutItem multiLayoutItem1157;
        private MultiLayoutItem multiLayoutItem1158;
        private MultiLayoutItem multiLayoutItem1159;
        private MultiLayoutItem multiLayoutItem1160;
        private MultiLayoutItem multiLayoutItem1161;
        private MultiLayoutItem multiLayoutItem1162;
        private MultiLayoutItem multiLayoutItem1163;
        private MultiLayoutItem multiLayoutItem1164;
        private MultiLayoutItem multiLayoutItem1165;
        private MultiLayoutItem multiLayoutItem1166;
        private MultiLayoutItem multiLayoutItem1167;
        private MultiLayoutItem multiLayoutItem1168;
        private MultiLayoutItem multiLayoutItem1169;
        private MultiLayoutItem multiLayoutItem1170;
        private MultiLayoutItem multiLayoutItem1171;
        private MultiLayoutItem multiLayoutItem1172;
        private MultiLayoutItem multiLayoutItem1173;
        private MultiLayoutItem multiLayoutItem1174;
        private MultiLayoutItem multiLayoutItem1175;
        private MultiLayoutItem multiLayoutItem1176;
        private MultiLayoutItem multiLayoutItem1177;
        private MultiLayoutItem multiLayoutItem1178;
        private MultiLayoutItem multiLayoutItem1179;
        private MultiLayoutItem multiLayoutItem1180;
        private MultiLayoutItem multiLayoutItem1181;
        private MultiLayoutItem multiLayoutItem1182;
        private MultiLayoutItem multiLayoutItem1183;
        private MultiLayoutItem multiLayoutItem1184;
        private MultiLayoutItem multiLayoutItem1185;
        private MultiLayoutItem multiLayoutItem1946;
        private MultiLayout layDrugOrder;
        private MultiLayoutItem multiLayoutItem421;
        private MultiLayoutItem multiLayoutItem422;
        private MultiLayoutItem multiLayoutItem423;
        private MultiLayoutItem multiLayoutItem424;
        private MultiLayoutItem multiLayoutItem425;
        private MultiLayoutItem multiLayoutItem426;
        private MultiLayoutItem multiLayoutItem427;
        private MultiLayoutItem multiLayoutItem428;
        private MultiLayoutItem multiLayoutItem429;
        private MultiLayoutItem multiLayoutItem430;
        private MultiLayoutItem multiLayoutItem431;
        private MultiLayoutItem multiLayoutItem1792;
        private MultiLayoutItem multiLayoutItem1793;
        private MultiLayoutItem multiLayoutItem1794;
        private MultiLayoutItem multiLayoutItem1795;
        private MultiLayoutItem multiLayoutItem1796;
        private MultiLayoutItem multiLayoutItem1797;
        private MultiLayoutItem multiLayoutItem1798;
        private MultiLayoutItem multiLayoutItem1799;
        private MultiLayoutItem multiLayoutItem1800;
        private MultiLayoutItem multiLayoutItem1801;
        private MultiLayoutItem multiLayoutItem1802;
        private MultiLayoutItem multiLayoutItem1803;
        private MultiLayoutItem multiLayoutItem1804;
        private MultiLayoutItem multiLayoutItem1805;
        private MultiLayoutItem multiLayoutItem1806;
        private MultiLayoutItem multiLayoutItem1807;
        private MultiLayoutItem multiLayoutItem1808;
        private MultiLayoutItem multiLayoutItem1809;
        private MultiLayoutItem multiLayoutItem1810;
        private MultiLayoutItem multiLayoutItem1811;
        private MultiLayoutItem multiLayoutItem1812;
        private MultiLayoutItem multiLayoutItem1813;
        private MultiLayoutItem multiLayoutItem1814;
        private MultiLayoutItem multiLayoutItem1815;
        private MultiLayoutItem multiLayoutItem1816;
        private MultiLayoutItem multiLayoutItem1817;
        private MultiLayoutItem multiLayoutItem1818;
        private MultiLayoutItem multiLayoutItem1819;
        private MultiLayoutItem multiLayoutItem1820;
        private MultiLayoutItem multiLayoutItem1821;
        private MultiLayoutItem multiLayoutItem1822;
        private MultiLayoutItem multiLayoutItem1823;
        private MultiLayoutItem multiLayoutItem1824;
        private MultiLayoutItem multiLayoutItem1825;
        private MultiLayoutItem multiLayoutItem1826;
        private MultiLayoutItem multiLayoutItem1827;
        private MultiLayoutItem multiLayoutItem1828;
        private MultiLayoutItem multiLayoutItem1829;
        private MultiLayoutItem multiLayoutItem1830;
        private MultiLayoutItem multiLayoutItem1831;
        private MultiLayoutItem multiLayoutItem1832;
        private MultiLayoutItem multiLayoutItem1833;
        private MultiLayoutItem multiLayoutItem1834;
        private MultiLayoutItem multiLayoutItem1835;
        private MultiLayoutItem multiLayoutItem1836;
        private MultiLayoutItem multiLayoutItem1837;
        private MultiLayoutItem multiLayoutItem1838;
        private MultiLayoutItem multiLayoutItem1839;
        private MultiLayoutItem multiLayoutItem1840;
        private MultiLayoutItem multiLayoutItem1841;
        private MultiLayoutItem multiLayoutItem1842;
        private MultiLayoutItem multiLayoutItem1843;
        private MultiLayoutItem multiLayoutItem1844;
        private MultiLayoutItem multiLayoutItem1845;
        private MultiLayoutItem multiLayoutItem1846;
        private MultiLayoutItem multiLayoutItem1847;
        private MultiLayoutItem multiLayoutItem1848;
        private MultiLayoutItem multiLayoutItem1849;
        private MultiLayoutItem multiLayoutItem1850;
        private MultiLayoutItem multiLayoutItem1851;
        private MultiLayoutItem multiLayoutItem1852;
        private MultiLayoutItem multiLayoutItem1853;
        private MultiLayoutItem multiLayoutItem1854;
        private MultiLayoutItem multiLayoutItem1855;
        private MultiLayoutItem multiLayoutItem1856;
        private MultiLayoutItem multiLayoutItem1857;
        private MultiLayoutItem multiLayoutItem1858;
        private MultiLayoutItem multiLayoutItem1859;
        private MultiLayoutItem multiLayoutItem1860;
        private MultiLayoutItem multiLayoutItem1861;
        private MultiLayoutItem multiLayoutItem1862;
        private MultiLayoutItem multiLayoutItem1863;
        private MultiLayoutItem multiLayoutItem1864;
        private MultiLayoutItem multiLayoutItem1865;
        private MultiLayoutItem multiLayoutItem1866;
        private MultiLayoutItem multiLayoutItem1867;
        private MultiLayoutItem multiLayoutItem1868;
        private MultiLayoutItem multiLayoutItem1869;
        private MultiLayoutItem multiLayoutItem1870;
        private MultiLayoutItem multiLayoutItem1871;
        private MultiLayoutItem multiLayoutItem1872;
        private MultiLayoutItem multiLayoutItem1873;
        private MultiLayoutItem multiLayoutItem1874;
        private MultiLayoutItem multiLayoutItem1875;
        private MultiLayoutItem multiLayoutItem1876;
        private MultiLayoutItem multiLayoutItem1877;
        private MultiLayoutItem multiLayoutItem1878;
        private MultiLayoutItem multiLayoutItem1879;
        private MultiLayoutItem multiLayoutItem1880;
        private MultiLayoutItem multiLayoutItem1881;
        private MultiLayoutItem multiLayoutItem1882;
        private MultiLayoutItem multiLayoutItem1883;
        private MultiLayoutItem multiLayoutItem1884;
        private MultiLayoutItem multiLayoutItem1885;
        private MultiLayoutItem multiLayoutItem1886;
        private MultiLayoutItem multiLayoutItem1887;
        private MultiLayoutItem multiLayoutItem1888;
        private MultiLayoutItem multiLayoutItem1889;
        private MultiLayoutItem multiLayoutItem1890;
        private MultiLayoutItem multiLayoutItem1891;
        private MultiLayoutItem multiLayoutItem1892;
        private MultiLayoutItem multiLayoutItem1893;
        private MultiLayoutItem multiLayoutItem1894;
        private MultiLayoutItem multiLayoutItem1895;
        private MultiLayoutItem multiLayoutItem1896;
        private MultiLayoutItem multiLayoutItem1897;
        private MultiLayoutItem multiLayoutItem1898;
        private MultiLayoutItem multiLayoutItem1899;
        private MultiLayoutItem multiLayoutItem1900;
        private MultiLayoutItem multiLayoutItem1901;
        private MultiLayoutItem multiLayoutItem1902;
        private MultiLayoutItem multiLayoutItem1903;
        private MultiLayoutItem multiLayoutItem1904;
        private MultiLayoutItem multiLayoutItem1905;
        private MultiLayoutItem multiLayoutItem1906;
        private MultiLayoutItem multiLayoutItem1907;
        private MultiLayoutItem multiLayoutItem1908;
        private MultiLayoutItem multiLayoutItem1909;
        private MultiLayoutItem multiLayoutItem1910;
        private MultiLayoutItem multiLayoutItem1911;
        private MultiLayoutItem multiLayoutItem1912;
        private MultiLayoutItem multiLayoutItem1913;
        private MultiLayoutItem multiLayoutItem1914;
        private MultiLayoutItem multiLayoutItem1915;
        private MultiLayoutItem multiLayoutItem1916;
        private MultiLayoutItem multiLayoutItem1917;
        private MultiLayoutItem multiLayoutItem1918;
        private MultiLayoutItem multiLayoutItem1919;
        private MultiLayoutItem multiLayoutItem1920;
        private MultiLayoutItem multiLayoutItem1921;
        private MultiLayoutItem multiLayoutItem1922;
        private MultiLayoutItem multiLayoutItem1923;
        private MultiLayoutItem multiLayoutItem1924;
        private MultiLayoutItem multiLayoutItem1925;
        private MultiLayoutItem multiLayoutItem1926;
        private MultiLayoutItem multiLayoutItem1927;
        private MultiLayoutItem multiLayoutItem1942;
        private MultiLayoutItem multiLayoutItem1943;
        private MultiLayoutItem multiLayoutItem1944;
        private MultiLayoutItem multiLayoutItem1945;
        private MultiLayoutItem multiLayoutItem1947;
        private XButton btnNextWeek;
        private XButton btnPreWeek;
        private XButton btnGraph;
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
        private MultiLayoutItem multiLayoutItem124;
        private MultiLayoutItem multiLayoutItem125;
        private MultiLayoutItem multiLayoutItem126;
        private MultiLayoutItem multiLayoutItem127;
        private MultiLayoutItem multiLayoutItem128;
        private MultiLayoutItem multiLayoutItem129;
        private MultiLayoutItem multiLayoutItem130;
        private MultiLayoutItem multiLayoutItem131;
        private MultiLayoutItem multiLayoutItem132;
        private MultiLayoutItem multiLayoutItem133;
        private MultiLayoutItem multiLayoutItem134;
        private MultiLayoutItem multiLayoutItem135;
        private MultiLayoutItem multiLayoutItem136;
        private MultiLayoutItem multiLayoutItem137;
        private MultiLayoutItem multiLayoutItem138;
        private MultiLayoutItem multiLayoutItem139;
        private MultiLayoutItem multiLayoutItem140;
        private MultiLayoutItem multiLayoutItem141;
        private MultiLayoutItem multiLayoutItem142;
        private MultiLayoutItem multiLayoutItem143;
        private MultiLayoutItem multiLayoutItem144;
        private MultiLayoutItem multiLayoutItem145;
        private MultiLayoutItem multiLayoutItem146;
        private MultiLayoutItem multiLayoutItem284;
        private MultiLayoutItem multiLayoutItem285;
        private MultiLayoutItem multiLayoutItem286;
        private MultiLayoutItem multiLayoutItem287;
        private MultiLayoutItem multiLayoutItem288;
        private MultiLayoutItem multiLayoutItem289;
        private MultiLayoutItem multiLayoutItem290;
        private MultiLayoutItem multiLayoutItem291;
        private MultiLayoutItem multiLayoutItem292;
        private MultiLayoutItem multiLayoutItem293;
        private MultiLayoutItem multiLayoutItem294;
        private MultiLayoutItem multiLayoutItem295;
        private MultiLayoutItem multiLayoutItem296;
        private MultiLayoutItem multiLayoutItem297;
        private MultiLayoutItem multiLayoutItem298;
        private MultiLayoutItem multiLayoutItem299;
        private MultiLayoutItem multiLayoutItem300;
        private MultiLayoutItem multiLayoutItem301;
        private MultiLayoutItem multiLayoutItem302;
        private MultiLayoutItem multiLayoutItem303;
        private MultiLayoutItem multiLayoutItem304;
        private MultiLayoutItem multiLayoutItem305;
        private MultiLayoutItem multiLayoutItem306;
        private MultiLayoutItem multiLayoutItem307;
        private MultiLayoutItem multiLayoutItem308;
        private MultiLayoutItem multiLayoutItem309;
        private MultiLayoutItem multiLayoutItem312;
        private MultiLayoutItem multiLayoutItem313;
        private MultiLayoutItem multiLayoutItem314;
        private MultiLayoutItem multiLayoutItem315;
        private MultiLayoutItem multiLayoutItem316;
        private MultiLayoutItem multiLayoutItem321;
        private MultiLayoutItem multiLayoutItem322;
        private MultiLayoutItem multiLayoutItem325;
        private XButton btnEmergencyTreatDisplayYN;
        private XButton btnCommentOnOff;
        private XButton btnRemarkOnOff;
		private System.ComponentModel.IContainer components;
        #endregion

        public OCS6010U10()
        {
            /* SavePerformer 생성 */
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            this.dloItemData.SavePerformer = new XSavePerformer(this);
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.dloItemData);

			this.mPatientInfo = new IHIS.OCS.PatientInfo(this.ScreenID);    // OCS 환자정보 그룹 라이브러리 
			this.mOrderFunc   = new IHIS.OCS.OrderFunc();                   // OCS 그룹 Function 라이브러리			
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS6010U10));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.pbxBunho = new IHIS.Framework.XPatientBox();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnGraph = new IHIS.Framework.XButton();
            this.btnOpenOrder = new IHIS.Framework.XButton();
            this.btnShowProcessPlan = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlMid_top = new IHIS.Framework.XPanel();
            this.btnNextWeek = new IHIS.Framework.XButton();
            this.btnPreWeek = new IHIS.Framework.XButton();
            this.dbxConfirmUserName = new IHIS.Framework.XDisplayBox();
            this.txtConfirmUser = new IHIS.Framework.XTextBox();
            this.lblNurseId = new IHIS.Framework.XLabel();
            this.btnNextPeriod = new IHIS.Framework.XButton();
            this.dpkTo_date = new IHIS.Framework.XDatePicker();
            this.dpkFrom_date = new IHIS.Framework.XDatePicker();
            this.btnCommentOnOff = new IHIS.Framework.XButton();
            this.btnEmergencyTreatDisplayYN = new IHIS.Framework.XButton();
            this.btnPrePeriod = new IHIS.Framework.XButton();
            this.xFlatLabel2 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.btnClearConfirmUser = new IHIS.Framework.XButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dtpApp_To_date = new IHIS.Framework.XDatePicker();
            this.dloItemData = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem124 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem125 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem126 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem127 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem128 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem129 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem130 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem131 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem132 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem133 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem134 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem135 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem136 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem137 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem138 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem139 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem140 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem141 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem142 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem143 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem144 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem145 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem146 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem284 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem285 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem286 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem287 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem288 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem289 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem290 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem291 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem292 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem293 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem294 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem295 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem296 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem297 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem298 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem299 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem300 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem301 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem302 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem303 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem304 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem305 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem306 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem307 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem308 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem309 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem312 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem313 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem314 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem315 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem316 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem321 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem322 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem325 = new IHIS.Framework.MultiLayoutItem();
            this.dloInput_gubun = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem62 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem63 = new IHIS.Framework.MultiLayoutItem();
            this.mtxPlanMgt = new IHIS.Framework.XMatrix();
            this.pnlPosition = new System.Windows.Forms.Panel();
            this.dloProcessInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem57 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem58 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem59 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem60 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem61 = new IHIS.Framework.MultiLayoutItem();
            this.pnlProcessApplyPlan = new IHIS.Framework.XPanel();
            this.rbtSiksa = new IHIS.Framework.XRadioButton();
            this.rbtJusa = new IHIS.Framework.XRadioButton();
            this.rbtPJ = new IHIS.Framework.XRadioButton();
            this.rbtAll = new IHIS.Framework.XRadioButton();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.dwSiksaJunpyo = new IHIS.Framework.XDataWindow();
            this.btnProcessPlanClose = new IHIS.Framework.XButton();
            this.dApp_From_date = new IHIS.Framework.XDatePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProcessPlan = new IHIS.Framework.XButton();
            this.dloProcessInfo1 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem64 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem65 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem66 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem67 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem68 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem69 = new IHIS.Framework.MultiLayoutItem();
            this.tabQuery = new IHIS.Framework.XTabControl();
            this.laySiksaJunpyo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
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
            this.xToolTip1 = new IHIS.Framework.XToolTip();
            this.layQueryLayout = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1484 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1485 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1486 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1487 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1488 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1489 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1490 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1491 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1492 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1493 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1494 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1495 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1496 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1497 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1498 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1499 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1517 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1518 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1519 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1520 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1521 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1522 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1523 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1524 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1525 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1526 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1527 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1528 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1529 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1530 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1531 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1532 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1533 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1534 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1535 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1536 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1537 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1538 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1539 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1540 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1541 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1542 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1543 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1544 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1545 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1546 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1547 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1548 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1549 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1550 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1551 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1552 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1553 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1554 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1555 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1556 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1557 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1558 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1559 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1560 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1561 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1562 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1563 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1564 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1565 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1566 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1567 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1568 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1569 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1570 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1571 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1572 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1573 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1574 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1575 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1576 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1577 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1578 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1579 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1580 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1581 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1582 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1583 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1584 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1585 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1586 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1587 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1588 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1589 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1590 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1591 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1592 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1593 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1594 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1595 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1596 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1597 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1598 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1599 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1600 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1601 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1602 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1603 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1604 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1605 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1606 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1607 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1608 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1609 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1610 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1611 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1612 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1613 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1614 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1615 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1616 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1617 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1618 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1619 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1620 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1621 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1622 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1623 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1624 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1625 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1626 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1627 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1628 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1629 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1630 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1631 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1632 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1633 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1634 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1635 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1636 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1637 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1638 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1639 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1640 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1641 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1642 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1643 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1644 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1645 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1660 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1938 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1954 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1955 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1956 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1957 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1958 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1959 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1960 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1961 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1962 = new IHIS.Framework.MultiLayoutItem();
            this.layCplOrder = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem432 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem433 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem434 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem435 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem436 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem437 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem438 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem439 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem440 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem441 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem442 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem443 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem444 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem445 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem446 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem447 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem448 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem449 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem450 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem451 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem452 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem453 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem454 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem455 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem456 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem457 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem458 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem459 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem460 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem461 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem462 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem463 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem464 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem465 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem466 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem467 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem468 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem469 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem470 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem471 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem472 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem473 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem474 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem475 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem476 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem477 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem478 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem479 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem480 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem481 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem482 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem483 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem484 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem485 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem486 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem487 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem488 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem489 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem490 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem491 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem492 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem493 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem494 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem495 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem496 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem497 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem498 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem499 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem500 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem501 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem502 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem503 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem504 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem505 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem506 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem507 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem508 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem509 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem510 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem511 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem512 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem513 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem514 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem515 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem516 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem517 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem518 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem519 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem520 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem521 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem522 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem523 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem524 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem525 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem526 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem527 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem528 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem529 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem530 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem531 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem532 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem533 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem534 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem535 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem536 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem537 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem538 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem539 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem540 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem541 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem542 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem543 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem544 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem545 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem546 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem547 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem548 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem549 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem687 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem688 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem689 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem690 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem691 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem692 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem693 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem694 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem701 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem702 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem703 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem713 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem723 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem724 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1013 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1014 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1015 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1016 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1029 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1928 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1929 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1930 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1931 = new IHIS.Framework.MultiLayoutItem();
            this.layJusaOrder = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1972 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1973 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1974 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1975 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1976 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1977 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1978 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1979 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1980 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1981 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1982 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1983 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1984 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1985 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1986 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1987 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1988 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1989 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1990 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1991 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1992 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1993 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1994 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1995 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1996 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1997 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1998 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1999 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2000 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2001 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2002 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2003 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2004 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2005 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2006 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2007 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2008 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2009 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2010 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2011 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2012 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2013 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2014 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2015 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2016 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2017 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2018 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2019 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2020 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2021 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2022 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2023 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2024 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2025 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2026 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2027 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2028 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2029 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2030 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2031 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2032 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2033 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2034 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2035 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2036 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2037 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2038 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2039 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2040 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2041 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2042 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2043 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2044 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2045 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2046 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2047 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2048 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2049 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2050 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2051 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2052 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2053 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2054 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2055 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2056 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2057 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2058 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2059 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2060 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2061 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2062 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2063 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2064 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2065 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2066 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2067 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2068 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2069 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2070 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2071 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2072 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2073 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2074 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2075 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2076 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2077 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2078 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2079 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2080 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2081 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2082 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2083 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2084 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2085 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2086 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2087 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2088 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2089 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2090 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2091 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2092 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2093 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2094 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2095 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2096 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2097 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2098 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2099 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2100 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2101 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2102 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2103 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2104 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2105 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2106 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2107 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2108 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2109 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2110 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2111 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2112 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2113 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2114 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2115 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2116 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2117 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2118 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2119 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2120 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2121 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2122 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2123 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3336 = new IHIS.Framework.MultiLayoutItem();
            this.layPfeOrder = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem726 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem727 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem728 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem729 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem730 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem731 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem732 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem733 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem734 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem735 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem736 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem737 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem738 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem739 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem740 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem741 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem742 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem743 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem744 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem745 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem746 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem747 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem748 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem749 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem750 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem751 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem752 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem753 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem754 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem755 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem756 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem757 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem758 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem759 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem760 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem761 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem762 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem763 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem764 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem765 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem766 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem767 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem768 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem769 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem770 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem771 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem772 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem773 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem774 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem775 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem776 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem777 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem778 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem779 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem780 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem781 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem782 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem783 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem784 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem785 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem786 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem787 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem788 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem789 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem790 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem791 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem792 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem793 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem794 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem795 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem796 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem797 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem798 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem799 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem800 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem801 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem802 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem803 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem804 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem805 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem806 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem807 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem808 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem809 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem810 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem811 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem812 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem813 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem814 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem815 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem816 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem817 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem818 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem819 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem820 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem821 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem822 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem823 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem824 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem825 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem826 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem827 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem828 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem829 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem830 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem831 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem832 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem833 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem834 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem835 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem836 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem837 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem838 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem839 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem840 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem841 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem842 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem843 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem844 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem845 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem846 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem847 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem848 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem849 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem850 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem851 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem852 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem853 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem854 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem855 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem856 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem857 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem858 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem859 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem860 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem861 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem862 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem863 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem864 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem865 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem866 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem867 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem868 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1026 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1027 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1028 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1032 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1932 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1948 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1949 = new IHIS.Framework.MultiLayoutItem();
            this.layAplOrder = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem550 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem551 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem552 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem553 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem554 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem555 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem556 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem557 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem558 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem559 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem560 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem561 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem562 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem563 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem564 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem565 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem566 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem567 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem568 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem569 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem570 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem571 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem572 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem573 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem574 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem575 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem576 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem577 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem578 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem579 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem580 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem581 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem582 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem583 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem584 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem585 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem586 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem587 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem588 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem589 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem590 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem591 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem592 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem593 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem594 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem595 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem596 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem597 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem598 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem599 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem600 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem601 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem602 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem603 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem604 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem605 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem606 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem607 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem608 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem609 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem610 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem611 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem612 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem613 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem614 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem615 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem616 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem617 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem618 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem619 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem620 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem621 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem622 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem623 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem624 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem625 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem626 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem627 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem628 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem629 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem630 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem631 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem632 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem633 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem634 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem635 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem636 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem637 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem638 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem639 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem640 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem641 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem642 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem643 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem644 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem645 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem646 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem647 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem648 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem649 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem650 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem651 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem652 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem653 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem654 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem655 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem656 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem657 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem658 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem659 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem660 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem661 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem662 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem663 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem664 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem665 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem666 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem667 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem668 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem669 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem670 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem671 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem672 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem673 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem674 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem675 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem676 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem677 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem678 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem679 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem680 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem681 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem682 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem683 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem684 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem685 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem686 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem704 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem705 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem706 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem714 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem715 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem716 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1024 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1025 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1030 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1040 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1933 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1934 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1950 = new IHIS.Framework.MultiLayoutItem();
            this.laySusulOrder = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem147 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem150 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem151 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem153 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem155 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem158 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem161 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem162 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem163 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem164 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem165 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem166 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem167 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem168 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem169 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem170 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem171 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem172 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem173 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem174 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem175 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem176 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem177 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem178 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem179 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem180 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem181 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem182 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem183 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem184 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem185 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem186 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem187 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem188 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem189 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem190 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem191 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem192 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem193 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem194 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem195 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem196 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem197 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem198 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem199 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem200 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem201 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem202 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem203 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem204 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem205 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem206 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem207 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem208 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem209 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem210 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem211 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem212 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem213 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem214 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem215 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem216 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem217 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem218 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem219 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem220 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem221 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem222 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem223 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem224 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem225 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem226 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem227 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem228 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem229 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem230 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem231 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem232 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem233 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem234 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem235 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem236 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem237 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem238 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem239 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem240 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem241 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem242 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem243 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem244 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem245 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem246 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem247 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem248 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem249 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem250 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem251 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem252 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem253 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem254 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem255 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem256 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem257 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem258 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem259 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem260 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem261 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem262 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem263 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem264 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem265 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem266 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem267 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem268 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem269 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem270 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem271 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem272 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem273 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem274 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem275 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem276 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem277 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem278 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem279 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem280 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem281 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem282 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem283 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem707 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem708 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem709 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem710 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem721 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem722 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1022 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1023 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1041 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1186 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1187 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1935 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1951 = new IHIS.Framework.MultiLayoutItem();
            this.layEtcOrder = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1188 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1189 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1190 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1191 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1192 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1193 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1194 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1195 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1196 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1197 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1198 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1199 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1200 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1201 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1202 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1203 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1204 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1205 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1206 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1207 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1208 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1209 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1210 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1211 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1212 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1213 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1214 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1215 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1216 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1217 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1218 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1219 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1220 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1221 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1222 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1223 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1224 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1225 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1226 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1227 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1228 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1229 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1230 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1231 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1232 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1233 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1234 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1235 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1236 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1237 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1238 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1239 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1240 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1241 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1242 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1243 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1244 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1245 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1246 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1247 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1248 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1249 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1250 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1251 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1252 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1253 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1254 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1255 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1256 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1257 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1258 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1259 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1260 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1261 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1262 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1263 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1264 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1265 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1266 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1267 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1268 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1269 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1270 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1271 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1272 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1273 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1274 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1275 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1276 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1277 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1278 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1279 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1280 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1281 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1282 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1283 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1284 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1285 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1286 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1287 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1288 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1289 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1290 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1291 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1292 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1293 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1294 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1295 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1296 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1297 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1298 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1299 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1300 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1301 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1302 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1303 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1304 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1305 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1306 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1307 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1308 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1309 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1310 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1311 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1312 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1313 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1314 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1315 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1316 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1317 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1318 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1319 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1320 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1321 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1322 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1323 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1324 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1325 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1326 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1327 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1328 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1329 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1330 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1331 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1332 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1333 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1334 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1335 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1936 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1952 = new IHIS.Framework.MultiLayoutItem();
            this.layXrtOrder = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1336 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1337 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1338 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1339 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1340 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1341 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1342 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1343 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1344 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1345 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1346 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1347 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1348 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1349 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1350 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1351 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1352 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1353 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1354 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1355 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1356 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1357 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1358 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1359 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1360 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1361 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1362 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1363 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1364 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1365 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1366 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1367 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1368 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1369 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1370 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1371 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1372 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1373 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1374 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1375 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1376 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1377 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1378 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1379 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1380 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1381 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1382 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1383 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1384 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1385 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1386 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1387 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1388 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1389 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1390 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1391 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1392 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1393 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1394 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1395 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1396 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1397 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1398 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1399 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1400 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1401 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1402 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1403 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1404 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1405 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1406 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1407 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1408 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1409 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1410 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1411 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1412 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1413 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1414 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1415 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1416 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1417 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1418 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1419 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1420 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1421 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1422 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1423 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1424 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1425 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1426 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1427 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1428 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1429 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1430 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1431 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1432 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1433 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1434 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1435 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1436 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1437 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1438 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1439 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1440 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1441 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1442 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1443 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1444 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1445 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1446 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1447 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1448 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1449 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1450 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1451 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1452 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1453 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1454 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1455 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1456 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1457 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1458 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1459 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1460 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1461 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1462 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1463 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1464 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1465 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1466 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1467 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1468 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1469 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1470 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1471 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1472 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1473 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1474 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1475 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1476 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1477 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1478 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1479 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1480 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1481 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1482 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1483 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1937 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1953 = new IHIS.Framework.MultiLayoutItem();
            this.layChuchiOrder = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1031 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1036 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1037 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1038 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1039 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1042 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1043 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1044 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1045 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1046 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1047 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1048 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1049 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1050 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1051 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1052 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1053 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1054 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1055 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1056 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1057 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1058 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1059 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1060 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1061 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1062 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1063 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1064 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1065 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1066 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1067 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1068 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1069 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1070 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1071 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1072 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1073 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1074 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1075 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1076 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1077 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1078 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1079 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1080 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1081 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1082 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1083 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1084 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1085 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1086 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1087 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1088 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1089 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1090 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1091 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1092 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1093 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1094 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1095 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1096 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1097 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1098 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1099 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1100 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1101 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1102 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1103 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1104 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1105 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1106 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1107 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1108 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1109 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1110 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1111 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1112 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1113 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1114 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1115 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1116 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1117 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1118 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1119 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1120 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1121 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1122 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1123 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1124 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1125 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1126 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1127 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1128 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1129 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1130 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1131 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1132 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1133 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1134 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1135 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1136 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1137 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1138 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1139 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1140 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1141 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1142 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1143 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1144 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1145 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1146 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1147 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1148 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1149 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1150 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1151 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1152 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1153 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1154 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1155 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1156 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1157 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1158 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1159 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1160 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1161 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1162 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1163 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1164 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1165 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1166 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1167 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1168 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1169 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1170 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1171 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1172 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1173 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1174 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1175 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1176 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1177 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1178 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1179 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1180 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1181 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1182 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1183 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1184 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1185 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1946 = new IHIS.Framework.MultiLayoutItem();
            this.layDrugOrder = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem421 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem422 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem423 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem424 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem425 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem426 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem427 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem428 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem429 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem430 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem431 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1792 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1793 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1794 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1795 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1796 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1797 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1798 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1799 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1800 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1801 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1802 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1803 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1804 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1805 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1806 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1807 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1808 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1809 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1810 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1811 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1812 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1813 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1814 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1815 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1816 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1817 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1818 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1819 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1820 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1821 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1822 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1823 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1824 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1825 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1826 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1827 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1828 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1829 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1830 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1831 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1832 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1833 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1834 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1835 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1836 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1837 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1838 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1839 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1840 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1841 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1842 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1843 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1844 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1845 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1846 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1847 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1848 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1849 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1850 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1851 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1852 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1853 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1854 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1855 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1856 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1857 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1858 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1859 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1860 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1861 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1862 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1863 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1864 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1865 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1866 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1867 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1868 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1869 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1870 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1871 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1872 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1873 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1874 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1875 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1876 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1877 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1878 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1879 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1880 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1881 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1882 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1883 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1884 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1885 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1886 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1887 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1888 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1889 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1890 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1891 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1892 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1893 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1894 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1895 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1896 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1897 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1898 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1899 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1900 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1901 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1902 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1903 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1904 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1905 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1906 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1907 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1908 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1909 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1910 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1911 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1912 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1913 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1914 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1915 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1916 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1917 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1918 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1919 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1920 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1921 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1922 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1923 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1924 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1925 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1926 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1927 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1942 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1943 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1944 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1945 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1947 = new IHIS.Framework.MultiLayoutItem();
            this.btnRemarkOnOff = new IHIS.Framework.XButton();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBunho)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlMid_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dloItemData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloInput_gubun)).BeginInit();
            this.mtxPlanMgt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dloProcessInfo)).BeginInit();
            this.pnlProcessApplyPlan.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dloProcessInfo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySiksaJunpyo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layQueryLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCplOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJusaOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPfeOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layAplOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySusulOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layEtcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layXrtOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layChuchiOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDrugOrder)).BeginInit();
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
            this.ImageList.Images.SetKeyName(9, "");
            this.ImageList.Images.SetKeyName(10, "");
            this.ImageList.Images.SetKeyName(11, "");
            this.ImageList.Images.SetKeyName(12, "");
            this.ImageList.Images.SetKeyName(13, "");
            this.ImageList.Images.SetKeyName(14, "");
            this.ImageList.Images.SetKeyName(15, "");
            this.ImageList.Images.SetKeyName(16, "");
            this.ImageList.Images.SetKeyName(17, "");
            this.ImageList.Images.SetKeyName(18, "");
            this.ImageList.Images.SetKeyName(19, "");
            this.ImageList.Images.SetKeyName(20, "");
            this.ImageList.Images.SetKeyName(21, "8.gif");
            this.ImageList.Images.SetKeyName(22, "식이관리.ico");
            this.ImageList.Images.SetKeyName(23, "24-message-info.png");
            this.ImageList.Images.SetKeyName(24, "comments.png");
            this.ImageList.Images.SetKeyName(25, "cancel.png");
            this.ImageList.Images.SetKeyName(26, "식이관리중지.bmp");
            this.ImageList.Images.SetKeyName(27, "외용약.ico");
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.Controls.Add(this.pbxBunho);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1114, 28);
            this.pnlTop.TabIndex = 11;
            // 
            // pbxBunho
            // 
            this.pbxBunho.BoxType = IHIS.Framework.PatientBoxType.NormalMiddle;
            this.pbxBunho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbxBunho.Location = new System.Drawing.Point(0, 0);
            this.pbxBunho.Name = "pbxBunho";
            this.pbxBunho.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.pbxBunho.Size = new System.Drawing.Size(1114, 28);
            this.pbxBunho.TabIndex = 6;
            this.pbxBunho.PatientSelectionFailed += new System.EventHandler(this.pbxBunho_PatientSelectionFailed);
            this.pbxBunho.PatientSelected += new System.EventHandler(this.pbxBunho_PatientSelected);
            // 
            // xPanel1
            // 
            this.xPanel1.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel1.Controls.Add(this.btnGraph);
            this.xPanel1.Controls.Add(this.btnOpenOrder);
            this.xPanel1.Controls.Add(this.btnShowProcessPlan);
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 553);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1114, 37);
            this.xPanel1.TabIndex = 12;
            // 
            // btnGraph
            // 
            this.btnGraph.Image = ((System.Drawing.Image)(resources.GetObject("btnGraph.Image")));
            this.btnGraph.Location = new System.Drawing.Point(216, 5);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnGraph.Size = new System.Drawing.Size(114, 28);
            this.btnGraph.TabIndex = 3;
            this.btnGraph.Text = "温度板照会";
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // btnOpenOrder
            // 
            this.btnOpenOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenOrder.Image")));
            this.btnOpenOrder.Location = new System.Drawing.Point(331, 5);
            this.btnOpenOrder.Name = "btnOpenOrder";
            this.btnOpenOrder.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnOpenOrder.Size = new System.Drawing.Size(88, 28);
            this.btnOpenOrder.TabIndex = 2;
            this.btnOpenOrder.Text = "オーダ";
            this.btnOpenOrder.Visible = false;
            this.btnOpenOrder.Click += new System.EventHandler(this.btnOpenOrder_Click);
            // 
            // btnShowProcessPlan
            // 
            this.btnShowProcessPlan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowProcessPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnShowProcessPlan.Image")));
            this.btnShowProcessPlan.Location = new System.Drawing.Point(6, 5);
            this.btnShowProcessPlan.Name = "btnShowProcessPlan";
            this.btnShowProcessPlan.Size = new System.Drawing.Size(210, 28);
            this.btnShowProcessPlan.TabIndex = 1;
            this.btnShowProcessPlan.Text = "看護確認/治療計画オーダ施行";
            this.btnShowProcessPlan.Click += new System.EventHandler(this.btnShowProcessPlan_Click);
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(944, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.Size = new System.Drawing.Size(163, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlMid_top
            // 
            this.pnlMid_top.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.pnlMid_top.Controls.Add(this.btnNextWeek);
            this.pnlMid_top.Controls.Add(this.btnPreWeek);
            this.pnlMid_top.Controls.Add(this.dbxConfirmUserName);
            this.pnlMid_top.Controls.Add(this.txtConfirmUser);
            this.pnlMid_top.Controls.Add(this.lblNurseId);
            this.pnlMid_top.Controls.Add(this.btnNextPeriod);
            this.pnlMid_top.Controls.Add(this.dpkTo_date);
            this.pnlMid_top.Controls.Add(this.dpkFrom_date);
            this.pnlMid_top.Controls.Add(this.btnRemarkOnOff);
            this.pnlMid_top.Controls.Add(this.btnCommentOnOff);
            this.pnlMid_top.Controls.Add(this.btnEmergencyTreatDisplayYN);
            this.pnlMid_top.Controls.Add(this.btnPrePeriod);
            this.pnlMid_top.Controls.Add(this.xFlatLabel2);
            this.pnlMid_top.Controls.Add(this.xFlatLabel1);
            this.pnlMid_top.Controls.Add(this.btnClearConfirmUser);
            this.pnlMid_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMid_top.DrawBorder = true;
            this.pnlMid_top.Location = new System.Drawing.Point(0, 28);
            this.pnlMid_top.Name = "pnlMid_top";
            this.pnlMid_top.Size = new System.Drawing.Size(1114, 34);
            this.pnlMid_top.TabIndex = 14;
            // 
            // btnNextWeek
            // 
            this.btnNextWeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextWeek.Image = ((System.Drawing.Image)(resources.GetObject("btnNextWeek.Image")));
            this.btnNextWeek.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNextWeek.Location = new System.Drawing.Point(454, 4);
            this.btnNextWeek.Name = "btnNextWeek";
            this.btnNextWeek.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnNextWeek.Size = new System.Drawing.Size(34, 24);
            this.btnNextWeek.TabIndex = 24;
            this.btnNextWeek.Click += new System.EventHandler(this.btnNextWeek_Click);
            // 
            // btnPreWeek
            // 
            this.btnPreWeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreWeek.Image = ((System.Drawing.Image)(resources.GetObject("btnPreWeek.Image")));
            this.btnPreWeek.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPreWeek.Location = new System.Drawing.Point(3, 4);
            this.btnPreWeek.Name = "btnPreWeek";
            this.btnPreWeek.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnPreWeek.Size = new System.Drawing.Size(34, 24);
            this.btnPreWeek.TabIndex = 23;
            this.btnPreWeek.Click += new System.EventHandler(this.btnPreWeek_Click);
            // 
            // dbxConfirmUserName
            // 
            this.dbxConfirmUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dbxConfirmUserName.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbxConfirmUserName.Location = new System.Drawing.Point(923, 6);
            this.dbxConfirmUserName.Name = "dbxConfirmUserName";
            this.dbxConfirmUserName.Size = new System.Drawing.Size(120, 23);
            this.dbxConfirmUserName.TabIndex = 22;
            // 
            // txtConfirmUser
            // 
            this.txtConfirmUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConfirmUser.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmUser.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtConfirmUser.Location = new System.Drawing.Point(809, 6);
            this.txtConfirmUser.Name = "txtConfirmUser";
            this.txtConfirmUser.Size = new System.Drawing.Size(112, 23);
            this.txtConfirmUser.TabIndex = 21;
            this.txtConfirmUser.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtConfirmUser_DataValidating);
            // 
            // lblNurseId
            // 
            this.lblNurseId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNurseId.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblNurseId.EdgeRounding = false;
            this.lblNurseId.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblNurseId.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblNurseId.Location = new System.Drawing.Point(683, 6);
            this.lblNurseId.Name = "lblNurseId";
            this.lblNurseId.Size = new System.Drawing.Size(124, 22);
            this.lblNurseId.TabIndex = 20;
            this.lblNurseId.Text = "看護確認 ID";
            this.lblNurseId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNextPeriod
            // 
            this.btnNextPeriod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextPeriod.Image = ((System.Drawing.Image)(resources.GetObject("btnNextPeriod.Image")));
            this.btnNextPeriod.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNextPeriod.Location = new System.Drawing.Point(419, 4);
            this.btnNextPeriod.Name = "btnNextPeriod";
            this.btnNextPeriod.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnNextPeriod.Size = new System.Drawing.Size(34, 24);
            this.btnNextPeriod.TabIndex = 7;
            this.btnNextPeriod.Click += new System.EventHandler(this.btnNextPeriod_Click);
            // 
            // dpkTo_date
            // 
            this.dpkTo_date.Enabled = false;
            this.dpkTo_date.IsJapanYearType = true;
            this.dpkTo_date.Location = new System.Drawing.Point(304, 6);
            this.dpkTo_date.Name = "dpkTo_date";
            this.dpkTo_date.Protect = true;
            this.dpkTo_date.ReadOnly = true;
            this.dpkTo_date.Size = new System.Drawing.Size(112, 20);
            this.dpkTo_date.TabIndex = 6;
            this.dpkTo_date.TabStop = false;
            // 
            // dpkFrom_date
            // 
            this.dpkFrom_date.IsJapanYearType = true;
            this.dpkFrom_date.Location = new System.Drawing.Point(164, 6);
            this.dpkFrom_date.Name = "dpkFrom_date";
            this.dpkFrom_date.Size = new System.Drawing.Size(112, 20);
            this.dpkFrom_date.TabIndex = 5;
            this.dpkFrom_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkFrom_date_DataValidating);
            // 
            // btnCommentOnOff
            // 
            this.btnCommentOnOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCommentOnOff.ImageIndex = 4;
            this.btnCommentOnOff.ImageList = this.ImageList;
            this.btnCommentOnOff.Location = new System.Drawing.Point(686, 4);
            this.btnCommentOnOff.Name = "btnCommentOnOff";
            this.btnCommentOnOff.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnCommentOnOff.Size = new System.Drawing.Size(87, 24);
            this.btnCommentOnOff.TabIndex = 4;
            this.btnCommentOnOff.Text = "項目詳細";
            this.btnCommentOnOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCommentOnOff.Click += new System.EventHandler(this.btnCommentOnOff_Click);
            // 
            // btnEmergencyTreatDisplayYN
            // 
            this.btnEmergencyTreatDisplayYN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmergencyTreatDisplayYN.ImageIndex = 3;
            this.btnEmergencyTreatDisplayYN.ImageList = this.ImageList;
            this.btnEmergencyTreatDisplayYN.Location = new System.Drawing.Point(492, 4);
            this.btnEmergencyTreatDisplayYN.Name = "btnEmergencyTreatDisplayYN";
            this.btnEmergencyTreatDisplayYN.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnEmergencyTreatDisplayYN.Size = new System.Drawing.Size(93, 24);
            this.btnEmergencyTreatDisplayYN.TabIndex = 4;
            this.btnEmergencyTreatDisplayYN.Text = "緊急時処置";
            this.btnEmergencyTreatDisplayYN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEmergencyTreatDisplayYN.Click += new System.EventHandler(this.btnEmergencyTreatDisplayYN_Click);
            // 
            // btnPrePeriod
            // 
            this.btnPrePeriod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrePeriod.Image = ((System.Drawing.Image)(resources.GetObject("btnPrePeriod.Image")));
            this.btnPrePeriod.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrePeriod.Location = new System.Drawing.Point(38, 4);
            this.btnPrePeriod.Name = "btnPrePeriod";
            this.btnPrePeriod.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnPrePeriod.Size = new System.Drawing.Size(34, 24);
            this.btnPrePeriod.TabIndex = 4;
            this.btnPrePeriod.Click += new System.EventHandler(this.btnPrePeriod_Click);
            // 
            // xFlatLabel2
            // 
            this.xFlatLabel2.Image = ((System.Drawing.Image)(resources.GetObject("xFlatLabel2.Image")));
            this.xFlatLabel2.Location = new System.Drawing.Point(286, 6);
            this.xFlatLabel2.Name = "xFlatLabel2";
            this.xFlatLabel2.Size = new System.Drawing.Size(11, 20);
            this.xFlatLabel2.TabIndex = 3;
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.Image = ((System.Drawing.Image)(resources.GetObject("xFlatLabel1.Image")));
            this.xFlatLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xFlatLabel1.Location = new System.Drawing.Point(78, 6);
            this.xFlatLabel1.Name = "xFlatLabel1";
            this.xFlatLabel1.Size = new System.Drawing.Size(88, 20);
            this.xFlatLabel1.TabIndex = 2;
            this.xFlatLabel1.Text = "     照会期間";
            // 
            // btnClearConfirmUser
            // 
            this.btnClearConfirmUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearConfirmUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearConfirmUser.Image = ((System.Drawing.Image)(resources.GetObject("btnClearConfirmUser.Image")));
            this.btnClearConfirmUser.Location = new System.Drawing.Point(1045, 5);
            this.btnClearConfirmUser.Name = "btnClearConfirmUser";
            this.btnClearConfirmUser.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnClearConfirmUser.Size = new System.Drawing.Size(62, 25);
            this.btnClearConfirmUser.TabIndex = 19;
            this.btnClearConfirmUser.Text = "クリア";
            this.btnClearConfirmUser.Click += new System.EventHandler(this.btnClearConfirmUser_Click);
            // 
            // dtpApp_To_date
            // 
            this.dtpApp_To_date.Location = new System.Drawing.Point(235, 9);
            this.dtpApp_To_date.Name = "dtpApp_To_date";
            this.dtpApp_To_date.Size = new System.Drawing.Size(102, 20);
            this.dtpApp_To_date.TabIndex = 2;
            // 
            // dloItemData
            // 
            this.dloItemData.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem124,
            this.multiLayoutItem125,
            this.multiLayoutItem126,
            this.multiLayoutItem127,
            this.multiLayoutItem128,
            this.multiLayoutItem129,
            this.multiLayoutItem130,
            this.multiLayoutItem131,
            this.multiLayoutItem132,
            this.multiLayoutItem133,
            this.multiLayoutItem134,
            this.multiLayoutItem135,
            this.multiLayoutItem136,
            this.multiLayoutItem137,
            this.multiLayoutItem138,
            this.multiLayoutItem139,
            this.multiLayoutItem140,
            this.multiLayoutItem141,
            this.multiLayoutItem142,
            this.multiLayoutItem143,
            this.multiLayoutItem144,
            this.multiLayoutItem145,
            this.multiLayoutItem146,
            this.multiLayoutItem284,
            this.multiLayoutItem285,
            this.multiLayoutItem286,
            this.multiLayoutItem287,
            this.multiLayoutItem288,
            this.multiLayoutItem289,
            this.multiLayoutItem290,
            this.multiLayoutItem291,
            this.multiLayoutItem292,
            this.multiLayoutItem293,
            this.multiLayoutItem294,
            this.multiLayoutItem295,
            this.multiLayoutItem296,
            this.multiLayoutItem297,
            this.multiLayoutItem298,
            this.multiLayoutItem299,
            this.multiLayoutItem300,
            this.multiLayoutItem301,
            this.multiLayoutItem302,
            this.multiLayoutItem303,
            this.multiLayoutItem304,
            this.multiLayoutItem305,
            this.multiLayoutItem306,
            this.multiLayoutItem307,
            this.multiLayoutItem308,
            this.multiLayoutItem309,
            this.multiLayoutItem312,
            this.multiLayoutItem313,
            this.multiLayoutItem314,
            this.multiLayoutItem315,
            this.multiLayoutItem316,
            this.multiLayoutItem321,
            this.multiLayoutItem322,
            this.multiLayoutItem325});
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "bunho";
            this.multiLayoutItem40.IsUpdItem = true;
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "fkinp1001";
            this.multiLayoutItem41.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem41.IsUpdItem = true;
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "fkocs6010";
            this.multiLayoutItem42.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem42.IsUpdItem = true;
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "cp_name";
            this.multiLayoutItem43.IsUpdItem = true;
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "order_date";
            this.multiLayoutItem44.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem44.IsUpdItem = true;
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "order_end_date";
            this.multiLayoutItem45.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem45.IsUpdItem = true;
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "input_gubun";
            this.multiLayoutItem46.IsUpdItem = true;
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "input_gubun_name";
            this.multiLayoutItem47.IsUpdItem = true;
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "order_gubun";
            this.multiLayoutItem48.IsUpdItem = true;
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "order_gubun_ori";
            this.multiLayoutItem49.IsUpdItem = true;
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "order_gubun_name";
            this.multiLayoutItem50.IsUpdItem = true;
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "hangmog_code";
            this.multiLayoutItem51.IsUpdItem = true;
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "hangmog_name";
            this.multiLayoutItem52.IsUpdItem = true;
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "suryang";
            this.multiLayoutItem53.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem124
            // 
            this.multiLayoutItem124.DataName = "nalsu";
            this.multiLayoutItem124.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem125
            // 
            this.multiLayoutItem125.DataName = "detail";
            this.multiLayoutItem125.IsUpdItem = true;
            // 
            // multiLayoutItem126
            // 
            this.multiLayoutItem126.DataName = "order_remark";
            this.multiLayoutItem126.IsUpdItem = true;
            // 
            // multiLayoutItem127
            // 
            this.multiLayoutItem127.DataName = "nurse_remark";
            this.multiLayoutItem127.IsUpdItem = true;
            // 
            // multiLayoutItem128
            // 
            this.multiLayoutItem128.DataName = "tel_yn";
            // 
            // multiLayoutItem129
            // 
            this.multiLayoutItem129.DataName = "emergency";
            this.multiLayoutItem129.IsUpdItem = true;
            // 
            // multiLayoutItem130
            // 
            this.multiLayoutItem130.DataName = "jusa_name";
            // 
            // multiLayoutItem131
            // 
            this.multiLayoutItem131.DataName = "bogyong_name";
            // 
            // multiLayoutItem132
            // 
            this.multiLayoutItem132.DataName = "jaewonil";
            this.multiLayoutItem132.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem132.IsUpdItem = true;
            // 
            // multiLayoutItem133
            // 
            this.multiLayoutItem133.DataName = "pk";
            this.multiLayoutItem133.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem133.IsUpdItem = true;
            // 
            // multiLayoutItem134
            // 
            this.multiLayoutItem134.DataName = "group_ser";
            this.multiLayoutItem134.IsUpdItem = true;
            // 
            // multiLayoutItem135
            // 
            this.multiLayoutItem135.DataName = "mix_group";
            this.multiLayoutItem135.IsUpdItem = true;
            // 
            // multiLayoutItem136
            // 
            this.multiLayoutItem136.DataName = "table_id";
            this.multiLayoutItem136.IsUpdItem = true;
            // 
            // multiLayoutItem137
            // 
            this.multiLayoutItem137.DataName = "confirm_yn";
            this.multiLayoutItem137.IsUpdItem = true;
            // 
            // multiLayoutItem138
            // 
            this.multiLayoutItem138.DataName = "acting_yn";
            this.multiLayoutItem138.IsUpdItem = true;
            // 
            // multiLayoutItem139
            // 
            this.multiLayoutItem139.DataName = "can_plan_change_yn";
            this.multiLayoutItem139.IsUpdItem = true;
            // 
            // multiLayoutItem140
            // 
            this.multiLayoutItem140.DataName = "can_confirm_yn";
            this.multiLayoutItem140.IsUpdItem = true;
            // 
            // multiLayoutItem141
            // 
            this.multiLayoutItem141.DataName = "can_acting_yn";
            this.multiLayoutItem141.IsUpdItem = true;
            // 
            // multiLayoutItem142
            // 
            this.multiLayoutItem142.DataName = "can_plan_app_yn";
            this.multiLayoutItem142.IsUpdItem = true;
            // 
            // multiLayoutItem143
            // 
            this.multiLayoutItem143.DataName = "input_name";
            this.multiLayoutItem143.IsUpdItem = true;
            // 
            // multiLayoutItem144
            // 
            this.multiLayoutItem144.DataName = "input_seq";
            this.multiLayoutItem144.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem144.IsUpdItem = true;
            // 
            // multiLayoutItem145
            // 
            this.multiLayoutItem145.DataName = "order_end_yn";
            this.multiLayoutItem145.IsUpdItem = true;
            // 
            // multiLayoutItem146
            // 
            this.multiLayoutItem146.DataName = "confirm_name";
            this.multiLayoutItem146.IsUpdItem = true;
            // 
            // multiLayoutItem284
            // 
            this.multiLayoutItem284.DataName = "detail_act_yn";
            this.multiLayoutItem284.IsUpdItem = true;
            // 
            // multiLayoutItem285
            // 
            this.multiLayoutItem285.DataName = "bulyong_check";
            this.multiLayoutItem285.IsUpdItem = true;
            // 
            // multiLayoutItem286
            // 
            this.multiLayoutItem286.DataName = "hold_user";
            // 
            // multiLayoutItem287
            // 
            this.multiLayoutItem287.DataName = "input_gwa";
            // 
            // multiLayoutItem288
            // 
            this.multiLayoutItem288.DataName = "input_doctor";
            // 
            // multiLayoutItem289
            // 
            this.multiLayoutItem289.DataName = "reser_date";
            // 
            // multiLayoutItem290
            // 
            this.multiLayoutItem290.DataName = "acting_date";
            this.multiLayoutItem290.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem291
            // 
            this.multiLayoutItem291.DataName = "jundal_table";
            // 
            // multiLayoutItem292
            // 
            this.multiLayoutItem292.DataName = "jundal_part";
            // 
            // multiLayoutItem293
            // 
            this.multiLayoutItem293.DataName = "ocs_flag";
            // 
            // multiLayoutItem294
            // 
            this.multiLayoutItem294.DataName = "source_order_date";
            this.multiLayoutItem294.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem295
            // 
            this.multiLayoutItem295.DataName = "continue_yn";
            // 
            // multiLayoutItem296
            // 
            this.multiLayoutItem296.DataName = "jisi_order_gubun";
            // 
            // multiLayoutItem297
            // 
            this.multiLayoutItem297.DataName = "origin_order_date";
            this.multiLayoutItem297.IsUpdItem = true;
            // 
            // multiLayoutItem298
            // 
            this.multiLayoutItem298.DataName = "origin_input_gubun";
            this.multiLayoutItem298.IsUpdItem = true;
            // 
            // multiLayoutItem299
            // 
            this.multiLayoutItem299.DataName = "del_flag";
            this.multiLayoutItem299.IsUpdItem = true;
            // 
            // multiLayoutItem300
            // 
            this.multiLayoutItem300.DataName = "pickup_user";
            this.multiLayoutItem300.IsUpdItem = true;
            // 
            // multiLayoutItem301
            // 
            this.multiLayoutItem301.DataName = "rowindex";
            this.multiLayoutItem301.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem302
            // 
            this.multiLayoutItem302.DataName = "notlayout";
            // 
            // multiLayoutItem303
            // 
            this.multiLayoutItem303.DataName = "direct_cont";
            // 
            // multiLayoutItem304
            // 
            this.multiLayoutItem304.DataName = "pkocs2005";
            // 
            // multiLayoutItem305
            // 
            this.multiLayoutItem305.DataName = "pkocs6015";
            // 
            // multiLayoutItem306
            // 
            this.multiLayoutItem306.DataName = "input_id";
            // 
            // multiLayoutItem307
            // 
            this.multiLayoutItem307.DataName = "direct_code";
            // 
            // multiLayoutItem308
            // 
            this.multiLayoutItem308.DataName = "dv";
            // 
            // multiLayoutItem309
            // 
            this.multiLayoutItem309.DataName = "check_acting";
            // 
            // multiLayoutItem312
            // 
            this.multiLayoutItem312.DataName = "diff";
            // 
            // multiLayoutItem313
            // 
            this.multiLayoutItem313.DataName = "nurse_act_user";
            this.multiLayoutItem313.IsUpdItem = true;
            // 
            // multiLayoutItem314
            // 
            this.multiLayoutItem314.DataName = "nurse_act_date";
            this.multiLayoutItem314.IsUpdItem = true;
            // 
            // multiLayoutItem315
            // 
            this.multiLayoutItem315.DataName = "nurse_act_time";
            this.multiLayoutItem315.IsUpdItem = true;
            // 
            // multiLayoutItem316
            // 
            this.multiLayoutItem316.DataName = "medi_act_chk";
            // 
            // multiLayoutItem321
            // 
            this.multiLayoutItem321.DataName = "drt_from_datetime";
            // 
            // multiLayoutItem322
            // 
            this.multiLayoutItem322.DataName = "drt_to_datetime";
            // 
            // multiLayoutItem325
            // 
            this.multiLayoutItem325.DataName = "jisi_gubun";
            // 
            // dloInput_gubun
            // 
            this.dloInput_gubun.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem62,
            this.multiLayoutItem63});
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "order_date";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "input_gubun";
            // 
            // mtxPlanMgt
            // 
            this.mtxPlanMgt.AllowDrop = true;
            this.mtxPlanMgt.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.mtxPlanMgt.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.mtxPlanMgt.Controls.Add(this.pnlPosition);
            this.mtxPlanMgt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtxPlanMgt.ImageList = this.ImageList;
            this.mtxPlanMgt.Location = new System.Drawing.Point(0, 92);
            this.mtxPlanMgt.Name = "mtxPlanMgt";
            this.mtxPlanMgt.Size = new System.Drawing.Size(1114, 361);
            this.mtxPlanMgt.TabIndex = 15;
            this.mtxPlanMgt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mtxPlanMgt_MouseMove);
            this.mtxPlanMgt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mtxPlanMgt_MouseDown);
            this.mtxPlanMgt.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.mtxPlanMgt_GiveFeedback);
            this.mtxPlanMgt.DragEnter += new System.Windows.Forms.DragEventHandler(this.mtxPlanMgt_DragEnter);
            this.mtxPlanMgt.ItemDragDrop += new IHIS.Framework.XMatrixItemDragDropEventHandler(this.mtxPlanMgt_ItemDragDrop);
            // 
            // pnlPosition
            // 
            this.pnlPosition.Location = new System.Drawing.Point(0, 0);
            this.pnlPosition.Name = "pnlPosition";
            this.pnlPosition.Size = new System.Drawing.Size(70, 52);
            this.pnlPosition.TabIndex = 1;
            // 
            // dloProcessInfo
            // 
            this.dloProcessInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem56,
            this.multiLayoutItem57,
            this.multiLayoutItem58,
            this.multiLayoutItem59,
            this.multiLayoutItem60,
            this.multiLayoutItem61});
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "bunho";
            this.multiLayoutItem56.IsNotNull = true;
            this.multiLayoutItem56.IsUpdItem = true;
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "fkinp1001";
            this.multiLayoutItem57.IsNotNull = true;
            this.multiLayoutItem57.IsUpdItem = true;
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "from_date";
            this.multiLayoutItem58.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem58.IsNotNull = true;
            this.multiLayoutItem58.IsUpdItem = true;
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "to_date";
            this.multiLayoutItem59.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem59.IsNotNull = true;
            this.multiLayoutItem59.IsUpdItem = true;
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "pkocs6013";
            this.multiLayoutItem60.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem60.IsNotNull = true;
            this.multiLayoutItem60.IsUpdItem = true;
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "user_id";
            this.multiLayoutItem61.IsNotNull = true;
            this.multiLayoutItem61.IsUpdItem = true;
            // 
            // pnlProcessApplyPlan
            // 
            this.pnlProcessApplyPlan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlProcessApplyPlan.BackgroundImage")));
            this.pnlProcessApplyPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProcessApplyPlan.Controls.Add(this.rbtSiksa);
            this.pnlProcessApplyPlan.Controls.Add(this.rbtJusa);
            this.pnlProcessApplyPlan.Controls.Add(this.rbtPJ);
            this.pnlProcessApplyPlan.Controls.Add(this.rbtAll);
            this.pnlProcessApplyPlan.Controls.Add(this.xPanel3);
            this.pnlProcessApplyPlan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProcessApplyPlan.Location = new System.Drawing.Point(0, 453);
            this.pnlProcessApplyPlan.Name = "pnlProcessApplyPlan";
            this.pnlProcessApplyPlan.Size = new System.Drawing.Size(1114, 100);
            this.pnlProcessApplyPlan.TabIndex = 1;
            this.pnlProcessApplyPlan.VisibleChanged += new System.EventHandler(this.pnlProcessApplyPlan_VisibleChanged);
            // 
            // rbtSiksa
            // 
            this.rbtSiksa.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtSiksa.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtSiksa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtSiksa.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtSiksa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtSiksa.ImageIndex = 3;
            this.rbtSiksa.ImageList = this.ImageList;
            this.rbtSiksa.Location = new System.Drawing.Point(368, 6);
            this.rbtSiksa.Name = "rbtSiksa";
            this.rbtSiksa.Size = new System.Drawing.Size(120, 26);
            this.rbtSiksa.TabIndex = 23;
            this.rbtSiksa.Text = "      食事";
            this.rbtSiksa.UseVisualStyleBackColor = false;
            this.rbtSiksa.Visible = false;
            this.rbtSiksa.Click += new System.EventHandler(this.rbtAll_Click);
            // 
            // rbtJusa
            // 
            this.rbtJusa.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtJusa.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtJusa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtJusa.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtJusa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtJusa.ImageIndex = 3;
            this.rbtJusa.ImageList = this.ImageList;
            this.rbtJusa.Location = new System.Drawing.Point(128, 6);
            this.rbtJusa.Name = "rbtJusa";
            this.rbtJusa.Size = new System.Drawing.Size(120, 26);
            this.rbtJusa.TabIndex = 22;
            this.rbtJusa.Text = "      注    射";
            this.rbtJusa.UseVisualStyleBackColor = false;
            this.rbtJusa.Click += new System.EventHandler(this.rbtAll_Click);
            // 
            // rbtPJ
            // 
            this.rbtPJ.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtPJ.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtPJ.Checked = true;
            this.rbtPJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtPJ.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtPJ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtPJ.ImageIndex = 4;
            this.rbtPJ.ImageList = this.ImageList;
            this.rbtPJ.Location = new System.Drawing.Point(0, 6);
            this.rbtPJ.Name = "rbtPJ";
            this.rbtPJ.Size = new System.Drawing.Size(128, 26);
            this.rbtPJ.TabIndex = 21;
            this.rbtPJ.TabStop = true;
            this.rbtPJ.Text = "      内服薬/外用薬";
            this.rbtPJ.UseVisualStyleBackColor = false;
            this.rbtPJ.Click += new System.EventHandler(this.rbtAll_Click);
            // 
            // rbtAll
            // 
            this.rbtAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtAll.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtAll.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtAll.ImageIndex = 3;
            this.rbtAll.ImageList = this.ImageList;
            this.rbtAll.Location = new System.Drawing.Point(248, 6);
            this.rbtAll.Name = "rbtAll";
            this.rbtAll.Size = new System.Drawing.Size(120, 26);
            this.rbtAll.TabIndex = 20;
            this.rbtAll.Text = "      オーダ全体";
            this.rbtAll.UseVisualStyleBackColor = false;
            this.rbtAll.Click += new System.EventHandler(this.rbtAll_Click);
            // 
            // xPanel3
            // 
            this.xPanel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.xPanel3.Controls.Add(this.dwSiksaJunpyo);
            this.xPanel3.Controls.Add(this.btnProcessPlanClose);
            this.xPanel3.Controls.Add(this.dApp_From_date);
            this.xPanel3.Controls.Add(this.label1);
            this.xPanel3.Controls.Add(this.dtpApp_To_date);
            this.xPanel3.Controls.Add(this.label2);
            this.xPanel3.Controls.Add(this.btnProcessPlan);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(0, 30);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(1112, 68);
            this.xPanel3.TabIndex = 19;
            // 
            // dwSiksaJunpyo
            // 
            this.dwSiksaJunpyo.DataWindowObject = "ocs6010u20";
            this.dwSiksaJunpyo.LibraryList = "..\\OCSI\\ocsi.ocs6010u10.pbd";
            this.dwSiksaJunpyo.Location = new System.Drawing.Point(921, 3);
            this.dwSiksaJunpyo.Name = "dwSiksaJunpyo";
            this.dwSiksaJunpyo.Size = new System.Drawing.Size(30, 30);
            this.dwSiksaJunpyo.TabIndex = 19;
            this.dwSiksaJunpyo.Text = "dwSiksaJunpyo";
            this.dwSiksaJunpyo.Visible = false;
            // 
            // btnProcessPlanClose
            // 
            this.btnProcessPlanClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcessPlanClose.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessPlanClose.Image")));
            this.btnProcessPlanClose.Location = new System.Drawing.Point(328, 34);
            this.btnProcessPlanClose.Name = "btnProcessPlanClose";
            this.btnProcessPlanClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnProcessPlanClose.Size = new System.Drawing.Size(88, 28);
            this.btnProcessPlanClose.TabIndex = 18;
            this.btnProcessPlanClose.Text = "閉じる";
            this.btnProcessPlanClose.Click += new System.EventHandler(this.btnProcessPlanClose_Click);
            // 
            // dApp_From_date
            // 
            this.dApp_From_date.Location = new System.Drawing.Point(107, 9);
            this.dApp_From_date.Name = "dApp_From_date";
            this.dApp_From_date.Size = new System.Drawing.Size(102, 20);
            this.dApp_From_date.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(211, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(19, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "     適用日付";
            // 
            // btnProcessPlan
            // 
            this.btnProcessPlan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcessPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessPlan.Image")));
            this.btnProcessPlan.Location = new System.Drawing.Point(240, 34);
            this.btnProcessPlan.Name = "btnProcessPlan";
            this.btnProcessPlan.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnProcessPlan.Size = new System.Drawing.Size(88, 28);
            this.btnProcessPlan.TabIndex = 0;
            this.btnProcessPlan.Text = "施行";
            this.btnProcessPlan.Click += new System.EventHandler(this.btnProcessPlan_Click);
            // 
            // dloProcessInfo1
            // 
            this.dloProcessInfo1.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem54,
            this.multiLayoutItem55,
            this.multiLayoutItem64,
            this.multiLayoutItem65,
            this.multiLayoutItem66,
            this.multiLayoutItem67,
            this.multiLayoutItem68,
            this.multiLayoutItem69});
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "bunho";
            this.multiLayoutItem54.IsNotNull = true;
            this.multiLayoutItem54.IsUpdItem = true;
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "fkinp1001";
            this.multiLayoutItem55.IsNotNull = true;
            this.multiLayoutItem55.IsUpdItem = true;
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "fkocs6010";
            this.multiLayoutItem64.IsNotNull = true;
            this.multiLayoutItem64.IsUpdItem = true;
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "plan_date";
            this.multiLayoutItem65.IsNotNull = true;
            this.multiLayoutItem65.IsUpdItem = true;
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "input_gubun";
            this.multiLayoutItem66.IsNotNull = true;
            this.multiLayoutItem66.IsUpdItem = true;
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "order_gubun";
            this.multiLayoutItem67.IsNotNull = true;
            this.multiLayoutItem67.IsUpdItem = true;
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "group_ser";
            this.multiLayoutItem68.IsNotNull = true;
            this.multiLayoutItem68.IsUpdItem = true;
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "user_id";
            this.multiLayoutItem69.IsNotNull = true;
            this.multiLayoutItem69.IsUpdItem = true;
            // 
            // tabQuery
            // 
            this.tabQuery.Appearance = IHIS.X.Magic.Common.VisualAppearance.MultiBox;
            this.tabQuery.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.AliceBlue);
            this.tabQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabQuery.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabQuery.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabQuery.IDEPixelArea = true;
            this.tabQuery.ImageList = this.ImageList;
            this.tabQuery.Location = new System.Drawing.Point(0, 62);
            this.tabQuery.Name = "tabQuery";
            this.tabQuery.Size = new System.Drawing.Size(1114, 30);
            this.tabQuery.TabIndex = 16;
            // 
            // laySiksaJunpyo
            // 
            this.laySiksaJunpyo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
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
            this.multiLayoutItem22});
            this.laySiksaJunpyo.QuerySQL = resources.GetString("laySiksaJunpyo.QuerySQL");
            this.laySiksaJunpyo.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.laySiksaJunpyo_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "fkinp1001";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "suname";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "suname2";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "birth";
            this.multiLayoutItem5.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "age";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "sex";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "height";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "weight";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "gwa";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "gwa_name";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "doctor";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "ho_dong";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "ho_dong_name";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "ho_code";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "sik_gubun";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "siksagubun";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "drt_from_date";
            this.multiLayoutItem18.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "drt_to_date";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "order_date";
            this.multiLayoutItem20.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "sang_name";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "direct_code";
            // 
            // layQueryLayout
            // 
            this.layQueryLayout.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1484,
            this.multiLayoutItem1485,
            this.multiLayoutItem1486,
            this.multiLayoutItem1487,
            this.multiLayoutItem1488,
            this.multiLayoutItem1489,
            this.multiLayoutItem1490,
            this.multiLayoutItem1491,
            this.multiLayoutItem1492,
            this.multiLayoutItem1493,
            this.multiLayoutItem1494,
            this.multiLayoutItem1495,
            this.multiLayoutItem1496,
            this.multiLayoutItem1497,
            this.multiLayoutItem1498,
            this.multiLayoutItem1499,
            this.multiLayoutItem1517,
            this.multiLayoutItem1518,
            this.multiLayoutItem1519,
            this.multiLayoutItem1520,
            this.multiLayoutItem1521,
            this.multiLayoutItem1522,
            this.multiLayoutItem1523,
            this.multiLayoutItem1524,
            this.multiLayoutItem1525,
            this.multiLayoutItem1526,
            this.multiLayoutItem1527,
            this.multiLayoutItem1528,
            this.multiLayoutItem1529,
            this.multiLayoutItem1530,
            this.multiLayoutItem1531,
            this.multiLayoutItem1532,
            this.multiLayoutItem1533,
            this.multiLayoutItem1534,
            this.multiLayoutItem1535,
            this.multiLayoutItem1536,
            this.multiLayoutItem1537,
            this.multiLayoutItem1538,
            this.multiLayoutItem1539,
            this.multiLayoutItem1540,
            this.multiLayoutItem1541,
            this.multiLayoutItem1542,
            this.multiLayoutItem1543,
            this.multiLayoutItem1544,
            this.multiLayoutItem1545,
            this.multiLayoutItem1546,
            this.multiLayoutItem1547,
            this.multiLayoutItem1548,
            this.multiLayoutItem1549,
            this.multiLayoutItem1550,
            this.multiLayoutItem1551,
            this.multiLayoutItem1552,
            this.multiLayoutItem1553,
            this.multiLayoutItem1554,
            this.multiLayoutItem1555,
            this.multiLayoutItem1556,
            this.multiLayoutItem1557,
            this.multiLayoutItem1558,
            this.multiLayoutItem1559,
            this.multiLayoutItem1560,
            this.multiLayoutItem1561,
            this.multiLayoutItem1562,
            this.multiLayoutItem1563,
            this.multiLayoutItem1564,
            this.multiLayoutItem1565,
            this.multiLayoutItem1566,
            this.multiLayoutItem1567,
            this.multiLayoutItem1568,
            this.multiLayoutItem1569,
            this.multiLayoutItem1570,
            this.multiLayoutItem1571,
            this.multiLayoutItem1572,
            this.multiLayoutItem1573,
            this.multiLayoutItem1574,
            this.multiLayoutItem1575,
            this.multiLayoutItem1576,
            this.multiLayoutItem1577,
            this.multiLayoutItem1578,
            this.multiLayoutItem1579,
            this.multiLayoutItem1580,
            this.multiLayoutItem1581,
            this.multiLayoutItem1582,
            this.multiLayoutItem1583,
            this.multiLayoutItem1584,
            this.multiLayoutItem1585,
            this.multiLayoutItem1586,
            this.multiLayoutItem1587,
            this.multiLayoutItem1588,
            this.multiLayoutItem1589,
            this.multiLayoutItem1590,
            this.multiLayoutItem1591,
            this.multiLayoutItem1592,
            this.multiLayoutItem1593,
            this.multiLayoutItem1594,
            this.multiLayoutItem1595,
            this.multiLayoutItem1596,
            this.multiLayoutItem1597,
            this.multiLayoutItem1598,
            this.multiLayoutItem1599,
            this.multiLayoutItem1600,
            this.multiLayoutItem1601,
            this.multiLayoutItem1602,
            this.multiLayoutItem1603,
            this.multiLayoutItem1604,
            this.multiLayoutItem1605,
            this.multiLayoutItem1606,
            this.multiLayoutItem1607,
            this.multiLayoutItem1608,
            this.multiLayoutItem1609,
            this.multiLayoutItem1610,
            this.multiLayoutItem1611,
            this.multiLayoutItem1612,
            this.multiLayoutItem1613,
            this.multiLayoutItem1614,
            this.multiLayoutItem1615,
            this.multiLayoutItem1616,
            this.multiLayoutItem1617,
            this.multiLayoutItem1618,
            this.multiLayoutItem1619,
            this.multiLayoutItem1620,
            this.multiLayoutItem1621,
            this.multiLayoutItem1622,
            this.multiLayoutItem1623,
            this.multiLayoutItem1624,
            this.multiLayoutItem1625,
            this.multiLayoutItem1626,
            this.multiLayoutItem1627,
            this.multiLayoutItem1628,
            this.multiLayoutItem1629,
            this.multiLayoutItem1630,
            this.multiLayoutItem1631,
            this.multiLayoutItem1632,
            this.multiLayoutItem1633,
            this.multiLayoutItem1634,
            this.multiLayoutItem1635,
            this.multiLayoutItem1636,
            this.multiLayoutItem1637,
            this.multiLayoutItem1638,
            this.multiLayoutItem1639,
            this.multiLayoutItem1640,
            this.multiLayoutItem1641,
            this.multiLayoutItem1642,
            this.multiLayoutItem1643,
            this.multiLayoutItem1644,
            this.multiLayoutItem1645,
            this.multiLayoutItem1660,
            this.multiLayoutItem1938,
            this.multiLayoutItem1954,
            this.multiLayoutItem1955,
            this.multiLayoutItem1956,
            this.multiLayoutItem1957,
            this.multiLayoutItem1958,
            this.multiLayoutItem1959,
            this.multiLayoutItem1960,
            this.multiLayoutItem1961,
            this.multiLayoutItem1962});
            this.layQueryLayout.QuerySQL = resources.GetString("layQueryLayout.QuerySQL");
            // 
            // multiLayoutItem1484
            // 
            this.multiLayoutItem1484.DataName = "in_out_key";
            this.multiLayoutItem1484.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem1484.IsUpdItem = true;
            // 
            // multiLayoutItem1485
            // 
            this.multiLayoutItem1485.DataName = "pkocskey";
            this.multiLayoutItem1485.IsUpdItem = true;
            // 
            // multiLayoutItem1486
            // 
            this.multiLayoutItem1486.DataName = "bunho";
            this.multiLayoutItem1486.IsUpdItem = true;
            // 
            // multiLayoutItem1487
            // 
            this.multiLayoutItem1487.DataName = "order_date";
            this.multiLayoutItem1487.IsUpdItem = true;
            // 
            // multiLayoutItem1488
            // 
            this.multiLayoutItem1488.DataName = "gwa";
            this.multiLayoutItem1488.IsUpdItem = true;
            // 
            // multiLayoutItem1489
            // 
            this.multiLayoutItem1489.DataName = "doctor";
            this.multiLayoutItem1489.IsUpdItem = true;
            // 
            // multiLayoutItem1490
            // 
            this.multiLayoutItem1490.DataName = "resident";
            this.multiLayoutItem1490.IsUpdItem = true;
            // 
            // multiLayoutItem1491
            // 
            this.multiLayoutItem1491.DataName = "naewon_type";
            this.multiLayoutItem1491.IsUpdItem = true;
            // 
            // multiLayoutItem1492
            // 
            this.multiLayoutItem1492.DataName = "jubsu_no";
            this.multiLayoutItem1492.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem1492.IsUpdItem = true;
            // 
            // multiLayoutItem1493
            // 
            this.multiLayoutItem1493.DataName = "input_id";
            this.multiLayoutItem1493.IsUpdItem = true;
            // 
            // multiLayoutItem1494
            // 
            this.multiLayoutItem1494.DataName = "input_part";
            this.multiLayoutItem1494.IsUpdItem = true;
            // 
            // multiLayoutItem1495
            // 
            this.multiLayoutItem1495.DataName = "input_gwa";
            this.multiLayoutItem1495.IsUpdItem = true;
            // 
            // multiLayoutItem1496
            // 
            this.multiLayoutItem1496.DataName = "input_doctor";
            this.multiLayoutItem1496.IsUpdItem = true;
            // 
            // multiLayoutItem1497
            // 
            this.multiLayoutItem1497.DataName = "input_gubun";
            this.multiLayoutItem1497.IsUpdItem = true;
            // 
            // multiLayoutItem1498
            // 
            this.multiLayoutItem1498.DataName = "input_gubun_name";
            // 
            // multiLayoutItem1499
            // 
            this.multiLayoutItem1499.DataName = "group_ser";
            this.multiLayoutItem1499.IsUpdItem = true;
            // 
            // multiLayoutItem1517
            // 
            this.multiLayoutItem1517.DataName = "input_tab";
            this.multiLayoutItem1517.IsUpdItem = true;
            // 
            // multiLayoutItem1518
            // 
            this.multiLayoutItem1518.DataName = "input_tab_name";
            // 
            // multiLayoutItem1519
            // 
            this.multiLayoutItem1519.DataName = "order_gubun";
            this.multiLayoutItem1519.IsUpdItem = true;
            // 
            // multiLayoutItem1520
            // 
            this.multiLayoutItem1520.DataName = "order_gubun_name";
            // 
            // multiLayoutItem1521
            // 
            this.multiLayoutItem1521.DataName = "group_yn";
            this.multiLayoutItem1521.IsUpdItem = true;
            // 
            // multiLayoutItem1522
            // 
            this.multiLayoutItem1522.DataName = "seq";
            this.multiLayoutItem1522.IsUpdItem = true;
            // 
            // multiLayoutItem1523
            // 
            this.multiLayoutItem1523.DataName = "slip_code";
            this.multiLayoutItem1523.IsUpdItem = true;
            // 
            // multiLayoutItem1524
            // 
            this.multiLayoutItem1524.DataName = "hangmog_code";
            this.multiLayoutItem1524.IsUpdItem = true;
            // 
            // multiLayoutItem1525
            // 
            this.multiLayoutItem1525.DataName = "hangmog_name";
            // 
            // multiLayoutItem1526
            // 
            this.multiLayoutItem1526.DataName = "specimen_code";
            this.multiLayoutItem1526.IsUpdItem = true;
            // 
            // multiLayoutItem1527
            // 
            this.multiLayoutItem1527.DataName = "specimen_name";
            // 
            // multiLayoutItem1528
            // 
            this.multiLayoutItem1528.DataName = "suryang";
            this.multiLayoutItem1528.IsUpdItem = true;
            // 
            // multiLayoutItem1529
            // 
            this.multiLayoutItem1529.DataName = "sunab_suryang";
            this.multiLayoutItem1529.IsUpdItem = true;
            // 
            // multiLayoutItem1530
            // 
            this.multiLayoutItem1530.DataName = "subul_suryang";
            this.multiLayoutItem1530.IsUpdItem = true;
            // 
            // multiLayoutItem1531
            // 
            this.multiLayoutItem1531.DataName = "ord_danui";
            this.multiLayoutItem1531.IsUpdItem = true;
            // 
            // multiLayoutItem1532
            // 
            this.multiLayoutItem1532.DataName = "ord_danui_name";
            // 
            // multiLayoutItem1533
            // 
            this.multiLayoutItem1533.DataName = "dv_time";
            this.multiLayoutItem1533.IsUpdItem = true;
            // 
            // multiLayoutItem1534
            // 
            this.multiLayoutItem1534.DataName = "dv";
            this.multiLayoutItem1534.IsUpdItem = true;
            // 
            // multiLayoutItem1535
            // 
            this.multiLayoutItem1535.DataName = "dv_1";
            this.multiLayoutItem1535.IsUpdItem = true;
            // 
            // multiLayoutItem1536
            // 
            this.multiLayoutItem1536.DataName = "dv_2";
            this.multiLayoutItem1536.IsUpdItem = true;
            // 
            // multiLayoutItem1537
            // 
            this.multiLayoutItem1537.DataName = "dv_3";
            this.multiLayoutItem1537.IsUpdItem = true;
            // 
            // multiLayoutItem1538
            // 
            this.multiLayoutItem1538.DataName = "dv_4";
            this.multiLayoutItem1538.IsUpdItem = true;
            // 
            // multiLayoutItem1539
            // 
            this.multiLayoutItem1539.DataName = "nalsu";
            this.multiLayoutItem1539.IsUpdItem = true;
            // 
            // multiLayoutItem1540
            // 
            this.multiLayoutItem1540.DataName = "sunab_nalsu";
            this.multiLayoutItem1540.IsUpdItem = true;
            // 
            // multiLayoutItem1541
            // 
            this.multiLayoutItem1541.DataName = "jusa";
            this.multiLayoutItem1541.IsUpdItem = true;
            // 
            // multiLayoutItem1542
            // 
            this.multiLayoutItem1542.DataName = "jusa_name";
            this.multiLayoutItem1542.IsUpdItem = true;
            // 
            // multiLayoutItem1543
            // 
            this.multiLayoutItem1543.DataName = "jusa_spd_gubun";
            this.multiLayoutItem1543.IsUpdItem = true;
            // 
            // multiLayoutItem1544
            // 
            this.multiLayoutItem1544.DataName = "bogyong_code";
            this.multiLayoutItem1544.IsUpdItem = true;
            // 
            // multiLayoutItem1545
            // 
            this.multiLayoutItem1545.DataName = "bogyong_name";
            this.multiLayoutItem1545.IsUpdItem = true;
            // 
            // multiLayoutItem1546
            // 
            this.multiLayoutItem1546.DataName = "emergency";
            this.multiLayoutItem1546.IsUpdItem = true;
            // 
            // multiLayoutItem1547
            // 
            this.multiLayoutItem1547.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem1547.IsUpdItem = true;
            // 
            // multiLayoutItem1548
            // 
            this.multiLayoutItem1548.DataName = "jundal_table";
            this.multiLayoutItem1548.IsUpdItem = true;
            // 
            // multiLayoutItem1549
            // 
            this.multiLayoutItem1549.DataName = "jundal_part";
            this.multiLayoutItem1549.IsUpdItem = true;
            // 
            // multiLayoutItem1550
            // 
            this.multiLayoutItem1550.DataName = "move_part";
            this.multiLayoutItem1550.IsUpdItem = true;
            // 
            // multiLayoutItem1551
            // 
            this.multiLayoutItem1551.DataName = "portable_yn";
            this.multiLayoutItem1551.IsUpdItem = true;
            // 
            // multiLayoutItem1552
            // 
            this.multiLayoutItem1552.DataName = "powder_yn";
            this.multiLayoutItem1552.IsUpdItem = true;
            // 
            // multiLayoutItem1553
            // 
            this.multiLayoutItem1553.DataName = "hubal_change_yn";
            this.multiLayoutItem1553.IsUpdItem = true;
            // 
            // multiLayoutItem1554
            // 
            this.multiLayoutItem1554.DataName = "pharmacy";
            this.multiLayoutItem1554.IsUpdItem = true;
            // 
            // multiLayoutItem1555
            // 
            this.multiLayoutItem1555.DataName = "drg_pack_yn";
            this.multiLayoutItem1555.IsUpdItem = true;
            // 
            // multiLayoutItem1556
            // 
            this.multiLayoutItem1556.DataName = "muhyo";
            this.multiLayoutItem1556.IsUpdItem = true;
            // 
            // multiLayoutItem1557
            // 
            this.multiLayoutItem1557.DataName = "prn_yn";
            this.multiLayoutItem1557.IsUpdItem = true;
            // 
            // multiLayoutItem1558
            // 
            this.multiLayoutItem1558.DataName = "toiwon_drg_yn";
            this.multiLayoutItem1558.IsUpdItem = true;
            // 
            // multiLayoutItem1559
            // 
            this.multiLayoutItem1559.DataName = "prn_nurse";
            this.multiLayoutItem1559.IsUpdItem = true;
            // 
            // multiLayoutItem1560
            // 
            this.multiLayoutItem1560.DataName = "append_yn";
            this.multiLayoutItem1560.IsUpdItem = true;
            // 
            // multiLayoutItem1561
            // 
            this.multiLayoutItem1561.DataName = "order_remark";
            this.multiLayoutItem1561.IsUpdItem = true;
            // 
            // multiLayoutItem1562
            // 
            this.multiLayoutItem1562.DataName = "nurse_remark";
            this.multiLayoutItem1562.IsUpdItem = true;
            // 
            // multiLayoutItem1563
            // 
            this.multiLayoutItem1563.DataName = "comment";
            this.multiLayoutItem1563.IsUpdItem = true;
            // 
            // multiLayoutItem1564
            // 
            this.multiLayoutItem1564.DataName = "mix_group";
            this.multiLayoutItem1564.IsUpdItem = true;
            // 
            // multiLayoutItem1565
            // 
            this.multiLayoutItem1565.DataName = "amt";
            this.multiLayoutItem1565.IsUpdItem = true;
            // 
            // multiLayoutItem1566
            // 
            this.multiLayoutItem1566.DataName = "pay";
            this.multiLayoutItem1566.IsUpdItem = true;
            // 
            // multiLayoutItem1567
            // 
            this.multiLayoutItem1567.DataName = "wonyoi_order_yn";
            this.multiLayoutItem1567.IsUpdItem = true;
            // 
            // multiLayoutItem1568
            // 
            this.multiLayoutItem1568.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem1568.IsUpdItem = true;
            // 
            // multiLayoutItem1569
            // 
            this.multiLayoutItem1569.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem1569.IsUpdItem = true;
            // 
            // multiLayoutItem1570
            // 
            this.multiLayoutItem1570.DataName = "bom_occur_yn";
            this.multiLayoutItem1570.IsUpdItem = true;
            // 
            // multiLayoutItem1571
            // 
            this.multiLayoutItem1571.DataName = "bom_source_key";
            this.multiLayoutItem1571.IsUpdItem = true;
            // 
            // multiLayoutItem1572
            // 
            this.multiLayoutItem1572.DataName = "display_yn";
            this.multiLayoutItem1572.IsUpdItem = true;
            // 
            // multiLayoutItem1573
            // 
            this.multiLayoutItem1573.DataName = "sunab_yn";
            this.multiLayoutItem1573.IsUpdItem = true;
            // 
            // multiLayoutItem1574
            // 
            this.multiLayoutItem1574.DataName = "sunab_date";
            this.multiLayoutItem1574.IsUpdItem = true;
            // 
            // multiLayoutItem1575
            // 
            this.multiLayoutItem1575.DataName = "sunab_time";
            this.multiLayoutItem1575.IsUpdItem = true;
            // 
            // multiLayoutItem1576
            // 
            this.multiLayoutItem1576.DataName = "hope_date";
            this.multiLayoutItem1576.IsUpdItem = true;
            // 
            // multiLayoutItem1577
            // 
            this.multiLayoutItem1577.DataName = "hope_time";
            this.multiLayoutItem1577.IsUpdItem = true;
            // 
            // multiLayoutItem1578
            // 
            this.multiLayoutItem1578.DataName = "nurse_confirm_user";
            this.multiLayoutItem1578.IsUpdItem = true;
            // 
            // multiLayoutItem1579
            // 
            this.multiLayoutItem1579.DataName = "nurse_confirm_date";
            this.multiLayoutItem1579.IsUpdItem = true;
            // 
            // multiLayoutItem1580
            // 
            this.multiLayoutItem1580.DataName = "nurse_confirm_time";
            this.multiLayoutItem1580.IsUpdItem = true;
            // 
            // multiLayoutItem1581
            // 
            this.multiLayoutItem1581.DataName = "nurse_pickup_user";
            this.multiLayoutItem1581.IsUpdItem = true;
            // 
            // multiLayoutItem1582
            // 
            this.multiLayoutItem1582.DataName = "nurse_pickup_date";
            this.multiLayoutItem1582.IsUpdItem = true;
            // 
            // multiLayoutItem1583
            // 
            this.multiLayoutItem1583.DataName = "nurse_pickup_time";
            this.multiLayoutItem1583.IsUpdItem = true;
            // 
            // multiLayoutItem1584
            // 
            this.multiLayoutItem1584.DataName = "nurse_hold_user";
            this.multiLayoutItem1584.IsUpdItem = true;
            // 
            // multiLayoutItem1585
            // 
            this.multiLayoutItem1585.DataName = "nurse_hold_date";
            this.multiLayoutItem1585.IsUpdItem = true;
            // 
            // multiLayoutItem1586
            // 
            this.multiLayoutItem1586.DataName = "nurse_hold_time";
            this.multiLayoutItem1586.IsUpdItem = true;
            // 
            // multiLayoutItem1587
            // 
            this.multiLayoutItem1587.DataName = "reser_date";
            this.multiLayoutItem1587.IsUpdItem = true;
            // 
            // multiLayoutItem1588
            // 
            this.multiLayoutItem1588.DataName = "reser_time";
            this.multiLayoutItem1588.IsUpdItem = true;
            // 
            // multiLayoutItem1589
            // 
            this.multiLayoutItem1589.DataName = "jubsu_date";
            this.multiLayoutItem1589.IsUpdItem = true;
            // 
            // multiLayoutItem1590
            // 
            this.multiLayoutItem1590.DataName = "jubsu_time";
            this.multiLayoutItem1590.IsUpdItem = true;
            // 
            // multiLayoutItem1591
            // 
            this.multiLayoutItem1591.DataName = "acting_date";
            this.multiLayoutItem1591.IsUpdItem = true;
            // 
            // multiLayoutItem1592
            // 
            this.multiLayoutItem1592.DataName = "acting_time";
            this.multiLayoutItem1592.IsUpdItem = true;
            // 
            // multiLayoutItem1593
            // 
            this.multiLayoutItem1593.DataName = "acting_day";
            this.multiLayoutItem1593.IsUpdItem = true;
            // 
            // multiLayoutItem1594
            // 
            this.multiLayoutItem1594.DataName = "result_date";
            this.multiLayoutItem1594.IsUpdItem = true;
            // 
            // multiLayoutItem1595
            // 
            this.multiLayoutItem1595.DataName = "dc_gubun";
            this.multiLayoutItem1595.IsUpdItem = true;
            // 
            // multiLayoutItem1596
            // 
            this.multiLayoutItem1596.DataName = "dc_yn";
            this.multiLayoutItem1596.IsUpdItem = true;
            // 
            // multiLayoutItem1597
            // 
            this.multiLayoutItem1597.DataName = "bannab_yn";
            this.multiLayoutItem1597.IsUpdItem = true;
            // 
            // multiLayoutItem1598
            // 
            this.multiLayoutItem1598.DataName = "bannab_confirm";
            this.multiLayoutItem1598.IsUpdItem = true;
            // 
            // multiLayoutItem1599
            // 
            this.multiLayoutItem1599.DataName = "source_ord_key";
            this.multiLayoutItem1599.IsUpdItem = true;
            // 
            // multiLayoutItem1600
            // 
            this.multiLayoutItem1600.DataName = "ocs_flag";
            this.multiLayoutItem1600.IsUpdItem = true;
            // 
            // multiLayoutItem1601
            // 
            this.multiLayoutItem1601.DataName = "sg_code";
            this.multiLayoutItem1601.IsUpdItem = true;
            // 
            // multiLayoutItem1602
            // 
            this.multiLayoutItem1602.DataName = "sg_ymd";
            this.multiLayoutItem1602.IsUpdItem = true;
            // 
            // multiLayoutItem1603
            // 
            this.multiLayoutItem1603.DataName = "io_gubun";
            this.multiLayoutItem1603.IsUpdItem = true;
            // 
            // multiLayoutItem1604
            // 
            this.multiLayoutItem1604.DataName = "after_act_yn";
            this.multiLayoutItem1604.IsUpdItem = true;
            // 
            // multiLayoutItem1605
            // 
            this.multiLayoutItem1605.DataName = "bichi_yn";
            this.multiLayoutItem1605.IsUpdItem = true;
            // 
            // multiLayoutItem1606
            // 
            this.multiLayoutItem1606.DataName = "drg_bunho";
            this.multiLayoutItem1606.IsUpdItem = true;
            // 
            // multiLayoutItem1607
            // 
            this.multiLayoutItem1607.DataName = "sub_susul";
            this.multiLayoutItem1607.IsUpdItem = true;
            // 
            // multiLayoutItem1608
            // 
            this.multiLayoutItem1608.DataName = "print_yn";
            this.multiLayoutItem1608.IsUpdItem = true;
            // 
            // multiLayoutItem1609
            // 
            this.multiLayoutItem1609.DataName = "chisik";
            this.multiLayoutItem1609.IsUpdItem = true;
            // 
            // multiLayoutItem1610
            // 
            this.multiLayoutItem1610.DataName = "tel_yn";
            this.multiLayoutItem1610.IsUpdItem = true;
            // 
            // multiLayoutItem1611
            // 
            this.multiLayoutItem1611.DataName = "order_gubun_bas";
            this.multiLayoutItem1611.IsUpdItem = true;
            // 
            // multiLayoutItem1612
            // 
            this.multiLayoutItem1612.DataName = "input_control";
            this.multiLayoutItem1612.IsUpdItem = true;
            // 
            // multiLayoutItem1613
            // 
            this.multiLayoutItem1613.DataName = "suga_yn";
            this.multiLayoutItem1613.IsUpdItem = true;
            // 
            // multiLayoutItem1614
            // 
            this.multiLayoutItem1614.DataName = "jaeryo_yn";
            this.multiLayoutItem1614.IsUpdItem = true;
            // 
            // multiLayoutItem1615
            // 
            this.multiLayoutItem1615.DataName = "wonyoi_check";
            this.multiLayoutItem1615.IsUpdItem = true;
            // 
            // multiLayoutItem1616
            // 
            this.multiLayoutItem1616.DataName = "emergency_check";
            this.multiLayoutItem1616.IsUpdItem = true;
            // 
            // multiLayoutItem1617
            // 
            this.multiLayoutItem1617.DataName = "specimen_check";
            // 
            // multiLayoutItem1618
            // 
            this.multiLayoutItem1618.DataName = "portable_check";
            this.multiLayoutItem1618.IsUpdItem = true;
            // 
            // multiLayoutItem1619
            // 
            this.multiLayoutItem1619.DataName = "bulyong_check";
            this.multiLayoutItem1619.IsUpdItem = true;
            // 
            // multiLayoutItem1620
            // 
            this.multiLayoutItem1620.DataName = "sunab_check";
            // 
            // multiLayoutItem1621
            // 
            this.multiLayoutItem1621.DataName = "dc_check";
            // 
            // multiLayoutItem1622
            // 
            this.multiLayoutItem1622.DataName = "dc_gubun_check";
            this.multiLayoutItem1622.IsUpdItem = true;
            // 
            // multiLayoutItem1623
            // 
            this.multiLayoutItem1623.DataName = "confirm_check";
            this.multiLayoutItem1623.IsUpdItem = true;
            // 
            // multiLayoutItem1624
            // 
            this.multiLayoutItem1624.DataName = "reser_yn_check";
            this.multiLayoutItem1624.IsUpdItem = true;
            // 
            // multiLayoutItem1625
            // 
            this.multiLayoutItem1625.DataName = "chisik_check";
            this.multiLayoutItem1625.IsUpdItem = true;
            // 
            // multiLayoutItem1626
            // 
            this.multiLayoutItem1626.DataName = "nday_yn";
            this.multiLayoutItem1626.IsUpdItem = true;
            // 
            // multiLayoutItem1627
            // 
            this.multiLayoutItem1627.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem1627.IsUpdItem = true;
            // 
            // multiLayoutItem1628
            // 
            this.multiLayoutItem1628.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem1628.IsUpdItem = true;
            // 
            // multiLayoutItem1629
            // 
            this.multiLayoutItem1629.DataName = "specific_comment";
            this.multiLayoutItem1629.IsUpdItem = true;
            // 
            // multiLayoutItem1630
            // 
            this.multiLayoutItem1630.DataName = "specific_comment_name";
            this.multiLayoutItem1630.IsUpdItem = true;
            // 
            // multiLayoutItem1631
            // 
            this.multiLayoutItem1631.DataName = "specific_comment_sys_id";
            this.multiLayoutItem1631.IsUpdItem = true;
            // 
            // multiLayoutItem1632
            // 
            this.multiLayoutItem1632.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem1632.IsUpdItem = true;
            // 
            // multiLayoutItem1633
            // 
            this.multiLayoutItem1633.DataName = "specific_comment_not_null";
            this.multiLayoutItem1633.IsUpdItem = true;
            // 
            // multiLayoutItem1634
            // 
            this.multiLayoutItem1634.DataName = "specific_comment_table_id";
            this.multiLayoutItem1634.IsUpdItem = true;
            // 
            // multiLayoutItem1635
            // 
            this.multiLayoutItem1635.DataName = "specific_comment_col_id";
            this.multiLayoutItem1635.IsUpdItem = true;
            // 
            // multiLayoutItem1636
            // 
            this.multiLayoutItem1636.DataName = "donbog_yn";
            this.multiLayoutItem1636.IsUpdItem = true;
            // 
            // multiLayoutItem1637
            // 
            this.multiLayoutItem1637.DataName = "order_gubun_bas_name";
            this.multiLayoutItem1637.IsUpdItem = true;
            // 
            // multiLayoutItem1638
            // 
            this.multiLayoutItem1638.DataName = "act_doctor";
            this.multiLayoutItem1638.IsUpdItem = true;
            // 
            // multiLayoutItem1639
            // 
            this.multiLayoutItem1639.DataName = "act_buseo";
            this.multiLayoutItem1639.IsUpdItem = true;
            // 
            // multiLayoutItem1640
            // 
            this.multiLayoutItem1640.DataName = "act_gwa";
            this.multiLayoutItem1640.IsUpdItem = true;
            // 
            // multiLayoutItem1641
            // 
            this.multiLayoutItem1641.DataName = "home_care_yn";
            this.multiLayoutItem1641.IsUpdItem = true;
            // 
            // multiLayoutItem1642
            // 
            this.multiLayoutItem1642.DataName = "regular_yn";
            this.multiLayoutItem1642.IsUpdItem = true;
            // 
            // multiLayoutItem1643
            // 
            this.multiLayoutItem1643.DataName = "sort_fkocskey";
            this.multiLayoutItem1643.IsUpdItem = true;
            // 
            // multiLayoutItem1644
            // 
            this.multiLayoutItem1644.DataName = "child_yn";
            this.multiLayoutItem1644.IsUpdItem = true;
            // 
            // multiLayoutItem1645
            // 
            this.multiLayoutItem1645.DataName = "if_input_control";
            // 
            // multiLayoutItem1660
            // 
            this.multiLayoutItem1660.DataName = "child_gubun";
            // 
            // multiLayoutItem1938
            // 
            this.multiLayoutItem1938.DataName = "slip_name";
            // 
            // multiLayoutItem1954
            // 
            this.multiLayoutItem1954.DataName = "nday_occur_yn";
            this.multiLayoutItem1954.IsUpdItem = true;
            // 
            // multiLayoutItem1955
            // 
            this.multiLayoutItem1955.DataName = "org_key";
            // 
            // multiLayoutItem1956
            // 
            this.multiLayoutItem1956.DataName = "parent_key";
            // 
            // multiLayoutItem1957
            // 
            this.multiLayoutItem1957.DataName = "bun_code";
            // 
            // multiLayoutItem1958
            // 
            this.multiLayoutItem1958.DataName = "wonnae_drg_yn";
            // 
            // multiLayoutItem1959
            // 
            this.multiLayoutItem1959.DataName = "hubal_change_check";
            // 
            // multiLayoutItem1960
            // 
            this.multiLayoutItem1960.DataName = "drg_pack_check";
            // 
            // multiLayoutItem1961
            // 
            this.multiLayoutItem1961.DataName = "pharmacy_check";
            // 
            // multiLayoutItem1962
            // 
            this.multiLayoutItem1962.DataName = "powder_check";
            // 
            // layCplOrder
            // 
            this.layCplOrder.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem432,
            this.multiLayoutItem433,
            this.multiLayoutItem434,
            this.multiLayoutItem435,
            this.multiLayoutItem436,
            this.multiLayoutItem437,
            this.multiLayoutItem438,
            this.multiLayoutItem439,
            this.multiLayoutItem440,
            this.multiLayoutItem441,
            this.multiLayoutItem442,
            this.multiLayoutItem443,
            this.multiLayoutItem444,
            this.multiLayoutItem445,
            this.multiLayoutItem446,
            this.multiLayoutItem447,
            this.multiLayoutItem448,
            this.multiLayoutItem449,
            this.multiLayoutItem450,
            this.multiLayoutItem451,
            this.multiLayoutItem452,
            this.multiLayoutItem453,
            this.multiLayoutItem454,
            this.multiLayoutItem455,
            this.multiLayoutItem456,
            this.multiLayoutItem457,
            this.multiLayoutItem458,
            this.multiLayoutItem459,
            this.multiLayoutItem460,
            this.multiLayoutItem461,
            this.multiLayoutItem462,
            this.multiLayoutItem463,
            this.multiLayoutItem464,
            this.multiLayoutItem465,
            this.multiLayoutItem466,
            this.multiLayoutItem467,
            this.multiLayoutItem468,
            this.multiLayoutItem469,
            this.multiLayoutItem470,
            this.multiLayoutItem471,
            this.multiLayoutItem472,
            this.multiLayoutItem473,
            this.multiLayoutItem474,
            this.multiLayoutItem475,
            this.multiLayoutItem476,
            this.multiLayoutItem477,
            this.multiLayoutItem478,
            this.multiLayoutItem479,
            this.multiLayoutItem480,
            this.multiLayoutItem481,
            this.multiLayoutItem482,
            this.multiLayoutItem483,
            this.multiLayoutItem484,
            this.multiLayoutItem485,
            this.multiLayoutItem486,
            this.multiLayoutItem487,
            this.multiLayoutItem488,
            this.multiLayoutItem489,
            this.multiLayoutItem490,
            this.multiLayoutItem491,
            this.multiLayoutItem492,
            this.multiLayoutItem493,
            this.multiLayoutItem494,
            this.multiLayoutItem495,
            this.multiLayoutItem496,
            this.multiLayoutItem497,
            this.multiLayoutItem498,
            this.multiLayoutItem499,
            this.multiLayoutItem500,
            this.multiLayoutItem501,
            this.multiLayoutItem502,
            this.multiLayoutItem503,
            this.multiLayoutItem504,
            this.multiLayoutItem505,
            this.multiLayoutItem506,
            this.multiLayoutItem507,
            this.multiLayoutItem508,
            this.multiLayoutItem509,
            this.multiLayoutItem510,
            this.multiLayoutItem511,
            this.multiLayoutItem512,
            this.multiLayoutItem513,
            this.multiLayoutItem514,
            this.multiLayoutItem515,
            this.multiLayoutItem516,
            this.multiLayoutItem517,
            this.multiLayoutItem518,
            this.multiLayoutItem519,
            this.multiLayoutItem520,
            this.multiLayoutItem521,
            this.multiLayoutItem522,
            this.multiLayoutItem523,
            this.multiLayoutItem524,
            this.multiLayoutItem525,
            this.multiLayoutItem526,
            this.multiLayoutItem527,
            this.multiLayoutItem528,
            this.multiLayoutItem529,
            this.multiLayoutItem530,
            this.multiLayoutItem531,
            this.multiLayoutItem532,
            this.multiLayoutItem533,
            this.multiLayoutItem534,
            this.multiLayoutItem535,
            this.multiLayoutItem536,
            this.multiLayoutItem537,
            this.multiLayoutItem538,
            this.multiLayoutItem539,
            this.multiLayoutItem540,
            this.multiLayoutItem541,
            this.multiLayoutItem542,
            this.multiLayoutItem543,
            this.multiLayoutItem544,
            this.multiLayoutItem545,
            this.multiLayoutItem546,
            this.multiLayoutItem547,
            this.multiLayoutItem548,
            this.multiLayoutItem549,
            this.multiLayoutItem687,
            this.multiLayoutItem688,
            this.multiLayoutItem689,
            this.multiLayoutItem690,
            this.multiLayoutItem691,
            this.multiLayoutItem692,
            this.multiLayoutItem693,
            this.multiLayoutItem694,
            this.multiLayoutItem701,
            this.multiLayoutItem702,
            this.multiLayoutItem703,
            this.multiLayoutItem713,
            this.multiLayoutItem723,
            this.multiLayoutItem724,
            this.multiLayoutItem1013,
            this.multiLayoutItem1014,
            this.multiLayoutItem1015,
            this.multiLayoutItem1016,
            this.multiLayoutItem1029,
            this.multiLayoutItem1928,
            this.multiLayoutItem1929,
            this.multiLayoutItem1930,
            this.multiLayoutItem1931});
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "in_out_key";
            this.multiLayoutItem23.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem23.IsUpdItem = true;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "pkocskey";
            this.multiLayoutItem24.IsUpdItem = true;
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "bunho";
            this.multiLayoutItem25.IsUpdItem = true;
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "order_date";
            this.multiLayoutItem26.IsUpdItem = true;
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "gwa";
            this.multiLayoutItem27.IsUpdItem = true;
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "doctor";
            this.multiLayoutItem28.IsUpdItem = true;
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "resident";
            this.multiLayoutItem29.IsUpdItem = true;
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "naewon_type";
            this.multiLayoutItem30.IsUpdItem = true;
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "jubsu_no";
            this.multiLayoutItem31.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem31.IsUpdItem = true;
            // 
            // multiLayoutItem432
            // 
            this.multiLayoutItem432.DataName = "input_id";
            this.multiLayoutItem432.IsUpdItem = true;
            // 
            // multiLayoutItem433
            // 
            this.multiLayoutItem433.DataName = "input_part";
            this.multiLayoutItem433.IsUpdItem = true;
            // 
            // multiLayoutItem434
            // 
            this.multiLayoutItem434.DataName = "input_gwa";
            this.multiLayoutItem434.IsUpdItem = true;
            // 
            // multiLayoutItem435
            // 
            this.multiLayoutItem435.DataName = "input_doctor";
            this.multiLayoutItem435.IsUpdItem = true;
            // 
            // multiLayoutItem436
            // 
            this.multiLayoutItem436.DataName = "input_gubun";
            this.multiLayoutItem436.IsUpdItem = true;
            // 
            // multiLayoutItem437
            // 
            this.multiLayoutItem437.DataName = "input_gubun_name";
            // 
            // multiLayoutItem438
            // 
            this.multiLayoutItem438.DataName = "group_ser";
            this.multiLayoutItem438.IsUpdItem = true;
            // 
            // multiLayoutItem439
            // 
            this.multiLayoutItem439.DataName = "input_tab";
            this.multiLayoutItem439.IsUpdItem = true;
            // 
            // multiLayoutItem440
            // 
            this.multiLayoutItem440.DataName = "input_tab_name";
            // 
            // multiLayoutItem441
            // 
            this.multiLayoutItem441.DataName = "order_gubun";
            this.multiLayoutItem441.IsUpdItem = true;
            // 
            // multiLayoutItem442
            // 
            this.multiLayoutItem442.DataName = "order_gubun_name";
            // 
            // multiLayoutItem443
            // 
            this.multiLayoutItem443.DataName = "group_yn";
            this.multiLayoutItem443.IsUpdItem = true;
            // 
            // multiLayoutItem444
            // 
            this.multiLayoutItem444.DataName = "seq";
            this.multiLayoutItem444.IsUpdItem = true;
            // 
            // multiLayoutItem445
            // 
            this.multiLayoutItem445.DataName = "slip_code";
            this.multiLayoutItem445.IsUpdItem = true;
            // 
            // multiLayoutItem446
            // 
            this.multiLayoutItem446.DataName = "hangmog_code";
            this.multiLayoutItem446.IsUpdItem = true;
            // 
            // multiLayoutItem447
            // 
            this.multiLayoutItem447.DataName = "hangmog_name";
            // 
            // multiLayoutItem448
            // 
            this.multiLayoutItem448.DataName = "specimen_code";
            this.multiLayoutItem448.IsUpdItem = true;
            // 
            // multiLayoutItem449
            // 
            this.multiLayoutItem449.DataName = "specimen_name";
            // 
            // multiLayoutItem450
            // 
            this.multiLayoutItem450.DataName = "suryang";
            this.multiLayoutItem450.IsUpdItem = true;
            // 
            // multiLayoutItem451
            // 
            this.multiLayoutItem451.DataName = "sunab_suryang";
            this.multiLayoutItem451.IsUpdItem = true;
            // 
            // multiLayoutItem452
            // 
            this.multiLayoutItem452.DataName = "subul_suryang";
            this.multiLayoutItem452.IsUpdItem = true;
            // 
            // multiLayoutItem453
            // 
            this.multiLayoutItem453.DataName = "ord_danui";
            this.multiLayoutItem453.IsUpdItem = true;
            // 
            // multiLayoutItem454
            // 
            this.multiLayoutItem454.DataName = "ord_danui_name";
            // 
            // multiLayoutItem455
            // 
            this.multiLayoutItem455.DataName = "dv_time";
            this.multiLayoutItem455.IsUpdItem = true;
            // 
            // multiLayoutItem456
            // 
            this.multiLayoutItem456.DataName = "dv";
            this.multiLayoutItem456.IsUpdItem = true;
            // 
            // multiLayoutItem457
            // 
            this.multiLayoutItem457.DataName = "dv_1";
            this.multiLayoutItem457.IsUpdItem = true;
            // 
            // multiLayoutItem458
            // 
            this.multiLayoutItem458.DataName = "dv_2";
            this.multiLayoutItem458.IsUpdItem = true;
            // 
            // multiLayoutItem459
            // 
            this.multiLayoutItem459.DataName = "dv_3";
            this.multiLayoutItem459.IsUpdItem = true;
            // 
            // multiLayoutItem460
            // 
            this.multiLayoutItem460.DataName = "dv_4";
            this.multiLayoutItem460.IsUpdItem = true;
            // 
            // multiLayoutItem461
            // 
            this.multiLayoutItem461.DataName = "nalsu";
            this.multiLayoutItem461.IsUpdItem = true;
            // 
            // multiLayoutItem462
            // 
            this.multiLayoutItem462.DataName = "sunab_nalsu";
            this.multiLayoutItem462.IsUpdItem = true;
            // 
            // multiLayoutItem463
            // 
            this.multiLayoutItem463.DataName = "jusa";
            this.multiLayoutItem463.IsUpdItem = true;
            // 
            // multiLayoutItem464
            // 
            this.multiLayoutItem464.DataName = "jusa_name";
            this.multiLayoutItem464.IsUpdItem = true;
            // 
            // multiLayoutItem465
            // 
            this.multiLayoutItem465.DataName = "jusa_spd_gubun";
            this.multiLayoutItem465.IsUpdItem = true;
            // 
            // multiLayoutItem466
            // 
            this.multiLayoutItem466.DataName = "bogyong_code";
            this.multiLayoutItem466.IsUpdItem = true;
            // 
            // multiLayoutItem467
            // 
            this.multiLayoutItem467.DataName = "bogyong_name";
            this.multiLayoutItem467.IsUpdItem = true;
            // 
            // multiLayoutItem468
            // 
            this.multiLayoutItem468.DataName = "emergency";
            this.multiLayoutItem468.IsUpdItem = true;
            // 
            // multiLayoutItem469
            // 
            this.multiLayoutItem469.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem469.IsUpdItem = true;
            // 
            // multiLayoutItem470
            // 
            this.multiLayoutItem470.DataName = "jundal_table";
            this.multiLayoutItem470.IsUpdItem = true;
            // 
            // multiLayoutItem471
            // 
            this.multiLayoutItem471.DataName = "jundal_part";
            this.multiLayoutItem471.IsUpdItem = true;
            // 
            // multiLayoutItem472
            // 
            this.multiLayoutItem472.DataName = "move_part";
            this.multiLayoutItem472.IsUpdItem = true;
            // 
            // multiLayoutItem473
            // 
            this.multiLayoutItem473.DataName = "portable_yn";
            this.multiLayoutItem473.IsUpdItem = true;
            // 
            // multiLayoutItem474
            // 
            this.multiLayoutItem474.DataName = "powder_yn";
            this.multiLayoutItem474.IsUpdItem = true;
            // 
            // multiLayoutItem475
            // 
            this.multiLayoutItem475.DataName = "hubal_change_yn";
            this.multiLayoutItem475.IsUpdItem = true;
            // 
            // multiLayoutItem476
            // 
            this.multiLayoutItem476.DataName = "pharmacy";
            this.multiLayoutItem476.IsUpdItem = true;
            // 
            // multiLayoutItem477
            // 
            this.multiLayoutItem477.DataName = "drg_pack_yn";
            this.multiLayoutItem477.IsUpdItem = true;
            // 
            // multiLayoutItem478
            // 
            this.multiLayoutItem478.DataName = "muhyo";
            this.multiLayoutItem478.IsUpdItem = true;
            // 
            // multiLayoutItem479
            // 
            this.multiLayoutItem479.DataName = "prn_yn";
            this.multiLayoutItem479.IsUpdItem = true;
            // 
            // multiLayoutItem480
            // 
            this.multiLayoutItem480.DataName = "toiwon_drg_yn";
            this.multiLayoutItem480.IsUpdItem = true;
            // 
            // multiLayoutItem481
            // 
            this.multiLayoutItem481.DataName = "prn_nurse";
            this.multiLayoutItem481.IsUpdItem = true;
            // 
            // multiLayoutItem482
            // 
            this.multiLayoutItem482.DataName = "append_yn";
            this.multiLayoutItem482.IsUpdItem = true;
            // 
            // multiLayoutItem483
            // 
            this.multiLayoutItem483.DataName = "order_remark";
            this.multiLayoutItem483.IsUpdItem = true;
            // 
            // multiLayoutItem484
            // 
            this.multiLayoutItem484.DataName = "nurse_remark";
            this.multiLayoutItem484.IsUpdItem = true;
            // 
            // multiLayoutItem485
            // 
            this.multiLayoutItem485.DataName = "comment";
            this.multiLayoutItem485.IsUpdItem = true;
            // 
            // multiLayoutItem486
            // 
            this.multiLayoutItem486.DataName = "mix_group";
            this.multiLayoutItem486.IsUpdItem = true;
            // 
            // multiLayoutItem487
            // 
            this.multiLayoutItem487.DataName = "amt";
            this.multiLayoutItem487.IsUpdItem = true;
            // 
            // multiLayoutItem488
            // 
            this.multiLayoutItem488.DataName = "pay";
            this.multiLayoutItem488.IsUpdItem = true;
            // 
            // multiLayoutItem489
            // 
            this.multiLayoutItem489.DataName = "wonyoi_order_yn";
            this.multiLayoutItem489.IsUpdItem = true;
            // 
            // multiLayoutItem490
            // 
            this.multiLayoutItem490.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem490.IsUpdItem = true;
            // 
            // multiLayoutItem491
            // 
            this.multiLayoutItem491.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem491.IsUpdItem = true;
            // 
            // multiLayoutItem492
            // 
            this.multiLayoutItem492.DataName = "bom_occur_yn";
            this.multiLayoutItem492.IsUpdItem = true;
            // 
            // multiLayoutItem493
            // 
            this.multiLayoutItem493.DataName = "bom_source_key";
            this.multiLayoutItem493.IsUpdItem = true;
            // 
            // multiLayoutItem494
            // 
            this.multiLayoutItem494.DataName = "display_yn";
            this.multiLayoutItem494.IsUpdItem = true;
            // 
            // multiLayoutItem495
            // 
            this.multiLayoutItem495.DataName = "sunab_yn";
            this.multiLayoutItem495.IsUpdItem = true;
            // 
            // multiLayoutItem496
            // 
            this.multiLayoutItem496.DataName = "sunab_date";
            this.multiLayoutItem496.IsUpdItem = true;
            // 
            // multiLayoutItem497
            // 
            this.multiLayoutItem497.DataName = "sunab_time";
            this.multiLayoutItem497.IsUpdItem = true;
            // 
            // multiLayoutItem498
            // 
            this.multiLayoutItem498.DataName = "hope_date";
            this.multiLayoutItem498.IsUpdItem = true;
            // 
            // multiLayoutItem499
            // 
            this.multiLayoutItem499.DataName = "hope_time";
            this.multiLayoutItem499.IsUpdItem = true;
            // 
            // multiLayoutItem500
            // 
            this.multiLayoutItem500.DataName = "nurse_confirm_user";
            this.multiLayoutItem500.IsUpdItem = true;
            // 
            // multiLayoutItem501
            // 
            this.multiLayoutItem501.DataName = "nurse_confirm_date";
            this.multiLayoutItem501.IsUpdItem = true;
            // 
            // multiLayoutItem502
            // 
            this.multiLayoutItem502.DataName = "nurse_confirm_time";
            this.multiLayoutItem502.IsUpdItem = true;
            // 
            // multiLayoutItem503
            // 
            this.multiLayoutItem503.DataName = "nurse_pickup_user";
            this.multiLayoutItem503.IsUpdItem = true;
            // 
            // multiLayoutItem504
            // 
            this.multiLayoutItem504.DataName = "nurse_pickup_date";
            this.multiLayoutItem504.IsUpdItem = true;
            // 
            // multiLayoutItem505
            // 
            this.multiLayoutItem505.DataName = "nurse_pickup_time";
            this.multiLayoutItem505.IsUpdItem = true;
            // 
            // multiLayoutItem506
            // 
            this.multiLayoutItem506.DataName = "nurse_hold_user";
            this.multiLayoutItem506.IsUpdItem = true;
            // 
            // multiLayoutItem507
            // 
            this.multiLayoutItem507.DataName = "nurse_hold_date";
            this.multiLayoutItem507.IsUpdItem = true;
            // 
            // multiLayoutItem508
            // 
            this.multiLayoutItem508.DataName = "nurse_hold_time";
            this.multiLayoutItem508.IsUpdItem = true;
            // 
            // multiLayoutItem509
            // 
            this.multiLayoutItem509.DataName = "reser_date";
            this.multiLayoutItem509.IsUpdItem = true;
            // 
            // multiLayoutItem510
            // 
            this.multiLayoutItem510.DataName = "reser_time";
            this.multiLayoutItem510.IsUpdItem = true;
            // 
            // multiLayoutItem511
            // 
            this.multiLayoutItem511.DataName = "jubsu_date";
            this.multiLayoutItem511.IsUpdItem = true;
            // 
            // multiLayoutItem512
            // 
            this.multiLayoutItem512.DataName = "jubsu_time";
            this.multiLayoutItem512.IsUpdItem = true;
            // 
            // multiLayoutItem513
            // 
            this.multiLayoutItem513.DataName = "acting_date";
            this.multiLayoutItem513.IsUpdItem = true;
            // 
            // multiLayoutItem514
            // 
            this.multiLayoutItem514.DataName = "acting_time";
            this.multiLayoutItem514.IsUpdItem = true;
            // 
            // multiLayoutItem515
            // 
            this.multiLayoutItem515.DataName = "acting_day";
            this.multiLayoutItem515.IsUpdItem = true;
            // 
            // multiLayoutItem516
            // 
            this.multiLayoutItem516.DataName = "result_date";
            this.multiLayoutItem516.IsUpdItem = true;
            // 
            // multiLayoutItem517
            // 
            this.multiLayoutItem517.DataName = "dc_gubun";
            this.multiLayoutItem517.IsUpdItem = true;
            // 
            // multiLayoutItem518
            // 
            this.multiLayoutItem518.DataName = "dc_yn";
            this.multiLayoutItem518.IsUpdItem = true;
            // 
            // multiLayoutItem519
            // 
            this.multiLayoutItem519.DataName = "bannab_yn";
            this.multiLayoutItem519.IsUpdItem = true;
            // 
            // multiLayoutItem520
            // 
            this.multiLayoutItem520.DataName = "bannab_confirm";
            this.multiLayoutItem520.IsUpdItem = true;
            // 
            // multiLayoutItem521
            // 
            this.multiLayoutItem521.DataName = "source_ord_key";
            this.multiLayoutItem521.IsUpdItem = true;
            // 
            // multiLayoutItem522
            // 
            this.multiLayoutItem522.DataName = "ocs_flag";
            this.multiLayoutItem522.IsUpdItem = true;
            // 
            // multiLayoutItem523
            // 
            this.multiLayoutItem523.DataName = "sg_code";
            this.multiLayoutItem523.IsUpdItem = true;
            // 
            // multiLayoutItem524
            // 
            this.multiLayoutItem524.DataName = "sg_ymd";
            this.multiLayoutItem524.IsUpdItem = true;
            // 
            // multiLayoutItem525
            // 
            this.multiLayoutItem525.DataName = "io_gubun";
            this.multiLayoutItem525.IsUpdItem = true;
            // 
            // multiLayoutItem526
            // 
            this.multiLayoutItem526.DataName = "after_act_yn";
            this.multiLayoutItem526.IsUpdItem = true;
            // 
            // multiLayoutItem527
            // 
            this.multiLayoutItem527.DataName = "bichi_yn";
            this.multiLayoutItem527.IsUpdItem = true;
            // 
            // multiLayoutItem528
            // 
            this.multiLayoutItem528.DataName = "drg_bunho";
            this.multiLayoutItem528.IsUpdItem = true;
            // 
            // multiLayoutItem529
            // 
            this.multiLayoutItem529.DataName = "sub_susul";
            this.multiLayoutItem529.IsUpdItem = true;
            // 
            // multiLayoutItem530
            // 
            this.multiLayoutItem530.DataName = "print_yn";
            this.multiLayoutItem530.IsUpdItem = true;
            // 
            // multiLayoutItem531
            // 
            this.multiLayoutItem531.DataName = "chisik";
            this.multiLayoutItem531.IsUpdItem = true;
            // 
            // multiLayoutItem532
            // 
            this.multiLayoutItem532.DataName = "tel_yn";
            this.multiLayoutItem532.IsUpdItem = true;
            // 
            // multiLayoutItem533
            // 
            this.multiLayoutItem533.DataName = "order_gubun_bas";
            this.multiLayoutItem533.IsUpdItem = true;
            // 
            // multiLayoutItem534
            // 
            this.multiLayoutItem534.DataName = "input_control";
            this.multiLayoutItem534.IsUpdItem = true;
            // 
            // multiLayoutItem535
            // 
            this.multiLayoutItem535.DataName = "suga_yn";
            this.multiLayoutItem535.IsUpdItem = true;
            // 
            // multiLayoutItem536
            // 
            this.multiLayoutItem536.DataName = "jaeryo_yn";
            this.multiLayoutItem536.IsUpdItem = true;
            // 
            // multiLayoutItem537
            // 
            this.multiLayoutItem537.DataName = "wonyoi_check";
            this.multiLayoutItem537.IsUpdItem = true;
            // 
            // multiLayoutItem538
            // 
            this.multiLayoutItem538.DataName = "emergency_check";
            this.multiLayoutItem538.IsUpdItem = true;
            // 
            // multiLayoutItem539
            // 
            this.multiLayoutItem539.DataName = "specimen_check";
            // 
            // multiLayoutItem540
            // 
            this.multiLayoutItem540.DataName = "portable_check";
            this.multiLayoutItem540.IsUpdItem = true;
            // 
            // multiLayoutItem541
            // 
            this.multiLayoutItem541.DataName = "bulyong_check";
            this.multiLayoutItem541.IsUpdItem = true;
            // 
            // multiLayoutItem542
            // 
            this.multiLayoutItem542.DataName = "sunab_check";
            // 
            // multiLayoutItem543
            // 
            this.multiLayoutItem543.DataName = "dc_check";
            // 
            // multiLayoutItem544
            // 
            this.multiLayoutItem544.DataName = "dc_gubun_check";
            this.multiLayoutItem544.IsUpdItem = true;
            // 
            // multiLayoutItem545
            // 
            this.multiLayoutItem545.DataName = "confirm_check";
            this.multiLayoutItem545.IsUpdItem = true;
            // 
            // multiLayoutItem546
            // 
            this.multiLayoutItem546.DataName = "reser_yn_check";
            this.multiLayoutItem546.IsUpdItem = true;
            // 
            // multiLayoutItem547
            // 
            this.multiLayoutItem547.DataName = "chisik_check";
            this.multiLayoutItem547.IsUpdItem = true;
            // 
            // multiLayoutItem548
            // 
            this.multiLayoutItem548.DataName = "nday_yn";
            this.multiLayoutItem548.IsUpdItem = true;
            // 
            // multiLayoutItem549
            // 
            this.multiLayoutItem549.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem549.IsUpdItem = true;
            // 
            // multiLayoutItem687
            // 
            this.multiLayoutItem687.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem687.IsUpdItem = true;
            // 
            // multiLayoutItem688
            // 
            this.multiLayoutItem688.DataName = "specific_comment";
            this.multiLayoutItem688.IsUpdItem = true;
            // 
            // multiLayoutItem689
            // 
            this.multiLayoutItem689.DataName = "specific_comment_name";
            this.multiLayoutItem689.IsUpdItem = true;
            // 
            // multiLayoutItem690
            // 
            this.multiLayoutItem690.DataName = "specific_comment_sys_id";
            this.multiLayoutItem690.IsUpdItem = true;
            // 
            // multiLayoutItem691
            // 
            this.multiLayoutItem691.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem691.IsUpdItem = true;
            // 
            // multiLayoutItem692
            // 
            this.multiLayoutItem692.DataName = "specific_comment_not_null";
            this.multiLayoutItem692.IsUpdItem = true;
            // 
            // multiLayoutItem693
            // 
            this.multiLayoutItem693.DataName = "specific_comment_table_id";
            this.multiLayoutItem693.IsUpdItem = true;
            // 
            // multiLayoutItem694
            // 
            this.multiLayoutItem694.DataName = "specific_comment_col_id";
            this.multiLayoutItem694.IsUpdItem = true;
            // 
            // multiLayoutItem701
            // 
            this.multiLayoutItem701.DataName = "donbog_yn";
            this.multiLayoutItem701.IsUpdItem = true;
            // 
            // multiLayoutItem702
            // 
            this.multiLayoutItem702.DataName = "order_gubun_bas_name";
            this.multiLayoutItem702.IsUpdItem = true;
            // 
            // multiLayoutItem703
            // 
            this.multiLayoutItem703.DataName = "act_doctoor";
            this.multiLayoutItem703.IsUpdItem = true;
            // 
            // multiLayoutItem713
            // 
            this.multiLayoutItem713.DataName = "act_buseo";
            this.multiLayoutItem713.IsUpdItem = true;
            // 
            // multiLayoutItem723
            // 
            this.multiLayoutItem723.DataName = "act_gwa";
            this.multiLayoutItem723.IsUpdItem = true;
            // 
            // multiLayoutItem724
            // 
            this.multiLayoutItem724.DataName = "home_care_yn";
            this.multiLayoutItem724.IsUpdItem = true;
            // 
            // multiLayoutItem1013
            // 
            this.multiLayoutItem1013.DataName = "regular_yn";
            this.multiLayoutItem1013.IsUpdItem = true;
            // 
            // multiLayoutItem1014
            // 
            this.multiLayoutItem1014.DataName = "sort_fkocskey";
            this.multiLayoutItem1014.IsUpdItem = true;
            // 
            // multiLayoutItem1015
            // 
            this.multiLayoutItem1015.DataName = "child_yn";
            this.multiLayoutItem1015.IsUpdItem = true;
            // 
            // multiLayoutItem1016
            // 
            this.multiLayoutItem1016.DataName = "if_input_control";
            // 
            // multiLayoutItem1029
            // 
            this.multiLayoutItem1029.DataName = "slip_name";
            // 
            // multiLayoutItem1928
            // 
            this.multiLayoutItem1928.DataName = "org_key";
            // 
            // multiLayoutItem1929
            // 
            this.multiLayoutItem1929.DataName = "parent_key";
            // 
            // multiLayoutItem1930
            // 
            this.multiLayoutItem1930.DataName = "bun_code";
            // 
            // multiLayoutItem1931
            // 
            this.multiLayoutItem1931.DataName = "wonnae_drg_yn";
            // 
            // layJusaOrder
            // 
            this.layJusaOrder.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1972,
            this.multiLayoutItem1973,
            this.multiLayoutItem1974,
            this.multiLayoutItem1975,
            this.multiLayoutItem1976,
            this.multiLayoutItem1977,
            this.multiLayoutItem1978,
            this.multiLayoutItem1979,
            this.multiLayoutItem1980,
            this.multiLayoutItem1981,
            this.multiLayoutItem1982,
            this.multiLayoutItem1983,
            this.multiLayoutItem1984,
            this.multiLayoutItem1985,
            this.multiLayoutItem1986,
            this.multiLayoutItem1987,
            this.multiLayoutItem1988,
            this.multiLayoutItem1989,
            this.multiLayoutItem1990,
            this.multiLayoutItem1991,
            this.multiLayoutItem1992,
            this.multiLayoutItem1993,
            this.multiLayoutItem1994,
            this.multiLayoutItem1995,
            this.multiLayoutItem1996,
            this.multiLayoutItem1997,
            this.multiLayoutItem1998,
            this.multiLayoutItem1999,
            this.multiLayoutItem2000,
            this.multiLayoutItem2001,
            this.multiLayoutItem2002,
            this.multiLayoutItem2003,
            this.multiLayoutItem2004,
            this.multiLayoutItem2005,
            this.multiLayoutItem2006,
            this.multiLayoutItem2007,
            this.multiLayoutItem2008,
            this.multiLayoutItem2009,
            this.multiLayoutItem2010,
            this.multiLayoutItem2011,
            this.multiLayoutItem2012,
            this.multiLayoutItem2013,
            this.multiLayoutItem2014,
            this.multiLayoutItem2015,
            this.multiLayoutItem2016,
            this.multiLayoutItem2017,
            this.multiLayoutItem2018,
            this.multiLayoutItem2019,
            this.multiLayoutItem2020,
            this.multiLayoutItem2021,
            this.multiLayoutItem2022,
            this.multiLayoutItem2023,
            this.multiLayoutItem2024,
            this.multiLayoutItem2025,
            this.multiLayoutItem2026,
            this.multiLayoutItem2027,
            this.multiLayoutItem2028,
            this.multiLayoutItem2029,
            this.multiLayoutItem2030,
            this.multiLayoutItem2031,
            this.multiLayoutItem2032,
            this.multiLayoutItem2033,
            this.multiLayoutItem2034,
            this.multiLayoutItem2035,
            this.multiLayoutItem2036,
            this.multiLayoutItem2037,
            this.multiLayoutItem2038,
            this.multiLayoutItem2039,
            this.multiLayoutItem2040,
            this.multiLayoutItem2041,
            this.multiLayoutItem2042,
            this.multiLayoutItem2043,
            this.multiLayoutItem2044,
            this.multiLayoutItem2045,
            this.multiLayoutItem2046,
            this.multiLayoutItem2047,
            this.multiLayoutItem2048,
            this.multiLayoutItem2049,
            this.multiLayoutItem2050,
            this.multiLayoutItem2051,
            this.multiLayoutItem2052,
            this.multiLayoutItem2053,
            this.multiLayoutItem2054,
            this.multiLayoutItem2055,
            this.multiLayoutItem2056,
            this.multiLayoutItem2057,
            this.multiLayoutItem2058,
            this.multiLayoutItem2059,
            this.multiLayoutItem2060,
            this.multiLayoutItem2061,
            this.multiLayoutItem2062,
            this.multiLayoutItem2063,
            this.multiLayoutItem2064,
            this.multiLayoutItem2065,
            this.multiLayoutItem2066,
            this.multiLayoutItem2067,
            this.multiLayoutItem2068,
            this.multiLayoutItem2069,
            this.multiLayoutItem2070,
            this.multiLayoutItem2071,
            this.multiLayoutItem2072,
            this.multiLayoutItem2073,
            this.multiLayoutItem2074,
            this.multiLayoutItem2075,
            this.multiLayoutItem2076,
            this.multiLayoutItem2077,
            this.multiLayoutItem2078,
            this.multiLayoutItem2079,
            this.multiLayoutItem2080,
            this.multiLayoutItem2081,
            this.multiLayoutItem2082,
            this.multiLayoutItem2083,
            this.multiLayoutItem2084,
            this.multiLayoutItem2085,
            this.multiLayoutItem2086,
            this.multiLayoutItem2087,
            this.multiLayoutItem2088,
            this.multiLayoutItem2089,
            this.multiLayoutItem2090,
            this.multiLayoutItem2091,
            this.multiLayoutItem2092,
            this.multiLayoutItem2093,
            this.multiLayoutItem2094,
            this.multiLayoutItem2095,
            this.multiLayoutItem2096,
            this.multiLayoutItem2097,
            this.multiLayoutItem2098,
            this.multiLayoutItem2099,
            this.multiLayoutItem2100,
            this.multiLayoutItem2101,
            this.multiLayoutItem2102,
            this.multiLayoutItem2103,
            this.multiLayoutItem2104,
            this.multiLayoutItem2105,
            this.multiLayoutItem2106,
            this.multiLayoutItem2107,
            this.multiLayoutItem2108,
            this.multiLayoutItem2109,
            this.multiLayoutItem2110,
            this.multiLayoutItem2111,
            this.multiLayoutItem2112,
            this.multiLayoutItem2113,
            this.multiLayoutItem2114,
            this.multiLayoutItem2115,
            this.multiLayoutItem2116,
            this.multiLayoutItem2117,
            this.multiLayoutItem2118,
            this.multiLayoutItem2119,
            this.multiLayoutItem2120,
            this.multiLayoutItem2121,
            this.multiLayoutItem2122,
            this.multiLayoutItem2123,
            this.multiLayoutItem3336});
            // 
            // multiLayoutItem1972
            // 
            this.multiLayoutItem1972.DataName = "in_out_key";
            this.multiLayoutItem1972.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem1972.IsUpdItem = true;
            // 
            // multiLayoutItem1973
            // 
            this.multiLayoutItem1973.DataName = "pkocskey";
            this.multiLayoutItem1973.IsUpdItem = true;
            // 
            // multiLayoutItem1974
            // 
            this.multiLayoutItem1974.DataName = "bunho";
            this.multiLayoutItem1974.IsUpdItem = true;
            // 
            // multiLayoutItem1975
            // 
            this.multiLayoutItem1975.DataName = "order_date";
            this.multiLayoutItem1975.IsUpdItem = true;
            // 
            // multiLayoutItem1976
            // 
            this.multiLayoutItem1976.DataName = "gwa";
            this.multiLayoutItem1976.IsUpdItem = true;
            // 
            // multiLayoutItem1977
            // 
            this.multiLayoutItem1977.DataName = "doctor";
            this.multiLayoutItem1977.IsUpdItem = true;
            // 
            // multiLayoutItem1978
            // 
            this.multiLayoutItem1978.DataName = "resident";
            this.multiLayoutItem1978.IsUpdItem = true;
            // 
            // multiLayoutItem1979
            // 
            this.multiLayoutItem1979.DataName = "naewon_type";
            this.multiLayoutItem1979.IsUpdItem = true;
            // 
            // multiLayoutItem1980
            // 
            this.multiLayoutItem1980.DataName = "jubsu_no";
            this.multiLayoutItem1980.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem1980.IsUpdItem = true;
            // 
            // multiLayoutItem1981
            // 
            this.multiLayoutItem1981.DataName = "input_id";
            this.multiLayoutItem1981.IsUpdItem = true;
            // 
            // multiLayoutItem1982
            // 
            this.multiLayoutItem1982.DataName = "input_part";
            this.multiLayoutItem1982.IsUpdItem = true;
            // 
            // multiLayoutItem1983
            // 
            this.multiLayoutItem1983.DataName = "input_gwa";
            this.multiLayoutItem1983.IsUpdItem = true;
            // 
            // multiLayoutItem1984
            // 
            this.multiLayoutItem1984.DataName = "input_doctor";
            this.multiLayoutItem1984.IsUpdItem = true;
            // 
            // multiLayoutItem1985
            // 
            this.multiLayoutItem1985.DataName = "input_gubun";
            this.multiLayoutItem1985.IsUpdItem = true;
            // 
            // multiLayoutItem1986
            // 
            this.multiLayoutItem1986.DataName = "input_gubun_name";
            // 
            // multiLayoutItem1987
            // 
            this.multiLayoutItem1987.DataName = "group_ser";
            this.multiLayoutItem1987.IsUpdItem = true;
            // 
            // multiLayoutItem1988
            // 
            this.multiLayoutItem1988.DataName = "input_tab";
            this.multiLayoutItem1988.IsUpdItem = true;
            // 
            // multiLayoutItem1989
            // 
            this.multiLayoutItem1989.DataName = "input_tab_name";
            // 
            // multiLayoutItem1990
            // 
            this.multiLayoutItem1990.DataName = "order_gubun";
            this.multiLayoutItem1990.IsUpdItem = true;
            // 
            // multiLayoutItem1991
            // 
            this.multiLayoutItem1991.DataName = "order_gubun_name";
            // 
            // multiLayoutItem1992
            // 
            this.multiLayoutItem1992.DataName = "group_yn";
            this.multiLayoutItem1992.IsUpdItem = true;
            // 
            // multiLayoutItem1993
            // 
            this.multiLayoutItem1993.DataName = "seq";
            this.multiLayoutItem1993.IsUpdItem = true;
            // 
            // multiLayoutItem1994
            // 
            this.multiLayoutItem1994.DataName = "slip_code";
            this.multiLayoutItem1994.IsUpdItem = true;
            // 
            // multiLayoutItem1995
            // 
            this.multiLayoutItem1995.DataName = "hangmog_code";
            this.multiLayoutItem1995.IsUpdItem = true;
            // 
            // multiLayoutItem1996
            // 
            this.multiLayoutItem1996.DataName = "hangmog_name";
            // 
            // multiLayoutItem1997
            // 
            this.multiLayoutItem1997.DataName = "specimen_code";
            this.multiLayoutItem1997.IsUpdItem = true;
            // 
            // multiLayoutItem1998
            // 
            this.multiLayoutItem1998.DataName = "specimen_name";
            // 
            // multiLayoutItem1999
            // 
            this.multiLayoutItem1999.DataName = "suryang";
            this.multiLayoutItem1999.IsUpdItem = true;
            // 
            // multiLayoutItem2000
            // 
            this.multiLayoutItem2000.DataName = "sunab_suryang";
            this.multiLayoutItem2000.IsUpdItem = true;
            // 
            // multiLayoutItem2001
            // 
            this.multiLayoutItem2001.DataName = "subul_suryang";
            this.multiLayoutItem2001.IsUpdItem = true;
            // 
            // multiLayoutItem2002
            // 
            this.multiLayoutItem2002.DataName = "ord_danui";
            this.multiLayoutItem2002.IsUpdItem = true;
            // 
            // multiLayoutItem2003
            // 
            this.multiLayoutItem2003.DataName = "ord_danui_name";
            // 
            // multiLayoutItem2004
            // 
            this.multiLayoutItem2004.DataName = "dv_time";
            this.multiLayoutItem2004.IsUpdItem = true;
            // 
            // multiLayoutItem2005
            // 
            this.multiLayoutItem2005.DataName = "dv";
            this.multiLayoutItem2005.IsUpdItem = true;
            // 
            // multiLayoutItem2006
            // 
            this.multiLayoutItem2006.DataName = "dv_1";
            this.multiLayoutItem2006.IsUpdItem = true;
            // 
            // multiLayoutItem2007
            // 
            this.multiLayoutItem2007.DataName = "dv_2";
            this.multiLayoutItem2007.IsUpdItem = true;
            // 
            // multiLayoutItem2008
            // 
            this.multiLayoutItem2008.DataName = "dv_3";
            this.multiLayoutItem2008.IsUpdItem = true;
            // 
            // multiLayoutItem2009
            // 
            this.multiLayoutItem2009.DataName = "dv_4";
            this.multiLayoutItem2009.IsUpdItem = true;
            // 
            // multiLayoutItem2010
            // 
            this.multiLayoutItem2010.DataName = "nalsu";
            this.multiLayoutItem2010.IsUpdItem = true;
            // 
            // multiLayoutItem2011
            // 
            this.multiLayoutItem2011.DataName = "sunab_nalsu";
            this.multiLayoutItem2011.IsUpdItem = true;
            // 
            // multiLayoutItem2012
            // 
            this.multiLayoutItem2012.DataName = "jusa";
            this.multiLayoutItem2012.IsUpdItem = true;
            // 
            // multiLayoutItem2013
            // 
            this.multiLayoutItem2013.DataName = "jusa_name";
            this.multiLayoutItem2013.IsUpdItem = true;
            // 
            // multiLayoutItem2014
            // 
            this.multiLayoutItem2014.DataName = "jusa_spd_gubun";
            this.multiLayoutItem2014.IsUpdItem = true;
            // 
            // multiLayoutItem2015
            // 
            this.multiLayoutItem2015.DataName = "bogyong_code";
            this.multiLayoutItem2015.IsUpdItem = true;
            // 
            // multiLayoutItem2016
            // 
            this.multiLayoutItem2016.DataName = "bogyong_name";
            this.multiLayoutItem2016.IsUpdItem = true;
            // 
            // multiLayoutItem2017
            // 
            this.multiLayoutItem2017.DataName = "emergency";
            this.multiLayoutItem2017.IsUpdItem = true;
            // 
            // multiLayoutItem2018
            // 
            this.multiLayoutItem2018.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem2018.IsUpdItem = true;
            // 
            // multiLayoutItem2019
            // 
            this.multiLayoutItem2019.DataName = "jundal_table";
            this.multiLayoutItem2019.IsUpdItem = true;
            // 
            // multiLayoutItem2020
            // 
            this.multiLayoutItem2020.DataName = "jundal_part";
            this.multiLayoutItem2020.IsUpdItem = true;
            // 
            // multiLayoutItem2021
            // 
            this.multiLayoutItem2021.DataName = "move_part";
            this.multiLayoutItem2021.IsUpdItem = true;
            // 
            // multiLayoutItem2022
            // 
            this.multiLayoutItem2022.DataName = "portable_yn";
            this.multiLayoutItem2022.IsUpdItem = true;
            // 
            // multiLayoutItem2023
            // 
            this.multiLayoutItem2023.DataName = "powder_yn";
            this.multiLayoutItem2023.IsUpdItem = true;
            // 
            // multiLayoutItem2024
            // 
            this.multiLayoutItem2024.DataName = "hubal_change_yn";
            this.multiLayoutItem2024.IsUpdItem = true;
            // 
            // multiLayoutItem2025
            // 
            this.multiLayoutItem2025.DataName = "pharmacy";
            this.multiLayoutItem2025.IsUpdItem = true;
            // 
            // multiLayoutItem2026
            // 
            this.multiLayoutItem2026.DataName = "drg_pack_yn";
            this.multiLayoutItem2026.IsUpdItem = true;
            // 
            // multiLayoutItem2027
            // 
            this.multiLayoutItem2027.DataName = "muhyo";
            this.multiLayoutItem2027.IsUpdItem = true;
            // 
            // multiLayoutItem2028
            // 
            this.multiLayoutItem2028.DataName = "prn_yn";
            this.multiLayoutItem2028.IsUpdItem = true;
            // 
            // multiLayoutItem2029
            // 
            this.multiLayoutItem2029.DataName = "toiwon_drg_yn";
            this.multiLayoutItem2029.IsUpdItem = true;
            // 
            // multiLayoutItem2030
            // 
            this.multiLayoutItem2030.DataName = "prn_nurse";
            this.multiLayoutItem2030.IsUpdItem = true;
            // 
            // multiLayoutItem2031
            // 
            this.multiLayoutItem2031.DataName = "append_yn";
            this.multiLayoutItem2031.IsUpdItem = true;
            // 
            // multiLayoutItem2032
            // 
            this.multiLayoutItem2032.DataName = "order_remark";
            this.multiLayoutItem2032.IsUpdItem = true;
            // 
            // multiLayoutItem2033
            // 
            this.multiLayoutItem2033.DataName = "nurse_remark";
            this.multiLayoutItem2033.IsUpdItem = true;
            // 
            // multiLayoutItem2034
            // 
            this.multiLayoutItem2034.DataName = "comment";
            this.multiLayoutItem2034.IsUpdItem = true;
            // 
            // multiLayoutItem2035
            // 
            this.multiLayoutItem2035.DataName = "mix_group";
            this.multiLayoutItem2035.IsUpdItem = true;
            // 
            // multiLayoutItem2036
            // 
            this.multiLayoutItem2036.DataName = "amt";
            this.multiLayoutItem2036.IsUpdItem = true;
            // 
            // multiLayoutItem2037
            // 
            this.multiLayoutItem2037.DataName = "pay";
            this.multiLayoutItem2037.IsUpdItem = true;
            // 
            // multiLayoutItem2038
            // 
            this.multiLayoutItem2038.DataName = "wonyoi_order_yn";
            this.multiLayoutItem2038.IsUpdItem = true;
            // 
            // multiLayoutItem2039
            // 
            this.multiLayoutItem2039.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem2039.IsUpdItem = true;
            // 
            // multiLayoutItem2040
            // 
            this.multiLayoutItem2040.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem2040.IsUpdItem = true;
            // 
            // multiLayoutItem2041
            // 
            this.multiLayoutItem2041.DataName = "bom_occur_yn";
            this.multiLayoutItem2041.IsUpdItem = true;
            // 
            // multiLayoutItem2042
            // 
            this.multiLayoutItem2042.DataName = "bom_source_key";
            this.multiLayoutItem2042.IsUpdItem = true;
            // 
            // multiLayoutItem2043
            // 
            this.multiLayoutItem2043.DataName = "display_yn";
            this.multiLayoutItem2043.IsUpdItem = true;
            // 
            // multiLayoutItem2044
            // 
            this.multiLayoutItem2044.DataName = "sunab_yn";
            this.multiLayoutItem2044.IsUpdItem = true;
            // 
            // multiLayoutItem2045
            // 
            this.multiLayoutItem2045.DataName = "sunab_date";
            this.multiLayoutItem2045.IsUpdItem = true;
            // 
            // multiLayoutItem2046
            // 
            this.multiLayoutItem2046.DataName = "sunab_time";
            this.multiLayoutItem2046.IsUpdItem = true;
            // 
            // multiLayoutItem2047
            // 
            this.multiLayoutItem2047.DataName = "hope_date";
            this.multiLayoutItem2047.IsUpdItem = true;
            // 
            // multiLayoutItem2048
            // 
            this.multiLayoutItem2048.DataName = "hope_time";
            this.multiLayoutItem2048.IsUpdItem = true;
            // 
            // multiLayoutItem2049
            // 
            this.multiLayoutItem2049.DataName = "nurse_confirm_user";
            this.multiLayoutItem2049.IsUpdItem = true;
            // 
            // multiLayoutItem2050
            // 
            this.multiLayoutItem2050.DataName = "nurse_confirm_date";
            this.multiLayoutItem2050.IsUpdItem = true;
            // 
            // multiLayoutItem2051
            // 
            this.multiLayoutItem2051.DataName = "nurse_confirm_time";
            this.multiLayoutItem2051.IsUpdItem = true;
            // 
            // multiLayoutItem2052
            // 
            this.multiLayoutItem2052.DataName = "nurse_pickup_user";
            this.multiLayoutItem2052.IsUpdItem = true;
            // 
            // multiLayoutItem2053
            // 
            this.multiLayoutItem2053.DataName = "nurse_pickup_date";
            this.multiLayoutItem2053.IsUpdItem = true;
            // 
            // multiLayoutItem2054
            // 
            this.multiLayoutItem2054.DataName = "nurse_pickup_time";
            this.multiLayoutItem2054.IsUpdItem = true;
            // 
            // multiLayoutItem2055
            // 
            this.multiLayoutItem2055.DataName = "nurse_hold_user";
            this.multiLayoutItem2055.IsUpdItem = true;
            // 
            // multiLayoutItem2056
            // 
            this.multiLayoutItem2056.DataName = "nurse_hold_date";
            this.multiLayoutItem2056.IsUpdItem = true;
            // 
            // multiLayoutItem2057
            // 
            this.multiLayoutItem2057.DataName = "nurse_hold_time";
            this.multiLayoutItem2057.IsUpdItem = true;
            // 
            // multiLayoutItem2058
            // 
            this.multiLayoutItem2058.DataName = "reser_date";
            this.multiLayoutItem2058.IsUpdItem = true;
            // 
            // multiLayoutItem2059
            // 
            this.multiLayoutItem2059.DataName = "reser_time";
            this.multiLayoutItem2059.IsUpdItem = true;
            // 
            // multiLayoutItem2060
            // 
            this.multiLayoutItem2060.DataName = "jubsu_date";
            this.multiLayoutItem2060.IsUpdItem = true;
            // 
            // multiLayoutItem2061
            // 
            this.multiLayoutItem2061.DataName = "jubsu_time";
            this.multiLayoutItem2061.IsUpdItem = true;
            // 
            // multiLayoutItem2062
            // 
            this.multiLayoutItem2062.DataName = "acting_date";
            this.multiLayoutItem2062.IsUpdItem = true;
            // 
            // multiLayoutItem2063
            // 
            this.multiLayoutItem2063.DataName = "acting_time";
            this.multiLayoutItem2063.IsUpdItem = true;
            // 
            // multiLayoutItem2064
            // 
            this.multiLayoutItem2064.DataName = "acting_day";
            this.multiLayoutItem2064.IsUpdItem = true;
            // 
            // multiLayoutItem2065
            // 
            this.multiLayoutItem2065.DataName = "result_date";
            this.multiLayoutItem2065.IsUpdItem = true;
            // 
            // multiLayoutItem2066
            // 
            this.multiLayoutItem2066.DataName = "dc_gubun";
            this.multiLayoutItem2066.IsUpdItem = true;
            // 
            // multiLayoutItem2067
            // 
            this.multiLayoutItem2067.DataName = "dc_yn";
            this.multiLayoutItem2067.IsUpdItem = true;
            // 
            // multiLayoutItem2068
            // 
            this.multiLayoutItem2068.DataName = "bannab_yn";
            this.multiLayoutItem2068.IsUpdItem = true;
            // 
            // multiLayoutItem2069
            // 
            this.multiLayoutItem2069.DataName = "bannab_confirm";
            this.multiLayoutItem2069.IsUpdItem = true;
            // 
            // multiLayoutItem2070
            // 
            this.multiLayoutItem2070.DataName = "source_ord_key";
            this.multiLayoutItem2070.IsUpdItem = true;
            // 
            // multiLayoutItem2071
            // 
            this.multiLayoutItem2071.DataName = "ocs_flag";
            this.multiLayoutItem2071.IsUpdItem = true;
            // 
            // multiLayoutItem2072
            // 
            this.multiLayoutItem2072.DataName = "sg_code";
            this.multiLayoutItem2072.IsUpdItem = true;
            // 
            // multiLayoutItem2073
            // 
            this.multiLayoutItem2073.DataName = "sg_ymd";
            this.multiLayoutItem2073.IsUpdItem = true;
            // 
            // multiLayoutItem2074
            // 
            this.multiLayoutItem2074.DataName = "io_gubun";
            this.multiLayoutItem2074.IsUpdItem = true;
            // 
            // multiLayoutItem2075
            // 
            this.multiLayoutItem2075.DataName = "after_act_yn";
            this.multiLayoutItem2075.IsUpdItem = true;
            // 
            // multiLayoutItem2076
            // 
            this.multiLayoutItem2076.DataName = "bichi_yn";
            this.multiLayoutItem2076.IsUpdItem = true;
            // 
            // multiLayoutItem2077
            // 
            this.multiLayoutItem2077.DataName = "drg_bunho";
            this.multiLayoutItem2077.IsUpdItem = true;
            // 
            // multiLayoutItem2078
            // 
            this.multiLayoutItem2078.DataName = "sub_susul";
            this.multiLayoutItem2078.IsUpdItem = true;
            // 
            // multiLayoutItem2079
            // 
            this.multiLayoutItem2079.DataName = "print_yn";
            this.multiLayoutItem2079.IsUpdItem = true;
            // 
            // multiLayoutItem2080
            // 
            this.multiLayoutItem2080.DataName = "chisik";
            this.multiLayoutItem2080.IsUpdItem = true;
            // 
            // multiLayoutItem2081
            // 
            this.multiLayoutItem2081.DataName = "tel_yn";
            this.multiLayoutItem2081.IsUpdItem = true;
            // 
            // multiLayoutItem2082
            // 
            this.multiLayoutItem2082.DataName = "order_gubun_bas";
            this.multiLayoutItem2082.IsUpdItem = true;
            // 
            // multiLayoutItem2083
            // 
            this.multiLayoutItem2083.DataName = "input_control";
            this.multiLayoutItem2083.IsUpdItem = true;
            // 
            // multiLayoutItem2084
            // 
            this.multiLayoutItem2084.DataName = "suga_yn";
            this.multiLayoutItem2084.IsUpdItem = true;
            // 
            // multiLayoutItem2085
            // 
            this.multiLayoutItem2085.DataName = "jaeryo_yn";
            this.multiLayoutItem2085.IsUpdItem = true;
            // 
            // multiLayoutItem2086
            // 
            this.multiLayoutItem2086.DataName = "wonyoi_check";
            this.multiLayoutItem2086.IsUpdItem = true;
            // 
            // multiLayoutItem2087
            // 
            this.multiLayoutItem2087.DataName = "emergency_check";
            this.multiLayoutItem2087.IsUpdItem = true;
            // 
            // multiLayoutItem2088
            // 
            this.multiLayoutItem2088.DataName = "specimen_check";
            // 
            // multiLayoutItem2089
            // 
            this.multiLayoutItem2089.DataName = "portable_check";
            this.multiLayoutItem2089.IsUpdItem = true;
            // 
            // multiLayoutItem2090
            // 
            this.multiLayoutItem2090.DataName = "bulyong_check";
            this.multiLayoutItem2090.IsUpdItem = true;
            // 
            // multiLayoutItem2091
            // 
            this.multiLayoutItem2091.DataName = "sunab_check";
            // 
            // multiLayoutItem2092
            // 
            this.multiLayoutItem2092.DataName = "dc_check";
            // 
            // multiLayoutItem2093
            // 
            this.multiLayoutItem2093.DataName = "dc_gubun_check";
            this.multiLayoutItem2093.IsUpdItem = true;
            // 
            // multiLayoutItem2094
            // 
            this.multiLayoutItem2094.DataName = "confirm_check";
            this.multiLayoutItem2094.IsUpdItem = true;
            // 
            // multiLayoutItem2095
            // 
            this.multiLayoutItem2095.DataName = "reser_yn_check";
            this.multiLayoutItem2095.IsUpdItem = true;
            // 
            // multiLayoutItem2096
            // 
            this.multiLayoutItem2096.DataName = "chisik_check";
            this.multiLayoutItem2096.IsUpdItem = true;
            // 
            // multiLayoutItem2097
            // 
            this.multiLayoutItem2097.DataName = "nday_yn";
            this.multiLayoutItem2097.IsUpdItem = true;
            // 
            // multiLayoutItem2098
            // 
            this.multiLayoutItem2098.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem2098.IsUpdItem = true;
            // 
            // multiLayoutItem2099
            // 
            this.multiLayoutItem2099.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem2099.IsUpdItem = true;
            // 
            // multiLayoutItem2100
            // 
            this.multiLayoutItem2100.DataName = "specific_comment";
            this.multiLayoutItem2100.IsUpdItem = true;
            // 
            // multiLayoutItem2101
            // 
            this.multiLayoutItem2101.DataName = "specific_comment_name";
            this.multiLayoutItem2101.IsUpdItem = true;
            // 
            // multiLayoutItem2102
            // 
            this.multiLayoutItem2102.DataName = "specific_comment_sys_id";
            this.multiLayoutItem2102.IsUpdItem = true;
            // 
            // multiLayoutItem2103
            // 
            this.multiLayoutItem2103.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem2103.IsUpdItem = true;
            // 
            // multiLayoutItem2104
            // 
            this.multiLayoutItem2104.DataName = "specific_comment_not_null";
            this.multiLayoutItem2104.IsUpdItem = true;
            // 
            // multiLayoutItem2105
            // 
            this.multiLayoutItem2105.DataName = "specific_comment_table_id";
            this.multiLayoutItem2105.IsUpdItem = true;
            // 
            // multiLayoutItem2106
            // 
            this.multiLayoutItem2106.DataName = "specific_comment_col_id";
            this.multiLayoutItem2106.IsUpdItem = true;
            // 
            // multiLayoutItem2107
            // 
            this.multiLayoutItem2107.DataName = "donbog_yn";
            this.multiLayoutItem2107.IsUpdItem = true;
            // 
            // multiLayoutItem2108
            // 
            this.multiLayoutItem2108.DataName = "order_gubun_bas_name";
            this.multiLayoutItem2108.IsUpdItem = true;
            // 
            // multiLayoutItem2109
            // 
            this.multiLayoutItem2109.DataName = "act_doctoor";
            this.multiLayoutItem2109.IsUpdItem = true;
            // 
            // multiLayoutItem2110
            // 
            this.multiLayoutItem2110.DataName = "act_buseo";
            this.multiLayoutItem2110.IsUpdItem = true;
            // 
            // multiLayoutItem2111
            // 
            this.multiLayoutItem2111.DataName = "act_gwa";
            this.multiLayoutItem2111.IsUpdItem = true;
            // 
            // multiLayoutItem2112
            // 
            this.multiLayoutItem2112.DataName = "home_care_yn";
            this.multiLayoutItem2112.IsUpdItem = true;
            // 
            // multiLayoutItem2113
            // 
            this.multiLayoutItem2113.DataName = "regular_yn";
            this.multiLayoutItem2113.IsUpdItem = true;
            // 
            // multiLayoutItem2114
            // 
            this.multiLayoutItem2114.DataName = "sort_fkocskey";
            this.multiLayoutItem2114.IsUpdItem = true;
            // 
            // multiLayoutItem2115
            // 
            this.multiLayoutItem2115.DataName = "child_yn";
            this.multiLayoutItem2115.IsUpdItem = true;
            // 
            // multiLayoutItem2116
            // 
            this.multiLayoutItem2116.DataName = "child_exist_yn";
            this.multiLayoutItem2116.IsUpdItem = true;
            // 
            // multiLayoutItem2117
            // 
            this.multiLayoutItem2117.DataName = "nday_occur_yn";
            this.multiLayoutItem2117.IsUpdItem = true;
            // 
            // multiLayoutItem2118
            // 
            this.multiLayoutItem2118.DataName = "bun_code";
            // 
            // multiLayoutItem2119
            // 
            this.multiLayoutItem2119.DataName = "wonnae_drg_yn";
            // 
            // multiLayoutItem2120
            // 
            this.multiLayoutItem2120.DataName = "hubal_change_check";
            // 
            // multiLayoutItem2121
            // 
            this.multiLayoutItem2121.DataName = "drg_pack_check";
            // 
            // multiLayoutItem2122
            // 
            this.multiLayoutItem2122.DataName = "pharmacy_check";
            // 
            // multiLayoutItem2123
            // 
            this.multiLayoutItem2123.DataName = "powder_check";
            // 
            // multiLayoutItem3336
            // 
            this.multiLayoutItem3336.DataName = "if_input_control";
            // 
            // layPfeOrder
            // 
            this.layPfeOrder.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem726,
            this.multiLayoutItem727,
            this.multiLayoutItem728,
            this.multiLayoutItem729,
            this.multiLayoutItem730,
            this.multiLayoutItem731,
            this.multiLayoutItem732,
            this.multiLayoutItem733,
            this.multiLayoutItem734,
            this.multiLayoutItem735,
            this.multiLayoutItem736,
            this.multiLayoutItem737,
            this.multiLayoutItem738,
            this.multiLayoutItem739,
            this.multiLayoutItem740,
            this.multiLayoutItem741,
            this.multiLayoutItem742,
            this.multiLayoutItem743,
            this.multiLayoutItem744,
            this.multiLayoutItem745,
            this.multiLayoutItem746,
            this.multiLayoutItem747,
            this.multiLayoutItem748,
            this.multiLayoutItem749,
            this.multiLayoutItem750,
            this.multiLayoutItem751,
            this.multiLayoutItem752,
            this.multiLayoutItem753,
            this.multiLayoutItem754,
            this.multiLayoutItem755,
            this.multiLayoutItem756,
            this.multiLayoutItem757,
            this.multiLayoutItem758,
            this.multiLayoutItem759,
            this.multiLayoutItem760,
            this.multiLayoutItem761,
            this.multiLayoutItem762,
            this.multiLayoutItem763,
            this.multiLayoutItem764,
            this.multiLayoutItem765,
            this.multiLayoutItem766,
            this.multiLayoutItem767,
            this.multiLayoutItem768,
            this.multiLayoutItem769,
            this.multiLayoutItem770,
            this.multiLayoutItem771,
            this.multiLayoutItem772,
            this.multiLayoutItem773,
            this.multiLayoutItem774,
            this.multiLayoutItem775,
            this.multiLayoutItem776,
            this.multiLayoutItem777,
            this.multiLayoutItem778,
            this.multiLayoutItem779,
            this.multiLayoutItem780,
            this.multiLayoutItem781,
            this.multiLayoutItem782,
            this.multiLayoutItem783,
            this.multiLayoutItem784,
            this.multiLayoutItem785,
            this.multiLayoutItem786,
            this.multiLayoutItem787,
            this.multiLayoutItem788,
            this.multiLayoutItem789,
            this.multiLayoutItem790,
            this.multiLayoutItem791,
            this.multiLayoutItem792,
            this.multiLayoutItem793,
            this.multiLayoutItem794,
            this.multiLayoutItem795,
            this.multiLayoutItem796,
            this.multiLayoutItem797,
            this.multiLayoutItem798,
            this.multiLayoutItem799,
            this.multiLayoutItem800,
            this.multiLayoutItem801,
            this.multiLayoutItem802,
            this.multiLayoutItem803,
            this.multiLayoutItem804,
            this.multiLayoutItem805,
            this.multiLayoutItem806,
            this.multiLayoutItem807,
            this.multiLayoutItem808,
            this.multiLayoutItem809,
            this.multiLayoutItem810,
            this.multiLayoutItem811,
            this.multiLayoutItem812,
            this.multiLayoutItem813,
            this.multiLayoutItem814,
            this.multiLayoutItem815,
            this.multiLayoutItem816,
            this.multiLayoutItem817,
            this.multiLayoutItem818,
            this.multiLayoutItem819,
            this.multiLayoutItem820,
            this.multiLayoutItem821,
            this.multiLayoutItem822,
            this.multiLayoutItem823,
            this.multiLayoutItem824,
            this.multiLayoutItem825,
            this.multiLayoutItem826,
            this.multiLayoutItem827,
            this.multiLayoutItem828,
            this.multiLayoutItem829,
            this.multiLayoutItem830,
            this.multiLayoutItem831,
            this.multiLayoutItem832,
            this.multiLayoutItem833,
            this.multiLayoutItem834,
            this.multiLayoutItem835,
            this.multiLayoutItem836,
            this.multiLayoutItem837,
            this.multiLayoutItem838,
            this.multiLayoutItem839,
            this.multiLayoutItem840,
            this.multiLayoutItem841,
            this.multiLayoutItem842,
            this.multiLayoutItem843,
            this.multiLayoutItem844,
            this.multiLayoutItem845,
            this.multiLayoutItem846,
            this.multiLayoutItem847,
            this.multiLayoutItem848,
            this.multiLayoutItem849,
            this.multiLayoutItem850,
            this.multiLayoutItem851,
            this.multiLayoutItem852,
            this.multiLayoutItem853,
            this.multiLayoutItem854,
            this.multiLayoutItem855,
            this.multiLayoutItem856,
            this.multiLayoutItem857,
            this.multiLayoutItem858,
            this.multiLayoutItem859,
            this.multiLayoutItem860,
            this.multiLayoutItem861,
            this.multiLayoutItem862,
            this.multiLayoutItem863,
            this.multiLayoutItem864,
            this.multiLayoutItem865,
            this.multiLayoutItem866,
            this.multiLayoutItem867,
            this.multiLayoutItem868,
            this.multiLayoutItem1026,
            this.multiLayoutItem1027,
            this.multiLayoutItem1028,
            this.multiLayoutItem1032,
            this.multiLayoutItem1932,
            this.multiLayoutItem1948,
            this.multiLayoutItem1949});
            // 
            // multiLayoutItem726
            // 
            this.multiLayoutItem726.DataName = "in_out_key";
            this.multiLayoutItem726.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem726.IsUpdItem = true;
            // 
            // multiLayoutItem727
            // 
            this.multiLayoutItem727.DataName = "pkocskey";
            this.multiLayoutItem727.IsUpdItem = true;
            // 
            // multiLayoutItem728
            // 
            this.multiLayoutItem728.DataName = "bunho";
            this.multiLayoutItem728.IsUpdItem = true;
            // 
            // multiLayoutItem729
            // 
            this.multiLayoutItem729.DataName = "order_date";
            this.multiLayoutItem729.IsUpdItem = true;
            // 
            // multiLayoutItem730
            // 
            this.multiLayoutItem730.DataName = "gwa";
            this.multiLayoutItem730.IsUpdItem = true;
            // 
            // multiLayoutItem731
            // 
            this.multiLayoutItem731.DataName = "doctor";
            this.multiLayoutItem731.IsUpdItem = true;
            // 
            // multiLayoutItem732
            // 
            this.multiLayoutItem732.DataName = "resident";
            this.multiLayoutItem732.IsUpdItem = true;
            // 
            // multiLayoutItem733
            // 
            this.multiLayoutItem733.DataName = "naewon_type";
            this.multiLayoutItem733.IsUpdItem = true;
            // 
            // multiLayoutItem734
            // 
            this.multiLayoutItem734.DataName = "jubsu_no";
            this.multiLayoutItem734.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem734.IsUpdItem = true;
            // 
            // multiLayoutItem735
            // 
            this.multiLayoutItem735.DataName = "input_id";
            this.multiLayoutItem735.IsUpdItem = true;
            // 
            // multiLayoutItem736
            // 
            this.multiLayoutItem736.DataName = "input_part";
            this.multiLayoutItem736.IsUpdItem = true;
            // 
            // multiLayoutItem737
            // 
            this.multiLayoutItem737.DataName = "input_gwa";
            this.multiLayoutItem737.IsUpdItem = true;
            // 
            // multiLayoutItem738
            // 
            this.multiLayoutItem738.DataName = "input_doctor";
            this.multiLayoutItem738.IsUpdItem = true;
            // 
            // multiLayoutItem739
            // 
            this.multiLayoutItem739.DataName = "input_gubun";
            this.multiLayoutItem739.IsUpdItem = true;
            // 
            // multiLayoutItem740
            // 
            this.multiLayoutItem740.DataName = "input_gubun_name";
            // 
            // multiLayoutItem741
            // 
            this.multiLayoutItem741.DataName = "group_ser";
            this.multiLayoutItem741.IsUpdItem = true;
            // 
            // multiLayoutItem742
            // 
            this.multiLayoutItem742.DataName = "input_tab";
            this.multiLayoutItem742.IsUpdItem = true;
            // 
            // multiLayoutItem743
            // 
            this.multiLayoutItem743.DataName = "input_tab_name";
            // 
            // multiLayoutItem744
            // 
            this.multiLayoutItem744.DataName = "order_gubun";
            this.multiLayoutItem744.IsUpdItem = true;
            // 
            // multiLayoutItem745
            // 
            this.multiLayoutItem745.DataName = "order_gubun_name";
            // 
            // multiLayoutItem746
            // 
            this.multiLayoutItem746.DataName = "group_yn";
            this.multiLayoutItem746.IsUpdItem = true;
            // 
            // multiLayoutItem747
            // 
            this.multiLayoutItem747.DataName = "seq";
            this.multiLayoutItem747.IsUpdItem = true;
            // 
            // multiLayoutItem748
            // 
            this.multiLayoutItem748.DataName = "slip_code";
            this.multiLayoutItem748.IsUpdItem = true;
            // 
            // multiLayoutItem749
            // 
            this.multiLayoutItem749.DataName = "hangmog_code";
            this.multiLayoutItem749.IsUpdItem = true;
            // 
            // multiLayoutItem750
            // 
            this.multiLayoutItem750.DataName = "hangmog_name";
            // 
            // multiLayoutItem751
            // 
            this.multiLayoutItem751.DataName = "specimen_code";
            this.multiLayoutItem751.IsUpdItem = true;
            // 
            // multiLayoutItem752
            // 
            this.multiLayoutItem752.DataName = "specimen_name";
            // 
            // multiLayoutItem753
            // 
            this.multiLayoutItem753.DataName = "suryang";
            this.multiLayoutItem753.IsUpdItem = true;
            // 
            // multiLayoutItem754
            // 
            this.multiLayoutItem754.DataName = "sunab_suryang";
            this.multiLayoutItem754.IsUpdItem = true;
            // 
            // multiLayoutItem755
            // 
            this.multiLayoutItem755.DataName = "subul_suryang";
            this.multiLayoutItem755.IsUpdItem = true;
            // 
            // multiLayoutItem756
            // 
            this.multiLayoutItem756.DataName = "ord_danui";
            this.multiLayoutItem756.IsUpdItem = true;
            // 
            // multiLayoutItem757
            // 
            this.multiLayoutItem757.DataName = "ord_danui_name";
            // 
            // multiLayoutItem758
            // 
            this.multiLayoutItem758.DataName = "dv_time";
            this.multiLayoutItem758.IsUpdItem = true;
            // 
            // multiLayoutItem759
            // 
            this.multiLayoutItem759.DataName = "dv";
            this.multiLayoutItem759.IsUpdItem = true;
            // 
            // multiLayoutItem760
            // 
            this.multiLayoutItem760.DataName = "dv_1";
            this.multiLayoutItem760.IsUpdItem = true;
            // 
            // multiLayoutItem761
            // 
            this.multiLayoutItem761.DataName = "dv_2";
            this.multiLayoutItem761.IsUpdItem = true;
            // 
            // multiLayoutItem762
            // 
            this.multiLayoutItem762.DataName = "dv_3";
            this.multiLayoutItem762.IsUpdItem = true;
            // 
            // multiLayoutItem763
            // 
            this.multiLayoutItem763.DataName = "dv_4";
            this.multiLayoutItem763.IsUpdItem = true;
            // 
            // multiLayoutItem764
            // 
            this.multiLayoutItem764.DataName = "nalsu";
            this.multiLayoutItem764.IsUpdItem = true;
            // 
            // multiLayoutItem765
            // 
            this.multiLayoutItem765.DataName = "sunab_nalsu";
            this.multiLayoutItem765.IsUpdItem = true;
            // 
            // multiLayoutItem766
            // 
            this.multiLayoutItem766.DataName = "jusa";
            this.multiLayoutItem766.IsUpdItem = true;
            // 
            // multiLayoutItem767
            // 
            this.multiLayoutItem767.DataName = "jusa_name";
            this.multiLayoutItem767.IsUpdItem = true;
            // 
            // multiLayoutItem768
            // 
            this.multiLayoutItem768.DataName = "jusa_spd_gubun";
            this.multiLayoutItem768.IsUpdItem = true;
            // 
            // multiLayoutItem769
            // 
            this.multiLayoutItem769.DataName = "bogyong_code";
            this.multiLayoutItem769.IsUpdItem = true;
            // 
            // multiLayoutItem770
            // 
            this.multiLayoutItem770.DataName = "bogyong_name";
            this.multiLayoutItem770.IsUpdItem = true;
            // 
            // multiLayoutItem771
            // 
            this.multiLayoutItem771.DataName = "emergency";
            this.multiLayoutItem771.IsUpdItem = true;
            // 
            // multiLayoutItem772
            // 
            this.multiLayoutItem772.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem772.IsUpdItem = true;
            // 
            // multiLayoutItem773
            // 
            this.multiLayoutItem773.DataName = "jundal_table";
            this.multiLayoutItem773.IsUpdItem = true;
            // 
            // multiLayoutItem774
            // 
            this.multiLayoutItem774.DataName = "jundal_part";
            this.multiLayoutItem774.IsUpdItem = true;
            // 
            // multiLayoutItem775
            // 
            this.multiLayoutItem775.DataName = "move_part";
            this.multiLayoutItem775.IsUpdItem = true;
            // 
            // multiLayoutItem776
            // 
            this.multiLayoutItem776.DataName = "portable_yn";
            this.multiLayoutItem776.IsUpdItem = true;
            // 
            // multiLayoutItem777
            // 
            this.multiLayoutItem777.DataName = "powder_yn";
            this.multiLayoutItem777.IsUpdItem = true;
            // 
            // multiLayoutItem778
            // 
            this.multiLayoutItem778.DataName = "hubal_change_yn";
            this.multiLayoutItem778.IsUpdItem = true;
            // 
            // multiLayoutItem779
            // 
            this.multiLayoutItem779.DataName = "pharmacy";
            this.multiLayoutItem779.IsUpdItem = true;
            // 
            // multiLayoutItem780
            // 
            this.multiLayoutItem780.DataName = "drg_pack_yn";
            this.multiLayoutItem780.IsUpdItem = true;
            // 
            // multiLayoutItem781
            // 
            this.multiLayoutItem781.DataName = "muhyo";
            this.multiLayoutItem781.IsUpdItem = true;
            // 
            // multiLayoutItem782
            // 
            this.multiLayoutItem782.DataName = "prn_yn";
            this.multiLayoutItem782.IsUpdItem = true;
            // 
            // multiLayoutItem783
            // 
            this.multiLayoutItem783.DataName = "toiwon_drg_yn";
            this.multiLayoutItem783.IsUpdItem = true;
            // 
            // multiLayoutItem784
            // 
            this.multiLayoutItem784.DataName = "prn_nurse";
            this.multiLayoutItem784.IsUpdItem = true;
            // 
            // multiLayoutItem785
            // 
            this.multiLayoutItem785.DataName = "append_yn";
            this.multiLayoutItem785.IsUpdItem = true;
            // 
            // multiLayoutItem786
            // 
            this.multiLayoutItem786.DataName = "order_remark";
            this.multiLayoutItem786.IsUpdItem = true;
            // 
            // multiLayoutItem787
            // 
            this.multiLayoutItem787.DataName = "nurse_remark";
            this.multiLayoutItem787.IsUpdItem = true;
            // 
            // multiLayoutItem788
            // 
            this.multiLayoutItem788.DataName = "comment";
            this.multiLayoutItem788.IsUpdItem = true;
            // 
            // multiLayoutItem789
            // 
            this.multiLayoutItem789.DataName = "mix_group";
            this.multiLayoutItem789.IsUpdItem = true;
            // 
            // multiLayoutItem790
            // 
            this.multiLayoutItem790.DataName = "amt";
            this.multiLayoutItem790.IsUpdItem = true;
            // 
            // multiLayoutItem791
            // 
            this.multiLayoutItem791.DataName = "pay";
            this.multiLayoutItem791.IsUpdItem = true;
            // 
            // multiLayoutItem792
            // 
            this.multiLayoutItem792.DataName = "wonyoi_order_yn";
            this.multiLayoutItem792.IsUpdItem = true;
            // 
            // multiLayoutItem793
            // 
            this.multiLayoutItem793.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem793.IsUpdItem = true;
            // 
            // multiLayoutItem794
            // 
            this.multiLayoutItem794.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem794.IsUpdItem = true;
            // 
            // multiLayoutItem795
            // 
            this.multiLayoutItem795.DataName = "bom_occur_yn";
            this.multiLayoutItem795.IsUpdItem = true;
            // 
            // multiLayoutItem796
            // 
            this.multiLayoutItem796.DataName = "bom_source_key";
            this.multiLayoutItem796.IsUpdItem = true;
            // 
            // multiLayoutItem797
            // 
            this.multiLayoutItem797.DataName = "display_yn";
            this.multiLayoutItem797.IsUpdItem = true;
            // 
            // multiLayoutItem798
            // 
            this.multiLayoutItem798.DataName = "sunab_yn";
            this.multiLayoutItem798.IsUpdItem = true;
            // 
            // multiLayoutItem799
            // 
            this.multiLayoutItem799.DataName = "sunab_date";
            this.multiLayoutItem799.IsUpdItem = true;
            // 
            // multiLayoutItem800
            // 
            this.multiLayoutItem800.DataName = "sunab_time";
            this.multiLayoutItem800.IsUpdItem = true;
            // 
            // multiLayoutItem801
            // 
            this.multiLayoutItem801.DataName = "hope_date";
            this.multiLayoutItem801.IsUpdItem = true;
            // 
            // multiLayoutItem802
            // 
            this.multiLayoutItem802.DataName = "hope_time";
            this.multiLayoutItem802.IsUpdItem = true;
            // 
            // multiLayoutItem803
            // 
            this.multiLayoutItem803.DataName = "nurse_confirm_user";
            this.multiLayoutItem803.IsUpdItem = true;
            // 
            // multiLayoutItem804
            // 
            this.multiLayoutItem804.DataName = "nurse_confirm_date";
            this.multiLayoutItem804.IsUpdItem = true;
            // 
            // multiLayoutItem805
            // 
            this.multiLayoutItem805.DataName = "nurse_confirm_time";
            this.multiLayoutItem805.IsUpdItem = true;
            // 
            // multiLayoutItem806
            // 
            this.multiLayoutItem806.DataName = "nurse_pickup_user";
            this.multiLayoutItem806.IsUpdItem = true;
            // 
            // multiLayoutItem807
            // 
            this.multiLayoutItem807.DataName = "nurse_pickup_date";
            this.multiLayoutItem807.IsUpdItem = true;
            // 
            // multiLayoutItem808
            // 
            this.multiLayoutItem808.DataName = "nurse_pickup_time";
            this.multiLayoutItem808.IsUpdItem = true;
            // 
            // multiLayoutItem809
            // 
            this.multiLayoutItem809.DataName = "nurse_hold_user";
            this.multiLayoutItem809.IsUpdItem = true;
            // 
            // multiLayoutItem810
            // 
            this.multiLayoutItem810.DataName = "nurse_hold_date";
            this.multiLayoutItem810.IsUpdItem = true;
            // 
            // multiLayoutItem811
            // 
            this.multiLayoutItem811.DataName = "nurse_hold_time";
            this.multiLayoutItem811.IsUpdItem = true;
            // 
            // multiLayoutItem812
            // 
            this.multiLayoutItem812.DataName = "reser_date";
            this.multiLayoutItem812.IsUpdItem = true;
            // 
            // multiLayoutItem813
            // 
            this.multiLayoutItem813.DataName = "reser_time";
            this.multiLayoutItem813.IsUpdItem = true;
            // 
            // multiLayoutItem814
            // 
            this.multiLayoutItem814.DataName = "jubsu_date";
            this.multiLayoutItem814.IsUpdItem = true;
            // 
            // multiLayoutItem815
            // 
            this.multiLayoutItem815.DataName = "jubsu_time";
            this.multiLayoutItem815.IsUpdItem = true;
            // 
            // multiLayoutItem816
            // 
            this.multiLayoutItem816.DataName = "acting_date";
            this.multiLayoutItem816.IsUpdItem = true;
            // 
            // multiLayoutItem817
            // 
            this.multiLayoutItem817.DataName = "acting_time";
            this.multiLayoutItem817.IsUpdItem = true;
            // 
            // multiLayoutItem818
            // 
            this.multiLayoutItem818.DataName = "acting_day";
            this.multiLayoutItem818.IsUpdItem = true;
            // 
            // multiLayoutItem819
            // 
            this.multiLayoutItem819.DataName = "result_date";
            this.multiLayoutItem819.IsUpdItem = true;
            // 
            // multiLayoutItem820
            // 
            this.multiLayoutItem820.DataName = "dc_gubun";
            this.multiLayoutItem820.IsUpdItem = true;
            // 
            // multiLayoutItem821
            // 
            this.multiLayoutItem821.DataName = "dc_yn";
            this.multiLayoutItem821.IsUpdItem = true;
            // 
            // multiLayoutItem822
            // 
            this.multiLayoutItem822.DataName = "bannab_yn";
            this.multiLayoutItem822.IsUpdItem = true;
            // 
            // multiLayoutItem823
            // 
            this.multiLayoutItem823.DataName = "bannab_confirm";
            this.multiLayoutItem823.IsUpdItem = true;
            // 
            // multiLayoutItem824
            // 
            this.multiLayoutItem824.DataName = "source_ord_key";
            this.multiLayoutItem824.IsUpdItem = true;
            // 
            // multiLayoutItem825
            // 
            this.multiLayoutItem825.DataName = "ocs_flag";
            this.multiLayoutItem825.IsUpdItem = true;
            // 
            // multiLayoutItem826
            // 
            this.multiLayoutItem826.DataName = "sg_code";
            this.multiLayoutItem826.IsUpdItem = true;
            // 
            // multiLayoutItem827
            // 
            this.multiLayoutItem827.DataName = "sg_ymd";
            this.multiLayoutItem827.IsUpdItem = true;
            // 
            // multiLayoutItem828
            // 
            this.multiLayoutItem828.DataName = "io_gubun";
            this.multiLayoutItem828.IsUpdItem = true;
            // 
            // multiLayoutItem829
            // 
            this.multiLayoutItem829.DataName = "after_act_yn";
            this.multiLayoutItem829.IsUpdItem = true;
            // 
            // multiLayoutItem830
            // 
            this.multiLayoutItem830.DataName = "bichi_yn";
            this.multiLayoutItem830.IsUpdItem = true;
            // 
            // multiLayoutItem831
            // 
            this.multiLayoutItem831.DataName = "drg_bunho";
            this.multiLayoutItem831.IsUpdItem = true;
            // 
            // multiLayoutItem832
            // 
            this.multiLayoutItem832.DataName = "sub_susul";
            this.multiLayoutItem832.IsUpdItem = true;
            // 
            // multiLayoutItem833
            // 
            this.multiLayoutItem833.DataName = "print_yn";
            this.multiLayoutItem833.IsUpdItem = true;
            // 
            // multiLayoutItem834
            // 
            this.multiLayoutItem834.DataName = "chisik";
            this.multiLayoutItem834.IsUpdItem = true;
            // 
            // multiLayoutItem835
            // 
            this.multiLayoutItem835.DataName = "tel_yn";
            this.multiLayoutItem835.IsUpdItem = true;
            // 
            // multiLayoutItem836
            // 
            this.multiLayoutItem836.DataName = "order_gubun_bas";
            this.multiLayoutItem836.IsUpdItem = true;
            // 
            // multiLayoutItem837
            // 
            this.multiLayoutItem837.DataName = "input_control";
            this.multiLayoutItem837.IsUpdItem = true;
            // 
            // multiLayoutItem838
            // 
            this.multiLayoutItem838.DataName = "suga_yn";
            this.multiLayoutItem838.IsUpdItem = true;
            // 
            // multiLayoutItem839
            // 
            this.multiLayoutItem839.DataName = "jaeryo_yn";
            this.multiLayoutItem839.IsUpdItem = true;
            // 
            // multiLayoutItem840
            // 
            this.multiLayoutItem840.DataName = "wonyoi_check";
            this.multiLayoutItem840.IsUpdItem = true;
            // 
            // multiLayoutItem841
            // 
            this.multiLayoutItem841.DataName = "emergency_check";
            this.multiLayoutItem841.IsUpdItem = true;
            // 
            // multiLayoutItem842
            // 
            this.multiLayoutItem842.DataName = "specimen_check";
            // 
            // multiLayoutItem843
            // 
            this.multiLayoutItem843.DataName = "portable_check";
            this.multiLayoutItem843.IsUpdItem = true;
            // 
            // multiLayoutItem844
            // 
            this.multiLayoutItem844.DataName = "bulyong_check";
            this.multiLayoutItem844.IsUpdItem = true;
            // 
            // multiLayoutItem845
            // 
            this.multiLayoutItem845.DataName = "sunab_check";
            // 
            // multiLayoutItem846
            // 
            this.multiLayoutItem846.DataName = "dc_check";
            // 
            // multiLayoutItem847
            // 
            this.multiLayoutItem847.DataName = "dc_gubun_check";
            this.multiLayoutItem847.IsUpdItem = true;
            // 
            // multiLayoutItem848
            // 
            this.multiLayoutItem848.DataName = "confirm_check";
            this.multiLayoutItem848.IsUpdItem = true;
            // 
            // multiLayoutItem849
            // 
            this.multiLayoutItem849.DataName = "reser_yn_check";
            this.multiLayoutItem849.IsUpdItem = true;
            // 
            // multiLayoutItem850
            // 
            this.multiLayoutItem850.DataName = "chisik_check";
            this.multiLayoutItem850.IsUpdItem = true;
            // 
            // multiLayoutItem851
            // 
            this.multiLayoutItem851.DataName = "nday_yn";
            this.multiLayoutItem851.IsUpdItem = true;
            // 
            // multiLayoutItem852
            // 
            this.multiLayoutItem852.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem852.IsUpdItem = true;
            // 
            // multiLayoutItem853
            // 
            this.multiLayoutItem853.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem853.IsUpdItem = true;
            // 
            // multiLayoutItem854
            // 
            this.multiLayoutItem854.DataName = "specific_comment";
            this.multiLayoutItem854.IsUpdItem = true;
            // 
            // multiLayoutItem855
            // 
            this.multiLayoutItem855.DataName = "specific_comment_name";
            this.multiLayoutItem855.IsUpdItem = true;
            // 
            // multiLayoutItem856
            // 
            this.multiLayoutItem856.DataName = "specific_comment_sys_id";
            this.multiLayoutItem856.IsUpdItem = true;
            // 
            // multiLayoutItem857
            // 
            this.multiLayoutItem857.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem857.IsUpdItem = true;
            // 
            // multiLayoutItem858
            // 
            this.multiLayoutItem858.DataName = "specific_comment_not_null";
            this.multiLayoutItem858.IsUpdItem = true;
            // 
            // multiLayoutItem859
            // 
            this.multiLayoutItem859.DataName = "specific_comment_table_id";
            this.multiLayoutItem859.IsUpdItem = true;
            // 
            // multiLayoutItem860
            // 
            this.multiLayoutItem860.DataName = "specific_comment_col_id";
            this.multiLayoutItem860.IsUpdItem = true;
            // 
            // multiLayoutItem861
            // 
            this.multiLayoutItem861.DataName = "donbog_yn";
            this.multiLayoutItem861.IsUpdItem = true;
            // 
            // multiLayoutItem862
            // 
            this.multiLayoutItem862.DataName = "order_gubun_bas_name";
            this.multiLayoutItem862.IsUpdItem = true;
            // 
            // multiLayoutItem863
            // 
            this.multiLayoutItem863.DataName = "act_doctoor";
            this.multiLayoutItem863.IsUpdItem = true;
            // 
            // multiLayoutItem864
            // 
            this.multiLayoutItem864.DataName = "act_buseo";
            this.multiLayoutItem864.IsUpdItem = true;
            // 
            // multiLayoutItem865
            // 
            this.multiLayoutItem865.DataName = "act_gwa";
            this.multiLayoutItem865.IsUpdItem = true;
            // 
            // multiLayoutItem866
            // 
            this.multiLayoutItem866.DataName = "home_care_yn";
            this.multiLayoutItem866.IsUpdItem = true;
            // 
            // multiLayoutItem867
            // 
            this.multiLayoutItem867.DataName = "regular_yn";
            this.multiLayoutItem867.IsUpdItem = true;
            // 
            // multiLayoutItem868
            // 
            this.multiLayoutItem868.DataName = "sort_fkocskey";
            this.multiLayoutItem868.IsUpdItem = true;
            // 
            // multiLayoutItem1026
            // 
            this.multiLayoutItem1026.DataName = "child_yn";
            this.multiLayoutItem1026.IsUpdItem = true;
            // 
            // multiLayoutItem1027
            // 
            this.multiLayoutItem1027.DataName = "if_input_control";
            // 
            // multiLayoutItem1028
            // 
            this.multiLayoutItem1028.DataName = "slip_name";
            // 
            // multiLayoutItem1032
            // 
            this.multiLayoutItem1032.DataName = "org_key";
            // 
            // multiLayoutItem1932
            // 
            this.multiLayoutItem1932.DataName = "parent_key";
            // 
            // multiLayoutItem1948
            // 
            this.multiLayoutItem1948.DataName = "bun_code";
            // 
            // multiLayoutItem1949
            // 
            this.multiLayoutItem1949.DataName = "wonnae_drg_yn";
            // 
            // layAplOrder
            // 
            this.layAplOrder.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem550,
            this.multiLayoutItem551,
            this.multiLayoutItem552,
            this.multiLayoutItem553,
            this.multiLayoutItem554,
            this.multiLayoutItem555,
            this.multiLayoutItem556,
            this.multiLayoutItem557,
            this.multiLayoutItem558,
            this.multiLayoutItem559,
            this.multiLayoutItem560,
            this.multiLayoutItem561,
            this.multiLayoutItem562,
            this.multiLayoutItem563,
            this.multiLayoutItem564,
            this.multiLayoutItem565,
            this.multiLayoutItem566,
            this.multiLayoutItem567,
            this.multiLayoutItem568,
            this.multiLayoutItem569,
            this.multiLayoutItem570,
            this.multiLayoutItem571,
            this.multiLayoutItem572,
            this.multiLayoutItem573,
            this.multiLayoutItem574,
            this.multiLayoutItem575,
            this.multiLayoutItem576,
            this.multiLayoutItem577,
            this.multiLayoutItem578,
            this.multiLayoutItem579,
            this.multiLayoutItem580,
            this.multiLayoutItem581,
            this.multiLayoutItem582,
            this.multiLayoutItem583,
            this.multiLayoutItem584,
            this.multiLayoutItem585,
            this.multiLayoutItem586,
            this.multiLayoutItem587,
            this.multiLayoutItem588,
            this.multiLayoutItem589,
            this.multiLayoutItem590,
            this.multiLayoutItem591,
            this.multiLayoutItem592,
            this.multiLayoutItem593,
            this.multiLayoutItem594,
            this.multiLayoutItem595,
            this.multiLayoutItem596,
            this.multiLayoutItem597,
            this.multiLayoutItem598,
            this.multiLayoutItem599,
            this.multiLayoutItem600,
            this.multiLayoutItem601,
            this.multiLayoutItem602,
            this.multiLayoutItem603,
            this.multiLayoutItem604,
            this.multiLayoutItem605,
            this.multiLayoutItem606,
            this.multiLayoutItem607,
            this.multiLayoutItem608,
            this.multiLayoutItem609,
            this.multiLayoutItem610,
            this.multiLayoutItem611,
            this.multiLayoutItem612,
            this.multiLayoutItem613,
            this.multiLayoutItem614,
            this.multiLayoutItem615,
            this.multiLayoutItem616,
            this.multiLayoutItem617,
            this.multiLayoutItem618,
            this.multiLayoutItem619,
            this.multiLayoutItem620,
            this.multiLayoutItem621,
            this.multiLayoutItem622,
            this.multiLayoutItem623,
            this.multiLayoutItem624,
            this.multiLayoutItem625,
            this.multiLayoutItem626,
            this.multiLayoutItem627,
            this.multiLayoutItem628,
            this.multiLayoutItem629,
            this.multiLayoutItem630,
            this.multiLayoutItem631,
            this.multiLayoutItem632,
            this.multiLayoutItem633,
            this.multiLayoutItem634,
            this.multiLayoutItem635,
            this.multiLayoutItem636,
            this.multiLayoutItem637,
            this.multiLayoutItem638,
            this.multiLayoutItem639,
            this.multiLayoutItem640,
            this.multiLayoutItem641,
            this.multiLayoutItem642,
            this.multiLayoutItem643,
            this.multiLayoutItem644,
            this.multiLayoutItem645,
            this.multiLayoutItem646,
            this.multiLayoutItem647,
            this.multiLayoutItem648,
            this.multiLayoutItem649,
            this.multiLayoutItem650,
            this.multiLayoutItem651,
            this.multiLayoutItem652,
            this.multiLayoutItem653,
            this.multiLayoutItem654,
            this.multiLayoutItem655,
            this.multiLayoutItem656,
            this.multiLayoutItem657,
            this.multiLayoutItem658,
            this.multiLayoutItem659,
            this.multiLayoutItem660,
            this.multiLayoutItem661,
            this.multiLayoutItem662,
            this.multiLayoutItem663,
            this.multiLayoutItem664,
            this.multiLayoutItem665,
            this.multiLayoutItem666,
            this.multiLayoutItem667,
            this.multiLayoutItem668,
            this.multiLayoutItem669,
            this.multiLayoutItem670,
            this.multiLayoutItem671,
            this.multiLayoutItem672,
            this.multiLayoutItem673,
            this.multiLayoutItem674,
            this.multiLayoutItem675,
            this.multiLayoutItem676,
            this.multiLayoutItem677,
            this.multiLayoutItem678,
            this.multiLayoutItem679,
            this.multiLayoutItem680,
            this.multiLayoutItem681,
            this.multiLayoutItem682,
            this.multiLayoutItem683,
            this.multiLayoutItem684,
            this.multiLayoutItem685,
            this.multiLayoutItem686,
            this.multiLayoutItem704,
            this.multiLayoutItem705,
            this.multiLayoutItem706,
            this.multiLayoutItem714,
            this.multiLayoutItem715,
            this.multiLayoutItem716,
            this.multiLayoutItem1024,
            this.multiLayoutItem1025,
            this.multiLayoutItem1030,
            this.multiLayoutItem1040,
            this.multiLayoutItem1933,
            this.multiLayoutItem1934,
            this.multiLayoutItem1950});
            // 
            // multiLayoutItem550
            // 
            this.multiLayoutItem550.DataName = "in_out_key";
            this.multiLayoutItem550.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem550.IsUpdItem = true;
            // 
            // multiLayoutItem551
            // 
            this.multiLayoutItem551.DataName = "pkocskey";
            this.multiLayoutItem551.IsUpdItem = true;
            // 
            // multiLayoutItem552
            // 
            this.multiLayoutItem552.DataName = "bunho";
            this.multiLayoutItem552.IsUpdItem = true;
            // 
            // multiLayoutItem553
            // 
            this.multiLayoutItem553.DataName = "order_date";
            this.multiLayoutItem553.IsUpdItem = true;
            // 
            // multiLayoutItem554
            // 
            this.multiLayoutItem554.DataName = "gwa";
            this.multiLayoutItem554.IsUpdItem = true;
            // 
            // multiLayoutItem555
            // 
            this.multiLayoutItem555.DataName = "doctor";
            this.multiLayoutItem555.IsUpdItem = true;
            // 
            // multiLayoutItem556
            // 
            this.multiLayoutItem556.DataName = "resident";
            this.multiLayoutItem556.IsUpdItem = true;
            // 
            // multiLayoutItem557
            // 
            this.multiLayoutItem557.DataName = "naewon_type";
            this.multiLayoutItem557.IsUpdItem = true;
            // 
            // multiLayoutItem558
            // 
            this.multiLayoutItem558.DataName = "jubsu_no";
            this.multiLayoutItem558.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem558.IsUpdItem = true;
            // 
            // multiLayoutItem559
            // 
            this.multiLayoutItem559.DataName = "input_id";
            this.multiLayoutItem559.IsUpdItem = true;
            // 
            // multiLayoutItem560
            // 
            this.multiLayoutItem560.DataName = "input_part";
            this.multiLayoutItem560.IsUpdItem = true;
            // 
            // multiLayoutItem561
            // 
            this.multiLayoutItem561.DataName = "input_gwa";
            this.multiLayoutItem561.IsUpdItem = true;
            // 
            // multiLayoutItem562
            // 
            this.multiLayoutItem562.DataName = "input_doctor";
            this.multiLayoutItem562.IsUpdItem = true;
            // 
            // multiLayoutItem563
            // 
            this.multiLayoutItem563.DataName = "input_gubun";
            this.multiLayoutItem563.IsUpdItem = true;
            // 
            // multiLayoutItem564
            // 
            this.multiLayoutItem564.DataName = "input_gubun_name";
            // 
            // multiLayoutItem565
            // 
            this.multiLayoutItem565.DataName = "group_ser";
            this.multiLayoutItem565.IsUpdItem = true;
            // 
            // multiLayoutItem566
            // 
            this.multiLayoutItem566.DataName = "input_tab";
            this.multiLayoutItem566.IsUpdItem = true;
            // 
            // multiLayoutItem567
            // 
            this.multiLayoutItem567.DataName = "input_tab_name";
            // 
            // multiLayoutItem568
            // 
            this.multiLayoutItem568.DataName = "order_gubun";
            this.multiLayoutItem568.IsUpdItem = true;
            // 
            // multiLayoutItem569
            // 
            this.multiLayoutItem569.DataName = "order_gubun_name";
            // 
            // multiLayoutItem570
            // 
            this.multiLayoutItem570.DataName = "group_yn";
            this.multiLayoutItem570.IsUpdItem = true;
            // 
            // multiLayoutItem571
            // 
            this.multiLayoutItem571.DataName = "seq";
            this.multiLayoutItem571.IsUpdItem = true;
            // 
            // multiLayoutItem572
            // 
            this.multiLayoutItem572.DataName = "slip_code";
            this.multiLayoutItem572.IsUpdItem = true;
            // 
            // multiLayoutItem573
            // 
            this.multiLayoutItem573.DataName = "hangmog_code";
            this.multiLayoutItem573.IsUpdItem = true;
            // 
            // multiLayoutItem574
            // 
            this.multiLayoutItem574.DataName = "hangmog_name";
            // 
            // multiLayoutItem575
            // 
            this.multiLayoutItem575.DataName = "specimen_code";
            this.multiLayoutItem575.IsUpdItem = true;
            // 
            // multiLayoutItem576
            // 
            this.multiLayoutItem576.DataName = "specimen_name";
            // 
            // multiLayoutItem577
            // 
            this.multiLayoutItem577.DataName = "suryang";
            this.multiLayoutItem577.IsUpdItem = true;
            // 
            // multiLayoutItem578
            // 
            this.multiLayoutItem578.DataName = "sunab_suryang";
            this.multiLayoutItem578.IsUpdItem = true;
            // 
            // multiLayoutItem579
            // 
            this.multiLayoutItem579.DataName = "subul_suryang";
            this.multiLayoutItem579.IsUpdItem = true;
            // 
            // multiLayoutItem580
            // 
            this.multiLayoutItem580.DataName = "ord_danui";
            this.multiLayoutItem580.IsUpdItem = true;
            // 
            // multiLayoutItem581
            // 
            this.multiLayoutItem581.DataName = "ord_danui_name";
            // 
            // multiLayoutItem582
            // 
            this.multiLayoutItem582.DataName = "dv_time";
            this.multiLayoutItem582.IsUpdItem = true;
            // 
            // multiLayoutItem583
            // 
            this.multiLayoutItem583.DataName = "dv";
            this.multiLayoutItem583.IsUpdItem = true;
            // 
            // multiLayoutItem584
            // 
            this.multiLayoutItem584.DataName = "dv_1";
            this.multiLayoutItem584.IsUpdItem = true;
            // 
            // multiLayoutItem585
            // 
            this.multiLayoutItem585.DataName = "dv_2";
            this.multiLayoutItem585.IsUpdItem = true;
            // 
            // multiLayoutItem586
            // 
            this.multiLayoutItem586.DataName = "dv_3";
            this.multiLayoutItem586.IsUpdItem = true;
            // 
            // multiLayoutItem587
            // 
            this.multiLayoutItem587.DataName = "dv_4";
            this.multiLayoutItem587.IsUpdItem = true;
            // 
            // multiLayoutItem588
            // 
            this.multiLayoutItem588.DataName = "nalsu";
            this.multiLayoutItem588.IsUpdItem = true;
            // 
            // multiLayoutItem589
            // 
            this.multiLayoutItem589.DataName = "sunab_nalsu";
            this.multiLayoutItem589.IsUpdItem = true;
            // 
            // multiLayoutItem590
            // 
            this.multiLayoutItem590.DataName = "jusa";
            this.multiLayoutItem590.IsUpdItem = true;
            // 
            // multiLayoutItem591
            // 
            this.multiLayoutItem591.DataName = "jusa_name";
            this.multiLayoutItem591.IsUpdItem = true;
            // 
            // multiLayoutItem592
            // 
            this.multiLayoutItem592.DataName = "jusa_spd_gubun";
            this.multiLayoutItem592.IsUpdItem = true;
            // 
            // multiLayoutItem593
            // 
            this.multiLayoutItem593.DataName = "bogyong_code";
            this.multiLayoutItem593.IsUpdItem = true;
            // 
            // multiLayoutItem594
            // 
            this.multiLayoutItem594.DataName = "bogyong_name";
            this.multiLayoutItem594.IsUpdItem = true;
            // 
            // multiLayoutItem595
            // 
            this.multiLayoutItem595.DataName = "emergency";
            this.multiLayoutItem595.IsUpdItem = true;
            // 
            // multiLayoutItem596
            // 
            this.multiLayoutItem596.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem596.IsUpdItem = true;
            // 
            // multiLayoutItem597
            // 
            this.multiLayoutItem597.DataName = "jundal_table";
            this.multiLayoutItem597.IsUpdItem = true;
            // 
            // multiLayoutItem598
            // 
            this.multiLayoutItem598.DataName = "jundal_part";
            this.multiLayoutItem598.IsUpdItem = true;
            // 
            // multiLayoutItem599
            // 
            this.multiLayoutItem599.DataName = "move_part";
            this.multiLayoutItem599.IsUpdItem = true;
            // 
            // multiLayoutItem600
            // 
            this.multiLayoutItem600.DataName = "portable_yn";
            this.multiLayoutItem600.IsUpdItem = true;
            // 
            // multiLayoutItem601
            // 
            this.multiLayoutItem601.DataName = "powder_yn";
            this.multiLayoutItem601.IsUpdItem = true;
            // 
            // multiLayoutItem602
            // 
            this.multiLayoutItem602.DataName = "hubal_change_yn";
            this.multiLayoutItem602.IsUpdItem = true;
            // 
            // multiLayoutItem603
            // 
            this.multiLayoutItem603.DataName = "pharmacy";
            this.multiLayoutItem603.IsUpdItem = true;
            // 
            // multiLayoutItem604
            // 
            this.multiLayoutItem604.DataName = "drg_pack_yn";
            this.multiLayoutItem604.IsUpdItem = true;
            // 
            // multiLayoutItem605
            // 
            this.multiLayoutItem605.DataName = "muhyo";
            this.multiLayoutItem605.IsUpdItem = true;
            // 
            // multiLayoutItem606
            // 
            this.multiLayoutItem606.DataName = "prn_yn";
            this.multiLayoutItem606.IsUpdItem = true;
            // 
            // multiLayoutItem607
            // 
            this.multiLayoutItem607.DataName = "toiwon_drg_yn";
            this.multiLayoutItem607.IsUpdItem = true;
            // 
            // multiLayoutItem608
            // 
            this.multiLayoutItem608.DataName = "prn_nurse";
            this.multiLayoutItem608.IsUpdItem = true;
            // 
            // multiLayoutItem609
            // 
            this.multiLayoutItem609.DataName = "append_yn";
            this.multiLayoutItem609.IsUpdItem = true;
            // 
            // multiLayoutItem610
            // 
            this.multiLayoutItem610.DataName = "order_remark";
            this.multiLayoutItem610.IsUpdItem = true;
            // 
            // multiLayoutItem611
            // 
            this.multiLayoutItem611.DataName = "nurse_remark";
            this.multiLayoutItem611.IsUpdItem = true;
            // 
            // multiLayoutItem612
            // 
            this.multiLayoutItem612.DataName = "comment";
            this.multiLayoutItem612.IsUpdItem = true;
            // 
            // multiLayoutItem613
            // 
            this.multiLayoutItem613.DataName = "mix_group";
            this.multiLayoutItem613.IsUpdItem = true;
            // 
            // multiLayoutItem614
            // 
            this.multiLayoutItem614.DataName = "amt";
            this.multiLayoutItem614.IsUpdItem = true;
            // 
            // multiLayoutItem615
            // 
            this.multiLayoutItem615.DataName = "pay";
            this.multiLayoutItem615.IsUpdItem = true;
            // 
            // multiLayoutItem616
            // 
            this.multiLayoutItem616.DataName = "wonyoi_order_yn";
            this.multiLayoutItem616.IsUpdItem = true;
            // 
            // multiLayoutItem617
            // 
            this.multiLayoutItem617.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem617.IsUpdItem = true;
            // 
            // multiLayoutItem618
            // 
            this.multiLayoutItem618.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem618.IsUpdItem = true;
            // 
            // multiLayoutItem619
            // 
            this.multiLayoutItem619.DataName = "bom_occur_yn";
            this.multiLayoutItem619.IsUpdItem = true;
            // 
            // multiLayoutItem620
            // 
            this.multiLayoutItem620.DataName = "bom_source_key";
            this.multiLayoutItem620.IsUpdItem = true;
            // 
            // multiLayoutItem621
            // 
            this.multiLayoutItem621.DataName = "display_yn";
            this.multiLayoutItem621.IsUpdItem = true;
            // 
            // multiLayoutItem622
            // 
            this.multiLayoutItem622.DataName = "sunab_yn";
            this.multiLayoutItem622.IsUpdItem = true;
            // 
            // multiLayoutItem623
            // 
            this.multiLayoutItem623.DataName = "sunab_date";
            this.multiLayoutItem623.IsUpdItem = true;
            // 
            // multiLayoutItem624
            // 
            this.multiLayoutItem624.DataName = "sunab_time";
            this.multiLayoutItem624.IsUpdItem = true;
            // 
            // multiLayoutItem625
            // 
            this.multiLayoutItem625.DataName = "hope_date";
            this.multiLayoutItem625.IsUpdItem = true;
            // 
            // multiLayoutItem626
            // 
            this.multiLayoutItem626.DataName = "hope_time";
            this.multiLayoutItem626.IsUpdItem = true;
            // 
            // multiLayoutItem627
            // 
            this.multiLayoutItem627.DataName = "nurse_confirm_user";
            this.multiLayoutItem627.IsUpdItem = true;
            // 
            // multiLayoutItem628
            // 
            this.multiLayoutItem628.DataName = "nurse_confirm_date";
            this.multiLayoutItem628.IsUpdItem = true;
            // 
            // multiLayoutItem629
            // 
            this.multiLayoutItem629.DataName = "nurse_confirm_time";
            this.multiLayoutItem629.IsUpdItem = true;
            // 
            // multiLayoutItem630
            // 
            this.multiLayoutItem630.DataName = "nurse_pickup_user";
            this.multiLayoutItem630.IsUpdItem = true;
            // 
            // multiLayoutItem631
            // 
            this.multiLayoutItem631.DataName = "nurse_pickup_date";
            this.multiLayoutItem631.IsUpdItem = true;
            // 
            // multiLayoutItem632
            // 
            this.multiLayoutItem632.DataName = "nurse_pickup_time";
            this.multiLayoutItem632.IsUpdItem = true;
            // 
            // multiLayoutItem633
            // 
            this.multiLayoutItem633.DataName = "nurse_hold_user";
            this.multiLayoutItem633.IsUpdItem = true;
            // 
            // multiLayoutItem634
            // 
            this.multiLayoutItem634.DataName = "nurse_hold_date";
            this.multiLayoutItem634.IsUpdItem = true;
            // 
            // multiLayoutItem635
            // 
            this.multiLayoutItem635.DataName = "nurse_hold_time";
            this.multiLayoutItem635.IsUpdItem = true;
            // 
            // multiLayoutItem636
            // 
            this.multiLayoutItem636.DataName = "reser_date";
            this.multiLayoutItem636.IsUpdItem = true;
            // 
            // multiLayoutItem637
            // 
            this.multiLayoutItem637.DataName = "reser_time";
            this.multiLayoutItem637.IsUpdItem = true;
            // 
            // multiLayoutItem638
            // 
            this.multiLayoutItem638.DataName = "jubsu_date";
            this.multiLayoutItem638.IsUpdItem = true;
            // 
            // multiLayoutItem639
            // 
            this.multiLayoutItem639.DataName = "jubsu_time";
            this.multiLayoutItem639.IsUpdItem = true;
            // 
            // multiLayoutItem640
            // 
            this.multiLayoutItem640.DataName = "acting_date";
            this.multiLayoutItem640.IsUpdItem = true;
            // 
            // multiLayoutItem641
            // 
            this.multiLayoutItem641.DataName = "acting_time";
            this.multiLayoutItem641.IsUpdItem = true;
            // 
            // multiLayoutItem642
            // 
            this.multiLayoutItem642.DataName = "acting_day";
            this.multiLayoutItem642.IsUpdItem = true;
            // 
            // multiLayoutItem643
            // 
            this.multiLayoutItem643.DataName = "result_date";
            this.multiLayoutItem643.IsUpdItem = true;
            // 
            // multiLayoutItem644
            // 
            this.multiLayoutItem644.DataName = "dc_gubun";
            this.multiLayoutItem644.IsUpdItem = true;
            // 
            // multiLayoutItem645
            // 
            this.multiLayoutItem645.DataName = "dc_yn";
            this.multiLayoutItem645.IsUpdItem = true;
            // 
            // multiLayoutItem646
            // 
            this.multiLayoutItem646.DataName = "bannab_yn";
            this.multiLayoutItem646.IsUpdItem = true;
            // 
            // multiLayoutItem647
            // 
            this.multiLayoutItem647.DataName = "bannab_confirm";
            this.multiLayoutItem647.IsUpdItem = true;
            // 
            // multiLayoutItem648
            // 
            this.multiLayoutItem648.DataName = "source_ord_key";
            this.multiLayoutItem648.IsUpdItem = true;
            // 
            // multiLayoutItem649
            // 
            this.multiLayoutItem649.DataName = "ocs_flag";
            this.multiLayoutItem649.IsUpdItem = true;
            // 
            // multiLayoutItem650
            // 
            this.multiLayoutItem650.DataName = "sg_code";
            this.multiLayoutItem650.IsUpdItem = true;
            // 
            // multiLayoutItem651
            // 
            this.multiLayoutItem651.DataName = "sg_ymd";
            this.multiLayoutItem651.IsUpdItem = true;
            // 
            // multiLayoutItem652
            // 
            this.multiLayoutItem652.DataName = "io_gubun";
            this.multiLayoutItem652.IsUpdItem = true;
            // 
            // multiLayoutItem653
            // 
            this.multiLayoutItem653.DataName = "after_act_yn";
            this.multiLayoutItem653.IsUpdItem = true;
            // 
            // multiLayoutItem654
            // 
            this.multiLayoutItem654.DataName = "bichi_yn";
            this.multiLayoutItem654.IsUpdItem = true;
            // 
            // multiLayoutItem655
            // 
            this.multiLayoutItem655.DataName = "drg_bunho";
            this.multiLayoutItem655.IsUpdItem = true;
            // 
            // multiLayoutItem656
            // 
            this.multiLayoutItem656.DataName = "sub_susul";
            this.multiLayoutItem656.IsUpdItem = true;
            // 
            // multiLayoutItem657
            // 
            this.multiLayoutItem657.DataName = "print_yn";
            this.multiLayoutItem657.IsUpdItem = true;
            // 
            // multiLayoutItem658
            // 
            this.multiLayoutItem658.DataName = "chisik";
            this.multiLayoutItem658.IsUpdItem = true;
            // 
            // multiLayoutItem659
            // 
            this.multiLayoutItem659.DataName = "tel_yn";
            this.multiLayoutItem659.IsUpdItem = true;
            // 
            // multiLayoutItem660
            // 
            this.multiLayoutItem660.DataName = "order_gubun_bas";
            this.multiLayoutItem660.IsUpdItem = true;
            // 
            // multiLayoutItem661
            // 
            this.multiLayoutItem661.DataName = "input_control";
            this.multiLayoutItem661.IsUpdItem = true;
            // 
            // multiLayoutItem662
            // 
            this.multiLayoutItem662.DataName = "suga_yn";
            this.multiLayoutItem662.IsUpdItem = true;
            // 
            // multiLayoutItem663
            // 
            this.multiLayoutItem663.DataName = "jaeryo_yn";
            this.multiLayoutItem663.IsUpdItem = true;
            // 
            // multiLayoutItem664
            // 
            this.multiLayoutItem664.DataName = "wonyoi_check";
            this.multiLayoutItem664.IsUpdItem = true;
            // 
            // multiLayoutItem665
            // 
            this.multiLayoutItem665.DataName = "emergency_check";
            this.multiLayoutItem665.IsUpdItem = true;
            // 
            // multiLayoutItem666
            // 
            this.multiLayoutItem666.DataName = "specimen_check";
            // 
            // multiLayoutItem667
            // 
            this.multiLayoutItem667.DataName = "portable_check";
            this.multiLayoutItem667.IsUpdItem = true;
            // 
            // multiLayoutItem668
            // 
            this.multiLayoutItem668.DataName = "bulyong_check";
            this.multiLayoutItem668.IsUpdItem = true;
            // 
            // multiLayoutItem669
            // 
            this.multiLayoutItem669.DataName = "sunab_check";
            // 
            // multiLayoutItem670
            // 
            this.multiLayoutItem670.DataName = "dc_check";
            // 
            // multiLayoutItem671
            // 
            this.multiLayoutItem671.DataName = "dc_gubun_check";
            this.multiLayoutItem671.IsUpdItem = true;
            // 
            // multiLayoutItem672
            // 
            this.multiLayoutItem672.DataName = "confirm_check";
            this.multiLayoutItem672.IsUpdItem = true;
            // 
            // multiLayoutItem673
            // 
            this.multiLayoutItem673.DataName = "reser_yn_check";
            this.multiLayoutItem673.IsUpdItem = true;
            // 
            // multiLayoutItem674
            // 
            this.multiLayoutItem674.DataName = "chisik_check";
            this.multiLayoutItem674.IsUpdItem = true;
            // 
            // multiLayoutItem675
            // 
            this.multiLayoutItem675.DataName = "nday_yn";
            this.multiLayoutItem675.IsUpdItem = true;
            // 
            // multiLayoutItem676
            // 
            this.multiLayoutItem676.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem676.IsUpdItem = true;
            // 
            // multiLayoutItem677
            // 
            this.multiLayoutItem677.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem677.IsUpdItem = true;
            // 
            // multiLayoutItem678
            // 
            this.multiLayoutItem678.DataName = "specific_comment";
            this.multiLayoutItem678.IsUpdItem = true;
            // 
            // multiLayoutItem679
            // 
            this.multiLayoutItem679.DataName = "specific_comment_name";
            this.multiLayoutItem679.IsUpdItem = true;
            // 
            // multiLayoutItem680
            // 
            this.multiLayoutItem680.DataName = "specific_comment_sys_id";
            this.multiLayoutItem680.IsUpdItem = true;
            // 
            // multiLayoutItem681
            // 
            this.multiLayoutItem681.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem681.IsUpdItem = true;
            // 
            // multiLayoutItem682
            // 
            this.multiLayoutItem682.DataName = "specific_comment_not_null";
            this.multiLayoutItem682.IsUpdItem = true;
            // 
            // multiLayoutItem683
            // 
            this.multiLayoutItem683.DataName = "specific_comment_table_id";
            this.multiLayoutItem683.IsUpdItem = true;
            // 
            // multiLayoutItem684
            // 
            this.multiLayoutItem684.DataName = "specific_comment_col_id";
            this.multiLayoutItem684.IsUpdItem = true;
            // 
            // multiLayoutItem685
            // 
            this.multiLayoutItem685.DataName = "donbog_yn";
            this.multiLayoutItem685.IsUpdItem = true;
            // 
            // multiLayoutItem686
            // 
            this.multiLayoutItem686.DataName = "order_gubun_bas_name";
            this.multiLayoutItem686.IsUpdItem = true;
            // 
            // multiLayoutItem704
            // 
            this.multiLayoutItem704.DataName = "act_doctoor";
            this.multiLayoutItem704.IsUpdItem = true;
            // 
            // multiLayoutItem705
            // 
            this.multiLayoutItem705.DataName = "act_buseo";
            this.multiLayoutItem705.IsUpdItem = true;
            // 
            // multiLayoutItem706
            // 
            this.multiLayoutItem706.DataName = "act_gwa";
            this.multiLayoutItem706.IsUpdItem = true;
            // 
            // multiLayoutItem714
            // 
            this.multiLayoutItem714.DataName = "home_care_yn";
            this.multiLayoutItem714.IsUpdItem = true;
            // 
            // multiLayoutItem715
            // 
            this.multiLayoutItem715.DataName = "regular_yn";
            this.multiLayoutItem715.IsUpdItem = true;
            // 
            // multiLayoutItem716
            // 
            this.multiLayoutItem716.DataName = "sort_fkocskey";
            this.multiLayoutItem716.IsUpdItem = true;
            // 
            // multiLayoutItem1024
            // 
            this.multiLayoutItem1024.DataName = "child_yn";
            this.multiLayoutItem1024.IsUpdItem = true;
            // 
            // multiLayoutItem1025
            // 
            this.multiLayoutItem1025.DataName = "if_input_control";
            // 
            // multiLayoutItem1030
            // 
            this.multiLayoutItem1030.DataName = "slip_name";
            // 
            // multiLayoutItem1040
            // 
            this.multiLayoutItem1040.DataName = "org_key";
            // 
            // multiLayoutItem1933
            // 
            this.multiLayoutItem1933.DataName = "parent_key";
            // 
            // multiLayoutItem1934
            // 
            this.multiLayoutItem1934.DataName = "bun_code";
            // 
            // multiLayoutItem1950
            // 
            this.multiLayoutItem1950.DataName = "wonnae_drg_yn";
            // 
            // laySusulOrder
            // 
            this.laySusulOrder.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem147,
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem150,
            this.multiLayoutItem151,
            this.multiLayoutItem34,
            this.multiLayoutItem153,
            this.multiLayoutItem35,
            this.multiLayoutItem155,
            this.multiLayoutItem36,
            this.multiLayoutItem37,
            this.multiLayoutItem158,
            this.multiLayoutItem38,
            this.multiLayoutItem39,
            this.multiLayoutItem161,
            this.multiLayoutItem162,
            this.multiLayoutItem163,
            this.multiLayoutItem164,
            this.multiLayoutItem165,
            this.multiLayoutItem166,
            this.multiLayoutItem167,
            this.multiLayoutItem168,
            this.multiLayoutItem169,
            this.multiLayoutItem170,
            this.multiLayoutItem171,
            this.multiLayoutItem172,
            this.multiLayoutItem173,
            this.multiLayoutItem174,
            this.multiLayoutItem175,
            this.multiLayoutItem176,
            this.multiLayoutItem177,
            this.multiLayoutItem178,
            this.multiLayoutItem179,
            this.multiLayoutItem180,
            this.multiLayoutItem181,
            this.multiLayoutItem182,
            this.multiLayoutItem183,
            this.multiLayoutItem184,
            this.multiLayoutItem185,
            this.multiLayoutItem186,
            this.multiLayoutItem187,
            this.multiLayoutItem188,
            this.multiLayoutItem189,
            this.multiLayoutItem190,
            this.multiLayoutItem191,
            this.multiLayoutItem192,
            this.multiLayoutItem193,
            this.multiLayoutItem194,
            this.multiLayoutItem195,
            this.multiLayoutItem196,
            this.multiLayoutItem197,
            this.multiLayoutItem198,
            this.multiLayoutItem199,
            this.multiLayoutItem200,
            this.multiLayoutItem201,
            this.multiLayoutItem202,
            this.multiLayoutItem203,
            this.multiLayoutItem204,
            this.multiLayoutItem205,
            this.multiLayoutItem206,
            this.multiLayoutItem207,
            this.multiLayoutItem208,
            this.multiLayoutItem209,
            this.multiLayoutItem210,
            this.multiLayoutItem211,
            this.multiLayoutItem212,
            this.multiLayoutItem213,
            this.multiLayoutItem214,
            this.multiLayoutItem215,
            this.multiLayoutItem216,
            this.multiLayoutItem217,
            this.multiLayoutItem218,
            this.multiLayoutItem219,
            this.multiLayoutItem220,
            this.multiLayoutItem221,
            this.multiLayoutItem222,
            this.multiLayoutItem223,
            this.multiLayoutItem224,
            this.multiLayoutItem225,
            this.multiLayoutItem226,
            this.multiLayoutItem227,
            this.multiLayoutItem228,
            this.multiLayoutItem229,
            this.multiLayoutItem230,
            this.multiLayoutItem231,
            this.multiLayoutItem232,
            this.multiLayoutItem233,
            this.multiLayoutItem234,
            this.multiLayoutItem235,
            this.multiLayoutItem236,
            this.multiLayoutItem237,
            this.multiLayoutItem238,
            this.multiLayoutItem239,
            this.multiLayoutItem240,
            this.multiLayoutItem241,
            this.multiLayoutItem242,
            this.multiLayoutItem243,
            this.multiLayoutItem244,
            this.multiLayoutItem245,
            this.multiLayoutItem246,
            this.multiLayoutItem247,
            this.multiLayoutItem248,
            this.multiLayoutItem249,
            this.multiLayoutItem250,
            this.multiLayoutItem251,
            this.multiLayoutItem252,
            this.multiLayoutItem253,
            this.multiLayoutItem254,
            this.multiLayoutItem255,
            this.multiLayoutItem256,
            this.multiLayoutItem257,
            this.multiLayoutItem258,
            this.multiLayoutItem259,
            this.multiLayoutItem260,
            this.multiLayoutItem261,
            this.multiLayoutItem262,
            this.multiLayoutItem263,
            this.multiLayoutItem264,
            this.multiLayoutItem265,
            this.multiLayoutItem266,
            this.multiLayoutItem267,
            this.multiLayoutItem268,
            this.multiLayoutItem269,
            this.multiLayoutItem270,
            this.multiLayoutItem271,
            this.multiLayoutItem272,
            this.multiLayoutItem273,
            this.multiLayoutItem274,
            this.multiLayoutItem275,
            this.multiLayoutItem276,
            this.multiLayoutItem277,
            this.multiLayoutItem278,
            this.multiLayoutItem279,
            this.multiLayoutItem280,
            this.multiLayoutItem281,
            this.multiLayoutItem282,
            this.multiLayoutItem283,
            this.multiLayoutItem707,
            this.multiLayoutItem708,
            this.multiLayoutItem709,
            this.multiLayoutItem710,
            this.multiLayoutItem721,
            this.multiLayoutItem722,
            this.multiLayoutItem1022,
            this.multiLayoutItem1023,
            this.multiLayoutItem1041,
            this.multiLayoutItem1186,
            this.multiLayoutItem1187,
            this.multiLayoutItem1935,
            this.multiLayoutItem1951});
            // 
            // multiLayoutItem147
            // 
            this.multiLayoutItem147.DataName = "in_out_key";
            this.multiLayoutItem147.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem147.IsUpdItem = true;
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "pkocskey";
            this.multiLayoutItem32.IsUpdItem = true;
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "bunho";
            this.multiLayoutItem33.IsUpdItem = true;
            // 
            // multiLayoutItem150
            // 
            this.multiLayoutItem150.DataName = "order_date";
            this.multiLayoutItem150.IsUpdItem = true;
            // 
            // multiLayoutItem151
            // 
            this.multiLayoutItem151.DataName = "gwa";
            this.multiLayoutItem151.IsUpdItem = true;
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "doctor";
            this.multiLayoutItem34.IsUpdItem = true;
            // 
            // multiLayoutItem153
            // 
            this.multiLayoutItem153.DataName = "resident";
            this.multiLayoutItem153.IsUpdItem = true;
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "naewon_type";
            this.multiLayoutItem35.IsUpdItem = true;
            // 
            // multiLayoutItem155
            // 
            this.multiLayoutItem155.DataName = "jubsu_no";
            this.multiLayoutItem155.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem155.IsUpdItem = true;
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "input_id";
            this.multiLayoutItem36.IsUpdItem = true;
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "input_part";
            this.multiLayoutItem37.IsUpdItem = true;
            // 
            // multiLayoutItem158
            // 
            this.multiLayoutItem158.DataName = "input_gwa";
            this.multiLayoutItem158.IsUpdItem = true;
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "input_doctor";
            this.multiLayoutItem38.IsUpdItem = true;
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "input_gubun";
            this.multiLayoutItem39.IsUpdItem = true;
            // 
            // multiLayoutItem161
            // 
            this.multiLayoutItem161.DataName = "input_gubun_name";
            // 
            // multiLayoutItem162
            // 
            this.multiLayoutItem162.DataName = "group_ser";
            this.multiLayoutItem162.IsUpdItem = true;
            // 
            // multiLayoutItem163
            // 
            this.multiLayoutItem163.DataName = "input_tab";
            this.multiLayoutItem163.IsUpdItem = true;
            // 
            // multiLayoutItem164
            // 
            this.multiLayoutItem164.DataName = "input_tab_name";
            // 
            // multiLayoutItem165
            // 
            this.multiLayoutItem165.DataName = "order_gubun";
            this.multiLayoutItem165.IsUpdItem = true;
            // 
            // multiLayoutItem166
            // 
            this.multiLayoutItem166.DataName = "order_gubun_name";
            // 
            // multiLayoutItem167
            // 
            this.multiLayoutItem167.DataName = "group_yn";
            this.multiLayoutItem167.IsUpdItem = true;
            // 
            // multiLayoutItem168
            // 
            this.multiLayoutItem168.DataName = "seq";
            this.multiLayoutItem168.IsUpdItem = true;
            // 
            // multiLayoutItem169
            // 
            this.multiLayoutItem169.DataName = "slip_code";
            this.multiLayoutItem169.IsUpdItem = true;
            // 
            // multiLayoutItem170
            // 
            this.multiLayoutItem170.DataName = "hangmog_code";
            this.multiLayoutItem170.IsUpdItem = true;
            // 
            // multiLayoutItem171
            // 
            this.multiLayoutItem171.DataName = "hangmog_name";
            // 
            // multiLayoutItem172
            // 
            this.multiLayoutItem172.DataName = "specimen_code";
            this.multiLayoutItem172.IsUpdItem = true;
            // 
            // multiLayoutItem173
            // 
            this.multiLayoutItem173.DataName = "specimen_name";
            // 
            // multiLayoutItem174
            // 
            this.multiLayoutItem174.DataName = "suryang";
            this.multiLayoutItem174.IsUpdItem = true;
            // 
            // multiLayoutItem175
            // 
            this.multiLayoutItem175.DataName = "sunab_suryang";
            this.multiLayoutItem175.IsUpdItem = true;
            // 
            // multiLayoutItem176
            // 
            this.multiLayoutItem176.DataName = "subul_suryang";
            this.multiLayoutItem176.IsUpdItem = true;
            // 
            // multiLayoutItem177
            // 
            this.multiLayoutItem177.DataName = "ord_danui";
            this.multiLayoutItem177.IsUpdItem = true;
            // 
            // multiLayoutItem178
            // 
            this.multiLayoutItem178.DataName = "ord_danui_name";
            // 
            // multiLayoutItem179
            // 
            this.multiLayoutItem179.DataName = "dv_time";
            this.multiLayoutItem179.IsUpdItem = true;
            // 
            // multiLayoutItem180
            // 
            this.multiLayoutItem180.DataName = "dv";
            this.multiLayoutItem180.IsUpdItem = true;
            // 
            // multiLayoutItem181
            // 
            this.multiLayoutItem181.DataName = "dv_1";
            this.multiLayoutItem181.IsUpdItem = true;
            // 
            // multiLayoutItem182
            // 
            this.multiLayoutItem182.DataName = "dv_2";
            this.multiLayoutItem182.IsUpdItem = true;
            // 
            // multiLayoutItem183
            // 
            this.multiLayoutItem183.DataName = "dv_3";
            this.multiLayoutItem183.IsUpdItem = true;
            // 
            // multiLayoutItem184
            // 
            this.multiLayoutItem184.DataName = "dv_4";
            this.multiLayoutItem184.IsUpdItem = true;
            // 
            // multiLayoutItem185
            // 
            this.multiLayoutItem185.DataName = "nalsu";
            this.multiLayoutItem185.IsUpdItem = true;
            // 
            // multiLayoutItem186
            // 
            this.multiLayoutItem186.DataName = "sunab_nalsu";
            this.multiLayoutItem186.IsUpdItem = true;
            // 
            // multiLayoutItem187
            // 
            this.multiLayoutItem187.DataName = "jusa";
            this.multiLayoutItem187.IsUpdItem = true;
            // 
            // multiLayoutItem188
            // 
            this.multiLayoutItem188.DataName = "jusa_name";
            this.multiLayoutItem188.IsUpdItem = true;
            // 
            // multiLayoutItem189
            // 
            this.multiLayoutItem189.DataName = "jusa_spd_gubun";
            this.multiLayoutItem189.IsUpdItem = true;
            // 
            // multiLayoutItem190
            // 
            this.multiLayoutItem190.DataName = "bogyong_code";
            this.multiLayoutItem190.IsUpdItem = true;
            // 
            // multiLayoutItem191
            // 
            this.multiLayoutItem191.DataName = "bogyong_name";
            this.multiLayoutItem191.IsUpdItem = true;
            // 
            // multiLayoutItem192
            // 
            this.multiLayoutItem192.DataName = "emergency";
            this.multiLayoutItem192.IsUpdItem = true;
            // 
            // multiLayoutItem193
            // 
            this.multiLayoutItem193.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem193.IsUpdItem = true;
            // 
            // multiLayoutItem194
            // 
            this.multiLayoutItem194.DataName = "jundal_table";
            this.multiLayoutItem194.IsUpdItem = true;
            // 
            // multiLayoutItem195
            // 
            this.multiLayoutItem195.DataName = "jundal_part";
            this.multiLayoutItem195.IsUpdItem = true;
            // 
            // multiLayoutItem196
            // 
            this.multiLayoutItem196.DataName = "move_part";
            this.multiLayoutItem196.IsUpdItem = true;
            // 
            // multiLayoutItem197
            // 
            this.multiLayoutItem197.DataName = "portable_yn";
            this.multiLayoutItem197.IsUpdItem = true;
            // 
            // multiLayoutItem198
            // 
            this.multiLayoutItem198.DataName = "powder_yn";
            this.multiLayoutItem198.IsUpdItem = true;
            // 
            // multiLayoutItem199
            // 
            this.multiLayoutItem199.DataName = "hubal_change_yn";
            this.multiLayoutItem199.IsUpdItem = true;
            // 
            // multiLayoutItem200
            // 
            this.multiLayoutItem200.DataName = "pharmacy";
            this.multiLayoutItem200.IsUpdItem = true;
            // 
            // multiLayoutItem201
            // 
            this.multiLayoutItem201.DataName = "drg_pack_yn";
            this.multiLayoutItem201.IsUpdItem = true;
            // 
            // multiLayoutItem202
            // 
            this.multiLayoutItem202.DataName = "muhyo";
            this.multiLayoutItem202.IsUpdItem = true;
            // 
            // multiLayoutItem203
            // 
            this.multiLayoutItem203.DataName = "prn_yn";
            this.multiLayoutItem203.IsUpdItem = true;
            // 
            // multiLayoutItem204
            // 
            this.multiLayoutItem204.DataName = "toiwon_drg_yn";
            this.multiLayoutItem204.IsUpdItem = true;
            // 
            // multiLayoutItem205
            // 
            this.multiLayoutItem205.DataName = "prn_nurse";
            this.multiLayoutItem205.IsUpdItem = true;
            // 
            // multiLayoutItem206
            // 
            this.multiLayoutItem206.DataName = "append_yn";
            this.multiLayoutItem206.IsUpdItem = true;
            // 
            // multiLayoutItem207
            // 
            this.multiLayoutItem207.DataName = "order_remark";
            this.multiLayoutItem207.IsUpdItem = true;
            // 
            // multiLayoutItem208
            // 
            this.multiLayoutItem208.DataName = "nurse_remark";
            this.multiLayoutItem208.IsUpdItem = true;
            // 
            // multiLayoutItem209
            // 
            this.multiLayoutItem209.DataName = "comment";
            this.multiLayoutItem209.IsUpdItem = true;
            // 
            // multiLayoutItem210
            // 
            this.multiLayoutItem210.DataName = "mix_group";
            this.multiLayoutItem210.IsUpdItem = true;
            // 
            // multiLayoutItem211
            // 
            this.multiLayoutItem211.DataName = "amt";
            this.multiLayoutItem211.IsUpdItem = true;
            // 
            // multiLayoutItem212
            // 
            this.multiLayoutItem212.DataName = "pay";
            this.multiLayoutItem212.IsUpdItem = true;
            // 
            // multiLayoutItem213
            // 
            this.multiLayoutItem213.DataName = "wonyoi_order_yn";
            this.multiLayoutItem213.IsUpdItem = true;
            // 
            // multiLayoutItem214
            // 
            this.multiLayoutItem214.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem214.IsUpdItem = true;
            // 
            // multiLayoutItem215
            // 
            this.multiLayoutItem215.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem215.IsUpdItem = true;
            // 
            // multiLayoutItem216
            // 
            this.multiLayoutItem216.DataName = "bom_occur_yn";
            this.multiLayoutItem216.IsUpdItem = true;
            // 
            // multiLayoutItem217
            // 
            this.multiLayoutItem217.DataName = "bom_source_key";
            this.multiLayoutItem217.IsUpdItem = true;
            // 
            // multiLayoutItem218
            // 
            this.multiLayoutItem218.DataName = "display_yn";
            this.multiLayoutItem218.IsUpdItem = true;
            // 
            // multiLayoutItem219
            // 
            this.multiLayoutItem219.DataName = "sunab_yn";
            this.multiLayoutItem219.IsUpdItem = true;
            // 
            // multiLayoutItem220
            // 
            this.multiLayoutItem220.DataName = "sunab_date";
            this.multiLayoutItem220.IsUpdItem = true;
            // 
            // multiLayoutItem221
            // 
            this.multiLayoutItem221.DataName = "sunab_time";
            this.multiLayoutItem221.IsUpdItem = true;
            // 
            // multiLayoutItem222
            // 
            this.multiLayoutItem222.DataName = "hope_date";
            this.multiLayoutItem222.IsUpdItem = true;
            // 
            // multiLayoutItem223
            // 
            this.multiLayoutItem223.DataName = "hope_time";
            this.multiLayoutItem223.IsUpdItem = true;
            // 
            // multiLayoutItem224
            // 
            this.multiLayoutItem224.DataName = "nurse_confirm_user";
            this.multiLayoutItem224.IsUpdItem = true;
            // 
            // multiLayoutItem225
            // 
            this.multiLayoutItem225.DataName = "nurse_confirm_date";
            this.multiLayoutItem225.IsUpdItem = true;
            // 
            // multiLayoutItem226
            // 
            this.multiLayoutItem226.DataName = "nurse_confirm_time";
            this.multiLayoutItem226.IsUpdItem = true;
            // 
            // multiLayoutItem227
            // 
            this.multiLayoutItem227.DataName = "nurse_pickup_user";
            this.multiLayoutItem227.IsUpdItem = true;
            // 
            // multiLayoutItem228
            // 
            this.multiLayoutItem228.DataName = "nurse_pickup_date";
            this.multiLayoutItem228.IsUpdItem = true;
            // 
            // multiLayoutItem229
            // 
            this.multiLayoutItem229.DataName = "nurse_pickup_time";
            this.multiLayoutItem229.IsUpdItem = true;
            // 
            // multiLayoutItem230
            // 
            this.multiLayoutItem230.DataName = "nurse_hold_user";
            this.multiLayoutItem230.IsUpdItem = true;
            // 
            // multiLayoutItem231
            // 
            this.multiLayoutItem231.DataName = "nurse_hold_date";
            this.multiLayoutItem231.IsUpdItem = true;
            // 
            // multiLayoutItem232
            // 
            this.multiLayoutItem232.DataName = "nurse_hold_time";
            this.multiLayoutItem232.IsUpdItem = true;
            // 
            // multiLayoutItem233
            // 
            this.multiLayoutItem233.DataName = "reser_date";
            this.multiLayoutItem233.IsUpdItem = true;
            // 
            // multiLayoutItem234
            // 
            this.multiLayoutItem234.DataName = "reser_time";
            this.multiLayoutItem234.IsUpdItem = true;
            // 
            // multiLayoutItem235
            // 
            this.multiLayoutItem235.DataName = "jubsu_date";
            this.multiLayoutItem235.IsUpdItem = true;
            // 
            // multiLayoutItem236
            // 
            this.multiLayoutItem236.DataName = "jubsu_time";
            this.multiLayoutItem236.IsUpdItem = true;
            // 
            // multiLayoutItem237
            // 
            this.multiLayoutItem237.DataName = "acting_date";
            this.multiLayoutItem237.IsUpdItem = true;
            // 
            // multiLayoutItem238
            // 
            this.multiLayoutItem238.DataName = "acting_time";
            this.multiLayoutItem238.IsUpdItem = true;
            // 
            // multiLayoutItem239
            // 
            this.multiLayoutItem239.DataName = "acting_day";
            this.multiLayoutItem239.IsUpdItem = true;
            // 
            // multiLayoutItem240
            // 
            this.multiLayoutItem240.DataName = "result_date";
            this.multiLayoutItem240.IsUpdItem = true;
            // 
            // multiLayoutItem241
            // 
            this.multiLayoutItem241.DataName = "dc_gubun";
            this.multiLayoutItem241.IsUpdItem = true;
            // 
            // multiLayoutItem242
            // 
            this.multiLayoutItem242.DataName = "dc_yn";
            this.multiLayoutItem242.IsUpdItem = true;
            // 
            // multiLayoutItem243
            // 
            this.multiLayoutItem243.DataName = "bannab_yn";
            this.multiLayoutItem243.IsUpdItem = true;
            // 
            // multiLayoutItem244
            // 
            this.multiLayoutItem244.DataName = "bannab_confirm";
            this.multiLayoutItem244.IsUpdItem = true;
            // 
            // multiLayoutItem245
            // 
            this.multiLayoutItem245.DataName = "source_ord_key";
            this.multiLayoutItem245.IsUpdItem = true;
            // 
            // multiLayoutItem246
            // 
            this.multiLayoutItem246.DataName = "ocs_flag";
            this.multiLayoutItem246.IsUpdItem = true;
            // 
            // multiLayoutItem247
            // 
            this.multiLayoutItem247.DataName = "sg_code";
            this.multiLayoutItem247.IsUpdItem = true;
            // 
            // multiLayoutItem248
            // 
            this.multiLayoutItem248.DataName = "sg_ymd";
            this.multiLayoutItem248.IsUpdItem = true;
            // 
            // multiLayoutItem249
            // 
            this.multiLayoutItem249.DataName = "io_gubun";
            this.multiLayoutItem249.IsUpdItem = true;
            // 
            // multiLayoutItem250
            // 
            this.multiLayoutItem250.DataName = "after_act_yn";
            this.multiLayoutItem250.IsUpdItem = true;
            // 
            // multiLayoutItem251
            // 
            this.multiLayoutItem251.DataName = "bichi_yn";
            this.multiLayoutItem251.IsUpdItem = true;
            // 
            // multiLayoutItem252
            // 
            this.multiLayoutItem252.DataName = "drg_bunho";
            this.multiLayoutItem252.IsUpdItem = true;
            // 
            // multiLayoutItem253
            // 
            this.multiLayoutItem253.DataName = "sub_susul";
            this.multiLayoutItem253.IsUpdItem = true;
            // 
            // multiLayoutItem254
            // 
            this.multiLayoutItem254.DataName = "print_yn";
            this.multiLayoutItem254.IsUpdItem = true;
            // 
            // multiLayoutItem255
            // 
            this.multiLayoutItem255.DataName = "chisik";
            this.multiLayoutItem255.IsUpdItem = true;
            // 
            // multiLayoutItem256
            // 
            this.multiLayoutItem256.DataName = "tel_yn";
            this.multiLayoutItem256.IsUpdItem = true;
            // 
            // multiLayoutItem257
            // 
            this.multiLayoutItem257.DataName = "order_gubun_bas";
            this.multiLayoutItem257.IsUpdItem = true;
            // 
            // multiLayoutItem258
            // 
            this.multiLayoutItem258.DataName = "input_control";
            this.multiLayoutItem258.IsUpdItem = true;
            // 
            // multiLayoutItem259
            // 
            this.multiLayoutItem259.DataName = "suga_yn";
            this.multiLayoutItem259.IsUpdItem = true;
            // 
            // multiLayoutItem260
            // 
            this.multiLayoutItem260.DataName = "jaeryo_yn";
            this.multiLayoutItem260.IsUpdItem = true;
            // 
            // multiLayoutItem261
            // 
            this.multiLayoutItem261.DataName = "wonyoi_check";
            this.multiLayoutItem261.IsUpdItem = true;
            // 
            // multiLayoutItem262
            // 
            this.multiLayoutItem262.DataName = "emergency_check";
            this.multiLayoutItem262.IsUpdItem = true;
            // 
            // multiLayoutItem263
            // 
            this.multiLayoutItem263.DataName = "specimen_check";
            // 
            // multiLayoutItem264
            // 
            this.multiLayoutItem264.DataName = "portable_check";
            this.multiLayoutItem264.IsUpdItem = true;
            // 
            // multiLayoutItem265
            // 
            this.multiLayoutItem265.DataName = "bulyong_check";
            this.multiLayoutItem265.IsUpdItem = true;
            // 
            // multiLayoutItem266
            // 
            this.multiLayoutItem266.DataName = "sunab_check";
            // 
            // multiLayoutItem267
            // 
            this.multiLayoutItem267.DataName = "dc_check";
            // 
            // multiLayoutItem268
            // 
            this.multiLayoutItem268.DataName = "dc_gubun_check";
            this.multiLayoutItem268.IsUpdItem = true;
            // 
            // multiLayoutItem269
            // 
            this.multiLayoutItem269.DataName = "confirm_check";
            this.multiLayoutItem269.IsUpdItem = true;
            // 
            // multiLayoutItem270
            // 
            this.multiLayoutItem270.DataName = "reser_yn_check";
            this.multiLayoutItem270.IsUpdItem = true;
            // 
            // multiLayoutItem271
            // 
            this.multiLayoutItem271.DataName = "chisik_check";
            this.multiLayoutItem271.IsUpdItem = true;
            // 
            // multiLayoutItem272
            // 
            this.multiLayoutItem272.DataName = "nday_yn";
            this.multiLayoutItem272.IsUpdItem = true;
            // 
            // multiLayoutItem273
            // 
            this.multiLayoutItem273.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem273.IsUpdItem = true;
            // 
            // multiLayoutItem274
            // 
            this.multiLayoutItem274.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem274.IsUpdItem = true;
            // 
            // multiLayoutItem275
            // 
            this.multiLayoutItem275.DataName = "specific_comment";
            this.multiLayoutItem275.IsUpdItem = true;
            // 
            // multiLayoutItem276
            // 
            this.multiLayoutItem276.DataName = "specific_comment_name";
            this.multiLayoutItem276.IsUpdItem = true;
            // 
            // multiLayoutItem277
            // 
            this.multiLayoutItem277.DataName = "specific_comment_sys_id";
            this.multiLayoutItem277.IsUpdItem = true;
            // 
            // multiLayoutItem278
            // 
            this.multiLayoutItem278.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem278.IsUpdItem = true;
            // 
            // multiLayoutItem279
            // 
            this.multiLayoutItem279.DataName = "specific_comment_not_null";
            this.multiLayoutItem279.IsUpdItem = true;
            // 
            // multiLayoutItem280
            // 
            this.multiLayoutItem280.DataName = "specific_comment_table_id";
            this.multiLayoutItem280.IsUpdItem = true;
            // 
            // multiLayoutItem281
            // 
            this.multiLayoutItem281.DataName = "specific_comment_col_id";
            this.multiLayoutItem281.IsUpdItem = true;
            // 
            // multiLayoutItem282
            // 
            this.multiLayoutItem282.DataName = "donbog_yn";
            this.multiLayoutItem282.IsUpdItem = true;
            // 
            // multiLayoutItem283
            // 
            this.multiLayoutItem283.DataName = "order_gubun_bas_name";
            this.multiLayoutItem283.IsUpdItem = true;
            // 
            // multiLayoutItem707
            // 
            this.multiLayoutItem707.DataName = "act_doctoor";
            this.multiLayoutItem707.IsUpdItem = true;
            // 
            // multiLayoutItem708
            // 
            this.multiLayoutItem708.DataName = "act_buseo";
            this.multiLayoutItem708.IsUpdItem = true;
            // 
            // multiLayoutItem709
            // 
            this.multiLayoutItem709.DataName = "act_gwa";
            this.multiLayoutItem709.IsUpdItem = true;
            // 
            // multiLayoutItem710
            // 
            this.multiLayoutItem710.DataName = "home_care_yn";
            this.multiLayoutItem710.IsUpdItem = true;
            // 
            // multiLayoutItem721
            // 
            this.multiLayoutItem721.DataName = "regular_yn";
            this.multiLayoutItem721.IsUpdItem = true;
            // 
            // multiLayoutItem722
            // 
            this.multiLayoutItem722.DataName = "sort_fkocskey";
            this.multiLayoutItem722.IsUpdItem = true;
            // 
            // multiLayoutItem1022
            // 
            this.multiLayoutItem1022.DataName = "child_yn";
            this.multiLayoutItem1022.IsUpdItem = true;
            // 
            // multiLayoutItem1023
            // 
            this.multiLayoutItem1023.DataName = "if_input_control";
            // 
            // multiLayoutItem1041
            // 
            this.multiLayoutItem1041.DataName = "slip_name";
            // 
            // multiLayoutItem1186
            // 
            this.multiLayoutItem1186.DataName = "org_key";
            // 
            // multiLayoutItem1187
            // 
            this.multiLayoutItem1187.DataName = "parent_key";
            // 
            // multiLayoutItem1935
            // 
            this.multiLayoutItem1935.DataName = "bun_code";
            // 
            // multiLayoutItem1951
            // 
            this.multiLayoutItem1951.DataName = "wonnae_drg_yn";
            // 
            // layEtcOrder
            // 
            this.layEtcOrder.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1188,
            this.multiLayoutItem1189,
            this.multiLayoutItem1190,
            this.multiLayoutItem1191,
            this.multiLayoutItem1192,
            this.multiLayoutItem1193,
            this.multiLayoutItem1194,
            this.multiLayoutItem1195,
            this.multiLayoutItem1196,
            this.multiLayoutItem1197,
            this.multiLayoutItem1198,
            this.multiLayoutItem1199,
            this.multiLayoutItem1200,
            this.multiLayoutItem1201,
            this.multiLayoutItem1202,
            this.multiLayoutItem1203,
            this.multiLayoutItem1204,
            this.multiLayoutItem1205,
            this.multiLayoutItem1206,
            this.multiLayoutItem1207,
            this.multiLayoutItem1208,
            this.multiLayoutItem1209,
            this.multiLayoutItem1210,
            this.multiLayoutItem1211,
            this.multiLayoutItem1212,
            this.multiLayoutItem1213,
            this.multiLayoutItem1214,
            this.multiLayoutItem1215,
            this.multiLayoutItem1216,
            this.multiLayoutItem1217,
            this.multiLayoutItem1218,
            this.multiLayoutItem1219,
            this.multiLayoutItem1220,
            this.multiLayoutItem1221,
            this.multiLayoutItem1222,
            this.multiLayoutItem1223,
            this.multiLayoutItem1224,
            this.multiLayoutItem1225,
            this.multiLayoutItem1226,
            this.multiLayoutItem1227,
            this.multiLayoutItem1228,
            this.multiLayoutItem1229,
            this.multiLayoutItem1230,
            this.multiLayoutItem1231,
            this.multiLayoutItem1232,
            this.multiLayoutItem1233,
            this.multiLayoutItem1234,
            this.multiLayoutItem1235,
            this.multiLayoutItem1236,
            this.multiLayoutItem1237,
            this.multiLayoutItem1238,
            this.multiLayoutItem1239,
            this.multiLayoutItem1240,
            this.multiLayoutItem1241,
            this.multiLayoutItem1242,
            this.multiLayoutItem1243,
            this.multiLayoutItem1244,
            this.multiLayoutItem1245,
            this.multiLayoutItem1246,
            this.multiLayoutItem1247,
            this.multiLayoutItem1248,
            this.multiLayoutItem1249,
            this.multiLayoutItem1250,
            this.multiLayoutItem1251,
            this.multiLayoutItem1252,
            this.multiLayoutItem1253,
            this.multiLayoutItem1254,
            this.multiLayoutItem1255,
            this.multiLayoutItem1256,
            this.multiLayoutItem1257,
            this.multiLayoutItem1258,
            this.multiLayoutItem1259,
            this.multiLayoutItem1260,
            this.multiLayoutItem1261,
            this.multiLayoutItem1262,
            this.multiLayoutItem1263,
            this.multiLayoutItem1264,
            this.multiLayoutItem1265,
            this.multiLayoutItem1266,
            this.multiLayoutItem1267,
            this.multiLayoutItem1268,
            this.multiLayoutItem1269,
            this.multiLayoutItem1270,
            this.multiLayoutItem1271,
            this.multiLayoutItem1272,
            this.multiLayoutItem1273,
            this.multiLayoutItem1274,
            this.multiLayoutItem1275,
            this.multiLayoutItem1276,
            this.multiLayoutItem1277,
            this.multiLayoutItem1278,
            this.multiLayoutItem1279,
            this.multiLayoutItem1280,
            this.multiLayoutItem1281,
            this.multiLayoutItem1282,
            this.multiLayoutItem1283,
            this.multiLayoutItem1284,
            this.multiLayoutItem1285,
            this.multiLayoutItem1286,
            this.multiLayoutItem1287,
            this.multiLayoutItem1288,
            this.multiLayoutItem1289,
            this.multiLayoutItem1290,
            this.multiLayoutItem1291,
            this.multiLayoutItem1292,
            this.multiLayoutItem1293,
            this.multiLayoutItem1294,
            this.multiLayoutItem1295,
            this.multiLayoutItem1296,
            this.multiLayoutItem1297,
            this.multiLayoutItem1298,
            this.multiLayoutItem1299,
            this.multiLayoutItem1300,
            this.multiLayoutItem1301,
            this.multiLayoutItem1302,
            this.multiLayoutItem1303,
            this.multiLayoutItem1304,
            this.multiLayoutItem1305,
            this.multiLayoutItem1306,
            this.multiLayoutItem1307,
            this.multiLayoutItem1308,
            this.multiLayoutItem1309,
            this.multiLayoutItem1310,
            this.multiLayoutItem1311,
            this.multiLayoutItem1312,
            this.multiLayoutItem1313,
            this.multiLayoutItem1314,
            this.multiLayoutItem1315,
            this.multiLayoutItem1316,
            this.multiLayoutItem1317,
            this.multiLayoutItem1318,
            this.multiLayoutItem1319,
            this.multiLayoutItem1320,
            this.multiLayoutItem1321,
            this.multiLayoutItem1322,
            this.multiLayoutItem1323,
            this.multiLayoutItem1324,
            this.multiLayoutItem1325,
            this.multiLayoutItem1326,
            this.multiLayoutItem1327,
            this.multiLayoutItem1328,
            this.multiLayoutItem1329,
            this.multiLayoutItem1330,
            this.multiLayoutItem1331,
            this.multiLayoutItem1332,
            this.multiLayoutItem1333,
            this.multiLayoutItem1334,
            this.multiLayoutItem1335,
            this.multiLayoutItem1936,
            this.multiLayoutItem1952});
            // 
            // multiLayoutItem1188
            // 
            this.multiLayoutItem1188.DataName = "in_out_key";
            this.multiLayoutItem1188.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem1188.IsUpdItem = true;
            // 
            // multiLayoutItem1189
            // 
            this.multiLayoutItem1189.DataName = "pkocskey";
            this.multiLayoutItem1189.IsUpdItem = true;
            // 
            // multiLayoutItem1190
            // 
            this.multiLayoutItem1190.DataName = "bunho";
            this.multiLayoutItem1190.IsUpdItem = true;
            // 
            // multiLayoutItem1191
            // 
            this.multiLayoutItem1191.DataName = "order_date";
            this.multiLayoutItem1191.IsUpdItem = true;
            // 
            // multiLayoutItem1192
            // 
            this.multiLayoutItem1192.DataName = "gwa";
            this.multiLayoutItem1192.IsUpdItem = true;
            // 
            // multiLayoutItem1193
            // 
            this.multiLayoutItem1193.DataName = "doctor";
            this.multiLayoutItem1193.IsUpdItem = true;
            // 
            // multiLayoutItem1194
            // 
            this.multiLayoutItem1194.DataName = "resident";
            this.multiLayoutItem1194.IsUpdItem = true;
            // 
            // multiLayoutItem1195
            // 
            this.multiLayoutItem1195.DataName = "naewon_type";
            this.multiLayoutItem1195.IsUpdItem = true;
            // 
            // multiLayoutItem1196
            // 
            this.multiLayoutItem1196.DataName = "jubsu_no";
            this.multiLayoutItem1196.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem1196.IsUpdItem = true;
            // 
            // multiLayoutItem1197
            // 
            this.multiLayoutItem1197.DataName = "input_id";
            this.multiLayoutItem1197.IsUpdItem = true;
            // 
            // multiLayoutItem1198
            // 
            this.multiLayoutItem1198.DataName = "input_part";
            this.multiLayoutItem1198.IsUpdItem = true;
            // 
            // multiLayoutItem1199
            // 
            this.multiLayoutItem1199.DataName = "input_gwa";
            this.multiLayoutItem1199.IsUpdItem = true;
            // 
            // multiLayoutItem1200
            // 
            this.multiLayoutItem1200.DataName = "input_doctor";
            this.multiLayoutItem1200.IsUpdItem = true;
            // 
            // multiLayoutItem1201
            // 
            this.multiLayoutItem1201.DataName = "input_gubun";
            this.multiLayoutItem1201.IsUpdItem = true;
            // 
            // multiLayoutItem1202
            // 
            this.multiLayoutItem1202.DataName = "input_gubun_name";
            // 
            // multiLayoutItem1203
            // 
            this.multiLayoutItem1203.DataName = "group_ser";
            this.multiLayoutItem1203.IsUpdItem = true;
            // 
            // multiLayoutItem1204
            // 
            this.multiLayoutItem1204.DataName = "input_tab";
            this.multiLayoutItem1204.IsUpdItem = true;
            // 
            // multiLayoutItem1205
            // 
            this.multiLayoutItem1205.DataName = "input_tab_name";
            // 
            // multiLayoutItem1206
            // 
            this.multiLayoutItem1206.DataName = "order_gubun";
            this.multiLayoutItem1206.IsUpdItem = true;
            // 
            // multiLayoutItem1207
            // 
            this.multiLayoutItem1207.DataName = "order_gubun_name";
            // 
            // multiLayoutItem1208
            // 
            this.multiLayoutItem1208.DataName = "group_yn";
            this.multiLayoutItem1208.IsUpdItem = true;
            // 
            // multiLayoutItem1209
            // 
            this.multiLayoutItem1209.DataName = "seq";
            this.multiLayoutItem1209.IsUpdItem = true;
            // 
            // multiLayoutItem1210
            // 
            this.multiLayoutItem1210.DataName = "slip_code";
            this.multiLayoutItem1210.IsUpdItem = true;
            // 
            // multiLayoutItem1211
            // 
            this.multiLayoutItem1211.DataName = "hangmog_code";
            this.multiLayoutItem1211.IsUpdItem = true;
            // 
            // multiLayoutItem1212
            // 
            this.multiLayoutItem1212.DataName = "hangmog_name";
            // 
            // multiLayoutItem1213
            // 
            this.multiLayoutItem1213.DataName = "specimen_code";
            this.multiLayoutItem1213.IsUpdItem = true;
            // 
            // multiLayoutItem1214
            // 
            this.multiLayoutItem1214.DataName = "specimen_name";
            // 
            // multiLayoutItem1215
            // 
            this.multiLayoutItem1215.DataName = "suryang";
            this.multiLayoutItem1215.IsUpdItem = true;
            // 
            // multiLayoutItem1216
            // 
            this.multiLayoutItem1216.DataName = "sunab_suryang";
            this.multiLayoutItem1216.IsUpdItem = true;
            // 
            // multiLayoutItem1217
            // 
            this.multiLayoutItem1217.DataName = "subul_suryang";
            this.multiLayoutItem1217.IsUpdItem = true;
            // 
            // multiLayoutItem1218
            // 
            this.multiLayoutItem1218.DataName = "ord_danui";
            this.multiLayoutItem1218.IsUpdItem = true;
            // 
            // multiLayoutItem1219
            // 
            this.multiLayoutItem1219.DataName = "ord_danui_name";
            // 
            // multiLayoutItem1220
            // 
            this.multiLayoutItem1220.DataName = "dv_time";
            this.multiLayoutItem1220.IsUpdItem = true;
            // 
            // multiLayoutItem1221
            // 
            this.multiLayoutItem1221.DataName = "dv";
            this.multiLayoutItem1221.IsUpdItem = true;
            // 
            // multiLayoutItem1222
            // 
            this.multiLayoutItem1222.DataName = "dv_1";
            this.multiLayoutItem1222.IsUpdItem = true;
            // 
            // multiLayoutItem1223
            // 
            this.multiLayoutItem1223.DataName = "dv_2";
            this.multiLayoutItem1223.IsUpdItem = true;
            // 
            // multiLayoutItem1224
            // 
            this.multiLayoutItem1224.DataName = "dv_3";
            this.multiLayoutItem1224.IsUpdItem = true;
            // 
            // multiLayoutItem1225
            // 
            this.multiLayoutItem1225.DataName = "dv_4";
            this.multiLayoutItem1225.IsUpdItem = true;
            // 
            // multiLayoutItem1226
            // 
            this.multiLayoutItem1226.DataName = "nalsu";
            this.multiLayoutItem1226.IsUpdItem = true;
            // 
            // multiLayoutItem1227
            // 
            this.multiLayoutItem1227.DataName = "sunab_nalsu";
            this.multiLayoutItem1227.IsUpdItem = true;
            // 
            // multiLayoutItem1228
            // 
            this.multiLayoutItem1228.DataName = "jusa";
            this.multiLayoutItem1228.IsUpdItem = true;
            // 
            // multiLayoutItem1229
            // 
            this.multiLayoutItem1229.DataName = "jusa_name";
            this.multiLayoutItem1229.IsUpdItem = true;
            // 
            // multiLayoutItem1230
            // 
            this.multiLayoutItem1230.DataName = "jusa_spd_gubun";
            this.multiLayoutItem1230.IsUpdItem = true;
            // 
            // multiLayoutItem1231
            // 
            this.multiLayoutItem1231.DataName = "bogyong_code";
            this.multiLayoutItem1231.IsUpdItem = true;
            // 
            // multiLayoutItem1232
            // 
            this.multiLayoutItem1232.DataName = "bogyong_name";
            this.multiLayoutItem1232.IsUpdItem = true;
            // 
            // multiLayoutItem1233
            // 
            this.multiLayoutItem1233.DataName = "emergency";
            this.multiLayoutItem1233.IsUpdItem = true;
            // 
            // multiLayoutItem1234
            // 
            this.multiLayoutItem1234.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem1234.IsUpdItem = true;
            // 
            // multiLayoutItem1235
            // 
            this.multiLayoutItem1235.DataName = "jundal_table";
            this.multiLayoutItem1235.IsUpdItem = true;
            // 
            // multiLayoutItem1236
            // 
            this.multiLayoutItem1236.DataName = "jundal_part";
            this.multiLayoutItem1236.IsUpdItem = true;
            // 
            // multiLayoutItem1237
            // 
            this.multiLayoutItem1237.DataName = "move_part";
            this.multiLayoutItem1237.IsUpdItem = true;
            // 
            // multiLayoutItem1238
            // 
            this.multiLayoutItem1238.DataName = "portable_yn";
            this.multiLayoutItem1238.IsUpdItem = true;
            // 
            // multiLayoutItem1239
            // 
            this.multiLayoutItem1239.DataName = "powder_yn";
            this.multiLayoutItem1239.IsUpdItem = true;
            // 
            // multiLayoutItem1240
            // 
            this.multiLayoutItem1240.DataName = "hubal_change_yn";
            this.multiLayoutItem1240.IsUpdItem = true;
            // 
            // multiLayoutItem1241
            // 
            this.multiLayoutItem1241.DataName = "pharmacy";
            this.multiLayoutItem1241.IsUpdItem = true;
            // 
            // multiLayoutItem1242
            // 
            this.multiLayoutItem1242.DataName = "drg_pack_yn";
            this.multiLayoutItem1242.IsUpdItem = true;
            // 
            // multiLayoutItem1243
            // 
            this.multiLayoutItem1243.DataName = "muhyo";
            this.multiLayoutItem1243.IsUpdItem = true;
            // 
            // multiLayoutItem1244
            // 
            this.multiLayoutItem1244.DataName = "prn_yn";
            this.multiLayoutItem1244.IsUpdItem = true;
            // 
            // multiLayoutItem1245
            // 
            this.multiLayoutItem1245.DataName = "toiwon_drg_yn";
            this.multiLayoutItem1245.IsUpdItem = true;
            // 
            // multiLayoutItem1246
            // 
            this.multiLayoutItem1246.DataName = "prn_nurse";
            this.multiLayoutItem1246.IsUpdItem = true;
            // 
            // multiLayoutItem1247
            // 
            this.multiLayoutItem1247.DataName = "append_yn";
            this.multiLayoutItem1247.IsUpdItem = true;
            // 
            // multiLayoutItem1248
            // 
            this.multiLayoutItem1248.DataName = "order_remark";
            this.multiLayoutItem1248.IsUpdItem = true;
            // 
            // multiLayoutItem1249
            // 
            this.multiLayoutItem1249.DataName = "nurse_remark";
            this.multiLayoutItem1249.IsUpdItem = true;
            // 
            // multiLayoutItem1250
            // 
            this.multiLayoutItem1250.DataName = "comment";
            this.multiLayoutItem1250.IsUpdItem = true;
            // 
            // multiLayoutItem1251
            // 
            this.multiLayoutItem1251.DataName = "mix_group";
            this.multiLayoutItem1251.IsUpdItem = true;
            // 
            // multiLayoutItem1252
            // 
            this.multiLayoutItem1252.DataName = "amt";
            this.multiLayoutItem1252.IsUpdItem = true;
            // 
            // multiLayoutItem1253
            // 
            this.multiLayoutItem1253.DataName = "pay";
            this.multiLayoutItem1253.IsUpdItem = true;
            // 
            // multiLayoutItem1254
            // 
            this.multiLayoutItem1254.DataName = "wonyoi_order_yn";
            this.multiLayoutItem1254.IsUpdItem = true;
            // 
            // multiLayoutItem1255
            // 
            this.multiLayoutItem1255.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem1255.IsUpdItem = true;
            // 
            // multiLayoutItem1256
            // 
            this.multiLayoutItem1256.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem1256.IsUpdItem = true;
            // 
            // multiLayoutItem1257
            // 
            this.multiLayoutItem1257.DataName = "bom_occur_yn";
            this.multiLayoutItem1257.IsUpdItem = true;
            // 
            // multiLayoutItem1258
            // 
            this.multiLayoutItem1258.DataName = "bom_source_key";
            this.multiLayoutItem1258.IsUpdItem = true;
            // 
            // multiLayoutItem1259
            // 
            this.multiLayoutItem1259.DataName = "display_yn";
            this.multiLayoutItem1259.IsUpdItem = true;
            // 
            // multiLayoutItem1260
            // 
            this.multiLayoutItem1260.DataName = "sunab_yn";
            this.multiLayoutItem1260.IsUpdItem = true;
            // 
            // multiLayoutItem1261
            // 
            this.multiLayoutItem1261.DataName = "sunab_date";
            this.multiLayoutItem1261.IsUpdItem = true;
            // 
            // multiLayoutItem1262
            // 
            this.multiLayoutItem1262.DataName = "sunab_time";
            this.multiLayoutItem1262.IsUpdItem = true;
            // 
            // multiLayoutItem1263
            // 
            this.multiLayoutItem1263.DataName = "hope_date";
            this.multiLayoutItem1263.IsUpdItem = true;
            // 
            // multiLayoutItem1264
            // 
            this.multiLayoutItem1264.DataName = "hope_time";
            this.multiLayoutItem1264.IsUpdItem = true;
            // 
            // multiLayoutItem1265
            // 
            this.multiLayoutItem1265.DataName = "nurse_confirm_user";
            this.multiLayoutItem1265.IsUpdItem = true;
            // 
            // multiLayoutItem1266
            // 
            this.multiLayoutItem1266.DataName = "nurse_confirm_date";
            this.multiLayoutItem1266.IsUpdItem = true;
            // 
            // multiLayoutItem1267
            // 
            this.multiLayoutItem1267.DataName = "nurse_confirm_time";
            this.multiLayoutItem1267.IsUpdItem = true;
            // 
            // multiLayoutItem1268
            // 
            this.multiLayoutItem1268.DataName = "nurse_pickup_user";
            this.multiLayoutItem1268.IsUpdItem = true;
            // 
            // multiLayoutItem1269
            // 
            this.multiLayoutItem1269.DataName = "nurse_pickup_date";
            this.multiLayoutItem1269.IsUpdItem = true;
            // 
            // multiLayoutItem1270
            // 
            this.multiLayoutItem1270.DataName = "nurse_pickup_time";
            this.multiLayoutItem1270.IsUpdItem = true;
            // 
            // multiLayoutItem1271
            // 
            this.multiLayoutItem1271.DataName = "nurse_hold_user";
            this.multiLayoutItem1271.IsUpdItem = true;
            // 
            // multiLayoutItem1272
            // 
            this.multiLayoutItem1272.DataName = "nurse_hold_date";
            this.multiLayoutItem1272.IsUpdItem = true;
            // 
            // multiLayoutItem1273
            // 
            this.multiLayoutItem1273.DataName = "nurse_hold_time";
            this.multiLayoutItem1273.IsUpdItem = true;
            // 
            // multiLayoutItem1274
            // 
            this.multiLayoutItem1274.DataName = "reser_date";
            this.multiLayoutItem1274.IsUpdItem = true;
            // 
            // multiLayoutItem1275
            // 
            this.multiLayoutItem1275.DataName = "reser_time";
            this.multiLayoutItem1275.IsUpdItem = true;
            // 
            // multiLayoutItem1276
            // 
            this.multiLayoutItem1276.DataName = "jubsu_date";
            this.multiLayoutItem1276.IsUpdItem = true;
            // 
            // multiLayoutItem1277
            // 
            this.multiLayoutItem1277.DataName = "jubsu_time";
            this.multiLayoutItem1277.IsUpdItem = true;
            // 
            // multiLayoutItem1278
            // 
            this.multiLayoutItem1278.DataName = "acting_date";
            this.multiLayoutItem1278.IsUpdItem = true;
            // 
            // multiLayoutItem1279
            // 
            this.multiLayoutItem1279.DataName = "acting_time";
            this.multiLayoutItem1279.IsUpdItem = true;
            // 
            // multiLayoutItem1280
            // 
            this.multiLayoutItem1280.DataName = "acting_day";
            this.multiLayoutItem1280.IsUpdItem = true;
            // 
            // multiLayoutItem1281
            // 
            this.multiLayoutItem1281.DataName = "result_date";
            this.multiLayoutItem1281.IsUpdItem = true;
            // 
            // multiLayoutItem1282
            // 
            this.multiLayoutItem1282.DataName = "dc_gubun";
            this.multiLayoutItem1282.IsUpdItem = true;
            // 
            // multiLayoutItem1283
            // 
            this.multiLayoutItem1283.DataName = "dc_yn";
            this.multiLayoutItem1283.IsUpdItem = true;
            // 
            // multiLayoutItem1284
            // 
            this.multiLayoutItem1284.DataName = "bannab_yn";
            this.multiLayoutItem1284.IsUpdItem = true;
            // 
            // multiLayoutItem1285
            // 
            this.multiLayoutItem1285.DataName = "bannab_confirm";
            this.multiLayoutItem1285.IsUpdItem = true;
            // 
            // multiLayoutItem1286
            // 
            this.multiLayoutItem1286.DataName = "source_ord_key";
            this.multiLayoutItem1286.IsUpdItem = true;
            // 
            // multiLayoutItem1287
            // 
            this.multiLayoutItem1287.DataName = "ocs_flag";
            this.multiLayoutItem1287.IsUpdItem = true;
            // 
            // multiLayoutItem1288
            // 
            this.multiLayoutItem1288.DataName = "sg_code";
            this.multiLayoutItem1288.IsUpdItem = true;
            // 
            // multiLayoutItem1289
            // 
            this.multiLayoutItem1289.DataName = "sg_ymd";
            this.multiLayoutItem1289.IsUpdItem = true;
            // 
            // multiLayoutItem1290
            // 
            this.multiLayoutItem1290.DataName = "io_gubun";
            this.multiLayoutItem1290.IsUpdItem = true;
            // 
            // multiLayoutItem1291
            // 
            this.multiLayoutItem1291.DataName = "after_act_yn";
            this.multiLayoutItem1291.IsUpdItem = true;
            // 
            // multiLayoutItem1292
            // 
            this.multiLayoutItem1292.DataName = "bichi_yn";
            this.multiLayoutItem1292.IsUpdItem = true;
            // 
            // multiLayoutItem1293
            // 
            this.multiLayoutItem1293.DataName = "drg_bunho";
            this.multiLayoutItem1293.IsUpdItem = true;
            // 
            // multiLayoutItem1294
            // 
            this.multiLayoutItem1294.DataName = "sub_susul";
            this.multiLayoutItem1294.IsUpdItem = true;
            // 
            // multiLayoutItem1295
            // 
            this.multiLayoutItem1295.DataName = "print_yn";
            this.multiLayoutItem1295.IsUpdItem = true;
            // 
            // multiLayoutItem1296
            // 
            this.multiLayoutItem1296.DataName = "chisik";
            this.multiLayoutItem1296.IsUpdItem = true;
            // 
            // multiLayoutItem1297
            // 
            this.multiLayoutItem1297.DataName = "tel_yn";
            this.multiLayoutItem1297.IsUpdItem = true;
            // 
            // multiLayoutItem1298
            // 
            this.multiLayoutItem1298.DataName = "order_gubun_bas";
            this.multiLayoutItem1298.IsUpdItem = true;
            // 
            // multiLayoutItem1299
            // 
            this.multiLayoutItem1299.DataName = "input_control";
            this.multiLayoutItem1299.IsUpdItem = true;
            // 
            // multiLayoutItem1300
            // 
            this.multiLayoutItem1300.DataName = "suga_yn";
            this.multiLayoutItem1300.IsUpdItem = true;
            // 
            // multiLayoutItem1301
            // 
            this.multiLayoutItem1301.DataName = "jaeryo_yn";
            this.multiLayoutItem1301.IsUpdItem = true;
            // 
            // multiLayoutItem1302
            // 
            this.multiLayoutItem1302.DataName = "wonyoi_check";
            this.multiLayoutItem1302.IsUpdItem = true;
            // 
            // multiLayoutItem1303
            // 
            this.multiLayoutItem1303.DataName = "emergency_check";
            this.multiLayoutItem1303.IsUpdItem = true;
            // 
            // multiLayoutItem1304
            // 
            this.multiLayoutItem1304.DataName = "specimen_check";
            // 
            // multiLayoutItem1305
            // 
            this.multiLayoutItem1305.DataName = "portable_check";
            this.multiLayoutItem1305.IsUpdItem = true;
            // 
            // multiLayoutItem1306
            // 
            this.multiLayoutItem1306.DataName = "bulyong_check";
            this.multiLayoutItem1306.IsUpdItem = true;
            // 
            // multiLayoutItem1307
            // 
            this.multiLayoutItem1307.DataName = "sunab_check";
            // 
            // multiLayoutItem1308
            // 
            this.multiLayoutItem1308.DataName = "dc_check";
            // 
            // multiLayoutItem1309
            // 
            this.multiLayoutItem1309.DataName = "dc_gubun_check";
            this.multiLayoutItem1309.IsUpdItem = true;
            // 
            // multiLayoutItem1310
            // 
            this.multiLayoutItem1310.DataName = "confirm_check";
            this.multiLayoutItem1310.IsUpdItem = true;
            // 
            // multiLayoutItem1311
            // 
            this.multiLayoutItem1311.DataName = "reser_yn_check";
            this.multiLayoutItem1311.IsUpdItem = true;
            // 
            // multiLayoutItem1312
            // 
            this.multiLayoutItem1312.DataName = "chisik_check";
            this.multiLayoutItem1312.IsUpdItem = true;
            // 
            // multiLayoutItem1313
            // 
            this.multiLayoutItem1313.DataName = "nday_yn";
            this.multiLayoutItem1313.IsUpdItem = true;
            // 
            // multiLayoutItem1314
            // 
            this.multiLayoutItem1314.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem1314.IsUpdItem = true;
            // 
            // multiLayoutItem1315
            // 
            this.multiLayoutItem1315.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem1315.IsUpdItem = true;
            // 
            // multiLayoutItem1316
            // 
            this.multiLayoutItem1316.DataName = "specific_comment";
            this.multiLayoutItem1316.IsUpdItem = true;
            // 
            // multiLayoutItem1317
            // 
            this.multiLayoutItem1317.DataName = "specific_comment_name";
            this.multiLayoutItem1317.IsUpdItem = true;
            // 
            // multiLayoutItem1318
            // 
            this.multiLayoutItem1318.DataName = "specific_comment_sys_id";
            this.multiLayoutItem1318.IsUpdItem = true;
            // 
            // multiLayoutItem1319
            // 
            this.multiLayoutItem1319.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem1319.IsUpdItem = true;
            // 
            // multiLayoutItem1320
            // 
            this.multiLayoutItem1320.DataName = "specific_comment_not_null";
            this.multiLayoutItem1320.IsUpdItem = true;
            // 
            // multiLayoutItem1321
            // 
            this.multiLayoutItem1321.DataName = "specific_comment_table_id";
            this.multiLayoutItem1321.IsUpdItem = true;
            // 
            // multiLayoutItem1322
            // 
            this.multiLayoutItem1322.DataName = "specific_comment_col_id";
            this.multiLayoutItem1322.IsUpdItem = true;
            // 
            // multiLayoutItem1323
            // 
            this.multiLayoutItem1323.DataName = "donbog_yn";
            this.multiLayoutItem1323.IsUpdItem = true;
            // 
            // multiLayoutItem1324
            // 
            this.multiLayoutItem1324.DataName = "order_gubun_bas_name";
            this.multiLayoutItem1324.IsUpdItem = true;
            // 
            // multiLayoutItem1325
            // 
            this.multiLayoutItem1325.DataName = "act_doctoor";
            this.multiLayoutItem1325.IsUpdItem = true;
            // 
            // multiLayoutItem1326
            // 
            this.multiLayoutItem1326.DataName = "act_buseo";
            this.multiLayoutItem1326.IsUpdItem = true;
            // 
            // multiLayoutItem1327
            // 
            this.multiLayoutItem1327.DataName = "act_gwa";
            this.multiLayoutItem1327.IsUpdItem = true;
            // 
            // multiLayoutItem1328
            // 
            this.multiLayoutItem1328.DataName = "home_care_yn";
            this.multiLayoutItem1328.IsUpdItem = true;
            // 
            // multiLayoutItem1329
            // 
            this.multiLayoutItem1329.DataName = "regular_yn";
            this.multiLayoutItem1329.IsUpdItem = true;
            // 
            // multiLayoutItem1330
            // 
            this.multiLayoutItem1330.DataName = "sort_fkocskey";
            this.multiLayoutItem1330.IsUpdItem = true;
            // 
            // multiLayoutItem1331
            // 
            this.multiLayoutItem1331.DataName = "child_yn";
            this.multiLayoutItem1331.IsUpdItem = true;
            // 
            // multiLayoutItem1332
            // 
            this.multiLayoutItem1332.DataName = "if_input_control";
            // 
            // multiLayoutItem1333
            // 
            this.multiLayoutItem1333.DataName = "slip_name";
            // 
            // multiLayoutItem1334
            // 
            this.multiLayoutItem1334.DataName = "org_key";
            // 
            // multiLayoutItem1335
            // 
            this.multiLayoutItem1335.DataName = "parent_key";
            // 
            // multiLayoutItem1936
            // 
            this.multiLayoutItem1936.DataName = "bun_code";
            // 
            // multiLayoutItem1952
            // 
            this.multiLayoutItem1952.DataName = "wonnae_drg_yn";
            // 
            // layXrtOrder
            // 
            this.layXrtOrder.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1336,
            this.multiLayoutItem1337,
            this.multiLayoutItem1338,
            this.multiLayoutItem1339,
            this.multiLayoutItem1340,
            this.multiLayoutItem1341,
            this.multiLayoutItem1342,
            this.multiLayoutItem1343,
            this.multiLayoutItem1344,
            this.multiLayoutItem1345,
            this.multiLayoutItem1346,
            this.multiLayoutItem1347,
            this.multiLayoutItem1348,
            this.multiLayoutItem1349,
            this.multiLayoutItem1350,
            this.multiLayoutItem1351,
            this.multiLayoutItem1352,
            this.multiLayoutItem1353,
            this.multiLayoutItem1354,
            this.multiLayoutItem1355,
            this.multiLayoutItem1356,
            this.multiLayoutItem1357,
            this.multiLayoutItem1358,
            this.multiLayoutItem1359,
            this.multiLayoutItem1360,
            this.multiLayoutItem1361,
            this.multiLayoutItem1362,
            this.multiLayoutItem1363,
            this.multiLayoutItem1364,
            this.multiLayoutItem1365,
            this.multiLayoutItem1366,
            this.multiLayoutItem1367,
            this.multiLayoutItem1368,
            this.multiLayoutItem1369,
            this.multiLayoutItem1370,
            this.multiLayoutItem1371,
            this.multiLayoutItem1372,
            this.multiLayoutItem1373,
            this.multiLayoutItem1374,
            this.multiLayoutItem1375,
            this.multiLayoutItem1376,
            this.multiLayoutItem1377,
            this.multiLayoutItem1378,
            this.multiLayoutItem1379,
            this.multiLayoutItem1380,
            this.multiLayoutItem1381,
            this.multiLayoutItem1382,
            this.multiLayoutItem1383,
            this.multiLayoutItem1384,
            this.multiLayoutItem1385,
            this.multiLayoutItem1386,
            this.multiLayoutItem1387,
            this.multiLayoutItem1388,
            this.multiLayoutItem1389,
            this.multiLayoutItem1390,
            this.multiLayoutItem1391,
            this.multiLayoutItem1392,
            this.multiLayoutItem1393,
            this.multiLayoutItem1394,
            this.multiLayoutItem1395,
            this.multiLayoutItem1396,
            this.multiLayoutItem1397,
            this.multiLayoutItem1398,
            this.multiLayoutItem1399,
            this.multiLayoutItem1400,
            this.multiLayoutItem1401,
            this.multiLayoutItem1402,
            this.multiLayoutItem1403,
            this.multiLayoutItem1404,
            this.multiLayoutItem1405,
            this.multiLayoutItem1406,
            this.multiLayoutItem1407,
            this.multiLayoutItem1408,
            this.multiLayoutItem1409,
            this.multiLayoutItem1410,
            this.multiLayoutItem1411,
            this.multiLayoutItem1412,
            this.multiLayoutItem1413,
            this.multiLayoutItem1414,
            this.multiLayoutItem1415,
            this.multiLayoutItem1416,
            this.multiLayoutItem1417,
            this.multiLayoutItem1418,
            this.multiLayoutItem1419,
            this.multiLayoutItem1420,
            this.multiLayoutItem1421,
            this.multiLayoutItem1422,
            this.multiLayoutItem1423,
            this.multiLayoutItem1424,
            this.multiLayoutItem1425,
            this.multiLayoutItem1426,
            this.multiLayoutItem1427,
            this.multiLayoutItem1428,
            this.multiLayoutItem1429,
            this.multiLayoutItem1430,
            this.multiLayoutItem1431,
            this.multiLayoutItem1432,
            this.multiLayoutItem1433,
            this.multiLayoutItem1434,
            this.multiLayoutItem1435,
            this.multiLayoutItem1436,
            this.multiLayoutItem1437,
            this.multiLayoutItem1438,
            this.multiLayoutItem1439,
            this.multiLayoutItem1440,
            this.multiLayoutItem1441,
            this.multiLayoutItem1442,
            this.multiLayoutItem1443,
            this.multiLayoutItem1444,
            this.multiLayoutItem1445,
            this.multiLayoutItem1446,
            this.multiLayoutItem1447,
            this.multiLayoutItem1448,
            this.multiLayoutItem1449,
            this.multiLayoutItem1450,
            this.multiLayoutItem1451,
            this.multiLayoutItem1452,
            this.multiLayoutItem1453,
            this.multiLayoutItem1454,
            this.multiLayoutItem1455,
            this.multiLayoutItem1456,
            this.multiLayoutItem1457,
            this.multiLayoutItem1458,
            this.multiLayoutItem1459,
            this.multiLayoutItem1460,
            this.multiLayoutItem1461,
            this.multiLayoutItem1462,
            this.multiLayoutItem1463,
            this.multiLayoutItem1464,
            this.multiLayoutItem1465,
            this.multiLayoutItem1466,
            this.multiLayoutItem1467,
            this.multiLayoutItem1468,
            this.multiLayoutItem1469,
            this.multiLayoutItem1470,
            this.multiLayoutItem1471,
            this.multiLayoutItem1472,
            this.multiLayoutItem1473,
            this.multiLayoutItem1474,
            this.multiLayoutItem1475,
            this.multiLayoutItem1476,
            this.multiLayoutItem1477,
            this.multiLayoutItem1478,
            this.multiLayoutItem1479,
            this.multiLayoutItem1480,
            this.multiLayoutItem1481,
            this.multiLayoutItem1482,
            this.multiLayoutItem1483,
            this.multiLayoutItem1937,
            this.multiLayoutItem1953});
            // 
            // multiLayoutItem1336
            // 
            this.multiLayoutItem1336.DataName = "in_out_key";
            this.multiLayoutItem1336.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem1336.IsUpdItem = true;
            // 
            // multiLayoutItem1337
            // 
            this.multiLayoutItem1337.DataName = "pkocskey";
            this.multiLayoutItem1337.IsUpdItem = true;
            // 
            // multiLayoutItem1338
            // 
            this.multiLayoutItem1338.DataName = "bunho";
            this.multiLayoutItem1338.IsUpdItem = true;
            // 
            // multiLayoutItem1339
            // 
            this.multiLayoutItem1339.DataName = "order_date";
            this.multiLayoutItem1339.IsUpdItem = true;
            // 
            // multiLayoutItem1340
            // 
            this.multiLayoutItem1340.DataName = "gwa";
            this.multiLayoutItem1340.IsUpdItem = true;
            // 
            // multiLayoutItem1341
            // 
            this.multiLayoutItem1341.DataName = "doctor";
            this.multiLayoutItem1341.IsUpdItem = true;
            // 
            // multiLayoutItem1342
            // 
            this.multiLayoutItem1342.DataName = "resident";
            this.multiLayoutItem1342.IsUpdItem = true;
            // 
            // multiLayoutItem1343
            // 
            this.multiLayoutItem1343.DataName = "naewon_type";
            this.multiLayoutItem1343.IsUpdItem = true;
            // 
            // multiLayoutItem1344
            // 
            this.multiLayoutItem1344.DataName = "jubsu_no";
            this.multiLayoutItem1344.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem1344.IsUpdItem = true;
            // 
            // multiLayoutItem1345
            // 
            this.multiLayoutItem1345.DataName = "input_id";
            this.multiLayoutItem1345.IsUpdItem = true;
            // 
            // multiLayoutItem1346
            // 
            this.multiLayoutItem1346.DataName = "input_part";
            this.multiLayoutItem1346.IsUpdItem = true;
            // 
            // multiLayoutItem1347
            // 
            this.multiLayoutItem1347.DataName = "input_gwa";
            this.multiLayoutItem1347.IsUpdItem = true;
            // 
            // multiLayoutItem1348
            // 
            this.multiLayoutItem1348.DataName = "input_doctor";
            this.multiLayoutItem1348.IsUpdItem = true;
            // 
            // multiLayoutItem1349
            // 
            this.multiLayoutItem1349.DataName = "input_gubun";
            this.multiLayoutItem1349.IsUpdItem = true;
            // 
            // multiLayoutItem1350
            // 
            this.multiLayoutItem1350.DataName = "input_gubun_name";
            // 
            // multiLayoutItem1351
            // 
            this.multiLayoutItem1351.DataName = "group_ser";
            this.multiLayoutItem1351.IsUpdItem = true;
            // 
            // multiLayoutItem1352
            // 
            this.multiLayoutItem1352.DataName = "input_tab";
            this.multiLayoutItem1352.IsUpdItem = true;
            // 
            // multiLayoutItem1353
            // 
            this.multiLayoutItem1353.DataName = "input_tab_name";
            // 
            // multiLayoutItem1354
            // 
            this.multiLayoutItem1354.DataName = "order_gubun";
            this.multiLayoutItem1354.IsUpdItem = true;
            // 
            // multiLayoutItem1355
            // 
            this.multiLayoutItem1355.DataName = "order_gubun_name";
            // 
            // multiLayoutItem1356
            // 
            this.multiLayoutItem1356.DataName = "group_yn";
            this.multiLayoutItem1356.IsUpdItem = true;
            // 
            // multiLayoutItem1357
            // 
            this.multiLayoutItem1357.DataName = "seq";
            this.multiLayoutItem1357.IsUpdItem = true;
            // 
            // multiLayoutItem1358
            // 
            this.multiLayoutItem1358.DataName = "slip_code";
            this.multiLayoutItem1358.IsUpdItem = true;
            // 
            // multiLayoutItem1359
            // 
            this.multiLayoutItem1359.DataName = "hangmog_code";
            this.multiLayoutItem1359.IsUpdItem = true;
            // 
            // multiLayoutItem1360
            // 
            this.multiLayoutItem1360.DataName = "hangmog_name";
            // 
            // multiLayoutItem1361
            // 
            this.multiLayoutItem1361.DataName = "specimen_code";
            this.multiLayoutItem1361.IsUpdItem = true;
            // 
            // multiLayoutItem1362
            // 
            this.multiLayoutItem1362.DataName = "specimen_name";
            // 
            // multiLayoutItem1363
            // 
            this.multiLayoutItem1363.DataName = "suryang";
            this.multiLayoutItem1363.IsUpdItem = true;
            // 
            // multiLayoutItem1364
            // 
            this.multiLayoutItem1364.DataName = "sunab_suryang";
            this.multiLayoutItem1364.IsUpdItem = true;
            // 
            // multiLayoutItem1365
            // 
            this.multiLayoutItem1365.DataName = "subul_suryang";
            this.multiLayoutItem1365.IsUpdItem = true;
            // 
            // multiLayoutItem1366
            // 
            this.multiLayoutItem1366.DataName = "ord_danui";
            this.multiLayoutItem1366.IsUpdItem = true;
            // 
            // multiLayoutItem1367
            // 
            this.multiLayoutItem1367.DataName = "ord_danui_name";
            // 
            // multiLayoutItem1368
            // 
            this.multiLayoutItem1368.DataName = "dv_time";
            this.multiLayoutItem1368.IsUpdItem = true;
            // 
            // multiLayoutItem1369
            // 
            this.multiLayoutItem1369.DataName = "dv";
            this.multiLayoutItem1369.IsUpdItem = true;
            // 
            // multiLayoutItem1370
            // 
            this.multiLayoutItem1370.DataName = "dv_1";
            this.multiLayoutItem1370.IsUpdItem = true;
            // 
            // multiLayoutItem1371
            // 
            this.multiLayoutItem1371.DataName = "dv_2";
            this.multiLayoutItem1371.IsUpdItem = true;
            // 
            // multiLayoutItem1372
            // 
            this.multiLayoutItem1372.DataName = "dv_3";
            this.multiLayoutItem1372.IsUpdItem = true;
            // 
            // multiLayoutItem1373
            // 
            this.multiLayoutItem1373.DataName = "dv_4";
            this.multiLayoutItem1373.IsUpdItem = true;
            // 
            // multiLayoutItem1374
            // 
            this.multiLayoutItem1374.DataName = "nalsu";
            this.multiLayoutItem1374.IsUpdItem = true;
            // 
            // multiLayoutItem1375
            // 
            this.multiLayoutItem1375.DataName = "sunab_nalsu";
            this.multiLayoutItem1375.IsUpdItem = true;
            // 
            // multiLayoutItem1376
            // 
            this.multiLayoutItem1376.DataName = "jusa";
            this.multiLayoutItem1376.IsUpdItem = true;
            // 
            // multiLayoutItem1377
            // 
            this.multiLayoutItem1377.DataName = "jusa_name";
            this.multiLayoutItem1377.IsUpdItem = true;
            // 
            // multiLayoutItem1378
            // 
            this.multiLayoutItem1378.DataName = "jusa_spd_gubun";
            this.multiLayoutItem1378.IsUpdItem = true;
            // 
            // multiLayoutItem1379
            // 
            this.multiLayoutItem1379.DataName = "bogyong_code";
            this.multiLayoutItem1379.IsUpdItem = true;
            // 
            // multiLayoutItem1380
            // 
            this.multiLayoutItem1380.DataName = "bogyong_name";
            this.multiLayoutItem1380.IsUpdItem = true;
            // 
            // multiLayoutItem1381
            // 
            this.multiLayoutItem1381.DataName = "emergency";
            this.multiLayoutItem1381.IsUpdItem = true;
            // 
            // multiLayoutItem1382
            // 
            this.multiLayoutItem1382.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem1382.IsUpdItem = true;
            // 
            // multiLayoutItem1383
            // 
            this.multiLayoutItem1383.DataName = "jundal_table";
            this.multiLayoutItem1383.IsUpdItem = true;
            // 
            // multiLayoutItem1384
            // 
            this.multiLayoutItem1384.DataName = "jundal_part";
            this.multiLayoutItem1384.IsUpdItem = true;
            // 
            // multiLayoutItem1385
            // 
            this.multiLayoutItem1385.DataName = "move_part";
            this.multiLayoutItem1385.IsUpdItem = true;
            // 
            // multiLayoutItem1386
            // 
            this.multiLayoutItem1386.DataName = "portable_yn";
            this.multiLayoutItem1386.IsUpdItem = true;
            // 
            // multiLayoutItem1387
            // 
            this.multiLayoutItem1387.DataName = "powder_yn";
            this.multiLayoutItem1387.IsUpdItem = true;
            // 
            // multiLayoutItem1388
            // 
            this.multiLayoutItem1388.DataName = "hubal_change_yn";
            this.multiLayoutItem1388.IsUpdItem = true;
            // 
            // multiLayoutItem1389
            // 
            this.multiLayoutItem1389.DataName = "pharmacy";
            this.multiLayoutItem1389.IsUpdItem = true;
            // 
            // multiLayoutItem1390
            // 
            this.multiLayoutItem1390.DataName = "drg_pack_yn";
            this.multiLayoutItem1390.IsUpdItem = true;
            // 
            // multiLayoutItem1391
            // 
            this.multiLayoutItem1391.DataName = "muhyo";
            this.multiLayoutItem1391.IsUpdItem = true;
            // 
            // multiLayoutItem1392
            // 
            this.multiLayoutItem1392.DataName = "prn_yn";
            this.multiLayoutItem1392.IsUpdItem = true;
            // 
            // multiLayoutItem1393
            // 
            this.multiLayoutItem1393.DataName = "toiwon_drg_yn";
            this.multiLayoutItem1393.IsUpdItem = true;
            // 
            // multiLayoutItem1394
            // 
            this.multiLayoutItem1394.DataName = "prn_nurse";
            this.multiLayoutItem1394.IsUpdItem = true;
            // 
            // multiLayoutItem1395
            // 
            this.multiLayoutItem1395.DataName = "append_yn";
            this.multiLayoutItem1395.IsUpdItem = true;
            // 
            // multiLayoutItem1396
            // 
            this.multiLayoutItem1396.DataName = "order_remark";
            this.multiLayoutItem1396.IsUpdItem = true;
            // 
            // multiLayoutItem1397
            // 
            this.multiLayoutItem1397.DataName = "nurse_remark";
            this.multiLayoutItem1397.IsUpdItem = true;
            // 
            // multiLayoutItem1398
            // 
            this.multiLayoutItem1398.DataName = "comment";
            this.multiLayoutItem1398.IsUpdItem = true;
            // 
            // multiLayoutItem1399
            // 
            this.multiLayoutItem1399.DataName = "mix_group";
            this.multiLayoutItem1399.IsUpdItem = true;
            // 
            // multiLayoutItem1400
            // 
            this.multiLayoutItem1400.DataName = "amt";
            this.multiLayoutItem1400.IsUpdItem = true;
            // 
            // multiLayoutItem1401
            // 
            this.multiLayoutItem1401.DataName = "pay";
            this.multiLayoutItem1401.IsUpdItem = true;
            // 
            // multiLayoutItem1402
            // 
            this.multiLayoutItem1402.DataName = "wonyoi_order_yn";
            this.multiLayoutItem1402.IsUpdItem = true;
            // 
            // multiLayoutItem1403
            // 
            this.multiLayoutItem1403.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem1403.IsUpdItem = true;
            // 
            // multiLayoutItem1404
            // 
            this.multiLayoutItem1404.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem1404.IsUpdItem = true;
            // 
            // multiLayoutItem1405
            // 
            this.multiLayoutItem1405.DataName = "bom_occur_yn";
            this.multiLayoutItem1405.IsUpdItem = true;
            // 
            // multiLayoutItem1406
            // 
            this.multiLayoutItem1406.DataName = "bom_source_key";
            this.multiLayoutItem1406.IsUpdItem = true;
            // 
            // multiLayoutItem1407
            // 
            this.multiLayoutItem1407.DataName = "display_yn";
            this.multiLayoutItem1407.IsUpdItem = true;
            // 
            // multiLayoutItem1408
            // 
            this.multiLayoutItem1408.DataName = "sunab_yn";
            this.multiLayoutItem1408.IsUpdItem = true;
            // 
            // multiLayoutItem1409
            // 
            this.multiLayoutItem1409.DataName = "sunab_date";
            this.multiLayoutItem1409.IsUpdItem = true;
            // 
            // multiLayoutItem1410
            // 
            this.multiLayoutItem1410.DataName = "sunab_time";
            this.multiLayoutItem1410.IsUpdItem = true;
            // 
            // multiLayoutItem1411
            // 
            this.multiLayoutItem1411.DataName = "hope_date";
            this.multiLayoutItem1411.IsUpdItem = true;
            // 
            // multiLayoutItem1412
            // 
            this.multiLayoutItem1412.DataName = "hope_time";
            this.multiLayoutItem1412.IsUpdItem = true;
            // 
            // multiLayoutItem1413
            // 
            this.multiLayoutItem1413.DataName = "nurse_confirm_user";
            this.multiLayoutItem1413.IsUpdItem = true;
            // 
            // multiLayoutItem1414
            // 
            this.multiLayoutItem1414.DataName = "nurse_confirm_date";
            this.multiLayoutItem1414.IsUpdItem = true;
            // 
            // multiLayoutItem1415
            // 
            this.multiLayoutItem1415.DataName = "nurse_confirm_time";
            this.multiLayoutItem1415.IsUpdItem = true;
            // 
            // multiLayoutItem1416
            // 
            this.multiLayoutItem1416.DataName = "nurse_pickup_user";
            this.multiLayoutItem1416.IsUpdItem = true;
            // 
            // multiLayoutItem1417
            // 
            this.multiLayoutItem1417.DataName = "nurse_pickup_date";
            this.multiLayoutItem1417.IsUpdItem = true;
            // 
            // multiLayoutItem1418
            // 
            this.multiLayoutItem1418.DataName = "nurse_pickup_time";
            this.multiLayoutItem1418.IsUpdItem = true;
            // 
            // multiLayoutItem1419
            // 
            this.multiLayoutItem1419.DataName = "nurse_hold_user";
            this.multiLayoutItem1419.IsUpdItem = true;
            // 
            // multiLayoutItem1420
            // 
            this.multiLayoutItem1420.DataName = "nurse_hold_date";
            this.multiLayoutItem1420.IsUpdItem = true;
            // 
            // multiLayoutItem1421
            // 
            this.multiLayoutItem1421.DataName = "nurse_hold_time";
            this.multiLayoutItem1421.IsUpdItem = true;
            // 
            // multiLayoutItem1422
            // 
            this.multiLayoutItem1422.DataName = "reser_date";
            this.multiLayoutItem1422.IsUpdItem = true;
            // 
            // multiLayoutItem1423
            // 
            this.multiLayoutItem1423.DataName = "reser_time";
            this.multiLayoutItem1423.IsUpdItem = true;
            // 
            // multiLayoutItem1424
            // 
            this.multiLayoutItem1424.DataName = "jubsu_date";
            this.multiLayoutItem1424.IsUpdItem = true;
            // 
            // multiLayoutItem1425
            // 
            this.multiLayoutItem1425.DataName = "jubsu_time";
            this.multiLayoutItem1425.IsUpdItem = true;
            // 
            // multiLayoutItem1426
            // 
            this.multiLayoutItem1426.DataName = "acting_date";
            this.multiLayoutItem1426.IsUpdItem = true;
            // 
            // multiLayoutItem1427
            // 
            this.multiLayoutItem1427.DataName = "acting_time";
            this.multiLayoutItem1427.IsUpdItem = true;
            // 
            // multiLayoutItem1428
            // 
            this.multiLayoutItem1428.DataName = "acting_day";
            this.multiLayoutItem1428.IsUpdItem = true;
            // 
            // multiLayoutItem1429
            // 
            this.multiLayoutItem1429.DataName = "result_date";
            this.multiLayoutItem1429.IsUpdItem = true;
            // 
            // multiLayoutItem1430
            // 
            this.multiLayoutItem1430.DataName = "dc_gubun";
            this.multiLayoutItem1430.IsUpdItem = true;
            // 
            // multiLayoutItem1431
            // 
            this.multiLayoutItem1431.DataName = "dc_yn";
            this.multiLayoutItem1431.IsUpdItem = true;
            // 
            // multiLayoutItem1432
            // 
            this.multiLayoutItem1432.DataName = "bannab_yn";
            this.multiLayoutItem1432.IsUpdItem = true;
            // 
            // multiLayoutItem1433
            // 
            this.multiLayoutItem1433.DataName = "bannab_confirm";
            this.multiLayoutItem1433.IsUpdItem = true;
            // 
            // multiLayoutItem1434
            // 
            this.multiLayoutItem1434.DataName = "source_ord_key";
            this.multiLayoutItem1434.IsUpdItem = true;
            // 
            // multiLayoutItem1435
            // 
            this.multiLayoutItem1435.DataName = "ocs_flag";
            this.multiLayoutItem1435.IsUpdItem = true;
            // 
            // multiLayoutItem1436
            // 
            this.multiLayoutItem1436.DataName = "sg_code";
            this.multiLayoutItem1436.IsUpdItem = true;
            // 
            // multiLayoutItem1437
            // 
            this.multiLayoutItem1437.DataName = "sg_ymd";
            this.multiLayoutItem1437.IsUpdItem = true;
            // 
            // multiLayoutItem1438
            // 
            this.multiLayoutItem1438.DataName = "io_gubun";
            this.multiLayoutItem1438.IsUpdItem = true;
            // 
            // multiLayoutItem1439
            // 
            this.multiLayoutItem1439.DataName = "after_act_yn";
            this.multiLayoutItem1439.IsUpdItem = true;
            // 
            // multiLayoutItem1440
            // 
            this.multiLayoutItem1440.DataName = "bichi_yn";
            this.multiLayoutItem1440.IsUpdItem = true;
            // 
            // multiLayoutItem1441
            // 
            this.multiLayoutItem1441.DataName = "drg_bunho";
            this.multiLayoutItem1441.IsUpdItem = true;
            // 
            // multiLayoutItem1442
            // 
            this.multiLayoutItem1442.DataName = "sub_susul";
            this.multiLayoutItem1442.IsUpdItem = true;
            // 
            // multiLayoutItem1443
            // 
            this.multiLayoutItem1443.DataName = "print_yn";
            this.multiLayoutItem1443.IsUpdItem = true;
            // 
            // multiLayoutItem1444
            // 
            this.multiLayoutItem1444.DataName = "chisik";
            this.multiLayoutItem1444.IsUpdItem = true;
            // 
            // multiLayoutItem1445
            // 
            this.multiLayoutItem1445.DataName = "tel_yn";
            this.multiLayoutItem1445.IsUpdItem = true;
            // 
            // multiLayoutItem1446
            // 
            this.multiLayoutItem1446.DataName = "order_gubun_bas";
            this.multiLayoutItem1446.IsUpdItem = true;
            // 
            // multiLayoutItem1447
            // 
            this.multiLayoutItem1447.DataName = "input_control";
            this.multiLayoutItem1447.IsUpdItem = true;
            // 
            // multiLayoutItem1448
            // 
            this.multiLayoutItem1448.DataName = "suga_yn";
            this.multiLayoutItem1448.IsUpdItem = true;
            // 
            // multiLayoutItem1449
            // 
            this.multiLayoutItem1449.DataName = "jaeryo_yn";
            this.multiLayoutItem1449.IsUpdItem = true;
            // 
            // multiLayoutItem1450
            // 
            this.multiLayoutItem1450.DataName = "wonyoi_check";
            this.multiLayoutItem1450.IsUpdItem = true;
            // 
            // multiLayoutItem1451
            // 
            this.multiLayoutItem1451.DataName = "emergency_check";
            this.multiLayoutItem1451.IsUpdItem = true;
            // 
            // multiLayoutItem1452
            // 
            this.multiLayoutItem1452.DataName = "specimen_check";
            // 
            // multiLayoutItem1453
            // 
            this.multiLayoutItem1453.DataName = "portable_check";
            this.multiLayoutItem1453.IsUpdItem = true;
            // 
            // multiLayoutItem1454
            // 
            this.multiLayoutItem1454.DataName = "bulyong_check";
            this.multiLayoutItem1454.IsUpdItem = true;
            // 
            // multiLayoutItem1455
            // 
            this.multiLayoutItem1455.DataName = "sunab_check";
            // 
            // multiLayoutItem1456
            // 
            this.multiLayoutItem1456.DataName = "dc_check";
            // 
            // multiLayoutItem1457
            // 
            this.multiLayoutItem1457.DataName = "dc_gubun_check";
            this.multiLayoutItem1457.IsUpdItem = true;
            // 
            // multiLayoutItem1458
            // 
            this.multiLayoutItem1458.DataName = "confirm_check";
            this.multiLayoutItem1458.IsUpdItem = true;
            // 
            // multiLayoutItem1459
            // 
            this.multiLayoutItem1459.DataName = "reser_yn_check";
            this.multiLayoutItem1459.IsUpdItem = true;
            // 
            // multiLayoutItem1460
            // 
            this.multiLayoutItem1460.DataName = "chisik_check";
            this.multiLayoutItem1460.IsUpdItem = true;
            // 
            // multiLayoutItem1461
            // 
            this.multiLayoutItem1461.DataName = "nday_yn";
            this.multiLayoutItem1461.IsUpdItem = true;
            // 
            // multiLayoutItem1462
            // 
            this.multiLayoutItem1462.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem1462.IsUpdItem = true;
            // 
            // multiLayoutItem1463
            // 
            this.multiLayoutItem1463.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem1463.IsUpdItem = true;
            // 
            // multiLayoutItem1464
            // 
            this.multiLayoutItem1464.DataName = "specific_comment";
            this.multiLayoutItem1464.IsUpdItem = true;
            // 
            // multiLayoutItem1465
            // 
            this.multiLayoutItem1465.DataName = "specific_comment_name";
            this.multiLayoutItem1465.IsUpdItem = true;
            // 
            // multiLayoutItem1466
            // 
            this.multiLayoutItem1466.DataName = "specific_comment_sys_id";
            this.multiLayoutItem1466.IsUpdItem = true;
            // 
            // multiLayoutItem1467
            // 
            this.multiLayoutItem1467.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem1467.IsUpdItem = true;
            // 
            // multiLayoutItem1468
            // 
            this.multiLayoutItem1468.DataName = "specific_comment_not_null";
            this.multiLayoutItem1468.IsUpdItem = true;
            // 
            // multiLayoutItem1469
            // 
            this.multiLayoutItem1469.DataName = "specific_comment_table_id";
            this.multiLayoutItem1469.IsUpdItem = true;
            // 
            // multiLayoutItem1470
            // 
            this.multiLayoutItem1470.DataName = "specific_comment_col_id";
            this.multiLayoutItem1470.IsUpdItem = true;
            // 
            // multiLayoutItem1471
            // 
            this.multiLayoutItem1471.DataName = "donbog_yn";
            this.multiLayoutItem1471.IsUpdItem = true;
            // 
            // multiLayoutItem1472
            // 
            this.multiLayoutItem1472.DataName = "order_gubun_bas_name";
            this.multiLayoutItem1472.IsUpdItem = true;
            // 
            // multiLayoutItem1473
            // 
            this.multiLayoutItem1473.DataName = "act_doctoor";
            this.multiLayoutItem1473.IsUpdItem = true;
            // 
            // multiLayoutItem1474
            // 
            this.multiLayoutItem1474.DataName = "act_buseo";
            this.multiLayoutItem1474.IsUpdItem = true;
            // 
            // multiLayoutItem1475
            // 
            this.multiLayoutItem1475.DataName = "act_gwa";
            this.multiLayoutItem1475.IsUpdItem = true;
            // 
            // multiLayoutItem1476
            // 
            this.multiLayoutItem1476.DataName = "home_care_yn";
            this.multiLayoutItem1476.IsUpdItem = true;
            // 
            // multiLayoutItem1477
            // 
            this.multiLayoutItem1477.DataName = "regular_yn";
            this.multiLayoutItem1477.IsUpdItem = true;
            // 
            // multiLayoutItem1478
            // 
            this.multiLayoutItem1478.DataName = "sort_fkocskey";
            this.multiLayoutItem1478.IsUpdItem = true;
            // 
            // multiLayoutItem1479
            // 
            this.multiLayoutItem1479.DataName = "child_yn";
            this.multiLayoutItem1479.IsUpdItem = true;
            // 
            // multiLayoutItem1480
            // 
            this.multiLayoutItem1480.DataName = "if_input_control";
            // 
            // multiLayoutItem1481
            // 
            this.multiLayoutItem1481.DataName = "slip_name";
            // 
            // multiLayoutItem1482
            // 
            this.multiLayoutItem1482.DataName = "org_key";
            // 
            // multiLayoutItem1483
            // 
            this.multiLayoutItem1483.DataName = "parent_key";
            // 
            // multiLayoutItem1937
            // 
            this.multiLayoutItem1937.DataName = "bun_code";
            // 
            // multiLayoutItem1953
            // 
            this.multiLayoutItem1953.DataName = "wonnae_drg_yn";
            // 
            // layChuchiOrder
            // 
            this.layChuchiOrder.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1031,
            this.multiLayoutItem1036,
            this.multiLayoutItem1037,
            this.multiLayoutItem1038,
            this.multiLayoutItem1039,
            this.multiLayoutItem1042,
            this.multiLayoutItem1043,
            this.multiLayoutItem1044,
            this.multiLayoutItem1045,
            this.multiLayoutItem1046,
            this.multiLayoutItem1047,
            this.multiLayoutItem1048,
            this.multiLayoutItem1049,
            this.multiLayoutItem1050,
            this.multiLayoutItem1051,
            this.multiLayoutItem1052,
            this.multiLayoutItem1053,
            this.multiLayoutItem1054,
            this.multiLayoutItem1055,
            this.multiLayoutItem1056,
            this.multiLayoutItem1057,
            this.multiLayoutItem1058,
            this.multiLayoutItem1059,
            this.multiLayoutItem1060,
            this.multiLayoutItem1061,
            this.multiLayoutItem1062,
            this.multiLayoutItem1063,
            this.multiLayoutItem1064,
            this.multiLayoutItem1065,
            this.multiLayoutItem1066,
            this.multiLayoutItem1067,
            this.multiLayoutItem1068,
            this.multiLayoutItem1069,
            this.multiLayoutItem1070,
            this.multiLayoutItem1071,
            this.multiLayoutItem1072,
            this.multiLayoutItem1073,
            this.multiLayoutItem1074,
            this.multiLayoutItem1075,
            this.multiLayoutItem1076,
            this.multiLayoutItem1077,
            this.multiLayoutItem1078,
            this.multiLayoutItem1079,
            this.multiLayoutItem1080,
            this.multiLayoutItem1081,
            this.multiLayoutItem1082,
            this.multiLayoutItem1083,
            this.multiLayoutItem1084,
            this.multiLayoutItem1085,
            this.multiLayoutItem1086,
            this.multiLayoutItem1087,
            this.multiLayoutItem1088,
            this.multiLayoutItem1089,
            this.multiLayoutItem1090,
            this.multiLayoutItem1091,
            this.multiLayoutItem1092,
            this.multiLayoutItem1093,
            this.multiLayoutItem1094,
            this.multiLayoutItem1095,
            this.multiLayoutItem1096,
            this.multiLayoutItem1097,
            this.multiLayoutItem1098,
            this.multiLayoutItem1099,
            this.multiLayoutItem1100,
            this.multiLayoutItem1101,
            this.multiLayoutItem1102,
            this.multiLayoutItem1103,
            this.multiLayoutItem1104,
            this.multiLayoutItem1105,
            this.multiLayoutItem1106,
            this.multiLayoutItem1107,
            this.multiLayoutItem1108,
            this.multiLayoutItem1109,
            this.multiLayoutItem1110,
            this.multiLayoutItem1111,
            this.multiLayoutItem1112,
            this.multiLayoutItem1113,
            this.multiLayoutItem1114,
            this.multiLayoutItem1115,
            this.multiLayoutItem1116,
            this.multiLayoutItem1117,
            this.multiLayoutItem1118,
            this.multiLayoutItem1119,
            this.multiLayoutItem1120,
            this.multiLayoutItem1121,
            this.multiLayoutItem1122,
            this.multiLayoutItem1123,
            this.multiLayoutItem1124,
            this.multiLayoutItem1125,
            this.multiLayoutItem1126,
            this.multiLayoutItem1127,
            this.multiLayoutItem1128,
            this.multiLayoutItem1129,
            this.multiLayoutItem1130,
            this.multiLayoutItem1131,
            this.multiLayoutItem1132,
            this.multiLayoutItem1133,
            this.multiLayoutItem1134,
            this.multiLayoutItem1135,
            this.multiLayoutItem1136,
            this.multiLayoutItem1137,
            this.multiLayoutItem1138,
            this.multiLayoutItem1139,
            this.multiLayoutItem1140,
            this.multiLayoutItem1141,
            this.multiLayoutItem1142,
            this.multiLayoutItem1143,
            this.multiLayoutItem1144,
            this.multiLayoutItem1145,
            this.multiLayoutItem1146,
            this.multiLayoutItem1147,
            this.multiLayoutItem1148,
            this.multiLayoutItem1149,
            this.multiLayoutItem1150,
            this.multiLayoutItem1151,
            this.multiLayoutItem1152,
            this.multiLayoutItem1153,
            this.multiLayoutItem1154,
            this.multiLayoutItem1155,
            this.multiLayoutItem1156,
            this.multiLayoutItem1157,
            this.multiLayoutItem1158,
            this.multiLayoutItem1159,
            this.multiLayoutItem1160,
            this.multiLayoutItem1161,
            this.multiLayoutItem1162,
            this.multiLayoutItem1163,
            this.multiLayoutItem1164,
            this.multiLayoutItem1165,
            this.multiLayoutItem1166,
            this.multiLayoutItem1167,
            this.multiLayoutItem1168,
            this.multiLayoutItem1169,
            this.multiLayoutItem1170,
            this.multiLayoutItem1171,
            this.multiLayoutItem1172,
            this.multiLayoutItem1173,
            this.multiLayoutItem1174,
            this.multiLayoutItem1175,
            this.multiLayoutItem1176,
            this.multiLayoutItem1177,
            this.multiLayoutItem1178,
            this.multiLayoutItem1179,
            this.multiLayoutItem1180,
            this.multiLayoutItem1181,
            this.multiLayoutItem1182,
            this.multiLayoutItem1183,
            this.multiLayoutItem1184,
            this.multiLayoutItem1185,
            this.multiLayoutItem1946});
            // 
            // multiLayoutItem1031
            // 
            this.multiLayoutItem1031.DataName = "in_out_key";
            this.multiLayoutItem1031.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem1031.IsUpdItem = true;
            // 
            // multiLayoutItem1036
            // 
            this.multiLayoutItem1036.DataName = "pkocskey";
            this.multiLayoutItem1036.IsUpdItem = true;
            // 
            // multiLayoutItem1037
            // 
            this.multiLayoutItem1037.DataName = "bunho";
            this.multiLayoutItem1037.IsUpdItem = true;
            // 
            // multiLayoutItem1038
            // 
            this.multiLayoutItem1038.DataName = "order_date";
            this.multiLayoutItem1038.IsUpdItem = true;
            // 
            // multiLayoutItem1039
            // 
            this.multiLayoutItem1039.DataName = "gwa";
            this.multiLayoutItem1039.IsUpdItem = true;
            // 
            // multiLayoutItem1042
            // 
            this.multiLayoutItem1042.DataName = "doctor";
            this.multiLayoutItem1042.IsUpdItem = true;
            // 
            // multiLayoutItem1043
            // 
            this.multiLayoutItem1043.DataName = "resident";
            this.multiLayoutItem1043.IsUpdItem = true;
            // 
            // multiLayoutItem1044
            // 
            this.multiLayoutItem1044.DataName = "naewon_type";
            this.multiLayoutItem1044.IsUpdItem = true;
            // 
            // multiLayoutItem1045
            // 
            this.multiLayoutItem1045.DataName = "jubsu_no";
            this.multiLayoutItem1045.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem1045.IsUpdItem = true;
            // 
            // multiLayoutItem1046
            // 
            this.multiLayoutItem1046.DataName = "input_id";
            this.multiLayoutItem1046.IsUpdItem = true;
            // 
            // multiLayoutItem1047
            // 
            this.multiLayoutItem1047.DataName = "input_part";
            this.multiLayoutItem1047.IsUpdItem = true;
            // 
            // multiLayoutItem1048
            // 
            this.multiLayoutItem1048.DataName = "input_gwa";
            this.multiLayoutItem1048.IsUpdItem = true;
            // 
            // multiLayoutItem1049
            // 
            this.multiLayoutItem1049.DataName = "input_doctor";
            this.multiLayoutItem1049.IsUpdItem = true;
            // 
            // multiLayoutItem1050
            // 
            this.multiLayoutItem1050.DataName = "input_gubun";
            this.multiLayoutItem1050.IsUpdItem = true;
            // 
            // multiLayoutItem1051
            // 
            this.multiLayoutItem1051.DataName = "input_gubun_name";
            // 
            // multiLayoutItem1052
            // 
            this.multiLayoutItem1052.DataName = "group_ser";
            this.multiLayoutItem1052.IsUpdItem = true;
            // 
            // multiLayoutItem1053
            // 
            this.multiLayoutItem1053.DataName = "input_tab";
            this.multiLayoutItem1053.IsUpdItem = true;
            // 
            // multiLayoutItem1054
            // 
            this.multiLayoutItem1054.DataName = "input_tab_name";
            // 
            // multiLayoutItem1055
            // 
            this.multiLayoutItem1055.DataName = "order_gubun";
            this.multiLayoutItem1055.IsUpdItem = true;
            // 
            // multiLayoutItem1056
            // 
            this.multiLayoutItem1056.DataName = "order_gubun_name";
            // 
            // multiLayoutItem1057
            // 
            this.multiLayoutItem1057.DataName = "group_yn";
            this.multiLayoutItem1057.IsUpdItem = true;
            // 
            // multiLayoutItem1058
            // 
            this.multiLayoutItem1058.DataName = "seq";
            this.multiLayoutItem1058.IsUpdItem = true;
            // 
            // multiLayoutItem1059
            // 
            this.multiLayoutItem1059.DataName = "slip_code";
            this.multiLayoutItem1059.IsUpdItem = true;
            // 
            // multiLayoutItem1060
            // 
            this.multiLayoutItem1060.DataName = "hangmog_code";
            this.multiLayoutItem1060.IsUpdItem = true;
            // 
            // multiLayoutItem1061
            // 
            this.multiLayoutItem1061.DataName = "hangmog_name";
            // 
            // multiLayoutItem1062
            // 
            this.multiLayoutItem1062.DataName = "specimen_code";
            this.multiLayoutItem1062.IsUpdItem = true;
            // 
            // multiLayoutItem1063
            // 
            this.multiLayoutItem1063.DataName = "specimen_name";
            // 
            // multiLayoutItem1064
            // 
            this.multiLayoutItem1064.DataName = "suryang";
            this.multiLayoutItem1064.IsUpdItem = true;
            // 
            // multiLayoutItem1065
            // 
            this.multiLayoutItem1065.DataName = "sunab_suryang";
            this.multiLayoutItem1065.IsUpdItem = true;
            // 
            // multiLayoutItem1066
            // 
            this.multiLayoutItem1066.DataName = "subul_suryang";
            this.multiLayoutItem1066.IsUpdItem = true;
            // 
            // multiLayoutItem1067
            // 
            this.multiLayoutItem1067.DataName = "ord_danui";
            this.multiLayoutItem1067.IsUpdItem = true;
            // 
            // multiLayoutItem1068
            // 
            this.multiLayoutItem1068.DataName = "ord_danui_name";
            // 
            // multiLayoutItem1069
            // 
            this.multiLayoutItem1069.DataName = "dv_time";
            this.multiLayoutItem1069.IsUpdItem = true;
            // 
            // multiLayoutItem1070
            // 
            this.multiLayoutItem1070.DataName = "dv";
            this.multiLayoutItem1070.IsUpdItem = true;
            // 
            // multiLayoutItem1071
            // 
            this.multiLayoutItem1071.DataName = "dv_1";
            this.multiLayoutItem1071.IsUpdItem = true;
            // 
            // multiLayoutItem1072
            // 
            this.multiLayoutItem1072.DataName = "dv_2";
            this.multiLayoutItem1072.IsUpdItem = true;
            // 
            // multiLayoutItem1073
            // 
            this.multiLayoutItem1073.DataName = "dv_3";
            this.multiLayoutItem1073.IsUpdItem = true;
            // 
            // multiLayoutItem1074
            // 
            this.multiLayoutItem1074.DataName = "dv_4";
            this.multiLayoutItem1074.IsUpdItem = true;
            // 
            // multiLayoutItem1075
            // 
            this.multiLayoutItem1075.DataName = "nalsu";
            this.multiLayoutItem1075.IsUpdItem = true;
            // 
            // multiLayoutItem1076
            // 
            this.multiLayoutItem1076.DataName = "sunab_nalsu";
            this.multiLayoutItem1076.IsUpdItem = true;
            // 
            // multiLayoutItem1077
            // 
            this.multiLayoutItem1077.DataName = "jusa";
            this.multiLayoutItem1077.IsUpdItem = true;
            // 
            // multiLayoutItem1078
            // 
            this.multiLayoutItem1078.DataName = "jusa_name";
            this.multiLayoutItem1078.IsUpdItem = true;
            // 
            // multiLayoutItem1079
            // 
            this.multiLayoutItem1079.DataName = "jusa_spd_gubun";
            this.multiLayoutItem1079.IsUpdItem = true;
            // 
            // multiLayoutItem1080
            // 
            this.multiLayoutItem1080.DataName = "bogyong_code";
            this.multiLayoutItem1080.IsUpdItem = true;
            // 
            // multiLayoutItem1081
            // 
            this.multiLayoutItem1081.DataName = "bogyong_name";
            this.multiLayoutItem1081.IsUpdItem = true;
            // 
            // multiLayoutItem1082
            // 
            this.multiLayoutItem1082.DataName = "emergency";
            this.multiLayoutItem1082.IsUpdItem = true;
            // 
            // multiLayoutItem1083
            // 
            this.multiLayoutItem1083.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem1083.IsUpdItem = true;
            // 
            // multiLayoutItem1084
            // 
            this.multiLayoutItem1084.DataName = "jundal_table";
            this.multiLayoutItem1084.IsUpdItem = true;
            // 
            // multiLayoutItem1085
            // 
            this.multiLayoutItem1085.DataName = "jundal_part";
            this.multiLayoutItem1085.IsUpdItem = true;
            // 
            // multiLayoutItem1086
            // 
            this.multiLayoutItem1086.DataName = "move_part";
            this.multiLayoutItem1086.IsUpdItem = true;
            // 
            // multiLayoutItem1087
            // 
            this.multiLayoutItem1087.DataName = "portable_yn";
            this.multiLayoutItem1087.IsUpdItem = true;
            // 
            // multiLayoutItem1088
            // 
            this.multiLayoutItem1088.DataName = "powder_yn";
            this.multiLayoutItem1088.IsUpdItem = true;
            // 
            // multiLayoutItem1089
            // 
            this.multiLayoutItem1089.DataName = "hubal_change_yn";
            this.multiLayoutItem1089.IsUpdItem = true;
            // 
            // multiLayoutItem1090
            // 
            this.multiLayoutItem1090.DataName = "pharmacy";
            this.multiLayoutItem1090.IsUpdItem = true;
            // 
            // multiLayoutItem1091
            // 
            this.multiLayoutItem1091.DataName = "drg_pack_yn";
            this.multiLayoutItem1091.IsUpdItem = true;
            // 
            // multiLayoutItem1092
            // 
            this.multiLayoutItem1092.DataName = "muhyo";
            this.multiLayoutItem1092.IsUpdItem = true;
            // 
            // multiLayoutItem1093
            // 
            this.multiLayoutItem1093.DataName = "prn_yn";
            this.multiLayoutItem1093.IsUpdItem = true;
            // 
            // multiLayoutItem1094
            // 
            this.multiLayoutItem1094.DataName = "toiwon_drg_yn";
            this.multiLayoutItem1094.IsUpdItem = true;
            // 
            // multiLayoutItem1095
            // 
            this.multiLayoutItem1095.DataName = "prn_nurse";
            this.multiLayoutItem1095.IsUpdItem = true;
            // 
            // multiLayoutItem1096
            // 
            this.multiLayoutItem1096.DataName = "append_yn";
            this.multiLayoutItem1096.IsUpdItem = true;
            // 
            // multiLayoutItem1097
            // 
            this.multiLayoutItem1097.DataName = "order_remark";
            this.multiLayoutItem1097.IsUpdItem = true;
            // 
            // multiLayoutItem1098
            // 
            this.multiLayoutItem1098.DataName = "nurse_remark";
            this.multiLayoutItem1098.IsUpdItem = true;
            // 
            // multiLayoutItem1099
            // 
            this.multiLayoutItem1099.DataName = "comment";
            this.multiLayoutItem1099.IsUpdItem = true;
            // 
            // multiLayoutItem1100
            // 
            this.multiLayoutItem1100.DataName = "mix_group";
            this.multiLayoutItem1100.IsUpdItem = true;
            // 
            // multiLayoutItem1101
            // 
            this.multiLayoutItem1101.DataName = "amt";
            this.multiLayoutItem1101.IsUpdItem = true;
            // 
            // multiLayoutItem1102
            // 
            this.multiLayoutItem1102.DataName = "pay";
            this.multiLayoutItem1102.IsUpdItem = true;
            // 
            // multiLayoutItem1103
            // 
            this.multiLayoutItem1103.DataName = "wonyoi_order_yn";
            this.multiLayoutItem1103.IsUpdItem = true;
            // 
            // multiLayoutItem1104
            // 
            this.multiLayoutItem1104.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem1104.IsUpdItem = true;
            // 
            // multiLayoutItem1105
            // 
            this.multiLayoutItem1105.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem1105.IsUpdItem = true;
            // 
            // multiLayoutItem1106
            // 
            this.multiLayoutItem1106.DataName = "bom_occur_yn";
            this.multiLayoutItem1106.IsUpdItem = true;
            // 
            // multiLayoutItem1107
            // 
            this.multiLayoutItem1107.DataName = "bom_source_key";
            this.multiLayoutItem1107.IsUpdItem = true;
            // 
            // multiLayoutItem1108
            // 
            this.multiLayoutItem1108.DataName = "display_yn";
            this.multiLayoutItem1108.IsUpdItem = true;
            // 
            // multiLayoutItem1109
            // 
            this.multiLayoutItem1109.DataName = "sunab_yn";
            this.multiLayoutItem1109.IsUpdItem = true;
            // 
            // multiLayoutItem1110
            // 
            this.multiLayoutItem1110.DataName = "sunab_date";
            this.multiLayoutItem1110.IsUpdItem = true;
            // 
            // multiLayoutItem1111
            // 
            this.multiLayoutItem1111.DataName = "sunab_time";
            this.multiLayoutItem1111.IsUpdItem = true;
            // 
            // multiLayoutItem1112
            // 
            this.multiLayoutItem1112.DataName = "hope_date";
            this.multiLayoutItem1112.IsUpdItem = true;
            // 
            // multiLayoutItem1113
            // 
            this.multiLayoutItem1113.DataName = "hope_time";
            this.multiLayoutItem1113.IsUpdItem = true;
            // 
            // multiLayoutItem1114
            // 
            this.multiLayoutItem1114.DataName = "nurse_confirm_user";
            this.multiLayoutItem1114.IsUpdItem = true;
            // 
            // multiLayoutItem1115
            // 
            this.multiLayoutItem1115.DataName = "nurse_confirm_date";
            this.multiLayoutItem1115.IsUpdItem = true;
            // 
            // multiLayoutItem1116
            // 
            this.multiLayoutItem1116.DataName = "nurse_confirm_time";
            this.multiLayoutItem1116.IsUpdItem = true;
            // 
            // multiLayoutItem1117
            // 
            this.multiLayoutItem1117.DataName = "nurse_pickup_user";
            this.multiLayoutItem1117.IsUpdItem = true;
            // 
            // multiLayoutItem1118
            // 
            this.multiLayoutItem1118.DataName = "nurse_pickup_date";
            this.multiLayoutItem1118.IsUpdItem = true;
            // 
            // multiLayoutItem1119
            // 
            this.multiLayoutItem1119.DataName = "nurse_pickup_time";
            this.multiLayoutItem1119.IsUpdItem = true;
            // 
            // multiLayoutItem1120
            // 
            this.multiLayoutItem1120.DataName = "nurse_hold_user";
            this.multiLayoutItem1120.IsUpdItem = true;
            // 
            // multiLayoutItem1121
            // 
            this.multiLayoutItem1121.DataName = "nurse_hold_date";
            this.multiLayoutItem1121.IsUpdItem = true;
            // 
            // multiLayoutItem1122
            // 
            this.multiLayoutItem1122.DataName = "nurse_hold_time";
            this.multiLayoutItem1122.IsUpdItem = true;
            // 
            // multiLayoutItem1123
            // 
            this.multiLayoutItem1123.DataName = "reser_date";
            this.multiLayoutItem1123.IsUpdItem = true;
            // 
            // multiLayoutItem1124
            // 
            this.multiLayoutItem1124.DataName = "reser_time";
            this.multiLayoutItem1124.IsUpdItem = true;
            // 
            // multiLayoutItem1125
            // 
            this.multiLayoutItem1125.DataName = "jubsu_date";
            this.multiLayoutItem1125.IsUpdItem = true;
            // 
            // multiLayoutItem1126
            // 
            this.multiLayoutItem1126.DataName = "jubsu_time";
            this.multiLayoutItem1126.IsUpdItem = true;
            // 
            // multiLayoutItem1127
            // 
            this.multiLayoutItem1127.DataName = "acting_date";
            this.multiLayoutItem1127.IsUpdItem = true;
            // 
            // multiLayoutItem1128
            // 
            this.multiLayoutItem1128.DataName = "acting_time";
            this.multiLayoutItem1128.IsUpdItem = true;
            // 
            // multiLayoutItem1129
            // 
            this.multiLayoutItem1129.DataName = "acting_day";
            this.multiLayoutItem1129.IsUpdItem = true;
            // 
            // multiLayoutItem1130
            // 
            this.multiLayoutItem1130.DataName = "result_date";
            this.multiLayoutItem1130.IsUpdItem = true;
            // 
            // multiLayoutItem1131
            // 
            this.multiLayoutItem1131.DataName = "dc_gubun";
            this.multiLayoutItem1131.IsUpdItem = true;
            // 
            // multiLayoutItem1132
            // 
            this.multiLayoutItem1132.DataName = "dc_yn";
            this.multiLayoutItem1132.IsUpdItem = true;
            // 
            // multiLayoutItem1133
            // 
            this.multiLayoutItem1133.DataName = "bannab_yn";
            this.multiLayoutItem1133.IsUpdItem = true;
            // 
            // multiLayoutItem1134
            // 
            this.multiLayoutItem1134.DataName = "bannab_confirm";
            this.multiLayoutItem1134.IsUpdItem = true;
            // 
            // multiLayoutItem1135
            // 
            this.multiLayoutItem1135.DataName = "source_ord_key";
            this.multiLayoutItem1135.IsUpdItem = true;
            // 
            // multiLayoutItem1136
            // 
            this.multiLayoutItem1136.DataName = "ocs_flag";
            this.multiLayoutItem1136.IsUpdItem = true;
            // 
            // multiLayoutItem1137
            // 
            this.multiLayoutItem1137.DataName = "sg_code";
            this.multiLayoutItem1137.IsUpdItem = true;
            // 
            // multiLayoutItem1138
            // 
            this.multiLayoutItem1138.DataName = "sg_ymd";
            this.multiLayoutItem1138.IsUpdItem = true;
            // 
            // multiLayoutItem1139
            // 
            this.multiLayoutItem1139.DataName = "io_gubun";
            this.multiLayoutItem1139.IsUpdItem = true;
            // 
            // multiLayoutItem1140
            // 
            this.multiLayoutItem1140.DataName = "after_act_yn";
            this.multiLayoutItem1140.IsUpdItem = true;
            // 
            // multiLayoutItem1141
            // 
            this.multiLayoutItem1141.DataName = "bichi_yn";
            this.multiLayoutItem1141.IsUpdItem = true;
            // 
            // multiLayoutItem1142
            // 
            this.multiLayoutItem1142.DataName = "drg_bunho";
            this.multiLayoutItem1142.IsUpdItem = true;
            // 
            // multiLayoutItem1143
            // 
            this.multiLayoutItem1143.DataName = "sub_susul";
            this.multiLayoutItem1143.IsUpdItem = true;
            // 
            // multiLayoutItem1144
            // 
            this.multiLayoutItem1144.DataName = "print_yn";
            this.multiLayoutItem1144.IsUpdItem = true;
            // 
            // multiLayoutItem1145
            // 
            this.multiLayoutItem1145.DataName = "chisik";
            this.multiLayoutItem1145.IsUpdItem = true;
            // 
            // multiLayoutItem1146
            // 
            this.multiLayoutItem1146.DataName = "tel_yn";
            this.multiLayoutItem1146.IsUpdItem = true;
            // 
            // multiLayoutItem1147
            // 
            this.multiLayoutItem1147.DataName = "order_gubun_bas";
            this.multiLayoutItem1147.IsUpdItem = true;
            // 
            // multiLayoutItem1148
            // 
            this.multiLayoutItem1148.DataName = "input_control";
            this.multiLayoutItem1148.IsUpdItem = true;
            // 
            // multiLayoutItem1149
            // 
            this.multiLayoutItem1149.DataName = "suga_yn";
            this.multiLayoutItem1149.IsUpdItem = true;
            // 
            // multiLayoutItem1150
            // 
            this.multiLayoutItem1150.DataName = "jaeryo_yn";
            this.multiLayoutItem1150.IsUpdItem = true;
            // 
            // multiLayoutItem1151
            // 
            this.multiLayoutItem1151.DataName = "wonyoi_check";
            this.multiLayoutItem1151.IsUpdItem = true;
            // 
            // multiLayoutItem1152
            // 
            this.multiLayoutItem1152.DataName = "emergency_check";
            this.multiLayoutItem1152.IsUpdItem = true;
            // 
            // multiLayoutItem1153
            // 
            this.multiLayoutItem1153.DataName = "specimen_check";
            // 
            // multiLayoutItem1154
            // 
            this.multiLayoutItem1154.DataName = "portable_check";
            this.multiLayoutItem1154.IsUpdItem = true;
            // 
            // multiLayoutItem1155
            // 
            this.multiLayoutItem1155.DataName = "bulyong_check";
            this.multiLayoutItem1155.IsUpdItem = true;
            // 
            // multiLayoutItem1156
            // 
            this.multiLayoutItem1156.DataName = "sunab_check";
            // 
            // multiLayoutItem1157
            // 
            this.multiLayoutItem1157.DataName = "dc_check";
            // 
            // multiLayoutItem1158
            // 
            this.multiLayoutItem1158.DataName = "dc_gubun_check";
            this.multiLayoutItem1158.IsUpdItem = true;
            // 
            // multiLayoutItem1159
            // 
            this.multiLayoutItem1159.DataName = "confirm_check";
            this.multiLayoutItem1159.IsUpdItem = true;
            // 
            // multiLayoutItem1160
            // 
            this.multiLayoutItem1160.DataName = "reser_yn_check";
            this.multiLayoutItem1160.IsUpdItem = true;
            // 
            // multiLayoutItem1161
            // 
            this.multiLayoutItem1161.DataName = "chisik_check";
            this.multiLayoutItem1161.IsUpdItem = true;
            // 
            // multiLayoutItem1162
            // 
            this.multiLayoutItem1162.DataName = "nday_yn";
            this.multiLayoutItem1162.IsUpdItem = true;
            // 
            // multiLayoutItem1163
            // 
            this.multiLayoutItem1163.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem1163.IsUpdItem = true;
            // 
            // multiLayoutItem1164
            // 
            this.multiLayoutItem1164.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem1164.IsUpdItem = true;
            // 
            // multiLayoutItem1165
            // 
            this.multiLayoutItem1165.DataName = "specific_comment";
            this.multiLayoutItem1165.IsUpdItem = true;
            // 
            // multiLayoutItem1166
            // 
            this.multiLayoutItem1166.DataName = "specific_comment_name";
            this.multiLayoutItem1166.IsUpdItem = true;
            // 
            // multiLayoutItem1167
            // 
            this.multiLayoutItem1167.DataName = "specific_comment_sys_id";
            this.multiLayoutItem1167.IsUpdItem = true;
            // 
            // multiLayoutItem1168
            // 
            this.multiLayoutItem1168.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem1168.IsUpdItem = true;
            // 
            // multiLayoutItem1169
            // 
            this.multiLayoutItem1169.DataName = "specific_comment_not_null";
            this.multiLayoutItem1169.IsUpdItem = true;
            // 
            // multiLayoutItem1170
            // 
            this.multiLayoutItem1170.DataName = "specific_comment_table_id";
            this.multiLayoutItem1170.IsUpdItem = true;
            // 
            // multiLayoutItem1171
            // 
            this.multiLayoutItem1171.DataName = "specific_comment_col_id";
            this.multiLayoutItem1171.IsUpdItem = true;
            // 
            // multiLayoutItem1172
            // 
            this.multiLayoutItem1172.DataName = "donbog_yn";
            this.multiLayoutItem1172.IsUpdItem = true;
            // 
            // multiLayoutItem1173
            // 
            this.multiLayoutItem1173.DataName = "order_gubun_bas_name";
            this.multiLayoutItem1173.IsUpdItem = true;
            // 
            // multiLayoutItem1174
            // 
            this.multiLayoutItem1174.DataName = "act_doctoor";
            this.multiLayoutItem1174.IsUpdItem = true;
            // 
            // multiLayoutItem1175
            // 
            this.multiLayoutItem1175.DataName = "act_buseo";
            this.multiLayoutItem1175.IsUpdItem = true;
            // 
            // multiLayoutItem1176
            // 
            this.multiLayoutItem1176.DataName = "act_gwa";
            this.multiLayoutItem1176.IsUpdItem = true;
            // 
            // multiLayoutItem1177
            // 
            this.multiLayoutItem1177.DataName = "home_care_yn";
            this.multiLayoutItem1177.IsUpdItem = true;
            // 
            // multiLayoutItem1178
            // 
            this.multiLayoutItem1178.DataName = "regular_yn";
            this.multiLayoutItem1178.IsUpdItem = true;
            // 
            // multiLayoutItem1179
            // 
            this.multiLayoutItem1179.DataName = "sort_fkocskey";
            this.multiLayoutItem1179.IsUpdItem = true;
            // 
            // multiLayoutItem1180
            // 
            this.multiLayoutItem1180.DataName = "child_yn";
            this.multiLayoutItem1180.IsUpdItem = true;
            // 
            // multiLayoutItem1181
            // 
            this.multiLayoutItem1181.DataName = "if_input_control";
            // 
            // multiLayoutItem1182
            // 
            this.multiLayoutItem1182.DataName = "slip_name";
            // 
            // multiLayoutItem1183
            // 
            this.multiLayoutItem1183.DataName = "org_key";
            // 
            // multiLayoutItem1184
            // 
            this.multiLayoutItem1184.DataName = "parent_key";
            // 
            // multiLayoutItem1185
            // 
            this.multiLayoutItem1185.DataName = "bun_code";
            // 
            // multiLayoutItem1946
            // 
            this.multiLayoutItem1946.DataName = "wonnae_drg_yn";
            // 
            // layDrugOrder
            // 
            this.layDrugOrder.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem421,
            this.multiLayoutItem422,
            this.multiLayoutItem423,
            this.multiLayoutItem424,
            this.multiLayoutItem425,
            this.multiLayoutItem426,
            this.multiLayoutItem427,
            this.multiLayoutItem428,
            this.multiLayoutItem429,
            this.multiLayoutItem430,
            this.multiLayoutItem431,
            this.multiLayoutItem1792,
            this.multiLayoutItem1793,
            this.multiLayoutItem1794,
            this.multiLayoutItem1795,
            this.multiLayoutItem1796,
            this.multiLayoutItem1797,
            this.multiLayoutItem1798,
            this.multiLayoutItem1799,
            this.multiLayoutItem1800,
            this.multiLayoutItem1801,
            this.multiLayoutItem1802,
            this.multiLayoutItem1803,
            this.multiLayoutItem1804,
            this.multiLayoutItem1805,
            this.multiLayoutItem1806,
            this.multiLayoutItem1807,
            this.multiLayoutItem1808,
            this.multiLayoutItem1809,
            this.multiLayoutItem1810,
            this.multiLayoutItem1811,
            this.multiLayoutItem1812,
            this.multiLayoutItem1813,
            this.multiLayoutItem1814,
            this.multiLayoutItem1815,
            this.multiLayoutItem1816,
            this.multiLayoutItem1817,
            this.multiLayoutItem1818,
            this.multiLayoutItem1819,
            this.multiLayoutItem1820,
            this.multiLayoutItem1821,
            this.multiLayoutItem1822,
            this.multiLayoutItem1823,
            this.multiLayoutItem1824,
            this.multiLayoutItem1825,
            this.multiLayoutItem1826,
            this.multiLayoutItem1827,
            this.multiLayoutItem1828,
            this.multiLayoutItem1829,
            this.multiLayoutItem1830,
            this.multiLayoutItem1831,
            this.multiLayoutItem1832,
            this.multiLayoutItem1833,
            this.multiLayoutItem1834,
            this.multiLayoutItem1835,
            this.multiLayoutItem1836,
            this.multiLayoutItem1837,
            this.multiLayoutItem1838,
            this.multiLayoutItem1839,
            this.multiLayoutItem1840,
            this.multiLayoutItem1841,
            this.multiLayoutItem1842,
            this.multiLayoutItem1843,
            this.multiLayoutItem1844,
            this.multiLayoutItem1845,
            this.multiLayoutItem1846,
            this.multiLayoutItem1847,
            this.multiLayoutItem1848,
            this.multiLayoutItem1849,
            this.multiLayoutItem1850,
            this.multiLayoutItem1851,
            this.multiLayoutItem1852,
            this.multiLayoutItem1853,
            this.multiLayoutItem1854,
            this.multiLayoutItem1855,
            this.multiLayoutItem1856,
            this.multiLayoutItem1857,
            this.multiLayoutItem1858,
            this.multiLayoutItem1859,
            this.multiLayoutItem1860,
            this.multiLayoutItem1861,
            this.multiLayoutItem1862,
            this.multiLayoutItem1863,
            this.multiLayoutItem1864,
            this.multiLayoutItem1865,
            this.multiLayoutItem1866,
            this.multiLayoutItem1867,
            this.multiLayoutItem1868,
            this.multiLayoutItem1869,
            this.multiLayoutItem1870,
            this.multiLayoutItem1871,
            this.multiLayoutItem1872,
            this.multiLayoutItem1873,
            this.multiLayoutItem1874,
            this.multiLayoutItem1875,
            this.multiLayoutItem1876,
            this.multiLayoutItem1877,
            this.multiLayoutItem1878,
            this.multiLayoutItem1879,
            this.multiLayoutItem1880,
            this.multiLayoutItem1881,
            this.multiLayoutItem1882,
            this.multiLayoutItem1883,
            this.multiLayoutItem1884,
            this.multiLayoutItem1885,
            this.multiLayoutItem1886,
            this.multiLayoutItem1887,
            this.multiLayoutItem1888,
            this.multiLayoutItem1889,
            this.multiLayoutItem1890,
            this.multiLayoutItem1891,
            this.multiLayoutItem1892,
            this.multiLayoutItem1893,
            this.multiLayoutItem1894,
            this.multiLayoutItem1895,
            this.multiLayoutItem1896,
            this.multiLayoutItem1897,
            this.multiLayoutItem1898,
            this.multiLayoutItem1899,
            this.multiLayoutItem1900,
            this.multiLayoutItem1901,
            this.multiLayoutItem1902,
            this.multiLayoutItem1903,
            this.multiLayoutItem1904,
            this.multiLayoutItem1905,
            this.multiLayoutItem1906,
            this.multiLayoutItem1907,
            this.multiLayoutItem1908,
            this.multiLayoutItem1909,
            this.multiLayoutItem1910,
            this.multiLayoutItem1911,
            this.multiLayoutItem1912,
            this.multiLayoutItem1913,
            this.multiLayoutItem1914,
            this.multiLayoutItem1915,
            this.multiLayoutItem1916,
            this.multiLayoutItem1917,
            this.multiLayoutItem1918,
            this.multiLayoutItem1919,
            this.multiLayoutItem1920,
            this.multiLayoutItem1921,
            this.multiLayoutItem1922,
            this.multiLayoutItem1923,
            this.multiLayoutItem1924,
            this.multiLayoutItem1925,
            this.multiLayoutItem1926,
            this.multiLayoutItem1927,
            this.multiLayoutItem1942,
            this.multiLayoutItem1943,
            this.multiLayoutItem1944,
            this.multiLayoutItem1945,
            this.multiLayoutItem1947});
            // 
            // multiLayoutItem421
            // 
            this.multiLayoutItem421.DataName = "in_out_key";
            this.multiLayoutItem421.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem421.IsUpdItem = true;
            // 
            // multiLayoutItem422
            // 
            this.multiLayoutItem422.DataName = "pkocskey";
            this.multiLayoutItem422.IsUpdItem = true;
            // 
            // multiLayoutItem423
            // 
            this.multiLayoutItem423.DataName = "bunho";
            this.multiLayoutItem423.IsUpdItem = true;
            // 
            // multiLayoutItem424
            // 
            this.multiLayoutItem424.DataName = "order_date";
            this.multiLayoutItem424.IsUpdItem = true;
            // 
            // multiLayoutItem425
            // 
            this.multiLayoutItem425.DataName = "gwa";
            this.multiLayoutItem425.IsUpdItem = true;
            // 
            // multiLayoutItem426
            // 
            this.multiLayoutItem426.DataName = "doctor";
            this.multiLayoutItem426.IsUpdItem = true;
            // 
            // multiLayoutItem427
            // 
            this.multiLayoutItem427.DataName = "resident";
            this.multiLayoutItem427.IsUpdItem = true;
            // 
            // multiLayoutItem428
            // 
            this.multiLayoutItem428.DataName = "naewon_type";
            this.multiLayoutItem428.IsUpdItem = true;
            // 
            // multiLayoutItem429
            // 
            this.multiLayoutItem429.DataName = "jubsu_no";
            this.multiLayoutItem429.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem429.IsUpdItem = true;
            // 
            // multiLayoutItem430
            // 
            this.multiLayoutItem430.DataName = "input_id";
            this.multiLayoutItem430.IsUpdItem = true;
            // 
            // multiLayoutItem431
            // 
            this.multiLayoutItem431.DataName = "input_part";
            this.multiLayoutItem431.IsUpdItem = true;
            // 
            // multiLayoutItem1792
            // 
            this.multiLayoutItem1792.DataName = "input_gwa";
            this.multiLayoutItem1792.IsUpdItem = true;
            // 
            // multiLayoutItem1793
            // 
            this.multiLayoutItem1793.DataName = "input_doctor";
            this.multiLayoutItem1793.IsUpdItem = true;
            // 
            // multiLayoutItem1794
            // 
            this.multiLayoutItem1794.DataName = "input_gubun";
            this.multiLayoutItem1794.IsUpdItem = true;
            // 
            // multiLayoutItem1795
            // 
            this.multiLayoutItem1795.DataName = "input_gubun_name";
            // 
            // multiLayoutItem1796
            // 
            this.multiLayoutItem1796.DataName = "group_ser";
            this.multiLayoutItem1796.IsUpdItem = true;
            // 
            // multiLayoutItem1797
            // 
            this.multiLayoutItem1797.DataName = "input_tab";
            this.multiLayoutItem1797.IsUpdItem = true;
            // 
            // multiLayoutItem1798
            // 
            this.multiLayoutItem1798.DataName = "input_tab_name";
            // 
            // multiLayoutItem1799
            // 
            this.multiLayoutItem1799.DataName = "order_gubun";
            this.multiLayoutItem1799.IsUpdItem = true;
            // 
            // multiLayoutItem1800
            // 
            this.multiLayoutItem1800.DataName = "order_gubun_name";
            // 
            // multiLayoutItem1801
            // 
            this.multiLayoutItem1801.DataName = "group_yn";
            this.multiLayoutItem1801.IsUpdItem = true;
            // 
            // multiLayoutItem1802
            // 
            this.multiLayoutItem1802.DataName = "seq";
            this.multiLayoutItem1802.IsUpdItem = true;
            // 
            // multiLayoutItem1803
            // 
            this.multiLayoutItem1803.DataName = "slip_code";
            this.multiLayoutItem1803.IsUpdItem = true;
            // 
            // multiLayoutItem1804
            // 
            this.multiLayoutItem1804.DataName = "hangmog_code";
            this.multiLayoutItem1804.IsUpdItem = true;
            // 
            // multiLayoutItem1805
            // 
            this.multiLayoutItem1805.DataName = "hangmog_name";
            // 
            // multiLayoutItem1806
            // 
            this.multiLayoutItem1806.DataName = "specimen_code";
            this.multiLayoutItem1806.IsUpdItem = true;
            // 
            // multiLayoutItem1807
            // 
            this.multiLayoutItem1807.DataName = "specimen_name";
            // 
            // multiLayoutItem1808
            // 
            this.multiLayoutItem1808.DataName = "suryang";
            this.multiLayoutItem1808.IsUpdItem = true;
            // 
            // multiLayoutItem1809
            // 
            this.multiLayoutItem1809.DataName = "sunab_suryang";
            this.multiLayoutItem1809.IsUpdItem = true;
            // 
            // multiLayoutItem1810
            // 
            this.multiLayoutItem1810.DataName = "subul_suryang";
            this.multiLayoutItem1810.IsUpdItem = true;
            // 
            // multiLayoutItem1811
            // 
            this.multiLayoutItem1811.DataName = "ord_danui";
            this.multiLayoutItem1811.IsUpdItem = true;
            // 
            // multiLayoutItem1812
            // 
            this.multiLayoutItem1812.DataName = "ord_danui_name";
            // 
            // multiLayoutItem1813
            // 
            this.multiLayoutItem1813.DataName = "dv_time";
            this.multiLayoutItem1813.IsUpdItem = true;
            // 
            // multiLayoutItem1814
            // 
            this.multiLayoutItem1814.DataName = "dv";
            this.multiLayoutItem1814.IsUpdItem = true;
            // 
            // multiLayoutItem1815
            // 
            this.multiLayoutItem1815.DataName = "dv_1";
            this.multiLayoutItem1815.IsUpdItem = true;
            // 
            // multiLayoutItem1816
            // 
            this.multiLayoutItem1816.DataName = "dv_2";
            this.multiLayoutItem1816.IsUpdItem = true;
            // 
            // multiLayoutItem1817
            // 
            this.multiLayoutItem1817.DataName = "dv_3";
            this.multiLayoutItem1817.IsUpdItem = true;
            // 
            // multiLayoutItem1818
            // 
            this.multiLayoutItem1818.DataName = "dv_4";
            this.multiLayoutItem1818.IsUpdItem = true;
            // 
            // multiLayoutItem1819
            // 
            this.multiLayoutItem1819.DataName = "nalsu";
            this.multiLayoutItem1819.IsUpdItem = true;
            // 
            // multiLayoutItem1820
            // 
            this.multiLayoutItem1820.DataName = "sunab_nalsu";
            this.multiLayoutItem1820.IsUpdItem = true;
            // 
            // multiLayoutItem1821
            // 
            this.multiLayoutItem1821.DataName = "jusa";
            this.multiLayoutItem1821.IsUpdItem = true;
            // 
            // multiLayoutItem1822
            // 
            this.multiLayoutItem1822.DataName = "jusa_name";
            this.multiLayoutItem1822.IsUpdItem = true;
            // 
            // multiLayoutItem1823
            // 
            this.multiLayoutItem1823.DataName = "jusa_spd_gubun";
            this.multiLayoutItem1823.IsUpdItem = true;
            // 
            // multiLayoutItem1824
            // 
            this.multiLayoutItem1824.DataName = "bogyong_code";
            this.multiLayoutItem1824.IsUpdItem = true;
            // 
            // multiLayoutItem1825
            // 
            this.multiLayoutItem1825.DataName = "bogyong_name";
            this.multiLayoutItem1825.IsUpdItem = true;
            // 
            // multiLayoutItem1826
            // 
            this.multiLayoutItem1826.DataName = "emergency";
            this.multiLayoutItem1826.IsUpdItem = true;
            // 
            // multiLayoutItem1827
            // 
            this.multiLayoutItem1827.DataName = "jaeryo_jundal_yn";
            this.multiLayoutItem1827.IsUpdItem = true;
            // 
            // multiLayoutItem1828
            // 
            this.multiLayoutItem1828.DataName = "jundal_table";
            this.multiLayoutItem1828.IsUpdItem = true;
            // 
            // multiLayoutItem1829
            // 
            this.multiLayoutItem1829.DataName = "jundal_part";
            this.multiLayoutItem1829.IsUpdItem = true;
            // 
            // multiLayoutItem1830
            // 
            this.multiLayoutItem1830.DataName = "move_part";
            this.multiLayoutItem1830.IsUpdItem = true;
            // 
            // multiLayoutItem1831
            // 
            this.multiLayoutItem1831.DataName = "portable_yn";
            this.multiLayoutItem1831.IsUpdItem = true;
            // 
            // multiLayoutItem1832
            // 
            this.multiLayoutItem1832.DataName = "powder_yn";
            this.multiLayoutItem1832.IsUpdItem = true;
            // 
            // multiLayoutItem1833
            // 
            this.multiLayoutItem1833.DataName = "hubal_change_yn";
            this.multiLayoutItem1833.IsUpdItem = true;
            // 
            // multiLayoutItem1834
            // 
            this.multiLayoutItem1834.DataName = "pharmacy";
            this.multiLayoutItem1834.IsUpdItem = true;
            // 
            // multiLayoutItem1835
            // 
            this.multiLayoutItem1835.DataName = "drg_pack_yn";
            this.multiLayoutItem1835.IsUpdItem = true;
            // 
            // multiLayoutItem1836
            // 
            this.multiLayoutItem1836.DataName = "muhyo";
            this.multiLayoutItem1836.IsUpdItem = true;
            // 
            // multiLayoutItem1837
            // 
            this.multiLayoutItem1837.DataName = "prn_yn";
            this.multiLayoutItem1837.IsUpdItem = true;
            // 
            // multiLayoutItem1838
            // 
            this.multiLayoutItem1838.DataName = "toiwon_drg_yn";
            this.multiLayoutItem1838.IsUpdItem = true;
            // 
            // multiLayoutItem1839
            // 
            this.multiLayoutItem1839.DataName = "prn_nurse";
            this.multiLayoutItem1839.IsUpdItem = true;
            // 
            // multiLayoutItem1840
            // 
            this.multiLayoutItem1840.DataName = "append_yn";
            this.multiLayoutItem1840.IsUpdItem = true;
            // 
            // multiLayoutItem1841
            // 
            this.multiLayoutItem1841.DataName = "order_remark";
            this.multiLayoutItem1841.IsUpdItem = true;
            // 
            // multiLayoutItem1842
            // 
            this.multiLayoutItem1842.DataName = "nurse_remark";
            this.multiLayoutItem1842.IsUpdItem = true;
            // 
            // multiLayoutItem1843
            // 
            this.multiLayoutItem1843.DataName = "comment";
            this.multiLayoutItem1843.IsUpdItem = true;
            // 
            // multiLayoutItem1844
            // 
            this.multiLayoutItem1844.DataName = "mix_group";
            this.multiLayoutItem1844.IsUpdItem = true;
            // 
            // multiLayoutItem1845
            // 
            this.multiLayoutItem1845.DataName = "amt";
            this.multiLayoutItem1845.IsUpdItem = true;
            // 
            // multiLayoutItem1846
            // 
            this.multiLayoutItem1846.DataName = "pay";
            this.multiLayoutItem1846.IsUpdItem = true;
            // 
            // multiLayoutItem1847
            // 
            this.multiLayoutItem1847.DataName = "wonyoi_order_yn";
            this.multiLayoutItem1847.IsUpdItem = true;
            // 
            // multiLayoutItem1848
            // 
            this.multiLayoutItem1848.DataName = "dangil_gumsa_order_yn";
            this.multiLayoutItem1848.IsUpdItem = true;
            // 
            // multiLayoutItem1849
            // 
            this.multiLayoutItem1849.DataName = "dangil_gumsa_result_yn";
            this.multiLayoutItem1849.IsUpdItem = true;
            // 
            // multiLayoutItem1850
            // 
            this.multiLayoutItem1850.DataName = "bom_occur_yn";
            this.multiLayoutItem1850.IsUpdItem = true;
            // 
            // multiLayoutItem1851
            // 
            this.multiLayoutItem1851.DataName = "bom_source_key";
            this.multiLayoutItem1851.IsUpdItem = true;
            // 
            // multiLayoutItem1852
            // 
            this.multiLayoutItem1852.DataName = "display_yn";
            this.multiLayoutItem1852.IsUpdItem = true;
            // 
            // multiLayoutItem1853
            // 
            this.multiLayoutItem1853.DataName = "sunab_yn";
            this.multiLayoutItem1853.IsUpdItem = true;
            // 
            // multiLayoutItem1854
            // 
            this.multiLayoutItem1854.DataName = "sunab_date";
            this.multiLayoutItem1854.IsUpdItem = true;
            // 
            // multiLayoutItem1855
            // 
            this.multiLayoutItem1855.DataName = "sunab_time";
            this.multiLayoutItem1855.IsUpdItem = true;
            // 
            // multiLayoutItem1856
            // 
            this.multiLayoutItem1856.DataName = "hope_date";
            this.multiLayoutItem1856.IsUpdItem = true;
            // 
            // multiLayoutItem1857
            // 
            this.multiLayoutItem1857.DataName = "hope_time";
            this.multiLayoutItem1857.IsUpdItem = true;
            // 
            // multiLayoutItem1858
            // 
            this.multiLayoutItem1858.DataName = "nurse_confirm_user";
            this.multiLayoutItem1858.IsUpdItem = true;
            // 
            // multiLayoutItem1859
            // 
            this.multiLayoutItem1859.DataName = "nurse_confirm_date";
            this.multiLayoutItem1859.IsUpdItem = true;
            // 
            // multiLayoutItem1860
            // 
            this.multiLayoutItem1860.DataName = "nurse_confirm_time";
            this.multiLayoutItem1860.IsUpdItem = true;
            // 
            // multiLayoutItem1861
            // 
            this.multiLayoutItem1861.DataName = "nurse_pickup_user";
            this.multiLayoutItem1861.IsUpdItem = true;
            // 
            // multiLayoutItem1862
            // 
            this.multiLayoutItem1862.DataName = "nurse_pickup_date";
            this.multiLayoutItem1862.IsUpdItem = true;
            // 
            // multiLayoutItem1863
            // 
            this.multiLayoutItem1863.DataName = "nurse_pickup_time";
            this.multiLayoutItem1863.IsUpdItem = true;
            // 
            // multiLayoutItem1864
            // 
            this.multiLayoutItem1864.DataName = "nurse_hold_user";
            this.multiLayoutItem1864.IsUpdItem = true;
            // 
            // multiLayoutItem1865
            // 
            this.multiLayoutItem1865.DataName = "nurse_hold_date";
            this.multiLayoutItem1865.IsUpdItem = true;
            // 
            // multiLayoutItem1866
            // 
            this.multiLayoutItem1866.DataName = "nurse_hold_time";
            this.multiLayoutItem1866.IsUpdItem = true;
            // 
            // multiLayoutItem1867
            // 
            this.multiLayoutItem1867.DataName = "reser_date";
            this.multiLayoutItem1867.IsUpdItem = true;
            // 
            // multiLayoutItem1868
            // 
            this.multiLayoutItem1868.DataName = "reser_time";
            this.multiLayoutItem1868.IsUpdItem = true;
            // 
            // multiLayoutItem1869
            // 
            this.multiLayoutItem1869.DataName = "jubsu_date";
            this.multiLayoutItem1869.IsUpdItem = true;
            // 
            // multiLayoutItem1870
            // 
            this.multiLayoutItem1870.DataName = "jubsu_time";
            this.multiLayoutItem1870.IsUpdItem = true;
            // 
            // multiLayoutItem1871
            // 
            this.multiLayoutItem1871.DataName = "acting_date";
            this.multiLayoutItem1871.IsUpdItem = true;
            // 
            // multiLayoutItem1872
            // 
            this.multiLayoutItem1872.DataName = "acting_time";
            this.multiLayoutItem1872.IsUpdItem = true;
            // 
            // multiLayoutItem1873
            // 
            this.multiLayoutItem1873.DataName = "acting_day";
            this.multiLayoutItem1873.IsUpdItem = true;
            // 
            // multiLayoutItem1874
            // 
            this.multiLayoutItem1874.DataName = "result_date";
            this.multiLayoutItem1874.IsUpdItem = true;
            // 
            // multiLayoutItem1875
            // 
            this.multiLayoutItem1875.DataName = "dc_gubun";
            this.multiLayoutItem1875.IsUpdItem = true;
            // 
            // multiLayoutItem1876
            // 
            this.multiLayoutItem1876.DataName = "dc_yn";
            this.multiLayoutItem1876.IsUpdItem = true;
            // 
            // multiLayoutItem1877
            // 
            this.multiLayoutItem1877.DataName = "bannab_yn";
            this.multiLayoutItem1877.IsUpdItem = true;
            // 
            // multiLayoutItem1878
            // 
            this.multiLayoutItem1878.DataName = "bannab_confirm";
            this.multiLayoutItem1878.IsUpdItem = true;
            // 
            // multiLayoutItem1879
            // 
            this.multiLayoutItem1879.DataName = "source_ord_key";
            this.multiLayoutItem1879.IsUpdItem = true;
            // 
            // multiLayoutItem1880
            // 
            this.multiLayoutItem1880.DataName = "ocs_flag";
            this.multiLayoutItem1880.IsUpdItem = true;
            // 
            // multiLayoutItem1881
            // 
            this.multiLayoutItem1881.DataName = "sg_code";
            this.multiLayoutItem1881.IsUpdItem = true;
            // 
            // multiLayoutItem1882
            // 
            this.multiLayoutItem1882.DataName = "sg_ymd";
            this.multiLayoutItem1882.IsUpdItem = true;
            // 
            // multiLayoutItem1883
            // 
            this.multiLayoutItem1883.DataName = "io_gubun";
            this.multiLayoutItem1883.IsUpdItem = true;
            // 
            // multiLayoutItem1884
            // 
            this.multiLayoutItem1884.DataName = "after_act_yn";
            this.multiLayoutItem1884.IsUpdItem = true;
            // 
            // multiLayoutItem1885
            // 
            this.multiLayoutItem1885.DataName = "bichi_yn";
            this.multiLayoutItem1885.IsUpdItem = true;
            // 
            // multiLayoutItem1886
            // 
            this.multiLayoutItem1886.DataName = "drg_bunho";
            this.multiLayoutItem1886.IsUpdItem = true;
            // 
            // multiLayoutItem1887
            // 
            this.multiLayoutItem1887.DataName = "sub_susul";
            this.multiLayoutItem1887.IsUpdItem = true;
            // 
            // multiLayoutItem1888
            // 
            this.multiLayoutItem1888.DataName = "print_yn";
            this.multiLayoutItem1888.IsUpdItem = true;
            // 
            // multiLayoutItem1889
            // 
            this.multiLayoutItem1889.DataName = "chisik";
            this.multiLayoutItem1889.IsUpdItem = true;
            // 
            // multiLayoutItem1890
            // 
            this.multiLayoutItem1890.DataName = "tel_yn";
            this.multiLayoutItem1890.IsUpdItem = true;
            // 
            // multiLayoutItem1891
            // 
            this.multiLayoutItem1891.DataName = "order_gubun_bas";
            this.multiLayoutItem1891.IsUpdItem = true;
            // 
            // multiLayoutItem1892
            // 
            this.multiLayoutItem1892.DataName = "input_control";
            this.multiLayoutItem1892.IsUpdItem = true;
            // 
            // multiLayoutItem1893
            // 
            this.multiLayoutItem1893.DataName = "suga_yn";
            this.multiLayoutItem1893.IsUpdItem = true;
            // 
            // multiLayoutItem1894
            // 
            this.multiLayoutItem1894.DataName = "jaeryo_yn";
            this.multiLayoutItem1894.IsUpdItem = true;
            // 
            // multiLayoutItem1895
            // 
            this.multiLayoutItem1895.DataName = "wonyoi_check";
            this.multiLayoutItem1895.IsUpdItem = true;
            // 
            // multiLayoutItem1896
            // 
            this.multiLayoutItem1896.DataName = "emergency_check";
            this.multiLayoutItem1896.IsUpdItem = true;
            // 
            // multiLayoutItem1897
            // 
            this.multiLayoutItem1897.DataName = "specimen_check";
            // 
            // multiLayoutItem1898
            // 
            this.multiLayoutItem1898.DataName = "portable_check";
            this.multiLayoutItem1898.IsUpdItem = true;
            // 
            // multiLayoutItem1899
            // 
            this.multiLayoutItem1899.DataName = "bulyong_check";
            this.multiLayoutItem1899.IsUpdItem = true;
            // 
            // multiLayoutItem1900
            // 
            this.multiLayoutItem1900.DataName = "sunab_check";
            // 
            // multiLayoutItem1901
            // 
            this.multiLayoutItem1901.DataName = "dc_check";
            // 
            // multiLayoutItem1902
            // 
            this.multiLayoutItem1902.DataName = "dc_gubun_check";
            this.multiLayoutItem1902.IsUpdItem = true;
            // 
            // multiLayoutItem1903
            // 
            this.multiLayoutItem1903.DataName = "confirm_check";
            this.multiLayoutItem1903.IsUpdItem = true;
            // 
            // multiLayoutItem1904
            // 
            this.multiLayoutItem1904.DataName = "reser_yn_check";
            this.multiLayoutItem1904.IsUpdItem = true;
            // 
            // multiLayoutItem1905
            // 
            this.multiLayoutItem1905.DataName = "chisik_check";
            this.multiLayoutItem1905.IsUpdItem = true;
            // 
            // multiLayoutItem1906
            // 
            this.multiLayoutItem1906.DataName = "nday_yn";
            this.multiLayoutItem1906.IsUpdItem = true;
            // 
            // multiLayoutItem1907
            // 
            this.multiLayoutItem1907.DataName = "default_jaeryo_jundal_yn";
            this.multiLayoutItem1907.IsUpdItem = true;
            // 
            // multiLayoutItem1908
            // 
            this.multiLayoutItem1908.DataName = "default_wonyoi_order_yn";
            this.multiLayoutItem1908.IsUpdItem = true;
            // 
            // multiLayoutItem1909
            // 
            this.multiLayoutItem1909.DataName = "specific_comment";
            this.multiLayoutItem1909.IsUpdItem = true;
            // 
            // multiLayoutItem1910
            // 
            this.multiLayoutItem1910.DataName = "specific_comment_name";
            this.multiLayoutItem1910.IsUpdItem = true;
            // 
            // multiLayoutItem1911
            // 
            this.multiLayoutItem1911.DataName = "specific_comment_sys_id";
            this.multiLayoutItem1911.IsUpdItem = true;
            // 
            // multiLayoutItem1912
            // 
            this.multiLayoutItem1912.DataName = "specific_comment_pgm_id";
            this.multiLayoutItem1912.IsUpdItem = true;
            // 
            // multiLayoutItem1913
            // 
            this.multiLayoutItem1913.DataName = "specific_comment_not_null";
            this.multiLayoutItem1913.IsUpdItem = true;
            // 
            // multiLayoutItem1914
            // 
            this.multiLayoutItem1914.DataName = "specific_comment_table_id";
            this.multiLayoutItem1914.IsUpdItem = true;
            // 
            // multiLayoutItem1915
            // 
            this.multiLayoutItem1915.DataName = "specific_comment_col_id";
            this.multiLayoutItem1915.IsUpdItem = true;
            // 
            // multiLayoutItem1916
            // 
            this.multiLayoutItem1916.DataName = "donbog_yn";
            this.multiLayoutItem1916.IsUpdItem = true;
            // 
            // multiLayoutItem1917
            // 
            this.multiLayoutItem1917.DataName = "order_gubun_bas_name";
            this.multiLayoutItem1917.IsUpdItem = true;
            // 
            // multiLayoutItem1918
            // 
            this.multiLayoutItem1918.DataName = "act_doctoor";
            this.multiLayoutItem1918.IsUpdItem = true;
            // 
            // multiLayoutItem1919
            // 
            this.multiLayoutItem1919.DataName = "act_buseo";
            this.multiLayoutItem1919.IsUpdItem = true;
            // 
            // multiLayoutItem1920
            // 
            this.multiLayoutItem1920.DataName = "act_gwa";
            this.multiLayoutItem1920.IsUpdItem = true;
            // 
            // multiLayoutItem1921
            // 
            this.multiLayoutItem1921.DataName = "home_care_yn";
            this.multiLayoutItem1921.IsUpdItem = true;
            // 
            // multiLayoutItem1922
            // 
            this.multiLayoutItem1922.DataName = "regular_yn";
            this.multiLayoutItem1922.IsUpdItem = true;
            // 
            // multiLayoutItem1923
            // 
            this.multiLayoutItem1923.DataName = "sort_fkocskey";
            this.multiLayoutItem1923.IsUpdItem = true;
            // 
            // multiLayoutItem1924
            // 
            this.multiLayoutItem1924.DataName = "child_yn";
            this.multiLayoutItem1924.IsUpdItem = true;
            // 
            // multiLayoutItem1925
            // 
            this.multiLayoutItem1925.DataName = "child_exist_yn";
            this.multiLayoutItem1925.IsUpdItem = true;
            // 
            // multiLayoutItem1926
            // 
            this.multiLayoutItem1926.DataName = "nday_occur_yn";
            this.multiLayoutItem1926.IsUpdItem = true;
            // 
            // multiLayoutItem1927
            // 
            this.multiLayoutItem1927.DataName = "bun_code";
            // 
            // multiLayoutItem1942
            // 
            this.multiLayoutItem1942.DataName = "wonnae_drg_yn";
            // 
            // multiLayoutItem1943
            // 
            this.multiLayoutItem1943.DataName = "hubal_change_check";
            // 
            // multiLayoutItem1944
            // 
            this.multiLayoutItem1944.DataName = "drg_pack_check";
            // 
            // multiLayoutItem1945
            // 
            this.multiLayoutItem1945.DataName = "pharmacy_check";
            // 
            // multiLayoutItem1947
            // 
            this.multiLayoutItem1947.DataName = "powder_check";
            // 
            // btnRemarkOnOff
            // 
            this.btnRemarkOnOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemarkOnOff.Image = ((System.Drawing.Image)(resources.GetObject("btnRemarkOnOff.Image")));
            this.btnRemarkOnOff.ImageIndex = 4;
            this.btnRemarkOnOff.ImageList = this.ImageList;
            this.btnRemarkOnOff.Location = new System.Drawing.Point(585, 4);
            this.btnRemarkOnOff.Name = "btnRemarkOnOff";
            this.btnRemarkOnOff.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnRemarkOnOff.Size = new System.Drawing.Size(100, 24);
            this.btnRemarkOnOff.TabIndex = 4;
            this.btnRemarkOnOff.Text = "実施コメント";
            this.btnRemarkOnOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemarkOnOff.Click += new System.EventHandler(this.btnRemarkOnOff_Click);
            // 
            // OCS6010U10
            // 
            this.Controls.Add(this.mtxPlanMgt);
            this.Controls.Add(this.tabQuery);
            this.Controls.Add(this.pnlProcessApplyPlan);
            this.Controls.Add(this.pnlMid_top);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.pnlTop);
            this.Name = "OCS6010U10";
            this.Size = new System.Drawing.Size(1114, 590);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OCS6010U10_Closing);
            this.Load += new System.EventHandler(this.OCS6010U10_Load);
            this.UserChanged += new System.EventHandler(this.OCS6010U10_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS6010U10_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBunho)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlMid_top.ResumeLayout(false);
            this.pnlMid_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dloItemData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloInput_gubun)).EndInit();
            this.mtxPlanMgt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dloProcessInfo)).EndInit();
            this.pnlProcessApplyPlan.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dloProcessInfo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySiksaJunpyo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layQueryLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCplOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJusaOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPfeOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layAplOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySusulOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layEtcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layXrtOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layChuchiOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDrugOrder)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]

		private void OCS6010U10_Load(object sender, System.EventArgs e)
		{
			// 화면 크기를 화면에 맞게 최대화 시킨다 (다른 화면에서 연경우가 아닌경우)
//			if (this.Opener is IHIS.Framework.MdiForm && 
//				(this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed))
//			{
				Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;			
				this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 105);

			if (this.OpenStyle == IHIS.Framework.ScreenOpenStyle.ResponseFixed || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.ResponseSizable)
                this.ParentForm.Location = new Point(25, 80);
//			}		
            
			pnlProcessApplyPlan.Visible = false;
            
			//order_gubun
			CreateOrder_gubun();

			//col title Panel 생성
			CreateColTitlePanel();
			
			//row title Panel생성
            CreateRowTitlePanel();
		}
		
		private void OCS6010U10_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
                    if (OpenParam.Contains("query_date"))
                    {
                        dpkFrom_date.SetDataValue(DateTime.Parse(OpenParam["query_date"].ToString()).AddDays(-1));
                        dpkTo_date.SetDataValue(DateTime.Parse(dpkFrom_date.GetDataValue()).AddDays(6));
                    }
                    else
                    {
                        //기본 일자 setting
                        dpkFrom_date.SetDataValue(EnvironInfo.GetSysDate());
                        dpkTo_date.SetDataValue(EnvironInfo.GetSysDate().AddDays(6));
                    }


                    if (OpenParam.Contains("fkinp1001"))
                    {
                        if (!TypeCheck.IsInt(OpenParam["fkinp1001"].ToString()))
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "入院情報が正しくありません。ご確認ください。" : "입원정보가 정확하지않습니다. 확인바랍니다.";
                            mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            return;
                        }
                        else
                            mFkinp1001 = int.Parse(OpenParam["fkinp1001"].ToString().Trim());
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "入院情報が正しくありません。ご確認ください。" : "입원정보가 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        return;
                    }


					if(OpenParam.Contains("bunho"))
					{
						if(TypeCheck.IsNull(OpenParam["bunho"].ToString().Trim()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が正しくありません。ご確認ください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
							XMessageBox.Show(mbxMsg, mbxCap);					
							return;
						}
						else
						{
							mBunho = OpenParam["bunho"].ToString().Trim();							
							this.pbxBunho.SetPatientID(mBunho);
						}
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が正しくありません。ご確認ください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);							
						return;
					}
				}
				catch (Exception ex)
				{
					XMessageBox.Show(ex.Message, "");						
				}
			}
            else if (this.OpenCommand != null)
            {
                try
                {
                    if (OpenCommand.Items.Contains("bunho"))
                    {

                    }
                }
                catch (Exception xe)
                {
                    XMessageBox.Show(xe.Message);
                }
            }
            else
            {
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                {
                    // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                    patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                }

                if (patientInfo != null)
                {
                    this.pbxBunho.SetPatientID(patientInfo.BunHo);
                }
            }
			
			PostCallHelper.PostCall(new PostMethod(PostLoad));		
		}
	

		private void PostLoad()
		{
			// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
			this.OCS6010U10_UserChanged(this, new System.EventArgs()); 
			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////			

		}

		private void OCS6010U10_UserChanged(object sender, System.EventArgs e)
		{
			if(UserInfo.UserGubun == UserType.Doctor)
			{
				btnShowProcessPlan.Visible  = false;
				pnlProcessApplyPlan.Visible = false;
				lblNurseId.Visible = false;
				txtConfirmUser.Visible = false;
				dbxConfirmUserName.Visible = false;
				btnClearConfirmUser.Visible = false;
                //btnOpenOrder.Visible = true;
			}
			else
			{
				btnShowProcessPlan.Visible  = true;
				lblNurseId.Visible = true;
				txtConfirmUser.Visible = true;
				dbxConfirmUserName.Visible = true;
                btnClearConfirmUser.Visible = true;
                //btnOpenOrder.Visible = false;
			}
		
		}

		#endregion

		#region [Tab 정보]
        
		/// <summary>
		/// Order_gubun을 tab으로 생성합니다.
		/// </summary>
		private void CreateOrder_gubun()
		{
            tabQuery.BackColor = XColor.XPanelBackColor;
			tabQuery.Cursor = Cursors.Hand;
				
			IHIS.X.Magic.Controls.TabPage page = new IHIS.X.Magic.Controls.TabPage("全体");
			page.Tag = "%";
			page.ImageIndex = 4;
			page.BackColor = XColor.XDisplayBoxBackColor.Color;			
			tabQuery.TabPages.Add(page);

			page = new IHIS.X.Magic.Controls.TabPage("全体(指示除外)");
			page.Tag = "1";
			page.ImageIndex = 3;
			page.BackColor = XColor.XDisplayBoxBackColor.Color;			
			tabQuery.TabPages.Add(page);

			page = new IHIS.X.Magic.Controls.TabPage("指示事項");
			page.Tag = "0";
			page.ImageIndex = 3;
			page.BackColor = XColor.XDisplayBoxBackColor.Color;			
			tabQuery.TabPages.Add(page);

            //page = new IHIS.X.Magic.Controls.TabPage("指示事項(緊急時処置)");
            //page.Tag = "N";
            //page.ImageIndex = 3;
            //page.BackColor = XColor.XDisplayBoxBackColor.Color;
            //tabQuery.TabPages.Add(page);

			//Tab page생성
			IHIS.Framework.MultiLayout layoutCombo;
			layoutCombo = new MultiLayout();

			//처방구분 DataLayout;
			layoutCombo.Reset();
			layoutCombo.LayoutItems.Clear();
			layoutCombo.LayoutItems.Add("code", DataType.String);
			layoutCombo.LayoutItems.Add("code_name", DataType.String);
			layoutCombo.InitializeLayoutTable();

            layoutCombo.QuerySQL = @"SELECT CODE, CODE_NAME
                                       FROM OCS0132
                                      WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE
                                        AND CODE_TYPE = 'ORDER_GUBUN_BAS'
                                      ORDER BY SORT_KEY";
            if (!layoutCombo.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

			if(layoutCombo.LayoutTable != null)
			{
				foreach(DataRow row in layoutCombo.LayoutTable.Rows)
				{
					page = new IHIS.X.Magic.Controls.TabPage(row["code_name"].ToString());
					page.Tag = row["code"];
					page.ImageIndex = 3;
					page.BackColor = IHIS.Framework.XColor.XDisplayBoxBackColor.Color;
					tabQuery.TabPages.Add(page);
				}				
			}

			tabQuery.SelectedIndex = 0;

			this.tabQuery.SelectionChanged += new System.EventHandler(this.tabQuery_SelectionChanged);

		}

		private void tabQuery_SelectionChanged(object sender, System.EventArgs e)
		{
			foreach( IHIS.X.Magic.Controls.TabPage page in tabQuery.TabPages)
			{
				if(tabQuery.SelectedTab == page)
					page.ImageIndex = 4;
				else
					page.ImageIndex = 3;
			}

			ShowData(false);

			
		}

		#endregion

		#region [환자정보 Reques/Receive Event]
		/// <summary>
		/// Docking Screen에서 환자정보 변경시 Raise
		/// </summary>
		public override void OnReceiveBunHo(XPatientInfo info)
		{
			if (info != null && !TypeCheck.IsNull(info.BunHo))
			{
                if (info.BunHo != pbxBunho.BunHo)
                {
                    dpkFrom_date.SetDataValue(EnvironInfo.GetSysDate());
                }

                this.pbxBunho.Focus();
				this.pbxBunho.SetPatientID(info.BunHo);
			}
		}

		/// <summary>
		/// 현Screen의 등록번호를 타Screen에 넘긴다
		/// </summary>
		public override XPatientInfo OnRequestBunHo()
		{
			if (!TypeCheck.IsNull(this.pbxBunho.BunHo.ToString()))
			{
				return new XPatientInfo(this.pbxBunho.BunHo.ToString(), "", "", "", this.ScreenName);
			}

			return null;
		}
		#endregion 

		#region [PopUp Menu]
		IHIS.X.Magic.Menus.PopupMenu popMenu = new IHIS.X.Magic.Menus.PopupMenu();
        
		/// <summary>
		/// POPUP 메뉴
		/// 1.예정지시사항 예정일자변경
		/// 2.지시사항 실시
		/// 3.간호확인
		/// </summary>
		/// <param name="sPopMode"></param>
		private void CreatePopUpMenu()
		{
			int currentDataIndex = -1;
			if (mtxPlanMgt.SelectedItems.Count > 0)
				currentDataIndex = int.Parse(mtxPlanMgt.SelectedItems[0].Tag.ToString());
			else
				return;

			//Item Clear
			popMenu.MenuCommands.Clear();

			//PopupMenu 
			IHIS.X.Magic.Menus.MenuCommand menuCmd = null;

            #region 의사지시서
            if (!mIsJaewonYn) 
			{
				// 퇴원환자 의사지시서는 출력할 수 있도록 
				// 의사지시서 출력
				if( UserInfo.UserGubun == UserType.Nurse &&
					( dloItemData.GetItemString(currentDataIndex, "table_id" ) == "OCS2003" ||  dloItemData.GetItemString(currentDataIndex, "table_id" ) == "OCS6013") )
				{
					//의사지시서 출력
					menuCmd = new IHIS.X.Magic.Menus.MenuCommand("医師指示書", this.ImageList.Images[19], new EventHandler(OnPopMenuClick));
					menuCmd.Tag = 11;
					popMenu.MenuCommands.Add(menuCmd);	
				}

                return;
            }
            #endregion

            #region 예정사항 및 예정사항 변경
            //예정사항을 변경가능
			if(dloItemData.GetItemString(currentDataIndex, "can_plan_change_yn") == "Y")
			{
				//예정일자 변경
				menuCmd = new IHIS.X.Magic.Menus.MenuCommand("予定日変更", this.ImageList.Images[6], new EventHandler(OnPopMenuClick));
				menuCmd.Tag = 1;
				popMenu.MenuCommands.Add(menuCmd);				
			}

			//예정사항적용여부
			if(dloItemData.GetItemString(currentDataIndex, "can_plan_app_yn") == "Y")
			{
				if(UserInfo.UserGubun == UserType.Nurse)
				{
					//예정사항적용여부
                    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("CPオーダ施行", this.ImageList.Images[14], new EventHandler(OnPopMenuClick));
                    menuCmd.Tag = 7;
                    popMenu.MenuCommands.Add(menuCmd);
				
					//선택일자전체예정사항적용
                    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("選択日付全体CPオーダ施行", this.ImageList.Images[14], new EventHandler(OnPopMenuClick));
					menuCmd.Tag = 10;
					popMenu.MenuCommands.Add(menuCmd);	
				}
				//주기Order의 삭제는 막는다.
				else if(UserInfo.UserGubun == UserType.Doctor && dloItemData.GetItemString(currentDataIndex, "can_plan_change_yn") == "Y" )
				{
					//예정 Order 삭제
                    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("CPオーダ削除", this.ImageList.Images[15], new EventHandler(OnPopMenuClick));
					menuCmd.Tag = 8;
					popMenu.MenuCommands.Add(menuCmd);	
				}
            }
            #endregion

            #region 간호확인 확인가능
            //간호확인 확인가능
			if(dloItemData.GetItemString(currentDataIndex, "can_confirm_yn") == "Y" && dloItemData.GetItemString(currentDataIndex, "confirm_yn") == "N")
			{
				if(UserInfo.UserGubun == UserType.Nurse && dloItemData.GetItemString(currentDataIndex, "order_end_yn") == "N")
				{
					//간호확인
					menuCmd = new IHIS.X.Magic.Menus.MenuCommand("看護確認", this.ImageList.Images[8], new EventHandler(OnPopMenuClick));
					menuCmd.Tag = 2;
					popMenu.MenuCommands.Add(menuCmd);	
			
					//선택일자전체간호확인
					menuCmd = new IHIS.X.Magic.Menus.MenuCommand("選択日付全体看護確認", this.ImageList.Images[8], new EventHandler(OnPopMenuClick));
					menuCmd.Tag = 3;
					popMenu.MenuCommands.Add(menuCmd);	
				}
            }
            #endregion

            #region 오더삭제
            // 오더삭제
            //if (UserInfo.UserGubun == UserType.Doctor &&
            //    dloItemData.GetItemString(currentDataIndex, "table_id") == "OCS2003" &&
            //    dloItemData.GetItemString(currentDataIndex, "ocs_flag") != "2" &&
            //    dloItemData.GetItemString(currentDataIndex, "ocs_flag") != "3")
            //{
            //    //예정 Order 삭제
            //    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("オーダ削除", this.ImageList.Images[15], new EventHandler(OnPopMenuClick));
            //    menuCmd.Tag = 8;
            //    popMenu.MenuCommands.Add(menuCmd);
            //}
            if (   dloItemData.GetItemString(currentDataIndex, "table_id") == "OCS2003" 
                && dloItemData.GetItemString(currentDataIndex, "order_gubun_ori").Substring(0, 1) == "1"
                && (
                        dloItemData.GetItemString(currentDataIndex, "order_gubun_ori").Substring(1, 1) == "B"
                     || dloItemData.GetItemString(currentDataIndex, "order_gubun_ori").Substring(1, 1) == "C"
                     || dloItemData.GetItemString(currentDataIndex, "order_gubun_ori").Substring(1, 1) == "D"
                     || dloItemData.GetItemString(currentDataIndex, "order_gubun_ori").Substring(1, 1) == "H"
                    )
                )
            {
                string cmd = @"   SELECT 'Y'
                                    FROM OCS2016 A
                                       , OCS2015 B
                                       , OCS2005 C
                                       , NUR0111 D
                                   WHERE A.HOSP_CODE = :f_hosp_code
                                     AND A.FKOCS2003 = :f_fkocs2003
                                     --
                                     AND B.HOSP_CODE = A.HOSP_CODE
                                     AND B.PKOCS2015 = A.FKOCS2015
                                     --
                                     AND C.HOSP_CODE = B.HOSP_CODE
                                     AND C.PKOCS2005 = B.FKOCS2005
                                     --
                                     AND D.HOSP_CODE   = C.HOSP_CODE
                                     AND D.NUR_GR_CODE = C.DIRECT_GUBUN
                                     AND D.NUR_MD_CODE = C.DIRECT_CODE
                                     AND D.JISI_ORDER_GUBUN IN ('1', '2', '3', '4')
                                   ";
                    BindVarCollection bind = new BindVarCollection();
                    bind.Add("f_hosp_code", EnvironInfo.HospCode);
                    bind.Add("f_fkocs2003", dloItemData.GetItemString(currentDataIndex, "pk"));

                    object obj = Service.ExecuteScalar(cmd, bind);

                    if (obj != null && obj.ToString() == "Y")
                    {
                        // 指示事項実施画面を表示
                    }
                    else
                    {
                        //예정 Order 삭제
                        menuCmd = new IHIS.X.Magic.Menus.MenuCommand("指示オーダ取消", this.ImageList.Images[15], new EventHandler(OnPopMenuClick));
                        menuCmd.Tag = 8;
                        popMenu.MenuCommands.Add(menuCmd);
                    }

            }
            #endregion

            #region 간호확인 취소
            //간호확인 확인취소
			if(dloItemData.GetItemString(currentDataIndex, "can_confirm_yn") == "Y" && 
               dloItemData.GetItemString(currentDataIndex, "confirm_yn") == "Y" &&
               TypeCheck.IsNull(dloItemData.GetItemString(currentDataIndex, "nurse_act_user")))
			{
				if(UserInfo.UserGubun == UserType.Nurse)
				{
					//간호확인취소
					menuCmd = new IHIS.X.Magic.Menus.MenuCommand("看護確認取消", this.ImageList.Images[10], new EventHandler(OnPopMenuClick));
					menuCmd.Tag = 4;
					popMenu.MenuCommands.Add(menuCmd);	
			
					//선택일자전체간호확인
					menuCmd = new IHIS.X.Magic.Menus.MenuCommand("選択日付全体看護確認取消", this.ImageList.Images[10], new EventHandler(OnPopMenuClick));
					menuCmd.Tag = 5;
					popMenu.MenuCommands.Add(menuCmd);	
				}
            }
            #endregion

            #region 지시사항 실시
            //지시사항 실시
			if(dloItemData.GetItemString(currentDataIndex, "can_acting_yn") == "Y")// &&
               //dloItemData.GetItemString(currentDataIndex, "order_date").Replace("-", "/") == EnvironInfo.GetSysDate().ToShortDateString().Replace("-", "/"))
			{
				if(UserInfo.UserGubun == UserType.Nurse)
				{
                    if(dloItemData.GetItemString(currentDataIndex, "order_gubun") == "03")
                    {
                        // 식사     2011.04.15 KHJ
                        if(dloItemData.GetItemString(currentDataIndex, "acting_yn") == "Y")
                        {
                            menuCmd = new IHIS.X.Magic.Menus.MenuCommand("食事確認取消", this.ImageList.Images[22], new EventHandler(OnPopMenuClick));
                            menuCmd.Tag = 23;
                            popMenu.MenuCommands.Add(menuCmd);
                        }
                        else
                        {
                            menuCmd = new IHIS.X.Magic.Menus.MenuCommand("食事確認", this.ImageList.Images[22], new EventHandler(OnPopMenuClick));
                            menuCmd.Tag = 22;
                            popMenu.MenuCommands.Add(menuCmd);
                        }
                    }
                    else
                    {
					    //지시사항 실시
					    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("指示事項実施", this.ImageList.Images[7], new EventHandler(OnPopMenuClick));
					    menuCmd.Tag = 6;
					    popMenu.MenuCommands.Add(menuCmd);
                    }
				}

                //インスリン履歴確認
                menuCmd = new IHIS.X.Magic.Menus.MenuCommand("インスリン履歴確認", this.ImageList.Images[5], new EventHandler(OnPopMenuClick));
                menuCmd.Tag = 99;
                popMenu.MenuCommands.Add(menuCmd);

            }
            #endregion

            #region 지시사항 삭제
            //지시사항 삭제
            //if ((dloItemData.GetItemString(currentDataIndex, "can_acting_yn") == "Y" && dloItemData.GetItemString(currentDataIndex, "table_id") == "OCS6015") ||
            //     (dloItemData.GetItemString(currentDataIndex, "can_acting_yn") == "Y" && dloItemData.GetItemString(currentDataIndex, "table_id") == "OCS2005"))
            //{
            //    //예정 Order 삭제
            //    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("指示事項削除", this.ImageList.Images[15], new EventHandler(OnPopMenuClick));
            //    menuCmd.Tag = 8;
            //    popMenu.MenuCommands.Add(menuCmd);
            //}
            #endregion

            #region 투약기록
            //투약기록 投薬記録
			if( dloItemData.GetItemString(currentDataIndex, "table_id" ) == "OCS2003" && 
				( dloItemData.GetItemString(currentDataIndex, "order_gubun") == "A" ||  
				  dloItemData.GetItemString(currentDataIndex, "order_gubun") == "B" || 
				  dloItemData.GetItemString(currentDataIndex, "order_gubun") == "C") )
			{
				if(UserInfo.UserGubun != UserType.Doctor)
				{
					if( ( dloItemData.GetItemString(currentDataIndex, "jundal_part") != "HOM" && dloItemData.GetItemString(currentDataIndex, "acting_yn" ) == "Y" ) ||
						( dloItemData.GetItemString(currentDataIndex, "jundal_part") == "HOM" && dloItemData.GetItemString(currentDataIndex, "confirm_yn") == "Y" ) )
					{
						//투약기록
						menuCmd = new IHIS.X.Magic.Menus.MenuCommand("投薬記録", this.ImageList.Images[16], new EventHandler(OnPopMenuClick));
						menuCmd.Tag = 9;
						popMenu.MenuCommands.Add(menuCmd);	
					}
				}
			    else if(UserInfo.UserGubun == UserType.Doctor)
				{
					if( ( dloItemData.GetItemString(currentDataIndex, "jundal_part") != "HOM" && dloItemData.GetItemString(currentDataIndex, "acting_yn" ) == "Y" ) ||
						( dloItemData.GetItemString(currentDataIndex, "jundal_part") == "HOM" && dloItemData.GetItemString(currentDataIndex, "confirm_yn") == "Y" ) )
					{
						//투약기록
						menuCmd = new IHIS.X.Magic.Menus.MenuCommand("投薬記録照会", this.ImageList.Images[16], new EventHandler(OnPopMenuClick));
						menuCmd.Tag = 12;
						popMenu.MenuCommands.Add(menuCmd);	
					}
				}
            }
            #endregion

            #region 외용약 사용처리
            if (dloItemData.GetItemString(currentDataIndex, "table_id") == "OCS2003" &&
                dloItemData.GetItemString(currentDataIndex, "order_gubun") == "D" &&
                dloItemData.GetItemString(currentDataIndex, "can_confirm_yn") == "Y" && 
                dloItemData.GetItemString(currentDataIndex, "confirm_yn") == "Y" &&
                ((dloItemData.GetItemString(currentDataIndex, "jundal_part") != "HOM" && dloItemData.GetItemString(currentDataIndex, "acting_yn") == "Y") ||
                 (dloItemData.GetItemString(currentDataIndex, "jundal_part") == "HOM" && dloItemData.GetItemString(currentDataIndex, "confirm_yn") == "Y"))
                )
            {
                if (TypeCheck.IsNull(dloItemData.GetItemString(currentDataIndex, "nurse_act_user")))
                {
                    //외용약 사용
                    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("使用済み", this.ImageList.Images[27], new EventHandler(OnPopMenuClick));
                    menuCmd.Tag = 13;
                    popMenu.MenuCommands.Add(menuCmd);
                }
                else
                {
                    //외용약 사용 취소
                    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("使用済み取消", this.ImageList.Images[10], new EventHandler(OnPopMenuClick));
                    menuCmd.Tag = 14;
                    popMenu.MenuCommands.Add(menuCmd);
                }
            }

            #endregion

            #region 의사지시서 출력
            // 의사지시서 출력
			if( UserInfo.UserGubun == UserType.Nurse &&
				( dloItemData.GetItemString(currentDataIndex, "table_id" ) == "OCS2003" ||  dloItemData.GetItemString(currentDataIndex, "table_id" ) == "OCS6013") )
			{
                // 간호오더일 경우에만 의사지시서출력 메뉴 생성 20120209 KHJ
                if (dloItemData.GetItemString(currentDataIndex, "input_gubun") == "NR")
                {
                    //의사지시서 출력
                    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("医師指示書", this.ImageList.Images[19], new EventHandler(OnPopMenuClick));
                    menuCmd.Tag = 11;
                    popMenu.MenuCommands.Add(menuCmd);
                }
            }
            #endregion

            #region 식사전 출력
            // 식사전 출력
            
            
            if (//dloItemData.GetItemString(currentDataIndex, "can_acting_yn") == "Y" && 
                (dloItemData.GetItemString(currentDataIndex, "table_id") == "OCS2005" ||
                dloItemData.GetItemString(currentDataIndex, "table_id") == "OCS6005" ||
                dloItemData.GetItemString(currentDataIndex, "table_id") == "OCS6015" ) &&
                dloItemData.GetItemString(currentDataIndex, "order_gubun") == "03"  )
            {

                //식사전 수정
                menuCmd = new IHIS.X.Magic.Menus.MenuCommand("食事箋修正", this.ImageList.Images[19], new EventHandler(OnPopMenuClick));
                menuCmd.Tag = 20;
                popMenu.MenuCommands.Add(menuCmd);

                //if (dloItemData.GetItemString(currentDataIndex, "hangmog_code").Substring(2, 1) != "2")
                //{
                //    //식사중지
                //    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("食事中止", this.ImageList.Images[26], new EventHandler(OnPopMenuClick));
                //    menuCmd.Tag = 21;
                //    popMenu.MenuCommands.Add(menuCmd);

                //    //전일식사중지
                //    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("終日中止", this.ImageList.Images[26], new EventHandler(OnPopMenuClick));
                //    menuCmd.Tag = 27;
                //    popMenu.MenuCommands.Add(menuCmd);
                //}
                //else
                //{
                //    //식사중지
                //    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("中止取消", this.ImageList.Images[25], new EventHandler(OnPopMenuClick));
                //    menuCmd.Tag = 26;
                //    popMenu.MenuCommands.Add(menuCmd);
                //}

                //if (UserInfo.UserGubun == UserType.Nurse)
                //{
                    ////식사전 출력
                    //menuCmd = new IHIS.X.Magic.Menus.MenuCommand("食事伝票出力", this.ImageList.Images[19], new EventHandler(OnPopMenuClick));
                    //menuCmd.Tag = 20;
                    //popMenu.MenuCommands.Add(menuCmd);


                //}
            }
             
            #endregion

            #region オーダ取消 [ OCS2003U03 ]の呼び出し
            if (UserInfo.UserGubun == UserType.Doctor &&
                !TypeCheck.IsInt(dloItemData.GetItemString(currentDataIndex, "order_gubun")))
            {
                menuCmd = new IHIS.X.Magic.Menus.MenuCommand("オーダ取消", this.ImageList.Images[25], new EventHandler(OnPopMenuClick));
                menuCmd.Tag = 24;
                popMenu.MenuCommands.Add(menuCmd);
            }
            #endregion

            #region 오더정보조회
            // 오더정보조회
            if ( (dloItemData.GetItemString(currentDataIndex, "acting_yn") == "Y" &&
                  dloItemData.GetItemString(currentDataIndex, "can_acting_yn") == "Y") ||
                 (dloItemData.GetItemString(currentDataIndex, "confirm_yn") == "Y" &&
                  dloItemData.GetItemString(currentDataIndex, "can_confirm_yn") == "Y" ) )
            {
                menuCmd = new IHIS.X.Magic.Menus.MenuCommand("オーダ情報照会", this.ImageList.Images[24], new EventHandler(OnPopMenuClick));
                menuCmd.Tag = 25;
                popMenu.MenuCommands.Add(menuCmd);
            }
            #endregion
        }

		private void OnPopMenuClick(object sender, EventArgs e)
		{
            string cmdText = "";

			string menuItemIndex = ((IHIS.X.Magic.Menus.MenuCommand) sender).Tag.ToString();

			// 의사지시서출력과 오더정보조회는 확인 ID 없이도 출력
			if(menuItemIndex != "25" && menuItemIndex != "11" && UserInfo.UserGubun == UserType.Nurse && TypeCheck.IsNull(dbxConfirmUserName.GetDataValue()))
			{                

                frmInputNurseID frm = new frmInputNurseID();

                frm.StartPosition = FormStartPosition.CenterScreen;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.txtNurseID.Text != "")
                    {
                        this.txtConfirmUser.Text = frm.txtNurseID.Text;
                        this.txtConfirmUser.AcceptData();

                        OnPopMenuClick(sender, e);
                        return;
                    }
                }
                else
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "看護確認 IDが正しくありません。 ご確認ください。" : "간호확인 ID가 정확하지않습니다. 확인바랍니다.";
                    mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認ID" : "간호확인ID";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    txtConfirmUser.Focus();
                    txtConfirmUser.SelectAll();
                    return;
                }
			}
			
			int currentDataIndex = -1;
		
			if (mtxPlanMgt.SelectedItems.Count > 0)
				currentDataIndex = int.Parse(mtxPlanMgt.SelectedItems[0].Tag.ToString());
			else
				return;

			string order_date = mtxPlanMgt.SelectedItems[0].ColKey.Substring(0, 8);

			bool jusa_confirm = false;
            CommonItemCollection openParams = new CommonItemCollection();

            BindVarCollection bindVars = new BindVarCollection();
			
			switch (menuItemIndex)
            {
                #region case "1" - 예정일 변경
                case "1":

					frmModifyPlan_date frm = new frmModifyPlan_date();
					frm.ModifyPlan_date = dloItemData.GetItemString(currentDataIndex, "order_date");
					frm.Fkocs6010       = dloItemData.GetItemString(currentDataIndex, "fkocs6010" );
					frm.ShowDialog();

					if(frm.DialogResult == DialogResult.OK)
					{
						if(dloItemData.GetItemString(currentDataIndex, "table_id") == "OCS6013") 
							MoveSelectItem(mtxPlanMgt.SelectedItems[0].ColKey, frm.ModifyPlan_date, dloItemData.GetItemString(currentDataIndex, "input_gubun"));
						else
							dloItemData.SetItemValue(currentDataIndex, "order_date", frm.ModifyPlan_date);
					
						mScrollPoint = mtxPlanMgt.AutoScrollPosition;
						SaveData();
						ShowData(false);
						PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));
					}

					break;
                #endregion

                #region case "2" 간호확인
                case "2":

					try
					{
						Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
					
						string table_id    = dloItemData.GetItemString(currentDataIndex, "table_id"   );
						order_date  = dloItemData.GetItemString(currentDataIndex, "order_date" );
						string input_gubun = dloItemData.GetItemString(currentDataIndex, "input_gubun");
						string order_gubun = dloItemData.GetItemString(currentDataIndex, "order_gubun");
						string group_ser   = dloItemData.GetItemString(currentDataIndex, "group_ser"  );
			
						for(int i = 0; i < dloItemData.RowCount; i++)
						{
							//삭제 Data Skip
							if(dloItemData.GetItemString(i, "notlayout") == "Y") continue;

							if( dloItemData.GetItemString(i, "can_confirm_yn") == "Y" && dloItemData.GetItemString(i, "confirm_yn") == "N" &&
								table_id    == dloItemData.GetItemString(i, "table_id"   ) &&
								order_date  == dloItemData.GetItemString(i, "order_date" ) &&
								input_gubun == dloItemData.GetItemString(i, "input_gubun") &&
								order_gubun == dloItemData.GetItemString(i, "order_gubun") &&
								group_ser   == dloItemData.GetItemString(i, "group_ser"  ) )
							{
								if(CheckOrderConfirmPossible())
								{
									//간호확인			
									dloItemData.SetItemValue(i, "confirm_yn", "Y");
									dloItemData.SetItemValue(i, "pickup_user", txtConfirmUser.Text.Trim());

									if( dloItemData.GetItemString(i, "order_gubun" ) == "B"   &&  
										dloItemData.GetItemString(i, "jundal_table") == "DRG" &&  
										dloItemData.GetItemString(i, "jundal_table") != "HOM" )
										jusa_confirm = true;
								}
							}
						}

						mScrollPoint = mtxPlanMgt.AutoScrollPosition;
						SaveData();
						ShowData(false);
						PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));	
		
					}
					finally
					{					
						Cursor.Current = System.Windows.Forms.Cursors.Default;
					}
					
					break;
                #endregion
                    
                #region case "3" 일 전체 간호 확인
                case "3":

					try
					{
						Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;	
				
						for(int i = 0; i < mtxPlanMgt.Items.Count; i++)
						{
							//같은 일자가 아니면 Skip
							if( order_date != mtxPlanMgt.Items[i].ColKey.Substring(0, 8) ||
								TypeCheck.IsNull(mtxPlanMgt.Items[i].Tag) ) continue;

							currentDataIndex = int.Parse(mtxPlanMgt.Items[i].Tag.ToString());
                        
							//간호확인이 가능한 처방
							if(dloItemData.GetItemString(currentDataIndex, "can_confirm_yn") == "Y" && dloItemData.GetItemString(currentDataIndex, "confirm_yn") == "N")
							{
								//간호확인						
								if(CheckOrderConfirmPossible())
								{								
									mtxPlanMgt.Items[i].ImageIndex = 4;
									mtxPlanMgt.Items[i].TextColor  = XColor.NormalForeColor.Color;
									dloItemData.SetItemValue(currentDataIndex, "confirm_yn", "Y");
									dloItemData.SetItemValue(currentDataIndex, "pickup_user", txtConfirmUser.Text.Trim());

									if( dloItemData.GetItemString(currentDataIndex, "order_gubun" ) == "B"   &&
										dloItemData.GetItemString(currentDataIndex, "jundal_table") == "DRG" &&  
										dloItemData.GetItemString(currentDataIndex, "jundal_table") != "HOM" )
										jusa_confirm = true;
								}
							}
						}

						mScrollPoint = mtxPlanMgt.AutoScrollPosition;
						SaveData();
						ShowData(false);
						PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));	
				
					}
					finally
					{					
						Cursor.Current = System.Windows.Forms.Cursors.Default;
					}
					break;
                #endregion

                #region case "4"
                case "4":

					mtxPlanMgt.SelectedItems[0].ImageIndex = 3;
					mtxPlanMgt.SelectedItems[0].TextColor  = Color.Blue;
					dloItemData.SetItemValue(currentDataIndex, "confirm_yn", "N");

					mScrollPoint = mtxPlanMgt.AutoScrollPosition;
					SaveData();
					ShowData(false);
					PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));

					break;
                #endregion

                #region case "5"
                case "5":

					try
					{
						Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;	
				
						for(int i = 0; i < mtxPlanMgt.Items.Count; i++)
						{
							//같은 일자가 아니면 Skip
							if( order_date != mtxPlanMgt.Items[i].ColKey.Substring(0, 8) ||
								TypeCheck.IsNull(mtxPlanMgt.Items[i].Tag) ) continue;

							currentDataIndex = int.Parse(mtxPlanMgt.Items[i].Tag.ToString());
                        
							//간호확인이 가능한 처방
							if(dloItemData.GetItemString(currentDataIndex, "can_confirm_yn") == "Y" && dloItemData.GetItemString(currentDataIndex, "confirm_yn") == "Y")
							{
								//간호확인						
								if(CheckOrderConfirmPossible())
								{								
									mtxPlanMgt.Items[i].ImageIndex = 3;
									mtxPlanMgt.Items[i].TextColor  = Color.Blue;
									dloItemData.SetItemValue(currentDataIndex, "confirm_yn", "N");
								}
							}
						}

						mScrollPoint = mtxPlanMgt.AutoScrollPosition;
						SaveData();
						ShowData(false);
						PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));	
				
					}
					finally
					{					
						Cursor.Current = System.Windows.Forms.Cursors.Default;
					}
					
					break;
                #endregion

                #region case "99" Insulin
                case "99":
                    frmInsulinLog frmLog = new frmInsulinLog();

                    frmLog.FKINP1001 = dloItemData.GetItemString(currentDataIndex, "fkinp1001");
                    frmLog.BUNHO     = dloItemData.GetItemString(currentDataIndex, "bunho");
                    frmLog.SUNAME    = this.mPatientInfo.GetPatientInfo["suname"].ToString();

                    frmLog.StartPosition = FormStartPosition.CenterScreen;
                    frmLog.ShowDialog();
                    break;
                #endregion

                #region case "6" 指示事項実行
                case "6":

                    
                    // 指示事項実施
                    #region OCS2005 및 OCS2006 테이블에 데이터 생성 프로시져
                    // CP에서 입력된 내용을 OCS2005 및 OCS2006 테이블에 데이터 생성 프로시져 //
                    string aTableId   = dloItemData.GetItemString(currentDataIndex, "table_id");
                    string aPkocs6015 = dloItemData.GetItemString(currentDataIndex, "pkocs6015");
                    string aOrderDate = dloItemData.GetItemString(currentDataIndex, "order_date");
                    string retPkOCS2005 = dloItemData.GetItemString(currentDataIndex, "pkocs2005");

                    string drt_from_datetime = dloItemData.GetItemString(currentDataIndex, "drt_from_datetime");
                    string drt_to_datetime = dloItemData.GetItemString(currentDataIndex, "drt_to_datetime");
                    string present_datetime = EnvironInfo.GetSysDateTime().ToString("yyyyMMddHHmm");

                    // 現在時刻基準で有効な指示事項なのかチェック
                    if (long.Parse(drt_from_datetime) > long.Parse(present_datetime))
                    {
                        if (XMessageBox.Show("現時点でまだ開始されてない指示事項です。続けますか？", "確認", MessageBoxButtons.YesNo) == DialogResult.No)
                            return;
                    }
                    else if (long.Parse(drt_to_datetime) < long.Parse(present_datetime))
                    {
                        if (XMessageBox.Show("現時点で既に終了された指示事項です。続けますか？", "確認", MessageBoxButtons.YesNo) == DialogResult.No)
                            return;
                    }

                    cmdText = @"SELECT DECODE(COUNT(*), 0, 'Y', 'N')
                                  FROM OCS2005
                                 WHERE HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE
                                   AND ORDER_DATE = '" + aOrderDate + @"'
                                   AND FKOCS6015  = '" + aPkocs6015 + @"'";
                    string aCount = Service.ExecuteScalar(cmdText).ToString();
                    
                    if (retPkOCS2005 == "0" && aTableId == "OCS6015" && aCount == "Y")
                    {
                        string spName = "PR_OCS_PLAN_DIRECT_CONVERT";
                        ArrayList inputList = new ArrayList();
                        ArrayList ouputList = new ArrayList();
                        inputList.Add(dloItemData.GetItemString(currentDataIndex, "pkocs6015"));
                        inputList.Add(dloItemData.GetItemString(currentDataIndex, "order_date")); // HOLI_DAY =>> 화면에서현재 실행하는 날짜
                        inputList.Add(UserInfo.UserID);

                        try
                        {
                            Service.BeginTransaction();
                            if (!Service.ExecuteProcedure(spName, inputList, ouputList)) throw new Exception(Service.ErrFullMsg);
                        }
                        catch (Exception xe)
                        {
                            Service.RollbackTransaction();
                            XMessageBox.Show("実施処理にエラーが発生しました。 \n\r" + xe.Message + "\n\r" + xe.StackTrace, "実施エラー",
                                MessageBoxIcon.Error);
                            return;
                        }

                        retPkOCS2005 = ouputList[0].ToString(); // 새로 생성한 OCS2005 의 pkocs2005 값

                        Service.CommitTransaction();
                    }
                    // CP에서 입력된 내용을 OCS2005 및 OCS2006 테이블에 데이터 생성 프로시져 //
                    #endregion

                    //인슐린 : jisi_order_gubun = "1" or "2"
                    if(dloItemData.GetItemString(currentDataIndex, "jisi_order_gubun") == "1" ||
                       dloItemData.GetItemString(currentDataIndex, "jisi_order_gubun") == "2" )     // 인슐린
					{
                        frmInsulinActing frmAct = new frmInsulinActing(
                        dloItemData.GetItemString(currentDataIndex, "bunho"),
                        dloItemData.GetItemString(currentDataIndex, "fkinp1001"),
                        dloItemData.GetItemString(currentDataIndex, "order_date"),    // HOLI_DAY
                        dloItemData.GetItemString(currentDataIndex, "input_gubun"),
                        dloItemData.GetItemString(currentDataIndex, "pk"),
                        dloItemData.GetItemString(currentDataIndex, "order_gubun"),
                        dloItemData.GetItemString(currentDataIndex, "hangmog_code"),
                        txtConfirmUser.GetDataValue().Trim(),
                        dloItemData.GetItemString(currentDataIndex, "input_gwa"),
                        dloItemData.GetItemString(currentDataIndex, "input_doctor"),

                        retPkOCS2005,
                        dloItemData.GetItemString(currentDataIndex, "pkocs6015"),

                        dloItemData.GetItemString(currentDataIndex, "source_order_date") // ORDER_DATE
                        );

                        frmAct.StartPosition = FormStartPosition.CenterScreen;
                        frmAct.ShowDialog();

                        if (frmAct.DialogResult == DialogResult.OK)
                        {
                            if (frmAct.ACTING_YN == "Y")
                            {
                                mtxPlanMgt.SelectedItems[0].ImageIndex = 2;
                                mtxPlanMgt.SelectedItems[0].TextColor = XColor.NormalForeColor.Color;
                                dloItemData.SetItemValue(currentDataIndex, "acting_yn", "Y");
                            }
                            else
                            {
                                mtxPlanMgt.SelectedItems[0].ImageIndex = 1;
                                mtxPlanMgt.SelectedItems[0].TextColor = Color.Blue;
                                dloItemData.SetItemValue(currentDataIndex, "acting_yn", "N");
                            }

                            mScrollPoint = mtxPlanMgt.AutoScrollPosition;
                            SaveData();
                            ShowData(false);
                            PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));
                        }
					}
                    // 산소요법 : jisi_order_gubun = "3"
                    else if(dloItemData.GetItemString(currentDataIndex, "jisi_order_gubun") == "3")     // 산소요법
					{
						frmO2Acting frmAct = new frmO2Acting();
						frmAct.BUNHO        = dloItemData.GetItemString(currentDataIndex, "bunho");
						frmAct.FKINP1001    = dloItemData.GetItemString(currentDataIndex, "fkinp1001");
						frmAct.ORDER_DATE   = dloItemData.GetItemString(currentDataIndex, "order_date");    // HOLI_DAY
						frmAct.INPUT_GUBUN  = dloItemData.GetItemString(currentDataIndex, "input_gubun");
						frmAct.OCS2005_SEQ  = dloItemData.GetItemString(currentDataIndex, "pk");
						frmAct.DIRECT_GUBUN = dloItemData.GetItemString(currentDataIndex, "order_gubun");
						frmAct.DIRECT_CODE  = dloItemData.GetItemString(currentDataIndex, "hangmog_code");
                        frmAct.USER_ID      = txtConfirmUser.GetDataValue().Trim();

                        frmAct.PKOCS2005 = retPkOCS2005;
                        frmAct.PKOCS6015 = dloItemData.GetItemString(currentDataIndex, "pkocs6015");

                        frmAct.INPUT_GWA    = dloItemData.GetItemString(currentDataIndex, "input_gwa");
                        frmAct.INPUT_DOCTOR = dloItemData.GetItemString(currentDataIndex, "input_doctor");


                        frmAct.SOURCE_ORDER_DATE = dloItemData.GetItemString(currentDataIndex, "source_order_date"); // ORDER_DATE

                        frmAct.StartPosition = FormStartPosition.CenterScreen;
						frmAct.ShowDialog();

						if(frmAct.DialogResult == DialogResult.OK)
						{
							if(frmAct.ACTING_YN == "Y")
							{							
								mtxPlanMgt.SelectedItems[0].ImageIndex = 2;
								mtxPlanMgt.SelectedItems[0].TextColor  = XColor.NormalForeColor.Color;
								dloItemData.SetItemValue(currentDataIndex, "acting_yn", "Y");
							}
							else
							{
								mtxPlanMgt.SelectedItems[0].ImageIndex = 1;
								mtxPlanMgt.SelectedItems[0].TextColor  = Color.Blue;
								dloItemData.SetItemValue(currentDataIndex, "acting_yn", "N");
							}

							mScrollPoint = mtxPlanMgt.AutoScrollPosition;
							SaveData();
							ShowData(false);
							PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));
						}
					}
                    // 인공호흡  : jisi_order_gubun = "4"
                    else if(dloItemData.GetItemString(currentDataIndex, "jisi_order_gubun") == "4" )        // 인공호흡
					{
                        frmARActing frmAct = new frmARActing();
                        frmAct.BUNHO        = dloItemData.GetItemString(currentDataIndex, "bunho");
                        frmAct.FKINP1001    = dloItemData.GetItemString(currentDataIndex, "fkinp1001");
                        frmAct.ORDER_DATE   = dloItemData.GetItemString(currentDataIndex, "order_date");    // HOLI_DAY
                        frmAct.INPUT_GUBUN  = dloItemData.GetItemString(currentDataIndex, "input_gubun");
                        frmAct.OCS2005_SEQ  = dloItemData.GetItemString(currentDataIndex, "pk");
                        frmAct.DIRECT_GUBUN = dloItemData.GetItemString(currentDataIndex, "order_gubun");
                        frmAct.DIRECT_CODE  = dloItemData.GetItemString(currentDataIndex, "hangmog_code");
                        frmAct.DIRECT_CONT  = dloItemData.GetItemString(currentDataIndex, "direct_cont");
                        frmAct.USER_ID      = txtConfirmUser.GetDataValue().Trim();

                        frmAct.PKOCS2005 = retPkOCS2005;
                        frmAct.PKOCS6015 = dloItemData.GetItemString(currentDataIndex, "pkocs6015");

                        frmAct.INPUT_GWA    = dloItemData.GetItemString(currentDataIndex, "input_gwa");
                        frmAct.INPUT_DOCTOR = dloItemData.GetItemString(currentDataIndex, "input_doctor");


                        frmAct.SOURCE_ORDER_DATE = dloItemData.GetItemString(currentDataIndex, "source_order_date"); // ORDER_DATE

                        frmAct.StartPosition = FormStartPosition.CenterScreen;
                        frmAct.ShowDialog();

                        if (frmAct.DialogResult == DialogResult.OK)
                        {
                            if (frmAct.ACTING_YN == "Y")
                            {
                                mtxPlanMgt.SelectedItems[0].ImageIndex = 2;
                                mtxPlanMgt.SelectedItems[0].TextColor = XColor.NormalForeColor.Color;
                                dloItemData.SetItemValue(currentDataIndex, "acting_yn", "Y");
                            }
                            else
                            {
                                mtxPlanMgt.SelectedItems[0].ImageIndex = 1;
                                mtxPlanMgt.SelectedItems[0].TextColor = Color.Blue;
                                dloItemData.SetItemValue(currentDataIndex, "acting_yn", "N");
                            }

                            mScrollPoint = mtxPlanMgt.AutoScrollPosition;
                            SaveData();
                            ShowData(false);
                            PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));
                        }
					}
                    // 약  : jisi_order_gubun = "5"
                    else if(dloItemData.GetItemString(currentDataIndex, "jisi_order_gubun") == "5")     // 약
                    {
                        frmDrugActing frmAct = new frmDrugActing();
                        frmAct.BUNHO        = dloItemData.GetItemString(currentDataIndex, "bunho");
                        frmAct.FKINP1001    = dloItemData.GetItemString(currentDataIndex, "fkinp1001");
                        frmAct.ORDER_DATE   = dloItemData.GetItemString(currentDataIndex, "order_date");    // HOLI_DAY
                        frmAct.INPUT_GUBUN  = dloItemData.GetItemString(currentDataIndex, "input_gubun");
                        frmAct.OCS2005_SEQ  = dloItemData.GetItemString(currentDataIndex, "pk");
                        frmAct.DIRECT_GUBUN = dloItemData.GetItemString(currentDataIndex, "order_gubun");
                        frmAct.DIRECT_CODE  = dloItemData.GetItemString(currentDataIndex, "hangmog_code");
                        frmAct.DIRECT_CONT  = dloItemData.GetItemString(currentDataIndex, "direct_cont");  // direct_detail
                        frmAct.USER_ID      = txtConfirmUser.GetDataValue().Trim();

                        frmAct.PKOCS2005 = retPkOCS2005;
                        frmAct.PKOCS6015 = dloItemData.GetItemString(currentDataIndex, "pkocs6015");

                        frmAct.INPUT_GWA    = dloItemData.GetItemString(currentDataIndex, "input_gwa");
                        frmAct.INPUT_DOCTOR = dloItemData.GetItemString(currentDataIndex, "input_doctor");


                        frmAct.SOURCE_ORDER_DATE = dloItemData.GetItemString(currentDataIndex, "source_order_date"); // ORDER_DATE

                        frmAct.StartPosition = FormStartPosition.CenterScreen;
                        frmAct.ShowDialog();

                        if (frmAct.DialogResult == DialogResult.OK)
                        {
                            if (frmAct.ACTING_YN == "Y")
                            {
                                mtxPlanMgt.SelectedItems[0].ImageIndex = 2;
                                mtxPlanMgt.SelectedItems[0].TextColor = XColor.NormalForeColor.Color;
                                dloItemData.SetItemValue(currentDataIndex, "acting_yn", "Y");
                            }
                            else
                            {
                                mtxPlanMgt.SelectedItems[0].ImageIndex = 1;
                                mtxPlanMgt.SelectedItems[0].TextColor = Color.Blue;
                                dloItemData.SetItemValue(currentDataIndex, "acting_yn", "N");
                            }

                            mScrollPoint = mtxPlanMgt.AutoScrollPosition;
                            SaveData();
                            ShowData(false);
                            PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));
                        }
                    }
                    // 처치 : jisi_order_gubun = "6"
                    else if (dloItemData.GetItemString(currentDataIndex, "jisi_order_gubun") == "6")    // 처치
                    {
                        frmTreatmentActing frmAct = new frmTreatmentActing();
                        frmAct.BUNHO        = dloItemData.GetItemString(currentDataIndex, "bunho");
                        frmAct.FKINP1001    = dloItemData.GetItemString(currentDataIndex, "fkinp1001");
                        frmAct.ORDER_DATE   = dloItemData.GetItemString(currentDataIndex, "order_date");    // HOLI_DAY
                        frmAct.INPUT_GUBUN  = dloItemData.GetItemString(currentDataIndex, "input_gubun");
                        frmAct.OCS2005_SEQ  = dloItemData.GetItemString(currentDataIndex, "pk");
                        frmAct.DIRECT_GUBUN = dloItemData.GetItemString(currentDataIndex, "order_gubun");
                        frmAct.DIRECT_CODE  = dloItemData.GetItemString(currentDataIndex, "hangmog_code");
                        frmAct.DIRECT_CONT  = dloItemData.GetItemString(currentDataIndex, "direct_cont");
                        frmAct.USER_ID      = txtConfirmUser.GetDataValue().Trim();

                        frmAct.PKOCS2005 = retPkOCS2005;
                        frmAct.PKOCS6015 = dloItemData.GetItemString(currentDataIndex, "pkocs6015");


                        frmAct.SOURCE_ORDER_DATE = dloItemData.GetItemString(currentDataIndex, "source_order_date"); // ORDER_DATE

                        frmAct.StartPosition = FormStartPosition.CenterScreen;
                        frmAct.ShowDialog();

                        if (frmAct.DialogResult == DialogResult.OK)
                        {
                            if (frmAct.ACTING_YN == "Y")
                            {
                                mtxPlanMgt.SelectedItems[0].ImageIndex = 2;
                                mtxPlanMgt.SelectedItems[0].TextColor = XColor.NormalForeColor.Color;
                                dloItemData.SetItemValue(currentDataIndex, "acting_yn", "Y");
                            }
                            else
                            {
                                mtxPlanMgt.SelectedItems[0].ImageIndex = 1;
                                mtxPlanMgt.SelectedItems[0].TextColor = Color.Blue;
                                dloItemData.SetItemValue(currentDataIndex, "acting_yn", "N");
                            }

                            mScrollPoint = mtxPlanMgt.AutoScrollPosition;
                            SaveData();
                            ShowData(false);
                            PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));
                        }
                    }
                    else if (dloItemData.GetItemString(currentDataIndex, "jisi_order_gubun") == "7")     // VitalSign
                    {
                        CommonItemCollection openParams1 = new CommonItemCollection();
                        openParams1.Add("sysid", "NURI");
                        openParams1.Add("screen", this.ScreenID.ToString());
                        //openParams.Add( "ho_dong", this.paBox.ToString());
                        openParams1.Add("bunho", this.pbxBunho.BunHo.ToString());
                        openParams1.Add("date", dloItemData.GetItemString(currentDataIndex, "order_date")); // ORDER_DATE

                        XScreen.OpenScreenWithParam(this, "NURI", "NUR1020U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, openParams1);

                    }
                    else if (dloItemData.GetItemString(currentDataIndex, "jisi_order_gubun") == "9")     // Moniter
                    {
                        frmMoniterActing frmAct = new frmMoniterActing();
                        frmAct.BUNHO = dloItemData.GetItemString(currentDataIndex, "bunho");
                        frmAct.FKINP1001 = dloItemData.GetItemString(currentDataIndex, "fkinp1001");
                        frmAct.ORDER_DATE = dloItemData.GetItemString(currentDataIndex, "order_date");    // HOLI_DAY
                        frmAct.INPUT_GUBUN = dloItemData.GetItemString(currentDataIndex, "input_gubun");
                        frmAct.OCS2005_SEQ = dloItemData.GetItemString(currentDataIndex, "pk");
                        frmAct.DIRECT_GUBUN = dloItemData.GetItemString(currentDataIndex, "order_gubun");
                        frmAct.DIRECT_CODE = dloItemData.GetItemString(currentDataIndex, "hangmog_code");
                        frmAct.USER_ID = txtConfirmUser.GetDataValue().Trim();

                        frmAct.PKOCS2005 = retPkOCS2005;
                        frmAct.PKOCS6015 = dloItemData.GetItemString(currentDataIndex, "pkocs6015");

                        frmAct.INPUT_GWA = dloItemData.GetItemString(currentDataIndex, "input_gwa");
                        frmAct.INPUT_DOCTOR = dloItemData.GetItemString(currentDataIndex, "input_doctor");


                        frmAct.SOURCE_ORDER_DATE = dloItemData.GetItemString(currentDataIndex, "source_order_date"); // ORDER_DATE

                        frmAct.StartPosition = FormStartPosition.CenterScreen;
                        frmAct.ShowDialog();

                        if (frmAct.DialogResult == DialogResult.OK)
                        {
                            if (frmAct.ACTING_YN == "Y")
                            {
                                mtxPlanMgt.SelectedItems[0].ImageIndex = 2;
                                mtxPlanMgt.SelectedItems[0].TextColor = XColor.NormalForeColor.Color;
                                dloItemData.SetItemValue(currentDataIndex, "acting_yn", "Y");
                            }
                            else
                            {
                                mtxPlanMgt.SelectedItems[0].ImageIndex = 1;
                                mtxPlanMgt.SelectedItems[0].TextColor = Color.Blue;
                                dloItemData.SetItemValue(currentDataIndex, "acting_yn", "N");
                            }

                            mScrollPoint = mtxPlanMgt.AutoScrollPosition;
                            SaveData();
                            ShowData(false);
                            PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));
                        }
                    }
                    // 일반지시
                    else    // 일반지시
                    {
                        frmDirectActing frmAct = new frmDirectActing();
                        frmAct.BUNHO = dloItemData.GetItemString(currentDataIndex, "bunho");
                        frmAct.FKINP1001 = dloItemData.GetItemString(currentDataIndex, "fkinp1001");
                        frmAct.ORDER_DATE = dloItemData.GetItemString(currentDataIndex, "order_date");    // HOLI_DAY
                        frmAct.INPUT_GUBUN = dloItemData.GetItemString(currentDataIndex, "input_gubun");
                        frmAct.OCS2005_SEQ = dloItemData.GetItemString(currentDataIndex, "pk");
                        frmAct.DIRECT_GUBUN = dloItemData.GetItemString(currentDataIndex, "order_gubun");
                        frmAct.DIRECT_CODE = dloItemData.GetItemString(currentDataIndex, "hangmog_code");
                        frmAct.CAN_ACTING_YN = dloItemData.GetItemString(currentDataIndex, "can_acting_yn");
                        frmAct.USER_ID = txtConfirmUser.GetDataValue().Trim();

                        frmAct.SOURCE_ORDER_DATE = dloItemData.GetItemString(currentDataIndex, "source_order_date"); // ORDER_DATE

                        frmAct.StartPosition = FormStartPosition.CenterScreen;
                        frmAct.ShowDialog();

                        if (frmAct.DialogResult == DialogResult.OK)
                        {
                            if (frmAct.ACTING_YN == "Y")
                            {
                                mtxPlanMgt.SelectedItems[0].ImageIndex = 2;
                                mtxPlanMgt.SelectedItems[0].TextColor = XColor.NormalForeColor.Color;
                                dloItemData.SetItemValue(currentDataIndex, "acting_yn", "Y");
                            }
                            else
                            {
                                mtxPlanMgt.SelectedItems[0].ImageIndex = 1;
                                mtxPlanMgt.SelectedItems[0].TextColor = Color.Blue;
                                dloItemData.SetItemValue(currentDataIndex, "acting_yn", "N");
                            }

                            mScrollPoint = mtxPlanMgt.AutoScrollPosition;
                            SaveData();
                            ShowData(false);
                            PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));
                        }
                    }
					break;
                #endregion

                #region case "7,10"
                case "7":
                case "10":
					if(this.htSelectItem.Count < 1) return;

					try
					{
						Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
					
						string table_id    = dloItemData.GetItemString(currentDataIndex, "table_id"   );
						order_date  = dloItemData.GetItemString(currentDataIndex, "order_date" );    // HOLI_DAY
						string input_gubun = dloItemData.GetItemString(currentDataIndex, "input_gubun");
						string order_gubun = dloItemData.GetItemString(currentDataIndex, "order_gubun");
						string group_ser   = dloItemData.GetItemString(currentDataIndex, "group_ser"  );
			
						for(int i = 0; i < dloItemData.RowCount; i++)
						{
							//삭제 Data Skip
							if(dloItemData.GetItemString(i, "notlayout") == "Y") continue;
                
							if( dloItemData.GetItemString(i, "can_plan_app_yn") == "Y"  &&
								table_id    == dloItemData.GetItemString(i, "table_id"   ) &&
								order_date  == dloItemData.GetItemString(i, "order_date" ) &&
								input_gubun == dloItemData.GetItemString(i, "input_gubun") &&
								order_gubun == dloItemData.GetItemString(i, "order_gubun") &&
								group_ser   == dloItemData.GetItemString(i, "group_ser"  ) )
							{
								
								if( dloItemData.GetItemString(i, "order_gubun" ) == "B"   &&  
									dloItemData.GetItemString(i, "jundal_table") == "DRG" &&  
									dloItemData.GetItemString(i, "jundal_table") != "HOM" )
								{
									jusa_confirm = true;
									break;
								}
							}
						}

                        //ProcessApplyPlanOrderGroup(menuItemIndex);	
		
					}
					finally
					{					
						Cursor.Current = System.Windows.Forms.Cursors.Default;
					}
					break;
                #endregion

                #region case "8"
                case "8":

                    if( dloItemData.GetItemString(currentDataIndex, "table_id") == "OCS6013" || dloItemData.GetItemString(currentDataIndex, "table_id") == "OCS2003" )
				    {
					    mbxMsg = NetInfo.Language == LangMode.Jr ? "選択したオーダを削除しますか？" : "선택한 처방을 삭제하시겠습니까?";
					    mbxCap = NetInfo.Language == LangMode.Jr ? "オーダ削除可否" : "처방삭제여부";
				    }
				    else
				    {
					    mbxMsg = NetInfo.Language == LangMode.Jr ? "選択した指示事項を削除しますか？" : "선택한 지시사항을 삭제하시겠습니까?";
					    mbxCap = NetInfo.Language == LangMode.Jr ? "指示事項削除" : "지시사항삭제여부";
				    }
					
				    DialogResult dialogResult = XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				    if (dialogResult == DialogResult.No) 
					    break;

				    //예정처방, 처방삭제, 지시사항삭제						
				    dloItemData.SetItemValue(currentDataIndex, "del_flag", "Y");

				    mScrollPoint = mtxPlanMgt.AutoScrollPosition;
				    SaveData();
				    ShowData(false);
				    PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));
                    

					break;
                #endregion

                #region case "9" - 투약기록
                case "9":
					
					openParams  = new CommonItemCollection();			
					openParams.Add( "order_date"  , dloItemData.GetItemString(currentDataIndex, "source_order_date" )); // order_date
					openParams.Add( "bunho"       , dloItemData.GetItemString(currentDataIndex, "bunho"      ));
                    //openParams.Add( "pkocs2003"   , dloItemData.GetItemString(currentDataIndex, "pk"         ));
                    //openParams.Add( "order_gubun" , dloItemData.GetItemString(currentDataIndex, "order_gubun"));
					openParams.Add( "user_id"     , txtConfirmUser.GetDataValue()                             );
                    openParams.Add( "acting_date" , dloItemData.GetItemString(currentDataIndex, "order_date" ));    // HOLI_DAY
					
					//투약기록
					XScreen.OpenScreenWithParam( this, "NURI", "NUR2017U01", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopCenter, openParams);
                    
					mScrollPoint = mtxPlanMgt.AutoScrollPosition;
					ShowData(false);
					PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));	
					break;
                #endregion

                #region case 10
                //case "10":

                //    try
                //    {
                //        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                //        for (int i = 0; i < mtxPlanMgt.Items.Count; i++)
                //        {
                //            //같은 일자가 아니면 Skip
                //            if (order_date != mtxPlanMgt.Items[i].ColKey.Substring(0, 8) ||
                //                TypeCheck.IsNull(mtxPlanMgt.Items[i].Tag)) continue;

                //            currentDataIndex = int.Parse(mtxPlanMgt.Items[i].Tag.ToString());

                //            //치료계획 실시가 가능한 처방
                //            if (dloItemData.GetItemString(currentDataIndex, "can_plan_app_yn") == "Y")
                //            {
                //                if (dloItemData.GetItemString(currentDataIndex, "order_gubun") == "B" &&
                //                    dloItemData.GetItemString(currentDataIndex, "jundal_table") == "DRG" &&
                //                    dloItemData.GetItemString(currentDataIndex, "jundal_table") != "HOM")
                //                    jusa_confirm = true;
                //            }
                //        }

                //        bool allCheck = rbtAll.Checked;

                //        rbtAll.Checked = true;
                //        dpkApp_From_date.SetDataValue(dloItemData.GetItemString(currentDataIndex, "order_date")); // HOLI_DAY
                //        dpkApp_To_date.SetDataValue(dloItemData.GetItemString(currentDataIndex, "order_date"));
                //        ProcessApplyPlanOrder();

                //        rbtAll.Checked = allCheck;


                //    }
                //    finally
                //    {
                //        Cursor.Current = System.Windows.Forms.Cursors.Default;
                //    }

                //    break;
                #endregion

                #region case "11"
                case "11":

					LoadOrderPrint(currentDataIndex);

				    break;
                #endregion

                #region case "12" - 투약기록조회
                case "12":

                    openParams = new CommonItemCollection();
                    openParams.Add("order_date", dloItemData.GetItemString(currentDataIndex, "order_date"));    // HOLI_DAY
                    openParams.Add("bunho", dloItemData.GetItemString(currentDataIndex, "bunho"));
                    openParams.Add("pkocs2003", dloItemData.GetItemString(currentDataIndex, "pk"));
                    openParams.Add("order_gubun", dloItemData.GetItemString(currentDataIndex, "order_gubun"));
                    openParams.Add("user_id", txtConfirmUser.GetDataValue());

                    //투약기록조회
                    XScreen.OpenScreenWithParam(this, "NURI", "NUR2017Q00", ScreenOpenStyle.ResponseFixed, openParams);

                    break;
                #endregion

                #region case "13" 외용약 실시

                case "13":                           
                        //사용 등록	
                    dloItemData.SetItemValue(currentDataIndex, "nurse_act_user", txtConfirmUser.Text.Trim());
                    dloItemData.SetItemValue(currentDataIndex, "nurse_act_date", dloItemData.GetItemString(currentDataIndex, "order_date"));
                    mScrollPoint = mtxPlanMgt.AutoScrollPosition;
                    SaveData();
                    ShowData(false);
                    PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));
                break;

                #endregion

                #region case "14" 외용약 실시 취소 
                case "14":
                    //사용 등록	취소
                    dloItemData.SetItemValue(currentDataIndex, "nurse_act_user", "");
                    mScrollPoint = mtxPlanMgt.AutoScrollPosition;
                    SaveData();
                    ShowData(false);
                    PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));
                break;
                    
                #endregion 

                #region case "20" - 식사전출력
                case "20":
                    // 식사전

                    //DialogResult result = XMessageBox.Show("食事伝票の出力を行いますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //if (result == DialogResult.No) break;

                    //openParams = new CommonItemCollection();
                    //openParams.Add( "bunho"      , dloItemData.GetItemString(currentDataIndex, "bunho"       ));
                    //openParams.Add( "pkinp1001"  , dloItemData.GetItemString(currentDataIndex, "fkinp1001"   ));
                    //openParams.Add( "date"       , dloItemData.GetItemString(currentDataIndex, "order_date"  ));// HOLI_DAY
                    //openParams.Add( "direct_code", dloItemData.GetItemString(currentDataIndex, "hangmog_code"));
                    //openParams.Add( "print_mode" , true                                                       );

                    //XScreen.OpenScreenWithParam(this, "OCSI", "OCS2005R02", ScreenOpenStyle.ResponseFixed, openParams);

                    openParams = new CommonItemCollection();
                    openParams.Add("bunho", dloItemData.GetItemString(currentDataIndex, "bunho"));
                    openParams.Add("hodong", mPatientInfo.GetPatientInfo["ho_dong"].ToString());
                    openParams.Add("hocode", mPatientInfo.GetPatientInfo["ho_code"].ToString());

                    XScreen.OpenScreenWithParam(this, "OCSI", "OCS2005U02", ScreenOpenStyle.ResponseFixed, openParams);

                  
                    break;
                #endregion

                #region case "21" - 식사중지
                case "21":
                    // 이미 확인된 식사에 대해서는 중지시킬 수 없다
                    if (dloItemData.GetItemString(currentDataIndex, "acting_yn") == "Y")
                    {
                        XMessageBox.Show("確認された食事は中止できません。", "注意", MessageBoxIcon.Warning);
                        return;
                    }

                    string directCode = "202";
                    ArrayList inputArray = new ArrayList();
                    ArrayList outputArray = new ArrayList();
                    inputArray.Add(dloItemData.GetItemString(currentDataIndex, "pkocs2005"));
                    inputArray.Add(dloItemData.GetItemString(currentDataIndex, "order_date"));
                    inputArray.Add(UserInfo.UserID);
                    inputArray.Add(directCode + dloItemData.GetItemString(currentDataIndex, "hangmog_code").Substring(3, 1));

                    // 식사중지 프로시져 실행
                    StopSiksa(inputArray, outputArray);

                    //재조회
                    btnList_ButtonClick(this, new ButtonClickEventArgs(FunctionType.Query, false, false));

                    break;
                #endregion

                #region case "22" - 식사확인
                case "22":
                    //  2011.04.16.(토) KHJ
                    //  식사확인
                    string seqText = @"SELECT NVL(MAX(SEQ), 0) + 1 SEQ
                                         FROM OCS2015
                                        WHERE HOSP_CODE   = FN_ADM_LOAD_HOSP_CODE
                                          AND BUNHO       = :f_bunho
                                          AND FKINP1001   = :f_fkinp1001
                                          AND ORDER_DATE  = :f_order_date
                                          AND INPUT_GUBUN = :f_input_gubun
                                          AND PK_SEQ      = :f_pk_seq
                                          AND ACT_DATE    = TRUNC(SYSDATE)";

                    bindVars.Clear();
                    bindVars.Add("f_user_id",       txtConfirmUser.GetDataValue());
                    bindVars.Add("f_bunho",         dloItemData.GetItemString(currentDataIndex, "bunho"            ));
                    bindVars.Add("f_fkinp1001",     dloItemData.GetItemString(currentDataIndex, "fkinp1001"        ));
                    bindVars.Add("f_order_date",    dloItemData.GetItemString(currentDataIndex, "source_order_date"));
                    bindVars.Add("f_input_gubun",   dloItemData.GetItemString(currentDataIndex, "input_gubun"      ));
                    bindVars.Add("f_input_id",      dloItemData.GetItemString(currentDataIndex, "input_id"         ));
                    bindVars.Add("f_pk_seq",        dloItemData.GetItemString(currentDataIndex, "pk"               ));
                    bindVars.Add("f_act_date",      dloItemData.GetItemString(currentDataIndex, "order_date"       ));
                    bindVars.Add("f_siksa_code",    dloItemData.GetItemString(currentDataIndex, "hangmog_code"     ));

                    string seqVal = Service.ExecuteScalar(seqText, bindVars).ToString();
                    bindVars.Add("f_seq", seqVal);

                    cmdText = @"INSERT INTO OCS2015
          ( SYS_DATE     ,   SYS_ID      ,   UPD_DATE    ,   UPD_ID      ,
            HOSP_CODE    ,   PKOCS2015   ,
            BUNHO        ,   FKINP1001   ,   ORDER_DATE  ,   INPUT_GUBUN ,
            INPUT_ID     ,   PK_SEQ      ,   SEQ         ,   DRT_DATE    ,
            ACT_DATE     ,   ACT_ID      ,   SIKSA_CODE                      )
VALUES    ( SYSDATE      ,   :f_user_id  ,   SYSDATE     ,   :f_user_id  ,
            FN_ADM_LOAD_HOSP_CODE(),  OCS2015_SEQ.NEXTVAL,
            :f_bunho     ,   :f_fkinp1001,   :f_order_date,  :f_input_gubun,
            :f_input_id  ,   :f_pk_seq   ,   :f_seq      ,   :f_order_date ,
            :f_act_date  ,   :f_user_id  ,   :f_siksa_code                   )";

                    try
                    {
                        Service.BeginTransaction();
                        if (!Service.ExecuteNonQuery(cmdText, bindVars))
                        {
                            throw new Exception(Service.ErrFullMsg);
                        }
                    
                    }
                    catch (Exception xe)
                    {
                        Service.RollbackTransaction();
                        XMessageBox.Show(xe.Message);
                    }
                    Service.CommitTransaction();

                    ShowData(false);

                    break;
                #endregion

                #region case "23" - 식사확인취소
                case "23":

                    mbxMsg = NetInfo.Language == LangMode.Jr ? "食事確認を取り消します。よろしいですか？" : "선택하신 식사를 취소하시겠습니까?";
                    mbxCap = NetInfo.Language == LangMode.Jr ? "食事確認取消" : "식사확인취소";

                    DialogResult result = XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        cmdText = @"DELETE FROM OCS2015
                                     WHERE HOSP_CODE   = FN_ADM_LOAD_HOSP_CODE
                                       AND BUNHO       = :f_bunho
                                       AND FKINP1001   = :f_fkinp1001
                                       AND ORDER_DATE  = :f_order_date
                                       AND INPUT_GUBUN = :f_input_gubun
                                       AND PK_SEQ      = :f_pk_seq
                                       AND ACT_DATE    = :f_act_date
                                       AND SIKSA_CODE  = :f_siksa_code";

                        bindVars.Clear();
                        bindVars.Add("f_user_id",       txtConfirmUser.GetDataValue());
                        bindVars.Add("f_bunho",         dloItemData.GetItemString(currentDataIndex, "bunho"            ));
                        bindVars.Add("f_fkinp1001",     dloItemData.GetItemString(currentDataIndex, "fkinp1001"        ));
                        bindVars.Add("f_order_date",    dloItemData.GetItemString(currentDataIndex, "source_order_date"));
                        bindVars.Add("f_input_gubun",   dloItemData.GetItemString(currentDataIndex, "input_gubun"      ));
                        bindVars.Add("f_pk_seq",        dloItemData.GetItemString(currentDataIndex, "pk"               ));
                        bindVars.Add("f_act_date",      dloItemData.GetItemString(currentDataIndex, "order_date"       ));
                        bindVars.Add("f_siksa_code",    dloItemData.GetItemString(currentDataIndex, "hangmog_code"     ));

                        try
                        {
                            Service.BeginTransaction();
                            if (!Service.ExecuteNonQuery(cmdText, bindVars))
                            {
                                throw new Exception(Service.ErrFullMsg);
                            }
                        }
                        catch (Exception xe)
                        {
                            Service.RollbackTransaction();
                            XMessageBox.Show(xe.Message);
                        }
                        Service.CommitTransaction();

                        ShowData(false);
                    }
                    break;
                #endregion

                #region case "24" - オーダ取消
                case "24":
                    openParams = new CommonItemCollection();
                    openParams.Add("query_date",  dloItemData.GetItemString(currentDataIndex, "source_order_date"));
                    openParams.Add("bunho",       dloItemData.GetItemString(currentDataIndex, "bunho"));
                    openParams.Add("fkinp1001",   dloItemData.GetItemString(currentDataIndex, "fkinp1001"));
                    openParams.Add("input_gubun", dloItemData.GetItemString(currentDataIndex, "input_gubun"));
                    openParams.Add("doctor",      dloItemData.GetItemString(currentDataIndex, "input_doctor"));

                    XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003U03", ScreenOpenStyle.ResponseFixed, openParams);

                    this.ShowData(false);
                    break;
                #endregion

                #region case "25" - 오더정보상세조회
                case "25":
                    mtxPlanMgt_ItemClick(mtxPlanMgt, new XMatrixItemClickEventArgs(mtxPlanMgt.SelectedItems[0], MouseButtons.Right));
                    break;
                #endregion

                #region case "26" - 식사중지취소
                case "26":
                    string t_flag = "";
                    inputArray  = new ArrayList();
                    outputArray = new ArrayList();
                    inputArray.Add(dloItemData.GetItemString(currentDataIndex, "pkocs2005"));
                    inputArray.Add(UserInfo.UserID);
                    inputArray.Add(dloItemData.GetItemString(currentDataIndex, "hangmog_code"));
                    inputArray.Add(dloItemData.GetItemString(currentDataIndex, "bunho"));
                    inputArray.Add(dloItemData.GetItemString(currentDataIndex, "fkinp1001"));
                    inputArray.Add(dloItemData.GetItemString(currentDataIndex, "source_order_date"));
                    inputArray.Add(dloItemData.GetItemString(currentDataIndex, "input_gubun"));

                    try
                    {
                        Service.BeginTransaction();
                        if (Service.ExecuteProcedure("PR_OCS_STOP_SIKSA_CANCEL", inputArray, outputArray))
                        {
                            t_flag = outputArray[0].ToString();

                            if (!t_flag.Equals(""))
                            {
                                throw new Exception(outputArray[0].ToString());
                            }
                        }
                        else
                            throw new Exception(Service.ErrFullMsg);

                    }
                    catch (Exception xe)
                    {
                        Service.RollbackTransaction();

                        XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace, "PR_OCS_STOP_SIKSA ERROR");
                        return;
                    }
                    Service.CommitTransaction();

                    btnList_ButtonClick(this, new ButtonClickEventArgs(FunctionType.Query, false, false));
                    break;
                #endregion

                #region case "27" - 전일식사중지
                case "27":
                    directCode = "202";
                    inputArray = new ArrayList();
                    outputArray = new ArrayList();
                    DataTable dtTable = new DataTable();
                    bindVars.Clear();

                    cmdText = @"SELECT A.PKOCS2005,
                                       A.DIRECT_CODE,
                                       A.PK_SEQ,
                                       B.ACT_DATE
                                  FROM OCS2005 A,
                                       OCS2015 B
                                 WHERE A.HOSP_CODE      = FN_ADM_LOAD_HOSP_CODE
                                   AND A.BUNHO          = :f_bunho
                                   AND A.FKINP1001      = :f_fkinp1001
                                   AND A.INPUT_GUBUN    = :f_input_gubun
                                   AND TRUNC(TO_DATE(:f_act_date)) BETWEEN A.DRT_FROM_DATE AND NVL(A.DRT_TO_DATE, '9999/12/31')
                                   AND SUBSTR(A.DIRECT_CODE, 3, 1) != '2'
                                   
                                   AND B.HOSP_CODE(+)   = A.HOSP_CODE
                                   AND B.BUNHO(+)       = A.BUNHO
                                   AND B.FKINP1001(+)   = A.FKINP1001
                                   AND B.ORDER_DATE(+)  = A.ORDER_DATE
                                   AND B.INPUT_GUBUN(+) = A.INPUT_GUBUN
                                   AND B.PK_SEQ(+)      = A.PK_SEQ
                                   AND B.ACT_DATE(+)    = :f_act_date";
                    bindVars.Add("f_bunho",       dloItemData.GetItemString(currentDataIndex, "bunho"));
                    bindVars.Add("f_fkinp1001",   dloItemData.GetItemString(currentDataIndex, "fkinp1001"));
                    bindVars.Add("f_input_gubun", dloItemData.GetItemString(currentDataIndex, "input_gubun"));
                    bindVars.Add("f_act_date",    dloItemData.GetItemString(currentDataIndex, "order_date"));
                    bindVars.Add("f_order_date",  dloItemData.GetItemString(currentDataIndex, "source_order_date"));

                    try
                    {
                        dtTable = Service.ExecuteDataTable(cmdText, bindVars);
                                                
                        Service.BeginTransaction();

                        if (dtTable.Rows.Count > 0)
                        {

                            foreach(DataRow dr in dtTable.Rows)
                            {
                                // 식사확인 건 체크 후, 확인된 건이 있으면 건너뛰기
                                if (dr["act_date"].ToString() != "") continue;

                                inputArray.Clear();
                                inputArray.Add(dr["pkocs2005"].ToString());
                                inputArray.Add(dloItemData.GetItemString(currentDataIndex, "order_date"));
                                inputArray.Add(UserInfo.UserID);
                                inputArray.Add(directCode + dr["direct_code"].ToString().Substring(3, 1));

                                // 식사중지 프로시져 실행
                                if (!StopSiksa(inputArray, outputArray))
                                    throw new Exception();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Service.RollbackTransaction();
                        return;
                    }
                    Service.CommitTransaction();
                    //재조회
                    btnList_ButtonClick(this, new ButtonClickEventArgs(FunctionType.Query, false, false));

                    break;
                #endregion
            }

            #region// 간호확인시 주사마감
            if (jusa_confirm)
			{
                // 약국종료가 되지 않은 경우에는 병동주사처방전출력 화면은 띄우지 않음. 20120118 KHJ
                cmdText = @"SELECT DECODE(COUNT('Y'), 0, 'N', 'Y') CHK  FROM DRG9043
                             WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE
                               AND TO_CHAR(SYSDATE,'YYYYMMDDHH24MISS') BETWEEN TO_CHAR(START_DATE,'YYYYMMDD') || START_TIME
                                                                           AND TO_CHAR(NVL(END_DATE,SYSDATE),'YYYYMMDD') || NVL(END_TIME,'9999')
                               AND CANCEL_DATE IS NULL";

                if (Service.ExecuteScalar(cmdText).ToString().Equals("N"))  // 약국종료 Y
                {
                    return;
                }


                //openParams  = new CommonItemCollection();							
                //openParams.Add("bunho"  , mPatientInfo.GetPatientInfo["bunho"  ].ToString());
                //openParams.Add("doctor",  mPatientInfo.GetPatientInfo["doctor"].ToString());
                //openParams.Add("ho_dong", mPatientInfo.GetPatientInfo["ho_dong"].ToString());
                //openParams.Add("order_date", order_date);
					
                //XScreen.OpenScreenWithParam(this, "DRGS", "DRG3010P88", ScreenOpenStyle.ResponseSizable, openParams);

				mScrollPoint = mtxPlanMgt.AutoScrollPosition;
				ShowData(false);
				PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));
            }
            #endregion
        }

		private void OpenPopupMenu()
		{
			if(this.mtxPlanMgt.SelectedItems.Count < 1) return;
            
			//메뉴생성
			CreatePopUpMenu();

			popMenu.TrackPopup(mtxPlanMgt.PointToScreen(new Point(m_iMenuX, m_iMenuY)));
        }

        private bool StopSiksa(ArrayList inputArray, ArrayList outputArray)
        {
            string t_flag = "";
            try
            {
                Service.BeginTransaction();
                if (Service.ExecuteProcedure("PR_OCS_STOP_SIKSA", inputArray, outputArray))
                {
                    t_flag = outputArray[0].ToString();

                    if (!t_flag.Equals(""))
                    {
                        throw new Exception(outputArray[0].ToString());
                    }
                }
                else
                    throw new Exception(Service.ErrFullMsg);

            }
            catch (Exception xe)
            {
                Service.RollbackTransaction();

                XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace, "PR_OCS_STOP_SIKSA ERROR");
                return false;
            }
            Service.CommitTransaction();
            return true;
        }

		#endregion

		#region [Matrix]

		#region [Layout Variable]
        
		//col width
		private const int DATACOLWIDTH = 350 - 128;
		private IHIS.Framework.XPanel   pnlRowTitle;
		private IHIS.Framework.XPanel   pnlColTitle;

		#endregion
        
		#region [지시사항 및 처방정보를 Matrix로 보여준다.]
        
		/// <summary>
		/// 지시사항 및 처방정보를 Matrix로 보여준다.
		/// </summary>
		private void ShowData(bool aRelayout)
		{
			if(TypeCheck.IsNull(mBunho)) return;

			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                
				#region [LayoutMatrix]

				//Matrix Reset
				ClearMatrix();
                
				if(!aRelayout)
				{
                    if (!LoadDetailData(mBunho, mFkinp1001.ToString(), dpkFrom_date.GetDataValue(), dpkTo_date.GetDataValue(), tabQuery.SelectedTab.Tag.ToString()))
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                    }

					for(int i = 0; i < this.dloItemData.RowCount; i++)
					{
						this.dloItemData.SetItemValue(i, "origin_order_date",  dloItemData.GetItemString(i, "order_date"));
						this.dloItemData.SetItemValue(i, "origin_input_gubun", dloItemData.GetItemString(i, "input_gubun"));
					}
					this.dloItemData.ResetUpdate();
				}
                
				//data가 없으면 return
				if(dloItemData.RowCount < 1)
				{
					Cursor.Current = System.Windows.Forms.Cursors.Default;
					return;
				}
			
				//row 정보생성
				LayoutRow();

				//Col 정보생성
				LayoutCol();
				
				//Data Setting
				LayoutData();

				//RowState Reset
				if(!aRelayout) dloItemData.ResetUpdate();
            
				//Show Matrix Layout
				mtxPlanMgt.SuspendLayout();
				pnlColTitle.Visible = true;
				pnlColTitle.BringToFront();
				pnlRowTitle.Visible = true;
				pnlRowTitle.BringToFront();
                mtxPlanMgt.Setup();
				SetColTitle();
				SetRowTitleHeight();
				
				mtxPlanMgt.ResumeLayout();

				#endregion
			}
			finally
			{
				
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}

		#endregion		
        
		/// <summary>
		/// Row 정보를 생성한다.
		/// 1.기본 ColHeader Row 
		/// 2.항목 코드별 Row
		/// 3.Row Title 
		///   (Matrix에서 구현이 안되서 Panel에 Label로 처리)
		/// </summary>
		private void LayoutRow()
		{	
			//Title Row
			mtxPlanMgt.RowItems.Add("日付",0);
			AddTitle("日付", 0, 0);
			mtxPlanMgt.RowItems.Add("経過",0);
			AddTitle("経過", 1, 1);
            
			//row Title
			string order_gubun   = "";
			int    startRowIndex = mtxPlanMgt.RowItems.Count;
			int    endRowIndex   = mtxPlanMgt.RowItems.Count;
            
			//row item
			string hangmog_code = "";
			string table_id     = "";
			int    rowIndex     = mtxPlanMgt.RowItems.Count;

			for(int i = 0; i < this.dloItemData.RowCount; i++)
			{
				//삭제 Data Skip
				if(dloItemData.GetItemString(i, "notlayout") == "Y") continue;

				//order_gubun check
				if(order_gubun != dloItemData.GetItemString(i, "order_gubun") && order_gubun != "")
				{
					AddTitle(dloItemData.GetItemString(i - 1, "order_gubun_name"), startRowIndex, endRowIndex);					
					startRowIndex = mtxPlanMgt.RowItems.Count;
				}
                
				//hangmog_code check
				if( order_gubun  != dloItemData.GetItemString(i, "order_gubun" ) || 
					table_id     != dloItemData.GetItemString(i, "table_id"   ).Substring(6,1) || 
					hangmog_code != dloItemData.GetItemString(i, "hangmog_code"))
				{	
					//처방은 항목별로 나누지 않는다. order_gubun별로 나눈다.
                    if( dloItemData.GetItemString(i, "table_id") == "OCS2003" || dloItemData.GetItemString(i, "table_id") == "OCS6013"
                     || (dloItemData.GetItemString(i, "table_id") == "OCS2005" && dloItemData.GetItemString(i, "order_gubun") != "03"))
                    {
                        if (order_gubun != dloItemData.GetItemString(i, "order_gubun"))
                        //if (order_gubun != dloItemData.GetItemString(i, "hangmog_code"))
                        {
                            //mtxPlanMgt.RowItems.Add(dloItemData.GetItemString(i, "hangmog_code"), 1, 50);
                            mtxPlanMgt.RowItems.Add(dloItemData.GetItemString(i, "hangmog_code"), 1);
                            rowIndex     = mtxPlanMgt.RowItems.Count - 1;				
                            endRowIndex  = rowIndex;
                        }
                    }
                    else if (dloItemData.GetItemString(i, "table_id") == "OCS2005" && dloItemData.GetItemString(i, "order_gubun") == "03")
                    {
                        if (order_gubun != dloItemData.GetItemString(i, "order_gubun"))
                        {
                            mtxPlanMgt.RowItems.Add(dloItemData.GetItemString(i, "hangmog_code"), 1);
                            rowIndex = mtxPlanMgt.RowItems.Count - 1;
                            endRowIndex = rowIndex;
                        }
                    }
                    else
                    {
                        //mtxPlanMgt.RowItems.Add(dloItemData.GetItemString(i, "hangmog_code"), 1, 50);
                        mtxPlanMgt.RowItems.Add(dloItemData.GetItemString(i, "hangmog_code"), 1);
                        rowIndex = mtxPlanMgt.RowItems.Count - 1;
                        endRowIndex = rowIndex;
                    }
                    
					order_gubun  = dloItemData.GetItemString(i, "order_gubun" );
					table_id     = dloItemData.GetItemString(i, "table_id"   ).Substring(6,1);
					hangmog_code = dloItemData.GetItemString(i, "hangmog_code");
				}
                
				//해당 Data가 row를 찾을 수 있도록 여기서 row값을 넣어준다.
				if(TypeCheck.IsNull(dloItemData.GetItemString(i, "rowindex"))) dloItemData.SetItemValue(i, "rowindex", rowIndex);			
			}

			if( dloItemData.RowCount > 0 )
				AddTitle(dloItemData.GetItemString(dloItemData.RowCount -1, "order_gubun_name"), startRowIndex, endRowIndex);

		}

		/// <summary>
		/// Col 정보를 생성한다.
		/// 1.기본 조회기간(7일) Col
		/// 2.해당 일자의 Input_gubun Col
		///   - 간호인 경우에는 일단 정규로 처리
		///   - Col Index는 일자(YYYYMMDD) + Input_gubun 값
		///   ** 실제 해당일자의 Data가 없더라도 정규로 Input_gubun을 생성한다.
		/// </summary>
		private void LayoutCol()
		{
			//ColItem
			XColMatrixItem colItem ;

			//일자 Setting
			DateTime startDate = DateTime.Parse(dpkFrom_date.GetDataValue());
			DateTime showDate = startDate;

            //일주일단위의 일자를 Setting한다.
			for(int i = 0; i < 7; i++)
			{
				showDate = startDate.AddDays(i);
				
				
				colItem = mtxPlanMgt.ColItems.Add(showDate.ToString("yyyyMMdd"), showDate.ToString("yyyy/MM/dd") + LoadDayName(showDate.DayOfWeek.ToString()), DATACOLWIDTH);	
				colItem.Tag = showDate.ToString("yyyyMMdd");
                
				//퇴원예고일표시
				if(showDate.ToString("yyyyMMdd") == this.mPatientInfo.GetPatientInfo["toiwon_res_date"].ToString().Replace("/", ""))
				{
					colItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
					colItem.ImageIndex = 20;
				}
				//현재일 표시
				else if(showDate.ToString("yyyy/MM/dd") == EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"))
				{
					colItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
					colItem.ImageIndex = 0;
				}
			}

			string order_date  = "";
			string input_gubun = "";
			int    insertRow;
            DateTime dtCheck = new DateTime();

			foreach(DataRow row in dloItemData.LayoutTable.Select("", "order_date ASC, input_seq ASC"))
			{
				if(row["notlayout"].ToString() == "Y") continue;

                //if (int.Parse(row["order_date"].ToString().Replace("/", "")) > int.Parse(dpkTo_date.GetDataValue().Replace("/", ""))) continue;


				// MLayout에서 GetItemDateTime error...
				if(order_date != row["order_date"].ToString().Replace("/", "") || input_gubun != row["input_gubun"].ToString())
				{
					order_date  = row["order_date"].ToString().Replace("/", "");
					input_gubun = row["input_gubun"].ToString();

                    colItem = mtxPlanMgt.ColItems[order_date].Childs.Add(order_date + input_gubun, row["input_gubun_name"].ToString(), DATACOLWIDTH);
                    colItem.Tag = order_date + input_gubun;

					//input_gubun 정보
					insertRow = dloInput_gubun.InsertRow(-1);
					dloInput_gubun.SetItemValue(insertRow, "order_date" , order_date );
					dloInput_gubun.SetItemValue(insertRow, "input_gubun", input_gubun);
				}
			}

			//해당 일자에 input_gubun이 없는 경우에는 input_gubun을 만든다.
			foreach(XColMatrixItem col in mtxPlanMgt.ColItems)
			{
				if(col.Childs.Count == 0)
				{
					//차후 Header title은 함수에서 가져온다.
					colItem = col.Childs.Add(col.Tag.ToString() + "D0", "通常", DATACOLWIDTH);
					colItem.Tag = col.Tag.ToString() + "D0";

					//input_gubun 정보
					insertRow = dloInput_gubun.InsertRow(-1);
					dloInput_gubun.SetItemValue(insertRow, "order_date" , col.Tag.ToString() );
					dloInput_gubun.SetItemValue(insertRow, "input_gubun", "D0");
				}

				//col Width조정
				col.Width = DATACOLWIDTH * col.Childs.Count;
			}
		}

		/// <summary>
		/// Data를 Setting한다.
		/// </summary>
		private void LayoutData()
		{
            string MIX_START = "┏";
            string MIX_MID   = "┃";
            string MIX_END   = "┗";
			string SET_MIX   = "  ";

			int    row;
			string colKey      = "";
			string displayText = "";

			//group header를 생성한다.
			
			int    chk_row       = -1;
			string chk_colKey    = "";
			string chk_table_id  = "";
			string chk_group_ser = "";
			string chk_mix_group = "";

            string chk_input_doctor = "";


			int      ORD_INFO_LENGTH = 50 - 10 + 6;
			string   tempValue       = "";
			string[] tempArray ;

			int    j = -1;  // GROUP HEADER
            int    l = -1;  // 주사, 복용법

			for(int i = 0; i < dloItemData.RowCount; i++)
			{
				j++;
                l++;

				//삭제 Data Skip
				if(dloItemData.GetItemString(i, "notlayout") == "Y") continue;

				row    = dloItemData.GetItemInt(i,"rowindex");
                colKey = dloItemData.GetItemString(i, "order_date").Replace("/", "") + dloItemData.GetItemString(i, "input_gubun");

				displayText = "      ";
                
				//group Ser, mix 표시
				if( dloItemData.GetItemString(i,"table_id") == "OCS2003" || dloItemData.GetItemString(i,"table_id") == "OCS6013" )
				{  
					//group header를 만든다.
                    if (chk_row != row || chk_colKey != colKey || chk_table_id != dloItemData.GetItemString(i, "table_id") || chk_group_ser != dloItemData.GetItemString(i, "group_ser") || chk_input_doctor != dloItemData.GetItemString(i, "input_doctor"))
                    {
                        if (dloItemData.GetItemString(i, "group_ser").Length < 3)
                            displayText = "【  " + dloItemData.GetItemString(i, "group_ser") + "  】 ";
                        else
                            displayText = "【  " + dloItemData.GetItemString(i, "group_ser").Substring(1)  + "  】 ";
                        
                        // 20111019 KHJ
                        // 약/주사오더에 있어 NDAY오더 변경에 의한 치료계획 화면로직 변경
                        if (dloItemData.GetItemString(i, "diff") != "1" &&                            
                            (dloItemData.GetItemString(i, "order_gubun") == "B" ||
                             dloItemData.GetItemString(i, "order_gubun") == "C" ||
                             dloItemData.GetItemString(i, "order_gubun") == "D")
                           )
                        {
                            if (dloItemData.GetItemString(i, "input_gubun") == "D7")
                            {
                                displayText = displayText + "【退院薬】            " + dloItemData.GetItemString(i, "order_date");
                            }
                            else if (dloItemData.GetItemString(i, "diff") == dloItemData.GetItemString(i, "nalsu"))
                            {
                                displayText = displayText + "【終了】              " + dloItemData.GetItemString(i, "order_date");
                            }

                            else
                            {
                                displayText = displayText + "【継続】              " + dloItemData.GetItemString(i, "order_date");
                                //displayText = displayText + "【継続】     " + dloItemData.GetItemString(i, "input_gubun_name") + "    " + dloItemData.GetItemString(i, "order_date");
                            }
                        }
                        else if (dloItemData.GetItemString(i, "diff") == "1")
                        {
                            displayText = displayText + "            　　　　  " + dloItemData.GetItemString(i, "order_date");
                            //displayText = displayText + "　　　　     " + dloItemData.GetItemString(i, "input_gubun_name") + "    " + dloItemData.GetItemString(i, "order_date");
                        }

                        mtxPlanMgt.Items.Add(row, colKey, displayText);
                        // 20120120 KHJ 글꼴,색상변경
                        //mtxPlanMgt.Items[j].TextFont = new Font("MS UI Gothic", 9.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                        mtxPlanMgt.Items[j].TextFont = new Font("MS UI Gothic", 9.25F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                        mtxPlanMgt.Items[j].TextColor = Color.Black;
                        j++;

                        // 2011226 KHJ
                        // 주사법 및 복용법은 각 그룹 별로 그룹시리얼 밑에 한 번만 표시
                        displayText = "";
                        displayText = dloItemData.GetItemString(i, "jusa_name").Trim() == "" ? "" : "    【 " + dloItemData.GetItemString(i, "jusa_name") + " 】";
                        
                        if (dloItemData.GetItemString(i, "order_gubun") == "C")// 약
                        {
                            if (dloItemData.GetItemString(i, "input_gubun") == "D7")
                            {
                                displayText = dloItemData.GetItemString(i, "bogyong_name").Trim() == "" ? displayText : displayText + "    【 " + dloItemData.GetItemString(i, "bogyong_name") + " 】              " + dloItemData.GetItemString(i, "nalsu") + " 日分";
                            }
                            else
                            {
                                displayText = dloItemData.GetItemString(i, "bogyong_name").Trim() == "" ? displayText : displayText + "    【 " + dloItemData.GetItemString(i, "bogyong_name") + " 】          " + dloItemData.GetItemString(i, "diff") + " / " + dloItemData.GetItemString(i, "nalsu") + " 日分";
                            }
                        }
                        else if (dloItemData.GetItemString(i, "order_gubun") == "D") //외용약
                        {
                            displayText = dloItemData.GetItemString(i, "bogyong_name").Trim() == "" ? displayText : displayText + "    【 " + dloItemData.GetItemString(i, "bogyong_name") + " 】　　" + dloItemData.GetItemString(i, "detail") + "　　　　   " + dloItemData.GetItemString(i, "diff") + " / " + dloItemData.GetItemString(i, "dv") + "回"; 
                        }
                        else // 그외
                        {
                            displayText = dloItemData.GetItemString(i, "bogyong_name").Trim() == "" ? displayText : displayText + "    【 " + dloItemData.GetItemString(i, "bogyong_name") + " 】  ";
                        }
                        if (displayText.Trim() != "") displayText = displayText + "\n\r";

                        // 20120120 KHJ 그룹별 입력ID 오더확인 ID 일괄표시
                        displayText = dloItemData.GetItemString(i, "input_name").Trim() == "" ? displayText + "" : displayText + "      ▷ " + dloItemData.GetItemString(i, "input_name");

                        mtxPlanMgt.Items.Add(row, colKey, displayText);

                        // 20120120 KHJ 글꼴,색상변경
                        mtxPlanMgt.Items[j].TextFont = new Font("MS UI Gothic", 7.75F, FontStyle.Regular, GraphicsUnit.Point, ((System.Byte)(0)));

                        mtxPlanMgt.Items[j].TextColor = Color.DimGray;

                        j++;
                        l++;

                        chk_row = row;
                        chk_colKey = colKey;
                        chk_table_id = dloItemData.GetItemString(i, "table_id");
                        chk_group_ser = dloItemData.GetItemString(i, "group_ser");

                        chk_input_doctor = dloItemData.GetItemString(i, "input_doctor");

                        displayText = "      ";
                        chk_mix_group = "";
					}

					SET_MIX = "";

					if( !TypeCheck.IsNull(dloItemData.GetItemString(i,"mix_group").Trim()) )
					{
						if( chk_mix_group != dloItemData.GetItemString(i,"mix_group") )
                            displayText = displayText + MIX_START;
						else
							displayText = displayText + MIX_MID;
                        
						chk_mix_group = dloItemData.GetItemString(i,"mix_group").Trim();
						SET_MIX       = "  " + MIX_MID;
					}
                    
					// 오더불용
					if( dloItemData.GetItemString(i,"bulyong_check").Trim() == "Y" )
						displayText = displayText + "ⓧ オーダ不用 \n    " + SET_MIX;

					//Order중지여부
					if( dloItemData.GetItemString(i,"order_end_yn").Trim() == "Y" )
						displayText = displayText + "ⓧ オーダ中止 \n    " + SET_MIX;

					//진행중인 예정명칭 표시
					if( dloItemData.GetItemString(i,"table_id") == "OCS6013" && !TypeCheck.IsNull(dloItemData.GetItemString(i,"cp_name")))
					{
						displayText = displayText + "『" +   dloItemData.GetItemString(i,"cp_name") + "』\n    " + SET_MIX;
                    }

				}
                
				// 주기Order여부 표시
                tempValue = "";
				
				if( dloItemData.GetItemString(i,"emergency") == "Y" )
				{
					tempValue = tempValue + "[緊急]";
				    if ( !TypeCheck.IsNull(dloItemData.GetItemString(i,"confirm_name")) ) 
						tempValue = tempValue + " " + dloItemData.GetItemString(i,"confirm_name") + "\n   " + SET_MIX;
				}

				if( dloItemData.GetItemString(i,"table_id") == "OCS6013" && dloItemData.GetItemString(i,"can_plan_change_yn") == "N")
					tempValue = tempValue + "[CP: " + dloItemData.GetItemString(i, "jaewonil") + "日目] \n\r　"  + dloItemData.GetItemString(i, "hangmog_name");
				else
                    tempValue = tempValue + dloItemData.GetItemString(i, "hangmog_name");

				//오더명은 display길이로 잘라서 처리
				tempArray = this.mOrderFunc.GetArraySubstrByte(tempValue, ORD_INFO_LENGTH );
				for(int k = 0; k < tempArray.Length; k++)
				{						
					if( k != 0 )
                        displayText = displayText + "    " + SET_MIX;
                    displayText = dloItemData.GetItemString(i, "mix_group").Trim() == "" ? displayText + tempArray[k] + "\n\r　" : displayText + tempArray[k] + "\n\r";
                    //displayText = displayText + tempArray[k] + "\n\r";

				}

                // detailを切って処理
                string detail = "";
                tempArray = this.mOrderFunc.GetArraySubstrByte(dloItemData.GetItemString(i, "detail"), 43);
                for (int k = 0; k < tempArray.Length; k++)
                {
                    if(k == tempArray.Length -1 )
                        detail = dloItemData.GetItemString(i, "mix_group").Trim() == "" ? detail + tempArray[k] : detail + tempArray[k];
                    else
                        detail = dloItemData.GetItemString(i, "mix_group").Trim() == "" ? detail + tempArray[k] + "\n\r　" : detail + tempArray[k] + "\n\r";
                }

                //displayText = dloItemData.GetItemString(i, "detail").Trim() == "" ? displayText + "" : displayText + "    " + SET_MIX + "" + dloItemData.GetItemString(i, "detail") + "\n";
                displayText = dloItemData.GetItemString(i, "detail").Trim() == "" ? displayText + "" : displayText + "    " + SET_MIX + "" + detail + "\n";

                displayText = dloItemData.GetItemString(i, "order_remark").Trim() == "" ? displayText + "" : displayText + "    " + SET_MIX + "└ " + dloItemData.GetItemString(i, "order_remark") + "\n";
                displayText = dloItemData.GetItemString(i, "nurse_remark").Trim() == "" ? displayText + "" : displayText + "    " + SET_MIX + "└ [看護]" + dloItemData.GetItemString(i, "nurse_remark") + "\n";

                //if (!TypeCheck.IsNull(dloItemData.GetItemString(i, "reser_date")))
                //{
                //    if (SET_MIX.Replace(" ", "").Replace("　", "").Trim() != "")
                //    {
                //        displayText = displayText + "    " + SET_MIX + "[予約オーダ]";
                //    }
                //    else
                //    {
                //        displayText = displayText + "    " + SET_MIX + "　　[予約オーダ]";
                //    }
                //}

                if (!TypeCheck.IsNull(dloItemData.GetItemString(i, "hold_user").Trim()))
                {
                    displayText = displayText + "    " + SET_MIX + "└ [保留]" + dloItemData.GetItemString(i, "hold_user") + "\n";
                }


                
				if( i < dloItemData.RowCount -1 )
				{	
					if( !TypeCheck.IsNull(dloItemData.GetItemString(i,"mix_group").Trim()) && (
						chk_row       != dloItemData.GetItemInt   (i + 1,"rowindex")    || 
						chk_colKey    != dloItemData.GetItemString(i + 1, "order_date").Replace("/", "") + dloItemData.GetItemString(i, "input_gubun") || 
						chk_table_id  != dloItemData.GetItemString(i + 1,"table_id")    || 
						chk_group_ser != dloItemData.GetItemString(i + 1,"group_ser")   ||
						chk_mix_group != dloItemData.GetItemString(i + 1,"mix_group").Trim()))
					{
                        if (displayText.IndexOf(MIX_START) > -1)
                        {
                            displayText = displayText.Replace(MIX_START, "").Replace(SET_MIX, "");
                        }
                        else
                        {
                            displayText = displayText.Substring(0, displayText.LastIndexOf(SET_MIX.Trim())) + MIX_END + displayText.Substring(displayText.LastIndexOf(SET_MIX.Trim()) + 1);// +"△▼△▼";
                        }
					}

				}
				else
				{
					if( !TypeCheck.IsNull(dloItemData.GetItemString(i,"mix_group").Trim()) )
					{
                        if (displayText.IndexOf(MIX_START) > -1)
                            displayText = displayText.Replace(MIX_START, "").Replace(SET_MIX, "");
                        else
                            displayText = displayText.Substring(0, displayText.LastIndexOf(SET_MIX.Trim())) + MIX_END + displayText.Substring(displayText.LastIndexOf(SET_MIX.Trim()) + 1);// +"■□■□■□■□";
						SET_MIX = "";
					}

                }

                //// 20120220 KHJ 오더취소 ID 표시
                if (dloItemData.GetItemInt(i, "nalsu") < 0) displayText = displayText + "         取消 ▶ " + dloItemData.GetItemString(i, "input_name");

                /*   [[ 20101227 KHJ 지시사항 종료일까지 표시하기 위한 반복문 ]] */
				mtxPlanMgt.Items.Add(row, colKey, displayText);				
                
				mtxPlanMgt.Items[j].ImageAlign = System.Drawing.ContentAlignment.TopLeft;
				mtxPlanMgt.Items[j].TextAlign  = System.Drawing.ContentAlignment.TopLeft;

				//해당 Item tag에는 해당 rowIndex값을 가져간다.
				mtxPlanMgt.Items[j].Tag = i;
                // 20120120 KHJ
                mtxPlanMgt.Items[j].TextFont = new Font("MS UI Gothic", 7.75F, FontStyle.Regular, GraphicsUnit.Point, ((System.Byte)(0)));
				
				if ( dloItemData.GetItemString(i,"table_id") == "OCS2005" )
				{
                    //지시사항
                    if (dloItemData.GetItemString(i, "acting_yn") == "Y")
					{
                        if (dloItemData.GetItemString(i, "order_gubun") == "03")
                        {
                            if (dloItemData.GetItemString(i, "hangmog_code").Substring(2, 1) == "2")
                                mtxPlanMgt.Items[j].ImageIndex = 26;
                            else
                                // 식사   
                                mtxPlanMgt.Items[j].ImageIndex = 22;
                        }
                        else
                        {
                            //실시 지시사항
                            mtxPlanMgt.Items[j].ImageIndex = 2;
                                                        
                            //현재 날짜가 시작일보다 작거나 목표일보다 크면 사용할 수 없음
                            if ((EnvironInfo.GetSysDateTime().ToString("yyyyMMddHHmm").CompareTo(dloItemData.GetItemString(i, "drt_from_datetime")) < 0)
                                || (EnvironInfo.GetSysDateTime().ToString("yyyyMMddHHmm").CompareTo(dloItemData.GetItemString(i, "drt_to_datetime")) > 0))
                            {
                                mtxPlanMgt.Items[j].TextColor = Color.LightGray;
                            }
                        }
					}
					else
					{
						//미실시 지시사항
						mtxPlanMgt.Items[j].TextColor  = Color.Blue;
						mtxPlanMgt.Items[j].ImageIndex = 1;

                        //현재 날짜가 시작일보다 작거나 목표일보다 크면 사용할 수 없음
                        if ((EnvironInfo.GetSysDateTime().ToString("yyyyMMddHHmm").CompareTo(dloItemData.GetItemString(i, "drt_from_datetime")) < 0)
                            || (EnvironInfo.GetSysDateTime().ToString("yyyyMMddHHmm").CompareTo(dloItemData.GetItemString(i, "drt_to_datetime")) > 0))
                        {
                            mtxPlanMgt.Items[j].TextColor = Color.LightGray;
                        }
					}
				}
			    else if ( dloItemData.GetItemString(i,"table_id") == "OCS6015" )
				{
                    // 실시
                    if (dloItemData.GetItemString(i, "acting_yn") == "Y")
                    {
                        mtxPlanMgt.Items[j].ImageIndex = 2;
                    }
                    else
                    {
                        //예정지시사항
                        mtxPlanMgt.Items[j].TextColor = Color.Blue;
                        mtxPlanMgt.Items[j].ImageIndex = 1;
                    }
				}
				else if ( dloItemData.GetItemString(i,"table_id") == "OCS2003" )
				{
					//처방
					if (dloItemData.GetItemString(i,"bulyong_check").Trim() == "Y")
					{
						//미간호확인
						mtxPlanMgt.Items[j].TextColor = Color.Red;								
						mtxPlanMgt.Items[j].ImageIndex = 17;
					}
					else if (dloItemData.GetItemString(i,"detail_act_yn") == "Y")
					{
						//투약실시						
                        mtxPlanMgt.Items[j].ImageIndex = 16;
					}
				    else if(dloItemData.GetItemString(i,"acting_yn") == "Y")
					{
						//시행
                        int index = 5;
                        BindVarCollection bindVars = new BindVarCollection();
                        bindVars.Add("f_fkocs2003", dloItemData.GetItemString(i, "pk"));
                        bindVars.Add("f_act_res_date", dloItemData.GetItemString(i, "order_date"));
                        //bindVars.Add("f_acting_date", dloItemData.GetItemString(i, "acting_date"));
                        bindVars.Add("f_hosp_code", mHospCode);

                        //string result = MedicineActingCheck(bindVars);

                        string result = dloItemData.GetItemString(i, "medi_act_chk");

                        // OCS2017투약실시체크
                        if (result == "5" || result == "6") index = 18;  // 약
                        else if (result == "4") index = 16;              // 주사
                        else if (!TypeCheck.IsNull(dloItemData.GetItemString(i, "nurse_act_user")))
                            index = 27;
                        else index = 5;                                 // 기타

						mtxPlanMgt.Items[j].ImageIndex = index;
                    }
					else if(dloItemData.GetItemString(i,"confirm_yn") == "Y")
					{
						//간호확인
                        //if ((dloItemData.GetItemString(i, "order_gubun") == "C" ||   // 약(내복/외용)의 간호확인
                        //     dloItemData.GetItemString(i, "order_gubun") == "D"   )
                        //    && dloItemData.GetItemString(i, "acting_date") != "")
                        //{
                        //        mtxPlanMgt.Items[j].ImageIndex = 18;
                        //}
                        //else
                        //{
                            mtxPlanMgt.Items[j].ImageIndex = 4;
                        //}
					}
                    else
                    {
                        mtxPlanMgt.Items[j].ImageIndex = 3;
                    }
                    
					//미간호확인
					if( dloItemData.GetItemString(i,"confirm_yn") == "N" )						
						mtxPlanMgt.Items[j].TextColor = Color.Blue;	

                    //DC, 반납 -건
                    if (int.Parse(dloItemData.GetItemString(i, "nalsu")) < 0)
                    {
                        if (dloItemData.GetItemString(i, "confirm_yn") == "Y")
                        {
                            mtxPlanMgt.Items[j].TextColor = Color.LightGray;
                        }
                        else
                        {
                            mtxPlanMgt.Items[j].TextColor = Color.Red;
                        }
                    }
                    
					// 반납지시
					if( dloItemData.GetItemString(i,"hangmog_name").IndexOf("返納指示") > 0)
						mtxPlanMgt.Items[j].TextColor = Color.Red;
					

				}
				else if ( dloItemData.GetItemString(i,"table_id") == "OCS6013" )
				{
					//예정처방	
					//처방
					if (dloItemData.GetItemString(i,"bulyong_check").Trim() == "Y")
					{
						//미간호확인
						mtxPlanMgt.Items[j].TextColor = Color.Red;								
						mtxPlanMgt.Items[j].ImageIndex = 17;
					}
					else
                        mtxPlanMgt.Items[j].ImageIndex = 6;
                }
                /*   [[ 20101227 KHJ 지시사항 종료일까지 표시하기 위한 반복문 ]] */

			}
		}
        /*
        /// <summary>
        /// 투약실시 체크와 투약오더의 구분(약/주사)를 판단한다.
        /// </summary>
        /// <param name="bindVars"></param>
        /// <returns></returns>
        private string MedicineActingCheck(BindVarCollection bindVars)
        {
            string cmdText = @"SELECT DISPLAY_SEQ
                                 FROM OCS2017
                                WHERE HOSP_CODE    = :f_hosp_code
                                  AND FKOCS2003    = :f_fkocs2003
                                  AND ACT_RES_DATE = :f_act_res_date
                                --AND ACTING_DATE  = TO_CHAR(to_date(:f_acting_date), 'YYYY/MM/DD')
                                  AND TRIM(ACTING_DATE) IS NOT NULL";

            object result = Service.ExecuteScalar(cmdText, bindVars);

            if (result != null)
            {
                return result.ToString();
            }
            else
            {
                return "0";
            }
        }
        */
		#region [ Row Title 설정]
        
		/// <summary>
		/// Row Title Panel을 생성한다.
		/// </summary>
		private void CreateRowTitlePanel()
		{	
			pnlRowTitle = new IHIS.Framework.XPanel();
            pnlRowTitle.BorderColor = IHIS.Framework.XColor.XMatrixLineColor;
			pnlRowTitle.DrawBorder = true;
			pnlRowTitle.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			pnlRowTitle.Location = new System.Drawing.Point(0, -1);
			pnlRowTitle.Name = "pnlRowTitle";
            pnlRowTitle.Size = new System.Drawing.Size(mtxPlanMgt.RowHeaderWidth + 1, 40);
			
			mtxPlanMgt.Controls.Add(this.pnlRowTitle);
		}
        
		/// <summary>
		/// Row Title의 Label를 추가한다.
		/// </summary>
		private void AddTitle(string aTitle, int aStartMergeRowIndex, int aEndMergeRowIndex)
		{
			//Merge할 rowItem의 높이를 더해서 높이를 구한다.
			int   height = 0;			
			for(int i = aStartMergeRowIndex; i <= aEndMergeRowIndex; i++)
			{
				try
				{
					height = height + this.mtxPlanMgt.RowItems[i].Height;
				}
				catch{}
			}
			
			// Create Title Label 
			XLabel lblTitle = new XLabel();
            lblTitle.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            lblTitle.BorderColor = IHIS.Framework.XColor.XMatrixLineColor;
			lblTitle.EdgeRounding = false;
			lblTitle.Location = new System.Drawing.Point(0, 0);
			lblTitle.Name = "lbl" + aTitle;
            lblTitle.Size = new System.Drawing.Size(pnlRowTitle.Size.Width + 4, height);
			lblTitle.Text = aTitle;	
			lblTitle.Tag = aStartMergeRowIndex.ToString() + "|" + aEndMergeRowIndex.ToString();
			lblTitle.BringToFront();

            lblTitle.Font = new Font("MS UI Gothic", 7.75F, FontStyle.Regular, GraphicsUnit.Point, ((System.Byte)(0)));
			// Add Title Label
			pnlRowTitle.Controls.Add(lblTitle);

		}
        
		/// <summary>
		/// Row Title Panel의 높이를 Setting한다.
		/// </summary>
		private void SetRowTitleHeight()
		{
			int mergeHeigtht = 0;
			int mergeFrCol   = 0;
			int mergeToCol   = 0;
			int height       = 0;

			for(int i = 0; i < pnlRowTitle.Controls.Count; i++)
			{
				mergeHeigtht = 0;
				mergeFrCol   = int.Parse(((Label)pnlRowTitle.Controls[i]).Tag.ToString().Split('|')[0]);
				mergeToCol   = int.Parse(((Label)pnlRowTitle.Controls[i]).Tag.ToString().Split('|')[1]);

				//Merge할 rowItem의 높이를 더해서 높이를 구한다.
				for(int j = mergeFrCol; j <= mergeToCol; j++)
				{
					try
					{
						mergeHeigtht = mergeHeigtht + mtxPlanMgt.RowItems[j].Rect.Height;
					}
					catch{}
				}
                
				//merge시 각 Control이 맞붙게되면 각 boarder Line 때문에 선이 굵게 보이므로 곁치게 layout한다.
				//단 마지막 Control은 제외
				if(i == pnlRowTitle.Controls.Count - 1)
                    ((Label)pnlRowTitle.Controls[i]).SetBounds(0, mtxPlanMgt.RowItems[mergeFrCol].Rect.Y, ((Label)pnlRowTitle.Controls[i]).Size.Width, mergeHeigtht);
				else
					((Label)pnlRowTitle.Controls[i]).SetBounds(0, mtxPlanMgt.RowItems[mergeFrCol].Rect.Y, ((Label)pnlRowTitle.Controls[i]).Size.Width, mergeHeigtht + 1);

				((Label)pnlRowTitle.Controls[i]).BringToFront();
				height = height + mergeHeigtht;
			}

			pnlRowTitle.SetBounds(pnlRowTitle.Location.X, pnlRowTitle.Location.Y, pnlRowTitle.Size.Width, height);
			pnlRowTitle.BringToFront();
		}
		
		#endregion

		#region [ Col Title 설정]
        
		/// <summary>
		/// Col Title Panel을 생성한다.
		/// </summary>
		private void CreateColTitlePanel()
		{	
			pnlColTitle = new IHIS.Framework.XPanel();
			pnlColTitle.BorderColor = IHIS.Framework.XColor.XMatrixLineColor;
			pnlColTitle.DrawBorder = true;
			pnlColTitle.Font = new System.Drawing.Font("MS UI Gothic", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			pnlColTitle.Location = new System.Drawing.Point(mtxPlanMgt.RowHeaderWidth, 0);
			pnlColTitle.Name = "pnlRowTitle";
			pnlColTitle.Size = new System.Drawing.Size(0, 0);
			pnlColTitle.Visible = false;

			mtxPlanMgt.Controls.Add(this.pnlColTitle);
		}

		private void SetColTitle()
		{
			if ( mtxPlanMgt.RowItems.Count == 0 ) return;

			int ColTitlePanelWidth  = 0;
			int ColTitlePanelHeight = 0;
			int ColHeaderHeight = mtxPlanMgt.RowItems[0].Height;

			XLabel lblTitle;
            #region row header쪽 col부분
            //			lblTitle = new XLabel();
//			lblTitle.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
//			lblTitle.BorderColor = IHIS.Framework.XColor.XMatrixLineColor;
//			lblTitle.EdgeRounding = false;
//			lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
//			lblTitle.ImageList = this.ImageList;
//			lblTitle.Location = new System.Drawing.Point(0, 0);
//			lblTitle.Name = "lbl" + mtxPlanMgt.RowItems[0].Text;
//			lblTitle.Size = new System.Drawing.Size(mtxPlanMgt.RowItems[0].Rect.Width, mtxPlanMgt.RowItems[0].Rect.Height + 2);			
//			lblTitle.Text = mtxPlanMgt.RowItems[0].Text;	
//			lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//			pnlColTitle.Controls.Add(lblTitle);			
//			lblTitle.BringToFront();
//
//			lblTitle = new XLabel();
//			lblTitle.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
//			lblTitle.BorderColor = IHIS.Framework.XColor.XMatrixLineColor;
//			lblTitle.EdgeRounding = false;
//			lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
//			lblTitle.ImageList = this.ImageList;
//			lblTitle.Location = new System.Drawing.Point(0, ColHeaderHeight);
//			lblTitle.Name = "lbl" + mtxPlanMgt.RowItems[1].Text;
//			lblTitle.Size = new System.Drawing.Size(mtxPlanMgt.RowItems[1].Rect.Width, mtxPlanMgt.RowItems[1].Rect.Height + 2);			
//			lblTitle.Text = mtxPlanMgt.RowItems[1].Text;	
//			lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//			pnlColTitle.Controls.Add(lblTitle);			
            //			lblTitle.BringToFront();
            #endregion

            // Col Header를 생성한다.			
			for(int i = 0; i < mtxPlanMgt.ColItems.Count; i++)
			{
				lblTitle = new XLabel();
				lblTitle.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
                lblTitle.BorderColor = IHIS.Framework.XColor.XMatrixLineColor;
				lblTitle.EdgeRounding = false;
				lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
				lblTitle.ImageList = this.ImageList;
				lblTitle.ImageIndex = mtxPlanMgt.ColItems[i].ImageIndex;
				// col title X = row title 넓이 + 이전까지 col title 넓이
				lblTitle.Location = new System.Drawing.Point(ColTitlePanelWidth - 1, -1);
				lblTitle.Name = "lbl" + mtxPlanMgt.ColItems[i].Tag.ToString();
                lblTitle.Size = new System.Drawing.Size(mtxPlanMgt.ColItems[i].Width + 4, ColHeaderHeight + 2);
				lblTitle.Text = mtxPlanMgt.ColItems[i].Text;	
				lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 201201 KHJ
                lblTitle.Font = new Font("MS UI Gothic", 8.25F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));


				pnlColTitle.Controls.Add(lblTitle);			
				lblTitle.BringToFront();

				for( int j = 0; j < mtxPlanMgt.ColItems[i].Childs.Count; j++ )
				{
					lblTitle = new XLabel();
					lblTitle.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
                    lblTitle.BorderColor = IHIS.Framework.XColor.XMatrixLineColor;
					lblTitle.EdgeRounding = false;
					lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
					lblTitle.ImageList = this.ImageList;
					lblTitle.ImageIndex = mtxPlanMgt.ColItems[i].Childs[j].ImageIndex;
					// col title X = row title 넓이 + 이전까지 col title 넓이 + child 넓이
					lblTitle.Location = new System.Drawing.Point( ColTitlePanelWidth + j * DATACOLWIDTH - 1, ColHeaderHeight -1);
					lblTitle.Name = "lbl" + mtxPlanMgt.ColItems[i].Childs[j].Tag.ToString();
                    lblTitle.Size = new System.Drawing.Size(mtxPlanMgt.ColItems[i].Childs[j].Width + 4, ColHeaderHeight + 2);
					lblTitle.Text = mtxPlanMgt.ColItems[i].Childs[j].Text;
                    lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    // 201201 KHJ
                    lblTitle.Font = new Font("MS UI Gothic", 8.25F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));


					pnlColTitle.Controls.Add(lblTitle);			
					lblTitle.BringToFront();
				}

				// col title panel 넓이
                ColTitlePanelWidth += mtxPlanMgt.ColItems[i].Width;
			}
            
			// col title panel 높이
			ColTitlePanelHeight = mtxPlanMgt.RowItems[0].Height * 2 + 1;

			//pnlColTitle.Visible = true;
			pnlColTitle.Size = new System.Drawing.Size(ColTitlePanelWidth, ColTitlePanelHeight);
			//pnlColTitle.BringToFront();


		}
		
		#endregion

		#region [Layout Function]
        
		/// <summary>
		/// Clear Matrix
		/// </summary>
		private void ClearMatrix()
		{	
			//선택정보삭제
			this.htSelectItem.Clear();

			//Scroll처리
			if(mtxPlanMgt.AutoScroll)
				mtxPlanMgt.AutoScrollPosition = new Point(0, 0);
			
			//input_gubun 정보 Clear
			dloInput_gubun.Reset();
		
			//data Clear
			mtxPlanMgt.Items.Clear();
			//col 정보 Clear
			mtxPlanMgt.ColItems.Clear();
			//row 정보 Clear
			mtxPlanMgt.RowItems.Clear();

			mtxPlanMgt.SuspendLayout();
            
			//row Title정보 Clear
			pnlRowTitle.Controls.Clear();	
			pnlRowTitle.Visible = false;

			//col Title정보 Clear
			pnlColTitle.Controls.Clear();
			pnlColTitle.Visible = false;

			try
			{
				//row Item에서 error발생됨.
				mtxPlanMgt.Setup();
			}
			catch{}
            
			mtxPlanMgt.ResumeLayout();
			mtxPlanMgt.Refresh();
		}
        
		#endregion

		#endregion	

		#region [Function]
        
		/// <summary>
		/// 수정한 정보가 있는지 Check한다.
		/// </summary>
		/// <returns></returns>
		private bool CheckModifyData()
		{
			bool returnValue = false;


			return returnValue;
		}
        
		/// <summary>
		/// 간호확인이 가능한지 Check한다.
		/// </summary>
		/// <returns></returns>
		private bool CheckOrderConfirmPossible()
		{
			bool returnValue = true;

			int currentDataIndex = -1;
			if (mtxPlanMgt.SelectedItems.Count > 0)
				currentDataIndex = int.Parse(mtxPlanMgt.SelectedItems[0].Tag.ToString());
			else
				return false;

			string checkValue = GetCheckValue("confirm_check", dloItemData.GetItemString(currentDataIndex, "pk"));

			switch (checkValue.Trim())
			{
				case "B":

					mbxMsg = NetInfo.Language == LangMode.Jr ? "不用処理されたオーダコードです。処方の再入力を求めてください。" : "불용처리 되어 처방확인이 불가능합니다. \n\r 처방을 재입력을 요청하세요";
					mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認不可" : "간호확인불가";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
					returnValue = false;
					break;

				case "J":

					mbxMsg = NetInfo.Language == LangMode.Jr ? "該当オーダの伝達基準が変わりました。処方の再入力を求めてください。" : "해당 처방의 전달기준이 바뀌었습니다.\n\r 처방을 재입력을 요청하세요";
					mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認不可" : "간호확인불가";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
					returnValue = false;
					break;

				case "D":

					mbxMsg = NetInfo.Language == LangMode.Jr ? "同一グループ内に重複オーダが存在します。確認しますか?" : "동일그룹내에 중복 Order가 존재합니다.\n\r 확인하시겠습니까?";
					mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認" : "간호확인";
					DialogResult result;
					result = XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, MessageBoxIcon.Question); 
					if(result == DialogResult.Yes)
						returnValue = true;
					else if(result == DialogResult.Cancel)
						returnValue = false;

					break;

				case "OE":

					mbxMsg = NetInfo.Language == LangMode.Jr ? "入力されたオーダ単位は間違っています。\n\r 確認してください。": "입력된 처방단위의 오류가 있습니다. \n\r 확인하세요.";
					mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認不可" : "간호확인불가";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
					returnValue = false;
					break;

				case "OB":

					mbxMsg = NetInfo.Language == LangMode.Jr ? "オーダ単位は必須入力項目です。。\n\r 確認してください。": "처방단위가 반드시 입력되어야 합니다. \n\r 확인하세요.";
					mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認不可" : "간호확인불가";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
					returnValue = false;
					break;

				case "ON":

					mbxMsg = NetInfo.Language == LangMode.Jr ? "オーダ単位値が不必要です。\n\r 確認してください。": "처방단위값이 불필요합니다. \n\r 확인하세요.";
					mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認不可" : "간호확인불가";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
					returnValue = false;
					break;

				case "G":

					mbxMsg = NetInfo.Language == LangMode.Jr ? "入力されたオーダ日付が退院日付より大きいです。\n\r 確認してください。": "입력된 처방일자가 가퇴원일자보다 큽니다. \n\r 확인하세요.";
					mbxCap = NetInfo.Language == LangMode.Jr ? "看護確認不可" : "간호확인불가";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
					returnValue = false;
					break;
				
				default:

					returnValue = true;

					break;
			}
            
			return returnValue;
		}

		private string LoadDayName(string day)
		{
			string dayName = "";

			switch (day.Trim())
			{
				case "Sunday":

					dayName = " 【日】";

					break;

				case "Monday":

					dayName = " 【月】";

					break;

				case "Tuesday":

					dayName = " 【火】";

					break;

				case "Wednesday":

					dayName = " 【水】";

					break;

				case "Thursday":

					dayName = " 【木】";

					break;

				case "Friday":

					dayName = " 【金】";

					break;

				case "Saturday":

					dayName = " 【土】";

					break;
			}

			return dayName;
		}
        
		#endregion

		#region [MouseDown, DragInfo]

		private bool	m_bCanDrag = false;
		private int		m_iDragX = 0;
		private int		m_iDragY = 0;

		private int		m_iMenuX = 0;
		private int		m_iMenuY = 0;

        private Rectangle dragBoxFromMouseDown; // popup order info
		private void mtxPlanMgt_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (frmOrderInfo != null) frmOrderInfo.Dispose();

            //if (!mIsJaewonYn)
            //    return;
            

			if(mtxPlanMgt.RowItems.Count < 1) return;

            if (mIsJaewonYn && e.Clicks == 1 && e.Button == MouseButtons.Left)
            {
                dragBoxFromMouseDown = Rectangle.Empty;
                Size dragSize = SystemInformation.DragSize;
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)), dragSize);

                this.ClearSelectItem();
                mtxPlanMgt.UnSelectAll();

                m_bCanDrag = true;
                m_iDragX = e.X;
                m_iDragY = e.Y;

                PostCallHelper.PostCall(new PostMethod(SelectMutiItem));


            }
            else if (mIsJaewonYn && e.Clicks == 2 && e.Button == MouseButtons.Left)
			{
				this.ClearSelectItem();
				mtxPlanMgt.UnSelectAll();

                PostCallHelper.PostCall(new PostMethod(SelectMutiItem));
			}
            else if (e.Clicks == 1 && e.Button == MouseButtons.Right)
            {
                m_iMenuX = e.X + (mtxPlanMgt.AutoScroll ? mtxPlanMgt.AutoScrollPosition.X : 0);
                //Scroll값을 읽어서 위치계산
                m_iMenuY = e.Y + (mtxPlanMgt.AutoScroll ? mtxPlanMgt.AutoScrollPosition.Y : 0);
                PostCallHelper.PostCall(new PostMethod(OpenPopupMenu));
            }
            mtxPlanMgt.Focus();
		}

		#region DragHelper 사용 Drag Drop

		private void mtxPlanMgt_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
			if (m_bCanDrag && (Math.Abs(e.X - m_iDragX) > 3 || Math.Abs(e.Y - m_iDragY) > 3))
			{
				m_bCanDrag = false;
				
				// Starts a drag-and-drop operation with that item.
				// Mouse Down Event이후에 SelectedItems이 생성되므로 여기서 기술
				
				if (mtxPlanMgt.SelectedItems.Count < 1) return;

				if( TypeCheck.IsNull(mtxPlanMgt.SelectedItems[0].Tag) || dloItemData.GetItemString(int.Parse(mtxPlanMgt.SelectedItems[0].Tag.ToString()), "table_id") != "OCS6013") 
					return;
			    
				//해당 예정사항을 변경가능한 경우에만 Drag할 수 있도록 한다.
				if(dloItemData.GetItemString(int.Parse(mtxPlanMgt.SelectedItems[0].Tag.ToString()), "can_plan_change_yn") == "Y")
				{
					//Drag Image 생성
					XMatrixItem item = mtxPlanMgt.SelectedItems[0];
					DragHelper.CreateDragCursor(mtxPlanMgt, item.Text, item.TextFont);
					mtxPlanMgt.DoDragDrop(mtxPlanMgt.SelectedItems, DragDropEffects.Move);
				}
			}

            // popup 된 위치에서 지정수치 이상 벗어나면 폼을 Dispose 시킴
            //if (Math.Abs(e.X - dragBoxFromMouseDown.X) > 30 || Math.Abs(e.Y - dragBoxFromMouseDown.Y) > 30)
            //{
            //    dragBoxFromMouseDown = Rectangle.Empty;
            //    if (frmOrderInfo != null) { frmOrderInfo.Close(); frmOrderInfo.Dispose(); }
            //}
		}
		
		private void mtxPlanMgt_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(IHIS.Framework.XMatrixItemCollection)))
				e.Effect = DragDropEffects.Move;
		}

		private void mtxPlanMgt_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
				Cursor.Current = DragHelper.DragCursor;
		}

		private void mtxPlanMgt_ItemDragDrop(object sender, IHIS.Framework.XMatrixItemDragDropEventArgs e)
		{
			XMatrixItemCollection items = (e.Data.GetData(typeof(XMatrixItemCollection))) as XMatrixItemCollection;
			if (items == null)
				return;
			
			XMatrixItem dragItem = items[0];
			//DragItem과 DropItem이 같으면 Return
			if ((e.DropItem != null) && dragItem.Equals(e.DropItem))
				return;

			//row가 다른 경우에는 이동을 막는다.(연속지시사항 표시문제)
			if(e.DropRow != dragItem.Row)
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "同じ項目（row）の中だけで予定変更が出来ます。確認してください。" : "같은 항목(row)내에서만 예정변경이 가능합니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "予定変更" : "예정변경";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				this.ClearSelectItem();
				mtxPlanMgt.UnSelectAll();
				return;
			}

			//현재일자 이후로만 변경이 가능하도록 한다.
			if( int.Parse(e.DropColKey.Substring(0, 8)) < int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "現在日以後だけで予定変更が出来ます。確認してください。" : "현재일이후로만 예정변경이 가능합니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "予定変更" : "예정변경";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				this.ClearSelectItem();
				mtxPlanMgt.UnSelectAll();
				return;
			}

			//DataLayout에 값을 변경한다.
			string modifyOrder_date  = e.DropColKey.Substring(0, 4) + "/" + e.DropColKey.Substring(4, 2) + "/" + e.DropColKey.Substring(6, 2);
			string modifyInput_gubun = e.DropColKey.Substring(8, 2);
			
			//현재 예정적용일자보다 변경하려는 일자가 작은지 check한다.
			if( !GetCheckModifyPlan_date(dloItemData.GetItemString( int.Parse(dragItem.Tag.ToString()), "fkocs6010" ), modifyOrder_date))
				return;
            
			//지시사항 중복여부 check
			if(!GetCheckDupDirect(modifyOrder_date, modifyInput_gubun, int.Parse(dragItem.Tag.ToString())))
				return;			
			
			//DropItem이 있으면 DropItem의 앞에 Insert하고 Row, ColKey만 Change
			if (dragItem.ColKey == e.DropColKey && e.DropItem != null)
			{
				this.ClearSelectItem();
				mtxPlanMgt.UnSelectAll();
				return;		//mtxPlanMgt.Items.Insert(e.DropItem, dragItem, true);
			}

			//input_gubun 변경은 막는다.
			if(modifyOrder_date == dloItemData.GetItemString( int.Parse(dragItem.Tag.ToString()), "order_date")) return;
						
			//DragItem의 ColKey과 Row를 변경
			if(dloItemData.GetItemString(int.Parse(dragItem.Tag.ToString()), "table_id") == "OCS6013") 
			{
				mbxMsg = "オーダ日を変更しますか?";
				mbxCap = "オーダ日変更";
				DialogResult result;
				result = XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, MessageBoxIcon.Question); 
				if(result == DialogResult.Yes)
				{					
					MoveSelectItem(e.DropColKey, modifyOrder_date, modifyInput_gubun);
				}
			    else
					return;
			}
			else
			{
				dragItem.ColKey = e.DropColKey;
				dragItem.Row = e.DropRow;

				dloItemData.SetItemValue( int.Parse(dragItem.Tag.ToString()), "order_date" , modifyOrder_date );
				//dloItemData.SetItemValue( int.Parse(dragItem.Tag.ToString()), "input_gubun", modifyInput_gubun);
			}

			
			//SaveData();
			
//			mtxPlanMgt.SuspendLayout();
//			mtxPlanMgt.Setup(true);
//			SetRowTitleHeight();
//			mtxPlanMgt.ResumeLayout();
//			this.ClearSelectItem();
//			mtxPlanMgt.UnSelectAll();
			
			mScrollPoint = mtxPlanMgt.AutoScrollPosition;
			SaveData();
			ShowData(false);
			PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));
		}
		#endregion
		
		#endregion

		#region [Control Event]
		
		private void dpkFrom_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{	
			if(!TypeCheck.IsDateTime(e.DataValue))
			{
                mbxMsg = NetInfo.Language == LangMode.Jr ? "正しくない日付が入力されました。ご確認ください。" : "일자를 잘못 입력하셨습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
				e.Cancel = true;
			}
			else
			{
				e.Cancel = false;
				dpkTo_date.SetDataValue(DateTime.Parse(e.DataValue).AddDays(6).ToString("yyyy/MM/dd"));
				this.ShowData(false);
			}
		}
        
		/// <summary>
		/// 기준일자를 1일전으로 돌린다.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPrePeriod_Click(object sender, System.EventArgs e)
		{
			if(!TypeCheck.IsDateTime(dpkFrom_date.GetDataValue()))
			{
                mbxMsg = NetInfo.Language == LangMode.Jr ? "正しくない日付が入力されました。ご確認ください。" : "일자를 잘못 입력하셨습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
				dpkFrom_date.Focus();
			}
			else
			{
				dpkFrom_date.SetDataValue(DateTime.Parse(dpkFrom_date.GetDataValue()).AddDays(-1).ToString("yyyy/MM/dd"));
                dpkTo_date.SetDataValue(DateTime.Parse(dpkTo_date.GetDataValue()).AddDays(-1).ToString("yyyy/MM/dd"));
				this.ShowData(false);
			}		
		}
        
		/// <summary>
		/// 기준일자를 1일후로 돌린다.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnNextPeriod_Click(object sender, System.EventArgs e)
		{
			if(!TypeCheck.IsDateTime(dpkFrom_date.GetDataValue()))
			{
                mbxMsg = NetInfo.Language == LangMode.Jr ? "正しくない日付が入力されました。ご確認ください。" : "일자를 잘못 입력하셨습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
				dpkFrom_date.Focus();
			}
			else
			{
				dpkFrom_date.SetDataValue(DateTime.Parse(dpkFrom_date.GetDataValue()).AddDays(1).ToString("yyyy/MM/dd"));
                dpkTo_date.SetDataValue(DateTime.Parse(dpkTo_date.GetDataValue()).AddDays(1).ToString("yyyy/MM/dd"));
				this.ShowData(false);
			}				
		}

		#endregion

		#region [Button List Event]

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:
					
					e.IsBaseCall = false;

					if(!TypeCheck.IsDateTime(dpkFrom_date.GetDataValue()))
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "正しくない日付が入力されました。ご確認ください。" : "일자를 잘못 입력하셨습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
						dpkFrom_date.Focus();
					}
					else
					{
						this.ShowData(false);
					}		

					break;

				case FunctionType.Update:

					e.IsBaseCall = false;

                    SaveData();

                    //if (dloItemData.SaveLayout())
                    //{
                    //    mbxMsg = "保存しました。";
                    //    SetMsg(mbxMsg);
                    //}
                    //else
                    //{
                    //    mbxMsg = "保存に失敗しました。";
                    //    mbxMsg = mbxMsg + Service.ErrMsg;
                    //    mbxCap = "保存エラー";
                    //    XMessageBox.Show(mbxMsg, mbxCap);
                    //}

					break;
				
				default:

					break;
			}	
		}


		#endregion

		#region [저장]

        private void SaveData()
        {
            this.AcceptData();

            if (dloItemData.SaveLayout())
            {
                mbxMsg = "保存しました。";
                SetMsg(mbxMsg);
            }
            else
            {
                mbxMsg = "保存に失敗しました。";
                mbxMsg = mbxMsg + Service.ErrMsg;
                mbxCap = "保存エラー";
                XMessageBox.Show(mbxMsg, mbxCap);
            }
        }

		#endregion

		#region [Check]
        
		/// <summary>
		/// 간호확인시 각종 CHECK값을 가져옵니다.
		/// </summary>
		/// <param name="code">코드Value</param>
		/// <returns></returns>
		private string GetCheckValue(string checkMode, string code)
		{
			string checkValue = "";
            string cmdText = "";
            object retVal = null;

			if(code.Trim() == "" ) return checkValue;

			switch (checkMode)
			{
				case "confirm_check":

                    cmdText = "SELECT FN_OCS_CHECK_CAN_CONFIRM_INP(" + code + ") FROM DUAL";
                    retVal = Service.ExecuteScalar(cmdText);

                    if (!TypeCheck.IsNull(retVal))
                    {
                        checkValue = "F";
                    }
                    else
                        checkValue = retVal.ToString();

					break;
				
				default:
					break;
			}

			return checkValue;
		}
        
		/// <summary>
		/// 수정하려는 예정일자가 현재예정계획 적용일자에 유효한지 check한다.
		/// </summary>
		/// <param name="aFkocs6010"></param>
		/// <param name="aModify_date"></param>
		/// <returns></returns>
		private bool GetCheckModifyPlan_date(string aFkocs6010, string aModify_date)
		{
			bool checkValue = true;
            string cmdText  = "";
            object retVal   = null;

			cmdText = ""
				+ " SELECT DECODE(SIGN(TO_DATE('" + aModify_date + "', 'YYYY/MM/DD') - APP_DATE), -1, 'N', 'Y') "
				+ "   FROM OCS6010 "
                + "  WHERE HOSP_CODE = '" + mHospCode + "'"
                + "    AND PKOCS6010 = "  + aFkocs6010;

            retVal = Service.ExecuteScalar(cmdText);
			
			if(TypeCheck.IsNull(retVal))
				checkValue = false;					
			else
			{
                if (retVal.ToString() == "Y")
					checkValue = true;
				else
				{
					mbxMsg = NetInfo.Language == LangMode.Jr ? "予定は予定計画適用日以後から変更可能です。ご確認ください。" : "예정계획적용일자이후로만 예정변경이 가능합니다. 확인바랍니다.";
					mbxCap = NetInfo.Language == LangMode.Jr ? "予定変更" : "예정변경";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
					checkValue = false;
				}
			}

			return checkValue;

		}

		/// <summary>
		/// 간호지시예정사항인 경우 중복여부를 check한다.
		/// </summary>
		/// <param name="aFkocs6010"></param>
		/// <param name="aModify_date"></param>
		/// <returns></returns>
		private bool GetCheckDupDirect(string aOrder_date, string aInput_gubun, int rowIndex)
		{
            bool checkValue = true;
            string cmdText  = "";
            object retVal   = null;

			//예정지시사항이 아닌경우 Skip
			if( this.dloItemData.GetItemString(rowIndex, "table_id") != "OCS6015" )
				return checkValue;

			string fkocs6010    = dloItemData.GetItemString(rowIndex, "fkocs6010"   );
			string direct_gubun = dloItemData.GetItemString(rowIndex, "order_gubun" );
			string direct_code  = dloItemData.GetItemString(rowIndex, "hangmog_code"); 

			//현재 重複のコードです。ご確認下さい。
			string filter = " order_date = '" + aOrder_date + "' and input_gubun = '" + aInput_gubun + "' and ";
            filter = filter + " order_gubun = '" + direct_gubun + "' and hangmog_code = '" + direct_code + "' ";

			if(dloItemData.LayoutTable.Select(filter, "").Length > 0)
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "重複の指示事項です。ご確認ください。" : "중복된 지시사항이 존재합니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "予定変更" : "예정변경";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				checkValue = false;
				return checkValue;
			}

			//현재 조회기간을 벗어나는 일자인 경우에는 back한다.
			if( int.Parse(DateTime.Parse(aOrder_date).ToString("yyyyMMdd")) < int.Parse(DateTime.Parse(dpkFrom_date.GetDataValue()).ToString("yyyyMMdd")) ||
				int.Parse(DateTime.Parse(aOrder_date).ToString("yyyyMMdd")) > int.Parse(DateTime.Parse(dpkTo_date.GetDataValue()).ToString("yyyyMMdd")) )
			{
				cmdText = ""
					+ " SELECT 'Y'     "
                    + "   FROM OCS6013 "
                    + "  WHERE HOSP_CODE    = '" + mHospCode    + "' "
					+ "    AND FKOCS6010    =  " + fkocs6010    + "  "
					+ "    AND ORDER_DATE   = '" + aOrder_date  + "' " 
					+ "    AND INPUT_GUBUN  = '" + aInput_gubun + "' "
					+ "    AND DIRECT_GUBUN = '" + direct_gubun + "' "
					+ "    AND DIRECT_CODE  = '" + direct_code  + "' ";

                retVal = Service.ExecuteScalar(cmdText);
                    
				if(!TypeCheck.IsNull(retVal) && retVal.ToString() == "Y")
				{
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "重複の指示事項です。ご確認ください。" : "중복된 지시사항이 존재합니다. 확인바랍니다.";
					mbxCap = NetInfo.Language == LangMode.Jr ? "予定変更" : "예정변경";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
					checkValue = false;
				}
			}

			return checkValue;


		}

		#endregion

		#region [환자정보 Load]

		private void pbxBunho_PatientSelected(object sender, System.EventArgs e)
		{
			SetBunho(pbxBunho.BunHo);
		}

		private void pbxBunho_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			InitialBunhoChange();
		}

		private void SetBunho(string aBunho)
		{
			string order_date = "";
			mIsJaewonYn = false;			
			
			if (TypeCheck.IsNull(aBunho)) 
			{						
				InitialBunhoChange();
				return;
			}
			
			order_date = dpkFrom_date.GetDataValue();

			this.mPatientInfo.Parameter.Clear();
			this.mPatientInfo.Parameter.Bunho = aBunho;
			this.mPatientInfo.Parameter.Gwa = "%";
			this.mPatientInfo.Parameter.Doctor = "%";
			this.mPatientInfo.Parameter.IOEGubun =   "I";     // 입원

            if (OpenParam != null && OpenParam.Contains("jaewon_yn"))
            {
                this.mPatientInfo.Parameter.JaewonFlag = OpenParam["jaewon_yn"].ToString();
                this.mPatientInfo.Parameter.NaewonKey = mFkinp1001.ToString();

                if(OpenParam["jaewon_yn"].ToString() == "N")
                      mIsJaewonYn = false;
                else
                      mIsJaewonYn = true;
            }
            else
            {
                this.mPatientInfo.Parameter.JaewonFlag = "Y";     // 재원상태
                mIsJaewonYn = true;
            }

			this.mPatientInfo.Parameter.NaewonDate = "";      // order_date

			if (!this.mPatientInfo.LoadPatientInfo(IHIS.OCS.PatientInfo.QueryMode.NawonFullInfo))
			{
				if (this.mPatientInfo.GetPatientInfo == null || TypeCheck.IsNull(this.mPatientInfo.GetPatientInfo["suname"]))
				{
					mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号入力に間違いがあります。 確認してください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
					XMessageBox.Show(mbxMsg, mbxCap);

					InitialBunhoChange();				
					return;
				}
				else
				{
					mFkinp1001 = LoadInpwon_list(aBunho);
					if(mFkinp1001 == 0)
					{
						InitialBunhoChange();	
						pbxBunho.SetPatientID("");
						return;
					}
					mBunho = aBunho;
				}
			}
			else
			{

				// 재원이면서 퇴원일자가 있는 경우는 가퇴원일자가 있는 환자입니다.
//                if (!TypeCheck.IsNull(this.mPatientInfo.GetPatientInfo["toiwon_date"].ToString()))
//                {				
//                    if (int.Parse(this.mPatientInfo.GetPatientInfo["toiwon_date"].ToString().Replace("/","")) < int.Parse(order_date.Replace("/","")))
//                    {
////						mbxMsg = NetInfo.Language == LangMode.Jr ? "[{0}]日付で仮退院されました。以前日付のみオーダ入力可能です。" : "[%s]일자로 가퇴원되었습니다. 이전일자로만 처방입력가능합니다.";
////						mbxMsg = String.Format(mbxMsg, this.mPatientInfo.GetPatientInfo["toiwon_date"].ToString());
////						XMessageBox.Show(mbxMsg, mbxCap);

//                        mFkinp1001 = LoadInpwon_list(aBunho);
//                        if(mFkinp1001 == 0)
//                        {
//                            InitialBunhoChange();
//                            pbxBunho.SetPatientID("");
//                            return;
//                        }
//                        mBunho = aBunho;
//                    }
//                }
//                else
//                {
					mFkinp1001  = int.Parse(mPatientInfo.GetPatientInfo["naewon_key"].ToString());
					mBunho      = mPatientInfo.GetPatientInfo["bunho"].ToString();
                //}
			}

            //if (OpenParam.Contains("jaewon_yn"))
            //{
            //    if (OpenParam["jaewon_yn"].ToString() == "N")
            //    {
            //        mFkinp1001 = int.Parse(OpenParam["fkinp1001"].ToString());
            //        mIsJaewonYn = false;
            //    }
            //}

			ShowData(false);
		}

		private void InitialBunhoChange()
		{
			mPatientInfo.ClearPatientInfo();
			mFkinp1001 = 0;
			mBunho = "";
			mIsJaewonYn = false;
			//Matrix Reset
			ClearMatrix();
			dloItemData.Reset();
			pnlProcessApplyPlan.Visible = false;
		}

		private int LoadInpwon_list(string aBunho)
		{
			int pkinp1001 = 0;
			
			//Tab page생성
			IHIS.Framework.MultiLayout layoutInpwonList = new MultiLayout();

			layoutInpwonList.Reset();
			layoutInpwonList.LayoutItems.Clear();
			layoutInpwonList.LayoutItems.Add("pkinp1001"  , DataType.String);
			layoutInpwonList.LayoutItems.Add("bunho"      , DataType.String);
			layoutInpwonList.LayoutItems.Add("ipwon_date" , DataType.Date  );
			layoutInpwonList.LayoutItems.Add("gwa"        , DataType.String);
			layoutInpwonList.LayoutItems.Add("gwa_name"   , DataType.String);
			layoutInpwonList.LayoutItems.Add("doctor"     , DataType.String);
			layoutInpwonList.LayoutItems.Add("doctor_name", DataType.String);			
			layoutInpwonList.LayoutItems.Add("gubun"      , DataType.String);
			layoutInpwonList.LayoutItems.Add("gubun_name" , DataType.String);
			layoutInpwonList.InitializeLayoutTable();

            layoutInpwonList.QuerySQL = " "
				+ " SELECT A.PKINP1001                       PKINP1001,     "
				+ "        A.BUNHO                           BUNHO,         "
				+ "        A.IPWON_DATE                      IPWON_DATE,    "
				+ "        A.GWA                             GWA,           "
				+ "        FN_BAS_LOAD_GWA_NAME(A.GWA, A.IPWON_DATE)        "
				+ "                                          GWA_NAME,      "
				+ "        A.DOCTOR                          DOCTOR,        "
				+ "        FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.IPWON_DATE)  "
				+ "                                          DOCTOR_NAME,   "				
				+ "        B.GUBUN                           GUBUN,         "
				+ "        FN_BAS_LOAD_GUBUN_NAME(B.GUBUN, A.IPWON_DATE)    "
				+ "                                          GUBUN_NAME     "
				+ "   FROM INP1002 B       ,                                "
				+ "        INP1001 A                                        "
                + "  WHERE A.HOSP_CODE = '" + mHospCode + "'                "
                + "    AND A.BUNHO     = '" + aBunho + "'                   "
				+ "    AND NVL(A.CANCEL_YN,'N') != 'Y'                      "
				+ "    AND A.PKINP1001 = B.FKINP1001                        "
                + "    AND A.HOSP_CODE = B.HOSP_CODE                        "
				+ "    AND B.SEQ       = (SELECT MAX(C.SEQ)                 "
				+ "                         FROM INP1002 C                  "
                + "                        WHERE C.HOSP_CODE = A.HOSP_CODE  "
                + "                          AND C.FKINP1001 = A.PKINP1001) ";

            if (layoutInpwonList.QueryLayout(false) && layoutInpwonList.LayoutTable != null)
			{
				if(layoutInpwonList.RowCount > 1)
				{
					frmInpwonList frm = new frmInpwonList();
					frm.INPWON_LIST   = layoutInpwonList;
					frm.ShowDialog();

					if(frm.DialogResult == DialogResult.OK)
					{
						int selectRow = frm.SELECT_ROW;
						pkinp1001 = layoutInpwonList.GetItemInt(selectRow, "pkinp1001");
					}
				}
				else
				{
                    if (layoutInpwonList.RowCount == 1)
                    {
                        pkinp1001 = layoutInpwonList.GetItemInt(0, "pkinp1001");
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "入院情報が存在しません。 ご確認ください。" : "입원정보가 존재하지않습니다. 확인바랍니다.";
                        XMessageBox.Show(mbxMsg, mbxCap);
                    }
				}				
			}
			else
			{
                mbxMsg = NetInfo.Language == LangMode.Jr ? "入院情報が存在しません。 ご確認ください。" : "입원정보가 존재하지않습니다. 확인바랍니다.";
				XMessageBox.Show(mbxMsg, mbxCap);
			}

			return pkinp1001;

		}
		
		#endregion

		#region [치료계획 Order발생]

		private void rbtAll_Click(object sender, System.EventArgs e)
		{
			if(rbtAll.Checked)
			{
                rbtAll.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
				rbtAll.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
				rbtAll.ImageIndex = 4;

				rbtPJ.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtPJ.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtPJ.ImageIndex = 3;  	
			
				rbtJusa.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtJusa.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtJusa.ImageIndex = 3;

                rbtSiksa.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtSiksa.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtSiksa.ImageIndex = 3;
			}
			else if(rbtPJ.Checked)
			{
				rbtPJ.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
				rbtPJ.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
				rbtPJ.ImageIndex = 4;

				rbtAll.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtAll.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtAll.ImageIndex = 3;  
				
				rbtJusa.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtJusa.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtJusa.ImageIndex = 3;

                rbtSiksa.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtSiksa.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtSiksa.ImageIndex = 3;
			}
            else if (rbtJusa.Checked)
            {
                rbtJusa.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
                rbtJusa.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                rbtJusa.ImageIndex = 4;

                rbtAll.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtAll.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtAll.ImageIndex = 3;

                rbtPJ.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtPJ.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtPJ.ImageIndex = 3;

                rbtSiksa.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtSiksa.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtSiksa.ImageIndex = 3;
            }
            else
            {
                rbtSiksa.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
                rbtSiksa.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                rbtSiksa.ImageIndex = 4;

                rbtJusa.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtJusa.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtJusa.ImageIndex = 3;

                rbtAll.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtAll.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtAll.ImageIndex = 3;

                rbtPJ.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtPJ.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtPJ.ImageIndex = 3;
            }
		
		}

        /// <summary>
        /// Show시 적용일자 Setting
        /// </summary>
		private void pnlProcessApplyPlan_VisibleChanged(object sender, System.EventArgs e)
		{
			if(pnlProcessApplyPlan.Visible)
			{
				dApp_From_date.SetDataValue(dpkFrom_date.GetDataValue());
				dtpApp_To_date.SetDataValue( DateTime.Parse(dpkFrom_date.GetDataValue()).AddDays(6));
				dApp_From_date.Focus();
				dApp_From_date.SelectAll();
			}		
		}
        
		/// <summary>
		/// 치료계획 적용 pannel을 Show하거나 hide한다.
		/// </summary>
		private void btnShowProcessPlan_Click(object sender, System.EventArgs e)
		{
			if(!mIsJaewonYn) return;

			if(pnlProcessApplyPlan.Visible)
				pnlProcessApplyPlan.Visible = false;				
			else
			{
				pnlProcessApplyPlan.Visible = true;
				pnlProcessApplyPlan.BringToFront();
			}
		}

		private void btnProcessPlanClose_Click(object sender, System.EventArgs e)
		{
			pnlProcessApplyPlan.Visible = false;		
		}

		#region [치료계획적용]

		private void btnProcessPlan_Click(object sender, System.EventArgs e)
		{
			if(TypeCheck.IsNull(dbxConfirmUserName.GetDataValue()))
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "看護確認IDが正しくありません。 ご確認ください。" : "간호확인 ID가 정확하지않습니다. 확인바랍니다.";						
				XMessageBox.Show(mbxMsg, mbxCap);
				txtConfirmUser.Focus();
				txtConfirmUser.SelectAll();
				return;
			}

            //if(!rbtSiksa.Checked)
			    ProcessApplyPlanOrder();
            //else

		}

		private bool SetInvalue()
		{
			bool returnValue = true;

			dloProcessInfo.Reset();
			dloProcessInfo.InsertRow(-1);

			if(!mIsJaewonYn) return false;

			if(mPatientInfo.GetPatientInfo == null)
			{				
				mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号に誤りがあります。 ご確認ください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap);
				return false;
			}

			dloProcessInfo.SetItemValue(0, "bunho", mPatientInfo.GetPatientInfo["bunho"].ToString());
			dloProcessInfo.SetItemValue(0, "fkinp1001", mPatientInfo.GetPatientInfo["naewon_key"].ToString());
            
			if(!TypeCheck.IsDateTime(dApp_From_date.GetDataValue()) )
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "適用開始日に誤りがあります。 ご確認ください。" : "적용시작일이 정확하지않습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap);
				dApp_From_date.Focus();
				dApp_From_date.SelectAll();
				returnValue = false;
				return returnValue;
			}
            
			dloProcessInfo.SetItemValue(0, "from_date", dApp_From_date.GetDataValue() );

			if(!TypeCheck.IsDateTime(dtpApp_To_date.GetDataValue()) )
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "適用終了日に誤りがあります。 ご確認ください。" : "적용종료일이 정확하지않습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap);
				dtpApp_To_date.Focus();
				dtpApp_To_date.SelectAll();
				returnValue = false;
				return returnValue;
			}

			dloProcessInfo.SetItemValue(0, "to_date"  , dtpApp_To_date.GetDataValue() );

			if(rbtAll.Checked)
				dloProcessInfo.SetItemValue(0, "pkocs6013"  , "0" );
			else if(this.rbtPJ.Checked)
				dloProcessInfo.SetItemValue(0, "pkocs6013"  , "1" );
			else
				dloProcessInfo.SetItemValue(0, "pkocs6013"  , "2" );

			dloProcessInfo.SetItemValue(0, "user_id"  , this.txtConfirmUser.GetDataValue().Trim() );

			return returnValue;
		}

		private void ProcessApplyPlanOrder()
		{
			if(!SetInvalue()) return;

            if (DayApplyOCS6013())
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "処理が完了しました。" : "처리가 완료되었습니다.";
				SetMsg(mbxMsg);
				pnlProcessApplyPlan.Visible = false;

				mScrollPoint = mtxPlanMgt.AutoScrollPosition;
				ShowData(false);
				PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));
			}
		}

		#region [Order group 별 치료계획 실행]

        private bool SetInvalueOrderGroup(string menuItemIndex)
		{
			bool returnValue = true;

			dloProcessInfo1.Reset();
			dloProcessInfo1.InsertRow(-1);
			
			foreach(object obj in htSelectItem.Keys)
			{			
				dloProcessInfo1.SetItemValue(0, "bunho"      , this.dloItemData.GetItemString(int.Parse(obj.ToString()), "bunho"      ));
				dloProcessInfo1.SetItemValue(0, "fkinp1001"  , this.dloItemData.GetItemString(int.Parse(obj.ToString()), "fkinp1001"  ));
				dloProcessInfo1.SetItemValue(0, "fkocs6010"  , this.dloItemData.GetItemString(int.Parse(obj.ToString()), "fkocs6010"  ));
				dloProcessInfo1.SetItemValue(0, "plan_date"  , this.dloItemData.GetItemString(int.Parse(obj.ToString()), "order_date" ));
				dloProcessInfo1.SetItemValue(0, "input_gubun", this.dloItemData.GetItemString(int.Parse(obj.ToString()), "input_gubun"));
				dloProcessInfo1.SetItemValue(0, "user_id"    , this.txtConfirmUser.GetDataValue().Trim() );
                if (menuItemIndex == "7")   // CP 그룹별 시행
                {
                    dloProcessInfo1.SetItemValue(0, "order_gubun", this.dloItemData.GetItemString(int.Parse(obj.ToString()), "order_gubun"));
                    dloProcessInfo1.SetItemValue(0, "group_ser", this.dloItemData.GetItemString(int.Parse(obj.ToString()), "group_ser"));
                }
                else if(menuItemIndex == "10")  // CP 당일 전체 시행
                {
                    dloProcessInfo1.SetItemValue(0, "group_ser", "%");
                    dloProcessInfo1.SetItemValue(0, "order_gubun", "%");
                }

				break;
			}
			
			return returnValue;
		}

        private void ProcessApplyPlanOrderGroup(string menuItemIndex)
		{
            if (!SetInvalueOrderGroup(menuItemIndex)) return;

            if (ApplyOCS6013())
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "処理が完了しました。" : "처리가 완료되었습니다.";
				SetMsg(mbxMsg);
				
				mScrollPoint = mtxPlanMgt.AutoScrollPosition;
				ShowData(false);
				PostCallHelper.PostCall(new PostMethod(this.PostSetScrollPoint));
			}
			else
			{
				mbxMsg = "処理が失敗しました。"; 
				mbxMsg = mbxMsg + Service.ErrMsg;
				mbxCap = "保存エラー";
				XMessageBox.Show(mbxMsg, mbxCap);
			}
		}

		#endregion

		#endregion
		

		#endregion

		#region [Item Multi 선택]
		private void SelectMutiItem()
		{
			ClearSelectItem();

			if(this.mtxPlanMgt.SelectedItems.Count < 1) return;

			if( TypeCheck.IsNull(mtxPlanMgt.SelectedItems[0].Tag) )
			{
				mtxPlanMgt.UnSelectAll();
				return;
			}				
           
			if( TypeCheck.IsNull(mtxPlanMgt.SelectedItems[0].Tag) || 
				( dloItemData.GetItemString(int.Parse(mtxPlanMgt.SelectedItems[0].Tag.ToString()), "table_id") != "OCS2003"  &&
				  dloItemData.GetItemString(int.Parse(mtxPlanMgt.SelectedItems[0].Tag.ToString()), "table_id") != "OCS6013") )
				return;
			
			string table_id    = dloItemData.GetItemString(int.Parse(mtxPlanMgt.SelectedItems[0].Tag.ToString()), "table_id");
			string order_date  = mtxPlanMgt.SelectedItems[0].ColKey.Substring(0, 4) + "/" + mtxPlanMgt.SelectedItems[0].ColKey.Substring(4, 2) + "/" + mtxPlanMgt.SelectedItems[0].ColKey.Substring(6, 2);
			string input_gubun = mtxPlanMgt.SelectedItems[0].ColKey.Substring(8, 2);
			string fkocs6010   = dloItemData.GetItemString(int.Parse(mtxPlanMgt.SelectedItems[0].Tag.ToString()), "fkocs6010"  );
			string order_gubun = dloItemData.GetItemString(int.Parse(mtxPlanMgt.SelectedItems[0].Tag.ToString()), "order_gubun");
			string group_ser   = dloItemData.GetItemString(int.Parse(mtxPlanMgt.SelectedItems[0].Tag.ToString()), "group_ser"  );
            string input_doctor= dloItemData.GetItemString(int.Parse(mtxPlanMgt.SelectedItems[0].Tag.ToString()), "input_doctor");
			
			int itemIndex = 0;
			for(int i = 0; i < dloItemData.RowCount; i++)
			{
				//삭제 Data Skip
				if(dloItemData.GetItemString(i, "notlayout") == "Y") continue;
                
				//if(dloItemData.GetItemString(i, "can_plan_change_yn") == "Y") continue;

				if( table_id     == dloItemData.GetItemString(i, "table_id"   ) &&
					order_date   == dloItemData.GetItemString(i, "order_date" ) &&
					input_gubun  == dloItemData.GetItemString(i, "input_gubun") &&
					order_gubun  == dloItemData.GetItemString(i, "order_gubun") &&
					fkocs6010    == dloItemData.GetItemString(i, "fkocs6010"  ) &&
					group_ser    == dloItemData.GetItemString(i, "group_ser"  ) &&
                    input_doctor == dloItemData.GetItemString(i, "input_doctor"))
					htSelectItem.Add(i, mtxPlanMgt.Items[itemIndex]);

				itemIndex++;
			}

			SelectItemBackColorChanging();
		}

		#endregion

		#region [Group Mastrix item 처리]
        
		//Item선택시 같은 그룹 Item 선택처리
		private void SelectItemBackColorChanging()
		{	
			mtxPlanMgt.SuspendLayout();
			foreach (XMatrixItem item in mtxPlanMgt.Items)
			{
				if( TypeCheck.IsNull(item.Tag) ) continue;

				//if(htSelectItem.ContainsKey(int.Parse(item.Tag.ToString())) && (mtxPlanMgt.SelectedItems.Count > 0 && item.Tag.ToString() !=  mtxPlanMgt.SelectedItems[0].Tag.ToString()))
                if (htSelectItem.ContainsKey(int.Parse(item.Tag.ToString())))
                    item.BackColor = Color.FromArgb(125, XColor.XCalendarSelectedDateBackColor.Color);
                else
                    item.BackColor = XColor.XMatrixItemBackColor.Color;	
			}

			mtxPlanMgt.Setup(true);
			mtxPlanMgt.ResumeLayout();
		}
        
		//선택해제
		private void ClearSelectItem()
		{
			htSelectItem.Clear();
            
			mtxPlanMgt.SuspendLayout();
            foreach (XMatrixItem item in mtxPlanMgt.Items)
                item.BackColor = XColor.XMatrixItemBackColor.Color;	
			mtxPlanMgt.Setup(true);
			mtxPlanMgt.ResumeLayout();
		}

		private void MoveSelectItem(string modifyColKey, string modifyOrder_date, string modifyInput_gubun)
		{
			foreach( object obj in htSelectItem.Values)
			{
				((XMatrixItem)obj).ColKey = modifyColKey;
				if(dloItemData.GetItemString( int.Parse(((XMatrixItem)obj).Tag.ToString()), "can_plan_change_yn") == "N") continue;

				dloItemData.SetItemValue( int.Parse(((XMatrixItem)obj).Tag.ToString()), "order_date" , modifyOrder_date );
				//dloItemData.SetItemValue( int.Parse(((XMatrixItem)obj).Tag.ToString()), "input_gubun", modifyInput_gubun);
			}
		}
		#endregion

		#region [Post ScrollPoint]
		private Point mScrollPoint;
		private void PostSetScrollPoint()
		{
			mtxPlanMgt.AutoScrollPosition = new Point(mScrollPoint.X * -1, mScrollPoint.Y * -1);
		}
		#endregion

		#region [간호확인사용자]
		private void txtConfirmUser_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			dbxConfirmUserName.SetDataValue("");

			if( TypeCheck.IsNull(e.DataValue) )
			{
				txtConfirmUser.SetDataValue("");
			}
			
			string user_nm = GetAdminUSER_NAME(e.DataValue);

			if( TypeCheck.IsNull(user_nm) )
			{
				txtConfirmUser.SetDataValue("");
				txtConfirmUser.Focus();
				txtConfirmUser.SelectAll();
				return;
			}

			dbxConfirmUserName.SetDataValue(user_nm);
		}

		private string GetAdminUSER_NAME(string aUser_id)
		{
			string user_name = "";
            string cmdText = "";
            DataTable dtResult = new DataTable();

			cmdText = ""
				+ " SELECT USER_NM, FN_PPE_LOAD_CONFIRM_ENABLE(USER_ID) CONFIRM_GRANT"
				+ "   FROM ADM3200   "
				+ "  WHERE HOSP_CODE = '" + mHospCode + "' "
                + "    AND USER_ID   = '" + aUser_id + "' ";
            dtResult = Service.ExecuteDataTable(cmdText);
                    
			if(Service.ErrCode == 0 &&  !TypeCheck.IsNull(dtResult))
			{
                if (dtResult.Rows[0]["confirm_grant"].ToString() != "Y")
				{
					mbxMsg = NetInfo.Language == LangMode.Jr ? "オーダ確認権限がありません。確認してください。" : "오더확인권한이 없습니다. 확인바랍니다.";
					mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
					return user_name;

				}
				user_name = dtResult.Rows[0]["user_nm"].ToString();				
			}


			return user_name;
		}

		private void btnClearConfirmUser_Click(object sender, System.EventArgs e)
		{
			txtConfirmUser.SetDataValue("");
			dbxConfirmUserName.SetDataValue("");
		}

		#endregion

		#region [의사지시서 출력]

		private void LoadOrderPrint(int rowIndex)
		{
			if( rowIndex < 0 ) return;

			string pgm_id = LoadPrintPGM_ID(dloItemData.GetItemString(rowIndex, "table_id"), dloItemData.GetItemString(rowIndex, "pk"));

			switch (pgm_id)
			{
				case "OCS2003R00":

					try
				    {
                        CommonItemCollection openParams = new CommonItemCollection();
                        openParams.Add("bunho", dloItemData.GetItemString(rowIndex, "bunho"));
                        openParams.Add("fkinp1001", dloItemData.GetItemString(rowIndex, "fkinp1001"));
                        openParams.Add("order_date", dloItemData.GetItemString(rowIndex, "source_order_date"));
                        openParams.Add("input_gubun", "NR"); // 의사처방 전체 조회
                        //openParams.Add("input_gubun", "D%"); // 의사처방 전체 조회
                        openParams.Add("auto_close", false); // 출력후 닫기

                        openParams.Add("gwa", dloItemData.GetItemString(rowIndex, "input_gwa"));
                        openParams.Add("doctor", dloItemData.GetItemString(rowIndex, "input_doctor"));

                        XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003R00", ScreenOpenStyle.ResponseSizable, openParams);
					}
					catch{}
          
					break;

				case "OCS6013R00":

					try
					{
						CommonItemCollection openParams = new CommonItemCollection();
						openParams.Add("pkocs6010"  , dloItemData.GetItemString(rowIndex, "fkocs6010"));
						openParams.Add("jaewonil"   , dloItemData.GetItemString(rowIndex, "jaewonil" ));
						openParams.Add("auto_close" , false); // 출력후 닫기

						XScreen.OpenScreenWithParam(this, "OCSI", "OCS6013R00", ScreenOpenStyle.ResponseSizable, openParams);
					}
					catch{}
          
					break;

				case "OCS6017R00":

					try
					{
						CommonItemCollection openParams = new CommonItemCollection();
						openParams.Add("bunho",       dloItemData.GetItemString(rowIndex, "bunho"    ));
						openParams.Add("fkinp1001"  , dloItemData.GetItemString(rowIndex, "fkinp1001"));
						openParams.Add("input_gubun", "NR" );	 // 의사처방 전체 조회
						openParams.Add("auto_close" , false); // 출력후 닫기
						openParams.Add("order_date"  , dloItemData.GetItemString(rowIndex, "source_order_date"));

						XScreen.OpenScreenWithParam(this, "OCSI", "OCS6017R00", ScreenOpenStyle.ResponseSizable, openParams);
					}
					catch{}
          
					break;
				
				default:
					break;
			}


		}

		private string LoadPrintPGM_ID(string aTable_id, string aPkOrder)
		{
			string pgm_id  = "";
            string cmdText = "";
            object retVal  = null;
            
            cmdText = ""
				+ " SELECT FN_OCS_LOAD_ORDER_PRT_PGM_ID('" + aTable_id + "', " + aPkOrder + ") "
				+ "   FROM DUAL ";
            retVal = Service.ExecuteScalar(cmdText);
                    
			if( Service.ErrCode == 0 && !TypeCheck.IsNull(retVal.ToString().Trim()) )
                pgm_id = retVal.ToString();

			return pgm_id;
		}
		#endregion

		#region [row, col title Fixed 처리]
		
		private void pnlPosition_Move(object sender, System.EventArgs e)
		{
			mtxPlanMgt.SuspendLayout();
			try
			{
				if( pnlRowTitle != null )
				{
					pnlColTitle.SetBounds(pnlColTitle.Location.X, 0, 
						pnlColTitle.Size.Width, pnlColTitle.Size.Height);

					pnlRowTitle.SetBounds(0, pnlRowTitle.Location.Y, 
						                  pnlRowTitle.Size.Width, pnlRowTitle.Size.Height);
				}
			}
			catch {}

			mtxPlanMgt.ResumeLayout();
		
		}

		#endregion

        #region [ Custom Method ]

        #region // LoadDetailData() //
        /// <summary>
        /// Data Service PC : OCS6010U10, Service Name : OCS6010U10_LoadDetailData 
        /// </summary>
        /// <param name="aBunho"></param>
        /// <param name="aFkinp1001"></param>
        /// <param name="aFromDate"></param>
        /// <param name="aToDate"></param>
        /// <param name="aOrderGubun"></param>
        /// <returns></returns>
        private bool LoadDetailData(string aBunho, string aFkinp1001, string aFromDate, string aToDate,  string aOrderGubun)
        {
            dloItemData.Reset();

            #region // Variables for Query
            string cmdText = "";
            DataTable dtResult = new DataTable();
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_bunho",       aBunho);
            bindVars.Add("f_fkinp1001",   aFkinp1001);
            bindVars.Add("f_from_date",   aFromDate);
            bindVars.Add("f_to_date",     aToDate);
            bindVars.Add("f_order_gubun", aOrderGubun);
            bindVars.Add("f_hosp_code",   mHospCode);

            bindVars.Add("f_emergency_treat", this.btnEmergencyTreatDisplayYN.ImageIndex == 3 ? "N" : "Y");
            bindVars.Add("f_comment_yn", this.btnCommentOnOff.ImageIndex == 3 ? "N" : "Y");
            bindVars.Add("f_remark_yn", this.btnRemarkOnOff.ImageIndex == 3 ? "N" : "Y");

            if (UserInfo.Gwa == "CK")
                bindVars.Add("f_instead_order_display_yn", "Y");
            else
                bindVars.Add("f_instead_order_display_yn", "N");

            object retVal = null;



            #region [ Original Query ]
            /*
            cmdText = @"SELECT A.BUNHO             ,
       A.FKINP1001         ,
       A.FKOCS6010         ,
       A.CP_NAME           ,
       TO_CHAR(A.ORDER_DATE, 'YYYY/MM/DD')     ORDER_DATE ,
       TO_CHAR(A.ORDER_END_DATE, 'YYYY/MM/DD') ORDER_END_DATE,
       A.INPUT_GUBUN       ,
       A.INPUT_GUBUN_NAME  ,
       A.ORDER_GUBUN       ,
       A.ORDER_GUBUN_NAME  ,
       A.HANGMOG_CODE      ,
       A.HANGMOG_NAME      ,
       A.SURYANG           ,
       A.NALSU             ,
       A.DETAIL            ,
       A.ORDER_REMARK      ,
       A.NURSE_REMARK      ,
       A.TEL_YN            ,
       A.EMERGENCY         ,
       A.JUSA_NAME         ,
       A.BOGYONG_NAME      ,
       A.JAEWONIL          ,
       A.PK                ,
       A.GROUP_SER         ,
       A.MIX_GROUP         ,
       A.TABLE_ID          ,
       A.CONFIRM_YN        ,
       A.ACTING_YN         ,
       A.CAN_PLAN_CHANGE_YN,
       A.CAN_CONFIRM_YN    ,
       A.CAN_ACTING_YN     ,
       A.CAN_PLAN_APP_YN   ,
       A.INPUT_NAME        ,
       A.INPUT_SEQ         ,
       A.ORDER_END_YN      ,
       A.CONFIRM_NAME      ,
       A.DETAIL_ACT_YN     ,
       A.BULYONG_CHECK     ,
       A.NURSE_HOLD_USER   ,
       A.INPUT_GWA         ,
       A.INPUT_DOCTOR      ,
       A.RESER_DATE,--TO_CHAR(A.RESER_DATE, 'YYYY/MM/DD')  RESER_DATE,
       A.ACTING_DATE,--TO_CHAR(A.ACTING_DATE, 'YYYY/MM/DD') ACTING_DATE,
       A.JUNDAL_TABLE      ,
       A.JUNDAL_PART       ,
       A.OCS_FLAG          ,
       TO_CHAR(A.SOURCE_ORDER_DATE, 'YYYY/MM/DD') SOURCE_ORDER_DATE,
       A.CONTINUE_YN       ,
       A.JISI_ORDER_GUBUN  ,
       A.DIRECT_CONT       ,
       A.PKOCS2005         ,
       A.PKOCS6015         ,
       A.INPUT_ID
FROM ( SELECT A.BUNHO                                       BUNHO             ,
               A.FKINP1001                                   FKINP1001         ,
               0                                             FKOCS6010         ,
               NULL                                          CP_NAME           ,
               F.HOLI_DAY                                    ORDER_DATE        ,
               CASE WHEN DECODE(A.DRT_FROM_DATE, NULL, A.ORDER_DATE, NVL(A.DRT_TO_DATE, TO_DATE('99981231', 'YYYYMMDD'))) >= TO_DATE('2011/12/26', 'YYYY/MM/DD') THEN  TO_DATE('2011/12/26', 'YYYY/MM/DD')
               ELSE DECODE(A.DRT_FROM_DATE, NULL, A.ORDER_DATE, NVL(A.DRT_TO_DATE, TO_DATE('99981231', 'YYYYMMDD')))
               END                                           ORDER_END_DATE    ,
               A.INPUT_GUBUN                                 INPUT_GUBUN       ,
               E.CODE_NAME                                   INPUT_GUBUN_NAME  ,
               A.DIRECT_GUBUN                                ORDER_GUBUN       ,
               B.NUR_GR_NAME                                 ORDER_GUBUN_NAME  ,
               A.DIRECT_CODE                                 HANGMOG_CODE      ,
               C.NUR_MD_NAME                                 HANGMOG_NAME      ,
               1                                             SURYANG           ,
               1                                             NALSU             ,
               TRIM(A.DIRECT_TEXT    )                       DETAIL            ,
               FN_OCSI_LOAD_DIRECT_ACT_RESULT(A.BUNHO, A.FKINP1001, F.HOLI_DAY, A.INPUT_GUBUN, A.PK_SEQ)      ORDER_REMARK ,
               NULL                                          NURSE_REMARK      ,
               'N'                                           TEL_YN            ,
               'N'                                           EMERGENCY         ,
               ' '                                           JUSA_NAME         ,
               ' '                                           BOGYONG_NAME      ,
               0                                             JAEWONIL          ,
               A.PK_SEQ                                      PK                ,
               1                                             GROUP_SER         ,
               NULL                                          MIX_GROUP         ,
               'OCS2005'                                     TABLE_ID          ,
               'N'                                           CONFIRM_YN        ,
               DECODE(C.ACTING_YN, 'Y', DECODE(FN_OCSI_LOAD_DIRECT_ACT_ID(A.BUNHO, A.FKINP1001, A.ORDER_DATE, A.INPUT_GUBUN, F.HOLI_DAY, A.PK_SEQ), NULL, 'N', 'Y'), 'Y')
                                                             ACTING_YN         ,
               'N'                                           CAN_PLAN_CHANGE_YN,
               'N'                                           CAN_CONFIRM_YN    ,
               DECODE(C.ACTING_YN, 'Y', 'Y', 'N')            CAN_ACTING_YN     ,
               'N'                                           CAN_PLAN_APP_YN   ,
               FN_ADM_USER_NM(A.INPUT_ID)                    INPUT_NAME        ,
               NVL(E.SORT_KEY, 99)                           INPUT_SEQ         ,
               'N'                                           ORDER_END_YN      ,
               NULL                                          CONFIRM_NAME      ,
               'N'                                           DETAIL_ACT_YN     ,
               'N'                                           BULYONG_CHECK     ,
               ' '                                           NURSE_HOLD_USER   ,
               A.INPUT_GWA                                   INPUT_GWA         ,
               A.INPUT_DOCTOR                                INPUT_DOCTOR      ,
               NULL                                          RESER_DATE        ,
               F.HOLI_DAY                                    ACTING_DATE       ,
               ' '                                           JUNDAL_TABLE      ,
               ' '                                           JUNDAL_PART       ,
               '0'                                           OCS_FLAG          ,
               A.ORDER_DATE                                  SOURCE_ORDER_DATE ,
               A.CONTINUE_YN                                 CONTINUE_YN       ,
/*
               '0'||A.DIRECT_GUBUN||A.DIRECT_CODE||TO_CHAR(A.ORDER_DATE, 'YYYYMMDD')||TO_CHAR(E.SORT_KEY)||A.INPUT_GUBUN
                                                             CONT_KEY          ,
* /

               DECODE(A.DIRECT_GUBUN, '02',
               '0'||A.DIRECT_GUBUN||'000'||SUBSTR(A.DIRECT_CODE, 4, 1)||TO_CHAR(A.ORDER_DATE, 'YYYYMMDD')||TO_CHAR(E.SORT_KEY)||A.INPUT_GUBUN ,
               '0'||A.DIRECT_GUBUN||A.DIRECT_CODE||TO_CHAR(A.ORDER_DATE, 'YYYYMMDD')||TO_CHAR(E.SORT_KEY)||A.INPUT_GUBUN ) CONT_KEY,

               C.JISI_ORDER_GUBUN                            JISI_ORDER_GUBUN  ,
               A.DIRECT_CONT1                                DIRECT_CONT
             , A.PKOCS2005                                   PKOCS2005
             , NVL(A.FKOCS6015, 0)                           PKOCS6015
             , A.INPUT_ID   INPUT_ID
          FROM OCS2005 A,
               NUR0110 B,
               NUR0111 C,
               OCS0132 E,
               RES0101 F
         WHERE ( NVL('%', '%') = '%' OR NVL('%', '%') = '0')
           AND A.BUNHO          = '000026869'
           AND A.FKINP1001      = '1605981'

           AND ('2011/12/20' BETWEEN NVL(A.DRT_FROM_DATE, A.ORDER_DATE)
                                AND DECODE(A.DRT_FROM_DATE, NULL, A.ORDER_DATE, NVL(A.DRT_TO_DATE, TO_DATE('99981231', 'YYYYMMDD')))
                OR NVL(A.DRT_FROM_DATE, A.ORDER_DATE) >= '2011/12/20' )

           AND F.HOLI_DAY BETWEEN NVL(A.DRT_FROM_DATE, A.ORDER_DATE)
                                AND DECODE(A.DRT_FROM_DATE, NULL, A.ORDER_DATE, NVL(A.DRT_TO_DATE, TO_DATE('99981231', 'YYYYMMDD')))
           AND F.HOSP_CODE      = A.HOSP_CODE
           AND F.HOLI_DAY      <= '2011/12/26'
           AND F.HOLI_DAY BETWEEN '2011/12/20' AND '2011/12/26'
           AND A.HOSP_CODE      = 'XXX'
           AND B.NUR_GR_CODE    = A.DIRECT_GUBUN
           AND B.HOSP_CODE      = A.HOSP_CODE
           AND C.NUR_GR_CODE    = A.DIRECT_GUBUN
           AND C.NUR_MD_CODE    = A.DIRECT_CODE
           AND C.HOSP_CODE      = A.HOSP_CODE
           AND E.CODE_TYPE      = 'INPUT_GUBUN'
           AND E.CODE           = A.INPUT_GUBUN
           AND E.HOSP_CODE      = A.HOSP_CODE
        UNION ALL
        SELECT A.BUNHO                                       BUNHO             ,
               A.FKINP1001                                   FKINP1001         ,
               B.FKOCS6010                                   FKOCS6010         ,
               NULL                                          CP_NAME           ,
               F.HOLI_DAY                                    ORDER_DATE        ,
               NVL(B.PLAN_TO_DATE, TO_DATE('99991231', 'YYYYMMDD'))
                                                             ORDER_END_DATE    ,
               B.INPUT_GUBUN                                 INPUT_GUBUN       ,
               E.CODE_NAME                                   INPUT_GUBUN_NAME  ,
               B.DIRECT_GUBUN                                ORDER_GUBUN       ,
               C.NUR_GR_NAME                                 ORDER_GUBUN_NAME  ,
               B.DIRECT_CODE                                 HANGMOG_CODE      ,
               D.NUR_MD_NAME                                 HANGMOG_NAME      ,
               1                                             SURYANG           ,
               1                                             NALSU             ,
               TRIM(B.DIRECT_TEXT)                           DETAIL            ,
               NULL                                          ORDER_REMARK      ,
               NULL                                          NURSE_REMARK      ,
               'N'                                           TEL_YN            ,
               'N'                                           EMERGENCY         ,
               ' '                                           JUSA_NAME         ,
               ' '                                           BOGYONG_NAME      ,
               B.JAEWONIL                                    JAEWONIL          ,
               B.PK_SEQ                                      PK                ,
               1                                             GROUP_SER         ,
               NULL                                          MIX_GROUP         ,
               'OCS6015'                                     TABLE_ID          ,
               'N'                                           CONFIRM_YN        ,
               --'N'                                           ACTING_YN         , -- 20110217
               DECODE(D.ACTING_YN, 'Y', DECODE(FN_OCSI_LOAD_OCS6015_ACT_ID(B.PKOCS6015, F.HOLI_DAY), NULL, 'N', 'Y'), 'Y')
                                                             ACTING_YN         ,
               DECODE(SIGN(B.PLAN_FROM_DATE - NVL(B.PLAN_TO_DATE, TO_DATE('99991231', 'YYYYMMDD'))), -1 , 'N', 'Y')
                                                             CAN_PLAN_CHANGE_YN,
               'N'                                           CAN_CONFIRM_YN    ,
               DECODE(D.ACTING_YN, 'Y', 'Y', 'N')            CAN_ACTING_YN     ,
               --'N'                                           CAN_ACTING_YN     , -- 20110217
               'N'                                           CAN_PLAN_APP_YN   ,
               FN_ADM_USER_NM(B.INPUT_ID)                    INPUT_NAME        ,
               NVL(E.SORT_KEY, 99)                           INPUT_SEQ         ,
               'N'                                           ORDER_END_YN      ,
               NULL                                          CONFIRM_NAME      ,
               'N'                                           DETAIL_ACT_YN     ,
               'N'                                           BULYONG_CHECK     ,
               ' '                                           NURSE_HOLD_USER   ,
               ' '                                           INPUT_GWA         ,
               ' '                                           INPUT_DOCTOR      ,
               NULL                                          RESER_DATE        ,
               NULL                                          ACTING_DATE       ,
               ' '                                           JUNDAL_TABLE      ,
               ' '                                           JUNDAL_PART       ,
               '0'                                           OCS_FLAG          ,
               B.PLAN_FROM_DATE                              SOURCE_ORDER_DATE ,
               B.CONTINUE_YN                                 CONTINUE_YN       ,
               '0'||B.DIRECT_GUBUN||B.DIRECT_CODE||TO_CHAR(B.PLAN_FROM_DATE, 'YYYYMMDD')||TO_CHAR(E.SORT_KEY)||B.INPUT_GUBUN
                                                             CONT_KEY
             , D.JISI_ORDER_GUBUN                            JISI_ORDER_GUBUN
             , B.DIRECT_DETAIL                               DIRECT_CONT
             , 0                                             PKOCS2005
             , B.PKOCS6015                                   PKOCS6015
             , B.INPUT_ID   INPUT_ID
          FROM OCS6010 A,
               OCS6015 B,
               NUR0110 C,
               NUR0111 D,
               OCS0132 E,
               RES0101 F
         WHERE ( NVL('%', '%') = '%' OR NVL('%', '%') = '0')
           AND '2011/12/26'          > TRUNC(SYSDATE)
           AND A.BUNHO              = '000026869'
           AND A.FKINP1001          = '1605981'
           AND A.HOSP_CODE          = 'XXX'
           AND NVL(A.CP_END_YN, 'N') = 'N'
           AND B.FKOCS6010          = A.PKOCS6010
           AND B.HOSP_CODE          = A.HOSP_CODE
           AND B.PLAN_FROM_DATE    <= '2011/12/26'
           AND NVL(B.PLAN_TO_DATE, TO_DATE('99991231', 'YYYYMMDD'))
                                   >= DECODE(SIGN( TO_DATE('2011/12/20', 'YYYY/MM/DD') - TRUNC(SYSDATE)), 1, TO_DATE('2011/12/20', 'YYYY/MM/DD')
                                                                                                           , TRUNC(SYSDATE ))-- + 1)
           AND C.NUR_GR_CODE        = B.DIRECT_GUBUN
           AND C.HOSP_CODE          = B.HOSP_CODE
           AND D.NUR_GR_CODE        = B.DIRECT_GUBUN
           AND D.NUR_MD_CODE        = B.DIRECT_CODE
           AND D.HOSP_CODE          = B.HOSP_CODE
           AND E.CODE_TYPE          = 'INPUT_GUBUN'
           AND E.CODE               = B.INPUT_GUBUN
           AND E.HOSP_CODE          = B.HOSP_CODE
           
           AND F.HOLI_DAY BETWEEN NVL(B.PLAN_FROM_DATE, TRUNC(SYSDATE))
                                AND DECODE(B.PLAN_FROM_DATE, NULL, TRUNC(SYSDATE), NVL(B.PLAN_TO_DATE, TO_DATE('99981231', 'YYYYMMDD')))
           AND F.HOSP_CODE      = A.HOSP_CODE
           AND F.HOLI_DAY      <= '2011/12/26'
           AND F.HOLI_DAY BETWEEN '2011/12/20' AND '2011/12/26'

           AND NOT EXISTS(  SELECT 'X'
                              FROM OCS2005
                             WHERE BUNHO = A.BUNHO
                               AND FKINP1001 = A.FKINP1001
                               AND ORDER_DATE = F.HOLI_DAY
                               AND FKOCS6015  = B.PKOCS6015 )
        UNION ALL
        SELECT A.BUNHO                                       BUNHO             ,
               A.FKINP1001                                   FKINP1001         ,
               0                                             FKOCS6010         ,
               NULL                                          CP_NAME           ,


               (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')
                     THEN NVL(A.ACTING_DATE, NVL(A.RESER_DATE, A.ORDER_DATE))
                     WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('B', 'C', 'D')
                     THEN I.HOLI_DAY
                     ELSE NVL(A.RESER_DATE, A.ORDER_DATE)
               END )                                         ORDER_DATE        ,
               (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')
                     THEN NVL(A.ACTING_DATE, NVL(A.RESER_DATE, A.ORDER_DATE))
                     WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('B', 'C', 'D')
                     THEN I.HOLI_DAY
                     ELSE NVL(A.RESER_DATE, A.ORDER_DATE)
               END )                                         ORDER_END_DATE    ,

/*****************************
               (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')
                     THEN NVL(A.ACTING_DATE, NVL(A.RESER_DATE, A.ORDER_DATE))
                     ELSE NVL(A.RESER_DATE, A.ORDER_DATE) END )
                                                             ORDER_DATE        ,
               (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')
                     THEN NVL(A.ACTING_DATE, NVL(A.RESER_DATE, A.ORDER_DATE))
                     ELSE NVL(A.RESER_DATE, A.ORDER_DATE) END )
                                                             ORDER_END_DATE    ,
****************************** /


               A.INPUT_GUBUN                                 INPUT_GUBUN       ,
               E.CODE_NAME                                   INPUT_GUBUN_NAME  ,
               SUBSTR(A.ORDER_GUBUN, 2, 1)                   ORDER_GUBUN       ,
               FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', SUBSTR(A.ORDER_GUBUN, 2, 1) )
                                                             ORDER_GUBUN_NAME  ,
               A.HANGMOG_CODE                                HANGMOG_CODE      ,
               DECODE(A.BANNAB_YN, 'Y', '['||TRIM(FN_ADM_MSG(3142))||']', DECODE(SIGN(A.NALSU), -1, '['||TRIM(FN_ADM_MSG(3154))||']', DECODE( A.DC_GUBUN, 'Y', '['||TRIM(FN_ADM_MSG(3239))||']', '')))||
               ( CASE WHEN NVL(A.PORTABLE_YN, 'N') = 'N' THEN ''
                      ELSE FN_OCS_LOAD_CODE_NAME('PORTABLE_YN', A.PORTABLE_YN) END )||
               ( CASE WHEN C.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
                      THEN NVL(FN_DRG_SPEC_NAME(C.HANGMOG_CODE), '')||C.HANGMOG_NAME
                      ELSE C.HANGMOG_NAME  END )             HANGMOG_NAME      ,
               A.SURYANG                                     SURYANG           ,
               A.NALSU                                       NALSU             ,
               (CASE WHEN C.INPUT_CONTROL = '1' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(A.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(A.SURYANG)), LTRIM(TO_CHAR(A.SURYANG)))
                     WHEN C.INPUT_CONTROL = 'C' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(A.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(A.SURYANG)), LTRIM(TO_CHAR(A.SURYANG)))
                     WHEN C.INPUT_CONTROL = 'D' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(A.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(A.SURYANG)), LTRIM(TO_CHAR(A.SURYANG)))
                     WHEN C.INPUT_CONTROL = '2' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(A.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(A.SURYANG)), LTRIM(TO_CHAR(A.SURYANG)))
                     WHEN C.INPUT_CONTROL = '3' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(A.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(A.SURYANG)), LTRIM(TO_CHAR(A.SURYANG)))
                     WHEN C.INPUT_CONTROL = '6' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(A.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(A.SURYANG)), LTRIM(TO_CHAR(A.SURYANG)))
                     WHEN C.INPUT_CONTROL = '7' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(A.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(A.SURYANG)), LTRIM(TO_CHAR(A.SURYANG)))
                     ELSE '' END)                              ||
               (CASE WHEN C.ORDER_GUBUN         = 'K' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)
                     WHEN C.INPUT_CONTROL       = '1' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)
                     WHEN C.INPUT_CONTROL       = 'C' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)
                     WHEN C.INPUT_CONTROL       = 'D' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)
                     WHEN C.INPUT_CONTROL       = '2' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)
                     WHEN C.INPUT_CONTROL       = '3' AND NVL(D.BUN_CODE, 'XX') = 'T2'
                                                      THEN FN_ADM_MSG(3185)
                     WHEN C.INPUT_CONTROL       = '3' THEN FN_ADM_MSG(3182)
                     WHEN C.INPUT_CONTROL       = '6'
                     THEN DECODE(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI), '', FN_ADM_MSG(3186), FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI))
                     WHEN C.INPUT_CONTROL       = '7'
                     THEN DECODE(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI), '', FN_ADM_MSG(3186), FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI))
                     ELSE '' END )                            ||
               (CASE WHEN C.INPUT_CONTROL = '1' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME', A.DV_TIME)
                     WHEN C.INPUT_CONTROL = '2' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME', A.DV_TIME)
                     ELSE '' END )                            ||
               (CASE WHEN C.INPUT_CONTROL = '1' THEN TRIM(TO_CHAR(A.DV, '99'))
                     WHEN C.INPUT_CONTROL = '2' THEN TRIM(TO_CHAR(A.DV, '99'))
                     ELSE '' END )                            ||
               (CASE WHEN C.INPUT_CONTROL = '1' THEN '  '||DECODE(A.NALSU, 1, '', LTRIM(TO_CHAR(A.NALSU, '9999'))||FN_ADM_MSG(3184))
                     WHEN C.INPUT_CONTROL = '2' THEN '  '||DECODE(A.NALSU, 1, '', LTRIM(TO_CHAR(A.NALSU, '9999'))||FN_ADM_MSG(3184))
                     WHEN C.INPUT_CONTROL = '3' THEN '  '||LTRIM(TO_CHAR(A.NALSU, '9999'))||FN_ADM_MSG(3183)
                     WHEN C.INPUT_CONTROL = '7' THEN '  '||DECODE(A.NALSU, 1, '', LTRIM(TO_CHAR(A.NALSU, '9999'))||FN_ADM_MSG(3184))
                     WHEN C.INPUT_CONTROL = '8' THEN '  '||DECODE(A.NALSU, 1, '', LTRIM(TO_CHAR(A.NALSU, '9999'))||FN_ADM_MSG(3184))
                         ELSE '' END)                             ||
                   FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4)    DETAIL ,
               TRIM(A.ORDER_REMARK)                          ORDER_REMARK      ,
               TRIM(A.NURSE_REMARK)                          NURSE_REMARK      ,
               A.TEL_YN                                      TEL_YN            ,
               A.EMERGENCY                                   EMERGENCY         ,
               FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)         JUSA_NAME         ,
               (CASE WHEN NVL(A.SPECIMEN_CODE, '*') <> '*' AND A.BOGYONG_CODE IS NULL
                     THEN FN_OCS_LOAD_SPECIMEN_NAME(A.SPECIMEN_CODE)
                     WHEN NVL(A.SPECIMEN_CODE, '*') <> '*' AND A.BOGYONG_CODE IS NOT NULL
                     THEN FN_OCS_LOAD_SPECIMEN_NAME(A.SPECIMEN_CODE)||' '||FN_OCS_BOGYONG_COL_NAME(C.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
                     ELSE FN_OCS_BOGYONG_COL_NAME(C.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN) END )
                                                             BOGYONG_NAME      ,
               0                                             JAEWONIL          ,
               A.PKOCS2003                                   PK                ,
               A.GROUP_SER                                   GROUP_SER         ,
               A.MIX_GROUP                                   MIX_GROUP         ,
               'OCS2003'                                     TABLE_ID          ,
               ( CASE WHEN A.NURSE_PICKUP_DATE IS NULL
                       AND A.ORDER_GUBUN NOT LIKE 'D%'
                       AND A.ORDER_GUBUN NOT LIKE 'N%'
                      THEN 'N'
                      ELSE 'Y' END )                         CONFIRM_YN        ,
               DECODE(A.OCS_FLAG, '3', 'Y', 'N')             ACTING_YN         ,
               'N'                                           CAN_PLAN_CHANGE_YN,
               ( CASE WHEN SUBSTR(A.INPUT_GUBUN, 1, 1) IN ('D', 'N') THEN 'Y'
                      ELSE 'N' END )                         CAN_CONFIRM_YN    ,
               'N'                                           CAN_ACTING_YN     ,
               'N'                                           CAN_PLAN_APP_YN   ,
               TO_CHAR(A.ORDER_DATE, 'YYYY/MM/DD')||' '||FN_ADM_LOAD_USER_NM(A.INPUT_ID, A.ORDER_DATE)
                                                             INPUT_NAME        ,
               NVL(E.SORT_KEY, 99)                           INPUT_SEQ         ,
               NVL(F.ORDER_END_YN  , 'N')                    ORDER_END_YN      ,
               (CASE WHEN NVL(H.USER_GUBUN, '3') = '2' THEN  FN_ADM_LOAD_USER_NM(H.USER_ID, A.ORDER_DATE)
                     ELSE '' END )                           CONFIRM_NAME      ,
               (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B' )
                         THEN FN_OCS_CHECK_DETAIL_ACTING(A.PKOCS2003)
                         ELSE 'N' END)                        DETAIL_ACT_YN    ,
               (CASE WHEN FN_OCS_BULYONG_CHECK(A.HANGMOG_CODE, A.ORDER_DATE) = 'Y'
                          AND A.ACTING_DATE IS NULL
                         THEN 'Y'
                         ELSE 'N' END)                       BULYONG_CHECK     ,
               FN_ADM_LOAD_USER_NM(A.NURSE_HOLD_USER, A.ORDER_DATE)
                                                             NURSE_HOLD_USER   ,
               A.INPUT_GWA                                   INPUT_GWA         ,
               A.INPUT_DOCTOR                                INPUT_DOCTOR      ,
               (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')
                     THEN REPLACE(TO_CHAR(FN_SCH_LOAD_RESER_DATE('I', A.PKOCS2003), 'YYYY/MM/DD HH24:MI'), '00:00', '')
                     ELSE TO_CHAR(NVL(A.RESER_DATE, A.HOPE_DATE), 'YYYY/MM/DD') END )
                     RESER_DATE        ,
               A.ACTING_DATE                                 ACTING_DATE       ,
               A.JUNDAL_TABLE                                JUNDAL_TABLE      ,
               A.JUNDAL_PART                                 JUNDAL_PART       ,
               A.OCS_FLAG                                    OCS_FLAG          ,
               A.ORDER_DATE                                  SOURCE_ORDER_DATE  ,
               'N'                                           continue_yn       ,
               '1'||SUBSTR(A.ORDER_GUBUN, 2, 1)||TO_CHAR(NVL(A.RESER_DATE, I.HOLI_DAY), 'YYYYMMDD')||'0000000000'||LTRIM(TO_CHAR(E.SORT_KEY, '00'))||LTRIM(TO_CHAR(A.GROUP_SER, '000'))||NVL(A.MIX_GROUP, '  ')||LTRIM(TO_CHAR(A.SEQ, '0000'))
                                                             CONT_KEY
             , ''                                            JISI_ORDER_GUBUN
             , ''                                            DIRECT_CONT
             , 0                                             PKOCS2005
             , 0                                             PKOCS6015
             , A.INPUT_ID   INPUT_ID
          FROM OCS2003 A,
               OCS2004 B,
               OCS0103 C,
               BAS0310 D,
               OCS0132 E,
               OCS6013 F,
               DRG3010 G,
               ADM3200 H
             , RES0101 I
         WHERE A.BUNHO                = '000026869'
           AND A.FKINP1001            = '1605981'
           AND A.HOSP_CODE            = 'XXX'


           AND ( (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')
                       THEN NVL(A.ACTING_DATE, NVL(A.RESER_DATE, A.ORDER_DATE))
                       ELSE NVL(A.RESER_DATE, A.ORDER_DATE) END ) >= '2011/12/20'
              OR (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('B', 'C', 'D')
                       THEN NVL(A.RESER_DATE, A.ORDER_DATE) END ) > = A.ORDER_DATE)            

/****************** ORDER NDAY 변경에 따른 처리..
           AND (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')
                     THEN NVL(A.ACTING_DATE, NVL(A.RESER_DATE, A.ORDER_DATE))
                     ELSE NVL(A.RESER_DATE, A.ORDER_DATE) END ) >= '2011/12/20'
           AND (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')
                     THEN NVL(A.ACTING_DATE, NVL(A.RESER_DATE, A.ORDER_DATE))
                     ELSE NVL(A.RESER_DATE, A.ORDER_DATE) END ) <= '2011/12/26'
****************** /


           AND NVL(A.NDAY_YN, 'N') = 'N'
--           AND NVL(A.DISPLAY_YN,'Y')  = 'Y'
           AND NVL(A.PRN_YN,'N')      = 'N'
           --반납원Order는 보이도록 한다.
           AND ( NVL(A.DC_YN,'N')     = 'N' OR ( NVL(A.DC_YN,'N') = 'Y' AND A.BANNAB_YN = 'Y' ))
           AND SUBSTR(A.ORDER_GUBUN, 2, 1) LIKE DECODE( NVL('%', '%'), '1', '%', NVL('%', '%') )
           AND B.BUNHO      (+)       = A.BUNHO
           AND B.FKINP1001  (+)       = A.FKINP1001
           AND B.ORDER_DATE (+)       = A.ORDER_DATE
           AND B.INPUT_GUBUN(+)       = A.INPUT_GUBUN
           AND B.HOSP_CODE  (+)       = A.HOSP_CODE
           AND C.HANGMOG_CODE         = A.HANGMOG_CODE
           AND C.HOSP_CODE            = A.HOSP_CODE
           AND D.SG_CODE    (+)       = C.SG_CODE
           AND D.HOSP_CODE  (+)       = C.HOSP_CODE
           AND E.CODE_TYPE            = 'INPUT_GUBUN'
           AND E.CODE                 = A.INPUT_GUBUN
           AND E.HOSP_CODE            = A.HOSP_CODE
           AND F.ref_FKOCS2003(+)     = A.PKOCS2003
           AND F.HOSP_CODE  (+)       = A.HOSP_CODE
           AND G.FKOCS2003  (+)       = A.PKOCS2003
           AND G.HOSP_CODE  (+)       = A.HOSP_CODE
           AND H.USER_ID    (+)       = A.NURSE_PICKUP_USER
           AND H.HOSP_CODE  (+)       = A.HOSP_CODE


           AND I.HOLI_DAY BETWEEN NVL(A.ORDER_DATE, TRUNC(SYSDATE)) AND A.ORDER_DATE + ABS(A.NALSU) - 1
           AND I.HOSP_CODE      = A.HOSP_CODE
           AND I.HOLI_DAY      <= '2011/12/26'
           AND I.HOLI_DAY BETWEEN '2011/12/20' AND '2011/12/26'


        UNION ALL
        SELECT A.BUNHO                                       BUNHO             ,
               A.FKINP1001                                   FKINP1001         ,
               B.FKOCS6010                                   FKOCS6010         ,
               NULL                                          CP_NAME           ,
               B.PLAN_ORDER_DATE                             ORDER_DATE        ,
               B.PLAN_ORDER_DATE                             ORDER_END_DATE    ,
               B.INPUT_GUBUN                                 INPUT_GUBUN       ,
               F.CODE_NAME                                   INPUT_GUBUN_NAME  ,
               SUBSTR(B.ORDER_GUBUN, 2, 1)                   ORDER_GUBUN       ,
               FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', SUBSTR(B.ORDER_GUBUN, 2, 1) )
                                                             ORDER_GUBUN_NAME  ,
               B.HANGMOG_CODE                                HANGMOG_CODE      ,
               ( CASE WHEN NVL(B.PORTABLE_YN, 'N') = 'N' THEN ''
                      ELSE FN_OCS_LOAD_CODE_NAME('PORTABLE_YN', B.PORTABLE_YN) END )||
               DECODE(B.PRN_YN, 'Y', '[PRN]', '')||
               ( CASE WHEN D.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
                      THEN NVL(FN_DRG_SPEC_NAME(D.HANGMOG_CODE), '')||D.HANGMOG_NAME
                      ELSE D.HANGMOG_NAME  END )             HANGMOG_NAME      ,
               B.SURYANG                                     SURYANG           ,
               B.NALSU                                       NALSU             ,
               (CASE WHEN D.INPUT_CONTROL = '1' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(B.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(B.SURYANG)), LTRIM(TO_CHAR(B.SURYANG)))
                     WHEN D.INPUT_CONTROL = 'C' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(B.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(B.SURYANG)), LTRIM(TO_CHAR(B.SURYANG)))
                     WHEN D.INPUT_CONTROL = 'D' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(B.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(B.SURYANG)), LTRIM(TO_CHAR(B.SURYANG)))
                     WHEN D.INPUT_CONTROL = '2' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(B.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(B.SURYANG)), LTRIM(TO_CHAR(B.SURYANG)))
                     WHEN D.INPUT_CONTROL = '3' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(B.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(B.SURYANG)), LTRIM(TO_CHAR(B.SURYANG)))
                     WHEN D.INPUT_CONTROL = '6' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(B.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(B.SURYANG)), LTRIM(TO_CHAR(B.SURYANG)))
                     WHEN D.INPUT_CONTROL = '7' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(B.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(B.SURYANG)), LTRIM(TO_CHAR(B.SURYANG)))
                         ELSE '' END)                              ||
               (CASE WHEN D.ORDER_GUBUN         = 'K' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI)
                     WHEN D.INPUT_CONTROL       = '1' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI)
                     WHEN D.INPUT_CONTROL       = 'C' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI)
                     WHEN D.INPUT_CONTROL       = 'D' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI)
                     WHEN D.INPUT_CONTROL       = '2' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI)
                     WHEN D.INPUT_CONTROL       = '3' AND NVL(E.BUN_CODE, 'XX') = 'T2'
                                                      THEN FN_ADM_MSG(3185)
                     WHEN D.INPUT_CONTROL       = '3' THEN FN_ADM_MSG(3182)
                     WHEN D.INPUT_CONTROL       = '6'
                     THEN DECODE(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI), '', FN_ADM_MSG(3186), FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI))
                     WHEN D.INPUT_CONTROL       = '7'
                     THEN DECODE(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI), '', FN_ADM_MSG(3186), FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI))
                     ELSE '' END )                            ||
               (CASE WHEN D.INPUT_CONTROL = '1' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME', B.DV_TIME)
                     WHEN D.INPUT_CONTROL = '2' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME', B.DV_TIME)
                     ELSE '' END )                            ||
               (CASE WHEN D.INPUT_CONTROL = '1' THEN TRIM(TO_CHAR(B.DV, '99'))
                     WHEN D.INPUT_CONTROL = '2' THEN TRIM(TO_CHAR(B.DV, '99'))
                     ELSE '' END )                            ||
               (CASE WHEN D.INPUT_CONTROL = '1' THEN '  '||DECODE(B.NALSU, 1, '', LTRIM(TO_CHAR(B.NALSU, '9999'))||FN_ADM_MSG(3184))
                     WHEN D.INPUT_CONTROL = '2' THEN '  '||DECODE(B.NALSU, 1, '', LTRIM(TO_CHAR(B.NALSU, '9999'))||FN_ADM_MSG(3184))
                     WHEN D.INPUT_CONTROL = '3' THEN '  '||LTRIM(TO_CHAR(B.NALSU, '9999'))||FN_ADM_MSG(3183)
                     WHEN D.INPUT_CONTROL = '7' THEN '  '||DECODE(B.NALSU, 1, '', LTRIM(TO_CHAR(B.NALSU, '9999'))||FN_ADM_MSG(3184))
                     WHEN D.INPUT_CONTROL = '8' THEN '  '||DECODE(B.NALSU, 1, '', LTRIM(TO_CHAR(B.NALSU, '9999'))||FN_ADM_MSG(3184))
                         ELSE '' END)                            ||
                   FN_OCS_LOAD_DV_NAME(B.DV, B.DV_1, B.DV_2, B.DV_3, B.DV_4)
                                                             DETAIL            ,
               TRIM(B.ORDER_REMARK)                          ORDER_REMARK      ,
               TRIM(B.NURSE_REMARK)                          NURSE_REMARK      ,
               'N'                                           TEL_YN            ,
               B.EMERGENCY                                   EMERGENCY         ,
               FN_OCS_LOAD_CODE_NAME('JUSA', B.JUSA)         JUSA_NAME         ,
               (CASE WHEN NVL(B.SPECIMEN_CODE, '*') <> '*' AND B.BOGYONG_CODE IS NULL
                     THEN FN_OCS_LOAD_SPECIMEN_NAME(B.SPECIMEN_CODE)
                     WHEN NVL(B.SPECIMEN_CODE, '*') <> '*' AND B.BOGYONG_CODE IS NOT NULL
                     THEN FN_OCS_LOAD_SPECIMEN_NAME(B.SPECIMEN_CODE)||' '||FN_OCS_BOGYONG_COL_NAME(D.ORDER_GUBUN, B.BOGYONG_CODE, B.JUSA_SPD_GUBUN)
                     ELSE FN_OCS_BOGYONG_COL_NAME(D.ORDER_GUBUN, B.BOGYONG_CODE, B.JUSA_SPD_GUBUN) END )
                                                             BOGYONG_NAME      ,
               B.JAEWONIL                                    JAEWONIL          ,
               B.PKOCS6013                                   PK                ,
               B.GROUP_SER                                   GROUP_SER         ,
               B.MIX_GROUP                                   MIX_GROUP         ,
               'OCS6013'                                     TABLE_ID          ,
               'N'                                           CONFIRM_YN        ,
               'N'                                           ACTING_YN         ,
               'N'                                           CAN_PLAN_CHANGE_YN, -- B.FKOCS6017
               'N'                                           CAN_CONFIRM_YN    ,
               'N'                                           CAN_ACTING_YN     ,
               ( CASE WHEN FN_OCS_BULYONG_CHECK(B.HANGMOG_CODE, B.PLAN_ORDER_DATE)  <> 'Y'
                      THEN 'Y'
                      WHEN FN_OCS_BULYONG_CHECK(B.HANGMOG_CODE, B.PLAN_ORDER_DATE)  = 'Y'
                       AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', B.HANGMOG_CODE, A.BUNHO, B.PLAN_ORDER_DATE) <> B.HANGMOG_CODE
                      THEN 'Y'
                      ELSE 'N' END )                         CAN_PLAN_APP_YN   ,
               TO_CHAR(B.PLAN_ORDER_DATE, 'YYYY/MM/DD')||' '||FN_ADM_LOAD_USER_NM(B.INPUT_DOCTOR, B.PLAN_ORDER_DATE)
                                                             INPUT_NAME        ,
               NVL(F.SORT_KEY, 99)                           INPUT_SEQ         ,
               B.ORDER_END_YN                                ORDER_END_YN      ,
               NULL                                          CONFIRM_NAME      ,
               'N'                                           DETAIL_ACT_YN     ,
               ( CASE WHEN FN_OCS_BULYONG_CHECK(B.HANGMOG_CODE, B.PLAN_ORDER_DATE)  <> 'Y'
                      THEN 'N'
                      WHEN FN_OCS_BULYONG_CHECK(B.HANGMOG_CODE, B.PLAN_ORDER_DATE)  = 'Y'
                       AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', B.HANGMOG_CODE, A.BUNHO, B.PLAN_ORDER_DATE) <> B.HANGMOG_CODE
                      THEN 'Z'
                      ELSE 'Y' END )                         BULYONG_CHECK     ,
               FN_ADM_LOAD_USER_NM(B.NURSE_HOLD_USER, B.PLAN_ORDER_DATE)
                                                             NURSE_HOLD_USER   ,
               ' '                                           INPUT_GWA         ,
               ' '                                           INPUT_DOCTOR      ,
               NULL                                          RESER_DATE        ,
               NULL                                          ACTING_DATE       ,
               B.JUNDAL_TABLE                                JUNDAL_TABLE      ,
               B.JUNDAL_PART                                 JUNDAL_PART       ,
               ( CASE WHEN B.ref_FKOCS2003 IS NOT NULL
                     THEN '3'
                     ELSE '0' END )                          OCS_FLAG          ,
               B.PLAN_ORDER_DATE                             SOURCE_ORDER_DATE  ,
               'N'                                           continue_yn       ,
               '1'||SUBSTR(B.ORDER_GUBUN, 2, 1)||TO_CHAR(B.PLAN_ORDER_DATE , 'YYYYMMDD')||LTRIM(TO_CHAR(B.FKOCS6010, '0000000000'))||LTRIM(TO_CHAR(F.SORT_KEY, '00'))||LTRIM(TO_CHAR(B.GROUP_SER, '000'))||NVL(B.MIX_GROUP, '  ')||TO_CHAR(B.SEQ, '0000')
                                                             CONT_KEY
             , ''                                            JISI_ORDER_GUBUN
             , ''                                            DIRECT_CONT
             , 0                                             PKOCS2005
             , 0                                             PKOCS6015
             , B.INPUT_ID   INPUT_ID
          FROM OCS6010 A,
               OCS6013 B,
               OCS6014 C,
               OCS0103 D,
               BAS0310 E,
               OCS0132 F
         WHERE A.BUNHO              = '000026869'
           AND A.FKINP1001          = '1605981'
           AND A.HOSP_CODE          = 'XXX'
           AND NVL(A.CP_END_YN, 'N') = 'N'
           AND B.FKOCS6010          = A.PKOCS6010
           AND B.HOSP_CODE          = A.HOSP_CODE
           AND B.PLAN_ORDER_DATE   >= '2011/12/20'
           AND B.PLAN_ORDER_DATE   <= '2011/12/26'
           AND NVL(B.FKOCS2003, 0)  = 0
           AND NVL(B.PRN_YN,'N')    = 'N'
           AND SUBSTR(B.ORDER_GUBUN, 2, 1) LIKE DECODE( NVL('%', '%'), '1', '%', NVL('%', '%') )
           AND C.FKOCS6010      (+) = B.FKOCS6010
           AND C.JAEWONIL       (+) = B.JAEWONIL
           AND C.PLAN_ORDER_DATE(+) = B.PLAN_ORDER_DATE
           AND C.INPUT_GUBUN    (+) = B.INPUT_GUBUN
           AND C.HOSP_CODE      (+) = B.HOSP_CODE
           AND D.HANGMOG_CODE       = B.HANGMOG_CODE
           AND D.HOSP_CODE          = B.HOSP_CODE
           AND E.SG_CODE        (+) = D.SG_CODE
           AND E.HOSP_CODE      (+) = D.HOSP_CODE
           AND F.CODE_TYPE          = 'INPUT_GUBUN'
           AND F.CODE               = B.INPUT_GUBUN
           AND F.HOSP_CODE          = B.HOSP_CODE  ) A
WHERE A.ORDER_DATE = TRUNC(SYSDATE)
ORDER BY A.CONT_KEY";*/
            #endregion



            #endregion

            #region [ basic query ]
            cmdText = @"SELECT A.BUNHO             ,
       A.FKINP1001         ,
       A.FKOCS6010         ,
       A.CP_NAME           ,
       TO_CHAR(A.ORDER_DATE, 'YYYY/MM/DD')     ORDER_DATE ,
       TO_CHAR(A.ORDER_END_DATE, 'YYYY/MM/DD') ORDER_END_DATE,
       A.INPUT_GUBUN       ,
       A.INPUT_GUBUN_NAME  ,
       A.ORDER_GUBUN       ,
       A.ORDER_GUBUN_ORI   ,
       A.ORDER_GUBUN_NAME  ,
       A.HANGMOG_CODE      ,
       A.HANGMOG_NAME      ,
       A.SURYANG           ,
       A.NALSU             ,
       DECODE(:f_comment_yn, 'Y', A.DETAIL      , '') DETAIL      ,
       DECODE(:f_remark_yn , 'Y', A.ORDER_REMARK, '') ORDER_REMARK,
       A.NURSE_REMARK      ,
       A.TEL_YN            ,
       A.EMERGENCY         ,
       A.JUSA_NAME         ,
       A.BOGYONG_NAME      ,
       A.JAEWONIL          ,
       A.PK                ,
       A.GROUP_SER         ,
       A.MIX_GROUP         ,
       A.TABLE_ID          ,
       A.CONFIRM_YN        ,
       A.ACTING_YN         ,
       A.CAN_PLAN_CHANGE_YN,
       A.CAN_CONFIRM_YN    ,
       A.CAN_ACTING_YN     ,
       A.CAN_PLAN_APP_YN   ,
       A.INPUT_NAME        ,
       A.INPUT_SEQ         ,
       A.ORDER_END_YN      ,
       A.CONFIRM_NAME      ,
       A.DETAIL_ACT_YN     ,
       A.BULYONG_CHECK     ,
       A.NURSE_HOLD_USER   ,
       A.INPUT_GWA         ,
       A.INPUT_DOCTOR      ,
       A.RESER_DATE        ,--TO_CHAR(A.RESER_DATE, 'YYYY/MM/DD')  RESER_DATE,
       A.ACTING_DATE       ,--TO_CHAR(A.ACTING_DATE, 'YYYY/MM/DD') ACTING_DATE,
       A.JUNDAL_TABLE      ,
       A.JUNDAL_PART       ,
       A.OCS_FLAG          ,
       TO_CHAR(A.SOURCE_ORDER_DATE, 'YYYY/MM/DD') SOURCE_ORDER_DATE,
       A.CONTINUE_YN       ,
       A.JISI_ORDER_GUBUN  ,
       A.DIRECT_CONT       ,
       A.PKOCS2005         ,
       A.PKOCS6015         ,
       A.INPUT_ID          ,
       A.DV                ,
       A.CHECK_ACTING      ,
       A.DIFF              ,
       A.NURSE_ACT_USER    ,
       A.NURSE_ACT_DATE    ,
       A.NURSE_ACT_TIME    ,
       A.MEDI_ACT_CHK      ,
       A.BROUGHT_DRG_YN    ,
       A.FKOCS1003         ,
       A.DRT_FROM_DATETIME ,
       A.DRT_TO_DATETIME   ,
       A.JISI_GUBUN
FROM ( SELECT A.BUNHO                                       BUNHO             ,
               A.FKINP1001                                   FKINP1001         ,
               0                                             FKOCS6010         ,
               NULL                                          CP_NAME           ,
               F.HOLI_DAY                                    ORDER_DATE        ,
               CASE WHEN DECODE(A.DRT_FROM_DATE, NULL, A.ORDER_DATE, NVL(A.DRT_TO_DATE, TO_DATE('99981231', 'YYYYMMDD'))) >= TO_DATE(:f_to_date, 'YYYY/MM/DD') THEN  TO_DATE(:f_to_date, 'YYYY/MM/DD')
               ELSE DECODE(A.DRT_FROM_DATE, NULL, A.ORDER_DATE, NVL(A.DRT_TO_DATE, TO_DATE('99981231', 'YYYYMMDD')))
               END                                           ORDER_END_DATE    ,
               A.INPUT_GUBUN                                 INPUT_GUBUN       ,
               E.CODE_NAME                                   INPUT_GUBUN_NAME  ,
               A.DIRECT_GUBUN                                ORDER_GUBUN       ,
               A.DIRECT_GUBUN                                ORDER_GUBUN_ORI   ,
               B.NUR_GR_NAME                                 ORDER_GUBUN_NAME  ,
               A.DIRECT_CODE                                 HANGMOG_CODE      ,
               C.NUR_MD_NAME                                 HANGMOG_NAME      ,
               1                                             SURYANG           ,
               1                                             NALSU             ,
               TRIM(A.DIRECT_TEXT    )                       DETAIL            ,
               FN_OCSI_LOAD_DIRECT_ACT_RESULT(A.BUNHO, A.FKINP1001, F.HOLI_DAY, A.INPUT_GUBUN, A.PK_SEQ, A.ORDER_DATE)      ORDER_REMARK ,
               NULL                                          NURSE_REMARK      ,
               'N'                                           TEL_YN            ,
               'N'                                           EMERGENCY         ,
               ' '                                           JUSA_NAME         ,
               ' '                                           BOGYONG_NAME      ,
               0                                             JAEWONIL          ,
               A.PK_SEQ                                      PK                ,
               '1'                                           GROUP_SER         ,
               NULL                                          MIX_GROUP         ,
               'OCS2005'                                     TABLE_ID          ,
               'N'                                           CONFIRM_YN        ,
               DECODE(C.ACTING_YN, 'Y', DECODE( FN_OCSI_LOAD_DIRECT_ACT_ID(A.BUNHO, A.FKINP1001, A.ORDER_DATE, A.INPUT_GUBUN, F.HOLI_DAY, A.PK_SEQ), null, 'N', 'Y'), 'Y')
                                                             ACTING_YN         ,
               'N'                                           CAN_PLAN_CHANGE_YN,
               'N'                                           CAN_CONFIRM_YN    ,
               DECODE(C.ACTING_YN, 'Y', 'Y', 'N')            CAN_ACTING_YN     ,
               'N'                                           CAN_PLAN_APP_YN   ,
               FN_ADM_USER_NM(A.INPUT_ID)                    INPUT_NAME        ,
               NVL(E.SORT_KEY, 99)                           INPUT_SEQ         ,
               'N'                                           ORDER_END_YN      ,
               NULL                                          CONFIRM_NAME      ,
               'N'                                           DETAIL_ACT_YN     ,
               'N'                                           BULYONG_CHECK     ,
               ' '                                           NURSE_HOLD_USER   ,
               A.INPUT_GWA                                   INPUT_GWA         ,
               A.INPUT_DOCTOR                                INPUT_DOCTOR      ,
               NULL                                          RESER_DATE        ,
               F.HOLI_DAY                                    ACTING_DATE       ,
               ' '                                           JUNDAL_TABLE      ,
               ' '                                           JUNDAL_PART       ,
               '0'                                           OCS_FLAG          ,
               A.ORDER_DATE                                  SOURCE_ORDER_DATE ,
               A.CONTINUE_YN                                 CONTINUE_YN       ,

              '0'||A.DIRECT_GUBUN||A.DIRECT_CODE||TO_CHAR(A.ORDER_DATE, 'YYYYMMDD')||A.INPUT_GUBUN || TO_CHAR(A.DRT_FROM_DATE, 'YYYYMMDD') || A.DRT_FROM_TIME CONT_KEY,
               C.JISI_ORDER_GUBUN                            JISI_ORDER_GUBUN  ,
               A.DIRECT_CONT1                                DIRECT_CONT
             , A.PKOCS2005                                   PKOCS2005
             , NVL(A.FKOCS6015, 0)                           PKOCS6015
             , A.INPUT_ID   INPUT_ID
             , 0 DV
             , 'N'  CHECK_ACTING
             , NULL DIFF
             , NULL NURSE_ACT_USER
             , NULL NURSE_ACT_DATE
             , NULL NURSE_ACT_TIME
             , NULL MEDI_ACT_CHK
             , NULL BROUGHT_DRG_YN
             , NULL FKOCS1003             
             , TO_CHAR(A.DRT_FROM_DATE, 'YYYYMMDD') || A.DRT_FROM_TIME      DRT_FROM_DATETIME
             , CASE WHEN A.CONTINUE_YN = 'Y' THEN '999812312359'
                    WHEN A.CONTINUE_YN = 'N' AND (A.DRT_TO_DATE IS NULL OR A.DRT_TO_TIME IS NULL) THEN TO_CHAR(F.HOLI_DAY, 'YYYYMMDD') || '2359'
                    ELSE TO_CHAR(A.DRT_TO_DATE, 'YYYYMMDD') || A.DRT_TO_TIME  END        DRT_TO_DATETIME
             , NVL(C.JISI_GUBUN, 'ALL') JISI_GUBUN
          FROM OCS2005 A,
               NUR0110 B,
               NUR0111 C,
               OCS0132 E,
               RES0101 F
         WHERE A.HOSP_CODE      = :f_hosp_code
           AND (    NVL(:f_order_gubun, '%') = '%'
                 OR NVL(:f_order_gubun, '%') = '0'
                 OR NVL(:f_order_gubun, '%') = 'N'
               )
           AND (
                     (:f_emergency_treat = 'N' AND A.INPUT_GUBUN <> 'DN')
                 OR  (:f_emergency_treat = 'Y' )
               )

           AND A.BUNHO          = :f_bunho
           AND A.FKINP1001      = :f_fkinp1001

           AND (:f_from_date BETWEEN NVL(A.DRT_FROM_DATE, A.ORDER_DATE)
                                AND DECODE(A.DRT_FROM_DATE, NULL, A.ORDER_DATE, NVL(A.DRT_TO_DATE, TO_DATE('99981231', 'YYYYMMDD')))
                OR NVL(A.DRT_FROM_DATE, A.ORDER_DATE) >= :f_from_date )

           AND F.HOLI_DAY BETWEEN NVL(A.DRT_FROM_DATE, A.ORDER_DATE)
                                AND DECODE(A.DRT_FROM_DATE, NULL, A.ORDER_DATE, NVL(A.DRT_TO_DATE, TO_DATE('99981231', 'YYYYMMDD')))
           AND F.HOSP_CODE      = A.HOSP_CODE
--           AND F.HOLI_DAY      <= :f_to_date
           AND F.HOLI_DAY BETWEEN :f_from_date AND :f_to_date
           AND B.HOSP_CODE      = A.HOSP_CODE
           AND B.NUR_GR_CODE    = A.DIRECT_GUBUN
           AND C.HOSP_CODE      = A.HOSP_CODE
           AND C.NUR_GR_CODE    = A.DIRECT_GUBUN
           AND C.NUR_MD_CODE    = A.DIRECT_CODE
           AND E.HOSP_CODE      = A.HOSP_CODE
           AND E.CODE_TYPE      = 'INPUT_GUBUN'
           AND E.CODE           = A.INPUT_GUBUN
           AND A.DIRECT_GUBUN   != '03' --食事除外
        UNION ALL
        SELECT A.BUNHO                                       BUNHO             ,
               A.FKINP1001                                   FKINP1001         ,
               0                                             FKOCS6010         ,
               NULL                                          CP_NAME           ,
               F.HOLI_DAY                                    ORDER_DATE        ,
               CASE WHEN DECODE(A.DRT_FROM_DATE, NULL, A.ORDER_DATE, NVL(A.DRT_TO_DATE, TO_DATE('99981231', 'YYYYMMDD'))) >= TO_DATE(:f_to_date, 'YYYY/MM/DD') THEN  TO_DATE(:f_to_date, 'YYYY/MM/DD')
               ELSE DECODE(A.DRT_FROM_DATE, NULL, A.ORDER_DATE, NVL(A.DRT_TO_DATE, TO_DATE('99981231', 'YYYYMMDD')))
               END                                           ORDER_END_DATE    ,
               A.INPUT_GUBUN                                 INPUT_GUBUN       ,
               E.CODE_NAME                                   INPUT_GUBUN_NAME  ,
               A.DIRECT_GUBUN                                ORDER_GUBUN       ,
               A.DIRECT_GUBUN                                ORDER_GUBUN_ORI   ,
               B.NUR_GR_NAME                                 ORDER_GUBUN_NAME  ,
               A.DIRECT_CONT1                                 HANGMOG_CODE      ,
               DECODE(A.BLD_GUBUN, 1, '朝', 2, '昼', '夕') || ': [' || A.SIK_JUSIK_NAME || '] [' || A.SIK_BUSIK_NAME || '] '                              HANGMOG_NAME      ,
               1                                             SURYANG           ,
               1                                             NALSU             ,
               ''                                            DETAIL            ,
               DECODE( A.KUMJISIK, '', '', REPLACE(A.KUMJISIK, CHR(10), CHR(10) || '             ')) ORDER_REMARK,
               NULL                                          NURSE_REMARK      ,
               'N'                                           TEL_YN            ,
               'N'                                           EMERGENCY         ,
               ' '                                           JUSA_NAME         ,
               ' '                                           BOGYONG_NAME      ,
               0                                             JAEWONIL          ,
               A.PK_SEQ                                      PK                ,
               '1'                                           GROUP_SER         ,
               NULL                                          MIX_GROUP         ,
               'OCS2005'                                     TABLE_ID          ,
               'N'                                           CONFIRM_YN        ,
               DECODE(C.ACTING_YN, 'Y', DECODE( FN_OCSI_LOAD_DIRECT_ACT_ID(A.BUNHO, A.FKINP1001, A.ORDER_DATE, A.INPUT_GUBUN, F.HOLI_DAY, A.PK_SEQ), null, 'N', 'Y'), 'Y')
                                                             ACTING_YN         ,
               'N'                                           CAN_PLAN_CHANGE_YN,
               'N'                                           CAN_CONFIRM_YN    ,
               DECODE(C.ACTING_YN, 'Y', 'Y', 'N')            CAN_ACTING_YN     ,
               'N'                                           CAN_PLAN_APP_YN   ,
               FN_ADM_USER_NM(A.INPUT_ID)                    INPUT_NAME        ,
               NVL(E.SORT_KEY, 99)                           INPUT_SEQ         ,
               'N'                                           ORDER_END_YN      ,
               NULL                                          CONFIRM_NAME      ,
               'N'                                           DETAIL_ACT_YN     ,
               'N'                                           BULYONG_CHECK     ,
               ' '                                           NURSE_HOLD_USER   ,
               A.INPUT_GWA                                   INPUT_GWA         ,
               A.INPUT_DOCTOR                                INPUT_DOCTOR      ,
               NULL                                          RESER_DATE        ,
               F.HOLI_DAY                                    ACTING_DATE       ,
               ' '                                           JUNDAL_TABLE      ,
               ' '                                           JUNDAL_PART       ,
               '0'                                           OCS_FLAG          ,
               A.ORDER_DATE                                  SOURCE_ORDER_DATE ,
               A.CONTINUE_YN                                 CONTINUE_YN       ,

            --   '0'||A.DIRECT_GUBUN||A.DIRECT_CODE||TO_CHAR(A.ORDER_DATE, 'YYYYMMDD')||TO_CHAR(E.SORT_KEY)||A.INPUT_GUBUN
            --                                                 CONT_KEY          ,
                           
               '0'||A.DIRECT_GUBUN||'000'||A.BLD_GUBUN||TO_CHAR(A.ORDER_DATE, 'YYYYMMDD')||TO_CHAR(E.SORT_KEY)||A.INPUT_GUBUN  CONT_KEY,

               C.JISI_ORDER_GUBUN                            JISI_ORDER_GUBUN  ,
               A.DIRECT_CONT1                                DIRECT_CONT
             , A.PKOCS2005                                   PKOCS2005
             , 0                                             PKOCS6015
             , A.INPUT_ID   INPUT_ID
             , 0 DV
             , 'N'  CHECK_ACTING
             , NULL DIFF
             , NULL NURSE_ACT_ID
             , NULL NURSE_ACT_DATE
             , NULL NURSE_ACT_TIME
             , NULL MEDI_ACT_CHK
             , NULL BROUGHT_DRG_YN
             , NULL FKOCS1003             
             , NULL DRT_FROM_DATETIME
             , NULL DRT_TO_DATETIME
             , NVL(C.JISI_GUBUN, 'ALL') JISI_GUBUN
          FROM VW_OCS_OCS2005_NUT A,
               NUR0110 B,
               NUR0111 C,
               OCS0132 E,
               RES0101 F
         WHERE A.HOSP_CODE      = :f_hosp_code
           AND (   NVL(:f_order_gubun, '%') = '%' 
                OR NVL(:f_order_gubun, '%') = '0'
                OR NVL(:f_order_gubun, '%') = 'N'
               )
           AND A.BUNHO          = :f_bunho
           AND A.FKINP1001      = :f_fkinp1001
           AND A.NUT_DATE       BETWEEN :f_from_date AND :f_to_date
--           AND (:f_from_date BETWEEN NVL(A.DRT_FROM_DATE, A.ORDER_DATE)
--                                AND DECODE(A.DRT_FROM_DATE, NULL, A.ORDER_DATE, NVL(A.DRT_TO_DATE, TO_DATE('99981231', 'YYYYMMDD')))
--                OR NVL(A.DRT_FROM_DATE, A.ORDER_DATE) >= :f_from_date )
--
--           AND F.HOLI_DAY BETWEEN NVL(A.DRT_FROM_DATE, A.ORDER_DATE)
--                                AND DECODE(A.DRT_FROM_DATE, NULL, A.ORDER_DATE, NVL(A.DRT_TO_DATE, TO_DATE('99981231', 'YYYYMMDD')))
           AND F.HOLI_DAY = A.NUT_DATE                     
           AND F.HOSP_CODE      = A.HOSP_CODE
--           AND F.HOLI_DAY      <= :f_to_date
           AND F.HOLI_DAY BETWEEN :f_from_date AND :f_to_date
           AND B.HOSP_CODE      = A.HOSP_CODE
           AND B.NUR_GR_CODE    = A.DIRECT_GUBUN
           AND C.HOSP_CODE      = A.HOSP_CODE
           AND C.NUR_GR_CODE    = A.DIRECT_GUBUN
           AND C.NUR_MD_CODE    = A.DIRECT_CODE
           AND E.HOSP_CODE      = A.HOSP_CODE
           AND E.CODE_TYPE      = 'INPUT_GUBUN'
           AND E.CODE           = A.INPUT_GUBUN
           AND A.DIRECT_GUBUN   = '03' --食事指示
        UNION ALL
        SELECT A.BUNHO                                       BUNHO             ,
               A.FKINP1001                                   FKINP1001         ,
               B.FKOCS6010                                   FKOCS6010         ,
               NULL                                          CP_NAME           ,
               F.HOLI_DAY                                    ORDER_DATE        ,
               NVL(B.PLAN_TO_DATE, TO_DATE('99991231', 'YYYYMMDD'))
                                                             ORDER_END_DATE    ,
               B.INPUT_GUBUN                                 INPUT_GUBUN       ,
               E.CODE_NAME                                   INPUT_GUBUN_NAME  ,
               B.DIRECT_GUBUN                                ORDER_GUBUN       ,
               B.DIRECT_GUBUN                                ORDER_GUBUN_ORI   ,
               C.NUR_GR_NAME                                 ORDER_GUBUN_NAME  ,
               B.DIRECT_CODE                                 HANGMOG_CODE      ,
               D.NUR_MD_NAME                                 HANGMOG_NAME      ,
               1                                             SURYANG           ,
               1                                             NALSU             ,
               TRIM(B.DIRECT_TEXT)                           DETAIL            ,
               NULL                                          ORDER_REMARK      ,
               NULL                                          NURSE_REMARK      ,
               'N'                                           TEL_YN            ,
               'N'                                           EMERGENCY         ,
               ' '                                           JUSA_NAME         ,
               ' '                                           BOGYONG_NAME      ,
               B.JAEWONIL                                    JAEWONIL          ,
               B.PK_SEQ                                      PK                ,
               '1'                                           GROUP_SER         ,
               NULL                                          MIX_GROUP         ,
               'OCS6015'                                     TABLE_ID          ,
               'N'                                           CONFIRM_YN        ,
               --'N'                                           ACTING_YN         , -- 20110217
               DECODE(D.ACTING_YN, 'Y', DECODE(FN_OCSI_LOAD_OCS6015_ACT_ID(B.PKOCS6015, F.HOLI_DAY), NULL, 'N', 'Y'), 'Y')
                                                             ACTING_YN         ,
               DECODE(SIGN(B.PLAN_FROM_DATE - NVL(B.PLAN_TO_DATE, TO_DATE('99991231', 'YYYYMMDD'))), -1 , 'N', 'Y')
                                                             CAN_PLAN_CHANGE_YN,
               'N'                                           CAN_CONFIRM_YN    ,
               DECODE(D.ACTING_YN, 'Y', 'Y', 'N')            CAN_ACTING_YN     ,
               --'N'                                           CAN_ACTING_YN     , -- 20110217
               'N'                                           CAN_PLAN_APP_YN   ,
               FN_ADM_USER_NM(B.INPUT_ID)                    INPUT_NAME        ,
               NVL(E.SORT_KEY, 99)                           INPUT_SEQ         ,
               'N'                                           ORDER_END_YN      ,
               NULL                                          CONFIRM_NAME      ,
               'N'                                           DETAIL_ACT_YN     ,
               'N'                                           BULYONG_CHECK     ,
               ' '                                           NURSE_HOLD_USER   ,
               ' '                                           INPUT_GWA         ,
               ' '                                           INPUT_DOCTOR      ,
               NULL                                          RESER_DATE        ,
               NULL                                          ACTING_DATE       ,
               ' '                                           JUNDAL_TABLE      ,
               ' '                                           JUNDAL_PART       ,
               '0'                                           OCS_FLAG          ,
               B.PLAN_FROM_DATE                              SOURCE_ORDER_DATE ,
               B.CONTINUE_YN                                 CONTINUE_YN       ,
               '0'||B.DIRECT_GUBUN||B.DIRECT_CODE||TO_CHAR(B.PLAN_FROM_DATE, 'YYYYMMDD')||TO_CHAR(E.SORT_KEY)||B.INPUT_GUBUN
                                                             CONT_KEY
             , D.JISI_ORDER_GUBUN                            JISI_ORDER_GUBUN
             , B.DIRECT_DETAIL                               DIRECT_CONT
             , 0                                             PKOCS2005
             , B.PKOCS6015                                   PKOCS6015
             , B.INPUT_ID   INPUT_ID
             , 0 DV
             , 'N'  CHECK_ACTING
             , NULL DIFF
             , NULL NURSE_ACT_ID
             , NULL NURSE_ACT_DATE
             , NULL NURSE_ACT_TIME
             , NULL MEDI_ACT_CHK
             , NULL BROUGHT_DRG_YN
             , NULL FKOCS1003
             , NULL DRT_FROM_DATETIME
             , NULL DRT_TO_DATETIME
             , NVL(D.JISI_GUBUN, 'ALL') JISI_GUBUN
          FROM OCS6010 A,
               OCS6015 B,
               NUR0110 C,
               NUR0111 D,
               OCS0132 E,
               RES0101 F
         WHERE A.HOSP_CODE          = :f_hosp_code
           AND (   NVL(:f_order_gubun, '%') = '%' 
                OR NVL(:f_order_gubun, '%') = '0'
                OR NVL(:f_order_gubun, '%') = 'N'
               )
           --AND :f_to_date          > TRUNC(SYSDATE)
           AND A.BUNHO              = :f_bunho
           AND A.FKINP1001          = :f_fkinp1001
           AND NVL(A.CP_END_YN, 'N') = 'N'
           AND B.HOSP_CODE          = A.HOSP_CODE
           AND B.FKOCS6010          = A.PKOCS6010
           AND B.PLAN_FROM_DATE    <= :f_to_date
           AND NVL(B.PLAN_TO_DATE, TO_DATE('99991231', 'YYYYMMDD'))
                                   >= DECODE(SIGN( TO_DATE(:f_from_date, 'YYYY/MM/DD') - TRUNC(SYSDATE)), 1, TO_DATE(:f_from_date, 'YYYY/MM/DD'), TRUNC(SYSDATE ))-- + 1)
           AND C.HOSP_CODE          = B.HOSP_CODE                                                       
           AND C.NUR_GR_CODE        = B.DIRECT_GUBUN
           AND D.HOSP_CODE          = B.HOSP_CODE
           AND D.NUR_GR_CODE        = B.DIRECT_GUBUN
           AND D.NUR_MD_CODE        = B.DIRECT_CODE
           AND E.HOSP_CODE          = B.HOSP_CODE
           AND E.CODE_TYPE          = 'INPUT_GUBUN'
           AND E.CODE               = B.INPUT_GUBUN
           
           AND F.HOSP_CODE      = A.HOSP_CODE
           AND F.HOLI_DAY BETWEEN NVL(B.PLAN_FROM_DATE, TRUNC(SYSDATE))
                                AND DECODE(B.PLAN_FROM_DATE, NULL, TRUNC(SYSDATE), NVL(B.PLAN_TO_DATE, TO_DATE('99981231', 'YYYYMMDD')))
--           AND F.HOLI_DAY      <= :f_to_date
           AND F.HOLI_DAY BETWEEN :f_from_date AND :f_to_date

           AND NOT EXISTS(  SELECT 'X'
                              FROM OCS2005
                             WHERE HOSP_CODE  = A.HOSP_CODE
                               AND BUNHO      = A.BUNHO
                               AND FKINP1001  = A.FKINP1001
                               AND ORDER_DATE = F.HOLI_DAY
                               AND FKOCS6015  = B.PKOCS6015 )
        UNION ALL
        SELECT A.BUNHO                                       BUNHO             ,
               A.FKINP1001                                   FKINP1001         ,
               0                                             FKOCS6010         ,
               NULL                                          CP_NAME           ,


               (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')
                     THEN NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)))
                     WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('B', 'C', 'D')
                     THEN I.HOLI_DAY
                     WHEN A.INPUT_TAB = '10' AND A.JUNDAL_PART = 'REH' -- リハビリ実績はオーダー日ではなく実行日で見せる
                     THEN A.ACTING_DATE
                     ELSE NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))
               END )                                         ORDER_DATE        ,
               (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')
                     THEN NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)))
                     WHEN A.INPUT_GUBUN = 'D7'
                     THEN NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)) + A.NALSU
                     WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('B', 'C', 'D')
                     THEN I.HOLI_DAY
                     WHEN A.INPUT_TAB = '10' AND A.JUNDAL_PART = 'REH' -- リハビリ実績はオーダー日ではなく実行日で見せる 
                     THEN A.ACTING_DATE
                     ELSE NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))
               END )                                         ORDER_END_DATE    ,

/*****************************
               (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')
                     THEN NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)))
                     ELSE NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)) END )
                                                             ORDER_DATE        ,
               (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')
                     THEN NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)))
                     ELSE NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)) END )
                                                             ORDER_END_DATE    ,
******************************/


               A.INPUT_GUBUN                                 INPUT_GUBUN       ,
               E.CODE_NAME                                   INPUT_GUBUN_NAME  ,
               SUBSTR(A.ORDER_GUBUN, 2, 1)                   ORDER_GUBUN       ,
               A.ORDER_GUBUN                                 ORDER_GUBUN_ORI   ,
               FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', SUBSTR(A.ORDER_GUBUN, 2, 1) )
                                                             ORDER_GUBUN_NAME  ,
               A.HANGMOG_CODE                                HANGMOG_CODE      ,
               DECODE(A.FKOCS1003, NULL , '' , '[転]') || DECODE(A.BROUGHT_DRG_YN, 'Y' , '[持]') ||
               DECODE(A.BANNAB_YN, 'Y', '['||TRIM(FN_ADM_MSG(3142))||']', DECODE(SIGN(A.NALSU), -1, '['||TRIM(FN_ADM_MSG(3154))||']', DECODE( A.DC_GUBUN, 'Y', '['||TRIM(FN_ADM_MSG(3239))||']', '')))||
               ( CASE WHEN NVL(A.PORTABLE_YN, 'N') = 'N' THEN ''
                      ELSE FN_OCS_LOAD_CODE_NAME('PORTABLE_YN', A.PORTABLE_YN) END )||
               ( CASE WHEN C.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
                      THEN NVL(FN_DRG_SPEC_NAME(C.HANGMOG_CODE), '')||C.HANGMOG_NAME
                      ELSE C.HANGMOG_NAME  END )             HANGMOG_NAME      ,
               A.SURYANG                                     SURYANG           ,
               A.NALSU                                       NALSU             ,
               (CASE WHEN C.INPUT_CONTROL = '1' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(A.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(A.SURYANG)), LTRIM(TO_CHAR(A.SURYANG)))
                     WHEN C.INPUT_CONTROL = 'C' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(A.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(A.SURYANG)), LTRIM(TO_CHAR(A.SURYANG)))
                     WHEN C.INPUT_CONTROL = 'D' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(A.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(A.SURYANG)), LTRIM(TO_CHAR(A.SURYANG)))
                     WHEN C.INPUT_CONTROL = '2' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(A.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(A.SURYANG)), LTRIM(TO_CHAR(A.SURYANG)))
                     WHEN C.INPUT_CONTROL = '3' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(A.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(A.SURYANG)), LTRIM(TO_CHAR(A.SURYANG)))
                     WHEN C.INPUT_CONTROL = '6' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(A.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(A.SURYANG)), LTRIM(TO_CHAR(A.SURYANG)))
                     WHEN C.INPUT_CONTROL = '7' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(A.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(A.SURYANG)), LTRIM(TO_CHAR(A.SURYANG)))
                     ELSE '' END)                              ||
               (CASE WHEN C.ORDER_GUBUN         = 'K' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)
                     WHEN C.INPUT_CONTROL       = '1' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)
                     WHEN C.INPUT_CONTROL       = 'C' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)
                     WHEN C.INPUT_CONTROL       = 'D' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)
                     WHEN C.INPUT_CONTROL       = '2' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)
                     WHEN C.INPUT_CONTROL       = '3' AND NVL(D.BUN_CODE, 'XX') = 'T2'
                                                      THEN FN_ADM_MSG(3185)
                     WHEN C.INPUT_CONTROL       = '3' THEN FN_ADM_MSG(3182)
                     WHEN C.INPUT_CONTROL       = '6'
                     THEN DECODE(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI), '', FN_ADM_MSG(3186), FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI))
                     WHEN C.INPUT_CONTROL       = '7'
                     THEN DECODE(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI), '', FN_ADM_MSG(3186), FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI))
                     ELSE '' END )                            ||
               (CASE WHEN C.INPUT_CONTROL = '1' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME', A.DV_TIME)
                     WHEN C.INPUT_CONTROL = '2' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME', A.DV_TIME)
                     ELSE '' END )                            ||
               (CASE WHEN C.INPUT_CONTROL = '1' THEN TRIM(TO_CHAR(A.DV, '99'))
                     WHEN C.INPUT_CONTROL = '2' THEN TRIM(TO_CHAR(A.DV, '99'))
                     ELSE '' END )                            ||
               -- 酸素の注入時間表示
               (CASE WHEN C.INPUT_CONTROL = '3' AND A.NALSU > 0 THEN '*'|| A.NALSU || '分'
                     ELSE '' END )                            ||
/*               (CASE WHEN C.INPUT_CONTROL = '1' THEN '  '||DECODE(A.NALSU, 1, '', LTRIM(TO_CHAR(A.NALSU, '9999'))||FN_ADM_MSG(3184))
                     WHEN C.INPUT_CONTROL = '2' THEN '  '||DECODE(A.NALSU, 1, '', LTRIM(TO_CHAR(A.NALSU, '9999'))||FN_ADM_MSG(3184))
                     WHEN C.INPUT_CONTROL = '3' THEN '  '||LTRIM(TO_CHAR(A.NALSU, '9999'))||FN_ADM_MSG(3183)
                     WHEN C.INPUT_CONTROL = '7' THEN '  '||DECODE(A.NALSU, 1, '', LTRIM(TO_CHAR(A.NALSU, '9999'))||FN_ADM_MSG(3184))
                     WHEN C.INPUT_CONTROL = '8' THEN '  '||DECODE(A.NALSU, 1, '', LTRIM(TO_CHAR(A.NALSU, '9999'))||FN_ADM_MSG(3184))
                         ELSE '' END)                             ||    */
                   FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4, A.DV_5, A.DV_6, A.DV_7, A.DV_8)    DETAIL ,
               TRIM(A.ORDER_REMARK)                          ORDER_REMARK      ,
               TRIM(A.NURSE_REMARK)                          NURSE_REMARK      ,
               A.TEL_YN                                      TEL_YN            ,
               A.EMERGENCY                                   EMERGENCY         ,
               FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)         JUSA_NAME         ,
               (CASE WHEN NVL(A.SPECIMEN_CODE, '*') <> '*' AND A.BOGYONG_CODE IS NULL
                     THEN FN_OCS_LOAD_SPECIMEN_NAME(A.SPECIMEN_CODE)
                     WHEN NVL(A.SPECIMEN_CODE, '*') <> '*' AND A.BOGYONG_CODE IS NOT NULL
                     THEN FN_OCS_LOAD_SPECIMEN_NAME(A.SPECIMEN_CODE)||' '||FN_OCS_BOGYONG_COL_NAME(C.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)
                     ELSE FN_OCS_BOGYONG_COL_NAME(C.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN) END )
                                                             BOGYONG_NAME      ,
               0                                             JAEWONIL          ,
               A.PKOCS2003                                   PK                ,
               --SUBSTR(A.GROUP_SER, 2)                        GROUP_SER         ,
               TO_CHAR(A.GROUP_SER)                                   GROUP_SER         ,
               A.MIX_GROUP                                   MIX_GROUP         ,
               'OCS2003'                                     TABLE_ID          ,
               ( CASE WHEN A.NURSE_PICKUP_DATE IS NULL
                       AND A.ORDER_GUBUN NOT LIKE 'D%'
                       AND A.ORDER_GUBUN NOT LIKE 'N%'
                      THEN 'N'
                      ELSE 'Y' END )                         CONFIRM_YN        ,
               DECODE(A.OCS_FLAG, '3', 'Y', '4', 'Y', 'N')   ACTING_YN         ,
               'N'                                           CAN_PLAN_CHANGE_YN,
               ( CASE WHEN SUBSTR(A.INPUT_GUBUN, 1, 1) IN ('D', 'N') THEN 'Y'
                      ELSE 'N' END )                         CAN_CONFIRM_YN    ,
               'N'                                           CAN_ACTING_YN     ,
               'N'                                           CAN_PLAN_APP_YN   ,
               TO_CHAR(A.ORDER_DATE, 'MM/DD')||' '||FN_ADM_LOAD_USER_NM(A.INPUT_ID, A.ORDER_DATE)
                                                             INPUT_NAME        ,
               NVL(E.SORT_KEY, 99)                           INPUT_SEQ         ,
               NVL(F.ORDER_END_YN  , 'N')                    ORDER_END_YN      ,
               (CASE WHEN NVL(H.USER_GUBUN, '3') = '2' THEN  FN_ADM_LOAD_USER_NM(H.USER_ID, A.ORDER_DATE)
                     ELSE '' END )                           CONFIRM_NAME      ,
               (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('A', 'B' )
                         THEN FN_OCS_CHECK_DETAIL_ACTING(A.PKOCS2003)
                         ELSE 'N' END)                        DETAIL_ACT_YN    ,
               (CASE WHEN FN_OCS_BULYONG_CHECK(A.HANGMOG_CODE, A.ORDER_DATE) = 'Y'
                          AND A.ACTING_DATE IS NULL
                         THEN 'Y'
                         ELSE 'N' END)                       BULYONG_CHECK     ,
               FN_ADM_LOAD_USER_NM(A.NURSE_HOLD_USER, A.ORDER_DATE)
                                                             NURSE_HOLD_USER   ,
               A.INPUT_GWA                                   INPUT_GWA         ,
               A.INPUT_DOCTOR                                INPUT_DOCTOR      ,
               (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')
                     THEN REPLACE(TO_CHAR(FN_SCH_LOAD_RESER_DATE('I', A.PKOCS2003), 'YYYY/MM/DD HH24:MI'), '00:00', '')
                     ELSE TO_CHAR(NVL(A.RESER_DATE, A.HOPE_DATE), 'YYYY/MM/DD') END )
                     RESER_DATE        ,
               A.ACTING_DATE                                 ACTING_DATE       ,
               A.JUNDAL_TABLE                                JUNDAL_TABLE      ,
               A.JUNDAL_PART                                 JUNDAL_PART       ,
               A.OCS_FLAG                                    OCS_FLAG          ,
               A.ORDER_DATE                                  SOURCE_ORDER_DATE  ,
               'N'                                           continue_yn       ,
               '1'||SUBSTR(A.ORDER_GUBUN, 2, 1)||TO_CHAR(NVL(A.RESER_DATE, I.HOLI_DAY), 'YYYYMMDD')||'0000000000'||LTRIM(TO_CHAR(E.SORT_KEY, '00'))||LTRIM(TO_CHAR(A.GROUP_SER, '000'))||NVL(A.MIX_GROUP, '  ')||LTRIM(TO_CHAR(A.SEQ, '0000'))
                                                             CONT_KEY
             , ''                                            JISI_ORDER_GUBUN
             , ''                                            DIRECT_CONT
             , 0                                             PKOCS2005
             , 0                                             PKOCS6015
             , A.INPUT_ID   INPUT_ID
             , A.DV         DV
             , CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('B', 'C', 'D')
                      THEN FN_OCS_CHECK_DETAIL_MAX_ACTING(A.PKOCS2003, NVL(A.HOPE_DATE, A.ORDER_DATE))
                    ELSE 'N'
               END AS CHECK_ACTING
             , I.HOLI_DAY - NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)) + 1  AS DIFF
             , A.NURSE_ACT_USER    NURSE_ACT_USER
             , A.NURSE_ACT_DATE    NURSE_ACT_DATE
             , A.NURSE_ACT_TIME    NURSE_ACT_TIME
             , FN_MEDICINE_ACTING_CHECK(A.HOSP_CODE, A.PKOCS2003, I.HOLI_DAY)  MEDI_ACT_CHK             
             , NVL(BROUGHT_DRG_YN, 'N')                                        BROUGHT_DRG_YN
             , FKOCS1003                                                       FKOCS1003
             , NULL DRT_FROM_DATETIME
             , NULL DRT_TO_DATETIME
             , 'ALL' JISI_GUBUN
          FROM OCS2003 A,
               OCS2004 B,
               OCS0103 C,
               (SELECT *
                  FROM BAS0310 A
                 WHERE A.HOSP_CODE = :f_hosp_code
                   AND A.SG_YMD    = (SELECT MAX(C.SG_YMD)
                                        FROM BAS0310 C
                                       WHERE C.HOSP_CODE = A.HOSP_CODE
                                         AND C.SG_CODE   = A.SG_CODE
                                       )
                  ) D,
               OCS0132 E,
               OCS6013 F,
               DRG3010 G,
               ADM3200 H
             , RES0101 I
         WHERE A.HOSP_CODE            = :f_hosp_code
           AND A.BUNHO                = :f_bunho
           AND A.FKINP1001            = :f_fkinp1001
 
           AND (      (   (NVL(A.INSTEAD_YN, 'N')     = 'N') -- 代行オーダーではない
                       OR (NVL(A.POSTAPPROVE_YN, 'N') = 'Y') -- 事後承認可能
                      )
                   OR (   (NVL(A.INSTEAD_YN, 'N')      = 'Y' AND :f_instead_order_display_yn = 'Y')
                       OR (NVL(A.APPROVE_YN, 'N')      = 'Y' AND :f_instead_order_display_yn = 'N')
                      )
               )

           AND ( (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')
                       THEN NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)))
                       --
                       WHEN A.INPUT_TAB = '10'
                       THEN NVL(A.ACTING_DATE, A.ORDER_DATE)

                       ELSE NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)) END ) >= :f_from_date

              OR (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('B', 'C', 'D', 'Z')
                       THEN NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)) END ) > = A.ORDER_DATE)            

/****************** ORDER NDAY 변경에 따른 처리..
           AND (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')
                     THEN NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)))
                     ELSE NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)) END ) >= :f_from_date
           AND (CASE WHEN SUBSTR(A.ORDER_GUBUN, 2, 1) IN ('F', 'E')
                     THEN NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)))
                     ELSE NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)) END ) <= :f_to_date
******************/


           AND NVL(A.NDAY_YN, 'N') = 'N'
--           AND NVL(A.DISPLAY_YN,'Y')  = 'Y'
           AND NVL(A.PRN_YN,'N')      = 'N'
           --반납원Order는 보이도록 한다.
--           AND ( NVL(A.DC_YN,'N')     = 'N' OR ( NVL(A.DC_YN,'N') = 'Y' AND A.BANNAB_YN = 'Y' ))
           -- 반납Order 는 표시하지 않음
           AND ( NVL(A.DC_YN, 'N')      = 'N' OR ( NVL(A.DC_YN,'N') = 'Y' AND NVL( A.BANNAB_YN, 'N') = 'N' ) )
           AND SUBSTR(A.ORDER_GUBUN, 2, 1) LIKE DECODE( NVL(:f_order_gubun, '%'), '1', '%', NVL(:f_order_gubun, '%') )
           AND B.HOSP_CODE  (+)       = A.HOSP_CODE
           AND B.BUNHO      (+)       = A.BUNHO
           AND B.FKINP1001  (+)       = A.FKINP1001
           AND B.ORDER_DATE (+)       = A.ORDER_DATE
           AND B.INPUT_GUBUN(+)       = A.INPUT_GUBUN
           AND C.HOSP_CODE            = A.HOSP_CODE
           AND C.HANGMOG_CODE         = A.HANGMOG_CODE
           AND TRUNC(A.ORDER_DATE) BETWEEN TRUNC(C.START_DATE) AND TRUNC(C.END_DATE)
           AND D.HOSP_CODE  (+)       = C.HOSP_CODE
           AND D.SG_CODE    (+)       = C.SG_CODE
           AND E.HOSP_CODE            = A.HOSP_CODE
           AND E.CODE_TYPE            = 'INPUT_GUBUN'
           AND E.CODE                 = A.INPUT_GUBUN
           AND F.HOSP_CODE  (+)       = A.HOSP_CODE
           AND F.ref_FKOCS2003(+)     = A.PKOCS2003
           AND G.HOSP_CODE  (+)       = A.HOSP_CODE
           AND G.FKOCS2003  (+)       = A.PKOCS2003
           AND H.HOSP_CODE  (+)       = A.HOSP_CODE
           AND H.USER_ID    (+)       = A.NURSE_PICKUP_USER

-- 2012.02.02 AND I.HOLI_DAY BETWEEN NVL(nvl(a.hope_date, A.ORDER_DATE), TRUNC(SYSDATE)) AND nvl(a.hope_date, A.ORDER_DATE) + ABS(A.NALSU) - 1
-- 2011.10.01 AND I.HOLI_DAY BETWEEN NVL(A.ORDER_DATE, TRUNC(SYSDATE)) AND A.ORDER_DATE + ABS(A.NALSU) - 1

/* 2012.02.23 */

             --
             AND( (C.ORDER_GUBUN != 'D' AND A.INPUT_TAB != '10') AND ( (I.HOLI_DAY BETWEEN NVL(nvl(a.hope_date, A.ORDER_DATE), TRUNC(SYSDATE)) AND nvl(a.hope_date, A.ORDER_DATE) + ABS(DECODE(C.INPUT_CONTROL, '3', 1, A.NALSU)) - 1 AND DECODE(C.INPUT_CONTROL, '3', 1, A.NALSU) > 0 )
                 OR 
                 (I.HOLI_DAY BETWEEN TO_CHAR(FN_OCSI_LOAD_BANNAB_FROM_DATE(A.SOURCE_FKOCS2003), 'YYYY/MM/DD') AND 
                TO_CHAR(FN_OCSI_LOAD_BANNAB_TO_DATE(A.SOURCE_FKOCS2003), 'YYYY/MM/DD')  AND A.NALSU < 0 )
               )
               
               OR
               
               (C.ORDER_GUBUN = 'D' AND (I.HOLI_DAY BETWEEN NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)) AND NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)) + A.DV -1 AND A.NALSU > 0
                                       OR (I.HOLI_DAY BETWEEN TO_CHAR(FN_OCSI_LOAD_BANNAB_FROM_DATE(A.SOURCE_FKOCS2003), 'YYYY/MM/DD') AND 
                                           TO_CHAR(FN_OCSI_LOAD_BANNAB_TO_DATE(A.SOURCE_FKOCS2003), 'YYYY/MM/DD')  AND A.NALSU < 0 )
                                           )
               )
               -- REHABILITATION JISSEKI
               OR (A.INPUT_TAB = '10' AND I.HOLI_DAY = NVL(A.ACTING_DATE, A.ORDER_DATE)) 
               )
/*
 AND ( (I.HOLI_DAY BETWEEN NVL(nvl(a.hope_date, A.ORDER_DATE), TRUNC(SYSDATE)) AND nvl(a.hope_date, A.ORDER_DATE) + ABS(A.NALSU) - 1 AND A.NALSU > 0 )
                     OR 
                     (I.HOLI_DAY BETWEEN TO_CHAR(FN_OCSI_LOAD_BANNAB_FROM_DATE(A.SOURCE_FKOCS2003), 'YYYY/MM/DD') AND 
                    TO_CHAR(FN_OCSI_LOAD_BANNAB_TO_DATE(A.SOURCE_FKOCS2003), 'YYYY/MM/DD')  AND A.NALSU < 0 )
                   )
*/
           AND I.HOSP_CODE      = A.HOSP_CODE
           AND I.HOLI_DAY      <= :f_to_date
           AND I.HOLI_DAY BETWEEN :f_from_date AND :f_to_date
           AND ((A.INPUT_GUBUN != 'D7') OR (A.INPUT_GUBUN = 'D7' AND I.HOLI_DAY = NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)))) 
           -- 丸め代表オーダは見えない様に
           AND NOT EXISTS ( SELECT 'X'
                             FROM OCS0132 J
                            WHERE J.HOSP_CODE  = A.HOSP_CODE
                              AND J.CODE_TYPE  = 'MARUME_ORDER'
                              AND J.CODE       = A.HANGMOG_CODE 
                              AND A.DISPLAY_YN = 'N')
        UNION ALL
        SELECT A.BUNHO                                       BUNHO             ,
               A.FKINP1001                                   FKINP1001         ,
               B.FKOCS6010                                   FKOCS6010         ,
               NULL                                          CP_NAME           ,
               B.PLAN_ORDER_DATE                             ORDER_DATE        ,
               B.PLAN_ORDER_DATE                             ORDER_END_DATE    ,
               B.INPUT_GUBUN                                 INPUT_GUBUN       ,
               F.CODE_NAME                                   INPUT_GUBUN_NAME  ,
               SUBSTR(B.ORDER_GUBUN, 2, 1)                   ORDER_GUBUN       ,
               B.ORDER_GUBUN                                 ORDER_GUBUN_ORI   ,
               FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', SUBSTR(B.ORDER_GUBUN, 2, 1) )
                                                             ORDER_GUBUN_NAME  ,
               B.HANGMOG_CODE                                HANGMOG_CODE      ,
               ( CASE WHEN NVL(B.PORTABLE_YN, 'N') = 'N' THEN ''
                      ELSE FN_OCS_LOAD_CODE_NAME('PORTABLE_YN', B.PORTABLE_YN) END )||
               DECODE(B.PRN_YN, 'Y', '[PRN]', '')||
               ( CASE WHEN D.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
                      THEN NVL(FN_DRG_SPEC_NAME(D.HANGMOG_CODE), '')||D.HANGMOG_NAME
                      ELSE D.HANGMOG_NAME  END )             HANGMOG_NAME      ,
               B.SURYANG                                     SURYANG           ,
               B.NALSU                                       NALSU             ,
               (CASE WHEN D.INPUT_CONTROL = '1' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(B.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(B.SURYANG)), LTRIM(TO_CHAR(B.SURYANG)))
                     WHEN D.INPUT_CONTROL = 'C' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(B.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(B.SURYANG)), LTRIM(TO_CHAR(B.SURYANG)))
                     WHEN D.INPUT_CONTROL = 'D' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(B.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(B.SURYANG)), LTRIM(TO_CHAR(B.SURYANG)))
                     WHEN D.INPUT_CONTROL = '2' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(B.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(B.SURYANG)), LTRIM(TO_CHAR(B.SURYANG)))
                     WHEN D.INPUT_CONTROL = '3' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(B.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(B.SURYANG)), LTRIM(TO_CHAR(B.SURYANG)))
                     WHEN D.INPUT_CONTROL = '6' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(B.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(B.SURYANG)), LTRIM(TO_CHAR(B.SURYANG)))
                     WHEN D.INPUT_CONTROL = '7' THEN DECODE(SUBSTR(LTRIM(TO_CHAR(B.SURYANG)), 1, 1), '.', '0'||LTRIM(TO_CHAR(B.SURYANG)), LTRIM(TO_CHAR(B.SURYANG)))
                         ELSE '' END)                              ||
               (CASE WHEN D.ORDER_GUBUN         = 'K' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI)
                     WHEN D.INPUT_CONTROL       = '1' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI)
                     WHEN D.INPUT_CONTROL       = 'C' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI)
                     WHEN D.INPUT_CONTROL       = 'D' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI)
                     WHEN D.INPUT_CONTROL       = '2' THEN FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI)
                     WHEN D.INPUT_CONTROL       = '3' AND NVL(E.BUN_CODE, 'XX') = 'T2'
                                                      THEN FN_ADM_MSG(3185)
                     WHEN D.INPUT_CONTROL       = '3' THEN FN_ADM_MSG(3182)
                     WHEN D.INPUT_CONTROL       = '6'
                     THEN DECODE(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI), '', FN_ADM_MSG(3186), FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI))
                     WHEN D.INPUT_CONTROL       = '7'
                     THEN DECODE(FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI), '', FN_ADM_MSG(3186), FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI))
                     ELSE '' END )                            ||
               (CASE WHEN D.INPUT_CONTROL = '1' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME', B.DV_TIME)
                     WHEN D.INPUT_CONTROL = '2' THEN FN_OCS_LOAD_CODE_NAME('DV_TIME', B.DV_TIME)
                     ELSE '' END )                            ||
               (CASE WHEN D.INPUT_CONTROL = '1' THEN TRIM(TO_CHAR(B.DV, '99'))
                     WHEN D.INPUT_CONTROL = '2' THEN TRIM(TO_CHAR(B.DV, '99'))
                     ELSE '' END )                            ||
               (CASE WHEN D.INPUT_CONTROL = '1' THEN '  '||DECODE(B.NALSU, 1, '', LTRIM(TO_CHAR(B.NALSU, '9999'))||FN_ADM_MSG(3184))
                     WHEN D.INPUT_CONTROL = '2' THEN '  '||DECODE(B.NALSU, 1, '', LTRIM(TO_CHAR(B.NALSU, '9999'))||FN_ADM_MSG(3184))
                     WHEN D.INPUT_CONTROL = '3' THEN '  '||LTRIM(TO_CHAR(B.NALSU, '9999'))||FN_ADM_MSG(3183)
                     WHEN D.INPUT_CONTROL = '7' THEN '  '||DECODE(B.NALSU, 1, '', LTRIM(TO_CHAR(B.NALSU, '9999'))||FN_ADM_MSG(3184))
                     WHEN D.INPUT_CONTROL = '8' THEN '  '||DECODE(B.NALSU, 1, '', LTRIM(TO_CHAR(B.NALSU, '9999'))||FN_ADM_MSG(3184))
                         ELSE '' END)                            ||
                   FN_OCS_LOAD_DV_NAME(B.DV, B.DV_1, B.DV_2, B.DV_3, B.DV_4, B.DV_5, B.DV_6, B.DV_7, B.DV_8)
                                                             DETAIL            ,
               TRIM(B.ORDER_REMARK)                          ORDER_REMARK      ,
               TRIM(B.NURSE_REMARK)                          NURSE_REMARK      ,
               'N'                                           TEL_YN            ,
               B.EMERGENCY                                   EMERGENCY         ,
               FN_OCS_LOAD_CODE_NAME('JUSA', B.JUSA)         JUSA_NAME         ,
               (CASE WHEN NVL(B.SPECIMEN_CODE, '*') <> '*' AND B.BOGYONG_CODE IS NULL
                     THEN FN_OCS_LOAD_SPECIMEN_NAME(B.SPECIMEN_CODE)
                     WHEN NVL(B.SPECIMEN_CODE, '*') <> '*' AND B.BOGYONG_CODE IS NOT NULL
                     THEN FN_OCS_LOAD_SPECIMEN_NAME(B.SPECIMEN_CODE)||' '||FN_OCS_BOGYONG_COL_NAME(D.ORDER_GUBUN, B.BOGYONG_CODE, B.JUSA_SPD_GUBUN)
                     ELSE FN_OCS_BOGYONG_COL_NAME(D.ORDER_GUBUN, B.BOGYONG_CODE, B.JUSA_SPD_GUBUN) END )
                                                             BOGYONG_NAME      ,
               B.JAEWONIL                                    JAEWONIL          ,
               B.PKOCS6013                                   PK                ,
               --SUBSTR(B.GROUP_SER, 2)                        GROUP_SER         ,
               TO_CHAR(B.GROUP_SER)                                   GROUP_SER         ,
               B.MIX_GROUP                                   MIX_GROUP         ,
               'OCS6013'                                     TABLE_ID          ,
               'N'                                           CONFIRM_YN        ,
               'N'                                           ACTING_YN         ,
               'N'                                           CAN_PLAN_CHANGE_YN, -- B.FKOCS6017
               'N'                                           CAN_CONFIRM_YN    ,
               'N'                                           CAN_ACTING_YN     ,
               ( CASE WHEN FN_OCS_BULYONG_CHECK(B.HANGMOG_CODE, B.PLAN_ORDER_DATE)  <> 'Y'
                      THEN 'Y'
                      WHEN FN_OCS_BULYONG_CHECK(B.HANGMOG_CODE, B.PLAN_ORDER_DATE)  = 'Y'
                       AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', B.HANGMOG_CODE, A.BUNHO, B.PLAN_ORDER_DATE) <> B.HANGMOG_CODE
                      THEN 'Y'
                      ELSE 'N' END )                         CAN_PLAN_APP_YN   ,
               TO_CHAR(B.PLAN_ORDER_DATE, 'YYYY/MM/DD')||' '||FN_ADM_LOAD_USER_NM(B.INPUT_DOCTOR, B.PLAN_ORDER_DATE)
                                                             INPUT_NAME        ,
               NVL(F.SORT_KEY, 99)                           INPUT_SEQ         ,
               B.ORDER_END_YN                                ORDER_END_YN      ,
               NULL                                          CONFIRM_NAME      ,
               'N'                                           DETAIL_ACT_YN     ,
               ( CASE WHEN FN_OCS_BULYONG_CHECK(B.HANGMOG_CODE, B.PLAN_ORDER_DATE)  <> 'Y'
                      THEN 'N'
                      WHEN FN_OCS_BULYONG_CHECK(B.HANGMOG_CODE, B.PLAN_ORDER_DATE)  = 'Y'
                       AND FN_OCS_CONVERT_HANGMOG_CODE('2', '1', B.HANGMOG_CODE, A.BUNHO, B.PLAN_ORDER_DATE) <> B.HANGMOG_CODE
                      THEN 'Z'
                      ELSE 'Y' END )                         BULYONG_CHECK     ,
               FN_ADM_LOAD_USER_NM(B.NURSE_HOLD_USER, B.PLAN_ORDER_DATE)
                                                             NURSE_HOLD_USER   ,
               ' '                                           INPUT_GWA         ,
               ' '                                           INPUT_DOCTOR      ,
               NULL                                          RESER_DATE        ,
               NULL                                          ACTING_DATE       ,
               B.JUNDAL_TABLE                                JUNDAL_TABLE      ,
               B.JUNDAL_PART                                 JUNDAL_PART       ,
               ( CASE WHEN B.ref_FKOCS2003 IS NOT NULL
                     THEN '3'
                     ELSE '0' END )                          OCS_FLAG          ,
               B.PLAN_ORDER_DATE                             SOURCE_ORDER_DATE  ,
               'N'                                           continue_yn       ,
               '1'||SUBSTR(B.ORDER_GUBUN, 2, 1)||TO_CHAR(B.PLAN_ORDER_DATE , 'YYYYMMDD')||LTRIM(TO_CHAR(B.FKOCS6010, '0000000000'))||LTRIM(TO_CHAR(F.SORT_KEY, '00'))||LTRIM(TO_CHAR(B.GROUP_SER, '000'))||NVL(B.MIX_GROUP, '  ')||TO_CHAR(B.SEQ, '0000')
                                                             CONT_KEY
             , ''                                            JISI_ORDER_GUBUN
             , ''                                            DIRECT_CONT
             , 0                                             PKOCS2005
             , 0                                             PKOCS6015
             , B.INPUT_ID   INPUT_ID
             , 0 DV
             , 'N'  CHECK_ACTING
             , NULL DIFF
             , NULL NURSE_ACT_USER
             , NULL NURSE_ACT_DATE
             , NULL NURSE_ACT_TIME
             , NULL MEDI_ACT_CHK
             , NULL BROUGHT_DRG_YN
             , NULL FKOCS1003     
             , NULL DRT_FROM_DATETIME
             , NULL DRT_TO_DATETIME        
             , 'ALL' JISI_GUBUN
          FROM OCS6010 A,
               OCS6013 B,
               OCS6014 C,
               OCS0103 D,
               BAS0310 E,
               OCS0132 F
         WHERE A.HOSP_CODE          = :f_hosp_code
           AND A.BUNHO              = :f_bunho
           AND A.FKINP1001          = :f_fkinp1001
           AND NVL(A.CP_END_YN, 'N') = 'N'
           AND B.HOSP_CODE          = A.HOSP_CODE
           AND B.FKOCS6010          = A.PKOCS6010
           AND B.PLAN_ORDER_DATE   >= :f_from_date
           AND B.PLAN_ORDER_DATE   <= :f_to_date
           AND NVL(B.FKOCS2003, 0)  = 0
           AND NVL(B.PRN_YN,'N')    = 'N'
           AND SUBSTR(B.ORDER_GUBUN, 2, 1) LIKE DECODE( NVL(:f_order_gubun, '%'), '1', '%', NVL(:f_order_gubun, '%') )
           AND C.HOSP_CODE      (+) = B.HOSP_CODE
           AND C.FKOCS6010      (+) = B.FKOCS6010
           AND C.JAEWONIL       (+) = B.JAEWONIL
           AND C.PLAN_ORDER_DATE(+) = B.PLAN_ORDER_DATE
           AND C.INPUT_GUBUN    (+) = B.INPUT_GUBUN
           AND D.HOSP_CODE          = B.HOSP_CODE
           AND D.HANGMOG_CODE       = B.HANGMOG_CODE
           AND TRUNC(B.PLAN_ORDER_DATE) BETWEEN TRUNC(D.START_DATE) AND TRUNC(D.END_DATE)
           AND E.HOSP_CODE      (+) = D.HOSP_CODE
           AND E.SG_CODE        (+) = D.SG_CODE
           AND F.HOSP_CODE          = B.HOSP_CODE
           AND F.CODE_TYPE          = 'INPUT_GUBUN'
           AND F.CODE               = B.INPUT_GUBUN  ) A

WHERE A.ORDER_DATE BETWEEN :f_from_date AND :f_to_date  -- 20120220 khj 날짜범위 에러 수정

ORDER BY A.CONT_KEY";
/**/
#endregion

            #region // Variables Set Columns
            string o_bunho              = string.Empty;
            string o_fkinp1001          = string.Empty;
            string o_fkocs6010          = string.Empty;
            string o_cp_name            = string.Empty;
            string o_order_date         = string.Empty;
            string o_order_end_date     = string.Empty;
            string o_input_gubun        = string.Empty;
            string o_input_gubun_name   = string.Empty;
            string o_order_gubun        = string.Empty;
            string o_order_gubun_ori    = string.Empty;
            string o_order_gubun_name   = string.Empty;
            string o_hangmog_code       = string.Empty;
            string o_hangmog_name       = string.Empty;
            string o_suryang            = string.Empty;
            string o_nalsu              = string.Empty;
            string o_detail             = string.Empty;
            string o_order_remark       = string.Empty;
            string o_nurse_remark       = string.Empty;
            string o_tel_yn             = string.Empty;
            string o_emergency          = string.Empty;
            string o_jusa_name          = string.Empty;
            string o_bogyong_name       = string.Empty;
            string o_jaewonil           = string.Empty;
            string o_pk                 = string.Empty;
            string o_group_ser          = string.Empty;
            string o_mix_group          = string.Empty;
            string o_table_id           = string.Empty;
            string o_confirm_yn         = string.Empty;
            string o_acting_yn          = string.Empty;
            string o_can_plan_change_yn = string.Empty;
            string o_can_confirm_yn     = string.Empty;
            string o_can_acting_yn      = string.Empty;
            string o_can_plan_app_yn    = string.Empty;
            string o_input_name         = string.Empty;
            string o_input_seq          = string.Empty;
            string o_order_end_yn       = string.Empty;
            string o_confirm_name       = string.Empty;
            string o_detail_act_yn      = string.Empty;
            string o_bulyong_check      = string.Empty;
            string o_hold_user          = string.Empty;
            string o_input_gwa          = string.Empty;
            string o_input_doctor       = string.Empty;
            string o_reser_date         = string.Empty;
            string o_acting_date        = string.Empty;
            string o_jundal_table       = string.Empty;
            string o_jundal_part        = string.Empty;
            string o_ocs_flag           = string.Empty;
            string o_souce_order_date   = string.Empty;
            string o_continue_yn        = string.Empty;
            string o_jisi_order_gubun   = string.Empty;
            string o_direct_cont        = string.Empty;
            string o_pkocs2005          = string.Empty;
            string o_pkocs6015          = string.Empty;
            string o_input_id           = string.Empty;
            string o_dv                 = string.Empty;
            string o_check_acting       = string.Empty;
            string o_diff               = string.Empty;
            string o_nurse_act_user     = string.Empty;
            string o_nurse_act_date     = string.Empty;
            string o_nurse_act_time     = string.Empty;
            string o_medi_act_chk       = string.Empty;
            string o_drt_from_datetime  = string.Empty;
            string o_drt_to_datetime    = string.Empty;
            string o_jisi_gubun         = string.Empty;

            #endregion

            dtResult = Service.ExecuteDataTable(cmdText, bindVars);

            if (dtResult != null)
            {
                int row;
                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    #region * 레이아웃에 쿼리 결과 셋팅
                    o_bunho              = dtResult.Rows[i]["bunho"].ToString();
                    o_fkinp1001          = dtResult.Rows[i]["fkinp1001"].ToString();
                    o_fkocs6010          = dtResult.Rows[i]["fkocs6010"].ToString();
                    o_cp_name            = dtResult.Rows[i]["cp_name"].ToString();
                    o_order_date         = dtResult.Rows[i]["order_date"].ToString();
                    o_order_end_date     = dtResult.Rows[i]["order_end_date"].ToString();
                    o_input_gubun        = dtResult.Rows[i]["input_gubun"].ToString();
                    o_input_gubun_name   = dtResult.Rows[i]["input_gubun_name"].ToString();
                    o_order_gubun        = dtResult.Rows[i]["order_gubun"].ToString();
                    o_order_gubun_ori    = dtResult.Rows[i]["order_gubun_ori"].ToString();
                    o_order_gubun_name   = dtResult.Rows[i]["order_gubun_name"].ToString();
                    o_hangmog_code       = dtResult.Rows[i]["hangmog_code"].ToString();
                    o_hangmog_name       = dtResult.Rows[i]["hangmog_name"].ToString();
                    o_suryang            = dtResult.Rows[i]["suryang"].ToString();
                    o_nalsu              = dtResult.Rows[i]["nalsu"].ToString();
                    o_detail             = dtResult.Rows[i]["detail"].ToString();
                    o_order_remark       = dtResult.Rows[i]["order_remark"].ToString();
                    o_nurse_remark       = dtResult.Rows[i]["nurse_remark"].ToString();
                    o_tel_yn             = dtResult.Rows[i]["tel_yn"].ToString();
                    o_emergency          = dtResult.Rows[i]["emergency"].ToString();
                    o_jusa_name          = dtResult.Rows[i]["jusa_name"].ToString();
                    o_bogyong_name       = dtResult.Rows[i]["bogyong_name"].ToString();
                    o_jaewonil           = dtResult.Rows[i]["jaewonil"].ToString();
                    o_pk                 = dtResult.Rows[i]["pk"].ToString();
                    o_group_ser          = dtResult.Rows[i]["group_ser"].ToString();
                    o_mix_group          = dtResult.Rows[i]["mix_group"].ToString();
                    o_table_id           = dtResult.Rows[i]["table_id"].ToString();
                    o_confirm_yn         = dtResult.Rows[i]["confirm_yn"].ToString();
                    o_acting_yn          = dtResult.Rows[i]["acting_yn"].ToString();
                    o_can_plan_change_yn = dtResult.Rows[i]["can_plan_change_yn"].ToString();
                    o_can_confirm_yn     = dtResult.Rows[i]["can_confirm_yn"].ToString();
                    o_can_acting_yn      = dtResult.Rows[i]["can_acting_yn"].ToString();
                    o_can_plan_app_yn    = dtResult.Rows[i]["can_plan_app_yn"].ToString();
                    o_input_name         = dtResult.Rows[i]["input_name"].ToString();
                    o_input_seq          = dtResult.Rows[i]["input_seq"].ToString();
                    o_order_end_yn       = dtResult.Rows[i]["order_end_yn"].ToString();
                    o_confirm_name       = dtResult.Rows[i]["confirm_name"].ToString();
                    o_detail_act_yn      = dtResult.Rows[i]["detail_act_yn"].ToString();
                    o_bulyong_check      = dtResult.Rows[i]["bulyong_check"].ToString();
                    o_hold_user          = dtResult.Rows[i]["nurse_hold_user"].ToString();
                    o_input_gwa          = dtResult.Rows[i]["input_gwa"].ToString();
                    o_input_doctor       = dtResult.Rows[i]["input_doctor"].ToString();
                    o_reser_date         = dtResult.Rows[i]["reser_date"].ToString();
                    o_acting_date        = dtResult.Rows[i]["acting_date"].ToString();
                    o_jundal_table       = dtResult.Rows[i]["jundal_table"].ToString();
                    o_jundal_part        = dtResult.Rows[i]["jundal_part"].ToString();
                    o_ocs_flag           = dtResult.Rows[i]["ocs_flag"].ToString();
                    o_souce_order_date   = dtResult.Rows[i]["source_order_date"].ToString();
                    o_continue_yn        = dtResult.Rows[i]["continue_yn"].ToString();
                    o_jisi_order_gubun   = dtResult.Rows[i]["jisi_order_gubun"].ToString();
                    o_direct_cont        = dtResult.Rows[i]["direct_cont"].ToString();
                    o_pkocs2005          = dtResult.Rows[i]["pkocs2005"].ToString();
                    o_pkocs6015          = dtResult.Rows[i]["pkocs6015"].ToString();
                    o_input_id           = dtResult.Rows[i]["input_id"].ToString();
                    o_dv                 = dtResult.Rows[i]["dv"].ToString();
                    o_check_acting       = dtResult.Rows[i]["check_acting"].ToString();
                    o_diff               = dtResult.Rows[i]["diff"].ToString();
                    o_nurse_act_user     = dtResult.Rows[i]["nurse_act_user"].ToString();
                    o_nurse_act_date     = dtResult.Rows[i]["nurse_act_date"].ToString();
                    o_nurse_act_time     = dtResult.Rows[i]["nurse_act_time"].ToString();
                    o_medi_act_chk       = dtResult.Rows[i]["medi_act_chk"].ToString();
                    o_drt_from_datetime  = dtResult.Rows[i]["drt_from_datetime"].ToString();
                    o_drt_to_datetime    = dtResult.Rows[i]["drt_to_datetime"].ToString();
                    o_jisi_gubun         = dtResult.Rows[i]["jisi_gubun"].ToString();



                    //DateTime drt_from_datetime = DateTime.Parse(o_drt_from_datetime


                    row = dloItemData.InsertRow(-1);    // 로우 추가

                    dloItemData.SetItemValue(row, "bunho"             , o_bunho);
                    dloItemData.SetItemValue(row, "fkinp1001"         , o_fkinp1001);
                    dloItemData.SetItemValue(row, "fkocs6010"         , o_fkocs6010);
                    dloItemData.SetItemValue(row, "cp_name"           , o_cp_name);
                    dloItemData.SetItemValue(row, "order_date"        , o_order_date);
                    dloItemData.SetItemValue(row, "order_end_date"    , o_order_end_date);
                    dloItemData.SetItemValue(row, "input_gubun"       , o_input_gubun);
                    dloItemData.SetItemValue(row, "input_gubun_name"  , o_input_gubun_name);
                    dloItemData.SetItemValue(row, "order_gubun"       , o_order_gubun);
                    dloItemData.SetItemValue(row, "order_gubun_ori"   , o_order_gubun_ori);
                    dloItemData.SetItemValue(row, "order_gubun_name"  , o_order_gubun_name);
                    dloItemData.SetItemValue(row, "hangmog_code"      , o_hangmog_code);
                    //if (o_continue_yn.Equals("Y"))
                    //{
                    //    //dloItemData.SetItemValue(row, "hangmog_name", "【 継続 】\n\r" + o_hangmog_name);
                    //}
                    //else
                    //{
                        dloItemData.SetItemValue(row, "hangmog_name", o_hangmog_name);
                    //}

                    dloItemData.SetItemValue(row, "suryang"           , o_suryang);
                    dloItemData.SetItemValue(row, "nalsu"             , o_nalsu);
                    dloItemData.SetItemValue(row, "detail"            , o_detail);
                    dloItemData.SetItemValue(row, "order_remark"      , o_order_remark);
                    dloItemData.SetItemValue(row, "nurse_remark"      , o_nurse_remark);
                    dloItemData.SetItemValue(row, "tel_yn"            , o_tel_yn);
                    dloItemData.SetItemValue(row, "emergency"         , o_emergency);
                    dloItemData.SetItemValue(row, "jusa_name"         , o_jusa_name);
                    dloItemData.SetItemValue(row, "bogyong_name"      , o_bogyong_name);
                    dloItemData.SetItemValue(row, "jaewonil"          , o_jaewonil);
                    dloItemData.SetItemValue(row, "pk"                , o_pk);
                    dloItemData.SetItemValue(row, "group_ser"         , o_group_ser);
                    dloItemData.SetItemValue(row, "mix_group"         , o_mix_group);
                    dloItemData.SetItemValue(row, "table_id"          , o_table_id);
                    dloItemData.SetItemValue(row, "confirm_yn"        , o_confirm_yn);
                    dloItemData.SetItemValue(row, "acting_yn"         , o_acting_yn);
                    dloItemData.SetItemValue(row, "can_plan_change_yn", o_can_plan_change_yn);
                    dloItemData.SetItemValue(row, "can_confirm_yn"    , o_can_confirm_yn);
                    dloItemData.SetItemValue(row, "can_acting_yn"     , o_can_acting_yn);
                    dloItemData.SetItemValue(row, "can_plan_app_yn"   , o_can_plan_app_yn);
                    dloItemData.SetItemValue(row, "input_name"        , o_input_name);
                    dloItemData.SetItemValue(row, "input_seq"         , o_input_seq);
                    dloItemData.SetItemValue(row, "order_end_yn"      , o_order_end_yn);
                    dloItemData.SetItemValue(row, "confirm_name"      , o_confirm_name);
                    dloItemData.SetItemValue(row, "detail_act_yn"     , o_detail_act_yn);
                    dloItemData.SetItemValue(row, "bulyong_check"     , o_bulyong_check);
                    dloItemData.SetItemValue(row, "hold_user"         , o_hold_user);
                    dloItemData.SetItemValue(row, "input_gwa"         , o_input_gwa);
                    dloItemData.SetItemValue(row, "input_doctor"      , o_input_doctor);
                    dloItemData.SetItemValue(row, "reser_date"        , o_reser_date);
                    dloItemData.SetItemValue(row, "acting_date"       , o_acting_date);
                    dloItemData.SetItemValue(row, "jundal_table"      , o_jundal_table);
                    dloItemData.SetItemValue(row, "jundal_part"       , o_jundal_part);
                    dloItemData.SetItemValue(row, "ocs_flag"          , o_ocs_flag);
                    dloItemData.SetItemValue(row, "source_order_date" , o_souce_order_date);
                    dloItemData.SetItemValue(row, "continue_yn"       , o_continue_yn);
                    dloItemData.SetItemValue(row, "jisi_order_gubun"  , o_jisi_order_gubun);
                    dloItemData.SetItemValue(row, "direct_cont"       , o_direct_cont);
                    dloItemData.SetItemValue(row, "pkocs2005"         , o_pkocs2005);
                    dloItemData.SetItemValue(row, "pkocs6015"         , o_pkocs6015);
                    dloItemData.SetItemValue(row, "input_id"          , o_input_id);
                    dloItemData.SetItemValue(row, "dv"                , o_dv);
                    dloItemData.SetItemValue(row, "check_acting"      , o_check_acting);
                    dloItemData.SetItemValue(row, "diff"              , o_diff);
                    dloItemData.SetItemValue(row, "nurse_act_user"    , o_nurse_act_user);
                    dloItemData.SetItemValue(row, "nurse_act_date"    , o_nurse_act_date);
                    dloItemData.SetItemValue(row, "nurse_act_time"    , o_nurse_act_time);
                    dloItemData.SetItemValue(row, "medi_act_chk"      , o_medi_act_chk);
                    dloItemData.SetItemValue(row, "drt_from_datetime" , o_drt_from_datetime);
                    dloItemData.SetItemValue(row, "drt_to_datetime"   , o_drt_to_datetime);
                    dloItemData.SetItemValue(row, "jisi_gubun"        , o_jisi_gubun);

                    #endregion
                    
                    #region * 연속지시사항 처리    
                    if(!o_table_id.Equals("OCS6015") &&
                        o_continue_yn.Equals("Y") )
                    {
                        //o_hangmog_name = "【 継続 】▶▶▶ \n\r" + o_hangmog_name;
                        //cmdText = @"SELECT TO_DATE(:f_to_date, 'YYYY/MM/DD') - TO_DATE(:f_from_date, 'YYYY/MM/DD') FROM DUAL";
                        //bindVars.Clear();
                        //bindVars.Add("f_from_date", o_order_date);
                        //bindVars.Add("f_to_date",   o_order_end_date);
                        //retVal = Service.ExecuteScalar(cmdText, bindVars);

                        //if (!TypeCheck.IsNull(retVal))
                        //{
                        //    for (int j = 0; j < Convert.ToInt32(retVal); j++)
                        //    {
                        //        cmdText = "SELECT TO_CHAR(TO_DATE(:o_order_date, 'YYYY/MM/DD') + 1, 'YYYY/MM/DD') FROM DUAL";
                        //        bindVars.Clear();
                        //        bindVars.Add("o_order_date", o_order_date);
                        //        o_order_date = Service.ExecuteScalar(cmdText, bindVars).ToString();

                        //        row = dloItemData.InsertRow(-1);    // 로우 추가

                        //        dloItemData.SetItemValue(row, "bunho"             , o_bunho);
                        //        dloItemData.SetItemValue(row, "fkinp1001"         , o_fkinp1001);
                        //        dloItemData.SetItemValue(row, "fkocs6010"         , o_fkocs6010);
                        //        dloItemData.SetItemValue(row, "cp_name"           , o_cp_name);
                        //        dloItemData.SetItemValue(row, "order_date"        , o_order_date);
                        //        dloItemData.SetItemValue(row, "order_end_date"    , o_order_end_date);
                        //        dloItemData.SetItemValue(row, "input_gubun"       , o_input_gubun);
                        //        dloItemData.SetItemValue(row, "input_gubun_name"  , o_input_gubun_name);
                        //        dloItemData.SetItemValue(row, "order_gubun"       , o_order_gubun);
                        //        dloItemData.SetItemValue(row, "order_gubun_name"  , o_order_gubun_name);
                        //        dloItemData.SetItemValue(row, "hangmog_code"      , o_hangmog_code);
                        //        dloItemData.SetItemValue(row, "hangmog_name"      , o_hangmog_name);
                        //        dloItemData.SetItemValue(row, "suryang"           , o_suryang);
                        //        dloItemData.SetItemValue(row, "nalsu"             , o_nalsu);
                        //        dloItemData.SetItemValue(row, "detail"            , o_detail);
                        //        dloItemData.SetItemValue(row, "order_remark"      , o_order_remark);
                        //        dloItemData.SetItemValue(row, "nurse_remark"      , o_nurse_remark);
                        //        dloItemData.SetItemValue(row, "tel_yn"            , o_tel_yn);
                        //        dloItemData.SetItemValue(row, "emergency"         , o_emergency);
                        //        dloItemData.SetItemValue(row, "jusa_name"         , o_jusa_name);
                        //        dloItemData.SetItemValue(row, "bogyong_name"      , o_bogyong_name);
                        //        dloItemData.SetItemValue(row, "jaewonil"          , o_jaewonil);
                        //        dloItemData.SetItemValue(row, "pk"                , o_pk);
                        //        dloItemData.SetItemValue(row, "group_ser"         , o_group_ser);
                        //        dloItemData.SetItemValue(row, "mix_group"         , o_mix_group);
                        //        dloItemData.SetItemValue(row, "table_id"          , o_table_id);
                        //        dloItemData.SetItemValue(row, "confirm_yn"        , o_confirm_yn);
                        //        dloItemData.SetItemValue(row, "acting_yn"         , o_acting_yn);
                        //        dloItemData.SetItemValue(row, "can_plan_change_yn", o_can_plan_change_yn);
                        //        dloItemData.SetItemValue(row, "can_confirm_yn"    , o_can_confirm_yn);
                        //        dloItemData.SetItemValue(row, "can_acting_yn"     , o_can_acting_yn);
                        //        dloItemData.SetItemValue(row, "can_plan_app_yn"   , o_can_plan_app_yn);
                        //        dloItemData.SetItemValue(row, "input_name"        , "");
                        //        dloItemData.SetItemValue(row, "input_seq"         , o_input_seq);
                        //        dloItemData.SetItemValue(row, "order_end_yn"      , "N");
                        //        dloItemData.SetItemValue(row, "confirm_name"      , "");
                        //        dloItemData.SetItemValue(row, "detail_act_yn"     , "N");
                        //        dloItemData.SetItemValue(row, "bulyong_check"     , "N");
                        //        dloItemData.SetItemValue(row, "hold_user"         , "");
                        //        dloItemData.SetItemValue(row, "input_gwa"         , "");
                        //        dloItemData.SetItemValue(row, "input_doctor"      , "");
                        //        dloItemData.SetItemValue(row, "reser_date"        , "");
                        //        dloItemData.SetItemValue(row, "acting_date"       , "");
                        //        dloItemData.SetItemValue(row, "jundal_table"      , "");
                        //        dloItemData.SetItemValue(row, "jundal_part"       , "");
                        //        dloItemData.SetItemValue(row, "ocs_flag"          , o_ocs_flag);
                        //        dloItemData.SetItemValue(row, "source_order_date"  , o_souce_order_date);
                        //        dloItemData.SetItemValue(row, "continue_yn"       , o_continue_yn);
                        //        dloItemData.SetItemValue(row, "jisi_order_gubun"  , o_jisi_order_gubun);
                        //        dloItemData.SetItemValue(row, "direct_cont"       , o_direct_cont);
                        //        dloItemData.SetItemValue(row, "pkocs"             , o_pkocs);
                        //    }
                        //}
                    }
                    else if(!o_table_id.Equals("OCS6015") &&
                            Convert.ToInt32(o_order_date.Replace("/", "")) <= Convert.ToInt32(o_order_end_date.Replace("/", "")))
                    {
                        //cmdText = @"SELECT TO_DATE(:f_to_date, 'YYYY/MM/DD') - TO_DATE(:f_from_date, 'YYYY/MM/DD') FROM DUAL";
                        //bindVars.Clear();
                        //bindVars.Add("f_from_date", o_order_date);
                        //bindVars.Add("f_to_date", o_order_end_date);
                        //retVal = Service.ExecuteScalar(cmdText, bindVars);

                        //if (!TypeCheck.IsNull(retVal))
                        //{
                        //    for (int j = 0; j < Convert.ToInt32(retVal); j++)
                        //    {
                        //        cmdText = "SELECT TO_CHAR(TO_DATE(:o_order_date, 'YYYY/MM/DD') + 1, 'YYYY/MM/DD') FROM DUAL";
                        //        bindVars.Clear();
                        //        bindVars.Add("o_order_date", o_order_date);
                        //        o_order_date = Service.ExecuteScalar(cmdText, bindVars).ToString();

                        //        row = dloItemData.InsertRow(-1);    // 로우 추가

                        //        dloItemData.SetItemValue(row, "bunho", o_bunho);
                        //        dloItemData.SetItemValue(row, "fkinp1001", o_fkinp1001);
                        //        dloItemData.SetItemValue(row, "fkocs6010", o_fkocs6010);
                        //        dloItemData.SetItemValue(row, "cp_name", o_cp_name);
                        //        dloItemData.SetItemValue(row, "order_date", o_order_date);
                        //        dloItemData.SetItemValue(row, "order_end_date", o_order_end_date);
                        //        dloItemData.SetItemValue(row, "input_gubun", o_input_gubun);
                        //        dloItemData.SetItemValue(row, "input_gubun_name", o_input_gubun_name);
                        //        dloItemData.SetItemValue(row, "order_gubun", o_order_gubun);
                        //        dloItemData.SetItemValue(row, "order_gubun_name", o_order_gubun_name);
                        //        dloItemData.SetItemValue(row, "hangmog_code", o_hangmog_code);
                        //        dloItemData.SetItemValue(row, "hangmog_name", o_hangmog_name);
                        //        dloItemData.SetItemValue(row, "suryang", o_suryang);
                        //        dloItemData.SetItemValue(row, "nalsu", o_nalsu);
                        //        dloItemData.SetItemValue(row, "detail", o_detail);
                        //        dloItemData.SetItemValue(row, "order_remark", o_order_remark);
                        //        dloItemData.SetItemValue(row, "nurse_remark", o_nurse_remark);
                        //        dloItemData.SetItemValue(row, "tel_yn", o_tel_yn);
                        //        dloItemData.SetItemValue(row, "emergency", o_emergency);
                        //        dloItemData.SetItemValue(row, "jusa_name", o_jusa_name);
                        //        dloItemData.SetItemValue(row, "bogyong_name", o_bogyong_name);
                        //        dloItemData.SetItemValue(row, "jaewonil", o_jaewonil);
                        //        dloItemData.SetItemValue(row, "pk", o_pk);
                        //        dloItemData.SetItemValue(row, "group_ser", o_group_ser);
                        //        dloItemData.SetItemValue(row, "mix_group", o_mix_group);
                        //        dloItemData.SetItemValue(row, "table_id", o_table_id);
                        //        dloItemData.SetItemValue(row, "confirm_yn", o_confirm_yn);
                        //        dloItemData.SetItemValue(row, "acting_yn", o_acting_yn);
                        //        dloItemData.SetItemValue(row, "can_plan_change_yn", o_can_plan_change_yn);
                        //        dloItemData.SetItemValue(row, "can_confirm_yn", o_can_confirm_yn);
                        //        dloItemData.SetItemValue(row, "can_acting_yn", o_can_acting_yn);
                        //        dloItemData.SetItemValue(row, "can_plan_app_yn", o_can_plan_app_yn);
                        //        dloItemData.SetItemValue(row, "input_name", "");
                        //        dloItemData.SetItemValue(row, "input_seq", o_input_seq);
                        //        dloItemData.SetItemValue(row, "order_end_yn", "N");
                        //        dloItemData.SetItemValue(row, "confirm_name", "");
                        //        dloItemData.SetItemValue(row, "detail_act_yn", "N");
                        //        dloItemData.SetItemValue(row, "bulyong_check", "N");
                        //        dloItemData.SetItemValue(row, "hold_user", "");
                        //        dloItemData.SetItemValue(row, "input_gwa", "");
                        //        dloItemData.SetItemValue(row, "input_doctor", "");
                        //        dloItemData.SetItemValue(row, "reser_date", "");
                        //        dloItemData.SetItemValue(row, "acting_date", "");
                        //        dloItemData.SetItemValue(row, "jundal_table", "");
                        //        dloItemData.SetItemValue(row, "jundal_part", "");
                        //        dloItemData.SetItemValue(row, "ocs_flag", o_ocs_flag);
                        //        dloItemData.SetItemValue(row, "source_order_date", o_souce_order_date);
                        //        dloItemData.SetItemValue(row, "continue_yn", o_continue_yn);
                        //        dloItemData.SetItemValue(row, "jisi_order_gubun", o_jisi_order_gubun);
                        //        dloItemData.SetItemValue(row, "direct_cont", o_direct_cont);
                        //        dloItemData.SetItemValue(row, "pkocs", o_pkocs);
                        //    }
                        //}
                    }
                    #endregion
                }
            }
            else return false;
            return true;
        }
        #endregion

        #region // DayApplyOCS6013() //
        private bool DayApplyOCS6013()
        {
            #region * 메소드 변수 초기화
            string f_bunho     = string.Empty;
            string f_fkinp1001 = string.Empty;
            string f_from_date = string.Empty;
            string f_to_date   = string.Empty;
            string f_pkocs6013 = string.Empty;
            string f_user_id   = string.Empty;

            string t_errmsg    = string.Empty;
            string t_flag      = string.Empty;

            //string spName = "PR_OCS_APPLY_PLAN_ORDER";

            string cmdText = @"UPDATE OCS2003
                                  SET NURSE_CONFIRM_USER = DECODE(NVL(NURSE_CONFIRM_USER, 'N'), 'N', :f_user_id                , NURSE_CONFIRM_USER), 
                                      NURSE_CONFIRM_DATE = DECODE(NVL(NURSE_CONFIRM_USER, 'N'), 'N', TRUNC(SYSDATE)            , NURSE_CONFIRM_DATE),
                                      NURSE_CONFIRM_TIME = DECODE(NVL(NURSE_CONFIRM_USER, 'N'), 'N', TO_CHAR(SYSDATE, 'HH24MI'), NURSE_CONFIRM_TIME),
                                      NURSE_PICKUP_USER  = :f_user_id             ,
                                      NURSE_PICKUP_DATE  = TRUNC(SYSDATE)         ,
                                      NURSE_PICKUP_TIME  = TO_CHAR(SYSDATE,'HH24MM')
                                WHERE HOSP_CODE            = :f_hosp_code
                                  AND BUNHO                = :f_bunho
                                  AND FKINP1001            = :f_fkinp1001
                                  AND NVL(RESER_DATE, NVL(HOPE_DATE, ORDER_DATE))          >= :f_from_date
                                  AND ORDER_DATE          <= :f_to_date
                                --  AND NVL(DISPLAY_YN,'Y')  = 'Y'
                                  AND NVL(PRN_YN,'N')      = 'N'
                                  --AND NVL(DC_YN,'N')       = 'N'
                                  AND FN_OCS_BULYONG_CHECK(HANGMOG_CODE, ORDER_DATE) = 'N'
                                  AND ( ( :f_pkocs6013 = 0 )
                                       OR
                                        ( :f_pkocs6013 = 1 AND SUBSTR(ORDER_GUBUN, 2, 1) IN ('C', 'D') )
                                       OR
                                        ( :f_pkocs6013 = 2 AND SUBSTR(ORDER_GUBUN, 2, 1) IN ('A', 'B') ) )
                                  AND NURSE_PICKUP_DATE IS NULL";
            BindVarCollection bindVars = new BindVarCollection();
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            #endregion

            if (dloProcessInfo.RowCount > 0)
            {
                #region @ 변수 셋팅
                f_bunho     = dloProcessInfo.GetItemString(0, "bunho"    );
                f_fkinp1001 = dloProcessInfo.GetItemString(0, "fkinp1001");
                f_from_date = dloProcessInfo.GetItemString(0, "from_date");
                f_to_date   = dloProcessInfo.GetItemString(0, "to_date"  );
                f_pkocs6013 = dloProcessInfo.GetItemString(0, "pkocs6013");
                f_user_id   = dloProcessInfo.GetItemString(0, "user_id"  );

                //if (f_pkocs6013.Equals("1"))
                //{
                //    f_to_date = "9999/12/31";
                //}

                // UPDATE 바인드 변수 셋팅
                bindVars.Add("f_bunho",     f_bunho     );
                bindVars.Add("f_fkinp1001", f_fkinp1001 );
                bindVars.Add("f_from_date", f_from_date );
                bindVars.Add("f_to_date",   f_to_date   );
                bindVars.Add("f_pkocs6013", f_pkocs6013 );
                bindVars.Add("f_user_id",   f_user_id   );
                bindVars.Add("f_hosp_code", mHospCode   );

                // PROCEDURE INPUT 변수 셋팅
                inputList.Add(f_bunho);
                inputList.Add(f_fkinp1001);
                inputList.Add(f_from_date);
                inputList.Add(f_to_date);
                inputList.Add(f_pkocs6013);
                inputList.Add(f_user_id);
                #endregion

                try
                {
                    Service.BeginTransaction();
                    
                    if (!Service.ExecuteNonQuery(cmdText, bindVars))
                    {
                        throw new Exception(Service.ErrFullMsg);
                    }

                    //if(Service.ExecuteProcedure(spName, inputList, outputList))
                    //{
                    //    t_flag = outputList[1].ToString();

                    //    if (!t_flag.Equals("0"))
                    //    {
                    //        throw new Exception(outputList[0].ToString());
                    //    }
                    //}
                    //else
                    //    throw new Exception(Service.ErrFullMsg);
                    
                }
                catch (Exception xe)
                {
                    Service.RollbackTransaction();

                    XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace, "DayApplyOCS6013() ERROR");
                    return false;
                }

                Service.CommitTransaction();
            }

            return true;
        }
        #endregion

        #region // ApplyOCS6013() //
        private bool ApplyOCS6013()
        {
            if (dloProcessInfo1.RowCount < 1) return false;

            string spName = "PR_OCS_APPLY_PLAN_ORDER_GROUP";

            ArrayList inputList = new ArrayList();
            inputList.Add(dloProcessInfo1.GetItemString(0, "bunho")      );
            inputList.Add(dloProcessInfo1.GetItemString(0, "fkinp1001")  );
            inputList.Add(dloProcessInfo1.GetItemString(0, "fkocs6010")  );
            inputList.Add(dloProcessInfo1.GetItemString(0, "plan_date")  );
            inputList.Add(dloProcessInfo1.GetItemString(0, "input_gubun"));
            inputList.Add(dloProcessInfo1.GetItemString(0, "order_gubun"));
            inputList.Add(dloProcessInfo1.GetItemString(0, "group_ser")  );
            inputList.Add(dloProcessInfo1.GetItemString(0, "user_id")    );
            ArrayList outputList = new ArrayList();

            try
            {
                Service.BeginTransaction();

                if (!Service.ExecuteProcedure(spName, inputList, outputList))
                {
                    throw new Exception(Service.ErrFullMsg);
                }

                if (outputList[1].ToString().Equals("1"))
                {
                    throw new Exception(outputList[0].ToString());
                }

                if (!outputList[1].ToString().Equals("0"))
                {
                    throw new Exception(outputList[0].ToString());
                }
            }
            catch (Exception xe)
            {
                Service.RollbackTransaction();
                XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace, "ApplyOCS6013() ERROR");
                return false;
            }

            Service.CommitTransaction();
            return true;
        }
        #endregion

        #endregion


        #region [ XSavePerformer ]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private OCS6010U10 parent = null;
            public XSavePerformer(OCS6010U10 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                //Grid에서 넘어온 Bind 변수에 q_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                string t_old_order_date = "";   /* 비교예정일자     */
                string t_old_input_gubun = "";  /* 비교입력구분     */
                string t_group_ser = "";
                string t_jaewonil = "";
                string t_flag = "";
                string t_pk_seq = "";
                string spName = "PR_OCS_CREATE_PLAN_JAEWONIL"; /* */

                if (item.RowState == DataRowState.Added || item.RowState == DataRowState.Deleted || item.RowState == DataRowState.Modified)
                {
                    switch (item.BindVarList["f_table_id"].VarValue)
                    {
                        case "OCS2003":

                            /* OCS2003 간호확인 */
                            if (!item.BindVarList["f_del_flag"].VarValue.Equals("Y"))
                            {
                                /* 간호확인 */

                                if (!TypeCheck.IsNull(item.BindVarList["f_nurse_act_user"].VarValue))
                                {
                                    cmdText = @"UPDATE OCS2003
                                                   SET UPD_ID             = :q_user_id      ,
                                                       UPD_DATE           = SYSDATE         ,
                                                       NURSE_ACT_USER     = :f_nurse_act_user ,
                                                       NURSE_ACT_DATE     = :f_nurse_act_date            
                                                 WHERE HOSP_CODE          = :f_hosp_code
                                                   AND PKOCS2003          = :f_pk";
                                }
                                else if(!TypeCheck.IsNull(item.BindVarList["f_nurse_act_date"].VarValue))
                                {   
                                    cmdText = @"UPDATE OCS2003
                                                   SET UPD_ID             = :q_user_id      ,
                                                       UPD_DATE           = SYSDATE         ,
                                                       NURSE_ACT_USER     = NULL            ,
                                                       NURSE_ACT_DATE     = NULL     
                                                 WHERE HOSP_CODE          = :f_hosp_code
                                                   AND PKOCS2003          = :f_pk";
                                }
                                else if (item.BindVarList["f_confirm_yn"].VarValue.Equals("Y"))
                                {
                                    cmdText = @"UPDATE OCS2003
                                                   SET UPD_ID             = :q_user_id      ,
                                                       UPD_DATE           = SYSDATE         ,
                                                       NURSE_CONFIRM_USER = DECODE(NVL(NURSE_CONFIRM_USER, 'N'), 'N', :f_pickup_user            , NURSE_CONFIRM_USER),
                                                       NURSE_CONFIRM_DATE = DECODE(NVL(NURSE_CONFIRM_USER, 'N'), 'N', TRUNC(SYSDATE)            , NURSE_CONFIRM_DATE),
                                                       NURSE_CONFIRM_TIME = DECODE(NVL(NURSE_CONFIRM_USER, 'N'), 'N', TO_CHAR(SYSDATE, 'HH24MI'), NURSE_CONFIRM_TIME),
                                                       NURSE_PICKUP_USER  = :f_pickup_user             ,
                                                       NURSE_PICKUP_DATE  = TRUNC(SYSDATE)             ,
                                                       NURSE_PICKUP_TIME  = TO_CHAR(SYSDATE, 'HH24MI') ,
                                                       NURSE_HOLD_USER    = NULL,
                                                       NURSE_HOLD_DATE    = NULL,
                                                       NURSE_HOLD_TIME    = NULL
                                                 WHERE HOSP_CODE          = :f_hosp_code
                                                   AND PKOCS2003          = :f_pk";
                                }
                                else
                                {
                                    cmdText = @"UPDATE OCS2003
                                                   SET UPD_ID             = :q_user_id,
                                                       UPD_DATE           = SYSDATE   ,
                                                       NURSE_PICKUP_USER  = NULL      ,
                                                       NURSE_PICKUP_DATE  = NULL      ,
                                                       NURSE_PICKUP_TIME  = NULL      ,
                                                       NURSE_ACT_USER     = NULL      ,
                                                       NURSE_ACT_DATE     = NULL      
                                                 WHERE HOSP_CODE          = :f_hosp_code
                                                   AND PKOCS2003          = :f_pk";
                                }
                            }
                            else if(item.BindVarList["f_del_flag"].VarValue.Equals("Y"))
                            {
                                //string cmd_delete = "";
                                ArrayList inputList_d = new ArrayList();
                                inputList_d.Add(item.BindVarList["f_hosp_code"].VarValue);
                                inputList_d.Add(item.BindVarList["f_pk"].VarValue);
                                ArrayList outputList_d = new ArrayList();

                                Service.ExecuteProcedure("PR_OCS_PRN_CANCEL_PROC", inputList_d, outputList_d);


//                                //投薬取消OCS2017
//                                cmd_delete = @" UPDATE OCS2017 A
//                                                   SET UPD_ID       = :q_user_id
//                                                     , UPD_DATE     = SYSDATE
//                                                     , ACTING_DATE  = NULL
//                                                     , ACTING_TIME  = NULL
//                                                     , ACT_USER     = NULL
//                                                 WHERE A.HOSP_CODE = :f_hosp_code
//                                                   AND A.FKOCS2003 = :f_pk
//                                                ";
//                                Service.ExecuteScalar(cmd_delete, item.BindVarList);

//                                //オーダACTING取消OCS2003
//                                cmd_delete = @" UPDATE OCS2003 A
//                                                   SET A.ACTING_DATE = NULL
//                                                     , A.ACTING_TIME = NULL
//                                                     , A.ACTING_DAY  = NULL
//                                                     , A.OCS_FLAG    = '1'
//                                                     , A.ACT_BUSEO   = NULL
//                                                 WHERE A.HOSP_CODE = :f_hosp_code
//                                                   AND A.PKOCS2003 = :f_pk
//                                                ";
//                                Service.ExecuteScalar(cmd_delete, item.BindVarList);

//                                //オーダ削除OCS2003
//                                cmd_delete = @"DELETE OCS2003 A
//                                                WHERE A.HOSP_CODE = :f_hosp_code 
//                                                  AND A.PKOCS2003 = :f_pk
//                                            ";
//                                Service.ExecuteScalar(cmd_delete, item.BindVarList);

//                                //OCS2016
//                                cmd_delete = @" DELETE OCS2016 A
//                                                 WHERE A.HOSP_CODE = :f_hosp_code
//                                                   AND A.FKOCS2003 = :f_pk
//                                                ";
//                                Service.ExecuteScalar(cmd_delete, item.BindVarList);

                                //cmdText = "DELETE OCS2003 WHERE HOSP_CODE = :f_hosp_code AND PKOCS2003 = :f_pk";
                            }

                            break;

                        case "OCS6013":

                            /* f_del_flag */
                            if (!item.BindVarList["f_del_flag"].VarValue.Equals("Y"))
                            {
                                /* 변경된 정보가 없으면 SKIP */
                                if (item.BindVarList["f_order_date"].VarValue.Equals(item.BindVarList["f_origin_order_date"].VarValue) &&
                                    item.BindVarList["f_input_gubun"].VarValue.Equals(item.BindVarList["f_origin_input_gubun"].VarValue))
                                    break;
                                /* 변경된 정보가 없으면 SKIP */

                                /* PR_OCS_CREATE_PLAN_JAEWONIL */
                                ArrayList inputList = new ArrayList();
                                inputList.Add(item.BindVarList["f_fkocs6010"].VarValue);
                                inputList.Add(item.BindVarList["f_order_date"].VarValue);
                                inputList.Add("q_user_id");
                                ArrayList outputList = new ArrayList();

                                if (Service.ExecuteProcedure(spName, inputList, outputList))
                                {
                                    t_jaewonil = outputList[0].ToString();
                                    t_flag     = outputList[1].ToString();
                                    if (!t_flag.Equals("0"))
                                    {
                                        this.parent.SetMsg("null", MsgType.Error);
                                        return false;
                                    }

                                    item.BindVarList.Remove("t_jaewonil");
                                    item.BindVarList.Add("t_jaewonil", t_jaewonil);
                                }
                                else
                                {
                                    this.parent.SetMsg(Service.ErrMsg, MsgType.Error);
                                    return false;
                                }
                                /* PR_OCS_CREATE_PLAN_JAEWONIL */

                                /* 비교예정일자 // 비교입력구분     */
                                if (!item.BindVarList["f_order_date"].VarValue.Equals(t_old_order_date) ||
                                    !item.BindVarList["f_input_gubun"].VarValue.Equals(t_old_input_gubun) )
                                {
                                    cmdText = @"SELECT NVL(MAX(GROUP_SER), 0) + 1       T_GROUP_SER
                                                  FROM OCS6013
                                                 WHERE HOSP_CODE       = :f_hosp_code
                                                   AND PLAN_ORDER_DATE = :f_order_date
                                                   AND INPUT_GUBUN     = :f_input_gubun
                                                   AND FKOCS6010       = :f_fkocs6010";
                                    t_group_ser = Service.ExecuteScalar(cmdText, item.BindVarList).ToString();

                                    if (Service.ErrCode != 0)
                                    {
                                        this.parent.SetMsg("ERROR Create group ser ", MsgType.Error);
                                        return false;
                                    }

                                    t_old_order_date = item.BindVarList["f_order_date"].VarValue;
                                    t_old_input_gubun = item.BindVarList["f_input_gubun"].VarValue;
                                }
                                /* 비교예정일자 // 비교입력구분     */

                                cmdText = @"UPDATE OCS6013
                                               SET UPD_ID          = :q_user_id          ,
                                                   UPD_DATE        = SYSDATE             ,
                                                   JAEWONIL        = :t_jaewonil         ,
                                                   PLAN_ORDER_DATE = :f_order_date       ,
                                                   INPUT_GUBUN     = :f_input_gubun      ,
                                                   GROUP_SER       = :t_group_ser
                                             WHERE HOSP_CODE       = :f_hosp_code
                                               AND PKOCS6013       = :f_pk";
                            }
                            else if(item.BindVarList["f_del_flag"].VarValue.Equals("Y"))
                            {
                                /* 삭제 가능 여부 */
                                cmdText = "SELECT DECODE(ref_FKOCS2003, NULL, 'N', 'Y') FROM OCS6013 A WHERE HOSP_CODE = :f_hosp_code AND PKOCS6013 = :f_pk";

                                object tChk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(tChk) && tChk.ToString().Equals("Y"))
                                {
                                    this.parent.SetMsg(Service.ExecuteScalar("SELECT FN_ADM_MSG(2057) FROM DUAL").ToString());
                                    return false;
                                }

                                cmdText = @"DELETE OCS6013
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND PKOCS6013 = :f_pk";
                            }

                            break;

                        case "OCS6015":

                            if (!item.BindVarList["f_del_flag"].VarValue.Equals("Y"))
                            {
                                /* 변경된 정보가 없으면 SKIP */
                                if (item.BindVarList["f_order_date"].VarValue.Equals(item.BindVarList["f_origin_order_date"].VarValue) &&
                                    item.BindVarList["f_input_gubun"].VarValue.Equals(item.BindVarList["f_origin_input_gubun"].VarValue))
                                    break;
                                /* 변경된 정보가 없으면 SKIP */

                                /* PR_OCS_CREATE_PLAN_JAEWONIL */
                                ArrayList inputList = new ArrayList();
                                inputList.Add(item.BindVarList["f_fkocs6010"].VarValue);
                                inputList.Add(item.BindVarList["f_order_date"].VarValue);
                                inputList.Add(item.BindVarList["q_user_id"].VarValue);
                                ArrayList outputList = new ArrayList();
                                
                                if(Service.ExecuteProcedure(spName, inputList, outputList))
                                {
                                    t_jaewonil = outputList[0].ToString();
                                    t_flag     = outputList[1].ToString(); 
                                    if(!t_flag.Equals("0"))
                                    {
                                        this.parent.SetMsg("9999", MsgType.Error);
                                        return false;
                                    }

                                    item.BindVarList.Remove("t_jaewonil");
                                    item.BindVarList.Add("t_jaewonil", t_jaewonil);
                                }
                                else
                                {
                                    this.parent.SetMsg(Service.ErrMsg, MsgType.Error);
                                    return false;
                                }
                                /* PR_OCS_CREATE_PLAN_JAEWONIL */

                                /* CHECK DUP */
                                cmdText = @"SELECT 'Y'
                                              FROM OCS6015
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND FKOCS6010    = :f_fkocs6010
                                               AND JAEWONIL     = :t_jaewonil
                                               AND INPUT_GUBUN  = :f_input_gubun
                                               AND DIRECT_GUBUN = :f_order_gubun
                                               AND DIRECT_CODE  = :f_hangmog_code
                                               AND ROWNUM = 1";
                                object tChk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(tChk) && tChk.ToString().Equals("Y"))
                                {
                                    this.parent.SetMsg("既に同じデータがあります。", MsgType.Error);
                                    return false;
                                }
                                /* CHECK DUP */

                                cmdText = @"SELECT NVL(MAX(PK_SEQ), 0) + 1
                                              FROM OCS6015
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND FKOCS6010    = :f_fkocs6010
                                               AND JAEWONIL     = :t_jaewonil
                                               AND INPUT_GUBUN  = :f_input_gubun";
                                t_pk_seq = Service.ExecuteScalar(cmdText, item.BindVarList).ToString();
                                item.BindVarList.Remove("t_pk_seq");
                                item.BindVarList.Add("t_pk_seq", t_pk_seq);

                                cmdText = @"UPDATE OCS6015
                                               SET UPD_ID          = :q_user_id    ,
                                                   UPD_DATE        = SYSDATE       ,
                                                   JAEWONIL        = :t_jaewonil   ,
                                                   PLAN_FROM_DATE  = :f_order_date ,
                                                   PLAN_TO_DATE    = :f_order_date ,
                                                   INPUT_GUBUN     = :f_input_gubun,
                                                   PK_SEQ          = :t_pk_seq
                                             WHERE HOSP_CODE       = :f_hosp_code
                                               AND FKOCS6010       = :f_fkocs6010
                                               AND INPUT_GUBUN     = :f_origin_input_gubun
                                               AND PLAN_FROM_DATE  = :f_origin_order_date
                                               AND PK_SEQ          = :f_pk";
                            }
                            else if (item.BindVarList["f_del_flag"].VarValue.Equals("Y"))
                            {
                                cmdText = @"SELECT DECODE(SIGN(A.PLAN_FROM_DATE - TO_DATE(:f_order_date, 'YYYY/MM/DD')), 0, 'Y', 'N')
                                              FROM OCS6015 A
                                             WHERE HOSP_CODE       = :f_hosp_code
                                               AND FKOCS6010       = :f_fkocs6010
                                               AND JAEWONIL        = :f_jaewonil
                                               AND INPUT_GUBUN     = :f_input_gubun
                                               AND PK_SEQ          = :f_pk";
                                object tChk = Service.ExecuteScalar(cmdText, item.BindVarList);
                                if (TypeCheck.IsNull(tChk))
                                {
                                    this.parent.SetMsg("NULL", MsgType.Error);
                                    return false;
                                }

                                /* 삭제 가능 여부 */
                                if (!tChk.ToString().Equals("Y"))
                                {
                                    cmdText = @"UPDATE OCS6015
                                                   SET PLAN_TO_DATE = TO_DATE(:f_order_date, 'YYYY/MM/DD') - 1,
                                                       CONTINUE_YN  = 'N'
                                                 WHERE HOSP_CODE    = :f_hosp_code
                                                   AND FKOCS6010    = :f_fkocs6010
                                                   AND JAEWONIL     = :f_jaewonil
                                                   AND INPUT_GUBUN  = :f_input_gubun
                                                   AND PK_SEQ       = :f_pk";
                                }
                                else
                                {
                                    cmdText = @"DELETE OCS6015
                                                 WHERE HOSP_CODE   = :f_hosp_code
                                                   AND FKOCS6010   = :f_fkocs6010
                                                   AND JAEWONIL    = :f_jaewonil
                                                   AND INPUT_GUBUN = :f_input_gubun
                                                   AND PK_SEQ      = :f_pk";

                                    if (Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                    {
                                        cmdText = @"DELETE OCS6016
                                                     WHERE HOSP_CODE   = :f_hosp_code
                                                       AND FKOCS6010   = :f_fkocs6010
                                                       AND JAEWONIL    = :f_jaewonil
                                                       AND INPUT_GUBUN = :f_input_gubun
                                                       AND PK_SEQ      = :f_pk";
                                    }
                                }
                            }

                            break;

                        case "OCS2005":

                            if (item.BindVarList["f_del_flag"].VarValue.Equals("Y"))
                            {
                                object tChk = null;
                                cmdText = @"SELECT COUNT(*)
                                              FROM OCS2015 A
                                             WHERE HOSP_CODE   = :f_hosp_code
                                               AND BUNHO       = :f_bunho
                                               AND FKINP1001   = :f_fkinp1001
                                               AND ORDER_DATE  = :f_source_order_date
                                               AND ACT_DATE    IS NOT NULL
                                               AND INPUT_GUBUN = :f_input_gubun
                                               AND PK_SEQ      = :f_pk";
                                tChk = Service.ExecuteScalar(cmdText, item.BindVarList);
                                if (!TypeCheck.IsNull(tChk) && !tChk.ToString().Equals("0"))
                                {
                                    this.parent.SetMsg(Service.ExecuteScalar("SELECT FN_ADM_MSG(3259) FROM DUAL").ToString(), MsgType.Error);
                                    return false;
                                }

                                cmdText = @"DELETE OCS2006
                                             WHERE HOSP_CODE   = :f_hosp_code
                                               AND BUNHO       = :f_bunho
                                               AND FKINP1001   = :f_fkinp1001
                                               --AND ORDER_DATE  = :f_order_date
                                               AND INPUT_GUBUN = :f_input_gubun
                                               AND PK_SEQ      = :f_pk";

                                if (Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    cmdText = @"DELETE OCS2005
                                                 WHERE HOSP_CODE   = :f_hosp_code
                                                   AND BUNHO       = :f_bunho
                                                   AND FKINP1001   = :f_fkinp1001
                                                   --AND ORDER_DATE  = :f_order_date
                                                   AND INPUT_GUBUN = :f_input_gubun
                                                   AND PK_SEQ      = :f_pk";
                                }
                            }

                            break;
                    }
                }
                if (cmdText == "") return true;
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        #region laySiksaJunpyo_QueyEnd
        private void laySiksaJunpyo_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (laySiksaJunpyo.RowCount > 0)
            {
                dwSiksaJunpyo.Reset();

                dwSiksaJunpyo.FillData(laySiksaJunpyo.LayoutTable);

                if (dwSiksaJunpyo.RowCount > 0)
                {
                    dwSiksaJunpyo.Refresh();
                    dwSiksaJunpyo.Print();
                }
            }
        }
        #endregion

        private int location_X = -1;
        private int location_Y = -1;
        private void mtxPlanMgt_ItemClick(object sender, XMatrixItemClickEventArgs e)
        {
            Hashtable returnBack = new Hashtable();

            if (mtxPlanMgt.SelectedItems.Count > 0)
            {
                int selectedRow = int.Parse(mtxPlanMgt.SelectedItems[0].Tag.ToString());

                //if (dloItemData.GetItemString(selectedRow, "acting_yn") != "Y" || 
                //    (dloItemData.GetItemString(selectedRow, "can_acting_yn") == "N" && dloItemData.GetItemString(selectedRow, "table_id") == "OCS2005")
                //   ) return;

                string table_id = dloItemData.GetItemString(selectedRow, "table_id");
                //if (table_id != "OCS2005") return;

                Hashtable htOrderInfo = new Hashtable();
                htOrderInfo.Add("table_id",         table_id);
                htOrderInfo.Add("bunho",            dloItemData.GetItemString(selectedRow, "bunho"));
                htOrderInfo.Add("fkinp1001",        dloItemData.GetItemString(selectedRow, "fkinp1001"));
                htOrderInfo.Add("input_gubun",      dloItemData.GetItemString(selectedRow, "input_gubun"));
                htOrderInfo.Add("order_date",       dloItemData.GetItemString(selectedRow, "source_order_date"));
                htOrderInfo.Add("pk_seq",           dloItemData.GetItemString(selectedRow, "pk"));
                htOrderInfo.Add("act_date",         dloItemData.GetItemString(selectedRow, "order_date"));
                htOrderInfo.Add("order_gubun",      dloItemData.GetItemString(selectedRow, "order_gubun"));
                htOrderInfo.Add("pk",               dloItemData.GetItemString(selectedRow, "pk"));
                htOrderInfo.Add("jisi_order_gubun", dloItemData.GetItemString(selectedRow, "jisi_order_gubun"));

                location_X = Control.MousePosition.X;
                location_Y = Control.MousePosition.Y;

                returnBack = OrderInfoSet(htOrderInfo);

                if (TypeCheck.IsNull(returnBack) || returnBack.Count == 0) return;

                if (frmOrderInfo != null)
                    frmOrderInfo.Dispose();
                frmOrderInfo = new frmOrderInfo();
                frmOrderInfo.Size = new Size(Convert.ToInt32(returnBack["width"]), Convert.ToInt32(returnBack["height"]));

                // 
                if (Math.Abs(location_X + frmOrderInfo.Size.Width) > Math.Abs(Screen.PrimaryScreen.WorkingArea.Width - 5))
                {
                    location_X = location_X - frmOrderInfo.Size.Width + 15;
                }
                if (Math.Abs(location_Y + frmOrderInfo.Size.Height) > Math.Abs(Screen.PrimaryScreen.WorkingArea.Height - 65))
                {
                    location_Y = location_Y - frmOrderInfo.Size.Height + 15;
                }

                frmOrderInfo.DBX_TEXT = returnBack["text"].ToString();

                frmOrderInfo.Location = new Point(location_X - 15, location_Y - 40);

                frmOrderInfo.Show();

            }
        }

        #region [ btnOpenOrder_Click / OrderInfoSet ] - オーダ画面をオープン
        private Hashtable OrderInfoSet(Hashtable htOrderInfo)
        {
            Hashtable htReturn = new Hashtable();
            DataTable dtResult = new DataTable();
            string dbxText = string.Empty;
            string cmdText = string.Empty;
            int width  = 0;
            int height = 0;

            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_bunho",       htOrderInfo["bunho"].ToString());
            bindVars.Add("f_fkinp1001",   htOrderInfo["fkinp1001"].ToString());
            bindVars.Add("f_input_gubun", htOrderInfo["input_gubun"].ToString());
            bindVars.Add("f_order_date",  htOrderInfo["order_date"].ToString());
            bindVars.Add("f_pk_seq",      htOrderInfo["pk_seq"].ToString());
            bindVars.Add("f_act_date",    htOrderInfo["act_date"].ToString());
            bindVars.Add("f_pk",          htOrderInfo["pk"].ToString());

            switch(htOrderInfo["table_id"].ToString())
            {
                case "OCS2005":
                    switch (htOrderInfo["jisi_order_gubun"].ToString())
                    {
                        case "1":  // 指示-インスリン
                        case "2":
                            cmdText = @"SELECT B.PKOCS2016    ,
                                               B.FKOCS2015    ,
                                               FN_BAS_TO_JAPAN_DATE_CONVERT(4, B.UPD_DATE) ACT_DATE,
                                               DECODE(B.TIME_GUBUN, 0, '1次', 1, '2次', 2, '3次', 3, '4次', 4, '5次', 5, '6次') TIME_GUBUN,
                                               TO_CHAR(B.UPD_DATE, 'HH24:MI') ACT_TIME,
                                               B.SURYANG || '単位sc' SURYANG ,
                                               B.BLOOD_SUGAR,
                                               NVL(B.SYS_ID, A.ACT_ID) || ' / ' || C.USER_NM ACT_USER
                                          FROM OCS2015 A ,
                                               OCS2016 B ,
                                               ADM3200 C
                                         WHERE A.HOSP_CODE       = FN_ADM_LOAD_HOSP_CODE()
                                           AND A.BUNHO           = :f_bunho
                                           AND A.FKINP1001       = :f_fkinp1001
                                           AND A.INPUT_GUBUN     = :f_input_gubun
                                           AND A.ORDER_DATE      = :f_order_date
                                           AND A.PK_SEQ          = :f_pk_seq 
                                           AND TRUNC(A.ACT_DATE) = :f_act_date
                                           --
                                           AND B.HOSP_CODE       = A.HOSP_CODE
                                           AND B.FKOCS2015       = A.PKOCS2015
                                           --
                                           AND C.HOSP_CODE       = A.HOSP_CODE
                                           AND C.USER_ID         = NVL(B.SYS_ID, A.ACT_ID)
                                         ORDER BY B.TIME_GUBUN";

                            dtResult = Service.ExecuteDataTable(cmdText, bindVars);

                            if (dtResult != null && dtResult.Rows.Count > 0)
                            {
                                dbxText = "◎詳細情報◎\n\r\n\r";

                                width = 190;
                                if (dtResult.Rows.Count == 1) height = 78;
                                else height = 70;
                                height = dtResult.Rows.Count * height + 5;
                                
                                for (int i = 0; i < dtResult.Rows.Count; i++)
                                {
                                    dbxText = dbxText + "   【　" + dtResult.Rows[i]["time_gubun"].ToString() + "　】" + "\n\r";
                                    dbxText = dbxText + "　　・実施時間：" + dtResult.Rows[i]["act_time"].ToString() + "\n\r";
                                    //dbxText = dbxText + "　 ・ 実施日付 : " + dtResult.Rows[i]["act_date"].ToString() + "\n\r";
                                    dbxText = dbxText + "　　・実施数量：" + dtResult.Rows[i]["suryang"].ToString() + "\n\r";
                                    if (!TypeCheck.IsNull(dtResult.Rows[i]["blood_sugar"])) dbxText = dbxText + "　　・血糖値　：" + dtResult.Rows[i]["blood_sugar"].ToString() + "\n\r";
                                    dbxText = dbxText + "　　・実施者　：" + dtResult.Rows[i]["act_user"].ToString() + "\n\r\n\r";
                                }
                            }
                            break;

                        case "3":   // 산소요법 酸素
                            cmdText = @"SELECT TO_CHAR(A.ACT_DATE, 'YYYY/MM/DD') ACT_DATE
                                             , A.ACT_ID
                                             , A.SURYANG
                                             , SUBSTR(A.START_TIME, 1, 2) || ':' || SUBSTR(A.START_TIME, 3, 2) START_TIME
                                             , TO_CHAR(A.END_DATE, 'YYYY/MM/DD') END_DATE
                                             , SUBSTR(A.END_TIME, 1, 2) || ':' || SUBSTR(A.END_TIME, 3, 2) END_TIME
                                             , B.USER_NM ACT_USER
                                             , D.HANGMOG_NAME
                                             , TO_CHAR(TO_NUMBER(SUBSTR(A.END_TIME, 1, 2) - SUBSTR(A.START_TIME, 1, 2)) * 60 + TO_NUMBER(SUBSTR(A.END_TIME, 3, 2) - SUBSTR(A.START_TIME, 3, 2)) + 1) TOTAL_MINUTE
                                          FROM OCS2015 A
                                             , ADM3200 B
                                             , OCS2016 C
                                             , OCS0103 D
                                         WHERE A.HOSP_CODE    = FN_ADM_LOAD_HOSP_CODE()
                                           AND A.BUNHO        = :f_bunho
                                           AND A.FKINP1001    = :f_fkinp1001
                                           AND A.ORDER_DATE   = :f_order_date
                                           AND A.INPUT_GUBUN  = :f_input_gubun
                                           AND A.PK_SEQ       = :f_pk_seq
                                           AND A.ACT_DATE     = :f_act_date
                                           --
                                           AND B.HOSP_CODE    = A.HOSP_CODE
                                           AND B.USER_ID      = A.ACT_ID
                                           --
                                           AND C.FKOCS2015    = A.PKOCS2015
                                           AND C.HOSP_CODE    = A.HOSP_CODE
                                           AND C.BOM_YN       = 'P'
                                           --
                                           AND D.HOSP_CODE    = C.HOSP_CODE
                                           AND D.HANGMOG_CODE = C.HANGMOG_CODE";

                            dtResult = Service.ExecuteDataTable(cmdText, bindVars);

                            if (dtResult != null && dtResult.Rows.Count > 0)
                            {
                                dbxText = "◎詳細情報◎\n\r\n\r";

                                width = 250;
                                height = 100;
                                height = dtResult.Rows.Count * height + 7;

                                for (int i = 0; i < dtResult.Rows.Count; i++)
                                {
                                    dbxText = dbxText + "   【 実施日付：" + dtResult.Rows[i]["act_date"].ToString() + " 】\n\r";
                                    dbxText = dbxText + "　　・項目：" + dtResult.Rows[i]["hangmog_name"].ToString() + "\n\r";
                                    dbxText = dbxText + "　　・ℓ/分：" + dtResult.Rows[i]["suryang"].ToString() + "ℓ \n\r";
                                    dbxText = dbxText + "　　・吸入量：" + dtResult.Rows[i]["total_minute"].ToString() + "分 \n\r";
                                    
                                    //if (!TypeCheck.IsNull(dtResult.Rows[i]["blood_sugar"])) dbxText = dbxText + "　 ・ 血糖値  : " + dtResult.Rows[i]["blood_sugar"].ToString() + "\n\r";
                                    dbxText = dbxText + "　　・開始時間：" + dtResult.Rows[i]["start_time"].ToString() + "\n\r";
                                    dbxText = dbxText + "　　・終了時間：" + dtResult.Rows[i]["end_time"].ToString() + "\n\r";
                                    dbxText = dbxText + "　　・実施者　：" + dtResult.Rows[i]["act_user"].ToString() + "\n\r\n\r";
                                }
                            }
                            break;
                        case "4":   // 인공호흡 人工呼吸
                            cmdText = @"SELECT TO_CHAR(A.ACT_DATE, 'YYYY/MM/DD') ACT_DATE
                                             , A.ACT_ID
                                             , A.SURYANG
                                             , SUBSTR(A.START_TIME, 1, 2) || ':' || SUBSTR(A.START_TIME, 3, 2) START_TIME
                                             , TO_CHAR(A.END_DATE, 'YYYY/MM/DD') END_DATE
                                             , SUBSTR(A.END_TIME, 1, 2) || ':' || SUBSTR(A.END_TIME, 3, 2) END_TIME
                                             , B.USER_NM ACT_USER
                                             , D.HANGMOG_NAME
                                             --, TRUNC(TO_NUMBER(TO_DATE(A.END_TIME, 'HH24MI') - TO_DATE(A.START_TIME, 'HH24MI')) * 24 * 60 + 2 ) TOTAL_MINUTE
                                             , TO_CHAR(TO_NUMBER(SUBSTR(A.END_TIME, 1, 2) - SUBSTR(A.START_TIME, 1, 2)) * 60 + TO_NUMBER(SUBSTR(A.END_TIME, 3, 2) - SUBSTR(A.START_TIME, 3, 2)) + 1) TOTAL_MINUTE
                                          FROM OCS2015 A
                                             , ADM3200 B
                                             , OCS2016 C
                                             , OCS0103 D
                                         WHERE A.HOSP_CODE    = FN_ADM_LOAD_HOSP_CODE()
                                           AND A.BUNHO        = :f_bunho
                                           AND A.FKINP1001    = :f_fkinp1001
                                           AND A.ORDER_DATE   = :f_order_date
                                           AND A.INPUT_GUBUN  = :f_input_gubun
                                           AND A.PK_SEQ       = :f_pk_seq
                                           AND A.ACT_DATE     = :f_act_date
                                           --
                                           AND B.HOSP_CODE    = A.HOSP_CODE
                                           AND B.USER_ID      = A.ACT_ID
                                           --
                                           AND C.FKOCS2015    = A.PKOCS2015
                                           AND C.HOSP_CODE    = A.HOSP_CODE
                                           AND C.BOM_YN       = 'P'
                                           --
                                           AND D.HOSP_CODE    = C.HOSP_CODE
                                           AND D.HANGMOG_CODE = C.HANGMOG_CODE";

                            dtResult = Service.ExecuteDataTable(cmdText, bindVars);

                            if (dtResult != null && dtResult.Rows.Count > 0)
                            {
                                dbxText = "◎詳細情報◎\n\r\n\r";

                                width = 250;
                                height = 100;
                                height = dtResult.Rows.Count * height + 7;

                                for (int i = 0; i < dtResult.Rows.Count; i++)
                                {
                                    dbxText = dbxText + "   【 実施日付：" + dtResult.Rows[i]["act_date"].ToString() + " 】\n\r";
                                    dbxText = dbxText + "　　・項目：" + dtResult.Rows[i]["hangmog_name"].ToString() + "\n\r";
                                    dbxText = dbxText + "　　・ℓ/分：" + dtResult.Rows[i]["suryang"].ToString() + "ℓ \n\r";
                                    dbxText = dbxText + "　　・吸入量：" + dtResult.Rows[i]["total_minute"].ToString() + "分 \n\r";
                                    //if (!TypeCheck.IsNull(dtResult.Rows[i]["blood_sugar"])) dbxText = dbxText + "　 ・ 血糖値  : " + dtResult.Rows[i]["blood_sugar"].ToString() + "\n\r";
                                    dbxText = dbxText + "　　・開始時間：" + dtResult.Rows[i]["start_time"].ToString() + "\n\r";
                                    dbxText = dbxText + "　　・終了時間：" + dtResult.Rows[i]["end_time"].ToString() + "\n\r";
                                    dbxText = dbxText + "　　・実施者　：" + dtResult.Rows[i]["act_user"].ToString() + "\n\r\n\r";
                                }
                            }
                            break;

                        //case "5":
                        //    break;

                        default:
                            cmdText = @"SELECT TO_CHAR(A.ACT_DATE, 'YYYY/MM/DD') ACT_DATE
                                             , A.ACT_ID
                                             , A.SURYANG
                                             , SUBSTR(A.START_TIME, 1, 2) || ':' || SUBSTR(A.START_TIME, 3, 2) START_TIME
                                             , TO_CHAR(A.END_DATE, 'YYYY/MM/DD') END_DATE
                                             , SUBSTR(A.END_TIME, 1, 2) || ':' || SUBSTR(A.END_TIME, 3, 2) END_TIME
                                             , B.USER_NM ACT_USER
                                             , D.HANGMOG_NAME
                                             , TO_CHAR(A.UPD_DATE, 'HH24:MI') ACT_TIME
                                          FROM OCS2015 A
                                             , ADM3200 B
                                             , OCS2016 C
                                             , OCS0103 D
                                         WHERE A.HOSP_CODE       = FN_ADM_LOAD_HOSP_CODE()
                                           AND A.BUNHO           = :f_bunho
                                           AND A.FKINP1001       = :f_fkinp1001
                                        --   AND A.ORDER_DATE    = :f_order_date
                                           AND A.INPUT_GUBUN     = :f_input_gubun
                                           AND A.PK_SEQ          = :f_pk_seq
                                           AND A.ACT_DATE        = :f_act_date
                                           --
                                           AND B.HOSP_CODE       = A.HOSP_CODE
                                           AND B.USER_ID         = A.ACT_ID
                                           --
                                           AND C.HOSP_CODE(+)    = A.HOSP_CODE
                                           AND C.FKOCS2015(+)    = A.PKOCS2015
                                           --
                                           AND D.HOSP_CODE(+)    = C.HOSP_CODE
                                           AND D.HANGMOG_CODE(+) = C.HANGMOG_CODE ";

                            dtResult = Service.ExecuteDataTable(cmdText, bindVars);

                            if (dtResult != null && dtResult.Rows.Count > 0)
                            {
                                dbxText = "◎詳細情報◎\n\r\n\r";

                                width = 250;
                                height = 50;
                                height = dtResult.Rows.Count * height + 6;

                                for (int i = 0; i < dtResult.Rows.Count; i++)
                                {
                                    dbxText = dbxText + "   【 実施日付：" + dtResult.Rows[i]["act_date"].ToString() + " 】\n\r";

                                    if (!TypeCheck.IsNull(dtResult.Rows[i]["hangmog_name"]))
                                    {
                                        height = height + 10; dbxText = dbxText + "　　・項目：" + dtResult.Rows[i]["hangmog_name"].ToString() + "\n\r";
                                    }

                                    dbxText = dbxText + "　　・実施時間：" + dtResult.Rows[i]["act_time"].ToString() + "\n\r";

                                    if (!TypeCheck.IsNull(dtResult.Rows[i]["suryang"]))
                                    {
                                        height = height + 10; dbxText = dbxText + "　　・実施数量：" + dtResult.Rows[i]["suryang"].ToString() + "\n\r";
                                    }

                                    dbxText = dbxText + "　　・実施者 ：" + dtResult.Rows[i]["act_user"].ToString() + "\n\r\n\r";
                                }
                            }
                            break;

                    }
                    break;

                case "OCS2003":

                    cmdText = @"SELECT A.NURSE_PICKUP_USER || ' ' || B.USER_NM PICKUP_USER
                                     , TO_CHAR(A.NURSE_PICKUP_DATE, 'YYYY/MM/DD') NURSE_PICKUP_DATE
                                     , SUBSTR(A.NURSE_PICKUP_TIME, 1, 2) || ':' || SUBSTR(A.NURSE_PICKUP_TIME, 3, 2) PICKUP_TIME
                                     , A.NURSE_CONFIRM_DATE
                                     , A.NURSE_CONFIRM_TIME
                                     , TO_CHAR(A.ACTING_DATE, 'MM/DD') ACTING_DATE
                                     , A.ACTING_TIME
                                  FROM ADM3200 B
                                     , OCS2003 A
                                 WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE
                                   AND A.PKOCS2003 = :f_pk
                                   AND B.HOSP_CODE = A.HOSP_CODE
                                   AND B.USER_ID   = A.NURSE_PICKUP_USER";

                            dtResult = Service.ExecuteDataTable(cmdText, bindVars);
                    
                            if (dtResult != null && dtResult.Rows.Count > 0)
                            {
                                dbxText = "◎詳細情報◎\n\r\n\r";

                                width = 190;
                                height = 60;
                                height = dtResult.Rows.Count * height + 5;

                                for (int i = 0; i < dtResult.Rows.Count; i++)
                                {
                                    dbxText = dbxText + "   【 確認日付：" + dtResult.Rows[i]["nurse_pickup_date"].ToString() + " 】\n\r";
                                    dbxText = dbxText + "　　・看護確認：" + dtResult.Rows[i]["pickup_user"].ToString() + "\n\r";
                                    dbxText = dbxText + "　　・確認時間：" + dtResult.Rows[i]["pickup_time"].ToString();
                                    if (dtResult.Rows[i]["acting_date"].ToString() != "")
                                    {
                                        height = height + 20;
                                        dbxText = dbxText + "\n\r" + "　　・実施日付：" + dtResult.Rows[i]["acting_date"].ToString();
                                        dbxText = dbxText + "\n\r" + "　　・実施時間：" + dtResult.Rows[i]["acting_time"].ToString();
                                    }
                                    dbxText = dbxText + "\n\r\n\r";
                                }
                            }
                    break;

                case "OCS6015":
                    break;
            }

            if (dtResult.Rows.Count > 0)
            {
                htReturn.Add("width", width);
                htReturn.Add("height", height);
                htReturn.Add("text", dbxText);
            }

            return htReturn;
        }
        #endregion

        #region [ btnOpenOrder_Click - オーダ画面をオープン ]
        private OCS.PatientInfo.clsParameter mPatientInfoParam;
        private void btnOpenOrder_Click(object sender, EventArgs e)
        {
            if (mtxPlanMgt.SelectedItems.Count == 0) return;
            int currentRow = int.Parse(mtxPlanMgt.SelectedItems[0].Tag.ToString());

            if (TypeCheck.IsInt(dloItemData.GetItemString(currentRow, "order_gubun"))) return;
                
            MultiLayout aLayout = new MultiLayout();
            string openScreenID = string.Empty;
            mPatientInfoParam = new IHIS.OCS.PatientInfo.clsParameter();
            mPatientInfoParam.NaewonDate = dloItemData.GetItemString(currentRow, "source_order_date");
            mPatientInfoParam.InputID = dloItemData.GetItemString(currentRow, "input_doctor");
            mPatientInfoParam.IOEGubun = "I"; // 외래입원구분 - 입원 -
            mPatientInfoParam.Bunho = dloItemData.GetItemString(currentRow, "bunho");

            OCS.PatientInfo mSelectedPatientInfo = new IHIS.OCS.PatientInfo(this.Name);
            mSelectedPatientInfo.Parameter = mPatientInfoParam;
            mSelectedPatientInfo.LoadPatientInfo(IHIS.OCS.PatientInfo.QueryMode.NawonFullInfo);
                                               
            string aBunho      = dloItemData.GetItemString(currentRow, "bunho");
            string aFkInp1001  = dloItemData.GetItemString(currentRow, "fkinp1001");
            string aQueryGubun;
            if(UserInfo.UserGubun == UserType.Doctor) aQueryGubun = "D";
            else aQueryGubun = "N";
            string aInputGubun = dloItemData.GetItemString(currentRow, "input_gubun");
            string aOrderDate  = dloItemData.GetItemString(currentRow, "order_date");
            
            // openParam setting
            CommonItemCollection param = new CommonItemCollection();
            param.Add("patient_info",       mSelectedPatientInfo);
            param.Add("order_date",         aOrderDate);  // 오더일. 희망일 아님.
            param.Add("io_gubun",           "I");
            param.Add("input_gubun",        aInputGubun);
            param.Add("bunho",              aBunho);

            param.Add("input_part",         dloItemData.GetItemString(currentRow, "input_gwa"));
            param.Add("naewon_key",         mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            param.Add("input_gubun_name",   dloItemData.GetItemString(currentRow, "input_gubun_name"));
            param.Add("caller_screen_id",   this.ScreenID);
            param.Add("caller_sys_id",      EnvironInfo.CurrSystemID);
            param.Add("order_mode",         OCS.OrderVariables.OrderMode.InpOrder);
            // openParam setting

            if (!LoadOutOrder(aBunho, aFkInp1001, aQueryGubun, aInputGubun, aOrderDate))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }

            switch (dloItemData.GetItemString(currentRow, "order_gubun"))
            {
                case "B":   // 注射
                    openScreenID = "OCS0103U12";
                    aLayout = layJusaOrder.Copy();
                    break;

                case "C":   // 内服薬
                case "D":   // 外用薬
                    openScreenID = "OCS0103U10";
                    aLayout = layDrugOrder.Copy();
                    break;

                case "E":   // 画像診断
                    openScreenID = "OCS0103U16";
                    aLayout = layXrtOrder.Copy();
                    break;

                case "F":   // 検体検査
                    openScreenID = "OCS0103U13";
                    aLayout = layCplOrder.Copy();
                    break;

                case "G":   // 手術
                case "M":   // 麻酔
                    openScreenID = "OCS0103U18";
                    aLayout = laySusulOrder.Copy();
                    break;

                case "H":   // 処置
                    openScreenID = "OCS0103U17";
                    aLayout = layChuchiOrder.Copy();
                    break;

                case "K":   // 材料
                case "Z":   // その他
                    openScreenID = "OCS0103U19";
                    aLayout = layEtcOrder.Copy();
                    break;

                case "N":   // 生理検査
                    openScreenID = "OCS0103U14";
                    aLayout = layPfeOrder.Copy();
                    break;
            }

            param.Add("in_data_row", aLayout.LayoutTable);

            if(openScreenID != null)
                OpenScreenWithParam(this, "OCSA", openScreenID, ScreenOpenStyle.ResponseFixed, param);

            btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region LoadOutOrder() - 오더화면에 넘길 레이아웃 작성 함수
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aBunho"></param>
        /// <param name="aFkINP1001"></param>
        /// <param name="aQueryGubun"></param>
        /// <param name="aInputGubun"></param>
        /// <param name="aOrderDate"></param>
        /// <returns></returns>
        private bool LoadOutOrder(string aBunho, string aFkINP1001, string aQueryGubun, string aInputGubun, string aOrderDate)
        {
            this.layQueryLayout.SetBindVarValue("f_bunho",       aBunho);
            this.layQueryLayout.SetBindVarValue("f_fkinp1001",   aFkINP1001);
            this.layQueryLayout.SetBindVarValue("f_query_gubun", aQueryGubun);
            this.layQueryLayout.SetBindVarValue("f_input_gubun", aInputGubun);
            this.layQueryLayout.SetBindVarValue("f_order_date",  aOrderDate);
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

            foreach (DataRow dr in this.layQueryLayout.LayoutTable.Rows)
            {
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

                    case "11": // 기타 오더

                        this.layEtcOrder.LayoutTable.ImportRow(dr);

                        break;
                }
            }
            return true;
        }
        #endregion

        private void OCS6010U10_Closing(object sender, CancelEventArgs e)
        {
            ((XScreen)this.Opener).Command(this.Name, new CommonItemCollection());
        }

        private void btnPreWeek_Click(object sender, EventArgs e)
        {
            if (!TypeCheck.IsDateTime(dpkFrom_date.GetDataValue()))
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "正しくない日付が入力されました。ご確認ください。" : "일자를 잘못 입력하셨습니다. 확인바랍니다.";
                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
                dpkFrom_date.Focus();
            }
            else
            {
                dpkFrom_date.SetDataValue(DateTime.Parse(dpkFrom_date.GetDataValue()).AddDays(-7).ToString("yyyy/MM/dd"));
                dpkTo_date.SetDataValue(DateTime.Parse(dpkFrom_date.GetDataValue()).AddDays(6).ToString("yyyy/MM/dd"));
                this.ShowData(false);
            }
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            if (!TypeCheck.IsDateTime(dpkFrom_date.GetDataValue()))
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "正しくない日付が入力されました。ご確認ください。" : "일자를 잘못 입력하셨습니다. 확인바랍니다.";
                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
                dpkFrom_date.Focus();
            }
            else
            {
                dpkFrom_date.SetDataValue(DateTime.Parse(dpkFrom_date.GetDataValue()).AddDays(7).ToString("yyyy/MM/dd"));
                dpkTo_date.SetDataValue(DateTime.Parse(dpkFrom_date.GetDataValue()).AddDays(6).ToString("yyyy/MM/dd"));
                this.ShowData(false);
            }
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            if (this.pbxBunho.BunHo.ToString() == "")
            {
                XMessageBox.Show("患者番号を確認してください");
                return;
            }

            IXScreen screen = XScreen.FindScreen("NURI", "NUR1020Q00");
            
            if (screen == null)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("sysid", EnvironInfo.CurrSystemID);
                openParams.Add("screen", this.ScreenID.ToString());
                openParams.Add("bunho", this.pbxBunho.BunHo);
                openParams.Add("fkinp1001", this.mFkinp1001);

                if (OpenParam.Contains("jaewon_yn") && OpenParam["jaewon_yn"].ToString() == "N")
                {
                    openParams.Add("date", OpenParam["query_date"].ToString());
                    openParams.Add("jaewon_yn", OpenParam["jaewon_yn"].ToString());
                }
                else
                {
                    openParams.Add("date", this.dpkFrom_date.GetDataValue());
                    openParams.Add("hodong", mPatientInfo.GetPatientInfo["ho_dong"].ToString());
                }
                XScreen.OpenScreenWithParam(this, "NURI", "NUR1020Q00", ScreenOpenStyle.PopUpFixed, ScreenAlignment.ParentTopCenter, openParams);
            }
            else
            {
                screen.Activate();
                XPatientInfo pInfo = new XPatientInfo(this.pbxBunho.BunHo, "", "", mPatientInfo.GetPatientInfo["ho_dong"].ToString(), this.mFkinp1001.ToString(), PatientPKGubun.In, this.ScreenID);
                XScreen.SendPatientInfo(pInfo);
            }

        }

        private void btnEmergencyTreatDisplayYN_Click(object sender, EventArgs e)
        {
            this.btnEmergencyTreatDisplayYN.ImageIndex = this.btnEmergencyTreatDisplayYN.ImageIndex == 3 ? 4 : 3;
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void btnCommentOnOff_Click(object sender, EventArgs e)
        {
            this.btnCommentOnOff.ImageIndex = this.btnCommentOnOff.ImageIndex == 3 ? 4 : 3;
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void btnRemarkOnOff_Click(object sender, EventArgs e)
        {
            this.btnRemarkOnOff.ImageIndex = this.btnRemarkOnOff.ImageIndex == 3 ? 4 : 3;
            this.btnList.PerformClick(FunctionType.Query);
        }

    }
}

