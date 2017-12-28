#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.DRGS.Properties;
using IHIS.Framework;
#endregion

namespace IHIS.DRGS
{
    /// <summary>
    /// DRG3010P99에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class DRG3010P99 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XDatePicker dtpToDate;
        private IHIS.Framework.XDatePicker dtpFromDate;
        private IHIS.Framework.XButton btnRePrint;
        private IHIS.Framework.XDatePicker dtpMagamDate;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XButton btnCancel;
        private IHIS.Framework.MultiLayout layMagam;
        private IHIS.Framework.MultiLayout layOrderJungbo;
 //       private IHIS.Framework.XDataWindow dw_jusa;
 //       private IHIS.Framework.XDataWindow dw_print;
        private IHIS.Framework.MultiLayout layOrderBarcode;
//        private IHIS.Framework.XDataWindow dw_lable;
        private IHIS.Framework.MultiLayout layJusaLable;
        private IHIS.Framework.XComboBox cbxGubun;
        private IHIS.Framework.XComboItem xComboItem4;
        private IHIS.Framework.MultiLayout layOrderPrint;
        private IHIS.Framework.MultiLayout layJusaOrderPrint;
        private IHIS.Framework.XComboItem xComboItem5;
        private IHIS.Framework.XTabControl tabControl;
        private IHIS.X.Magic.Controls.TabPage tabPage1;
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
        private MultiLayoutItem multiLayoutItem120;
        private MultiLayoutItem multiLayoutItem121;
        private MultiLayoutItem multiLayoutItem122;
        private MultiLayoutItem multiLayoutItem123;
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
        private XEditGridCell xEditGridCell19;
        private ImageList imageListMixGroup;
        private XButton btnReLabelPrint;
        private XButton btnMagamStops;
        private XButton btnMagamStarts;
        private XComboItem xComboItem9;
        private XComboItem xComboItem10;
        private MultiLayout layOutOrder;
        private MultiLayoutItem multiLayoutItem56;
        private XPanel pnlMagam;
        private XPanel xPanel4;
        private XEditGrid grdMagamJUSAOrder;
        private XEditGridCell xEditGridCell57;
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
        private XEditGridCell xEditGridCell124;
        private XEditGridCell xEditGridCell125;
        private XEditGridCell xEditGridCell128;
        private XEditGridCell xEditGridCell130;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGrid grdMagamOrder;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
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
        private XEditGridCell xEditGridCell123;
        private XEditGridCell xEditGridCell126;
        private XEditGridCell xEditGridCell127;
        private XEditGridCell xEditGridCell129;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGrid grdList;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XComboItem xComboItem6;
        private XComboItem xComboItem7;
        private XComboItem xComboItem8;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private IHIS.X.Magic.Controls.TabPage tabPage2;
//        private IHIS.X.Magic.Controls.TabPage tabPage3;
        private XPanel pnlBoryu;
        private XPanel pnlMiMagam;
        //private XEditGrid grdBoryuPa;
        private XEditGridCell xEditGridCell259;
        private XEditGridCell xEditGridCell260;
        private XEditGridCell xEditGridCell261;
        private XEditGridCell xEditGridCell262;
        private XEditGridCell xEditGridCell263;
        private XEditGridCell xEditGridCell264;
        private XEditGridCell xEditGridCell265;
        private XEditGridCell xEditGridCell268;
        private XEditGridCell xEditGridCell323;
        private XEditGridCell xEditGridCell412;
        private XEditGridCell xEditGridCell266;
        private XEditGridCell xEditGridCell267;
        private XPanel xPanel12;
        //private XEditGrid grdBoryuNeabok;
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
        private XEditGridCell xEditGridCell324;
        private XEditGridCell xEditGridCell325;
        private XEditGridCell xEditGridCell326;
        private XEditGridCell xEditGridCell327;
        private XEditGridCell xEditGridCell328;
        private XEditGridCell xEditGridCell329;
        private XEditGridCell xEditGridCell330;
        private XEditGridCell xEditGridCell331;
        //private XEditGrid grdBoryuJusa;
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
        private XPanel xPanel5;
        //private XDataWindow xDataWindow4;
        //private XDataWindow xDataWindow5;
        //private XDataWindow xDataWindow6;
        private XButtonList xButtonList2;
        private XPanel xPanel2;
        //private XDataWindow xDataWindow1;
        //private XDataWindow xDataWindow2;
        //private XDataWindow xDataWindow3;
        private XButtonList xButtonList1;
        private XEditGrid grdPaQuery;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell31;
        private XEditGridCell xEditGridCell37;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell332;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell83;
        private XEditGridCell xEditGridCell87;
        private XEditGridCell xEditGridCell409;
        private XEditGridCell xEditGridCell60;
        private XEditGridCell xEditGridCell410;
        private XEditGridCell xEditGridCell165;
        private XEditGridCell xEditGridCell148;
        private XEditGridCell xEditGridCell173;
        private XEditGridCell xEditGridCell149;
        private XPanel xPanel8;
        private XEditGrid grdMiMagamOrder;
        private XEditGridCell xEditGridCell61;
        private XEditGridCell xEditGridCell70;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell65;
        private XEditGridCell xEditGridCell63;
        private XEditGridCell xEditGridCell64;
        private XEditGridCell xEditGridCell66;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell68;
        private XEditGridCell xEditGridCell69;
        private XEditGridCell xEditGridCell71;
        private XEditGridCell xEditGridCell72;
        private XEditGridCell xEditGridCell73;
        private XEditGridCell xEditGridCell74;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell76;
        private XEditGridCell xEditGridCell77;
        private XEditGridCell xEditGridCell78;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell81;
        private XEditGridCell xEditGridCell82;
        private XEditGridCell xEditGridCell84;
        private XEditGridCell xEditGridCell315;
        private XEditGridCell xEditGridCell319;
        private XEditGridCell xEditGridCell317;
        private XEditGridCell xEditGridCell85;
        private XEditGridCell xEditGridCell321;
        private XEditGridCell xEditGridCell334;
        private XEditGridCell xEditGridCell335;
        private XEditGridCell xEditGridCell134;
        private XEditGridCell xEditGridCell135;
        private XEditGridCell xEditGridCell140;
        private XEditGridCell xEditGridCell162;
        private XGridHeader xGridHeader2;
        private XEditGrid grdMiMagamJUSAOrder;
        private XEditGridCell xEditGridCell86;
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
        private XEditGridCell xEditGridCell131;
        private XEditGridCell xEditGridCell132;
        private XEditGridCell xEditGridCell133;
        private XEditGridCell xEditGridCell136;
        private XEditGridCell xEditGridCell137;
        private XEditGridCell xEditGridCell138;
        private XEditGridCell xEditGridCell139;
        private XEditGridCell xEditGridCell141;
        private XEditGridCell xEditGridCell142;
        private XEditGridCell xEditGridCell316;
        private XEditGridCell xEditGridCell320;
        private XEditGridCell xEditGridCell318;
        private XEditGridCell xEditGridCell143;
        private XEditGridCell xEditGridCell322;
        private XEditGridCell xEditGridCell144;
        private XEditGridCell xEditGridCell333;
        private XEditGridCell xEditGridCell145;
        private XEditGridCell xEditGridCell146;
        private XEditGridCell xEditGridCell147;
        private XEditGridCell xEditGridCell163;
        private XGridHeader xGridHeader1;
        private XButton btnPrint;
        private XEditGridCell xEditGridCell58;
        private XEditGridCell xEditGridCell150;
        private XEditGridCell xEditGridCell152;
        private XEditGridCell xEditGridCell153;
        private XEditGridCell xEditGridCell154;
        private XEditGridCell xEditGridCell155;
        private XEditGridCell xEditGridCell156;
        private XButton btnUnCheckAll;
        private XButton btnCheckAll;
        private XComboItem xComboItem11;
        private XComboItem xComboItem12;
        private XComboItem xComboItem13;
        private XComboItem xComboItem14;
        private XGridHeader xGridHeader3;
        private XGridHeader xGridHeader4;
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
        private MultiLayoutItem multiLayoutItem147;
        private MultiLayoutItem multiLayoutItem148;
        private MultiLayoutItem multiLayoutItem149;
        private MultiLayoutItem multiLayoutItem150;
        private MultiLayoutItem multiLayoutItem151;
        private MultiLayoutItem multiLayoutItem152;
        private MultiLayoutItem multiLayoutItem153;
        private MultiLayoutItem multiLayoutItem154;
        private MultiLayoutItem multiLayoutItem155;
        private MultiLayoutItem multiLayoutItem156;
        private MultiLayoutItem multiLayoutItem157;
        private MultiLayoutItem multiLayoutItem158;
        private MultiLayoutItem multiLayoutItem159;
        private MultiLayoutItem multiLayoutItem160;
        private MultiLayoutItem multiLayoutItem161;
        private MultiLayoutItem multiLayoutItem162;
        private MultiLayoutItem multiLayoutItem163;
        private MultiLayoutItem multiLayoutItem164;
        private MultiLayoutItem multiLayoutItem195;
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
        private XComboItem xComboItem16;
        private XEditGridCell xEditGridCell157;
        private XLabel xLabel5;
        private XLabel lbDate;
        private XLabel xLabel4;
        private XDictComboBox cbxBuseo;
        private XLabel xLabel7;
        private XLabel xLabel6;
        private XPatientBox paBox;
        private XEditGridCell xEditGridCell158;
        private XEditGridCell xEditGridCell159;
        private XEditGridCell xEditGridCell160;
        private XEditGridCell xEditGridCell161;
        private XEditGridCell xEditGridCell6;
        private XPanel xPanel6;
        private XPanel xPanel7;
        private XComboItem xComboItem3;
        private XLabel xLabel2;
        private XDictComboBox cbxActor;
        private XEditGridCell xEditGridCell164;
        private XEditGridCell xEditGridCell166;
        private Panel pnlStatus;
        private Label lbStatus;
        private XProgressBar pgbProgress;
        private XTextBox txtTimeInterval;
        private XTextBox tbxTimer;
        private XDictComboBox cboTime;
        private XLabel xLabel8;
        private XLabel lbTime;
        private Timer timer1;
        private XButton btnUseAlarmChk;
        private XButton btnUseTimeChk;
        private MultiLayout mlayConstantInfo;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem42;
        private MultiLayoutItem multiLayoutItem43;
        private XLabel xLabel3;
        private XDatePicker dtpJubsuDate;
        private IHIS.X.Magic.Controls.TabPage tabPage3;
        private XPanel xPanel9;
        private XPanel xPanel10;
        private XEditGrid grdDcOrder;
        private XEditGridCell xEditGridCell167;
        private XEditGridCell xEditGridCell168;
        private XEditGridCell xEditGridCell169;
        private XEditGridCell xEditGridCell170;
        private XEditGridCell xEditGridCell171;
        private XEditGridCell xEditGridCell172;
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
        private XEditGrid grdJusaDcOrder;
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
        private XPanel xPanel11;
        private XEditGrid grdPaDcList;
        private XEditGridCell xEditGridCell238;
        private XEditGridCell xEditGridCell239;
        private XEditGridCell xEditGridCell240;
        private XEditGridCell xEditGridCell241;
        private XEditGridCell xEditGridCell242;
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
        private XComboItem xComboItem15;
        private XComboItem xComboItem17;
        private XComboItem xComboItem18;
        private XComboItem xComboItem19;
        private XComboItem xComboItem20;
        private XEditGridCell xEditGridCell254;
        private XPanel xPanel13;
        private XButton btnDcReLabelPrint;
        private XButton xButton2;
        private XButton btnDcRePrint;
        private XButtonList btnListDc;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem36;
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem38;
        private MultiLayoutItem multiLayoutItem39;
        private MultiLayoutItem multiLayoutItem40;
        private MultiLayoutItem multiLayoutItem41;
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
        private MultiLayoutItem multiLayoutItem232;
        private MultiLayoutItem multiLayoutItem233;
        private MultiLayoutItem multiLayoutItem234;
        private MultiLayoutItem multiLayoutItem235;
        private MultiLayoutItem multiLayoutItem237;
        private MultiLayoutItem multiLayoutItem238;
        private MultiLayoutItem multiLayoutItem239;
        private MultiLayoutItem multiLayoutItem240;
        private MultiLayoutItem multiLayoutItem241;
        private XComboItem xComboItem21;
        private IHIS.X.Magic.Controls.TabPage tabPage4;
        private XPanel xPanel14;
        private XPanel xPanel15;
        private XEditGrid grdPrnOrder;
        private XEditGridCell xEditGridCell255;
        private XEditGridCell xEditGridCell256;
        private XEditGridCell xEditGridCell257;
        private XEditGridCell xEditGridCell258;
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
        private XGridHeader xGridHeader5;
        private XEditGrid grdPrnJusaOrder;
        private XEditGridCell xEditGridCell366;
        private XEditGridCell xEditGridCell367;
        private XEditGridCell xEditGridCell368;
        private XEditGridCell xEditGridCell369;
        private XEditGridCell xEditGridCell370;
        private XEditGridCell xEditGridCell371;
        private XEditGridCell xEditGridCell372;
        private XEditGridCell xEditGridCell373;
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
        private XGridHeader xGridHeader6;
        private XPanel xPanel16;
        private XEditGrid grdPaPrnQuery;
        private XEditGridCell xEditGridCell400;
        private XEditGridCell xEditGridCell401;
        private XEditGridCell xEditGridCell402;
        private XEditGridCell xEditGridCell403;
        private XEditGridCell xEditGridCell404;
        private XEditGridCell xEditGridCell405;
        private XEditGridCell xEditGridCell406;
        private XEditGridCell xEditGridCell407;
        private XEditGridCell xEditGridCell408;
        private XEditGridCell xEditGridCell411;
        private XEditGridCell xEditGridCell413;
        private XEditGridCell xEditGridCell414;
        private XEditGridCell xEditGridCell415;
        private XEditGridCell xEditGridCell416;
        private XEditGridCell xEditGridCell417;
        private XEditGridCell xEditGridCell418;
        private XEditGridCell xEditGridCell419;
        private XEditGridCell xEditGridCell420;
        private XEditGridCell xEditGridCell421;
        private XComboItem xComboItem27;
        private XEditGridCell xEditGridCell422;
        private XEditGridCell xEditGridCell423;
        private XPanel xPanel17;
        private XButton btnPrnPrint;
        //private XDataWindow xDataWindow7;
        //private XDataWindow xDataWindow8;
        //private XDataWindow xDataWindow9;
        private XButtonList btnPrnList;
        private XComboItem xComboItem28;
        private XCheckBox cbxATCYN;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem171;
        private MultiLayoutItem multiLayoutItem172;
        private XButton btnAtcTrans;
        private XEditGridCell xEditGridCell424;
        private XComboItem xComboItem22;
        private XComboItem xComboItem23;
        private XComboItem xComboItem24;
        private XComboItem xComboItem25;
        private XGridHeader xGridHeader8;
        private XGridHeader xGridHeader7;
        private XEditGridCell xEditGridCell425;
        private XEditGridCell xEditGridCell426;
        private XEditGridCell xEditGridCell427;
        private XButton btnPrintAdmMedi;
        private XEditGridCell xEditGridCell428;
        private XEditGridCell xEditGridCell430;
        private XEditGridCell xEditGridCell429;
        private XEditGridCell xEditGridCell431;
        private XEditGridCell xEditGridCell432;
        private XEditGridCell xEditGridCell433;
        private XEditGridCell xEditGridCell434;
        private XEditGridCell xEditGridCell435;
        private XEditGridCell xEditGridCell436;
        private XEditGridCell xEditGridCell437;
        private XEditGridCell xEditGridCell438;
        private XCheckBox cbxJusaLabelYN;
        private XEditGridCell xEditGridCell151;
        private System.ComponentModel.IContainer components;

        public DRG3010P99()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.Height = rc.Height - 125;
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

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG3010P99));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dtpJubsuDate = new IHIS.Framework.XDatePicker();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpMagamDate = new IHIS.Framework.XDatePicker();
            this.cbxActor = new IHIS.Framework.XDictComboBox();
            this.txtTimeInterval = new IHIS.Framework.XTextBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.tbxTimer = new IHIS.Framework.XTextBox();
            this.cboTime = new IHIS.Framework.XDictComboBox();
            this.lbTime = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.cbxBuseo = new IHIS.Framework.XDictComboBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.lbDate = new IHIS.Framework.XLabel();
            this.cbxGubun = new IHIS.Framework.XComboBox();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem9 = new IHIS.Framework.XComboItem();
            this.xComboItem10 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xComboItem21 = new IHIS.Framework.XComboItem();
            this.xComboItem22 = new IHIS.Framework.XComboItem();
            this.xComboItem23 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.btnMagamStops = new IHIS.Framework.XButton();
            this.btnMagamStarts = new IHIS.Framework.XButton();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnPrintAdmMedi = new IHIS.Framework.XButton();
            this.btnAtcTrans = new IHIS.Framework.XButton();
            this.btnReLabelPrint = new IHIS.Framework.XButton();
            this.btnCancel = new IHIS.Framework.XButton();
            this.btnRePrint = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layMagam = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem171 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem172 = new IHIS.Framework.MultiLayoutItem();
            this.layOrderJungbo = new IHIS.Framework.MultiLayout();
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
            this.layOrderPrint = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem40 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem232 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem233 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem234 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem235 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem237 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem238 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem239 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem240 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem241 = new IHIS.Framework.MultiLayoutItem();
            this.layJusaOrderPrint = new IHIS.Framework.MultiLayout();
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
            this.layOrderBarcode = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem120 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem121 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem122 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem123 = new IHIS.Framework.MultiLayoutItem();
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
            this.layJusaLable = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem147 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem148 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem149 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem150 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem151 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem152 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem153 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem154 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem155 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem156 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem157 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem158 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem159 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem160 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem161 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem162 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem163 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem164 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem195 = new IHIS.Framework.MultiLayoutItem();
            this.tabControl = new IHIS.Framework.XTabControl();
            this.tabPage2 = new IHIS.X.Magic.Controls.TabPage();
            this.pnlMiMagam = new IHIS.Framework.XPanel();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.grdMiMagamOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell315 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell319 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell317 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell321 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell334 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell335 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell140 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell162 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell426 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell429 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.grdMiMagamJUSAOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell131 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell132 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell133 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell136 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell137 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell138 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell141 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell142 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell316 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell320 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell318 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell143 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell322 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell144 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell333 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell145 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell146 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell147 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell163 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell433 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell434 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.pgbProgress = new IHIS.Framework.XProgressBar();
            this.grdPaQuery = new IHIS.Framework.XEditGrid();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell332 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell157 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell173 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell409 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell410 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell155 = new IHIS.Framework.XEditGridCell();
            this.xComboItem11 = new IHIS.Framework.XComboItem();
            this.xComboItem12 = new IHIS.Framework.XComboItem();
            this.xComboItem13 = new IHIS.Framework.XComboItem();
            this.xComboItem16 = new IHIS.Framework.XComboItem();
            this.xComboItem14 = new IHIS.Framework.XComboItem();
            this.xEditGridCell156 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell428 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell164 = new IHIS.Framework.XEditGridCell();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.cbxJusaLabelYN = new IHIS.Framework.XCheckBox();
            this.cbxATCYN = new IHIS.Framework.XCheckBox();
            this.btnUseAlarmChk = new IHIS.Framework.XButton();
            this.btnUseTimeChk = new IHIS.Framework.XButton();
            this.btnUnCheckAll = new IHIS.Framework.XButton();
            this.btnCheckAll = new IHIS.Framework.XButton();
            this.btnPrint = new IHIS.Framework.XButton();
            this.xButtonList2 = new IHIS.Framework.XButtonList();
            this.tabPage1 = new IHIS.X.Magic.Controls.TabPage();
            this.pnlMagam = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.grdMagamOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell123 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell152 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell427 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell430 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader7 = new IHIS.Framework.XGridHeader();
            this.grdMagamJUSAOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell124 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell130 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell435 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell436 = new IHIS.Framework.XEditGridCell();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell425 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell158 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell159 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell160 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell161 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell153 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell424 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell166 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xComboItem24 = new IHIS.Framework.XComboItem();
            this.xComboItem25 = new IHIS.Framework.XComboItem();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell151 = new IHIS.Framework.XEditGridCell();
            this.tabPage3 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel9 = new IHIS.Framework.XPanel();
            this.xPanel10 = new IHIS.Framework.XPanel();
            this.grdDcOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell167 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell168 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell169 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell170 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell171 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell172 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell431 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell432 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader8 = new IHIS.Framework.XGridHeader();
            this.grdJusaDcOrder = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell437 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell438 = new IHIS.Framework.XEditGridCell();
            this.xPanel11 = new IHIS.Framework.XPanel();
            this.grdPaDcList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell238 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell239 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell240 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell241 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell242 = new IHIS.Framework.XEditGridCell();
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
            this.xComboItem15 = new IHIS.Framework.XComboItem();
            this.xComboItem17 = new IHIS.Framework.XComboItem();
            this.xComboItem18 = new IHIS.Framework.XComboItem();
            this.xComboItem19 = new IHIS.Framework.XComboItem();
            this.xComboItem20 = new IHIS.Framework.XComboItem();
            this.xEditGridCell254 = new IHIS.Framework.XEditGridCell();
            this.xPanel13 = new IHIS.Framework.XPanel();
            this.btnDcReLabelPrint = new IHIS.Framework.XButton();
            this.xButton2 = new IHIS.Framework.XButton();
            this.btnDcRePrint = new IHIS.Framework.XButton();
            this.btnListDc = new IHIS.Framework.XButtonList();
            this.tabPage4 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel14 = new IHIS.Framework.XPanel();
            this.xPanel15 = new IHIS.Framework.XPanel();
            this.grdPrnOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell255 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell256 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell257 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell258 = new IHIS.Framework.XEditGridCell();
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
            this.xGridHeader5 = new IHIS.Framework.XGridHeader();
            this.grdPrnJusaOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell366 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell367 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell368 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell369 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell370 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell371 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell372 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell373 = new IHIS.Framework.XEditGridCell();
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
            this.xGridHeader6 = new IHIS.Framework.XGridHeader();
            this.xPanel16 = new IHIS.Framework.XPanel();
            this.grdPaPrnQuery = new IHIS.Framework.XEditGrid();
            this.xEditGridCell400 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell401 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell402 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell403 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell404 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell405 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell406 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell407 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell408 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell411 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell413 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell414 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell415 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell416 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell417 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell418 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell419 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell420 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell421 = new IHIS.Framework.XEditGridCell();
            this.xComboItem28 = new IHIS.Framework.XComboItem();
            this.xComboItem27 = new IHIS.Framework.XComboItem();
            this.xEditGridCell422 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell423 = new IHIS.Framework.XEditGridCell();
            this.xPanel17 = new IHIS.Framework.XPanel();
            this.btnPrnPrint = new IHIS.Framework.XButton();
            this.btnPrnList = new IHIS.Framework.XButtonList();
            this.pnlBoryu = new IHIS.Framework.XPanel();
            this.xPanel12 = new IHIS.Framework.XPanel();
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
            this.xEditGridCell324 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell325 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell326 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell327 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell328 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell329 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell330 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell331 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader4 = new IHIS.Framework.XGridHeader();
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
            this.xGridHeader3 = new IHIS.Framework.XGridHeader();
            this.xEditGridCell259 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell260 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell261 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell262 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell263 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell264 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell265 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell412 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell150 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell154 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell268 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell323 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell266 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell267 = new IHIS.Framework.XEditGridCell();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xEditGridCell165 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.layOutOrder = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mlayConstantInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layMagam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderJungbo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJusaOrderPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJusaLable)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pnlMiMagam.SuspendLayout();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMiMagamOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMiMagamJUSAOrder)).BeginInit();
            this.xPanel6.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaQuery)).BeginInit();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList2)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.pnlMagam.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamJUSAOrder)).BeginInit();
            this.xPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.xPanel9.SuspendLayout();
            this.xPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJusaDcOrder)).BeginInit();
            this.xPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaDcList)).BeginInit();
            this.xPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnListDc)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.xPanel14.SuspendLayout();
            this.xPanel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrnOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrnJusaOrder)).BeginInit();
            this.xPanel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaPrnQuery)).BeginInit();
            this.xPanel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOutOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "YESEN1.ICO");
            this.ImageList.Images.SetKeyName(4, "YESUP1.ICO");
            this.ImageList.Images.SetKeyName(5, "aquapuls.gif");
            this.ImageList.Images.SetKeyName(6, "미리보기.gif");
            this.ImageList.Images.SetKeyName(7, "출력.gif");
            this.ImageList.Images.SetKeyName(8, "이석.gif");
            this.ImageList.Images.SetKeyName(9, "적용.gif");
            this.ImageList.Images.SetKeyName(10, "1378574239_25466.ico");
            this.ImageList.Images.SetKeyName(11, "1378574249_25467.ico");
            this.ImageList.Images.SetKeyName(12, "그린볼.gif");
            this.ImageList.Images.SetKeyName(13, "블루볼.gif");
            this.ImageList.Images.SetKeyName(14, "핑크볼.gif");
            this.ImageList.Images.SetKeyName(15, "sun.gif");
            this.ImageList.Images.SetKeyName(16, "04.gif");
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.dtpJubsuDate);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dtpMagamDate);
            this.xPanel1.Controls.Add(this.cbxActor);
            this.xPanel1.Controls.Add(this.txtTimeInterval);
            this.xPanel1.Controls.Add(this.xLabel6);
            this.xPanel1.Controls.Add(this.paBox);
            this.xPanel1.Controls.Add(this.tbxTimer);
            this.xPanel1.Controls.Add(this.cboTime);
            this.xPanel1.Controls.Add(this.lbTime);
            this.xPanel1.Controls.Add(this.xLabel8);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Controls.Add(this.cbxBuseo);
            this.xPanel1.Controls.Add(this.xLabel7);
            this.xPanel1.Controls.Add(this.dtpToDate);
            this.xPanel1.Controls.Add(this.dtpFromDate);
            this.xPanel1.Controls.Add(this.xLabel5);
            this.xPanel1.Controls.Add(this.lbDate);
            this.xPanel1.Controls.Add(this.cbxGubun);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Name = "xLabel3";
            // 
            // dtpJubsuDate
            // 
            resources.ApplyResources(this.dtpJubsuDate, "dtpJubsuDate");
            this.dtpJubsuDate.IsVietnameseYearType = false;
            this.dtpJubsuDate.Name = "dtpJubsuDate";
            this.dtpJubsuDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpJubsuDate_DataValidating);
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Name = "xLabel2";
            // 
            // dtpMagamDate
            // 
            resources.ApplyResources(this.dtpMagamDate, "dtpMagamDate");
            this.dtpMagamDate.IsVietnameseYearType = false;
            this.dtpMagamDate.Name = "dtpMagamDate";
            // 
            // cbxActor
            // 
            resources.ApplyResources(this.cbxActor, "cbxActor");
            this.cbxActor.ExecuteQuery = null;
            this.cbxActor.Name = "cbxActor";
            this.cbxActor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxActor.ParamList")));
            this.cbxActor.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxActor.UserSQL = resources.GetString("cbxActor.UserSQL");
            // 
            // txtTimeInterval
            // 
            resources.ApplyResources(this.txtTimeInterval, "txtTimeInterval");
            this.txtTimeInterval.Name = "txtTimeInterval";
            this.txtTimeInterval.TabStop = false;
            this.txtTimeInterval.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtTimeInterval_DataValidating);
            // 
            // xLabel6
            // 
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Name = "xLabel6";
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // tbxTimer
            // 
            resources.ApplyResources(this.tbxTimer, "tbxTimer");
            this.tbxTimer.Name = "tbxTimer";
            // 
            // cboTime
            // 
            resources.ApplyResources(this.cboTime, "cboTime");
            this.cboTime.ExecuteQuery = null;
            this.cboTime.Name = "cboTime";
            this.cboTime.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTime.ParamList")));
            this.cboTime.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboTime.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM NUR0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE(" +
    ")\r\n   AND CODE_TYPE = \'NUR2001U04_TIMER\'\r\n ORDER BY TO_NUMBER(CODE)";
            this.cboTime.SelectionChangeCommitted += new System.EventHandler(this.cboTime_SelectionChangeCommitted);
            // 
            // lbTime
            // 
            resources.ApplyResources(this.lbTime, "lbTime");
            this.lbTime.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbTime.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.lbTime.Name = "lbTime";
            // 
            // xLabel8
            // 
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel8.Name = "xLabel8";
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Name = "xLabel4";
            // 
            // cbxBuseo
            // 
            resources.ApplyResources(this.cbxBuseo, "cbxBuseo");
            this.cbxBuseo.ExecuteQuery = null;
            this.cbxBuseo.Name = "cbxBuseo";
            this.cbxBuseo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxBuseo.ParamList")));
            this.cbxBuseo.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxBuseo.UserSQL = resources.GetString("cbxBuseo.UserSQL");
            this.cbxBuseo.SelectionChangeCommitted += new System.EventHandler(this.cbxBuseo_SelectionChangeCommitted);
            // 
            // xLabel7
            // 
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Name = "xLabel7";
            // 
            // dtpToDate
            // 
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.IsVietnameseYearType = false;
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpToDate_DataValidating);
            // 
            // dtpFromDate
            // 
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.IsVietnameseYearType = false;
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFromDate_DataValidating);
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel5.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel5.Name = "xLabel5";
            // 
            // lbDate
            // 
            resources.ApplyResources(this.lbDate, "lbDate");
            this.lbDate.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lbDate.EdgeRounding = false;
            this.lbDate.Name = "lbDate";
            // 
            // cbxGubun
            // 
            resources.ApplyResources(this.cbxGubun, "cbxGubun");
            this.cbxGubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem9,
            this.xComboItem10,
            this.xComboItem4,
            this.xComboItem21,
            this.xComboItem22,
            this.xComboItem23,
            this.xComboItem3});
            this.cbxGubun.Name = "cbxGubun";
            this.cbxGubun.SelectionChangeCommitted += new System.EventHandler(this.cbxGubun_SelectionChangeCommitted);
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "%";
            // 
            // xComboItem9
            // 
            resources.ApplyResources(this.xComboItem9, "xComboItem9");
            this.xComboItem9.ValueItem = "21";
            // 
            // xComboItem10
            // 
            resources.ApplyResources(this.xComboItem10, "xComboItem10");
            this.xComboItem10.ValueItem = "22";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "31";
            // 
            // xComboItem21
            // 
            resources.ApplyResources(this.xComboItem21, "xComboItem21");
            this.xComboItem21.ValueItem = "32";
            // 
            // xComboItem22
            // 
            resources.ApplyResources(this.xComboItem22, "xComboItem22");
            this.xComboItem22.ValueItem = "P1";
            // 
            // xComboItem23
            // 
            resources.ApplyResources(this.xComboItem23, "xComboItem23");
            this.xComboItem23.ValueItem = "P2";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "ER";
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel1.Name = "xLabel1";
            // 
            // btnMagamStops
            // 
            resources.ApplyResources(this.btnMagamStops, "btnMagamStops");
            this.btnMagamStops.ImageIndex = 3;
            this.btnMagamStops.ImageList = this.ImageList;
            this.btnMagamStops.Name = "btnMagamStops";
            this.btnMagamStops.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnMagamStops.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMagamStops.Click += new System.EventHandler(this.btnMagamStop_Click);
            // 
            // btnMagamStarts
            // 
            resources.ApplyResources(this.btnMagamStarts, "btnMagamStarts");
            this.btnMagamStarts.ImageIndex = 4;
            this.btnMagamStarts.ImageList = this.ImageList;
            this.btnMagamStarts.Name = "btnMagamStarts";
            this.btnMagamStarts.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnMagamStarts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMagamStarts.Click += new System.EventHandler(this.btnMagamStart_Click);
            // 
            // xPanel3
            // 
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Controls.Add(this.btnPrintAdmMedi);
            this.xPanel3.Controls.Add(this.btnAtcTrans);
            this.xPanel3.Controls.Add(this.btnReLabelPrint);
            this.xPanel3.Controls.Add(this.btnCancel);
            this.xPanel3.Controls.Add(this.btnRePrint);
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnPrintAdmMedi
            // 
            resources.ApplyResources(this.btnPrintAdmMedi, "btnPrintAdmMedi");
            this.btnPrintAdmMedi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnPrintAdmMedi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintAdmMedi.ImageIndex = 2;
            this.btnPrintAdmMedi.ImageList = this.ImageList;
            this.btnPrintAdmMedi.Name = "btnPrintAdmMedi";
            this.btnPrintAdmMedi.Click += new System.EventHandler(this.btnPrintAdmMedi_Click);
            // 
            // btnAtcTrans
            // 
            resources.ApplyResources(this.btnAtcTrans, "btnAtcTrans");
            this.btnAtcTrans.Image = global::IHIS.DRGS.Properties.Resources.검사예약_1;
            this.btnAtcTrans.Name = "btnAtcTrans";
            this.btnAtcTrans.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnAtcTrans.Click += new System.EventHandler(this.btnAtcTrans_Click);
            // 
            // btnReLabelPrint
            // 
            resources.ApplyResources(this.btnReLabelPrint, "btnReLabelPrint");
            this.btnReLabelPrint.ImageIndex = 2;
            this.btnReLabelPrint.ImageList = this.ImageList;
            this.btnReLabelPrint.Name = "btnReLabelPrint";
            this.btnReLabelPrint.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnReLabelPrint.Click += new System.EventHandler(this.btnReLabelPrint_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.ImageIndex = 9;
            this.btnCancel.ImageList = this.ImageList;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRePrint
            // 
            resources.ApplyResources(this.btnRePrint, "btnRePrint");
            this.btnRePrint.ImageIndex = 2;
            this.btnRePrint.ImageList = this.ImageList;
            this.btnRePrint.Name = "btnRePrint";
            this.btnRePrint.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnRePrint.Click += new System.EventHandler(this.btnRePrint_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // layMagam
            // 
            this.layMagam.ExecuteQuery = null;
            this.layMagam.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem171,
            this.multiLayoutItem172});
            this.layMagam.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layMagam.ParamList")));
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
            this.multiLayoutItem3.DataName = "jubsu_date";
            this.multiLayoutItem3.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "drg_bunho";
            // 
            // multiLayoutItem171
            // 
            this.multiLayoutItem171.DataName = "magam_gubun";
            // 
            // multiLayoutItem172
            // 
            this.multiLayoutItem172.DataName = "jusa_yn";
            // 
            // layOrderJungbo
            // 
            this.layOrderJungbo.ExecuteQuery = null;
            this.layOrderJungbo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem20});
            this.layOrderJungbo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderJungbo.ParamList")));
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "text_1";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "text_2";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "text_3";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "comments";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "bunho_comments";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "bar_drg_bunho";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "bar_rp_bunho";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "cpl_1";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "cpl_2";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "cpl_3";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "danui_1";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "danui_2";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "danui_3";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "hl_1";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "hl_2";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "hl_3";
            // 
            // layOrderPrint
            // 
            this.layOrderPrint.ExecuteQuery = null;
            this.layOrderPrint.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem34,
            this.multiLayoutItem35,
            this.multiLayoutItem36,
            this.multiLayoutItem37,
            this.multiLayoutItem38,
            this.multiLayoutItem39,
            this.multiLayoutItem40,
            this.multiLayoutItem41,
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
            this.multiLayoutItem232,
            this.multiLayoutItem233,
            this.multiLayoutItem234,
            this.multiLayoutItem235,
            this.multiLayoutItem237,
            this.multiLayoutItem238,
            this.multiLayoutItem239,
            this.multiLayoutItem240,
            this.multiLayoutItem241});
            this.layOrderPrint.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderPrint.ParamList")));
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "bunho";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "drg_bunho";
            this.multiLayoutItem22.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "naewon_date";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "group_ser";
            this.multiLayoutItem25.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "jubsu_date";
            this.multiLayoutItem26.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "hope_date";
            this.multiLayoutItem27.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "order_date";
            this.multiLayoutItem28.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "jaeryo_code";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "nalsu";
            this.multiLayoutItem30.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "divide";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "ord_surang";
            this.multiLayoutItem32.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "order_suryang";
            this.multiLayoutItem33.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "order_danui";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "subul_danui";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "group_yn";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "jaeryo_gubun";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "bogyong_code";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "bogyong_name";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "caution_name";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "caution_code";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "mix_yn";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "atc_yn";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "dv";
            this.multiLayoutItem46.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "dv_time";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "dc_yn";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "bannab_yn";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "source_fkocs1003";
            this.multiLayoutItem50.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "fkocs1003";
            this.multiLayoutItem51.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "sunab_date";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "pattern";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "jaeryo_name";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "sunab_nalsu";
            this.multiLayoutItem55.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "wonyoi_yn";
            // 
            // multiLayoutItem94
            // 
            this.multiLayoutItem94.DataName = "order_remark";
            // 
            // multiLayoutItem95
            // 
            this.multiLayoutItem95.DataName = "act_date";
            // 
            // multiLayoutItem96
            // 
            this.multiLayoutItem96.DataName = "mayak";
            // 
            // multiLayoutItem97
            // 
            this.multiLayoutItem97.DataName = "tpn_joje_gubun";
            // 
            // multiLayoutItem98
            // 
            this.multiLayoutItem98.DataName = "ui_jusa_yn";
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "subul_suryang";
            this.multiLayoutItem99.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem100
            // 
            this.multiLayoutItem100.DataName = "serial_v";
            // 
            // multiLayoutItem101
            // 
            this.multiLayoutItem101.DataName = "gwa_name";
            // 
            // multiLayoutItem102
            // 
            this.multiLayoutItem102.DataName = "doctor_name";
            // 
            // multiLayoutItem103
            // 
            this.multiLayoutItem103.DataName = "suname";
            // 
            // multiLayoutItem104
            // 
            this.multiLayoutItem104.DataName = "suname2";
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "birth";
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "age";
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "other_gwa";
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "do_order";
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "gubun_name";
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "powder_yn";
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "line";
            this.multiLayoutItem111.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "kyukyeok";
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "licenes";
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "bunryu1";
            // 
            // multiLayoutItem115
            // 
            this.multiLayoutItem115.DataName = "ho_dong";
            // 
            // multiLayoutItem116
            // 
            this.multiLayoutItem116.DataName = "ho_code";
            // 
            // multiLayoutItem117
            // 
            this.multiLayoutItem117.DataName = "title";
            // 
            // multiLayoutItem118
            // 
            this.multiLayoutItem118.DataName = "donbok";
            // 
            // multiLayoutItem119
            // 
            this.multiLayoutItem119.DataName = "tusuk";
            // 
            // multiLayoutItem232
            // 
            this.multiLayoutItem232.DataName = "magam_gubun";
            // 
            // multiLayoutItem233
            // 
            this.multiLayoutItem233.DataName = "text_color";
            // 
            // multiLayoutItem234
            // 
            this.multiLayoutItem234.DataName = "changgo";
            // 
            // multiLayoutItem235
            // 
            this.multiLayoutItem235.DataName = "from_order_date";
            // 
            // multiLayoutItem237
            // 
            this.multiLayoutItem237.DataName = "to_order_date";
            // 
            // multiLayoutItem238
            // 
            this.multiLayoutItem238.DataName = "data_gubun";
            // 
            // multiLayoutItem239
            // 
            this.multiLayoutItem239.DataName = "print_gubun";
            // 
            // multiLayoutItem240
            // 
            this.multiLayoutItem240.DataName = "hodong_ord_name";
            // 
            // multiLayoutItem241
            // 
            this.multiLayoutItem241.DataName = "max_bannab_yn";
            // 
            // layJusaOrderPrint
            // 
            this.layJusaOrderPrint.ExecuteQuery = null;
            this.layJusaOrderPrint.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem92});
            this.layJusaOrderPrint.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layJusaOrderPrint.ParamList")));
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "bunho";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "suname";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "suname2";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "birth";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "age";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "drg_bunho";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "ho_dong";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "ho_code";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "magam_gubun";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "gwa_name";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "doctor_name";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "jubsu_date";
            this.multiLayoutItem68.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "serial_v";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "resident_name";
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "jusa";
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "jaeryo_name";
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "bogyong_name";
            // 
            // multiLayoutItem74
            // 
            this.multiLayoutItem74.DataName = "ord_surang";
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "order_danui";
            // 
            // multiLayoutItem76
            // 
            this.multiLayoutItem76.DataName = "dv";
            // 
            // multiLayoutItem77
            // 
            this.multiLayoutItem77.DataName = "subul_surang";
            // 
            // multiLayoutItem78
            // 
            this.multiLayoutItem78.DataName = "subul_danui";
            // 
            // multiLayoutItem79
            // 
            this.multiLayoutItem79.DataName = "order_remark";
            // 
            // multiLayoutItem80
            // 
            this.multiLayoutItem80.DataName = "rp_barcode";
            // 
            // multiLayoutItem81
            // 
            this.multiLayoutItem81.DataName = "order_date";
            this.multiLayoutItem81.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "order_suryang";
            // 
            // multiLayoutItem83
            // 
            this.multiLayoutItem83.DataName = "jusa_nalsu";
            // 
            // multiLayoutItem84
            // 
            this.multiLayoutItem84.DataName = "data_gubun";
            // 
            // multiLayoutItem85
            // 
            this.multiLayoutItem85.DataName = "barcode";
            // 
            // multiLayoutItem86
            // 
            this.multiLayoutItem86.DataName = "print_gubun";
            // 
            // multiLayoutItem87
            // 
            this.multiLayoutItem87.DataName = "hodong_ord_name";
            // 
            // multiLayoutItem88
            // 
            this.multiLayoutItem88.DataName = "sort_key";
            // 
            // multiLayoutItem89
            // 
            this.multiLayoutItem89.DataName = "max_bannab_yn";
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "bannab_yn";
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "fkocs2003";
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "hope_date";
            // 
            // layOrderBarcode
            // 
            this.layOrderBarcode.ExecuteQuery = null;
            this.layOrderBarcode.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem120,
            this.multiLayoutItem121,
            this.multiLayoutItem122,
            this.multiLayoutItem123,
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
            this.multiLayoutItem135});
            this.layOrderBarcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderBarcode.ParamList")));
            // 
            // multiLayoutItem120
            // 
            this.multiLayoutItem120.DataName = "text_1";
            // 
            // multiLayoutItem121
            // 
            this.multiLayoutItem121.DataName = "text_2";
            // 
            // multiLayoutItem122
            // 
            this.multiLayoutItem122.DataName = "text_3";
            // 
            // multiLayoutItem123
            // 
            this.multiLayoutItem123.DataName = "comments";
            // 
            // multiLayoutItem124
            // 
            this.multiLayoutItem124.DataName = "bunho_comments";
            // 
            // multiLayoutItem125
            // 
            this.multiLayoutItem125.DataName = "bar_drg_bunho";
            // 
            // multiLayoutItem126
            // 
            this.multiLayoutItem126.DataName = "bar_rp_bunho";
            // 
            // multiLayoutItem127
            // 
            this.multiLayoutItem127.DataName = "cpl_1";
            // 
            // multiLayoutItem128
            // 
            this.multiLayoutItem128.DataName = "cpl_2";
            // 
            // multiLayoutItem129
            // 
            this.multiLayoutItem129.DataName = "cpl_3";
            // 
            // multiLayoutItem130
            // 
            this.multiLayoutItem130.DataName = "danui_1";
            // 
            // multiLayoutItem131
            // 
            this.multiLayoutItem131.DataName = "danui_2";
            // 
            // multiLayoutItem132
            // 
            this.multiLayoutItem132.DataName = "danui_3";
            // 
            // multiLayoutItem133
            // 
            this.multiLayoutItem133.DataName = "hl_1";
            // 
            // multiLayoutItem134
            // 
            this.multiLayoutItem134.DataName = "hl_2";
            // 
            // multiLayoutItem135
            // 
            this.multiLayoutItem135.DataName = "hl_3";
            // 
            // layJusaLable
            // 
            this.layJusaLable.ExecuteQuery = null;
            this.layJusaLable.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem147,
            this.multiLayoutItem148,
            this.multiLayoutItem149,
            this.multiLayoutItem150,
            this.multiLayoutItem151,
            this.multiLayoutItem152,
            this.multiLayoutItem153,
            this.multiLayoutItem154,
            this.multiLayoutItem155,
            this.multiLayoutItem156,
            this.multiLayoutItem157,
            this.multiLayoutItem158,
            this.multiLayoutItem159,
            this.multiLayoutItem160,
            this.multiLayoutItem161,
            this.multiLayoutItem162,
            this.multiLayoutItem163,
            this.multiLayoutItem164,
            this.multiLayoutItem195});
            this.layJusaLable.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layJusaLable.ParamList")));
            // 
            // multiLayoutItem136
            // 
            this.multiLayoutItem136.DataName = "bunho";
            // 
            // multiLayoutItem137
            // 
            this.multiLayoutItem137.DataName = "suname";
            // 
            // multiLayoutItem138
            // 
            this.multiLayoutItem138.DataName = "suname2";
            // 
            // multiLayoutItem139
            // 
            this.multiLayoutItem139.DataName = "birth";
            // 
            // multiLayoutItem140
            // 
            this.multiLayoutItem140.DataName = "age";
            // 
            // multiLayoutItem141
            // 
            this.multiLayoutItem141.DataName = "drg_bunho";
            // 
            // multiLayoutItem142
            // 
            this.multiLayoutItem142.DataName = "ho_dong";
            // 
            // multiLayoutItem143
            // 
            this.multiLayoutItem143.DataName = "ho_code";
            // 
            // multiLayoutItem144
            // 
            this.multiLayoutItem144.DataName = "magam_gubun";
            // 
            // multiLayoutItem145
            // 
            this.multiLayoutItem145.DataName = "gwa_name";
            // 
            // multiLayoutItem146
            // 
            this.multiLayoutItem146.DataName = "doctor_name";
            // 
            // multiLayoutItem147
            // 
            this.multiLayoutItem147.DataName = "jubsu_date";
            this.multiLayoutItem147.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem148
            // 
            this.multiLayoutItem148.DataName = "serial_v";
            // 
            // multiLayoutItem149
            // 
            this.multiLayoutItem149.DataName = "resident_name";
            // 
            // multiLayoutItem150
            // 
            this.multiLayoutItem150.DataName = "jusa";
            // 
            // multiLayoutItem151
            // 
            this.multiLayoutItem151.DataName = "jaeryo_name";
            // 
            // multiLayoutItem152
            // 
            this.multiLayoutItem152.DataName = "bogyong_name";
            // 
            // multiLayoutItem153
            // 
            this.multiLayoutItem153.DataName = "ord_surang";
            // 
            // multiLayoutItem154
            // 
            this.multiLayoutItem154.DataName = "order_danui";
            // 
            // multiLayoutItem155
            // 
            this.multiLayoutItem155.DataName = "dv";
            // 
            // multiLayoutItem156
            // 
            this.multiLayoutItem156.DataName = "subul_surang";
            // 
            // multiLayoutItem157
            // 
            this.multiLayoutItem157.DataName = "subul_danui";
            // 
            // multiLayoutItem158
            // 
            this.multiLayoutItem158.DataName = "order_remark";
            // 
            // multiLayoutItem159
            // 
            this.multiLayoutItem159.DataName = "rp_barcode";
            // 
            // multiLayoutItem160
            // 
            this.multiLayoutItem160.DataName = "hope_date";
            // 
            // multiLayoutItem161
            // 
            this.multiLayoutItem161.DataName = "order_date";
            this.multiLayoutItem161.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem162
            // 
            this.multiLayoutItem162.DataName = "order_suryang";
            // 
            // multiLayoutItem163
            // 
            this.multiLayoutItem163.DataName = "rp2";
            // 
            // multiLayoutItem164
            // 
            this.multiLayoutItem164.DataName = "data_gubun";
            // 
            // multiLayoutItem195
            // 
            this.multiLayoutItem195.DataName = "line";
            this.multiLayoutItem195.DataType = IHIS.Framework.DataType.Number;
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.IDEPixelArea = true;
            this.tabControl.IDEPixelBorder = false;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SelectedTab = this.tabPage2;
            this.tabControl.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabPage2,
            this.tabPage1,
            this.tabPage3,
            this.tabPage4});
            this.tabControl.SelectionChanged += new System.EventHandler(this.tabControl_SelectionChanged);
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.pnlMiMagam);
            this.tabPage2.ImageIndex = 12;
            this.tabPage2.ImageList = this.ImageList;
            this.tabPage2.Name = "tabPage2";
            // 
            // pnlMiMagam
            // 
            resources.ApplyResources(this.pnlMiMagam, "pnlMiMagam");
            this.pnlMiMagam.Controls.Add(this.xPanel8);
            this.pnlMiMagam.Controls.Add(this.xPanel6);
            this.pnlMiMagam.Controls.Add(this.xPanel5);
            this.pnlMiMagam.Name = "pnlMiMagam";
            // 
            // xPanel8
            // 
            resources.ApplyResources(this.xPanel8, "xPanel8");
            this.xPanel8.Controls.Add(this.grdMiMagamOrder);
            this.xPanel8.Controls.Add(this.grdMiMagamJUSAOrder);
            this.xPanel8.DrawBorder = true;
            this.xPanel8.Name = "xPanel8";
            // 
            // grdMiMagamOrder
            // 
            this.grdMiMagamOrder.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdMiMagamOrder, "grdMiMagamOrder");
            this.grdMiMagamOrder.ApplyPaintEventToAllColumn = true;
            this.grdMiMagamOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell61,
            this.xEditGridCell70,
            this.xEditGridCell62,
            this.xEditGridCell65,
            this.xEditGridCell63,
            this.xEditGridCell64,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell69,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell73,
            this.xEditGridCell74,
            this.xEditGridCell75,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell84,
            this.xEditGridCell315,
            this.xEditGridCell319,
            this.xEditGridCell317,
            this.xEditGridCell85,
            this.xEditGridCell321,
            this.xEditGridCell334,
            this.xEditGridCell335,
            this.xEditGridCell134,
            this.xEditGridCell135,
            this.xEditGridCell140,
            this.xEditGridCell162,
            this.xEditGridCell426,
            this.xEditGridCell429});
            this.grdMiMagamOrder.ColPerLine = 12;
            this.grdMiMagamOrder.Cols = 13;
            this.grdMiMagamOrder.ExecuteQuery = null;
            this.grdMiMagamOrder.FixedCols = 1;
            this.grdMiMagamOrder.FixedRows = 2;
            this.grdMiMagamOrder.HeaderHeights.Add(39);
            this.grdMiMagamOrder.HeaderHeights.Add(0);
            this.grdMiMagamOrder.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader2});
            this.grdMiMagamOrder.Name = "grdMiMagamOrder";
            this.grdMiMagamOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMiMagamOrder.ParamList")));
            this.grdMiMagamOrder.QuerySQL = resources.GetString("grdMiMagamOrder.QuerySQL");
            this.grdMiMagamOrder.RowHeaderVisible = true;
            this.grdMiMagamOrder.Rows = 3;
            this.grdMiMagamOrder.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdMiMagamOrder.TabStop = false;
            this.grdMiMagamOrder.ToolTipActive = true;
            this.grdMiMagamOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdMiMagamOrder_GridCellPainting);
            this.grdMiMagamOrder.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdPackPowder_GridColumnChanged);
            this.grdMiMagamOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMiMagamOrder_QueryStarting);
            this.grdMiMagamOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdMagamOrder_QueryEnd);
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "order_date";
            this.xEditGridCell61.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell61.CellWidth = 77;
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsReadOnly = true;
            this.xEditGridCell61.IsUpdCol = false;
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            this.xEditGridCell61.SuppressRepeating = true;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "mix_group";
            this.xEditGridCell70.CellWidth = 20;
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsReadOnly = true;
            this.xEditGridCell70.IsUpdCol = false;
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            this.xEditGridCell70.SuppressRepeating = true;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "jaeryo_code";
            this.xEditGridCell62.CellWidth = 77;
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsReadOnly = true;
            this.xEditGridCell62.IsUpdCol = false;
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            this.xEditGridCell62.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "jaeryo_name";
            this.xEditGridCell65.CellWidth = 264;
            this.xEditGridCell65.Col = 2;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsReadOnly = true;
            this.xEditGridCell65.IsUpdCol = false;
            this.xEditGridCell65.RowSpan = 2;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "ord_suryang";
            this.xEditGridCell63.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell63.CellWidth = 57;
            this.xEditGridCell63.Col = 3;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsReadOnly = true;
            this.xEditGridCell63.IsUpdCol = false;
            this.xEditGridCell63.RowSpan = 2;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "dv_time";
            this.xEditGridCell64.CellWidth = 20;
            this.xEditGridCell64.Col = 4;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsReadOnly = true;
            this.xEditGridCell64.IsUpdCol = false;
            this.xEditGridCell64.Row = 1;
            this.xEditGridCell64.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "dv";
            this.xEditGridCell66.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell66.CellWidth = 22;
            this.xEditGridCell66.Col = 5;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsReadOnly = true;
            this.xEditGridCell66.IsUpdCol = false;
            this.xEditGridCell66.Row = 1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "nalsu";
            this.xEditGridCell67.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell67.CellWidth = 32;
            this.xEditGridCell67.Col = 7;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsReadOnly = true;
            this.xEditGridCell67.IsUpdCol = false;
            this.xEditGridCell67.RowSpan = 2;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "order_danui";
            this.xEditGridCell68.CellWidth = 50;
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsReadOnly = true;
            this.xEditGridCell68.IsUpdCol = false;
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "danui_name";
            this.xEditGridCell69.CellWidth = 49;
            this.xEditGridCell69.Col = 6;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsReadOnly = true;
            this.xEditGridCell69.IsUpdCol = false;
            this.xEditGridCell69.RowSpan = 2;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "bogyong_code";
            this.xEditGridCell71.CellWidth = 197;
            this.xEditGridCell71.Col = -1;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsReadOnly = true;
            this.xEditGridCell71.IsUpdCol = false;
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "bogyong_name";
            this.xEditGridCell72.CellWidth = 122;
            this.xEditGridCell72.Col = 8;
            this.xEditGridCell72.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsReadOnly = true;
            this.xEditGridCell72.IsUpdCol = false;
            this.xEditGridCell72.RowSpan = 2;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "powder_yn";
            this.xEditGridCell73.CellWidth = 35;
            this.xEditGridCell73.Col = 10;
            this.xEditGridCell73.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell73.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsUpdCol = false;
            this.xEditGridCell73.RowSpan = 2;
            this.xEditGridCell73.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellLen = 100;
            this.xEditGridCell74.CellName = "remark";
            this.xEditGridCell74.CellWidth = 55;
            this.xEditGridCell74.Col = 12;
            this.xEditGridCell74.DisplayMemoText = true;
            this.xEditGridCell74.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell74.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsUpdCol = false;
            this.xEditGridCell74.RowSpan = 2;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "dv_1";
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsReadOnly = true;
            this.xEditGridCell75.IsUpdCol = false;
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "dv_2";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsReadOnly = true;
            this.xEditGridCell76.IsUpdCol = false;
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "dv_3";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsReadOnly = true;
            this.xEditGridCell77.IsUpdCol = false;
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "dv_4";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsReadOnly = true;
            this.xEditGridCell78.IsUpdCol = false;
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "dv_5";
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsReadOnly = true;
            this.xEditGridCell79.IsUpdCol = false;
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "hubal_change_yn";
            this.xEditGridCell80.CellWidth = 21;
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsReadOnly = true;
            this.xEditGridCell80.IsUpdCol = false;
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            this.xEditGridCell80.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "pharmacy";
            this.xEditGridCell81.CellWidth = 92;
            this.xEditGridCell81.Col = 11;
            this.xEditGridCell81.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsReadOnly = true;
            this.xEditGridCell81.IsUpdCol = false;
            this.xEditGridCell81.RowSpan = 2;
            this.xEditGridCell81.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "drg_pack_yn";
            this.xEditGridCell82.CellWidth = 40;
            this.xEditGridCell82.Col = 9;
            this.xEditGridCell82.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsUpdCol = false;
            this.xEditGridCell82.RowSpan = 2;
            this.xEditGridCell82.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "jusa";
            this.xEditGridCell84.CellWidth = 43;
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsReadOnly = true;
            this.xEditGridCell84.IsUpdCol = false;
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            this.xEditGridCell84.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell315
            // 
            this.xEditGridCell315.CellName = "suname";
            this.xEditGridCell315.Col = -1;
            this.xEditGridCell315.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell315, "xEditGridCell315");
            this.xEditGridCell315.IsUpdCol = false;
            this.xEditGridCell315.IsVisible = false;
            this.xEditGridCell315.Row = -1;
            // 
            // xEditGridCell319
            // 
            this.xEditGridCell319.CellName = "drg_bunho";
            this.xEditGridCell319.Col = -1;
            this.xEditGridCell319.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell319, "xEditGridCell319");
            this.xEditGridCell319.IsUpdCol = false;
            this.xEditGridCell319.IsVisible = false;
            this.xEditGridCell319.Row = -1;
            // 
            // xEditGridCell317
            // 
            this.xEditGridCell317.CellName = "fkocs2003";
            this.xEditGridCell317.Col = -1;
            this.xEditGridCell317.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell317, "xEditGridCell317");
            this.xEditGridCell317.IsVisible = false;
            this.xEditGridCell317.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "append_yn";
            this.xEditGridCell85.CellWidth = 21;
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsReadOnly = true;
            this.xEditGridCell85.IsUpdatable = false;
            this.xEditGridCell85.IsUpdCol = false;
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell321
            // 
            this.xEditGridCell321.CellName = "re_use_yn";
            this.xEditGridCell321.Col = -1;
            this.xEditGridCell321.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell321, "xEditGridCell321");
            this.xEditGridCell321.IsVisible = false;
            this.xEditGridCell321.Row = -1;
            // 
            // xEditGridCell334
            // 
            this.xEditGridCell334.CellName = "hope_date";
            this.xEditGridCell334.Col = -1;
            this.xEditGridCell334.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell334, "xEditGridCell334");
            this.xEditGridCell334.IsUpdCol = false;
            this.xEditGridCell334.IsVisible = false;
            this.xEditGridCell334.Row = -1;
            // 
            // xEditGridCell335
            // 
            this.xEditGridCell335.CellName = "hope_time";
            this.xEditGridCell335.Col = -1;
            this.xEditGridCell335.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell335, "xEditGridCell335");
            this.xEditGridCell335.IsUpdCol = false;
            this.xEditGridCell335.IsVisible = false;
            this.xEditGridCell335.Row = -1;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "group_ser";
            this.xEditGridCell134.CellWidth = 26;
            this.xEditGridCell134.Col = 1;
            this.xEditGridCell134.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell134, "xEditGridCell134");
            this.xEditGridCell134.IsReadOnly = true;
            this.xEditGridCell134.IsUpdatable = false;
            this.xEditGridCell134.IsUpdCol = false;
            this.xEditGridCell134.RowSpan = 2;
            this.xEditGridCell134.SuppressRepeating = true;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "dc_yn";
            this.xEditGridCell135.Col = -1;
            this.xEditGridCell135.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell135, "xEditGridCell135");
            this.xEditGridCell135.IsUpdCol = false;
            this.xEditGridCell135.IsVisible = false;
            this.xEditGridCell135.Row = -1;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.CellName = "order_gubun";
            this.xEditGridCell140.Col = -1;
            this.xEditGridCell140.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell140, "xEditGridCell140");
            this.xEditGridCell140.IsUpdCol = false;
            this.xEditGridCell140.IsVisible = false;
            this.xEditGridCell140.Row = -1;
            // 
            // xEditGridCell162
            // 
            this.xEditGridCell162.CellName = "if_input_control";
            this.xEditGridCell162.Col = -1;
            this.xEditGridCell162.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell162, "xEditGridCell162");
            this.xEditGridCell162.IsVisible = false;
            this.xEditGridCell162.Row = -1;
            // 
            // xEditGridCell426
            // 
            this.xEditGridCell426.CellName = "brought_drg_yn";
            this.xEditGridCell426.Col = -1;
            this.xEditGridCell426.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell426, "xEditGridCell426");
            this.xEditGridCell426.IsReadOnly = true;
            this.xEditGridCell426.IsVisible = false;
            this.xEditGridCell426.Row = -1;
            // 
            // xEditGridCell429
            // 
            this.xEditGridCell429.CellName = "emergency";
            this.xEditGridCell429.Col = -1;
            this.xEditGridCell429.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell429, "xEditGridCell429");
            this.xEditGridCell429.IsVisible = false;
            this.xEditGridCell429.Row = -1;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 4;
            this.xGridHeader2.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 20;
            // 
            // grdMiMagamJUSAOrder
            // 
            this.grdMiMagamJUSAOrder.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdMiMagamJUSAOrder, "grdMiMagamJUSAOrder");
            this.grdMiMagamJUSAOrder.ApplyPaintEventToAllColumn = true;
            this.grdMiMagamJUSAOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell86,
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
            this.xEditGridCell131,
            this.xEditGridCell132,
            this.xEditGridCell133,
            this.xEditGridCell136,
            this.xEditGridCell137,
            this.xEditGridCell138,
            this.xEditGridCell139,
            this.xEditGridCell141,
            this.xEditGridCell142,
            this.xEditGridCell316,
            this.xEditGridCell320,
            this.xEditGridCell318,
            this.xEditGridCell143,
            this.xEditGridCell322,
            this.xEditGridCell144,
            this.xEditGridCell333,
            this.xEditGridCell145,
            this.xEditGridCell146,
            this.xEditGridCell147,
            this.xEditGridCell163,
            this.xEditGridCell433,
            this.xEditGridCell434});
            this.grdMiMagamJUSAOrder.ColPerLine = 9;
            this.grdMiMagamJUSAOrder.Cols = 10;
            this.grdMiMagamJUSAOrder.ControlBinding = true;
            this.grdMiMagamJUSAOrder.ExecuteQuery = null;
            this.grdMiMagamJUSAOrder.FixedCols = 1;
            this.grdMiMagamJUSAOrder.FixedRows = 2;
            this.grdMiMagamJUSAOrder.HeaderHeights.Add(39);
            this.grdMiMagamJUSAOrder.HeaderHeights.Add(0);
            this.grdMiMagamJUSAOrder.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdMiMagamJUSAOrder.Name = "grdMiMagamJUSAOrder";
            this.grdMiMagamJUSAOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMiMagamJUSAOrder.ParamList")));
            this.grdMiMagamJUSAOrder.QuerySQL = resources.GetString("grdMiMagamJUSAOrder.QuerySQL");
            this.grdMiMagamJUSAOrder.RowHeaderVisible = true;
            this.grdMiMagamJUSAOrder.Rows = 3;
            this.grdMiMagamJUSAOrder.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdMiMagamJUSAOrder.ToolTipActive = true;
            this.grdMiMagamJUSAOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdMiMagamOrder_GridCellPainting);
            this.grdMiMagamJUSAOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMiMagamOrder_QueryStarting);
            this.grdMiMagamJUSAOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdMagamOrder_QueryEnd);
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "order_date";
            this.xEditGridCell86.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell86.CellWidth = 77;
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsReadOnly = true;
            this.xEditGridCell86.IsUpdCol = false;
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            this.xEditGridCell86.SuppressRepeating = true;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "mix_group";
            this.xEditGridCell88.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell88.CellWidth = 20;
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsReadOnly = true;
            this.xEditGridCell88.IsUpdCol = false;
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            this.xEditGridCell88.SuppressRepeating = true;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "jaeryo_code";
            this.xEditGridCell89.CellWidth = 77;
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsReadOnly = true;
            this.xEditGridCell89.IsUpdCol = false;
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            this.xEditGridCell89.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "jaeryo_name";
            this.xEditGridCell90.CellWidth = 305;
            this.xEditGridCell90.Col = 2;
            this.xEditGridCell90.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsReadOnly = true;
            this.xEditGridCell90.IsUpdCol = false;
            this.xEditGridCell90.RowSpan = 2;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "ord_suryang";
            this.xEditGridCell91.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell91.CellWidth = 40;
            this.xEditGridCell91.Col = 3;
            this.xEditGridCell91.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsReadOnly = true;
            this.xEditGridCell91.IsUpdCol = false;
            this.xEditGridCell91.RowSpan = 2;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "dv_time";
            this.xEditGridCell92.CellWidth = 20;
            this.xEditGridCell92.Col = 4;
            this.xEditGridCell92.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsReadOnly = true;
            this.xEditGridCell92.IsUpdCol = false;
            this.xEditGridCell92.Row = 1;
            this.xEditGridCell92.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "dv";
            this.xEditGridCell93.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell93.CellWidth = 22;
            this.xEditGridCell93.Col = 5;
            this.xEditGridCell93.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsReadOnly = true;
            this.xEditGridCell93.IsUpdCol = false;
            this.xEditGridCell93.Row = 1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "nalsu";
            this.xEditGridCell94.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell94.CellWidth = 22;
            this.xEditGridCell94.Col = -1;
            this.xEditGridCell94.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsReadOnly = true;
            this.xEditGridCell94.IsUpdCol = false;
            this.xEditGridCell94.IsVisible = false;
            this.xEditGridCell94.Row = -1;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "order_danui";
            this.xEditGridCell95.CellWidth = 50;
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            this.xEditGridCell95.IsReadOnly = true;
            this.xEditGridCell95.IsUpdCol = false;
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "danui_name";
            this.xEditGridCell96.CellWidth = 65;
            this.xEditGridCell96.Col = 6;
            this.xEditGridCell96.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            this.xEditGridCell96.IsReadOnly = true;
            this.xEditGridCell96.IsUpdCol = false;
            this.xEditGridCell96.RowSpan = 2;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "bogyong_code";
            this.xEditGridCell97.CellWidth = 197;
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            this.xEditGridCell97.IsReadOnly = true;
            this.xEditGridCell97.IsUpdCol = false;
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "bogyong_name";
            this.xEditGridCell98.CellWidth = 72;
            this.xEditGridCell98.Col = 8;
            this.xEditGridCell98.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsReadOnly = true;
            this.xEditGridCell98.IsUpdCol = false;
            this.xEditGridCell98.RowSpan = 2;
            this.xEditGridCell98.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "powder_yn";
            this.xEditGridCell99.CellWidth = 19;
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsReadOnly = true;
            this.xEditGridCell99.IsUpdCol = false;
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            this.xEditGridCell99.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellLen = 100;
            this.xEditGridCell100.CellName = "remark";
            this.xEditGridCell100.CellWidth = 45;
            this.xEditGridCell100.Col = 9;
            this.xEditGridCell100.DisplayMemoText = true;
            this.xEditGridCell100.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell100.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsUpdCol = false;
            this.xEditGridCell100.RowSpan = 2;
            // 
            // xEditGridCell131
            // 
            this.xEditGridCell131.CellName = "dv_1";
            this.xEditGridCell131.Col = -1;
            this.xEditGridCell131.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell131, "xEditGridCell131");
            this.xEditGridCell131.IsReadOnly = true;
            this.xEditGridCell131.IsUpdCol = false;
            this.xEditGridCell131.IsVisible = false;
            this.xEditGridCell131.Row = -1;
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.CellName = "dv_2";
            this.xEditGridCell132.Col = -1;
            this.xEditGridCell132.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell132, "xEditGridCell132");
            this.xEditGridCell132.IsReadOnly = true;
            this.xEditGridCell132.IsUpdCol = false;
            this.xEditGridCell132.IsVisible = false;
            this.xEditGridCell132.Row = -1;
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.CellName = "dv_3";
            this.xEditGridCell133.Col = -1;
            this.xEditGridCell133.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell133, "xEditGridCell133");
            this.xEditGridCell133.IsReadOnly = true;
            this.xEditGridCell133.IsUpdCol = false;
            this.xEditGridCell133.IsVisible = false;
            this.xEditGridCell133.Row = -1;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellName = "dv_4";
            this.xEditGridCell136.Col = -1;
            this.xEditGridCell136.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell136, "xEditGridCell136");
            this.xEditGridCell136.IsReadOnly = true;
            this.xEditGridCell136.IsUpdCol = false;
            this.xEditGridCell136.IsVisible = false;
            this.xEditGridCell136.Row = -1;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "dv_5";
            this.xEditGridCell137.Col = -1;
            this.xEditGridCell137.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell137, "xEditGridCell137");
            this.xEditGridCell137.IsReadOnly = true;
            this.xEditGridCell137.IsUpdCol = false;
            this.xEditGridCell137.IsVisible = false;
            this.xEditGridCell137.Row = -1;
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellName = "hubal_change_yn";
            this.xEditGridCell138.CellWidth = 19;
            this.xEditGridCell138.Col = -1;
            this.xEditGridCell138.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell138, "xEditGridCell138");
            this.xEditGridCell138.IsReadOnly = true;
            this.xEditGridCell138.IsUpdCol = false;
            this.xEditGridCell138.IsVisible = false;
            this.xEditGridCell138.Row = -1;
            this.xEditGridCell138.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.CellName = "pharmacy";
            this.xEditGridCell139.CellWidth = 30;
            this.xEditGridCell139.Col = -1;
            this.xEditGridCell139.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell139, "xEditGridCell139");
            this.xEditGridCell139.IsReadOnly = true;
            this.xEditGridCell139.IsUpdCol = false;
            this.xEditGridCell139.IsVisible = false;
            this.xEditGridCell139.Row = -1;
            this.xEditGridCell139.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.CellName = "drg_pack_yn";
            this.xEditGridCell141.CellWidth = 19;
            this.xEditGridCell141.Col = -1;
            this.xEditGridCell141.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell141, "xEditGridCell141");
            this.xEditGridCell141.IsReadOnly = true;
            this.xEditGridCell141.IsUpdCol = false;
            this.xEditGridCell141.IsVisible = false;
            this.xEditGridCell141.Row = -1;
            this.xEditGridCell141.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.CellName = "jusa";
            this.xEditGridCell142.CellWidth = 110;
            this.xEditGridCell142.Col = 7;
            this.xEditGridCell142.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell142, "xEditGridCell142");
            this.xEditGridCell142.IsReadOnly = true;
            this.xEditGridCell142.IsUpdCol = false;
            this.xEditGridCell142.RowSpan = 2;
            // 
            // xEditGridCell316
            // 
            this.xEditGridCell316.CellName = "suname";
            this.xEditGridCell316.CellWidth = 32;
            this.xEditGridCell316.Col = -1;
            this.xEditGridCell316.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell316, "xEditGridCell316");
            this.xEditGridCell316.IsUpdCol = false;
            this.xEditGridCell316.IsVisible = false;
            this.xEditGridCell316.Row = -1;
            // 
            // xEditGridCell320
            // 
            this.xEditGridCell320.CellName = "drg_bunho";
            this.xEditGridCell320.Col = -1;
            this.xEditGridCell320.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell320, "xEditGridCell320");
            this.xEditGridCell320.IsUpdCol = false;
            this.xEditGridCell320.IsVisible = false;
            this.xEditGridCell320.Row = -1;
            // 
            // xEditGridCell318
            // 
            this.xEditGridCell318.CellName = "fkocs2003";
            this.xEditGridCell318.Col = -1;
            this.xEditGridCell318.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell318, "xEditGridCell318");
            this.xEditGridCell318.IsVisible = false;
            this.xEditGridCell318.Row = -1;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "append_yn";
            this.xEditGridCell143.CellWidth = 19;
            this.xEditGridCell143.Col = -1;
            this.xEditGridCell143.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell143, "xEditGridCell143");
            this.xEditGridCell143.IsReadOnly = true;
            this.xEditGridCell143.IsUpdatable = false;
            this.xEditGridCell143.IsUpdCol = false;
            this.xEditGridCell143.IsVisible = false;
            this.xEditGridCell143.Row = -1;
            // 
            // xEditGridCell322
            // 
            this.xEditGridCell322.CellName = "re_use_yn";
            this.xEditGridCell322.CellWidth = 24;
            this.xEditGridCell322.Col = -1;
            this.xEditGridCell322.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell322, "xEditGridCell322");
            this.xEditGridCell322.IsVisible = false;
            this.xEditGridCell322.Row = -1;
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.CellName = "hope_date";
            this.xEditGridCell144.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell144.Col = -1;
            this.xEditGridCell144.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell144, "xEditGridCell144");
            this.xEditGridCell144.IsUpdCol = false;
            this.xEditGridCell144.IsVisible = false;
            this.xEditGridCell144.Row = -1;
            // 
            // xEditGridCell333
            // 
            this.xEditGridCell333.CellName = "hope_time";
            this.xEditGridCell333.Col = -1;
            this.xEditGridCell333.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell333, "xEditGridCell333");
            this.xEditGridCell333.IsUpdCol = false;
            this.xEditGridCell333.IsVisible = false;
            this.xEditGridCell333.Row = -1;
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.CellName = "group_ser";
            this.xEditGridCell145.CellWidth = 24;
            this.xEditGridCell145.Col = 1;
            this.xEditGridCell145.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell145, "xEditGridCell145");
            this.xEditGridCell145.IsReadOnly = true;
            this.xEditGridCell145.IsUpdatable = false;
            this.xEditGridCell145.IsUpdCol = false;
            this.xEditGridCell145.RowSpan = 2;
            this.xEditGridCell145.SuppressRepeating = true;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.CellName = "dc_yn";
            this.xEditGridCell146.Col = -1;
            this.xEditGridCell146.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell146, "xEditGridCell146");
            this.xEditGridCell146.IsUpdCol = false;
            this.xEditGridCell146.IsVisible = false;
            this.xEditGridCell146.Row = -1;
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.CellName = "order_gubun";
            this.xEditGridCell147.Col = -1;
            this.xEditGridCell147.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell147, "xEditGridCell147");
            this.xEditGridCell147.IsUpdCol = false;
            this.xEditGridCell147.IsVisible = false;
            this.xEditGridCell147.Row = -1;
            // 
            // xEditGridCell163
            // 
            this.xEditGridCell163.CellName = "if_input_control";
            this.xEditGridCell163.Col = -1;
            this.xEditGridCell163.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell163, "xEditGridCell163");
            this.xEditGridCell163.IsReadOnly = true;
            this.xEditGridCell163.IsUpdatable = false;
            this.xEditGridCell163.IsUpdCol = false;
            this.xEditGridCell163.IsVisible = false;
            this.xEditGridCell163.Row = -1;
            // 
            // xEditGridCell433
            // 
            this.xEditGridCell433.CellName = "brought_drg_yn";
            this.xEditGridCell433.Col = -1;
            this.xEditGridCell433.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell433, "xEditGridCell433");
            this.xEditGridCell433.IsVisible = false;
            this.xEditGridCell433.Row = -1;
            // 
            // xEditGridCell434
            // 
            this.xEditGridCell434.CellName = "emergency";
            this.xEditGridCell434.Col = -1;
            this.xEditGridCell434.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell434, "xEditGridCell434");
            this.xEditGridCell434.IsVisible = false;
            this.xEditGridCell434.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 4;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 20;
            // 
            // xPanel6
            // 
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.Controls.Add(this.pnlStatus);
            this.xPanel6.Controls.Add(this.grdPaQuery);
            this.xPanel6.DrawBorder = true;
            this.xPanel6.Name = "xPanel6";
            // 
            // pnlStatus
            // 
            resources.ApplyResources(this.pnlStatus, "pnlStatus");
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.lbStatus);
            this.pnlStatus.Controls.Add(this.pgbProgress);
            this.pnlStatus.Name = "pnlStatus";
            // 
            // lbStatus
            // 
            resources.ApplyResources(this.lbStatus, "lbStatus");
            this.lbStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Name = "lbStatus";
            // 
            // pgbProgress
            // 
            resources.ApplyResources(this.pgbProgress, "pgbProgress");
            this.pgbProgress.Name = "pgbProgress";
            // 
            // grdPaQuery
            // 
            resources.ApplyResources(this.grdPaQuery, "grdPaQuery");
            this.grdPaQuery.ApplyPaintEventToAllColumn = true;
            this.grdPaQuery.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell332,
            this.xEditGridCell157,
            this.xEditGridCell173,
            this.xEditGridCell59,
            this.xEditGridCell83,
            this.xEditGridCell87,
            this.xEditGridCell409,
            this.xEditGridCell60,
            this.xEditGridCell410,
            this.xEditGridCell148,
            this.xEditGridCell149,
            this.xEditGridCell155,
            this.xEditGridCell156,
            this.xEditGridCell428,
            this.xEditGridCell164});
            this.grdPaQuery.ColPerLine = 12;
            this.grdPaQuery.Cols = 13;
            this.grdPaQuery.ExecuteQuery = null;
            this.grdPaQuery.FixedCols = 1;
            this.grdPaQuery.FixedRows = 1;
            this.grdPaQuery.HeaderHeights.Add(39);
            this.grdPaQuery.Name = "grdPaQuery";
            this.grdPaQuery.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPaQuery.ParamList")));
            this.grdPaQuery.QuerySQL = resources.GetString("grdPaQuery.QuerySQL");
            this.grdPaQuery.RowHeaderVisible = true;
            this.grdPaQuery.Rows = 2;
            this.grdPaQuery.TabStop = false;
            this.grdPaQuery.ToolTipActive = true;
            this.grdPaQuery.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdPaQuery_ItemValueChanging);
            this.grdPaQuery.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPaQuery_RowFocusChanged);
            this.grdPaQuery.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPaQuery_QueryStarting);
            this.grdPaQuery.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPaQuery_QueryEnd);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "bunho";
            this.xEditGridCell28.CellWidth = 70;
            this.xEditGridCell28.Col = 8;
            this.xEditGridCell28.EnableSort = true;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.SuppressRepeating = true;
            this.xEditGridCell28.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "suname";
            this.xEditGridCell29.CellWidth = 93;
            this.xEditGridCell29.Col = 9;
            this.xEditGridCell29.EnableSort = true;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.SuppressRepeating = true;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "sex";
            this.xEditGridCell30.CellWidth = 27;
            this.xEditGridCell30.Col = 11;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "age";
            this.xEditGridCell31.CellWidth = 30;
            this.xEditGridCell31.Col = 12;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "resident";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "doctor_name";
            this.xEditGridCell38.CellWidth = 85;
            this.xEditGridCell38.Col = 10;
            this.xEditGridCell38.EnableSort = true;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsReadOnly = true;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "magam_yn";
            this.xEditGridCell39.CellWidth = 31;
            this.xEditGridCell39.Col = 1;
            this.xEditGridCell39.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell39.EnableSort = true;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell332
            // 
            this.xEditGridCell332.CellName = "ho_dong";
            this.xEditGridCell332.CellWidth = 32;
            this.xEditGridCell332.Col = -1;
            this.xEditGridCell332.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell332, "xEditGridCell332");
            this.xEditGridCell332.IsReadOnly = true;
            this.xEditGridCell332.IsUpdatable = false;
            this.xEditGridCell332.IsUpdCol = false;
            this.xEditGridCell332.IsVisible = false;
            this.xEditGridCell332.Row = -1;
            this.xEditGridCell332.SuppressRepeating = true;
            // 
            // xEditGridCell157
            // 
            this.xEditGridCell157.CellName = "ho_dong_name";
            this.xEditGridCell157.CellWidth = 70;
            this.xEditGridCell157.Col = 6;
            this.xEditGridCell157.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell157, "xEditGridCell157");
            this.xEditGridCell157.IsReadOnly = true;
            this.xEditGridCell157.IsUpdCol = false;
            // 
            // xEditGridCell173
            // 
            this.xEditGridCell173.CellName = "ho_code";
            this.xEditGridCell173.CellWidth = 71;
            this.xEditGridCell173.Col = 7;
            this.xEditGridCell173.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell173, "xEditGridCell173");
            this.xEditGridCell173.IsReadOnly = true;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "juninp_yn";
            this.xEditGridCell59.CellWidth = 28;
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsReadOnly = true;
            this.xEditGridCell59.IsUpdatable = false;
            this.xEditGridCell59.IsUpdCol = false;
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "hope_date";
            this.xEditGridCell83.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell83.Col = 4;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsReadOnly = true;
            this.xEditGridCell83.SuppressRepeating = true;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "hope_time";
            this.xEditGridCell87.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell87.CellWidth = 35;
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsReadOnly = true;
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Mask = "HH:MI";
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell409
            // 
            this.xEditGridCell409.CellName = "fkinp1001";
            this.xEditGridCell409.Col = -1;
            this.xEditGridCell409.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell409, "xEditGridCell409");
            this.xEditGridCell409.IsReadOnly = true;
            this.xEditGridCell409.IsUpdatable = false;
            this.xEditGridCell409.IsUpdCol = false;
            this.xEditGridCell409.IsVisible = false;
            this.xEditGridCell409.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "toiwon_yn";
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell410
            // 
            this.xEditGridCell410.CellName = "gwa";
            this.xEditGridCell410.Col = -1;
            this.xEditGridCell410.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell410, "xEditGridCell410");
            this.xEditGridCell410.IsReadOnly = true;
            this.xEditGridCell410.IsVisible = false;
            this.xEditGridCell410.Row = -1;
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellName = "order_date";
            this.xEditGridCell148.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell148.Col = 3;
            this.xEditGridCell148.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell148, "xEditGridCell148");
            this.xEditGridCell148.IsReadOnly = true;
            this.xEditGridCell148.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "emergency";
            this.xEditGridCell149.Col = -1;
            this.xEditGridCell149.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell149, "xEditGridCell149");
            this.xEditGridCell149.IsReadOnly = true;
            this.xEditGridCell149.IsVisible = false;
            this.xEditGridCell149.Row = -1;
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.AlterateRowForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell155.CellName = "magam_gubun";
            this.xEditGridCell155.CellWidth = 30;
            this.xEditGridCell155.Col = 2;
            this.xEditGridCell155.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem11,
            this.xComboItem12,
            this.xComboItem13,
            this.xComboItem16,
            this.xComboItem14});
            this.xEditGridCell155.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell155.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell155, "xEditGridCell155");
            this.xEditGridCell155.IsReadOnly = true;
            this.xEditGridCell155.RowForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell155.SelectedForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell155.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem11
            // 
            resources.ApplyResources(this.xComboItem11, "xComboItem11");
            this.xComboItem11.ValueItem = "21";
            // 
            // xComboItem12
            // 
            resources.ApplyResources(this.xComboItem12, "xComboItem12");
            this.xComboItem12.ValueItem = "22";
            // 
            // xComboItem13
            // 
            resources.ApplyResources(this.xComboItem13, "xComboItem13");
            this.xComboItem13.ValueItem = "31";
            // 
            // xComboItem16
            // 
            resources.ApplyResources(this.xComboItem16, "xComboItem16");
            this.xComboItem16.ValueItem = "32";
            // 
            // xComboItem14
            // 
            resources.ApplyResources(this.xComboItem14, "xComboItem14");
            this.xComboItem14.ValueItem = "ER";
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.CellName = "jusa_yn";
            this.xEditGridCell156.Col = -1;
            this.xEditGridCell156.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell156, "xEditGridCell156");
            this.xEditGridCell156.IsReadOnly = true;
            this.xEditGridCell156.IsVisible = false;
            this.xEditGridCell156.Row = -1;
            // 
            // xEditGridCell428
            // 
            this.xEditGridCell428.CellName = "act_buseo";
            this.xEditGridCell428.Col = -1;
            this.xEditGridCell428.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell428, "xEditGridCell428");
            this.xEditGridCell428.IsVisible = false;
            this.xEditGridCell428.Row = -1;
            // 
            // xEditGridCell164
            // 
            this.xEditGridCell164.CellName = "jubsu_date";
            this.xEditGridCell164.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell164.Col = 5;
            this.xEditGridCell164.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell164.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell164, "xEditGridCell164");
            this.xEditGridCell164.IsReadOnly = true;
            // 
            // xPanel5
            // 
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.Controls.Add(this.cbxJusaLabelYN);
            this.xPanel5.Controls.Add(this.cbxATCYN);
            this.xPanel5.Controls.Add(this.btnUseAlarmChk);
            this.xPanel5.Controls.Add(this.btnUseTimeChk);
            this.xPanel5.Controls.Add(this.btnUnCheckAll);
            this.xPanel5.Controls.Add(this.btnCheckAll);
            this.xPanel5.Controls.Add(this.btnPrint);
            this.xPanel5.Controls.Add(this.btnMagamStarts);
            this.xPanel5.Controls.Add(this.xButtonList2);
            this.xPanel5.Controls.Add(this.btnMagamStops);
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Name = "xPanel5";
            // 
            // cbxJusaLabelYN
            // 
            resources.ApplyResources(this.cbxJusaLabelYN, "cbxJusaLabelYN");
            this.cbxJusaLabelYN.CheckedText = global::IHIS.DRGS.Properties.Resources.cbxJusaLabelY;
            this.cbxJusaLabelYN.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.cbxJusaLabelYN.Name = "cbxJusaLabelYN";
            this.cbxJusaLabelYN.TabStop = false;
            this.cbxJusaLabelYN.UnCheckedText = global::IHIS.DRGS.Properties.Resources.cbxJusaLabelN;
            this.cbxJusaLabelYN.UseVisualStyleBackColor = false;
            // 
            // cbxATCYN
            // 
            resources.ApplyResources(this.cbxATCYN, "cbxATCYN");
            this.cbxATCYN.CheckedText = global::IHIS.DRGS.Properties.Resources.cbxATCY;
            this.cbxATCYN.Name = "cbxATCYN";
            this.cbxATCYN.TabStop = false;
            this.cbxATCYN.UnCheckedText = global::IHIS.DRGS.Properties.Resources.cbxATCN;
            this.cbxATCYN.UseVisualStyleBackColor = false;
            // 
            // btnUseAlarmChk
            // 
            resources.ApplyResources(this.btnUseAlarmChk, "btnUseAlarmChk");
            this.btnUseAlarmChk.ImageIndex = 1;
            this.btnUseAlarmChk.ImageList = this.ImageList;
            this.btnUseAlarmChk.Name = "btnUseAlarmChk";
            this.btnUseAlarmChk.Click += new System.EventHandler(this.btnUseAlarmChk_Click);
            // 
            // btnUseTimeChk
            // 
            resources.ApplyResources(this.btnUseTimeChk, "btnUseTimeChk");
            this.btnUseTimeChk.ImageIndex = 0;
            this.btnUseTimeChk.ImageList = this.ImageList;
            this.btnUseTimeChk.Name = "btnUseTimeChk";
            this.btnUseTimeChk.Click += new System.EventHandler(this.btnUseTimeChk_Click);
            // 
            // btnUnCheckAll
            // 
            resources.ApplyResources(this.btnUnCheckAll, "btnUnCheckAll");
            this.btnUnCheckAll.Image = ((System.Drawing.Image)(resources.GetObject("btnUnCheckAll.Image")));
            this.btnUnCheckAll.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUnCheckAll.Name = "btnUnCheckAll";
            this.btnUnCheckAll.Click += new System.EventHandler(this.btnUnCheckAll_Click);
            // 
            // btnCheckAll
            // 
            resources.ApplyResources(this.btnCheckAll, "btnCheckAll");
            this.btnCheckAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckAll.Image")));
            this.btnCheckAll.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.ImageIndex = 9;
            this.btnPrint.ImageList = this.ImageList;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // xButtonList2
            // 
            resources.ApplyResources(this.xButtonList2, "xButtonList2");
            this.xButtonList2.IsVisiblePreview = false;
            this.xButtonList2.IsVisibleReset = false;
            this.xButtonList2.Name = "xButtonList2";
            this.xButtonList2.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList2.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.pnlMagam);
            this.tabPage1.ImageIndex = 13;
            this.tabPage1.ImageList = this.ImageList;
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            // 
            // pnlMagam
            // 
            resources.ApplyResources(this.pnlMagam, "pnlMagam");
            this.pnlMagam.Controls.Add(this.xPanel4);
            this.pnlMagam.Controls.Add(this.xPanel7);
            this.pnlMagam.Controls.Add(this.xPanel3);
            this.pnlMagam.Name = "pnlMagam";
            // 
            // xPanel4
            // 
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Controls.Add(this.grdMagamOrder);
            this.xPanel4.Controls.Add(this.grdMagamJUSAOrder);
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Name = "xPanel4";
            // 
            // grdMagamOrder
            // 
            this.grdMagamOrder.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdMagamOrder, "grdMagamOrder");
            this.grdMagamOrder.ApplyPaintEventToAllColumn = true;
            this.grdMagamOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell27,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
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
            this.xEditGridCell123,
            this.xEditGridCell126,
            this.xEditGridCell127,
            this.xEditGridCell129,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell152,
            this.xEditGridCell427,
            this.xEditGridCell430});
            this.grdMagamOrder.ColPerLine = 14;
            this.grdMagamOrder.Cols = 15;
            this.grdMagamOrder.ControlBinding = true;
            this.grdMagamOrder.ExecuteQuery = null;
            this.grdMagamOrder.FixedCols = 1;
            this.grdMagamOrder.FixedRows = 2;
            this.grdMagamOrder.HeaderHeights.Add(40);
            this.grdMagamOrder.HeaderHeights.Add(0);
            this.grdMagamOrder.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader7});
            this.grdMagamOrder.Name = "grdMagamOrder";
            this.grdMagamOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMagamOrder.ParamList")));
            this.grdMagamOrder.QuerySQL = resources.GetString("grdMagamOrder.QuerySQL");
            this.grdMagamOrder.RowHeaderVisible = true;
            this.grdMagamOrder.Rows = 3;
            this.grdMagamOrder.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdMagamOrder.TabStop = false;
            this.grdMagamOrder.ToolTipActive = true;
            this.grdMagamOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdMagamOrder_GridCellPainting);
            this.grdMagamOrder.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdPackPowder_GridColumnChanged);
            this.grdMagamOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMagamOrder_QueryStarting);
            this.grdMagamOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdMagamOrder_QueryEnd);
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "order_date";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell27.CellWidth = 77;
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "group_ser";
            this.xEditGridCell32.CellWidth = 28;
            this.xEditGridCell32.Col = 3;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdCol = false;
            this.xEditGridCell32.SuppressRepeating = true;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "jaeryo_code";
            this.xEditGridCell33.CellWidth = 77;
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "jaeryo_name";
            this.xEditGridCell34.CellWidth = 200;
            this.xEditGridCell34.Col = 4;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsUpdCol = false;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "ord_suryang";
            this.xEditGridCell35.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell35.CellWidth = 35;
            this.xEditGridCell35.Col = 5;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.IsUpdCol = false;
            this.xEditGridCell35.RowSpan = 2;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "dv_time";
            this.xEditGridCell36.CellWidth = 22;
            this.xEditGridCell36.Col = 6;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsUpdCol = false;
            this.xEditGridCell36.Row = 1;
            this.xEditGridCell36.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "dv";
            this.xEditGridCell40.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell40.CellWidth = 22;
            this.xEditGridCell40.Col = 7;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsUpdCol = false;
            this.xEditGridCell40.Row = 1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "nalsu";
            this.xEditGridCell41.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell41.CellWidth = 22;
            this.xEditGridCell41.Col = 8;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsUpdCol = false;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "order_danui";
            this.xEditGridCell42.CellWidth = 77;
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsReadOnly = true;
            this.xEditGridCell42.IsUpdCol = false;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "danui_name";
            this.xEditGridCell43.CellWidth = 45;
            this.xEditGridCell43.Col = 9;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsReadOnly = true;
            this.xEditGridCell43.IsUpdCol = false;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "bogyong_code";
            this.xEditGridCell44.CellWidth = 77;
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsReadOnly = true;
            this.xEditGridCell44.IsUpdCol = false;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "bogyong_name";
            this.xEditGridCell45.CellWidth = 90;
            this.xEditGridCell45.Col = 10;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsReadOnly = true;
            this.xEditGridCell45.IsUpdCol = false;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "powder_yn";
            this.xEditGridCell46.CellWidth = 25;
            this.xEditGridCell46.Col = 12;
            this.xEditGridCell46.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellLen = 100;
            this.xEditGridCell47.CellName = "remark";
            this.xEditGridCell47.CellWidth = 43;
            this.xEditGridCell47.Col = 14;
            this.xEditGridCell47.DisplayMemoText = true;
            this.xEditGridCell47.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsReadOnly = true;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "dv_1";
            this.xEditGridCell48.CellWidth = 77;
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsReadOnly = true;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "dv_2";
            this.xEditGridCell49.CellWidth = 77;
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsReadOnly = true;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "dv_3";
            this.xEditGridCell50.CellWidth = 77;
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsReadOnly = true;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "dv_4";
            this.xEditGridCell51.CellWidth = 77;
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsReadOnly = true;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "dv_5";
            this.xEditGridCell52.CellWidth = 77;
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsReadOnly = true;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "hubal_change_yn";
            this.xEditGridCell53.CellWidth = 22;
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsReadOnly = true;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            this.xEditGridCell53.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "pharmacy";
            this.xEditGridCell54.CellWidth = 30;
            this.xEditGridCell54.Col = 13;
            this.xEditGridCell54.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsReadOnly = true;
            this.xEditGridCell54.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "drg_pack_yn";
            this.xEditGridCell55.CellWidth = 22;
            this.xEditGridCell55.Col = 11;
            this.xEditGridCell55.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "jusa";
            this.xEditGridCell56.CellWidth = 77;
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsReadOnly = true;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            this.xEditGridCell56.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellName = "suname";
            this.xEditGridCell123.Col = 2;
            this.xEditGridCell123.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell123, "xEditGridCell123");
            this.xEditGridCell123.IsReadOnly = true;
            this.xEditGridCell123.SuppressRepeating = true;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell126.CellName = "drg_bunho";
            this.xEditGridCell126.CellWidth = 40;
            this.xEditGridCell126.Col = 1;
            this.xEditGridCell126.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell126, "xEditGridCell126");
            this.xEditGridCell126.IsReadOnly = true;
            this.xEditGridCell126.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell126.SuppressRepeating = true;
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "jubsu_date";
            this.xEditGridCell127.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell127.CellWidth = 77;
            this.xEditGridCell127.Col = -1;
            this.xEditGridCell127.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell127, "xEditGridCell127");
            this.xEditGridCell127.IsVisible = false;
            this.xEditGridCell127.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "bunho";
            this.xEditGridCell129.CellWidth = 77;
            this.xEditGridCell129.Col = -1;
            this.xEditGridCell129.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell129, "xEditGridCell129");
            this.xEditGridCell129.IsVisible = false;
            this.xEditGridCell129.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "bannab_yn";
            this.xEditGridCell15.CellWidth = 77;
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "source_fkocs2003";
            this.xEditGridCell16.CellWidth = 77;
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "fkocs2003";
            this.xEditGridCell17.CellWidth = 77;
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "hope_date";
            this.xEditGridCell23.CellWidth = 77;
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "dc_yn";
            this.xEditGridCell24.CellWidth = 77;
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "order_gubun";
            this.xEditGridCell25.CellWidth = 77;
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "mix_group";
            this.xEditGridCell26.CellWidth = 77;
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell152
            // 
            this.xEditGridCell152.CellName = "re_use_yn";
            this.xEditGridCell152.Col = -1;
            this.xEditGridCell152.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell152, "xEditGridCell152");
            this.xEditGridCell152.IsVisible = false;
            this.xEditGridCell152.Row = -1;
            // 
            // xEditGridCell427
            // 
            this.xEditGridCell427.CellName = "brought_drg_yn";
            this.xEditGridCell427.Col = -1;
            this.xEditGridCell427.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell427, "xEditGridCell427");
            this.xEditGridCell427.IsReadOnly = true;
            this.xEditGridCell427.IsVisible = false;
            this.xEditGridCell427.Row = -1;
            // 
            // xEditGridCell430
            // 
            this.xEditGridCell430.CellName = "emergency";
            this.xEditGridCell430.Col = -1;
            this.xEditGridCell430.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell430, "xEditGridCell430");
            this.xEditGridCell430.IsVisible = false;
            this.xEditGridCell430.Row = -1;
            // 
            // xGridHeader7
            // 
            this.xGridHeader7.Col = 6;
            this.xGridHeader7.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader7, "xGridHeader7");
            this.xGridHeader7.HeaderWidth = 22;
            // 
            // grdMagamJUSAOrder
            // 
            resources.ApplyResources(this.grdMagamJUSAOrder, "grdMagamJUSAOrder");
            this.grdMagamJUSAOrder.ApplyPaintEventToAllColumn = true;
            this.grdMagamJUSAOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell57,
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
            this.xEditGridCell124,
            this.xEditGridCell125,
            this.xEditGridCell128,
            this.xEditGridCell130,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell18,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell435,
            this.xEditGridCell436});
            this.grdMagamJUSAOrder.ColPerLine = 12;
            this.grdMagamJUSAOrder.Cols = 13;
            this.grdMagamJUSAOrder.ControlBinding = true;
            this.grdMagamJUSAOrder.ExecuteQuery = null;
            this.grdMagamJUSAOrder.FixedCols = 1;
            this.grdMagamJUSAOrder.FixedRows = 1;
            this.grdMagamJUSAOrder.HeaderHeights.Add(41);
            this.grdMagamJUSAOrder.Name = "grdMagamJUSAOrder";
            this.grdMagamJUSAOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMagamJUSAOrder.ParamList")));
            this.grdMagamJUSAOrder.QuerySQL = resources.GetString("grdMagamJUSAOrder.QuerySQL");
            this.grdMagamJUSAOrder.RowHeaderVisible = true;
            this.grdMagamJUSAOrder.Rows = 2;
            this.grdMagamJUSAOrder.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdMagamJUSAOrder.TabStop = false;
            this.grdMagamJUSAOrder.ToolTipActive = true;
            this.grdMagamJUSAOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdMagamJUSAOrder_GridCellPainting);
            this.grdMagamJUSAOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMagamJUSAOrder_QueryStarting);
            this.grdMagamJUSAOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdMagamOrder_QueryEnd);
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "order_date";
            this.xEditGridCell57.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell57.CellWidth = 77;
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsReadOnly = true;
            this.xEditGridCell57.IsUpdCol = false;
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            this.xEditGridCell57.SuppressRepeating = true;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "group_ser";
            this.xEditGridCell101.CellWidth = 28;
            this.xEditGridCell101.Col = 3;
            this.xEditGridCell101.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsReadOnly = true;
            this.xEditGridCell101.IsUpdCol = false;
            this.xEditGridCell101.SuppressRepeating = true;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "jaeryo_code";
            this.xEditGridCell102.CellWidth = 77;
            this.xEditGridCell102.Col = -1;
            this.xEditGridCell102.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell102, "xEditGridCell102");
            this.xEditGridCell102.IsReadOnly = true;
            this.xEditGridCell102.IsUpdCol = false;
            this.xEditGridCell102.IsVisible = false;
            this.xEditGridCell102.Row = -1;
            this.xEditGridCell102.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "jaeryo_name";
            this.xEditGridCell103.CellWidth = 213;
            this.xEditGridCell103.Col = 4;
            this.xEditGridCell103.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.IsReadOnly = true;
            this.xEditGridCell103.IsUpdCol = false;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "ord_suryang";
            this.xEditGridCell104.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell104.CellWidth = 35;
            this.xEditGridCell104.Col = 6;
            this.xEditGridCell104.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
            this.xEditGridCell104.IsReadOnly = true;
            this.xEditGridCell104.IsUpdCol = false;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "dv_time";
            this.xEditGridCell105.CellWidth = 77;
            this.xEditGridCell105.Col = -1;
            this.xEditGridCell105.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell105, "xEditGridCell105");
            this.xEditGridCell105.IsReadOnly = true;
            this.xEditGridCell105.IsUpdCol = false;
            this.xEditGridCell105.IsVisible = false;
            this.xEditGridCell105.Row = -1;
            this.xEditGridCell105.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "dv";
            this.xEditGridCell106.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell106.CellWidth = 22;
            this.xEditGridCell106.Col = 7;
            this.xEditGridCell106.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            this.xEditGridCell106.IsReadOnly = true;
            this.xEditGridCell106.IsUpdCol = false;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "nalsu";
            this.xEditGridCell107.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell107.CellWidth = 22;
            this.xEditGridCell107.Col = 8;
            this.xEditGridCell107.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell107, "xEditGridCell107");
            this.xEditGridCell107.IsReadOnly = true;
            this.xEditGridCell107.IsUpdCol = false;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "order_danui";
            this.xEditGridCell108.CellWidth = 77;
            this.xEditGridCell108.Col = -1;
            this.xEditGridCell108.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell108, "xEditGridCell108");
            this.xEditGridCell108.IsReadOnly = true;
            this.xEditGridCell108.IsUpdCol = false;
            this.xEditGridCell108.IsVisible = false;
            this.xEditGridCell108.Row = -1;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "danui_name";
            this.xEditGridCell109.CellWidth = 49;
            this.xEditGridCell109.Col = 9;
            this.xEditGridCell109.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell109, "xEditGridCell109");
            this.xEditGridCell109.IsReadOnly = true;
            this.xEditGridCell109.IsUpdCol = false;
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "bogyong_code";
            this.xEditGridCell110.CellWidth = 77;
            this.xEditGridCell110.Col = -1;
            this.xEditGridCell110.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell110, "xEditGridCell110");
            this.xEditGridCell110.IsReadOnly = true;
            this.xEditGridCell110.IsUpdCol = false;
            this.xEditGridCell110.IsVisible = false;
            this.xEditGridCell110.Row = -1;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "bogyong_name";
            this.xEditGridCell111.CellWidth = 60;
            this.xEditGridCell111.Col = 10;
            this.xEditGridCell111.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell111, "xEditGridCell111");
            this.xEditGridCell111.IsReadOnly = true;
            this.xEditGridCell111.IsUpdCol = false;
            this.xEditGridCell111.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "powder_yn";
            this.xEditGridCell112.CellWidth = 77;
            this.xEditGridCell112.Col = -1;
            this.xEditGridCell112.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell112, "xEditGridCell112");
            this.xEditGridCell112.IsReadOnly = true;
            this.xEditGridCell112.IsVisible = false;
            this.xEditGridCell112.Row = -1;
            this.xEditGridCell112.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellLen = 100;
            this.xEditGridCell113.CellName = "remark";
            this.xEditGridCell113.CellWidth = 45;
            this.xEditGridCell113.Col = 12;
            this.xEditGridCell113.DisplayMemoText = true;
            this.xEditGridCell113.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell113.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell113, "xEditGridCell113");
            this.xEditGridCell113.IsReadOnly = true;
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "dv_1";
            this.xEditGridCell114.CellWidth = 77;
            this.xEditGridCell114.Col = -1;
            this.xEditGridCell114.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell114, "xEditGridCell114");
            this.xEditGridCell114.IsReadOnly = true;
            this.xEditGridCell114.IsVisible = false;
            this.xEditGridCell114.Row = -1;
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "dv_2";
            this.xEditGridCell115.CellWidth = 77;
            this.xEditGridCell115.Col = -1;
            this.xEditGridCell115.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell115, "xEditGridCell115");
            this.xEditGridCell115.IsReadOnly = true;
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "dv_3";
            this.xEditGridCell116.CellWidth = 77;
            this.xEditGridCell116.Col = -1;
            this.xEditGridCell116.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell116, "xEditGridCell116");
            this.xEditGridCell116.IsReadOnly = true;
            this.xEditGridCell116.IsVisible = false;
            this.xEditGridCell116.Row = -1;
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "dv_4";
            this.xEditGridCell117.CellWidth = 77;
            this.xEditGridCell117.Col = -1;
            this.xEditGridCell117.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell117, "xEditGridCell117");
            this.xEditGridCell117.IsReadOnly = true;
            this.xEditGridCell117.IsVisible = false;
            this.xEditGridCell117.Row = -1;
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellName = "dv_5";
            this.xEditGridCell118.CellWidth = 77;
            this.xEditGridCell118.Col = -1;
            this.xEditGridCell118.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell118, "xEditGridCell118");
            this.xEditGridCell118.IsReadOnly = true;
            this.xEditGridCell118.IsVisible = false;
            this.xEditGridCell118.Row = -1;
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "hubal_change_yn";
            this.xEditGridCell119.CellWidth = 25;
            this.xEditGridCell119.Col = 11;
            this.xEditGridCell119.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell119.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell119, "xEditGridCell119");
            this.xEditGridCell119.IsReadOnly = true;
            this.xEditGridCell119.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "pharmacy";
            this.xEditGridCell120.CellWidth = 77;
            this.xEditGridCell120.Col = -1;
            this.xEditGridCell120.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell120, "xEditGridCell120");
            this.xEditGridCell120.IsReadOnly = true;
            this.xEditGridCell120.IsVisible = false;
            this.xEditGridCell120.Row = -1;
            this.xEditGridCell120.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellName = "drg_pack_yn";
            this.xEditGridCell121.CellWidth = 77;
            this.xEditGridCell121.Col = -1;
            this.xEditGridCell121.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell121, "xEditGridCell121");
            this.xEditGridCell121.IsReadOnly = true;
            this.xEditGridCell121.IsVisible = false;
            this.xEditGridCell121.Row = -1;
            this.xEditGridCell121.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellName = "jusa";
            this.xEditGridCell122.Col = 5;
            this.xEditGridCell122.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell122, "xEditGridCell122");
            this.xEditGridCell122.IsReadOnly = true;
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "suname";
            this.xEditGridCell124.CellWidth = 85;
            this.xEditGridCell124.Col = 2;
            this.xEditGridCell124.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell124, "xEditGridCell124");
            this.xEditGridCell124.IsReadOnly = true;
            this.xEditGridCell124.SuppressRepeating = true;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell125.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell125.CellName = "drg_bunho";
            this.xEditGridCell125.CellWidth = 40;
            this.xEditGridCell125.Col = 1;
            this.xEditGridCell125.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell125, "xEditGridCell125");
            this.xEditGridCell125.IsReadOnly = true;
            this.xEditGridCell125.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell125.SuppressRepeating = true;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "jubsu_date";
            this.xEditGridCell128.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell128.CellWidth = 77;
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell128, "xEditGridCell128");
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.CellName = "bunho";
            this.xEditGridCell130.CellWidth = 77;
            this.xEditGridCell130.Col = -1;
            this.xEditGridCell130.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell130, "xEditGridCell130");
            this.xEditGridCell130.IsVisible = false;
            this.xEditGridCell130.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "bannab_yn";
            this.xEditGridCell12.CellWidth = 77;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "source_fkocs2003";
            this.xEditGridCell13.CellWidth = 77;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "fkocs2003";
            this.xEditGridCell14.CellWidth = 77;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "hope_date";
            this.xEditGridCell18.CellWidth = 77;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "dc_yn";
            this.xEditGridCell20.CellWidth = 77;
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "order_gubun";
            this.xEditGridCell21.CellWidth = 77;
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "mix_group";
            this.xEditGridCell22.CellWidth = 77;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell435
            // 
            this.xEditGridCell435.CellName = "brought_drg_yn";
            this.xEditGridCell435.Col = -1;
            this.xEditGridCell435.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell435, "xEditGridCell435");
            this.xEditGridCell435.IsVisible = false;
            this.xEditGridCell435.Row = -1;
            // 
            // xEditGridCell436
            // 
            this.xEditGridCell436.CellName = "emergency";
            this.xEditGridCell436.Col = -1;
            this.xEditGridCell436.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell436, "xEditGridCell436");
            this.xEditGridCell436.IsVisible = false;
            this.xEditGridCell436.Row = -1;
            // 
            // xPanel7
            // 
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.Controls.Add(this.grdList);
            this.xPanel7.DrawBorder = true;
            this.xPanel7.Name = "xPanel7";
            // 
            // grdList
            // 
            resources.ApplyResources(this.grdList, "grdList");
            this.grdList.ApplyPaintEventToAllColumn = true;
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell8,
            this.xEditGridCell425,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell158,
            this.xEditGridCell159,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell160,
            this.xEditGridCell161,
            this.xEditGridCell153,
            this.xEditGridCell424,
            this.xEditGridCell5,
            this.xEditGridCell7,
            this.xEditGridCell6,
            this.xEditGridCell166,
            this.xEditGridCell4,
            this.xEditGridCell11,
            this.xEditGridCell151});
            this.grdList.ColPerLine = 13;
            this.grdList.Cols = 14;
            this.grdList.ExecuteQuery = null;
            this.grdList.FixedCols = 1;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(40);
            this.grdList.Name = "grdList";
            this.grdList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdList.ParamList")));
            this.grdList.QuerySQL = resources.GetString("grdList.QuerySQL");
            this.grdList.RowHeaderVisible = true;
            this.grdList.Rows = 2;
            this.grdList.TabStop = false;
            this.grdList.ToolTipActive = true;
            this.grdList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdList_RowFocusChanged);
            this.grdList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdList_GridCellPainting);
            this.grdList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "jubsu_date";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.CellWidth = 78;
            this.xEditGridCell8.Col = 5;
            this.xEditGridCell8.EnableSort = true;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell425
            // 
            this.xEditGridCell425.CellName = "jubsu_time";
            this.xEditGridCell425.Col = -1;
            this.xEditGridCell425.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell425, "xEditGridCell425");
            this.xEditGridCell425.IsReadOnly = true;
            this.xEditGridCell425.IsVisible = false;
            this.xEditGridCell425.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell1.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.CellName = "drg_bunho";
            this.xEditGridCell1.CellWidth = 40;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.CellWidth = 70;
            this.xEditGridCell2.Col = 8;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
            this.xEditGridCell2.SuppressRepeating = true;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 50;
            this.xEditGridCell3.CellName = "suname";
            this.xEditGridCell3.CellWidth = 83;
            this.xEditGridCell3.Col = 9;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.SuppressRepeating = true;
            // 
            // xEditGridCell158
            // 
            this.xEditGridCell158.CellName = "sex";
            this.xEditGridCell158.CellWidth = 30;
            this.xEditGridCell158.Col = 11;
            this.xEditGridCell158.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell158, "xEditGridCell158");
            this.xEditGridCell158.IsReadOnly = true;
            // 
            // xEditGridCell159
            // 
            this.xEditGridCell159.CellName = "age";
            this.xEditGridCell159.CellWidth = 28;
            this.xEditGridCell159.Col = 12;
            this.xEditGridCell159.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell159, "xEditGridCell159");
            this.xEditGridCell159.IsReadOnly = true;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "doctor";
            this.xEditGridCell9.CellWidth = 40;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 50;
            this.xEditGridCell10.CellName = "doctor_name";
            this.xEditGridCell10.Col = 10;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            // 
            // xEditGridCell160
            // 
            this.xEditGridCell160.CellName = "ho_dong";
            this.xEditGridCell160.Col = -1;
            this.xEditGridCell160.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell160, "xEditGridCell160");
            this.xEditGridCell160.IsReadOnly = true;
            this.xEditGridCell160.IsVisible = false;
            this.xEditGridCell160.Row = -1;
            // 
            // xEditGridCell161
            // 
            this.xEditGridCell161.CellName = "ho_dong_name";
            this.xEditGridCell161.CellWidth = 42;
            this.xEditGridCell161.Col = 6;
            this.xEditGridCell161.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell161, "xEditGridCell161");
            this.xEditGridCell161.IsReadOnly = true;
            // 
            // xEditGridCell153
            // 
            this.xEditGridCell153.CellName = "ho_code";
            this.xEditGridCell153.CellWidth = 32;
            this.xEditGridCell153.Col = 7;
            this.xEditGridCell153.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell153, "xEditGridCell153");
            this.xEditGridCell153.IsReadOnly = true;
            // 
            // xEditGridCell424
            // 
            this.xEditGridCell424.CellName = "fkinp1001";
            this.xEditGridCell424.Col = -1;
            this.xEditGridCell424.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell424, "xEditGridCell424");
            this.xEditGridCell424.IsReadOnly = true;
            this.xEditGridCell424.IsVisible = false;
            this.xEditGridCell424.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "toiwon_drg_yn";
            this.xEditGridCell5.CellWidth = 40;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.SuppressRepeating = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "gwa";
            this.xEditGridCell7.CellWidth = 40;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "order_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.CellWidth = 78;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.EnableSort = true;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            // 
            // xEditGridCell166
            // 
            this.xEditGridCell166.CellName = "hope_date";
            this.xEditGridCell166.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell166.Col = 4;
            this.xEditGridCell166.EnableSort = true;
            this.xEditGridCell166.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell166, "xEditGridCell166");
            this.xEditGridCell166.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell4.CellName = "magam_gubun";
            this.xEditGridCell4.CellWidth = 30;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem8,
            this.xComboItem7,
            this.xComboItem2,
            this.xComboItem6,
            this.xComboItem24,
            this.xComboItem25,
            this.xComboItem1});
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.RowForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell4.SelectedForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem8
            // 
            resources.ApplyResources(this.xComboItem8, "xComboItem8");
            this.xComboItem8.ValueItem = "21";
            // 
            // xComboItem7
            // 
            resources.ApplyResources(this.xComboItem7, "xComboItem7");
            this.xComboItem7.ValueItem = "22";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "31";
            // 
            // xComboItem6
            // 
            resources.ApplyResources(this.xComboItem6, "xComboItem6");
            this.xComboItem6.ValueItem = "32";
            // 
            // xComboItem24
            // 
            resources.ApplyResources(this.xComboItem24, "xComboItem24");
            this.xComboItem24.ValueItem = "P1";
            // 
            // xComboItem25
            // 
            resources.ApplyResources(this.xComboItem25, "xComboItem25");
            this.xComboItem25.ValueItem = "P2";
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "ER";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "jusa_yn";
            this.xEditGridCell11.CellWidth = 40;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell151
            // 
            this.xEditGridCell151.CellName = "mix_date";
            this.xEditGridCell151.Col = 13;
            this.xEditGridCell151.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell151, "xEditGridCell151");
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Controls.Add(this.xPanel9);
            this.tabPage3.ImageIndex = 14;
            this.tabPage3.ImageList = this.ImageList;
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            // 
            // xPanel9
            // 
            resources.ApplyResources(this.xPanel9, "xPanel9");
            this.xPanel9.Controls.Add(this.xPanel10);
            this.xPanel9.Controls.Add(this.xPanel11);
            this.xPanel9.Controls.Add(this.xPanel13);
            this.xPanel9.Name = "xPanel9";
            // 
            // xPanel10
            // 
            resources.ApplyResources(this.xPanel10, "xPanel10");
            this.xPanel10.Controls.Add(this.grdDcOrder);
            this.xPanel10.Controls.Add(this.grdJusaDcOrder);
            this.xPanel10.DrawBorder = true;
            this.xPanel10.Name = "xPanel10";
            // 
            // grdDcOrder
            // 
            this.grdDcOrder.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdDcOrder, "grdDcOrder");
            this.grdDcOrder.ApplyPaintEventToAllColumn = true;
            this.grdDcOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell167,
            this.xEditGridCell168,
            this.xEditGridCell169,
            this.xEditGridCell170,
            this.xEditGridCell171,
            this.xEditGridCell172,
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
            this.xEditGridCell431,
            this.xEditGridCell432});
            this.grdDcOrder.ColPerLine = 14;
            this.grdDcOrder.Cols = 15;
            this.grdDcOrder.ControlBinding = true;
            this.grdDcOrder.ExecuteQuery = null;
            this.grdDcOrder.FixedCols = 1;
            this.grdDcOrder.FixedRows = 2;
            this.grdDcOrder.HeaderHeights.Add(40);
            this.grdDcOrder.HeaderHeights.Add(0);
            this.grdDcOrder.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader8});
            this.grdDcOrder.Name = "grdDcOrder";
            this.grdDcOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDcOrder.ParamList")));
            this.grdDcOrder.QuerySQL = resources.GetString("grdDcOrder.QuerySQL");
            this.grdDcOrder.RowHeaderVisible = true;
            this.grdDcOrder.Rows = 3;
            this.grdDcOrder.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdDcOrder.TabStop = false;
            this.grdDcOrder.ToolTipActive = true;
            this.grdDcOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdDcOrder_GridCellPainting);
            this.grdDcOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDcOrder_QueryStarting);
            this.grdDcOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdMagamOrder_QueryEnd);
            // 
            // xEditGridCell167
            // 
            this.xEditGridCell167.CellName = "order_date";
            this.xEditGridCell167.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell167.CellWidth = 77;
            this.xEditGridCell167.Col = -1;
            this.xEditGridCell167.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell167, "xEditGridCell167");
            this.xEditGridCell167.IsReadOnly = true;
            this.xEditGridCell167.IsUpdCol = false;
            this.xEditGridCell167.IsVisible = false;
            this.xEditGridCell167.Row = -1;
            // 
            // xEditGridCell168
            // 
            this.xEditGridCell168.CellName = "group_ser";
            this.xEditGridCell168.CellWidth = 28;
            this.xEditGridCell168.Col = 3;
            this.xEditGridCell168.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell168, "xEditGridCell168");
            this.xEditGridCell168.IsReadOnly = true;
            this.xEditGridCell168.IsUpdCol = false;
            this.xEditGridCell168.SuppressRepeating = true;
            // 
            // xEditGridCell169
            // 
            this.xEditGridCell169.CellName = "jaeryo_code";
            this.xEditGridCell169.CellWidth = 77;
            this.xEditGridCell169.Col = -1;
            this.xEditGridCell169.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell169, "xEditGridCell169");
            this.xEditGridCell169.IsReadOnly = true;
            this.xEditGridCell169.IsUpdCol = false;
            this.xEditGridCell169.IsVisible = false;
            this.xEditGridCell169.Row = -1;
            this.xEditGridCell169.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell170
            // 
            this.xEditGridCell170.CellName = "jaeryo_name";
            this.xEditGridCell170.CellWidth = 200;
            this.xEditGridCell170.Col = 4;
            this.xEditGridCell170.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell170, "xEditGridCell170");
            this.xEditGridCell170.IsReadOnly = true;
            this.xEditGridCell170.IsUpdCol = false;
            // 
            // xEditGridCell171
            // 
            this.xEditGridCell171.CellName = "ord_suryang";
            this.xEditGridCell171.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell171.CellWidth = 35;
            this.xEditGridCell171.Col = 5;
            this.xEditGridCell171.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell171, "xEditGridCell171");
            this.xEditGridCell171.IsReadOnly = true;
            this.xEditGridCell171.IsUpdCol = false;
            this.xEditGridCell171.RowSpan = 2;
            // 
            // xEditGridCell172
            // 
            this.xEditGridCell172.CellName = "dv_time";
            this.xEditGridCell172.CellWidth = 22;
            this.xEditGridCell172.Col = 6;
            this.xEditGridCell172.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell172, "xEditGridCell172");
            this.xEditGridCell172.IsReadOnly = true;
            this.xEditGridCell172.IsUpdCol = false;
            this.xEditGridCell172.Row = 1;
            this.xEditGridCell172.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell174
            // 
            this.xEditGridCell174.CellName = "dv";
            this.xEditGridCell174.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell174.CellWidth = 22;
            this.xEditGridCell174.Col = 7;
            this.xEditGridCell174.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell174, "xEditGridCell174");
            this.xEditGridCell174.IsReadOnly = true;
            this.xEditGridCell174.IsUpdCol = false;
            this.xEditGridCell174.Row = 1;
            // 
            // xEditGridCell175
            // 
            this.xEditGridCell175.CellName = "nalsu";
            this.xEditGridCell175.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell175.CellWidth = 22;
            this.xEditGridCell175.Col = 8;
            this.xEditGridCell175.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell175, "xEditGridCell175");
            this.xEditGridCell175.IsReadOnly = true;
            this.xEditGridCell175.IsUpdCol = false;
            // 
            // xEditGridCell176
            // 
            this.xEditGridCell176.CellName = "order_danui";
            this.xEditGridCell176.CellWidth = 77;
            this.xEditGridCell176.Col = -1;
            this.xEditGridCell176.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell176, "xEditGridCell176");
            this.xEditGridCell176.IsReadOnly = true;
            this.xEditGridCell176.IsUpdCol = false;
            this.xEditGridCell176.IsVisible = false;
            this.xEditGridCell176.Row = -1;
            // 
            // xEditGridCell177
            // 
            this.xEditGridCell177.CellName = "danui_name";
            this.xEditGridCell177.CellWidth = 45;
            this.xEditGridCell177.Col = 9;
            this.xEditGridCell177.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell177, "xEditGridCell177");
            this.xEditGridCell177.IsReadOnly = true;
            this.xEditGridCell177.IsUpdCol = false;
            // 
            // xEditGridCell178
            // 
            this.xEditGridCell178.CellName = "bogyong_code";
            this.xEditGridCell178.CellWidth = 77;
            this.xEditGridCell178.Col = -1;
            this.xEditGridCell178.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell178, "xEditGridCell178");
            this.xEditGridCell178.IsReadOnly = true;
            this.xEditGridCell178.IsUpdCol = false;
            this.xEditGridCell178.IsVisible = false;
            this.xEditGridCell178.Row = -1;
            // 
            // xEditGridCell179
            // 
            this.xEditGridCell179.CellName = "bogyong_name";
            this.xEditGridCell179.CellWidth = 90;
            this.xEditGridCell179.Col = 10;
            this.xEditGridCell179.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell179, "xEditGridCell179");
            this.xEditGridCell179.IsReadOnly = true;
            this.xEditGridCell179.IsUpdCol = false;
            // 
            // xEditGridCell180
            // 
            this.xEditGridCell180.CellName = "powder_yn";
            this.xEditGridCell180.CellWidth = 25;
            this.xEditGridCell180.Col = 12;
            this.xEditGridCell180.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell180.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell180, "xEditGridCell180");
            this.xEditGridCell180.IsReadOnly = true;
            this.xEditGridCell180.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell181
            // 
            this.xEditGridCell181.CellLen = 100;
            this.xEditGridCell181.CellName = "remark";
            this.xEditGridCell181.CellWidth = 43;
            this.xEditGridCell181.Col = 14;
            this.xEditGridCell181.DisplayMemoText = true;
            this.xEditGridCell181.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell181.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell181, "xEditGridCell181");
            this.xEditGridCell181.IsReadOnly = true;
            // 
            // xEditGridCell182
            // 
            this.xEditGridCell182.CellName = "dv_1";
            this.xEditGridCell182.CellWidth = 77;
            this.xEditGridCell182.Col = -1;
            this.xEditGridCell182.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell182, "xEditGridCell182");
            this.xEditGridCell182.IsReadOnly = true;
            this.xEditGridCell182.IsVisible = false;
            this.xEditGridCell182.Row = -1;
            // 
            // xEditGridCell183
            // 
            this.xEditGridCell183.CellName = "dv_2";
            this.xEditGridCell183.CellWidth = 77;
            this.xEditGridCell183.Col = -1;
            this.xEditGridCell183.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell183, "xEditGridCell183");
            this.xEditGridCell183.IsReadOnly = true;
            this.xEditGridCell183.IsVisible = false;
            this.xEditGridCell183.Row = -1;
            // 
            // xEditGridCell184
            // 
            this.xEditGridCell184.CellName = "dv_3";
            this.xEditGridCell184.CellWidth = 77;
            this.xEditGridCell184.Col = -1;
            this.xEditGridCell184.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell184, "xEditGridCell184");
            this.xEditGridCell184.IsReadOnly = true;
            this.xEditGridCell184.IsVisible = false;
            this.xEditGridCell184.Row = -1;
            // 
            // xEditGridCell185
            // 
            this.xEditGridCell185.CellName = "dv_4";
            this.xEditGridCell185.CellWidth = 77;
            this.xEditGridCell185.Col = -1;
            this.xEditGridCell185.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell185, "xEditGridCell185");
            this.xEditGridCell185.IsReadOnly = true;
            this.xEditGridCell185.IsVisible = false;
            this.xEditGridCell185.Row = -1;
            // 
            // xEditGridCell186
            // 
            this.xEditGridCell186.CellName = "dv_5";
            this.xEditGridCell186.CellWidth = 77;
            this.xEditGridCell186.Col = -1;
            this.xEditGridCell186.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell186, "xEditGridCell186");
            this.xEditGridCell186.IsReadOnly = true;
            this.xEditGridCell186.IsVisible = false;
            this.xEditGridCell186.Row = -1;
            // 
            // xEditGridCell187
            // 
            this.xEditGridCell187.CellName = "hubal_change_yn";
            this.xEditGridCell187.CellWidth = 22;
            this.xEditGridCell187.Col = -1;
            this.xEditGridCell187.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell187, "xEditGridCell187");
            this.xEditGridCell187.IsReadOnly = true;
            this.xEditGridCell187.IsVisible = false;
            this.xEditGridCell187.Row = -1;
            this.xEditGridCell187.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell188
            // 
            this.xEditGridCell188.CellName = "pharmacy";
            this.xEditGridCell188.CellWidth = 30;
            this.xEditGridCell188.Col = 13;
            this.xEditGridCell188.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell188.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell188, "xEditGridCell188");
            this.xEditGridCell188.IsReadOnly = true;
            this.xEditGridCell188.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell189
            // 
            this.xEditGridCell189.CellName = "drg_pack_yn";
            this.xEditGridCell189.CellWidth = 22;
            this.xEditGridCell189.Col = 11;
            this.xEditGridCell189.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell189.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell189, "xEditGridCell189");
            this.xEditGridCell189.IsReadOnly = true;
            this.xEditGridCell189.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell190
            // 
            this.xEditGridCell190.CellName = "jusa";
            this.xEditGridCell190.CellWidth = 77;
            this.xEditGridCell190.Col = -1;
            this.xEditGridCell190.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell190, "xEditGridCell190");
            this.xEditGridCell190.IsReadOnly = true;
            this.xEditGridCell190.IsVisible = false;
            this.xEditGridCell190.Row = -1;
            this.xEditGridCell190.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell191
            // 
            this.xEditGridCell191.CellName = "suname";
            this.xEditGridCell191.Col = 2;
            this.xEditGridCell191.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell191, "xEditGridCell191");
            this.xEditGridCell191.IsReadOnly = true;
            this.xEditGridCell191.SuppressRepeating = true;
            // 
            // xEditGridCell192
            // 
            this.xEditGridCell192.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell192.CellName = "drg_bunho";
            this.xEditGridCell192.CellWidth = 40;
            this.xEditGridCell192.Col = 1;
            this.xEditGridCell192.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell192, "xEditGridCell192");
            this.xEditGridCell192.IsReadOnly = true;
            this.xEditGridCell192.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell192.SuppressRepeating = true;
            // 
            // xEditGridCell193
            // 
            this.xEditGridCell193.CellName = "jubsu_date";
            this.xEditGridCell193.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell193.CellWidth = 77;
            this.xEditGridCell193.Col = -1;
            this.xEditGridCell193.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell193, "xEditGridCell193");
            this.xEditGridCell193.IsVisible = false;
            this.xEditGridCell193.Row = -1;
            // 
            // xEditGridCell194
            // 
            this.xEditGridCell194.CellName = "bunho";
            this.xEditGridCell194.CellWidth = 77;
            this.xEditGridCell194.Col = -1;
            this.xEditGridCell194.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell194, "xEditGridCell194");
            this.xEditGridCell194.IsVisible = false;
            this.xEditGridCell194.Row = -1;
            // 
            // xEditGridCell195
            // 
            this.xEditGridCell195.CellName = "bannab_yn";
            this.xEditGridCell195.CellWidth = 77;
            this.xEditGridCell195.Col = -1;
            this.xEditGridCell195.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell195, "xEditGridCell195");
            this.xEditGridCell195.IsVisible = false;
            this.xEditGridCell195.Row = -1;
            // 
            // xEditGridCell196
            // 
            this.xEditGridCell196.CellName = "source_fkocs2003";
            this.xEditGridCell196.CellWidth = 77;
            this.xEditGridCell196.Col = -1;
            this.xEditGridCell196.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell196, "xEditGridCell196");
            this.xEditGridCell196.IsVisible = false;
            this.xEditGridCell196.Row = -1;
            // 
            // xEditGridCell197
            // 
            this.xEditGridCell197.CellName = "fkocs2003";
            this.xEditGridCell197.CellWidth = 77;
            this.xEditGridCell197.Col = -1;
            this.xEditGridCell197.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell197, "xEditGridCell197");
            this.xEditGridCell197.IsVisible = false;
            this.xEditGridCell197.Row = -1;
            // 
            // xEditGridCell198
            // 
            this.xEditGridCell198.CellName = "hope_date";
            this.xEditGridCell198.CellWidth = 77;
            this.xEditGridCell198.Col = -1;
            this.xEditGridCell198.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell198, "xEditGridCell198");
            this.xEditGridCell198.IsVisible = false;
            this.xEditGridCell198.Row = -1;
            // 
            // xEditGridCell199
            // 
            this.xEditGridCell199.CellName = "dc_yn";
            this.xEditGridCell199.CellWidth = 77;
            this.xEditGridCell199.Col = -1;
            this.xEditGridCell199.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell199, "xEditGridCell199");
            this.xEditGridCell199.IsVisible = false;
            this.xEditGridCell199.Row = -1;
            // 
            // xEditGridCell200
            // 
            this.xEditGridCell200.CellName = "order_gubun";
            this.xEditGridCell200.CellWidth = 77;
            this.xEditGridCell200.Col = -1;
            this.xEditGridCell200.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell200, "xEditGridCell200");
            this.xEditGridCell200.IsVisible = false;
            this.xEditGridCell200.Row = -1;
            // 
            // xEditGridCell201
            // 
            this.xEditGridCell201.CellName = "mix_group";
            this.xEditGridCell201.CellWidth = 77;
            this.xEditGridCell201.Col = -1;
            this.xEditGridCell201.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell201, "xEditGridCell201");
            this.xEditGridCell201.IsVisible = false;
            this.xEditGridCell201.Row = -1;
            // 
            // xEditGridCell202
            // 
            this.xEditGridCell202.CellName = "re_use_yn";
            this.xEditGridCell202.Col = -1;
            this.xEditGridCell202.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell202, "xEditGridCell202");
            this.xEditGridCell202.IsVisible = false;
            this.xEditGridCell202.Row = -1;
            // 
            // xEditGridCell431
            // 
            this.xEditGridCell431.CellName = "brought_drg_yn";
            this.xEditGridCell431.Col = -1;
            this.xEditGridCell431.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell431, "xEditGridCell431");
            this.xEditGridCell431.IsVisible = false;
            this.xEditGridCell431.Row = -1;
            // 
            // xEditGridCell432
            // 
            this.xEditGridCell432.CellName = "emergency";
            this.xEditGridCell432.Col = -1;
            this.xEditGridCell432.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell432, "xEditGridCell432");
            this.xEditGridCell432.IsVisible = false;
            this.xEditGridCell432.Row = -1;
            // 
            // xGridHeader8
            // 
            this.xGridHeader8.Col = 6;
            this.xGridHeader8.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader8, "xGridHeader8");
            this.xGridHeader8.HeaderWidth = 22;
            // 
            // grdJusaDcOrder
            // 
            resources.ApplyResources(this.grdJusaDcOrder, "grdJusaDcOrder");
            this.grdJusaDcOrder.ApplyPaintEventToAllColumn = true;
            this.grdJusaDcOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell437,
            this.xEditGridCell438});
            this.grdJusaDcOrder.ColPerLine = 12;
            this.grdJusaDcOrder.Cols = 13;
            this.grdJusaDcOrder.ControlBinding = true;
            this.grdJusaDcOrder.ExecuteQuery = null;
            this.grdJusaDcOrder.FixedCols = 1;
            this.grdJusaDcOrder.FixedRows = 1;
            this.grdJusaDcOrder.HeaderHeights.Add(41);
            this.grdJusaDcOrder.Name = "grdJusaDcOrder";
            this.grdJusaDcOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdJusaDcOrder.ParamList")));
            this.grdJusaDcOrder.QuerySQL = resources.GetString("grdJusaDcOrder.QuerySQL");
            this.grdJusaDcOrder.RowHeaderVisible = true;
            this.grdJusaDcOrder.Rows = 2;
            this.grdJusaDcOrder.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdJusaDcOrder.TabStop = false;
            this.grdJusaDcOrder.ToolTipActive = true;
            this.grdJusaDcOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdJusaDcOrder_GridCellPainting);
            this.grdJusaDcOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdJusaDcOrder_QueryStarting);
            this.grdJusaDcOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdMagamOrder_QueryEnd);
            // 
            // xEditGridCell203
            // 
            this.xEditGridCell203.CellName = "order_date";
            this.xEditGridCell203.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell203.CellWidth = 77;
            this.xEditGridCell203.Col = -1;
            this.xEditGridCell203.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell203, "xEditGridCell203");
            this.xEditGridCell203.IsReadOnly = true;
            this.xEditGridCell203.IsUpdCol = false;
            this.xEditGridCell203.IsVisible = false;
            this.xEditGridCell203.Row = -1;
            this.xEditGridCell203.SuppressRepeating = true;
            // 
            // xEditGridCell204
            // 
            this.xEditGridCell204.CellName = "group_ser";
            this.xEditGridCell204.CellWidth = 28;
            this.xEditGridCell204.Col = 3;
            this.xEditGridCell204.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell204, "xEditGridCell204");
            this.xEditGridCell204.IsReadOnly = true;
            this.xEditGridCell204.IsUpdCol = false;
            this.xEditGridCell204.SuppressRepeating = true;
            // 
            // xEditGridCell205
            // 
            this.xEditGridCell205.CellName = "jaeryo_code";
            this.xEditGridCell205.CellWidth = 77;
            this.xEditGridCell205.Col = -1;
            this.xEditGridCell205.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell205, "xEditGridCell205");
            this.xEditGridCell205.IsReadOnly = true;
            this.xEditGridCell205.IsUpdCol = false;
            this.xEditGridCell205.IsVisible = false;
            this.xEditGridCell205.Row = -1;
            this.xEditGridCell205.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell206
            // 
            this.xEditGridCell206.CellName = "jaeryo_name";
            this.xEditGridCell206.CellWidth = 213;
            this.xEditGridCell206.Col = 4;
            this.xEditGridCell206.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell206, "xEditGridCell206");
            this.xEditGridCell206.IsReadOnly = true;
            this.xEditGridCell206.IsUpdCol = false;
            // 
            // xEditGridCell207
            // 
            this.xEditGridCell207.CellName = "ord_suryang";
            this.xEditGridCell207.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell207.CellWidth = 35;
            this.xEditGridCell207.Col = 6;
            this.xEditGridCell207.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell207, "xEditGridCell207");
            this.xEditGridCell207.IsReadOnly = true;
            this.xEditGridCell207.IsUpdCol = false;
            // 
            // xEditGridCell208
            // 
            this.xEditGridCell208.CellName = "dv_time";
            this.xEditGridCell208.CellWidth = 77;
            this.xEditGridCell208.Col = -1;
            this.xEditGridCell208.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell208, "xEditGridCell208");
            this.xEditGridCell208.IsReadOnly = true;
            this.xEditGridCell208.IsUpdCol = false;
            this.xEditGridCell208.IsVisible = false;
            this.xEditGridCell208.Row = -1;
            this.xEditGridCell208.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell209
            // 
            this.xEditGridCell209.CellName = "dv";
            this.xEditGridCell209.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell209.CellWidth = 22;
            this.xEditGridCell209.Col = 7;
            this.xEditGridCell209.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell209, "xEditGridCell209");
            this.xEditGridCell209.IsReadOnly = true;
            this.xEditGridCell209.IsUpdCol = false;
            // 
            // xEditGridCell210
            // 
            this.xEditGridCell210.CellName = "nalsu";
            this.xEditGridCell210.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell210.CellWidth = 22;
            this.xEditGridCell210.Col = 8;
            this.xEditGridCell210.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell210, "xEditGridCell210");
            this.xEditGridCell210.IsReadOnly = true;
            this.xEditGridCell210.IsUpdCol = false;
            // 
            // xEditGridCell211
            // 
            this.xEditGridCell211.CellName = "order_danui";
            this.xEditGridCell211.CellWidth = 77;
            this.xEditGridCell211.Col = -1;
            this.xEditGridCell211.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell211, "xEditGridCell211");
            this.xEditGridCell211.IsReadOnly = true;
            this.xEditGridCell211.IsUpdCol = false;
            this.xEditGridCell211.IsVisible = false;
            this.xEditGridCell211.Row = -1;
            // 
            // xEditGridCell212
            // 
            this.xEditGridCell212.CellName = "danui_name";
            this.xEditGridCell212.CellWidth = 49;
            this.xEditGridCell212.Col = 9;
            this.xEditGridCell212.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell212, "xEditGridCell212");
            this.xEditGridCell212.IsReadOnly = true;
            this.xEditGridCell212.IsUpdCol = false;
            // 
            // xEditGridCell213
            // 
            this.xEditGridCell213.CellName = "bogyong_code";
            this.xEditGridCell213.CellWidth = 77;
            this.xEditGridCell213.Col = -1;
            this.xEditGridCell213.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell213, "xEditGridCell213");
            this.xEditGridCell213.IsReadOnly = true;
            this.xEditGridCell213.IsUpdCol = false;
            this.xEditGridCell213.IsVisible = false;
            this.xEditGridCell213.Row = -1;
            // 
            // xEditGridCell214
            // 
            this.xEditGridCell214.CellName = "bogyong_name";
            this.xEditGridCell214.CellWidth = 60;
            this.xEditGridCell214.Col = 10;
            this.xEditGridCell214.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell214, "xEditGridCell214");
            this.xEditGridCell214.IsReadOnly = true;
            this.xEditGridCell214.IsUpdCol = false;
            this.xEditGridCell214.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell215
            // 
            this.xEditGridCell215.CellName = "powder_yn";
            this.xEditGridCell215.CellWidth = 77;
            this.xEditGridCell215.Col = -1;
            this.xEditGridCell215.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell215, "xEditGridCell215");
            this.xEditGridCell215.IsReadOnly = true;
            this.xEditGridCell215.IsVisible = false;
            this.xEditGridCell215.Row = -1;
            this.xEditGridCell215.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell216
            // 
            this.xEditGridCell216.CellLen = 100;
            this.xEditGridCell216.CellName = "remark";
            this.xEditGridCell216.CellWidth = 45;
            this.xEditGridCell216.Col = 12;
            this.xEditGridCell216.DisplayMemoText = true;
            this.xEditGridCell216.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell216.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell216, "xEditGridCell216");
            this.xEditGridCell216.IsReadOnly = true;
            // 
            // xEditGridCell217
            // 
            this.xEditGridCell217.CellName = "dv_1";
            this.xEditGridCell217.CellWidth = 77;
            this.xEditGridCell217.Col = -1;
            this.xEditGridCell217.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell217, "xEditGridCell217");
            this.xEditGridCell217.IsReadOnly = true;
            this.xEditGridCell217.IsVisible = false;
            this.xEditGridCell217.Row = -1;
            // 
            // xEditGridCell218
            // 
            this.xEditGridCell218.CellName = "dv_2";
            this.xEditGridCell218.CellWidth = 77;
            this.xEditGridCell218.Col = -1;
            this.xEditGridCell218.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell218, "xEditGridCell218");
            this.xEditGridCell218.IsReadOnly = true;
            this.xEditGridCell218.IsVisible = false;
            this.xEditGridCell218.Row = -1;
            // 
            // xEditGridCell219
            // 
            this.xEditGridCell219.CellName = "dv_3";
            this.xEditGridCell219.CellWidth = 77;
            this.xEditGridCell219.Col = -1;
            this.xEditGridCell219.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell219, "xEditGridCell219");
            this.xEditGridCell219.IsReadOnly = true;
            this.xEditGridCell219.IsVisible = false;
            this.xEditGridCell219.Row = -1;
            // 
            // xEditGridCell220
            // 
            this.xEditGridCell220.CellName = "dv_4";
            this.xEditGridCell220.CellWidth = 77;
            this.xEditGridCell220.Col = -1;
            this.xEditGridCell220.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell220, "xEditGridCell220");
            this.xEditGridCell220.IsReadOnly = true;
            this.xEditGridCell220.IsVisible = false;
            this.xEditGridCell220.Row = -1;
            // 
            // xEditGridCell221
            // 
            this.xEditGridCell221.CellName = "dv_5";
            this.xEditGridCell221.CellWidth = 77;
            this.xEditGridCell221.Col = -1;
            this.xEditGridCell221.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell221, "xEditGridCell221");
            this.xEditGridCell221.IsReadOnly = true;
            this.xEditGridCell221.IsVisible = false;
            this.xEditGridCell221.Row = -1;
            // 
            // xEditGridCell222
            // 
            this.xEditGridCell222.CellName = "hubal_change_yn";
            this.xEditGridCell222.CellWidth = 25;
            this.xEditGridCell222.Col = 11;
            this.xEditGridCell222.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell222.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell222, "xEditGridCell222");
            this.xEditGridCell222.IsReadOnly = true;
            this.xEditGridCell222.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell223
            // 
            this.xEditGridCell223.CellName = "pharmacy";
            this.xEditGridCell223.CellWidth = 77;
            this.xEditGridCell223.Col = -1;
            this.xEditGridCell223.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell223, "xEditGridCell223");
            this.xEditGridCell223.IsReadOnly = true;
            this.xEditGridCell223.IsVisible = false;
            this.xEditGridCell223.Row = -1;
            this.xEditGridCell223.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell224
            // 
            this.xEditGridCell224.CellName = "drg_pack_yn";
            this.xEditGridCell224.CellWidth = 77;
            this.xEditGridCell224.Col = -1;
            this.xEditGridCell224.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell224, "xEditGridCell224");
            this.xEditGridCell224.IsReadOnly = true;
            this.xEditGridCell224.IsVisible = false;
            this.xEditGridCell224.Row = -1;
            this.xEditGridCell224.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell225
            // 
            this.xEditGridCell225.CellName = "jusa";
            this.xEditGridCell225.Col = 5;
            this.xEditGridCell225.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell225, "xEditGridCell225");
            this.xEditGridCell225.IsReadOnly = true;
            // 
            // xEditGridCell226
            // 
            this.xEditGridCell226.CellName = "suname";
            this.xEditGridCell226.CellWidth = 85;
            this.xEditGridCell226.Col = 2;
            this.xEditGridCell226.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell226, "xEditGridCell226");
            this.xEditGridCell226.IsReadOnly = true;
            this.xEditGridCell226.SuppressRepeating = true;
            // 
            // xEditGridCell227
            // 
            this.xEditGridCell227.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell227.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell227.CellName = "drg_bunho";
            this.xEditGridCell227.CellWidth = 40;
            this.xEditGridCell227.Col = 1;
            this.xEditGridCell227.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell227, "xEditGridCell227");
            this.xEditGridCell227.IsReadOnly = true;
            this.xEditGridCell227.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell227.SuppressRepeating = true;
            // 
            // xEditGridCell228
            // 
            this.xEditGridCell228.CellName = "jubsu_date";
            this.xEditGridCell228.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell228.CellWidth = 77;
            this.xEditGridCell228.Col = -1;
            this.xEditGridCell228.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell228, "xEditGridCell228");
            this.xEditGridCell228.IsVisible = false;
            this.xEditGridCell228.Row = -1;
            // 
            // xEditGridCell229
            // 
            this.xEditGridCell229.CellName = "bunho";
            this.xEditGridCell229.CellWidth = 77;
            this.xEditGridCell229.Col = -1;
            this.xEditGridCell229.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell229, "xEditGridCell229");
            this.xEditGridCell229.IsVisible = false;
            this.xEditGridCell229.Row = -1;
            // 
            // xEditGridCell230
            // 
            this.xEditGridCell230.CellName = "bannab_yn";
            this.xEditGridCell230.CellWidth = 77;
            this.xEditGridCell230.Col = -1;
            this.xEditGridCell230.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell230, "xEditGridCell230");
            this.xEditGridCell230.IsVisible = false;
            this.xEditGridCell230.Row = -1;
            // 
            // xEditGridCell231
            // 
            this.xEditGridCell231.CellName = "source_fkocs2003";
            this.xEditGridCell231.CellWidth = 77;
            this.xEditGridCell231.Col = -1;
            this.xEditGridCell231.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell231, "xEditGridCell231");
            this.xEditGridCell231.IsVisible = false;
            this.xEditGridCell231.Row = -1;
            // 
            // xEditGridCell232
            // 
            this.xEditGridCell232.CellName = "fkocs2003";
            this.xEditGridCell232.CellWidth = 77;
            this.xEditGridCell232.Col = -1;
            this.xEditGridCell232.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell232, "xEditGridCell232");
            this.xEditGridCell232.IsVisible = false;
            this.xEditGridCell232.Row = -1;
            // 
            // xEditGridCell233
            // 
            this.xEditGridCell233.CellName = "hope_date";
            this.xEditGridCell233.CellWidth = 77;
            this.xEditGridCell233.Col = -1;
            this.xEditGridCell233.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell233, "xEditGridCell233");
            this.xEditGridCell233.IsVisible = false;
            this.xEditGridCell233.Row = -1;
            // 
            // xEditGridCell234
            // 
            this.xEditGridCell234.CellName = "dc_yn";
            this.xEditGridCell234.CellWidth = 77;
            this.xEditGridCell234.Col = -1;
            this.xEditGridCell234.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell234, "xEditGridCell234");
            this.xEditGridCell234.IsVisible = false;
            this.xEditGridCell234.Row = -1;
            // 
            // xEditGridCell235
            // 
            this.xEditGridCell235.CellName = "order_gubun";
            this.xEditGridCell235.CellWidth = 77;
            this.xEditGridCell235.Col = -1;
            this.xEditGridCell235.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell235, "xEditGridCell235");
            this.xEditGridCell235.IsVisible = false;
            this.xEditGridCell235.Row = -1;
            // 
            // xEditGridCell236
            // 
            this.xEditGridCell236.CellName = "mix_group";
            this.xEditGridCell236.CellWidth = 77;
            this.xEditGridCell236.Col = -1;
            this.xEditGridCell236.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell236, "xEditGridCell236");
            this.xEditGridCell236.IsVisible = false;
            this.xEditGridCell236.Row = -1;
            // 
            // xEditGridCell437
            // 
            this.xEditGridCell437.CellName = "brought_drg_yn";
            this.xEditGridCell437.Col = -1;
            this.xEditGridCell437.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell437, "xEditGridCell437");
            this.xEditGridCell437.IsVisible = false;
            this.xEditGridCell437.Row = -1;
            // 
            // xEditGridCell438
            // 
            this.xEditGridCell438.CellName = "emergency";
            this.xEditGridCell438.Col = -1;
            this.xEditGridCell438.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell438, "xEditGridCell438");
            this.xEditGridCell438.IsVisible = false;
            this.xEditGridCell438.Row = -1;
            // 
            // xPanel11
            // 
            resources.ApplyResources(this.xPanel11, "xPanel11");
            this.xPanel11.Controls.Add(this.grdPaDcList);
            this.xPanel11.DrawBorder = true;
            this.xPanel11.Name = "xPanel11";
            // 
            // grdPaDcList
            // 
            resources.ApplyResources(this.grdPaDcList, "grdPaDcList");
            this.grdPaDcList.ApplyPaintEventToAllColumn = true;
            this.grdPaDcList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell238,
            this.xEditGridCell239,
            this.xEditGridCell240,
            this.xEditGridCell241,
            this.xEditGridCell242,
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
            this.xEditGridCell254});
            this.grdPaDcList.ColPerLine = 12;
            this.grdPaDcList.Cols = 13;
            this.grdPaDcList.ExecuteQuery = null;
            this.grdPaDcList.FixedCols = 1;
            this.grdPaDcList.FixedRows = 1;
            this.grdPaDcList.HeaderHeights.Add(40);
            this.grdPaDcList.Name = "grdPaDcList";
            this.grdPaDcList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPaDcList.ParamList")));
            this.grdPaDcList.QuerySQL = resources.GetString("grdPaDcList.QuerySQL");
            this.grdPaDcList.ReadOnly = true;
            this.grdPaDcList.RowHeaderVisible = true;
            this.grdPaDcList.Rows = 2;
            this.grdPaDcList.TabStop = false;
            this.grdPaDcList.ToolTipActive = true;
            this.grdPaDcList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPaDcList_RowFocusChanged);
            this.grdPaDcList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPaDcList_QueryStarting);
            // 
            // xEditGridCell238
            // 
            this.xEditGridCell238.CellName = "jubsu_date";
            this.xEditGridCell238.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell238.CellWidth = 78;
            this.xEditGridCell238.Col = 5;
            this.xEditGridCell238.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell238, "xEditGridCell238");
            this.xEditGridCell238.IsReadOnly = true;
            this.xEditGridCell238.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell239
            // 
            this.xEditGridCell239.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell239.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell239.CellName = "drg_bunho";
            this.xEditGridCell239.CellWidth = 40;
            this.xEditGridCell239.Col = 2;
            this.xEditGridCell239.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell239, "xEditGridCell239");
            this.xEditGridCell239.IsReadOnly = true;
            this.xEditGridCell239.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell239.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell240
            // 
            this.xEditGridCell240.CellName = "bunho";
            this.xEditGridCell240.CellWidth = 70;
            this.xEditGridCell240.Col = 8;
            this.xEditGridCell240.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell240, "xEditGridCell240");
            this.xEditGridCell240.IsReadOnly = true;
            this.xEditGridCell240.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
            this.xEditGridCell240.SuppressRepeating = true;
            this.xEditGridCell240.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell241
            // 
            this.xEditGridCell241.CellLen = 50;
            this.xEditGridCell241.CellName = "suname";
            this.xEditGridCell241.CellWidth = 83;
            this.xEditGridCell241.Col = 9;
            this.xEditGridCell241.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell241, "xEditGridCell241");
            this.xEditGridCell241.IsReadOnly = true;
            this.xEditGridCell241.SuppressRepeating = true;
            // 
            // xEditGridCell242
            // 
            this.xEditGridCell242.CellName = "sex";
            this.xEditGridCell242.CellWidth = 30;
            this.xEditGridCell242.Col = 11;
            this.xEditGridCell242.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell242, "xEditGridCell242");
            this.xEditGridCell242.IsReadOnly = true;
            // 
            // xEditGridCell243
            // 
            this.xEditGridCell243.CellName = "age";
            this.xEditGridCell243.CellWidth = 28;
            this.xEditGridCell243.Col = 12;
            this.xEditGridCell243.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell243, "xEditGridCell243");
            this.xEditGridCell243.IsReadOnly = true;
            // 
            // xEditGridCell244
            // 
            this.xEditGridCell244.CellName = "doctor";
            this.xEditGridCell244.CellWidth = 40;
            this.xEditGridCell244.Col = -1;
            this.xEditGridCell244.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell244, "xEditGridCell244");
            this.xEditGridCell244.IsReadOnly = true;
            this.xEditGridCell244.IsVisible = false;
            this.xEditGridCell244.Row = -1;
            // 
            // xEditGridCell245
            // 
            this.xEditGridCell245.CellLen = 50;
            this.xEditGridCell245.CellName = "doctor_name";
            this.xEditGridCell245.Col = 10;
            this.xEditGridCell245.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell245, "xEditGridCell245");
            this.xEditGridCell245.IsReadOnly = true;
            // 
            // xEditGridCell246
            // 
            this.xEditGridCell246.CellName = "ho_dong";
            this.xEditGridCell246.Col = -1;
            this.xEditGridCell246.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell246, "xEditGridCell246");
            this.xEditGridCell246.IsReadOnly = true;
            this.xEditGridCell246.IsVisible = false;
            this.xEditGridCell246.Row = -1;
            // 
            // xEditGridCell247
            // 
            this.xEditGridCell247.CellName = "ho_dong_name";
            this.xEditGridCell247.CellWidth = 42;
            this.xEditGridCell247.Col = 6;
            this.xEditGridCell247.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell247, "xEditGridCell247");
            this.xEditGridCell247.IsReadOnly = true;
            // 
            // xEditGridCell248
            // 
            this.xEditGridCell248.CellName = "ho_code";
            this.xEditGridCell248.CellWidth = 32;
            this.xEditGridCell248.Col = 7;
            this.xEditGridCell248.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell248, "xEditGridCell248");
            this.xEditGridCell248.IsReadOnly = true;
            // 
            // xEditGridCell249
            // 
            this.xEditGridCell249.CellName = "toiwon_drg_yn";
            this.xEditGridCell249.CellWidth = 40;
            this.xEditGridCell249.Col = -1;
            this.xEditGridCell249.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell249, "xEditGridCell249");
            this.xEditGridCell249.IsReadOnly = true;
            this.xEditGridCell249.IsVisible = false;
            this.xEditGridCell249.Row = -1;
            this.xEditGridCell249.SuppressRepeating = true;
            // 
            // xEditGridCell250
            // 
            this.xEditGridCell250.CellName = "gwa";
            this.xEditGridCell250.CellWidth = 40;
            this.xEditGridCell250.Col = -1;
            this.xEditGridCell250.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell250, "xEditGridCell250");
            this.xEditGridCell250.IsReadOnly = true;
            this.xEditGridCell250.IsVisible = false;
            this.xEditGridCell250.Row = -1;
            this.xEditGridCell250.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell251
            // 
            this.xEditGridCell251.CellName = "order_date";
            this.xEditGridCell251.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell251.CellWidth = 78;
            this.xEditGridCell251.Col = 3;
            this.xEditGridCell251.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell251, "xEditGridCell251");
            this.xEditGridCell251.IsReadOnly = true;
            // 
            // xEditGridCell252
            // 
            this.xEditGridCell252.CellName = "hope_date";
            this.xEditGridCell252.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell252.Col = 4;
            this.xEditGridCell252.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell252, "xEditGridCell252");
            this.xEditGridCell252.IsReadOnly = true;
            // 
            // xEditGridCell253
            // 
            this.xEditGridCell253.AlterateRowForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell253.CellName = "magam_gubun";
            this.xEditGridCell253.CellWidth = 30;
            this.xEditGridCell253.Col = 1;
            this.xEditGridCell253.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem15,
            this.xComboItem17,
            this.xComboItem18,
            this.xComboItem19,
            this.xComboItem20});
            this.xEditGridCell253.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell253.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell253, "xEditGridCell253");
            this.xEditGridCell253.IsReadOnly = true;
            this.xEditGridCell253.RowForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell253.SelectedForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell253.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem15
            // 
            resources.ApplyResources(this.xComboItem15, "xComboItem15");
            this.xComboItem15.ValueItem = "21";
            // 
            // xComboItem17
            // 
            resources.ApplyResources(this.xComboItem17, "xComboItem17");
            this.xComboItem17.ValueItem = "22";
            // 
            // xComboItem18
            // 
            resources.ApplyResources(this.xComboItem18, "xComboItem18");
            this.xComboItem18.ValueItem = "31";
            // 
            // xComboItem19
            // 
            resources.ApplyResources(this.xComboItem19, "xComboItem19");
            this.xComboItem19.ValueItem = "32";
            // 
            // xComboItem20
            // 
            resources.ApplyResources(this.xComboItem20, "xComboItem20");
            this.xComboItem20.ValueItem = "ER";
            // 
            // xEditGridCell254
            // 
            this.xEditGridCell254.CellName = "jusa_yn";
            this.xEditGridCell254.CellWidth = 40;
            this.xEditGridCell254.Col = -1;
            this.xEditGridCell254.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell254, "xEditGridCell254");
            this.xEditGridCell254.IsReadOnly = true;
            this.xEditGridCell254.IsVisible = false;
            this.xEditGridCell254.Row = -1;
            // 
            // xPanel13
            // 
            resources.ApplyResources(this.xPanel13, "xPanel13");
            this.xPanel13.Controls.Add(this.btnDcReLabelPrint);
            this.xPanel13.Controls.Add(this.xButton2);
            this.xPanel13.Controls.Add(this.btnDcRePrint);
            this.xPanel13.Controls.Add(this.btnListDc);
            this.xPanel13.DrawBorder = true;
            this.xPanel13.Name = "xPanel13";
            // 
            // btnDcReLabelPrint
            // 
            resources.ApplyResources(this.btnDcReLabelPrint, "btnDcReLabelPrint");
            this.btnDcReLabelPrint.ImageIndex = 2;
            this.btnDcReLabelPrint.ImageList = this.ImageList;
            this.btnDcReLabelPrint.Name = "btnDcReLabelPrint";
            this.btnDcReLabelPrint.Scheme = IHIS.Framework.XButtonSchemes.Green;
            // 
            // xButton2
            // 
            resources.ApplyResources(this.xButton2, "xButton2");
            this.xButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            this.xButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xButton2.ImageIndex = 9;
            this.xButton2.ImageList = this.ImageList;
            this.xButton2.Name = "xButton2";
            this.xButton2.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            // 
            // btnDcRePrint
            // 
            resources.ApplyResources(this.btnDcRePrint, "btnDcRePrint");
            this.btnDcRePrint.ImageIndex = 2;
            this.btnDcRePrint.ImageList = this.ImageList;
            this.btnDcRePrint.Name = "btnDcRePrint";
            this.btnDcRePrint.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnDcRePrint.Click += new System.EventHandler(this.btnDcRePrint_Click);
            // 
            // btnListDc
            // 
            resources.ApplyResources(this.btnListDc, "btnListDc");
            this.btnListDc.IsVisiblePreview = false;
            this.btnListDc.IsVisibleReset = false;
            this.btnListDc.Name = "btnListDc";
            this.btnListDc.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnListDc.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // tabPage4
            // 
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Controls.Add(this.xPanel14);
            this.tabPage4.ImageIndex = 15;
            this.tabPage4.ImageList = this.ImageList;
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            // 
            // xPanel14
            // 
            resources.ApplyResources(this.xPanel14, "xPanel14");
            this.xPanel14.Controls.Add(this.xPanel15);
            this.xPanel14.Controls.Add(this.xPanel16);
            this.xPanel14.Controls.Add(this.xPanel17);
            this.xPanel14.Name = "xPanel14";
            // 
            // xPanel15
            // 
            resources.ApplyResources(this.xPanel15, "xPanel15");
            this.xPanel15.Controls.Add(this.grdPrnOrder);
            this.xPanel15.Controls.Add(this.grdPrnJusaOrder);
            this.xPanel15.DrawBorder = true;
            this.xPanel15.Name = "xPanel15";
            // 
            // grdPrnOrder
            // 
            this.grdPrnOrder.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdPrnOrder, "grdPrnOrder");
            this.grdPrnOrder.ApplyPaintEventToAllColumn = true;
            this.grdPrnOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell255,
            this.xEditGridCell256,
            this.xEditGridCell257,
            this.xEditGridCell258,
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
            this.xEditGridCell365});
            this.grdPrnOrder.ColPerLine = 12;
            this.grdPrnOrder.Cols = 13;
            this.grdPrnOrder.ExecuteQuery = null;
            this.grdPrnOrder.FixedCols = 1;
            this.grdPrnOrder.FixedRows = 2;
            this.grdPrnOrder.HeaderHeights.Add(39);
            this.grdPrnOrder.HeaderHeights.Add(0);
            this.grdPrnOrder.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader5});
            this.grdPrnOrder.Name = "grdPrnOrder";
            this.grdPrnOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPrnOrder.ParamList")));
            this.grdPrnOrder.QuerySQL = resources.GetString("grdPrnOrder.QuerySQL");
            this.grdPrnOrder.RowHeaderVisible = true;
            this.grdPrnOrder.Rows = 3;
            this.grdPrnOrder.TabStop = false;
            this.grdPrnOrder.ToolTipActive = true;
            this.grdPrnOrder.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdPackPowder_GridColumnChanged);
            this.grdPrnOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPrnOrder_QueryStarting);
            this.grdPrnOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdMagamOrder_QueryEnd);
            // 
            // xEditGridCell255
            // 
            this.xEditGridCell255.CellName = "order_date";
            this.xEditGridCell255.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell255.CellWidth = 77;
            this.xEditGridCell255.Col = -1;
            this.xEditGridCell255.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell255, "xEditGridCell255");
            this.xEditGridCell255.IsReadOnly = true;
            this.xEditGridCell255.IsUpdCol = false;
            this.xEditGridCell255.IsVisible = false;
            this.xEditGridCell255.Row = -1;
            this.xEditGridCell255.SuppressRepeating = true;
            // 
            // xEditGridCell256
            // 
            this.xEditGridCell256.CellName = "mix_group";
            this.xEditGridCell256.CellWidth = 20;
            this.xEditGridCell256.Col = -1;
            this.xEditGridCell256.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell256, "xEditGridCell256");
            this.xEditGridCell256.IsReadOnly = true;
            this.xEditGridCell256.IsUpdCol = false;
            this.xEditGridCell256.IsVisible = false;
            this.xEditGridCell256.Row = -1;
            this.xEditGridCell256.SuppressRepeating = true;
            // 
            // xEditGridCell257
            // 
            this.xEditGridCell257.CellName = "jaeryo_code";
            this.xEditGridCell257.CellWidth = 77;
            this.xEditGridCell257.Col = -1;
            this.xEditGridCell257.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell257, "xEditGridCell257");
            this.xEditGridCell257.IsReadOnly = true;
            this.xEditGridCell257.IsUpdCol = false;
            this.xEditGridCell257.IsVisible = false;
            this.xEditGridCell257.Row = -1;
            this.xEditGridCell257.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell258
            // 
            this.xEditGridCell258.CellName = "jaeryo_name";
            this.xEditGridCell258.CellWidth = 273;
            this.xEditGridCell258.Col = 2;
            this.xEditGridCell258.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell258, "xEditGridCell258");
            this.xEditGridCell258.IsReadOnly = true;
            this.xEditGridCell258.IsUpdCol = false;
            this.xEditGridCell258.RowSpan = 2;
            // 
            // xEditGridCell336
            // 
            this.xEditGridCell336.CellName = "ord_suryang";
            this.xEditGridCell336.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell336.CellWidth = 30;
            this.xEditGridCell336.Col = 3;
            this.xEditGridCell336.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell336, "xEditGridCell336");
            this.xEditGridCell336.IsReadOnly = true;
            this.xEditGridCell336.IsUpdCol = false;
            this.xEditGridCell336.RowSpan = 2;
            // 
            // xEditGridCell337
            // 
            this.xEditGridCell337.CellName = "dv_time";
            this.xEditGridCell337.CellWidth = 20;
            this.xEditGridCell337.Col = 4;
            this.xEditGridCell337.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell337, "xEditGridCell337");
            this.xEditGridCell337.IsReadOnly = true;
            this.xEditGridCell337.IsUpdCol = false;
            this.xEditGridCell337.Row = 1;
            this.xEditGridCell337.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell338
            // 
            this.xEditGridCell338.CellName = "dv";
            this.xEditGridCell338.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell338.CellWidth = 22;
            this.xEditGridCell338.Col = 5;
            this.xEditGridCell338.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell338, "xEditGridCell338");
            this.xEditGridCell338.IsReadOnly = true;
            this.xEditGridCell338.IsUpdCol = false;
            this.xEditGridCell338.Row = 1;
            // 
            // xEditGridCell339
            // 
            this.xEditGridCell339.CellName = "nalsu";
            this.xEditGridCell339.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell339.CellWidth = 22;
            this.xEditGridCell339.Col = 7;
            this.xEditGridCell339.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell339, "xEditGridCell339");
            this.xEditGridCell339.IsReadOnly = true;
            this.xEditGridCell339.IsUpdCol = false;
            this.xEditGridCell339.RowSpan = 2;
            // 
            // xEditGridCell340
            // 
            this.xEditGridCell340.CellName = "order_danui";
            this.xEditGridCell340.CellWidth = 50;
            this.xEditGridCell340.Col = -1;
            this.xEditGridCell340.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell340, "xEditGridCell340");
            this.xEditGridCell340.IsReadOnly = true;
            this.xEditGridCell340.IsUpdCol = false;
            this.xEditGridCell340.IsVisible = false;
            this.xEditGridCell340.Row = -1;
            // 
            // xEditGridCell341
            // 
            this.xEditGridCell341.CellName = "danui_name";
            this.xEditGridCell341.CellWidth = 49;
            this.xEditGridCell341.Col = 6;
            this.xEditGridCell341.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell341, "xEditGridCell341");
            this.xEditGridCell341.IsReadOnly = true;
            this.xEditGridCell341.IsUpdCol = false;
            this.xEditGridCell341.RowSpan = 2;
            // 
            // xEditGridCell342
            // 
            this.xEditGridCell342.CellName = "bogyong_code";
            this.xEditGridCell342.CellWidth = 197;
            this.xEditGridCell342.Col = -1;
            this.xEditGridCell342.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell342, "xEditGridCell342");
            this.xEditGridCell342.IsReadOnly = true;
            this.xEditGridCell342.IsUpdCol = false;
            this.xEditGridCell342.IsVisible = false;
            this.xEditGridCell342.Row = -1;
            // 
            // xEditGridCell343
            // 
            this.xEditGridCell343.CellName = "bogyong_name";
            this.xEditGridCell343.CellWidth = 133;
            this.xEditGridCell343.Col = 8;
            this.xEditGridCell343.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell343, "xEditGridCell343");
            this.xEditGridCell343.IsReadOnly = true;
            this.xEditGridCell343.IsUpdCol = false;
            this.xEditGridCell343.RowSpan = 2;
            // 
            // xEditGridCell344
            // 
            this.xEditGridCell344.CellName = "powder_yn";
            this.xEditGridCell344.CellWidth = 22;
            this.xEditGridCell344.Col = 10;
            this.xEditGridCell344.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell344.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell344, "xEditGridCell344");
            this.xEditGridCell344.IsUpdCol = false;
            this.xEditGridCell344.RowSpan = 2;
            this.xEditGridCell344.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell345
            // 
            this.xEditGridCell345.CellLen = 100;
            this.xEditGridCell345.CellName = "remark";
            this.xEditGridCell345.CellWidth = 55;
            this.xEditGridCell345.Col = 12;
            this.xEditGridCell345.DisplayMemoText = true;
            this.xEditGridCell345.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell345.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell345, "xEditGridCell345");
            this.xEditGridCell345.IsUpdCol = false;
            this.xEditGridCell345.RowSpan = 2;
            // 
            // xEditGridCell346
            // 
            this.xEditGridCell346.CellName = "dv_1";
            this.xEditGridCell346.Col = -1;
            this.xEditGridCell346.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell346, "xEditGridCell346");
            this.xEditGridCell346.IsReadOnly = true;
            this.xEditGridCell346.IsUpdCol = false;
            this.xEditGridCell346.IsVisible = false;
            this.xEditGridCell346.Row = -1;
            // 
            // xEditGridCell347
            // 
            this.xEditGridCell347.CellName = "dv_2";
            this.xEditGridCell347.Col = -1;
            this.xEditGridCell347.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell347, "xEditGridCell347");
            this.xEditGridCell347.IsReadOnly = true;
            this.xEditGridCell347.IsUpdCol = false;
            this.xEditGridCell347.IsVisible = false;
            this.xEditGridCell347.Row = -1;
            // 
            // xEditGridCell348
            // 
            this.xEditGridCell348.CellName = "dv_3";
            this.xEditGridCell348.Col = -1;
            this.xEditGridCell348.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell348, "xEditGridCell348");
            this.xEditGridCell348.IsReadOnly = true;
            this.xEditGridCell348.IsUpdCol = false;
            this.xEditGridCell348.IsVisible = false;
            this.xEditGridCell348.Row = -1;
            // 
            // xEditGridCell349
            // 
            this.xEditGridCell349.CellName = "dv_4";
            this.xEditGridCell349.Col = -1;
            this.xEditGridCell349.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell349, "xEditGridCell349");
            this.xEditGridCell349.IsReadOnly = true;
            this.xEditGridCell349.IsUpdCol = false;
            this.xEditGridCell349.IsVisible = false;
            this.xEditGridCell349.Row = -1;
            // 
            // xEditGridCell350
            // 
            this.xEditGridCell350.CellName = "dv_5";
            this.xEditGridCell350.Col = -1;
            this.xEditGridCell350.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell350, "xEditGridCell350");
            this.xEditGridCell350.IsReadOnly = true;
            this.xEditGridCell350.IsUpdCol = false;
            this.xEditGridCell350.IsVisible = false;
            this.xEditGridCell350.Row = -1;
            // 
            // xEditGridCell351
            // 
            this.xEditGridCell351.CellName = "hubal_change_yn";
            this.xEditGridCell351.CellWidth = 21;
            this.xEditGridCell351.Col = -1;
            this.xEditGridCell351.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell351, "xEditGridCell351");
            this.xEditGridCell351.IsReadOnly = true;
            this.xEditGridCell351.IsUpdCol = false;
            this.xEditGridCell351.IsVisible = false;
            this.xEditGridCell351.Row = -1;
            this.xEditGridCell351.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell352
            // 
            this.xEditGridCell352.CellName = "pharmacy";
            this.xEditGridCell352.CellWidth = 30;
            this.xEditGridCell352.Col = 11;
            this.xEditGridCell352.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell352.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell352, "xEditGridCell352");
            this.xEditGridCell352.IsReadOnly = true;
            this.xEditGridCell352.IsUpdCol = false;
            this.xEditGridCell352.RowSpan = 2;
            this.xEditGridCell352.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell353
            // 
            this.xEditGridCell353.CellName = "drg_pack_yn";
            this.xEditGridCell353.CellWidth = 21;
            this.xEditGridCell353.Col = 9;
            this.xEditGridCell353.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell353.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell353, "xEditGridCell353");
            this.xEditGridCell353.IsUpdCol = false;
            this.xEditGridCell353.RowSpan = 2;
            this.xEditGridCell353.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell354
            // 
            this.xEditGridCell354.CellName = "jusa";
            this.xEditGridCell354.CellWidth = 43;
            this.xEditGridCell354.Col = -1;
            this.xEditGridCell354.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell354, "xEditGridCell354");
            this.xEditGridCell354.IsReadOnly = true;
            this.xEditGridCell354.IsUpdCol = false;
            this.xEditGridCell354.IsVisible = false;
            this.xEditGridCell354.Row = -1;
            this.xEditGridCell354.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell355
            // 
            this.xEditGridCell355.CellName = "suname";
            this.xEditGridCell355.Col = -1;
            this.xEditGridCell355.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell355, "xEditGridCell355");
            this.xEditGridCell355.IsUpdCol = false;
            this.xEditGridCell355.IsVisible = false;
            this.xEditGridCell355.Row = -1;
            // 
            // xEditGridCell356
            // 
            this.xEditGridCell356.CellName = "drg_bunho";
            this.xEditGridCell356.Col = -1;
            this.xEditGridCell356.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell356, "xEditGridCell356");
            this.xEditGridCell356.IsUpdCol = false;
            this.xEditGridCell356.IsVisible = false;
            this.xEditGridCell356.Row = -1;
            // 
            // xEditGridCell357
            // 
            this.xEditGridCell357.CellName = "fkocs2003";
            this.xEditGridCell357.Col = -1;
            this.xEditGridCell357.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell357, "xEditGridCell357");
            this.xEditGridCell357.IsVisible = false;
            this.xEditGridCell357.Row = -1;
            // 
            // xEditGridCell358
            // 
            this.xEditGridCell358.CellName = "append_yn";
            this.xEditGridCell358.CellWidth = 21;
            this.xEditGridCell358.Col = -1;
            this.xEditGridCell358.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell358, "xEditGridCell358");
            this.xEditGridCell358.IsReadOnly = true;
            this.xEditGridCell358.IsUpdatable = false;
            this.xEditGridCell358.IsUpdCol = false;
            this.xEditGridCell358.IsVisible = false;
            this.xEditGridCell358.Row = -1;
            // 
            // xEditGridCell359
            // 
            this.xEditGridCell359.CellName = "re_use_yn";
            this.xEditGridCell359.Col = -1;
            this.xEditGridCell359.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell359, "xEditGridCell359");
            this.xEditGridCell359.IsVisible = false;
            this.xEditGridCell359.Row = -1;
            // 
            // xEditGridCell360
            // 
            this.xEditGridCell360.CellName = "hope_date";
            this.xEditGridCell360.Col = -1;
            this.xEditGridCell360.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell360, "xEditGridCell360");
            this.xEditGridCell360.IsUpdCol = false;
            this.xEditGridCell360.IsVisible = false;
            this.xEditGridCell360.Row = -1;
            // 
            // xEditGridCell361
            // 
            this.xEditGridCell361.CellName = "hope_time";
            this.xEditGridCell361.Col = -1;
            this.xEditGridCell361.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell361, "xEditGridCell361");
            this.xEditGridCell361.IsUpdCol = false;
            this.xEditGridCell361.IsVisible = false;
            this.xEditGridCell361.Row = -1;
            // 
            // xEditGridCell362
            // 
            this.xEditGridCell362.CellName = "group_ser";
            this.xEditGridCell362.CellWidth = 26;
            this.xEditGridCell362.Col = 1;
            this.xEditGridCell362.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell362, "xEditGridCell362");
            this.xEditGridCell362.IsReadOnly = true;
            this.xEditGridCell362.IsUpdatable = false;
            this.xEditGridCell362.IsUpdCol = false;
            this.xEditGridCell362.RowSpan = 2;
            this.xEditGridCell362.SuppressRepeating = true;
            // 
            // xEditGridCell363
            // 
            this.xEditGridCell363.CellName = "dc_yn";
            this.xEditGridCell363.Col = -1;
            this.xEditGridCell363.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell363, "xEditGridCell363");
            this.xEditGridCell363.IsUpdCol = false;
            this.xEditGridCell363.IsVisible = false;
            this.xEditGridCell363.Row = -1;
            // 
            // xEditGridCell364
            // 
            this.xEditGridCell364.CellName = "order_gubun";
            this.xEditGridCell364.Col = -1;
            this.xEditGridCell364.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell364, "xEditGridCell364");
            this.xEditGridCell364.IsUpdCol = false;
            this.xEditGridCell364.IsVisible = false;
            this.xEditGridCell364.Row = -1;
            // 
            // xEditGridCell365
            // 
            this.xEditGridCell365.CellName = "if_input_control";
            this.xEditGridCell365.Col = -1;
            this.xEditGridCell365.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell365, "xEditGridCell365");
            this.xEditGridCell365.IsVisible = false;
            this.xEditGridCell365.Row = -1;
            // 
            // xGridHeader5
            // 
            this.xGridHeader5.Col = 4;
            this.xGridHeader5.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader5, "xGridHeader5");
            this.xGridHeader5.HeaderWidth = 20;
            // 
            // grdPrnJusaOrder
            // 
            this.grdPrnJusaOrder.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdPrnJusaOrder, "grdPrnJusaOrder");
            this.grdPrnJusaOrder.ApplyPaintEventToAllColumn = true;
            this.grdPrnJusaOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell366,
            this.xEditGridCell367,
            this.xEditGridCell368,
            this.xEditGridCell369,
            this.xEditGridCell370,
            this.xEditGridCell371,
            this.xEditGridCell372,
            this.xEditGridCell373,
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
            this.xEditGridCell399});
            this.grdPrnJusaOrder.ColPerLine = 9;
            this.grdPrnJusaOrder.Cols = 10;
            this.grdPrnJusaOrder.ControlBinding = true;
            this.grdPrnJusaOrder.ExecuteQuery = null;
            this.grdPrnJusaOrder.FixedCols = 1;
            this.grdPrnJusaOrder.FixedRows = 2;
            this.grdPrnJusaOrder.HeaderHeights.Add(39);
            this.grdPrnJusaOrder.HeaderHeights.Add(0);
            this.grdPrnJusaOrder.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader6});
            this.grdPrnJusaOrder.Name = "grdPrnJusaOrder";
            this.grdPrnJusaOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPrnJusaOrder.ParamList")));
            this.grdPrnJusaOrder.QuerySQL = resources.GetString("grdPrnJusaOrder.QuerySQL");
            this.grdPrnJusaOrder.RowHeaderVisible = true;
            this.grdPrnJusaOrder.Rows = 3;
            this.grdPrnJusaOrder.ToolTipActive = true;
            this.grdPrnJusaOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPrnOrder_QueryStarting);
            this.grdPrnJusaOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdMagamOrder_QueryEnd);
            // 
            // xEditGridCell366
            // 
            this.xEditGridCell366.CellName = "order_date";
            this.xEditGridCell366.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell366.CellWidth = 77;
            this.xEditGridCell366.Col = -1;
            this.xEditGridCell366.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell366, "xEditGridCell366");
            this.xEditGridCell366.IsReadOnly = true;
            this.xEditGridCell366.IsUpdCol = false;
            this.xEditGridCell366.IsVisible = false;
            this.xEditGridCell366.Row = -1;
            this.xEditGridCell366.SuppressRepeating = true;
            // 
            // xEditGridCell367
            // 
            this.xEditGridCell367.CellName = "mix_group";
            this.xEditGridCell367.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell367.CellWidth = 20;
            this.xEditGridCell367.Col = -1;
            this.xEditGridCell367.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell367, "xEditGridCell367");
            this.xEditGridCell367.IsReadOnly = true;
            this.xEditGridCell367.IsUpdCol = false;
            this.xEditGridCell367.IsVisible = false;
            this.xEditGridCell367.Row = -1;
            this.xEditGridCell367.SuppressRepeating = true;
            // 
            // xEditGridCell368
            // 
            this.xEditGridCell368.CellName = "jaeryo_code";
            this.xEditGridCell368.CellWidth = 77;
            this.xEditGridCell368.Col = -1;
            this.xEditGridCell368.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell368, "xEditGridCell368");
            this.xEditGridCell368.IsReadOnly = true;
            this.xEditGridCell368.IsUpdCol = false;
            this.xEditGridCell368.IsVisible = false;
            this.xEditGridCell368.Row = -1;
            this.xEditGridCell368.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell369
            // 
            this.xEditGridCell369.CellName = "jaeryo_name";
            this.xEditGridCell369.CellWidth = 305;
            this.xEditGridCell369.Col = 2;
            this.xEditGridCell369.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell369, "xEditGridCell369");
            this.xEditGridCell369.IsReadOnly = true;
            this.xEditGridCell369.IsUpdCol = false;
            this.xEditGridCell369.RowSpan = 2;
            // 
            // xEditGridCell370
            // 
            this.xEditGridCell370.CellName = "ord_suryang";
            this.xEditGridCell370.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell370.CellWidth = 40;
            this.xEditGridCell370.Col = 3;
            this.xEditGridCell370.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell370, "xEditGridCell370");
            this.xEditGridCell370.IsReadOnly = true;
            this.xEditGridCell370.IsUpdCol = false;
            this.xEditGridCell370.RowSpan = 2;
            // 
            // xEditGridCell371
            // 
            this.xEditGridCell371.CellName = "dv_time";
            this.xEditGridCell371.CellWidth = 20;
            this.xEditGridCell371.Col = 4;
            this.xEditGridCell371.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell371, "xEditGridCell371");
            this.xEditGridCell371.IsReadOnly = true;
            this.xEditGridCell371.IsUpdCol = false;
            this.xEditGridCell371.Row = 1;
            this.xEditGridCell371.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell372
            // 
            this.xEditGridCell372.CellName = "dv";
            this.xEditGridCell372.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell372.CellWidth = 22;
            this.xEditGridCell372.Col = 5;
            this.xEditGridCell372.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell372, "xEditGridCell372");
            this.xEditGridCell372.IsReadOnly = true;
            this.xEditGridCell372.IsUpdCol = false;
            this.xEditGridCell372.Row = 1;
            // 
            // xEditGridCell373
            // 
            this.xEditGridCell373.CellName = "nalsu";
            this.xEditGridCell373.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell373.CellWidth = 22;
            this.xEditGridCell373.Col = -1;
            this.xEditGridCell373.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell373, "xEditGridCell373");
            this.xEditGridCell373.IsReadOnly = true;
            this.xEditGridCell373.IsUpdCol = false;
            this.xEditGridCell373.IsVisible = false;
            this.xEditGridCell373.Row = -1;
            // 
            // xEditGridCell374
            // 
            this.xEditGridCell374.CellName = "order_danui";
            this.xEditGridCell374.CellWidth = 50;
            this.xEditGridCell374.Col = -1;
            this.xEditGridCell374.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell374, "xEditGridCell374");
            this.xEditGridCell374.IsReadOnly = true;
            this.xEditGridCell374.IsUpdCol = false;
            this.xEditGridCell374.IsVisible = false;
            this.xEditGridCell374.Row = -1;
            // 
            // xEditGridCell375
            // 
            this.xEditGridCell375.CellName = "danui_name";
            this.xEditGridCell375.CellWidth = 65;
            this.xEditGridCell375.Col = 6;
            this.xEditGridCell375.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell375, "xEditGridCell375");
            this.xEditGridCell375.IsReadOnly = true;
            this.xEditGridCell375.IsUpdCol = false;
            this.xEditGridCell375.RowSpan = 2;
            // 
            // xEditGridCell376
            // 
            this.xEditGridCell376.CellName = "bogyong_code";
            this.xEditGridCell376.CellWidth = 197;
            this.xEditGridCell376.Col = -1;
            this.xEditGridCell376.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell376, "xEditGridCell376");
            this.xEditGridCell376.IsReadOnly = true;
            this.xEditGridCell376.IsUpdCol = false;
            this.xEditGridCell376.IsVisible = false;
            this.xEditGridCell376.Row = -1;
            // 
            // xEditGridCell377
            // 
            this.xEditGridCell377.CellName = "bogyong_name";
            this.xEditGridCell377.CellWidth = 72;
            this.xEditGridCell377.Col = 8;
            this.xEditGridCell377.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell377, "xEditGridCell377");
            this.xEditGridCell377.IsReadOnly = true;
            this.xEditGridCell377.IsUpdCol = false;
            this.xEditGridCell377.RowSpan = 2;
            this.xEditGridCell377.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell378
            // 
            this.xEditGridCell378.CellName = "powder_yn";
            this.xEditGridCell378.CellWidth = 19;
            this.xEditGridCell378.Col = -1;
            this.xEditGridCell378.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell378, "xEditGridCell378");
            this.xEditGridCell378.IsReadOnly = true;
            this.xEditGridCell378.IsUpdCol = false;
            this.xEditGridCell378.IsVisible = false;
            this.xEditGridCell378.Row = -1;
            this.xEditGridCell378.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell379
            // 
            this.xEditGridCell379.CellLen = 100;
            this.xEditGridCell379.CellName = "remark";
            this.xEditGridCell379.CellWidth = 45;
            this.xEditGridCell379.Col = 9;
            this.xEditGridCell379.DisplayMemoText = true;
            this.xEditGridCell379.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell379.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell379, "xEditGridCell379");
            this.xEditGridCell379.IsUpdCol = false;
            this.xEditGridCell379.RowSpan = 2;
            // 
            // xEditGridCell380
            // 
            this.xEditGridCell380.CellName = "dv_1";
            this.xEditGridCell380.Col = -1;
            this.xEditGridCell380.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell380, "xEditGridCell380");
            this.xEditGridCell380.IsReadOnly = true;
            this.xEditGridCell380.IsUpdCol = false;
            this.xEditGridCell380.IsVisible = false;
            this.xEditGridCell380.Row = -1;
            // 
            // xEditGridCell381
            // 
            this.xEditGridCell381.CellName = "dv_2";
            this.xEditGridCell381.Col = -1;
            this.xEditGridCell381.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell381, "xEditGridCell381");
            this.xEditGridCell381.IsReadOnly = true;
            this.xEditGridCell381.IsUpdCol = false;
            this.xEditGridCell381.IsVisible = false;
            this.xEditGridCell381.Row = -1;
            // 
            // xEditGridCell382
            // 
            this.xEditGridCell382.CellName = "dv_3";
            this.xEditGridCell382.Col = -1;
            this.xEditGridCell382.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell382, "xEditGridCell382");
            this.xEditGridCell382.IsReadOnly = true;
            this.xEditGridCell382.IsUpdCol = false;
            this.xEditGridCell382.IsVisible = false;
            this.xEditGridCell382.Row = -1;
            // 
            // xEditGridCell383
            // 
            this.xEditGridCell383.CellName = "dv_4";
            this.xEditGridCell383.Col = -1;
            this.xEditGridCell383.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell383, "xEditGridCell383");
            this.xEditGridCell383.IsReadOnly = true;
            this.xEditGridCell383.IsUpdCol = false;
            this.xEditGridCell383.IsVisible = false;
            this.xEditGridCell383.Row = -1;
            // 
            // xEditGridCell384
            // 
            this.xEditGridCell384.CellName = "dv_5";
            this.xEditGridCell384.Col = -1;
            this.xEditGridCell384.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell384, "xEditGridCell384");
            this.xEditGridCell384.IsReadOnly = true;
            this.xEditGridCell384.IsUpdCol = false;
            this.xEditGridCell384.IsVisible = false;
            this.xEditGridCell384.Row = -1;
            // 
            // xEditGridCell385
            // 
            this.xEditGridCell385.CellName = "hubal_change_yn";
            this.xEditGridCell385.CellWidth = 19;
            this.xEditGridCell385.Col = -1;
            this.xEditGridCell385.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell385, "xEditGridCell385");
            this.xEditGridCell385.IsReadOnly = true;
            this.xEditGridCell385.IsUpdCol = false;
            this.xEditGridCell385.IsVisible = false;
            this.xEditGridCell385.Row = -1;
            this.xEditGridCell385.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell386
            // 
            this.xEditGridCell386.CellName = "pharmacy";
            this.xEditGridCell386.CellWidth = 30;
            this.xEditGridCell386.Col = -1;
            this.xEditGridCell386.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell386, "xEditGridCell386");
            this.xEditGridCell386.IsReadOnly = true;
            this.xEditGridCell386.IsUpdCol = false;
            this.xEditGridCell386.IsVisible = false;
            this.xEditGridCell386.Row = -1;
            this.xEditGridCell386.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell387
            // 
            this.xEditGridCell387.CellName = "drg_pack_yn";
            this.xEditGridCell387.CellWidth = 19;
            this.xEditGridCell387.Col = -1;
            this.xEditGridCell387.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell387, "xEditGridCell387");
            this.xEditGridCell387.IsReadOnly = true;
            this.xEditGridCell387.IsUpdCol = false;
            this.xEditGridCell387.IsVisible = false;
            this.xEditGridCell387.Row = -1;
            this.xEditGridCell387.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell388
            // 
            this.xEditGridCell388.CellName = "jusa";
            this.xEditGridCell388.CellWidth = 110;
            this.xEditGridCell388.Col = 7;
            this.xEditGridCell388.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell388, "xEditGridCell388");
            this.xEditGridCell388.IsReadOnly = true;
            this.xEditGridCell388.IsUpdCol = false;
            this.xEditGridCell388.RowSpan = 2;
            // 
            // xEditGridCell389
            // 
            this.xEditGridCell389.CellName = "suname";
            this.xEditGridCell389.CellWidth = 32;
            this.xEditGridCell389.Col = -1;
            this.xEditGridCell389.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell389, "xEditGridCell389");
            this.xEditGridCell389.IsUpdCol = false;
            this.xEditGridCell389.IsVisible = false;
            this.xEditGridCell389.Row = -1;
            // 
            // xEditGridCell390
            // 
            this.xEditGridCell390.CellName = "drg_bunho";
            this.xEditGridCell390.Col = -1;
            this.xEditGridCell390.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell390, "xEditGridCell390");
            this.xEditGridCell390.IsUpdCol = false;
            this.xEditGridCell390.IsVisible = false;
            this.xEditGridCell390.Row = -1;
            // 
            // xEditGridCell391
            // 
            this.xEditGridCell391.CellName = "fkocs2003";
            this.xEditGridCell391.Col = -1;
            this.xEditGridCell391.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell391, "xEditGridCell391");
            this.xEditGridCell391.IsVisible = false;
            this.xEditGridCell391.Row = -1;
            // 
            // xEditGridCell392
            // 
            this.xEditGridCell392.CellName = "append_yn";
            this.xEditGridCell392.CellWidth = 19;
            this.xEditGridCell392.Col = -1;
            this.xEditGridCell392.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell392, "xEditGridCell392");
            this.xEditGridCell392.IsReadOnly = true;
            this.xEditGridCell392.IsUpdatable = false;
            this.xEditGridCell392.IsUpdCol = false;
            this.xEditGridCell392.IsVisible = false;
            this.xEditGridCell392.Row = -1;
            // 
            // xEditGridCell393
            // 
            this.xEditGridCell393.CellName = "re_use_yn";
            this.xEditGridCell393.CellWidth = 24;
            this.xEditGridCell393.Col = -1;
            this.xEditGridCell393.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell393, "xEditGridCell393");
            this.xEditGridCell393.IsVisible = false;
            this.xEditGridCell393.Row = -1;
            // 
            // xEditGridCell394
            // 
            this.xEditGridCell394.CellName = "hope_date";
            this.xEditGridCell394.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell394.Col = -1;
            this.xEditGridCell394.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell394, "xEditGridCell394");
            this.xEditGridCell394.IsUpdCol = false;
            this.xEditGridCell394.IsVisible = false;
            this.xEditGridCell394.Row = -1;
            // 
            // xEditGridCell395
            // 
            this.xEditGridCell395.CellName = "hope_time";
            this.xEditGridCell395.Col = -1;
            this.xEditGridCell395.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell395, "xEditGridCell395");
            this.xEditGridCell395.IsUpdCol = false;
            this.xEditGridCell395.IsVisible = false;
            this.xEditGridCell395.Row = -1;
            // 
            // xEditGridCell396
            // 
            this.xEditGridCell396.CellName = "group_ser";
            this.xEditGridCell396.CellWidth = 24;
            this.xEditGridCell396.Col = 1;
            this.xEditGridCell396.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell396, "xEditGridCell396");
            this.xEditGridCell396.IsReadOnly = true;
            this.xEditGridCell396.IsUpdatable = false;
            this.xEditGridCell396.IsUpdCol = false;
            this.xEditGridCell396.RowSpan = 2;
            this.xEditGridCell396.SuppressRepeating = true;
            // 
            // xEditGridCell397
            // 
            this.xEditGridCell397.CellName = "dc_yn";
            this.xEditGridCell397.Col = -1;
            this.xEditGridCell397.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell397, "xEditGridCell397");
            this.xEditGridCell397.IsUpdCol = false;
            this.xEditGridCell397.IsVisible = false;
            this.xEditGridCell397.Row = -1;
            // 
            // xEditGridCell398
            // 
            this.xEditGridCell398.CellName = "order_gubun";
            this.xEditGridCell398.Col = -1;
            this.xEditGridCell398.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell398, "xEditGridCell398");
            this.xEditGridCell398.IsUpdCol = false;
            this.xEditGridCell398.IsVisible = false;
            this.xEditGridCell398.Row = -1;
            // 
            // xEditGridCell399
            // 
            this.xEditGridCell399.CellName = "if_input_control";
            this.xEditGridCell399.Col = -1;
            this.xEditGridCell399.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell399, "xEditGridCell399");
            this.xEditGridCell399.IsReadOnly = true;
            this.xEditGridCell399.IsUpdatable = false;
            this.xEditGridCell399.IsUpdCol = false;
            this.xEditGridCell399.IsVisible = false;
            this.xEditGridCell399.Row = -1;
            // 
            // xGridHeader6
            // 
            this.xGridHeader6.Col = 4;
            this.xGridHeader6.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader6, "xGridHeader6");
            this.xGridHeader6.HeaderWidth = 20;
            // 
            // xPanel16
            // 
            resources.ApplyResources(this.xPanel16, "xPanel16");
            this.xPanel16.Controls.Add(this.grdPaPrnQuery);
            this.xPanel16.DrawBorder = true;
            this.xPanel16.Name = "xPanel16";
            // 
            // grdPaPrnQuery
            // 
            resources.ApplyResources(this.grdPaPrnQuery, "grdPaPrnQuery");
            this.grdPaPrnQuery.ApplyPaintEventToAllColumn = true;
            this.grdPaPrnQuery.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell400,
            this.xEditGridCell401,
            this.xEditGridCell402,
            this.xEditGridCell403,
            this.xEditGridCell404,
            this.xEditGridCell405,
            this.xEditGridCell406,
            this.xEditGridCell407,
            this.xEditGridCell408,
            this.xEditGridCell411,
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
            this.xEditGridCell423});
            this.grdPaPrnQuery.ColPerLine = 12;
            this.grdPaPrnQuery.Cols = 13;
            this.grdPaPrnQuery.ExecuteQuery = null;
            this.grdPaPrnQuery.FixedCols = 1;
            this.grdPaPrnQuery.FixedRows = 1;
            this.grdPaPrnQuery.HeaderHeights.Add(39);
            this.grdPaPrnQuery.Name = "grdPaPrnQuery";
            this.grdPaPrnQuery.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPaPrnQuery.ParamList")));
            this.grdPaPrnQuery.QuerySQL = resources.GetString("grdPaPrnQuery.QuerySQL");
            this.grdPaPrnQuery.RowHeaderVisible = true;
            this.grdPaPrnQuery.Rows = 2;
            this.grdPaPrnQuery.TabStop = false;
            this.grdPaPrnQuery.ToolTipActive = true;
            this.grdPaPrnQuery.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdPaPrnQuery_ItemValueChanging);
            this.grdPaPrnQuery.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPaPrnQuery_RowFocusChanged);
            this.grdPaPrnQuery.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPaPrnQuery_QueryStarting);
            this.grdPaPrnQuery.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPaPrnQuery_QueryEnd);
            // 
            // xEditGridCell400
            // 
            this.xEditGridCell400.CellName = "bunho";
            this.xEditGridCell400.CellWidth = 70;
            this.xEditGridCell400.Col = 8;
            this.xEditGridCell400.EnableSort = true;
            this.xEditGridCell400.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell400, "xEditGridCell400");
            this.xEditGridCell400.IsReadOnly = true;
            this.xEditGridCell400.SuppressRepeating = true;
            this.xEditGridCell400.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell401
            // 
            this.xEditGridCell401.CellName = "suname";
            this.xEditGridCell401.CellWidth = 93;
            this.xEditGridCell401.Col = 9;
            this.xEditGridCell401.EnableSort = true;
            this.xEditGridCell401.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell401, "xEditGridCell401");
            this.xEditGridCell401.IsReadOnly = true;
            this.xEditGridCell401.SuppressRepeating = true;
            // 
            // xEditGridCell402
            // 
            this.xEditGridCell402.CellName = "sex";
            this.xEditGridCell402.CellWidth = 27;
            this.xEditGridCell402.Col = 11;
            this.xEditGridCell402.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell402, "xEditGridCell402");
            this.xEditGridCell402.IsReadOnly = true;
            this.xEditGridCell402.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell403
            // 
            this.xEditGridCell403.CellName = "age";
            this.xEditGridCell403.CellWidth = 30;
            this.xEditGridCell403.Col = 12;
            this.xEditGridCell403.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell403, "xEditGridCell403");
            this.xEditGridCell403.IsReadOnly = true;
            this.xEditGridCell403.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell404
            // 
            this.xEditGridCell404.CellName = "resident";
            this.xEditGridCell404.Col = -1;
            this.xEditGridCell404.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell404, "xEditGridCell404");
            this.xEditGridCell404.IsReadOnly = true;
            this.xEditGridCell404.IsVisible = false;
            this.xEditGridCell404.Row = -1;
            // 
            // xEditGridCell405
            // 
            this.xEditGridCell405.CellName = "doctor_name";
            this.xEditGridCell405.CellWidth = 85;
            this.xEditGridCell405.Col = 10;
            this.xEditGridCell405.EnableSort = true;
            this.xEditGridCell405.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell405, "xEditGridCell405");
            this.xEditGridCell405.IsReadOnly = true;
            // 
            // xEditGridCell406
            // 
            this.xEditGridCell406.CellName = "magam_yn";
            this.xEditGridCell406.CellWidth = 25;
            this.xEditGridCell406.Col = 1;
            this.xEditGridCell406.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell406.EnableSort = true;
            this.xEditGridCell406.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell406, "xEditGridCell406");
            this.xEditGridCell406.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell407
            // 
            this.xEditGridCell407.CellName = "ho_dong";
            this.xEditGridCell407.CellWidth = 32;
            this.xEditGridCell407.Col = -1;
            this.xEditGridCell407.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell407, "xEditGridCell407");
            this.xEditGridCell407.IsReadOnly = true;
            this.xEditGridCell407.IsUpdatable = false;
            this.xEditGridCell407.IsUpdCol = false;
            this.xEditGridCell407.IsVisible = false;
            this.xEditGridCell407.Row = -1;
            this.xEditGridCell407.SuppressRepeating = true;
            // 
            // xEditGridCell408
            // 
            this.xEditGridCell408.CellName = "ho_dong_name";
            this.xEditGridCell408.CellWidth = 42;
            this.xEditGridCell408.Col = 6;
            this.xEditGridCell408.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell408, "xEditGridCell408");
            this.xEditGridCell408.IsReadOnly = true;
            this.xEditGridCell408.IsUpdCol = false;
            // 
            // xEditGridCell411
            // 
            this.xEditGridCell411.CellName = "ho_code";
            this.xEditGridCell411.CellWidth = 32;
            this.xEditGridCell411.Col = 7;
            this.xEditGridCell411.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell411, "xEditGridCell411");
            this.xEditGridCell411.IsReadOnly = true;
            // 
            // xEditGridCell413
            // 
            this.xEditGridCell413.CellName = "juninp_yn";
            this.xEditGridCell413.CellWidth = 28;
            this.xEditGridCell413.Col = -1;
            this.xEditGridCell413.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell413, "xEditGridCell413");
            this.xEditGridCell413.IsReadOnly = true;
            this.xEditGridCell413.IsUpdatable = false;
            this.xEditGridCell413.IsUpdCol = false;
            this.xEditGridCell413.IsVisible = false;
            this.xEditGridCell413.Row = -1;
            // 
            // xEditGridCell414
            // 
            this.xEditGridCell414.CellName = "hope_date";
            this.xEditGridCell414.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell414.Col = 4;
            this.xEditGridCell414.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell414, "xEditGridCell414");
            this.xEditGridCell414.IsReadOnly = true;
            // 
            // xEditGridCell415
            // 
            this.xEditGridCell415.CellName = "hope_time";
            this.xEditGridCell415.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell415.CellWidth = 35;
            this.xEditGridCell415.Col = -1;
            this.xEditGridCell415.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell415, "xEditGridCell415");
            this.xEditGridCell415.IsReadOnly = true;
            this.xEditGridCell415.IsVisible = false;
            this.xEditGridCell415.Mask = "HH:MI";
            this.xEditGridCell415.Row = -1;
            // 
            // xEditGridCell416
            // 
            this.xEditGridCell416.CellName = "fkinp1001";
            this.xEditGridCell416.Col = -1;
            this.xEditGridCell416.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell416, "xEditGridCell416");
            this.xEditGridCell416.IsReadOnly = true;
            this.xEditGridCell416.IsUpdatable = false;
            this.xEditGridCell416.IsUpdCol = false;
            this.xEditGridCell416.IsVisible = false;
            this.xEditGridCell416.Row = -1;
            // 
            // xEditGridCell417
            // 
            this.xEditGridCell417.CellName = "toiwon_yn";
            this.xEditGridCell417.Col = -1;
            this.xEditGridCell417.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell417, "xEditGridCell417");
            this.xEditGridCell417.IsReadOnly = true;
            this.xEditGridCell417.IsVisible = false;
            this.xEditGridCell417.Row = -1;
            // 
            // xEditGridCell418
            // 
            this.xEditGridCell418.CellName = "gwa";
            this.xEditGridCell418.Col = -1;
            this.xEditGridCell418.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell418, "xEditGridCell418");
            this.xEditGridCell418.IsReadOnly = true;
            this.xEditGridCell418.IsVisible = false;
            this.xEditGridCell418.Row = -1;
            // 
            // xEditGridCell419
            // 
            this.xEditGridCell419.CellName = "order_date";
            this.xEditGridCell419.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell419.Col = 3;
            this.xEditGridCell419.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell419, "xEditGridCell419");
            this.xEditGridCell419.IsReadOnly = true;
            this.xEditGridCell419.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell420
            // 
            this.xEditGridCell420.CellName = "emergency";
            this.xEditGridCell420.Col = -1;
            this.xEditGridCell420.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell420, "xEditGridCell420");
            this.xEditGridCell420.IsReadOnly = true;
            this.xEditGridCell420.IsVisible = false;
            this.xEditGridCell420.Row = -1;
            // 
            // xEditGridCell421
            // 
            this.xEditGridCell421.AlterateRowForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell421.CellName = "magam_gubun";
            this.xEditGridCell421.CellWidth = 30;
            this.xEditGridCell421.Col = 2;
            this.xEditGridCell421.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem28,
            this.xComboItem27});
            this.xEditGridCell421.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell421.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell421.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell421, "xEditGridCell421");
            this.xEditGridCell421.IsReadOnly = true;
            this.xEditGridCell421.RowForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell421.SelectedForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell421.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem28
            // 
            resources.ApplyResources(this.xComboItem28, "xComboItem28");
            this.xComboItem28.ValueItem = "P1";
            // 
            // xComboItem27
            // 
            resources.ApplyResources(this.xComboItem27, "xComboItem27");
            this.xComboItem27.ValueItem = "P2";
            // 
            // xEditGridCell422
            // 
            this.xEditGridCell422.CellName = "jusa_yn";
            this.xEditGridCell422.Col = -1;
            this.xEditGridCell422.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell422, "xEditGridCell422");
            this.xEditGridCell422.IsReadOnly = true;
            this.xEditGridCell422.IsVisible = false;
            this.xEditGridCell422.Row = -1;
            // 
            // xEditGridCell423
            // 
            this.xEditGridCell423.CellName = "jubsu_date";
            this.xEditGridCell423.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell423.Col = 5;
            this.xEditGridCell423.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell423, "xEditGridCell423");
            this.xEditGridCell423.IsReadOnly = true;
            // 
            // xPanel17
            // 
            resources.ApplyResources(this.xPanel17, "xPanel17");
            this.xPanel17.Controls.Add(this.btnPrnPrint);
            this.xPanel17.Controls.Add(this.btnPrnList);
            this.xPanel17.DrawBorder = true;
            this.xPanel17.Name = "xPanel17";
            // 
            // btnPrnPrint
            // 
            resources.ApplyResources(this.btnPrnPrint, "btnPrnPrint");
            this.btnPrnPrint.ImageIndex = 9;
            this.btnPrnPrint.ImageList = this.ImageList;
            this.btnPrnPrint.Name = "btnPrnPrint";
            this.btnPrnPrint.Click += new System.EventHandler(this.btnPrnPrint_Click);
            // 
            // btnPrnList
            // 
            resources.ApplyResources(this.btnPrnList, "btnPrnList");
            this.btnPrnList.IsVisiblePreview = false;
            this.btnPrnList.IsVisibleReset = false;
            this.btnPrnList.Name = "btnPrnList";
            this.btnPrnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnPrnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlBoryu
            // 
            resources.ApplyResources(this.pnlBoryu, "pnlBoryu");
            this.pnlBoryu.Name = "pnlBoryu";
            // 
            // xPanel12
            // 
            resources.ApplyResources(this.xPanel12, "xPanel12");
            this.xPanel12.Name = "xPanel12";
            // 
            // xEditGridCell296
            // 
            this.xEditGridCell296.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell296, "xEditGridCell296");
            // 
            // xEditGridCell297
            // 
            this.xEditGridCell297.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell297, "xEditGridCell297");
            // 
            // xEditGridCell298
            // 
            this.xEditGridCell298.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell298, "xEditGridCell298");
            // 
            // xEditGridCell299
            // 
            this.xEditGridCell299.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell299, "xEditGridCell299");
            // 
            // xEditGridCell300
            // 
            this.xEditGridCell300.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell300, "xEditGridCell300");
            // 
            // xEditGridCell301
            // 
            this.xEditGridCell301.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell301, "xEditGridCell301");
            // 
            // xEditGridCell302
            // 
            this.xEditGridCell302.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell302, "xEditGridCell302");
            // 
            // xEditGridCell303
            // 
            this.xEditGridCell303.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell303, "xEditGridCell303");
            // 
            // xEditGridCell304
            // 
            this.xEditGridCell304.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell304, "xEditGridCell304");
            // 
            // xEditGridCell305
            // 
            this.xEditGridCell305.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell305, "xEditGridCell305");
            // 
            // xEditGridCell306
            // 
            this.xEditGridCell306.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell306, "xEditGridCell306");
            // 
            // xEditGridCell307
            // 
            this.xEditGridCell307.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell307, "xEditGridCell307");
            // 
            // xEditGridCell308
            // 
            this.xEditGridCell308.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell308, "xEditGridCell308");
            // 
            // xEditGridCell309
            // 
            this.xEditGridCell309.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell309, "xEditGridCell309");
            // 
            // xEditGridCell310
            // 
            this.xEditGridCell310.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell310, "xEditGridCell310");
            // 
            // xEditGridCell311
            // 
            this.xEditGridCell311.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell311, "xEditGridCell311");
            // 
            // xEditGridCell312
            // 
            this.xEditGridCell312.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell312, "xEditGridCell312");
            // 
            // xEditGridCell313
            // 
            this.xEditGridCell313.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell313, "xEditGridCell313");
            // 
            // xEditGridCell314
            // 
            this.xEditGridCell314.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell314, "xEditGridCell314");
            // 
            // xEditGridCell324
            // 
            this.xEditGridCell324.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell324, "xEditGridCell324");
            // 
            // xEditGridCell325
            // 
            this.xEditGridCell325.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell325, "xEditGridCell325");
            // 
            // xEditGridCell326
            // 
            this.xEditGridCell326.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell326, "xEditGridCell326");
            // 
            // xEditGridCell327
            // 
            this.xEditGridCell327.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell327, "xEditGridCell327");
            // 
            // xEditGridCell328
            // 
            this.xEditGridCell328.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell328, "xEditGridCell328");
            // 
            // xEditGridCell329
            // 
            this.xEditGridCell329.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell329, "xEditGridCell329");
            // 
            // xEditGridCell330
            // 
            this.xEditGridCell330.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell330, "xEditGridCell330");
            // 
            // xEditGridCell331
            // 
            this.xEditGridCell331.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell331, "xEditGridCell331");
            // 
            // xGridHeader4
            // 
            resources.ApplyResources(this.xGridHeader4, "xGridHeader4");
            // 
            // xEditGridCell269
            // 
            this.xEditGridCell269.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell269, "xEditGridCell269");
            // 
            // xEditGridCell270
            // 
            this.xEditGridCell270.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell270, "xEditGridCell270");
            // 
            // xEditGridCell271
            // 
            this.xEditGridCell271.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell271, "xEditGridCell271");
            // 
            // xEditGridCell272
            // 
            this.xEditGridCell272.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell272, "xEditGridCell272");
            // 
            // xEditGridCell273
            // 
            this.xEditGridCell273.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell273, "xEditGridCell273");
            // 
            // xEditGridCell274
            // 
            this.xEditGridCell274.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell274, "xEditGridCell274");
            // 
            // xEditGridCell275
            // 
            this.xEditGridCell275.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell275, "xEditGridCell275");
            // 
            // xEditGridCell276
            // 
            this.xEditGridCell276.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell276, "xEditGridCell276");
            // 
            // xEditGridCell277
            // 
            this.xEditGridCell277.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell277, "xEditGridCell277");
            // 
            // xEditGridCell278
            // 
            this.xEditGridCell278.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell278, "xEditGridCell278");
            // 
            // xEditGridCell279
            // 
            this.xEditGridCell279.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell279, "xEditGridCell279");
            // 
            // xEditGridCell280
            // 
            this.xEditGridCell280.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell280, "xEditGridCell280");
            // 
            // xEditGridCell281
            // 
            this.xEditGridCell281.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell281, "xEditGridCell281");
            // 
            // xEditGridCell282
            // 
            this.xEditGridCell282.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell282, "xEditGridCell282");
            // 
            // xEditGridCell283
            // 
            this.xEditGridCell283.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell283, "xEditGridCell283");
            // 
            // xEditGridCell284
            // 
            this.xEditGridCell284.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell284, "xEditGridCell284");
            // 
            // xEditGridCell285
            // 
            this.xEditGridCell285.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell285, "xEditGridCell285");
            // 
            // xEditGridCell286
            // 
            this.xEditGridCell286.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell286, "xEditGridCell286");
            // 
            // xEditGridCell287
            // 
            this.xEditGridCell287.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell287, "xEditGridCell287");
            // 
            // xEditGridCell288
            // 
            this.xEditGridCell288.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell288, "xEditGridCell288");
            // 
            // xEditGridCell289
            // 
            this.xEditGridCell289.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell289, "xEditGridCell289");
            // 
            // xEditGridCell290
            // 
            this.xEditGridCell290.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell290, "xEditGridCell290");
            // 
            // xEditGridCell291
            // 
            this.xEditGridCell291.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell291, "xEditGridCell291");
            // 
            // xEditGridCell292
            // 
            this.xEditGridCell292.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell292, "xEditGridCell292");
            // 
            // xEditGridCell293
            // 
            this.xEditGridCell293.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell293, "xEditGridCell293");
            // 
            // xEditGridCell294
            // 
            this.xEditGridCell294.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell294, "xEditGridCell294");
            // 
            // xEditGridCell295
            // 
            this.xEditGridCell295.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell295, "xEditGridCell295");
            // 
            // xGridHeader3
            // 
            resources.ApplyResources(this.xGridHeader3, "xGridHeader3");
            // 
            // xEditGridCell259
            // 
            this.xEditGridCell259.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell259, "xEditGridCell259");
            // 
            // xEditGridCell260
            // 
            this.xEditGridCell260.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell260, "xEditGridCell260");
            // 
            // xEditGridCell261
            // 
            this.xEditGridCell261.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell261, "xEditGridCell261");
            // 
            // xEditGridCell262
            // 
            this.xEditGridCell262.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell262, "xEditGridCell262");
            // 
            // xEditGridCell263
            // 
            this.xEditGridCell263.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell263, "xEditGridCell263");
            // 
            // xEditGridCell264
            // 
            this.xEditGridCell264.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell264, "xEditGridCell264");
            // 
            // xEditGridCell265
            // 
            this.xEditGridCell265.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell265, "xEditGridCell265");
            // 
            // xEditGridCell412
            // 
            this.xEditGridCell412.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell412, "xEditGridCell412");
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            // 
            // xEditGridCell150
            // 
            this.xEditGridCell150.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell150, "xEditGridCell150");
            // 
            // xEditGridCell154
            // 
            this.xEditGridCell154.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell154, "xEditGridCell154");
            // 
            // xEditGridCell268
            // 
            this.xEditGridCell268.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell268, "xEditGridCell268");
            // 
            // xEditGridCell323
            // 
            this.xEditGridCell323.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell323, "xEditGridCell323");
            // 
            // xEditGridCell266
            // 
            this.xEditGridCell266.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell266, "xEditGridCell266");
            // 
            // xEditGridCell267
            // 
            this.xEditGridCell267.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell267, "xEditGridCell267");
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.Name = "xButtonList1";
            // 
            // xEditGridCell165
            // 
            this.xEditGridCell165.CellName = "magam_bunryu";
            this.xEditGridCell165.CellWidth = 55;
            this.xEditGridCell165.Col = 2;
            this.xEditGridCell165.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell165.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell165, "xEditGridCell165");
            this.xEditGridCell165.IsReadOnly = true;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "group_ser";
            this.xEditGridCell19.Col = 19;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMixGroup.Images.SetKeyName(0, "20.gif");
            this.imageListMixGroup.Images.SetKeyName(1, "1.gif");
            this.imageListMixGroup.Images.SetKeyName(2, "2.gif");
            this.imageListMixGroup.Images.SetKeyName(3, "3.gif");
            this.imageListMixGroup.Images.SetKeyName(4, "4.gif");
            this.imageListMixGroup.Images.SetKeyName(5, "5.gif");
            this.imageListMixGroup.Images.SetKeyName(6, "6.gif");
            this.imageListMixGroup.Images.SetKeyName(7, "7.gif");
            this.imageListMixGroup.Images.SetKeyName(8, "8.gif");
            this.imageListMixGroup.Images.SetKeyName(9, "9.gif");
            this.imageListMixGroup.Images.SetKeyName(10, "10.gif");
            this.imageListMixGroup.Images.SetKeyName(11, "11.gif");
            this.imageListMixGroup.Images.SetKeyName(12, "12.gif");
            this.imageListMixGroup.Images.SetKeyName(13, "13.gif");
            this.imageListMixGroup.Images.SetKeyName(14, "14.gif");
            this.imageListMixGroup.Images.SetKeyName(15, "15.gif");
            this.imageListMixGroup.Images.SetKeyName(16, "16.gif");
            this.imageListMixGroup.Images.SetKeyName(17, "17.gif");
            this.imageListMixGroup.Images.SetKeyName(18, "18.gif");
            this.imageListMixGroup.Images.SetKeyName(19, "19.gif");
            // 
            // layOutOrder
            // 
            this.layOutOrder.ExecuteQuery = null;
            this.layOutOrder.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem56});
            this.layOutOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOutOrder.ParamList")));
            this.layOutOrder.QuerySQL = resources.GetString("layOutOrder.QuerySQL");
            this.layOutOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layOutOrder_QueryStarting);
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "outorder";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mlayConstantInfo
            // 
            this.mlayConstantInfo.ExecuteQuery = null;
            this.mlayConstantInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem23,
            this.multiLayoutItem42,
            this.multiLayoutItem43});
            this.mlayConstantInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("mlayConstantInfo.ParamList")));
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "code";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "code_name";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "code_value";
            // 
            // DRG3010P99
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.xPanel1);
            this.Name = "DRG3010P99";
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layMagam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderJungbo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJusaOrderPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJusaLable)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.pnlMiMagam.ResumeLayout(false);
            this.xPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMiMagamOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMiMagamJUSAOrder)).EndInit();
            this.xPanel6.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaQuery)).EndInit();
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList2)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.pnlMagam.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamJUSAOrder)).EndInit();
            this.xPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.xPanel9.ResumeLayout(false);
            this.xPanel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJusaDcOrder)).EndInit();
            this.xPanel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaDcList)).EndInit();
            this.xPanel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnListDc)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.xPanel14.ResumeLayout(false);
            this.xPanel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPrnOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrnJusaOrder)).EndInit();
            this.xPanel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaPrnQuery)).EndInit();
            this.xPanel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPrnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOutOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Common Properties
        private string mHospCode = EnvironInfo.HospCode;

        private int QueryTime;
        private int TimeVal;

        // 自動照会使用可否フラグ
        private string useTimeChkYN = "Y";

        // 患者有AlarmファイルPATH
        private string alarmFilePath_DRG = "";
        private string alarmFilePath_DRG_EM = "";
        private string useAlarmChkYN = "";
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());
            this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate());

            this.dtpJubsuDate.SetDataValue(EnvironInfo.GetSysDate());

            this.cbxBuseo.SelectedIndex = 0;
            this.cbxGubun.SelectedIndex = 0;

            // 実施者に 現在ログインしている IDを セットする｡
            this.cbxActor.SetDataValue(UserInfo.UserID);

            this.tabControl.SelectedIndex = 0;
            this.tabControl.Refresh();

            //if (!grdList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

            //MagamProcess();

            /*
            //btnMagamStart.Enabled = false;
            //btnMagamStop.Enabled = true;

            //dtpBoryuFrom.SetDataValue(EnvironInfo.GetSysDate().AddDays(-7));
            //dtpBoryuTo.SetDataValue(EnvironInfo.GetSysDate());

            //pnlMagam.Visible = true;
            //pnlBoryu.Visible = false;
            */
            this.btnMagamStop_Click(this, new EventArgs());

            //xTabControl1.SelectedIndex = 0;
            //grdPaQuery.QueryLayout(false);
            this.gridQuery();

            // タイマー設定
            this.setTimer();

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {
            string btn_autoQuery_yn = null;
            string btn_autoAlarm_yn = null;

            string chkATC_yn = null;
            string chkJusaLabel = null;

            // 注射画面コントロールデータ照会
            this.mlayConstantInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
                                                 FROM INV0102
                                                WHERE HOSP_CODE = :f_hosp_code
                                                  AND CODE_TYPE = 'DRG_CONSTANT'
                                                ORDER BY CODE";

            this.mlayConstantInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            if (mlayConstantInfo.QueryLayout(true))
            {
                for (int i = 0; i < this.mlayConstantInfo.RowCount; i++)
                {
                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("btn_autoQuery_yn")) btn_autoQuery_yn = this.mlayConstantInfo.GetItemString(i, "code_value");

                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("chkATC_yn")) chkATC_yn = mlayConstantInfo.GetItemString(i, "code_value");

                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("chkJusaLabel")) chkJusaLabel = mlayConstantInfo.GetItemString(i, "code_value");
                }

                for (int i = 0; i < this.mlayConstantInfo.RowCount; i++)
                {
                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("btn_autoAlarm_yn"))
                    {
                        btn_autoAlarm_yn = mlayConstantInfo.GetItemString(i, "code_value");

                        // AlarmファイルPATH取得
                        this.mlayConstantInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
                                                             FROM INV0102
                                                            WHERE HOSP_CODE = 'K01'
                                                              AND CODE_TYPE = 'DRG_ALARM'
                                                            ORDER BY CODE";

                        this.mlayConstantInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

                        if (this.mlayConstantInfo.QueryLayout(true))
                        {
                            for (int k = 0; k < this.mlayConstantInfo.RowCount; k++)
                            {
                                if (this.mlayConstantInfo.GetItemString(k, "code").Equals("DRG")) this.alarmFilePath_DRG = this.mlayConstantInfo.GetItemString(k, "code_value");
                            }
                        }
                    }
                }
            }

            // ボタン設定

            // 自動照会
            if (btn_autoQuery_yn.Equals("Y"))
            {
                this.useTimeChkYN = "Y";
                this.btnUseTimeChk.ImageIndex = 4;

                this.timer1.Start();
                this.cboTime.Enabled = true;
            }
            else
            {
                this.useTimeChkYN = "N";
                this.btnUseTimeChk.ImageIndex = 3;

                this.cboTime.Enabled = false;
                this.timer1.Stop();
            }

            // 患者有Alarm
            if (btn_autoAlarm_yn.Equals("Y"))
            {
                this.useAlarmChkYN = "Y";
                this.btnUseAlarmChk.ImageIndex = 4;
            }
            else
            {
                this.useAlarmChkYN = "N";
                this.btnUseAlarmChk.ImageIndex = 3;
            }

            // ATC自動設定可否
            if (chkATC_yn.Equals("Y"))
            {
                this.cbxATCYN.Checked = true;
            }
            else
            {
                this.cbxATCYN.Checked = false;
            }

            // 注射ラベル印刷可否
            if (chkJusaLabel.Equals("Y"))
            {
                this.cbxJusaLabelYN.Checked = true;
            }
            else
            {
                this.cbxJusaLabelYN.Checked = false;
            }
        }
        #endregion

        #region [btnList_ButtonClick]
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    //this.grdMagamOrder.Reset();
                    //this.grdMagamJUSAOrder.Reset();
                    e.IsBaseCall = false;

                    this.gridQuery();

                    this.QueryTime = this.TimeVal;

                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [MagamProcess]
        private void MagamProcess(XEditGrid aGrd)
        {
            layMagam.Reset();
            if (this.DsvMagam(aGrd))
            {
                if (layMagam.RowCount < 1) return;

                for (int i = 0; i < layMagam.RowCount; i++)
                {
                    string bunho = layMagam.GetItemString(i, "bunho");
                    string fkinp1001 = layMagam.GetItemString(i, "fkinp1001");

                    string jubsu_date = layMagam.GetItemString(i, "jubsu_date");
                    string drg_bunho = layMagam.GetItemString(i, "drg_bunho");
                    string jusa_yn = layMagam.GetItemString(i, "jusa_yn");

                    string magam_gubun = layMagam.GetItemString(i, "magam_gubun");

                    if (drg_bunho != "0")
                    {
                        this.DrgPrint(jubsu_date, drg_bunho, jusa_yn, "", magam_gubun);

                        // ATC装置I/Fデータ転送Process
                        if (magam_gubun != "P1" && this.cbxATCYN.Checked && jusa_yn == "N")
                        {
                            bool value = this.procAtcInterface(jubsu_date, drg_bunho, bunho, fkinp1001);

                            if (value == false)
                            {
                                throw new Exception();
                            }
                        }
                    }
                }

                // Status BAR Not Visible
                this.SetVisibleStatusBar(false);
            }
            else
            {
                if (Service.ErrCode != 0)
                {
                    XMessageBox.Show(Service.ErrMsg, 3);
                }
            }

            if (layMagam.RowCount > 0)
                if (!grdList.QueryLayout(false))
                    XMessageBox.Show(Service.ErrFullMsg);

            this.gridQuery();
        }
        #endregion

        #region [gridQuery TAB別オーダ検索]
        private void gridQuery()
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    this.grdMiMagamJUSAOrder.Reset();
                    this.grdMiMagamOrder.Reset();
                    this.grdPaQuery.QueryLayout(false);
                    break;

                case 1:
                    this.grdMagamJUSAOrder.Reset();
                    this.grdMagamOrder.Reset();
                    this.grdList.QueryLayout(false);
                    break;

                case 2:
                    this.grdDcOrder.Reset();
                    this.grdJusaDcOrder.Reset();
                    this.grdPaDcList.QueryLayout(false);
                    break;

                case 3:
                    this.grdPrnOrder.Reset();
                    this.grdPrnJusaOrder.Reset();
                    this.grdPaPrnQuery.QueryLayout(false);
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region [-- DsvMagam --]
        /// <summary>
        /// dsvMagam Service Conversion PC:DRG3010P99, WT:3, OUTPUT:layMagam
        /// </summary>
        /// <returns></returns>
        private bool DsvMagam(XEditGrid aGrd)
        {
            if (aGrd == null) return false;

            //string cmdText = "";
            //BindVarCollection bindVars = new BindVarCollection();
            //bindVars.Add("f_hope_date", dtpMagamDate.GetDataValue());
            //bindVars.Add("f_magam_gubun", cbxGubun.GetDataValue());
            //bindVars.Add("f_hosp_code", mHospCode);
            //DataTable resTable = new DataTable();

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            int rowNum = 0;
            int chkRow = 0;

            string magam_ser = "0";

            string o_drg_bunho = string.Empty;
            string o_bunho = string.Empty;
            string o_gwa = string.Empty;
            string o_doctor = string.Empty;
            string o_magam_gubun = string.Empty;
            string o_jusa_yn = string.Empty;
            string o_io_err = string.Empty;
            string o_hope_date = string.Empty;
            string o_jubsu_date = string.Empty;
            string o_order_date = string.Empty;

            int procCnt = 0;
            for (int i = 0; i < aGrd.RowCount; i++)
            {
                if (aGrd.GetItemString(i, "magam_yn") == "Y") procCnt++;
            }

            if (procCnt > 0)
            {
                this.InitStatusBar(procCnt);
                this.SetVisibleStatusBar(true);
            }

            for (int i = 0; i < aGrd.RowCount; i++)
            {
                if (aGrd.GetItemString(i, "magam_yn") != "Y")
                    continue;

                if (aGrd.GetItemString(i, "magam_gubun") == "")
                {
                    XMessageBox.Show(Resources.XMessageBox1, Resources.XMessageBox_caption1, MessageBoxIcon.Warning);
                    return false;
                }

                chkRow++;

                this.SetStatusBar(chkRow);
                aGrd.SetFocusToItem(i, 1);

                o_bunho = aGrd.GetItemString(i, "bunho");
                o_gwa = aGrd.GetItemString(i, "gwa");
                o_doctor = aGrd.GetItemString(i, "resident");
                o_magam_gubun = aGrd.GetItemString(i, "magam_gubun");
                o_jusa_yn = aGrd.GetItemString(i, "jusa_yn");
                o_hope_date = aGrd.GetItemString(i, "hope_date");
                o_jubsu_date = this.dtpJubsuDate.GetDataValue();//aGrd.GetItemString(i, "jubsu_date");
                o_order_date = aGrd.GetItemString(i, "order_date");

                #region [PR_DRG_LOAD_BONGTU_SER]
                if (magam_ser == "0")
                {
                    inputList.Clear();
                    outputList.Clear();

                    inputList.Add(o_jubsu_date);
                    inputList.Add(o_magam_gubun);
                    inputList.Add("%");
                    inputList.Add("PA");
                    inputList.Add(this.cbxActor.GetDataValue());
                    if (Service.ExecuteProcedure("PR_DRG_LOAD_BONGTU_SER", inputList, outputList))
                    {
                        magam_ser = outputList[0].ToString();
                    }
                }
                #endregion [END PR_DRG_LOAD_BONGTU_SER]

                if (o_magam_gubun == "ER") // 긴급
                {
                    inputList.Clear();
                    outputList.Clear();

                    inputList.Add(o_jubsu_date);
                    inputList.Add(o_bunho);
                    inputList.Add(o_hope_date);
                    inputList.Add(aGrd.GetItemString(i, "hope_time"));
                    inputList.Add(o_gwa);
                    inputList.Add(o_doctor);
                    inputList.Add(o_jusa_yn);
                    inputList.Add("PA");
                    inputList.Add(this.cbxActor.GetDataValue());

                    if (Service.ExecuteProcedure("PR_DRG_MAKE_BONGTU_INP_ER", inputList, outputList))
                    {
                        o_drg_bunho = outputList[0].ToString();
                    }
                    else
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                        return false;
                    }
                }
                else
                {
                    inputList.Clear();
                    outputList.Clear();

                    inputList.Add(EnvironInfo.CurrSystemID);
                    inputList.Add(o_jubsu_date);
                    inputList.Add(o_order_date);
                    inputList.Add(o_hope_date);
                    inputList.Add(o_magam_gubun);
                    inputList.Add(magam_ser);
                    inputList.Add(o_bunho);
                    inputList.Add(o_doctor);
                    inputList.Add(this.cbxActor.GetDataValue());

                    if (Service.ExecuteProcedure("PR_DRG_INP_MAGAM_PROC", inputList, outputList))
                    {
                        o_drg_bunho = outputList[0].ToString();
                    }
                    else
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                        return false;
                    }
                }

                #region [OLD VERSION]
                //else if (o_magam_gubun == "21" || o_magam_gubun == "P1") // 약 임시 指示薬臨時
                //{
                //    //XMessageBox.Show("약 임시 : " + resTable.Rows[i]["bunho"].ToString());
                //    if (magam_ser_21 == "0")
                //    {
                //        /* dsvLoadMagamSer PC: DRG3010p10 WT: 3 */
                //        inputList.Clear();
                //        outputList.Clear();

                //        inputList.Add(o_jubsu_date);
                //        inputList.Add(o_magam_gubun);
                //        inputList.Add("%");
                //        inputList.Add("PA");
                //        inputList.Add(this.cbxActor.GetDataValue());
                //        if (Service.ExecuteProcedure("PR_DRG_LOAD_BONGTU_SER", inputList, outputList))  
                //        {
                //            magam_ser_21 = outputList[0].ToString();
                //            magam_ser = magam_ser_21;
                //            //o_drg_bunho = outputList[
                //        }
                //    }

                //    /* dsvMagam */
                //    inputList.Clear();
                //    outputList.Clear();

                //    inputList.Add(o_jubsu_date);
                //    inputList.Add(o_hope_date);
                //    inputList.Add(aGrd.GetItemString(i, "hope_time"));
                //    inputList.Add(o_magam_gubun);
                //    inputList.Add(magam_ser);
                //    inputList.Add(o_bunho);
                //    inputList.Add(aGrd.GetItemString(i, "ho_dong"));
                //    inputList.Add(o_gwa);
                //    inputList.Add(o_doctor);
                //    inputList.Add(this.cbxActor.GetDataValue());

                //    // sleep
                //    System.Threading.Thread.Sleep(1);

                //    //마감
                //    if (Service.ExecuteProcedure("PR_DRG_MAKE_BONGTU_INP_NEW", inputList, outputList))
                //    {
                //        if (outputList[0].ToString() != "0")
                //        {
                //            //복약지도 전달
                //            //AtcSend(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), outputList[0].ToString());
                //            //처방전 출력
                //            //DrgPrint(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), outputList[0].ToString(), o_magam_gubun, "");
                //            o_drg_bunho = outputList[0].ToString();
                //        }
                //    }
                //    else
                //    {
                //        XMessageBox.Show(Service.ErrFullMsg);
                //        //XMessageBox.Show(outputList[1].ToString(), 2);
                //    }
                //}
                //else if (o_magam_gubun == "22" || o_magam_gubun == "P2") // 주사 임시 指示注射臨時
                //{
                //    //XMessageBox.Show("주사 임시 : " + resTable.Rows[i]["bunho"].ToString());

                //    magam_ser = "0";

                //    /* dsvLoadMagamSer */
                //    inputList.Clear();
                //    outputList.Clear();

                //    inputList.Add(o_jubsu_date);
                //    inputList.Add(o_magam_gubun);  // 주사약 마감구분은 임시마감으로 셋팅
                //    inputList.Add("%");
                //    inputList.Add("PA");
                //    inputList.Add(this.cbxActor.GetDataValue());
                //    if (Service.ExecuteProcedure("PR_DRG_LOAD_BONGTU_SER", inputList, outputList))
                //    {
                //        magam_ser = outputList[0].ToString();
                //    }

                //    inputList.Clear();
                //    outputList.Clear();

                //    inputList.Add(o_jubsu_date);
                //    inputList.Add(o_order_date);
                //    inputList.Add(o_hope_date);
                //    inputList.Add(aGrd.GetItemString(i,"hope_time"));
                //    inputList.Add(o_magam_gubun);
                //    inputList.Add(magam_ser);
                //    inputList.Add("PA");
                //    inputList.Add(o_bunho);
                //    inputList.Add(aGrd.GetItemString(i, "ho_dong"));
                //    inputList.Add(o_doctor);
                //    inputList.Add(this.cbxActor.GetDataValue());

                //    //마감
                //    if (Service.ExecuteProcedure("PR_DRG_MAGAM_INJ_NEW", inputList, outputList))
                //    {
                //        o_drg_bunho = outputList[0].ToString();
                //    }
                    
                //}
                //else if (o_magam_gubun == "31") // 약 퇴원
                //{
                //    magam_ser = "0";

                //    inputList.Clear();
                //    outputList.Clear();

                //    inputList.Add(o_jubsu_date);
                //    inputList.Add(o_magam_gubun);
                //    inputList.Add("%");
                //    inputList.Add("PA");
                //    inputList.Add(this.cbxActor.GetDataValue());
                //    if (Service.ExecuteProcedure("PR_DRG_LOAD_BONGTU_SER", inputList, outputList))
                //    {
                //        magam_ser = outputList[0].ToString();
                //    }

                //    inputList.Clear();
                //    outputList.Clear();

                //    inputList.Add(o_jubsu_date);
                //    inputList.Add(o_bunho);
                //    inputList.Add(o_hope_date);
                //    inputList.Add(aGrd.GetItemString(i, "hope_time"));
                //    inputList.Add(o_magam_gubun);
                //    inputList.Add(magam_ser);
                //    inputList.Add(o_gwa);
                //    inputList.Add(o_doctor);
                //    inputList.Add(o_jusa_yn);
                //    inputList.Add(this.cbxActor.GetDataValue());

                //    if (Service.ExecuteProcedure("PR_DRG_MAKE_BONGTU_INP_TOIWON", inputList, outputList))
                //    {
                //        o_drg_bunho = outputList[0].ToString();
                //    }
                //    else
                //    {
                //        XMessageBox.Show(Service.ErrFullMsg);
                //        return false;
                //    }
                //}
                //else if (o_magam_gubun == "32") // 주사 퇴원
                //{
                //    magam_ser = "0";

                //    inputList.Clear();
                //    outputList.Clear();

                //    inputList.Add(o_jubsu_date);
                //    inputList.Add(o_magam_gubun);
                //    inputList.Add("%");
                //    inputList.Add("PA");
                //    inputList.Add(this.cbxActor.GetDataValue());
                //    if (Service.ExecuteProcedure("PR_DRG_LOAD_BONGTU_SER", inputList, outputList))
                //    {
                //        magam_ser = outputList[0].ToString();
                //    }

                //    inputList.Clear();
                //    outputList.Clear();

                //    inputList.Add(o_jubsu_date);
                //    inputList.Add(o_bunho);
                //    inputList.Add(o_hope_date);
                //    inputList.Add(aGrd.GetItemString(i, "hope_time"));
                //    inputList.Add(o_magam_gubun);
                //    inputList.Add(magam_ser);
                //    inputList.Add(o_gwa);
                //    inputList.Add(o_doctor);
                //    inputList.Add(o_jusa_yn);
                //    inputList.Add(this.cbxActor.GetDataValue());

                //    if (Service.ExecuteProcedure("PR_DRG_MAKE_BONGTU_INP_TOIWON", inputList, outputList))
                //    {
                //        o_drg_bunho = outputList[0].ToString();
                //    }
                //    else
                //    {
                //        XMessageBox.Show(Service.ErrFullMsg);
                //        return false;
                //    }
                //}
                #endregion [OLD VERSION]

                rowNum = layMagam.InsertRow(-1);

                layMagam.SetItemValue(rowNum, "bunho", o_bunho);
                layMagam.SetItemValue(rowNum, "fkinp1001", aGrd.GetItemString(i, "fkinp1001"));

                layMagam.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                layMagam.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                layMagam.SetItemValue(rowNum, "magam_gubun", o_magam_gubun);
                layMagam.SetItemValue(rowNum, "jusa_yn", o_jusa_yn);
            }
            return true;
        }
        #endregion

        #region [-- DsvOrderPrint --]
        /// <summary>
        /// dsvOrderPrint Service Conversion PC: DRGPRINT, WT: E, OUTPUT:layOrderPrint
        /// </summary>
        /// <param name="jubsuDate"></param>
        /// <param name="drgBunho"></param>
        /// <param name="printGubun"></param>
        /// <returns></returns>
        private bool DsvOrderPrint(string jubsuDate, string drgBunho, string printGubun)
        {
            layOrderPrint.Reset();

            string o_bunho = string.Empty;
            string o_drg_bunho = string.Empty;
            string o_naewon_date = string.Empty;
            string o_group_ser = string.Empty;
            string o_jubsu_date = string.Empty;
            string o_order_date = string.Empty;
            string o_jaeryo_code = string.Empty;
            string o_divide = string.Empty;
            string o_ord_suryang = string.Empty;
            string o_order_suryang = string.Empty;
            string o_order_danui = string.Empty;
            string o_subul_danui = string.Empty;
            string o_group_yn = string.Empty;
            string o_jaeryo_gubun = string.Empty;
            string o_bogyong_code = string.Empty;
            string o_bogyong_name = string.Empty;
            string o_caution_name = string.Empty;
            string o_caution_code = string.Empty;
            string o_mix_yn = string.Empty;
            string o_atc_yn = string.Empty;
            string o_dv = string.Empty;
            string o_dv_time = string.Empty;
            string o_dc_yn = string.Empty;
            string o_bannab_yn = string.Empty;
            string o_source_fkocs2003 = string.Empty;
            string o_fkocs2003 = string.Empty;
            string o_sunab_date = string.Empty;
            string o_pattern = string.Empty;
            string o_jaeryo_name = string.Empty;
            string o_sunab_nalsu = string.Empty;
            string o_wonyoi_yn = string.Empty;
            string o_order_remark = string.Empty;
            string o_act_date = string.Empty;
            string o_mayak = string.Empty;
            string o_tpn_joje_gubun = string.Empty;
            string o_ui_jusa_yn = string.Empty;
            string o_subul_suryang = string.Empty;
            string o_serial_v = string.Empty;
            string o_gwa_name = string.Empty;
            string o_doctor_name = string.Empty;
            string o_suname = string.Empty;
            string o_suname2 = string.Empty;
            string o_birth = string.Empty;
            string o_age_sex = string.Empty;
            string o_other_gwa = string.Empty;
            string o_do_order = string.Empty;
            string o_gubun_name = string.Empty;
            string o_hope_date = string.Empty;
            string o_powder_yn = string.Empty;
            string o_line = string.Empty;
            string o_kyukyeok = string.Empty;
            string o_ho_dong = string.Empty;
            string o_ho_code = string.Empty;
            string o_title = string.Empty;
            string o_licenes = string.Empty;
            string o_bunryu1 = string.Empty;
            string o_donbok = string.Empty;
            string o_tusuk = string.Empty;
            string o_jusa = string.Empty;
            string o_magam_gubun = string.Empty;
            string o_text_color = string.Empty;
            string o_changgo = string.Empty;
            string o_from_order_date = string.Empty;
            string o_to_order_date = string.Empty;
            string o_order_date_text = string.Empty;
            string o_serial_text = string.Empty;
            string o_sex_age = string.Empty;
            string o_rp_barcode = string.Empty;
            string o_ord_danui2 = string.Empty;
            string o_data_gubun = string.Empty;
            string o_print_gubun = string.Empty;
            string o_hodong_ord_name = string.Empty;
            string o_nalsu = string.Empty;
            string o_max_bannab_yn = string.Empty;

            int rowNum;

            string cmdText = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();
            DataTable resTable = new DataTable();
            DataTable dtSerial = new DataTable();
            DataTable dtRemark = new DataTable();
            DataTable dtBannab = new DataTable();

            /* 재출력, 보류 체크 */
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            inputList.Add(jubsuDate);
            inputList.Add(drgBunho);
            inputList.Add(printGubun);
            if (Service.ExecuteProcedure("PR_DRG_LOAD_PRINT_GUBUN", inputList, outputList))
            {
                o_print_gubun = outputList[0].ToString();
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return false;
            }

            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

            /* DRGPRINT_I_ORD_PRN_CUR */
            cmdText = @"SELECT DISTINCT
                               A.BUNHO                                             BUNHO
                              ,LTRIM(TO_CHAR(A.DRG_BUNHO))                         DRG_BUNHO
                              ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE )    ORDER_DATE_TEXT
                              ,A.JUBSU_DATE                                        JUBSU_DATE
                              ,A.ORDER_DATE                                        ORDER_DATE
                              ,'Rp.'||E.SERIAL_V||DECODE(A.MIX_GROUP,NULL,'',' M') SERIAL_V
                              ,E.SERIAL_V                                          SERIAL_TEXT
                              ,FN_BAS_LOAD_GWA_NAME(F.GWA, A.JUBSU_DATE)           GWA_NAME
                              ,FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE)   DOCTOR_NAME
                              ,D.SUNAME                                            SUNAME
                              ,D.SUNAME2                                           SUNAME2
                              ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.BIRTH)          BIRTH
                              ,FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE)          SEX_AGE
                              ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'C'),1,20)      HO_CODE
                              ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)      HO_DONG                    
                              ,DECODE(A.TOIWON_DRG_YN, '1', 'OT', A.MAGAM_GUBUN)                   MAGAM_GUBUN
                              ,TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || TO_CHAR(A.DRG_BUNHO) || TO_CHAR(E.SERIAL_V)   RP_BARCODE
                          FROM INP1001 F
                              ,DRG2035 E
                              ,OUT0101 D
                              ,DRG0120 C
                              ,INV0110 B
                              ,DRG3010 A
                         WHERE A.JUBSU_DATE         = :f_jubsu_date
                           AND A.HOSP_CODE          = :f_hosp_code
                           AND A.DRG_BUNHO          = :f_drg_bunho
                           AND A.BUNRYU1            <> '4'
                           --AND NVL(A.DC_YN,'N')     = 'N'
                           --AND NVL(A.BANNAB_YN,'N') = 'N'
                           AND B.HOSP_CODE          = A.HOSP_CODE
                           AND B.JAERYO_CODE        = A.JAERYO_CODE
                           AND C.HOSP_CODE       (+)= A.HOSP_CODE
                           AND C.BOGYONG_CODE    (+)= A.BOGYONG_CODE
                           AND D.HOSP_CODE          = A.HOSP_CODE
                           AND D.BUNHO              = A.BUNHO
                           AND E.HOSP_CODE          = A.HOSP_CODE
                           AND E.JUBSU_DATE         = A.JUBSU_DATE
                           AND E.DRG_BUNHO          = A.DRG_BUNHO
                           AND E.FKOCS2003          = A.FKOCS2003
                           AND F.HOSP_CODE          = A.HOSP_CODE
                           AND F.PKINP1001          = A.FKINP1001
                         ORDER BY TO_NUMBER(E.SERIAL_V)";
            try
            {
                resTable = Service.ExecuteDataTable(cmdText, bindVars);
                /* DRGPRINT_I_ORD_PRN_CUR */
                for (int i = 0; i < resTable.Rows.Count; i++)
                {
                    o_bunho = resTable.Rows[i]["bunho"].ToString();
                    o_drg_bunho = resTable.Rows[i]["drg_bunho"].ToString();
                    o_order_date_text = resTable.Rows[i]["order_date_text"].ToString();
                    o_jubsu_date = resTable.Rows[i]["jubsu_date"].ToString();
                    o_order_date = resTable.Rows[i]["order_date"].ToString();
                    o_serial_v = resTable.Rows[i]["serial_v"].ToString();
                    o_serial_text = resTable.Rows[i]["serial_text"].ToString();
                    o_gwa_name = resTable.Rows[i]["gwa_name"].ToString();
                    o_doctor_name = resTable.Rows[i]["doctor_name"].ToString();
                    o_suname = resTable.Rows[i]["suname"].ToString();
                    o_suname2 = resTable.Rows[i]["suname2"].ToString();
                    o_birth = resTable.Rows[i]["birth"].ToString();
                    o_sex_age = resTable.Rows[i]["sex_age"].ToString();
                    o_ho_code = resTable.Rows[i]["ho_code"].ToString();
                    o_ho_dong = resTable.Rows[i]["ho_dong"].ToString();
                    o_magam_gubun = resTable.Rows[i]["magam_gubun"].ToString();
                    o_rp_barcode = resTable.Rows[i]["rp_barcode"].ToString();

                    //
                    bindVars.Remove("f_serial_text");
                    bindVars.Add("f_serial_text", o_serial_text);
                    bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

                    /* DRGPRINT_I_ORD_PRN_SERIAL */
                    cmdText = @"SELECT DISTINCT
                                       A.BUNHO                                                                                 BUNHO
                                      ,A.DRG_BUNHO                                                                             DRG_BUNHO
                                      ,A.GROUP_SER                                                                             GROUP_SER
                                      ,TO_CHAR(A.JUBSU_DATE,'YYYY/MM/DD')                                                                            JUBSU_DATE
                                      ,TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD')                                                                            ORDER_DATE
                                      ,A.JAERYO_CODE                                                                           JAERYO_CODE
                                      ,A.NALSU * DECODE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) , 'Y', A.DIVIDE, 1)              NALSU
                                      ,A.DIVIDE                                                                                DIVIDE
                                      ,A.ORD_SURYANG                                                                           ORD_SURYANG
                                      ,DECODE(A.BUNRYU1, '4', A.ORD_SURYANG, A.ORDER_SURYANG )                                 ORDER_SURYANG
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI)                                         ORDER_DANUI
                                      ,A.SUBUL_DANUI                                                                           SUBUL_DANUI
                                      ,A.BOGYONG_CODE                                                                          BOGYONG_CODE
                                      ,TRIM(B.BOGYONG_NAME) || FN_DRG_LOAD_RP_TEXT('I', E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V)||
                                        DECODE(NVL(G.DV_1,0) + NVL(G.DV_2,0) + NVL(G.DV_3,0) + NVL(G.DV_4,0) + NVL(G.DV_5,0) 
                                      , 0,  NULL, '('||LTRIM(TO_CHAR(NVL(G.DV_1,0))) || '-' ||LTRIM(TO_CHAR(NVL(G.DV_2,0))) ||  '-' ||
                                  LTRIM(TO_CHAR(NVL(G.DV_3,0))) || '-' ||LTRIM(TO_CHAR(NVL(G.DV_4,0))) ||  '-' ||
                                  LTRIM(TO_CHAR(NVL(G.DV_5,0)))|| ')' )   BOGYONG_NAME
                                      ,SUBSTRB(FN_DRG_LOAD_CAUTION_NM(E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O' ) ,1,80)      CAUTION_NAME
                                      ,A.MIX_YN                                                                                MIX_YN
                                      ,A.ATC_YN                                                                                ATC_YN
                                      ,D.DV                                                                                    DV
                                      ,A.DV_TIME                                                                               DV_TIME
                                      ,D.DC_YN                                                                                 DC_YN
                                      ,D.BANNAB_YN                                                                             BANNAB_YN
                                      ,D.SOURCE_FKOCS2003                                                                      SOURCE_FKOCS2003
                                      ,A.FKOCS2003                                                                             FKOCS2003
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                                          SUNAB_DATE
                                      ,B.PATTERN                                                                               PATTERN
                                      ,F.HANGMOG_NAME                                                                          JAERYO_NAME
                                      ,0                                                                                       SUNAB_NALSU
                                      ,NVL(D.WONYOI_ORDER_YN,'N')                                                              WONYOI_YN
                                      ,F.HANGMOG_NAME || ' : ' ||  TRIM(D.ORDER_REMARK)                                        ORDER_REMARK
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                    ACT_DATE
                                      ,NVL(C.MIX_YN_INP,'N')                                                                   UI_JUSA_YN
                                      ,A.SUBUL_SURYANG                                                                         SUBUL_SURYANG
                                      ,'Rp.'||LTRIM(TO_CHAR(TO_NUMBER(E.SERIAL_V),'00'))||DECODE(G.MIX_GROUP,NULL,'',' M')     SERIAL_V
                                      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.JUBSU_DATE)                                               GWA_NAME
                                      ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.JUBSU_DATE)                                         DOCTOR_NAME
                                      ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA)                             OTHER_GWA
                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE )                                         HOPE_DATE
                                      ,FN_DRG_POWDER_YN(A.JUBSU_DATE, A.DRG_BUNHO, 'I')                                        POWDER_YN
                                      ,NVL(E.SERIAL_V, 1)                                                                      LINE
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI)                                       ORD_DANUI2
                                      ,SUBSTRB(TRIM(A.BUNRYU1),1,1)                                                            BUNRYU1
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)                          HO_DONG
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'C'),1,20)                          HO_CODE              
                                      ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                                   DONBOK
                                      ,''                                                                                      TUSUK
                                      ,DECODE(G.TOIWON_DRG_YN, '1', 'OT', G.MAGAM_GUBUN)                                       MAGAM_GUBUN
                                      ,C.TEXT_COLOR                                                                            TEXT_COLOR
                                      ,C.CHANGGO1                                                                              CHANGGO
                                      ,'( ' || TO_CHAR(NVL(D.HOPE_DATE, D.ORDER_DATE),'MM/DD')                                 FROM_ORDER_DATE
                                      ,TO_CHAR(NVL(D.HOPE_DATE, D.ORDER_DATE)+ A.NALSU - 1, 'MM/DD') || ' )'                   TO_ORDER_DATE
                                      ,'A'                                                                                     DATA_GUBUN
                                      ,NVL(C.ACT_JAERYO_NAME,F.HANGMOG_NAME)                                                   HODONG_ORD_NAME
                                      ,(SELECT MAX(NVL(X.BANNAB_YN,'N'))
                                          FROM DRG3010 X
                                             , DRG2035 Y
                                         WHERE Y.JUBSU_DATE = E.JUBSU_DATE
                                           AND Y.HOSP_CODE  = :f_hosp_code
                                           AND Y.DRG_BUNHO  = E.DRG_BUNHO
                                           AND Y.SERIAL_V   = E.SERIAL_V
                                           AND Y.FKOCS2003  = X.FKOCS2003
                                           AND X.FKOCS2003  = E.FKOCS2003
                                           AND X.HOSP_CODE  = Y.HOSP_CODE
                                           )                                                     MAX_BANNAB_YN
                                  FROM OCS0103 F
                                      ,DRG2035 E
                                      ,OCS2003 D
                                      ,INV0110 C
                                      ,DRG0120 B
                                      ,DRG3011 A
                                      ,DRG3010 G
                                 WHERE A.JUBSU_DATE       = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                                   AND A.HOSP_CODE        = :f_hosp_code
                                   AND A.DRG_BUNHO        = :f_drg_bunho
                                   AND B.HOSP_CODE     (+)= A.HOSP_CODE
                                   AND B.BOGYONG_CODE  (+)= A.BOGYONG_CODE
                                   AND C.HOSP_CODE        = A.HOSP_CODE
                                   AND C.JAERYO_CODE      = A.JAERYO_CODE
                                   AND D.HOSP_CODE        = A.HOSP_CODE
                                   AND D.PKOCS2003        = A.FKOCS2003
                                   AND G.HOSP_CODE        = A.HOSP_CODE
                                   AND G.FKOCS2003        = A.FKOCS2003
                                   AND E.HOSP_CODE        = A.HOSP_CODE
                                   AND E.JUBSU_DATE       = A.JUBSU_DATE
                                   AND E.DRG_BUNHO        = A.DRG_BUNHO
                                   AND E.FKOCS2003        = A.FKOCS2003
                                   AND E.SERIAL_V         = :f_serial_text
                                   AND F.HOSP_CODE        = D.HOSP_CODE
                                   AND F.HANGMOG_CODE     = D.HANGMOG_CODE
                                 ORDER BY A.DRG_BUNHO, 'Rp.'||LTRIM(TO_CHAR(TO_NUMBER(E.SERIAL_V),'00'))||DECODE(G.MIX_GROUP,NULL,'',' M'), A.FKOCS2003";

                    dtSerial = Service.ExecuteDataTable(cmdText, bindVars);
                    for (int j = 0; j < dtSerial.Rows.Count; j++)
                    {
                        o_bunho = dtSerial.Rows[j]["bunho"].ToString();
                        o_drg_bunho = dtSerial.Rows[j]["drg_bunho"].ToString();
                        o_group_ser = dtSerial.Rows[j]["group_ser"].ToString();
                        o_jubsu_date = dtSerial.Rows[j]["jubsu_date"].ToString();
                        o_order_date = dtSerial.Rows[j]["order_date"].ToString();
                        o_jaeryo_code = dtSerial.Rows[j]["jaeryo_code"].ToString();
                        o_nalsu = dtSerial.Rows[j]["nalsu"].ToString();
                        o_divide = dtSerial.Rows[j]["divide"].ToString();
                        o_ord_suryang = dtSerial.Rows[j]["ord_suryang"].ToString();
                        o_order_suryang = dtSerial.Rows[j]["order_suryang"].ToString();
                        o_order_danui = dtSerial.Rows[j]["order_danui"].ToString();
                        o_subul_danui = dtSerial.Rows[j]["subul_danui"].ToString();
                        o_bogyong_code = dtSerial.Rows[j]["bogyong_code"].ToString();
                        o_bogyong_name = dtSerial.Rows[j]["bogyong_name"].ToString();
                        o_caution_name = dtSerial.Rows[j]["caution_name"].ToString();
                        o_mix_yn = dtSerial.Rows[j]["mix_yn"].ToString();
                        o_atc_yn = dtSerial.Rows[j]["atc_yn"].ToString();
                        o_dv = dtSerial.Rows[j]["dv"].ToString();
                        o_dv_time = dtSerial.Rows[j]["dv_time"].ToString();
                        o_dc_yn = dtSerial.Rows[j]["dc_yn"].ToString();
                        o_bannab_yn = dtSerial.Rows[j]["bannab_yn"].ToString();
                        o_source_fkocs2003 = dtSerial.Rows[j]["source_fkocs2003"].ToString();
                        o_fkocs2003 = dtSerial.Rows[j]["fkocs2003"].ToString();
                        o_sunab_date = dtSerial.Rows[j]["sunab_date"].ToString();
                        o_pattern = dtSerial.Rows[j]["pattern"].ToString();
                        o_jaeryo_name = dtSerial.Rows[j]["jaeryo_name"].ToString();
                        o_sunab_nalsu = dtSerial.Rows[j]["sunab_nalsu"].ToString();
                        o_wonyoi_yn = dtSerial.Rows[j]["wonyoi_yn"].ToString();
                        o_order_remark = dtSerial.Rows[j]["order_remark"].ToString();
                        o_act_date = dtSerial.Rows[j]["act_date"].ToString();
                        o_ui_jusa_yn = dtSerial.Rows[j]["ui_jusa_yn"].ToString();
                        o_subul_suryang = dtSerial.Rows[j]["subul_suryang"].ToString();
                        o_serial_v = dtSerial.Rows[j]["serial_v"].ToString();
                        o_gwa_name = dtSerial.Rows[j]["gwa_name"].ToString();
                        o_doctor_name = dtSerial.Rows[j]["doctor_name"].ToString();
                        o_other_gwa = dtSerial.Rows[j]["other_gwa"].ToString();
                        o_hope_date = dtSerial.Rows[j]["hope_date"].ToString();
                        o_powder_yn = dtSerial.Rows[j]["powder_yn"].ToString();
                        o_line = dtSerial.Rows[j]["line"].ToString();
                        o_ord_danui2 = dtSerial.Rows[j]["ord_danui2"].ToString();
                        o_bunryu1 = dtSerial.Rows[j]["bunryu1"].ToString();
                        o_ho_dong = dtSerial.Rows[j]["ho_dong"].ToString();
                        o_ho_code = dtSerial.Rows[j]["ho_code"].ToString();
                        o_donbok = dtSerial.Rows[j]["donbok"].ToString();
                        o_tusuk = dtSerial.Rows[j]["tusuk"].ToString();
                        o_magam_gubun = dtSerial.Rows[j]["magam_gubun"].ToString();
                        o_text_color = dtSerial.Rows[j]["text_color"].ToString();
                        o_changgo = dtSerial.Rows[j]["changgo"].ToString();
                        o_from_order_date = dtSerial.Rows[j]["from_order_date"].ToString();
                        o_to_order_date = dtSerial.Rows[j]["to_order_date"].ToString();
                        o_data_gubun = dtSerial.Rows[j]["data_gubun"].ToString();
                        o_hodong_ord_name = dtSerial.Rows[j]["hodong_ord_name"].ToString();
                        o_max_bannab_yn = dtSerial.Rows[j]["max_bannab_yn"].ToString();

                        rowNum = layOrderPrint.InsertRow(-1);

                        layOrderPrint.SetItemValue(rowNum, "bunho", o_bunho);
                        layOrderPrint.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                        layOrderPrint.SetItemValue(rowNum, "naewon_date", o_naewon_date);
                        layOrderPrint.SetItemValue(rowNum, "group_ser", o_group_ser);
                        layOrderPrint.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                        layOrderPrint.SetItemValue(rowNum, "order_date", o_order_date);
                        layOrderPrint.SetItemValue(rowNum, "jaeryo_code", o_jaeryo_code);
                        layOrderPrint.SetItemValue(rowNum, "nalsu", o_nalsu);
                        layOrderPrint.SetItemValue(rowNum, "divide", o_divide);
                        layOrderPrint.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                        layOrderPrint.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                        layOrderPrint.SetItemValue(rowNum, "order_danui", o_order_danui);
                        layOrderPrint.SetItemValue(rowNum, "subul_danui", o_subul_danui);
                        layOrderPrint.SetItemValue(rowNum, "group_yn", o_group_yn);
                        layOrderPrint.SetItemValue(rowNum, "jaeryo_gubun", o_jaeryo_gubun);
                        layOrderPrint.SetItemValue(rowNum, "bogyong_code", o_bogyong_code);
                        layOrderPrint.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                        layOrderPrint.SetItemValue(rowNum, "caution_name", o_caution_name);
                        layOrderPrint.SetItemValue(rowNum, "caution_code", o_caution_code);
                        layOrderPrint.SetItemValue(rowNum, "mix_yn", o_mix_yn);
                        layOrderPrint.SetItemValue(rowNum, "atc_yn", o_atc_yn);
                        layOrderPrint.SetItemValue(rowNum, "dv", o_dv);
                        layOrderPrint.SetItemValue(rowNum, "dv_time", o_dv_time);
                        layOrderPrint.SetItemValue(rowNum, "dc_yn", o_dc_yn);
                        layOrderPrint.SetItemValue(rowNum, "bannab_yn", o_bannab_yn);
                        layOrderPrint.SetItemValue(rowNum, "source_fkocs1003", o_source_fkocs2003);
                        layOrderPrint.SetItemValue(rowNum, "fkocs1003", o_fkocs2003);
                        layOrderPrint.SetItemValue(rowNum, "sunab_date", o_sunab_date);
                        layOrderPrint.SetItemValue(rowNum, "pattern", o_pattern);
                        layOrderPrint.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                        layOrderPrint.SetItemValue(rowNum, "sunab_nalsu", o_sunab_nalsu);
                        layOrderPrint.SetItemValue(rowNum, "wonyoi_yn", o_wonyoi_yn);
                        layOrderPrint.SetItemValue(rowNum, "order_remark", o_order_remark);
                        layOrderPrint.SetItemValue(rowNum, "act_date", o_act_date);
                        layOrderPrint.SetItemValue(rowNum, "mayak", o_mayak);
                        layOrderPrint.SetItemValue(rowNum, "tpn_joje_gubun", o_tpn_joje_gubun);
                        layOrderPrint.SetItemValue(rowNum, "ui_jusa_yn", o_ui_jusa_yn);
                        layOrderPrint.SetItemValue(rowNum, "subul_suryang", o_subul_suryang);
                        layOrderPrint.SetItemValue(rowNum, "serial_v", o_serial_v);
                        layOrderPrint.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                        layOrderPrint.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                        layOrderPrint.SetItemValue(rowNum, "suname", o_suname);
                        layOrderPrint.SetItemValue(rowNum, "suname2", o_suname2);
                        layOrderPrint.SetItemValue(rowNum, "birth", o_birth);
                        layOrderPrint.SetItemValue(rowNum, "age", o_sex_age);
                        layOrderPrint.SetItemValue(rowNum, "other_gwa", o_other_gwa);
                        layOrderPrint.SetItemValue(rowNum, "do_order", o_do_order);
                        layOrderPrint.SetItemValue(rowNum, "gubun_name", o_gubun_name);
                        layOrderPrint.SetItemValue(rowNum, "hope_date", o_hope_date);
                        layOrderPrint.SetItemValue(rowNum, "powder_yn", o_powder_yn);
                        layOrderPrint.SetItemValue(rowNum, "line", o_line);
                        layOrderPrint.SetItemValue(rowNum, "kyukyeok", o_kyukyeok);
                        layOrderPrint.SetItemValue(rowNum, "licenes", o_licenes);
                        layOrderPrint.SetItemValue(rowNum, "bunryu1", o_bunryu1);
                        layOrderPrint.SetItemValue(rowNum, "ho_dong", o_ho_dong);
                        layOrderPrint.SetItemValue(rowNum, "ho_code", o_ho_code);
                        layOrderPrint.SetItemValue(rowNum, "title", o_title);
                        layOrderPrint.SetItemValue(rowNum, "donbok", o_donbok);
                        layOrderPrint.SetItemValue(rowNum, "tusuk", o_tusuk);
                        layOrderPrint.SetItemValue(rowNum, "magam_gubun", o_magam_gubun);
                        layOrderPrint.SetItemValue(rowNum, "text_color", o_text_color);
                        layOrderPrint.SetItemValue(rowNum, "changgo", o_changgo);
                        layOrderPrint.SetItemValue(rowNum, "from_order_date", o_from_order_date);
                        layOrderPrint.SetItemValue(rowNum, "to_order_date", o_to_order_date);
                        layOrderPrint.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                        layOrderPrint.SetItemValue(rowNum, "print_gubun", o_print_gubun);
                        layOrderPrint.SetItemValue(rowNum, "hodong_ord_name", o_hodong_ord_name);
                        layOrderPrint.SetItemValue(rowNum, "max_bannab_yn", o_max_bannab_yn);

                        //반납건 추가 조회
                        bindVars.Remove("f_serial_v");
                        bindVars.Add("f_serial_v", o_serial_text);
                        bindVars.Add("f_fkocs2003", o_fkocs2003);
                        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

                        cmdText = @"SELECT DISTINCT
                                       A.BUNHO                                                                                 BUNHO
                                      ,A.DRG_BUNHO                                                                             DRG_BUNHO
                                      ,A.GROUP_SER                                                                             GROUP_SER
                                      ,TO_CHAR(A.JUBSU_DATE,'YYYY/MM/DD')                                                                            JUBSU_DATE
                                      ,TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD')                                                                            ORDER_DATE
                                      ,A.JAERYO_CODE                                                                           JAERYO_CODE
                                      ,A.NALSU * DECODE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) , 'Y', A.DIVIDE, 1)              NALSU
                                      ,A.DIVIDE                                                                                DIVIDE
                                      ,CASE WHEN A.NALSU < 0 THEN '-'||CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN '0'||ROUND(A.ORD_SURYANG,2) ELSE ''||ROUND(A.ORD_SURYANG,2) END
                                                           ELSE ''||CASE WHEN ROUND(A.ORD_SURYANG,2) < 1 THEN '0'||ROUND(A.ORD_SURYANG,2) ELSE ''||ROUND(A.ORD_SURYANG,2) END
                                                           END                                                                 ORD_SURYANG
                                      ,DECODE(A.BUNRYU1, '4', A.ORD_SURYANG, A.ORDER_SURYANG )                                 ORDER_SURYANG
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI)                                         ORDER_DANUI
                                      ,A.SUBUL_DANUI                                                                           SUBUL_DANUI
                                      ,A.BOGYONG_CODE                                                                          BOGYONG_CODE
                                      ,TRIM(B.BOGYONG_NAME) || FN_DRG_LOAD_RP_TEXT('I', A.JUBSU_DATE, A.DRG_BUNHO, :f_serial_v)||
                                        DECODE(NVL(A.DV_1,0) + NVL(A.DV_2,0) + NVL(A.DV_3,0) + NVL(A.DV_4,0) + NVL(A.DV_5,0)
                                      , 0,  NULL, '('||LTRIM(TO_CHAR(NVL(A.DV_1,0))) || '-' ||LTRIM(TO_CHAR(NVL(A.DV_2,0))) ||  '-' ||
                                  LTRIM(TO_CHAR(NVL(A.DV_3,0))) || '-' ||LTRIM(TO_CHAR(NVL(A.DV_4,0))) ||  '-' ||
                                  LTRIM(TO_CHAR(NVL(A.DV_5,0)))|| ')' )   BOGYONG_NAME
                                      ,SUBSTRB(FN_DRG_LOAD_CAUTION_NM(A.JUBSU_DATE, A.DRG_BUNHO, :f_serial_v, 'O' ) ,1,80)      CAUTION_NAME
                                      ,A.MIX_YN                                                                                MIX_YN
                                      ,A.ATC_YN                                                                                ATC_YN
                                      ,D.DV                                                                                    DV
                                      ,A.DV_TIME                                                                               DV_TIME
                                      ,D.DC_YN                                                                                 DC_YN
                                      ,D.BANNAB_YN                                                                             BANNAB_YN
                                      ,D.SOURCE_FKOCS2003                                                                      SOURCE_FKOCS2003
                                      ,A.FKOCS2003                                                                             FKOCS2003
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                                          SUNAB_DATE
                                      ,B.PATTERN                                                                               PATTERN
                                      ,F.HANGMOG_NAME                                                                          JAERYO_NAME
                                      ,0                                                                                       SUNAB_NALSU
                                      ,NVL(D.WONYOI_ORDER_YN,'N')                                                              WONYOI_YN
                                      ,F.HANGMOG_NAME || ' : ' ||  TRIM(D.ORDER_REMARK)                                        ORDER_REMARK
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                    ACT_DATE
                                      ,NVL(C.MIX_YN_INP,'N')                                                                   UI_JUSA_YN
                                      ,A.SUBUL_SURYANG                                                                         SUBUL_SURYANG
                                      ,'Rp.'||LTRIM(TO_CHAR(TO_NUMBER(:f_serial_v),'00'))||DECODE(A.MIX_GROUP,NULL,'',' M')    SERIAL_V
                                      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.JUBSU_DATE)                                               GWA_NAME
                                      ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                                         DOCTOR_NAME
                                      ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA)                             OTHER_GWA
                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE )                                         HOPE_DATE
                                      ,FN_DRG_POWDER_YN(A.JUBSU_DATE, A.DRG_BUNHO, 'I')                                        POWDER_YN
                                      ,NVL(:f_serial_v,'1')                                                                   LINE
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI)                                       ORD_DANUI2
                                      ,SUBSTRB(TRIM(A.BUNRYU1),1,1)                                                            BUNRYU1
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)                          HO_DONG
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'C'),1,20)                          HO_CODE
                                      ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                                   DONBOK
                                      ,''                                                                                      TUSUK
                                      ,DECODE(A.TOIWON_DRG_YN, '1', 'OT', A.MAGAM_GUBUN)                                       MAGAM_GUBUN
                                      ,C.TEXT_COLOR                                                                            TEXT_COLOR
                                      ,C.CHANGGO1                                                                              CHANGGO
                                      ,'( ' || TO_CHAR(NVL(D.HOPE_DATE, D.ORDER_DATE),'MM/DD')                                 FROM_ORDER_DATE
                                      ,TO_CHAR(NVL(D.HOPE_DATE, D.ORDER_DATE)+ A.NALSU - 1, 'MM/DD') || ' )'                   TO_ORDER_DATE
                                      ,'A'                                                                                     DATA_GUBUN
                                      ,NVL(C.ACT_JAERYO_NAME,F.HANGMOG_NAME)                                                   HODONG_ORD_NAME
                                      --,'Y'                                                                                     MAX_BANNAB_YN
                                      ,NVL(A.BANNAB_YN,'N')                                                                    MAX_BANNAB_YN
                                  FROM OCS0103 F
                                      ,OCS2003 D
                                      ,INV0110 C
                                      ,DRG0120 B
                                      ,DRG3010 A
                                 WHERE A.SOURCE_FKOCS2003 = :f_fkocs2003
                                   AND A.HOSP_CODE        = :f_hosp_code
                                   AND B.HOSP_CODE     (+)= A.HOSP_CODE
                                   AND B.BOGYONG_CODE  (+)= A.BOGYONG_CODE
                                   AND C.HOSP_CODE        = A.HOSP_CODE
                                   AND C.JAERYO_CODE      = A.JAERYO_CODE
                                   AND D.HOSP_CODE        = A.HOSP_CODE
                                   AND D.PKOCS2003        = A.FKOCS2003
                                   AND F.HOSP_CODE        = D.HOSP_CODE
                                   AND F.HANGMOG_CODE     = D.HANGMOG_CODE
                                 ORDER BY A.FKOCS2003";

                        dtBannab = Service.ExecuteDataTable(cmdText, bindVars);
                        for (int t = 0; t < dtBannab.Rows.Count; t++)
                        {
                            o_bunho = dtBannab.Rows[t]["bunho"].ToString();
                            o_drg_bunho = dtBannab.Rows[t]["drg_bunho"].ToString();
                            o_group_ser = dtBannab.Rows[t]["group_ser"].ToString();
                            o_jubsu_date = dtBannab.Rows[t]["jubsu_date"].ToString();
                            o_order_date = dtBannab.Rows[t]["order_date"].ToString();
                            o_jaeryo_code = dtBannab.Rows[t]["jaeryo_code"].ToString();
                            o_nalsu = dtBannab.Rows[t]["nalsu"].ToString();
                            o_divide = dtBannab.Rows[t]["divide"].ToString();
                            o_ord_suryang = dtBannab.Rows[t]["ord_suryang"].ToString();
                            o_order_suryang = dtBannab.Rows[t]["order_suryang"].ToString();
                            o_order_danui = dtBannab.Rows[t]["order_danui"].ToString();
                            o_subul_danui = dtBannab.Rows[t]["subul_danui"].ToString();
                            o_bogyong_code = dtBannab.Rows[t]["bogyong_code"].ToString();
                            o_bogyong_name = dtBannab.Rows[t]["bogyong_name"].ToString();
                            o_caution_name = dtBannab.Rows[t]["caution_name"].ToString();
                            o_mix_yn = dtBannab.Rows[t]["mix_yn"].ToString();
                            o_atc_yn = dtBannab.Rows[t]["atc_yn"].ToString();
                            o_dv = dtBannab.Rows[t]["dv"].ToString();
                            o_dv_time = dtBannab.Rows[t]["dv_time"].ToString();
                            o_dc_yn = dtBannab.Rows[t]["dc_yn"].ToString();
                            o_bannab_yn = dtBannab.Rows[t]["bannab_yn"].ToString();
                            o_source_fkocs2003 = dtBannab.Rows[t]["source_fkocs2003"].ToString();
                            o_fkocs2003 = dtBannab.Rows[t]["fkocs2003"].ToString();
                            o_sunab_date = dtBannab.Rows[t]["sunab_date"].ToString();
                            o_pattern = dtBannab.Rows[t]["pattern"].ToString();
                            o_jaeryo_name = dtBannab.Rows[t]["jaeryo_name"].ToString();
                            o_sunab_nalsu = dtBannab.Rows[t]["sunab_nalsu"].ToString();
                            o_wonyoi_yn = dtBannab.Rows[t]["wonyoi_yn"].ToString();
                            o_order_remark = dtBannab.Rows[t]["order_remark"].ToString();
                            o_act_date = dtBannab.Rows[t]["act_date"].ToString();
                            o_ui_jusa_yn = dtBannab.Rows[t]["ui_jusa_yn"].ToString();
                            o_subul_suryang = dtBannab.Rows[t]["subul_suryang"].ToString();
                            o_serial_v = dtBannab.Rows[t]["serial_v"].ToString();
                            o_gwa_name = dtBannab.Rows[t]["gwa_name"].ToString();
                            o_doctor_name = dtBannab.Rows[t]["doctor_name"].ToString();
                            o_other_gwa = dtBannab.Rows[t]["other_gwa"].ToString();
                            o_hope_date = dtBannab.Rows[t]["hope_date"].ToString();
                            o_powder_yn = dtBannab.Rows[t]["powder_yn"].ToString();
                            o_line = dtBannab.Rows[t]["line"].ToString();
                            o_ord_danui2 = dtBannab.Rows[t]["ord_danui2"].ToString();
                            o_bunryu1 = dtBannab.Rows[t]["bunryu1"].ToString();
                            o_ho_dong = dtBannab.Rows[t]["ho_dong"].ToString();
                            o_ho_code = dtBannab.Rows[t]["ho_code"].ToString();
                            o_donbok = dtBannab.Rows[t]["donbok"].ToString();
                            o_tusuk = dtBannab.Rows[t]["tusuk"].ToString();
                            o_magam_gubun = dtBannab.Rows[t]["magam_gubun"].ToString();
                            o_text_color = dtBannab.Rows[t]["text_color"].ToString();
                            o_changgo = dtBannab.Rows[t]["changgo"].ToString();
                            o_from_order_date = dtBannab.Rows[t]["from_order_date"].ToString();
                            o_to_order_date = dtBannab.Rows[t]["to_order_date"].ToString();
                            o_data_gubun = dtBannab.Rows[t]["data_gubun"].ToString();
                            o_hodong_ord_name = dtBannab.Rows[t]["hodong_ord_name"].ToString();
                            o_max_bannab_yn = dtBannab.Rows[t]["max_bannab_yn"].ToString();

                            rowNum = layOrderPrint.InsertRow(-1);

                            layOrderPrint.SetItemValue(rowNum, "bunho", o_bunho);
                            layOrderPrint.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                            layOrderPrint.SetItemValue(rowNum, "naewon_date", o_naewon_date);
                            layOrderPrint.SetItemValue(rowNum, "group_ser", o_group_ser);
                            layOrderPrint.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                            layOrderPrint.SetItemValue(rowNum, "order_date", o_order_date);
                            layOrderPrint.SetItemValue(rowNum, "jaeryo_code", o_jaeryo_code);
                            layOrderPrint.SetItemValue(rowNum, "nalsu", o_nalsu);
                            layOrderPrint.SetItemValue(rowNum, "divide", o_divide);
                            layOrderPrint.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                            layOrderPrint.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                            layOrderPrint.SetItemValue(rowNum, "order_danui", o_order_danui);
                            layOrderPrint.SetItemValue(rowNum, "subul_danui", o_subul_danui);
                            layOrderPrint.SetItemValue(rowNum, "group_yn", o_group_yn);
                            layOrderPrint.SetItemValue(rowNum, "jaeryo_gubun", o_jaeryo_gubun);
                            layOrderPrint.SetItemValue(rowNum, "bogyong_code", o_bogyong_code);
                            layOrderPrint.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                            layOrderPrint.SetItemValue(rowNum, "caution_name", o_caution_name);
                            layOrderPrint.SetItemValue(rowNum, "caution_code", o_caution_code);
                            layOrderPrint.SetItemValue(rowNum, "mix_yn", o_mix_yn);
                            layOrderPrint.SetItemValue(rowNum, "atc_yn", o_atc_yn);
                            layOrderPrint.SetItemValue(rowNum, "dv", o_dv);
                            layOrderPrint.SetItemValue(rowNum, "dv_time", o_dv_time);
                            layOrderPrint.SetItemValue(rowNum, "dc_yn", o_dc_yn);
                            layOrderPrint.SetItemValue(rowNum, "bannab_yn", o_bannab_yn);
                            layOrderPrint.SetItemValue(rowNum, "source_fkocs1003", o_source_fkocs2003);
                            layOrderPrint.SetItemValue(rowNum, "fkocs1003", o_fkocs2003);
                            layOrderPrint.SetItemValue(rowNum, "sunab_date", o_sunab_date);
                            layOrderPrint.SetItemValue(rowNum, "pattern", o_pattern);
                            layOrderPrint.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                            layOrderPrint.SetItemValue(rowNum, "sunab_nalsu", o_sunab_nalsu);
                            layOrderPrint.SetItemValue(rowNum, "wonyoi_yn", o_wonyoi_yn);
                            layOrderPrint.SetItemValue(rowNum, "order_remark", o_order_remark);
                            layOrderPrint.SetItemValue(rowNum, "act_date", o_act_date);
                            layOrderPrint.SetItemValue(rowNum, "mayak", o_mayak);
                            layOrderPrint.SetItemValue(rowNum, "tpn_joje_gubun", o_tpn_joje_gubun);
                            layOrderPrint.SetItemValue(rowNum, "ui_jusa_yn", o_ui_jusa_yn);
                            layOrderPrint.SetItemValue(rowNum, "subul_suryang", o_subul_suryang);
                            layOrderPrint.SetItemValue(rowNum, "serial_v", o_serial_v);
                            layOrderPrint.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                            layOrderPrint.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                            layOrderPrint.SetItemValue(rowNum, "suname", o_suname);
                            layOrderPrint.SetItemValue(rowNum, "suname2", o_suname2);
                            layOrderPrint.SetItemValue(rowNum, "birth", o_birth);
                            layOrderPrint.SetItemValue(rowNum, "age", o_sex_age);
                            layOrderPrint.SetItemValue(rowNum, "other_gwa", o_other_gwa);
                            layOrderPrint.SetItemValue(rowNum, "do_order", o_do_order);
                            layOrderPrint.SetItemValue(rowNum, "gubun_name", o_gubun_name);
                            layOrderPrint.SetItemValue(rowNum, "hope_date", o_hope_date);
                            layOrderPrint.SetItemValue(rowNum, "powder_yn", o_powder_yn);
                            layOrderPrint.SetItemValue(rowNum, "line", o_line);
                            layOrderPrint.SetItemValue(rowNum, "kyukyeok", o_kyukyeok);
                            layOrderPrint.SetItemValue(rowNum, "licenes", o_licenes);
                            layOrderPrint.SetItemValue(rowNum, "bunryu1", o_bunryu1);
                            layOrderPrint.SetItemValue(rowNum, "ho_dong", o_ho_dong);
                            layOrderPrint.SetItemValue(rowNum, "ho_code", o_ho_code);
                            layOrderPrint.SetItemValue(rowNum, "title", o_title);
                            layOrderPrint.SetItemValue(rowNum, "donbok", o_donbok);
                            layOrderPrint.SetItemValue(rowNum, "tusuk", o_tusuk);
                            layOrderPrint.SetItemValue(rowNum, "magam_gubun", o_magam_gubun);
                            layOrderPrint.SetItemValue(rowNum, "text_color", o_text_color);
                            layOrderPrint.SetItemValue(rowNum, "changgo", o_changgo);
                            layOrderPrint.SetItemValue(rowNum, "from_order_date", o_from_order_date);
                            layOrderPrint.SetItemValue(rowNum, "to_order_date", o_to_order_date);
                            layOrderPrint.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                            layOrderPrint.SetItemValue(rowNum, "print_gubun", o_print_gubun);
                            layOrderPrint.SetItemValue(rowNum, "hodong_ord_name", o_hodong_ord_name);
                            layOrderPrint.SetItemValue(rowNum, "max_bannab_yn", o_max_bannab_yn);
                        }

                    }

                    /* DRGPRINT_I_ORD_PRN_REMARK */
                    cmdText = @"SELECT DISTINCT
                                       A.BUNHO                                                                                BUNHO
                                      ,A.DRG_BUNHO                                                                            DRG_BUNHO
                                      ,A.GROUP_SER                                                                            GROUP_SER
                                      ,TO_CHAR(A.JUBSU_DATE,'YYYY/MM/DD')                                                                           JUBSU_DATE
                                      ,TO_CHAR(A.ORDER_DATE,'YYYY/MM/DD')                                                                           ORDER_DATE
                                      ,A.JAERYO_CODE                                                                          JAERYO_CODE
                                      ,A.NALSU * DECODE(FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE) , 'Y', A.DIVIDE, 1)             NALSU
                                      ,A.DIVIDE                                                                               DIVIDE
                                      ,A.ORD_SURYANG                                                                          ORD_SURYANG
                                      ,DECODE(A.BUNRYU1, '4', A.ORD_SURYANG, A.ORDER_SURYANG )                                ORDER_SURYANG
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI)                                        ORDER_DANUI
                                      ,A.SUBUL_DANUI                                                                          SUBUL_DANUI
                                      ,A.BOGYONG_CODE                                                                         BOGYONG_CODE
                                      ,TRIM(B.BOGYONG_NAME)|| DECODE(NVL(G.DV_1,0) + NVL(G.DV_2,0) + NVL(G.DV_3,0) + 
                                       NVL(G.DV_4,0) + NVL(G.DV_5,0) , 0,  NULL, '('||LTRIM(TO_CHAR(NVL(G.DV_1,0))) 
                                       || '-' ||LTRIM(TO_CHAR(NVL(G.DV_2,0))) ||  '-' ||
                                   LTRIM(TO_CHAR(NVL(G.DV_3,0))) || '-' ||LTRIM(TO_CHAR(NVL(G.DV_4,0))) ||  '-' ||
                                   LTRIM(TO_CHAR(NVL(G.DV_5,0)))|| ')' )                                                  BOGYONG_NAME
                                      ,SUBSTRB(FN_DRG_LOAD_CAUTION_NM(E.JUBSU_DATE, E.DRG_BUNHO, E.SERIAL_V, 'O' ) ,1,80)     CAUTION_NAME
                                      ,A.MIX_YN                                                                               MIX_YN
                                      ,A.ATC_YN                                                                               ATC_YN
                                      ,D.DV                                                                                   DV
                                      ,A.DV_TIME                                                                              DV_TIME
                                      ,D.DC_YN                                                                                DC_YN
                                      ,D.BANNAB_YN                                                                            BANNAB_YN
                                      ,D.SOURCE_FKOCS2003                                                                     SOURCE_FKOCS2003
                                      ,A.FKOCS2003                                                                            FKOCS2003
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                                         SUNAB_DATE
                                      ,B.PATTERN                                                                              PATTERN
                                      ,F.HANGMOG_NAME                                                                         JAERYO_NAME
                                      ,0                                                                                      SUNAB_NALSU
                                      ,NVL(D.WONYOI_ORDER_YN,'N')                                                             WONYOI_YN
                                      ,F.HANGMOG_NAME || ' : ' || TRIM(D.ORDER_REMARK)                                        ORDER_REMARK
                                      ,TO_CHAR(TRUNC(SYSDATE),'YYYY/MM/DD')                                                   ACT_DATE
                                      ,NVL(C.MIX_YN_INP,'N')                                                                  UI_JUSA_YN
                                      ,A.SUBUL_SURYANG                                                                        SUBUL_SURYANG
                                      ,'Rp.'||LTRIM(TO_CHAR(TO_NUMBER(E.SERIAL_V),'00'))||DECODE(G.MIX_GROUP,NULL,'',' M')    SERIAL_V
                                      ,FN_BAS_LOAD_GWA_NAME(A.GWA, A.JUBSU_DATE)                                              GWA_NAME
                                      ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)                                             DOCTOR_NAME
                                      ,FN_OCS_CHECK_OTHER_GWA_NAEWON(A.BUNHO, A.ORDER_DATE, A.GWA)                            OTHER_GWA
                                      ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.HOPE_DATE )                                        HOPE_DATE
                                      ,FN_DRG_POWDER_YN(A.JUBSU_DATE, A.DRG_BUNHO, 'I')                                       POWDER_YN
                                      ,NVL(E.SERIAL_V, 1)                                                                     LINE
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI)                                      ORD_DANUI2
                                      ,SUBSTRB(TRIM(A.BUNRYU1),1,1)                                                           BUNRYU1
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'C'),1,20)                         HO_CODE
                                      ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)                         HO_DONG
                                      ,FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE)                                                  DONBOK
                                      ,''                                                                                     TUSUK
                                      ,DECODE(G.TOIWON_DRG_YN, '1', 'OT', G.MAGAM_GUBUN)                                      MAGAM_GUBUN
                                      ,C.TEXT_COLOR                                                                           TEXT_COLOR
                                      ,C.CHANGGO1                                                                             CHANGGO
                                      ,'( ' || TO_CHAR(NVL(D.HOPE_DATE, D.ORDER_DATE),'MM/DD')                                 FROM_ORDER_DATE
                                      ,TO_CHAR(NVL(D.HOPE_DATE, D.ORDER_DATE)+ A.NALSU - 1, 'MM/DD') || ' )'                   TO_ORDER_DATE
                                      ,'B'                                                                                    DATA_GUBUN
                                      ,NVL(C.ACT_JAERYO_NAME,F.HANGMOG_NAME)                                                  HODONG_ORD_NAME
                                      ,(SELECT MAX(NVL(X.BANNAB_YN,'N'))
                                          FROM DRG3010 X
                                             , DRG2035 Y
                                         WHERE Y.JUBSU_DATE = E.JUBSU_DATE
                                           AND Y.HOSP_CODE  = :f_hosp_code
                                           AND Y.DRG_BUNHO  = E.DRG_BUNHO
                                           AND Y.SERIAL_V   = E.SERIAL_V
                                           AND Y.FKOCS2003  = X.FKOCS2003
                                           AND X.FKOCS2003  = E.FKOCS2003 
                                           AND X.HOSP_CODE  = Y.HOSP_CODE
                                          )                                                     MAX_BANNAB_YN
                                  FROM OCS0103 F
                                      ,DRG2035 E
                                      ,OCS2003 D
                                      ,INV0110 C
                                      ,DRG0120 B
                                      ,DRG3011 A
                                      ,DRG3010 G
                                 WHERE A.JUBSU_DATE       = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
                                   AND A.HOSP_CODE        = :f_hosp_code
                                   AND A.DRG_BUNHO        = :f_drg_bunho
                                   AND B.HOSP_CODE     (+)= A.HOSP_CODE
                                   AND B.BOGYONG_CODE  (+)= A.BOGYONG_CODE
                                   AND C.HOSP_CODE        = A.HOSP_CODE
                                   AND C.JAERYO_CODE      = A.JAERYO_CODE
                                   AND D.HOSP_CODE        = A.HOSP_CODE
                                   AND D.PKOCS2003        = A.FKOCS2003
                                   AND TRIM(D.ORDER_REMARK) IS NOT NULL
                                   AND G.HOSP_CODE        = A.HOSP_CODE
                                   AND G.FKOCS2003        = A.FKOCS2003
                                   AND E.HOSP_CODE        = A.HOSP_CODE
                                   AND E.JUBSU_DATE       = A.JUBSU_DATE
                                   AND E.DRG_BUNHO        = A.DRG_BUNHO
                                   AND E.FKOCS2003        = A.FKOCS2003
                                   AND E.SERIAL_V         = :f_serial_text
                                   AND F.HOSP_CODE        = D.HOSP_CODE
                                   AND F.HANGMOG_CODE     = D.HANGMOG_CODE
                                 ORDER BY A.DRG_BUNHO, 'Rp.'||LTRIM(TO_CHAR(TO_NUMBER(E.SERIAL_V),'00'))||DECODE(G.MIX_GROUP,NULL,'',' M'), A.FKOCS2003";

                    dtRemark = Service.ExecuteDataTable(cmdText, bindVars);

                    for (int k = 0; k < dtRemark.Rows.Count; k++)
                    {
                        o_bunho = dtRemark.Rows[k]["bunho"].ToString();
                        o_drg_bunho = dtRemark.Rows[k]["drg_bunho"].ToString();
                        o_group_ser = dtRemark.Rows[k]["group_ser"].ToString();
                        o_jubsu_date = dtRemark.Rows[k]["jubsu_date"].ToString();
                        o_order_date = dtRemark.Rows[k]["order_date"].ToString();
                        o_jaeryo_code = dtRemark.Rows[k]["jaeryo_code"].ToString();
                        o_nalsu = dtRemark.Rows[k]["nalsu"].ToString();
                        o_divide = dtRemark.Rows[k]["divide"].ToString();
                        o_ord_suryang = dtRemark.Rows[k]["ord_suryang"].ToString();
                        o_order_suryang = dtRemark.Rows[k]["order_suryang"].ToString();
                        o_order_danui = dtRemark.Rows[k]["order_danui"].ToString();
                        o_subul_danui = dtRemark.Rows[k]["subul_danui"].ToString();
                        o_bogyong_code = dtRemark.Rows[k]["bogyong_code"].ToString();
                        o_bogyong_name = dtRemark.Rows[k]["bogyong_name"].ToString();
                        o_caution_name = dtRemark.Rows[k]["caution_name"].ToString();
                        o_mix_yn = dtRemark.Rows[k]["mix_yn"].ToString();
                        o_atc_yn = dtRemark.Rows[k]["atc_yn"].ToString();
                        o_dv = dtRemark.Rows[k]["dv"].ToString();
                        o_dv_time = dtRemark.Rows[k]["dv_time"].ToString();
                        o_dc_yn = dtRemark.Rows[k]["dc_yn"].ToString();
                        o_bannab_yn = dtRemark.Rows[k]["bannab_yn"].ToString();
                        o_source_fkocs2003 = dtRemark.Rows[k]["source_fkocs2003"].ToString();
                        o_fkocs2003 = dtRemark.Rows[k]["fkocs2003"].ToString();
                        o_sunab_date = dtRemark.Rows[k]["sunab_date"].ToString();
                        o_pattern = dtRemark.Rows[k]["pattern"].ToString();
                        o_jaeryo_name = dtRemark.Rows[k]["jaeryo_name"].ToString();
                        o_sunab_nalsu = dtRemark.Rows[k]["sunab_nalsu"].ToString();
                        o_wonyoi_yn = dtRemark.Rows[k]["wonyoi_yn"].ToString();
                        o_order_remark = dtRemark.Rows[k]["order_remark"].ToString();
                        o_act_date = dtRemark.Rows[k]["act_date"].ToString();
                        o_ui_jusa_yn = dtRemark.Rows[k]["ui_jusa_yn"].ToString();
                        o_subul_suryang = dtRemark.Rows[k]["subul_suryang"].ToString();
                        o_serial_v = dtRemark.Rows[k]["serial_v"].ToString();
                        o_gwa_name = dtRemark.Rows[k]["gwa_name"].ToString();
                        o_doctor_name = dtRemark.Rows[k]["doctor_name"].ToString();
                        o_other_gwa = dtRemark.Rows[k]["other_gwa"].ToString();
                        o_hope_date = dtRemark.Rows[k]["hope_date"].ToString();
                        o_powder_yn = dtRemark.Rows[k]["powder_yn"].ToString();
                        o_line = dtRemark.Rows[k]["line"].ToString();
                        o_ord_danui2 = dtRemark.Rows[k]["ord_danui2"].ToString();
                        o_bunryu1 = dtRemark.Rows[k]["bunryu1"].ToString();
                        o_ho_code = dtRemark.Rows[k]["ho_code"].ToString();
                        o_ho_dong = dtRemark.Rows[k]["ho_dong"].ToString();
                        o_donbok = dtRemark.Rows[k]["donbok"].ToString();
                        o_tusuk = dtRemark.Rows[k]["tusuk"].ToString();
                        o_magam_gubun = dtRemark.Rows[k]["magam_gubun"].ToString();
                        o_text_color = dtRemark.Rows[k]["text_color"].ToString();
                        o_changgo = dtRemark.Rows[k]["changgo"].ToString();
                        o_from_order_date = dtRemark.Rows[k]["from_order_date"].ToString();
                        o_to_order_date = dtRemark.Rows[k]["to_order_date"].ToString();
                        o_data_gubun = dtRemark.Rows[k]["data_gubun"].ToString();
                        o_hodong_ord_name = dtRemark.Rows[k]["hodong_ord_name"].ToString();
                        o_max_bannab_yn = dtRemark.Rows[k]["max_bannab_yn"].ToString();

                        rowNum = layOrderPrint.InsertRow(-1);

                        layOrderPrint.SetItemValue(rowNum, "bunho", o_bunho);
                        layOrderPrint.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                        layOrderPrint.SetItemValue(rowNum, "naewon_date", o_naewon_date);
                        layOrderPrint.SetItemValue(rowNum, "group_ser", o_group_ser);
                        layOrderPrint.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                        layOrderPrint.SetItemValue(rowNum, "order_date", o_order_date);
                        layOrderPrint.SetItemValue(rowNum, "jaeryo_code", o_jaeryo_code);
                        layOrderPrint.SetItemValue(rowNum, "nalsu", o_nalsu);
                        layOrderPrint.SetItemValue(rowNum, "divide", o_divide);
                        layOrderPrint.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                        layOrderPrint.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                        layOrderPrint.SetItemValue(rowNum, "order_danui", o_order_danui);
                        layOrderPrint.SetItemValue(rowNum, "subul_danui", o_subul_danui);
                        layOrderPrint.SetItemValue(rowNum, "group_yn", o_group_yn);
                        layOrderPrint.SetItemValue(rowNum, "jaeryo_gubun", o_jaeryo_gubun);
                        layOrderPrint.SetItemValue(rowNum, "bogyong_code", o_bogyong_code);
                        layOrderPrint.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                        layOrderPrint.SetItemValue(rowNum, "caution_name", o_caution_name);
                        layOrderPrint.SetItemValue(rowNum, "caution_code", o_caution_code);
                        layOrderPrint.SetItemValue(rowNum, "mix_yn", o_mix_yn);
                        layOrderPrint.SetItemValue(rowNum, "atc_yn", o_atc_yn);
                        layOrderPrint.SetItemValue(rowNum, "dv", o_dv);
                        layOrderPrint.SetItemValue(rowNum, "dv_time", o_dv_time);
                        layOrderPrint.SetItemValue(rowNum, "dc_yn", o_dc_yn);
                        layOrderPrint.SetItemValue(rowNum, "bannab_yn", o_bannab_yn);
                        layOrderPrint.SetItemValue(rowNum, "source_fkocs1003", o_source_fkocs2003);
                        layOrderPrint.SetItemValue(rowNum, "fkocs1003", o_fkocs2003);
                        layOrderPrint.SetItemValue(rowNum, "sunab_date", o_sunab_date);
                        layOrderPrint.SetItemValue(rowNum, "pattern", o_pattern);
                        layOrderPrint.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                        layOrderPrint.SetItemValue(rowNum, "sunab_nalsu", o_sunab_nalsu);
                        layOrderPrint.SetItemValue(rowNum, "wonyoi_yn", o_wonyoi_yn);
                        layOrderPrint.SetItemValue(rowNum, "order_remark", o_order_remark);
                        layOrderPrint.SetItemValue(rowNum, "act_date", o_act_date);
                        layOrderPrint.SetItemValue(rowNum, "mayak", o_mayak);
                        layOrderPrint.SetItemValue(rowNum, "tpn_joje_gubun", o_tpn_joje_gubun);
                        layOrderPrint.SetItemValue(rowNum, "ui_jusa_yn", o_ui_jusa_yn);
                        layOrderPrint.SetItemValue(rowNum, "subul_suryang", o_subul_suryang);
                        layOrderPrint.SetItemValue(rowNum, "serial_v", o_serial_v);
                        layOrderPrint.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                        layOrderPrint.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                        layOrderPrint.SetItemValue(rowNum, "suname", o_suname);
                        layOrderPrint.SetItemValue(rowNum, "suname2", o_suname2);
                        layOrderPrint.SetItemValue(rowNum, "birth", o_birth);
                        layOrderPrint.SetItemValue(rowNum, "age", o_sex_age);
                        layOrderPrint.SetItemValue(rowNum, "other_gwa", o_other_gwa);
                        layOrderPrint.SetItemValue(rowNum, "do_order", o_do_order);
                        layOrderPrint.SetItemValue(rowNum, "gubun_name", o_gubun_name);
                        layOrderPrint.SetItemValue(rowNum, "hope_date", o_hope_date);
                        layOrderPrint.SetItemValue(rowNum, "powder_yn", o_powder_yn);
                        layOrderPrint.SetItemValue(rowNum, "line", o_line);
                        layOrderPrint.SetItemValue(rowNum, "kyukyeok", o_kyukyeok);
                        layOrderPrint.SetItemValue(rowNum, "licenes", o_licenes);
                        layOrderPrint.SetItemValue(rowNum, "bunryu1", o_bunryu1);
                        layOrderPrint.SetItemValue(rowNum, "ho_dong", o_ho_dong);
                        layOrderPrint.SetItemValue(rowNum, "ho_code", o_ho_code);
                        layOrderPrint.SetItemValue(rowNum, "title", o_title);
                        layOrderPrint.SetItemValue(rowNum, "donbok", o_donbok);
                        layOrderPrint.SetItemValue(rowNum, "tusuk", o_tusuk);
                        layOrderPrint.SetItemValue(rowNum, "magam_gubun", o_magam_gubun);
                        layOrderPrint.SetItemValue(rowNum, "text_color", o_text_color);
                        layOrderPrint.SetItemValue(rowNum, "changgo", o_changgo);
                        layOrderPrint.SetItemValue(rowNum, "from_order_date", o_from_order_date);
                        layOrderPrint.SetItemValue(rowNum, "to_order_date", o_to_order_date);
                        layOrderPrint.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                        layOrderPrint.SetItemValue(rowNum, "print_gubun", o_print_gubun);
                        layOrderPrint.SetItemValue(rowNum, "hodong_ord_name", o_hodong_ord_name);
                        layOrderPrint.SetItemValue(rowNum, "max_bannab_yn", o_max_bannab_yn);
                    }
                }

                int ttt_cnt = 0;
                foreach (DataRow dtrow in layOrderPrint.LayoutTable.Rows)
                {
                    Service.debugFileWrite("mins test row = " + ++ttt_cnt);
                    for (int col_ind = 0; col_ind < layOrderPrint.LayoutTable.Columns.Count; col_ind++)
                    {
                        Service.debugFileWrite("mins test " + ttt_cnt + " [" + layOrderPrint.LayoutTable.Columns[col_ind].ColumnName + "] = [" + dtrow[col_ind].ToString() + "]");
                    }
                }
            }
            catch (Exception xe)
            {
                XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                return false;
            }
            return true;
        }
        #endregion

        #region [-- DsvOrderJungbo --]
        /// <summary>
        /// dsvOrderJungbo Service Conversion PC: DRGPRINT, WT: 8
        /// </summary>
        /// <param name="jubsuDate"></param>
        /// <param name="drgBunho"></param>
        /// <returns>bool</returns>
        private bool DsvOrderJungbo(string jubsuDate, string drgBunho)
        {
            layOrderJungbo.Reset();

            string o_seq_1 = string.Empty;
            string o_seq_2 = string.Empty;

            string o_text_1 = string.Empty;
            string o_text_2 = string.Empty;
            string o_text_3 = string.Empty;
            string o_comments = string.Empty;
            string o_bunho_comments = string.Empty;
            string o_bar_drg_bunho = string.Empty;
            string o_bar_rp_bunho = string.Empty;

            string o_bunho = string.Empty;
            string o_cpl_1 = string.Empty;
            string o_cpl_2 = string.Empty;
            string o_cpl_3 = string.Empty;
            string o_danui_1 = string.Empty;
            string o_danui_2 = string.Empty;
            string o_danui_3 = string.Empty;
            string o_hl_1 = string.Empty;
            string o_hl_2 = string.Empty;
            string o_hl_3 = string.Empty;

            string t_comments = string.Empty;

            string cmdText = "";
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);
            bindVars.Add("f_hosp_code", mHospCode);
            DataTable resTable = new DataTable();
            object retVal = null;

            cmdText = @"SELECT '1'                SEQ_1
                              ,D.SERIAL_V         SEQ_2
                              ,C.JAERYO_NAME      TEXT_1
                              ,''                 TEXT_2
                              ,''                 TEXT_3
                              ,REPLACE(REPLACE(B.ORDER_REMARK,CHR(13)||CHR(10),' '),CHR(10),' ')     REMARK
                              ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'  bar_drg_bunho
                              ,A.BUNHO            BUNHO
                          FROM DRG2035 D
                              ,INV0110 C
                              ,DRG9042 B
                              ,DRG3010 A
                         WHERE A.JUBSU_DATE     = TO_DATE(:f_jubsu_date, 'yyyy/MM/dd')
                           AND A.DRG_BUNHO      = :f_drg_bunho
                           AND A.HOSP_CODE      = :f_hosp_code
                           AND B.FKOCS          = A.FKOCS2003
                           AND B.HOSP_CODE      = A.HOSP_CODE
                           AND C.JAERYO_CODE (+)= A.JAERYO_CODE
                           AND C.HOSP_CODE   (+)= A.HOSP_CODE
                           AND D.FKOCS2003   (+)= A.FKOCS2003
                           AND D.HOSP_CODE   (+)= A.HOSP_CODE
                           AND B.ORDER_REMARK IS NOT NULL
                        UNION ALL
                        SELECT DISTINCT '1'       SEQ_1
                              ,''                 SEQ_2
                              ,C.JAERYO_NAME      TEXT_1
                              ,''                 TEXT_2
                              ,''                 TEXT_3
                              ,'[' || FN_ADM_MSG(4111) || ']' || REPLACE(REPLACE(C.DRG_COMMENT,CHR(13)||CHR(10),' '),CHR(10),' ')      REMARK
                              ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'  bar_drg_bunho
                              ,A.BUNHO            BUNHO
                          FROM DRG2035 D
                              ,INV0110 C
                              ,DRG3010 A
                         WHERE A.JUBSU_DATE     = TO_DATE(:f_jubsu_date, 'yyyy/MM/dd')
                           AND A.DRG_BUNHO      = :f_drg_bunho
                           AND A.HOSP_CODE      = :f_hosp_code
                           AND C.JAERYO_CODE (+)= A.JAERYO_CODE
                           AND C.HOSP_CODE   (+)= A.HOSP_CODE
                           AND NVL(C.CHKD,'N')  = 'Y'
                           AND D.FKOCS2003   (+)= A.FKOCS2003
                           AND D.HOSP_CODE   (+)= A.HOSP_CODE
                        UNION ALL
                        SELECT DISTINCT
                               '2'                SEQ_1
                              ,''                 SEQ_2
                              ,'##'               TEXT_1
                              ,''                 TEXT_2
                              ,''                 TEXT_3
                              ,REPLACE(REPLACE(B.ORDER_REMARK,CHR(13)||CHR(10),' '),CHR(10),' ')    REMARK
                              ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'  bar_drg_bunho
                              ,A.BUNHO            BUNHO
                          FROM DRG9040 B
                              ,DRG3010 A
                         WHERE A.JUBSU_DATE  = TO_DATE(:f_jubsu_date, 'yyyy/MM/dd')
                           AND A.DRG_BUNHO   = :f_drg_bunho
                           AND A.HOSP_CODE   = :f_hosp_code
                           AND B.JUBSU_DATE  = A.JUBSU_DATE
                           AND B.DRG_BUNHO   = A.DRG_BUNHO
                           AND B.HOSP_CODE   = A.HOSP_CODE
                           AND B.ORDER_REMARK IS NOT NULL
                        UNION ALL
                        SELECT DISTINCT
                               '3'                SEQ_1
                              ,''                 SEQ_2
                              ,'$$'               TEXT_1
                              ,''                 TEXT_2
                              ,''                 TEXT_3
                              ,REPLACE(REPLACE(B.ORDER_REMARK,CHR(13)||CHR(10),' '),CHR(10),' ')     REMARK
                              ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'  bar_drg_bunho
                              ,A.BUNHO            BUNHO
                          FROM DRG9041 B
                              ,DRG3010 A
                         WHERE A.JUBSU_DATE     = TO_DATE(:f_jubsu_date, 'yyyy/MM/dd')
                           AND A.DRG_BUNHO      = :f_drg_bunho
                           AND A.HOSP_CODE      = :f_hosp_code
                           AND B.BUNHO       (+)= A.BUNHO
                           AND B.HOSP_CODE   (+)= A.HOSP_CODE
                           AND B.ORDER_REMARK IS NOT NULL
                         ORDER BY 1, 2";

            try
            {
                resTable = Service.ExecuteDataTable(cmdText, bindVars);

                if (TypeCheck.IsNull(resTable) || resTable.Rows.Count == 0)
                {
                    cmdText = @"SELECT DISTINCT '*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || LTRIM(TO_CHAR(A.DRG_BUNHO,'0000'))||'*'
                                                   FROM DRG3010 A
                                                  WHERE A.JUBSU_DATE  = TO_DATE(:f_jubsu_date, 'yyyy/MM/dd')
                                                    AND A.DRG_BUNHO   = :f_drg_bunho
                                                    AND A.HOSP_CODE   = :f_hosp_code";
                    /* fetch된 data가 없을 경우는 바코드를 위해서 */
                    retVal = Service.ExecuteScalar(cmdText, bindVars);
                    if (retVal == null)
                    {
                        XMessageBox.Show(Service.ErrFullMsg + "\n\r" + Resources.XMessageBox2);
                        return false;
                    }

                    layOrderJungbo.InsertRow(-1);
                    layOrderJungbo.SetItemValue(0, "bar_drg_bunho", retVal.ToString());
                    return true;
                }

                if (Service.ErrCode != 0) return false;

                for (int i = 0; i < resTable.Rows.Count; i++)
                {
                    o_seq_1 = resTable.Rows[i]["seq_1"].ToString();
                    o_seq_2 = resTable.Rows[i]["seq_2"].ToString();
                    o_text_1 = resTable.Rows[i]["text_1"].ToString();
                    o_text_2 = resTable.Rows[i]["text_2"].ToString();
                    o_text_3 = resTable.Rows[i]["text_3"].ToString();
                    o_comments = resTable.Rows[i]["remark"].ToString();
                    o_bar_drg_bunho = resTable.Rows[i]["bar_drg_bunho"].ToString();
                    o_bunho = resTable.Rows[i]["bunho"].ToString();

                    cmdText = @"SELECT NVL(FN_NUR_LOAD_WEIGHT_HEIGHT('H', :o_bunho), 0) HEIGHT
                                      ,'Cm'                                             CM
                                      ,NVL(FN_NUR_LOAD_WEIGHT_HEIGHT('W', :o_bunho), 0) WEIGHT
                                      ,'Kg'                                             KG
                                      ,FN_CPL_HANGMOG_RESULT(:o_bunho, '00077')         CPL_RESULT
                                      ,FN_ADM_CONVERT_KATAKANA_FULL(:o_comments)        COMMENTS
                                      ,TRUNC(LENGTH(NVL(:o_comments,' ')) / 80)         CNT
                                  FROM DUAL";
                    DataTable dtResult = new DataTable();
                    BindVarCollection bcResult = new BindVarCollection();
                    bcResult.Add("o_bunho", resTable.Rows[i]["bunho"].ToString());
                    bcResult.Add("o_comments", resTable.Rows[i]["remark"].ToString());
                    dtResult = Service.ExecuteDataTable(cmdText, bcResult);
                    int by_row;

                    o_cpl_2 = dtResult.Rows[0]["height"].ToString();
                    o_danui_2 = dtResult.Rows[0]["cm"].ToString();
                    o_cpl_1 = dtResult.Rows[0]["weight"].ToString();
                    o_danui_1 = dtResult.Rows[0]["kg"].ToString();
                    o_cpl_3 = dtResult.Rows[0]["cpl_result"].ToString();
                    o_comments = dtResult.Rows[0]["comments"].ToString();
                    by_row = int.Parse(dtResult.Rows[0]["cnt"].ToString());

                    cmdText = "";
                    int rowNum = 0;
                    for (int b = 0; b <= by_row; b++)
                    {
                        cmdText = @"SELECT '    ' || SUBSTR('" + o_comments + "', " + b + "* 80 + 1, 80)  T_COMMENTS FROM DUAL";
                        t_comments = Service.ExecuteScalar(cmdText).ToString();
                        if (b == 0)
                        {
                            rowNum = layOrderJungbo.InsertRow(-1);
                            layOrderJungbo.SetItemValue(rowNum, "text_1", o_text_1);
                            layOrderJungbo.SetItemValue(rowNum, "text_2", o_text_2);
                            layOrderJungbo.SetItemValue(rowNum, "text_3", o_text_3);
                            layOrderJungbo.SetItemValue(rowNum, "comments", o_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bunho_comments", o_bunho_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bar_drg_bunho", o_bar_drg_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "bar_rp_bunho", o_bar_rp_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_1", o_cpl_1);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_2", o_cpl_2);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_3", o_cpl_3);
                            layOrderJungbo.SetItemValue(rowNum, "danui_1", o_danui_1);
                            layOrderJungbo.SetItemValue(rowNum, "danui_2", o_danui_2);
                            layOrderJungbo.SetItemValue(rowNum, "danui_3", o_danui_3);
                            layOrderJungbo.SetItemValue(rowNum, "hl_1", o_hl_1);
                            layOrderJungbo.SetItemValue(rowNum, "hl_2", o_hl_2);
                            layOrderJungbo.SetItemValue(rowNum, "hl_3", o_hl_3);

                            rowNum = layOrderJungbo.InsertRow(-1);
                            layOrderJungbo.SetItemValue(rowNum, "text_1", t_comments);
                            layOrderJungbo.SetItemValue(rowNum, "text_2", o_text_2);
                            layOrderJungbo.SetItemValue(rowNum, "text_3", o_text_3);
                            layOrderJungbo.SetItemValue(rowNum, "comments", t_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bunho_comments", o_bunho_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bar_drg_bunho", o_bar_drg_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "bar_rp_bunho", o_bar_rp_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_1", o_cpl_1);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_2", o_cpl_2);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_3", o_cpl_3);
                            layOrderJungbo.SetItemValue(rowNum, "danui_1", o_danui_1);
                            layOrderJungbo.SetItemValue(rowNum, "danui_2", o_danui_2);
                            layOrderJungbo.SetItemValue(rowNum, "danui_3", o_danui_3);
                            layOrderJungbo.SetItemValue(rowNum, "hl_1", o_hl_1);
                            layOrderJungbo.SetItemValue(rowNum, "hl_2", o_hl_2);
                            layOrderJungbo.SetItemValue(rowNum, "hl_3", o_hl_3);
                        }
                        else
                        {
                            rowNum = layOrderJungbo.InsertRow(-1);
                            layOrderJungbo.SetItemValue(rowNum, "text_1", t_comments);
                            layOrderJungbo.SetItemValue(rowNum, "text_2", o_text_2);
                            layOrderJungbo.SetItemValue(rowNum, "text_3", o_text_3);
                            layOrderJungbo.SetItemValue(rowNum, "comments", t_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bunho_comments", o_bunho_comments);
                            layOrderJungbo.SetItemValue(rowNum, "bar_drg_bunho", o_bar_drg_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "bar_rp_bunho", o_bar_rp_bunho);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_1", o_cpl_1);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_2", o_cpl_2);
                            layOrderJungbo.SetItemValue(rowNum, "cpl_3", o_cpl_3);
                            layOrderJungbo.SetItemValue(rowNum, "danui_1", o_danui_1);
                            layOrderJungbo.SetItemValue(rowNum, "danui_2", o_danui_2);
                            layOrderJungbo.SetItemValue(rowNum, "danui_3", o_danui_3);
                            layOrderJungbo.SetItemValue(rowNum, "hl_1", o_hl_1);
                            layOrderJungbo.SetItemValue(rowNum, "hl_2", o_hl_2);
                            layOrderJungbo.SetItemValue(rowNum, "hl_3", o_hl_3);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message + "\n\r" + ex.StackTrace);
                return false;
            }
            return true;
        }
        #endregion

        #region [-- DsvOrderBarcode --]
        /// <summary>
        /// dsvOrderBarcode Service Conversion / PC: DRGPRINT WT: B
        /// </summary>
        /// <param name="jubsuDate"></param>
        /// <param name="drgBunho"></param>
        /// <returns>fewfeewf</returns>
        private bool DsvOrderBarcode(string jubsuDate, string drgBunho)
        {
            string o_seq_1 = string.Empty;
            string o_seq_2 = string.Empty;

            string o_text_1 = string.Empty;
            string o_text_2 = string.Empty;
            string o_text_3 = string.Empty;
            string o_comments = string.Empty;
            string o_bunho_comments = string.Empty;
            string o_bar_drg_bunho = string.Empty;
            string o_bar_rp_bunho = string.Empty;

            string o_cpl_1 = string.Empty;
            string o_cpl_2 = string.Empty;
            string o_cpl_3 = string.Empty;
            string o_danui_1 = string.Empty;
            string o_danui_2 = string.Empty;
            string o_danui_3 = string.Empty;
            string o_hl_1 = string.Empty;
            string o_hl_2 = string.Empty;
            string o_hl_3 = string.Empty;

            string o_bunho = string.Empty;

            string cmdText = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);
            bindVars.Add("f_hosp_code", mHospCode);
            DataTable resTable = new DataTable();
            DataTable dtResult = new DataTable();

            cmdText = @"SELECT DISTINCT
                               '*' || TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || TO_CHAR(A.DRG_BUNHO) || '*'                          BAR_DRG_BUNHO
                              ,'*' || TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || TO_CHAR(A.DRG_BUNHO) || TO_CHAR(A.GROUP_SER) || '*'  BAR_RP_BUNHO
                              ,'Rp. ' || TO_CHAR(A.GROUP_SER)                                                                  SER
                              ,A.BUNHO                                                                                         BUNHO
                          FROM DRG3011 A
                         WHERE A.JUBSU_DATE     = :f_jubsu_date
                           AND A.DRG_BUNHO      = :f_drg_bunho
                           AND A.HOSP_CODE      = :f_hosp_code
                         ORDER BY 1, 2";

            resTable = Service.ExecuteDataTable(cmdText, bindVars);

            if (resTable.Rows.Count > 0)
            {
                for (int i = 0; i < resTable.Rows.Count; i++)
                {
                    int rowNum = layOrderBarcode.InsertRow(-1);

                    o_bar_drg_bunho = resTable.Rows[i]["bar_drg_bunho"].ToString();
                    o_bar_rp_bunho = resTable.Rows[i]["bar_rp_bunho"].ToString();
                    o_text_1 = resTable.Rows[i]["ser"].ToString();
                    o_bunho = resTable.Rows[i]["bunho"].ToString();

                    cmdText = @"SELECT NVL(FN_NUR_LOAD_WEIGHT_HEIGHT('H', :o_bunho), 0) HEIGHT
                                      ,'Cm'                                             CM
                                      ,NVL(FN_NUR_LOAD_WEIGHT_HEIGHT('W', :o_bunho), 0) WEIGHT
                                      ,'Kg'                                             KG
                                      ,FN_CPL_HANGMOG_RESULT(:o_bunho, '00077')         CPL_RESULT
                                  FROM DUAL";
                    bindVars.Clear();
                    bindVars.Add("o_bunho", o_bunho);
                    dtResult = Service.ExecuteDataTable(cmdText, bindVars);
                    o_cpl_1 = dtResult.Rows[0]["height"].ToString();
                    o_danui_1 = dtResult.Rows[0]["cm"].ToString();
                    o_cpl_2 = dtResult.Rows[0]["weight"].ToString();
                    o_danui_2 = dtResult.Rows[0]["kg"].ToString();
                    o_cpl_3 = dtResult.Rows[0]["cpl_result"].ToString();

                    layOrderBarcode.SetItemValue(rowNum, "text_1", o_text_1);
                    layOrderBarcode.SetItemValue(rowNum, "text_2", o_text_2);
                    layOrderBarcode.SetItemValue(rowNum, "text_3", o_text_3);
                    layOrderBarcode.SetItemValue(rowNum, "comments", o_comments);
                    layOrderBarcode.SetItemValue(rowNum, "bunho_comments", o_bunho_comments);
                    layOrderBarcode.SetItemValue(rowNum, "bar_drg_bunho", o_bar_drg_bunho);
                    layOrderBarcode.SetItemValue(rowNum, "bar_rp_bunho", o_bar_rp_bunho);
                    layOrderBarcode.SetItemValue(rowNum, "cpl_1", o_cpl_1);
                    layOrderBarcode.SetItemValue(rowNum, "cpl_2", o_cpl_2);
                    layOrderBarcode.SetItemValue(rowNum, "cpl_3", o_cpl_3);
                    layOrderBarcode.SetItemValue(rowNum, "danui_1", o_danui_1);
                    layOrderBarcode.SetItemValue(rowNum, "danui_2", o_danui_2);
                    layOrderBarcode.SetItemValue(rowNum, "danui_3", o_danui_3);
                    layOrderBarcode.SetItemValue(rowNum, "hl_1", o_hl_1);
                    layOrderBarcode.SetItemValue(rowNum, "hl_2", o_hl_2);
                    layOrderBarcode.SetItemValue(rowNum, "hl_3", o_hl_3);
                }
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return false;
            }

            return true;
        }
        #endregion

        #region [-- DsvJusaOrderPrint --]
        /// <summary>
        /// dsvJusaOrderPrint Service Conversion PC: DRGPRINT, WT: D
        /// </summary>
        /// <param name="jubsuDate"></param>
        /// <param name="drgBunho"></param>
        /// <param name="printGubun"></param>
        /// <returns></returns>
        private bool DsvJusaOrderPrint(string jubsuDate, string drgBunho, string printGubun)
        {
            string o_print_gubun = string.Empty;
            layJusaOrderPrint.Reset();
            int rowNum;

            // DRGPRINT_I_JUSA_CUR 변수
            string o_bunho = string.Empty;
            string o_drg_bunho = string.Empty;
            string o_order_date_text = string.Empty;
            string o_jubsu_date = string.Empty;
            string o_hope_date = string.Empty;
            string o_order_date = string.Empty;
            string o_serial_v = string.Empty;
            string o_serial_text = string.Empty;
            string o_gwa_name = string.Empty;
            string o_resident_name = string.Empty;
            string o_suname = string.Empty;
            string o_suname2 = string.Empty;
            string o_birth = string.Empty;
            string o_sex_age = string.Empty;
            string o_ho_code = string.Empty;
            string o_ho_dong = string.Empty;
            string o_magam_gubun = string.Empty;
            string o_rp_barcode = string.Empty;
            string o_barcode = string.Empty;
            string o_key = string.Empty;

            //DRGPRINT_I_JUSA_SERIAL 변수
            string o_jaeryo_code = string.Empty;
            string o_nalsu = string.Empty;
            string o_divide = string.Empty;
            string o_order_suryang = string.Empty;
            string o_subul_suryang = string.Empty;
            string o_ord_suryang = string.Empty;
            string o_order_danui = string.Empty;
            string o_subul_danui = string.Empty;
            string o_bunryu1 = string.Empty;
            string o_bunryu2 = string.Empty;
            string o_bunryu3 = string.Empty;
            string o_bunryu4 = string.Empty;
            string o_remark = string.Empty;
            string o_dv_time = string.Empty;
            string o_dv = string.Empty;
            string o_bunryu6 = string.Empty;
            string o_mix_group = string.Empty;
            string o_dv_1 = string.Empty;
            string o_dv_2 = string.Empty;
            string o_dv_3 = string.Empty;
            string o_dv_4 = string.Empty;
            string o_dv_5 = string.Empty;
            string o_hubal_change_yn = string.Empty;
            string o_pharmacy = string.Empty;
            string o_jusa_spd_gubun = string.Empty;
            string o_drg_pack_yn = string.Empty;
            string o_jusa = string.Empty;
            string o_jaeryo_name = string.Empty;
            string o_order_danui_name = string.Empty;
            string o_subul_danui_name = string.Empty;
            string o_jusa_name = string.Empty;
            string o_bogyong_name = string.Empty;
            string o_jusa_nalsu = string.Empty;
            string o_data_gubun = string.Empty;
            string o_hodong_ord_name = string.Empty;
            string o_doctor_name = string.Empty;
            string o_max_bannab_yn = string.Empty;
            string o_bannab_yn = string.Empty;
            string o_fkocs2003 = string.Empty;

            string cmdText = string.Empty;
            DataTable dtJusa = new DataTable();
            DataTable dtSerial = new DataTable();
            DataTable dtRemark = new DataTable();
            DataTable dtBannab = new DataTable();

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            inputList.Add(jubsuDate);
            inputList.Add(drgBunho);
            inputList.Add(printGubun);
            if (Service.ExecuteProcedure("PR_DRG_LOAD_PRINT_GUBUN", inputList, outputList))
            {
                o_print_gubun = outputList[0].ToString();
            }
            /*DRGPRINT_I_JUSA_CUR*/
            cmdText = @"SELECT DISTINCT
                               A.BUNHO                                             BUNHO
                              ,LTRIM(TO_CHAR(A.DRG_BUNHO))                         DRG_BUNHO
                              ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE )    ORDER_DATE_TEXT
                              ,TO_CHAR(A.JUBSU_DATE,'yyyy/MM/dd')                  JUBSU_DATE
                              ,TO_CHAR(A.HOPE_DATE ,'yyyy/MM/dd')                  HOPE_DATE
                              ,TO_CHAR(A.ORDER_DATE,'yyyy/MM/dd')                  ORDER_DATE
                              ,'Rp.'||E.SERIAL_V||DECODE(A.MIX_GROUP,NULL,'',' M') SERIAL_V
                              ,E.SERIAL_V                                          SERIAL_TEXT
                              ,FN_BAS_LOAD_GWA_NAME(F.GWA, A.JUBSU_DATE)           GWA_NAME
                              ,FN_BAS_LOAD_DOCTOR_NAME(A.RESIDENT, A.ORDER_DATE)   DOCTOR_NAME
                              ,D.SUNAME                                            SUNAME
                              ,D.SUNAME2                                           SUNAME2
                              ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', D.BIRTH)          BIRTH
                              ,FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE)          SEX_AGE
                              ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'C'),1,20)      HO_CODE
                              ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)      HO_DONG
                              ,A.MAGAM_GUBUN                                       MAGAM_GUBUN
                              ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || TO_CHAR(A.DRG_BUNHO) || TO_CHAR(E.SERIAL_V)||'*'      RP_BARCODE
                              ,'*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD') || TO_CHAR(A.DRG_BUNHO)||'*'                             BARCODE
                              ,LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ') key
                          FROM INP1001 F
                              ,DRG2035 E
                              ,OUT0101 D
                              ,DRG0120 C
                              ,INV0110 B
                              ,DRG3010 A
                         WHERE A.JUBSU_DATE         = :f_jubsu_date
                           AND A.DRG_BUNHO          = :f_drg_bunho
                           AND A.HOSP_CODE          = :f_hosp_code
                           AND A.BUNRYU1            IN ('4')
                           --AND NVL(A.DC_YN,'N')     = 'N'
                           --AND NVL(A.BANNAB_YN,'N') = 'N'
                           AND B.JAERYO_CODE     (+)= A.JAERYO_CODE
                           AND B.HOSP_CODE       (+)= A.HOSP_CODE
                           AND C.BOGYONG_CODE    (+)= A.BOGYONG_CODE
                           AND C.HOSP_CODE       (+)= A.HOSP_CODE
                           AND D.BUNHO              = A.BUNHO
                           AND D.HOSP_CODE          = A.HOSP_CODE
                           AND E.JUBSU_DATE         = A.JUBSU_DATE
                           AND E.DRG_BUNHO          = A.DRG_BUNHO
                           AND E.FKOCS2003          = A.FKOCS2003
                           AND E.HOSP_CODE          = A.HOSP_CODE
                           AND F.HOSP_CODE          = A.HOSP_CODE
                           AND F.PKINP1001          = A.FKINP1001
                         ORDER BY LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')";
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);
            bindVars.Add("f_hosp_code", mHospCode);
            try
            {
                dtJusa = Service.ExecuteDataTable(cmdText, bindVars);
                /*DRGPRINT_I_JUSA_CUR*/
                for (int i = 0; i < dtJusa.Rows.Count; i++)
                {
                    o_bunho = dtJusa.Rows[i]["bunho"].ToString();
                    o_drg_bunho = dtJusa.Rows[i]["drg_bunho"].ToString();
                    o_order_date_text = dtJusa.Rows[i]["order_date_text"].ToString();
                    o_jubsu_date = dtJusa.Rows[i]["jubsu_date"].ToString();
                    o_hope_date = dtJusa.Rows[i]["hope_date"].ToString();
                    o_order_date = dtJusa.Rows[i]["order_date"].ToString();
                    o_serial_v = dtJusa.Rows[i]["serial_v"].ToString();
                    o_serial_text = dtJusa.Rows[i]["serial_text"].ToString();
                    o_gwa_name = dtJusa.Rows[i]["gwa_name"].ToString();
                    o_resident_name = dtJusa.Rows[i]["doctor_name"].ToString();
                    o_suname = dtJusa.Rows[i]["suname"].ToString();
                    o_suname2 = dtJusa.Rows[i]["suname2"].ToString();
                    o_birth = dtJusa.Rows[i]["birth"].ToString();
                    o_sex_age = dtJusa.Rows[i]["sex_age"].ToString();
                    o_ho_code = dtJusa.Rows[i]["ho_code"].ToString();
                    o_ho_dong = dtJusa.Rows[i]["ho_dong"].ToString();
                    o_magam_gubun = dtJusa.Rows[i]["magam_gubun"].ToString();
                    o_rp_barcode = dtJusa.Rows[i]["rp_barcode"].ToString();
                    o_barcode = dtJusa.Rows[i]["barcode"].ToString();
                    o_key = dtJusa.Rows[i]["key"].ToString();

                    bindVars.Remove("f_serial_text");
                    bindVars.Add("f_serial_text", o_serial_text);

                    /*DRGPRINT_I_JUSA_SERIAL*/
                    cmdText = @"SELECT A.JAERYO_CODE                                        JAERYO_CODE
                                      ,A.NALSU                                              NALSU
                                      ,A.DIVIDE                                             DIVIDE
                                      ,A.ORDER_SURYANG                                      ORDER_SURYANG
                                      ,A.SUBUL_SURYANG                                      SUBUL_SURYANG
                                      ,A.ORD_SURYANG                                        ORD_SURYANG
                                      ,A.ORDER_DANUI                                        ORDER_DANUI
                                      ,A.SUBUL_DANUI                                        SUBUL_DANUI
                                      ,A.BUNRYU1                                            BUNRYU1
                                      ,A.BUNRYU2                                            BUNRYU2
                                      ,A.BUNRYU3                                            BUNRYU3
                                      ,A.BUNRYU4                                            BUNRYU4
                                      ,TRIM(C.ORDER_REMARK)                                 REMARK
                                      ,A.DV_TIME                                            DV_TIME
                                      ,A.DV                                                 DV
                                      ,A.BUNRYU6                                            BUNRYU6
                                      ,A.MIX_GROUP                                          MIX_GROUP
                                      ,A.DV_1                                               DV_1
                                      ,A.DV_2                                               DV_2
                                      ,A.DV_3                                               DV_3
                                      ,A.DV_4                                               DV_4
                                      ,A.DV_5                                               DV_5
                                      ,A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN
                                      ,A.PHARMACY                                           PHARMACY
                                      ,A.JUSA_SPD_GUBUN                                     JUSA_SPD_GUBUN
                                      ,A.DRG_PACK_YN                                        DRG_PACK_YN
                                      ,A.JUSA                                               JUSA
                                      ,B.HANGMOG_NAME                                       JAERYO_NAME
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI)    DANUI_NAME
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI)    SUBUL_DANUI_NAME
                                      ,FN_OCS_LOAD_CODE_NAME('JUSA',NVL(A.JUSA,'0'))        JUSA_NAME
                                      ,A.BOGYONG_CODE || ' ' || FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',NVL(A.JUSA_SPD_GUBUN,'0'))     BOGYONG_NAME
                                      --,FN_DRG_LOAD_NALSU_CNT(A.BUNHO, A.ORDER_DATE, 'I', A.JAERYO_CODE)                               JUSA_NALSU
                                      ,FN_DRG_LOAD_JUSA_NALSU_CNT(A.BUNHO, A.ORDER_DATE, A.JAERYO_CODE, A.GROUP_SER, A.HOPE_DATE, 'C')  JUSA_NALSU
                                      ,'A'                                                                                            DATA_GUBUN
                                      ,NVL(D.ACT_JAERYO_NAME,B.HANGMOG_NAME)                HODONG_ORD_NAME
                                      ,LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||
                                       LTRIM(TO_CHAR(DECODE(C.BOM_OCCUR_YN, 'Y', C.SEQ + 100, C.SEQ), '0000'))||
                                       LTRIM(TO_CHAR(C.PKOCS2003, '0000000000'))            key
                                      ,(SELECT MAX(NVL(X.BANNAB_YN,'N'))
                                          FROM DRG3010 X
                                             , DRG2035 Y
                                         WHERE Y.JUBSU_DATE = E.JUBSU_DATE
                                           AND Y.DRG_BUNHO  = E.DRG_BUNHO
                                           AND Y.SERIAL_V   = E.SERIAL_V
                                           AND Y.FKOCS2003  = X.FKOCS2003)              MAX_BANNAB_YN
                                      ,A.BANNAB_YN                                          BANNAB_YN
                                      ,A.FKOCS2003                                          FKOCS2003
                                  FROM DRG2035 E
                                      ,INV0110 D
                                      ,OCS2003 C
                                      ,OCS0103 B
                                      ,DRG3010 A
                                 WHERE A.JUBSU_DATE         = :f_jubsu_date
                                   AND A.DRG_BUNHO          = :f_drg_bunho
                                   AND A.HOSP_CODE          = :f_hosp_code
                                   AND A.BUNRYU1            IN ('4')
                                   --AND NVL(A.DC_YN,'N')     = 'N'
                                   --AND NVL(A.BANNAB_YN,'N') = 'N'
                                   AND B.HANGMOG_CODE       = C.HANGMOG_CODE
                                   AND B.HOSP_CODE          = C.HOSP_CODE
                                   AND A.JAERYO_CODE        = D.JAERYO_CODE(+)
                                   AND A.HOSP_CODE          = D.HOSP_CODE(+)
                                   AND E.JUBSU_DATE         = A.JUBSU_DATE
                                   AND E.DRG_BUNHO          = A.DRG_BUNHO
                                   AND E.HOSP_CODE          = A.HOSP_CODE
                                   AND E.FKOCS2003          = A.FKOCS2003
                                   AND C.PKOCS2003          = A.FKOCS2003
                                   AND C.HOSP_CODE          = A.HOSP_CODE
                                   AND E.SERIAL_V           = :f_serial_text
                                   AND C.ORDER_DATE         BETWEEN   B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
                                 ORDER BY LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||
                                       LTRIM(TO_CHAR(DECODE(C.BOM_OCCUR_YN, 'Y', C.SEQ + 100, C.SEQ), '0000'))||
                                       LTRIM(TO_CHAR(C.PKOCS2003, '0000000000'))";

                    dtSerial = Service.ExecuteDataTable(cmdText, bindVars);

                    /*DRGPRINT_I_JUSA_SERIAL*/
                    for (int j = 0; j < dtSerial.Rows.Count; j++)
                    {
                        o_jaeryo_code = dtSerial.Rows[j]["jaeryo_code"].ToString();
                        o_nalsu = dtSerial.Rows[j]["nalsu"].ToString();
                        o_divide = dtSerial.Rows[j]["divide"].ToString();
                        o_order_suryang = dtSerial.Rows[j]["order_suryang"].ToString();
                        o_subul_suryang = dtSerial.Rows[j]["subul_suryang"].ToString();
                        o_ord_suryang = dtSerial.Rows[j]["ord_suryang"].ToString();
                        o_order_danui = dtSerial.Rows[j]["order_danui"].ToString();
                        o_subul_danui = dtSerial.Rows[j]["subul_danui"].ToString();
                        o_bunryu1 = dtSerial.Rows[j]["bunryu1"].ToString();
                        o_bunryu2 = dtSerial.Rows[j]["bunryu2"].ToString();
                        o_bunryu3 = dtSerial.Rows[j]["bunryu3"].ToString();
                        o_bunryu4 = dtSerial.Rows[j]["bunryu4"].ToString();
                        o_remark = dtSerial.Rows[j]["remark"].ToString();
                        o_dv_time = dtSerial.Rows[j]["dv_time"].ToString();
                        o_dv = dtSerial.Rows[j]["dv"].ToString();
                        o_bunryu6 = dtSerial.Rows[j]["bunryu6"].ToString();
                        o_mix_group = dtSerial.Rows[j]["mix_group"].ToString();
                        o_dv_1 = dtSerial.Rows[j]["dv_1"].ToString();
                        o_dv_2 = dtSerial.Rows[j]["dv_2"].ToString();
                        o_dv_3 = dtSerial.Rows[j]["dv_3"].ToString();
                        o_dv_4 = dtSerial.Rows[j]["dv_4"].ToString();
                        o_dv_5 = dtSerial.Rows[j]["dv_5"].ToString();
                        o_hubal_change_yn = dtSerial.Rows[j]["hubal_change_yn"].ToString();
                        o_pharmacy = dtSerial.Rows[j]["pharmacy"].ToString();
                        o_jusa_spd_gubun = dtSerial.Rows[j]["jusa_spd_gubun"].ToString();
                        o_drg_pack_yn = dtSerial.Rows[j]["drg_pack_yn"].ToString();
                        o_jusa = dtSerial.Rows[j]["jusa"].ToString();
                        o_jaeryo_name = dtSerial.Rows[j]["jaeryo_name"].ToString();
                        o_order_danui_name = dtSerial.Rows[j]["danui_name"].ToString();
                        o_subul_danui_name = dtSerial.Rows[j]["subul_danui_name"].ToString();
                        o_jusa_name = dtSerial.Rows[j]["jusa_name"].ToString();
                        o_bogyong_name = dtSerial.Rows[j]["bogyong_name"].ToString();
                        o_jusa_nalsu = dtSerial.Rows[j]["jusa_nalsu"].ToString();
                        o_data_gubun = dtSerial.Rows[j]["data_gubun"].ToString();
                        o_hodong_ord_name = dtSerial.Rows[j]["hodong_ord_name"].ToString();
                        o_key = dtSerial.Rows[j]["key"].ToString();
                        o_max_bannab_yn = dtSerial.Rows[j]["max_bannab_yn"].ToString();
                        o_bannab_yn = dtSerial.Rows[j]["bannab_yn"].ToString();
                        o_fkocs2003 = dtSerial.Rows[j]["fkocs2003"].ToString();
                             

                        /* layJusaOrderPrint 에 쿼리결과를 셋팅 */
                        rowNum = layJusaOrderPrint.InsertRow(-1);

                        layJusaOrderPrint.SetItemValue(rowNum, "bunho", o_bunho);
                        layJusaOrderPrint.SetItemValue(rowNum, "suname", o_suname);
                        layJusaOrderPrint.SetItemValue(rowNum, "suname2", o_suname2);
                        layJusaOrderPrint.SetItemValue(rowNum, "birth", o_birth);
                        layJusaOrderPrint.SetItemValue(rowNum, "age", o_sex_age);
                        layJusaOrderPrint.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                        layJusaOrderPrint.SetItemValue(rowNum, "ho_dong", o_ho_dong);
                        layJusaOrderPrint.SetItemValue(rowNum, "ho_code", o_ho_code);
                        layJusaOrderPrint.SetItemValue(rowNum, "magam_gubun", o_magam_gubun);
                        layJusaOrderPrint.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                        layJusaOrderPrint.SetItemValue(rowNum, "serial_v", o_serial_v);
                        layJusaOrderPrint.SetItemValue(rowNum, "resident_name", o_resident_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "jusa", o_jusa_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                        layJusaOrderPrint.SetItemValue(rowNum, "order_danui", o_order_danui_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "dv", o_dv);
                        layJusaOrderPrint.SetItemValue(rowNum, "subul_surang", o_subul_suryang);
                        layJusaOrderPrint.SetItemValue(rowNum, "subul_danui", o_subul_danui_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "order_remark", o_remark);
                        layJusaOrderPrint.SetItemValue(rowNum, "rp_barcode", o_rp_barcode);
                        layJusaOrderPrint.SetItemValue(rowNum, "order_date", o_order_date);
                        layJusaOrderPrint.SetItemValue(rowNum, "hope_date", o_hope_date);
                        layJusaOrderPrint.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                        layJusaOrderPrint.SetItemValue(rowNum, "jusa_nalsu", o_jusa_nalsu);
                        layJusaOrderPrint.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                        layJusaOrderPrint.SetItemValue(rowNum, "barcode", o_barcode);
                        layJusaOrderPrint.SetItemValue(rowNum, "print_gubun", o_print_gubun);
                        layJusaOrderPrint.SetItemValue(rowNum, "hodong_ord_name", o_hodong_ord_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "sort_key", o_key);
                        layJusaOrderPrint.SetItemValue(rowNum, "max_bannab_yn", o_max_bannab_yn);
                        layJusaOrderPrint.SetItemValue(rowNum, "bannab_yn", o_bannab_yn);
                        layJusaOrderPrint.SetItemValue(rowNum, "fkocs2003", o_fkocs2003);

                        //반납건 추가 조회
                        bindVars.Remove("f_serial_v");
                        bindVars.Add("f_serial_v", o_serial_text);
                        bindVars.Add("f_fkocs2003", o_fkocs2003);

                        cmdText = @"SELECT A.JAERYO_CODE                                        JAERYO_CODE
                                      ,A.NALSU                                              NALSU
                                      ,A.DIVIDE                                             DIVIDE
                                      ,A.ORDER_SURYANG                                      ORDER_SURYANG
                                      ,A.SUBUL_SURYANG                                      SUBUL_SURYANG
                                      --,A.ORD_SURYANG                                        ORD_SURYANG
                                      ,A.SUBUL_SURYANG                                      ORD_SURYANG
                                      ,A.ORDER_DANUI                                        ORDER_DANUI
                                      ,A.SUBUL_DANUI                                        SUBUL_DANUI
                                      ,A.BUNRYU1                                            BUNRYU1
                                      ,A.BUNRYU2                                            BUNRYU2
                                      ,A.BUNRYU3                                            BUNRYU3
                                      ,A.BUNRYU4                                            BUNRYU4
                                      ,TRIM(C.ORDER_REMARK)                                 REMARK
                                      ,A.DV_TIME                                            DV_TIME
                                      ,A.DV                                                 DV
                                      ,A.BUNRYU6                                            BUNRYU6
                                      ,A.MIX_GROUP                                          MIX_GROUP
                                      ,A.DV_1                                               DV_1
                                      ,A.DV_2                                               DV_2
                                      ,A.DV_3                                               DV_3
                                      ,A.DV_4                                               DV_4
                                      ,A.DV_5                                               DV_5
                                      ,A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN
                                      ,A.PHARMACY                                           PHARMACY
                                      ,A.JUSA_SPD_GUBUN                                     JUSA_SPD_GUBUN
                                      ,A.DRG_PACK_YN                                        DRG_PACK_YN
                                      ,A.JUSA                                               JUSA
                                      ,B.HANGMOG_NAME                                       JAERYO_NAME
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI)    DANUI_NAME
                                      ,FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI)    SUBUL_DANUI_NAME
                                      ,FN_OCS_LOAD_CODE_NAME('JUSA',NVL(A.JUSA,'0'))        JUSA_NAME
                                      ,A.BOGYONG_CODE || ' ' || FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',NVL(A.JUSA_SPD_GUBUN,'0'))     BOGYONG_NAME
                                      --,FN_DRG_LOAD_NALSU_CNT(A.BUNHO, A.ORDER_DATE, 'I', A.JAERYO_CODE)                               JUSA_NALSU
                                      ,FN_DRG_LOAD_JUSA_NALSU_CNT(A.BUNHO, A.ORDER_DATE, A.JAERYO_CODE, A.GROUP_SER, A.HOPE_DATE, 'C')  JUSA_NALSU
                                      ,'A'                                                                                            DATA_GUBUN
                                      ,NVL(D.ACT_JAERYO_NAME,B.HANGMOG_NAME)                HODONG_ORD_NAME
                                      ,LTRIM(TO_CHAR(:f_serial_v, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||
                                       LTRIM(TO_CHAR(DECODE(C.BOM_OCCUR_YN, 'Y', C.SEQ + 100, C.SEQ), '0000'))||
                                       LTRIM(TO_CHAR(C.PKOCS2003, '0000000000'))            key
                                      ,'Y'                                                  MAX_BANNAB_YN
                                      ,A.BANNAB_YN                                          BANNAB_YN
                                      ,A.FKOCS2003                                          FKOCS2003
                                  FROM INV0110 D
                                      ,OCS2003 C
                                      ,OCS0103 B
                                      ,DRG3010 A
                                 WHERE A.SOURCE_FKOCS2003   = :f_fkocs2003
                                   AND A.BUNRYU1            IN ('4')
                                   AND NVL(A.BANNAB_YN,'N') = 'Y'
                                   AND B.HANGMOG_CODE       = C.HANGMOG_CODE
                                   AND A.JAERYO_CODE        = D.JAERYO_CODE(+)
                                   AND C.PKOCS2003          = A.FKOCS2003
                                   AND C.ORDER_DATE       BETWEEN   B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
                                 ORDER BY A.FKOCS2003";

                        dtBannab = Service.ExecuteDataTable(cmdText, bindVars);
                        for (int t = 0; t < dtBannab.Rows.Count; t++)
                        {
                            o_jaeryo_code = dtBannab.Rows[t]["jaeryo_code"].ToString();
                            o_nalsu = dtBannab.Rows[t]["nalsu"].ToString();
                            o_divide = dtBannab.Rows[t]["divide"].ToString();
                            o_order_suryang = dtBannab.Rows[t]["order_suryang"].ToString();
                            o_subul_suryang = dtBannab.Rows[t]["subul_suryang"].ToString();
                            o_ord_suryang = dtBannab.Rows[t]["ord_suryang"].ToString();
                            o_order_danui = dtBannab.Rows[t]["order_danui"].ToString();
                            o_subul_danui = dtBannab.Rows[t]["subul_danui"].ToString();
                            o_bunryu1 = dtBannab.Rows[t]["bunryu1"].ToString();
                            o_bunryu2 = dtBannab.Rows[t]["bunryu2"].ToString();
                            o_bunryu3 = dtBannab.Rows[t]["bunryu3"].ToString();
                            o_bunryu4 = dtBannab.Rows[t]["bunryu4"].ToString();
                            o_remark = dtBannab.Rows[t]["remark"].ToString();
                            o_dv_time = dtBannab.Rows[t]["dv_time"].ToString();
                            o_dv = dtBannab.Rows[t]["dv"].ToString();
                            o_bunryu6 = dtBannab.Rows[t]["bunryu6"].ToString();
                            o_mix_group = dtBannab.Rows[t]["mix_group"].ToString();
                            o_dv_1 = dtBannab.Rows[t]["dv_1"].ToString();
                            o_dv_2 = dtBannab.Rows[t]["dv_2"].ToString();
                            o_dv_3 = dtBannab.Rows[t]["dv_3"].ToString();
                            o_dv_4 = dtBannab.Rows[t]["dv_4"].ToString();
                            o_dv_5 = dtBannab.Rows[t]["dv_5"].ToString();
                            o_hubal_change_yn = dtBannab.Rows[t]["hubal_change_yn"].ToString();
                            o_pharmacy = dtBannab.Rows[t]["pharmacy"].ToString();
                            o_jusa_spd_gubun = dtBannab.Rows[t]["jusa_spd_gubun"].ToString();
                            o_drg_pack_yn = dtBannab.Rows[t]["drg_pack_yn"].ToString();
                            o_jusa = dtBannab.Rows[t]["jusa"].ToString();
                            o_jaeryo_name = dtBannab.Rows[t]["jaeryo_name"].ToString();
                            o_order_danui_name = dtBannab.Rows[t]["danui_name"].ToString();
                            o_subul_danui_name = dtBannab.Rows[t]["subul_danui_name"].ToString();
                            o_jusa_name = dtBannab.Rows[t]["jusa_name"].ToString();
                            o_bogyong_name = dtBannab.Rows[t]["bogyong_name"].ToString();
                            o_jusa_nalsu = dtBannab.Rows[t]["jusa_nalsu"].ToString();
                            o_data_gubun = dtBannab.Rows[t]["data_gubun"].ToString();
                            o_hodong_ord_name = dtBannab.Rows[t]["hodong_ord_name"].ToString();
                            o_key = dtBannab.Rows[t]["key"].ToString();
                            o_max_bannab_yn = dtBannab.Rows[t]["max_bannab_yn"].ToString();
                            o_bannab_yn = dtBannab.Rows[t]["bannab_yn"].ToString();
                            o_fkocs2003 = dtBannab.Rows[t]["fkocs2003"].ToString();


                            /* layJusaOrderPrint 에 쿼리결과를 셋팅 */
                            rowNum = layJusaOrderPrint.InsertRow(-1);

                            layJusaOrderPrint.SetItemValue(rowNum, "bunho", o_bunho);
                            layJusaOrderPrint.SetItemValue(rowNum, "suname", o_suname);
                            layJusaOrderPrint.SetItemValue(rowNum, "suname2", o_suname2);
                            layJusaOrderPrint.SetItemValue(rowNum, "birth", o_birth);
                            layJusaOrderPrint.SetItemValue(rowNum, "age", o_sex_age);
                            layJusaOrderPrint.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                            layJusaOrderPrint.SetItemValue(rowNum, "ho_dong", o_ho_dong);
                            layJusaOrderPrint.SetItemValue(rowNum, "ho_code", o_ho_code);
                            layJusaOrderPrint.SetItemValue(rowNum, "magam_gubun", o_magam_gubun);
                            layJusaOrderPrint.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                            layJusaOrderPrint.SetItemValue(rowNum, "serial_v", o_serial_v);
                            layJusaOrderPrint.SetItemValue(rowNum, "resident_name", o_resident_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "jusa", o_jusa_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                            layJusaOrderPrint.SetItemValue(rowNum, "order_danui", o_order_danui_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "dv", o_dv);
                            layJusaOrderPrint.SetItemValue(rowNum, "subul_surang", o_subul_suryang);
                            layJusaOrderPrint.SetItemValue(rowNum, "subul_danui", o_subul_danui_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "order_remark", o_remark);
                            layJusaOrderPrint.SetItemValue(rowNum, "rp_barcode", o_rp_barcode);
                            layJusaOrderPrint.SetItemValue(rowNum, "order_date", o_order_date);
                            layJusaOrderPrint.SetItemValue(rowNum, "hope_date", o_hope_date);
                            layJusaOrderPrint.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                            layJusaOrderPrint.SetItemValue(rowNum, "jusa_nalsu", o_jusa_nalsu);
                            layJusaOrderPrint.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                            layJusaOrderPrint.SetItemValue(rowNum, "barcode", o_barcode);
                            layJusaOrderPrint.SetItemValue(rowNum, "print_gubun", o_print_gubun);
                            layJusaOrderPrint.SetItemValue(rowNum, "hodong_ord_name", o_hodong_ord_name);
                            layJusaOrderPrint.SetItemValue(rowNum, "sort_key", o_key);
                            layJusaOrderPrint.SetItemValue(rowNum, "max_bannab_yn", o_max_bannab_yn);
                            layJusaOrderPrint.SetItemValue(rowNum, "bannab_yn", o_bannab_yn);
                            layJusaOrderPrint.SetItemValue(rowNum, "fkocs2003", o_fkocs2003);
                        }
                    }

                    /*DRGPRINT_I_SER_REMARK_CUR*/
                    cmdText = @"SELECT A.JAERYO_CODE                                        JAERYO_CODE
                                      ,A.NALSU                                              NALSU
                                      ,A.DIVIDE                                             DIVIDE
                                      ,A.ORDER_SURYANG                                      ORDER_SURYANG
                                      ,A.SUBUL_SURYANG                                      SUBUL_SURYANG
                                      ,A.ORD_SURYANG                                        ORD_SURYANG
                                      ,A.ORDER_DANUI                                        ORDER_DANUI
                                      ,A.SUBUL_DANUI                                        SUBUL_DANUI
                                      ,A.BUNRYU1                                            BUNRYU1
                                      ,A.BUNRYU2                                            BUNRYU2
                                      ,A.BUNRYU3                                            BUNRYU3
                                      ,A.BUNRYU4                                            BUNRYU4
                                      ,TRIM(C.ORDER_REMARK)                                 REMARK
                                      ,A.DV_TIME                                            DV_TIME
                                      ,A.DV                                                 DV
                                      ,A.BUNRYU6                                            BUNRYU6
                                      ,A.MIX_GROUP                                          MIX_GROUP
                                      ,A.DV_1                                               DV_1
                                      ,A.DV_2                                               DV_2
                                      ,A.DV_3                                               DV_3
                                      ,A.DV_4                                               DV_4
                                      ,A.DV_5                                               DV_5
                                      ,A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN
                                      ,A.PHARMACY                                           PHARMACY
                                      ,A.JUSA_SPD_GUBUN                                     JUSA_SPD_GUBUN
                                      ,A.DRG_PACK_YN                                        DRG_PACK_YN
                                      ,A.JUSA                                               JUSA
                                      ,B.HANGMOG_NAME                                       JAERYO_NAME
                                      ,'B'                                                  DATA_GUBUN
                                      ,NVL(D.ACT_JAERYO_NAME,B.HANGMOG_NAME)                HODONG_ORD_NAME
                                      ,LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||
                                       LTRIM(TO_CHAR(DECODE(C.BOM_OCCUR_YN, 'Y', C.SEQ + 100, C.SEQ), '0000'))||
                                       LTRIM(TO_CHAR(C.PKOCS2003, '0000000000'))            key
                                  FROM DRG2035 E
                                      ,INV0110 D
                                      ,OCS2003 C
                                      ,OCS0103 B
                                      ,DRG3010 A
                                 WHERE A.JUBSU_DATE         = :f_jubsu_date
                                   AND A.DRG_BUNHO          = :f_drg_bunho
                                   AND A.HOSP_CODE          = :f_hosp_code
                                   AND A.BUNRYU1            IN ('4')
                                   --AND NVL(A.DC_YN,'N')     = 'N'
                                   --AND NVL(A.BANNAB_YN,'N') = 'N'
                                   AND TRIM(C.ORDER_REMARK) IS NOT NULL
                                   AND B.HANGMOG_CODE       = C.HANGMOG_CODE
                                   AND B.HOSP_CODE          = C.HOSP_CODE
                                   AND A.JAERYO_CODE        = D.JAERYO_CODE(+)
                                   AND A.HOSP_CODE          = D.HOSP_CODE(+)
                                   AND E.JUBSU_DATE         = A.JUBSU_DATE
                                   AND E.DRG_BUNHO          = A.DRG_BUNHO
                                   AND E.HOSP_CODE          = A.HOSP_CODE
                                   AND C.PKOCS2003          = A.FKOCS2003
                                   AND C.HOSP_CODE          = A.HOSP_CODE
                                   AND E.FKOCS2003          = A.FKOCS2003
                                   AND E.SERIAL_V           = :f_serial_text
                                   AND C.ORDER_DATE       BETWEEN   B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
                                 ORDER BY LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||
                                          LTRIM(TO_CHAR(DECODE(C.BOM_OCCUR_YN, 'Y', C.SEQ + 100, C.SEQ), '0000'))||
                                          LTRIM(TO_CHAR(C.PKOCS2003, '0000000000'))";

                    dtRemark = Service.ExecuteDataTable(cmdText, bindVars);

                    for (int k = 0; k < dtRemark.Rows.Count; k++)
                    {
                        o_jaeryo_code = dtRemark.Rows[k]["jaeryo_code"].ToString();
                        o_nalsu = dtRemark.Rows[k]["nalsu"].ToString();
                        o_divide = dtRemark.Rows[k]["divide"].ToString();
                        o_order_suryang = dtRemark.Rows[k]["order_suryang"].ToString();
                        o_subul_suryang = dtRemark.Rows[k]["subul_suryang"].ToString();
                        o_ord_suryang = dtRemark.Rows[k]["ord_suryang"].ToString();
                        o_order_danui = dtRemark.Rows[k]["order_danui"].ToString();
                        o_subul_danui = dtRemark.Rows[k]["subul_danui"].ToString();
                        o_bunryu1 = dtRemark.Rows[k]["bunryu1"].ToString();
                        o_bunryu2 = dtRemark.Rows[k]["bunryu2"].ToString();
                        o_bunryu3 = dtRemark.Rows[k]["bunryu3"].ToString();
                        o_bunryu4 = dtRemark.Rows[k]["bunryu4"].ToString();
                        o_remark = dtRemark.Rows[k]["remark"].ToString();
                        o_dv_time = dtRemark.Rows[k]["dv_time"].ToString();
                        o_dv = dtRemark.Rows[k]["dv"].ToString();
                        o_bunryu6 = dtRemark.Rows[k]["bunryu6"].ToString();
                        o_mix_group = dtRemark.Rows[k]["mix_group"].ToString();
                        o_dv_1 = dtRemark.Rows[k]["dv_1"].ToString();
                        o_dv_2 = dtRemark.Rows[k]["dv_2"].ToString();
                        o_dv_3 = dtRemark.Rows[k]["dv_3"].ToString();
                        o_dv_4 = dtRemark.Rows[k]["dv_4"].ToString();
                        o_dv_5 = dtRemark.Rows[k]["dv_5"].ToString();
                        o_hubal_change_yn = dtRemark.Rows[k]["hubal_change_yn"].ToString();
                        o_pharmacy = dtRemark.Rows[k]["pharmacy"].ToString();
                        o_jusa_spd_gubun = dtRemark.Rows[k]["jusa_spd_gubun"].ToString();
                        o_drg_pack_yn = dtRemark.Rows[k]["drg_pack_yn"].ToString();
                        o_jusa = dtRemark.Rows[k]["jusa"].ToString();
                        o_jaeryo_name = dtRemark.Rows[k]["jaeryo_name"].ToString();
                        o_data_gubun = dtRemark.Rows[k]["data_gubun"].ToString();
                        o_hodong_ord_name = dtRemark.Rows[k]["hodong_ord_name"].ToString();
                        o_key = dtRemark.Rows[k]["key"].ToString();

                        rowNum = layJusaOrderPrint.InsertRow(-1);
                        layJusaOrderPrint.SetItemValue(rowNum, "bunho", o_bunho);
                        layJusaOrderPrint.SetItemValue(rowNum, "suname", o_suname);
                        layJusaOrderPrint.SetItemValue(rowNum, "suname2", o_suname2);
                        layJusaOrderPrint.SetItemValue(rowNum, "birth", o_birth);
                        layJusaOrderPrint.SetItemValue(rowNum, "age", o_sex_age);
                        layJusaOrderPrint.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                        layJusaOrderPrint.SetItemValue(rowNum, "ho_dong", o_ho_dong);
                        layJusaOrderPrint.SetItemValue(rowNum, "ho_code", o_ho_code);
                        layJusaOrderPrint.SetItemValue(rowNum, "magam_gubun", o_magam_gubun);
                        layJusaOrderPrint.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                        layJusaOrderPrint.SetItemValue(rowNum, "serial_v", o_serial_v);
                        layJusaOrderPrint.SetItemValue(rowNum, "resident_name", o_resident_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "jusa", o_jusa_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                        layJusaOrderPrint.SetItemValue(rowNum, "order_danui", o_order_danui_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "dv", o_dv);
                        layJusaOrderPrint.SetItemValue(rowNum, "subul_surang", o_subul_suryang);
                        layJusaOrderPrint.SetItemValue(rowNum, "subul_danui", o_subul_danui_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "order_remark", o_remark);
                        layJusaOrderPrint.SetItemValue(rowNum, "rp_barcode", o_rp_barcode);
                        layJusaOrderPrint.SetItemValue(rowNum, "order_date", o_order_date);
                        layJusaOrderPrint.SetItemValue(rowNum, "hope_date", o_hope_date);
                        layJusaOrderPrint.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                        layJusaOrderPrint.SetItemValue(rowNum, "jusa_nalsu", o_jusa_nalsu);
                        layJusaOrderPrint.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                        layJusaOrderPrint.SetItemValue(rowNum, "barcode", o_barcode);
                        layJusaOrderPrint.SetItemValue(rowNum, "print_gubun", o_print_gubun);
                        layJusaOrderPrint.SetItemValue(rowNum, "hodong_ord_name", o_hodong_ord_name);
                        layJusaOrderPrint.SetItemValue(rowNum, "sort_key", o_key);
                    }
                }
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message + "\n\r" + ex.StackTrace);
                return false;
            }
            return true;
        }
        #endregion

        #region [-- DsvJusaLabel --]
        /// <summary>
        /// dsvJusaLabel Service Conversion PC: DRGPRINT, WT:0
        /// </summary>
        /// <param name="jubsuDate"></param>
        /// <param name="drgBunho"></param>
        /// <returns></returns>
        private bool DsvJusaLabel(string jubsuDate, string drgBunho)
        {
            string o_fkocs2003 = string.Empty;
            string o_bunho = string.Empty;
            string o_fkinp1001 = string.Empty;
            string o_group_ser = string.Empty;
            string o_jubsu_date = string.Empty;
            string o_hope_date = string.Empty;
            string o_order_date = string.Empty;
            string o_drg_bunho = string.Empty;
            string o_ho_code = string.Empty;
            string o_ho_dong = string.Empty;
            string o_doctor = string.Empty;
            string o_resident = string.Empty;
            string o_gwa = string.Empty;
            string o_jaeryo_code = string.Empty;
            string o_jaeryo_gubun = string.Empty;
            string o_nalsu = string.Empty;
            string o_divide = string.Empty;
            string o_order_suryang = string.Empty;
            string o_subul_suryang = string.Empty;
            string o_ord_suryang = string.Empty;
            string o_order_danui = string.Empty;
            string o_subul_danui = string.Empty;
            string o_group_yn = string.Empty;
            string o_bunryu1 = string.Empty;
            string o_bunryu2 = string.Empty;
            string o_bunryu3 = string.Empty;
            string o_bunryu4 = string.Empty;
            string o_bogyong_code = string.Empty;
            string o_caution_code = string.Empty;
            string o_mix_yn = string.Empty;
            string o_atc_yn = string.Empty;
            string o_chulgo_buseo = string.Empty;
            string o_chulgo_date = string.Empty;
            string o_chulgo_qty = string.Empty;
            string o_chulgo_yn = string.Empty;
            string o_change_qty = string.Empty;
            string o_toiwon_drg_yn = string.Empty;
            string o_emergency = string.Empty;
            string o_drg_prn_yn = string.Empty;
            string o_drg_prn_time = string.Empty;
            string o_append_yn = string.Empty;
            string o_anti_cancer_yn = string.Empty;
            string o_tpn_yn = string.Empty;
            string o_self_gubun = string.Empty;
            string o_magam_gubun = string.Empty;
            string o_magam_ser = string.Empty;
            string o_dc_yn = string.Empty;
            string o_dc_confirm = string.Empty;
            string o_bannab_yn = string.Empty;
            string o_jundal_part = string.Empty;
            string o_source_fkocs2003 = string.Empty;
            string o_re_use_yn = string.Empty;
            string o_end_type = string.Empty;
            string o_remark = string.Empty;
            string o_input_gubun = string.Empty;
            string o_dv_time = string.Empty;
            string o_dv = string.Empty;
            string o_anti_soyu_yn = string.Empty;
            string o_wonyoi_order_yn = string.Empty;
            string o_wonnae_sayu_code = string.Empty;
            string o_wonyoi_act_yn = string.Empty;
            string o_inv_confirm = string.Empty;
            string o_ho_dong1 = string.Empty;
            string o_suak_jubsu_date = string.Empty;
            string o_suak_ser = string.Empty;
            string o_bunryu6 = string.Empty;
            string o_tpn_joje_gubun = string.Empty;
            string o_powder_yn = string.Empty;
            string o_jubsu_ilsi = string.Empty;
            string o_drg_prn_date = string.Empty;
            string o_er_magam_date = string.Empty;
            string o_er_magam_gubun = string.Empty;
            string o_er_magam_ser = string.Empty;
            string o_jundal_part_run = string.Empty;
            string o_iu_jusa_date = string.Empty;
            string o_mayak_print_yn = string.Empty;
            string o_fkdrg3011 = string.Empty;
            string o_out_bf_dc = string.Empty;
            string o_mix_group = string.Empty;
            string o_dv_1 = string.Empty;
            string o_dv_2 = string.Empty;
            string o_dv_3 = string.Empty;
            string o_dv_4 = string.Empty;
            string o_dv_5 = string.Empty;
            string o_hubal_change_yn = string.Empty;
            string o_pharmacy = string.Empty;
            string o_jusa_spd_gubun = string.Empty;
            string o_drg_pack_yn = string.Empty;
            string o_jusa = string.Empty;
            string o_jusa_name = string.Empty;

            string o_jaeryo_name = string.Empty;
            string o_bogyong_name = string.Empty;
            string o_order_danui_name = string.Empty;
            string o_subul_danui_name = string.Empty;
            string o_gwa_name = string.Empty;
            string o_doctor_name = string.Empty;
            string o_resident_name = string.Empty;
            string o_serial_v = string.Empty;
            string o_serial_text = string.Empty;

            string o_suname = string.Empty;
            string o_suname2 = string.Empty;
            string o_birth = string.Empty;
            string o_age = string.Empty;
            string o_rp_barcode = string.Empty;
            string o_danui_name = string.Empty;
            string o_data_gubun = string.Empty;
            string o_order_date_text = string.Empty;
            string o_sex_age = string.Empty;
            string o_rp2 = string.Empty;
            string o_cnt = string.Empty;
            string o_line = string.Empty;

            int InsertRow;
            int rowNum;

            DataTable dtLabel = new DataTable();
            DataTable dtSerial = new DataTable();
            DataTable dtRemark = new DataTable();

            string cmdText = "";
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_jubsu_date", jubsuDate);
            bindVars.Add("f_drg_bunho", drgBunho);
            bindVars.Add("f_hosp_code", mHospCode);

            /* DRGPRINT_I_JUSA_LABLE_CUR */
            cmdText = @"SELECT A.BUNHO                                             BUNHO
                              ,LTRIM(TO_CHAR(A.DRG_BUNHO))                         DRG_BUNHO
                              ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE )    ORDER_DATE_TEXT
                              ,TO_CHAR(A.JUBSU_DATE,'yyyy/MM/dd')                  JUBSU_DATE
                              ,TO_CHAR(A.HOPE_DATE,'yyyy/MM/dd')                   HOPE_DATE
                              ,TO_CHAR(A.ORDER_DATE,'yyyy/MM/dd')                  ORDER_DATE
                              ,'Rp.'||E.SERIAL_V||DECODE(A.MIX_GROUP,NULL,'',' M') SERIAL_V
                              ,E.SERIAL_V                                          SERIAL_TEXT
                              ,D.SUNAME                                            SUNAME
                              ,D.SUNAME2                                           SUNAME2
                              ,FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE)          SEX_AGE
                              ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'C'),1,20)      HO_CODE
                              ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)      HO_DONG
                              ,MAX(A.BOGYONG_CODE || ' ' || FN_OCS_LOAD_CODE_NAME('JUSA_SPD_GUBUN',NVL(A.JUSA_SPD_GUBUN,'0')))     BOGYONG_NAME
                              ,MAX(A.DV)                                           CNT
                          FROM DRG2035 E
                              ,OUT0101 D
                              ,DRG0120 C
                              ,INV0110 B
                              ,DRG3010 A
                         WHERE A.JUBSU_DATE         = :f_jubsu_date
                           AND A.DRG_BUNHO          = :f_drg_bunho
                           AND A.HOSP_CODE          = :f_hosp_code
                           AND A.BUNRYU1            = '4'
                           AND NVL(A.DC_YN,'N')     = 'N'
                           AND NVL(A.BANNAB_YN,'N') = 'N'
                           AND B.JAERYO_CODE     (+)= A.JAERYO_CODE
                           AND B.HOSP_CODE       (+)= A.HOSP_CODE
                           AND C.BOGYONG_CODE    (+)= A.BOGYONG_CODE
                           AND C.HOSP_CODE       (+)= A.HOSP_CODE
                           AND D.BUNHO              = A.BUNHO
                           AND D.HOSP_CODE          = A.HOSP_CODE
                           AND E.JUBSU_DATE         = A.JUBSU_DATE
                           AND E.DRG_BUNHO          = A.DRG_BUNHO
                           AND E.FKOCS2003          = A.FKOCS2003
                           AND E.HOSP_CODE          = A.HOSP_CODE
                         GROUP BY A.BUNHO
                              ,LTRIM(TO_CHAR(A.DRG_BUNHO))
                              ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.ORDER_DATE )
                              ,A.JUBSU_DATE
                              ,A.HOPE_DATE
                              ,A.ORDER_DATE
                              ,'Rp.'||E.SERIAL_V||DECODE(A.MIX_GROUP,NULL,'',' M')
                              ,E.SERIAL_V
                              ,D.SUNAME
                              ,D.SUNAME2
                              ,FN_OCS_LOAD_SEX_AGE(A.BUNHO, A.ORDER_DATE)
                              ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'C'),1,20)      
                              ,substrb(FN_DRG_HO_DONG(A.FKINP1001, trunc(sysdate), 'D'),1,20)
                         ORDER BY LTRIM(TO_CHAR(E.SERIAL_V, '0000'))";
            try
            {
                dtLabel = Service.ExecuteDataTable(cmdText, bindVars);

                for (int i = 0; i < dtLabel.Rows.Count; i++)
                {
                    o_bunho = dtLabel.Rows[i]["bunho"].ToString();
                    o_drg_bunho = dtLabel.Rows[i]["drg_bunho"].ToString();
                    o_order_date_text = dtLabel.Rows[i]["order_date_text"].ToString();
                    o_jubsu_date = dtLabel.Rows[i]["jubsu_date"].ToString();
                    o_hope_date = dtLabel.Rows[i]["hope_date"].ToString();
                    o_order_date = dtLabel.Rows[i]["order_date"].ToString();
                    o_serial_v = dtLabel.Rows[i]["serial_v"].ToString();
                    o_serial_text = dtLabel.Rows[i]["serial_text"].ToString();
                    o_suname = dtLabel.Rows[i]["suname"].ToString();
                    o_suname2 = dtLabel.Rows[i]["suname2"].ToString();
                    o_sex_age = dtLabel.Rows[i]["sex_age"].ToString();
                    o_ho_code = dtLabel.Rows[i]["ho_code"].ToString();
                    o_ho_dong = dtLabel.Rows[i]["ho_dong"].ToString();
                    o_bogyong_name = dtLabel.Rows[i]["bogyong_name"].ToString();
                    o_cnt = dtLabel.Rows[i]["cnt"].ToString();

                    InsertRow = int.Parse(o_cnt);

                    bindVars.Remove("f_serial_text");
                    bindVars.Add("f_serial_text", o_serial_text);
                    bindVars.Remove("f_cnt");
                    bindVars.Add("f_cnt", o_cnt);

                    layJusaLable.Reset();

                    for (int k = 1; k <= InsertRow; k++)
                    {
                        bindVars.Remove("k");
                        bindVars.Add("k", k.ToString());
                        cmdText = @"SELECT A.JAERYO_CODE                                        JAERYO_CODE
                                         , A.NALSU                                              NALSU
                                         , A.DIVIDE                                             DIVIDE
                                         , A.ORDER_SURYANG                                      ORDER_SURYANG
                                         , A.SUBUL_SURYANG                                      SUBUL_SURYANG
                                         , A.ORD_SURYANG                                        ORD_SURYANG
                                         , A.ORDER_DANUI                                        ORDER_DANUI
                                         , A.SUBUL_DANUI                                        SUBUL_DANUI
                                         , A.BUNRYU1                                            BUNRYU1
                                         , A.BUNRYU2                                            BUNRYU2
                                         , A.BUNRYU3                                            BUNRYU3
                                         , A.BUNRYU4                                            BUNRYU4
                                         , A.REMARK                                             REMARK
                                         , A.DV_TIME                                            DV_TIME
                                         , A.DV                                                 DV
                                         , A.BUNRYU6                                            BUNRYU6
                                         , A.MIX_GROUP                                          MIX_GROUP
                                         , A.DV_1                                               DV_1
                                         , A.DV_2                                               DV_2
                                         , A.DV_3                                               DV_3
                                         , A.DV_4                                               DV_4
                                         , A.DV_5                                               DV_5
                                         , A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN
                                         , A.PHARMACY                                           PHARMACY
                                         , A.JUSA_SPD_GUBUN                                     JUSA_SPD_GUBUN
                                         , A.DRG_PACK_YN                                        DRG_PACK_YN
                                         , A.JUSA                                               JUSA
                                         , B.HANGMOG_NAME                                       JAERYO_NAME
                                         , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI)    DANUI_NAME
                                         , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI)    SUBUL_DANUI_NAME
                                         , FN_OCS_LOAD_CODE_NAME('JUSA',NVL(A.JUSA,'0'))        JUSA_NAME
                                         , TO_CHAR(:k) || '/' || TO_CHAR(:f_cnt)                RP2
                                         , '*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD')||TO_CHAR(A.DRG_BUNHO)||E.SERIAL_V||TO_CHAR(:k)||'*' BARCODE_NO
                                         , 'A'                                                  DATA_GUBUN
                                    FROM DRG2035 E
                                       , OCS2003 C
                                       , OCS0103 B
                                       , DRG3010 A
                                    WHERE A.JUBSU_DATE         = :f_jubsu_date
                                      AND A.DRG_BUNHO          = :f_drg_bunho
                                      AND A.HOSP_CODE          = :f_hosp_code
                                      AND A.DIVIDE            >= :k 
                                      AND A.BUNRYU1            IN ('4')
                                      AND NVL(A.DC_YN,'N')     = 'N'
                                      AND NVL(A.BANNAB_YN,'N') = 'N'
                                      AND B.HANGMOG_CODE       = C.HANGMOG_CODE
                                      AND B.HOSP_CODE          = C.HOSP_CODE
                                      AND C.PKOCS2003          = A.FKOCS2003
                                      AND C.HOSP_CODE          = A.HOSP_CODE
                                      AND E.JUBSU_DATE         = A.JUBSU_DATE
                                      AND E.DRG_BUNHO          = A.DRG_BUNHO
                                      AND E.FKOCS2003          = A.FKOCS2003
                                      AND E.HOSP_CODE          = A.HOSP_CODE
                                      AND E.SERIAL_V           = :f_serial_text
                                      AND C.ORDER_DATE       BETWEEN   B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
                                    ORDER BY LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||
                                             LTRIM(TO_CHAR(DECODE(C.BOM_OCCUR_YN, 'Y', C.SEQ + 100, C.SEQ), '0000'))||
                                             LTRIM(TO_CHAR(C.PKOCS2003, '0000000000'))";

                        dtSerial = Service.ExecuteDataTable(cmdText, bindVars);

                        for (int j = 0; j < dtSerial.Rows.Count; j++)
                        {
                            o_jaeryo_code = dtSerial.Rows[j]["jaeryo_code"].ToString();
                            o_nalsu = dtSerial.Rows[j]["nalsu"].ToString();
                            o_divide = dtSerial.Rows[j]["divide"].ToString();
                            o_order_suryang = dtSerial.Rows[j]["order_suryang"].ToString();
                            o_subul_suryang = dtSerial.Rows[j]["subul_suryang"].ToString();
                            o_ord_suryang = dtSerial.Rows[j]["ord_suryang"].ToString();
                            o_order_danui = dtSerial.Rows[j]["order_danui"].ToString();
                            o_subul_danui = dtSerial.Rows[j]["subul_danui"].ToString();
                            o_bunryu1 = dtSerial.Rows[j]["bunryu1"].ToString();
                            o_bunryu2 = dtSerial.Rows[j]["bunryu2"].ToString();
                            o_bunryu3 = dtSerial.Rows[j]["bunryu3"].ToString();
                            o_bunryu4 = dtSerial.Rows[j]["bunryu4"].ToString();
                            o_remark = dtSerial.Rows[j]["remark"].ToString();
                            o_dv_time = dtSerial.Rows[j]["dv_time"].ToString();
                            o_dv = dtSerial.Rows[j]["dv"].ToString();
                            o_bunryu6 = dtSerial.Rows[j]["bunryu6"].ToString();
                            o_mix_group = dtSerial.Rows[j]["mix_group"].ToString();
                            o_dv_1 = dtSerial.Rows[j]["dv_1"].ToString();
                            o_dv_2 = dtSerial.Rows[j]["dv_2"].ToString();
                            o_dv_3 = dtSerial.Rows[j]["dv_3"].ToString();
                            o_dv_4 = dtSerial.Rows[j]["dv_4"].ToString();
                            o_dv_5 = dtSerial.Rows[j]["dv_5"].ToString();
                            o_hubal_change_yn = dtSerial.Rows[j]["hubal_change_yn"].ToString();
                            o_pharmacy = dtSerial.Rows[j]["pharmacy"].ToString();
                            o_jusa_spd_gubun = dtSerial.Rows[j]["jusa_spd_gubun"].ToString();
                            o_drg_pack_yn = dtSerial.Rows[j]["drg_pack_yn"].ToString();
                            o_jusa = dtSerial.Rows[j]["jusa"].ToString();
                            o_jaeryo_name = dtSerial.Rows[j]["jaeryo_name"].ToString();
                            o_order_danui_name = dtSerial.Rows[j]["danui_name"].ToString();
                            o_subul_danui_name = dtSerial.Rows[j]["subul_danui_name"].ToString();
                            o_jusa_name = dtSerial.Rows[j]["jusa_name"].ToString();
                            o_rp2 = dtSerial.Rows[j]["rp2"].ToString();
                            o_rp_barcode = dtSerial.Rows[j]["barcode_no"].ToString();
                            o_data_gubun = dtSerial.Rows[j]["data_gubun"].ToString();

                            rowNum = layJusaLable.InsertRow(-1);
                            o_line = (rowNum + 1).ToString();

                            layJusaLable.SetItemValue(rowNum, "bunho", o_bunho);
                            layJusaLable.SetItemValue(rowNum, "suname", o_suname);
                            layJusaLable.SetItemValue(rowNum, "suname2", o_suname2);
                            layJusaLable.SetItemValue(rowNum, "birth", o_birth);
                            layJusaLable.SetItemValue(rowNum, "age", o_sex_age);
                            layJusaLable.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                            layJusaLable.SetItemValue(rowNum, "ho_dong", o_ho_dong);
                            layJusaLable.SetItemValue(rowNum, "ho_code", o_ho_code);
                            layJusaLable.SetItemValue(rowNum, "magam_gubun", o_magam_gubun);
                            layJusaLable.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                            layJusaLable.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                            layJusaLable.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                            layJusaLable.SetItemValue(rowNum, "serial_v", o_serial_v);
                            layJusaLable.SetItemValue(rowNum, "resident_name", o_resident_name);
                            layJusaLable.SetItemValue(rowNum, "jusa", o_jusa_name);
                            layJusaLable.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                            layJusaLable.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                            layJusaLable.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                            layJusaLable.SetItemValue(rowNum, "order_danui", o_order_danui_name);
                            layJusaLable.SetItemValue(rowNum, "dv", o_dv);
                            layJusaLable.SetItemValue(rowNum, "subul_surang", o_subul_suryang);
                            layJusaLable.SetItemValue(rowNum, "subul_danui", o_subul_danui);
                            layJusaLable.SetItemValue(rowNum, "order_remark", o_remark);
                            layJusaLable.SetItemValue(rowNum, "rp_barcode", o_rp_barcode);
                            layJusaLable.SetItemValue(rowNum, "order_date", o_order_date);
                            layJusaLable.SetItemValue(rowNum, "hope_date", o_hope_date);
                            layJusaLable.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                            layJusaLable.SetItemValue(rowNum, "rp2", o_rp2);
                            layJusaLable.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                            layJusaLable.SetItemValue(rowNum, "line", o_line);
                        }

                        // COMMENT --------------------------------------------------------------------------->
                        cmdText = @"SELECT A.JAERYO_CODE                                        JAERYO_CODE
                                         , A.NALSU                                              NALSU
                                         , A.DIVIDE                                             DIVIDE
                                         , A.ORDER_SURYANG                                      ORDER_SURYANG
                                         , A.SUBUL_SURYANG                                      SUBUL_SURYANG
                                         , A.ORD_SURYANG                                        ORD_SURYANG
                                         , A.ORDER_DANUI                                        ORDER_DANUI
                                         , A.SUBUL_DANUI                                        SUBUL_DANUI
                                         , A.BUNRYU1                                            BUNRYU1
                                         , A.BUNRYU2                                            BUNRYU2
                                         , A.BUNRYU3                                            BUNRYU3
                                         , A.BUNRYU4                                            BUNRYU4
                                         , A.REMARK                                             REMARK
                                         , A.DV_TIME                                            DV_TIME
                                         , A.DV                                                 DV
                                         , A.BUNRYU6                                            BUNRYU6
                                         , A.MIX_GROUP                                          MIX_GROUP
                                         , A.DV_1                                               DV_1
                                         , A.DV_2                                               DV_2
                                         , A.DV_3                                               DV_3
                                         , A.DV_4                                               DV_4
                                         , A.DV_5                                               DV_5
                                         , A.HUBAL_CHANGE_YN                                    HUBAL_CHANGE_YN
                                         , A.PHARMACY                                           PHARMACY
                                         , A.JUSA_SPD_GUBUN                                     JUSA_SPD_GUBUN
                                         , A.DRG_PACK_YN                                        DRG_PACK_YN
                                         , A.JUSA                                               JUSA
                                         , B.HANGMOG_NAME                                       JAERYO_NAME
                                         , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORDER_DANUI)    DANUI_NAME
                                         , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.SUBUL_DANUI)    SUBUL_DANUI_NAME
                                         , FN_OCS_LOAD_CODE_NAME('JUSA',NVL(A.JUSA,'0'))        JUSA_NAME
                                         , TO_CHAR(:k) || '/' || TO_CHAR(:f_cnt)                RP2
                                         , '*'||TO_CHAR(A.JUBSU_DATE,'YYYYMMDD')||TO_CHAR(A.DRG_BUNHO)||E.SERIAL_V||TO_CHAR(:k)||'*' BARCODE_NO
                                         , 'B'                                                  DATA_GUBUN
                                    FROM DRG2035 E
                                       , OCS2003 C
                                       , OCS0103 B
                                       , DRG3010 A
                                    WHERE A.HOSP_CODE          = :f_hosp_code
                                      AND A.JUBSU_DATE         = :f_jubsu_date
                                      AND A.DRG_BUNHO          = :f_drg_bunho
                                      AND A.DIVIDE            >= :k 
                                      AND A.BUNRYU1            IN ('4')
                                      AND NVL(A.DC_YN,'N')     = 'N'
                                      AND NVL(A.BANNAB_YN,'N') = 'N'
                                      AND B.HOSP_CODE          = C.HOSP_CODE 
                                      AND B.HANGMOG_CODE       = C.HANGMOG_CODE
                                      AND C.HOSP_CODE          = A.HOSP_CODE 
                                      AND C.PKOCS2003          = A.FKOCS2003
                                      AND E.HOSP_CODE          = A.HOSP_CODE 
                                      AND E.JUBSU_DATE         = A.JUBSU_DATE
                                      AND E.DRG_BUNHO          = A.DRG_BUNHO
                                      AND E.FKOCS2003          = A.FKOCS2003
                                      AND E.SERIAL_V           = :f_serial_text
                                      AND C.ORDER_DATE         BETWEEN   B.START_DATE AND NVL(B.END_DATE, '9998/12/31')
                                    ORDER BY LTRIM(TO_CHAR(E.SERIAL_V, '0000'))|| LTRIM(TO_CHAR(A.GROUP_SER, '0000'))||NVL(A.MIX_GROUP, ' ')||
                                             LTRIM(TO_CHAR(DECODE(C.BOM_OCCUR_YN, 'Y', C.SEQ + 100, C.SEQ), '0000'))||
                                             LTRIM(TO_CHAR(C.PKOCS2003, '0000000000'))";

                        dtRemark = Service.ExecuteDataTable(cmdText, bindVars);

                        for (int j = 0; j < dtRemark.Rows.Count; j++)
                        {
                            o_jaeryo_code = dtRemark.Rows[j]["jaeryo_code"].ToString();
                            o_nalsu = dtRemark.Rows[j]["nalsu"].ToString();
                            o_divide = dtRemark.Rows[j]["divide"].ToString();
                            o_order_suryang = dtRemark.Rows[j]["order_suryang"].ToString();
                            o_subul_suryang = dtRemark.Rows[j]["subul_suryang"].ToString();
                            o_ord_suryang = dtRemark.Rows[j]["ord_suryang"].ToString();
                            o_order_danui = dtRemark.Rows[j]["order_danui"].ToString();
                            o_subul_danui = dtRemark.Rows[j]["subul_danui"].ToString();
                            o_bunryu1 = dtRemark.Rows[j]["bunryu1"].ToString();
                            o_bunryu2 = dtRemark.Rows[j]["bunryu2"].ToString();
                            o_bunryu3 = dtRemark.Rows[j]["bunryu3"].ToString();
                            o_bunryu4 = dtRemark.Rows[j]["bunryu4"].ToString();
                            o_remark = dtRemark.Rows[j]["remark"].ToString();
                            o_dv_time = dtRemark.Rows[j]["dv_time"].ToString();
                            o_dv = dtRemark.Rows[j]["dv"].ToString();
                            o_bunryu6 = dtRemark.Rows[j]["bunryu6"].ToString();
                            o_mix_group = dtRemark.Rows[j]["mix_group"].ToString();
                            o_dv_1 = dtRemark.Rows[j]["dv_1"].ToString();
                            o_dv_2 = dtRemark.Rows[j]["dv_2"].ToString();
                            o_dv_3 = dtRemark.Rows[j]["dv_3"].ToString();
                            o_dv_4 = dtRemark.Rows[j]["dv_4"].ToString();
                            o_dv_5 = dtRemark.Rows[j]["dv_5"].ToString();
                            o_hubal_change_yn = dtRemark.Rows[j]["hubal_change_yn"].ToString();
                            o_pharmacy = dtRemark.Rows[j]["pharmacy"].ToString();
                            o_jusa_spd_gubun = dtRemark.Rows[j]["jusa_spd_gubun"].ToString();
                            o_drg_pack_yn = dtRemark.Rows[j]["drg_pack_yn"].ToString();
                            o_jusa = dtRemark.Rows[j]["jusa"].ToString();
                            o_jaeryo_name = dtRemark.Rows[j]["jaeryo_name"].ToString();
                            o_order_danui_name = dtRemark.Rows[j]["danui_name"].ToString();
                            o_subul_danui_name = dtRemark.Rows[j]["subul_danui_name"].ToString();
                            o_jusa_name = dtRemark.Rows[j]["jusa_name"].ToString();
                            o_rp2 = dtRemark.Rows[j]["rp2"].ToString();
                            o_rp_barcode = dtRemark.Rows[j]["barcode_no"].ToString();
                            o_data_gubun = dtRemark.Rows[j]["data_gubun"].ToString();

                            rowNum = layJusaLable.InsertRow(-1);
                            o_line = (rowNum + 1).ToString();

                            layJusaLable.SetItemValue(rowNum, "bunho", o_bunho);
                            layJusaLable.SetItemValue(rowNum, "suname", o_suname);
                            layJusaLable.SetItemValue(rowNum, "suname2", o_suname2);
                            layJusaLable.SetItemValue(rowNum, "birth", o_birth);
                            //layJusaLable.SetItemValue(rowNum, "age", o_age);
                            layJusaLable.SetItemValue(rowNum, "age", o_sex_age);
                            layJusaLable.SetItemValue(rowNum, "drg_bunho", o_drg_bunho);
                            layJusaLable.SetItemValue(rowNum, "ho_dong", o_ho_dong);
                            layJusaLable.SetItemValue(rowNum, "ho_code", o_ho_code);
                            layJusaLable.SetItemValue(rowNum, "magam_gubun", o_magam_gubun);
                            layJusaLable.SetItemValue(rowNum, "gwa_name", o_gwa_name);
                            layJusaLable.SetItemValue(rowNum, "doctor_name", o_doctor_name);
                            layJusaLable.SetItemValue(rowNum, "jubsu_date", o_jubsu_date);
                            layJusaLable.SetItemValue(rowNum, "serial_v", o_serial_v);
                            layJusaLable.SetItemValue(rowNum, "resident_name", o_resident_name);
                            layJusaLable.SetItemValue(rowNum, "jusa", o_jusa_name);
                            layJusaLable.SetItemValue(rowNum, "jaeryo_name", o_jaeryo_name);
                            layJusaLable.SetItemValue(rowNum, "bogyong_name", o_bogyong_name);
                            layJusaLable.SetItemValue(rowNum, "ord_surang", o_ord_suryang);
                            layJusaLable.SetItemValue(rowNum, "order_danui", o_order_danui_name);
                            layJusaLable.SetItemValue(rowNum, "dv", o_dv);
                            layJusaLable.SetItemValue(rowNum, "subul_surang", o_subul_suryang);
                            layJusaLable.SetItemValue(rowNum, "subul_danui", o_subul_danui);
                            layJusaLable.SetItemValue(rowNum, "order_remark", o_remark);
                            layJusaLable.SetItemValue(rowNum, "rp_barcode", o_rp_barcode);
                            layJusaLable.SetItemValue(rowNum, "order_date", o_order_date);
                            layJusaLable.SetItemValue(rowNum, "hope_date", o_hope_date);
                            layJusaLable.SetItemValue(rowNum, "order_suryang", o_order_suryang);
                            layJusaLable.SetItemValue(rowNum, "rp2", o_rp2);
                            layJusaLable.SetItemValue(rowNum, "data_gubun", o_data_gubun);
                            layJusaLable.SetItemValue(rowNum, "line", o_line);
                        }

                        this.thirdChkProc(o_hope_date, o_rp_barcode.Replace("*", ""));
                    }
                    // 오다 내역 조회
                    //dw_lable.Reset();
                    //dw_lable.FillData(layJusaLable.LayoutTable);
                    //if (dw_lable.RowCount > 0) dw_lable.Print();
                }
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message + "\n\r" + ex.StackTrace);
                return false;
            }
            return true;
        }
        #endregion

        #region 3点チェックの出庫、入庫処理
        private void thirdChkProc(string hopeDate, string barcode)
        {
            if (TypeCheck.IsNull(barcode)) return;

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            // 出庫処理
            inputList.Add(barcode);
            inputList.Add("I");
            inputList.Add(this.cbxActor.GetDataValue());
            inputList.Add(hopeDate);
            inputList.Add("DRG");
            inputList.Add("");

            if (!Service.ExecuteProcedure("PR_DRG_MAKE_BARCODE", inputList, outputList))
            {
                XMessageBox.Show("出庫処理が失敗しました。", Resources.caption, MessageBoxIcon.Error);
                return;
            }

            inputList.Clear();
            outputList.Clear();

            // 入庫処理
            inputList.Add(barcode);
            inputList.Add("I");
            inputList.Add(this.cbxActor.GetDataValue());
            inputList.Add(hopeDate);
            inputList.Add("NRI");
            inputList.Add("");

            if (!Service.ExecuteProcedure("PR_DRG_MAKE_BARCODE", inputList, outputList))
            {
                XMessageBox.Show("入庫処理が失敗しました。", Resources.caption, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        private void btnMagamStop_Click(object sender, System.EventArgs e)
        {

            //if (XMessageBox.Show("自動出力を中止しますか?", "出力中止", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
                //tmMagam.Stop();

                //btnMagamStart.Enabled = true;
                //btnMagamStop.Enabled = false;

                btnMagamStops.ImageIndex = 1;
                btnMagamStarts.ImageIndex = 3;

                btnMagamStarts.Font = new Font(btnMagamStops.Font, FontStyle.Regular);
                btnMagamStarts.Scheme = XButtonSchemes.Silver;
                btnMagamStops.Font = new Font(btnMagamStops.Font, FontStyle.Bold);
                btnMagamStops.Scheme = XButtonSchemes.HotPink;

                //btnMagamStart.ForeColor = Color.Gray;
                //btnMagamStop.ForeColor = Color.Green;

                tabControl.SelectedIndex = 0;
            //}
        }

        private void btnMagamStart_Click(object sender, System.EventArgs e)
        {

            if (XMessageBox.Show("自動出力を実行しますか？ プリンターをご確認ください。", Resources.caption, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                btnMagamStops.ImageIndex = 3;
                btnMagamStarts.ImageIndex = 4;

                btnMagamStarts.Font = new Font(btnMagamStarts.Font, FontStyle.Bold);
                btnMagamStarts.Scheme = XButtonSchemes.Green;
                btnMagamStops.Font = new Font(btnMagamStops.Font, FontStyle.Regular);
                btnMagamStops.Scheme = XButtonSchemes.Silver;

                tabControl.SelectedIndex = 1;
            }
        }

        private void grdList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            // 出庫日付の表示
            if ((this.grdList.GetItemString(e.RowNumber, "mix_date") != "") &&
                (this.grdList.GetItemString(e.RowNumber, "jusa_yn") == "Y"))
                e.BackColor = Color.Khaki;
        }

        private void grdList_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            string jusa_yn = "N";

            this.grdMagamJUSAOrder.Reset();
            this.grdMagamOrder.Reset();

            jusa_yn = this.grdList.GetItemString(this.grdList.CurrentRowNumber, "jusa_yn");

            //내복, 외용
            if (jusa_yn == "N")
            {
                this.grdMagamOrder.Visible = true;
                this.grdMagamJUSAOrder.Visible = false;
                if (!this.grdMagamOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
            //주사
            if (jusa_yn == "Y")
            {
                this.grdMagamOrder.Visible = false;
                this.grdMagamJUSAOrder.Visible = true;
                if (!this.grdMagamJUSAOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
        }

        private bool DrgCancelCheck(string aDrgBunho, string aJubsu_date)
        {
            BindVarCollection bindVal = new BindVarCollection();
            object retVal = null;

            string cmd = "";

            cmd = @"SELECT FKOCS2003 
                      FROM DRG3010
                     WHERE DRG_BUNHO  = :f_drg_bunho
                       AND JUBSU_DATE = :f_jubsu_date";

            bindVal.Add("f_drg_bunho", aDrgBunho);
            bindVal.Add("f_jubsu_date", aJubsu_date);

            DataTable dt = new DataTable();

            dt = Service.ExecuteDataTable(cmd, bindVal);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bindVal.Clear();

                cmd = @" SELECT NVL(FN_OCS_CHECK_DETAIL_MAX_ACTING(A.FKOCS2003, NVL(HOPE_DATE, ORDER_DATE)),0)
                       FROM DRG3010 A
                      WHERE A.FKOCS2003 = :f_fkocs2003";

                bindVal.Add("f_fkocs2003", dt.Rows[i]["fkocs2003"].ToString());

                retVal = Service.ExecuteScalar(cmd, bindVal);


                if (retVal.ToString() != "0")
                    return false;
            }
            return true;
        }

        #region [btnCancel_Click 投薬番号別取消]
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            string drg_bunho = "", jubsu_date = "";

            if (grdList.CurrentRowNumber < 0) return;

            // 3P CHECK
            //if (this.isThirdChk(grdList.GetItemString(grdList.CurrentRowNumber, "bunho"), grdList.GetItemString(grdList.CurrentRowNumber, "order_date")) == true)
            //{
            //    XMessageBox.Show("既に出庫されています[3P CHECK]。　取消できません。", "確認", MessageBoxIcon.Information);
            //    return;
            //}

            if (this.grdList.GetItemString(this.grdList.CurrentRowNumber, "mix_date") != "")
            {
                XMessageBox.Show(Resources.XMessageBox3, Resources.caption, MessageBoxIcon.Information);
                return;
            }

            jubsu_date = grdList.GetItemString(grdList.CurrentRowNumber, "jubsu_date");
            drg_bunho = grdList.GetItemString(grdList.CurrentRowNumber, "drg_bunho");

            if (!DrgCancelCheck(drg_bunho, jubsu_date))
            {
                XMessageBox.Show(Resources.XMessageBox4, Resources.caption, MessageBoxIcon.Warning);
                return;
            }

            if (XMessageBox.Show(Resources.XMessageBox5, Resources.XMessageBox_caption5, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ArrayList inputList = new ArrayList();
                inputList.Add(jubsu_date);
                inputList.Add(drg_bunho);
                inputList.Add(UserInfo.UserID);

                ArrayList outputList = new ArrayList();
                
                try
                {
                    if (!Service.ExecuteProcedure("PR_DRG_INP_DRG_BUNHO_CANCEL", inputList, outputList))
                    {
                        XMessageBox.Show(outputList[0].ToString());
                    }
                    else
                    {
                        if (outputList[0].ToString() == "1")
                        {
                            XMessageBox.Show(Resources.XMessageBox6, Resources.caption, MessageBoxIcon.Warning);
                            return;
                        }

                        if (outputList[0].ToString() == "X")
                        {
                            XMessageBox.Show(Resources.XMessageBox7, Resources.caption, MessageBoxIcon.Warning);
                            return;
                        }

                        if (outputList[0].ToString() == "Y")
                        {
                            XMessageBox.Show(Resources.XMessageBox8, Resources.caption, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    #region [3点チェックデータ削除処理]
                    if (this.grdList.GetItemString(this.grdList.CurrentRowNumber, "jusa_yn") == "Y")
                    {
                        BindVarCollection bindVals = new BindVarCollection();

                        string cmdText = "";

                        bindVals.Clear();
                        bindVals.Add("f_hosp_code", EnvironInfo.HospCode);
                        bindVals.Add("f_jubsu_date", jubsu_date);
                        bindVals.Add("f_drg_bunho", drg_bunho);

                        cmdText = @"DELETE DRG3041 A
                                 WHERE A.HOSP_CODE  = :f_hosp_code
                                   AND A.JUBSU_DATE = :f_jubsu_date
                                   AND A.DRG_BUNHO  = :f_drg_bunho";

                        if (!Service.ExecuteNonQuery(cmdText, bindVals))
                        {
                            throw new Exception(Service.ErrFullMsg);
                        }
                    }
                    #endregion

                    grdList.Reset();
                    grdMagamOrder.Reset();
                    grdMagamJUSAOrder.Reset();

                    if (!grdList.QueryLayout(false)) throw new Exception(Service.ErrFullMsg);
                }
                catch (Exception xe)
                {
                    XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                    return;
                }
            }
        }
        #endregion

        #region [3点チェック実施可否チェック]
        private bool isThirdChk(string bunho, string orderDate)
        {
            string strCmd = "";

            BindVarCollection bindVar = new BindVarCollection();

            bindVar.Add("f_bunho", bunho);
            bindVar.Add("f_orderDate", orderDate);

            strCmd = @"select FN_DRG_CHULGO_DATE('I', :f_bunho, :f_orderDate) from dual";

            object result = Service.ExecuteScalar(strCmd, bindVar);

            if (TypeCheck.IsNull(result.ToString()))
            {
                return false;
            }
            else return true;
            
        }
         #endregion

        private void btnRePrint_Click(object sender, System.EventArgs e)
        {
            string drg_bunho = "", jubsu_date = "";

            string jusa_yn = "";
            jusa_yn = grdList.GetItemString(grdList.CurrentRowNumber, "jusa_yn");

            //내복, 외용
            if (jusa_yn == "N")
            {
                if (grdMagamOrder.CurrentRowNumber < 0) return;
                jubsu_date = grdMagamOrder.GetItemString(grdMagamOrder.CurrentRowNumber, "jubsu_date");
                drg_bunho = grdMagamOrder.GetItemString(grdMagamOrder.CurrentRowNumber, "drg_bunho");
            }
            //주사
            if (jusa_yn == "Y")
            {
                if (grdMagamJUSAOrder.CurrentRowNumber < 0) return;
                jubsu_date = grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "jubsu_date");
                drg_bunho = grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "drg_bunho");
            }

            DrgPrint(jubsu_date, drg_bunho, jusa_yn, "R", "");
        }

        private void btnDcRePrint_Click(object sender, EventArgs e)
        {
            string drg_bunho = "", jubsu_date = "";

            string jusa_yn = "";
            jusa_yn = this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "jusa_yn");

            //내복, 외용
            if (jusa_yn == "N")
            {
                if (this.grdDcOrder.CurrentRowNumber < 0) return;
                jubsu_date = this.grdDcOrder.GetItemString(this.grdDcOrder.CurrentRowNumber, "jubsu_date");
                drg_bunho = this.grdDcOrder.GetItemString(this.grdDcOrder.CurrentRowNumber, "drg_bunho");
            }
            //주사
            if (jusa_yn == "Y")
            {
                if (this.grdJusaDcOrder.CurrentRowNumber < 0) return;
                jubsu_date = this.grdJusaDcOrder.GetItemString(this.grdJusaDcOrder.CurrentRowNumber, "jubsu_date");
                drg_bunho = this.grdJusaDcOrder.GetItemString(this.grdJusaDcOrder.CurrentRowNumber, "drg_bunho");
            }

            this.DrgPrint(jubsu_date, drg_bunho, jusa_yn, "R", "");
        }

        private void DrgPrint(string ar_JubsuDate, string ar_DrgBunho, string ar_JusaGubun, string ar_Print_Gubun, string ar_Magam_gubun)
        {
            //int row;

            //내복, 외용
            if (ar_JusaGubun == "N")
            {
                #region 약국용 처방전
                //A4 用　d_drg3010_1（dw_1　＋　dw_2）
                //dw_print.DataWindowObject = "d_drg3010_1";
   //             dw_print.DataWindowObject = "d_drg3010_order";
                
   //             dw_print.Reset();

                // 오다 내역 조회
                //if (DsvOrderPrint(ar_JubsuDate, ar_DrgBunho, ar_Print_Gubun))
                //    //dw_print.FillChildData("dw_1", layOrderPrint.LayoutTable);
                //    dw_print.FillData(layOrderPrint.LayoutTable);
                //else
                //    return;

                //// comment 조회
                //if (DsvOrderJungbo(ar_JubsuDate, ar_DrgBunho))
                //{
                //    dw_print.FillChildData("dw_2", layOrderJungbo.LayoutTable);
                //}

                //if (layOrderJungbo.RowCount < 1)
                //{
                //    row = layOrderJungbo.InsertRow(0);
                //    layOrderJungbo.SetItemValue(row, "bar_drg_bunho", ar_JubsuDate.Replace("/", "") + ar_DrgBunho);
                //    dw_print.FillChildData("dw_2", layOrderJungbo.LayoutTable);
                //}

                //dw_print.AcceptText();
                //if (dw_print.RowCount > 0)
                //{
                //    dw_print.Print();
                //    //dw_print.Print();
                //}
        //        else
         //           return;
                #endregion

                #region 병동용 처방전
                //// A4 用　d_drg3010_1_ho_dong（dw_1　＋　dw_2）
                ////dw_print.DataWindowObject = "d_drg3010_1_ho_dong";
                //dw_print.DataWindowObject = "d_drg3010_order_ho_dong";

                //dw_print.Reset();

                //dw_print.FillData(layOrderPrint.LayoutTable);

                ////// 오다 내역 조회
                ////dw_print.FillChildData("dw_1", layOrderPrint.LayoutTable);

                ////// comment 조회
                //////if (DsvOrderBarcode(ar_JubsuDate, ar_DrgBunho))
                //////{
                //////    dw_print.FillChildData("dw_2", layOrderBarcode.LayoutTable);
                //////}
                ////// comment 조회
                ////dw_print.FillChildData("dw_2", layOrderJungbo.LayoutTable);
                
                //dw_print.AcceptText();
                //if (dw_print.RowCount > 0)
                //    dw_print.Print();
                //else
                //    return;
                #endregion

                return;
            }


            //주사
            if (ar_JusaGubun == "Y")
            {
                #region 약국용 처방전
                //A4 用　d_drg3010_4（dw_1　＋　dw_2）
                //dw_jusa.DataWindowObject = "d_drg3010_4";
      //          dw_jusa.DataWindowObject = "d_drg3010_jusa";

      //          dw_jusa.Reset();

                // 오다 내역 조회
       //         if (DsvJusaOrderPrint(ar_JubsuDate, ar_DrgBunho, ar_Print_Gubun))
                    //dw_jusa.FillChildData("dw_1", layJusaOrderPrint.LayoutTable);
       //             dw_jusa.FillData(layJusaOrderPrint.LayoutTable);
      //          else
      //              return;

                //// comment 조회
                //if (DsvOrderJungbo(ar_JubsuDate, ar_DrgBunho))
                //{
                //    dw_jusa.FillChildData("dw_2", layOrderJungbo.LayoutTable);
                //}

                //if (layOrderJungbo.RowCount < 1)
                //{
                //    row = layOrderJungbo.InsertRow(0);
                //    layOrderJungbo.SetItemValue(row, "bar_drg_bunho", ar_JubsuDate.Replace("/", "") + ar_DrgBunho);
                //    dw_print.FillChildData("dw_2", layOrderJungbo.LayoutTable);
                //}

                //dw_jusa.AcceptText();
                //if (dw_jusa.RowCount > 0)
                //    dw_jusa.Print();
                //else
                //    return;

                #endregion

                #region 병동용 처방전
                ////dw_jusa.DataWindowObject = "d_drg3010_jusa_ho_dong_all";
                //dw_jusa.DataWindowObject = "d_drg3010_jusa_ho_dong";

                //dw_jusa.Reset();

                //// 오다 내역 조회
                //dw_jusa.FillData(layJusaOrderPrint.LayoutTable);

                //dw_jusa.AcceptText();
                //if (dw_jusa.RowCount > 0)
                //    dw_jusa.Print();
                //else
                //    return;

                #endregion

                #region 주사라벨

                // reprint
                if (ar_Print_Gubun == "R" ) return;

                // prn order
                if (ar_Magam_gubun == "P2") return;

                if (!this.cbxJusaLabelYN.Checked) return;

     //           string origin_print = SetPrint(dw_lable, false);
     //           string print_name = SetPrint(dw_lable, true);

                // lable print set
                //try
                //{
                //    if (print_name != "")
                //        IHIS.Framework.PrintHelper.SetDefaultPrinter(print_name);

                //    // 오다 내역 조회
                //    DsvJusaLabel(ar_JubsuDate, ar_DrgBunho);
                //    // 기본프린터 set
                //    if (origin_print != "")
                //        IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print);
                //}
                //catch
                //{ }
                #endregion
            }
        }

        #region SetPrint
        private string SetPrint(XDataWindow dw_print, bool lable_yn)
        {
            string print_name = "";

            if (lable_yn)
            {
                foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    if (s == "JUSA_LABEL" || s == "jusa_label")
                    {
                        print_name = "JUSA_LABEL";
                        break;
                    }
                    else
                    {
                        if (s.IndexOf("JUSA_LABEL") >= 0 || s.IndexOf("jusa_label") >= 0)
                            print_name = s;
                    }
                }

                if (print_name.IndexOf("JUSA_LABEL") < 0)
                {
                    //MessageBox.Show("ラベルプリンタの設定がされていません。");
                    //dw_print.PrintDialog(true);
                }
                //foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                //{
                //    if (s == "Microsoft XPS Document Writer")
                //    {
                //        print_name = "Microsoft XPS Document Writer";
                //        break;
                //    }
                //    else
                //    {
                //        if (s.IndexOf("Microsoft XPS Document Writer") >= 0)
                //            print_name = s;
                //    }
                //}

                //if (print_name.IndexOf("Microsoft XPS Document Writer") < 0)
                //{
                //    //MessageBox.Show("ラベルプリンタの設定がされていません。");
                //    //dw_print.PrintDialog(true);
                //}
            }
            else
            {
                print_name = dw_print.PrintProperties.PrinterName;
            }

            return print_name;
        }
        #endregion

        //private void dtpMagamDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        //{
        //    gridQuery();
        //}

        private void btnATC_Click(object sender, System.EventArgs e)
        {
            string drg_bunho = "", jubsu_date = "";

            string jusa_yn = "";
            jusa_yn = grdList.GetItemString(grdList.CurrentRowNumber, "jusa_yn");

            //내복, 외용
            if (jusa_yn == "N")
            {
                if (grdMagamOrder.CurrentRowNumber < 0) return;
                jubsu_date = grdMagamOrder.GetItemString(grdMagamOrder.CurrentRowNumber, "jubsu_date");
                drg_bunho = grdMagamOrder.GetItemString(grdMagamOrder.CurrentRowNumber, "drg_bunho");

                AtcSend(jubsu_date, drg_bunho);
            }
        }

        #region AtcSend
        private void AtcSend(string jubsu_date, string drg_bunho)
        {
            string f_seq = string.Empty;
            string cmdText = @"SELECT MAX(SEQ) + 1
                                 FROM DRG_ATC
                                WHERE JUBSU_DATE   = :f_jubsu_date
                                  AND DRG_BUNHO    = :f_drg_bunho
                                  AND IN_OUT_GUBUN = :f_in_out_gubun
                                  AND HOSP_CODE    = :f_hosp_code";
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_jubsu_date", jubsu_date);
            bindVars.Add("f_drg_bunho", drg_bunho);
            bindVars.Add("f_in_out_gubun", "I");
            bindVars.Add("f_hosp_code", mHospCode);
            object retVal = Service.ExecuteScalar(cmdText, bindVars);

            if (!TypeCheck.IsNull(retVal))
            {
                f_seq = retVal.ToString();
            }
            bindVars.Add("q_user_id", UserInfo.UserID);
            bindVars.Add("f_seq", f_seq);

            cmdText = @"INSERT INTO DRG_ATC(SYS_DATE              ,SYS_ID               ,UPD_DATE
                                           ,JUBSU_DATE            ,DRG_BUNHO            ,IN_OUT_GUBUN
                                           ,SEQ                   ,INPUT_DATE           ,INPUT_TIME
                                           ,SEND_DATE             ,SEND_TIME            ,END_FLAG
                                           ,HOSP_CODE)
                                    VALUES (SYSDATE               ,:q_user_id           ,SYSDATE
                                           ,:f_jubsu_date         ,:f_drg_bunho         ,:f_in_out_gubun
                                           ,NVL(:f_seq,1)         ,TRUNC(SYSDATE)       ,TO_CHAR(SYSDATE,'HH24MI')
                                           ,NULL                  ,NULL                 ,'N'
                                           ,:f_hosp_code)";
            try
            {
                Service.BeginTransaction();
                if (!Service.ExecuteNonQuery(cmdText, bindVars)) throw new Exception(Service.ErrFullMsg);
            }
            catch (Exception xe)
            {
                Service.RollbackTransaction();
                XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                return;
            }
            Service.CommitTransaction();
        }
        #endregion

        #region [-- DsvBoryu() --]
        /// <summary>
        /// dsvBoryu Service Conversion PC:DRG3010P10, WT:D
        /// </summary>
        /// <param name="fkocs2003"></param>
        /// <param name="reUseYn"></param>
        /// <returns></returns>
        private bool DsvBoryu(string fkocs2003, string reUseYn)
        {
            string cmdText = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_fkocs2003", fkocs2003);
            bindVars.Add("f_hosp_code", mHospCode);
            bindVars.Add("f_re_use_yn", reUseYn);

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            inputList.Add(UserInfo.UserID);
            inputList.Add(fkocs2003);
            inputList.Add(reUseYn);

            cmdText = @"SELECT NVL(B.TOIWON_GOJI_YN,'N') TOIWON_GOJI_YN
                          FROM INP1001 B
                             , OCS2003 A
                         WHERE A.PKOCS2003 = :f_fkocs2003
                           AND A.FKINP1001 = B.PKINP1001
                           AND A.HOSP_CODE = :f_hosp_code";
            if (Service.ExecuteScalar(cmdText, bindVars).ToString().Equals("Y"))
            {
                XMessageBox.Show(Service.ExecuteScalar("SELECT FN_ADM_MSG(909) FROM DUAL").ToString());
                return false;
            }
            else
            {
                cmdText = @"UPDATE DRG3010
                               SET RE_USE_YN = :f_re_use_yn
                             WHERE FKOCS2003 = :f_fkocs2003
                               AND HOSP_CODE = :f_hosp_code";
                if (!Service.ExecuteNonQuery(cmdText, bindVars))
                {
                    return false;
                }

                if (!Service.ExecuteProcedure("PR_DRG_MAKE_DRG3060", inputList, outputList))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        private void dtpFromDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.gridQuery();
        }

        private void dtpToDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.gridQuery();
        }

        #region [処方箋印刷ボタン]
        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            XEditGrid aGrid = this.grdPaQuery;

            if (aGrid.RowCount < 1) return;

            if (XMessageBox.Show(Resources.XMessageBox9, Resources.XMessageBox_caption9, MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            else
            {
                this.MagamProcess(aGrid);
            }
        }
        #endregion

//        private void xButton2_Click(object sender, System.EventArgs e)
//        {
//            if (grdList.CurrentRowNumber < 0) return;

//            ArrayList inputList = new ArrayList();
//            ArrayList outputList = new ArrayList();

//            try
//            {
//                #region 보류
//                if (XMessageBox.Show("保留実行を続きますか。", "保留", MessageBoxButtons.YesNo) == DialogResult.Yes)
//                {
//                    string cmdText = string.Empty;
//                    BindVarCollection bindVars = new BindVarCollection();
//                    bindVars.Add("f_jubsu_date", grdList.GetItemString(grdList.CurrentRowNumber, "jubsu_date"));
//                    bindVars.Add("f_drg_bunho", grdList.GetItemString(grdList.CurrentRowNumber, "drg_bunho"));
//                    bindVars.Add("f_hosp_code", mHospCode);
//                    object fkocs2003 = null;

//                    cmdText = @"SELECT FKOCS2003
//                              FROM DRG3010
//                             WHERE JUBSU_DATE = :f_jubsu_date
//                               AND DRG_BUNHO  = :f_drg_bunho
//                               AND HOSP_CODE  = :f_hosp_code";
//                    fkocs2003 = Service.ExecuteScalar(cmdText, bindVars);

//                    if (!TypeCheck.IsNull(fkocs2003))
//                    {
//                        bindVars.Add("f_fkocs2003", fkocs2003.ToString());

//                        inputList.Add(UserInfo.UserID);
//                        inputList.Add(fkocs2003.ToString());
//                        inputList.Add("Y");

//                        cmdText = @"SELECT NVL(B.TOIWON_GOJI_YN,'N') TOIWON_GOJI_YN
//                                  FROM INP1001 B
//                                     , OCS2003 A
//                                 WHERE A.PKOCS2003 = :f_fkocs2003
//                                   AND A.FKINP1001 = B.PKINP1001
//                                   AND A.HOSP_CODE = :f_hosp_code";
//                        if (Service.ExecuteScalar(cmdText, bindVars).ToString().Equals("Y"))
//                        {
//                            XMessageBox.Show(Service.ExecuteScalar("SELECT FN_ADM_MSG(999) FROM DUAL").ToString());
//                            return;
//                        }
//                        else
//                        {
//                            Service.BeginTransaction();
//                            cmdText = @"UPDATE DRG3010
//                                           SET RE_USE_YN = 'Y'
//                                         WHERE FKOCS2003 = :f_fkocs2003
//                                           AND HOSP_CODE = :f_hosp_code";
//                            if (!Service.ExecuteNonQuery(cmdText, bindVars))
//                            {
//                                throw new Exception(Service.ErrFullMsg);
//                            }

//                            if (!Service.ExecuteProcedure("PR_DRG_MAKE_DRG3060", inputList, outputList))
//                            {
//                                throw new Exception(outputList[0].ToString());
//                            }
//                        }
//                    }
//                }
//                else
//                    return;
//                #endregion


//                #region 마감취소
//                string drg_bunho = "", jubsu_date = "";
//                jubsu_date = grdList.GetItemString(grdList.CurrentRowNumber, "jubsu_date");
//                drg_bunho = grdList.GetItemString(grdList.CurrentRowNumber, "drg_bunho");

//                inputList.Clear();
//                outputList.Clear();
//                inputList.Add(jubsu_date);
//                inputList.Add(drg_bunho);
//                inputList.Add(UserInfo.UserID);
//                if (!Service.ExecuteProcedure("PR_DRG_INP_DRG_BUNHO_CANCEL", inputList, outputList))
//                {
//                    throw new Exception(Service.ErrFullMsg);
//                }

//                grdList.Reset();
//                grdMagamOrder.Reset();
//                grdMagamJUSAOrder.Reset();

//                if (!grdList.QueryLayout(false)) throw new Exception(Service.ErrFullMsg);
//                #endregion
//            }
//            catch (Exception xe)
//            {
//                Service.RollbackTransaction();
//                XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace, "エラー", MessageBoxIcon.Hand);
//                return;
//            }
//            Service.CommitTransaction();
//        }

        private void grdBoryuPa_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            //string jusa_yn;
            //jusa_yn = grdBoryuPa.GetItemString(grdBoryuPa.CurrentRowNumber, "jusa_yn");

            //grdBoryuJusa.Reset();
            //grdBoryuNeabok.Reset();

            //try
            //{
            //    //내복, 외용
            //    if (jusa_yn == "N")
            //    {
            //        grdBoryuNeabok.Visible = true;
            //        grdBoryuJusa.Visible = false;
            //        //grdBoryuNeabok.SetBindVarValue("f_magam_bunryu", jusa_yn);
            //        if (!grdBoryuNeabok.QueryLayout(false)) throw new Exception(Service.ErrFullMsg);
            //    }
            //    //주사
            //    if (jusa_yn == "Y")
            //    {
            //        grdBoryuJusa.Visible = true;
            //        grdBoryuNeabok.Visible = false;
            //        //grdBoryuJusa.SetBindVarValue("f_magam_bunryu", jusa_yn);
            //        if (!grdBoryuJusa.QueryLayout(false)) throw new Exception(Service.ErrFullMsg);
            //    }
            //}
            //catch (Exception xe)
            //{
            //    XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace, "エラー", MessageBoxIcon.Hand);
            //    return;
            //}
        }

        private void tabControl_SelectionChanged(object sender, System.EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                this.dtpJubsuDate.Enabled = true;
                this.lbDate.Text = Resources.lbDate2;
                //paBox.Reset();
                this.cbxActor.Enabled = true;
            }

            if (tabControl.SelectedIndex == 1)
            {
                this.dtpJubsuDate.Enabled = false;
                this.lbDate.Text = Resources.lbDate1;
                //paBox.Reset();
                this.cbxActor.Enabled = false;
            }

            if (tabControl.SelectedIndex == 2)
            {
                this.dtpJubsuDate.Enabled = false;
                this.lbDate.Text = Resources.lbDate1;
                //paBox.Reset();
                this.cbxActor.Enabled = false;
            }

            if (tabControl.SelectedIndex == 3)
            {
                this.dtpJubsuDate.Enabled = true;
                this.lbDate.Text = Resources.lbDate2;
                //paBox.Reset();
                this.cbxActor.Enabled = true;
            }

            this.gridQuery();
        }

        private void grdBoryuPa_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
        {
            //if (XMessageBox.Show("保留取消実行を続きますか。", "保留", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    string jusa_yn;
            //    jusa_yn = grdBoryuPa.GetItemString(grdBoryuPa.CurrentRowNumber, "jusa_yn");

            //    if (jusa_yn == "N")
            //    {
            //        for (int i = 0; i < grdBoryuNeabok.RowCount; i++)
            //        {
            //            grdBoryuNeabok.SetItemValue(i, "re_use_yn", "N");
            //            if (!DsvBoryu(grdBoryuNeabok.GetItemString(i, "fkocs2003")
            //                    , grdBoryuNeabok.GetItemString(i, "re_use_yn")))
            //                return;
            //        }
            //    }
            //    else
            //    {
            //        for (int i = 0; i < grdBoryuJusa.RowCount; i++)
            //        {
            //            grdBoryuJusa.SetItemValue(i, "re_use_yn", "N");
            //            if (!DsvBoryu(grdBoryuJusa.GetItemString(i, "fkocs2003")
            //                   , grdBoryuJusa.GetItemString(i, "re_use_yn")))
            //                return;
            //        }
            //    }

            //    grdBoryuJusa.Reset();
            //    grdBoryuNeabok.Reset();

            //    if (!grdBoryuPa.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

            //    BoryuQuery();
                
            //}
        }

        #region [-- DsvBoRyu --]
        /// <summary>
        /// dsvBoRyu Service Conversion PC:DRG3010P99, WT:7
        /// </summary>
        /// <param name="fkocs2003"></param>
        /// <param name="reUseYn"></param>
        private bool DsvBoRyu(string fkocs2003, string reUseYn)
        {
            try
            {
                Service.BeginTransaction();
                string cmdText = @"UPDATE DRG3010
                                      SET RE_USE_YN = '" + reUseYn + @"'
                                    WHERE FKOCS2003 = '" + fkocs2003 + @"'
                                      AND HOSP_CODE = '" + mHospCode + "'";

                ArrayList inputList = new ArrayList();
                ArrayList outputList = new ArrayList();
                inputList.Add(UserInfo.UserID);
                inputList.Add(fkocs2003);
                inputList.Add(reUseYn);

                if (!Service.ExecuteNonQuery(cmdText)) throw new Exception(Service.ErrFullMsg);
                if (!Service.ExecuteProcedure("PR_DRG_MAKE_DRG3060", inputList, outputList)) throw new Exception(Service.ErrFullMsg);
            }
            catch (Exception xe)
            {
                Service.RollbackTransaction();
                XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
                return false;
            }
            Service.CommitTransaction();
            return true;
        }
        #endregion

        #region 각 그리드/레이아웃에 바인드변수 설정
        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdList.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdList.SetBindVarValue("f_ho_dong", this.cbxBuseo.GetDataValue());
            this.grdList.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.grdList.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            this.grdList.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            this.grdList.SetBindVarValue("f_magam_gubun", cbxGubun.GetDataValue());
        }

        private void grdMagamOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMagamOrder.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdMagamOrder.SetBindVarValue("f_jubsu_date", this.grdList.GetItemString(this.grdList.CurrentRowNumber, "jubsu_date"));
            this.grdMagamOrder.SetBindVarValue("f_drg_bunho", this.grdList.GetItemString(this.grdList.CurrentRowNumber, "drg_bunho"));
        }

        private void grdMagamJUSAOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMagamJUSAOrder.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdMagamJUSAOrder.SetBindVarValue("f_jubsu_date", this.grdList.GetItemString(this.grdList.CurrentRowNumber, "jubsu_date"));
            this.grdMagamJUSAOrder.SetBindVarValue("f_drg_bunho", this.grdList.GetItemString(this.grdList.CurrentRowNumber, "drg_bunho"));
        }

        private void grdBoryuPa_QueryStarting(object sender, CancelEventArgs e)
        {
            //grdBoryuPa.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            //grdBoryuPa.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            //grdBoryuPa.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdBoryuJusa_QueryStarting(object sender, CancelEventArgs e)
        {
            //grdBoryuJusa.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            //grdBoryuJusa.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            //grdBoryuJusa.SetBindVarValue("f_bunho", grdBoryuPa.GetItemString(grdBoryuPa.CurrentRowNumber, "bunho"));
            //grdBoryuJusa.SetBindVarValue("f_doctor", grdBoryuPa.GetItemString(grdBoryuPa.CurrentRowNumber, "doctor"));
            //grdBoryuJusa.SetBindVarValue("f_hosp_code", mHospCode);
            //grdBoryuJusa.SetBindVarValue("f_emergency", grdBoryuPa.GetItemString(grdBoryuPa.CurrentRowNumber, "emergency"));

        }

        private void grdBoryuNeabok_QueryStarting(object sender, CancelEventArgs e)
        {
            //grdBoryuNeabok.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            //grdBoryuNeabok.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            //grdBoryuNeabok.SetBindVarValue("f_bunho", grdBoryuPa.GetItemString(grdBoryuPa.CurrentRowNumber, "bunho"));
            //grdBoryuNeabok.SetBindVarValue("f_doctor", grdBoryuPa.GetItemString(grdBoryuPa.CurrentRowNumber, "doctor"));
            //grdBoryuNeabok.SetBindVarValue("f_hosp_code", mHospCode);
            //grdBoryuNeabok.SetBindVarValue("f_emergency", grdBoryuPa.GetItemString(grdBoryuPa.CurrentRowNumber, "emergency"));

        }

        private void layOutOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            layOutOrder.SetBindVarValue("f_from_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            layOutOrder.SetBindVarValue("f_to_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            layOutOrder.SetBindVarValue("f_gubun", "1"); //미접수건만
            layOutOrder.SetBindVarValue("f_wonyoi_yn", "N"); //외래만
            layOutOrder.SetBindVarValue("f_bunho", ""); // 모든 환자
            layOutOrder.SetBindVarValue("f_gwa", "%"); // 모든 과
        }
        
        private void grdPaQuery_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPaQuery.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdPaQuery.SetBindVarValue("f_ho_dong", this.cbxBuseo.GetDataValue());
            this.grdPaQuery.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.grdPaQuery.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            this.grdPaQuery.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            this.grdPaQuery.SetBindVarValue("f_magam_gubun", cbxGubun.GetDataValue());

        }

        private void grdPaQuery_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.grdPaQuery.RowCount < 1) return;

            this.SetGrdHeaderImage(this.grdPaQuery);

            //for (int i = 0; i < this.grdPaQuery.RowCount; i++)
            //{
            //    if (this.grdPaQuery.GetItemString(i, "act_buseo") == "")
            //    {
            //        // 締切自動チェック
            //        this.grdPaQuery.SetItemValue(i, "magam_yn", "Y");
            //        // 締切日付セット
            //        this.grdPaQuery.SetItemValue(i, "jubsu_date", IHIS.Framework.EnvironInfo.GetSysDate());
            //    }
            //}
            //this.grdPaQuery.ResetUpdate();

            // 画面のALARMが活性の場合
            if (this.useAlarmChkYN.Equals("Y"))
            {
                this.playAlarm("DRG");
            }
        }

        #region 그리드 이미지 셋팅
        private void SetGrdHeaderImage(XEditGrid grid)
        {
            for (int i = 0; i < grid.RowCount; i++)
            {
                // 払出済환자.
                if (grid.Name == "grdPaQuery" && grid.GetItemString(i, "act_buseo") == "PA")
                {
                    grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[16];
                    grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + "払出済";
                }
            }
        }
        #endregion

        #region [playAlarm] Alarmを設定
        private void playAlarm(string part)
        {
            try
            {
                if (part.Equals("DRG"))
                    Kernel32.PlaySound(this.alarmFilePath_DRG, IntPtr.Zero, Win32.SoundFlags.SND_FILENAME | Win32.SoundFlags.SND_ASYNC);
                else if (part.Equals("DRG_EM"))
                    Kernel32.PlaySound(this.alarmFilePath_DRG_EM, IntPtr.Zero, Win32.SoundFlags.SND_FILENAME | Win32.SoundFlags.SND_ASYNC);
                else
                    IHIS.Framework.Kernel32.Nofify();
            }
            catch { }
        }
        #endregion

        #region [grdPaQuery_ItemValueChanging]
        private void grdPaQuery_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ColName == "magam_yn")
            {
                if (e.ChangeValue.ToString() == "Y")
                {
                    this.grdPaQuery.SetItemValue(e.RowNumber, "jubsu_date", this.dtpJubsuDate.GetDataValue());

                    if (this.grdPaQuery.GetItemString(e.RowNumber, "act_buseo") == "PA") XMessageBox.Show(Resources.XMessageBox10, Resources.XMessageBox10_caption, MessageBoxIcon.Information);

                }
                else
                {
                    this.grdPaQuery.SetItemValue(e.RowNumber, "jubsu_date", "");
                }
            }
            this.grdPaQuery.ResetUpdate();
        }
        #endregion

        #region [dtpJubsuDate_DataValidating 受付日付変更]
        private void dtpJubsuDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            for (int i = 0; i < this.grdPaQuery.RowCount; i++)
            {
                if (this.grdPaQuery.GetItemString(i, "magam_yn") == "Y")
                {
                    this.grdPaQuery.SetItemValue(i, "jubsu_date", e.DataValue);
                }
            }
        }
        #endregion

        private void grdMiMagamOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            //if (rbxBunryu1.Checked)
            //XMessageBox.Show(((XEditGrid)sender).Name);
            string jusa_yn = grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "jusa_yn");

            if (jusa_yn == "N")
            {
                grdMiMagamOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                grdMiMagamOrder.SetBindVarValue("f_order_date", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "order_date"));
                grdMiMagamOrder.SetBindVarValue("f_hope_date", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "hope_date"));
                //grdMiMagamOrder.SetBindVarValue("f_hope_time", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "hope_time"));
                grdMiMagamOrder.SetBindVarValue("f_bunho", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "bunho"));
                grdMiMagamOrder.SetBindVarValue("f_ho_dong", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "ho_dong"));
                grdMiMagamOrder.SetBindVarValue("f_doctor", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "resident"));
                grdMiMagamOrder.SetBindVarValue("f_emergency", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "emergency"));
                //grdMiMagamOrder.SetBindVarValue("f_toiwon_yn", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "toiwon_yn"));
                grdMiMagamOrder.SetBindVarValue("f_magam_gubun", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "magam_gubun"));
            }
            else
            {
                grdMiMagamJUSAOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                grdMiMagamJUSAOrder.SetBindVarValue("f_order_date", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "order_date"));
                grdMiMagamJUSAOrder.SetBindVarValue("f_hope_date", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "hope_date"));
                //grdMiMagamJUSAOrder.SetBindVarValue("f_hope_time", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "hope_time"));
                grdMiMagamJUSAOrder.SetBindVarValue("f_bunho", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "bunho"));
                grdMiMagamJUSAOrder.SetBindVarValue("f_ho_dong", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "ho_dong"));
                grdMiMagamJUSAOrder.SetBindVarValue("f_doctor", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "resident"));
                grdMiMagamJUSAOrder.SetBindVarValue("f_emergency", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "emergency"));
                //grdMiMagamJUSAOrder.SetBindVarValue("f_toiwon_yn", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "toiwon_yn"));
                grdMiMagamJUSAOrder.SetBindVarValue("f_magam_gubun", grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "magam_gubun"));
            }
        }

        private void grdMagamOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            XEditGrid aGrid = (XEditGrid)sender;
            
            string cmdText = @" SELECT '(' || NVL(:f_dv_1,'0')||'-'||NVL(:f_dv_2,'0')||'-'||NVL(:f_dv_3,'0')||'-'||NVL(:f_dv_4,'0')||'-'||NVL(:f_dv_5,'0')||') '
                                           || :f_remark     REMARK
                                  FROM DUAL
                                 WHERE NVL(:f_dv_1,0) + NVL(:f_dv_2,0) + NVL(:f_dv_3,0) + NVL(:f_dv_4,0) + NVL(:f_dv_5,0) > 0";
            BindVarCollection bindVars = new BindVarCollection();
            object retVal = null;

            for (int i = 0; i < aGrid.RowCount; i++)
            {
                bindVars.Clear();
                bindVars.Add("f_dv_1", aGrid.GetItemString(i, "dv_1"));
                bindVars.Add("f_dv_2", aGrid.GetItemString(i, "dv_2"));
                bindVars.Add("f_dv_3", aGrid.GetItemString(i, "dv_3"));
                bindVars.Add("f_dv_4", aGrid.GetItemString(i, "dv_4"));
                bindVars.Add("f_dv_5", aGrid.GetItemString(i, "dv_5"));
                bindVars.Add("f_remark", aGrid.GetItemString(i, "remark"));

                retVal = Service.ExecuteScalar(cmdText, bindVars);

                if (!TypeCheck.IsNull(retVal))
                {
                    aGrid.SetItemValue(i, "remark", retVal.ToString());
                }
            }

            DisplayMixGroup(aGrid);
        }

        private void grdPaDcList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPaDcList.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdPaDcList.SetBindVarValue("f_ho_dong", this.cbxBuseo.GetDataValue());
            this.grdPaDcList.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.grdPaDcList.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            this.grdPaDcList.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            this.grdPaDcList.SetBindVarValue("f_magam_gubun", cbxGubun.GetDataValue());
        }

        private void grdPaDcList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            string jusa_yn = "N";

            this.grdJusaDcOrder.Reset();
            this.grdDcOrder.Reset();

            jusa_yn = this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "jusa_yn");

            //내복, 외용
            if (jusa_yn == "N")
            {
                this.grdDcOrder.Visible = true;
                this.grdJusaDcOrder.Visible = false;
                if (!this.grdDcOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
            //주사
            if (jusa_yn == "Y")
            {
                this.grdDcOrder.Visible = false;
                this.grdJusaDcOrder.Visible = true;
                if (!this.grdJusaDcOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
        }

        private void grdDcOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.grdDcOrder.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdDcOrder.SetBindVarValue("f_jubsu_date", this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "jubsu_date"));
            this.grdDcOrder.SetBindVarValue("f_drg_bunho", this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "drg_bunho"));

            this.grdDcOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDcOrder.SetBindVarValue("f_order_date", this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "order_date"));
            this.grdDcOrder.SetBindVarValue("f_hope_date", this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "hope_date"));
            //this.grdDcOrder.SetBindVarValue("f_hope_time", this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "hope_time"));
            this.grdDcOrder.SetBindVarValue("f_bunho", this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "bunho"));
            this.grdDcOrder.SetBindVarValue("f_ho_dong", this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "ho_dong"));
            this.grdDcOrder.SetBindVarValue("f_doctor", this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "doctor"));
        }

        private void grdDcOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["bannab_yn"].ToString() == "Y")
            {
                if (int.Parse(e.DataRow["nalsu"].ToString()) > 0)
                {
                    e.DrawMiddleLine = true;
                    e.MiddleLineColor = Color.Red;
                }
                else
                {
                    e.ForeColor = Color.Red;
                }
            }

            if (e.DataRow["brought_drg_yn"].ToString() == "Y")
                e.BackColor = Color.LightBlue;

            if (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "0")
            {
                if (e.DataRow["emergency"].ToString() == "Y")
                    e.BackColor = Color.Pink;
            }
        }

        private void grdJusaDcOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.grdJusaDcOrder.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdJusaDcOrder.SetBindVarValue("f_jubsu_date", this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "jubsu_date"));
            this.grdJusaDcOrder.SetBindVarValue("f_drg_bunho", this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "drg_bunho"));


            this.grdJusaDcOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdJusaDcOrder.SetBindVarValue("f_order_date", this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "order_date"));
            this.grdJusaDcOrder.SetBindVarValue("f_hope_date", this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "hope_date"));
            //this.grdJusaDcOrder.SetBindVarValue("f_hope_time", this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "hope_time"));
            this.grdJusaDcOrder.SetBindVarValue("f_bunho", this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "bunho"));
            this.grdJusaDcOrder.SetBindVarValue("f_ho_dong", this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "ho_dong"));
            this.grdJusaDcOrder.SetBindVarValue("f_doctor", this.grdPaDcList.GetItemString(this.grdPaDcList.CurrentRowNumber, "doctor"));
        }

        private void grdJusaDcOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["bannab_yn"].ToString() == "Y")
            {
                if (int.Parse(e.DataRow["nalsu"].ToString()) > 0)
                {
                    e.DrawMiddleLine = true;
                    e.MiddleLineColor = Color.Red;
                }
                else
                {
                    e.ForeColor = Color.Red;
                }
            }

            if (e.DataRow["brought_drg_yn"].ToString() == "Y")
                e.BackColor = Color.LightBlue;

            if (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "0")
            {
                if (e.DataRow["emergency"].ToString() == "Y")
                    e.BackColor = Color.Pink;
            }
        }
        #endregion
        /*
        private void grdMagamJUSAOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            string cmdText = @" SELECT '(' || NVL(:f_dv_1,'0')||'-'||NVL(:f_dv_2,'0')||'-'||NVL(:f_dv_3,'0')||'-'||NVL(:f_dv_4,'0')||'-'||NVL(:f_dv_5,'0')||') '
                                       || :f_remark     REMARK
                                  FROM DUAL
                                 WHERE NVL(:f_dv_1,0) + NVL(:f_dv_2,0) + NVL(:f_dv_3,0) + NVL(:f_dv_4,0) + NVL(:f_dv_5,0) > 0";
            BindVarCollection bindVars = new BindVarCollection();
            object retVal = null;

            for (int i = 0; i < grdMagamJUSAOrder.RowCount; i++)
            {
                bindVars.Clear();
                bindVars.Add("f_dv_1", grdMagamJUSAOrder.GetItemString(i, "dv_1"));
                bindVars.Add("f_dv_2", grdMagamJUSAOrder.GetItemString(i, "dv_2"));
                bindVars.Add("f_dv_3", grdMagamJUSAOrder.GetItemString(i, "dv_3"));
                bindVars.Add("f_dv_4", grdMagamJUSAOrder.GetItemString(i, "dv_4"));
                bindVars.Add("f_dv_5", grdMagamJUSAOrder.GetItemString(i, "dv_5"));
                bindVars.Add("f_remark", grdMagamJUSAOrder.GetItemString(i, "remark"));

                retVal = Service.ExecuteScalar(cmdText, bindVars);

                if (!TypeCheck.IsNull(retVal))
                {
                    grdMagamJUSAOrder.SetItemValue(i, "remark", retVal.ToString());
                }
            }

            XEditGrid aGrid = (XEditGrid)sender;

            DisplayMixGroup(aGrid);
        
        }
        */
        private void btnBoryuQry_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!grdBoryuPa.QueryLayout(false)) throw new Exception(Service.ErrFullMsg);
            //}
            //catch (Exception xe)
            //{
            //    XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
            //}
        }

        
        #region Mix Group 데이타 Image Display (DiaplayMixGroup)
        /// <summary>
        /// Mix Group 데이타 Image Display
        /// </summary>
        /// <param name="aGrd"> XEditGrid </param>
        /// <returns> void  </returns>
        private void DisplayMixGroup(XEditGrid aGrd)
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
                    if (aGrd.GetItemString(i, "dc_yn") == "Y") continue;

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

        #region 반납그리드표시
        private void grdMagamJUSAOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["bannab_yn"].ToString() == "Y")
            {
                if (int.Parse(e.DataRow["nalsu"].ToString()) > 0)
                {
                    e.DrawMiddleLine = true;
                    e.MiddleLineColor = Color.Red;
                }
                else
                {
                    e.ForeColor = Color.Red;
                }
            }

            if (e.DataRow["brought_drg_yn"].ToString() == "Y")
                e.BackColor = Color.LightBlue;

            if (e.DataRow["order_gubun"].ToString().Substring(1,1) == "0")
            {
                if (e.DataRow["emergency"].ToString() == "Y")
                    e.BackColor = Color.Pink;
            }
        }

        private void grdMagamOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["bannab_yn"].ToString() == "Y")
            {
                if (int.Parse(e.DataRow["nalsu"].ToString()) > 0)
                {
                    e.DrawMiddleLine = true;
                    e.MiddleLineColor = Color.Red;
                }
                else
                {
                    e.ForeColor = Color.Red;
                }
            }

            if (e.DataRow["brought_drg_yn"].ToString() == "Y")
                e.BackColor = Color.LightBlue;

            if (e.DataRow["order_gubun"].ToString().Substring(1, 1) == "0")
            {
                if (e.DataRow["emergency"].ToString() == "Y")
                    e.BackColor = Color.Pink;
            }
        }
        #endregion


        #region 주사 라벨 재출력
        private void btnReLabelPrint_Click(object sender, EventArgs e)
        {
    //        string origin_print = SetPrint(dw_lable, false);
    //        string print_name = SetPrint(dw_lable, true);
            //string origin_print = "";
            //string print_name = "";

            // lable print set
            //try
            //{
            //    if (print_name != "")
            //        IHIS.Framework.PrintHelper.SetDefaultPrinter(print_name);

            //    if (grdMagamJUSAOrder.CurrentRowNumber < 0) return;
            //    string jubsu_date = grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "jubsu_date");
            //    string drg_bunho = grdMagamJUSAOrder.GetItemString(grdMagamJUSAOrder.CurrentRowNumber, "drg_bunho");

            //    // 오다 내역 조회
            //    DsvJusaLabel(jubsu_date, drg_bunho);

            //    // 기본프린터 set
            //    if (origin_print != "")
            //        IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print);
            //}
            //catch
            //{ }
            //finally
            //{
            //    IHIS.Framework.PrintHelper.SetDefaultPrinter(origin_print);
            //}
        }
        #endregion

        private void btnOutOpen_Click(object sender, EventArgs e)
        {
            XScreen.OpenScreen(this, "DRG5100P01", ScreenOpenStyle.PopUpFixed);
        }

        private void grdPaQuery_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            //string magam_bunryu = "1", magam_gubun = "N";

            ////내복, 외용
            //if (rbxBunryu1.Checked)
            if (grdPaQuery.GetItemString(e.CurrentRow, "jusa_yn") == "N")
            {
                //magam_bunryu = "1";
                grdMiMagamOrder.Visible = true;
                grdMiMagamJUSAOrder.Visible = false;

                //magam_gubun = grdPaQuery.GetItemString(e.CurrentRow, "append_yn");
                //grdMiMagamOrder.SetBindVarValue("f_magam_bunryu", magam_bunryu);
                //grdMiMagamOrder.SetBindVarValue("f_magam_gubun", magam_gubun);

                if (!grdMiMagamOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
            //주사
            //if (rbxBunryu2.Checked)
            if (grdPaQuery.GetItemString(e.CurrentRow, "jusa_yn") == "Y")
            {
                //magam_bunryu = "2";
                grdMiMagamOrder.Visible = false;
                grdMiMagamJUSAOrder.Visible = true;

                //magam_gubun = grdPaQuery.GetItemString(e.CurrentRow, "append_yn");
                //grdMiMagamJUSAOrder.SetBindVarValue("f_magam_bunryu", magam_bunryu);
                //grdMiMagamJUSAOrder.SetBindVarValue("f_magam_gubun", magam_gubun);

                if (!grdMiMagamJUSAOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
        }

        private void btnBoryu_Click(object sender, EventArgs e)
        {
            if (XMessageBox.Show(Resources.XMessageBox11, Resources.XMessageBox_caption11, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //if (rbxBunryu1.Checked)
                if (grdPaQuery.GetItemString(grdPaQuery.CurrentRowNumber, "jusa_yn") == "N")
                {
                    for (int i = 0; i < grdMiMagamOrder.RowCount; i++)
                    {
                        grdMiMagamOrder.SetItemValue(i, "re_use_yn", "Y");
                    }
                    BoRyuMethod(grdMiMagamOrder);

                }
                else
                {
                    for (int i = 0; i < grdMiMagamJUSAOrder.RowCount; i++)
                    {
                        grdMiMagamJUSAOrder.SetItemValue(i, "re_use_yn", "Y");
                    }
                    BoRyuMethod(grdMiMagamJUSAOrder);
                }

                gridQuery();
            }
        }

        private void BoRyuMethod(XEditGrid grd)
        {
            string cmdText = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();
            object retVal = null;
            bindVars.Add("q_user_id", UserInfo.UserID);
            try
            {
                Service.BeginTransaction();
               
                for (int i = 0; i < grd.RowCount; i++)
                {
                        cmdText = string.Empty;
                        bindVars.Clear();
                        bindVars.Add("f_fkocs2003", grd.GetItemString(i, "fkocs2003"));
                        bindVars.Add("f_re_use_yn", grd.GetItemString(i, "re_use_yn"));
                        bindVars.Add("f_user_id", UserInfo.UserID);
                        cmdText = @"SELECT NVL(B.TOIWON_GOJI_YN,'N') TOIWON_GOJI_YN
                                  FROM INP1001 B
                                     , OCS2003 A
                                 WHERE A.PKOCS2003 = :f_fkocs2003
                                   AND A.FKINP1001 = B.PKINP1001";
                        retVal = Service.ExecuteScalar(cmdText, bindVars);
                        if (!TypeCheck.IsNull(retVal) && retVal.Equals("Y"))
                        {
                            throw new Exception(Service.ExecuteScalar("SELECT FN_ADM_MSG(909) FROM DUAL").ToString());
                        }
                        else
                        {
                            ArrayList inputList = new ArrayList();
                            inputList.Add(bindVars["f_user_id"].VarValue);
                            inputList.Add(bindVars["f_fkocs2003"].VarValue);
                            inputList.Add(bindVars["f_re_use_yn"].VarValue);
                            ArrayList outputList = new ArrayList();
                            cmdText = @"UPDATE DRG3010
                                       SET RE_USE_YN = :f_re_use_yn
                                     WHERE FKOCS2003 = :f_fkocs2003";
                            if (Service.ExecuteNonQuery(cmdText, bindVars))
                            {
                                if (!Service.ExecuteProcedure("PR_DRG_MAKE_DRG3060", inputList, outputList))
                                {
                                    throw new Exception(outputList[0].ToString());
                                }
                            }
                        }
                    }
            }
            catch (Exception xe)
            {
                Service.RollbackTransaction();
                XMessageBox.Show(xe.Message);
                return;
            }
            Service.CommitTransaction();
        }

        #region [締切チェックコントロール]
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grdPaQuery.RowCount; i++)
            {
                this.grdPaQuery.SetItemValue(i, "magam_yn", "Y");
                // 締切日付セット
                this.grdPaQuery.SetItemValue(i, "jubsu_date", IHIS.Framework.EnvironInfo.GetSysDate());
            }
        }

        private void btnUnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdPaQuery.RowCount; i++)
            {
                this.grdPaQuery.SetItemValue(i, "magam_yn", "N");
                // 締切日付セット
                this.grdPaQuery.SetItemValue(i, "jubsu_date", "");
            }
        }
        #endregion

        #region [cbxBuseo_SelectionChangeCommitted]
        private void cbxBuseo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.gridQuery();
        }
        #endregion

        #region [cbxGubun_SelectionChangeCommitted]
        private void cbxGubun_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.gridQuery();
        }
        #endregion

        #region Status BAR 관련 메소드
        private void InitStatusBar(int aMaxValue)
        {
            this.pgbProgress.Minimum = 0;
            this.pgbProgress.Maximum = aMaxValue;

            this.lbStatus.Text = "";
        }

        private void SetVisibleStatusBar(bool aIsVisible)
        {
            this.pnlStatus.Visible = aIsVisible;
        }

        private void SetStatusBar(int aCurrentValue)
        {
            this.pgbProgress.Value = aCurrentValue;
            this.pgbProgress.Refresh();

            this.lbStatus.Text = aCurrentValue.ToString() + "/" + this.pgbProgress.Maximum.ToString();
            this.lbStatus.Refresh();
        }
        #endregion

        #region [timer1_Tick] 自動照会関連
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lbTime.Text = (this.QueryTime / 1000).ToString();
            this.QueryTime = this.QueryTime - 1000;

            if (QueryTime == 0)
            {
                this.gridQuery();

                this.timer1.Stop();

                this.timer1.Start();

                this.QueryTime = TimeVal;
            }
        }

        private void btnUseTimeChk_Click(object sender, EventArgs e)
        {
            // 自動照会使用可否 useTimeChkYN 

            if (this.useTimeChkYN.Equals("N"))
            {
                this.btnUseTimeChk.ImageIndex = 4;
                this.useTimeChkYN = "Y";

                this.timer1.Start();
                this.cboTime.Enabled = true;
                this.tbxTimer.SetDataValue("Y");
                this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
                this.txtTimeInterval.AcceptData();
            }
            else
            {
                this.btnUseTimeChk.ImageIndex = 3;
                this.useTimeChkYN = "N";

                this.cboTime.Enabled = false;
                this.timer1.Stop();
            }
        }

        #region [btnUseAlarmChk_Click]
        private void btnUseAlarmChk_Click(object sender, EventArgs e)
        {
            // 自動照会使用可否 useTimeChkYN 

            if (this.useAlarmChkYN.Equals("N"))
            {
                this.btnUseAlarmChk.ImageIndex = 4;
                this.useAlarmChkYN = "Y";
            }
            else
            {
                this.btnUseAlarmChk.ImageIndex = 3;
                this.useAlarmChkYN = "N";
            }
        }
        #endregion

        private void setTimer()
        {
            if (TypeCheck.IsInt(txtTimeInterval.Text))
            {
                this.QueryTime = int.Parse(txtTimeInterval.GetDataValue());
                this.TimeVal = int.Parse(txtTimeInterval.GetDataValue());
            }

            this.QueryTime = this.TimeVal;

            this.cboTime.SelectedIndex = 0;
            this.timer1.Start();
            this.cboTime.Enabled = true;
            this.tbxTimer.SetDataValue("Y");
            this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
            this.txtTimeInterval.AcceptData();
        }

        private void txtTimeInterval_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (TypeCheck.IsInt(e.DataValue))
            {
                this.QueryTime = int.Parse(e.DataValue);
                this.TimeVal = int.Parse(e.DataValue);


                this.lbTime.Text = (this.QueryTime / 1000).ToString();

                if (this.tbxTimer.GetDataValue() == "Y")
                {
                    this.timer1.Stop();
                    this.timer1.Start();
                }
            }
            else
            {
                PostCallHelper.PostCall(new PostMethod(PostTimerValidating));
            }
        }

        private void PostTimerValidating()
        {
            this.txtTimeInterval.SetDataValue(this.TimeVal.ToString());
        }

        private void cboTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.timer1.Stop();

            this.tbxTimer.SetDataValue("Y");
            this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
            this.txtTimeInterval.AcceptData();

            this.timer1.Start();
        }
        #endregion

        #region [PRN TAB 指示事項TAB コントロール] 
        private void grdPaPrnQuery_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPaPrnQuery.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdPaPrnQuery.SetBindVarValue("f_ho_dong", this.cbxBuseo.GetDataValue());
            this.grdPaPrnQuery.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.grdPaPrnQuery.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            this.grdPaPrnQuery.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
        }

        private void grdPaPrnQuery_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            string jusa_yn = "N";

            this.grdPrnJusaOrder.Reset();
            this.grdPrnOrder.Reset();

            jusa_yn = this.grdPaPrnQuery.GetItemString(this.grdPaPrnQuery.CurrentRowNumber, "jusa_yn");

            //내복, 외용
            if (jusa_yn == "N")
            {
                this.grdPrnOrder.Visible = true;
                this.grdPrnJusaOrder.Visible = false;
                if (!this.grdPrnOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
            //주사
            if (jusa_yn == "Y")
            {
                this.grdPrnOrder.Visible = false;
                this.grdPrnJusaOrder.Visible = true;
                if (!this.grdPrnJusaOrder.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
            }
        }

        private void grdPrnOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            string jusa_yn = grdPaPrnQuery.GetItemString(grdPaPrnQuery.CurrentRowNumber, "jusa_yn");

            if (jusa_yn == "N")
            {
                grdPrnOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                grdPrnOrder.SetBindVarValue("f_order_date", grdPaPrnQuery.GetItemString(grdPaPrnQuery.CurrentRowNumber, "order_date"));
                grdPrnOrder.SetBindVarValue("f_hope_date", grdPaPrnQuery.GetItemString(grdPaPrnQuery.CurrentRowNumber, "hope_date"));
                grdPrnOrder.SetBindVarValue("f_hope_time", grdPaPrnQuery.GetItemString(grdPaPrnQuery.CurrentRowNumber, "hope_time"));
                grdPrnOrder.SetBindVarValue("f_bunho", grdPaPrnQuery.GetItemString(grdPaPrnQuery.CurrentRowNumber, "bunho"));
                grdPrnOrder.SetBindVarValue("f_ho_dong", grdPaPrnQuery.GetItemString(grdPaPrnQuery.CurrentRowNumber, "ho_dong"));
                grdPrnOrder.SetBindVarValue("f_doctor", grdPaPrnQuery.GetItemString(grdPaPrnQuery.CurrentRowNumber, "resident"));
                grdPrnOrder.SetBindVarValue("f_emergency", grdPaPrnQuery.GetItemString(grdPaPrnQuery.CurrentRowNumber, "emergency"));
            }
            else
            {
                grdPrnJusaOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                grdPrnJusaOrder.SetBindVarValue("f_order_date", grdPaPrnQuery.GetItemString(grdPaPrnQuery.CurrentRowNumber, "order_date"));
                grdPrnJusaOrder.SetBindVarValue("f_hope_date", grdPaPrnQuery.GetItemString(grdPaPrnQuery.CurrentRowNumber, "hope_date"));
                grdPrnJusaOrder.SetBindVarValue("f_hope_time", grdPaPrnQuery.GetItemString(grdPaPrnQuery.CurrentRowNumber, "hope_time"));
                grdPrnJusaOrder.SetBindVarValue("f_bunho", grdPaPrnQuery.GetItemString(grdPaPrnQuery.CurrentRowNumber, "bunho"));
                grdPrnJusaOrder.SetBindVarValue("f_ho_dong", grdPaPrnQuery.GetItemString(grdPaPrnQuery.CurrentRowNumber, "ho_dong"));
                grdPrnJusaOrder.SetBindVarValue("f_doctor", grdPaPrnQuery.GetItemString(grdPaPrnQuery.CurrentRowNumber, "resident"));
                grdPrnJusaOrder.SetBindVarValue("f_emergency", grdPaPrnQuery.GetItemString(grdPaPrnQuery.CurrentRowNumber, "emergency"));
            }
        }

        private void btnPrnPrint_Click(object sender, EventArgs e)
        {
            XEditGrid aGrid = this.grdPaPrnQuery;

            if (aGrid.RowCount < 1) return;

            this.MagamProcess(aGrid);
        }

        private void grdPaPrnQuery_QueryEnd(object sender, QueryEndEventArgs e)
        {
            for (int i = 0; i < this.grdPaPrnQuery.RowCount; i++)
            {
                // 締切自動チェック
                this.grdPaPrnQuery.SetItemValue(i, "magam_yn", "Y");
                // 締切日付セット
                this.grdPaPrnQuery.SetItemValue(i, "jubsu_date", IHIS.Framework.EnvironInfo.GetSysDate());
            }
            this.grdPaPrnQuery.ResetUpdate();
        }

        private void grdPaPrnQuery_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ColName == "magam_yn")
            {
                if (e.ChangeValue.ToString() == "Y")
                {
                    this.grdPaPrnQuery.SetItemValue(e.RowNumber, "jubsu_date", this.dtpJubsuDate.GetDataValue());
                }
                else
                {
                    this.grdPaPrnQuery.SetItemValue(e.RowNumber, "jubsu_date", "");
                }
            }
        }
        #endregion

        #region [btnAtcTrans_Click ATC再転送]
        private void btnAtcTrans_Click(object sender, EventArgs e)
        {
            if (this.grdList.RowCount < 1) return;

            if (this.grdList.GetItemString(this.grdList.CurrentRowNumber, "jusa_yn").Equals("Y")) return;

            bool value = this.procAtcInterface(this.grdList.GetItemString(this.grdList.CurrentRowNumber, "jubsu_date")
                                             , this.grdList.GetItemString(this.grdList.CurrentRowNumber, "drg_bunho")
                                             , this.grdList.GetItemString(this.grdList.CurrentRowNumber, "bunho")
                                             , this.grdList.GetItemString(this.grdList.CurrentRowNumber, "fkinp1001"));

            if (value == false)
            {
                throw new Exception();
            }
        }
        #endregion

        #region [ATC I/F]
        private bool procAtcInterface(string jubsu_date, string drg_bunho, string bunho, string fkinp1001)
        {
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            BindVarCollection item = new BindVarCollection();
            string pkdrg4010 = "0";

            //１．中間テーブルデータ生成（DRG4010）
            inputList.Clear();
            inputList.Add(EnvironInfo.HospCode); //病院コード
            inputList.Add(jubsu_date); //受付日付
            inputList.Add(drg_bunho); //投薬番号
            inputList.Add("0"); //データ区分
            inputList.Add("I");//入外区分
            inputList.Add(bunho);//患者番号
            inputList.Add(fkinp1001);//FKINP1001

            try
            {
                Service.BeginTransaction();

                // IFSテーブル作成リターン値
                int rtnIfsCnt = -1;

                bool value = Service.ExecuteProcedure("PR_IFS_DRG_MASTER_INSERT", inputList, outputList);

                if (value == false || TypeCheck.IsNull(outputList[0]) || outputList[0].ToString().Equals("-1"))
                {
                    throw new Exception(Resources.Exception1);
                }
                else
                {
                    pkdrg4010 = outputList[0].ToString();

                    string QuerySQL = @"UPDATE DRG3010 A
                                           SET A.FKDRG4010    = :f_pkdrg4010
                                         WHERE A.HOSP_CODE    = :f_hosp_code
                                           AND A.JUBSU_DATE   = :f_jubsu_date
                                           AND A.DRG_BUNHO    = :f_drg_bunho
                                           AND A.BUNHO        = :f_bunho";

                    item.Clear();
                    item.Add("f_pkdrg4010", pkdrg4010);
                    item.Add("f_hosp_code", EnvironInfo.HospCode);
                    item.Add("f_jubsu_date", jubsu_date);
                    item.Add("f_drg_bunho", drg_bunho);
                    item.Add("f_bunho", bunho);

                    if (!Service.ExecuteNonQuery(QuerySQL, item))
                    {
                        throw new Exception(Resources.Exception2);
                    }

                    //２．I/Fテーブルデータ生成（IFS7010 ~ 7107）
                    rtnIfsCnt = this.makeIFSTBL("I", pkdrg4010, "Y");
                }
                Service.CommitTransaction();

                //３．ATC装置にFILE転送
                if (rtnIfsCnt > 0)
                {
                    //DRG_PROC_MAIN
                    this.atcTrans(pkdrg4010);
                }
            }
            catch (Exception ex)
            {
                Service.RollbackTransaction();
                XMessageBox.Show(ex.Message, Resources.XMessageBox_caption12, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //XMessageBox.Show("ATC情報転送の申請を成功しました。", "ATC情報転送要請成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private int makeIFSTBL(string io_gubun, string pkdrg4010, string send_yn)
        {
            //IFS1004テータ作成

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            int retVal = -1;

            inputList.Clear();
            outputList.Clear();

            inputList.Add(EnvironInfo.HospCode);
            inputList.Add(io_gubun);
            inputList.Add(pkdrg4010);
            inputList.Add(send_yn);

            bool ret = Service.ExecuteProcedure("PR_IFS_DRG_PROC_MAIN", inputList, outputList);

            //if (TypeCheck.IsNull(outputList[1]) || outputList[1].ToString() != "1")
            //{
            //    throw new Exception(outputList[2].ToString());
            //}

            if (TypeCheck.IsInt(outputList[0]))
            {
                retVal = Int32.Parse(outputList[0].ToString());
            }
            return retVal;
        }

        private bool atcTrans(string pkdrg4010)
        {
            if (TypeCheck.IsNull(pkdrg4010))
            {
                throw new Exception(Resources.Exception4);
            }

            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText;

            msgText = "97101" + pkdrg4010;
            int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
            if (ret == -1)
            {
                throw new Exception(Resources.Exception5 + msgText);
            }
            return true;
        }
        #endregion

        private void grdMiMagamOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["brought_drg_yn"].ToString() == "Y")
                e.BackColor = Color.LightBlue;

            if (e.DataRow["emergency"].ToString() == "Y")
                e.BackColor = Color.Pink;
        }

        #region [btnPrintAdmMedi_Click 服薬指導せん出力ボタン]
        private void btnPrintAdmMedi_Click(object sender, EventArgs e)
        {
            BindVarCollection item = new BindVarCollection();
            object retVal = null;
            string ordChkDrg = "";
            string cmdText = null;

            #region CHECK DRG
            cmdText = @"SELECT DISTINCT 'Y' 
                          FROM (
                                SELECT SUBSTR(A.ORDER_GUBUN,2,1) ORDER_GUBUN
                                  FROM OCS2003 A
                                 WHERE A.HOSP_CODE = :f_hosp_code
                                   AND A.PKOCS2003 IN (SELECT B.FKOCS2003
                                                         FROM DRG3010 B
                                                        WHERE B.HOSP_CODE  = A.HOSP_CODE
                                                          AND B.JUBSU_DATE = :f_jubsu_date
                                                          AND B.DRG_BUNHO  = :f_drg_bunho
                                                          AND B.BUNHO      = :f_bunho)
                               ) C
                         WHERE C.ORDER_GUBUN IN ('C', 'D')";

            item.Clear();
            item.Add("f_hosp_code", EnvironInfo.HospCode);
            item.Add("f_jubsu_date", this.grdList.GetItemString(this.grdList.CurrentRowNumber, "jubsu_date"));
            item.Add("f_drg_bunho", this.grdList.GetItemString(this.grdList.CurrentRowNumber, "drg_bunho"));
            item.Add("f_bunho", this.grdList.GetItemString(this.grdList.CurrentRowNumber, "bunho"));

            retVal = Service.ExecuteScalar(cmdText, item);
            if (!TypeCheck.IsNull(retVal))
            {
                ordChkDrg = retVal.ToString();
            }

            if (ordChkDrg.Equals("Y"))
            {
                bool value = this.procJihInterface("D");

                if (value == false)
                {
                    throw new Exception();
                }
            }
            #endregion

            #region CHECK INJ
            string ordChkInj = "";

            cmdText = @"SELECT DISTINCT 'Y' 
                          FROM (
                                SELECT SUBSTR(A.ORDER_GUBUN,2,1) ORDER_GUBUN
                                  FROM OCS2003 A
                                 WHERE A.HOSP_CODE = :f_hosp_code
                                   AND A.PKOCS2003 IN (SELECT B.FKOCS2003
                                                         FROM DRG3010 B
                                                        WHERE B.HOSP_CODE  = A.HOSP_CODE
                                                          AND B.JUBSU_DATE = :f_jubsu_date
                                                          AND B.DRG_BUNHO  = :f_drg_bunho
                                                          AND B.BUNHO      = :f_bunho)
                               ) C
                         WHERE C.ORDER_GUBUN IN ('B')";

            item.Clear();
            item.Add("f_hosp_code", EnvironInfo.HospCode);
            item.Add("f_jubsu_date", this.grdList.GetItemString(this.grdList.CurrentRowNumber, "jubsu_date"));
            item.Add("f_drg_bunho", this.grdList.GetItemString(this.grdList.CurrentRowNumber, "drg_bunho"));
            item.Add("f_bunho", this.grdList.GetItemString(this.grdList.CurrentRowNumber, "bunho"));

            retVal = Service.ExecuteScalar(cmdText, item);
            if (!TypeCheck.IsNull(retVal))
            {
                ordChkInj = retVal.ToString();
            }

            if (!TypeCheck.IsNull(ordChkInj) && ordChkInj.Equals("Y"))
            {
                bool value = this.procJihInterface("I");

                if (value == false)
                {
                    throw new Exception();
                }
            }
            #endregion
        }
        #endregion

        #region [procAtcInterface() 服薬指導せんI/F]
        private bool procJihInterface(string gubun)
        {
            string jubsuDate = this.grdList.GetItemString(this.grdList.CurrentRowNumber, "jubsu_date");
            string drgBunho = this.grdList.GetItemString(this.grdList.CurrentRowNumber, "drg_bunho");
            string bunho = this.grdList.GetItemString(this.grdList.CurrentRowNumber, "bunho");

            string fkinp1001 = this.grdList.GetItemString(this.grdList.CurrentRowNumber, "fkinp1001");

            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

            //１．中間テーブルデータ生成（DRG5010）
            inputList.Clear();
            inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);       // 病院コード
            inputList.Add("I_JUBSU_DATE", jubsuDate);         // 受付日付
            inputList.Add("I_DRG_BUNHO", drgBunho);           // 投薬番号

            inputList.Add("I_DATA_DUBUN", "0");                       // データ区分(登録)
            //if (rbx2.Checked) inputList.Add("I_DATA_DUBUN", "2");   // データ区分(取消)

            inputList.Add("I_IN_OUT_GUBUN", "I");                     // 入外区分
            inputList.Add("I_BUNHO", bunho);                   // 患者番号
            inputList.Add("I_FK", fkinp1001);                  // FKOUT1001

            #region PR_JIH_DRG_DRG5010_INSERT
            if (gubun.Equals("D"))
            {
                try
                {
                    Service.BeginTransaction();

                    // IFSテーブル作成リターン値
                    int rtnIfsCnt = -1;
                    string pkdrg5010 = "";

                    bool value = Service.ExecuteProcedure("PR_JIH_DRG_DRG5010_INSERT", inputList, outputList);

                    if (value == false || TypeCheck.IsNull(outputList["O_PK"]) || outputList["O_PK"].ToString().Equals("-1"))
                    {
                        throw new Exception(Resources.Exception6);
                    }
                    else
                    {
                        pkdrg5010 = outputList["O_PK"].ToString();

                        BindVarCollection item = new BindVarCollection();

                        //OCS1003に転送情報Update
                        string QuerySQL = @"UPDATE DRG3010 A
                                           SET A.FKJIHKEY     = :f_pkdrg5010
                                         WHERE A.HOSP_CODE    = :f_hosp_code
                                           AND A.JUBSU_DATE   = :f_jubsu_date
                                           AND A.DRG_BUNHO    = :f_drg_bunho
                                           AND A.BUNHO        = :f_bunho
                                           AND A.BUNRYU1      IN('1', '6')";

                        item.Clear();
                        item.Add("f_pkdrg5010", pkdrg5010);
                        item.Add("f_hosp_code", EnvironInfo.HospCode);
                        item.Add("f_jubsu_date", jubsuDate);
                        item.Add("f_drg_bunho", drgBunho);
                        item.Add("f_bunho", bunho);

                        if (!Service.ExecuteNonQuery(QuerySQL, item))
                        {
                            throw new Exception(Resources.Exception2);
                        }

                        //２．I/Fテーブルデータ生成（IFS7301, IFS7302）
                        rtnIfsCnt = this.makeIFSTBL("I", pkdrg5010, "Y", "D");
                    }
                    Service.CommitTransaction();

                    //３．じほうにFILE転送
                    if (rtnIfsCnt == 0)
                    {
                        if (this.atcTrans(pkdrg5010, "D"))
                            XMessageBox.Show(Resources.XMessageBox12, Resources.XMessageBox_caption13, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    Service.RollbackTransaction();
                    XMessageBox.Show(ex.Message, Resources.XMessageBox_caption14, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            #endregion

            #region PR_JIH_INJ_DRG5030_INSERT
            if (gubun.Equals("I"))
            {
                try
                {
                    Service.BeginTransaction();

                    // IFSテーブル作成リターン値
                    int rtnIfsCnt = -1;
                    string pkdrg5030 = "";

                    bool value = Service.ExecuteProcedure("PR_JIH_INJ_DRG5030_INSERT", inputList, outputList);

                    if (value == false || TypeCheck.IsNull(outputList["O_PK"]) || outputList["O_PK"].ToString().Equals("-1"))
                    {
                        throw new Exception(Resources.Exception13);
                    }
                    else
                    {
                        pkdrg5030 = outputList["O_PK"].ToString();

                        BindVarCollection item = new BindVarCollection();

                        //OCS1003に転送情報Update
                        string QuerySQL = @"UPDATE DRG3010 A
                                           SET A.FKJIHKEY     = :f_pkdrg5030
                                         WHERE A.HOSP_CODE    = :f_hosp_code
                                           AND A.JUBSU_DATE   = :f_jubsu_date
                                           AND A.DRG_BUNHO    = :f_drg_bunho
                                           AND A.BUNHO        = :f_bunho
                                           AND A.BUNRYU1      = '4'";

                        item.Clear();
                        item.Add("f_pkdrg5030", pkdrg5030);
                        item.Add("f_hosp_code", EnvironInfo.HospCode);
                        item.Add("f_jubsu_date", jubsuDate);
                        item.Add("f_drg_bunho", drgBunho);
                        item.Add("f_bunho", bunho);

                        if (!Service.ExecuteNonQuery(QuerySQL, item))
                        {
                            throw new Exception(Resources.Exception2);
                        }

                        //２．I/Fテーブルデータ生成（IFS7303, IFS7304）
                        rtnIfsCnt = this.makeIFSTBL("I", pkdrg5030, "Y", "I");
                    }
                    Service.CommitTransaction();

                    //３．じほうにFILE転送
                    if (rtnIfsCnt == 0)
                    {
                        if (this.atcTrans(pkdrg5030, "I"))
                            XMessageBox.Show(Resources.XMessageBox12, Resources.XMessageBox_caption13, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    Service.RollbackTransaction();
                    XMessageBox.Show(ex.Message, Resources.XMessageBox_caption14, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            #endregion

            return true;
        }

        private int makeIFSTBL(string io_gubun, string pkdrg, string send_yn, string gubun)
        {
            string jubsuDate = this.grdList.GetItemString(this.grdList.CurrentRowNumber, "jubsu_date");
            string drgBunho = this.grdList.GetItemString(this.grdList.CurrentRowNumber, "drg_bunho");

            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

            int retVal = -1;

            inputList.Clear();
            outputList.Clear();

            inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
            inputList.Add("I_IO_GUBUN", io_gubun);
            inputList.Add("I_JUBSU_DATE", jubsuDate);
            inputList.Add("I_DRG_BUNHO", drgBunho);
            inputList.Add("I_FKDRG", pkdrg);
            inputList.Add("I_USER_ID", UserInfo.UserID);
            //inputList.Add(send_yn);

            if (gubun.Equals("D")) // DRG
            {
                bool ret = Service.ExecuteProcedure("PR_JIH_DRG_IFS_PROC", inputList, outputList);

                if (ret == false || TypeCheck.IsNull(outputList["O_ERR"]) || outputList["O_ERR"].ToString() == "1")
                {
                    throw new Exception(Resources.Exception14);
                }
                else retVal = Int32.Parse(outputList["O_ERR"].ToString());
            }

            if (gubun.Equals("I")) //INJ
            {
                bool ret = Service.ExecuteProcedure("PR_JIH_INJ_IFS_PROC", inputList, outputList);

                if (ret == false || TypeCheck.IsNull(outputList["O_ERR"]) || outputList["O_ERR"].ToString() == "1")
                {
                    throw new Exception(Resources.Exception15);
                }
                else retVal = Int32.Parse(outputList["O_ERR"].ToString());
            }

            return retVal;
        }

        private bool atcTrans(string pkdrg, string gubun)
        {
            if (TypeCheck.IsNull(pkdrg))
            {
                throw new Exception(Resources.Exception4);
            }

            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText = null;

            if (gubun.Equals("D")) msgText = "97301" + pkdrg;
            if (gubun.Equals("I")) msgText = "97303" + pkdrg;

            //if (gubun.Equals("D")) msgText = "95010" + pkdrg;
            //if (gubun.Equals("I")) msgText = "95030" + pkdrg;

            int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
            if (ret == -1)
            {
                throw new Exception(Resources.Exception16 + msgText);
            }
            return true;
        }
        #endregion

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            this.gridQuery();
        }

        #region [一包化、粉砕変更]
        private void grdPackPowder_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grd = (XEditGrid)sender;

            BindVarCollection bindVals = new BindVarCollection();

            string cmdText = "";

            string fkocs = grd.GetItemString(e.RowNumber, "fkocs2003");

            switch (e.ColName)
            {
                case "drg_pack_yn":

                    string drg_pack_yn = grd.GetItemString(e.RowNumber, "drg_pack_yn");

                    bindVals.Clear();
                    bindVals.Add("f_hosp_code", EnvironInfo.HospCode);
                    bindVals.Add("f_fkocs2003", fkocs);

                    bindVals.Add("f_drg_pack_yn", drg_pack_yn);

                    cmdText = @"UPDATE DRG3010 A
                           SET A.DRG_PACK_YN = :f_drg_pack_yn
                         WHERE A.HOSP_CODE   = :f_hosp_code
                           AND A.FKOCS2003   = :f_fkocs2003
                       ";

                    if (!Service.ExecuteNonQuery(cmdText, bindVals))
                    {
                        throw new Exception(Service.ErrFullMsg);
                    }
                    break;

                case "powder_yn":

                    string powder_yn = grd.GetItemString(e.RowNumber, "powder_yn");

                    bindVals.Clear();
                    bindVals.Add("f_hosp_code", EnvironInfo.HospCode);
                    bindVals.Add("f_fkocs2003", fkocs);

                    bindVals.Add("f_powder_yn", powder_yn);

                    cmdText = @"UPDATE DRG3010 A
                           SET A.POWDER_YN   = :f_powder_yn
                         WHERE A.HOSP_CODE   = :f_hosp_code
                           AND A.FKOCS2003   = :f_fkocs2003
                       ";

                    if (!Service.ExecuteNonQuery(cmdText, bindVals))
                    {
                        throw new Exception(Service.ErrFullMsg);
                    }
                    break;
            }
        }
        #endregion
    }
}

